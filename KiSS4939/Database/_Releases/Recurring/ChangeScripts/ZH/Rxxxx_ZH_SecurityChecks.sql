/*===============================================================================================
  $Revision: 7 $
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
-- check 1: check that current identity for BaPerson ist < 500'000
-------------------------------------------------------------------------------
DECLARE @NextBaPersonID INT;
DECLARE @ErrorMessage VARCHAR(MAX);

SET @NextBaPersonID = IDENT_CURRENT('BaPerson');
IF (@NextBaPersonID >= 499000)
BEGIN
  -- setup error message
  SET @ErrorMessage = 'Security-Error: PSCD akzeptiert nur Personen mit ID < 500''000, die nächste Person erhält ID ' + CONVERT(VARCHAR,@NextBaPersonID);
  
  -- show error message
  RAISERROR (@ErrorMessage, 18, 1);
END

GO

-------------------------------------------------------------------------------
-- check 2: validate VIS-server-name and VIS-db-name in VIS-views
--           - vwVIS_DOSSIER
--           - vwVIS_MANDATSTRAEGER
--           - vwVIS_MASSNAHMEN
--           - vwVIS_MASSNAHMEN_HIST
--           - vwVIS_ABTEILUNG
--           - vwVIS_BERICHT
--           - vwVIS_OPERATION
-------------------------------------------------------------------------------
-- init vars
DECLARE @ErrorMessage VARCHAR(2000);
DECLARE @VisViewSqlCode VARCHAR(MAX);
DECLARE @VisServerName VARCHAR(255);
DECLARE @VisDBName VARCHAR(255);
  
SET @VisServerName = '{VisServerName}';
SET @VisDBName = '{VisDBName}';
  
-----------------------------------
-- init vars and table
-----------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @ViewName VARCHAR(255);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  ViewName VARCHAR(255)
);

-----------------------------------
-- insert entries into temp table
-----------------------------------
INSERT INTO @TempTable (ViewName)
  SELECT 'vwVIS_DOSSIER' UNION ALL
  SELECT 'vwVIS_MANDATSTRAEGER' UNION ALL
  SELECT 'vwVIS_MANDATSTRAEGER_SIMPLE' UNION ALL
  SELECT 'vwVIS_MASSNAHMEN' UNION ALL
  SELECT 'vwVIS_MASSNAHMEN_HIST' UNION ALL
  SELECT 'vwVIS_ABTEILUNG' UNION ALL
  SELECT 'vwVIS_BERICHT' UNION ALL
  SELECT 'vwVIS_OPERATION'

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-----------------------------------
-- loop all entries
-----------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @ViewName = TMP.ViewName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  SET @ErrorMessage = NULL;
  SET @VisViewSqlCode = NULL;

  -----------------------------------
    -- get script content for view
  -----------------------------------
  SELECT @VisViewSqlCode = OBJECT_DEFINITION(VIE.object_id)
  FROM sys.views VIE
  WHERE OBJECT_NAME(VIE.object_id) = @ViewName;
    
  -----------------------------------
    -- validate sql-definition
  -----------------------------------
  IF (@VisViewSqlCode IS NULL)
  BEGIN
    -- invalid program code, missing view definition
    SET @ErrorMessage = 'Expected view "dbo.' + @ViewName + '" is either missing or has no definition code.';
  END;
  -- validate sql-code for proper database name (code must match with view definition)
  ELSE IF (@VisViewSqlCode NOT LIKE '%' + @VisServerName + '%' OR @VisViewSqlCode NOT LIKE  + '%' + @VisDBName + '%')
  BEGIN
    -- invalid program code, invalid view definition
    SET @ErrorMessage = 'View "dbo.' + @ViewName + '" contains invalid VisServerName or VisDBName. Expected values are "' + @VisServerName + '", "' + @VisDBName + '".';
  END;
    
  -----------------------------------
    -- check error message
  -----------------------------------
  IF (@ErrorMessage IS NOT NULL)
  BEGIN
    -- setup error message
    SET @ErrorMessage = 'Security-Error: ' + @ErrorMessage;
      
    -- show error message
    RAISERROR (@ErrorMessage, 18, 1);
  END
  ELSE
  BEGIN
    -- info
    PRINT ('Security-Info: View "dbo.' + @ViewName + '" exists and contains expected VisServerName "' + @VisServerName + '" and VisDBName "' + @VisDBName + '".');
  END;
  -----------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
