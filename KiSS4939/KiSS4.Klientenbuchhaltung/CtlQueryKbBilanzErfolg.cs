using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

using KiSS.DBScheme;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlQueryKbBilanzErfolg : KissSearchUserControl
    {
        #region Enumerations

        private enum BilanzErCode
        {
            Bilanz = 1,
            Erfolgsrechnung = 2
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_BILANZERCODE = "BilanzErCode";

        #endregion

        #region Private Fields

        private bool _isSelectedTabChanging;
        private int _kbPeriodeID;
        private DateTime _periodeBis;
        private DateTime _periodeVon;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKbBilanzErfolg()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryKbBilanzErfolg_Load(object sender, EventArgs e)
        {
            _kbPeriodeID = Utils.ConvertToInt(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));

            var qryPeriode = DBUtil.OpenSQL(@"
                SELECT PeriodeVon,
                       PeriodeBis
                FROM dbo.KbPeriode WITH (READUNCOMMITTED)
                WHERE KbPeriodeID = {0};", _kbPeriodeID);

            _periodeVon = Utils.ConvertToDateTime(qryPeriode[DBO.KbPeriode.PeriodeVon]);
            _periodeBis = Utils.ConvertToDateTime(qryPeriode[DBO.KbPeriode.PeriodeBis]);

            // Because Control is not QueryControl --> Start new Search manually
            ArrangeTabPages();
            NewSearch();
        }

        private void btnBilanzCollapse_Click(object sender, EventArgs e)
        {
            CollapseTree(treBilanz);
        }

        private void btnBilanzExpand_Click(object sender, EventArgs e)
        {
            ExpandTree(treBilanz);
        }

        private void btnErfolgCollapse_Click(object sender, EventArgs e)
        {
            CollapseTree(treErfolg);
        }

        private void btnErfolgExpand_Click(object sender, EventArgs e)
        {
            ExpandTree(treErfolg);
        }

        private void btnUebersichtCollapse_Click(object sender, EventArgs e)
        {
            CollapseTree(treUebersicht);
        }

        private void btnUebersichtExpand_Click(object sender, EventArgs e)
        {
            ExpandTree(treUebersicht);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            _isSelectedTabChanging = false;
        }

        private void tabControlSearch_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            _isSelectedTabChanging = true;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override String GetContextName()
        {
            Debug.WriteLine("GetContextName()");

            if (tabControlSearch.SelectedTab == tpgBilanz)
            {
                return "CtlQueryKbBilanzErfolg_Bilanz";
            }

            if (tabControlSearch.SelectedTab == tpgErfolg)
            {
                return "CtlQueryKbBilanzErfolg_Erfolg";
            }

            return "CtlQueryKbBilanzErfolg";
        }

        public override object GetContextValue(string fieldName)
        {
            Debug.WriteLine("GetContextValue " + fieldName);
            object context;

            switch (fieldName.ToUpper())
            {
                case "KBPERIODEID":
                    context = _kbPeriodeID;
                    break;

                case "NURMITBUCHUNGEN":
                    context = edtNurMitBuchungen.Checked;
                    break;

                case "DATUMVON":
                    context = edtDatumVon.EditValue;
                    break;

                case "DATUMBIS":
                    context = edtDatumBis.EditValue;
                    break;

                case "OHNEKTOGRUPPEN":
                    context = edtOhneKtoGruppen.Checked;
                    break;

                default:
                    context = base.GetContextValue(fieldName);
                    break;
            }

            return context;
        }

        /// <summary>
        /// Translate this query
        /// </summary>
        public override void Translate()
        {
            // apply translation
            base.Translate();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage(Name, "Liste1Uebersicht_v01", "Ü&bersicht");
            tpgBilanz.Title = KissMsg.GetMLMessage(Name, "Liste2Bilanz_v01", "&Bilanz");
            tpgErfolg.Title = KissMsg.GetMLMessage(Name, "Liste3Erfolg_v01", "&Erfolg");
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            tabControlSearch.SelectTab(tpgSuchen);

            edtNurMitBuchungen.Checked = true;
            edtOhneKtoGruppen.Checked = true;
            edtDatumVon.EditValue = _periodeVon;
            edtDatumBis.EditValue = _periodeBis;
            edtDatumVon.Focus();
        }

        protected override void RunSearch()
        {
            if (!CheckPrms())
            {
                throw new KissCancelException();
            }

            try
            {
                BeforeFill();

                qryBilanzErfolg.Fill(@"
                    EXEC dbo.spKbGetBilanzErfolg {0}, {1}, {2}, {3}, {4};",
                    _kbPeriodeID,
                    edtDatumVon.EditValue,
                    edtDatumBis.EditValue,
                    edtNurMitBuchungen.Checked,
                    edtOhneKtoGruppen.Checked);

                AfterFill();

                if (!_isSelectedTabChanging)
                {
                    try
                    {
                        kissSearch.Disabled = true;
                        tabControlSearch.SelectTab(tpgListe);
                    }
                    finally
                    {
                        kissSearch.Disabled = false;
                    }
                }

                _isSelectedTabChanging = false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorSearchingData", "Es ist ein Fehler beim Suchen der Daten aufgetreten.", ex);
                throw;
            }
        }

        #endregion

        #region Private Static Methods

        private static void AfterFillInitTree(KissTree tree, ISupportInitialize dataSource)
        {
            tree.DataSource = dataSource;
            tree.ExpandAll();
            tree.Focus();
        }

        private static void BeforeFillInitTree(KissTree tree)
        {
            tree.DataSource = null;
        }

        private static void CollapseTree(KissTree tree)
        {
            tree.CollapseAll();
            tree.Focus();
        }

        private static void ExpandTree(KissTree tree)
        {
            tree.ExpandAll();
            tree.Focus();
        }

        #endregion

        #region Private Methods

        private void AfterFill()
        {
            SetBilanzBestandColumnsPer();

            AfterFillInitTree(treUebersicht, GetDataSourceUebersicht());
            AfterFillInitTree(treBilanz, GetDataSourceBilanz());
            AfterFillInitTree(treErfolg, GetDataSourceErfolg());
        }

        private void ArrangeTabPages()
        {
            // do nothing in designmode
            if (DesignMode)
            {
                return;
            }

            // move tpgSearch always to the right side
            // Um das Flackern beim Öffnen der Abfrage zu verhindern,
            // verwenden wir BeginUpdate/EndUpdate
            tabControlSearch.BeginUpdate();

            try
            {
                kissSearch.Disabled = true;

                try
                {
                    // Hier wird sichergestellt, dass tpgSuchen als letzter Tab erscheint.
                    // Dies kann nicht im Design gemacht werden,
                    // da je nach Abfrage weitere Ritter automatisch erstellt werden.
                    tabControlSearch.TabPages.Remove(tpgSuchen);
                    tabControlSearch.TabPages.Add(tpgSuchen);
                }
                finally
                {
                    kissSearch.Disabled = false;
                }
            }
            finally
            {
                tabControlSearch.EndUpdate();
            }
        }

        private void BeforeFill()
        {
            BeforeFillInitTree(treUebersicht);
            BeforeFillInitTree(treBilanz);
            BeforeFillInitTree(treErfolg);
        }

        private bool CheckPrms()
        {
            if (DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                tabControlSearch.SelectTab(tpgSuchen);
                DlgInfo.Show("Das Feld 'Datum von' darf nicht leer bleiben!", 0, 0);
                edtDatumVon.Focus();
                return false;
            }

            if (DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                tabControlSearch.SelectTab(tpgSuchen);
                DlgInfo.Show("Das Feld 'Datum bis' darf nicht leer bleiben!", 0, 0);
                edtDatumBis.Focus();
                return false;
            }

            return true;
        }

        private DataView GetDataSourceBilanz()
        {
            return new DataView(qryBilanzErfolg.DataTable.Copy())
            {
                RowFilter = string.Format("{0} = {1}", COL_BILANZERCODE, Convert.ToInt32(BilanzErCode.Bilanz))
            };
        }

        private DataView GetDataSourceErfolg()
        {
            return new DataView(qryBilanzErfolg.DataTable.Copy())
            {
                RowFilter = string.Format("{0} = {1}", COL_BILANZERCODE, Convert.ToInt32(BilanzErCode.Erfolgsrechnung))
            };
        }

        private DataView GetDataSourceUebersicht()
        {
            return new DataView(qryBilanzErfolg.DataTable);
        }

        private void SetBilanzBestandColumnsPer()
        {
            // Von
            if (DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                colBilanzBestandPerVon.Caption = KissMsg.GetMLMessage(Name, "BilanzBestandPerAnfang", "Bestand per Anfang");
            }
            else
            {
                colBilanzBestandPerVon.Caption = KissMsg.GetMLMessage(
                    Name, "BilanzBestandPerVon", "Bestand per {0:d}", KissMsgCode.Text, edtDatumVon.EditValue);
            }

            // Bis
            if (DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                colBilanzBestandPerBis.Caption = KissMsg.GetMLMessage(Name, "BilanzBestandPerEnde", "Bestand per Ende");
            }
            else
            {
                colBilanzBestandPerBis.Caption = KissMsg.GetMLMessage(
                    Name, "BilanzBestandPerBis", "Bestand per {0:d}", KissMsgCode.Text, edtDatumBis.EditValue);
            }
        }

        #endregion

        #endregion
    }
}