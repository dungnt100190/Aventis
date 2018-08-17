using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Common
{
    /// <summary>
    /// Control zum Bearbeiten eines Profils.
    /// Gebrauch:
    ///  ActiveSQL Query setzen.
    ///  Das DataMember muss XProfileID heissen (ansonsten dieses Control erweitern. :)).
    ///  Gebraucht wird das Control auf CtlDocTemplate.
    /// </summary>
    public partial class CtlProfileTagsControl : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Holt alle ProfileTags, die es gibt.
        /// </summary>
        private const string SQL_ALL_PROFILETAGS = @"
            SELECT [Code] = PRT.XProfileTagID,
                   [Text] = dbo.fnGetMLTextByDefault(PRT.NameTID, {0}, PRT.Name)
            FROM dbo.XProfileTag PRT WITH (READUNCOMMITTED)
            ORDER BY [Text];";

        /// <summary>
        /// Löscht das gesamte Profil
        /// </summary>
        private const string SQL_DELETE_PROFILE = @"
            DELETE
            FROM dbo.XProfile_XProfileTag
            WHERE XProfileID = {0};

            DELETE
            FROM dbo.XProfile
            WHERE XProfileID = {0};";

        /// <summary>
        /// Löscht die Relationen zwischen XProfile und XProfileTag
        /// </summary>
        private const string SQL_DELETE_PROFILE_TAGS_REFS = @"
            DELETE
            FROM dbo.XProfile_XProfileTag
            WHERE XProfileID = {0};";

        /// <summary>
        /// Holt alle ProfileTagID's eines Profils.
        /// </summary>
        private const string SQL_GETTAGS_OF_PROFILE = @"
            SELECT XProfileTagID
            FROM dbo.XProfile_XProfileTag WITH (READUNCOMMITTED)
            WHERE XProfileID = {0};";

        /// <summary>
        /// Speichert das Profil. 
        /// </summary>
        private const string SQL_SAVEPROFILE_TAGS = @"
            DECLARE @ProfileID INT;
            EXEC @ProfileID = dbo.spXSaveProfileTags {0}, '{1}';
            SELECT ProfileID = @ProfileID;";

        #endregion

        #region Private Fields

        /// <summary>
        /// True wenn die ProfileTags geladen werden.       
        /// </summary>
        private bool _isLoading;

        /// <summary>
        /// Wenn das Control auf der Maske für die Profile selber verwendet wird,
        /// dann müssen die ProfileTags-Referenzen wegen den FK-Constraints erst nach dem
        /// INSERT in XProfile erstellt werden. Wir brauchen den Primärschlüssel
        /// des Profils, wegen IDENTITY kriegen wir den erst nach dem Post.
        /// 
        /// Wird das Control z.B. bei den Vorlagen verwendet, dann muss das XProfil
        /// vor dem Speichern der Vorlage erstellt werden. Es kann ja sein, dass
        /// die Vorlage noch kein Profil hat, dann wird die SP eines erstellen.
        /// </summary>
        private bool _saveInAfterPost;

        #endregion

        #endregion

        #region Constructors

        public CtlProfileTagsControl()
        {
            InitializeComponent();

            //LookupSQL für edtProifleTags Sparchabhäging machen
            //mit LanguageCode
            if (Session.User == null)
            {
                edtProfileTags.LookupSQL = string.Format(SQL_ALL_PROFILETAGS, 1);
            }
            else
            {
                edtProfileTags.LookupSQL = string.Format(SQL_ALL_PROFILETAGS, Session.User.LanguageCode);
            }
        }

        #endregion

        #region Properties

        public override SqlQuery ActiveSQLQuery
        {
            get { return base.ActiveSQLQuery; }
            set
            {
                value.PositionChanged += query_PositionChanged;
                value.BeforePost += query_BeforePost;
                value.AfterPost += query_AfterPost;
                value.BeforeDelete += query_BeforeDelete;
                value.AfterDelete += query_AfterDelete;
                base.ActiveSQLQuery = value;
            }
        }

        /// <summary>
        /// Die Kolonne im SQLQuery, welche den Text "Merkmale" anzeigt.
        /// Für GridViews.
        /// </summary>
        public string DisplayMember
        {
            get;
            set;
        }

        /// <summary>
        /// Dieses Property nur auf CtlProfile auf true stellen.
        /// Sonst bitte nicht verwenden.
        /// Etwas unschön, dass dieses Control das wissen muss.
        /// </summary>
        public bool IsOnCtlProfile
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void CtlProfileTagsControl_Load(object sender, EventArgs e)
        {
            // setup control to have border
            BackColor = GuiConfig.ControlBorder;
        }

        private void edtProfileTags_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (ActiveSQLQuery.Row != null && _isLoading == false)
            {
                DataRowState state = ActiveSQLQuery.Row.RowState;

                if (state == DataRowState.Unchanged)
                {
                    ActiveSQLQuery.Row.SetModified();
                }

                if (!string.IsNullOrEmpty(DisplayMember))
                {
                    string tags = GetKissCheckedLookupEditGridString(edtProfileTags);
                    ActiveSQLQuery[DisplayMember] = tags;
                }
            }
        }

        private void query_AfterPost(object sender, EventArgs e)
        {
            if (_saveInAfterPost)
            {
                SaveProfileTags();
                _saveInAfterPost = false;
            }
        }

        private void query_BeforeDelete(object sender, EventArgs e)
        {
            if (IsOnCtlProfile)
            {
                DeleteProfileTags();
            }            
        }

        private void query_AfterDelete(object sender, EventArgs e)
        {
            if (!IsOnCtlProfile)
            {
                DeleteProfile();
            }
        }

        private void query_BeforePost(object sender, EventArgs e)
        {
            if (ActiveSQLQuery.Row.RowState == DataRowState.Modified)
            {
                SaveProfileTags();
                _saveInAfterPost = false;
            }

            if (ActiveSQLQuery.Row.RowState == DataRowState.Added)
            {
                _saveInAfterPost = true;
            }
        }

        private void query_PositionChanged(object sender, EventArgs e)
        {
            LoadValues();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Erstellt einen String anhand der angewählten Items in einem KissCheckedLookupEdit.
        /// Beispiel (Die items "BigMac" und "Shake" sind angewählt, dann ergibt diese Fuktion "BitMac; Shake".
        /// </summary>
        /// <param name="control">Das Control</param>
        /// <returns>Zusammengesetzter String von den angewählten Items.</returns>
        public string GetKissCheckedLookupEditGridString(KissCheckedLookupEdit control)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < control.Items.Count; i++)
            {
                if (control.Items[i].CheckState == CheckState.Checked)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("; ");
                    }

                    sb.Append(control.Items[i].ToString());
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Löscht ein Profil und die Verknüfungen zu den ProfileTags.
        /// </summary>
        private void DeleteProfile()
        {
            int profileID = Utils.ConvertToInt(ActiveSQLQuery[DBO.XProfile.XProfileID]);
            DBUtil.ExecSQL(SQL_DELETE_PROFILE, profileID);
        }

        /// <summary>
        /// Löscht die Verknüpfungen zu den ProfileTags.
        /// </summary>
        private void DeleteProfileTags()
        {
            int profileID = Utils.ConvertToInt(ActiveSQLQuery[DBO.XProfile.XProfileID]);
            DBUtil.ExecSQL(SQL_DELETE_PROFILE_TAGS_REFS, profileID);
        }

        private void LoadValues()
        {
            _isLoading = true;
            int profileID = Utils.ConvertToInt(ActiveSQLQuery[DBO.XProfile.XProfileID]);
            SqlQuery qry = DBUtil.OpenSQL(SQL_GETTAGS_OF_PROFILE, profileID);
            string selectedValues = "";

            foreach (DataRowView row in qry.DataTable.DefaultView)
            {
                if (!DBUtil.IsEmpty(row[DBO.XProfile_XProfileTag.XProfileTagID]))
                {
                    selectedValues = row[DBO.XProfile_XProfileTag.XProfileTagID] + "," + selectedValues;
                }
            }

            edtProfileTags.EditValue = selectedValues;
            _isLoading = false;
        }

        /// <summary>
        /// Speichert die ProfileTags. Wenn noch kein Profil vorhanden ist,
        /// dann erstellt die SP ein neues Profil.
        /// </summary>
        private void SaveProfileTags()
        {
            string selectedValues = edtProfileTags.EditValue;

            int profileID = Utils.ConvertToInt(ActiveSQLQuery[DBO.XProfile.XProfileID]);

            string sql = string.Format(SQL_SAVEPROFILE_TAGS, profileID, selectedValues);
            int result = (int)DBUtil.ExecuteScalarSQL(sql);

            ActiveSQLQuery[DBO.XProfile.XProfileID] = result;
        }

        #endregion

        #endregion
    }
}