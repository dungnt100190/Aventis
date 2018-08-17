using System;
using System.ComponentModel;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// A component that is used for selecting a person / institution.
    /// Set the DataSource, DataMember, DataMemberBaInstitution and the DataMemberBaPerson properties.
    /// </summary>
    [ToolboxItem(true)]
    public partial class KissAdressatButtonEdit : KissButtonEdit
    {
        #region Constructors

        public KissAdressatButtonEdit()
        {
            InitializeComponent();

            DataMember = string.Empty;
            DataMemberBaInstitution = string.Empty;
            DataMemberBaPerson = string.Empty;
            DataMemberFaLeistung = string.Empty;

            UserModifiedFld += KissButtonEdit_UserModifiedFld;
        }

        public KissAdressatButtonEdit(IContainer container)
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
        /// Gets or sets the data member that is used when an institution is selected.
        /// </summary>
        [DefaultValue("")]
        public string DataMemberBaInstitution
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data member that is used when a person is selected.
        /// </summary>
        [DefaultValue("")]
        public string DataMemberBaPerson
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data member that specifies the current FaLeistungID.
        /// </summary>
        [DefaultValue("")]
        public string DataMemberFaLeistung
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data member that is used when a privater Mandatsträger is selected.
        /// </summary>
        [DefaultValue("")]
        public string DataMemberVmPriMa
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
            if (DataSource == null)
            {
                return;
            }

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
                    DataSource[DataMemberBaPerson] = DBNull.Value;
                    DataSource[DataMemberBaInstitution] = DBNull.Value;
                    if (!string.IsNullOrEmpty(DataMemberVmPriMa))
                    {
                        DataSource[DataMemberVmPriMa] = DBNull.Value;
                    }
                    DataSource[DataMember] = DBNull.Value;
                    return;
                }
            }

            int faLeistungId = 0;

            if (!DBUtil.IsEmpty(DataMemberFaLeistung))
            {
                faLeistungId = Utils.ConvertToInt(DataSource[DataMemberFaLeistung], 0);
                if (faLeistungId == 0)
                {
                    // Try to get it from the data source
                    if (!DBUtil.IsEmpty(DataSource[DBO.FaLeistung.FaLeistungID]))
                    {
                        faLeistungId = Utils.ConvertToInt(DataSource[DBO.FaLeistung.FaLeistungID]);
                    }
                }
            }

            // Show dialog
            using (var dlg = new DlgAuswahl())
            {
                bool showPriMa = !string.IsNullOrEmpty(DataMemberVmPriMa);

                if (dlg.AdressatSuchen(searchString, faLeistungId, e.ButtonClicked, showPriMa))
                {
                    switch (Utils.ConvertToInt(dlg[1]))
                    {
                        case 1: // Person
                            DataSource[DataMemberBaPerson] = dlg[0];
                            DataSource[DataMemberBaInstitution] = DBNull.Value;
                            if (!string.IsNullOrEmpty(DataMemberVmPriMa))
                            {
                                DataSource[DataMemberVmPriMa] = DBNull.Value;
                            }
                            break;

                        case 2: // Institution
                            DataSource[DataMemberBaPerson] = DBNull.Value;
                            DataSource[DataMemberBaInstitution] = dlg[0];
                            if (!string.IsNullOrEmpty(DataMemberVmPriMa))
                            {
                                DataSource[DataMemberVmPriMa] = DBNull.Value;
                            }
                            break;

                        case 3: // Private Mandatsträger
                            DataSource[DataMemberBaPerson] = DBNull.Value;
                            DataSource[DataMemberBaInstitution] = DBNull.Value;
                            if (!string.IsNullOrEmpty(DataMemberVmPriMa))
                            {
                                DataSource[DataMemberVmPriMa] = dlg[0];
                            }
                            break;
                    }

                    DataSource[DataMember] = dlg[3];
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion
    }
}