using System;
using System.Data;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Sozialhilfe
{
    public class CtlBgAlimente : KiSS4.Gui.KissUserControl
    {
        private const LOV.BgGruppeCode BgGruppeCode = LOV.BgGruppeCode.Alimentenguthaben;
        private int BgBudgetID;
        private int BgFinanzplanID;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBgPositionsartID;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID;
        private KiSS4.Gui.KissMemoEdit edtHilfeText;
        private KiSS4.Gui.KissCheckEdit edtNurAktuelle;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBgPositionsartID;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private SqlQuery qryBgPositionsart;

        public CtlBgAlimente()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlBgAlimente(Image titelImage, string titelText, int bgBudgetID)
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
                , bgBudgetID);
            this.BgFinanzplanID = Utils.ConvertToInt(qry["BgFinanzplanID"]);
            this.lblTitel.Text = string.Format(this.lblTitel.Text, qry["FinanzplanVon"], qry["FinanzplanBis"], titelText);

            //zur Bestimmung der gültigen BgPositionsartIDs wird der Gültigkeitsbereich des Finanzplans verwendet.
            DateTime datumVon = Utils.ConvertToDateTime(qry["FinanzplanVon"]);
            DateTime datumBis = Utils.ConvertToDateTime(qry["FinanzplanBis"]);

            qry = ShUtil.GetPersonen_Unterstuetzt(BgBudgetID);
            this.colBaPersonID.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qry, "BaPersonID", "NameVorname");
            this.edtBaPersonID.LoadQuery(qry, "BaPersonID", "NameVorname");

            qryBgPositionsart = ShUtil.GetSqlQueryShPositionTyp(BgGruppeCode, datumVon, datumBis, false);
            this.colBgPositionsartID.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qryBgPositionsart);
            this.edtBgPositionsartID.LoadQuery(qryBgPositionsart);

            ShUtil.ApplyShStatusCodeToSqlQuery(this.ActiveSQLQuery, BgBudgetID);
            this.qryBgPosition.Fill(qryBgPosition.SelectStatement, BgBudgetID, BgGruppeCode, edtNurAktuelle.Checked);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgAlimente));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgPositionsartID = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgPositionsartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtHilfeText = new KiSS4.Gui.KissMemoEdit();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtNurAktuelle = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // lblBetrag
            //
            this.lblBetrag.Location = new System.Drawing.Point(8, 295);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(168, 24);
            this.lblBetrag.TabIndex = 51;
            this.lblBetrag.Text = "Monatliches Alimentenguthaben";
            //
            // edtBetrag
            //
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(192, 295);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            this.edtBetrag.Size = new System.Drawing.Size(112, 24);
            this.edtBetrag.TabIndex = 50;
            //
            // qryBgPosition
            //
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            //
            // lblBemerkung
            //
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 320);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(112, 16);
            this.lblBemerkung.TabIndex = 49;
            this.lblBemerkung.Text = "Beschreibung";
            //
            // edtBgPositionsartID
            //
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgPosition;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(192, 216);
            this.edtBgPositionsartID.Name = "edtBgPositionsartID";
            this.edtBgPositionsartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgPositionsartID.Properties.DisplayMember = "Text";
            this.edtBgPositionsartID.Properties.NullText = "";
            this.edtBgPositionsartID.Properties.ShowFooter = false;
            this.edtBgPositionsartID.Properties.ShowHeader = false;
            this.edtBgPositionsartID.Properties.ValueMember = "Code";
            this.edtBgPositionsartID.Size = new System.Drawing.Size(480, 24);
            this.edtBgPositionsartID.TabIndex = 48;
            this.edtBgPositionsartID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBgPositionsartID_UserModifiedFld);
            this.edtBgPositionsartID.EditValueChanged += new System.EventHandler(this.edtBgPositionsartID_EditValueChanged);
            //
            // lblBgPositionsartID
            //
            this.lblBgPositionsartID.Location = new System.Drawing.Point(8, 216);
            this.lblBgPositionsartID.Name = "lblBgPositionsartID";
            this.lblBgPositionsartID.Size = new System.Drawing.Size(144, 24);
            this.lblBgPositionsartID.TabIndex = 47;
            this.lblBgPositionsartID.Text = "Inkasso- und Auszahlungsart";
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 46;
            this.lblTitel.Text = "Monatliches Alimentenguthaben vom {0:d} bis {1:d}";
            //
            // grdBgPosition
            //
            this.grdBgPosition.DataSource = this.qryBgPosition;
            //
            //
            //
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(8, 30);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(664, 150);
            this.grdBgPosition.TabIndex = 45;
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
            this.colBaPersonID,
            this.colGeburtsdatum,
            this.colBgPositionsartID,
            this.colBetrag});
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
            // colBaPersonID
            //
            this.colBaPersonID.Caption = "Name";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 1;
            this.colBaPersonID.Width = 190;
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
            // colBgPositionsartID
            //
            this.colBgPositionsartID.Caption = "Inkasso- und Auszahlungsart";
            this.colBgPositionsartID.FieldName = "BgPositionsartID";
            this.colBgPositionsartID.Name = "colBgPositionsartID";
            this.colBgPositionsartID.Visible = true;
            this.colBgPositionsartID.VisibleIndex = 3;
            this.colBgPositionsartID.Width = 241;
            //
            // colBetrag
            //
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Einkommen";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            //
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 336);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 144);
            this.edtBemerkung.TabIndex = 44;
            //
            // edtHilfeText
            //
            this.edtHilfeText.DataMember = "HilfeText";
            this.edtHilfeText.DataSource = this.qryBgPosition;
            this.edtHilfeText.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHilfeText.Location = new System.Drawing.Point(192, 239);
            this.edtHilfeText.Name = "edtHilfeText";
            this.edtHilfeText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHilfeText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHilfeText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHilfeText.Properties.Appearance.Options.UseBackColor = true;
            this.edtHilfeText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHilfeText.Properties.Appearance.Options.UseFont = true;
            this.edtHilfeText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHilfeText.Properties.ReadOnly = true;
            this.edtHilfeText.Size = new System.Drawing.Size(480, 57);
            this.edtHilfeText.TabIndex = 53;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 54;
            this.picTitel.TabStop = false;
            //
            // lblBaPersonID
            //
            this.lblBaPersonID.Location = new System.Drawing.Point(11, 186);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(175, 24);
            this.lblBaPersonID.TabIndex = 59;
            this.lblBaPersonID.Text = "Person";
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(192, 186);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "Code";
            this.edtBaPersonID.Size = new System.Drawing.Size(480, 24);
            this.edtBaPersonID.TabIndex = 58;
            //
            // edtNurAktuelle
            //
            this.edtNurAktuelle.EditValue = false;
            this.edtNurAktuelle.Location = new System.Drawing.Point(543, 8);
            this.edtNurAktuelle.Name = "edtNurAktuelle";
            this.edtNurAktuelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAktuelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktuelle.Properties.Caption = "Nur aktuelle anzeigen";
            this.edtNurAktuelle.Size = new System.Drawing.Size(129, 19);
            this.edtNurAktuelle.TabIndex = 60;
            this.edtNurAktuelle.CheckedChanged += new System.EventHandler(this.edtNurAktive_CheckedChanged);
            //
            // CtlBgAlimente
            //
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.edtNurAktuelle);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.edtHilfeText);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtBgPositionsartID);
            this.Controls.Add(this.lblBgPositionsartID);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.edtBemerkung);
            this.Name = "CtlBgAlimente";
            this.Size = new System.Drawing.Size(680, 488);
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void edtBgPositionsartID_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                int bgPositionsartID = (int)this.edtBgPositionsartID.EditValue;
                SetBgPositionsartID(bgPositionsartID, false);
            }
            catch { }
        }

        private void edtBgPositionsartID_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            try
            {
                int bgPositionsartID = (int)this.edtBgPositionsartID.EditValue;
                SetBgPositionsartID(bgPositionsartID, true);
            }
            catch { }

            edtBgPositionsartID.BindingManager.EndCurrentEdit();
        }

        private void edtNurAktive_CheckedChanged(object sender, EventArgs e)
        {
            this.qryBgPosition.Fill(BgBudgetID, BgGruppeCode, edtNurAktuelle.Checked);
        }

        private void qryBgPosition_AfterInsert(object sender, System.EventArgs e)
        {
            this.qryBgPosition["BgBudgetID"] = this.BgBudgetID;
            this.qryBgPosition["BgKategorieCode"] = 1;

            this.edtBaPersonID.Focus();
        }

        private void qryBgPosition_AfterPost(object sender, System.EventArgs e)
        {
            //Budget runden
            DBUtil.ExecSQLThrowingException("EXEC spWhBudget_Runden {0}", this.BgBudgetID);

            //Die StoredProcedure überprüft die editierte Masterbudget-Position und erstellt gegebenenfalls eine Nachfolge-Position,
            //falls eine Positionsart verwendet wurde, die während der Finanzplan-Laufzeit terminiert wurde.
            DBUtil.ExecSQLThrowingException("EXEC spWhPositionsart_Masterbudget_Terminieren {0}, {1}", this.BgFinanzplanID, qryBgPosition["BgPositionsartID"]);

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            qryBgPosition.RowModified = false;
            qryBgPosition.Refresh();
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBaPersonID, lblBaPersonID.Text);

            DBUtil.CheckNotNullField(edtBgPositionsartID, lblBgPositionsartID.Text);

            if ((DBUtil.IsEmpty(qryBgPosition["Buchungstext"]) || qryBgPosition.ColumnModified("BgPositionsartID"))
                && qryBgPositionsart.Find(string.Format("BgPositionsartID = {0}", qryBgPosition["BgPositionsartID"])))
            {
                qryBgPosition["Buchungstext"] = qryBgPositionsart["Name"];
            }
        }

        private void SetBgPositionsartID(int bgPositionsartID, bool updateVerwaltungSD)
        {
            if (qryBgPosition.CanUpdate)
            {
                qryBgPosition["BgPositionsartID"] = bgPositionsartID;
            }
            SqlQuery qry = (SqlQuery)this.edtBgPositionsartID.Properties.DataSource;

            DataRow[] rows = qry.DataTable.Select("Code = " + DBUtil.SqlLiteral(bgPositionsartID));
            if (rows.Length > 0)
            {
                if (updateVerwaltungSD)
                {
                    // Verwaltung SD setzen
                    qryBgPosition["VerwaltungSD"] = rows[0]["VerwaltungSD_Default"];
                }
                this.edtHilfeText.EditValue = rows[0]["HilfeText"];
            }
        }
    }
}