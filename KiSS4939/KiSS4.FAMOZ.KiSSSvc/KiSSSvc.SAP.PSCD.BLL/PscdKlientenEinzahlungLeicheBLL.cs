using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PscdKlientenEinzahlungLeicheBLL
	{
		public static KiSSDB.PscdKlientenEinzahlungLeicheDataTable GetLeichenAndDelete()
		{
			PscdKlientenEinzahlungLeicheTableAdapter adapter = new PscdKlientenEinzahlungLeicheTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdKlientenEinzahlungLeicheDataTable table = adapter.GetLeichen();
			adapter.ClearTable();
			return table;
		}

		public static bool Insert(string ABSND, decimal? KWBTR, decimal? SPESK, string AZIDT, string BUDAT, string BVDAT, string EPERL,
			string ESNUM, string KWAER, string MANDT, string STATUS, string VALUT, string VGEXT, string VORGC,
			string VWEZW1, string VWEZW2, string VWEZW3, string VWEZW4, string VWEZW5, string VWEZW6, string VWEZW7, string VWEZW8)
		{
			PscdKlientenEinzahlungLeicheTableAdapter adapter = new PscdKlientenEinzahlungLeicheTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.Insert(MANDT, ABSND, AZIDT, ESNUM, EPERL, BVDAT, BUDAT, VALUT, KWAER, KWBTR, SPESK, VORGC, VGEXT, VWEZW1, VWEZW2, VWEZW3, VWEZW4, VWEZW5, VWEZW6, VWEZW7, VWEZW8, STATUS) == 1;
		}

	}
}
