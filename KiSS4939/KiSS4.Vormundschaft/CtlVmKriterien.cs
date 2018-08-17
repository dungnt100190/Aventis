using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmKriterien.
    /// </summary>
    public partial class CtlVmKriterien : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly bool _showProdukte;

        #endregion

        #region Private Fields

        private int _faLeistungId;
        private bool _rightBewilligung;
        private int _toleranzTage = 10;
        private int _vmBewertungId;

        #endregion

        #endregion

        #region Constructors

        public CtlVmKriterien()
        {
            InitializeComponent();

            ProduktId = 0;

            _showProdukte = DBUtil.GetConfigBool(@"System\Vormundschaft\Bewertung\ProdukteAnzeigen", false);

            if (!_showProdukte)
            {
                lblKriterienE.Visible = false;
                edtKriterienE.Visible = false;
                edtVmMandatstypCode.LOVFilter = "1";
                edtVmMandatstypCode.LOVName = "VmMandatstyp";
            }
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [DefaultValue(0)]
        public int FaLeistungId
        {
            get { return _faLeistungId; }
            set
            {
                _faLeistungId = value;
                DisplayBewertungen();
            }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        public int ProduktId
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void CtlVmKriterien_Load(object sender, EventArgs e)
        {
            if (DesignerMode)
            {
                return;
            }

            colVmMandatstypCode.ColumnEdit = grdVmBewertung.GetLOVLookUpEdit("VmMandatstyp");
            colVmMandatstypBewilligtCode.ColumnEdit = grdVmBewertung.GetLOVLookUpEdit("VmMandatstyp");

            _rightBewilligung = DBUtil.UserHasRight("VmFallgewichtungBewilligung");

            btnBewilligung.Visible = _rightBewilligung;
            btnAdmin.Visible = _rightBewilligung;

            _toleranzTage = (int)DBUtil.GetConfigValue(@"System\Vormundschaft\Bewertung\ToleranzTage", 10);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var dlg = new DlgVmBewertungAdmin();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (Parent is CtlFrmVmBewertung)
                {
                    ((CtlFrmVmBewertung)Parent).UpdateMandanten();
                }

                qryVmBewertung.Refresh();
                DisplayBewertungen();
            }
        }

        private void btnBewilligung_Click(object sender, EventArgs e)
        {
            if (qryVmBewertung.Count == 0)
            {
                return;
            }

            qryVmBewertung[DBO.VmBewertung.VmMandatstypBewilligtCode] = qryVmBewertung[DBO.VmBewertung.VmMandatstypCode];
            qryVmBewertung.RefreshDisplay();
        }

        private void edtKriterien_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            qryVmBewertung.RowModified = true;
        }

        private void qryVmBewertung_AfterFill(object sender, EventArgs e)
        {
            SelectProperVmBewertungEntry();
        }

        private void qryVmBewertung_AfterPost(object sender, EventArgs e)
        {
            qryVmBewertung["SAR"] = Session.User.LastName + ", " + Session.User.FirstName;

            if (Parent is CtlFrmVmBewertung)
            {
                ((CtlFrmVmBewertung)Parent).UpdateMandanten();
            }
        }

        private void qryVmBewertung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtVmMandatstypCode, KissMsg.GetMLMessage(typeof(CtlVmKriterien).Name, "Bewertung", "Bewertung"));
            string[] arr;

            if (_showProdukte)
            {
                arr = new[]
                          {
                              edtKriterienA.EditValue,
                              edtKriterienB.EditValue,
                              edtKriterienC.EditValue,
                              edtKriterienD.EditValue,
                              edtKriterienE.EditValue
                          };
            }
            else
            {
                arr = new[]
                          {
                              edtKriterienA.EditValue,
                              edtKriterienB.EditValue,
                              edtKriterienC.EditValue,
                              edtKriterienD.EditValue
                          };
            }

            var kriterienCodes = "";

            foreach (var s in arr.Where(s => s != ""))
            {
                if (kriterienCodes != "")
                {
                    kriterienCodes += ",";
                }

                kriterienCodes += s;
            }

            qryVmBewertung[DBO.VmBewertung.VmKriterienCodes] = kriterienCodes;

            if (_showProdukte)
            {
                qryVmBewertung[DBO.VmBewertung.VmKriterienListe] =
                    new String('A', edtKriterienA.CheckedIndices.Count) +
                    new String('B', edtKriterienB.CheckedIndices.Count) +
                    new String('C', edtKriterienC.CheckedIndices.Count) +
                    new String('D', edtKriterienD.CheckedIndices.Count) +
                    new String('E', edtKriterienE.CheckedIndices.Count);
            }
            else
            {
                qryVmBewertung[DBO.VmBewertung.VmKriterienListe] =
                    new String('A', edtKriterienA.CheckedIndices.Count) +
                    new String('B', edtKriterienB.CheckedIndices.Count) +
                    new String('C', edtKriterienC.CheckedIndices.Count) +
                    new String('D', edtKriterienD.CheckedIndices.Count);
            }

            if (!_rightBewilligung)
            {
                qryVmBewertung[DBO.VmBewertung.UserID] = Session.User.UserID;
            }

            //falls gewichtung verändert wurde: bewilligung löschen
            if (!DBUtil.IsEmpty(qryVmBewertung[DBO.VmBewertung.VmMandatstypBewilligtCode]))
            {
                if (qryVmBewertung[DBO.VmBewertung.VmMandatstypCode].ToString() != qryVmBewertung[DBO.VmBewertung.VmMandatstypBewilligtCode].ToString())
                {
                    qryVmBewertung[DBO.VmBewertung.VmMandatstypBewilligtCode] = DBNull.Value;
                }
            }

            qryVmBewertung[DBO.VmBewertung.Datum] = DateTime.Today;
            qryVmBewertung[DBO.VmBewertung.FaLeistungID] = _faLeistungId;

            if (_showProdukte)
            {
                qryVmBewertung[DBO.VmBewertung.ProduktID] = ProduktId;
            }
        }

        private void qryVmBewertung_PositionChanged(object sender, EventArgs e)
        {
            edtKriterienA.EditValue = qryVmBewertung[DBO.VmBewertung.VmKriterienCodes].ToString();
            edtKriterienB.EditValue = qryVmBewertung[DBO.VmBewertung.VmKriterienCodes].ToString();
            edtKriterienC.EditValue = qryVmBewertung[DBO.VmBewertung.VmKriterienCodes].ToString();
            edtKriterienD.EditValue = qryVmBewertung[DBO.VmBewertung.VmKriterienCodes].ToString();

            if (_showProdukte)
            {
                edtKriterienE.EditValue = qryVmBewertung[DBO.VmBewertung.VmKriterienCodes].ToString();
            }

            qryVmBewertung.RowModified = false;

            // keine Fallgewichtung in der Vergangenheit
            qryVmBewertung.EnableBoundFields(false);
            btnBewilligung.Enabled = false;

            try
            {
                // neuere Bewertung für die gleiche Leistung überprüfen
                var neuereBewertung = DBUtil.ExecuteScalarSQL(@"
                        SELECT TOP 1 1
                        FROM dbo.VmBewertung
                        WHERE FaLeistungID = {0}
                          AND ((VmFallgewichtungJahr = {1} AND VmFallgewichtungStichtagCode > {2}) OR VmFallgewichtungJahr > {1});",
                        qryVmBewertung[DBO.VmBewertung.FaLeistungID],
                        qryVmBewertung[DBO.VmBewertung.VmFallgewichtungJahr],
                        qryVmBewertung[DBO.VmBewertung.VmFallgewichtungStichtagCode]);

                // Bewilligung möglich wenn in Zukunft (-Toleranz) oder wenn Spezialrecht gegeben und noch keine neueren Einträge
                if ((DateTime.Today.AddDays(-_toleranzTage) < (DateTime)qryVmBewertung["Stichdatum"]) ||
                    (_rightBewilligung && DBUtil.IsEmpty(neuereBewertung)))
                {
                    qryVmBewertung.EnableBoundFields(true);
                    btnBewilligung.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error in qryVmBewertung_PositionChanged(...)", ex.Message);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            // Keinen Datensatz anlegen wenn keine Person ausgewählt
            if (_faLeistungId == 0)
            {
                KissMsg.ShowError(Name, "CannotAddDataNoFaLeistungID", "Es kann kein neuer Datensatz hinzugefügt werden.", "_faLeistungID == 0");
                return false;
            }

            bool mayRead, mayInsert, mayUpdate, mayDelete;
            Session.GetUserRight(typeof(CtlVmKriterien).Name, out mayRead, out mayInsert, out mayUpdate, out mayDelete);

            if (!mayInsert)
            {
                KissMsg.ShowError(Name, "CannotAddDataNoRights", "Das Einfügen eines Datensatzes ist nicht erlaubt!", "mayInsert = false");
                return false;
            }

            if (!qryVmBewertung.Post())
            {
                return false;
            }

            object stichtagCode;

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 VBW.*
                FROM VmBewertung         VBW
                  INNER JOIN FaLeistung  FAL ON FAL.FaLeistungID = VBW.FaLeistungID
                WHERE VBW.FaLeistungID = {0}" + (_showProdukte ? @"
                  AND VBW.ProduktID = {1}" : string.Empty) + @"
                ORDER BY VBW.VmFallgewichtungJahr DESC, VBW.VmFallgewichtungStichtagCode DESC",
                _faLeistungId, ProduktId);

            if (qry.Count == 0)
            {
                //nächstgelegenes Stichdatum bestimmen
                stichtagCode = DBUtil.ExecuteScalarSQL(@"
                    select	top 1 Code --convert(datetime,Text + {0},104)
                    from	XLOVCode
                    where	LOVName = 'VmFallgewichtungStichtag'
                    order by abs(datediff(d,convert(datetime,Text + {0},104),getdate()))",
                    DateTime.Today.Year.ToString());

                if (_showProdukte)
                {
                    DBUtil.ExecSQL(@"
                        insert VmBewertung (FaLeistungID, VmMandatstypCode, UserID, VmFallgewichtungStichtagCode, VmFallgewichtungJahr, ProduktID)
                        values ({0}, dbo.fnVmGetMandatstypCode({4}), {1}, {2}, {3}, {4})",
                        _faLeistungId,
                        Session.User.UserID,
                        stichtagCode,
                        DateTime.Today.Year,
                        ProduktId);
                }
                else
                {
                    DBUtil.ExecSQL(@"
                        insert VmBewertung (FaLeistungID, VmMandatstypCode, UserID, VmFallgewichtungStichtagCode, VmFallgewichtungJahr)
                        values ({0}, {1}, {2}, {3}, {4})",
                        FaLeistungId,
                        3, // Typ C
                        Session.User.UserID,
                        stichtagCode,
                        DateTime.Today.Year);
                }
            }
            else
            {
                int maxStichtagCode = (int)DBUtil.ExecuteScalarSQL("select max(Code) from XLOVCode where LOVName = 'VmFallgewichtungStichtag'");

                int jahr;
                if (maxStichtagCode == (int)qry["VmFallgewichtungStichtagCode"])
                {
                    stichtagCode = 1;
                    jahr = ((int)qry["VmFallgewichtungJahr"]) + 1;
                }
                else
                {
                    stichtagCode = ((int)qry["VmFallgewichtungStichtagCode"]) + 1;
                    jahr = (int)qry["VmFallgewichtungJahr"];
                }

                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.VmBewertung (FaLeistungID, VmMandatstypCode, UserID, VmFallgewichtungStichtagCode,
                                                 VmFallgewichtungJahr, VmKriterienCodes, VmKriterienListe, ProduktID)
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});",
                    FaLeistungId,
                    qry["VmMandatstypCode"],
                    Session.User.UserID,
                    stichtagCode,
                    jahr,
                    qry["VmKriterienCodes"],
                    qry["VmKriterienListe"],
                    _showProdukte ? (int?)ProduktId : null);
            }

            DisplayBewertungen();
            return true;
        }

        /// <summary>
        /// Resets the assigned VmBewertungID without reloading any data
        /// </summary>
        public void ResetVmBewertungIdWithoutReload()
        {
            _vmBewertungId = 0;
        }

        /// <summary>
        /// Selects proper entry in list depending on current values
        /// </summary>
        public void SelectProperVmBewertungEntry()
        {
            if (_vmBewertungId > 0)
            {
                // positionieren auf VmBewertungID
                if (qryVmBewertung.Find(string.Format("VmBewertungID = {0}", _vmBewertungId)))
                {
                    // we found it!
                    return;
                }
            }

            // positionieren auf ersten unbewerteten Eintrag
            while (!DBUtil.IsEmpty(qryVmBewertung["VmMandatstypCode"]))
            {
                if (!qryVmBewertung.Next())
                {
                    break;
                }
            }
        }

        public void SetVmBewertungId(int vmBewertungId, int faLeistungId)
        {
            _faLeistungId = faLeistungId;
            _vmBewertungId = vmBewertungId;
            DisplayBewertungen();
        }

        #endregion

        #region Private Methods

        private void DisplayBewertungen()
        {
            if (_showProdukte)
            {
                SetLOVKriterien();
            }
            else
            {
                lblKriterienE.Visible = false;
                edtKriterienE.Visible = false;
            }

            qryVmBewertung.Fill(@"
                SELECT VBW.*,
                       SAR        = USR.LastName + ISNULL(', ' + USR.FirstName, ''),
                       Stichtag   = STI.Text + CONVERT(VARCHAR, VBW.VmFallgewichtungJahr),
                       Stichdatum = CONVERT(DATETIME, STI.Text + CONVERT(VARCHAR, VBW.VmFallgewichtungJahr), 104)
                FROM dbo.VmBewertung        VBW WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = VBW.FaLeistungID
                  LEFT  JOIN dbo.XUser      USR WITH (READUNCOMMITTED) ON USR.UserID = VBW.UserID
                  LEFT  JOIN dbo.XLOVCode   STI WITH (READUNCOMMITTED) ON STI.LOVName = 'VmFallgewichtungStichtag'
                                                                      AND STI.Code = VBW.VmFallgewichtungStichtagCode
                WHERE VBW.FaLeistungID = {0}" + (_showProdukte ? @"
                  AND VBW.ProduktID = {1}" : string.Empty) + @"
                ORDER BY Stichdatum;", _faLeistungId, ProduktId);
        }

        private void SetLOVKriterien()
        {
            try
            {
                edtKriterienA.LOVFilter = "0";
                edtKriterienB.LOVFilter = "0";
                edtKriterienC.LOVFilter = "0";
                edtKriterienD.LOVFilter = "0";
                edtKriterienE.LOVFilter = "0";
                edtKriterienA.Visible = false;
                edtKriterienB.Visible = false;
                edtKriterienC.Visible = false;
                edtKriterienD.Visible = false;
                edtKriterienE.Visible = false;

                switch (ProduktId)
                {
                    case 2: //"Private Mandate":
                        edtKriterienA.LOVFilter = "5";
                        edtKriterienA.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "2";
                        break;

                    case 1: //"Vormundschaftliche Mandate":
                        edtKriterienB.LOVFilter = "1";
                        edtKriterienC.LOVFilter = "2";
                        edtKriterienD.LOVFilter = "3";
                        edtKriterienE.LOVFilter = "4";
                        edtKriterienB.Visible = true;
                        edtKriterienC.Visible = true;
                        edtKriterienD.Visible = true;
                        edtKriterienE.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "3";
                        break;

                    case 3: //"VM Abklärungen":
                        edtKriterienB.LOVFilter = "6";
                        edtKriterienC.LOVFilter = "7";
                        edtKriterienD.LOVFilter = "8";
                        edtKriterienE.LOVFilter = "9";
                        edtKriterienB.Visible = true;
                        edtKriterienC.Visible = true;
                        edtKriterienD.Visible = true;
                        edtKriterienE.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "3";
                        break;

                    case 4: //"Vaterschaftsabklärung: Neu und Aberkennungsklage":
                        edtKriterienA.LOVFilter = "10";
                        edtKriterienB.LOVFilter = "11";
                        edtKriterienC.LOVFilter = "12";
                        edtKriterienA.Visible = true;
                        edtKriterienB.Visible = true;
                        edtKriterienC.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "4";
                        break;

                    case 10: //"Kinderzuteilungsberichte":
                        edtKriterienA.LOVFilter = "26";
                        edtKriterienB.LOVFilter = "27";
                        edtKriterienC.LOVFilter = "28";
                        edtKriterienA.Visible = true;
                        edtKriterienB.Visible = true;
                        edtKriterienC.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "4";
                        break;

                    case 11: //"Kontrolle Kindsvermögen":
                        edtKriterienA.LOVFilter = "29";
                        edtKriterienB.LOVFilter = "22";
                        edtKriterienA.Visible = true;
                        edtKriterienB.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "5";
                        break;

                    case 7: //"Besuchsrechtsregelungen":
                        edtKriterienA.LOVFilter = "17";
                        edtKriterienB.LOVFilter = "18";
                        edtKriterienC.LOVFilter = "19";
                        edtKriterienA.Visible = true;
                        edtKriterienB.Visible = true;
                        edtKriterienC.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "4";
                        break;

                    case 5: //"Unterhaltsverträge: Abänderungen":
                        edtKriterienA.LOVFilter = "13";
                        edtKriterienB.LOVFilter = "14";
                        edtKriterienA.Visible = true;
                        edtKriterienB.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "5";
                        break;

                    case 6: //"Scheidungsurteil":
                        edtKriterienA.LOVFilter = "15";
                        edtKriterienB.LOVFilter = "16";
                        edtKriterienA.Visible = true;
                        edtKriterienB.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "5";
                        break;

                    case 9: //"Adoptionserklärungen":
                        edtKriterienB.LOVFilter = "23";
                        edtKriterienC.LOVFilter = "24";
                        edtKriterienD.LOVFilter = "25";
                        edtKriterienB.Visible = true;
                        edtKriterienC.Visible = true;
                        edtKriterienD.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "6";
                        break;

                    case 8: //"psB":
                        edtKriterienB.LOVFilter = "20";
                        edtKriterienC.LOVFilter = "21";
                        edtKriterienB.Visible = true;
                        edtKriterienC.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "7";
                        break;

                    case 12: //"Erbschaft":
                        edtKriterienA.LOVFilter = "30";
                        edtKriterienA.Visible = true;
                        edtVmMandatstypCode.LOVFilter = "2";
                        break;
                }

                edtKriterienA.LOVName = "VmKriterien";
                edtKriterienB.LOVName = "VmKriterien";
                edtKriterienC.LOVName = "VmKriterien";
                edtKriterienD.LOVName = "VmKriterien";
                edtKriterienE.LOVName = "VmKriterien";
                edtVmMandatstypCode.LOVName = "VmMandatstyp";
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error in SetLOVKriterien()", ex.Message);
            }
        }

        #endregion

        #endregion
    }
}