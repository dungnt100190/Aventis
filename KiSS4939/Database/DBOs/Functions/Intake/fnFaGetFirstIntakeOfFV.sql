SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetFirstIntakeOfFV;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetFirstIntakeOfFV.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:27 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get first (oldest) FaLeistungID of intake-module of given person
    @BaPersonID:              The BaPersonID to get first intake
    @FaLeistungIDFallverlauf: The FaLeistungID of the Fallverlauf to get first intake 
                              (if NULL, the latest one will be taken)
  -
  RETURNS: The FaLeistungID of the first intake of given user or -1 if invalid or nothing found
  -
  TEST:    SELECT [dbo].[fnFaGetFirstIntakeOfFV](77950, NULL)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetFirstIntakeOfFV.sql $
 * 
 * 5     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 4     5.02.09 12:33 Cjaeggi
 * Added 2nd performance booster
 * 
 * 3     3.02.09 12:23 Cjaeggi
 * Added performance booster
 * 
 * 2     28.01.09 16:32 Cjaeggi
 * Changed example
 * 
 * 1     28.01.09 16:20 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetFirstIntakeOfFV
(
  @BaPersonID INT,
  @FaLeistungIDFallverlauf INT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@BaPersonID IS NULL)
  BEGIN
    -- invalid value
    RETURN -1
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @FaLeistungIDFirstIntake INT
  SET @FaLeistungIDFirstIntake = NULL
  
  -----------------------------------------------------------------------------
  -- performance booster: get intake if only one exists without further checks
  -----------------------------------------------------------------------------
  -- check if we only have one intake or even none
  IF ((SELECT COUNT(1)
       FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
       WHERE LEI.BaPersonID = @BaPersonID AND
             LEI.ModulID = 7) < 2) -- zero or one intake
  BEGIN
    -- get one and only Intake
    SELECT @FaLeistungIDFirstIntake = LEI.FaLeistungID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND
          LEI.ModulID = 7 -- only IN
    
    -- done
    RETURN ISNULL(@FaLeistungIDFirstIntake, -1)
  END
  
  -----------------------------------------------------------------------------
  -- continue with more than one intake
  -----------------------------------------------------------------------------
  -- set FV-FaLeistungID if emtpy
  SET @FaLeistungIDFallverlauf = ISNULL(@FaLeistungIDFallverlauf, dbo.fnFaGetLastFaLeistungID(@BaPersonID, 2)) -- FV
  
  -----------------------------------------------------------------------------
  -- get all intakes of given FV and check which one is the first 
  -- 
  -- call is the same as in dbo.fnFaIsFirstIntake()!
  -----------------------------------------------------------------------------
  SELECT TOP 1 
         @FaLeistungIDFirstIntake = LEI.FaLeistungID
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.BaPersonID = @BaPersonID AND                                              -- only for current person
        LEI.ModulID = 7 AND                                                           -- only IN=Intake
        dbo.fnFaGetFallIDOfDL(LEI.FaLeistungID, NULL) = @FaLeistungIDFallverlauf      -- only within current FV
  ORDER BY LEI.DatumVon ASC, LEI.FaLeistungID ASC                                     -- do same ordering as in dbo.fnFaIsFirstIntake()
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@FaLeistungIDFirstIntake, -1)
END
