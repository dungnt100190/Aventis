using System;
using System.Collections.Generic;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaVermittlungSIVermittlungsprofil : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = -1;
        private int _faLeistungID = -1;
        private bool _mayClose;
        private bool _mayDelete;
        private bool _mayInsert;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpdate;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungSIVermittlungsprofil()
        {
            InitializeComponent();

            LoadQueryBewertung(edtGesundheitKoerperlichBewertung);
            LoadQueryBewertung(edtGesundheitPsychischBewertung);
            LoadQueryBewertung(edtZuverlaessigkeitBewertung);
            LoadQueryBewertung(edtModivationBewertung);
        }

        #endregion

        #region EventHandlers

        private void CtlKaVermittlungSIVermittlungsprofil_Load(object sender, EventArgs e)
        {
            btnEinsatzplatzSuchen.Enabled = DBUtil.UserHasRight("CtlKaVermittlungSIVermittlungsprofil", "UI") && (_mayUpdate || _mayInsert);

            if (KaUtil.GetSichtbarSDFlag(_baPersonID) == 1)
            {
                qrySIVermittlung.EnableBoundFields(false);
                btnEinsatzplatzSuchen.Enabled = false;
                btnVermittlungsgespraech.Enabled = false;
            }
        }

        private void btnEinsatzplatzSuchen_Click(object sender, EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            if (qrySIVermittlung.Count > 0)
            {
                FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEPSuchen", "BrancheCodes", qrySIVermittlung["BrancheCodes"]);
            }
            else
            {
                FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEPSuchen");
            }
        }

        private void edtGepraechsfuehrer_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtGepraechsfuehrer.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qrySIVermittlung["SIGespraechfuehrerinID"] = DBNull.Value;
                    qrySIVermittlung["SIGespraechfuehrerin"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$ = UserID,
                       [Kürzel] = LogonName,
                       [Mitarbeiter/in] = NameVorname,
                       [Org.Einheit] = OrgUnit
                FROM dbo.vwUser
                WHERE NameVorname LIKE '%' + {0} + '%'
                  AND LogonName LIKE 'KA%'
                ORDER BY NameVorname",
                searchString,
                e.ButtonClicked,
                null,
                null,
                null);

            if (!e.Cancel)
            {
                qrySIVermittlung["SIGespraechfuehrerinID"] = dlg[0];
                qrySIVermittlung["SIGespraechfuehrerin"] = dlg[2];
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return _faLeistungID;

                case "BAPERSONID":
                    return (int)DBUtil.ExecuteScalarSQL("select BaPersonID from FaLeistung where FaLeistungID = {0}", _faLeistungID);

                case "KAVERMITTLUNGPROFILID":
                    return qrySIVermittlung["KaVermittlungProfilID"];

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
            }

            return base.GetContextValue(fieldName);
        }

        // ComponentName: qrySIVermittlung
        public void Init(string maskName, Image maskImage, int faLeistungID, int baPersonID)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            tabVermittlungsprofil.SelectedTabIndex = 0;
            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayInsert, out _mayUpdate, out _mayDelete, out _mayClose, out _mayReopen);

            if (!VermittlungExists() && DBUtil.UserHasRight("CtlKaVermittlungSIVermittlungsprofil", "UI") && (_mayUpdate || _mayInsert))
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.KaVermittlungProfil (FaLeistungID, SichtbarSDFlag, Creator, Created, Modifier, Modified)
                    VALUES ({0}, {1}, {2}, GETDATE(), {2}, GETDATE())",
                    _faLeistungID,
                    KaUtil.IsVisibleSD(_baPersonID),
                    DBUtil.GetDBRowCreatorModifier());
            }

            qrySIVermittlung.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Specific messages as key/value pair for current form</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public override object ReturnMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "GetPendenzStandardWerte":
                    {
                        System.Collections.Specialized.HybridDictionary dic = new System.Collections.Specialized.HybridDictionary();

                        var betreff = DBUtil.GetConfigString(@"System\Pendenzen\StandardWerte\CtlKaVermittlungSIVermittlungsprofil\Betreff", string.Empty);
                        var beschreibung = DBUtil.GetConfigString(@"System\Pendenzen\StandardWerte\CtlKaVermittlungSIVermittlungsprofil\Beschreibung", string.Empty);
                        var typ = DBUtil.GetConfigInt(@"System\Pendenzen\StandardWerte\CtlKaVermittlungSIVermittlungsprofil\Typ", 1);

                        dic["Betreff"] = betreff;
                        dic["Beschreibung"] = beschreibung;
                        dic["Falltraeger"] = _baPersonID;
                        dic["FaLeistungID"] = _faLeistungID;
                        dic["BetrifftPerson"] = DBNull.Value;
                        dic["Typ"] = typ;
                        return dic;
                    }
            }

            // did not understand message
            return base.ReturnMessage(param);
        }

        #endregion

        #region Private Static Methods

        private static void LoadQueryBewertung(KissLookUpEdit kissLookUpEdit)
        {
            var codeTexts = new Dictionary<int, string>
            {
                { 1, "1" },
                { 2, "2" },
                { 3, "3" },
                { 4, "4" },
                { 5, "5" },
                { 6, "6" },
                { 7, "7" },
                { 8, "8" },
                { 9, "9" },
                { 10, "10" },
            };

            kissLookUpEdit.ApplyCodeTextPairsAsPopupDataSource(codeTexts);
        }

        #endregion

        #region Private Methods

        private void CheckPensum(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(((KissCalcEdit)sender).EditValue))
            {
                if (Convert.ToInt32(((KissCalcEdit)sender).EditValue) > 100)
                {
                    KissMsg.ShowInfo("CtlKaVermittlungSIVermittlungsprofil", "PensumZuGross", "Pensum darf nicht höher sein als 100%!");
                    ((KissCalcEdit)sender).Focus();
                }
            }
        }

        private bool VermittlungExists()
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(
                @"select count(*) from KaVermittlungProfil where FaLeistungID = {0}",
                _faLeistungID)) > 0;
        }

        #endregion

        #endregion
    }
}