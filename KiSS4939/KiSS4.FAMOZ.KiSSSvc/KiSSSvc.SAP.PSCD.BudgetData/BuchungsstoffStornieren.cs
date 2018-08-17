using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BuchungsstoffStornieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;
using KiSSSvc.DAL.TransactionalTableAdapters;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.Logging;
using KiSSSvc.SAP.Helpers;
using System.Web.Services.Protocols;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
	public class BuchungsstoffStornieren
	{
		private MI_KISS_BUCHSTOFF003Service svcStornoBuchugsstoff;

		public BuchungsstoffStornieren()
		{
			svcStornoBuchugsstoff = WebServiceSource.GetBuchungsstoffStornierenWS();
		}

		/// <summary>
		/// Diese Methode storniert den Nettobeleg inkl. allen weiteren zugehörigen Nettobelegen (z.B. bei mehreren Auszahlungsdaten)
		///     und allen Bruttobelegen. 
		/// Die Methode geht folgendermassen vor:
		///     1. Sie prüft alle abhängigen Netto- und Brutto-Belege auf deren Status, ob alle Belege noch stornierbar sind
		///     2. Dann werden die Netto-Belege via PSCD storniert (zuerst mit testflag = true)
		///     3. Dann werden die Netto-Belege effektiv im PSCD storniert. Dabei werden im PSCD neue Storno-Netto-Belege erstellt.
		///     4. Dann werden die Netto- und Brutto-Belege im KiSS storniert via stored procedure (unter der verwendung der neuen Storno-Netto-Belege). 
		///        Dabei werden neue Storno-Brutto-Belege erstellt im KiSS. Die Stored Proc gibt die IDs der neuen Storno-Brutto-Buchungen zurück.
		///     5. Dann werden die neuen Storno-Brutto-Belege wie "normale" Buchungen ans PSCD übertragen
		/// </summary>
		/// <param name="kbBuchungIDs"></param>
		/// <param name="user"></param>
		/// <param name="test"></param>
		/// <param name="exceptionMessage"></param>
		/// <returns></returns>
		public CreateObjectResult StornoNettoBelegeByIDs(int[] kbBuchungIDs, UserInfo user, DateTime minimumStornoDatum, ref string warningMessage)
		{
			bool success = true;
			bool pscdNettoBelegeGesendet = false;
			bool pscdBruttoBelegeGesendet = false;

			// TODO: Add Lock to ensure that no other thread can call this method at the same time
			// Erstelle eine String-Liste aller IDs (für Logging)
			string inID = string.Join(", ", new List<int>(kbBuchungIDs).ConvertAll<string>(Convert.ToString).ToArray());
			try
			{
				// Transaktions-Block
				using (TransactionHelper transHelper = new TransactionHelper())
				{
					// Hole alle Netto-Buchungen inkl. abhängigen Buchungen
					KiSSDB.KbBuchungDataTable buchungenTable = KbBuchungBLL.GetWhBelegeFromKbBuchungIDs(transHelper, kbBuchungIDs, true, true);

					// Prüfe alle abhängigen Netto- und Brutto-Belege auf deren Status, ob alle Belege noch stornierbar sind (via Stored Procedure spKbBuchung_StornoCheck
					foreach (KiSSDB.KbBuchungRow belegRow in buchungenTable)
					{
						try
						{
							KbBuchungStornoBLL.spKbBuchung_StornoCheck(belegRow.KbBuchungID);
						}
						catch (Exception ex)
						{
							// Diese Buchung ist offensichtlich nicht stornierbar. Sammle alle Fehlermeldungen
							warningMessage += string.Format("Der Netto-Beleg {0} kann nicht storniert werden: {1}{2}", belegRow.KbBuchungID, ex.ToString(), WebServiceHelperMethods.GetNewLineString());
							success = false;
						}
					}

					if (!success)
					{
						// Mind. eine Netto-Buchung ist in einem nicht stornierbaren Zustand
						return CreateObjectResult.Warning;
					}

					// Ok, alle Netto-Buchungen können storniert werden zu diesem Zeitpunkt, also los
					Log.Info(this.GetType(), string.Format("# Übergebene Netto-Buchungen: {0}, # Netto-Buchungen gefunden (inkl. abhängiger Netto-Buchungen): {1}", kbBuchungIDs.Length, buchungenTable.Count));

					// Die Netto-Belege via PSCD stornieren (zuerst mit testflag = true)
					foreach (KiSSDB.KbBuchungRow belegRow in buchungenTable)
					{
						// Übermittle nur transferierte Belege, bei denen der Storno-Beleg nicht schon erstellt wurde im PSCD.
                        if(!belegRow.IsTransferDatumNull() && (belegRow.KbBuchungStatusCode == 3 || belegRow.KbBuchungStatusCode == 9) && belegRow.IsStornoBelegNrNull())
                        {
							success &= SubmitStornoNettoBelegAnPSCD(transHelper, belegRow, user, true, minimumStornoDatum, ref warningMessage);
						}
					}

					if (!success)
					{
						// Mind. eine Netto-Buchung kann nicht von PSCD storniert werden
						return CreateObjectResult.Warning;
					}

					// Ok, nun werden die Netto-Buchungen effektiv im PSCD storniert und die neu generierte PSCD Beleg-Nummer wird in der Storno-Tabelle gespeichert
					foreach (KiSSDB.KbBuchungRow belegRow in buchungenTable)
					{
						// Übermittle nur transferierte Belege, bei denen der Storno-Beleg nicht schon erstellt wurde im PSCD.
                        if(!belegRow.IsTransferDatumNull() && (belegRow.KbBuchungStatusCode == 3 || belegRow.KbBuchungStatusCode == 9) && belegRow.IsStornoBelegNrNull())
						{
							pscdNettoBelegeGesendet = true;  // Hier setzen wir das Flag, denn ab hier sind wir nicht mehr 100% sicher, ob nicht doch schon ein Beleg ans PSCD geschickt wurde
							success &= SubmitStornoNettoBelegAnPSCD(transHelper, belegRow, user, false, minimumStornoDatum, ref warningMessage);
						}
					}

					if (!success)
					{
						// => Problem: Mind. eine Netto-Buchung ist schiefgegangen im PSCD, was nun zu inkonsistenzen zwischen KiSS und PSCD führt!
						if (pscdNettoBelegeGesendet)
						{
							warningMessage = "Bei der Stornierung von Netto-Buchungen im PSCD ist ein Fehler aufgetreten: ." + WebServiceHelperMethods.GetNewLineString() + warningMessage;
						}
						else
						{
							warningMessage = "Bei der Stornierung von Netto-Buchungen ist ein Fehler aufgetreten. Es sind keine Belege ans PSCD geschickt worden, und auch die Belege im KiSS wurden nicht geändert." + WebServiceHelperMethods.GetNewLineString() + warningMessage;
						}
						return CreateObjectResult.Warning;
					}

					// Nun werden die Netto-Belege im Kiss storniert, wobei gleichzeitig alle abhängigen Brutto-Buchungen auch storniert werden. 
					// Die Stored Proc liefert die StornoGruppierung der neu generierten Storno-Brutto-Buchungen zurück (oder Null, wenn keine neuen Storno-Brutto-Buchungen erstellt wurden)
					string stornoGruppierung = null;

					foreach (KiSSDB.KbBuchungRow belegRow in buchungenTable)
					{
						try
						{
							KbBuchungBLL.StornoNettoBeleg(transHelper, belegRow.KbBuchungID, user.UserID, minimumStornoDatum, ref stornoGruppierung);

							if (!string.IsNullOrEmpty(stornoGruppierung))
							{
								// Es wurden Brutto-Buchungen erstellt, die nun noch ans PSCD geschickt werden müssen

								// Selektiere alle Brutto-Buchungen mit der StornoGruppierung
								KiSSDB.KbBuchungBruttoDataTable bruttoBelege = KbBuchungBruttoBLL.GetBruttoBelegeByGruppierungUmbuchung(transHelper, stornoGruppierung);

								foreach (KiSSDB.KbBuchungBruttoRow bruttoRow in bruttoBelege)
								{
									pscdBruttoBelegeGesendet = true;  // Hier setzen wir das Flag, denn ab hier sind wir nicht mehr 100% sicher, ob nicht doch schon ein Beleg ans PSCD geschickt wurde

									// Schicke die Brutto-Belege ans PSCD. Dies erstellt auch die Storno-Belegnummer, die dann im Bruttobeleg abgelegt wird
									if (!SubmitStornoBruttoBelegAnPSCD(transHelper, bruttoRow, user, false, minimumStornoDatum, ref warningMessage))
									{
										warningMessage = "Bei der Übermittlung des Storno-Brutto-Belegs " + bruttoRow.KbBuchungBruttoID + " mit der StornoGruppierung " + stornoGruppierung + " ist ein Fehler aufgetreten: " + WebServiceHelperMethods.GetNewLineString() + warningMessage;
                                        success = false;
										return CreateObjectResult.Warning;
									}
								}
							}
						}
						catch (Exception ex)
						{
							if (!string.IsNullOrEmpty(stornoGruppierung))
							{
                                if (pscdNettoBelegeGesendet || pscdBruttoBelegeGesendet)
								{
									warningMessage = "Storno des Netto-Belegs " + belegRow.KbBuchungID + ": Bei der Übermittlung von Storno-Brutto-Belegen mit der StornoGruppierung " + stornoGruppierung + " ist ein Fehler aufgetreten:" + WebServiceHelperMethods.GetNewLineString() + ex.ToString() + WebServiceHelperMethods.GetNewLineString() + warningMessage;
								}
								else
								{
									warningMessage = "Storno des Netto-Belegs " + belegRow.KbBuchungID + ": Bei der Übermittlung von Storno-Brutto-Belegen mit der StornoGruppierung " + stornoGruppierung + " ist ein Fehler aufgetreten. Es sind keine Belege ans PSCD geschickt worden, und auch die Belege im KiSS wurden nicht geändert." + WebServiceHelperMethods.GetNewLineString() + ex.ToString() + WebServiceHelperMethods.GetNewLineString() + warningMessage;
								}
							}
							else
							{
                                if (pscdNettoBelegeGesendet || pscdBruttoBelegeGesendet)
								{
									warningMessage = "Storno des Netto-Belegs " + belegRow.KbBuchungID + ": Bei der Übermittlung von Storno-Brutto-Belegen ist ein Fehler aufgetreten, womit ein Risiko besteht, dass einige Netto- und Brutto-Belege im PSCD bereits storniert sind, aber im KiSS noch nicht. Bitte versuchen Sie später erneut, den Beleg zu stornieren, damit kann das Problem ev. behoben werden." + WebServiceHelperMethods.GetNewLineString() + ex.ToString() + WebServiceHelperMethods.GetNewLineString() + warningMessage;
								}
								else
								{
									warningMessage = "Storno des Netto-Belegs " + belegRow.KbBuchungID + ": Bei der Übermittlung von Storno-Brutto-Belegen ist ein Fehler aufgetreten. Es sind keine Belege ans PSCD geschickt worden, und auch die Belege im KiSS wurden nicht geändert." + WebServiceHelperMethods.GetNewLineString() + ex.ToString() + WebServiceHelperMethods.GetNewLineString() + warningMessage;
								}
							}
                            success = false;
							return CreateObjectResult.Warning;
						}
					}

					// Schreibe nun alle Updates auf die KiSS-DB
					transHelper.Complete();
				} // Ende Transaktions-Block (using (TransactionHelper transHelper = new TransactionHelper())
			}
			catch (Exception ex2)
			{
                if (pscdNettoBelegeGesendet || pscdBruttoBelegeGesendet)
				{
					warningMessage = "Beim Storno der Netto-Belege " + inID + " ist ein Fehler aufgetreten, womit ein Risiko besteht, dass einige Netto- oder Brutto-Belege im PSCD bereits storniert sind, aber im KiSS noch nicht! Bitte versuchen Sie später erneut, den Beleg zu stornieren, damit kann das Problem ev. behoben werden." + WebServiceHelperMethods.GetNewLineString() + ex2.ToString() + WebServiceHelperMethods.GetNewLineString() + warningMessage;
				}
				else
				{
					warningMessage = "Beim Storno der Netto-Belege " + inID + " ist ein Fehler aufgetreten. Es sind keine Belege ans PSCD geschickt worden, und auch die Belege im KiSS wurden nicht geändert." + WebServiceHelperMethods.GetNewLineString() + ex2.ToString() + WebServiceHelperMethods.GetNewLineString() + warningMessage;
				}

				success = false;
			}
			finally
			{
				if (!success)
				{
					Log.Error(this.GetType(), "Problem beim Beleg stornieren:" + warningMessage);
				}
			}

			return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
		}

		public CreateObjectResult StornoBruttoBelegeByIDs(int[] kbBuchungBruttoIDs, UserInfo user, bool test, DateTime minimumStornoDatum, ref string warningMessage)
		{
			CreateObjectResult result = CreateObjectResult.Success;
			KiSSDB.KbBuchungBruttoDataTable zuStornierendeBruttoBelege = KbBuchungBruttoBLL.GetBruttoBelegeByKbBuchungIDs(null, null, kbBuchungBruttoIDs);

			Log.Info(this.GetType(), string.Format("StornoBruttoBelegeByIDs, IDs {0}, selektiert {1}", string.Join(", ", new List<int>(kbBuchungBruttoIDs).ConvertAll<string>(Convert.ToString).ToArray()), zuStornierendeBruttoBelege.Count));

			foreach (KiSSDB.KbBuchungBruttoRow bruttoRow in zuStornierendeBruttoBelege)
			{
				using (TransactionHelper transHelper = new TransactionHelper())
				{
					string stornoGruppierung = string.Empty;
					KbBuchungBruttoBLL.StornoBruttoBeleg(transHelper, bruttoRow.KbBuchungBruttoID, user.UserID, minimumStornoDatum, ref stornoGruppierung);
					KiSSDB.KbBuchungBruttoDataTable stornoBruttoBelege = KbBuchungBruttoBLL.GetBruttoBelegeByGruppierungUmbuchung(transHelper, stornoGruppierung);
					if (stornoBruttoBelege.Count != 2)
					{
						warningMessage += string.Format("Es wurden nicht genau zwei Belege mit GruppierungUmbuchung {0} selektiert", stornoGruppierung);
						result = CreateObjectResult.Warning;
						// Wenn der Beleg nicht storniert werden kann, müssen wir nicht weitermachen
						continue;
					}

                    // Hole die Storno-Row
                    KiSSDB.KbBuchungBruttoRow stornoRow = (KiSSDB.KbBuchungBruttoRow)(stornoBruttoBelege.Select("StorniertKbBuchungBruttoID = " + bruttoRow.KbBuchungBruttoID)[0]);
					// Zuerst Testlauf: Kann der Beleg im PSCD überhaupt storniert werden?
					if (!SubmitStornoBruttoBelegAnPSCD(transHelper, stornoRow, user, true, minimumStornoDatum, ref warningMessage))
					{
						warningMessage += string.Format("Bei der Test-Übermittlung des Storno-Brutto-Belegs {0} ist ein Fehler aufgetreten: {1}{2}", stornoRow.KbBuchungBruttoID, WebServiceHelperMethods.GetNewLineString(), warningMessage);
						result = CreateObjectResult.Warning;
						// Wenn der Beleg nicht storniert werden kann, müssen wir nicht weitermachen
						continue;
					}

					if (!test)
					{

						// Schicke die Brutto-Belege ans PSCD. Dies erstellt auch die Storno-Belegnummer, die dann im Bruttobeleg abgelegt wird
						if (!SubmitStornoBruttoBelegAnPSCD(transHelper, stornoRow, user, false, minimumStornoDatum, ref warningMessage))
						{
							warningMessage += "Bei der Übermittlung des Storno-Brutto-Belegs " + stornoRow.KbBuchungBruttoID + " mit der StornoGruppierung " + stornoGruppierung + " ist ein Fehler aufgetreten: " + WebServiceHelperMethods.GetNewLineString() + warningMessage;
							result = CreateObjectResult.Warning;
							continue;
						}
						// Schreibe nun alle Updates auf die KiSS-DB
						transHelper.Complete();
					}
				}
			}
			return result;
		}

		private bool SubmitStornoNettoBelegAnPSCD(TransactionHelper transHelper, KiSSDB.KbBuchungRow belegRow, UserInfo user, bool test, DateTime minimumStornoDatum, ref string exceptionMessage)
		{
			bool success = true;
			string belegart = "ST"; // Stornobeleg
			BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
            recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();
			string fiKey = SapHelper.GetAbstimmschluessel();

			BAPIRET2[] returnMessages = new BAPIRET2[] { };
			long? belegNr = null;
			PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF003", svcStornoBuchugsstoff.Url, belegRow.BelegNr, user);
			try
			{
				string returnMsg = svcStornoBuchugsstoff.MI_KISS_BUCHSTOFF003(
					 "",
					 "KiSS-NBC",     // KiSS-NBC: es wird mit dem von KiSS gelieferten Datum storniert (d.h. die PSCD-interne Belegdatums-Logik wird umgabnen). Falls das mitgegebene StornoDatum in einer geschlossenen Periode liegt, wird eine Fehlermeldung produziert ("Storno kann mit KiSS-Buchungsdatum 12.06.2008 nicht durchgeführt werden").
					 "",
					 "05",
					 SapHelper.GetDocumentNumber(belegRow.BelegNr),
					 "33",
					 belegart,
					 fiKey,
					 "",
					 recKeyInfo,
					 "",
					 "",
					 SapHelper.ConvertDateObject(belegRow.ValutaDatum > minimumStornoDatum ? belegRow.ValutaDatum : minimumStornoDatum),  // StornoDatum = MAX(belegRow.ValutaDatum, minimumStornoDatum)
					 test ? "X" : "",
					 ref returnMessages);
				log.StopWatch();
				log.ReturnMsg = returnMsg;

				// Prüfe, ob es eine Fehlermeldung à la "Beleg XXX wurde bereits mit Beleg YYY storniert"
				// => Falls ja, parsen wir die Storno-Belegnummer YYY raus und verwenden diese
				log.ErrorMsgs = ParseReturnMessages(returnMessages);
				string errorMsgs = log.GetErrorMsgs(false);
				long bnr = 0;

				if (!string.IsNullOrEmpty(errorMsgs) && errorMsgs.Contains("wurde bereits mit Beleg") && errorMsgs.Contains("storniert"))
				{
					// Ja, dies scheint der Fall zu sein, bei dem der Storno-Beleg früher schon mal übermittelt wurde, dann aber KiSS ein Problem hatte, worauf es zu dieser Inkonsistenz gekommen ist
					// => Wir müssen nun (leider) die Storno-Beleg-Nr aus der Fehlermeldung herausparsen (sehr unschön...)
					try
					{
						bnr = long.Parse(errorMsgs.Substring(errorMsgs.IndexOf("wurde bereits mit Beleg") + 24, 11));    // Beleg-Nummern sind immer 11 characters lang
						log.ErrorMsgs = null;    // OK, hat geklappt, dann wollen wir die Fehlermeldung ignorieren (Fast, wir schreiben nur einen Eintrag ins PSCDFehlermeldung-Feld)
						log.ExceptionMsg = null;
						string error = KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung("Info: Der Storno-Netto-Beleg " + belegRow.KbBuchungID + " war in PSCD bereits storniert unter der Storno-Belegnummer " + bnr + ". Dies lässt darauf schliessen, dass dieser Beleg bereits früher storniert wurde, dann aber der Storno vorzeitig abgebrochen wurde.");
						try
						{
							// Update der Storno-Buchung mit der Fehlermeldung 
							KbBuchungStornoBLL.spKbBuchung_StornoUpdateErrorMessage(transHelper, belegRow.KbBuchungID, error);
						}
						catch (Exception ex)
						{
							Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), string.Format("Update der Fehlermeldung '{0}' in Storno-Tabelle für Netto-Beleg {1} fehlgeschlagen.", error, belegRow.KbBuchungID), ex);
						}
					}
					catch (Exception ex2)
					{
						Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), string.Format("Parsen der Storno-Beleg-Nr aus der Fehlermeldung '{0}' ist fehlgeschlagen.", errorMsgs), ex2);
						bnr = 0;
					}
				}

				if (bnr != 0)
				{
					belegNr = bnr;
				}
				else
				{
					if (long.TryParse(returnMsg, out bnr))
						belegNr = bnr;
				}
			}
			catch (SoapException ex)
			{
				log.StopWatch();
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Belege stornieren", ex);
				log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
				exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Netto-Stornobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, log.ExceptionMsg, WebServiceHelperMethods.GetNewLineString());
			}
			catch (Exception ex)
			{
				log.StopWatch();
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Belege stornieren", ex);

				string msg = ex.Message;
				// HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
				if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
					msg = string.Format("Fehler beim Anlegen des Netto-Stornobelegs mit ID {0}: Zwischen XI und PSCD gab es ein Timeout{1}", belegRow.KbBuchungID, WebServiceHelperMethods.GetNewLineString());
				exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Netto-Stornobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, msg, WebServiceHelperMethods.GetNewLineString());
				log.ExceptionMsg = msg;
			}
			finally
			{
				log.WriteToDB();
			}
			if (log.HasErrorOccured() || (!test && !belegNr.HasValue))
			{
				// Entweder ist ein Fehler passiert, oder im Echtlauf wurde keine Belegnummer zurückgegeben
				string error = log.GetErrorMsgs(false);

				if (string.IsNullOrEmpty(log.ExceptionMsg))
				{
					exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Netto-Stornobelegs mit ID {0}: {1}", belegRow.KbBuchungID, log.GetErrorMsgs(false), WebServiceHelperMethods.GetNewLineString());
				}

				try
				{
					// Update der Storno-Buchung mit der Fehlermeldung 
					KbBuchungStornoBLL.spKbBuchung_StornoUpdateErrorMessage(transHelper, belegRow.KbBuchungID, error);
				}
				catch (Exception ex)
				{
					exceptionMessage += string.Format("Update der Fehlermeldung '{0}' in Storno-Tabelle für Netto-Beleg {1} fehlgeschlagen. ", error, belegRow.KbBuchungID) + ex.ToString();
				}
				success = false;
			}
			else
			{
				// Es ist kein Fehler passiert
				if (!test)
				{
					try
					{
						// Dies ist kein Test, d.h. wir müssen nun die neu erstellte Beleg-Nr speichern
						KbBuchungStornoBLL.spKbBuchung_StornoUpdateStornoBelegNr(transHelper, belegRow.KbBuchungID, belegNr.Value);
					}
					catch (Exception ex)
					{
						exceptionMessage += string.Format("Update der Storno BelegNummer '{0}' in Storno-Tabelle für Netto-Beleg {1} fehlgeschlagen. ", belegNr.Value, belegRow.KbBuchungID) + ex.ToString();
						success = false;
					}
				}
			}
			return success;
		}

		private bool SubmitStornoBruttoBelegAnPSCD(TransactionHelper transHelper, KiSSDB.KbBuchungBruttoRow belegRow, UserInfo user, bool test, DateTime minimumStornoDatum, ref string exceptionMessage)
		{
			bool success = true;

			if (belegRow.IsStorniertKbBuchungBruttoIDNull())
			{
				// Dies kein Storno-Beleg, es gibt nichts zu tun hier.
				return true;
			}

			if (belegRow.IsTransferDatumNull())
			{
				// Der Original-Beleg (dessen TransferDatum in diesen Stornobeleg kopiert wurde in der stored proc spKbBuchung_Storno) wurde nie transferiert, d.h. es gibt nichts zu tun hier
				return true;
			}

			string belegart = "ST"; // Stornobeleg
			BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
            recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();
			string fiKey = SapHelper.GetAbstimmschluessel();

			BAPIRET2[] returnMessages = new BAPIRET2[] { };
			long? belegNr = null;
			PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF003", svcStornoBuchugsstoff.Url, belegRow.BelegNr, user);
			try
			{
				string returnMsg = svcStornoBuchugsstoff.MI_KISS_BUCHSTOFF003(
					 "",
					 "KiSS-NBC",     // KiSS-NBC: es wird mit dem von KiSS gelieferten Datum storniert (d.h. die PSCD-interne Belegdatums-Logik wird umgabnen). Falls das mitgegebene StornoDatum in einer geschlossenen Periode liegt, wird eine Fehlermeldung produziert ("Storno kann mit KiSS-Buchungsdatum 12.06.2008 nicht durchgeführt werden").
					 "",
					 "05",
					 SapHelper.GetDocumentNumber(belegRow.BelegNr),
					 "33",
					 belegart,
					 fiKey,
					 "",
					 recKeyInfo,
					 "",
					 "",
					 SapHelper.ConvertDateObject(belegRow.ValutaDatum > minimumStornoDatum ? belegRow.ValutaDatum : minimumStornoDatum),  // StornoDatum = MAX(belegRow.ValutaDatum, minimumStornoDatum)
					 test ? "X" : "",
					 ref returnMessages);
				log.StopWatch();
				log.ReturnMsg = returnMsg;

				// Prüfe, ob es eine Fehlermeldung à la "Beleg XXX wurde bereits mit Beleg YYY storniert"
				// => Falls ja, parsen wir die Storno-Belegnummer YYY raus und verwenden diese
				log.ErrorMsgs = ParseReturnMessages(returnMessages);
				string errorMsgs = log.GetErrorMsgs(false);
				long bnr = 0;

				if (!string.IsNullOrEmpty(errorMsgs) && errorMsgs.Contains("wurde bereits mit Beleg") && errorMsgs.Contains("storniert"))
				{
					// Ja, dies scheint der Fall zu sein, bei dem der Storno-Beleg früher schon mal übermittelt wurde, dann aber KiSS ein Problem hatte, worauf es zu dieser Inkonsistenz gekommen ist
					// => Wir müssen nun (leider) die Storno-Beleg-Nr aus der Fehlermeldung herausparsen (sehr unschön...)
					try
					{
						bnr = long.Parse(errorMsgs.Substring(errorMsgs.IndexOf("wurde bereits mit Beleg") + 24, 11));    // Beleg-Nummern sind immer 11 characters lang
						log.ErrorMsgs = null;    // OK, hat geklappt, dann wollen wir die Fehlermeldung ignorieren (Fast, wir schreiben nur einen Eintrag ins PSCDFehlermeldung-Feld)
						string error = KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung("Info: Der Storno-Brutto-Beleg " + belegRow.KbBuchungBruttoID + " war in PSCD bereits storniert unter der Storno-Belegnummer " + bnr + ". Dies lässt darauf schliessen, dass dieser Beleg bereits früher storniert wurde, dann aber der Storno vorzeitig abgebrochen wurde.");
						try
						{
							// Update der Buchung mit der Fehlermeldung 
							KbBuchungBruttoBLL.UpdatePscdFehlermeldung(transHelper, belegRow, error);
						}
						catch (Exception ex)
						{
							Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), string.Format("Update der PSCD-Fehlermeldung '{0}' in KbBuchungBrutto-Tabelle für Brutto-Beleg {1} fehlgeschlagen.", error, belegRow.KbBuchungBruttoID), ex);
						}
					}
					catch (Exception ex2)
					{
						Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), string.Format("Parsen der Storno-Beleg-Nr aus der Fehlermeldung '{0}' ist fehlgeschlagen.", errorMsgs), ex2);
						bnr = 0;
					}
				}

				if (bnr != 0)
				{
					belegNr = bnr;
				}
				else
				{
					if (long.TryParse(returnMsg, out bnr))
						belegNr = bnr;
				}
			}
			catch (SoapException ex)
			{
				log.StopWatch();
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Belege stornieren", ex);
				log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
				exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Brutto-Stornobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungBruttoID, log.ExceptionMsg, WebServiceHelperMethods.GetNewLineString());
			}
			catch (Exception ex)
			{
				log.StopWatch();
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Belege stornieren", ex);

				string msg = ex.Message;
				// HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
				if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
					msg = string.Format("Fehler beim Anlegen des Brutto-Stornobelegs mit ID {0}: Zwischen XI und PSCD gab es ein Timeout{1}", belegRow.KbBuchungBruttoID, WebServiceHelperMethods.GetNewLineString());
				exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Brutto-Stornobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungBruttoID, msg, WebServiceHelperMethods.GetNewLineString());
				log.ExceptionMsg = msg;
			}
			finally
			{
				log.WriteToDB();
			}
			if (log.HasErrorOccured() || (!test && !belegNr.HasValue))
			{
				// Entweder ist ein Fehler passiert, oder es wurde keine Belegnummer zurückgegeben
				string error = log.GetErrorMsgs(false);

				if (string.IsNullOrEmpty(log.ExceptionMsg))
				{
					exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Brutto-Stornobelegs mit ID {0}: {1}", belegRow.KbBuchungBruttoID, log.GetErrorMsgs(false), WebServiceHelperMethods.GetNewLineString());
				}

				try
				{
					// Update der Buchung mit der Fehlermeldung 
					KbBuchungBruttoBLL.UpdatePscdFehlermeldung(transHelper, belegRow, error);
				}
				catch (Exception ex)
				{
					exceptionMessage += string.Format("Update der Fehlermeldung '{0}' in Storno-Tabelle für Brutto-Beleg {1} fehlgeschlagen. ", error, belegRow.KbBuchungBruttoID) + ex.ToString();
				}
				success = false;
			}
			else
			{
				// Es ist kein Fehler passiert
				if (!test)
				{
					try
					{
						// Wir müssen nun die neu erstellte Beleg-Nr und das TransferDatum speichern
						KbBuchungBruttoBLL.UpdatePscdBelegNr(transHelper, belegRow, belegNr.Value, DateTime.Now);
					}
					catch (Exception ex)
					{
						exceptionMessage += string.Format("Update der Belegnmummer '{0}' in Storno-Tabelle für Brutto-Beleg {1} fehlgeschlagen. ", belegNr.Value, belegRow.KbBuchungBruttoID) + ex.ToString();
						success = false;
					}
				}
			}
			return success;
		}

		private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(BAPIRET2[] returnMessages)
		{
			KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
			int tempInt;
			foreach (BAPIRET2 retMsg in returnMessages)
			{
				KiSSDB.PscdCallReturnMsgRow err = errorTbl.NewPscdCallReturnMsgRow();
				err.CausingSystem = retMsg.SYSTEM;
				err.Field = retMsg.FIELD;
				if (int.TryParse(retMsg.LOG_MSG_NO, out tempInt))
					err.LogNrInternal = tempInt;
				else
					err.SetLogNrInternalNull();
				err.LogNr = retMsg.LOG_NO;
				err.Message1 = retMsg.MESSAGE_V1;
				err.Message2 = retMsg.MESSAGE_V2;
				err.Message3 = retMsg.MESSAGE_V3;
				err.Message4 = retMsg.MESSAGE_V4;
				err.MessageClass = retMsg.ID;
				if (int.TryParse(retMsg.NUMBER, out tempInt))
					err.MessageNumber = tempInt;
				else
					err.SetMessageNumberNull();
				err.Message = retMsg.MESSAGE;
				err.Parameter = retMsg.PARAMETER;
				if (int.TryParse(retMsg.ROW, out tempInt))
					err.Row = tempInt;
				else
					err.SetRowNull();

				if (!string.IsNullOrEmpty(retMsg.TYPE))
					err.Severity = retMsg.TYPE;

				errorTbl.AddPscdCallReturnMsgRow(err);
			}
			return errorTbl;
		}

		/// <summary>
		/// Check ob Beleg bereits an Pscd gesendet ist
		/// </summary>
		/// <param name="belegRow"></param>
		/// <returns></returns>
		private bool IsBelegVerbucht(KiSSDB.KbBuchungBruttoRow belegRow)
		{
			return !belegRow.IsKbBuchungStatusCodeNull() && (belegRow.KbBuchungStatusCode >= 3);
		}


		#region Kg

		public CreateObjectResult StornoKgBudget(int kgBudgetID, UserInfo user, bool test)
		{
			bool success = true;
			string exceptionMessage = "";
			KiSSDB.KgBuchungDataTable buchungenTable = KgBuchungBLL.GetStornoBelegeOfKgBudget(kgBudgetID);
			foreach (KiSSDB.KgBuchungRow stornoBelegRow in buchungenTable)
			{
				success &= SubmitStornoKgBeleg(ref exceptionMessage, stornoBelegRow, user, test);
			}
			if (!string.IsNullOrEmpty(exceptionMessage))
				throw new Exception(exceptionMessage);
			return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
		}

		public CreateObjectResult StornoKgBeleg(int kgBuchungID, UserInfo user, bool test)
		{
			bool success = true;
			string exceptionMessage = "";
			KiSSDB.KgBuchungDataTable buchungenTable = KgBuchungBLL.GetStornoBelegByID(kgBuchungID);
			foreach (KiSSDB.KgBuchungRow stornoBelegRow in buchungenTable)
			{
				success &= SubmitStornoKgBeleg(ref exceptionMessage, stornoBelegRow, user, test);
			}
			if (!string.IsNullOrEmpty(exceptionMessage))
				throw new Exception(exceptionMessage);
			return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
		}

		public CreateObjectResult StornoKgBelege(int[] kgBuchungID, UserInfo user, bool test)
		{
			bool success = true;
			string exceptionMessage = "";
			KiSSDB.KgBuchungDataTable buchungenTable = KgBuchungBLL.GetStornoBelegeByIDs(kgBuchungID);
			foreach (KiSSDB.KgBuchungRow stornoBelegRow in buchungenTable)
			{
				success &= SubmitStornoKgBeleg(ref exceptionMessage, stornoBelegRow, user, test);
			}
			if (!string.IsNullOrEmpty(exceptionMessage))
				throw new Exception(exceptionMessage);
			return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
		}

		private bool SubmitStornoKgBeleg(ref string exceptionMessage, KiSSDB.KgBuchungRow stornoBelegRow, UserInfo user, bool test)
		{
			bool success = true;
			try
			{
				string belegart = "ST"; // Stornobeleg
				BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
                recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();
				string fiKey = SapHelper.GetAbstimmschluessel();

				BAPIRET2[] returnMessages = new BAPIRET2[] { };
				//using (BelegNr belegNumber = new BelegNr(KeysBLL.GetBelegNr(belegart)))
				//{
				long? belegNr = null;
				PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF003", svcStornoBuchugsstoff.Url, stornoBelegRow.StorniertBelegNr, user);
				try
				{
					string returnMsg = svcStornoBuchugsstoff.MI_KISS_BUCHSTOFF003(
						"",
						"",
						"",
						"05",
						SapHelper.GetDocumentNumber(stornoBelegRow.StorniertBelegNr),
						"33",
						belegart,
						fiKey,
						"",
						recKeyInfo,
						"",
						"",
						"",//SapHelper.ConvertDateObject(stornoBelegRow.StorniertValuta),
								test ? "X" : "",
						ref returnMessages);
					log.StopWatch();
					log.ReturnMsg = returnMsg;
					log.ErrorMsgs = ParseReturnMessages(returnMessages);
					long bnr;
					if (long.TryParse(returnMsg, out bnr))
						belegNr = bnr;
				}
				catch (Exception ex)
				{
					log.StopWatch();
					log.ExceptionMsg = ex.Message;
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
				}
				finally
				{
					log.WriteToDB();
				}
				if (!log.HasErrorOccured() && belegNr.HasValue)
				{
					stornoBelegRow.KgBuchungStatusCode = 3; // verbucht
					stornoBelegRow.PscdFehlermeldung = ""; // Ev. vorhandene Fehlermeldung löschen
					KgBuchungBLL.UpdateStatusCode(stornoBelegRow, belegNr);
				}
				else
				{
					stornoBelegRow.KgBuchungStatusCode = 2; // freigegeben
					stornoBelegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
					success = false;
					KgBuchungBLL.UpdateStatusCode(stornoBelegRow, null);
				}
				//}
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
				success = false;
				exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
			}
			return success;
		}

		#endregion

	}

}

