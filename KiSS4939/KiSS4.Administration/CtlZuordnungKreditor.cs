using System;
using System.Data;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public class CtlZuordnungKreditor : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnInstitutionErfassen;
        private KiSS4.Gui.KissButton btnZahlwegZuweisen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit editBaInstitution;
        private KiSS4.Gui.KissButtonEdit editBaPerson;
        private KiSS4.Gui.KissTextEdit edtBaInstitutionID;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissCheckEdit edtNurLetzteMonate;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissTextEdit edttPLZ;
        private KiSS4.Gui.KissGrid grdFlKreditor;
        private KiSS4.Gui.KissGrid grdFlZahlungsweg;
        private KiSS4.Gui.KissGrid grdInstZahlungsweg;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFlZahlungsweg;
        private KiSS4.Gui.KissLabel lblAnzahl;
        private KiSS4.Gui.KissLabel lblAnzahlZuweisen;
        private KiSS4.Gui.KissLabel lblBaInstitutionID;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblInstitutionKiSS;
        private KiSS4.Gui.KissLabel lblInstitutionSuchen;
        private KiSS4.Gui.KissLabel lblKreditorSchnittstelle;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblOrt;
        private KiSS4.Gui.KissLabel lblPLZ;
        private KiSS4.Gui.KissLabel lblPersonSuchen;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblZahlungswege1;
        private KiSS4.Gui.KissLabel lblZahlungswege2;
        private KiSS4.DB.SqlQuery qryBaPersonBaInstitution;
        private KiSS4.DB.SqlQuery qryFlKreditor;
        private KiSS4.DB.SqlQuery qryInstitutionZahlungswege;
        private KiSS4.DB.SqlQuery qryKreditorZahlungswege;

        #endregion

        #endregion

        #region Constructors

        public CtlZuordnungKreditor()
        {
            this.InitializeComponent();

            qryFlKreditor.Fill(edtNurLetzteMonate.EditValue);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlZuordnungKreditor));
            this.editBaInstitution = new KiSS4.Gui.KissButtonEdit();
            this.editBaPerson = new KiSS4.Gui.KissButtonEdit();
            this.lblInstitutionKiSS = new KiSS4.Gui.KissLabel();
            this.lblPersonSuchen = new KiSS4.Gui.KissLabel();
            this.lblInstitutionSuchen = new KiSS4.Gui.KissLabel();
            this.lblKreditorSchnittstelle = new KiSS4.Gui.KissLabel();
            this.edtBaInstitutionID = new KiSS4.Gui.KissTextEdit();
            this.qryBaPersonBaInstitution = new KiSS4.DB.SqlQuery(this.components);
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edttPLZ = new KiSS4.Gui.KissTextEdit();
            this.lblZahlungswege1 = new KiSS4.Gui.KissLabel();
            this.lblZahlungswege2 = new KiSS4.Gui.KissLabel();
            this.grdFlZahlungsweg = new KiSS4.Gui.KissGrid();
            this.qryKreditorZahlungswege = new KiSS4.DB.SqlQuery(this.components);
            this.grvFlZahlungsweg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdInstZahlungsweg = new KiSS4.Gui.KissGrid();
            this.qryInstitutionZahlungswege = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnInstitutionErfassen = new KiSS4.Gui.KissButton();
            this.btnZahlwegZuweisen = new KiSS4.Gui.KissButton();
            this.lblBaInstitutionID = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblPLZ = new KiSS4.Gui.KissLabel();
            this.lblOrt = new KiSS4.Gui.KissLabel();
            this.grdFlKreditor = new KiSS4.Gui.KissGrid();
            this.qryFlKreditor = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtNurLetzteMonate = new KiSS4.Gui.KissCheckEdit();
            this.lblAnzahlZuweisen = new KiSS4.Gui.KissLabel();
            this.lblAnzahl = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.editBaInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionKiSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonSuchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionSuchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorSchnittstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPersonBaInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edttPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungswege1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungswege2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKreditorZahlungswege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFlZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitutionZahlungswege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaInstitutionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFlKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurLetzteMonate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlZuweisen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahl)).BeginInit();
            this.SuspendLayout();
            //
            // editBaInstitution
            //
            this.editBaInstitution.Location = new System.Drawing.Point(638, 43);
            this.editBaInstitution.Name = "editBaInstitution";
            this.editBaInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBaInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBaInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBaInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.editBaInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.editBaInstitution.Properties.Appearance.Options.UseFont = true;
            this.editBaInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editBaInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editBaInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBaInstitution.Size = new System.Drawing.Size(270, 24);
            this.editBaInstitution.TabIndex = 0;
            this.editBaInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editBaInstitution_UserModifiedFld);
            //
            // editBaPerson
            //
            this.editBaPerson.Location = new System.Drawing.Point(638, 73);
            this.editBaPerson.Name = "editBaPerson";
            this.editBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.editBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.editBaPerson.Properties.Appearance.Options.UseFont = true;
            this.editBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editBaPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBaPerson.Size = new System.Drawing.Size(270, 24);
            this.editBaPerson.TabIndex = 0;
            this.editBaPerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editBaPerson_UserModifiedFld);
            //
            // lblInstitutionKiSS
            //
            this.lblInstitutionKiSS.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblInstitutionKiSS.Location = new System.Drawing.Point(638, 13);
            this.lblInstitutionKiSS.Name = "lblInstitutionKiSS";
            this.lblInstitutionKiSS.Size = new System.Drawing.Size(145, 16);
            this.lblInstitutionKiSS.TabIndex = 6;
            this.lblInstitutionKiSS.Text = "Institution KiSS";
            this.lblInstitutionKiSS.UseCompatibleTextRendering = true;
            //
            // lblPersonSuchen
            //
            this.lblPersonSuchen.Location = new System.Drawing.Point(515, 73);
            this.lblPersonSuchen.Name = "lblPersonSuchen";
            this.lblPersonSuchen.Size = new System.Drawing.Size(110, 24);
            this.lblPersonSuchen.TabIndex = 7;
            this.lblPersonSuchen.Text = "Person suchen";
            this.lblPersonSuchen.UseCompatibleTextRendering = true;
            //
            // lblInstitutionSuchen
            //
            this.lblInstitutionSuchen.Location = new System.Drawing.Point(515, 43);
            this.lblInstitutionSuchen.Name = "lblInstitutionSuchen";
            this.lblInstitutionSuchen.Size = new System.Drawing.Size(110, 24);
            this.lblInstitutionSuchen.TabIndex = 7;
            this.lblInstitutionSuchen.Text = "Institution suchen";
            this.lblInstitutionSuchen.UseCompatibleTextRendering = true;
            //
            // lblKreditorSchnittstelle
            //
            this.lblKreditorSchnittstelle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKreditorSchnittstelle.Location = new System.Drawing.Point(8, 13);
            this.lblKreditorSchnittstelle.Name = "lblKreditorSchnittstelle";
            this.lblKreditorSchnittstelle.Size = new System.Drawing.Size(169, 16);
            this.lblKreditorSchnittstelle.TabIndex = 9;
            this.lblKreditorSchnittstelle.Text = "Kreditor Schnittstelle";
            this.lblKreditorSchnittstelle.UseCompatibleTextRendering = true;
            //
            // edtBaInstitutionID
            //
            this.edtBaInstitutionID.AllowDrop = true;
            this.edtBaInstitutionID.DataMember = "BaInstitutionID";
            this.edtBaInstitutionID.DataSource = this.qryBaPersonBaInstitution;
            this.edtBaInstitutionID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaInstitutionID.Location = new System.Drawing.Point(638, 104);
            this.edtBaInstitutionID.Name = "edtBaInstitutionID";
            this.edtBaInstitutionID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaInstitutionID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaInstitutionID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaInstitutionID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaInstitutionID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaInstitutionID.Properties.Appearance.Options.UseFont = true;
            this.edtBaInstitutionID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaInstitutionID.Properties.ReadOnly = true;
            this.edtBaInstitutionID.Size = new System.Drawing.Size(93, 24);
            this.edtBaInstitutionID.TabIndex = 17;
            //
            // qryBaPersonBaInstitution
            //
            this.qryBaPersonBaInstitution.BatchUpdate = true;
            this.qryBaPersonBaInstitution.HostControl = this;
            this.qryBaPersonBaInstitution.SelectStatement = resources.GetString("qryBaPersonBaInstitution.SelectStatement");
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.AllowDrop = true;
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBaPersonBaInstitution;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(815, 104);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(93, 24);
            this.edtBaPersonID.TabIndex = 17;
            //
            // edtName
            //
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBaPersonBaInstitution;
            this.edtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtName.Location = new System.Drawing.Point(638, 134);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.ReadOnly = true;
            this.edtName.Size = new System.Drawing.Size(270, 24);
            this.edtName.TabIndex = 18;
            //
            // edtStrasse
            //
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryBaPersonBaInstitution;
            this.edtStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasse.Location = new System.Drawing.Point(638, 165);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Properties.ReadOnly = true;
            this.edtStrasse.Size = new System.Drawing.Size(270, 24);
            this.edtStrasse.TabIndex = 19;
            //
            // edtOrt
            //
            this.edtOrt.DataMember = "Ort";
            this.edtOrt.DataSource = this.qryBaPersonBaInstitution;
            this.edtOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrt.Location = new System.Drawing.Point(638, 226);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Properties.ReadOnly = true;
            this.edtOrt.Size = new System.Drawing.Size(270, 24);
            this.edtOrt.TabIndex = 22;
            //
            // edttPLZ
            //
            this.edttPLZ.DataMember = "PLZ";
            this.edttPLZ.DataSource = this.qryBaPersonBaInstitution;
            this.edttPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edttPLZ.Location = new System.Drawing.Point(638, 196);
            this.edttPLZ.Name = "edttPLZ";
            this.edttPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edttPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edttPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edttPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edttPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edttPLZ.Properties.Appearance.Options.UseFont = true;
            this.edttPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edttPLZ.Properties.ReadOnly = true;
            this.edttPLZ.Size = new System.Drawing.Size(100, 24);
            this.edttPLZ.TabIndex = 595;
            //
            // lblZahlungswege1
            //
            this.lblZahlungswege1.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblZahlungswege1.Location = new System.Drawing.Point(8, 321);
            this.lblZahlungswege1.Name = "lblZahlungswege1";
            this.lblZahlungswege1.Size = new System.Drawing.Size(143, 16);
            this.lblZahlungswege1.TabIndex = 599;
            this.lblZahlungswege1.Text = "Zahlungswege";
            this.lblZahlungswege1.UseCompatibleTextRendering = true;
            //
            // lblZahlungswege2
            //
            this.lblZahlungswege2.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblZahlungswege2.Location = new System.Drawing.Point(515, 321);
            this.lblZahlungswege2.Name = "lblZahlungswege2";
            this.lblZahlungswege2.Size = new System.Drawing.Size(143, 16);
            this.lblZahlungswege2.TabIndex = 599;
            this.lblZahlungswege2.Text = "Zahlungswege";
            this.lblZahlungswege2.UseCompatibleTextRendering = true;
            //
            // grdFlZahlungsweg
            //
            this.grdFlZahlungsweg.DataSource = this.qryKreditorZahlungswege;
            this.grdFlZahlungsweg.EmbeddedNavigator.Name = "";
            this.grdFlZahlungsweg.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFlZahlungsweg.Location = new System.Drawing.Point(8, 349);
            this.grdFlZahlungsweg.MainView = this.grvFlZahlungsweg;
            this.grdFlZahlungsweg.Name = "grdFlZahlungsweg";
            this.grdFlZahlungsweg.Size = new System.Drawing.Size(480, 214);
            this.grdFlZahlungsweg.TabIndex = 600;
            this.grdFlZahlungsweg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFlZahlungsweg});
            //
            // qryKreditorZahlungswege
            //
            this.qryKreditorZahlungswege.HostControl = this;
            this.qryKreditorZahlungswege.SelectStatement = resources.GetString("qryKreditorZahlungswege.SelectStatement");
            //
            // grvFlZahlungsweg
            //
            this.grvFlZahlungsweg.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFlZahlungsweg.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.Empty.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.Empty.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.EvenRow.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFlZahlungsweg.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFlZahlungsweg.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFlZahlungsweg.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFlZahlungsweg.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFlZahlungsweg.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFlZahlungsweg.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFlZahlungsweg.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFlZahlungsweg.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFlZahlungsweg.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFlZahlungsweg.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.GroupRow.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFlZahlungsweg.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFlZahlungsweg.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFlZahlungsweg.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFlZahlungsweg.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFlZahlungsweg.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFlZahlungsweg.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFlZahlungsweg.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFlZahlungsweg.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFlZahlungsweg.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.OddRow.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFlZahlungsweg.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.Row.Options.UseBackColor = true;
            this.grvFlZahlungsweg.Appearance.Row.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFlZahlungsweg.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFlZahlungsweg.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFlZahlungsweg.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFlZahlungsweg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFlZahlungsweg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn15,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.grvFlZahlungsweg.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFlZahlungsweg.GridControl = this.grdFlZahlungsweg;
            this.grvFlZahlungsweg.Name = "grvFlZahlungsweg";
            this.grvFlZahlungsweg.OptionsBehavior.Editable = false;
            this.grvFlZahlungsweg.OptionsCustomization.AllowFilter = false;
            this.grvFlZahlungsweg.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFlZahlungsweg.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFlZahlungsweg.OptionsNavigation.UseTabKey = false;
            this.grvFlZahlungsweg.OptionsSelection.MultiSelect = true;
            this.grvFlZahlungsweg.OptionsView.ColumnAutoWidth = false;
            this.grvFlZahlungsweg.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFlZahlungsweg.OptionsView.ShowGroupPanel = false;
            this.grvFlZahlungsweg.OptionsView.ShowIndicator = false;
            //
            // gridColumn
            //
            this.gridColumn.Caption = "Kontoart";
            this.gridColumn.FieldName = "Kontoart";
            this.gridColumn.Name = "gridColumn";
            this.gridColumn.Visible = true;
            this.gridColumn.VisibleIndex = 0;
            //
            // gridColumn9
            //
            this.gridColumn9.Caption = "KontoNr";
            this.gridColumn9.FieldName = "BankKontoNr";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            //
            // gridColumn10
            //
            this.gridColumn10.Caption = "PcKonto";
            this.gridColumn10.FieldName = "BankPcKonto";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            //
            // gridColumn11
            //
            this.gridColumn11.Caption = "EsrTeilnehmer";
            this.gridColumn11.FieldName = "EsrTeilnehmer";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            //
            // gridColumn15
            //
            this.gridColumn15.Caption = "Clearing";
            this.gridColumn15.FieldName = "Clearing";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            //
            // gridColumn8
            //
            this.gridColumn8.Caption = "Name";
            this.gridColumn8.FieldName = "Bankname";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            //
            // gridColumn12
            //
            this.gridColumn12.Caption = "Strasse";
            this.gridColumn12.FieldName = "Strasse";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            //
            // gridColumn13
            //
            this.gridColumn13.Caption = "PLZ";
            this.gridColumn13.FieldName = "PLZ";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            //
            // gridColumn14
            //
            this.gridColumn14.Caption = "Ort";
            this.gridColumn14.FieldName = "Ort";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            //
            // grdInstZahlungsweg
            //
            this.grdInstZahlungsweg.DataSource = this.qryInstitutionZahlungswege;
            this.grdInstZahlungsweg.EmbeddedNavigator.Name = "";
            this.grdInstZahlungsweg.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdInstZahlungsweg.Location = new System.Drawing.Point(515, 349);
            this.grdInstZahlungsweg.MainView = this.gridView1;
            this.grdInstZahlungsweg.Name = "grdInstZahlungsweg";
            this.grdInstZahlungsweg.Size = new System.Drawing.Size(481, 214);
            this.grdInstZahlungsweg.TabIndex = 600;
            this.grdInstZahlungsweg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // qryInstitutionZahlungswege
            //
            this.qryInstitutionZahlungswege.HostControl = this;
            this.qryInstitutionZahlungswege.SelectStatement = "SELECT *\r\nFROM BaZahlungsweg \r\nWHERE BaInstitutionID = {0} OR BaPersonID = {1}";
            //
            // gridView1
            //
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdInstZahlungsweg;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            //
            // gridColumn2
            //
            this.gridColumn2.Caption = "KontoNr";
            this.gridColumn2.FieldName = "BankKontoNummer";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            //
            // gridColumn3
            //
            this.gridColumn3.Caption = "PCKonto";
            this.gridColumn3.FieldName = "PostKontoNummer";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            //
            // gridColumn1
            //
            this.gridColumn1.Caption = "Name";
            this.gridColumn1.FieldName = "AdresseName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            //
            // gridColumn4
            //
            this.gridColumn4.Caption = "Strasse";
            this.gridColumn4.FieldName = "AdresseStrasse";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            //
            // gridColumn6
            //
            this.gridColumn6.Caption = "PLZ";
            this.gridColumn6.FieldName = "AdressePLZ";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            //
            // gridColumn7
            //
            this.gridColumn7.Caption = "Ort";
            this.gridColumn7.FieldName = "AdresseOrt";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            //
            // btnInstitutionErfassen
            //
            this.btnInstitutionErfassen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstitutionErfassen.Location = new System.Drawing.Point(332, 300);
            this.btnInstitutionErfassen.Name = "btnInstitutionErfassen";
            this.btnInstitutionErfassen.Size = new System.Drawing.Size(156, 24);
            this.btnInstitutionErfassen.TabIndex = 601;
            this.btnInstitutionErfassen.Text = "Institution erfassen";
            this.btnInstitutionErfassen.UseCompatibleTextRendering = true;
            this.btnInstitutionErfassen.UseVisualStyleBackColor = false;
            this.btnInstitutionErfassen.Click += new System.EventHandler(this.btnInstitutionErfassen_Click);
            //
            // btnZahlwegZuweisen
            //
            this.btnZahlwegZuweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZahlwegZuweisen.Location = new System.Drawing.Point(332, 581);
            this.btnZahlwegZuweisen.Name = "btnZahlwegZuweisen";
            this.btnZahlwegZuweisen.Size = new System.Drawing.Size(156, 24);
            this.btnZahlwegZuweisen.TabIndex = 601;
            this.btnZahlwegZuweisen.Text = "Zahlungsweg zuweisen";
            this.btnZahlwegZuweisen.UseCompatibleTextRendering = true;
            this.btnZahlwegZuweisen.UseVisualStyleBackColor = false;
            this.btnZahlwegZuweisen.Click += new System.EventHandler(this.btnZahlwegZuweisen_Click);
            //
            // lblBaInstitutionID
            //
            this.lblBaInstitutionID.Location = new System.Drawing.Point(515, 104);
            this.lblBaInstitutionID.Name = "lblBaInstitutionID";
            this.lblBaInstitutionID.Size = new System.Drawing.Size(87, 24);
            this.lblBaInstitutionID.TabIndex = 603;
            this.lblBaInstitutionID.Text = "BaInstitutionID";
            this.lblBaInstitutionID.UseCompatibleTextRendering = true;
            //
            // lblBaPersonID
            //
            this.lblBaPersonID.Location = new System.Drawing.Point(739, 103);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(70, 24);
            this.lblBaPersonID.TabIndex = 603;
            this.lblBaPersonID.Text = "BaPersonID";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(515, 134);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 24);
            this.lblName.TabIndex = 604;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // lblStrasse
            //
            this.lblStrasse.Location = new System.Drawing.Point(515, 165);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(54, 24);
            this.lblStrasse.TabIndex = 605;
            this.lblStrasse.Text = "Strasse";
            this.lblStrasse.UseCompatibleTextRendering = true;
            //
            // lblPLZ
            //
            this.lblPLZ.Location = new System.Drawing.Point(515, 195);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(53, 24);
            this.lblPLZ.TabIndex = 606;
            this.lblPLZ.Text = "PLZ";
            this.lblPLZ.UseCompatibleTextRendering = true;
            //
            // lblOrt
            //
            this.lblOrt.Location = new System.Drawing.Point(515, 226);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(53, 24);
            this.lblOrt.TabIndex = 607;
            this.lblOrt.Text = "Ort";
            this.lblOrt.UseCompatibleTextRendering = true;
            //
            // grdFlKreditor
            //
            this.grdFlKreditor.DataSource = this.qryFlKreditor;
            this.grdFlKreditor.EmbeddedNavigator.Name = "";
            this.grdFlKreditor.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFlKreditor.Location = new System.Drawing.Point(8, 43);
            this.grdFlKreditor.MainView = this.gridView2;
            this.grdFlKreditor.Name = "grdFlKreditor";
            this.grdFlKreditor.Size = new System.Drawing.Size(480, 236);
            this.grdFlKreditor.TabIndex = 608;
            this.grdFlKreditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            //
            // qryFlKreditor
            //
            this.qryFlKreditor.HostControl = this;
            this.qryFlKreditor.SelectStatement = resources.GetString("qryFlKreditor.SelectStatement");
            this.qryFlKreditor.PositionChanged += new System.EventHandler(this.qryFlKreditor_PositionChanged);
            this.qryFlKreditor.AfterFill += new System.EventHandler(this.qryFlKreditor_AfterFill);
            //
            // gridView2
            //
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdFlKreditor;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            //
            // edtNur2008
            //
            this.edtNurLetzteMonate.EditValue = false;
            this.edtNurLetzteMonate.Location = new System.Drawing.Point(256, 21);
            this.edtNurLetzteMonate.Name = "edtNur2008";
            this.edtNurLetzteMonate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurLetzteMonate.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurLetzteMonate.Properties.Caption = "Nur in den letzten 12 Monaten verwendete";
            this.edtNurLetzteMonate.Size = new System.Drawing.Size(232, 19);
            this.edtNurLetzteMonate.TabIndex = 609;
            this.edtNurLetzteMonate.EditValueChanged += new System.EventHandler(this.edtNur2008_EditValueChanged);
            //
            // lblAnzahlZuweisen
            //
            this.lblAnzahlZuweisen.Location = new System.Drawing.Point(89, 282);
            this.lblAnzahlZuweisen.Name = "lblAnzahlZuweisen";
            this.lblAnzahlZuweisen.Size = new System.Drawing.Size(103, 24);
            this.lblAnzahlZuweisen.TabIndex = 610;
            this.lblAnzahlZuweisen.Text = "Es fehlen nur noch:";
            this.lblAnzahlZuweisen.UseCompatibleTextRendering = true;
            //
            // lblAnzahl
            //
            this.lblAnzahl.Location = new System.Drawing.Point(198, 282);
            this.lblAnzahl.Name = "lblAnzahl";
            this.lblAnzahl.Size = new System.Drawing.Size(53, 24);
            this.lblAnzahl.TabIndex = 611;
            this.lblAnzahl.Text = "0";
            this.lblAnzahl.UseCompatibleTextRendering = true;
            //
            // CtlZuordnungKreditor
            //
            this.Controls.Add(this.lblAnzahl);
            this.Controls.Add(this.lblAnzahlZuweisen);
            this.Controls.Add(this.edtNurLetzteMonate);
            this.Controls.Add(this.grdFlKreditor);
            this.Controls.Add(this.lblOrt);
            this.Controls.Add(this.lblPLZ);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.lblBaInstitutionID);
            this.Controls.Add(this.btnZahlwegZuweisen);
            this.Controls.Add(this.btnInstitutionErfassen);
            this.Controls.Add(this.grdInstZahlungsweg);
            this.Controls.Add(this.grdFlZahlungsweg);
            this.Controls.Add(this.lblZahlungswege2);
            this.Controls.Add(this.lblZahlungswege1);
            this.Controls.Add(this.edttPLZ);
            this.Controls.Add(this.edtOrt);
            this.Controls.Add(this.edtStrasse);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.edtBaInstitutionID);
            this.Controls.Add(this.lblKreditorSchnittstelle);
            this.Controls.Add(this.lblInstitutionSuchen);
            this.Controls.Add(this.lblPersonSuchen);
            this.Controls.Add(this.lblInstitutionKiSS);
            this.Controls.Add(this.editBaPerson);
            this.Controls.Add(this.editBaInstitution);
            this.Name = "CtlZuordnungKreditor";
            this.Size = new System.Drawing.Size(1014, 614);
            ((System.ComponentModel.ISupportInitialize)(this.editBaInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionKiSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonSuchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionSuchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorSchnittstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPersonBaInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edttPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungswege1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungswege2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKreditorZahlungswege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFlZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitutionZahlungswege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaInstitutionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFlKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurLetzteMonate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlZuweisen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahl)).EndInit();
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

        private void btnInstitutionErfassen_Click(object sender, System.EventArgs e)
        {
            InstitutionErfassen();
        }

        private void btnZahlwegZuweisen_Click(object sender, System.EventArgs e)
        {
            ZahlwegZuweisen();
        }

        private void editBaInstitution_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = editBaInstitution.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg = new KissLookupDialog();

            if (e.ButtonClicked || !DBUtil.IsEmpty(searchString))
            {
                if (DBUtil.IsEmpty(searchString))
                {
                    searchString = "%";
                }

                e.Cancel = !dlg.SearchData(string.Format(@"
                    SELECT BainstitutionID,
                           Name  = INS.NameVorname,
                           Typen = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', {1}, {2}),
                           Telefon,
                           Strasse,
                           Ort
                           PLZ,
                           Bemerkung,
                           Aktiv,
                           Anrede,
                           Homepage,
                           Debitor,
                           Kreditor,
                           Aktiv
                    FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                    WHERE INS.NameVorname LIKE '%' + {0} + '%';", DBUtil.SqlLiteral(searchString), Session.User.UserID, Session.User.LanguageCode),
                                           searchString,
                                           e.ButtonClicked);
            }

            if (!e.Cancel)
            {
                editBaInstitution.EditValue = dlg["Name"];
                editBaInstitution.LookupID = dlg["BainstitutionID"];

                qryBaPersonBaInstitution.Fill(DBNull.Value, dlg["BainstitutionID"]);

                qryInstitutionZahlungswege.Fill(dlg["BaInstitutionID"], null);

                editBaPerson.EditValue = "";
                editBaPerson.LookupID = null;

            }
        }

        private void editBaPerson_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = editBaPerson.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg2 = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(SearchString))
            {
                if (DBUtil.IsEmpty(SearchString))
                    SearchString = "%";

                e.Cancel = !dlg2.SearchData(@"
             	                SELECT TOP 2000
                                  BaPersonID,
                                  NameVorname,
                                  WohnsitzStrasse,
                                  WohnsitzOrt,
                                  WohnsitzPLZ,
                                  Person = Name + isNull(', ' + Vorname,'')
                                FROM vwPerson
                                WHERE Name + ISNULL(', ' + Vorname,'') LIKE {0} + '%'
                                ORDER BY NameVorname, WohnsitzPLZ
                                ", SearchString, e.ButtonClicked, null, null, null);
            }
            if (!e.Cancel)
            {
                editBaPerson.EditValue = dlg2["NameVorname"];
                editBaPerson.LookupID = dlg2["BaPersonID"];

                qryBaPersonBaInstitution.Fill(dlg2["BaPersonID"], DBNull.Value);
                qryInstitutionZahlungswege.Fill(-1, dlg2["BaPersonID"]);

                editBaInstitution.EditValue = "";
                editBaInstitution.LookupID = null;

            }
        }

        private void edtNur2008_EditValueChanged(object sender, System.EventArgs e)
        {
            if ((bool)edtNurLetzteMonate.EditValue)
            {
                qryFlKreditor.Fill(@"
                    SELECT *
                    FROM FlKreditor   FLK
                    WHERE EXISTS (SELECT 1 FROM FlZahlungsweg FLZ
                                    INNER JOIN BaZahlungsweg  BZW ON BZW.BaZahlungswegID = FLZ.FlZahlungswegID
                                  WHERE FLZ.FlKreditorID = FLK.FlKreditorID AND BZW.BaPersonID IS NULL AND BZW.BaInstitutionID IS NULL)
                      AND FlKreditorID IN (SELECT DISTINCT FlKreditorID
                                           FROM FlZahlungslauf         ZLF
                                             INNER JOIN KbBuchung      BEL ON BEL.FlZahlungslaufID = ZLF.FlZahlungslaufID
                                             INNER JOIN FlZahlungsweg  FLZ ON FLZ.FlZahlungswegID = BEL.BaZahlungswegID
                                           WHERE ymDatumZahlungslauf > (YEAR(DATEADD(YEAR, -1, GETDATE())) * 12))
                    ORDER BY Name, PLZ");
            }
            else
            {
                qryFlKreditor.Fill(@"
                    SELECT *
                    FROM FlKreditor   FLK
                    WHERE EXISTS (SELECT 1 FROM FlZahlungsweg FLZ
                                    INNER JOIN BaZahlungsweg  BZW ON BZW.BaZahlungswegID = FLZ.FlZahlungswegID
                                  WHERE FLZ.FlKreditorID = FLK.FlKreditorID AND BZW.BaPersonID IS NULL AND BZW.BaInstitutionID IS NULL)
                    ORDER BY Name, PLZ");
            }
        }

        private void qryFlKreditor_AfterFill(object sender, System.EventArgs e)
        {
            if (qryFlKreditor.Count == 1432)
            {
                MessageBox.Show("Schon fertig?");
            }
            if (qryFlKreditor.Count == 497)
            {
                MessageBox.Show("Es hat noch ein paar...Go for it!");
            }
            if (qryFlKreditor.Count == 345)
            {
                MessageBox.Show("So schlimm wars jetzt auch nicht oder?!!!");
            }
            if (qryFlKreditor.Count == 3)
            {
                MessageBox.Show("Nur noch 3! Tschagaaa... du schaffst es! :-)");
            }
            if (qryFlKreditor.Count == 1)
            {
                MessageBox.Show("Sorry, jetzt gibt's nur noch einen zuzuweisen. Schon fast schade, oder?");
            }

            lblAnzahl.Text = qryFlKreditor.Count.ToString();
        }

        private void qryFlKreditor_PositionChanged(object sender, System.EventArgs e)
        {
            qryKreditorZahlungswege.Fill(qryFlKreditor["FlKreditorID"]);
        }

        #endregion

        #region Methods

        #region Private Methods

        private void InstitutionErfassen()
        {
            DBUtil.NewHistoryVersion();

            Session.BeginTransaction();
            try
            {
                int InstitutionID = (int)DBUtil.ExecuteScalarSQL(@"
                INSERT INTO BaInstitution (Name, Creator, Created, Modifier, Modified)
                  VALUES ({0}, {1}, GetDate(), {1}, GetDate())
                SELECT CAST(SCOPE_IDENTITY() AS int )",
                    qryFlKreditor["Name"], DBUtil.GetDBRowCreatorModifier());

                DBUtil.ExecuteScalarSQL(@"
                INSERT INTO BaAdresse (BaInstitutionID, Strasse, PLZ, Ort)
                  VALUES ({0},{1},{2},{3})",
                    InstitutionID, qryFlKreditor["Strasse"],
                    qryFlKreditor["PLZ"], qryFlKreditor["Ort"]);

                qryBaPersonBaInstitution.Fill(DBNull.Value, InstitutionID);
                qryInstitutionZahlungswege.Fill(InstitutionID, DBNull.Value);

                editBaInstitution.EditValue = qryFlKreditor["Name"];
                editBaInstitution.LookupID = InstitutionID;

                editBaPerson.EditValue = "";
                editBaPerson.LookupID = null;

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }

            KissMsg.ShowInfo("Institution erfolgreich erfasst");
        }

        private void ZahlwegZuweisen()
        {
            // get all rows the user selected
            int[] RowHandles = grvFlZahlungsweg.GetSelectedRows();
            if (RowHandles == null)
            {
                return;
            }

            if (!DBUtil.IsEmpty(edtBaInstitutionID.EditValue) || !DBUtil.IsEmpty(edtBaPersonID.EditValue))
            {

                // insert all rows the user selected
                foreach (int rowHandle in RowHandles)
                {
                    DataRow row = grvFlZahlungsweg.GetDataRow(rowHandle);

                    if (!DBUtil.IsEmpty(edtBaInstitutionID.EditValue))
                    {
                        DBUtil.ExecuteScalarSQL(@"UPDATE BaZahlungsweg SET BaInstitutionID = {0} WHERE BaZahlungswegID = {1}", edtBaInstitutionID.EditValue, row["FlZahlungswegID"]);
                    }
                    else if (!DBUtil.IsEmpty(edtBaPersonID.EditValue))
                    {
                        DBUtil.ExecuteScalarSQL(@"UPDATE BaZahlungsweg SET BaPersonID = {0} WHERE BaZahlungswegID = {1}", edtBaPersonID.EditValue, row["FlZahlungswegID"]);
                    }
                }
                qryInstitutionZahlungswege.Refresh();
                qryKreditorZahlungswege.Refresh();
                qryFlKreditor.Refresh();

            }
            else
            {
                KissMsg.ShowInfo("Sie müssen eine Person oder Institution auswählen!");
            }
        }

        #endregion

        #endregion
    }
}