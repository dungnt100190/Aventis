using KiSS4.DB;
namespace KiSS4.Pendenzen
{
    partial class CtlPendenzenVerwaltung
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlPendenzenVerwaltung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pendenzPanel = new System.Windows.Forms.Panel();
            this.panAktionen = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSetBearbeitung = new KiSS4.Gui.KissButton();
            this.btnJump = new KiSS4.Gui.KissButton();
            this.btnForward = new KiSS4.Gui.KissButton();
            this.btnSetErledigt = new KiSS4.Gui.KissButton();
            this.edtFallLeistungBetrifftPerson = new KiSS4.Pendenzen.CtlFallLeistungBetrifftPerson();
            this.qryXTask = new KiSS4.DB.SqlQuery();
            this.ctlBearbeitungErledigt = new KiSS4.Common.CtlErfassungMutation();
            this.lblCreateDate = new KiSS4.Gui.KissLabel();
            this.lblResponseText = new KiSS4.Gui.KissLabel();
            this.lblReceiver = new KiSS4.Gui.KissLabel();
            this.lblSender = new KiSS4.Gui.KissLabel();
            this.lblExpirationDate = new KiSS4.Gui.KissLabel();
            this.lblBeschreibung = new KiSS4.Gui.KissLabel();
            this.lblSubject = new KiSS4.Gui.KissLabel();
            this.lblTaskTypeCode = new KiSS4.Gui.KissLabel();
            this.lblTaskStatusCode = new KiSS4.Gui.KissLabel();
            this.edtExpirationDate = new KiSS4.Gui.KissDateEdit();
            this.edtCreateDate = new KiSS4.Gui.KissDateEdit();
            this.edtResponseText = new KiSS4.Gui.KissMemoEdit();
            this.edtReceiver = new KiSS4.Gui.KissButtonEdit();
            this.edtSender = new KiSS4.Gui.KissTextEdit();
            this.edtBeschreibung = new KiSS4.Gui.KissMemoEdit();
            this.edtSubject = new KiSS4.Gui.KissTextEdit();
            this.edtTaskTypeCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtTaskStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheDoneDateBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBis4 = new KiSS4.Gui.KissLabel();
            this.edtSucheDoneDateVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDoneDate = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheStartDateBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBis3 = new KiSS4.Gui.KissLabel();
            this.edtSucheStartDateVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheStartDate = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheExpirationDateBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBis2 = new KiSS4.Gui.KissLabel();
            this.edtSucheExpirationDateVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheExpirationDate = new KiSS4.Gui.KissLabel();
            this.edtSucheTaskReceiverCode = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheReceiverID = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheReceiver = new KiSS4.Gui.KissLabel();
            this.edtSucheCreateDateBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBis = new KiSS4.Gui.KissLabel();
            this.edtSucheCreateDateVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheCreateDate = new KiSS4.Gui.KissLabel();
            this.edtSucheTaskSenderCode = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheSenderID = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheSender = new KiSS4.Gui.KissLabel();
            this.edtSucheSubject = new KiSS4.Gui.KissTextEdit();
            this.lblSucheSubject = new KiSS4.Gui.KissLabel();
            this.edtSucheTaskTypeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheTaskTypeCode = new KiSS4.Gui.KissLabel();
            this.edtSucheTaskStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheTaskStatusCode = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.grdXTask = new KiSS4.Gui.KissGrid();
            this.grvXTask = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAuswahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpirationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaFall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaskStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfasst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoneDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponseText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panListTop = new System.Windows.Forms.Panel();
            this.btnBatchApply = new KiSS4.Gui.KissButton();
            this.lblGewaehlteZeilen = new KiSS4.Gui.KissLabel();
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.panListBottom = new System.Windows.Forms.Panel();
            this.edtSucheFallID = new KiSS4.Gui.KissTextEdit();
            this.edtSucheLeistungID = new KiSS4.Gui.KissTextEdit();
            this.qryXTaskDetails = new KiSS4.DB.SqlQuery();
            this.lblSucheFallnummer = new KiSS4.Gui.KissLabel();
            this.edtSucheSAR = new KiSS4.Gui.KissButtonEdit();
            this.lblLeistungsverantwortlicher = new KiSS4.Gui.KissLabel();
            this.lblSucheOrgUnit = new KiSS4.Gui.KissLabel();
            this.edtSucheOrgUnit = new KiSS4.Gui.KissLookUpEdit();
            this.qryOrgUnit = new KiSS4.DB.SqlQuery();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.pendenzPanel.SuspendLayout();
            this.panAktionen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResponseText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExpirationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreateDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResponseText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschreibung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDoneDateBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDoneDateVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDoneDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStartDateBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStartDateVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheExpirationDateBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheExpirationDateVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskReceiverCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheReceiverID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCreateDateBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCreateDateVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskSenderCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSenderID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTaskTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTaskStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXTask)).BeginInit();
            this.panListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).BeginInit();
            this.panListBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTaskDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsverantwortlicher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(1007, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(1031, 309);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdXTask);
            this.tpgListe.Controls.Add(this.panListTop);
            this.tpgListe.Controls.Add(this.panListBottom);
            this.tpgListe.Size = new System.Drawing.Size(1019, 271);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheOrgUnit);
            this.tpgSuchen.Controls.Add(this.lblSucheOrgUnit);
            this.tpgSuchen.Controls.Add(this.edtSucheSAR);
            this.tpgSuchen.Controls.Add(this.lblLeistungsverantwortlicher);
            this.tpgSuchen.Controls.Add(this.lblSucheFallnummer);
            this.tpgSuchen.Controls.Add(this.edtSucheLeistungID);
            this.tpgSuchen.Controls.Add(this.edtSucheFallID);
            this.tpgSuchen.Controls.Add(this.edtSucheDoneDateBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBis4);
            this.tpgSuchen.Controls.Add(this.edtSucheDoneDateVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDoneDate);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheStartDateBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBis3);
            this.tpgSuchen.Controls.Add(this.edtSucheStartDateVon);
            this.tpgSuchen.Controls.Add(this.lblSucheStartDate);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.edtSucheExpirationDateBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBis2);
            this.tpgSuchen.Controls.Add(this.edtSucheExpirationDateVon);
            this.tpgSuchen.Controls.Add(this.lblSucheExpirationDate);
            this.tpgSuchen.Controls.Add(this.edtSucheTaskReceiverCode);
            this.tpgSuchen.Controls.Add(this.edtSucheReceiverID);
            this.tpgSuchen.Controls.Add(this.lblSucheReceiver);
            this.tpgSuchen.Controls.Add(this.edtSucheCreateDateBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBis);
            this.tpgSuchen.Controls.Add(this.edtSucheCreateDateVon);
            this.tpgSuchen.Controls.Add(this.lblSucheCreateDate);
            this.tpgSuchen.Controls.Add(this.edtSucheTaskSenderCode);
            this.tpgSuchen.Controls.Add(this.edtSucheSenderID);
            this.tpgSuchen.Controls.Add(this.lblSucheSender);
            this.tpgSuchen.Controls.Add(this.edtSucheSubject);
            this.tpgSuchen.Controls.Add(this.lblSucheSubject);
            this.tpgSuchen.Controls.Add(this.edtSucheTaskTypeCode);
            this.tpgSuchen.Controls.Add(this.lblSucheTaskTypeCode);
            this.tpgSuchen.Controls.Add(this.edtSucheTaskStatusCode);
            this.tpgSuchen.Controls.Add(this.lblSucheTaskStatusCode);
            this.tpgSuchen.Size = new System.Drawing.Size(1019, 271);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTaskStatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTaskStatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTaskTypeCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTaskTypeCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSubject, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSubject, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSenderID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTaskSenderCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheCreateDate, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheCreateDateVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheCreateDateBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheReceiver, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheReceiverID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTaskReceiverCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheExpirationDate, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheExpirationDateVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBis2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheExpirationDateBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStartDate, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStartDateVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBis3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStartDateBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDoneDate, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDoneDateVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBis4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDoneDateBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFallID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLeistungID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFallnummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsverantwortlicher, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOrgUnit, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrgUnit, 0);
            // 
            // pendenzPanel
            // 
            this.pendenzPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pendenzPanel.Controls.Add(this.panAktionen);
            this.pendenzPanel.Controls.Add(this.edtFallLeistungBetrifftPerson);
            this.pendenzPanel.Controls.Add(this.ctlBearbeitungErledigt);
            this.pendenzPanel.Controls.Add(this.lblCreateDate);
            this.pendenzPanel.Controls.Add(this.lblResponseText);
            this.pendenzPanel.Controls.Add(this.lblReceiver);
            this.pendenzPanel.Controls.Add(this.lblSender);
            this.pendenzPanel.Controls.Add(this.lblExpirationDate);
            this.pendenzPanel.Controls.Add(this.lblBeschreibung);
            this.pendenzPanel.Controls.Add(this.lblSubject);
            this.pendenzPanel.Controls.Add(this.lblTaskTypeCode);
            this.pendenzPanel.Controls.Add(this.lblTaskStatusCode);
            this.pendenzPanel.Controls.Add(this.edtExpirationDate);
            this.pendenzPanel.Controls.Add(this.edtCreateDate);
            this.pendenzPanel.Controls.Add(this.edtResponseText);
            this.pendenzPanel.Controls.Add(this.edtReceiver);
            this.pendenzPanel.Controls.Add(this.edtSender);
            this.pendenzPanel.Controls.Add(this.edtBeschreibung);
            this.pendenzPanel.Controls.Add(this.edtSubject);
            this.pendenzPanel.Controls.Add(this.edtTaskTypeCode);
            this.pendenzPanel.Controls.Add(this.edtTaskStatusCode);
            this.pendenzPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pendenzPanel.Location = new System.Drawing.Point(0, 309);
            this.pendenzPanel.Name = "pendenzPanel";
            this.pendenzPanel.Size = new System.Drawing.Size(1031, 402);
            this.pendenzPanel.TabIndex = 3;
            // 
            // panAktionen
            // 
            this.panAktionen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAktionen.Controls.Add(this.btnSetBearbeitung);
            this.panAktionen.Controls.Add(this.btnJump);
            this.panAktionen.Controls.Add(this.btnForward);
            this.panAktionen.Controls.Add(this.btnSetErledigt);
            this.panAktionen.Location = new System.Drawing.Point(401, 11);
            this.panAktionen.Name = "panAktionen";
            this.panAktionen.Size = new System.Drawing.Size(618, 24);
            this.panAktionen.TabIndex = 25;
            // 
            // btnSetBearbeitung
            // 
            this.btnSetBearbeitung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBearbeitung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetBearbeitung.Location = new System.Drawing.Point(0, 0);
            this.btnSetBearbeitung.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.btnSetBearbeitung.Name = "btnSetBearbeitung";
            this.btnSetBearbeitung.Size = new System.Drawing.Size(100, 24);
            this.btnSetBearbeitung.TabIndex = 21;
            this.btnSetBearbeitung.Text = "in Bearbeitung";
            this.btnSetBearbeitung.UseVisualStyleBackColor = false;
            this.btnSetBearbeitung.Click += new System.EventHandler(this.btnSetBearbeitung_Click);
            // 
            // btnJump
            // 
            this.btnJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJump.Enabled = false;
            this.btnJump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJump.Location = new System.Drawing.Point(106, 0);
            this.btnJump.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(90, 24);
            this.btnJump.TabIndex = 23;
            this.btnJump.Text = "zur Maske";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Location = new System.Drawing.Point(202, 0);
            this.btnForward.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(100, 24);
            this.btnForward.TabIndex = 24;
            this.btnForward.Text = "Weiterleiten";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnSetErledigt
            // 
            this.btnSetErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetErledigt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetErledigt.Location = new System.Drawing.Point(308, 0);
            this.btnSetErledigt.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.btnSetErledigt.Name = "btnSetErledigt";
            this.btnSetErledigt.Size = new System.Drawing.Size(98, 24);
            this.btnSetErledigt.TabIndex = 22;
            this.btnSetErledigt.Text = "Erledigt";
            this.btnSetErledigt.UseVisualStyleBackColor = false;
            this.btnSetErledigt.Click += new System.EventHandler(this.ActionButtonClick);
            // 
            // edtFallLeistungBetrifftPerson
            // 
            this.edtFallLeistungBetrifftPerson.ActiveSQLQuery = this.qryXTask;
            this.edtFallLeistungBetrifftPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFallLeistungBetrifftPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFallLeistungBetrifftPerson.DataMemberFaFallID = "Fallnummer";
            this.edtFallLeistungBetrifftPerson.DataSource = this.qryXTask;
            this.edtFallLeistungBetrifftPerson.Location = new System.Drawing.Point(6, 221);
            this.edtFallLeistungBetrifftPerson.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.edtFallLeistungBetrifftPerson.Name = "edtFallLeistungBetrifftPerson";
            this.edtFallLeistungBetrifftPerson.ShowSAR = true;
            this.edtFallLeistungBetrifftPerson.Size = new System.Drawing.Size(755, 114);
            this.edtFallLeistungBetrifftPerson.TabIndex = 13;
            // 
            // qryXTask
            // 
            this.qryXTask.CanDelete = true;
            this.qryXTask.CanInsert = true;
            this.qryXTask.CanUpdate = true;
            this.qryXTask.HostControl = this;
            this.qryXTask.IsIdentityInsert = false;
            this.qryXTask.TableName = "XTask";
            this.qryXTask.AfterDelete += new System.EventHandler(this.qryXTask_AfterDelete);
            this.qryXTask.AfterFill += new System.EventHandler(this.qryXTask_AfterFill);
            this.qryXTask.AfterInsert += new System.EventHandler(this.qryXTask_AfterInsert);
            this.qryXTask.AfterPost += new System.EventHandler(this.qryXTask_AfterPost);
            this.qryXTask.BeforeDeleteQuestion += new System.EventHandler(this.qryXTask_BeforeDeleteQuestion);
            this.qryXTask.BeforePost += new System.EventHandler(this.qryXTask_BeforePost);
            this.qryXTask.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryXTask_ColumnChanged);
            this.qryXTask.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryXTask_ColumnChanging);
            this.qryXTask.PositionChanged += new System.EventHandler(this.qryXTask_PositionChanged);
            // 
            // ctlBearbeitungErledigt
            // 
            this.ctlBearbeitungErledigt.ActiveSQLQuery = this.qryXTask;
            this.ctlBearbeitungErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlBearbeitungErledigt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlBearbeitungErledigt.DataMemberErfassungDatum = "StartDate";
            this.ctlBearbeitungErledigt.DataMemberErfassungUserID = "UserID_InBearbeitung";
            this.ctlBearbeitungErledigt.DataMemberMutationDatum = "DoneDate";
            this.ctlBearbeitungErledigt.DataMemberMutationUserID = "UserID_Erledigt";
            this.ctlBearbeitungErledigt.LabelLength = 60;
            this.ctlBearbeitungErledigt.LabelTextErfassung = "Bearbeitung";
            this.ctlBearbeitungErledigt.LabelTextMutation = "Erledigt";
            this.ctlBearbeitungErledigt.Location = new System.Drawing.Point(767, 281);
            this.ctlBearbeitungErledigt.Name = "ctlBearbeitungErledigt";
            this.ctlBearbeitungErledigt.Size = new System.Drawing.Size(252, 54);
            this.ctlBearbeitungErledigt.TabIndex = 20;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateDate.Location = new System.Drawing.Point(767, 161);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(80, 24);
            this.lblCreateDate.TabIndex = 16;
            this.lblCreateDate.Text = "Erfasst";
            this.lblCreateDate.UseCompatibleTextRendering = true;
            // 
            // lblResponseText
            // 
            this.lblResponseText.Location = new System.Drawing.Point(6, 341);
            this.lblResponseText.Name = "lblResponseText";
            this.lblResponseText.Size = new System.Drawing.Size(79, 24);
            this.lblResponseText.TabIndex = 14;
            this.lblResponseText.Text = "Antwort";
            this.lblResponseText.UseCompatibleTextRendering = true;
            // 
            // lblReceiver
            // 
            this.lblReceiver.Location = new System.Drawing.Point(6, 191);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(79, 24);
            this.lblReceiver.TabIndex = 10;
            this.lblReceiver.Text = "Empfänger";
            this.lblReceiver.UseCompatibleTextRendering = true;
            // 
            // lblSender
            // 
            this.lblSender.Location = new System.Drawing.Point(6, 161);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(79, 24);
            this.lblSender.TabIndex = 8;
            this.lblSender.Text = "Ersteller";
            this.lblSender.UseCompatibleTextRendering = true;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpirationDate.Location = new System.Drawing.Point(767, 191);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(80, 24);
            this.lblExpirationDate.TabIndex = 18;
            this.lblExpirationDate.Text = "Fällig";
            this.lblExpirationDate.UseCompatibleTextRendering = true;
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.Location = new System.Drawing.Point(6, 101);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(79, 24);
            this.lblBeschreibung.TabIndex = 6;
            this.lblBeschreibung.Text = "Beschreibung";
            this.lblBeschreibung.UseCompatibleTextRendering = true;
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(6, 71);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(79, 24);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Betreff";
            this.lblSubject.UseCompatibleTextRendering = true;
            // 
            // lblTaskTypeCode
            // 
            this.lblTaskTypeCode.Location = new System.Drawing.Point(6, 41);
            this.lblTaskTypeCode.Name = "lblTaskTypeCode";
            this.lblTaskTypeCode.Size = new System.Drawing.Size(79, 24);
            this.lblTaskTypeCode.TabIndex = 2;
            this.lblTaskTypeCode.Text = "Pendenz Typ";
            this.lblTaskTypeCode.UseCompatibleTextRendering = true;
            // 
            // lblTaskStatusCode
            // 
            this.lblTaskStatusCode.Location = new System.Drawing.Point(6, 11);
            this.lblTaskStatusCode.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblTaskStatusCode.Name = "lblTaskStatusCode";
            this.lblTaskStatusCode.Size = new System.Drawing.Size(79, 24);
            this.lblTaskStatusCode.TabIndex = 0;
            this.lblTaskStatusCode.Text = "Status";
            this.lblTaskStatusCode.UseCompatibleTextRendering = true;
            // 
            // edtExpirationDate
            // 
            this.edtExpirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExpirationDate.DataMember = "ExpirationDate";
            this.edtExpirationDate.DataSource = this.qryXTask;
            this.edtExpirationDate.EditValue = null;
            this.edtExpirationDate.Location = new System.Drawing.Point(853, 191);
            this.edtExpirationDate.Name = "edtExpirationDate";
            this.edtExpirationDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExpirationDate.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExpirationDate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExpirationDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExpirationDate.Properties.Appearance.Options.UseBackColor = true;
            this.edtExpirationDate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExpirationDate.Properties.Appearance.Options.UseFont = true;
            this.edtExpirationDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtExpirationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExpirationDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtExpirationDate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExpirationDate.Properties.Name = "kissDateEdit1.Properties";
            this.edtExpirationDate.Properties.ShowToday = false;
            this.edtExpirationDate.Size = new System.Drawing.Size(100, 24);
            this.edtExpirationDate.TabIndex = 19;
            // 
            // edtCreateDate
            // 
            this.edtCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtCreateDate.DataMember = "CreateDate";
            this.edtCreateDate.DataSource = this.qryXTask;
            this.edtCreateDate.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCreateDate.EditValue = null;
            this.edtCreateDate.Location = new System.Drawing.Point(853, 161);
            this.edtCreateDate.Name = "edtCreateDate";
            this.edtCreateDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtCreateDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCreateDate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCreateDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCreateDate.Properties.Appearance.Options.UseBackColor = true;
            this.edtCreateDate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCreateDate.Properties.Appearance.Options.UseFont = true;
            this.edtCreateDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtCreateDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCreateDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtCreateDate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCreateDate.Properties.ReadOnly = true;
            this.edtCreateDate.Properties.ShowToday = false;
            this.edtCreateDate.Size = new System.Drawing.Size(100, 24);
            this.edtCreateDate.TabIndex = 17;
            // 
            // edtResponseText
            // 
            this.edtResponseText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtResponseText.DataMember = "ResponseText";
            this.edtResponseText.DataSource = this.qryXTask;
            this.edtResponseText.Location = new System.Drawing.Point(120, 341);
            this.edtResponseText.Name = "edtResponseText";
            this.edtResponseText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtResponseText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtResponseText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtResponseText.Properties.Appearance.Options.UseBackColor = true;
            this.edtResponseText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtResponseText.Properties.Appearance.Options.UseFont = true;
            this.edtResponseText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtResponseText.Size = new System.Drawing.Size(899, 54);
            this.edtResponseText.TabIndex = 15;
            // 
            // edtReceiver
            // 
            this.edtReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtReceiver.DataMember = "Receiver";
            this.edtReceiver.DataSource = this.qryXTask;
            this.edtReceiver.Location = new System.Drawing.Point(120, 191);
            this.edtReceiver.Name = "edtReceiver";
            this.edtReceiver.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReceiver.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReceiver.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReceiver.Properties.Appearance.Options.UseBackColor = true;
            this.edtReceiver.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReceiver.Properties.Appearance.Options.UseFont = true;
            this.edtReceiver.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtReceiver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtReceiver.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReceiver.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtReceiver.Size = new System.Drawing.Size(641, 24);
            this.edtReceiver.TabIndex = 11;
            this.edtReceiver.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtReceiver_UserModifiedFld);
            // 
            // edtSender
            // 
            this.edtSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSender.DataMember = "Sender";
            this.edtSender.DataSource = this.qryXTask;
            this.edtSender.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSender.Location = new System.Drawing.Point(120, 161);
            this.edtSender.Name = "edtSender";
            this.edtSender.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSender.Properties.Appearance.Options.UseBackColor = true;
            this.edtSender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSender.Properties.Appearance.Options.UseFont = true;
            this.edtSender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSender.Properties.ReadOnly = true;
            this.edtSender.Size = new System.Drawing.Size(641, 24);
            this.edtSender.TabIndex = 9;
            this.edtSender.TabStop = false;
            // 
            // edtBeschreibung
            // 
            this.edtBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeschreibung.DataMember = "TaskDescription";
            this.edtBeschreibung.DataSource = this.qryXTask;
            this.edtBeschreibung.Location = new System.Drawing.Point(120, 101);
            this.edtBeschreibung.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.edtBeschreibung.Name = "edtBeschreibung";
            this.edtBeschreibung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeschreibung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeschreibung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeschreibung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeschreibung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeschreibung.Properties.Appearance.Options.UseFont = true;
            this.edtBeschreibung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeschreibung.Size = new System.Drawing.Size(899, 54);
            this.edtBeschreibung.TabIndex = 7;
            // 
            // edtSubject
            // 
            this.edtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSubject.DataMember = "Subject";
            this.edtSubject.DataSource = this.qryXTask;
            this.edtSubject.Location = new System.Drawing.Point(120, 71);
            this.edtSubject.Name = "edtSubject";
            this.edtSubject.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSubject.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSubject.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSubject.Properties.Appearance.Options.UseBackColor = true;
            this.edtSubject.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSubject.Properties.Appearance.Options.UseFont = true;
            this.edtSubject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSubject.Properties.Name = "kissTextEdit1.Properties";
            this.edtSubject.Size = new System.Drawing.Size(899, 24);
            this.edtSubject.TabIndex = 5;
            // 
            // edtTaskTypeCode
            // 
            this.edtTaskTypeCode.AllowNull = false;
            this.edtTaskTypeCode.DataMember = "TaskTypeCode";
            this.edtTaskTypeCode.DataSource = this.qryXTask;
            this.edtTaskTypeCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTaskTypeCode.Location = new System.Drawing.Point(120, 41);
            this.edtTaskTypeCode.LOVFilterWhereAppend = true;
            this.edtTaskTypeCode.LOVName = "TaskType";
            this.edtTaskTypeCode.Name = "edtTaskTypeCode";
            this.edtTaskTypeCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTaskTypeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTaskTypeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskTypeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtTaskTypeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTaskTypeCode.Properties.Appearance.Options.UseFont = true;
            this.edtTaskTypeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTaskTypeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskTypeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTaskTypeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTaskTypeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtTaskTypeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtTaskTypeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTaskTypeCode.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtTaskTypeCode.Properties.NullText = "";
            this.edtTaskTypeCode.Properties.ReadOnly = true;
            this.edtTaskTypeCode.Properties.ShowFooter = false;
            this.edtTaskTypeCode.Properties.ShowHeader = false;
            this.edtTaskTypeCode.Size = new System.Drawing.Size(532, 24);
            this.edtTaskTypeCode.TabIndex = 3;
            this.edtTaskTypeCode.EditValueChanged += new System.EventHandler(this.edtTaskTypeCode_EditValueChanged);
            // 
            // edtTaskStatusCode
            // 
            this.edtTaskStatusCode.AllowNull = false;
            this.edtTaskStatusCode.DataMember = "TaskStatusCode";
            this.edtTaskStatusCode.DataSource = this.qryXTask;
            this.edtTaskStatusCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTaskStatusCode.Location = new System.Drawing.Point(120, 11);
            this.edtTaskStatusCode.LOVName = "TaskStatus";
            this.edtTaskStatusCode.Name = "edtTaskStatusCode";
            this.edtTaskStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTaskStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTaskStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtTaskStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTaskStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtTaskStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTaskStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTaskStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTaskStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTaskStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTaskStatusCode.Properties.NullText = "";
            this.edtTaskStatusCode.Properties.ReadOnly = true;
            this.edtTaskStatusCode.Properties.ShowFooter = false;
            this.edtTaskStatusCode.Properties.ShowHeader = false;
            this.edtTaskStatusCode.Size = new System.Drawing.Size(275, 24);
            this.edtTaskStatusCode.TabIndex = 1;
            // 
            // edtSucheDoneDateBis
            // 
            this.edtSucheDoneDateBis.EditValue = null;
            this.edtSucheDoneDateBis.Location = new System.Drawing.Point(921, 220);
            this.edtSucheDoneDateBis.Name = "edtSucheDoneDateBis";
            this.edtSucheDoneDateBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDoneDateBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDoneDateBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDoneDateBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDoneDateBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDoneDateBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDoneDateBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDoneDateBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheDoneDateBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDoneDateBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheDoneDateBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDoneDateBis.Properties.Name = "kissDateEdit5.Properties";
            this.edtSucheDoneDateBis.Properties.ShowToday = false;
            this.edtSucheDoneDateBis.Size = new System.Drawing.Size(89, 24);
            this.edtSucheDoneDateBis.TabIndex = 38;
            // 
            // lblSucheBis4
            // 
            this.lblSucheBis4.Location = new System.Drawing.Point(903, 220);
            this.lblSucheBis4.Name = "lblSucheBis4";
            this.lblSucheBis4.Size = new System.Drawing.Size(12, 24);
            this.lblSucheBis4.TabIndex = 37;
            this.lblSucheBis4.Text = "-";
            this.lblSucheBis4.UseCompatibleTextRendering = true;
            // 
            // edtSucheDoneDateVon
            // 
            this.edtSucheDoneDateVon.EditValue = null;
            this.edtSucheDoneDateVon.Location = new System.Drawing.Point(804, 220);
            this.edtSucheDoneDateVon.Name = "edtSucheDoneDateVon";
            this.edtSucheDoneDateVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDoneDateVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDoneDateVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDoneDateVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDoneDateVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDoneDateVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDoneDateVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDoneDateVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheDoneDateVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDoneDateVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheDoneDateVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDoneDateVon.Properties.Name = "kissDateEdit4.Properties";
            this.edtSucheDoneDateVon.Properties.ShowToday = false;
            this.edtSucheDoneDateVon.Size = new System.Drawing.Size(89, 24);
            this.edtSucheDoneDateVon.TabIndex = 36;
            // 
            // lblSucheDoneDate
            // 
            this.lblSucheDoneDate.Location = new System.Drawing.Point(678, 220);
            this.lblSucheDoneDate.Name = "lblSucheDoneDate";
            this.lblSucheDoneDate.Size = new System.Drawing.Size(81, 24);
            this.lblSucheDoneDate.TabIndex = 35;
            this.lblSucheDoneDate.Text = "Erledigt";
            this.lblSucheDoneDate.UseCompatibleTextRendering = true;
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(131, 220);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(516, 24);
            this.edtSucheVorname.TabIndex = 16;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.Location = new System.Drawing.Point(30, 220);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(103, 24);
            this.lblSucheVorname.TabIndex = 15;
            this.lblSucheVorname.Text = "Vorname Klient/in";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            // 
            // edtSucheStartDateBis
            // 
            this.edtSucheStartDateBis.EditValue = null;
            this.edtSucheStartDateBis.Location = new System.Drawing.Point(921, 190);
            this.edtSucheStartDateBis.Name = "edtSucheStartDateBis";
            this.edtSucheStartDateBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheStartDateBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStartDateBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStartDateBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStartDateBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStartDateBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStartDateBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStartDateBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheStartDateBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheStartDateBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheStartDateBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStartDateBis.Properties.Name = "kissDateEdit5.Properties";
            this.edtSucheStartDateBis.Properties.ShowToday = false;
            this.edtSucheStartDateBis.Size = new System.Drawing.Size(89, 24);
            this.edtSucheStartDateBis.TabIndex = 34;
            // 
            // lblSucheBis3
            // 
            this.lblSucheBis3.Location = new System.Drawing.Point(903, 190);
            this.lblSucheBis3.Name = "lblSucheBis3";
            this.lblSucheBis3.Size = new System.Drawing.Size(14, 24);
            this.lblSucheBis3.TabIndex = 33;
            this.lblSucheBis3.Text = "-";
            this.lblSucheBis3.UseCompatibleTextRendering = true;
            // 
            // edtSucheStartDateVon
            // 
            this.edtSucheStartDateVon.EditValue = null;
            this.edtSucheStartDateVon.Location = new System.Drawing.Point(804, 190);
            this.edtSucheStartDateVon.Name = "edtSucheStartDateVon";
            this.edtSucheStartDateVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheStartDateVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStartDateVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStartDateVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStartDateVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStartDateVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStartDateVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStartDateVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheStartDateVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheStartDateVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheStartDateVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStartDateVon.Properties.Name = "kissDateEdit4.Properties";
            this.edtSucheStartDateVon.Properties.ShowToday = false;
            this.edtSucheStartDateVon.Size = new System.Drawing.Size(89, 24);
            this.edtSucheStartDateVon.TabIndex = 32;
            // 
            // lblSucheStartDate
            // 
            this.lblSucheStartDate.Location = new System.Drawing.Point(678, 190);
            this.lblSucheStartDate.Name = "lblSucheStartDate";
            this.lblSucheStartDate.Size = new System.Drawing.Size(81, 24);
            this.lblSucheStartDate.TabIndex = 31;
            this.lblSucheStartDate.Text = "Bearbeitung";
            this.lblSucheStartDate.UseCompatibleTextRendering = true;
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(131, 190);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(516, 24);
            this.edtSucheName.TabIndex = 14;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(30, 190);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(84, 24);
            this.lblSucheName.TabIndex = 13;
            this.lblSucheName.Text = "Name Klient/in";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtSucheExpirationDateBis
            // 
            this.edtSucheExpirationDateBis.EditValue = null;
            this.edtSucheExpirationDateBis.Location = new System.Drawing.Point(921, 160);
            this.edtSucheExpirationDateBis.Name = "edtSucheExpirationDateBis";
            this.edtSucheExpirationDateBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheExpirationDateBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheExpirationDateBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheExpirationDateBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheExpirationDateBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheExpirationDateBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheExpirationDateBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheExpirationDateBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheExpirationDateBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheExpirationDateBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheExpirationDateBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheExpirationDateBis.Properties.Name = "kissDateEdit5.Properties";
            this.edtSucheExpirationDateBis.Properties.ShowToday = false;
            this.edtSucheExpirationDateBis.Size = new System.Drawing.Size(89, 24);
            this.edtSucheExpirationDateBis.TabIndex = 30;
            // 
            // lblSucheBis2
            // 
            this.lblSucheBis2.Location = new System.Drawing.Point(903, 160);
            this.lblSucheBis2.Name = "lblSucheBis2";
            this.lblSucheBis2.Size = new System.Drawing.Size(12, 24);
            this.lblSucheBis2.TabIndex = 29;
            this.lblSucheBis2.Text = "-";
            this.lblSucheBis2.UseCompatibleTextRendering = true;
            // 
            // edtSucheExpirationDateVon
            // 
            this.edtSucheExpirationDateVon.EditValue = null;
            this.edtSucheExpirationDateVon.Location = new System.Drawing.Point(804, 160);
            this.edtSucheExpirationDateVon.Name = "edtSucheExpirationDateVon";
            this.edtSucheExpirationDateVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheExpirationDateVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheExpirationDateVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheExpirationDateVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheExpirationDateVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheExpirationDateVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheExpirationDateVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheExpirationDateVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheExpirationDateVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheExpirationDateVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheExpirationDateVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheExpirationDateVon.Properties.Name = "kissDateEdit4.Properties";
            this.edtSucheExpirationDateVon.Properties.ShowToday = false;
            this.edtSucheExpirationDateVon.Size = new System.Drawing.Size(89, 24);
            this.edtSucheExpirationDateVon.TabIndex = 28;
            // 
            // lblSucheExpirationDate
            // 
            this.lblSucheExpirationDate.Location = new System.Drawing.Point(678, 160);
            this.lblSucheExpirationDate.Name = "lblSucheExpirationDate";
            this.lblSucheExpirationDate.Size = new System.Drawing.Size(81, 24);
            this.lblSucheExpirationDate.TabIndex = 27;
            this.lblSucheExpirationDate.Text = "Fällig";
            this.lblSucheExpirationDate.UseCompatibleTextRendering = true;
            // 
            // edtSucheTaskReceiverCode
            // 
            this.edtSucheTaskReceiverCode.Location = new System.Drawing.Point(652, 160);
            this.edtSucheTaskReceiverCode.Name = "edtSucheTaskReceiverCode";
            this.edtSucheTaskReceiverCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheTaskReceiverCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTaskReceiverCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTaskReceiverCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTaskReceiverCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTaskReceiverCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTaskReceiverCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTaskReceiverCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheTaskReceiverCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTaskReceiverCode.Size = new System.Drawing.Size(14, 24);
            this.edtSucheTaskReceiverCode.TabIndex = 12;
            this.edtSucheTaskReceiverCode.Visible = false;
            // 
            // edtSucheReceiverID
            // 
            this.edtSucheReceiverID.Location = new System.Drawing.Point(131, 160);
            this.edtSucheReceiverID.Name = "edtSucheReceiverID";
            this.edtSucheReceiverID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheReceiverID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheReceiverID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheReceiverID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheReceiverID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheReceiverID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheReceiverID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSucheReceiverID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSucheReceiverID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheReceiverID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheReceiverID.Size = new System.Drawing.Size(516, 24);
            this.edtSucheReceiverID.TabIndex = 11;
            this.edtSucheReceiverID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheReceiverID_UserModifiedFld);
            // 
            // lblSucheReceiver
            // 
            this.lblSucheReceiver.Location = new System.Drawing.Point(30, 160);
            this.lblSucheReceiver.Name = "lblSucheReceiver";
            this.lblSucheReceiver.Size = new System.Drawing.Size(84, 24);
            this.lblSucheReceiver.TabIndex = 10;
            this.lblSucheReceiver.Text = "Empfänger";
            this.lblSucheReceiver.UseCompatibleTextRendering = true;
            // 
            // edtSucheCreateDateBis
            // 
            this.edtSucheCreateDateBis.EditValue = null;
            this.edtSucheCreateDateBis.Location = new System.Drawing.Point(921, 130);
            this.edtSucheCreateDateBis.Name = "edtSucheCreateDateBis";
            this.edtSucheCreateDateBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheCreateDateBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheCreateDateBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheCreateDateBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheCreateDateBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheCreateDateBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheCreateDateBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheCreateDateBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtSucheCreateDateBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheCreateDateBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtSucheCreateDateBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheCreateDateBis.Properties.Name = "kissDateEdit5.Properties";
            this.edtSucheCreateDateBis.Properties.ShowToday = false;
            this.edtSucheCreateDateBis.Size = new System.Drawing.Size(89, 24);
            this.edtSucheCreateDateBis.TabIndex = 26;
            // 
            // lblSucheBis
            // 
            this.lblSucheBis.Location = new System.Drawing.Point(903, 130);
            this.lblSucheBis.Name = "lblSucheBis";
            this.lblSucheBis.Size = new System.Drawing.Size(12, 24);
            this.lblSucheBis.TabIndex = 25;
            this.lblSucheBis.Text = "-";
            this.lblSucheBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheCreateDateVon
            // 
            this.edtSucheCreateDateVon.EditValue = null;
            this.edtSucheCreateDateVon.Location = new System.Drawing.Point(804, 130);
            this.edtSucheCreateDateVon.Name = "edtSucheCreateDateVon";
            this.edtSucheCreateDateVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheCreateDateVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheCreateDateVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheCreateDateVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheCreateDateVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheCreateDateVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheCreateDateVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheCreateDateVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSucheCreateDateVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheCreateDateVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSucheCreateDateVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheCreateDateVon.Properties.Name = "kissDateEdit4.Properties";
            this.edtSucheCreateDateVon.Properties.ShowToday = false;
            this.edtSucheCreateDateVon.Size = new System.Drawing.Size(89, 24);
            this.edtSucheCreateDateVon.TabIndex = 24;
            // 
            // lblSucheCreateDate
            // 
            this.lblSucheCreateDate.Location = new System.Drawing.Point(678, 130);
            this.lblSucheCreateDate.Name = "lblSucheCreateDate";
            this.lblSucheCreateDate.Size = new System.Drawing.Size(81, 24);
            this.lblSucheCreateDate.TabIndex = 23;
            this.lblSucheCreateDate.Text = "Erfasst";
            this.lblSucheCreateDate.UseCompatibleTextRendering = true;
            // 
            // edtSucheTaskSenderCode
            // 
            this.edtSucheTaskSenderCode.Location = new System.Drawing.Point(652, 130);
            this.edtSucheTaskSenderCode.Name = "edtSucheTaskSenderCode";
            this.edtSucheTaskSenderCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheTaskSenderCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTaskSenderCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTaskSenderCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTaskSenderCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTaskSenderCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTaskSenderCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTaskSenderCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheTaskSenderCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTaskSenderCode.Size = new System.Drawing.Size(14, 24);
            this.edtSucheTaskSenderCode.TabIndex = 9;
            this.edtSucheTaskSenderCode.Visible = false;
            // 
            // edtSucheSenderID
            // 
            this.edtSucheSenderID.Location = new System.Drawing.Point(131, 130);
            this.edtSucheSenderID.Name = "edtSucheSenderID";
            this.edtSucheSenderID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSenderID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSenderID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSenderID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSenderID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSenderID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSenderID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtSucheSenderID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtSucheSenderID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSenderID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheSenderID.Size = new System.Drawing.Size(516, 24);
            this.edtSucheSenderID.TabIndex = 8;
            this.edtSucheSenderID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheSenderID_UserModifiedFld);
            // 
            // lblSucheSender
            // 
            this.lblSucheSender.Location = new System.Drawing.Point(30, 130);
            this.lblSucheSender.Name = "lblSucheSender";
            this.lblSucheSender.Size = new System.Drawing.Size(84, 24);
            this.lblSucheSender.TabIndex = 7;
            this.lblSucheSender.Text = "Ersteller";
            this.lblSucheSender.UseCompatibleTextRendering = true;
            // 
            // edtSucheSubject
            // 
            this.edtSucheSubject.Location = new System.Drawing.Point(131, 100);
            this.edtSucheSubject.Name = "edtSucheSubject";
            this.edtSucheSubject.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSubject.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSubject.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSubject.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSubject.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSubject.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSubject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheSubject.Properties.Name = "kissTextEdit3.Properties";
            this.edtSucheSubject.Size = new System.Drawing.Size(516, 24);
            this.edtSucheSubject.TabIndex = 6;
            // 
            // lblSucheSubject
            // 
            this.lblSucheSubject.Location = new System.Drawing.Point(30, 100);
            this.lblSucheSubject.Name = "lblSucheSubject";
            this.lblSucheSubject.Size = new System.Drawing.Size(84, 24);
            this.lblSucheSubject.TabIndex = 5;
            this.lblSucheSubject.Text = "Betreff";
            this.lblSucheSubject.UseCompatibleTextRendering = true;
            // 
            // edtSucheTaskTypeCode
            // 
            this.edtSucheTaskTypeCode.Location = new System.Drawing.Point(131, 70);
            this.edtSucheTaskTypeCode.LOVName = "TaskType";
            this.edtSucheTaskTypeCode.Name = "edtSucheTaskTypeCode";
            this.edtSucheTaskTypeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTaskTypeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTaskTypeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTaskTypeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTaskTypeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTaskTypeCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTaskTypeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTaskTypeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTaskTypeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTaskTypeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTaskTypeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtSucheTaskTypeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtSucheTaskTypeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTaskTypeCode.Properties.Name = "kissLookUpEdit7.Properties";
            this.edtSucheTaskTypeCode.Properties.NullText = "";
            this.edtSucheTaskTypeCode.Properties.ShowFooter = false;
            this.edtSucheTaskTypeCode.Properties.ShowHeader = false;
            this.edtSucheTaskTypeCode.Size = new System.Drawing.Size(516, 24);
            this.edtSucheTaskTypeCode.TabIndex = 4;
            // 
            // lblSucheTaskTypeCode
            // 
            this.lblSucheTaskTypeCode.Location = new System.Drawing.Point(30, 70);
            this.lblSucheTaskTypeCode.Name = "lblSucheTaskTypeCode";
            this.lblSucheTaskTypeCode.Size = new System.Drawing.Size(84, 24);
            this.lblSucheTaskTypeCode.TabIndex = 3;
            this.lblSucheTaskTypeCode.Text = "Pendenz Typ";
            this.lblSucheTaskTypeCode.UseCompatibleTextRendering = true;
            // 
            // edtSucheTaskStatusCode
            // 
            this.edtSucheTaskStatusCode.Location = new System.Drawing.Point(131, 40);
            this.edtSucheTaskStatusCode.LOVFilter = "Code <> 4";
            this.edtSucheTaskStatusCode.LOVFilterWhereAppend = true;
            this.edtSucheTaskStatusCode.LOVName = "TaskStatus";
            this.edtSucheTaskStatusCode.Name = "edtSucheTaskStatusCode";
            this.edtSucheTaskStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTaskStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTaskStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTaskStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTaskStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTaskStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTaskStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTaskStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTaskStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTaskStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTaskStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtSucheTaskStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtSucheTaskStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTaskStatusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheTaskStatusCode.Properties.DisplayMember = "Text";
            this.edtSucheTaskStatusCode.Properties.DropDownRows = 1;
            this.edtSucheTaskStatusCode.Properties.NullText = "";
            this.edtSucheTaskStatusCode.Properties.ShowFooter = false;
            this.edtSucheTaskStatusCode.Properties.ShowHeader = false;
            this.edtSucheTaskStatusCode.Properties.ValueMember = "Code";
            this.edtSucheTaskStatusCode.Size = new System.Drawing.Size(204, 24);
            this.edtSucheTaskStatusCode.TabIndex = 1;
            // 
            // lblSucheTaskStatusCode
            // 
            this.lblSucheTaskStatusCode.Location = new System.Drawing.Point(30, 40);
            this.lblSucheTaskStatusCode.Name = "lblSucheTaskStatusCode";
            this.lblSucheTaskStatusCode.Size = new System.Drawing.Size(84, 24);
            this.lblSucheTaskStatusCode.TabIndex = 0;
            this.lblSucheTaskStatusCode.Text = "Status";
            this.lblSucheTaskStatusCode.UseCompatibleTextRendering = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "FAL_BaPersonID";
            this.ctlGotoFall.DataSource = this.qryXTask;
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 3);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 24);
            this.ctlGotoFall.TabIndex = 3;
            // 
            // grdXTask
            // 
            this.grdXTask.DataSource = this.qryXTask;
            this.grdXTask.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdXTask.EmbeddedNavigator.Name = "kissGrid1.EmbeddedNavigator";
            this.grdXTask.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdXTask.Location = new System.Drawing.Point(0, 32);
            this.grdXTask.MainView = this.grvXTask;
            this.grdXTask.Name = "grdXTask";
            this.grdXTask.Size = new System.Drawing.Size(1019, 207);
            this.grdXTask.TabIndex = 2;
            this.grdXTask.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXTask});
            // 
            // grvXTask
            // 
            this.grvXTask.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXTask.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.Empty.Options.UseBackColor = true;
            this.grvXTask.Appearance.Empty.Options.UseFont = true;
            this.grvXTask.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXTask.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.EvenRow.Options.UseFont = true;
            this.grvXTask.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXTask.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvXTask.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXTask.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXTask.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXTask.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXTask.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvXTask.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXTask.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXTask.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXTask.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXTask.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvXTask.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvXTask.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXTask.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXTask.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXTask.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXTask.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXTask.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.GroupRow.Options.UseFont = true;
            this.grvXTask.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXTask.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXTask.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXTask.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXTask.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXTask.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXTask.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXTask.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXTask.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXTask.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXTask.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXTask.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvXTask.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXTask.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.OddRow.Options.UseFont = true;
            this.grvXTask.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXTask.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.Row.Options.UseBackColor = true;
            this.grvXTask.Appearance.Row.Options.UseFont = true;
            this.grvXTask.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXTask.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvXTask.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXTask.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvXTask.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvXTask.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXTask.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXTask.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuswahl,
            this.colExpirationDate,
            this.colSubject,
            this.colLeistung,
            this.colFaFall,
            this.colFallnummer,
            this.colBaPerson,
            this.colSender,
            this.colReceiver,
            this.colTaskStatusCode,
            this.colErfasst,
            this.colStartDate,
            this.colDoneDate,
            this.colResponseText});
            this.grvXTask.GridControl = this.grdXTask;
            this.grvXTask.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvXTask.Name = "grvXTask";
            this.grvXTask.OptionsCustomization.AllowFilter = false;
            this.grvXTask.OptionsFilter.AllowFilterEditor = false;
            this.grvXTask.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXTask.OptionsMenu.EnableColumnMenu = false;
            this.grvXTask.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXTask.OptionsView.ColumnAutoWidth = false;
            this.grvXTask.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXTask.OptionsView.ShowGroupPanel = false;
            this.grvXTask.LostFocus += new System.EventHandler(this.grvXTask_LostFocus);
            // 
            // colAuswahl
            // 
            this.colAuswahl.Caption = "Ausw.";
            this.colAuswahl.FieldName = "Auswahl";
            this.colAuswahl.Name = "colAuswahl";
            this.colAuswahl.Visible = true;
            this.colAuswahl.VisibleIndex = 0;
            this.colAuswahl.Width = 47;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colExpirationDate.AppearanceCell.Options.UseBackColor = true;
            this.colExpirationDate.Caption = "Fällig";
            this.colExpirationDate.FieldName = "ExpirationDate";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.OptionsColumn.AllowEdit = false;
            this.colExpirationDate.Visible = true;
            this.colExpirationDate.VisibleIndex = 1;
            // 
            // colSubject
            // 
            this.colSubject.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSubject.AppearanceCell.Options.UseBackColor = true;
            this.colSubject.Caption = "Betreff";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.OptionsColumn.AllowEdit = false;
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 2;
            this.colSubject.Width = 135;
            // 
            // colLeistung
            // 
            this.colLeistung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colLeistung.AppearanceCell.Options.UseBackColor = true;
            this.colLeistung.Caption = "Leistung";
            this.colLeistung.FieldName = "ModulID";
            this.colLeistung.Name = "colLeistung";
            this.colLeistung.OptionsColumn.AllowEdit = false;
            this.colLeistung.Visible = true;
            this.colLeistung.VisibleIndex = 3;
            // 
            // colFaFall
            // 
            this.colFaFall.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colFaFall.AppearanceCell.Options.UseBackColor = true;
            this.colFaFall.Caption = "Fallträger";
            this.colFaFall.FieldName = "FaFall";
            this.colFaFall.Name = "colFaFall";
            this.colFaFall.OptionsColumn.AllowEdit = false;
            this.colFaFall.Visible = true;
            this.colFaFall.VisibleIndex = 4;
            this.colFaFall.Width = 90;
            // 
            // colFallnummer
            // 
            this.colFallnummer.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colFallnummer.AppearanceCell.Options.UseBackColor = true;
            this.colFallnummer.Caption = "Fallnummer";
            this.colFallnummer.FieldName = "Fallnummer";
            this.colFallnummer.Name = "colFallnummer";
            this.colFallnummer.OptionsColumn.AllowEdit = false;
            this.colFallnummer.Visible = true;
            this.colFallnummer.VisibleIndex = 5;
            this.colFallnummer.Width = 90;
            // 
            // colBaPerson
            // 
            this.colBaPerson.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBaPerson.AppearanceCell.Options.UseBackColor = true;
            this.colBaPerson.Caption = "Person";
            this.colBaPerson.FieldName = "PersonBP";
            this.colBaPerson.Name = "colBaPerson";
            this.colBaPerson.OptionsColumn.AllowEdit = false;
            this.colBaPerson.Visible = true;
            this.colBaPerson.VisibleIndex = 6;
            this.colBaPerson.Width = 90;
            // 
            // colSender
            // 
            this.colSender.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSender.AppearanceCell.Options.UseBackColor = true;
            this.colSender.Caption = "Ersteller";
            this.colSender.FieldName = "Sender";
            this.colSender.Name = "colSender";
            this.colSender.OptionsColumn.AllowEdit = false;
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 7;
            this.colSender.Width = 125;
            // 
            // colReceiver
            // 
            this.colReceiver.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colReceiver.AppearanceCell.Options.UseBackColor = true;
            this.colReceiver.Caption = "Empfänger";
            this.colReceiver.FieldName = "Receiver";
            this.colReceiver.Name = "colReceiver";
            this.colReceiver.OptionsColumn.AllowEdit = false;
            this.colReceiver.Visible = true;
            this.colReceiver.VisibleIndex = 8;
            this.colReceiver.Width = 125;
            // 
            // colTaskStatusCode
            // 
            this.colTaskStatusCode.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colTaskStatusCode.AppearanceCell.Options.UseBackColor = true;
            this.colTaskStatusCode.Caption = "Status";
            this.colTaskStatusCode.FieldName = "TaskStatusCode";
            this.colTaskStatusCode.Name = "colTaskStatusCode";
            this.colTaskStatusCode.OptionsColumn.AllowEdit = false;
            this.colTaskStatusCode.Visible = true;
            this.colTaskStatusCode.VisibleIndex = 9;
            this.colTaskStatusCode.Width = 46;
            // 
            // colErfasst
            // 
            this.colErfasst.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colErfasst.AppearanceCell.Options.UseBackColor = true;
            this.colErfasst.Caption = "Erfasst";
            this.colErfasst.FieldName = "CreateDate";
            this.colErfasst.Name = "colErfasst";
            this.colErfasst.OptionsColumn.AllowEdit = false;
            this.colErfasst.Visible = true;
            this.colErfasst.VisibleIndex = 10;
            // 
            // colStartDate
            // 
            this.colStartDate.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colStartDate.AppearanceCell.Options.UseBackColor = true;
            this.colStartDate.Caption = "Bearbeitung";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsColumn.AllowEdit = false;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 11;
            this.colStartDate.Width = 80;
            // 
            // colDoneDate
            // 
            this.colDoneDate.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDoneDate.AppearanceCell.Options.UseBackColor = true;
            this.colDoneDate.Caption = "Erledigt";
            this.colDoneDate.FieldName = "DoneDate";
            this.colDoneDate.Name = "colDoneDate";
            this.colDoneDate.OptionsColumn.AllowEdit = false;
            this.colDoneDate.Visible = true;
            this.colDoneDate.VisibleIndex = 12;
            // 
            // colResponseText
            // 
            this.colResponseText.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colResponseText.AppearanceCell.Options.UseBackColor = true;
            this.colResponseText.Caption = "Antwort";
            this.colResponseText.FieldName = "ResponseText";
            this.colResponseText.Name = "colResponseText";
            this.colResponseText.OptionsColumn.AllowEdit = false;
            this.colResponseText.Visible = true;
            this.colResponseText.VisibleIndex = 13;
            // 
            // panListTop
            // 
            this.panListTop.Controls.Add(this.btnBatchApply);
            this.panListTop.Controls.Add(this.lblGewaehlteZeilen);
            this.panListTop.Controls.Add(this.btnSelectNone);
            this.panListTop.Controls.Add(this.btnSelectAll);
            this.panListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panListTop.Location = new System.Drawing.Point(0, 0);
            this.panListTop.Name = "panListTop";
            this.panListTop.Size = new System.Drawing.Size(1019, 32);
            this.panListTop.TabIndex = 4;
            // 
            // btnBatchApply
            // 
            this.btnBatchApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchApply.Location = new System.Drawing.Point(916, 5);
            this.btnBatchApply.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnBatchApply.Name = "btnBatchApply";
            this.btnBatchApply.Size = new System.Drawing.Size(100, 24);
            this.btnBatchApply.TabIndex = 3;
            this.btnBatchApply.Text = "Verarbeiten...";
            this.btnBatchApply.UseCompatibleTextRendering = true;
            this.btnBatchApply.UseVisualStyleBackColor = false;
            this.btnBatchApply.Click += new System.EventHandler(this.btnBatchApply_Click);
            // 
            // lblGewaehlteZeilen
            // 
            this.lblGewaehlteZeilen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGewaehlteZeilen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGewaehlteZeilen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGewaehlteZeilen.Location = new System.Drawing.Point(66, 6);
            this.lblGewaehlteZeilen.Name = "lblGewaehlteZeilen";
            this.lblGewaehlteZeilen.Size = new System.Drawing.Size(844, 24);
            this.lblGewaehlteZeilen.TabIndex = 2;
            this.lblGewaehlteZeilen.Text = "Ausgewählte Zeilen: <Anzahl>";
            this.lblGewaehlteZeilen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGewaehlteZeilen.UseCompatibleTextRendering = true;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.Location = new System.Drawing.Point(36, 6);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 1;
            this.btnSelectNone.UseCompatibleTextRendering = true;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 6);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // panListBottom
            // 
            this.panListBottom.Controls.Add(this.ctlGotoFall);
            this.panListBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panListBottom.Location = new System.Drawing.Point(0, 239);
            this.panListBottom.Name = "panListBottom";
            this.panListBottom.Size = new System.Drawing.Size(1019, 32);
            this.panListBottom.TabIndex = 5;
            // 
            // edtSucheFallID
            // 
            this.edtSucheFallID.Location = new System.Drawing.Point(804, 40);
            this.edtSucheFallID.Name = "edtSucheFallID";
            this.edtSucheFallID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFallID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFallID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFallID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFallID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFallID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFallID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFallID.Size = new System.Drawing.Size(206, 24);
            this.edtSucheFallID.TabIndex = 18;
            this.edtSucheFallID.TabStop = false;
            // 
            // edtSucheLeistungID
            // 
            this.edtSucheLeistungID.Location = new System.Drawing.Point(341, 40);
            this.edtSucheLeistungID.Name = "edtSucheLeistungID";
            this.edtSucheLeistungID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLeistungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLeistungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLeistungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLeistungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLeistungID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLeistungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLeistungID.Size = new System.Drawing.Size(17, 24);
            this.edtSucheLeistungID.TabIndex = 2;
            this.edtSucheLeistungID.TabStop = false;
            this.edtSucheLeistungID.Visible = false;
            // 
            // qryXTaskDetails
            // 
            this.qryXTaskDetails.CanDelete = true;
            this.qryXTaskDetails.CanInsert = true;
            this.qryXTaskDetails.CanUpdate = true;
            this.qryXTaskDetails.HostControl = this;
            this.qryXTaskDetails.IsIdentityInsert = false;
            this.qryXTaskDetails.SelectStatement = resources.GetString("qryXTaskDetails.SelectStatement");
            this.qryXTaskDetails.TableName = "XTask";
            // 
            // lblSucheFallnummer
            // 
            this.lblSucheFallnummer.Location = new System.Drawing.Point(678, 40);
            this.lblSucheFallnummer.Name = "lblSucheFallnummer";
            this.lblSucheFallnummer.Size = new System.Drawing.Size(81, 24);
            this.lblSucheFallnummer.TabIndex = 17;
            this.lblSucheFallnummer.Text = "Fallnummer";
            this.lblSucheFallnummer.UseCompatibleTextRendering = true;
            // 
            // edtSucheSAR
            // 
            this.edtSucheSAR.Location = new System.Drawing.Point(804, 70);
            this.edtSucheSAR.Name = "edtSucheSAR";
            this.edtSucheSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSAR.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheSAR.Size = new System.Drawing.Size(206, 24);
            this.edtSucheSAR.TabIndex = 20;
            this.edtSucheSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheSAR_UserModifiedFld);
            // 
            // lblLeistungsverantwortlicher
            // 
            this.lblLeistungsverantwortlicher.Location = new System.Drawing.Point(678, 70);
            this.lblLeistungsverantwortlicher.Name = "lblLeistungsverantwortlicher";
            this.lblLeistungsverantwortlicher.Size = new System.Drawing.Size(101, 24);
            this.lblLeistungsverantwortlicher.TabIndex = 19;
            this.lblLeistungsverantwortlicher.Text = "Leistungsverantw.";
            this.lblLeistungsverantwortlicher.UseCompatibleTextRendering = true;
            // 
            // lblSucheOrgUnit
            // 
            this.lblSucheOrgUnit.Location = new System.Drawing.Point(678, 100);
            this.lblSucheOrgUnit.Name = "lblSucheOrgUnit";
            this.lblSucheOrgUnit.Size = new System.Drawing.Size(119, 24);
            this.lblSucheOrgUnit.TabIndex = 21;
            this.lblSucheOrgUnit.Text = "Organisationseinheit";
            this.lblSucheOrgUnit.UseCompatibleTextRendering = true;
            // 
            // edtSucheOrgUnit
            // 
            this.edtSucheOrgUnit.Location = new System.Drawing.Point(804, 100);
            this.edtSucheOrgUnit.Name = "edtSucheOrgUnit";
            this.edtSucheOrgUnit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrgUnit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrgUnit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrgUnit.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrgUnit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrgUnit.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheOrgUnit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheOrgUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheOrgUnit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheOrgUnit.Properties.Name = "kissLookUpEdit7.Properties";
            this.edtSucheOrgUnit.Properties.NullText = "";
            this.edtSucheOrgUnit.Properties.ShowFooter = false;
            this.edtSucheOrgUnit.Properties.ShowHeader = false;
            this.edtSucheOrgUnit.Size = new System.Drawing.Size(206, 24);
            this.edtSucheOrgUnit.TabIndex = 22;
            // 
            // qryOrgUnit
            // 
            this.qryOrgUnit.HostControl = this;
            this.qryOrgUnit.IsIdentityInsert = false;
            this.qryOrgUnit.SelectStatement = "SELECT Code = NULL,\r\n       Text = NULL\r\nUNION ALL\r\nSELECT Code = OrgUnitID,\r\n   " +
    "    Text = ItemName\r\nFROM XOrgUnit\r\nORDER BY Text";
            // 
            // CtlPendenzenVerwaltung
            // 
            this.ActiveSQLQuery = this.qryXTask;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pendenzPanel);
            this.Name = "CtlPendenzenVerwaltung";
            this.Size = new System.Drawing.Size(1031, 711);
            this.Load += new System.EventHandler(this.CtlPendenzenVerwaltung_Load);
            this.Controls.SetChildIndex(this.pendenzPanel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.pendenzPanel.ResumeLayout(false);
            this.panAktionen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResponseText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExpirationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreateDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResponseText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschreibung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDoneDateBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDoneDateVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDoneDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStartDateBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStartDateVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheExpirationDateBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheExpirationDateVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskReceiverCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheReceiverID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCreateDateBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCreateDateVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskSenderCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSenderID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTaskTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTaskStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTaskStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXTask)).EndInit();
            this.panListTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).EndInit();
            this.panListBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTaskDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsverantwortlicher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).EndInit();
            this.ResumeLayout(false);

        }

        

        
        #endregion

        private System.Windows.Forms.Panel pendenzPanel;
        private KiSS4.Gui.KissLabel lblCreateDate;
        private KiSS4.Gui.KissLabel lblResponseText;
        private KiSS4.Gui.KissLabel lblReceiver;
        private KiSS4.Gui.KissLabel lblSender;
        private KiSS4.Gui.KissLabel lblExpirationDate;
        private KiSS4.Gui.KissLabel lblBeschreibung;
        private KiSS4.Gui.KissLabel lblSubject;
        private KiSS4.Gui.KissLabel lblTaskTypeCode;
        private KiSS4.Gui.KissLabel lblTaskStatusCode;
        private KiSS4.Gui.KissDateEdit edtExpirationDate;
        private KiSS4.Gui.KissDateEdit edtCreateDate;
        private KiSS4.Gui.KissMemoEdit edtResponseText;
        private KiSS4.Gui.KissButtonEdit edtReceiver;
        private KiSS4.Gui.KissTextEdit edtSender;
        private KiSS4.Gui.KissMemoEdit edtBeschreibung;
        private KiSS4.Gui.KissTextEdit edtSubject;
        private KiSS4.Gui.KissLookUpEdit edtTaskTypeCode;
        private KiSS4.Gui.KissButton btnForward;
        private KiSS4.Gui.KissButton btnJump;
        private KiSS4.Gui.KissButton btnSetErledigt;
        private KiSS4.Gui.KissButton btnSetBearbeitung;
        private KiSS4.Gui.KissLookUpEdit edtTaskStatusCode;
        private KiSS4.Gui.KissDateEdit edtSucheDoneDateBis;
        private KiSS4.Gui.KissLabel lblSucheBis4;
        private KiSS4.Gui.KissDateEdit edtSucheDoneDateVon;
        private KiSS4.Gui.KissLabel lblSucheDoneDate;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissDateEdit edtSucheStartDateBis;
        private KiSS4.Gui.KissLabel lblSucheBis3;
        private KiSS4.Gui.KissDateEdit edtSucheStartDateVon;
        private KiSS4.Gui.KissLabel lblSucheStartDate;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissDateEdit edtSucheExpirationDateBis;
        private KiSS4.Gui.KissLabel lblSucheBis2;
        private KiSS4.Gui.KissDateEdit edtSucheExpirationDateVon;
        private KiSS4.Gui.KissLabel lblSucheExpirationDate;
        private KiSS4.Gui.KissCalcEdit edtSucheTaskReceiverCode;
        private KiSS4.Gui.KissButtonEdit edtSucheReceiverID;
        private KiSS4.Gui.KissLabel lblSucheReceiver;
        private KiSS4.Gui.KissDateEdit edtSucheCreateDateBis;
        private KiSS4.Gui.KissLabel lblSucheBis;
        private KiSS4.Gui.KissDateEdit edtSucheCreateDateVon;
        private KiSS4.Gui.KissLabel lblSucheCreateDate;
        private KiSS4.Gui.KissCalcEdit edtSucheTaskSenderCode;
        private KiSS4.Gui.KissButtonEdit edtSucheSenderID;
        private KiSS4.Gui.KissLabel lblSucheSender;
        private KiSS4.Gui.KissTextEdit edtSucheSubject;
        private KiSS4.Gui.KissLabel lblSucheSubject;
        private KiSS4.Gui.KissLookUpEdit edtSucheTaskTypeCode;
        private KiSS4.Gui.KissLabel lblSucheTaskTypeCode;
        private KiSS4.Gui.KissLookUpEdit edtSucheTaskStatusCode;
        private KiSS4.Gui.KissLabel lblSucheTaskStatusCode;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissGrid grdXTask;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXTask;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswahl;
        private DevExpress.XtraGrid.Columns.GridColumn colExpirationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colFaFall;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiver;
        private DevExpress.XtraGrid.Columns.GridColumn colTaskStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDoneDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResponseText;
        private System.Windows.Forms.Panel panListBottom;
        private System.Windows.Forms.Panel panListTop;
        private KiSS4.Gui.KissButton btnBatchApply;
        private KiSS4.Gui.KissLabel lblGewaehlteZeilen;
        private KiSS4.Gui.KissButton btnSelectNone;
        private KiSS4.Gui.KissButton btnSelectAll;
        private KiSS4.DB.SqlQuery qryXTask;
        private KiSS4.Gui.KissTextEdit edtSucheFallID;
        private KiSS4.Gui.KissTextEdit edtSucheLeistungID;
        private DB.SqlQuery qryXTaskDetails;
        private Common.CtlErfassungMutation ctlBearbeitungErledigt;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colFallnummer;
        private CtlFallLeistungBetrifftPerson edtFallLeistungBetrifftPerson;
        private Gui.KissLookUpEdit edtSucheOrgUnit;
        private Gui.KissLabel lblSucheOrgUnit;
        private Gui.KissButtonEdit edtSucheSAR;
        private Gui.KissLabel lblLeistungsverantwortlicher;
        private Gui.KissLabel lblSucheFallnummer;
        private DB.SqlQuery qryOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colErfasst;
        private System.Windows.Forms.FlowLayoutPanel panAktionen;
    }
}
