using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public partial class DlgKbBelegeKorrigierenNeueWerte : KissDialog
    {
        private readonly BelegeKorrigierenHelper _belegeKorrigierenHelper;

        public DlgKbBelegeKorrigierenNeueWerte()
        {
            InitializeComponent();
            SetupQuery();
            SetupBindings();
        }

        public DlgKbBelegeKorrigierenNeueWerte(IEnumerable<DataRow> selectedRows)
            : this()
        {
            var rowList = selectedRows.ToList();

            if (rowList.Count == 0)
            {
                Close();
                return;
            }

            _belegeKorrigierenHelper = new BelegeKorrigierenHelper(
                this,
                null,
                qryNeueWerte,
                null,
                edtValutaDatum,
                null,
                null,
                edtVerwPeriodeVon,
                edtVerwPeriodeBis,
                edtBgKostenartID,
                edtLT,
                edtBetrifftPerson,
                edtBuchungstext,
                null,
                false);

            var ltBaPersonId = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BaPersonID_LT);
            var lt = DBUtil.ExecuteScalarSQL(@"SELECT NameVorname
                                               FROM dbo.vwPerson
                                               WHERE BaPersonID = {0};", ltBaPersonId);

            // Betrifft Person
            var betrifftBaPersonIds = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.KlientBaPersonIDList) as string;
            var betrifftBaPersonId = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BetrifftBaPersonID) as int?;
            if (!betrifftBaPersonId.HasValue)
            {
                int baPersonId;
                if (int.TryParse(betrifftBaPersonIds, out baPersonId))
                {
                    betrifftBaPersonId = baPersonId;
                }
            }
            var betrifftPerson = DBUtil.ExecuteScalarSQL(@"SELECT NameVorname
                                                           FROM dbo.vwPerson
                                                           WHERE BaPersonID = {0};", betrifftBaPersonId) as string;

            // LA
            var bgKostenartId = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartID);
            var bgKostenart = DBUtil.ExecuteScalarSQL(@"
                SELECT KontoNr + ' ' + Name
                FROM dbo.BgKostenart WITH(READUNCOMMITTED)
                WHERE BgKostenartID = {0};", bgKostenartId);

            qryNeueWerte[ResultFieldNames.BetrifftBaPersonID] = betrifftBaPersonId;
            qryNeueWerte[ResultFieldNames.LTBaPersonID] = ltBaPersonId;
            qryNeueWerte[ResultFieldNames.SplittingArt] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.SplittingArt);
            qryNeueWerte[ResultFieldNames.BetrifftPerson] = betrifftPerson;
            qryNeueWerte[ResultFieldNames.LT] = lt;
            qryNeueWerte[ResultFieldNames.Storno] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.StornoCode);

            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.KbBuchungStatusCode] = rowList.Select(x => x[CtlKbBelegeKorrigierenMasse.GridFieldNames.KbBuchungStatusCode]).Max();

            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgFinanzplanID] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BgFinanzplanID);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartID] = bgKostenartId;
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Buchungstext] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Buchungstext);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.FaFallID] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.FaFallID);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.FaLeistungID] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.FaLeistungID);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.IsSiLei] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.IsSiLei);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenart] = bgKostenart;
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Quoting] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Quoting);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SplittingArtCode] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.SplittingArtCode);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Valuta] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Valuta);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeBis] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeBis);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeVon] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeVon);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Abgetreten] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Abgetreten);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Hauptvorgang] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Hauptvorgang);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Teilvorgang] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Teilvorgang);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartHauptvorgang] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartHauptvorgang);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartTeilvorgang] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartTeilvorgang);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartHauptvorgangAbtretung] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartHauptvorgangAbtretung);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartTeilvorgangAbtretung] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartTeilvorgangAbtretung);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Belegart] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Belegart);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Weiterverrechenbar] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.Weiterverrechenbar);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumVon] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumVon);
            qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumBis] = GetValueDistinct(rowList, CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumBis);
        }

        /// <summary>
        /// Gets the result row after the dialog is accepted. (null if cancelled)
        /// </summary>
        public DataRow ResultRow
        {
            get;
            private set;
        }

        private static object GetValueDistinct(IEnumerable<DataRow> rows, string fieldName)
        {
            var list = rows.Select(x => x[fieldName]).Distinct().ToList();
            return list.Count == 1 ? list[0] : null;
        }

        private void AddQueryColumn<T>(string fieldName)
        {
            qryNeueWerte.DataTable.Columns.Add(fieldName, typeof(T));
        }

        private void btnHaushalt_Click(object sender, EventArgs e)
        {
            var resultRow = BelegeKorrigierenHelper.ShowHaushaltDialog(
                Utils.ConvertToInt(qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.FaFallID]),
                qryNeueWerte[ResultFieldNames.LTBaPersonID] as int?,
                qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgFinanzplanID] as int?);

            if (resultRow != null)
            {
                qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumVon] = DBUtil.IsEmpty(resultRow["DatVonProLei"])
                    ? resultRow["DatVonKiSS"]
                    : resultRow["DatVonProLei"];
                qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumBis] = DBUtil.IsEmpty(resultRow["DatBisProLei"])
                    ? resultRow["DatBisKiSS"]
                    : resultRow["DatBisProLei"];
                qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltProleistPersonenIDs] = resultRow["PersonenIDs$"];
                qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.KlientBaPersonIDList] = resultRow["PersonenIDs$"];
                qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgFinanzplanID] = resultRow["BgFinanzplanID$"];
                qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.FaLeistungID] = resultRow["FaLeistungID"];

                UpdateGui();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ResultRow = qryNeueWerte.Row;
            DialogResult = DialogResult.OK;
        }

        private void DlgKbBelegeKorrigierenNeueWerte_Load(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void edtBetrifftPerson_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            _belegeKorrigierenHelper.ChangingData = true;
            var isSiLei = Utils.ConvertToBool(qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.IsSiLei]);
            _belegeKorrigierenHelper.BetrifftPersonUserModifiedField(e, isSiLei);
        }

        private void edtBgKostenartID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            _belegeKorrigierenHelper.ChangingData = true;
            _belegeKorrigierenHelper.KostenartUserModifiedField(e, btnHaushalt, false);
            UpdateGui();
        }

        private void edtLT_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            _belegeKorrigierenHelper.ChangingData = true;
            _belegeKorrigierenHelper.LeistungstraegerUserModifiedField(e);
        }

        private void SetupBindings()
        {
            edtBetrifftPerson.DataSource = qryNeueWerte;
            edtBuchungstext.DataSource = qryNeueWerte;
            edtBgKostenartID.DataSource = qryNeueWerte;
            edtLT.DataSource = qryNeueWerte;
            edtValutaDatum.DataSource = qryNeueWerte;
            edtVerwPeriodeBis.DataSource = qryNeueWerte;
            edtVerwPeriodeVon.DataSource = qryNeueWerte;
            edtSplittingart.DataSource = qryNeueWerte;

            edtBetrifftPerson.DataMember = ResultFieldNames.BetrifftPerson;
            edtBuchungstext.DataMember = CtlKbBelegeKorrigierenMasse.GridFieldNames.Buchungstext;
            edtBgKostenartID.DataMember = CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenart;
            edtLT.DataMember = ResultFieldNames.LT;
            edtValutaDatum.DataMember = CtlKbBelegeKorrigierenMasse.GridFieldNames.Valuta;
            edtVerwPeriodeBis.DataMember = CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeBis;
            edtVerwPeriodeVon.DataMember = CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeVon;
            edtSplittingart.DataMember = ResultFieldNames.SplittingArt;

            qryNeueWerte.BindControls();
            qryNeueWerte.DataTable.Rows.Add(qryNeueWerte.DataTable.NewRow());
        }

        private void SetupQuery()
        {
            AddQueryColumn<int>(ResultFieldNames.BetrifftBaPersonID);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.BgFinanzplanID);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartID);
            AddQueryColumn<string>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Buchungstext);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.FaFallID);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.FaLeistungID);
            AddQueryColumn<bool>(CtlKbBelegeKorrigierenMasse.GridFieldNames.IsSiLei);
            AddQueryColumn<bool>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Quoting);
            AddQueryColumn<string>(CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltProleistPersonenIDs);
            AddQueryColumn<DateTime>(CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumBis);
            AddQueryColumn<DateTime>(CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumVon);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.SplittingArtCode);
            AddQueryColumn<DateTime>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Valuta);
            AddQueryColumn<DateTime>(CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeBis);
            AddQueryColumn<DateTime>(CtlKbBelegeKorrigierenMasse.GridFieldNames.VerwPeriodeVon);
            AddQueryColumn<string>(CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenart);
            AddQueryColumn<bool>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Abgetreten);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Hauptvorgang);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Teilvorgang);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartHauptvorgang);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartTeilvorgang);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartHauptvorgangAbtretung);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.BgKostenartTeilvorgangAbtretung);
            AddQueryColumn<string>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Belegart);
            AddQueryColumn<bool>(CtlKbBelegeKorrigierenMasse.GridFieldNames.Weiterverrechenbar);
            AddQueryColumn<int>(CtlKbBelegeKorrigierenMasse.GridFieldNames.KbBuchungStatusCode);
            AddQueryColumn<string>(CtlKbBelegeKorrigierenMasse.GridFieldNames.KlientBaPersonIDList);
            AddQueryColumn<int>(ResultFieldNames.LTBaPersonID);
            AddQueryColumn<string>(ResultFieldNames.BetrifftPerson);
            AddQueryColumn<string>(ResultFieldNames.LT);
            AddQueryColumn<string>(ResultFieldNames.KontoNr);
            AddQueryColumn<bool>(ResultFieldNames.Storno);
            AddQueryColumn<string>(ResultFieldNames.SplittingArt);
        }

        private void UpdateGui()
        {
            // Haushalt-Label
            var bgFinanzplanId = qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.BgFinanzplanID] as int?;

            var unterstuetztePersonen = 0;
            var totalPersonen = 0;

            if (bgFinanzplanId > 0)
            {
                var finanzplanQuery = DBUtil.OpenSQL(@"
                    SELECT
                      UnterstuetztePersonen = SUM(CAST(FPP.IstUnterstuetzt AS INT)),
                      TotalPersonen = COUNT(FPP.BaPersonID)
                    FROM dbo.BgFinanzplan FPL WITH(READUNCOMMITTED)
                      INNER JOIN dbo.BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
                    WHERE FPL.BgFinanzplanID = {0};", bgFinanzplanId);

                if (!finanzplanQuery.IsEmpty)
                {
                    unterstuetztePersonen = Utils.ConvertToInt(finanzplanQuery["UnterstuetztePersonen"]);
                    totalPersonen = Utils.ConvertToInt(finanzplanQuery["TotalPersonen"]);
                }
            }
            else if (bgFinanzplanId == 0)
            {
                var proleistIds = qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltProleistPersonenIDs] as string;
                if (proleistIds != null)
                {
                    unterstuetztePersonen = totalPersonen = proleistIds.Split(',').Length;
                }
            }

            var haushaltDatumVon = qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumVon] as DateTime?;
            var haushaltDatumBis = qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.SelectedHaushaltDatumBis] as DateTime?;

            var quoting = Utils.ConvertToBool(qryNeueWerte[CtlKbBelegeKorrigierenMasse.GridFieldNames.Quoting]);

            if (quoting && unterstuetztePersonen > 0)
            {
                lblHaushalt.Text = string.Format("{0:d} - {1:d}, {2}/{3}", haushaltDatumVon, haushaltDatumBis, unterstuetztePersonen, totalPersonen);
            }
            else
            {
                lblHaushalt.Text = string.Empty;
            }

            // Haushalt-Button
            btnHaushalt.Enabled = quoting;

            // Betrifft-Person
            edtBetrifftPerson.EditMode = quoting ? EditModeType.ReadOnly : EditModeType.Normal;
        }

        public class ResultFieldNames
        {
            public const string BetrifftBaPersonID = "BetrifftBaPersonID";
            public const string BetrifftPerson = "BetrifftPerson";
            public const string KontoNr = "KontoNr";
            public const string LT = "LT";
            public const string LTBaPersonID = "LTBaPersonID";
            public const string SplittingArt = "SplittingArt";
            public const string Storno = "Storno";
        }
    }
}