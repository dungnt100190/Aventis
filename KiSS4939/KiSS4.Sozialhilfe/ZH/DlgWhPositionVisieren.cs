using System;
using System.Windows.Forms;

using KiSS4.DB;

namespace KiSS4.Sozialhilfe.ZH
{
    #region Enumerations

    public enum BewilligungAktionZH
    {
        Anfrage,
        Antwort,
        Aufheben,
        Sperren,
        SerrungAufheben
    }

    #endregion

    public class DlgWhPositionVisieren : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnAblehnen;
        private KiSS4.Gui.KissButton btnDetails;
        private KiSS4.Gui.KissButton btnVisieren;
        private System.ComponentModel.IContainer components = null;
        private DateTime dDatum;
        private KiSS4.Gui.KissMemoEdit edtMitteilung;
        private KiSS4.Gui.KissTextEdit edtSender;
        private KiSS4.Gui.KissLabel lblEmpfaenger;
        private KiSS4.Gui.KissLabel lblMitteilung;
        private KiSS4.Gui.KissLabel lblSammelposition;
        private KiSS4.Gui.KissLabel lblTitle;
        private BewilligungAktionZH m_aktion;
        private int m_bgBudgetID = 0;
        private int m_bgFinanzplanID = 0;
        private int m_bgPositionID = 0;
        private string m_herkunftClassName;
        private int receiverID;
        private string taskDescription;
        private bool userYes;

        #endregion

        #endregion

        #region Constructors

        public DlgWhPositionVisieren(int bgPositionID, string herkunftClassName)
            : this(bgPositionID, BewilligungAktionZH.Antwort, herkunftClassName)
        {
        }

        public DlgWhPositionVisieren(int bgPositionID, BewilligungAktionZH aktion, string herkunftClassName)
            : this()
        {
            m_aktion = aktion;

            //Hauptposition, Anzahl/Total bestimmen
            m_bgPositionID = bgPositionID;

            m_herkunftClassName = herkunftClassName;

            //Hauptposition, Anzahl/Total bestimmen
            SqlQuery qry2 = DBUtil.OpenSQL(@"
                declare @BgPositionID int

                -- von Detail auf Hauptposition wechseln
                select @BgPositionID = isnull(BgPositionID_Parent,BgPositionID)
                from   BgPosition
                where  BgPositionID = {0} and
                       BgKategorieCode in (100,101)

                select BgPositionID = @BgPositionID,
                       Anzahl       = count(*),
                       AnzahlZL     = sum(case when BgKategorieCode = 100 then 1 else 0 end),
                       AnzahlEZ     = sum(case when BgKategorieCode = 101 then 1 else 0 end),
                       Total        = sum(Betrag),
                       TotalZL      = sum(case when BgKategorieCode = 100 then Betrag else 0 end),
                       TotalEZ      = sum(case when BgKategorieCode = 101 then Betrag else 0 end)
                from   BgPosition
                where  BgPositionID = @BgPositionID or
                       (BgPositionID_Parent = @BgPositionID and
                        BgKategorieCode in (100,101))",
                m_bgPositionID);

            if (qry2.Count > 0 && (int)qry2["Anzahl"] > 1)
            {
                m_bgPositionID = (int)qry2["BgPositionID"];
                if ((int)qry2["AnzahlEZ"] > 0)
                    lblSammelposition.Text = string.Format(
                        "{0} Positionen, Total {1:n2} CHF\r\n" +
                        "- {2} ZL: {3:n2} CHF\r\n" +
                        "- {4} EZ: {5:n2} CHF",
                        qry2["Anzahl"], qry2["Total"],
                        qry2["AnzahlZL"], qry2["TotalZL"],
                        qry2["AnzahlEZ"], qry2["TotalEZ"]);
                else
                    lblSammelposition.Text = string.Format("{0} Positionen, Total {1:n2} CHF", qry2["Anzahl"], qry2["Total"]);

                lblSammelposition.Visible = true;
                btnDetails.Visible = true;
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                select Anfragender = USR.LastName + IsNull(', ' + USR.FirstName, ''),
                    UserIDAn = USR.UserID
                from BgBewilligung BEW
                    left join XUser USR on USR.UserID = BEW.UserID
                where BEW.BgPositionID = {0}
                and BEW.BgBewilligungCode = 1",
                m_bgPositionID);

            Datum = DateTime.Now;

            if (qry.Count > 0)
            {
                edtSender.EditValue = qry["Anfragender"].ToString();
                receiverID = (int)qry["UserIDAn"];
            }

            switch (aktion)
            {
                case BewilligungAktionZH.Antwort:
                    btnAblehnen.Text = "Ablehnen";
                    btnVisieren.Visible = true;
                    break;

                case BewilligungAktionZH.Aufheben:
                    btnAblehnen.Text = "Aufheben";
                    btnVisieren.Visible = false;
                    break;
            }
        }

