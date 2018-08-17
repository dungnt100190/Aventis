using System;
using DevExpress.XtraGrid.Views.Base;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkMonatszahlenVerrechnung : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_PERSON = "Person";
        private const string COL_SALDOVERRECHNUNSKONTO = "Saldo";
        private const string DATAMEMBER_ANZAHLMONATE = "AnzahlMonate";

        #endregion

        #region Private Fields

        private bool _canEditData;
        private int _ikRechtstitelID;
        private bool _isInPositionChanging;
        private bool _wasVisible;

        #endregion

        #endregion

        #region Constructors

        public CtlIkMonatszahlenVerrechnung()
        {
            InitializeComponent();

            // set min/max size to have proper display with optional scrollbars
            panDetails.AutoScrollMinSize = panDetails.Size;
            panDetails.AutoScroll = true;
            panDetails.MaximumSize = panDetails.Size;

            SetupFieldNames();
        }

        #endregion

        #region EventHandlers

        private void CtlIkMonatszahlenVerrechnung_VisibleChanged(object sender, EventArgs e)
        {
            // HACK: somehow, moving to last datarow does not work after filling, so we do it here only once
            if (_wasVisible || !Visible)
            {
                return;
            }

            _wasVisible = true;

            qryVerrechnung.Last();
        }

        private void edtBetragProMonat_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtBetragProMonat.UserModified || _isInPositionChanging)
            {
                return;
            }

            // calc
            qryVerrechnung[DBO.IkVerrechnungskonto.BetragProMonat] = Utils.ConvertToDecimal(edtBetragProMonat.EditValue);
            SetCalculatedValues();
        }

        private void edtDatumVon_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtDatumVon.UserModified || _isInPositionChanging)
            {
                return;
            }

            // calc
            if (DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon] = null;
            }
            else
            {
                qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon] = Convert.ToDateTime(edtDatumVon.EditValue);
            }

            SetCalculatedValues();
        }

        private void edtGrundforderung_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtGrundforderung.UserModified || _isInPositionChanging)
            {
                return;
            }

            // calc
            qryVerrechnung[DBO.IkVerrechnungskonto.Grundforderung] = Utils.ConvertToDecimal(edtGrundforderung.EditValue);
            SetCalculatedValues();
        }

        private void grvVerrechnung_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Handled = false;

            if (grvVerrechnung.FocusedRowHandle == e.RowHandle)
            {
                return;
            }

            var erl = grvVerrechnung.GetRowCellValue(e.RowHandle, grvVerrechnung.Columns[DBO.IkVerrechnungskonto.IstErledigt]);
            var erledigt = (erl is bool) ? Convert.ToBoolean(erl) : false;

            e.Appearance.BackColor = erledigt ? GuiConfig.GridRowHighlightedRed : GuiConfig.GridRowReadOnly;
        }

        private void qryVerrechnung_AfterFill(object sender, EventArgs e)
        {
            SetRightsAndUpdateDisplay();
        }

        private void qryVerrechnung_AfterInsert(object sender, EventArgs e)
        {
            qryVerrechnung[DBO.IkVerrechnungskonto.IkRechtstitelID] = _ikRechtstitelID;
            qryVerrechnung[DBO.IkVerrechnungskonto.IkVerrechnungsartCode] = 2; // LOVName=IkVerrechnungsart; 2="Rückforderung von Gläubiger"
            qryVerrechnung[DBO.IkVerrechnungskonto.IstErledigt] = false;
            qryVerrechnung[DBO.IkVerrechnungskonto.IstAnnulliert] = false;

            edtBaPersonID.Focus();
        }

        private void qryVerrechnung_AfterPost(object sender, EventArgs e)
        {
            if (Session.Transaction == null)
            {
                return;
            }

            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    EXEC dbo.spIkMonatszahlen_DetailAll NULL, {0}, 1;", _ikRechtstitelID);

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryVerrechnung_BeforePost(object sender, EventArgs e)
        {
            // done editing
            qryVerrechnung.EndCurrentEdit();

            // validate
            DBUtil.CheckNotNullField(edtBaPersonID, lblBaPersonID.Text);
            DBUtil.CheckNotNullField(edtGrundforderung, lblGrundforderung.Text);
            DBUtil.CheckNotNullField(edtBetragProMonat, lblBetragProMonat.Text);
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);

            if (Utils.ConvertToDecimal(qryVerrechnung[DBO.IkVerrechnungskonto.Grundforderung]) < 0)
            {
                KissMsg.ShowInfo(Name, "BeforePostGrundforderungKleinerNull", "Die Grundforderung darf nicht kleiner als 0 sein.");
                edtGrundforderung.Focus();
                throw new KissCancelException();
            }

            if (Utils.ConvertToDecimal(qryVerrechnung[DBO.IkVerrechnungskonto.BetragProMonat]) < 0)
            {
                KissMsg.ShowInfo(Name, "BeforePostBetragProMonatKleinerNull", "Der Betrag pro Monat darf nicht kleiner als 0 sein.");
                edtBetragProMonat.Focus();
                throw new KissCancelException();
            }

            if (Utils.ConvertToDecimal(qryVerrechnung[DBO.IkVerrechnungskonto.Grundforderung]) < Utils.ConvertToDecimal(qryVerrechnung[DBO.IkVerrechnungskonto.BetragProMonat]))
            {
                KissMsg.ShowInfo(Name, "BeforePostGrundforderungKleinerBetragProMonat", "Die Grundforderung darf nicht kleiner sein als der Betrag pro Monat.");
                edtGrundforderung.Focus();
                throw new KissCancelException();
            }

            // handle DatumVon, calc and DatumBis
            qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon] = Utils.firstDayOfMonth(Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon]));
            SetCalculatedValues();
            qryVerrechnung[DBO.IkVerrechnungskonto.DatumBis] = Utils.firstDayOfMonth(Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumBis]));

            // handle annullieren
            HandleAndCheckAnnullieren();

            // update display
            qryVerrechnung[COL_PERSON] = edtBaPersonID.GetDisplayText(edtBaPersonID.EditValue);

            var annulliertAmOrDatumBis = Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumBis]);
            annulliertAmOrDatumBis = DBUtil.IsEmpty(qryVerrechnung[DBO.IkVerrechnungskonto.AnnulliertAm]) ? annulliertAmOrDatumBis : Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.AnnulliertAm]);

            // validate account vs. person crossings
            if (IkUtils.AlreadyHasAccountForGivenPerson(
                GetCurrentVrkIDIfDefined(),
                Convert.ToInt32(qryVerrechnung[DBO.IkVerrechnungskonto.BaPersonID]),
                _ikRechtstitelID,
                Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon]),
                annulliertAmOrDatumBis))
            {
                KissMsg.ShowInfo(
                    Name,
                    "BeforePostAlreadyHasAccountForPerson",
                    "Für diese Person und den gewählten Zeitraum gibt es bereits ein Verrechnungskonto.");

                edtBaPersonID.Focus();
                throw new KissCancelException();
            }

            // use transaction
            Session.BeginTransaction();
        }

        private void qryVerrechnung_PositionChanged(object sender, EventArgs e)
        {
            // reset flag
            _isInPositionChanging = false;

            SetRightsAndUpdateDisplay();
        }

        private void qryVerrechnung_PositionChanging(object sender, EventArgs e)
        {
            // set flag to prevent unneeded calculations
            _isInPositionChanging = true;
        }

        private void qryVerrechnung_PostCompleted(object sender, EventArgs e)
        {
            // refresh data after updating Monatszahlen (this will also set rights and update display (afterfill))
            qryVerrechnung.Refresh();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Activate()
        {
            edtBaPersonID.Focus();
        }

        public void Init(int rechtstitelID, int fallID, int fallPersonID, bool canEdit)
        {
            _ikRechtstitelID = rechtstitelID;
            _canEditData = canEdit;

            qryVerrechnung.CanUpdate = canEdit;
            qryVerrechnung.CanInsert = canEdit;
            qryVerrechnung.CanDelete = canEdit;

            FillQueryVerrechnung();
        }

        #endregion

        #region Private Methods

        private void CalculateAnzahlMonate()
        {
            SetCalculatedValues(
                qryVerrechnung[DBO.IkVerrechnungskonto.Grundforderung],
                qryVerrechnung[DBO.IkVerrechnungskonto.BetragProMonat],
                qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon],
                true);
        }

        private void FillQueryPersonAndSetupControl()
        {
            edtBaPersonID.Properties.DataSource = null;

            qryPerson.Fill(@"
                SELECT DISTINCT
                       [BaPersonID] = PRS.BaPersonID,
                       [Text]       = PRS.NameVorname + ISNULL(', ' + CONVERT(VARCHAR(10), PRS.Geburtsdatum, 104), ''),
                       [Alter]      = PRS.[Alter]
                FROM (SELECT GLB.BaPersonID
                      FROM dbo.IkGlaeubiger        GLB WITH (READUNCOMMITTED)
                        -- show only persons who are allowed to have ALBV
                        INNER JOIN dbo.IkForderung FRD WITH (READUNCOMMITTED) ON FRD.IkForderungID = (SELECT TOP 1
                                                                                                             SFRD.IkForderungID
                                                                                                      FROM dbo.IkForderung SFRD WITH (READUNCOMMITTED)
                                                                                                      WHERE SFRD.IkRechtstitelID = GLB.IkRechtstitelID
                                                                                                        AND SFRD.ALBVBerechtigt = 1
                                                                                                        AND SFRD.IkForderungPeriodischCode = 1      -- LOVName=IkForderungPeriodisch; 1=Kinderalimente
                                                                                                        AND GETDATE() BETWEEN SFRD.DatumAnpassenAb AND ISNULL(SFRD.DatumGueltigBis, '9999-12-31')
                                                                                                        AND SFRD.BaPersonID = GLB.BaPersonID
                                                                                                      ORDER BY SFRD.DatumAnpassenAb DESC)           -- get only newest matching IkForderung
                      WHERE GLB.IkRechtstitelID = {0}

                      UNION ALL

                      SELECT VRK.BaPersonID
                      FROM dbo.IkVerrechnungskonto VRK WITH (READUNCOMMITTED)
                      WHERE VRK.IkRechtstitelID = {0}
                        AND VRK.IkVerrechnungskontoID = {1}) SUB
                  INNER JOIN dbo.vwPerson                    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SUB.BaPersonID
                ORDER BY [Alter] DESC, [Text] ASC;", _ikRechtstitelID, GetCurrentVrkIDIfDefined());

            edtBaPersonID.Properties.DataSource = qryPerson;
            edtBaPersonID.Properties.DropDownRows = Math.Min(qryPerson.Count, 14);
        }

        private void FillQueryVerrechnung()
        {
            qryVerrechnung.Fill(@"
                SELECT VRK.IkVerrechnungskontoID,
                       VRK.IkRechtstitelID,
                       VRK.BaPersonID,
                       VRK.Grundforderung,
                       VRK.VereinbarungVom,
                       VRK.BetragProMonat,
                       VRK.DatumVon,
                       VRK.DatumBis,
                       VRK.LetzterMonat,
                       VRK.Bemerkung,
                       VRK.IstErledigt,
                       VRK.IstAnnulliert,
                       VRK.AnnulliertAm,
                       VRK.IkVerrechnungsartCode,
                       VRK.IkVerrechnungskontoTS,
                       --
                       AnzahlMonate = NULL,
                       --
                       Person = PRS.NameVorname,
                       Saldo  = CONVERT(DECIMAL(10, 2), VRK.Grundforderung +
                                -- BetragALBVverrechnung is negative!
                                ISNULL((SELECT Saldo = SUM(ISNULL(IPO.BetragALBVverrechnung, 0.0))
                                        FROM dbo.IkPosition           IPO WITH (READUNCOMMITTED)
                                          INNER JOIN dbo.IkGlaeubiger GLB WITH (READUNCOMMITTED) ON GLB.IkRechtstitelID = IPO.IkRechtstitelID
                                                                                                AND GLB.BaPersonID = IPO.BaPersonID
                                        WHERE IPO.IkRechtstitelID = VRK.IkRechtstitelID
                                          AND IPO.BaPersonID = VRK.BaPersonID
                                          AND IPO.Einmalig = 0        -- only Periodisch
                                          AND IPO.ErledigterMonat = 1 -- month is imported
                                          AND dbo.fnDateSerial(IPO.Jahr, IPO.Monat, 1) BETWEEN dbo.fnFirstDayOf(VRK.DatumVon) AND dbo.fnLastDayOf(ISNULL(VRK.AnnulliertAm, VRK.DatumBis))), 0.0))
                FROM dbo.IkVerrechnungskonto   VRK WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = VRK.BaPersonID
                WHERE VRK.IkRechtstitelID = {0}
                ORDER BY VRK.VereinbarungVom ASC, Person ASC;", _ikRechtstitelID);
        }

        private int GetCurrentVrkIDIfDefined()
        {
            return DBUtil.IsEmpty(qryVerrechnung[DBO.IkVerrechnungskonto.IkVerrechnungskontoID]) ? -1 : Convert.ToInt32(qryVerrechnung[DBO.IkVerrechnungskonto.IkVerrechnungskontoID]);
        }

        private void HandleAndCheckAnnullieren()
        {
            // check if we need to validate AnnulliertAm date
            if (qryVerrechnung.IsEmpty ||
                !qryVerrechnung.CanUpdate ||
                edtAnnulliertAm.EditMode == EditModeType.ReadOnly)
            {
                // no data to handle or locked
                return;
            }

            if (DBUtil.IsEmpty(qryVerrechnung[DBO.IkVerrechnungskonto.AnnulliertAm]))
            {
                // setup as not canceled
                qryVerrechnung[DBO.IkVerrechnungskonto.IstAnnulliert] = false;

                SetupTextAndGetIfDefinitelyCanceled();
                return;
            }

            // validate AnnulliertAm (last day of month; after last ALBV payment date)
            var annulliertAm = Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.AnnulliertAm]);
            var lastDayOfMonthAnnulliertAm = Utils.lastDayOfMonth(annulliertAm);

            var datumVon = Utils.firstDayOfMonth(Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon]));
            var datumBis = Utils.lastDayOfMonth(Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumBis]));

            if (!annulliertAm.Equals(lastDayOfMonthAnnulliertAm))
            {
                // auto fix date to last day of month
                qryVerrechnung[DBO.IkVerrechnungskonto.AnnulliertAm] = lastDayOfMonthAnnulliertAm;
                annulliertAm = lastDayOfMonthAnnulliertAm;
            }

            if (annulliertAm < datumVon)
            {
                KissMsg.ShowInfo(Name, "AnnulliertAmBeforeDatumVon", "Das Datum 'Annullieren am' muss nach oder gleich dem Datum 'Dauer von' sein.");

                edtAnnulliertAm.Focus();
                throw new KissCancelException();
            }

            if (annulliertAm > datumBis)
            {
                KissMsg.ShowInfo(Name, "AnnulliertAmAfterDatumBis", "Das Datum 'Annullieren am' muss vor oder gleich dem Datum 'Dauer bis' sein.");

                edtAnnulliertAm.Focus();
                throw new KissCancelException();
            }

            var lastAlbvPaymentDate = LastAlbvPaymentDate();

            if (lastAlbvPaymentDate.HasValue && annulliertAm < lastAlbvPaymentDate.Value)
            {
                KissMsg.ShowInfo(
                    Name,
                    "AnnulliertAmNotAfterLastALBVPayment_v02",
                    "Das Datum 'Annullieren am' muss nach oder im selben Monat der letzten ALBV Auszahlung '{0:d}' sein.",
                    lastAlbvPaymentDate.Value);

                edtAnnulliertAm.Focus();
                throw new KissCancelException();
            }

            // if we are here, mark entry as canceled
            qryVerrechnung[DBO.IkVerrechnungskonto.IstAnnulliert] = true;

            // setup text
            SetupTextAndGetIfDefinitelyCanceled();
        }

        private bool HavingBookedPositionsForAccount()
        {
            // check if current account is valid (or e.g. new entry)
            if (GetCurrentVrkIDIfDefined() < 1)
            {
                return false;
            }

            var baPersonID = Convert.ToInt32(qryVerrechnung[DBO.IkVerrechnungskonto.BaPersonID]);
            var datumVon = Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon]);
            var datumBis = Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.DatumBis]);

            // check if there are entries within current account
            return IkUtils.HavingBookedPositions(_ikRechtstitelID, baPersonID, datumVon, datumBis);
        }

        private bool IsDefinitelyCanceled()
        {
            var baPersonID = Convert.ToInt32(qryVerrechnung[DBO.IkVerrechnungskonto.BaPersonID]);
            var annulliertAm = Utils.lastDayOfMonth(Convert.ToDateTime(qryVerrechnung[DBO.IkVerrechnungskonto.AnnulliertAm]));

            // check if there are entries after canceling
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.IkPosition IPO WITH (READUNCOMMITTED)
                           WHERE IPO.IkRechtstitelID = {0}
                             AND IPO.BaPersonID = {1}
                             AND IPO.ErledigterMonat = 1    -- only Erledigt
                             AND IPO.Einmalig = 0           -- only Periodisch
                             AND dbo.fnLastDayOf(dbo.fnDateSerial(IPO.Jahr, IPO.Monat, 1)) > {2}))
                BEGIN
                  -- definitely canceled
                  SELECT 1;
                END
                ELSE
                BEGIN
                  -- only marked as canceled/not marked
                  SELECT 0;
                END;", _ikRechtstitelID, baPersonID, annulliertAm));
        }

        private DateTime? LastAlbvPaymentDate()
        {
            var dateLastAlbvPayment = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT MAX(dbo.fnLastDayOf(dbo.fnDateSerial(IPO.Jahr, IPO.Monat, 1)))
                FROM dbo.IkPosition IPO WITH (READUNCOMMITTED)
                WHERE IPO.IkRechtstitelID = {0}
                  AND IPO.ErledigterMonat = 1    -- only Erledigt
                  AND IPO.Einmalig = 0           -- only Periodisch
                  AND IPO.BaPersonID = {1};", _ikRechtstitelID, qryVerrechnung[DBO.IkVerrechnungskonto.BaPersonID]);

            if (dateLastAlbvPayment is DateTime)
            {
                return Convert.ToDateTime(dateLastAlbvPayment);
            }

            return null;
        }

        private void SetCalculatedValues()
        {
            SetCalculatedValues(
                qryVerrechnung[DBO.IkVerrechnungskonto.Grundforderung],
                qryVerrechnung[DBO.IkVerrechnungskonto.BetragProMonat],
                qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon],
                false);
        }

        private void SetCalculatedValues(object grundForderung, object proMonat, object datumVon, bool setOnlyAnzahlMonate)
        {
            if (qryVerrechnung.IsEmpty)
            {
                return;
            }

            qryVerrechnung.EndCurrentEdit();

            if (setOnlyAnzahlMonate && !DBUtil.IsEmpty(qryVerrechnung[DATAMEMBER_ANZAHLMONATE]))
            {
                // calulate only once if not changed values
                return;
            }

            bool queryModified = qryVerrechnung.RowModified;
            var letzterBetrag = Convert.ToDecimal(0.0);
            decimal grund = Utils.ConvertToDecimal(grundForderung);
            decimal proMo = Utils.ConvertToDecimal(proMonat);
            int anzahlMonate = 0;

            if (!DBUtil.IsEmpty(datumVon) && grund > 0 && proMo > 0)
            {
                var startDatum = Convert.ToDateTime(datumVon);
                var letztesDatum = startDatum;
                var rest = grund;

                while (rest > 0)
                {
                    if (rest > proMo)
                    {
                        // Rest ist grösser als Betrag pro Monat, also 1 Monat erstellen
                        letztesDatum = letztesDatum.AddMonths(1);
                        rest -= proMo;
                    }
                    else
                    {
                        // Rest ist gleich oder kleiner Betrag pro Monat, also 1 Monat erstellen
                        letzterBetrag = rest;
                        rest = Convert.ToDecimal(0.0);
                    }

                    anzahlMonate++;
                }

                if (!setOnlyAnzahlMonate)
                {
                    qryVerrechnung[DBO.IkVerrechnungskonto.DatumBis] = letztesDatum;
                    qryVerrechnung[DBO.IkVerrechnungskonto.LetzterMonat] = letzterBetrag;
                }

                qryVerrechnung[DATAMEMBER_ANZAHLMONATE] = anzahlMonate;
            }
            else
            {
                if (!setOnlyAnzahlMonate)
                {
                    qryVerrechnung[DBO.IkVerrechnungskonto.DatumBis] = qryVerrechnung[DBO.IkVerrechnungskonto.DatumVon];
                    qryVerrechnung[DBO.IkVerrechnungskonto.LetzterMonat] = Convert.ToDecimal(0.0);
                }

                qryVerrechnung[DATAMEMBER_ANZAHLMONATE] = null;
            }

            // if user cannot change data, we accept changes without saving (or we calulated only amout of months)
            if (!_canEditData || (setOnlyAnzahlMonate && !queryModified && qryVerrechnung.Row.RowState != System.Data.DataRowState.Added))
            {
                qryVerrechnung.RowModified = false;
                qryVerrechnung.Row.AcceptChanges();
            }

            qryVerrechnung.RefreshDisplay();
        }

        private void SetRightsAndUpdateDisplay()
        {
            var isDefinitelyCanceled = SetupTextAndGetIfDefinitelyCanceled();

            var canEdit = (qryVerrechnung.CanUpdate &&                                                  // query content can be changed
                            qryVerrechnung.Count > 0 &&                                                  // query has content
                            _ikRechtstitelID > 0 &&                                                      // valid id is given
                            !isDefinitelyCanceled &&                                                     // entry is not definitely canceled
                            (!Convert.ToBoolean(qryVerrechnung[DBO.IkVerrechnungskonto.IstErledigt])));  // entry is not finished

            if (!canEdit || !_canEditData)
            {
                // lock editing whole entry
                qryVerrechnung.EnableBoundFields(false);
                qryVerrechnung.CanDelete = false;
            }
            else
            {
                var havingBookedPositionsForAccount = HavingBookedPositionsForAccount();
                var editModeNormal = havingBookedPositionsForAccount ? EditModeType.ReadOnly : EditModeType.Normal;
                var editModeRequired = havingBookedPositionsForAccount ? EditModeType.ReadOnly : EditModeType.Required;

                // setup locking of controls
                edtBaPersonID.EditMode = editModeRequired;
                edtVereinbarungVom.EditMode = editModeNormal;
                edtGrundforderung.EditMode = editModeRequired;
                edtBetragProMonat.EditMode = editModeRequired;
                edtDatumVon.EditMode = editModeRequired;

                edtDatumBis.EditMode = EditModeType.ReadOnly;
                edtAnzahlMonate.EditMode = EditModeType.ReadOnly;
                edtLetzterMonat.EditMode = EditModeType.ReadOnly;

                memBemerkungen.EditMode = EditModeType.Normal;
                edtAnnulliertAm.EditMode = EditModeType.Normal;

                // enable editing whole entry on query
                qryVerrechnung.EnableBoundFields(true);
                qryVerrechnung.CanDelete = !havingBookedPositionsForAccount;
            }

            FillQueryPersonAndSetupControl();
            CalculateAnzahlMonate();
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colPerson.FieldName = COL_PERSON;
            colGrundforderung.FieldName = DBO.IkVerrechnungskonto.Grundforderung;
            colDatumVon.FieldName = DBO.IkVerrechnungskonto.DatumVon;
            colDatumBis.FieldName = DBO.IkVerrechnungskonto.DatumBis;
            colMonatlicherBetrag.FieldName = DBO.IkVerrechnungskonto.BetragProMonat;
            colAnnulliertAm.FieldName = DBO.IkVerrechnungskonto.AnnulliertAm;
            colIstErledigt.FieldName = DBO.IkVerrechnungskonto.IstErledigt;
            colSaldoVerrechnunsKonto.FieldName = COL_SALDOVERRECHNUNSKONTO;
        }

        private bool SetupTextAndGetIfDefinitelyCanceled()
        {
            var labelTextAnnullieren = KissMsg.GetMLMessage(Name, "AnnulierenAm", "Annullieren am");
            var labelTextAnnulliert = KissMsg.GetMLMessage(Name, "AnnuliertAm", "Annulliert am");

            string labelText;
            bool isDefinitelyCanceled;

            if (qryVerrechnung.IsEmpty || DBUtil.IsEmpty(qryVerrechnung[DBO.IkVerrechnungskonto.AnnulliertAm]))
            {
                labelText = labelTextAnnullieren;
                isDefinitelyCanceled = false;
            }
            else
            {
                isDefinitelyCanceled = IsDefinitelyCanceled();
                labelText = isDefinitelyCanceled ? labelTextAnnulliert : labelTextAnnullieren;
            }

            lblAnnullieren.Text = labelText;
            return isDefinitelyCanceled;
        }

        #endregion

        #endregion
    }
}