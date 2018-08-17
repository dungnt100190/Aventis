namespace KiSS4.Arbeit
{
    partial class CtlKaQJPZAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJPZAssessment));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.lblAufgIn = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.chkA = new KiSS4.Gui.KissCheckEdit();
            this.chkC = new KiSS4.Gui.KissCheckEdit();
            this.chkD = new KiSS4.Gui.KissCheckEdit();
            this.chkB = new KiSS4.Gui.KissCheckEdit();
            this.edtProjGefaehrGrund = new KiSS4.Gui.KissMemoEdit();
            this.chkProjGefaehrdet = new KiSS4.Gui.KissCheckEdit();
            this.lblProjGefaehrdet = new KiSS4.Gui.KissLabel();
            this.qryQJAssessment = new KiSS4.DB.SqlQuery(this.components);
            this.docAssessment = new KiSS4.Dokument.KissDocumentButton();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufgIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProjGefaehrGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProjGefaehrdet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProjGefaehrdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQJAssessment)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(729, 40);
            this.pnTitle.TabIndex = 2;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Assessment";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(10, 45);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(120, 24);
            this.lblDatum.TabIndex = 3;
            this.lblDatum.Text = "Datum";
            // 
            // lblAufgIn
            // 
            this.lblAufgIn.Location = new System.Drawing.Point(10, 85);
            this.lblAufgIn.Name = "lblAufgIn";
            this.lblAufgIn.Size = new System.Drawing.Size(120, 24);
            this.lblAufgIn.TabIndex = 3;
            this.lblAufgIn.Text = "Aufgenommen in";
            // 
            // edtDatum
            // 
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(134, 45);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDatum.TabIndex = 0;
            // 
            // chkA
            // 
            this.chkA.EditValue = false;
            this.chkA.Location = new System.Drawing.Point(134, 90);
            this.chkA.Name = "chkA";
            this.chkA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkA.Properties.Appearance.Options.UseBackColor = true;
            this.chkA.Properties.Caption = "A";
            this.chkA.Size = new System.Drawing.Size(124, 19);
            this.chkA.TabIndex = 1;
            // 
            // chkC
            // 
            this.chkC.EditValue = false;
            this.chkC.Location = new System.Drawing.Point(134, 115);
            this.chkC.Name = "chkC";
            this.chkC.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkC.Properties.Appearance.Options.UseBackColor = true;
            this.chkC.Properties.Caption = "C";
            this.chkC.Size = new System.Drawing.Size(124, 19);
            this.chkC.TabIndex = 2;
            // 
            // chkD
            // 
            this.chkD.EditValue = false;
            this.chkD.Location = new System.Drawing.Point(266, 115);
            this.chkD.Name = "chkD";
            this.chkD.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkD.Properties.Appearance.Options.UseBackColor = true;
            this.chkD.Properties.Caption = "D";
            this.chkD.Size = new System.Drawing.Size(124, 19);
            this.chkD.TabIndex = 4;
            // 
            // chkB
            // 
            this.chkB.EditValue = false;
            this.chkB.Location = new System.Drawing.Point(266, 90);
            this.chkB.Name = "chkB";
            this.chkB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkB.Properties.Appearance.Options.UseBackColor = true;
            this.chkB.Properties.Caption = "B";
            this.chkB.Size = new System.Drawing.Size(124, 19);
            this.chkB.TabIndex = 3;
            // 
            // edtProjGefaehrGrund
            // 
            this.edtProjGefaehrGrund.Location = new System.Drawing.Point(134, 170);
            this.edtProjGefaehrGrund.Name = "edtProjGefaehrGrund";
            this.edtProjGefaehrGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProjGefaehrGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProjGefaehrGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProjGefaehrGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtProjGefaehrGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProjGefaehrGrund.Properties.Appearance.Options.UseFont = true;
            this.edtProjGefaehrGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtProjGefaehrGrund.Size = new System.Drawing.Size(426, 70);
            this.edtProjGefaehrGrund.TabIndex = 7;
            // 
            // chkProjGefaehrdet
            // 
            this.chkProjGefaehrdet.EditValue = false;
            this.chkProjGefaehrdet.Location = new System.Drawing.Point(134, 145);
            this.chkProjGefaehrdet.Name = "chkProjGefaehrdet";
            this.chkProjGefaehrdet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkProjGefaehrdet.Properties.Appearance.Options.UseBackColor = true;
            this.chkProjGefaehrdet.Properties.Caption = "Grund";
            this.chkProjGefaehrdet.Size = new System.Drawing.Size(68, 19);
            this.chkProjGefaehrdet.TabIndex = 6;
            this.chkProjGefaehrdet.CheckedChanged += new System.EventHandler(this.chkProjGefaehrdet_CheckedChanged);
            // 
            // lblProjGefaehrdet
            // 
            this.lblProjGefaehrdet.Location = new System.Drawing.Point(10, 140);
            this.lblProjGefaehrdet.Name = "lblProjGefaehrdet";
            this.lblProjGefaehrdet.Size = new System.Drawing.Size(120, 24);
            this.lblProjGefaehrdet.TabIndex = 3;
            this.lblProjGefaehrdet.Text = "Projekt gefährdet (D)";
            // 
            // qryQJAssessment
            // 
            this.qryQJAssessment.HostControl = this;
            this.qryQJAssessment.IsIdentityInsert = false;
            this.qryQJAssessment.SelectStatement = resources.GetString("qryQJAssessment.SelectStatement");
            this.qryQJAssessment.TableName = "KaQJPZAssessment";
            // 
            // docAssessment
            // 
            this.docAssessment.Context = "KaQJAssessment";
            this.docAssessment.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.Word;
            this.docAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docAssessment.Image = ((System.Drawing.Image)(resources.GetObject("docAssessment.Image")));
            this.docAssessment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docAssessment.Location = new System.Drawing.Point(13, 253);
            this.docAssessment.Name = "docAssessment";
            this.docAssessment.Size = new System.Drawing.Size(98, 24);
            this.docAssessment.TabIndex = 10;
            this.docAssessment.Text = "Dokument";
            this.docAssessment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docAssessment.UseVisualStyleBackColor = false;
            // 
            // CtlKaQJPZAssessment
            // 
            this.ActiveSQLQuery = this.qryQJAssessment;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.docAssessment);
            this.Controls.Add(this.edtProjGefaehrGrund);
            this.Controls.Add(this.chkB);
            this.Controls.Add(this.chkProjGefaehrdet);
            this.Controls.Add(this.chkD);
            this.Controls.Add(this.chkC);
            this.Controls.Add(this.chkA);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblProjGefaehrdet);
            this.Controls.Add(this.lblAufgIn);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaQJPZAssessment";
            this.Size = new System.Drawing.Size(729, 290);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufgIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProjGefaehrGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProjGefaehrdet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProjGefaehrdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQJAssessment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.PictureBox imageTitle;
        private Gui.KissLabel lblTitle;
        private Gui.KissLabel lblDatum;
        private Gui.KissLabel lblAufgIn;
        private Gui.KissDateEdit edtDatum;
        private Gui.KissCheckEdit chkA;
        private Gui.KissCheckEdit chkC;
        private Gui.KissCheckEdit chkD;
        private Gui.KissCheckEdit chkB;
        private Gui.KissMemoEdit edtProjGefaehrGrund;
        private Gui.KissCheckEdit chkProjGefaehrdet;
        private Gui.KissLabel lblProjGefaehrdet;
        private DB.SqlQuery qryQJAssessment;
        private Dokument.KissDocumentButton docAssessment;
    }
}
