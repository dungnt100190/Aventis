-- init
SET NOCOUNT ON;

-- declare and init vars
DECLARE @ErrorMessage VARCHAR(MAX);
SET @ErrorMessage = NULL;

-------------------------------------------------------------------------------
-- error handling
-------------------------------------------------------------------------------
BEGIN TRY
  -- do some really complicated stuff here
  -- <Hier einiger Code...>
  
  -- done
  PRINT ('Info: Successfully completed data handling.');
END TRY
BEGIN CATCH
  -- set error part
  SET @ErrorMessage = ERROR_MESSAGE();
  
  -- do not continue
  RAISERROR ('Error: Could not process data handling. Database error was: %s', 18, 1, @ErrorMessage);
  RETURN;
END CATCH;