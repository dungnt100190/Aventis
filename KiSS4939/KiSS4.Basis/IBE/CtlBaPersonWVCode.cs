using System;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraEditors.Controls;

namespace KiSS4.Basis.IBE
{
    public partial class CtlBaPersonWVCode : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPersonWVCode()
        {
            InitializeComponent();

            ddlWVCode.Properties.DataSource = DBUtil.OpenSQL(@"
                SELECT Code,
                       Text = Shorttext + '  ' + Text
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'BaWVCode';");

            colWVCode.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                SELECT Code,
                       Text = Shorttext
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'BaWVCode';"));

            colBED.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit("BaBED");
            colStatus.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit("BaWVStatus");
        }

        #endregion

        #region Properties

        public int BaPersonID
        {
            set
            {
                _baPersonID = value;
                qryBaWVCode.Fill(value);

                if (qryBaWVCode.Count == 0)
                {
                    qryBaWVCode.Insert();
                }
            }
            get
            {
                return _baPersonID;
            }
        }

        private bool CanInsertWVCode
        {
            get
            {
                qryStatus.Fill(_baPersonID, qryBaWVCode["DatumVon"], qryBaWVCode["DatumBis"], qryBaWVCode["BaWVCodeID"]);
                return (bool)qryStatus["CanInsert"];
            }
        }

        private bool CanUpdateWVCode
        {
            get
            {
                qryStatus.Fill(_baPersonID, qryBaWVCode["DatumVon"], qryBaWVCode["DatumBis"], qryBaWVCode["BaWVCodeID"]);
                return qryBaWVCode.Row.RowState == System.Data.DataRowState.Added || (bool)qryStatus["CanUpdate"];
            }
        }

        private DateTime LastDateTo
        {
            get
            {
                qryStatus.Fill(_baPersonID, qryBaWVCode["DatumVon"], qryBaWVCode["DatumBis"], qryBaWVCode["BaWVCodeID"]);
                return (DateTime)qryStatus["LastDateTo"];
            }
        }

        #endregion

        #region EventHandlers

        private void ddlWVCode_CloseUp(object sender, CloseUpEventArgs e)
        {
            ddlBED.EditValue = null;
        }

        private void ddlWVCode_EditValueChanging(object sender, ChangingEventArgs e)
        {
            //value2 (BED) of WVCode:
            string bedCriteria = (string)DBUtil.ExecuteScalarSQL(@"
                SELECT Value2
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'BaWVCode'
                  AND Code = {0};", e.NewValue);

            if (!DBUtil.IsEmpty(bedCriteria))
            {
                SetBEDList(bedCriteria);
            }
        }

        private void qryBaWVCode_AfterInsert(object sender, EventArgs e)
        {
            qryBaWVCode["BaPersonID"] = _baPersonID;
            qryBaWVCode["DatumVon"] = LastDateTo.AddDays(1);
            Activate();
        }

        private void qryBaWVCode_AfterPost(object sender, EventArgs e)
        {
            HandleFolgeCode();
        }

        private void qryBaWVCode_BeforeInsert(object sender, EventArgs e)
        {
            if (!CanInsertWVCode)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBaPersonWVCode", "WVCodeDatumBisFehlt", "Es existiert ein nicht abgeschlossener WVCode. Es kann kein neuer angelegt werden.", KissMsgCode.MsgInfo));
            }
        }

        private void qryBaWVCode_BeforePost(object sender, EventArgs e)
        {
            //Muss ausgefüllt sein: DatumVon, WVCode, BED
            DBUtil.CheckNotNullField(edtDatumVon, KissMsg.GetMLMessage("CtlBaPersonWVCode", "Eroeffnungsdatum", "Eröffnungsdatum"));
            DBUtil.CheckNotNullField(ddlWVCode, KissMsg.GetMLMessage("CtlBaPersonWVCode", "WVCode", "WVCode"));
            DBUtil.CheckNotNullField(ddlBED, KissMsg.GetMLMessage("CtlBaPersonWVCode", "BaBedID", "BED"));

            object datumBis = DBUtil.ExecuteScalarSQL(@"
                SELECT DateAdd(Day, -1, DateAdd(Month, Convert(int, Value3), {1}))
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'BaWVCode'
                  AND Code = {0};", ddlWVCode.EditValue, qryBaWVCode["DatumVon"]);

            object monate = DBUtil.ExecuteScalarSQL(@"
                SELECT Value3
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'BaWVCode'
                  AND Code = {0};", ddlWVCode.EditValue);

            //DatumVon > DatumBis
            if (!DBUtil.IsEmpty(qryBaWVCode["DatumBis"]))
            {
                if ((DateTime)qryBaWVCode["DatumVon"] > (DateTime)qryBaWVCode["DatumBis"])
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBaPersonWVCode", "DatumBisGroesserDatumVon", "Das Von-Datum muss grösser als das Bis-Datum sein!", KissMsgCode.MsgInfo));
                }
                string folgeCode = GetFolgeCode();
                if (!DBUtil.IsEmpty(folgeCode) && !DBUtil.IsEmpty(datumBis) && (DateTime)qryBaWVCode["DatumBis"] > (DateTime)datumBis)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBaPersonWVCode", "MaxZeitdauer", "Datum Bis überschreitet maximale Zeitdauer ({0} Monate).", KissMsgCode.MsgInfo, monate as string));
                }
            }
            else
            { //DatumBis null --> je nach WVCode kann DatumBis gesetzt werden
                if (!DBUtil.IsEmpty(datumBis))
                {
                    qryBaWVCode["DatumBis"] = (DateTime)datumBis;
                }
            }
            //DatumVon nicht innerhalb DatumVon-DatumBis von bestehendem Record
            if (qryBaWVCode.ColumnModified("DatumVon"))
            {
                int count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.BaWVCode WITH(READUNCOMMITTED)
                    WHERE BaPersonID = {0}
                      AND ({1} BETWEEN DatumVon AND DatumBis OR {1} <= DatumVon)
                      AND BaWVCodeID <> ISNULL({2}, -1)
                      AND ISNULL(StatusCode, 0) <> 2; -- Status <> Falsch",
                    _baPersonID,
                    qryBaWVCode["DatumVon"], qryBaWVCode["BaWVCodeID"]);
                if (count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBaPersonWVCode", "UeberschneidungGueltigkeitsdatum", "Das Datum darf sich nicht mit einer anderen Gültigkeitsperiode überschneiden!", KissMsgCode.MsgInfo));
                }
            }
        }

