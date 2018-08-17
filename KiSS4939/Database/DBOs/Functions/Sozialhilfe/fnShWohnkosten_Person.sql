SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnShWohnkosten_Person
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnShWohnkosten_Person.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:04 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnShWohnkosten_Person.sql $
 * 
 * 2     25.06.09 8:14 Ckaeser
 * Alter2Create
 * 
 * 1     16.12.08 14:33 Ckaeser
 * 
 * 1     10.09.08 12:25 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnShWohnkosten_Person
 (@PersonCount int,
  @RefDate     datetime)
 RETURNS money
AS
BEGIN
  DECLARE @Betrag money
  DECLARE @BetragAdditionalPerson money
  DECLARE @MaxPerson int

  SET @Betrag = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B30_Amount\' + CAST(@PersonCount AS varchar), @RefDate) AS money)

  -- Falls mehr Personen im Haushalt leben als in XConfig spezifiert: 
  -- Ansatz mit der höchsten Anzahl Personen nehmen (welche noch kleiner als die gesuchte Anzahl Personen ist), und für die restlichen Personen mit dem Ansatz für zusätzliche Personen berechnen
  IF IsNull(@Betrag, 0) = 0
  BEGIN
    SELECT TOP 1  
      @Betrag = CAST(ValueVar AS money), 
      @MaxPerson = CAST(Child AS int)
    FROM   dbo.fnXConfigChild('System\Sozialhilfe\SKOS\B30_Amount\', @RefDate)
    WHERE  CAST(Child AS int) < @PersonCount 
      AND CAST(ValueVar AS money) > 0
    ORDER BY CAST(Child AS int) DESC;

    SET @BetragAdditionalPerson = CAST(dbo.fnXConfig('System\Sozialhilfe\SKOS\B30_AmountAdditionalPerson', @RefDate) AS money)

    SET @Betrag = @Betrag + (@PersonCount - @MaxPerson) * @BetragAdditionalPerson;    
  END

  RETURN @Betrag
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

