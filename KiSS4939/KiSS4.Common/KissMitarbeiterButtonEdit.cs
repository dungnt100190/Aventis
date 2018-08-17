using System;
using System.ComponentModel;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// A component that is used for selecting a XUser.
    ///
    /// Set the DataSource, DataMember and DataMemberUserId
    /// or set IsSearchField for Queries.
    ///
    /// If you only want to show users who have access to a
    /// specific module, set the ModulId property to true too.
    ///
    /// There is a PI Mode which will show different columns in the dialog.
    /// Set the property PiMode to true to switch to PI Mode.
    /// </summary>
    [ToolboxItem(true)]
    public partial class KissMitarbeiterButtonEdit : KissButtonEdit
    {
        #region Constructors

        public KissMitarbeiterButtonEdit()
        {
            InitializeComponent();

            DataMember = string.Empty;
            DataMemberUserId = string.Empty;
            ModulId = ModulID.None;

            UserModifiedFld += KissButtonEdit_UserModifiedFld;
        }

        public KissMitarbeiterButtonEdit(IContainer container)
            : this()
        {
            container.Add(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the data member that specifies the column for displaying the selected value.
        /// </summary>
        [DefaultValue("")]
        public new string DataMember
        {
            get { return base.DataMember; }
            set { base.DataMember = value; }
        }

        /// <summary>
        /// Gets or sets the data member that specifies the selected user.
        /// </summary>
        [DefaultValue("")]
        public string DataMemberUserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets that this control is used as a "search parameter".
        /// DataSource and DataMember's don't have to be set.
        /// </summary>
        [DefaultValue(false)]
        public bool IsSearchField
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a ModulID to use for searching.
        /// Use <c>ModulID.None</c> to get all users.
        /// </summary>
        [DefaultValue(ModulID.None)]
        public ModulID ModulId
        {
            get;
            set;
        }

        /// <summary>
        /// For PI other columns will be details.
        /// </summary>
        [DefaultValue(false)]
        public bool PiMode
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Event handler for the base.UserModifiedFld event.
        /// </summary>
        /// <remarks>
        /// The reason because the OnUserModifiedFld is not overridden is that doing so is hardly possible..
        /// The accessor of EditValue again calls OnUserModifiedFld and the behavior is different between
        /// clicking on the button and leaving the control.
        /// </remarks>
        private void KissButtonEdit_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (IsDesignMode)
            {
                return;
            }

            //Do some validation
            if (DataSource == null && IsSearchField == false)
            {
                throw new ArgumentException(
                    @"Datasource not set and IsSearchField is set to false. Set the datasource or set IsSearchField to true");
            }

            //PI will show other columns in the Dialog.
            if (PiMode)
            {
                PiClient(e);
            }
            //All other clients
            else
            {
                StandardClient(e);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// For PI client.
        /// PI client will show other columns than standard client.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private void PiClient(UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (EditMode == EditModeType.ReadOnly ||
                     (!IsSearchField && !DataSource.CanUpdate))
                {
                    // do nothing
                    return;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(EditValue))
                {
                    // prepare for database search
                    searchString = EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        if (!IsSearchField)
                        {
                            DataSource[DataMemberUserId] = DBNull.Value;
                            DataSource[DataMember] = DBNull.Value;
                        }

                        EditValue = null;
                        LookupID = null;

                        return;
                    }
                }

                // Mitarbeiter_Suchen()
                KissLookupDialog dlg = new KissLookupDialog();
                e.Cancel =
                    !dlg.SearchData(
                        String.Format(
                            @"
                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE {1} OR USR.Kürzel LIKE {1} OR USR.UserID$ LIKE {1}",
                            Session.User.UserID,
                            DBUtil.SqlLiteralLike(searchString + "%")),
                        searchString,
                        e.ButtonClicked,
                        null,
                        null,
                        null);

                if (!e.Cancel)
                {
                    // apply new value
                    if (!IsSearchField)
                    {
                        DataSource[DataMemberUserId] = dlg["UserID$"];
                        DataSource[DataMember] = dlg["Name"];
                    }
                    else
                    {
                        //Order is important, first editvalue
                        //then lookupid.
                        EditValue = dlg["Name"];
                        LookupID = dlg["UserID$"];
                    }

                    // success
                    return;
                }

                // canceled or error
                return;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return;
            }
        }

        /// <summary>
        /// For standard client. Standard will show other columns than PI client.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private void StandardClient(UserModifiedFldEventArgs e)
        {
            // Prepare search string
            var searchString = EditValue != null ? EditValue.ToString() : "%";

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    if (!IsSearchField)
                    {
                        DataSource[DataMemberUserId] = DBNull.Value;
                        DataSource[DataMember] = DBNull.Value;
                    }

                    EditValue = null;
                    LookupID = null;

                    return;
                }
            }

            // Show dialog
            using (var dlg = new DlgAuswahl())
            {
                var res = ModulId == ModulID.None
                              ? dlg.MitarbeiterSuchen(searchString, e.ButtonClicked)
                              : dlg.MitarbeiterSuchen(searchString, ModulId, e.ButtonClicked);

                if (res)
                {
                    if (!IsSearchField)
                    {
                        DataSource[DataMemberUserId] = dlg[0];
                        DataSource[DataMember] = dlg[1];
                    }
                    else
                    {
                        //Order is important, first editvalue
                        //then lookupid.
                        EditValue = dlg[1];
                        LookupID = dlg[0];
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #endregion
    }
}