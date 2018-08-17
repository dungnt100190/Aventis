using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class DlgWhKlientenkontoabrechnungLAAusschluss : KissDialog
    {
        #region Constructors

        public DlgWhKlientenkontoabrechnungLAAusschluss()
        {
            InitializeComponent();
            qryGueltigkeitsBereich.Fill();

            pklInstTypen.ButtonSelectAll.Visible = true;
            pklInstTypen.ButtonRemoveAll.Visible = true;
            pklInstTypen.ColumnsByFieldNameAndCaptionForSourceGrid = new Dictionary<string, string> { { "Name", "Verfügbare Leistungsart" } };
            pklInstTypen.ColumnsByFieldNameAndCaptionForTargetGrid = new Dictionary<string, string> { { "Name", "Zugeteilte Leistungsart" } };

            pklInstTypen.DataSourceOfSourceGrid = qryVerfuegbar;
            pklInstTypen.DataSourceOfTargetGrid = qryZugeteilt;
        }

        #endregion

        #region Properties

        public string AusgeschlosseneLAList
        {
            set
            {
                //Dialog initialisieren, als ob value die erwünschten LAs enthalten würde. 
                //Dies führt allerdings dazu, dass die beiden Queries vertauscht werden müssen.
                qryVerfuegbar.Fill(qryVerfuegbar.SelectStatement, value);
                qryZugeteilt.Fill(qryZugeteilt.SelectStatement, value);

                pklInstTypen.DataSourceOfSourceGrid = qryZugeteilt;
                pklInstTypen.DataSourceOfTargetGrid = qryVerfuegbar;

                pklInstTypen.UpdateRowFilterForSource();
            }
        }

        public string LAList
        {
            get { return pklInstTypen.SelectedIds; }
            set
            {
                qryVerfuegbar.Fill(qryVerfuegbar.SelectStatement, value);
                qryZugeteilt.Fill(qryZugeteilt.SelectStatement, value);
                pklInstTypen.UpdateRowFilterForSource();
            }
        }

        public new string Name
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        public string SelectedLAList
        {
            get { return KissPickList.GetIdsAsCsvString(pklInstTypen.DataSourceOfTargetGrid, "KontoNr"); }
        }

        #endregion

        #region EventHandlers

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAnfragen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void qryZugeteilt_AfterFill(object sender, EventArgs e)
        {
            pklInstTypen.UpdateRowFilterForSource();
        }

        #endregion

        #region Methods

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion

        #endregion
    }
}