using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    public partial class CtlFibuZahlungsWeg : KissComplexControl, IBelegleser
    {
        #region Enumerations

        public enum ControlTyp
        {
            Buchung,
            DauerAuftrag
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly DataSet _dataSet;

        private const ControlTyp TYPCONST = ControlTyp.Buchung;

        #endregion

        #region Private Fields

        private BuchungDTAStatus _buchungStatus = BuchungDTAStatus.Unbekannt;
        private int _buchungZahlungsWegID;
        private DataRow _currentKreditor;
        private DataRow _currentZahlungsweg;
        private SqlQuery _dataSource;
        private DataTable _dtBank;
        private DataTable _dtKreditor;
        private DataTable _dtZahlungsWeg;
        private int _fbBuchungID;
        private int _fbDauerAuftragId;
        private int _fbZahlungsWegID;
        private bool _filling;
        private string _idColumnName = "FbBuchungID";
        private bool _isNewZahlungsWeg;
        private DataRow _neuZahlungsweg;
        private SqlDataAdapter _sdaBank;
        private SqlDataAdapter _sdaKreditor;
        private SqlDataAdapter _sdaZahlungsWeg;
        private string _searchClearingNr = "";
        private string _searchKontoNummer;
        private ControlTyp _typ = ControlTyp.Buchung;
        private ZahlungsArt _zahlungsArtCode;

        #endregion

        #endregion

        #region Constructors

        public CtlFibuZahlungsWeg()
        {
            InitializeComponent();

            editEinzahlungsPLZOrt.EdtKanton.DataMember = string.Empty;
            editEinzahlungsPLZOrt.EdtLand.DataMember = string.Empty;

            _dataSet = new DataSet();
        }

        #endregion

        #region Events

        private event DataColumnChangeEventHandler KreditorTableEventDelegate;

        private event DataColumnChangeEventHandler ZahlungsWegTableEventDelegate;

        #endregion

        #region Properties

        [Browsable(false)]
        public BuchungDTAStatus BuchungStatus
        {
            get { return _buchungStatus; }

            set
            {
                if (value == BuchungDTAStatus.Unbekannt || value == BuchungDTAStatus.Fehlerhaft)
                {
                    _buchungStatus = value;
                    UnlockControl();
                }
                else
                {
                    _buchungStatus = value;
                    LockControl();
                }
            }
        }

        public SqlQuery DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                if (_dataSource != null)
                {
                    if (_dataSource["FbZahlungsWegID"] != DBNull.Value)
                        _buchungZahlungsWegID = Convert.ToInt32(_dataSource["FbZahlungsWegID"]);
                }
            }
        }

        [Browsable(false)]
        public object FbBuchungId
        {
            get
            {
                return _fbBuchungID;
            }
            set
            {
                if (value == DBNull.Value)
                    value = 0;

                if (Convert.ToInt32(value) != _fbBuchungID)
                {
                    if (_isNewZahlungsWeg)
                    {
                        //Reset it here
                        _isNewZahlungsWeg = false;
                    }
                }

                _fbBuchungID = Convert.ToInt32(value);
            }
        }

        [Browsable(false)]
        public object FbDauerAuftragId
        {
            get
            {
                return _fbDauerAuftragId;
            }
            set
            {
                if (value == DBNull.Value)
                    value = 0;

                if (Convert.ToInt32(value) != _fbDauerAuftragId)
                {
                    if (_isNewZahlungsWeg)
                    {
                        //Reset it here
                        _isNewZahlungsWeg = false;
                    }
                }

                _fbDauerAuftragId = Convert.ToInt32(value);
            }
        }

        [Browsable(false)]
        public object FbZahlungsWegId
        {
            get
            {
                if (_fbZahlungsWegID == 0)
                {
                    return DBNull.Value;
                }

                return _fbZahlungsWegID;
            }
            set
            {
                _filling = true;

                if (DBNull.Value == value)
                {
                    value = 0;
                }

                if (Convert.ToInt32(value) == 0 && _isNewZahlungsWeg == false)
                {
                    //Remove DataBinding on all Controls
                    RemoveDataBindings();
                    FillCboZahlungsArtcode(null);
                    ReinitializeControls(true);
                    DisableControl();
                    _fbZahlungsWegID = 0;

                    // if it's a freshly new inserted row, reinitialise datasourse
                    if (((_typ == ControlTyp.Buchung && _fbBuchungID == 0) || (_typ == ControlTyp.DauerAuftrag && _fbDauerAuftragId == 0)) && _dataSource != null)
                    {
                        ReinitializeDataSource(true, true);
                    }
                }

                else
                {
                    if (_isNewZahlungsWeg)
                    {
                        cboZahlungsArt.EditMode = EditModeType.Normal;
                    }
                    else
                    {
                        cboZahlungsArt.EditMode = EditModeType.ReadOnly;
                    }

                    EnableControl();
                    _dataSet.Relations.Clear();
                    _dataSet.EnforceConstraints = false;
                    _fbZahlungsWegID = Convert.ToInt32(value);

                    # region DBAccess

                    //Fill DataSet
                    string sqlZahlungsWeg = @"--SQLCHECK_IGNORE--
                        SELECT * FROM FbZahlungsWeg WHERE FbZahlungsWegId = @FbZahlungsWegID";
                    string sqlKreditor = @"--SQLCHECK_IGNORE--
                        SELECT * FROM FbKreditor WHERE FbKreditorID = @FbKreditorID";
                    string sqlBank = @"--SQLCHECK_IGNORE--
                        SELECT * FROM BaBank WHERE BaBankID = @BaBankID";

                    // Get ZahlungsWeg from DB
                    try
                    {
                        if (_isNewZahlungsWeg == false)
                        {
                            if (_dtZahlungsWeg != null)
                            {
                                _dtZahlungsWeg.Clear();
                            }

                            _sdaZahlungsWeg = new SqlDataAdapter(sqlZahlungsWeg, Session.Connection);
                            _sdaZahlungsWeg.SelectCommand.Parameters.AddWithValue("@FbZahlungsWegID", value);
                            new SqlCommandBuilder(_sdaZahlungsWeg);
                            _sdaZahlungsWeg.Fill(_dataSet, "ZahlungsWeg");

                            _dtZahlungsWeg = _dataSet.Tables["ZahlungsWeg"];
                            //
                            if (ZahlungsWegTableEventDelegate == null)
                            {
                                ZahlungsWegTableEventDelegate = OnColumnChanged;
                                _dtZahlungsWeg.ColumnChanged += ZahlungsWegTableEventDelegate;
                            }

                            // Set current Zahlungsweg for later updating
                            _currentZahlungsweg = _dtZahlungsWeg.Rows[0];
                        }
                        else
                        {
                            _currentZahlungsweg = _neuZahlungsweg;
                        }

                        if (_dtZahlungsWeg.Rows.Count > 0)
                        {
                            if (_dtKreditor != null)
                            {
                                _dtKreditor.Clear();
                            }

                            // Get Kreditor from DB
                            _sdaKreditor = new SqlDataAdapter(sqlKreditor, Session.Connection);
                            _sdaKreditor.SelectCommand.Parameters.AddWithValue("@FbKreditorID", Convert.ToInt32(_currentZahlungsweg["FbKreditorID"]));
                            new SqlCommandBuilder(_sdaKreditor);
                            _sdaKreditor.Fill(_dataSet, "Kreditor");

                            _dtKreditor = _dataSet.Tables["Kreditor"];

                            if (KreditorTableEventDelegate == null)
                            {
                                KreditorTableEventDelegate = OnColumnChanged;
                                _dtKreditor.ColumnChanged += KreditorTableEventDelegate;
                            }

                            _currentKreditor = _dtKreditor.Rows[0];

                            // Create Relationship between Kreditor and ZahlungsWeg
                            DataRelation dr = new DataRelation("KreditorZahlungweg", _dtKreditor.Columns["FbKreditorID"], _dtZahlungsWeg.Columns["FbKreditorID"]);
                            _dataSet.Relations.Add(dr);

                            // Get Bank from DB
                            if (DBNull.Value != _dtZahlungsWeg.Rows[0]["BaBankID"])
                            {
                                if (_dtBank != null)
                                {
                                    _dtBank.Clear();
                                }

                                _sdaBank = new SqlDataAdapter(sqlBank, Session.Connection);
                                _sdaBank.SelectCommand.Parameters.AddWithValue("@BaBankID", Convert.ToInt32(_dtZahlungsWeg.Rows[0]["BaBankID"]));
                                _sdaBank.Fill(_dataSet, "Bank");

                                _dtBank = _dataSet.Tables["Bank"];

                                // Create Relationship between Bank und ZahlungsWeg
                                dr = new DataRelation("BankZahlungweg", _dtBank.Columns["BaBankID"], _dtZahlungsWeg.Columns["BaBankID"]);
                                _dataSet.Relations.Add(dr);

                                // If BankPcKontoNr has been introduced before as searchparam, overwrite existing PCKontoNr
                                if (!string.IsNullOrEmpty(_searchKontoNummer))
                                {
                                    if (FibuUtilities.IsValidPCKontoNr(_searchKontoNummer))
                                    {
                                        _dtBank.Rows[0]["PCKontoNr"] = _searchKontoNummer;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }

                    #endregion

                    //Remove DataBinding on all Controls
                    RemoveDataBindings();

                    if (_dtZahlungsWeg.Rows.Count > 0 && _dataSource.Row != null)
                    {

                        if (_dataSource.Row.RowState == DataRowState.Added)
                        {
                            SetBuchungText();
                            SetAufwandKonto();
                        }

                        if (_typ == ControlTyp.DauerAuftrag || DataSource["ZahlungsArtCode"] == DBNull.Value)
                        {
                            if (_dtZahlungsWeg.Rows[0]["ZahlungsArtCode"] != DBNull.Value)
                            {
                                ZahlungsArtCode =
                                    (ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), _dtZahlungsWeg.Rows[0]["ZahlungsArtCode"].ToString(), true);
                            }
                        }
                        else
                        {
                            ZahlungsArtCode = (ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), DataSource["ZahlungsArtCode"].ToString(), true);
                        }

                        AddDataBindings(cboZahlungsArt, "EditValue", _dataSource, "ZahlungsArtCode", _dtZahlungsWeg);

                        if (dtpValuta.DataBindings.Count == 0 && _typ == ControlTyp.Buchung)
                        {
                            dtpValuta.DataBindings.Add("EditValue", _dataSource, "ValutaDatum");
                            editFrist.DataBindings.Add("EditValue", _dataSource, "ZahlungsFrist");
                        }

                        switch (_zahlungsArtCode)
                        {
                            case ZahlungsArt.OrangerEinzahlungsschein:
                                {
                                    AddDataBindings(btnEditKontoNr, "EditValue", _dataSource, "PCKontoNr", _dtZahlungsWeg);
                                    AddDataBindings(editEinzahlungName, "EditValue", _dataSource, "Name", _dtKreditor);
                                    AddDataBindings(editEinzahlungStrasse, "EditValue", _dataSource, "Strasse", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtPLZ, "EditValue", _dataSource, "PLZ", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtOrt, "EditValue", _dataSource, "Ort", _dtKreditor);
                                    editReferenzNr.DataBindings.Add("EditValue", _dataSource, "ReferenzNummer");
                                    break;
                                }

                            case ZahlungsArt.Blau_Orange_ESR_ueber_Bank:
                                {
                                    if (_isNewZahlungsWeg)
                                        _dtZahlungsWeg.Rows[0]["PCKontoNr"] = _dtBank.Rows[0]["PCKontoNr"];
                                    //Bank Info cannot be updated, no need to databind
                                    AddDataBindings(btnEditKontoNr, "EditValue", _dataSource, "PCKontoNr", _dtZahlungsWeg);
                                    editEinzahlungName.Text = _dtBank.Rows[0]["Name"].ToString();

                                    if (DBNull.Value != _dtBank.Rows[0]["Strasse"])
                                        editEinzahlungStrasse.Text = _dtBank.Rows[0]["Strasse"].ToString();
                                    editEinzahlungsPLZOrt.PLZ = _dtBank.Rows[0]["PLZ"].ToString();
                                    editEinzahlungsPLZOrt.Ort = _dtBank.Rows[0]["Ort"].ToString();

                                    editReferenzNr.DataBindings.Add("EditValue", _dataSource, "ReferenzNummer");

                                    // This infos are not editable from user so they must reflect the latest changes to the kreditor
                                    if (_typ == ControlTyp.Buchung)
                                    {
                                        if (!_dataSource["Name"].Equals(_currentKreditor["Name"]))
                                        {
                                            _dataSource["Name"] = _currentKreditor["Name"];
                                        }

                                        if (!_dataSource["Zusatz"].Equals(_currentKreditor["Zusatz"]))
                                        {
                                            _dataSource["Zusatz"] = _currentKreditor["Zusatz"];
                                        }

                                        if (!_dataSource["Strasse"].Equals(_currentKreditor["Strasse"]))
                                        {
                                            _dataSource["Strasse"] = _currentKreditor["Strasse"];
                                        }

                                        if (!_dataSource["PLZ"].Equals(_currentKreditor["PLZ"]))
                                        {
                                            _dataSource["PLZ"] = _currentKreditor["PLZ"];
                                        }

                                        if (!_dataSource["Ort"].Equals(_currentKreditor["Ort"]))
                                        {
                                            _dataSource["Ort"] = _currentKreditor["Ort"];
                                        }
                                    }

                                    break;
                                }

                            case ZahlungsArt.RoterEinzahlungsscheinPost:
                                {
                                    AddDataBindings(btnEditKontoNr, "EditValue", _dataSource, "PCKontoNr", _dtZahlungsWeg);
                                    AddDataBindings(editBankKontoNrXtra, "EditValue", _dataSource, "IBAN", _dtZahlungsWeg);

                                    AddDataBindings(editEinzahlungName, "EditValue", _dataSource, "Name", _dtKreditor);
                                    AddDataBindings(editEinzahlungStrasse, "EditValue", _dataSource, "Strasse", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtPLZ, "EditValue", _dataSource, "PLZ", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtOrt, "EditValue", _dataSource, "Ort", _dtKreditor);

                                    editZahlungsgrund.DataBindings.Add("EditValue", _dataSource, "Zahlungsgrund");

                                    break;
                                }

                            case ZahlungsArt.BankzahlungSchweiz:
                                {
                                    // Copy PCKontoNr and IBAN by default from BaBank to FbZahlungsWeg for new Zahlungsweg
                                    if (_isNewZahlungsWeg)
                                    {
                                        _dtZahlungsWeg.Rows[0]["PCKontoNr"] = _dtBank.Rows[0]["PCKontoNr"];
                                        _dtZahlungsWeg.Rows[0]["IBAN"] = _dtBank.Rows[0]["IBAN"];
                                    }

                                    AddDataBindings(btnEditKontoNr, "EditValue", _dataSource, "PCKontoNr", _dtZahlungsWeg);
                                    AddDataBindings(editBankKontoNrXtra, "EditValue", _dataSource, "IBAN", _dtZahlungsWeg);

                                    //Bank Info cannot be updated, no need to databind
                                    editEinzahlungName.Text = _dtBank.Rows[0]["Name"].ToString();

                                    if (DBNull.Value != _dtBank.Rows[0]["Strasse"])
                                    {
                                        editEinzahlungStrasse.Text = _dtBank.Rows[0]["Strasse"].ToString();
                                    }

                                    editEinzahlungsPLZOrt.PLZ = _dtBank.Rows[0]["PLZ"].ToString();
                                    editEinzahlungsPLZOrt.Ort = _dtBank.Rows[0]["Ort"].ToString();
                                    editZahlungsgrund.DataBindings.Add("EditValue", _dataSource, "Zahlungsgrund");

                                    // This infos are not editable from user so they must reflect the latest changes to the kreditor
                                    if (_typ == ControlTyp.Buchung)
                                    {
                                        if (!_dataSource["Name"].Equals(_currentKreditor["Name"]))
                                        {
                                            _dataSource["Name"] = _currentKreditor["Name"];
                                        }

                                        if (!_dataSource["Zusatz"].Equals(_currentKreditor["Zusatz"]))
                                        {
                                            _dataSource["Zusatz"] = _currentKreditor["Zusatz"];
                                        }

                                        if (!_dataSource["Strasse"].Equals(_currentKreditor["Strasse"]))
                                        {
                                            _dataSource["Strasse"] = _currentKreditor["Strasse"];
                                        }

                                        if (!_dataSource["PLZ"].Equals(_currentKreditor["PLZ"]))
                                        {
                                            _dataSource["PLZ"] = _currentKreditor["PLZ"];
                                        }

                                        if (!_dataSource["Ort"].Equals(_currentKreditor["Ort"]))
                                        {
                                            _dataSource["Ort"] = _currentKreditor["Ort"];
                                        }
                                    }
                                    break;
                                }

                            case ZahlungsArt.BankUeberweisung:
                                {
                                    AddDataBindings(btnEditKontoNr, "EditValue", _dataSource, "IBAN", _dtZahlungsWeg);
                                    AddDataBindings(editEinzahlungName, "EditValue", _dataSource, "Name", _dtKreditor);
                                    AddDataBindings(editEinzahlungStrasse, "EditValue", _dataSource, "Strasse", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtPLZ, "EditValue", _dataSource, "PLZ", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtOrt, "EditValue", _dataSource, "Ort", _dtKreditor);
                                    editZahlungsgrund.DataBindings.Add("EditValue", _dataSource, "Zahlungsgrund");

                                    SetBankInfos();

                                    break;
                                }

                            case ZahlungsArt.Postmandat:
                                {
                                    AddDataBindings(editEinzahlungName, "EditValue", _dataSource, "Name", _dtKreditor);
                                    AddDataBindings(editEinzahlungStrasse, "EditValue", _dataSource, "Strasse", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtPLZ, "EditValue", _dataSource, "PLZ", _dtKreditor);
                                    AddDataBindings(editEinzahlungsPLZOrt.EdtOrt, "EditValue", _dataSource, "Ort", _dtKreditor);

                                    editZahlungsgrund.DataBindings.Add("EditValue", _dataSource, "Zahlungsgrund");
                                    btnEditKontoNr.Text = "";

                                    break;
                                }
                        }
                    }
                }

                _filling = false;
            }
        }

        [Browsable(true)]
        [DefaultValue(TYPCONST)]
        public ControlTyp Typ
        {
            get
            {
                return _typ;
            }
            set
            {
                _typ = value;
                if (_typ == ControlTyp.Buchung)
                {
                    _idColumnName = "FbBuchungID";
                    panelValuta.Visible = true;
                }
                else
                {
                    _idColumnName = "FbDauerAuftragID";
                    panelValuta.Visible = false;
                }
            }
        }

        [Browsable(false)]
        public ZahlungsArt ZahlungsArtCode
        {
            get { return _zahlungsArtCode; }
            set
            {
                _zahlungsArtCode = (ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), value.ToString(), true);

                // Change design of the control
                // defaults:
                lblBankKontoNrXtra.Text = "Bankkonto Nr";

                switch (_zahlungsArtCode)
                {
                    // ESR ueber PCKonto
                    case ZahlungsArt.OrangerEinzahlungsschein:
                        {
                            lblKontoNr.Text = "Postkonto";
                            // Hide editZugunstenVon informationen
                            btnEditKontoNr.EditMode = EditModeType.Normal;
                            lblInfos.Visible = false;
                            editEinzahlungName.EditMode = EditModeType.Normal;
                            editEinzahlungStrasse.EditMode = EditModeType.Normal;
                            editEinzahlungsPLZOrt.EditMode = EditModeType.Normal;
                            editZugunstenVon.Visible = false;
                            lblReferenzNr.Visible = true;
                            editReferenzNr.Visible = true;
                            lblZahlungsgrund.Visible = false;
                            editZahlungsgrund.Visible = false;
                            lblBankKontoNrXtra.Visible = false;
                            editBankKontoNrXtra.Visible = false;
                            break;
                        }

                    // ESR ueber PCKonto einer Bank
                    case ZahlungsArt.Blau_Orange_ESR_ueber_Bank:
                        {
                            lblKontoNr.Text = "Postkonto der Bank";
                            btnEditKontoNr.EditMode = EditModeType.Normal;
                            lblInfos.Visible = false;
                            editEinzahlungName.EditMode = EditModeType.ReadOnly;
                            editEinzahlungStrasse.EditMode = EditModeType.ReadOnly;
                            editEinzahlungsPLZOrt.EditMode = EditModeType.ReadOnly;
                            editZugunstenVon.Visible = false;
                            lblReferenzNr.Visible = true;
                            editReferenzNr.Visible = true;
                            lblZahlungsgrund.Visible = false;
                            editZahlungsgrund.Visible = false;
                            lblBankKontoNrXtra.Visible = false;
                            editBankKontoNrXtra.Visible = false;
                            break;
                        }

                    // Non-ESR ueber PCKonto
                    case ZahlungsArt.RoterEinzahlungsscheinPost:
                        {
                            // Hide editZugunstenVon informationen
                            lblKontoNr.Text = "Postkonto";
                            btnEditKontoNr.EditMode = EditModeType.Normal;
                            lblInfos.Visible = false;
                            editEinzahlungName.EditMode = EditModeType.Normal;
                            editEinzahlungStrasse.EditMode = EditModeType.Normal;
                            editEinzahlungsPLZOrt.EditMode = EditModeType.Normal;
                            editZugunstenVon.Visible = false;
                            lblReferenzNr.Visible = false;
                            editReferenzNr.Visible = false;
                            lblZahlungsgrund.Visible = true;
                            editZahlungsgrund.Visible = true;
                            lblBankKontoNrXtra.Visible = false;
                            editBankKontoNrXtra.Visible = false;
                            break;
                        }

                    // Non-ESR ueber PCKonto einer Bank
                    case ZahlungsArt.BankzahlungSchweiz:
                        {
                            lblKontoNr.Text = "Postkonto der Bank";
                            lblBankKontoNrXtra.Text = "IBAN";
                            btnEditKontoNr.EditMode = EditModeType.Normal;
                            lblInfos.Visible = false;
                            editEinzahlungName.EditMode = EditModeType.ReadOnly;
                            editEinzahlungStrasse.EditMode = EditModeType.ReadOnly;
                            editEinzahlungsPLZOrt.EditMode = EditModeType.ReadOnly;
                            editBankKontoNrXtra.EditMode = EditModeType.ReadOnly;
                            editZugunstenVon.Visible = false;
                            lblReferenzNr.Visible = false;
                            editReferenzNr.Visible = false;
                            lblZahlungsgrund.Visible = true;
                            editZahlungsgrund.Visible = true;
                            lblBankKontoNrXtra.Visible = true;
                            editBankKontoNrXtra.Visible = true;
                            break;
                        }

                    // Bank Ueberweisung
                    case ZahlungsArt.BankUeberweisung:
                        {
                            lblKontoNr.Text = "Bankkonto";
                            btnEditKontoNr.EditMode = EditModeType.Normal;
                            lblInfos.Visible = true;
                            editEinzahlungName.EditMode = EditModeType.Normal;
                            editEinzahlungStrasse.EditMode = EditModeType.Normal;
                            editEinzahlungsPLZOrt.EditMode = EditModeType.Normal;
                            editZugunstenVon.EditMode = EditModeType.ReadOnly;
                            editZugunstenVon.Visible = true;
                            lblReferenzNr.Visible = false;
                            editReferenzNr.Visible = false;
                            lblZahlungsgrund.Visible = true;
                            editZahlungsgrund.Visible = true;
                            lblBankKontoNrXtra.Visible = false;
                            editBankKontoNrXtra.Visible = false;
                            break;
                        }

                    // Post Mandat
                    case ZahlungsArt.Postmandat:
                        {
                            // Hide editZugunstenVon informationen
                            btnEditKontoNr.EditMode = EditModeType.ReadOnly;

                            //btnEditKontoNr.Width = 50 ;
                            //btnEditKontoNr.Properties.Buttons[0].Visible = true ;
                            lblInfos.Visible = false;
                            editEinzahlungName.EditMode = EditModeType.Normal;
                            editEinzahlungStrasse.EditMode = EditModeType.Normal;
                            editEinzahlungsPLZOrt.EditMode = EditModeType.Normal;
                            editZugunstenVon.Visible = false;
                            lblReferenzNr.Visible = false;
                            editReferenzNr.Visible = false;
                            lblZahlungsgrund.Visible = true;
                            editZahlungsgrund.Visible = true;
                            lblBankKontoNrXtra.Visible = false;
                            editBankKontoNrXtra.Visible = false;
                            break;
                        }
                }
            }
        }

        #endregion

        #region EventHandlers

        private void CtlFibuZahlungsWeg_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            FillCboZahlungsArtcode(null);
        }

        private void btnEditKontoNr_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                _isNewZahlungsWeg = false;
                ReinitializeDataSource(true, true);
                FbZahlungsWegId = 0;
            }
            else
            {
                _searchKontoNummer = ((Control)sender).Text;
                SearchZahlungsWeg(_searchKontoNummer);
            }
        }

        private void btnEditKontoNr_EnterKey(object sender, KeyEventArgs e)
        {
            if (btnEditKontoNr.UserModified)
            {
                _searchKontoNummer = ((Control)sender).Text;
                SearchZahlungsWeg(_searchKontoNummer);
            }
        }

        private void btnEditKontoNr_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                if (ZahlungsArtCode != ZahlungsArt.Postmandat && ZahlungsArtCode != ZahlungsArt.BankUeberweisung && (_isNewZahlungsWeg || _fbZahlungsWegID != 0))
                {
                    // Check if user entered text to search for a Kreditor Name
                    if (!Utils.IsAlpha(btnEditKontoNr.EditValue.ToString()))
                    {
                        btnEditKontoNr.EditValue = Utils.FormatPCKontoNummerToUserFormat(btnEditKontoNr.EditValue.ToString());
                        if (_typ == ControlTyp.Buchung)
                        {
                            _dataSource["PCKontoNr"] = Utils.FormatPCKontoNummerToDBFormat(btnEditKontoNr.EditValue.ToString(), _zahlungsArtCode);
                        }
                    }
                }
            }
            catch (KissInfoException ex)
            {
                KissMsg.ShowInfo(ex.Message);
                btnEditKontoNr.Focus();
            }
        }

        private void btnEditPostKontoNr_Properties_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (ZahlungsArtCode != ZahlungsArt.Postmandat && ZahlungsArtCode != ZahlungsArt.BankUeberweisung)
                {
                    // Check if user entered text to search for a Kreditor Name
                    if (Utils.IsAlpha(e.Value.ToString()) == false)
                    {
                        e.Value = Utils.FormatPCKontoNummerToUserFormat(e.Value.ToString().Replace("*", ""));
                    }
                }
            }

            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void btnEditPostKontoNr_Properties_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (ZahlungsArtCode != ZahlungsArt.Postmandat && ZahlungsArtCode != ZahlungsArt.BankUeberweisung)
                {
                    e.Value = Utils.FormatPCKontoNummerToDBFormat(e.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void cboZahlungsArt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // When adding zahlungsweg to a freshly inserted Buchung or DauerAuftrag, we don't know the id from Buchung or
                // DauerAuftrag at this time
                int tempFbBuchungID = 0;
                int tempFbDauerAuftragID = 0;

                if (_typ == ControlTyp.Buchung)
                {

                    if (_dataSource["FbBuchungID"] != DBNull.Value)
                    {
                        tempFbBuchungID = Convert.ToInt32(_dataSource["FbBuchungID"]);
                    }
                }
                else
                {

                    if (_dataSource["FbDauerAuftragId"] != DBNull.Value)
                    {
                        tempFbDauerAuftragID = Convert.ToInt32(_dataSource["FbDauerAuftragId"]);
                    }
                }

                if ((_isNewZahlungsWeg || _fbZahlungsWegID != 0)
                    && ((_typ == ControlTyp.Buchung && _fbBuchungID == tempFbBuchungID) || (_typ == ControlTyp.DauerAuftrag && _fbDauerAuftragId == tempFbDauerAuftragID))
                    && cboZahlungsArt.EditValue != DBNull.Value && !_filling
                    && _neuZahlungsweg != null)
                {

                    _neuZahlungsweg["ZahlungsArtCode"] = Convert.ToInt32(cboZahlungsArt.EditValue);

                    switch ((ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), cboZahlungsArt.EditValue.ToString(), true))
                    {
                        case ZahlungsArt.Blau_Orange_ESR_ueber_Bank:
                        case ZahlungsArt.BankzahlungSchweiz:
                        case ZahlungsArt.BankUeberweisung:
                            {
                                DlgAuswahlBank dlg = new DlgAuswahlBank();
                                if (dlg.SearchBank(_searchClearingNr, _searchKontoNummer, false))
                                {
                                    _neuZahlungsweg["BaBankID"] = dlg.ResultRow["BaBankID"];
                                }
                                else
                                {
                                    return;
                                }

                                break;
                            }

                        case ZahlungsArt.Postmandat:
                            {
                                btnEditKontoNr.EditMode = EditModeType.ReadOnly;
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }

                    btnEditKontoNr.EditMode = EditModeType.Normal;
                    ReinitializeDataSource(false, false);
                    FbZahlungsWegId = Convert.ToInt32(_neuZahlungsweg["FbZahlungsWegID"]);
                    _dataSource.RefreshDisplay();
                }

            }
            catch (Exception g)
            {
                KissMsg.ShowError("CtlFibuZahlungsWeg", "FehlerZahlungswegSpeichern", "Error beim Zahlungsweg speichern", g);
            }
        }

        private void editReferenzNr_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            e.Handled = true;
            string temp = e.Value.ToString();
            temp = temp.Trim().Replace(" ", "");
            e.Value = temp;
        }

        private void sdaZahlungsWeg_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", e.Command.Connection);
            _fbZahlungsWegID = Convert.ToInt32(cmd.ExecuteScalar());
        }

        #endregion

        #region Methods

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            // if finished reading string, process belegleserstring and reset it
            if (_buchungStatus == BuchungDTAStatus.Unbekannt || _buchungStatus == BuchungDTAStatus.Fehlerhaft)
            {
                if (_dataSource.Count == 0)
                {
                    _dataSource.Insert();
                }

                //If not in insert mode, send warning to user for overwriting current
                //Zahlungsweg, Create new Record in Datasource or Cancel
                else if (_dataSource.Row[_idColumnName] != DBNull.Value && _dataSource["FbZahlungsWegId"] != DBNull.Value)
                {
                    DlgBelegLeser dlg = new DlgBelegLeser();
                    dlg.ShowDialog(this);

                    if (dlg.Result != DlgBelegLeser.Status.Cancel)
                    {
                        if (dlg.Result == DlgBelegLeser.Status.Neu)
                        {
                            _dataSource.Insert();
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                FibuBelegleser belegLeser = new FibuBelegleser(beleg);
                if (!belegLeser.SearchZahlungsWeg())
                {
                    return;
                }

                if (beleg.ReferenzNummer != "")
                {
                    _dataSource.Row["ReferenzNummer"] = beleg.ReferenzNummer;
                }

                if (beleg.Betrag != 0)
                {
                    _dataSource.Row["Betrag"] = beleg.Betrag;
                }

                #region ZahlungsWeg Auswählen oder Erfassen

                // Existing Zahlungsweg choosen
                if (belegLeser.FbZahlungswegID != 0)
                {
                    FbZahlungsWegId = belegLeser.FbZahlungswegID;
                }

                // Existing Kreditor choosen, new zahlungsweg
                else if (belegLeser.FbKreditorID != 0)
                {
                    // Search Kreditor
                    int kreditorId = belegLeser.FbKreditorID;

                    //Check BelegTyp to filter ZahlungsArt
                    ZahlungsArt[] param = new ZahlungsArt[0];
                    if (belegLeser.BelegTyp == BelegTyp.ESR)
                    {
                        // ESR Typ
                        param = new ZahlungsArt[2];
                        param[0] = ZahlungsArt.OrangerEinzahlungsschein;
                        param[1] = ZahlungsArt.Blau_Orange_ESR_ueber_Bank;
                    }
                    else if (belegLeser.BelegTyp == BelegTyp.Post)
                    {
                        // Postkonto Typ
                        param = new ZahlungsArt[2];
                        param[0] = ZahlungsArt.RoterEinzahlungsscheinPost;
                        param[1] = ZahlungsArt.BankzahlungSchweiz;
                    }
                    else if (belegLeser.BelegTyp == BelegTyp.Bank)
                    {
                        param = new ZahlungsArt[2];
                        param[0] = ZahlungsArt.BankzahlungSchweiz;
                        param[1] = ZahlungsArt.BankUeberweisung;
                    }

                    //Create New ZahlungsWeg
                    FillCboZahlungsArtcode(param);
                    AddZahlungsWeg(kreditorId, beleg.KontoNummer, beleg.BelegTyp, beleg.ClearingNummer);
                }

                #endregion
            }
        }

        /// <summary>
        /// Lock btnEditKontoNr + All Other Controls
        /// </summary>
        public void LockControl()
        {
            btnEditKontoNr.EditMode = EditModeType.ReadOnly;
            btnEditKontoNr.Properties.Buttons[0].Visible = false;
            btnEditKontoNr.Properties.Buttons[1].Visible = false;
            DisableControl();
        }

        public void Save()
        {
            _dtKreditor.Rows[0].EndEdit();
            _dtZahlungsWeg.Rows[0].EndEdit();
            _sdaKreditor.Update(_dtKreditor);
            _sdaZahlungsWeg.Update(_dtZahlungsWeg);
        }

        /// <summary>
        /// Used to save FbBuchung/FbDauerAuftrag Zahlungsweg Informationen on FbZahlungsweg("Template")
        /// </summary>
        public void SaveNewKreditorAndZahlungsWeg()
        {
            bool saveZahlungsWeg = false;
            bool saveKreditor = false;
            bool askForSaveZahlungsWeg = false;
            bool askForSaveKreditor = false;
            string askForSaveZahlungsWegQuestion = "Folgende Felder wurden im Zahlungsweg verändert : " + Environment.NewLine;
            string askForSaveKreditorQuestion = "Folgende Felder wurden im Kreditor verändert : " + Environment.NewLine;

            #region CheckBuchungInformationen
            // 1 First Check Buchung Informationen

            // 1.1	Check Valuta Datum

            if (_currentZahlungsweg == null)
            {
                return;
            }

            if (_currentKreditor == null)
            {
                return;
            }

            _currentZahlungsweg.EndEdit();
            _currentKreditor.EndEdit();

            editEinzahlungName.Focus();

            if (!_filling && (_buchungStatus == BuchungDTAStatus.Unbekannt || _buchungStatus == BuchungDTAStatus.Fehlerhaft || _typ == ControlTyp.DauerAuftrag) && (_fbZahlungsWegID != 0 || _isNewZahlungsWeg))
            {
                #region Check Zahlungsweg + Kreditor Informationen
                // 1.4 Check ZahlungsWeg With Info from FbBuchung

                string zahlungsWegError;

                if (_typ == ControlTyp.Buchung)
                {
                    zahlungsWegError = FibuUtilities.CheckZahlungsWeg(_dataSource.Row, _currentZahlungsweg["BaBankID"]);
                }
                else
                {
                    zahlungsWegError = FibuUtilities.CheckZahlungsWeg(_currentZahlungsweg, _currentKreditor, _currentZahlungsweg["BaBankID"]);
                }

                if (zahlungsWegError != "")
                {
                    KissMsg.ShowInfo(zahlungsWegError);
                    btnEditKontoNr.Focus();
                    throw new KissCancelException();
                }

                #endregion

                // Check only Valutadatum for new Buchung
                if (_typ == ControlTyp.Buchung && _dataSource.Row.RowState == DataRowState.Added)
                {
                    if (_dataSource["ValutaDatum"] == DBNull.Value)
                    {
                        _dataSource["ValutaDatum"] = _dataSource["BuchungsDatum"];
                    }

                    DateTime dt = (DateTime)_dataSource["ValutaDatum"];

                    while (dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dt = dt.AddDays(1);
                    }

                    _dataSource["ValutaDatum"] = dt;
                }

                # region Referenz Nummer Check// 1.2	Check Referenz Nummer

                if (ZahlungsArtCode == ZahlungsArt.OrangerEinzahlungsschein || ZahlungsArtCode == ZahlungsArt.Blau_Orange_ESR_ueber_Bank)
                {
                    string testText = editReferenzNr.Text.Trim().Replace(" ", "");

                    string pcKontoNr = "";

                    if (_typ == ControlTyp.Buchung)
                    {
                        if (_dataSource["PCKontoNr"] != DBNull.Value)
                        {
                            pcKontoNr = _dataSource["PCKontoNr"].ToString();
                        }
                    }
                    else if (_typ == ControlTyp.DauerAuftrag)
                    {
                        if (_currentZahlungsweg["PCKontoNr"] != DBNull.Value)
                        {
                            pcKontoNr = _currentZahlungsweg["PCKontoNr"].ToString();
                        }
                    }

                    // Speziell Fall (ESR 5 Positionen)
                    if (pcKontoNr.Length == 5)
                    {
                        if (testText.Length != 15)
                        {
                            KissMsg.ShowInfo("CtlFibuZahlungsWeg", "RefNrZuKurz", "Referenz Nummer muss 15 Positionen lang sein");
                            editReferenzNr.Focus();
                            throw new KissCancelException();
                        }
                    }

                    // Standart 9 Positionen ESR Teilnehmer
                    else
                    {
                        if (testText.Length != 27 && testText.Length != 16)
                        {
                            KissMsg.ShowInfo("CtlFibuZahlungsWeg", "RefNrNichtOK", "Referenz Nummer muss 16 oder 27 Positionen sein");
                            editReferenzNr.Focus();
                            throw new KissCancelException();
                        }

                        if (!Utils.CheckMod10Nummer(testText))
                        {
                            KissMsg.ShowInfo("CtlFibuZahlungsWeg", "RefNrFalsch", "Referenz Nummer falsch");
                            editReferenzNr.Focus();
                            throw new KissCancelException();
                        }
                    }
                }

                #endregion
            }

            #endregion

            #region update Zahlungsweg + Kreditor
            // 2 Then Update Zahlungweg and Kreditor with user modified Data for new or modified Zahlungsweg
            if ((_fbZahlungsWegID != 0 || _isNewZahlungsWeg) && (_buchungStatus == BuchungDTAStatus.Unbekannt || _buchungStatus == BuchungDTAStatus.Fehlerhaft) && _typ == ControlTyp.Buchung)
            {
                // 2.1 Check If ZahlungsWeg Information changed in FbBuchung for existing ZahlungsWeg
                if (!_isNewZahlungsWeg)
                {
                    if (!_currentZahlungsweg["PCKontoNr"].Equals(_dataSource["PCKontoNr"]) && (!_dataSource.Row.HasVersion(DataRowVersion.Original) || !_dataSource.Row["PCKontoNr", DataRowVersion.Original].Equals(_dataSource.Row["PCKontoNr", DataRowVersion.Current])))
                    {
                        askForSaveZahlungsWegQuestion += "- Postkonto Nummer " + Environment.NewLine + "(Zahlungsweg : " +
                                                         Utils.FormatPCKontoNummerToUserFormat(_currentZahlungsweg["PCKontoNr"].ToString()) +
                                                         " / Buchung : " + Utils.FormatPCKontoNummerToUserFormat(_dataSource["PCKontoNr"].ToString()) +
                                                         ")" + Environment.NewLine;
                        askForSaveZahlungsWeg = true;
                    }

                    if (!_currentZahlungsweg["IBAN"].Equals(_dataSource["IBAN"]) && (!_dataSource.Row.HasVersion(DataRowVersion.Original) || !_dataSource.Row["IBAN", DataRowVersion.Original].Equals(_dataSource.Row["IBAN", DataRowVersion.Current])))
                    {
                        askForSaveZahlungsWegQuestion += "- IBAN " + Environment.NewLine + "(Zahlungsweg : " +
                                                         _currentZahlungsweg["IBAN"] + " / Buchung : " + _dataSource["IBAN"] + ")" +
                                                         Environment.NewLine;
                        askForSaveZahlungsWeg = true;
                    }

                    if (!_currentZahlungsweg["ZahlungsArtCode"].Equals(_dataSource["ZahlungsArtCode"]) && (!_dataSource.Row.HasVersion(DataRowVersion.Original) || !_dataSource.Row["ZahlungsArtCode", DataRowVersion.Original].Equals(_dataSource.Row["ZahlungsArtCode", DataRowVersion.Current])))
                    {
                        askForSaveZahlungsWegQuestion += "- Zahlungsart " + Environment.NewLine + "(Zahlungsweg : " +
                                                         _currentZahlungsweg["ZahlungsArtCode"] + " / Buchung : " + _dataSource["ZahlungsArtCode"] +
                                                         ")" + Environment.NewLine;
                        askForSaveZahlungsWeg = true;
                    }

                    if (!_currentZahlungsweg["ZahlungsFrist"].Equals(_dataSource["ZahlungsFrist"]) && (!_dataSource.Row.HasVersion(DataRowVersion.Original) || !_dataSource.Row["ZahlungsFrist", DataRowVersion.Original].Equals(_dataSource.Row["ZahlungsFrist", DataRowVersion.Current])))
                    {
                        askForSaveZahlungsWegQuestion += "- Zahlungsfrist " + Environment.NewLine + "(Zahlungsweg : " +
                                                         _currentZahlungsweg["ZahlungsFrist"] + " / Buchung : " + _dataSource["ZahlungsFrist"] + ")" +
                                                         Environment.NewLine;
                        askForSaveZahlungsWeg = true;
                    }

                    // Ask user if he wants to modify FbZahlungsWeg to reflect changes made on FbBuchung for existing zahlungsWeg
                    if (askForSaveZahlungsWeg)
                    {
                        askForSaveZahlungsWegQuestion += "Möchten Sie die Änderungen auf den Zahlungswegstamm übernehmen ?";
                        if (KissMsg.ShowQuestion(null, null, askForSaveZahlungsWegQuestion, 600, 0))
                        {
                            saveZahlungsWeg = true;
                        }
                    }
                }

                // It's a new Zahlungsweg, save Zahlungweg Information from FbBuchung implicitly
                else
                {
                    saveZahlungsWeg = true;
                }

                #region Sychronize Kreditor

                try
                {
                    // Records in Kiss 2.0 had empty ("") strings on DB, replace them by DBNull.Value
                    if (_currentKreditor["Strasse"].ToString() == "")
                    {
                        _currentKreditor["Strasse"] = DBNull.Value;
                    }

                    // 2.2 Then Synchronise Kreditor Informationen für Zahlungen die nicht üeber Bank gehen die Kreditor Informationen prüfen
                    if (ZahlungsArtCode != ZahlungsArt.BankUeberweisung && ZahlungsArtCode != ZahlungsArt.Blau_Orange_ESR_ueber_Bank && _zahlungsArtCode != ZahlungsArt.BankzahlungSchweiz)
                    {
                        if (!_currentKreditor["Name"].Equals(_dataSource["Name"]) &&
                            (!_dataSource.Row.HasVersion(DataRowVersion.Original) ||
                             !_dataSource.Row["Name", DataRowVersion.Original].Equals(_dataSource.Row["Name", DataRowVersion.Current])))
                        {
                            askForSaveKreditorQuestion += "- Name " + Environment.NewLine + "(Kreditor : " + _currentKreditor["Name"] +
                                                          " / Buchung : " + _dataSource["Name"] + ")" + Environment.NewLine;
                            askForSaveKreditor = true;
                        }

                        if (!_currentKreditor["Strasse"].Equals(_dataSource["Strasse"]) &&
                            (!_dataSource.Row.HasVersion(DataRowVersion.Original) ||
                             !_dataSource.Row["Strasse", DataRowVersion.Original].Equals(_dataSource.Row["Strasse", DataRowVersion.Current])))
                        {
                            askForSaveKreditorQuestion += "- Strasse " + Environment.NewLine + "(Kreditor : " + _currentKreditor["Strasse"] +
                                                          " / Buchung : " + _dataSource["Strasse"] + ")" + Environment.NewLine;
                            askForSaveKreditor = true;
                        }

                        if (!_currentKreditor["PLZ"].Equals(_dataSource["PLZ"]) &&
                            (!_dataSource.Row.HasVersion(DataRowVersion.Original) ||
                             !_dataSource.Row["PLZ", DataRowVersion.Original].Equals(_dataSource.Row["PLZ", DataRowVersion.Current])))
                        {
                            askForSaveKreditorQuestion += "- PLZ " + Environment.NewLine + "(Kreditor : " + _currentKreditor["PLZ"] + " / Buchung : " +
                                                          _dataSource["PLZ"] + ")" + Environment.NewLine;
                            askForSaveKreditor = true;
                        }

                        if (!_currentKreditor["Ort"].Equals(_dataSource["Ort"]) &&
                            (!_dataSource.Row.HasVersion(DataRowVersion.Original) ||
                             !_dataSource.Row["Ort", DataRowVersion.Original].Equals(_dataSource.Row["Ort", DataRowVersion.Current])))
                        {
                            askForSaveKreditorQuestion += "- Ort " + Environment.NewLine + "(Kreditor : " + _currentKreditor["Ort"] + " / Buchung : " +
                                                          _dataSource["Ort"] + ")" + Environment.NewLine;
                            askForSaveKreditor = true;
                        }

                        // Ask user if he wants to modify FbKreditor to reflect changes made on FbBuchung
                        if (askForSaveKreditor)
                        {
                            askForSaveKreditorQuestion += "Möchten Sie die Änderungen auf den Kreditorenstamm übernehmen ?";
                            if (KissMsg.ShowQuestion(null, null, askForSaveKreditorQuestion, 600, 0))
                            {
                                saveKreditor = true;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    KissMsg.ShowError(e.Message);
                }

                #endregion

                #region saveKreditor

                if (saveKreditor)
                {
                    _currentKreditor["Name"] = _dataSource["Name"];
                    _currentKreditor["Strasse"] = _dataSource["Strasse"];
                    _currentKreditor["PLZ"] = _dataSource["PLZ"];
                    _currentKreditor["Ort"] = _dataSource["Ort"];

                    _sdaKreditor.Update(_dtKreditor);
                }

                #endregion

                # region saveZahlungsweg

                if (saveZahlungsWeg)
                {
                    _currentZahlungsweg["PCKontoNr"] = _dataSource["PCKontoNr"];
                    _currentZahlungsweg["IBAN"] = _dataSource["IBAN"];
                    _currentZahlungsweg["ZahlungsArtCode"] = _dataSource["ZahlungsArtCode"];
                    _currentZahlungsweg["ZahlungsFrist"] = _dataSource["ZahlungsFrist"];

                    // Event Handler Only for inserts because Select @@Identity returns DBNull on update, delete
                    if (_isNewZahlungsWeg)
                    {
                        _sdaZahlungsWeg.RowUpdated += sdaZahlungsWeg_RowUpdated;
                    }

                    try
                    {
                        _sdaZahlungsWeg.Update(_dtZahlungsWeg);
                        _isNewZahlungsWeg = false;
                    }
                    finally
                    {
                        // Remove event handler to retrieve FbZahlungsWegId from freshly inserted Row on DB
                        _sdaZahlungsWeg.RowUpdated -= sdaZahlungsWeg_RowUpdated;
                    }
                }

                #endregion
            }
            else if (_typ == ControlTyp.DauerAuftrag)
            {
                try
                {
                    // Check if a Zahlungsweg has been created or selected (KreditorId must be filled in both case)
                    if (_currentZahlungsweg["FbKreditorID"] != DBNull.Value)
                    {
                        if (_isNewZahlungsWeg)
                        {
                            _sdaZahlungsWeg.RowUpdated += sdaZahlungsWeg_RowUpdated;
                        }

                        _dtZahlungsWeg.Rows[0].EndEdit();
                        _sdaZahlungsWeg.Update(_dtZahlungsWeg);
                        _isNewZahlungsWeg = false;
                    }
                }
                finally
                {
                    // Remove event handler to retrieve FbZahlungsWegId from freshly inserted Row on DB
                    _sdaZahlungsWeg.RowUpdated -= sdaZahlungsWeg_RowUpdated;
                }

                if (_currentZahlungsweg["FbKreditorID"] != DBNull.Value)
                {
                    _dtKreditor.Rows[0].EndEdit();
                    _sdaKreditor.Update(_dtKreditor);
                }
            }

            if (_fbZahlungsWegID == 0)
            {
                _dataSource["FbZahlungsWegId"] = DBNull.Value;
                ReinitializeDataSource(true, true);
            }
            else
            {
                _dataSource["FbZahlungsWegId"] = _fbZahlungsWegID;
            }

            #endregion
        }

        public void UnlockControl()
        {
            btnEditKontoNr.EditMode = EditModeType.Normal;
            btnEditKontoNr.Properties.Buttons[0].Visible = true;
            btnEditKontoNr.Properties.Buttons[1].Visible = true;

            if (_fbZahlungsWegID != 0)
            {
                EnableControl();
                ZahlungsArtCode = _zahlungsArtCode;
            }
        }

        #endregion

        #region Private Methods

        private void AddDataBindings(Control control, string property, SqlQuery datasource, string columnName, DataTable dt, string dtColumnName = null)
        {
            if (control.DataBindings.Count > 0)
            {
                control.DataBindings.Clear();
            }

            if (dtColumnName == null)
            {
                dtColumnName = columnName;
            }

            if (_typ == ControlTyp.Buchung)
            {
                // If new ZahlungsWeg, copy information from ZahlungsWeg to FbBuchung datasource before binding
                if (_dataSource["FbZahlungswegID"] == DBNull.Value || Convert.ToInt32(_dataSource["FbZahlungswegID"]) != _fbZahlungsWegID || _isNewZahlungsWeg)
                {
                    // Used if user already typed a PostKontoNr for searching and he doesn't choose one from a bank, then keep it as default value
                    if (control.Name == "btnEditKontoNr" && (_zahlungsArtCode == ZahlungsArt.OrangerEinzahlungsschein || _zahlungsArtCode == ZahlungsArt.RoterEinzahlungsscheinPost) && _isNewZahlungsWeg && FibuUtilities.IsValidPCKontoNr(_searchKontoNummer))
                    {
                        _dataSource[columnName] = _searchKontoNummer;
                    }
                    else
                    {
                        _dataSource[columnName] = dt.Rows[0][dtColumnName];
                    }
                }

                control.DataBindings.Add(property, datasource, columnName);
            }
            else
            {
                control.DataBindings.Add(property, dt, dtColumnName);
            }
        }

        private void AddZahlungsWeg(int kreditorId, string kontoNr, BelegTyp typ = BelegTyp.Unbekannt, string clearingNr = "")
        {
            _sdaZahlungsWeg = new SqlDataAdapter("Select * from FbZahlungsWeg", Session.Connection);
            new SqlCommandBuilder(_sdaZahlungsWeg);

            // keep search parameter if bank pc konto nr entered
            try
            {
                Utils.FormatPCKontoNummerToDBFormat(_searchKontoNummer);
            }
            catch
            {
                _searchKontoNummer = "";
                btnEditKontoNr.EditValue = DBNull.Value;
            }

            if (_dtZahlungsWeg != null)
            {
                ReinitializeControls(false);
                ReinitializeDataSource(false, false);
                _dtZahlungsWeg.Clear();
            }
            else
            {
                _dtZahlungsWeg = new DataTable("ZahlungsWeg");
                _dataSet.Tables.Add(_dtZahlungsWeg);
            }

            // Get Metadata to be able to add new Datarow
            _dtZahlungsWeg = _sdaZahlungsWeg.FillSchema(_dtZahlungsWeg, SchemaType.Source);
            //dtZahlungsWeg.Columns["FbZahlungsWegId"].ReadOnly = false ;
            if (_dtZahlungsWeg.Rows.Count > 0)
            {
                _dtZahlungsWeg.Clear();
            }

            _neuZahlungsweg = _dtZahlungsWeg.NewRow();
            _neuZahlungsweg["FbKreditorID"] = kreditorId;
            _neuZahlungsweg["IsActive"] = true;

            // Case When Coming From BelegLeser (Save KontoNr for later Bank Search)
            if (kontoNr != "")
            {
                _searchKontoNummer = kontoNr;
            }

            if (typ != BelegTyp.Bank)
            {
                if (kontoNr != "")
                {
                    _neuZahlungsweg["PCKontoNr"] = kontoNr;
                }

                _searchClearingNr = "";
            }
            else
            {
                _neuZahlungsweg["BankKontoNr"] = kontoNr;

                // copy konto nr as it is on beleg for future search
                _neuZahlungsweg["BelegBankKontoNr"] = kontoNr;

                _searchClearingNr = clearingNr;
            }

            _dtZahlungsWeg.Rows.Add(_neuZahlungsweg);
            _currentZahlungsweg = _neuZahlungsweg;

            DisableControl();

            btnEditKontoNr.EditMode = EditModeType.ReadOnly;
            cboZahlungsArt.EditMode = EditModeType.Normal;
            cboZahlungsArt.Focus();
            _isNewZahlungsWeg = true;
        }

        /// <summary>
        /// All Controls are set to ReadOnly, only btnEditKontoNr stays enabled
        /// </summary>
        private void DisableControl()
        {
            editBankKontoNrXtra.EditMode = EditModeType.ReadOnly;
            editZahlungsgrund.EditMode = EditModeType.ReadOnly;
            editReferenzNr.EditMode = EditModeType.ReadOnly;
            editFrist.EditMode = EditModeType.ReadOnly;
            dtpValuta.EditMode = EditModeType.ReadOnly;
            cboZahlungsArt.EditMode = EditModeType.ReadOnly;
            editEinzahlungName.EditMode = EditModeType.ReadOnly;
            editEinzahlungStrasse.EditMode = EditModeType.ReadOnly;
            editEinzahlungsPLZOrt.EditMode = EditModeType.ReadOnly;
            editZugunstenVon.EditMode = EditModeType.ReadOnly;
        }

        /// <summary>
        /// All controls are set to EditMode = Normal
        /// </summary>
        private void EnableControl()
        {
            editBankKontoNrXtra.EditMode = EditModeType.Normal;
            editZahlungsgrund.EditMode = EditModeType.Normal;
            editReferenzNr.EditMode = EditModeType.Normal;
            editFrist.EditMode = EditModeType.Normal;
            dtpValuta.EditMode = EditModeType.Normal;
            editEinzahlungName.EditMode = EditModeType.Normal;
            editEinzahlungStrasse.EditMode = EditModeType.Normal;
            editEinzahlungsPLZOrt.EditMode = EditModeType.Normal;
            editZugunstenVon.EditMode = EditModeType.Normal;
        }

        private void FillCboZahlungsArtcode(ZahlungsArt[] param)
        {
            string sql = null;

            if (param != null && param.Length > 0)
            {
                sql = " AND Code IN (" + ((int)param[0]).ToString();

                for (int i = 1; i < param.Length; i++)
                {
                    sql += ", " + ((int)param[i]).ToString();
                }

                sql += ")";
            }

            cboZahlungsArt.LoadQuery(DBUtil.GetLOVQuery("FbZahlungsArtCode", false, sql));
        }

        /// <summary>
        /// Called when a Column has changed in DtKreditor or DtZahlungsweg has changed. 
        /// Forces setting rowState from DataSource to "modified", so that Post is started
        /// </summary>
        private void OnColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            _dataSource.RowModified = true;
        }

        private void ReinitializeControls(bool pcKontoNr)
        {
            _filling = true;
            btnEditKontoNr.Properties.Buttons[0].Visible = true;
            btnEditKontoNr.Properties.Buttons[1].Visible = true;
            btnEditKontoNr.EditMode = EditModeType.Normal;
            editZugunstenVon.Visible = false;
            lblInfos.Visible = false;
            lblKontoNr.Text = "KontoNr/Kreditor/IBAN";
            lblBankKontoNrXtra.Visible = false;
            editBankKontoNrXtra.Visible = false;
            editZahlungsgrund.Text = "";
            editReferenzNr.Text = "";
            editEinzahlungName.Text = "";
            editEinzahlungStrasse.Text = "";
            editEinzahlungsPLZOrt.Ort = "";
            editEinzahlungsPLZOrt.PLZ = "";
            editZugunstenVon.Text = "";

            cboZahlungsArt.EditValue = null;
            editFrist.Text = "";
            dtpValuta.Text = "";
            _filling = false;

            if (pcKontoNr)
            {
                btnEditKontoNr.Text = "";
            }
        }

        /// <summary>
        ///  Reinitializes all values from source to DBNull, except ReferenzNummer in some case because it may come from Belegleser and we need to
        ///  keep it until zahlungsweg is saved, in case user changes ZahlungsArt
        /// </summary>
        private void ReinitializeDataSource(bool deleteReferenzNummer, bool deleteIds)
        {
            _filling = true;
            if (_dataSource.Count > 0)
            {
                _dataSource["FbZahlungsWegId"] = DBNull.Value;

                if (_typ == ControlTyp.Buchung)
                {
                    _dataSource["PCKontoNr"] = DBNull.Value;
                    _dataSource["IBAN"] = DBNull.Value;
                    _dataSource["ZahlungsArtCode"] = DBNull.Value;
                    _dataSource["Name"] = DBNull.Value;
                    _dataSource["Strasse"] = DBNull.Value;
                    _dataSource["Plz"] = DBNull.Value;
                    _dataSource["Ort"] = DBNull.Value;
                    _dataSource["ZahlungsFrist"] = DBNull.Value;
                    _dataSource["ValutaDatum"] = DBNull.Value;
                }
                // For DauerAuftrag, controls are directly binded to internal datatables dtKreditor + dtZahlungsweg, so
                // if we make a new zahlungsweg we need to reset values in those datatables to reset editValues from binded
                // controls
                // ID's (ZahlungsWegId, FbKreditorID and BaBankID should be kept)
                else
                {
                    if (_dtZahlungsWeg != null)
                    {
                        foreach (DataColumn col in _dtZahlungsWeg.Columns)
                        {
                            if ((col.ReadOnly == false) && ((col.ColumnName != "FbKreditorID" && col.ColumnName != "ZahlungsArtCode" && col.ColumnName != "BaBankID" && col.ColumnName != "BelegBankKontoNr") || deleteIds))
                            {
                                _dtZahlungsWeg.Rows[0][col.ColumnName] = DBNull.Value;
                            }
                        }
                    }

                    if (_dtKreditor != null)
                    {
                        foreach (DataColumn col in _dtKreditor.Columns)
                        {
                            if ((col.ReadOnly == false) && (col.ColumnName != "FbKreditorID" || deleteIds))
                            {
                                _dtKreditor.Rows[0][col.ColumnName] = DBNull.Value;
                            }
                        }
                    }

                    if (_dtBank != null)
                    {
                        foreach (DataColumn col in _dtBank.Columns)
                        {
                            if (col.ColumnName != "BaBankID" || deleteIds)
                            {
                                _dtBank.Rows[0][col.ColumnName] = DBNull.Value;
                            }
                        }
                    }
                }

                if (deleteReferenzNummer)
                {
                    _dataSource["ReferenzNummer"] = DBNull.Value;
                }

                // Exists on FbBuchung & on FbDauerAuftrag
                _dataSource["Zahlungsgrund"] = DBNull.Value;
            }

            _filling = false;
        }

        private void RemoveDataBindings()
        {
            foreach (Control ctl in Controls)
            {
                RemoveDataBindings(ctl);
            }
        }

        /// <summary>
        /// Recursive Function to remove all DataBindings
        /// </summary>
        /// <param name="ctl">Control</param>
        private void RemoveDataBindings(Control ctl)
        {
            if (ctl.DataBindings.Count > 0)
            {
                ctl.DataBindings.Clear();
            }

            if (ctl.Controls.Count > 0)
            {
                foreach (Control subC in ctl.Controls)
                {
                    RemoveDataBindings(subC);
                }
            }
        }

        private void SearchZahlungsWeg(string param)
        {
            DlgAuswahlFbZahlungsweg dlg = new DlgAuswahlFbZahlungsweg(param);

            try
            {
                dlg.ShowDialog(this);

                if (dlg.DialogResult == DialogResult.OK)
                {
                    if (dlg.FbZahlungswegID == 0)
                    {
                        btnEditKontoNr.Properties.Buttons[0].Visible = false;
                        if (dlg.FbKreditorID != 0)
                        {
                            AddZahlungsWeg(dlg.FbKreditorID, "");
                        }
                    }
                    else
                    {
                        //erase all informations about ZahlungsWeg on FbBuchung Table
                        ReinitializeDataSource(false, false);

                        // set ZahlungsWeg Informations
                        FbZahlungsWegId = dlg.FbZahlungswegID;

                        SetBuchungText();
                        SetAufwandKonto();

                        cboZahlungsArt.Focus();
                        _dataSource.RefreshDisplay();
                    }
                }
            }
            finally
            {
                dlg.Dispose();
            }
        }

        /// <summary>
        /// Copy AufwandKonto as default Soll-Konto
        /// </summary>
        private void SetAufwandKonto()
        {
            if (!DBUtil.IsEmpty(_dataSource["SollKtoNr"]) ||
                DBUtil.IsEmpty(_currentKreditor["AufwandKonto"]))
            {
                return;
            }

            _dataSource["SollKtoNr"] = _currentKreditor["AufwandKonto"];

            //Typ Buchung: get Kontoname if BuchungsDatum and FbPeriodeID are not null
            if (_typ == ControlTyp.Buchung &&
                !DBUtil.IsEmpty(_dataSource["BuchungsDatum"]) &&
                !DBUtil.IsEmpty(_dataSource["FbPeriodeID"]))
            {
                SqlQuery qry = DBUtil.OpenSQL(
                    "SELECT KontoName " +
                    "FROM   FbKonto " +
                    "WHERE  FbPeriodeID = {0} AND " +
                     "		KontoNr = {1}",
                     _dataSource["FbPeriodeID"],
                     _currentKreditor["AufwandKonto"]);

                if (qry.Count > 0)
                {
                    _dataSource["SollKtoName"] = qry["KontoName"];
                }
            }
        }

        private void SetBankInfos()
        {
            DataRow currentBank = _dtBank.Rows[0];
            string bankInfos = currentBank["Name"].ToString();

            bankInfos += Environment.NewLine + currentBank["ClearingNr"];
            if (currentBank["Strasse"] != DBNull.Value)
            {
                bankInfos += Environment.NewLine;
                bankInfos += currentBank["Strasse"].ToString();
            }

            if (currentBank["PLZ"] != DBNull.Value)
            {
                bankInfos += Environment.NewLine;
                bankInfos += currentBank["PLZ"] + " " + currentBank["Ort"];
            }

            editZugunstenVon.Text = bankInfos;
        }

        /// <summary>
        /// Copy Kreditor Name as default Buchungtext
        /// </summary>
        private void SetBuchungText()
        {
            if (Typ == ControlTyp.Buchung)
            {
                if (_dataSource["Text"] == DBNull.Value)
                {
                    _dataSource["Text"] = DBUtil.GetConfigValue(@"System\Fibu\PraefixBuchungstext", "an ").ToString() +
                                          _currentKreditor["Name"];
                }
            }
        }

        #endregion

        #endregion
    }
}