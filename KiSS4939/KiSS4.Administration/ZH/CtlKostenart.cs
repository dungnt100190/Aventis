using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Administration.ZH
{
    public partial class CtlKostenart : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlKostenart";
        private const string KEYPATH_ZUSAETZLICHE_LA = @"System\WH\Klientenkontoabrechnung_zusaetzliche_LAs";
        private const string QRY_AUS_DATUM_BIS = "DatumBis";
        private const string QRY_AUS_DATUM_VON = "DatumVon";
        private const string QRY_AUS_KONTO_NR = "KontoNr";
        private readonly ModulID _modul;

        #endregion

        #region Private Fields

        private List<AusgeschlossenerZeitraumDto> _ausgeschlossenerZeitraumDtos;
        private bool _saveAuszuschliessendeLa;

        #endregion

        #endregion

        #region Constructors

        public CtlKostenart(ModulID modul)
            : this()
        {
            _modul = modul;
        }

        public CtlKostenart()
        {
            InitializeComponent();

            colBgSplittingartCode.ColumnEdit = grdBgKostenart.GetLOVLookUpEdit((SqlQuery)edtBgSplittingArtCode.Properties.DataSource);
            colFaFachbereichCode.ColumnEdit = grdBgKostenart.GetLOVLookUpEdit((SqlQuery)edtFaFachbereichCode.Properties.DataSource);

            SetupDataMembers();
        }

        #endregion

        #region EventHandlers

        private void CtlKostenart_Load(object sender, EventArgs e)
        {
            LoadFromXConfig();

            qryBgKostenart.PostCompleted += qryBgKostenart_PostCompleted;
            qryBgKostenart.Fill((int)_modul);

            // always select Koa-tab first
            tabControl.SelectTab(tpgKostenart);
        }

        private void editReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!qryBgKostenart.Post())
            {
                return;
            }

            var editable = !editReadOnly.Checked;

            qryBgKostenart.CanDelete = editable;
            qryBgKostenart.CanInsert = editable;
            qryBgKostenart.CanUpdate = editable;

            qryBgKostenart.ApplyUserRights();
            qryBgKostenart.Refresh();
        }

        private void edtBaZahlungswegIDFix_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtBaZahlungswegIDFix.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgKostenart["KreditorFix"] = DBNull.Value;
                    qryBgKostenart["BaZahlungswegIDFix"] = DBNull.Value;
                }
            }

            using (var dlg = new KissLookupDialog())
            {
                e.Cancel = !dlg.SearchData(@"
                    SELECT ID$         = KRE.BaZahlungswegID,
                           Institution = KRE.InstitutionName,
                           Zahlungsweg = KRE.Zahlungsweg,
                           Kreditor$   = KRE.InstitutionName + IsNull(', ' + KRE.InstitutionAdresse,'') + IsNull(', ' + KRE.Zahlungsweg,'')
                    FROM dbo.vwKreditor KRE
                      INNER JOIN dbo.BaInstitution INS ON INS.BaInstitutionID = KRE.BaInstitutionID
                    WHERE KRE.InstitutionName LIKE '%' + {0} + '%'
                      AND INS.Aktiv = 1
                      AND INS.Kreditor = 1
                      AND KRE.BaFreigabeStatusCode = 2 -- definitiv
                      AND KRE.ZahlungswegBaFreigabeStatusCode = 2;",
                    searchString,
                    e.ButtonClicked,
                    null,
                    null,
                    null);

                if (!e.Cancel)
                {
                    qryBgKostenart["KreditorFix"] = dlg["Kreditor$"];
                    qryBgKostenart["BaZahlungswegIDFix"] = dlg["ID$"];
                }
                else
                {
                    qryBgKostenart["KreditorFix"] = DBNull.Value;
                    qryBgKostenart["BaZahlungswegIDFix"] = DBNull.Value;
                }
            }
        }

        private void qryAuszuschliessendeLA_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            _saveAuszuschliessendeLa = true;
        }

        private void qryAuszuschliessendeLA_PositionChanged(object sender, EventArgs e)
        {
            SetEditModeAuszuschliessendeLa();
        }

        private void qryAuszuschliessendeLA_PositionChanging(object sender, EventArgs e)
        {
            AcceptChanges(qryAuszuschliessendeLA);
        }

        private void qryBgKostenart_AfterInsert(object sender, EventArgs e)
        {
            qryBgKostenart["ModulID"] = (int)_modul;

            edtBgKostenartID.Focus();
        }

        private void qryBgKostenart_BeforePost(object sender, EventArgs e)
        {
            // Convert BelegartCode to Belegart
            var lookupRow = ((SqlQuery)edtBelegart.Properties.DataSource).DataTable
                                                                         .Select(string.Format("Code={0}", qryBgKostenart["BelegartCode"]))
                                                                         .FirstOrDefault();
            if (lookupRow != null)
            {
                qryBgKostenart["Belegart"] = lookupRow["Text"];
            }
            DBUtil.CheckNotNullField(edtName, lblName.Text);
        }

        private void qryBgKostenart_PositionChanged(object sender, EventArgs e)
        {
            SetEditModeAuszuschliessendeLa();

            if (tabControl.SelectedTab == tpgKlientenkontoabrechnung)
            {
                FillAuszuschliessendeLaQuery();
            }
        }

        private void qryBgKostenart_PositionChanging(object sender, EventArgs e)
        {
            AcceptChanges(qryAuszuschliessendeLA);

            SaveToXConfig();
        }

        private void qryBgKostenart_PostCompleted(object sender, EventArgs e)
        {
            qryBgKostenart.Refresh();
        }

        private void tabControl_SelectedTabChanged(TabPageEx page)
        {
            AcceptChanges(qryAuszuschliessendeLA);

            if (page == tpgKlientenkontoabrechnung)
            {
                FillAuszuschliessendeLaQuery();
            }
            else
            {
                SaveToXConfig();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            // Insert either BgKostenart or config-value
            if (tabControl.SelectedTab == tpgKostenart)
            {
                return base.OnAddData();
            }

            _saveAuszuschliessendeLa = true;
            return qryAuszuschliessendeLA.Insert() != null;
        }

        public override bool OnDeleteData()
        {
            if (tabControl.SelectedTab == tpgKostenart)
            {
                return base.OnDeleteData();
            }

            _saveAuszuschliessendeLa = true;
            return qryAuszuschliessendeLA.Delete();
        }

        public override bool OnSaveData()
        {
            bool retVal = base.OnSaveData();
            SaveToXConfig();
            return retVal;
        }

        #endregion

        #region Private Static Methods

        private static void AcceptChanges(SqlQuery qry)
        {
            qry.RowModified = false;
            qry.DataSet.AcceptChanges();
        }

        #endregion

        #region Private Methods

        private void AddConfigValuesForDate(Dictionary<DateTime, List<string>> configValues, DateTime datumVonXConfig)
        {
            if (configValues.ContainsKey(datumVonXConfig))
            {
                return;
            }

            var validKontos = (from x in _ausgeschlossenerZeitraumDtos
                               where x.DatumVon <= datumVonXConfig
                               where (x.DatumBis ?? DateTime.MaxValue) >= datumVonXConfig
                               orderby x.KontoNr
                               select x.KontoNr).ToList();

            configValues.Add(datumVonXConfig, validKontos);
        }

        private void FillAuszuschliessendeLaQuery()
        {
            qryAuszuschliessendeLA.Refresh();

            var rows = _ausgeschlossenerZeitraumDtos.Where(x => x.KontoNr == Utils.ConvertToString(qryBgKostenart[DBO.BgKostenart.KontoNr]));

            var canInsert = qryAuszuschliessendeLA.CanInsert;

            foreach (var dto in rows)
            {
                qryAuszuschliessendeLA.CanInsert = true;
                qryAuszuschliessendeLA.Insert();
                qryAuszuschliessendeLA[QRY_AUS_DATUM_VON] = dto.DatumVon;
                qryAuszuschliessendeLA[QRY_AUS_DATUM_BIS] = dto.DatumBis;
                qryAuszuschliessendeLA[QRY_AUS_KONTO_NR] = dto.KontoNr;

                qryAuszuschliessendeLA.RowModified = false;
                qryAuszuschliessendeLA.DataSet.AcceptChanges();
            }

            qryAuszuschliessendeLA.CanInsert = canInsert;
            _saveAuszuschliessendeLa = false;
        }

        private void LoadFromXConfig()
        {
            // Fill dummy query
            qryAuszuschliessendeLA.Fill(@"
                SELECT TOP 0
                  DatumVon = CAST(NULL AS DATETIME),
                  DatumBis = CAST(NULL AS DATETIME),
                  KontoNr  = CAST(NULL AS VARCHAR(10));");

            // Get all config values
            var qryXConfig = DBUtil.OpenSQL(@"
                SELECT
                  CFG.DatumVon,
                  CFG.ValueVarchar,
                  DatumBis = (SELECT TOP 1 DATEADD(DAY, -1, DatumVon)
                              FROM dbo.XConfig SUB WITH(READUNCOMMITTED)
                              WHERE SUB.KeyPath = CFG.KeyPath
                                AND SUB.XConfigID <> CFG.XConfigID
                                AND SUB.DatumVon >= CFG.DatumVon
                              ORDER BY SUB.DatumVon)
                FROM dbo.XConfig CFG WITH(READUNCOMMITTED)
                WHERE CFG.KeyPath = {0}
                ORDER BY CFG.DatumVon;",
                KEYPATH_ZUSAETZLICHE_LA);

            _ausgeschlossenerZeitraumDtos = new List<AusgeschlossenerZeitraumDto>();

            // create a DTO for each config value and KontoNr
            foreach (DataRow row in qryXConfig.DataTable.Rows)
            {
                var datumVon = Utils.ConvertToDateTime(row[DBO.XConfig.DatumVon]);
                var valueVar = row[DBO.XConfig.ValueVarchar];

                // Value has to be set
                if (DBUtil.IsEmpty(valueVar))
                {
                    continue;
                }

                var kontoNrList = valueVar.ToString().Split(',');

                // Create DTOs for every Konto-Nr
                foreach (var kontoNr in kontoNrList)
                {
                    var datumBis = row["DatumBis"];
                    _ausgeschlossenerZeitraumDtos.Add(new AusgeschlossenerZeitraumDto
                    {
                        DatumVon = datumVon,
                        DatumBis = (DBUtil.IsEmpty(datumBis) ? null : datumBis as DateTime?),
                        KontoNr = kontoNr
                    });
                }
            }
        }

        private void SaveToXConfig()
        {
            if (_saveAuszuschliessendeLa)
            {
                // remove old entries with this
                var kontoNr = Utils.ConvertToString(qryBgKostenart[DBO.BgKostenart.KontoNr]);
                _ausgeschlossenerZeitraumDtos.RemoveAll(x => x.KontoNr == kontoNr);

                // add DTOs with current values
                foreach (DataRow row in qryAuszuschliessendeLA.DataTable.Rows)
                {
                    var datumVon = row[QRY_AUS_DATUM_VON];

                    if (DBUtil.IsEmpty(datumVon))
                    {
                        continue;
                    }

                    var datumBis = row[QRY_AUS_DATUM_BIS];
                    AusgeschlossenerZeitraumDto tmp = new AusgeschlossenerZeitraumDto
                    {
                        DatumVon = Utils.ConvertToDateTime(datumVon),
                        DatumBis =
                                                                  (DBUtil.IsEmpty(datumBis) ? null : datumBis) as
                                                                  DateTime?,
                        KontoNr = kontoNr
                    };
                    if (tmp.DatumVon > tmp.DatumBis)
                    {
                        KissMsg.ShowInfo(CLASSNAME, "DatumVonGroesserDatumBis", "Das 'Datum Von' liegt nach dem 'Datum Bis'");
                        throw new KissCancelException();
                    }
                    if (_ausgeschlossenerZeitraumDtos.Any(x => x.KontoNr == tmp.KontoNr && (x.DatumVon <= (tmp.DatumBis ?? DateTime.MaxValue) && (x.DatumBis ?? DateTime.MaxValue) >= tmp.DatumVon)))
                    {
                        KissMsg.ShowInfo(CLASSNAME, "DatumBereichUeberschneidung", "In diesem Datumsbereich gibt es eine Überschneidung.");
                        throw new KissCancelException();
                    }

                    _ausgeschlossenerZeitraumDtos.Add(tmp);
                }

                // Flatten DTOs and save to XConfig
                var configValues = new Dictionary<DateTime, List<string>>();
                var ordered = _ausgeschlossenerZeitraumDtos.OrderBy(x => x.DatumVon).ThenBy(x => x.KontoNr).ToList();

                // create for each different DatumVon and 'DatumBis + 1 Day' an entry in configValues
                foreach (var dto in ordered)
                {
                    AddConfigValuesForDate(configValues, dto.DatumVon);

                    if (dto.DatumBis.HasValue)
                    {
                        AddConfigValuesForDate(configValues, dto.DatumBis.Value.AddDays(1));
                    }
                }

                // Remove duplicates
                var orderedConfigValues = configValues.OrderBy(x => x.Key).ToList();

                if (orderedConfigValues.Count > 1)
                {
                    for (int i = 1; i < orderedConfigValues.Count; i++)
                    {
                        if (orderedConfigValues[i].Value.All(x => orderedConfigValues[i - 1].Value.Contains(x)) &&
                            orderedConfigValues[i - 1].Value.All(x => orderedConfigValues[i].Value.Contains(x)))
                        {
                            configValues.Remove(orderedConfigValues[i].Key);
                        }
                    }
                }

                // Insert values on database
                try
                {
                    Session.BeginTransaction();

                    DBUtil.ExecSQLThrowingException(@"
                        DELETE FROM dbo.XConfig
                        WHERE KeyPath = {0};", KEYPATH_ZUSAETZLICHE_LA);

                    var nseId = DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT XNamespaceExtensionID
                        FROM dbo.XNamespaceExtension
                        WHERE NamespaceExtension = 'ZH';");

                    foreach (var configValue in configValues)
                    {
                        var valueVar = string.Join(",", configValue.Value);

                        DBUtil.ExecSQLThrowingException(@"
                            INSERT INTO dbo.XConfig (KeyPath, ValueVarchar, DatumVon, XNamespaceExtensionID, ValueCode, Description, System)
                              VALUES ({0}, {1}, {2}, {3}, 1, 'LAs, die Standardmässig nicht in der Klientenkontoabrechnung verwendet werden, aber durch den Benutzer hinzugefügt werden können.', 0);",
                            KEYPATH_ZUSAETZLICHE_LA,
                            valueVar,
                            configValue.Key,
                            nseId);
                    }

                    Session.Commit();
                    _saveAuszuschliessendeLa = false;
                }
                catch
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }

                    throw;
                }
            }
        }

        private void SetEditModeAuszuschliessendeLa()
        {
            var editable = !editReadOnly.Checked;

            qryAuszuschliessendeLA.CanDelete = editable;
            qryAuszuschliessendeLA.CanInsert = editable;
            qryAuszuschliessendeLA.CanUpdate = editable;

            qryAuszuschliessendeLA.EnableBoundFields(editable);
        }

        private void SetupDataMembers()
        {
            colAuszuschliessendDatumVon.FieldName = QRY_AUS_DATUM_VON;
            colAuszuschliessendDatumBis.FieldName = QRY_AUS_DATUM_BIS;
            edtAuszuschliessendDatumVon.DataMember = QRY_AUS_DATUM_VON;
            edtAuszuschliessendDatumBis.DataMember = QRY_AUS_DATUM_BIS;
        }

        #endregion

        #endregion

        #region Nested Types

        private class AusgeschlossenerZeitraumDto
        {
            #region Properties

            public DateTime? DatumBis
            {
                get;
                set;
            }

            public DateTime DatumVon
            {
                get;
                set;
            }

            public string KontoNr
            {
                get;
                set;
            }

            #endregion
        }

        #endregion
    }
}