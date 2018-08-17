using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaIntegBildung.
    /// </summary>
    public partial class CtlKaIntegBildung : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_DATUM_BIS = "DatumBis";
        private const string COL_DATUM_VON = "DatumVon";
        private const string COL_KURS = "Kurs";
        private const string COL_KURS_DETAIL = "KursDetail";

        #endregion

        #region Private Fields

        private int _baPersonId = -1;
        private int _faLeistungId = -1;

        #endregion

        #endregion

        #region Constructors

        public CtlKaIntegBildung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlKaIntegBildung_Load(object sender, EventArgs e)
        {
            //FillIntegBildung();
        }

        private void dat_leave(object sender, EventArgs e)
        {
            if (!CheckDate())
            {
                KissMsg.ShowInfo("CtlKaIntegBildung", "AustrittVorEintritt", "'Austritt' darf nicht vor 'Eintritt' liegen!");
                ((KissDateEdit)sender).Focus();
            }
        }

        private void dlgKurs_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            if (dlg.KurserfassungSuchen(dlgKurs.Text, e.ButtonClicked, KaKurssucheCaller.IntegrierteBildung))
            {
                qryIntegBildung[COL_KURS] = dlg["KursNrName"];
                qryIntegBildung[DBO.KaIntegBildung.KaKurserfassungID] = dlg["KaKurserfassungID"];
                qryIntegBildung[COL_DATUM_VON] = dlg["DatumVon"];
                qryIntegBildung[COL_DATUM_BIS] = dlg["DatumBis"];
                qryIntegBildung[COL_KURS_DETAIL] = dlg["KursDetail"];

                dlgKurs.EditValue = dlg["KursNrName"];
                dlgKurs.LookupID = dlg["KaKurserfassungID"];
                lblKursDetail.Text = dlg["KursDetail"].ToString();

                qryIntegBildung.Post();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void qryIntegBildung_AfterInsert(object sender, EventArgs e)
        {
            qryIntegBildung[DBO.KaIntegBildung.BaPersonID] = _baPersonId;
            qryIntegBildung[DBO.KaIntegBildung.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonId);
        }

        private void qryIntegBildung_BeforePost(object sender, EventArgs e)
        {
            if (!CheckDate())
            {
                throw new KissInfoException("'Austritt' darf nicht vor 'Eintritt' liegen!");
            }

            if (!CheckDateInRange(datEintritt))
            {
                throw new KissInfoException("'Kurseintritt' liegt nicht innerhalb des Kursdatums!");
            }

            if (!CheckDateInRange(datAustritt))
            {
                throw new KissInfoException("'Kursaustritt' liegt nicht innerhalb des Kursdatums!");
            }

            DBUtil.CheckNotNullField(edtKaProgramm, lblKaProgramm.Text);
            DBUtil.CheckNotNullField(edtFaLeistung, lblFaLeistung.Text);
        }

        private void qryIntegBildung_PositionChanged(object sender, EventArgs e)
        {
            LoadFaLeistungQuery();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return _faLeistungId;
                case "BAPERSONID":
                    return _baPersonId;
                case "KAINTEGBILDUNGID":
                    return Convert.ToInt32(qryIntegBildung[DBO.KaIntegBildung.KaIntegBildungID]);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int baPersonId, int faLeistungId)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _baPersonId = baPersonId;
            _faLeistungId = faLeistungId;

            colKursabschluss.ColumnEdit = grdIntegBildung.GetLOVLookUpEdit("KaInteBildKursAbschl");

            FillIntegBildung();
            LoadFaLeistungQuery();
        }

        #endregion

        #region Private Methods

        private bool CheckDate()
        {
            bool rslt = true;

            if (!DBUtil.IsEmpty(datEintritt.EditValue) && !DBUtil.IsEmpty(datAustritt.EditValue))
            {
                if (Convert.ToDateTime(datEintritt.EditValue) > Convert.ToDateTime(datAustritt.EditValue))
                {
                    rslt = false;
                }
            }

            return rslt;
        }

        private bool CheckDateInRange(KissDateEdit dat)
        {
            bool rslt = true;

            try
            {
                if (!DBUtil.IsEmpty(dat.EditValue))
                {
                    if (!DBUtil.IsEmpty(qryIntegBildung[COL_DATUM_VON]) && !DBUtil.IsEmpty(qryIntegBildung[COL_DATUM_BIS]))
                    {
                        if (Convert.ToDateTime(dat.EditValue) < Convert.ToDateTime(qryIntegBildung[COL_DATUM_VON]) ||
                            Convert.ToDateTime(dat.EditValue) > Convert.ToDateTime(qryIntegBildung[COL_DATUM_BIS]))
                        {
                            rslt = false;
                        }
                    }
                    else if (!DBUtil.IsEmpty(qryIntegBildung[COL_DATUM_VON]))
                    {
                        if (Convert.ToDateTime(dat.EditValue) < Convert.ToDateTime(qryIntegBildung[COL_DATUM_VON]))
                        {
                            rslt = false;
                        }
                    }
                    else if (!DBUtil.IsEmpty(qryIntegBildung[COL_DATUM_BIS]))
                    {
                        if (Convert.ToDateTime(dat.EditValue) > Convert.ToDateTime(qryIntegBildung[COL_DATUM_BIS]))
                        {
                            rslt = false;
                        }
                    }
                }
            }
            catch { }

            return rslt;
        }

        private void FillIntegBildung()
        {
            qryIntegBildung.Fill(@"
                SELECT	IBI.KaIntegBildungID,
                        IBI.FaLeistungID,
                        IBI.BaPersonID,
                        IBI.KaKurserfassungID,
                        IBI.Eintritt,
                        IBI.Austritt,
                        IBI.AbschlussCode,
                        IBI.AbschlussDokID,
                        IBI.RueckmeldungDokID,
                        IBI.Bemerkung,
                        IBI.KursbestFlag,
                        IBI.SichtbarSDFlag,
                        IBI.KaProgrammCode,
                        Kurs = KUE.KursNr + isNull(', ' + KUR.Name, ''),
                        KursDetail = KUE.KursNr + isNull(', ' + KUR.Name, '')
                                     + isNull(', ' + Convert(VARCHAR(15), KUE.DatumVon, 104), '')
                                     + isNull(' - ' + Convert(VARCHAR(15), KUE.DatumBis, 104), '')
                                     + CASE WHEN KUE.SistiertFlag = 1 THEN ', sistiert' ELSE '' END,
                        DatumVon = KUE.DatumVon,
                        DatumBis = KUE.DatumBis,
                        IBI.Creator,
                        IBI.Created,
                        IBI.Modifier,
                        IBI.Modified
                FROM dbo.KaIntegBildung         IBI WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.KaKurserfassung KUE WITH(READUNCOMMITTED) ON KUE.KaKurserfassungID = IBI.KaKurserfassungID
                  LEFT JOIN dbo.KaKurs          KUR WITH(READUNCOMMITTED) ON KUR.KaKursID = KUE.KursID
                WHERE IBI.BaPersonID = {0}
                  AND (IBI.SichtbarSDFlag = {1} OR IBI.SichtbarSDFlag = 1)
                ORDER BY IBI.Austritt DESC",
                _baPersonId, Session.User.IsUserKA ? 0 : 1);

            SetEditMode();
        }

        private void LoadFaLeistungQuery()
        {
            qryFaLeistung.Fill(qryIntegBildung[DBO.KaIntegBildung.FaLeistungID], _baPersonId);
            edtFaLeistung.LoadQuery(qryFaLeistung);
        }

        private void SetEditMode()
        {
            bool mayClose, mayDel, mayIns, mayRead, mayReopen, mayUpd;
            DBUtil.GetFallRights(_faLeistungId, out mayRead, out mayIns, out mayUpd, out mayDel, out mayClose, out mayReopen);
            qryIntegBildung.CanUpdate = mayUpd && DBUtil.UserHasRight("CtlKaIntegBildung", "U");
            qryIntegBildung.CanInsert = mayIns && DBUtil.UserHasRight("CtlKaIntegBildung", "I");
            qryIntegBildung.CanDelete = mayDel && DBUtil.UserHasRight("CtlKaIntegBildung", "D");
            qryIntegBildung.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}