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

#endregion

using System;
using System.Data;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.ZH
{
    public class CtlIbanGenerieren : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnGotoInstitution;
        private KiSS4.Gui.KissButton btnGotoPerson;
        private KiSS4.Gui.KissButton btnStart;
        private DevExpress.XtraGrid.Columns.GridColumn colBCL;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colNameEmpfaenger;
        private DevExpress.XtraGrid.Columns.GridColumn colOE;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAuswahl;
        private KiSS4.Gui.KissCalcEdit edtToDo;
        private KiSS4.Gui.KissGrid grdMessage;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMessage;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblAuswahl;
        private KiSS4.Gui.KissLabel lblFail;
        private KiSS4.Gui.KissLabel lblSuccess;
        private KiSS4.Gui.KissLabel lblSuccessLegende;
        private KiSS4.Gui.KissLabel lblToDo;
        private KiSS4.Gui.KissLabel lblTotal;
        private KiSS4.DB.SqlQuery qryIBAN;
        private KiSS4.DB.SqlQuery qryMessages;

        #endregion

        #region Constructors

        public CtlIbanGenerieren()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIbanGenerieren));
            this.btnStart = new KiSS4.Gui.KissButton();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblAuswahl = new KiSS4.Gui.KissLabel();
            this.lblFail = new KiSS4.Gui.KissLabel();
            this.lblSuccess = new KiSS4.Gui.KissLabel();
            this.lblSuccessLegende = new KiSS4.Gui.KissLabel();
            this.lblToDo = new KiSS4.Gui.KissLabel();
            this.lblTotal = new KiSS4.Gui.KissLabel();
            this.edtToDo = new KiSS4.Gui.KissCalcEdit();
            this.grdMessage = new KiSS4.Gui.KissGrid();
            this.btnGotoInstitution = new KiSS4.Gui.KissButton();
            this.btnGotoPerson = new KiSS4.Gui.KissButton();
            this.edtAuswahl = new KiSS4.Gui.KissLookUpEdit();
            this.colBCL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameEmpfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvMessage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryIBAN = new KiSS4.DB.SqlQuery(this.components);
            this.qryMessages = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessLegende)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtToDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessages)).BeginInit();
            this.SuspendLayout();
            //
            // btnStart
            //
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(24, 102);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 24);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "IBAN generieren";
            this.btnStart.UseCompatibleTextRendering = true;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(24, 72);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(150, 24);
            this.kissLabel1.TabIndex = 1;
            this.kissLabel1.Text = "Anzahl zu generieren";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // kissLabel4
            //
            this.kissLabel4.Location = new System.Drawing.Point(24, 155);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(150, 24);
            this.kissLabel4.TabIndex = 1;
            this.kissLabel4.Text = "Generierung nicht m�glich";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // lblAuswahl
            //
            this.lblAuswahl.Location = new System.Drawing.Point(24, 22);
            this.lblAuswahl.Name = "lblAuswahl";
            this.lblAuswahl.Size = new System.Drawing.Size(150, 24);
            this.lblAuswahl.TabIndex = 1;
            this.lblAuswahl.Text = "Auswahl:";
            this.lblAuswahl.UseCompatibleTextRendering = true;
            //
            // lblFail
            //
            this.lblFail.Location = new System.Drawing.Point(215, 155);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(100, 23);
            this.lblFail.TabIndex = 1;
            this.lblFail.Text = "";
            this.lblFail.UseCompatibleTextRendering = true;
            //
            // lblSuccess
            //
            this.lblSuccess.Location = new System.Drawing.Point(215, 131);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(100, 23);
            this.lblSuccess.TabIndex = 1;
            this.lblSuccess.Text = "";
            this.lblSuccess.UseCompatibleTextRendering = true;
            //
            // lblSuccessLegende
            //
            this.lblSuccessLegende.Location = new System.Drawing.Point(24, 131);
            this.lblSuccessLegende.Name = "lblSuccessLegende";
            this.lblSuccessLegende.Size = new System.Drawing.Size(150, 24);
            this.lblSuccessLegende.TabIndex = 1;
            this.lblSuccessLegende.Text = "IBAN generiert:";
            this.lblSuccessLegende.UseCompatibleTextRendering = true;
            //
            // lblToDo
            //
            this.lblToDo.Location = new System.Drawing.Point(24, 48);
            this.lblToDo.Name = "lblToDo";
            this.lblToDo.Size = new System.Drawing.Size(150, 24);
            this.lblToDo.TabIndex = 1;
            this.lblToDo.Text = "Zahlungswege ohne IBAN:";
            this.lblToDo.UseCompatibleTextRendering = true;
            //
            // lblTotal
            //
            this.lblTotal.Location = new System.Drawing.Point(215, 49);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "";
            this.lblTotal.UseCompatibleTextRendering = true;
            //
            // edtToDo
            //
            this.edtToDo.EditValue = new decimal(new int[] {
                        10,
                        0,
                        0,
                        0});
            this.edtToDo.Location = new System.Drawing.Point(215, 72);
            this.edtToDo.Name = "edtToDo";
            this.edtToDo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtToDo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtToDo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtToDo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtToDo.Properties.Appearance.Options.UseBackColor = true;
            this.edtToDo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtToDo.Properties.Appearance.Options.UseFont = true;
            this.edtToDo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtToDo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtToDo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtToDo.Size = new System.Drawing.Size(100, 24);
            this.edtToDo.TabIndex = 3;
            //
            // grdMessage
            //
            this.grdMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMessage.DataSource = this.qryMessages;
            this.grdMessage.EmbeddedNavigator.Name = "";
            this.grdMessage.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMessage.Location = new System.Drawing.Point(12, 189);
            this.grdMessage.MainView = this.grvMessage;
            this.grdMessage.Name = "grdMessage";
            this.grdMessage.Size = new System.Drawing.Size(946, 471);
            this.grdMessage.TabIndex = 4;
            this.grdMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvMessage});
            //
            // btnGotoInstitution
            //
            this.btnGotoInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGotoInstitution.Enabled = false;
            this.btnGotoInstitution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoInstitution.Location = new System.Drawing.Point(12, 666);
            this.btnGotoInstitution.Name = "btnGotoInstitution";
            this.btnGotoInstitution.Size = new System.Drawing.Size(184, 24);
            this.btnGotoInstitution.TabIndex = 5;
            this.btnGotoInstitution.Text = "Zu Institution springen";
            this.btnGotoInstitution.UseCompatibleTextRendering = true;
            this.btnGotoInstitution.UseVisualStyleBackColor = false;
            this.btnGotoInstitution.Click += new System.EventHandler(this.btnGotoInstitution_Click);
            //
            // btnGotoPerson
            //
            this.btnGotoPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGotoPerson.Enabled = false;
            this.btnGotoPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoPerson.Location = new System.Drawing.Point(202, 666);
            this.btnGotoPerson.Name = "btnGotoPerson";
            this.btnGotoPerson.Size = new System.Drawing.Size(184, 24);
            this.btnGotoPerson.TabIndex = 5;
            this.btnGotoPerson.Text = "Zu Person springen";
            this.btnGotoPerson.UseCompatibleTextRendering = true;
            this.btnGotoPerson.UseVisualStyleBackColor = false;
            //
            // edtAuswahl
            //
            this.edtAuswahl.Location = new System.Drawing.Point(215, 22);
            this.edtAuswahl.Name = "edtAuswahl";
            this.edtAuswahl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswahl.Properties.Appearance.Options.UseFont = true;
            this.edtAuswahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuswahl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtAuswahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswahl.Properties.NullText = "";
            this.edtAuswahl.Properties.ShowFooter = false;
            this.edtAuswahl.Properties.ShowHeader = false;
            this.edtAuswahl.Size = new System.Drawing.Size(193, 24);
            this.edtAuswahl.TabIndex = 6;
            this.edtAuswahl.EditValueChanged += new System.EventHandler(this.edtAuswahl_EditValueChanged);
            //
            // colBCL
            //
            this.colBCL.Caption = "BCL";
            this.colBCL.FieldName = "BCL";
            this.colBCL.Name = "colBCL";
            this.colBCL.Visible = true;
            this.colBCL.VisibleIndex = 0;
            this.colBCL.Width = 52;
            //
            // colKontoNr
            //
            this.colKontoNr.Caption = "Konto";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 1;
            this.colKontoNr.Width = 107;
            //
            // colMessage
            //
            this.colMessage.Caption = "Fehler";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            this.colMessage.Width = 409;
            //
            // colNameEmpfaenger
            //
            this.colNameEmpfaenger.Caption = "Name";
            this.colNameEmpfaenger.FieldName = "Name";
            this.colNameEmpfaenger.Name = "colNameEmpfaenger";
            this.colNameEmpfaenger.Visible = true;
            this.colNameEmpfaenger.VisibleIndex = 3;
            this.colNameEmpfaenger.Width = 188;
            //
            // colOE
            //
            this.colOE.Caption = "OE";
            this.colOE.FieldName = "OE";
            this.colOE.Name = "colOE";
            this.colOE.Visible = true;
            this.colOE.VisibleIndex = 5;
            this.colOE.Width = 101;
            //
            // colUser
            //
            this.colUser.Caption = "User";
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 4;
            //
            // grvMessage
            //
            this.grvMessage.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvMessage.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.Empty.Options.UseBackColor = true;
            this.grvMessage.Appearance.Empty.Options.UseFont = true;
            this.grvMessage.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.EvenRow.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMessage.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvMessage.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMessage.Appearance.FocusedCell.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMessage.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMessage.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMessage.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMessage.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMessage.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMessage.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMessage.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.GroupRow.Options.UseFont = true;
            this.grvMessage.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvMessage.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvMessage.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMessage.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMessage.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMessage.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvMessage.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvMessage.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMessage.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.OddRow.Options.UseFont = true;
            this.grvMessage.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvMessage.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.Row.Options.UseBackColor = true;
            this.grvMessage.Appearance.Row.Options.UseFont = true;
            this.grvMessage.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.SelectedRow.Options.UseFont = true;
            this.grvMessage.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvMessage.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMessage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvMessage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colBCL,
                        this.colKontoNr,
                        this.colMessage,
                        this.colNameEmpfaenger,
                        this.colUser,
                        this.colOE});
            this.grvMessage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMessage.GridControl = this.grdMessage;
            this.grvMessage.Name = "grvMessage";
            this.grvMessage.OptionsBehavior.Editable = false;
            this.grvMessage.OptionsCustomization.AllowFilter = false;
            this.grvMessage.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvMessage.OptionsNavigation.AutoFocusNewRow = true;
            this.grvMessage.OptionsNavigation.UseTabKey = false;
            this.grvMessage.OptionsView.ColumnAutoWidth = false;
            this.grvMessage.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMessage.OptionsView.ShowGroupPanel = false;
            this.grvMessage.OptionsView.ShowIndicator = false;
            //
            // qryIBAN
            //
            this.qryIBAN.BatchUpdate = true;
            this.qryIBAN.HostControl = this;
            this.qryIBAN.SelectStatement = resources.GetString("qryIBAN.SelectStatement");
            this.qryIBAN.TableName = "vwBaZahlungsweg";
            //
            // qryMessages
            //
            this.qryMessages.BatchUpdate = true;
            this.qryMessages.HostControl = this;
            this.qryMessages.PositionChanged += new System.EventHandler(this.qryMessages_PositionChanged);
            //
            // CtlIbanGenerieren
            //
            this.ActiveSQLQuery = this.qryIBAN;
            this.Controls.Add(this.edtAuswahl);
            this.Controls.Add(this.btnGotoPerson);
            this.Controls.Add(this.btnGotoInstitution);
            this.Controls.Add(this.grdMessage);
            this.Controls.Add(this.edtToDo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblToDo);
            this.Controls.Add(this.lblSuccessLegende);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.lblFail);
            this.Controls.Add(this.lblAuswahl);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.btnStart);
            this.Name = "CtlIbanGenerieren";
            this.Size = new System.Drawing.Size(970, 703);
            this.Load += new System.EventHandler(this.CtlIbanGenerieren_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessLegende)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtToDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessages)).EndInit();
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

        private void AddErrorRow(string bcl, string konto, string fehler, string name, object baInstitutionID, object baPersonID, string user, string oe)
        {
            DataRow row = qryMessages.DataTable.NewRow();
            row["BCL"] = bcl;
            row["KontoNr"] = konto;
            row["Message"] = fehler;
            row["Name"] = name;
            row["BaInstitutionID"] = baInstitutionID;
            row["BaPersonID"] = baPersonID;
            row["User"] = user;
            row["OE"] = oe;
            qryMessages.DataTable.Rows.Add(row);
        }

        private void btnGotoInstitution_Click(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryMessages["BaInstitutionID"]))
                FormController.SendMessage("FrmInstitutionenStamm", "Action", "ShowInstitution", "BaInstitutionID", qryMessages["BaInstitutionID"]);
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            //qryIBAN.Fill("SELECT ZAL.BaZahlungswegID, ZAL.EinzahlungsscheinCode, ZAL.PostKontoNummer, ZAL.BankKontoNummer, ZAL.IBANNummer, BNK.ClearingNr, ZAL.Empfaenger, ZAL.BaInstitutionID, ZAL.BaPersonID, Logon, OE = OrgUnit " + GetIbanSqlFilterStmt());
            qryIBAN.Fill(@"
            SELECT ZAL.BaZahlungswegID, ZAL.EinzahlungsscheinCode, ZAL.PostKontoNummer, ZAL.BankKontoNummer, ZAL.IBANNummer, BNK.ClearingNr, Name = PRS.Name + IsNull(' ' + PRS.Vorname,''), ZAL.BaInstitutionID, ZAL.BaPersonID, USR.Logon, USR.OrgUnit
            FROM   vwBaZahlungsweg   ZAL
              LEFT JOIN BaBank       BNK ON BNK.BaBankID   = ZAL.BaBankID
              LEFT JOIN BaPerson     PRS ON PRS.BaPersonID = ZAL.BaPersonID
              LEFT JOIN FaFallPerson FAP ON FAP.BaPersonID = PRS.BaPersonID
              LEFT JOIN FaFall       FAL ON FAL.FaFallID   = FAP.FaFallID
              LEFT JOIN vwUser       USR ON USR.UserID     = FAL.UserID
            WHERE  IBANNummer IS NULL AND EinzahlungsscheinCode IN (2,3,5) AND (FAL.FaFallID IS NULL OR FAL.DatumBis IS NULL)" + GetIbanSqlFilterStmt());

            //lblTotal.Text = qryIBAN.Count.ToString();
            int count = 0;
            int errors = 0;
            int success = 0;
            int ezCode = 0;
            int todo = (int)edtToDo.Value;
            string iban;

            foreach (DataRow row in qryIBAN.DataTable.Rows)
            {
                try
                {
                    if (++count > todo)
                        break;
                    ezCode = (int)row["EinzahlungsscheinCode"];
                    switch (ezCode)
                    {
                        case 1: // OrangerEinzahlungsschein
                            {
                                // F�r ESR braucht es keine IBAN
                                continue;
                            }
                        case 2: // Post
                            {
                                iban = Belegleser.IBANConvert(row["PostKontoNummer"] as string, "9000");
                                DBUtil.ExecSQL("UPDATE BaZahlungsweg SET IBANNummer = {0}, Modifier = {2}, Modified = GETDATE(), MutiertUserID = {3} WHERE BaZahlungswegID = {1}", iban, (int)row["BaZahlungswegID"], DBUtil.GetDBRowCreatorModifier(), Session.User.UserID);
                                qryIBAN.Post();
                                success++;
                            }
                            break;

                        case 3:
                        case 5: // Bank
                            {
                                iban = Belegleser.IBANConvert(row["BankKontoNummer"] as string, row["ClearingNr"] as string);
                                DBUtil.ExecSQL("UPDATE BaZahlungsweg SET IBANNummer = {0}, Modifier = {2}, Modified = GETDATE(), MutiertUserID = {3} WHERE BaZahlungswegID = {1}", iban, (int)row["BaZahlungswegID"], DBUtil.GetDBRowCreatorModifier(), Session.User.UserID);
                                success++;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    errors++;
                    bool post = (ezCode == 2);
                    AddErrorRow(post ? "9000" : (row["ClearingNr"] is string ? row["ClearingNr"].ToString() : ""), post ? row["PostKontoNummer"] as string : row["BankKontoNummer"] as string, ex.Message, row["Name"] as string, row["BaInstitutionID"], row["BaPersonID"], row["Logon"] as string, row["OrgUnit"] as string);
                    //		errorMsgs += string.Format("BCL {0}, Konto {1}: {2}", post?"9000":row["ClearingNr"], post?row["PostKontoNummer"]:row["BankKontoNummer"], ex.Message) + Environment.NewLine;
                    //KissMsg.ShowError( "CtlIbanGenerieren", "IBANGenerationFailed", "Es konnte keine IBAN generiert werden.", ex);
                }
            }

            lblSuccess.Text = success.ToString();
            lblFail.Text = errors.ToString();

            //edtFeedback.Text = errorMsgs;

            UpdateCount();
        }

        private void CtlIbanGenerieren_Load(object sender, System.EventArgs e)
        {
            UpdateCount();

            //DataColumn colBCL = new DataColumn("BCL", typeof(string));
            qryMessages.DataTable.Columns.Clear();
            qryMessages.DataTable.Columns.Add("BCL", typeof(string));
            qryMessages.DataTable.Columns.Add("KontoNr", typeof(string));
            qryMessages.DataTable.Columns.Add("Message", typeof(string));
            qryMessages.DataTable.Columns.Add("Name", typeof(string));
            qryMessages.DataTable.Columns.Add("BaInstitutionID", typeof(int));
            qryMessages.DataTable.Columns.Add("BaPersonID", typeof(int));
            qryMessages.DataTable.Columns.Add("User", typeof(string));
            qryMessages.DataTable.Columns.Add("OE", typeof(string));
            //qryMessages.DataTable.Columns.Add("BCL", typeof(string));

            edtAuswahl.LoadQuery(DBUtil.OpenSQL(@"
                    select Code = 0, Text = 'Alle'
                    union
                    select Code = 1, Text = 'Nur Institutionen'
                    union
                    select Code = 2, Text = 'Nur Personen'"));

            edtAuswahl.EditValue = 0;
        }

        private void edtAuswahl_EditValueChanged(object sender, System.EventArgs e)
        {
            UpdateCount();
        }

        private string GetIbanSqlFilterStmt()
        {
            string filter = @"";

            if (!DBUtil.IsEmpty(edtAuswahl.EditValue))
            {
                int code = (int)edtAuswahl.EditValue;
                if (code == 1)
                    filter += " AND ZAL.BaInstitutionID IS NOT NULL";
                else if (code == 2)
                    filter += " AND ZAL.BaPersonID IS NOT NULL";
            }
            return filter;
        }

        private void qryMessages_PositionChanged(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryMessages["BaInstitutionID"]))
            {
                btnGotoInstitution.Enabled = true;
                btnGotoPerson.Enabled = false;
            }
            else if (!DBUtil.IsEmpty(qryMessages["BaPersonID"]))
            {
                btnGotoInstitution.Enabled = false;
                btnGotoPerson.Enabled = true;
            }
        }

        private void UpdateCount()
        {
            lblTotal.Text = DBUtil.ExecuteScalarSQL(@"
              SELECT Count(*)
              FROM vwBaZahlungsweg ZAL
                LEFT JOIN  BaBank BNK ON BNK.BaBankID = ZAL.BaBankID
              WHERE  IBANNummer IS NULL AND EinzahlungsscheinCode IN (2,3,5) " + GetIbanSqlFilterStmt()).ToString();
            //	  FROM BaZahlungsweg ZAL
            //	    LEFT JOIN  BaBank BNK ON BNK.BaBankID = ZAL.BaBankID
            //	  WHERE  IBANNummer IS NULL AND EinzahlungsscheinCode IN (2,3,5)").ToString();
            edtToDo.Value = int.Parse(lblTotal.Text);
        }

        #endregion
    }
}