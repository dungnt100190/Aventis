using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQEEPQ.
    /// </summary>
    public partial class CtlKaQEEPQ : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _baPersonID = 0;
        private int _faLeistungID = 0;
        private bool _isFillEpq; // flag used to store if currently filling datasources within method FillEPQ()
        private bool _mayClose;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpd;
        private bool _userDel;
        private bool _userIns;
        private bool _userUpd;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlKaQEEPQ"/> class.
        /// </summary>
        public CtlKaQEEPQ()
        {
            // logging
            _logger.Debug("enter");

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region EventHandlers

        private void btnPraesenzzeit_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("call");

            ((KissMainForm)Session.MainForm).OpenChildForm(typeof(FrmKaPraesenzzeit));
            var frmPraesenz = (FrmKaPraesenzzeit)((KissMainForm)Session.MainForm).GetChildForm(typeof(FrmKaPraesenzzeit));
            frmPraesenz.SetKlientX(_baPersonID);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("call");

            if (KissMsg.ShowQuestion(Name, "WerteZuruecksetzen_v01", "Folgende Werte zurücksetzen:\r\nDatum, Austrittsgrund (inkl. Auswahl)?"))
            {
                datAustrittDatum.EditValue = null;
                rgGrund.EditValue = null;
                ddlGrund.EditValue = null;

                ddlGrund.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaQEEPQ_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            //FillEPQ();
            //SetDropDownGrund();
            qryVerlauf.Last();

            // logging
            _logger.Debug("done");
        }

        private void qryEPQ_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            if (!DBUtil.IsEmpty(datAustrittDatum.EditValue))
            {
                DBUtil.CheckNotNullField(rgGrund, lblGrund.Text);
            }

            if (!DBUtil.IsEmpty(rgGrund.EditValue))
            {
                DBUtil.CheckNotNullField(datAustrittDatum, "Austrittsdatum");
            }

            if (rgGrund.SelectedIndex == 0)
            {
                DBUtil.CheckNotNullField(ddlGrund, "Auswahl Austrittsgrund");
            }

            if (rgProgBeginn.EditValue.ToString().Equals("1"))
            {
                qryEPQ["ProgBeginn"] = true;
            }
            else if (rgProgBeginn.EditValue.ToString().Equals("0"))
            {
                if (DBUtil.IsEmpty(chlIntakeCodes.EditValue))
                {
                    tabControlEPQ.SelectedTabIndex = tpgIntake.TabIndex;
                    chlIntakeCodes.Focus();
                    throw new KissInfoException("Min. 1 Auswahlfeld auswählen in Intake!\r\n(Programmbeginn = Nein)");
                }

                qryEPQ["ProgBeginn"] = false;
            }

            // logging
            _logger.Debug("done");

            // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
            DateTime? datumVon;
            DateTime? datumBis;
            var hatArbeitsrapport = KaUtil.WouldKaArbeitsRapportRecordsBeDeleted(_faLeistungID, qryEPQ["AustrittDatum"] as DateTime?, out datumVon, out datumBis);

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

            Session.BeginTransaction();
        }

        private void qryZielvereinb_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            qryZielvereinb["FaLeistungID"] = _faLeistungID;
            qryZielvereinb["SichtbarSDFlag"] = KaUtil.IsVisibleSD(_baPersonID);

            // logging
            _logger.Debug("done");
        }

        private void qryZielvereinbVerl_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            qryZielvereinbVerl["FaLeistungID"] = _faLeistungID;
            qryZielvereinbVerl["SichtbarSDFlag"] = KaUtil.IsVisibleSD(_baPersonID);

            // logging
            _logger.Debug("done");
        }

        private void rgGrund_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            if (_isFillEpq || qryEPQ.IsFilling || DBUtil.IsEmpty(e.NewValue))
            {
                // logging
                _logger.Debug("done, _isFillEPQ=True || IsFilling=True || IsEmpty(e.NewValue)=True");

                // done
                return;
            }

            if (Convert.ToInt32(e.NewValue) == 1)
            {
                ddlGrund.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                if (DBUtil.IsEmpty(ddlGrund.EditValue))
                {
                    ddlGrund.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    if (KissMsg.ShowQuestion(Name, "WertAustrittsgrundLoeschen", "Wert in Auswahl Austrittsgrund löschen?"))
                    {
                        // delete entry
                        ddlGrund.EditValue = null;
                        ddlGrund.EditMode = EditModeType.ReadOnly;
                    }
                    else
                    {
                        rgGrund.SelectedIndex = Convert.ToInt32(e.OldValue) - 1;
                        e.Cancel = true;
                    }
                }
            }

            // logging
            _logger.Debug("done");
        }

        private void rgGrund_SelectedIndexChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // update dropdown
            SetDropDownGrund();

            // logging
            _logger.Debug("done");
        }

        private void tabControlEPQ_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // logging
            _logger.Debug("enter");

            SetEditMode();

            // logging
            _logger.Debug("done");
        }

        private void tabControlEPQ_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: Mit Leo besprechen, ob aus seiner Sicht sinnvoll...
            /*
            // logging
            _logger.Debug("enter");

            // can only switch tpg if properly saved
            e.Cancel = !OnSaveData();

            // logging
            _logger.DebugFormat("e.Cancel={0}", e.Cancel);
            _logger.Debug("done");
            */
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");

            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT UserID
                        FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                        WHERE FaLeistungID = {0};", _faLeistungID));

                case "SICHTBARFLAG":
                    return KaUtil.GetSichtbarSDFlag(_baPersonID);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            // logging
            _logger.Debug("enter");

            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            FillEpq();
            SetDropDownGrund();

            // logging
            _logger.Debug("done");
        }

        public override bool OnSaveData()
        {
            // #6330: Fehler auf Integration, Button zurücksetzen Austritt EPQ
            // to promote the changes being done directly on the controls, we have to perform EndCurrentEdit().
            // this method is also invoked in KissDataNavigator.SaveData(), which is bypassed by overriding OnSaveData().
            ActiveSQLQuery.EndCurrentEdit();

            // logging
            _logger.Debug("enter");

            // check if need to save changes and reload data (performance booster when closing control)
            if ((!qryEPQ.RowModified && (qryEPQ.Row == null || qryEPQ.Row.RowState == System.Data.DataRowState.Unchanged)) &&
                (!qryZielvereinb.RowModified && (qryZielvereinb.Row == null || qryZielvereinb.Row.RowState == System.Data.DataRowState.Unchanged)) &&
                (!qryZielvereinbVerl.RowModified && (qryZielvereinbVerl.Row == null || qryZielvereinbVerl.Row.RowState == System.Data.DataRowState.Unchanged)))
            {
                // logging
                _logger.Debug("done, nothing to save");

                // nothing to save
                return true;
            }

            bool ret1 = qryEPQ.Post();
            bool ret2 = qryZielvereinb.Post();
            bool ret3 = qryZielvereinbVerl.Post();
            bool result = (ret1 && ret2 && ret3);

            if (result)
            {
                // reload data
                FillEpq();
            }

            // logging
            _logger.DebugFormat("done, return='{0}'", result);

            // done
            return result;
        }

        #endregion

        #region Private Methods

        private bool EpqExists()
        {
            // logging
            _logger.Debug("call");

            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.KaQEEPQ
                WHERE FaLeistungID = {0};", _faLeistungID)) > 0;
        }

        private void FillEpq()
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // set flag
                _isFillEpq = true;

                SetEditMode();

                // create row in KaQEEPQ if there is no entry.
                if (!EpqExists() && DBUtil.UserHasRight("CtlKaQEEPQ") && _mayUpd)
                {
                    // logging
                    _logger.Debug("create new row");

                    DBUtil.ExecSQL(@"
                        INSERT INTO dbo.KaQEEPQ (FaLeistungID, SichtbarSDFlag)
                        VALUES ({0}, {1});", _faLeistungID, KaUtil.IsVisibleSD(_baPersonID));
                }

                // logging
                _logger.Debug("fill datasources");

                qryEPQ.Fill(@"
                    SELECT EPQ.*,
                           ProgBeg = CASE
                                       WHEN EPQ.ProgBeginn = 1 THEN '1'
                                       ELSE CASE
                                              WHEN EPQ.ProgBeginn = 0 THEN '0'
                                              ELSE NULL
                                            END
                                     END
                    FROM dbo.KaQEEPQ EPQ WITH (READUNCOMMITTED)
                    WHERE EPQ.FaLeistungID = {0}
                      AND (EPQ.SichtbarSDFlag = {1} OR EPQ.SichtbarSDFlag = 1);", _faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));

                qryAnweisung.Fill(@"
                    SELECT TOP 1
                           KAE.*,
                           EinsatzplatzName = KEP.Name,
                           ALKAnzeige       = ORG.InstitutionNr + isNull(', ' + ORG.Name, '') + isNull(', ' + ADR.Ort, ''),
                           ALKasse          = ORG.InstitutionNr + isNull(', ' + ORG.Name, ''),
                           ZustKA           = XUR.LastName + isNull(', ' + XUR.FirstName,''),
                           Zuweiser         = CASE
                                                WHEN KAE.ZuweiserID < 0 THEN XUR2.LastName + ISNULL(', ' + XUR2.FirstName,'')
                                                ELSE OKO.Name + ISNULL(', ' + OKO.Vorname,'')
                                              END,
                           ZuweiserAnzeige  = CASE
                                                WHEN KAE.ZuweiserID < 0 THEN XUR2.LastName +
                                                                             ISNULL(' ' + XUR2.FirstName,'') +
                                                                             ISNULL(', ' + XOU.ItemName, '') +
                                                                             ISNULL(', ' + XUR2.Phone, '')
                                                else OKO.Name + ISNULL(' ' + OKO.Vorname,'') +
                                                                ISNULL(', ' + ORG1.Name, '') +
                                                                ISNULL(', ' + OKO.Telefon, '')
                                              END,
                           ZuweiserName     = CASE
                                                WHEN KAE.ZuweiserID < 0 THEN XUR2.LastName
                                                ELSE OKO.Name
                                              END,
                           ZuweiserVorname  = CASE
                                                WHEN KAE.ZuweiserID < 0 THEN XUR2.FirstName
                                                ELSE OKO.Vorname
                                              END,
                           InstNr           = ORG.InstitutionNr,
                           Coach            = XUR1.LastName + isNull(', ' + XUR1.FirstName,''),
                           Tel              = ISNULL(PRS.Telefon_P + ISNULL(', ' + PRS.MobilTel, ''), ISNULL(PRS.MobilTel, ''))
                    FROM dbo.KaEinsatz               KAE  WITH (READUNCOMMITTED)
                      LEFT JOIN KaEinsatzplatz2      KEP  WITH (READUNCOMMITTED) ON KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
                      LEFT JOIN BaInstitution        ORG  WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = KAE.ALKasseID
                      LEFT JOIN BaAdresse            ADR  WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = ORG.BaInstitutionID
                      LEFT JOIN KaZuteilFachbereich  PRZ  WITH (READUNCOMMITTED) ON PRZ.BaPersonID = {1}
                                                                                AND PRZ.ZuteilungBis = (SELECT MAX(PRZ1.ZuteilungBis)
                                                                                                        FROM dbo.KaZuteilFachbereich PRZ1 WITH (READUNCOMMITTED)
                                                                                                        WHERE PRZ1.BaPersonID = PRZ.BaPersonID)
                      LEFT JOIN XUser                XUR  WITH (READUNCOMMITTED) ON XUR.UserID = PRZ.ZustaendigKaID
                      LEFT JOIN BaInstitutionKontakt OKO  WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID
                      LEFT JOIN BaInstitution        ORG1 WITH (READUNCOMMITTED) ON ORG1.BaInstitutionID =  OKO.BaInstitutionID
                      LEFT JOIN FaLeistung           FAL  WITH (READUNCOMMITTED) ON FAL.FaLeistungID = {0}
                      LEFT JOIN XUser                XUR1 WITH (READUNCOMMITTED) ON XUR1.UserID = FAL.UserID
                      LEFT JOIN XUser                XUR2 WITH (READUNCOMMITTED) ON XUR2.UserID = -KAE.ZuweiserID
                      LEFT JOIN XOrgUnit_User        OUU  WITH (READUNCOMMITTED) ON OUU.UserID = -KAE.ZuweiserID
                                                                                AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
                      LEFT JOIN XOrgUnit             XOU WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                      LEFT JOIN BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KAE.BaPersonID
                    WHERE KAE.BaPersonID = {1}
                      AND (KAE.SichtbarSDFlag = {2} OR KAE.SichtbarSDFlag = 1)
                    ORDER BY KAE.DatumBis DESC", _faLeistungID, _baPersonID, KaUtil.GetSichtbarSDFlag(_baPersonID));

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

                qryDates.Fill(@"
                    SELECT ZielDate1 = (SELECT MIN(FeinzielDat)
                                        FROM dbo.KaQEEPQZielvereinb WITH (READUNCOMMITTED)
                                        WHERE FaLeistungID = {0}
                                          AND (SichtbarSDFlag = {1} OR SichtbarSDFlag = 1)),
                           ZielDate2 = (SELECT MIN(FeinzielDat)
                                        FROM dbo.KaQEEPQZielvereinbVerl WITH (READUNCOMMITTED)
                                        WHERE FaLeistungID = {0}
                                          AND (SichtbarSDFlag = {1} OR SichtbarSDFlag = 1))", _faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));

                qryIntegBildung.Fill(@"
                    SELECT IBI.*,
                           Kurs       = KUE.KursNr + ISNULL(', ' + KUR.Name, ''),
                           KursDetail = KUE.KursNr +
                                        ISNULL(', ' + KUR.Name, '') +
                                        ISNULL(', ' + CONVERT(VARCHAR(15), KUE.DatumVon, 104), '') +
                                        ISNULL(' - ' + CONVERT(VARCHAR(15), KUE.DatumBis, 104), '')
                    FROM dbo.KaIntegBildung         IBI WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.KaKurserfassung KUE WITH (READUNCOMMITTED) ON KUE.KaKurserfassungID = IBI.KaKurserfassungID
                      LEFT JOIN dbo.KaKurs          KUR WITH (READUNCOMMITTED) ON KUR.KaKursID = KUE.KursID
                    WHERE IBI.BaPersonID = {0}
                      AND (IBI.SichtbarSDFlag = {1} OR IBI.SichtbarSDFlag = 1)
                    ORDER BY IBI.Austritt DESC;", _baPersonID, KaUtil.GetSichtbarSDFlag(_baPersonID));

                qryZielvereinb.Fill(@"
                    SELECT *
                    FROM dbo.KaQEEPQZielvereinb WITH (READUNCOMMITTED)
                    WHERE FaLeistungID = {0}
                      AND (SichtbarSDFlag = {1} OR SichtbarSDFlag = 1)
                    ORDER BY FeinzielDat DESC", _faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));

                qryZielvereinbVerl.Fill(@"
                    SELECT *
                    FROM dbo.KaQEEPQZielvereinbVerl WITH (READUNCOMMITTED)
                    WHERE FaLeistungID = {0}
                      AND (SichtbarSDFlag = {1} or SichtbarSDFlag = 1)
                    ORDER BY FeinzielDat DESC", _faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));

                SetEditMode();

                if (qryEPQ.CanUpdate && !DBUtil.IsEmpty(qryEPQ["IntakeCodes"]))
                {
                    chlIntakeCodes.EditValue = qryEPQ["IntakeCodes"].ToString();
                }
            }
            finally
            {
                // reset flag
                _isFillEpq = false;
            }

            // logging
            _logger.Debug("done");
        }

        private void SetDropDownGrund()
        {
            // logging
            _logger.Debug("enter");

            if (!DBUtil.IsEmpty(rgGrund.EditValue))
            {
                if (rgGrund.SelectedIndex == 0 || Convert.ToInt32(rgGrund.EditValue) == 1)
                {
                    ddlGrund.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                }
                else
                {
                    ddlGrund.EditMode = EditModeType.ReadOnly;
                }
            }

            // logging
            _logger.Debug("done");
        }

        private void SetEditMode()
        {
            // logging
            _logger.Debug("enter");

            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);
            qryEPQ.CanUpdate = _mayUpd && DBUtil.UserHasRight("CtlKaQEEPQ", "U");
            qryEPQ.CanInsert = false;
            qryEPQ.CanDelete = false;
            qryEPQ.EnableBoundFields();

            switch (tabControlEPQ.SelectedTabIndex)
            {
                case 0:
                    //tpgProzessuebersicht
                    _userUpd = DBUtil.UserHasRight("TabEPQProzessuebersicht", "U") && _mayUpd;
                    _userIns = false;
                    _userDel = false;

                    datStaoDatum.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docTaetigProg.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docPrzStandortBestimmung1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docPrzStandortBestimmung2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docPersonalblatt.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docZwischenbericht1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docZwischenbericht2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    chkVerlaengerung.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    datVerlaengerung.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docSchlussbericht1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docSchlussbericht2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docArbeitszeugnis.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docZwischenzeugnis.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

                    ActiveSQLQuery = qryEPQ;
                    break;

                case 1:
                    //tpgIntake
                    _userUpd = DBUtil.UserHasRight("TabEPQIntake", "U") && _mayUpd;
                    _userIns = false;
                    _userDel = false;

                    datEinladung1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    datEinladung2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docEinladung1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docEinladung2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    chlIntakeCodes.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    rgProgBeginn.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docIntakeVorstellungsgespraech.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docAntwortAnbieter.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docEinladungProgBeginn1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docEinladungProgBeginn2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    memBemerkungen.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

                    ActiveSQLQuery = qryEPQ;
                    break;

                case 2:
                    //tpgZielVereinbarung
                    _userUpd = DBUtil.UserHasRight("TabEPQZielVereinb", "U") && _mayUpd;
                    _userIns = DBUtil.UserHasRight("TabEPQZielVereinb", "I") && _mayIns;
                    _userDel = DBUtil.UserHasRight("TabEPQZielVereinb", "D") && _mayDel;

                    qryZielvereinb.CanUpdate = _userUpd;
                    qryZielvereinb.CanInsert = _userIns;
                    qryZielvereinb.CanDelete = _userDel;

                    qryZielvereinb.EnableBoundFields();

                    memIndivZieleRAV.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docIndivZieleRAV.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

                    ActiveSQLQuery = qryZielvereinb;
                    break;

                case 3:
                    //tpgZielVereinbarungVerl
                    _userUpd = DBUtil.UserHasRight("TabEPQZielVereinbVerl", "U") && _mayUpd;
                    _userIns = DBUtil.UserHasRight("TabEPQZielVereinbVerl", "I") && _mayIns;
                    _userDel = DBUtil.UserHasRight("TabEPQZielVereinbVerl", "D") && _mayDel;

                    qryZielvereinbVerl.CanUpdate = _userUpd;
                    qryZielvereinbVerl.CanInsert = _userIns;
                    qryZielvereinbVerl.CanDelete = _userDel;

                    qryZielvereinbVerl.EnableBoundFields();

                    memIndivZieleRAVVerl.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docIndivZieleRAVVerl.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

                    ActiveSQLQuery = qryZielvereinbVerl;
                    break;

                case 4:
                    //tpgInterventionen
                    _userUpd = DBUtil.UserHasRight("TabEPQInterventionen", "U") && _mayUpd;
                    _userIns = false;
                    _userDel = false;

                    datMuendAufford1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    datMuendAufford2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    memMuendAufford1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    memMuendAufford2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docAufforderung1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docAufforderung2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docAufforderung3.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docVereinbarung1.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docVereinbarung2.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docVerwRegelverstoss.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docVerwNichterscheinen.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    docProgAbbruch.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

                    ActiveSQLQuery = qryEPQ;
                    break;

                case 5:
                    //tabControlEPQ
                    _userUpd = DBUtil.UserHasRight("TabEPQAustritt", "U") && _mayUpd;
                    _userIns = false;
                    _userDel = false;

                    datAustrittDatum.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    rgGrund.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    ddlGrund.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
                    btnReset.Enabled = _userUpd;
                    memAustrittBem.EditMode = _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

                    SetDropDownGrund();

                    ActiveSQLQuery = qryEPQ;
                    break;

                default:
                    ActiveSQLQuery = qryEPQ;
                    break;
            }

            // logging
            _logger.Debug("done");
        }

        #endregion

        private void qryEPQ_AfterPost(object sender, EventArgs e)
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

        #endregion
    }
}