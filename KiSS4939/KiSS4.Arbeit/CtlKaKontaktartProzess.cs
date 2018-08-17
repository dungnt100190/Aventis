using System;
using System.Data;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaKontaktartProzess : KissUserControl
    {
        private int _baPersonID = -1;
        private int _faLeistungID = -1;
        private bool _verlaufseintragClicked;

        public CtlKaKontaktartProzess()
        {
            InitializeComponent();
            SetupDataMember();
        }

        public void Init(string maskName, Image maskImage, int faLeistungID, int baPersonID, int prozessCode)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            qryKaKontaktartProzess.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1, Session.User.LanguageCode);

            string lovName;
            switch (prozessCode)
            {
                case 711:
                    lovName = "KaKontaktartProzessJobtimal";
                    edtKaKontaktartStatus.Visible = true;
                    break;

                default:
                    lovName = "KaKontaktartProzess";
                    edtKaKontaktartStatus.Visible = false;
                    break;
            }
            edtKontaktart.LOVName = lovName;

            colKontaktart.ColumnEdit = grdProzess.GetLOVLookUpEdit(lovName);
        }

        private void btnVerlaufseintragErfassen_Click(object sender, EventArgs e)
        {
            try
            {
                _verlaufseintragClicked = true;

                if (qryKaKontaktartProzess.Post())
                {
                    var leistungKa = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                        SELECT FaLeistungID
                        FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                        WHERE BaPersonID = {0}
                          AND ModulID = 7
                          AND FaProzessCode = 700;",
                        _baPersonID));

                    var treeNodeID = string.Format("{0}/{1}", leistungKa, typeof(CtlKaVerlauf).Name);

                    var allgemKontaktartCode = DBUtil.ExecuteScalarSQL(@"
                        SELECT Value1
                        FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                        WHERE LOVName = {0}
                          AND Code = {1};",
                        edtKontaktart.LOVName,
                        qryKaKontaktartProzess[DBO.KaKontaktartProzess.KaKontaktartProzessCode]);

                    FormController.OpenForm(
                        FormController.Forms.FALL,
                        FormController.Param.ACTION,
                        FormController.Action.JUMP_TO_PATH,
                        FormController.Param.BA_PERSON_ID,
                        _baPersonID,
                        FormController.Param.MODUL_ID,
                        ModulID.K,
                        FormController.Param.FA_LEISTUNG_ID,
                        leistungKa,
                        FormController.Param.TREE_NODE_ID,
                        treeNodeID,
                        DBO.KaVerlauf.Datum,
                        qryKaKontaktartProzess[DBO.KaVerlauf.Datum],
                        DBO.KaVerlauf.KaAllgemKontaktartCode,
                        allgemKontaktartCode);
                }
            }
            finally
            {
                _verlaufseintragClicked = false;
            }
        }

        private void CtlKaKontaktartProzess_Load(object sender, EventArgs e)
        {
            btnVerlaufseintragErfassen.Enabled = DBUtil.UserHasRight(typeof(CtlKaVerlauf).Name, "I");
            if (KaUtil.GetSichtbarSDFlag(_baPersonID) == 1)
            {
                qryKaKontaktartProzess.EnableBoundFields(false);
            }
        }

        private void qryKaKontaktartProzess_AfterDelete(object sender, EventArgs e)
        {
            ShowVerlaufAendernInfo();
        }

        private void qryKaKontaktartProzess_AfterInsert(object sender, EventArgs e)
        {
            qryKaKontaktartProzess[DBO.KaKontaktartProzess.FaLeistungID] = _faLeistungID;
            qryKaKontaktartProzess[DBO.KaKontaktartProzess.Datum] = DateTime.Today;
            qryKaKontaktartProzess[DBO.KaKontaktartProzess.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonID);
        }

        private void qryKaKontaktartProzess_BeforePost(object sender, EventArgs e)
        {
            if (qryKaKontaktartProzess.CurrentRowState == DataRowState.Added
                && edtKaKontaktartStatus.Visible
                && Utils.ConvertToInt(qryKaKontaktartProzess[DBO.KaKontaktartProzess.KaKontaktartProzessStatusCode]) == 0)
            {
                KissMsg.ShowInfo(
                   typeof(CtlKaKontaktartProzess).Name,
                   "KaKontaktartStatusErfassen",
                   "Die Auswahl eines Radiobuttons ist zwingend.");
                throw new KissCancelException();
            }

            if (qryKaKontaktartProzess.CurrentRowState == DataRowState.Added && !_verlaufseintragClicked)
            {
                KissMsg.ShowInfo(
                    typeof(CtlKaKontaktartProzess).Name,
                    "VerlaufseintragErfassen",
                    "Es muss zu diesem Eintrag zwingend ein Verlaufseintrag erstellt werden. Betätigen Sie dazu den Button '{0}'.",
                    btnVerlaufseintragErfassen.Text);
                throw new KissCancelException();
            }

            if (qryKaKontaktartProzess.CurrentRowState == DataRowState.Modified)
            {
                ShowVerlaufAendernInfo();
            }
        }

        private void SetupDataMember()
        {
            colDatum.FieldName = DBO.KaKontaktartProzess.Datum;
            colKontaktart.FieldName = DBO.KaKontaktartProzess.KaKontaktartProzessCode;
            edtDatum.DataMember = DBO.KaKontaktartProzess.Datum;
            edtKontaktart.DataMember = DBO.KaKontaktartProzess.KaKontaktartProzessCode;
            edtKaKontaktartStatus.DataMember = DBO.KaKontaktartProzess.KaKontaktartProzessStatusCode;
        }

        private void ShowVerlaufAendernInfo()
        {
            KissMsg.ShowInfo(
                typeof(CtlKaKontaktartProzess).Name,
                "VerlaufseintragÄndern",
                "Die Änderung muss auch in der Maske Verlauf erfolgen.");
        }
    }
}