using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryVmPriMaMandateEks : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAufenthaltsort;
        private DevExpress.XtraGrid.Columns.GridColumn colEMailPriMa;
        private DevExpress.XtraGrid.Columns.GridColumn colErrichtungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZPriMa;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNrPriMa;
        private DevExpress.XtraGrid.Columns.GridColumn colStrassePriMa;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnort;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnortPriMa;
        private DevExpress.XtraGrid.Columns.GridColumn colZustPriMa;
        private KiSS4.Gui.KissLabel edt;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissDateEdit edtGeburtBis;
        private KiSS4.Gui.KissDateEdit edtGeburtVon;
        private KiSS4.Gui.KissCheckEdit edtNurAktive;
        private KiSS4.Gui.KissButtonEdit edtVmPriMaID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblGeburtsdatumvon;
        private KiSS4.Gui.KissLabel lblPerson;
        private KiSS4.Gui.KissLabel lblbis;

        #endregion

        #region Constructors

        public CtlQueryVmPriMaMandateEks()
        {
            this.InitializeComponent();

            edtNurAktive.Checked = true;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmPriMaMandateEks));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edt = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatumvon = new KiSS4.Gui.KissLabel();
            this.lblPerson = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtVmPriMaID = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.edtGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.colAufenthaltsort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMailPriMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrichtungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZPriMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNrPriMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrassePriMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnortPriMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustPriMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNurAktive);
            this.tpgSuchen.Controls.Add(this.edtGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtGeburtVon);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtVmPriMaID);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblPerson);
            this.tpgSuchen.Controls.Add(this.lblGeburtsdatumvon);
            this.tpgSuchen.Controls.Add(this.edt);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGeburtsdatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVmPriMaID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktive, 0);
            // 
            // edt
            // 
            this.edt.Location = new System.Drawing.Point(10, 40);
            this.edt.Name = "edt";
            this.edt.Size = new System.Drawing.Size(130, 24);
            this.edt.TabIndex = 1;
            this.edt.Text = "PriMa";
            this.edt.UseCompatibleTextRendering = true;
            // 
            // lblGeburtsdatumvon
            // 
            this.lblGeburtsdatumvon.Location = new System.Drawing.Point(10, 100);
            this.lblGeburtsdatumvon.Name = "lblGeburtsdatumvon";
            this.lblGeburtsdatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblGeburtsdatumvon.TabIndex = 2;
            this.lblGeburtsdatumvon.Text = "Geburtsdatum von";
            this.lblGeburtsdatumvon.UseCompatibleTextRendering = true;
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(10, 70);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(130, 24);
            this.lblPerson.TabIndex = 2;
            this.lblPerson.Text = "Person";
            this.lblPerson.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(270, 100);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 3;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // edtVmPriMaID
            // 
            this.edtVmPriMaID.EditValue = "";
            this.edtVmPriMaID.Location = new System.Drawing.Point(150, 40);
            this.edtVmPriMaID.Name = "edtVmPriMaID";
            this.edtVmPriMaID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmPriMaID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmPriMaID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmPriMaID.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmPriMaID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmPriMaID.Properties.Appearance.Options.UseFont = true;
            this.edtVmPriMaID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVmPriMaID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVmPriMaID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmPriMaID.Size = new System.Drawing.Size(250, 24);
            this.edtVmPriMaID.TabIndex = 21;
            this.edtVmPriMaID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtVmPriMaID_UserModifiedFld);
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Location = new System.Drawing.Point(150, 70);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(250, 24);
            this.edtBaPersonID.TabIndex = 22;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            // 
            // edtGeburtVon
            // 
            this.edtGeburtVon.EditValue = null;
            this.edtGeburtVon.Location = new System.Drawing.Point(150, 100);
            this.edtGeburtVon.Name = "edtGeburtVon";
            this.edtGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtVon.Properties.ShowToday = false;
            this.edtGeburtVon.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtVon.TabIndex = 23;
            // 
            // edtGeburtBis
            // 
            this.edtGeburtBis.EditValue = null;
            this.edtGeburtBis.Location = new System.Drawing.Point(300, 100);
            this.edtGeburtBis.Name = "edtGeburtBis";
            this.edtGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtBis.Properties.ShowToday = false;
            this.edtGeburtBis.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtBis.TabIndex = 24;
            // 
            // edtNurAktive
            // 
            this.edtNurAktive.EditValue = false;
            this.edtNurAktive.Location = new System.Drawing.Point(150, 130);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = "nur aktive";
            this.edtNurAktive.Size = new System.Drawing.Size(250, 19);
            this.edtNurAktive.TabIndex = 25;
            // 
            // colAufenthaltsort
            // 
            this.colAufenthaltsort.Name = "colAufenthaltsort";
            // 
            // colEMailPriMa
            // 
            this.colEMailPriMa.Name = "colEMailPriMa";
            // 
            // colErrichtungsdatum
            // 
            this.colErrichtungsdatum.Name = "colErrichtungsdatum";
            // 
            // colPerson
            // 
            this.colPerson.Name = "colPerson";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colPLZPriMa
            // 
            this.colPLZPriMa.Name = "colPLZPriMa";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colStrasseNr
            // 
            this.colStrasseNr.Name = "colStrasseNr";
            // 
            // colStrasseNrPriMa
            // 
            this.colStrasseNrPriMa.Name = "colStrasseNrPriMa";
            // 
            // colStrassePriMa
            // 
            this.colStrassePriMa.Name = "colStrassePriMa";
            // 
            // colWohnort
            // 
            this.colWohnort.Name = "colWohnort";
            // 
            // colWohnortPriMa
            // 
            this.colWohnortPriMa.Name = "colWohnortPriMa";
            // 
            // colZustPriMa
            // 
            this.colZustPriMa.Name = "colZustPriMa";
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryVmPriMaMandateEks
            // 
            this.Name = "CtlQueryVmPriMaMandateEks";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtNurAktive.Checked = true;
        }

        #endregion

        #region Private Methods

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(string.Format(@"
                SELECT ID = BaPersonID, Person = IsNull(NameVorname, '')
                FROM vwPerson
                WHERE IsNull(NameVorname,'') like {{0}} + '%'
                    AND (PersonSichtbarSDFlag = dbo.fnGetPersonSichtbarFlag('{0}') or PersonSichtbarSDFlag = 1)
                ORDER BY Person", Session.User.LogonName),
                SearchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        private void edtVmPriMaID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtVmPriMaID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                        edtVmPriMaID.EditValue = null;
                        edtVmPriMaID.LookupID = null;
              		return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select ID = VmPriMaID,
                    PriMa = Name + isNull(', ' + Vorname,'')
                from   VmPriMa
                where Name + isNull(', ' + Vorname,'') like {0} + '%'
                order by PriMa",
              SearchString,
              e.ButtonClicked,null,null,null);

            if (!e.Cancel)
            {
                edtVmPriMaID.EditValue = dlg[1];
                edtVmPriMaID.LookupID = dlg[0];
            }
        }

        #endregion
    }
}