using System;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Administration
{
    public class CtlKostenart : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private ModulID _modul;
        private DevExpress.XtraGrid.Columns.GridColumn colBaWVZeileCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKostenartID;
        private DevExpress.XtraGrid.Columns.GridColumn colHauptvorgang;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuoting;
        private DevExpress.XtraGrid.Columns.GridColumn colSplittingart;
        private DevExpress.XtraGrid.Columns.GridColumn colTeilvorgang;
        private System.ComponentModel.IContainer components;
        private KissLookUpEdit edBaWVZeileCode;
        private KiSS4.Gui.KissLookUpEdit edSplittingart;
        private KiSS4.Gui.KissCheckEdit editReadOnly;
        private KiSS4.Gui.KissCalcEdit edtBgKostenartID;
        private KiSS4.Gui.KissCalcEdit edtKontoNr;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissCheckEdit edtQuoting;
        private KiSS4.Gui.KissGrid grdBgKostenart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgKostenart;
        private KissLabel lblBaWVZeileCode;
        private KiSS4.Gui.KissLabel lblBgKostenartID;
        private KiSS4.Gui.KissLabel lblKontoNr;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblSplittingart;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.DB.SqlQuery qryBgKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlKostenart(ModulID modul)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            _modul = modul;
            colSplittingart.ColumnEdit = grdBgKostenart.GetLOVLookUpEdit("BgSplittingart");
            colBaWVZeileCode.ColumnEdit = grdBgKostenart.GetLOVLookUpEdit("BaWVZeile");

            if (_modul == ModulID.A)
            {
                edBaWVZeileCode.EditMode = EditModeType.ReadOnly;
            }
        }

        public CtlKostenart()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBaWVZeileCode = new KiSS4.Gui.KissLabel();
            this.edBaWVZeileCode = new KiSS4.Gui.KissLookUpEdit();
            this.qryBgKostenart = new KiSS4.DB.SqlQuery(this.components);
            this.edtQuoting = new KiSS4.Gui.KissCheckEdit();
            this.edSplittingart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSplittingart = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtKontoNr = new KiSS4.Gui.KissCalcEdit();
            this.lblKontoNr = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartID = new KiSS4.Gui.KissCalcEdit();
            this.lblBgKostenartID = new KiSS4.Gui.KissLabel();
            this.editReadOnly = new KiSS4.Gui.KissCheckEdit();
            this.grdBgKostenart = new KiSS4.Gui.KissGrid();
            this.grvBgKostenart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBgKostenartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHauptvorgang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeilvorgang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSplittingart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuoting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaWVZeileCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaWVZeileCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBaWVZeileCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBaWVZeileCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuoting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSplittingart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSplittingart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSplittingart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBaWVZeileCode);
            this.panel1.Controls.Add(this.edBaWVZeileCode);
            this.panel1.Controls.Add(this.edtQuoting);
            this.panel1.Controls.Add(this.edSplittingart);
            this.panel1.Controls.Add(this.lblSplittingart);
            this.panel1.Controls.Add(this.edtName);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.edtKontoNr);
            this.panel1.Controls.Add(this.lblKontoNr);
            this.panel1.Controls.Add(this.edtBgKostenartID);
            this.panel1.Controls.Add(this.lblBgKostenartID);
            this.panel1.Controls.Add(this.editReadOnly);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 181);
            this.panel1.TabIndex = 0;
            // 
            // lblBaWVZeileCode
            // 
            this.lblBaWVZeileCode.Location = new System.Drawing.Point(6, 126);
            this.lblBaWVZeileCode.Name = "lblBaWVZeileCode";
            this.lblBaWVZeileCode.Size = new System.Drawing.Size(110, 24);
            this.lblBaWVZeileCode.TabIndex = 14;
            this.lblBaWVZeileCode.Text = "Weiterverrechenbar";
            this.lblBaWVZeileCode.UseCompatibleTextRendering = true;
            // 
            // edBaWVZeileCode
            // 
            this.edBaWVZeileCode.DataMember = "BaWVZeileCode";
            this.edBaWVZeileCode.DataSource = this.qryBgKostenart;
            this.edBaWVZeileCode.Location = new System.Drawing.Point(122, 126);
            this.edBaWVZeileCode.LOVName = "BaWVZeile";
            this.edBaWVZeileCode.Name = "edBaWVZeileCode";
            this.edBaWVZeileCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edBaWVZeileCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edBaWVZeileCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edBaWVZeileCode.Properties.Appearance.Options.UseBackColor = true;
            this.edBaWVZeileCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edBaWVZeileCode.Properties.Appearance.Options.UseFont = true;
            this.edBaWVZeileCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edBaWVZeileCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edBaWVZeileCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edBaWVZeileCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edBaWVZeileCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edBaWVZeileCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edBaWVZeileCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edBaWVZeileCode.Properties.NullText = "";
            this.edBaWVZeileCode.Properties.ShowFooter = false;
            this.edBaWVZeileCode.Properties.ShowHeader = false;
            this.edBaWVZeileCode.Size = new System.Drawing.Size(184, 24);
            this.edBaWVZeileCode.TabIndex = 13;
            // 
            // qryBgKostenart
            // 
            this.qryBgKostenart.HostControl = this;
            this.qryBgKostenart.SelectStatement = "SELECT *\r\nFROM BgKostenart\r\nWHERE ModulID = {0}";
            this.qryBgKostenart.TableName = "BgKostenart";
            this.qryBgKostenart.AfterInsert += new System.EventHandler(this.qryBgKostenart_AfterInsert);
            this.qryBgKostenart.BeforePost += new System.EventHandler(this.qryBgKostenart_BeforePost);
            // 
            // edtQuoting
            // 
            this.edtQuoting.DataMember = "Quoting";
            this.edtQuoting.DataSource = this.qryBgKostenart;
            this.edtQuoting.Location = new System.Drawing.Point(122, 156);
            this.edtQuoting.Name = "edtQuoting";
            this.edtQuoting.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtQuoting.Properties.Appearance.Options.UseBackColor = true;
            this.edtQuoting.Properties.Caption = "Quoting";
            this.edtQuoting.Size = new System.Drawing.Size(184, 19);
            this.edtQuoting.TabIndex = 11;
            // 
            // edSplittingart
            // 
            this.edSplittingart.DataMember = "BgSplittingArtCode";
            this.edSplittingart.DataSource = this.qryBgKostenart;
            this.edSplittingart.Location = new System.Drawing.Point(122, 96);
            this.edSplittingart.LOVName = "BgSplittingart";
            this.edSplittingart.Name = "edSplittingart";
            this.edSplittingart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edSplittingart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edSplittingart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edSplittingart.Properties.Appearance.Options.UseBackColor = true;
            this.edSplittingart.Properties.Appearance.Options.UseBorderColor = true;
            this.edSplittingart.Properties.Appearance.Options.UseFont = true;
            this.edSplittingart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edSplittingart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edSplittingart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edSplittingart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edSplittingart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edSplittingart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edSplittingart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edSplittingart.Properties.NullText = "";
            this.edSplittingart.Properties.ShowFooter = false;
            this.edSplittingart.Properties.ShowHeader = false;
            this.edSplittingart.Size = new System.Drawing.Size(184, 24);
            this.edSplittingart.TabIndex = 10;
            // 
            // lblSplittingart
            // 
            this.lblSplittingart.Location = new System.Drawing.Point(6, 96);
            this.lblSplittingart.Name = "lblSplittingart";
            this.lblSplittingart.Size = new System.Drawing.Size(110, 24);
            this.lblSplittingart.TabIndex = 9;
            this.lblSplittingart.Text = "Splittingart";
            this.lblSplittingart.UseCompatibleTextRendering = true;
            // 
            // edtName
            // 
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBgKostenart;
            this.edtName.Location = new System.Drawing.Point(122, 66);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(525, 24);
            this.edtName.TabIndex = 8;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(6, 66);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 24);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Kostenart";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtKontoNr
            // 
            this.edtKontoNr.DataMember = "KontoNr";
            this.edtKontoNr.DataSource = this.qryBgKostenart;
            this.edtKontoNr.Location = new System.Drawing.Point(122, 36);
            this.edtKontoNr.Name = "edtKontoNr";
            this.edtKontoNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoNr.Size = new System.Drawing.Size(48, 24);
            this.edtKontoNr.TabIndex = 6;
            // 
            // lblKontoNr
            // 
            this.lblKontoNr.Location = new System.Drawing.Point(6, 36);
            this.lblKontoNr.Name = "lblKontoNr";
            this.lblKontoNr.Size = new System.Drawing.Size(110, 24);
            this.lblKontoNr.TabIndex = 5;
            this.lblKontoNr.Text = "Konto-Nr.";
            this.lblKontoNr.UseCompatibleTextRendering = true;
            // 
            // edtBgKostenartID
            // 
            this.edtBgKostenartID.DataMember = "BgKostenartID";
            this.edtBgKostenartID.DataSource = this.qryBgKostenart;
            this.edtBgKostenartID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgKostenartID.Location = new System.Drawing.Point(122, 6);
            this.edtBgKostenartID.Name = "edtBgKostenartID";
            this.edtBgKostenartID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.Properties.ReadOnly = true;
            this.edtBgKostenartID.Size = new System.Drawing.Size(48, 24);
            this.edtBgKostenartID.TabIndex = 2;
            // 
            // lblBgKostenartID
            // 
            this.lblBgKostenartID.Location = new System.Drawing.Point(6, 6);
            this.lblBgKostenartID.Name = "lblBgKostenartID";
            this.lblBgKostenartID.Size = new System.Drawing.Size(110, 24);
            this.lblBgKostenartID.TabIndex = 1;
            this.lblBgKostenartID.Text = "ID";
            this.lblBgKostenartID.UseCompatibleTextRendering = true;
            // 
            // editReadOnly
            // 
            this.editReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editReadOnly.EditValue = true;
            this.editReadOnly.Location = new System.Drawing.Point(913, 9);
            this.editReadOnly.Name = "editReadOnly";
            this.editReadOnly.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.editReadOnly.Properties.Appearance.Options.UseBackColor = true;
            this.editReadOnly.Properties.Caption = "Schreibschutz";
            this.editReadOnly.Size = new System.Drawing.Size(104, 19);
            this.editReadOnly.TabIndex = 0;
            this.editReadOnly.CheckedChanged += new System.EventHandler(this.editReadOnly_CheckedChanged);
            // 
            // grdBgKostenart
            // 
            this.grdBgKostenart.DataSource = this.qryBgKostenart;
            this.grdBgKostenart.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBgKostenart.EmbeddedNavigator.Name = "";
            this.grdBgKostenart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgKostenart.Location = new System.Drawing.Point(0, 0);
            this.grdBgKostenart.MainView = this.grvBgKostenart;
            this.grdBgKostenart.Name = "grdBgKostenart";
            this.grdBgKostenart.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdBgKostenart.Size = new System.Drawing.Size(1020, 446);
            this.grdBgKostenart.TabIndex = 1;
            this.grdBgKostenart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgKostenart});
            // 
            // grvBgKostenart
            // 
            this.grvBgKostenart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgKostenart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.Empty.Options.UseFont = true;
            this.grvBgKostenart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgKostenart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgKostenart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgKostenart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgKostenart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgKostenart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgKostenart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgKostenart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgKostenart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgKostenart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgKostenart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgKostenart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgKostenart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgKostenart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgKostenart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgKostenart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgKostenart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgKostenart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgKostenart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgKostenart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgKostenart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgKostenart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgKostenart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgKostenart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgKostenart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgKostenart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.OddRow.Options.UseFont = true;
            this.grvBgKostenart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgKostenart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.Row.Options.UseBackColor = true;
            this.grvBgKostenart.Appearance.Row.Options.UseFont = true;
            this.grvBgKostenart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgKostenart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgKostenart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgKostenart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgKostenart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgKostenart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBgKostenartID,
            this.colName,
            this.colKontoNr,
            this.colHauptvorgang,
            this.colTeilvorgang,
            this.colSplittingart,
            this.colQuoting,
            this.colBaWVZeileCode});
            this.grvBgKostenart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgKostenart.GridControl = this.grdBgKostenart;
            this.grvBgKostenart.Name = "grvBgKostenart";
            this.grvBgKostenart.OptionsBehavior.Editable = false;
            this.grvBgKostenart.OptionsCustomization.AllowFilter = false;
            this.grvBgKostenart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgKostenart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgKostenart.OptionsNavigation.UseTabKey = false;
            this.grvBgKostenart.OptionsView.ColumnAutoWidth = false;
            this.grvBgKostenart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgKostenart.OptionsView.ShowGroupPanel = false;
            this.grvBgKostenart.OptionsView.ShowIndicator = false;
            // 
            // colBgKostenartID
            // 
            this.colBgKostenartID.Caption = "ID";
            this.colBgKostenartID.FieldName = "BgKostenartID";
            this.colBgKostenartID.Name = "colBgKostenartID";
            this.colBgKostenartID.Visible = true;
            this.colBgKostenartID.VisibleIndex = 0;
            this.colBgKostenartID.Width = 60;
            // 
            // colName
            // 
            this.colName.Caption = "Kostenart";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 300;
            // 
            // colHauptvorgang
            // 
            this.colHauptvorgang.Caption = "Hauptvorgang";
            this.colHauptvorgang.Name = "colHauptvorgang";
            // 
            // colTeilvorgang
            // 
            this.colTeilvorgang.Caption = "Teilvorgang";
            this.colTeilvorgang.Name = "colTeilvorgang";
            // 
            // colSplittingart
            // 
            this.colSplittingart.Caption = "Splittingart";
            this.colSplittingart.FieldName = "BgSplittingArtCode";
            this.colSplittingart.Name = "colSplittingart";
            this.colSplittingart.Visible = true;
            this.colSplittingart.VisibleIndex = 3;
            this.colSplittingart.Width = 80;
            // 
            // colQuoting
            // 
            this.colQuoting.Caption = "Quoting";
            this.colQuoting.FieldName = "Quoting";
            this.colQuoting.Name = "colQuoting";
            this.colQuoting.Visible = true;
            this.colQuoting.VisibleIndex = 4;
            this.colQuoting.Width = 65;
            // 
            // colBaWVZeileCode
            // 
            this.colBaWVZeileCode.Caption = "Weiterverrechenbar";
            this.colBaWVZeileCode.FieldName = "BaWVZeileCode";
            this.colBaWVZeileCode.Name = "colBaWVZeileCode";
            this.colBaWVZeileCode.Visible = true;
            this.colBaWVZeileCode.VisibleIndex = 5;
            this.colBaWVZeileCode.Width = 239;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "KontoNr";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 2;
            // 
            // CtlKostenart
            // 
            this.ActiveSQLQuery = this.qryBgKostenart;
            this.Controls.Add(this.grdBgKostenart);
            this.Controls.Add(this.panel1);
            this.Name = "CtlKostenart";
            this.Size = new System.Drawing.Size(1020, 627);
            this.Load += new System.EventHandler(this.CtlKostenart_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBaWVZeileCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBaWVZeileCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBaWVZeileCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuoting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSplittingart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSplittingart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSplittingart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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

        private void CtlKostenart_Load(object sender, System.EventArgs e)
        {
            qryBgKostenart.Fill(Convert.ToInt32(_modul));
        }

        private void editReadOnly_CheckedChanged(Object sender, System.EventArgs e)
        {
            if (!qryBgKostenart.Post())
            {
                return;
            }

            qryBgKostenart.CanDelete = !editReadOnly.Checked;
            qryBgKostenart.CanInsert = !editReadOnly.Checked;
            qryBgKostenart.CanUpdate = !editReadOnly.Checked;

            qryBgKostenart.ApplyUserRights();
            qryBgKostenart.Refresh();
        }

        private void qryBgKostenart_AfterInsert(object sender, System.EventArgs e)
        {
            // apply modulid
            qryBgKostenart[DBO.BgKostenart.ModulID] = Convert.ToInt32(_modul);

            edtBgKostenartID.Focus();
        }

        private void qryBgKostenart_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtName, lblName.Text);
        }

        #endregion
    }
}