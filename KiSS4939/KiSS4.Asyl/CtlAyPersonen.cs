using System;
using System.Data;
using System.Drawing;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public partial class CtlAyPersonen : KissUserControl
    {
        private readonly int _bgFinanzplanID;
        private readonly int _baPersonID;

        public CtlAyPersonen()
        {
            InitializeComponent();
        }

        public CtlAyPersonen(Image titelImage, int bgFinanzplanID, int baPersonID)
            : this()
        {
            picTitel.Image = titelImage;
            _bgFinanzplanID = bgFinanzplanID;
            _baPersonID = baPersonID;

            object bgBewilligungStatusCode = DBUtil.ExecuteScalarSQL(@"
				SELECT SFP.BgBewilligungStatusCode 
				FROM dbo.BgFinanzplan SFP WITH(READUNCOMMITTED)
				WHERE SFP.BgFinanzplanID = {0};",
                _bgFinanzplanID);

            bool enable = (bgBewilligungStatusCode == null || (int)bgBewilligungStatusCode < (int)BgBewilligungStatus.Erteilt);

            btnAdd.Enabled = enable;
            btnRemove.Enabled = enable;
            btnAddAll.Enabled = enable;
            btnRemoveAll.Enabled = enable;

            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            qryHeader.Fill(@"
                DECLARE @RefDate DATETIME
                SELECT @RefDate = ISNULL(SFP.DatumVon, SFP.GeplantVon)
                FROM dbo.BgFinanzplan SFP WITH(READUNCOMMITTED)
                WHERE SFP.BgFinanzplanID = {0};

                SELECT
                  Titel         = 'Personen im Haushalt, vom ' + CONVERT(VARCHAR, ISNULL(SFP.DatumVon, SFP.GeplantVon), 104)
                                  + ISNULL(' bis ' + CONVERT(VARCHAR, ISNULL(SFP.DatumBis, SFP.GeplantBis), 104), ''),
                  NameVorname   = PRS.NameVorname,
                  Adresse       = PRS.WohnsitzStrasseHausNr,
                  Ort           = PRS.WohnsitzPLZOrt,
                  Geburtsdatum  = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
                  Nationalitaet = PRS.Nationalitaet, " +

                AyUtil.BgFinanzplan_Kennzahlen("{0}") + @"

                FROM dbo.vwPerson        PRS
                  LEFT JOIN BgFinanzplan SFP WITH(READUNCOMMITTED) ON SFP.BgFinanzplanID = {0}
                WHERE PRS.BaPersonID = {1};",
                _bgFinanzplanID, _baPersonID);

            qryKlientensystem.Fill(@"
                DECLARE @KlientID INT;
                SET @KlientID = {1};

                DECLARE @tblKlientensystem TABLE (BaPersonID INT);

                INSERT @tblKlientensystem
                  SELECT DISTINCT
                         CASE
                           WHEN BaPersonID_1 = @KlientID THEN BaPersonID_2
                           ELSE BaPersonID_1
                         END
                  FROM dbo.BaPerson_Relation WITH(READUNCOMMITTED)
                  WHERE BaPersonID_1 = @KlientID
                     OR BaPersonID_2 = @KlientID 
				
                  UNION

                  SELECT @KlientID

                  SELECT [BaPersonID]   = PRS.BaPersonID,
                         [NameVorname]  = PRS.NameVorname,
                         [Geburtsdatum] = PRS.Geburtsdatum,
                         [Alter]        = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(SFP.DatumVon, SFP.GeplantVon)),
                         [Beziehung]    = CASE
                                            WHEN PRS.BaPersonID = @KlientID THEN 'Fallträger/-in'
                                            ELSE dbo.fnBaRelation(@KlientID, PRS.BaPersonID)
                                          END,
                         [unterstuetzt] = SPP.IstUnterstuetzt
                  FROM @tblKlientensystem KLS
                    INNER JOIN dbo.vwPerson              PRS ON PRS.BaPersonID = KLS.BaPersonID
                    LEFT  JOIN dbo.BgFinanzplan_BaPerson SPP WITH(READUNCOMMITTED) ON SPP.BgFinanzplanID = {0}
                                                                                  AND SPP.BaPersonID = KLS.BaPersonID
                    LEFT  JOIN dbo.BgFinanzplan          SFP WITH(READUNCOMMITTED) ON SFP.BgFinanzplanID = {0}
                  WHERE SPP.BaPersonID IS NULL;",
                _bgFinanzplanID,
                _baPersonID);

            qryHaushalt.Fill(@"
                DECLARE @KlientID INT;
                SET @KlientID = {1};

                DECLARE @tblKlientensystem TABLE (BaPersonID INT)

                INSERT @tblKlientensystem
                SELECT DISTINCT
                  CASE WHEN BaPersonID_1 = @KlientID
                    THEN BaPersonID_2
                    ELSE BaPersonID_1
                  END
                FROM dbo.BaPerson_Relation WITH(READUNCOMMITTED)
                WHERE BaPersonID_1 = @KlientID
                   OR BaPersonID_2 = @KlientID 
                
                UNION	
                
                SELECT @KlientID

                SELECT
                  [BaPersonID]   = PRS.BaPersonID,
                  [NameVorname]  = PRS.NameVorname,
                  [Geburtsdatum] = PRS.Geburtsdatum,
                  [Alter]        = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(SFP.DatumVon, SFP.GeplantVon)),
                  [Beziehung]    = CASE
                                     WHEN PRS.BaPersonID = @KlientID THEN 'Fallträger/-in'
                                     ELSE dbo.fnBaRelation(@KlientID, PRS.BaPersonID)
                                   END,
                  [unterstuetzt] = SPP.IstUnterstuetzt
                FROM @tblKlientensystem KLS
                  INNER JOIN dbo.vwPerson              PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = KLS.BaPersonID
                  INNER JOIN dbo.BgFinanzplan_BaPerson SPP WITH(READUNCOMMITTED) ON SPP.BgFinanzplanID = {0}
                                                                                AND SPP.BaPersonID = KLS.BaPersonID
                  INNER JOIN dbo.BgFinanzplan          SFP WITH(READUNCOMMITTED) ON SFP.BgFinanzplanID = SPP.BgFinanzplanID;",
                _bgFinanzplanID,
                _baPersonID);
        }

        private void btnAddRemove_Click(object sender, EventArgs e)
        {
            if (sender == btnAdd)
            {
                if (qryKlientensystem.Count == 0)
                {
                    return;
                }

                DBUtil.ExecSQL(@"
					INSERT INTO BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt)
					  VALUES ({0}, {1}, 1)",
                    _bgFinanzplanID,
                    qryKlientensystem["BaPersonID"]);
            }
            else if (sender == btnRemove)
            {
                if (qryHaushalt.Count == 0)
                {
                    return;
                }

                DBUtil.ExecSQL(@"
					DELETE FROM BgFinanzplan_BaPerson
					WHERE BgFinanzplanID = {0} AND BaPersonID = {1}",
                    _bgFinanzplanID,
                    qryHaushalt["BaPersonID"]);
            }
            else if (sender == btnAddAll)
            {
                foreach (DataRow row in qryKlientensystem.DataTable.Rows)
                {
                    DBUtil.ExecSQL(@"
						INSERT INTO BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt)
						  VALUES ({0}, {1}, 1)",
                        _bgFinanzplanID,
                        row["BaPersonID"]);
                }
            }
            else if (sender == btnRemoveAll)
            {
                if (qryHaushalt.Count == 0)
                {
                    return;
                }

                DBUtil.ExecSQL(@"
					DELETE FROM BgFinanzplan_BaPerson
					WHERE BgFinanzplanID = {0}",
                    _bgFinanzplanID);
            }

            DBUtil.ExecSQL("EXECUTE spAyFinanzplan_Update {0}", _bgFinanzplanID);
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            // jüngste Unterstützungsperiode expandieren
            KissModulTree modulTree = (KissModulTree)GetKissMainForm().GetTreeFall();

            if (modulTree.KissTree != null &&
                modulTree.KissTree.Nodes.Count > 0 &&
                modulTree.KissTree.Nodes[0].Nodes.Count > 0 &&
                modulTree.KissTree.Nodes[0].Nodes[0].Nodes.Count > 0 &&
                modulTree.KissTree.Nodes[0].Nodes[0].Nodes[0].Nodes.Count > 0)
            {
                modulTree.KissTree.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Expanded = true; // Personen der Unterst.Periode
            }

            RefreshDisplay();
        }

        private void grdKlientensystem_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
        }

        private void grdHaushalt_DoubleClick(object sender, EventArgs e)
        {
            if (btnRemove.Enabled)
            {
                btnRemove.PerformClick();
            }
        }
    }
}

