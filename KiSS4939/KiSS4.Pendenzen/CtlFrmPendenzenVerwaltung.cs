using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Pendenzen
{
    /// <summary>
    /// Form, used for Pendenzenverwaltung
    /// </summary>
    public partial class CtlFrmPendenzenVerwaltung : KissNavBarUserControl
    {
        private const string CLASSNAME = "CtlFrmPendenzenVerwaltung";
        private readonly CtlPendenzenVerwaltung _ctlPendenzenVerwaltung;
        private readonly Font _fontBold;
        private readonly Font _fontRegular;
        private readonly Font _fontUnderline;
        private readonly Font _fontUnderlineBold;
        private readonly Hashtable _htNavBarItem = new Hashtable();
        private readonly SqlQuery _qryTaskCount = new SqlQuery();
        private readonly bool _zuVisierendeEnabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFrmPendenzenVerwaltung"/> class.
        /// </summary>
        public CtlFrmPendenzenVerwaltung()
        {
            InitializeComponent();

            _ctlPendenzenVerwaltung = new CtlPendenzenVerwaltung { Dock = DockStyle.Fill };
            _ctlPendenzenVerwaltung.Init(RefreshNavBarItems, null, null, AccessPendenzen.Verwaltung);

            _fontRegular = itmMeineInBearbeitung.Appearance.Font;
            _fontBold = new Font(_fontRegular, FontStyle.Bold);

            _fontUnderline = new Font(_fontRegular, FontStyle.Underline);
            _fontUnderlineBold = new Font(_fontRegular, FontStyle.Underline | FontStyle.Bold);

            _zuVisierendeEnabled = DBUtil.GetConfigBool(@"System\Pendenzen\Pendenzenverwaltung\ZuVisierendePendenzenAktiv", false);

            _qryTaskCount.SelectStatement = "SELECT a = NULL";

            SetCaptionMl();

            foreach (DevExpress.XtraNavBar.NavBarItem item in navBar.Items)
            {
                item.Appearance.ForeColor = Color.IndianRed;
                item.Appearance.Options.UseForeColor = false;

                item.LinkClicked += navBar_LinkClicked;

                if (item.Tag is string && item.Caption.IndexOf("({0})") > 0)
                {
                    _qryTaskCount.SelectStatement += string.Format(",\r\n{0} = (SELECT COUNT(1) FROM dbo.XTask WITH (READUNCOMMITTED) WHERE {1})", item.Name, item.Tag);
                    _htNavBarItem[item.Name] = item.Caption;

                    item.Caption = item.Caption.Replace("({0})", "");
                }
            }

            ActivateUserControl(_ctlPendenzenVerwaltung, panDetail, false);
            ActiveControl = _ctlPendenzenVerwaltung;
        }

        protected override void OnLinkClicked(NavBarItemLink link)
        {
            foreach (DevExpress.XtraNavBar.NavBarItem item in navBar.Items)
            {
                item.Appearance.Options.UseForeColor = false;
            }

            link.Item.Appearance.Options.UseForeColor = true;

            if (link.Item == itmSuche)
            {
                _ctlPendenzenVerwaltung.CustomSearch(null);
            }
            else if (link.Item.Tag is string)
            {
                _ctlPendenzenVerwaltung.CustomSearch(Convert.ToString(link.Item.Tag), Session.User.UserID);
            }

            ShowSubMask(link);
        }

        private void CtlFrmPendenzenVerwaltung_Load(Object sender, EventArgs e)
        {
            // correct painting problem
            panDetail.Dock = DockStyle.Fill;
            panDetail.Padding = new Padding(0, 0, 3, 0);

            RefreshNavBarItems();
            OnLinkClicked(itmMeineOffen.Links[0]);
        }

        private void navBar_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            OnLinkClicked(e.Link);
        }

        /// <summary>
        /// Refreshes the nav bar items.
        /// </summary>
        private void RefreshNavBarItems()
        {
            _qryTaskCount.Fill(Session.User.UserID);

            foreach (DevExpress.XtraNavBar.NavBarItem item in navBar.Items)
            {
                if (_htNavBarItem.ContainsKey(item.Name))
                {
                    if (Convert.ToInt32(_qryTaskCount[item.Name]) > 0)
                    {
                        item.Appearance.Font = _fontBold;
                        item.AppearanceHotTracked.Font = _fontUnderlineBold;
                    }
                    else
                    {
                        item.Appearance.Font = _fontRegular;
                        item.AppearanceHotTracked.Font = _fontUnderline;
                    }

                    item.AppearancePressed.Font = item.AppearanceHotTracked.Font;
                    item.Caption = string.Format(Convert.ToString(_htNavBarItem[item.Name]), _qryTaskCount[item.Name]);

                    if (item.Appearance.Options.UseForeColor)
                    {
                        lblTitle.Text = item.Caption;
                    }
                }
            }

            itmMeineZuVisieren.Enabled = _zuVisierendeEnabled;
            itmVersandteZuVisieren.Enabled = _zuVisierendeEnabled;
        }

        private void SetCaptionMl()
        {
            nbgOwnTaks.Caption = KissMsg.GetMLMessage(CLASSNAME, "nbgOwnTaks", "Meine Pendenzen");
            itmMeineFaellig.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineFaellig", "fällige ({0})");
            itmMeineOffen.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineOffen", "offene ({0})");
            itmMeineInBearbeitung.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineInBearbeitung", "in Bearbeitung ({0})");
            itmMeineErstellt.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineErstellt", "selber erstellte ({0})");
            itmMeineErhalten.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineErhalten", "erhaltene ({0})");
            itmMeineZuVisieren.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineZuVisieren", "zu visierende ({0})");
            itmMeineGruppe.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineGruppe", "an die Gruppe");
            itmMeineErledigt.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmMeineErledigt", "erledigte");

            nbgCreatedTasks.Caption = KissMsg.GetMLMessage(CLASSNAME, "nbgCreatedTasks", "Erstellte Pendenzen");
            itmVersandteFaellig.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmVersandteFaellig", "fällige ({0})");
            itmVersandteOffen.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmVersandteOffen", "offene ({0})");
            itmVersandteAllgemein.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmVersandteAllgemein", "allgemeine ({0})");
            itmVersandteZuVisieren.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmVersandteZuVisieren", "zu visierende ({0})");
            itmVersandteGruppe.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmVersandteGruppe", "an die Gruppe");
            itmVersandteErledigt.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmVersandteErledigt", "erledigte");

            nbgSearchTasks.Caption = KissMsg.GetMLMessage(CLASSNAME, "nbgSearchTasks", "Suchen");
            itmSuche.Caption = KissMsg.GetMLMessage(CLASSNAME, "itmSuche", "Pendenzen suchen");
        }
    }
}