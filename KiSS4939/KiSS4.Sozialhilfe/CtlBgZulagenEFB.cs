using System;
using System.Data;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    /// <summary>
    /// Summary description for CtlBgZulagenEFB.
    /// </summary>
    public class CtlBgZulagenEFB : KiSS4.Gui.KissUserControl
    {
        private int BgBudgetID;
        private int BgFinanzplanID;
        private KiSS4.Gui.KissCheckEdit chkAlleinerziehend;
        private DevExpress.XtraGrid.Columns.GridColumn colAnteil;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBgGruppeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLabel dblNameVorname;
        private KiSS4.Gui.KissLookUpEdit edtAnteil;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBgGruppeCode;
        private KissCheckEdit edtNurAktuelle;
        private DateTime finanzplanVon;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KiSS4.Gui.KissLabel lblAnteil;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBgGruppeCode;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private SqlQuery qryBgPositionsart;

        public CtlBgZulagenEFB()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"
				SELECT 1 AS Code, '01-20%' AS Text
				UNION SELECT 2, '21-30%'
				UNION SELECT 3, '31-40%'
				UNION SELECT 4, '41-50%'
				UNION SELECT 5, '51-60%'
				UNION SELECT 6, '61-70%'
				UNION SELECT 7, '71-80%'
				UNION SELECT 8, '81-90%'
				UNION SELECT 9, '100%'");

            this.edtAnteil.LoadQuery(qry);
            this.edtAnteil.Properties.DropDownRows = qry.Count;
            this.colAnteil.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qry);

            qry = DBUtil.GetLOVQuery("BgGruppe", true, @"
				  AND Code BETWEEN 39000 AND 39999
				  AND Code NOT IN (39000, 39110, 39130, 39910)"); // Zulagen/EFB, Alleinerziehend ausschliessen

            this.edtBgGruppeCode.LoadQuery(qry);
            this.colBgGruppeCode.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qry);
        }

        public CtlBgZulagenEFB(Image titelImage, string titelText, int bgBudgetID)
            : this()
        {
            this.picTitel.Image = titelImage;
            this.BgBudgetID = bgBudgetID;

            SqlQuery qry = DBUtil.OpenSQL(@"
				SELECT SFP.BgFinanzplanID,
				  FinanzplanVon = IsNull(SFP.DatumVon, SFP.GeplantVon),
				  FinanzplanBis = IsNull(SFP.DatumBis, SFP.GeplantBis)
				FROM BgBudget             BBG
				  INNER JOIN BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
				WHERE BBG.BgBudgetID = {0}"
                , BgBudgetID);

            finanzplanVon = Utils.ConvertToDateTime(qry["FinanzplanVon"]);
            BgFinanzplanID = Utils.ConvertToInt(qry["BgFinanzplanID"]);
            DateTime finanzplanBis = Utils.ConvertToDateTime(qry["FinanzplanVon"]);
            this.lblTitel.Text = string.Format(this.lblTitel.Text, qry["FinanzplanVon"], qry["FinanzplanBis"], titelText);

            qryBgPositionsart = ShUtil.GetSqlQueryShPositionTyp(39021, 39999, finanzplanVon, finanzplanBis, false);

            ShUtil.ApplyShStatusCodeToSqlQuery(this.ActiveSQLQuery, BgBudgetID);
            this.qryBgPosition.Fill(BgBudgetID, edtNurAktuelle.Checked);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgZulagenEFB));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dblNameVorname = new KiSS4.Gui.KissLabel();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgGruppeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnteil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.chkAlleinerziehend = new KiSS4.Gui.KissCheckEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBgGruppeCode = new KiSS4.Gui.KissLabel();
            this.lblAnteil = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtAnteil = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgGruppeCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtNurAktuelle = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dblNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlleinerziehend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnteil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // dblNameVorname
            //
            this.dblNameVorname.DataMember = "NameVorname";
            this.dblNameVorname.DataSource = this.qryBgPosition;
            this.dblNameVorname.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.dblNameVorname.Location = new System.Drawing.Point(8, 184);
            this.dblNameVorname.Name = "dblNameVorname";
            this.dblNameVorname.Size = new System.Drawing.Size(664, 16);
            this.dblNameVorname.TabIndex = 2;
            //
            // qryBgPosition
            //
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgPosition_ColumnChanged);
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 320);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 144);
            this.edtBemerkung.TabIndex = 11;
            //
            // lblBemerkung
            //
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 304);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(112, 16);
            this.lblBemerkung.TabIndex = 10;
            this.lblBemerkung.Text = "Beschreibung";
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Monatliche Zulagen und EFB vom {0:d} bis {1:d}";
            //
            // grdBgPosition
            //
            this.grdBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgPosition.DataSource = this.qryBgPosition;
            //
            //
            //
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(8, 40);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(664, 136);
            this.grdBgPosition.TabIndex = 1;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            //
            // grvBgPosition
            //
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Empty.Options.UseFont = true;
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colNameVorname,
            this.colGeburtsdatum,
            this.colBgGruppeCode,
            this.colAnteil,
            this.colBetrag,
            this.colBemerkung});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPosition.OptionsView.ShowFooter = true;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "Gültig ab";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 60;
            //
            // colNameVorname
            //
            this.colNameVorname.Caption = "Name";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 1;
            this.colNameVorname.Width = 190;
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Caption = "Geburtsdatum";
            this.colGeburtsdatum.DisplayFormat.FormatString = "d";
            this.colGeburtsdatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 2;
            this.colGeburtsdatum.Width = 90;
            //
            // colBgGruppeCode
            //
            this.colBgGruppeCode.Caption = "Zulage";
            this.colBgGruppeCode.FieldName = "BgGruppeCode";
            this.colBgGruppeCode.Name = "colBgGruppeCode";
            this.colBgGruppeCode.Visible = true;
            this.colBgGruppeCode.VisibleIndex = 3;
            this.colBgGruppeCode.Width = 110;
            //
            // colAnteil
            //
            this.colAnteil.AppearanceCell.Options.UseTextOptions = true;
            this.colAnteil.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAnteil.Caption = "%";
            this.colAnteil.DisplayFormat.FormatString = "n0";
            this.colAnteil.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAnteil.FieldName = "Anteil";
            this.colAnteil.Name = "colAnteil";
            this.colAnteil.Visible = true;
            this.colAnteil.VisibleIndex = 4;
            this.colAnteil.Width = 62;
            //
            // colBetrag
            //
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "BetragSum";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            this.colBetrag.Width = 60;
            //
            // colBemerkung
            //
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 6;
            this.colBemerkung.Width = 83;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 64;
            this.picTitel.TabStop = false;
            //
            // chkAlleinerziehend
            //
            this.chkAlleinerziehend.DataMember = "Alleinerziehend";
            this.chkAlleinerziehend.DataSource = this.qryBgPosition;
            this.chkAlleinerziehend.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkAlleinerziehend.Location = new System.Drawing.Point(240, 234);
            this.chkAlleinerziehend.Name = "chkAlleinerziehend";
            this.chkAlleinerziehend.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAlleinerziehend.Properties.Appearance.Options.UseBackColor = true;
            this.chkAlleinerziehend.Properties.Caption = "Alleinerziehend";
            this.chkAlleinerziehend.Properties.ReadOnly = true;
            this.chkAlleinerziehend.Size = new System.Drawing.Size(120, 19);
            this.chkAlleinerziehend.TabIndex = 7;
            this.chkAlleinerziehend.Tag = "";
            this.chkAlleinerziehend.EditValueChanged += new System.EventHandler(this.chkAlleinerziehend_EditValueChanged);
            //
            // edtBetrag
            //
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag.Location = new System.Drawing.Point(112, 254);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.ReadOnly = true;
            this.edtBetrag.Size = new System.Drawing.Size(120, 24);
            this.edtBetrag.TabIndex = 9;
            //
            // lblBgGruppeCode
            //
            this.lblBgGruppeCode.Location = new System.Drawing.Point(16, 208);
            this.lblBgGruppeCode.Name = "lblBgGruppeCode";
            this.lblBgGruppeCode.Size = new System.Drawing.Size(100, 23);
            this.lblBgGruppeCode.TabIndex = 3;
            this.lblBgGruppeCode.Text = "Zulage";
            //
            // lblAnteil
            //
            this.lblAnteil.Location = new System.Drawing.Point(16, 231);
            this.lblAnteil.Name = "lblAnteil";
            this.lblAnteil.Size = new System.Drawing.Size(100, 23);
            this.lblAnteil.TabIndex = 5;
            this.lblAnteil.Text = "% Anteil";
            //
            // lblBetrag
            //
            this.lblBetrag.Location = new System.Drawing.Point(16, 254);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(100, 23);
            this.lblBetrag.TabIndex = 8;
            this.lblBetrag.Text = "Betrag";
            //
            // edtAnteil
            //
            this.edtAnteil.DataMember = "Anteil";
            this.edtAnteil.DataSource = this.qryBgPosition;
            this.edtAnteil.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnteil.Location = new System.Drawing.Point(112, 231);
            this.edtAnteil.Name = "edtAnteil";
            this.edtAnteil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnteil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnteil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnteil.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnteil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnteil.Properties.Appearance.Options.UseFont = true;
            this.edtAnteil.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAnteil.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnteil.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAnteil.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAnteil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAnteil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAnteil.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnteil.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 5)});
            this.edtAnteil.Properties.DisplayMember = "Text";
            this.edtAnteil.Properties.NullText = "";
            this.edtAnteil.Properties.ReadOnly = true;
            this.edtAnteil.Properties.ShowFooter = false;
            this.edtAnteil.Properties.ShowHeader = false;
            this.edtAnteil.Properties.ValueMember = "Code";
            this.edtAnteil.Size = new System.Drawing.Size(120, 24);
            this.edtAnteil.TabIndex = 6;
            this.edtAnteil.EditValueChanged += new System.EventHandler(this.cboAnteil_EditValueChanged);
            //
            // edtBgGruppeCode
            //
            this.edtBgGruppeCode.DataMember = "BgGruppeCode";
            this.edtBgGruppeCode.DataSource = this.qryBgPosition;
            this.edtBgGruppeCode.Location = new System.Drawing.Point(112, 208);
            this.edtBgGruppeCode.Name = "edtBgGruppeCode";
            this.edtBgGruppeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGruppeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGruppeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBgGruppeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgGruppeCode.Properties.DisplayMember = "Text";
            this.edtBgGruppeCode.Properties.NullText = "";
            this.edtBgGruppeCode.Properties.ShowFooter = false;
            this.edtBgGruppeCode.Properties.ShowHeader = false;
            this.edtBgGruppeCode.Properties.ValueMember = "Code";
            this.edtBgGruppeCode.Size = new System.Drawing.Size(232, 24);
            this.edtBgGruppeCode.TabIndex = 4;
            this.edtBgGruppeCode.EditValueChanged += new System.EventHandler(this.edtBgGruppeCode_EditValueChanged);
            //
            // edtNurAktuelle
            //
            this.edtNurAktuelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNurAktuelle.EditValue = false;
            this.edtNurAktuelle.Location = new System.Drawing.Point(543, 8);
            this.edtNurAktuelle.Name = "edtNurAktuelle";
            this.edtNurAktuelle.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktuelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktuelle.Properties.Caption = "Nur aktuelle anzeigen";
            this.edtNurAktuelle.Size = new System.Drawing.Size(129, 19);
            this.edtNurAktuelle.TabIndex = 65;
            this.edtNurAktuelle.CheckedChanged += new System.EventHandler(this.edtNurAktive_CheckedChanged);
            //
            // CtlBgZulagenEFB
            //
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.edtNurAktuelle);
            this.Controls.Add(this.edtBgGruppeCode);
            this.Controls.Add(this.edtAnteil);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.chkAlleinerziehend);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.lblAnteil);
            this.Controls.Add(this.lblBgGruppeCode);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.dblNameVorname);
            this.Name = "CtlBgZulagenEFB";
            this.Size = new System.Drawing.Size(680, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dblNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlleinerziehend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnteil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void cboAnteil_EditValueChanged(object sender, System.EventArgs e)
        {
            if (edtAnteil.UserModified)
            {
                edtAnteil.UserModified = false;
                qryBgPosition[edtAnteil.DataMember] = edtAnteil.EditValue;
            }
        }

        private void chkAlleinerziehend_EditValueChanged(object sender, System.EventArgs e)
        {
            if (chkAlleinerziehend.UserModified)
            {
                chkAlleinerziehend.UserModified = false;
                qryBgPosition[chkAlleinerziehend.DataMember] = chkAlleinerziehend.EditValue;
            }
        }

        private void edtBgGruppeCode_EditValueChanged(object sender, System.EventArgs e)
        {
            object BgGruppeCode;

            if (sender == this.edtBgGruppeCode)
                BgGruppeCode = this.edtBgGruppeCode.EditValue;
            else
                BgGruppeCode = this.qryBgPosition["BgGruppeCode"];

            if (BgGruppeCode.Equals(39100) || BgGruppeCode.Equals(39120) || BgGruppeCode.Equals(39900))
                this.chkAlleinerziehend.EditMode = EditModeType.Normal;
            else
                this.chkAlleinerziehend.EditMode = EditModeType.ReadOnly;

            DataRow[] rows = qryBgPositionsart.DataTable.Select(string.Format("BgGruppeCode = {0} AND BgPositionsartCode <> {0}", DBUtil.SqlLiteral(BgGruppeCode)));
            if (rows.Length == 9)
                this.edtAnteil.EditMode = EditModeType.Normal;
            else
                this.edtAnteil.EditMode = EditModeType.ReadOnly;

            if (rows.Length == 0)
                rows = qryBgPositionsart.DataTable.Select(string.Format("BgGruppeCode = {0}", DBUtil.SqlLiteral(BgGruppeCode)));

            if (rows.Length > 0)
            {
                SqlQuery qry = ShUtil.GetRichtlinie(rows[0]["sqlRichtlinie"], this.BgBudgetID);
                if (qry.Count == 0 || DBUtil.IsEmpty(qry["PR_MIN"]) || !qry["PR_MIN"].Equals(qry["PR_MAX"]))
                    this.edtBetrag.EditMode = EditModeType.Normal;
                else
                    this.edtBetrag.EditMode = EditModeType.ReadOnly;
            }

            this.qryBgPosition.EnableBoundFields();

            if (edtBgGruppeCode.UserModified)
            {
                edtBgGruppeCode.UserModified = false;
                qryBgPosition["BgGruppeCode"] = BgGruppeCode;
            }
        }

        private void edtNurAktive_CheckedChanged(object sender, EventArgs e)
        {
            this.qryBgPosition.Fill(BgBudgetID, edtNurAktuelle.Checked);
        }

        private void qryBgPosition_AfterPost(object sender, EventArgs e)
        {
            //Budget runden
            DBUtil.ExecSQLThrowingException("EXEC spWhBudget_Runden {0}", this.BgBudgetID);

            //Die StoredProcedure überprüft die editierte Masterbudget-Position und erstellt gegebenenfalls eine Nachfolge-Position,
            //falls eine Positionsart verwendet wurde, die während der Finanzplan-Laufzeit terminiert wurde.
            DBUtil.ExecSQLThrowingException("EXEC spWhPositionsart_Masterbudget_Terminieren {0}, {1}", this.BgFinanzplanID, qryBgPosition["BgPositionsartID"]);

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            this.qryBgPosition.RowModified = false;
            this.qryBgPosition.Refresh();
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID"]))
            {
                if (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionID"]))
                {
                    DBUtil.ExecSQL("DELETE FROM BgPosition WHERE BgPositionID = {0}", this.qryBgPosition["BgPositionID"]);
                    this.qryBgPosition["BgPositionID"] = DBNull.Value;
                    this.qryBgPosition["Bemerkung"] = DBNull.Value;

                    this.qryBgPosition.Row.AcceptChanges();
                    this.qryBgPosition.RowModified = false;
                    throw new KissCancelException();
                }
            }

            DBUtil.CheckNotNullField(edtBgGruppeCode, lblBgGruppeCode.Text);

            if (this.edtAnteil.EditMode == EditModeType.Normal)
                DBUtil.CheckNotNullField(edtAnteil, KissMsg.GetMLMessage("CtlBgZulagenEFB", "Anteil", "Anteil"));

            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            SqlQuery qry = ShUtil.GetRichtlinie((int)this.qryBgPosition["BgPositionsartID"], this.BgBudgetID);
            if (qry.Count == 1)
            {
                if (!DBUtil.IsEmpty(qry["PR_MIN"]) && (decimal)this.qryBgPosition["Betrag"] < (decimal)qry["PR_MIN"])
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBgZulagenEFB", "MinZulage", "Die Zulage muss mindestens Fr. {0:n2} betragen", KissMsgCode.MsgInfo, qry["PR_MIN"]), this.edtBetrag);
                else if (!DBUtil.IsEmpty(qry["PR_MAX"]) && (decimal)this.qryBgPosition["Betrag"] > (decimal)qry["PR_MAX"])
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBgZulagenEFB", "MaxZulage", "Die Zulage kann maximal Fr. {0:n2} betragen", KissMsgCode.MsgInfo, qry["PR_MAX"]), this.edtBetrag);
            }

            if ((DBUtil.IsEmpty(qryBgPosition["Buchungstext"]) || qryBgPosition.ColumnModified("BgPositionsartID"))
                && qryBgPositionsart.Find(string.Format("BgPositionsartID = {0}", qryBgPosition["BgPositionsartID"])))
            {
                qryBgPosition["Buchungstext"] = qryBgPositionsart["Name"];
            }

            // Create new Record if needed
            if (DBUtil.IsEmpty(this.qryBgPosition["BgPositionID"]))
            {
                qry = DBUtil.OpenSQL("SELECT * FROM BgPosition WHERE 1 = 0");
                qry.Insert("BgPosition");

                qry["BgBudgetID"] = this.BgBudgetID;
                qry["BaPersonID"] = this.qryBgPosition["BaPersonID_NEW"];

                foreach (DataColumn col in qry.DataTable.Columns)
                    if (this.qryBgPosition.ColumnModified(col.ColumnName))
                        qry[col.ColumnName] = this.qryBgPosition[col.ColumnName];

                qry.Post("BgPosition");

                foreach (DataColumn col in qry.DataTable.Columns)
                    this.qryBgPosition[col.ColumnName] = qry[col.ColumnName];

                this.qryBgPosition.Row.AcceptChanges();
            }
        }

        private void qryBgPosition_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            if (e.ProposedValue.Equals(e.Row[e.Column, DataRowVersion.Current])) return;

            if (e.Column.ColumnName == "BgGruppeCode")
            {
                if (DBUtil.IsEmpty(e.ProposedValue))
                {
                    e.Row["BgPositionsartID"] = e.ProposedValue;
                    return;
                }

                DataRow[] rows = qryBgPositionsart.DataTable.Select(string.Format("BgGruppeCode = {0}", DBUtil.SqlLiteral(e.ProposedValue)));
                if (rows.Length == 1)
                    e.Row["Anteil"] = DBNull.Value;

                if (e.ProposedValue.Equals(LOV.BgGruppeCode.IZU_Alleinerziehend))
                    e.Row["Alleinerziehend"] = true;
                else if (!(e.ProposedValue.Equals(LOV.BgGruppeCode.EFB_Erwerbsaufnahme) || e.ProposedValue.Equals(LOV.BgGruppeCode.EFB) || e.ProposedValue.Equals(39900)))  //39900: ??? (unbekannte BgGruppe)
                    e.Row["Alleinerziehend"] = false;
            }

            if (e.Column.ColumnName == "Betrag" || e.Column.ColumnName == "BgKategorieCode")
            {
                if (!DBUtil.IsEmpty(e.Row["Betrag"]) && !DBUtil.IsEmpty(e.Row["BgKategorieCode"]))
                {
                    e.Row["BetragSum"] = e.Row["BgKategorieCode"].Equals(4) ? -(decimal)e.Row["Betrag"] : e.Row["Betrag"];
                    this.qryBgPosition.RefreshDisplay();
                }
            }
            else if (e.Column.ColumnName == "BgGruppeCode" || e.Column.ColumnName == "Anteil" || e.Column.ColumnName == "Alleinerziehend")
            {
                if (DBUtil.IsEmpty(e.Row["BgGruppeCode"])) return;

                int BgPositionsartCode = (int)e.Row["BgGruppeCode"];

                if (BgPositionsartCode != 39210 && e.Row["Alleinerziehend"].Equals(true))
                    BgPositionsartCode += 10;

                if (!DBUtil.IsEmpty(e.Row["Anteil"]))
                    BgPositionsartCode += (int)e.Row["Anteil"];

                int? posArtID = ShUtil.GetBgPositionsartID(BgPositionsartCode, finanzplanVon, false);
                if (posArtID.HasValue)
                {
                    e.Row["BgPositionsartID"] = posArtID.Value;
                }
            }
            else if (e.Column.ColumnName == "BgPositionsartID")
            {
                if (DBUtil.IsEmpty(e.ProposedValue))
                {
                    e.Row["Alleinerziehend"] = false;
                    e.Row["Anteil"] = DBNull.Value;
                    e.Row["Betrag"] = DBNull.Value;
                }
                else
                {
                    DataRow[] rows = qryBgPositionsart.DataTable.Select(string.Format("BgPositionsartID = {0}", e.ProposedValue));
                    if (rows.Length > 0)
                    {
                        SqlQuery qry = ShUtil.GetRichtlinie(rows[0]["sqlRichtlinie"], this.BgBudgetID);

                        if (qry.Count == 1)
                        {
                            e.Row["BgKategorieCode"] = rows[0]["BgKategorieCode"];
                            e.Row["DatumBis"] = rows[0]["DatumBis"];
                            e.Row["Betrag"] = DBUtil.IsEmpty(qry["PR_DEF"]) ? qry["PR_MIN"] : qry["PR_DEF"];
                        }
                    }
                }
            }
            else
                return;

            this.qryBgPosition.RefreshDisplay();
        }
    }
}