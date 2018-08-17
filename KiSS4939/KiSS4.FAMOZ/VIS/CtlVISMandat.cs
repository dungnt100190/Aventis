using System;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.FAMOZ.VIS
{
    public partial class CtlVISMandat : KissUserControl
    {
        private int _faLeistungID;

        public CtlVISMandat()
        {
            InitializeComponent();
        }

        public void Init(string titleName, Image titleImage, int faLeistungID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            _faLeistungID = faLeistungID;
        }

        private void btnReopen_Click(object sender, EventArgs e)
        {
            // Prüfe, ob es bereits eine aktive Leistung für diese Massnahme gibt
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT LEI.FaFallID, LEI.FaLeistungID
                FROM dbo.FaLeistung          LEI WITH(READUNCOMMITTED)
                  INNER JOIN dbo.VmMassnahme MAS WITH(READUNCOMMITTED) ON MAS.FaLeistungID = LEI.FaLeistungID
                WHERE MAS.VIS_VormschID = {0}
                  AND LEI.DatumBis IS NULL;", qryFaLeistung["VIS_VormschID"]);

            if (qry.Count > 0)
            {
                // es gibt bereits eine aktive Leistung für diese VormschID => exception
                KissMsg.ShowInfo(string.Format("Diese KES-Leistung mit VormschID {0} kann nicht neu eröffnet werden,\r\nda sie bereits aktiv in der Leistung {1} im Fall {2} geführt wird.", qryFaLeistung["VIS_VormschID"], qry["FaLeistungID"], qry["FaFallID"]));
                return;
            }

            if (KissMsg.ShowQuestion("CtlVISMandat", "VmWiederOeffnen", "Soll die geschlossene KES-Leistung wieder geöffnet werden ?"))
            {
                qryFaLeistung.CanUpdate = true;
                qryFaLeistung["DatumBis"] = DBNull.Value;
                qryFaLeistung.Post();

                DBUtil.ExecSQL(@"
                    INSERT dbo.FaJournal (FaFallID, FaLeistungID, UserID, Text, OrgUnitID)
                      VALUES ({0}, {1}, {2}, {3}, {4})",
                    qryFaLeistung["FaFallID"],
                    qryFaLeistung["FaLeistungID"],
                    Session.User.UserID,
                    "Wiedereröffnung M-Leistung",
                    Session.User["OrgUnitID"]);
            }
        }

        private void CtlVISMandat_Load(object sender, EventArgs e)
        {
            qryFaLeistung.Fill(_faLeistungID);

            // Überführung im VIS aber noch nicht im KiSS
            if (!DBUtil.IsEmpty(qryFaLeistung["VIS_VormschID_2"]) && !(qryFaLeistung["VIS_VormschID_2_InKiss"] as bool? ?? false))
            {
                if (KissMsg.ShowQuestion(
                    GetType().Name,
                    "UeberfuertImVisNichtImKiss",
                    "Diese Massnahme wurde im VIS überführt und ist im KiSS noch nicht vorhanden." + Environment.NewLine +
                    "Wollen Sie die überführte Massnahme mit VormschID {0} jetzt importieren?",
                    true,
                    qryFaLeistung["VIS_VormschID_2"]))
                {
                    DlgVISNeueMassnahme dlgVNeueMassnahme = new DlgVISNeueMassnahme((int)qryFaLeistung["FaFallID"], (int)qryFaLeistung["BaPersonID"], true, qryFaLeistung["VIS_VormschID_2"] as int?);
                    dlgVNeueMassnahme.ShowDialog();
                    if (dlgVNeueMassnahme.DialogResult == DialogResult.OK)
                    {
                        if (dlgVNeueMassnahme.FaLeistungID > 0)
                        {
                            // Refresh Tree and jump to new arrangement
                            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                            string displayTree = string.Format(
                                "BaPersonID={0};FaLeistungID={1};TreeNodeID=CtlVISMandat{1};FaFallID={2}",
                                qryFaLeistung["BaPersonID"],
                                dlgVNeueMassnahme.FaLeistungID,
                                qryFaLeistung["FaFallID"]);
                            System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(displayTree);
                            FormController.OpenForm("FrmFall", "Action", "JumpToPath", dic);
                        }
                    }
                }
            }

            SetEditMode();
        }

        private void qryFaLeistung_AfterFill(object sender, EventArgs e)
        {
            var neurechtlich = (bool)qryFaLeistung["Neurechtlich"];
            if (neurechtlich)
            {
                lblVormschID.Text = "Altrechtliche VormschID";
            }
            else
            {
                lblVormschID.Text = "Neurechtliche VormschID";
            }
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            SetEditMode();
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                // Liegt DatumBis nach DatumVon?
                DateTime datumVon = (DateTime)qryFaLeistung["DatumVon"];
                DateTime datumBis = (DateTime)qryFaLeistung["DatumBis"];
                if (datumVon > datumBis)
                {
                    throw new KissInfoException("Abschlussdatum muss nach Eröffnungsdatum liegen!");
                }

                DBUtil.ExecSQL(@"
                    INSERT dbo.FaJournal (FaFallID, FaLeistungID, UserID, Text, OrgUnitID)
                      VALUES ({0}, {1}, {2}, {3}, {4})",
                    qryFaLeistung["FaFallID"],
                    qryFaLeistung["FaLeistungID"],
                    Session.User.UserID,
                    "Abschluss M-Leistung",
                    Session.User["OrgUnitID"]);
            }
        }

        private void SetEditMode()
        {
            if (qryFaLeistung.Count == 0)
            {
                return;
            }

            bool mayRead, mayIns, mayUpd, mayDel, mayClose, mayReopen;
            DBUtil.GetFallRights((int)qryFaLeistung["FaLeistungID"], out mayRead, out mayIns, out mayUpd, out mayDel, out mayClose, out mayReopen);

            if (mayClose)
            {
                bool open = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);
                bool archived = !DBUtil.IsEmpty(qryFaLeistung["FaLeistungArchivID"]);

                qryFaLeistung.CanUpdate = open;
                btnReopen.Visible = !open && !archived && mayReopen && DBUtil.UserHasRight("CtlVISMandat_FallWiederEroeffnen");
                if ((qryFaLeistung["Altrechtlich"] as bool? ?? false) && (qryFaLeistung["VIS_VormschID_2_InKiss"] as bool? ?? false))
                {
                    btnReopen.Enabled = false;
                }
                else
                {
                    btnReopen.Enabled = true;
                }

                if (open)
                {
                    edtDatumVon.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtDatumVon.EditMode = EditModeType.ReadOnly;
                }
            }
            else
            {
                qryFaLeistung.CanUpdate = false; ;
                btnReopen.Visible = false;
                edtDatumVon.EditMode = EditModeType.ReadOnly;
            }

            qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate);
        }
    }
}