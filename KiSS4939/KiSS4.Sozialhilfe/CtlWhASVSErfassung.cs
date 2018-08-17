using System;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;

namespace KiSS4.Sozialhilfe
{
    public partial class CtlWhASVSErfassung : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Fallträger
        /// </summary>
        private readonly int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlWhASVSErfassung(int faLeistungID)
        {
            _faLeistungID = faLeistungID;
            InitializeComponent();
        }

        #endregion

        #region Properties

        private int Status
        {
            get { return (int)qryASVS["ASVSEintragStatusCode"]; }
            set { qryASVS["ASVSEintragStatusCode"] = value; }
        }

        #endregion

        #region EventHandlers

        private void CtlWhASVSErfassung_Enter(object sender, EventArgs e)
        {
            // Workaround: Beim Modulwechsel werden sonst die Datum-Icons nicht schön angezeigt.
            edtDatumVon.Refresh();
            edtDatumBis.Refresh();
        }

        private void btnKopieren_Click(object sender, EventArgs e)
        {
            string[] fieldNames = {
                "WhASVSEintragID",
                "FaLeistungID",
                "BaPersonID",
                "DatumVon",
                "DatumBis",
                "NameVorname"
            };

            DBUtil.CopyDataRow_IncludingFields(qryASVS, fieldNames, false);
            Status = 2;
            qryASVS["Creator"] = Session.User.LogonName;
            qryASVS["Modifier"] = Session.User.LogonName;
        }

        private void edtWiderruf_EditValueChanged(object sender, EventArgs e)
        {
            if (qryASVS.IsInserting)
            {
                return;
            }

            if (qryASVS["Widerrufen"] as bool? != edtWiderruf.EditValue as bool?)
            {
                qryASVS["Widerrufen"] = edtWiderruf.EditValue;
            }
        }

