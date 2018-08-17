using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// This class is handling the usage of CtlKaTransfer.
    /// </summary>
    public partial class CtlKaTransfer : KissUserControl
    {
        #region Fields

        #region Private Fields

        /* BaPersonID and FaLeistungID will be filled by the Init-Method */
        private int _baPersonID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlKaTransfer()
        {
            InitializeComponent();

            /* Initialize fields */
            _baPersonID = 0;
            _faLeistungID = 0;
        }

        #endregion

        #region EventHandlers

        private void btnReopen_Click(object sender, System.EventArgs e)
        {
            /* If the user wants to reopen the closed Transfer */
            if (KissMsg.ShowQuestion("CtlKaTransfer", "FallWiedereroeffnen", "Soll der geschlossene Fall wieder geöffnet werden?"))
            {
                SetEditMode();

                qryFall.CanUpdate = true;
                qryFall["DatumBis"] = DBNull.Value;
                qryFall.Post();
            }
        }

        private void qryFall_AfterPost(object sender, EventArgs e)
        {
            /* Before closing save the actual data */
            if (CloseAllgemein())
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = GetDate(), Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", _baPersonID, DBUtil.GetDBRowCreatorModifier());
            }
            else
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = null, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", _baPersonID, DBUtil.GetDBRowCreatorModifier());
            }

            SetEditMode();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFall_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(datDatumVon, "Eröffnungsdatum");

            /* falls DatumBis erfasst, muss es grösser sein als DatumVon, sonst gibt es eine Warnung */
            if (!DBUtil.IsEmpty(qryFall["DatumBis"]) && (DateTime)qryFall["DatumVon"] > (DateTime)qryFall["DatumBis"])
                throw new KissInfoException("Das Eröffnungsdatum darf nicht nach dem Abschlussdatum sein!");

            /* prüfen, ob DatumVon in eine andere Fallperiode fällt */
            var count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM FaLeistung A
                  INNER JOIN FaLeistung B ON B.BaPersonID = A.BaPersonID
                    AND B.ModulID = 7
                    AND B.FaProzessCode = A.FaProzessCode
                    AND B.FaLeistungID <> A.FaLeistungID
                    AND {0} BETWEEN B.DatumVon AND B.DatumBis
                WHERE A.FaLeistungID = {1}",
                qryFall["DatumVon"],
                _faLeistungID);

            if (count > 0)
                throw new KissInfoException("Das Eröffnungsdatum darf nicht mit einem anderen Fall überschneiden!");

            /* Kontrolle offene Pendenzen */
            int countPendenzen = Utils.GetAnzahlOffenePendenzen(_faLeistungID);
            if (countPendenzen > 0)
            {
                string msg =
                    string.Format(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "OffenePendenzenVorhanden",
                                                       string.Format(
                                                           "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                                                           countPendenzen)));
                KissMsg.ShowInfo(msg);
            }

            CheckAbschlussIsValid();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            FillQryFall();
            SetEditMode();
        }

        public override bool OnSaveData()
        {
            bool ret = qryFall.Post();
            SetEditMode();
            return ret;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Wenn DatumBis gesetzt ist, wird geprüft, ob die Leistung wirklich geschlossen werden darf.
        /// </summary>
        private void CheckAbschlussIsValid()
        {
            if (!DBUtil.IsEmpty(qryFall["DatumBis"]))
            {
                var count = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                                            SELECT
                                              COUNT(*)
                                            FROM
                                              KaTransfer
                                            WHERE
                                              FaLeistungID = {0} AND
                                              AustrittDat IS NOT NULL AND
                                              AustrittGrund IS NOT NULL;
                                        ", _faLeistungID);
                if (count == 0)
                {
                    datDatumBis.EditValue = null;
                    qryFall["DatumBis"] = DBNull.Value;
                    throw new KissInfoException("Abschluss nicht möglich!\r\nAustrittsdatum sowie Austrittsgrund dürfen nicht leer sein!");
                }
            }
        }

        private bool CloseAllgemein()
        {
            var rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*) FROM FaLeistung WITH(READUNCOMMITTED)
                                          WHERE BaPersonID = {0}
                                            AND ModulID = 7
                                            AND FaProzessCode BETWEEN 701 AND 720
                                            AND DatumBis IS NULL",
                                        _baPersonID)
                            ) == 0;

            return rslt;
        }

        private void FillQryFall()
        {
            qryFall.Fill(_faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));

            var a = qryFall["Grund"];
        }

        private void SetEditMode()
        {
            if (qryFall.Count == 0) return;

            /* nur owner oder admin darf abschliessen */
            if (Session.User.IsUserAdmin || (int)qryFall["UserID"] == Session.User.UserID || DBUtil.UserHasRight("CtlKaTransfer"))
            {
                bool open = DBUtil.IsEmpty(qryFall["DatumBis"]);
                bool archived = !DBUtil.IsEmpty(qryFall["FaLeistungArchivID"]);

                qryFall.CanUpdate = DBUtil.UserHasRight("CtlKaTransfer", "UI");
                qryFall.EnableBoundFields(qryFall.CanUpdate && open);
                btnReopen.Visible = !open && !archived && qryFall.CanUpdate;
            }
            else
            {
                qryFall.EnableBoundFields(false);
                btnReopen.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}