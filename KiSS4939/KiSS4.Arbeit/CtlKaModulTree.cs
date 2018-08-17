using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    partial class CtlKaModulTree : KissModulTree
    {
        #region Fields

        #region Private Fields

        private int _oldPersSichtbar;
        private bool _themenUpdate;

        #endregion

        #endregion

        #region Constructors

        public CtlKaModulTree(int baPersonID, Panel panDetail)
            : base(baPersonID, panDetail, Gui.ModulID.K)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            popup_Tree.LinksPersistInfo.Clear();
            popup_Tree.LinksPersistInfo.AddRange(new[] {
                new LinkPersistInfo(btnNewAbklaerung),
                new LinkPersistInfo(btnNewVermittlungInizio),
                new LinkPersistInfo(btnNewVermittlungBI),
                new LinkPersistInfo(btnNewVermittlungSI),
                new LinkPersistInfo(btnNewJobtimal),
                new LinkPersistInfo(btnNewEaf),
                new LinkPersistInfo(btnNewQualifizierungJ),
                new LinkPersistInfo(btnNewQualifizierungE),
                new LinkPersistInfo(btnNewTransfer),
                new LinkPersistInfo(btnNewAssistenz),
                new LinkPersistInfo(btnDelete, true),
                new LinkPersistInfo(btnFallInfo),
                new LinkPersistInfo(btnFallZugriff, true)});

            SetThemenLayout();
            HideThemenFilter();
        }

        public CtlKaModulTree()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        protected override void kissTree_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e == null || e.Node == null)
            {
                ShowDetail(null);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var className = e.Node.GetValue("ClassName") as string;
                var imgIcon = GetIcon(e);
                var titel = e.Node.GetValue("Name") as string;

                var baPersonID = e.Node.GetValue("BaPersonID") as int?;
                var faLeistungID = e.Node.GetValue("FaLeistungID") as int?;

                KissUserControl ctl = null;

                // Neue WPF Masken (XAML)
                var initParams = new InitParameters
                {
                    BaPersonID = baPersonID,
                    FaLeistungID = faLeistungID,
                    Title = titel,
                };
                var xclassID = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID(className);
                if (xclassID.HasValue)
                {
                    var view = new CtlWpfHost(xclassID.Value, initParams);
                    ShowDetail(view, true);
                    return;
                }

                int faLeistungIdRelation;
                switch (className)
                {
                    case null:
                        ShowDetail(ctl, true);
                        return;

                    case "CtlKaAnweisung":
                    case "CtlKaPraesenzAllgemein":
                    case "CtlKaIntegBildung":
                    case "CtlKaZuteilFachbereich":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon,
                            (int)e.Node.GetValue("BaPersonID"),
                            (int)e.Node.GetValue("FaLeistungID"));
                        break;

                    case "CtlKaAssistenz":
                    case "CtlKaQJVereinbarung":
                    case "CtlKaQJProzess":
                    case "CtlKaQJUebersicht":
                    case "CtlKaQJPZZielvereinbarung":
                    case "CtlKaQEJobtimum":
                    case "CtlKaAKZuweiser":
                    case "CtlKaAbklaerungIntake":
                    case "CtlKaAbklaerungVertieft":
                    case "CtlKaAKPhasen":
                    case "CtlKaQEEPQ":
                    case "CtlKaQJExterneEinsaetze":
                    case "CtlKaQJIntake":
                    case "CtlKaQJBildung":
                    case "CtlKaProzessQJ":
                    case "CtlKaProzessQE":
                    case "CtlKaTransfer":
                    case "CtlKaTransferProzess":
                    case "CtlKaProzessAS":
                    case "CtlKaProzessAK":
                    case "CtlKaProzessInizio":
                    case "CtlKaProzessBIBIP":
                    case "CtlKaProzessSI":
                    case "CtlKaProzessJobtimal":
                    case "CtlKaInizioEinsaetze":
                    case "CtlKaVermittlungSIEinsaetze":
                    case "CtlKaVermittlungJobtimalEinsaetze":
                    case "CtlKaJobtimalEinsaetze":
                    case "CtlKaVermittlungBIBIPEinsaetzeBIP":
                    case "CtlKaVermittlungBIBIPStellenBI":
                    case "CtlKaVermittlungSIVermittlungsprofil":
                    case "CtlKaVermittlungBIBIPVermittlungsprofil":
                    case "CtlKaInizioVermittlungsprofil":
                    case "CtlKaQJExternVermittlungsprofil":
                    case "CtlKaVermittlungSIUebersicht":
                    case "CtlKaJobtimalUebersicht":
                    case "CtlKaAusbildung":
                    case "CtlKaVermittlungBIBIPUebersicht":
                    case "CtlKaInizioUebersicht":
                    case "CtlKaExterneBildung":
                    case "CtlKaQJPZAssessment":
                    case "CtlKaQJPZBerichte":
                    case "CtlKaVerlauf":
                    case "CtlKaEafSozioberuflicheBilanz":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon,
                            (int)e.Node.GetValue("FaLeistungID"),
                            (int)e.Node.GetValue("BaPersonID"));
                        break;

                    case "CtlKaKontaktartProzess":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon,
                            (int)e.Node.GetValue("FaLeistungID"),
                            (int)e.Node.GetValue("BaPersonID"),
                            (int)e.Node.GetValue("ProzessCode"));
                        break;

                    case "CtlKaEafSpezifischeErmittlung":
                        faLeistungIdRelation = FindRelatedFaLeistungId(Convert.ToInt32(e.Node.GetValue("FaLeistungID")), FaRelationTyp.KaEaf);
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon,
                            faLeistungIdRelation,
                            (int)e.Node.GetValue("BaPersonID"));
                        break;

                    case "CtlKaProzessEaf":
                        faLeistungIdRelation = FindRelatedFaLeistungId(Convert.ToInt32(e.Node.GetValue("FaLeistungID")), FaRelationTyp.KaEaf);
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon,
                            Convert.ToInt32(e.Node.GetValue("FaLeistungID")),
                            faLeistungIdRelation,
                            Convert.ToInt32(e.Node.GetValue("BaPersonID")),
                            Convert.ToInt32(e.Node.GetValue("ProzessCode")));
                        break;

                    case "CtlDynaMask":
                        var maskName = e.Node.GetValue("MaskName") as string;

                        if (maskName != null && (maskName.Equals("Ka_VermittlungSI") || maskName.Equals("Ka_VermittlungBIBIP") || maskName.Equals("Ka_VermittlungInizio")))
                        {
                            ctl = (KissUserControl)AssemblyLoader.CreateInstance("CtlKaProzess");
                            AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon,
                                (int)e.Node.GetValue("FaLeistungID"),
                                (int)e.Node.GetValue("BaPersonID"));

                            break;
                        }

                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        var ctlDynaMask = (CtlDynaMask)ctl;
                        ctlDynaMask.Init(titel, imgIcon, (int)e.Node.GetValue("FaLeistungID"), 0, maskName, false, null);
                        ShowDetail(ctlDynaMask, true);
                        ctlDynaMask.ResizeControls();
                        return;

                    default:
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        break;
                }

                ApplyEditMaskToSqlQuery(ctl.ActiveSQLQuery);
                ShowDetail(ctl, true);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlKaModulTree", "EintragAnzeigenNichtMoeglich", "Der gewünschte Eintrag kann nicht angezeigt werden", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
                barItemLink.Item.Visibility = BarItemVisibility.Never;

            btnDelete.Caption = "Löschen";

            if (DBUtil.UserHasRight("KaNavigNewAbklaerung"))
                btnNewAbklaerung.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewVermittlungInizio"))
                btnNewVermittlungInizio.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewVermittlungBI"))
                btnNewVermittlungBI.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewVermittlungSI"))
                btnNewVermittlungSI.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewJobtimal"))
                btnNewJobtimal.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewEaf"))
                btnNewEaf.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewQualifizierungJ"))
                btnNewQualifizierungJ.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewQualifizierungE"))
                btnNewQualifizierungE.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewTransfer"))
                btnNewTransfer.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("KaNavigNewAssistenz"))
                btnNewAssistenz.Visibility = BarItemVisibility.Always;

            if (kissTree.FocusedNode != null)
            {
                switch (kissTree.FocusedNode.GetValue("ClassName") as string)
                {
                    case "CtlKaProzessAK":
                    case "CtlKaProzessQE":
                    case "CtlKaTransfer":
                    case "CtlKaProzessQJ":
                    case "CtlKaProzessAS":
                    case "CtlKaProzessInizio":
                    case "CtlKaProzessBIBIP":
                    case "CtlKaProzessSI":
                    case "CtlKaProzessJobtimal":
                    case "CtlKaProzessEaf":
                        if (DBUtil.UserHasRight("FrmFallZugriff"))
                            btnFallZugriff.Visibility = BarItemVisibility.Always;

                        if (DBUtil.UserHasRight("FrmFallInfo"))
                            btnFallInfo.Visibility = BarItemVisibility.Always;
                        break;

                    case "CtlDynaMask":
                        switch (kissTree.FocusedNode.GetValue("MaskName") as string)
                        {
                            case "Ka_Allgemein":
                                if (DBUtil.UserHasRight("FrmFallZugriff"))
                                    btnFallZugriff.Visibility = BarItemVisibility.Always;

                                if (DBUtil.UserHasRight("FrmFallInfo"))
                                    btnFallInfo.Visibility = BarItemVisibility.Always;
                                break;
                        }
                        break;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 700)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteAllgemein"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 701)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteAbklaerung"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 702)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteVermittlungInizio"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 703)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteQualifizierungJ"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 704)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteQualifizierungE"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 705)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteVermittlungBI"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 706)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteVermittlungSI"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 707)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteAssistenz"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 708)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteTransfer"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 709 || (int)kissTree.FocusedNode.GetValue("ProzessCode") == 710)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteEaf"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }

                if ((int)kissTree.FocusedNode.GetValue("ProzessCode") == 711)
                {
                    if (DBUtil.UserHasRight("KaNavigDeleteJobtimal"))
                        btnDelete.Visibility = BarItemVisibility.Always;
                }
            }

            if (e.Menu.ItemLinks.Cast<BarItemLink>().Any(barItemLink => barItemLink.Item.Visibility != BarItemVisibility.Never))
            {
                return;
            }
            e.Cancel = true;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var faLeistungID = (int)kissTree.FocusedNode.GetValue("FaLeistungID");
            var prozessCode = (int)kissTree.FocusedNode.GetValue("ProzessCode");
            var zusatz = kissTree.FocusedNode.GetValue("Zusatz").ToString();

            var faLeistungID2 = FindRelatedFaLeistungId(faLeistungID, FaRelationTyp.KaEaf);
            var einsatzVorhanden = DBUtil.ExecuteScalarSQL(@"
                SELECT TOP 1 1
                FROM dbo.KaEinsatz WITH(READUNCOMMITTED)
                WHERE FaLeistungID IN ({0}, {1})",
                faLeistungID,
                faLeistungID2);

            if (!DBUtil.IsEmpty(einsatzVorhanden))
            {
                KissMsg.ShowInfo("CtlKaModulTree", "LoeschenEinsatzVorhanden", "Die Leistung kann nicht gelöscht werden, da sie mit einer Zu-/Anweisung verknüpft ist.");
                return;
            }

            if (prozessCode == 700 && KissMsg.ShowQuestion("CtlKaModulTree", "KAllgemeinLoeschen", "Soll K-Allgemein mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL("DELETE FROM dbo.KaVerlauf WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaAllgemein WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaArbeitsrapport WHERE BaPersonID = {0};", BaPersonID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaZuteilFachbereich WHERE BaPersonID = {0};", BaPersonID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaAmmBesch WHERE BaPersonID = {0};", BaPersonID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaEinsatz WHERE BaPersonID = {0};", BaPersonID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaIntegBildung WHERE BaPersonID = {0};", BaPersonID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaSequenzen WHERE BaPersonID = {0};", BaPersonID);
                    DBUtil.ExecSQL("DELETE FROM dbo.KaAssistenz WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE FROM dbo.DynaValue WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE FROM dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 701 && KissMsg.ShowQuestion("CtlKaModulTree", "AbklaerungLoeschen", "Soll die ganze Abklärung mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL("DELETE KaAbklaerungIntake WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaAbklaerungVertieft WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaAKZuweiser WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 702 && KissMsg.ShowQuestion("CtlKaModulTree", "PhaseInizioLoeschen", "Soll die ganze Phase Inizio mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz WHERE KaVermittlungVorschlagID IN (
                                       SELECT KaVermittlungVorschlagID
                                       FROM KaVermittlungVorschlag
                                       WHERE FaLeistungID = {0})", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungVorschlag WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungProfil WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaInizio WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 703 && KissMsg.ShowQuestion("CtlKaModulTree", "QJLoeschen", "Soll die ganze Qualifizierung Jugend mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL(@"DELETE KaQJIntakeGespraech
                                     WHERE KaQJIntakeID = (SELECT KaQJIntakeID
                                                           FROM dbo.KaQJIntake QJI WITH (READUNCOMMITTED)
                                                           WHERE FaLeistungID = {0})", faLeistungID);
                    DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz where KaVermittlungVorschlagID IN (
                                       SELECT KaVermittlungVorschlagID
                                       FROM KaVermittlungVorschlag
                                       WHERE FaLeistungID = {0})", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungVorschlag WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungProfil WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQJIntake WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQJPZSchlussbericht WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQJPZZielvereinbarung WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQJVereinbarung WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQJProzess WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 704 && KissMsg.ShowQuestion("CtlKaModulTree", "QELoeschen", "Soll die ganze Qualifizierung Erwachsene mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL("DELETE KaQEEPQ WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQEEPQZielvereinb WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQEEPQZielvereinbVerl WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaQEJobtimum WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 705 && KissMsg.ShowQuestion("CtlKaModulTree", "VermittlBILoeschen", "Soll die ganze Vermittlung BI / BIP mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL(@"DELETE dbo.XDocument
                                     WHERE DocumentID IN (SELECT DocumentID_Schlussbericht
                                                          FROM dbo.KaVermittlungBIBIP
                                                          WHERE FaLeistungID = {0});", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.KaVermittlungBIBIP WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.KaKontaktartProzess WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL(@"DELETE dbo.KaVermittlungEinsatz
                                     WHERE KaVermittlungVorschlagID IN (SELECT KaVermittlungVorschlagID
                                                                        FROM dbo.KaVermittlungVorschlag
                                                                        WHERE FaLeistungID = {0});", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.KaVermittlungVorschlag WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.KaVermittlungProfil WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.DynaValue WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 706 && KissMsg.ShowQuestion("CtlKaModulTree", "VermittlSILoeschen", "Soll die ganze Vermittlung SI mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL(@"DELETE KaVermittlungSIZwischenbericht where KaVermittlungVorschlagID IN (
                                     SELECT KaVermittlungVorschlagID
                                     FROM KaVermittlungVorschlag
                                     WHERE FaLeistungID = {0})", faLeistungID);
                    DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz where KaVermittlungVorschlagID IN (
                                     SELECT KaVermittlungVorschlagID
                                     FROM KaVermittlungVorschlag
                                     WHERE FaLeistungID = {0})", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.KaKontaktartProzess WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungVorschlag WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungProfil WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungSI WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);
                    //TODO: cascade delete

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 707 && KissMsg.ShowQuestion("CtlKaModulTree", "AssistenzLoeschen", "Soll die ganze Assistenz mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL("DELETE KaAssistenz WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID); //solange wir die alten DynaValues noch haben... Dieses Statement kann ab 4.4.33 entfernt werden
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);
                    //TODO: cascade delete

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 708 && KissMsg.ShowQuestion("CtlKaModulTree", "TransferLoeschen", "Soll der ganze Transfer mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL("DELETE KaTransfer WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaTransferZielvereinb WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if ((prozessCode == 709 || prozessCode == 710) && KissMsg.ShowQuestion("CtlKaModulTree", "EafLoeschen", "Soll die ganze EAF mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    // Dokumente von KaEafSozioberuflicheBilanz löschen
                    var sozioBil = DBUtil.OpenSQL(@"
                    SELECT
                      DocumentID_ProzessErmittlungsprogramm,
                      DocumentID_ProzessFaehigkeitsprofilMelba,
                      DocumentID_ProzessSchlussbericht,
                      DocumentID_InterventionenVereinbarung,
                      DocumentID_InterventionenVerwarnung1,
                      DocumentID_InterventionenVerwarnung2,
                      DocumentID_InterventionenProgrammabbruch
                    FROM dbo.KaEafSozioberuflicheBilanz WHERE FaLeistungID IN ({0}, {1})", faLeistungID, faLeistungID2);
                    DBUtil.ExecSQL(
                        "DELETE dbo.XDocument WHERE DocumentID IN ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                        sozioBil[DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessErmittlungsprogramm],
                        sozioBil[DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessFaehigkeitsprofilMelba],
                        sozioBil[DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessSchlussbericht],
                        sozioBil[DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenVereinbarung],
                        sozioBil[DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenVerwarnung1],
                        sozioBil[DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenVerwarnung2],
                        sozioBil[DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenProgrammabbruch]);

                    // Dokumente von KaEafSpezifischeErmittlung löschen
                    var spezErm = DBUtil.OpenSQL(@"
                    SELECT
                      DocumentID_ProzessVereinbarung,
                      DocumentID_ProzessSchlussbericht,
                      DocumentID_InterventionenAufforderung1,
                      DocumentID_InterventionenAufforderung2,
                      DocumentID_InterventionenAufforderung3,
                      DocumentID_InterventionenVereinbarung1,
                      DocumentID_InterventionenVereinbarung2,
                      DocumentID_InterventionenVerwarnung1,
                      DocumentID_InterventionenVerwarnung2,
                      DocumentID_InterventionenProgrammabbruch
                    FROM dbo.KaEafSpezifischeErmittlung WHERE FaLeistungID IN ({0}, {1})", faLeistungID, faLeistungID2);
                    DBUtil.ExecSQL(
                        "DELETE dbo.XDocument WHERE DocumentID IN ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})",
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_ProzessVereinbarung],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_ProzessSchlussbericht],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenAufforderung1],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenAufforderung2],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenAufforderung3],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVereinbarung1],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVereinbarung2],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVerwarnung1],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVerwarnung2],
                        spezErm[DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenProgrammabbruch]);

                    // andere Daten löschen
                    DBUtil.ExecSQL("DELETE dbo.KaEafSozioberuflicheBilanz WHERE FaLeistungID IN ({0}, {1})", faLeistungID, faLeistungID2);
                    DBUtil.ExecSQL("DELETE dbo.KaEafSpezifischeErmittlung WHERE FaLeistungID IN ({0}, {1})", faLeistungID, faLeistungID2);
                    DBUtil.ExecSQL("DELETE dbo.FaRelation WHERE FaLeistungID1 = {0} OR FaLeistungID2 = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.DynaValue  WHERE FaLeistungID = {0}", faLeistungID);

                    DBUtil.ExecSQL("DELETE dbo.FaLeistung WHERE FaLeistungID IN ({0}, {1})", faLeistungID, faLeistungID2);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else if (prozessCode == 711 && KissMsg.ShowQuestion("CtlKaModulTree", "JobtimalLoeschen", "Soll das ganze Jobtimal mit allen abhängigen Daten gelöscht werden?"))
            {
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL(@"DELETE KaVermittlungSIZwischenbericht where KaVermittlungVorschlagID IN (
                                     SELECT KaVermittlungVorschlagID
                                     FROM KaVermittlungVorschlag
                                     WHERE FaLeistungID = {0})", faLeistungID);
                    DBUtil.ExecSQL(@"DELETE KaVermittlungEinsatz where KaVermittlungVorschlagID IN (
                                     SELECT KaVermittlungVorschlagID
                                     FROM KaVermittlungVorschlag
                                     WHERE FaLeistungID = {0})", faLeistungID);
                    DBUtil.ExecSQL("DELETE dbo.KaKontaktartProzess WHERE FaLeistungID = {0};", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungVorschlag WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaVermittlungProfil WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE KaJobtimal WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE DynaValue WHERE FaLeistungID = {0}", faLeistungID);
                    DBUtil.ExecSQL("DELETE FaLeistung WHERE FaLeistungID = {0}", faLeistungID);
                    //TODO: cascade delete

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else
            {
                return;
            }

            FillTree();
            if (kissTree.Nodes.Count > 0)
                kissTree.Nodes[0].Expanded = true;

            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnNewAbklaerung && OpenAbklExist())
            {
                KissMsg.ShowInfo("CtlKaModulTree", "OffeneAbklExistiert", "Es existiert bereits eine offene Abklärung!");
                return;
            }

            if (e.Item == btnNewQualifizierungJ && OpenQJExist())
            {
                KissMsg.ShowInfo("CtlKaModulTree", "OffeneQualiExistiert", "Es existiert bereits eine offene Qualifizierung Jugend!");
                return;
            }

            //ist die 'Allgemein'-Phase noch archiviert?
            var leistungArchivID = DBUtil.ExecuteScalarSQL(@"
                SELECT LEA.FaLeistungArchivID
                FROM dbo.FaLeistungArchiv LEA WITH (READUNCOMMITTED)
                    INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = LEA.FaLeistungID
                WHERE LEI.BaPersonID = {0}
                    AND LEI.ModulID = 7
                    AND LEI.FaProzessCode = 700
                    AND LEA.CheckOut IS NULL", BaPersonID) as int?;
            if (leistungArchivID.HasValue)
            {
                //Allgemeine Leistung is archived. The user has to take it out before adding a new Leistung.
                KissMsg.ShowInfo("CtlKaModulTree", "AllgemeineLeistungArchiviert", "Die Phase Allgemein ist noch archiviert. Sie muss zuerst aus dem Archiv zurückgeholt werden.");
                return;
            }

            DBUtil.NewHistoryVersion();

            // Set the SichtbarSDFlag in Basis
            if (KissMsg.ShowQuestion("CtlKaModulTree", "ZuweiserVonBern", "Ist der Zuweiser vom SD Bern?"))
            {
                // Data visible for SD Bern
                DBUtil.ExecSQL(@"
                        UPDATE BaPerson
                        SET    SichtbarSDFlag = 1, Modifier = {0}, Modified = GetDate()
                        WHERE  BaPersonID = {1}",
                    DBUtil.GetDBRowCreatorModifier(), BaPersonID);
            }
            else
            {
                // Data not visible for SD Bern
                DBUtil.ExecSQL(@"
                        UPDATE BaPerson
                        SET    SichtbarSDFlag = 0, Modifier = {0}, Modified = GetDate()
                        WHERE  BaPersonID = {1}",
                    DBUtil.GetDBRowCreatorModifier(), BaPersonID);
            }

            int faProzessCode;
            int? faProzessCodeZus = null;
            var faRelationTyp = 0;

            if (e.Item == btnNewAbklaerung)
                faProzessCode = 701;
            else if (e.Item == btnNewVermittlungInizio)
                faProzessCode = 702;
            else if (e.Item == btnNewQualifizierungJ)
                faProzessCode = 703;
            else if (e.Item == btnNewQualifizierungE)
                faProzessCode = 704;
            else if (e.Item == btnNewVermittlungBI)
                faProzessCode = 705;
            else if (e.Item == btnNewVermittlungSI)
                faProzessCode = 706;
            else if (e.Item == btnNewAssistenz)
                faProzessCode = 707;
            else if (e.Item == btnNewTransfer)
                faProzessCode = 708;
            else if (e.Item == btnNewEaf)
            {
                faProzessCode = 709;
                faProzessCodeZus = 710;
                faRelationTyp = 1;
            }
            else if (e.Item == btnNewJobtimal)
                faProzessCode = 711;
            else
                return;

            _oldPersSichtbar = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT PersonSichtbarSDFlag
                        FROM dbo.BaPerson
                        WHERE BaPersonID = {0}",
                        BaPersonID));

            InsertAllgemein();

            var id1 = InsertLeistung(faProzessCode);

            if (faProzessCodeZus.HasValue)
            {
                var id2 = InsertLeistung(faProzessCodeZus.Value);
                InsertRelation(id1, id2, faRelationTyp, true);
            }

            DBUtil.ExecSQL(@"UPDATE BaPerson SET PersonSichtbarSDFlag = {0}, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {2}", _oldPersSichtbar, DBUtil.GetDBRowCreatorModifier(), BaPersonID);

            //refresh Navigator und Neupositionierung auf neuen Eintrag
            kissTree.DataSource = null; //sonst Exception: open DataReader!
            FillTree();

            var node = DBUtil.FindNodeByValue(kissTree.Nodes, Convert.ToString(faProzessCode), "ProzessCode");
            if (node != null)
            {
                kissTree.FocusedNode = node;
                node.Expanded = true;
            }
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
        }

        private void btnThemen_Click(object sender, EventArgs e)
        {
            _themenUpdate = true;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chlThemen.Items)
            {
                if (sender == btnAlleThemen)
                {
                    item.CheckState = CheckState.Checked;
                }
                if (sender == btnKeineThemen)
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }
            _themenUpdate = false;
            ApplyThemenFilter();
        }

        private void chkThemenfilter_CheckedChanged(object sender, EventArgs e)
        {
            SetThemenLayout();
            ApplyThemenFilter();
        }

        private void chkThemenfilter_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //Detaildaten müssen zuerst gespeichert werden, bevor Themenfilter ein/aus
            if (DetailControl is CtlDynaMask)
            {
                e.Cancel = !DetailControl.OnSaveData();
            }
        }

        private void chlThemen_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_themenUpdate)
            {
                return;
            }

            ApplyThemenFilter();
        }

        private void CtlKaModulTree_DetailChanged(object sender, EventArgs e)
        {
            //Only display the 'Themenfilter', if there is a Dynamask holding any controls
            if (DetailControl is CtlDynaMask
                && DetailControl.Controls.Count != 0)
            {
                ShowThemenFilter();
            }
            else
            {
                HideThemenFilter();
            }
        }

        private void CtlKaModulTree_Load(object sender, EventArgs e)
        {
            kissTree.DataSource = null; //sonst Exception: open DataReader!
            FillTree();

            // Expand all nodes which are open!!
            SqlQuery qry1 = DBUtil.OpenSQL(@"
                SELECT LST.FaProzessCode
                FROM FaLeistung LST WITH(READUNCOMMITTED)
                WHERE LST.BaPersonID = {0}
                  AND LST.ModulID = 7
                  AND LST.DatumBis IS NULL
                  AND LST.FaProzessCode IS NOT NULL
                ORDER BY LST.DatumVon ASC", BaPersonID);

            foreach (DataRow r1 in qry1.DataTable.Rows)
            {
                var node = DBUtil.FindNodeByValue(kissTree.Nodes, r1["FaProzessCode"].ToString(), "ProzessCode");
                if (node != null)
                {
                    kissTree.FocusedNode = node;

                    if (r1["FaProzessCode"].ToString().Equals("700"))
                        node.ExpandAll();
                    else
                        node.Expanded = true;
                }
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void ApplyThemenFilter()
        {
            var ctlDynaMask = DetailControl as CtlDynaMask;
            if (ctlDynaMask != null)
            {
                ctlDynaMask.SetThemenFilter(chkThemenfilter.Checked, chlThemen.EditValue);
            }
        }

        private int FindRelatedFaLeistungId(int faLeistungId, FaRelationTyp faRelationTyp)
        {
            return Utils.ConvertToInt(
                DBUtil.ExecuteScalarSQL(@"
                    SELECT FaLeistungID = CASE
                                            WHEN FaLeistungID1 = {0} THEN FaLeistungID2
                                            ELSE FaLeistungID1
                                          END
                    FROM dbo.FaRelation WITH (READUNCOMMITTED)
                    WHERE FaRelationTypCode = {1}
                      AND (FaLeistungID1 = {0}
                           OR FaLeistungID2 = {0});",
                    faLeistungId,
                    (int)faRelationTyp));
        }

        /// <summary>
        /// Versteckt den Themenfilter.
        /// </summary>
        private void HideThemenFilter()
        {
            pnlThemenfilter.Visible = false;
            pnlThemenfilter.Visible = false;
        }

        private void InsertAllgemein()
        {
            var insertProzess = (int)DBUtil.ExecuteScalarSQL(
                @"SELECT COUNT(*)
                  FROM dbo.FaLeistung LST
                  WHERE LST.BaPersonID = {0}
                    AND LST.ModulID = 7
                    AND LST.FaProzessCode = 700"
                , BaPersonID) == 0;

            if (insertProzess)
            {
                DBUtil.ExecSQL(@"
                    INSERT FaLeistung (BaPersonID, ModulID, UserID, DatumVon, FaProzessCode, FaFallID, Creator, Created, Modifier, Modified)
                    VALUES ({0}, 7, {1}, GETDATE(), 700, {0}, {2}, GETDATE(), {2}, GETDATE())",
                    BaPersonID,
                    Session.User.UserID,
                    DBUtil.GetDBRowCreatorModifier());
            }
            else
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = NULL, Modifier = {1}, Modified = GETDATE() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }
        }

        private int InsertLeistung(int faProzessCode)
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(
                @"INSERT FaLeistung (BaPersonID, ModulID, UserID, DatumVon, FaProzessCode, FaFallID, Creator, Created, Modifier, Modified)
                      VALUES ({0}, 7, {1}, dbo.fnDateOf(getdate()), {2}, {3}, {4}, getdate(), {4}, getdate());
                      SELECT SCOPE_IDENTITY();",
                BaPersonID,
                Session.User.UserID,
                faProzessCode,
                BaPersonID,
                DBUtil.GetDBRowCreatorModifier()));
        }

        private void InsertRelation(int id1, int id2, int faRelationTyp, bool cascadeUpdate)
        {
            DBUtil.ExecSQL(
                @"INSERT FaRelation(FaLeistungID1, FaLeistungID2, FaRelationTypCode, CascadeUpdate, Creator, Created, Modifier, Modified)
                  VALUES ({0}, {1}, {2}, {3}, {4}, GETDATE(), {4}, GETDATE());",
                id1,
                id2,
                faRelationTyp,
                cascadeUpdate,
                DBUtil.GetDBRowCreatorModifier());
        }

        private bool OpenAbklExist()
        {
            var cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM FaLeistung FAL
                    WHERE FAL.ModulID = 7
                      AND FAL.FaProzessCode = 701
                      AND FAL.DatumBis IS NULL
                      AND FAL.BaPersonID = {0}"
                , BaPersonID));
            return cnt > 0;
        }

        private bool OpenQJExist()
        {
            var cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM FaLeistung FAL
                    WHERE FAL.ModulID = 7
                      AND FAL.FaProzessCode = 703
                      AND FAL.DatumBis IS NULL
                      AND FAL.BaPersonID = {0}"
                , BaPersonID));
            return cnt > 0;
        }

        private void SetThemenLayout()
        {
            if (chkThemenfilter.Checked)
            {
                pnlThemen.Height = 40 + chlThemen.Items.Count * 20;
            }
            else
            {
                pnlThemen.Height = 0;
            }
        }

        /// <summary>
        /// Zeigt den Themenfilter.
        /// </summary>
        private void ShowThemenFilter()
        {
            pnlThemenfilter.Visible = chkThemenfilter.Checked;
            pnlThemenfilter.Visible = true;
        }

        #endregion

        #endregion
    }
}