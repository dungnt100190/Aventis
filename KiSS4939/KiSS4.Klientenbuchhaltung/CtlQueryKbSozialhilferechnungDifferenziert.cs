using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using KiSS.Common.IO;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlQueryKbSozialhilferechnungDifferenziert : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string ABRECHNENDE_EINHEIT = "AbrechnendeEinheit";
        private const string AHV_MINDESTBEITRAEGE = "AHVMindestbeitraege";
        private const string ALV = "ALV";
        private const string ANGESCHLOSSENE_EINHEIT = "AngeschlosseneEinheit";
        private const string ANZ_AMBULANTE_MASSNAHMEN = "AnzAmbulanteMassnahmen";
        private const string ANZ_PLATZIERUNGEN_ERWACHSENE_MIT_KESB = "AnzPlatzierungenErwachseneMitKesb";
        private const string ANZ_PLATZIERUNGEN_ERWACHSENE_OHNE_KESB = "AnzPlatzierungenErwachseneOhneKesb";
        private const string ANZ_PLATZIERUNGEN_U18_MIT_KESB = "AnzPlatzierungenU18MitKesb";
        private const string ANZ_PLATZIERUNGEN_U18_OHNE_KESB = "AnzPlatzierungenU18OhneKesb";
        private const string ANZ_UNTERSTUETZTE_MONATE = "AnzUnterstuetzteMonate";
        private const string ANZAHL_DOSSIERS = "AnzahlDossiers";
        private const string ANZAHL_PERSONEN = "AnzahlPersonen";
        private const string DATENSATZ_ID = "DatensatzID";
        private const string DATENSATZ_ID_INT = "DatensatzID_Int";
        private const string DECIMAL_FORMAT = "F2";
        private const string DOSSIER_NR = "DossierNr";
        private const string EFB = "EFB";
        private const string EINKOMMEN_AUS_SOZIALVERSICHERUNGEN = "EinkommenAusSozialversicherungen";
        private const string ELTERNBEITRAEGE_VERWANDTENUNTERSTUETZUNG = "ElternbeitraegeVerwandtenunterstuetzung";
        private const string ERTRAEGE_GESUNDHEITSKOSTEN = "ErtraegeGesundheitskosten";
        private const string ERTRAG_MIT_INKASSOPROVISION = "ErtragMitInkassoprovision";
        private const string ERTRAG_OHNE_INKASSOPROVISION = "ErtragOhneInkassoprovision";
        private const string ERWERBSEINKOMMEN_NETTO = "ErwerbseinkommenNetto";
        private const string FAMILIENZULAGEN = "Familienzulagen";
        private const string GESUNDHEITSKOSTEN = "Gesundheitskosten";
        private const string GRUNDBEDARF = "Grundbedarf";
        private const string HEIMATLICHE_VERGUETUNGEN = "HeimatlicheVerguetungen";
        private const string IV_TAGGELDER_RENTEN = "IVTaggelderRenten";
        private const string IZU = "IZU";
        private const string JAHR = "Jahr";
        private const string KINDERALIMENTE_UND_EHEGATTENALIMENTE = "KinderalimenteUndEhegattenalimente";
        private const string KK_PRAEMIEN_GRUNDVERSICHERUNG = "KKPraemienGrundversicherung";
        private const string MASSNAHMEKOSTEN_OHNE_KESB_BESCHLUSS = "MassnahmekostenOhneKesbBeschluss";
        private const string NK_MASSNAHMEN_MIT_KESB_BESCHLUSS = "NKMassnahmenMitKesbBeschluss";
        private const string NK_MASSNAHMEN_OHNE_KESB_BESCHLUSS = "NKMassnahmenOhneKesbBeschluss";
        private const string PERSOENLICHE_RUECKERSTATTUNG = "PersoenlicheRueckerstattung";
        private const string QRY_BA_WV_CODE_ = "BaWVCode$";
        private const string QRY_BEVORSCHUSSUNG = "Bevorschussung";
        private const string QRY_HAS_GEF_MAPPING_ = "HasGefMapping$";
        private const string QRY_HAS_UNMAPPED_KOA_ = "HasUnmappedKOA$";
        private const string QRY_INKASSIKOSTEN = "Inkassikosten";
        private const string QRY_IS_ALBV_KONTO_ = "IsALBVKonto$";
        private const string QRY_IS_WI_HI_RELEVANT_ = "IsWiHiRelevant$";
        private const string QRY_IS_ZUDE_KONTO_ = "IsZuDeKonto$";
        private const string QRY_NETTO = "Netto";
        private const string QRY_RUECKERSTATTUNG = "Rueckerstattung";
        private const string SCHULKOSTEN_MASSNAHMEN_OHNE_KESB_BESCHLUSS = "SchulkostenMassnahmenOhneKesbBeschluss";
        private const string UEBERSCHUSSZAHLUNG_AN_KESB = "UeberschusszahlungAnKesb";
        private const string UEBRIGE_ERTRAEGE_DWH = "UebrigeErtraegeDWH";
        private const string UEBRIGE_SIL = "UebrigeSIL";
        private const string VORSORGLICHE_AMBULANTE_MASSNAHMEN = "VorsorglicheAmbulanteMassnahmen";
        private const string WOHNKOSTEN = "Wohnkosten";

        #endregion

        #region Private Fields

        private static string _prefixPageheader = KissMsg.GetMLMessage("CtlQueryKbSozialhilfeDifferenziert", "DifferenzierungSozialhilferechnung", "Differenzierung Sozialhilferechnung {0}");

        private static string _tabPageTitle1Gesamtuebersicht = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_1Gesamtuebersicht", "1 - Gesamtübersicht");

        private static string _tabPageTitle2aWiHilfe = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_2aWiHilfe", "2a - Wirtschaftliche Hilfe");

        private static string _tabPageTitle2bWiHilfeZ = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_2bWiHilfe_Zusammenzug", "2b - Wirtschaftliche Hilfe: Zusammenzug pro Gemeinde");

        private static string _tabPageTitle3aHeimZ = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_3aZHeim_Zusammenzug", "3a - Zuschüsse HeimbewohnerInnen: Zusammenzug pro Gemeinde");

        private static string _tabPageTitle3Heim = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_3ZHeim", "3 - Zuschüsse an Heimbewohnerinnen und Heimbewohner");

        private static string _tabPageTitle4aNichtHeim = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_4aNichtHeim", "4a - Zuschüsse an Nichtheimbewohnerinnen und Nichtheimbewohner");

        private static string _tabPageTitle4bNichtHeimZ = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_4bNichtHeim_Zusammenzug", "4b - Zuschüsse NichtheimbewohnerInnen: Zusammenzug pro Gemeinde");

        private static string _tabPageTitle5aALBV = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_5aALBV", "5a - Bevorschussung von Unterhaltsbeiträgen für Kinder (Kinderalimente)");

        private static string _tabPageTitle5bALBVZ = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_5bALBV_Zusammenzug", "5b - Kinderalimente: Zusammenzug pro Gemeinde");

        private static string _tabPageTitleFilag = KissMsg.GetMLMessage("CtlQueryKbSozialhilfeDifferenziert", "Title_FILAG", "FILAG 2012");

        private static string _tabPageTitleKoaOhneZuweisung = KissMsg.GetMLMessage(
            "CtlQueryKbSozialhilfeDifferenziert", "Title_KoaOhneZuweisung", "Kostenarten ohne Zuweisung zu einer GEF Kategorie");

        private static string _tabPageTitleListe = KissMsg.GetMLMessage("CtlQueryKbSozialhilfeDifferenziert", "Title_Liste", "Liste");

        private static string[] _tabPageTitles = {
            _tabPageTitleListe, //Liste
            _tabPageTitle1Gesamtuebersicht, //1 - Gesamtübersicht
            _tabPageTitleFilag, //FILAG 2012
            _tabPageTitle2aWiHilfe, //2a - Wirtschaftliche Hilfe
            _tabPageTitle2bWiHilfeZ, //2b - Wirtschaftliche Hilfe: Zusammenzug
            _tabPageTitle3Heim, //3 - Zuschüsse Heimbewohner
            _tabPageTitle3aHeimZ, //3a - Zuschüsse Heimbewohner: Zusammenzug
            _tabPageTitle4aNichtHeim, //4a - Zuschüsse Nichtheimbewohner
            _tabPageTitle4bNichtHeimZ, //4b - Zuschüsse Nichtheimbewohner: Zusammenzug
            _tabPageTitle5aALBV, //5a - Kinderalimente
            _tabPageTitle5bALBVZ, //5b - Kinderalimente: Zusammenzug
            _tabPageTitleKoaOhneZuweisung, //KoA ohne Zuweisung
            "" //Suche
        };

        private int _kbPeriodeID;

        private int customGroupCount_FilagAnzahlUnterstuetzteMonate;
        private decimal customGroupSum_FilagAnzahlUnterstuetzteMonate;
        private decimal customTotalSum_FilagAnzahlUnterstuetzteMonate;
        private HashSet<int> treatedGroupRowHandles_FilagAnzahlUnterstuetzteMonate = new HashSet<int>();

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKbSozialhilferechnungDifferenziert()
        {
            InitializeComponent();

            qrySektion.Fill();
            edtSektion.LoadQuery(qrySektion);
        }

        #endregion

        #region EventHandlers

        private void btnXmlExport_Click(object sender, EventArgs e)
        {
            //Prüfen, dass Brutto-Sicht aktiviert wurde
            if (!edtInklBruttoSichtX.Checked)
            {
                bool result = KissMsg.ShowQuestion(Name, "XMLExportOhneBruttoSicht",
                    "Sie führen den XML Export ohne Brutto-Sicht aus. Wollen Sie trotzdem fortfahren?", false);
                if (result)
                {
                    XmlExport();
                }
            }
            else
            {
                XmlExport();
            }
        }

        private void CtlQueryKbSozialhilferechnungDifferenziert_Load(object sender, EventArgs e)
        {
            _kbPeriodeID = FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID") as int? ?? 0;

            grdQuery1.XtraPrint += grdQuery1_XtraPrint;

            kissSearch.SelectParameters = new object[] { _kbPeriodeID, Session.User.LanguageCode };

            // Grösse von Grid die nicht mit Dock.Fill sondern mit Anchor definiert sind richtig setzen
            grdQuery1.Size = new Size(grdQuery1.Parent.Size.Width, grdQuery1.Parent.Size.Height - 30);
            grdFilag.Size = new Size(grdFilag.Parent.Size.Width, grdFilag.Parent.Size.Height - 30);

            // CtlGotoFall anhand Position des Grids platzieren
            ctlGotoFall.Location = new Point(3, grdQuery1.Size.Height + 3);
            ctlGotoFall1.Location = new Point(3, grdFilag.Size.Height + 3);
            btnXmlExport.Location = new Point(grdFilag.Size.Width - btnXmlExport.Size.Width - 3, grdFilag.Size.Height + 3);
        }

        private void grdAnhang1_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang1.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle1Gesamtuebersicht),
                footerTextLeft
            );
        }

        private void grdAnhang2a_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang2a.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle2aWiHilfe),
                footerTextLeft
            );
        }

        private void grdAnhang2b_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang2b.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle2bWiHilfeZ),
                footerTextLeft
            );
        }

        private void grdAnhang3_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang3.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle3Heim),
                footerTextLeft
            );
        }

        private void grdAnhang3a_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang3a.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle3aHeimZ),
                footerTextLeft
            );
        }

        private void grdAnhang4a_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang4a.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle4aNichtHeim),
                footerTextLeft
            );
        }

        private void grdAnhang4b_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang4b.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle4bNichtHeimZ),
                footerTextLeft
            );
        }

        private void grdAnhang5a_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang5a.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle5aALBV),
                footerTextLeft
            );
        }

        private void grdAnhang5b_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdAnhang5b.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitle5bALBVZ),
                footerTextLeft
            );
        }

        private void grdFilag_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdFilag.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitleFilag),
                footerTextLeft
            );
        }

        private void grdKoaOhneZuweisung_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdFilag.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitleKoaOhneZuweisung),
                footerTextLeft
            );
        }

        private void grdQuery1_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdQuery1.SetHeaderAndFooterText(
                e,
                string.Format(_prefixPageheader, _tabPageTitleListe),
                footerTextLeft
            );
        }

        private void grvFilag_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetGotoFallBaPersonID(e.FocusedRowHandle, ctlGotoFall1, grvFilag);
        }

        private void grvQuery1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetGotoFallBaPersonID(e.FocusedRowHandle, ctlGotoFall, grvQuery1);
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            UpdateGridDataSources();

            //Update lblNettoSicht
            lblNettoSicht.Visible = !edtInklBruttoSichtX.Checked;
        }

        private void SetupTabPages(bool inklBruttoSicht)
        {
            //wenn Brutto-Sicht, dann darf nur 4-Filag sichtbar sein
            tpgListe.HideTab = inklBruttoSicht;
            tpgAnhang1.HideTab = inklBruttoSicht;

            //Ausnahme:4-Filag bleibt sichtbar
            //tpgFilag.HideTab = inklBruttoSicht;

            tpgAnhang2a.HideTab = inklBruttoSicht;
            tpgAnhang2b.HideTab = inklBruttoSicht;
            tpgAnhang3.HideTab = inklBruttoSicht;
            tpgAnhang3a.HideTab = inklBruttoSicht;
            tpgAnhang4a.HideTab = inklBruttoSicht;
            tpgAnhang4b.HideTab = inklBruttoSicht;
            tpgAnhang5a.HideTab = inklBruttoSicht;
            tpgAnhang5b.HideTab = inklBruttoSicht;
            tpgKoaOhneZuweisung.HideTab = inklBruttoSicht;
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (page == tpgSuchen)
            {
                //Update lblNettoSicht
                lblNettoSicht.Visible = false;
            }
            btnXmlExport.Visible = (tabControlSearch.SelectedTab == tpgFilag);
            AllowGrouping = (tabControlSearch.SelectedTab != tpgFilag);
            lblTitle.Text = _tabPageTitles[tabControlSearch.SelectedTabIndex];

            if (page == tpgListe && edtInklBruttoSichtX.Checked)
            {
                //sicherstellen, dass nicht Liste selektiert ist, da in Brutto-Sicht dieses Tab gar nicht existiert
                tabControlSearch.SelectTab(tpgFilag);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetGotoFallBaPersonID(int rowHandle, CtlGotoFall gotoFall, GridView grv)
        {
            gotoFall.BaPersonID = grv.GetRowCellValue(rowHandle, "BaPersonID$");
        }

        private void SetupDataSourceAndGridColumns(KissGrid grid, int tableNr, string rowFilter)
        {
            var dataView = new DataView(qryQuery.DataTable.DataSet.Tables[tableNr].Copy())
            {
                RowFilter = rowFilter
            };
            SetupDataSourceAndGridColumns(grid, dataView);
        }

        private void UpdateGridDataSources()
        {
            //ungrouped - Table#0
            SetupDataSourceAndGridColumns(grdQuery1, 0, null);
            ctlGotoFall.DataSource = null;
            SetGotoFallBaPersonID(0, ctlGotoFall, grvQuery1);
            grvQuery1.FocusedRowChanged -= grvQuery1_FocusedRowChanged;
            grvQuery1.FocusedRowChanged += grvQuery1_FocusedRowChanged;

            SetupDataSourceAndGridColumns(grdFilag, 0, $"{QRY_IS_WI_HI_RELEVANT_} = 1");

            ctlGotoFall1.DataSource = null;
            SetGotoFallBaPersonID(0, ctlGotoFall1, grvFilag);
            grvFilag.FocusedRowChanged -= grvFilag_FocusedRowChanged;
            grvFilag.FocusedRowChanged += grvFilag_FocusedRowChanged;

            SetupDataSourceAndGridColumns(grdAnhang2a, 0, $"{QRY_IS_WI_HI_RELEVANT_} = 1");
            SetupDataSourceAndGridColumns(grdAnhang3, 0, $"{QRY_BA_WV_CODE_} = 50");
            SetupDataSourceAndGridColumns(grdAnhang4a, 0, $"{QRY_BA_WV_CODE_} = 51");
            SetupDataSourceAndGridColumns(grdAnhang5a, 0, $"{QRY_IS_ALBV_KONTO_} = 1");
            SetupDataSourceAndGridColumns(grdKoaOhneZuweisung, 0, $"{QRY_HAS_UNMAPPED_KOA_} = 1");

            //grouped - Table#1
            SetupDataSourceAndGridColumns(grdAnhang2b, 1, $"{QRY_IS_WI_HI_RELEVANT_} = 1");
            SetupDataSourceAndGridColumns(grdAnhang3a, 1, $"{QRY_BA_WV_CODE_} = 50");
            SetupDataSourceAndGridColumns(grdAnhang4b, 1, $"{QRY_BA_WV_CODE_} = 51");
            SetupDataSourceAndGridColumns(grdAnhang5b, 1, $"{QRY_IS_ALBV_KONTO_} = 1");

            //Übersicht - Table#2
            SetupDataSourceAndGridColumns(grdAnhang1, 2, string.Empty);
        }

        /// <summary>
        /// Exports the FILAG-2012 tab as XML for the GEF (#5068)
        /// </summary>
        private void XmlExport()
        {
            // Get xml name
            var dlgFileSave = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ".xml",
                Filter = @"XML files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (DialogResult.Cancel == dlgFileSave.ShowDialog(this))
            {
                return;
            }

            // define xml settings
            var xmlSettings = new XmlWriterSettings { NewLineOnAttributes = true, Indent = true };

            // write xml
            using (var writer = XmlWriter.Create(dlgFileSave.FileName, xmlSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("DatenimportDSHR");
                writer.WriteAttributeString("xmlns", "xs", null, "http://www.w3.org/2001/XMLSchema");

                // foreach rows in the FILAG tab
                var rows = qryQuery.DataTable.Select(((DataView)grdFilag.DataSource).RowFilter);

                var person = from row in rows
                             select new PersonRow
                             {
                                 DatensatzIdInt = (int)row[DATENSATZ_ID_INT],
                                 Jahr = (int)row[JAHR],
                                 AbrechnendeEinheit = row[ABRECHNENDE_EINHEIT] as int?,
                                 AngeschlosseneGemeinde = row[ANGESCHLOSSENE_EINHEIT] as int?,
                                 DossierNummer = (int)row[DOSSIER_NR],
                                 Grundbedarf = (decimal)row[GRUNDBEDARF],
                                 Wohnkosten = (decimal)row[WOHNKOSTEN],
                                 Gesundheitskosten = (decimal)row[GESUNDHEITSKOSTEN],
                                 KKPraemien = (decimal)row[KK_PRAEMIEN_GRUNDVERSICHERUNG],
                                 Platzierungskosten1 = (decimal)row[NK_MASSNAHMEN_MIT_KESB_BESCHLUSS],
                                 UeberschusszahlungKESB = (decimal)row[UEBERSCHUSSZAHLUNG_AN_KESB],
                                 Platzierungskosten2 = (decimal)row[MASSNAHMEKOSTEN_OHNE_KESB_BESCHLUSS],
                                 SchulkostenMassnahmenOhneKESB = (decimal)row[SCHULKOSTEN_MASSNAHMEN_OHNE_KESB_BESCHLUSS],
                                 NebenkostenMassnahmenOhneKESB = (decimal)row[NK_MASSNAHMEN_OHNE_KESB_BESCHLUSS],
                                 AmbulanteMassnahmen = (decimal)row[VORSORGLICHE_AMBULANTE_MASSNAHMEN],
                                 AHVMindestbeitraege = (decimal)row[AHV_MINDESTBEITRAEGE],
                                 UebrigeSIL = (decimal)row[UEBRIGE_SIL],
                                 IZU_MIZ = (decimal)row[IZU],
                                 Einkommensfreibetrag = (decimal)row[EFB],
                                 Erwerbseinkommen = (decimal)row[ERWERBSEINKOMMEN_NETTO],
                                 ALV = (decimal)row[ALV],
                                 IV = (decimal)row[IV_TAGGELDER_RENTEN],
                                 EinkommenUebrigeSozialVers = (decimal)row[EINKOMMEN_AUS_SOZIALVERSICHERUNGEN],
                                 Alimente = (decimal)row[KINDERALIMENTE_UND_EHEGATTENALIMENTE],
                                 Familienzulagen = (decimal)row[FAMILIENZULAGEN],
                                 KKRueckerstattungen = (decimal)row[ERTRAEGE_GESUNDHEITSKOSTEN],
                                 PersRueckerstattungen = (decimal)row[PERSOENLICHE_RUECKERSTATTUNG],
                                 ElternVerwandtenUnterst = (decimal)row[ELTERNBEITRAEGE_VERWANDTENUNTERSTUETZUNG],
                                 HeimatlicheVerguetungen = (decimal)row[HEIMATLICHE_VERGUETUNGEN],
                                 UebrigeEinkommen = (decimal)row[UEBRIGE_ERTRAEGE_DWH],
                                 PlatzierungenErwachsene = (int)row[ANZ_PLATZIERUNGEN_ERWACHSENE_OHNE_KESB],
                                 PlatzierungenErwachseneVormundschaft = (int)row[ANZ_PLATZIERUNGEN_ERWACHSENE_MIT_KESB],
                                 PlatzierungenUnter18 = (int)row[ANZ_PLATZIERUNGEN_U18_OHNE_KESB],
                                 PlatzierungenUnter18Vormundschaft = (int)row[ANZ_PLATZIERUNGEN_U18_MIT_KESB],
                                 AnzahlAmbulanteMassnahmen = (int)row[ANZ_AMBULANTE_MASSNAHMEN],
                                 AnzahlDossiers = (int)row[ANZAHL_DOSSIERS],
                                 AnzahlUnterstPersonen = (int)row[ANZAHL_PERSONEN],
                                 AnzahlUnterstMonate = (int)row[ANZ_UNTERSTUETZTE_MONATE],
                             };

                var grouped = from p in person
                              group p by p.DossierNummer
                                  into grp
                              select new
                              {
                                  DossierNr = grp.Key,
                                  Personen = grp,
                              };

                var dossiers = from grp in grouped
                               let falltraeger = grp.Personen.Where(p => p.DatensatzIdInt == grp.DossierNr).FirstOrDefault()
                               select new PersonRow
                               {
                                   DatensatzIdInt = falltraeger != null ? falltraeger.DatensatzIdInt : grp.Personen.Min(p => p.DatensatzIdInt),
                                   Jahr = grp.Personen.Min(p => p.Jahr),
                                   AbrechnendeEinheit = grp.Personen.Min(p => p.AbrechnendeEinheit),
                                   AngeschlosseneGemeinde = grp.Personen.Min(p => p.AngeschlosseneGemeinde),
                                   DossierNummer = grp.DossierNr,
                                   Grundbedarf = grp.Personen.Sum(p => p.Grundbedarf),
                                   Wohnkosten = grp.Personen.Sum(p => p.Wohnkosten),
                                   Gesundheitskosten = grp.Personen.Sum(p => p.Gesundheitskosten),
                                   KKPraemien = grp.Personen.Sum(p => p.KKPraemien),
                                   Platzierungskosten1 = grp.Personen.Sum(p => p.Platzierungskosten1),
                                   UeberschusszahlungKESB = grp.Personen.Sum(p => p.UeberschusszahlungKESB),
                                   Platzierungskosten2 = grp.Personen.Sum(p => p.Platzierungskosten2),
                                   SchulkostenMassnahmenOhneKESB = grp.Personen.Sum(p => p.SchulkostenMassnahmenOhneKESB),
                                   NebenkostenMassnahmenOhneKESB = grp.Personen.Sum(p => p.NebenkostenMassnahmenOhneKESB),
                                   AmbulanteMassnahmen = grp.Personen.Sum(p => p.AmbulanteMassnahmen),
                                   AHVMindestbeitraege = grp.Personen.Sum(p => p.AHVMindestbeitraege),
                                   UebrigeSIL = grp.Personen.Sum(p => p.UebrigeSIL),
                                   IZU_MIZ = grp.Personen.Sum(p => p.IZU_MIZ),
                                   Einkommensfreibetrag = grp.Personen.Sum(p => p.Einkommensfreibetrag),
                                   Erwerbseinkommen = grp.Personen.Sum(p => p.Erwerbseinkommen),
                                   ALV = grp.Personen.Sum(p => p.ALV),
                                   IV = grp.Personen.Sum(p => p.IV),
                                   EinkommenUebrigeSozialVers = grp.Personen.Sum(p => p.EinkommenUebrigeSozialVers),
                                   Alimente = grp.Personen.Sum(p => p.Alimente),
                                   Familienzulagen = grp.Personen.Sum(p => p.Familienzulagen),
                                   KKRueckerstattungen = grp.Personen.Sum(p => p.KKRueckerstattungen),
                                   PersRueckerstattungen = grp.Personen.Sum(p => p.PersRueckerstattungen),
                                   ElternVerwandtenUnterst = grp.Personen.Sum(p => p.ElternVerwandtenUnterst),
                                   HeimatlicheVerguetungen = grp.Personen.Sum(p => p.HeimatlicheVerguetungen),
                                   UebrigeEinkommen = grp.Personen.Sum(p => p.UebrigeEinkommen),
                                   PlatzierungenErwachsene = grp.Personen.Distinct().Sum(p => p.PlatzierungenErwachsene),
                                   PlatzierungenErwachseneVormundschaft = grp.Personen.Distinct().Sum(p => p.PlatzierungenErwachseneVormundschaft),
                                   PlatzierungenUnter18 = grp.Personen.Distinct().Sum(p => p.PlatzierungenUnter18),
                                   PlatzierungenUnter18Vormundschaft = grp.Personen.Distinct().Sum(p => p.PlatzierungenUnter18Vormundschaft),
                                   AnzahlAmbulanteMassnahmen = grp.Personen.Distinct().Sum(p => p.AnzahlAmbulanteMassnahmen),
                                   AnzahlDossiers = grp.Personen.Max(p => p.AnzahlDossiers), //distinct darf hier nicht verwendet werden, da diese Spalte bei einer duplizierten Zeile abweichende Werte haben kann (eine Zeile 0, eine Zeile 1). Je nach dem, welche zuerst kommt, verwendet .Distinct(...) 0 oder 1, was falsch ist. --> Besser: Max(...) wenn eine Person 1 liefert, gilt auf dem Dossier 1
                                   AnzahlUnterstPersonen = grp.Personen.Distinct().Sum(p => p.AnzahlUnterstPersonen),
                                   AnzahlUnterstMonate = (int)Math.Ceiling(grp.Personen.Distinct().Average(p => p.AnzahlUnterstMonate)),
                               };

                foreach (var dossier in dossiers)
                {
                    writer.WriteStartElement("DossierDSHR");

                    writer.WriteElement("Id", dossier.DatensatzIdInt);
                    writer.WriteElement("Jahr", dossier.Jahr);
                    writer.WriteElement("AbrechnendeEinheit", dossier.AbrechnendeEinheit);
                    writer.WriteElement("AngeschlosseneGemeinde", dossier.AngeschlosseneGemeinde);
                    writer.WriteElement("DossierNummer", dossier.DossierNummer);
                    writer.WriteElement("Grundbedarf", dossier.Grundbedarf, DECIMAL_FORMAT);
                    writer.WriteElement("Wohnkosten", dossier.Wohnkosten, DECIMAL_FORMAT);
                    writer.WriteElement("Gesundheitskosten", dossier.Gesundheitskosten, DECIMAL_FORMAT);
                    writer.WriteElement("KKPraemien", dossier.KKPraemien, DECIMAL_FORMAT);
                    writer.WriteElement("Platzierungskosten1", dossier.Platzierungskosten1, DECIMAL_FORMAT);
                    writer.WriteElement("UeberschusszahlungKESB", dossier.UeberschusszahlungKESB, DECIMAL_FORMAT);
                    writer.WriteElement("Platzierungskosten2", dossier.Platzierungskosten2, DECIMAL_FORMAT);
                    writer.WriteElement("SchulkostenMassnahmenOhneKESB", dossier.SchulkostenMassnahmenOhneKESB, DECIMAL_FORMAT);
                    writer.WriteElement("NebenkostenMassnahmenOhneKESB", dossier.NebenkostenMassnahmenOhneKESB, DECIMAL_FORMAT);
                    writer.WriteElement("AmbulanteMassnahmen", dossier.AmbulanteMassnahmen, DECIMAL_FORMAT);
                    writer.WriteElement("AHVMindestbeitraege", dossier.AHVMindestbeitraege, DECIMAL_FORMAT);
                    writer.WriteElement("UebrigeSIL", dossier.UebrigeSIL, DECIMAL_FORMAT);
                    writer.WriteElement("IZU-MIZ", dossier.IZU_MIZ, DECIMAL_FORMAT);
                    writer.WriteElement("Einkommensfreibetrag", dossier.Einkommensfreibetrag, DECIMAL_FORMAT);
                    writer.WriteElement("Erwerbseinkommen", dossier.Erwerbseinkommen, DECIMAL_FORMAT);
                    writer.WriteElement("ALV", dossier.ALV, DECIMAL_FORMAT);
                    writer.WriteElement("IV", dossier.IV, DECIMAL_FORMAT);
                    writer.WriteElement("EinkommenUebrigeSozialVers", dossier.EinkommenUebrigeSozialVers, DECIMAL_FORMAT);
                    writer.WriteElement("Alimente", dossier.Alimente, DECIMAL_FORMAT);
                    writer.WriteElement("Familienzulagen", dossier.Familienzulagen, DECIMAL_FORMAT);
                    writer.WriteElement("KKRueckerstattungen", dossier.KKRueckerstattungen, DECIMAL_FORMAT);
                    writer.WriteElement("PersRueckerstattungen", dossier.PersRueckerstattungen, DECIMAL_FORMAT);
                    writer.WriteElement("ElternVerwandtenUnterst", dossier.ElternVerwandtenUnterst, DECIMAL_FORMAT);
                    writer.WriteElement("HeimatlicheVerguetungen", dossier.HeimatlicheVerguetungen, DECIMAL_FORMAT);
                    writer.WriteElement("UebrigeEinkommen", dossier.UebrigeEinkommen, DECIMAL_FORMAT);
                    writer.WriteElement("PlatzierungenErwachsene", dossier.PlatzierungenErwachsene);
                    writer.WriteElement("PlatzierungenErwachseneVormundschaft", dossier.PlatzierungenErwachseneVormundschaft);
                    writer.WriteElement("PlatzierungenUnter18", dossier.PlatzierungenUnter18);
                    writer.WriteElement("PlatzierungenUnter18Vormundschaft", dossier.PlatzierungenUnter18Vormundschaft);
                    writer.WriteElement("AnzahlAmbulanteMassnahmen", dossier.AnzahlAmbulanteMassnahmen);
                    writer.WriteElement("AnzahlDossiers", dossier.AnzahlDossiers);
                    writer.WriteElement("AnzahlUnterstPersonen", dossier.AnzahlUnterstPersonen);
                    writer.WriteElement("AnzahlUnterstMonate", dossier.AnzahlUnterstMonate);

                    writer.WriteEndElement(); // </DossierDSHR>
                }

                writer.WriteEndElement(); // </DatenimportDSHR>
                writer.WriteEndDocument();
            }
        }

        public class PersonRow
        {
            public int? AbrechnendeEinheit
            {
                get;
                set;
            }

            public decimal AHVMindestbeitraege
            {
                get;
                set;
            }

            public decimal Alimente
            {
                get;
                set;
            }

            public decimal ALV
            {
                get;
                set;
            }

            public decimal AmbulanteMassnahmen
            {
                get;
                set;
            }

            public int? AngeschlosseneGemeinde
            {
                get;
                set;
            }

            public int AnzahlAmbulanteMassnahmen
            {
                get;
                set;
            }

            public int AnzahlDossiers
            {
                get;
                set;
            }

            public int AnzahlUnterstMonate
            {
                get;
                set;
            }

            public int AnzahlUnterstPersonen
            {
                get;
                set;
            }

            public int DatensatzIdInt
            {
                get;
                set;
            }

            public int DossierNummer
            {
                get;
                set;
            }

            public decimal Einkommensfreibetrag
            {
                get;
                set;
            }

            public decimal EinkommenUebrigeSozialVers
            {
                get;
                set;
            }

            public decimal ElternVerwandtenUnterst
            {
                get;
                set;
            }

            public decimal Erwerbseinkommen
            {
                get;
                set;
            }

            public decimal Familienzulagen
            {
                get;
                set;
            }

            public decimal Gesundheitskosten
            {
                get;
                set;
            }

            public decimal Grundbedarf
            {
                get;
                set;
            }

            public decimal HeimatlicheVerguetungen
            {
                get;
                set;
            }

            public decimal IV
            {
                get;
                set;
            }

            public decimal IZU_MIZ
            {
                get;
                set;
            }

            public int Jahr
            {
                get;
                set;
            }

            public decimal KKPraemien
            {
                get;
                set;
            }

            public decimal KKRueckerstattungen
            {
                get;
                set;
            }

            public decimal NebenkostenMassnahmenOhneKESB
            {
                get;
                set;
            }

            public decimal PersRueckerstattungen
            {
                get;
                set;
            }

            public int PlatzierungenErwachsene
            {
                get;
                set;
            }

            public int PlatzierungenErwachseneVormundschaft
            {
                get;
                set;
            }

            public int PlatzierungenUnter18
            {
                get;
                set;
            }

            public int PlatzierungenUnter18Vormundschaft
            {
                get;
                set;
            }

            public decimal Platzierungskosten1
            {
                get;
                set;
            }

            public decimal Platzierungskosten2
            {
                get;
                set;
            }

            public decimal SchulkostenMassnahmenOhneKESB
            {
                get;
                set;
            }

            public decimal UeberschusszahlungKESB
            {
                get;
                set;
            }

            public decimal UebrigeEinkommen
            {
                get;
                set;
            }

            public decimal UebrigeSIL
            {
                get;
                set;
            }

            public decimal Wohnkosten
            {
                get;
                set;
            }

            public override bool Equals(object value)
            {
                var type = value as PersonRow;
                return (type != null) && EqualityComparer<int>.Default.Equals(type.DatensatzIdInt, DatensatzIdInt);
            }

            public override int GetHashCode()
            {
                int num = 0x7a2f0b42;
                return (-1521134295 * num) + EqualityComparer<int>.Default.GetHashCode(DatensatzIdInt);
            }
        }

        #endregion

        private void edtSAR_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            String SearchString = edtSAR.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtSAR.EditValue = null;
                    edtSAR.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSAR.EditValue = dlg["Name"];
                edtSAR.LookupID = dlg["UserID"];
            }
        }

        #endregion

        private void CalcGroupSummary_ColFilagAnzUnterstuetzteMonate(CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                customGroupSum_FilagAnzahlUnterstuetzteMonate = 0;
                customGroupCount_FilagAnzahlUnterstuetzteMonate = 0;
            }
            else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                var fieldValue = e.FieldValue as int?;
                if (fieldValue.HasValue)
                {
                    customGroupSum_FilagAnzahlUnterstuetzteMonate += fieldValue.Value;
                    customGroupCount_FilagAnzahlUnterstuetzteMonate++;
                }
            }
            else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                if (customGroupCount_FilagAnzahlUnterstuetzteMonate == 0)
                {
                    e.TotalValue = 0;
                }
                else
                {
                    e.TotalValue = (int)Math.Ceiling(customGroupSum_FilagAnzahlUnterstuetzteMonate / customGroupCount_FilagAnzahlUnterstuetzteMonate);
                }
            }
        }

        private void CalcGroupSummary_grvFilag(CustomSummaryEventArgs e)
        {
            var summaryItem = e.Item as GridGroupSummaryItem;
            if (summaryItem == null)
            {
                return;
            }

            if (summaryItem.FieldName == ANZ_UNTERSTUETZTE_MONATE)
            {
                CalcGroupSummary_ColFilagAnzUnterstuetzteMonate(e);
            }
        }

        private void CalcTotalSummary_ColFilagAnzUnterstuetzteMonate(CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                customTotalSum_FilagAnzahlUnterstuetzteMonate = 0;
                treatedGroupRowHandles_FilagAnzahlUnterstuetzteMonate.Clear();
            }
            else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                var groupRowHandle = grvFilag.GetParentRowHandle(e.RowHandle);
                if (!treatedGroupRowHandles_FilagAnzahlUnterstuetzteMonate.Contains(groupRowHandle))
                {
                    var rowSummaryItem = grvFilag.GetRowSummaryItem(groupRowHandle, colFilagAnzUnterstuetzteMonate);
                    var averageValue = rowSummaryItem.Value as int?;
                    if (averageValue.HasValue)
                    {
                        customTotalSum_FilagAnzahlUnterstuetzteMonate += averageValue.Value;
                        treatedGroupRowHandles_FilagAnzahlUnterstuetzteMonate.Add(groupRowHandle);
                    }
                }
            }
            else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                e.TotalValue = customTotalSum_FilagAnzahlUnterstuetzteMonate;
            }
        }

        private void CalcTotalSummary_grvFilag(CustomSummaryEventArgs e)
        {
            var summaryItem = e.Item as GridColumnSummaryItem;
            if (summaryItem == null)
            {
                return;
            }

            if (summaryItem.FieldName == ANZ_UNTERSTUETZTE_MONATE)
            {
                CalcTotalSummary_ColFilagAnzUnterstuetzteMonate(e);
            }
        }

        private void edtInklBruttoSichtX_CheckedChanged(object sender, EventArgs e)
        {
            SetupTabPages(edtInklBruttoSichtX.Checked);
        }

        private void grvFilag_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary)
            {
                CalcTotalSummary_grvFilag(e);
            }
            else if (e.IsGroupSummary)
            {
                CalcGroupSummary_grvFilag(e);
            }
        }
    }
}