/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to automatically check all prerequisites for release script. If there
           is any error, the whole release script will be canceled and a server-log entry will
           be created!
           
           You need to be member of "SysAdmin" on sqlserver instance to run this script!
=================================================================================================*/

-------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

SET NOCOUNT ON;
GO

-- Collation-Check: wird als Print-Warning ausgegeben
{Include:Rxxxx_Check_Collation}

--=============================================================================
-- 1. check if database has exactly version of the one-and-only 
--    previous release
--=============================================================================
-- info
PRINT ('Info: ---- 1. Prerequiste - checking previous database version ----');

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
DECLARE @ErrorMessage VARCHAR(MAX);
DECLARE @ReleaseFile VARCHAR(2000);
--
DECLARE @ReleaseNumber VARCHAR(4);
DECLARE @ReleaseNumberMajor VARCHAR(1);
DECLARE @ReleaseNumberMinor VARCHAR(1);
DECLARE @ReleaseNumberRevision VARCHAR(2);
--
DECLARE @PreviousReleaseNumber VARCHAR(4);
DECLARE @CurrentDatabaseVersionNumber VARCHAR(10);

-------------------------------------------------------------------------------
-- set vars
-------------------------------------------------------------------------------
SET @ReleaseFile = '{ReleaseFile}';
SET @ReleaseFile = ISNULL(@ReleaseFile, '????');

-------------------------------------------------------------------------------
-- check release-file-content
-------------------------------------------------------------------------------
IF (@ReleaseFile NOT LIKE '%\Release ____\%')
BEGIN
  SET @ErrorMessage = 'Error: Invalid @ReleaseFile value ("' + @ReleaseFile + '"), cannot parse current release number.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- info
PRINT ('Info: @ReleaseFile="' + @ReleaseFile + '".');

-------------------------------------------------------------------------------
-- getting release-number from release-file
-------------------------------------------------------------------------------
SET @ReleaseNumber = SUBSTRING(@ReleaseFile, CHARINDEX('\Release ', @ReleaseFile, 0) + 9, 4);
SET @ReleaseNumber = ISNULL(@ReleaseNumber, '{ReleaseNumber}')

-- KiSS5000 check
IF (@ReleaseNumber = '5000')
BEGIN
  -- info
  PRINT ('Info: Detected new KiSS-5000 release, skipping version checks.');
  
  -- do not perform check for this version
  GOTO DONEFIRST;
  RETURN;
END;

-- validate
IF (@ReleaseNumber NOT LIKE '4___')
BEGIN
  SET @ErrorMessage = 'The current release number "' + @ReleaseNumber + '" from @ReleaseFile does not match the expected pattern.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- parse
SELECT @ReleaseNumberMajor    = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 1, 1),
       @ReleaseNumberMinor    = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 2, 1),
       @ReleaseNumberRevision = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 3, 2);

-- info
PRINT ('Info: Detected release number "' + @ReleaseNumberMajor + '.' + @ReleaseNumberMinor + '.' + @ReleaseNumberRevision + '" for current release.');

-------------------------------------------------------------------------------
-- calc previous release number for database
-------------------------------------------------------------------------------
SET @PreviousReleaseNumber =  CASE @ReleaseNumber 
                                WHEN '4644' THEN '4632'
                                WHEN '4709' THEN '4644'
                                WHEN '4731' THEN '4709'
                                WHEN '4741' THEN '4731'
                                WHEN '4806' THEN '4741'
                                WHEN '4829' THEN '4806'
                                WHEN '4839' THEN '4829'
                                WHEN '4906' THEN '4839'
                                WHEN '4929' THEN '4906'
                                WHEN '4939' THEN '4929'
                                ELSE '????'
                              END;

SET @PreviousReleaseNumber = ISNULL(@PreviousReleaseNumber, '????');

-- validate
IF (@PreviousReleaseNumber NOT LIKE '4___')
BEGIN
  SET @ErrorMessage = 'The calculated version "' + @PreviousReleaseNumber + '" for previous database release does not match the expected pattern.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- info
PRINT ('Info: Calculated expected previous database version "' + @PreviousReleaseNumber + '".');

-------------------------------------------------------------------------------
-- get current database version
-------------------------------------------------------------------------------
SELECT @CurrentDatabaseVersionNumber = CONVERT(VARCHAR, DBV.MajorVersion) +
                                       CONVERT(VARCHAR, DBV.MinorVersion) +
                                       CASE 
                                         WHEN LEN(CONVERT(VARCHAR, DBV.Build)) = 1 THEN '0' + CONVERT(VARCHAR, DBV.Build)
                                         ELSE CONVERT(VARCHAR, DBV.Build)
                                       END
FROM dbo.XDBVersion DBV WITH (READUNCOMMITTED)
WHERE DBV.XDBVersionID = dbo.fnXDBVersionGetCurrentDBVersionID();

SET @CurrentDatabaseVersionNumber = ISNULL(@CurrentDatabaseVersionNumber, '????');

-- info
PRINT ('Info: Current database version "' + @CurrentDatabaseVersionNumber + '".');

-------------------------------------------------------------------------------
-- check if last database version is the calculated previous version
-------------------------------------------------------------------------------
IF (@CurrentDatabaseVersionNumber <> @PreviousReleaseNumber)
BEGIN
  SET @ErrorMessage = 'The current database version does not match with the expected value (current="' + @CurrentDatabaseVersionNumber + '", expected="' + @PreviousReleaseNumber + '"). Please take the release script that matches with your current database version.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- info
PRINT ('Info: Database version is valid - continue with release script.');

-------------------------------------------------------------------------------
-- done info
-------------------------------------------------------------------------------
DONEFIRST:
PRINT ('Info: ---- 1. Prerequiste - done ----');
GO

--=============================================================================
-- 2. ...
--=============================================================================
-- TODO: Maybe we can check NSE ($NSE) so that a releasescript for one customer cannot be executed for another customer --> store $NSE in XDBVersion table.
GO

--=============================================================================
-- 3. security check before installing release script
--=============================================================================
{Include:Rxxxx_ZH_SecurityChecks_Prerequisites:IFNSE=ZH}

GO

--=============================================================================
-- 4. ...
--=============================================================================
GO