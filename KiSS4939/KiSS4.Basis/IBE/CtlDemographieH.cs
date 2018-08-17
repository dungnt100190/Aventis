using System;
using System.Drawing;

using KiSS4.DB;

namespace KiSS4.Basis.IBE
{
    /// <summary>
    /// Summary description for DataExplorerForm.
    /// </summary>
    partial class CtlDemographieH : Gui.KissUserControl
    {
        private int _verID;

        public CtlDemographieH()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void cboNationalitaet_EditValueChanged(object sender, EventArgs e)
        {
            if (edtNation.EditValue != DBNull.Value && edtNation.EditValue != null)
            {
                if (Convert.ToInt32(edtNation.EditValue) == Session.BaLandCodeSchweiz)
                {
                    ((IKissBindableEdit)edtAuslStatus).AllowEdit(false);
                    ((IKissBindableEdit)edtStatusBis).AllowEdit(false);
                }
                else
                {
                    ((IKissBindableEdit)edtAuslStatus).AllowEdit(true);
                    ((IKissBindableEdit)edtStatusBis).AllowEdit(true);
                }
            }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ADRESSATID":
                case "BAPERSONID":
                    return qryBaPerson["BaPersonID"];
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int ftPersonID, bool isFallTraeger)
        {
            picTitel.Image = titleImage;

            tabPerson.SelectedTabIndex = 0;
        }

        public void SetVersion(int baPersonID, int verID)
        {
            _verID = verID;

            //Personalien
            qryBaPerson.Fill(@"
                SELECT TOP 1
                       PRS.*
                FROM dbo.Hist_BaPerson PRS WITH (READUNCOMMITTED)
                WHERE PRS.BaPersonID = {0}
                  AND PRS.VerID <= {1}
                ORDER BY PRS.VerID DESC;", baPersonID, verID);

            DisplayWohnsituation();
        }

        protected internal void DisplayWohnsituation()
        {
            // Wohnsitz
            qryWohnsitzAdr.Fill(@"
                SELECT TOP 1
                       *
                FROM dbo.Hist_BaAdresse WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND VerID <= {1}
                  AND AdresseCode = 1
                ORDER BY VerID DESC", qryBaPerson["BaPersonID"], _verID);

            // Aufenthaltsort
            qryAufenthaltAdr.Fill(@"
                SELECT TOP 1
                       ADR.*,
                       PlatzierungInst = INS.Name
                FROM dbo.Hist_BaAdresse       ADR WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaInstitution INS ON INS.BaInstitutionID = ADR.PlatzierungInstID
                WHERE ADR.BaPersonID = {0}
                  AND ADR.VerID <= {1}
                  AND ADR.AdresseCode = 3
                ORDER BY VerID DESC", qryBaPerson["BaPersonID"], _verID);
        }
    }
}