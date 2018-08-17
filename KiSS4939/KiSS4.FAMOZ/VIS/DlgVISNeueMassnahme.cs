using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.FAMOZ.VIS
{
    public partial class DlgVISNeueMassnahme : KissDialog
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly int _baPersonID;
        private readonly bool _createLeistungOnOk = true;
        private readonly int _faFallID;
        private readonly int? _vormschID;

        /// <summary>
        /// ID der neu erstellten VM-Leistung
        /// </summary>
        private int _faLeistungID;

        private bool _ueberfuehren;

        public DlgVISNeueMassnahme()
        {
            InitializeComponent();
        }

        public DlgVISNeueMassnahme(int faFallID, int baPersonID)
            : this()
        {
            _faFallID = faFallID;
            _baPersonID = baPersonID;
        }

        public DlgVISNeueMassnahme(int faFallID, int baPersonID, bool ueberfuehren, int? vormschId)
            : this(faFallID, baPersonID)
        {
            _ueberfuehren = ueberfuehren;
            _vormschID = vormschId;
            edtInklAufgehobeneMassnahme.CheckedChanged -= edtInklAufgehobeneMassnahme_CheckedChanged;
            edtInklAufgehobeneMassnahme.Checked = true;
            edtInklAufgehobeneMassnahme.CheckedChanged += edtInklAufgehobeneMassnahme_CheckedChanged;
        }

        public DlgVISNeueMassnahme(int faFallID, int visFallNr, int baPersonID)
            : this()
        {
            _faFallID = faFallID;
            edtVISFallNr.EditValue = visFallNr;
            _baPersonID = baPersonID;
        }

        public DlgVISNeueMassnahme(int faFallID, int visFallNr, int baPersonID, bool createLeistungOnOk)
            : this()
        {
            _faFallID = faFallID;
            edtVISFallNr.EditValue = visFallNr;
            _baPersonID = baPersonID;
            _createLeistungOnOk = createLeistungOnOk;
        }

        public int FaLeistungID
        {
            get { return _faLeistungID; }
        }

        /// <summary>
        /// Nachdem der Dialog mit OK abgeschlossen wurde, kann die effektive Leistung mit dieser Methode von aussen her erstellt werden, falls sie nicht schon beim OK selber erstellt wurde
        /// Dies ist für gewisse Transaktionshandlings nötig, da der User zuerst den Dialog abschliessen muss, bevor die Transaktion gestartet werden kann
        /// </summary>
        /// <returns></returns>
        public int CreateVLeistung()
        {
            return CreateVLeistung(_faFallID);
        }

        public int CreateVLeistung(int faFallID)
        {
            if (_faLeistungID == 0)
            {
                // Der Dialog wurde mit OK abgeschlossen und die Leistung wurde noch nicht erstellt
                _faLeistungID = UtilsVIS.CreateNewVMLeistung(faFallID, _baPersonID, (int)qryVISMassnahmen["VormschID"], qryVISMassnahmen["ArrangementId"].ToString(), _ueberfuehren);
            }

            return _faLeistungID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryVISMassnahmen["VormschID"]))
            {
                KissMsg.ShowInfo("Bitte selektieren Sie eine Massnahme");
                return;
            }

            if ((bool)qryVISMassnahmen["VMExist"])
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                            SELECT LEI.FaFallID, LEI.FaLeistungID
                            FROM FaLeistung LEI
                            INNER JOIN VmMassnahme MAS ON MAS.FaLeistungID = LEI.FaLeistungID
                            WHERE MAS.VIS_VormschID = {0}", qryVISMassnahmen["VormschID"]);

                if (qry.Count > 0)
                {
                    KissMsg.ShowInfo(string.Format("Die selektierte Massnahme wird im KiSS bereits geführt im Fall {0}, Leistung {1}", qry["FaFallID"], qry["FaLeistungID"]));
                }

                return;
            }

            if (_createLeistungOnOk)
            {
                // Erstelle die effektive V-Leistung in der DB
                CreateVLeistung();
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnVISMassnahmenLaden_Click(object sender, EventArgs e)
        {
            ReloadVISFall();
        }

        private void DlgVISNeueMassnahme_Load(object sender, EventArgs e)
        {
            qryBaPerson.Fill(_baPersonID);

            if (DBUtil.IsEmpty(edtVISFallNr.EditValue))
            {
                if (DBUtil.IsEmpty(qryBaPerson["ZIPNr"]))
                {
                    KissMsg.ShowInfo(string.Format("Die Person {0} hat keine PID und kann daher im VIS nicht gesucht werden.\r\n\r\nFalls bekannt, geben Sie direkt die VIS-Fall-Nr ein.", qryBaPerson["Person"]));
                    return;
                }

                try
                {
                    edtVISFallNr.EditValue = DBUtil.ExecuteScalarSQLThrowingException(@"SELECT FALL_NR FROM dbo.vwVIS_DOSSIER WHERE ZIP_NR = {0}", qryBaPerson["ZIPNr"]);
                }
                catch (Exception ex)
                {
                    // Eintrag ins Log.
                    _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                    edtVISFallNr.EditValue = null;
                }

                if (DBUtil.IsEmpty(edtVISFallNr.EditValue))
                {
                    KissMsg.ShowInfo(string.Format("Die Person {0} mit der PID {1} hat im VIS keinen Fall zugeordnet.\r\n\r\nFalls bekannt, geben Sie direkt die VIS-Fall-Nr ein.", qryBaPerson["Person"], qryBaPerson["ZIPNr"]));
                    return;
                }
            }

            // Wenn wir hierhin kommen, dann haben wir die ZIP-Nr gefunden, d.h. es ist nicht erlaubt, manuell die VIS-Fallnummer zu überschreiben
            edtVISFallNr.EditMode = EditModeType.ReadOnly;
            btnVISMassnahmenLaden.Visible = false;

            ReloadVISFall();
        }

        private void edtInklAufgehobeneMassnahme_CheckedChanged(object sender, EventArgs e)
        {
            ReloadVISFall();
        }

        private void ReloadVISFall()
        {
            _faLeistungID = 0;
            try
            {
                qryVISMassnahmen.Fill(edtVISFallNr.EditValue, edtInklAufgehobeneMassnahme.Checked, _vormschID);

                if (qryVISMassnahmen.Count == 0)
                {
                    KissMsg.ShowInfo(string.Format("Die VIS-Fallnummer {0} konnte entweder in VIS nicht gefunden werden oder hat keine aktiven Massnahmen.", edtVISFallNr.EditValue));
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(string.Format("Die VIS-Fallnummer {0} konnte in VIS nicht gefunden werden. Bitte überprüfen Sie die VIS-Fallnummer.", edtVISFallNr.Value), ex);
            }
        }
    }
}