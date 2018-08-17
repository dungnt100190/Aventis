using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query.MBU
{
    public partial class CtlQueryStatVmErbschaft : KiSS4.Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryStatVmErbschaft()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, "Datum von");
            DBUtil.CheckNotNullField(edtDatumBis, "Datum bis");

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            this.grdListe2.DataSource = qryQuery.DataSet.Tables[1];
        }

        #endregion
    }
}