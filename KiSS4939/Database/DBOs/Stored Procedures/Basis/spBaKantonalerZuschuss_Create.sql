SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject spBaKantonalerZuschuss_Create
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Basis/spBaKantonalerZuschuss_Create.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:20 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This sp creates new assigned entries to availables KantonalenZuschüsse for given 
           BaPersonID
    @BaPersonID:             The id of the person to assign BaKantonalerZuschussID
    @BaKantonalerZuschussID: The id of the entry to assign
  -
  RETURNS: Column [Result]: 1=success, else=failure
  -
  TEST:    EXEC spBaKantonalerZuschuss_Create 77923, 1, 'Jäggi Christoph (2)'
           EXEC spBaKantonalerZuschuss_Create 77923, 2, 'Jäggi Christoph (2)'
           
           EXEC spBaKantonalerZuschuss_Create NULL, 1, 'Jäggi Christoph (2)'
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Basis/spBaKantonalerZuschuss_Create.sql $
 * 
 * 3     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 2     1.12.08 10:12 Cjaeggi
 * 
 * 1     1.12.08 9:04 Cjaeggi
 * First version
=================================================================================================*/

CREATE PROCEDURE dbo.spBaKantonalerZuschuss_Create
(
  @BaPersonID INT,
  @BaKantonalerZuschussID INT,
  @Creator VARCHAR(50)
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- Validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID, -1) < 1 OR ISNULL(@BaKantonalerZuschussID, -1) < 1 OR ISNULL(@Creator, '') = '')
  BEGIN
    -- return invalid value
    SELECT [Result] = -1
  
    -- do not continue
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- insert entry
  -------------------------------------------------------------------------------
  INSERT INTO dbo.BaPerson_KantonalerZuschuss (BaPersonID, BaKantonalerZuschussID, Creator)
  VALUES (@BaPersonID, @BaKantonalerZuschussID, @Creator)
  
  -------------------------------------------------------------------------------
  -- done
  -------------------------------------------------------------------------------
  -- return rowcount (expect exactly one row)
  SELECT [Result] = @@ROWCOUNT
END
