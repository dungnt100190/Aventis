using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhLeistung : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlWhLeistung";
        private const string XDOCUMENTID_KI_JU_AMBULANT = "XDocumentID_KiJuAmbulant";
        private const string XDOCUMENTID_KLAERUNGSPHASE_LEISTUNGSENTSCHEID = "XDocumentID_Klaerungsphase_Leistungsentscheid";

        #endregion

        #endregion

        #region Constructors

        public CtlWhLeistung(Image titelImage, string titelText, int faLeistungID)
            : this()
        {
            picTitle.Image = titelImage;
            lblTitel.Text = titelText;

            colBgBewilligungStatusCode.ColumnEdit = grdBgFinanzplan.GetLOVLookUpEdit("BgBewilligungStatus");

            qryFaLeistung.Fill(faLeistungID);
        }

        public CtlWhLeistung()
        {
            InitializeComponent();

            SetupDocumentColumns();
        }

        #endregion

        #region EventHandlers

        private void grdBgFinanzplan_Click(object sender, EventArgs e)
        {
            var documentID = GetDocumentIDForMousePositionColumn();

            if (documentID.HasValue)
            {
                DokumentOeffnen(documentID.Value);
            }
        }

        private void grdBgFinanzplan_MouseMove(object sender, MouseEventArgs e)
        {
            int? documentID = GetDocumentIDForMousePositionColumn();
            if (documentID.HasValue)
            {
                grdBgFinanzplan.Cursor = Cursors.Hand;
            }
            else
            {
                grdBgFinanzplan.Cursor = Cursors.Default;
            }
        }

        private void qryBgFinanzplan_AfterFill(object sender, EventArgs e)
        {
            // Dokument Icon und Vorlagenname anzeigen
            var images = new ImageCollection();
            images.AddImage(XDokument.BmpNewDoc);
            images.AddImage(null);

            repositoryItemImageComboBox1.SmallImages = images;
            repositoryItemImageComboBox2.SmallImages = images;

            foreach (DataRow row in qryBgFinanzplan.DataTable.Rows)
            {
                // DocTemplateName_KiJuAmbulant
                var description = row["DocTemplateName_KiJuAmbulant"].ToString();
                var value = row["XDocumentID_KiJuAmbulant"] as int? ?? 0;

                repositoryItemImageComboBox1.Items.Add(
                    new ImageComboBoxItem(
                        description,
                        value,
                        value == 0 ? 1 : 0));

                // DocTemplateName_Klaerungsphase_Leistungsentscheid
                description = row["DocTemplateName_Klaerungsphase_Leistungsentscheid"].ToString();
                value = row["XDocumentID_Klaerungsphase_Leistungsentscheid"] as int? ?? 0;

                repositoryItemImageComboBox2.Items.Add(
                    new ImageComboBoxItem(
                        description,
                        value,
                        value == 0 ? 1 : 0));
            }
        }

        private void qryFaLeistung_AfterDelete(object sender, EventArgs e)
        {
            FormController.SendMessage(FormController.Forms.FALL, FormController.Param.ACTION, FormController.Action.REFRESH_TREE);

            // JumpToPath auf Kontoauszug um eine Exception 'Objektverweis wurde nicht auf eine Objektinstanz festgelegt'
            // zu verhindern
            FormController.OpenForm(
                FormController.Forms.FALL,
                FormController.Param.ACTION,
                FormController.Action.JUMP_TO_PATH,
                FormController.Param.BA_PERSON_ID,
                qryFaLeistung["BaPersonID"],
                FormController.Param.MODUL_ID,
                3,
                FormController.Param.TREE_NODE_ID,
                "CtlWhKontoauszug");
        }

        private void qryFaLeistung_AfterFill(object sender, EventArgs e)
        {
            qryBgFinanzplan.Fill(qryFaLeistung["FaLeistungID"]);
            grvBgFinanzplan.BestFitColumns();

            // Migrationsfelder
            bool migBemerkung = !DBUtil.IsEmpty(qryFaLeistung["MigBemerkung"]);
            lblMigBemerkung.Visible = migBemerkung;
            edtMigBemerkung.Visible = migBemerkung;

            //bool migLeistungVorhanden = !DBUtil.IsEmpty(qryFaLeistung["MigLeistungID"]);
            //EditModeType mode = migLeistungVorhanden ? EditModeType.ReadOnly : EditModeType.Normal;
            //lblAlteFallNr.Text = KissMsg.GetMLMessage(CLASSNAME, "AlteFallNr", "FallNr in {0}:", KissMsgCode.Text,  qryFaLeistung["ToolAlt"]);
            //edtAlteFallNr.EditMode = mode;
            //edtMigHerkunftCode.EditMode = mode;
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                //Eintrag ins Fallverlaufsprotokoll
                DBUtil.ExecSQL(@"
                    INSERT FaJournal (FaFallID, FaLeistungID, BaPersonID, UserID, Text, OrgUnitID)
                      VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                    qryFaLeistung["FaFallID"],
                    qryFaLeistung["FaLeistungID"],
                    qryFaLeistung["BaPersonID"],
                    Session.User.UserID,
                    "Fallabschluss",
                    Session.User["OrgUnitID"]);
            }
        }

        private void qryFaLeistung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            qryBgFinanzplan.Refresh();

            if (qryBgFinanzplan.Count > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FaLeistungLöschen",
                        "Diese Leistung kann nicht gelöscht werden.\r\n\r\nSie enthält mindestens 1 Finanzplan"));
            }

            if (!DBUtil.IsEmpty(qryFaLeistung["MigAlteFallNr"]))
            {
                int count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT Count(*)
                    FROM MigDetailBuchung
                    WHERE FaLeistungID = {0}",
                    qryFaLeistung["FaLeistungID"]);
                if (count > 0)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            CLASSNAME,
                            "FaLeistungLöschenMigrierteBuchungen",
                            "Diese Leistung kann nicht gelöscht werden.\r\n\r\nSie enthält aus ProLeist migrierte Buchungen."));
                }
            }

            var hasSpezkonto = DBUtil.ExecuteScalarSQLThrowingException(@"
                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.BgSpezkonto SPK WITH (READUNCOMMITTED)
                          WHERE FaLeistungID = {0})
                BEGIN
                    SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                    SELECT CONVERT(BIT, 0);
                END;",
                qryFaLeistung[DBO.FaLeistung.FaLeistungID]) as bool? ?? false;
            if (hasSpezkonto)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FaLeistungLöschenBgSpezialkontoVorhanden",
                        "Neue wirtschaftliche Hilfe kann nicht gelöscht werden. Es bestehen noch Einträge im Ausgabe-/Verrechnungskonto. Diese müssen zuerst gelöscht werden."));
            }
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) && ((DateTime)qryFaLeistung["DatumBis"]).Date < ((DateTime)qryFaLeistung["DatumVon"]).Date)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(CLASSNAME, "FallVorEnde", "Der Fall beginnt nach seinem Ende", KissMsgCode.MsgInfo), edtDatumBis);
            }

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                if (0 != (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*) FROM BgFinanzplan
                    WHERE FaLeistungID = {0}
                      AND dbo.fnDateOf(IsNull(DatumBis, GeplantBis)) > {1}",
                    qryFaLeistung["FaLeistungID"],
                    qryFaLeistung["DatumBis"]))
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            CLASSNAME,
                            "MinEinFinanzplanNachDatum",
                            "Datum bis ungültig. Mindestens ein Finanzplan endet nach diesem Datum.",
                            KissMsgCode.MsgInfo),
                        edtDatumBis);
                }

                //Kontrolle offene Pendenzen
                int countPendenzen = Utils.GetAnzahlOffenePendenzen((int)qryFaLeistung["FaLeistungID"]);
                if (countPendenzen > 0)
                {
                    string msg =
                        string.Format(
                            KissMsg.GetMLMessage(
                                CLASSNAME,
                                "OffenePendenzenVorhanden",
                                string.Format(
                                    "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                                    countPendenzen)));
                    KissMsg.ShowInfo(msg);
                }
            }
            else
            {
                // EndDatum ist leer, d.h. die Leistung ist aktiv. Wir müssen prüfen, ob es auch ein offener Fall gibt, sonst darf das Bis-Datum nicht leer sein
                object obj = DBUtil.ExecuteScalarSQL("SELECT FaFallID FROM FaLeistung WHERE FaFallID = {0} AND FaProzessCode = 200 AND DatumBis IS NULL", qryFaLeistung["FaFallID"]);

                if (obj == null)
                {
                    throw new KissInfoException(
                        "Ohne aktive Fallführung kann diese Wirtschaftliche Hilfe nicht wieder eröffnet werden. Das Bis-Datum darf nicht leer sein.");
                }
            }

            if (0 != (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*) FROM BgFinanzplan
                WHERE FaLeistungID = {0} AND IsNull(DatumVon, GeplantVon) < {1}",
                qryFaLeistung["FaLeistungID"],
                Utils.firstDayOfMonth((DateTime)qryFaLeistung["DatumVon"])))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "MinEinFinanzplanVorDatum",
                        "Datum von ungültig. Mindestens ein Finanzplan beginnt vor diesem Datum.",
                        KissMsgCode.MsgInfo),
                    edtDatumVon);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void DokumentOeffnen(int documentID)
        {
            edtDocumentHidden.DocumentID = documentID;
            edtDocumentHidden.OpenDoc();
        }

        private int? GetDocumentIDForMousePositionColumn()
        {
            //Determine doubleclicked column
            Point pt = grdBgFinanzplan.PointToClient(MousePosition);
            var info = grvBgFinanzplan.CalcHitInfo(pt);
            string xdocumentIdColumnName = info != null && info.Column != null ? info.Column.Tag as string : null;

            if (string.IsNullOrEmpty(xdocumentIdColumnName))
            {
                return null;
            }

            if (!info.InRow)
            {
                return null;
            }

            var documentID = Utils.ConvertToInt(grvBgFinanzplan.GetRowCellValue(info.RowHandle, xdocumentIdColumnName));
            if (documentID == 0)
            {
                return null;
            }

            return documentID;
        }

        private void SetupDocumentColumns()
        {
            colTemplateNameKiJuAmbulant.Tag = XDOCUMENTID_KI_JU_AMBULANT;
            colTemplateNameKlaerungsphaseLeistungsentscheid.Tag = XDOCUMENTID_KLAERUNGSPHASE_LEISTUNGSENTSCHEID;
        }

        #endregion

        #endregion
    }
}