/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfII_Hg
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfII_Hg
 (@BgFinanzPlanID   int,
  @WGemeinschaft    bit = 1)
 RETURNS money
AS BEGIN

  RETURN (SELECT Betrag = CASE WHEN @WGemeinschaft = 1
                          THEN dbo.fnShGrundbedarfII_Person(KZ.HgGrundbedarf, KZ.RefDate)
                          ELSE dbo.fnShGrundbedarfII_Person(1, KZ.RefDate) * KZ.HgGrundbedarf
                          END
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)
END
GO