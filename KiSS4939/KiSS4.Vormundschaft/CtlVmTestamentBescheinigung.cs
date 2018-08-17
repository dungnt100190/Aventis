using System;
using System.Drawing;

using KiSS.DBScheme;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmTestamentBescheinigung.
    /// </summary>
    public partial class CtlVmTestamentBescheinigung : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Fields

        private int _vmTestamentID;

        #endregion

        #endregion

        #region Constructors

        public CtlVmTestamentBescheinigung()
        {
            InitializeComponent();
            SetupLogischesLoeschen();
        }

        #endregion

        #region EventHandlers

        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            OnRestoreData();
        }

        private void qryVmTestamentBescheinigung_AfterInsert(object sender, EventArgs e)
        {
            qryVmTestamentBescheinigung.SetCreator();
            qryVmTestamentBescheinigung["VmTestamentID"] = _vmTestamentID;
            edtDatum.Focus();
        }

        private void qryVmTestamentBescheinigung_BeforePost(object sender, EventArgs e)
        {
            qryVmTestamentBescheinigung.SetModifierModified();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL(
                        "SELECT BaPersonID FROM dbo.FaLeistung WHERE FaLeistungID = {0};",
                        _faLeistungId);

                case "VMTESTAMENTID":
                    return _vmTestamentID;

                case "USERID":
                    return Session.User.UserID;

                case "OWNERUSERID":
                    return DBUtil.ExecuteScalarSQL(
                        "SELECT UserID FROM dbo.FaLeistung WHERE FaLeistungID = {0};",
                        _faLeistungId);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int baPersonID, int faLeistungID, int vmTestamentID)
        {
            base.Init(titleName, titleImage, baPersonID, faLeistungID);

            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            _vmTestamentID = vmTestamentID;

            _faLeistungId = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT FaLeistungID FROM VmTestament WHERE VmTestamentID = {0}", vmTestamentID));

            colBescheinigungCode.ColumnEdit = grdVmTestamentBescheinigung.GetLOVLookUpEdit("VmErbBescheinigung");

            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Setzt die Felder auf enabled oder disabled,
        /// jenachdem, ob der Datensatz logisch gelöscht worden ist.        
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtDatum.EditMode = editMode;
            edtBescheinigungCode.EditMode = editMode;
            edtBescheinigungDokID.EditMode = editMode;
            edtBescheinigungText.EditMode = editMode;
            edtGebuehr.EditMode = editMode;
            edtSAPNr.EditMode = editMode;
            edtBemerkung.EditMode = editMode;

        }

        /// <summary>
        /// Führt die Suche aus.  Hier werden dem Query die Parameter übergeben
        /// {0}, {1} ...      
        /// </summary>
        protected override void RunSearch()
        {
            bool isDeleted1;
            bool isDeleted2;

            int editVal = Convert.ToInt32(radGrpDeleted.EditValue);

            //Nur aktive Dokumente anzeigen
            if (editVal == 1)
            {
                isDeleted1 = false;
                isDeleted2 = false;
            }

                //Alle (gelöschte und aktuelle Dokumente) anzeigen
            else if (editVal == 0)
            {
                isDeleted1 = true;
                isDeleted2 = false;
            }

                //Nur gelöschte Dokumente anzeigen
            else
            {
                isDeleted1 = true;
                isDeleted2 = true;
            }

            kissSearch.SelectParameters = new object[] { _vmTestamentID, isDeleted1, isDeleted2 };

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtDatumVonSuche.Top;

            //DrawZell render Methode hinzufügen.
            GridView = grvVmTestamentBescheinigung;
        }

        #endregion

        #endregion
    }
}