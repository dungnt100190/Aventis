using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;

namespace KiSS4.Fallfuehrung.PI
{
    internal partial class CtlFaBeratungsperiode : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _baPersonID;
        private DateTime? _datumBisLeistung;
        private int _faLeistungID = -1;
        private bool _hasMaChanged;
        private int _modulID = -1;
        private string _title = "";

        #endregion

        #endregion

        #region Constructors

        public CtlFaBeratungsperiode()
        {
            InitializeComponent();

            // disable button reopen
            btnReOpen.Enabled = false;

            // set popup with for Abschlussgrund
            edtAbschlussGrund.Properties.PopupWidth = edtAbschlussGrund.Width + 80;

            // init with default values
            Init(null, null, -1, -1);
        }

        #endregion

        #region EventHandlers

        private void btnReOpen_Click(object sender, EventArgs e)
        {
            // check if reopen is really possible
            if (_modulID != 2 || qryFaLeistung.Count < 1 || DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                // reopen is not possible, disable button
                btnReOpen.Enabled = false;
                return;
            }

            // confirm reopen
            if (!KissMsg.ShowQuestion(Name, "ConfirmReopenFV", "Soll der geschlossene Fallverlauf wirklich wieder geöffnet werden?", false))
            {
                // user canceled
                return;
            }

            // do reopen
            qryFaLeistung.CanUpdate = true;
            ResetCloseProcess();

            // save changes
            if (qryFaLeistung.Post())
            {
                // setup mode and rights
                SetEditMode();
            }
        }

        private void CtlFaBeratungsperiode_Load(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void edtDatumBis_EditValueChanged(object sender, EventArgs e)
        {
            // check if we have a value
            bool hasDatumBis = !DBUtil.IsEmpty(edtDatumBis.EditValue);

            // depending on value/empty setup edtAbschlussGrund
            edtAbschlussGrund.EditMode = hasDatumBis && qryFaLeistung.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;

            // check if we need to reset
            if (!hasDatumBis && qryFaLeistung.CanUpdate && !DBUtil.IsEmpty(edtAbschlussGrund.EditValue))
            {
                // logging
                _logger.Debug("reset: edtAbschlussGrund.EditValue");

                // reset any value
                edtAbschlussGrund.EditValue = null;
            }
        }

        private void edtMitarbeiter_EditValueChanged(object sender, EventArgs e)
        {
            // data has changed
            _hasMaChanged = true;
        }

        private void edtMitarbeiter_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogAutor(e);
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            try
            {
                // historize the Situationsbeschreibung if the Fallverlauf has been closed
                if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) && DBUtil.IsEmpty(_datumBisLeistung))
                {
                    FaUtils.HistorizeSituationsbeschreibung(_baPersonID);
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();

                KissMsg.ShowError(Name, "ErrorSavingData", "Es ist ein Fehler beim Speichern der Daten aufgetreten.", ex);

                throw new KissCancelException();
            }
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            // finish edit
            qryFaLeistung.EndCurrentEdit();

