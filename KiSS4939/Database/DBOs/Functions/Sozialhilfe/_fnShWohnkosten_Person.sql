/*
  KiSS 4.0
  --------
  DB-Object: fnShWohnkosten_Person
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShWohnkosten_Person
 (@PersonCount int,
  @RefDate     datetime)
 RETURNS money
AS BEGIN
  DECLARE @Betrag money

  SET @Betrag = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B30_Amount\' + CAST(@PersonCount AS varchar), @RefDate) AS money)

  -- Falls mehr Personen im Haushalt leben als in XConfig spezifiert: 
  -- Ansatz mit der höchsten Anzahl Personen nehmen (keine lineare Erhöhung!!)
  IF @Betrag IS NULL BEGIN
    SET @Betrag = (SELECT TOP 1  CAST(ValueVar AS money)
                   FROM   dbo.fnXConfigChild('System\Sozialhilfe\SKOS\B30_Amount\', @RefDate)
                   WHERE  CAST(Child AS int) < @PersonCount 
                   ORDER BY CAST(Child AS int) DESC)
  END

  RETURN (@Betrag)
END
GO