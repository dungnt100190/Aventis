SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSWert
GO
/*===============================================================================================
  $Revision: 1 $
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
=================================================================================================*/
CREATE FUNCTION [dbo].[fnBFSWert]
  (@Variable     varchar(10),
   @BFSDossierID int)
  RETURNS sql_variant
AS BEGIN
  DECLARE @BFSWert sql_variant

  SELECT @BFSWert = Wert
  FROM   BFSWert VAL
         INNER JOIN BFSFrage FRA ON FRA.BFSFrageId = VAL.BFSFrageID
  WHERE  VAL.BFSDossierID = @BFSDossierID AND
         FRA.Variable = @variable
         
  RETURN @BFSWert;
END
GO