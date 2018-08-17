using System;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main.PI
{
    public class DlgGeheZu : KiSS4.Gui.KissDialog
    {
        #region Fields

        private KiSS4.Gui.KissButton btnBaPersonID;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnFaLeistungID;
        private KiSS4.Gui.KissButton btnKlientenkontoNr;
        private KiSS4.Gui.KissButton btnZLEUserID;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtFaLeistungID;
        private KiSS4.Gui.KissTextEdit edtKlientenkontoNr;
        private KiSS4.Gui.KissTextEdit edtZLEUserID;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblFaLeistungID;
        private KiSS4.Gui.KissLabel lblFallbearbeitung;
        private KiSS4.Gui.KissLabel lblInfo;
        private KiSS4.Gui.KissLabel lblKlientenkontoNr;
        private KiSS4.Gui.KissLabel lblZeitleistungserfassung;
        private KiSS4.Gui.KissLabel lblZLEUserID;

        #endregion

        #region Constructors

        public DlgGeheZu()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new KiSS4.Gui.KissLabel();
            this.lblFallbearbeitung = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.btnBaPersonID = new KiSS4.Gui.KissButton();
            this.lblKlientenkontoNr = new KiSS4.Gui.KissLabel();
            this.edtKlientenkontoNr = new KiSS4.Gui.KissTextEdit();
            this.btnKlientenkontoNr = new KiSS4.Gui.KissButton();
            this.lblFaLeistungID = new KiSS4.Gui.KissLabel();
            this.edtFaLeistungID = new KiSS4.Gui.KissTextEdit();
            this.btnFaLeistungID = new KiSS4.Gui.KissButton();
            this.lblZeitleistungserfassung = new KiSS4.Gui.KissLabel();
            this.lblZLEUserID = new KiSS4.Gui.KissLabel();
            this.edtZLEUserID = new KiSS4.Gui.KissTextEdit();
            this.btnZLEUserID = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallbearbeitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientenkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistungID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitleistungserfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZLEUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZLEUserID.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // lblInfo
            //
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(267, 16);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Direktsprung zu:";
            this.lblInfo.UseCompatibleTextRendering = true;
            //
            // lblFallbearbeitung
            //
            this.lblFallbearbeitung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblFallbearbeitung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblFallbearbeitung.Location = new System.Drawing.Point(112, 40);
            this.lblFallbearbeitung.Name = "lblFallbearbeitung";
            this.lblFallbearbeitung.Size = new System.Drawing.Size(163, 16);
            this.lblFallbearbeitung.TabIndex = 1;
            this.lblFallbearbeitung.Text = "Fallbearbeitung";
            this.lblFallbearbeitung.UseCompatibleTextRendering = true;
            //
            // lblBaPersonID
            //
            this.lblBaPersonID.Location = new System.Drawing.Point(12, 59);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(94, 24);
            this.lblBaPersonID.TabIndex = 2;
            this.lblBaPersonID.Text = "Personen-Nr.";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaPersonID.Location = new System.Drawing.Point(112, 59);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBaPersonID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Mask.EditMask = "[0-9]{0,10}";
            this.edtBaPersonID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtBaPersonID.Properties.Mask.ShowPlaceHolders = false;
            this.edtBaPersonID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtBaPersonID.Properties.MaxLength = 10;
            this.edtBaPersonID.Size = new System.Drawing.Size(135, 24);
            this.edtBaPersonID.TabIndex = 3;
            //
            // btnBaPersonID
            //
            this.btnBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBaPersonID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaPersonID.IconID = 5014;
            this.btnBaPersonID.Location = new System.Drawing.Point(253, 59);
            this.btnBaPersonID.Name = "btnBaPersonID";
            this.btnBaPersonID.Size = new System.Drawing.Size(26, 24);
            this.btnBaPersonID.TabIndex = 4;
            this.btnBaPersonID.UseCompatibleTextRendering = true;
            this.btnBaPersonID.UseVisualStyleBackColor = false;
            this.btnBaPersonID.Click += new System.EventHandler(this.btnBaPersonID_Click);
            //
            // lblKlientenkontoNr
            //
            this.lblKlientenkontoNr.Location = new System.Drawing.Point(12, 89);
            this.lblKlientenkontoNr.Name = "lblKlientenkontoNr";
            this.lblKlientenkontoNr.Size = new System.Drawing.Size(94, 24);
            this.lblKlientenkontoNr.TabIndex = 5;
            this.lblKlientenkontoNr.Text = "Klientenkonto-Nr.";
            this.lblKlientenkontoNr.UseCompatibleTextRendering = true;
            //
            // edtKlientenkontoNr
            //
            this.edtKlientenkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKlientenkontoNr.Location = new System.Drawing.Point(112, 89);
            this.edtKlientenkontoNr.Name = "edtKlientenkontoNr";
            this.edtKlientenkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlientenkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientenkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientenkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientenkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientenkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtKlientenkontoNr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtKlientenkontoNr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtKlientenkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientenkontoNr.Properties.Mask.EditMask = "[0-9]{0,10}";
            this.edtKlientenkontoNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtKlientenkontoNr.Properties.Mask.ShowPlaceHolders = false;
            this.edtKlientenkontoNr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtKlientenkontoNr.Properties.MaxLength = 10;
            this.edtKlientenkontoNr.Size = new System.Drawing.Size(135, 24);
            this.edtKlientenkontoNr.TabIndex = 6;
            //
            // btnKlientenkontoNr
            //
            this.btnKlientenkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKlientenkontoNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKlientenkontoNr.IconID = 5014;
            this.btnKlientenkontoNr.Location = new System.Drawing.Point(253, 89);
            this.btnKlientenkontoNr.Name = "btnKlientenkontoNr";
            this.btnKlientenkontoNr.Size = new System.Drawing.Size(26, 24);
            this.btnKlientenkontoNr.TabIndex = 7;
            this.btnKlientenkontoNr.UseCompatibleTextRendering = true;
            this.btnKlientenkontoNr.UseVisualStyleBackColor = false;
            this.btnKlientenkontoNr.Click += new System.EventHandler(this.btnKlientenkontoNr_Click);
            //
            // lblFaLeistungID
            //
            this.lblFaLeistungID.Location = new System.Drawing.Point(12, 119);
            this.lblFaLeistungID.Name = "lblFaLeistungID";
            this.lblFaLeistungID.Size = new System.Drawing.Size(94, 24);
            this.lblFaLeistungID.TabIndex = 8;
            this.lblFaLeistungID.Text = "Prozess-Nr.";
            this.lblFaLeistungID.UseCompatibleTextRendering = true;
            //
            // edtFaLeistungID
            //
            this.edtFaLeistungID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFaLeistungID.Location = new System.Drawing.Point(112, 119);
            this.edtFaLeistungID.Name = "edtFaLeistungID";
            this.edtFaLeistungID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaLeistungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaLeistungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseFont = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseTextOptions = true;
            this.edtFaLeistungID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtFaLeistungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaLeistungID.Properties.Mask.EditMask = "[0-9]{0,10}";
            this.edtFaLeistungID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtFaLeistungID.Properties.Mask.ShowPlaceHolders = false;
            this.edtFaLeistungID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtFaLeistungID.Properties.MaxLength = 10;
            this.edtFaLeistungID.Size = new System.Drawing.Size(135, 24);
            this.edtFaLeistungID.TabIndex = 9;
            //
            // btnFaLeistungID
            //
            this.btnFaLeistungID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFaLeistungID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaLeistungID.IconID = 5014;
            this.btnFaLeistungID.Location = new System.Drawing.Point(253, 119);
            this.btnFaLeistungID.Name = "btnFaLeistungID";
            this.btnFaLeistungID.Size = new System.Drawing.Size(26, 24);
            this.btnFaLeistungID.TabIndex = 10;
            this.btnFaLeistungID.UseCompatibleTextRendering = true;
            this.btnFaLeistungID.UseVisualStyleBackColor = false;
            this.btnFaLeistungID.Click += new System.EventHandler(this.btnFaLeistungID_Click);
            //
            // lblZeitleistungserfassung
            //
            this.lblZeitleistungserfassung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblZeitleistungserfassung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZeitleistungserfassung.Location = new System.Drawing.Point(112, 162);
            this.lblZeitleistungserfassung.Name = "lblZeitleistungserfassung";
            this.lblZeitleistungserfassung.Size = new System.Drawing.Size(163, 16);
            this.lblZeitleistungserfassung.TabIndex = 11;
            this.lblZeitleistungserfassung.Text = "ZLE";
            this.lblZeitleistungserfassung.UseCompatibleTextRendering = true;
            //
            // lblZLEUserID
            //
            this.lblZLEUserID.Location = new System.Drawing.Point(12, 181);
            this.lblZLEUserID.Name = "lblZLEUserID";
            this.lblZLEUserID.Size = new System.Drawing.Size(94, 24);
            this.lblZLEUserID.TabIndex = 12;
            this.lblZLEUserID.Text = "Benutzer-Nr.";
            this.lblZLEUserID.UseCompatibleTextRendering = true;
            //
            // edtZLEUserID
            //
            this.edtZLEUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtZLEUserID.Location = new System.Drawing.Point(112, 181);
            this.edtZLEUserID.Name = "edtZLEUserID";
            this.edtZLEUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZLEUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZLEUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZLEUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtZLEUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZLEUserID.Properties.Appearance.Options.UseFont = true;
            this.edtZLEUserID.Properties.Appearance.Options.UseTextOptions = true;
            this.edtZLEUserID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtZLEUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZLEUserID.Properties.Mask.EditMask = "[0-9]{0,10}";
            this.edtZLEUserID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtZLEUserID.Properties.Mask.ShowPlaceHolders = false;
            this.edtZLEUserID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtZLEUserID.Properties.MaxLength = 10;
            this.edtZLEUserID.Size = new System.Drawing.Size(135, 24);
            this.edtZLEUserID.TabIndex = 13;
            //
            // btnZLEUserID
            //
            this.btnZLEUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZLEUserID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZLEUserID.IconID = 5014;
            this.btnZLEUserID.Location = new System.Drawing.Point(253, 181);
            this.btnZLEUserID.Name = "btnZLEUserID";
            this.btnZLEUserID.Size = new System.Drawing.Size(26, 24);
            this.btnZLEUserID.TabIndex = 14;
            this.btnZLEUserID.UseCompatibleTextRendering = true;
            this.btnZLEUserID.UseVisualStyleBackColor = false;
            this.btnZLEUserID.Click += new System.EventHandler(this.btnZLEUserID_Click);
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(191, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Abbruch";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // DlgGeheZu
            //
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(291, 275);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnZLEUserID);
            this.Controls.Add(this.edtZLEUserID);
            this.Controls.Add(this.lblZLEUserID);
            this.Controls.Add(this.lblZeitleistungserfassung);
            this.Controls.Add(this.btnFaLeistungID);
            this.Controls.Add(this.edtFaLeistungID);
            this.Controls.Add(this.lblFaLeistungID);
            this.Controls.Add(this.btnKlientenkontoNr);
            this.Controls.Add(this.edtKlientenkontoNr);
            this.Controls.Add(this.lblKlientenkontoNr);
            this.Controls.Add(this.btnBaPersonID);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.lblFallbearbeitung);
            this.Controls.Add(this.lblInfo);
            this.Name = "DlgGeheZu";
            this.Text = "Gehe zu";
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallbearbeitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientenkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistungID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitleistungserfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZLEUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZLEUserID.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Private Methods

        private void btnBaPersonID_Click(object sender, System.EventArgs e)
        {
            try
            {
                // validate value
                if (DBUtil.IsEmpty(edtBaPersonID.EditValue))
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "EmptyBaPersonID", "Bitte geben Sie eine Personen-Nr. an.");

                    // set focus
                    edtBaPersonID.Focus();

                    // cancel here
                    return;
                }

                // get entered id
                Int32 baPersonID = this.ValidateInt32(edtBaPersonID.EditValue);

                // check if entry exists
                Int32 countBaPersonID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                        WHERE PRS.BaPersonID = {0}", baPersonID));

                if (countBaPersonID < 1)
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "InvalidBaPersonID", "Die angegebene Personen-Nr. existiert nicht in der Datenbank.");

                    // set focus
                    edtBaPersonID.Focus();

                    // cancel here
                    return;
                }

                // entry is valid and can be used
                if (FormController.OpenForm("FrmFall", "Action", "ShowFall",
                                            "BaPersonID", baPersonID,
                                            "ModulID", 1))	// 1=Person
                {
                    // successfully done, close dialog
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("DlgGeheZu", "ErrorOnBtnBaPersonID", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
        }

        private void btnFaLeistungID_Click(object sender, System.EventArgs e)
        {
            try
            {
                // validate value
                if (DBUtil.IsEmpty(edtFaLeistungID.EditValue))
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "EmptyFaLeistungID", "Bitte geben Sie eine Prozess-Nr. an.");

                    // set focus
                    edtFaLeistungID.Focus();

                    // cancel here
                    return;
                }

                // get entered id
                Int32 faLeistungID = this.ValidateInt32(edtFaLeistungID.EditValue);

                // get data
                SqlQuery qryFaLeistung = DBUtil.OpenSQL(@"
                        SELECT LEI.BaPersonID,
                               LEI.ModulID
                        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                        WHERE LEI.FaLeistungID = {0}", faLeistungID);

                // check if we found item
                if (qryFaLeistung.Count < 1)
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "InvalidFaLeistungID", "Die angegebene Prozess-Nr. existiert nicht in der Datenbank.");

                    // set focus
                    edtFaLeistungID.Focus();

                    // cancel here
                    return;
                }

                // get values
                Int32 baPersonID = Convert.ToInt32(qryFaLeistung["BaPersonID"]);
                Int32 modulID = Convert.ToInt32(qryFaLeistung["ModulID"]);

                // handle invalid modulid
                if (modulID < 1)
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "InvalidFaLeistungModulID", "Die angegebene Prozess-Nr. ist ungültig (ModulID).");

                    // set focus
                    edtFaLeistungID.Focus();

                    // cancel here
                    return;
                }

                // entry is valid and can be used
                if (FormController.OpenForm("FrmFall", "Action", "ShowFall",
                                            "BaPersonID", baPersonID,
                                            "ModulID", 2))	// 2=FV
                {
                    // do it first
                    ApplicationFacade.DoEvents();

                    // set id-string (see: dbo.spXGetModulTree for further details)
                    String idString = "LEI";

                    // set module-depending id-string
                    if (modulID == 2)
                    {
                        // FV has different id-string
                        idString = "CtlFaBeratungsperiode";
                    }

                    // open FaLeistung
                    if (!FormController.SendMessage("FrmFall", "Action", "JumpToNodeByFieldValue",
                                                    "BaPersonID", baPersonID,
                                                    "ModulID", 2,
                                                    "FieldName", "ID",
                                                    "FieldValue", String.Format("{0}{1}", idString, faLeistungID)))
                    {
                        // detail could not be loaded
                        KissMsg.ShowInfo("DlgGeheZu", "CouldNotJumpToDetailFaLeistungID", "Die genaue Prozess-Nr. konnte nicht geöffnet werden.");
                    }

                    // successfully done, close dialog
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("DlgGeheZu", "ErrorOnBtnFaLeistungID", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
        }

        private void btnKlientenkontoNr_Click(object sender, System.EventArgs e)
        {
            try
            {
                // validate value
                if (DBUtil.IsEmpty(edtKlientenkontoNr.EditValue))
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "EmptyKlientenkontoNr", "Bitte geben Sie eine Klientenkonto-Nr. an.");

                    // set focus
                    edtKlientenkontoNr.Focus();

                    // cancel here
                    return;
                }

                // get entered id
                Int32 klientenkontoNr = this.ValidateInt32(edtKlientenkontoNr.EditValue);

                // get data
                SqlQuery qryBaPerson = DBUtil.OpenSQL(@"
                        SELECT PRS.BaPersonID
                        FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                        WHERE PRS.KlientenkontoNr = {0}", klientenkontoNr);

                // check if we found item
                if (qryBaPerson.Count < 1)
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "InvalidKlientenkontoNr", "Die angegebene Klientenkonto-Nr. existiert nicht in der Datenbank.");

                    // set focus
                    edtKlientenkontoNr.Focus();

                    // cancel here
                    return;
                }
                else if (qryBaPerson.Count > 1)
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "MultipleKlientenkontoNr", "Die angegebene Klientenkonto-Nr. existiert mehrfach in der Datenbank.");

                    // set focus
                    edtKlientenkontoNr.Focus();

                    // cancel here
                    return;
                }

                // get entered id
                Int32 baPersonID = Convert.ToInt32(qryBaPerson["BaPersonID"]);

                // entry is valid and can be used
                if (FormController.OpenForm("FrmFall", "Action", "ShowFall",
                                            "BaPersonID", baPersonID,
                                            "ModulID", 1))	// 1=Person
                {
                    // successfully done, close dialog
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("DlgGeheZu", "ErrorOnbtnKlientenkontoNr", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
        }

        private void btnZLEUserID_Click(object sender, System.EventArgs e)
        {
            try
            {
                // validate value
                if (DBUtil.IsEmpty(edtZLEUserID.EditValue))
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "EmptyZLEUserID", "Bitte geben Sie eine Benutzer-Nr. für die ZLE an.");

                    // set focus
                    edtZLEUserID.Focus();

                    // cancel here
                    return;
                }

                // get entered id
                Int32 userID = this.ValidateInt32(edtZLEUserID.EditValue);

                // check if entry exists
                Int32 countUserID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.XUser USR WITH (READUNCOMMITTED)
                        WHERE USR.UserID = {0}", userID));

                if (countUserID < 1)
                {
                    // show message
                    KissMsg.ShowInfo("DlgGeheZu", "InvalidZLEUserID", "Die angegebene Benutzer-Nr. existiert nicht in der Datenbank.");

                    // set focus
                    edtZLEUserID.Focus();

                    // cancel here
                    return;
                }

                // entry is valid and can be used
                if (FormController.OpenForm("FrmBDEZeiterfassung", "Action", "SelectUser",
                                            "UserID", userID))
                {
                    // successfully done, close dialog
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("DlgGeheZu", "ErrorOnBtnZLEUserID", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
        }

        private Int32 ValidateInt32(Object editValue)
        {
            // init vars and try to create an int32 of editvalue
            Int32 validInt32;
            Boolean result = Int32.TryParse(Convert.ToString(editValue), out validInt32);

            // check if object is a valid Int32
            if (result)
            {
                // is valid, return value
                return validInt32;
            }
            else
            {
                // invalid object, cannot create an Int32-number of it
                throw new ArgumentOutOfRangeException("editValue", "The given number is not a valid Int32 (max-value is: 2.147.483.647).");
            }
        }

        #endregion
    }
}