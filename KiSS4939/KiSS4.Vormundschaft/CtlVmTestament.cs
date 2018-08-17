using System.Data;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmTestament.
    /// </summary>
    public partial class CtlVmTestament : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _vmTestamentID;

        #endregion

        #endregion

        #region Constructors

        public CtlVmTestament()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void editNotar_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.InstitutionSuchen(edtNotar.Text, 19, true, e.ButtonClicked); //nur Notare

            if (!e.Cancel)
            {
                qryVmTestament[DBO.VmTestament.NotarID] = dlg["BaInstitutionID"];
                qryVmTestament["Notar"] = dlg["Name"];
            }
        }

        private void editSAR_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtUser.Text, ModulID.V, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryVmTestament[DBO.VmTestament.UserID] = dlg["UserID"];
                qryVmTestament["User"] = dlg["Name"];
            }
        }

        private void qryVmTestament_BeforePost(object sender, System.EventArgs e)
        {
            /* Mantis 448: keine automatische Vergabe der Fallnummer
            if (DBUtil.IsEmpty(qryVmTestament["LaufNr"]))
            {
                qryVmTestament["LaufNr"] = DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MAX(LaufNr) + 1,1)
                    FROM dbo.VmTestament WITH(READUNCOMMITTED)
                    WHERE Jahr = {0}", qryVmTestament[DBO.VmTestament.Jahr]);
            }
            */

            if (qryVmTestament.Row.RowState == DataRowState.Added ||
                !qryVmTestament.Row[DBO.VmTestament.LaufNr, DataRowVersion.Original].Equals(qryVmTestament[DBO.VmTestament.LaufNr]) ||
                !qryVmTestament.Row[DBO.VmTestament.Jahr, DataRowVersion.Original].Equals(qryVmTestament[DBO.VmTestament.Jahr]))
            {
                //check Eindeutigkeit: LaufNr
                var count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.VmTestament
                    WHERE LaufNr = {0}
                      AND Jahr = {1}",
                    qryVmTestament["LaufNr"],
                    qryVmTestament["Jahr"]);

                if (count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlVmTestament", "LaufNrBereisVerwendet", "Die LaufNr {0} wird bereits verwendet!", KissMsgCode.MsgInfo, qryVmTestament["LaufNr"].ToString()));
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL("SELECT BaPersonID FROM dbo.FaLeistung WHERE FaLeistungID = {0};", qryVmTestament["FaLeistungID"]);

                case "FALEISTUNGID":
                    return qryVmTestament[DBO.VmTestament.FaLeistungID];

                case "VMTESTAMENTID":
                    return _vmTestamentID;

                case "OWNERUSERID":
                    return qryVmTestament[DBO.VmTestament.UserID];
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int vmTestamentID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            _vmTestamentID = vmTestamentID;

            qryVmTestament.Fill(@"
                SELECT [VmTestamentID]                = VTM.VmTestamentID,
                       [FaLeistungID]                 = VTM.FaLeistungID,
                       [LaufNr]                       = VTM.LaufNr,
                       [UserID]                       = VTM.UserID,
                       [KopieAnCodes]                 = VTM.KopieAnCodes,
                       [ZeugnisseCodes]               = VTM.ZeugnisseCodes,
                       [EroeffnungsRechnungBetrag]    = VTM.EroeffnungsRechnungBetrag,
                       [EroeffnungsRechnungSAPNr]     = VTM.EroeffnungsRechnungSAPNr,
                       [ZusatzRechnungBetrag]         = VTM.ZusatzRechnungBetrag,
                       [ZusatzRechnungSAPNr]          = VTM.ZusatzRechnungSAPNr,
                       [EroeffnungDokID]              = VTM.EroeffnungDokID,
                       [EroeffnungAuszugDokID]        = VTM.EroeffnungAuszugDokID,
                       [EroeffnungAdressenDokID]      = VTM.EroeffnungAdressenDokID,
                       [EroeffnungAbgeschlossenDatum] = VTM.EroeffnungAbgeschlossenDatum,
                       [PublikationFrist]             = VTM.PublikationFrist,
                       [PublikationDatum]             = VTM.PublikationDatum,
                       [Bemerkung]                    = VTM.Bemerkung,
                       [NotarID]                      = VTM.NotarID,
                       [Jahr]                         = VTM.Jahr,
                       [User]                         = USR.LastName + ISNULL(', ' + USR.FirstName,''),
                       [Notar]                        = INS.Name
                FROM dbo.VmTestament          VTM WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.XUser         USR WITH(READUNCOMMITTED) ON USR.UserID = VTM.UserID
                  LEFT JOIN dbo.BaInstitution INS WITH(READUNCOMMITTED) ON INS.BaInstitutionID = VTM.NotarID
                WHERE VTM.VmTestamentID = {0};",
                vmTestamentID);

            if (qryVmTestament.Count > 0)
            {
                ctlVmErblasserInfo1.FaLeistungID = (int)qryVmTestament[DBO.VmTestament.FaLeistungID];
            }
        }

        #endregion

        #endregion
    }
}