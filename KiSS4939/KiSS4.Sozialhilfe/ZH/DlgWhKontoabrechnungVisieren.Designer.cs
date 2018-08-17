using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Sozialhilfe.ZH
{
    partial class DlgWhKontoabrechnungVisieren
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgWhKontoabrechnungVisieren));
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblEmpfaenger = new KiSS4.Gui.KissLabel();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.btnVisieren = new KiSS4.Gui.KissButton();
            this.btnAblehnen = new KiSS4.Gui.KissButton();
            this.edtSender = new KiSS4.Gui.KissTextEdit();
            this.qryAnfrage = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfaenger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAnfrage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Visieren";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // lblEmpfaenger
            // 
            this.lblEmpfaenger.Location = new System.Drawing.Point(12, 35);
            this.lblEmpfaenger.Name = "lblEmpfaenger";
            this.lblEmpfaenger.Size = new System.Drawing.Size(185, 24);
            this.lblEmpfaenger.TabIndex = 1;
            this.lblEmpfaenger.Text = "Anfragender Mitarbeiter";
            this.lblEmpfaenger.UseCompatibleTextRendering = true;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(343, 116);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 5;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // btnVisieren
            // 
            this.btnVisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisieren.Location = new System.Drawing.Point(108, 116);
            this.btnVisieren.Name = "btnVisieren";
            this.btnVisieren.Size = new System.Drawing.Size(90, 24);
            this.btnVisieren.TabIndex = 4;
            this.btnVisieren.Text = "Visieren";
            this.btnVisieren.UseCompatibleTextRendering = true;
            this.btnVisieren.UseVisualStyleBackColor = true;
            this.btnVisieren.Click += new System.EventHandler(this.btnVisieren_Click);
            // 
            // btnAblehnen
            // 
            this.btnAblehnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAblehnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAblehnen.Location = new System.Drawing.Point(12, 116);
            this.btnAblehnen.Name = "btnAblehnen";
            this.btnAblehnen.Size = new System.Drawing.Size(90, 24);
            this.btnAblehnen.TabIndex = 3;
            this.btnAblehnen.Text = "Ablehnen";
            this.btnAblehnen.UseCompatibleTextRendering = true;
            this.btnAblehnen.UseVisualStyleBackColor = true;
            this.btnAblehnen.Click += new System.EventHandler(this.btnAblehnen_Click);
            // 
            // edtSender
            // 
            this.edtSender.DataMember = "UserVon_NameVorname";
            this.edtSender.DataSource = this.qryAnfrage;
            this.edtSender.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSender.Location = new System.Drawing.Point(12, 62);
            this.edtSender.Name = "edtSender";
            this.edtSender.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSender.Properties.Appearance.Options.UseBackColor = true;
            this.edtSender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSender.Properties.Appearance.Options.UseFont = true;
            this.edtSender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSender.Properties.ReadOnly = true;
            this.edtSender.Size = new System.Drawing.Size(424, 24);
            this.edtSender.TabIndex = 2;
            // 
            // qryAnfrage
            // 
            this.qryAnfrage.CanUpdate = true;
            this.qryAnfrage.SelectStatement = resources.GetString("qryAnfrage.SelectStatement");
            this.qryAnfrage.TableName = "WhAbrechnung";
            this.qryAnfrage.BeforePost += new System.EventHandler(this.qryAnfrage_BeforePost);
            // 
            // DlgWhKontoabrechnungVisieren
            // 
            this.AcceptButton = this.btnVisieren;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(445, 149);
            this.Controls.Add(this.edtSender);
            this.Controls.Add(this.btnAblehnen);
            this.Controls.Add(this.btnVisieren);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.lblEmpfaenger);
            this.Controls.Add(this.lblTitle);
            this.Name = "DlgWhKontoabrechnungVisieren";
            this.Load += new System.EventHandler(this.DlgWhKontoabrechnungVisieren_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfaenger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAnfrage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnAblehnen;
        private KiSS4.Gui.KissButton btnVisieren;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtSender;
        private KiSS4.Gui.KissLabel lblEmpfaenger;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.DB.SqlQuery qryAnfrage;
    }
}
