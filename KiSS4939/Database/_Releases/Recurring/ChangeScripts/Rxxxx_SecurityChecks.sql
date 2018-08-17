/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to perform security check after installing release script.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- check 1: validate doc-db-name in view XDocument (if existing)
-------------------------------------------------------------------------------
-- check if table exists > in this case, we do not need to validate view
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables TBL
            WHERE TBL.name = 'XDocument'))
BEGIN
  -- info
  PRINT ('Security-Info: Table "dbo.XDocument" exists, we do not need to validate view content.');
END
ELSE
BEGIN
  -- init vars
  DECLARE @ErrorMessage VARCHAR(2000);
  DECLARE @XDocumentViewSQLCode VARCHAR(MAX);
  DECLARE @DocDBName VARCHAR(255);
  
  SET @ErrorMessage = NULL;
  SET @XDocumentViewSQLCode = NULL;
  SET @DocDBName = '{DocDBName}';
  
  -- get script content for view
  SELECT @XDocumentViewSQLCode = OBJECT_DEFINITION(VIE.object_id)
  FROM sys.views VIE
  WHERE OBJECT_NAME(VIE.object_id) = 'XDocument';
  
  -- validate sql-definition
  IF (@XDocumentViewSQLCode IS NULL)
  BEGIN
    -- invalid program code, missing view definition
    SET @ErrorMessage = 'Expected view "dbo.XDocument" is either missing or has no definition code.';
  END;
  -- validate sql-code for proper database name (code must match with view definition)
  ELSE IF (@XDocumentViewSQLCode NOT LIKE ('%FROM ' + @DocDBName + '.dbo.XDocument%'))
  BEGIN
    -- invalid program code, invalid view definition
    SET @ErrorMessage = 'View "dbo.XDocument" contains invalid DocDBName. Expected value is "' + @DocDBName + '".';
  END;
  
  -- check error message
  IF (@ErrorMessage IS NOT NULL)
  BEGIN
    -- setup error message
    SET @ErrorMessage = 'Security-Error: ' + @ErrorMessage;
    
    -- show error message
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END
  ELSE
  BEGIN
    -- info
    PRINT ('Security-Info: View "dbo.XDocument" exists and contains expected DocDBName "' + @DocDBName + '".');
  END;
END;
GO

-------------------------------------------------------------------------------
-- check 2: Validate spXDocument_Lock, spXDocument_UnLock
-------------------------------------------------------------------------------
-- TODO...
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
