using System;
using System.Data;
using System.Drawing;

using DevExpress.XtraTreeList.Nodes;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public partial class CtlAyFall : KissUserControl
    {
        private readonly int _baPersonID;

        private bool _isNewFall;

        public CtlAyFall()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent call
            colGrundEroeffnen.ColumnEdit = grdFaLeistung.GetLOVLookUpEdit(edtEroeffnungsGrundCode.LOVName);
            colGrundAbschluss.ColumnEdit = grdFaLeistung.GetLOVLookUpEdit(edtAbschlussGrundCode.LOVName);
        }

        public CtlAyFall(Image titelImage, string titelText, int baPersonID)
            : this()
        {
            picTitel.Image = titelImage;
            _baPersonID = baPersonID;
            lblTitel.Text = titelText;

            qryFaLeistung.Fill(_baPersonID, (int)ModulID.A);
        }

        public CtlAyFall(Image titelImage, string titelText, int baPersonID, int faLeistungID)
            : this(titelImage, titelText, baPersonID)
        {
            qryFaLeistung.Find(string.Format("FaLeistungID = 0{0}", faLeistungID));
        }

        public override bool BeforeCloseView()
        {
            //Verlassen der Maske erlaubt falls es einen neuen Datensatz ist (die Maske ist in diesem Fall automatisch geschlossen und neu geladet)
            if (qryFaLeistung.CurrentRowState == DataRowState.Added ||
                qryFaLeistung.CurrentRowState == DataRowState.Detached || //nicht mehr mit der DB verbunden
                _isNewFall)
            {
                return true;
            }

            try
            {
                ValidateForm();
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    ((KissCancelException)ex).ShowMessage();
                }
                return false;
            }

            return true;
        }

        public override bool OnAddData()
        {
            if (base.OnAddData() && qryFaLeistung.Post())
            {
                KissModulTree modulTree = (KissModulTree)GetKissMainForm().GetTreeFall();
                modulTree.FocusedNode = DBUtil.FindNodeByValue(modulTree.KissTree.Nodes, "FAL" + qryFaLeistung["FaLeistungID"], "ID");
                modulTree.FocusedNode.Expanded = true;

                foreach (TreeListNode node in modulTree.FocusedNode.Nodes)
                {
                    node.Expanded = true;
                }

                return true;
            }

            return false;
        }

        private void qryFaLeistung_AfterDelete(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFaLeistung_AfterInsert(object sender, EventArgs e)
        {
            qryFaLeistung["FaFallID"] = _baPersonID;
            qryFaLeistung["ModulID"] = (int)ModulID.A;
            qryFaLeistung["UserID"] = Session.User.UserID;
            qryFaLeistung["BaPersonID"] = _baPersonID;
            qryFaLeistung["FaProzessCode"] = 600;

            qryFaLeistung["DatumVon"] = DBUtil.ExecuteScalarSQL(@"
                SELECT DateAdd(D, 1, MAX(DatumBis))
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = {1}
                UNION ALL
                SELECT dbo.fnDateOf(GETDATE())
                ORDER BY 1 DESC;",
                _baPersonID,
                (int)ModulID.A);

            SqlQuery qry = (SqlQuery)edtEroeffnungsGrundCode.Properties.DataSource;

            if (qry.Count == 1)
            {
                qryFaLeistung["EroeffnungsGrundCode"] = qry.DataTable.Rows[0]["Code"];
            }

            qryFaLeistung.RowModified = true;
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFaLeistung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // TODO : Checks
        }

        private void qryFaLeistung_BeforeInsert(object sender, EventArgs e)
        {
            var leistungCount = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = {1}
                  AND DatumBis IS NULL;",
                _baPersonID,
                (int)ModulID.A);

            if (leistungCount > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlAyFall", "AsylfallNichtAbgeschl", "Der letzte Asylfall ist noch nicht abgeschlossen.", KissMsgCode.MsgInfo));
            }
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            //der Erste Datensatz ist eingefügt vor dem Benutzer etwas an der Form machen kann, in diesem Fall prüfen wir den Form nicht
            // dann wird die Maske automatisch geschlossen und neu geladet
            if (qryFaLeistung.CurrentRowState == DataRowState.Added)
            {
                _isNewFall = true;
            }

            if (!_isNewFall)
            {
                ValidateForm();
            }
        }

        /// <summary>
        /// Prüft der Datensatz, und verursacht ein Exception falls etwas nicht in Ordnung ist
        /// </summary>
        private void ValidateForm()
        {
            DBUtil.CheckNotNullField(edtGemeindeCode, lblGemeindeCode.Text);
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) && ((DateTime)qryFaLeistung["DatumBis"]).Date < ((DateTime)qryFaLeistung["DatumVon"]).Date)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage("CtlAyFall", "FallNachEnde", "Der Fall beginnt nach seinem Ende", KissMsgCode.MsgInfo), edtDatumBis);
            }

            int queryCount = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = {1}
                  AND FaLeistungID != ISNULL({2}, 0)
                  AND dbo.fnDateOf({3})                     <= dbo.fnDateOf(ISNULL(DatumBis, '99991231'))
                  AND dbo.fnDateOf(ISNULL({4}, '99991231')) >= dbo.fnDateOf(DatumVon)",
                _baPersonID,
                (int)ModulID.A,
                qryFaLeistung["FaLeistungID"],
                qryFaLeistung["DatumVon"],
                qryFaLeistung["DatumBis"]);

            if (queryCount != 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage("CtlAyFall", "UeberschneidungDatum", "Überschneidung der Datumsbereiche", KissMsgCode.MsgInfo), edtDatumVon);
            }

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                queryCount = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.BgFinanzplan WITH(READUNCOMMITTED)
                    WHERE FaLeistungID = {0}
                      AND BgBewilligungStatusCode >= 5
                      AND DatumBis IS NULL;",
                    qryFaLeistung["FaLeistungID"]);

                if (queryCount != 0)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            "CtlAyFall",
                            "AbschlussNichtMoeglich",
                            "Abschluss nicht möglich. Mindestens ein Masterbudget ist noch nicht abgeschlossen.",
                            KissMsgCode.MsgInfo));
                }

                //Kontrolle offene Pendenzen
                int countPendenzen = Utils.GetAnzahlOffenePendenzen((int)qryFaLeistung["FaLeistungID"]);
                if (countPendenzen > 0)
                {
                    string msg =
                        string.Format(KissMsg.GetMLMessage("CtlFaBeratungsperiode", "OffenePendenzenVorhanden",
                                                           string.Format(
                                                               "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                                                               countPendenzen)));
                    KissMsg.ShowInfo(msg);
                }
            }

            queryCount = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.BgFinanzplan WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0}
                AND ISNULL(DatumVon, GeplantVon) < {1};",
                qryFaLeistung["FaLeistungID"],
                Utils.firstDayOfMonth((DateTime)qryFaLeistung["DatumVon"]));

            if (queryCount != 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlAyFall",
                        "DatumVonUngueltig",
                        "Datum von ungültig. Mindestens ein Masterbudget beginnt vor diesem Datum.",
                        KissMsgCode.MsgInfo),
                    edtDatumVon);
            }

            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                queryCount = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.BgFinanzplan WITH(READUNCOMMITTED)
                    WHERE FaLeistungID = {0}
                      AND dbo.fnDateOf(ISNULL(DatumBis, GeplantBis)) > {1};",
                    qryFaLeistung["FaLeistungID"],
                    qryFaLeistung["DatumBis"]);
                if (queryCount != 0)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            "CtlAyFall",
                            "DatumBisUngueltig",
                            "Datum bis ungültig. Mindestens ein Masterbudget endet nach diesem Datum.",
                            KissMsgCode.MsgInfo),
                        edtDatumBis);
                }
            }
        }
    }
}