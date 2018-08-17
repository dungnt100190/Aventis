using System;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbKostenstelleZuweisung : KiSS4.Common.KissSearchUserControl
    {
        public CtlKbKostenstelleZuweisung()
        {
            InitializeComponent();
        }

        //protected override void NewSearch()
        //{
        //    base.NewSearch();
        //    edtInklusiveUEPersonenX.EditMode = EditModeType.ReadOnly;
        //    edtInklusiveUEPersonenX.Checked = false;
        //}

        private void edtBaPersonIDX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            if (!DBUtil.IsEmpty(edtBaPersonIDX.EditValue) && dlg.PersonSuchen(
                edtBaPersonIDX.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%"),
                e.ButtonClicked))
            {
                edtBaPersonIDX.Text = dlg["Name"].ToString();
                edtBaPersonIDX.LookupID = dlg["BaPersonID"];
                //edtInklusiveUEPersonenX.EditMode = EditModeType.Normal;
            }
            else
            {
                edtBaPersonIDX.EditValue = DBNull.Value;
                //edtInklusiveUEPersonenX.EditMode = EditModeType.ReadOnly;
                //edtInklusiveUEPersonenX.Checked = false;
            }
        }

        private void CtlKbKostenstelleZuweisung_Load(object sender, EventArgs e)
        {
            this.colKostenstelleModul.ColumnEdit = grdKostenstellePerson.GetLOVLookUpEdit("Modul");
            this.tabControlSearch.SelectedTabIndex = 1;
            this.qryKostenstellePerson.EnableBoundFields(false);            
        }

        private void edtKostenstelle_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string SearchString = edtKostenstelle.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    this.qryKostenstellePerson["KbKostenstelleID"] = DBNull.Value;
                    this.qryKostenstellePerson["Nr"] = DBNull.Value;
                    this.qryKostenstellePerson["Name"] = DBNull.Value;
                    this.qryKostenstellePerson["Aktiv"] = DBNull.Value;
                    this.qryKostenstellePerson["ModulID"] = DBNull.Value;
                }
                return;
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT KbKostenstelleID$  = KST.KbKostenstelleID,                     
                     Nr                 = KST.Nr,
                     Name               = KST.Name,
                     Aktiv              = KST.Aktiv,
                     ModulID$           = KST.ModulID                     
              FROM   dbo.KbKostenstelle KST WITH (READUNCOMMITTED)
              WHERE  KST.Name LIKE '%' + {0} + '%'
              AND    KST.Aktiv = 1
              ORDER BY KST.Nr, KST.Name",
              SearchString,
              e.ButtonClicked);

            if (!e.Cancel)
            {
                this.qryKostenstellePerson["KbKostenstelleID"] = dlg["KbKostenstelleID$"];
                this.qryKostenstellePerson["Nr"] = dlg["Nr"];
                this.qryKostenstellePerson["Name"] = dlg["Name"];
                this.qryKostenstellePerson["Aktiv"] = dlg["Aktiv"];
                this.qryKostenstellePerson["ModulID"] = dlg["ModulID$"];
            }
        }

        private void edtPerson_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string SearchString = edtPerson.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    this.qryKostenstellePerson["BaPersonID"] = DBNull.Value;
                    this.qryKostenstellePerson["NameVorname"] = DBNull.Value;
                }
                return;
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(
              SearchString,
              e.ButtonClicked);

            if (!e.Cancel)
            {
                this.qryKostenstellePerson["BaPersonID"] = dlg["BaPersonID"];
                this.qryKostenstellePerson["NameVorname"] = dlg["Name"];
            }
        }

        private void qryKostenstellePerson_AfterInsert(object sender, EventArgs e)
        {
            // set creator
            this.qryKostenstellePerson.SetCreator();
        }

        private void qryKostenstellePerson_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtKostenstelle, lblKostenstelle.Text);
            DBUtil.CheckNotNullField(edtPerson, lblPerson.Text);
            DBUtil.CheckNotNullField(edtGueltigVon, lblGueltigVon.Text);

            int cnt = 0;

            if (DBUtil.IsEmpty(this.qryKostenstellePerson["KbKostenstelleBaPersonID"]))
            {
                cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.KbKostenstelle_BaPerson KSP WITH (READUNCOMMITTED)
                        WHERE KSP.BaPersonID = {0}
                        AND KSP.KbKostenstelleID = {1}
                        AND (KSP.DatumBis IS NULL OR {2} BETWEEN KSP.DatumVon AND KSP.DatumBis)"
                            , this.qryKostenstellePerson["BaPersonID"]
                            , this.qryKostenstellePerson["KbKostenstelleID"]
                            , this.qryKostenstellePerson["DatumVon"]));

                if (cnt > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlKbKostenstelleZuweisung", "UnerlaubteZuweisung", "Es besteht bereits eine Zuweisung (Person, Kostenstelle) in der gewünschten Zeitspanne.", KissMsgCode.MsgInfo));
                }
            }

            // set modifier/modified
            this.qryKostenstellePerson.SetModifierModified();
        }
    }
}
