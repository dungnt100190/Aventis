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
    partial class CtlKaProzessEaf : KissUserControl
    {
        private int _baPersonID;
        private int _faLeistungIDSozioberuflicheBilanz;
        private int _faLeistungIDSpezifischeErmittlung;

        public CtlKaProzessEaf()
        {
            InitializeComponent();
        }

        public void Init(string titleName, Image titleImage, int faLeistungId1, int faLeistungId2, int baPersonID, int faProzessCode)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _baPersonID = baPersonID;

            if (faProzessCode == 709)
            {
                _faLeistungIDSozioberuflicheBilanz = faLeistungId1;
                _faLeistungIDSpezifischeErmittlung = faLeistungId2;
            }
            else
            {
                _faLeistungIDSozioberuflicheBilanz = faLeistungId2;
                _faLeistungIDSpezifischeErmittlung = faLeistungId1;
            }

            qryQuery.Fill(_faLeistungIDSozioberuflicheBilanz);
            SetEditMode();
        }

        private void btnReopen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion(typeof(CtlKaProzessEaf).Name, "FallWiedereroeffnen", "Soll der geschlossene Fall wieder geöffnet werden ?"))
            {
                qryQuery.CanUpdate = true;
                qryQuery[DBO.FaLeistung.DatumBis] = DBNull.Value;
                qryQuery.Post();
            }
        }

        private void qryQuery_AfterPost(object sender, EventArgs e)
        {
            try
            {
                KaUtil.UpdateDatumBisAllgemein(_baPersonID);
                Session.Commit();
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }

            SetEditMode();

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryQuery_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(datDatumVon, "Eröffnungsdatum");

            //prüfen, ob DatumVon in eine andere Fallperiode fällt
            var count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                    WHERE LEI.BaPersonID = {0}
                      AND LEI.FaProzessCode IN (709, 710)
                      AND LEI.ModulID = 7
                      AND {1} BETWEEN LEI.DatumVon AND LEI.DatumBis
                      AND LEI.FaLeistungID NOT IN ({2}, {3});",
                _baPersonID,
                qryQuery[DBO.FaLeistung.DatumVon],
                _faLeistungIDSpezifischeErmittlung,
                _faLeistungIDSozioberuflicheBilanz));

            if (count > 0)
            {
                throw new KissInfoException("Das Eröffnungsdatum darf nicht mit einem anderen Fall überschneiden!");
            }

            // Checks bei Abschluss
            if (!DBUtil.IsEmpty(qryQuery[DBO.FaLeistung.DatumBis]))
            {
                // falls DatumBis erfasst, muss es grösser sein als DatumVon
                if ((DateTime)qryQuery[DBO.FaLeistung.DatumVon] > (DateTime)qryQuery[DBO.FaLeistung.DatumBis])
                {
                    throw new KissInfoException("Das Eröffnungsdatum darf nicht nach dem Abschlussdatum sein!");
                }

                var wiederholteSpezifischeErmittlung = (bool)qryQuery[DBO.FaLeistung.WiederholteSpezifischeErmittlungEAF];

                // Austritt Sozioberufliche Bilanz muss erfasst sein
                // 9474 : Falls WiederholteSpezifischeErmittlungEAF aktiv, dann sind KaEafSozioberuflicheBilanz Einträge nicht editierbar
                if (!wiederholteSpezifischeErmittlung)
                {
                    var datumAustrittSozioBilanz = DBUtil.ExecuteScalarSQL(@"
                        SELECT AustrittDatum
                        FROM dbo.KaEafSozioberuflicheBilanz WITH(READUNCOMMITTED)
                        WHERE FaLeistungID = {0};",
                        _faLeistungIDSozioberuflicheBilanz);

                    if (DBUtil.IsEmpty(datumAustrittSozioBilanz))
                    {
                        qryQuery[DBO.FaLeistung.DatumBis] = null;
                        throw new KissInfoException("Die Daten 'Sozioberufliche Bilanz / Austritt' sind nicht erfasst. Die Leistung kann nicht abgeschlossen werden.");
                    }
                }

                // Austritt Spezifische Ermittlung
                var qrySpezifischeErmittlung = DBUtil.OpenSQL(@"
                    SELECT TOP 1
                        AustrittDatum,
                        Zielsetzungen
                    FROM dbo.KaEafSpezifischeErmittlung WITH(READUNCOMMITTED)
                    WHERE FaLeistungID = {0};",
                    _faLeistungIDSpezifischeErmittlung);

                if (wiederholteSpezifischeErmittlung)
                {
                    if (qrySpezifischeErmittlung.IsEmpty)
                    {
                        // 9474 : Falls WiederholteSpezifischeErmittlungEAF Aktiv, dann muss eine 'Spezifische Ermittlung' da sein
                        qryQuery[DBO.FaLeistung.DatumBis] = null;
                        throw new KissInfoException("Es gibt keine Leistung 'Spezifische Ermittlung' und 'wiederholte spezifische Ermittlung' ist aktiv.");
                    }

                    // AustrittDatum und Zielsetzungen obligatorisch
                    if (DBUtil.IsEmpty(qrySpezifischeErmittlung[DBO.KaEafSpezifischeErmittlung.AustrittDatum]) ||
                        string.IsNullOrEmpty(qrySpezifischeErmittlung[DBO.KaEafSpezifischeErmittlung.Zielsetzungen] as string))
                    {
                        qryQuery[DBO.FaLeistung.DatumBis] = null;
                        throw new KissInfoException("Die Daten 'Spezifische Ermittlung / Austritt und Zielsetzungen' sind nicht erfasst. Die Leistung kann nicht abgeschlossen werden.");
                    }
                }
                else
                {
                    // Falls Zielsetzungen nicht eingetragen, dann ist diese Spezifische Ermittlung nicht betrachtet
                    if (qrySpezifischeErmittlung.HasRow && DBUtil.IsEmpty(qrySpezifischeErmittlung[DBO.KaEafSpezifischeErmittlung.AustrittDatum]) &&
                        !string.IsNullOrEmpty(qrySpezifischeErmittlung[DBO.KaEafSpezifischeErmittlung.Zielsetzungen] as string))
                    {
                        qryQuery[DBO.FaLeistung.DatumBis] = null;
                        throw new KissInfoException("Die Daten 'Spezifische Ermittlung / Austritt' sind nicht erfasst. Die Leistung kann nicht abgeschlossen werden.");
                    }
                }

                // Kontrolle offene Pendenzen
                var countPendenzen = Utils.GetAnzahlOffenePendenzen(_faLeistungIDSozioberuflicheBilanz);
                countPendenzen += Utils.GetAnzahlOffenePendenzen(_faLeistungIDSpezifischeErmittlung);
                if (countPendenzen > 0)
                {
                    var msg = KissMsg.GetMLMessage(
                        "CtlFaBeratungsperiode",
                        "OffenePendenzenVorhanden",
                        "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                        countPendenzen);
                    KissMsg.ShowInfo(msg);
                }
            }

            Session.BeginTransaction();
            try
            {
                SynchronizeFaLeistungen(qryQuery);
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void SetEditMode()
        {
            if (qryQuery.Count == 0)
            {
                return;
            }

            var open = DBUtil.IsEmpty(qryQuery[DBO.FaFall.DatumBis]);
            var archived = !DBUtil.IsEmpty(qryQuery[DBO.FaLeistungArchiv.FaLeistungArchivID]);

            qryQuery.EnableBoundFields(qryQuery.CanUpdate && open);
            btnReopen.Visible = !open && !archived && qryQuery.CanUpdate;
        }

        private void SynchronizeFaLeistungen(SqlQuery qrySozioberuflicheB)
        {
            DBUtil.ExecSQL(@"UPDATE dbo.FaLeistung
                               SET DatumVon = {1},
                                   DatumBis = {2}
                             WHERE FaLeistungID = {0};",
                             _faLeistungIDSpezifischeErmittlung,
                             qrySozioberuflicheB[DBO.FaLeistung.DatumVon],
                             qrySozioberuflicheB[DBO.FaLeistung.DatumBis]);
        }
    }
}