            // validate FaLeistungID
            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.FaLeistungID]))
            {
                // no valid modulid, cancel
                KissMsg.ShowError(
                    Name,
                    "NoValidFaLeistungIDInBeforePost_v01",
                    "Die aktuelle Dienstleistung ist ungültig und kann daher nicht gespeichert werden (FaLeistungID).");

                // cancel changes
                throw new KissCancelException();
            }

            // validate BaPersonID
            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.BaPersonID]))
            {
                // no valid modulid, cancel
                KissMsg.ShowError(
                    Name,
                    "NoValidBaPersonIDInBeforePost_v01",
                    "Die aktuelle Dienstleistung ist keiner Person zugewiesen und kann daher nicht gespeichert werden.");

                // cancel changes
                throw new KissCancelException();
            }

            // validate ModulID
            List<int> validModulIDs = new List<int>            {
                Convert.ToInt32(BaUtils.ModulID.Fallverlauf),
                Convert.ToInt32(BaUtils.ModulID.SozialBeratung),
                Convert.ToInt32(BaUtils.ModulID.CaseManagement),
                Convert.ToInt32(BaUtils.ModulID.BegleitetesWohnen),
                Convert.ToInt32(BaUtils.ModulID.EntlastungsDienst),
                Convert.ToInt32(BaUtils.ModulID.Assistenzberatung),
                Convert.ToInt32(BaUtils.ModulID.WeitereDL),
            };

            if (!validModulIDs.Contains(_modulID))
            {
                // show message
                KissMsg.ShowError(
                    Name,
                    "InvalidModulIDOnPost",
                    "Es ist ein Ausnahmefehler beim Speichern aufgetreten. Die verwendete ModulID ist ungültig und kann nicht verwendet werden.");

                // cancel
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.ModulID]))
            {
                // no valid modulid, cancel
                KissMsg.ShowError(
                    Name,
                    "NoValidModulIDInBeforePost_v01",
                    "Die aktuelle Dienstleistung ist keinem Modul zugewiesen und kann daher nicht gespeichert werden.");

                throw new KissCancelException();
            }

            // validate duplicate wD

            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.FaModulDienstleistungenCode]) &&
                FaUtils.CheckDuplicateWdExists(Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.BaPersonID]), (int)qryFaLeistung[DBO.FaLeistung.FaModulDienstleistungenCode], (int)qryFaLeistung[DBO.FaLeistung.FaLeistungID]))
            {
                // DuplicateWdExists, cancel
                KissMsg.ShowInfo(
                    Name,
                    "DuplicateWdExists_v01",
                    "Es gibt bereits eine aktive weitere Dienstleistung von diesem Typ, daher kann nicht gespeichert werden.");
                throw new KissCancelException();
            }

            // validate must fields
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtMitarbeiter, lblMitarbeiter.Text);
            if (edtDienstleistung.Visible)
            {
                DBUtil.CheckNotNullField(edtDienstleistung, lblDienstleistung.Text);
            }

            // validate buttonedits
            if (_hasMaChanged && !DialogAutor(new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Autor
                edtMitarbeiter.Focus();
                throw new KissCancelException();
            }

            // reset flags
            _hasMaChanged = false;

            // #7827: DateTime without time
            qryFaLeistung[DBO.FaLeistung.DatumVon] = FaUtils.DateTimeWithoutTime(qryFaLeistung, DBO.FaLeistung.DatumVon);
            qryFaLeistung[DBO.FaLeistung.DatumBis] = FaUtils.DateTimeWithoutTime(qryFaLeistung, DBO.FaLeistung.DatumBis);

            // init vars
            int currentBaPersonID = Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.BaPersonID]);
            DateTime currentDatumVon = Convert.ToDateTime(qryFaLeistung[DBO.FaLeistung.DatumVon]);

            // DATUMVON:
            // validate DatumVon only if modified
            if (qryFaLeistung.ColumnModified(DBO.FaLeistung.DatumVon))
            {
                // check if DatumVon is before FV.DatumVon (only if not FV-entry)
                bool doCheckisDateInOtherProcess = (_modulID != Convert.ToInt32(BaUtils.ModulID.WeitereDL));
                if (!FaUtils.IsProcessDateValid(_modulID, _faLeistungID, true, currentDatumVon, DateTime.MinValue, doCheckisDateInOtherProcess))
                {
                    // DatumVon is invalid
                    edtDatumVon.Focus();

                    // do not continue with save (message alreday shown)
                    throw new KissCancelException();
                }

                // check if FV-DatumVon is after start of first process
                if (_modulID == Convert.ToInt32(BaUtils.ModulID.Fallverlauf) &&
                    !FaUtils.IsFVDateBeforeAfterProcesses(_faLeistungID, currentBaPersonID, true, currentDatumVon))
                {
                    // FVDatumVon is after Process-DatumVon
                    edtDatumVon.Focus();

                    // do not continue with save (message alreday shown)
                    throw new KissCancelException();
                }
            }

            // DATUMBIS:
            // validate DatumBis
            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]))
            {
                // GET NAME:
                // get name of the fallverlauf/service
                string name = "?";

                try
                {
                    // get the name of the FallVerlauf in ModulTree
                    name = ((KissModulTree)FormController.GetMessage("FrmFall", false, "Action", "CurrentModulTree")).FocusedNode.GetDisplayText("Name");
                }
                catch (Exception ex)
                {
                    XLog.Create(GetType().FullName, LogLevel.ERROR, "Get the name of the FallVerlauf in ModulTree", ex.Message);
                }

                // CHECK CLOSE-MUSTFIELDS:
                // check if we have to fill edtAbschlussGrund >> depending on modul-id
                if (_modulID != Convert.ToInt32(BaUtils.ModulID.Fallverlauf))
                {
                    // on ever other case than FV, we have to fill AbschlussGrund
                    DBUtil.CheckNotNullField(edtAbschlussGrund, lblAbschlussGrund.Text);
                }

                // VALIDATE closing modules

                #region Validate closing SB/CM

                // sb/cm can only be closed if some conditions are valid
                if ((_modulID == Convert.ToInt32(BaUtils.ModulID.SozialBeratung) ||
                     _modulID == Convert.ToInt32(BaUtils.ModulID.CaseManagement)) &&
                    !FaUtils.CheckCanSBCMBeClosed(Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.FaLeistungID])))
                {
                    KissMsg.ShowInfo(
                        Name,
                        "SBOrCMCannotBeClosedByRule_v02",
                        "Der '{0}' Prozess kann nicht abgeschlossen werden.{1}{1}Es müssen mindestens ein Rahmenziel definiert und alle Ziele evaluiert sein.",
                        0,
                        0,
                        name,
                        Environment.NewLine);

                    ResetCloseProcess();

                    edtDatumBis.Focus();

                    throw new KissCancelException();
                }

                #endregion

                #region Validate closing BW

                // bw can only be closed if some conditions are valid
                if (_modulID == Convert.ToInt32(BaUtils.ModulID.BegleitetesWohnen) &&
                    FaUtils.CheckCanBWBeClosed(Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.FaLeistungID]), true, name) != FaUtils.ClosingBWState.Ok)
                {
                    ResetCloseProcess();

                    edtDatumBis.Focus();

                    throw new KissCancelException();
                }

                #endregion

                #region Validate closing ED

                // bw can only be closed if some conditions are valid
                if (_modulID == Convert.ToInt32(BaUtils.ModulID.EntlastungsDienst) &&
                    FaUtils.CheckCanEDBeClosed(Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.FaLeistungID]), true, name) != FaUtils.ClosingEDState.Ok)
                {
                    ResetCloseProcess();

                    edtDatumBis.Focus();

                    throw new KissCancelException();
                }

                #endregion

                // VALIDAT DATE:
                // init var
                var currentDatumBis = Convert.ToDateTime(qryFaLeistung[DBO.FaLeistung.DatumBis]);

                // validate date ranges
                if (currentDatumVon > currentDatumBis)
                {
                    // invalid range, set focus and show message
                    edtDatumBis.Focus();
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            Name, "InvalidDateOrder_v01", "Das Abschlussdatum ist ungültig - es darf nicht kleiner als das Eröffnungsdatum sein."),
                        edtDatumBis);
                }

                // check if DatumBis is after FV.DatumBis or DatumBis does cross any other same items
                bool doCheckisDateInOtherProcess = (_modulID != Convert.ToInt32(BaUtils.ModulID.WeitereDL));
                if (!FaUtils.IsProcessDateValid(_modulID, _faLeistungID, false, currentDatumVon, currentDatumBis, doCheckisDateInOtherProcess))
                {
                    // DatumBis is after FVDatumBis
                    edtDatumBis.Focus();

                    // do not continue with save (message alreday shown)
                    throw new KissCancelException();
                }

                // VALIDATE FALLVERLAUF - DATUMBIS
                if (_modulID == 2)
                {
                    // check if FV-DatumBis is before end of last process
                    if (!FaUtils.IsFVDateBeforeAfterProcesses(_faLeistungID, currentBaPersonID, false, currentDatumBis))
                    {
                        // FVDatumBis is before Process-DatumBis
                        edtDatumBis.Focus();

                        // do not continue with save (message alreday shown)
                        throw new KissCancelException();
                    }
                }

                // CONFIRM CLOSE
                bool doCloseAction;

                // depending on modulid, we show different question
                switch (_modulID)
                {
                    case 2: // Fallverlauf
                        doCloseAction = KissMsg.ShowQuestion(
                            Name,
                            "ConfirmCloseFallverlauf",
                            "Wollen Sie den Fallverlauf wirklich per '{0}' schliessen?",
                            0,
                            0,
                            false,
                            currentDatumBis.ToString("dd.MM.yyyy"));
                        break;

                    default: // others
                        doCloseAction = KissMsg.ShowQuestion(
                            Name,
                            "ConfirmCloseOtherService",
                            "Wollen Sie '{0}' wirklich per '{1}' schliessen?",
                            0,
                            0,
                            false,
                            name,
                            currentDatumBis.ToString("dd.MM.yyyy"));
                        break;
                }

                // if user did not confirm closing, we do cancel
                if (!doCloseAction)
                {
                    // reset current value and set focus
                    ResetCloseProcess();

                    edtDatumBis.Focus();

                    throw new KissCancelException();
                }
            }

            _datumBisLeistung = qryFaLeistung[DBO.FaLeistung.DatumBis, DataRowVersion.Original] as DateTime?;

            Session.BeginTransaction();
        }

        private void qryFaLeistung_PostCompleted(object sender, EventArgs e)
        {
            // refresh tree
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            SetEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            _title = titleName;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
            _modulID = -1; // do reset

            // validate
            if (faLeistungID < 1 || baPersonID < 1)
            {
                // logging
                _logger.Debug("cancel: faLeistungID < 1 || baPersonID < 1");

                // lock update
                qryFaLeistung.CanUpdate = false;

                // lock special items
                ShowHideControls(false, false);

                // handle editmode of controls
                qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate);
                return;
            }

            // get data
            qryFaLeistung.Fill(@"
                SELECT LEI.*,
                        Mitarbeiter        = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
                        Abteilung          = dbo.fnOrgUnitOfUser(LEI.UserID, 0),
                        FaLeistungArchivID = ARC.FaLeistungArchivID
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                    INNER JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
                    LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                                                                ARC.CheckOut IS NULL
                WHERE LEI.FaLeistungID = {0};",
                _faLeistungID);

            // get modul-id if any data-entry was found
            if (qryFaLeistung.Count > 0 && !DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.ModulID]))
            {
                // get modul-id
                _modulID = Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.ModulID]);
            }

            // setup mode and rights
            SetEditMode();

            // reset flags
            _hasMaChanged = false;

            // Dienstleistung is required
            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.FaModulDienstleistungenCode]) && DBUtil.IsEmpty(edtDienstleistung.EditValue))
            {
                //only 1 item in a mandatory field --> set value directly
                var queryDienstleistung = ((SqlQuery)edtDienstleistung.Properties.DataSource);

                if (queryDienstleistung.Count == 1)
                {
                    qryFaLeistung[DBO.FaLeistung.FaModulDienstleistungenCode] = queryDienstleistung["Code"];
                }
                else if (qryFaLeistung.CanUpdate)
                {
                    qryFaLeistung.RowModified = true;
                }
            }
        }

        public override void OnRefreshData()
        {
            base.OnRefreshData();

            SetEditMode();
        }

        public override void Translate()
        {
            base.Translate();

            // setup title
            lblTitel.Text = _title;
        }

        #endregion

        #region Private Methods

        private bool DialogAutor(UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (edtMitarbeiter.EditMode == EditModeType.ReadOnly || !qryFaLeistung.CanUpdate)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edtMitarbeiter.EditValue))
                {
                    // prepare for database search
                    searchString = edtMitarbeiter.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // reset fields
                        qryFaLeistung[DBO.FaLeistung.UserID] = DBNull.Value;
                        qryFaLeistung["Mitarbeiter"] = DBNull.Value;
                        qryFaLeistung["Abteilung"] = DBNull.Value;

                        // cancel
                        return true;
                    }
                }

                // Mitarbeiter_Suchen()
                using (var dlg = new KissLookupDialog())
                {
                    e.Cancel = !dlg.SearchData(
                        string.Format(@"
                            SELECT USR.*
                            FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                            WHERE USR.Name LIKE '{1}%';",
                            Session.User.UserID,
                            searchString),
                        searchString,
                        e.ButtonClicked,
                        null,
                        null,
                        null);

                    if (!e.Cancel)
                    {
                        // apply new value
                        qryFaLeistung[DBO.FaLeistung.UserID] = dlg["UserID$"];
                        qryFaLeistung["Mitarbeiter"] = dlg["Name"];
                        qryFaLeistung["Abteilung"] = dlg["Abteilung"];

                        // reset flag
                        _hasMaChanged = false;

                        // success
                        return true;
                    }
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorDialogAutor", "Es ist ein Fehler bei der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private void ResetCloseProcess()
        {
            qryFaLeistung[DBO.FaLeistung.DatumBis] = DBNull.Value;
            qryFaLeistung[DBO.FaLeistung.AbschlussGrundCode] = DBNull.Value;
        }

        private void SetEditMode()
        {
            // validate
            if (qryFaLeistung.Count < 1 || _modulID < 2)
            {
                // logging
                _logger.Debug("no data or invalid modulid < 2");

                // lock query and all fields
                qryFaLeistung.CanInsert = false;
                qryFaLeistung.CanUpdate = false;
                qryFaLeistung.CanDelete = false;

                // update fields depending on CanUpdate
                qryFaLeistung.EnableBoundFields();

                return;
            }

            // init vars
            bool mayRead;
            bool mayIns;
            bool mayUpd;
            bool mayDel;
            bool mayClose;
            bool mayReOpen;

            // get values
            DBUtil.GetFallRights(
                Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.FaLeistungID]),
                out mayRead,
                out mayIns,
                out mayUpd,
                out mayDel,
                out mayClose,
                out mayReOpen);

            // user can close leistung if not yet done
            bool isOpen = DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]);

            // setup depending on rights
            if (mayClose)
            {
                // set update-mode
                qryFaLeistung.CanUpdate = isOpen;
            }
            else
            {
                // user cannot modify item
                qryFaLeistung.CanUpdate = false;
            }

            // handle special-controls
            ShowHideControls(isOpen, mayReOpen);

            // MA-FIELD:
            // setup MA-Field depending on module, set editmode to readonly if FV, otherwise leave it as it is
            edtMitarbeiter.EditMode = _modulID == 2 ? EditModeType.ReadOnly : edtMitarbeiter.EditMode;

            // REFRESH FIELDS:
            // update fields depending on CanUpdate
            qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate);
        }

        private void ShowHideControls(Boolean isOpen, Boolean mayReOpen)
        {
            // >> depending on module-id show or hide some controls
            edtDienstleistung.Visible = _modulID == Convert.ToInt32(BaUtils.ModulID.WeitereDL);
            lblDienstleistung.Visible = _modulID == Convert.ToInt32(BaUtils.ModulID.WeitereDL);

            // init vars
            bool isCloseDateWithinTimeLimit = false;

            // check if we have a close-date (only important for FV: ModulID=2)
            if (_modulID == 2 && qryFaLeistung.Count > 0 && !DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]))
            {
                // get close-date
                DateTime closeDate = Convert.ToDateTime(qryFaLeistung[DBO.FaLeistung.DatumBis]);

                // we are in FV and have to check if we are within time-limit of 3 months
                isCloseDateWithinTimeLimit = DateTime.Compare(DateTime.Today.AddMonths(-3), closeDate) <= 0; // if (now-3m) > closeDate >> locked
            }

            // set flags
            bool canUseAbschlussGrund = _modulID > 1 && _modulID != 2;
            bool canReOpenCase = !isOpen && ((mayReOpen && isCloseDateWithinTimeLimit) || Session.User.IsUserAdmin);
            // case has to be FV, closed, can be reopened and was closed within 3 months (or user is admin: can reopen any closed FV case)

            // setup controls depending on flags
            panAbschlussGrund.Visible = canUseAbschlussGrund;
            lblBemerkungen.Top = canUseAbschlussGrund ? panAbschlussGrund.Top + panAbschlussGrund.Height + 6 : panAbschlussGrund.Top;
            memBemerkungen.Top = lblBemerkungen.Top;

            btnReOpen.Top = memBemerkungen.Top + memBemerkungen.Height + 6;
            btnReOpen.Visible = _modulID == 2;
            btnReOpen.Enabled = canReOpenCase;
        }

        #endregion

        #endregion
    }
}