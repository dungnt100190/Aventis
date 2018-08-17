namespace KiSS4.Pendenzen
{
    using KiSS4.DB;

    public partial class DlgPendenzErfassen 
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnErfassen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtCreateDate;
        private KiSS4.Gui.KissDateEdit edtExpirationDate;
        private KiSS4.Gui.KissButtonEdit edtReceiverID;
        private KiSS4.Gui.KissTextEdit edtSubject;
        private KiSS4.Gui.KissMemoEdit edtTaskDescription;
        private KiSS4.Gui.KissLookUpEdit edtTaskTypeCode;
        private KiSS4.Gui.KissLabel lblCreateDate;
        private KiSS4.Gui.KissLabel lblExpirationDate;
        private KiSS4.Gui.KissLabel lblReceiverID;
        private KiSS4.Gui.KissLabel lblSubject;
        private KiSS4.Gui.KissLabel lblTaskDescription;
        private KiSS4.Gui.KissLabel lblTaskTypeCode;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.DB.SqlQuery qryXTask;

        #endregion

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgPendenzErfassen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblTaskTypeCode = new KiSS4.Gui.KissLabel();
            this.edtTaskTypeCode = new KiSS4.Gui.KissLookUpEdit();
            this.qryXTask = new KiSS4.DB.SqlQuery(this.components);
            this.lblSubject = new KiSS4.Gui.KissLabel();
            this.edtSubject = new KiSS4.Gui.KissTextEdit();
            this.lblTaskDescription = new KiSS4.Gui.KissLabel();
            this.edtTaskDescription = new KiSS4.Gui.KissMemoEdit();
            this.lblReceiverID = new KiSS4.Gui.KissLabel();
            this.edtReceiverID = new KiSS4.Gui.KissButtonEdit();
            this.lblExpirationDate = new KiSS4.Gui.KissLabel();
            this.edtExpirationDate = new KiSS4.Gui.KissDateEdit();
            this.btnErfassen = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.lblCreateDate = new KiSS4.Gui.KissLabel();
            this.edtCreateDate = new KiSS4.Gui.KissDateEdit();
            this.qryTaskType = new KiSS4.DB.SqlQuery(this.components);
            this.edtFallLeistungBetrifftPerson = new KiSS4.Pendenzen.CtlFallLeistungBetrifftPerson();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiverID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiverID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExpirationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreateDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTaskType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(8, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(585, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Neue Pendenz";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // lblTaskTypeCode
            // 
            this.lblTaskTypeCode.Location = new System.Drawing.Point(9, 35);
            this.lblTaskTypeCode.Name = "lblTaskTypeCode";
            this.lblTaskTypeCode.Size = new System.Drawing.Size(108, 24);
            this.lblTaskTypeCode.TabIndex = 1;
            this.lblTaskTypeCode.Text = "Typ";
            this.lblTaskTypeCode.UseCompatibleTextRendering = true;
            // 
            // edtTaskTypeCode
            // 
            this.edtTaskTypeCode.AllowNull = false;
            this.edtTaskTypeCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTaskTypeCode.DataMember = "TaskTypeCode";
            this.edtTaskTypeCode.DataSource = this.qryXTask;
            this.edtTaskTypeCode.Location = new System.Drawing.Point(123, 35);
            this.edtTaskTypeCode.LOVFilter = "Value3 IS NULL";
            this.edtTaskTypeCode.LOVFilterWhereAppend = true;
            this.edtTaskTypeCode.LOVName = "TaskType";
            this.edtTaskTypeCode.Name = "edtTaskTypeCode";
            this.edtTaskTypeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTaskTypeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTaskTypeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskTypeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtTaskTypeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTaskTypeCode.Properties.Appearance.Options.UseFont = true;
            this.edtTaskTypeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTaskTypeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskTypeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTaskTypeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTaskTypeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtTaskTypeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtTaskTypeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTaskTypeCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtTaskTypeCode.Properties.DisplayMember = "Text";
            this.edtTaskTypeCode.Properties.NullText = "";
            this.edtTaskTypeCode.Properties.ShowFooter = false;
            this.edtTaskTypeCode.Properties.ShowHeader = false;
            this.edtTaskTypeCode.Properties.ValueMember = "Code";
            this.edtTaskTypeCode.Size = new System.Drawing.Size(470, 24);
            this.edtTaskTypeCode.TabIndex = 2;
            this.edtTaskTypeCode.EditValueChanged += new System.EventHandler(this.edtTaskTypeCode_EditValueChanged);
            // 
            // qryXTask
            // 
            this.qryXTask.CanInsert = true;
            this.qryXTask.CanUpdate = true;
            this.qryXTask.HostControl = this;
            this.qryXTask.SelectStatement = "SELECT \r\n  FaFall = \'\', \r\n  * \r\nFROM dbo.XTask WHERE 1=2;";
            this.qryXTask.TableName = "XTask";
            this.qryXTask.AfterInsert += new System.EventHandler(this.qryXTask_AfterInsert);
            this.qryXTask.BeforePost += new System.EventHandler(this.qryXTask_BeforePost);
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(9, 65);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(108, 24);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Betreff";
            this.lblSubject.UseCompatibleTextRendering = true;
            // 
            // edtSubject
            // 
            this.edtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSubject.DataMember = "Subject";
            this.edtSubject.DataSource = this.qryXTask;
            this.edtSubject.Location = new System.Drawing.Point(123, 65);
            this.edtSubject.Name = "edtSubject";
            this.edtSubject.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSubject.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSubject.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSubject.Properties.Appearance.Options.UseBackColor = true;
            this.edtSubject.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSubject.Properties.Appearance.Options.UseFont = true;
            this.edtSubject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSubject.Properties.Name = "kissTextEdit1.Properties";
            this.edtSubject.Size = new System.Drawing.Size(470, 24);
            this.edtSubject.TabIndex = 4;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.Location = new System.Drawing.Point(9, 95);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(108, 24);
            this.lblTaskDescription.TabIndex = 5;
            this.lblTaskDescription.Text = "Beschreibung";
            this.lblTaskDescription.UseCompatibleTextRendering = true;
            // 
            // edtTaskDescription
            // 
            this.edtTaskDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTaskDescription.DataMember = "TaskDescription";
            this.edtTaskDescription.DataSource = this.qryXTask;
            this.edtTaskDescription.Location = new System.Drawing.Point(123, 95);
            this.edtTaskDescription.Name = "edtTaskDescription";
            this.edtTaskDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTaskDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTaskDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtTaskDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTaskDescription.Properties.Appearance.Options.UseFont = true;
            this.edtTaskDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTaskDescription.Size = new System.Drawing.Size(470, 95);
            this.edtTaskDescription.TabIndex = 6;
            // 
            // lblReceiverID
            // 
            this.lblReceiverID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceiverID.Location = new System.Drawing.Point(9, 196);
            this.lblReceiverID.Name = "lblReceiverID";
            this.lblReceiverID.Size = new System.Drawing.Size(108, 24);
            this.lblReceiverID.TabIndex = 7;
            this.lblReceiverID.Text = "Empfänger";
            this.lblReceiverID.UseCompatibleTextRendering = true;
            // 
            // edtReceiverID
            // 
            this.edtReceiverID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtReceiverID.Location = new System.Drawing.Point(123, 196);
            this.edtReceiverID.Name = "edtReceiverID";
            this.edtReceiverID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReceiverID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReceiverID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReceiverID.Properties.Appearance.Options.UseBackColor = true;
            this.edtReceiverID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReceiverID.Properties.Appearance.Options.UseFont = true;
            this.edtReceiverID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtReceiverID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtReceiverID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReceiverID.Size = new System.Drawing.Size(266, 24);
            this.edtReceiverID.TabIndex = 8;
            this.edtReceiverID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtReceiverID_UserModifiedFld);
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpirationDate.Location = new System.Drawing.Point(407, 226);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(90, 24);
            this.lblExpirationDate.TabIndex = 12;
            this.lblExpirationDate.Text = "Fällig";
            this.lblExpirationDate.UseCompatibleTextRendering = true;
            // 
            // edtExpirationDate
            // 
            this.edtExpirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExpirationDate.DataMember = "ExpirationDate";
            this.edtExpirationDate.DataSource = this.qryXTask;
            this.edtExpirationDate.EditValue = null;
            this.edtExpirationDate.Location = new System.Drawing.Point(503, 226);
            this.edtExpirationDate.Name = "edtExpirationDate";
            this.edtExpirationDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExpirationDate.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExpirationDate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExpirationDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExpirationDate.Properties.Appearance.Options.UseBackColor = true;
            this.edtExpirationDate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExpirationDate.Properties.Appearance.Options.UseFont = true;
            this.edtExpirationDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtExpirationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExpirationDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtExpirationDate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExpirationDate.Properties.ShowToday = false;
            this.edtExpirationDate.Size = new System.Drawing.Size(90, 24);
            this.edtExpirationDate.TabIndex = 13;
            // 
            // btnErfassen
            // 
            this.btnErfassen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErfassen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfassen.Location = new System.Drawing.Point(407, 286);
            this.btnErfassen.Name = "btnErfassen";
            this.btnErfassen.Size = new System.Drawing.Size(90, 24);
            this.btnErfassen.TabIndex = 14;
            this.btnErfassen.Text = "Erfassen";
            this.btnErfassen.UseCompatibleTextRendering = true;
            this.btnErfassen.UseVisualStyleBackColor = false;
            this.btnErfassen.Click += new System.EventHandler(this.btnErfassen_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(503, 286);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 15;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateDate.Location = new System.Drawing.Point(407, 196);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(90, 24);
            this.lblCreateDate.TabIndex = 10;
            this.lblCreateDate.Text = "Erfasst";
            this.lblCreateDate.UseCompatibleTextRendering = true;
            // 
            // edtCreateDate
            // 
            this.edtCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtCreateDate.DataMember = "CreateDate";
            this.edtCreateDate.DataSource = this.qryXTask;
            this.edtCreateDate.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCreateDate.EditValue = null;
            this.edtCreateDate.Location = new System.Drawing.Point(503, 196);
            this.edtCreateDate.Name = "edtCreateDate";
            this.edtCreateDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtCreateDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCreateDate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCreateDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCreateDate.Properties.Appearance.Options.UseBackColor = true;
            this.edtCreateDate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCreateDate.Properties.Appearance.Options.UseFont = true;
            this.edtCreateDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtCreateDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCreateDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtCreateDate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCreateDate.Properties.ReadOnly = true;
            this.edtCreateDate.Properties.ShowToday = false;
            this.edtCreateDate.Size = new System.Drawing.Size(90, 24);
            this.edtCreateDate.TabIndex = 11;
            this.edtCreateDate.TabStop = false;
            // 
            // qryTaskType
            // 
            this.qryTaskType.HostControl = this;
            this.qryTaskType.SelectStatement = resources.GetString("qryTaskType.SelectStatement");
            // 
            // edtFallLeistungBetrifftPerson
            // 
            this.edtFallLeistungBetrifftPerson.ActiveSQLQuery = this.qryXTask;
            this.edtFallLeistungBetrifftPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFallLeistungBetrifftPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFallLeistungBetrifftPerson.DataSource = this.qryXTask;
            this.edtFallLeistungBetrifftPerson.Location = new System.Drawing.Point(9, 226);
            this.edtFallLeistungBetrifftPerson.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.edtFallLeistungBetrifftPerson.Name = "edtFallLeistungBetrifftPerson";
            this.edtFallLeistungBetrifftPerson.Size = new System.Drawing.Size(380, 84);
            this.edtFallLeistungBetrifftPerson.TabIndex = 9;
            // 
            // DlgPendenzErfassen
            // 
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(600, 318);
            this.Controls.Add(this.edtFallLeistungBetrifftPerson);
            this.Controls.Add(this.edtCreateDate);
            this.Controls.Add(this.lblCreateDate);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnErfassen);
            this.Controls.Add(this.edtExpirationDate);
            this.Controls.Add(this.lblExpirationDate);
            this.Controls.Add(this.edtReceiverID);
            this.Controls.Add(this.lblReceiverID);
            this.Controls.Add(this.edtTaskDescription);
            this.Controls.Add(this.lblTaskDescription);
            this.Controls.Add(this.edtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.edtTaskTypeCode);
            this.Controls.Add(this.lblTaskTypeCode);
            this.Controls.Add(this.lblTitle);
            this.Name = "DlgPendenzErfassen";
            this.Text = KissMsg.GetMLMessage("DlgPendenzErfassen", "dlgPendenzErfassenTitle", "Pendenz erfassen");
            this.Load += new System.EventHandler(this.DlgPendenzErfassen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiverID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiverID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExpirationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreateDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTaskType)).EndInit();
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

        private DB.SqlQuery qryTaskType;
        private CtlFallLeistungBetrifftPerson edtFallLeistungBetrifftPerson;
    }
}