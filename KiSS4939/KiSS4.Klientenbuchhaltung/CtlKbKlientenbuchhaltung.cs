using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Klientenbuchhaltung.BL;

using DevExpress.XtraNavBar;

namespace KiSS4.Klientenbuchhaltung
{
    public class CtlKbKlientenbuchhaltung : KissNavBarUserControl
    {
        #region Fields

        #region Private Fields

        private KlibuEnvironment _kliBuEnvironment;
        private KissNavBarItem navBarItemCtlKbAuszahlungVerbuchen = new KissNavBarItem("Auszahlung manuell verbuchen", 1427, typeof(CtlKbAuszahlungVerbuchen), new object[] { });
        private KissNavBarItem navBarItemCtlKbBankPost = new KissNavBarItem("Bankenstamm", 191, typeof(CtlKbBankPost), new object[] { });

        //Inkasso
        private KissNavBarItem navBarItemCtlKbBelegImportIK = new KissNavBarItem("BelegImport aus Inkasso", 1326, typeof(CtlKbBelegImportIK), new object[] { });

        // Budget
        private KissNavBarItem navBarItemCtlKbBelegImportSH = new KissNavBarItem("BelegImport aus Budgets", 1321, typeof(CtlKbBelegImportSH), new object[] { });
        private KissNavBarItem navBarItemCtlKbBelegeKorrigieren = new KissNavBarItem("Beleg Korrektur", 1321, typeof(CtlKbBelegeKorrigieren), new object[] { });
        private KissNavBarItem navBarItemCtlKbBelegkreise = new KissNavBarItem("Belegkreise", 210, typeof(CtlKbBelegkreise), new object[] { });
        private KissNavBarItem navBarItemCtlKbBuchung = new KissNavBarItem("Buchungen erfassen", 178, typeof(CtlKbBuchung), new object[] { });
        private KissNavBarItem navBarItemCtlKbIbanGenerieren = new KissNavBarItem("IBAN generieren", 129, typeof(CtlKbIbanGenerieren), new object[] { });
        private KissNavBarItem navBarItemCtlKbKonto = new KissNavBarItem("Kontenplan", 176, typeof(CtlKbKonto), new object[] { });
        private KissNavBarItem navBarItemCtlKbKostenstelleErfassung = new KissNavBarItem("Kostenstelle Erfassung", 196, typeof(CtlKbKostenstelleErfassung), new object[] { });
        private KissNavBarItem navBarItemCtlKbKostenstelleZuweisung = new KissNavBarItem("Kostenstelle Zuweisung", 196, typeof(CtlKbKostenstelleZuweisung), new object[] { });
        private KissNavBarItem navBarItemCtlKbKostenstellen = new KissNavBarItem("Kostenstellen WV", 182, typeof(CtlKbKostenstellen), new object[] { });
        private KissNavBarItem navBarItemCtlKbKreditor = new KissNavBarItem("Kreditoren", 171, typeof(CtlKbKreditor), new object[] { });

        //Stammdaten
        private KissNavBarItem navBarItemCtlKbMandant = new KissNavBarItem("Mandanten", 190, typeof(CtlKbMandant), new object[] { });
        private KissNavBarItem navBarItemCtlKbPeriode = new KissNavBarItem("Geschäftsperioden", 193, typeof(CtlKbPeriode), new object[] { });

        //Direkthilfe Integration
        private KissNavBarItem navBarItemCtlBelegImportGv = new KissNavBarItem("Belegimport aus Direkthilfe", 1321, typeof(CtlKbBelegImportGv), new object[] { });

        //el. Zahlungsverkehr
        private KissNavBarItem navBarItemCtlKbTransfer = new KissNavBarItem("Zahlungsjournal", 1417, typeof(CtlKbTransfer), new object[] { });

        // WV
        private KissNavBarItem navBarItemCtlKbWVEinzelposten = new KissNavBarItem("WV-Abrechnung", 2118, typeof(CtlKbWVEinzelposten), new object[] { });

