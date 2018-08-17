using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.XtraEditors;

namespace KiSS4.Basis
{
    public class FrmRavBerater : KiSS4.Gui.KissChildForm
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_KONTAKT_INSTITUTION_NAME = "Institution";

        #endregion

        #region Private Fields

        private string aName = string.Empty;
        private string aVorname = string.Empty;
        private DevExpress.XtraGrid.Columns.GridColumn colMail;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colRavStelle;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissTextEdit editAnrede;
        private KiSS4.Gui.KissButtonEdit editBaInstitutionID;
        private KiSS4.Gui.KissButtonEdit editBaInstitutionIDX;
        private KiSS4.Gui.KissRTFEdit editBemerkungRTF;
        private KiSS4.Gui.KissTextEdit editEMail;
        private KiSS4.Gui.KissTextEdit editEMailX;
        private KiSS4.Gui.KissTextEdit editFax;
        private KiSS4.Gui.KissTextEdit editName;
        private KiSS4.Gui.KissTextEdit editNameX;
        private KiSS4.Gui.KissLookUpEdit editSprache;
        private KiSS4.Gui.KissTextEdit editTelefon;
        private KiSS4.Gui.KissTextEdit editTelefonX;
        private KiSS4.Gui.KissTextEdit editVorname;
        private KiSS4.Gui.KissTextEdit editVornameX;
        private KiSS4.Gui.KissGrid gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissLabel lblAnrede;
        private KiSS4.Gui.KissLabel lblBaInstitutionID;
        private KiSS4.Gui.KissLabel lblBaInstitutionIDX;
        private KiSS4.Gui.KissLabel lblBemerkungRFT;
        private KiSS4.Gui.KissLabel lblEMail;
        private KiSS4.Gui.KissLabel lblEMailX;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblNameX;
        private KiSS4.Gui.KissLabel lblSprache;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblTelefonX;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissLabel lblVornameX;
        private System.Windows.Forms.Panel panel4;
        private KiSS4.DB.SqlQuery qryKontakt;
        private SharpLibrary.WinControls.TabPageEx tabListe;
        private SharpLibrary.WinControls.TabPageEx tabSuchen;
        private KiSS4.Gui.KissTabControlEx xTabControl1;

        #endregion

        #endregion

        #region Constructors

