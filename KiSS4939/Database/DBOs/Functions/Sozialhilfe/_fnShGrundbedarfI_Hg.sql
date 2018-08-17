/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfI_Hg
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfI_Hg
 (@BgFinanzPlanID   int)
 RETURNS money
AS BEGIN

  RETURN (SELECT Betrag = dbo.fnShGrundbedarfI_Person(KZ.HgGrundbedarf, KZ.RefDate)
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)

END
GO