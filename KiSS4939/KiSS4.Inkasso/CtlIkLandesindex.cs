using System;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Inkasso
{
    public partial class CtlIkLandesindex : KissUserControl
    {
        #region Constructors

        public CtlIkLandesindex()
        {
            InitializeComponent();
            colIkLandesindexID.AppearanceCell.BackColor = GuiConfig.GridRowReadOnly;
        }

        #endregion

        #region EventHandlers

        private void CtlIkLandesIndex_Load(object sender, EventArgs e)
        {
            qryLandesindex.Fill();
        }

        private void btnCreateLandesindex_Click(object sender, EventArgs e)
        {
            // Neuen Index anlegen, wenn keiner existiert
            if (qryLandesindex.IsEmpty)
            {
                qryLandesindex.Insert();
                return;
            }

            var selected = (string)qryLandesindex[DBO.IkLandesindex.Name];
            var oldId = Utils.ConvertToInt(qryLandesindex[DBO.IkLandesindex.IkLandesindexID]);

            using (var dlg = new DlgLandesindexKopieren(selected))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                // Basis für Neuberechnung
                var neuberechnungBasis = -1m;

                if (dlg.Neuberechnen)
                {
                    var res =
                        DBUtil.ExecuteScalarSQL(@"
                                SELECT Wert
                                FROM dbo.IkLandesindexWert WITH(READUNCOMMITTED)
                                WHERE Jahr = {0}
                                  AND Monat = {1}
                                  AND IkLandesindexID = {2};",
                            dlg.Jahr,
                            dlg.Monat,
                            oldId);

                    neuberechnungBasis = Utils.ConvertToDecimal(res, -1m);

                    if (neuberechnungBasis < 0)
                    {
                        KissMsg.ShowError(
                            typeof(CtlIkLandesindex).Name,
                            "UngueltigesBasisDatum",
                            "Kein Wert für den angegebenen Monat gefunden.");
                        return;
                    }
                }

                // IkLandesindex anlegen
                qryLandesindex.Insert();
                qryLandesindex[DBO.IkLandesindex.Name] = dlg.LandesindexName;

                // nur bei Neuberechnung
                if (!qryLandesindex.Post() || !dlg.Neuberechnen)
                {
                    return;
                }

                var newId = Utils.ConvertToInt(qryLandesindex[DBO.IkLandesindex.IkLandesindexID]);
                var creatorModifier = DBUtil.GetDBRowCreatorModifier();

                // Werte einfügen
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.IkLandesindexWert(IkLandesindexID, Jahr, Monat, Wert, Creator, Modifier)
                        SELECT {0}, Jahr, Monat, Wert, {1}, {1}
                        FROM dbo.IkLandesindexWert WITH(READUNCOMMITTED)
                        WHERE IkLandesindexID = {2};",
                    newId,
                    creatorModifier,
                    oldId);

                // Update falls gewählt
                DBUtil.ExecSQLThrowingException(@"
                    UPDATE LIW
                    SET LIW.Wert = ROUND(100.0 / {0} * LIW.Wert, 1)
                    FROM dbo.IkLandesindexWert LIW
                    WHERE LIW.IkLandesindexID = {1};",
                    neuberechnungBasis,
                    newId);

                qryLandesindexWert.Fill(qryLandesindex[DBO.IkLandesindex.IkLandesindexID]);
            }
        }

        private void btnDeleteIndex_Click(object sender, EventArgs e)
        {
            if (qryLandesindex.Row != null)
            {
                qryLandesindex.Delete();
            }
        }

        private void qryLandesindexWert_AfterFill(object sender, EventArgs e)
        {
            qryLandesindexWert.Last();
        }

        private void qryLandesindexWert_AfterInsert(object sender, EventArgs e)
        {
            qryLandesindexWert[DBO.IkLandesindexWert.IkLandesindexID] = qryLandesindex[DBO.IkLandesindex.IkLandesindexID];
        }

        private void qryLandesindex_AfterFill(object sender, EventArgs e)
        {
            qryLandesindex.Last();
        }

        private void qryLandesindex_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.ExecSQLThrowingException(@"
                DELETE FROM dbo.IkLandesindexWert WHERE IkLandesindexID = {0};",
                qryLandesindex[DBO.IkLandesindex.IkLandesindexID]);
        }

        private void qryLandesindex_PositionChanged(object sender, EventArgs e)
        {
            qryLandesindexWert.Fill(qryLandesindex[DBO.IkLandesindex.IkLandesindexID]);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            qryLandesindex.Refresh();

            base.OnRefreshData();

            qryLandesindex.Last();
            qryLandesindexWert.Last();
        }

        public override bool OnSaveData()
        {
            return qryLandesindex.Post() && base.OnSaveData();
        }

        #endregion

        private void btnCreateValues_Click(object sender, EventArgs e)
        {
            if (qryLandesindex.IsEmpty)
            {
                KissMsg.ShowInfo(typeof(CtlIkLandesindex).Name, "KeinLandesindexVorhanden", "Bitte zuerst einen Landesindex erfassen.");
            }

            using (var dlg = new DlgLandesindexWertErfassen())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var jahr = dlg.Jahr;
                    var monat = dlg.Monat;
                    var values = dlg.Values;

                    foreach (var value in values)
                    {
                        // Überprüfen, ob Wert bereits existiert
                        var count = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                            SELECT COUNT(*)
                            FROM dbo.IkLandesindexWert WITH(READUNCOMMITTED)
                            WHERE IkLandesindexID = {0}
                              AND Jahr = {1}
                              AND Monat = {2};", value.Key, jahr, monat));

                        if (count > 0)
                        {
                            // Wert existiert bereits..
                            var name = DBUtil.ExecuteScalarSQL(@"
                                SELECT Name
                                FROM dbo.IkLandesindex WITH(READUNCOMMITTED)
                                WHERE IkLandesindexID = {0};", value.Key);

                            KissMsg.ShowInfo(
                                typeof(CtlIkLandesindex).Name,
                                "WertBereitsVorhanden",
                                "Der Landesindex '{0}' besitzt bereits einen Wert für den ausgewählten Monat.",
                                name);

                            // Nicht einfügen..
                            continue;
                        }

                        // Wert einfügen
                        DBUtil.ExecSQL(@"
                            INSERT INTO dbo.IkLandesindexWert(IkLandesindexID, Jahr, Monat, Wert, Creator, Modifier)
                            VALUES ({0}, {1}, {2}, {3}, {4}, {4});",
                            value.Key,
                            jahr,
                            monat,
                            value.Value,
                            DBUtil.GetDBRowCreatorModifier());
                    }

                    OnRefreshData();
                }
            }
        }

        #endregion
    }
}