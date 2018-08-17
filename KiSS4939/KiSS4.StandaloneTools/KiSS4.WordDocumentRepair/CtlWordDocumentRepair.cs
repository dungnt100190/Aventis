using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

using Kiss.Interfaces.DocumentHandling;

using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.WordDocumentRepair
{
    public partial class CtlWordDocumentRepair : Gui.KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string ABBRECHEN = "Abbrechen";
        private const string SQL_DM_EXTENSION = @"
            IF (NOT EXISTS(SELECT TOP 1 1 FROM sys.tables WHERE name = '_tmp_RepairXDocument'))
            BEGIN
                CREATE TABLE _tmp_RepairXDocument
                (
                    DocumentID INT NOT NULL PRIMARY KEY CLUSTERED,
                    Fehler BIT DEFAULT 0,
                    Bemerkung VARCHAR(200)
                );
            END;

            IF (NOT EXISTS(SELECT TOP 1 1 FROM sys.tables WHERE name = '_tmp_RepairXDocTemplate'))
            BEGIN
                CREATE TABLE _tmp_RepairXDocTemplate
                (
                    DocTemplateID INT NOT NULL PRIMARY KEY CLUSTERED,
                    Fehler BIT DEFAULT 0,
                    Bemerkung VARCHAR(200)
                );
            END;";
        private const string START = "Start";

        #endregion

        #region Private Fields

        private bool _cancelled;
        private DokFormat? _dokFormat;
        private DokTyp _dokTyp;
        private bool _loop;
        private Form _mainForm;
        private int _nbrOfDocumentsRepaired;
        private int _nbrOfDocumentsToRepair;
        private int _statsExcelDocumentsFehler;
        private int _statsExcelDocumentsOk;
        private int _statsExcelDocumentsTotal;
        private int _statsExcelTemplatesFehler;
        private int _statsExcelTemplatesOk;
        private int _statsExcelTemplatesTotal;
        private int _statsWordDocumentsFehler;
        private int _statsWordDocumentsOk;
        private int _statsWordDocumentsTotal;
        private int _statsWordTemplatesFehler;
        private int _statsWordTemplatesOk;
        private int _statsWordTemplatesTotal;

        #endregion

        #endregion

        #region Constructors

        public CtlWordDocumentRepair()
        {
            InitializeComponent();
            //default values:
            edtDokTyp.EditValue = DokTyp.Dokument;
        }

        #endregion

        #region Properties

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                if (value)
                {
                    //the control should be enabled
                    //do we have a connection?
                    if (Session.Active)
                    {
                        InitLookupFields();

                        try
                        {
                            EnsureDMExtension();

                            qryDocumentRepair.Fill();
                            qryTemplateRepair.Fill();
                        }
                        catch
                        {
                            KissMsg.ShowError("Damit der Fortschritt der Reparatur abgespeichert werden kann und die Reparatur jederzeit unterbrochen werden kann, muss das Datenmodell erweitert werden. Diese Erweiterung konnte nicht durchgeführt werden. \r\n\r\nBitte wenden Sie sich an den Datenbank-Administrator, so dass er die Datenmodell-Erweiterung ausführen kann. \r\n\r\nDas dazu nötige Script finden Sie unter [Technische Info].", SQL_DM_EXTENSION);
                            return;
                        }

                        ReadStatistics();
                        UpdateStatistics();
                    }
                    else
                    {
                        return;
                    }
                }

                base.Enabled = value;
                btnStartStop.Enabled = value;
                progressBar1.Enabled = value;
                lblStatus.Enabled = value;
                lblTitel.Enabled = value;
                edtLog.Enabled = value;
                lblDokFormat.Enabled = value;
                edtDokFormat.Enabled = value;
                lblDokTyp.Enabled = value;
                edtDokTyp.Enabled = value;
            }
        }

        #endregion

        #region EventHandlers

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == START)
            {
                //starten
                btnStartStop.Text = ABBRECHEN;

                //init progressbar
                progressBar1.Minimum = 0;
                progressBar1.Maximum = _nbrOfDocumentsToRepair + 1;
                progressBar1.Value = _nbrOfDocumentsRepaired;

                _loop = true;
                _cancelled = false;

                var ts = _dokTyp == DokTyp.Dokument
                             ? new ThreadStart(LoadAndRepairDocuments)
                             : new ThreadStart(LoadAndRepairTemplates);

                //Start the Processing in a seperate thread
                Thread t = new Thread(ts);
                t.Start();
            }
            else
            {
                //abbrechen
                _cancelled = true;
                btnStartStop.Enabled = false;
            }
        }

        private void edtDokFormat_EditValueChanged(object sender, EventArgs e)
        {
            _dokFormat = (DokFormat)edtDokFormat.EditValue;
            CalculateNbrOfDocumentsToRepair();
        }

        private void edtDokTyp_EditValueChanged(object sender, EventArgs e)
        {
            _dokTyp = (DokTyp)edtDokTyp.EditValue;
            CalculateNbrOfDocumentsToRepair();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void CalculateNbrOfDocumentsToRepair()
        {
            _nbrOfDocumentsRepaired = 0;

            if (_dokTyp == DokTyp.Dokument)
            {
                //documents
                if (_dokFormat.HasValue)
                {
                    switch (_dokFormat)
                    {
                        case DokFormat.Word:
                            _nbrOfDocumentsToRepair = _statsWordDocumentsTotal -
                                                     (_statsWordDocumentsOk + _statsWordDocumentsFehler);
                            break;
                        case DokFormat.Excel:
                            _nbrOfDocumentsToRepair = _statsExcelDocumentsTotal -
                                                     (_statsExcelDocumentsOk + _statsExcelDocumentsFehler);
                            break;
                    }
                }
                else
                {
                    //alle (word + excel)
                    _nbrOfDocumentsToRepair = _statsWordDocumentsTotal + _statsExcelDocumentsTotal -
                                             (_statsWordDocumentsOk + _statsWordDocumentsFehler +
                                              _statsExcelDocumentsOk + _statsExcelDocumentsFehler);
                }
            }
            else
            {
                //templates
                if (_dokFormat.HasValue)
                {
                    switch (_dokFormat)
                    {
                        case DokFormat.Word:
                            _nbrOfDocumentsToRepair = _statsWordTemplatesTotal -
                                (_statsWordTemplatesOk + _statsWordTemplatesFehler);
                            break;
                        case DokFormat.Excel:
                            _nbrOfDocumentsToRepair = _statsExcelTemplatesTotal -
                                (_statsExcelTemplatesOk + _statsExcelTemplatesFehler);
                            break;
                    }
                }
                else
                {
                    //alle (word + excel)
                    _nbrOfDocumentsToRepair = _statsWordTemplatesTotal + _statsExcelTemplatesTotal -
                        (_statsWordTemplatesOk + _statsWordTemplatesFehler +
                            _statsExcelTemplatesOk + _statsExcelTemplatesFehler);
                }
            }
        }

        private void EnsureDMExtension()
        {
            DBUtil.ExecSQLThrowingException(SQL_DM_EXTENSION);
        }

        private void InitLookupFields()
        {
            //edtDokFormat.LOVName = "DocType";
            //edtDokTyp.LOVName = "DocFormat";

            edtDokFormat.LOVFilterWhereAppend = true;
            edtDokFormat.LOVFilter = "CODE IN (1,2)"; //only 1: Word and 2: Excel are supported
            edtDokFormat.ReadLOV();

            edtDokTyp.ReadLOV();
        }

        private void LoadAndRepairDocuments()
        {
            try
            {
                //make sure, we don't have any KiSSMsg-ShowInfo...
                _mainForm = Session.MainForm;
                Session.MainForm = null;

                while (_loop && !_cancelled)
                {
                    ShowStatus("Lade Dokumente...", _nbrOfDocumentsRepaired);

                    _loop = qryDocument.Fill(_dokFormat.HasValue ? (int)_dokFormat.Value : -1);

                    if (qryDocument.Count == 0)
                        _loop = false;

                    foreach (DataRow row in qryDocument.DataTable.Rows)
                    {
                        if (!_loop || _cancelled)
                            break;

                        ShowStatus(string.Format("Bearbeite Dokument... ({0}/{1})", ++_nbrOfDocumentsRepaired, _nbrOfDocumentsToRepair), _nbrOfDocumentsRepaired);

                        DokFormat? format = null;
                        int documentID = (int)row[DBO.XDocument.DocumentID];

                        try
                        {
                            XDokumentHelper.RepairDocument(documentID, (string)row["FileExtension"], out format);

                            ReportDocumentRepaired(documentID, format, true, null);
                        }
                        catch (Exception ex)
                        {
                            ReportDocumentRepaired(documentID, format, false, ex);
                        }

                        grpStats.Invoke(new MethodInvoker(UpdateStatistics));
                    }
                }

                if (_cancelled)
                    ShowStatus("Abgebrochen...", 0);
                else
                    ShowStatus("", 0);
            }
            finally
            {
                //enable KissMsg.Info... again
                Session.MainForm = _mainForm;

                //Enable the start-button
                ResetStartButton();

                //make sure, there are no processes left in memory
                XDokumentHelper.QuitApplications();
            }
        }

        private void LoadAndRepairTemplates()
        {
            try
            {
                while (_loop && !_cancelled)
                {
                    ShowStatus("Lade Vorlage...", _nbrOfDocumentsRepaired);
                    _loop = qryTemplate.Fill(_dokFormat.HasValue ? (int)_dokFormat.Value : -1);

                    if (qryTemplate.Count == 0)
                        _loop = false;

                    foreach (DataRow row in qryTemplate.DataTable.Rows)
                    {
                        if (!_loop || _cancelled)
                            break;

                        ShowStatus(string.Format("Bearbeite Vorlage... ({0}/{1})", ++_nbrOfDocumentsRepaired, _nbrOfDocumentsToRepair), _nbrOfDocumentsRepaired);

                        DokFormat? format = null;
                        int docTemplateID = (int)row[DBO.XDocTemplate.DocTemplateID];

                        try
                        {
                            XDokumentHelper.RepairTemplate(docTemplateID, (string)row["FileExtension"], out format);

                            ReportTemplateRepaired(docTemplateID, format, true, null);
                        }
                        catch (Exception ex)
                        {
                            ReportTemplateRepaired(docTemplateID, format, false, ex);
                        }

                        grpStats.Invoke(new MethodInvoker(UpdateStatistics));
                    }

                    if (_cancelled)
                        ShowStatus("Abgebrochen...", 0);
                    else
                        ShowStatus("", 0);
                }
            }
            finally
            {
                ResetStartButton();
            }
        }

        private void ReadStatistics()
        {
            qryDocumentCount.Fill();

            //reset values
            _statsExcelDocumentsFehler = 0;
            _statsWordDocumentsFehler = 0;
            _statsExcelDocumentsOk = 0;
            _statsWordDocumentsOk = 0;
            _statsExcelDocumentsTotal = 0;
            _statsWordDocumentsTotal = 0;

            if (!qryDocumentCount.IsEmpty)
            {
                _statsExcelDocumentsFehler = (int)qryDocumentCount["AnzahlExcelFehler"];
                _statsWordDocumentsFehler = (int)qryDocumentCount["AnzahlWordFehler"];
                _statsExcelDocumentsOk = (int)qryDocumentCount["AnzahlExcelOk"];
                _statsWordDocumentsOk = (int)qryDocumentCount["AnzahlWordOk"];
                _statsExcelDocumentsTotal = (int)qryDocumentCount["AnzahlExcelTotal"];
                _statsWordDocumentsTotal = (int)qryDocumentCount["AnzahlWordTotal"];
            }

            qryTemplateCount.Fill();
            //reset values
            _statsExcelTemplatesFehler = 0;
            _statsWordTemplatesFehler = 0;
            _statsExcelTemplatesOk = 0;
            _statsWordTemplatesOk = 0;
            _statsExcelTemplatesTotal = 0;
            _statsWordTemplatesTotal = 0;

            if (!qryTemplateCount.IsEmpty)
            {
                _statsExcelTemplatesFehler = (int)qryTemplateCount["AnzahlExcelFehler"];
                _statsWordTemplatesFehler = (int)qryTemplateCount["AnzahlWordFehler"];
                _statsExcelTemplatesOk = (int)qryTemplateCount["AnzahlExcelOk"];
                _statsWordTemplatesOk = (int)qryTemplateCount["AnzahlWordOk"];
                _statsExcelTemplatesTotal = (int)qryTemplateCount["AnzahlExcelTotal"];
                _statsWordTemplatesTotal = (int)qryTemplateCount["AnzahlWordTotal"];
            }

            CalculateNbrOfDocumentsToRepair();
        }

        private void ReportDocumentRepaired(int documentID, DokFormat? format, bool successful, Exception exception)
        {
            DataRow newRow = qryDocumentRepair.Insert();
            newRow[DBO.XDocument.DocumentID] = documentID;
            if (!successful)
            {
                newRow["Fehler"] = true;
                newRow["Bemerkung"] = exception.Message;
                ShowMessage("Reparatur von Dokument ID: {0} fehlgeschlagen. Fehler: {1}", documentID, exception.Message);

                switch (format ?? DokFormat.Unbekannt)
                {
                    case DokFormat.Word:
                        _statsWordDocumentsFehler++;
                        break;
                    case DokFormat.Excel:
                        _statsExcelDocumentsFehler++;
                        break;
                }
            }
            else
            {
                switch (format ?? DokFormat.Unbekannt)
                {
                    case DokFormat.Word:
                        _statsWordDocumentsOk++;
                        break;
                    case DokFormat.Excel:
                        _statsExcelDocumentsOk++;
                        break;
                }
            }

            qryDocumentRepair.Post();
        }

        private void ReportTemplateRepaired(int docTemplateID, DokFormat? format, bool successful, Exception exception)
        {
            DataRow newRow = qryTemplateRepair.Insert();
            newRow[DBO.XDocTemplate.DocTemplateID] = docTemplateID;
            if (!successful)
            {
                newRow["Fehler"] = true;
                newRow["Bemerkung"] = exception.Message;
                ShowMessage("Reparatur von Vorlage ID: {0} fehlgeschlagen. Fehler: {1}", docTemplateID, exception.Message);

                switch (format ?? DokFormat.Unbekannt)
                {
                    case DokFormat.Word:
                        _statsWordTemplatesFehler++;
                        break;
                    case DokFormat.Excel:
                        _statsExcelTemplatesFehler++;
                        break;
                }
            }
            else
            {
                switch (format ?? DokFormat.Unbekannt)
                {
                    case DokFormat.Word:
                        _statsWordTemplatesOk++;
                        break;
                    case DokFormat.Excel:
                        _statsExcelTemplatesOk++;
                        break;
                }
            }

            qryTemplateRepair.Post();
        }

        private void ResetStartButton()
        {
            if (btnStartStop.InvokeRequired)
            {
                btnStartStop.Invoke(new MethodInvoker(() =>
                {
                    btnStartStop.Text = START;
                    btnStartStop.Enabled = true;
                }));
            }
            else
            {
                btnStartStop.Text = START;
                btnStartStop.Enabled = true;
            }
        }

        private void ShowMessage(string message, params object[] parameters)
        {
            if (edtLog.InvokeRequired)
            {
                edtLog.Invoke(new MethodInvoker(() =>
                    {
                        edtLog.Text = edtLog.Text + Environment.NewLine + string.Format(message, parameters);
                    }));
            }
            else
            {
                edtLog.Text = edtLog.Text + Environment.NewLine + string.Format(message, parameters);
            }
        }

        private void ShowStatus(string status, int progressValue)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(() =>
                    {
                        lblStatus.Text = status;
                        progressBar1.Value = progressValue;
                    }));
            }
            else
            {
                lblStatus.Text = status;
                progressBar1.Value = progressValue;
            }
        }

        private void UpdateStatistics()
        {
            lblStatsTotalExcelDokument.Text = _statsExcelDocumentsTotal.ToString();
            lblStatsTotalWordDokument.Text = _statsWordDocumentsTotal.ToString();
            lblStatsTotalExcelVorlage.Text = _statsExcelTemplatesTotal.ToString();
            lblStatsTotalWordVorlage.Text = _statsWordTemplatesTotal.ToString();

            lblStatsFehlerExcelDokument.Text = _statsExcelDocumentsFehler.ToString();
            lblStatsFehlerWordDokument.Text = _statsWordDocumentsFehler.ToString();
            lblStatsFehlerExcelVorlage.Text = _statsExcelTemplatesFehler.ToString();
            lblStatsFehlerWordVorlage.Text = _statsWordTemplatesFehler.ToString();

            lblStatsOkExcelDokument.Text = _statsExcelDocumentsOk.ToString();
            lblStatsOkWordDokument.Text = _statsWordDocumentsOk.ToString();
            lblStatsOkExcelVorlage.Text = _statsExcelTemplatesOk.ToString();
            lblStatsOkWordVorlage.Text = _statsWordTemplatesOk.ToString();
        }

        #endregion

        #endregion
    }
}