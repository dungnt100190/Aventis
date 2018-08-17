namespace KiSS4.BDE
{
    partial class DlgUserBDEDetails
    {
        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgUserBDEDetails));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTopInfo = new System.Windows.Forms.Panel();
            this.lblUserName = new KiSS4.Gui.KissLabel();
            this.lblUserNameLbl = new KiSS4.Gui.KissLabel();
            this.panTopWarning = new System.Windows.Forms.Panel();
            this.picWarningIcon = new System.Windows.Forms.PictureBox();
            this.lblWarningText = new KiSS4.Gui.KissLabel();
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnCloseDialog = new KiSS4.Gui.KissButton();
            this.tabUserBDEDetails = new KiSS4.Gui.KissTabControlEx();
            this.tpgFerienKuerzungen = new SharpLibrary.WinControls.TabPageEx();
            this.lblFerienKuerzungenFerienkuerzungStdUnit = new KiSS4.Gui.KissLabel();
            this.edtFerienKuerzungenFerienkuerzungStd = new KiSS4.Gui.KissCalcEdit();
            this.qryBDEFerienKuerzungen_XUser = new KiSS4.DB.SqlQuery(this.components);
            this.lblFerienKuerzungenFerienkuerzungStd = new KiSS4.Gui.KissLabel();
            this.edtFerienKuerzungenJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblFerienKuerzungenJahr = new KiSS4.Gui.KissLabel();
            this.grdBDEFerienKuerzungen_XUser = new KiSS4.Gui.KissGrid();
            this.grvBDEFerienKuerzungen_XUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFerienKuerzungenJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFerienKuerzungenFerienkuerzungStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFerienKuerzungenManualEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgSollProJahr = new SharpLibrary.WinControls.TabPageEx();
            this.btnTotalAufMonateVerteilen = new KiSS4.Gui.KissButton();
            this.lblSollProJahrTotalStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrTotalStd = new KiSS4.Gui.KissCalcEdit();
            this.qryBDESollStundenProJahr_XUser = new KiSS4.DB.SqlQuery(this.components);
            this.lblSollProJahrTotalStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrInfo = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrDezemberStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrDezemberStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrDezemberStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrNovemberStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrNovemberStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrNovemberStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrOktoberStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrOktoberStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrOktoberStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrSeptemberStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrSeptemberStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrSeptemberStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrAugustStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrAugustStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrAugustStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJuliStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrJuliStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrJuliStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJuniStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrJuniStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrJuniStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrMaiStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrMaiStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrMaiStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrAprilStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrAprilStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrAprilStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrMaerzStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrMaerzStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrMaerzStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrFebruarStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrFebruarStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrFebruarStd = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJanuarStdUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrJanuarStd = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrJanuarStd = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblSollProJahrJahr = new KiSS4.Gui.KissLabel();
            this.grdBDESollStundenProJahr_XUser = new KiSS4.Gui.KissGrid();
            this.grvBDESollStundenProJahr_XUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSollProJahrJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrJanuarStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrFebruarStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrMaerzStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrAprilStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrMai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrJuniStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrJuliStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrAugustStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrSeptemberStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrOktoberStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrNovemberStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrDezemberStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrTotalStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProJahrManualEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgSollProTag = new SharpLibrary.WinControls.TabPageEx();
            this.lblSollProTagSollStundenProTagUnit = new KiSS4.Gui.KissLabel();
            this.edtSollProTagSollStundenProTag = new KiSS4.Gui.KissCalcEdit();
            this.qryBDESollProTag_XUser = new KiSS4.DB.SqlQuery(this.components);
            this.lblSollProTagSollStundenProTag = new KiSS4.Gui.KissLabel();
            this.edtSollProTagDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSollProTagDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSollProTagDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSollProTagDatumVon = new KiSS4.Gui.KissLabel();
            this.grdBDESollProTag_XUser = new KiSS4.Gui.KissGrid();
            this.grvBDESollProTag_XUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSollProTagBDESollProTag_XUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProTagDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProTagDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProTagSollStundenProTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollProTagManualEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgPensum = new SharpLibrary.WinControls.TabPageEx();
            this.lblPensumPensumProzentUnit = new KiSS4.Gui.KissLabel();
            this.edtPensumPensumProzent = new KiSS4.Gui.KissCalcEdit();
            this.qryBDEPensum_XUser = new KiSS4.DB.SqlQuery(this.components);
            this.lblPensumPensumProzent = new KiSS4.Gui.KissLabel();
            this.edtPensumDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblPensumDatumBis = new KiSS4.Gui.KissLabel();
            this.edtPensumDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblPensumDatumVon = new KiSS4.Gui.KissLabel();
            this.grdBDEPensum_XUser = new KiSS4.Gui.KissGrid();
            this.grvBDEPensum_XUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPensumBDEPensum_XUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensumDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensumDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensumPensumProzent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensumManualEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgFerienAnspruch = new SharpLibrary.WinControls.TabPageEx();
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit = new KiSS4.Gui.KissLabel();
            this.edtFerienAnspruchFerienAnspruchStdProJahr = new KiSS4.Gui.KissCalcEdit();
            this.qryBDEFerienAnspruch_XUser = new KiSS4.DB.SqlQuery(this.components);
            this.lblFerienAnspruchFerienAnspruchStdProJahr = new KiSS4.Gui.KissLabel();
            this.edtFerienAnspruchDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblFerienAnspruchDatumBis = new KiSS4.Gui.KissLabel();
            this.edtFerienAnspruchDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblFerienAnspruchDatumVon = new KiSS4.Gui.KissLabel();
            this.edtFerienAnspruchJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblFerienAnspruchJahr = new KiSS4.Gui.KissLabel();
            this.grdBDEFerienAnspruch_XUser = new KiSS4.Gui.KissGrid();
            this.grvBDEFerienAnspruch_XUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFerienAnspruchBDEFerienAnspruch_XUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFerienAnspruchJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFerienAnspruchDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFerienAnspruchDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFerienAnspruchFerienAnspruchStdProJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFerienAnspruchManualEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAusbezahlteUeberstunden = new SharpLibrary.WinControls.TabPageEx();
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit = new KiSS4.Gui.KissLabel();
            this.edtAusbezahlteUeberstundenAusbezahlteStd = new KiSS4.Gui.KissCalcEdit();
            this.qryBDEAusbezahlteUeberstunden_XUser = new KiSS4.DB.SqlQuery(this.components);
            this.lblAusbezahlteUeberstundenAusbezahlteStd = new KiSS4.Gui.KissLabel();
            this.edtAusbezahlteUeberstundenDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblAusbezahlteUeberstundenDatumBis = new KiSS4.Gui.KissLabel();
            this.edtAusbezahlteUeberstundenDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblAusbezahlteUeberstundenDatumVon = new KiSS4.Gui.KissLabel();
            this.edtAusbezahlteUeberstundenJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblAusbezahlteUeberstundenJahr = new KiSS4.Gui.KissLabel();
            this.grdBDEAusbezahlteUeberstunden_XUser = new KiSS4.Gui.KissGrid();
            this.grvBDEAusbezahlteUeberstunden_XUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbezahlteUeberstundenJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbezahlteUeberstundenDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbezahlteUeberstundenDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbezahlteUeberstundenAusbezahlteStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbezahlteUeberstundenManualEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panTopInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserNameLbl)).BeginInit();
            this.panTopWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarningIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarningText)).BeginInit();
            this.panBottom.SuspendLayout();
            this.tabUserBDEDetails.SuspendLayout();
            this.tpgFerienKuerzungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienKuerzungenFerienkuerzungStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienKuerzungenFerienkuerzungStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEFerienKuerzungen_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienKuerzungenFerienkuerzungStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienKuerzungenJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienKuerzungenJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEFerienKuerzungen_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEFerienKuerzungen_XUser)).BeginInit();
            this.tpgSollProJahr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrTotalStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrTotalStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDESollStundenProJahr_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrTotalStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezemberStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrDezemberStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezemberStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovemberStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrNovemberStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovemberStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktoberStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrOktoberStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktoberStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptemberStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrSeptemberStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptemberStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugustStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrAugustStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugustStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuliStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJuliStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuliStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuniStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJuniStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuniStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaiStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrMaiStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaiStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAprilStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrAprilStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAprilStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerzStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrMaerzStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerzStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruarStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrFebruarStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruarStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuarStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJanuarStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuarStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDESollStundenProJahr_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDESollStundenProJahr_XUser)).BeginInit();
            this.tpgSollProTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagSollStundenProTagUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProTagSollStundenProTag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDESollProTag_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagSollStundenProTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProTagDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProTagDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDESollProTag_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDESollProTag_XUser)).BeginInit();
            this.tpgPensum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumPensumProzentUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumPensumProzent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEPensum_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumPensumProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEPensum_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEPensum_XUser)).BeginInit();
            this.tpgFerienAnspruch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchFerienAnspruchStdProJahrUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEFerienAnspruch_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchFerienAnspruchStdProJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEFerienAnspruch_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEFerienAnspruch_XUser)).BeginInit();
            this.tpgAusbezahlteUeberstunden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenAusbezahlteStdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEAusbezahlteUeberstunden_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenAusbezahlteStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEAusbezahlteUeberstunden_XUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEAusbezahlteUeberstunden_XUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panTopInfo
            // 
            this.panTopInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTopInfo.Controls.Add(this.lblUserName);
            this.panTopInfo.Controls.Add(this.lblUserNameLbl);
            this.panTopInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopInfo.Location = new System.Drawing.Point(0, 0);
            this.panTopInfo.Name = "panTopInfo";
            this.panTopInfo.Size = new System.Drawing.Size(894, 30);
            this.panTopInfo.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblUserName.Location = new System.Drawing.Point(170, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(710, 16);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "<Name>, <Vorname> (Nr. <UserID>)";
            this.lblUserName.UseCompatibleTextRendering = true;
            // 
            // lblUserNameLbl
            // 
            this.lblUserNameLbl.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblUserNameLbl.Location = new System.Drawing.Point(12, 7);
            this.lblUserNameLbl.Name = "lblUserNameLbl";
            this.lblUserNameLbl.Size = new System.Drawing.Size(152, 16);
            this.lblUserNameLbl.TabIndex = 0;
            this.lblUserNameLbl.Text = "Aktueller Benutzer:";
            this.lblUserNameLbl.UseCompatibleTextRendering = true;
            // 
            // panTopWarning
            // 
            this.panTopWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTopWarning.Controls.Add(this.picWarningIcon);
            this.panTopWarning.Controls.Add(this.lblWarningText);
            this.panTopWarning.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopWarning.Location = new System.Drawing.Point(0, 30);
            this.panTopWarning.Name = "panTopWarning";
            this.panTopWarning.Size = new System.Drawing.Size(894, 60);
            this.panTopWarning.TabIndex = 1;
            // 
            // picWarningIcon
            // 
            this.picWarningIcon.Location = new System.Drawing.Point(12, 12);
            this.picWarningIcon.Name = "picWarningIcon";
            this.picWarningIcon.Size = new System.Drawing.Size(32, 32);
            this.picWarningIcon.TabIndex = 0;
            this.picWarningIcon.TabStop = false;
            // 
            // lblWarningText
            // 
            this.lblWarningText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarningText.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblWarningText.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblWarningText.Location = new System.Drawing.Point(50, 9);
            this.lblWarningText.Name = "lblWarningText";
            this.lblWarningText.Size = new System.Drawing.Size(830, 40);
            this.lblWarningText.TabIndex = 0;
            this.lblWarningText.Text = resources.GetString("lblWarningText.Text");
            this.lblWarningText.UseCompatibleTextRendering = true;
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.btnCloseDialog);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 525);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(894, 37);
            this.panBottom.TabIndex = 2;
            // 
            // btnCloseDialog
            // 
            this.btnCloseDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDialog.Location = new System.Drawing.Point(792, 1);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(90, 24);
            this.btnCloseDialog.TabIndex = 0;
            this.btnCloseDialog.Text = "&Schliessen";
            this.btnCloseDialog.UseCompatibleTextRendering = true;
            this.btnCloseDialog.UseVisualStyleBackColor = true;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnCloseDialog_Click);
            // 
            // tabUserBDEDetails
            // 
            this.tabUserBDEDetails.Controls.Add(this.tpgFerienKuerzungen);
            this.tabUserBDEDetails.Controls.Add(this.tpgSollProJahr);
            this.tabUserBDEDetails.Controls.Add(this.tpgSollProTag);
            this.tabUserBDEDetails.Controls.Add(this.tpgPensum);
            this.tabUserBDEDetails.Controls.Add(this.tpgFerienAnspruch);
            this.tabUserBDEDetails.Controls.Add(this.tpgAusbezahlteUeberstunden);
            this.tabUserBDEDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserBDEDetails.Location = new System.Drawing.Point(0, 90);
            this.tabUserBDEDetails.Name = "tabUserBDEDetails";
            this.tabUserBDEDetails.SelectedTabIndex = 2;
            this.tabUserBDEDetails.ShowFixedWidthTooltip = true;
            this.tabUserBDEDetails.Size = new System.Drawing.Size(894, 435);
            this.tabUserBDEDetails.TabIndex = 3;
            this.tabUserBDEDetails.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPensum,
            this.tpgSollProTag,
            this.tpgSollProJahr,
            this.tpgFerienAnspruch,
            this.tpgFerienKuerzungen,
            this.tpgAusbezahlteUeberstunden});
            this.tabUserBDEDetails.TabsLineColor = System.Drawing.Color.Black;
            this.tabUserBDEDetails.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabUserBDEDetails.Text = "kissTabControlEx1";
            this.tabUserBDEDetails.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabUserBDEDetails_SelectedTabChanged);
            this.tabUserBDEDetails.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabUserBDEDetails_SelectedTabChanging);
            // 
            // tpgFerienKuerzungen
            // 
            this.tpgFerienKuerzungen.Controls.Add(this.lblFerienKuerzungenFerienkuerzungStdUnit);
            this.tpgFerienKuerzungen.Controls.Add(this.edtFerienKuerzungenFerienkuerzungStd);
            this.tpgFerienKuerzungen.Controls.Add(this.lblFerienKuerzungenFerienkuerzungStd);
            this.tpgFerienKuerzungen.Controls.Add(this.edtFerienKuerzungenJahr);
            this.tpgFerienKuerzungen.Controls.Add(this.lblFerienKuerzungenJahr);
            this.tpgFerienKuerzungen.Controls.Add(this.grdBDEFerienKuerzungen_XUser);
            this.tpgFerienKuerzungen.Location = new System.Drawing.Point(6, 6);
            this.tpgFerienKuerzungen.Name = "tpgFerienKuerzungen";
            this.tpgFerienKuerzungen.Size = new System.Drawing.Size(882, 397);
            this.tpgFerienKuerzungen.TabIndex = 4;
            this.tpgFerienKuerzungen.Title = "Ferien Zugaben/Kürzungen";
            // 
            // lblFerienKuerzungenFerienkuerzungStdUnit
            // 
            this.lblFerienKuerzungenFerienkuerzungStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienKuerzungenFerienkuerzungStdUnit.Location = new System.Drawing.Point(216, 364);
            this.lblFerienKuerzungenFerienkuerzungStdUnit.Name = "lblFerienKuerzungenFerienkuerzungStdUnit";
            this.lblFerienKuerzungenFerienkuerzungStdUnit.Size = new System.Drawing.Size(230, 24);
            this.lblFerienKuerzungenFerienkuerzungStdUnit.TabIndex = 5;
            this.lblFerienKuerzungenFerienkuerzungStdUnit.Text = "Std. ([+]=Zugaben, [-]=Kürzungen)";
            this.lblFerienKuerzungenFerienkuerzungStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtFerienKuerzungenFerienkuerzungStd
            // 
            this.edtFerienKuerzungenFerienkuerzungStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFerienKuerzungenFerienkuerzungStd.DataMember = "FerienkuerzungStd";
            this.edtFerienKuerzungenFerienkuerzungStd.DataSource = this.qryBDEFerienKuerzungen_XUser;
            this.edtFerienKuerzungenFerienkuerzungStd.Location = new System.Drawing.Point(136, 364);
            this.edtFerienKuerzungenFerienkuerzungStd.Name = "edtFerienKuerzungenFerienkuerzungStd";
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Appearance.Options.UseFont = true;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.DisplayFormat.FormatString = "###0.0000";
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.EditFormat.FormatString = "###0.####";
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Mask.EditMask = "###0.####";
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.MaxLength = 2;
            this.edtFerienKuerzungenFerienkuerzungStd.Properties.Precision = 4;
            this.edtFerienKuerzungenFerienkuerzungStd.Size = new System.Drawing.Size(74, 24);
            this.edtFerienKuerzungenFerienkuerzungStd.TabIndex = 4;
            // 
            // qryBDEFerienKuerzungen_XUser
            // 
            this.qryBDEFerienKuerzungen_XUser.HostControl = this;
            this.qryBDEFerienKuerzungen_XUser.TableName = "BDEFerienKuerzungen_XUser";
            this.qryBDEFerienKuerzungen_XUser.BeforePost += new System.EventHandler(this.qryBDEFerienKuerzungen_XUser_BeforePost);
            this.qryBDEFerienKuerzungen_XUser.AfterPost += new System.EventHandler(this.qryBDEFerienKuerzungen_XUser_AfterPost);
            this.qryBDEFerienKuerzungen_XUser.PositionChanged += new System.EventHandler(this.qryBDEFerienKuerzungen_XUser_PositionChanged);
            // 
            // lblFerienKuerzungenFerienkuerzungStd
            // 
            this.lblFerienKuerzungenFerienkuerzungStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienKuerzungenFerienkuerzungStd.Location = new System.Drawing.Point(6, 364);
            this.lblFerienKuerzungenFerienkuerzungStd.Name = "lblFerienKuerzungenFerienkuerzungStd";
            this.lblFerienKuerzungenFerienkuerzungStd.Size = new System.Drawing.Size(124, 24);
            this.lblFerienKuerzungenFerienkuerzungStd.TabIndex = 3;
            this.lblFerienKuerzungenFerienkuerzungStd.Text = "Zugaben/Kürzungen";
            this.lblFerienKuerzungenFerienkuerzungStd.UseCompatibleTextRendering = true;
            // 
            // edtFerienKuerzungenJahr
            // 
            this.edtFerienKuerzungenJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFerienKuerzungenJahr.DataMember = "Jahr";
            this.edtFerienKuerzungenJahr.DataSource = this.qryBDEFerienKuerzungen_XUser;
            this.edtFerienKuerzungenJahr.Location = new System.Drawing.Point(136, 334);
            this.edtFerienKuerzungenJahr.Name = "edtFerienKuerzungenJahr";
            this.edtFerienKuerzungenJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFerienKuerzungenJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFerienKuerzungenJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFerienKuerzungenJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFerienKuerzungenJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFerienKuerzungenJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFerienKuerzungenJahr.Properties.Appearance.Options.UseFont = true;
            this.edtFerienKuerzungenJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFerienKuerzungenJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFerienKuerzungenJahr.Properties.DisplayFormat.FormatString = "0000";
            this.edtFerienKuerzungenJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienKuerzungenJahr.Properties.EditFormat.FormatString = "0000";
            this.edtFerienKuerzungenJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienKuerzungenJahr.Properties.Mask.EditMask = "0000";
            this.edtFerienKuerzungenJahr.Properties.MaxLength = 2;
            this.edtFerienKuerzungenJahr.Properties.Precision = 0;
            this.edtFerienKuerzungenJahr.Size = new System.Drawing.Size(74, 24);
            this.edtFerienKuerzungenJahr.TabIndex = 2;
            // 
            // lblFerienKuerzungenJahr
            // 
            this.lblFerienKuerzungenJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienKuerzungenJahr.Location = new System.Drawing.Point(7, 334);
            this.lblFerienKuerzungenJahr.Name = "lblFerienKuerzungenJahr";
            this.lblFerienKuerzungenJahr.Size = new System.Drawing.Size(123, 24);
            this.lblFerienKuerzungenJahr.TabIndex = 1;
            this.lblFerienKuerzungenJahr.Text = "Jahr";
            this.lblFerienKuerzungenJahr.UseCompatibleTextRendering = true;
            // 
            // grdBDEFerienKuerzungen_XUser
            // 
            this.grdBDEFerienKuerzungen_XUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBDEFerienKuerzungen_XUser.DataSource = this.qryBDEFerienKuerzungen_XUser;
            // 
            // 
            // 
            this.grdBDEFerienKuerzungen_XUser.EmbeddedNavigator.Name = "";
            this.grdBDEFerienKuerzungen_XUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDEFerienKuerzungen_XUser.Location = new System.Drawing.Point(3, 3);
            this.grdBDEFerienKuerzungen_XUser.MainView = this.grvBDEFerienKuerzungen_XUser;
            this.grdBDEFerienKuerzungen_XUser.Name = "grdBDEFerienKuerzungen_XUser";
            this.grdBDEFerienKuerzungen_XUser.Size = new System.Drawing.Size(876, 325);
            this.grdBDEFerienKuerzungen_XUser.TabIndex = 0;
            this.grdBDEFerienKuerzungen_XUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDEFerienKuerzungen_XUser});
            // 
            // grvBDEFerienKuerzungen_XUser
            // 
            this.grvBDEFerienKuerzungen_XUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDEFerienKuerzungen_XUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.Empty.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEFerienKuerzungen_XUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.OddRow.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDEFerienKuerzungen_XUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.Row.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.Row.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienKuerzungen_XUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDEFerienKuerzungen_XUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEFerienKuerzungen_XUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDEFerienKuerzungen_XUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDEFerienKuerzungen_XUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFerienKuerzungenJahr,
            this.colFerienKuerzungenFerienkuerzungStd,
            this.colFerienKuerzungenManualEdit});
            this.grvBDEFerienKuerzungen_XUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDEFerienKuerzungen_XUser.GridControl = this.grdBDEFerienKuerzungen_XUser;
            this.grvBDEFerienKuerzungen_XUser.Name = "grvBDEFerienKuerzungen_XUser";
            this.grvBDEFerienKuerzungen_XUser.OptionsBehavior.Editable = false;
            this.grvBDEFerienKuerzungen_XUser.OptionsCustomization.AllowFilter = false;
            this.grvBDEFerienKuerzungen_XUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDEFerienKuerzungen_XUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDEFerienKuerzungen_XUser.OptionsNavigation.UseTabKey = false;
            this.grvBDEFerienKuerzungen_XUser.OptionsView.ColumnAutoWidth = false;
            this.grvBDEFerienKuerzungen_XUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDEFerienKuerzungen_XUser.OptionsView.ShowGroupPanel = false;
            this.grvBDEFerienKuerzungen_XUser.OptionsView.ShowIndicator = false;
            // 
            // colFerienKuerzungenJahr
            // 
            this.colFerienKuerzungenJahr.Caption = "Jahr";
            this.colFerienKuerzungenJahr.FieldName = "Jahr";
            this.colFerienKuerzungenJahr.Name = "colFerienKuerzungenJahr";
            this.colFerienKuerzungenJahr.Visible = true;
            this.colFerienKuerzungenJahr.VisibleIndex = 0;
            this.colFerienKuerzungenJahr.Width = 60;
            // 
            // colFerienKuerzungenFerienkuerzungStd
            // 
            this.colFerienKuerzungenFerienkuerzungStd.Caption = "Zugaben/Kürzungen";
            this.colFerienKuerzungenFerienkuerzungStd.DisplayFormat.FormatString = "###0.0000";
            this.colFerienKuerzungenFerienkuerzungStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFerienKuerzungenFerienkuerzungStd.FieldName = "FerienkuerzungStd";
            this.colFerienKuerzungenFerienkuerzungStd.Name = "colFerienKuerzungenFerienkuerzungStd";
            this.colFerienKuerzungenFerienkuerzungStd.Visible = true;
            this.colFerienKuerzungenFerienkuerzungStd.VisibleIndex = 1;
            this.colFerienKuerzungenFerienkuerzungStd.Width = 140;
            // 
            // colFerienKuerzungenManualEdit
            // 
            this.colFerienKuerzungenManualEdit.Caption = "Manuell";
            this.colFerienKuerzungenManualEdit.FieldName = "ManualEdit";
            this.colFerienKuerzungenManualEdit.Name = "colFerienKuerzungenManualEdit";
            this.colFerienKuerzungenManualEdit.Visible = true;
            this.colFerienKuerzungenManualEdit.VisibleIndex = 2;
            this.colFerienKuerzungenManualEdit.Width = 60;
            // 
            // tpgSollProJahr
            // 
            this.tpgSollProJahr.Controls.Add(this.btnTotalAufMonateVerteilen);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrTotalStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrTotalStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrTotalStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrInfo);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrDezemberStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrDezemberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrDezemberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrNovemberStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrNovemberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrNovemberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrOktoberStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrOktoberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrOktoberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrSeptemberStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrSeptemberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrSeptemberStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrAugustStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrAugustStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrAugustStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJuliStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrJuliStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJuliStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJuniStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrJuniStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJuniStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrMaiStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrMaiStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrMaiStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrAprilStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrAprilStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrAprilStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrMaerzStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrMaerzStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrMaerzStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrFebruarStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrFebruarStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrFebruarStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJanuarStdUnit);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrJanuarStd);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJanuarStd);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrJahr);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJahr);
            this.tpgSollProJahr.Controls.Add(this.grdBDESollStundenProJahr_XUser);
            this.tpgSollProJahr.Location = new System.Drawing.Point(6, 6);
            this.tpgSollProJahr.Name = "tpgSollProJahr";
            this.tpgSollProJahr.Size = new System.Drawing.Size(882, 397);
            this.tpgSollProJahr.TabIndex = 2;
            this.tpgSollProJahr.Title = "Soll pro Jahr";
            // 
            // btnTotalAufMonateVerteilen
            // 
            this.btnTotalAufMonateVerteilen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTotalAufMonateVerteilen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTotalAufMonateVerteilen.Location = new System.Drawing.Point(690, 244);
            this.btnTotalAufMonateVerteilen.Name = "btnTotalAufMonateVerteilen";
            this.btnTotalAufMonateVerteilen.Size = new System.Drawing.Size(189, 24);
            this.btnTotalAufMonateVerteilen.TabIndex = 47;
            this.btnTotalAufMonateVerteilen.Text = "Total auf Monate verteilen";
            this.btnTotalAufMonateVerteilen.UseVisualStyleBackColor = false;
            this.btnTotalAufMonateVerteilen.Click += new System.EventHandler(this.btnTotalAufMonateVerteilen_Click);
            // 
            // lblSollProJahrTotalStdUnit
            // 
            this.lblSollProJahrTotalStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrTotalStdUnit.Location = new System.Drawing.Point(609, 244);
            this.lblSollProJahrTotalStdUnit.Name = "lblSollProJahrTotalStdUnit";
            this.lblSollProJahrTotalStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrTotalStdUnit.TabIndex = 46;
            this.lblSollProJahrTotalStdUnit.Text = "Std.";
            // 
            // edtSollProJahrTotalStd
            // 
            this.edtSollProJahrTotalStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrTotalStd.DataMember = "TotalStd";
            this.edtSollProJahrTotalStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrTotalStd.Location = new System.Drawing.Point(528, 244);
            this.edtSollProJahrTotalStd.Name = "edtSollProJahrTotalStd";
            this.edtSollProJahrTotalStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrTotalStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrTotalStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrTotalStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrTotalStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrTotalStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrTotalStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrTotalStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrTotalStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrTotalStd.Properties.DisplayFormat.FormatString = "###0.0000";
            this.edtSollProJahrTotalStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrTotalStd.Properties.EditFormat.FormatString = "###0.####";
            this.edtSollProJahrTotalStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrTotalStd.Properties.Mask.EditMask = "###0.####";
            this.edtSollProJahrTotalStd.Properties.MaxLength = 4;
            this.edtSollProJahrTotalStd.Properties.Precision = 4;
            this.edtSollProJahrTotalStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrTotalStd.TabIndex = 45;
            // 
            // qryBDESollStundenProJahr_XUser
            // 
            this.qryBDESollStundenProJahr_XUser.HostControl = this;
            this.qryBDESollStundenProJahr_XUser.TableName = "BDESollStundenProJahr_XUser";
            this.qryBDESollStundenProJahr_XUser.BeforePost += new System.EventHandler(this.qryBDESollStundenProJahr_XUser_BeforePost);
            this.qryBDESollStundenProJahr_XUser.AfterPost += new System.EventHandler(this.qryBDESollStundenProJahr_XUser_AfterPost);
            this.qryBDESollStundenProJahr_XUser.PositionChanged += new System.EventHandler(this.qryBDESollStundenProJahr_XUser_PositionChanged);
            // 
            // lblSollProJahrTotalStd
            // 
            this.lblSollProJahrTotalStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrTotalStd.Location = new System.Drawing.Point(454, 244);
            this.lblSollProJahrTotalStd.Name = "lblSollProJahrTotalStd";
            this.lblSollProJahrTotalStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrTotalStd.TabIndex = 44;
            this.lblSollProJahrTotalStd.Text = "Total";
            // 
            // lblSollProJahrInfo
            // 
            this.lblSollProJahrInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrInfo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrInfo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrInfo.Location = new System.Drawing.Point(690, 279);
            this.lblSollProJahrInfo.Name = "lblSollProJahrInfo";
            this.lblSollProJahrInfo.Size = new System.Drawing.Size(189, 109);
            this.lblSollProJahrInfo.TabIndex = 39;
            this.lblSollProJahrInfo.Text = "Hinweis:\r\nDie Soll-Stunden pro Monat sind auf der Basis von 100%-Beschäftigungsgr" +
    "ad ausgelegt und werden anschliessend vom System automatisch berechnet.";
            this.lblSollProJahrInfo.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrDezemberStdUnit
            // 
            this.lblSollProJahrDezemberStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrDezemberStdUnit.Location = new System.Drawing.Point(609, 364);
            this.lblSollProJahrDezemberStdUnit.Name = "lblSollProJahrDezemberStdUnit";
            this.lblSollProJahrDezemberStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrDezemberStdUnit.TabIndex = 38;
            this.lblSollProJahrDezemberStdUnit.Text = "Std.";
            this.lblSollProJahrDezemberStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrDezemberStd
            // 
            this.edtSollProJahrDezemberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrDezemberStd.DataMember = "DezemberStd";
            this.edtSollProJahrDezemberStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrDezemberStd.Location = new System.Drawing.Point(529, 364);
            this.edtSollProJahrDezemberStd.Name = "edtSollProJahrDezemberStd";
            this.edtSollProJahrDezemberStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrDezemberStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrDezemberStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrDezemberStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrDezemberStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrDezemberStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrDezemberStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrDezemberStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrDezemberStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrDezemberStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrDezemberStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrDezemberStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrDezemberStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrDezemberStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrDezemberStd.Properties.MaxLength = 2;
            this.edtSollProJahrDezemberStd.Properties.Precision = 4;
            this.edtSollProJahrDezemberStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrDezemberStd.TabIndex = 37;
            // 
            // lblSollProJahrDezemberStd
            // 
            this.lblSollProJahrDezemberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrDezemberStd.Location = new System.Drawing.Point(454, 364);
            this.lblSollProJahrDezemberStd.Name = "lblSollProJahrDezemberStd";
            this.lblSollProJahrDezemberStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrDezemberStd.TabIndex = 36;
            this.lblSollProJahrDezemberStd.Text = "Dezember";
            this.lblSollProJahrDezemberStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrNovemberStdUnit
            // 
            this.lblSollProJahrNovemberStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrNovemberStdUnit.Location = new System.Drawing.Point(609, 334);
            this.lblSollProJahrNovemberStdUnit.Name = "lblSollProJahrNovemberStdUnit";
            this.lblSollProJahrNovemberStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrNovemberStdUnit.TabIndex = 35;
            this.lblSollProJahrNovemberStdUnit.Text = "Std.";
            this.lblSollProJahrNovemberStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrNovemberStd
            // 
            this.edtSollProJahrNovemberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrNovemberStd.DataMember = "NovemberStd";
            this.edtSollProJahrNovemberStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrNovemberStd.Location = new System.Drawing.Point(529, 334);
            this.edtSollProJahrNovemberStd.Name = "edtSollProJahrNovemberStd";
            this.edtSollProJahrNovemberStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrNovemberStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrNovemberStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrNovemberStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrNovemberStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrNovemberStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrNovemberStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrNovemberStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrNovemberStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrNovemberStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrNovemberStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrNovemberStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrNovemberStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrNovemberStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrNovemberStd.Properties.MaxLength = 2;
            this.edtSollProJahrNovemberStd.Properties.Precision = 4;
            this.edtSollProJahrNovemberStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrNovemberStd.TabIndex = 34;
            // 
            // lblSollProJahrNovemberStd
            // 
            this.lblSollProJahrNovemberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrNovemberStd.Location = new System.Drawing.Point(454, 334);
            this.lblSollProJahrNovemberStd.Name = "lblSollProJahrNovemberStd";
            this.lblSollProJahrNovemberStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrNovemberStd.TabIndex = 33;
            this.lblSollProJahrNovemberStd.Text = "November";
            this.lblSollProJahrNovemberStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrOktoberStdUnit
            // 
            this.lblSollProJahrOktoberStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrOktoberStdUnit.Location = new System.Drawing.Point(609, 304);
            this.lblSollProJahrOktoberStdUnit.Name = "lblSollProJahrOktoberStdUnit";
            this.lblSollProJahrOktoberStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrOktoberStdUnit.TabIndex = 32;
            this.lblSollProJahrOktoberStdUnit.Text = "Std.";
            this.lblSollProJahrOktoberStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrOktoberStd
            // 
            this.edtSollProJahrOktoberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrOktoberStd.DataMember = "OktoberStd";
            this.edtSollProJahrOktoberStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrOktoberStd.Location = new System.Drawing.Point(528, 304);
            this.edtSollProJahrOktoberStd.Name = "edtSollProJahrOktoberStd";
            this.edtSollProJahrOktoberStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrOktoberStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrOktoberStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrOktoberStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrOktoberStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrOktoberStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrOktoberStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrOktoberStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrOktoberStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrOktoberStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrOktoberStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrOktoberStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrOktoberStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrOktoberStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrOktoberStd.Properties.MaxLength = 2;
            this.edtSollProJahrOktoberStd.Properties.Precision = 4;
            this.edtSollProJahrOktoberStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrOktoberStd.TabIndex = 31;
            // 
            // lblSollProJahrOktoberStd
            // 
            this.lblSollProJahrOktoberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrOktoberStd.Location = new System.Drawing.Point(454, 304);
            this.lblSollProJahrOktoberStd.Name = "lblSollProJahrOktoberStd";
            this.lblSollProJahrOktoberStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrOktoberStd.TabIndex = 30;
            this.lblSollProJahrOktoberStd.Text = "Oktober";
            this.lblSollProJahrOktoberStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrSeptemberStdUnit
            // 
            this.lblSollProJahrSeptemberStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrSeptemberStdUnit.Location = new System.Drawing.Point(609, 274);
            this.lblSollProJahrSeptemberStdUnit.Name = "lblSollProJahrSeptemberStdUnit";
            this.lblSollProJahrSeptemberStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrSeptemberStdUnit.TabIndex = 29;
            this.lblSollProJahrSeptemberStdUnit.Text = "Std.";
            this.lblSollProJahrSeptemberStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrSeptemberStd
            // 
            this.edtSollProJahrSeptemberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrSeptemberStd.DataMember = "SeptemberStd";
            this.edtSollProJahrSeptemberStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrSeptemberStd.Location = new System.Drawing.Point(528, 274);
            this.edtSollProJahrSeptemberStd.Name = "edtSollProJahrSeptemberStd";
            this.edtSollProJahrSeptemberStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrSeptemberStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrSeptemberStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrSeptemberStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrSeptemberStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrSeptemberStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrSeptemberStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrSeptemberStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrSeptemberStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrSeptemberStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrSeptemberStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrSeptemberStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrSeptemberStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrSeptemberStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrSeptemberStd.Properties.MaxLength = 2;
            this.edtSollProJahrSeptemberStd.Properties.Precision = 4;
            this.edtSollProJahrSeptemberStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrSeptemberStd.TabIndex = 28;
            // 
            // lblSollProJahrSeptemberStd
            // 
            this.lblSollProJahrSeptemberStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrSeptemberStd.Location = new System.Drawing.Point(454, 274);
            this.lblSollProJahrSeptemberStd.Name = "lblSollProJahrSeptemberStd";
            this.lblSollProJahrSeptemberStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrSeptemberStd.TabIndex = 27;
            this.lblSollProJahrSeptemberStd.Text = "September";
            this.lblSollProJahrSeptemberStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrAugustStdUnit
            // 
            this.lblSollProJahrAugustStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrAugustStdUnit.Location = new System.Drawing.Point(385, 364);
            this.lblSollProJahrAugustStdUnit.Name = "lblSollProJahrAugustStdUnit";
            this.lblSollProJahrAugustStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrAugustStdUnit.TabIndex = 26;
            this.lblSollProJahrAugustStdUnit.Text = "Std.";
            this.lblSollProJahrAugustStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrAugustStd
            // 
            this.edtSollProJahrAugustStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrAugustStd.DataMember = "AugustStd";
            this.edtSollProJahrAugustStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrAugustStd.Location = new System.Drawing.Point(305, 364);
            this.edtSollProJahrAugustStd.Name = "edtSollProJahrAugustStd";
            this.edtSollProJahrAugustStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrAugustStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrAugustStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrAugustStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrAugustStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrAugustStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrAugustStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrAugustStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrAugustStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrAugustStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrAugustStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrAugustStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrAugustStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrAugustStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrAugustStd.Properties.MaxLength = 2;
            this.edtSollProJahrAugustStd.Properties.Precision = 4;
            this.edtSollProJahrAugustStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrAugustStd.TabIndex = 25;
            // 
            // lblSollProJahrAugustStd
            // 
            this.lblSollProJahrAugustStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrAugustStd.Location = new System.Drawing.Point(230, 364);
            this.lblSollProJahrAugustStd.Name = "lblSollProJahrAugustStd";
            this.lblSollProJahrAugustStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrAugustStd.TabIndex = 24;
            this.lblSollProJahrAugustStd.Text = "August";
            this.lblSollProJahrAugustStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJuliStdUnit
            // 
            this.lblSollProJahrJuliStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrJuliStdUnit.Location = new System.Drawing.Point(385, 334);
            this.lblSollProJahrJuliStdUnit.Name = "lblSollProJahrJuliStdUnit";
            this.lblSollProJahrJuliStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrJuliStdUnit.TabIndex = 23;
            this.lblSollProJahrJuliStdUnit.Text = "Std.";
            this.lblSollProJahrJuliStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrJuliStd
            // 
            this.edtSollProJahrJuliStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrJuliStd.DataMember = "JuliStd";
            this.edtSollProJahrJuliStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrJuliStd.Location = new System.Drawing.Point(305, 334);
            this.edtSollProJahrJuliStd.Name = "edtSollProJahrJuliStd";
            this.edtSollProJahrJuliStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrJuliStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrJuliStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrJuliStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrJuliStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrJuliStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrJuliStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrJuliStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrJuliStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrJuliStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrJuliStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJuliStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrJuliStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJuliStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrJuliStd.Properties.MaxLength = 2;
            this.edtSollProJahrJuliStd.Properties.Precision = 4;
            this.edtSollProJahrJuliStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrJuliStd.TabIndex = 22;
            // 
            // lblSollProJahrJuliStd
            // 
            this.lblSollProJahrJuliStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrJuliStd.Location = new System.Drawing.Point(230, 334);
            this.lblSollProJahrJuliStd.Name = "lblSollProJahrJuliStd";
            this.lblSollProJahrJuliStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrJuliStd.TabIndex = 21;
            this.lblSollProJahrJuliStd.Text = "Juli";
            this.lblSollProJahrJuliStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJuniStdUnit
            // 
            this.lblSollProJahrJuniStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrJuniStdUnit.Location = new System.Drawing.Point(385, 304);
            this.lblSollProJahrJuniStdUnit.Name = "lblSollProJahrJuniStdUnit";
            this.lblSollProJahrJuniStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrJuniStdUnit.TabIndex = 20;
            this.lblSollProJahrJuniStdUnit.Text = "Std.";
            this.lblSollProJahrJuniStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrJuniStd
            // 
            this.edtSollProJahrJuniStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrJuniStd.DataMember = "JuniStd";
            this.edtSollProJahrJuniStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrJuniStd.Location = new System.Drawing.Point(304, 304);
            this.edtSollProJahrJuniStd.Name = "edtSollProJahrJuniStd";
            this.edtSollProJahrJuniStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrJuniStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrJuniStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrJuniStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrJuniStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrJuniStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrJuniStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrJuniStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrJuniStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrJuniStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrJuniStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJuniStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrJuniStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJuniStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrJuniStd.Properties.MaxLength = 2;
            this.edtSollProJahrJuniStd.Properties.Precision = 4;
            this.edtSollProJahrJuniStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrJuniStd.TabIndex = 19;
            // 
            // lblSollProJahrJuniStd
            // 
            this.lblSollProJahrJuniStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrJuniStd.Location = new System.Drawing.Point(230, 304);
            this.lblSollProJahrJuniStd.Name = "lblSollProJahrJuniStd";
            this.lblSollProJahrJuniStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrJuniStd.TabIndex = 18;
            this.lblSollProJahrJuniStd.Text = "Juni";
            this.lblSollProJahrJuniStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrMaiStdUnit
            // 
            this.lblSollProJahrMaiStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrMaiStdUnit.Location = new System.Drawing.Point(385, 274);
            this.lblSollProJahrMaiStdUnit.Name = "lblSollProJahrMaiStdUnit";
            this.lblSollProJahrMaiStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrMaiStdUnit.TabIndex = 17;
            this.lblSollProJahrMaiStdUnit.Text = "Std.";
            this.lblSollProJahrMaiStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrMaiStd
            // 
            this.edtSollProJahrMaiStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrMaiStd.DataMember = "MaiStd";
            this.edtSollProJahrMaiStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrMaiStd.Location = new System.Drawing.Point(304, 274);
            this.edtSollProJahrMaiStd.Name = "edtSollProJahrMaiStd";
            this.edtSollProJahrMaiStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrMaiStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrMaiStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrMaiStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrMaiStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrMaiStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrMaiStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrMaiStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrMaiStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrMaiStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrMaiStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrMaiStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrMaiStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrMaiStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrMaiStd.Properties.MaxLength = 2;
            this.edtSollProJahrMaiStd.Properties.Precision = 4;
            this.edtSollProJahrMaiStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrMaiStd.TabIndex = 16;
            // 
            // lblSollProJahrMaiStd
            // 
            this.lblSollProJahrMaiStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrMaiStd.Location = new System.Drawing.Point(230, 274);
            this.lblSollProJahrMaiStd.Name = "lblSollProJahrMaiStd";
            this.lblSollProJahrMaiStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrMaiStd.TabIndex = 15;
            this.lblSollProJahrMaiStd.Text = "Mai";
            this.lblSollProJahrMaiStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrAprilStdUnit
            // 
            this.lblSollProJahrAprilStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrAprilStdUnit.Location = new System.Drawing.Point(161, 364);
            this.lblSollProJahrAprilStdUnit.Name = "lblSollProJahrAprilStdUnit";
            this.lblSollProJahrAprilStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrAprilStdUnit.TabIndex = 14;
            this.lblSollProJahrAprilStdUnit.Text = "Std.";
            this.lblSollProJahrAprilStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrAprilStd
            // 
            this.edtSollProJahrAprilStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrAprilStd.DataMember = "AprilStd";
            this.edtSollProJahrAprilStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrAprilStd.Location = new System.Drawing.Point(81, 364);
            this.edtSollProJahrAprilStd.Name = "edtSollProJahrAprilStd";
            this.edtSollProJahrAprilStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrAprilStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrAprilStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrAprilStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrAprilStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrAprilStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrAprilStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrAprilStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrAprilStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrAprilStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrAprilStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrAprilStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrAprilStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrAprilStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrAprilStd.Properties.MaxLength = 2;
            this.edtSollProJahrAprilStd.Properties.Precision = 4;
            this.edtSollProJahrAprilStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrAprilStd.TabIndex = 13;
            // 
            // lblSollProJahrAprilStd
            // 
            this.lblSollProJahrAprilStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrAprilStd.Location = new System.Drawing.Point(6, 364);
            this.lblSollProJahrAprilStd.Name = "lblSollProJahrAprilStd";
            this.lblSollProJahrAprilStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrAprilStd.TabIndex = 12;
            this.lblSollProJahrAprilStd.Text = "April";
            this.lblSollProJahrAprilStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrMaerzStdUnit
            // 
            this.lblSollProJahrMaerzStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrMaerzStdUnit.Location = new System.Drawing.Point(161, 334);
            this.lblSollProJahrMaerzStdUnit.Name = "lblSollProJahrMaerzStdUnit";
            this.lblSollProJahrMaerzStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrMaerzStdUnit.TabIndex = 11;
            this.lblSollProJahrMaerzStdUnit.Text = "Std.";
            this.lblSollProJahrMaerzStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrMaerzStd
            // 
            this.edtSollProJahrMaerzStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrMaerzStd.DataMember = "MaerzStd";
            this.edtSollProJahrMaerzStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrMaerzStd.Location = new System.Drawing.Point(81, 334);
            this.edtSollProJahrMaerzStd.Name = "edtSollProJahrMaerzStd";
            this.edtSollProJahrMaerzStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrMaerzStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrMaerzStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrMaerzStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrMaerzStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrMaerzStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrMaerzStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrMaerzStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrMaerzStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrMaerzStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrMaerzStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrMaerzStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrMaerzStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrMaerzStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrMaerzStd.Properties.MaxLength = 2;
            this.edtSollProJahrMaerzStd.Properties.Precision = 4;
            this.edtSollProJahrMaerzStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrMaerzStd.TabIndex = 10;
            // 
            // lblSollProJahrMaerzStd
            // 
            this.lblSollProJahrMaerzStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrMaerzStd.Location = new System.Drawing.Point(6, 334);
            this.lblSollProJahrMaerzStd.Name = "lblSollProJahrMaerzStd";
            this.lblSollProJahrMaerzStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrMaerzStd.TabIndex = 9;
            this.lblSollProJahrMaerzStd.Text = "März";
            this.lblSollProJahrMaerzStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrFebruarStdUnit
            // 
            this.lblSollProJahrFebruarStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrFebruarStdUnit.Location = new System.Drawing.Point(161, 304);
            this.lblSollProJahrFebruarStdUnit.Name = "lblSollProJahrFebruarStdUnit";
            this.lblSollProJahrFebruarStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrFebruarStdUnit.TabIndex = 8;
            this.lblSollProJahrFebruarStdUnit.Text = "Std.";
            this.lblSollProJahrFebruarStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrFebruarStd
            // 
            this.edtSollProJahrFebruarStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrFebruarStd.DataMember = "FebruarStd";
            this.edtSollProJahrFebruarStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrFebruarStd.Location = new System.Drawing.Point(80, 304);
            this.edtSollProJahrFebruarStd.Name = "edtSollProJahrFebruarStd";
            this.edtSollProJahrFebruarStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrFebruarStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrFebruarStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrFebruarStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrFebruarStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrFebruarStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrFebruarStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrFebruarStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrFebruarStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrFebruarStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrFebruarStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrFebruarStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrFebruarStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrFebruarStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrFebruarStd.Properties.MaxLength = 2;
            this.edtSollProJahrFebruarStd.Properties.Precision = 4;
            this.edtSollProJahrFebruarStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrFebruarStd.TabIndex = 7;
            // 
            // lblSollProJahrFebruarStd
            // 
            this.lblSollProJahrFebruarStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrFebruarStd.Location = new System.Drawing.Point(6, 304);
            this.lblSollProJahrFebruarStd.Name = "lblSollProJahrFebruarStd";
            this.lblSollProJahrFebruarStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrFebruarStd.TabIndex = 6;
            this.lblSollProJahrFebruarStd.Text = "Februar";
            this.lblSollProJahrFebruarStd.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJanuarStdUnit
            // 
            this.lblSollProJahrJanuarStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrJanuarStdUnit.Location = new System.Drawing.Point(161, 274);
            this.lblSollProJahrJanuarStdUnit.Name = "lblSollProJahrJanuarStdUnit";
            this.lblSollProJahrJanuarStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProJahrJanuarStdUnit.TabIndex = 5;
            this.lblSollProJahrJanuarStdUnit.Text = "Std.";
            this.lblSollProJahrJanuarStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrJanuarStd
            // 
            this.edtSollProJahrJanuarStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrJanuarStd.DataMember = "JanuarStd";
            this.edtSollProJahrJanuarStd.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrJanuarStd.Location = new System.Drawing.Point(80, 274);
            this.edtSollProJahrJanuarStd.Name = "edtSollProJahrJanuarStd";
            this.edtSollProJahrJanuarStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrJanuarStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrJanuarStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrJanuarStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrJanuarStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrJanuarStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrJanuarStd.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrJanuarStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrJanuarStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrJanuarStd.Properties.DisplayFormat.FormatString = "##0.0000";
            this.edtSollProJahrJanuarStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJanuarStd.Properties.EditFormat.FormatString = "##0.####";
            this.edtSollProJahrJanuarStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJanuarStd.Properties.Mask.EditMask = "##0.####";
            this.edtSollProJahrJanuarStd.Properties.MaxLength = 2;
            this.edtSollProJahrJanuarStd.Properties.Precision = 4;
            this.edtSollProJahrJanuarStd.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrJanuarStd.TabIndex = 4;
            // 
            // lblSollProJahrJanuarStd
            // 
            this.lblSollProJahrJanuarStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrJanuarStd.Location = new System.Drawing.Point(6, 274);
            this.lblSollProJahrJanuarStd.Name = "lblSollProJahrJanuarStd";
            this.lblSollProJahrJanuarStd.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrJanuarStd.TabIndex = 3;
            this.lblSollProJahrJanuarStd.Text = "Januar";
            this.lblSollProJahrJanuarStd.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrJahr
            // 
            this.edtSollProJahrJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProJahrJahr.DataMember = "Jahr";
            this.edtSollProJahrJahr.DataSource = this.qryBDESollStundenProJahr_XUser;
            this.edtSollProJahrJahr.Location = new System.Drawing.Point(80, 244);
            this.edtSollProJahrJahr.Name = "edtSollProJahrJahr";
            this.edtSollProJahrJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProJahrJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrJahr.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProJahrJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrJahr.Properties.DisplayFormat.FormatString = "0000";
            this.edtSollProJahrJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJahr.Properties.EditFormat.FormatString = "0000";
            this.edtSollProJahrJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProJahrJahr.Properties.Mask.EditMask = "0000";
            this.edtSollProJahrJahr.Properties.MaxLength = 2;
            this.edtSollProJahrJahr.Properties.Precision = 0;
            this.edtSollProJahrJahr.Size = new System.Drawing.Size(74, 24);
            this.edtSollProJahrJahr.TabIndex = 2;
            // 
            // lblSollProJahrJahr
            // 
            this.lblSollProJahrJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProJahrJahr.Location = new System.Drawing.Point(6, 244);
            this.lblSollProJahrJahr.Name = "lblSollProJahrJahr";
            this.lblSollProJahrJahr.Size = new System.Drawing.Size(69, 24);
            this.lblSollProJahrJahr.TabIndex = 1;
            this.lblSollProJahrJahr.Text = "Jahr";
            this.lblSollProJahrJahr.UseCompatibleTextRendering = true;
            // 
            // grdBDESollStundenProJahr_XUser
            // 
            this.grdBDESollStundenProJahr_XUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBDESollStundenProJahr_XUser.DataSource = this.qryBDESollStundenProJahr_XUser;
            // 
            // 
            // 
            this.grdBDESollStundenProJahr_XUser.EmbeddedNavigator.Name = "";
            this.grdBDESollStundenProJahr_XUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDESollStundenProJahr_XUser.Location = new System.Drawing.Point(3, 3);
            this.grdBDESollStundenProJahr_XUser.MainView = this.grvBDESollStundenProJahr_XUser;
            this.grdBDESollStundenProJahr_XUser.Name = "grdBDESollStundenProJahr_XUser";
            this.grdBDESollStundenProJahr_XUser.Size = new System.Drawing.Size(876, 235);
            this.grdBDESollStundenProJahr_XUser.TabIndex = 0;
            this.grdBDESollStundenProJahr_XUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDESollStundenProJahr_XUser});
            // 
            // grvBDESollStundenProJahr_XUser
            // 
            this.grvBDESollStundenProJahr_XUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDESollStundenProJahr_XUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.Empty.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDESollStundenProJahr_XUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDESollStundenProJahr_XUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDESollStundenProJahr_XUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDESollStundenProJahr_XUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDESollStundenProJahr_XUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDESollStundenProJahr_XUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.OddRow.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDESollStundenProJahr_XUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.Row.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.Row.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollStundenProJahr_XUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDESollStundenProJahr_XUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDESollStundenProJahr_XUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDESollStundenProJahr_XUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDESollStundenProJahr_XUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSollProJahrJahr,
            this.colSollProJahrJanuarStd,
            this.colSollProJahrFebruarStd,
            this.colSollProJahrMaerzStd,
            this.colSollProJahrAprilStd,
            this.colSollProJahrMai,
            this.colSollProJahrJuniStd,
            this.colSollProJahrJuliStd,
            this.colSollProJahrAugustStd,
            this.colSollProJahrSeptemberStd,
            this.colSollProJahrOktoberStd,
            this.colSollProJahrNovemberStd,
            this.colSollProJahrDezemberStd,
            this.colSollProJahrTotalStd,
            this.colSollProJahrManualEdit});
            this.grvBDESollStundenProJahr_XUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDESollStundenProJahr_XUser.GridControl = this.grdBDESollStundenProJahr_XUser;
            this.grvBDESollStundenProJahr_XUser.Name = "grvBDESollStundenProJahr_XUser";
            this.grvBDESollStundenProJahr_XUser.OptionsBehavior.Editable = false;
            this.grvBDESollStundenProJahr_XUser.OptionsCustomization.AllowFilter = false;
            this.grvBDESollStundenProJahr_XUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDESollStundenProJahr_XUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDESollStundenProJahr_XUser.OptionsNavigation.UseTabKey = false;
            this.grvBDESollStundenProJahr_XUser.OptionsView.ColumnAutoWidth = false;
            this.grvBDESollStundenProJahr_XUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDESollStundenProJahr_XUser.OptionsView.ShowGroupPanel = false;
            this.grvBDESollStundenProJahr_XUser.OptionsView.ShowIndicator = false;
            // 
            // colSollProJahrJahr
            // 
            this.colSollProJahrJahr.Caption = "Jahr";
            this.colSollProJahrJahr.FieldName = "Jahr";
            this.colSollProJahrJahr.Name = "colSollProJahrJahr";
            this.colSollProJahrJahr.Visible = true;
            this.colSollProJahrJahr.VisibleIndex = 0;
            this.colSollProJahrJahr.Width = 60;
            // 
            // colSollProJahrJanuarStd
            // 
            this.colSollProJahrJanuarStd.Caption = "Jan.";
            this.colSollProJahrJanuarStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrJanuarStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrJanuarStd.FieldName = "JanuarStd";
            this.colSollProJahrJanuarStd.Name = "colSollProJahrJanuarStd";
            this.colSollProJahrJanuarStd.Visible = true;
            this.colSollProJahrJanuarStd.VisibleIndex = 1;
            this.colSollProJahrJanuarStd.Width = 58;
            // 
            // colSollProJahrFebruarStd
            // 
            this.colSollProJahrFebruarStd.Caption = "Feb.";
            this.colSollProJahrFebruarStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrFebruarStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrFebruarStd.FieldName = "FebruarStd";
            this.colSollProJahrFebruarStd.Name = "colSollProJahrFebruarStd";
            this.colSollProJahrFebruarStd.Visible = true;
            this.colSollProJahrFebruarStd.VisibleIndex = 2;
            this.colSollProJahrFebruarStd.Width = 58;
            // 
            // colSollProJahrMaerzStd
            // 
            this.colSollProJahrMaerzStd.Caption = "Mrz.";
            this.colSollProJahrMaerzStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrMaerzStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrMaerzStd.FieldName = "MaerzStd";
            this.colSollProJahrMaerzStd.Name = "colSollProJahrMaerzStd";
            this.colSollProJahrMaerzStd.Visible = true;
            this.colSollProJahrMaerzStd.VisibleIndex = 3;
            this.colSollProJahrMaerzStd.Width = 58;
            // 
            // colSollProJahrAprilStd
            // 
            this.colSollProJahrAprilStd.Caption = "Apr.";
            this.colSollProJahrAprilStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrAprilStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrAprilStd.FieldName = "AprilStd";
            this.colSollProJahrAprilStd.Name = "colSollProJahrAprilStd";
            this.colSollProJahrAprilStd.Visible = true;
            this.colSollProJahrAprilStd.VisibleIndex = 4;
            this.colSollProJahrAprilStd.Width = 58;
            // 
            // colSollProJahrMai
            // 
            this.colSollProJahrMai.Caption = "Mai";
            this.colSollProJahrMai.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrMai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrMai.FieldName = "MaiStd";
            this.colSollProJahrMai.Name = "colSollProJahrMai";
            this.colSollProJahrMai.Visible = true;
            this.colSollProJahrMai.VisibleIndex = 5;
            this.colSollProJahrMai.Width = 58;
            // 
            // colSollProJahrJuniStd
            // 
            this.colSollProJahrJuniStd.Caption = "Jun.";
            this.colSollProJahrJuniStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrJuniStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrJuniStd.FieldName = "JuniStd";
            this.colSollProJahrJuniStd.Name = "colSollProJahrJuniStd";
            this.colSollProJahrJuniStd.Visible = true;
            this.colSollProJahrJuniStd.VisibleIndex = 6;
            this.colSollProJahrJuniStd.Width = 58;
            // 
            // colSollProJahrJuliStd
            // 
            this.colSollProJahrJuliStd.Caption = "Jul.";
            this.colSollProJahrJuliStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrJuliStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrJuliStd.FieldName = "JuliStd";
            this.colSollProJahrJuliStd.Name = "colSollProJahrJuliStd";
            this.colSollProJahrJuliStd.Visible = true;
            this.colSollProJahrJuliStd.VisibleIndex = 7;
            this.colSollProJahrJuliStd.Width = 58;
            // 
            // colSollProJahrAugustStd
            // 
            this.colSollProJahrAugustStd.Caption = "Aug.";
            this.colSollProJahrAugustStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrAugustStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrAugustStd.FieldName = "AugustStd";
            this.colSollProJahrAugustStd.Name = "colSollProJahrAugustStd";
            this.colSollProJahrAugustStd.Visible = true;
            this.colSollProJahrAugustStd.VisibleIndex = 8;
            this.colSollProJahrAugustStd.Width = 58;
            // 
            // colSollProJahrSeptemberStd
            // 
            this.colSollProJahrSeptemberStd.Caption = "Sep.";
            this.colSollProJahrSeptemberStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrSeptemberStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrSeptemberStd.FieldName = "SeptemberStd";
            this.colSollProJahrSeptemberStd.Name = "colSollProJahrSeptemberStd";
            this.colSollProJahrSeptemberStd.Visible = true;
            this.colSollProJahrSeptemberStd.VisibleIndex = 9;
            this.colSollProJahrSeptemberStd.Width = 58;
            // 
            // colSollProJahrOktoberStd
            // 
            this.colSollProJahrOktoberStd.Caption = "Okt.";
            this.colSollProJahrOktoberStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrOktoberStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrOktoberStd.FieldName = "OktoberStd";
            this.colSollProJahrOktoberStd.Name = "colSollProJahrOktoberStd";
            this.colSollProJahrOktoberStd.Visible = true;
            this.colSollProJahrOktoberStd.VisibleIndex = 10;
            this.colSollProJahrOktoberStd.Width = 58;
            // 
            // colSollProJahrNovemberStd
            // 
            this.colSollProJahrNovemberStd.Caption = "Nov.";
            this.colSollProJahrNovemberStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrNovemberStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrNovemberStd.FieldName = "NovemberStd";
            this.colSollProJahrNovemberStd.Name = "colSollProJahrNovemberStd";
            this.colSollProJahrNovemberStd.Visible = true;
            this.colSollProJahrNovemberStd.VisibleIndex = 11;
            this.colSollProJahrNovemberStd.Width = 58;
            // 
            // colSollProJahrDezemberStd
            // 
            this.colSollProJahrDezemberStd.Caption = "Dez.";
            this.colSollProJahrDezemberStd.DisplayFormat.FormatString = "##0.0000";
            this.colSollProJahrDezemberStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrDezemberStd.FieldName = "DezemberStd";
            this.colSollProJahrDezemberStd.Name = "colSollProJahrDezemberStd";
            this.colSollProJahrDezemberStd.Visible = true;
            this.colSollProJahrDezemberStd.VisibleIndex = 12;
            this.colSollProJahrDezemberStd.Width = 58;
            // 
            // colSollProJahrTotalStd
            // 
            this.colSollProJahrTotalStd.Caption = "Total";
            this.colSollProJahrTotalStd.DisplayFormat.FormatString = "###0.0000";
            this.colSollProJahrTotalStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProJahrTotalStd.FieldName = "TotalStd";
            this.colSollProJahrTotalStd.Name = "colSollProJahrTotalStd";
            this.colSollProJahrTotalStd.Visible = true;
            this.colSollProJahrTotalStd.VisibleIndex = 13;
            this.colSollProJahrTotalStd.Width = 70;
            // 
            // colSollProJahrManualEdit
            // 
            this.colSollProJahrManualEdit.Caption = "Manuell";
            this.colSollProJahrManualEdit.FieldName = "ManualEdit";
            this.colSollProJahrManualEdit.Name = "colSollProJahrManualEdit";
            this.colSollProJahrManualEdit.Visible = true;
            this.colSollProJahrManualEdit.VisibleIndex = 14;
            this.colSollProJahrManualEdit.Width = 60;
            // 
            // tpgSollProTag
            // 
            this.tpgSollProTag.Controls.Add(this.lblSollProTagSollStundenProTagUnit);
            this.tpgSollProTag.Controls.Add(this.edtSollProTagSollStundenProTag);
            this.tpgSollProTag.Controls.Add(this.lblSollProTagSollStundenProTag);
            this.tpgSollProTag.Controls.Add(this.edtSollProTagDatumBis);
            this.tpgSollProTag.Controls.Add(this.lblSollProTagDatumBis);
            this.tpgSollProTag.Controls.Add(this.edtSollProTagDatumVon);
            this.tpgSollProTag.Controls.Add(this.lblSollProTagDatumVon);
            this.tpgSollProTag.Controls.Add(this.grdBDESollProTag_XUser);
            this.tpgSollProTag.Location = new System.Drawing.Point(6, 6);
            this.tpgSollProTag.Name = "tpgSollProTag";
            this.tpgSollProTag.Size = new System.Drawing.Size(882, 397);
            this.tpgSollProTag.TabIndex = 1;
            this.tpgSollProTag.Title = "Soll pro Tag";
            // 
            // lblSollProTagSollStundenProTagUnit
            // 
            this.lblSollProTagSollStundenProTagUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProTagSollStundenProTagUnit.Location = new System.Drawing.Point(216, 364);
            this.lblSollProTagSollStundenProTagUnit.Name = "lblSollProTagSollStundenProTagUnit";
            this.lblSollProTagSollStundenProTagUnit.Size = new System.Drawing.Size(35, 24);
            this.lblSollProTagSollStundenProTagUnit.TabIndex = 7;
            this.lblSollProTagSollStundenProTagUnit.Text = "Std.";
            this.lblSollProTagSollStundenProTagUnit.UseCompatibleTextRendering = true;
            // 
            // edtSollProTagSollStundenProTag
            // 
            this.edtSollProTagSollStundenProTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProTagSollStundenProTag.DataMember = "SollStundenProTag";
            this.edtSollProTagSollStundenProTag.DataSource = this.qryBDESollProTag_XUser;
            this.edtSollProTagSollStundenProTag.Location = new System.Drawing.Point(136, 364);
            this.edtSollProTagSollStundenProTag.Name = "edtSollProTagSollStundenProTag";
            this.edtSollProTagSollStundenProTag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProTagSollStundenProTag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProTagSollStundenProTag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProTagSollStundenProTag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProTagSollStundenProTag.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProTagSollStundenProTag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProTagSollStundenProTag.Properties.Appearance.Options.UseFont = true;
            this.edtSollProTagSollStundenProTag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollProTagSollStundenProTag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProTagSollStundenProTag.Properties.DisplayFormat.FormatString = "#0.0000";
            this.edtSollProTagSollStundenProTag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProTagSollStundenProTag.Properties.EditFormat.FormatString = "#0.####";
            this.edtSollProTagSollStundenProTag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSollProTagSollStundenProTag.Properties.Mask.EditMask = "#0.####";
            this.edtSollProTagSollStundenProTag.Properties.MaxLength = 2;
            this.edtSollProTagSollStundenProTag.Properties.Precision = 4;
            this.edtSollProTagSollStundenProTag.Size = new System.Drawing.Size(74, 24);
            this.edtSollProTagSollStundenProTag.TabIndex = 6;
            // 
            // qryBDESollProTag_XUser
            // 
            this.qryBDESollProTag_XUser.HostControl = this;
            this.qryBDESollProTag_XUser.TableName = "BDESollProTag_XUser";
            this.qryBDESollProTag_XUser.BeforePost += new System.EventHandler(this.qryBDESollProTag_XUser_BeforePost);
            // 
            // lblSollProTagSollStundenProTag
            // 
            this.lblSollProTagSollStundenProTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProTagSollStundenProTag.Location = new System.Drawing.Point(6, 364);
            this.lblSollProTagSollStundenProTag.Name = "lblSollProTagSollStundenProTag";
            this.lblSollProTagSollStundenProTag.Size = new System.Drawing.Size(124, 24);
            this.lblSollProTagSollStundenProTag.TabIndex = 5;
            this.lblSollProTagSollStundenProTag.Text = "Soll Stunden pro Tag";
            this.lblSollProTagSollStundenProTag.UseCompatibleTextRendering = true;
            // 
            // edtSollProTagDatumBis
            // 
            this.edtSollProTagDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProTagDatumBis.DataMember = "DatumBis";
            this.edtSollProTagDatumBis.DataSource = this.qryBDESollProTag_XUser;
            this.edtSollProTagDatumBis.EditValue = null;
            this.edtSollProTagDatumBis.Location = new System.Drawing.Point(136, 334);
            this.edtSollProTagDatumBis.Name = "edtSollProTagDatumBis";
            this.edtSollProTagDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProTagDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProTagDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProTagDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProTagDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProTagDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProTagDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSollProTagDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSollProTagDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSollProTagDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSollProTagDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProTagDatumBis.Properties.ShowToday = false;
            this.edtSollProTagDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSollProTagDatumBis.TabIndex = 4;
            // 
            // lblSollProTagDatumBis
            // 
            this.lblSollProTagDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProTagDatumBis.Location = new System.Drawing.Point(6, 334);
            this.lblSollProTagDatumBis.Name = "lblSollProTagDatumBis";
            this.lblSollProTagDatumBis.Size = new System.Drawing.Size(124, 24);
            this.lblSollProTagDatumBis.TabIndex = 3;
            this.lblSollProTagDatumBis.Text = "Gültig bis";
            this.lblSollProTagDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtSollProTagDatumVon
            // 
            this.edtSollProTagDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollProTagDatumVon.DataMember = "DatumVon";
            this.edtSollProTagDatumVon.DataSource = this.qryBDESollProTag_XUser;
            this.edtSollProTagDatumVon.EditValue = null;
            this.edtSollProTagDatumVon.Location = new System.Drawing.Point(136, 304);
            this.edtSollProTagDatumVon.Name = "edtSollProTagDatumVon";
            this.edtSollProTagDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollProTagDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProTagDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProTagDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProTagDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProTagDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProTagDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSollProTagDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSollProTagDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSollProTagDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSollProTagDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProTagDatumVon.Properties.ShowToday = false;
            this.edtSollProTagDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSollProTagDatumVon.TabIndex = 2;
            // 
            // lblSollProTagDatumVon
            // 
            this.lblSollProTagDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSollProTagDatumVon.Location = new System.Drawing.Point(6, 304);
            this.lblSollProTagDatumVon.Name = "lblSollProTagDatumVon";
            this.lblSollProTagDatumVon.Size = new System.Drawing.Size(124, 24);
            this.lblSollProTagDatumVon.TabIndex = 1;
            this.lblSollProTagDatumVon.Text = "Gültig ab";
            this.lblSollProTagDatumVon.UseCompatibleTextRendering = true;
            // 
            // grdBDESollProTag_XUser
            // 
            this.grdBDESollProTag_XUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBDESollProTag_XUser.DataSource = this.qryBDESollProTag_XUser;
            // 
            // 
            // 
            this.grdBDESollProTag_XUser.EmbeddedNavigator.Name = "";
            this.grdBDESollProTag_XUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDESollProTag_XUser.Location = new System.Drawing.Point(3, 3);
            this.grdBDESollProTag_XUser.MainView = this.grvBDESollProTag_XUser;
            this.grdBDESollProTag_XUser.Name = "grdBDESollProTag_XUser";
            this.grdBDESollProTag_XUser.Size = new System.Drawing.Size(876, 295);
            this.grdBDESollProTag_XUser.TabIndex = 0;
            this.grdBDESollProTag_XUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDESollProTag_XUser});
            // 
            // grvBDESollProTag_XUser
            // 
            this.grvBDESollProTag_XUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDESollProTag_XUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.Empty.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDESollProTag_XUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDESollProTag_XUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDESollProTag_XUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDESollProTag_XUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDESollProTag_XUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDESollProTag_XUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDESollProTag_XUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDESollProTag_XUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDESollProTag_XUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDESollProTag_XUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDESollProTag_XUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDESollProTag_XUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDESollProTag_XUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDESollProTag_XUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDESollProTag_XUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDESollProTag_XUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDESollProTag_XUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.OddRow.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDESollProTag_XUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.Row.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.Appearance.Row.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDESollProTag_XUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDESollProTag_XUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDESollProTag_XUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDESollProTag_XUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDESollProTag_XUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSollProTagBDESollProTag_XUserID,
            this.colSollProTagDatumVon,
            this.colSollProTagDatumBis,
            this.colSollProTagSollStundenProTag,
            this.colSollProTagManualEdit});
            this.grvBDESollProTag_XUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDESollProTag_XUser.GridControl = this.grdBDESollProTag_XUser;
            this.grvBDESollProTag_XUser.Name = "grvBDESollProTag_XUser";
            this.grvBDESollProTag_XUser.OptionsBehavior.Editable = false;
            this.grvBDESollProTag_XUser.OptionsCustomization.AllowFilter = false;
            this.grvBDESollProTag_XUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDESollProTag_XUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDESollProTag_XUser.OptionsNavigation.UseTabKey = false;
            this.grvBDESollProTag_XUser.OptionsView.ColumnAutoWidth = false;
            this.grvBDESollProTag_XUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDESollProTag_XUser.OptionsView.ShowGroupPanel = false;
            this.grvBDESollProTag_XUser.OptionsView.ShowIndicator = false;
            // 
            // colSollProTagBDESollProTag_XUserID
            // 
            this.colSollProTagBDESollProTag_XUserID.Caption = "ID";
            this.colSollProTagBDESollProTag_XUserID.FieldName = "BDESollProTag_XUserID";
            this.colSollProTagBDESollProTag_XUserID.Name = "colSollProTagBDESollProTag_XUserID";
            this.colSollProTagBDESollProTag_XUserID.Visible = true;
            this.colSollProTagBDESollProTag_XUserID.VisibleIndex = 0;
            this.colSollProTagBDESollProTag_XUserID.Width = 60;
            // 
            // colSollProTagDatumVon
            // 
            this.colSollProTagDatumVon.Caption = "Gültig ab";
            this.colSollProTagDatumVon.FieldName = "DatumVon";
            this.colSollProTagDatumVon.Name = "colSollProTagDatumVon";
            this.colSollProTagDatumVon.Visible = true;
            this.colSollProTagDatumVon.VisibleIndex = 1;
            this.colSollProTagDatumVon.Width = 80;
            // 
            // colSollProTagDatumBis
            // 
            this.colSollProTagDatumBis.Caption = "Gültig bis";
            this.colSollProTagDatumBis.FieldName = "DatumBis";
            this.colSollProTagDatumBis.Name = "colSollProTagDatumBis";
            this.colSollProTagDatumBis.Visible = true;
            this.colSollProTagDatumBis.VisibleIndex = 2;
            this.colSollProTagDatumBis.Width = 80;
            // 
            // colSollProTagSollStundenProTag
            // 
            this.colSollProTagSollStundenProTag.Caption = "Soll Stunden pro Tag";
            this.colSollProTagSollStundenProTag.DisplayFormat.FormatString = "#0.0000";
            this.colSollProTagSollStundenProTag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSollProTagSollStundenProTag.FieldName = "SollStundenProTag";
            this.colSollProTagSollStundenProTag.Name = "colSollProTagSollStundenProTag";
            this.colSollProTagSollStundenProTag.Visible = true;
            this.colSollProTagSollStundenProTag.VisibleIndex = 3;
            this.colSollProTagSollStundenProTag.Width = 160;
            // 
            // colSollProTagManualEdit
            // 
            this.colSollProTagManualEdit.Caption = "Manuell";
            this.colSollProTagManualEdit.FieldName = "ManualEdit";
            this.colSollProTagManualEdit.Name = "colSollProTagManualEdit";
            this.colSollProTagManualEdit.Visible = true;
            this.colSollProTagManualEdit.VisibleIndex = 4;
            this.colSollProTagManualEdit.Width = 60;
            // 
            // tpgPensum
            // 
            this.tpgPensum.Controls.Add(this.lblPensumPensumProzentUnit);
            this.tpgPensum.Controls.Add(this.edtPensumPensumProzent);
            this.tpgPensum.Controls.Add(this.lblPensumPensumProzent);
            this.tpgPensum.Controls.Add(this.edtPensumDatumBis);
            this.tpgPensum.Controls.Add(this.lblPensumDatumBis);
            this.tpgPensum.Controls.Add(this.edtPensumDatumVon);
            this.tpgPensum.Controls.Add(this.lblPensumDatumVon);
            this.tpgPensum.Controls.Add(this.grdBDEPensum_XUser);
            this.tpgPensum.Location = new System.Drawing.Point(6, 6);
            this.tpgPensum.Name = "tpgPensum";
            this.tpgPensum.Size = new System.Drawing.Size(882, 397);
            this.tpgPensum.TabIndex = 0;
            this.tpgPensum.Title = "Beschäftigungsgrad";
            // 
            // lblPensumPensumProzentUnit
            // 
            this.lblPensumPensumProzentUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPensumPensumProzentUnit.Location = new System.Drawing.Point(216, 364);
            this.lblPensumPensumProzentUnit.Name = "lblPensumPensumProzentUnit";
            this.lblPensumPensumProzentUnit.Size = new System.Drawing.Size(20, 24);
            this.lblPensumPensumProzentUnit.TabIndex = 7;
            this.lblPensumPensumProzentUnit.Text = "%";
            this.lblPensumPensumProzentUnit.UseCompatibleTextRendering = true;
            // 
            // edtPensumPensumProzent
            // 
            this.edtPensumPensumProzent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPensumPensumProzent.DataMember = "PensumProzent";
            this.edtPensumPensumProzent.DataSource = this.qryBDEPensum_XUser;
            this.edtPensumPensumProzent.Location = new System.Drawing.Point(136, 364);
            this.edtPensumPensumProzent.Name = "edtPensumPensumProzent";
            this.edtPensumPensumProzent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensumPensumProzent.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensumPensumProzent.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensumPensumProzent.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumPensumProzent.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensumPensumProzent.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensumPensumProzent.Properties.Appearance.Options.UseFont = true;
            this.edtPensumPensumProzent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensumPensumProzent.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensumPensumProzent.Properties.DisplayFormat.FormatString = "##0";
            this.edtPensumPensumProzent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtPensumPensumProzent.Properties.EditFormat.FormatString = "##0";
            this.edtPensumPensumProzent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtPensumPensumProzent.Properties.Mask.EditMask = "##0";
            this.edtPensumPensumProzent.Properties.MaxLength = 3;
            this.edtPensumPensumProzent.Properties.Precision = 0;
            this.edtPensumPensumProzent.Size = new System.Drawing.Size(74, 24);
            this.edtPensumPensumProzent.TabIndex = 6;
            // 
            // qryBDEPensum_XUser
            // 
            this.qryBDEPensum_XUser.HostControl = this;
            this.qryBDEPensum_XUser.TableName = "BDEPensum_XUser";
            this.qryBDEPensum_XUser.BeforePost += new System.EventHandler(this.qryBDEPensum_XUser_BeforePost);
            // 
            // lblPensumPensumProzent
            // 
            this.lblPensumPensumProzent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPensumPensumProzent.Location = new System.Drawing.Point(6, 364);
            this.lblPensumPensumProzent.Name = "lblPensumPensumProzent";
            this.lblPensumPensumProzent.Size = new System.Drawing.Size(124, 24);
            this.lblPensumPensumProzent.TabIndex = 5;
            this.lblPensumPensumProzent.Text = "Beschäftigungsgrad";
            this.lblPensumPensumProzent.UseCompatibleTextRendering = true;
            // 
            // edtPensumDatumBis
            // 
            this.edtPensumDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPensumDatumBis.DataMember = "DatumBis";
            this.edtPensumDatumBis.DataSource = this.qryBDEPensum_XUser;
            this.edtPensumDatumBis.EditValue = null;
            this.edtPensumDatumBis.Location = new System.Drawing.Point(136, 334);
            this.edtPensumDatumBis.Name = "edtPensumDatumBis";
            this.edtPensumDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensumDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensumDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensumDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensumDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensumDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtPensumDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtPensumDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPensumDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtPensumDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensumDatumBis.Properties.ShowToday = false;
            this.edtPensumDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtPensumDatumBis.TabIndex = 4;
            // 
            // lblPensumDatumBis
            // 
            this.lblPensumDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPensumDatumBis.Location = new System.Drawing.Point(6, 334);
            this.lblPensumDatumBis.Name = "lblPensumDatumBis";
            this.lblPensumDatumBis.Size = new System.Drawing.Size(124, 24);
            this.lblPensumDatumBis.TabIndex = 3;
            this.lblPensumDatumBis.Text = "Gültig bis";
            this.lblPensumDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtPensumDatumVon
            // 
            this.edtPensumDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPensumDatumVon.DataMember = "DatumVon";
            this.edtPensumDatumVon.DataSource = this.qryBDEPensum_XUser;
            this.edtPensumDatumVon.EditValue = null;
            this.edtPensumDatumVon.Location = new System.Drawing.Point(136, 304);
            this.edtPensumDatumVon.Name = "edtPensumDatumVon";
            this.edtPensumDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensumDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensumDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensumDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensumDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensumDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtPensumDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtPensumDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPensumDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtPensumDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensumDatumVon.Properties.ShowToday = false;
            this.edtPensumDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtPensumDatumVon.TabIndex = 2;
            // 
            // lblPensumDatumVon
            // 
            this.lblPensumDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPensumDatumVon.Location = new System.Drawing.Point(6, 304);
            this.lblPensumDatumVon.Name = "lblPensumDatumVon";
            this.lblPensumDatumVon.Size = new System.Drawing.Size(124, 24);
            this.lblPensumDatumVon.TabIndex = 1;
            this.lblPensumDatumVon.Text = "Gültig ab";
            this.lblPensumDatumVon.UseCompatibleTextRendering = true;
            // 
            // grdBDEPensum_XUser
            // 
            this.grdBDEPensum_XUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBDEPensum_XUser.DataSource = this.qryBDEPensum_XUser;
            // 
            // 
            // 
            this.grdBDEPensum_XUser.EmbeddedNavigator.Name = "";
            this.grdBDEPensum_XUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDEPensum_XUser.Location = new System.Drawing.Point(3, 3);
            this.grdBDEPensum_XUser.MainView = this.grvBDEPensum_XUser;
            this.grdBDEPensum_XUser.Name = "grdBDEPensum_XUser";
            this.grdBDEPensum_XUser.Size = new System.Drawing.Size(876, 295);
            this.grdBDEPensum_XUser.TabIndex = 0;
            this.grdBDEPensum_XUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDEPensum_XUser});
            // 
            // grvBDEPensum_XUser
            // 
            this.grvBDEPensum_XUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDEPensum_XUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.Empty.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEPensum_XUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDEPensum_XUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDEPensum_XUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEPensum_XUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDEPensum_XUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDEPensum_XUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEPensum_XUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEPensum_XUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEPensum_XUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDEPensum_XUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDEPensum_XUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDEPensum_XUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDEPensum_XUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDEPensum_XUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEPensum_XUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDEPensum_XUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEPensum_XUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.OddRow.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDEPensum_XUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.Row.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.Appearance.Row.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEPensum_XUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDEPensum_XUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEPensum_XUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDEPensum_XUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDEPensum_XUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPensumBDEPensum_XUserID,
            this.colPensumDatumVon,
            this.colPensumDatumBis,
            this.colPensumPensumProzent,
            this.colPensumManualEdit});
            this.grvBDEPensum_XUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDEPensum_XUser.GridControl = this.grdBDEPensum_XUser;
            this.grvBDEPensum_XUser.Name = "grvBDEPensum_XUser";
            this.grvBDEPensum_XUser.OptionsBehavior.Editable = false;
            this.grvBDEPensum_XUser.OptionsCustomization.AllowFilter = false;
            this.grvBDEPensum_XUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDEPensum_XUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDEPensum_XUser.OptionsNavigation.UseTabKey = false;
            this.grvBDEPensum_XUser.OptionsView.ColumnAutoWidth = false;
            this.grvBDEPensum_XUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDEPensum_XUser.OptionsView.ShowGroupPanel = false;
            this.grvBDEPensum_XUser.OptionsView.ShowIndicator = false;
            // 
            // colPensumBDEPensum_XUserID
            // 
            this.colPensumBDEPensum_XUserID.Caption = "ID";
            this.colPensumBDEPensum_XUserID.FieldName = "BDEPensum_XUserID";
            this.colPensumBDEPensum_XUserID.Name = "colPensumBDEPensum_XUserID";
            this.colPensumBDEPensum_XUserID.Visible = true;
            this.colPensumBDEPensum_XUserID.VisibleIndex = 0;
            this.colPensumBDEPensum_XUserID.Width = 60;
            // 
            // colPensumDatumVon
            // 
            this.colPensumDatumVon.Caption = "Gültig ab";
            this.colPensumDatumVon.FieldName = "DatumVon";
            this.colPensumDatumVon.Name = "colPensumDatumVon";
            this.colPensumDatumVon.Visible = true;
            this.colPensumDatumVon.VisibleIndex = 1;
            this.colPensumDatumVon.Width = 80;
            // 
            // colPensumDatumBis
            // 
            this.colPensumDatumBis.Caption = "Gültig bis";
            this.colPensumDatumBis.FieldName = "DatumBis";
            this.colPensumDatumBis.Name = "colPensumDatumBis";
            this.colPensumDatumBis.Visible = true;
            this.colPensumDatumBis.VisibleIndex = 2;
            this.colPensumDatumBis.Width = 80;
            // 
            // colPensumPensumProzent
            // 
            this.colPensumPensumProzent.Caption = "Beschäftigungsgrad [%]";
            this.colPensumPensumProzent.FieldName = "PensumProzent";
            this.colPensumPensumProzent.Name = "colPensumPensumProzent";
            this.colPensumPensumProzent.Visible = true;
            this.colPensumPensumProzent.VisibleIndex = 3;
            this.colPensumPensumProzent.Width = 160;
            // 
            // colPensumManualEdit
            // 
            this.colPensumManualEdit.Caption = "Manuell";
            this.colPensumManualEdit.FieldName = "ManualEdit";
            this.colPensumManualEdit.Name = "colPensumManualEdit";
            this.colPensumManualEdit.Visible = true;
            this.colPensumManualEdit.VisibleIndex = 4;
            this.colPensumManualEdit.Width = 60;
            // 
            // tpgFerienAnspruch
            // 
            this.tpgFerienAnspruch.Controls.Add(this.lblFerienAnspruchFerienAnspruchStdProJahrUnit);
            this.tpgFerienAnspruch.Controls.Add(this.edtFerienAnspruchFerienAnspruchStdProJahr);
            this.tpgFerienAnspruch.Controls.Add(this.lblFerienAnspruchFerienAnspruchStdProJahr);
            this.tpgFerienAnspruch.Controls.Add(this.edtFerienAnspruchDatumBis);
            this.tpgFerienAnspruch.Controls.Add(this.lblFerienAnspruchDatumBis);
            this.tpgFerienAnspruch.Controls.Add(this.edtFerienAnspruchDatumVon);
            this.tpgFerienAnspruch.Controls.Add(this.lblFerienAnspruchDatumVon);
            this.tpgFerienAnspruch.Controls.Add(this.edtFerienAnspruchJahr);
            this.tpgFerienAnspruch.Controls.Add(this.lblFerienAnspruchJahr);
            this.tpgFerienAnspruch.Controls.Add(this.grdBDEFerienAnspruch_XUser);
            this.tpgFerienAnspruch.Location = new System.Drawing.Point(6, 6);
            this.tpgFerienAnspruch.Name = "tpgFerienAnspruch";
            this.tpgFerienAnspruch.Size = new System.Drawing.Size(882, 397);
            this.tpgFerienAnspruch.TabIndex = 0;
            this.tpgFerienAnspruch.Title = "Ferien Anspruch";
            // 
            // lblFerienAnspruchFerienAnspruchStdProJahrUnit
            // 
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit.Location = new System.Drawing.Point(216, 364);
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit.Name = "lblFerienAnspruchFerienAnspruchStdProJahrUnit";
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit.Size = new System.Drawing.Size(35, 24);
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit.TabIndex = 9;
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit.Text = "Std.";
            this.lblFerienAnspruchFerienAnspruchStdProJahrUnit.UseCompatibleTextRendering = true;
            // 
            // edtFerienAnspruchFerienAnspruchStdProJahr
            // 
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFerienAnspruchFerienAnspruchStdProJahr.DataMember = "FerienanspruchStdProJahr";
            this.edtFerienAnspruchFerienAnspruchStdProJahr.DataSource = this.qryBDEFerienAnspruch_XUser;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Location = new System.Drawing.Point(136, 364);
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Name = "edtFerienAnspruchFerienAnspruchStdProJahr";
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Appearance.Options.UseFont = true;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.DisplayFormat.FormatString = "###0.0000";
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.EditFormat.FormatString = "###0.####";
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Mask.EditMask = "###0.####";
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.MaxLength = 2;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties.Precision = 4;
            this.edtFerienAnspruchFerienAnspruchStdProJahr.Size = new System.Drawing.Size(74, 24);
            this.edtFerienAnspruchFerienAnspruchStdProJahr.TabIndex = 8;
            // 
            // qryBDEFerienAnspruch_XUser
            // 
            this.qryBDEFerienAnspruch_XUser.HostControl = this;
            this.qryBDEFerienAnspruch_XUser.TableName = "BDEFerienAnspruch_XUser";
            this.qryBDEFerienAnspruch_XUser.BeforePost += new System.EventHandler(this.qryBDEFerienAnspruch_XUser_BeforePost);
            // 
            // lblFerienAnspruchFerienAnspruchStdProJahr
            // 
            this.lblFerienAnspruchFerienAnspruchStdProJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienAnspruchFerienAnspruchStdProJahr.Location = new System.Drawing.Point(6, 364);
            this.lblFerienAnspruchFerienAnspruchStdProJahr.Name = "lblFerienAnspruchFerienAnspruchStdProJahr";
            this.lblFerienAnspruchFerienAnspruchStdProJahr.Size = new System.Drawing.Size(124, 24);
            this.lblFerienAnspruchFerienAnspruchStdProJahr.TabIndex = 7;
            this.lblFerienAnspruchFerienAnspruchStdProJahr.Text = "Ferienansp. pro Jahr";
            this.lblFerienAnspruchFerienAnspruchStdProJahr.UseCompatibleTextRendering = true;
            // 
            // edtFerienAnspruchDatumBis
            // 
            this.edtFerienAnspruchDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFerienAnspruchDatumBis.DataMember = "DatumBis";
            this.edtFerienAnspruchDatumBis.DataSource = this.qryBDEFerienAnspruch_XUser;
            this.edtFerienAnspruchDatumBis.EditValue = null;
            this.edtFerienAnspruchDatumBis.Location = new System.Drawing.Point(136, 334);
            this.edtFerienAnspruchDatumBis.Name = "edtFerienAnspruchDatumBis";
            this.edtFerienAnspruchDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFerienAnspruchDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFerienAnspruchDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFerienAnspruchDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFerienAnspruchDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFerienAnspruchDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFerienAnspruchDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtFerienAnspruchDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtFerienAnspruchDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFerienAnspruchDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtFerienAnspruchDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFerienAnspruchDatumBis.Properties.ShowToday = false;
            this.edtFerienAnspruchDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtFerienAnspruchDatumBis.TabIndex = 6;
            // 
            // lblFerienAnspruchDatumBis
            // 
            this.lblFerienAnspruchDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienAnspruchDatumBis.Location = new System.Drawing.Point(6, 334);
            this.lblFerienAnspruchDatumBis.Name = "lblFerienAnspruchDatumBis";
            this.lblFerienAnspruchDatumBis.Size = new System.Drawing.Size(124, 24);
            this.lblFerienAnspruchDatumBis.TabIndex = 5;
            this.lblFerienAnspruchDatumBis.Text = "Gültig bis";
            this.lblFerienAnspruchDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtFerienAnspruchDatumVon
            // 
            this.edtFerienAnspruchDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFerienAnspruchDatumVon.DataMember = "DatumVon";
            this.edtFerienAnspruchDatumVon.DataSource = this.qryBDEFerienAnspruch_XUser;
            this.edtFerienAnspruchDatumVon.EditValue = null;
            this.edtFerienAnspruchDatumVon.Location = new System.Drawing.Point(136, 304);
            this.edtFerienAnspruchDatumVon.Name = "edtFerienAnspruchDatumVon";
            this.edtFerienAnspruchDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFerienAnspruchDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFerienAnspruchDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFerienAnspruchDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFerienAnspruchDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFerienAnspruchDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFerienAnspruchDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtFerienAnspruchDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtFerienAnspruchDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFerienAnspruchDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtFerienAnspruchDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFerienAnspruchDatumVon.Properties.ShowToday = false;
            this.edtFerienAnspruchDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtFerienAnspruchDatumVon.TabIndex = 4;
            // 
            // lblFerienAnspruchDatumVon
            // 
            this.lblFerienAnspruchDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienAnspruchDatumVon.Location = new System.Drawing.Point(6, 304);
            this.lblFerienAnspruchDatumVon.Name = "lblFerienAnspruchDatumVon";
            this.lblFerienAnspruchDatumVon.Size = new System.Drawing.Size(124, 24);
            this.lblFerienAnspruchDatumVon.TabIndex = 3;
            this.lblFerienAnspruchDatumVon.Text = "Gültig ab";
            this.lblFerienAnspruchDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtFerienAnspruchJahr
            // 
            this.edtFerienAnspruchJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFerienAnspruchJahr.DataMember = "Jahr";
            this.edtFerienAnspruchJahr.DataSource = this.qryBDEFerienAnspruch_XUser;
            this.edtFerienAnspruchJahr.Location = new System.Drawing.Point(136, 274);
            this.edtFerienAnspruchJahr.Name = "edtFerienAnspruchJahr";
            this.edtFerienAnspruchJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFerienAnspruchJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFerienAnspruchJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFerienAnspruchJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFerienAnspruchJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFerienAnspruchJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFerienAnspruchJahr.Properties.Appearance.Options.UseFont = true;
            this.edtFerienAnspruchJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFerienAnspruchJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFerienAnspruchJahr.Properties.DisplayFormat.FormatString = "0000";
            this.edtFerienAnspruchJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienAnspruchJahr.Properties.EditFormat.FormatString = "0000";
            this.edtFerienAnspruchJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtFerienAnspruchJahr.Properties.Mask.EditMask = "0000";
            this.edtFerienAnspruchJahr.Properties.MaxLength = 2;
            this.edtFerienAnspruchJahr.Properties.Precision = 0;
            this.edtFerienAnspruchJahr.Size = new System.Drawing.Size(74, 24);
            this.edtFerienAnspruchJahr.TabIndex = 2;
            // 
            // lblFerienAnspruchJahr
            // 
            this.lblFerienAnspruchJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFerienAnspruchJahr.Location = new System.Drawing.Point(6, 274);
            this.lblFerienAnspruchJahr.Name = "lblFerienAnspruchJahr";
            this.lblFerienAnspruchJahr.Size = new System.Drawing.Size(124, 24);
            this.lblFerienAnspruchJahr.TabIndex = 1;
            this.lblFerienAnspruchJahr.Text = "Jahr";
            this.lblFerienAnspruchJahr.UseCompatibleTextRendering = true;
            // 
            // grdBDEFerienAnspruch_XUser
            // 
            this.grdBDEFerienAnspruch_XUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBDEFerienAnspruch_XUser.DataSource = this.qryBDEFerienAnspruch_XUser;
            // 
            // 
            // 
            this.grdBDEFerienAnspruch_XUser.EmbeddedNavigator.Name = "";
            this.grdBDEFerienAnspruch_XUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDEFerienAnspruch_XUser.Location = new System.Drawing.Point(3, 3);
            this.grdBDEFerienAnspruch_XUser.MainView = this.grvBDEFerienAnspruch_XUser;
            this.grdBDEFerienAnspruch_XUser.Name = "grdBDEFerienAnspruch_XUser";
            this.grdBDEFerienAnspruch_XUser.Size = new System.Drawing.Size(876, 265);
            this.grdBDEFerienAnspruch_XUser.TabIndex = 0;
            this.grdBDEFerienAnspruch_XUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDEFerienAnspruch_XUser});
            // 
            // grvBDEFerienAnspruch_XUser
            // 
            this.grvBDEFerienAnspruch_XUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDEFerienAnspruch_XUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.Empty.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDEFerienAnspruch_XUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDEFerienAnspruch_XUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDEFerienAnspruch_XUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEFerienAnspruch_XUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEFerienAnspruch_XUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.OddRow.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDEFerienAnspruch_XUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.Row.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.Row.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEFerienAnspruch_XUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDEFerienAnspruch_XUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEFerienAnspruch_XUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDEFerienAnspruch_XUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDEFerienAnspruch_XUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFerienAnspruchBDEFerienAnspruch_XUserID,
            this.colFerienAnspruchJahr,
            this.colFerienAnspruchDatumVon,
            this.colFerienAnspruchDatumBis,
            this.colFerienAnspruchFerienAnspruchStdProJahr,
            this.colFerienAnspruchManualEdit});
            this.grvBDEFerienAnspruch_XUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDEFerienAnspruch_XUser.GridControl = this.grdBDEFerienAnspruch_XUser;
            this.grvBDEFerienAnspruch_XUser.Name = "grvBDEFerienAnspruch_XUser";
            this.grvBDEFerienAnspruch_XUser.OptionsBehavior.Editable = false;
            this.grvBDEFerienAnspruch_XUser.OptionsCustomization.AllowFilter = false;
            this.grvBDEFerienAnspruch_XUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDEFerienAnspruch_XUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDEFerienAnspruch_XUser.OptionsNavigation.UseTabKey = false;
            this.grvBDEFerienAnspruch_XUser.OptionsView.ColumnAutoWidth = false;
            this.grvBDEFerienAnspruch_XUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDEFerienAnspruch_XUser.OptionsView.ShowGroupPanel = false;
            this.grvBDEFerienAnspruch_XUser.OptionsView.ShowIndicator = false;
            // 
            // colFerienAnspruchBDEFerienAnspruch_XUserID
            // 
            this.colFerienAnspruchBDEFerienAnspruch_XUserID.Caption = "ID";
            this.colFerienAnspruchBDEFerienAnspruch_XUserID.FieldName = "BDEFerienanspruch_XUserID";
            this.colFerienAnspruchBDEFerienAnspruch_XUserID.Name = "colFerienAnspruchBDEFerienAnspruch_XUserID";
            this.colFerienAnspruchBDEFerienAnspruch_XUserID.Visible = true;
            this.colFerienAnspruchBDEFerienAnspruch_XUserID.VisibleIndex = 0;
            this.colFerienAnspruchBDEFerienAnspruch_XUserID.Width = 60;
            // 
            // colFerienAnspruchJahr
            // 
            this.colFerienAnspruchJahr.Caption = "Jahr";
            this.colFerienAnspruchJahr.FieldName = "Jahr";
            this.colFerienAnspruchJahr.Name = "colFerienAnspruchJahr";
            this.colFerienAnspruchJahr.Visible = true;
            this.colFerienAnspruchJahr.VisibleIndex = 1;
            this.colFerienAnspruchJahr.Width = 60;
            // 
            // colFerienAnspruchDatumVon
            // 
            this.colFerienAnspruchDatumVon.Caption = "Gültig ab";
            this.colFerienAnspruchDatumVon.FieldName = "DatumVon";
            this.colFerienAnspruchDatumVon.Name = "colFerienAnspruchDatumVon";
            this.colFerienAnspruchDatumVon.Visible = true;
            this.colFerienAnspruchDatumVon.VisibleIndex = 2;
            this.colFerienAnspruchDatumVon.Width = 80;
            // 
            // colFerienAnspruchDatumBis
            // 
            this.colFerienAnspruchDatumBis.Caption = "Gültig bis";
            this.colFerienAnspruchDatumBis.FieldName = "DatumBis";
            this.colFerienAnspruchDatumBis.Name = "colFerienAnspruchDatumBis";
            this.colFerienAnspruchDatumBis.Visible = true;
            this.colFerienAnspruchDatumBis.VisibleIndex = 3;
            this.colFerienAnspruchDatumBis.Width = 80;
            // 
            // colFerienAnspruchFerienAnspruchStdProJahr
            // 
            this.colFerienAnspruchFerienAnspruchStdProJahr.Caption = "Ferienanspruch pro Jahr";
            this.colFerienAnspruchFerienAnspruchStdProJahr.DisplayFormat.FormatString = "###0.0000";
            this.colFerienAnspruchFerienAnspruchStdProJahr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFerienAnspruchFerienAnspruchStdProJahr.FieldName = "FerienanspruchStdProJahr";
            this.colFerienAnspruchFerienAnspruchStdProJahr.Name = "colFerienAnspruchFerienAnspruchStdProJahr";
            this.colFerienAnspruchFerienAnspruchStdProJahr.Visible = true;
            this.colFerienAnspruchFerienAnspruchStdProJahr.VisibleIndex = 4;
            this.colFerienAnspruchFerienAnspruchStdProJahr.Width = 160;
            // 
            // colFerienAnspruchManualEdit
            // 
            this.colFerienAnspruchManualEdit.Caption = "Manuell";
            this.colFerienAnspruchManualEdit.FieldName = "ManualEdit";
            this.colFerienAnspruchManualEdit.Name = "colFerienAnspruchManualEdit";
            this.colFerienAnspruchManualEdit.Visible = true;
            this.colFerienAnspruchManualEdit.VisibleIndex = 5;
            this.colFerienAnspruchManualEdit.Width = 60;
            // 
            // tpgAusbezahlteUeberstunden
            // 
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.lblAusbezahlteUeberstundenAusbezahlteStdUnit);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.edtAusbezahlteUeberstundenAusbezahlteStd);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.lblAusbezahlteUeberstundenAusbezahlteStd);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.edtAusbezahlteUeberstundenDatumBis);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.lblAusbezahlteUeberstundenDatumBis);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.edtAusbezahlteUeberstundenDatumVon);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.lblAusbezahlteUeberstundenDatumVon);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.edtAusbezahlteUeberstundenJahr);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.lblAusbezahlteUeberstundenJahr);
            this.tpgAusbezahlteUeberstunden.Controls.Add(this.grdBDEAusbezahlteUeberstunden_XUser);
            this.tpgAusbezahlteUeberstunden.Location = new System.Drawing.Point(6, 6);
            this.tpgAusbezahlteUeberstunden.Name = "tpgAusbezahlteUeberstunden";
            this.tpgAusbezahlteUeberstunden.Size = new System.Drawing.Size(882, 397);
            this.tpgAusbezahlteUeberstunden.TabIndex = 0;
            this.tpgAusbezahlteUeberstunden.Title = "Ausbezahlte Überstunden";
            // 
            // lblAusbezahlteUeberstundenAusbezahlteStdUnit
            // 
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit.Location = new System.Drawing.Point(216, 364);
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit.Name = "lblAusbezahlteUeberstundenAusbezahlteStdUnit";
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit.Size = new System.Drawing.Size(35, 24);
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit.TabIndex = 9;
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit.Text = "Std.";
            this.lblAusbezahlteUeberstundenAusbezahlteStdUnit.UseCompatibleTextRendering = true;
            // 
            // edtAusbezahlteUeberstundenAusbezahlteStd
            // 
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusbezahlteUeberstundenAusbezahlteStd.DataMember = "AusbezahlteStd";
            this.edtAusbezahlteUeberstundenAusbezahlteStd.DataSource = this.qryBDEAusbezahlteUeberstunden_XUser;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Location = new System.Drawing.Point(136, 364);
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Name = "edtAusbezahlteUeberstundenAusbezahlteStd";
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Appearance.Options.UseFont = true;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.DisplayFormat.FormatString = "###0.0000";
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.EditFormat.FormatString = "###0.####";
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Mask.EditMask = "###0.####";
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.MaxLength = 2;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties.Precision = 4;
            this.edtAusbezahlteUeberstundenAusbezahlteStd.Size = new System.Drawing.Size(74, 24);
            this.edtAusbezahlteUeberstundenAusbezahlteStd.TabIndex = 8;
            // 
            // qryBDEAusbezahlteUeberstunden_XUser
            // 
            this.qryBDEAusbezahlteUeberstunden_XUser.HostControl = this;
            this.qryBDEAusbezahlteUeberstunden_XUser.TableName = "BDEAusbezahlteUeberstunden_XUser";
            this.qryBDEAusbezahlteUeberstunden_XUser.BeforePost += new System.EventHandler(this.qryBDEAusbezahlteUeberstunden_XUser_BeforePost);
            // 
            // lblAusbezahlteUeberstundenAusbezahlteStd
            // 
            this.lblAusbezahlteUeberstundenAusbezahlteStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusbezahlteUeberstundenAusbezahlteStd.Location = new System.Drawing.Point(6, 364);
            this.lblAusbezahlteUeberstundenAusbezahlteStd.Name = "lblAusbezahlteUeberstundenAusbezahlteStd";
            this.lblAusbezahlteUeberstundenAusbezahlteStd.Size = new System.Drawing.Size(124, 24);
            this.lblAusbezahlteUeberstundenAusbezahlteStd.TabIndex = 7;
            this.lblAusbezahlteUeberstundenAusbezahlteStd.Text = "Ausbezahlte Stunden";
            this.lblAusbezahlteUeberstundenAusbezahlteStd.UseCompatibleTextRendering = true;
            // 
            // edtAusbezahlteUeberstundenDatumBis
            // 
            this.edtAusbezahlteUeberstundenDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusbezahlteUeberstundenDatumBis.DataMember = "DatumBis";
            this.edtAusbezahlteUeberstundenDatumBis.DataSource = this.qryBDEAusbezahlteUeberstunden_XUser;
            this.edtAusbezahlteUeberstundenDatumBis.EditValue = null;
            this.edtAusbezahlteUeberstundenDatumBis.Location = new System.Drawing.Point(136, 334);
            this.edtAusbezahlteUeberstundenDatumBis.Name = "edtAusbezahlteUeberstundenDatumBis";
            this.edtAusbezahlteUeberstundenDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbezahlteUeberstundenDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAusbezahlteUeberstundenDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAusbezahlteUeberstundenDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbezahlteUeberstundenDatumBis.Properties.ShowToday = false;
            this.edtAusbezahlteUeberstundenDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtAusbezahlteUeberstundenDatumBis.TabIndex = 6;
            // 
            // lblAusbezahlteUeberstundenDatumBis
            // 
            this.lblAusbezahlteUeberstundenDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusbezahlteUeberstundenDatumBis.Location = new System.Drawing.Point(6, 334);
            this.lblAusbezahlteUeberstundenDatumBis.Name = "lblAusbezahlteUeberstundenDatumBis";
            this.lblAusbezahlteUeberstundenDatumBis.Size = new System.Drawing.Size(124, 24);
            this.lblAusbezahlteUeberstundenDatumBis.TabIndex = 5;
            this.lblAusbezahlteUeberstundenDatumBis.Text = "Gültig bis";
            this.lblAusbezahlteUeberstundenDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtAusbezahlteUeberstundenDatumVon
            // 
            this.edtAusbezahlteUeberstundenDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusbezahlteUeberstundenDatumVon.DataMember = "DatumVon";
            this.edtAusbezahlteUeberstundenDatumVon.DataSource = this.qryBDEAusbezahlteUeberstunden_XUser;
            this.edtAusbezahlteUeberstundenDatumVon.EditValue = null;
            this.edtAusbezahlteUeberstundenDatumVon.Location = new System.Drawing.Point(136, 304);
            this.edtAusbezahlteUeberstundenDatumVon.Name = "edtAusbezahlteUeberstundenDatumVon";
            this.edtAusbezahlteUeberstundenDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbezahlteUeberstundenDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAusbezahlteUeberstundenDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAusbezahlteUeberstundenDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbezahlteUeberstundenDatumVon.Properties.ShowToday = false;
            this.edtAusbezahlteUeberstundenDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtAusbezahlteUeberstundenDatumVon.TabIndex = 4;
            // 
            // lblAusbezahlteUeberstundenDatumVon
            // 
            this.lblAusbezahlteUeberstundenDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusbezahlteUeberstundenDatumVon.Location = new System.Drawing.Point(6, 304);
            this.lblAusbezahlteUeberstundenDatumVon.Name = "lblAusbezahlteUeberstundenDatumVon";
            this.lblAusbezahlteUeberstundenDatumVon.Size = new System.Drawing.Size(124, 24);
            this.lblAusbezahlteUeberstundenDatumVon.TabIndex = 3;
            this.lblAusbezahlteUeberstundenDatumVon.Text = "Gültig ab";
            this.lblAusbezahlteUeberstundenDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtAusbezahlteUeberstundenJahr
            // 
            this.edtAusbezahlteUeberstundenJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusbezahlteUeberstundenJahr.DataMember = "Jahr";
            this.edtAusbezahlteUeberstundenJahr.DataSource = this.qryBDEAusbezahlteUeberstunden_XUser;
            this.edtAusbezahlteUeberstundenJahr.Location = new System.Drawing.Point(136, 274);
            this.edtAusbezahlteUeberstundenJahr.Name = "edtAusbezahlteUeberstundenJahr";
            this.edtAusbezahlteUeberstundenJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAusbezahlteUeberstundenJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbezahlteUeberstundenJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbezahlteUeberstundenJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbezahlteUeberstundenJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbezahlteUeberstundenJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbezahlteUeberstundenJahr.Properties.Appearance.Options.UseFont = true;
            this.edtAusbezahlteUeberstundenJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusbezahlteUeberstundenJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbezahlteUeberstundenJahr.Properties.DisplayFormat.FormatString = "0000";
            this.edtAusbezahlteUeberstundenJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAusbezahlteUeberstundenJahr.Properties.EditFormat.FormatString = "0000";
            this.edtAusbezahlteUeberstundenJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAusbezahlteUeberstundenJahr.Properties.Mask.EditMask = "0000";
            this.edtAusbezahlteUeberstundenJahr.Properties.MaxLength = 2;
            this.edtAusbezahlteUeberstundenJahr.Properties.Precision = 0;
            this.edtAusbezahlteUeberstundenJahr.Size = new System.Drawing.Size(74, 24);
            this.edtAusbezahlteUeberstundenJahr.TabIndex = 2;
            // 
            // lblAusbezahlteUeberstundenJahr
            // 
            this.lblAusbezahlteUeberstundenJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusbezahlteUeberstundenJahr.Location = new System.Drawing.Point(6, 274);
            this.lblAusbezahlteUeberstundenJahr.Name = "lblAusbezahlteUeberstundenJahr";
            this.lblAusbezahlteUeberstundenJahr.Size = new System.Drawing.Size(124, 24);
            this.lblAusbezahlteUeberstundenJahr.TabIndex = 1;
            this.lblAusbezahlteUeberstundenJahr.Text = "Jahr";
            this.lblAusbezahlteUeberstundenJahr.UseCompatibleTextRendering = true;
            // 
            // grdBDEAusbezahlteUeberstunden_XUser
            // 
            this.grdBDEAusbezahlteUeberstunden_XUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBDEAusbezahlteUeberstunden_XUser.DataSource = this.qryBDEAusbezahlteUeberstunden_XUser;
            // 
            // 
            // 
            this.grdBDEAusbezahlteUeberstunden_XUser.EmbeddedNavigator.Name = "";
            this.grdBDEAusbezahlteUeberstunden_XUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBDEAusbezahlteUeberstunden_XUser.Location = new System.Drawing.Point(3, 3);
            this.grdBDEAusbezahlteUeberstunden_XUser.MainView = this.grvBDEAusbezahlteUeberstunden_XUser;
            this.grdBDEAusbezahlteUeberstunden_XUser.Name = "grdBDEAusbezahlteUeberstunden_XUser";
            this.grdBDEAusbezahlteUeberstunden_XUser.Size = new System.Drawing.Size(876, 265);
            this.grdBDEAusbezahlteUeberstunden_XUser.TabIndex = 0;
            this.grdBDEAusbezahlteUeberstunden_XUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBDEAusbezahlteUeberstunden_XUser});
            // 
            // grvBDEAusbezahlteUeberstunden_XUser
            // 
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Empty.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.OddRow.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Row.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.Row.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBDEAusbezahlteUeberstunden_XUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBDEAusbezahlteUeberstunden_XUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID,
            this.colAusbezahlteUeberstundenJahr,
            this.colAusbezahlteUeberstundenDatumVon,
            this.colAusbezahlteUeberstundenDatumBis,
            this.colAusbezahlteUeberstundenAusbezahlteStd,
            this.colAusbezahlteUeberstundenManualEdit});
            this.grvBDEAusbezahlteUeberstunden_XUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBDEAusbezahlteUeberstunden_XUser.GridControl = this.grdBDEAusbezahlteUeberstunden_XUser;
            this.grvBDEAusbezahlteUeberstunden_XUser.Name = "grvBDEAusbezahlteUeberstunden_XUser";
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsBehavior.Editable = false;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsCustomization.AllowFilter = false;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsNavigation.UseTabKey = false;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsView.ColumnAutoWidth = false;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsView.ShowGroupPanel = false;
            this.grvBDEAusbezahlteUeberstunden_XUser.OptionsView.ShowIndicator = false;
            // 
            // colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID
            // 
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID.Caption = "ID";
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID.FieldName = "BDEAusbezahlteUeberstunden_XUserID";
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID.Name = "colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID";
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID.Visible = true;
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID.VisibleIndex = 0;
            this.colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID.Width = 60;
            // 
            // colAusbezahlteUeberstundenJahr
            // 
            this.colAusbezahlteUeberstundenJahr.Caption = "Jahr";
            this.colAusbezahlteUeberstundenJahr.FieldName = "Jahr";
            this.colAusbezahlteUeberstundenJahr.Name = "colAusbezahlteUeberstundenJahr";
            this.colAusbezahlteUeberstundenJahr.Visible = true;
            this.colAusbezahlteUeberstundenJahr.VisibleIndex = 1;
            this.colAusbezahlteUeberstundenJahr.Width = 60;
            // 
            // colAusbezahlteUeberstundenDatumVon
            // 
            this.colAusbezahlteUeberstundenDatumVon.Caption = "Gültig ab";
            this.colAusbezahlteUeberstundenDatumVon.FieldName = "DatumVon";
            this.colAusbezahlteUeberstundenDatumVon.Name = "colAusbezahlteUeberstundenDatumVon";
            this.colAusbezahlteUeberstundenDatumVon.Visible = true;
            this.colAusbezahlteUeberstundenDatumVon.VisibleIndex = 2;
            this.colAusbezahlteUeberstundenDatumVon.Width = 80;
            // 
            // colAusbezahlteUeberstundenDatumBis
            // 
            this.colAusbezahlteUeberstundenDatumBis.Caption = "Gültig bis";
            this.colAusbezahlteUeberstundenDatumBis.FieldName = "DatumBis";
            this.colAusbezahlteUeberstundenDatumBis.Name = "colAusbezahlteUeberstundenDatumBis";
            this.colAusbezahlteUeberstundenDatumBis.Visible = true;
            this.colAusbezahlteUeberstundenDatumBis.VisibleIndex = 3;
            this.colAusbezahlteUeberstundenDatumBis.Width = 80;
            // 
            // colAusbezahlteUeberstundenAusbezahlteStd
            // 
            this.colAusbezahlteUeberstundenAusbezahlteStd.Caption = "Ausbezahlte Überstunden";
            this.colAusbezahlteUeberstundenAusbezahlteStd.DisplayFormat.FormatString = "###0.0000";
            this.colAusbezahlteUeberstundenAusbezahlteStd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAusbezahlteUeberstundenAusbezahlteStd.FieldName = "AusbezahlteStd";
            this.colAusbezahlteUeberstundenAusbezahlteStd.Name = "colAusbezahlteUeberstundenAusbezahlteStd";
            this.colAusbezahlteUeberstundenAusbezahlteStd.Visible = true;
            this.colAusbezahlteUeberstundenAusbezahlteStd.VisibleIndex = 4;
            this.colAusbezahlteUeberstundenAusbezahlteStd.Width = 160;
            // 
            // colAusbezahlteUeberstundenManualEdit
            // 
            this.colAusbezahlteUeberstundenManualEdit.Caption = "Manuell";
            this.colAusbezahlteUeberstundenManualEdit.FieldName = "ManualEdit";
            this.colAusbezahlteUeberstundenManualEdit.Name = "colAusbezahlteUeberstundenManualEdit";
            this.colAusbezahlteUeberstundenManualEdit.Visible = true;
            this.colAusbezahlteUeberstundenManualEdit.VisibleIndex = 5;
            this.colAusbezahlteUeberstundenManualEdit.Width = 60;
            // 
            // DlgUserBDEDetails
            // 
            this.ClientSize = new System.Drawing.Size(894, 562);
            this.Controls.Add(this.tabUserBDEDetails);
            this.Controls.Add(this.panTopWarning);
            this.Controls.Add(this.panTopInfo);
            this.Controls.Add(this.panBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgUserBDEDetails";
            this.Text = "Benutzer - BDE-Details";
            this.panTopInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserNameLbl)).EndInit();
            this.panTopWarning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWarningIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarningText)).EndInit();
            this.panBottom.ResumeLayout(false);
            this.tabUserBDEDetails.ResumeLayout(false);
            this.tpgFerienKuerzungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienKuerzungenFerienkuerzungStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienKuerzungenFerienkuerzungStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEFerienKuerzungen_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienKuerzungenFerienkuerzungStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienKuerzungenJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienKuerzungenJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEFerienKuerzungen_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEFerienKuerzungen_XUser)).EndInit();
            this.tpgSollProJahr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrTotalStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrTotalStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDESollStundenProJahr_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrTotalStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezemberStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrDezemberStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezemberStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovemberStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrNovemberStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovemberStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktoberStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrOktoberStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktoberStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptemberStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrSeptemberStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptemberStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugustStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrAugustStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugustStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuliStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJuliStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuliStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuniStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJuniStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuniStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaiStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrMaiStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaiStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAprilStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrAprilStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAprilStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerzStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrMaerzStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerzStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruarStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrFebruarStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruarStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuarStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJanuarStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuarStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDESollStundenProJahr_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDESollStundenProJahr_XUser)).EndInit();
            this.tpgSollProTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagSollStundenProTagUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProTagSollStundenProTag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDESollProTag_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagSollStundenProTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProTagDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProTagDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProTagDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDESollProTag_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDESollProTag_XUser)).EndInit();
            this.tpgPensum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumPensumProzentUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumPensumProzent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEPensum_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumPensumProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEPensum_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEPensum_XUser)).EndInit();
            this.tpgFerienAnspruch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchFerienAnspruchStdProJahrUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchFerienAnspruchStdProJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEFerienAnspruch_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchFerienAnspruchStdProJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFerienAnspruchJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFerienAnspruchJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEFerienAnspruch_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEFerienAnspruch_XUser)).EndInit();
            this.tpgAusbezahlteUeberstunden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenAusbezahlteStdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenAusbezahlteStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEAusbezahlteUeberstunden_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenAusbezahlteStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbezahlteUeberstundenJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbezahlteUeberstundenJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBDEAusbezahlteUeberstunden_XUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBDEAusbezahlteUeberstunden_XUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnCloseDialog;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbezahlteUeberstundenAusbezahlteStd;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbezahlteUeberstundenBDEAusbezahlteUeberstunden_XUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbezahlteUeberstundenDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbezahlteUeberstundenDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbezahlteUeberstundenJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbezahlteUeberstundenManualEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienAnspruchBDEFerienAnspruch_XUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienAnspruchDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienAnspruchDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienAnspruchFerienAnspruchStdProJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienAnspruchJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienAnspruchManualEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienKuerzungenFerienkuerzungStd;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienKuerzungenJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colFerienKuerzungenManualEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPensumBDEPensum_XUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colPensumDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colPensumDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colPensumManualEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPensumPensumProzent;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrAprilStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrAugustStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrDezemberStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrFebruarStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrJanuarStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrJuliStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrJuniStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrMaerzStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrMai;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrManualEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrNovemberStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrOktoberStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrSeptemberStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProJahrTotalStd;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProTagBDESollProTag_XUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProTagDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProTagDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProTagManualEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colSollProTagSollStundenProTag;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtAusbezahlteUeberstundenAusbezahlteStd;
        private KiSS4.Gui.KissDateEdit edtAusbezahlteUeberstundenDatumBis;
        private KiSS4.Gui.KissDateEdit edtAusbezahlteUeberstundenDatumVon;
        private KiSS4.Gui.KissCalcEdit edtAusbezahlteUeberstundenJahr;
        private KiSS4.Gui.KissDateEdit edtFerienAnspruchDatumBis;
        private KiSS4.Gui.KissDateEdit edtFerienAnspruchDatumVon;
        private KiSS4.Gui.KissCalcEdit edtFerienAnspruchFerienAnspruchStdProJahr;
        private KiSS4.Gui.KissCalcEdit edtFerienAnspruchJahr;
        private KiSS4.Gui.KissCalcEdit edtFerienKuerzungenFerienkuerzungStd;
        private KiSS4.Gui.KissCalcEdit edtFerienKuerzungenJahr;
        private KiSS4.Gui.KissDateEdit edtPensumDatumBis;
        private KiSS4.Gui.KissDateEdit edtPensumDatumVon;
        private KiSS4.Gui.KissCalcEdit edtPensumPensumProzent;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrAprilStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrAugustStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrDezemberStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrFebruarStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrJahr;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrJanuarStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrJuliStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrJuniStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrMaerzStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrMaiStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrNovemberStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrOktoberStd;
        private KiSS4.Gui.KissCalcEdit edtSollProJahrSeptemberStd;
        private KiSS4.Gui.KissDateEdit edtSollProTagDatumBis;
        private KiSS4.Gui.KissDateEdit edtSollProTagDatumVon;
        private KiSS4.Gui.KissCalcEdit edtSollProTagSollStundenProTag;
        private KiSS4.Gui.KissGrid grdBDEAusbezahlteUeberstunden_XUser;
        private KiSS4.Gui.KissGrid grdBDEFerienAnspruch_XUser;
        private KiSS4.Gui.KissGrid grdBDEFerienKuerzungen_XUser;
        private KiSS4.Gui.KissGrid grdBDEPensum_XUser;
        private KiSS4.Gui.KissGrid grdBDESollProTag_XUser;
        private KiSS4.Gui.KissGrid grdBDESollStundenProJahr_XUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDEAusbezahlteUeberstunden_XUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDEFerienAnspruch_XUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDEFerienKuerzungen_XUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDEPensum_XUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDESollProTag_XUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBDESollStundenProJahr_XUser;
        private KiSS4.Gui.KissLabel lblAusbezahlteUeberstundenAusbezahlteStd;
        private KiSS4.Gui.KissLabel lblAusbezahlteUeberstundenAusbezahlteStdUnit;
        private KiSS4.Gui.KissLabel lblAusbezahlteUeberstundenDatumBis;
        private KiSS4.Gui.KissLabel lblAusbezahlteUeberstundenDatumVon;
        private KiSS4.Gui.KissLabel lblAusbezahlteUeberstundenJahr;
        private KiSS4.Gui.KissLabel lblFerienAnspruchDatumBis;
        private KiSS4.Gui.KissLabel lblFerienAnspruchDatumVon;
        private KiSS4.Gui.KissLabel lblFerienAnspruchFerienAnspruchStdProJahr;
        private KiSS4.Gui.KissLabel lblFerienAnspruchFerienAnspruchStdProJahrUnit;
        private KiSS4.Gui.KissLabel lblFerienAnspruchJahr;
        private KiSS4.Gui.KissLabel lblFerienKuerzungenFerienkuerzungStd;
        private KiSS4.Gui.KissLabel lblFerienKuerzungenFerienkuerzungStdUnit;
        private KiSS4.Gui.KissLabel lblFerienKuerzungenJahr;
        private KiSS4.Gui.KissLabel lblPensumDatumBis;
        private KiSS4.Gui.KissLabel lblPensumDatumVon;
        private KiSS4.Gui.KissLabel lblPensumPensumProzent;
        private KiSS4.Gui.KissLabel lblPensumPensumProzentUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrAprilStd;
        private KiSS4.Gui.KissLabel lblSollProJahrAprilStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrAugustStd;
        private KiSS4.Gui.KissLabel lblSollProJahrAugustStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrDezemberStd;
        private KiSS4.Gui.KissLabel lblSollProJahrDezemberStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrFebruarStd;
        private KiSS4.Gui.KissLabel lblSollProJahrFebruarStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrInfo;
        private KiSS4.Gui.KissLabel lblSollProJahrJahr;
        private KiSS4.Gui.KissLabel lblSollProJahrJanuarStd;
        private KiSS4.Gui.KissLabel lblSollProJahrJanuarStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrJuliStd;
        private KiSS4.Gui.KissLabel lblSollProJahrJuliStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrJuniStd;
        private KiSS4.Gui.KissLabel lblSollProJahrJuniStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrMaerzStd;
        private KiSS4.Gui.KissLabel lblSollProJahrMaerzStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrMaiStd;
        private KiSS4.Gui.KissLabel lblSollProJahrMaiStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrNovemberStd;
        private KiSS4.Gui.KissLabel lblSollProJahrNovemberStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrOktoberStd;
        private KiSS4.Gui.KissLabel lblSollProJahrOktoberStdUnit;
        private KiSS4.Gui.KissLabel lblSollProJahrSeptemberStd;
        private KiSS4.Gui.KissLabel lblSollProJahrSeptemberStdUnit;
        private KiSS4.Gui.KissLabel lblSollProTagDatumBis;
        private KiSS4.Gui.KissLabel lblSollProTagDatumVon;
        private KiSS4.Gui.KissLabel lblSollProTagSollStundenProTag;
        private KiSS4.Gui.KissLabel lblSollProTagSollStundenProTagUnit;
        private KiSS4.Gui.KissLabel lblUserName;
        private KiSS4.Gui.KissLabel lblUserNameLbl;
        private KiSS4.Gui.KissLabel lblWarningText;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Panel panTopInfo;
        private System.Windows.Forms.Panel panTopWarning;
        private System.Windows.Forms.PictureBox picWarningIcon;
        private KiSS4.DB.SqlQuery qryBDEAusbezahlteUeberstunden_XUser;
        private KiSS4.DB.SqlQuery qryBDEFerienAnspruch_XUser;
        private KiSS4.DB.SqlQuery qryBDEFerienKuerzungen_XUser;
        private KiSS4.DB.SqlQuery qryBDEPensum_XUser;
        private KiSS4.DB.SqlQuery qryBDESollProTag_XUser;
        private KiSS4.DB.SqlQuery qryBDESollStundenProJahr_XUser;
        private KiSS4.Gui.KissTabControlEx tabUserBDEDetails;
        private SharpLibrary.WinControls.TabPageEx tpgAusbezahlteUeberstunden;
        private SharpLibrary.WinControls.TabPageEx tpgFerienAnspruch;
        private SharpLibrary.WinControls.TabPageEx tpgFerienKuerzungen;
        private SharpLibrary.WinControls.TabPageEx tpgPensum;
        private SharpLibrary.WinControls.TabPageEx tpgSollProJahr;
        private SharpLibrary.WinControls.TabPageEx tpgSollProTag;
        private Gui.KissButton btnTotalAufMonateVerteilen;
        private Gui.KissLabel lblSollProJahrTotalStdUnit;
        private Gui.KissCalcEdit edtSollProJahrTotalStd;
        private Gui.KissLabel lblSollProJahrTotalStd;
    }
}
