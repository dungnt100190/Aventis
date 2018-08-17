/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfIZuschlag
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfIZuschlag
 (@BgFinanzplanID   int)
 RETURNS money
AS BEGIN

  RETURN (SELECT Betrag = CASE WHEN KZ.GBUseHgUeFactor = 1
                          THEN KZ.HgZuschlagI * KZ.GBHgUeFactor * KZ.B23Amount
                          ELSE KZ.UeZuschlagI * KZ.B23Amount
                          END
          FROM   dbo.fnWhKennzahlen(@BgFinanzplanID) KZ)
END
GO