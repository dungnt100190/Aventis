-- init
SET NOCOUNT ON;

-- declare and init vars
DECLARE @ErrorMessage VARCHAR(MAX);
SET @ErrorMessage = NULL;

-------------------------------------------------------------------------------
-- error handling
-------------------------------------------------------------------------------
BEGIN TRANSACTION;

BEGIN TRY
  -- do some really complicated stuff here
  -- <Hier einiger Code...>
  
  -- done
  COMMIT TRANSACTION;
  PRINT ('Info: Successfully completed data handling and committed transaction.');
END TRY
BEGIN CATCH
  -- set error part
  SET @ErrorMessage = ERROR_MESSAGE();
  
  -- do rollback!
  ROLLBACK TRANSACTION;
  
  -- do not continue
  RAISERROR ('Error: Could not process data handling. Database error was: %s', 18, 1, @ErrorMessage);
  RETURN;
END CATCH;