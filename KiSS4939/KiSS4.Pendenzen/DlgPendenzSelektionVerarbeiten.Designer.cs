using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Pendenzen
{
    partial class DlgPendenzSelektionVerarbeiten
    {
        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSelectedIDsCount = new KiSS4.Gui.KissLabel();
            this.edtSelectedIDsCount = new KiSS4.Gui.KissTextEdit();
            this.lblInfoPendenzen = new KiSS4.Gui.KissLabel();
            this.tabPendenzenJobs = new KiSS4.Gui.KissTabControlEx();
            this.tpgErledigen = new SharpLibrary.WinControls.TabPageEx();
            this.panAktionen = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSetBearbeitung = new KiSS4.Gui.KissButton();
            this.btnSetErledigt = new KiSS4.Gui.KissButton();
            this.lblErledigenInfo = new KiSS4.Gui.KissLabel();
            this.tpgUebergeben = new SharpLibrary.WinControls.TabPageEx();
            this.btnPendenzenUebergeben = new KiSS4.Gui.KissButton();
            this.edtUebergebenTarget = new KiSS4.Gui.KissButtonEdit();
            this.lblUebergebenTarget = new KiSS4.Gui.KissLabel();
            this.edtUebergebenSource = new KiSS4.Gui.KissButtonEdit();
            this.lblUebergebenSource = new KiSS4.Gui.KissLabel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.qryXTask = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedIDsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectedIDsCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoPendenzen)).BeginInit();
            this.tabPendenzenJobs.SuspendLayout();
            this.tpgErledigen.SuspendLayout();
            this.panAktionen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErledigenInfo)).BeginInit();
            this.tpgUebergeben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUebergebenTarget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebergebenTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUebergebenSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebergebenSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectedIDsCount
            // 
            this.lblSelectedIDsCount.Location = new System.Drawing.Point(9, 6);
            this.lblSelectedIDsCount.Name = "lblSelectedIDsCount";
            this.lblSelectedIDsCount.Size = new System.Drawing.Size(175, 24);
            this.lblSelectedIDsCount.TabIndex = 0;
            this.lblSelectedIDsCount.Text = "Anzahl selektierter Pendenzen:";
            this.lblSelectedIDsCount.UseCompatibleTextRendering = true;
            // 
            // edtSelectedIDsCount
            // 
            this.edtSelectedIDsCount.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSelectedIDsCount.EditValue = "";
            this.edtSelectedIDsCount.Location = new System.Drawing.Point(190, 6);
            this.edtSelectedIDsCount.Name = "edtSelectedIDsCount";
            this.edtSelectedIDsCount.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSelectedIDsCount.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSelectedIDsCount.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSelectedIDsCount.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelectedIDsCount.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSelectedIDsCount.Properties.Appearance.Options.UseFont = true;
            this.edtSelectedIDsCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSelectedIDsCount.Properties.ReadOnly = true;
            this.edtSelectedIDsCount.Size = new System.Drawing.Size(86, 24);
            this.edtSelectedIDsCount.TabIndex = 1;
            this.edtSelectedIDsCount.TabStop = false;
            // 
            // lblInfoPendenzen
            // 
            this.lblInfoPendenzen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoPendenzen.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblInfoPendenzen.Location = new System.Drawing.Point(9, 33);
            this.lblInfoPendenzen.Name = "lblInfoPendenzen";
            this.lblInfoPendenzen.Size = new System.Drawing.Size(558, 18);
            this.lblInfoPendenzen.TabIndex = 2;
            this.lblInfoPendenzen.Text = "Info: Je nach gewählter Tätigkeit können nicht alle Pendenzen verarbeitet werden." +
    "";
            this.lblInfoPendenzen.UseCompatibleTextRendering = true;
            // 
            // tabPendenzenJobs
            // 
            this.tabPendenzenJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPendenzenJobs.Controls.Add(this.tpgErledigen);
            this.tabPendenzenJobs.Controls.Add(this.tpgUebergeben);
            this.tabPendenzenJobs.Location = new System.Drawing.Point(9, 57);
            this.tabPendenzenJobs.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.tabPendenzenJobs.Name = "tabPendenzenJobs";
            this.tabPendenzenJobs.SelectedTabIndex = 1;
            this.tabPendenzenJobs.ShowFixedWidthTooltip = true;
            this.tabPendenzenJobs.Size = new System.Drawing.Size(558, 212);
            this.tabPendenzenJobs.TabIndex = 3;
            this.tabPendenzenJobs.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgUebergeben,
            this.tpgErledigen});
            this.tabPendenzenJobs.TabsLineColor = System.Drawing.Color.Black;
            this.tabPendenzenJobs.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabPendenzenJobs.Text = "kissTabControlEx1";
            // 
            // tpgErledigen
            // 
            this.tpgErledigen.Controls.Add(this.panAktionen);
            this.tpgErledigen.Controls.Add(this.lblErledigenInfo);
            this.tpgErledigen.Location = new System.Drawing.Point(6, 6);
            this.tpgErledigen.Name = "tpgErledigen";
            this.tpgErledigen.Padding = new System.Windows.Forms.Padding(6);
            this.tpgErledigen.Size = new System.Drawing.Size(546, 174);
            this.tpgErledigen.TabIndex = 1;
            this.tpgErledigen.Title = "Erledigen";
            // 
            // panAktionen
            // 
            this.panAktionen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAktionen.Controls.Add(this.btnSetBearbeitung);
            this.panAktionen.Controls.Add(this.btnSetErledigt);
            this.panAktionen.Location = new System.Drawing.Point(9, 40);
            this.panAktionen.Name = "panAktionen";
            this.panAktionen.Size = new System.Drawing.Size(540, 95);
            this.panAktionen.TabIndex = 26;
            // 
            // btnSetBearbeitung
            // 
            this.btnSetBearbeitung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBearbeitung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetBearbeitung.Location = new System.Drawing.Point(0, 0);
            this.btnSetBearbeitung.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.btnSetBearbeitung.Name = "btnSetBearbeitung";
            this.btnSetBearbeitung.Size = new System.Drawing.Size(100, 24);
            this.btnSetBearbeitung.TabIndex = 21;
            this.btnSetBearbeitung.Text = "in Bearbeitung";
            this.btnSetBearbeitung.UseVisualStyleBackColor = false;
            this.btnSetBearbeitung.Click += new System.EventHandler(this.btnSetBearbeitung_Click);
            // 
            // btnSetErledigt
            // 
            this.btnSetErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetErledigt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetErledigt.Location = new System.Drawing.Point(106, 0);
            this.btnSetErledigt.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.btnSetErledigt.Name = "btnSetErledigt";
            this.btnSetErledigt.Size = new System.Drawing.Size(98, 24);
            this.btnSetErledigt.TabIndex = 22;
            this.btnSetErledigt.Text = "Erledigt";
            this.btnSetErledigt.UseVisualStyleBackColor = false;
            this.btnSetErledigt.Click += new System.EventHandler(this.ActionButtonClick);
            // 
            // lblErledigenInfo
            // 
            this.lblErledigenInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErledigenInfo.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblErledigenInfo.Location = new System.Drawing.Point(9, 6);
            this.lblErledigenInfo.Name = "lblErledigenInfo";
            this.lblErledigenInfo.Size = new System.Drawing.Size(528, 18);
            this.lblErledigenInfo.TabIndex = 2;
            this.lblErledigenInfo.Text = "Die ausgewählten Pendenzen werden, wenn möglich, als erledigt markiert.";
            this.lblErledigenInfo.UseCompatibleTextRendering = true;
            // 
            // tpgUebergeben
            // 
            this.tpgUebergeben.Controls.Add(this.btnPendenzenUebergeben);
            this.tpgUebergeben.Controls.Add(this.edtUebergebenTarget);
            this.tpgUebergeben.Controls.Add(this.lblUebergebenTarget);
            this.tpgUebergeben.Controls.Add(this.edtUebergebenSource);
            this.tpgUebergeben.Controls.Add(this.lblUebergebenSource);
            this.tpgUebergeben.Location = new System.Drawing.Point(6, 6);
            this.tpgUebergeben.Name = "tpgUebergeben";
            this.tpgUebergeben.Padding = new System.Windows.Forms.Padding(6);
            this.tpgUebergeben.Size = new System.Drawing.Size(546, 174);
            this.tpgUebergeben.TabIndex = 0;
            this.tpgUebergeben.Title = "Übergeben";
            // 
            // btnPendenzenUebergeben
            // 
            this.btnPendenzenUebergeben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPendenzenUebergeben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendenzenUebergeben.Location = new System.Drawing.Point(366, 141);
            this.btnPendenzenUebergeben.Name = "btnPendenzenUebergeben";
            this.btnPendenzenUebergeben.Size = new System.Drawing.Size(171, 24);
            this.btnPendenzenUebergeben.TabIndex = 4;
            this.btnPendenzenUebergeben.Text = "Pendenzen übergeben";
            this.btnPendenzenUebergeben.UseCompatibleTextRendering = true;
            this.btnPendenzenUebergeben.UseVisualStyleBackColor = false;
            this.btnPendenzenUebergeben.Click += new System.EventHandler(this.btnPendenzenUebergeben_Click);
            // 
            // edtUebergebenTarget
            // 
            this.edtUebergebenTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUebergebenTarget.EditValue = "";
            this.edtUebergebenTarget.Location = new System.Drawing.Point(197, 36);
            this.edtUebergebenTarget.Name = "edtUebergebenTarget";
            this.edtUebergebenTarget.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUebergebenTarget.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUebergebenTarget.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUebergebenTarget.Properties.Appearance.Options.UseBackColor = true;
            this.edtUebergebenTarget.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUebergebenTarget.Properties.Appearance.Options.UseFont = true;
            this.edtUebergebenTarget.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUebergebenTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUebergebenTarget.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUebergebenTarget.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUebergebenTarget.Size = new System.Drawing.Size(340, 24);
            this.edtUebergebenTarget.TabIndex = 3;
            this.edtUebergebenTarget.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUebergebenTarget_UserModifiedFld);
            // 
            // lblUebergebenTarget
            // 
            this.lblUebergebenTarget.Location = new System.Drawing.Point(9, 36);
            this.lblUebergebenTarget.Name = "lblUebergebenTarget";
            this.lblUebergebenTarget.Size = new System.Drawing.Size(182, 24);
            this.lblUebergebenTarget.TabIndex = 2;
            this.lblUebergebenTarget.Text = "DANN Pendenzen übergeben an";
            this.lblUebergebenTarget.UseCompatibleTextRendering = true;
            // 
            // edtUebergebenSource
            // 
            this.edtUebergebenSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUebergebenSource.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUebergebenSource.EditValue = "";
            this.edtUebergebenSource.Location = new System.Drawing.Point(197, 6);
            this.edtUebergebenSource.Name = "edtUebergebenSource";
            this.edtUebergebenSource.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUebergebenSource.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUebergebenSource.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUebergebenSource.Properties.Appearance.Options.UseBackColor = true;
            this.edtUebergebenSource.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUebergebenSource.Properties.Appearance.Options.UseFont = true;
            this.edtUebergebenSource.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUebergebenSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUebergebenSource.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUebergebenSource.Properties.ReadOnly = true;
            this.edtUebergebenSource.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUebergebenSource.Size = new System.Drawing.Size(340, 24);
            this.edtUebergebenSource.TabIndex = 1;
            this.edtUebergebenSource.TabStop = false;
            this.edtUebergebenSource.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUebergebenSource_UserModifiedFld);
            // 
            // lblUebergebenSource
            // 
            this.lblUebergebenSource.Location = new System.Drawing.Point(9, 6);
            this.lblUebergebenSource.Name = "lblUebergebenSource";
            this.lblUebergebenSource.Size = new System.Drawing.Size(182, 24);
            this.lblUebergebenSource.TabIndex = 0;
            this.lblUebergebenSource.Text = "WENN Absender oder Empfänger = ";
            this.lblUebergebenSource.UseCompatibleTextRendering = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(477, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // qryXTask
            // 
            this.qryXTask.CanDelete = true;
            this.qryXTask.CanInsert = true;
            this.qryXTask.CanUpdate = true;
            this.qryXTask.TableName = "XTask";
            // 
            // DlgPendenzSelektionVerarbeiten
            // 
            this.ClientSize = new System.Drawing.Size(576, 278);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabPendenzenJobs);
            this.Controls.Add(this.lblInfoPendenzen);
            this.Controls.Add(this.edtSelectedIDsCount);
            this.Controls.Add(this.lblSelectedIDsCount);
            this.Name = "DlgPendenzSelektionVerarbeiten";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Pendenzen verarbeiten";
            this.Load += new System.EventHandler(this.DlgPendenzSelektionVerarbeiten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedIDsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectedIDsCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoPendenzen)).EndInit();
            this.tabPendenzenJobs.ResumeLayout(false);
            this.tpgErledigen.ResumeLayout(false);
            this.panAktionen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErledigenInfo)).EndInit();
            this.tpgUebergeben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUebergebenTarget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebergebenTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUebergebenSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebergebenSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnPendenzenUebergeben;
        private KiSS4.Gui.KissTextEdit edtSelectedIDsCount;
        private KiSS4.Gui.KissButtonEdit edtUebergebenSource;
        private KiSS4.Gui.KissButtonEdit edtUebergebenTarget;
        private KiSS4.Gui.KissLabel lblErledigenInfo;
        private KiSS4.Gui.KissLabel lblInfoPendenzen;
        private KiSS4.Gui.KissLabel lblSelectedIDsCount;
        private KiSS4.Gui.KissLabel lblUebergebenSource;
        private KiSS4.Gui.KissLabel lblUebergebenTarget;
        private KiSS4.Gui.KissTabControlEx tabPendenzenJobs;
        private SharpLibrary.WinControls.TabPageEx tpgErledigen;
        private SharpLibrary.WinControls.TabPageEx tpgUebergeben;
        private System.Windows.Forms.FlowLayoutPanel panAktionen;
        private Gui.KissButton btnSetErledigt;
        private DB.SqlQuery qryXTask;
        private System.ComponentModel.IContainer components;
        private Gui.KissButton btnSetBearbeitung;
    }
}
