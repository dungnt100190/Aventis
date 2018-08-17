using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SharpLibrary.WinControls;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    public partial class DlgAuswahlFbZahlungsweg : KissForm
    {
        #region Fields

        #region Private Fields

        private int _baBankId;
        private bool _canReturnUniqueZahlungsWeg;
        private int _fbKreditorID;
        private int _fbZahlungswegID;
        private bool _isSearching;
        private string _searchKontoNummerParam = "";

        #endregion

        #endregion

        #region Constructors

        public DlgAuswahlFbZahlungsweg(string searchParam, string iban, BelegTyp typ)
        {
            InitializeComponent();

            colPCKontoNr.DisplayFormat.Format = new GridColumnPCKontoFormatter();
            SetDataSources(searchParam, iban, typ);

            tabControlSearch.SelectedTabIndex = 1;
            tabControlSearch.SelectedTabIndex = 0;
        }

        public DlgAuswahlFbZahlungsweg(string searchParam)
            : this(searchParam, string.Empty, BelegTyp.Unbekannt)
        {
        }

        #endregion

        #region Dispose

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

        #endregion

        #region Properties

        public int FbKreditorID
        {
            get { return _fbKreditorID; }
        }

        public int FbZahlungswegID
        {
            get { return _fbZahlungswegID; }
        }

        #endregion

        #region EventHandlers

        private void btnListeAbbruch_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnListeOK_Click(object sender, EventArgs e)
        {
            _fbZahlungswegID = Convert.ToInt32(qryFbZahlungsweg["FbZahlungswegID"]);
            _fbKreditorID = Convert.ToInt32(qryFbKreditor["FbKreditorID"]);
            DialogResult = DialogResult.OK;
        }

        private void btnNeuKreditorOk_Click(object sender, EventArgs e)
        {
            if (editName.Text == "")
            {
                KissMsg.ShowInfo("DlgAuswahlZahlungsWeg", "KredNameFehlt", "Kreditor Name fehlt");
                return;
            }

            if (editPLZOrt.PLZ == "")
            {
                KissMsg.ShowInfo("DlgAuswahlZahlungsWeg", "PLZOrtFehlt", "PLZ + Ort fehlen");
                return;
            }

            if (editPLZOrt.Ort == "")
            {
                KissMsg.ShowInfo("DlgAuswahlZahlungsWeg", "PLZOrtFehlt", "PLZ + Ort fehlen");
                return;
            }

            DataRow newKreditor = qryFbKreditor.Insert(null);
            newKreditor["Name"] = editName.Text;
            newKreditor["KurzName"] = editKuerzel.Text;
            newKreditor["Zusatz"] = editZusatz.Text;
            newKreditor["Strasse"] = editStrasse.Text;
            newKreditor["PLZ"] = editPLZOrt.PLZ;
            newKreditor["Ort"] = editPLZOrt.Ort;

            if (editAufwandKonto.Text != "")
            {
                newKreditor["AufwandKonto"] = editAufwandKonto.Text;
            }
            else
            {
                newKreditor["AufwandKonto"] = DBNull.Value;
            }
            qryFbKreditor.Post();

            _fbZahlungswegID = 0;
            _fbKreditorID = Convert.ToInt32(qryFbKreditor["FbKreditorID"]);
            DialogResult = DialogResult.OK;
        }

        private void btnNeuSuche_Click(object sender, EventArgs e)
        {
            NewSearch();
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            OnSearch();
        }

        private void editAufwandKontoSearch_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.StandardKontoSuchen(edtSearchAufwandKonto.Text, e.ButtonClicked, (int)KontoKlasse.Aufwand);

            if (!e.Cancel)
            {
                edtSearchAufwandKonto.Text = dlg["KontoNr"].ToString();
                edtSearchAufwandKontoName.Text = dlg["KontoName"].ToString();
            }
        }

        private void editAufwandKonto_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.StandardKontoSuchen(editAufwandKonto.Text, e.ButtonClicked, (int)KontoKlasse.Aufwand);

            if (!e.Cancel)
            {
                editAufwandKonto.Text = dlg["KontoNr"].ToString();
                editAufwandKontoName.Text = dlg["KontoName"].ToString();
            }
        }

        private void editBankSearch_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FibuUtilities.BankSuchen(edtSearchBank.Text, true, edtSearchBank, ref _baBankId);
        }

        private void editBankSearch_Leave(object sender, EventArgs e)
        {
            if (Text == "")
            {
                _baBankId = 0;
            }
        }

        private void qryKreditor_PositionChanged(object sender, EventArgs e)
        {
            if (!qryFbKreditor.IsInserting)
            {
                string selectStatement = @"
                    SELECT
                      FZW.*,
                      X.Text,
                      Bank = IsNull(FBB.Name + ' ' + FBB.PLZ + ' ' + FBB.Ort, 'Postfinance')
                    FROM FbZahlungsWeg    FZW
                      LEFT  JOIN BaBank   FBB ON FBB.BaBankID = FZW.BaBankID
                      INNER JOIN XLOVCode X   ON FZW.ZahlungsArtCode = X.Code
                                             AND X.Lovname = 'FbZahlungsartCode'
                    WHERE FbKreditorID = {0}
                      AND FZW.IsActive = 1";

                if (_searchKontoNummerParam != "")
                {
                    selectStatement += " AND (FZW.PCKontoNr like {1} OR FZW.BankKontoNr like {1} OR FZW.BelegBankKontoNr like {1}) ";
                }

                selectStatement += " ORDER BY ZahlungsArtCode";

                // When coming from Belegleser
                if (_searchKontoNummerParam != "")
                {
                    qryFbZahlungsweg.Fill(selectStatement, qryFbKreditor["FbKreditorID"], "%" + _searchKontoNummerParam + "%");
                }
                else
                {
                    qryFbZahlungsweg.Fill(selectStatement, qryFbKreditor["FbKreditorID"]);
                }

                qryFbZahlungsweg.RefreshDisplay();
            }
        }

        private void xTabControl1_SelectedTabChanged(TabPageEx page)
        {
            AcceptButton = null;
            CancelButton = null;

            if (page == tpgListe)
            {
                AcceptButton = btnListeOK;
                CancelButton = btnListeAbbruch;
            }
            else if (page == tpgNeuKreditor)
            {
                AcceptButton = btnNeuKreditorOk;
                CancelButton = btnNeuKreditorAbbrechen;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            base.OnSearch();

            if (tabControlSearch.SelectedTab == tpgListe)
            {
                NewSearch();
                return;
            }

            try
            {
                _isSearching = true;
                _canReturnUniqueZahlungsWeg = false;
                qryFbKreditor.SelectStatement = @"
                    Select Distinct FBK.KurzName, FBK.Name, FBK.AufwandKonto, FBK.Zusatz, FBK.PLZ, FBK.Ort, FBK.FbKreditorID, IsNull(FBK.Name + ' ', '') as Kreditor, FBK.Strasse,
                      IsNull(FBK.Plz + ' ', '') + IsNull(FBK.Ort + ' ', '') as KreditorOrt, FZW.IBAN
                    FROM FbKreditor             FBK
                      LEFT  JOIN FbZahlungsweg  FZW on FZW.FbKreditorID = FBK.FbKreditorID ";

                // Kreditor Search Params
                if (edtSearchName.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.Name like " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchName.Text + "%");
                }
                if (edtSearchKurzName.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.KurzName like " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchKurzName.Text + "%");
                }
                if (edtSearchPLZOrt.PLZ != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.PLZ like " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchPLZOrt.PLZ + "%");
                }
                if (edtSearchPLZOrt.Ort != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.Ort like " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchPLZOrt.Ort + "%");
                }
                if (edtSearchStrasse.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.Strasse like " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchStrasse.Text + "%");
                }
                if (edtSearchZusatz.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.Zusatz like " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchZusatz.Text + "%");
                }
                if (edtSearchAufwandKonto.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.AufwandKonto = " +
                                                     DBUtil.SqlLiteral(edtSearchAufwandKonto.Text);
                }
                if (edtSearchAktiv.CheckState != CheckState.Indeterminate)
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FBK.Aktiv = " +
                                                     DBUtil.SqlLiteral(edtSearchAktiv.Checked);
                }

                // ZahlungsWeg Search Params
                if (edtSearchZahlungsArt.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FZW.ZahlungsArtCode = " +
                                                     DBUtil.SqlLiteral(edtSearchZahlungsArt.EditValue) + " ";
                }
                if (edtSearchIban.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " REPLACE(FZW.IBAN,' ', '') LIKE " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchIban.Text.Replace(" ", String.Empty) + "%");
                }
                if (edtSearchPostKontoNr.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FZW.PCKontoNr like " +
                                                     DBUtil.SqlLiteralLike("%" + Utils.FormatPCKontoNummerToDBFormat(edtSearchPostKontoNr.Text) + "%");
                }
                if (edtSearchBankKontoNr.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FZW.BankKontoNr like " +
                                                     DBUtil.SqlLiteralLike("%" + edtSearchBankKontoNr.Text + "%");
                }
                if (_baBankId != 0)
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FZW.BaBankID = " + _baBankId + " ";
                }
                if (edtSearchZahlungsFrist.Text != "")
                {
                    qryFbKreditor.SelectStatement += FibuUtilities.AndOrWhere(qryFbKreditor.SelectStatement) + " FZW.ZahlungsFrist = " +
                                                     DBUtil.SqlLiteral("%" + edtSearchZahlungsFrist.Text + "%");
                }

                qryFbKreditor.SelectStatement += " Order by FBK.Name";

                qryFbKreditor.Fill();

                if (qryFbKreditor.Count == 0)
                {
                    qryFbZahlungsweg.SelectStatement = "Select * from FbzahlungsWeg where FbKreditorID =  null";
                    qryFbZahlungsweg.Fill();
                }

                qryFbKreditor.RefreshDisplay();
                grdFbKreditor.DataSource = qryFbKreditor;

                // Reset parameters received from BelegLeser
                _searchKontoNummerParam = "";

                if (qryFbKreditor.Count == 0)
                {
                    KissMsg.ShowInfo("DlgAuswahlZahlungsWeg", "ZahlungswegNichtGefunden", "Keine zutreffende Zahlungsweg gefunden");
                }
                else
                {
                    if (!tabControlSearch.TabPages.Contains(tpgListe))
                    {
                        tabControlSearch.TabPages.Remove(tpgNeuKreditor);
                        tabControlSearch.TabPages.Remove(tpgSuchen);
                        tabControlSearch.TabPages.Add(tpgListe);
                        tabControlSearch.TabPages.Add(tpgSuchen);
                        //xTabControl1.TabPages.Add(tabNeuKreditor) ;
                        //tabListe.TabIndex = 0 ;
                    }
                    tabControlSearch.SelectedTabIndex = 0;
                    AcceptButton = btnListeOK;
                    CancelButton = btnListeAbbruch;

                    grdFbKreditor.Visible = true;
                }

                _isSearching = false;
            }
            catch (Exception g)
            {
                KissMsg.ShowError("DlgAuswahlZahlungsWeg",
                    "FehlerBeimSuchen",
                    "Beim Suchen ist ein Fehler aufgetreten",
                    g.Message + Environment.NewLine + g.StackTrace,
                    g);
            }
        }

        public DialogResult ShowDialogAuswahl()
        {
            // If possible return directly the "ZahlungsWeg"
            // If the unique Zahlungsweg found is ESR Direkt return directly even if canReturnUniqueZahlungsWeg is false at this point

            if (qryFbZahlungsweg.Count > 0 && qryFbZahlungsweg["ZahlungsArtCode"] != DBNull.Value
                && _isSearching == false && qryFbKreditor.Count == 1 && qryFbZahlungsweg.Count == 1 &&
                (_canReturnUniqueZahlungsWeg ||
                (!_canReturnUniqueZahlungsWeg && Convert.ToInt32(qryFbZahlungsweg["ZahlungsArtCode"]) == (int)ZahlungsArt.OrangerEinzahlungsschein) ||
                (!_canReturnUniqueZahlungsWeg && Convert.ToInt32(qryFbZahlungsweg["ZahlungsArtCode"]) == (int)ZahlungsArt.RoterEinzahlungsscheinPost)))
            {
                _fbZahlungswegID = Convert.ToInt32(qryFbZahlungsweg["FbZahlungswegID"]);
                _fbKreditorID = Convert.ToInt32(qryFbKreditor["FbKreditorID"]);
                DialogResult = DialogResult.OK;
                return DialogResult;
            }

            return ShowDialog();
        }

        #endregion

        #region Private Methods

        private void NewSearch()
        {
            tabControlSearch.SelectTab(tpgSuchen);

            foreach (Control ctl in tpgSuchen.Controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit)
                {
                    ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue = null;
                }
                else if (ctl is KissPLZOrt)
                {
                    ((KissPLZOrt)ctl).PLZ = "";
                    ((KissPLZOrt)ctl).Ort = "";
                }
            }

            // Search Aktiv Kreditor By Default
            edtSearchAktiv.CheckState = CheckState.Checked;
        }

        private void SetDataSources(string searchParam, string iban, BelegTyp typ)
        {
            Regex rxKontoNr = new Regex("[0-9]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex rxIban = new Regex("[a-z]{2}[0-9]{2}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            qryFbKreditor.SelectStatement = @"
                SELECT DISTINCT
                  FBK.KurzName,
                  FBK.Name,
                  FBK.AufwandKonto,
                  FBK.Zusatz,
                  FBK.PLZ,
                  FBK.Ort,
                  FBK.FbKreditorID,
                  Kreditor = ISNULL(FBK.Name + ' ', ''),
                  FBK.Strasse,
                  KreditorOrt = ISNULL(FBK.Plz + ' ', '') + ISNULL(FBK.Ort + ' ', '')
                FROM dbo.FbKreditor FBK WITH(READUNCOMMITTED) ";

            if (typ == BelegTyp.Unbekannt)
            {
                // wir suchen nach Postkonto-Nr / Bankkonto-Nr / IBAN / Kreditor-Name

                // Da der Typ nich bekannt ist, kann kein eindeutiger Zahlungsweg ermittelt werden
                _canReturnUniqueZahlungsWeg = false;

                var isKontoNr = rxKontoNr.IsMatch(searchParam);
                var isIban = rxIban.IsMatch(searchParam);

                if (isKontoNr || isIban)
                {
                    qryFbKreditor.SelectStatement += " LEFT JOIN FbZahlungsweg FZW ON FZW.FbKreditorID = FBK.FbKreditorID ";
                }

                qryFbKreditor.SelectStatement += " WHERE ";
                qryFbKreditor.SelectStatement += " FBK.Aktiv = 1 ";

                if (isKontoNr || isIban)
                {
                    qryFbKreditor.SelectStatement += "AND (FZW.PCKontoNr LIKE {0} OR FZW.BankKontoNr LIKE {0} OR FZW.IBAN LIKE {0} )";

                    if (!isIban)
                    {
                        try
                        {
                            searchParam = Utils.FormatPCKontoNummerToDBFormat(searchParam);
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    qryFbKreditor.SelectStatement += "AND ISNULL(FBK.Name + ' ', '') LIKE {0} ";
                }

                qryFbKreditor.SelectStatement += " ORDER BY ISNULL(FBK.Name + ' ', '') ";

                searchParam = "%" + searchParam.Replace("*", "%") + "%";

                Cursor.Current = Cursors.WaitCursor;
                qryFbKreditor.Fill((object)searchParam);
                Cursor.Current = Cursors.Default;

                grdFbKreditor.DataSource = qryFbKreditor;

                qryFbKreditor.PositionChanged += qryKreditor_PositionChanged;
            }
            // When coming from BelegLeser
            else
            {
                qryFbKreditor.SelectStatement += " INNER JOIN FbZahlungsweg FZW ON FZW.FbKreditorID = FBK.FbKreditorID WHERE ";
                _searchKontoNummerParam = searchParam;

                switch (typ)
                {
                    case BelegTyp.ESR:
                        // There is no possibility to differenciate an ESR Direkt with a ESR Ueber Bank with CodeZiele.
                        _canReturnUniqueZahlungsWeg = false;
                        qryFbKreditor.SelectStatement += "(FZW.ZahlungsArtCode = {0} OR FZW.ZahlungsArtCode = {1}) AND FZW.PCKontoNr like {2} AND FBK.Aktiv = 1 ORDER BY FBK.Name";
                        qryFbKreditor.Fill((int)ZahlungsArt.OrangerEinzahlungsschein, (int)ZahlungsArt.Blau_Orange_ESR_ueber_Bank, "%" + searchParam + "%");
                        break;

                    case BelegTyp.Post:
                        _canReturnUniqueZahlungsWeg = true;
                        qryFbKreditor.SelectStatement += "FZW.ZahlungsArtCode = {0} AND (FZW.PCKontoNr LIKE {1} OR FZW.IBAN = {2}) AND FBK.Aktiv = 1 ORDER BY FBK.Name ";
                        qryFbKreditor.Fill((int)ZahlungsArt.RoterEinzahlungsscheinPost, "%" + searchParam + "%", iban);
                        break;

                    case BelegTyp.Bank:
                        _canReturnUniqueZahlungsWeg = true;
                        qryFbKreditor.SelectStatement += "(FZW.ZahlungsArtCode = {0} OR FZW.ZahlungsArtCode = {1}) AND (FZW.BelegBankKontoNr LIKE {2} OR FZW.IBAN = {3}) AND FBK.Aktiv = 1 ORDER BY FBK.Name ";
                        qryFbKreditor.Fill((int)ZahlungsArt.BankUeberweisung, (int)ZahlungsArt.BankzahlungSchweiz, "%" + searchParam + "%", iban);
                        break;
                }
            }

            grdFbZahlungsweg.DataSource = qryFbZahlungsweg;
            grdFbKreditor.DataSource = qryFbKreditor;

            qryFbKreditor.RefreshDisplay();

            if (qryFbKreditor.Count == 0)
            {
                tabControlSearch.SelectedTabIndex = 2;
                AcceptButton = btnNeuKreditorOk;
                CancelButton = btnNeuKreditorAbbrechen;
                tabControlSearch.TabPages.Remove(tpgListe);
            }
            else
            {
                tabControlSearch.SelectedTabIndex = 0;
                AcceptButton = btnListeOK;
                CancelButton = btnListeAbbruch;
                tabControlSearch.TabPages.Remove(tpgNeuKreditor);
            }
        }

        #endregion

        #endregion
    }
}