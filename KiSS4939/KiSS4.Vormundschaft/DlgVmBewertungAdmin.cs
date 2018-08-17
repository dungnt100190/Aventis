using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for DlgVmBewertungAdmin.
    /// </summary>
    public partial class DlgVmBewertungAdmin : KissDialog
    {
        #region Constructors

        public DlgVmBewertungAdmin()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void DlgVmBewertungAdmin_Load(object sender, EventArgs e)
        {
            edtJahr.EditValue = DateTime.Today.Year;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtBewertung.EditValue) || DBUtil.IsEmpty(edtJahr.EditValue))
            {
                KissMsg.ShowInfo("CtlVmBewertungAdmin", "TagMonatJahrErfassen", "Die Felder 'Tag/Monat' und 'Jahr' müssen erfasst werden!");
                return;
            }

            int year = Convert.ToInt32(edtJahr.EditValue);
            int code = (int)edtBewertung.EditValue;
            int minYear = DateTime.Today.Year - 1;
            int maxYear = DateTime.Today.Year + 1;

            if (year < minYear || year > maxYear)
            {
                KissMsg.ShowInfo(
                    "CtlVmBewertungAdmin",
                    "EinschraenkungJahr",
                    "Das Jahr muss zwischen {0} und {1} liegen!",
                    0,
                    0,
                    minYear.ToString(),
                    maxYear.ToString());
                return;
            }

            int rowCount = DBUtil.ExecSQL(@"
                INSERT VmBewertung (FaLeistungID, Datum, VmFallgewichtungStichtagCode, VmFallgewichtungJahr, VmMandatstypCode,
                                    VmKriterienCodes, VmKriterienListe, UserID, VmMandatstypBewilligtCode)
                  SELECT FaLeistungID                 = FAL.FaLeistungID,
                         Datum                        = GETDATE(),
                         VmFallgewichtungStichtagCode = {0},
                         VmFallgewichtungJahr         = {1},
                         VmMandatstypCode             = CASE
                                                          WHEN BEW2.VmBewertungID IS NOT NULL THEN BEW2.VmMandatstypCode
                                                          ELSE 3
                                                        END,
                         VmKriterienCodes             = CASE
                                                          WHEN BEW2.VmBewertungID IS NOT NULL THEN BEW2.VmKriterienCodes
                                                        END,
                         VmKriterienListe             = CASE
                                                          WHEN BEW2.VmBewertungID IS NOT NULL THEN BEW2.VmKriterienListe
                                                        END,
                         UserID                       = FAL.UserID,
                         VmMandatstypBewilligtCode    = CASE
                                                          WHEN BEW2.VmBewertungID IS NOT NULL THEN BEW2.VmMandatstypBewilligtCode
                                                          ELSE 3
                                                        END
                  FROM dbo.FaLeistung         FAL  WITH(READUNCOMMITTED)
                    LEFT JOIN dbo.VmBewertung BEW  WITH(READUNCOMMITTED) ON BEW.FaLeistungID = FAL.FaLeistungID
                                                                        AND BEW.VmFallgewichtungStichtagCode = {0}
                                                                        AND BEW.VmFallgewichtungJahr = {1}
                    LEFT JOIN dbo.VmBewertung BEW2 WITH(READUNCOMMITTED) ON BEW2.FaLeistungID = FAL.FaLeistungID
                                                                        AND BEW2.VmBewertungID = (SELECT TOP 1 VmBewertungID
                                                                                                  FROM dbo.VmBewertung WITH(READUNCOMMITTED)
                                                                                                  WHERE FaLeistungID = FAL.FaLeistungID
                                                                                                    AND ((VmFallgewichtungJahr < {1}) OR
                                                                                                         (VmFallgewichtungJahr = {1} AND
                                                                                                          VmFallgewichtungStichtagCode < {0}))
                                                                                                  ORDER BY VmFallgewichtungJahr DESC,
                                                                                                           VmFallgewichtungStichtagCode DESC)
                  WHERE FAL.ModulID = 5
                    AND FAL.FaProzessCode = 501
                    AND FAL.DatumBis IS NULL
                    AND EXISTS (SELECT VmBerichtID
                                FROM dbo.VmBericht BER WITH(READUNCOMMITTED)
                                WHERE BER.FaLeistungID = FAL.FaLeistungID
                                  AND BER.Erstellung IS NULL)  -- pendente Berichterstellung
                                  AND BEW.VmBewertungID IS NULL;", code, year);

            KissMsg.ShowInfo("CtlVmBewertungAdmin", "NeueEintraege", "Es wurden {0} neue Einträge erzeugt.", 0, 0, rowCount.ToString());

            if (rowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtBewertung.EditValue) || DBUtil.IsEmpty(edtJahr.EditValue))
            {
                KissMsg.ShowInfo("CtlVmBewertungAdmin", "TagMonatJahrErfassen", "Die Felder 'Tag/Monat' und 'Jahr' müssen erfasst werden!");
                return;
            }

            int year = Convert.ToInt32(edtJahr.EditValue);
            int code = (int)edtBewertung.EditValue;
            int minYear = DateTime.Today.Year - 1;
            int maxYear = DateTime.Today.Year + 1;

            if (year < minYear || year > maxYear)
            {
                KissMsg.ShowInfo("CtlVmBewertungAdmin", "EinschraenkungJahr", "Das Jahr muss zwischen {0} und {1} liegen!", 0, 0, minYear.ToString(), maxYear.ToString());
                return;
            }

            if (!KissMsg.ShowQuestion(
                "DlgVmBewertungAdmin",
                "FaelleMitDatumLoeschen",
                "Sollen für aktive Fälle alle Einträge mit Datum {0}{1} gelöscht werden?",
                0,
                0,
                true,
                edtBewertung.Text,
                year))
            {
                return;
            }

            int rowCount = DBUtil.ExecSQL(@"
                DELETE BEW
                FROM VmBewertung        BEW
                  INNER JOIN FaLeistung FAL ON FAL.FaLeistungID = BEW.FaLeistungID AND FAL.DatumBis IS NULL
                WHERE BEW.VmFallgewichtungStichtagCode = {0} AND BEW.VmFallgewichtungJahr = {1}",
                code, year);

            KissMsg.ShowInfo("CtlVmBewertungAdmin", "EintraegeGeloescht", "Es wurden {0} Einträge gelöscht.", 0, 0, rowCount.ToString());

            if (rowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        #endregion
    }
}