using System;

using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Administration
{
    public partial class CtlProfile : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_TAGS = "Tags";

        /// <summary>
        /// Name der Spalte für Text in der GridView.
        /// </summary>
        private const string COL_TEXT = "Text";

        /// <summary>
        /// Vor dem Löschen eines Profils: Verknüpfungen zu XProfileTag löschen. 
        /// </summary>
        private const string SQL_BEFORE_DELETING_PROFILE = @"
            DELETE
            FROM dbo.XProfile_XProfileTag
            WHERE XProfileID = {0};";

        #endregion

        #endregion

        #region Constructors

        public CtlProfile()
        {
            InitializeComponent();

            SetupDataMembers();
            SetupFieldNames();
            SetupTags();

            NewSearchAndRun();
        }

        #endregion

        #region EventHandlers

        private void qryXProfile_AfterDelete(object sender, EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryXProfile_AfterInsert(object sender, EventArgs e)
        {
            qryXProfile.SetCreator();
            edtProfileText.Focus();
        }

        private void qryXProfile_AfterPost(object sender, EventArgs e)
        {
            // set value to display-only column
            qryXProfile[COL_TEXT] = edtProfileText.Text;
        }

        private void qryXProfile_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            // hier darf kein Code stehen!
            // wenn in DoSomething() nichts gemacht werden muss,
            // kann der ganze try-catch-Block weggelassen werden.
            try
            {
                int profileID = Utils.ConvertToInt(qryXProfile[DBO.XProfile.XProfileID]);
                DBUtil.ExecSQL(SQL_BEFORE_DELETING_PROFILE, profileID);
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryXProfile_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtProfileText, lblProfileName.Text);

            qryXProfile[DBO.XProfile.XProfileTypeCode] = Convert.ToInt32(Dokument.Utilities.XProfileType.UserOrOrgUnitProfile);

            qryXProfile.SetModifierModified();
        }

        private void qryXProfile_PositionChanged(object sender, EventArgs e)
        {
            panelDetail.Enabled = !qryXProfile.IsEmpty;
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryXProfile.IsEmpty)
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
            edtProfileText.Focus();
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
            object[] parameters = new object[] { Session.User.LanguageCode, Convert.ToInt32(Dokument.Utilities.XProfileType.UserOrOrgUnitProfile) };
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
            edtProfileText.DataMemberDefaultText = DBO.XProfile.Name;
            edtProfileText.DataMemberTID = DBO.XProfile.NameTID;
            edtDescription.DataMember = DBO.XProfile.Description;
            edtProfileTags.DisplayMember = COL_TAGS;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colID.FieldName = DBO.XProfile.XProfileID;
            colName.FieldName = COL_TEXT;
            colTags.FieldName = COL_TAGS;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtProfileText.Tag = lblProfileName.Text;
            edtProfileTags.Tag = lblProfileTags.Text;
        }

        #endregion

        #endregion
    }
}