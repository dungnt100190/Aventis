using System;
using System.Data;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung
{
    /// <summary>
    /// Summary description for CtlFaBeratungsphase.
    /// </summary>
    public partial class CtlFaBeratungsphase : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly string _typeName = typeof(CtlFaBeratungsphase).Name;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly bool _fsLicensed;

        #endregion

        #region Private Fields

        private int _faPhaseID;

        #endregion

        #endregion

        #region Constructors

        public CtlFaBeratungsphase()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // hide button reopen anyway at the beginning
            btnReopen.Visible = false;

            // check if FS is licensed
            _fsLicensed = Utils.ConvertToBool(
                DBUtil.ExecuteScalarSQL(@"
                    SELECT Licensed
                    FROM dbo.XModul WITH(READUNCOMMITTED)
                    WHERE ModulID = {0};",
                    ModulID.Fs));

            // init with default values
            Init(null, null, -1);
        }

        #endregion

        #region EventHandlers

        private void btnReopen_Click(object sender, EventArgs e)
        {
            SqlQuery qry3 = DBUtil.OpenSQL(@"
                SELECT CountIntake   = (SELECT COUNT(1)
                                        FROM dbo.FaPhase
                                        WHERE FaLeistungID = {0}
                                          AND FaPhaseCode = 1
                                          AND DatumBis IS NULL),
                       CountBeratung = (SELECT COUNT(1)
                                        FROM dbo.FaPhase
                                        WHERE FaLeistungID = {0}
                                          AND FaPhaseCode = 2
                                          AND DatumBis IS NULL)",
                qryPhase["FaLeistungID"]);

            int countIntake = Convert.ToInt32(qry3["CountIntake"]);
            int countBeratung = Convert.ToInt32(qry3["CountBeratung"]);
            int offeneIntakePhasen = DBUtil.GetConfigInt(@"System\Fallfuehrung\OffeneIntakePhasen", 1);

            if (countBeratung > 0)
            {
                KissMsg.ShowInfo(_typeName, "KeineBeratungsphaseAbgeschlossen", "Es gibt noch nicht abgeschlossene Beratungsphasen!");
                return;
            }

            if (Convert.ToInt32(qryPhase["FaPhaseCode"]) == 1)
            {
                //Intakephase
                switch (countIntake)
                {
                    case 0:
                        break;

                    case 1:
                        if (offeneIntakePhasen == 1)
                        {
                            KissMsg.ShowInfo(_typeName, "IntakePhaseVorhanden1", "Es gibt bereits eine offene Intake-Phase!");
                            return;
                        }
                        KissMsg.ShowInfo(_typeName, "IntakePhaseVorhanden2", "Achtung, es gibt bereits eine offene Intake-Phase!");
                        break;

                    case 2:
                        KissMsg.ShowInfo(_typeName, "2OffeneIntakePhasen", "Es gibt bereits 2 offene Intake-Phasen!");
                        return;

                    default:
                        return;
                }
            }
            else
            {
                //Beratungsphase
                if (countIntake > 0)
                {
                    KissMsg.ShowInfo(_typeName, "IntakePhaseNichtAbgeschlossen", "Es gibt noch nicht abgeschlossene Intake-Phasen!");
                    return;
                }
            }

            if (KissMsg.ShowQuestion(_typeName, "PhaseWiederOeffnen", "Soll die geschlossene Phase wieder geöffnet werden ?"))
            {
                qryPhase.CanUpdate = true;
                qryPhase["DatumBis"] = DBNull.Value;
                qryPhase.Post();
            }
        }

        private void CtlFaBeratungsphase_RefreshData(object sender, EventArgs e)
        {
            if (!qryPhase.Post())
            {
                return;
            }

            // wenn REFRESH geklickt wird, sollen die DLP aktualisiert werden,
            // weil das Erfassen der DLPs in einem MDI-Child erfolgt
            if (_fsLicensed)
            {
                qryDLP.Refresh();
            }

            qryPhase.Refresh();
        }

        private void editSAR_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSAR.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryPhase["SAR"] = dlg["Name"];
                qryPhase["UserID"] = dlg["UserID"];
            }
        }

        private void qryPhase_AfterPost(object sender, EventArgs e)
        {
            SetEditMode();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryPhase_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, KissMsg.GetMLMessage(_typeName, "Eroeffnungsdatum", "Eröffnungsdatum"));
            DBUtil.CheckNotNullField(edtSAR, KissMsg.GetMLMessage(_typeName, "SAR", "SAR"));

            if (!DBUtil.IsEmpty(qryPhase["DatumBis"]) && (DateTime)qryPhase["DatumVon"] > (DateTime)qryPhase["DatumBis"])
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        _typeName,
                        "EroeffdatNachAbschlussdat",
                        "Das Eröffnungsdatum darf nicht nach dem Abschlussdatum liegen!",
                        KissMsgCode.MsgInfo));
            }

            SqlQuery qryFall = DBUtil.OpenSQL(@"
                SELECT FAL.FaLeistungID,
                       FAL.DatumVon
                FROM dbo.FaPhase            PHA
                  INNER JOIN dbo.FaLeistung FAL ON FAL.FaLeistungID = PHA.FaLeistungID
                WHERE FaPhaseID = {0}",
                _faPhaseID);

            int faLeistungID = Convert.ToInt32(qryFall["FaLeistungID"]);

            if (qryPhase.ColumnModified("DatumVon"))
            {
                if ((DateTime)qryPhase["DatumVon"] < (DateTime)qryFall["DatumVon"])
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            _typeName,
                            "EroeffdatVorFallEroeffdat",
                            "Das Eröffnungsdatum darf nicht vor dem Eröffnungsdatum des Fallverlaufs liegen!",
                            KissMsgCode.MsgInfo));
                }

                int count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.FaPhase PHA
                    WHERE PHA.FaLeistungID = {0}
                      AND {1} BETWEEN PHA.DatumVon AND PHA.DatumBis
                      AND PHA.FaPhaseID <> {2}",
                    faLeistungID,
                    qryPhase["DatumVon"],
                    _faPhaseID));

                if (count > 0)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            _typeName,
                            "UeberschneidungEroeffdat",
                            "Das Eröffnungsdatum darf sich nicht mit einer anderen Phase überschneiden!",
                            KissMsgCode.MsgInfo));
                }
            }

            if (Session.SupportDynaMask && !DBUtil.IsEmpty(qryPhase["DatumBis"]))
            {
                //prüfen, ob alle Muss-Einzelfelder ausgefüllt sind
                SqlQuery qry1 = DBUtil.OpenSQL(@"
                    DECLARE @FaPhaseCode INT;
                    SET @FaPhaseCode = (SELECT FaPhaseCode
                                        FROM dbo.FaPhase WITH(READUNCOMMITTED)
                                        WHERE FaPhaseID = {0});

                    SELECT FLD.DisplayText
                    FROM dbo.DynaField         FLD WITH(READUNCOMMITTED)
                      INNER JOIN dbo.DynaMask  MSK WITH(READUNCOMMITTED) ON MSK.Maskname = FLD.Maskname
                                                                        AND MSK.Active = 1
                                                                        AND MSK.FaPhaseCode = @FaPhaseCode
                      LEFT  JOIN dbo.DynaValue VAL WITH(READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                                                                        AND VAL.FaPhaseID = {0}
                                                                        AND VAL.GridRowID = 1
                    WHERE FLD.AppCode like '%[[]Abschluss]%'
                      AND NOT (ISNULL(MSK.AppCode, '') LIKE '%[[]ZielAusw]%')
                      AND VAL.Value IS NULL
                    ORDER BY FLD.DisplayText;",
                    _faPhaseID);

                //prüfen, ob alle Ziele minimal ausgewertet wurden
                SqlQuery qry2 = DBUtil.OpenSQL(@"
                    DECLARE @FaPhaseCode   INT;
                    DECLARE @ZielTextFldID INT;
                    DECLARE @ZielMussFelder TABLE (DynaFieldID INT);

                    SET @FaPhaseCode = (SELECT FaPhaseCode
                                        FROM dbo.FaPhase WITH(READUNCOMMITTED) WHERE FaPhaseID = {0});

                    SET @ZielTextFldID = (SELECT MAX(DynaFieldID)
                                          FROM dbo.DynaField        FLD WITH(READUNCOMMITTED)
                                            INNER JOIN dbo.DynaMask MSK WITH(READUNCOMMITTED) ON MSK.Maskname = FLD.Maskname
                                                                                             AND MSK.Active = 1
                                          WHERE FLD.AppCode LIKE '%[[]ZielText]%'
                                            AND MSK.FaPhaseCode = @FaPhaseCode);

                    INSERT @ZielMussFelder
                      SELECT FLD.DynaFieldID
                      FROM dbo.DynaField        FLD WITH(READUNCOMMITTED)
                        INNER JOIN dbo.DynaMask MSK WITH(READUNCOMMITTED) ON MSK.Maskname = FLD.Maskname
                                                                         AND MSK.Active = 1
                      WHERE FLD.AppCode LIKE '%[[]Abschluss]%'
                        AND MSK.AppCode LIKE '%[[]ZielAusw]%'
                        AND MSK.FaPhaseCode = @FaPhaseCode;

                    SELECT DISTINCT
                           GID.Value ZielText
                    FROM (SELECT GridRowID, Value
                          FROM dbo.DynaValue WITH(READUNCOMMITTED)
                          WHERE FaPhaseID = {0}
                            AND DynaFieldID = @ZielTextFldID) GID
                      LEFT JOIN dbo.DynaValue                 VAL WITH(READUNCOMMITTED) ON VAL.FaPhaseID = {0}
                                                                                       AND VAL.DynaFieldID IN (SELECT DynaFieldID
                                                                                                               FROM @ZielMussFelder)
                                                                                       AND VAL.GridRowID = GID.GridRowID
                    WHERE VAL.Value IS NULL;",
                    _faPhaseID);

                int phaseAbschluss = DBUtil.GetConfigInt(@"System\Fallfuehrung\PhaseAbschluss", 1);

                // 1: Muss-Einzelfelder zwingend
                // 2: Muss-Einzelfelder nur zwingend, wenn Ziele vorhanden
                if ((qry1.Count > 0 && phaseAbschluss == 1) || qry2.Count > 0)
                {
                    string info = "Die Phase kann noch nicht abgeschlossen werden.\r\n";

                    if (qry1.Count > 0)
                    {
                        info += "\r\nFolgende Einzelfelder sind noch nicht erfasst:\r\n";

                        foreach (DataRow row in qry1.DataTable.Rows)
                        {
                            info += "- " + row["DisplayText"] + "\r\n";
                        }
                    }

                    if (qry2.Count > 0)
                    {
                        info += "\r\nFolgende Ziele sind noch nicht ausgewertet:\r\n";

                        foreach (DataRow row in qry2.DataTable.Rows)
                        {
                            if (row["ZielText"].ToString().Length > 50)
                            {
                                info += "- " + row["ZielText"].ToString().Substring(0, 50) + " ...\r\n";
                            }
                            else
                            {
                                info += "- " + row["ZielText"] + "\r\n";
                            }
                        }
                    }

                    KissMsg.ShowInfo(null, null, info, 500, 200 + (qry1.Count + qry2.Count) * 16);
                    qryPhase["DatumBis"] = DBNull.Value;
                    throw new KissCancelException();
                }
            }

            // set modifier and modified
            qryPhase.SetModifierModified();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faPhaseID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            _faPhaseID = faPhaseID;

            // validate
            if (faPhaseID < 1)
            {
                // lock control
                SetEditMode();
                return;
            }

            // get data
            if (_fsLicensed)
            {
                qryDLP.Fill();
                LoadQueryDlp(edtDLPzugewiesen);
                LoadQueryDlp(edtDLPBedarf);
            }

            qryPhase.Fill(faPhaseID);

            // setup mode and rights
            SetEditMode();

            // Abschlussgrund: Falls vorhanden spezielles LOV laden, sonst allgemeines
            try
            {
                object lovName;

                if (Convert.ToInt32(qryPhase[DBO.FaPhase.FaPhaseCode]) == 1)
                {
                    lovName = DBUtil.ExecuteScalarSQL(@"
                        --SQLCHECK_IGNORE--
                        SELECT LOVName
                        FROM dbo.XLOV WITH (READUNCOMMITTED)
                        WHERE LOVName = 'FaAbschlussgrundIntPhase'");
                }
                else
                {
                    lovName = DBUtil.ExecuteScalarSQL(@"
                        --SQLCHECK_IGNORE--
                        SELECT LOVName
                        FROM dbo.XLOV WITH (READUNCOMMITTED)
                        WHERE LOVName = 'FaAbschlussgrundBerPhase'");
                }

                if (lovName == null)
                {
                    lovName = "FaAbschlussgrundPhase";
                }

                edtAbschlussGrundCode.LOVName = lovName.ToString();
            }
            catch
            {
            }
        }

        #endregion

        #region Private Methods

        private void HideDlpControls()
        {
            if (!_fsLicensed)
            {
                // disable DLP selection
                lblDLPZugewiesen.Visible = false;
                edtDLPzugewiesen.Visible = false;
                lblDLPBedarf.Visible = false;
                edtDLPBedarf.Visible = false;
            }
        }

        private void LoadQueryDlp(KissLookUpEdit edt)
        {
            edt.LoadQuery(qryDLP);
        }

        private void SetEditMode()
        {
            HideDlpControls();

            // check data
            if (qryPhase.IsEmpty)
            {
                // hide button
                btnReopen.Visible = false;

                // lock CRUD
                qryPhase.CanInsert = false;
                qryPhase.CanUpdate = false;
                qryPhase.CanDelete = false;

                // handle editmode of controls
                qryPhase.EnableBoundFields();

                // done
                return;
            }

            // init flags
            bool mayRead, mayIns, mayUpd, mayDel, mayClose, mayReOpen;

            bool phaseOwner = (Session.User.IsUserAdmin || (Session.User.UserID == Convert.ToInt32(qryPhase[DBO.FaPhase.UserID])));
            bool open = DBUtil.IsEmpty(qryPhase[DBO.FaPhase.DatumBis]) && DBUtil.IsEmpty(qryPhase["FallDatumBis"]);
            bool archived = !DBUtil.IsEmpty(qryPhase["FaLeistungArchivID"]);

            DBUtil.GetFallRights(
                Convert.ToInt32(qryPhase[DBO.FaPhase.FaLeistungID]),
                out mayRead,
                out mayIns,
                out mayUpd,
                out mayDel,
                out mayClose,
                out mayReOpen);

            if (mayClose || phaseOwner)
            {
                // set update-mode
                qryPhase.CanUpdate = open;

                // neue Logik für Reopen: Fallverlaufbesitzer darf nicht wiederöffnen, nur Phasenbesitzer
                mayReOpen = !open && !archived && phaseOwner && DBUtil.UserHasRight("CtlFaPhaseReopen");
            }
            else
            {
                // not owner, cannot reopen case
                mayReOpen = false;

                // user cannot modify item
                qryPhase.CanUpdate = false;
            }

            // handle controls
            btnReopen.Visible = mayReOpen;

            edtDatumVon.EditMode = open ? EditModeType.Normal : EditModeType.ReadOnly;
            edtSAR.EditMode = open ? EditModeType.Normal : EditModeType.ReadOnly;

            qryPhase.EnableBoundFields((open && qryPhase.CanUpdate));
        }

        #endregion

        #endregion
    }
}