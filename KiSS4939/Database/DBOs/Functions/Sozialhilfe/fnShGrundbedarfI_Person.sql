SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnShGrundbedarfI_Person
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfI_Person.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:03 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfI_Person.sql $
 * 
 * 2     25.06.09 8:14 Ckaeser
 * Alter2Create
 * 
 * 1     16.12.08 14:28 Ckaeser
 * 
 * 1     10.09.08 12:25 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnShGrundbedarfI_Person
 (@PersonCount int,
  @RefDate     datetime)
 RETURNS money
AS
BEGIN
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

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

