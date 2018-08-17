using System;
using System.Data;
using DevExpress.XtraGrid.Views.Base;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    public partial class CtlFrmVmBewertung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private const string CLASSENAME = "CtlFrmVmBewertung";
        private int _baPersonID;
        private bool _displayedMembersFromReceiveMessage;
        private bool _updating;
        private int _vmBewertungID;

        #endregion

        #endregion

        #region Constructors

        public CtlFrmVmBewertung()
        {
            InitializeComponent();

            InitQueries();

            edtSAR.EditValue = Session.User.LastName + ", " + Session.User.FirstName;
            edtSAR.LookupID = Session.User.UserID;

            //frmVmBewertung_Shown hier verschoben wegen der Migration FrmToCtl
            frmVmBewertung_Shown(this, new EventArgs());
        }

        #endregion

        #region EventHandlers

        private void editSAR_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSAR.Text, e.ButtonClicked);

            if (e.Cancel)
            {
                return;
            }

            edtSAR.EditValue = dlg["Name"];
            edtSAR.LookupID = dlg["UserID"];
            DisplayMandanten();
        }

        private void frmVmBewertung_Shown(object sender, EventArgs e)
        {
            if (!_displayedMembersFromReceiveMessage)
            {
                DisplayMandanten();
            }

            _displayedMembersFromReceiveMessage = false;
        }

        private void grvMandanten_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            if (_updating)
            {
                return;
            }

            e.Allow = ctlVmKriterien.ActiveSQLQuery.Post();
        }

        private void qryMandant_AfterFill(object sender, EventArgs e)
        {
            CalcAuslastung();
        }

        private void qryMandant_PositionChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryMandant["FaLeistungID"]) || _updating)
            {
                return;
            }

            if (_vmBewertungID > 0 && _baPersonID > 0)
            {
                ctlVmKriterien.SetVmBewertungId(_vmBewertungID, Convert.ToInt32(qryMandant["FaLeistungID"]));
            }
            else
            {
                // the _vmBewertungID is only useful with its matching FaLeistungID. as the value of _vmBewertungID is resetted above after assigning
                //   once (see ReceiveMessage>SetVmBewertungID>DisplayMandant > _baPersonID), there is no usage of the id after changing the position
                //   once and we need to reset the value on ctlVmKritierien, too!
                ctlVmKriterien.ResetVmBewertungIdWithoutReload();
                ctlVmKriterien.FaLeistungId = Convert.ToInt32(qryMandant["FaLeistungID"]);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="parameters">Specific messages as key/value pair for current form</param>
        /// <returns>True, if successfully handles message call, else false</returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "SetBewertungID":
                    SetBewertungID(Convert.ToInt32(parameters["VmBewertungID"]));
                    return true;
            }

            // did not understand message
            return false;
        }

        public void UpdateMandanten()
        {
            if (qryMandant.Count == 0)
            {
                return;
            }

            _updating = true;

            try
            {
                _baPersonID = Convert.ToInt32(qryMandant["BaPersonID"]);
                DisplayMandanten();
            }
            finally
            {
                _updating = false;
            }
        }

        #endregion

        #region Private Methods

        private void CalcAuslastung()
        {
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int countD = 0;

            foreach (DataRow row in qryMandant.DataTable.Rows)
            {
                object bCode = row["VmMandatstypBewilligtCode"];
                if (!DBUtil.IsEmpty(bCode))
                {
                    switch ((int)bCode)
                    {
                        case 1:
                            countA++;
                            break;

                        case 2:
                            countB++;
                            break;

                        case 3:
                            countC++;
                            break;

                        case 4:
                            countD++;
                            break;
                    }
                }
            }
            edtAnzahlA.EditValue = countA;
            edtAnzahlB.EditValue = countB;
            edtAnzahlC.EditValue = countC;
            edtAnzahlD.EditValue = countD;
            edtAnzahlTotal.EditValue = countA + countB + countC + countD;

            int hoursPerYearForCaseMgmt = 0;
            if (qryUser.Count > 0 && !DBUtil.IsEmpty(qryUser["HoursPerYearForCaseMgmt"]))
                hoursPerYearForCaseMgmt = (int)qryUser["HoursPerYearForCaseMgmt"];

            int hours = 0;
            try
            {
                foreach (DataRow row in qryVmMandatsTyp.DataTable.Rows)
                {
                    switch ((int)row["Code"])
                    {
                        case 1:
                            hours += countA * Convert.ToInt32(row["Value1"]);
                            break;

                        case 2:
                            hours += countB * Convert.ToInt32(row["Value1"]);
                            break;

                        case 3:
                            hours += countC * Convert.ToInt32(row["Value1"]);
                            break;

                        case 4:
                            hours += countD * Convert.ToInt32(row["Value1"]);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSENAME, "FehlerWerteliste", "Fehler in der Werteliste 'VmMandatsTyp'", ex);
                hours = 0;
            }

            if (hoursPerYearForCaseMgmt > 0)
                edtAuslastung.EditValue = Convert.ToDouble(hours) / Convert.ToDouble(hoursPerYearForCaseMgmt) * 100.0;
            else
                edtAuslastung.EditValue = 0;
        }

        private void DisplayMandanten()
        {
            qryUser.Fill(
                @"SELECT JobPercentage,
                         HoursPerYearForCaseMgmt
                  FROM dbo.XUser WITH (READUNCOMMITTED)
                  WHERE UserID = {0};", edtSAR.LookupID);

            qryMandant.Fill(@"
                SELECT FaLeistungID              = LEI.FaLeistungID,
                       BaPersonID                = LEI.BaPersonID,
                       Mandant                   = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
                       ZGB                       = REPLACE(dbo.fnLOVTextListe('VmZGB', VMN.ZGBCodes), ' ZGB', ''),
                       VmMandatstypCode          = VBW.VmMandatstypCode,
                       VmMandatstypBewilligtCode = VBW.VmMandatstypBewilligtCode,
                       Tage                      = DATEDIFF(d, CONVERT(DATETIME, STI.Text + CONVERT(VARCHAR, VBW.VmFallgewichtungJahr), 104), GETDATE())
                FROM dbo.FaLeistung          LEI WITH(READUNCOMMITTED)
                  INNER JOIN dbo.BaPerson    PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                  LEFT  JOIN dbo.VmBewertung VBW WITH(READUNCOMMITTED) ON VBW.FaLeistungID = LEI.FaLeistungID
                                                                      AND VBW.VmBewertungID = (SELECT TOP 1 VmBewertungID
                                                                                               FROM dbo.VmBewertung WITH(READUNCOMMITTED)
                                                                                               WHERE FaLeistungID = LEI.FaLeistungID
                                                                                                 AND VmMandatstypCode IS NOT NULL
                                                                                               ORDER BY VmFallgewichtungJahr DESC,
                                                                                                        VmFallgewichtungStichtagCode DESC)
                  LEFT  JOIN dbo.XLOVCode    STI WITH(READUNCOMMITTED) ON STI.LOVName = 'VmFallgewichtungStichtag'
                                                                      AND STI.Code = VBW.VmFallgewichtungStichtagCode
                  LEFT  JOIN dbo.VmMassnahme VMN WITH(READUNCOMMITTED) ON VMN.FaLeistungID = LEI.FaLeistungID
                                                                      AND VMN.VmMassnahmeID = (SELECT TOP 1 VmMassnahmeID
                                                                                               FROM dbo.VmMassnahme WITH(READUNCOMMITTED)
                                                                                               WHERE FaLeistungID = LEI.FaLeistungID
                                                                                               ORDER BY DatumVon DESC)
                WHERE LEI.UserID = {0}
                  AND LEI.ModulID = 5
                  AND LEI.FaProzessCode = 501
                  AND LEI.DatumBis IS NULL -- aktiver Fall
                  AND EXISTS (SELECT VmBerichtID
                              FROM dbo.VmBericht WITH(READUNCOMMITTED)
                              WHERE FaLeistungID = LEI.FaLeistungID
                                AND Erstellung IS NULL) -- pendente Berichterstellung
                ORDER BY Mandant;", edtSAR.LookupID);

            if (_baPersonID > 0)
            {
                if (!qryMandant.Find(string.Format("BaPersonID = {0}", _baPersonID)))
                {
                    KissMsg.ShowInfo(Name, "BaPersonIDInMandantNotFound_v01", "Die gewünschte Person wurde in der angezeigten Liste der Mandanten nicht gefunden.\r\nBitte wählen Sie den Eintrag manuell aus.");
                }

                _baPersonID = 0; // reset (received via FormController, so we need it just once)

                if (_vmBewertungID > 0)
                {
                    _displayedMembersFromReceiveMessage = true; // set to prevent overwriting selection on Form_Shown
                }

                _vmBewertungID = 0; // reset (received via FormController, so we need it just once; used in qryMandant_PositionChanged)
            }
        }

        private void InitQueries()
        {
            grdMandanten.View.Columns["VmMandatstypCode"].ColumnEdit = grdMandanten.GetLOVLookUpEdit("vmMandatstyp");
            grdMandanten.View.Columns["VmMandatstypBewilligtCode"].ColumnEdit = grdMandanten.GetLOVLookUpEdit("vmMandatstyp");
            qryVmMandatsTyp = DBUtil.GetLOVQuery("VmMandatsTyp", false);
        }

        private void SetBewertungID(int vmBewertungID)
        {
            _vmBewertungID = vmBewertungID;

            var qry = DBUtil.OpenSQL(@"
                SELECT UserID     = ISNULL(USR1.UserID, USR2.UserID),
                       SAR        = ISNULL(USR1.LastName + ISNULL(', ' + USR1.Firstname, ''), USR2.LastName + ISNULL(', ' + USR2.Firstname, '')),
                       BaPersonID = LEI.BaPersonID
                FROM dbo.VmBewertung        BEW  WITH(READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung LEI  WITH(READUNCOMMITTED) ON LEI.FaLeistungID = BEW.FaLeistungID
                  LEFT JOIN dbo.XUser       USR1 WITH(READUNCOMMITTED) ON USR1.UserID = BEW.UserID
                  LEFT JOIN dbo.XUser       USR2 WITH(READUNCOMMITTED) ON USR2.UserID = LEI.UserID
                WHERE BEW.VmBewertungID = {0};", _vmBewertungID);

            edtSAR.EditValue = qry["SAR"];
            edtSAR.LookupID = qry["UserID"];
            _baPersonID = Convert.ToInt32(qry["BaPersonID"]);

            if (Visible)
            {
                DisplayMandanten();
            }
        }

        #endregion

        #endregion
    }
}