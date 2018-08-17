/*
  KiSS 4.0
  --------
  DB-Object: fnShWohnkosten_Hg
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShWohnkosten_Hg
 (@BgFinanzplanID   int)
 RETURNS money
AS BEGIN

  RETURN (SELECT Betrag = dbo.fnShWohnkosten_Person(KZ.HgGrundbedarf, KZ.RefDate)
          FROM   dbo.fnWhKennzahlen(@BgFinanzplanID) KZ)
END
GO