        private void qryBaWVCode_PositionChanged(object sender, EventArgs e)
        {
            edtDatumVon.EditMode = CanUpdateWVCode ? EditModeType.Normal : EditModeType.ReadOnly;
            edtDatumBis.EditMode = CanUpdateWVCode || DBUtil.IsEmpty(edtDatumBis.EditValue) ? EditModeType.Normal : EditModeType.ReadOnly;
            ddlWVCode.EditMode = CanUpdateWVCode ? EditModeType.Normal : EditModeType.ReadOnly;
            ddlBED.EditMode = CanUpdateWVCode ? EditModeType.Normal : EditModeType.ReadOnly;

            qryBaWVCode.CanDelete = CanUpdateWVCode;

            if (CanUpdateWVCode)
            {
                SetWVList();
            }
            else
            {
                SetWVList("");
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Activate()
        {
            edtDatumVon.Focus();
        }

        #endregion

        #region Private Methods

        private string GetFolgeCode()
        {
            //value1 (Folgecode) of WVCode:
            return DBUtil.ExecuteScalarSQL(@"
                SELECT Value1
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'BaWVCode'
                  AND Code = {0};",
                ddlWVCode.EditValue) as string;
        }

        private void HandleFolgeCode()
        {
            //value1 (Folgecode) of WVCode:
            string folgeCode = GetFolgeCode();

            if (DBUtil.IsEmpty(folgeCode))
            {
                return;
            }

            int nrFolgeCodes = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.BaWVCode WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ISNULL(StatusCode, 0) <> 2 -- Status <> Falsch,
                  AND (BaWVCode IS NULL OR DatumVon > (SELECT DatumVon
                                                       FROM dbo.BaWVCode WITH(READUNCOMMITTED)
                                                       WHERE BaWVCodeID = {1}));", _baPersonID, qryBaWVCode["BaWVCodeID"]);

            if (nrFolgeCodes > 0 || !KissMsg.ShowQuestion("CtlBaPersonWVCode", "FolgeCodeEinfuegen", "Für diesen WV-Code ist ein FolgeCode zwingend. Soll ein Datensatz angelegt werden?"))
            {
                return;
            }

            DBUtil.ExecuteScalarSQL(@"
                INSERT INTO dbo.BaWVCode (BaPersonID, DatumVon)
                VALUES ({0}, {1})", _baPersonID, LastDateTo.AddDays(1));

            qryBaWVCode.Refresh();
            qryBaWVCode.Last();
            Activate();
        }

        private void SetBEDList(string bedCriteria)
        {
            SetDDLList(ddlBED, bedCriteria, "BaBED");
        }

        private void SetDDLList(KissLookUpEdit ddl, string codes, string lovName)
        {
            if (DBUtil.IsEmpty(codes)) codes = "Code"; //finds all

            string[] criteria = codes.Split(',');
            string whereInString = "";

            if (codes.Contains("-"))
            {
                foreach (string s in criteria)
                {
                    if (whereInString.Length > 0)
                    {
                        whereInString += ",";
                    }

                    if (s.Contains("-"))
                    {
                        string[] minMax = s.Split('-');
                        int min;
                        int max;

                        int.TryParse(minMax[0], out min);
                        int.TryParse(minMax[1], out max);

                        for (int i = min; i <= max; i++)
                        {
                            whereInString += i.ToString();
                            if (i < max)
                            {
                                whereInString += ",";
                            }
                        }
                    }
                    else
                    {
                        whereInString += s;
                    }
                }
            }
            else
            {
                whereInString = codes;
            }

            string format;

            if (ddl == ddlBED)
            {
                format = @"
                    SELECT Code,
                           Text = CAST(Code AS VARCHAR) + ',  ' + Text
                    FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                    WHERE LOVName = {{0}} AND Code IN ({0});";
            }
            else
            {
                format = @"
                    SELECT Code,
                           Text = Shorttext + '  ' + Text
                    FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                    WHERE LOVName = {{0}} AND Code IN ({0});";
            }

            string sql = string.Format(format, whereInString);

            ddl.Properties.DataSource = DBUtil.OpenSQL(sql, lovName);
            ddl.Properties.DropDownRows = 7;
        }

        private void SetWVList()
        {
            string folgeCodes = (string)DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(Value1, '')
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'BaWVCode'
                  AND Code = (SELECT TOP 1 BaWVCode
                              FROM dbo.BaWVCode WITH(READUNCOMMITTED)
                              WHERE BaPersonID = {0}
                                AND ISNULL(StatusCode, 0) <> 2 -- Status <> Falsch
                                AND BaWVCode IS NOT NULL
                                AND BaWVCodeID <> {1}
                              ORDER BY DatumVon DESC);", _baPersonID, qryBaWVCode.Row["BaWVCodeID"]);

            SetWVList(folgeCodes);
        }

        private void SetWVList(string folgeCodes)
        {
            SetDDLList(ddlWVCode, folgeCodes, "BaWVCode");
        }

        #endregion

        #endregion
    }
}