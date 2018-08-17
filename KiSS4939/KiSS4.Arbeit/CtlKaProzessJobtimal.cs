using System;
using System.Drawing;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    partial class CtlKaProzessJobtimal : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int BaPersonID = 0;
        private int FaLeistungID = 0;

        #endregion

        #endregion

        #region Constructors

        public CtlKaProzessJobtimal()
        {
            this.InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnReopen_Click(object sender, System.EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaProzessJobtimal", "FallWiedereroeffnen", "Soll der geschlossene Fall wieder geöffnet werden ?"))
            {
                qryFaLeistung.CanUpdate = true;
                qryFaLeistung["DatumBis"] = DBNull.Value;
                qryFaLeistung.Post();
            }
        }

        private void qryFaLeistung_AfterPost(object sender, System.EventArgs e)
        {
            if (CloseAllgemein())
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = GetDate(), Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }
            else
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = null, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }

            SetEditMode();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFaLeistung_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(datDatumVon, "Eröffnungsdatum");

            //falls DatumBis erfasst, muss es grösser sein als DatumVon
            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) && (DateTime)qryFaLeistung["DatumVon"] > (DateTime)qryFaLeistung["DatumBis"])
                throw new KissInfoException("Das Eröffnungsdatum darf nicht nach dem Abschlussdatum sein!");

            //prüfen, ob DatumVon in eine andere Fallperiode fällt
            int Count = (int)DBUtil.ExecuteScalarSQL(@"
                select	count(*)
                from	FaLeistung A
                    inner join FaLeistung B on  B.BaPersonID = A.BaPersonID and
                                B.ModulID = 7 and
                                B.FaProzessCode = A.FaProzessCode and
                                B.FaLeistungID <> A.FaLeistungID and
                                {0} between B.DatumVon and B.DatumBis
                where	A.FaLeistungID = {1}",
                qryFaLeistung["DatumVon"],
                FaLeistungID);

            if (Count > 0)
                throw new KissInfoException("Das Eröffnungsdatum darf nicht mit einem anderen Fall überschneiden!");

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                int cnt = 0;

                // all fields have a value in "Jobtimal Übersicht"?
                cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                                    FROM KaJobtimal
                                    WHERE FaLeistungID = {0}
                                    AND AbschlussDatum IS NOT NULL
                                    AND AustrittgrundCode IS NOT NULL
                                    AND DossierRetouranSDGrundCode IS NOT NULL
                                         "
                                , FaLeistungID));

                if (cnt == 0)
                {
                    datDatumBis.EditValue = null;
                    qryFaLeistung["DatumBis"] = DBNull.Value;
                    throw new KissInfoException("Abschluss nicht möglich!\r\nNicht alle Felder ausgefüllt in Jobtimal Übersicht!\r\n(Datum Abschluss, aus Vermittlung/Einsatz, Grund)");
                }

                // exists Einsätze and are all fields filled?
                cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                                    FROM KaVermittlungVorschlag VOR
                                        INNER JOIN KaVermittlungEinsatz EIN ON EIN.KaVermittlungVorschlagID = VOR.KaVermittlungVorschlagID
                                    WHERE VOR.FaLeistungID = {0}
                                    AND EIN.EinsatzVon IS NOT NULL"
                                , FaLeistungID));

                if (cnt > 0)
                {
                    cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                                    FROM KaVermittlungVorschlag VOR
                                        INNER JOIN KaVermittlungEinsatz EIN ON EIN.KaVermittlungVorschlagID = VOR.KaVermittlungVorschlagID
                                    WHERE VOR.FaLeistungID = {0}
                                    AND (EIN.Abschluss IS NULL
                                        OR EIN.BIBIPSIAbschlussDurchCode IS NULL
                                        OR EIN.SIAbschlussGrundCode IS NULL)
                                    AND EIN.EinsatzVon IS NOT NULL"
                                , FaLeistungID));

                    if (cnt > 0)
                    {
                        datDatumBis.EditValue = null;
                        qryFaLeistung["DatumBis"] = DBNull.Value;
                        throw new KissInfoException("Abschluss nicht möglich!\r\nNicht alle Einsätze korrekt ausgefüllt in Jobtimal  Einsätze\r\n(Datum Einsatzende, durch, Grund)");
                    }
                }

                //Kontrolle offene Pendenzen
                int countPendenzen = Utils.GetAnzahlOffenePendenzen(FaLeistungID);
                if (countPendenzen > 0)
                {
                    string Msg =
                        string.Format(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "OffenePendenzenVorhanden",
                                                           string.Format(
                                                               "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                                                               countPendenzen)));
                    KissMsg.ShowInfo(Msg);
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string TitleName, Image TitleImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitle.Image = TitleImage;
            this.FaLeistungID = FaLeistungID;
            this.BaPersonID = BaPersonID;

            qryFaLeistung.Fill(FaLeistungID);

            SetEditMode();
        }

        public override bool OnSaveData()
        {
            bool ret = qryFaLeistung.Post();
            SetEditMode();
            return ret;
        }

        #endregion

        #region Private Methods

        private bool CloseAllgemein()
        {
            bool rslt = false;

            rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from FaLeistung
                                      where BaPersonID = {0}
                                      and   ModulID = 7
                                      and   FaProzessCode BETWEEN 701 AND 720
                                      and   DatumBis is null",
                BaPersonID)) == 0;

            return rslt;
        }

        private void SetEditMode()
        {
            if (qryFaLeistung.Count == 0) return;

            //nur owner oder admin darf abschliessen
            if (Session.User.IsUserAdmin || (int)qryFaLeistung["UserID"] == Session.User.UserID || DBUtil.UserHasRight("CtlKaProzessJobtimal"))
            {
                bool open = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);
                bool archived = !DBUtil.IsEmpty(qryFaLeistung["FaLeistungArchivID"]);

                qryFaLeistung.CanUpdate = DBUtil.UserHasRight("CtlKaProzessJobtimal", "UI");
                qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate && open);
                btnReopen.Visible = !open && !archived && qryFaLeistung.CanUpdate;
            }
            else
            {
                qryFaLeistung.EnableBoundFields(false);
                btnReopen.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}