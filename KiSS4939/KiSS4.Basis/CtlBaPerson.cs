using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    public partial class CtlBaPerson : KissUserControl
    {
        #region Fields

        #region Public Fields

        public CtlBaPersonWV ctlBaPersonWV;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "CtlBaPerson";

        #endregion

        #region Private Fields

        private int _baPersonID;
        private int _ftPersonID;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPerson()
        {
            InitializeComponent();
            xTabControl1.SelectedTabIndex = 0;
        }

        #endregion

        #region Properties

        public int BaPersonID
        {
            set
            {
                _baPersonID = value;
                qryBaPerson.Fill(value);
                DisplayWohnsituation();
                ctlZahlungsweg.BaPersonID = BaPersonID;
                ctlBaPersonAdresse.BaPersonID = _baPersonID;

                if (ctlBaPersonWV == null)
                {
                    InitCtlWV();
                }
                else
                {
                    ctlBaPersonWV.BaPersonID = value;
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
                    return ctlBaPersonWV;
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

            if (qryBaPerson.Count > 0)
            {
                if (xTabControl1.SelectedTabIndex == 1)
                {
                    DisplayWohnsituation();
                }
            }
        }

        protected void xTabControl1_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !OnSaveData();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            DlgDemographieH dlg = new DlgDemographieH();
            dlg.Init("", picTitle.Image, BaPersonID, _ftPersonID, false);
            dlg.ShowDialog(Session.MainForm);
        }

        private void CtlBaPerson_Load(object sender, EventArgs e)
        {
            if (DesignerMode || Session.User == null)
            {
                return;
            }

            chkSichtbarSD.Visible = Session.User.IsUserKA;
            chkPersonSichtbarSD.Visible = Session.User.IsUserKA;
            panTop.Visible = !IsTopHidden;

            edtZuzugGde.GetDatum = GetDatumZuzugGemeinde;
            edtZuzugKt.GetDatum = GetDatumZuzugKt;
            edtWegzug.GetDatum = GetDatumWegzug;
        }

        private void qryAufenthalt_AfterInsert(object sender, EventArgs e)
        {
            qryAufenthalt[DBO.BaAdresse.AdresseCode] = 3;
            qryAufenthalt[DBO.BaAdresse.BaPersonID] = qryBaPerson[DBO.BaPerson.BaPersonID];
        }

        private void qryAufenthalt_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryBaPerson.RowModified = true;
        }

        private void qryBaPerson_AfterPost(object sender, EventArgs e)
        {
            if (!qryWohnsitz.Post())
            {
                throw new KissCancelException();
            }

            if (!qryAufenthalt.Post())
            {
                throw new KissCancelException();
            }

            if (xTabControl1.SelectedTabIndex == 1)
            {
                DisplayWohnsituation();
            }

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
            edtZuzugKt.DoValidate();
            edtZuzugGde.DoValidate();

            DBUtil.NewHistoryVersion();
            DBUtil.CheckNotNullField(edtName, KissMsg.GetMLMessage(CLASS_NAME, "FeldName", "Name"));
            DBUtil.CheckNotNullField(edtVorname, KissMsg.GetMLMessage(CLASS_NAME, "FeldVorname", "Vorname"));

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
                    edtUntWohnsitz.EdtOrt, KissMsg.GetMLMessage(CLASS_NAME, "Unterstuetzungswohnsitz", "Unterstützungswohnsitz - Ort", KissMsgCode.MsgInfo));
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

        private void qryWohnsitz_AfterInsert(object sender, EventArgs e)
        {
            qryWohnsitz[DBO.BaAdresse.AdresseCode] = 1;
            qryWohnsitz[DBO.BaAdresse.BaPersonID] = qryBaPerson[DBO.BaPerson.BaPersonID];
        }

        private void qryWohnsitz_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryBaPerson.RowModified = true;
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

        public DateTime? GetDatumZuzugGemeinde()
        {
            return edtZuzugGdeDatum.EditValue as DateTime?;
        }

        public DateTime? GetDatumZuzugKt()
        {
            return edtZuzugKtDatum.EditValue as DateTime?;
        }

        public void Init(string titleName, Image titleImage, int baPersonID, int ftPersonID, bool isFallTraeger)
        {
            BaPersonID = baPersonID;
            _ftPersonID = ftPersonID;
            picTitle.Image = titleImage;

            xTabControl1.SelectedTabIndex = 0;
        }

        /// <summary>
        /// Formulardaten werden gespeichert.
        /// </summary>
        /// <returns></returns>
        public override bool OnSaveData()
        {
            if (!ActiveSQLQuery.Post())
            {
                //In case of validation and optimistic locking
                return false;
            }
            return base.OnSaveData();
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            var resultBase = base.ReceiveMessage(parameters);

            var result = BaUtils.ReceiveMessageBaPerson(parameters, xTabControl1, tabWohnsituation, ctlBaPersonAdresse);

            return resultBase && result;
        }

        #endregion

        #region Internal Methods

        protected internal void DisplayWohnsituation()
        {
            //Wohnsitz
            qryWohnsitz.Fill(qryBaPerson[DBO.BaPerson.BaPersonID]);
            //if (qryBaPerson.CanUpdate && qryWohnsitz.Count == 0) qryWohnsitz.Insert();

            //Aufenthaltsort
            qryAufenthalt.Fill(qryBaPerson[DBO.BaPerson.BaPersonID]);
            //if (qryBaPerson.CanUpdate && qryAufenthalt.Count == 0) qryAufenthalt.Insert();
        }

        #endregion

        #region Private Methods

        private void InitCtlWV()
        {
            ctlBaPersonWV = new CtlBaPersonWV();
            ctlBaPersonWV.BaPersonID = BaPersonID;
            ctlBaPersonWV.Dock = DockStyle.Fill;
            tabWV.Controls.Add(ctlBaPersonWV);
            ctlBaPersonWV.BringToFront();
        }

        #endregion

        #endregion
    }
}