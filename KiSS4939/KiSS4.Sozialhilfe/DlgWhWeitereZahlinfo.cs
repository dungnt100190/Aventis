using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public partial class DlgWhWeitereZahlinfo : KissDialog, IBelegleser
    {
        #region Enumerations

        public enum KiSSKunde
        {
            BSS = 1,	// BSS ist Standard
            FAMOZ = 2	// ZH
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private const string FLD_KREDITOR = "Kreditor";
        private const string FLD_NEW_ID = "TempID";
        private readonly int _bgPositionId;
        private readonly bool _doPostChecks;
        private readonly bool _readOnly;
        private readonly List<Termin> _terminList = new List<Termin>();
        private readonly List<Termin> _terminListLt = new List<Termin>();

        #endregion

        #region Private Fields

        private bool _calendarFilling;
        private bool _isModified;

        #endregion

        #endregion

        #region Constructors

        public DlgWhWeitereZahlinfo(int aBgPositionId, bool aReadOnly)
            : this()
        {
            _bgPositionId = aBgPositionId;
            _readOnly = aReadOnly;
            _isModified = false;
            _doPostChecks = false;

            lblZahlbarAn.Left = lblMitteilung.Left;
            edtValutaTermine.Left = edtValutaDatum.Left;

            edtCalendar.DateChanged += edtCalendar_DateChanged;
            timer1.Tick += timer1_Tick;

            colAuszahlung.ColumnEdit = kissGrid1.GetLOVLookUpEdit(
                DBUtil.OpenSQL(@"select Code, ShortText from dbo.XLOVCode where LOVName = 'KbAuszahlungsArt'"),
                "Code",
                "ShortText"
            );
            colTermin.ColumnEdit = kissGrid1.GetLOVLookUpEdit("BgAuszahlungsTermin");

            // Hauptquery öffnen
            qryBgAuszahlungPerson.CanUpdate = !_readOnly;
            qryBgAuszahlungPerson.Fill(_bgPositionId);

            // save Concurrency Info for payment in list.
            //11byte[] concurrenyAuftragTSBefore = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonTS] as byte[];
            //11byte[] concurrenyZyklusTSBefore = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonTS] as byte[];

            if (DBUtil.IsEmpty(qryBgAuszahlungPerson["BaPersonID"]))
            {
                // wenn noch keine Auszahlungen an UE-Personen definiert wurden, dann ist BaPersonID leer
                // deshalb füllen wir hier BaPersonID auf
                qryBgAuszahlungPerson["BaPersonID"] = qryBgAuszahlungPerson["UEPersonID"];
                qryBgAuszahlungPerson.Post();
            }

            // der erste Datensatz muss jener des Fallträgers sein (sortierung muss so sein!)
            // damit neu erstellte Datensätze zu Personen der UE gefüllt werden können,
            // legen wir die Daten des Fallträgers in Variablen ab,
            // um sie später zum Füllen von neuen Datensätzen zu verwenden:
            object bgAuszahlungPersonIdLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonID];
            object bgZahlungsmodusIdLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgZahlungsmodusID];
            object kbAuszahlungsArtCodeLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.KbAuszahlungsArtCode];
            object bgAuszahlungsTerminCodeLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode];
            object bgWochentagCodesLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgWochentagCodes];
            object baZahlungswegIdLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BaZahlungswegID];
            object zahlungsgrundLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.Zahlungsgrund];
            object referenzNummerLt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.ReferenzNummer];
            object mitteilungZeile2Lt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile2];
            object mitteilungZeile3Lt = qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile3];
            object kreditorLt = qryBgAuszahlungPerson[FLD_KREDITOR];
            object zusatzInfoLt = qryBgAuszahlungPerson["ZusatzInfo"];
            object valutaDatumLt = qryBgAuszahlungPerson["ValutaDatum"];
            object valutaTermineLt = qryBgAuszahlungPerson["ValutaTermine"];
            object einzahlungsscheinCodeLt = qryBgAuszahlungPerson["EinzahlungsscheinCode"];

            // In der DB nicht vorhandene UE-Personen müssen speziell mit temporären Schlüssel versehen werden,
            // damit eine Zuordnung zu den Terminen gewährleistet ist (BgAuszahlungPersonID is leer!!!).
            // dazu zählen wir abwärts beginnend mit -1
            int newIDs = -1;
            foreach (DataRow rowPers in qryBgAuszahlungPerson.DataTable.Rows)
            {
                rowPers[DBO.BgAuszahlungPerson.BgPositionID] = _bgPositionId;
                rowPers[DBO.BgAuszahlungPerson.BaPersonID] = rowPers["UEPersonID"];
                if (DBUtil.IsEmpty(rowPers[DBO.BgAuszahlungPerson.BgAuszahlungPersonID]))
                {
                    rowPers[DBO.BgAuszahlungPerson.BgAuszahlungPersonID] = newIDs;
                    rowPers[FLD_NEW_ID] = newIDs;
                    newIDs--;
                }
                else
                {
                    rowPers[FLD_NEW_ID] = rowPers[DBO.BgAuszahlungPerson.BgAuszahlungPersonID];
                }
            }

            // Alle existierenden Daten aus BgAuszahlungPersonTermin sammeln,
            // damit Korrekturen durch den User in _PersonenDatumList zwischengespeichert werden können
            qryBgAuszahlungPersonTermin.Fill(_bgPositionId);

            foreach (DataRow rowTermin in qryBgAuszahlungPersonTermin.DataTable.Rows)
            {
                _terminList.Add(new Termin(
                    Utils.ConvertToInt(rowTermin[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonTerminID]),
                    Utils.ConvertToInt(rowTermin[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonID]),
                    Utils.ConvertToDateTime(rowTermin[DBO.BgAuszahlungPersonTermin.Datum])
                ));

                if (Utils.ConvertToInt(rowTermin[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonID]) == Utils.ConvertToInt(bgAuszahlungPersonIdLt))
                {
                    // hier die Termine es Fallträgers in _PersonenDatumListLT speichern,
                    // damit Termine für andere Personen in der UE analog LT erzeugt werden können
                    _terminListLt.Add(new Termin(
                        Utils.ConvertToInt(qryBgAuszahlungPersonTermin[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonTerminID]),
                        Utils.ConvertToInt(qryBgAuszahlungPersonTermin[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonID]),
                        Utils.ConvertToDateTime(qryBgAuszahlungPersonTermin[DBO.BgAuszahlungPersonTermin.Datum])
                    ));
                }
            }

            if (qryBgAuszahlungPerson.Find(FLD_NEW_ID + "=-1"))
            {
                // es gibt mindestens eine Person aus der UE, bei welcher noch keine individuellen Auszahlungstermine definiert wurden.
                // Solche Daten müssen jetzt mit Vorgabewerten anhand der Daten des Fallträgers gefüllt werden:
                foreach (DataRow rowPers in qryBgAuszahlungPerson.DataTable.Rows)
                {
                    // noch die Mitteilung erfassen, für wen diese Zahlung ist
                    // aber nur, wenn diese infos auch beim LT gefüllt sind
                    rowPers[DBO.BgAuszahlungPerson.MitteilungZeile1] = rowPers["PersonVornameName"];

                    if (!DBUtil.IsEmpty(mitteilungZeile2Lt))
                    {
                        rowPers[DBO.BgAuszahlungPerson.MitteilungZeile2] = rowPers["PersonWohnsitzStrasse"];
                    }

                    if (!DBUtil.IsEmpty(mitteilungZeile3Lt))
                    {
                        rowPers[DBO.BgAuszahlungPerson.MitteilungZeile3] = rowPers["PersonWohnsitzOrt"];
                    }

                    if (Utils.ConvertToInt(rowPers[DBO.BgAuszahlungPerson.BgAuszahlungPersonID]) < 0 && !Utils.ConvertToBool(rowPers["LT"], true))
                    {
                        rowPers[DBO.BgAuszahlungPerson.BgPositionID] = _bgPositionId;
                        rowPers[DBO.BgAuszahlungPerson.BgZahlungsmodusID] = bgZahlungsmodusIdLt;
                        rowPers[DBO.BgAuszahlungPerson.KbAuszahlungsArtCode] = kbAuszahlungsArtCodeLt;
                        rowPers[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode] = bgAuszahlungsTerminCodeLt;
                        rowPers[DBO.BgAuszahlungPerson.BgWochentagCodes] = bgWochentagCodesLt;
                        rowPers[DBO.BgAuszahlungPerson.BaZahlungswegID] = baZahlungswegIdLt;
                        rowPers[DBO.BgAuszahlungPerson.Zahlungsgrund] = zahlungsgrundLt;
                        rowPers[DBO.BgAuszahlungPerson.ReferenzNummer] = referenzNummerLt;
                        rowPers[FLD_KREDITOR] = kreditorLt;
                        rowPers["ZusatzInfo"] = zusatzInfoLt;
                        rowPers["ValutaDatum"] = valutaDatumLt;
                        rowPers["ValutaTermine"] = valutaTermineLt;
                        rowPers["EinzahlungsscheinCode"] = einzahlungsscheinCodeLt;

                        // jetzt müssen auch noch die beim LT bereits existierenden Termine bei allen UE-Personen nachgetragen werden
                        int nId = Utils.ConvertToInt(rowPers[FLD_NEW_ID]);
                        foreach (Termin pd in _terminListLt)
                        {
                            _terminList.Add(new Termin(0, nId, pd.Datum));
                        }
                    }
                }
            }

            // Ansichtsbeginn soll beim ersten Datensatz sein:
            qryBgAuszahlungPerson.First();
            _doPostChecks = true;
            qryBgAuszahlungPerson_PositionChanged(null, null);
            SetEditMode();
        }

        public DlgWhWeitereZahlinfo()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void BgAuszahlungPersonTermin_Delete(int aId)
        {
            DBUtil.ExecSQLThrowingException(@"
                delete dbo.BgAuszahlungPersonTermin
                where BgAuszahlungPersonTerminID = {0}",
                aId
            );
        }

        private void BgAuszahlungPersonTermin_Insert(int aPersId, DateTime aDat)
        {
            DBUtil.ExecSQLThrowingException(@"
                insert into dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
                values({0}, {1})",
                aPersId,
                aDat
            );
        }

        private void BgAuszahlungPersonTermin_Update(int aId, int aPersId, DateTime aDat)
        {
            DBUtil.ExecSQLThrowingException(@"
                update dbo.BgAuszahlungPersonTermin set BgAuszahlungPersonID = {0}, Datum = {1}
                where BgAuszahlungPersonTerminID = {2}",
                aPersId,
                aDat,
                aId
            );
        }

        private void ShowInfo_KeineKreditorenEintraege()
        {
            KissMsg.ShowInfo(
                Name,
                "KeineKreditorenEintraege",
                "Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!"
            );
        }

        private void TerminList_Delete(int aId)
        {
            Termin[] terminArray = _terminList.ToArray();
            foreach (Termin pd in terminArray)
            {
                if (pd.AuszPersonId == aId)
                {
                    _terminList.Remove(pd);
                }
            }
        }

        private void TerminList_SetNewIds(int tempId, int maxId)
        {
            Termin[] tArray = _terminList.ToArray();
            foreach (Termin trm in tArray)
            {
                if (trm.AuszPersonId == tempId)
                {
                    _terminList.Add(new Termin(trm.AuszPersonTerminId, maxId, trm.Datum));
                    _terminList.Remove(trm);
                }
            }
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            userCancel = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!qryBgAuszahlungPerson.Post())
            {
                return;
            }

            if (_isModified)
            {
                Session.BeginTransaction();
                try
                {
                    // Kontrolle, ob in der Zwischenzeit jemand anders die Datensätze editiert hat:
                    // zuerst für Tabelle BgAuszahlungPerson....:
                    SqlQuery qryTsCheck = DBUtil.OpenSQL(@"
                        select BgAuszahlungPersonID, BgAuszahlungPersonTS
                        from dbo.BgAuszahlungPerson
                        where BgPositionID = {0}",
                        _bgPositionId
                    );
                    DBUtil.CheckForTimeStampConflict_OnePK(
                        qryBgAuszahlungPerson,
                        qryTsCheck,
                        DBO.BgAuszahlungPerson.BgAuszahlungPersonID,
                        DBO.BgAuszahlungPerson.BgAuszahlungPersonTS
                    );

                    // Kontrolle, ob in der Zwischenzeit jemand anders die Datensaätze editiert hat:
                    // .... dann für Tabelle BgAuszahlungPersonTermin:
                    qryTsCheck = DBUtil.OpenSQL(@"
                        select T.BgAuszahlungPersonTerminID, T.BgAuszahlungPersonTerminTS
                        from dbo.BgAuszahlungPersonTermin T
                        left join dbo.BgAuszahlungPerson P on P.BgAuszahlungPersonID = T.BgAuszahlungPersonID
                        where P.BgPositionID = {0}",
                        _bgPositionId
                    );
                    DBUtil.CheckForTimeStampConflict_OnePK(
                        qryBgAuszahlungPersonTermin,
                        qryTsCheck,
                        DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonTerminID,
                        DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonTerminTS
                    );

                    foreach (DataRow row in qryBgAuszahlungPerson.DataTable.Rows)
                    {
                        if (Utils.ConvertToInt(row["BgAuszahlungPersonID"]) > 0)
                        {
                            DBUtil.ExecSQLThrowingException(@"
                                update dbo.BgAuszahlungPerson set
                                    BgPositionID = {0},
                                    BaPersonID = {1},
                                    BgZahlungsmodusID = {2},
                                    KbAuszahlungsArtCode = {3},
                                    BgAuszahlungsTerminCode = {4},
                                    BgWochentagCodes = {5},
                                    BaZahlungswegID = {6},
                                    Zahlungsgrund = {7},
                                    ReferenzNummer = {8},
                                    MitteilungZeile1 = {9},
                                    MitteilungZeile2 = {10},
                                    MitteilungZeile3 = {11}
                                where BgAuszahlungPersonID = {12}",
                                row["BgPositionID"],
                                row["BaPersonID"],
                                row["BgZahlungsmodusID"],
                                row["KbAuszahlungsArtCode"],
                                row["BgAuszahlungsTerminCode"],
                                row["BgWochentagCodes"],
                                row["BaZahlungswegID"],
                                row["Zahlungsgrund"],
                                row["ReferenzNummer"],
                                row["MitteilungZeile1"],
                                row["MitteilungZeile2"],
                                row["MitteilungZeile3"],
                                row["BgAuszahlungPersonID"]
                            );
                        }
                        else if (Utils.ConvertToInt(row[FLD_NEW_ID]) < 0)
                        {
                            object maxId = DBUtil.ExecuteScalarSQLThrowingException(@"
                                insert into dbo.BgAuszahlungPerson (
                                    BgPositionID,
                                    BaPersonID,
                                    BgZahlungsmodusID,
                                    KbAuszahlungsArtCode,
                                    BgAuszahlungsTerminCode,
                                    BgWochentagCodes,
                                    BaZahlungswegID,
                                    Zahlungsgrund,
                                    ReferenzNummer,
                                    MitteilungZeile1,
                                    MitteilungZeile2,
                                    MitteilungZeile3)
                                values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})
                                select SCOPE_IDENTITY()",
                                row["BgPositionID"],
                                row["BaPersonID"],
                                row["BgZahlungsmodusID"],
                                row["KbAuszahlungsArtCode"],
                                row["BgAuszahlungsTerminCode"],
                                row["BgWochentagCodes"],
                                row["BaZahlungswegID"],
                                row["Zahlungsgrund"],
                                row["ReferenzNummer"],
                                row["MitteilungZeile1"],
                                row["MitteilungZeile2"],
                                row["MitteilungZeile3"]
                            );

                            // Bei INSERT gibt es neue Primärschlüssel,
                            // welche nun auf die Liste der Termine übertragen werden müssen:
                            row[DBO.BgAuszahlungPerson.BgAuszahlungPersonID] = maxId;
                            TerminList_SetNewIds(Utils.ConvertToInt(row[FLD_NEW_ID]), Convert.ToInt32(maxId));
                        }
                    }

                    // qryBgAuszahlungPersonTermin muss nun aktualisiert werden,
                    // damit die bereits vorhandenen Termine dieser Budgetposition wiederverwendet werden können:
                    qryBgAuszahlungPersonTermin.Fill(_bgPositionId);

                    // Die vorhandenen Schlüssel übertragen wir nun auf die Liste:
                    // hat es mehr Zeilen auf der Datenbank als in der Liste, müssen INSERTs gemacht werden,
                    // ansonsten müssen einige Zeilen mit DELETE gelöscht werden:
                    Termin[] terminArray = _terminList.ToArray();
                    int aIndex = 0;
                    if (qryBgAuszahlungPersonTermin.Count > _terminList.Count)
                    {
                        // hat es mehr Zeilen auf der Datenbank als in der Liste:
                        // also zuerst möglichst viele verwenden, den Rest löschen:
                        foreach (DataRow row in qryBgAuszahlungPersonTermin.DataTable.Rows)
                        {
                            if (aIndex < _terminList.Count)
                            {
                                terminArray[aIndex].AuszPersonTerminId = Utils.ConvertToInt(row[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonTerminID]);
                            }
                            else
                            {
                                // diese Zeile muss gelöscht werden
                                BgAuszahlungPersonTermin_Delete(Utils.ConvertToInt(row[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonTerminID]));
                            }
                            aIndex++;
                        }
                    }
                    else
                    {
                        // hat es weniger Zeilen in der Datenbank als in der Liste:
                        // also alle vorhandenen verwenden, ...
                        foreach (DataRow row in qryBgAuszahlungPersonTermin.DataTable.Rows)
                        {
                            terminArray[aIndex].AuszPersonTerminId = Utils.ConvertToInt(row[DBO.BgAuszahlungPersonTermin.BgAuszahlungPersonTerminID]);
                            aIndex++;
                        }
                        // ... die Restlichen müssen noch eingefügt werden:
                        for (int i = qryBgAuszahlungPersonTermin.Count; i < _terminList.Count; i++)
                        {
                            terminArray[i].AuszPersonTerminId = 0;
                        }
                    }

                    for (int i = 0; i < _terminList.Count; i++)
                    {
                        if (terminArray[i].AuszPersonTerminId > 0)
                        {
                            // wenn der PK > 0 ist, existiert der Datensatz und es kann nur ein UPDATE gemacht werden
                            BgAuszahlungPersonTermin_Update(terminArray[i].AuszPersonTerminId, terminArray[i].AuszPersonId, terminArray[i].Datum);
                        }
                        else
                        {
                            // wenn der PK = 0 ist, existiert der Datensatz nicht und es muss ein INSERT gemacht werden
                            BgAuszahlungPersonTermin_Insert(terminArray[i].AuszPersonId, terminArray[i].Datum);
                        }
                    }
                    Session.Commit();
                }
                catch (DBConcurrencyException ex)
                {
                    Session.Rollback();
                    KissMsg.ShowError(
                        Name,
                        "DatenNichtMehrAktuell",
                        "Die Daten wurden in der Zwischenzeit von einem anderen Benutzer verändert.\r\nLaden Sie die Maske neu.",
                        ex
                    );
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    KissMsg.ShowError(Name, "FehlerBeimSpeichern", "Beim Speichern der Daten ist ein Fehler aufgetreten.", ex);
                }
            }

            if (_isModified)
            {
                userCancel = false;
                DialogResult = DialogResult.OK;
            }
            else
            {
                userCancel = true;
                DialogResult = DialogResult.Cancel;
            }
        }

        private void edtBgAuszahlungsTerminCode_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgAuszahlungPerson.IsFilling) return;
            if (!edtBgAuszahlungsTerminCode.Focused) return;

            qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode] = edtBgAuszahlungsTerminCode.EditValue;
            int bgAuszahlungsTerminCode = (int)qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode];

            switch (bgAuszahlungsTerminCode)
            {
                case 6: // Wochentage
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgWochentagCodes] = DBNull.Value;
                    break;

                case 99: //individuell
                    int aId = Utils.ConvertToInt(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonID]);
                    TerminList_Delete(aId);
                    break;
            }

            LoadValutaTermine();
            DisplayValutaTermine();
            DisplayCalendarBoldDates();
            SetEditMode();

            switch (bgAuszahlungsTerminCode)
            {
                case 1:  // 1x pro Monat
                case 2:  // 2x pro Monat
                case 3:  // wöchentlich
                case 5:  // 14-täglich
                    break;

                case 4:  // Valuta
                    tabZahlinfo.SelectTab(tpgZahlinfo);
                    break;

                case 6:  // Wochentage
                case 99: // Individuell
                    tabZahlinfo.SelectTab(tpgKalender);
                    break;
            }
        }

        private void edtCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (_calendarFilling)
            {
                return;
            }

            if (Array.IndexOf(edtCalendar.BoldedDates, e.Start) >= 0)
            {
                edtCalendar.RemoveBoldedDate(e.Start);
            }
            else
            {
                edtCalendar.AddBoldedDate(e.Start);
            }

            SaveCalendarBoldDatesToList();
            DisplayValutaTermine();
            timer1.Enabled = true;
        }

        private void edtKbAuszahlungsArtCode_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgAuszahlungPerson.IsFilling) return;
            if (!edtKbAuszahlungsArtCode.Focused) return;
            if (!edtKbAuszahlungsArtCode.UserModified) return;

            qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.KbAuszahlungsArtCode] = edtKbAuszahlungsArtCode.EditValue;
            SetEditMode();
            int auszahlungsArt = ShUtil.GetCode(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.KbAuszahlungsArtCode]);

            switch (auszahlungsArt)
            {
                case 101:
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile1] = TruncateString(qryBgAuszahlungPerson["PersonVornameName"], 35);
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile2] = DBNull.Value;
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile3] = DBNull.Value;

                    tabZahlinfo.SelectTab(tpgZahlinfo);
                    break;

                case 103:
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile1] = TruncateString(qryBgAuszahlungPerson["PersonVornameName"], 35);
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile2] = TruncateString(qryBgAuszahlungPerson["PersonWohnsitzStrasse"], 35);
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile3] = TruncateString(qryBgAuszahlungPerson["PersonWohnsitzOrt"], 35);

                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BaZahlungswegID] = DBNull.Value;
                    qryBgAuszahlungPerson[FLD_KREDITOR] = DBNull.Value;
                    qryBgAuszahlungPerson["ZusatzInfo"] = DBNull.Value;
                    qryBgAuszahlungPerson["EinzahlungsscheinCode"] = DBNull.Value;
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.ReferenzNummer] = DBNull.Value;

                    tabZahlinfo.SelectTab(tpgMitteilung);
                    break;
            }
            qryBgAuszahlungPerson.RefreshDisplay();
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlKreditor(edtKreditor.EditValue.ToString(), e.ButtonClicked);
        }

        private void qryBgAuszahlungPerson_AfterPost(object sender, EventArgs e)
        {
            // Valuta-Termine speichern
            //SaveValutaTermine();
        }

        private void qryBgAuszahlungPerson_BeforePost(object sender, EventArgs e)
        {
            if (!_doPostChecks) return;

            int auszahlungsTermin = ShUtil.GetCode(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode]);
            int auszahlungsArt = ShUtil.GetCode(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.KbAuszahlungsArtCode]);
            int es = ShUtil.GetCode(qryBgAuszahlungPerson["EinzahlungsscheinCode"]);

            DBUtil.CheckNotNullField(edtKbAuszahlungsArtCode, lblKbAuszahlungsArtCode.Text);
            DBUtil.CheckNotNullField(edtBgAuszahlungsTerminCode, lblBgAuszahlungsTerminCode.Text);

            // Valuta
            if (auszahlungsTermin == 4)
            {
                CheckNotNullFieldOnTabPage(edtValutaDatum, lblValutaDatum.Text, tpgZahlinfo);
            }

            // Wochentag
            if (auszahlungsTermin == 6)
            {
                CheckNotNullFieldOnTabPage(edtWochentagCodes, "Wochentage", tpgKalender);
            }

            // individuell
            if (auszahlungsTermin == 99)
            {
                if (edtCalendar.BoldedDates == null)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(
                        Name,
                        "KeineIndividuellenAuszahltermine",
                        "Es sind noch keine individuellen Auszahltermine erfasst."
                    ));
                }
            }

            // elektronische Auszahlung
            if (auszahlungsArt == 101)
            {
                CheckNotNullFieldOnTabPage(edtKreditor, lblKreditor.Text, tpgZahlinfo);
            }

            // bar
            if (auszahlungsArt == 103)
            {
                CheckNotNullFieldOnTabPage(edtMitteilungZeile1, lblZahlbarAn.Text, tpgMitteilung);
            }

            // oranger ES
            if (es == 1)
            {
                CheckNotNullFieldOnTabPage(edtReferenzNummer, lblReferenzNummer.Text, tpgZahlinfo);
            }

            // Mitteilungszeilen begrenzen auf 35 Zeichen
            qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile1] = TruncateString(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile1], 35);
            qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile2] = TruncateString(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile2], 35);
            qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile3] = TruncateString(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile3], 35);

            // die in der Kalender-Komponente gewählen Termine auf die temporäre Liste _PersonenDatumList übertragen
            SaveCalendarBoldDatesToList();

            // die Termine als Liste abilden in eime String abbilden
            DisplayValutaTermine();

            _isModified = true;
        }

        private void qryBgAuszahlungPerson_PositionChanged(object sender, EventArgs e)
        {
            if (qryBgAuszahlungPerson.Count == 0)
            {
                return;
            }
            SetEditMode();
            DisplayCalendarBoldDates();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ApplicationFacade.DoEvents();
            timer1.Enabled = false;

            int budgetJahr = (int)qryBgAuszahlungPerson["BudgetJahr"];
            int budgetMonat = (int)qryBgAuszahlungPerson["BudgetMonat"];
            DateTime firstDate = new DateTime(budgetJahr, budgetMonat, 1);

            _calendarFilling = true;
            try
            {
                edtCalendar.SelectionRange = new SelectionRange(firstDate, firstDate.AddDays(1));
            }
            finally
            {
                _calendarFilling = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            if (_readOnly)
            {
                KissMsg.ShowInfo(
                    Name,
                    "NeueDatenBelegleser",
                    "Neue Daten vom Belegleser: Die Daten sind schreibgeschützt."
                );
                return;
            }

            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;
            dlg.SucheBaZahlungsweg(beleg);

            switch (dlg.Count)
            {
                case 0:
                    ShowInfo_KeineKreditorenEintraege();
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BaZahlungswegID] = DBNull.Value;
                    qryBgAuszahlungPerson["Kreditor"] = DBNull.Value;
                    qryBgAuszahlungPerson["ZusatzInfo"] = DBNull.Value;

                    // TODO RH "Betrag" gibt es nicht? Was sollte hier gemacht werden?
                    /*
                    if (beleg.Betrag > 0)
                    {
                        qryBgAuszahlungPerson["Betrag"] = beleg.Betrag;
                    }
                    */
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.ReferenzNummer] = beleg.ReferenzNummer;
                    break;

                case 1:
                    transfer = true;
                    break;

                default:
                    transfer = dlg.ShowDialog(this) == DialogResult.OK;
                    break;
            }

            if (transfer)
            {
                qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BaZahlungswegID] = dlg["BaZahlungswegID"];
                qryBgAuszahlungPerson[FLD_KREDITOR] = dlg["Kreditor"];
                qryBgAuszahlungPerson["ZusatzInfo"] = dlg["ZusatzInfo"];
                qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.ReferenzNummer] = beleg.ReferenzNummer;
                qryBgAuszahlungPerson["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode"];

                // TODO RH "Betrag" gibt es nicht? Was sollte hier gemacht werden?
                /*
                if (beleg.Betrag > 0)
                {
                    qryBgAuszahlungPerson["Betrag"] = beleg.Betrag;
                }
                 * */
            }

            qryBgAuszahlungPerson.RefreshDisplay();
            SetEditMode();
        }

        #endregion

        #region Private Methods

        private bool AuswahlKreditor(string searchString, bool buttonClicked)
        {
            bool cancel = false;
            searchString = searchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgAuszahlungPerson[FLD_KREDITOR] = DBNull.Value;
                    qryBgAuszahlungPerson["ZusatzInfo"] = DBNull.Value;
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BaZahlungswegID] = DBNull.Value;
                    qryBgAuszahlungPerson["EinzahlungsscheinCode"] = DBNull.Value;
                    SetEditMode();
                    return false;
                }
            }

            if (searchString == ".")
            {
                // Auszahlung an
                // Klientensystem       	 - FaFallPerson
                // Involvierte Institutionen - FaFallPerson / BaPerson_BaInstitution
                KissLookupDialog dlg = new KissLookupDialog();
                cancel = !dlg.SearchData(@"
                        -- Klientensystem
                        SELECT  ID$          = KRE.BaZahlungswegID,
                                Typ          = 'Klientensystem',
                                Name         = KRE.PersonNameVorname,
                                Zahlungsweg  = KRE.Zahlungsweg,
                                ESCode$      = KRE.EinzahlungsscheinCode,
                                Kreditor$    = KRE.Kreditor,
                                ZusatzInfo$  = KRE.ZusatzInfo,
                                SortKey$     = 1
                        FROM dbo.FaFallPerson FAP
                        INNER JOIN dbo.vwKreditor KRE ON KRE.BaPersonID = FAP.BaPersonID
                        WHERE FAP.FaFallID = {0}

                        UNION

                        -- Involvierte Institutionen
                        SELECT	ID$               = KRE.BaZahlungswegID,
                                Typ               = 'Institutionen',
                                Name              = KRE.InstitutionName,
                                Zahlungsweg       = KRE.Zahlungsweg,
                                ESCode$           = KRE.EinzahlungsscheinCode,
                                Kreditor$         = KRE.Kreditor,
                                ZusatzInfo$       = KRE.ZusatzInfo,
                                SortKey$          = 2
                        FROM dbo.FaFallPerson                 FFP
                        INNER JOIN dbo.BaPerson_BaInstitution PIN ON PIN.BaPersonID = FFP.BaPersonID
                        INNER JOIN dbo.vwKreditor           KRE ON KRE.BaInstitutionID = PIN.BaInstitutionID
                        WHERE FaFallID = {0}

                        ORDER BY SortKey$, Name, Zahlungsweg",
                    qryBgAuszahlungPerson["FaFallID"].ToString(),
                    buttonClicked, null, null, null);

                if (!cancel)
                {
                    qryBgAuszahlungPerson[FLD_KREDITOR] = dlg["Kreditor$"];
                    qryBgAuszahlungPerson["ZusatzInfo"] = dlg["ZusatzInfo$"];
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BaZahlungswegID] = dlg["ID$"];
                    qryBgAuszahlungPerson["EinzahlungsscheinCode"] = dlg["ESCode$"];

                    if ((int)qryBgAuszahlungPerson["EinzahlungsscheinCode"] != 1)
                    {
                        // != oranger ES
                        qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.ReferenzNummer] = DBNull.Value;
                    }

                    SetEditMode();
                    return false;
                }
            }
            else // Auszahlung Dritte
            {
                DlgAuswahlBaZahlungsweg dlg2 = new DlgAuswahlBaZahlungsweg();
                ApplicationFacade.DoEvents();

                bool transfer = false;
                dlg2.SucheBaZahlungsweg(searchString);
                switch (dlg2.Count)
                {
                    case 0:
                        ShowInfo_KeineKreditorenEintraege();
                        break;

                    case 1:
                        transfer = true;
                        break;

                    default:
                        transfer = dlg2.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (transfer)
                {
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BaZahlungswegID] = dlg2["BaZahlungswegID"];
                    qryBgAuszahlungPerson[FLD_KREDITOR] = dlg2["Kreditor"];
                    qryBgAuszahlungPerson["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryBgAuszahlungPerson["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];

                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile1] = TruncateString(qryBgAuszahlungPerson["PersonVornameName"], 35);
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile2] = DBNull.Value;
                    qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.MitteilungZeile3] = DBNull.Value;

                    if ((int)qryBgAuszahlungPerson["EinzahlungsscheinCode"] != 1)
                    {
                        // != oranger ES
                        qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.ReferenzNummer] = DBNull.Value;
                    }
                }

                qryBgAuszahlungPerson.RefreshDisplay();
                SetEditMode();
            }
            return cancel;
        }

        private void CheckNotNullFieldOnTabPage(IKissBindableEdit ctl, String text, SharpLibrary.WinControls.TabPageEx page)
        {
            try
            {
                ((KissTabControlEx)page.Parent).SelectTab(page);
            }
            finally
            {
                DBUtil.CheckNotNullField(ctl, text);
            }
        }

        private void DisplayCalendarBoldDates()
        {
            /*
            _calendarFilling = true;

            edtCalendar.TodayDate = DateTime.Today;

             * */

            _calendarFilling = true;
            try
            {
                int budgetJahr = (int)qryBgAuszahlungPerson["BudgetJahr"];
                int budgetMonat = (int)qryBgAuszahlungPerson["BudgetMonat"];
                DateTime firstDate = new DateTime(budgetJahr, budgetMonat, 1);
                edtCalendar.MaxSelectionCount = 2;
                edtCalendar.SelectionRange = new SelectionRange(firstDate, firstDate.AddDays(1));

                edtCalendar.BoldedDates = null;
                int aId = Utils.ConvertToInt(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonID]);

                foreach (Termin pd in _terminList)
                {
                    if (pd.AuszPersonId == aId)
                    {
                        edtCalendar.AddBoldedDate(pd.Datum);
                    }
                }
            }
            finally
            {
                _calendarFilling = false;
            }
        }

        private void DisplayValutaTermine()
        {
            string valutaTermine = "";
            int aId = Utils.ConvertToInt(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonID]);

            foreach (Termin pd in _terminList)
            {
                if (pd.AuszPersonId == aId)
                {
                    if (valutaTermine != "") valutaTermine += @"  ";
                    valutaTermine += pd.Datum.ToString("d.M");
                }
            }
            qryBgAuszahlungPerson["ValutaTermine"] = valutaTermine;
            qryBgAuszahlungPerson.RefreshDisplay();
        }

        private void LoadValutaTermine()
        {
            int aId = Utils.ConvertToInt(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonID]);
            if (DBUtil.IsEmpty(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode]))
            {
                TerminList_Delete(aId);
                return;
            }

            int budgetJahr = (int)qryBgAuszahlungPerson["BudgetJahr"];
            int budgetMonat = (int)qryBgAuszahlungPerson["BudgetMonat"];
            int bgAuszahlungsTerminCode = (int)qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode];

            SqlQuery qryTermine;
            switch (bgAuszahlungsTerminCode)
            {
                case 1:  // 1x pro Monat
                case 2:  // 2x pro Monat
                case 3:  // wöchentlich
                case 5:  // 14-täglich
                    TerminList_Delete(aId);
                    qryTermine = DBUtil.OpenSQL(@"
                        select T.Datum
                        from dbo.fnKbAuszahlTermine({0}, {1}) T
                        where T.BgAuszahlungsTerminCode = {2}
             		    order by T.Datum",
                        budgetJahr,
                        budgetMonat,
                        bgAuszahlungsTerminCode
                    );
                    foreach (DataRow trm in qryTermine.DataTable.Rows)
                    {
                        _terminList.Add(new Termin(
                            0, // weil es neue Daten sind, gibt es keine Primärschlüssel -> 0
                            aId, // der Schlüssel zur Person
                            Utils.ConvertToDateTime(trm[DBO.BgAuszahlungPersonTermin.Datum])
                        ));
                    }
                    break;

                case 4:  // Valuta
                    break;

                case 6:  // Wochentage
                    TerminList_Delete(aId);
                    qryTermine = DBUtil.OpenSQL(@"
                        select T.Datum
                        from dbo.fnKbAuszahlTermine({0},{1}) T
                        where T.BgAuszahlungsTerminCode = {2}
                            and {3} like '%' + convert(varchar, T.BgWochentagCode) + '%'
             		    order by T.Datum",
                        budgetJahr,
                        budgetMonat,
                        bgAuszahlungsTerminCode,
                        qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgWochentagCodes]
                    );
                    foreach (DataRow trm in qryTermine.DataTable.Rows)
                    {
                        _terminList.Add(new Termin(
                            0, // weil es neue Daten sind, gibt es keine Primärschlüssel -> 0
                            aId, // der Schlüssel zur Person
                            Utils.ConvertToDateTime(trm[DBO.BgAuszahlungPersonTermin.Datum])
                        ));
                    }
                    break;

                case 99: // Individuell
                    break;
            }
        }

        private void SaveCalendarBoldDatesToList()
        {
            int aId = Utils.ConvertToInt(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungPersonID]);
            TerminList_Delete(aId);

            DateTime[] dates = (DateTime[])edtCalendar.BoldedDates.Clone();
            Array.Sort(dates);

            foreach (var aDat in dates)
            {
                _terminList.Add(new Termin(
                    0, // weil es neue Daten sind, gibt es keine Primärschlüssel -> 0
                    aId, // der Schlüssel zur Person
                    aDat
                ));
            }
        }

        private void SetEditMode()
        {
            if (qryBgAuszahlungPerson.Count == 0) return;

            try
            {
                int kategorie = ShUtil.GetCode(qryBgAuszahlungPerson["BgKategorieCode"]);

                qryBgAuszahlungPerson.EnableBoundFields(!_readOnly);

                int es = ShUtil.GetCode(qryBgAuszahlungPerson["EinzahlungsscheinCode"]);
                int auszahlungsTermin = ShUtil.GetCode(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.BgAuszahlungsTerminCode]);
                int auszahlungsArt = ShUtil.GetCode(qryBgAuszahlungPerson[DBO.BgAuszahlungPerson.KbAuszahlungsArtCode]);

                // Kategorienabhängige Einstellungen
                switch (kategorie)
                {
                    case 2: // Ausgaben
                    case 100: // Zusatzleistung
                    case 101: // Einzelzahlung
                        edtValutaDatum.EditMode = (auszahlungsTermin == 4) && !_readOnly ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtValutaDatum.Visible = (auszahlungsTermin == 4);
                        edtValutaTermine.Visible = (auszahlungsTermin != 4);
                        lblValutaDatum.Text = "Valuta";
                        edtReferenzNummer.EditMode = (es == 1) && (!_readOnly) ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtReferenzNummer.Visible = true;
                        lblReferenzNummer.Visible = true;
                        tpgZahlinfo.Title = lblKreditor.Text;

                        if (auszahlungsArt == 101)  // elektronisch
                        {
                            // Kreditor, ReferenzNr, Mitteilung mutierbar, wenn  PositionStatus = 5 (Zahlauftrag fehlerhaft)
                            edtKreditor.EditMode = EditModeType.Normal;
                            tpgMitteilung.HideTab = (es != 2) && (es != 3) && (es != 5); //roter ES
                            lblMitteilung.Visible = true;
                            lblZahlbarAn.Visible = false;
                            tpgMitteilung.Title = lblMitteilung.Text;
                            edtMitteilungZeile1.EditMode = !_readOnly ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile2.EditMode = !_readOnly ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile3.EditMode = !_readOnly ? EditModeType.Normal : EditModeType.ReadOnly;
                        }
                        else if (auszahlungsArt == 103) // bar
                        {
                            edtKreditor.EditMode = EditModeType.ReadOnly;
                            tpgMitteilung.HideTab = false;
                            lblMitteilung.Visible = false;
                            lblZahlbarAn.Visible = true;
                            tpgMitteilung.Title = lblZahlbarAn.Text;
                        }

                        tpgKalender.HideTab = (auszahlungsTermin == 4);

                        if (!tpgKalender.HideTab)
                        {
                            int budgetJahr = (int)qryBgAuszahlungPerson["BudgetJahr"];
                            int budgetMonat = (int)qryBgAuszahlungPerson["BudgetMonat"];
                            DateTime firstDate = new DateTime(budgetJahr, budgetMonat, 1);
                            switch (auszahlungsTermin)
                            {
                                case 6:  // Wochentage
                                    edtWochentagCodes.Visible = true;
                                    edtCalendar.Visible = true;
                                    edtCalendar.Enabled = false;
                                    edtCalendar.MinDate = firstDate;
                                    edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                    edtCalendar.CalendarDimensions = new Size(1, 1);
                                    edtCalendar.Left = tpgKalender.Width - edtCalendar.Width - 5;
                                    break;

                                case 5:  // 14-täglich
                                case 99: // individuell
                                    edtWochentagCodes.Visible = false;
                                    edtCalendar.Visible = true;
                                    edtCalendar.Enabled = !_readOnly && (auszahlungsTermin == 99);
                                    edtCalendar.MinDate = firstDate;
                                    edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                    edtCalendar.CalendarDimensions = new Size(1, 1);
                                    edtCalendar.Left = (tpgKalender.Width - edtCalendar.Width) / 2;
                                    break;

                                default: edtWochentagCodes.Visible = false;
                                    edtCalendar.Visible = true;
                                    edtCalendar.Enabled = false;
                                    edtCalendar.MinDate = firstDate.AddMonths(-1);
                                    edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                    edtCalendar.CalendarDimensions = new Size(2, 1);
                                    edtCalendar.Left = (tpgKalender.Width - edtCalendar.Width) / 2;
                                    break;
                            }
                        }

                        break;

                    case 1:	// Einnahme
                        break;

                    case 4: // Sanktion/Kürzung
                        break;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "FehlerSetEditMode", "Fehler in SetEditMode: " + ex.Message, null, ex, 0, 0, null);
            }
        }

        private object TruncateString(object s, int maxLength)
        {
            if (DBUtil.IsEmpty(s)) return s;
            if (!(s is String)) return s;
            if (s.ToString().Length > maxLength) return s.ToString().Substring(0, maxLength);
            return s;
        }

        #endregion

        #endregion

        #region Nested Types

        /// <summary>
        /// Struktur um die Daten der Tabelle BgAuszahlungPersonTermin in variablen zu speichern
        /// </summary>
        private struct Termin
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public readonly int AuszPersonId;

            #endregion

            #region Public Fields

            public int AuszPersonTerminId; // Primärschlüssel
            public DateTime Datum;

            #endregion

            #endregion

            #region Constructors

            public Termin(int apTerminId, int aPersonId, DateTime aDatum)
            {
                AuszPersonTerminId = apTerminId;
                AuszPersonId = aPersonId;
                Datum = aDatum;
            }

            #endregion
        }

        #endregion
    }
}