SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spEdVerfuegbarkeit_Delete
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Entlastungsdienst/spEdVerfuegbarkeit_Delete.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 8:59 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to remove pending data withing EdVerfuegbarkeit and EdVerfuegbarkeit_ProTag.
            The required transaction handling has to be done in gui
    @EdMitarbeiterID: The id within EdMitarbeiter, whose data has to be removed from other tables
  -
  RETURNS: Nothing
  -
  TEST:    EXEC dbo.spXX
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Entlastungsdienst/spEdVerfuegbarkeit_Delete.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     30.01.09 11:18 Cjaeggi
 * New stored procedure
=================================================================================================*/

CREATE PROCEDURE dbo.spEdVerfuegbarkeit_Delete
(
  @EdMitarbeiterID INT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@EdMitarbeiterID IS NULL)
  BEGIN
    -- do nothing
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @EdVerfuegbarkeitID INT
  
  -------------------------------------------------------------------------------
  -- get single entry within EdVerfuegbarkeit
  -------------------------------------------------------------------------------
  SELECT @EdVerfuegbarkeitID = EdVerfuegbarkeitID 
  FROM dbo.EdVerfuegbarkeit WITH (READUNCOMMITTED)
  WHERE EdMitarbeiterID = @EdMitarbeiterID
  
  -- validate
  IF (ISNULL(@EdVerfuegbarkeitID, -1) < 1)
  BEGIN
    -- do nothing, it seems entries have been removed already
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- remove entries from given id
  -------------------------------------------------------------------------------
  -- remove daily-table values
  DELETE dbo.EdVerfuegbarkeit_ProTag 
  WHERE EdVerfuegbarkeitID = @EdVerfuegbarkeitID
  
  -- remove entry in EdVerfuegbarkeit
  DELETE dbo.EdVerfuegbarkeit 
  WHERE EdVerfuegbarkeitID = @EdVerfuegbarkeitID
END
GO
