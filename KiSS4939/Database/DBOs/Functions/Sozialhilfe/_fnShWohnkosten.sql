/*
  KiSS 4.0
  --------
  DB-Object: fnShWohnkosten
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShWohnkosten
 (@BgFinanzplanID   int)
 RETURNS money
AS BEGIN

  RETURN (SELECT Betrag = CASE WHEN KZ.RntUseHgUeFactor = 1
                          THEN KZ.GBHgUeFactor * dbo.fnShWohnkosten_Person(KZ.HgGrundbedarf, KZ.RefDate)
                          ELSE dbo.fnShWohnkosten_Person(KZ.UeGrundbedarf, KZ.RefDate)
                          END
          FROM   dbo.fnWhKennzahlen(@BgFinanzplanID) KZ)
END
GO