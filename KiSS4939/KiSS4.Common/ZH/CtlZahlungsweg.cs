#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using Kiss.Interfaces.UI;
using KiSS4.Gui;

namespace KiSS4.Common.ZH
{
    public class CtlZahlungsweg : KiSS4.Gui.KissComplexControl
    {
        #region Fields

        private KiSS4.Gui.KissButtonEdit btnEditSearch;
        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblSuchbegriff;
        private KiSS4.Gui.KissLabel lblZahlungsweg;
        private KiSS4.Gui.KissMemoEdit memoKreditor;
        private KiSS4.Gui.KissMemoEdit memoZahlungsweg;

        #endregion

        #region Constructors

        public CtlZahlungsweg()
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
            this.lblSuchbegriff = new KiSS4.Gui.KissLabel();
            this.btnEditSearch = new KiSS4.Gui.KissButtonEdit();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.memoKreditor = new KiSS4.Gui.KissMemoEdit();
            this.lblZahlungsweg = new KiSS4.Gui.KissLabel();
            this.memoZahlungsweg = new KiSS4.Gui.KissMemoEdit();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchbegriff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoZahlungsweg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // lblSuchbegriff
            //
            this.lblSuchbegriff.Location = new System.Drawing.Point(0, 0);
            this.lblSuchbegriff.Name = "lblSuchbegriff";
            this.lblSuchbegriff.Size = new System.Drawing.Size(60, 24);
            this.lblSuchbegriff.TabIndex = 0;
            this.lblSuchbegriff.Text = "Suchbegriff";
            this.lblSuchbegriff.UseCompatibleTextRendering = true;
            //
            // btnEditSearch
            //
            this.btnEditSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSearch.Location = new System.Drawing.Point(68, 0);
            this.btnEditSearch.Name = "btnEditSearch";
            this.btnEditSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEditSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.btnEditSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnEditSearch.Properties.Appearance.Options.UseBackColor = true;
            this.btnEditSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.btnEditSearch.Properties.Appearance.Options.UseFont = true;
            this.btnEditSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnEditSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(),
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.btnEditSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEditSearch.Size = new System.Drawing.Size(330, 24);
            this.btnEditSearch.TabIndex = 1;
            //
            // lblKreditor
            //
            this.lblKreditor.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblKreditor.Location = new System.Drawing.Point(0, 28);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(100, 16);
            this.lblKreditor.TabIndex = 2;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            //
            // memoKreditor
            //
            this.memoKreditor.EditMode = EditModeType.ReadOnly;
            this.memoKreditor.Location = new System.Drawing.Point(0, 44);
            this.memoKreditor.Name = "memoKreditor";
            this.memoKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memoKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memoKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memoKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.memoKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.memoKreditor.Properties.Appearance.Options.UseFont = true;
            this.memoKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memoKreditor.Properties.ReadOnly = true;
            this.memoKreditor.Size = new System.Drawing.Size(398, 93);
            this.memoKreditor.TabIndex = 3;
            //
            // lblZahlungsweg
            //
            this.lblZahlungsweg.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblZahlungsweg.Location = new System.Drawing.Point(413, 28);
            this.lblZahlungsweg.Name = "lblZahlungsweg";
            this.lblZahlungsweg.Size = new System.Drawing.Size(100, 16);
            this.lblZahlungsweg.TabIndex = 4;
            this.lblZahlungsweg.Text = "Zahlungsweg";
            this.lblZahlungsweg.UseCompatibleTextRendering = true;
            //
            // memoZahlungsweg
            //
            this.memoZahlungsweg.EditMode = EditModeType.ReadOnly;
            this.memoZahlungsweg.Location = new System.Drawing.Point(413, 44);
            this.memoZahlungsweg.Name = "memoZahlungsweg";
            this.memoZahlungsweg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memoZahlungsweg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memoZahlungsweg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memoZahlungsweg.Properties.Appearance.Options.UseBackColor = true;
            this.memoZahlungsweg.Properties.Appearance.Options.UseBorderColor = true;
            this.memoZahlungsweg.Properties.Appearance.Options.UseFont = true;
            this.memoZahlungsweg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memoZahlungsweg.Properties.ReadOnly = true;
            this.memoZahlungsweg.Size = new System.Drawing.Size(398, 93);
            this.memoZahlungsweg.TabIndex = 5;
            //
            // chkAktiv
            //
            this.chkAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAktiv.EditMode = EditModeType.ReadOnly;
            this.chkAktiv.EditValue = "False";
            this.chkAktiv.Location = new System.Drawing.Point(759, 5);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = "aktiv";
            this.chkAktiv.Properties.ReadOnly = true;
            this.chkAktiv.Size = new System.Drawing.Size(52, 19);
            this.chkAktiv.TabIndex = 6;
            //
            // CtlZahlungsweg
            //
            this.Controls.Add(this.chkAktiv);
            this.Controls.Add(this.memoZahlungsweg);
            this.Controls.Add(this.lblZahlungsweg);
            this.Controls.Add(this.memoKreditor);
            this.Controls.Add(this.lblKreditor);
            this.Controls.Add(this.btnEditSearch);
            this.Controls.Add(this.lblSuchbegriff);
            this.Name = "CtlZahlungsweg";
            this.Size = new System.Drawing.Size(818, 142);
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchbegriff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoZahlungsweg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Public Properties

        public EditModeType EditMode
        {
            get { return this.btnEditSearch.EditMode; }
            set { this.btnEditSearch.EditMode = value; }
        }

        #endregion
    }
}