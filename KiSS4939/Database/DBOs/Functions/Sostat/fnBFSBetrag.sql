SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSBetrag
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnBFSBetrag.sql $
  $Author: Mweber $
  $Modtime: 19.10.09 4:25 $
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
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnBFSBetrag.sql $
 * 
 * 1     19.10.09 4:28 Mweber
 * Übernahme von ZH
 * 
 * 
 *
=================================================================================================*/
CREATE FUNCTION [dbo].[fnBFSBetrag]
  (@Variable     varchar(10),
   @BFSDossierID int)
  RETURNS money
AS BEGIN
  DECLARE @BFSWert sql_variant

  SELECT @BFSWert = Wert
  FROM   BFSWert VAL
         INNER JOIN BFSFrage FRA ON FRA.BFSFrageId = VAL.BFSFrageID
  WHERE  VAL.BFSDossierID = @BFSDossierID AND
         FRA.Variable = @variable
         
  RETURN CONVERT(money,@BFSWert)
END
GO