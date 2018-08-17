using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    public partial class CtlBaZahlungsweg : KissUserControl, IBelegleser
    {
        #region Fields

        #region Private Fields

        private int _baInstitutionId;
        private int _baPersonId;
        private bool _isPersonZahlungsweg;

        #endregion

        #endregion

        #region Constructors

        public CtlBaZahlungsweg()
        {
            InitializeComponent();

            // default property values
            AutoSetRights = true;

            edtBankPC.Location = edtPostkontoNr.Location;
            edtBankPC.Size = edtPostkontoNr.Size;

            // warning color for error-messages
            edtIBANErrorMsg.ForeColor = System.Drawing.Color.Red;

            // Anzeigen im Gitter:
            colEZ.ColumnEdit = grdBaZahlungsweg.GetLOVLookUpEdit((SqlQuery)edtEinzahlungsschein.Properties.DataSource);

            // Fokus setzen
            edtDatumVon.Focus();

            // Rechte der Qry setzen
            SetRights();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get and set if rights will be handled automatically
        /// </summary>
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Get and set if rights will be handled automatically")]
        public bool AutoSetRights
        {
            get;
            set;
        }

        public int BaInstitutionID
        {
            set
            {
                _baInstitutionId = value;
                _isPersonZahlungsweg = false;
                Visible = value > 0;

                FillZahlungsweg();
            }
            get
            {
                return _baInstitutionId;
            }
        }

        public int BaPersonID
        {
            set
            {
                _baPersonId = value;
                _isPersonZahlungsweg = true;
                Visible = value > 0;

                FillZahlungsweg();
            }
            get
            {
                return _baPersonId;
            }
        }

        public bool IsZahlwegForInstitution
        {
            set
            {
                edtBaZahlwegModulStdCodes.Visible = !value;
                lblStandardZahlwegFuer.Visible = !value;
            }
        }

        #endregion

        #region EventHandlers

        private void btnGenerateIBAN_Click(object sender, EventArgs e)
        {
            if (!qryBaZahlungsweg.Post())
            {
                return;
            }

            int ezCode = Utils.ConvertToInt(edtEinzahlungsschein.EditValue);

            if (ezCode == 0)
            {
                return;
            }

            try
            {
                string iban;
                if (ezCode == 1 || ezCode == 2)
                {
                    // IBAN generieren für PC-Konti, Format ist "xx-yyyyyy-p"
                    iban = Belegleser.IBANConvert(edtPostkontoNr.Text, "9000");
                    edtIBAN.Text = iban;
                }
                else if (ezCode == 3 || ezCode == 5)
                {
                    // IBAN aus Bankkontonummer und Bank (Clearingnummer)
                    iban = Belegleser.IBANConvert(edtPostkontoNr.Text, edtClearingNummer.Text);
                    edtIBAN.Text = iban;
                }
                else
                {
                    KissMsg.ShowInfo(Name, "NoIBANNrForThisType", "Für diesen Typ kann keine IBAN-Nummer generiert werden.");
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "IBANGenerationFailed_v01", "Es konnte keine IBAN generiert werden.\r\n\r\nBitte die Postkonto- oder Bankkontonummer überprüfen.", ex);
            }
        }

        private void edtBankkontoNr_EditValueChanged(object sender, EventArgs e)
        {
            // Schalter IBAN generieren
            SetIbanButton();
        }

        private void edtBankPost_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtBankPost.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                    qryBaZahlungsweg["BankName"] = DBNull.Value;
                    qryBaZahlungsweg["BankPC"] = DBNull.Value;
                    qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new DlgAuswahl();

            if (dlg.SearchBank(searchString, e.ButtonClicked))
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = dlg[DBO.BaZahlungsweg.BaBankID];
                qryBaZahlungsweg["BankName"] = string.Format("{0}, {1}", dlg[DBO.BaBank.Name], dlg[DBO.BaBank.Ort]);
                qryBaZahlungsweg[DBO.BaBank.ClearingNr] = dlg[DBO.BaBank.ClearingNr];
                qryBaZahlungsweg["BankPC"] = dlg[DBO.BaBank.PCKontoNr];
            }

            qryBaZahlungsweg.RefreshDisplay();
            dlg.Dispose();
        }

        private void edtEinzahlungsschein_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            /*
              Specifies that the dropdown window was closed because an end user:
                ButtonClick  clicked the editor's dropdown button.
                Cancel       pressed the ESC key or clicked the close button
                             (available for LookUpEdit, CalcEdit and PopupContainerEdit controls).
                CloseUpKey   pressed a shortcut used to close the dropdown (the ALT+DOWN ARROW or RepositoryItemPopupBase.CloseUpKey).
                Immediate    clicked outside the editor.
                Normal       selected an option from the editor's dropdown.
              */

            e.AcceptValue = true;

            if (!e.CloseMode.Equals(DevExpress.XtraEditors.PopupCloseMode.Normal))
            {
                return;
            }

            // Alter Code holen und vergleichen:
            int oldValue = 0;

            if (!DBUtil.IsEmpty(edtEinzahlungsschein.EditValue))
            {
                oldValue = Convert.ToInt32(edtEinzahlungsschein.EditValue);
            }
            if ((oldValue == 0) || (oldValue == Convert.ToInt32(e.Value)))
            {
                return;
            }

            // Kontrollieren, ob eine Abfrage notwendig ist:
            bool hasToAsk = false;
            int newValue = Convert.ToInt32(e.Value);

            bool isNotEmptyZlwBankKontoNr = !DBUtil.IsEmpty(qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer]);
            bool isNotEmptyZlwBaBankId = !DBUtil.IsEmpty(qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID]);
            bool isNotEmptyZlwPostKontoNummer = !DBUtil.IsEmpty(qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer]);
            bool isNotEmptyZlwIbanNummer = !DBUtil.IsEmpty(qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer]);

            if (((newValue == 1) && (isNotEmptyZlwBankKontoNr || isNotEmptyZlwBaBankId || isNotEmptyZlwIbanNummer)) ||
                ((newValue == 2) && (isNotEmptyZlwBankKontoNr || isNotEmptyZlwBaBankId || isNotEmptyZlwIbanNummer)) ||
                ((newValue == 3 || newValue == 5) && isNotEmptyZlwPostKontoNummer) ||
                ((newValue == 4) && (isNotEmptyZlwPostKontoNummer || isNotEmptyZlwBankKontoNr || isNotEmptyZlwBaBankId)) ||
                ((newValue == 6) && (isNotEmptyZlwPostKontoNummer || isNotEmptyZlwBankKontoNr || isNotEmptyZlwBaBankId || isNotEmptyZlwIbanNummer)))
            {
                hasToAsk = true;
            }

            if (hasToAsk)
            {
                // Jetzt abfragen, ob die alten Daten gelöscht werden sollen oder nicht:
                if (!KissMsg.ShowQuestion(Name, "ConfirmDeleteOldData", "Sie haben den Typ 'Einzahlungsschein' gewechselt.\r\n" +
                                                                             "Somit werden bereits erfasste Daten ungültig und werden automatisch gelöscht.\r\n\r\n" +
                                                                             "Wollen Sie fortfahren und die erfasste Daten löschen lassen?"))
                {
                    // Nein, erfasste Daten sollen nicht gelöscht werden,
                    // Also soll der neue Code nicht gesetzt werden:
                    e.AcceptValue = false;
                    return;
                }
            }

            // Ja, erfasste Daten sollen gelöscht werden:
            if (newValue == 1 || newValue == 2)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer] = DBNull.Value;
                qryBaZahlungsweg["BankPC"] = DBNull.Value;
                qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
            }
            else if (newValue == 2)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }
            else if (newValue == 3 || newValue == 5)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = DBNull.Value;
                qryBaZahlungsweg["PcNr"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }
            else if (newValue == 4)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer] = DBNull.Value;
                qryBaZahlungsweg["BankPC"] = DBNull.Value;
                qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = DBNull.Value;
                qryBaZahlungsweg["PcNr"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }
            else if (newValue == 6)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] = DBNull.Value;
                qryBaZahlungsweg["BankPC"] = DBNull.Value;
                qryBaZahlungsweg["ClearingNr"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = DBNull.Value;
                qryBaZahlungsweg["PcNr"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }

            qryBaZahlungsweg.RefreshDisplay();
        }

        private void edtEinzahlungsschein_EditValueChanged(object sender, EventArgs e)
        {
            // Editieren der Felder einstellen
            SetAllFields_ES();

            // Schalter IBAN generieren setzen
            SetIbanButton();
        }

        private void edtEinzahlungsschein_EnterKey(object sender, KeyEventArgs e)
        {
            if (edtPostkontoNr.Visible)
            {
                edtPostkontoNr.Focus();
            }
            else
            {
                edtBankPost.Focus();
            }
        }

        private void edtName_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void edtPostkontoNr_EditValueChanged(object sender, EventArgs e)
        {
            // Schalter IBAN generieren
            SetIbanButton();
        }

        private void edtWohnsitzPLZOrt_Load(object sender, EventArgs e)
        {
        }

        private void edtWohnsitzStrasse_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void edtWohnsitzZusatz_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void lblEinzahlungFuer_Click(object sender, EventArgs e)
        {
        }

        private void lblName_Click(object sender, EventArgs e)
        {
        }

        private void lblPLZOrt_Click(object sender, EventArgs e)
        {
        }

        private void lblStandardZahlwegFuer_Click(object sender, EventArgs e)
        {
        }

        private void lblStrasseNr_Click(object sender, EventArgs e)
        {
        }

        private void lblZusatz_Click(object sender, EventArgs e)
        {
        }

        private void qryBaZahlungsweg_AfterFill(object sender, EventArgs e)
        {
            if (qryBaZahlungsweg.Count == 0)
            {
                qryBaZahlungsweg_PositionChanged(sender, e);
            }

            // Wenn Daten vorhanden, auf die letzte Zeile springen:
            if (qryBaZahlungsweg.Count > 0)
            {
                qryBaZahlungsweg.Last();
            }
        }

        private void qryBaZahlungsweg_AfterInsert(object sender, EventArgs e)
        {
            // Defaultwerte:
            if (_isPersonZahlungsweg)
            {
                qryBaZahlungsweg["BaPersonID"] = _baPersonId;
            }
            else
            {
                qryBaZahlungsweg["BaInstitutionID"] = _baInstitutionId;
            }

            edtDatumVon.Focus();
        }

        private void qryBaZahlungsweg_BeforePost(object sender, EventArgs e)
        {
            // Kontrolle der Muss-Felder:
            CheckEditsBeforePost();
            TryGenerateIban();
        }

        private void qryBaZahlungsweg_PositionChanged(object sender, EventArgs e)
        {
            SetEditMainFields();
            edtEinzahlungsschein_EditValueChanged(sender, e);

            edtIBANErrorMsg.Text = "";
            edtIBANErrorMsg.Visible = false;

            if (qryBaZahlungsweg.CanUpdate && qryBaZahlungsweg.Count > 0 &&
                qryBaZahlungsweg.Row.RowState != DataRowState.Added &&
                !DBUtil.UserHasRight("CtlBaZahlungsweg_Bearbeiten"))
            {
                qryBaZahlungsweg.EnableBoundFields(false);
                ((IKissBindableEdit)edtDatumBis).AllowEdit(true);
            }
        }

        private void SetAllFields_ES()
        {
            bool canEdit = qryBaZahlungsweg.CanUpdate;

            // Felder Einstellen gemäss ausgewähltem Einzahlungsscheintyps:
            if (DBUtil.IsEmpty(edtEinzahlungsschein.EditValue) || !canEdit)
            {
                // Wenn nichts gewählt ist, dann soll alles gesperrt sein:
                edtPostkontoNr.EditMode = EditModeType.ReadOnly;
                edtBankkontoNr.EditMode = EditModeType.ReadOnly;
                edtBankPost.EditMode = EditModeType.ReadOnly;
                edtIBAN.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                var ezCode = (int)edtEinzahlungsschein.EditValue;

                // Postkonto-Nr.:
                if (ezCode == 1 || ezCode == 2)
                {
                    edtPostkontoNr.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtPostkontoNr.EditMode = EditModeType.ReadOnly;
                }

                edtPostkontoNr.Visible = (ezCode == 1 || ezCode == 2);
                edtBankPC.Visible = !edtPostkontoNr.Visible;

                // Bankkonto, Bank/Post, IBAN Feld und Schalter
                if (ezCode == 3 || ezCode == 5)
                {
                    edtBankkontoNr.EditMode = EditModeType.Normal;
                    edtBankPost.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtBankkontoNr.EditMode = EditModeType.ReadOnly;
                    edtBankPost.EditMode = EditModeType.ReadOnly;
                }

                // IBAN Feld
                if (ezCode == 3 || ezCode == 4 || ezCode == 5)
                {
                    edtIBAN.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtIBAN.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            if (!qryBaZahlungsweg.CanInsert || qryBaZahlungsweg.Insert() == null)
            {
                return;
            }

            qryBaZahlungsweg[DBO.BaZahlungsweg.EinzahlungsscheinCode] = Convert.ToInt32(beleg.BelegTyp);

            switch (beleg.BelegTyp)
            {
                case BelegTyp.ESR:
                case BelegTyp.Post:
                    qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = beleg.KontoNummer;
                    qryBaZahlungsweg["PcNr"] = DBUtil.ExecuteScalarSQL(@"
                        SELECT dbo.fnTnToPc({0});", beleg.KontoNummer);
                    break;

                case BelegTyp.Bank:
                    SqlQuery qryBaBank = DBUtil.OpenSQL(@"
                        SELECT BaBankID,
                               BankName = Name + ', ' + Ort
                        FROM dbo.BaBank WITH (READUNCOMMITTED)
                        WHERE ClearingNr = {0}
                        ORDER BY FilialeNr;", beleg.ClearingNummer);

                    try
                    {
                        qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = qryBaBank[DBO.BaBank.BaBankID];
                        qryBaZahlungsweg[DBO.BaBank.ClearingNr] = beleg.ClearingNummer;
                        qryBaZahlungsweg["BankName"] = qryBaBank["BankName"];

                        qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] = beleg.IBANNummer;
                    }
                    catch { }
                    break;
            }
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            base.ReceiveMessage(parameters);

            qryBaZahlungsweg.Find(string.Format("BaZahlungswegID={0}", parameters["BaZahlungswegID"]));

            return true;
        }

        public void SetRights()
        {
            // check if need to set rights automatically
            if (!AutoSetRights)
            {
                return;
            }

            // apply rights
            qryBaZahlungsweg.ApplyUserRights();

            // setup controls
            qryBaZahlungsweg.EnableBoundFields();
        }

        /// <summary>
        /// Set rights manually and disable AutoSetRights
        /// </summary>
        /// <param name="canInsertUpdateDelete"><c>True</c> if user can insert, update and delete address records, otherwise <c>False</c></param>
        public void SetRights(bool canInsertUpdateDelete)
        {
            SetRights(canInsertUpdateDelete, canInsertUpdateDelete, canInsertUpdateDelete);
        }

        /// <summary>
        /// Set rights manually and disable AutoSetRights
        /// </summary>
        /// <param name="canInsert"><c>True</c> if user can insert new address records, otherwise <c>False</c></param>
        /// <param name="canUpdate"><c>True</c> if user can update existing address records, otherwise <c>False</c></param>
        /// <param name="canDelete"><c>True</c> if user can delete existing address records, otherwise <c>False</c></param>
        public void SetRights(bool canInsert, bool canUpdate, bool canDelete)
        {
            // disable auto-set-rights
            AutoSetRights = false;

            // setup queries
            qryBaZahlungsweg.CanInsert = canInsert;
            qryBaZahlungsweg.CanUpdate = canUpdate;
            qryBaZahlungsweg.CanDelete = canDelete;

            // setup controls
            qryBaZahlungsweg.EnableBoundFields();
            edtBaZahlwegModulStdCodes.EditMode = canUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        #endregion

        #region Private Methods

        private void CheckEditsBeforePost()
        {
            edtWohnsitzPLZOrt.DoValidate();

            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtEinzahlungsschein, lblEinzahlungsschein.Text);
            int esTyp = Utils.ConvertToInt(edtEinzahlungsschein.EditValue);

            // Bis-Datum darf nicht vor Von-Datum liegen
            var von = edtDatumVon.EditValue as DateTime?;
            var bis = edtDatumBis.EditValue as DateTime?;

            if (von.HasValue && bis.HasValue && von.Value >= bis.Value)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name, "ValidateFromTo", "Das Von-Datum muss vor dem Bis-Datum liegen!"));
            }

            // check if we have table KbBuchung
            bool hasKbBuchungTable = Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                IF (EXISTS (SELECT TOP 1 1 FROM sys.tables WHERE name = 'KbBuchung'))
                BEGIN
                  SELECT 1;
                END
                ELSE
                BEGIN
                  SELECT 0;
                END;"));

            if (hasKbBuchungTable)
            {
                // Kontrollieren, ob der neue Gültigkeitzeitraum alle Buchungen abdeckt, die den Zahlweg verwenden
                SqlQuery qryDates = DBUtil.OpenSQL(@"
                    SELECT [Min] = CASE
                                     WHEN MIN([Min]) < {0} THEN 1
                                     ELSE 0
                                   END,
                           [Max] = CASE
                                     WHEN MAX([Max]) > {1} THEN 1
                                     ELSE 0
                                   END,
                           MinDatum = MIN([Min]),
                           MaxDatum = MAX([Max])
                    FROM (SELECT [Min] = MIN(ValutaDatum),
                                 [Max] = MAX(ValutaDatum)
                          FROM dbo.KbBuchung
                          WHERE BaZahlungswegID = {2}) TMP;", edtDatumVon.EditValue,
                                                              edtDatumBis.EditValue,
                                                              qryBaZahlungsweg[DBO.BaZahlungsweg.BaZahlungswegID]);

                if (Convert.ToInt32(qryDates["Min"]) == 1)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "KbBuchungEntryExistsNewFrom", "Für diesen Zahlungsweg gibt es eine Buchung mit Beleg-Datum {0:dd.MM.yyyy}. Das Von-Datum muss früher festgelegt werden.", qryDates["MinDatum"]));
                }
                if (Convert.ToInt32(qryDates["Max"]) == 1)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "KbBuchungEntryExistsNewTo", "Für diesen Zahlungsweg gibt es eine Buchung mit Beleg-Datum {0:dd.MM.yyyy}. Das Bis-Datum muss später festgelegt werden.", qryDates["MaxDatum"]));
                }
            }

            // Felder kontrollieren gemäss ausgewähltem Einzahlungsscheintyps:
            // Postkonto-Nr.:
            if (esTyp == 1 || esTyp == 2)
            {
                if (DBUtil.IsEmpty(edtIBAN.EditValue) && DBUtil.IsEmpty(edtPostkontoNr.EditValue))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "MissingPostKtNrOrIBAN", "Das Feld 'Postkontonummer' oder das Feld 'IBAN' darf nicht leer sein."));
                }

                if (!DBUtil.IsEmpty(edtPostkontoNr.EditValue))
                {
                    CheckPcNr();
                }
            }

            // Bankkonto, Bank/Post, IBAN Feld und Schalter
            else if (esTyp == 3 || esTyp == 5)
            {
                if (DBUtil.IsEmpty(edtIBAN.EditValue))
                {
                    DBUtil.CheckNotNullField(edtBankPost, lblBankPost.Text);
                    DBUtil.CheckNotNullField(edtBankkontoNr, lblBankkontoNr.Text);
                }
                else if (DBUtil.IsEmpty(edtBankPost.EditValue))
                {
                    string iban = edtIBAN.EditValue.ToString();

                    if (!string.IsNullOrEmpty(iban))
                    {
                        iban = iban.Replace(" ", "");
                        int bcl;

                        if (iban.StartsWith("CH") &&
                            iban.Length == 21 &&
                            int.TryParse(iban.Substring(4, 5), out bcl))
                        {
                            SqlQuery qryBcl = DBUtil.OpenSQL(@"
                                SELECT TOP 1
                                       BaBankID,
                                       ClearingNr,
                                       HauptsitzBCL,
                                       BankName = Name + ISNULL(', ' + Ort,''),
                                       BankPC = dbo.fnTnToPc(PCKontoNr)
                                FROM dbo.BaBank WITH (READUNCOMMITTED)
                                WHERE ClearingNr = {0};", bcl.ToString());

                            if (qryBcl.Count == 0)
                            {
                                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                                qryBaZahlungsweg[DBO.BaBank.ClearingNr] = DBNull.Value;
                                qryBaZahlungsweg["BankName"] = DBNull.Value;
                                qryBaZahlungsweg["BankPC"] = DBNull.Value;
                            }
                            else
                            {
                                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = qryBcl[DBO.BaBank.BaBankID];
                                qryBaZahlungsweg[DBO.BaBank.ClearingNr] = qryBcl[DBO.BaBank.ClearingNr];
                                qryBaZahlungsweg["BankName"] = qryBcl["BankName"];
                                qryBaZahlungsweg["BankPC"] = qryBcl["BankPC"];
                            }
                        }
                    }
                }
            }

            // IBAN Nummer ist bei Bankzahlungen Ausland obligatorisch
            if (esTyp == 4)
            {
                DBUtil.CheckNotNullField(edtIBAN, lblIBAN.Text);
            }

            // IBAN Nummer prüfen, falls vorhanden
            if (!DBUtil.IsEmpty(edtIBAN.EditValue))
            {
                string errorMsg;
                string sIban = edtIBAN.EditValue.ToString();

                if (!Utils.CheckIBAN(sIban, out errorMsg))
                {
                    // Achtung: Der Fokus darf nicht gesetzt werden,
                    // da sonst beim Wechsel zu einem anderen Fenster eine Endlosschlaufe produziert wird:
                    //edtIBAN.Focus();
                    throw new KissInfoException(errorMsg);
                }
            }

            if (esTyp == 1 || esTyp == 2)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer] = DBNull.Value;
            }

            if (esTyp == 2)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }

            if (esTyp == 3 || esTyp == 5)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }

            if (esTyp == 4)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }

            if (esTyp == 6)
            {
                qryBaZahlungsweg[DBO.BaZahlungsweg.BaBankID] = DBNull.Value;
                qryBaZahlungsweg["BankName"] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.BankKontoNummer] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = DBNull.Value;
                qryBaZahlungsweg[DBO.BaZahlungsweg.ReferenzNummer] = DBNull.Value;
            }
        }

        // Kontrolle der Eingabe:
        // zusätzlich soll die PC-Nummer zu einer TN-Nummer umgewandelt werden:
        private void CheckPcNr()
        {
            string pcNr = edtPostkontoNr.EditValue.ToString();
            int esTyp = Utils.ConvertToInt(edtEinzahlungsschein.EditValue);

            if (pcNr.Contains("-") || esTyp == 2)
            {
                string errorMsg;
                string tnNumber;
                if (!Utils.CheckPCKontoNumber(pcNr, out errorMsg, out tnNumber))
                {
                    // Achtung: Der Fokus darf nicht gesetzt werden,
                    // da sonst beim Wechsel zu einem anderen Fenster eine Endlisschlaufe produziert wird:
                    //edtPostkontoNr.Focus();
                    KissMsg.ShowInfo(errorMsg);
                    throw new KissCancelException();
                }

                // Falls kein Fehler: Datenfeld füllen:
                qryBaZahlungsweg["PcNr"] = pcNr;
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = tnNumber;
                qryBaZahlungsweg.RefreshDisplay();
            }
            else
            {
                // Bei Typ 1 soll 5-stellige Nummer zugelassen sein
                if (pcNr.Length != 5)
                {
                    KissMsg.ShowInfo(Name, "NoPCNrMustHave5Chars", "Wenn keine PC-Nummer definiert wird, muss die Nummer 5 Zeichen enthalten.");
                    throw new KissCancelException();
                }

                // Falls kein Fehler: Datenfeld füllen:
                qryBaZahlungsweg["PcNr"] = pcNr;
                qryBaZahlungsweg[DBO.BaZahlungsweg.PostKontoNummer] = pcNr;
                qryBaZahlungsweg.RefreshDisplay();
            }
        }

        private void FillZahlungsweg()
        {
            int id = _isPersonZahlungsweg ? _baPersonId : _baInstitutionId;

            qryBaZahlungsweg.Fill(@"
                SELECT BaZahlungswegID,
                       BaPersonID,
                       BaInstitutionID,
                       DatumVon,
                       DatumBis,
                       EinzahlungsscheinCode,
                       ZLW.BaBankID,
                       BankKontoNummer,
                       IBANNummer,
                       PostKontoNummer,
                       ReferenzNummer,
                       AdresseName,
                       AdresseName2,
                       AdresseStrasse,
                       AdresseHausNr,
                       AdressePostfach,
                       AdressePLZ,
                       AdresseOrt,
                       AdresseOrtCode         = NULL,
                       AdresseLandCode,
                       BaZahlwegModulStdCodes,
                       --
                       PcNr                   = dbo.fnTnToPc(ZLW.PostKontoNummer),
                       ClearingNr             = BNK.ClearingNr,
                       Bankname               = BNK.Name + ', ' + ISNULL(BNK.PLZ + ' ', '') + ISNULL(BNK.Ort, ''),
                       Strasse                = BNK.Strasse,
                       BankPC                 = dbo.fnTnToPc(BNK.PCKontoNr)
                FROM dbo.BaZahlungsweg ZLW
                  LEFT JOIN dbo.BaBank BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = ZLW.BaBankID
                WHERE (1 = {0} AND ZLW.BaPersonID = {1})
                   OR (0 = {0} AND ZLW.BaInstitutionID = {1})
                ORDER BY ZLW.DatumVon, BankName;", _isPersonZahlungsweg, id);

            SetRights();
        }

        private void SetEditMainFields()
        {
            bool canEdit = (qryBaZahlungsweg.CanUpdate && qryBaZahlungsweg.Count > 0);
            EditModeType editMode = EditModeType.ReadOnly;

            if (canEdit)
            {
                editMode = EditModeType.Normal;
            }

            edtDatumVon.EditMode = editMode;
            edtDatumBis.EditMode = editMode;
            edtEinzahlungsschein.EditMode = editMode;
        }

        private void SetIbanButton()
        {
            bool isEnabled = false;

            if (!DBUtil.IsEmpty(edtEinzahlungsschein.EditValue))
            {
                var ezCode = (int)edtEinzahlungsschein.EditValue;
                isEnabled = (!DBUtil.IsEmpty(edtPostkontoNr.Text) && (ezCode == 2) ||
                             !DBUtil.IsEmpty(edtBankkontoNr.Text) && (ezCode == 3 || ezCode == 5));
            }

            if (isEnabled && qryBaZahlungsweg.CanUpdate)
            {
                btnGenerateIBAN.Enabled = true;
            }
            else
            {
                btnGenerateIBAN.Enabled = false;
            }
        }

        private void TryGenerateIban()
        {
            string iban;
            int ezCode = Utils.ConvertToInt(edtEinzahlungsschein.EditValue);

            if (ezCode == 0)
            {
                return;
            }

            edtIBANErrorMsg.Text = "";
            edtIBANErrorMsg.Visible = false;

            try
            {
                if (ezCode == 2)
                {
                    // IBAN generieren für PC-Konti, Format ist "xx-yyyyyy-p"
                    iban = Belegleser.IBANConvert(edtPostkontoNr.Text, "9000");
                    qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] = iban;
                }
                else if (ezCode == 3 || ezCode == 5)
                {
                    if (!string.IsNullOrEmpty(edtBankkontoNr.Text) && !string.IsNullOrEmpty(edtClearingNummer.Text))
                    {
                        // KontoNr und BCL vorhanden
                        // IBAN aus Bankkontonummer und Bank (Clearingnummer)
                        iban = Belegleser.IBANConvert(edtBankkontoNr.Text, edtClearingNummer.Text);
                        var ibanBefore = qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] as string;

                        if (string.IsNullOrEmpty(ibanBefore))
                        {
                            qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] = iban;
                        }
                        else
                        {
                            // neue IBAN mit bestehender vergleichen
                            if (iban.Replace(" ", "") != ibanBefore.Replace(" ", ""))
                            {
                                throw new Exception(KissMsg.GetMLMessage(Name, "NonMatchingIBANWithPrevious", "Generierte IBAN {0} stimmt nicht mir bisheriger ({1}) überein. Löschen Sie die bestehende IBAN oder korrigieren Sie die Kontonummer / Clearingnummer.", iban, ibanBefore));
                            }

                            // sonst stimmts ja, also kein Speichern der IBAN nötig
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                edtIBANErrorMsg.Text = ex.Message;
                edtIBANErrorMsg.Visible = true;
                qryBaZahlungsweg[DBO.BaZahlungsweg.IBANNummer] = DBNull.Value;
            }
        }

        #endregion

        #endregion
    }
}