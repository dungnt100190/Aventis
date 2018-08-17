using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PscdSentBLL
	{
		#region Person

		public static void SavePscdSentPerson(int baPersonID, byte[] ts)
		{
			PscdSentBaPersonTableAdapter adapter = new PscdSentBaPersonTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaPersonDataTable tbl = adapter.GetPersonByID(baPersonID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentBaPersonRow row = tbl.NewPscdSentBaPersonRow();
				row.BaPersonID = baPersonID;
				row.BaPersonTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentBaPersonRow(row);
			}
			else
			{
				KiSSDB.PscdSentBaPersonRow row = tbl[0];
				row.BaPersonID = baPersonID;
				row.BaPersonTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
			}
			adapter.Update(tbl);
		}
		public enum SendState
		{
			NotYetSent,
			Changed,
			Unchanged
		}

		public static SendState HasPersonBeenChanged(int baPersonID, long ts)
		{
			PscdSentBaPersonTableAdapter adapter = new PscdSentBaPersonTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaPersonDataTable tbl = adapter.GetPersonByID(baPersonID);
			if (tbl.Count == 1)
			{
				KiSSDB.PscdSentBaPersonRow row = tbl[0];
				if (row.BaPersonTS_SentCast == ts)
					return SendState.Unchanged;
				return SendState.Changed;
			}
			return SendState.NotYetSent;
		}

		#endregion

		#region BaAdresse

		public static void SavePscdSentAdresse(int baAdresseID, byte[] ts)
		{
			PscdSentBaAdresseTableAdapter adapter = new PscdSentBaAdresseTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaAdresseDataTable tbl = adapter.GetAdresseByID(baAdresseID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentBaAdresseRow row = tbl.NewPscdSentBaAdresseRow();
				row.BaAdresseID = baAdresseID;
				row.BaAdresseTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentBaAdresseRow(row);
			}
			else
			{
				KiSSDB.PscdSentBaAdresseRow row = tbl[0];
				row.BaAdresseID = baAdresseID;
				row.BaAdresseTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
			}
			adapter.Update(tbl);
		}

		public static PscdSentBLL.SendState HasAdresseBeenChanged(int baPersonID, long ts)
		{
			PscdSentBaAdresseTableAdapter adapter = new PscdSentBaAdresseTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaAdresseDataTable tbl = adapter.GetAdresseByID(baPersonID);
			if (tbl.Count == 1)
			{
				KiSSDB.PscdSentBaAdresseRow row = tbl[0];
				if (row.BaAdresseTS_SentCast == ts)
					return SendState.Unchanged;
				return SendState.Changed;
			}
			return SendState.NotYetSent;
		}

		#endregion

		#region Institution

		public static void SavePscdSentInstitution(int baInstitutionID, byte[] ts)
		{
			PscdSentBaInstitutionTableAdapter adapter = new PscdSentBaInstitutionTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaInstitutionDataTable tbl = adapter.GetInstitutionByID(baInstitutionID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentBaInstitutionRow row = tbl.NewPscdSentBaInstitutionRow();
				row.BaInstitutionID = baInstitutionID;
				row.BaInstitutionTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentBaInstitutionRow(row);
			}
			else
			{
				KiSSDB.PscdSentBaInstitutionRow row = tbl[0];
				row.BaInstitutionID = baInstitutionID;
				row.BaInstitutionTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
			}
			adapter.Update(tbl);
		}

		public static PscdSentBLL.SendState HasInstitutionBeenChanged(int baInstitutionID, long ts)
		{
			PscdSentBaInstitutionTableAdapter adapter = new PscdSentBaInstitutionTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaInstitutionDataTable tbl = adapter.GetInstitutionByID(baInstitutionID);
			if (tbl.Count == 1)
			{
				KiSSDB.PscdSentBaInstitutionRow row = tbl[0];
				if (row.BaInstitutionTS_SentCast == ts)
					return SendState.Unchanged;
				return SendState.Changed;
			}
			return SendState.NotYetSent;
		}

		#endregion

		#region BaZahlungsweg

		public static void SavePscdSentZahlungsweg(int baZahlungswegID, byte[] ts, int? sapID)
		{
			PscdSentBaZahlungswegTableAdapter adapter = new PscdSentBaZahlungswegTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaZahlungswegDataTable tbl = adapter.GetZahlungswegByID(baZahlungswegID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentBaZahlungswegRow row = tbl.NewPscdSentBaZahlungswegRow();
				row.BaZahlungswegID = baZahlungswegID;
				row.BaZahlungswegTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				if (sapID.HasValue)
					row.SapID = sapID.Value;
				tbl.AddPscdSentBaZahlungswegRow(row);
			}
			else
			{
				KiSSDB.PscdSentBaZahlungswegRow row = tbl[0];
				row.BaZahlungswegID = baZahlungswegID;
				row.BaZahlungswegTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				if (sapID.HasValue)
					row.SapID = sapID.Value;
			}
			adapter.Update(tbl);
		}

		public static void SavePscdSentZahlungswegAddress(int baZahlungswegID, byte[] ts, int? sapIDAddress)
		{
			PscdSentBaZahlungswegTableAdapter adapter = new PscdSentBaZahlungswegTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaZahlungswegDataTable tbl = adapter.GetZahlungswegByID(baZahlungswegID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentBaZahlungswegRow row = tbl.NewPscdSentBaZahlungswegRow();
				row.BaZahlungswegID = baZahlungswegID;
				row.BaZahlungswegTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				if (sapIDAddress.HasValue)
					row.SapIDAddress = sapIDAddress.Value;
				tbl.AddPscdSentBaZahlungswegRow(row);
			}
			else
			{
				KiSSDB.PscdSentBaZahlungswegRow row = tbl[0];
				row.BaZahlungswegID = baZahlungswegID;
				row.BaZahlungswegTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				if (sapIDAddress.HasValue)
					row.SapIDAddress = sapIDAddress.Value;
			}
			adapter.Update(tbl);
		}

		public static bool HasZahlungswegBeenChanged(int baZahlungswegID, long ts)
		{
			PscdSentBaZahlungswegTableAdapter adapter = new PscdSentBaZahlungswegTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaZahlungswegDataTable tbl = adapter.GetZahlungswegByID(baZahlungswegID);
			if (tbl.Count == 1)
			{
				KiSSDB.PscdSentBaZahlungswegRow row = tbl[0];
				return row.BaZahlungswegTS_SentCast != ts;
			}
			return true;
		}

		public static int? GetSapID(int baZahlungswegID)
		{
			PscdSentBaZahlungswegTableAdapter adapter = new PscdSentBaZahlungswegTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaZahlungswegDataTable tbl = adapter.GetZahlungswegByID(baZahlungswegID);
			if (tbl.Count == 1 && !tbl[0].IsSapIDNull())
			{
				return tbl[0].SapID;
			}
			return null;
		}

		public static int? GetSapIDAddress(int baZahlungswegID)
		{
			PscdSentBaZahlungswegTableAdapter adapter = new PscdSentBaZahlungswegTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBaZahlungswegDataTable tbl = adapter.GetZahlungswegByID(baZahlungswegID);
			if (tbl.Count == 1 && !tbl[0].IsSapIDAddressNull())
			{
				return tbl[0].SapIDAddress;
			}
			return null;
		}

		#endregion

		#region FaLeistung

		public static void SavePscdSentLeistung(int faLeistungID, byte[] ts)
		{
			PscdSentFaLeistungTableAdapter adapter = new PscdSentFaLeistungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentFaLeistungDataTable tbl = adapter.GetLeistungByID(faLeistungID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentFaLeistungRow row = tbl.NewPscdSentFaLeistungRow();
				row.FaLeistungID = faLeistungID;
				row.FaLeistungTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentFaLeistungRow(row);
			}
			else
			{
				KiSSDB.PscdSentFaLeistungRow row = tbl[0];
				row.FaLeistungID = faLeistungID;
				row.FaLeistungTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
			}
			adapter.Update(tbl);
		}

		public static bool HasLeistungBeenChanged(int faLeistungID, long ts)
		{
			PscdSentFaLeistungTableAdapter adapter = new PscdSentFaLeistungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentFaLeistungDataTable tbl = adapter.GetLeistungByID(faLeistungID);
			if (tbl.Count == 1)
			{
				KiSSDB.PscdSentFaLeistungRow row = tbl[0];
				return row.FaLeistungTS_SentCast != ts;
			}
			return true;
		}

		#endregion

		#region BgFinanzPlan

		public static void SavePscdSentFinanzPlan(int bgFinanzPlanID, byte[] ts)
		{
			PscdSentBgFinanzPlanTableAdapter adapter = new PscdSentBgFinanzPlanTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBgFinanzPlanDataTable tbl = adapter.GetFinanzPlanByID(bgFinanzPlanID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentBgFinanzPlanRow row = tbl.NewPscdSentBgFinanzPlanRow();
				row.BgFinanzPlanID = bgFinanzPlanID;
				row.BgFinanzPlanTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentBgFinanzPlanRow(row);
			}
			else
			{
				KiSSDB.PscdSentBgFinanzPlanRow row = tbl[0];
				row.BgFinanzPlanID = bgFinanzPlanID;
				row.BgFinanzPlanTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
			}
			adapter.Update(tbl);
		}

		public static bool HasFinanzPlanBeenChanged(int bgFinanzPlanID, long ts)
		{
			PscdSentBgFinanzPlanTableAdapter adapter = new PscdSentBgFinanzPlanTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBgFinanzPlanDataTable tbl = adapter.GetFinanzPlanByID(bgFinanzPlanID);
			if (tbl.Count == 1)
			{
				KiSSDB.PscdSentBgFinanzPlanRow row = tbl[0];
				return row.BgFinanzPlanTS_SentCast != ts;
			}
			return true;
		}

		#endregion

		#region FaLeistung_Person

		public static bool HasLeistungPersonBeenSent(int faLeistungID, int baPersonID)
		{
			PscdSentFaLeistung_PersonTableAdapter adapter = new PscdSentFaLeistung_PersonTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentFaLeistung_PersonDataTable tbl = adapter.GetLeistungPersonByIDs(faLeistungID, baPersonID);
			return tbl.Count == 1;
		}

		public static void SavePscdSentLeistungPerson(int faLeistungID, int baPersonID)
		{
			PscdSentFaLeistung_PersonTableAdapter adapter = new PscdSentFaLeistung_PersonTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentFaLeistung_PersonDataTable tbl = adapter.GetLeistungPersonByIDs(faLeistungID, baPersonID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentFaLeistung_PersonRow row = tbl.NewPscdSentFaLeistung_PersonRow();
				row.FaLeistungID = faLeistungID;
				row.BaPersonID = baPersonID;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentFaLeistung_PersonRow(row);
				adapter.Update(tbl);
			}
		}

		#endregion

		#region BgFinanzPlan_Person
/*
		public static bool HasFinanzplanPersonBeenSent(int bgFinanzPlanID, int baPersonID)
		{
			PscdSentBgFinanzPlan_PersonTableAdapter adapter = new PscdSentBgFinanzPlan_PersonTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBgFinanzPlan_PersonDataTable tbl = adapter.GetFinanzPlanPersonByIDs(bgFinanzPlanID, baPersonID);
			return tbl.Count == 1;
		}

		public static void SavePscdSentFinanzPlanPerson(int bgFinanzPlanID, int baPersonID)
		{
			PscdSentBgFinanzPlan_PersonTableAdapter adapter = new PscdSentBgFinanzPlan_PersonTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentBgFinanzPlan_PersonDataTable tbl = adapter.GetFinanzPlanPersonByIDs(bgFinanzPlanID, baPersonID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentBgFinanzPlan_PersonRow row = tbl.NewPscdSentBgFinanzPlan_PersonRow();
				row.BgFinanzPlanID = bgFinanzPlanID;
				row.BaPersonID = baPersonID;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentBgFinanzPlan_PersonRow(row);
			}
			else
			{
				KiSSDB.PscdSentBgFinanzPlan_PersonRow row = tbl[0];
				row.BgFinanzPlanID = bgFinanzPlanID;
				row.BaPersonID = baPersonID;
				row.SentToPscd = DateTime.Now;
			}
			adapter.Update(tbl);
		}
		*/
		#endregion

		#region KbBuchungKostenart

		public static void SavePscdSentBuchungKostenart(int kbBuchungKostenartID, byte[] ts)
		{
			PscdSentKbBuchungKostenartTableAdapter adapter = new PscdSentKbBuchungKostenartTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdSentKbBuchungKostenartDataTable tbl = adapter.GetBuchungKostenartByID(kbBuchungKostenartID);
			if (tbl.Count == 0)
			{
				// No entry yet, create one
				KiSSDB.PscdSentKbBuchungKostenartRow row = tbl.NewPscdSentKbBuchungKostenartRow();
				row.KbBuchungKostenartID = kbBuchungKostenartID;
				row.KbBuchungKostenartTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
				tbl.AddPscdSentKbBuchungKostenartRow(row);
			}
			else
			{
				KiSSDB.PscdSentKbBuchungKostenartRow row = tbl[0];
				row.KbBuchungKostenartID = kbBuchungKostenartID;
				row.KbBuchungKostenartTS_Sent = ts;
				row.SentToPscd = DateTime.Now;
			}
			adapter.Update(tbl);
		}

		#endregion

	}
}
