using System;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    public class DlgVisumAnfragen : KiSS4.Gui.KissDialog
    {
        #region Fields

        private int _faDokumenteID;
        private int _faLeistungID;
        private int _xTaskIDNew = -1;
        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnAnfragen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtReceiver;
        private KiSS4.Gui.KissMemoEdit edtTaskDescription;
        private KiSS4.Gui.KissLabel lblReceiver;
        private KiSS4.Gui.KissLabel lblTaskDescription;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.DB.SqlQuery qryXTask;

        #endregion

        #region Constructors

        public DlgVisumAnfragen(int faDokumenteID, int faLeistungID)
            : this()
        {
            _faDokumenteID = faDokumenteID;
            _faLeistungID = faLeistungID;
            qryXTask.Fill("SELECT TOP 0 * FROM dbo.XTask");
            qryXTask.Insert();
        }

        public DlgVisumAnfragen()
        {
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
            this.edtReceiver = new KiSS4.Gui.KissButtonEdit();
            this.edtTaskDescription = new KiSS4.Gui.KissMemoEdit();
            this.btnAnfragen = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblReceiver = new KiSS4.Gui.KissLabel();
            this.lblTaskDescription = new KiSS4.Gui.KissLabel();
            this.qryXTask = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).BeginInit();
            this.SuspendLayout();
            //
            // edtReceiver
            //
            this.edtReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtReceiver.Location = new System.Drawing.Point(12, 65);
            this.edtReceiver.Name = "edtReceiver";
            this.edtReceiver.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReceiver.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReceiver.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReceiver.Properties.Appearance.Options.UseBackColor = true;
            this.edtReceiver.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReceiver.Properties.Appearance.Options.UseFont = true;
            this.edtReceiver.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReceiver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtReceiver.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReceiver.Size = new System.Drawing.Size(632, 24);
            this.edtReceiver.TabIndex = 0;
            this.edtReceiver.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtReceiver_UserModifiedFld);
            //
            // edtTaskDescription
            //
            this.edtTaskDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTaskDescription.DataMember = "TaskDescription";
            this.edtTaskDescription.DataSource = this.qryXTask;
            this.edtTaskDescription.Location = new System.Drawing.Point(13, 118);
            this.edtTaskDescription.Name = "edtTaskDescription";
            this.edtTaskDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTaskDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTaskDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtTaskDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTaskDescription.Properties.Appearance.Options.UseFont = true;
            this.edtTaskDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTaskDescription.Size = new System.Drawing.Size(631, 138);
            this.edtTaskDescription.TabIndex = 1;
            //
            // btnAnfragen
            //
            this.btnAnfragen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnfragen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnfragen.Location = new System.Drawing.Point(458, 262);
            this.btnAnfragen.Name = "btnAnfragen";
            this.btnAnfragen.Size = new System.Drawing.Size(90, 24);
            this.btnAnfragen.TabIndex = 2;
            this.btnAnfragen.Text = "Anfragen";
            this.btnAnfragen.UseCompatibleTextRendering = true;
            this.btnAnfragen.UseVisualStyleBackColor = true;
            this.btnAnfragen.Click += new System.EventHandler(this.btnAnfragen_Click);
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(554, 262);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 3;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            //
            // lblTitle
            //
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 16);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Visum beantragen";
            this.lblTitle.UseCompatibleTextRendering = true;
            //
            // lblReceiver
            //
            this.lblReceiver.Location = new System.Drawing.Point(12, 38);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(279, 24);
            this.lblReceiver.TabIndex = 8;
            this.lblReceiver.Text = "Anzufragende Person oder Gruppe";
            this.lblReceiver.UseCompatibleTextRendering = true;
            //
            // lblTaskDescription
            //
            this.lblTaskDescription.Location = new System.Drawing.Point(13, 92);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(100, 23);
            this.lblTaskDescription.TabIndex = 10;
            this.lblTaskDescription.Text = "Mitteilung";
            this.lblTaskDescription.UseCompatibleTextRendering = true;
            //
            // qryXTask
            //
            this.qryXTask.CanInsert = true;
            this.qryXTask.CanUpdate = true;
            this.qryXTask.HostControl = this;
            this.qryXTask.SelectStatement = "SELECT *\r\nFROM XTask";
            this.qryXTask.TableName = "XTask";
            this.qryXTask.BeforePost += new System.EventHandler(this.qryXTask_BeforePost);
            this.qryXTask.AfterInsert += new System.EventHandler(this.qryXTask_AfterInsert);
            //
            // DlgVisumAnfragen
            //
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(656, 292);
            this.Controls.Add(this.lblTaskDescription);
            this.Controls.Add(this.lblReceiver);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnAnfragen);
            this.Controls.Add(this.edtTaskDescription);
            this.Controls.Add(this.edtReceiver);
            this.Name = "DlgVisumAnfragen";
            this.Text = "Visum beantragen";
            this.Load += new System.EventHandler(this.DlgVisumAnfragen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).EndInit();
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

        #region Public Properties

        public int NewXTaskID
        {
            get { return _xTaskIDNew; }
        }

        #endregion

        #region Private Methods

        private void btnAnfragen_Click(object sender, EventArgs e)
        {
            // save data
            qryXTask.RowModified = true;
            qryXTask.Post();

            // store new id
            _xTaskIDNew = DBUtil.IsEmpty(qryXTask["XTaskID"]) ? -1 : Convert.ToInt32(qryXTask["XTaskID"]);

            // close dialog
            DialogResult = DialogResult.OK;
        }

        private void DlgVisumAnfragen_Load(object sender, EventArgs e)
        {
            ActiveSQLQuery = null;

            SqlQuery user = DBUtil.OpenSQL("SELECT stellenleiterID, stellenleiterStvID FROM dbo.vwUser WHERE UserID = {0}", Session.User.UserID);
            SqlQuery chief = DBUtil.OpenSQL(@"
                SELECT DISTINCT TOP 1
                  ID$          = USR.UserID,
                  TypeCode$    = 1,
                  DisplayText$ = USRS.DisplayText,
                  myChief$     = CASE USR.UserID WHEN {0} THEN 2 WHEN {1} THEN 1 ELSE 0 END
                FROM dbo.vwuser                  USR
                  INNER JOIN dbo.vwUserSimple    USRS ON USRS.UserID = USR.UserID
                  LEFT JOIN dbo.XUser_UserGroup  UUG  ON UUG.UserID = USR.UserID
                  LEFT JOIN dbo.XUserGroup_Right UGR  ON UGR.UserGroupID = UUG.UserGroupID
                  LEFT JOIN dbo.XRight           XRT  ON XRT.RightID = UGR.RightID
                  LEFT JOIN dbo.XUserGroup       USG  ON USG.userGroupID = UUG.UserGroupID
                WHERE XRT.RightName = 'CtlFaDokumente_Visieren'
                  AND (USR.UserID = {0} OR USR.UserID = {1})
                ORDER BY myChief$ DESC",
                user["stellenleiterID"],
                user["stellenleiterStvID"]);

            edtReceiver.EditValue = chief["DisplayText$"];
            qryXTask["ReceiverID"] = chief["ID$"];
            qryXTask["TaskReceiverCode"] = chief["TypeCode$"];

            edtReceiver.Focus();
        }

        private void edtReceiver_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtReceiver.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            SqlQuery user = DBUtil.OpenSQL("SELECT stellenleiterID, stellenleiterStvID FROM dbo.vwUser WHERE UserID = {0}", Session.User.UserID);

            KissLookupDialog dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(searchString))
            {
                if (DBUtil.IsEmpty(searchString))
                {
                    searchString = "%";
                }

                string dotSuche = null;
                if (searchString == ".")
                {
                    searchString = "%";
                    dotSuche = "1";
                }

                e.Cancel = !dlg.SearchData(@"
                    SELECT distinct
                      Typ = 'Benutzer',
                      [Kürzel] = USR.LogonName,
                      Name = USR.NameVorname,
                      Abteilung = USR.OrgEinheitName,
                      ID$ = USR.UserID, TypeCode$ = 1,
                      DisplayText$ = USRS.DisplayText,
                      myChief$ = CASE USR.UserID WHEN {1} THEN 2 WHEN {2} THEN 1 ELSE 0 END
                    FROM dbo.vwuser                   USR
                      INNER JOIN dbo.vwUserSimple     USRS ON USRS.UserID = USR.UserID
                      LEFT  JOIN dbo.XUser_UserGroup  UUG  ON UUG.UserID = USR.UserID
                      LEFT  JOIN dbo.xUserGroup_Right UGR  ON UGR.UserGroupID = UUG.UserGroupID
                      LEFT  JOIN dbo.XRight           XRT  ON XRT.RightID = UGR.RightID
                      LEFT  JOIN dbo.XUserGroup       USG  ON USG.userGroupID = UUG.UserGroupID
                    WHERE XRT.RightName = 'CtlFaDokumente_Visieren'
                      AND USR.DisplayText LIKE '%' + {0} + '%'
                      AND ({3} IS NULL OR (USR.UserID = {1} OR USR.UserID = {2}))

            /* Momentan keine Visumsanfragen an Pendendenzgruppen
                    UNION ALL
                    SELECT 'Gruppe', NULL, Name, NULL, FaPendenzgruppeID, TypeCode$ = 2, Name, myChief$ = 0
                    FROM FaPendenzgruppe
                    WHERE Name LIKE '%' + {0} + '%'
                      AND Name NOT LIKE 'migrierte_Grp_%'
            */
                    ORDER BY TypeCode$ ASC, myChief$ DESC, Name
                    ", searchString, e.ButtonClicked, user["stellenleiterID"], user["stellenleiterStvID"], dotSuche);

                if (e.Cancel) return;
            }

            edtReceiver.EditValue = dlg["DisplayText$"];
            qryXTask["ReceiverID"] = dlg["ID$"];
            qryXTask["TaskReceiverCode"] = dlg["TypeCode$"];
        }

        private void qryXTask_AfterInsert(object sender, EventArgs e)
        {
            qryXTask["TaskStatusCode"] = 1; // Pendent

            qryXTask["TaskTypeCode"] = 2; // Visum
            qryXTask["Subject"] = "Visum für ein Dokument"; // Betreff der Pendenz

            qryXTask["SenderID"] = Session.User.UserID;
            qryXTask["TaskSenderCode"] = 1; // Person
            qryXTask["FaLeistungID"] = _faLeistungID;
            qryXTask["FaDokumenteID"] = _faDokumenteID;

            qryXTask["CreateDate"] = DateTime.Now;
            qryXTask["ExpirationDate"] = DateTime.Now;
        }

        private void qryXTask_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtReceiver, lblReceiver.Text);
        }

        #endregion
    }
}