using System;
using System.Drawing;

using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaProzess.
    /// </summary>
    public partial class CtlKaProzessAK : KissUserControl
    {
        private int _baPersonID;
        private int _faLeistungID;

        public CtlKaProzessAK()
        {
            InitializeComponent();
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;

            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            qryFall.Fill(faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));

            SetEditMode();
        }

        private void btnReopen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaProzessAK", "FallWiedereroeffnen", "Soll der geschlossene Fall wieder geöffnet werden ?"))
            {
                qryFall.CanUpdate = true;
                qryFall[DBO.FaLeistung.DatumBis] = DBNull.Value;
                qryFall.Post();
            }
        }

        private bool CloseAllgemein()
        {
            bool rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                    WHERE BaPersonID = {0}
                      AND ModulID = 7
                      AND FaProzessCode BETWEEN 701 AND 720
                      AND DatumBis IS NULL;",
                    _baPersonID)) == 0;

            return rslt;
        }

        private void qryFall_AfterPost(object sender, EventArgs e)
        {
            if (CloseAllgemein())
            {
                DBUtil.ExecSQL(@"
                    UPDATE dbo.FaLeistung
                    SET DatumBis = GETDATE(), Modifier = {1}, Modified = GETDATE()
                    WHERE BaPersonID = {0}
                      AND ModulID = 7
                      AND FaProzessCode = 700;", _baPersonID, DBUtil.GetDBRowCreatorModifier());
            }
            else
            {
                DBUtil.ExecSQL(@"
                    UPDATE dbo.FaLeistung
                    SET DatumBis = NULL, Modifier = {1}, Modified = GETDATE()
                    WHERE BaPersonID = {0}
                      AND ModulID = 7
                      AND FaProzessCode = 700;", _baPersonID, DBUtil.GetDBRowCreatorModifier());
            }

            SetEditMode();

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFall_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(datDatumVon, "Eröffnungsdatum");

            //falls DatumBis erfasst, muss es grösser sein als DatumVon
            if (!DBUtil.IsEmpty(qryFall[DBO.FaLeistung.DatumBis]) && (DateTime)qryFall[DBO.FaLeistung.DatumVon] > (DateTime)qryFall[DBO.FaLeistung.DatumBis])
            {
                throw new KissInfoException("Das Eröffnungsdatum darf nicht nach dem Abschlussdatum sein!");
            }

            //prüfen, ob DatumVon in eine andere Fallperiode fällt
            var count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung         A WITH(READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung B WITH(READUNCOMMITTED) ON B.BaPersonID = A.BaPersonID
                                                                   AND B.ModulID = 7
                                                                   AND B.FaProzessCode = A.FaProzessCode
                                                                   AND B.FaLeistungID <> A.FaLeistungID
                                                                   AND {0} BETWEEN B.DatumVon AND B.DatumBis
                WHERE A.FaLeistungID = {1};",
                qryFall[DBO.FaLeistung.DatumVon],
                _faLeistungID);

            if (count > 0)
                throw new KissInfoException("Das Eröffnungsdatum darf nicht mit einem anderen Fall überschneiden!");

            if (!DBUtil.IsEmpty(qryFall[DBO.FaLeistung.DatumBis]))
            {
                int cnt = Convert.ToInt32(
                    DBUtil.ExecuteScalarSQL(@"
                        SELECT (SELECT COUNT(1)
                                FROM dbo.KaAbklaerungIntake KAI WITH (READUNCOMMITTED)
                                WHERE KAI.FaLeistungID = {0}
                                  AND (KAI.DatumIntegration IS NULL OR KAI.KaAbklaerungIntegrBeurCode IS NULL)
                               ) +
                               (SELECT COUNT(1)
                                FROM dbo.KaAbklaerungVertieft KAV WITH (READUNCOMMITTED)
                                WHERE KAV.FaLeistungID = {0}
                                  AND (KAV.DatumIntegration IS NULL OR KAV.KaAbklaerungIntegrBeurCode IS NULL)
                               );",
                        _faLeistungID));

                if (cnt > 0)
                {
                    qryFall[DBO.FaLeistung.DatumBis] = null;
                    throw new KissInfoException("Abschluss nicht möglich!\r\nEs existieren noch Phasen ohne Integrationsbeurteilung!");
                }

                //Kontrolle offene Pendenzen
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
            }
        }

        private void SetEditMode()
        {
            if (qryFall.Count == 0) return;

            //nur owner oder admin darf abschliessen
            if (Session.User.IsUserAdmin || (int)qryFall[DBO.FaLeistung.UserID] == Session.User.UserID || DBUtil.UserHasRight("CtlKaProzessAK"))
            {
                bool open = DBUtil.IsEmpty(qryFall[DBO.FaLeistung.DatumBis]);
                bool archived = !DBUtil.IsEmpty(qryFall["FaLeistungArchivID"]);

                qryFall.CanUpdate = DBUtil.UserHasRight("CtlKaProzessAK", "UI");
                qryFall.EnableBoundFields(qryFall.CanUpdate && open);
                btnReopen.Visible = !open && !archived && qryFall.CanUpdate;
            }
            else
            {
                qryFall.EnableBoundFields(false);
                btnReopen.Visible = false;
            }
        }
    }
}