SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEIsZeitrechnerRangeValid;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEIsZeitrechnerRangeValid.sql $
  $Author: Cjaeggi $
  $Modtime: 23.11.09 8:54 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to check if a user is already occupied for given date and time range
    @UserID:      ID of user who is occupied for given date and time range
    @Datum:       The date where user is occupied
    @ZeitVon:     The time from where user is occupied within date
    @ZeitBis:     The time to where user is occupied within date
    @EdEinsatzID: The id of the current entry in order to prevent wrong result because of current entry
  -
  RETURNS: 1 if given values are valid and not crossing with other entries
           0 if given values are invalid or crossing with other entries
  -
  TEST:    SELECT dbo.fnBDEIsZeitrechnerRangeValid(2, GETDATE(), GETDATE(), GETDATE(), -1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEIsZeitrechnerRangeValid.sql $
 * 
 * 3     23.11.09 8:56 Cjaeggi
 * #5185: Refactoring
 * 
 * 2     18.12.08 13:35 Cjaeggi
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEIsZeitrechnerRangeValid
(
  @UserID  INT,
  @Datum   DATETIME,
  @ZeitVon DATETIME,
  @ZeitBis DATETIME,
  @BDEZeitrechnerID INT
)
RETURNS BIT
AS BEGIN
  -- validate
  IF (@UserID IS NULL OR @Datum IS NULL OR @ZeitVon IS NULL)
  BEGIN
    -- values are invalid, range is not valid
    RETURN 0;
  END;
  
  -- calculate values from datetime to int as seconds
  DECLARE @ZeitVonAsSeconds INT;
  DECLARE @ZeitBisAsSeconds INT;
  
  SET @ZeitVonAsSeconds = dbo.fnGetSecondsFromDateTime(@ZeitVon);
  
  -- check if we need to validate range or only ZeitVon
  IF (@ZeitBis IS NULL)
  BEGIN
    -- validate if ZeitVon is not in range ZeitVon-ZeitBis of any other entry of this user and date
    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.BDEZeitrechner BZR WITH (READUNCOMMITTED)
               WHERE BZR.UserID = @UserID 
                 AND BZR.Datum = @Datum 
                 AND BZR.BDEZeitrechnerID <> ISNULL(@BDEZeitrechnerID, -1) 
                 AND dbo.fnGetSecondsFromDateTime(BZR.ZeitVon) <= @ZeitVonAsSeconds 
                 AND dbo.fnGetSecondsFromDateTime(BZR.ZeitBis) > @ZeitVonAsSeconds))
    BEGIN
      -- ZeitVon is invalid
      RETURN 0;
    END
    ELSE
    BEGIN
      -- ZeitVon is valid
      RETURN 1;
    END;
  END
  ELSE
  BEGIN
    -- convert ZeitBis as seconds
    SET @ZeitBisAsSeconds = dbo.fnGetSecondsFromDateTime(@ZeitBis);
    
    -- validate time
    IF (@ZeitVonAsSeconds >= @ZeitBisAsSeconds)
    BEGIN
      -- invalid ragne
      RETURN 0;
    END;
    
    -- validate if ZeitVon and ZeitBis are not in range ZeitVon-ZeitBis of any other entry of this user and date
    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.BDEZeitrechner BZR WITH (READUNCOMMITTED)
               WHERE BZR.UserID = @UserID 
                 AND BZR.Datum = @Datum 
                 AND BZR.BDEZeitrechnerID <> ISNULL(@BDEZeitrechnerID, -1) 
                 AND ((dbo.fnGetSecondsFromDateTime(BZR.ZeitVon) <= @ZeitVonAsSeconds AND dbo.fnGetSecondsFromDateTime(BZR.ZeitBis) >= @ZeitVonAsSeconds) OR
                      (dbo.fnGetSecondsFromDateTime(BZR.ZeitVon) <= @ZeitBisAsSeconds AND dbo.fnGetSecondsFromDateTime(BZR.ZeitBis) >= @ZeitBisAsSeconds) OR
                      (dbo.fnGetSecondsFromDateTime(BZR.ZeitVon) >= @ZeitVonAsSeconds AND dbo.fnGetSecondsFromDateTime(BZR.ZeitBis) <= @ZeitBisAsSeconds))))
    BEGIN
      -- ZeitVon/ZeitBis are invalid
      RETURN 0;
    END
    ELSE
    BEGIN
      -- ZeitVon/ZeitBis are valid
      RETURN 1;
    END;
  END;
  
  -- if we are here, something is invalid
  RETURN 0;
END;
GO