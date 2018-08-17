using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    /// <summary>
    /// Die Liste zeigt eine Übersicht aller Stellensuchenden, welche aktuell im Programm Jobtimum teilnehmen 
    /// (und somit einen gültigen KA Einsatz Typ Anweisung/Verlängerung haben)
    /// </summary>
    public partial class CtlQueryKaCasemanagementlisteBin : KissQueryControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryKaCasemanagementlisteBin"/> class.
        /// </summary>
        public CtlQueryKaCasemanagementlisteBin()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtSucheDatum.EditValue = DateTime.Now.Date;
            edtSucheDatum.Focus();
        }

        protected override void RunSearch()
        {
            // Datum is required
            DBUtil.CheckNotNullField(edtSucheDatum, lblSucheDatum.Text);

            base.RunSearch();
        }

        #endregion

        #endregion
    }
}