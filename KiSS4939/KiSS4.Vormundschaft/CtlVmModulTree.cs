using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmModulTree : KissModulTree
    {
        #region Constructors

        public CtlVmModulTree(int baPersonID, int faFallID, Panel panDetail)
            : base(baPersonID, faFallID, panDetail, 5)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            FillTree(0);

            //Replace Captions for popup menu entries
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Code, Value1
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'FaProzess'
                  AND Value1 IS NOT NULL;");

            foreach (DataRow row in qry.DataTable.Rows)
            {
                switch (Convert.ToInt32(row["Code"]))
                {
                    case 501:
                        btnNewMassnahme.Caption = row["Value1"].ToString();
                        break;

                    case 502:
                        btnNewVaterschaftsabklaerung.Caption = row["Value1"].ToString();
                        break;

                    case 503:
                        btnNewErbschaft.Caption = row["Value1"].ToString();
                        break;

                    case 504:
                        btnNewPflegekind.Caption = row["Value1"].ToString();
                        break;

                    case 505:
                        btnNewAuftrag.Caption = row["Value1"].ToString();
                        break;

                    case 531:
                        btnNeueSiegelung.Caption = row["Value1"].ToString();
                        break;

                    case 532:
                        btnNeuesTestament.Caption = row["Value1"].ToString();
                        break;

                    case 533:
                        btnNeuerErbschaftsdienst.Caption = row["Value1"].ToString();
                        break;
                }
            }
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
                IKissView ctl = null;

                if (className != null)
                {
                    if (className == "CtlVmRevisionen" && !DBUtil.GetConfigBool(@"System\Vormundschaft\SeparaterMandantenstamm", true))
                    {
                        className = "CtlVmRevisionen2";
                    }

                    bool forceDispose = false;

                    var id = e.Node.GetValue("ID") as string;

                    object faLeistungID = e.Node.GetValue("FaLeistungID");
                    object baPersonID = e.Node.GetValue("BaPersonID");

                    object vmSiegelungID = e.Node.GetValue("VmSiegelungID");
                    object vmTestamentID = e.Node.GetValue("VmTestamentID");
                    object vmErbschaftsdienstID = e.Node.GetValue("VmErbschaftsdienstID");

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

                    // Neue WPF Masken (XAML).
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
                                AssemblyLoader.InvokeMethode(ctl, "Init", titel, imgIcon, Convert.ToInt32(faLeistungID));
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

                        //string maskName, Image maskImage, int PersonID, int LeistungID

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

            btnDelete.Caption = "Löschen";

            if (DBUtil.UserHasRight("VmNavigNewMassnahme"))
            {
                btnNewMassnahme.Visibility = BarItemVisibility.Always;
            }

            if (DBUtil.UserHasRight("VmNavigNewVaterschaft"))
            {
                btnNewVaterschaftsabklaerung.Visibility = BarItemVisibility.Always;
            }

            if (DBUtil.UserHasRight("VmNavigNewErbschaft"))
            {
                btnNewErbschaft.Visibility = BarItemVisibility.Always;
            }

            if (DBUtil.UserHasRight("VmNavigNewPflegekind"))
            {
                btnNewPflegekind.Visibility = BarItemVisibility.Always;
            }

            if (DBUtil.UserHasRight("VmNavigNewVmAuftrag"))
            {
                btnNewAuftrag.Visibility = BarItemVisibility.Always;
            }

            if (kissTree.FocusedNode != null)
            {
                btnDelete.Caption = kissTree.FocusedNode.GetDisplayText("Name") + " löschen";

                bool deleteEnabled = false;

                var className = kissTree.FocusedNode.GetValue("ClassName") as string;

                if (className == typeof(CtlVmProzess).Name) // Leistung
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

                    //Don't do anything if empty; Fix for Mantis Ticket 4077
                    if (!DBUtil.IsEmpty(code))
                    {
                        int faProzessCode = (int)code;

                        if (faProzessCode == 501) // Massnahme
                        {
                            if (DBUtil.UserHasRight("VmNavigDeleteMassnahme"))
                            {
                                deleteEnabled = true;
                            }
                        }
                        else if (faProzessCode == 502) // Vaterschaft
                        {
                            if (DBUtil.UserHasRight("VmNavigDeleteVaterschaft"))
                            {
                                deleteEnabled = true;
                            }
                        }
                        else if (faProzessCode == 503) // Erbschaft
                        {
                            if (DBUtil.UserHasRight("VmNavigDeleteErbschaft"))
                            {
                                deleteEnabled = true;
                            }

                            if (DBUtil.UserHasRight("VmNavigNewSiegelung"))
                            {
                                btnNeueSiegelung.Visibility = BarItemVisibility.Always;
                            }

                            if (DBUtil.UserHasRight("VmNavigNewTestament"))
                            {
                                btnNeuesTestament.Visibility = BarItemVisibility.Always;
                            }

                            if (DBUtil.UserHasRight("VmNavigNewErbschaftsdienst"))
                            {
                                btnNeuerErbschaftsdienst.Visibility = BarItemVisibility.Always;
                            }
                        }
                        else if (faProzessCode == 504) // Pflegekinder
                        {
                            if (DBUtil.UserHasRight("VmNavigDeletePflegekind"))
                            {
                                deleteEnabled = true;
                            }
                        }
                        else if (faProzessCode == 505) // Auftrag
                        {
                            if (DBUtil.UserHasRight("VmNavigVmAuftrag") || DBUtil.UserHasRight("VmNavigDeleteAuftrag"))
                            {
                                deleteEnabled = true;
                            }
                        }
                    }
                }
                else if (className == typeof(CtlVmErbschaftsdienst).Name)
                {
                    object vmErbschaftsdienstID = kissTree.FocusedNode.GetValue("VmErbschaftsdienstID");

                    if (vmErbschaftsdienstID is int && DBUtil.UserHasRight("VmNavigDeleteErbschaftsdienst"))
                    {
                        deleteEnabled = true;
                    }
                }
                else if (className == typeof(CtlVmTestament).Name)
                {
                    object vmTestamentID = kissTree.FocusedNode.GetValue("VmTestamentID");

                    if (vmTestamentID is int && DBUtil.UserHasRight("VmNavigDeleteTestament"))
                    {
                        deleteEnabled = true;
                    }
                }
                else if (className == typeof(CtlVmSiegelung).Name)
                {
                    object vmSiegelungID = kissTree.FocusedNode.GetValue("VmSiegelungID");

                    if (vmSiegelungID is int && DBUtil.UserHasRight("VmNavigDeleteSiegelung"))
                    {
                        deleteEnabled = true;
                    }
                }

                if (deleteEnabled)
                {
                    btnDelete.Visibility = BarItemVisibility.Always;
                }
            }

            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                if (barItemLink.Item.Visibility != BarItemVisibility.Never)
                {
                    return;
                }
            }

            e.Cancel = true;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var faLeistungID = (int)kissTree.FocusedNode.GetValue("FaLeistungID");
            var faProzessCode = (int)kissTree.FocusedNode.GetValue("FaProzessCode");
            var zusatz = kissTree.FocusedNode.GetValue("Zusatz").ToString();

            if (faProzessCode == 501)
            {
                // Abfrage, ob bereits eine Barauszahlung erfolgte
                var qry = new SqlQuery();
                qry.Fill("SELECT AuszahlungenVorhanden FROM dbo.FbBarauszahlungAuftrag WHERE FaLeistungID = {0};", faLeistungID);

                if (!DBUtil.IsEmpty(qry[DBO.FbBarauszahlungAuftrag.AuszahlungenVorhanden]) && (bool)qry[DBO.FbBarauszahlungAuftrag.AuszahlungenVorhanden])
                {
                    KissMsg.ShowInfo("CtlVmModulTree", "VormundMassnahmenLoeschenBarauszahlung", "Die vormundschaftliche Massnahme kann nicht gelöscht werden, weil bereits eine Barauszahlung erfolgte.");
                }
                else if (KissMsg.ShowQuestion("CtlVmModulTree", "VormundMassnahmenLoeschen", "Soll die ganze vormundschaftliche Massnahme mit allen abhängigen Daten gelöscht werden?"))
                {
                    DBUtil.ExecSQL(@"
                        DELETE dbo.DynaValue WHERE FaLeistungID = {0};
                        DELETE dbo.VmErnennung WHERE VmMassnahmeID IN (SELECT VmMassnahmeID FROM dbo.VmMassnahme WHERE FaLeistungID = {0});
                        DELETE dbo.VmMassnahme WHERE FaLeistungID = {0};
                        DELETE dbo.VmBericht WHERE FaLeistungID = {0};
                        DELETE dbo.FbBarauszahlungZyklus WHERE FbBarauszahlungAuftragID IN (SELECT FbBarauszahlungAuftragID FROM dbo.FbBarauszahlungAuftrag WHERE FaLeistungID = {0});
                        DELETE dbo.FbBarauszahlungAuftrag WHERE FaLeistungID = {0};
                        DELETE dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);
                }
            }
            else if (faProzessCode == 502 && KissMsg.ShowQuestion("CtlVmModulTree", "VaterschaftsabklaerungLoeschen", "Soll die ganze Vaterschaftsabklärung mit allen abhängigen Daten gelöscht werden?"))
            {
                DBUtil.ExecSQL(@"
                    DELETE dbo.DynaValue WHERE FaLeistungID = {0};
                    DELETE dbo.VmVaterschaft WHERE FaLeistungID = {0};
                    DELETE dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);
            }
            else if (faProzessCode == 503 && KissMsg.ShowQuestion("CtlVmModulTree", "ErbschaftLoeschen", "Soll die ganze Erbschaft mit allen abhängigen Daten gelöscht werden?"))
            {
                DBUtil.ExecSQL(@"
                    DELETE dbo.DynaValue WHERE FaLeistungID = {0};
                    DELETE dbo.VmErbe WHERE VmSiegelungID IN (SELECT VmSiegelungID FROM dbo.VmSiegelung WHERE FaLeistungID = {0});
                    DELETE dbo.VmErbe WHERE VmTestamentID IN (SELECT VmTestamentID FROM dbo.VmTestament WHERE FaLeistungID = {0});
                    DELETE dbo.VmErbe WHERE VmErbschaftsdienstID IN (SELECT VmErbschaftsdienstID FROM dbo.VmErbschaftsdienst WHERE FaLeistungID = {0});
                    DELETE dbo.VmTestament WHERE FaLeistungID = {0};
                    DELETE dbo.VmSiegelung WHERE FaLeistungID = {0};
                    DELETE dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);
            }
            else if (faProzessCode == 531 && KissMsg.ShowQuestion("CtlVmModulTree", "SiegelungsdienstLoeschen", "Soll der Siegelungsdienst {0} gelöscht werden?", 0, 0, true, zusatz))
            {
                object vmSiegelungID = kissTree.FocusedNode.GetValue("VmSiegelungID");

                DBUtil.ExecSQL(@"
                    DELETE dbo.VmErbe WHERE VmSiegelungID = {0};
                    DELETE dbo.VmSiegelung WHERE VmSiegelungID = {0};", vmSiegelungID);
            }
            else if (faProzessCode == 532 && KissMsg.ShowQuestion("CtlVmModulTree", "TestamentsdienstLoeschen", "Soll der Testamentsdienst {0} gelöscht werden?", 0, 0, true, zusatz))
            {
                object vmTestamentID = kissTree.FocusedNode.GetValue("VmTestamentID");

                DBUtil.ExecSQL(@"
                    DELETE dbo.VmErbe WHERE VmTestamentID = {0};
                    DELETE dbo.VmTestament WHERE VmTestamentID = {0};", vmTestamentID);
            }
            else if (faProzessCode == 533 && KissMsg.ShowQuestion("CtlVmModulTree", "ErbschaftsdienstLoeschen", "Soll der Erbschaftsdienst {0} gelöscht werden?", 0, 0, true, zusatz))
            {
                object vmErbschaftsdienstID = kissTree.FocusedNode.GetValue("VmErbschaftsdienstID");

                DBUtil.ExecSQL(@"
                    DELETE dbo.VmErbe WHERE VmErbschaftsdienstID = {0};
                    DELETE dbo.VmErbschaftsdienst WHERE VmErbschaftsdienstID = {0};", vmErbschaftsdienstID);
            }
            else if (faProzessCode == 504 && KissMsg.ShowQuestion("CtlVmModulTree", "PflegekindprozessLoeschen", "Soll der ganze Pflegekind-Prozess mit allen abhängigen Daten gelöscht werden?"))
            {
                DBUtil.ExecSQL(@"
                    DELETE dbo.DynaValue WHERE FaLeistungID = {0};
                    DELETE dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);
            }
            else if (faProzessCode == 505 && KissMsg.ShowQuestion("CtlVmModulTree", "VormundAuftragLoeschen", "Soll der ganze vormundschaftliche Auftrag mit allen abhängigen Daten gelöscht werden?"))
            {
                DBUtil.ExecSQL(@"
                    DELETE dbo.DynaValue WHERE FaLeistungID = {0};
                    DELETE dbo.FaLeistung WHERE FaLeistungID = {0};", faLeistungID);
            }
            else
            {
                return;
            }

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            FillTree();

            if (kissTree.Nodes.Count > 0)
            {
                kissTree.Nodes[0].Expanded = true;
            }
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //neue Vormundschaft nur möglich, falls bereits eine Fallführung (aktiv oder passiv) existiert
            var count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = 2;", BaPersonID);

            if (count == 0)
            {
                KissMsg.ShowInfo("CtlVmModulTree", "NeuerProzessNichtMoeglich", "Ohne Fallführung kann kein neuer Vormundschafts-Prozess erzeugt werden.\r\nBitte via Fall-Navigator und 'Neuer Fall' eine neue Fallführung anlegen");
                return;
            }

            int faProzessCode;

            if (e.Item == btnNewMassnahme)
                faProzessCode = 501;
            else if (e.Item == btnNewVaterschaftsabklaerung)
                faProzessCode = 502;
            else if (e.Item == btnNewErbschaft)
                faProzessCode = 503;
            else if (e.Item == btnNewPflegekind)
                faProzessCode = 504;
            else if (e.Item == btnNewAuftrag)
                faProzessCode = 505;
            else
                return;

            //prüfen, ob ein ProzessCode mehrfach erfasst werden kann  (vormundsch. Massnahme / Vaterschaftsabklärung)
            if (faProzessCode == 501 || faProzessCode == 502)
            {
                var count2 = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                    WHERE BaPersonID = {0}
                      AND ModulID = 5
                      AND DatumBis IS NULL
                      AND FaProzessCode = {1};",
                    BaPersonID,
                    faProzessCode);

                if (faProzessCode == 501)
                {
                    if (count2 > 0 && DBUtil.GetConfigInt(@"System\Vormundschaft\AnzahlMassnahmen", 2) != 2)
                    {
                        KissMsg.ShowInfo("CtlVmModulTree", "MassnahmeVorhanden", "Es existiert bereits eine vormundschaftliche Massnahme!");
                        return;
                    }
                }
                else
                {
                    if (count2 > 0 && DBUtil.GetConfigInt(@"System\Vormundschaft\AnzahlVaterschaftsAbklaerungen", 2) != 2)
                    {
                        KissMsg.ShowInfo("CtlVmModulTree", "VaterschaftsabklaerungVorhanden", "Es existiert bereits eine Vaterschaftsabklärung!");
                        return;
                    }
                }
            }

            DBUtil.ExecSQL(@"
                INSERT INTO dbo.FaLeistung (FaFallID, BaPersonID, ModulID, FaProzessCode, DatumVon, UserID, Creator, Created, Modifier, Modified)
                  SELECT TOP 1 FaFallID, BaPersonID, 5, {2}, dbo.fnDateOf(GetDate()), {1}, {3}, GetDate(), {3}, GetDate()
                  FROM dbo.FaFall WITH(READUNCOMMITTED)
                  WHERE BaPersonID = {0}
                  ORDER BY DatumBis, DatumVon DESC;",
                BaPersonID,
                Session.User.UserID,
                faProzessCode,
                DBUtil.GetDBRowCreatorModifier());

            if (faProzessCode == 501)
            {
                DBUtil.NewHistoryVersion();

                //Kopiere demographische Daten des Mandanten aus den Basisdaten
                DBUtil.ExecSQL(@"
                    IF (NOT EXISTS (SELECT TOP 1 1
                                    FROM dbo.VmMandant
                                    WHERE BaPersonID = {0}))
                    BEGIN
                      DECLARE @VmMandantID INT;

                      INSERT INTO dbo.VmMandant (BaPersonID, Version, Datum, Name, Vorname, Geburtsdatum, ZivilstandCode,
                                                 HeimatgemeindeBaGemeindeID, Beruf, AHVNummer)
                        SELECT TOP 1
                               PRS.BaPersonID,
                               1,
                               GetDate(),
                               Name,
                               Vorname,
                               Geburtsdatum,
                               ZivilstandCode,
                               HeimatgemeindeBaGemeindeID,
                               BRF.Beruf,
                               AHVNummer
                        FROM dbo.BaPerson                  PRS
                          LEFT JOIN dbo.BaArbeitAusbildung ARB ON ARB.BaPersonID = PRS.BaPersonID
                          LEFT JOIN dbo.BaBeruf            BRF ON BRF.BaBerufID = ARB.BerufCode
                        WHERE PRS.BaPersonID = {0};

                      SELECT @VmMandantID = SCOPE_IDENTITY();

                      INSERT INTO dbo.BaAdresse (VmMandantID, Zusatz, Strasse, HausNr, Postfach, PLZ, Ort, Kanton, BaLandID, OrtschaftCode, Creator, Modifier)
                        SELECT @VmMandantID,
                               WohnsitzAdressZusatz,
                               WohnsitzStrasse,
                               WohnsitzHausNr,
                               WohnsitzPostfach,
                               WohnsitzPLZ,
                               WohnsitzOrt,
                               WohnsitzKanton,
                               WohnsitzBaLandID,
                               WohnsitzOrtschaftCode,
                               {1},
                               {1}
                        FROM dbo.vwPerson
                        WHERE BaPersonID = {0};
                    END;", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }
            else if (faProzessCode == 503)
            {
                //Kopiere demographische Daten des Mandanten zum Erblasser
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.VmErblasser
                            (FaLeistungID,
                             TodesDatum,
                             AHVNummer,
                             Anrede,
                             FamilienNamen,
                             LedigName,
                             Vornamen,
                             Elternnamen,
                             ZivilstandCode,
                             Geburtsdatum,
                             Heimatorte,
                             Strasse,
                             Ort,
                             Aufenthalt)
                    SELECT FaLeistungID   = @@IDENTITY,
                           TodesDatum     = Sterbedatum,
                           AHVNummer      = AHVNummer,
                           Anrede         = Titel,
                           FamilienNamen  = PRS.Name,
                           LedigName      = PRS.FruehererName,
                           Vornamen       = PRS.Vorname,
                           Elternnamen    = ISNULL((SELECT TOP 1 ISNULL(PRS.Vorname + ' ', '') + PRS.Name
                                                    FROM dbo.BaPerson_Relation DPR WITH(READUNCOMMITTED)
                                                      INNER JOIN dbo.BaPerson  PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = DPR.BaPersonID_1
                                                                                                        AND PRS.GeschlechtCode = 1
                                                    WHERE DPR.BaPersonid_2 = {0}
                                                      AND DPR.BaRelationID = 1) + ', ', '') +
                                            ISNULL((SELECT TOP 1 ISNULL(PRS.Vorname + ' ', '') + PRS.Name
                                                    FROM dbo.BaPerson_Relation DPR WITH(READUNCOMMITTED)
                                                      INNER JOIN dbo.BaPerson  PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = DPR.BaPersonID_1
                                                                                                        AND PRS.GeschlechtCode = 2
                                                    WHERE DPR.BaPersonid_2 = {0}
                                                      AND DPR.BaRelationID = 1), ''),
                           ZivilstandCode = CASE ZivilstandCode
                                              WHEN 1 THEN 1
                                              WHEN 2 THEN 2
                                              WHEN 3 THEN 4
                                              WHEN 4 THEN 3
                                              WHEN 5 THEN 4
                                              WHEN 6 THEN NULL
                                            END,
                           Geburtsdatum   = CONVERT(VARCHAR, Geburtsdatum, 104),
                           Heimatorte     = HEI.Name,
                           Strasse        = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
                           Ort            = ISNULL(ADR.PLZ + ' ', '') + ADR.Ort,
                           Aufenthalt     = ISNULL(ADR2.Strasse + ISNULL(' ' + ADR2.HausNr, '') + ', ', '') + ISNULL(ADR2.PLZ + ' ', '') + ADR2.Ort
                    FROM dbo.BaPerson          PRS  WITH(READUNCOMMITTED)
                      LEFT JOIN dbo.BaAdresse  ADR  WITH(READUNCOMMITTED) ON ADR.BaPersonID = PRS.BaPersonID
                                                                         AND ADR.AdresseCode = 1 -- Wohnsitz
                                                                         AND ISNULL(ADR.DatumBis, '99990101') >= GETDATE()
                      LEFT JOIN dbo.BaAdresse  ADR2 WITH(READUNCOMMITTED) ON ADR2.BaPersonID = PRS.BaPersonID
                                                                         AND ADR2.AdresseCode = 3 -- Aufenthalt
                                                                         AND ISNULL(ADR2.DatumBis, '99990101') >= GETDATE()
                      LEFT JOIN dbo.BaGemeinde HEI  WITH(READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
                    WHERE  PRS.BaPersonID = {0};", BaPersonID);
            }

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");

            //refresh Navigator und Neupositionierung auf neuen Eintrag
            kissTree.DataSource = null; //sonst Exception: open DataReader!
            FillTree();
            TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, faProzessCode.ToString(), "FaProzessCode");

            if (node != null)
            {
                kissTree.FocusedNode = node;
                node.Expanded = true;
            }
        }

        private void btnNew2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (kissTree.FocusedNode == null || (int)kissTree.FocusedNode.GetValue("FaProzessCode") != 503)
            {
                return;
            }

            var faLeistungID = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            string qryString;
            string idColumnName;

            if (e.Item == btnNeueSiegelung)
            {
                //nur 1 Siegelung zulassen
                if (Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(0)
                        FROM dbo.VmSiegelung
                        WHERE FaLeistungID = {0};", faLeistungID)) != 0)
                {
                    KissMsg.ShowInfo("CtlVmModulTree", "SiegelungErbschaftVorhanden", "Es besteht bereits eine Sieglung für diesen Erbschaftsfall");
                    return;
                }

                qryString = @"
                    INSERT INTO dbo.VmSiegelung (FaLeistungID)
                    VALUES ({0});
                    SELECT ID = @@IDENTITY;";

                idColumnName = "VmSiegelungID";
            }
            else if (e.Item == btnNeuesTestament)
            {
                qryString = @"
                    INSERT INTO dbo.VmTestament (FaLeistungID)
                    VALUES ({0});
                    SELECT ID = @@IDENTITY;";

                idColumnName = "VmTestamentID";
            }
            else if (e.Item == btnNeuerErbschaftsdienst)
            {
                //nun doch mehrere Erbschaften zulassen
                qryString = @"
                    INSERT INTO dbo.VmErbschaftsdienst (FaLeistungID)
                    VALUES ({0});
                    SELECT ID = @@IDENTITY;";
                idColumnName = "VmErbschaftsdienstID";
            }
            else
            {
                return;
            }

            SqlQuery qry = DBUtil.OpenSQL(qryString, faLeistungID);

            Decimal identity = -1;

            if (qry.Count > 0)
            {
                identity = (Decimal)qry["ID"];
            }

            //refresh Navigator und Neupositionierung auf neuen Eintrag
            kissTree.DataSource = null; //sonst Exception: open DataReader!
            FillTree();
            TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, identity.ToString(), idColumnName);

            if (node != null)
            {
                kissTree.FocusedNode = node;
                node.Expanded = true;
            }
        }

        #endregion
    }
}