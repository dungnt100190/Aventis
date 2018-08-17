SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFaIntake;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for FaIntake
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmFaIntake;
=================================================================================================*/

CREATE VIEW dbo.vwTmFaIntake
AS
SELECT
  FAI.FaIntakeID,
  --
  Eroeffnung  = CONVERT(VARCHAR, LEI.DatumVon, 104),
  Mitarbeiter = REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', ''),
  --
  KlientNameVorname	 = dbo.fnGetLastFirstName(NULL, VPR.Name, VPR.Vorname),
  KlientName         = VPR.Name,
  KlientVorname      = VPR.Vorname,
  KlientGeburtsdatum = VPR.Geburtsdatum,
  --
  KlientWohnsitzAdresseMehrzD = VPR.WohnsitzAdresseMehrzOhneNameD,
  KlientWohnsitzAdresseMehrzF = VPR.WohnsitzAdresseMehrzOhneNameF,
  KlientWohnsitzAdresseMehrzI = VPR.WohnsitzAdresseMehrzOhneNameI,
  --
  VPR.TelefonP,
  VPR.TelefonG,
  VPR.TelefonM,
  --
  VPR.HauptbehinderungsartD,
  VPR.HauptbehinderungsartF,
  VPR.HauptbehinderungsartI,
  --
  VPR.Behinderungsart2D,
  VPR.Behinderungsart2F,
  VPR.Behinderungsart2I,
  --
  VPR.BSVBehinderungsartD,
  VPR.BSVBehinderungsartF,
  VPR.BSVBehinderungsartI,
  --
  EmpfohlenVonD = dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, 1),
  EmpfohlenVonF = dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, 2),
  EmpfohlenVonI = dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, 3),
  --
  AnlassthemenD	= dbo.fnLOVMLColumnListe('FaLebensbereich', FAI.AnlassthemenCodes, NULL, 1), -- (Text d/f/i statt Codes anzeigen)
  AnlassthemenF	= dbo.fnLOVMLColumnListe('FaLebensbereich', FAI.AnlassthemenCodes, NULL, 2),
  AnlassthemenI	= dbo.fnLOVMLColumnListe('FaLebensbereich', FAI.AnlassthemenCodes, NULL, 3),
  --
  FAI.Anlass,
  FAI.Situationsbeschrieb,
  FAI.WeiteresVorgehen,
  --
  RueckrufDurchD = dbo.fnGetLOVMLText('FaIntakeWer', FAI.DurchWenCode, 1),
  RueckrufDurchF = dbo.fnGetLOVMLText('FaIntakeWer', FAI.DurchWenCode, 2),
  RueckrufDurchI = dbo.fnGetLOVMLText('FaIntakeWer', FAI.DurchWenCode, 3),
  --
  RueckrufBis         = CONVERT(VARCHAR, FAI.RueckrufBis, 104),
  VereinbartesTreffen = CONVERT(VARCHAR, FAI.VereinbartesTreffen, 104),
  FAI.InvolvierteFachstellen
  --
FROM dbo.FaIntake FAI WITH(READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung   LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FAI.FaLeistungID
  LEFT  JOIN dbo.XUser        USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
  INNER JOIN dbo.vwTmBaPerson VPR WITH(READUNCOMMITTED) ON LEI.BaPersonID = VPR.BaPersonID;
GO