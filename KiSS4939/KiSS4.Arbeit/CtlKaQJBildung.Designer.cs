namespace KiSS4.Arbeit
{
    partial class CtlKaQJBildung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJBildung));
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.chkKursBewerbung = new KiSS4.Gui.KissCheckEdit();
            this.qryKaQJBildung = new KiSS4.DB.SqlQuery(this.components);
            this.lblBesuchteKurse = new KiSS4.Gui.KissLabel();
            this.lblKursBewerbung = new KiSS4.Gui.KissLabel();
            this.chkKursInformatik = new KiSS4.Gui.KissCheckEdit();
            this.lblKursInformatik = new KiSS4.Gui.KissLabel();
            this.edtKursCustom1 = new KiSS4.Gui.KissTextEdit();
            this.chkKursCustom1 = new KiSS4.Gui.KissCheckEdit();
            this.chkKursVideo = new KiSS4.Gui.KissCheckEdit();
            this.lblKursVideo = new KiSS4.Gui.KissLabel();
            this.chkKursWissen = new KiSS4.Gui.KissCheckEdit();
            this.lblKursWissen = new KiSS4.Gui.KissLabel();
            this.edtKursCustom2 = new KiSS4.Gui.KissTextEdit();
            this.chkKursCustom2 = new KiSS4.Gui.KissCheckEdit();
            this.edtKursCustom3 = new KiSS4.Gui.KissTextEdit();
            this.chkKursCustom3 = new KiSS4.Gui.KissCheckEdit();
            this.edtKursCustom4 = new KiSS4.Gui.KissTextEdit();
            this.chkKursCustom4 = new KiSS4.Gui.KissCheckEdit();
            this.edtKursCustom5 = new KiSS4.Gui.KissTextEdit();
            this.chkKursCustom5 = new KiSS4.Gui.KissCheckEdit();
            this.edtKursCustom6 = new KiSS4.Gui.KissTextEdit();
            this.chkKursCustom6 = new KiSS4.Gui.KissCheckEdit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursBewerbung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaQJBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBesuchteKurse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursBewerbung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursInformatik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursInformatik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursVideo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursWissen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursWissen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom6.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(705, 40);
            this.pnTitle.TabIndex = 1;
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
            this.lblTitle.Text = "Bildung";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // chkKursBewerbung
            // 
            this.chkKursBewerbung.DataSource = this.qryKaQJBildung;
            this.chkKursBewerbung.EditValue = false;
            this.chkKursBewerbung.Location = new System.Drawing.Point(10, 65);
            this.chkKursBewerbung.Name = "chkKursBewerbung";
            this.chkKursBewerbung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursBewerbung.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursBewerbung.Properties.Caption = "";
            this.chkKursBewerbung.Size = new System.Drawing.Size(25, 19);
            this.chkKursBewerbung.TabIndex = 0;
            // 
            // qryKaQJBildung
            // 
            this.qryKaQJBildung.CanUpdate = true;
            this.qryKaQJBildung.HostControl = this;
            this.qryKaQJBildung.IsIdentityInsert = false;
            this.qryKaQJBildung.SelectStatement = resources.GetString("qryKaQJBildung.SelectStatement");
            this.qryKaQJBildung.TableName = "KaQJBildung";
            this.qryKaQJBildung.BeforePost += new System.EventHandler(this.qryKaQJBildung_BeforePost);
            // 
            // lblBesuchteKurse
            // 
            this.lblBesuchteKurse.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblBesuchteKurse.Location = new System.Drawing.Point(10, 42);
            this.lblBesuchteKurse.Name = "lblBesuchteKurse";
            this.lblBesuchteKurse.Size = new System.Drawing.Size(175, 16);
            this.lblBesuchteKurse.TabIndex = 3;
            this.lblBesuchteKurse.Text = "Besuchte Kurse";
            // 
            // lblKursBewerbung
            // 
            this.lblKursBewerbung.Location = new System.Drawing.Point(41, 62);
            this.lblKursBewerbung.Margin = new System.Windows.Forms.Padding(3);
            this.lblKursBewerbung.Name = "lblKursBewerbung";
            this.lblKursBewerbung.Size = new System.Drawing.Size(303, 24);
            this.lblKursBewerbung.TabIndex = 4;
            this.lblKursBewerbung.Text = "Bewerbungskurs";
            // 
            // chkKursInformatik
            // 
            this.chkKursInformatik.EditValue = false;
            this.chkKursInformatik.Location = new System.Drawing.Point(10, 95);
            this.chkKursInformatik.Name = "chkKursInformatik";
            this.chkKursInformatik.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursInformatik.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursInformatik.Properties.Caption = "";
            this.chkKursInformatik.Size = new System.Drawing.Size(25, 19);
            this.chkKursInformatik.TabIndex = 1;
            // 
            // lblKursInformatik
            // 
            this.lblKursInformatik.Location = new System.Drawing.Point(41, 92);
            this.lblKursInformatik.Margin = new System.Windows.Forms.Padding(3);
            this.lblKursInformatik.Name = "lblKursInformatik";
            this.lblKursInformatik.Size = new System.Drawing.Size(303, 24);
            this.lblKursInformatik.TabIndex = 4;
            this.lblKursInformatik.Text = "Informatikkurs";
            // 
            // edtKursCustom1
            // 
            this.edtKursCustom1.Location = new System.Drawing.Point(44, 182);
            this.edtKursCustom1.Name = "edtKursCustom1";
            this.edtKursCustom1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursCustom1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursCustom1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursCustom1.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursCustom1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursCustom1.Properties.Appearance.Options.UseFont = true;
            this.edtKursCustom1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursCustom1.Size = new System.Drawing.Size(300, 24);
            this.edtKursCustom1.TabIndex = 5;
            // 
            // chkKursCustom1
            // 
            this.chkKursCustom1.EditValue = false;
            this.chkKursCustom1.Location = new System.Drawing.Point(10, 185);
            this.chkKursCustom1.Name = "chkKursCustom1";
            this.chkKursCustom1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursCustom1.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursCustom1.Properties.Caption = "";
            this.chkKursCustom1.Size = new System.Drawing.Size(25, 19);
            this.chkKursCustom1.TabIndex = 4;
            // 
            // chkKursVideo
            // 
            this.chkKursVideo.EditValue = false;
            this.chkKursVideo.Location = new System.Drawing.Point(10, 125);
            this.chkKursVideo.Name = "chkKursVideo";
            this.chkKursVideo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursVideo.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursVideo.Properties.Caption = "";
            this.chkKursVideo.Size = new System.Drawing.Size(25, 19);
            this.chkKursVideo.TabIndex = 2;
            // 
            // lblKursVideo
            // 
            this.lblKursVideo.Location = new System.Drawing.Point(41, 122);
            this.lblKursVideo.Margin = new System.Windows.Forms.Padding(3);
            this.lblKursVideo.Name = "lblKursVideo";
            this.lblKursVideo.Size = new System.Drawing.Size(303, 24);
            this.lblKursVideo.TabIndex = 4;
            this.lblKursVideo.Text = "Videokurs";
            // 
            // chkKursWissen
            // 
            this.chkKursWissen.EditValue = false;
            this.chkKursWissen.Location = new System.Drawing.Point(10, 155);
            this.chkKursWissen.Name = "chkKursWissen";
            this.chkKursWissen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursWissen.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursWissen.Properties.Caption = "";
            this.chkKursWissen.Size = new System.Drawing.Size(25, 19);
            this.chkKursWissen.TabIndex = 3;
            // 
            // lblKursWissen
            // 
            this.lblKursWissen.Location = new System.Drawing.Point(41, 152);
            this.lblKursWissen.Margin = new System.Windows.Forms.Padding(3);
            this.lblKursWissen.Name = "lblKursWissen";
            this.lblKursWissen.Size = new System.Drawing.Size(303, 24);
            this.lblKursWissen.TabIndex = 4;
            this.lblKursWissen.Text = "Allg. Wissen im Alltag";
            // 
            // edtKursCustom2
            // 
            this.edtKursCustom2.Location = new System.Drawing.Point(44, 212);
            this.edtKursCustom2.Name = "edtKursCustom2";
            this.edtKursCustom2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursCustom2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursCustom2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursCustom2.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursCustom2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursCustom2.Properties.Appearance.Options.UseFont = true;
            this.edtKursCustom2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursCustom2.Size = new System.Drawing.Size(300, 24);
            this.edtKursCustom2.TabIndex = 7;
            // 
            // chkKursCustom2
            // 
            this.chkKursCustom2.EditValue = false;
            this.chkKursCustom2.Location = new System.Drawing.Point(10, 215);
            this.chkKursCustom2.Name = "chkKursCustom2";
            this.chkKursCustom2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursCustom2.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursCustom2.Properties.Caption = "";
            this.chkKursCustom2.Size = new System.Drawing.Size(25, 19);
            this.chkKursCustom2.TabIndex = 6;
            // 
            // edtKursCustom3
            // 
            this.edtKursCustom3.Location = new System.Drawing.Point(44, 242);
            this.edtKursCustom3.Name = "edtKursCustom3";
            this.edtKursCustom3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursCustom3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursCustom3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursCustom3.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursCustom3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursCustom3.Properties.Appearance.Options.UseFont = true;
            this.edtKursCustom3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursCustom3.Size = new System.Drawing.Size(300, 24);
            this.edtKursCustom3.TabIndex = 9;
            // 
            // chkKursCustom3
            // 
            this.chkKursCustom3.EditValue = false;
            this.chkKursCustom3.Location = new System.Drawing.Point(10, 245);
            this.chkKursCustom3.Name = "chkKursCustom3";
            this.chkKursCustom3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursCustom3.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursCustom3.Properties.Caption = "";
            this.chkKursCustom3.Size = new System.Drawing.Size(25, 19);
            this.chkKursCustom3.TabIndex = 8;
            // 
            // edtKursCustom4
            // 
            this.edtKursCustom4.Location = new System.Drawing.Point(44, 272);
            this.edtKursCustom4.Name = "edtKursCustom4";
            this.edtKursCustom4.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursCustom4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursCustom4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursCustom4.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursCustom4.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursCustom4.Properties.Appearance.Options.UseFont = true;
            this.edtKursCustom4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursCustom4.Size = new System.Drawing.Size(300, 24);
            this.edtKursCustom4.TabIndex = 11;
            // 
            // chkKursCustom4
            // 
            this.chkKursCustom4.EditValue = false;
            this.chkKursCustom4.Location = new System.Drawing.Point(10, 275);
            this.chkKursCustom4.Name = "chkKursCustom4";
            this.chkKursCustom4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursCustom4.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursCustom4.Properties.Caption = "";
            this.chkKursCustom4.Size = new System.Drawing.Size(25, 19);
            this.chkKursCustom4.TabIndex = 10;
            // 
            // edtKursCustom5
            // 
            this.edtKursCustom5.Location = new System.Drawing.Point(44, 302);
            this.edtKursCustom5.Name = "edtKursCustom5";
            this.edtKursCustom5.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursCustom5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursCustom5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursCustom5.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursCustom5.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursCustom5.Properties.Appearance.Options.UseFont = true;
            this.edtKursCustom5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursCustom5.Size = new System.Drawing.Size(300, 24);
            this.edtKursCustom5.TabIndex = 13;
            // 
            // chkKursCustom5
            // 
            this.chkKursCustom5.EditValue = false;
            this.chkKursCustom5.Location = new System.Drawing.Point(10, 305);
            this.chkKursCustom5.Name = "chkKursCustom5";
            this.chkKursCustom5.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursCustom5.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursCustom5.Properties.Caption = "";
            this.chkKursCustom5.Size = new System.Drawing.Size(25, 19);
            this.chkKursCustom5.TabIndex = 12;
            // 
            // edtKursCustom6
            // 
            this.edtKursCustom6.Location = new System.Drawing.Point(44, 332);
            this.edtKursCustom6.Name = "edtKursCustom6";
            this.edtKursCustom6.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursCustom6.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursCustom6.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursCustom6.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursCustom6.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursCustom6.Properties.Appearance.Options.UseFont = true;
            this.edtKursCustom6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursCustom6.Size = new System.Drawing.Size(300, 24);
            this.edtKursCustom6.TabIndex = 15;
            // 
            // chkKursCustom6
            // 
            this.chkKursCustom6.EditValue = false;
            this.chkKursCustom6.Location = new System.Drawing.Point(10, 335);
            this.chkKursCustom6.Name = "chkKursCustom6";
            this.chkKursCustom6.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKursCustom6.Properties.Appearance.Options.UseBackColor = true;
            this.chkKursCustom6.Properties.Caption = "";
            this.chkKursCustom6.Size = new System.Drawing.Size(25, 19);
            this.chkKursCustom6.TabIndex = 14;
            // 
            // CtlKaQJBildung
            // 
            this.ActiveSQLQuery = this.qryKaQJBildung;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.chkKursCustom6);
            this.Controls.Add(this.chkKursCustom5);
            this.Controls.Add(this.chkKursCustom4);
            this.Controls.Add(this.chkKursCustom3);
            this.Controls.Add(this.chkKursCustom2);
            this.Controls.Add(this.chkKursCustom1);
            this.Controls.Add(this.edtKursCustom6);
            this.Controls.Add(this.edtKursCustom5);
            this.Controls.Add(this.edtKursCustom4);
            this.Controls.Add(this.edtKursCustom3);
            this.Controls.Add(this.edtKursCustom2);
            this.Controls.Add(this.edtKursCustom1);
            this.Controls.Add(this.lblKursWissen);
            this.Controls.Add(this.lblKursVideo);
            this.Controls.Add(this.chkKursWissen);
            this.Controls.Add(this.lblKursInformatik);
            this.Controls.Add(this.chkKursVideo);
            this.Controls.Add(this.lblKursBewerbung);
            this.Controls.Add(this.chkKursInformatik);
            this.Controls.Add(this.lblBesuchteKurse);
            this.Controls.Add(this.chkKursBewerbung);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaQJBildung";
            this.Size = new System.Drawing.Size(705, 435);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursBewerbung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaQJBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBesuchteKurse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursBewerbung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursInformatik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursInformatik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursVideo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursWissen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursWissen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursCustom6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKursCustom6.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.PictureBox imageTitle;
        private Gui.KissLabel lblTitle;
        private Gui.KissCheckEdit chkKursBewerbung;
        private Gui.KissLabel lblBesuchteKurse;
        private Gui.KissLabel lblKursBewerbung;
        private Gui.KissCheckEdit chkKursInformatik;
        private Gui.KissLabel lblKursInformatik;
        private Gui.KissTextEdit edtKursCustom1;
        private Gui.KissCheckEdit chkKursCustom1;
        private Gui.KissCheckEdit chkKursVideo;
        private Gui.KissLabel lblKursVideo;
        private Gui.KissCheckEdit chkKursWissen;
        private Gui.KissLabel lblKursWissen;
        private Gui.KissTextEdit edtKursCustom2;
        private Gui.KissCheckEdit chkKursCustom2;
        private Gui.KissTextEdit edtKursCustom3;
        private Gui.KissCheckEdit chkKursCustom3;
        private Gui.KissTextEdit edtKursCustom4;
        private Gui.KissCheckEdit chkKursCustom4;
        private Gui.KissTextEdit edtKursCustom5;
        private Gui.KissCheckEdit chkKursCustom5;
        private Gui.KissTextEdit edtKursCustom6;
        private Gui.KissCheckEdit chkKursCustom6;
        private DB.SqlQuery qryKaQJBildung;
    }
}
