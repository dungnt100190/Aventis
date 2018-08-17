using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Newod;
using KiSS4.Schnittstellen.Newod.Service;

namespace KiSS4.Basis.BSS
{
    public partial class CtlBaPerson : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "CtlBaPerson";
        private const string RIGHT_FIKTIVE_PERSON_BEARBEITEN = "CtlBaPerson_FiktivePersonBearbeiten";
        private readonly List<string> _newodMessages = new List<string>();

        #endregion

        #region Private Fields

        private int _baPersonID;
        private CtlBaPersonWV _ctlBaPersonWV;
        private int _ftPersonID;
        private bool _userHasSpezialrechtFiktivePersonBearbeiten;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPerson()
        {
            InitializeComponent();
            xTabControl1.SelectedTabIndex = 0;

            _userHasSpezialrechtFiktivePersonBearbeiten = DBUtil.UserHasRight(RIGHT_FIKTIVE_PERSON_BEARBEITEN);
        }

        #endregion

        #region Properties

        public int BaPersonID
        {
            set
            {
                _baPersonID = value;
                qryBaPerson.Fill(value);

                // TODO: Sichtbar nach Berechtigung
                //this.ActivateNewodBinding();

                ctlZahlungsweg.BaPersonID = BaPersonID;
                ctlBaPersonAdresse.BaPersonID = _baPersonID;

                if (_ctlBaPersonWV == null)
                {
                    InitCtlWV();
                }
                else
                {
                    _ctlBaPersonWV.BaPersonID = value;
                }
            }
            get
            {
                return _baPersonID;
            }
        }

        public override KissUserControl DetailControl
        {
            get
            {
                if (xTabControl1.SelectedTab == tabWohnsituation)
                {
                    return ctlBaPersonAdresse;
                }
                if (xTabControl1.SelectedTab == tabZahlungsweg)
                {
                    return ctlZahlungsweg;
                }
                if (xTabControl1.SelectedTab == tabWV)
                {
                    return _ctlBaPersonWV;
                }

                return base.DetailControl;
            }
        }

