namespace KiSS4.Pendenzen
{
    partial class CtlFrmPendenzenVerwaltung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFrmPendenzenVerwaltung));
            this.itmMeineInBearbeitung = new DevExpress.XtraNavBar.NavBarItem();
            this.itmMeineErhalten = new DevExpress.XtraNavBar.NavBarItem();
            this.itmMeineErledigt = new DevExpress.XtraNavBar.NavBarItem();
            this.itmMeineErstellt = new DevExpress.XtraNavBar.NavBarItem();
            this.itmMeineFaellig = new DevExpress.XtraNavBar.NavBarItem();
            this.itmMeineGruppe = new DevExpress.XtraNavBar.NavBarItem();
            this.itmMeineOffen = new DevExpress.XtraNavBar.NavBarItem();
            this.itmMeineZuVisieren = new DevExpress.XtraNavBar.NavBarItem();
            this.itmSuche = new DevExpress.XtraNavBar.NavBarItem();
            this.itmVersandteAllgemein = new DevExpress.XtraNavBar.NavBarItem();
            this.itmVersandteErledigt = new DevExpress.XtraNavBar.NavBarItem();
            this.itmVersandteFaellig = new DevExpress.XtraNavBar.NavBarItem();
            this.itmVersandteGruppe = new DevExpress.XtraNavBar.NavBarItem();
            this.itmVersandteOffen = new DevExpress.XtraNavBar.NavBarItem();
            this.itmVersandteZuVisieren = new DevExpress.XtraNavBar.NavBarItem();
            this.nbgOwnTaks = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbgCreatedTasks = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbgSearchTasks = new DevExpress.XtraNavBar.NavBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(417, 25);
            this.lblTitle.TabIndex = 0;
            // 
            // navBar
            // 
            this.navBar.ActiveGroup = this.nbgOwnTaks;
            this.navBar.Appearance.Background.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.navBar.Appearance.Background.Options.UseBackColor = true;
            this.navBar.Appearance.GroupBackground.BackColor = System.Drawing.Color.Lavender;
            this.navBar.Appearance.GroupBackground.Options.UseBackColor = true;
            this.navBar.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemDisabled.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navBar.Appearance.ItemHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemPressed.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemPressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemPressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgOwnTaks,
            this.nbgCreatedTasks,
            this.nbgSearchTasks});
            this.navBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.itmSuche,
            this.itmMeineFaellig,
            this.itmMeineOffen,
            this.itmMeineInBearbeitung,
            this.itmMeineErstellt,
            this.itmMeineErhalten,
            this.itmMeineZuVisieren,
            this.itmMeineGruppe,
            this.itmMeineErledigt,
            this.itmVersandteFaellig,
            this.itmVersandteErledigt,
            this.itmVersandteGruppe,
            this.itmVersandteZuVisieren,
            this.itmVersandteAllgemein,
            this.itmVersandteOffen});
            this.navBar.Size = new System.Drawing.Size(189, 670);
            this.navBar.TabIndex = 0;
            // 
            // panDetail
            // 
            this.panDetail.Dock = System.Windows.Forms.DockStyle.None;
            this.panDetail.Location = new System.Drawing.Point(184, 29);
            this.panDetail.Size = new System.Drawing.Size(724, 641);
            this.panDetail.TabIndex = 1;
            // 
            // panTitle
            // 
            this.panTitle.Location = new System.Drawing.Point(192, 0);
            this.panTitle.Size = new System.Drawing.Size(728, 29);
            this.panTitle.TabIndex = 0;
            // 
            // splitterNavControl
            // 
            this.splitterNavControl.Location = new System.Drawing.Point(189, 0);
            this.splitterNavControl.Size = new System.Drawing.Size(3, 670);
            this.splitterNavControl.TabIndex = 1;
            // 
            // itmMeineInBearbeitung
            // 
            this.itmMeineInBearbeitung.Caption = "in Bearbeitung ({0})";
            this.itmMeineInBearbeitung.Name = "itmMeineInBearbeitung";
            this.itmMeineInBearbeitung.SmallImageIndex = 26;
            this.itmMeineInBearbeitung.Tag = "TaskReceiverCode = 1 AND ReceiverID = {0} AND TaskStatusCode IN (2)";
            // 
            // itmMeineErhalten
            // 
            this.itmMeineErhalten.Caption = "erhaltene ({0})";
            this.itmMeineErhalten.Name = "itmMeineErhalten";
            this.itmMeineErhalten.SmallImageIndex = 26;
            this.itmMeineErhalten.Tag = resources.GetString("itmMeineErhalten.Tag");
            // 
            // itmMeineErledigt
            // 
            this.itmMeineErledigt.Caption = "erledigte";
            this.itmMeineErledigt.Name = "itmMeineErledigt";
            this.itmMeineErledigt.SmallImageIndex = 30;
            this.itmMeineErledigt.Tag = resources.GetString("itmMeineErledigt.Tag");
            // 
            // itmMeineErstellt
            // 
            this.itmMeineErstellt.Caption = "selber erstellte ({0})";
            this.itmMeineErstellt.Name = "itmMeineErstellt";
            this.itmMeineErstellt.SmallImageIndex = 26;
            this.itmMeineErstellt.Tag = resources.GetString("itmMeineErstellt.Tag");
            // 
            // itmMeineFaellig
            // 
            this.itmMeineFaellig.Caption = "fällige ({0})";
            this.itmMeineFaellig.Name = "itmMeineFaellig";
            this.itmMeineFaellig.SmallImageIndex = 31;
            this.itmMeineFaellig.Tag = resources.GetString("itmMeineFaellig.Tag");
            // 
            // itmMeineGruppe
            // 
            this.itmMeineGruppe.Caption = "an die Gruppe";
            this.itmMeineGruppe.Name = "itmMeineGruppe";
            this.itmMeineGruppe.SmallImageIndex = 28;
            this.itmMeineGruppe.Tag = "(TaskReceiverCode = 2 AND EXISTS (SELECT TOP 1 1 FROM FaPendenzgruppe_User WHERE " +
    "UserID = {0} AND FaPendenzgruppeID = ReceiverID)) AND TaskStatusCode IN (1, 2)";
            // 
            // itmMeineOffen
            // 
            this.itmMeineOffen.Caption = "offene ({0})";
            this.itmMeineOffen.Name = "itmMeineOffen";
            this.itmMeineOffen.SmallImageIndex = 26;
            this.itmMeineOffen.Tag = resources.GetString("itmMeineOffen.Tag");
            // 
            // itmMeineZuVisieren
            // 
            this.itmMeineZuVisieren.Caption = "zu visierende ({0})";
            this.itmMeineZuVisieren.Enabled = false;
            this.itmMeineZuVisieren.Name = "itmMeineZuVisieren";
            this.itmMeineZuVisieren.SmallImageIndex = 26;
            this.itmMeineZuVisieren.Tag = resources.GetString("itmMeineZuVisieren.Tag");
            // 
            // itmSuche
            // 
            this.itmSuche.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.itmSuche.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.itmSuche.AppearancePressed.Options.UseBackColor = true;
            this.itmSuche.Caption = "Pendenzen suchen";
            this.itmSuche.Name = "itmSuche";
            this.itmSuche.SmallImageIndex = 29;
            // 
            // itmVersandteAllgemein
            // 
            this.itmVersandteAllgemein.Caption = "allgemeine ({0})";
            this.itmVersandteAllgemein.Name = "itmVersandteAllgemein";
            this.itmVersandteAllgemein.SmallImageIndex = 26;
            this.itmVersandteAllgemein.Tag = "TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2) AND TaskTypeCo" +
    "de <> 2";
            // 
            // itmVersandteErledigt
            // 
            this.itmVersandteErledigt.Caption = "erledigte";
            this.itmVersandteErledigt.Name = "itmVersandteErledigt";
            this.itmVersandteErledigt.SmallImageIndex = 30;
            this.itmVersandteErledigt.Tag = "TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (3)";
            // 
            // itmVersandteFaellig
            // 
            this.itmVersandteFaellig.Caption = "fällige ({0})";
            this.itmVersandteFaellig.Name = "itmVersandteFaellig";
            this.itmVersandteFaellig.SmallImageIndex = 31;
            this.itmVersandteFaellig.Tag = "TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2) AND Expiration" +
    "Date <= GetDate()";
            // 
            // itmVersandteGruppe
            // 
            this.itmVersandteGruppe.Caption = "an die Gruppe";
            this.itmVersandteGruppe.Name = "itmVersandteGruppe";
            this.itmVersandteGruppe.SmallImageIndex = 28;
            this.itmVersandteGruppe.Tag = "TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2) AND TaskReceiv" +
    "erCode = 2";
            // 
            // itmVersandteOffen
            // 
            this.itmVersandteOffen.Caption = "offene ({0})";
            this.itmVersandteOffen.Name = "itmVersandteOffen";
            this.itmVersandteOffen.SmallImageIndex = 26;
            this.itmVersandteOffen.Tag = "TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2)";
            // 
            // itmVersandteZuVisieren
            // 
            this.itmVersandteZuVisieren.Caption = "zu visierende ({0})";
            this.itmVersandteZuVisieren.Enabled = false;
            this.itmVersandteZuVisieren.Name = "itmVersandteZuVisieren";
            this.itmVersandteZuVisieren.SmallImageIndex = 26;
            this.itmVersandteZuVisieren.Tag = "TaskSenderCode = 1 AND SenderID = {0} AND TaskStatusCode IN (1, 2) AND TaskTypeCo" +
    "de = 2";
            // 
            // nbgOwnTaks
            // 
            this.nbgOwnTaks.Caption = "Meine Pendenzen";
            this.nbgOwnTaks.Expanded = true;
            this.nbgOwnTaks.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.nbgOwnTaks.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineFaellig),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineOffen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineInBearbeitung),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineErstellt),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineErhalten),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineZuVisieren),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineGruppe),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmMeineErledigt)});
            this.nbgOwnTaks.Name = "nbgOwnTaks";
            this.nbgOwnTaks.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbgOwnTaks.SmallImage")));
            // 
            // nbgCreatedTasks
            // 
            this.nbgCreatedTasks.Caption = "Erstellte Pendenzen";
            this.nbgCreatedTasks.Expanded = true;
            this.nbgCreatedTasks.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small;
            this.nbgCreatedTasks.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.nbgCreatedTasks.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmVersandteFaellig),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmVersandteOffen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmVersandteAllgemein),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmVersandteZuVisieren),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmVersandteGruppe),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmVersandteErledigt)});
            this.nbgCreatedTasks.Name = "nbgCreatedTasks";
            this.nbgCreatedTasks.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbgCreatedTasks.SmallImage")));
            // 
            // nbgSearchTasks
            // 
            this.nbgSearchTasks.Caption = "Suchen";
            this.nbgSearchTasks.Expanded = true;
            this.nbgSearchTasks.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.nbgSearchTasks.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itmSuche)});
            this.nbgSearchTasks.Name = "nbgSearchTasks";
            this.nbgSearchTasks.SmallImageIndex = 23;
            // 
            // CtlFrmPendenzenVerwaltung
            // 
            this.ClientSize = new System.Drawing.Size(920, 670);
            this.Name = "CtlFrmPendenzenVerwaltung";
            this.Text = "Pendenzenverwaltung";
            this.Load += new System.EventHandler(this.CtlFrmPendenzenVerwaltung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraNavBar.NavBarItem itmMeineInBearbeitung;
        private DevExpress.XtraNavBar.NavBarItem itmMeineErhalten;
        private DevExpress.XtraNavBar.NavBarItem itmMeineErledigt;
        private DevExpress.XtraNavBar.NavBarItem itmMeineErstellt;
        private DevExpress.XtraNavBar.NavBarItem itmMeineFaellig;
        private DevExpress.XtraNavBar.NavBarItem itmMeineGruppe;
        private DevExpress.XtraNavBar.NavBarItem itmMeineOffen;
        private DevExpress.XtraNavBar.NavBarItem itmMeineZuVisieren;
        private DevExpress.XtraNavBar.NavBarItem itmSuche;
        private DevExpress.XtraNavBar.NavBarItem itmVersandteAllgemein;
        private DevExpress.XtraNavBar.NavBarItem itmVersandteErledigt;
        private DevExpress.XtraNavBar.NavBarItem itmVersandteFaellig;
        private DevExpress.XtraNavBar.NavBarItem itmVersandteGruppe;
        private DevExpress.XtraNavBar.NavBarItem itmVersandteOffen;
        private DevExpress.XtraNavBar.NavBarItem itmVersandteZuVisieren;
        private DevExpress.XtraNavBar.NavBarGroup nbgCreatedTasks;
        private DevExpress.XtraNavBar.NavBarGroup nbgOwnTaks;
        private DevExpress.XtraNavBar.NavBarGroup nbgSearchTasks;
    }
}