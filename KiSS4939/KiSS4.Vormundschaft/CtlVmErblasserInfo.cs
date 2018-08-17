using System.ComponentModel;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmErblasserInfo.
    /// </summary>
    public class CtlVmErblasserInfo : KissComplexControl
    {
        private System.ComponentModel.IContainer components;
        private int faLeistungID = 0;
        private KiSS4.Gui.KissLabel lblErblasser;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblGeburtsdatum1;
        private KiSS4.Gui.KissLabel lblMT;
        private KiSS4.Gui.KissLabel lblMT1;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblName1;
        private KiSS4.Gui.KissLabel lblTodesdatum;
        private KiSS4.Gui.KissLabel lblTodesdatum1;
        private KiSS4.Gui.KissLabel lblVormundMassnahme;
        private KiSS4.Gui.KissLabel lblVormundMassnahme1;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissLabel lblVorname1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.DB.SqlQuery qryVmErblasserInfo;

        public CtlVmErblasserInfo()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        [Browsable(false)]
        [DefaultValue(-1)]
        public int FaLeistungID
        {
            get { return faLeistungID; }
            set
            {
                faLeistungID = value;
                qryVmErblasserInfo.Fill(@"
					SELECT Name = ERB.FamilienNamen,
                           Vorname = ERB.Vornamen,
                           ERB.Geburtsdatum,
                           Todesdatum = convert(varchar,ERB.Todesdatum,104),
                           VormundMassnahme = dbo.fnLOVTextListe('VmZGB',ZGBCodes),
                           MT = CASE WHEN USR.UserID IS NOT NULL THEN USR.LastName + isnull(', ' + USR.FirstName,'')
                                     ELSE VPM.Name + isnull(', ' + VPM.Vorname,'') + ' (PriMa)'
                                END
					FROM FaLeistung FAL
                      LEFT JOIN VmErblasser ERB ON ERB.FaLeistungID = FAL.FaLeistungID
                      LEFT JOIN FaLeistung FAL2 ON FAL2.BaPersonID = FAL.BaPersonID
                                       AND FAL2.ModulID = 5
                                       AND FAL2.FaProzessCode = 501
                                       AND FAL2.FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                                FROM FaLeistung
                                                                WHERE BaPersonID = FAL.BaPersonID
                                                                  AND ModulID = 5
                                                                  AND FaProzessCode = 501
                                                                ORDER BY DatumVon DESC)
                      LEFT JOIN VmMassnahme VMN ON VMN.FaLeistungID = FAL2.FaLeistungID
                                               AND VMN.DatumVon = (SELECT MAX(DatumVon)
                                                                   FROM VmMassnahme
                                                                   WHERE FaLeistungID = FAL2.FaLeistungID)
                      LEFT JOIN VmErnennung VEN ON VEN.VmMassnahmeID = VMN.VmMassnahmeID
                                               AND VEN.VmErnennungID = (SELECT TOP 1 VmErnennungID
                                                                        FROM VmErnennung
                                                                        WHERE VmMassnahmeID = VMN.VmMassnahmeID
																	    ORDER BY Ernennung DESC)
                      LEFT  JOIN XUser      USR  ON USR.UserID = VEN.UserID
                      LEFT  JOIN VmPriMa    VPM  ON VPM.VmPriMaID = VEN.VmPriMaID
					WHERE ERB.FaLeistungID = {0}",
                    faLeistungID);
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.qryVmErblasserInfo = new KiSS4.DB.SqlQuery(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblErblasser = new KiSS4.Gui.KissLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMT1 = new KiSS4.Gui.KissLabel();
            this.lblVormundMassnahme1 = new KiSS4.Gui.KissLabel();
            this.lblMT = new KiSS4.Gui.KissLabel();
            this.lblVormundMassnahme = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum1 = new KiSS4.Gui.KissLabel();
            this.lblTodesdatum1 = new KiSS4.Gui.KissLabel();
            this.lblVorname1 = new KiSS4.Gui.KissLabel();
            this.lblName1 = new KiSS4.Gui.KissLabel();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.lblTodesdatum = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErblasserInfo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErblasser)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVormundMassnahme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVormundMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesdatum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            this.SuspendLayout();
            //
            // qryVmErblasserInfo
            //
            this.qryVmErblasserInfo.HostControl = this;
            //
            // panel1
            //
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblErblasser);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 19);
            this.panel1.TabIndex = 659;
            //
            // lblErblasser
            //
            this.lblErblasser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErblasser.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErblasser.Location = new System.Drawing.Point(2, 1);
            this.lblErblasser.Name = "lblErblasser";
            this.lblErblasser.Size = new System.Drawing.Size(86, 14);
            this.lblErblasser.TabIndex = 35;
            this.lblErblasser.Text = "Erblasser/-in";
            //
            // panel2
            //
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblMT1);
            this.panel2.Controls.Add(this.lblVormundMassnahme1);
            this.panel2.Controls.Add(this.lblMT);
            this.panel2.Controls.Add(this.lblVormundMassnahme);
            this.panel2.Controls.Add(this.lblGeburtsdatum);
            this.panel2.Controls.Add(this.lblGeburtsdatum1);
            this.panel2.Controls.Add(this.lblTodesdatum1);
            this.panel2.Controls.Add(this.lblVorname1);
            this.panel2.Controls.Add(this.lblName1);
            this.panel2.Controls.Add(this.lblVorname);
            this.panel2.Controls.Add(this.lblTodesdatum);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Location = new System.Drawing.Point(2, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 91);
            this.panel2.TabIndex = 658;
            //
            // lblMT1
            //
            this.lblMT1.DataMember = "MT";
            this.lblMT1.DataSource = this.qryVmErblasserInfo;
            this.lblMT1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblMT1.Location = new System.Drawing.Point(477, 25);
            this.lblMT1.Name = "lblMT1";
            this.lblMT1.Size = new System.Drawing.Size(188, 22);
            this.lblMT1.TabIndex = 667;
            //
            // lblVormundMassnahme1
            //
            this.lblVormundMassnahme1.DataMember = "VormundMassnahme";
            this.lblVormundMassnahme1.DataSource = this.qryVmErblasserInfo;
            this.lblVormundMassnahme1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblVormundMassnahme1.Location = new System.Drawing.Point(477, 5);
            this.lblVormundMassnahme1.Name = "lblVormundMassnahme1";
            this.lblVormundMassnahme1.Size = new System.Drawing.Size(188, 22);
            this.lblVormundMassnahme1.TabIndex = 666;
            //
            // lblMT
            //
            this.lblMT.AutoSize = true;
            this.lblMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMT.ForeColor = System.Drawing.Color.Black;
            this.lblMT.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMT.Location = new System.Drawing.Point(352, 27);
            this.lblMT.Name = "lblMT";
            this.lblMT.Size = new System.Drawing.Size(91, 13);
            this.lblMT.TabIndex = 665;
            this.lblMT.Text = "Mandatsträger/-in";
            //
            // lblVormundMassnahme
            //
            this.lblVormundMassnahme.AutoSize = true;
            this.lblVormundMassnahme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVormundMassnahme.ForeColor = System.Drawing.Color.Black;
            this.lblVormundMassnahme.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblVormundMassnahme.Location = new System.Drawing.Point(352, 7);
            this.lblVormundMassnahme.Name = "lblVormundMassnahme";
            this.lblVormundMassnahme.Size = new System.Drawing.Size(112, 13);
            this.lblVormundMassnahme.TabIndex = 664;
            this.lblVormundMassnahme.Text = "Vormund. Massnahme";
            //
            // lblGeburtsdatum
            //
            this.lblGeburtsdatum.AutoSize = true;
            this.lblGeburtsdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.lblGeburtsdatum.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGeburtsdatum.Location = new System.Drawing.Point(5, 47);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(73, 13);
            this.lblGeburtsdatum.TabIndex = 663;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            //
            // lblGeburtsdatum1
            //
            this.lblGeburtsdatum1.DataMember = "Geburtsdatum";
            this.lblGeburtsdatum1.DataSource = this.qryVmErblasserInfo;
            this.lblGeburtsdatum1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblGeburtsdatum1.Location = new System.Drawing.Point(90, 45);
            this.lblGeburtsdatum1.Name = "lblGeburtsdatum1";
            this.lblGeburtsdatum1.Size = new System.Drawing.Size(254, 22);
            this.lblGeburtsdatum1.TabIndex = 660;
            //
            // lblTodesdatum1
            //
            this.lblTodesdatum1.DataMember = "Todesdatum";
            this.lblTodesdatum1.DataSource = this.qryVmErblasserInfo;
            this.lblTodesdatum1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTodesdatum1.Location = new System.Drawing.Point(90, 65);
            this.lblTodesdatum1.Name = "lblTodesdatum1";
            this.lblTodesdatum1.Size = new System.Drawing.Size(255, 22);
            this.lblTodesdatum1.TabIndex = 659;
            //
            // lblVorname1
            //
            this.lblVorname1.DataMember = "Vorname";
            this.lblVorname1.DataSource = this.qryVmErblasserInfo;
            this.lblVorname1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblVorname1.Location = new System.Drawing.Point(90, 25);
            this.lblVorname1.Name = "lblVorname1";
            this.lblVorname1.Size = new System.Drawing.Size(251, 22);
            this.lblVorname1.TabIndex = 657;
            //
            // lblName1
            //
            this.lblName1.DataMember = "Name";
            this.lblName1.DataSource = this.qryVmErblasserInfo;
            this.lblName1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblName1.Location = new System.Drawing.Point(90, 5);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(250, 22);
            this.lblName1.TabIndex = 656;
            //
            // lblVorname
            //
            this.lblVorname.AutoSize = true;
            this.lblVorname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVorname.ForeColor = System.Drawing.Color.Black;
            this.lblVorname.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblVorname.Location = new System.Drawing.Point(5, 27);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(49, 13);
            this.lblVorname.TabIndex = 655;
            this.lblVorname.Text = "Vorname";
            //
            // lblTodesdatum
            //
            this.lblTodesdatum.AutoSize = true;
            this.lblTodesdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodesdatum.ForeColor = System.Drawing.Color.Black;
            this.lblTodesdatum.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTodesdatum.Location = new System.Drawing.Point(5, 67);
            this.lblTodesdatum.Name = "lblTodesdatum";
            this.lblTodesdatum.Size = new System.Drawing.Size(66, 13);
            this.lblTodesdatum.TabIndex = 654;
            this.lblTodesdatum.Text = "Todesdatum";
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblName.Location = new System.Drawing.Point(5, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 652;
            this.lblName.Text = "Name";
            //
            // CtlVmErblasserInfo
            //
            this.ActiveSQLQuery = this.qryVmErblasserInfo;

            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "CtlVmErblasserInfo";
            this.Size = new System.Drawing.Size(652, 116);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErblasserInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErblasser)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVormundMassnahme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVormundMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesdatum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}