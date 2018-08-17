using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class BaAdresseBLL
	{
		public static KiSSDB.BaAdresseRow GetCurrentWMAOfPerson(int baPersonID)
		{
			BaAdresseTableAdapter addressAdapter = new BaAdresseTableAdapter();
            addressAdapter.InitializeKiSSAdapter(null);
			KiSSDB.BaAdresseDataTable addresses = addressAdapter.GetCurrentWMAOfPerson(baPersonID);
			if (addresses.Rows.Count == 0)
				throw new Exception(string.Format("Die Person mit ID {0} hat keine Wohn-/Meldeadresse.", baPersonID));
			else if (addresses.Rows.Count > 1)
				throw new Exception(string.Format("Die Person mit ID {0} hat gleichzeitig {1} Wohn-/Meldeadressen statt nur eine.", baPersonID, addresses.Rows.Count));

			return addresses[0];
		}

		public static KiSSDB.BaAdresseRow GetAdressOfInstitution(int baInstitutionID)
		{
			BaAdresseTableAdapter addressAdapter = new BaAdresseTableAdapter();
            addressAdapter.InitializeKiSSAdapter(null);
			KiSSDB.BaAdresseDataTable addresses = addressAdapter.GetAdressOfInstitution(baInstitutionID);
			if (addresses.Rows.Count == 0)
				throw new Exception(string.Format("Die Institution mit ID {0} hat keine Adresse.", baInstitutionID));
			else if (addresses.Rows.Count > 1)
				throw new Exception(string.Format("Die Institution mit ID {0} hat gleichzeitig {1} Adressen statt nur eine.", baInstitutionID, addresses.Rows.Count));

			return addresses[0];
		}
	}
}