        public FrmRavBerater()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public FrmRavBerater(string Name, string Vorname)
        {
            aName = Name;
            aVorname = Vorname;

            InitializeComponent();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xTabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tabListe = new SharpLibrary.WinControls.TabPageEx();
            this.gridList = new KiSS4.Gui.KissGrid();
            this.qryKontakt = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRavStelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.editBaInstitutionIDX = new KiSS4.Gui.KissButtonEdit();
            this.lblVornameX = new KiSS4.Gui.KissLabel();
            this.editVornameX = new KiSS4.Gui.KissTextEdit();
            this.lblBaInstitutionIDX = new KiSS4.Gui.KissLabel();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.lblTelefonX = new KiSS4.Gui.KissLabel();
            this.editTelefonX = new KiSS4.Gui.KissTextEdit();
            this.lblEMailX = new KiSS4.Gui.KissLabel();
            this.editEMailX = new KiSS4.Gui.KissTextEdit();
            this.lblNameX = new KiSS4.Gui.KissLabel();
            this.editNameX = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblBaInstitutionID = new KiSS4.Gui.KissLabel();
            this.editBemerkungRTF = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkungRFT = new KiSS4.Gui.KissLabel();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.editVorname = new KiSS4.Gui.KissTextEdit();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.editEMail = new KiSS4.Gui.KissTextEdit();
            this.lblSprache = new KiSS4.Gui.KissLabel();
            this.editSprache = new KiSS4.Gui.KissLookUpEdit();
            this.editFax = new KiSS4.Gui.KissTextEdit();
            this.editTelefon = new KiSS4.Gui.KissTextEdit();
            this.editName = new KiSS4.Gui.KissTextEdit();
            this.editAnrede = new KiSS4.Gui.KissTextEdit();
            this.lblAnrede = new KiSS4.Gui.KissLabel();
            this.editBaInstitutionID = new KiSS4.Gui.KissButtonEdit();
            this.xTabControl1.SuspendLayout();
            this.tabListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabSuchen.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editBaInstitutionIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornameX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVornameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaInstitutionIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTelefonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMailX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEMailX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaInstitutionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungRFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBaInstitutionID.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // xTabControl1
            //
            this.xTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.xTabControl1.BorderStyleEx = SharpLibrary.WinControls.BorderStyleEx.FixedSingle;
            this.xTabControl1.Controls.Add(this.tabListe);
            this.xTabControl1.Controls.Add(this.tabSuchen);
            this.xTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xTabControl1.Location = new System.Drawing.Point(5, 10);
            this.xTabControl1.Name = "xTabControl1";
            this.xTabControl1.Size = new System.Drawing.Size(710, 310);
            this.xTabControl1.TabIndex = 0;
            this.xTabControl1.TabStop = false;
            this.xTabControl1.Text = "xTabControl1";
            this.xTabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabListe,
            this.tabSuchen});

            //
            // tabListe
            //
            this.tabListe.Controls.Add(this.gridList);
            this.tabListe.Location = new System.Drawing.Point(3, 3);
            this.tabListe.Name = "tabListe";
            this.tabListe.Size = new System.Drawing.Size(704, 276);
            this.tabListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabListe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tabListe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabListe.TabIndex = 0;
            this.tabListe.Title = "Liste";
            //
            // gridList
            //
            this.gridList.DataSource = this.qryKontakt;
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.EmbeddedNavigator.Name = "";
            this.gridList.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridList.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridList.Location = new System.Drawing.Point(0, 0);
            this.gridList.MainView = this.gridView1;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(704, 276);
            this.gridList.TabIndex = 0;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // qryKontakt
            //
            this.qryKontakt.CanDelete = true;
            this.qryKontakt.CanInsert = true;
            this.qryKontakt.CanUpdate = true;
            this.qryKontakt.HostControl = this;
            this.qryKontakt.TableName = "BaInstitutionKontakt";
            this.qryKontakt.BeforePost += new System.EventHandler(this.qryKontakt_BeforePost);
            this.qryKontakt.AfterInsert += new System.EventHandler(this.qryKontakt_AfterInsert);
            //
            // gridView1
            //
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRavStelle,
            this.colName,
            this.colVorname,
            this.colTel,
            this.colMail});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridList;
            this.gridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            //
            // colRavStelle
            //
            this.colRavStelle.AppearanceCell.Options.UseTextOptions = true;
            this.colRavStelle.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colRavStelle.Caption = "Institution";
            this.colRavStelle.Name = "colRavStelle";
            this.colRavStelle.Visible = true;
            this.colRavStelle.VisibleIndex = 0;
            this.colRavStelle.Width = 169;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 148;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 2;
            this.colVorname.Width = 118;
            //
            // colTel
            //
            this.colTel.Caption = "Telefon";
            this.colTel.FieldName = "Telefon";
            this.colTel.Name = "colTel";
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 3;
            this.colTel.Width = 121;
            //
            // colMail
            //
            this.colMail.Caption = "EMail";
            this.colMail.FieldName = "EMail";
            this.colMail.Name = "colMail";
            this.colMail.Visible = true;
            this.colMail.VisibleIndex = 4;
            this.colMail.Width = 124;
            //
            // tabSuchen
            //
            this.tabSuchen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabSuchen.Controls.Add(this.panel4);
            this.tabSuchen.Location = new System.Drawing.Point(3, 3);
            this.tabSuchen.Name = "tabSuchen";
            this.tabSuchen.Size = new System.Drawing.Size(704, 276);
            this.tabSuchen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabSuchen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSuchen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabSuchen.TabIndex = 0;
            this.tabSuchen.Title = "Suchen";
            this.tabSuchen.Visible = false;
            //
            // panel4
            //
            this.panel4.Controls.Add(this.editBaInstitutionIDX);
            this.panel4.Controls.Add(this.lblVornameX);
            this.panel4.Controls.Add(this.editVornameX);
            this.panel4.Controls.Add(this.lblBaInstitutionIDX);
            this.panel4.Controls.Add(this.kissSearchTitel1);
            this.panel4.Controls.Add(this.lblTelefonX);
            this.panel4.Controls.Add(this.editTelefonX);
            this.panel4.Controls.Add(this.lblEMailX);
            this.panel4.Controls.Add(this.editEMailX);
            this.panel4.Controls.Add(this.lblNameX);
            this.panel4.Controls.Add(this.editNameX);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(704, 276);
            this.panel4.TabIndex = 0;
            //
            // editBaInstitutionIDX
            //
            this.editBaInstitutionIDX.Location = new System.Drawing.Point(80, 45);
            this.editBaInstitutionIDX.Name = "editBaInstitutionIDX";
            this.editBaInstitutionIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBaInstitutionIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBaInstitutionIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBaInstitutionIDX.Properties.Appearance.Options.UseBackColor = true;
            this.editBaInstitutionIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.editBaInstitutionIDX.Properties.Appearance.Options.UseFont = true;
            this.editBaInstitutionIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editBaInstitutionIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editBaInstitutionIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBaInstitutionIDX.Size = new System.Drawing.Size(262, 24);
            this.editBaInstitutionIDX.TabIndex = 579;
            this.editBaInstitutionIDX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editBaInstitutionIDX_UserModifiedFld);
            //
            // lblVornameX
            //
            this.lblVornameX.Location = new System.Drawing.Point(5, 105);
            this.lblVornameX.Name = "lblVornameX";
            this.lblVornameX.Size = new System.Drawing.Size(55, 24);
            this.lblVornameX.TabIndex = 578;
            this.lblVornameX.Text = "Vorname";
            //
            // editVornameX
            //
            this.editVornameX.EditValue = "";
            this.editVornameX.Location = new System.Drawing.Point(80, 105);
            this.editVornameX.Name = "editVornameX";
            this.editVornameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVornameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVornameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVornameX.Properties.Appearance.Options.UseBackColor = true;
            this.editVornameX.Properties.Appearance.Options.UseBorderColor = true;
            this.editVornameX.Properties.Appearance.Options.UseFont = true;
            this.editVornameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVornameX.Size = new System.Drawing.Size(260, 24);
            this.editVornameX.TabIndex = 2;
            //
            // lblBaInstitutionIDX
            //
            this.lblBaInstitutionIDX.ForeColor = System.Drawing.Color.Black;
            this.lblBaInstitutionIDX.Location = new System.Drawing.Point(5, 45);
            this.lblBaInstitutionIDX.Name = "lblBaInstitutionIDX";
            this.lblBaInstitutionIDX.Size = new System.Drawing.Size(60, 24);
            this.lblBaInstitutionIDX.TabIndex = 576;
            this.lblBaInstitutionIDX.Text = "Institution";
            //
            // kissSearchTitel1
            //
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(9, 4);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 574;
            //
            // lblTelefonX
            //
            this.lblTelefonX.ForeColor = System.Drawing.Color.Black;
            this.lblTelefonX.Location = new System.Drawing.Point(5, 165);
            this.lblTelefonX.Name = "lblTelefonX";
            this.lblTelefonX.Size = new System.Drawing.Size(45, 24);
            this.lblTelefonX.TabIndex = 573;
            this.lblTelefonX.Text = "Telefon";
            //
            // editTelefonX
            //
            this.editTelefonX.Location = new System.Drawing.Point(80, 165);
            this.editTelefonX.Name = "editTelefonX";
            this.editTelefonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTelefonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTelefonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTelefonX.Properties.Appearance.Options.UseBackColor = true;
            this.editTelefonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTelefonX.Properties.Appearance.Options.UseFont = true;
            this.editTelefonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editTelefonX.Size = new System.Drawing.Size(260, 24);
            this.editTelefonX.TabIndex = 4;
            //
            // lblEMailX
            //
            this.lblEMailX.ForeColor = System.Drawing.Color.Black;
            this.lblEMailX.Location = new System.Drawing.Point(5, 135);
            this.lblEMailX.Name = "lblEMailX";
            this.lblEMailX.Size = new System.Drawing.Size(31, 24);
            this.lblEMailX.TabIndex = 571;
            this.lblEMailX.Text = "EMail";
            //
            // editEMailX
            //
            this.editEMailX.Location = new System.Drawing.Point(80, 135);
            this.editEMailX.Name = "editEMailX";
            this.editEMailX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editEMailX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editEMailX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editEMailX.Properties.Appearance.Options.UseBackColor = true;
            this.editEMailX.Properties.Appearance.Options.UseBorderColor = true;
            this.editEMailX.Properties.Appearance.Options.UseFont = true;
            this.editEMailX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editEMailX.Size = new System.Drawing.Size(260, 24);
            this.editEMailX.TabIndex = 3;
            //
            // lblNameX
            //
            this.lblNameX.Location = new System.Drawing.Point(5, 75);
            this.lblNameX.Name = "lblNameX";
            this.lblNameX.Size = new System.Drawing.Size(42, 24);
            this.lblNameX.TabIndex = 348;
            this.lblNameX.Text = "Name";
            //
            // editNameX
            //
            this.editNameX.EditValue = "";
            this.editNameX.Location = new System.Drawing.Point(80, 75);
            this.editNameX.Name = "editNameX";
            this.editNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editNameX.Properties.Appearance.Options.UseBackColor = true;
            this.editNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.editNameX.Properties.Appearance.Options.UseFont = true;
            this.editNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editNameX.Size = new System.Drawing.Size(260, 24);
            this.editNameX.TabIndex = 1;
            //
            // lblName
            //
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(5, 396);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 24);
            this.lblName.TabIndex = 568;
            this.lblName.Text = "Name";
            //
            // lblBaInstitutionID
            //
            this.lblBaInstitutionID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaInstitutionID.ForeColor = System.Drawing.Color.Black;
            this.lblBaInstitutionID.Location = new System.Drawing.Point(5, 336);
            this.lblBaInstitutionID.Name = "lblBaInstitutionID";
            this.lblBaInstitutionID.Size = new System.Drawing.Size(60, 24);
            this.lblBaInstitutionID.TabIndex = 567;
            this.lblBaInstitutionID.Text = "Institution";
            //
            // editBemerkungRTF
            //
            this.editBemerkungRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editBemerkungRTF.BackColor = System.Drawing.Color.White;
            this.editBemerkungRTF.DataMember = "Bemerkung";
            this.editBemerkungRTF.DataSource = this.qryKontakt;
            this.editBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.editBemerkungRTF.Location = new System.Drawing.Point(90, 456);
            this.editBemerkungRTF.Name = "editBemerkungRTF";
            this.editBemerkungRTF.Size = new System.Drawing.Size(620, 100);
            this.editBemerkungRTF.TabIndex = 8;
            //
            // lblBemerkungRFT
            //
            this.lblBemerkungRFT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungRFT.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkungRFT.Location = new System.Drawing.Point(5, 456);
            this.lblBemerkungRFT.Name = "lblBemerkungRFT";
            this.lblBemerkungRFT.Size = new System.Drawing.Size(70, 24);
            this.lblBemerkungRFT.TabIndex = 566;
            this.lblBemerkungRFT.Text = "Bemerkung";
            //
            // lblTelefon
            //
            this.lblTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTelefon.ForeColor = System.Drawing.Color.Black;
            this.lblTelefon.Location = new System.Drawing.Point(380, 336);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(45, 24);
            this.lblTelefon.TabIndex = 564;
            this.lblTelefon.Text = "Telefon";
            //
            // lblFax
            //
            this.lblFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFax.ForeColor = System.Drawing.Color.Black;
            this.lblFax.Location = new System.Drawing.Point(380, 366);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(31, 24);
            this.lblFax.TabIndex = 563;
            this.lblFax.Text = "Fax";
            //
            // lblEMail
            //
            this.lblEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEMail.ForeColor = System.Drawing.Color.Black;
            this.lblEMail.Location = new System.Drawing.Point(380, 396);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(31, 24);
            this.lblEMail.TabIndex = 562;
            this.lblEMail.Text = "EMail";
            //
            // editVorname
            //
            this.editVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editVorname.DataMember = "Vorname";
            this.editVorname.DataSource = this.qryKontakt;
            this.editVorname.Location = new System.Drawing.Point(90, 426);
            this.editVorname.Name = "editVorname";
            this.editVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVorname.Properties.Appearance.Options.UseBackColor = true;
            this.editVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.editVorname.Properties.Appearance.Options.UseFont = true;
            this.editVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVorname.Size = new System.Drawing.Size(270, 24);
            this.editVorname.TabIndex = 3;
            //
            // lblVorname
            //
            this.lblVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVorname.ForeColor = System.Drawing.Color.Black;
            this.lblVorname.Location = new System.Drawing.Point(5, 426);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(80, 24);
            this.lblVorname.TabIndex = 561;
            this.lblVorname.Text = "Vorname";
            //
            // editEMail
            //
            this.editEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editEMail.DataMember = "EMail";
            this.editEMail.DataSource = this.qryKontakt;
            this.editEMail.Location = new System.Drawing.Point(450, 396);
            this.editEMail.Name = "editEMail";
            this.editEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editEMail.Properties.Appearance.Options.UseBackColor = true;
            this.editEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.editEMail.Properties.Appearance.Options.UseFont = true;
            this.editEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editEMail.Size = new System.Drawing.Size(260, 24);
            this.editEMail.TabIndex = 6;
            //
            // lblSprache
            //
            this.lblSprache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSprache.ForeColor = System.Drawing.Color.Black;
            this.lblSprache.Location = new System.Drawing.Point(380, 426);
            this.lblSprache.Name = "lblSprache";
            this.lblSprache.Size = new System.Drawing.Size(45, 24);
            this.lblSprache.TabIndex = 565;
            this.lblSprache.Text = "Sprache";
            //
            // editSprache
            //
            this.editSprache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editSprache.DataMember = "SprachCode";
            this.editSprache.DataSource = this.qryKontakt;
            this.editSprache.Location = new System.Drawing.Point(450, 426);
            this.editSprache.LOVName = "Sprache";
            this.editSprache.Name = "editSprache";
            this.editSprache.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSprache.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSprache.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSprache.Properties.Appearance.Options.UseBackColor = true;
            this.editSprache.Properties.Appearance.Options.UseBorderColor = true;
            this.editSprache.Properties.Appearance.Options.UseFont = true;
            this.editSprache.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editSprache.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editSprache.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editSprache.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editSprache.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editSprache.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editSprache.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSprache.Properties.NullText = "";
            this.editSprache.Properties.ShowFooter = false;
            this.editSprache.Properties.ShowHeader = false;
            this.editSprache.Size = new System.Drawing.Size(150, 24);
            this.editSprache.TabIndex = 7;
            //
            // editFax
            //
            this.editFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editFax.DataMember = "Fax";
            this.editFax.DataSource = this.qryKontakt;
            this.editFax.Location = new System.Drawing.Point(450, 366);
            this.editFax.Name = "editFax";
            this.editFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editFax.Properties.Appearance.Options.UseBackColor = true;
            this.editFax.Properties.Appearance.Options.UseBorderColor = true;
            this.editFax.Properties.Appearance.Options.UseFont = true;
            this.editFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editFax.Size = new System.Drawing.Size(260, 24);
            this.editFax.TabIndex = 5;
            //
            // editTelefon
            //
            this.editTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editTelefon.DataMember = "Telefon";
            this.editTelefon.DataSource = this.qryKontakt;
            this.editTelefon.Location = new System.Drawing.Point(450, 336);
            this.editTelefon.Name = "editTelefon";
            this.editTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.editTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.editTelefon.Properties.Appearance.Options.UseFont = true;
            this.editTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editTelefon.Size = new System.Drawing.Size(260, 24);
            this.editTelefon.TabIndex = 4;
            //
            // editName
            //
            this.editName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editName.DataMember = "Name";
            this.editName.DataSource = this.qryKontakt;
            this.editName.Location = new System.Drawing.Point(90, 396);
            this.editName.Name = "editName";
            this.editName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editName.Properties.Appearance.Options.UseBackColor = true;
            this.editName.Properties.Appearance.Options.UseBorderColor = true;
            this.editName.Properties.Appearance.Options.UseFont = true;
            this.editName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editName.Size = new System.Drawing.Size(270, 24);
            this.editName.TabIndex = 2;
            //
            // editAnrede
            //
            this.editAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editAnrede.DataMember = "Anrede";
            this.editAnrede.DataSource = this.qryKontakt;
            this.editAnrede.Location = new System.Drawing.Point(90, 366);
            this.editAnrede.Name = "editAnrede";
            this.editAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.editAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.editAnrede.Properties.Appearance.Options.UseFont = true;
            this.editAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAnrede.Size = new System.Drawing.Size(100, 24);
            this.editAnrede.TabIndex = 1;
            //
            // lblAnrede
            //
            this.lblAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnrede.ForeColor = System.Drawing.Color.Black;
            this.lblAnrede.Location = new System.Drawing.Point(5, 366);
            this.lblAnrede.Name = "lblAnrede";
            this.lblAnrede.Size = new System.Drawing.Size(80, 24);
            this.lblAnrede.TabIndex = 575;
            this.lblAnrede.Text = "Anrede";
            //
            // editBaInstitutionID
            //
            this.editBaInstitutionID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editBaInstitutionID.DataSource = this.qryKontakt;
            this.editBaInstitutionID.Location = new System.Drawing.Point(90, 336);
            this.editBaInstitutionID.Name = "editBaInstitutionID";
            this.editBaInstitutionID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBaInstitutionID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBaInstitutionID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBaInstitutionID.Properties.Appearance.Options.UseBackColor = true;
            this.editBaInstitutionID.Properties.Appearance.Options.UseBorderColor = true;
            this.editBaInstitutionID.Properties.Appearance.Options.UseFont = true;
            this.editBaInstitutionID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editBaInstitutionID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editBaInstitutionID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBaInstitutionID.Size = new System.Drawing.Size(270, 24);
            this.editBaInstitutionID.TabIndex = 0;
            this.editBaInstitutionID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editBaInstitutionID_UserModifiedFld);
            //
            // FrmRavBerater
            //
            this.ActiveSQLQuery = this.qryKontakt;
            this.ClientSize = new System.Drawing.Size(722, 566);
            this.Controls.Add(this.editBaInstitutionID);
            this.Controls.Add(this.editAnrede);
            this.Controls.Add(this.lblAnrede);
            this.Controls.Add(this.editBemerkungRTF);
            this.Controls.Add(this.editName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblBaInstitutionID);
            this.Controls.Add(this.lblBemerkungRFT);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.lblEMail);
            this.Controls.Add(this.editVorname);
            this.Controls.Add(this.lblVorname);
            this.Controls.Add(this.editEMail);
            this.Controls.Add(this.lblSprache);
            this.Controls.Add(this.editSprache);
            this.Controls.Add(this.editFax);
            this.Controls.Add(this.editTelefon);
            this.Controls.Add(this.xTabControl1);
            this.Name = "FrmRavBerater";
            this.Text = "KA externe Berater";
            this.Search += new System.EventHandler(this.FrmRavBerater_Search);
            this.Load += new System.EventHandler(this.FrmRavBerater_Load);
            this.xTabControl1.ResumeLayout(false);
            this.tabListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabSuchen.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editBaInstitutionIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornameX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVornameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaInstitutionIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTelefonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMailX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEMailX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaInstitutionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungRFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBaInstitutionID.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        //public void ShowExtBerater(string Name, string Vorname)
        //{
        //    if (!qryKontakt.Post()) return;
        //    NeueSuche();
        //    this.editNameX.Text = Name;
        //    this.editVornameX.Text = Vorname;
        //    FillKontakte();
        //}
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

        #endregion

        #region EventHandlers

        private void FrmRavBerater_Load(object sender, System.EventArgs e)
        {
            SetupFieldName();
            SetupDataMember();

            if (DBUtil.IsEmpty(aName) && DBUtil.IsEmpty(aVorname))
            {
                FillKontakte();
            }
            else
            {
                //ShowExtBerater(aName, aVorname);
                NeueSuche();

                this.editNameX.Text = aName;
                this.editVornameX.Text = aVorname;

                FillKontakte();
            }
        }

        private void FrmRavBerater_Search(object sender, System.EventArgs e)
        {
            if (xTabControl1.SelectedTabIndex == 1)
                FillKontakte();
            else
            {
                if (qryKontakt.Post())
                {
                    this.xTabControl1.SelectedTabIndex = 1;
                    NeueSuche();
                }
            }
        }

        private void editBaInstitutionIDX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.InstitutionSuchen(editBaInstitutionIDX.Text, e.ButtonClicked))
            {
                editBaInstitutionIDX.EditValue = dlg[DBO.BaInstitution.Name];
                editBaInstitutionIDX.LookupID = dlg[DBO.BaInstitution.BaInstitutionID];
            }
            else
                e.Cancel = true;
        }

        private void editBaInstitutionID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.InstitutionSuchen(editBaInstitutionID.Text, e.ButtonClicked))
            {
                qryKontakt[QRY_KONTAKT_INSTITUTION_NAME] = dlg[DBO.BaInstitution.Name];
                qryKontakt[DBO.BaInstitutionKontakt.BaInstitutionID] = dlg[DBO.BaInstitution.BaInstitutionID];
            }
            else
                e.Cancel = true;
        }

        private void qryKontakt_AfterInsert(object sender, System.EventArgs e)
        {
            qryKontakt[DBO.BaInstitutionKontakt.Creator] = DBUtil.GetDBRowCreatorModifier();

            editBaInstitutionID.Focus();
        }

        private void qryKontakt_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(editBaInstitutionID, lblBaInstitutionID.Text);
            DBUtil.CheckNotNullField(editName, lblName.Text);
            DBUtil.CheckNotNullField(editVorname, lblVorname.Text);

            qryKontakt[DBO.BaInstitutionKontakt.Modifier] = DBUtil.GetDBRowCreatorModifier();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAINSTITUTIONID":
                    if (qryKontakt.Count > 0)
                        return qryKontakt[DBO.BaInstitutionKontakt.BaInstitutionID];
                    break;
            }

            return base.GetContextValue(FieldName);
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "ShowExterneBerater":
                    if (!param.Contains("ZuweiserName")) param["ZuweiserName"] = "";
                    if (!param.Contains("ZuweiserVorname")) param["ZuweiserVorname"] = "";

                    NeueSuche();

                    this.editNameX.Text = param["ZuweiserName"].ToString();
                    this.editVornameX.Text = param["ZuweiserVorname"].ToString();

                    FillKontakte();

                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Private Methods

        private void FillKontakte()
        {
            Cursor.Current = Cursors.WaitCursor;

            string sql = @"
                SELECT OKO.[BaInstitutionKontaktID],
                       OKO.[BaInstitutionID],
                       OKO.[Aktiv],
                       OKO.[ManuelleAnrede],
                       OKO.[Anrede],
                       OKO.[Briefanrede],
                       OKO.[Titel],
                       OKO.[Name],
                       OKO.[Vorname],
                       OKO.[GeschlechtCode],
                       OKO.[Telefon],
                       OKO.[Fax],
                       OKO.[EMail],
                       OKO.[SprachCode],
                       OKO.[Bemerkung],
                       OKO.[Creator],
                       OKO.[Created],
                       OKO.[Modifier],
                       OKO.[Modified],
                       OKO.[BaInstitutionKontaktTS],
                       Institution = ORG.Name
                FROM dbo.BaInstitutionKontakt OKO
                  INNER JOIN dbo.BaInstitution ORG on ORG.BaInstitutionID = OKO.BaInstitutionID
                WHERE 1 = 1 ";

            // ID
            if (!DBUtil.IsEmpty(editBaInstitutionIDX.EditValue))
            {
                sql += " AND OKO.BaInstitutionID = " + editBaInstitutionIDX.LookupID;
            }

            // Name
            if (editNameX.Text != "")
            {
                sql += " AND OKO.Name LIKE " + DBUtil.SqlLiteralLike("%" + editNameX.Text + "%");
            }

            // Vorname
            if (editVornameX.Text != "")
            {
                sql += " AND OKO.Vorname LIKE " + DBUtil.SqlLiteralLike(editVornameX.Text + "%");
            }

            // EMail
            if (editEMailX.Text != "")
            {
                sql += " AND OKO.EMail LIKE " + DBUtil.SqlLiteralLike(editEMailX.Text + "%");
            }

            // Telefon
            if (editTelefonX.Text != "")
            {
                sql += " AND OKO.Telefon LIKE " + DBUtil.SqlLiteralLike(editTelefonX.Text + "%");
            }

            sql += " ORDER BY ORG.Name, OKO.Name";

            qryKontakt.Fill(sql);

            xTabControl1.SelectedTabIndex = 0;
            gridList.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void NeueSuche()
        {
            foreach (Control ctl in UtilsGui.AllControls(xTabControl1))
                if (ctl is BaseEdit)
                    ((BaseEdit)ctl).EditValue = null;

            editBaInstitutionIDX.Focus();
        }

        private void SetupDataMember()
        {
            editBaInstitutionID.DataMember = QRY_KONTAKT_INSTITUTION_NAME;
        }

        private void SetupFieldName()
        {
            colRavStelle.FieldName = QRY_KONTAKT_INSTITUTION_NAME;
        }

        #endregion

        #endregion
    }
}