using System.Data;
using System.Linq;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryVmKesKennzahlen : KissQueryControl
    {
        private static readonly string[] _columnNames = {
                                                            "XML-Code",
                                                            "Massnahme Artikel",
                                                            "Massnahme Absatz",
                                                            "Massnahme Ziffer",
                                                            "Aufgabenbereich",
                                                            "Massnahmeführender",
                                                            "Beistandsart",
                                                            "Indikation",
                                                            "Elterliche Sorge",
                                                            "Obhut",
                                                            "Änderung vom",
                                                            "Änderungsgrund",
                                                            "Übernahme vom",
                                                            "Übertragung vom",
                                                            "Übertragung an",
                                                            "Aufhebung vom",
                                                            "Aufhebungsgrund"
                                                        };

        public CtlQueryVmKesKennzahlen()
        {
            InitializeComponent();
        }

        public override void OnSearch()
        {
            grdQuery1.DataSource = null;
            grvQuery1.Columns.Clear();
            qryQuery.DataTable.Columns.Clear();

            grdQuery1.DataSource = qryQuery;
            base.OnSearch();

            grvQuery1.BestFitColumns();
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblZeitraumVon.Text);

            base.RunSearch();
        }

        private static void AppendMassnahme(DataRow row, DataRow massnahme, int group)
        {
            foreach (var columnName in _columnNames)
            {
                row[group + " " + columnName] = massnahme[columnName];
            }
        }

        private void edtNameBeistand_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var edtNameBeistand = sender as KissButtonEdit;
            if (edtNameBeistand == null)
            {
                return;
            }

            var auswahl = new DlgAuswahl();
            e.Cancel = !auswahl.MassnahmefuehrenderSuchen(edtNameBeistand.Text, null, e.ButtonClicked);
            if (!e.Cancel)
            {
                edtNameBeistand.EditValue = auswahl["Name"];
                edtNameBeistand.LookupID = auswahl["UserID$"] as int? ?? auswahl["VmPriMaID$"] as int? ?? auswahl["BaInstitutionID$"] as int?;
                edtNameBeistand.Tag = auswahl["KesBeistandsartCode$"];
            }
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            foreach (var klientRow in qryQuery.DataSet.Tables[0].Rows.OfType<DataRow>())
            {
                var row = klientRow;
                var massnahmen = qryQuery.DataSet.Tables[1].Rows.OfType<DataRow>().Where(r => r["BaPersonID"].Equals(row["BaPersonID$"]));

                var group = 0;
                foreach (var massnahme in massnahmen)
                {
                    group++;
                    //Check if column exists
                    if (!qryQuery.DataSet.Tables[0].Columns.Contains(group + " " + _columnNames[0]))
                    {
                        foreach (var columnName in _columnNames)
                        {
                            qryQuery.DataSet.Tables[0].Columns.Add(new DataColumn(group + " " + columnName, qryQuery.DataSet.Tables[1].Columns[columnName].DataType));
                        }
                    }

                    AppendMassnahme(klientRow, massnahme, group);
                }
            }
        }
    }
}