        public bool IsTopHidden
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        protected virtual void xTabControl1_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            qryBaPerson.Post();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            DlgDemographieH dlg = new DlgDemographieH();
            dlg.Init("", picTitle.Image, BaPersonID, _ftPersonID, false);
            dlg.ShowDialog(Session.MainForm);
        }

        /// <summary>
        /// Button for manual import of newod data for current client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewodImport_Click(object sender, EventArgs e)
        {
            if (qryBaPerson[DBO.BaPerson.BaPersonID] == null)
            {
                return;
            }

            btnNewodImport.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            int baPersonId = Utils.ConvertToInt(qryBaPerson[DBO.BaPerson.BaPersonID]);
            _newodMessages.Clear();
            var serviceBaPerson = new BaPersonService();
            serviceBaPerson.StartKomplettImport(SetNewodMessage, baPersonId);
            KissMsg.ShowInfo(string.Join(Environment.NewLine, _newodMessages.ToArray()));
            btnNewodImport.Enabled = true;
            Cursor.Current = Cursors.Default;
            qryBaPerson.Refresh();
        }

        private void CtlBaPerson_Load(object sender, EventArgs e)
        {
            chkSichtbarSD.Visible = Session.User.IsUserKA;
            chkPersonSichtbarSD.Visible = Session.User.IsUserKA;
            panTop.Visible = !IsTopHidden;

            edtZuzugGde.GetDatum = GetDatumZuzugGde;
            edtZuzugKt.GetDatum = GetDatumZuzugKt;
            edtWegzug.GetDatum = GetDatumWegzug;
        }

        private void edtNewod_Click(object sender, EventArgs e)
        {
            // this event is only allowed if control is editable
            if (edtNewod.EditMode == EditModeType.ReadOnly || !qryBaPerson.CanUpdate)
            {
                // do not allow any changes (see #6682)!
                return;
            }

            // initialize NEWOD Service
            if (edtNewod.Checked)
            {
                if (KissMsg.ShowQuestion(CLASS_NAME, "ConfirmDisconnectNewod", "Soll die Verbindung zu NEWOD getrennt werden?"))
                {
                    try
                    {
                        ClearNewodMapping();
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            else
            {
                edtNewod.Checked = true;

                DlgNewodMapping dlg = new DlgNewodMapping(qryBaPerson[DBO.BaPerson.BaPersonID].ToString());
                dlg.AutoSize = true;

                DialogResult dlgResult = dlg.ShowDialog(this);

                if (dlgResult == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        //refresh data
                        qryBaPerson.Fill(qryBaPerson[DBO.BaPerson.BaPersonID]);
                        ctlBaPersonAdresse.BaPersonID = Convert.ToInt32(qryBaPerson[DBO.BaPerson.BaPersonID]);

                        KissMsg.ShowInfo(CLASS_NAME, "InfoConnectedNewod", "Die Verbindung zu NEWOD wurde hergestellt.");
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
                else if (dlgResult == DialogResult.Cancel)
                {
                    KissMsg.ShowInfo(CLASS_NAME, "InfoCanceledConnectNewod", "Die Verbindung zu NEWOD wurde abgebrochen.");
                    edtNewod.Checked = false;
                }
            }
        }

        private void qryBaPerson_AfterFill(object sender, EventArgs e)
        {
            SetNewodButtonVisibility();
        }

        private void qryBaPerson_AfterPost(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
        }

        private void qryBaPerson_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();
        }

        private void qryBaPerson_BeforePost(object sender, EventArgs e)
        {
            edtWegzug.DoValidate();
            edtUntWohnsitz.DoValidate();
            edtZuzugGde.DoValidate();
            edtZuzugKt.DoValidate();

            DBUtil.NewHistoryVersion();
            DBUtil.CheckNotNullField(edtName, "Name");
            DBUtil.CheckNotNullField(edtVorname, "Vorname");

            if (!edtVersichertennummer.ValidateVersNr(true, false))
            {
                // set focus
                edtVersichertennummer.Focus();

                // cancel, message already shown
                throw new KissCancelException(string.Empty);
            }

            if (!DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.Sterbedatum]) && (DateTime)qryBaPerson[DBO.BaPerson.Sterbedatum] > DateTime.Today)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(CLASS_NAME, "SterbedatumInZukunft", "Das Sterbedatum liegt in der Zukunft!", KissMsgCode.MsgInfo),
                    edtSterbeDatum);
            }

            if (!DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.Geburtsdatum]) && (DateTime)qryBaPerson[DBO.BaPerson.Geburtsdatum] > DateTime.Today)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(CLASS_NAME, "GeburtsdatumInZukunft", "Das Geburtsdatum liegt in der Zukunft!", KissMsgCode.MsgInfo),
                    edtGeburtstag);
            }

            // Adressen
            if (!Utils.isAddressEmpty(qryBaPerson, edtUntWohnsitz.EdtPLZ.DataMember, edtUntWohnsitz.EdtOrt.DataMember, edtUntWohnsitz.EdtKanton.DataMember))
            {
                DBUtil.CheckNotNullField(
                    edtUntWohnsitz.EdtOrt, KissMsg.GetMLMessage(CLASS_NAME, "Unterstuetzungswohnsitz", "Unterstützungswohnsitz - Ort"));
            }

            //InCHSeit
            if (!DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.InCHSeitGeburt]) && (bool)qryBaPerson[DBO.BaPerson.InCHSeitGeburt])
            {
                qryBaPerson[DBO.BaPerson.InCHSeit] = DBNull.Value;
            }

            // Falls kein Schweizer mehr wird Heimatort gelöscht
            if (!DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.NationalitaetCode]) && Convert.ToInt32(qryBaPerson[DBO.BaPerson.NationalitaetCode]) != 147)
            {
                qryBaPerson[DBO.vwPerson.Heimatort] = String.Empty;
            }
        }

        private void xTabControl1_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !OnSaveData();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ADRESSATID":
                case "BAPERSONID":
                    return qryBaPerson[DBO.BaPerson.BaPersonID];
            }

            return base.GetContextValue(fieldName);
        }

        public DateTime? GetDatumWegzug()
        {
            return edtWegzugDatum.EditValue as DateTime?;
        }

        public DateTime? GetDatumZuzugGde()
        {
            return edtZuzugGdeDatum.EditValue as DateTime?;
        }

        public DateTime? GetDatumZuzugKt()
        {
            return edtZuzugKtDatum.EditValue as DateTime?;
        }

        public void Init(string titleName, Image titleImage, int baPersonID, int ftPersonID, bool isFallTraeger)
        {
            //chkSichtbarSD.Visible = Session.User.IsUserKA;
            //chkPersonSichtbarSD.Visible = Session.User.IsUserKA;

            BaPersonID = baPersonID;
            _ftPersonID = ftPersonID;
            picTitle.Image = titleImage;

            xTabControl1.SelectedTabIndex = 0;

            var isFiktivePerson = Utils.ConvertToBool(qryBaPerson["Fiktiv"]);
            if (!_userHasSpezialrechtFiktivePersonBearbeiten)
            {
                if (isFiktivePerson)
                {
                    qryBaPerson.CanUpdate = false;
                    qryBaPerson.CanDelete = false;
                    qryBaPerson.EnableBoundFields();

                    ctlBaPersonAdresse.SetRights(false);
                    ctlZahlungsweg.SetRights(false);
                    _ctlBaPersonWV.SetRights(false);
                }
                else
                {
                    //Benutzer hat Spezialrecht nicht, dann darf er auch keine normale Person als fiktiv markieren (er würde sich sonst "aussperren").
                    edtFiktiv.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            var resultBase = base.ReceiveMessage(parameters);

            var result = BaUtils.ReceiveMessageBaPerson(parameters, xTabControl1, tabWohnsituation, ctlBaPersonAdresse);

            return resultBase && result;
        }

        #endregion

        #region Private Methods

        private void ClearNewodMapping()
        {
            Session.BeginTransaction();

            try
            {
                int baPersonID = Utils.ConvertToInt(qryBaPerson["BaPersonID"]);
                int newodPersonID = Utils.ConvertToInt(qryBaPerson["NewodPersonID"]);

                NewodUtils.ClearNewodMapping(baPersonID, newodPersonID);

                Session.Commit();
                edtNewod.Checked = false;

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, 3, LogLevel.INFO, "Auflösen", string.Format("Verbindung mit NEWODID: {0} aufgelöst", qryBaPerson["NewodPersonID"]), "BaPerson", Convert.ToInt32(qryBaPerson["BaPersonID"].ToString()));

                KissMsg.ShowInfo(CLASS_NAME, "InfoDisconnectNewod", "Die Verbindung zu NEWOD wurde gelöst.");
            }
            catch (Exception ex)
            {
                Session.Rollback();
                edtNewod.Checked = true;

                KissMsg.ShowError(CLASS_NAME, "ErrorClearNewodBinding", "Die Verbindung zu NEWOD konnte nicht gelöst werden.", ex);
            }
        }

        private void InitCtlWV()
        {
            _ctlBaPersonWV = new CtlBaPersonWV();
            _ctlBaPersonWV.BaPersonID = BaPersonID;
            _ctlBaPersonWV.Dock = DockStyle.Fill;
            tabWV.Controls.Add(_ctlBaPersonWV);
            _ctlBaPersonWV.BringToFront();
        }

        private void SetNewodButtonVisibility()
        {
            if (Session.User.IsUserBIAGAdmin &&
                !DBUtil.IsEmpty(qryBaPerson["NewodMapping"]) &&
                (bool)qryBaPerson["NewodMapping"])
            {
                btnNewodImport.Visible = true;
            }
            else
            {
                btnNewodImport.Visible = false;
            }
        }

        /// <summary>
        /// Is Added to the delegate of BaPersonService
        /// Adds each message to internal newomdMessage list
        /// </summary>
        /// <param name="message">Newod message</param>
        private void SetNewodMessage(string message)
        {
            _newodMessages.Add(message);
        }

        #endregion

        #endregion
    }
}