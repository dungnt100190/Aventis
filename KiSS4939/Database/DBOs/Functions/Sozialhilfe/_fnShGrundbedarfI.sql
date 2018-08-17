/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfI
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfI
 (@BgFinanzPlanID   int)
 RETURNS money
AS BEGIN

  RETURN (SELECT Betrag = CASE WHEN KZ.GBUseHgUeFactor = 1
                          THEN KZ.GBHgUeFactor * dbo.fnShGrundbedarfI_Person(KZ.HgGrundbedarf, KZ.RefDate)
                          ELSE dbo.fnShGrundbedarfI_Person(KZ.UeGrundbedarf, KZ.RefDate)
                          END
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)
END
GO