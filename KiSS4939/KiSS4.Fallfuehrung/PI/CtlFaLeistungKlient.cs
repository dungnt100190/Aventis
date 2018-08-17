using System;
using System.Drawing;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    /// <summary>
    /// Control, used for showing entries of ZLE assigned to client
    /// </summary>
    public class CtlFaLeistungKlient : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = 0;
        private KiSS4.Gui.KissCheckEdit chkSucheFreigegeben;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDauer;
        private DevExpress.XtraGrid.Columns.GridColumn colFreigegeben;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colVerbucht;
        private DevExpress.XtraGrid.Columns.GridColumn colWT;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissButtonEdit edtSucheLeistungsart;
        private KiSS4.Gui.KissButtonEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissGrid grdLeistung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLeistung;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheLeistungsart;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryLeistungKlient;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFaLeistungKlient"/> class.
        /// </summary>
        public CtlFaLeistungKlient()
        {
            this.InitializeComponent();

            // init with default values
            this.Init(null, null, -1);

            // setup total as multilanguage
            this.colDatum.SummaryItem.DisplayFormat = KissMsg.GetMLMessage(this.Name, "SummaryItemTotal", "Total:");
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaLeistungKlient));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdLeistung = new KiSS4.Gui.KissGrid();
            this.qryLeistungKlient = new KiSS4.DB.SqlQuery(this.components);
            this.grvLeistung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDauer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreigegeben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerbucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtSucheLeistungsart = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissButtonEdit();
            this.chkSucheFreigegeben = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLeistungKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheFreigegeben.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(715, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 30);
            this.tabControlSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(739, 566);
            this.tabControlSearch.TabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdLeistung);
            this.tpgListe.Size = new System.Drawing.Size(727, 528);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.chkSucheFreigegeben);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheLeistungsart);
            this.tpgSuchen.Controls.Add(this.lblSucheLeistungsart);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(727, 528);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheFreigegeben, 0);
            //
            // panTitel
            //
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(739, 30);
            this.panTitel.TabIndex = 0;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(697, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Erfasste Leistungen";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // grdLeistung
            //
            this.grdLeistung.DataSource = this.qryLeistungKlient;
            this.grdLeistung.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdLeistung.EmbeddedNavigator.Name = "";
            this.grdLeistung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdLeistung.Location = new System.Drawing.Point(0, 0);
            this.grdLeistung.MainView = this.grvLeistung;
            this.grdLeistung.Name = "grdLeistung";
            this.grdLeistung.Size = new System.Drawing.Size(727, 528);
            this.grdLeistung.TabIndex = 1;
            this.grdLeistung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLeistung});
            //
            // qryLeistungKlient
            //
            this.qryLeistungKlient.HostControl = this;
            this.qryLeistungKlient.AfterFill += new System.EventHandler(this.qryLeistungKlient_AfterFill);
            //
            // grvLeistung
            //
            this.grvLeistung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvLeistung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.Empty.Options.UseBackColor = true;
            this.grvLeistung.Appearance.Empty.Options.UseFont = true;
            this.grvLeistung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.EvenRow.Options.UseFont = true;
            this.grvLeistung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvLeistung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvLeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvLeistung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvLeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvLeistung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvLeistung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvLeistung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvLeistung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvLeistung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvLeistung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLeistung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvLeistung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLeistung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLeistung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLeistung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvLeistung.Appearance.GroupRow.Options.UseFont = true;
            this.grvLeistung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvLeistung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvLeistung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvLeistung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLeistung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvLeistung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvLeistung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvLeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvLeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvLeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvLeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvLeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvLeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.OddRow.Options.UseFont = true;
            this.grvLeistung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvLeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.Row.Options.UseBackColor = true;
            this.grvLeistung.Appearance.Row.Options.UseFont = true;
            this.grvLeistung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLeistung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvLeistung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvLeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvLeistung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvLeistung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWT,
            this.colDatum,
            this.colDauer,
            this.colLeistungsart,
            this.colUser,
            this.colFreigegeben,
            this.colVerbucht});
            this.grvLeistung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvLeistung.GridControl = this.grdLeistung;
            this.grvLeistung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvLeistung.Name = "grvLeistung";
            this.grvLeistung.OptionsBehavior.Editable = false;
            this.grvLeistung.OptionsCustomization.AllowFilter = false;
            this.grvLeistung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvLeistung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvLeistung.OptionsNavigation.UseTabKey = false;
            this.grvLeistung.OptionsView.ColumnAutoWidth = false;
            this.grvLeistung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvLeistung.OptionsView.ShowFooter = true;
            this.grvLeistung.OptionsView.ShowGroupPanel = false;
            this.grvLeistung.OptionsView.ShowIndicator = false;
            //
            // colWT
            //
            this.colWT.Caption = "Tag";
            this.colWT.FieldName = "WT";
            this.colWT.Name = "colWT";
            this.colWT.Visible = true;
            this.colWT.VisibleIndex = 0;
            this.colWT.Width = 50;
            //
            // colDatum
            //
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.SummaryItem.DisplayFormat = "Total:";
            this.colDatum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 1;
            //
            // colDauer
            //
            this.colDauer.Caption = "Dauer";
            this.colDauer.DisplayFormat.FormatString = "0.00";
            this.colDauer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDauer.FieldName = "StundenDezimal";
            this.colDauer.Name = "colDauer";
            this.colDauer.SummaryItem.DisplayFormat = "{0:0.00h;-0.00h;#.##}";
            this.colDauer.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colDauer.Visible = true;
            this.colDauer.VisibleIndex = 2;
            this.colDauer.Width = 60;
            //
            // colLeistungsart
            //
            this.colLeistungsart.Caption = "Leistungsart";
            this.colLeistungsart.FieldName = "BezeichnungML";
            this.colLeistungsart.Name = "colLeistungsart";
            this.colLeistungsart.Visible = true;
            this.colLeistungsart.VisibleIndex = 3;
            this.colLeistungsart.Width = 220;
            //
            // colUser
            //
            this.colUser.Caption = "Mitarbeiter/in";
            this.colUser.FieldName = "UserName";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 4;
            this.colUser.Width = 200;
            //
            // colFreigegeben
            //
            this.colFreigegeben.Caption = "Freig.";
            this.colFreigegeben.FieldName = "Freigegeben";
            this.colFreigegeben.Name = "colFreigegeben";
            this.colFreigegeben.Visible = true;
            this.colFreigegeben.VisibleIndex = 5;
            this.colFreigegeben.Width = 45;
            //
            // colVerbucht
            //
            this.colVerbucht.Caption = "Verbucht";
            this.colVerbucht.FieldName = "Verbucht";
            this.colVerbucht.Name = "colVerbucht";
            this.colVerbucht.Visible = true;
            this.colVerbucht.VisibleIndex = 6;
            this.colVerbucht.Width = 80;
            //
            // lblSucheDatumVon
            //
            this.lblSucheDatumVon.Location = new System.Drawing.Point(31, 40);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(103, 24);
            this.lblSucheDatumVon.TabIndex = 1;
            this.lblSucheDatumVon.Text = "Datum";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumVon
            //
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(140, 38);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(95, 24);
            this.edtSucheDatumVon.TabIndex = 2;
            //
            // lblSucheDatumBis
            //
            this.lblSucheDatumBis.Location = new System.Drawing.Point(241, 38);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(25, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumBis
            //
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(272, 38);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(95, 24);
            this.edtSucheDatumBis.TabIndex = 4;
            //
            // lblSucheLeistungsart
            //
            this.lblSucheLeistungsart.Location = new System.Drawing.Point(31, 68);
            this.lblSucheLeistungsart.Name = "lblSucheLeistungsart";
            this.lblSucheLeistungsart.Size = new System.Drawing.Size(103, 24);
            this.lblSucheLeistungsart.TabIndex = 5;
            this.lblSucheLeistungsart.Text = "Leistungsart";
            this.lblSucheLeistungsart.UseCompatibleTextRendering = true;
            //
            // edtSucheLeistungsart
            //
            this.edtSucheLeistungsart.Location = new System.Drawing.Point(140, 68);
            this.edtSucheLeistungsart.Name = "edtSucheLeistungsart";
            this.edtSucheLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheLeistungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheLeistungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLeistungsart.Size = new System.Drawing.Size(227, 24);
            this.edtSucheLeistungsart.TabIndex = 6;
            this.edtSucheLeistungsart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheLeistungsart_UserModifiedFld);
            //
            // lblSucheMitarbeiter
            //
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 98);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(103, 24);
            this.lblSucheMitarbeiter.TabIndex = 7;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            //
            // edtSucheMitarbeiter
            //
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(140, 98);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(227, 24);
            this.edtSucheMitarbeiter.TabIndex = 8;
            this.edtSucheMitarbeiter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMitarbeiter_UserModifiedFld);
            //
            // chkSucheFreigegeben
            //
            this.chkSucheFreigegeben.EditValue = false;
            this.chkSucheFreigegeben.Location = new System.Drawing.Point(140, 131);
            this.chkSucheFreigegeben.Name = "chkSucheFreigegeben";
            this.chkSucheFreigegeben.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheFreigegeben.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheFreigegeben.Properties.Caption = "Nur Freigegeben";
            this.chkSucheFreigegeben.Size = new System.Drawing.Size(227, 19);
            this.chkSucheFreigegeben.TabIndex = 9;
            //
            // CtlFaLeistungKlient
            //
            this.ActiveSQLQuery = this.qryLeistungKlient;
            this.Controls.Add(this.panTitel);
            this.Name = "CtlFaLeistungKlient";
            this.Size = new System.Drawing.Size(739, 596);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLeistungKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheFreigegeben.Properties)).EndInit();
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

        #region EventHandlers

        private void edtSucheLeistungsart_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogLeistungsart(sender, e);
        }

        private void edtSucheMitarbeiter_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogMitarbeiter(sender, e);
        }

        private void qryLeistungKlient_AfterFill(object sender, System.EventArgs e)
        {
            // HACK: removed in Init(), set datasource again (summaryitem won't update otherwise)
            this.grdLeistung.DataSource = qryLeistungKlient;

            // select last row
            qryLeistungKlient.Last();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Init the control to show data for given <paramref name="baPersonID"/>
        /// </summary>
        /// <param name="titleName">The title to show</param>
        /// <param name="titleImage">The icon to show in title</param>
        /// <param name="baPersonID">The id of the person to show data for</param>
        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            // deny changes
            qryLeistungKlient.CanInsert = false;
            qryLeistungKlient.CanUpdate = false;
            qryLeistungKlient.CanDelete = false;

            // validate
            if (baPersonID < 1)
            {
                // do not continue
                return;
            }

            // apply values
            this._baPersonID = baPersonID;
            this.picTitel.Image = titleImage;
            this.lblTitel.Text = titleName;

            // setup select statement
            qryLeistungKlient.SelectStatement = @"
                SELECT LEI.*,
                       BezeichnungML = dbo.fnGetMLTextByDefault(LAR.BezeichnungTID, {1}, LAR.Bezeichnung),
                       StundenDezimal = LEI.Dauer,
                       -- StundenMinuten = dbo.fnBDEConvertMoneyToHHMM(Dauer, 'hh:mm'),
                       Klient = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                       UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, USR.Firstname),
                       WT = dbo.fnBDEGetWeekDayFromDate(Datum, {1})
                FROM dbo.BDELeistung             LEI WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID
                  LEFT  JOIN dbo.BaPerson        PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                  LEFT  JOIN dbo.XUser           USR WITH (READUNCOMMITtED) ON USR.UserID = LEI.UserID
                WHERE LEI.BaPersonID = {0}
                --- AND LEI.Datum >= {edtSucheDatumVon}
                --- AND LEI.Datum <= {edtSucheDatumBis}
                --- AND LEI.BDELeistungsartID = {edtSucheLeistungsart.LookupID}
                --- AND LEI.UserID = {edtSucheMitarbeiter.LookupID}
                --- AND LEI.Freigegeben = CASE WHEN ISNULL({chkSucheFreigegeben}, 0) = 1 THEN 1 ELSE LEI.Freigegeben END
                ORDER BY Datum ASC, BezeichnungML ASC";

            // HACK: remove datasource and set it again in after_fill (summaryitem won't update otherwise)
            this.grdLeistung.DataSource = null;

            // start a new search (default behaviour) and switch to tabListe
            this.NewSearch();
            this.tabControlSearch.SelectedTabIndex = 0;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // refresh search fields
            base.NewSearch();

            // reset manual fields
            edtSucheLeistungsart.EditValue = null;
            edtSucheLeistungsart.LookupID = null;

            edtSucheMitarbeiter.EditValue = null;
            edtSucheMitarbeiter.LookupID = null;

            // set focus
            edtSucheDatumVon.Focus();
        }

        protected override void RunSearch()
        {
            // set focus to apply dates
            chkSucheFreigegeben.Focus();

            // replace search parameters
            object[] parameters = new object[] { this._baPersonID, Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private bool DialogLeistungsart(object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // convert control
                KissButtonEdit edt = (KissButtonEdit)sender;

                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // Leistungsart Suche
                        edt.EditValue = null;
                        edt.LookupID = null;
                        return true;
                    }
                }

                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT DISTINCT
                           Bezeichnung = dbo.fnGetMLTextByDefault(LEI.BezeichnungTID, {1}, LEI.Bezeichnung),
                           Gruppe = dbo.fnGetMLTextByDefault(GRP.UserGroupNameTID, {1}, GRP.UserGroupName),
                           Code$ = LEI.BDELeistungsartID
                    FROM dbo.BDELeistungsart                      LEI WITH (READUNCOMMITTED)
                      INNER JOIN dbo.BDEUserGroup_BDELeistungsart UGL WITH (READUNCOMMITTED) ON UGL.BDELeistungsartID = LEI.BDELeistungsartID
                      INNER JOIN dbo.BDEUserGroup                 GRP WITH (READUNCOMMITTED) ON GRP.BDEUserGroupID = UGL.BDEUserGroupID
                    WHERE LEI.DatumVon <= GETDATE() AND
                          ISNULL(LEI.DatumBis, GETDATE()) >= GETDATE() AND
                          (LEI.KlientErfassungCode = 2 OR LEI.KlientErfassungCode = 3) AND
                          (LEI.Bezeichnung LIKE '{0}%' OR GRP.UserGroupName LIKE '{0}%')
                    ORDER BY Bezeichnung ASC", searchString, Session.User.LanguageCode), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // Leistungsart Suche (first EditValue, then LookupID!)
                    edt.EditValue = dlg["Bezeichnung"];
                    edt.LookupID = dlg["Code$"];

                    // success
                    return true;
                }
                else
                {
                    // canceled or error
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorDialogLeistungsart_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private bool DialogMitarbeiter(object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (edtSucheMitarbeiter.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edtSucheMitarbeiter.EditValue))
                {
                    // prepare for database search
                    searchString = edtSucheMitarbeiter.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        edtSucheMitarbeiter.EditValue = null;
                        edtSucheMitarbeiter.LookupID = null;
                        return true;
                    }
                }

                // Mitarbeiter_Suchen()
                KissLookupDialog dlg = new KissLookupDialog();
                e.Cancel = !dlg.SearchData(string.Format(@"
              		SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE '{1}%'", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // apply new value (first EditValue, then LookupID!)
                    edtSucheMitarbeiter.EditValue = dlg["Name"];
                    edtSucheMitarbeiter.LookupID = dlg["UserID$"];

                    // success
                    return true;
                }
                else
                {
                    // canceled or error
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorDialogMitarbeiter_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        #endregion

        #endregion
    }
}