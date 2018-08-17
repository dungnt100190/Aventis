#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using KiSS4.DB;
using KiSS4.FAMOZ.PSCDServices;
using System;

#endregion


namespace KiSS4.Administration.ZH
{
    public class CtlPscdLog : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colClass;
        private DevExpress.XtraGrid.Columns.GridColumn colFehler;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colMsgID;
        private DevExpress.XtraGrid.Columns.GridColumn colPscdCallIDDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colReturnMsg;
        private DevExpress.XtraGrid.Columns.GridColumn colService;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colURL;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colWinLogonName;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edPrimaryKey;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissTextEdit edtSucheFehlertext;
        private KiSS4.Gui.KissCheckEdit edtSucheNurFehler;
        private KiSS4.Gui.KissGrid grdPscdCall;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPscdCall;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPscdCallMsg;
        private KiSS4.Gui.KissLabel lbPrimaryKey;
        private KiSS4.Gui.KissLabel lblAmount;
        private KiSS4.Gui.KissLabel lblRowCount;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheFehlertext;
        private KiSS4.Gui.KissButton btnServerVersionCheck;
        private KiSS4.Gui.KissButton btnCacheLeeren;
        private KiSS4.DB.SqlQuery qryPscdCall;

        #endregion

        #region Constructors

        public CtlPscdLog()
        {
            this.InitializeComponent();
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlPscdLog));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grvPscdCallMsg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMsgID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPscdCallIDDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPscdCall = new KiSS4.Gui.KissGrid();
            this.qryPscdCall = new KiSS4.DB.SqlQuery(this.components);
            this.grvPscdCall = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReturnMsg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFehler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colURL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWinLogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblAmount = new KiSS4.Gui.KissLabel();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSucheFehlertext = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheFehlertext = new KiSS4.Gui.KissTextEdit();
            this.edtSucheNurFehler = new KiSS4.Gui.KissCheckEdit();
            this.lbPrimaryKey = new KiSS4.Gui.KissLabel();
            this.edPrimaryKey = new KiSS4.Gui.KissTextEdit();
            this.btnServerVersionCheck = new KiSS4.Gui.KissButton();
            this.btnCacheLeeren = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPscdCallMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPscdCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPscdCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPscdCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFehlertext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFehlertext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurFehler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbPrimaryKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPrimaryKey.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(800, 500);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.lblRowCount);
            this.tpgListe.Controls.Add(this.lblAmount);
            this.tpgListe.Controls.Add(this.grdPscdCall);
            this.tpgListe.Size = new System.Drawing.Size(788, 462);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.btnCacheLeeren);
            this.tpgSuchen.Controls.Add(this.btnServerVersionCheck);
            this.tpgSuchen.Controls.Add(this.edPrimaryKey);
            this.tpgSuchen.Controls.Add(this.lbPrimaryKey);
            this.tpgSuchen.Controls.Add(this.edtSucheNurFehler);
            this.tpgSuchen.Controls.Add(this.edtSucheFehlertext);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheFehlertext);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 462);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFehlertext, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFehlertext, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNurFehler, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbPrimaryKey, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edPrimaryKey, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnServerVersionCheck, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnCacheLeeren, 0);
            // 
            // grvPscdCallMsg
            // 
            this.grvPscdCallMsg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMsgID,
            this.colSeverity,
            this.colClass,
            this.colPscdCallIDDetail});
            this.grvPscdCallMsg.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPscdCallMsg.GridControl = this.grdPscdCall;
            this.grvPscdCallMsg.Name = "grvPscdCallMsg";
            this.grvPscdCallMsg.OptionsBehavior.Editable = false;
            this.grvPscdCallMsg.OptionsCustomization.AllowFilter = false;
            this.grvPscdCallMsg.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPscdCallMsg.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPscdCallMsg.OptionsNavigation.UseTabKey = false;
            this.grvPscdCallMsg.OptionsView.ColumnAutoWidth = false;
            this.grvPscdCallMsg.OptionsView.ShowGroupPanel = false;
            this.grvPscdCallMsg.OptionsView.ShowIndicator = false;
            // 
            // colMsgID
            // 
            this.colMsgID.Caption = "ID";
            this.colMsgID.FieldName = "PscdCallReturnMsgID";
            this.colMsgID.Name = "colMsgID";
            this.colMsgID.Visible = true;
            this.colMsgID.VisibleIndex = 0;
            // 
            // colSeverity
            // 
            this.colSeverity.Caption = "Typ";
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.Name = "colSeverity";
            this.colSeverity.Visible = true;
            this.colSeverity.VisibleIndex = 1;
            // 
            // colClass
            // 
            this.colClass.Caption = "Klasse";
            this.colClass.FieldName = "MessageClass";
            this.colClass.Name = "colClass";
            this.colClass.Visible = true;
            this.colClass.VisibleIndex = 2;
            // 
            // colPscdCallIDDetail
            // 
            this.colPscdCallIDDetail.Caption = "PscdCallID";
            this.colPscdCallIDDetail.FieldName = "PSCDCallID";
            this.colPscdCallIDDetail.Name = "colPscdCallIDDetail";
            this.colPscdCallIDDetail.Visible = true;
            this.colPscdCallIDDetail.VisibleIndex = 3;
            // 
            // grdPscdCall
            // 
            this.grdPscdCall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPscdCall.DataSource = this.qryPscdCall;
            this.grdPscdCall.EmbeddedNavigator.Name = "";
            this.grdPscdCall.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            gridLevelNode1.LevelTemplate = this.grvPscdCallMsg;
            gridLevelNode1.RelationName = "Messages";
            this.grdPscdCall.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdPscdCall.Location = new System.Drawing.Point(0, 25);
            this.grdPscdCall.MainView = this.grvPscdCall;
            this.grdPscdCall.Name = "grdPscdCall";
            this.grdPscdCall.Size = new System.Drawing.Size(785, 437);
            this.grdPscdCall.TabIndex = 0;
            this.grdPscdCall.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPscdCall,
            this.grvPscdCallMsg});
            // 
            // qryPscdCall
            // 
            this.qryPscdCall.HostControl = this;
            this.qryPscdCall.SelectStatement = resources.GetString("qryPscdCall.SelectStatement");
            this.qryPscdCall.TableName = "PscdCall";
            this.qryPscdCall.AfterFill += new System.EventHandler(this.qryPscdCall_AfterFill);
            // 
            // grvPscdCall
            // 
            this.grvPscdCall.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPscdCall.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.Empty.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.Empty.Options.UseFont = true;
            this.grvPscdCall.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPscdCall.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.EvenRow.Options.UseFont = true;
            this.grvPscdCall.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPscdCall.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPscdCall.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPscdCall.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPscdCall.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPscdCall.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPscdCall.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPscdCall.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPscdCall.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPscdCall.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPscdCall.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPscdCall.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPscdCall.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.GroupRow.Options.UseFont = true;
            this.grvPscdCall.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPscdCall.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPscdCall.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPscdCall.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPscdCall.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPscdCall.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPscdCall.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPscdCall.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPscdCall.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPscdCall.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPscdCall.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPscdCall.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.OddRow.Options.UseFont = true;
            this.grvPscdCall.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPscdCall.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.Row.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.Row.Options.UseFont = true;
            this.grvPscdCall.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPscdCall.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPscdCall.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPscdCall.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPscdCall.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPscdCall.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPscdCall.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPscdCall.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPscdCall.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPscdCall.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colStartTime,
            this.colService,
            this.colKey,
            this.colReturnMsg,
            this.colTime,
            this.colUser,
            this.colFehler,
            this.colURL,
            this.colWinLogonName});
            this.grvPscdCall.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPscdCall.GridControl = this.grdPscdCall;
            this.grvPscdCall.Name = "grvPscdCall";
            this.grvPscdCall.OptionsBehavior.Editable = false;
            this.grvPscdCall.OptionsCustomization.AllowFilter = false;
            this.grvPscdCall.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPscdCall.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPscdCall.OptionsNavigation.UseTabKey = false;
            this.grvPscdCall.OptionsView.ColumnAutoWidth = false;
            this.grvPscdCall.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPscdCall.OptionsView.ShowGroupPanel = false;
            this.grvPscdCall.OptionsView.ShowIndicator = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "PscdCallID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 83;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "Startzeit";
            this.colStartTime.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 1;
            this.colStartTime.Width = 125;
            // 
            // colService
            // 
            this.colService.Caption = "Service";
            this.colService.FieldName = "ServiceName";
            this.colService.Name = "colService";
            this.colService.Visible = true;
            this.colService.VisibleIndex = 2;
            this.colService.Width = 222;
            // 
            // colKey
            // 
            this.colKey.Caption = "PrimaryKey";
            this.colKey.FieldName = "PrimaryKey";
            this.colKey.Name = "colKey";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 3;
            this.colKey.Width = 97;
            // 
            // colReturnMsg
            // 
            this.colReturnMsg.Caption = "ReturnMsg";
            this.colReturnMsg.FieldName = "ReturnMsg";
            this.colReturnMsg.Name = "colReturnMsg";
            this.colReturnMsg.Visible = true;
            this.colReturnMsg.VisibleIndex = 4;
            this.colReturnMsg.Width = 95;
            // 
            // colTime
            // 
            this.colTime.Caption = "Zeit (ms)";
            this.colTime.FieldName = "ElapsedMilliseconds";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 5;
            this.colTime.Width = 60;
            // 
            // colUser
            // 
            this.colUser.Caption = "User";
            this.colUser.FieldName = "LogonName";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 6;
            // 
            // colFehler
            // 
            this.colFehler.Caption = "Fehlermeldung";
            this.colFehler.FieldName = "ExceptionMsg";
            this.colFehler.Name = "colFehler";
            this.colFehler.Visible = true;
            this.colFehler.VisibleIndex = 7;
            this.colFehler.Width = 185;
            // 
            // colURL
            // 
            this.colURL.Caption = "URL";
            this.colURL.FieldName = "ServiceURL";
            this.colURL.Name = "colURL";
            this.colURL.Visible = true;
            this.colURL.VisibleIndex = 8;
            this.colURL.Width = 400;
            // 
            // colWinLogonName
            // 
            this.colWinLogonName.Caption = "WinLogonName";
            this.colWinLogonName.FieldName = "UserWinLogonName";
            this.colWinLogonName.Name = "colWinLogonName";
            this.colWinLogonName.Visible = true;
            this.colWinLogonName.VisibleIndex = 9;
            this.colWinLogonName.Width = 100;
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.Location = new System.Drawing.Point(579, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Anzahl Datens�tze:";
            this.lblAmount.UseCompatibleTextRendering = true;
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Location = new System.Drawing.Point(685, 0);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(100, 23);
            this.lblRowCount.TabIndex = 2;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(8, 66);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(100, 23);
            this.lblSucheDatumVon.TabIndex = 1;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(8, 96);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(100, 23);
            this.lblSucheDatumBis.TabIndex = 2;
            this.lblSucheDatumBis.Text = "Datum bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheFehlertext
            // 
            this.lblSucheFehlertext.Location = new System.Drawing.Point(8, 156);
            this.lblSucheFehlertext.Name = "lblSucheFehlertext";
            this.lblSucheFehlertext.Size = new System.Drawing.Size(116, 24);
            this.lblSucheFehlertext.TabIndex = 3;
            this.lblSucheFehlertext.Text = "Text in Fehlermeldung";
            this.lblSucheFehlertext.UseCompatibleTextRendering = true;
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(128, 66);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumVon.TabIndex = 4;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(128, 96);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 5;
            // 
            // edtSucheFehlertext
            // 
            this.edtSucheFehlertext.Location = new System.Drawing.Point(128, 156);
            this.edtSucheFehlertext.Name = "edtSucheFehlertext";
            this.edtSucheFehlertext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFehlertext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFehlertext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFehlertext.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFehlertext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFehlertext.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFehlertext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFehlertext.Size = new System.Drawing.Size(182, 24);
            this.edtSucheFehlertext.TabIndex = 6;
            // 
            // edtSucheNurFehler
            // 
            this.edtSucheNurFehler.EditValue = false;
            this.edtSucheNurFehler.Location = new System.Drawing.Point(128, 187);
            this.edtSucheNurFehler.Name = "edtSucheNurFehler";
            this.edtSucheNurFehler.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSucheNurFehler.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNurFehler.Properties.Caption = "nur Fehlermeldungen ausgeben";
            this.edtSucheNurFehler.Size = new System.Drawing.Size(182, 19);
            this.edtSucheNurFehler.TabIndex = 7;
            // 
            // lbPrimaryKey
            // 
            this.lbPrimaryKey.Location = new System.Drawing.Point(8, 126);
            this.lbPrimaryKey.Name = "lbPrimaryKey";
            this.lbPrimaryKey.Size = new System.Drawing.Size(116, 24);
            this.lbPrimaryKey.TabIndex = 8;
            this.lbPrimaryKey.Text = "Primary Key";
            this.lbPrimaryKey.UseCompatibleTextRendering = true;
            // 
            // edPrimaryKey
            // 
            this.edPrimaryKey.Location = new System.Drawing.Point(128, 126);
            this.edPrimaryKey.Name = "edPrimaryKey";
            this.edPrimaryKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edPrimaryKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edPrimaryKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edPrimaryKey.Properties.Appearance.Options.UseBackColor = true;
            this.edPrimaryKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edPrimaryKey.Properties.Appearance.Options.UseFont = true;
            this.edPrimaryKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edPrimaryKey.Size = new System.Drawing.Size(182, 24);
            this.edPrimaryKey.TabIndex = 9;
            // 
            // btnServerVersionCheck
            // 
            this.btnServerVersionCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnServerVersionCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerVersionCheck.Location = new System.Drawing.Point(8, 276);
            this.btnServerVersionCheck.Name = "btnServerVersionCheck";
            this.btnServerVersionCheck.Size = new System.Drawing.Size(266, 24);
            this.btnServerVersionCheck.TabIndex = 10;
            this.btnServerVersionCheck.Text = "Pr�fe Version des KiSS-PSCD-Webservices";
            this.btnServerVersionCheck.UseCompatibleTextRendering = true;
            this.btnServerVersionCheck.UseVisualStyleBackColor = false;
            this.btnServerVersionCheck.Click += new System.EventHandler(this.btnServerVersionCheck_Click);
            // 
            // btnCacheLeeren
            // 
            this.btnCacheLeeren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCacheLeeren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCacheLeeren.Location = new System.Drawing.Point(8, 306);
            this.btnCacheLeeren.Name = "btnCacheLeeren";
            this.btnCacheLeeren.Size = new System.Drawing.Size(266, 24);
            this.btnCacheLeeren.TabIndex = 11;
            this.btnCacheLeeren.Text = "Cache leeren";
            this.btnCacheLeeren.UseCompatibleTextRendering = true;
            this.btnCacheLeeren.UseVisualStyleBackColor = false;
            this.btnCacheLeeren.Click += new System.EventHandler(this.btnCacheLeeren_Click);
            // 
            // CtlPscdLog
            // 
            this.ActiveSQLQuery = this.qryPscdCall;
            this.Name = "CtlPscdLog";
            this.Load += new System.EventHandler(this.CtlPscdLog_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvPscdCallMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPscdCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPscdCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPscdCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFehlertext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFehlertext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurFehler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbPrimaryKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPrimaryKey.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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

        #region Private Methods

        private void CtlPscdLog_Load(object sender, System.EventArgs e)
        {
            // qryPscdCall.Fill();
        }

        private void qryPscdCall_AfterFill(object sender, System.EventArgs e)
        {
            //System.Data.DataSet ds = this.qryPscdCall.DataSet;
            lblRowCount.Text =  qryPscdCall.DataSet.Tables[0].Rows.Count.ToString();
            
            //ds.Relations.Add("Fehlermeldungen",
            qryPscdCall.DataSet.Relations.Add("Fehlermeldungen",
                qryPscdCall.DataSet.Tables[0].Columns["PscdCallID"],
                qryPscdCall.DataSet.Tables[1].Columns["PscdCallID"]);
        }

        #endregion

        private void btnServerVersionCheck_Click(object sender, System.EventArgs e)
        {
            try
            {
                KissMsg.ShowInfo(string.Format("Der KiSS-PSCD-Webservice hat die Version {0}", PSCDInterface.GetServerVersion()));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Fehler beim Pr�fen der KiSS-PSCD-Webservice-Version", ex);
            }
        }

        private void btnCacheLeeren_Click(object sender, EventArgs e)
        {
            PSCDInterface.CacheLeeren();
        }
    }
}