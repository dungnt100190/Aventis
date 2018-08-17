using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Common;

namespace KiSS4.Query.IBE
{
    public partial class CtlQueryBaArbeitAusbildung : KiSS4.Common.KissQueryControl
    {
        public CtlQueryBaArbeitAusbildung()
        {
            InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"SELECT Code = OrgUnitID, Text = ItemName
                                            FROM XOrgUnit
                                            ORDER BY ItemName");
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();

            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;

            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(tabControlSearch_SelectedTabChanged);
        }

        void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgListe)
            {
                var colBemerkung = grvQuery1.Columns["Bemerkung"];
                if (colBemerkung != null)
                {
                    colBemerkung.DisplayFormat.Format = new GridColumnRTF();
                }
            }
        }
    }
}