        /// TODO: renaming according standard with "_" --> migration nötig in MenuItem!
        /// 
        // Bearbeiten
        private KissNavBarItem navBarItemCtlKbZahlungseingang = new KissNavBarItem("Zahlungseingang erfassen", 185, typeof(CtlKbZahlungseingang), new object[] { });
        private KissNavBarItem navBarItemCtlKbZahlungskonto = new KissNavBarItem("Zahlungskonten", 2111, typeof(CtlKbZahlungskonto), new object[] { });
        private KissNavBarItem navBarItemCtlKbZahlungslauf = new KissNavBarItem("Zahlungslauf", 183, typeof(CtlKbZahlungslauf), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbAbrechnungASVS = new KissNavBarItem("Abrechnung ASV", 1428, typeof(CtlQueryKbAbrechnungASVS), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbAbrechnungASVSFluechtling = new KissNavBarItem("Abrechnung ASV Flüchtling", 1428, typeof(CtlQueryKbAbrechnungASVSFluechtling), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbBilanzErfolg = new KissNavBarItem("Bilanz / Erfolg", 177, typeof(CtlQueryKbBilanzErfolg), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbBilanzkonti = new KissNavBarItem("Bilanzkonti", 195, typeof(CtlQueryKbBilanzkonti), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbBuchungsjournal = new KissNavBarItem("Buchungsjournal Fibu", 1417, typeof(CtlQueryKbBuchungsjournal), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbKlientenkonto = new KissNavBarItem("Klientenkonto", 183, typeof(CtlQueryKbKlientenkonto), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbKostenarten = new KissNavBarItem("Kostenarten", 1415, typeof(CtlQueryKbKostenarten), new object[] { });

        // Auswerten
        private KissNavBarItem navBarItemCtlQueryKbKostenstellenjournal = new KissNavBarItem("Kostenstellenjournal Bebu", 199, typeof(CtlQueryKbKostenstellenjournal), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbSaldolisteKreditoren = new KissNavBarItem("Kreditoren, Saldoliste", 1424, typeof(CtlQueryKbSaldolisteKreditoren), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbSozialhilferechnung = new KissNavBarItem("Sozialhilferechnung", 1428, typeof(CtlQueryKbSozialhilferechnung), new object[] { });
        private KissNavBarItem navBarItemCtlQueryKbSozialhilferechnungDifferenziert = new KissNavBarItem("Sozialhilferechnung", 1428, typeof(CtlQueryKbSozialhilferechnungDifferenziert), new object[] { });

        #endregion

        #endregion

        #region Constructors

        public CtlKbKlientenbuchhaltung()
        {
            InitializeComponent();

            _kliBuEnvironment = KlibuEnvironmentFactory.CreateKlibuEnvironment();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Size = new System.Drawing.Size(524, 27);
            //
            // navBar
            //
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
            this.navBar.Size = new System.Drawing.Size(170, 732);
            //
            // panDetail
            //
            this.panDetail.Location = new System.Drawing.Point(173, 31);
            this.panDetail.Size = new System.Drawing.Size(835, 701);
            //
            // panTitle
            //
            this.panTitle.Size = new System.Drawing.Size(835, 31);
            //
            // picTitle
            //
            this.picTitle.Size = new System.Drawing.Size(24, 26);
            //
            // splitterNavControl
            //
            this.splitterNavControl.Size = new System.Drawing.Size(3, 732);
            //
            // CtlKbKlientenbuchhaltung
            //
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Name = "CtlKbKlientenbuchhaltung";
            this.Text = "Klientenbuchhaltung";
            this.Load += new System.EventHandler(this.CtlKbKlientenbuchhaltung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region EventHandlers

        private void CtlKbKlientenbuchhaltung_Load(object sender, System.EventArgs e)
        {
            this.RefreshForm();

            // Methode OnParentFormShown muss im Kiss5 auch aufgerufen werden. Da beim Load die Maske noch nicht sichtbar ist, wird die Methode mit BeginInvoke erst später ausgeführt.
            var parent = Parent as FrmKbKlientenbuchhaltung;
            if (parent == null)
            {
                BeginInvoke(new Action(OnParentFormShown));
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void OnParentFormShown()
        {
            if (navBar.Groups.Count > 0)
            {
                if (_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein)
                {
                    if (navBarItemCtlKbAuszahlungVerbuchen.Links.Count > 0 &&
                        navBarItemCtlKbAuszahlungVerbuchen.Links[0].Enabled)
                    {
                        // show auszahlung verbuchen
                        ShowSubMask(navBarItemCtlKbAuszahlungVerbuchen.Links[0]);
                    }
                    else
                    {
                        // show first visible control as the desired one is not available
                        ShowFirstEnabledDetailControl();
                    }
                }

                if (!_kliBuEnvironment.IsLoggedOn)
                {
                    // check if we have a valid link-amount
                    if (navBarItemCtlKbPeriode.Links.Count < 1)
                    {
                        // show error message
                        KissMsg.ShowError(this.Name, "NavBarItemCtlKbPeriodeNoItems_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.");
                    }
                    else
                    {
                        // show "Geschäftsperioden" to setup an active periode
                        ShowSubMask(navBarItemCtlKbPeriode.Links[0]);
                        KissMsg.ShowInfo(this.Name, "KeineStandardPeriode", "Sie haben noch keine Standard-Periode ausgewählt.");
                    }
                }
            }
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "MandantWechseln":
                    this.ResetPeriode();
                    this.RefreshForm();
                    return true;

                case "OpenItem":
                    foreach (KissNavBarItem item in navBar.Items)
                    {
                        if (item.Type.Name == param["SubMask"].ToString())
                        {
                            ShowSubMask(item.Links[0]);
                            FormController.SendMessage((KissUserControl)panDetail.Controls[0], param);
                            return true;
                        }
                    }
                    return false;
            }

            // did not understand message
            return false;
        }

        public override object ReturnMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "KbPeriodeID":
                    // get current Periode
                    return _kliBuEnvironment.PeriodeID;

                case "KbMandantID":
                    // get current Periode
                    return _kliBuEnvironment.MandantID;
            }

            // did not understand message
            return null;
        }

        #endregion

        #region Private Methods

        private void RefreshForm()
        {
            this.Text = _kliBuEnvironment.ToString();
            SetMenuMasks();
        }

        ///TODO Logout(?)
        private void ResetPeriode()
        {
            _kliBuEnvironment.Reset();
        }

        ///TODO kriegt man das irgendwie schöner hin?
        ///--> evtl. über verschiedene Properties?!
        private void SetMenuMasks()
        {
            bool klibuIntEnabled = _kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert && _kliBuEnvironment.IsLoggedOn;

            foreach (NavBarGroup group in navBar.Groups)
            {
                foreach (NavBarItemLink link in group.ItemLinks)
                {
                    link.Item.Enabled = klibuIntEnabled;
                }
            }

            // Bearbeiten
            navBarItemCtlKbPeriode.Enabled = _kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert;
            navBarItemCtlKbAuszahlungVerbuchen.Enabled = (_kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert && _kliBuEnvironment.IsLoggedOn) || (_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein);

            // Stammdaten
            navBarItemCtlKbMandant.Enabled = _kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert;
            navBarItemCtlKbKostenstellen.Enabled = ((_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein) || (_kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert && _kliBuEnvironment.IsLoggedOn));
            navBarItemCtlKbKostenstelleErfassung.Enabled = (_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein);
            navBarItemCtlKbKostenstelleZuweisung.Enabled = (_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein);
            navBarItemCtlKbKreditor.Enabled = ((_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein) || (_kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert && _kliBuEnvironment.IsLoggedOn));
            navBarItemCtlKbIbanGenerieren.Enabled = ((_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein) || (_kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert && _kliBuEnvironment.IsLoggedOn));
            navBarItemCtlKbBankPost.Enabled = ((_kliBuEnvironment.KlibuSystem == KlibuSystem.Kein) || (_kliBuEnvironment.KlibuSystem == KlibuSystem.Integriert && _kliBuEnvironment.IsLoggedOn));
        }

        private void ShowFirstEnabledDetailControl()
        {
            foreach (NavBarGroup group in navBar.Groups)
            {
                foreach (NavBarItemLink link in group.ItemLinks)
                {
                    if (link.Item.Enabled)
                    {
                        // show control
                        ShowSubMask(link);
                        return;
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}