        private void grvASVSEinheit_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
        }

        private void grvASVSEinheit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void qryASVS_AfterInsert(object sender, EventArgs e)
        {
            Status = 2;
            qryASVS["FaLeistungID"] = _faLeistungID;
            qryASVS["Creator"] = Session.User.LogonName;
            qryASVS["Modifier"] = Session.User.LogonName;
            qryASVS.RowModified = true;
        }

        private void qryASVS_BeforeDelete(object sender, EventArgs e)
        {
            if (Status != 1 && Status != 2)
            {
                KissMsg.ShowInfo("Der Eintrag kann nicht gelöscht werden, da er bereits exportiert wurde.");
                throw new Exception("Der Eintrag kann nicht gelöscht werden, da er bereits exportiert wurde.");
            }
        }

        private void qryASVS_BeforePost(object sender, EventArgs e)
        {
            qryASVS["NameVorname"] = edtBaPersonID.GetColumnValue("NameVorname");
            if ((int)qryASVS["ASVSEintragStatusCode"] == 5)
            {
                return;
            }

            // Wenn Anmeldung widerrufen wird keine Validierung (alte Daten)
            if ((qryASVS["widerrufen"] as bool? ?? false))
            {
                ChangeStatus();
                return;
            }

            // ASV nur nach StartValidierung prüfen
            var configDate = DBUtil.GetConfigDateTime(@"System\Sozialhilfe\ASV\StartValidierung", DateTime.MinValue);

            if (DBUtil.IsEmpty(qryASVS["LeistungAb"]))
            {
                qryASVS["LeistungAb"] = DBUtil.ExecuteScalarSQL(
                    @"
                    SELECT DatumVon FROM FaLeistung WHERE FaLeistungID = {0}",
                    _faLeistungID);
            }

            if (Convert.ToDateTime(qryASVS["LeistungAb"]) >= configDate)
            {
                /* Fehlermeldung, wenn das Eröffnungsdatum mehr als 2 Monate vor dem Eröffnungsdatum der Sozialhilfe liegt */
                const string sqlSozialhilfe =
                    @"SELECT TOP 1 DatumVon
                      FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                      WHERE FaLeistungID = {0};";
                var geplantVonSozialhilfe = DBUtil.ExecuteScalarSQLThrowingException(string.Format(sqlSozialhilfe, _faLeistungID));
                if (!DBUtil.IsEmpty(geplantVonSozialhilfe))
                {
                    var datumGeplantVonSozialhilfe = (DateTime)geplantVonSozialhilfe;
                    // zwei Monat abziehen
                    datumGeplantVonSozialhilfe = datumGeplantVonSozialhilfe.AddMonths(-2);
                    datumGeplantVonSozialhilfe = new DateTime(datumGeplantVonSozialhilfe.Year, datumGeplantVonSozialhilfe.Month, 1);
                    var datumAvsVon = (DateTime)edtDatumVon.EditValue;
                    if (datumAvsVon < datumGeplantVonSozialhilfe)
                    {
                        KissMsg.ShowInfo("Das Anmeldedatum darf, bezogen auf den 1. des Monats, maximal 2 Monate früher als die Sozialhilfe sein.");
                        throw new KissCancelException();
                    }
                }

                // Fehlermeldung, wenn ASV-'Datum von' mehr als 2 Monate vor dem Eröffnungsdatum des ersten Finanzplans (meist Überbrückung) liegt.
                string sqlFinanzplan =
                    @"SELECT TOP 1 GeplantVon
                      FROM dbo.BgFinanzplan
                      WHERE FaLeistungID = {0}
                      ORDER BY GeplantVon, GeplantBis;";
                object geplantVonFinanzplan = DBUtil.ExecuteScalarSQLThrowingException(string.Format(sqlFinanzplan, _faLeistungID));
                if (!DBUtil.IsEmpty(geplantVonFinanzplan))
                {
                    DateTime datumGeplantVonFinanzplan = (DateTime)geplantVonFinanzplan;
                    // Ein Monat abziehen
                    datumGeplantVonFinanzplan = datumGeplantVonFinanzplan.AddMonths(-2);
                    datumGeplantVonFinanzplan = new DateTime(datumGeplantVonFinanzplan.Year, datumGeplantVonFinanzplan.Month, 1);
                    DateTime datumAvsVon = (DateTime)edtDatumVon.EditValue;
                    if (datumAvsVon < datumGeplantVonFinanzplan)
                    {
                        KissMsg.ShowInfo("Das Anmeldedatum kann nicht vor dem Eröffnungsdatum des ersten Finanzplans liegen.");
                        //Das Anmeldedatum darf, bezogen auf den 1. des Monats, maximal 2 Monate früher als die Sozialhilfe sein.
                        throw new KissCancelException();
                    }
                }
            }

            if (DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                KissMsg.ShowInfo("Das Feld 'Datum Von' muss ausgefüllt sein");
                throw new KissCancelException();
            }

            if (!DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                if (((DateTime)edtDatumVon.EditValue) > ((DateTime)(edtDatumBis.EditValue)))
                {
                    KissMsg.ShowInfo("Datum bis darf nicht vor Datum von sein");
                    throw new KissCancelException();
                }
            }

            var vonDatum = (DateTime)(edtDatumVon.EditValue);
            edtDatumVon.EditValue = new DateTime(vonDatum.Year, vonDatum.Month, 1);
            edtDatumVon.Refresh();
            if (vonDatum.Day != 1)
            {
                KissMsg.ShowInfo("Anmeldung ist nur am ersten Tag des Monats möglich.");
                throw new KissCancelException();
            }

            if (edtDatumBis.EditValue.ToString() != String.Empty)
            {
                var bisDatum = (DateTime)(edtDatumBis.EditValue);
                edtDatumBis.EditValue = new DateTime(bisDatum.Year, bisDatum.Month, 1).AddMonths(1).AddDays(-1);
                edtDatumBis.Refresh();
                if (bisDatum.AddDays(1).Day != 1)
                {
                    KissMsg.ShowInfo("Abmeldung ist nur am letzten Tag des Monats möglich.");
                    throw new KissCancelException();
                }
            }

            if (DBUtil.IsEmpty(edtBaPersonID.EditValue))
            {
                KissMsg.ShowInfo("Die Person muss ausgewählt werden.");
                throw new KissCancelException();
            }
            object adresseID =
                DBUtil.ExecuteScalarSQLThrowingException(
                    "SELECT BaAdresseID FROM BaAdresse WHERE BaPersonID = {0} AND AdresseCode = 1",
                    qryASVS["BaPersonID"]);
            if (DBUtil.IsEmpty(adresseID))
            {
                KissMsg.ShowInfo("Für die Person ist keine Adresse hinterlegt.");
                throw new KissCancelException();
            }
            object versichertennummer =
                DBUtil.ExecuteScalarSQLThrowingException(
                    "SELECT Versichertennummer FROM BaPerson WHERE BaPersonID = {0}",
                    qryASVS["BaPersonID"]);
            if (DBUtil.IsEmpty(versichertennummer))
            {
                KissMsg.ShowInfo("Für die Person ist keine Versichertennummer hinterlegt.");
                throw new KissCancelException();
            }

            ChangeStatus();
        }

        private void qryASVS_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void OnLoad(EventArgs e)
        {
            edtBaPersonID.Properties.DataSource = qryBaPerson;
            edtBaPersonID.Properties.DropDownRows = Math.Max(qryBaPerson.Count, 5);
            qryBaPerson.Fill(_faLeistungID);
            qryASVS.Fill(_faLeistungID);
            base.OnLoad(e);

            bool mayRead, mayInsert, mayUpdate, mayDelete;
            Session.GetUserRight("CtlWhASVSErfassung", out mayRead, out mayInsert, out mayUpdate, out mayDelete);
            qryASVS.CanInsert = mayInsert;
            qryASVS.CanDelete = mayDelete;
            qryASVS.CanUpdate = mayUpdate;
        }

        #endregion

        #region Private Methods

        private void ChangeStatus()
        {
            if (Status != 1 && Status != 2) // in Vorbereitung / exportbereit
            {
                if ((bool)edtWiderruf.EditValue)
                {
                    Status = 4; // Löschung pendent
                }
                else
                {
                    Status = 3; // exportiert
                }
            }
        }

        private void SetEditMode()
        {
            if (qryASVS.Count <= 0)
            {
                edtWiderruf.Enabled = false;
                edtBaPersonID.EditMode = EditModeType.ReadOnly;
                edtDatumVon.EditMode = EditModeType.ReadOnly;
                edtDatumBis.EditMode = EditModeType.ReadOnly;
                edtBemerkung.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                // Exportiert, aber widerruf noch nicht exportiert
                edtWiderruf.Enabled = Status == 3 || Status == 4;
                edtBaPersonID.EditMode = Status == 1 || Status == 2 ? EditModeType.Normal : EditModeType.ReadOnly;
                edtDatumVon.EditMode = Status == 1 || Status == 2 ? EditModeType.Normal : EditModeType.ReadOnly;
                edtDatumBis.EditMode = Status == 1 || Status == 2 ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBemerkung.EditMode = Status == 1 || Status == 2 ? EditModeType.Normal : EditModeType.ReadOnly;
            }
        }

        #endregion

        #endregion
    }
}