        public DlgWhPositionVisieren()
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
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblEmpfaenger = new KiSS4.Gui.KissLabel();
            this.lblMitteilung = new KiSS4.Gui.KissLabel();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.btnAblehnen = new KiSS4.Gui.KissButton();
            this.btnVisieren = new KiSS4.Gui.KissButton();
            this.edtMitteilung = new KiSS4.Gui.KissMemoEdit();
            this.edtSender = new KiSS4.Gui.KissTextEdit();
            this.lblSammelposition = new KiSS4.Gui.KissLabel();
            this.btnDetails = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfaenger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSammelposition)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Visieren";
            this.lblTitle.UseCompatibleTextRendering = true;
            //
            // lblEmpfaenger
            //
            this.lblEmpfaenger.Location = new System.Drawing.Point(12, 38);
            this.lblEmpfaenger.Name = "lblEmpfaenger";
            this.lblEmpfaenger.Size = new System.Drawing.Size(185, 24);
            this.lblEmpfaenger.TabIndex = 1;
            this.lblEmpfaenger.Text = "Anfragender Mitarbeiter";
            this.lblEmpfaenger.UseCompatibleTextRendering = true;
            this.lblEmpfaenger.Visible = false;
            //
            // lblMitteilung
            //
            this.lblMitteilung.Location = new System.Drawing.Point(13, 92);
            this.lblMitteilung.Name = "lblMitteilung";
            this.lblMitteilung.Size = new System.Drawing.Size(100, 23);
            this.lblMitteilung.TabIndex = 4;
            this.lblMitteilung.Text = "Mitteilung";
            this.lblMitteilung.UseCompatibleTextRendering = true;
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(554, 262);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 5;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            //
            // btnAblehnen
            //
            this.btnAblehnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAblehnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAblehnen.Location = new System.Drawing.Point(12, 262);
            this.btnAblehnen.Name = "btnAblehnen";
            this.btnAblehnen.Size = new System.Drawing.Size(90, 24);
            this.btnAblehnen.TabIndex = 5;
            this.btnAblehnen.Text = "Ablehnen";
            this.btnAblehnen.UseCompatibleTextRendering = true;
            this.btnAblehnen.UseVisualStyleBackColor = true;
            this.btnAblehnen.Click += new System.EventHandler(this.btnAblehnen_Click);
            //
            // btnVisieren
            //
            this.btnVisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisieren.Location = new System.Drawing.Point(108, 262);
            this.btnVisieren.Name = "btnVisieren";
            this.btnVisieren.Size = new System.Drawing.Size(90, 24);
            this.btnVisieren.TabIndex = 5;
            this.btnVisieren.Text = "Visieren";
            this.btnVisieren.UseCompatibleTextRendering = true;
            this.btnVisieren.UseVisualStyleBackColor = true;
            this.btnVisieren.Click += new System.EventHandler(this.btnVisieren_Click);
            //
            // edtMitteilung
            //
            this.edtMitteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMitteilung.Location = new System.Drawing.Point(13, 118);
            this.edtMitteilung.Name = "edtMitteilung";
            this.edtMitteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung.Size = new System.Drawing.Size(631, 138);
            this.edtMitteilung.TabIndex = 6;
            //
            // edtSender
            //
            this.edtSender.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSender.Location = new System.Drawing.Point(12, 65);
            this.edtSender.Name = "edtSender";
            this.edtSender.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSender.Properties.Appearance.Options.UseBackColor = true;
            this.edtSender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSender.Properties.Appearance.Options.UseFont = true;
            this.edtSender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSender.Properties.ReadOnly = true;
            this.edtSender.Size = new System.Drawing.Size(632, 24);
            this.edtSender.TabIndex = 9;
            //
            // lblSammelposition
            //
            this.lblSammelposition.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSammelposition.ForeColor = System.Drawing.Color.Red;
            this.lblSammelposition.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSammelposition.Location = new System.Drawing.Point(255, 13);
            this.lblSammelposition.Name = "lblSammelposition";
            this.lblSammelposition.Size = new System.Drawing.Size(293, 49);
            this.lblSammelposition.TabIndex = 10;
            this.lblSammelposition.Text = "Sammelposition";
            this.lblSammelposition.UseCompatibleTextRendering = true;
            this.lblSammelposition.Visible = false;
            //
            // btnDetails
            //
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Location = new System.Drawing.Point(554, 12);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(90, 24);
            this.btnDetails.TabIndex = 14;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseCompatibleTextRendering = true;
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Visible = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            //
            // DlgWhPositionVisieren
            //
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(656, 292);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblSammelposition);
            this.Controls.Add(this.edtSender);
            this.Controls.Add(this.edtMitteilung);
            this.Controls.Add(this.btnVisieren);
            this.Controls.Add(this.btnAblehnen);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.lblMitteilung);
            this.Controls.Add(this.lblEmpfaenger);
            this.Controls.Add(this.lblTitle);
            this.Name = "DlgWhPositionVisieren";
            this.Text = "Visieren";
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfaenger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSammelposition)).EndInit();
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

        #region Properties

        public BewilligungAktionZH Aktion
        {
            get { return this.m_aktion; }
        }

        public BgBewilligungStatus BgBewilligungStatusCode
        {
            get
            {
                if (userYes)
                {
                    // Der User hat die Bewilligung visiert
                    return BgBewilligungStatus.Erteilt;
                }
                else
                {
                    switch (m_aktion)
                    {
                        case BewilligungAktionZH.Antwort:
                            // Der User hat die Bewilligung abgelehnt
                            return BgBewilligungStatus.Abgelehnt;

                        case BewilligungAktionZH.Aufheben:
                            // Der User hat die Bewilligung aufgehoben => Status geht wieder in Vorbereitung
                            return BgBewilligungStatus.InVorbereitung;

                        default:
                            // Wir sollten nie hierhinkommen...
                            return BgBewilligungStatus.InVorbereitung;
                    }
                }
            }
        }

        public DateTime Datum
        {
            get { return dDatum; }
            set { dDatum = value; }
        }

        public int ReceiverID
        {
            get { return this.receiverID; }
        }

        public string TaskDescription
        {
            get { return this.taskDescription; }
        }

        public bool UserYes
        {
            get { return this.userYes; }
        }

        #endregion

        #region EventHandlers

        private void btnAbbrechen_Click(object sender, System.EventArgs e)
        {
            this.userCancel = true;
        }

        private void btnAblehnen_Click(object sender, System.EventArgs e)
        {
            this.userCancel = false;
            this.userYes = false;

            if (!DBUtil.IsEmpty(edtMitteilung.EditValue))
                taskDescription = (string)edtMitteilung.EditValue;

            DialogResult = DialogResult.OK;
        }

        private void btnDetails_Click(object sender, System.EventArgs e)
        {
            DlgWhWeitereKOA dlg = new DlgWhWeitereKOA(m_bgPositionID, this.Name, 0, false);  //AllowEdit = false
            dlg.ShowDialog(this);
        }

        private void btnVisieren_Click(object sender, System.EventArgs e)
        {
            this.userCancel = false;
            this.userYes = true;

            if (!DBUtil.IsEmpty(edtMitteilung.EditValue))
                taskDescription = (string)edtMitteilung.EditValue;

            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void InsertBewilligungsHistory()
        {
            if (userCancel)
            {
                // Der user hat den Dialog gecancelt, raus hier
                return;
            }

            SqlQuery qryBgBewilligung = new SqlQuery();

            qryBgBewilligung.Fill("SELECT TOP 0 * FROM BgBewilligung");
            qryBgBewilligung.Insert("BgBewilligung");
            qryBgBewilligung["BgPositionID"] = m_bgPositionID;
            qryBgBewilligung["Bemerkung"] = taskDescription;
            qryBgBewilligung["ClassName"] = m_herkunftClassName;
            if (m_bgFinanzplanID > 0)
            {
                qryBgBewilligung["BgFinanzPlanID"] = m_bgFinanzplanID;
            }
            if (m_bgBudgetID > 0)
            {
                qryBgBewilligung["BgBudgetID"] = m_bgBudgetID;
            }
            if (receiverID > 0)
            {
                qryBgBewilligung["UserID_An"] = receiverID;
            }

            qryBgBewilligung["Datum"] = DateTime.Now;
            qryBgBewilligung["UserID"] = Session.User.UserID;

            switch (m_aktion)
            {
                case BewilligungAktionZH.Aufheben:
                    qryBgBewilligung["BgBewilligungCode"] = 9; // Bewilligung aufgehoben
                    break;

                default:
                    // Mappe BgBewilligungStatusCode nach BgBewilligungCode
                    switch (BgBewilligungStatusCode)
                    {
                        case BgBewilligungStatus.InVorbereitung:
                        case BgBewilligungStatus.Angefragt:
                            qryBgBewilligung["BgBewilligungCode"] = 1; // Anfrage zur Bewilligung
                            break;
                        case BgBewilligungStatus.Abgelehnt:
                            qryBgBewilligung["BgBewilligungCode"] = 3; // Bewilligung abgelehnt
                            break;
                        case BgBewilligungStatus.Erteilt:
                            qryBgBewilligung["BgBewilligungCode"] = 2; // Bewilligung erteilt
                            break;
                    }
                    break;
            }

            // Execute Insert
            qryBgBewilligung.RowModified = true;
            qryBgBewilligung.Post("BgBewilligung");
        }

        #endregion

        #endregion
    }
}