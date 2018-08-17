using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Administration
{
    public partial class CtlProfileTagsVerwalten : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Name der Spalte für Text in der GridView.
        /// </summary>
        private const string COL_TEXT = "Text";

        #endregion

        #endregion

        #region Constructors

        public CtlProfileTagsVerwalten()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();

            NewSearchAndRun();
        }

        #endregion

        #region EventHandlers

        private void qryXProfileTag_AfterInsert(object sender, System.EventArgs e)
        {
            qryXProfileTag.SetCreator();
            edtProfileTagText.Focus();
        }

        private void qryXProfileTag_AfterPost(object sender, System.EventArgs e)
        {
            // set value to display-only column
            qryXProfileTag[COL_TEXT] = edtProfileTagText.Text;
        }

        private void qryXProfileTag_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtProfileTagText, lblProfileTagText.Text);

            qryXProfileTag.SetModifierModified();
        }

        private void qryXProfileTag_PositionChanged(object sender, System.EventArgs e)
        {
            panelDetail.Enabled = !qryXProfileTag.IsEmpty;
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryXProfileTag.IsEmpty)
            {
                panelDetail.Enabled = true;
            }
            else
            {
                panelDetail.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Setzt den Fokus auf das Feld Profilname
        /// </summary>
        protected override void NewSearch()
        {
            base.NewSearch();
            edtProfileTagText.Focus();
        }

        /// <summary>
        /// Führt eine neue Suche aus.
        /// </summary>
        protected void NewSearchAndRun()
        {
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        /// <summary>
        /// Run a new search
        /// </summary>
        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { Session.User.LanguageCode };
            kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtProfileTagText.DataMemberDefaultText = DBO.XProfileTag.Name;
            edtProfileTagText.DataMemberTID = DBO.XProfileTag.NameTID;
            edtProfileTagDescription.DataMember = DBO.XProfileTag.Description;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colMerkmal.FieldName = COL_TEXT;
            colXProfileTagID.FieldName = DBO.XProfileTag.XProfileTagID;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtProfileTagText.Tag = lblProfileTagText.Text;
        }

        #endregion

        #endregion
    }
}