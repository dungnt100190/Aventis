#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using System.Drawing;

namespace KiSS4.Fallfuehrung.ZH
{
    public class CtlFaLoesungsprozess : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private System.ComponentModel.IContainer components;
        private int faLeistungID = -1;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaLoesungsprozess;

        #endregion

        #region Constructors

        public CtlFaLoesungsprozess()
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
            this.components = new System.ComponentModel.Container();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.qryFaLoesungsprozess = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLoesungsprozess)).BeginInit();
            this.SuspendLayout();
            //
            // kissLabel1
            //
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel1.Location = new System.Drawing.Point(114, 172);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(316, 18);
            this.kissLabel1.TabIndex = 0;
            this.kissLabel1.Text = "Übersichtsdarstellung des Lösungsprozesses";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // kissLabel7
            //
            this.kissLabel7.Location = new System.Drawing.Point(114, 198);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(256, 24);
            this.kissLabel7.TabIndex = 17;
            this.kissLabel7.Text = "(wird vom SD noch definiert)";
            this.kissLabel7.UseCompatibleTextRendering = true;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 24);
            this.panel1.TabIndex = 30;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Lösungsprozess";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // qryFaLoesungsprozess
            //
            this.qryFaLoesungsprozess.HostControl = this;
            this.qryFaLoesungsprozess.SelectStatement = "select null";
            this.qryFaLoesungsprozess.TableName = "FaLoesungsprozess";
            //
            // CtlFaLoesungsprozess
            //
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.kissLabel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "CtlFaLoesungsprozess";
            this.Size = new System.Drawing.Size(600, 456);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLoesungsprozess)).EndInit();
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

        #region Public Methods

        public void Init(string Name, Image TitleImage, int LeistungID)
        {
            lblTitel.Text = Name;
              picTitel.Image = TitleImage;
              faLeistungID = LeistungID;

              // Daten anzeigen:
              qryFaLoesungsprozess.Fill(faLeistungID);
        }

        #endregion
    }
}