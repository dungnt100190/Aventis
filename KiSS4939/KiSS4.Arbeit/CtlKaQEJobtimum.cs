using System;
using System.Drawing;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQEJobtimum.
    /// </summary>
    public partial class CtlKaQEJobtimum : KissUserControl
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int _baPersonID;

        private int _faLeistungID;
        private bool _mayClose;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpd;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlKaQEJobtimum"/> class.
        /// </summary>
        public CtlKaQEJobtimum()
        {
            // logging
            Logger.Debug("enter");

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // logging
            Logger.Debug("done");
        }

        public override object GetContextValue(string fieldName)
        {
            // logging
            Logger.Debug("call");

            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);

                case "SICHTBARFLAG":
                    return KaUtil.GetSichtbarSDFlag(_baPersonID);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            // logging
            Logger.Debug("enter");

            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            // logging
            Logger.Debug("done");
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void btnPraesenzzeit_Click(object sender, EventArgs e)
        {
            // logging
            Logger.Debug("call");

            ((KissMainForm)Session.MainForm).OpenChildForm(typeof(FrmKaPraesenzzeit));
            FrmKaPraesenzzeit frmPraesenz = (FrmKaPraesenzzeit)((KissMainForm)Session.MainForm).GetChildForm(typeof(FrmKaPraesenzzeit));
            frmPraesenz.SetKlientX(_baPersonID);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // logging
            Logger.Debug("call");

            if (KissMsg.ShowQuestion(Name, "WertAustrittZuruecksetzen_v01", "Folgende Werte zurücksetzen:\r\nDatum, Austrittsgrund (inkl. Auswahl)?"))
            {
                datAustritt.EditValue = null;
                rgAustrittGrund.EditValue = null;
                ddlAustrittGrund.EditValue = null;

                rgAustrittGrund.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaQEJobtimum_Load(object sender, EventArgs e)
        {
            // logging
            Logger.Debug("enter");

            SetEditMode();
            FillJobtimum();
            qryVerlauf.Last();

            // logging
            Logger.Debug("done");
        }

        private void ddlAustrittGrund_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            // logging
            Logger.Debug("enter");

            if (qryJobtimum.IsFilling)
            {
                // logging
                Logger.Debug("done, IsFilling=True");

                return;
            }

            if (DBUtil.IsEmpty(e.NewValue))
            {
                if (!DBUtil.IsEmpty(rgAustrittGrund.EditValue))
                {
                    if (KissMsg.ShowQuestion(Name, "WertAustrittLoeschen", "Wert in Austrittsgrund 'Abbruch' löschen?"))
                    {
                        rgAustrittGrund.EditValue = null;
                        rgAustrittGrund.EditMode = EditModeType.ReadOnly;
                    }
                    else
                    {
                        ddlAustrittGrund.EditValue = e.OldValue;
                        rgAustrittGrund.EditMode = EditModeType.Normal;
                        e.Cancel = true;
                    }
                }

                // logging
                Logger.Debug("done, e.NewValue IsEmpty=True");

                // done
                return;
            }

            if (Convert.ToInt32(e.NewValue) == 4)
            {
                rgAustrittGrund.EditMode = EditModeType.Normal;
            }
            else
            {
                if (DBUtil.IsEmpty(rgAustrittGrund.EditValue))
                {
                    rgAustrittGrund.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    if (KissMsg.ShowQuestion("CtlKaQEJobtimum", "WertAustrittLoeschen", "Wert in Austrittsgrund 'Abbruch' löschen?"))
                    {
                        rgAustrittGrund.EditValue = null;
                        rgAustrittGrund.EditMode = EditModeType.ReadOnly;
                    }
                    else
                    {
                        ddlAustrittGrund.EditValue = e.OldValue;
                        rgAustrittGrund.EditMode = EditModeType.Normal;
                        e.Cancel = true;
                    }
                }
            }

            // logging
            Logger.Debug("done");
        }

        private void FillJobtimum()
        {
            // logging
            Logger.Debug("enter");

            // Create row in KaQEJobtimum if there is no entry.
            if (!JobtimumExists() && DBUtil.UserHasRight("CtlKaQEJobtimum") && _mayUpd)
            {
                // logging
                Logger.Debug("create entry");

                DBUtil.ExecSQL(@"
                    INSERT INTO KaQEJobtimum (FaLeistungID, SichtbarSDFlag)
                    VALUES ({0}, {1})", _faLeistungID, KaUtil.IsVisibleSD(_baPersonID));
            }

            // logging
            Logger.Debug("fill datasources");

            qryJobtimum.Fill(@"
                SELECT KAJ.*
                FROM dbo.KaQEJobtimum KAJ
                WHERE KAJ.FaLeistungID = {0}
                  AND (KAJ.SichtbarSDFlag = {1} OR KAJ.SichtbarSDFlag = 1)", _faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));

            qryAnweisung.Fill(@"
                SELECT TOP 1
                        KAE.*,
                        EinsatzplatzName = KEP.Name,
                        ALKAnzeige = ORG.InstitutionNr + isNull(', ' + ORG.Name, '') + isNull(', ' + ADR.Ort, ''),
                        ALKasse = ORG.InstitutionNr + isNull(', ' + ORG.Name, ''),
                        ZustKA = XUR.LastName + isNull(', ' + XUR.FirstName,''),
                        Zuweiser = case when KAE.ZuweiserID < 0 then
                                            XUR2.LastName + isNull(', ' + XUR2.FirstName,'')
                                        else OKO.Name + isNull(', ' + OKO.Vorname,'')
                                        end,
                        ZuweiserAnzeige = case when KAE.ZuweiserID < 0 then
                                                    XUR2.LastName + isNull(' ' + XUR2.FirstName,'') + isNull(', ' + XOU.ItemName, '') + isNull(', ' + XUR2.Phone, '')
                                                else OKO.Name + isNull(' ' + OKO.Vorname,'') + isNull(', ' + ORG1.Name, '') + isNull(', ' + OKO.Telefon, '')
                                                end,
                        ZuweiserName = case when KAE.ZuweiserID < 0 then XUR2.LastName else OKO.Name end,
                        ZuweiserVorname = case when KAE.ZuweiserID < 0 then XUR2.FirstName else OKO.Vorname end,
                        InstNr = ORG.InstitutionNr,
                        Coach = XUR1.LastName + isNull(', ' + XUR1.FirstName,''),
                        Tel = ISNULL(PRS.Telefon_P + ISNULL(', ' + PRS.MobilTel, ''), ISNULL(PRS.MobilTel, ''))
                FROM dbo.KaEinsatz                     KAE  WITH (READUNCOMMITTED)
                    LEFT JOIN dbo.KaEinsatzplatz2      KEP  WITH (READUNCOMMITTED) ON KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
                    LEFT JOIN dbo.BaInstitution        ORG  WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = KAE.ALKasseID
                    LEFT JOIN dbo.BaAdresse	           ADR  WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = ORG.BaInstitutionID
                    LEFT JOIN dbo.KaZuteilFachbereich  PRZ  WITH (READUNCOMMITTED) ON PRZ.BaPersonID = {1}
                                                                                 AND PRZ.ZuteilungBis = (SELECT MAX(PRZ1.ZuteilungBis)
                                                                                                         FROM dbo.KaZuteilFachbereich PRZ1 WITH (READUNCOMMITTED)
                                                                                                         WHERE PRZ1.BaPersonID = PRZ.BaPersonID)
                    LEFT JOIN dbo.XUser			       XUR  WITH (READUNCOMMITTED) ON XUR.UserID = PRZ.ZustaendigKaID
                    LEFT JOIN dbo.BaInstitutionKontakt OKO  WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID
                    LEFT JOIN dbo.BaInstitution        ORG1 WITH (READUNCOMMITTED) ON ORG1.BaInstitutionID =  OKO.BaInstitutionID
                    LEFT JOIN dbo.FaLeistung		   FAL  WITH (READUNCOMMITTED) ON FAL.FaLeistungID = {0}
                    LEFT JOIN dbo.XUser			       XUR1 WITH (READUNCOMMITTED) ON XUR1.UserID = FAL.UserID
                    LEFT JOIN dbo.XUser			       XUR2 WITH (READUNCOMMITTED) ON XUR2.UserID = -KAE.ZuweiserID
                    LEFT JOIN dbo.XOrgUnit_User        OUU  WITH (READUNCOMMITTED) ON OUU.UserID = -KAE.ZuweiserID
                                                                                  AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
                    LEFT JOIN dbo.XOrgUnit             XOU  WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                    LEFT JOIN dbo.BaPerson             PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = KAE.BaPersonID
                WHERE KAE.BaPersonID = {1}
                  AND (KAE.SichtbarSDFlag = {2} OR KAE.SichtbarSDFlag = 1)
                ORDER BY KAE.DatumBis DESC",
                _faLeistungID, _baPersonID, KaUtil.GetSichtbarSDFlag(_baPersonID));

            qryVerlauf.Fill(@"
                    SELECT Datum       = KAV.Datum,
                           Kontaktpers = KAV.Kontaktperson,
                           Stichwort   = KAV.Stichwort,
                           Thema       = dbo.fnLOVTextListe('KaAllgemThema', KAV.KaAllgemThemaCodes),
                           Autor       = USR.NameVorname
                    FROM dbo.KaVerlauf     KAV WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.vwUser USR WITH (READUNCOMMITTED) ON USR.UserID = KAV.UserID
                    WHERE KAV.FaLeistungID = (SELECT FaLeistungID
                                              FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                              WHERE BaPersonID = {0}
                                                AND ModulID = 7
                                                AND FaProzessCode = 700)
                      AND (KAV.SichtbarSDFlag IS NULL
                        OR KAV.SichtbarSDFlag = {1}
                        OR KAV.SichtbarSDFlag = 1)
                ORDER BY KAV.Datum;",
                _baPersonID,
                KaUtil.GetSichtbarSDFlag(_baPersonID));

            qryCoachDates.Fill(@"
                DECLARE @Date1 DATETIME;
                DECLARE @Date2 DATETIME;
                DECLARE @Date3 DATETIME;
                DECLARE @Date4 DATETIME;
                DECLARE @Date5 DATETIME;

                DECLARE cursorDate CURSOR STATIC FOR
                    SELECT TOP 5 KAV.Datum
                    FROM dbo.KaVerlauf KAV
                    WHERE KAV.FaLeistungID = (SELECT FAL.FaLeistungID
                                              FROM FaLeistung FAL
                                              WHERE FAL.BaPersonID = {0}
                                              AND FAL.ModulID = 7
                                              AND FAL.FaProzessCode = 700)

                      AND KAV.KaAllgemKontaktartCode = 8
                      AND (KAV.SichtbarSDFlag IS NULL
                        OR KAV.SichtbarSDFlag = {1}
                        OR KAV.SichtbarSDFlag = 1)
                    ORDER BY KAV.Datum

                OPEN cursorDate
                FETCH NEXT FROM cursorDate INTO @Date1
                FETCH NEXT FROM cursorDate INTO @Date2
                FETCH NEXT FROM cursorDate INTO @Date3
                FETCH NEXT FROM cursorDate INTO @Date4
                FETCH NEXT FROM cursorDate INTO @Date5
                CLOSE cursorDate
                DEALLOCATE cursorDate

                SELECT CoachDate1 = @Date1,
                       CoachDate2 = @Date2,
                       CoachDate3 = @Date3,
                       CoachDate4 = @Date4,
                       CoachDate5 = @Date5",
                _baPersonID,
                KaUtil.GetSichtbarSDFlag(_baPersonID));

            qrySequenzen.Fill(@"
                SELECT Sequenz = dbo.fnLOVText('KaJobSequenzen', SequenzCode), *
                FROM dbo.KaSequenzen
                WHERE BaPersonID = {0}
                  AND PraesenzCode IS NOT NULL
                  AND (SichtbarSDFlag = {1} or SichtbarSDFlag = 1)
                ORDER BY SequenzCode", _baPersonID, KaUtil.GetSichtbarSDFlag(_baPersonID));

            // logging
            Logger.Debug("done");
        }

        private bool JobtimumExists()
        {
            // logging
            Logger.Debug("call");

            var rslt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.KaQEJobtimum
                WHERE FaLeistungID = {0}", _faLeistungID)) > 0;

            return rslt;
        }

        private void qryJobtimum_AfterPost(object sender, EventArgs e)
        {
            try
            {
                KaUtil.UpdateKaArbeitsRapportRecords(_faLeistungID);

                Session.Commit();
            }
            catch (Exception exc)
            {
                Session.Rollback();
                KissMsg.ShowInfo(exc.Message);
                throw new KissCancelException();
            }
        }

        private void qryJobtimum_BeforePost(object sender, EventArgs e)
        {
            // logging
            Logger.Debug("enter");

            if (!DBUtil.IsEmpty(datAustritt.EditValue))
            {
                DBUtil.CheckNotNullField(ddlAustrittGrund, lblAustrittGrund.Text);
            }

            if (!DBUtil.IsEmpty(ddlAustrittGrund.EditValue))
            {
                DBUtil.CheckNotNullField(datAustritt, "Austrittsdatum");

                if (Convert.ToInt32(ddlAustrittGrund.EditValue) == 4)
                {
                    DBUtil.CheckNotNullField(rgAustrittGrund, "Austrittsgrund 'Abbruch'");
                }
            }

            // logging
            Logger.Debug("done");

            var austrittsdatum = qryJobtimum["AustrittDatum"] as DateTime?;

            if (KaUtil.IsDatePartOfAnArbeitsRapportRange(_faLeistungID, austrittsdatum))
            {
                // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
                DateTime? datumVon;
                DateTime? datumBis;
                var hatArbeitsrapport = KaUtil.WouldKaArbeitsRapportRecordsBeDeleted(_faLeistungID, austrittsdatum, out datumVon, out datumBis);

                // wenn ja, fragen ob die Daten gelöscht werden können
                if (hatArbeitsrapport && datumVon.HasValue && datumBis.HasValue)
                {
                    var answer = KissMsg.ShowQuestion(
                        Name,
                        "FrageZeiterfassungLoeschen",
                        "Es sind bereits Daten für die Präsenzzeiterfassung vor dem {0} oder nach dem {1} vorhanden." + Environment.NewLine +
                        "Wollen Sie diese Daten löschen?",
                        true,
                        datumVon.Value.ToShortDateString(),
                        datumBis.Value.ToShortDateString());

                    if (!answer)
                    {
                        throw new KissCancelException();
                    }
                }
            }
            else
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(Name, "ErrorDatumNichtInnerhalbZeiterfassung_V2", "Das Austrittsdatum liegt nicht innerhalb einer Anweisung."));
            }

            Session.BeginTransaction();
        }

        private void SetEditMode()
        {
            // logging
            Logger.Debug("call");

            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);
            qryJobtimum.CanUpdate = _mayUpd && DBUtil.UserHasRight("CtlKaQEJobtimum", "U");
            qryJobtimum.CanInsert = _mayIns && DBUtil.UserHasRight("CtlKaQEJobtimum", "I");
            qryJobtimum.CanDelete = _mayDel && DBUtil.UserHasRight("CtlKaQEJobtimum", "D");
            qryJobtimum.EnableBoundFields();

            btnReset.Enabled = _mayUpd && DBUtil.UserHasRight("CtlKaQEJobtimum", "U");
        }
    }
}