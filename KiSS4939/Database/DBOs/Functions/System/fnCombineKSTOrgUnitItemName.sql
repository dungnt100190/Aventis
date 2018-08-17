SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnCombineKSTOrgUnitItemName;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnCombineKSTOrgUnitItemName.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:07 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Combine XOrgUnit.Kostenstelle with XOrgUnit.ItemName with defined format and space
    @Kostenstelle:  The cost center of the orgunit
    @ItemName:      The name of the orgunit
  -
  RETURNS: Combined values
  -
  TEST:    SELECT [dbo].[fnCombineKSTOrgUnitItemName](100, 'MyOrgUnit')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnCombineKSTOrgUnitItemName.sql $
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     20.01.09 15:30 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnCombineKSTOrgUnitItemName
(
  @Kostenstelle INT,
  @ItemName VARCHAR(100)
)
RETURNS VARCHAR(150)
AS BEGIN
  -----------------------------------------------------------------------------
  -- combine values
  -----------------------------------------------------------------------------
  RETURN CONVERT(VARCHAR(50), ISNULL(@Kostenstelle, -1)) + '   ' + ISNULL(@ItemName, '-')
END
GO