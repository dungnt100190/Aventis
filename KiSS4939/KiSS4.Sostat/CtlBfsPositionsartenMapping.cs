using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sostat
{
    public class CtlBfsPositionsartenMapping : KiSS4.Common.KissSearchUserControl
    {
        #region Enumerations

        enum CreationMode
        {
            Empty = 0,
            Clone = 1,
            Folgeposition = 2
        }

        enum UseCase
        {
            None,
            TerminatePosArtNoSuccessor,
            TerminatePosArtWithSuccessor,
            ImportantFieldModified
        }

        #endregion

        #region Fields

        #region Private Static Fields

        /// The Log4Net logger.
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBFSVariable;
        private DevExpress.XtraGrid.Columns.GridColumn colBgGruppeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKategorieCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private System.ComponentModel.IContainer components = null;
        private KissButtonEdit edtBFSVariable;
        private KiSS4.Gui.KissLookUpEdit edtBgGruppeCodeX;
        private KiSS4.Gui.KissLookUpEdit edtBgKategorieCodeX;
        private KiSS4.Gui.KissLookUpEdit edtBgKostenartIDX;
        private KissCheckEdit edtErzeugtBfsDossier;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KiSS4.Gui.KissGrid grdBgPositionsart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPositionsart;
        private KissLabel lblBFSVariable;
        private KiSS4.Gui.KissLabel lblSucheGruppe;
        private KiSS4.Gui.KissLabel lblSucheKategorie;
        private KiSS4.Gui.KissLabel lblSucheKostenart;
        private KiSS4.Gui.KissLabel lblSucheName;
        private ModulID modul;
        private Dictionary<int, bool> positionsExistCache = new Dictionary<int, bool>();
        private KiSS4.DB.SqlQuery qryBgKostenart;
        private KiSS4.DB.SqlQuery qryBgPositionsart;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsPositionsartenMapping()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBfsPositionsartenMapping));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.grdBgPositionsart = new KiSS4.Gui.KissGrid();
            this.qryBgPositionsart = new KiSS4.DB.SqlQuery();
            this.grvBgPositionsart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBgKategorieCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgGruppeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBFSVariable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblSucheKategorie = new KiSS4.Gui.KissLabel();
            this.edtBgKategorieCodeX = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheGruppe = new KiSS4.Gui.KissLabel();
            this.edtBgGruppeCodeX = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.lblSucheKostenart = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartIDX = new KiSS4.Gui.KissLookUpEdit();
            this.qryBgKostenart = new KiSS4.DB.SqlQuery();
            this.edtBFSVariable = new KiSS4.Gui.KissButtonEdit();
            this.lblBFSVariable = new KiSS4.Gui.KissLabel();
            this.edtErzeugtBfsDossier = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSVariable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSVariable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErzeugtBfsDossier.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(772, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Size = new System.Drawing.Size(796, 387);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBgPositionsart);
            this.tpgListe.Size = new System.Drawing.Size(784, 349);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtBgKostenartIDX);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenart);
            this.tpgSuchen.Controls.Add(this.edtNameX);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.edtBgGruppeCodeX);
            this.tpgSuchen.Controls.Add(this.lblSucheGruppe);
            this.tpgSuchen.Controls.Add(this.edtBgKategorieCodeX);
            this.tpgSuchen.Controls.Add(this.lblSucheKategorie);
            this.tpgSuchen.Size = new System.Drawing.Size(784, 349);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKategorie, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgKategorieCodeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgGruppeCodeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgKostenartIDX, 0);
            //
            // grdBgPositionsart
            //
            this.grdBgPositionsart.DataSource = this.qryBgPositionsart;
            this.grdBgPositionsart.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdBgPositionsart.EmbeddedNavigator.Name = "";
            this.grdBgPositionsart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPositionsart.Location = new System.Drawing.Point(0, 0);
            this.grdBgPositionsart.MainView = this.grvBgPositionsart;
            this.grdBgPositionsart.Name = "grdBgPositionsart";
            this.grdBgPositionsart.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.grdBgPositionsart.Size = new System.Drawing.Size(784, 349);
            this.grdBgPositionsart.TabIndex = 0;
            this.grdBgPositionsart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPositionsart});
            //
            // qryBgPositionsart
            //
            this.qryBgPositionsart.CanUpdate = true;
            this.qryBgPositionsart.HostControl = this;
            this.qryBgPositionsart.SelectStatement = resources.GetString("qryBgPositionsart.SelectStatement");
            this.qryBgPositionsart.TableName = "BgPositionsart";
            //
            // grvBgPositionsart
            //
            this.grvBgPositionsart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPositionsart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.Empty.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPositionsart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPositionsart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPositionsart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPositionsart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPositionsart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPositionsart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPositionsart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPositionsart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPositionsart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.Row.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPositionsart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPositionsart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPositionsart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBgKategorieCode,
            this.colBgGruppeCode,
            this.colKontoNr,
            this.colBFSVariable,
            this.colName});
            this.grvBgPositionsart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPositionsart.GridControl = this.grdBgPositionsart;
            this.grvBgPositionsart.Name = "grvBgPositionsart";
            this.grvBgPositionsart.OptionsBehavior.Editable = false;
            this.grvBgPositionsart.OptionsCustomization.AllowFilter = false;
            this.grvBgPositionsart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPositionsart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPositionsart.OptionsNavigation.UseTabKey = false;
            this.grvBgPositionsart.OptionsView.ColumnAutoWidth = false;
            this.grvBgPositionsart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPositionsart.OptionsView.ShowGroupPanel = false;
            this.grvBgPositionsart.OptionsView.ShowIndicator = false;
            //
            // colBgKategorieCode
            //
            this.colBgKategorieCode.Caption = "Kategorie";
            this.colBgKategorieCode.FieldName = "BgKategorieCode";
            this.colBgKategorieCode.Name = "colBgKategorieCode";
            this.colBgKategorieCode.Visible = true;
            this.colBgKategorieCode.VisibleIndex = 0;
            this.colBgKategorieCode.Width = 150;
            //
            // colBgGruppeCode
            //
            this.colBgGruppeCode.Caption = "Gruppe";
            this.colBgGruppeCode.FieldName = "BgGruppeCode";
            this.colBgGruppeCode.Name = "colBgGruppeCode";
            this.colBgGruppeCode.Visible = true;
            this.colBgGruppeCode.VisibleIndex = 1;
            this.colBgGruppeCode.Width = 150;
            //
            // colKontoNr
            //
            this.colKontoNr.Caption = "LA";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 2;
            //
            // colBFSVariable
            //
            this.colBFSVariable.Caption = "BFS-Var.";
            this.colBFSVariable.FieldName = "VarName";
            this.colBFSVariable.Name = "colBFSVariable";
            this.colBFSVariable.Visible = true;
            this.colBFSVariable.VisibleIndex = 3;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 4;
            this.colName.Width = 324;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // repositoryItemCheckEdit2
            //
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            //
            // lblSucheKategorie
            //
            this.lblSucheKategorie.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKategorie.Name = "lblSucheKategorie";
            this.lblSucheKategorie.Size = new System.Drawing.Size(80, 24);
            this.lblSucheKategorie.TabIndex = 1;
            this.lblSucheKategorie.Text = "Kategorie";
            this.lblSucheKategorie.UseCompatibleTextRendering = true;
            //
            // edtBgKategorieCodeX
            //
            this.edtBgKategorieCodeX.Location = new System.Drawing.Point(117, 40);
            this.edtBgKategorieCodeX.LOVName = "BgKategorie";
            this.edtBgKategorieCodeX.Name = "edtBgKategorieCodeX";
            this.edtBgKategorieCodeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKategorieCodeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKategorieCodeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseFont = true;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKategorieCodeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgKategorieCodeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKategorieCodeX.Properties.NullText = "";
            this.edtBgKategorieCodeX.Properties.ShowFooter = false;
            this.edtBgKategorieCodeX.Properties.ShowHeader = false;
            this.edtBgKategorieCodeX.Size = new System.Drawing.Size(391, 24);
            this.edtBgKategorieCodeX.TabIndex = 2;
            //
            // lblSucheGruppe
            //
            this.lblSucheGruppe.Location = new System.Drawing.Point(31, 70);
            this.lblSucheGruppe.Name = "lblSucheGruppe";
            this.lblSucheGruppe.Size = new System.Drawing.Size(80, 24);
            this.lblSucheGruppe.TabIndex = 3;
            this.lblSucheGruppe.Text = "Gruppe";
            this.lblSucheGruppe.UseCompatibleTextRendering = true;
            //
            // edtBgGruppeCodeX
            //
            this.edtBgGruppeCodeX.Location = new System.Drawing.Point(117, 70);
            this.edtBgGruppeCodeX.LOVName = "BgGruppe";
            this.edtBgGruppeCodeX.Name = "edtBgGruppeCodeX";
            this.edtBgGruppeCodeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGruppeCodeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGruppeCodeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseFont = true;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGruppeCodeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBgGruppeCodeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCodeX.Properties.NullText = "";
            this.edtBgGruppeCodeX.Properties.ShowFooter = false;
            this.edtBgGruppeCodeX.Properties.ShowHeader = false;
            this.edtBgGruppeCodeX.Size = new System.Drawing.Size(391, 24);
            this.edtBgGruppeCodeX.TabIndex = 4;
            //
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(31, 100);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(80, 24);
            this.lblSucheName.TabIndex = 5;
            this.lblSucheName.Text = "BFS-Variable";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // edtNameX
            //
            this.edtNameX.Location = new System.Drawing.Point(117, 100);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Size = new System.Drawing.Size(391, 24);
            this.edtNameX.TabIndex = 6;
            //
            // lblSucheKostenart
            //
            this.lblSucheKostenart.Location = new System.Drawing.Point(31, 130);
            this.lblSucheKostenart.Name = "lblSucheKostenart";
            this.lblSucheKostenart.Size = new System.Drawing.Size(80, 24);
            this.lblSucheKostenart.TabIndex = 7;
            this.lblSucheKostenart.Text = "Kostenart";
            this.lblSucheKostenart.UseCompatibleTextRendering = true;
            //
            // edtBgKostenartIDX
            //
            this.edtBgKostenartIDX.Location = new System.Drawing.Point(117, 130);
            this.edtBgKostenartIDX.Name = "edtBgKostenartIDX";
            this.edtBgKostenartIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKostenartIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKostenartIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgKostenartIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartIDX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgKostenartIDX.Properties.DisplayMember = "Name";
            this.edtBgKostenartIDX.Properties.NullText = "";
            this.edtBgKostenartIDX.Properties.ShowFooter = false;
            this.edtBgKostenartIDX.Properties.ShowHeader = false;
            this.edtBgKostenartIDX.Properties.ValueMember = "BgKostenartID";
            this.edtBgKostenartIDX.Size = new System.Drawing.Size(391, 24);
            this.edtBgKostenartIDX.TabIndex = 8;
            //
            // qryBgKostenart
            //
            this.qryBgKostenart.HostControl = this;
            this.qryBgKostenart.SelectStatement = resources.GetString("qryBgKostenart.SelectStatement");
            //
            // edtBFSVariable
            //
            this.edtBFSVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBFSVariable.DataMember = "VarName";
            this.edtBFSVariable.DataSource = this.qryBgPositionsart;
            this.edtBFSVariable.Location = new System.Drawing.Point(85, 397);
            this.edtBFSVariable.Name = "edtBFSVariable";
            this.edtBFSVariable.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSVariable.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSVariable.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSVariable.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSVariable.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSVariable.Properties.Appearance.Options.UseFont = true;
            this.edtBFSVariable.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBFSVariable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBFSVariable.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSVariable.SearchStringWhitelist = new string[] {
            ".",
            "*",
            "%"};
            this.edtBFSVariable.Size = new System.Drawing.Size(568, 24);
            this.edtBFSVariable.TabIndex = 19;
            this.edtBFSVariable.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBFSVariable_UserModifiedFld);
            //
            // lblBFSVariable
            //
            this.lblBFSVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBFSVariable.Location = new System.Drawing.Point(8, 397);
            this.lblBFSVariable.Name = "lblBFSVariable";
            this.lblBFSVariable.Size = new System.Drawing.Size(71, 24);
            this.lblBFSVariable.TabIndex = 18;
            this.lblBFSVariable.Text = "BFS Variable";
            this.lblBFSVariable.UseCompatibleTextRendering = true;
            //
            // edtErzeugtBfsDossier
            //
            this.edtErzeugtBfsDossier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErzeugtBfsDossier.DataMember = "ErzeugtBfsDossier";
            this.edtErzeugtBfsDossier.DataSource = this.qryBgPositionsart;
            this.edtErzeugtBfsDossier.Location = new System.Drawing.Point(663, 399);
            this.edtErzeugtBfsDossier.Name = "edtErzeugtBfsDossier";
            this.edtErzeugtBfsDossier.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtErzeugtBfsDossier.Properties.Appearance.Options.UseBackColor = true;
            this.edtErzeugtBfsDossier.Properties.Caption = "Erzeugt BFS-Dossier";
            this.edtErzeugtBfsDossier.Size = new System.Drawing.Size(122, 19);
            this.edtErzeugtBfsDossier.TabIndex = 39;
            //
            // CtlBfsPositionsartenMapping
            //
            this.ActiveSQLQuery = this.qryBgPositionsart;
            this.Controls.Add(this.edtErzeugtBfsDossier);
            this.Controls.Add(this.edtBFSVariable);
            this.Controls.Add(this.lblBFSVariable);
            this.Name = "CtlBfsPositionsartenMapping";
            this.Size = new System.Drawing.Size(802, 433);
            this.Load += new System.EventHandler(this.CtlBgPositionsart_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblBFSVariable, 0);
            this.Controls.SetChildIndex(this.edtBFSVariable, 0);
            this.Controls.SetChildIndex(this.edtErzeugtBfsDossier, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSVariable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSVariable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErzeugtBfsDossier.Properties)).EndInit();
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

        private void CtlBgPositionsart_Load(object sender, System.EventArgs e)
        {
            colBgKategorieCode.ColumnEdit = this.grdBgPositionsart.GetLOVLookUpEdit("BgKategorie");
            colBgGruppeCode.ColumnEdit = this.grdBgPositionsart.GetLOVLookUpEdit("BgGruppe");

            qryBgKostenart.Fill();

            edtBgKostenartIDX.LoadQuery(qryBgKostenart, "BgKostenartID", "NrName");

            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        private void edtBFSVariable_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (String.IsNullOrEmpty(edtBFSVariable.Text) && !e.ButtonClicked)
            {
                qryBgPositionsart["VarName"] = "";
            }
            else
            {
                DlgAuswahl dlg = new DlgAuswahl();

                int bfsFrageKatalogJahr = DateTime.Now.Year;

                e.Cancel = !dlg.SucheBfsVariable(bfsFrageKatalogJahr, LOV.BFSFeldCode.Zahl, edtBFSVariable.Text);

                if (!e.Cancel)
                {
                    qryBgPositionsart["VarName"] = dlg["Variable"];
                }
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // BFS-Variable soll nur sichtbar sein, wenn die Liste dargstellt ist
            if (page == tpgListe)
            {
                lblBFSVariable.Visible = true;
                edtBFSVariable.Visible = true;
                edtErzeugtBfsDossier.Visible = true;
            }
            else
            {
                lblBFSVariable.Visible = false;
                edtBFSVariable.Visible = false;
                edtErzeugtBfsDossier.Visible = false;
            }
        }

        #endregion
    }
}