using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    public partial class CtlKesModulTree : KissModulTree
    {
        private const string CLASSNAME = "CtlKesModulTree";

        public CtlKesModulTree(int baPersonID, int faFallID, Panel panDetail)
            : base(baPersonID, faFallID, panDetail, 29)
        {
            InitializeComponent();

            FillTree(0);
        }

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
                IKissView ctl = null;

                if (className != null)
                {
                    var forceDispose = false;

                    var id = e.Node.GetValue("ID") as string;

                    var faLeistungID = e.Node.GetValue("FaLeistungID");
                    var baPersonID = e.Node.GetValue("BaPersonID");

                    // Neue WPF Masken (XAML)
                    var initParams = new InitParameters
                    {
                        BaPersonID = baPersonID as int?,
                        FaLeistungID = faLeistungID as int?,
                        Title = titel,
                    };
                    var xclassID = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID(className);
                    if (xclassID.HasValue)
                    {
                        var view = new CtlWpfHost(xclassID.Value, initParams);
                        ShowDetail(view, true);
                        return;
                    }

                    var type = AssemblyLoader.GetType(className);

                    // WPF Masken nach alt-neu (XAML).
                    if (CtlWpfMask.IsWpfView(type))
                    {
                        ctl = CtlWpfMask.CreateWpfView(type, new InitParameters
                        {
                            BaPersonID = baPersonID as int?,
                            FaLeistungID = faLeistungID as int?
                        });
                        ShowDetail(ctl, true); //Force dispose auf true, sonst gibt es ein Memory Leak.
                        return;
                    }

                    if (type != null)
                    {
                        ctl = _showDetail.GetDetailControl(type, true);
                        ctl.Name = titel;
                    }

                    if (ctl == null || id != null && id.StartsWith("X"))
                    {
                        ShowDetail(ctl);
                        return;
                    }

                    var vmSiegelungID = e.Node.GetValue("VmSiegelungID");
                    var vmTestamentID = e.Node.GetValue("VmTestamentID");
                    var vmErbschaftsdienstID = e.Node.GetValue("VmErbschaftsdienstID");

                    if (className == "CtlVmRevisionen" && !DBUtil.GetConfigBool(@"System\Vormundschaft\SeparaterMandantenstamm", true))
                    {
                        className = "CtlVmRevisionen2";
                    }

                    switch (className)
                    {
                        case "CtlDynaMask":
                            var maskName = e.Node.GetValue("MaskName") as string;
                            var ctlDynaMask = (CtlDynaMask)ctl;

                            ctlDynaMask.Init(titel, imgIcon, (int)faLeistungID, 0, maskName, false, null);

                            ActiveSQLQuery = ctlDynaMask.ActiveSQLQuery;
                            ShowDetail(ctlDynaMask, true);
                            ctlDynaMask.ResizeControls();
                            return;

                        case "CtlVmBarauszahlungGeplant":
                            if (faLeistungID is int && baPersonID is int)
                            {
                                forceDispose = true;
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)faLeistungID, (int)baPersonID);
                            }
                            break;

                        case "CtlVmProzess": // TODO: System && FaProzessCode < 10
                        case "CtlVmRevisionen":
                        case "CtlVmRevisionen2":
                        case "CtlVmBewertung":
                        case "CtlVmErblasser":
                            if (faLeistungID is int)
                            {
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)faLeistungID);
                            }
                            break;

                        case "CtlVmMandant":
                        case "CtlVmVaterschaftVerlauf":
                        case "CtlVmBarauszahlungErfolgt":
                            if (faLeistungID is int)
                            {
                                forceDispose = true;
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)faLeistungID);
                            }
                            break;

                        case "CtlVmSiegelung":
                            if (faLeistungID is int && vmSiegelungID is int)
                            {
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)vmSiegelungID);
                            }
                            break;

                        case "CtlVmErbe":
                            if (faLeistungID is int)
                            {
                                forceDispose = true;
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, faLeistungID, vmSiegelungID, vmTestamentID, vmErbschaftsdienstID);
                            }

                            break;

                        case "CtlVmTestament":
                        case "CtlVmTestamentVerfuegung":
                            if (vmTestamentID is int)
                            {
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)vmTestamentID);
                            }
                            break;

                        case "CtlVmTestamentBescheinigung":
                            if (vmTestamentID is int && baPersonID is int && faLeistungID is int)
                            {
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)baPersonID, (int)faLeistungID, (int)vmTestamentID);
                            }
                            break;

                        case "CtlVmErbschaftsdienst":
                            if (vmErbschaftsdienstID is int)
                            {
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)vmErbschaftsdienstID);
                            }
                            break;

                        case "CtlFaDokumente":
                        case "CtlFaAktennotiz":
                        case "CtlVmKlientenBudget":
                        case "CtlVmInventar":
                        case "CtlVmMassnahmen":
                        case "CtlVmSchulden":
                        case "CtlVmBudget":
                        case "CtlVmSteuern":
                        case "CtlVmSozialversicherung":
                        case "CtlVmELKrankheitskosten":
                        case "CtlVmAntragEksk":
                        case "CtlVmBeschwerdeAnfrage":
                        case "CtlVmSachversicherung":
                        case "CtlVmSituationsbericht":
                        case "CtlVmGefaehrdungsmeldung":
                        case "CtlVmMandBericht":
                        case "CtlVmAHVMindestbeitraege":
                        case "CtlKesMassnahme":
                            forceDispose = true;
                            AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)baPersonID, (int)faLeistungID);
                            break;

                        case "CtlFibuBuchung":
                            AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)baPersonID);
                            break;

                        case "CtlFibuKontoblatt":
                            AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, (int)baPersonID);
                            break;

                        default:
                            try
                            {
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon);
                                break;
                            }
                            catch
                            {
                                break;
                            }
                    }

                    ShowDetail(ctl, forceDispose);
                }
                else
                {
                    ShowDetail(null);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            btnDelete.Caption = KissMsg.GetMLMessage(CLASSNAME, "BtnDeleteCaption", "Löschen");

            if (DBUtil.UserHasRight("KesNavigNewKindesUndErwachsenenschutz"))
            {
                btnNewKes.Visibility = BarItemVisibility.Always;
            }

            if (kissTree.FocusedNode != null)
            {
                btnDelete.Caption = string.Format(KissMsg.GetMLMessage(CLASSNAME, "BtnDeleteContextCaption", "{0} löschen"), kissTree.FocusedNode.GetDisplayText("Name"));

                bool deleteEnabled = false;

                var className = kissTree.FocusedNode.GetValue("ClassName") as string;

                if (className != null && className.Contains("Kiss.UserInterface.View.Kes.KesLeistungView"))
                {
                    if (DBUtil.UserHasRight("FrmFallZugriff"))
                    {
                        btnFallZugriff.Visibility = BarItemVisibility.Always;
                    }

                    if (DBUtil.UserHasRight("FrmFallInfo"))
                    {
                        btnFallInfo.Visibility = BarItemVisibility.Always;
                    }

                    var code = kissTree.FocusedNode.GetValue("FaProzessCode");

                    if (!DBUtil.IsEmpty(code))
                    {
                        var faProzessCode = (int)code;

                        if (faProzessCode == 2900) // Kindes- und Erwachsenenschutz
                        {
                            if (DBUtil.UserHasRight("KesNavigDeleteKindesUndErwachsenenschutz"))
                            {
                                deleteEnabled = true;
                            }
                        }
                    }
                }

                if (deleteEnabled)
                {
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
            var faProzessCode = (int)kissTree.FocusedNode.GetValue("FaProzessCode");

            if (faProzessCode == 2900)
            {
                // Barauszahlungen prüfen
                var auszahlungenVorhanden = DBUtil.ExecuteScalarSQL(@"
                    SELECT TOP 1 1
                    FROM dbo.FbBarauszahlungAuftrag
                    WHERE AuszahlungenVorhanden = 1
                      AND FaLeistungID = {0};", faLeistungID);

                if (!DBUtil.IsEmpty(auszahlungenVorhanden))
                {
                    KissMsg.ShowInfo(CLASSNAME, "KesLoeschenBarauszahlungVorhanden", "Die KES-Leistung kann nicht gelöscht werden, weil bereits eine Barauszahlung erfolgte.");
                    return;
                }

                // Abhängige Daten prüfen
                var datenVorhanden = DBUtil.ExecuteScalarSQL(@"
                    SELECT TOP 1 1
                    FROM dbo.FaLeistung                     LEI
                      LEFT JOIN dbo.KesAuftrag              AUF ON AUF.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.KesMassnahme            MAS ON MAS.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.KesPflegekinderaufsicht PFL ON PFL.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.KesDokument             DOK ON DOK.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.KesPraevention          PRA ON PRA.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.KesVerlauf              VER ON VER.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.VmBudget                VBU ON VBU.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.VmSchulden              SCH ON SCH.FaLeistungID = LEI.FaLeistungID
                      LEFT JOIN dbo.FbBarauszahlungAuftrag  FBA ON FBA.FaLeistungID = LEI.FaLeistungID
                    WHERE LEI.FaLeistungID = {0}
                      AND (AUF.FaLeistungID IS NOT NULL OR
                           MAS.FaLeistungID IS NOT NULL OR
                           PFL.FaLeistungID IS NOT NULL OR
                           DOK.FaLeistungID IS NOT NULL OR
                           PRA.FaLeistungID IS NOT NULL OR
                           VER.FaLeistungID IS NOT NULL OR
                           VBU.FaLeistungID IS NOT NULL OR
                           SCH.FaLeistungID IS NOT NULL OR
                           FBA.FaLeistungID IS NOT NULL);", faLeistungID);

                if (!DBUtil.IsEmpty(datenVorhanden))
                {
                    KissMsg.ShowInfo(CLASSNAME, "KesLoeschenAbhaengigeDaten", "Die KES-Leistung kann nicht gelöscht werden, weil noch abhängige Daten vorhanden sind.");
                    return;
                }

                // Löschen
                Session.BeginTransaction();
                try
                {
                    DBUtil.ExecSQL(@"
                        DELETE dbo.FbBarauszahlungZyklus WHERE FbBarauszahlungAuftragID IN (SELECT FbBarauszahlungAuftragID FROM dbo.FbBarauszahlungAuftrag WHERE FaLeistungID = {0});
                        DELETE dbo.FbBarauszahlungAuftrag WHERE FaLeistungID = {0};
                        DELETE dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);
                    Session.Commit();
                }
                catch (System.Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
            else
            {
                return;
            }

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");

            FillTree();

            if (kissTree.Nodes.Count > 0)
            {
                kissTree.Nodes[0].Expanded = true;
            }
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //neue Kes-Leistung nur möglich, falls bereits eine Fallführung existiert
            var count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = 2;", BaPersonID);

            if (count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "NeueKesLeistungNichtMoeglich", "Ohne Fallführung kann kein neuer Kindes- und Erwachsenenschutz erzeugt werden.\r\nBitte via Fall-Navigator und 'Neuer Fall' eine neue Fallführung anlegen");
                return;
            }

            int faProzessCode;

            if (e.Item == btnNewKes)
            {
                faProzessCode = 2900;
            }
            else
            {
                return;
            }

            // Wenn noch eine offene Kes-Leistung existiert soll keine neue angelegt werden
            var offenesKes = DBUtil.ExecuteScalarSQL(@"
                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                           WHERE BaPersonID = {0}
                             AND ModulID = {1}
                             AND FaProzessCode = {2}
                             AND DatumBis IS NULL))
                BEGIN
                    SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                    SELECT CONVERT(BIT, 0);
                END;",
                BaPersonID,
                ModulID,
                faProzessCode) as bool? ?? false;

            if (offenesKes)
            {
                KissMsg.ShowInfo(CLASSNAME, "OffenerKindesUndErwachsenenschutz", "Der letzte Kindes- und Erwachsenenschutz ist noch nicht abgeschlossen.");
                return;
            }

            // Leistung erstellen
            DBUtil.ExecSQL(@"
                INSERT INTO dbo.FaLeistung (FaFallID, BaPersonID, ModulID, FaProzessCode, DatumVon, UserID, Creator, Created, Modifier, Modified)
                  SELECT TOP 1 FaFallID, BaPersonID, {4}, {2}, dbo.fnDateOf(GETDATE()), {1}, {3}, GETDATE(), {3}, GETDATE()
                  FROM dbo.FaFall WITH(READUNCOMMITTED)
                  WHERE BaPersonID = {0}
                  ORDER BY DatumBis, DatumVon DESC;",
                BaPersonID,
                Session.User.UserID,
                faProzessCode,
                DBUtil.GetDBRowCreatorModifier(),
                (int)Gui.ModulID.Kes);

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");

            //refresh Navigator und Neupositionierung auf neuen Eintrag
            //kissTree.DataSource = null; //sonst Exception: open DataReader!
            //FillTree();
            var node = DBUtil.FindNodeByValue(kissTree.Nodes, faProzessCode.ToString(), "FaProzessCode");

            if (node != null)
            {
                kissTree.FocusedNode = node;
                node.Expanded = true;
            }
        }
    }
}