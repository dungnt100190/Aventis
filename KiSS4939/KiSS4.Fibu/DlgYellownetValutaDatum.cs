using System;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for DlgYellownetValutaDatum.
    /// </summary>
    public class DlgYellownetValutaDatum
        :
        KiSS4.Gui.KissForm
    {
        #region GUI components

        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnOK;
        private KiSS4.Gui.KissDateEdit DtpAusfuehrungsDatum;
        private KiSS4.Gui.KissLabel kissLabel1;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgYellownetValutaDatum));
            this.DtpAusfuehrungsDatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.DtpAusfuehrungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.SuspendLayout();
            //
            // DtpAusfuehrungsDatum
            //
            this.DtpAusfuehrungsDatum.EditValue = new System.DateTime(2004, 5, 11, 0, 0, 0, 0);
            this.DtpAusfuehrungsDatum.Location = new System.Drawing.Point(157, 14);
            this.DtpAusfuehrungsDatum.Name = "DtpAusfuehrungsDatum";
            //
            // DtpAusfuehrungsDatum.Properties
            //
            this.DtpAusfuehrungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.DtpAusfuehrungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Bitmap)(resources.GetObject("resource"))), new DevExpress.Utils.ViewStyle("EditorButtonStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
																														 | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis)
																														 | DevExpress.Utils.StyleOptions.UseDrawFocusRect)
																														 | DevExpress.Utils.StyleOptions.UseFont)
																														 | DevExpress.Utils.StyleOptions.UseForeColor)
																														 | DevExpress.Utils.StyleOptions.UseHorzAlignment)
																														 | DevExpress.Utils.StyleOptions.UseImage)
																														 | DevExpress.Utils.StyleOptions.UseWordWrap)
																														 | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.Bisque, System.Drawing.SystemColors.ControlText))});
            this.DtpAusfuehrungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.DtpAusfuehrungsDatum.Properties.ShowClear = false;
            this.DtpAusfuehrungsDatum.Properties.ShowToday = false;
            this.DtpAusfuehrungsDatum.Properties.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.AliceBlue, System.Drawing.SystemColors.WindowText);
            this.DtpAusfuehrungsDatum.Properties.StyleBorder = new DevExpress.Utils.ViewStyle("ControlStyleBorder", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis)
                | DevExpress.Utils.StyleOptions.UseDrawFocusRect)
                | DevExpress.Utils.StyleOptions.UseFont)
                | DevExpress.Utils.StyleOptions.UseForeColor)
                | DevExpress.Utils.StyleOptions.UseHorzAlignment)
                | DevExpress.Utils.StyleOptions.UseImage)
                | DevExpress.Utils.StyleOptions.UseWordWrap)
                | DevExpress.Utils.StyleOptions.UseVertAlignment))), false, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.Linen, System.Drawing.SystemColors.Control);
            this.DtpAusfuehrungsDatum.Size = new System.Drawing.Size(92, 24);
            this.DtpAusfuehrungsDatum.TabIndex = 0;
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(41, 13);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(116, 24);
            this.kissLabel1.TabIndex = 1;
            this.kissLabel1.Text = "Ausführungsdatum ";
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(156, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbruch";
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(17, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(132, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            //
            // DlgYellownetValutaDatum
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 86);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.DtpAusfuehrungsDatum);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgYellownetValutaDatum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ausführungsdatum für EZAG-Aufträge";
            ((System.ComponentModel.ISupportInitialize)(this.DtpAusfuehrungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgYellownetValutaDatum"/> class.
        /// </summary>
        /// <param name="defaultDate">The default date.</param>
        public DlgYellownetValutaDatum(DateTime defaultDate)
        {
            System.Diagnostics.Debug.Assert(defaultDate != null, "defaultDate != null");

            this.InitializeComponent();

            if (defaultDate != null)
            {
                if (defaultDate != DateTime.MinValue)
                {
                    this.DtpAusfuehrungsDatum.DateTime = defaultDate;
                }
            }
        }

        /// <summary>
        /// Gets the AusfuehrungsDatum.
        /// </summary>
        /// <value>The ausfuehrungs datum.</value>
        public DateTime AusfuehrungsDatum
        {
            get
            {
                return this.DtpAusfuehrungsDatum.DateTime;
            }
        }
    }
}