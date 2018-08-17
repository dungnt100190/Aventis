SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject spBaKantonalerZuschuss_Delete
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Basis/spBaKantonalerZuschuss_Delete.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:20 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This sp delete an assigned KantonalenZuschuss entry for given BaPersonID
    @BaPersonID:             The id of the person to delete BaKantonalerZuschussID
    @BaKantonalerZuschussID: The id of the entry to delete
  -
  RETURNS: Column [Result]: 1=success, else=failure
  -
  TEST:    EXEC spBaKantonalerZuschuss_Delete 77923, 1
           EXEC spBaKantonalerZuschuss_Delete 77923, 2
           
           EXEC spBaKantonalerZuschuss_Delete NULL, 1
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Basis/spBaKantonalerZuschuss_Delete.sql $
 * 
 * 4     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 3     1.12.08 10:12 Cjaeggi
 * 
 * 2     1.12.08 10:10 Cjaeggi
 * 
 * 1     1.12.08 10:10 Cjaeggi
 * First version
=================================================================================================*/

CREATE PROCEDURE dbo.spBaKantonalerZuschuss_Delete
(
  @BaPersonID INT,
  @BaKantonalerZuschussID INT
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- Validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID, -1) < 1 OR ISNULL(@BaKantonalerZuschussID, -1) < 1)
  BEGIN
    -- return invalid value
    SELECT [Result] = -1
  
    -- do not continue
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- delete entry
  -------------------------------------------------------------------------------
  DELETE FROM dbo.BaPerson_KantonalerZuschuss 
  WHERE BaPersonID = @BaPersonID AND
        BaKantonalerZuschussID = @BaKantonalerZuschussID
  
  -------------------------------------------------------------------------------
  -- done
  -------------------------------------------------------------------------------
  -- return rowcount (expect exactly one row)
  SELECT [Result] = @@ROWCOUNT
END
 