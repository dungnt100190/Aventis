using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmMandant.
    /// </summary>
    public class CtlVmMandant : KissUserControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAdressZusatz;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissTextEdit edtBeruf;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
        private KiSS4.Gui.KissTextEdit edtHausNr;
        private KiSS4.Gui.KissButtonEdit edtHeimatort;
        private KiSS4.Gui.KissTextEdit edtKanton;
        private KiSS4.Gui.KissLookUpEdit edtLandCode;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtPostfach;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KissVersichertenNrEdit edtVersNr;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissTextEdit edtWertschriftenDepot;
        private KiSS4.Gui.KissLookUpEdit edtZivilstandCode;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissGrid grdVmMandant;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmMandant;
        private KiSS4.Gui.KissButtonEdit kissButtonEdit1;
        private KiSS4.Gui.KissDateEdit kissDateEdit1;
        private KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit1;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit2;
        private KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit10;
        private KiSS4.Gui.KissTextEdit kissTextEdit11;
        private KiSS4.Gui.KissTextEdit kissTextEdit12;
        private KiSS4.Gui.KissTextEdit kissTextEdit17;
        private KiSS4.Gui.KissTextEdit kissTextEdit18;
        private KiSS4.Gui.KissTextEdit kissTextEdit19;
        private KiSS4.Gui.KissTextEdit kissTextEdit20;
        private KiSS4.Gui.KissTextEdit kissTextEdit6;
        private KiSS4.Gui.KissTextEdit kissTextEdit7;
        private KiSS4.Gui.KissTextEdit kissTextEdit8;
        private KiSS4.Gui.KissTextEdit kissTextEdit9;
        private int LastVersion = 0;
        private KiSS4.Gui.KissLabel lblAdressZusatz;
        private KiSS4.Gui.KissLabel lblAHVNummer;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBeruf;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblLandCode;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPLZ;
        private KiSS4.Gui.KissLabel lblPostfach;
        private KiSS4.Gui.KissLabel lblStrasse;
        private System.Windows.Forms.Label lblTitel;
        private KissLabel lblVersNr;
        private KiSS4.Gui.KissLabel lblWertschriftenDepot;
        private KiSS4.Gui.KissLabel lblZivilstandCode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBasis;
        private KiSS4.DB.SqlQuery qryVmMandant;
        private SharpLibrary.WinControls.TabPageEx tabBasis;
        private SharpLibrary.WinControls.TabPageEx tabBS;
        private KiSS4.Gui.KissTabControlEx xTabControl1;

        #endregion

        #endregion

        #region Constructors

        public CtlVmMandant()
        {
            // This call is required by the Windows.Forms Form Designer.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmMandant));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.qryVmMandant = new KiSS4.DB.SqlQuery(this.components);
            this.grdVmMandant = new KiSS4.Gui.KissGrid();
            this.grvVmMandant = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xTabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tabBS = new SharpLibrary.WinControls.TabPageEx();
            this.edtHeimatort = new KiSS4.Gui.KissButtonEdit();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtWertschriftenDepot = new KiSS4.Gui.KissTextEdit();
            this.lblWertschriftenDepot = new KiSS4.Gui.KissLabel();
            this.edtBeruf = new KiSS4.Gui.KissTextEdit();
            this.lblBeruf = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtZivilstandCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblZivilstandCode = new KiSS4.Gui.KissLabel();
            this.lblAHVNummer = new KiSS4.Gui.KissLabel();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtLandCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtKanton = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtAdressZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblAdressZusatz = new KiSS4.Gui.KissLabel();
            this.lblPostfach = new KiSS4.Gui.KissLabel();
            this.lblPLZ = new KiSS4.Gui.KissLabel();
            this.lblLandCode = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.tabBasis = new SharpLibrary.WinControls.TabPageEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kissButtonEdit1 = new KiSS4.Gui.KissButtonEdit();
            this.qryBasis = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit6 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissDateEdit1 = new KiSS4.Gui.KissDateEdit();
            this.kissTextEdit7 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLookUpEdit1 = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit8 = new KiSS4.Gui.KissTextEdit();
            this.kissLookUpEdit2 = new KiSS4.Gui.KissLookUpEdit();
            this.kissTextEdit9 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit10 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit11 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit12 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit17 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit18 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit19 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit20 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.edtVersNr = new KiSS4.Gui.KissVersichertenNrEdit();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmMandant)).BeginInit();
            this.xTabControl1.SuspendLayout();
            this.tabBS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWertschriftenDepot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWertschriftenDepot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeruf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeruf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            this.tabBasis.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBasis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit12.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit17.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit18.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit19.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit20.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            //
            // qryVmMandant
            //
            this.qryVmMandant.CanUpdate = true;
            this.qryVmMandant.HostControl = this;
            this.qryVmMandant.TableName = "VmMandant";
            this.qryVmMandant.BeforePost += new System.EventHandler(this.qryVmMandant_BeforePost);
            this.qryVmMandant.PositionChanged += new System.EventHandler(this.qryVmMandant_PositionChanged);
            //
            // grdVmMandant
            //
            this.grdVmMandant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVmMandant.DataSource = this.qryVmMandant;
            this.grdVmMandant.EmbeddedNavigator.Name = "";
            this.grdVmMandant.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmMandant.Location = new System.Drawing.Point(5, 40);
            this.grdVmMandant.MainView = this.grvVmMandant;
            this.grdVmMandant.Name = "grdVmMandant";
            this.grdVmMandant.Size = new System.Drawing.Size(690, 149);
            this.grdVmMandant.TabIndex = 0;
            this.grdVmMandant.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmMandant});
            //
            // grvVmMandant
            //
            this.grvVmMandant.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmMandant.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.Empty.Options.UseFont = true;
            this.grvVmMandant.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmMandant.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmMandant.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmMandant.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmMandant.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmMandant.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmMandant.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmMandant.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmMandant.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmMandant.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmMandant.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmMandant.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmMandant.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmMandant.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmMandant.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmMandant.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmMandant.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmMandant.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmMandant.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmMandant.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmMandant.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmMandant.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmMandant.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmMandant.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmMandant.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmMandant.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.OddRow.Options.UseFont = true;
            this.grvVmMandant.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmMandant.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.Row.Options.UseBackColor = true;
            this.grvVmMandant.Appearance.Row.Options.UseFont = true;
            this.grvVmMandant.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMandant.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmMandant.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmMandant.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmMandant.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmMandant.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVersion,
            this.colDatum,
            this.colName,
            this.colVorname,
            this.colStrasse,
            this.colNummer,
            this.colPLZ,
            this.colOrt,
            this.colUserID});
            this.grvVmMandant.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmMandant.GridControl = this.grdVmMandant;
            this.grvVmMandant.Name = "grvVmMandant";
            this.grvVmMandant.OptionsBehavior.Editable = false;
            this.grvVmMandant.OptionsCustomization.AllowFilter = false;
            this.grvVmMandant.OptionsFilter.AllowFilterEditor = false;
            this.grvVmMandant.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmMandant.OptionsMenu.EnableColumnMenu = false;
            this.grvVmMandant.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmMandant.OptionsNavigation.UseTabKey = false;
            this.grvVmMandant.OptionsView.ColumnAutoWidth = false;
            this.grvVmMandant.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmMandant.OptionsView.ShowGroupPanel = false;
            this.grvVmMandant.OptionsView.ShowIndicator = false;
            //
            // colVersion
            //
            this.colVersion.Caption = "Vers.";
            this.colVersion.FieldName = "Version";
            this.colVersion.Name = "colVersion";
            this.colVersion.Visible = true;
            this.colVersion.VisibleIndex = 0;
            this.colVersion.Width = 44;
            //
            // colDatum
            //
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 1;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 105;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            //
            // colStrasse
            //
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 4;
            //
            // colNummer
            //
            this.colNummer.Caption = "Nr.";
            this.colNummer.FieldName = "HausNr";
            this.colNummer.Name = "colNummer";
            this.colNummer.Visible = true;
            this.colNummer.VisibleIndex = 5;
            this.colNummer.Width = 37;
            //
            // colPLZ
            //
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 6;
            this.colPLZ.Width = 47;
            //
            // colOrt
            //
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 7;
            this.colOrt.Width = 111;
            //
            // colUserID
            //
            this.colUserID.Caption = "BenutzerIn";
            this.colUserID.FieldName = "SAR";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 8;
            this.colUserID.Width = 96;
            //
            // xTabControl1
            //
            this.xTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xTabControl1.Controls.Add(this.tabBS);
            this.xTabControl1.Controls.Add(this.tabBasis);
            this.xTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xTabControl1.Location = new System.Drawing.Point(5, 188);
            this.xTabControl1.Name = "xTabControl1";
            this.xTabControl1.ShowFixedWidthTooltip = true;
            this.xTabControl1.Size = new System.Drawing.Size(690, 318);
            this.xTabControl1.TabIndex = 605;
            this.xTabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabBS,
            this.tabBasis});
            this.xTabControl1.TabsLineColor = System.Drawing.Color.Black;
            this.xTabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.xTabControl1.TabStop = false;
            this.xTabControl1.Text = "xTabControl1";
            //
            // tabBS
            //
            this.tabBS.Controls.Add(this.edtVersNr);
            this.tabBS.Controls.Add(this.lblVersNr);
            this.tabBS.Controls.Add(this.edtHeimatort);
            this.tabBS.Controls.Add(this.lblHeimatort);
            this.tabBS.Controls.Add(this.edtBemerkung);
            this.tabBS.Controls.Add(this.lblBemerkung);
            this.tabBS.Controls.Add(this.edtWertschriftenDepot);
            this.tabBS.Controls.Add(this.lblWertschriftenDepot);
            this.tabBS.Controls.Add(this.edtBeruf);
            this.tabBS.Controls.Add(this.lblBeruf);
            this.tabBS.Controls.Add(this.edtGeburtsdatum);
            this.tabBS.Controls.Add(this.edtAHVNummer);
            this.tabBS.Controls.Add(this.lblGeburtsdatum);
            this.tabBS.Controls.Add(this.edtZivilstandCode);
            this.tabBS.Controls.Add(this.lblZivilstandCode);
            this.tabBS.Controls.Add(this.lblAHVNummer);
            this.tabBS.Controls.Add(this.edtOrt);
            this.tabBS.Controls.Add(this.edtLandCode);
            this.tabBS.Controls.Add(this.edtKanton);
            this.tabBS.Controls.Add(this.edtPLZ);
            this.tabBS.Controls.Add(this.edtPostfach);
            this.tabBS.Controls.Add(this.edtHausNr);
            this.tabBS.Controls.Add(this.edtAdressZusatz);
            this.tabBS.Controls.Add(this.edtStrasse);
            this.tabBS.Controls.Add(this.lblAdressZusatz);
            this.tabBS.Controls.Add(this.lblPostfach);
            this.tabBS.Controls.Add(this.lblPLZ);
            this.tabBS.Controls.Add(this.lblLandCode);
            this.tabBS.Controls.Add(this.lblStrasse);
            this.tabBS.Controls.Add(this.edtVorname);
            this.tabBS.Controls.Add(this.edtName);
            this.tabBS.Controls.Add(this.lblName);
            this.tabBS.Location = new System.Drawing.Point(6, 6);
            this.tabBS.Name = "tabBS";
            this.tabBS.Size = new System.Drawing.Size(678, 280);
            this.tabBS.TabIndex = 0;
            this.tabBS.Title = "Version BS";
            //
            // edtHeimatort
            //
            this.edtHeimatort.DataMember = "Heimatort";
            this.edtHeimatort.DataSource = this.qryVmMandant;
            this.edtHeimatort.Location = new System.Drawing.Point(450, 103);
            this.edtHeimatort.Name = "edtHeimatort";
            this.edtHeimatort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeimatort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatort.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtHeimatort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtHeimatort.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHeimatort.Size = new System.Drawing.Size(174, 24);
            this.edtHeimatort.TabIndex = 13;
            this.edtHeimatort.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editBSHeimatort_UserModifiedFld);
            //
            // lblHeimatort
            //
            this.lblHeimatort.ForeColor = System.Drawing.Color.Black;
            this.lblHeimatort.Location = new System.Drawing.Point(379, 103);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(55, 24);
            this.lblHeimatort.TabIndex = 632;
            this.lblHeimatort.Text = "Heimatort";
            //
            // edtBemerkung
            //
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmMandant;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBemerkung.Location = new System.Drawing.Point(90, 225);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(536, 46);
            this.edtBemerkung.TabIndex = 17;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(5, 225);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(66, 24);
            this.lblBemerkung.TabIndex = 630;
            this.lblBemerkung.Text = "Bemerkung";
            //
            // edtWertschriftenDepot
            //
            this.edtWertschriftenDepot.DataMember = "WertschriftenDepot";
            this.edtWertschriftenDepot.DataSource = this.qryVmMandant;
            this.edtWertschriftenDepot.Location = new System.Drawing.Point(450, 193);
            this.edtWertschriftenDepot.Name = "edtWertschriftenDepot";
            this.edtWertschriftenDepot.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWertschriftenDepot.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWertschriftenDepot.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWertschriftenDepot.Properties.Appearance.Options.UseBackColor = true;
            this.edtWertschriftenDepot.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWertschriftenDepot.Properties.Appearance.Options.UseFont = true;
            this.edtWertschriftenDepot.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWertschriftenDepot.Size = new System.Drawing.Size(174, 24);
            this.edtWertschriftenDepot.TabIndex = 16;
            //
            // lblWertschriftenDepot
            //
            this.lblWertschriftenDepot.ForeColor = System.Drawing.Color.Black;
            this.lblWertschriftenDepot.Location = new System.Drawing.Point(379, 193);
            this.lblWertschriftenDepot.Name = "lblWertschriftenDepot";
            this.lblWertschriftenDepot.Size = new System.Drawing.Size(68, 24);
            this.lblWertschriftenDepot.TabIndex = 629;
            this.lblWertschriftenDepot.Text = "WS-Depot";
            //
            // edtBeruf
            //
            this.edtBeruf.DataMember = "Beruf";
            this.edtBeruf.DataSource = this.qryVmMandant;
            this.edtBeruf.Location = new System.Drawing.Point(450, 163);
            this.edtBeruf.Name = "edtBeruf";
            this.edtBeruf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeruf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeruf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeruf.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeruf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeruf.Properties.Appearance.Options.UseFont = true;
            this.edtBeruf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeruf.Size = new System.Drawing.Size(174, 24);
            this.edtBeruf.TabIndex = 15;
            //
            // lblBeruf
            //
            this.lblBeruf.ForeColor = System.Drawing.Color.Black;
            this.lblBeruf.Location = new System.Drawing.Point(379, 163);
            this.lblBeruf.Name = "lblBeruf";
            this.lblBeruf.Size = new System.Drawing.Size(68, 24);
            this.lblBeruf.TabIndex = 627;
            this.lblBeruf.Text = "Beruf";
            //
            // edtGeburtsdatum
            //
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryVmMandant;
            this.edtGeburtsdatum.EditValue = null;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(450, 10);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtsdatum.TabIndex = 10;
            //
            // edtAHVNummer
            //
            this.edtAHVNummer.DataMember = "AHVNummer";
            this.edtAHVNummer.DataSource = this.qryVmMandant;
            this.edtAHVNummer.Location = new System.Drawing.Point(450, 40);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Size = new System.Drawing.Size(115, 24);
            this.edtAHVNummer.TabIndex = 11;
            //
            // lblGeburtsdatum
            //
            this.lblGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.lblGeburtsdatum.Location = new System.Drawing.Point(379, 10);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(68, 24);
            this.lblGeburtsdatum.TabIndex = 625;
            this.lblGeburtsdatum.Text = "Geburt";
            //
            // edtZivilstandCode
            //
            this.edtZivilstandCode.DataMember = "ZivilstandCode";
            this.edtZivilstandCode.DataSource = this.qryVmMandant;
            this.edtZivilstandCode.Location = new System.Drawing.Point(450, 133);
            this.edtZivilstandCode.LOVName = "Zivilstand";
            this.edtZivilstandCode.Name = "edtZivilstandCode";
            this.edtZivilstandCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZivilstandCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZivilstandCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZivilstandCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZivilstandCode.Properties.NullText = "";
            this.edtZivilstandCode.Properties.ShowFooter = false;
            this.edtZivilstandCode.Properties.ShowHeader = false;
            this.edtZivilstandCode.Size = new System.Drawing.Size(174, 24);
            this.edtZivilstandCode.TabIndex = 14;
            //
            // lblZivilstandCode
            //
            this.lblZivilstandCode.ForeColor = System.Drawing.Color.Black;
            this.lblZivilstandCode.Location = new System.Drawing.Point(379, 133);
            this.lblZivilstandCode.Name = "lblZivilstandCode";
            this.lblZivilstandCode.Size = new System.Drawing.Size(68, 24);
            this.lblZivilstandCode.TabIndex = 624;
            this.lblZivilstandCode.Text = "Zivilstand";
            //
            // lblAHVNummer
            //
            this.lblAHVNummer.ForeColor = System.Drawing.Color.Black;
            this.lblAHVNummer.Location = new System.Drawing.Point(379, 40);
            this.lblAHVNummer.Name = "lblAHVNummer";
            this.lblAHVNummer.Size = new System.Drawing.Size(45, 24);
            this.lblAHVNummer.TabIndex = 623;
            this.lblAHVNummer.Text = "AVH-Nr";
            //
            // edtOrt
            //
            this.edtOrt.DataMember = "Ort";
            this.edtOrt.DataSource = this.qryVmMandant;
            this.edtOrt.Location = new System.Drawing.Point(139, 109);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(191, 24);
            this.edtOrt.TabIndex = 7;
            //
            // edtLandCode
            //
            this.edtLandCode.DataMember = "BaLandID";
            this.edtLandCode.DataSource = this.qryVmMandant;
            this.edtLandCode.Location = new System.Drawing.Point(90, 132);
            this.edtLandCode.LOVName = "BaLand";
            this.edtLandCode.Name = "edtLandCode";
            this.edtLandCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLandCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLandCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLandCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtLandCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLandCode.Properties.Appearance.Options.UseFont = true;
            this.edtLandCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLandCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLandCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLandCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLandCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtLandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtLandCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLandCode.Properties.NullText = "";
            this.edtLandCode.Properties.ShowFooter = false;
            this.edtLandCode.Properties.ShowHeader = false;
            this.edtLandCode.Size = new System.Drawing.Size(270, 24);
            this.edtLandCode.TabIndex = 9;
            //
            // edtKanton
            //
            this.edtKanton.DataMember = "Kanton";
            this.edtKanton.DataSource = this.qryVmMandant;
            this.edtKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKanton.Location = new System.Drawing.Point(329, 109);
            this.edtKanton.Name = "edtKanton";
            this.edtKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKanton.Properties.Appearance.Options.UseFont = true;
            this.edtKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKanton.Properties.ReadOnly = true;
            this.edtKanton.Size = new System.Drawing.Size(31, 24);
            this.edtKanton.TabIndex = 8;
            //
            // edtPLZ
            //
            this.edtPLZ.DataMember = "PLZ";
            this.edtPLZ.DataSource = this.qryVmMandant;
            this.edtPLZ.Location = new System.Drawing.Point(90, 109);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Size = new System.Drawing.Size(50, 24);
            this.edtPLZ.TabIndex = 6;
            //
            // edtPostfach
            //
            this.edtPostfach.DataMember = "Postfach";
            this.edtPostfach.DataSource = this.qryVmMandant;
            this.edtPostfach.Location = new System.Drawing.Point(90, 86);
            this.edtPostfach.Name = "edtPostfach";
            this.edtPostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfach.Size = new System.Drawing.Size(270, 24);
            this.edtPostfach.TabIndex = 5;
            //
            // edtHausNr
            //
            this.edtHausNr.DataMember = "HausNr";
            this.edtHausNr.DataSource = this.qryVmMandant;
            this.edtHausNr.Location = new System.Drawing.Point(311, 63);
            this.edtHausNr.Name = "edtHausNr";
            this.edtHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtHausNr.TabIndex = 4;
            //
            // edtAdressZusatz
            //
            this.edtAdressZusatz.DataMember = "Zusatz";
            this.edtAdressZusatz.DataSource = this.qryVmMandant;
            this.edtAdressZusatz.Location = new System.Drawing.Point(90, 40);
            this.edtAdressZusatz.Name = "edtAdressZusatz";
            this.edtAdressZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdressZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressZusatz.Size = new System.Drawing.Size(270, 24);
            this.edtAdressZusatz.TabIndex = 2;
            //
            // edtStrasse
            //
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryVmMandant;
            this.edtStrasse.Location = new System.Drawing.Point(90, 63);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(222, 24);
            this.edtStrasse.TabIndex = 3;
            //
            // lblAdressZusatz
            //
            this.lblAdressZusatz.ForeColor = System.Drawing.Color.Black;
            this.lblAdressZusatz.Location = new System.Drawing.Point(5, 40);
            this.lblAdressZusatz.Name = "lblAdressZusatz";
            this.lblAdressZusatz.Size = new System.Drawing.Size(68, 24);
            this.lblAdressZusatz.TabIndex = 619;
            this.lblAdressZusatz.Text = "Zusatz";
            //
            // lblPostfach
            //
            this.lblPostfach.ForeColor = System.Drawing.Color.Black;
            this.lblPostfach.Location = new System.Drawing.Point(5, 86);
            this.lblPostfach.Name = "lblPostfach";
            this.lblPostfach.Size = new System.Drawing.Size(68, 24);
            this.lblPostfach.TabIndex = 618;
            this.lblPostfach.Text = "Postfach";
            //
            // lblPLZ
            //
            this.lblPLZ.ForeColor = System.Drawing.Color.Black;
            this.lblPLZ.Location = new System.Drawing.Point(5, 109);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(68, 24);
            this.lblPLZ.TabIndex = 617;
            this.lblPLZ.Text = "PLZ/Ort/Kt";
            //
            // lblLandCode
            //
            this.lblLandCode.ForeColor = System.Drawing.Color.Black;
            this.lblLandCode.Location = new System.Drawing.Point(5, 132);
            this.lblLandCode.Name = "lblLandCode";
            this.lblLandCode.Size = new System.Drawing.Size(68, 24);
            this.lblLandCode.TabIndex = 616;
            this.lblLandCode.Text = "Land";
            //
            // lblStrasse
            //
            this.lblStrasse.ForeColor = System.Drawing.Color.Black;
            this.lblStrasse.Location = new System.Drawing.Point(5, 63);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(68, 24);
            this.lblStrasse.TabIndex = 615;
            this.lblStrasse.Text = "Strasse/Nr";
            //
            // edtVorname
            //
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryVmMandant;
            this.edtVorname.Location = new System.Drawing.Point(251, 10);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(109, 24);
            this.edtVorname.TabIndex = 1;
            //
            // edtName
            //
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryVmMandant;
            this.edtName.Location = new System.Drawing.Point(90, 10);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(162, 24);
            this.edtName.TabIndex = 0;
            //
            // lblName
            //
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(5, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 24);
            this.lblName.TabIndex = 614;
            this.lblName.Text = "Name/Vorname";
            //
            // tabBasis
            //
            this.tabBasis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabBasis.Controls.Add(this.panel4);
            this.tabBasis.Location = new System.Drawing.Point(6, 6);
            this.tabBasis.Name = "tabBasis";
            this.tabBasis.Size = new System.Drawing.Size(678, 280);
            this.tabBasis.TabIndex = 0;
            this.tabBasis.Title = "Version Basis";
            this.tabBasis.Visible = false;
            //
            // panel4
            //
            this.panel4.Controls.Add(this.kissTextEdit1);
            this.panel4.Controls.Add(this.kissLabel1);
            this.panel4.Controls.Add(this.kissButtonEdit1);
            this.panel4.Controls.Add(this.kissLabel5);
            this.panel4.Controls.Add(this.kissTextEdit6);
            this.panel4.Controls.Add(this.kissLabel6);
            this.panel4.Controls.Add(this.kissDateEdit1);
            this.panel4.Controls.Add(this.kissTextEdit7);
            this.panel4.Controls.Add(this.kissLabel7);
            this.panel4.Controls.Add(this.kissLookUpEdit1);
            this.panel4.Controls.Add(this.kissLabel8);
            this.panel4.Controls.Add(this.kissLabel9);
            this.panel4.Controls.Add(this.kissTextEdit8);
            this.panel4.Controls.Add(this.kissLookUpEdit2);
            this.panel4.Controls.Add(this.kissTextEdit9);
            this.panel4.Controls.Add(this.kissTextEdit10);
            this.panel4.Controls.Add(this.kissTextEdit11);
            this.panel4.Controls.Add(this.kissTextEdit12);
            this.panel4.Controls.Add(this.kissTextEdit17);
            this.panel4.Controls.Add(this.kissTextEdit18);
            this.panel4.Controls.Add(this.kissLabel10);
            this.panel4.Controls.Add(this.kissLabel11);
            this.panel4.Controls.Add(this.kissLabel12);
            this.panel4.Controls.Add(this.kissLabel13);
            this.panel4.Controls.Add(this.kissLabel14);
            this.panel4.Controls.Add(this.kissTextEdit19);
            this.panel4.Controls.Add(this.kissTextEdit20);
            this.panel4.Controls.Add(this.kissLabel15);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(678, 280);
            this.panel4.TabIndex = 0;
            //
            // kissButtonEdit1
            //
            this.kissButtonEdit1.DataMember = "Heimatort";
            this.kissButtonEdit1.DataSource = this.qryBasis;
            this.kissButtonEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissButtonEdit1.Location = new System.Drawing.Point(450, 103);
            this.kissButtonEdit1.Name = "kissButtonEdit1";
            this.kissButtonEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissButtonEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissButtonEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissButtonEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissButtonEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.kissButtonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.kissButtonEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissButtonEdit1.Properties.ReadOnly = true;
            this.kissButtonEdit1.Size = new System.Drawing.Size(174, 24);
            this.kissButtonEdit1.TabIndex = 649;
            //
            // qryBasis
            //
            this.qryBasis.HostControl = this;
            //
            // kissLabel5
            //
            this.kissLabel5.ForeColor = System.Drawing.Color.Black;
            this.kissLabel5.Location = new System.Drawing.Point(379, 103);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(55, 24);
            this.kissLabel5.TabIndex = 657;
            this.kissLabel5.Text = "Heimatort";
            //
            // kissTextEdit6
            //
            this.kissTextEdit6.DataMember = "Beruf";
            this.kissTextEdit6.DataSource = this.qryBasis;
            this.kissTextEdit6.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit6.Location = new System.Drawing.Point(450, 163);
            this.kissTextEdit6.Name = "kissTextEdit6";
            this.kissTextEdit6.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit6.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit6.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit6.Properties.ReadOnly = true;
            this.kissTextEdit6.Size = new System.Drawing.Size(174, 24);
            this.kissTextEdit6.TabIndex = 654;
            //
            // kissLabel6
            //
            this.kissLabel6.ForeColor = System.Drawing.Color.Black;
            this.kissLabel6.Location = new System.Drawing.Point(379, 163);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(68, 24);
            this.kissLabel6.TabIndex = 655;
            this.kissLabel6.Text = "Beruf";
            //
            // kissDateEdit1
            //
            this.kissDateEdit1.DataMember = "Geburtsdatum";
            this.kissDateEdit1.DataSource = this.qryBasis;
            this.kissDateEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit1.EditValue = null;
            this.kissDateEdit1.Location = new System.Drawing.Point(450, 10);
            this.kissDateEdit1.Name = "kissDateEdit1";
            this.kissDateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.kissDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit1.Properties.ReadOnly = true;
            this.kissDateEdit1.Properties.ShowToday = false;
            this.kissDateEdit1.Size = new System.Drawing.Size(95, 24);
            this.kissDateEdit1.TabIndex = 649;
            //
            // kissTextEdit7
            //
            this.kissTextEdit7.DataMember = "AHVNummer";
            this.kissTextEdit7.DataSource = this.qryBasis;
            this.kissTextEdit7.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit7.Location = new System.Drawing.Point(450, 40);
            this.kissTextEdit7.Name = "kissTextEdit7";
            this.kissTextEdit7.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit7.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit7.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit7.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit7.Properties.ReadOnly = true;
            this.kissTextEdit7.Size = new System.Drawing.Size(115, 24);
            this.kissTextEdit7.TabIndex = 648;
            //
            // kissLabel7
            //
            this.kissLabel7.ForeColor = System.Drawing.Color.Black;
            this.kissLabel7.Location = new System.Drawing.Point(379, 10);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(68, 24);
            this.kissLabel7.TabIndex = 653;
            this.kissLabel7.Text = "Geburt";
            //
            // kissLookUpEdit1
            //
            this.kissLookUpEdit1.DataMember = "ZivilstandCode";
            this.kissLookUpEdit1.DataSource = this.qryBasis;
            this.kissLookUpEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissLookUpEdit1.Location = new System.Drawing.Point(450, 133);
            this.kissLookUpEdit1.LOVName = "Zivilstand";
            this.kissLookUpEdit1.Name = "kissLookUpEdit1";
            this.kissLookUpEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissLookUpEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.kissLookUpEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit1.Properties.NullText = "";
            this.kissLookUpEdit1.Properties.ReadOnly = true;
            this.kissLookUpEdit1.Properties.ShowFooter = false;
            this.kissLookUpEdit1.Properties.ShowHeader = false;
            this.kissLookUpEdit1.Size = new System.Drawing.Size(174, 24);
            this.kissLookUpEdit1.TabIndex = 650;
            //
            // kissLabel8
            //
            this.kissLabel8.ForeColor = System.Drawing.Color.Black;
            this.kissLabel8.Location = new System.Drawing.Point(379, 133);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(68, 24);
            this.kissLabel8.TabIndex = 652;
            this.kissLabel8.Text = "Zivilstand";
            //
            // kissLabel9
            //
            this.kissLabel9.ForeColor = System.Drawing.Color.Black;
            this.kissLabel9.Location = new System.Drawing.Point(379, 40);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(45, 24);
            this.kissLabel9.TabIndex = 651;
            this.kissLabel9.Text = "AVH-Nr";
            //
            // kissTextEdit8
            //
            this.kissTextEdit8.DataMember = "Ort";
            this.kissTextEdit8.DataSource = this.qryBasis;
            this.kissTextEdit8.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit8.Location = new System.Drawing.Point(139, 109);
            this.kissTextEdit8.Name = "kissTextEdit8";
            this.kissTextEdit8.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit8.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit8.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit8.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit8.Properties.ReadOnly = true;
            this.kissTextEdit8.Size = new System.Drawing.Size(191, 24);
            this.kissTextEdit8.TabIndex = 639;
            //
            // kissLookUpEdit2
            //
            this.kissLookUpEdit2.DataMember = "BaLandID";
            this.kissLookUpEdit2.DataSource = this.qryBasis;
            this.kissLookUpEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissLookUpEdit2.Location = new System.Drawing.Point(90, 132);
            this.kissLookUpEdit2.LOVName = "BaLand";
            this.kissLookUpEdit2.Name = "kissLookUpEdit2";
            this.kissLookUpEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissLookUpEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.kissLookUpEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit2.Properties.NullText = "";
            this.kissLookUpEdit2.Properties.ReadOnly = true;
            this.kissLookUpEdit2.Properties.ShowFooter = false;
            this.kissLookUpEdit2.Properties.ShowHeader = false;
            this.kissLookUpEdit2.Size = new System.Drawing.Size(270, 24);
            this.kissLookUpEdit2.TabIndex = 641;
            //
            // kissTextEdit9
            //
            this.kissTextEdit9.DataMember = "Kanton";
            this.kissTextEdit9.DataSource = this.qryBasis;
            this.kissTextEdit9.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit9.Location = new System.Drawing.Point(329, 109);
            this.kissTextEdit9.Name = "kissTextEdit9";
            this.kissTextEdit9.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit9.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit9.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit9.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit9.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit9.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit9.Properties.ReadOnly = true;
            this.kissTextEdit9.Size = new System.Drawing.Size(31, 24);
            this.kissTextEdit9.TabIndex = 640;
            //
            // kissTextEdit10
            //
            this.kissTextEdit10.DataMember = "PLZ";
            this.kissTextEdit10.DataSource = this.qryBasis;
            this.kissTextEdit10.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit10.Location = new System.Drawing.Point(90, 109);
            this.kissTextEdit10.Name = "kissTextEdit10";
            this.kissTextEdit10.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit10.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit10.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit10.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit10.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit10.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit10.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit10.Properties.ReadOnly = true;
            this.kissTextEdit10.Size = new System.Drawing.Size(50, 24);
            this.kissTextEdit10.TabIndex = 638;
            //
            // kissTextEdit11
            //
            this.kissTextEdit11.DataMember = "Postfach";
            this.kissTextEdit11.DataSource = this.qryBasis;
            this.kissTextEdit11.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit11.Location = new System.Drawing.Point(90, 86);
            this.kissTextEdit11.Name = "kissTextEdit11";
            this.kissTextEdit11.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit11.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit11.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit11.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit11.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit11.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit11.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit11.Properties.ReadOnly = true;
            this.kissTextEdit11.Size = new System.Drawing.Size(270, 24);
            this.kissTextEdit11.TabIndex = 637;
            //
            // kissTextEdit12
            //
            this.kissTextEdit12.DataMember = "HausNr";
            this.kissTextEdit12.DataSource = this.qryBasis;
            this.kissTextEdit12.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit12.Location = new System.Drawing.Point(311, 63);
            this.kissTextEdit12.Name = "kissTextEdit12";
            this.kissTextEdit12.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit12.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit12.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit12.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit12.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit12.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit12.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit12.Properties.ReadOnly = true;
            this.kissTextEdit12.Size = new System.Drawing.Size(49, 24);
            this.kissTextEdit12.TabIndex = 636;
            //
            // kissTextEdit17
            //
            this.kissTextEdit17.DataMember = "Zusatz";
            this.kissTextEdit17.DataSource = this.qryBasis;
            this.kissTextEdit17.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit17.Location = new System.Drawing.Point(90, 40);
            this.kissTextEdit17.Name = "kissTextEdit17";
            this.kissTextEdit17.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit17.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit17.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit17.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit17.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit17.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit17.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit17.Properties.ReadOnly = true;
            this.kissTextEdit17.Size = new System.Drawing.Size(270, 24);
            this.kissTextEdit17.TabIndex = 634;
            //
            // kissTextEdit18
            //
            this.kissTextEdit18.DataMember = "Strasse";
            this.kissTextEdit18.DataSource = this.qryBasis;
            this.kissTextEdit18.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit18.Location = new System.Drawing.Point(90, 63);
            this.kissTextEdit18.Name = "kissTextEdit18";
            this.kissTextEdit18.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit18.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit18.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit18.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit18.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit18.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit18.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit18.Properties.ReadOnly = true;
            this.kissTextEdit18.Size = new System.Drawing.Size(222, 24);
            this.kissTextEdit18.TabIndex = 635;
            //
            // kissLabel10
            //
            this.kissLabel10.ForeColor = System.Drawing.Color.Black;
            this.kissLabel10.Location = new System.Drawing.Point(5, 40);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(68, 24);
            this.kissLabel10.TabIndex = 647;
            this.kissLabel10.Text = "Zusatz";
            //
            // kissLabel11
            //
            this.kissLabel11.ForeColor = System.Drawing.Color.Black;
            this.kissLabel11.Location = new System.Drawing.Point(5, 86);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(68, 24);
            this.kissLabel11.TabIndex = 646;
            this.kissLabel11.Text = "Postfach";
            //
            // kissLabel12
            //
            this.kissLabel12.ForeColor = System.Drawing.Color.Black;
            this.kissLabel12.Location = new System.Drawing.Point(5, 109);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(68, 24);
            this.kissLabel12.TabIndex = 645;
            this.kissLabel12.Text = "PLZ/Ort/Kt";
            //
            // kissLabel13
            //
            this.kissLabel13.ForeColor = System.Drawing.Color.Black;
            this.kissLabel13.Location = new System.Drawing.Point(5, 132);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(68, 24);
            this.kissLabel13.TabIndex = 644;
            this.kissLabel13.Text = "Land";
            //
            // kissLabel14
            //
            this.kissLabel14.ForeColor = System.Drawing.Color.Black;
            this.kissLabel14.Location = new System.Drawing.Point(5, 63);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(68, 24);
            this.kissLabel14.TabIndex = 643;
            this.kissLabel14.Text = "Strasse/Nr";
            //
            // kissTextEdit19
            //
            this.kissTextEdit19.DataMember = "Vorname";
            this.kissTextEdit19.DataSource = this.qryBasis;
            this.kissTextEdit19.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit19.Location = new System.Drawing.Point(251, 10);
            this.kissTextEdit19.Name = "kissTextEdit19";
            this.kissTextEdit19.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit19.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit19.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit19.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit19.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit19.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit19.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit19.Properties.ReadOnly = true;
            this.kissTextEdit19.Size = new System.Drawing.Size(109, 24);
            this.kissTextEdit19.TabIndex = 633;
            //
            // kissTextEdit20
            //
            this.kissTextEdit20.DataMember = "Name";
            this.kissTextEdit20.DataSource = this.qryBasis;
            this.kissTextEdit20.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit20.Location = new System.Drawing.Point(90, 10);
            this.kissTextEdit20.Name = "kissTextEdit20";
            this.kissTextEdit20.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit20.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit20.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit20.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit20.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit20.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit20.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit20.Properties.ReadOnly = true;
            this.kissTextEdit20.Size = new System.Drawing.Size(162, 24);
            this.kissTextEdit20.TabIndex = 632;
            //
            // kissLabel15
            //
            this.kissLabel15.ForeColor = System.Drawing.Color.Black;
            this.kissLabel15.Location = new System.Drawing.Point(5, 10);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(78, 24);
            this.kissLabel15.TabIndex = 642;
            this.kissLabel15.Text = "Name/Vorname";
            //
            // edtVersNr
            //
            this.edtVersNr.DataMember = "Versichertennummer";
            this.edtVersNr.DataSource = this.qryVmMandant;
            this.edtVersNr.Location = new System.Drawing.Point(450, 73);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Size = new System.Drawing.Size(115, 24);
            this.edtVersNr.TabIndex = 12;
            //
            // lblVersNr
            //
            this.lblVersNr.ForeColor = System.Drawing.Color.Black;
            this.lblVersNr.Location = new System.Drawing.Point(379, 73);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(45, 24);
            this.lblVersNr.TabIndex = 634;
            this.lblVersNr.Text = "Vers.-Nr.";
            //
            // kissTextEdit1
            //
            this.kissTextEdit1.DataMember = "Versichertennummer";
            this.kissTextEdit1.DataSource = this.qryBasis;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(450, 73);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(115, 24);
            this.kissTextEdit1.TabIndex = 658;
            //
            // kissLabel1
            //
            this.kissLabel1.ForeColor = System.Drawing.Color.Black;
            this.kissLabel1.Location = new System.Drawing.Point(379, 73);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(45, 24);
            this.kissLabel1.TabIndex = 659;
            this.kissLabel1.Text = "Vers.-Nr.";
            //
            // CtlVmMandant
            //
            this.ActiveSQLQuery = this.qryVmMandant;

            this.Controls.Add(this.xTabControl1);
            this.Controls.Add(this.grdVmMandant);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmMandant";
            this.Size = new System.Drawing.Size(707, 506);
            this.Load += new System.EventHandler(this.CtlVmMandant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmMandant)).EndInit();
            this.xTabControl1.ResumeLayout(false);
            this.tabBS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWertschriftenDepot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWertschriftenDepot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeruf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeruf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            this.tabBasis.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBasis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit12.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit17.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit18.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit19.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit20.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void CtlVmMandant_Load(object sender, System.EventArgs e)
        {
            DBUtil.ApplyFallRightsToSqlQuery(FaLeistungID, qryVmMandant);

            // lade Basisdaten einmal am Anfang
            qryBasis.Fill(@"
                SELECT PRS.Name,
                       PRS.Vorname,
                       PRS.Geburtsdatum,
                       PRS.AHVNummer,
                       PRS.Versichertennummer,
                       PRS.ZivilstandCode,
                       --
                       Zusatz       = PRS.WohnsitzAdressZusatz,
                       Strasse      = PRS.WohnsitzStrasse,
                       HausNr       = PRS.WohnsitzHausNr,
                       Postfach     = PRS.WohnsitzPostfach,
                       PLZ          = PRS.WohnsitzPLZ,
                       Ort          = PRS.WohnsitzOrt,
                       Kanton       = PRS.WohnsitzKanton,
                       BaLandID     = PRS.WohnsitzBaLandID,
                       Beruf        = BRF.Beruf,
                       Heimatort    = HEI.Name + ISNULL(' ' + HEI.Kanton, '')
                FROM dbo.FaLeistung                 FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.vwPerson           PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
                  LEFT  JOIN dbo.BaArbeitAusbildung DAA WITH (READUNCOMMITTED) ON DAA.BaPersonID = PRS.BaPersonID
                  LEFT  JOIN dbo.BaBeruf            BRF WITH (READUNCOMMITTED) ON BRF.BaBerufID = DAA.BerufCode
                  LEFT  JOIN dbo.BaGemeinde         HEI WITH (READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
                WHERE FAL.FaLeistungID = {0};", FaLeistungID);

            FillMandant();
        }

        private void editBSHeimatort_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.HeimatortSuchen(edtHeimatort.Text, e.ButtonClicked))
            {
                qryVmMandant["Heimatort"] = dlg["Heimatort"];
                qryVmMandant["HeimatgemeindeBaGemeindeID"] = dlg["Code"];
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void qryVmMandant_BeforePost(object sender, System.EventArgs e)
        {
            if (!edtVersNr.ValidateVersNr(true, false))
            {
                // set focus
                edtVersNr.Focus();

                // cancel, message already shown
                throw new KissCancelException();
            }

            DBUtil.NewHistoryVersion();

            //anstatt update: insert neue Version

            SqlQuery qry = DBUtil.OpenSQL(@"
                INSERT INTO dbo.VmMandant (BaPersonID, Version, Datum, UserID,
                                           Name, Vorname, Geburtsdatum, ZivilstandCode, HeimatgemeindeBaGemeindeID,
                                           Beruf, WertschriftenDepot, AHVNummer, Versichertennummer, Bemerkung)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13});

                SELECT VmMandantID = SCOPE_IDENTITY();",
                qryVmMandant["BaPersonID"],
                ((int)qryVmMandant["Version"]) + 1,
                DateTime.Today,
                Session.User.UserID,
                qryVmMandant["Name"],
                qryVmMandant["Vorname"],
                qryVmMandant["Geburtsdatum"],
                qryVmMandant["ZivilstandCode"],
                qryVmMandant["HeimatgemeindeBaGemeindeID"],
                qryVmMandant["Beruf"],
                qryVmMandant["WertschriftenDepot"],
                qryVmMandant["AHVNummer"],
                qryVmMandant["Versichertennummer"],
                qryVmMandant["Bemerkung"]);

            if (qry.Count == 0)
            {
                throw new KissCancelException();
            }

            //ebenfalls neue Adresse anlegen!
            DBUtil.ExecSQL(@"
                INSERT INTO dbo.BaAdresse (VmMandantID, Zusatz, Strasse, HausNr, Postfach, PLZ, Ort, Kanton, BaLandID, Creator, Modifier)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {9});",
                qry["VmMandantID"],
                qryVmMandant[DBO.BaAdresse.Zusatz],
                qryVmMandant[DBO.BaAdresse.Strasse],
                qryVmMandant[DBO.BaAdresse.HausNr],
                qryVmMandant[DBO.BaAdresse.Postfach],
                qryVmMandant[DBO.BaAdresse.PLZ],
                qryVmMandant[DBO.BaAdresse.Ort],
                qryVmMandant[DBO.BaAdresse.Kanton],
                qryVmMandant[DBO.BaAdresse.BaLandID],
                DBUtil.GetDBRowCreatorModifier());

            // so tun als obs nichts mehr zu tun gibt
            //// qryVmMandant.Row.AcceptChanges();
            //// qryVmMandant.RowModified = false;

            //query neu aufbauen
            FillMandant();
        }

        private void qryVmMandant_PositionChanged(object sender, System.EventArgs e)
        {
            bool enable = qryVmMandant.CanUpdate && ((int)qryVmMandant["Version"] == LastVersion);
            qryVmMandant.EnableBoundFields(enable);

            //Einfärbung der Basis zurücksetzen
            qryBasis.EnableBoundFields(false);
            foreach (Control ctl in UtilsGui.AllControls(xTabControl1))
            {
                if (ctl is IKissBindableEdit && ((IKissBindableEdit)ctl).DataSource == qryBasis)
                    ctl.BackColor = GuiConfig.EditColorReadOnly;
            }

            if (enable)
                CompareBStoBasis();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungID)
        {
            this.lblTitel.Text = titleName;
            this.picTitel.Image = titleImage;
            this.FaLeistungID = faLeistungID;
        }

        #endregion

        #region Private Methods

        private void CompareBStoBasis()
        {
            //Alle Feldpaare farblich hervorheben, die unterschiedliche Werte in BS- und Basis-Version haben
            foreach (DataColumn col in qryBasis.DataTable.Columns)
            {
                if (qryVmMandant[col.ColumnName].ToString() != qryBasis[col.ColumnName].ToString())
                {
                    foreach (Control ctl in UtilsGui.AllControls(xTabControl1))
                    {
                        if (ctl is IKissBindableEdit && ((IKissBindableEdit)ctl).DataMember == col.ColumnName)
                            ctl.BackColor = Color.PowderBlue;
                    }
                }
            }
        }

        private void FillMandant()
        {
            LastVersion = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(MAX(Version),0)
                FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.VmMandant VMD WITH (READUNCOMMITTED) on VMD.BaPersonID = FAL.BaPersonID
                WHERE FAL.FaLeistungID = {0};", FaLeistungID);

            qryVmMandant.Fill(@"
                SELECT VMD.*,
                       ADR.Zusatz,
                       ADR.Strasse,
                       ADR.HausNr,
                       ADR.Postfach,
                       ADR.PLZ,
                       ADR.Ort,
                       ADR.Kanton,
                       ADR.BaLandID,
                       SAR       = USR.LastName + ISNULL(', ' + USR.FirstName, ''),
                       Heimatort = HEI.Name + ISNULL(' ' + HEI.Kanton, '')
                FROM dbo.FaLeistung          FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.VmMandant   VMD WITH (READUNCOMMITTED) ON VMD.BaPersonID = FAL.BaPersonID
                  LEFT  JOIN dbo.BaAdresse   ADR WITH (READUNCOMMITTED) ON ADR.VmMandantID = VMD.VmMandantID
                  LEFT  JOIN dbo.XUser       USR WITH (READUNCOMMITTED) ON USR.UserID = VMD.UserID
                  LEFT  JOIN dbo.BaGemeinde  HEI WITH (READUNCOMMITTED) ON HEI.BaGemeindeID = VMD.HeimatgemeindeBaGemeindeID
                WHERE FAL.FaLeistungID = {0}
                ORDER BY [Version]", FaLeistungID);

            qryVmMandant.Last();
        }

        #endregion

        #endregion
    }
}