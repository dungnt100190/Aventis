/*
  KiSS 4.0
  --------
  DB-Object: fnShGrundbedarfI_Person
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShGrundbedarfI_Person
 (@PersonCount int,
  @RefDate     datetime)
 RETURNS money
AS BEGIN
  DECLARE @Betrag money
  DECLARE @AmountPerPerson money
  
  IF @PersonCount = 0 RETURN ($0.0000)

  SET @Betrag = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B22_Amount\' + CAST(@PersonCount AS varchar), @RefDate) AS money)
  IF @Betrag IS NULL BEGIN
    SET @Betrag = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B22_Amount\7', @RefDate) AS money)
    SET @AmountPerPerson = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B22_AmountPerPerson', @RefDate) AS money)
    SET @Betrag = @Betrag + (@AmountPerPerson * (@PersonCount - 7))
  END

  RETURN (@Betrag)
END
GO