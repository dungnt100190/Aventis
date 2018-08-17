using System;
using System.Data;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmRevisionen.
    /// </summary>
    public partial class CtlVmRevisionen : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlVmRevisionen()
        {
            InitializeComponent();
            SetDataMembers();
        }

        #endregion

        #region EventHandlers

        private void CtlVmRevisionen_Load(object sender, EventArgs e)
        {
            DBUtil.ApplyFallRightsToSqlQuery(_faLeistungID, qryVmBericht);

            qryVmBericht.Fill(_faLeistungID);

            if (qryVmBericht.Count == 0)
            {
                DisplayInfo();
            }
        }

        private void edtBerichtsperiodeVon_EditValueChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtBerichtsperiodeBis.EditValue))
            {
                var datumVon = edtBerichtsperiodeVon.EditValue;

                if (!DBUtil.IsEmpty(datumVon))
                {
                    // 2 Jahre hinzufügen
                    var datumBis = (DateTime)datumVon;
                    edtBerichtsperiodeBis.EditValue = datumBis.AddYears(2).Subtract(TimeSpan.FromDays(1));
                }
            }
        }

        private void qryVmBericht_AfterInsert(object sender, EventArgs e)
        {
            // Datumvorschlag neue Berichtsperiode
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT MAX(VBR.BerichtsperiodeBis) MaxDatum
                FROM dbo.VmBericht VBR WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0};", _faLeistungID);

            if (!DBUtil.IsEmpty(qry["MaxDatum"]))
            {
                qryVmBericht["BerichtsperiodeVon"] = ((DateTime)qry["MaxDatum"]).AddDays(1);
                qryVmBericht["BerichtsperiodeBis"] = ((DateTime)qry["MaxDatum"]).AddYears(2);
            }

            qryVmBericht["FaLeistungID"] = _faLeistungID;
            DisplayInfo();

            edtBerichtsperiodeVon.Focus();
        }

        private void qryVmBericht_AfterPost(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void qryVmBericht_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBerichtsperiodeVon, KissMsg.GetMLMessage(Name, "PeriodeVon", "Berichtsperiode von"));
            DBUtil.CheckNotNullField(edtBerichtsperiodeBis, KissMsg.GetMLMessage(Name, "PeriodeBis", "Berichtsperiode bis"));

            // check: Datum-Überschhneidung
            int count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.VmBericht WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0}
                  AND ({1} BETWEEN BerichtsperiodeVon AND BerichtsperiodeBis OR
                       {2} BETWEEN BerichtsperiodeVon AND BerichtsperiodeBis)
                  AND ISNULL({3}, -1) <> VmBerichtID;",
                _faLeistungID,
                qryVmBericht["BerichtsperiodeVon"],
                qryVmBericht["BerichtsperiodeBis"],
                qryVmBericht["VmBerichtID"]);

            if (count > 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(
                    Name,
                    "UeberschneidungMitPeriode",
                    "Der Datumsbereich der neuen/veränderten Berichtsperiode überschneidet sich mit einer anderen Berichtsperiode",
                    KissMsgCode.MsgInfo));
            }
        }

        private void qryVmBericht_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            // Damit Änderungen während des AfterInsert-Events einen Post bewirken,
            // auch wenn der Benutzer keine weiteren Eingaben macht
            qryVmBericht.RowModified = true;
        }

        private void qryVmBericht_PositionChanged(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "VMBERICHTID":
                    if (qryVmBericht.Count > 0)
                        return qryVmBericht["VmBerichtID"];
                    break;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string title, Image icon, int faLeistungID)
        {
            lblTitel.Text = title;
            picTitel.Image = icon;

            _faLeistungID = faLeistungID;

            lblZGB.Text = "";
        }

        #endregion

        #region Private Methods

        private void DisplayInfo()
        {
            //Mandant (mit separatem Mandantenstamm)
            qryInfoMandant.Fill(_faLeistungID);

            //Massnahme
            if (qryVmBericht.Count == 0)
                qryInfoMassnahme.Fill(@"
                    SELECT TOP 1
                           VMN.VmMassnahmeID,
                           DatumVon = convert(varchar,VMN.DatumVon,104),
                           DatumBis = convert(varchar,VMN.DatumBis,104),
                           VMN.ZGBCodes
                    FROM dbo.VmMassnahme VMN WITH(READUNCOMMITTED)
                    WHERE VMN.FaLeistungID = {0}
                      AND VMN.IsDeleted = 0
                    ORDER BY DatumVon DESC;", _faLeistungID);
            else
                qryInfoMassnahme.Fill(@"
                    SELECT TOP 1
                           VMN.VmMassnahmeID,
                           DatumVon = convert(varchar,VMN.DatumVon,104),
                           DatumBis = convert(varchar,VMN.DatumBis,104),
                           VMN.ZGBCodes
                    FROM dbo.VmBericht VBR WITH(READUNCOMMITTED)
                      INNER JOIN FaLeistung  FAL  ON FAL.FaLeistungID = VBR.FaLeistungID
                      INNER JOIN VmMassnahme VMN  ON VMN.FaLeistungID = FAL.FaLeistungID
                                                 AND VMN.VmMassnahmeID = (SELECT TOP 1
                                                                                 VmMassnahmeID
                                                                          FROM dbo.VmMassnahme
                                                                          WHERE FaLeistungID = FAL.FaLeistungID
                                                                            AND VBR.BerichtsperiodeBis BETWEEN DatumVon AND ISNULL(DatumBis, VBR.BerichtsperiodeBis)
                                                                            AND IsDeleted = 0)
                    WHERE VBR.VmBerichtID = {0}
                      AND VMN.IsDeleted = 0
                    ORDER BY VMN.DatumVon DESC;", qryVmBericht["VmBerichtID"]);

            // ZGB
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Text
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'VmZGB'
                   AND ',' + {0} + ',' LIKE '%,' + convert(varchar,Code) + ',%'
                ORDER BY SortKey;", qryInfoMassnahme["ZGBCodes"]);

            string zgb = "";

            foreach (DataRow row in qry.DataTable.Rows)
            {
                if (zgb != "")
                {
                    zgb += "\r\n";
                }

                zgb += row["Text"].ToString();
            }

            lblZGB.Text = zgb;

            //MT + Ernennung
            int vmMassnahmeID = -1;

            if (qryInfoMassnahme.Count > 0)
            {
                vmMassnahmeID = (int)qryInfoMassnahme["VmMassnahmeID"];
            }

            qryInfoMt.Fill(vmMassnahmeID);
        }

        private void SetDataMembers()
        {
            edtEntschaedigung.DataMember = DBO.VmBericht.Entschaedigung;
        }

        #endregion

        #endregion
    }
}