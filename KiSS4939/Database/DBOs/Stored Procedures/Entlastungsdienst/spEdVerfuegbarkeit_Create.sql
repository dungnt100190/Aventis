SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spEdVerfuegbarkeit_Create
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Entlastungsdienst/spEdVerfuegbarkeit_Create.sql $
  $Author: Cjaeggi $
  $Modtime: 7.08.09 13:09 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to create pending entries for new created EdMitarbeiter row. The required
            transaction-handling is done in calling gui.
    @EdMitarbeiterID: The id withing EdMitarbeiter.EdMitarbeiterID of the new created entry
    @UserID:          The id of the user who created the new entry
  -
  RETURNS: Nothing
  -
  TEST:    EXEC dbo.spEdVerfuegbarkeit_Create 1, 2
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Entlastungsdienst/spEdVerfuegbarkeit_Create.sql $
 * 
 * 2     7.08.09 13:10 Cjaeggi
 * Renamed function to fnGetDBRowCreatorModifier
 * 
 * 1     30.01.09 10:58 Cjaeggi
 * New stored procedure
=================================================================================================*/

CREATE PROCEDURE dbo.spEdVerfuegbarkeit_Create
(
  @EdMitarbeiterID INT,
  @UserID INT
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
  IF (@EdMitarbeiterID IS NULL OR @UserID IS NULL)
  BEGIN
    -- do not continue
    RAISERROR ('Error: Invalid EdMitarbeiterID (''%d'') and/or UserID (''%d'') parameter, cannot continue!', 18, 1, @EdMitarbeiterID, @UserID)
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @EdVerfuegbarkeitID INT
  DECLARE @Creator VARCHAR(255)
  
  -------------------------------------------------------------------------------
  -- get creator
  -------------------------------------------------------------------------------
  SET @Creator = dbo.fnGetDBRowCreatorModifier(@UserID)
  
  -------------------------------------------------------------------------------
  -- insert into EdVerfuegbarkeit
  -------------------------------------------------------------------------------
  -- EdVerfuegbarkeit
  INSERT INTO EdVerfuegbarkeit (EdMitarbeiterID, Creator, Created)
  VALUES (@EdMitarbeiterID , @Creator, GETDATE())
  
  -- get new id, used for daily-table
  SELECT @EdVerfuegbarkeitID = SCOPE_IDENTITY()
  
  -- validate
  IF (ISNULL(@EdVerfuegbarkeitID, -1) < 1)
  BEGIN
    -- do not continue
  RAISERROR ('Error: Invalid EdVerfuegbarkeitID (''%d''), entry could not be inserted into EdVerfuegbarkeit!', 18, 1, @EdVerfuegbarkeitID)
  RETURN
  END
  
  -------------------------------------------------------------------------------
  -- insert data into daily-table
  -------------------------------------------------------------------------------
  -- EdVerfuegbarkeit_ProTag (1=Monday)
  INSERT INTO EdVerfuegbarkeit_ProTag (EdVerfuegbarkeitID, WochentagID, Creator, Created)
  VALUES (@EdVerfuegbarkeitID, 1, @Creator, GETDATE())
  
  -- EdVerfuegbarkeit_ProTag (2=Tuesday)
  INSERT INTO EdVerfuegbarkeit_ProTag (EdVerfuegbarkeitID, WochentagID, Creator, Created)
  VALUES (@EdVerfuegbarkeitID, 2, @Creator, GETDATE())
  
  -- EdVerfuegbarkeit_ProTag (3=Wednesday)
  INSERT INTO EdVerfuegbarkeit_ProTag (EdVerfuegbarkeitID, WochentagID, Creator, Created)
  VALUES (@EdVerfuegbarkeitID, 3, @Creator, GETDATE())
  
  -- EdVerfuegbarkeit_ProTag (4=Thursday)
  INSERT INTO EdVerfuegbarkeit_ProTag (EdVerfuegbarkeitID, WochentagID, Creator, Created)
  VALUES (@EdVerfuegbarkeitID, 4, @Creator, GETDATE())
  
  -- EdVerfuegbarkeit_ProTag (5=Friday)
  INSERT INTO EdVerfuegbarkeit_ProTag (EdVerfuegbarkeitID, WochentagID, Creator, Created)
  VALUES (@EdVerfuegbarkeitID, 5, @Creator, GETDATE())
  
  -- EdVerfuegbarkeit_ProTag (6=Saturday)
  INSERT INTO EdVerfuegbarkeit_ProTag (EdVerfuegbarkeitID, WochentagID, Creator, Created)
  VALUES (@EdVerfuegbarkeitID, 6, @Creator, GETDATE())
  
  -- EdVerfuegbarkeit_ProTag (7=Sunday)
  INSERT INTO EdVerfuegbarkeit_ProTag (EdVerfuegbarkeitID, WochentagID, Creator, Created)
  VALUES (@EdVerfuegbarkeitID, 7, @Creator, GETDATE())
END
GO
