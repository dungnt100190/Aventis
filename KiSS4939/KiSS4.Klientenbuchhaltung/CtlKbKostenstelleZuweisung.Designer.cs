namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbKostenstelleZuweisung
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbKostenstelleZuweisung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblKostenstelleX = new KiSS4.Gui.KissLabel();
            this.lblUnterstuetztBisX = new KiSS4.Gui.KissLabel();
            this.lblUnterstuetztVonX = new KiSS4.Gui.KissLabel();
            this.lblBaPersonIDX = new KiSS4.Gui.KissLabel();
            this.edtInklusiveUEPersonenX = new KiSS4.Gui.KissCheckEdit();
            this.edtUnterstuetztBisX = new KiSS4.Gui.KissDateEdit();
            this.edtUnterstuetztVonX = new KiSS4.Gui.KissDateEdit();
            this.edtBaPersonIDX = new KiSS4.Gui.KissButtonEdit();
            this.edtKostenstelleX = new KiSS4.Gui.KissTextEdit();
            this.qryKostenstellePerson = new KiSS4.DB.SqlQuery(this.components);
            this.grdKostenstellePerson = new KiSS4.Gui.KissGrid();
            this.grvKostenstellePerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKostenstelleNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelleAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelleModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.lblGueltigVon = new KiSS4.Gui.KissLabel();
            this.edtGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.edtGueltigVon = new KiSS4.Gui.KissDateEdit();
            this.lblPerson = new KiSS4.Gui.KissLabel();
            this.lblKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtPerson = new KiSS4.Gui.KissButtonEdit();
            this.edtKostenstelle = new KiSS4.Gui.KissButtonEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklusiveUEPersonenX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKostenstellePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenstellePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenstellePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKostenstellePerson);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblKostenstelleX);
            this.tpgSuchen.Controls.Add(this.lblUnterstuetztBisX);
            this.tpgSuchen.Controls.Add(this.lblUnterstuetztVonX);
            this.tpgSuchen.Controls.Add(this.lblBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.edtInklusiveUEPersonenX);
            this.tpgSuchen.Controls.Add(this.edtUnterstuetztBisX);
            this.tpgSuchen.Controls.Add(this.edtUnterstuetztVonX);
            this.tpgSuchen.Controls.Add(this.edtBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.edtKostenstelleX);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenstelleX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUnterstuetztVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUnterstuetztBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklusiveUEPersonenX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUnterstuetztVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUnterstuetztBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKostenstelleX, 0);
            // 
            // lblKostenstelleX
            // 
            this.lblKostenstelleX.Location = new System.Drawing.Point(12, 54);
            this.lblKostenstelleX.Name = "lblKostenstelleX";
            this.lblKostenstelleX.Size = new System.Drawing.Size(90, 24);
            this.lblKostenstelleX.TabIndex = 389;
            this.lblKostenstelleX.Text = "Kostenstelle";
            this.lblKostenstelleX.UseCompatibleTextRendering = true;
            // 
            // lblUnterstuetztBisX
            // 
            this.lblUnterstuetztBisX.Location = new System.Drawing.Point(225, 110);
            this.lblUnterstuetztBisX.Name = "lblUnterstuetztBisX";
            this.lblUnterstuetztBisX.Size = new System.Drawing.Size(26, 24);
            this.lblUnterstuetztBisX.TabIndex = 388;
            this.lblUnterstuetztBisX.Text = "bis";
            this.lblUnterstuetztBisX.UseCompatibleTextRendering = true;
            // 
            // lblUnterstuetztVonX
            // 
            this.lblUnterstuetztVonX.Location = new System.Drawing.Point(12, 110);
            this.lblUnterstuetztVonX.Name = "lblUnterstuetztVonX";
            this.lblUnterstuetztVonX.Size = new System.Drawing.Size(90, 24);
            this.lblUnterstuetztVonX.TabIndex = 387;
            this.lblUnterstuetztVonX.Text = "Gültig von";
            this.lblUnterstuetztVonX.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonIDX
            // 
            this.lblBaPersonIDX.Location = new System.Drawing.Point(12, 80);
            this.lblBaPersonIDX.Name = "lblBaPersonIDX";
            this.lblBaPersonIDX.Size = new System.Drawing.Size(90, 24);
            this.lblBaPersonIDX.TabIndex = 386;
            this.lblBaPersonIDX.Text = "Person";
            this.lblBaPersonIDX.UseCompatibleTextRendering = true;
            // 
            // edtInklusiveUEPersonenX
            // 
            this.edtInklusiveUEPersonenX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtInklusiveUEPersonenX.EditValue = false;
            this.edtInklusiveUEPersonenX.Location = new System.Drawing.Point(375, 84);
            this.edtInklusiveUEPersonenX.Name = "edtInklusiveUEPersonenX";
            this.edtInklusiveUEPersonenX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInklusiveUEPersonenX.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklusiveUEPersonenX.Properties.Caption = "Inkl. UE-Personen";
            this.edtInklusiveUEPersonenX.Properties.ReadOnly = true;
            this.edtInklusiveUEPersonenX.Size = new System.Drawing.Size(205, 19);
            this.edtInklusiveUEPersonenX.TabIndex = 385;
            this.edtInklusiveUEPersonenX.Visible = false;
            // 
            // edtUnterstuetztBisX
            // 
            this.edtUnterstuetztBisX.EditValue = null;
            this.edtUnterstuetztBisX.Location = new System.Drawing.Point(257, 110);
            this.edtUnterstuetztBisX.Name = "edtUnterstuetztBisX";
            this.edtUnterstuetztBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterstuetztBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterstuetztBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterstuetztBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterstuetztBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetztBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterstuetztBisX.Properties.Appearance.Options.UseFont = true;
            this.edtUnterstuetztBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtUnterstuetztBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUnterstuetztBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtUnterstuetztBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterstuetztBisX.Properties.ShowToday = false;
            this.edtUnterstuetztBisX.Size = new System.Drawing.Size(100, 24);
            this.edtUnterstuetztBisX.TabIndex = 384;
            // 
            // edtUnterstuetztVonX
            // 
            this.edtUnterstuetztVonX.EditValue = null;
            this.edtUnterstuetztVonX.Location = new System.Drawing.Point(108, 110);
            this.edtUnterstuetztVonX.Name = "edtUnterstuetztVonX";
            this.edtUnterstuetztVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterstuetztVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterstuetztVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterstuetztVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterstuetztVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetztVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterstuetztVonX.Properties.Appearance.Options.UseFont = true;
            this.edtUnterstuetztVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtUnterstuetztVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUnterstuetztVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtUnterstuetztVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterstuetztVonX.Properties.ShowToday = false;
            this.edtUnterstuetztVonX.Size = new System.Drawing.Size(100, 24);
            this.edtUnterstuetztVonX.TabIndex = 383;
            // 
            // edtBaPersonIDX
            // 
            this.edtBaPersonIDX.Location = new System.Drawing.Point(108, 80);
            this.edtBaPersonIDX.Name = "edtBaPersonIDX";
            this.edtBaPersonIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBaPersonIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonIDX.Size = new System.Drawing.Size(249, 24);
            this.edtBaPersonIDX.TabIndex = 382;
            this.edtBaPersonIDX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonIDX_UserModifiedFld);
            // 
            // edtKostenstelleX
            // 
            this.edtKostenstelleX.Location = new System.Drawing.Point(108, 50);
            this.edtKostenstelleX.Name = "edtKostenstelleX";
            this.edtKostenstelleX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelleX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelleX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelleX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelleX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelleX.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelleX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenstelleX.Size = new System.Drawing.Size(249, 24);
            this.edtKostenstelleX.TabIndex = 381;
            // 
            // qryKostenstellePerson
            // 
            this.qryKostenstellePerson.CanDelete = true;
            this.qryKostenstellePerson.CanInsert = true;
            this.qryKostenstellePerson.CanUpdate = true;
            this.qryKostenstellePerson.HostControl = this;
            this.qryKostenstellePerson.SelectStatement = resources.GetString("qryKostenstellePerson.SelectStatement");
            this.qryKostenstellePerson.TableName = "KbKostenstelle_BaPerson";
            this.qryKostenstellePerson.BeforePost += new System.EventHandler(this.qryKostenstellePerson_BeforePost);
            this.qryKostenstellePerson.AfterInsert += new System.EventHandler(this.qryKostenstellePerson_AfterInsert);
            // 
            // grdKostenstellePerson
            // 
            this.grdKostenstellePerson.DataSource = this.qryKostenstellePerson;
            this.grdKostenstellePerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKostenstellePerson.EmbeddedNavigator.Name = "";
            this.grdKostenstellePerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKostenstellePerson.Location = new System.Drawing.Point(0, 0);
            this.grdKostenstellePerson.MainView = this.grvKostenstellePerson;
            this.grdKostenstellePerson.Name = "grdKostenstellePerson";
            this.grdKostenstellePerson.Size = new System.Drawing.Size(782, 223);
            this.grdKostenstellePerson.TabIndex = 0;
            this.grdKostenstellePerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKostenstellePerson});
            // 
            // grvKostenstellePerson
            // 
            this.grvKostenstellePerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKostenstellePerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.Empty.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKostenstellePerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenstellePerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKostenstellePerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKostenstellePerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenstellePerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKostenstellePerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKostenstellePerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenstellePerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenstellePerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenstellePerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenstellePerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKostenstellePerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKostenstellePerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKostenstellePerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenstellePerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKostenstellePerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKostenstellePerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenstellePerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKostenstellePerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenstellePerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.OddRow.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKostenstellePerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.Row.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.Row.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKostenstellePerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstellePerson.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKostenstellePerson.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKostenstellePerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKostenstellePerson.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKostenstellePerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenstellePerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKostenstellePerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKostenstellePerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKostenstelleNr,
            this.colKostenstelleName,
            this.colKostenstelleAktiv,
            this.colKostenstelleModul,
            this.colPersonNameVorname,
            this.colGueltigVon,
            this.colGueltigBis});
            this.grvKostenstellePerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKostenstellePerson.GridControl = this.grdKostenstellePerson;
            this.grvKostenstellePerson.Name = "grvKostenstellePerson";
            this.grvKostenstellePerson.OptionsBehavior.Editable = false;
            this.grvKostenstellePerson.OptionsCustomization.AllowFilter = false;
            this.grvKostenstellePerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKostenstellePerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKostenstellePerson.OptionsNavigation.UseTabKey = false;
            this.grvKostenstellePerson.OptionsView.ColumnAutoWidth = false;
            this.grvKostenstellePerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKostenstellePerson.OptionsView.ShowGroupPanel = false;
            this.grvKostenstellePerson.OptionsView.ShowIndicator = false;
            // 
            // colKostenstelleNr
            // 
            this.colKostenstelleNr.Caption = "Kst. Nr.";
            this.colKostenstelleNr.FieldName = "Nr";
            this.colKostenstelleNr.Name = "colKostenstelleNr";
            this.colKostenstelleNr.OptionsColumn.AllowEdit = false;
            this.colKostenstelleNr.OptionsColumn.AllowFocus = false;
            this.colKostenstelleNr.OptionsColumn.ReadOnly = true;
            this.colKostenstelleNr.Visible = true;
            this.colKostenstelleNr.VisibleIndex = 0;
            this.colKostenstelleNr.Width = 100;
            // 
            // colKostenstelleName
            // 
            this.colKostenstelleName.Caption = "Kst. Name";
            this.colKostenstelleName.FieldName = "Name";
            this.colKostenstelleName.Name = "colKostenstelleName";
            this.colKostenstelleName.OptionsColumn.AllowEdit = false;
            this.colKostenstelleName.OptionsColumn.AllowFocus = false;
            this.colKostenstelleName.Visible = true;
            this.colKostenstelleName.VisibleIndex = 1;
            this.colKostenstelleName.Width = 170;
            // 
            // colKostenstelleAktiv
            // 
            this.colKostenstelleAktiv.Caption = "Kst. Aktiv";
            this.colKostenstelleAktiv.FieldName = "Aktiv";
            this.colKostenstelleAktiv.Name = "colKostenstelleAktiv";
            this.colKostenstelleAktiv.OptionsColumn.AllowEdit = false;
            this.colKostenstelleAktiv.OptionsColumn.AllowFocus = false;
            this.colKostenstelleAktiv.OptionsColumn.ReadOnly = true;
            this.colKostenstelleAktiv.Visible = true;
            this.colKostenstelleAktiv.VisibleIndex = 2;
            this.colKostenstelleAktiv.Width = 60;
            // 
            // colKostenstelleModul
            // 
            this.colKostenstelleModul.Caption = "Kst. Modul";
            this.colKostenstelleModul.FieldName = "ModulID";
            this.colKostenstelleModul.Name = "colKostenstelleModul";
            this.colKostenstelleModul.OptionsColumn.AllowEdit = false;
            this.colKostenstelleModul.OptionsColumn.AllowFocus = false;
            this.colKostenstelleModul.OptionsColumn.ReadOnly = true;
            this.colKostenstelleModul.Visible = true;
            this.colKostenstelleModul.VisibleIndex = 3;
            this.colKostenstelleModul.Width = 120;
            // 
            // colPersonNameVorname
            // 
            this.colPersonNameVorname.Caption = "Person";
            this.colPersonNameVorname.FieldName = "NameVorname";
            this.colPersonNameVorname.Name = "colPersonNameVorname";
            this.colPersonNameVorname.OptionsColumn.AllowEdit = false;
            this.colPersonNameVorname.OptionsColumn.AllowFocus = false;
            this.colPersonNameVorname.OptionsColumn.ReadOnly = true;
            this.colPersonNameVorname.Visible = true;
            this.colPersonNameVorname.VisibleIndex = 4;
            this.colPersonNameVorname.Width = 150;
            // 
            // colGueltigVon
            // 
            this.colGueltigVon.Caption = "Gültig von";
            this.colGueltigVon.FieldName = "DatumVon";
            this.colGueltigVon.Name = "colGueltigVon";
            this.colGueltigVon.OptionsColumn.AllowEdit = false;
            this.colGueltigVon.OptionsColumn.AllowFocus = false;
            this.colGueltigVon.OptionsColumn.ReadOnly = true;
            this.colGueltigVon.Visible = true;
            this.colGueltigVon.VisibleIndex = 5;
            // 
            // colGueltigBis
            // 
            this.colGueltigBis.Caption = "Gültig bis";
            this.colGueltigBis.FieldName = "DatumBis";
            this.colGueltigBis.Name = "colGueltigBis";
            this.colGueltigBis.OptionsColumn.AllowEdit = false;
            this.colGueltigBis.OptionsColumn.AllowFocus = false;
            this.colGueltigBis.OptionsColumn.ReadOnly = true;
            this.colGueltigBis.Visible = true;
            this.colGueltigBis.VisibleIndex = 6;
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigBis.Location = new System.Drawing.Point(12, 371);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(65, 24);
            this.lblGueltigBis.TabIndex = 6;
            this.lblGueltigBis.Text = "Gültig bis";
            this.lblGueltigBis.UseCompatibleTextRendering = true;
            // 
            // lblGueltigVon
            // 
            this.lblGueltigVon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigVon.Location = new System.Drawing.Point(12, 341);
            this.lblGueltigVon.Name = "lblGueltigVon";
            this.lblGueltigVon.Size = new System.Drawing.Size(75, 24);
            this.lblGueltigVon.TabIndex = 4;
            this.lblGueltigVon.Text = "Gültig von";
            this.lblGueltigVon.UseCompatibleTextRendering = true;
            // 
            // edtGueltigBis
            // 
            this.edtGueltigBis.DataMember = "DatumBis";
            this.edtGueltigBis.DataSource = this.qryKostenstellePerson;
            this.edtGueltigBis.EditValue = null;
            this.edtGueltigBis.Location = new System.Drawing.Point(92, 371);
            this.edtGueltigBis.Name = "edtGueltigBis";
            this.edtGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGueltigBis.Properties.Name = "editPeriodeBis.Properties";
            this.edtGueltigBis.Properties.ShowToday = false;
            this.edtGueltigBis.Size = new System.Drawing.Size(95, 24);
            this.edtGueltigBis.TabIndex = 7;
            // 
            // edtGueltigVon
            // 
            this.edtGueltigVon.DataMember = "DatumVon";
            this.edtGueltigVon.DataSource = this.qryKostenstellePerson;
            this.edtGueltigVon.EditValue = null;
            this.edtGueltigVon.Location = new System.Drawing.Point(92, 341);
            this.edtGueltigVon.Name = "edtGueltigVon";
            this.edtGueltigVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGueltigVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGueltigVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGueltigVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGueltigVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGueltigVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGueltigVon.Properties.Appearance.Options.UseFont = true;
            this.edtGueltigVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGueltigVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGueltigVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGueltigVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGueltigVon.Properties.Name = "editPeriodeVon.Properties";
            this.edtGueltigVon.Properties.ShowToday = false;
            this.edtGueltigVon.Size = new System.Drawing.Size(95, 24);
            this.edtGueltigVon.TabIndex = 5;
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(12, 312);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(52, 24);
            this.lblPerson.TabIndex = 2;
            this.lblPerson.Text = "Person";
            this.lblPerson.UseCompatibleTextRendering = true;
            // 
            // lblKostenstelle
            // 
            this.lblKostenstelle.Location = new System.Drawing.Point(12, 282);
            this.lblKostenstelle.Name = "lblKostenstelle";
            this.lblKostenstelle.Size = new System.Drawing.Size(75, 24);
            this.lblKostenstelle.TabIndex = 0;
            this.lblKostenstelle.Text = "Kostenstelle";
            this.lblKostenstelle.UseCompatibleTextRendering = true;
            // 
            // edtPerson
            // 
            this.edtPerson.DataMember = "NameVorname";
            this.edtPerson.DataSource = this.qryKostenstellePerson;
            this.edtPerson.Location = new System.Drawing.Point(92, 312);
            this.edtPerson.Name = "edtPerson";
            this.edtPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPerson.Size = new System.Drawing.Size(297, 24);
            this.edtPerson.TabIndex = 3;
            this.edtPerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtPerson_UserModifiedFld);
            // 
            // edtKostenstelle
            // 
            this.edtKostenstelle.DataMember = "Name";
            this.edtKostenstelle.DataSource = this.qryKostenstellePerson;
            this.edtKostenstelle.Location = new System.Drawing.Point(92, 282);
            this.edtKostenstelle.Name = "edtKostenstelle";
            this.edtKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenstelle.Size = new System.Drawing.Size(297, 24);
            this.edtKostenstelle.TabIndex = 1;
            this.edtKostenstelle.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenstelle_UserModifiedFld);
            // 
            // CtlKbKostenstelleZuweisung
            // 
            this.ActiveSQLQuery = this.qryKostenstellePerson;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblKostenstelle);
            this.Controls.Add(this.edtPerson);
            this.Controls.Add(this.edtKostenstelle);
            this.Controls.Add(this.lblGueltigBis);
            this.Controls.Add(this.lblGueltigVon);
            this.Controls.Add(this.edtGueltigBis);
            this.Controls.Add(this.edtGueltigVon);
            this.Name = "CtlKbKostenstelleZuweisung";
            this.Load += new System.EventHandler(this.CtlKbKostenstelleZuweisung_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.edtGueltigVon, 0);
            this.Controls.SetChildIndex(this.edtGueltigBis, 0);
            this.Controls.SetChildIndex(this.lblGueltigVon, 0);
            this.Controls.SetChildIndex(this.lblGueltigBis, 0);
            this.Controls.SetChildIndex(this.edtKostenstelle, 0);
            this.Controls.SetChildIndex(this.edtPerson, 0);
            this.Controls.SetChildIndex(this.lblKostenstelle, 0);
            this.Controls.SetChildIndex(this.lblPerson, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklusiveUEPersonenX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKostenstellePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenstellePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenstellePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissLabel lblKostenstelleX;
        private KiSS4.Gui.KissLabel lblUnterstuetztBisX;
        private KiSS4.Gui.KissLabel lblUnterstuetztVonX;
        private KiSS4.Gui.KissLabel lblBaPersonIDX;
        private KiSS4.Gui.KissCheckEdit edtInklusiveUEPersonenX;
        private KiSS4.Gui.KissDateEdit edtUnterstuetztBisX;
        private KiSS4.Gui.KissDateEdit edtUnterstuetztVonX;
        private KiSS4.Gui.KissButtonEdit edtBaPersonIDX;
        private KiSS4.Gui.KissTextEdit edtKostenstelleX;
        private KiSS4.DB.SqlQuery qryKostenstellePerson;
        private KiSS4.Gui.KissGrid grdKostenstellePerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKostenstellePerson;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelleNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelleName;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelleAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelleModul;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigBis;
        private KiSS4.Gui.KissLabel lblGueltigBis;
        private KiSS4.Gui.KissLabel lblGueltigVon;
        private KiSS4.Gui.KissDateEdit edtGueltigBis;
        private KiSS4.Gui.KissDateEdit edtGueltigVon;
        private KiSS4.Gui.KissLabel lblPerson;
        private KiSS4.Gui.KissLabel lblKostenstelle;
        private KiSS4.Gui.KissButtonEdit edtPerson;
        private KiSS4.Gui.KissButtonEdit edtKostenstelle;
    }
}
