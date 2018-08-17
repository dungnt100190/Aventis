SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGleicheAdresse;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnGleicheAdresse.sql $
  $Author: Cjaeggi $
  $Modtime: 19.08.10 16:54 $
  $Revision: 5 $
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
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnGleicheAdresse.sql $
 * 
 * 5     19.08.10 16:55 Cjaeggi
 * #4167: Merged new functions for comparing addresses
 * 
 * 4     20.07.10 16:45 Cjaeggi
 * #4167: Renamed column LandCode to BaLandID
=================================================================================================*/

CREATE FUNCTION dbo.fnGleicheAdresse
(
  @FalltraegerID INT,
  @BaPersonID INT
)
RETURNS BIT
AS 
BEGIN
  -- we use now another function - this one is getting obsolete...
  RETURN dbo.fnBaGleicheAdresse(@FalltraegerID, @BaPersonID, 1, NULL);  -- we compare Wohnsitz-addresses
END;
GO