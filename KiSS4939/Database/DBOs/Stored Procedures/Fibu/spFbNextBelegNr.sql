SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFbNextBelegNr;
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbNextBelegNr.sql $
  $Author: Spsota $
  $Modtime: 21.01.10 10:19 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this function to get the next Fibu BelegNr
    @BelegNrId: The ID of the BelegNr entry
  -
  RETURNS: The next BelegNr with prefix.
  -
  TEST:    EXEC dbo.spFbNextBelegNr;
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbNextBelegNr.sql $
 * 
 * 2     21.01.10 17:00 Spsota
 * #5485 SPs für Kassenmodul korrigiert
 * 
 * 1     20.01.10 17:00 Spsota
 * #5485 SP get next Beleg Nr
=================================================================================================*/

CREATE PROCEDURE [dbo].[spFbNextBelegNr]
(
  @BelegNrId int,
  @Return varchar(25) OUT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  DECLARE @NextBelegNr int, @MaxBelegNr int, @MinBelegNr int;
  
  -------------------------------------------------------------------------------
  -- Get next BelegNr
  -------------------------------------------------------------------------------
  SELECT 
    @Return = FBN.Praefix + CONVERT(varchar, FBN.NaechsteBelegNr), 
    @NextBelegNr = FBN.NaechsteBelegNr,
    @MaxBelegNr = FBN.BelegNrBis,
    @MinBelegNr = FBN.BelegNrVon
  FROM FbBelegNr FBN
  WHERE FBN.FbBelegNrID = @BelegNrId;
  
  -------------------------------------------------------------------------------
  -- Calculate new next BelegNr
  -------------------------------------------------------------------------------
  SET @NextBelegNr = @NextBelegNr % @MaxBelegNr;
  IF @NextBelegNr = 0
  BEGIN
    SET @NextBelegNr = @MinBelegNr;
  END
  ELSE
  BEGIN
    SET @NextBelegNr = @NextBelegNr + 1;
  END;
  
  -------------------------------------------------------------------------------
  -- Update next BelegNr
  -------------------------------------------------------------------------------
  UPDATE FBN
    SET FBN.NaechsteBelegNr = @NextBelegNr
  FROM FbBelegNr FBN
  WHERE FBN.FbBelegNrID = @BelegNrId;
  
    
END;
GO
 