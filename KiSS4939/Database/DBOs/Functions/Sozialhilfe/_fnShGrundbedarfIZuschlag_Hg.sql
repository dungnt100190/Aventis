/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfIZuschlag_Hg
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfIZuschlag_Hg
 (@BgFinanzplanID   int)
 RETURNS money
AS BEGIN
  RETURN (SELECT Betrag = IsNull(KZ.HgZuschlagI * KZ.B23Amount, 0)
          FROM   dbo.fnWhKennzahlen(@BgFinanzplanID) KZ)
END
GO