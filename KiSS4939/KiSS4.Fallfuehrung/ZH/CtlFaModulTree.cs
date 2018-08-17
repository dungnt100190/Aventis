using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.FAMOZ.VIS;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    public partial class CtlFaModulTree : KissModulTree
    {
        #region Fields

        #region Private Fields

        private bool _isLoading = true;

        #endregion

        #endregion

        #region Constructors

        public CtlFaModulTree(int baPersonID, int faFallID, Panel pnlDetail)
            : base(baPersonID, faFallID, pnlDetail, 2)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            //this.ctlSozialsystemContainer = new CtlSozialsystemContainer();

            popup_Tree.LinksPersistInfo.Clear();
            popup_Tree.LinksPersistInfo.AddRange(
                new[]
                {
                    // Neue Fallführungen: Normal
                    new LinkPersistInfo(btnNeueFallfuehrung),
                    // Aufnahemprozzess:
                    new LinkPersistInfo(btnNeueVoranmeldung, true),
                    new LinkPersistInfo(btnNeuesCheckIn),
                    new LinkPersistInfo(btnNeuesAssessment),
                    // Lösungsprozess:
                    new LinkPersistInfo(btnNeuesRP, true),
                    new LinkPersistInfo(btnNeueZielvereinbarung),
                    new LinkPersistInfo(btnNeueAbklaerung),
                    // Vormundschaftliches Mandat:
                    new LinkPersistInfo(btnNeueVormMandat, true),
                    // Löschen:
                    new LinkPersistInfo(btnDelete, true),
                    // zusätzliche Menus:
                    new LinkPersistInfo(btnFallZuteilung, true)
                });
        }

        public CtlFaModulTree()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        protected override void kissTree_AfterFocusNode(object sender, NodeEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_isLoading)
                {
                    return;
                }

                // handle empty node
                if (e == null || e.Node == null)
                {
                    return;
                }

                string className = e.Node.GetValue("ClassName") as string;
                if (className != null)
                {
                    bool forceDispose = true;
                    IKissView ctrl = null;

                    string id = e.Node.GetValue("ID") as string;
                    object faFallId = e.Node.GetValue("FaFallID");
                    object faLeistungID = e.Node.GetValue("FaLeistungID");
                    string name = e.Node.GetValue("Name") as string;
                    object personId = e.Node.GetValue("BaPersonID");
                    object subId = e.Node.GetValue("SubKnotenID");
                    int subKnotenId = Utils.ConvertToInt(subId);

                    bool istVertraulich = e.Node.GetValue("Vertraulich") as bool? ?? false;
                    bool istAlim = e.Node.GetValue("IstAlimentenstelle") as bool? ?? false;

                    Type type;

                    switch (className)
                    {
                        case "CtlVISMandat":
                        case "CtlVISMassnahme":
                        case "CtlVISBericht":
                            type = AssemblyLoader.GetType("KiSS4.FAMOZ.VIS." + className);
                            break;

                        default:
                            type = AssemblyLoader.GetType(className);
                            break;
                    }

                    if (type != null)
                    {
                        ctrl = _showDetail.GetDetailControl(type, true);
                    }

                    if (ctrl == null || id != null && id.StartsWith("X"))
                    {
                        ShowDetail(ctrl, true);
                        return;
                    }

                    switch (className)
                    {
                        case "CtlSozialsystemContainer":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", (int)personId, (int)faFallId);
                            break;

                        case "CtlFaRessourcenpaket":
                        case "CtlFaAbklaerung":
                        case "CtlFaZielvereinbarung":
                        case "CtlFaZielvereinbarungAuswertung":
                        case "CtlFaAbmachungen":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, (int)faFallId);
                            break;

                        case "CtlFaVoranmeldung":
                        case "CtlFaAssessment":
                        case "CtlFaAssessmentbericht":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, subKnotenId);
                            break;

                        case "CtlFaCheckin":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, subKnotenId, (int)personId);
                            break;

                        case "CtlFaTeilleistungserbringer":
                        case "CtlFaAufnahmeprozess":
                        case "CtlFaLoesungsprozess":
                        case "CtlFaCheckinAlim":
                        case "CtlVISMandat":
                        case "CtlVISMassnahme":
                        case "CtlVISBericht":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID);
                            break;

                        case "CtlFaRessourcenkarte":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, (int)faFallId, (int)personId);
                            break;

                        case "CtlFaLeistung":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, istAlim);
                            break;

                        case "CtlFaUnterlagenliste":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, (int)faFallId, istAlim);
                            forceDispose = false;
                            break;

                        case "CtlFaDokumente":
                        case "CtlFaAktennotizen":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, (int)faFallId, istVertraulich, istAlim);
                            break;

                        case "CtlFaFallverlaufsprotokoll":
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)personId);
                            break;

                        case "CtlFaSozialSystem":
                            /*
                            if( ID.StartsWith( "S" ) )
                            {
                                this.ctlFaSozialSystem.PersonId = base.DmgPersonID;///TODO base.BaPersonID;
                                ShowDetail(ctlFaSozialSystem);
                                ApplicationFacade.DoEvents();
                                try
                                {
                                    ctlFaSozialSystem.FallId = -1; //select main person
                                }
                                catch{}
                            }
                            else if( ID.StartsWith( "F" ))
                            {
                                // Fälle des Sozialsystems
                                ShowDetail(ctlFaSozialSystem);
                                try
                                {
                                    ctlFaSozialSystem.FallId = (int)FaFallID;
                                }
                                catch{}
                            }*/
                            break;

                        case "CtlPendenzenVerwaltung":
                            string sqlFilter = e.Node.GetValue("SqlFilter") as string;
                            if (faFallId != null && faLeistungID != null)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", null, faFallId as int?, faLeistungID as int?, AccessPendenzen.Leistung);
                                AssemblyLoader.InvokeMethode(ctrl, "CustomSearch", sqlFilter);
                            }

                            break;

                        default:
                            try
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e));
                            }
                            catch
                            {
                            }

                            break;
                    }

                    KissUserControl kissUserCtrl = ctrl as KissUserControl;

                    if (kissUserCtrl != null && kissUserCtrl.ActiveSQLQuery != null)
                    {
                        bool bMaskAlwaysAccessible = false;
                        try
                        {
                            bMaskAlwaysAccessible = (bool)AssemblyLoader.GetPropertyValue(kissUserCtrl, "AlwaysOpen");
                        }
                        catch
                        {
                        }

                        if (bMaskAlwaysAccessible && faLeistungID is int)
                        {
                            //Maske bleibt offen, obwohl Fall bereits geschlossen/archiviert
                            SqlQuery qryFallZugriff = DBUtil.OpenSQL(@"
                                SELECT *
                                FROM dbo.fnUserAccess({0}, {1})  ACL",
                                Session.User.UserID,
                                GetContextValue("FaLeistungID"));

                            if (Session.User.IsUserAdmin)
                            {
                            }
                            else if (qryFallZugriff.Count == 1)
                            {
                                kissUserCtrl.ActiveSQLQuery.CanInsert &= (bool)qryFallZugriff["MayInsert"];
                                kissUserCtrl.ActiveSQLQuery.CanUpdate &= (bool)qryFallZugriff["MayUpdate"];
                                kissUserCtrl.ActiveSQLQuery.CanDelete &= (bool)qryFallZugriff["MayDelete"];
                            }
                        }
                        else
                        {
                            ApplyEditMaskToSqlQuery(kissUserCtrl.ActiveSQLQuery);
                        }
                    }

                    ShowDetail(ctrl, forceDispose);
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

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            int leistgId = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaLeistungID"));
            int fallId = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaFallID"));
            bool istAlim = (Utils.ConvertToInt(kissTree.FocusedNode.GetValue("IstAlimentenstelle")) == 1) || (bool)kissTree.FocusedNode.GetValue("IstAlimentenstelle");
            string className = Utils.ConvertToString(kissTree.FocusedNode.GetValue("ClassName"));
            string qst = "";
            string msg = "";
            object subId = kissTree.FocusedNode.GetValue("SubKnotenID");
            int subKnotenId = Utils.ConvertToInt(subId);

            // Daten des DetailControls speichern bevor wir die Löschprüfung machen
            if (DetailControl != null && !DetailControl.ActiveSQLQuery.Post())
            {
                return;
            }

            switch (className.ToUpper())
            {
                case "CTLVISMANDAT":
                    // V-Leistungen (VIS) => Können nur gelöscht werden, falls nicht schon ein Dokument existiert
                    SqlQuery qryVisMandant = DBUtil.OpenSQL(@"
                        Select DISTINCT
                            FaLeistungID,
                            CountBerichtDoc = (SELECT Count(DocumentID) FROM dbo.VmBericht WHERE VmMassnahmeID = MAS.VmMassnahmeID)
                        FROM dbo.VmMassnahme MAS
                        WHERE MAS.FaLeistungID = {0}",
                        leistgId);

                    if (qryVisMandant.Count > 0 && ((int)qryVisMandant["CountBerichtDoc"] > 0))
                    {
                        // Es existieren schon Berichtsdokumente, diese Leistung kann nicht mehr gelöscht werden
                        KissMsg.ShowInfo(
                            string.Format(
                                "Diese M-Leistung kann nicht gelöscht werden, da bereits\r\n{0} Berichtsdokumente existieren.\r\nSie können diese M-Leistung jedoch abschliessen.",
                                qryVisMandant["CountBerichtDoc"]));
                        return;
                    }

                    break;

                case "CTLFAABKLAERUNG":
                    // Abklärungen => Können nur gelöscht werden, falls nicht schon ein Abklärungsauftrag abgeschlossen wurde
                    SqlQuery qryFaAbklaerung = DBUtil.OpenSQL(@"
                        SELECT DISTINCT
                          FaAbklaerungID
                        FROM dbo.FaAbklaerung
                        WHERE FaLeistungID = {0}
                          AND AbklaerungsberichtBeendetDatum IS NOT NULL",
                            leistgId);
                    if (qryFaAbklaerung.Count > 0)
                    {
                        // Es existieren schon abgeschlossene Abklärungsaufträge, diese Leistung kann nicht mehr gelöscht werden
                        KissMsg.ShowInfo("Die Maske Abklärung kann nicht gelöscht werden, da bereits abgeschlossene Abklärungsaufträge existieren.");
                        return;
                    }

                    break;
            }

            switch (className.ToUpper())
            {
                case "CTLFALEISTUNG":
                    if (istAlim)
                    {
                        qst = "der gewählte Fall";
                        msg = "Maske Leistung";
                    }

                    break;

                case "CTLFAVORANMELDUNG":
                    qst = "die gewählte Voranmeldung";
                    msg = "Maske Voranmeldung";
                    break;

                case "CTLFACHECKIN":
                    qst = "das gewählte Check-in";
                    msg = "Maske Check-in";
                    break;

                case "CTLFACHECKINALIM":
                    qst = "das gewählte Check-in";
                    msg = "Maske Check-in Alimentenstelle";
                    break;

                case "CTLFAASSESSMENT":
                    qst = "das gewählte Assessment";
                    msg = "Maske Assessment";
                    break;

                case "CTLFARESSOURCENPAKET":
                    qst = "das gewählte Ressourcenpaket";
                    msg = "Maske Ressourcenpaket";
                    break;

                case "CTLFAZIELVEREINBARUNG":
                    qst = "die gewählte Zielvereinbarung";
                    msg = "Maske Zielvereinbarung";
                    break;

                case "CTLFAABKLAERUNG":
                    qst = "die gewählte Abklärung";
                    msg = "Maske Abklärung";
                    break;

                case "CTLVISMANDAT":
                    qst = "das gewählte vormundschaft. Mandat";
                    msg = "Bereich vomundschaftliches Mandat";
                    break;
            }

            if (qst == "")
            {
                KissMsg.ShowInfo("Programmierfehler: Fehlende Programmierung eines Knotens.");
                return;
            }

            string tab = "";
            bool canDelete;
            switch (className.ToUpper())
            {
                case "CTLFALEISTUNG":
                    if (istAlim)
                    {
                        tab = "FaLeistung";
                    }

                    break;

                case "CTLFAVORANMELDUNG":
                    tab = "FaVoranmeldung";
                    var qry = DBUtil.OpenSQL(@"
                        SELECT FaVoranmeldungAbschlussgrundCode, StelleTypCode
                        FROM dbo.FaVoranmeldung VAM WITH (READUNCOMMITTED)
                        WHERE FaVoranmeldungID = {0}",
                        subKnotenId);

                    if (!qry.IsEmpty)
                    {
                        if (!DBUtil.IsEmpty(qry["FaVoranmeldungAbschlussgrundCode"]))
                        {
                            KissMsg.ShowInfo(
                                className,
                                "FaVoranmeldungLöschenNichtMöglich_Abgeschlossen",
                                "Abgeschlossene Voranmeldungen dürfen nicht gelöscht werden.");
                            return;
                        }

                        if (!DBUtil.IsEmpty(qry["StelleTypCode"]))
                        {
                            KissMsg.ShowInfo(
                                className,
                                "FaVoranmeldungLöschenNichtMöglich_EinträgeZuFachstelle",
                                "Die Voranmeldung darf nicht gelöscht werden. Es bestehen Einträge zu Fachstelle/Fachperson.");
                            return;
                        }
                    }

                    break;

                case "CTLFACHECKIN":
                    tab = "FaCheckin";
                    canDelete = DBUtil.ExecuteScalarSQLThrowingException(@"
                        IF EXISTS(SELECT TOP 1 1
                                  FROM dbo.FaCheckin CKI WITH (READUNCOMMITTED)
                                  WHERE FaCheckinID = {0}
                                    AND AntragEingegangenDatum IS NULL
                                    AND AntragAbgegebenDatum IS NULL
                                    AND AbschlussDatum IS NULL)
                        BEGIN
                          SELECT CONVERT(BIT, 1);
                        END
                        ELSE
                        BEGIN
                          SELECT CONVERT(BIT, 0);
                        END;",
                        subKnotenId
                        ) as bool? ?? false;
                    if (!canDelete)
                    {
                        KissMsg.ShowInfo(
                            className,
                            "FaCheckinLöschenNichtMöglich",
                            "Das Check-in kann nicht gelöscht werden, da bereits ein Datum bei 'Unterstützungsantrag (für wirtschaftliche Hilfe)' bzw. bei 'Abschluss Check-in' eingetragen ist.");
                        return;
                    }

                    break;

                case "CTLFACHECKINALIM":
                    tab = "FaCheckinAlim";
                    break;

                case "CTLFAASSESSMENT":
                    tab = "FaAssessment";

                    //Fehlermeldung bei gesetztem Abschlussdatum und bei leeren Assessmentberichten
                    canDelete = DBUtil.ExecuteScalarSQLThrowingException(@"
                            IF EXISTS(SELECT TOP 1 1
                                      FROM dbo.FaAssessment ASS WITH (READUNCOMMITTED)
                                      WHERE FaAssessmentID = {0}
                                        AND AbschlussDatum IS NOT NULL
                                        AND Anlass IS NULL
                                        AND Situation IS NULL
                                        AND Thema1 IS NULL
                                        AND Thema2 IS NULL
                                        AND Thema1Zustaendig IS NULL
                                        AND Thema2Zustaendig IS NULL
                                        AND ThemaAnpacken IS NULL
                                        AND ISNULL(ThemaAnpackenKeinInteresse, 0) = 0
                                        AND ThemaAnpackenKeinInteresseGrund IS NULL
                                        AND ISNULL(KeinSoDThema, 0) = 0
                                        AND AndereStellen IS NULL
                                        AND FaAuflageCode IS NULL
                                        AND RPBedarfCode IS NULL
                                        AND ISNULL(DeutschUngenuegend, 0) = 0
                                        AND Muttersprache IS NULL
                                        AND ISNULL(Uebersetzer, 0) = 0
                                        AND Bemerkung IS NULL
                                        AND BerichtUserID IS NULL
                                        AND BerichtDokID IS NULL
                                        AND UnterschriebenDurchKlient IS NULL
                            )
                            BEGIN
                              SELECT CONVERT(BIT, 0); -- If it exists, delete must not be possible.
                            END
                            ELSE
                            BEGIN
                              SELECT CONVERT(BIT, 1);
                            END;",
                        subKnotenId) as bool? ?? false;
                    if (!canDelete)
                    {
                        KissMsg.ShowInfo(
                            className,
                            "FaAssessmentGeschlossenLöschenNichtMöglich",
                            "Das Assessment ist abgeschlossen und kann daher nicht gelöscht werden.");
                        return;
                    }

                    canDelete = DBUtil.ExecuteScalarSQLThrowingException(@"
                            IF EXISTS(SELECT TOP 1 1
                                      FROM dbo.FaAssessment ASS WITH (READUNCOMMITTED)
                                      WHERE FaAssessmentID = {0}
                                        AND AbschlussDatum IS NULL
                                        AND Anlass IS NULL
                                        AND Situation IS NULL
                                        AND Thema1 IS NULL
                                        AND Thema2 IS NULL
                                        AND Thema1Zustaendig IS NULL
                                        AND Thema2Zustaendig IS NULL
                                        AND ThemaAnpacken IS NULL
                                        AND ISNULL(ThemaAnpackenKeinInteresse, 0) = 0
                                        AND ThemaAnpackenKeinInteresseGrund IS NULL
                                        AND ISNULL(KeinSoDThema, 0) = 0
                                        AND AndereStellen IS NULL
                                        AND FaAuflageCode IS NULL
                                        AND RPBedarfCode IS NULL
                                        AND ISNULL(DeutschUngenuegend, 0) = 0
                                        AND Muttersprache IS NULL
                                        AND ISNULL(Uebersetzer, 0) = 0
                                        AND Bemerkung IS NULL
                                        AND BerichtUserID IS NULL
                                        AND BerichtDokID IS NULL
                                        AND UnterschriebenDurchKlient IS NULL
                            )
                            BEGIN
                              SELECT CONVERT(BIT, 1);
                            END
                            ELSE
                            BEGIN
                              SELECT CONVERT(BIT, 0);
                            END;",
                        subKnotenId) as bool? ?? false;
                    if (!canDelete)
                    {
                        KissMsg.ShowInfo(
                            className,
                            "FaAssessmentLöschenNichtMöglich",
                            "Das Assessment darf nicht gelöscht werden. Es bestehen bereits Einträge in den Assessmentberichten.");
                        return;
                    }
                    break;

                case "CTLFARESSOURCENPAKET":
                    tab = "FaRessourcenpaket";
                    break;

                case "CTLFAZIELVEREINBARUNG":
                    tab = "FaZielvereinbarung";
                    break;

                case "CTLFAABKLAERUNG":
                    tab = "FaAbklaerung";
                    break;

                case "CTLVISMANDAT":
                    tab = "FaLeistung";
                    break;
            }

            // Zuerst fragen:
            qst = string.Format("Soll {0} wirklich gelöscht werden ?", qst);
            //if (!KissMsg.ShowQuestion("CtlFaModulTree", "DatenFallLoeschen_"+tab, qst)) return;
            // es haben mehrere diesselbe Klasse (wird dann nicht der richtige Text angezeigt, wenn du das wie oben machst!
            if (!KissMsg.ShowQuestion(qst))
            {
                return;
            }

            // dann löschen:
            string deleteStatement = "Delete " + tab + " where FaLeistungID=" + leistgId.ToString();
            try
            {
                switch (className.ToUpper())
                {
                    case "CTLFAVORANMELDUNG":
                        deleteStatement = "Delete FaVoranmeldung where FaVoranmeldungID = " + subKnotenId.ToString();
                        break;

                    case "CTLFACHECKIN":
                        deleteStatement = "Delete FaCheckIn where FaCheckInID = " + subKnotenId.ToString();
                        break;

                    case "CTLFAASSESSMENT":
                        deleteStatement = "Delete FaAssessment where FaAssessmentID = " + subKnotenId.ToString();
                        break;
                }

                DBUtil.ExecSQLThrowingException(deleteStatement);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlFaModulTree", "FehlerLoeschen", "Fehler beim Löschen eines Eintrags", ex);
                return;
            }

            //Eintrag Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text, OrgUnitID)
                  VALUES ({0},{1},{2},{3}, {4})",
                fallId,
                leistgId,
                Session.User.UserID,
                msg + " gelöscht",
                Session.User["OrgUnitID"]);

            // Node + ParentNode löschen:
            bool deleteParent = (
                                    className == "CtlFaVoranmeldung" ||
                                    className == "CtlFaCheckin" ||
                                    className == "CtlFaCheckinAlimentenstelle" ||
                                    className == "CtlFaAssessment" ||
                                    className == "CtlFaRessourcenpaket" ||
                                    className == "CtlFaZielvereinbarung" ||
                                    className == "CtlFaAbklaerung");

            TreeListNode parentNode = kissTree.FocusedNode.ParentNode;

            kissTree.DeleteNode(kissTree.FocusedNode);

            // wenn notwendig, auch den ParentNode löschen:
            if (deleteParent && parentNode != null)
            {
                if (!parentNode.HasChildren)
                {
                    kissTree.DeleteNode(parentNode);
                }
            }
        }

        private void btnFallZuteilung_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormController.ShowDialogOnMain("DlgFallZuteilung", BaPersonID);
        }

        private void btnNeueAbklaerung_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faLeistungId = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            // neue Abklärung
            DBUtil.ExecSQL(@"
                INSERT dbo.FaAbklaerung (FaLeistungID, UserID,  AuftragDatum, AusloeserCode, Creator, Created, Modifier, Modified)
                  VALUES ({0}, {1}, dbo.fnDateOf(GETDATE()), -1, {2}, GETDATE(), {2}, GETDATE());",
                faLeistungId,
                Session.User.UserID,
                DBUtil.GetDBRowCreatorModifier());

            //Eintrag Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text, OrgUnitID)
                  VALUES ({0},{1},{2},{3}, {4})",
                kissTree.FocusedNode.GetValue("FaFallID"),
                faLeistungId,
                Session.User.UserID,
                "Maske Abklärung angelegt",
                Session.User["OrgUnitID"]);

            // Refresh Tree
            DisplayTree("CtlFaAbklaerung" + faLeistungId.ToString());
        }

        private void btnNeueFallfuehrung_ItemClick(object sender, ItemClickEventArgs e)
        {
            Decimal identity = -1;
            try
            {
                int faFallID = (int)kissTree.FocusedNode.GetValue("FaFallID");
                Session.BeginTransaction();
                // neue Fallführung (Prozesscode = 200)
                DBUtil.ExecSQLThrowingException(@"
                    IF EXISTS (SELECT 1 FROM dbo.FaFall WHERE FaFallID = {0} AND DatumBis IS NOT NULL)
                    BEGIN
                      EXEC [dbo].[spFaFall_Open] {0}, null, 200 /*Fallführung*/, {1}
                    END",
                    faFallID,
                    Session.User.UserID);
                SqlQuery qry = DBUtil.OpenSQL(@"
                    INSERT FaLeistung (FaFallID, ModulID, FaProzessCode, BaPersonID, UserID, DatumVon, Creator, Created, Modifier, Modified)
                      VALUES ( {0}, 2, 200, {1}, {2}, dbo.fnDateOf(GETDATE()), {3}, GETDATE(), {3}, GETDATE())
                    SELECT ID = @@identity",
                    faFallID,
                    BaPersonID,
                    Session.User.UserID,
                    DBUtil.GetDBRowCreatorModifier());

                // neue ID holen:

                if (qry.Count > 0)
                {
                    identity = (Decimal)qry["ID"];
                }

                //Eintrag Fallverlaufsprotokoll
                DBUtil.ExecSQL(@"
                    INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text)
                      VALUES ({0},{1},{2},{3})",
                    faFallID,
                    identity,
                    Session.User.UserID,
                    "Eröffnung Fallführung");

                /*
                  INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text,OrgUnitID)
                    VALUES ({0},{1},{2},{3},{4})",
                    kissTree.FocusedNode.GetValue("FaFallID"),
                    identity,
                    Session.User.UserID,
                    "Eröffnung Fallführung",
                    Session.User["OrgUnitID"]);
                */
                Session.Commit();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                throw ex;
            }

            // Refresh Tree
            DisplayTree("CtlFaFallfuehrung" + identity);
        }

        private void btnNeuesAssessment_ItemClick(object sender, ItemClickEventArgs e)
        {
            // neues Assessment
            int faLeistungId = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            SqlQuery qry = DBUtil.OpenSQL(@"
                Select top 1 OrgUnitID from XOrgUnit_User where UserID = {0} and OrgUnitMemberCode = 2",
                Session.User.UserID);
            object orgUnitId = qry["OrgUnitID"];
            DBUtil.ExecSQL(@"
                INSERT FaAssessment (FaLeistungID, EroeffnungDatum, EroeffnungUserID, EroeffnungOrgUnitID)
                  VALUES ({0}, GetDate(), {1}, {2})
                SELECT ID = @@identity",
                faLeistungId,
                Session.User.UserID,
                orgUnitId);

            //Eintrag Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text,OrgUnitID)
                  VALUES ({0},{1},{2},{3},{4})",
                kissTree.FocusedNode.GetValue("FaFallID"),
                faLeistungId,
                Session.User.UserID,
                "Maske Assessment angelegt",
                Session.User["OrgUnitID"]);

            // Refresh Tree
            DisplayTree("CtlFaAssessment" + faLeistungId.ToString());
        }

        private void btnNeuesCheckIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faLeistungId = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            // neues Checkins:
            SqlQuery qry = DBUtil.OpenSQL(@"
                Select top 1 OrgUnitID from XOrgUnit_User where UserID = {0} and OrgUnitMemberCode = 2",
                Session.User.UserID);
            object orgUnitId = qry["OrgUnitID"];
            DBUtil.ExecSQLThrowingException(@"
                INSERT FaCheckIn (FaLeistungID, ErstKontaktDatum, ErstKontaktUserID, ErstKontaktOrgUnitID)
                  VALUES ({0}, GetDate(), {1}, {2})",
                faLeistungId,
                Session.User.UserID,
                orgUnitId);
            int? checkinID = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT FaCheckInID FROM FaCheckIN WHERE FaLeistungID = {0} ORDER BY FaCheckInID DESC", faLeistungId) as int?;
            //Eintrag Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text,OrgUnitID)
                  VALUES ({0},{1},{2},{3},{4})",
                kissTree.FocusedNode.GetValue("FaFallID"),
                faLeistungId,
                Session.User.UserID,
                "Maske Checkin angelegt",
                Session.User["OrgUnitID"]);

            // Refresh Tree
            DisplayTree("CtlFaCheckin" + checkinID.ToString());
        }

        private void btnNeuesRP_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faLeistungId = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            // neues Ressourcenpaket
            DBUtil.ExecSQL(@"
                INSERT FaRessourcenpaket (FaLeistungID, FallfuehrenderID,RPIstDatumVon)
                  VALUES({0}, {1}, GetDate())",
                faLeistungId,
                Session.User.UserID);

            //Eintrag Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text, OrgUnitID)
                  VALUES ({0},{1},{2},{3},{4})",
                kissTree.FocusedNode.GetValue("FaFallID"),
                faLeistungId,
                Session.User.UserID,
                "Maske Ressourcenpaket angelegt",
                Session.User["OrgUnitID"]);

            // Refresh Tree
            DisplayTree("CtlFaRessourcenpaket" + faLeistungId.ToString());
        }

        private void btnNeueVoranmeldung_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faLeistungId = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            DateTime dt1 = DateTime.Today;
            DateTime dt2 = dt1.AddMonths(1);

            // neue Voranmeldung
            DBUtil.ExecSQL(@"
                INSERT FaVoranmeldung (FaLeistungID, UserID, Datum, FeedbackDatumBis)
                  VALUES ({0}, {1}, {2}, {3})",
                faLeistungId,
                Session.User.UserID,
                dt1,
                dt2);

            //Eintrag Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text,OrgUnitID)
                  VALUES ({0},{1},{2},{3},{4})",
                kissTree.FocusedNode.GetValue("FaFallID"),
                faLeistungId,
                Session.User.UserID,
                "Maske Voranmeldung angelegt",
                Session.User["OrgUnitID"]);

            // Refresh Tree
            DisplayTree("CtlFaVoranmeldung" + faLeistungId.ToString());
        }

        private void btnNeueVormMandat_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faFallId = (int)kissTree.FocusedNode.GetValue("FaFallID");

            KissLookupDialog dlg = new KissLookupDialog();
            if (!dlg.SearchData(@"
                    SELECT DISTINCT
                           BaPersonID$      = PRS.BaPersonID,
                           Person           = PRS.Name + isnull(', ' + PRS.Vorname,''),
                           [# aktiver M-Leistungen] = (SELECT COUNT(FaLeistungID) FROM FaLeistung WHERE FaProzessCode = 210 and BaPersonID = FPR.BaPersonID AND DatumBis is NULL)
                    FROM   FaFallPerson FPR
                           INNER JOIN BaPerson   PRS ON PRS.BaPersonID = FPR.BaPersonID
                    WHERE  FPR.FaFallID = {0}
                    ORDER BY Person",
                    faFallId.ToString(),
                    true,
                    null,
                    null,
                    null))
            {
                return;
            }

            int baPersonId = (int)dlg["BaPersonID$"];

            DlgVISNeueMassnahme dlgVNeueMassnahme = new DlgVISNeueMassnahme(faFallId, baPersonId);
            dlgVNeueMassnahme.ShowDialog();

            if (dlgVNeueMassnahme.DialogResult == DialogResult.OK)
            {
                if (dlgVNeueMassnahme.FaLeistungID > 0)
                {
                    // Refresh Tree
                    DisplayTree("CtlVISMandat" + dlgVNeueMassnahme.FaLeistungID.ToString());
                }
            }
        }

        private void btnNeueZielvereinbarung_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faLeistungId = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            // neue Zielvereinbarung
            DBUtil.ExecSQL(@"
                INSERT FaZielvereinbarung (FaLeistungID, ZielvereinbarungUserID, DatumZielvereinbarung,
                                           ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum)
                VALUES ({0}, {1}, GetDate(), {1}, {2}, {1}, {2} )",
                faLeistungId,
                Session.User.UserID,
                DateTime.Now
                );

            //Eintrag Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT FaJournal (FaFallID,FaLeistungID,UserID,Text, OrgUnitID)
                  VALUES ({0},{1},{2},{3},{4})",
                kissTree.FocusedNode.GetValue("FaFallID"),
                faLeistungId,
                Session.User.UserID,
                "Maske Zielvereinbarung angelegt",
                Session.User["OrgUnitID"]);

            // Refresh Tree
            DisplayTree("CtlFaZielvereinbarung" + faLeistungId.ToString());
        }

        private void CtlFaModulTree_Load(object sender, EventArgs e)
        {
            DisplayTree(null);
        }

        private void InsertNewNode_CheckIn()
        {
            int faLeistungId = (int)kissTree.FocusedNode.GetValue("FaLeistungID");

            SqlQuery qry = DBUtil.OpenSQL(
                "SELECT UserID, DatumVon FROM FaFall WHERE FaFallID = {0}",
                kissTree.FocusedNode.GetValue("FaFallID"));
            int userid = Utils.ConvertToInt(qry["UserID"]);
            if (userid == 0)
            {
                userid = Session.User.UserID;
            }

            DateTime dat = DBUtil.IsEmpty(qry["DatumVon"]) ? DateTime.Today : (DateTime)qry["DatumVon"];

            // einfügen eines neuen Checkins:
            DBUtil.ExecSQL(@"
                INSERT FaCheckIn (FaLeistungID, ErstKontaktDatum, ErstKontaktUserID) VALUES ( {0}, GetDate(), {1})",
                faLeistungId,
                Session.User.UserID);

            // Refresh Tree
            DisplayTree("CtlFaCheckin" + faLeistungId.ToString());
        }

        private void InsertNewNode_Main(int processCode)
        {
            // einfügen einer neuen FaLeistung:
            SqlQuery qry = DBUtil.OpenSQL(@"
                INSERT FaLeistung (FaFallID, ModulID, FaProzessCode, BaPersonID, UserID, DatumVon, Creator, Created, Modifier, Modified)
                  VALUES ( {0}, 2, {1}, {2}, {3}, GETDATE(), {5}, GETDATE(), {5}, GETDATE()  )
                SELECT ID = @@identity",
                kissTree.FocusedNode.GetValue("FaFallID"),
                processCode,
                BaPersonID,
                Session.User.UserID,
                DBUtil.GetDBRowCreatorModifier());

            // neue ID holen:
            Decimal identity = -1;
            if (qry.Count > 0)
            {
                identity = (Decimal)qry["ID"];
            }

            // Refresh Tree
            DisplayTree("CtlFaFallfuehrung" + identity);
        }

        private void popup_Tree_BeforePopup(object sender, EventArgs e)
        {
            bool vis;

            int caseId = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaFallID"));
            int leistgId = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaLeistungID"));
            string className = Utils.ConvertToString(kissTree.FocusedNode.GetValue("ClassName"));

            qryPopupMenu.Fill(caseId, leistgId, Session.User.UserID);

            bool userMayReadFall = qryPopupMenu["UserMayReadFall"] is bool && (bool)qryPopupMenu["UserMayReadFall"];
            bool caseIsClosed = (Utils.ConvertToInt(qryPopupMenu["CaseIsClosed"]) == 1);
            bool serviceIsClosed = (Utils.ConvertToInt(qryPopupMenu["ServiceIsClosed"]) == 1);
            bool istAlim = (Utils.ConvertToInt(qryPopupMenu["IstAlim"]) == 1);
            bool hatF = (Utils.ConvertToInt(qryPopupMenu["HatF"]) == 1);
            bool hatFAlim = (Utils.ConvertToInt(qryPopupMenu["HatFAlim"]) == 1);
            bool istVM = (Utils.ConvertToInt(qryPopupMenu["IstVM"]) == 1);
            bool hatVoranmeldung = (Utils.ConvertToInt(qryPopupMenu["HatVoranmeldung"]) == 1);
            bool hatCheckin = (Utils.ConvertToInt(qryPopupMenu["HatCheckin"]) == 1);
            bool hatAssessment = (Utils.ConvertToInt(qryPopupMenu["HatAssessment"]) == 1);

            // btnNeueFallfuehrung: Menu für neue Fallführung:
            vis = DBUtil.UserHasRight("CtlFaLeistung_Erstellen") && !hatF;

            SetPopupMenuVisibility(btnNeueFallfuehrung, vis);

            // btnNeueVoranmeldung: Menu für neue Voranmeldung:
            vis = (DBUtil.UserHasRight("CtlFaVoranmeldung_Erstellen") &&
                   userMayReadFall &&
                   !caseIsClosed && !serviceIsClosed &&
                   !istAlim && leistgId > 0 && !istVM && !hatVoranmeldung);
            SetPopupMenuVisibility(btnNeueVoranmeldung, vis);

            // btnNeuesCheckIn: Menu für neues Checkin:
            vis = (DBUtil.UserHasRight("CtlFaCheckin_Erstellen") &&
                   userMayReadFall &&
                   !caseIsClosed && !serviceIsClosed &&
                   !istAlim && leistgId > 0 && !istVM && !hatCheckin);
            SetPopupMenuVisibility(btnNeuesCheckIn, vis);

            // btnNeuesAssessment: Menu für neues Assessment:
            vis = (DBUtil.UserHasRight("CtlFaAssessment_Erstellen") &&
                   userMayReadFall &&
                   !caseIsClosed &&
                   !serviceIsClosed && !istAlim && leistgId > 0 && !istVM && !hatAssessment);
            SetPopupMenuVisibility(btnNeuesAssessment, vis);

            // btnNeuesRP: Menu für neues Ressourcenpaket:
            vis = false; //(UserMayReadFall && Utils.ConvertToInt(qry["HatRessourcenpaket"]) == 0 && !CaseIsClosed && !ServiceIsClosed && !IstAlim && LeistgID>0&& !IstVM);
            SetPopupMenuVisibility(btnNeuesRP, vis);

            // btnNeueZielvereinbarung: Menu für neue Zielvereinbarung:
            vis = DBUtil.UserHasRight("CtlFaZielvereinbarung_Erstellen") &&
                  userMayReadFall &&
                  Utils.ConvertToInt(qryPopupMenu["HatZielvereinbarung"]) == 0 &&
                  !caseIsClosed && !serviceIsClosed && !istAlim && leistgId > 0 && !istVM;
            SetPopupMenuVisibility(btnNeueZielvereinbarung, vis);

            // btnNeueAbklaerung: Menu für neue Abklärung:
            vis = DBUtil.UserHasRight("CtlFaAbklaerung_Erstellen") &&
                  userMayReadFall &&
                  Utils.ConvertToInt(qryPopupMenu["HatAbklaerung"]) == 0 &&
                  !caseIsClosed && !serviceIsClosed && !istAlim && leistgId > 0 && !istVM;
            SetPopupMenuVisibility(btnNeueAbklaerung, vis);

            // btnNeueVormMandat: Menu für neues vormundschaftliches Mandat:
            vis = DBUtil.UserHasRight("CtlVISMandat_Erstellen") &&
                /*Mantis 1650! Utils.ConvertToInt(qry["HatVm"]) == 0 && */
                  userMayReadFall && !caseIsClosed && !istAlim && (caseId > 0);
            SetPopupMenuVisibility(btnNeueVormMandat, vis);

            // btnDelete: Menu Löschen für alle Einträge:
            SetPopupMenuVisibility(
                btnDelete,
                userMayReadFall && !caseIsClosed && leistgId > 0 && !serviceIsClosed && (
                                                                                            (className == "CtlFaLeistung" && istAlim &&
                                                                                             DBUtil.UserHasRight("CtlFaLeistungAlim_Loeschen")) ||
                                                                                            (className == "CtlFaVoranmeldung" && DBUtil.UserHasRight("CtlFaVoranmeldung_Loeschen")) ||
                                                                                            (className == "CtlFaCheckin" && DBUtil.UserHasRight("CtlFaCheckin_Loeschen")) ||
                                                                                            (className == "CtlFaCheckinAlim" && DBUtil.UserHasRight("CtlFaCheckinAlim_Loeschen")) ||
                                                                                            (className == "CtlFaAssessment" && DBUtil.UserHasRight("CtlFaAssessment_Loeschen")) ||
                                                                                            (className == "CtlFaRessourcenpaket" &&
                                                                                             DBUtil.UserHasRight("CtlFaRessourcenpaket_Loeschen")) ||
                                                                                            (className == "CtlFaZielvereinbarung" &&
                                                                                             DBUtil.UserHasRight("CtlFaZielvereinbarung_Loeschen")) ||
                                                                                            (className == "CtlFaAbklaerung" && DBUtil.UserHasRight("CtlFaAbklaerung_Loeschen")) ||
                                                                                            (className == "CtlVISMandat" && DBUtil.UserHasRight("CtlVISMandat_Loeschen"))
                                                                                        )
                );

            // Fallzugriff/Fallinfo/Fallzuteilung:
            btnFallZugriff.Visibility = BarItemVisibility.Never;
            btnFallInfo.Visibility = BarItemVisibility.Never;
            btnFallZuteilung.Visibility = BarItemVisibility.Always;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void DisplayTree(string treeID)
        {
            kissTree.DataSource = null; //sonst Exception: open DataReader!

            _isLoading = true;
            FillTree();
            _isLoading = false;

            //auf obersten Fallverlauf öffnen und positionieren
            if (kissTree.Nodes.Count > 2)
            {
                kissTree.Nodes[2].Expanded = true;
                kissTree.FocusedNode = kissTree.Nodes[2];
                //Dokumentation öffnen
                if (kissTree.Nodes[2].Nodes.Count > 0)
                {
                    kissTree.Nodes[2].Nodes[0].Expanded = true;
                }
                //obersten Aufnahmeprozess oder LösungsprozessDokumentation öffnen
                if (kissTree.Nodes[2].Nodes.Count > 1)
                {
                    kissTree.Nodes[2].Nodes[1].Expanded = true;
                }
            }
            else if (kissTree.Nodes.Count > 1)
            {
                //Fallverlauf anzeigen
                kissTree.FocusedNode = kissTree.Nodes[1];
            }
            else
            {
                ShowDetail(null);
            }

            //ev. Neupositionierung auf neuen Eintrag
            if (treeID != string.Empty)
            {
                TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, treeID, "ID");
                if (node != null)
                {
                    node.Expanded = true;
                    kissTree.FocusedNode = node;
                }
            }

            ExpandActiveVLeistungen();
        }

        #endregion

        #region Private Methods

        private void ExpandActiveVLeistungen()
        {
            foreach (TreeListNode nodeLeistung in kissTree.Nodes)
            {
                // node entspricht F-Leistung
                foreach (TreeListNode node in nodeLeistung.Nodes)
                {
                    if ("CtlVISMandat" == node.GetValue("ClassName") as string && !DBUtil.IsEmpty(node.GetValue("AktiveLeistung")))
                    {
                        if ((bool)node.GetValue("AktiveLeistung"))
                        {
                            // aktive V-Leistungen werden expandiert
                            node.Expanded = true;
                        }
                        else
                        {
                            // inaktive V-Leistung wird nicht expandiert
                            node.Expanded = false;
                        }
                    }
                }
            }
        }

        private void SetPopupMenuVisibility(BarButtonItem btn, bool isVisible)
        {
            if (isVisible)
            {
                btn.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btn.Visibility = BarItemVisibility.Never;
            }
        }

        #endregion

        #endregion
    }
}