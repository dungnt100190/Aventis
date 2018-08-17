using System.Windows.Forms;

using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    public class DlgPendenzWeiterleiten : KiSS4.Gui.KissDialog
    {
        #region GUI Components
        private KiSS4.Gui.KissLabel lblReceiver;
        private KiSS4.Gui.KissButtonEdit edtReceiver;
        private KiSS4.Gui.KissLabel lblTaskDescription;
        private KiSS4.Gui.KissMemoEdit edtTaskDescription;
        private KiSS4.Gui.KissButton btnWeiterleiten;
        private KiSS4.Gui.KissButton btnCancel;
        #endregion

        #region Fields and Properties
        public object TaskReceiverCode;
        public object ReceiverID;
        public object DisplayText;

        public string TaskDescription;
        #endregion

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblReceiver = new KiSS4.Gui.KissLabel();
            this.edtReceiver = new KiSS4.Gui.KissButtonEdit();
            this.lblTaskDescription = new KiSS4.Gui.KissLabel();
            this.edtTaskDescription = new KiSS4.Gui.KissMemoEdit();
            this.btnWeiterleiten = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReceiver
            // 
            this.lblReceiver.Location = new System.Drawing.Point(12, 13);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(185, 24);
            this.lblReceiver.TabIndex = 0;
            this.lblReceiver.Text = "Weiterleiten an";
            this.lblReceiver.UseCompatibleTextRendering = true;
            // 
            // edtReceiver
            // 
            this.edtReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtReceiver.Location = new System.Drawing.Point(12, 40);
            this.edtReceiver.Name = "edtReceiver";
            this.edtReceiver.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReceiver.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReceiver.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReceiver.Properties.Appearance.Options.UseBackColor = true;
            this.edtReceiver.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReceiver.Properties.Appearance.Options.UseFont = true;
            this.edtReceiver.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtReceiver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
						new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtReceiver.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReceiver.Size = new System.Drawing.Size(508, 24);
            this.edtReceiver.TabIndex = 1;
            this.edtReceiver.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtReceiver_UserModifiedFld);
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.Location = new System.Drawing.Point(13, 67);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(100, 23);
            this.lblTaskDescription.TabIndex = 2;
            this.lblTaskDescription.Text = "Mitteilung";
            this.lblTaskDescription.UseCompatibleTextRendering = true;
            // 
            // edtTaskDescription
            // 
            this.edtTaskDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTaskDescription.EditValue = "";
            this.edtTaskDescription.Location = new System.Drawing.Point(13, 93);
            this.edtTaskDescription.Name = "edtTaskDescription";
            this.edtTaskDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTaskDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTaskDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaskDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtTaskDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTaskDescription.Properties.Appearance.Options.UseFont = true;
            this.edtTaskDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTaskDescription.Size = new System.Drawing.Size(507, 91);
            this.edtTaskDescription.TabIndex = 3;
            // 
            // btnWeiterleiten
            // 
            this.btnWeiterleiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWeiterleiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeiterleiten.Location = new System.Drawing.Point(334, 190);
            this.btnWeiterleiten.Name = "btnWeiterleiten";
            this.btnWeiterleiten.Size = new System.Drawing.Size(90, 24);
            this.btnWeiterleiten.TabIndex = 4;
            this.btnWeiterleiten.Text = "Weiterleiten";
            this.btnWeiterleiten.UseCompatibleTextRendering = true;
            this.btnWeiterleiten.UseVisualStyleBackColor = true;
            this.btnWeiterleiten.Click += new System.EventHandler(this.btnWeiterleiten_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(430, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DlgPendenzWeiterleiten
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(532, 226);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnWeiterleiten);
            this.Controls.Add(this.edtTaskDescription);
            this.Controls.Add(this.lblTaskDescription);
            this.Controls.Add(this.edtReceiver);
            this.Controls.Add(this.lblReceiver);
            this.Name = "DlgPendenzWeiterleiten";
            this.Text = "Pendenz weiterleiten";
            ((System.ComponentModel.ISupportInitialize)(this.lblReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReceiver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaskDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskDescription.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        public DlgPendenzWeiterleiten()
        {
            this.InitializeComponent();
        }

        #region edtReceiver Event Handler
        private void edtReceiver_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PendenzEmpfaengerSuchen(edtReceiver.Text, false, e.ButtonClicked);

            // if not canceled, apply values
            if (!e.Cancel)
            {
                DisplayText = dlg["DisplayText$"];
                ReceiverID = dlg["ID$"];
                TaskReceiverCode = dlg["TypeCode$"];

                edtReceiver.EditValue = DisplayText;
            }
        }
        #endregion

        #region Button Click Event Handler
        private void btnWeiterleiten_Click(object sender, System.EventArgs e)
        {
            try
            {
                DBUtil.CheckNotNullField(edtReceiver, lblReceiver.Text);

                TaskDescription = edtTaskDescription.Text;

                // close dialog
                this.DialogResult = DialogResult.OK;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
        }
        #endregion
    }
}