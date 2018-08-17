/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfII_Person
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfII_Person
 (@PersonCount int,
  @RefDate     datetime)
 RETURNS money
AS BEGIN
  DECLARE @Betrag money
  
  IF @PersonCount = 0 RETURN ($0.0000)

  SET @Betrag = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B24_Amount\' + CAST(@PersonCount AS varchar), @RefDate) AS money)
  IF @Betrag IS NULL BEGIN
    SET @Betrag = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B24_Amount\4', @RefDate) AS money)
  END

  RETURN (@Betrag)
END
GO