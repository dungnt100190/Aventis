SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaEinsatzIsTimeRangeValid;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaEinsatzIsTimeRangeValid.sql $
  $Author: Cjaeggi $
  $Modtime: 23.11.09 9:00 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to check if a user is already occupied for given date and time range
    @ModulID:   The ID of the module to use for checking data (5=BW, 6=ED, others are not supported)
    @UserID:    ID of user who is occupied for given date and time range
    @Beginn     The start date and time of the action
    @Ende       The end date and time of the action
    @EinsatzID: The id of the current entry in order to prevent wrong result because of comparing 
                with current entry
  -
  RETURNS: 1 if given values are valid and not crossing with other entries
           0 if given values are invalid or crossing with other entries
  -
  TEST:    SELECT dbo.fnFaEinsatzIsTimeRangeValid(2, GETDATE(), GETDATE(), -1)
           -
           UserID	  Beginn	                  Ende
           456      2009-01-02 00:01:00.000	  2009-01-03 00:05:00.000
           -
           SELECT dbo.fnFaEinsatzIsTimeRangeValid(6, 456, '2009-01-03 00:05:00.000', '2009-01-08 00:00:00.000', -1)
           SELECT dbo.fnFaEinsatzIsTimeRangeValid(6, 456, '2009-01-01 00:06:00.000', '2009-01-02 00:01:00.000', -1)
           SELECT dbo.fnFaEinsatzIsTimeRangeValid(6, 456, '2009-01-01 00:00:00.000', '2009-01-10 00:00:00.000', -1)
           SELECT dbo.fnFaEinsatzIsTimeRangeValid(6, 456, '2009-01-02 00:02:00.000', '2009-01-03 00:04:00.000', -1)
           SELECT dbo.fnFaEinsatzIsTimeRangeValid(6, 456, '2009-01-01 00:01:00.000', '2009-01-01 00:02:00.000', -1)
           SELECT dbo.fnFaEinsatzIsTimeRangeValid(6, 440, '2009-01-01 00:00:00.000', '2009-01-10 00:00:00.000', -1)
           SELECT dbo.fnFaEinsatzIsTimeRangeValid(6, 456, '2009-01-03 00:06:00.000', '2009-01-05 00:02:00.000', -1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaEinsatzIsTimeRangeValid.sql $
 * 
 * 6     23.11.09 9:01 Cjaeggi
 * #5185: Renamed and made available for BW usage
 * 
 * 5     23.11.09 8:48 Cjaeggi
 * #5185: Refactoring
 * 
 * 4     19.01.09 14:37 Cjaeggi
 * Changed to new table-columns
 * 
 * 3     8.01.09 11:14 Cjaeggi
 * Changed due to db-fields modification
 * 
 * 2     18.12.08 13:15 Cjaeggi
 * Fixed compare bug and function-call
 * 
 * 1     18.12.08 12:08 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnFaEinsatzIsTimeRangeValid
(
  @ModulID INT,
  @UserID  INT,
  @Beginn DATETIME,
  @Ende DATETIME,
  @EinsatzID INT
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@ModulID NOT IN (5, 6) OR @UserID IS NULL OR @Beginn IS NULL OR @Ende IS NULL)
  BEGIN
    -- values are invalid, range is not valid
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- BW specific
  -----------------------------------------------------------------------------
  IF (@ModulID = 5)
  BEGIN
    -- validate if there is already an entry that crosses with current values of this user
    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.BwEinsatz BWE WITH (READUNCOMMITTED)
                 INNER JOIN dbo.XUser_BwEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON UEV.XUser_BwEinsatzvereinbarungID = BWE.XUser_BwEinsatzvereinbarungID 
                                                                                      AND UEV.UserID = @UserID
               WHERE BWE.BwEinsatzID <> ISNULL(@EinsatzID, -1) 
                 AND (BWE.Beginn BETWEEN @Beginn AND @Ende OR
                      BWE.Ende BETWEEN @Beginn AND @Ende OR
                      (BWE.Beginn <= @Beginn AND BWE.Ende >= @Ende))))
    BEGIN
      -- Beginn/Ende are invalid
      RETURN 0;
    END
    ELSE
    BEGIN
      -- Beginn/Ende are valid
      RETURN 1;
    END;
  END
  
  -----------------------------------------------------------------------------
  -- ED specific
  -----------------------------------------------------------------------------
  IF (@ModulID = 6)
  BEGIN 
     -- validate if there is already an entry that crosses with current values of this user
    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.EdEinsatz EDE WITH (READUNCOMMITTED)
                 INNER JOIN dbo.XUser_EdEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON UEV.XUser_EdEinsatzvereinbarungID = EDE.XUser_EdEinsatzvereinbarungID 
                                                                                      AND UEV.UserID = @UserID
               WHERE EDE.EdEinsatzID <> ISNULL(@EinsatzID, -1) 
                 AND (EDE.Beginn BETWEEN @Beginn AND @Ende OR
                      EDE.Ende BETWEEN @Beginn AND @Ende OR
                      (EDE.Beginn <= @Beginn AND EDE.Ende >= @Ende))))
    BEGIN
      -- Beginn/Ende are invalid
      RETURN 0;
    END
    ELSE
    BEGIN
      -- Beginn/Ende are valid
      RETURN 1;
    END;
  END;
  
  -- if we are here, something is wrong
  RETURN 0;
END;
GO 