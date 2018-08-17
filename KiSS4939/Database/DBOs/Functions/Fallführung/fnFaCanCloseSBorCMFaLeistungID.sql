SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaCanCloseSBorCMFaLeistungID;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaCanCloseSBorCMFaLeistungID.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:26 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to validate if SB or CM FaLeistungID can be closed (with DatumBis).
           SB and CM can only be closed if at least one Rahmenziel is defined (otherwise only
           delete would be possible) and all Ziele are evaluated (have a valid EvaluationDatumBis).
   @FaLeistungID: The id within FaLeistungID
  -
  RETURNS: 1=item can be closed, 0=item cannot be closed, else: error (e.g. -1)
  -
  TEST:    SELECT [dbo].[fnFaCanCloseSBorCMFaLeistungID](142723)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaCanCloseSBorCMFaLeistungID.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     11.03.09 17:41 Cjaeggi
 * Fixed with other modules than sb or cm
 * 
 * 1     11.03.09 17:27 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnFaCanCloseSBorCMFaLeistungID
(
  @FaLeistungID INT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@FaLeistungID IS NULL)
  BEGIN
    -- ERR: invalid id, cannot close this item
    RETURN -1
  END  
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @ModulID INT
  DECLARE @CountRZEntries INT
  DECLARE @CountNotEvaluatedZiele INT
  
  -----------------------------------------------------------------------------
  -- get modul-id of given FaLeistungID
  -----------------------------------------------------------------------------
  -- get value
  SELECT @ModulID = LEI.ModulID
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.FaLeistungID = @FaLeistungID
  
  -- validate (3=SB, 4=CM)
  IF (ISNULL(@ModulID, -1) NOT IN (3, 4))
  BEGIN
    -- OK: no important Modul-ID for this check, can close item
    RETURN 1
  END
  
  -----------------------------------------------------------------------------
  -- check rules depending on given module
  -----------------------------------------------------------------------------
  IF (@ModulID = 3)
  BEGIN
    -- validate SB, count RZ
    SELECT @CountRZEntries = COUNT(1)
    FROM dbo.SbSozialberatung SBS WITH (READUNCOMMITTED)
    WHERE SBS.FaLeistungID = @FaLeistungID AND
          SBS.IstRahmenziel = 1
    
    -- count open evaluations
    SELECT @CountNotEvaluatedZiele = COUNT(1)
    FROM dbo.SbSozialberatung SBS WITH (READUNCOMMITTED)
    WHERE SBS.FaLeistungID = @FaLeistungID AND
          SBS.IstHaupteintrag = 0 AND
          SBS.EvaluationDatum IS NULL
  END
  ELSE IF (@ModulID = 4)
  BEGIN
    -- validate CM, count RZ
    SELECT @CountRZEntries = COUNT(1)
    FROM dbo.FaCaseManagement FAC WITH (READUNCOMMITTED)
    WHERE FAC.FaLeistungID = @FaLeistungID AND
          FAC.IstRahmenziel = 1
    
    -- count open evaluations
    SELECT @CountNotEvaluatedZiele = COUNT(1)
    FROM dbo.FaCaseManagement FAC WITH (READUNCOMMITTED)
    WHERE FAC.FaLeistungID = @FaLeistungID AND
          FAC.IstHaupteintrag = 0 AND
          FAC.EvaluationDatum IS NULL
  END
  ELSE
  BEGIN
    -- ERR: invalid id, cannot close item
    RETURN -1
  END
  
  -----------------------------------------------------------------------------
  -- validate if FaLeistungID can be closed
  -----------------------------------------------------------------------------
  -- check values (we need at least one RZ and no non-evaluated targets)
  IF (ISNULL(@CountRZEntries, 1) < 1 OR ISNULL(@CountNotEvaluatedZiele, 1) > 0)
  BEGIN
    -- NO: no RZ defined or at least one entry was not evaluated
    RETURN 0
  END
  
  -----------------------------------------------------------------------------
  -- if we are here, FaLeistungID can be closed
  -----------------------------------------------------------------------------
  -- OK: can close item
  RETURN 1
END
