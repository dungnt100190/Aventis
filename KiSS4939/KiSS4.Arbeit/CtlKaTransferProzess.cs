using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaTransfer.
    /// </summary>
    public partial class CtlKaTransferProzess : KissUserControl
    {
        private const string CLASSNAME = "CtlKaTransferProzess";

        private int _baPersonID;
        private int _faLeistungID;
        private bool _isFillTransfer;
        private bool _isUserEligibleForTransfer;
        private bool _mayClose;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpd;
        private bool _userUpdAustritt;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlKaTransferProzess"/> class.
        /// </summary>
        public CtlKaTransferProzess()
        {
            InitializeComponent();
        }

        public override object GetContextValue(string fieldName)
        {
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

        public void Init(string titleName, Image titleImage, int faLeistungId, int baPersonId)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungId;
            _baPersonID = baPersonId;
            SetFormAuthorisation();
            // create row in KaTransfer if there is no entry.
            if (!TransferExists() && _isUserEligibleForTransfer && _mayUpd)
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.KaTransfer (FaLeistungID, SichtbarSDFlag, Creator, Created, Modifier, Modified)
                    VALUES ({0}, {1}, {2}, {3}, {2}, {3});", _faLeistungID, KaUtil.IsVisibleSD(_baPersonID), Session.User.UserID, DateTime.Now);
            }

            FillDataQueries(true);
            SetAustrittEditmode();

            tabControl.SelectTab(tpgProzessuebersicht);
        }

        public override bool OnSaveData()
        {
            ActiveSQLQuery.EndCurrentEdit();
            qryTransfer.EndCurrentEdit();

            // check if need to save changes and reload data (performance booster when closing control)
            if ((!qryTransfer.RowModified && (qryTransfer.Row == null || qryTransfer.Row.RowState == System.Data.DataRowState.Unchanged)) &&
                (!qryZielvereinb.RowModified && (qryZielvereinb.Row == null || qryZielvereinb.Row.RowState == System.Data.DataRowState.Unchanged)))
            {
                // nothing to save
                return true;
            }

            bool ret1 = qryTransfer.Post();
            bool ret2 = qryZielvereinb.Post();
            bool result = ret1 && ret2;

            if (result)
            {
                // reload data
                FillDataQueries(false);
            }

            // done
            return result;
        }

        private void btnPraesenzzeit_Click(object sender, EventArgs e)
        {
            ((KissMainForm)Session.MainForm).OpenChildForm(typeof(FrmKaPraesenzzeit));
            var frmPraesenz = (FrmKaPraesenzzeit)((KissMainForm)Session.MainForm).GetChildForm(typeof(FrmKaPraesenzzeit));
            frmPraesenz.SetKlientX(_baPersonID);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion(CLASSNAME, "WerteZuruecksetzen", "Folgende Werte zurücksetzen:\r\nDatum, Austrittsgrund (inkl. Auswahl)?"))
            {
                edtAustrittDatum.EditValue = null;
                edtAustrittsgrund.EditValue = null;
                edtAustrittsgrund.EditMode = EditModeType.Normal;
                edtAustrittCode.EditValue = null;

                edtAustrittCode.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaTransferProzess_Load(object sender, EventArgs e)
        {
            qryVerlauf.Last();
        }

        private void edtAustrittDatum_EditValueChanged(object sender, EventArgs e)
        {
            SetAustrittEditmode();
        }

        private void edtAustrittsgrund_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (_isFillTransfer || qryTransfer.IsFilling || DBUtil.IsEmpty(e.NewValue))
            {
                return;
            }

            if (Convert.ToInt32(e.NewValue) == 1)
            {
                edtAustrittCode.EditMode = _userUpdAustritt ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                if (DBUtil.IsEmpty(edtAustrittCode.EditValue))
                {
                    edtAustrittCode.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    if (KissMsg.ShowQuestion(CLASSNAME, "WertAustrittsgrundLoeschen", "Wert in Auswahl Austrittsgrund löschen?"))
                    {
                        // delete entry
                        edtAustrittCode.EditValue = null;
                        edtAustrittCode.EditMode = EditModeType.ReadOnly;
                    }
                    else
                    {
                        edtAustrittsgrund.SelectedIndex = Convert.ToInt32(e.OldValue) - 1;
                        edtAustrittCode.EditMode = EditModeType.Required;
                        edtAustrittDatum.EditMode = EditModeType.Required;
                        e.Cancel = true;
                    }
                }
            }
        }

        private void edtAustrittsgrund_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update dropdown
            SetAustrittEditmode();
        }

        /// <summary>
        /// Fill sql queries
        /// </summary>
        /// <param name="isFirstRefresh">Is first refresh of the queries, performance optimization, when form is alreay loaded in the memory</param>
        private void FillDataQueries(bool isFirstRefresh)
        {
            try
            {
                // set flag
                _isFillTransfer = true;

                qryTransfer.Fill(_faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));
                qryZielvereinb.Fill(_faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));
                if (isFirstRefresh)
                {
                    qryAnweisung.Fill(_faLeistungID, _baPersonID, KaUtil.GetSichtbarSDFlag(_baPersonID));
                    qryVerlauf.Fill(_baPersonID, KaUtil.GetSichtbarSDFlag(_baPersonID));
                    qryDates.Fill(_faLeistungID, KaUtil.GetSichtbarSDFlag(_baPersonID));
                    qryIntegBildung.Fill(_baPersonID, KaUtil.GetSichtbarSDFlag(_baPersonID));
                }

                SetActiveQuery();
            }
            finally
            {
                // reset flag
                _isFillTransfer = false;
            }
        }

        private void qryTransfer_AfterPost(object sender, EventArgs e)
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

        private void qryTransfer_BeforePost(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtAustrittDatum.EditValue))
            {
                DBUtil.CheckNotNullField(edtAustrittsgrund, lblAustrittsgrund.Text);
            }

            if (!DBUtil.IsEmpty(edtAustrittsgrund.EditValue))
            {
                DBUtil.CheckNotNullField(edtAustrittDatum, lblAustrittDatum.Text);
            }

            if (edtAustrittsgrund.SelectedIndex == 0)
            {
                DBUtil.CheckNotNullField(edtAustrittCode, "Auswahl Austrittsgrund");
            }

            var austrittsdatum = qryTransfer["AustrittDat"] as DateTime?;
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
                        CLASSNAME,
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
                    KissMsg.GetMLMessage(CLASSNAME, "ErrorDatumNichtInnerhalbZeiterfassung_V2", "Das Austrittsdatum liegt nicht innerhalb einer Anweisung."));
            }

            Session.BeginTransaction();
        }

        private void qryZielvereinb_AfterInsert(object sender, EventArgs e)
        {
            qryZielvereinb["FaLeistungID"] = _faLeistungID;
            qryZielvereinb["SichtbarSDFlag"] = KaUtil.IsVisibleSD(_baPersonID);
        }

        private void qryZielvereinb_AfterPost(object sender, EventArgs e)
        {
            qryDates.Refresh();
        }

        private void SetActiveQuery()
        {
            switch (tabControl.SelectedTabIndex)
            {
                case 0:
                case 2:
                    ActiveSQLQuery = qryTransfer;
                    break;

                case 1:
                    ActiveSQLQuery = qryZielvereinb;
                    break;

                case 3:
                    SetAustrittEditmode();
                    ActiveSQLQuery = qryTransfer;
                    break;

                default:
                    ActiveSQLQuery = qryTransfer;
                    break;
            }
        }

        private void SetAustrittEditmode()
        {
            if (!_userUpdAustritt)
            {
                edtAustrittsgrund.EditMode = EditModeType.ReadOnly;
                edtAustrittDatum.EditMode = EditModeType.ReadOnly;
                edtAustrittCode.EditMode = EditModeType.ReadOnly;
                return;
            }

            if (!DBUtil.IsEmpty(edtAustrittsgrund.EditValue) || !DBUtil.IsEmpty(edtAustrittDatum.EditValue))
            {
                if (edtAustrittsgrund.SelectedIndex == 0 || (!DBUtil.IsEmpty(edtAustrittsgrund.EditValue) && Convert.ToInt32(edtAustrittsgrund.EditValue) == 1))
                {
                    edtAustrittCode.EditMode = EditModeType.Required;
                }
                else
                {
                    edtAustrittCode.EditMode = EditModeType.ReadOnly;
                }

                edtAustrittsgrund.EditMode = EditModeType.Required;
                edtAustrittDatum.EditMode = EditModeType.Required;
            }
            else
            {
                edtAustrittDatum.EditMode = EditModeType.Normal;
            }
        }

        private void SetFormAuthorisation()
        {
            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);
            _isUserEligibleForTransfer = DBUtil.UserHasRight(CLASSNAME);

            qryTransfer.CanUpdate = _mayUpd && DBUtil.UserHasRight(CLASSNAME, "U");
            qryTransfer.CanInsert = false;
            qryTransfer.CanDelete = false;
            qryTransfer.EnableBoundFields();

            //tpgProzessuebersicht
            var userUpd = DBUtil.UserHasRight("CtlKaTransferProzess_Prozessuebersicht", "U") && _mayUpd;

            edtStaoDatum.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docSituationserfassungVG.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docEntwicklungsverlauf.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docPersonalblatt.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docFaehigkeitsprofil.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docArbeitsproben.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docSchlussbericht.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docTeilnahmebestaetigung.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

            //tpgZielVereinbarung
            userUpd = DBUtil.UserHasRight("CtlKaTransferProzess_ZielVereinb", "U") && _mayUpd;
            var userIns = DBUtil.UserHasRight("CtlKaTransferProzess_ZielVereinb", "I") && _mayIns;
            var userDel = DBUtil.UserHasRight("CtlKaTransferProzess_ZielVereinb", "D") && _mayDel;
            qryZielvereinb.CanUpdate = userUpd;
            qryZielvereinb.CanInsert = userIns;
            qryZielvereinb.CanDelete = userDel;
            qryZielvereinb.EnableBoundFields();
            edtAllgZiele.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docAllgZiele.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

            //tpgInterventionen
            userUpd = DBUtil.UserHasRight("CtlKaTransferProzess_Interventionen", "U") && _mayUpd;
            edtMuendAufforderungDat1.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMuendAufforderungDat2.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMuendAufforderungBem1.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMuendAufforderungBem2.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docAufforderung1.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docAufforderung2.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docAufforderung3.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docVereinbarung1.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docVereinbarung2.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docVerwRegelverstoss.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docVerwNichterscheinen.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            docProgrammabbruch.EditMode = userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

            //tabControl
            _userUpdAustritt = DBUtil.UserHasRight("CtlKaTransferProzess_Austritt", "U") && _mayUpd;
            edtAustrittDatum.EditMode = _userUpdAustritt ? EditModeType.Normal : EditModeType.ReadOnly;
            edtAustrittsgrund.EditMode = _userUpdAustritt ? EditModeType.Normal : EditModeType.ReadOnly;
            edtAustrittCode.EditMode = EditModeType.ReadOnly;
            btnReset.Enabled = _userUpdAustritt;
            edtAustrittBem.EditMode = _userUpdAustritt ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void tabControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            SetActiveQuery();
        }

        private bool TransferExists()
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.KaTransfer
                WHERE FaLeistungID = {0};", _faLeistungID)) > 0;
        }
    }
}