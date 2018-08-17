using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    public partial class CtlFaLeistung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _activeImageID;
        private bool _buttonReopenWurdeGeklickt;
        private int _faLeistungID;
        private bool _istAlim;

        #endregion

        #endregion

        #region Constructors

        public CtlFaLeistung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnReopen_Click(object sender, EventArgs e)
        {
            // TODO: Refersh tree so machen, dass auch Personen-Tree ein refresh erhält

            var qry = DBUtil.OpenSQL(
                @"EXEC dbo.spFaLeistung_ReOpenCheckFF {0}, {1}, {2}, {3}",
                qryFaLeistung["FaFallID"],
                qryFaLeistung["FaLeistungID"],
                qryFaLeistung["BaPersonID"],
                qryFaLeistung["FaProzessCode"]);

            if (Utils.ConvertToString(qry["Error"]) != "")
            {
                KissMsg.ShowInfo(Utils.ConvertToString(qry["Error"]));
                return;
            }

            if (Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) == 201)
            {
                if (!KissMsg.ShowQuestion(
                    "CtlFaLeistung",
                    "FallverlaufWiederOeffnenAlim",
                    "Soll die geschlossene Alimentenfallführung wieder geöffnet werden?"))
                {
                    return;
                }
            }
            else
            {
                if (!KissMsg.ShowQuestion(
                    "CtlFaLeistung",
                    "FallverlaufWiederOeffnenNorm",
                    "Soll die geschlossene Fallführung wieder geöffnet werden?"))
                {
                    return;
                }
            }

            _buttonReopenWurdeGeklickt = true;

            try
            {
                // Leistung wieder öffnen
                qryFaLeistung.CanUpdate = true;
                qryFaLeistung["DatumBis"] = DBNull.Value;
                qryFaLeistung.Post();
            }
            finally
            {
                _buttonReopenWurdeGeklickt = false;
            }
        }

        private void qryFaLeistung_AfterDelete(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFaLeistung_AfterFill(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            if (Session.Transaction == null)
            {
                return;
            }

            try
            {
                if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
                {
                    // Leistung wurde abgeschlossen, also FaJournal Eintrag erstellen
                    DBUtil.OpenSQL(
                        "EXEC dbo.spFaJournal_Insert {0}, {1}, {2}, {3}, {4}, NULL",
                        qryFaLeistung["FaFallID"],
                        qryFaLeistung["FaLeistungID"],
                        qryFaLeistung["BaPersonID"],
                        Session.User.UserID,
                        2);

                    // Jetzt kontrollieren, ob der Fall abgeschlossen werden kann
                    // und wenn notwendig, den User wechseln
                    DBUtil.OpenSQL(
                        "EXEC dbo.spFaFall_Close {0}, {1}, {2}",
                        qryFaLeistung["FaFallID"],
                        qryFaLeistung["FaProzessCode"],
                        Session.User.UserID);
                }

                if (_buttonReopenWurdeGeklickt)
                {
                    DBUtil.ExecSQL(
                        "EXEC dbo.spFaJournal_Insert {0}, {1}, {2}, {3}, {4}, NULL",
                        qryFaLeistung["FaFallID"],
                        qryFaLeistung["FaLeistungID"],
                        qryFaLeistung["BaPersonID"],
                        Session.User.UserID,
                        3);
                }

                // Speichern
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            int newImageID = _istAlim
                                 ? DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) ? 1230 : 1232
                                 : DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) ? 1201 : 1202;

            if (newImageID != _activeImageID)
            {
                picTitel.Image = KissImageList.GetSmallImage(newImageID);
                _activeImageID = newImageID;
            }

            // Tree aktualisieren
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            // Editieren einstellen
            SetEditMode();
        }

        private void qryFaLeistung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (!_istAlim)
            {
                // wenn es eine F-Leistung ist
                KissMsg.ShowInfo("Das Löschen von Fallführungen ist noch nicht programmiert.");
                throw new KissCancelException();
            }

            // wenn es eine FA-Leistung ist
            // zuerst kontrollieren, ob es Einträge zu dieser Leistung gibt
            var qry = DBUtil.OpenSQL(@"
                select
                  AnzahlAktennotizen = (select count(*) from dbo.FaAktennotizen where FaLeistungID = {0}),
                  AnzahlDokumente = (select count(*) from dbo.FaDokumente where FaLeistungID = {0}),
                  AnzahlUnterlagen = (select count(*) from dbo.FaUnterlagen where FaLeistungID = {0}),
                  AnzahlCheckIn = (select count(*) from dbo.FaCheckIn where FaLeistungID = {0})",
                Utils.ConvertToInt(qryFaLeistung["FaLeistungID"]));

            string msg = "";

            if (Utils.ConvertToInt(qry["AnzahlAktennotizen"]) > 0)
            {
                msg = msg + string.Format(
                    "Es {1} noch {0} Aktennotiz{2} erfasst.\r\n",
                    Utils.ConvertToInt(qry["AnzahlAktennotizen"]),
                    Utils.ConvertToInt(qry["AnzahlAktennotizen"]) == 1 ? "ist" : "sind",
                    Utils.ConvertToInt(qry["AnzahlAktennotizen"]) == 1 ? "" : "en");
            }

            if (Utils.ConvertToInt(qry["AnzahlDokumente"]) > 0)
            {
                msg = msg + string.Format(
                    "Es {1} noch {0} Dokument{2} erfasst.\r\n",
                    Utils.ConvertToInt(qry["AnzahlDokumente"]),
                    Utils.ConvertToInt(qry["AnzahlDokumente"]) == 1 ? "ist" : "sind",
                    Utils.ConvertToInt(qry["AnzahlDokumente"]) == 1 ? "" : "e");
            }

            if (Utils.ConvertToInt(qry["AnzahlUnterlagen"]) > 0)
            {
                msg = msg + string.Format(
                    "Es {1} noch {0} Unterlage{2} erfasst.\r\n",
                    Utils.ConvertToInt(qry["AnzahlUnterlagen"]),
                    Utils.ConvertToInt(qry["AnzahlUnterlagen"]) == 1 ? "ist" : "sind",
                    Utils.ConvertToInt(qry["AnzahlUnterlagen"]) == 1 ? "" : "n");
            }

            if (Utils.ConvertToInt(qry["AnzahlCheckIn"]) > 0)
            {
                msg = msg + string.Format(
                    "Es {1} noch {0} Check-In{2} erfasst.\r\n",
                    Utils.ConvertToInt(qry["AnzahlCheckIn"]),
                    Utils.ConvertToInt(qry["AnzahlCheckIn"]) == 1 ? "ist" : "sind",
                    Utils.ConvertToInt(qry["AnzahlCheckIn"]) == 1 ? "" : "s");
            }

            if (msg != "")
            {
                KissMsg.ShowInfo(
                    string.Format(
                        "Diese Fallführung kann nicht gelöscht werden:\r\n\r\n" +
                        "{0}\r\n" +
                        "Löschen Sie zuerst die entsprechenden Einträge.",
                        msg));
                throw new KissCancelException();
            }

            // wenn es eine FA Leistung ist, darf nur gelöscht werden,
            // wenn es keine Leistungen im A gibt
            qry = DBUtil.OpenSQL(@"
                select Anzahl = count(*)
                from dbo.FaLeistung
                where FaProzessCode between 400 and 499
                and FaFallID = {0}",
                Utils.ConvertToInt(qryFaLeistung["FaFallID"]));

            int anzahl = Utils.ConvertToInt(qry["Anzahl"]);

            if (anzahl > 0)
            {
                KissMsg.ShowInfo(
                    string.Format(
                        "Das Löschen von Alimenten-Fallführungen ist nur möglich, wenn keine Alimenteninkassi existieren.\r\n" +
                        "Es sind aber noch {0} Leistungen in den Alimenten vorhanden.",
                        anzahl));
                throw new KissCancelException();
            }

            // es darf gelöscht werden, also noch abfragen
            if (!KissMsg.ShowQuestion("Soll diese Alimenten-Fallführung wirklich gelöscht werden?"))
                throw new KissCancelException();
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);

            // Kontrollieren, dass Datum von kleiner als Datum bis ist:
            if (!DBUtil.IsEmpty(qryFaLeistung["DatumVon"]) && !DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                if (((DateTime)qryFaLeistung["DatumVon"]).Date > ((DateTime)qryFaLeistung["DatumBis"]).Date)
                {
                    throw new KissInfoException("Das Von-Datum muss kleiner oder gleich als das Bis-Datum sein.");
                }
            }

            // Kontroll-Daten öffnen:
            qryKontrolle.Fill(Utils.ConvertToInt(qryFaLeistung["FaFallID"]));

            // Kontrollieren, dass das Von-Datum kleiner ist
            // als das Von-Datum aller zugehörigen Leistungen
            DateTime minDatum = DBUtil.IsEmpty(qryKontrolle["MinDatumVon"])
                                    ? (DateTime)qryFaLeistung["DatumVon"]
                                    : (DateTime)qryKontrolle["MinDatumVon"];
            DateTime minDatumA = DBUtil.IsEmpty(qryKontrolle["MinDatumVonA"])
                                     ? (DateTime)qryFaLeistung["DatumVon"]
                                     : (DateTime)qryKontrolle["MinDatumVonA"];

            if (!_buttonReopenWurdeGeklickt && ((!_istAlim && (DateTime)qryFaLeistung["DatumVon"] > minDatum) ||
                                               (_istAlim && (DateTime)qryFaLeistung["DatumVon"] > minDatumA)))
            {
                throw new KissInfoException(
                    string.Format(
                        "Das Von-Datum darf nicht grösser sein als das kleinste Von-Datum aller {1}Leistungen ({0}).",
                        minDatum.ToString("dd.MM.yyyy"),
                        _istAlim ? "A-" : "W-, Kg- und Vm-"));
            }

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                //TODO: auf offenen Aufnahmeprozess prüfen
                //TODO: auf offenen Lösungsprozess prüfen
                //TODO: auf offenen vormundschaftliche Massnahme prüfen

                // Wenn der Fall abgeschlossen werden soll, dann nuss ein Grund gewählt sein
                DBUtil.CheckNotNullField(edtAbschlussgrund, lblAbschlussgrund.Text);

                string msg;

                //Kontrolle: existieren offene Pendenzen?
                int countPendenzen = Utils.GetAnzahlOffenePendenzen((int)qryFaLeistung[DBO.FaLeistung.FaLeistungID]);

                if (countPendenzen > 0)
                {
                    msg = string.Format("Es existieren {0} offene Pendenzen zu der abzuschliessenden Leistung.", countPendenzen);
                    KissMsg.ShowInfo(msg);
                }

                // Kontrolle nach offenen Leistungen
                // ----------------------------------
                if (_istAlim && Utils.ConvertToInt(qryKontrolle["AnzahlOffeneLstA"]) > 0)
                {
                    msg = Utils.ConvertToInt(qryKontrolle["AnzahlOffeneLstA"]) == 1
                              ? "Es existiert 1 offene Alimenten-Leistung."
                              : string.Format(
                                  "Es existieren {0} offene Alimenten-Leistungen.",
                                  Utils.ConvertToInt(qryKontrolle["AnzahlOffeneLstA"]));

                    throw new KissInfoException(msg + "\r\n" + "Schliessen Sie zuerst alle offenen Leistungen ab.");
                }

                if (!_istAlim && Utils.ConvertToInt(qryKontrolle["AnzahlOffeneLst"]) > 0)
                {
                    msg = Utils.ConvertToInt(qryKontrolle["AnzahlOffeneLst"]) == 1
                              ? "Es existiert 1 offene Leistung (W, K, M)."
                              : string.Format(
                                  "Es existieren {0} offene Leistungen (W, K, M).",
                                  Utils.ConvertToInt(qryKontrolle["AnzahlOffeneLst"]));

                    throw new KissInfoException(msg + "\r\n" + "Schliessen Sie zuerst alle offenen Leistungen ab.");
                }

                // Kontrollieren, dass das Bis-Datum grösser ist als das Bis-Datum aller anderen Leistungen
                // ----------------------------------------------------------------------------------------
                DateTime maxDatum = DBUtil.IsEmpty(qryKontrolle["MaxDatumBis"])
                                        ? (DateTime)qryFaLeistung["DatumBis"]
                                        : (DateTime)qryKontrolle["MaxDatumBis"];
                DateTime maxDatumA = DBUtil.IsEmpty(qryKontrolle["MaxDatumBisA"])
                                         ? (DateTime)qryFaLeistung["DatumBis"]
                                         : (DateTime)qryKontrolle["MaxDatumBisA"];

                if ((!_istAlim && (DateTime)qryFaLeistung["DatumBis"] < maxDatum) ||
                    (_istAlim && (DateTime)qryFaLeistung["DatumBis"] < maxDatumA))
                {
                    throw new KissInfoException(
                        string.Format(
                            "Das Bis-Datum darf nicht kleiner sein als das grösste Bis-Datum aller {1}Leistungen ({0}).",
                            _istAlim ? maxDatumA.ToString("dd.MM.yyyy") : maxDatum.ToString("dd.MM.yyyy"),
                            _istAlim ? "A-" : "W-, Kg- und Vm-"));
                }
            }

            // Alles OK, also Transaktion starten
            Session.BeginTransaction();
            try
            {
                if (_buttonReopenWurdeGeklickt)
                {
                    // Fall autoamtisch öffnen, falls er abgeschlossen ist
                    var qry = DBUtil.OpenSQL(
                        @"EXEC dbo.spFaFall_Open {0}, {1}, {2}, {3}",
                        qryFaLeistung["FaFallID"],
                        qryFaLeistung["FaLeistungID"],
                        qryFaLeistung["FaProzessCode"],
                        Session.User.UserID
                        );
                    if (Utils.ConvertToString(qry["Error"]) != "")
                    {
                        // Fall konnte aus irgendwelchen Gründen nicht wiedereröffnet werden.
                        throw new KissInfoException(Utils.ConvertToString(qry["Error"]));
                    }
                }
            }
            catch (Exception ex)
            {
                // Alles rückgängig machen:
                Session.Rollback();
                // Wenn versucht wurde, den Fall wieder zu eröffnen, dann hier alles rückgängig machen:
                if (_buttonReopenWurdeGeklickt)
                {
                    qryFaLeistung.Cancel();
                    qryFaLeistung.CanUpdate = true;
                }
                // Das Posten stoppen:
                throw new KissInfoException(ex.Message);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungID, bool istAlim)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            _faLeistungID = faLeistungID;
            _istAlim = istAlim;

            if (istAlim)
            {
                edtAbschlussgrund.LOVFilter = "FA";
            }

            qryFaLeistung.Fill(_faLeistungID);
            _activeImageID = _istAlim
                                 ? DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) ? 1230 : 1232
                                 : DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) ? 1201 : 1202;
        }

        #endregion

        #region Private Methods

        private void SetEditMode()
        {
            if (qryFaLeistung.Count == 0)
            {
                return;
            }

            bool mayRead;
            bool mayIns;
            bool mayUpd;
            bool mayDel;
            bool mayClose;
            bool mayReopen;

            DBUtil.GetFallRights((int)qryFaLeistung["FaLeistungID"], out mayRead, out mayIns, out mayUpd, out mayDel, out mayClose, out mayReopen);

            if (mayClose)
            {
                bool open = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);
                bool archived = !DBUtil.IsEmpty(qryFaLeistung["FaLeistungArchivID"]);

                qryFaLeistung.CanUpdate = open;
                btnReopen.Visible = !open && !archived && mayReopen
                                    && ((DBUtil.UserHasRight("CtlFaLeistung_FallWiederEroeffnen") && !_istAlim)
                                        || (DBUtil.UserHasRight("CtlFaLeistung_FA_FallWiederEroeffnen") && _istAlim));

                if (open)
                {
                    edtDatumVon.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtDatumVon.EditMode = EditModeType.ReadOnly;
                }
            }
            else
            {
                qryFaLeistung.CanUpdate = false;
                btnReopen.Visible = false;
                edtDatumVon.EditMode = EditModeType.ReadOnly;
            }
            qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate);
        }

        #endregion

        #endregion
    }
}