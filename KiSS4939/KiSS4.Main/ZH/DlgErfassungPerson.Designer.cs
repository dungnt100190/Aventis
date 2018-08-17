
namespace KiSS4.Main.ZH
{
    public partial class DlgErfassungPerson
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.btnNeuePerson = new KiSS4.Gui.KissButton();
            this.edtBaRelationID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBeziehung = new KiSS4.Gui.KissLabel();
            this.ctlSuchePerson = new KiSS4.Main.ZH.CtlSuchePerson();
            this.qryBaPersonRelation = new KiSS4.DB.SqlQuery(this.components);
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPersonRelation)).BeginInit();
            this.SuspendLayout();
            //
            // pnBottom
            //
            this.pnBottom.Controls.Add(this.lblBeziehung);
            this.pnBottom.Controls.Add(this.edtBaRelationID);
            this.pnBottom.Controls.Add(this.btnNeuePerson);
            this.pnBottom.Controls.Add(this.btnAbbrechen);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 566);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(964, 76);
            this.pnBottom.TabIndex = 0;
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(865, 40);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 7;
            this.btnAbbrechen.Text = "Abbruch";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            //
            // btnNeuePerson
            //
            this.btnNeuePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuePerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuePerson.Location = new System.Drawing.Point(769, 40);
            this.btnNeuePerson.Name = "btnNeuePerson";
            this.btnNeuePerson.Size = new System.Drawing.Size(90, 24);
            this.btnNeuePerson.TabIndex = 8;
            this.btnNeuePerson.Text = "neue Person";
            this.btnNeuePerson.UseCompatibleTextRendering = true;
            this.btnNeuePerson.UseVisualStyleBackColor = false;
            this.btnNeuePerson.Click += new System.EventHandler(this.btnNeuePerson_Click);
            //
            // edtBeziehung
            //
            this.edtBaRelationID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaRelationID.Location = new System.Drawing.Point(563, 3);
            this.edtBaRelationID.Name = "edtBeziehung";
            this.edtBaRelationID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaRelationID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaRelationID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaRelationID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaRelationID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaRelationID.Properties.Appearance.Options.UseFont = true;
            this.edtBaRelationID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaRelationID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtBaRelationID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaRelationID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBaRelationID.Properties.DisplayMember = "Text";
            this.edtBaRelationID.Properties.NullText = "";
            this.edtBaRelationID.Properties.ShowFooter = false;
            this.edtBaRelationID.Properties.ShowHeader = false;
            this.edtBaRelationID.Properties.ValueMember = "Code";
            this.edtBaRelationID.Size = new System.Drawing.Size(393, 24);
            this.edtBaRelationID.TabIndex = 10;
            //
            // lblBeziehung
            //
            this.lblBeziehung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeziehung.Location = new System.Drawing.Point(411, 3);
            this.lblBeziehung.Name = "lblBeziehung";
            this.lblBeziehung.Size = new System.Drawing.Size(146, 24);
            this.lblBeziehung.TabIndex = 11;
            this.lblBeziehung.Text = "Beziehung zu Fallträger/-in";
            this.lblBeziehung.UseCompatibleTextRendering = true;
            //
            // ctlSuchePerson
            //
            this.ctlSuchePerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlSuchePerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSuchePerson.Location = new System.Drawing.Point(0, 0);
            this.ctlSuchePerson.Name = "ctlSuchePerson";
            this.ctlSuchePerson.Size = new System.Drawing.Size(964, 566);
            this.ctlSuchePerson.TabIndex = 1;
            //
            // qryBaPersonRelation
            //
            this.qryBaPersonRelation.CanInsert = true;
            this.qryBaPersonRelation.HostControl = this;
            this.qryBaPersonRelation.TableName = "BaPerson_Relation";
            //
            // DlgErfassungPerson
            //
            this.ClientSize = new System.Drawing.Size(964, 642);
            this.Controls.Add(this.ctlSuchePerson);
            this.Controls.Add(this.pnBottom);
            this.Name = "DlgErfassungPerson";
            this.Text = "Neue Person";
            this.Load += new System.EventHandler(this.DlgErfassungPerson_Load);
            this.pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPersonRelation)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnNeuePerson;
        private System.ComponentModel.IContainer components;
        private KiSS4.Main.ZH.CtlSuchePerson ctlSuchePerson;
        private KiSS4.Gui.KissLookUpEdit edtBaRelationID;
        private KiSS4.Gui.KissLabel lblBeziehung;
        private System.Windows.Forms.Panel pnBottom;
        private KiSS4.DB.SqlQuery qryBaPersonRelation;
    }
}