SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject fnFaIsFirstIntake;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/FnFaIsFirstIntake.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:29 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get if FaLeistungID of Intake is the first one within Fallverlauf
    @FaLeistungID: The id of the Intake to check status
  -
  RETURNS: 1 if given Intake is the first (even when closed) or 0 if not first or undefined
  -
  TEST:    SELECT [dbo].[fnFaIsFirstIntake](151390)
           SELECT [dbo].[fnFaIsFirstIntake](151393)
           -
           Show for person: EXEC dbo.spFaGetFallInfoData 77923, 1
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/FnFaIsFirstIntake.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     5.02.09 12:33 Cjaeggi
 * Changed comment
 * 
 * 1     3.12.08 8:51 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnFaIsFirstIntake
(
  @FaLeistungID INT
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not value is passed, invalid value
  IF (ISNULL(@FaLeistungID, -1) < 1)
  BEGIN
    -- invalid value
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @BaPersonID INT
  DECLARE @FaLeistungIDFallverlauf INT
  DECLARE @FaLeistungIDFirstIntake INT

  -----------------------------------------------------------------------------
  -- get person of current id if not defined yet
  -----------------------------------------------------------------------------
  SELECT @BaPersonID = LEI.BaPersonID,                                              -- get BaPersonID of current entry
         @FaLeistungIDFallverlauf = dbo.fnFaGetFallIDOfDL(LEI.FaLeistungID, NULL)   -- get Fallverlauf of current entry
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.FaLeistungID = @FaLeistungID

  -----------------------------------------------------------------------------
  -- get first Intake for given Fallverlauf
  -- 
  -- call is the same as in dbo.fnFaGetFirstIntakeOfFV()!
  -----------------------------------------------------------------------------
  SELECT TOP 1 
         @FaLeistungIDFirstIntake = LEI.FaLeistungID
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.BaPersonID = @BaPersonID AND                                          -- only for current person
        LEI.ModulID = 7 AND                                                       -- only for Intakes
        dbo.fnFaGetFallIDOfDL(LEI.FaLeistungID, NULL) = @FaLeistungIDFallverlauf  -- only for current Fallverlauf
  ORDER BY LEI.DatumVon ASC, LEI.FaLeistungID ASC                                 -- we want the first in occurance
  
  -----------------------------------------------------------------------------
  -- check if current entry is the first entry
  -----------------------------------------------------------------------------
  IF (ISNULL(@FaLeistungIDFirstIntake, -1) = @FaLeistungID)
  BEGIN
    -- the current item is the first Intake for given Fallverlauf
    RETURN 1
  END

  -----------------------------------------------------------------------------
  -- if we are here, the current item is not the first Intake for given Fallverlauf
  ----------------------------------------------------------------------------- 
  RETURN 0
END
 