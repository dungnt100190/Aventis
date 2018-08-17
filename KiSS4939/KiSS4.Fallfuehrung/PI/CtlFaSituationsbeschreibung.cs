using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    public partial class CtlFaSituationsbeschreibung : KissUserControl
    {
        private int _baPersonID = -1;

        public CtlFaSituationsbeschreibung()
        {
            InitializeComponent();

            Init(null, null, -1);
        }

        private enum Navigation
        {
            Previous,
            Next,
            None
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FASITUATIONSBESCHREIBUNGID":
                    if (qryFaSituationsbeschreibung.Count < 1)
                    {
                        return -1;
                    }

                    return qryFaSituationsbeschreibung["FaSituationsbeschreibungID"];

                case "BAPERSONID":
                    return _baPersonID;
            }

            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Default call --> used from modultree
        /// </summary>
        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            Init(titleName, titleImage, baPersonID, false, -1);
        }

        /// <summary>
        /// Advanced call for history version
        /// </summary>
        public void Init(string titleName, Image titleImage, int baPersonID, bool useHistory, int histFaSituationsbeschreibungID)
        {
            if (baPersonID < 1)
            {
                // do not continue
                qryFaSituationsbeschreibung.CanUpdate = false;

                // handle editmode of controls
                qryFaSituationsbeschreibung.EnableBoundFields(qryFaSituationsbeschreibung.CanUpdate);
                return;
            }

            // allow updates
            qryFaSituationsbeschreibung.CanUpdate = !useHistory;

            // apply values
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            // fill source (other data if history)
            if (!useHistory)
            {
                // default mode
                qryFaSituationsbeschreibung.Fill(FaUtils.QRY_SITUATIONSBESCHREIBUNG, baPersonID);
            }
            else
            {
                // history version
                qryFaSituationsbeschreibung.Fill(
                    @"
                        SELECT *
                        FROM dbo.Hist_FaSituationsbeschreibung WITH (READUNCOMMITTED)
                        WHERE BaPersonID = {0} AND
                              Hist_FaSituationsbeschreibungID = {1}",
                    baPersonID,
                    histFaSituationsbeschreibungID);
            }

            // insert new entry if not yet any entry found
            if (!useHistory && qryFaSituationsbeschreibung.Count == 0)
            {
                qryFaSituationsbeschreibung.Insert(null);
            }

            // show/hide buttons
            btnHistorisieren.Visible = !useHistory;
            btnVerlaufAnzeigen.Visible = !useHistory;
            docBericht.Visible = !useHistory;

            // arrange fields depending on history
            if (useHistory)
            {
                // get space between label and field
                int spaceLetzteAenderung = edtLetzteAenderung.Left - lblLetzteAenderung.Left - lblLetzteAenderung.Width;

                // arrange 'Letze Aenderung'
                edtLetzteAenderung.Left = (btnVerlaufAnzeigen.Left + btnVerlaufAnzeigen.Width) - edtLetzteAenderung.Width;
                lblLetzteAenderung.Left = edtLetzteAenderung.Left - spaceLetzteAenderung - lblLetzteAenderung.Width;
            }

            // update icons
            tabSituationsbeschreibung.ShowIconUpdate();
        }

        private void btnHistorisieren_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor = Cursors.WaitCursor;

            try
            {
                if (!CanUseHistory())
                {
                    KissMsg.ShowInfo("CtlFaSituationsbeschreibung", "CannotCreateNewHistory", "Die aktuellen Daten können nicht historisiert werden.");
                    return;
                }

                // confirm
                if (KissMsg.ShowQuestion(
                    "CtlFaSituationsbeschreibung", "ConfirmCreateNewHistory", "Wollen Sie den aktuellen Zustand nun historisieren?"))
                {
                    // yes --> create new history version
                    FaUtils.HistorizeSituationsbeschreibung(Convert.ToInt32(qryFaSituationsbeschreibung["BaPersonID"]));
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    "CtlFaSituationsbeschreibung",
                    "ErrorCreatingHistoryVersion_v01",
                    "Es ist ein Fehler beim Erstellen der historisierten Version aufgetreten.",
                    ex);
            }
            finally
            {
                // set focus
                tabSituationsbeschreibung.Focus();

                Cursor = currentCursor;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HandlePreviousNext(Navigation.Next);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            HandlePreviousNext(Navigation.Previous);
        }

        private void btnVerlaufAnzeigen_Click(object sender, EventArgs e)
        {
            if (!CanUseHistory())
            {
                KissMsg.ShowInfo("CtlFaSituationsbeschreibung", "CannotShowHistory", "Zu den aktuellen Daten kann kein Verlauf angezeigt werden.");
                return;
            }

            // check if we have any possible history versions
            if (
                Convert.ToInt32(
                    DBUtil.ExecuteScalarSQL(
                        @"
                        SELECT COUNT(1)
                        FROM dbo.Hist_FaSituationsbeschreibung WITH (READUNCOMMITTED)
                        WHERE FaSituationsbeschreibungID = {0} AND
                              BaPersonID = {1}",
                        qryFaSituationsbeschreibung["FaSituationsbeschreibungID"],
                        _baPersonID)) < 1)
            {
                KissMsg.ShowInfo(
                    "CtlFaSituationsbeschreibung",
                    "NoHistoryVersionFound",
                    "Es wurden keine historisierten Einträge gefunden, der Verlauf kann nicht angezeigt werden.");
                return;
            }

            try
            {
                // show dialog with versions (Image icon, string caption, int faSituationsbeschreibungID, int baPersonID)
                DlgFaSituationsbeschreibungHist dlg = new DlgFaSituationsbeschreibungHist(
                    picTitel.Image, lblTitel.Text, Convert.ToInt32(qryFaSituationsbeschreibung["FaSituationsbeschreibungID"]), _baPersonID);
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    "CtlFaSituationsbeschreibung", "ErrorShowingHistory_v01", "Es ist ein Fehler beim Anzeigen des Verlaufs aufgetreten.", ex);
            }
        }

        private bool CanUseHistory()
        {
            return !(!qryFaSituationsbeschreibung.CanUpdate ||
                     (qryFaSituationsbeschreibung.Row.RowState == DataRowState.Added && !qryFaSituationsbeschreibung.RowModified) ||
                     !qryFaSituationsbeschreibung.Post() ||
                     qryFaSituationsbeschreibung.Count < 1);
        }

        private void CtlFaSituationsbeschreibung_Load(object sender, EventArgs e)
        {
            tabSituationsbeschreibung.SelectedTabIndex = 0;

            // update icons
            tabSituationsbeschreibung.ShowIconUpdate();
        }

        private void HandlePreviousNext(Navigation navigationMode)
        {
            // check if we have more than one entry
            if (qryFaSituationsbeschreibung.Count < 2)
            {
                // hide buttons
                btnPrevious.Visible = false;
                btnNext.Visible = false;

                return;
            }

            // show buttons
            btnPrevious.Visible = true;
            btnNext.Visible = true;

            // check if we can save changes
            if (!qryFaSituationsbeschreibung.Post())
            {
                return;
            }

            // do navigation
            switch (navigationMode)
            {
                case Navigation.None:
                    break;

                case Navigation.Previous:
                    qryFaSituationsbeschreibung.Previous();
                    break;

                case Navigation.Next:
                    qryFaSituationsbeschreibung.Next();
                    break;
            }

            // enable/disable buttons depending on current position (zero-based)
            btnPrevious.Enabled = qryFaSituationsbeschreibung.Position > 0;
            btnNext.Enabled = qryFaSituationsbeschreibung.Position < (qryFaSituationsbeschreibung.Count - 1);

            // update icons
            tabSituationsbeschreibung.ShowIconUpdate();
        }

        private void qryFaSituationsbeschreibung_AfterFill(object sender, EventArgs e)
        {
            // enable / disable buttons
            HandlePreviousNext(Navigation.None);
        }

        private void qryFaSituationsbeschreibung_AfterInsert(object sender, EventArgs e)
        {
            // apply default value
            qryFaSituationsbeschreibung["BaPersonID"] = _baPersonID;
            qryFaSituationsbeschreibung["Creator"] = DBUtil.GetDBRowCreatorModifier();
        }

        private void qryFaSituationsbeschreibung_AfterPost(object sender, EventArgs e)
        {
            // update icons
            tabSituationsbeschreibung.ShowIconUpdate();
        }
    }
}