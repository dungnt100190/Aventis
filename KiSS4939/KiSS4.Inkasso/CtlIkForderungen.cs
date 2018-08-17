using System;
using System.ComponentModel;
using System.Drawing;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkForderungen : KissUserControl
    {
        private int _faLeistungId;

        private int _faProzessCode;

        public CtlIkForderungen()
        {
            InitializeComponent();
        }

        public override KissUserControl DetailControl
        {
            get
            {
                if (tabIkForderung.SelectedTab.Controls.Count == 1 &&
                    tabIkForderung.SelectedTab.Controls[0] is KissUserControl)
                {
                    return (KissUserControl)tabIkForderung.SelectedTab.Controls[0];
                }

                return base.DetailControl;
            }
        }

        public void Init(string name, Image titleImage, int leistungId, int prozessCode)
        {
            picTitel.Image = titleImage;
            lblTitel.Text = name;
            _faLeistungId = leistungId;
            _faProzessCode = prozessCode;
            colForderungPeriodisch.ColumnEdit = grdIkForderung.GetLOVLookUpEdit("IkForderungPeriodisch");

            // Daten anzeigen:
            qryIkForderung.Fill(_faLeistungId);

            // Auswahl Person:
            qryPerson.Fill(_faLeistungId);
            edtBaPersonID.Properties.DataSource = qryPerson;

            // Register: Einmalige Forderungen:
            ctlIkMonatszahlenEinmalig.Init(0, _faLeistungId, 0, true, false);

            //Felder ausblenden für Nachlass
            tbpPeriodischeForderungen.HideTab = Utils.ConvertToInt(_faProzessCode) == 406 || Utils.ConvertToInt(_faProzessCode) == 407 || Utils.ConvertToInt(_faProzessCode) == 403;

            edtForderungPeriodisch.LOVFilter = _faProzessCode.ToString();
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            if (param == null || param.Count < 1)
            {
                return true;
            }

            switch (param["Action"] as string)
            {
                case "Refresh": qryIkForderung.Refresh(); return true;
            }

            return false;
        }

        private void qryIkForderung_AfterFill(object sender, EventArgs e)
        {
            if (qryIkForderung.Count == 0)
            {
                qryIkForderung_PositionChanged(sender, e);
            }
        }

        private void qryIkForderung_AfterInsert(object sender, EventArgs e)
        {
            qryIkForderung["FaLeistungID"] = _faLeistungId;
        }

        private void qryIkForderung_AfterPost(object sender, EventArgs e)
        {
            try
            {
                DBUtil.OpenSQL("EXEC dbo.spIkMonatszahlen_DetailAll {0}, NULL, 1", _faLeistungId);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryIkForderung_BeforePost(object sender, EventArgs e)
        {
            // Mussfelder checken: Codes:
            DBUtil.CheckNotNullField(edtForderungPeriodisch, lblForderungPeriodisch.Text);
            DBUtil.CheckNotNullField(edtDatumAnpassenAb, lblDatumAnpassenAb.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
        }

        private void qryIkForderung_PositionChanged(object sender, EventArgs e)
        {
            qryIkForderung.EnableBoundFields(qryIkForderung.Count > 0 && qryIkForderung.CanUpdate);
        }

        private void tabIkForderung_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            // Mussfelder checken: Codes:
            //DBUtil.CheckNotNullField(edtForderungPeriodisch, lblForderungPeriodisch.Text);
            //DBUtil.CheckNotNullField(edtDatumAnpassenAb, lblDatumAnpassenAb.Text);
            //DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            //qryIkForderung["Person"] = edtBaPersonID.GetDisplayText(edtBaPersonID.EditValue);
        }
    }
}