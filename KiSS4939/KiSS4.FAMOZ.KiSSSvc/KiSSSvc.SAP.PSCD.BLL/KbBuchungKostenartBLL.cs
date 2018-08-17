using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbBuchungKostenartBLL
	{
        public static int UpdateVerwPeriode(DateTime VerwPeriodeVon, DateTime VerwPeriodeBis, int kbBuchungKostenartID)
		{
            KbBuchungKostenartTableAdapter adapter = new KbBuchungKostenartTableAdapter();
			adapter.InitializeKiSSAdapter(null);

            return adapter.UpdateVerwPeriode(VerwPeriodeVon, VerwPeriodeBis, kbBuchungKostenartID);
		}

        public static int GetSplittingArtCode(int kbBuchungKostenartID)
        {
            KbBuchungKostenartTableAdapter adapter = new KbBuchungKostenartTableAdapter();
            adapter.InitializeKiSSAdapter(null);
            try
            {
                return (int)adapter.GetSplittingArtCode(kbBuchungKostenartID);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Holen des SplittingCodes für kbBuchungKostenartID = " + kbBuchungKostenartID + ". Es wird 0 zurückgegeben.", ex);

                return 0;
            }
        }
	}
}
