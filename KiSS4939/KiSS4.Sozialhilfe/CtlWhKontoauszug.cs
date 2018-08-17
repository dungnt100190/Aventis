using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Reflection;
using System.Text;
using log4net;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public partial class CtlWhKontoauszug : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly int _baPersonID;

        #endregion

        #endregion

        #region Constructors

        public CtlWhKontoauszug(Image titelImage, string titelText, int baPersonID)
            : this()
        {
            picTitel.Image = titelImage;
            lblTitel.Text = titelText;
            _baPersonID = baPersonID;
        }

        public CtlWhKontoauszug()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryVerfuegbar.Count < 1)
            {
                return;
            }

            qryZugeteilt.DataTable.Rows.Add(qryVerfuegbar.Row.ItemArray);
            qryVerfuegbar.DeleteQuestion = null;
            qryVerfuegbar.Delete();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            qryZugeteilt.Fill(1);
            qryVerfuegbar.Fill(0);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryZugeteilt.Count < 1)
            {
                return;
            }

            qryVerfuegbar.DataTable.Rows.Add(qryZugeteilt.Row.ItemArray);
            qryZugeteilt.DeleteQuestion = null;
            qryZugeteilt.Delete();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            qryVerfuegbar.Fill(1);
            qryZugeteilt.Fill(0);
        }

        private void CtlWhKontoauszug_Load(object sender, EventArgs e)
        {
            NewSearch();

            grdKbBuchungKostenart.DataSource = null;

            btnAuszugDrucken.Enabled = DBUtil.UserHasRight(typeof(CtlWhKontoauszug).Name + "_AuszugDrucken");

            colTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("BgDokumentTyp");

            //Buchungsstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL(@"
                SELECT *
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'KbBuchungsStatus'
                ORDER BY SortKey;");

            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            edtPersonen.LookupSQL = string.Format(@"
                SELECT DISTINCT
                  Code = PRS.BaPersonID,
                  Text = PRS.NameVorname
                FROM BgFinanzplan_BaPerson BFB WITH(READUNCOMMITTED)
                  INNER JOIN vwPerson      PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = BFB.BaPersonID
                  INNER JOIN BgFinanzplan  BFP WITH(READUNCOMMITTED) ON BFP.BgFinanzplanID = BFB.BgFinanzplanID
                  INNER JOIN FaLeistung    FLE WITH(READUNCOMMITTED) ON FLE.FaLeistungID = BFP.FaLeistungID
                WHERE FLE.BaPersonID = {0}
                  AND BFB.IstUnterstuetzt = 1
                ORDER BY PRS.NameVorname;", _baPersonID);

            btnRemoveAll.PerformClick();
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";

            if (!DBUtil.IsEmpty(edtFilter.EditValue))
            {
                value = edtFilter.EditValue.ToString();
            }

            qryVerfuegbar.DataTable.DefaultView.RowFilter = "Name like '%" + value + "%'";
        }

        private void edtZeitraum_EditValueChanged(object sender, EventArgs e)
        {
            edtBetraegeAnpassen.Checked = (int)edtZeitraum.EditValue == 3;
        }

        private void grdKbBuchungKostenart_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"SELECT NameVorname
                                            FROM dbo.vwPerson
                                            WHERE BaPersonID = {0};", _baPersonID);
            string personText = Utils.ConvertToString(qry["NameVorname"]);
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVon.Text, edtDatumBis.Text);

            grdKbBuchungKostenart.SetHeaderAndFooterText(
                e,
                KissMsg.GetMLMessage("CtlWhKontoauszug", "WhKontoauszugTitel", "Kontoauszug"),
                personText + ", " + footerTextLeft
            );
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
        }

        private void grdZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            if (btnRemove.Enabled)
            {
                btnRemove.PerformClick();
            }
        }

        private void qryKontoauszug_AfterFill(object sender, EventArgs e)
        {
            decimal saldo = 0m;
            foreach (DataRow row in qryKontoauszug.DataTable.Rows)
            {
                var rowSaldo = Utils.ConvertToDecimal(row["Saldo"]);
                saldo += rowSaldo;
                saldo += Utils.ConvertToDecimal(row["Ausgabe"]) - Utils.ConvertToDecimal(row["Einnahme"]);
                if (rowSaldo == 0m)
                {
                    row["Saldo"] = saldo;
                }
            }

            qryKontoauszug.DataTable.AcceptChanges();
            qryKontoauszug.RowModified = false;

            grdKbBuchungKostenart.DataSource = qryKontoauszug;
        }

        private void qryKontoauszug_PositionChanged(object sender, EventArgs e)
        {
            if (qryKontoauszug["EA"].ToString() == "A")
            {
                lblKreditor.Text = "Kreditor";
            }
            else
            {
                lblKreditor.Text = "Debitor";
            }

            /*
            ///TODO: qryBgDokumente anpassen
            if (qryKontoauszug["BuchungID"].ToString() == "K")
                qryBgDokumente.Fill(qryKontoauszug["BuchungID"]);
            else
                qryBgDokumente.Fill(-1);
            */
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            // Diese Werte sollten nie NULL sein, da sonst die Textmarke nicht funktioniert
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;

                case "PERSON":
                    return edtPersonen.EditValue;

                case "ZEITRAUM":
                    return edtZeitraum.EditValue;

                case "DATUMVON":
                    return edtDatumVon.EditValue ?? SqlDateTime.MinValue.Value;

                case "DATUMBIS":
                    return edtDatumBis.EditValue ?? SqlDateTime.MaxValue.Value;

                case "LALIST":
                    return GetLaList();

                case "VERDICHTET":
                    return edtVerdichtet.EditValue;

                case "SALDOVORTRAGKISS":
                    return edtSaldovortragKiss.EditValue;

                case "SALDOVORTRAGFREMDSYSTEM":
                    return edtSaldovortragFremdsystem.EditValue;

                case "BETRAEGEANPASSEN":
                    return edtBetraegeAnpassen.EditValue;

                case "FALEISTUNGIDSLIST":
                    return GetFaLeistungIDList();
            }

            return base.GetContextValue(fieldName);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtPersonen.EnableCheckedLookup = true;

            edtZeitraum.EditValue = 1;
            edtBetraegeAnpassen.Checked = false;
            edtVerdichtet.Checked = true;
            edtSaldovortragKiss.Checked = true;
            edtSaldovortragFremdsystem.Checked = true;
        }

        protected override void RunSearch()
        {
            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue) && edtDatumVon.DateTime > edtDatumBis.DateTime)
            {
                KissMsg.ShowInfo("Das 'von-Datum' muss kleiner sein als das 'bis-Datum'");
                throw new KissCancelException("'Verwendungsperiode von' muss kleiner sein als 'Verwendungsperiode bis'");
            }

            string laList = GetLaList();
            string faLeistungIDList = GetFaLeistungIDList();

            kissSearch.SelectParameters = new[]
                                          {
                                              _baPersonID,
                                              edtPersonen.EditValue, //string containing a comma separated list of BaPersonIDs
                                              edtZeitraum.EditValue,
                                              edtDatumVon.EditValue,
                                              edtDatumBis.EditValue,
                                              laList,
                                              edtVerdichtet.EditValue,
                                              edtBetraegeAnpassen.EditValue,
                                              faLeistungIDList,
                                              false, // alle Klienten
                                              false, // neue Seite
                                              edtSaldovortragKiss.EditValue,
                                              edtSaldovortragFremdsystem.EditValue
                                          };

            base.RunSearch();
        }

        private string GetFaLeistungIDList()
        {
            var faLeistungIDList = DBUtil.ExecuteScalarSQL(@"SELECT dbo.ConcDistinct(FaLeistungID)
                                                             FROM FaLeistung
                                                             WHERE ModulID = 3
                                                               AND BaPersonID = {0}", _baPersonID) as string;
            return faLeistungIDList;
        }

        #endregion

        #region Private Methods

        private string GetLaList()
        {
            string laList = "";
            try
            {
                foreach (DataRow row in qryZugeteilt.DataTable.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (laList != "") laList += ",";
                        laList += row["KontoNr"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                //logger.DebugFormat("crashed while creating list. See exception: {0} ", e.ToString());
            }

            return laList;
        }

        #endregion

        #endregion
    }
}