/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfII
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfII
 (@BgFinanzPlanID   int,
  @WGemeinschaft    bit = 1)
 RETURNS money
AS BEGIN

  RETURN (SELECT Betrag = CASE WHEN @WGemeinschaft = 1
                          THEN CASE WHEN KZ.GBUseHgUeFactor = 1
                               THEN KZ.GBHgUeFactor * dbo.fnShGrundbedarfII_Person(KZ.HgGrundbedarf, KZ.RefDate)
                               ELSE dbo.fnShGrundbedarfII_Person(KZ.UeGrundbedarf, KZ.RefDate)
                               END
                          ELSE dbo.fnShGrundbedarfII_Person(1, KZ.RefDate) * KZ.UeGrundbedarf
                          END
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)
END
GO