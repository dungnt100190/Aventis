using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class BaZahlungswegBLL
	{
		public static KiSSDB.BaZahlungswegDataTable GetZahlungswegeOfPerson(int baPersonID)
		{
			BaZahlungswegTableAdapter zahlwegAdapter = new BaZahlungswegTableAdapter();
            zahlwegAdapter.InitializeKiSSAdapter(null);
			return zahlwegAdapter.GetZahlungsVerbindungByBaPersonID(baPersonID);
		}

		public static KiSSDB.BaZahlungswegDataTable GetZahlungsVerbindungByBaInstitutionID(int baInstitutionID)
		{
			BaZahlungswegTableAdapter zahlwegAdapter = new BaZahlungswegTableAdapter();
            zahlwegAdapter.InitializeKiSSAdapter(null);
			return zahlwegAdapter.GetZahlungsVerbindungByBaInstitutionID(baInstitutionID);
		}

		public static KiSSDB.BaZahlungswegRow GetZahlungswegByID(int baZahlungswegID)
		{
			BaZahlungswegTableAdapter zahlwegAdapter = new BaZahlungswegTableAdapter();
            zahlwegAdapter.InitializeKiSSAdapter(null);
			KiSSDB.BaZahlungswegDataTable zahlwegTable = zahlwegAdapter.GetZahlungswegByID(baZahlungswegID);
			if (zahlwegTable.Count == 0)
				return null;
			return zahlwegTable[0];
		}

		public static KiSSDB.BaZahlungswegRow GetZahlungswegOfKgPeriode(int kgPeriodeID)
		{
			BaZahlungswegTableAdapter zahlwegAdapter = new BaZahlungswegTableAdapter();
            zahlwegAdapter.InitializeKiSSAdapter(null);
			KiSSDB.BaZahlungswegDataTable zahlwegTable = zahlwegAdapter.GetZahlungswegOfKgPeriode(kgPeriodeID);
			if (zahlwegTable.Count == 0)
				return null;
			return zahlwegTable[0];
		}

		/// <summary>
		/// Gets the account number of a BaZahlungsVerbindung row. It can be either a bank or a post account number
		/// </summary>
		/// <param name="bankRow">row of table Ba$ZahlungsVerbindung</param>
		/// <returns>account number</returns>
		public static string GetAccountNumber(KiSSDB.BaZahlungswegRow bankRow)
		{
			return GetAccountNumber(bankRow, false);
		}

		public static string GetAccountNumber(KiSSDB.BaZahlungswegRow bankRow, bool suppressDummy)
		{
			string accountNr = null;
			if (!string.IsNullOrEmpty(bankRow.BankKontoNummer))
			{
				accountNr = bankRow.BankKontoNummer;
			}
			else if (!string.IsNullOrEmpty(bankRow.PCNr))
			{
				accountNr = bankRow.PCNr;
			}
			if (!suppressDummy && string.IsNullOrEmpty(accountNr))
			{
				accountNr = string.Format("DUMMY{0}", bankRow.BaZahlungswegID.ToString().PadLeft(8, '0'));
			}
			return accountNr;
		}



		public static string MakePcNr(string pcnummer)
		{
			if (string.IsNullOrEmpty(pcnummer) || pcnummer.IndexOf('-') > 0 || pcnummer.Length != 9)
				return pcnummer;

			return string.Format("{0}-{1}-{2}", pcnummer.Substring(0, 2), pcnummer.Substring(2, 6).TrimStart('0'), pcnummer[8]);

		}


		/// <summary>
		/// Converts a ZKB-AccountNr (1100-1234.123) to MuC (110001234123)
		/// </summary>
		/// <param name="zkbAccountNr"></param>
		/// <returns></returns>
		public static string GetMuCFromZKBAccountNr(string zkbAccountNr)
		{
			QueryAdapter adapter = new QueryAdapter();
			return adapter.GetMucFromZKBAccountNr(zkbAccountNr) as string;
		}


		public static bool HaveZahlungswegOfInstitutionChanged(int baInstitutionID)
		{
			BaZahlungswegTableAdapter zahlwegAdapter = new BaZahlungswegTableAdapter();
            zahlwegAdapter.InitializeKiSSAdapter(null);
			return HaveZahlungswegChanged(zahlwegAdapter.GetZahlungsVerbindungByBaInstitutionID(baInstitutionID));
		}

		public static bool HaveZahlungswegOfPersonChanged(int baPersonID)
		{
			BaZahlungswegTableAdapter zahlwegAdapter = new BaZahlungswegTableAdapter();
            zahlwegAdapter.InitializeKiSSAdapter(null);
			return HaveZahlungswegChanged(zahlwegAdapter.GetZahlungsVerbindungByBaPersonID(baPersonID));
		}

		public static bool HaveZahlungswegChanged(KiSSDB.BaZahlungswegDataTable zahlwegTable)
		{
			PscdSentBaZahlungswegTableAdapter sentAdapter = new PscdSentBaZahlungswegTableAdapter();
            sentAdapter.InitializeKiSSAdapter(null);

			foreach (KiSSDB.BaZahlungswegRow currentZahlungsweg in zahlwegTable)
			{
				// ESR und Postmandat werden nicht als Stammdaten angelegt
				if (currentZahlungsweg.IsEinzahlungsscheinCodeNull() || currentZahlungsweg.EinzahlungsscheinCode == 1 /*ESR*/|| currentZahlungsweg.EinzahlungsscheinCode == 6 /*Postmandat*/)
					continue;

				KiSSDB.PscdSentBaZahlungswegDataTable sentTbl = sentAdapter.GetZahlungswegByID(currentZahlungsweg.BaZahlungswegID);
				if (sentTbl.Count == 1 &&
					 sentTbl[0].BaZahlungswegTS_SentCast == currentZahlungsweg.BaZahlungswegTSCast)
				{
					continue;
				}
				return true;
			}
			// if we get here, we have not detected a change
			return false;
		}
	}
}
