PRINT ('
************************************************************
  START OF COMBINED SCRIPTS!
************************************************************
  Settings:
    settingsFile: [-]
    defaultFileEnding: [.sql]
    releaseFile: [_Releases\Release 4939\1. Dispatcher\Standard\Dispatcher.sql]
    searchFolder: [.]
    namespace extension: [BSS;SepDocDB;Standard;~ZH;$Standard]
    databaseName: [KiSS4_I]
    databaseName document: [KiSS4_DOC_I]
    databaseRootDirectory: [E:\sql-daten]
    sql username: [kiss3]
    TFS check in: [True]
    TFS url: [http://dtvs0034:8080/tfs/KiSS-Projects]
    TFS user name: []
    TFS directory: []
    TFS workspace name: []
    VIS server name: []
    VIS database name: []
    Release number: [4939]
    Custom parameters: [Language=de]
  Information:
    machine: [DTVS0033]
    user: [sa-kiss-tfs-agent]
    time: [02.03.2018 10:32:54]
    version: [2.1.6523.29673]
************************************************************
');
PRINT ('  Info: Start of script: [' + CONVERT(VARCHAR, GETDATE(), 113) + ']');
PRINT ('
************************************************************
');

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
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

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to verify that the DB has the same collation as the server.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Check collation
-------------------------------------------------------------------------------
DECLARE @ServerCollation VARCHAR(50);
DECLARE @DBCollation VARCHAR(50);

SELECT
  @ServerCollation = CONVERT(VARCHAR(50), SERVERPROPERTY('Collation')),
  @DBCollation = CONVERT(VARCHAR(50), DATABASEPROPERTYEX(DB_NAME(), 'Collation'));

IF (@ServerCollation != @DBCollation)
BEGIN
  PRINT ('Warning: Different Server/Database collation! Server: ' + @ServerCollation + ', Database: ' + @DBCollation);
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql' -------- */


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
SET @ReleaseFile = '_Releases\Release 4939\1. Dispatcher\Standard\Dispatcher.sql';
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
SET @ReleaseNumber = ISNULL(@ReleaseNumber, '4939')

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


GO

--=============================================================================
-- 4. ...
--=============================================================================
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update document handling object with its proper database 
           information.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 6 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- view: XDocument (only SepDocDB!)
-------------------------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\SepDocDB\XDocument.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\SepDocDB\XDocument.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
IF EXISTS(SELECT TOP 1 1 FROM SYSOBJECTS WHERE name LIKE 'XDocument' AND xtype LIKE 'V')
BEGIN
  DROP VIEW dbo.XDocument
END
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/XDocument.sql $
  $Author: Lloreggia $
  $Modtime: 23.12.09 17:06 $
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this view, if XDocument is located in a different DB
  -
  ATTENTION: - KISS4_BSS_MasterDev_DOC.dbo.XDocument have to be modified für different customers !!!
             - Do not insert this view if table XDocument already exists on same database !!!
  -
  RETURNS: all fields of table XDocument.
  -
  TEST:    SELECT * from dbo.XDocument
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/XDocument.sql $
 * 
 * 13    23.12.09 17:06 Lloreggia
 * Übernahme der Änderungen aus dem Branch 4.1.48
 * 
 * 12    13.11.09 15:38 Lloreggia
 * Updated to latest version (DB creation script working)
 * 
 * 11    2.09.09 7:55 Nweber
 * #4932: Dokumenten DB-Name mit KiSS4_I_DOC ersetzen für das neue
 * Release-Tool
 * 
 * 10    25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 9     18.06.09 15:23 Rhesterberg
 * #2499: Gleichzeitige Bearbeitung von Dokumenten (Locking)
 * 
 * 8     18.06.09 14:00 Rhesterberg
 * #2499: Gleichzeitige Bearbeitung von Dokumenten (Locking)
 * 
 * 7     17.06.09 17:03 Cjaeggi
 * #2499: Gleichzeitige Bearbeitung von Dokumenten
=================================================================================================*/

CREATE VIEW [dbo].[XDocument]
AS 

SELECT 
  DocumentID, DateCreation, UserID_Creator,
  FileBinary, DocFormatCode, FileExtension, DocReadOnly, DocTemplateID, XDocumentTS, 
  UserID_LastRead, DateLastRead, UserID_LastSave, DateLastSave, 
  DocTypeCode, DocTemplateName, 
  CheckOut_UserID, CheckOut_Date, CheckOut_Filename, CheckOut_Machine
FROM KiSS4_DOC_I.dbo.XDocument
--@@TODO ???

GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\SepDocDB\XDocument.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\SepDocDB\XDocument.sql' -------- */

GO

-------------------------------------------------------------------------------------------------
-- spXDocument_Lock
-------------------------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXDocument_Lock;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to access-lock specific document for other users
    @DocumentID:          ID of either XDocument or XDocTemplate
    @CheckOutUserID:      The user id who locks the document
    @CheckoutFilename:    The local filename including path of locked document
    @CheckoutMachinename: The name of the computer of the user who locks the document
    @IsTemplate:          Is it a template? TRUE = locks XDocTemplate, FALSE = locks XDocument
  -
  RETURNS: Nothing or in case of error the error-code used for mulitlanguage message
=================================================================================================
  TEST:    EXEC dbo.spXDocument_Lock -1, -1, NULL, NULL, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spXDocument_Lock
(
  @DocumentID INT,
  @CheckoutUserID INT,
  @CheckoutFilename VARCHAR(MAX),
  @CheckoutMachinename VARCHAR(MAX),
  @IsTemplate BIT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DocumentID, -1) < 1 OR ISNULL(@CheckOutUserID, -1) < 1 
      OR @CheckoutFilename IS NULL OR @CheckoutMachinename IS NULL
      OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('LockInvalidParameters' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- vars II.
  -----------------------------------------------------------------------------
  -- declare vars
  DECLARE @tmpCheckoutUserID INT;
  DECLARE @tmpCheckoutDate DATETIME;
  DECLARE @tmpUserName VARCHAR(200);
  DECLARE @tmpCheckoutFilename VARCHAR(MAX);
  DECLARE @tmpCheckoutMachinename VARCHAR(MAX);
  
  -----------------------------------------------------------------------------
  -- get current checked-out values
  -- ensure transaction was started from outer call of stored procedure
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    -- using XDocTemplate
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL(' ' + USR.FirstName, '')
    FROM dbo.XDocTemplate DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    -- using table XDocument by using view XDocument
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL(' ' + USR.FirstName, '')
    FROM dbo.XDocument DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocumentID = @DocumentID;
  END;
  
  -----------------------------------------------------------------------------
  -- check for existing chekcouts
  -----------------------------------------------------------------------------
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID != @CheckoutUserID)
  BEGIN
    -- file locked by other user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('FileIsLockedByAnotherUser' , 18, 1);
    RETURN;
  END
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID = @CheckoutUserID)
  BEGIN
    -- file locked by the actual user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('FileIsLockedByActualUser' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- no error occured, lock the document
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocTemplate
    --
    -- ATTENTION: 
    -- never change the DB for different customers (e.g. KISS4_BSS_MasterDev_DOC.dbo.XDocTemplate)
    -- XDocTemplate is always stored in the main DB, never in the document DB, for any customer
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocTemplate 
    SET CheckOut_UserID = @CheckoutUserID, 
        CheckOut_Date = GETDATE(), 
        CheckOut_Filename = @CheckoutFilename, 
        CheckOut_Machine = @CheckoutMachinename
    WHERE DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocument (updating using view or table)
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocument 
    SET CheckOut_UserID = @CheckoutUserID, 
        CheckOut_Date = GETDATE(), 
        CheckOut_Filename = @CheckoutFilename, 
        CheckOut_Machine = @CheckoutMachinename
    WHERE DocumentID = @DocumentID;
  END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql' -------- */

GO

-------------------------------------------------------------------------------------------------
-- spXDocument_UnLock
-------------------------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXDocument_UnLock;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to access-unlock specific document for other users
    @DocumentID: ID of either XDocument or XDocTemplate
    @IsTemplate: Is it a template? TRUE = unlocks XDocTemplate, FALSE = unlocks XDocument-
  RETURNS: Nothing or in case of error the errormessage
=================================================================================================
  TEST:    EXEC dbo.spXDocument_UnLock -1, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spXDocument_UnLock
(
  @DocumentID INT,
  @IsTemplate BIT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DocumentID, -1) < 1 OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('UnLockInvalidParameters' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- unlock documents
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocTemplate
    -- 
    -- ATTENTION: 
    -- never change the DB for different customers (e.g. KISS4_BSS_MasterDev_DOC.dbo.XDocTemplate)
    -- XDocTemplate is always stored in the main DB, never in the document DB, for any customer
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocTemplate 
    SET CheckOut_UserID = NULL, 
        CheckOut_Date = NULL, 
        CheckOut_Filename = NULL, 
        CheckOut_Machine = NULL
    WHERE DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocument (updating using view or table)
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocument 
    SET CheckOut_UserID = NULL, 
        CheckOut_Date = NULL, 
        CheckOut_Filename = NULL, 
        CheckOut_Machine = NULL
    WHERE DocumentID = @DocumentID;
  END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql' -------- */

GO

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to (re)create aggregate functions on database (x86 and x64).
           This script needs some extra rights and should be executed with sysadmin rights.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- drop functions first
-------------------------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1 FROM sysobjects WHERE Type = 'AF' AND [Name] = 'Conc'))
BEGIN
  DROP AGGREGATE [dbo].[Conc];
  DROP AGGREGATE [dbo].[ConcDistinct];
  DROP AGGREGATE [dbo].[ConcDistinctOrder];
  DROP ASSEMBLY [StringConcatenate];
END;

-------------------------------------------------------------------------------------------------
-- create assembly
-------------------------------------------------------------------------------------------------
IF (@@VERSION LIKE '%X64)%')
BEGIN
  -- Assembly erstellen für x64
  CREATE ASSEMBLY [StringConcatenate]
  AUTHORIZATION [dbo]
  FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A24000000000000005045000064860200FF13054B0000000000000000F00022200B0208000010000000100000000000000000000000200000000040000000000000200000001000000400000000000000040000000000000000600000001000000000000003004085000040000000000000400000000000000000100000000000002000000000000000000000100000000000000000000000000000000000000000400000A803000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000004800000000000000000000002E74657874000000E00C0000002000000010000000100000000000000000000000000000200000602E72737263000000A8030000004000000010000000200000000000000000000000000000400000402E72656C6F630000000000000060000000000000003000000000000000000000000000004000004200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004800000002000500A8220000380A0000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003202731000000A7D010000042ADE0F01281100000A2C012A027B010000040F01FE16040000016F1200000A6F1300000A2D12027B010000040F01281400000A6F1500000A2A4E027B010000040F017B010000046F1600000A2A9A027B010000046F1700000A7201000070027B010000046F1800000A281900000A281A00000A2A13300500240000000100001102036F1B00000A178D1C0000010A06161F2C9D066F1C00000A731D00000A7D010000042A9E027B010000046F1700000A037201000070027B010000046F1800000A281900000A6F1E00000A2A3202731000000A7D020000042ADE0F01281100000A2C012A027B020000040F01FE16040000016F1200000A6F1300000A2D12027B020000040F01281400000A6F1500000A2A4E027B020000040F017B020000046F1600000A2A6E7201000070027B020000046F1800000A281900000A281A00000A2A00000013300500240000000100001102036F1B00000A178D1C0000010A06161F2C9D066F1C00000A731D00000A7D020000042A72037201000070027B020000046F1800000A281900000A6F1E00000A2A3202731F00000A7D030000042A960F01281100000A2C012A027B030000040F01281400000A6F2000000A1F2C6F2100000A262A52027B030000040F017B030000046F2200000A262A000000133004003D000000020000117E2300000A0A027B030000042C28027B030000046F2400000A16311A027B0300000416027B030000046F2400000A17596F2500000A0A06732600000A2A4A02036F1B00000A732700000A7D030000042A4A03027B030000046F1200000A6F1E00000A2A0042534A4201000100000000000C00000076322E302E35303732370000000005006C00000018040000237E000084040000F803000023537472696E6773000000007C08000008000000235553008408000010000000234755494400000094080000A401000023426C6F620000000000000002000001571702080900000000FA013300160000010000001C0000000400000003000000120000000C00000003000000270000000D0000000200000001000000010000000200000000000A0001000000000006004C0045000A007D0062000600A9008E000A00DD00C80006000C01020106001E01020106003D01310106005D014B0106009B017C010600AF014B010600C8014B010600E3014B010600FE014B01060017024B01060030024B0106004F024B0106006C024B010600A30283020600C30283020600EB0245000A00010362000A0022036200060029037C0106003F037C0106005B034500060088038E000600AC0345000600D103450000000000010000000000010001000921100018000000050001000100092110002A0000000500020007000921100037000000050003000D000100B0000A000100B0000A000100B00038005020000000008600C300110001005D20000000008600E700150001009520000000008600F2001B000200A920000000008600F80021000300D02000000000E601190126000300002100000000E6012B012C0004002821000000008600C300110005003521000000008600E700150005006D21000000008600F200320006008121000000008600F80021000700A02100000000E601190126000700D02100000000E6012B012C000800ED21000000008600C30011000900FA21000000008600E700150009002022000000008600F2003C000A003822000000008600F80021000B00812200000000E601190126000B00942200000000E6012B012C000C00000001004A0300000100820300000100C40300000100DC03000001004A0300000100820300000100C40300000100DC03000001004A0300000100820300000100C40300000100DC03020009000300090004000900410076014200490076014700510076014200590076014200610076014200690076014200710076014200790076014200810076014200890076014200910076014C00990076011100A10076011100A90076015100B9007601B9000C007601110021005003C500C9006203C9000C006B03CD0021007403C9000C007E03D3000C009603D9000C009F0311000C00A403E300D900B303E9002100B803F0002900C603C900D900D603F6000C007601D90031002B0142003900760111003900DE0302013900DE0308013900DE030E01D900E50314013900EB031701390062031B012100760142003900760142002E00330055012E00630085012E00130025012E00230025012E002B002B012E003B0064012E00430025012E004B0025012E00530055012E005B007C01430073005700630073005700830073005700FD002101BF0004800000010000001A0EC74B000000000000E102000002000000000000000000000001003C0000000000020000000000000000000000010056000000000000000000003C4D6F64756C653E004167677265676174652E646C6C00436F6E6344697374696E63744F7264657200436F6E6344697374696E637400436F6E63006D73636F726C69620053797374656D0056616C7565547970650053797374656D2E44617461004D6963726F736F66742E53716C5365727665722E536572766572004942696E61727953657269616C697A650053797374656D2E436F6C6C656374696F6E732E47656E65726963004C697374603100696E7465726D656469617465526573756C7400496E69740053797374656D2E446174612E53716C54797065730053716C537472696E6700416363756D756C617465004D65726765005465726D696E6174650053797374656D2E494F0042696E61727952656164657200526561640042696E6172795772697465720057726974650053797374656D2E5465787400537472696E674275696C6465720053797374656D2E5265666C656374696F6E00417373656D626C7956657273696F6E417474726962757465002E63746F720053797374656D2E52756E74696D652E496E7465726F70536572766963657300436F6D56697369626C6541747472696275746500417373656D626C7943756C7475726541747472696275746500417373656D626C7954726164656D61726B41747472696275746500417373656D626C79436F7079726967687441747472696275746500417373656D626C7950726F6475637441747472696275746500417373656D626C79436F6D70616E7941747472696275746500417373656D626C79436F6E66696775726174696F6E41747472696275746500417373656D626C794465736372697074696F6E41747472696275746500417373656D626C795469746C654174747269627574650053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300436F6D70696C6174696F6E52656C61786174696F6E734174747269627574650052756E74696D65436F6D7061746962696C697479417474726962757465004167677265676174650053657269616C697A61626C654174747269627574650053716C55736572446566696E656441676772656761746541747472696275746500466F726D6174005374727563744C61796F7574417474726962757465004C61796F75744B696E640076616C7565006765745F49734E756C6C004F626A65637400546F537472696E6700436F6E7461696E73006765745F56616C756500416464006F746865720049456E756D657261626C6560310041646452616E676500536F727400546F417272617900537472696E67004A6F696E006F705F496D706C6963697400720052656164537472696E6700436861720053706C6974007700417070656E6400456D707479006765745F4C656E67746800000000032C000000000053D11236BE48D2419BD3042636AA6F140008B77A5C561934E089060615120D010E03200001052001011111052001011108042000111105200101121505200101121905200101110C0306121D052001011110042001010E042001010204200101080520010111596101000200000004005402124973496E76617269616E74546F4E756C6C73015402174973496E76617269616E74546F4475706C696361746573005402124973496E76617269616E74546F4F726465720054080B4D61784279746553697A65401F00000520010111610515120D010E032000020320000E052001021300052001011300092001011512690113000520001D13000600020E0E1D0E05000111110E0620011D0E1D030407011D03052001121D0E052001121D03052001121D1C02060E032000080520020E08080307010E05010000000029010024436F7079726967687420C2A920426F726E20496E666F726D6174696B204147203230303800000E010009416767726567617465000017010012426F726E20496E666F726D6174696B20414700000801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F7773010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001001000000018000080000000000000000000000000000001000100000030000080000000000000000000000000000001000000000048000000584000004C03000000000000000000004C0334000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE0000010000000100C74B1A0E00000100C74B1A0E3F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B004AC020000010053007400720069006E006700460069006C00650049006E0066006F00000088020000010030003000300030003000340062003000000048001300010043006F006D00700061006E0079004E0061006D0065000000000042006F0072006E00200049006E0066006F0072006D006100740069006B00200041004700000000003C000A000100460069006C0065004400650073006300720069007000740069006F006E0000000000410067006700720065006700610074006500000040000F000100460069006C006500560065007200730069006F006E000000000031002E0030002E0033003600310030002E0031003900330039003900000000003C000E00010049006E007400650072006E0061006C004E0061006D00650000004100670067007200650067006100740065002E0064006C006C0000006C00240001004C006500670061006C0043006F007000790072006900670068007400000043006F0070007900720069006700680074002000A900200042006F0072006E00200049006E0066006F0072006D006100740069006B0020004100470020003200300030003800000044000E0001004F0072006900670069006E0061006C00460069006C0065006E0061006D00650000004100670067007200650067006100740065002E0064006C006C00000034000A000100500072006F0064007500630074004E0061006D00650000000000410067006700720065006700610074006500000044000F000100500072006F006400750063007400560065007200730069006F006E00000031002E0030002E0033003600310030002E00310039003300390039000000000048000F00010041007300730065006D0062006C0079002000560065007200730069006F006E00000031002E0030002E0033003600310030002E0031003900330039003900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
  WITH PERMISSION_SET = SAFE;
END;
ELSE
BEGIN
  -- Assembly erstellen für x86
  CREATE ASSEMBLY [StringConcatenate]
  AUTHORIZATION [dbo]
  FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C0103000FEB254B0000000000000000E00002210B010800001000000020000000000000AE2E00000020000000400000000040000020000000100000040000000000000004000000000000000080000000100000000000000300408500001000001000000000100000100000000000001000000000000000000000005C2E00004F00000000400000A803000000000000000000000000000000000000006000000C000000CC2D00001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E74657874000000B40E0000002000000010000000100000000000000000000000000000200000602E72737263000000A8030000004000000010000000200000000000000000000000000000400000402E72656C6F6300000C00000000600000001000000030000000000000000000000000000040000042000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000902E000000000000480000000200050028230000A40A00000300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000360002731100000A7D010000042A0000133002002C00000001000011000F01281200000A16FE010A062D022B1A027B010000040F01281300000A6F1400000A1F2C6F1500000A262A5600027B010000040F017B010000046F1600000A262A0000133004004C00000002000011007E1700000A0A027B010000042C13027B010000046F1800000A16FE0216FE012B01170C082D1A027B0100000416027B010000046F1800000A17596F1900000A0A06731A00000A0B2B00072A4E0002036F1B00000A731C00000A7D010000042A520003027B010000046F1D00000A6F1E00000A002A360002731F00000A7D020000042A00133002004100000001000011000F01281200000A16FE010A062D022B2F027B020000040F01FE16040000016F1D00000A6F2000000A0A062D13027B020000040F01281300000A6F2100000A002A5600027B020000040F017B020000046F2200000A002A00133002002000000003000011007201000070027B020000046F2300000A282400000A282500000A0A2B00062A1330050025000000040000110002036F1B00000A178D1E0000010A06161F2C9D066F2600000A732700000A7D020000042A7A00037201000070027B020000046F2300000A282400000A6F1E00000A002A360002731F00000A7D030000042A0000133002004100000001000011000F01281200000A16FE010A062D022B2F027B030000040F01FE16040000016F1D00000A6F2000000A0A062D13027B030000040F01281300000A6F2100000A002A5600027B030000040F017B030000046F2200000A002A00133002002C0000000300001100027B030000046F2800000A007201000070027B030000046F2300000A282400000A282500000A0A2B00062A1330050025000000040000110002036F1B00000A178D1E0000010A06161F2C9D066F2600000A732700000A7D030000042AAA00027B030000046F2800000A00037201000070027B030000046F2300000A282400000A6F1E00000A002A42534A4201000100000000000C00000076322E302E35303732370000000005006C00000034040000237E0000A00400002C04000023537472696E677300000000CC0800000800000023555300D4080000100000002347554944000000E4080000C001000023426C6F620000000000000002000001571702080900000000FA013300160000010000001E0000000400000003000000120000000C00000003000000280000000E0000000400000001000000010000000200000000000A0001000000000006004C0045000A007D00620006009A008E000A00D500C00006000401FA0006001601FA0006004401290106005D014B0106009B017C010600AF014B010600C8014B010600E3014B010600FE014B01060017024B01060030024B0106004F024B0106006C024B010600960283024B00AA0200000600D902B9020600F902B9020600210345000A00370362000A005803620006005F037C01060075037C010600A80345000600D80345000600EC03290106001C04450000000000010000000000010001000921100018000000050001000100092110001D000000050002000700092110002A000000050003000D000100A8000A000100A8002F000100A8002F005020000000008600BB000E0001006020000000008600DF00120001009820000000008600EA0018000200B020000000008600F0001E000300082100000000E6011101230003001C2100000000E6012301290004003121000000008600BB000E0005004021000000008600DF00120005008D21000000008600EA0036000600A421000000008600F0001E000700D02100000000E601110123000700012200000000E6012301290008002022000000008600BB000E0009003022000000008600DF00120009007D22000000008600EA003C000A009422000000008600F0001E000B00CC2200000000E601110123000B00FD2200000000E601230129000C0000000100800300000100A20300000100C90300000100D60300000100800300000100A20300000100C90300000100D60300000100800300000100A20300000100C90300000100D603020009000300090004000900410076014200490076014700510076014200590076014200610076014200690076014200710076014200790076014200810076014200890076014200910076014C00A10076015200A90076010E00B10076010E00B90076015700C9007601BF00190076010E0021008603C50021009103C90019009B03CD0019009B03D30019009B03DD00D900AF03E3001900B503E6001900C003EA002100760142002900CB03C900190076014200E100C003C9003100230142000C0076010E000C00DF03FD000C00E80303010C00FA0309010C0003041301D9000B041901210010042001D90021042B010C00760109010C0027040E002E00330067012E003B0076012E00630097012E00130037012E00230037012E002B003D012E006B00A0012E00430037012E004B0037012E00530067012E005B008E0143007B005D0063007B005D0083007B005D00D900F00026013201F7000480000001000000330E8F3C0000000000001703000002000000000000000000000001003C0000000000020000000000000000000000010056000000000000000000003C4D6F64756C653E004167677265676174652E646C6C00436F6E6300436F6E6344697374696E637400436F6E6344697374696E63744F72646572006D73636F726C69620053797374656D0056616C7565547970650053797374656D2E44617461004D6963726F736F66742E53716C5365727665722E536572766572004942696E61727953657269616C697A650053797374656D2E5465787400537472696E674275696C64657200696E7465726D656469617465526573756C7400496E69740053797374656D2E446174612E53716C54797065730053716C537472696E6700416363756D756C617465004D65726765005465726D696E6174650053797374656D2E494F0042696E61727952656164657200526561640042696E6172795772697465720057726974650053797374656D2E436F6C6C656374696F6E732E47656E65726963004C69737460310053797374656D2E5265666C656374696F6E00417373656D626C7956657273696F6E417474726962757465002E63746F720053797374656D2E52756E74696D652E496E7465726F70536572766963657300436F6D56697369626C6541747472696275746500417373656D626C7943756C7475726541747472696275746500417373656D626C7954726164656D61726B41747472696275746500417373656D626C79436F7079726967687441747472696275746500417373656D626C7950726F6475637441747472696275746500417373656D626C79436F6D70616E7941747472696275746500417373656D626C79436F6E66696775726174696F6E41747472696275746500417373656D626C794465736372697074696F6E41747472696275746500417373656D626C795469746C654174747269627574650053797374656D2E446961676E6F73746963730044656275676761626C6541747472696275746500446562756767696E674D6F6465730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300436F6D70696C6174696F6E52656C61786174696F6E734174747269627574650052756E74696D65436F6D7061746962696C697479417474726962757465004167677265676174650053657269616C697A61626C654174747269627574650053716C55736572446566696E656441676772656761746541747472696275746500466F726D6174005374727563744C61796F7574417474726962757465004C61796F75744B696E640076616C7565006765745F49734E756C6C006765745F56616C756500417070656E64006F7468657200537472696E6700456D707479006765745F4C656E67746800546F537472696E6700720052656164537472696E670077004F626A65637400436F6E7461696E73004164640049456E756D657261626C6560310041646452616E676500546F4172726179004A6F696E006F705F496D706C6963697400436861720053706C697400536F72740000032C0000000000E6B47244306DD344864147A778C26E550008B77A5C561934E0890306120D032000010520010111110520010111080420001111052001011215052001011219060615121D010E05200101110C052001011110042001010E042001010205200101114D04200101080520010111616101000200000004005402124973496E76617269616E74546F4E756C6C73015402174973496E76617269616E74546F4475706C696361746573005402124973496E76617269616E74546F4F726465720054080B4D61784279746553697A65401F0000052001011169032000020320000E052001120D0E052001120D0303070102052001120D1C02060E032000080520020E08080607030E1111020515121D010E052001021300052001011300092001011512750113000520001D13000600020E0E1D0E05000111110E04070111110620011D0E1D030407011D0305010000000029010024436F7079726967687420C2A920426F726E20496E666F726D6174696B204147203230303800000E010009416767726567617465000017010012426F726E20496E666F726D6174696B20414700000801000701000000000801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F77730100000000000FEB254B000000000200000071000000E82D0000E81D0000525344534913C6E99C6C6A469A3E7C4FAF2672B501000000433A5C50726F6A656374735C4B69535334305C546F6F6C735C55736572446566696E656446756E6374696F6E735C554446735C4167677265676174655C6F626A5C7838365C44656275675C4167677265676174652E70646200000000842E000000000000000000009E2E0000002000000000000000000000000000000000000000000000902E0000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF25002040000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001001000000018000080000000000000000000000000000001000100000030000080000000000000000000000000000001000000000048000000584000004C03000000000000000000004C0334000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE00000100000001008F3C330E000001008F3C330E3F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B004AC020000010053007400720069006E006700460069006C00650049006E0066006F00000088020000010030003000300030003000340062003000000048001300010043006F006D00700061006E0079004E0061006D0065000000000042006F0072006E00200049006E0066006F0072006D006100740069006B00200041004700000000003C000A000100460069006C0065004400650073006300720069007000740069006F006E0000000000410067006700720065006700610074006500000040000F000100460069006C006500560065007200730069006F006E000000000031002E0030002E0033003600330035002E0031003500350030003300000000003C000E00010049006E007400650072006E0061006C004E0061006D00650000004100670067007200650067006100740065002E0064006C006C0000006C00240001004C006500670061006C0043006F007000790072006900670068007400000043006F0070007900720069006700680074002000A900200042006F0072006E00200049006E0066006F0072006D006100740069006B0020004100470020003200300030003800000044000E0001004F0072006900670069006E0061006C00460069006C0065006E0061006D00650000004100670067007200650067006100740065002E0064006C006C00000034000A000100500072006F0064007500630074004E0061006D00650000000000410067006700720065006700610074006500000044000F000100500072006F006400750063007400560065007200730069006F006E00000031002E0030002E0033003600330035002E00310035003500300033000000000048000F00010041007300730065006D0062006C0079002000560065007200730069006F006E00000031002E0030002E0033003600330035002E0031003500350030003300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000C000000B03E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
  WITH PERMISSION_SET = SAFE;
END;

-------------------------------------------------------------------------------------------------
-- link functions to assemby
-------------------------------------------------------------------------------------------------
-- User-defined functions (UDF) erstellen
CREATE AGGREGATE [dbo].[Conc]
(@input [nvarchar](200))
RETURNS[nvarchar](4000)
EXTERNAL NAME [StringConcatenate].[Conc];

CREATE AGGREGATE [dbo].[ConcDistinct]
(@input [nvarchar](200))
RETURNS[nvarchar](4000)
EXTERNAL NAME [StringConcatenate].[ConcDistinct];

CREATE AGGREGATE [dbo].[ConcDistinctOrder]
(@input [nvarchar](200))
RETURNS[nvarchar](4000)
EXTERNAL NAME [StringConcatenate].[ConcDistinctOrder];
GO

-------------------------------------------------------------------------------------------------
-- config server
-------------------------------------------------------------------------------------------------
EXEC sp_configure 'clr enabled', 1;
GO

RECONFIGURE WITH OVERRIDE
PRINT 'RECONFIGURE has been executed.';
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply only required rights to KiSS database user 
           (kiss3, kiss, kiss4_pi, ...)
           
  HINTS:   - To fix on changes, too: /Database/Scripts/Automation/ApplySecurityToDatabases.sql
           - Prevent adding any GOs for easy copy into script above
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 8 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------------------------
DECLARE @RoleNameBookmarksOnly SYSNAME;
DECLARE @RoleNameExecutor SYSNAME;
DECLARE @RoleNameDefinitionViewer SYSNAME;
--
DECLARE @RoleName SYSNAME;
DECLARE @RoleMemberName SYSNAME;
--
DECLARE @SqlStatement NVARCHAR(1000);
DECLARE @UserSchemaName NVARCHAR(255);

SET @RoleNameBookmarksOnly = N'KiSS_BookmarksOnly';
SET @RoleNameExecutor = N'KiSS_db_executor';
SET @RoleNameDefinitionViewer = N'KiSS_db_definition_viewer';

-------------------------------------------------------------------------------------------------
-- validate bookmarks role, set owner to dbo if current user is assigned
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleNameBookmarksOnly
              AND type = 'R'
              AND owning_principal_id = USER_ID('kiss3')))
BEGIN
  -- change owner of role to dbo
  SET @SqlStatement = 'ALTER AUTHORIZATION ON ROLE::[' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '] TO [dbo];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Changed owner of role "' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '" to "dbo"');
END;

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_executor
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameExecutor;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT EXECUTE TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_definition_viewer
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameDefinitionViewer;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT VIEW DEFINITION TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- setup rights
-------------------------------------------------------------------------------------------------
---------------------------------------
-- remove user from role <db_owner>
---------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_role_members       RM
              INNER JOIN sys.database_principals U  ON U.principal_id = RM.member_principal_id
                                                   AND U.name = 'kiss3'
              INNER JOIN sys.database_principals R  ON R.principal_id = RM.role_principal_id
                                                   AND R.name = 'db_owner'))
BEGIN
  -- drop it
  EXEC sp_droprolemember 'db_owner', 'kiss3';

  -- info
  PRINT ('Info: Removed user "kiss3" from db_owner rights members');
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss3" is not member of role "db_owner"');
END;

---------------------------------------
-- drop and recreate user for login
---------------------------------------
-- check if need to drop first
IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals 
           WHERE name = N'kiss3'
             AND type = N'S'))
BEGIN
  -- check if user owns a schema
  SELECT @UserSchemaName = SCH.name
  FROM sys.database_principals DBP
    INNER JOIN sys.schemas     SCH ON SCH.principal_id = DBP.principal_id
  WHERE DBP.name = N'kiss3'
    AND DBP.type = N'S';
  
  IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, changing owner of schema "' + @UserSchemaName + '" to [dbo].');
      
    -- change owner of schema
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [dbo];';
    EXEC sp_executesql @SqlStatement;
  END;
  
  -- info
  PRINT ('Info: Drop assignment of user "kiss3"');

  -- drop assignment of kiss3 user
  DROP USER [kiss3];
END;

-- create KiSS user for login
CREATE USER [kiss3] FOR LOGIN [kiss3] WITH DEFAULT_SCHEMA = [dbo];

-- info
PRINT ('Info: Created user "kiss3" for login on database');

IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, rechanging owner of schema "' + @UserSchemaName + '" with owner [dbo] back to "kiss3".');
     
    -- rechange owner of schema to SqlUserName
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [kiss3];';
    EXEC sp_executesql @SqlStatement;
  END;


---------------------------------------
-- add KiSS user to specific members
---------------------------------------
-- public roles
EXEC sp_addrolemember 'db_datareader', 'kiss3';
EXEC sp_addrolemember 'db_datawriter', 'kiss3';

-- KiSS roles
EXEC sp_addrolemember @RoleNameExecutor, 'kiss3';
EXEC sp_addrolemember @RoleNameDefinitionViewer, 'kiss3';

-- add required/restrict rights (e.g. for INDENTITY_INSERTs)
GRANT ALTER ANY SCHEMA TO [kiss3];
DENY CREATE SCHEMA TO [kiss3];

USE [master];
GO
BEGIN TRY
  GRANT EXECUTE ON sys.xp_msver TO [kiss3];
END TRY
BEGIN CATCH
  PRINT ('Warning: Could not grant rights on sys.xp_msver to kiss3!')
END CATCH;
GO
USE [KiSS4_I];
GO

-- info
PRINT ('Info: Added user "kiss3" as member to specific roles');
PRINT ('');
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply the bookmark user to database
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

----------------------------------------------------------------------------
-- remove kiss_bm if existing
----------------------------------------------------------------------------
USE [KiSS4_I];
GO

IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals 
           WHERE name = N'kiss_bm'))
BEGIN
  -- info
  PRINT ('Info: Drop user "kiss_bm" on database');
  
  -- drop
  DROP USER [kiss_bm];
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss_bm" not found on database');
END;
GO

----------------------------------------------------------------------------
-- create login on server if not existing yet
----------------------------------------------------------------------------
USE [master];
GO

IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.server_principals
               WHERE name = 'kiss_bm'))
BEGIN
  -- info
  PRINT ('Info: Create login "kiss_bm" on server');
  
  -- create login
  CREATE LOGIN [kiss_bm] WITH PASSWORD=N'textmarken88$', DEFAULT_DATABASE=[KiSS4_I], CHECK_EXPIRATION=OFF;
END
ELSE
BEGIN
  -- info
  PRINT ('Info: Login "kiss_bm" already exists on server');
END;
GO

----------------------------------------------------------------------------
-- create user on database if not existing yet
----------------------------------------------------------------------------
USE [KiSS4_I];
GO

IF (NOT EXISTS(SELECT TOP 1 1
               FROM sysusers
               WHERE name = 'kiss_bm'))
BEGIN
  -- info
  PRINT ('Info: Create user "kiss_bm" on database');
  
  -- create user
  CREATE USER [kiss_bm] FOR LOGIN [kiss_bm];
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss_bm" already exists on database');
END;
GO

----------------------------------------------------------------------------
-- create role on database if not existing yet
----------------------------------------------------------------------------
USE [KiSS4_I];
GO

IF (NOT EXISTS(SELECT TOP 1 1
               FROM sysusers
               WHERE name = 'KiSS_BookmarksOnly'))
BEGIN
  -- info
  PRINT ('Info: Create role "KiSS_BookmarksOnly" on database');
  
  -- create role
  CREATE ROLE [KiSS_BookmarksOnly];
END
ELSE
BEGIN
  -- info
  PRINT ('Info: Role "KiSS_BookmarksOnly" already exists on database');
END;
GO

-- assign role to user
EXEC sp_addrolemember N'KiSS_BookmarksOnly', N'kiss_bm'
GO
GRANT EXECUTE ON [dbo].[spXGetBookmark] TO [KiSS_BookmarksOnly]
GO

----------------------------------------------------------------------------
-- DENY ON SEVERAL SERVER OBJECTS
----------------------------------------------------------------------------
USE [master]
GO

DENY ADMINISTER BULK OPERATIONS TO [kiss_bm]
GO
DENY ALTER ANY CONNECTION TO [kiss_bm]
GO
DENY ALTER ANY CREDENTIAL TO [kiss_bm]
GO
DENY ALTER ANY DATABASE TO [kiss_bm]
GO
DENY ALTER ANY ENDPOINT TO [kiss_bm]
GO
DENY ALTER ANY EVENT NOTIFICATION TO [kiss_bm]
GO
DENY ALTER ANY LINKED SERVER TO [kiss_bm]
GO
DENY ALTER ANY LOGIN TO [kiss_bm]
GO
DENY ALTER RESOURCES TO [kiss_bm]
GO
DENY ALTER SERVER STATE TO [kiss_bm]
GO
DENY ALTER SETTINGS TO [kiss_bm]
GO
DENY ALTER TRACE TO [kiss_bm]
GO
DENY AUTHENTICATE SERVER TO [kiss_bm]
GO
DENY CREATE ANY DATABASE TO [kiss_bm]
GO
DENY CREATE DDL EVENT NOTIFICATION TO [kiss_bm]
GO
DENY CREATE ENDPOINT TO [kiss_bm]
GO
DENY CREATE TRACE EVENT NOTIFICATION TO [kiss_bm]
GO
DENY EXTERNAL ACCESS ASSEMBLY TO [kiss_bm]
GO
DENY SHUTDOWN TO [kiss_bm]
GO
DENY UNSAFE ASSEMBLY TO [kiss_bm]
GO
DENY VIEW ANY DATABASE TO [kiss_bm]
GO
GRANT VIEW ANY DEFINITION TO [kiss_bm]
GO
DENY VIEW SERVER STATE TO [kiss_bm]
GO

----------------------------------------------------------------------------
-- after all, switch back to original database
----------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select optional document database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_DOC_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_DOC_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
-- use document database (name must be given all the time, if no document database exists, use default database)
USE [KiSS4_DOC_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply only required rights to KiSS database user 
           (kiss3, kiss, kiss4_pi, ...)
           
  HINTS:   - To fix on changes, too: /Database/Scripts/Automation/ApplySecurityToDatabases.sql
           - Prevent adding any GOs for easy copy into script above
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 8 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------------------------
DECLARE @RoleNameBookmarksOnly SYSNAME;
DECLARE @RoleNameExecutor SYSNAME;
DECLARE @RoleNameDefinitionViewer SYSNAME;
--
DECLARE @RoleName SYSNAME;
DECLARE @RoleMemberName SYSNAME;
--
DECLARE @SqlStatement NVARCHAR(1000);
DECLARE @UserSchemaName NVARCHAR(255);

SET @RoleNameBookmarksOnly = N'KiSS_BookmarksOnly';
SET @RoleNameExecutor = N'KiSS_db_executor';
SET @RoleNameDefinitionViewer = N'KiSS_db_definition_viewer';

-------------------------------------------------------------------------------------------------
-- validate bookmarks role, set owner to dbo if current user is assigned
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleNameBookmarksOnly
              AND type = 'R'
              AND owning_principal_id = USER_ID('kiss3')))
BEGIN
  -- change owner of role to dbo
  SET @SqlStatement = 'ALTER AUTHORIZATION ON ROLE::[' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '] TO [dbo];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Changed owner of role "' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '" to "dbo"');
END;

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_executor
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameExecutor;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT EXECUTE TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_definition_viewer
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameDefinitionViewer;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT VIEW DEFINITION TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- setup rights
-------------------------------------------------------------------------------------------------
---------------------------------------
-- remove user from role <db_owner>
---------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_role_members       RM
              INNER JOIN sys.database_principals U  ON U.principal_id = RM.member_principal_id
                                                   AND U.name = 'kiss3'
              INNER JOIN sys.database_principals R  ON R.principal_id = RM.role_principal_id
                                                   AND R.name = 'db_owner'))
BEGIN
  -- drop it
  EXEC sp_droprolemember 'db_owner', 'kiss3';

  -- info
  PRINT ('Info: Removed user "kiss3" from db_owner rights members');
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss3" is not member of role "db_owner"');
END;

---------------------------------------
-- drop and recreate user for login
---------------------------------------
-- check if need to drop first
IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals 
           WHERE name = N'kiss3'
             AND type = N'S'))
BEGIN
  -- check if user owns a schema
  SELECT @UserSchemaName = SCH.name
  FROM sys.database_principals DBP
    INNER JOIN sys.schemas     SCH ON SCH.principal_id = DBP.principal_id
  WHERE DBP.name = N'kiss3'
    AND DBP.type = N'S';
  
  IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, changing owner of schema "' + @UserSchemaName + '" to [dbo].');
      
    -- change owner of schema
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [dbo];';
    EXEC sp_executesql @SqlStatement;
  END;
  
  -- info
  PRINT ('Info: Drop assignment of user "kiss3"');

  -- drop assignment of kiss3 user
  DROP USER [kiss3];
END;

-- create KiSS user for login
CREATE USER [kiss3] FOR LOGIN [kiss3] WITH DEFAULT_SCHEMA = [dbo];

-- info
PRINT ('Info: Created user "kiss3" for login on database');

IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, rechanging owner of schema "' + @UserSchemaName + '" with owner [dbo] back to "kiss3".');
     
    -- rechange owner of schema to SqlUserName
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [kiss3];';
    EXEC sp_executesql @SqlStatement;
  END;


---------------------------------------
-- add KiSS user to specific members
---------------------------------------
-- public roles
EXEC sp_addrolemember 'db_datareader', 'kiss3';
EXEC sp_addrolemember 'db_datawriter', 'kiss3';

-- KiSS roles
EXEC sp_addrolemember @RoleNameExecutor, 'kiss3';
EXEC sp_addrolemember @RoleNameDefinitionViewer, 'kiss3';

-- add required/restrict rights (e.g. for INDENTITY_INSERTs)
GRANT ALTER ANY SCHEMA TO [kiss3];
DENY CREATE SCHEMA TO [kiss3];

USE [master];
GO
BEGIN TRY
  GRANT EXECUTE ON sys.xp_msver TO [kiss3];
END TRY
BEGIN CATCH
  PRINT ('Warning: Could not grant rights on sys.xp_msver to kiss3!')
END CATCH;
GO
USE [KiSS4_I];
GO

-- info
PRINT ('Info: Added user "kiss3" as member to specific roles');
PRINT ('');
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDropObject.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDropObject.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
-------------------------------------------------------------------------------------------------
-- special drop this stored procedure
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.objects 
            WHERE object_id = OBJECT_ID(N'[dbo].[spDropObject]') 
              AND type in (N'P', N'PC')))
BEGIN
  DROP PROCEDURE [dbo].[spDropObject];
  PRINT ('Info: Dropped stored procedure [dbo].[spDropObject]')
END;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spDropObject
(
  @MainObjectName VARCHAR(776),
  @ObjectName VARCHAR(776) = NULL
)
AS 
BEGIN
  SET NOCOUNT ON;
  
  DECLARE @SQL VARCHAR(512);
  DECLARE @xtype VARCHAR(2);
  
  IF (CHARINDEX('.#', @MainObjectName) > 0 OR CHARINDEX('#', @MainObjectName) = 1)
  BEGIN
    SELECT @xtype = CASE
                      WHEN @ObjectName IS NULL THEN OBJ.xtype
                      WHEN SUB.xtype IS NOT NULL THEN SUB.xtype
                      WHEN IDX.id IS NOT NULL THEN 'IX'
                    END
    FROM tempdb..sysobjects        OBJ
      LEFT JOIN tempdb..sysobjects SUB ON SUB.parent_obj = OBJ.id 
                                      AND SUB.id = OBJECT_ID(@ObjectName)
      LEFT JOIN tempdb..sysindexes IDX ON IDX.id = OBJ.id 
                                      AND IDX.name = @ObjectName
    WHERE OBJ.id = OBJECT_ID(@MainObjectName);
    
    SET @MainObjectName = SUBSTRING(@MainObjectName, CHARINDEX('#', @MainObjectName), 1000);
  END 
  ELSE 
  BEGIN
    SELECT @xtype = CASE
                      WHEN @ObjectName IS NULL THEN OBJ.xtype
                      WHEN SUB.xtype IS NOT NULL THEN SUB.xtype
                      WHEN IDX.id IS NOT NULL THEN 'IX'
                    END
    FROM sysobjects        OBJ
      LEFT JOIN sysobjects SUB ON SUB.parent_obj = OBJ.id 
                              AND SUB.id = OBJECT_ID(@ObjectName)
      LEFT JOIN sysindexes IDX ON IDX.id = OBJ.id 
                              AND IDX.name = @ObjectName
    WHERE OBJ.id = OBJECT_ID(@MainObjectName);
    
    IF (@xtype IN ('U'))
    BEGIN
      SET @SQL = 'EXECUTE spDropTableRef ''' + @MainObjectName + '''';
      EXECUTE (@SQL);
    END;
  END;
  
  SET @SQL = CASE @xtype
               WHEN 'U'  THEN 'DROP TABLE ['     + @MainObjectName + ']'  -- User table
               WHEN 'TR' THEN 'DROP TRIGGER ['   + @MainObjectName + ']'  -- Trigger
               
               WHEN 'V'  THEN 'DROP VIEW ['      + @MainObjectName + ']'  -- View
               
               WHEN 'P'  THEN 'DROP PROCEDURE [' + @MainObjectName + ']'  -- Stored procedure
               
               WHEN 'FN' THEN 'DROP FUNCTION ['  + @MainObjectName + ']'  -- Scalar function
               WHEN 'TF' THEN 'DROP FUNCTION ['  + @MainObjectName + ']'  -- Table function
               WHEN 'IF' THEN 'DROP FUNCTION ['  + @MainObjectName + ']'  -- Inlined table-function
               
               WHEN 'PK' THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- PrimaryKey
               WHEN 'D'  THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- Default or DEFAULT constraint
               WHEN 'UQ' THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'
               WHEN 'C'  THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- CHECK constraint
               
               WHEN 'F'  THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- FOREIGN KEY constraint
               
               WHEN 'IX' THEN 'DROP INDEX '     + @MainObjectName + '.' + @ObjectName
               
               WHEN 'K'  THEN NULL  -- PRIMARY KEY or UNIQUE constraint
               
               WHEN 'L'  THEN NULL  -- Log
               WHEN 'R'  THEN NULL  -- Rule
               WHEN 'RF' THEN NULL  -- replication filter stored procedure
               
               WHEN 'S'  THEN NULL  -- System table
               WHEN 'X'  THEN NULL  -- Extended stored procedure
               
               ELSE NULL
             END;
  
  IF (NOT @SQL IS NULL)
  BEGIN
    PRINT '  - ' + @SQL;
    EXECUTE (@SQL);
  END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDropObject.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDropObject.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Job_PendenzenDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Job_PendenzenDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\Various\Jobs\Job_PendenzenAnlegen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\Various\Jobs\Job_PendenzenAnlegen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
USE [msdb]
GO
/****** Object:  Job [KiSS4_I_Pendenzen]    Script Date: 02/11/2009 09:33:40 ******/
DECLARE @job_id varchar(100)

SELECT @job_id = job_id FROM msdb.dbo.sysjobs_view WHERE name = N'KiSS4_I_Pendenzen'

IF  @job_id IS NOT NULL
  EXEC msdb.dbo.sp_delete_job @job_id, @delete_unused_schedule=1
GO
 
/****** Object:  Job [KiSS4_I_Pendenzen]    Script Date: 02/11/2009 09:31:53 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]]    Script Date: 02/11/2009 09:31:53 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16),
        @enableJob BIT;
SET @enableJob = case when N';BSS;SepDocDB;~ZH;$Standard;' LIKE '%;RESTORE;%' THEN 0 ELSE 1 END;
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'KiSS4_I_Pendenzen', 
		@enabled= @enableJob, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'Durchsucht KiSS nach neu zu erstellenden Pendenzen. Verwendet die Stored Procedure dbo.spXTask_Create.', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'kiss3', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Pendenzen anlegen]    Script Date: 02/11/2009 09:31:54 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Pendenzen anlegen', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'dbo.spXTask_Create', 
		@database_name=N'KiSS4_I', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Pendenz anlegen', 
		@enabled=@enableJob, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20090211, 
		@active_end_date=99991231, 
		@active_start_time=41315, 
		@active_end_time=235959
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave

QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION

EndSave:
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\Various\Jobs\Job_PendenzenAnlegen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\Various\Jobs\Job_PendenzenAnlegen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Job_PendenzenDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Job_PendenzenDispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\1. Dispatcher\Standard\R4939_Dispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\1. Dispatcher\Standard\R4939_Dispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to cleanup old migration tables.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- e.g. EXECUTE dbo.spDropObject _Old_FaPhase;
-------------------------------------------------------------------------------
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaAdressate;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Auswahl Adressate in CtlFaDokumente
           Typ ist in LOV BaAdressatTyp übersetzt
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwBaAdressate;
=================================================================================================*/

CREATE VIEW dbo.vwBaAdressate
AS
-------------------------------------------------------------------------------
-- Personen
-------------------------------------------------------------------------------
SELECT ID      = PRS.BaPersonID,
       TypCode = 1,
       Typ     = 'Person',
       Name    = PRS.Name + ISNULL(' ' + PRS.Vorname, ''),
       Strasse = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Ort     = ADR.PLZ + ISNULL(' ' + ADR.Ort, '')
FROM dbo.BaPerson         PRS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL) -- wohnsitz

UNION ALL

-------------------------------------------------------------------------------
-- Institutionen
-------------------------------------------------------------------------------
SELECT ID      = INS.BaInstitutionID,
       TypCode = 2,
       Typ     = 'Institution',
       Name    = INS.[Name] + ISNULL(' ' + INS.Vorname, ''),
       Strasse = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Ort     = ADR.PLZ + ISNULL(' ' + ADR.Ort, '')
FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
WHERE INS.Aktiv = 1

--UNION ALL

---------------------------------------------------------------------------------
---- Private Mandatsträger
---------------------------------------------------------------------------------
--SELECT ID      =  VPM.VmPriMaID,
--       TypCode = 3,
--       Typ     = 'PriMa',
--       Name    = VPM.Name + IsNull(', ' + VPM.Vorname, ''),
--       Strasse = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
--       Ort     = IsNull(ADR.PLZ + ' ', '') + ADR.Ort
--    FROM VmPriMa           VPM
--      LEFT JOIN BaAdresse  ADR ON ADR.VmPriMaID = VPM.VmPriMaID
--    WHERE 
--    VPM.isActive = 1
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XMenuItem.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XMenuItem.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to update XMenuItem entries
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1: disable FrmPriMa
-------------------------------------------------------------------------------
UPDATE MNU 
  SET [Enabled] = 0, Visible = 0
FROM dbo.XMenuItem MNU
WHERE ClassName = 'FrmPriMa';
GO

-------------------------------------------------------------------------------
-- step 3: add NamespaceExtension for BSS-specific version of CtlQueryStatFallentwicklungKes
-------------------------------------------------------------------------------
UPDATE dbo.XClass SET NamespaceExtension = 'BSS' WHERE ClassName = 'CtlQueryStatFallentwicklungKes';
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XMenuItem.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XMenuItem.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_BaInstitution.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_BaInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to migrate VmPriMa to BaInstitution
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.tables WITH (READUNCOMMITTED)
           WHERE [name] = '_Mig_VmPriMa_To_BaInstitution'))
BEGIN
  PRINT ('Warning: Tabelle _Mig_VmPriMa_To_BaInstitution ist bereits vorhanden');
END
ELSE 
BEGIN
  CREATE TABLE _Mig_VmPriMa_To_BaInstitution(
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    BaInstitutionID INT,
    VmPriMaID INT,
    Created DATETIME NOT NULL
  );

  ALTER TABLE [dbo].[_Mig_VmPriMa_To_BaInstitution] ADD  CONSTRAINT [DF__Mig_VmPriMa_To_BaInstitution_Created]  DEFAULT (GETDATE()) FOR [Created]
END;

DECLARE @BaInstitutionTypID INT;
-------------------------------------------------------------------------------
-- Typ 'Privatperson' in 'Privatperson (PriMa)' umbennen
-------------------------------------------------------------------------------
DECLARE @NameNeu VARCHAR(50);
SET @NameNeu = 'Privatperson (PriMa)';

UPDATE BaInstitutionTyp 
  SET Name = @NameNeu
WHERE Name LIKE '%Privatperson%';

SET @BaInstitutionTypID = (SELECT BaInstitutionTypID 
                           FROM BaInstitutionTyp
                           WHERE Name = @NameNeu);


DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @VmPriMaID INT;

INSERT INTO _Mig_VmPriMa_To_BaInstitution (VmPriMaID)
  SELECT PRM.VmPriMaID 
  FROM dbo.VmPriMa PRM;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @VmPriMaID = TMP.VmPriMaID
  FROM _Mig_VmPriMa_To_BaInstitution TMP
  WHERE TMP.ID = @EntriesIterator;

  PRINT (CONVERT(VARCHAR(MAX), @EntriesIterator) + ': VmPriMaID = ' + CONVERT(VARCHAR(MAX), @VmPriMaID));

  -- Datensätze von VmPriMa in BaInstitution schreiben 
  INSERT INTO dbo.BaInstitution (OrgUnitID, InstitutionNr, BaInstitutionArtCode, Aktiv, Debitor, Kreditor, KeinSerienbrief, ManuelleAnrede, Anrede, Briefanrede, Titel, Name, Vorname, GeschlechtCode, Geburtsdatum, Versichertennummer, Telefon, Telefon2, Telefon3, Fax, EMail, Homepage, SprachCode, Bemerkung, InstitutionName, InstitutionTypCode, BaFreigabeStatusCode, DefinitivUserID, DefinitivDatum, ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum, Creator, Created, Modifier, Modified)
    SELECT 
      NULL, -- OrgUnitID - int
      NULL, -- InstitutionNr - varchar(20)
      2, -- BaInstitutionArtCode - int
      PRM.IsActive, -- Aktiv - bit
      0, -- Debitor - bit
      0, -- Kreditor - bit
      0, -- KeinSerienbrief - bit
      1, -- ManuelleAnrede - bit
      dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 1, PRM.SprachCode, 'famherrfrau', '', NULL, NULL, NULL) + ', ' + 
      dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 2, PRM.SprachCode, 'famherrfrau', '', NULL, NULL, NULL), -- Anrede - varchar(100)
      dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 1, PRM.SprachCode, 'geehrte', '', NULL, NULL, NULL) + ', ' + 
      dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 2, PRM.SprachCode, 'geehrte', '', NULL, NULL, NULL), -- Briefanrede - varchar(100)
      PRM.Titel, -- Titel - varchar(100)
      PRM.Name, -- Name - varchar(500)
      PRM.Vorname, -- Vorname - varchar(100)
      NULL, -- GeschlechtCode - int
      PRM.Geburtsdatum, -- Geburtsdatum - datetime
      PRM.Versichertennummer, -- Versichertennummer - varchar(18)
      PRM.Telefon_P, -- Telefon - varchar(100)
      PRM.Telefon_G, -- Telefon2 - varchar(100)
      PRM.MobilTel, -- Telefon3 - varchar(100)
      PRM.Fax, -- Fax - varchar(100)
      PRM.EMail, -- EMail - varchar(100)
      NULL, -- Homepage - varchar(100)
      PRM.SprachCode, -- SprachCode - int
      ISNULL('Bank/PC: ' + PRM.BankName + CHAR(13) + CHAR(10), '') + ISNULL('Konto-Nr: ' + PRM.BankKontoNr + CHAR(13) + CHAR(10), '') + ISNULL(PRM.Bemerkung, ''), -- Bemerkung - varchar(max)
      NULL, -- InstitutionName - varchar(100)
      NULL, -- InstitutionTypCode - int
      NULL, -- BaFreigabeStatusCode - int
      NULL, -- DefinitivUserID - int
      GETDATE(), -- DefinitivDatum - datetime
      dbo.fnXGetSystemUserID(), -- ErstelltUserID - int
      GETDATE(), -- ErstelltDatum - datetime
      dbo.fnXGetSystemUserID(), -- MutiertUserID - int
      GETDATE(), -- MutiertDatum - datetime
      dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Creator - varchar(50)
      GETDATE(), -- Created - datetime
      dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Modifier - varchar(50)
      GETDATE() -- Modified - datetime
    FROM dbo.VmPriMa PRM
      LEFT JOIN _Mig_VmPriMa_To_BaInstitution VPR ON VPR.VmPriMaID = PRM.VmPriMaID
      LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.VmPriMaID = PRM.VmPriMaID
    WHERE PRM.VmPriMaID = @VmPriMaID;
   
  UPDATE _Mig_VmPriMa_To_BaInstitution
    SET BaInstitutionID = SCOPE_IDENTITY()
  WHERE VmPriMaID = @VmPriMaID;
    
  PRINT ('    BaInstitutionID = ' + CONVERT(VARCHAR(MAX), SCOPE_IDENTITY()));

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

PRINT ('Info: ' + CONVERT(VARCHAR(MAX), @EntriesIterator) + ' VmPriMas wurden in BaInstitution migriert');


-------------------------------------------------------------------------------
-- Datensätze von BaAdresse von VmPriMaID nach BaInstitutionID umschreiben
-- und einen Historyeintrag machen
-------------------------------------------------------------------------------
INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
         
UPDATE ADR
  SET ADR.BaInstitutionID = VPR.BaInstitutionID,
      ADR.VmPriMaID = NULL
FROM dbo.BaAdresse ADR
  INNER JOIN _Mig_VmPriMa_To_BaInstitution VPR ON VPR.VmPriMaID = ADR.VmPriMaID;

PRINT ('Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Adressen wurden umgehängt');

-------------------------------------------------------------------------------
-- Erstellte BaInstitutionen typisieren
-------------------------------------------------------------------------------
INSERT INTO BaInstitution_BaInstitutionTyp (BaInstitutionID, BaInstitutionTypID, Creator, Created, Modifier, Modified)
  SELECT 
      VPR.BaInstitutionID,
      @BaInstitutionTypID,
      dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Creator - varchar(50)
      GETDATE(), -- Created - datetime
      dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Modifier - varchar(50)
      GETDATE() -- Modified - datetime
  FROM _Mig_VmPriMa_To_BaInstitution VPR

PRINT ('Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' BaInstitution_BaInstitutionTyp wurden erstellt');


GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_BaInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_BaInstitution.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Alter_KesMassnahme.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Alter_KesMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to alter Kes-tables
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1: KesMassnahme
-------------------------------------------------------------------------------

--IsDeleted
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMassnahme_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMassnahme.IsDeleted wurde hinzugefügt');
END;

--FuersorgerischeUnterbringung
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'FuersorgerischeUnterbringung'))
BEGIN
  PRINT ('Info: Die Spalte FuersorgerischeUnterbringung ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD FuersorgerischeUnterbringung bit NOT NULL CONSTRAINT DF_KesMassnahme_FuersorgerischeUnterbringung DEFAULT 0
  PRINT ('Info: Spalte KesMassnahme.FuersorgerischeUnterbringung wurde hinzugefügt');
END;

--Platzierung_BaInstitutionID
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'Platzierung_BaInstitutionID'))
BEGIN
  PRINT ('Info: Die Spalte Platzierung_BaInstitutionID ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD Platzierung_BaInstitutionID int NULL;

  CREATE NONCLUSTERED INDEX [IX_KesMassnahme_Platzierung_BaInstitutionID] ON [dbo].[KesMassnahme] 
  (
    [Platzierung_BaInstitutionID] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];

  ALTER TABLE [dbo].[KesMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_Platzierung_BaInstitutionID] FOREIGN KEY([Platzierung_BaInstitutionID])
  REFERENCES [dbo].[BaInstitution] ([BaInstitutionID]);

  ALTER TABLE [dbo].[KesMassnahme] CHECK CONSTRAINT [FK_KesMassnahme_Platzierung_BaInstitutionID]

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Platzierung in einer Institution (Fremdschlüssel FK_KesMassnahme_Platzierung_BaInstitutionID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Platzierung_BaInstitutionID';

  PRINT ('Info: Spalte KesMassnahme.Platzierung_BaInstitutionID wurde hinzugefügt');
END;

--KesGrundlageCode
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'KesGrundlageCode'))
BEGIN
  PRINT ('Info: Die Spalte KesGrundlageCode ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD KesGrundlageCode int NULL;

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grundlage (LOV KesGrundlage)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesGrundlageCode'

  PRINT ('Info: Spalte KesMassnahme.KesGrundlageCode wurde hinzugefügt');
END;

GO

-------------------------------------------------------------------------------
-- step 2: KesMandatsfuehrendePerson
-------------------------------------------------------------------------------
-- IsDeleted
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMandatsfuehrendePerson')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMandatsfuehrendePerson bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMandatsfuehrendePerson ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMandatsfuehrendePerson_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMandatsfuehrendePerson.IsDeleted wurde hinzugefügt');
END;

-- DatumErnennungsurkunde
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMandatsfuehrendePerson')
             AND C.name = 'DatumErnennungsurkunde'))
BEGIN
  PRINT ('Info: Die Spalte DatumErnennungsurkunde ist auf KesMandatsfuehrendePerson bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMandatsfuehrendePerson ADD DatumErnennungsurkunde DATETIME NULL;
  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Ernennungsurkunde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumErnennungsurkunde'

  PRINT ('Info: Spalte KesMandatsfuehrendePerson.DatumErnennungsurkunde wurde hinzugefügt');
END;


GO

-------------------------------------------------------------------------------
-- step 3: KesMassnahmeAuftrag
-------------------------------------------------------------------------------
-- IsDeleted
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeAuftrag')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMassnahmeAuftrag bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeAuftrag ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMassnahmeAuftrag_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMassnahmeAuftrag.IsDeleted wurde hinzugefügt');
END;

-- DatumVersand
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeAuftrag')
             AND C.name = 'DatumVersand'))
BEGIN
  PRINT ('Info: Die Spalte DatumVersand ist auf KesMassnahmeAuftrag bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeAuftrag ADD DatumVersand DATETIME NULL;
  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Versand' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DatumVersand'

  PRINT ('Info: Spalte KesMassnahmeAuftrag.DatumVersand wurde hinzugefügt');
END;

GO

-------------------------------------------------------------------------------
-- step 4: KesMassnahmeBericht
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeBericht')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMassnahmeBericht bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeBericht ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMassnahmeBericht_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMassnahmeBericht.IsDeleted wurde hinzugefügt');
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeBericht')
             AND C.name = 'DatumVersand'))
BEGIN
  PRINT ('Info: Die Spalte DatumVersand ist auf KesMassnahmeBericht bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeBericht ADD DatumVersand DATETIME NULL;

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Versands' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumVersand'

  PRINT ('Info: Spalte KesMassnahmeBericht.DatumVersand wurde hinzugefügt');
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeBericht')
             AND C.name = 'DatumBelegeZurueck'))
BEGIN
  PRINT ('Info: Die Spalte DatumBelegeZurueck ist auf KesMassnahmeBericht bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeBericht ADD DatumBelegeZurueck DATETIME NULL;

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Belege zurück am' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumBelegeZurueck'

  PRINT ('Info: Spalte KesMassnahmeBericht.DatumBelegeZurueck wurde hinzugefügt');
END;

GO


-------------------------------------------------------------------------------
-- step 5: KesDokument
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesDokument')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesDokument bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesDokument ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesDokument_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesDokument.IsDeleted wurde hinzugefügt');
END;

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Alter_KesMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Alter_KesMassnahme.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_KesMassnahme.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_KesMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to migrate KesMassnahmeBSS to KesMassnahme and other tables
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO



-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @MigrationDate DATETIME = GETDATE();
PRINT ('Info: @MigrationDate = ' + CONVERT(VARCHAR(10), @MigrationDate, 121));

DECLARE @Creator VARCHAR(50);
SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @FaLeistungID INT;
DECLARE @MassnahmeVon DATETIME;
DECLARE @MassnahmeBis DATETIME;
DECLARE @IsDeleted BIT;
DECLARE @KesMassnahmeTypCode INT;
DECLARE @KesMassnahmeBSSIDs VARCHAR(MAX);
DECLARE @KesAufgabenbereichCodes VARCHAR(MAX);
DECLARE @KesIndikationCodes VARCHAR(MAX);

DECLARE @Mig_KesMassnahmeBSS_Merge TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  Mig_KesMassnahmeBSS_MergeID INT NOT NULL,
  FaLeistungID INT NOT NULL,
  MassnahmeVon DATETIME NOT NULL,
  MassnahmeBis DATETIME NOT NULL,
  IsDeleted BIT NOT NULL,
  KesMassnahmeTypCode INT NOT NULL,
  KesArtikelIDs VARCHAR(MAX) NULL,
  KesMassnahmeBSSIDs VARCHAR(MAX) NOT NULL,
  KesAufgabenbereichCodes VARCHAR(MAX) NULL,
  KesIndikationCodes VARCHAR(MAX) NULL
);



-- Tabelle _Mig_KesMassnahmeBSS erstellen
IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.tables
               WHERE name = '_Mig_KesMassnahmeBSS'))
BEGIN
  CREATE TABLE dbo._Mig_KesMassnahmeBSS 
  (
    ID INT IDENTITY(1, 1) NOT NULL,
    KesMassnahmeBSSID INT NOT NULL,
    KesMassnahmeID INT NULL,
    KesDokumentID INT NULL,
    Step INT NULL,
    Bemerkung VARCHAR(200) NOT NULL,
    MigrationDate DATETIME NOT NULL 
  );
  ALTER TABLE dbo._Mig_KesMassnahmeBSS ADD CONSTRAINT DF__Mig_KesMassnahmeBSS_MigrationDate DEFAULT GETDATE() FOR MigrationDate;
  PRINT ('Info: Tabelle _Mig_KesMassnahmeBSS wurde erstellt');
END
ELSE
BEGIN
  PRINT ('Warning: Tabelle _Mig_KesMassnahmeBSS existiert bereits');
END;


-- Tabelle _Mig_KesMassnahmeBSS_Group erstellen
IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.tables
               WHERE name = '_Mig_KesMassnahmeBSS_Group'))
BEGIN
  CREATE TABLE dbo._Mig_KesMassnahmeBSS_Group 
  (
    ID INT IDENTITY(1, 1) NOT NULL,
    FaLeistungID INT NOT NULL,
    MassnahmeVon DATETIME NOT NULL,
    MassnahmeBis DATETIME NOT NULL,
    IsDeleted BIT NOT NULL,
    KesMassnahmeTypCode INT NOT NULL,
    KesArtikelIDs VARCHAR(MAX) NULL,
    KesMassnahmeBSSIDs VARCHAR(MAX) NOT NULL,
    KesAufgabenbereichCodes VARCHAR(MAX) NULL,
    KesIndikationCodes VARCHAR(MAX) NULL,
    AnzahlGroup INT NULL,
    MigrationDate DATETIME NOT NULL 
  );
  ALTER TABLE dbo._Mig_KesMassnahmeBSS_Group ADD CONSTRAINT DF__Mig_KesMassnahmeBSS_Group_MigrationDate DEFAULT GETDATE() FOR MigrationDate;
  PRINT ('Info: Tabelle _Mig_KesMassnahmeBSS_Group wurde erstellt');
END
ELSE
BEGIN
  PRINT ('Warning: Tabelle _Mig_KesMassnahmeBSS_Group existiert bereits');
END;



-- Tabelle _Mig_KesMassnahmeBSS_Merge erstellen
IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.tables
               WHERE name = '_Mig_KesMassnahmeBSS_Merge'))
BEGIN
  CREATE TABLE dbo._Mig_KesMassnahmeBSS_Merge
  (
    ID INT IDENTITY(1, 1) NOT NULL,
    FaLeistungID INT NOT NULL,
    MassnahmeVon DATETIME NOT NULL,
    MassnahmeBis DATETIME NOT NULL,
    IsDeleted BIT NOT NULL,
    KesMassnahmeTypCode INT NOT NULL,
    KesArtikelIDs VARCHAR(MAX) NULL,
    KesMassnahmeBSSIDs VARCHAR(MAX) NOT NULL,
    KesAufgabenbereichCodes VARCHAR(MAX) NULL,
    KesIndikationCodes VARCHAR(MAX) NULL,
    AnzahlMerge INT NULL,
    MigrationDate DATETIME NOT NULL 
  );
  ALTER TABLE dbo._Mig_KesMassnahmeBSS_Merge ADD CONSTRAINT DF__Mig_KesMassnahmeBSS_Merge_MigrationDate DEFAULT GETDATE() FOR MigrationDate;
  PRINT ('Info: Tabelle _Mig_KesMassnahmeBSS_Merge wurde erstellt');
END
ELSE
BEGIN
  PRINT ('Warning: Tabelle _Mig_KesMassnahmeBSS_Merge existiert bereits');
END;



-------------------------------------------------------------------------------
-- step 1: Migration von "Nicht massnahmegebundene Unterbringung"
-------------------------------------------------------------------------------
PRINT ('Info: 1. Migration von "Nicht massnahmegebundene Unterbringung"');

MERGE dbo.KesDokument DST
USING
(
  SELECT 
    -- für die Logs
    MAS.KesMassnahmeBSSID,
    Step                     = 1,
    Bemerkung                = 'Nicht massnahmegebundene Unterbringung',

    -- für die Migration
    KesAuftragID             = NULL, 
    FaLeistungID             = MAS.FaLeistungID, 
    UserID                   = MAS.UserID, 
    BaPersonID_Adressat      = NULL, 
    BaInstitutionID_Adressat = NULL, 
    Stichwort                = ART.Artikel + IsNull('.' + ART.Absatz, '') + IsNull('.' + ART.Ziffer, '') + ' ' + ART.Gesetz + ' ' + ART.Bezeichnung + ' / ' + ISNULL(MAS.Bemerkung, ''), 
    KesDokumentResultatCode  = NULL, 
    KesDokumentArtCode       = NULL, 
    XDocumentID_Dokument     = MAS.KESBDocumentID, 
    XDocumentID_Versand      = NULL, 
    KesDokumentTypCode       = 2, -- Massnahmenführung Dokument
    Creator                  = MAS.Creator, 
    Created                  = MAS.Created, 
    Modifier                 = MAS.Modifier, 
    Modified                 = MAS.Modified,
    IsDeleted                = MAS.IsDeleted
  FROM dbo.KesMassnahmeBSS MAS WITH (READUNCOMMITTED)
    INNER JOIN dbo.KesArtikel ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = ISNULL(MAS.KesArtikelID_MassnahmegebundeneGeschaefte, MAS.KesArtikelID_NichtMassnahmegebundeneGeschaefte)
  WHERE ART.Artikel IN ('426', '427', '429', '431', '437')
) SRC ON 1=0 -- 1=0 (false) damit immer ein Insert gemacht wird
WHEN NOT MATCHED THEN 
  INSERT (KesAuftragID, FaLeistungID, UserID, BaPersonID_Adressat, BaInstitutionID_Adressat, Stichwort, KesDokumentResultatCode, KesDokumentArtCode, XDocumentID_Dokument, XDocumentID_Versand, KesDokumentTypCode, Creator, Created, Modifier, Modified, IsDeleted)
    VALUES (SRC.KesAuftragID, SRC.FaLeistungID, SRC.UserID, SRC.BaPersonID_Adressat, SRC.BaInstitutionID_Adressat, SRC.Stichwort, SRC.KesDokumentResultatCode, SRC.KesDokumentArtCode, SRC.XDocumentID_Dokument, SRC.XDocumentID_Versand, SRC.KesDokumentTypCode, SRC.Creator, SRC.Created, SRC.Modifier, SRC.Modified, SRC.IsDeleted)
OUTPUT SRC.KesMassnahmeBSSID,
       INSERTED.KesDokumentID,
       SRC.Step,
       SRC.Bemerkung
  INTO dbo._Mig_KesMassnahmeBSS (KesMassnahmeBSSID, KesDokumentID, Step, Bemerkung)
;

PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' KesMassnahmeBSS wurden in KesDokument migriert.');
PRINT ('');

-------------------------------------------------------------------------------
-- step 2: Migration von Massnahmen
-------------------------------------------------------------------------------
PRINT ('Info: 2. Migration von Massnahmen');

IF (EXISTS(SELECT TOP 1 1
           FROM dbo.KesMassnahme WITH (READUNCOMMITTED)
           WHERE 1=1))
BEGIN
  PRINT ('Warning: es sind bereits Daten in KesMassnahme vorhanden');
END;

-- Start "Päckli" machen
;WITH MassnahmeCTE AS 
(
  SELECT MassnahmeVon = ISNULL(NULLIF(COALESCE(MAS.AenderungVom, MAS.UebernahmeVom, MAS.ErrichtungVom, '17530102'), '17530101'), '17530102'), -- Das kleinste DatumVon darf nicht kleiner als 17530102 sein weil wir weiter unten ein DATEADD -1 machen
         MassnahmeBis = ISNULL(NULLIF(COALESCE(MAS.Beistandswechsel, MAS.UebertragungVom, MAS.AufhebungVom, MAS.BerichtsgenehmigungVom, '99991230'), '99991231'), '99991230'), -- Das grösste DatumBis darf nicht grösser als 99991231 sein weil wir weiter unten ein DATEADD +1 machen
         KesArtikelID = ISNULL(MAS.KesArtikelID_MassnahmegebundeneGeschaefte, MAS.KesArtikelID_NichtMassnahmegebundeneGeschaefte),
         MAS.*
  FROM dbo.KesMassnahmeBSS MAS WITH (READUNCOMMITTED)
    LEFT JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = MAS.KesMassnahmeBSSID AND MIG.MigrationDate >= @MigrationDate
  WHERE MIG.KesMassnahmeBSSID IS NULL -- Massnahmen die bereits migriert sind ignorieren
)

,MassnahmeGroupCTE AS
(
  SELECT 
    CTE.FaLeistungID, 
    CTE.MassnahmeVon, 
    CTE.MassnahmeBis, 
    CTE.IsDeleted,
    CTE.KesMassnahmeTypCode,
    KesArtikelIDs = dbo.ConcDistinctOrder(CTE.KesArtikelID), 
    KesMassnahmeBSSIDs = dbo.ConcDistinctOrder(CTE.KesMassnahmeBSSID), 
    KesAufgabenbereichCodes = dbo.ConcDistinctOrder(CTE.KesAufgabenbereichCodes),
    KesIndikationCodes = dbo.ConcDistinctOrder(CTE.KesIndikationCodes),
    AnzahlGroup = COUNT(1)
  FROM MassnahmeCTE CTE
  GROUP BY CTE.FaLeistungID, CTE.MassnahmeVon, CTE.MassnahmeBis, CTE.IsDeleted, CTE.KesMassnahmeTypCode
  --HAVING COUNT(1) > 1
  --ORDER BY CTE.FaLeistungID, CTE.MassnahmeVon, CTE.MassnahmeBis
) 

INSERT INTO dbo._Mig_KesMassnahmeBSS_Group (FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes, AnzahlGroup)
  SELECT FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes, AnzahlGroup
  FROM MassnahmeGroupCTE CTE 
  ORDER BY CTE.FaLeistungID, CTE.IsDeleted, CTE.KesMassnahmeTypCode, CTE.KesArtikelIDs, CTE.MassnahmeVon, CTE.MassnahmeBis

---- debug
--SELECT *
--FROM _Mig_KesMassnahmeBSS_Group
--WHERE MigrationDate >= @MigrationDate;
---- end debug


-- Start Massnahmen anhand Perioden zusammenführen
;WITH MassnahmeMergeCTE AS
(
  SELECT 
    CTE1.FaLeistungID, 
    CTE1.MassnahmeVon, 
    CTE1.MassnahmeBis,
    CTE1.IsDeleted,
    CTE1.KesMassnahmeTypCode,
    CTE1.KesArtikelIDs,
    CTE1.KesMassnahmeBSSIDs,
    CTE1.KesAufgabenbereichCodes,
    CTE1.KesIndikationCodes,
    CTE1.AnzahlGroup,
    ID = ROW_NUMBER() OVER(ORDER BY CTE1.FaLeistungID, CTE1.MassnahmeVon)
  FROM dbo._Mig_KesMassnahmeBSS_Group         CTE1
    LEFT  JOIN dbo._Mig_KesMassnahmeBSS_Group CTE2 ON CTE2.FaLeistungID = CTE1.FaLeistungID 
                                                  AND CTE2.KesArtikelIDs = CTE1.KesArtikelIDs 
                                                  AND CTE2.IsDeleted = CTE1.IsDeleted 
                                                  AND CTE2.KesMassnahmeTypCode = CTE1.KesMassnahmeTypCode
                                                  AND (DATEADD(DAY, 1, CTE2.MassnahmeBis) = CTE1.MassnahmeVon 
                                                    OR (CTE2.MassnahmeBis = CTE1.MassnahmeVon AND CTE2.MassnahmeVon <> CTE2.MassnahmeBis))
  WHERE CTE2.FaLeistungID IS NULL
  
  UNION ALL
  SELECT 
    CTE1.FaLeistungID, 
    CTE1.MassnahmeVon, 
    CTE2.MassnahmeBis,
    CTE1.IsDeleted,
    CTE1.KesMassnahmeTypCode,
    CTE1.KesArtikelIDs,
    KesMassnahmeBSSIDs      = CTE1.KesMassnahmeBSSIDs + ',' + CTE2.KesMassnahmeBSSIDs,
    KesAufgabenbereichCodes = CTE1.KesAufgabenbereichCodes + ',' + CTE2.KesAufgabenbereichCodes,
    KesIndikationCodes      = CTE1.KesIndikationCodes + ',' + CTE2.KesIndikationCodes,
    CTE1.AnzahlGroup,
    CTE1.ID
  FROM MassnahmeMergeCTE        CTE1
    INNER JOIN dbo._Mig_KesMassnahmeBSS_Group CTE2 ON CTE2.FaLeistungID = CTE1.FaLeistungID 
                                                  AND CTE2.KesArtikelIDs = CTE1.KesArtikelIDs 
                                                  AND CTE2.IsDeleted = CTE1.IsDeleted 
                                                  AND CTE2.KesMassnahmeTypCode = CTE1.KesMassnahmeTypCode
                                                  AND (DATEADD(DAY, -1, CTE2.MassnahmeVon) = CTE1.MassnahmeBis 
                                                    OR (CTE2.MassnahmeVon = CTE1.MassnahmeBis AND CTE2.MassnahmeVon <> CTE2.MassnahmeBis))
)

INSERT INTO dbo._Mig_KesMassnahmeBSS_Merge (FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes, AnzahlMerge)
  SELECT 
    FaLeistungID            = CTE.FaLeistungID, 
    MassnahmeVon            = CTE.MassnahmeVon, 
    MassnahmeBis            = MAX(CTE.MassnahmeBis),
    IsDeleted               = CTE.IsDeleted, 
    KesMassnahmeTypCode     = CTE.KesMassnahmeTypCode,
    KesArtikelIDs           = CTE.KesArtikelIDs, 
    KesMassnahmeBSSIDs      = dbo.Conc(CTE.KesMassnahmeBSSIDs), 
    KesAufgabenbereichCodes = dbo.Conc(CTE.KesAufgabenbereichCodes),
    KesIndikationCodes      = dbo.Conc(CTE.KesIndikationCodes),
    AnzahlMerge             = COUNT(1)
  FROM MassnahmeMergeCTE CTE
  GROUP BY CTE.FaLeistungID, CTE.KesArtikelIDs, CTE.MassnahmeVon, CTE.ID, CTE.IsDeleted, CTE.KesMassnahmeTypCode
  ORDER BY CTE.FaLeistungID, CTE.MassnahmeVon, MAX(CTE.MassnahmeBis), CTE.IsDeleted, CTE.KesMassnahmeTypCode

---- debug
--SELECT *
--FROM dbo._Mig_KesMassnahmeBSS_Merge
--WHERE MigrationDate >= @MigrationDate
---- end debug

-- remove dupplicate IDs and Codes
UPDATE MIG
  SET KesMassnahmeBSSIDs      = STUFF((SELECT DISTINCT ',' + SplitValue
                                       FROM dbo.fnSplitStringToValues(KesMassnahmeBSSIDs, ',', 1)
                                       FOR XML PATH('')),
                                       1,
                                       1, 
                                       ''),
      KesAufgabenbereichCodes = STUFF((SELECT DISTINCT ',' + SplitValue
                                       FROM dbo.fnSplitStringToValues(KesAufgabenbereichCodes, ',', 1)
                                       FOR XML PATH('')),
                                       1,
                                       1, 
                                       ''),
      KesIndikationCodes      = STUFF((SELECT DISTINCT ',' + SplitValue
                                       FROM dbo.fnSplitStringToValues(KesIndikationCodes, ',', 1)
                                       FOR XML PATH('')),
                                       1,
                                       1, 
                                       '')
FROM dbo._Mig_KesMassnahmeBSS_Merge MIG
WHERE MigrationDate >= @MigrationDate



---- debug
--SELECT *
--FROM dbo._Mig_KesMassnahmeBSS_Merge
--WHERE MigrationDate >= @MigrationDate
---- end debug

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @Mig_KesMassnahmeBSS_Merge (Mig_KesMassnahmeBSS_MergeID, FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes)
  SELECT Mig_KesMassnahmeBSS_MergeID = ID,
         FaLeistungID,
         MassnahmeVon,
         MassnahmeBis,
         IsDeleted,
         KesMassnahmeTypCode,
         KesArtikelIDs,
         KesMassnahmeBSSIDs,
         KesAufgabenbereichCodes,
         KesIndikationCodes
  FROM dbo._Mig_KesMassnahmeBSS_Merge
  WHERE MigrationDate >= @MigrationDate;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @FaLeistungID                = TMP.FaLeistungID,
         @MassnahmeVon                = TMP.MassnahmeVon,
         @MassnahmeBis                = TMP.MassnahmeBis,
         @IsDeleted                   = TMP.IsDeleted,
         @KesMassnahmeTypCode         = TMP.KesMassnahmeTypCode,
         @KesMassnahmeBSSIDs          = TMP.KesMassnahmeBSSIDs,
         @KesAufgabenbereichCodes     = TMP.KesAufgabenbereichCodes,
         @KesIndikationCodes          = TMP.KesIndikationCodes
  FROM @Mig_KesMassnahmeBSS_Merge TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  PRINT (CONVERT(VARCHAR(MAX), @EntriesIterator) + ' : @KesMassnahmeBSSIDs = ' + @KesMassnahmeBSSIDs);

  DECLARE @KesMassnahmeID INT;

  -----------------------------------------------------------------------------
  -- Step 2.1 Massnahme
  -----------------------------------------------------------------------------
  --SET IDENTITY_INSERT dbo.KesMassnahme ON
  INSERT  INTO dbo.KesMassnahme (/*KesMassnahmeID, */FaLeistungID, IsKS, DocumentID_Errichtungsbeschluss, DocumentID_Aufhebungsbeschluss, DatumVon, DatumBis, KesAufgabenbereichCodes, KesIndikationCodes, Auftragstext, KesElterlicheSorgeObhutCode_ElterlicheSorge, KesElterlicheSorgeObhutCode_Obhut, FuersorgerischeUnterbringung, Platzierung_BaInstitutionID, KesGrundlageCode, UebernahmeVon_Datum, UebernahmeVon_OrtschaftCode, UebernahmeVon_PLZ, UebernahmeVon_Ort, UebernahmeVon_Kanton, UebernahmeVon_KesBehoerdeID, AenderungVom_Datum, KesAenderungsgrundCode, UebertragungAn_Datum, UebertragungAn_OrtschaftCode, UebertragungAn_PLZ, UebertragungAn_Ort, UebertragungAn_Kanton, UebertragungAn_KesBehoerdeID, KesAufhebungsgrundCode, Bemerkung, Zustaendig_KesBehoerdeID, Creator, Created, Modifier, Modified, IsDeleted)
    SELECT  
      --KesMassnahmeID                              = MIN(ALT.KesMassnahmeBSSID),
      FaLeistungID                                = @FaLeistungID, 
      IsKS                                        = CASE WHEN @KesMassnahmeTypCode = 2 THEN 1 ELSE 0 END, -- 1	Erwachsenenschutz, 2	Kindesschutz
      DocumentID_Errichtungsbeschluss             = NULL, -- ALT.KESBDocumentID wird später aus dem ältesten Paket mit Änderungsgrund "Massnahmeart" oder [NULL]
      DocumentID_Aufhebungsbeschluss              = NULL, 
      DatumVon                                    = @MassnahmeVon, 
      DatumBis                                    = NULLIF(@MassnahmeBis, '99991230'), 
      KesAufgabenbereichCodes                     = @KesAufgabenbereichCodes, 
      KesIndikationCodes                          = @KesIndikationCodes, 
      Auftragstext                                = NULL, 
      KesElterlicheSorgeObhutCode_ElterlicheSorge = MIN(ALT.KesElterlicheSorgeObhutCode_ElterlicheSorge),
      KesElterlicheSorgeObhutCode_Obhut           = MIN(ALT.KesElterlicheSorgeObhutCode_Obhut),
      FuersorgerischeUnterbringung                = CONVERT(BIT, MIN(CONVERT(INT, ALT.FuersorgerischeUnterbringung))),
      Platzierung_BaInstitutionID                 = MIN(ALT.Platzierung_BaInstitutionID),
      KesGrundlageCode                            = MIN(ALT.KesGrundlageCode),
      UebernahmeVon_Datum                         = MIN(ALT.UebernahmeVom),
      UebernahmeVon_OrtschaftCode                 = NULL, 
      UebernahmeVon_PLZ                           = NULL, 
      UebernahmeVon_Ort                           = NULL, 
      UebernahmeVon_Kanton                        = NULL, 
      UebernahmeVon_KesBehoerdeID                 = NULL, 
      AenderungVom_Datum                          = MIN(ALT.AenderungVom), 
      KesAenderungsgrundCode                      = MIN(ALT.KesAenderungsgrundCode), 
      UebertragungAn_Datum                        = MIN(ALT.UebertragungVom), 
      UebertragungAn_OrtschaftCode                = MIN(ALT.OrtschaftCode), 
      UebertragungAn_PLZ                          = MIN(ALT.PLZ), 
      UebertragungAn_Ort                          = MIN(ALT.Ort), 
      UebertragungAn_Kanton                       = MIN(ALT.Kanton), 
      UebertragungAn_KesBehoerdeID                = NULL, 
      KesAufhebungsgrundCode                      = MIN(ALT.KesAufhebungsgrundCode), 
      Bemerkung                                   = dbo.ConcDistinct(ALT.Bemerkung), 
      Zustaendig_KesBehoerdeID                    = NULL, 
      Creator                                     = MIN(ALT.Creator), -- nicht ganz korrekt, aber immerhin besser als 'kiss_sys'
      Created                                     = MIN(ALT.Created), 
      Modifier                                    = MAX(ALT.Modifier),  -- nicht ganz korrekt, aber immerhin besser als 'kiss_sys'
      Modified                                    = MAX(ALT.Modified),
      IsDeleted                                   = @IsDeleted
    FROM dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED)
    WHERE ALT.KesMassnahmeBSSID IN (SELECT TOP 1 CONVERT(INT, SplitValue)
                                    FROM dbo.fnSplitStringToValues(@KesMassnahmeBSSIDs, ',', 1)
                                    WHERE 1=1)
    GROUP BY ALT.FaLeistungID;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Massnahme migriert');
  --SET IDENTITY_INSERT dbo.KesMassnahme OFF

  SELECT @KesMassnahmeID = SCOPE_IDENTITY();

  -- log
  INSERT INTO dbo._Mig_KesMassnahmeBSS (KesMassnahmeBSSID, KesMassnahmeID, Step, Bemerkung)
    SELECT KesMassnahmeBSSID = CONVERT(INT, SplitValue), 
           KesMassnahmeID    = @KesMassnahmeID,
           Step              = 2,
           Bemerkung         = 'Migration von Massnahmen'
    FROM dbo.fnSplitStringToValues(@KesMassnahmeBSSIDs, ',', 1)

  -- Das Dokument 'Verfügung/Auftrag KESB' mit 'Änderungsgrund' "Massnahme" oder [null] des ältesten Pakets gilt als der 'Errichtungsbeschluss'
  UPDATE MAS
    SET DocumentID_Errichtungsbeschluss = (SELECT TOP 1 ALT.KESBDocumentID
                                           FROM dbo._Mig_KesMassnahmeBSS    MIG WITH (READUNCOMMITTED) 
                                             INNER JOIN dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED) ON ALT.KesMassnahmeBSSID = MIG.KesMassnahmeBSSID
                                           WHERE MIG.KesMassnahmeID = MAS.KesMassnahmeID
                                             AND ISNULL(ALT.KesAenderungsgrundCode, 1) = 1 -- Massnahmenart oder leer
                                             AND ALT.KESBDocumentID IS NOT NULL
                                           ORDER BY COALESCE(ALT.AenderungVom, ALT.UebernahmeVom, ALT.ErrichtungVom, '17530102'), ALT.KesMassnahmeBSSID
                                          )
  FROM dbo.KesMassnahme MAS 
  WHERE MAS.KesMassnahmeID = @KesMassnahmeID;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' DocumentID_Errichtungsbeschluss hinzugefügt');

  -------------------------------------------------------------------------------
  -- step 2.2: Mandatsführende Person
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMandatsfuehrendePerson ( KesMassnahmeID ,
                                              DatumMandatVon ,
                                              DatumMandatBis ,
                                              DocumentID_Ernennungsurkunde ,
                                              UserID ,
                                              BaInstitutionID ,
                                              KesBeistandsartCode ,
                                              DatumVorgeschlagenAm ,
                                              DatumRechnungsfuehrungVon ,
                                              DatumRechnungsfuehrungBis ,
                                              Creator ,
                                              Created ,
                                              Modifier ,
                                              Modified ,
                                              IsDeleted
                                            )
    SELECT 
      KesMassnahmeID               = MIG.KesMassnahmeID,
      DatumMandatVon               = MIN(ALT.ErrichtungVom),
      DatumMandatBis               = NULL,
      DocumentID_Ernennungsurkunde = MIN(ALT.DocumentID_Urkunde),
      UserID                       = ALT.UserID,
      BaInstitutionID              = CASE WHEN ALT.BaInstitutionID IS NOT NULL THEN ALT.BaInstitutionID
                                          ELSE (SELECT TOP 1 BaInstitutionID
                                                FROM dbo._Mig_VmPriMa_To_BaInstitution WITH (READUNCOMMITTED)
                                                WHERE VmPriMaID = ALT.VmPriMaID)
                                     END,
      KesBeistandsartCode          = ALT.KesBeistandsartCode,
      DatumVorgeschlagenAm         = NULL,
      DatumRechnungsfuehrungVon    = NULL,
      DatumRechnungsfuehrungBis    = NULL,
      Creator                      = MIN(ALT.Creator),
      Created                      = MIN(ALT.Created),
      Modifier                     = MIN(ALT.Modifier),
      Modified                     = MIN(ALT.Modified),
      IsDeleted                    = ALT.IsDeleted
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE COALESCE(ALT.UserID, ALT.VmPriMaID, ALT.BaInstitutionID) IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
    GROUP BY MIG.KesMassnahmeID, ALT.UserID, ALT.BaInstitutionID, ALT.VmPriMaID, ALT.KesBeistandsartCode, ALT.IsDeleted;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Mandatsführende Person migriert');



  -------------------------------------------------------------------------------
  -- step 2.3: Artikel
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMassnahme_KesArtikel (KesMassnahmeID, KesArtikelID, Creator, Created, Modifier, Modified)
    SELECT 
      KesMassnahmeID = MIG.KesMassnahmeID,
      KesArtikelID   = ALT.KesArtikelID_MassnahmegebundeneGeschaefte,
      Creator        = MIN(ALT.Creator),
      Created        = MIN(ALT.Created),
      Modifier       = MAX(ALT.Modifier),
      Modified       = MAX(ALT.Modified)
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.KesArtikelID_MassnahmegebundeneGeschaefte IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
    GROUP BY MIG.KesMassnahmeID, ALT.KesArtikelID_MassnahmegebundeneGeschaefte;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Artikel (Massnahmegebundene Geschaefte) migriert');


  INSERT INTO dbo.KesMassnahme_KesArtikel (KesMassnahmeID, KesArtikelID, Creator, Created, Modifier, Modified)
    SELECT 
      KesMassnahmeID = MIG.KesMassnahmeID,
      KesArtikelID   = ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte,
      Creator        = MIN(ALT.Creator),
      Created        = MIN(ALT.Created),
      Modifier       = MAX(ALT.Modifier),
      Modified       = MAX(ALT.Modified)
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte IS NOT NULL
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.KesMassnahme_KesArtikel WITH (READUNCOMMITTED)
                      WHERE KesMassnahmeID = ALT.KesMassnahmeBSSID
                        AND KesArtikelID = ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte) --Sicherstellen, dass keine doppelten Daten existieren, falls KesArtikelID_MassnahmegebundeneGeschaefte = KesArtikelID_NichtMassnahmegebundeneGeschaefte
      AND MIG.KesMassnahmeID = @KesMassnahmeID
    GROUP BY MIG.KesMassnahmeID, ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Artikel (nicht Massnahmegebundene Geschaefte) migriert');


  -------------------------------------------------------------------------------
  -- step 2.4: Bericht: Periode aus VmBericht und DatumVerfuegungKESB aus KesMassnahmeBSS
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMassnahmeBericht (KesMassnahmeID, KesMassnahmeBerichtsartCode, DatumVon, DatumBis, Creator, Created, Modifier, Modified, IsDeleted)
    SELECT
      KesMassnahmeID              = @KesMassnahmeID,
      KesMassnahmeBerichtsartCode = 1, --1: Ordentlicher Bericht
      DatumVon                    = ALT.BerichtsperiodeVon,
      DatumBis                    = ALT.BerichtsperiodeBis,
      Creator                     = @Creator,
      Created                     = GETDATE(),
      Modifier                    = @Creator,
      Modified                    = GETDATE(),
      IsDeleted                   = @IsDeleted
    FROM dbo.VmBericht ALT WITH (READUNCOMMITTED)
    WHERE FaLeistungID = @FaLeistungID
      AND BerichtsperiodeVon <= @MassnahmeBis
      AND BerichtsperiodeBis >= @MassnahmeVon

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte migriert');

  -- Datum "Verfügung KESB vom" an richtigem Bericht zuordnen
  ;WITH BerichtCTE AS
  (
    SELECT
      KesMassnahmeID              = MIG.KesMassnahmeID,
      DatumVerfuegungKESB         = ALT.BerichtsgenehmigungVom,
      Creator                     = ALT.Creator,
      Created                     = ALT.Created,
      Modifier                    = ALT.Modifier,
      Modified                    = ALT.Modified,
      KesMassnahmeBerichtID       = (SELECT TOP 1 BER.KesMassnahmeBerichtID
                                     FROM dbo.KesMassnahmeBericht BER WITH (READUNCOMMITTED)
                                     WHERE BER.KesMassnahmeID = @KesMassnahmeID
                                       AND BER.DatumVon <= @MassnahmeBis
                                       AND BER.DatumBis >= @MassnahmeVon
                                       AND BER.DatumBis <= ALT.BerichtsgenehmigungVom
                                     ORDER BY BER.DatumBis DESC)
    FROM dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.BerichtsgenehmigungVom IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
  )

  UPDATE BER
    SET DatumVerfuegungKESB         = CTE.DatumVerfuegungKESB,
        Creator                     = CTE.Creator,
        Created                     = CTE.Created,
        Modifier                    = CTE.Modifier,
        Modified                    = CTE.Modified
  FROM dbo.KesMassnahmeBericht BER
    INNER JOIN BerichtCTE CTE WITH (READUNCOMMITTED) ON CTE.KesMassnahmeBerichtID = BER.KesMassnahmeBerichtID
  WHERE BER.KesMassnahmeID = @KesMassnahmeID;
  
  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte (Verfügung KESB vom) migriert');

  -- Wenn Massnahme 'Änderungsgrund' "Berichtsgenehmigung", Dok 'Verfügung/Auftrag KESB' nach 'Berichts- und Rechnungsablage' der zugehörigen Massnahme und der vorhergehenden Periode
  ;WITH BerichtCTE AS
  (
    SELECT
      KesMassnahmeID            = MIG.KesMassnahmeID,
      DocumentID_VerfuegungKESB = ALT.KESBDocumentID,
      KesMassnahmeBerichtID     = (SELECT TOP 1 BER.KesMassnahmeBerichtID
                                   FROM dbo.KesMassnahmeBericht BER WITH (READUNCOMMITTED)
                                   WHERE BER.KesMassnahmeID = @KesMassnahmeID
                                     AND BER.DatumVon <= @MassnahmeBis
                                     AND BER.DatumBis >= @MassnahmeVon
                                     AND BER.DatumBis <= COALESCE(ALT.AenderungVom, ALT.UebernahmeVom, ALT.ErrichtungVom, '17530102')
                                   ORDER BY BER.DatumBis DESC)
    FROM dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.KesAenderungsgrundCode = 12 -- Berichtsgenehmigung
      AND ALT.KESBDocumentID IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
  )

  UPDATE BER
    SET BER.DocumentID_VerfuegungKESB = CTE.DocumentID_VerfuegungKESB
  FROM dbo.KesMassnahmeBericht BER
    INNER JOIN BerichtCTE CTE WITH (READUNCOMMITTED) ON CTE.KesMassnahmeBerichtID = BER.KesMassnahmeBerichtID
  WHERE BER.KesMassnahmeID = @KesMassnahmeID;
  
  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte (Dokument Bericht) migriert');



  -------------------------------------------------------------------------------
  -- step 2.4: Auftrag: Wenn 'Änderungsgrund' alle anderen, dann Dokument in 'Aufträge/Anträge' zur entsprechenden Massnahme inkl. Begleittext.
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMassnahmeAuftrag (KesMassnahmeID, DocumentID_Beschluss, Auftrag, Creator, Created, Modifier, Modified, IsDeleted)
    SELECT 
      KesMassnahmeID         = MIG.KesMassnahmeID, 
      DocumentID_Beschluss   = ALT.KESBDocumentID, 
      Auftrag                = ISNULL(ART.Artikel + IsNull('.' + ART.Absatz, '') + IsNull('.' + ART.Ziffer, '') + ' ' + ART.Gesetz + ' ' + ART.Bezeichnung + ' / ', '') + 'Änderungsgrund: ' + dbo.fnLOVText('KesAenderungsgrund', ALT.KesAenderungsgrundCode), 
      Creator                = ALT.Creator,
      Created                = ALT.Created,
      Modifier               = ALT.Modifier,
      Modified               = ALT.Modified,
      IsDeleted              = ALT.IsDeleted
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
      LEFT  JOIN dbo.KesArtikel           ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = ISNULL(ALT.KesArtikelID_MassnahmegebundeneGeschaefte, ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte)
    WHERE ALT.KesAenderungsgrundCode IS NOT NULL
      AND ALT.KesAenderungsgrundCode NOT IN (1, 12) -- Massnahmeart, Berichtsgenehmigung
      AND ALT.KESBDocumentID IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
  

  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;




-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_KesMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Insert_KesMassnahme.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XModulTree.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XModulTree.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to add Kes-Massnahmeführung to Modul V
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

DECLARE @NewModulID INT,
        @NewModulID_Parent INT,
        @NewSortkey INT;
SELECT  @NewModulID = 5,
        @NewModulID_Parent = 50000,
        @NewSortkey = 2;

-------------------------------------------------------------------------------
-- Step 1: Make sure, there is a gap in the list of child-masks (increment SortKey on every mask after the position where the new mask is placed)
-------------------------------------------------------------------------------
UPDATE XModulTree SET SortKey = SortKey + 1 WHERE ModulID = @NewModulID AND ModulTreeID_Parent = @NewModulID_Parent and SortKey >= @NewSortkey;

-------------------------------------------------------------------------------
-- Step 2: Insert mask in XModulTree
-------------------------------------------------------------------------------
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, ModulTreeCode, sqlInsertTreeItem, Active)
VALUES (52900,				--ModulTreeID
        @NewModulID_Parent, --ModulTreeID_Parent
        @NewModulID,		--ModulID
        @NewSortkey,		--SortKey
        0,					--XIconID
        'Massnahmenführung', --Name
        'Kiss.UserInterface.View.Kes.KesMassnahmeView,Kiss.UserInterface.View', --ClassName
        1,	   --ModulTreeCode
        'UPDATE #Tree    SET Zusatz = NULL,        
                         IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                                            FROM dbo.KesMassnahme KMA WITH (READUNCOMMITTED)                                             
                                                              INNER JOIN #Tree    TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = KMA.FaLeistungID
                                                            WHERE KMA.IsDeleted = 0
                                                            UNION ALL                                                                                      
                                                            SELECT TOP 1 1                                           
                                                            FROM dbo.KesDokument KDO WITH (READUNCOMMITTED)                                             
                                                              INNER JOIN  #Tree  TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = KDO.FaLeistungID
                                                            WHERE KDO.IsDeleted = 0)
                                                    THEN 5062                              
                                               ELSE 5063                         
                                          END)  
        WHERE ModulTreeID = @ModulTreeID',    --sqlInsertTreeItem
        1);    --Active



GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XModulTree.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XModulTree.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XLOVCode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XLOVCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to update Kes-related XLOVCodes
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- Step 1: Update existing XLOVCodes
-------------------------------------------------------------------------------
UPDATE XLOVCode SET Text = 'Anderes', TextTID = NULL WHERE LOVName = 'KesAufhebungsgrundES' AND Code = 5;
UPDATE XLOVCode SET Text = 'Anderes', TextTID = NULL WHERE LOVName = 'KesAufhebungsgrundKS' AND Code = 6;
UPDATE XLOVCode SET Text = 'Andere', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 10;
UPDATE XLOVCode SET Text = 'Betroffene Person selber', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 1;
UPDATE XLOVCode SET Text = 'Keine (KESB von Amtes wegen)', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 11;
UPDATE XLOVCode SET Text = 'Weitere Amtsstellen (z.B. Betreibungsamt, Steueramt, Ausgleichskasse)', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 8;
UPDATE XLOVCode SET Text = 'Andere', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 10;
UPDATE XLOVCode SET Text = 'Betroffenes Kind selber', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 1;
UPDATE XLOVCode SET Text = 'Keine (KESB von Amtes wegen)', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 11;
UPDATE XLOVCode SET Text = 'Weitere Amtsstellen', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 8;
UPDATE XLOVCode SET Text = 'Ordentlicher Bericht', TextTID = NULL WHERE LOVName = 'KesMassnahmeBerichtsart' AND Code = 1;

-------------------------------------------------------------------------------
-- Step 2: Insert missing XLOVCodes
-------------------------------------------------------------------------------
INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       11,   --Code
       'Korrespondenz', --Text
       10, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       '1,2', --Value3
       NULL, --Description
       NULL, --LOVCodeName
       1,    --IsActive
       0     --System
FROM XLOV
WHERE LOVName = 'KesDienstleistung'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleistung' AND Code = 11)

--XLOV Eintrag KesDienstleitungenStatFallentw machen
IF(NOT EXISTS (SELECT TOP 1 1 FROM XLOV WHERE LOVName = 'KesDienstleitungenStatFallentw'))
BEGIN
  INSERT INTO [XLOV] ([LOVName], [Description], [System], [Expandable], [ModulID], [LastUpdated], [Translatable], [NameValue1], [NameValue2], [NameValue3])
  VALUES ( N'KesDienstleitungenStatFallentw' ,  
           N'Maske CtlQueryStatFallentwicklungKes - Liste der Prozess' ,
           1 ,
           0 ,
           29,
           null ,
           1 ,
           null ,
           null ,
           null )
END;

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       1,   --Code
       'Präventionen', --Text
       1, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Präventionen', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 1)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       2,   --Code
       'Abklärungen/Auftrag', --Text
       2, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Abklärungen/Auftrag', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 2)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       3,   --Code
       'Massnahmeführung', --Text
       3, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Massnahmeführung', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 3)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       4,   --Code
       'Pflegekinderaufsicht', --Text
       4, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Pflegekinderaufsicht', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 4)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       10,   --Code
       'Einstellung Verfahren', --Text
       10, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       NULL, --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesMassnahmeGeschaeftsart'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesMassnahmeGeschaeftsart' AND Code = 10)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       11,   --Code
       'Inventar bei Todesfall', --Text
       11, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       NULL, --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesMassnahmeGeschaeftsart'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesMassnahmeGeschaeftsart' AND Code = 11)

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XLOVCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XLOVCode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteMassnahme.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmLetzteMassnahme;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken um die Daten der Massnahme und die Mandatsführende Person der letzten Massnahme einer Person zu bekommen

  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmLetzteMassnahme;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmLetzteMassnahme
AS
  SELECT 
    PRS.BaPersonID,

    -- Massnahme
    BeschlussVom   = CONVERT(VARCHAR(10), MAS.DatumVon, 104),
    Aufhebung      = CONVERT(VARCHAR(10), MAS.DatumBis, 104),
    ZGBArtikel     = STUFF((SELECT ', ' + ART.Artikel + IsNull('.' + ART.Absatz, '') + IsNull('.' + ART.Ziffer, '') + ' ' + ART.Gesetz
                            FROM dbo.KesMassnahme_KesArtikel KMA WITH (READUNCOMMITTED)
                              INNER JOIN dbo.KesArtikel      ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = KMA.KesArtikelID
                            WHERE KMA.KesMassnahmeID = MAS.KesMassnahmeID
                            ORDER BY ART.Artikel, ART.Absatz, ART.Ziffer, ART.Gesetz
                            FOR XML PATH('')),
                            1,
                            2, 
                            ''),
    ZGBBez         = STUFF((SELECT ', ' + ART.Bezeichnung
                            FROM dbo.KesMassnahme_KesArtikel KMA WITH (READUNCOMMITTED)
                              INNER JOIN dbo.KesArtikel      ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = KMA.KesArtikelID
                            WHERE KMA.KesMassnahmeID = MAS.KesMassnahmeID
                            ORDER BY ART.Artikel, ART.Absatz, ART.Ziffer, ART.Gesetz
                            FOR XML PATH('')),
                            1,
                            2, 
                            ''),


    -- Mandatsführende Person
    MTAnrede       = CASE WHEN USR.UserID IS NOT NULL
                       THEN CASE USR.GenderCode
                              WHEN 1 THEN 'Herr'
                              WHEN 2 THEN 'Frau'
                              ELSE ''
                            END
                       ELSE dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, INS.GeschlechtCode, 1, 'herrfrau', '')
                     END,
    MTGeehrte      = CASE WHEN USR.UserID IS NOT NULL
                       THEN CASE USR.GenderCode
                              WHEN 1 THEN 'geehrter Herr'
                              WHEN 2 THEN 'geehrte Frau'
                              ELSE ''
                            END
                       ELSE dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, INS.GeschlechtCode, 1, 'geehrte', '')
                     END,
    MTName         = CASE WHEN USR.UserID IS NOT NULL
                       THEN ISNULL(USR.FirstName + ' ','') + USR.LastName
                       ELSE ISNULL(INS.Vorname + ' ','') + INS.[Name]
                     END,
    MTNachname     = ISNULL(USR.LastName, INS.[Name]),
    MTVorname      = ISNULL(USR.FirstName, INS.Vorname),
    MTPLZOrt       = ISNULL(ADR.PLZ + ' ','') + ADR.Ort,
    MTStrasseNr    = ADR.Strasse + ISNULL(' ' + ADR.HausNr,''),
    MTTelefonG     = ISNULL(USR.Phone, INS.Telefon2),
    MTTelefonMobil = ISNULL(USR.PhoneMobile, INS.Telefon3),
    MTTelefonP     = ISNULL(USR.PhonePrivat, INS.Telefon),
    MTEmail        = ISNULL(USR.EMail, INS.EMail),
    MTErnennung    = CONVERT(VARCHAR(10), MFP.DatumErnennungsurkunde, 104)
  FROM dbo.BaPerson                          PRS WITH (READUNCOMMITTED)
    INNER JOIN dbo.KesMassnahme              MAS WITH (READUNCOMMITTED) ON MAS.KesMassnahmeID = (SELECT TOP 1 MAS2.KesMassnahmeID
                                                                                                 FROM dbo.KesMassnahme MAS2 WITH (READUNCOMMITTED)
                                                                                                   INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = MAS2.FaLeistungID
                                                                                                 WHERE LEI.BaPersonID = PRS.BaPersonID
                                                                                                 ORDER BY MAS2.DatumVon DESC)
    LEFT  JOIN dbo.KesMandatsfuehrendePerson MFP WITH (READUNCOMMITTED) ON MFP.KesMassnahmeID = MAS.KesMassnahmeID
                                                                       AND MFP.KesMandatsfuehrendePersonID = (SELECT TOP 1 MFP2.KesMandatsfuehrendePersonID
                                                                                                              FROM dbo.KesMandatsfuehrendePerson MFP2 WITH (READUNCOMMITTED)
                                                                                                              WHERE MFP2.KesMassnahmeID = MFP.KesMassnahmeID
                                                                                                              ORDER BY MFP2.DatumErnennungsurkunde DESC)
    LEFT  JOIN dbo.XUser                     USR WITH (READUNCOMMITTED) ON USR.UserID = MFP.UserID
    LEFT  JOIN dbo.BaInstitution             INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = MFP.BaInstitutionID
    LEFT  JOIN dbo.BaAdresse                 ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID OR ADR.UserID = USR.UserID
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteMassnahme.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMassnahme.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmMassnahme;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken um die Daten einer Massnahme und die letzte Mandatsführende Person zu bekommen

  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmMassnahme;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmMassnahme
AS
  SELECT 
    MAS.KesMassnahmeID,

    -- Massnahme
    BeschlussVom   = CONVERT(VARCHAR(10), MAS.DatumVon, 104),
    Aufhebung      = CONVERT(VARCHAR(10), MAS.DatumBis, 104),
    ZGBArtikel     = STUFF((SELECT ', ' + ART.Artikel + IsNull('.' + ART.Absatz, '') + IsNull('.' + ART.Ziffer, '') + ' ' + ART.Gesetz
                            FROM dbo.KesMassnahme_KesArtikel KMA WITH (READUNCOMMITTED)
                              INNER JOIN dbo.KesArtikel      ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = KMA.KesArtikelID
                            WHERE KMA.KesMassnahmeID = MAS.KesMassnahmeID
                            ORDER BY ART.Artikel, ART.Absatz, ART.Ziffer, ART.Gesetz
                            FOR XML PATH('')),
                            1,
                            2, 
                            ''),
    ZGBBez         = STUFF((SELECT ', ' + ART.Bezeichnung
                            FROM dbo.KesMassnahme_KesArtikel KMA WITH (READUNCOMMITTED)
                              INNER JOIN dbo.KesArtikel      ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = KMA.KesArtikelID
                            WHERE KMA.KesMassnahmeID = MAS.KesMassnahmeID
                            ORDER BY ART.Artikel, ART.Absatz, ART.Ziffer, ART.Gesetz
                            FOR XML PATH('')),
                            1,
                            2, 
                            ''),


    -- Mandatsführende Person
    MTAnrede       = CASE WHEN USR.UserID IS NOT NULL
                       THEN CASE USR.GenderCode
                              WHEN 1 THEN 'Herr'
                              WHEN 2 THEN 'Frau'
                              ELSE ''
                            END
                       ELSE dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, INS.GeschlechtCode, 1, 'herrfrau', '')
                     END,
    MTGeehrte      = CASE WHEN USR.UserID IS NOT NULL
                       THEN CASE USR.GenderCode
                              WHEN 1 THEN 'Herr'
                              WHEN 2 THEN 'Frau'
                              ELSE ''
                            END
                       ELSE dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, INS.GeschlechtCode, 1, 'geehrte', '')
                     END,
    MTName         = CASE WHEN USR.UserID IS NOT NULL
                       THEN ISNULL(USR.FirstName + ' ','') + USR.LastName
                       ELSE ISNULL(INS.Vorname + ' ','') + INS.[Name]
                     END,
    MTNachname     = ISNULL(USR.LastName, INS.[Name]),
    MTVorname      = ISNULL(USR.FirstName, INS.Vorname),
    MTPLZOrt       = ISNULL(ADR.PLZ + ' ','') + ADR.Ort,
    MTStrasseNr    = ADR.Strasse + ISNULL(' ' + ADR.HausNr,''),
    MTTelefonG     = ISNULL(USR.Phone, INS.Telefon2),
    MTTelefonMobil = ISNULL(USR.PhoneMobile, INS.Telefon3),
    MTTelefonP     = ISNULL(USR.PhonePrivat, INS.Telefon),
    MTEmail        = ISNULL(USR.EMail, INS.EMail),
    MTErnennung    = CONVERT(VARCHAR(10), MFP.DatumErnennungsurkunde, 104)
  FROM dbo.KesMassnahme                      MAS WITH (READUNCOMMITTED) 
    LEFT  JOIN dbo.KesMandatsfuehrendePerson MFP WITH (READUNCOMMITTED) ON MFP.KesMassnahmeID = MAS.KesMassnahmeID
                                                                       AND MFP.KesMandatsfuehrendePersonID = (SELECT TOP 1 MFP2.KesMandatsfuehrendePersonID
                                                                                                              FROM dbo.KesMandatsfuehrendePerson MFP2 WITH (READUNCOMMITTED)
                                                                                                              WHERE MFP2.KesMassnahmeID = MFP.KesMassnahmeID
                                                                                                              ORDER BY MFP2.DatumErnennungsurkunde DESC)
    LEFT  JOIN dbo.XUser                     USR WITH (READUNCOMMITTED) ON USR.UserID = MFP.UserID
    LEFT  JOIN dbo.BaInstitution             INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = MFP.BaInstitutionID
    LEFT  JOIN dbo.BaAdresse                 ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID OR ADR.UserID = USR.UserID
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMassnahme.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMassnahme.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteBerPeriode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteBerPeriode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmLetzteBerPeriode;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken um die Daten der Berichtsperiode der letzten Massnahme einer Person zu bekommen

  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmLetzteBerPeriode;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmLetzteBerPeriode
AS
  SELECT 
    PRS.BaPersonID,

    -- Massnahme
    Von        = CONVERT(VARCHAR(10), BER.DatumVon, 104),
    Bis        = CONVERT(VARCHAR(10), BER.DatumBis, 104),
    Verfuegung = CONVERT(VARCHAR(10), BER.DatumVerfuegungKESB, 104),
    Versand    = CONVERT(VARCHAR(10), BER.DatumVersand, 104),
    Art        = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 1)

    
  FROM dbo.BaPerson                          PRS WITH (READUNCOMMITTED)
    INNER JOIN dbo.KesMassnahme              MAS WITH (READUNCOMMITTED) ON MAS.KesMassnahmeID = (SELECT TOP 1 MAS2.KesMassnahmeID
                                                                                                 FROM dbo.KesMassnahme MAS2 WITH (READUNCOMMITTED)
                                                                                                   INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = MAS2.FaLeistungID
                                                                                                 WHERE LEI.BaPersonID = PRS.BaPersonID
                                                                                                 ORDER BY MAS2.DatumVon DESC)
    LEFT  JOIN dbo.KesMassnahmeBericht       BER WITH (READUNCOMMITTED) ON BER.KesMassnahmeID = MAS.KesMassnahmeID
                                                                       AND BER.KesMassnahmeBerichtID = (SELECT TOP 1 BER2.KesMassnahmeBerichtID
                                                                                                        FROM dbo.KesMassnahmeBericht BER2 WITH (READUNCOMMITTED)
                                                                                                        WHERE BER2.KesMassnahmeID = BER.KesMassnahmeID
                                                                                                        ORDER BY BER2.DatumBis DESC)
GO



GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteBerPeriode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmLetzteBerPeriode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XBookmark.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XBookmark.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Script um die Textmarken anzupassen
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- Step 1: VmLetzteMassnahme...
-------------------------------------------------------------------------------
-- Old-Tabelle erstellen
SELECT TOP 1 *
INTO dbo._Old_XBookmark
FROM dbo.XBookmark WITH (READUNCOMMITTED)
WHERE 1 = 0


-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmLetzteMassnahmeMTEmail',
'VmLetzteMassnahmeMTErnennung',
'VmLetzteMassnahmeMTNachname',
'VmLetzteMassnahmeMTName',
'VmLetzteMassnahmeMTPLZOrt',
'VmLetzteMassnahmeMTStrasseNr',
'VmLetzteMassnahmeMTTelefonG',
'VmLetzteMassnahmeMTTelefonMobil',
'VmLetzteMassnahmeMTTelefonP',
'VmLetzteMassnahmeMTVorname',
'VmLetzteMassnahmeAufhebung',
'VmLetzteMassnahmeBeschlussVom',
'VmLetzteMassnahmeZGBArtikel',
'VmLetzteMassnahmeZGBBez'
)


-- neue Textmarken-View erstellen
IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XBookmark WITH (READUNCOMMITTED)
           WHERE BookmarkName = 'VmLetzteMassnahme'))
BEGIN
  PRINT ('Warning: XBookmark VmLetzteMassnahme ist bereits vorhanden');
END
ELSE
BEGIN
  INSERT INTO dbo.XBookmark (BookmarkName, Category, BookmarkCode, [SQL], [Description], TableName, ModulID, AlwaysVisible, [System]) 
    SELECT 'VmLetzteMassnahme', 'Vormundschaft', 1, 'SELECT <TableColumn> 
FROM dbo.vwTmVmLetzteMassnahme 
WHERE BaPersonID = {BaPersonID}', NULL, 'vwTmVmLetzteMassnahme', 5, 0, 1
  PRINT ('Info: XBookmark VmLetzteMassnahme wurde erstellt');
END;



GO

-------------------------------------------------------------------------------
-- Step 2: VmMassnahme...
-------------------------------------------------------------------------------
-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmMassnahmeAufhebung',
'VmMassnahmeBeschlussVom',
'VmMassnahmeZGBArtikel',
'VmMassnahmeZGBBez'
)


-- neue Textmarken-View erstellen
IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XBookmark WITH (READUNCOMMITTED)
           WHERE BookmarkName = 'VmMassnahme'))
BEGIN
  PRINT ('Warning: XBookmark VmMassnahme ist bereits vorhanden');
END
ELSE
BEGIN
  INSERT INTO dbo.XBookmark (BookmarkName, Category, BookmarkCode, [SQL], [Description], TableName, ModulID, AlwaysVisible, [System]) 
    SELECT 'VmMassnahme', 'Vormundschaft', 1, 'SELECT <TableColumn> 
FROM dbo.vwTmVmMassnahme 
WHERE KesMassnahmeID = {KesMassnahmeID}', NULL, 'vwTmVmMassnahme', 5, 0, 1
  PRINT ('Info: XBookmark VmMassnahme wurde erstellt');
END;
GO


-------------------------------------------------------------------------------
-- Step 3: VmMandatstraeger... löschen
-------------------------------------------------------------------------------
-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmMandatstraegerAnrede',
'VmMandatsträgerSehrGeehrteFrauHerr',
'VmMandatstraegerName',
'VmMandatstraegerVorname',
'VmMandatstraegerVornameName'
)

GO


-------------------------------------------------------------------------------
-- Step 4: VmLetzteBerPeriode...
-------------------------------------------------------------------------------
-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmLetzteBerPeriodeBis',
'VmLetzteBerPeriodeEntsch',
'VmLetzteBerPeriodeVon'
)


-- neue Textmarken-View erstellen
IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XBookmark WITH (READUNCOMMITTED)
           WHERE BookmarkName = 'VmLetzteBerPeriode'))
BEGIN
  PRINT ('Warning: XBookmark VmLetzteBerPeriode ist bereits vorhanden');
END
ELSE
BEGIN
  INSERT INTO dbo.XBookmark (BookmarkName, Category, BookmarkCode, [SQL], [Description], TableName, ModulID, AlwaysVisible, [System]) 
    SELECT 'VmLetzteBerPeriode', 'Vormundschaft', 1, 'SELECT <TableColumn> 
FROM dbo.vwTmVmLetzteBerPeriode 
WHERE BaPersonID = {BaPersonID}', NULL, 'vwTmVmLetzteBerPeriode', 5, 0, 1
  PRINT ('Info: XBookmark VmLetzteBerPeriode wurde erstellt');
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XBookmark.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_KBE-1458_Update_XBookmark.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSConcatDossierNr.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSConcatDossierNr.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSConcatDossierNr;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Konkateniert die übergebenen Werte nach dem BFS DossierNr Format:
           '<BaPersonID><GemeindeCode:4><Laufnummer:2><LeistungsartCode:2><Stichtag:1>'.
    @BaPersonID:       BaPersonID des BFS Dossierträgers
    @GemeindeCode:     BFSCode der zuständigen Gemeinde
    @Laufnummer:       Aufsteigende Nummer innerhalb einer Person und gleicher GemeindeCode.
    @LeistungsartCode: BFSCode der zuständigen Leistungsart
    @Stichtag:         Zum definieren ob es ein Stichtag- oder ein Anfangszustand-Dossier ist
  -
  RETURNS: Die BFS Dossier Nr des übergebenen Dossierträgers im Format: 
           '<BaPersonID><ZuständigeGemeinde:4><Laufnummer:2><LeistungsartCode:2><Stichtag:1>'. 
           Die ZuständigeGemeinde wird mit führenden Nullen auf 4 Stellen, die Laufnummer auf 
           2 Stellen formatiert, die Leistungsart auf 2 Stellen und der Stichtag auf 1. 
=================================================================================================
  TEST:    SELECT dbo.fnBFSConcatDossierNr(12345, 351, 1, 25, 1) --> 12345'0351'01'25'1;
           SELECT dbo.fnBFSConcatDossierNr(3, 2, 1, 25, 0) --> 3'0002'01'25'0;
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSConcatDossierNr
(
  @BaPersonID INT,
  @GemeindeCode INT,
  @Laufnummer INT,
  @LeistungsartCode INT, 
  @Stichtag BIT
)
RETURNS BIGINT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Parameter überprüfen
  -----------------------------------------------------------------------------
  IF(@BaPersonID IS NULL OR @GemeindeCode IS NULL OR @Laufnummer IS NULL OR @LeistungsartCode IS NULL OR @Stichtag IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  -- Wenn Werte -1 sind, auf 0 initialisiere, so dass beim konkatenieren der Default-Wert formatiert wird
  IF(@GemeindeCode = -1)
  BEGIN
    SET @GemeindeCode = 0;
  END;

  IF(@Laufnummer = -1)
  BEGIN
    SET @Laufnummer = 0;
  END;

  -----------------------------------------------------------------------------
  -- DossierNr konkatenieren: <BaPersonID><GemeindeCode:4><Laufnummer:2><LeistungsartCode:2><Stichtag:1>
  -----------------------------------------------------------------------------
  RETURN CONVERT(BIGINT, CONVERT(VARCHAR(10), @BaPersonID) +
                         dbo.fnFormatNumber(@GemeindeCode, 0, 'z4z', '0000') + 
                         dbo.fnFormatNumber(@Laufnummer, 0, 'z2z', '00') +
                         dbo.fnFormatNumber(@LeistungsartCode, 0, 'z2z', '00') +
                         CONVERT(VARCHAR(1), @Stichtag));
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSConcatDossierNr.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSConcatDossierNr.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sostat\spBFSGetDossierTree.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sostat\spBFSGetDossierTree.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBFSGetDossierTree;
GO
/*===============================================================================================
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:          Generate the tree filtered by search criterias used for editing and fixing 
                    BFS-Dossiers
    @Jahr:          Search value for filtering by year
    @UserID:        Search value for filtering by user-id
    @BaPersonID:    Search value for filtering by person's id
    @Stichtag:      Search value for filtering by flag Stichtag
    @AnfZustCode:   Search value for filtering by flag Anfangszustand
    @LeistArtCodes: Search value for filtering by LOV "BFSLeistungsart"
    @BFSDossierNr:  Search value for filtering by unique BFSDossier-number (generated from various 
                    values by specific function)
    @BFSDossierID:  Search value for filtering by BFSDossier.BFSDossierID
  -
  RETURNS: The tree used for BFSDossier-management in CtlBfsDossiers
=================================================================================================
  TEST:    EXECUTE dbo.spBfsGetDossierTree NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL
           EXECUTE dbo.spBfsGetDossierTree NULL, NULL, NULL, 1, NULL, NULL, 67426035100, NULL
=================================================================================================*/

CREATE PROCEDURE dbo.spBFSGetDossierTree
(
  @Jahr INT,
  @UserID INT,
  @BaPersonID INT,
  @Stichtag BIT,
  @AnfZustCode BIT,
  @LeistArtCodes VARCHAR(50),
  @BFSDossierNr VARCHAR(50),
  @BFSDossierID INT
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Init
  -----------------------------------------------------------------------------
  DECLARE @Tree TABLE 
  (
    TreeID INT IDENTITY(1,1) NOT NULL,
    ID VARCHAR(250) PRIMARY KEY,
    ParentID VARCHAR(250),
    Text VARCHAR(150),
    BFSDossierID INT,
    BFSDossierNr BIGINT,
    BFSKatalogVersionID INT,
    Jahr INT,
    BFSLeistungsfilterCode INT,
    Stichtag BIT,
    BFSPersonCode INT,
    PersonIndex INT,
    BFSDossierPersonID INT,
    BFSKategorieCode INT,
    Fehler INT,
    Anzahl INT
  );
  
  DECLARE @BFSLeistungsfilter TABLE
  (
    BFSKatalogVersionID INT,
    BFSLeistungsfilterCode INT,
    BFSPersonCode INT,
    Person VARCHAR(200),
    PersonIndex INT,
    BFSKategorieCode INT,
    Kategorie VARCHAR(200)
  );
  
  -----------------------------------------------------------------------------
  -- BFSLeistungsfilter
  -----------------------------------------------------------------------------
  INSERT INTO @BFSLeistungsfilter
    SELECT DISTINCT 
      FRA.BFSKatalogVersionID, 
      BLC.Code, 
      FRA.BFSPersonCode, 
      PRS.Text, 
      FRA.PersonIndex, 
      FRA.BFSKategorieCode, 
      KAT.Text
    FROM dbo.BFSFrage           FRA WITH (READUNCOMMITTED)
      INNER JOIN dbo.BFSLOVCode BLC WITH (READUNCOMMITTED) ON BLC.LOVName = 'BFSLeistungsfilter' 
                                                          AND ',' + FRA.BFSLeistungsfilterCodes + ',' LIKE '%,' + CONVERT(VARCHAR, BLC.Code) + ',%'
      INNER JOIN dbo.BFSLOVCode KAT WITH (READUNCOMMITTED) ON KAT.LOVName = 'BFSKategorie'       
                                                          AND KAT.Code = FRA.BFSKategorieCode
      INNER JOIN dbo.BFSLOVCode PRS WITH (READUNCOMMITTED) ON PRS.LOVName = 'BFSPerson'          
                                                          AND PRS.Code = FRA.BFSPersonCode;
  
  -----------------------------------------------------------------------------
  -- Tree: BFSDossier
  -----------------------------------------------------------------------------
  INSERT INTO @Tree
  (
    ID, 
    ParentID, 
    Text, 
    BFSKatalogVersionID, 
    BFSDossierID, 
    BFSDossierNr,
    Jahr, 
    BFSLeistungsfilterCode, 
    Stichtag
  )
    SELECT
      ID                     = 'DOS_' + CONVERT(VARCHAR, DOS.BFSDossierID),
      ParentID               = CONVERT(VARCHAR, Jahr) + '_PRS_' + COALESCE(PRS.NameVorname, DOP.PersonName, '???'),
      Text                   = LEI.Text + CASE 
                                            WHEN Stichtag = 1 THEN '' 
                                            ELSE ' (Anfangszustand)' 
                                          END,
      BFSKatalogVersionID    = DOS.BFSKatalogVersionID,
      BFSDossierID           = DOS.BFSDossierID,
      BFSDossierNr           = dbo.fnBFSConcatDossierNr(DOP.BaPersonID, DOS.ZustaendigeGemeinde, DOS.LaufNr, DOS.BFSLeistungsartCode, DOS.Stichtag),
      Jahr                   = DOS.Jahr,
      BFSLeistungsfilterCode = LEI.Filter,
      Stichtag               = DOS.Stichtag
    FROM dbo.BFSDossier               DOS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID 
                                                                AND DOP.BFSPersonCode = 1
      LEFT  JOIN dbo.vwPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DOP.BaPersonID
      LEFT  JOIN dbo.BFSLOVCode       LEI WITH (READUNCOMMITTED) ON LEI.LOVName = 'BFSLeistungsart'
                                                                AND LEI.Code = DOS.BFSLeistungsartCode
    WHERE ISNULL(@BFSDossierID, DOS.BFSDossierID) = DOS.BFSDossierID
      AND (@BFSDossierNr IS NULL OR dbo.fnBFSConcatDossierNr(DOP.BaPersonID, DOS.ZustaendigeGemeinde, DOS.LaufNr, DOS.BFSLeistungsartCode, DOS.Stichtag) = REPLACE(@BFSDossierNr,'.',''))
      AND (@Jahr IS NULL OR DOS.Jahr = @Jahr)
      AND (@UserID IS NULL OR DOS.UserID = @UserID)
      AND (@BaPersonID IS NULL OR DOP.BaPersonID = @BaPersonID)
      AND (DOS.Stichtag IN (CASE 
                              WHEN (@AnfZustCode = 1 AND @Stichtag = 0) THEN 0
                              WHEN (@AnfZustCode = 0 AND @Stichtag = 1) THEN 1
                              WHEN (@AnfZustCode = 0 AND @Stichtag = 0) THEN NULL
                              ELSE DOS.Stichtag
                            END))
      AND (@LeistArtCodes IS NULL OR ',' + @LeistArtCodes + ',' LIKE '%,' + CONVERT(VARCHAR, DOS.BFSLeistungsartCode) + ',%');
  
  UPDATE TRE 
  SET Fehler = (SELECT COUNT(1) 
                FROM dbo.BFSWert WRT WITH (READUNCOMMITTED)
                WHERE WRT.BFSDossierID = TRE.BFSDossierID 
                  AND WRT.PlausiFehler IS NOT NULL)
  FROM @Tree TRE;

  -- Jahr
  INSERT INTO @Tree (ID, Text, Jahr)
    SELECT DISTINCT Jahr, Jahr, Jahr 
    FROM @Tree;

  -- Antragsteller
  INSERT INTO @Tree (ID, ParentID, Text, Jahr)
    SELECT DISTINCT ParentID, Jahr, COALESCE(PRS.NameVorname, DOP.PersonName, '???'), Jahr
    FROM @Tree                        TRE
      INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = TRE.BFSDossierID 
                                                                AND DOP.BFSPersonCode = 1
      LEFT  JOIN dbo.vwPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DOP.BaPersonID;
  
  -----------------------------------------------------------------------------
  -- Tree: BFSKategorien
  -----------------------------------------------------------------------------
  INSERT INTO @Tree 
  (
    ID, 
    ParentID, 
    Text, 
    BFSKatalogVersionID, 
    BFSDossierID, 
    BFSDossierNr,
    Jahr, 
    BFSLeistungsfilterCode, 
    Stichtag,
    BFSPersonCode, 
    PersonIndex, 
    BFSDossierPersonID, 
    BFSKategorieCode, 
    Fehler
  )
    SELECT DISTINCT
      ID = 'DOS_' + CONVERT(VARCHAR, DOS.BFSDossierID) + 
           '_' + CONVERT(VARCHAR, DOP.BFSPersonCode) + 
           '_' + CONVERT(VARCHAR, DOP.PersonIndex) + 
           '_' + CONVERT(VARCHAR, KAT.BFSKategorieCode),
      --
      ParentID = 'DOS_' + CONVERT(VARCHAR, DOS.BFSDossierID) + 
                 CASE 
                   WHEN DOP.BFSPersonCode > 1 AND KAT.BFSKategorieCode > 2 THEN '_' + CONVERT(VARCHAR, DOP.BFSPersonCode) + 
                                                                                '_' + CONVERT(VARCHAR, DOP.PersonIndex) + '_2'
                   ELSE ''
                 END,
      --
      Text = CASE 
               WHEN DOP.BFSPersonCode = 1 OR KAT.BFSKategorieCode > 2 THEN KAT.Kategorie COLLATE DATABASE_DEFAULT
               ELSE KAT.Person COLLATE DATABASE_DEFAULT + ' - ' + COALESCE(PRS.NameVorname, DOP.PersonName, '???') COLLATE DATABASE_DEFAULT
             END COLLATE DATABASE_DEFAULT,
      --
      BFSKatalogVersionID    = DOS.BFSKatalogVersionID,
      BFSDossierID           = DOS.BFSDossierID,
      BFSDossierNr           = DOS.BFSDossierNr,   
      Jahr                   = DOS.Jahr,
      BFSLeistungsfilterCode = DOS.BFSLeistungsfilterCode,
      Stichtag               = DOS.Stichtag,

      BFSPersonCode          = DOP.BFSPersonCode,
      PersonIndex            = DOP.PersonIndex,
      BFSDossierPersonID     = DOP.BFSDossierPersonID,
      BFSKategorieCode       = KAT.BFSKategorieCode,
      --
      Fehler = (SELECT COUNT(1) 
                FROM dbo.BFSWert          WRT WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BFSFrage FRG WITH (READUNCOMMITTED) ON FRG.BFSFrageID = WRT.BFSFrageID
                WHERE WRT.BFSDossierID = DOS.BFSDossierID
                  AND WRT.PlausiFehler IS NOT NULL
                  AND WRT.BFSDossierPersonID = DOP.BFSDossierPersonID
                  AND FRG.BFSKategorieCode = KAT.BFSKategorieCode)
  FROM @Tree DOS
    INNER JOIN @BFSLeistungsfilter  KAT                        ON KAT.BFSKatalogVersionID = DOS.BFSKatalogVersionID 
                                                              AND KAT.BFSLeistungsfilterCode = DOS.BFSLeistungsfilterCode
    INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID
                                                              AND DOP.BFSPersonCode = KAT.BFSPersonCode 
                                                              AND DOP.PersonIndex = KAT.PersonIndex
    LEFT  JOIN dbo.vwPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DOP.BaPersonID
  ORDER BY DOS.BFSDossierID, DOP.BFSPersonCode, DOP.PersonIndex, KAT.BFSKategorieCode;
  
  -----------------------------------------------------------------------------
  -- Anzahl Dossiers zusammenzählen ...
  -----------------------------------------------------------------------------
  DECLARE @AnzahlDossiers INT;
  
  SELECT @AnzahlDossiers = COUNT(DISTINCT BFSDossierID) 
  FROM @Tree
  WHERE BFSDossierID IS NOT NULL;
  
  -- ... und in Tabelle @Tree speichern
  UPDATE @Tree 
  SET Anzahl = @AnzahlDossiers;
  
  -----------------------------------------------------------------------------
  -- Tabelle @Tree übergeben
  -----------------------------------------------------------------------------
  SELECT
    TreeID,
    ID,
    ParentID,
    Text,
    BFSDossierID,
    BFSDossierNr,
    BFSKatalogVersionID,
    Jahr,
    BFSLeistungsfilterCode,
    Stichtag,
    BFSPersonCode,
    PersonIndex,
    BFSDossierPersonID,
    BFSKategorieCode,
    Fehler,
    Anzahl
  FROM @Tree
  ORDER BY Jahr, ID;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sostat\spBFSGetDossierTree.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sostat\spBFSGetDossierTree.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5239_KBE-1501_Update_BFSFrage.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5239_KBE-1501_Update_BFSFrage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update BFSFrage (Change all call to fnBFSConcatDossierNr)
=================================================================================================*/


PRINT 'Tabelle BFSFrage aktualisieren'
GO

UPDATE dbo.BFSFrage
  SET HerkunftSQL = N'SELECT @value = dbo.fnBFSConcatDossierNr(PER.BaPersonID, DOS.ZustaendigeGemeinde, DOS.LaufNr, DOS.BFSLeistungsartCode, DOS.Stichtag)  FROM dbo.BFSDossier               DOS WITH (READUNCOMMITTED)     INNER JOIN dbo.BFSDossierPerson PER WITH (READUNCOMMITTED) ON PER.BFSDossierID = DOS.BFSDossierID                                                              AND PER.BFSPersonCode = 1 --1: Antragsteller  WHERE DOS.BFSDossierID = @BFSDossierID'
  WHERE BFSFrageID = (SELECT TOP 1 BFSFrageID FROM dbo.BFSFrage WHERE VariableExpandiert = '001.0000b' ORDER BY BFSKatalogVersionID DESC);
GO

PRINT 'fnBFSConcatDossierNr anrufen wurden aktualisiert'
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5239_KBE-1501_Update_BFSFrage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5239_KBE-1501_Update_BFSFrage.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41003_KBE-1453_Update_BFSFrage.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41003_KBE-1453_Update_BFSFrage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update entries in BFSFrage table
=================================================================================================*/


UPDATE FRA 
  SET HerkunftSQL = 'SELECT @value = SUM(CASE WHEN BgKategorieCode in (1,4) THEN -Betrag ELSE Betrag END)
FROM dbo.fnBFSMonatsBelege(@AntragstellerID, @BFSLeistungsartCode, YEAR(@DatumBis), MONTH(@DatumBis), 0)
WHERE BgKategorieCode IN (1, 2, 4, 100, 101) -- Einnahmen, Ausgaben, Kürzungen, ZL, EZ

IF (@value < 0)
BEGIN
  SET @value = 0;
END;'
FROM dbo.BFSFrage FRA
WHERE Variable = '15.051'
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variable 15.051 wurde angepasst');

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41003_KBE-1453_Update_BFSFrage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41003_KBE-1453_Update_BFSFrage.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaIsValidVersichertennummer.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaIsValidVersichertennummer.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBaIsValidVersichertennummer
GO

/*===============================================================================================
	$Archive: /KiSS4/Database/DBOs/Functions/System/fnBaIsValidVersichertennummer.sql $
	$Author: DFE $
	$Modtime: 06.11.17 08:00 $
	$Revision: 1 $
=================================================================================================
	Description
-------------------------------------------------------------------------------------------------
	SUMMARY: Check if Versichertennummer is Valid
	 @VersNrChars: The versichertennummer
	-
	RETURNS: True if is valid, otherwise false
	-
	TEST:    SELECT dbo.fnBaIsValidVersichertennummer('000.0000.0000.00', DEFAULT)
					 SELECT dbo.fnBaIsValidVersichertennummer('222.2222.2222.22', DEFAULT)
					 SELECT dbo.fnBaIsValidVersichertennummer('756.1234.5678.97', DEFAULT)
=================================================================================================*/

CREATE FUNCTION [dbo].[fnBaIsValidVersichertennummer]
(
	@VersNrChars NVARCHAR(255),
	@IsAltWertValid BIT = 0
)
RETURNS BIT
AS BEGIN
	
	IF dbo.fnIsNullOrEmpty(@VersNrChars, NULL, NULL, NULL) IS NULL
	BEGIN
		-- Empty new AVS Number is forbidden
		RETURN @IsAltWertValid
	END

	DECLARE @isOldFormatValid NVARCHAR(255) = '[0-9][0-9][0-9].[0-9][0-9].[0-9][0-9][0-9].[0-9][0-9][0-9]'
	IF PATINDEX(@isOldFormatValid, @VersNrChars) = 1
	BEGIN
		IF PATINDEX('000.00.000.000', @VersNrChars) = 1 OR @IsAltWertValid = 0
		BEGIN
			RETURN 0
		END
		RETURN 1
	END

	DECLARE @isNewFormatValid NVARCHAR(255) = '[0-9][0-9][0-9].[0-9][0-9][0-9][0-9].[0-9][0-9][0-9][0-9].[0-9][0-9]'
	IF (PATINDEX(@isNewFormatValid, @VersNrChars) <> 1 OR PATINDEX('000.0000.0000.00', @VersNrChars) = 1)
	BEGIN
		RETURN 0
	END

	-- Kontrollzifferprüfung gemäss EAN-13 (siehe http://www.ahv-iv-ar.ch/site/index.cfm?id_art=32126, https://de.wikipedia.org/wiki/European_Article_Number#Pr.C3.BCfziffer)
	DECLARE @sum INT = 0;-- store the sum of all multiplied values
	DECLARE @isEvenNumber BIT = 0;-- flag if current entry is a even position (true = digit 2, 4, 6, 8, 10, 12 from right hand, started with 2nd digit)
	DECLARE @numbers TABLE(ID TINYINT IDENTITY(1,1),val CHAR)

	SET @VersNrChars = REPLACE(@VersNrChars,'.','')

	-- split current validated value of versNr to single chars for parsing
	DECLARE @count INT = 1
	WHILE @count <= LEN(@VersNrChars)
	BEGIN
		INSERT @numbers(val) VALUES (SUBSTRING(@VersNrChars, @count, 1))
		SET @count = @count + 1
	END

	SET @sum = (SELECT 
		SUM(
			CASE (ID % 2)
				WHEN 0 THEN CAST(val AS INT)*3
				WHEN 1 THEN CAST(val AS INT)
			END
		)
	FROM @numbers
	WHERE ID < 13)
	
	--// calculate checknumber as defined
	DECLARE @checkNumber INT = (10 - (@sum % 10)) % 10

	--// compare with current last digit
	IF EXISTS(SELECT val FROM @numbers WHERE ID = 13 AND val = @checkNumber)
	BEGIN
		RETURN 1
	END

	-----------------------------------------------------------------------------
	-- if we are here, the Versichertennummer is not valid
	-----------------------------------------------------------------------------
	RETURN 0
END
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaIsValidVersichertennummer.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaIsValidVersichertennummer.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5305_SOSTAT-2017_Update_BFSFrage.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5305_SOSTAT-2017_Update_BFSFrage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Updates the BFSFrage 1.03 and 1.05 to check Avs Number with fnIsValidVersichertennummer
-------------------------------------------------------------------------------------------------
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- update BFSFrage 1.03 und 1.05
-------------------------------------------------------------------------------
UPDATE dbo.BFSFrage
  SET HerkunftSQL = 'SELECT @value = 
  CASE 
    WHEN dbo.fnBaIsValidVersichertennummer(BaPerson.AHVNummer, 1) = 1 THEN BaPerson.AHVNummer
    ELSE NULL 
  END 
FROM dbo.BaPerson WITH (READUNCOMMITTED)
  WHERE BaPerson.BaPersonID = @BaPersonID'
WHERE Variable = '1.03'
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variable 1.03 wurde angepasst');

UPDATE dbo.BFSFrage
  SET HerkunftSQL = 'SELECT @value = 
  CASE 
    WHEN dbo.fnBaIsValidVersichertennummer(vwPerson.VersichertenNummer, DEFAULT) = 1 THEN vwPerson.Versichertennummer
    ELSE NULL
  END 
FROM dbo.vwPerson
  WHERE vwPerson.BaPersonID = @BaPersonID'
WHERE Variable = '1.05'
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variable 1.05 wurde angepasst');
GO


-------------------------------------------------------------------------------
-- BFSFrage 7.07 und 7.08 aus Katalog entfernen
-------------------------------------------------------------------------------
UPDATE FRA 
  SET BFSLeistungsfilterCodes = NULL -- '1,2,3,8,9,10'
FROM dbo.BFSFrage FRA WITH (READUNCOMMITTED)
WHERE Variable IN  ('7.07', '7.08')
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variablen 7.07 und 7.08 wurde entfernt');
GO



-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5305_SOSTAT-2017_Update_BFSFrage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R5305_SOSTAT-2017_Update_BFSFrage.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSGetLeistungsartCode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSGetLeistungsartCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSGetLeistungsartCode
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSGetLeistungsartCode
(
  @FaProzessCode INT,
  @FaLeistungID  INT
)
RETURNS INT
AS 
BEGIN
  DECLARE @BFSLeistungsartCode INT;

  -- Für alle anderen mit LeistungsartCode 
  SET @BFSLeistungsartCode = (SELECT TOP 1 COALESCE(dbo.fnBFSCode('Leistungsart', LEI.LeistungsartCode),
                                                    dbo.fnBFSCode('FaProzess', @FaProzessCode),
                                                    2)
                              FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                              WHERE LEI.FaLeistungID = @FaLeistungID);
  
  RETURN @BFSLeistungsartCode;
END
GO 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSGetLeistungsartCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Sostat\fnBFSGetLeistungsartCode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwKreditor;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwKreditor;
=================================================================================================*/

CREATE VIEW dbo.vwKreditor WITH SCHEMABINDING
AS
WITH BaZahlungsweg_CTE
AS
(
    SELECT ZAH.BaZahlungswegID,
           ZAH.DatumVon,
           ZAH.DatumBis,
           ZAH.EinzahlungsscheinCode,
           ZAH.BankKontoNummer,
           ZAH.IBANNummer,
           ZAH.PostKontoNummer,
           ZAH.ReferenzNummer,
           ZAH.BaBankID,
           ZAH.BaInstitutionID,
           ZAH.BaPersonID,
           ZAH.AdresseName,
           ZAH.AdresseName2,
           ZAH.AdressePostfach,
           ZAH.AdresseStrasse,
           ZAH.AdresseHausNr,
           ZAH.AdressePLZ,
           ZAH.AdresseOrt
    FROM dbo.BaZahlungsweg ZAH
    WHERE (ZAH.BaInstitutionID IS NOT NULL OR ZAH.BaPersonID IS NOT NULL) -- cka: Kreditor muss Person oder Institution haben!
)
SELECT BaZahlungswegID           = ZAH.BaZahlungswegID,
       ZahlungswegDatumVon       = ZAH.DatumVon,
       ZahlungswegDatumBis       = ZAH.DatumBis,
       EinzahlungsscheinCode     = ZAH.EinzahlungsscheinCode,
       BankKontoNummer           = ZAH.BankKontoNummer,
       IBANNummer                = ZAH.IBANNummer,
       PostKontoNummer           = ZAH.PostKontoNummer,
       ReferenzNummer            = ZAH.ReferenzNummer,
       BaBankID                  = ZAH.BaBankID,
       BankName                  = BNK.Name,
       BankZusatz                = BNK.Zusatz,
       BankStrasse               = BNK.Strasse,
       BankPLZ                   = BNK.PLZ,
       BankOrt                   = BNK.Ort,
       BankClearingNr            = BNK.ClearingNr,
       BankPCKontoNr             = BNK.PCKontoNr,
       BankGueltigAb             = BNK.GueltigAb,
       BankLandCode              = BNK.LandCode,
       BaInstitutionID           = ZAH.BaInstitutionID,
       InstitutionName           = INS.[Name],
       BaFreigabeStatusCode      = INS.BaFreigabeStatusCode,
       InstitutionAdresse        = INS.Adresse,
       InstitutionOrtStrasse     = INS.OrtStrasse,
       InstitutionAdressZusatz   = INS.AdressZusatz,
       InstitutionStrasse        = INS.Strasse,
       InstitutionHausNr         = INS.HausNr,
       InstitutionStrasseHausNr  = INS.StrasseHausNr,
       InstitutionPostfach       = INS.Postfach,
       InstitutionPLZ            = INS.PLZ,
       InstitutionOrt            = INS.Ort,
       InstitutionPLZOrt         = INS.PLZOrt,
       InstitutionKanton         = INS.Kanton,
       InstitutionLand           = INS.Land,
       InstitutionBaLandID       = INS.BaLandID,
       BaPersonID                = ZAH.BaPersonID,
       PersonName                = PRS.Name,
       PersonVorname             = PRS.Vorname,
       PersonNameVorname         = PRS.NameVorname,
       PersonAdresse             = PRS.Wohnsitz,
       PersonAdressZusatz        = PRS.WohnsitzAdressZusatz,
       PersonStrasse             = PRS.WohnsitzStrasse,
       PersonHausNr              = PRS.WohnsitzHausNr,
       PersonStrasseHausNr       = PRS.WohnsitzStrasseHausNr,
       PersonPostfach            = PRS.WohnsitzPostfach,
       PersonPLZ                 = PRS.WohnsitzPLZ,
       PersonOrt                 = PRS.WohnsitzOrt,
       PersonPLZOrt              = PRS.WohnsitzPLZOrt,
       PersonKanton              = PRS.WohnsitzKanton,
       PersonLand                = PRS.WohnsitzLand,
       PersonBaLandID            = PRS.WohnsitzBaLandID,
       Kreditor                  = COALESCE(ZAH.AdresseName, INS.[Name], PRS.NameVorname),
       KreditorMehrZeilig        = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL 
                                      AND ZAH.AdressePLZ IS NOT NULL 
                                      AND ZAH.AdresseOrt IS NOT NULL 
                                      THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                           ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.NameVorname + CHAR(13) + CHAR(10) + PRS.WohnsitzMehrzeilig
                                     ELSE INS.[Name] + CHAR(13) + CHAR(10) + INS.AdresseMehrzeilig
                                   END,
       KreditorEinzeilig         = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL
                                      AND ZAH.AdressePLZ IS NOT NULL
                                      AND ZAH.AdresseOrt IS NOT NULL
                                      THEN ZAH.AdresseName + ', ' +
                                           ISNULL(ZAH.AdresseName2 + ', ', '') +
                                           ISNULL(ZAH.AdressePostfach + ', ', '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + ', ', '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.VornameName + ', ' + PRS.Wohnsitz
                                     ELSE INS.[Name] + ', ' + INS.Adresse
                                   END,
       Zahlungsweg               = EIZ.ShortText +
                                   ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)),'') +
                                   ISNULL(', ' + BNK.Name, '') +
                                   ISNULL(', ' + ZAH.BankKontoNummer, '') +
                                   ISNULL(', ' + ZAH.IBANNummer,''),
       ZahlungswegMehrZeilig     = EIZ.ShortText +
                                   ISNULL(CHAR(13) + CHAR(10) + 'IBAN:     ' + ZAH.IBANNummer,'') +
                                   ISNULL(CHAR(13) + CHAR(10) + 'Konto:    ' + ZAH.BankKontoNummer, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + BNK.Name, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + BNK.Strasse, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + ISNULL(BNK.PLZ + ' ', '') + BNK.Ort, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + 'PC-Konto: ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)), ''),
       PCKontoNr                 = dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)),
       ZusatzInfo                = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL 
                                      AND ZAH.AdressePLZ IS NOT NULL 
                                      AND ZAH.AdresseOrt IS NOT NULL
                                      THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                           ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.WohnsitzMehrzeilig
                                     ELSE INS.AdresseMehrzeilig
                                   END + CHAR(13) + CHAR(10) +
                                   '** ' + EIZ.ShortText + ' **' + CHAR(13) + CHAR(10) +
                                   ISNULL(dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)) + ISNULL(', ' + BNK.Name,'') + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ZAH.BankKontoNummer + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ZAH.IBANNummer, ''),
       IsActive                  = CONVERT(BIT, CASE 
                                                  WHEN GETDATE() BETWEEN ISNULL(ZAH.DatumVon, GETDATE()) AND ISNULL(ZAH.DatumBis, GETDATE()) THEN 1 
                                                  ELSE 0 
                                                END),
       BeguenstigtName           = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseName
                                          WHEN ZAH.BaPersonID IS NOT NULL THEN PRS.NameVorname
                                          ELSE INS.[Name]
                                        END, 35),
       BeguenstigtName2          = LEFT(CASE
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseName2 
                                        END, 35),
       BeguenstigtStrasse        = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseStrasse
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzStrasse
                                          ELSE INS.Strasse
                                        END, 35),
       BeguenstigtHausNr         = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseHausNr
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzHausNr
                                          ELSE INS.HausNr
                                        END, 35),
       BeguenstigtStrasseHausNr  = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '')
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzStrasseHausNr
                                          ELSE INS.StrasseHausNr
                                        END, 35),
       BeguenstigtPLZ            = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdressePLZ
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzPLZ
                                          ELSE INS.PLZ
                                        END, 10),
       BeguenstigtOrt            = LEFT(CASE
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseOrt
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzOrt
                                          ELSE INS.Ort
                                        END, 25)
FROM BaZahlungsweg_CTE        ZAH WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAH.BaInstitutionID
  LEFT JOIN dbo.vwPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ZAH.BaPersonID
  LEFT JOIN dbo.XLOVCode      EIZ WITH (READUNCOMMITTED) ON EIZ.LOVName = 'BgEinzahlungsschein' 
                                                        AND EIZ.Code = ZAH.EinzahlungsscheinCode
  LEFT JOIN dbo.BaBank        BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = ZAH.BaBankID;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sozialhilfe\Standard\spWhBudget_CreateKbBuchung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sozialhilfe\Standard\spWhBudget_CreateKbBuchung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_CreateKbBuchung
GO
/*===============================================================================================
  $Revision: 44 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Grünstellroutine.
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhBudget_CreateKbBuchung]
(
  @BgBudgetID          int,
  @UserID              int,
  @PreviewMode         int = 0,    -- 0: kein Preview (sondern echte Einträge in KbBuchung... Tabellen, 
                                   -- 1: Netto Preview, (temporäre Buchungen generieren)
                                   -- 2: Brutto Preview (temporäre Buchungen generieren)
  @CreateAllLocked     bit = 0,    -- 1: Die Buchungen mit Status 'gesperrt' generieren
  @BgPositionID_IN     int = NULL, -- 1: BgPositionID der Budgetposition, die separat auf grün gestellt werden soll
  @IncludeZahlwegGroup bit = 0,    -- 1: für Einzelpositionen auch weitere Positionen mit gleichem Zahlweg mitberücksichtigen
  @CheckSpezialkonti   bit = 1     -- 1: Prüfen, ob Spezialkonti (falls benützt) genügend Deckung aufweisen
)
AS BEGIN
  /*
    Gibt ein Monatsbudget zur Zahlung frei:
    - Sämtliche Belege des Budgets (ausser Einzelzahlungen) werden generiert, falls:
    - Der Status des Monatsbudget wird von 101 auf 102 gewechselt
  */
  SET NOCOUNT ON

  DECLARE @BgFinanzplanID            int,
          @MasterBudget              bit,
          @BgBewilligungStatusCode   int,
          @RefDate                   datetime,
          @FirstDayInMonth           datetime,
          @LastDayInMonth            datetime,
          @BgJahr                    int,
          @BgMonat                   int,
          @FAL_BaPersonID            int,
          @Person                    varchar(100),  -- Name/Vorname
          @FaLeistungID              int,

          @BuchungenID               int,

          @StartSaldo                money,
          @Summe                     money,
          @BetragKonto               money,

          @BuchungstextZL            varchar(120),  -- Zahlungslauf
          @BuchungstextBL            varchar(120),  -- Beleg

          @msg                       varchar(max),
          @KbPeriodeID               int,
          @TotalBetrag               money,
          @KbBuchungStatusCode       int,
          @Diff                      money,
          @SummeGBLAbzug             money,
          @SummeGBL                  money,
          @BgKostenartIDGBL          int,
          @BgPositionsartIDGBL       int,
          @BgPositionIDGBL           int,

          @KontoNrDebitor            varchar(10),
          @KontoNrKreditor           varchar(10),
          @KontoNrInterneVerrechnung varchar(10),
          @KissStandard              bit,

          @EFBErwerbsaufnahme        bit,

          @KreditorMehrZeilig        VARCHAR(MAX),
          @ClearingNr                VARCHAR(15),
          @ClearingNrNeu             VARCHAR(15),
          
          @ErrorMessage              varchar(max);

  SET @KissStandard = 1


  /************************************************************************************************/
  /* Check parameters                                                                             */
  /************************************************************************************************/
  IF @BgBudgetID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @BgBudgetID ist null!', 18, 1)
    RETURN -1
  END

  IF @UserID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
    RETURN -1
  END

  IF @UserID NOT IN (SELECT UserID FROM dbo.XUser WITH (READUNCOMMITTED)) BEGIN
    RAISERROR ('Es existiert kein User mit ID %d!', 18, 1, @UserID)
    RETURN -1
  END

  IF NOT EXISTS (SELECT 1 FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID) BEGIN
    RAISERROR ('Das Monatsbudget mit der ID %d existiert nicht!', 18, 1, @BgBudgetID)
    RETURN -1
  END

  SET @KbBuchungStatusCode = CASE @PreviewMode WHEN 0 THEN 2 /*freigegeben*/ ELSE 1 /*vorbereitet*/ END

  /************************************************************************************************/
  /* Get Monatsbudget properties, Check Stati, validate                                           */
  /************************************************************************************************/
  SELECT @BgFinanzplanID          = BBG.BgFinanzplanID,
         @MasterBudget            = BBG.MasterBudget,
         @BgBewilligungStatusCode = BBG.BgBewilligungStatusCode,
         @RefDate                 = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
         @BgJahr                  = BBG.Jahr,
         @BgMonat                 = BBG.Monat,
         @FAL_BaPersonID          = FAL.BaPersonID,
         @Person                  = PRS.Name + IsNull(', ' + Vorname,''),
         @FirstDayInMonth         = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
         @LastDayInMonth          = dbo.fnLastDayOf(@FirstDayInMonth),
         @BgKostenartIDGBL        = BPA.BgKostenartID,
         @BgPositionsartIDGBL     = SFP.WhGrundbedarfTypCode,
         @FaLeistungID            = FAL.FaLeistungID
  FROM   dbo.BgBudget                    BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan          SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID     = BBG.BgFinanzplanID
    INNER JOIN dbo.FaLeistung            FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID       = SFP.FaLeistungID
    INNER JOIN dbo.BaPerson              PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID         = FAL.BaPersonID
    INNER JOIN dbo.BgPositionsart        BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartCode = SFP.WhGrundbedarfTypCode AND
                                                                       ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) AND 
                                                                       ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1))
  WHERE BBG.BgBudgetID = @BgBudgetID

  IF (@@ROWCOUNT = 0) BEGIN
    RAISERROR ('Inkonsistente Konfiguration im Finanzplan: Es existiert keine Positionsart für den Grundbedarf in diesem Monat.', 18, 1)
    RETURN -1
  END

  IF (@@ROWCOUNT > 1) BEGIN
    RAISERROR ('Inkonsistente Konfiguration im Finanzplan: Es existieren mehrere Positionsarten für den Grundbedarf in diesem Monat.', 18, 1)
    RETURN -1
  END

  IF (@MasterBudget = 1) BEGIN
    RAISERROR ('Dieses Budget ist ein Masterbudget !', 18, 1)
    RETURN -1
  END

  IF (@BgBewilligungStatusCode = 5 AND @BgPositionID_IN IS NULL) BEGIN
    -- Für ein bewilligtes Budget werden keine Vorschaubelege erzeugt    
    IF @PreviewMode > 0
      RETURN 0
    RAISERROR ('Dieses Monatsbudget ist bereits zur Zahlung freigegeben!', 18, 1)
    RETURN -1
  END

  IF (@BgBewilligungStatusCode = 9) BEGIN
    RAISERROR ('Dieses Monatsbudget ist gesperrt!', 18, 1)
    RETURN -1
  END

  /************************************************************************************************/
  /* Check Konsistenz                                                                             */
  /************************************************************************************************/
  DECLARE @COUNT int
  DECLARE @BgPositionID_Parent int;   
      
  SELECT @BgPositionID_Parent = BgPositionID_Parent
  FROM dbo.vwBgPosition 
  WHERE BgBudgetID = @BgBudgetID AND BgPositionID = @BgPositionID_IN              

  -- #vwBgPosition ist eine temporäre Tabelle, die die BgPositionen enthält.
  -- Die Haupt- und Nebenpositionen können nur zusammen auf grün oder grau
  -- gestellt werden: Auch wenn eine BgPositionsID mitgegeben wird, können mehrere
  -- BgPositionen betroffen sein. 

  SELECT *, BelegVorhanden = dbo.fnWhExistsBelegForPosition(BgPositionID)
  INTO #vwBgPosition
  FROM dbo.vwBgPosition
  WHERE BgBudgetID = @BgBudgetID
    AND ((@BgPositionID_IN IS NULL 
      OR BgPositionID = @BgPositionID_IN
      OR (BgKategorieCode IN (100, 101) AND BgPositionID_Parent = @BgPositionID_IN))  --Hauptposition ist angewählt --> alle Nebenpositionen auch grünstellen
      OR (BgKategorieCode IN (100, 101) AND @BgPositionID_Parent IS NOT NULL AND (BgPositionID = @BgPositionID_Parent OR BgPositionID_Parent = @BgPositionID_Parent)) -- Nebenposition ist angewählt --> Hauptposition und alle Nebenpositionen auch grünstellen
    )

  CREATE NONCLUSTERED INDEX [IX_vwBgPosition_BgKategorieCode] ON [dbo].[#vwBgPosition] ([BgKategorieCode])
  CREATE NONCLUSTERED INDEX [IX_vwBgPosition_BgPositionID] ON [dbo].[#vwBgPosition] ([BgPositionID])


  -- Bereits verbuchte Buchungen. Wenn bereits verbuchte Buchungen vorhanden sind, dann kann man nicht auf grün stellen.
  SELECT @COUNT = COUNT(*)
  FROM   dbo.KbBuchung                KBU WITH (READUNCOMMITTED)
    INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID = KBU.KbBuchungID
  WHERE BgBudgetID = @BgBudgetID AND BgPositionID IN (SELECT BgPositionID FROM #vwBgPosition)
    AND KbBuchungTypCode IN (1/*Budget*/) AND KbBuchungStatusCode NOT IN (5,8,9) --falls Belege in diesen Sati existieren, können neue erzeugt werden 

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Für ' + CASE WHEN @BgPositionID_IN IS NULL THEN  'dieses Budget' ELSE 'diese Budgetposition' END + ' gibt es bereits verbuchte Belege!'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  -- Positionen ohne Positionsarten
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition       BPO
    LEFT JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
    LEFT JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,    SPZ.BgKostenartID)
  WHERE BPO.BgKategorieCode IN (1, 2, 100) -- Einnahmen, Ausgaben, Einzelzahlungen
    AND (BPO.BetragBudget) > 0
    AND (BKA.BgKostenartID IS NULL )

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Den folgenden Positionen dieses Budgets ist keine Leistungsart zugeordnet:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  -- Positionen ohne BaAuszahlung-FK
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition BPO
  WHERE (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Einzelzahlungen, Ausgaben, Zusätzliche Leistung
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND NOT EXISTS (SELECT 1 FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                    WHERE BgPositionID = BPO.BgPositionID
                      AND (KbAuszahlungsArtCode <> 106 OR BPO.BgKategorieCode <> 2) -- keine Vorerfassung bei Ausgaben
                   )

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Die folgenden Positionen dieses Budgets haben keine Auszahlungsangaben:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  -- Positionen mit BaAuszahlung-FK aber ohne Zahlweg 
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition           BPO
    LEFT OUTER JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID
  WHERE  (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Einnahmen, Ausgaben, Einzelzahlungen
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND ((BAP.KbAuszahlungsArtCode IN (101, 102) /*Elektronische Auszahlung, PapierVerfügung (nexiste pas)*/ AND BaZahlungswegID IS NULL)
         OR (BAP.BgAuszahlungsTerminCode IS NULL )
         OR (NOT EXISTS (SELECT BgAuszahlungPersonID FROM dbo.BgAuszahlungPersonTermin WITH (READUNCOMMITTED) WHERE BgAuszahlungPersonID = BAP.BgAuszahlungPersonID))
        )

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Die folgenden Positionen dieses Budgets haben keinen Auszahlungstermin oder Kreditor:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  -- Referenznummer
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition                BPO
    INNER JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BPO.BgPositionID    = BAP.BgPositionID
    INNER JOIN dbo.BaZahlungsweg      ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = BAP.BaZahlungswegID
  WHERE (BPO.Betrag - BPO.Reduktion) > 0 AND
          (BAP.ReferenzNummer IS NOT NULL AND dbo.[fnCheckReferenznummer](BAP.ReferenzNummer) = 0 OR
           (ZAL.EinzahlungsscheinCode = 1 AND BAP.ReferenzNummer IS NULL))

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Bei folgenden Positionen ist die Referenznummer ungültig:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  IF( @BgPositionID_IN IS NULL ) BEGIN -- nur für gesamtes Budget testen
    -- Zuviel Abzug vom GBL
    -- ToDo: Ev. werden hier noch nicht alle Abzüge berücksichtigt
    -- TODO SUM(Betrag) ist eigentlich falsch! Es müsste BetragBudget kontrollieren, hat aber weitere Konsequenzen --> Berechnung Abzug!
    -- siehe Ticket 4111 
    SELECT @SummeGBLAbzug = SUM(BetragBudget)
    FROM   vwBgPosition         BPO
      LEFT JOIN dbo.BgSpezkonto SPK ON SPK.BgSpezkontoID = BPO.BgSpezkontoID      
    WHERE  BgBudgetID = @BgBudgetID
      AND (BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NULL -- Einzelzahlung vom GBL
                 OR BgKategorieCode = 6 /*Vorabzüge*/
                 OR BgKategorieCode = 3 /*Abzahlung*/ AND (SPK.BgKostenartID IS NULL OR SPK.BgKostenartID = @BgKostenartIDGBL)) --Abzahlungen auf anderen Kostenarten ignorieren

    SELECT @SummeGBL = SUM(BetragBudget)
    FROM   #vwBgPosition       BPO
      LEFT JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPO.BgPositionsartID = BPA.BgPositionsartID
    WHERE  BgBudgetID = @BgBudgetID AND BPA.BgKostenartID = @BgKostenartIDGBL

    IF (@SummeGBLAbzug > @SummeGBL) BEGIN
      SET @msg = 'Es werden mehr Abzüge vom GBL gemacht als GBL bewilligt ist!' + char(13) + char(10) + ' Die Differenz beträgt CHF ' + CAST((@SummeGBLAbzug - @SummeGBL) AS varchar )
      RAISERROR ( @msg, 18, 1)
      RETURN -1
    END

    -- Zuviel Kürzungen?
    DECLARE @MaxKuerzungProzent decimal(19,1), @MaxKuerzungProPerson money
    SET @MaxKuerzungProzent = ISNULL(CONVERT(decimal(19,1), dbo.fnXConfig('System\Sozialhilfe\KuerzungMaxProzentsatz', @RefDate)), 15);
    SET @MaxKuerzungProPerson = dbo.fnShGetBetragGBL(@BgFinanzplanID, 1, 0) * @MaxKuerzungProzent / 100.0

    SELECT @Count = COUNT(*), @msg = dbo.ConcDistinct('- ' + PRS.NameVorname + ': Total Kürzungen ' + CONVERT(varchar, SummeKuerzungen) + ' Fr., erlaubt wären maximal ' + CONVERT(varchar, Erlaubt) + ' Fr.' + char(13) + char(10))
    FROM
    (
      SELECT BaPersonID, SummeKuerzungen = SUM(Betrag), Erlaubt = @MaxKuerzungProPerson
      FROM   #vwBgPosition
      WHERE  BgBudgetID = @BgBudgetID
             AND (BgKategorieCode = 4)
      GROUP BY BaPersonID
      HAVING SUM(Betrag) > @MaxKuerzungProPerson
    ) KRZ
      INNER JOIN vwPerson PRS ON PRS.BaPersonID = KRZ.BaPersonID

    IF (@Count > 0) BEGIN
      SET @msg = 'Bei folgenden Klienten überschreitet die Summe der Kürzungen die maximal erlaubten ' + convert(varchar, @MaxKuerzungProzent) + '%% vom personenbezogenen GBL:' + char(13) + char(10) + char(13) + char(10) + @msg
      RAISERROR (@msg, 18, 1)
      RETURN -1
    END

  END

  /************************************************************************************************/
  /* Check Spezialkonti                                                                           */
  /************************************************************************************************/
  IF (IsNull(@CheckSpezialkonti, 1) = 1)
  BEGIN
  -- Prüfen, ob Spezialkonti (falls benützt) genügend Deckung aufweisen
  DECLARE cSpezKonto CURSOR LOCAL FAST_FORWARD FOR
    SELECT 'Das ' + XLC.Text + ' "' + SSK.NameSpezkonto + '" weist zuwenig Deckung auf'
    FROM #vwBgPosition               BPO
--      INNER JOIN BgAuszahlungPerson  STZ ON STZ.BgPositionID   = BPO.BgPositionID
      INNER JOIN dbo.BgSpezkonto         SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID  = BPO.BgSpezkontoID
      INNER JOIN dbo.XLOVCode            XLC WITH (READUNCOMMITTED) ON XLC.LOVName        = 'BgSpezkontoTyp' AND XLC.Code = SSK.BgSpezkontoTypCode
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (101) -- Einzelzahlung
      --ToDo: AND NOT EXISTS (SELECT * FROM KbBuchung WHERE FlTypSourceCode = 105 AND IdSource = SEZ.BgAuszahlungID AND FlBelegStatusCode IN (102, 103, 106)) --verbucht(warnung)/gesperrt
      AND dbo.fnBgSpezkonto(BPO.BgSpezkontoID, 4, @BgBudgetID, default) < $0.00

    OPEN cSpezKonto
    FETCH NEXT FROM cSpezKonto INTO @msg
    IF @@FETCH_STATUS = 0 BEGIN
      RAISERROR (@msg, 18, 1)

      -- close cursor here and stop execution
      CLOSE cSpezKonto
      DEALLOCATE cSpezKonto
      RETURN -1
    END
    CLOSE cSpezKonto
    DEALLOCATE cSpezKonto
  END

  /************************************************************************************************/
  /* Buchungsperiode bestimmen                                                                    */
  /************************************************************************************************/
  -- get PeriodeID for range and if none within range, get newest open periode (BSS Klibu: KbMandantID = 1)
  SET @KbPeriodeID = dbo.fnKbGetPeriodeID(1, NULL, @BgJahr, @BgMonat, 1)

  IF (@KbPeriodeID IS NULL) BEGIN
    SET @msg = 'Es existiert keine offene Buchungsperiode, die den ' + CONVERT(varchar, @BgMonat) + '. Monat im Jahr ' + CONVERT(varchar, @BgJahr) + ' beinhaltet!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  -- Debitor-/Kreditor- und InterneVerrechnung-Konto bestimmen
  SELECT TOP 1 @KontoNrDebitor = KontoNr
  FROM   dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,20,%'

  SELECT TOP 1 @KontoNrKreditor = KontoNr
  FROM   dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes  + ',' LIKE '%,30,%'

  SELECT TOP 1 @KontoNrInterneVerrechnung = KontoNr
  FROM   dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes  + ',' LIKE '%,70,%'

  /************************************************************************************************/
  /* Monatsbudget verbuchen                                                                       */
  /************************************************************************************************/

  SELECT @BgPositionIDGBL = BgPositionID
  FROM #vwBgPosition
  WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = @BgPositionsartIDGBL

  -- Personen, Kostenstellen, NrmKonto
  DECLARE @PersonVerrechnung TABLE (
    BaPersonID            int PRIMARY KEY Clustered,
    NamePerson            varchar(200) COLLATE DATABASE_DEFAULT NOT NULL,
    KbKostenstelleID      int,
    PersonFactor          double precision
  )

  CREATE TABLE #Buchungen (
    BuchungenID           int NOT NULL IDENTITY(1, 1),
    BgPositionID          int NULL,
    BaPersonID            int NULL,
    BetragBrutto          money NULL, --!BSS
    BetragNetto           money NOT NULL,
    KbKostenstelleID      int NULL, --! BSS
    BgPositionsartID      int NULL,
    [Name]                varchar(200) COLLATE DATABASE_DEFAULT NULL,
    BgKostenartID         int NOT NULL,
    Dritte                bit NOT NULL DEFAULT (1),
    BaPersonID_Teil       int NOT NULL,
    Einnahme              bit NOT NULL DEFAULT (0),
    BgKategorieCode       int NULL,
    VerwaltungSD          bit NOT NULL DEFAULT (0),
    BgSpezkontoID         int NULL,
    KbBuchungStatusCode   int NULL,
    AuszahlGruppeID       int NULL,
    TerminFaktor          double precision NULL,
    NettoBetragProTermin  double precision NULL,
    BruttoBetragProTermin double precision NULL,
    BgSplittingArtCode    int NULL
  )
  CREATE NONCLUSTERED INDEX [IX_BaPersonID_Teil] ON [dbo].[#Buchungen] ([BaPersonID_Teil])
  CREATE NONCLUSTERED INDEX [IX_BgPositionID] ON [dbo].[#Buchungen] ([BgPositionID])


  -- Unterstützte Personen im Finanzplan
  INSERT INTO @PersonVerrechnung
    SELECT BFP.BaPersonID, PRS.NameVorname, KST.KbKostenstelleID,
           (SELECT CONVERT(double precision, 1) / COUNT(*)
            FROM  dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
            WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1
           )                  AS PersonFactor
    FROM dbo.BgFinanzplan_BaPerson   BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.vwPerson        PRS ON PRS.BaPersonID = BFP.BaPersonID
      LEFT  JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.BaPersonID = PRS.BaPersonID
                                                                       AND @FirstDayInMonth BETWEEN KST.DatumVon AND ISNULL(KST.DatumBis, '99990101')
                                                                       AND @LastDayInMonth BETWEEN KST.DatumVon AND ISNULL(KST.DatumBis, '99990101')
    WHERE BgFinanzplanID = @BgFinanzplanID AND BFP.IstUnterstuetzt = 1

  -- Sind denn überhaupt Personen im Finanzplan?
  SELECT @COUNT = COUNT(*)
  FROM   @PersonVerrechnung

  IF (@COUNT = 0) BEGIN
    SET @msg = 'Diesem Finanzplan sind keine Personen zugeordnet!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  -- Gibt es Positionen von Personen, welche nicht in diesem Finanzplan unterstützt sind?
  SELECT @Count = Count(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + PER.NameVorname + ': ' + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM #vwBgPosition              BPO
    INNER JOIN dbo.vwPerson		    PER ON PER.BaPersonID = BPO.BaPersonID
    LEFT  JOIN @PersonVerrechnung SPP ON SPP.BaPersonID = BPO.BaPersonID
  WHERE  SPP.BaPersonID IS NULL 
  AND  BPO.BetragBudget <> $0.00;

  IF (@Count > 0) BEGIN
    SET @ErrorMessage = 'Folgende Positionen betreffen Personen, welche nicht in diesem Finanzplan unterstützt sind:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg);
    RETURN -1;
  END

--select '@PersonVerrechnung', * FROM @PersonVerrechnung

  -- Buchungen (Ausgaben) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, BPO.BetragBudget   * CASE WHEN BPO.BaPersonID IS NULL OR (BKA.Quoting = 1 AND BPA.BgPositionsartCode NOT IN (32021, 32023)) THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, BPO.BetragRechnung * CASE WHEN BPO.BaPersonID IS NULL OR (BKA.Quoting = 1 AND BPA.BgPositionsartCode NOT IN (32021, 32023)) THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID, --! BSS
      BgPositionsartID     = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID),
      IsNull(BPO.Buchungstext, BPA.Name), BPA.BgKostenartID,
      Einnahme             = 0,
      BgKategorieCode      = BPO.BgKategorieCode,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      LEFT OUTER JOIN dbo.BgSpezkonto         SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung  SPP ON ((BKA.Quoting = 1 AND BPA.BgPositionsartCode NOT IN (32021, 32023)) OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                              SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                              BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE (BPO.BgKategorieCode = 2 /*Ausgaben*/ OR (BPO.BgKategorieCode = 100 /*Zusätzliche Leistung*/ AND BPO.BgBewilligungStatusCode = 5 /*bewilligt*/))
      AND (BPO.Betrag - BPO.Reduktion) > 0 AND BPO.BgSpezkontoID IS NULL
      AND BPO.BelegVorhanden = 0 /*keine verbuchten Belege*/

  -- Buchungen (Einnahmen) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, Name, BgKostenartID, Einnahme, BgKategorieCode, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.BetragBudget   * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.BetragRechnung * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID, --! BSS
      BgPositionsartID     = IsNull(BPA.BgPositionsartID,@BgPositionsartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgPositionsartID ELSE @BgPositionsartIDGBL END,
      IsNull(BPO.Buchungstext, BPA.Name),
      BgKostenartID        = IsNull(BPA.BgKostenartID, @BgKostenartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgKostenartID ELSE @BgKostenartIDGBL END,
      Einnahme             = 1,
      BgKategorieCode      = BPO.BgKategorieCode,
      VerwaltungSD         = BPO.VerwaltungSD,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = BPO.BgPositionsartID
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung  SPP ON (BKA.Quoting = 1                 OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                             SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                             BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE BPO.BgKategorieCode IN (1) --,4) /* Einnahmen, Sanktionen */
      AND ABS(BPO.Betrag - BPO.Reduktion) > 0                           -- positive und negative Einnahmen
      AND BPO.BelegVorhanden = 0          -- noch kein verbuchter Beleg

  -- Buchungen aus Einzelzahlung
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID,
      BPA.BgPositionsartID,
      IsNull(BPO.Buchungstext, IsNull('Zahlung aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = CASE WHEN BPO.BgSpezkontoID IS NULL THEN @BgKostenartIDGBL /*Einzelzahlung vom GBL*/ ELSE COALESCE(BPA.BgKostenartID, SPZ.BgKostenartID, /*ToDo*/@BgKostenartIDGBL) END,
      Einnahme             = 0,
      BPO.BgKategorieCode, BPO.BgSpezkontoID,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID       = BPO.BaPersonID OR BPO.BaPersonID IS NULL)
      LEFT OUTER JOIN dbo.BgSpezkonto         SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
    WHERE BPO.BgKategorieCode = 101 /*Einzelzahlung*/
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg

  -- Einnahmen aus Abzügen von Verrechnungs-/Abzahlungskonti
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.BetragBudget * CASE WHEN SPZ.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.BetragBudget * CASE WHEN SPZ.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID,
      SPZ.BgPositionsartID,
      IsNull(BPO.Buchungstext, IsNull('Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = CASE WHEN BPO.BgSpezkontoID IS NULL THEN @BgKostenartIDGBL /*Einzelzahlung vom GBL*/ ELSE COALESCE(SPZ.BgKostenartID, BPA.BgKostenartID, /*ToDo*/@BgKostenartIDGBL) END,
      Einnahme             = 1,
      BPO.BgKategorieCode, BPO.BgSpezkontoID,
      VerwaltungSD         = 0, -- Abzüge werden gleich behandelt wie nicht abgetretene Einkommen
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      INNER JOIN dbo.BgSpezkonto         SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID       = SPZ.BaPersonID OR SPZ.BaPersonID IS NULL)
      INNER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = SPZ.BgPositionsartID AND BPA.BgKategorieCode = BPO.BgKategorieCode
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
    WHERE BPO.BgKategorieCode IN (3 /*Abzahlung*/) --AND SPZ.OhneEinzelzahlung = 1
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg

-- select '#Buchungen', * from #Buchungen

  -- Bestimmen, ob EFB ausbezahlt wird
  IF (EXISTS(SELECT *
             FROM #Buchungen BUC
               INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BUC.BgPositionsartID
             WHERE BPA.BgGruppeCode IN (39100, 39110) /*EFB Erwerbsaufnahme*/)) BEGIN
    SET @EFBErwerbsaufnahme = 1
  END

  /************************************************************************************************/
  /* Auszahlbetrag bestimmen                                                                      */
  /************************************************************************************************/
  DECLARE @GetDate datetime
  SET @GetDate = GetDate()

  IF (@BgPositionID_IN IS NULL) BEGIN
    SELECT @TotalBetrag = SUM(IsNull(Total, -Betrag))
    FROM dbo.fnWhGetBudgetUebersicht(@BgBudgetID, @GetDate)
    WHERE Rec_ID IN (-20, -21)
  END
  ELSE BEGIN
    SELECT @TotalBetrag = SUM(Betrag)
    FROM #vwBgPosition
  END


  -- Alle Buchungen über @BuchungenID sind Netto-Buchungen (Umbuchungen)
  SELECT @BuchungenID = MAX(BuchungenID) + 1 FROM #Buchungen

  -- Zahlungen an Klient
  -- Default ist für jede Buchung eingetragen, dass sie an Dritte geht
  -- Hier wird Dritte = 0, wenn die Zahlung an einen Zahlungsweg geht, der einer unterstützten Person im Finanzplan geht
  UPDATE TMP
    SET Dritte = 0
  FROM #Buchungen                  TMP
    INNER JOIN dbo.BgAuszahlungPerson  BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID     = TMP.BgPositionID AND (BAP.BaPersonID = TMP.BaPersonID_Teil OR BAP.BaPersonID IS NULL)
    LEFT OUTER JOIN dbo.BaZahlungsweg       BZW WITH (READUNCOMMITTED) ON BZW.BaZahlungswegID  = BAP.BaZahlungswegID
    LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = TMP.BgPositionsartID
    LEFT OUTER JOIN dbo.XLOVCode            XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = BPA.BgGruppeCode
  WHERE (BZW.BaPersonID IS NULL AND BAP.KbAuszahlungsArtCode IN (103 /* Cash / Barauszahlung */, 104 /* Check */))
          OR BZW.BaPersonID IN (SELECT FPP.BaPersonID
                                FROM   dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED)
                                WHERE  FPP.BgFinanzplanID = @BgFinanzplanID AND FPP.IstUnterstuetzt = 1)
--SELECT 'Buchungen', * FROM #Buchungen

IF(@BgPositionID_IN IS NULL) BEGIN -- für Einzelposition

  -- Achtung Schönwetterprogrammierer: jetzt Augen schliessen und 20 Zeilen weiter unten wieder öffnen
  -- Dieser HACK sorgt dafür, dass das VVG gerecht vom GBL abgezogen wird
  -- Problem: In BetragBudget der GBL-BgPosition sind bereits alle VVGs abgezogen. BetragBudget wird aber wiederum von anderen Positionen benötigt, da so z.B. nicht übernommene Mieten korrekt abgehandelt werden
  ------ [Total GBL] - [Total VVG] = [BetragBudget]
  -- Deshalb werden hier zuerst die gequoteten GBL-Positionen um den Durchschnitt erhöht
  ------ [GBL P1] + [VVG Durchschnitt] = [GBL P1 temp]
  ------ [GBL P2] + [VVG Durchschnitt] = [GBL P2 temp]
  -- Danach werden die Personenbezogenen VVGs abgezogen
  ------ [GBL P1 temp] - [VVG P1] = [GBL P1 VVG-bereinigt]
  ------ [GBL P2 temp] - [VVG P2] = [GBL P2 VVG-bereinigt]
  -- voila...
  SELECT POS.BgBudgetID, POS.BaPersonID, BetragBudget = SUM(POS.BetragBudget)
  INTO #VVG
  FROM #vwBgPosition          POS
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
  WHERE POA.BgPositionsartCode IN (32021, 32022 /* VVG */, 32023 /* KVG - GBL */)
    AND POS.MaxBeitragSD = $0.00 --AND BgSpezkontoID IS NULL
  GROUP BY POS.BgBudgetID, POS.BaPersonID
--SELECT * FROM #VVG

  DECLARE @VVGDurchschnittBetrag money
  SELECT @VVGDurchschnittBetrag = SUM(BetragBudget) / COUNT(*)
  FROM @PersonVerrechnung  SPP
    LEFT JOIN #VVG         VVG ON VVG.BaPersonID = SPP.BaPersonID

  -- Korrektur Grundbedarf VVG-Abzug
  UPDATE TMP
    SET BetragBrutto = TMP.BetragBrutto - IsNull(VVG.BetragBudget, $0.00) + @VVGDurchschnittBetrag,
        BetragNetto  = TMP.BetragNetto  - IsNull(VVG.BetragBudget, $0.00) + @VVGDurchschnittBetrag
  FROM #Buchungen                  TMP
    LEFT  JOIN #VVG                VVG ON VVG.BgBudgetID = @BgBudgetID AND VVG.BaPersonID = TMP.BaPersonID_Teil
    INNER JOIN @PersonVerrechnung  SPP ON SPP.BaPersonID = TMP.BaPersonID_Teil
  WHERE @VVGDurchschnittBetrag > $0.00 AND TMP.BgPositionsartID = @BgPositionsartIDGBL

  DROP TABLE #VVG

--SELECT 'VVG - Korrektur', * FROM #Buchungen

  /************************************************************************************************/
  /* Direktabzug Kürzungen                                                                        */
  /************************************************************************************************/
  UPDATE TMP
    SET BetragBrutto = TMP.BetragBrutto - SummeKuerzungen,
        BetragNetto  = TMP.BetragNetto  - SummeKuerzungen
  FROM #Buchungen                  TMP
    INNER JOIN (SELECT BaPersonID, SummeKuerzungen = SUM(Betrag)
                FROM   #vwBgPosition
                WHERE  BgBudgetID = @BgBudgetID
                  AND (BgKategorieCode = 4)
                GROUP BY BaPersonID) KRZ ON KRZ.BaPersonID = TMP.BaPersonID_Teil
  WHERE TMP.BgPositionsartID = @BgPositionsartIDGBL


  /************************************************************************************************/
  /* Abzüge und Ausgaben an Dritte                                                                */
  /************************************************************************************************/
  DECLARE @Abzuege TABLE (
    AbzugID            int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    BgPositionID       int NULL,     -- Herkunft,    "Abzugsverursacher"
    BgPositionID_Abzug int NULL,     -- Erstes Ziel  "erstes Abzugsopfer"
    BaPersonID         int NULL,     -- gequotete Person
    BetragNetto        money NOT NULL DEFAULT($0.00),  -- gequoteter Betrag, der (noch) abgezogen wird. Bei erfolgtem Abzug wird dieser reduziert
    BetragNettoAbzug   money NOT NULL DEFAULT($0.00),  -- Hilfsfeld für direkte Abzüge (Bsp. Einkommen <-> EFB)
    BetragBrutto       money NULL DEFAULT($0.00), --BSS!
    BetragBruttoAbzug  money NOT NULL DEFAULT($0.00),
    BgKostenartID      int NULL,        -- des "Verursachers"
    Buchungstext       varchar(200) COLLATE DATABASE_DEFAULT NULL,
    BgKategorieCode    int
  )
  DECLARE @LoopCount int
  SET @LoopCount = 0
  -- Einkommen nicht vom Sozialdienst verwaltet (bewirken, dass weniger ausbezahlt wird, da der Klient das Geld direkt erhält)
  INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext, BgKategorieCode)
    SELECT BUC.BgPositionID, BUC.BaPersonID_Teil, -BUC.BetragBrutto, BUC.BgKostenartID, BUC.Name, BUC.BgKategorieCode
    FROM #Buchungen            BUC
      LEFT JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BUC.BgPositionsartID
    WHERE BUC.Einnahme = 1 /*Einnahmen*/ AND BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode IN (1, 3) /* Einnahmen, Verrechnung */

/*
SELECT 'Vor Abzug', * FROM #Buchungen
SELECT 'Vor Abzug', * FROM @Abzuege
*/
  WHILE 1 = 1 BEGIN
    SET @LoopCount = @LoopCount + 1

    -- Für nicht gequotete Einnahmen wird hier noch gequotet
    INSERT INTO @Abzuege
      SELECT ABZ.BgPositionID, ABZ.BgPositionID_Abzug, PVR.BaPersonID,
        ABZ.BetragNetto  * PVR.PersonFactor, $0.00,
        ABZ.BetragBrutto * PVR.PersonFactor, $0.00,
        ABZ.BgKostenartID, ABZ.Buchungstext, ABZ.BgKategorieCode
      FROM @Abzuege  ABZ, @PersonVerrechnung  PVR
      WHERE ABZ.BaPersonID IS NULL

    -- nicht gequotete Einträge löschen
    DELETE FROM @Abzuege WHERE BaPersonID IS NULL

    -- Bei direkt verrechenbaren Abzügen bleibt die PositionsID gleich
    UPDATE @Abzuege
      SET BgPositionID_Abzug = BgPositionID
    WHERE BgPositionID_Abzug IS NULL

    -- Abzüge direkte
    UPDATE ABZ
      SET BetragNettoAbzug  = CASE
                                WHEN TMP.Dritte = 1               THEN $0.00  -- Auszahlungen an Dritte
                                WHEN TMP.BgKategorieCode <> 2     THEN $0.00  -- Nur bei Auszahlung Direkter Abzug
                                WHEN GRP.SumBetragNetto = $0.00   THEN $0.00
                                ELSE CONVERT(money, dbo.fnMIN(ABS(GRP.SumBetragNetto), ABS(TMP.BetragNetto))) * ABZ.BetragNetto / GRP.SumBetragNetto
                              END,
          BetragBruttoAbzug = CASE
                                WHEN GRP.SumBetragBrutto = $0.00  THEN $0.00
                                ELSE CONVERT(money, dbo.fnMIN(ABS(GRP.SumBetragBrutto), ABS(TMP.BetragBrutto))) * ABZ.BetragBrutto / GRP.SumBetragBrutto
                              END
    FROM @Abzuege            ABZ
      INNER JOIN #Buchungen  TMP ON TMP.BgPositionID = ABZ.BgPositionID_Abzug AND TMP.BaPersonID_Teil = ABZ.BaPersonID
      INNER JOIN (SELECT BgPositionID_Abzug, BaPersonID,
                    SumBetragNetto = SUM(BetragNetto),
                    SumBetragBrutto = SUM(BetragBrutto)
                  FROM @Abzuege
                  GROUP BY BgPositionID_Abzug, BaPersonID
                 )           GRP ON GRP.BgPositionID_Abzug = ABZ.BgPositionID_Abzug AND GRP.BaPersonID = ABZ.BaPersonID
    WHERE TMP.Einnahme = 0 AND (GRP.SumBetragNetto > $0.00 OR GRP.SumBetragBrutto > $0.00)

    -- Abzugsursache abziehen (Bsp EFB) -> netto
    UPDATE TMP
      SET BetragNetto  = TMP.BetragNetto - CASE WHEN TMP.Dritte = 0 AND TMP.Einnahme = 0 THEN ABZ.SumBetragNettoAbzug ELSE $0.00 END,
          BetragBrutto = TMP.BetragBrutto - ABZ.SumBetragBruttoAbzug
    FROM #Buchungen  TMP
      INNER JOIN (SELECT BgPositionID_Abzug, BaPersonID,
                    SumBetragNettoAbzug = SUM(BetragNettoAbzug),
                    SumBetragBruttoAbzug = SUM(BetragBruttoAbzug)
                  FROM @Abzuege
                  WHERE BgPositionID_Abzug = BgPositionID
                  GROUP BY BgPositionID_Abzug, BaPersonID
                 )   ABZ ON ABZ.BgPositionID_Abzug = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
    WHERE TMP.BuchungenID < @BuchungenID


    -- Erstellen der Sollbuchungen für Direktabzüge
    INSERT INTO #Buchungen (BgPositionID, BgKostenartID, Name, BaPersonID_Teil, BetragBrutto, BetragNetto, KbBuchungStatusCode)
      SELECT ABZ.BgPositionID, ABZ.BgKostenartID, ABZ.Buchungstext + ' (direkt)', ABZ.BaPersonID,
        $0.00, ABZ.BetragNettoAbzug, TMP.KbBuchungStatusCode
      FROM #Buchungen          TMP
        INNER JOIN @Abzuege    ABZ ON ABZ.BgPositionID_Abzug = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
        INNER JOIN #Buchungen  HAB ON HAB.BgPositionID = ABZ.BgPositionID AND HAB.BaPersonID_Teil = ABZ.BaPersonID AND HAB.Einnahme = 0
      WHERE TMP.BuchungenID < @BuchungenID AND TMP.Dritte = 0 AND TMP.Einnahme = 0 AND ABZ.BetragNettoAbzug > $0.00
        AND ABZ.BgPositionID_Abzug <> ABZ.BgPositionID

    -- Abzugsopfer abziehen (Bsp Einkommen) -> netto
    UPDATE TMP
      SET BetragNetto  = TMP.BetragNetto  + ABZ.SumBetragNettoAbzug,
          BetragBrutto = TMP.BetragBrutto + ABZ.SumBetragBruttoAbzug
    FROM #Buchungen  TMP
      INNER JOIN (SELECT BgPositionID, BaPersonID,
                    SumBetragNettoAbzug = SUM(BetragNettoAbzug),
                    SumBetragBruttoAbzug = SUM(BetragBruttoAbzug)
                  FROM @Abzuege
                  GROUP BY BgPositionID, BaPersonID
                 )   ABZ ON ABZ.BgPositionID = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
    WHERE TMP.BuchungenID < @BuchungenID AND TMP.Einnahme = 1

/*
IF EXISTS (SELECT * FROM @Abzuege WHERE BetragNettoAbzug > $0.00 OR BetragBruttoAbzug > $0.00) BEGIN
  SELECT 'Nach Abzug Direkt, Loop: ' + CONVERT(varchar, @LoopCount), * FROM @Abzuege
  SELECT 'Nach Abzug Direkt, Loop: ' + CONVERT(varchar, @LoopCount), * FROM #Buchungen
END
*/

    UPDATE @Abzuege
      SET BgPositionID_Abzug = BgPositionID,
        BetragNetto  = BetragNetto - BetragNettoAbzug, BetragNettoAbzug = $0.00,
        BetragBrutto = BetragBrutto - BetragBruttoAbzug, BetragBruttoAbzug = $0.00


    IF @LoopCount = 1 BEGIN
      IF --1=1 OR
         IsNull(dbo.fnXConfig('System\Sozialhilfe\Belege\LineareEinkommensverteilung', @RefDate), 0) = 1 BEGIN
        -- Einkommen auf alle Ausgaben verteilen
        UPDATE @Abzuege SET BgPositionID_Abzug = NULL

        -- Ausnahmen beim Verteilen: KVG (32020), EFB(32020/32025; da bereits verrechnet), Einzelzahlungen
        SELECT BgPositionID, BaPersonID_Teil, BetragNetto
        INTO #Ausgaben
        FROM #Buchungen            TMP
          LEFT JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = TMP.BgPositionsartID
        WHERE BetragNetto > $0.00 AND Einnahme = 0
          AND BPA.BgPositionsartCode NOT IN (32020, 32121, 32122, 32123, 32124, 32125, 32126, 32127, 32128, 32129, 32130/*, 32021*/) 
          AND BPA.BgKategorieCode NOT IN (100,101) /* Keine Einzelzahlungen */
          AND BPA.BgGruppeCode NOT IN (39030, 39035) /* EFB */

        INSERT INTO @Abzuege
          SELECT ABZ.BgPositionID, TMP.BgPositionID, TMP.BaPersonID_Teil, ABZ.BetragNetto * TMP.BetragNetto / SBG.SumBetrag, $0.00, $0.00, $0.00, ABZ.BgKostenartID, ABZ.Buchungstext
          FROM #Ausgaben        TMP
            INNER JOIN @Abzuege ABZ ON ABZ.BaPersonID = TMP.BaPersonID_Teil AND ABZ.Betrag > $0.00
            INNER JOIN (SELECT BaPersonID_Teil, SUM(BetragNetto) AS SumBetrag
                        FROM #Ausgaben
                        GROUP BY BaPersonID_Teil) SBG ON SBG.BaPersonID_Teil = TMP.BaPersonID_Teil

        DROP TABLE #Ausgaben

        UPDATE @Abzuege SET BetragNetto = $0.00 WHERE BgPositionID_Abzug IS NULL
      END

      -- Einzelzahlungen von Grundbedarf
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.Betrag, BPO.Betrag, @BgKostenartIDGBL, BPO.Buchungstext + ' (finanziert vom GBL)'
        FROM #vwBgPosition BPO
        WHERE BPO.BgSpezkontoID IS NULL AND BPO.BgKategorieCode = 101 /* Einzelzahlung aus Grundbedarf */

      -- Kürzungen / Spezialkonto
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.BetragBudget, BPO.BetragBudget,
          BKA.BgKostenartID, IsNull(BSK.NameSpezkonto, BPO.Buchungstext) + IsNull( ' (' + LOV.Text + ')', '')
        FROM #vwBgPosition          BPO
          LEFT OUTER JOIN dbo.BgSpezkonto    BSK WITH (READUNCOMMITTED) ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BSK.BgPositionsartID
          LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = IsNull(BSK.BgKostenartID, @BgKostenartIDGBL)
          LEFT OUTER JOIN dbo.XLOVCode       LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'BgKategorie' AND LOV.Code = BPO.BgKategorieCode
        WHERE BPO.BgKategorieCode IN (3, /*4, */6) /* 3:Abzahlung, 4:Kürzung, 6:Vorabzug */
          AND NOT (BPO.BgKategorieCode = 3 AND IsNull(BPA.BgKategorieCode, 0) = 3 /*AND BSK.OhneEinzelzahlung = 1*/) -- Verrechnung mit Sollstellung

      -- Nicht übernommene Ausgaben 
      -- Bsp Miete 1300.- (wird dem Vermieter ausbezahlt), SD übernimmt aber nur 1000.- -> 300.- müssen sonstwo abgezogen werden werden
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.BetragRechnung - BPO.BetragBudget, BPA.BgKostenartID, BPA.Name + ' (nicht vom SD übernommen)'
        FROM #vwBgPosition           BPO
          INNER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPO.BgPositionsartID = BPA.BgPositionsartID
        WHERE BPO.BgKategorieCode = 2 /* Ausgaben */
          AND BPO.BetragRechnung > BPO.BetragBudget

      IF IsNull(dbo.fnXConfig('System\Sozialhilfe\Belege\KostendachMiete', @RefDate), 0) = 1 BEGIN
        -- Falls mehr Geld für Miete vorhanden ist als bezahlt werden soll, wird dieses Geld auf andere Miet-Abzüge (bsp Nebenkosten) verteilt (Abzüge werden reduziert)
        UPDATE TMP
          SET BetragNetto = CONVERT(money, dbo.fnMAX(TMP.BetragNetto -
            IsNull((SELECT SUM(BPO.BetragBudget - BPO.BetragRechnung)
                    FROM #vwBgPosition          BPO
                      INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3206 /* Miete */
                    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 /* Ausgaben */
                      AND BPO.BetragRechnung < BPO.BetragBudget), $0.00), $0.00))
        FROM @Abzuege               TMP
          INNER JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = TMP.BgPositionID
          INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3206  /* Miete */
      END


      -- SKOS2005 - EFB / Zulagen Limite
      -- Falls mehr Zulagen bezahlt werden sollen als die Limite erlaubt, wird die Differenz ebenfalls abgezogen
      DECLARE @SumZulage money, @Limit money

      SELECT @SumZulage = SUM(BPO.BetragBudget)
      FROM #vwBgPosition           BPO
        INNER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
      WHERE BPO.BgKategorieCode = 2
        AND BPA.BgGruppeCode BETWEEN 39000 AND 39999 /* EFB, IZU, MIZ */

      IF @SumZulage > $0.00 BEGIN
        SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
        FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
        WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KNZ)
        ORDER BY CFG.Child DESC

        IF @SumZulage > @Limit BEGIN
          INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto)
            SELECT BPO.BgPositionID, BPO.BaPersonID,
              BPO.BetragBudget - (BPO.BetragBudget * @Limit / @SumZulage),
              BPO.BetragBudget - (BPO.BetragBudget * @Limit / @SumZulage)
            FROM #vwBgPosition  BPO
              INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
            WHERE BPO.BgKategorieCode = 2 -- Ausgaben
              AND BPA.BgGruppeCode BETWEEN 39000 AND 39999 /* EFB, IZU, MIZ */
        END
      END
    END ELSE
      BREAK
  END

/*
SELECT 'Ende Abzug Direkt', * FROM @Abzuege
SELECT 'Ende Abzug Direkt', * FROM #Buchungen
*/

  -- Abzüge von GB
  DECLARE @AbzugBetragNetto         money,
          @AbzugBetragBrutto        money,
          @AbzugFactorNetto         double precision,
          @AbzugFactorBrutto        double precision

  DECLARE @BaPersonID               int,
          @BgKostenartID            int,
          @BgPositionsartID         int,

          @BgPositionID             int,
          @AbzugGruppeBetragNetto   money,
          @AbzugGruppeNettoGleich   bit,
          @AbzugGruppeBetragBrutto  money,
          @AbzugGruppeBruttoGleich  bit,
          @AbzugGruppeCount         int,

          @AbzBgPositionID          int,
          @AbzBaPersonID            int,
          @AbzBetragNetto           money,
          @AbzBetragBrutto          money,
          @AbzBgKostenartID         int,
          @AbzBuchungstext          varchar(200)


-- Negative Einkommen dem GBL dazuzählen
-- HACK, eigentlich sollte das auch über die Schlaufen gleich unten funktionieren...
  DECLARE @SummeNegEinkommen money, @SummeGejoined money

  SELECT @SummeNegEinkommen = SUM(BetragNetto)
  FROM @Abzuege
  WHERE BetragNetto < $0.00

  SELECT @SummeGejoined = SUM(ABZ.BetragNetto)
  FROM @Abzuege           ABZ
    INNER JOIN #Buchungen BUC ON BUC.BgPositionID = @BgPositionIDGBL AND BUC.BaPersonID_Teil = ABZ.BaPersonID
  WHERE ABZ.BetragNetto < $0.00

  IF ( @SummeGejoined <> @SummeNegEinkommen ) BEGIN
    SET @msg = 'Die negativen gequoteten Einkommen können nicht entsprechenden GBL-Position zugeordnet werden'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

  -- GBL erhöhen
  UPDATE BUC
  SET BUC.BetragNetto = BUC.BetragNetto - ABZ.BetragNetto
  FROM #Buchungen       BUC
    INNER JOIN (SELECT BaPersonID, BetragNetto = SUM(BetragNetto) FROM @Abzuege WHERE BetragNetto < $0.00 GROUP BY BaPersonID ) ABZ ON BUC.BgPositionID = @BgPositionIDGBL AND BUC.BaPersonID_Teil = ABZ.BaPersonID
  WHERE ABZ.BetragNetto < $0.00

  -- Buchung kurzen, die den Abzug verursacht hat (negatives Einkommen)
  UPDATE BUC
  SET BUC.BetragNetto = BUC.BetragNetto + ABZ.BetragNetto
  FROM #Buchungen       BUC
    INNER JOIN @Abzuege ABZ ON ABZ.BgPositionID = BUC.BgPositionID AND ABZ.BaPersonID = BUC.BaPersonID_Teil
  WHERE ABZ.BetragNetto < $0.00

  -- Abzüge leeren
  UPDATE @Abzuege
  SET BetragNetto = $0.00
  WHERE BetragNetto < $0.00

/*
SELECT '#Buchungen', * FROM #Buchungen
SELECT '@Abzuege', * FROM @Abzuege

    SELECT 'cAbzugNetto', BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragNetto) > $0.01
    ORDER BY BgKostenartID, BaPersonID

    SELECT 'cAbzugBrutto', BaPersonID, BetragBrutto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragBrutto) > $0.01
    ORDER BY BgKostenartID, BaPersonID
*/

  DECLARE cAbzugNetto CURSOR LOCAL FOR
    SELECT BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragNetto) > $0.01
    ORDER BY BgKostenartID, BaPersonID
    FOR UPDATE OF BetragNetto

  DECLARE cAbzugBrutto CURSOR LOCAL FOR
    SELECT BgPositionID, BaPersonID, BetragBrutto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragBrutto) > $0.01
    ORDER BY BgKostenartID, BaPersonID
    FOR UPDATE OF BetragBrutto

  SET @LoopCount = 0
  WHILE @LoopCount < 6 BEGIN
    SET @LoopCount = @LoopCount + 1

-- Reihenfolgen: 1,2(Person/Kostenart), 3,4(Person), 5,6(Finanzplan)
/* -- DEBUG
      SELECT * FROM #Buchungen

      SELECT * FROM @Abzuege
      ORDER BY BgKostenartID, BaPersonID

      SELECT LoopCount = @LoopCount,
        BaPersonID = CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END,
        TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END,
        SUM(TMP.BetragBrutto), CASE WHEN MIN(TMP.BetragBrutto) = MAX(TMP.BetragBrutto) THEN 1 ELSE 0 END
      FROM #Buchungen  TMP
        LEFT  JOIN WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT  JOIN XLOVCode         XLC ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE Einnahme = 0
        AND (@LoopCount % 2 = 0 OR TMP.Dritte = 0) AND (@LoopCount IN (3, 4, 5, 6) OR TMP.BgKategorieCode NOT IN (100, 101))
      GROUP BY CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN TMP.BgKategorieCode ELSE 1 END   -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                           -- KVG / VVG als letzte BgPosition kürzen
         , MIN(CASE WHEN @LoopCount <= 2 THEN TMP.BgKostenartID ELSE 0 END)
         , MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 3900 AND 3999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(SPT.SortKey) DESC
         , CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END
-- */

    DECLARE cBuchung CURSOR LOCAL FAST_FORWARD FOR
      SELECT
        BaPersonID = CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END,
        TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END,
        SUM(TMP.BetragBrutto), CASE WHEN MIN(TMP.BetragBrutto) = MAX(TMP.BetragBrutto) THEN 1 ELSE 0 END
      FROM #Buchungen               TMP
        LEFT OUTER JOIN dbo.WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT OUTER JOIN dbo.XLOVCode         XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE Einnahme = 0
        AND (@LoopCount % 2 = 0 OR TMP.Dritte = 0) AND (@LoopCount IN (3, 4, 5, 6) OR TMP.BgKategorieCode NOT IN (100, 101))
      GROUP BY CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN TMP.BgKategorieCode ELSE 1 END   -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                           -- KVG / VVG als letzte BgPosition kürzen
         , MIN(CASE WHEN @LoopCount <= 2 THEN TMP.BgKostenartID ELSE 0 END)
         --, MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 39000 AND 39999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen, #8492: SKOS-Zulagen werden erst nach GBL gekürzt
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(IsNull(SPT.SortKey, 0)) DESC
         , CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END

    OPEN cBuchung
    OPEN cAbzugNetto
    OPEN cAbzugBrutto
    SELECT @AbzBetragNetto  = $0.00, @AbzugGruppeBetragNetto  = $0.00, @AbzugFactorNetto  = 1,
           @AbzBetragBrutto = $0.00, @AbzugGruppeBetragBrutto = $0.00, @AbzugFactorBrutto = 1

    WHILE 1 = 1 BEGIN
      IF NOT EXISTS (SELECT * FROM @Abzuege
                     WHERE (@LoopCount % 2 = 1 AND ABS(BetragNetto) > $0.01) OR (@LoopCount % 2 = 0 AND ABS(BetragBrutto) > $0.01)) BEGIN
        BREAK
      END

      IF ((@LoopCount % 2 = 1 AND ABS(@AbzugGruppeBetragNetto) <= $0.01) OR (@LoopCount % 2 = 0 AND ABS(@AbzugGruppeBetragBrutto) <= $0.01)) BEGIN
        SELECT @AbzBetragNetto = $0.00, @AbzBetragBrutto = $0.00
        FETCH NEXT FROM cBuchung INTO @BaPersonID, @BgKostenartID, @BgPositionsartID, @BgPositionID, @AbzugGruppeCount,
          @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich, @AbzugGruppeBetragBrutto, @AbzugGruppeBruttoGleich
        IF @@FETCH_STATUS < 0 BREAK
-- SELECT 'cBuchung', @BaPersonID, @BgKostenartID, @BgPositionsartID, @BgPositionID, @AbzugGruppeCount, @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich, @AbzugGruppeBetragBrutto, @AbzugGruppeBruttoGleich
      END

      IF (@LoopCount % 2 = 1) BEGIN  -- Netto
        IF (@AbzBetragNetto <= $0.01) BEGIN
          CLOSE cAbzugNetto
          OPEN cAbzugNetto

          WHILE 1 = 1 BEGIN
            FETCH NEXT FROM cAbzugNetto INTO @AbzBgPositionID, @AbzBaPersonID, @AbzBetragNetto, @AbzBgKostenartID, @AbzBuchungstext
            IF @@FETCH_STATUS < 0 BREAK
            IF (ABS(@AbzBetragNetto) > $0.01
                 AND (@AbzBgKostenartID = @BgKostenartID OR @LoopCount > 2)
                 AND (@AbzBaPersonID    = @BaPersonID    OR @LoopCount > 4)) BEGIN
-- SELECT 'cAbzugNetto', @AbzBetragNetto, @BgPositionID, @AbzBaPersonID, @BaPersonID, @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich
              BREAK
            END
          END
          IF @@FETCH_STATUS < 0 BEGIN
            SET @AbzugGruppeBetragNetto = $0.00
            CONTINUE
          END
        END

        IF @AbzBetragNetto <= @AbzugGruppeBetragNetto BEGIN
          SELECT @AbzugBetragNetto = @AbzBetragNetto,
                 @AbzugBetragBrutto = $0.00,
                 @AbzugFactorNetto = CONVERT(double precision, (@AbzugGruppeBetragNetto - @AbzBetragNetto)) / @AbzugGruppeBetragNetto,
                 @AbzugFactorBrutto = 1,
                 @AbzBetragNetto = $0.00
        END ELSE BEGIN
          SELECT @AbzugBetragNetto = @AbzugGruppeBetragNetto,
                 @AbzugBetragBrutto = $0.00,
                 @AbzugFactorNetto = 0,
                 @AbzugFactorBrutto = 1,
                 @AbzBetragNetto = @AbzBetragNetto - @AbzugGruppeBetragNetto
        END

        UPDATE @Abzuege
          SET BetragNetto = @AbzBetragNetto
        WHERE CURRENT OF cAbzugNetto
      END ELSE BEGIN -- Brutto
        IF (@AbzBetragBrutto <= $0.01) BEGIN
          CLOSE cAbzugBrutto
          OPEN cAbzugBrutto

          WHILE 1 = 1 BEGIN
            FETCH NEXT FROM cAbzugBrutto INTO @AbzBgPositionID, @AbzBaPersonID, @AbzBetragBrutto, @AbzBgKostenartID, @AbzBuchungstext
            IF @@FETCH_STATUS < 0 BREAK
            IF (ABS(@AbzBetragBrutto) > $0.01
                 AND (@AbzBgKostenartID = @BgKostenartID OR @LoopCount > 2)
                 AND (@AbzBaPersonID    = @BaPersonID    OR @LoopCount > 4)) BEGIN
-- SELECT 'cAbzugBrutto', @AbzBgPositionID, @AbzBaPersonID, @AbzBetragBrutto, @AbzBgKostenartID, @AbzBuchungstext
              BREAK
            END
          END
          IF @@FETCH_STATUS < 0 BEGIN
            SET @AbzugGruppeBetragBrutto = $0.00
            CONTINUE
          END
        END

        IF @AbzBetragBrutto <= @AbzugGruppeBetragBrutto BEGIN
          SELECT @AbzugBetragNetto = $0.00,
                 @AbzugBetragBrutto = @AbzBetragBrutto,
                 @AbzugFactorNetto = 1,
                 @AbzugFactorBrutto = CONVERT(double precision, (@AbzugGruppeBetragBrutto - @AbzBetragBrutto)) / @AbzugGruppeBetragBrutto,
                 @AbzBetragBrutto = $0.00
        END ELSE BEGIN
          SELECT @AbzugBetragNetto = $0.00,
                 @AbzugBetragBrutto = @AbzugGruppeBetragBrutto,
                 @AbzugFactorNetto = 1,
                 @AbzugFactorBrutto = 0,
                 @AbzBetragBrutto = @AbzBetragBrutto - @AbzugGruppeBetragBrutto
        END

        UPDATE @Abzuege
          SET BetragBrutto = @AbzBetragBrutto
        WHERE CURRENT OF cAbzugBrutto
      END

      DECLARE @Buchung TABLE (
        BuchungenID_SOLL   int,
        BuchungenID_HABEN  int,
        BetragNetto        money,
        BetragBrutto       money)

      DELETE FROM @Buchung

      INSERT INTO @Buchung
        SELECT SOL.BuchungenID, HAB.BuchungenID,
          CASE WHEN @AbzugGruppeNettoGleich  = 1 THEN (@AbzugBetragNetto  / @AbzugGruppeCount) ELSE (-@AbzugFactorNetto  + 1) * SOL.BetragNetto END,
          CASE WHEN @AbzugGruppeBruttoGleich = 1 THEN (@AbzugBetragBrutto / @AbzugGruppeCount) ELSE (-@AbzugFactorBrutto + 1) * SOL.BetragBrutto END
        FROM #Buchungen         SOL
          LEFT  JOIN #Buchungen HAB ON HAB.BgPositionID = @AbzBgPositionID AND HAB.BaPersonID_Teil = @AbzBaPersonID
                                   AND HAB.BuchungenID < @BuchungenID AND (SIGN(SOL.BetragNetto) = SIGN(HAB.BetragNetto) OR HAB.VerwaltungSD = 0)
        WHERE (IsNull(SOL.BgPositionsartID, 0) = IsNull(@BgPositionsartID, 0) AND IsNull(SOL.BgPositionID, 0) = IsNull(@BgPositionID, 0))
          AND SOL.BaPersonID_Teil = IsNull(@BaPersonID, SOL.BaPersonID_Teil) AND (@LoopCount % 2 = 0 OR SOL.Dritte = 0)

      DELETE FROM @Buchung WHERE BetragNetto = $0.00 AND BetragBrutto = $0.00

/*
IF EXISTS (SELECT * FROM @Buchung)
  SELECT '@Buchung', LoopCount = @LoopCount, AbzugBetragNetto = @AbzugBetragNetto, AbzugBetragBrutto = @AbzugBetragBrutto,
    TMP.*, @AbzBuchungstext, SOL.*, HAB.*
  FROM @Buchung           TMP
    LEFT JOIN #Buchungen  SOL ON SOL.BuchungenID = BuchungenID_SOLL
    LEFT JOIN #Buchungen  HAB ON HAB.BuchungenID = BuchungenID_Haben
*/
      UPDATE BUC
        SET BetragNetto  = BUC.BetragNetto  - TMP.BetragNetto,
            BetragBrutto = BUC.BetragBrutto - TMP.BetragBrutto
      FROM #Buchungen        BUC
        INNER JOIN (SELECT BuchungenID_SOLL, BetragNetto = SUM(BetragNetto), BetragBrutto = SUM(BetragBrutto)
                    FROM @Buchung B
                    GROUP BY BuchungenID_SOLL) TMP ON TMP.BuchungenID_SOLL = BUC.BuchungenID

      UPDATE BUC
        SET BetragNetto  = BUC.BetragNetto  - (TMP.BetragNetto  * SIGN(BUC.BetragNetto)),
            BetragBrutto = BUC.BetragBrutto - (TMP.BetragBrutto * SIGN(BUC.BetragBrutto))
      FROM #Buchungen        BUC
        INNER JOIN (SELECT BuchungenID_HABEN, BetragNetto = SUM(BetragNetto), BetragBrutto = SUM(BetragBrutto)
                    FROM @Buchung B
                    GROUP BY BuchungenID_HABEN) TMP ON TMP.BuchungenID_HABEN = BUC.BuchungenID

      INSERT INTO #Buchungen (BgKategorieCode, BgPositionID, BgKostenartID, Name, BaPersonID_Teil, BetragBrutto, BetragNetto, KbBuchungStatusCode)
        SELECT SOL.BgKategorieCode, HAB.BgPositionID, SOL.BgKostenartID, @AbzBuchungstext, SOL.BaPersonID_Teil, TMP.BetragBrutto, TMP.BetragNetto, SOL.KbBuchungStatusCode
        FROM #Buchungen         SOL
          INNER JOIN @Buchung   TMP ON TMP.BuchungenID_SOLL = SOL.BuchungenID
          INNER JOIN #Buchungen HAB ON HAB.BuchungenID = BuchungenID_HABEN
        WHERE HAB.Einnahme = 0

--

/*
      INSERT INTO #Buchungen (BgPositionID, BgKostenartID, Name, BaPersonID_Teil,BgAuszahlungID, BetragBrutto, BetragNetto)
        SELECT @AbzBgPositionID, @AbzBgKostenartID, @AbzBuchungstext, BaPersonID_Teil, TMP.BgAuszahlungID,
          $0.00, CASE WHEN @AbzugGruppeBetragGleich = 1 THEN (@AbzugBetrag / @AbzugGruppeCount) ELSE (-@AbzugFactor + 1) * TMP.BetragNetto END
        FROM #Buchungen      TMP
        WHERE (IsNull(TMP.BgPositionsartID, 0) = IsNull(@BgPositionsartID, 0) AND IsNull(TMP.BgPositionID, 0) = IsNull(@BgPositionID, 0))
          AND TMP.BaPersonID_Teil = IsNull(@BaPersonID, TMP.BaPersonID_Teil) AND TMP.Dritte = 0
*/


      SELECT @AbzugGruppeBetragNetto  = @AbzugGruppeBetragNetto  - @AbzugBetragNetto,
             @AbzugGruppeBetragBrutto = @AbzugGruppeBetragBrutto - @AbzugBetragBrutto

      IF (@LoopCount % 2 = 1) BEGIN  -- Netto
        UPDATE @Abzuege
          SET BetragNetto = @AbzBetragNetto
        WHERE CURRENT OF cAbzugNetto
        SET @AbzBetragNetto  = $0.00
      END ELSE BEGIN
        UPDATE @Abzuege
          SET BetragBrutto = @AbzBetragBrutto
        WHERE CURRENT OF cAbzugBrutto
        SET @AbzBetragBrutto = $0.00
      END
    END

    DEALLOCATE cBuchung
    CLOSE cAbzugNetto
    CLOSE cAbzugBrutto
  END
  DEALLOCATE cAbzugNetto
  DEALLOCATE cAbzugBrutto

/*
SELECT *
FROM #Buchungen
ORDER BY BaPersonID_Teil, BuchungenID

SELECT '@Abzuege', * FROM @Abzuege

SELECT Brutto=SUM(BetragBrutto),Netto=SUM(BetragNetto) FROM #Buchungen /*where einnahme = 0 OR VerwaltungSD = 1*/ GROUP BY BgPositionID

SELECT Brutto=SUM(BetragBrutto),Netto=SUM(BetragNetto), diff=SUM(BetragBrutto)-SUM(BetragNetto)  FROM #Buchungen /*where einnahme = 0 OR VerwaltungSD = 1*/
*/
END -- IF(@BgPositionID_IN) -- für Einzelposition


  -- Runden
  DECLARE @BuchungenIDRunden        int,
          @BetragBrutto             money,
          @BetragNetto              money,
          @BetragBruttoRound        money,
          @BetragNettoRound         money,
          @RundungsdifferenzBrutto  money,
          @RundungsdifferenzNetto   money
--@SummeZahlungsmodus int


  SET @RundungsdifferenzBrutto = $0.00
  SET @RundungsdifferenzNetto = $0.00

  DECLARE cBuchungRunden CURSOR LOCAL FOR
    SELECT BuchungenID, BetragBrutto, BetragNetto
    FROM #Buchungen
    ORDER BY Einnahme, BgKostenartID, BgPositionID

  OPEN cBuchungRunden
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cBuchungRunden INTO @BuchungenIDRunden, @BetragBrutto, @BetragNetto
    IF @@FETCH_STATUS < 0 BREAK

    SET @BetragBruttoRound       = FLOOR((@BetragBrutto + @RundungsdifferenzBrutto) * 20.0 + 0.5) / 20.0
    SET @BetragNettoRound        = FLOOR((@BetragNetto + @RundungsdifferenzNetto) * 20.0 + 0.5) / 20.0
    SET @RundungsdifferenzBrutto = @BetragBrutto + @RundungsdifferenzBrutto - @BetragBruttoRound
    SET @RundungsdifferenzNetto  = @BetragNetto + @RundungsdifferenzNetto - @BetragNettoRound
    --SET @SummeZahlungsmodus      = @SummeZahlungsmodus + @BetragNettoRound

    UPDATE #Buchungen SET BetragBrutto = @BetragBruttoRound, BetragNetto = @BetragNettoRound
    WHERE BuchungenID = @BuchungenIDRunden

  END
  CLOSE cBuchungRunden
  DEALLOCATE cBuchungRunden

/* --
SELECT sumbet = (SELECT SUM(BetragNetto) FROM #Buchungen), *
FROM #Buchungen
ORDER BY BaPersonID_Teil, BuchungenID
-- */

  /************************************************************************************************/
  /* Beträge plausibilisieren                                                                     */
  /************************************************************************************************/
  IF EXISTS (SELECT * FROM @Abzuege WHERE BetragNetto > $0.01) BEGIN
    SET @msg = 'Der Auszahlungsbetrag an den Klienten beträgt:' + CHAR(13)  + CHAR(10) + ' -' + LTrim(STR((SELECT SUM(BetragNetto) FROM @Abzuege), 10, 2)) + ' sFr.'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

--SELECT Diff = ABS(SUM(BetragBrutto) - SUM(BetragNetto)), Brutto = SUM(BetragBrutto), Netto = SUM(BetragNetto) FROM #Buchungen

  SELECT @Diff = ABS(SUM(BetragBrutto) - SUM(BetragNetto)) FROM #Buchungen
  IF @Diff > $0.05 BEGIN
    SET @msg = 'Die Summe der Bruttobeträge entspricht nicht der Summe der Nettobeträge! Die Differenz beträgt ' + CONVERT(varchar,@Diff) + 'CHF'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

--return
/*
select *
from #Buchungen

select *
from @Abzuege 
select sum(betrag) from @Abzuege
*/
--return

/*
  DELETE TMP
  FROM #Buchungen  TMP
    INNER JOIN (SELECT BgAuszahlungID_EZ, SUM(BetragNetto) AS BetragSumme
                FROM #Buchungen GROUP BY BgAuszahlungID_EZ
               )   EZ  ON EZ.BgAuszahlungID_EZ = TMP.BgAuszahlungID_EZ
  WHERE EZ.BetragSumme = (SELECT SUM(Betrag) FROM ShEinzelzahlung WHERE BgAuszahlungID = TMP.BgAuszahlungID_EZ)
*/

  /************************************************************************************************/
  /* Belege verbuchen                                                                             */
  /************************************************************************************************/

  -- Faktor bestimmen für Aufteilung eines Betrages auf mehrere Auszahlungen (Bsp. 4 Termine -> Faktor 0.25)
  UPDATE BUC
  SET TerminFaktor = TMP.Faktor, NettoBetragProTermin = TMP.Faktor * BetragNetto, BruttoBetragProTermin = TMP.Faktor * BetragBrutto
  FROM #Buchungen BUC
    INNER JOIN (SELECT BgPositionID, Faktor = CONVERT(DOUBLE PRECISION, 1.0) / COUNT(*), BAP.BaPersonID
                FROM dbo.BgAuszahlungPerson               BAP WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BgAuszahlungPersonTermin BPT WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = BPT.BgAuszahlungPersonID
                GROUP BY BgPositionID, BAP.BaPersonID) TMP ON TMP.BgPositionID = BUC.BgPositionID AND IsNull(TMP.BaPersonID, BUC.BaPersonID_Teil) = BUC.BaPersonID_Teil


/*

select * FROM #Buchungen 

  SELECT BUC.BgPositionID, BUC.BetragNetto, TerminFaktor = TMP.Faktor, NettoBetragProTermin = BetragNetto * TMP.Faktor, BruttoBetragProTermin = BetragBrutto * TMP.Faktor
  FROM #Buchungen BUC
    INNER JOIN (SELECT BgPositionID, Faktor = 1.0 / Count(*), BAP.BaPersonID
                FROM BgAuszahlungPerson               BAP
                  INNER JOIN BgAuszahlungPersonTermin BPT ON BAP.BgAuszahlungPersonID = BPT.BgAuszahlungPersonID
                GROUP BY BgPositionID, BAP.BaPersonID) TMP ON TMP.BgPositionID = BUC.BgPositionID AND IsNull(TMP.BaPersonID, BUC.BaPersonID_Teil) = BUC.BaPersonID_Teil
  SELECT BUC.BgPositionID, BUC.BetragNetto, TerminFaktor = TMP.Faktor, NettoBetragProTermin = BetragNetto * TMP.Faktor, BruttoBetragProTermin = BetragBrutto * TMP.Faktor
  FROM #Buchungen BUC
    INNER JOIN (SELECT BgPositionID, Faktor = 1.0 / Count(*)
                FROM BgAuszahlungPerson               BAP
                  INNER JOIN BgAuszahlungPersonTermin BPT ON BAP.BgAuszahlungPersonID = BPT.BgAuszahlungPersonID
                GROUP BY BgPositionID) TMP ON TMP.BgPositionID = BUC.BgPositionID --AND IsNull(TMP.BaPersonID, BUC.BaPersonID_Teil) = BUC.BaPersonID_Teil
*/

  /************************************************************************************************/
  /* Temporäre (Netto-)Tabellen erstellen                                                         */
  /************************************************************************************************/
  DECLARE @KbBuchung TABLE(
  [KbBuchungID] [int] IDENTITY(1,1) NOT NULL,
  [KbPeriodeID] [int] NOT NULL,
  [IkPositionID] [int] NULL,
  [KbBuchungTypCode] [int] NOT NULL,
  [Code] [varchar](10) NULL,
  [BelegNr] [bigint] NULL,
  [BelegDatum] [datetime] NULL,
  [ValutaDatum] [datetime] NULL,
  [TransferDatum] [datetime] NULL,
  [Betrag] [money] NOT NULL,
  [Text] [varchar](200) NOT NULL,
  [KbBuchungStatusCode] [int] NULL,
  [SollKtoNr] [varchar](10) NULL,
  [HabenKtoNr] [varchar](10) NULL,
  [KbZahlungseingangID] [int] NULL,
  [BaZahlungswegID] [int] NULL,
  [KbAuszahlungsArtCode] [int] NULL,
  [PCKontoNr] [varchar](50) NULL,
  [BaBankID] [int] NULL,
  [BankKontoNr] [varchar](50) NULL,
  [IBAN] [varchar](50) NULL,
  [ReferenzNummer] [varchar](50) NULL,
  [Zahlungsgrund] [varchar](200) NULL,
  [MitteilungZeile1] [varchar](35) NULL,
  [MitteilungZeile2] [varchar](35) NULL,
  [MitteilungZeile3] [varchar](35) NULL,
  [MitteilungZeile4] [varchar](35) NULL,
  [BeguenstigtName] [varchar](100) NULL,
  [BeguenstigtName2] [varchar](200) NULL,
  [BeguenstigtStrasse] [varchar](100) NULL,
  [BeguenstigtHausNr] [varchar](10) NULL,
  [BeguenstigtPostfach] [varchar](40) NULL,
  [BeguenstigtOrt] [varchar](100) NULL,
  [BeguenstigtPLZ] [varchar](10) NULL,
  [BeguenstigtLandCode] [int] NULL,
  [BgBudgetID] [int] NULL,
  [BarbelegUserID] [int] NULL,
  [BarbelegDatum] [datetime] NULL,
  [CashOrCheckAm] [datetime] NULL,
  [PscdZahlwegArt] [char](1) NULL,
  [PscdFehlermeldung] [varchar](200) NULL,
  [StorniertKbBuchungID] [int] NULL,
  [Schuldner_BaInstitutionID] [int] NULL,
  [Schuldner_BaPersonID] [int] NULL,
  [ModulID] [int] NULL,
  [KbForderungIstSH] [bit] NULL,
  --!BSS [KbKostenstelleID] [int] NULL,
  [BankName] [varchar](70) NULL,
  [BankStrasse] [varchar](50) NULL,
  [BankPLZ] [varchar](10) NULL,
  [BankOrt] [varchar](60) NULL,
  [BankBCN] [varchar](10) NULL,
  [ErstelltUserID] [int] NULL,
  [ErstelltDatum] [datetime] NOT NULL DEFAULT(GetDate()), --! BSS
  [MutiertUserID] [int] NULL,
  [MutiertDatum] [datetime] NULL,
    [FaLeistungID] [int] NULL
)

DECLARE @KbBuchungKostenart TABLE
(
  [KbBuchungKostenartID] [int] IDENTITY(1,1) NOT NULL,
  [KbBuchungID] [int] NOT NULL,
  [BgPositionID] [int] NULL,
  [BgKostenartID] [int] NULL,
  [BaPersonID] [int] NULL,
  [Buchungstext] [varchar](200) NULL,
  [Betrag] [money] NOT NULL,
  [KontoNr] [varchar](50) NULL,
  [PositionImBeleg] [int] NULL,
  [Hauptvorgang] [int] NULL,
  [Teilvorgang] [int] NULL,
  [Belegart] [varchar](4) NULL,
  [KbForderungArtCode] [int] NULL,
  [VerwPeriodeVon] [datetime] NULL,
  [VerwPeriodeBis] [datetime] NULL,
    [KbKostenstelleID] [int] NULL, --! BSS
    [BgSplittingArtCode] [int] NULL, -- ! BSS
  [Weiterverrechenbar] [bit] NOT NULL DEFAULT (0), -- ! BSS
  [Quoting] [bit] NOT NULL DEFAULT (0) -- ! BSS
)

  /************************************************************************************************/
  /* Nettobelege verbuchen                                                                        */
  /************************************************************************************************/
/*
SELECT * FROM #Buchungen

  SELECT AuszahlBetrag = SUM(IsNull(BUC.NettoBetragProTermin,BUC.BetragNetto)), BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, Datum = IsNull(BAT.Datum,POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode, BAP.BaZahlungswegID, BAP.ReferenzNummer, Zahlungsgrund = NULL,/*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode
    FROM #Buchungen                      BUC
      LEFT JOIN BgPosition               POS ON POS.BgPositionID = BUC.BgPositionID
      LEFT JOIN BgAuszahlungPerson       BAP ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT JOIN BgAuszahlungPersonTermin BAT ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
    WHERE ABS(BUC.BetragNetto) > $0.00
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.KbKostenstelleID, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, BAP.BaZahlungswegID, IsNull(BAT.Datum,POS.FaelligAm), BAP.KbAuszahlungsArtCode, BUC.TerminFaktor, BAP.ReferenzNummer, /*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode, BUC.AuszahlGruppeID
    ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID
*/
  SELECT
    AuszahlungID = IDENTITY(int, 1, 1),
    AuszahlBetrag = SUM(IsNull(CONVERT(MONEY,BUC.NettoBetragProTermin), BUC.BetragNetto)),
    BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.KbKostenstelleID, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme,
    Datum = IsNull(BAT.Datum, POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode, BAP.BaZahlungswegID, BAP.ReferenzNummer,
    Zahlungsgrund = NULL,/*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode,
    BAP.MitteilungZeile1, BAP.MitteilungZeile2, BAP.MitteilungZeile3, BAP.MitteilungZeile4
  INTO #NettoAuszahlungen
  FROM #Buchungen                      BUC
    LEFT JOIN #vwBgPosition            POS ON POS.BgPositionID = BUC.BgPositionID
    LEFT JOIN dbo.BgAuszahlungPerson       BAP WITH (READUNCOMMITTED) ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
    LEFT JOIN dbo.BgAuszahlungPersonTermin BAT WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
  --WHERE ABS(BUC.BetragNetto) > $0.01
  GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.KbKostenstelleID, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme,
    IsNull(BAT.Datum, POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode,  BAP.BaZahlungswegID, BAP.ReferenzNummer,
    /*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode,
    BUC.AuszahlGruppeID, BAP.MitteilungZeile1, BAP.MitteilungZeile2, BAP.MitteilungZeile3, BAP.MitteilungZeile4
  ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID


  -- Check Zahlungsweg:
  --  IBAN
/*
--!BSS nocheck
  SELECT @COUNT = COUNT(*)
  FROM #NettoAuszahlungen    AUZ
    INNER JOIN BaZahlungsweg ZAL ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
  WHERE  IBANNummer IS NULL AND EinzahlungsscheinCode IN (2,3,5)

  IF @COUNT > 0 BEGIN
    SET @msg = 'Nicht alle verwendeten Zahlungswege haben eine IBAN. Die IBAN ist zwingend, um Auszahlungen zu machen. Tragen sie bitte die IBAN in den Basisdaten bzw im Institutionenstamm ein.'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END
*/
  --  Gültigkeit
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + POS.Buchungstext + ' (Betrag: ' + CONVERT(varchar, POS.Betrag) + '), Valuta: ' + CONVERT(varchar, AUZ.Datum, 104) + ', Gültigkeit: ' + IsNull(CONVERT(varchar, ZAL.DatumVon, 104), '-') + ' bis ' + IsNull(CONVERT(varchar, ZAL.DatumBis, 104), '-'))
  FROM #NettoAuszahlungen    AUZ
    INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
    INNER JOIN dbo.BgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = AUZ.BgPositionID
  WHERE  AUZ.Datum NOT BETWEEN ZAL.DatumVon AND ZAL.DatumBis

  IF @COUNT > 0 BEGIN
    SET @ErrorMessage = 'Folgende Positionen haben ein Valutadatum, welches ausserhalb des Gültigkeitszeitraums des Zahlungswegs liegt. Überprüfen Sie bitte die Gültigkeit der verwendeten Zahlungswege:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg);
    RETURN -1
  END

--select Referenzsumme = @TotalBetrag, Auszahlsumme = (SUM(AuszahlBetrag)) FROM #NettoAuszahlungen
/*
  SELECT @Diff = ABS(ABS(SUM(AuszahlBetrag)) - ABS(@TotalBetrag)) FROM #NettoAuszahlungen
  IF @Diff > $0.05 BEGIN
    SET @msg = 'Die Summe der auszuzahlenden Beträge wurde falsch berechnet! Der Fehler der Summe der Nettobeträge beträgt ' + CONVERT(varchar,@Diff) + 'CHF'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END
*/
  -- Runden
  DECLARE @BaPersonID_Teil  int,
          @AuszahlungID     int,
          @BelegBetrag      money,
          @AuszahlBetrag    money


  SET @BetragNettoRound = $0.00
  SET @RundungsdifferenzNetto = $0.00

  DECLARE cBelegRunden CURSOR LOCAL FOR
    SELECT BgPositionID, BaPersonID_Teil, SUM(AuszahlBetrag)
    FROM #NettoAuszahlungen
    GROUP BY BgPositionID, BaPersonID_Teil
    HAVING COUNT(*) > 1

  OPEN cBelegRunden
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cBelegRunden INTO @BgPositionID, @BaPersonID_Teil, @BelegBetrag
    IF @@FETCH_STATUS < 0 BREAK

    DECLARE cBelegPositionRunden CURSOR LOCAL FOR
      SELECT AuszahlungID, AuszahlBetrag
      FROM #NettoAuszahlungen
      WHERE BgPositionID = @BgPositionID AND BaPersonID_Teil = @BaPersonID_Teil

    OPEN cBelegPositionRunden
    WHILE 1=1 BEGIN
      FETCH NEXT FROM cBelegPositionRunden INTO @AuszahlungID, @AuszahlBetrag
      IF @@FETCH_STATUS < 0 BREAK
      SET @BetragNettoRound        = FLOOR((@AuszahlBetrag + @RundungsdifferenzNetto) * 20.0 + 0.5) / 20.0
      SET @RundungsdifferenzNetto  = @AuszahlBetrag + @RundungsdifferenzNetto - @BetragNettoRound

      UPDATE #NettoAuszahlungen SET AuszahlBetrag = @BetragNettoRound
      WHERE AuszahlungID = @AuszahlungID

    END
    CLOSE cBelegPositionRunden
    DEALLOCATE cBelegPositionRunden

  END
  CLOSE cBelegRunden
  DEALLOCATE cBelegRunden

  --Wegrunden von minimalen Beträgen (<0.001)

  UPDATE #NettoAuszahlungen
    SET AuszahlBetrag = FLOOR(AuszahlBetrag * 20.0 + 0.5) / 20.0
  WHERE ABS(FLOOR(AuszahlBetrag * 20.0 + 0.5) / 20.0 - AuszahlBetrag) < 0.001


--SELECT '#NettoAuszahlungen', *, Betrag = CONVERT(varchar, CONVERT(float,AuszahlBetrag)) FROM #NettoAuszahlungen AUZ

  DECLARE @KbBuchungTypCode int,
          @SumBetrag money,
          @Text varchar(200),
          @VerwPeriodeVon datetime,
          @VerwPeriodeBis datetime,
          @KbBuchungBruttoID int,
          @KbBuchungID int,
          @BaZahlungswegID int,
          @ValutaDatum datetime,
          @KbAuszahlungsArtCode int,
          @ReferenzNummer varchar(200),
          @Zahlungsgrund varchar(200),
          @KontoNr varchar(10),
          @Schuldner_BaInstitutionID int,
          @Schuldner_BaPersonID int,
          @BgPositionID_Einzahlung int,
          @MitteilungZeile1 varchar(35),
          @MitteilungZeile2 varchar(35),
          @MitteilungZeile3 varchar(35),
          @MitteilungZeile4 varchar(35)

/*
    SELECT 'cNettoBeleg', Einnahme, Datum, FLOOR((SUM(AuszahlBetrag)) * 20.0 + 0.5) / 20.0,
           BaZahlungswegID, KbAuszahlungsArtCode, Zahlungsgrund, ReferenzNummer, KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4
    FROM #NettoAuszahlungen     AUZ
      LEFT OUTER JOIN #vwBgPosition   BPO ON BPO.BgPositionID     = AUZ.BgPositionID
      LEFT OUTER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    WHERE IsNull(KbAuszahlungsArtCode, 0) <> 106 --! BSS Vorerfassung 
    --WHERE  AUZ.Einnahme = 0
    GROUP BY Datum, AUZ.BaZahlungswegID, AUZ.KbAuszahlungsArtCode, Zahlungsgrund, Einnahme, ReferenzNummer, AUZ.KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4
*/

  DECLARE cNettoBeleg CURSOR LOCAL FOR
    SELECT Einnahme, Datum, FLOOR((SUM(AuszahlBetrag)) * 20.0 + 0.5) / 20.0,
           BaZahlungswegID, KbAuszahlungsArtCode, Zahlungsgrund, ReferenzNummer, KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4
    FROM #NettoAuszahlungen     AUZ
      LEFT OUTER JOIN #vwBgPosition   BPO ON BPO.BgPositionID     = AUZ.BgPositionID
      LEFT OUTER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    WHERE IsNull(KbAuszahlungsArtCode, 0) <> 106 --! BSS Vorerfassung 
    --WHERE  AUZ.Einnahme = 0
    GROUP BY Datum, AUZ.BaZahlungswegID, AUZ.KbAuszahlungsArtCode, Zahlungsgrund, Einnahme, ReferenzNummer, AUZ.KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4

  DECLARE @BaBankID_Post int, @Einnahme int

  SELECT @BaBankID_Post = BaBankID
  FROM   dbo.BaBank WITH (READUNCOMMITTED)
  WHERE  ClearingNr = '9000'


  OPEN cNettoBeleg
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cNettoBeleg INTO @Einnahme, @ValutaDatum, @SumBetrag, @BaZahlungswegID, @KbAuszahlungsArtCode, @Zahlungsgrund, @ReferenzNummer, @KbBuchungStatusCode, @Schuldner_BaInstitutionID, @Schuldner_BaPersonID, @BgPositionID_Einzahlung, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4
    IF @@FETCH_STATUS < 0 BREAK

    -- Buchungskopf
    IF( @Einnahme = 0 ) BEGIN --Ausgabe

      IF (@KbAuszahlungsArtCode IN (103,104)) BEGIN -- Barauszahlung/Check
        -- Barauszahlung
        --Mitteilung bestimmen
        DECLARE @MitteilungZeile1tmp varchar(35),
                @MitteilungZeile2tmp varchar(35),
                @MitteilungZeile3tmp varchar(35),
                @MitteilungZeile4tmp varchar(35)

        SELECT TOP 1 @MitteilungZeile1tmp = MitteilungZeile1,
                     @MitteilungZeile2tmp = MitteilungZeile2,
                     @MitteilungZeile3tmp = MitteilungZeile3,
                     @MitteilungZeile4tmp = MitteilungZeile4
        FROM   #NettoAuszahlungen   AUZ
        WHERE AUZ.Datum = @ValutaDatum AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1) AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
          AND Einnahme = 0 AND MitteilungZeile1 IS NOT NULL


        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, ErstelltUserID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, BgBudgetID, PscdZahlwegArt/*, KbKostenstelleID*/, BeguenstigtName, BeguenstigtStrasse, BeguenstigtOrt, FaLeistungID)
        VALUES( @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, @SumBetrag, CASE @KbAuszahlungsArtCode WHEN 103 THEN 'Barauszahlung' ELSE 'Check' END + IsNull(' an ' + @MitteilungZeile1tmp,''), @KbBuchungStatusCode, @UserID, NULL, @KontoNrKreditor,
               @KbAuszahlungsArtCode, @BgBudgetID, CASE @KbAuszahlungsArtCode WHEN 103 THEN 'C' END/*, KbKostenstelleID*/, @MitteilungZeile1tmp, @MitteilungZeile2tmp, @MitteilungZeile3tmp, @FaLeistungID )
      END
/*
      ELSE IF (@KbAuszahlungsArtCode = 104) BEGIN -- Check
        -- Barauszahlung
        --Mitteilung bestimmen
        DECLARE @MitteilungZeile1tmp varchar(35),
                @MitteilungZeile2tmp varchar(35),
                @MitteilungZeile3tmp varchar(35),
                @MitteilungZeile4tmp varchar(35)

        SELECT TOP 1 @MitteilungZeile1tmp = MitteilungZeile1,
                     @MitteilungZeile2tmp = MitteilungZeile2,
                     @MitteilungZeile3tmp = MitteilungZeile3,
                     @MitteilungZeile4tmp = MitteilungZeile4
        FROM   #NettoAuszahlungen   AUZ
        WHERE AUZ.Datum = @ValutaDatum AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1) AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
          AND Einnahme = 0 AND MitteilungZeile1 IS NOT NULL


        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, ErstelltUserID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, BgBudgetID, PscdZahlwegArt/*, KbKostenstelleID*/, BeguenstigtName, BeguenstigtStrasse, BeguenstigtOrt, FaLeistungID)
        VALUES( @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, @SumBetrag, 'Check' + IsNull(' an ' + @MitteilungZeile1tmp,''), @KbBuchungStatusCode, @UserID, NULL, @KontoNrKreditor,
               @KbAuszahlungsArtCode, @BgBudgetID, NULL/*, KbKostenstelleID*/, @MitteilungZeile1tmp, @MitteilungZeile2tmp, @MitteilungZeile3tmp, @FaLeistungID )
      END
*/
      ELSE BEGIN
      
      -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
      SELECT TOP 1 
        @KreditorMehrZeilig = KreditorMehrZeilig,  
        @ClearingNr = ClearingNr, 
        @ClearingNrNeu = ClearingNrNeu
      FROM dbo.vwKreditor  BZW 
        LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = BZW.BaBankID
      WHERE BZW.BaZahlungswegID = @BaZahlungswegID
   
      IF @ClearingNrNeu IS NOT NULL
      BEGIN
        CLOSE cNettoBeleg
        DEALLOCATE cNettoBeleg
        DECLARE @Message VARCHAR(MAX)
        SET @Message = 'Der Zahlungsweg mit der ID %d hat eine Bank (ClearingNr %s) mit einer neuen ClearingNr.' + CHAR(13) + CHAR(10) +
                       'Kreditor:'+ CHAR(13) + CHAR(10) +
                       '%s'
        RAISERROR (@Message, 18, 1, @BaZahlungswegID, @ClearingNr, @KreditorMehrZeilig)
        RETURN -1
      END
      
        -- Elektronische Auszahlung
        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, PCKontoNr, BaBankID, BankKontoNr, IBAN, ReferenzNummer, Zahlungsgrund, BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr, BeguenstigtPLZ, BeguenstigtOrt,
                                BgBudgetID, PscdZahlwegArt, ModulID, /*KbKostenstelleID,*/ BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, ErstelltUserID, FaLeistungID,
                                MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4)
          SELECT @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, @SumBetrag,
               'an ' + CASE WHEN ZAL.BaZahlungswegID IS NOT NULL THEN CAST(CASE WHEN ZAL.BaPersonID IS NOT NULL THEN ZAL.PersonNameVorname WHEN ZAL.BaInstitutionID IS NOT NULL THEN ZAL.InstitutionName END AS varchar) + '; am ' + CONVERT(varchar,@ValutaDatum,104) WHEN @KbAuszahlungsArtCode = 103 THEN 'Barauszahlung' ELSE '' END,
               @KbBuchungStatusCode, @BaZahlungswegID, NULL, @KontoNrKreditor,
               @KbAuszahlungsArtCode, CASE WHEN (BNK.PCKontoNr IS NOT NULL AND BNK.PCKontoNr <> '') THEN BNK.PCKontoNr ELSE ZAL.PostKontoNummer END, ZAL.BaBankID, ZAL.BankKontoNummer, ZAL.IBANNummer, @ReferenzNummer, @Zahlungsgrund,
               ZAL.BeguenstigtName,
               ZAL.BeguenstigtName2,
               ZAL.BeguenstigtStrasse,
               ZAL.BeguenstigtHausNr,
               ZAL.BeguenstigtPLZ,
               ZAL.BeguenstigtOrt,
               @BgBudgetID,
               IsNull( XLA.Value1, XLE.Value1 ), ModulID = 3 /*W*/, /*@Kostenstelle,*/
               BNK.Name, BNK.Strasse, BNK.PLZ, BNK.Ort, BNK.ClearingNr, @UserID, @FaLeistungID, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4
          FROM dbo.vwKreditor         ZAL
            LEFT  JOIN dbo.XLOVCode      XLE WITH (READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = ZAL.EinzahlungsscheinCode
            LEFT  JOIN dbo.XLOVCode      XLA WITH (READUNCOMMITTED) ON XLA.LOVName = 'KbAuszahlungsArt'    AND XLA.Code = @KbAuszahlungsArtCode
            LEFT  JOIN dbo.BaBank        BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = CASE WHEN ZAL.BaBankID IS NULL AND (BNK.PCKontoNr IS NOT NULL AND BNK.PCKontoNr <> '' OR ZAL.PostKontoNummer IS NOT NULL AND ZAL.PostKontoNummer <> '') THEN @BaBankID_Post ELSE ZAL.BaBankID END
          WHERE ZAL.BaZahlungswegID = @BaZahlungswegID
          GROUP BY ZAL.BaZahlungswegID, CASE WHEN (BNK.PCKontoNr IS NOT NULL AND BNK.PCKontoNr <> '') THEN BNK.PCKontoNr ELSE ZAL.PostKontoNummer END, ZAL.BaBankID, ZAL.BankKontoNummer, ZAL.IBANNummer, ZAL.BaPersonID, ZAL.BaInstitutionID, ZAL.EinzahlungsscheinCode, ZAL.PersonNameVorname, ZAL.BeguenstigtName, ZAL.BeguenstigtName2, ZAL.BeguenstigtStrasse, ZAL.BeguenstigtHausNr, ZAL.BeguenstigtPLZ, ZAL.BeguenstigtOrt, ZAL.BaInstitutionID, ZAL.PersonStrasseHausNr, ZAL.PersonPLZ, ZAL.PersonOrt, ZAL.InstitutionName, ZAL.InstitutionStrasseHausNr, ZAL.InstitutionPLZ, ZAL.InstitutionOrt, XLA.Value1, XLE.Value1, BNK.Name, BNK.Strasse, BNK.PLZ, BNK.Ort, BNK.ClearingNr

          IF @@ROWCOUNT = 0
          BEGIN
              RAISERROR ('Der angegebene Kreditor ist keiner Person/Institution zugewiesen!', 18, 1)
              RETURN -1
          END 
      END
      
      SET @KbBuchungID = SCOPE_IDENTITY()
   
      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, KontoNr, VerwPeriodeVon, VerwPeriodeBis, KbKostenstelleID, BgSplittingArtCode, Weiterverrechenbar, Quoting)
        SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, AuszahlBetrag, NULL,
             BKA.KontoNr,
             VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
             VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
             AUZ.KbKostenstelleID,
             BgSplittingArtCode = BKA.BgSplittingArtCode,
             Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
             Quoting            = BKA.Quoting
        FROM   #NettoAuszahlungen   AUZ
          INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = AUZ.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = AUZ.BgPositionID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
        WHERE AUZ.Datum = @ValutaDatum AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1) AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
          AND Einnahme = 0
          AND IsNull(AUZ.MitteilungZeile1,'') = IsNull(@MitteilungZeile1,'') AND IsNull(AUZ.MitteilungZeile2,'') = IsNull(@MitteilungZeile2,'') AND IsNull(AUZ.MitteilungZeile3,'') = IsNull(@MitteilungZeile3,'') AND IsNull(AUZ.MitteilungZeile4,'') = IsNull(@MitteilungZeile4,'')

    END
    ELSE BEGIN -- Einnahme
      IF ABS(@SumBetrag) < $0.01 CONTINUE

      DECLARE @ForderungText varchar(200)
      SET @ForderungText = NULL

      IF( @Schuldner_BaInstitutionID IS NOT NULL ) BEGIN
        SELECT @ForderungText = [Name]
        FROM   dbo.BaInstitution WITH (READUNCOMMITTED)
        WHERE  BaInstitutionID = @Schuldner_BaInstitutionID
      END
      ELSE IF( @Schuldner_BaPersonID IS NOT NULL ) BEGIN
        SELECT @ForderungText = NameVorname
        FROM   dbo.vwPerson
        WHERE  BaPersonID = @Schuldner_BaPersonID
      END

      SET @ForderungText = IsNull('von ' + @ForderungText + IsNull('; am ' + CONVERT(varchar,@ValutaDatum,104),''),'Forderung')

      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, /*KbKostenstelleID,*/ SollKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID)
      VALUES( @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, -@SumBetrag, @ForderungText, @KbBuchungStatusCode, NULL,
              NULL, NULL, @BgBudgetID, NULL, /*@KbKostenstelleID,*/ @KontoNrDebitor, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID )

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, KontoNr, VerwPeriodeVon, VerwPeriodeBis, KbKostenstelleID, BgSplittingArtCode, Weiterverrechenbar, Quoting)
        SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, -AuszahlBetrag, NULL,
               BKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
               AUZ.KbKostenstelleID,
               BgSplittingArtCode = BKA.BgSplittingArtCode,
               Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
               Quoting            = BKA.Quoting
        FROM   #NettoAuszahlungen   AUZ
          INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = AUZ.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = AUZ.BgPositionID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
        WHERE IsNull(BPO.BaInstitutionID,-1) = IsNull(@Schuldner_BaInstitutionID,-1) AND IsNull(BPO.DebitorBaPersonID,-1) = IsNull(@Schuldner_BaPersonID,-1)
          AND Einnahme = 1 AND @BgPositionID_Einzahlung = AUZ.BgPositionID
          AND IsNull(AUZ.MitteilungZeile1,'') = IsNull(@MitteilungZeile1,'') AND IsNull(AUZ.MitteilungZeile2,'') = IsNull(@MitteilungZeile2,'') AND IsNull(AUZ.MitteilungZeile3,'') = IsNull(@MitteilungZeile3,'') AND IsNull(AUZ.MitteilungZeile4,'') = IsNull(@MitteilungZeile4,'')
    END
  END
  CLOSE cNettoBeleg
  DEALLOCATE cNettoBeleg

-- zusätzliche buchungen für abzüge auf abzahlungskonto
  DECLARE cAbzuege CURSOR LOCAL FOR
    SELECT BgPositionID
    FROM #Buchungen
  WHERE BgKategorieCode = 3
  GROUP BY BgPositionID
  
  OPEN cAbzuege
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cAbzuege INTO @BgPositionID
    IF @@FETCH_STATUS < 0 OR @KontoNrInterneVerrechnung IS NULL BREAK  --'Interne Verrechnung'-Buchungen nur erstellen, wenn ein solches Konto existiert
    
  -- Buchungskopf "BelastungKonto (GBL) -> Interne Verrechnung"
      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, /*KbKostenstelleID,*/ SollKtoNr, HabenKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID)
      SELECT @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, sum(-BUC.BetragBrutto), 'Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', @KbBuchungStatusCode, NULL,
              105 /*Interne Verrechnung*/, NULL, @BgBudgetID, NULL, /*@KbKostenstelleID,*/ NULL, @KontoNrInterneVerrechnung, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID 
      FROM #Buchungen          BUC
        INNER JOIN dbo.BgSpezkonto SPZ  on SPZ.BgSpezKontoID  = BUC.BgSpezkontoID
        LEFT JOIN  dbo.BgPosition  BPO  on BPO.BgPositionID   = BUC.BgPositionID
        LEFT JOIN  dbo.BgKostenart BKA  on BKA.BgKostenartID  = SPZ.BgKostenartID
      WHERE BUC.BgPositionID = @BgPositionID
      GROUP BY SPZ.NameSpezkonto

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, 
    Buchungstext, Betrag, PositionImBeleg, 
    KontoNr, 
    VerwPeriodeVon, 
    VerwPeriodeBis, 
    KbKostenstelleID, 
    BgSplittingArtCode, 
    Weiterverrechenbar, 
    Quoting)
        SELECT @KbBuchungID, BUC.BgPositionID, BUC.BgKostenartID, BUC.BaPersonID_Teil, 
               'Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', -BUC.BetragBrutto, NULL,
               BKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
               BUC.KbKostenstelleID,
               BgSplittingArtCode = BKA.BgSplittingArtCode,
               Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
               Quoting            = BKA.Quoting
        FROM   #Buchungen                    BUC
      INNER JOIN dbo.BgSpezkonto         SPZ ON                        SPZ.BgSpezKontoID    = BUC.BgSpezkontoID
          INNER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BUC.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition      BPO ON                        BPO.BgPositionID     = BUC.BgPositionID
        WHERE BUC.BgPositionID = @BgPositionID

  -- Buchungskopf "Interne Verrechnung -> GutschriftKonto"
      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, /*KbKostenstelleID,*/ SollKtoNr, HabenKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID)
      SELECT @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, SUM(-BUC.BetragBrutto), 'Gutschrift auf Konto "' + BPKA.KontoNr + ' ' + BPKA.Name + '"', @KbBuchungStatusCode, NULL,
              105 /*Interne Verrechnung*/, NULL, @BgBudgetID, NULL, /*@KbKostenstelleID,*/ @KontoNrInterneVerrechnung, NULL, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID 
      FROM #Buchungen          BUC
        INNER JOIN dbo.BgSpezkonto SPZ  on SPZ.BgSpezKontoID  = BUC.BgSpezkontoID
        LEFT JOIN  dbo.BgPosition  BPO  on BPO.BgPositionID   = BUC.BgPositionID
        LEFT JOIN  dbo.BgKostenart BKA  on BKA.BgKostenartID  = SPZ.BgKostenartID
        LEFT JOIN  dbo.BgPositionsart BPA  on BPA.BgPositionsartID = BUC.BgPositionsartID
        LEFT JOIN  dbo.BgKostenart BPKA on BPKA.BgKostenartID = BPA.BgKostenartID
      WHERE BUC.BgPositionID = @BgPositionID
      GROUP BY BPKA.KontoNr, BPKA.Name, BKA.KontoNr

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, 
                  Buchungstext, Betrag, PositionImBeleg, 
                  KontoNr, 
                  VerwPeriodeVon, 
                  VerwPeriodeBis, 
                  KbKostenstelleID, 
                  BgSplittingArtCode, 
                  Weiterverrechenbar, 
                  Quoting)
        SELECT @KbBuchungID, BUC.BgPositionID, BPA.BgKostenartID, BUC.BaPersonID_Teil, 
               'Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', -BUC.BetragBrutto, NULL,
               BPKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
               BUC.KbKostenstelleID,
               BgSplittingArtCode = BKA.BgSplittingArtCode,
               Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
               Quoting            = BKA.Quoting
        FROM   #Buchungen                    BUC
      INNER JOIN dbo.BgSpezkonto         SPZ ON                        SPZ.BgSpezKontoID    = BUC.BgSpezkontoID
          INNER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BUC.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition      BPO ON                        BPO.BgPositionID     = BUC.BgPositionID
      LEFT JOIN  dbo.BgPositionsart BPA  on BPA.BgPositionsartID = BUC.BgPositionsartID
          LEFT JOIN  dbo.BgKostenart BPKA on BPKA.BgKostenartID = BPA.BgKostenartID
        WHERE BUC.BgPositionID = @BgPositionID
  END
  CLOSE cAbzuege
  DEALLOCATE cAbzuege

  DROP TABLE #NettoAuszahlungen


  -- Leere Belege löschen
  DECLARE @tmp TABLE
  (
    KbBuchungID int
  )

  INSERT INTO @tmp
  SELECT KbBuchungID
  FROM @KbBuchung
  WHERE Betrag = $0.00 AND KbBuchungID NOT IN (SELECT KbBuchungID
                                               FROM @KbBuchungKostenart
                                               WHERE Betrag <> $0.00)

  DELETE FROM @KbBuchungKostenart WHERE KbBuchungID IN (SELECT KbBuchungID FROM @tmp)
  DELETE FROM @KbBuchung          WHERE KbBuchungID IN (SELECT KbBuchungID FROM @tmp)


  -- Position im NettoBeleg
  DECLARE @Pos int,
          @CurrentKbBuchungID int,
          @LastKbBuchungID int,
          @KbBuchungKostenartID int,
          @Betrag money


  SET @LastKbBuchungID = NULL

  DECLARE cNetto CURSOR LOCAL FOR
    SELECT KbBuchungKostenartID, KbBuchungID, Betrag
    FROM @KbBuchungKostenart
    ORDER BY KbBuchungID

  OPEN cNetto
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cNetto INTO @KbBuchungKostenartID, @CurrentKbBuchungID, @Betrag
    IF @@FETCH_STATUS < 0 BREAK

    IF ABS(@Betrag) < $0.01 CONTINUE

    IF IsNull(@LastKbBuchungID, -1) <> @CurrentKbBuchungID BEGIN
      SET @Pos = 1
      SET @LastKbBuchungID = @CurrentKbBuchungID
    END
    ELSE
      SET @Pos = @Pos + 1

    UPDATE @KbBuchungKostenart
    SET PositionImBeleg = @Pos
    WHERE KbBuchungKostenartID = @KbBuchungKostenartID

  END
  CLOSE cNetto
  DEALLOCATE cNetto


  -- Die auf 0.00 gekürzten Nettopositionenen müssen in einem Nettobeleg untergebracht werden, damit die entsprechenden Bruttobelege zu einem Nettobeleg zugeordnet werden können
  IF @KissStandard = 0 BEGIN
    DECLARE @KbBuchungIDGBL int

    SELECT TOP 1 @KbBuchungIDGBL = KBU.KbBuchungID
    FROM   @KbBuchung                KBU
      INNER JOIN @KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
    WHERE BgPositionID = @BgPositionIDGBL
    ORDER BY ValutaDatum

    IF @KbBuchungIDGBL IS NULL BEGIN
      SELECT TOP 1 @KbBuchungIDGBL = KbBuchungID
      FROM   @KbBuchung
      ORDER BY ValutaDatum
    END

    -- Detailpositionen
    INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, KontoNr, VerwPeriodeVon, VerwPeriodeBis, KbKostenstelleID, BgSplittingArtCode, Weiterverrechenbar, Quoting)
      SELECT @KbBuchungIDGBL, BUC.BgPositionID, BUC.BgKostenartID, BUC.BaPersonID_Teil, BUC.Name, $0.00, NULL,
             BKA.KontoNr,
             VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
             VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
             BUC.KbKostenstelleID,
             BgSplittingArtCode = BKA.BgSplittingArtCode,
             Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
             Quoting            = BKA.Quoting
      FROM   #Buchungen   BUC
        INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BUC.BgKostenartID
        LEFT  JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = BUC.BgPositionID
      WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1

/*
    SELECT *
    FROM #Buchungen
    WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1
*/
  END

  DROP TABLE #Buchungen



  /************************************************************************************************/
  /* Belege von temporären Tabellen in 'scharfe' Tabellen kopieren                                */
  /************************************************************************************************/
  IF @PreviewMode = 0 BEGIN
    -- Pendenz für EFB erstellen
    IF (@EFBErwerbsaufnahme = 1) BEGIN
      DECLARE @CreatorModifier VARCHAR(50)
      SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID)
      EXEC dbo.spPendenz_AblaufEFBErwerbsaufnahme @BgBudgetID, @CreatorModifier, @RefDate
    END

    DECLARE @KbBuchungID_tmp int
    DECLARE @KbBuchungID_new int
    DECLARE @KbBuchungBruttoID_tmp int
    DECLARE @KbBuchungBruttoID_new int

    BEGIN TRY 
      BEGIN TRAN

    IF EXISTS (SELECT POS2.BgPositionID
                 FROM #vwBgPosition POS2
                    INNER JOIN dbo.BgPosition POS ON POS.BgPositionID = POS2.BgPositionID
                 WHERE POS.BgPositionTS <> POS2.BgPositionTS)
      BEGIN
        RAISERROR('Mindestens eine Position wurde durch einen anderen Benutzer verändert!', 18, 1);
      END

/*
      -- Alte (nicht verbuchte, siehe Check zu Beginn) Belege dieses Budgets löschen
      DECLARE @IDs TABLE( ID int )

      --Brutto
      INSERT INTO @IDs
        SELECT KBB.KbBuchungBruttoID
        FROM KbBuchungBrutto              KBB
          LEFT JOIN KbBuchungBruttoPerson KBP ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
        WHERE BgBudgetID = @BgBudgetID AND KbBuchungTypCode IN (1,2) AND KbBuchungStatusCode IN (1,2) AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN)
    
      DELETE FROM KbBuchungBruttoPerson    
      WHERE KbBuchungBruttoID IN (SELECT ID FROM @IDs)

      DELETE FROM KbBuchungBrutto
      WHERE KbBuchungBruttoID IN (SELECT ID FROM @IDs)

      DELETE FROM @IDs

      --Netto
      INSERT INTO @IDs
        SELECT DISTINCT KBU.KbBuchungID
        FROM KbBuchung                 KBU
          LEFT JOIN KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
        WHERE BgBudgetID = @BgBudgetID AND KbBuchungTypCode IN (1,2) AND KbBuchungStatusCode IN (1,2) AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN)

      DELETE FROM KbBuchung    
      WHERE KbBuchungID IN (SELECT ID FROM @IDs)

      DELETE FROM KbBuchungKostenart
      WHERE KbBuchungID IN (SELECT ID FROM @IDs)
*/
      -- Netto
      DECLARE cKopf CURSOR LOCAL FAST_FORWARD FOR
        SELECT KbBuchungID
        FROM   @KbBuchung

      OPEN cKopf
      WHILE 1=1 BEGIN
        FETCH NEXT FROM cKopf INTO @KbBuchungID_tmp
        IF @@FETCH_STATUS <> 0 BREAK

        --Kopf einfügen
        INSERT INTO KbBuchung ([KbPeriodeID],[IkPositionID],[KbBuchungTypCode],/*[Code],*/[BelegNr],[BelegDatum],[ValutaDatum],[TransferDatum],[Betrag],[Text],[KbBuchungStatusCode],
                 [SollKtoNr],[HabenKtoNr],[KbZahlungseingangID],[BaZahlungswegID],[KbAuszahlungsArtCode],[PCKontoNr],[BaBankID],[BankKontoNr],[IBAN],[ReferenzNummer],
                 [Zahlungsgrund],[MitteilungZeile1],[MitteilungZeile2],[MitteilungZeile3],[MitteilungZeile4],[BeguenstigtName],[BeguenstigtName2],[BeguenstigtStrasse],
                 [BeguenstigtHausNr],[BeguenstigtPostfach],[BeguenstigtOrt],[BeguenstigtPLZ],[BeguenstigtLandCode],[BgBudgetID],[BarbelegUserID],[BarbelegDatum],/*[CashOrCheckAm],*/
                 /*[PscdZahlwegArt],[PscdFehlermeldung],*/[StorniertKbBuchungID],[Schuldner_BaInstitutionID],[Schuldner_BaPersonID],/*[ModulID],[KbForderungIstSH],[Kostenstelle],*/
                 [BankName],[BankStrasse],[BankPLZ],[BankOrt],[BankBCN],[ErstelltUserID],[ErstelltDatum],[MutiertUserID],[MutiertDatum])
          SELECT [KbPeriodeID],[IkPositionID],[KbBuchungTypCode],/*[Code],*/[BelegNr],[BelegDatum],[ValutaDatum],[TransferDatum],[Betrag],[Text],[KbBuchungStatusCode],
                 [SollKtoNr],[HabenKtoNr],[KbZahlungseingangID],[BaZahlungswegID],[KbAuszahlungsArtCode],[PCKontoNr],[BaBankID],[BankKontoNr],[IBAN],[ReferenzNummer],
                 [Zahlungsgrund],[MitteilungZeile1],[MitteilungZeile2],[MitteilungZeile3],[MitteilungZeile4],
                 [BeguenstigtName],
                 [BeguenstigtName2],[BeguenstigtStrasse],
                 [BeguenstigtHausNr],[BeguenstigtPostfach],[BeguenstigtOrt],[BeguenstigtPLZ],[BeguenstigtLandCode],[BgBudgetID],[BarbelegUserID],[BarbelegDatum],/*[CashOrCheckAm],*/
                 /*[PscdZahlwegArt],[PscdFehlermeldung],*/[StorniertKbBuchungID],[Schuldner_BaInstitutionID],[Schuldner_BaPersonID],/*[ModulID],[KbForderungIstSH],[Kostenstelle],*/
                 [BankName],[BankStrasse],[BankPLZ],[BankOrt],[BankBCN],[ErstelltUserID],[ErstelltDatum],[MutiertUserID],[MutiertDatum]
          FROM @KbBuchung
          WHERE KbBuchungID = @KbBuchungID_tmp

        -- 'echte' ID bestimmen
        SELECT @KbBuchungID_new = SCOPE_IDENTITY()

        -- Detailpositionen einfügen
        INSERT INTO KbBuchungKostenart([KbBuchungID],[BgPositionID],[BgKostenartID],[BaPersonID],[Buchungstext],[Betrag],[KontoNr],[PositionImBeleg],/*[Hauptvorgang],[Teilvorgang],*/
                    /*[Belegart],*/[KbForderungArtCode],[VerwPeriodeVon],[VerwPeriodeBis], [KbKostenstelleID], [BgSplittingArtCode], [Weiterverrechenbar], [Quoting])
          SELECT 	@KbBuchungID_new,[BgPositionID],[BgKostenartID],KOA.[BaPersonID],[Buchungstext],[Betrag],[KontoNr],[PositionImBeleg],/*[Hauptvorgang],[Teilvorgang],*/
                    /*[Belegart],*/[KbForderungArtCode],[VerwPeriodeVon],[VerwPeriodeBis], KOS.KbKostenstelleID, [BgSplittingArtCode], [Weiterverrechenbar], [Quoting]
          FROM @KbBuchungKostenart    KOA --! BSS
            LEFT  JOIN KbKostenstelle_BaPerson KOS ON KOS.BaPersonID = KOA.BaPersonID --! BSS
                                                  AND @FirstDayInMonth BETWEEN KOS.DatumVon AND ISNULL(KOS.DatumBis, '99990101')
                                                  AND @LastDayInMonth BETWEEN KOS.DatumVon AND ISNULL(KOS.DatumBis, '99990101')
          WHERE KbBuchungID = @KbBuchungID_tmp
        IF @@ROWCOUNT = 0 BEGIN
          RAISERROR('Interner Fehler: Beleg ohne Detailposition erstellt!', 18, 1)
        END
      END
      CLOSE cKopf
      DEALLOCATE cKopf

      -- BgPosition schein-updaten, damit TS verändert wird und nachträgliche Bearbeitungen fehlschlagen (z.B. Sozi verändert Kreditor nachdem Stellenleiter Position bewilligt & grün gestellt hat)
      UPDATE BgPosition
      SET MutiertDatum = MutiertDatum
      WHERE BgPositionID IN (SELECT BgPositionID
                             FROM @KbBuchungKostenart
                             WHERE BgPositionID IS NOT NULL)

      IF @BgPositionID_IN IS NULL BEGIN
        -- ganzes Budget grünstellen
        UPDATE BgBudget SET BgBewilligungStatusCode = 5 /* ersteilt */ WHERE BgBudgetID = @BgBudgetID
      END

      COMMIT
    END TRY
    BEGIN CATCH
      DECLARE @errormsg varchar(500)
      SET @errormsg = ERROR_MESSAGE()
      ROLLBACK
      RAISERROR(@errormsg,18,1)
    END CATCH
  END

  IF @PreviewMode = 1 BEGIN
    -- Netto Preview
    SELECT Betrag      = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN Betrag ELSE Betrag END, --! BSS
           BetragTotal = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN Betrag ELSE Betrag END, --! BSS
           *,
      Zahlungsempfaenger = IsNull(ZPR.NameVorname, ZIN.[Name])
    FROM   @KbBuchung KBU
           LEFT JOIN dbo.BaZahlungsweg      ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID   = KBU.BaZahlungswegID
           LEFT JOIN dbo.vwPerson           ZPR ON ZPR.BaPersonID        = ZAL.BaPersonID
           LEFT JOIN dbo.vwInstitution      ZIN ON ZIN.BaInstitutionID   = ZAL.BaInstitutionID
           LEFT JOIN dbo.KbKonto            KRE WITH (READUNCOMMITTED) ON KRE.KbPeriodeID       = KBU.KbPeriodeID AND KRE.KontoNr = @KontoNrKreditor

    SELECT BKA.*, PersonName = PRS.NameVorname
    FROM   @KbBuchungKostenart BKA
           LEFT  JOIN vwPerson    PRS ON PRS.BaPersonID  = BKA.BaPersonID
    WHERE  ABS(Betrag) > $0.01

  END
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sozialhilfe\Standard\spWhBudget_CreateKbBuchung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Sozialhilfe\Standard\spWhBudget_CreateKbBuchung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1493_Insert_XConfig.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1493_Insert_XConfig.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===================================================================================================
  $Revision: 1 $
=====================================================================================================
  Description
-----------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1493 (BackColor of barMainMenu in FrmMain)
=====================================================================================================*/
SET NOCOUNT ON;
GO


EXEC dbo.spAddXConfig @KeyPath = 'System\GUI\MenubalkenRotEinfaerben',
                      @DatumVon = '20180101',
                      @ValueVar = 0,
                      @ValueCode = 5, 
                      @Description = NULL,
                      @OriginalValue = 0,
                      @System = 0

PRINT ('Info: Konfiguration für Menubalken rot einfärben erstellt.');
GO

SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1493_Insert_XConfig.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1493_Insert_XConfig.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1492_Add_Spezialrecht.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1492_Add_Spezialrecht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1475
=================================================================================================*/
SET NOCOUNT ON;
GO

DECLARE @CreatorModifier VARCHAR(50);
SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()); 

DECLARE @RightName VARCHAR(100);
SET @RightName = 'CtlBaPerson_FiktivePersonBearbeiten';

IF NOT EXISTS (SELECT TOP 1 1 FROM XRight WHERE RightName = @RightName)
BEGIN
  INSERT INTO dbo.XRight
  (
      XClassID,
      ClassName,
      RightName,
      UserText,
      Description,
      Creator,
      Created,
      Modifier,
      Modified
  )
  SELECT XClassID,
       ClassName,
       RightName = @RightName,
       UserText = 'BA - Fiktive Person bearbeiten',
       Description = 'Spezialrecht um fiktive Personen zu bearbeiten',
       Creator = @CreatorModifier,
       Created = GETDATE(),
       Modifier = @CreatorModifier,
       Modified = GETDATE()
  FROM XClass
  WHERE ClassName = 'CtlBaPerson'

  PRINT ('Info: Spezialrecht: ' + @RightName + ' erstellt.');
END
ELSE
BEGIN
  PRINT ('Info: Spezialrecht: ' + @RightName + ' existiert bereits.');
END;

SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1492_Add_Spezialrecht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1492_Add_Spezialrecht.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Insert_XConfig.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Insert_XConfig.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1519
=================================================================================================*/
SET NOCOUNT ON;
GO

----------------------------------------------------------------
-- Systemkonfiguration eintragen
----------------------------------------------------------------

EXEC dbo.spAddXConfig @KeyPath = 'System\Pendenzen\Person1\Aktiv',
                      @DatumVon = '20180101',
                      @ValueVar = 1,
                      @ValueCode = 5,
                      @Description = N'Wenn wahr wird AnzahlTage vor dem 1. Geburtstag an den zuständigen SAR (Modul F) eine Pendenz erstellt',
                      @OriginalValue = 1,
                      @System = 0

EXEC dbo.spAddXConfig @KeyPath = 'System\Pendenzen\Person1\AnzahlTage',
                      @DatumVon = '20180101',
                      @ValueVar = 30,
                      @ValueCode = 2,
                      @Description = N'Anzahl Tage vor dem 1. Geburtstag',
                      @OriginalValue = 30,
                      @System = 0

PRINT ('Info: Default-Konfiguration für Neue Pendenz: Kind wird 1-jährig erstellt.');
GO

SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Insert_XConfig.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Insert_XConfig.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_TaskType.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_TaskType.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Updates the LOV "TaskType" by adding entries into dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'TaskType';
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- get the LOVID
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
SET @LOVName = 'TaskType';

DECLARE @LOVID INT
SELECT @LOVID = XLOVID FROM dbo.XLOV
WHERE LOVName = @LOVName;

-------------------------------------------------------------------------------
-- create the data in XLOVCode
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3,
                          Description, System, LOVCodeName)
  SELECT XLOVID = @LOVID,
         LOVName     = @LOVName,
         Code        = 19,
         Text        = 'Kind wird 1-jährig',
         SortKey     = 19,
         ShortText   = NULL,
         BFSCode     = NULL,
         Value1      = 'Kind erreicht am {0} das erste Altersjahr.',
         Value2      = 'Anmeldung Primano prüfen',
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = NULL
 
-- info
PRINT ('Info: Inserted LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_TaskType.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_TaskType.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_XTaskAutoGenerated.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_XTaskAutoGenerated.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Updates the LOV "TaskType" by adding entries into dbo.XLOVCode
-------------------------------------------------------------------------------------------------
  TEST:    EXEC dbo.LOV 'TaskType';
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- get the LOVID
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
SET @LOVName = 'XTaskAutoGeneratedType';

DECLARE @LOVID INT
SELECT @LOVID = XLOVID FROM dbo.XLOV
WHERE LOVName = @LOVName;

-------------------------------------------------------------------------------
-- create the data in XLOVCode
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3,
                          Description, System, LOVCodeName)
  SELECT XLOVID = @LOVID,
         LOVName     = @LOVName,
         Code        = 16,
         Text        = 'Person1',
         SortKey     = 17,
         ShortText   = NULL,
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 1,
         LOVCodeName = NULL
 
-- info
PRINT ('Info: Inserted LOV "' + @LOVName + '" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_XTaskAutoGenerated.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R41006_KBE-1519_Update_LOV_XTaskAutoGenerated.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Pendenzen\spPendenzCheck_Person1.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Pendenzen\spPendenzCheck_Person1.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE spDropObject spPendenzCheck_Person1
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spPendenzCheck_Person1.sql $
  $Author: DFE
  $Modtime: 11.01.2018 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:       Sucht Personen, die in Kürze 1 Jahre alt werden
    @AnzahlTage: Die Anzahl Tage vor dem 1. Geburtstag
  -
  RETURNS:       Ein Datensatz mit anzulegenden Pendenzen
  -
  TEST:          EXEC dbo.spPendenzCheck_Person1 30
=================================================================================================*/

CREATE PROCEDURE dbo.spPendenzCheck_Person1
(
  @AnzahlTage INT = 30
)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  -- declare local variables
  DECLARE @Alter INT
  DECLARE @AutoGeneratedType INT
  DECLARE @ReferenceTable VARCHAR(100)
  DECLARE @Code INT
  
  SET @Alter = 1
  SET @AutoGeneratedType = 16  -- Person 1
  SET @ReferenceTable = 'BaPerson'
  SET @Code = 19 -- Fristablauf Person 1

  SELECT DISTINCT
    TaskSenderCode   = 5,  -- DbScript
    TaskReceiverCode = 1,  -- Person
    TaskTypeCode     = @Code, -- Fristablauf Person 1
    TaskStatusCode   = 1,  -- Pendent
    CreateDate       = DATEADD(DAY, -@AnzahlTage, DATEADD(YEAR, @Alter, PRS.GeburtsDatum)),
    StartDate        = NULL,
    ExpirationDate   = DATEADD(YEAR, @Alter, PRS.GeburtsDatum),
    Subject          = (SELECT dbo.fnStringReplace(Value1, CONVERT(varchar, DATEADD(YEAR, @Alter, PRS.GeburtsDatum), 104)) FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    TaskDescription  = (SELECT Value2 FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    FaLeistungID     = FPL.FaLeistungID,
    BaPersonID       = FPP.BaPersonID,
    SenderID         = NULL,
    ReceiverID       = LEI.UserID,
    ReferenceTable    = @ReferenceTable,
    ReferenceID       = PRS.BaPersonID,
    AutoGeneratedType = @AutoGeneratedType
  FROM dbo.BgFinanzplan                  FPL WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
                                                                   --AND FPP.IstUnterstuetzt = 1
    INNER JOIN dbo.BaPerson              PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FPP.BaPersonID
    INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
  WHERE ISNULL(LEI.DatumBis, '99990101') >= GETDATE()
    AND FPL.BgBewilligungStatusCode >= 5
    AND DATEDIFF(DAY, GETDATE(), DATEADD(YEAR, @Alter, PRS.GeburtsDatum)) <= @AnzahlTage
    AND GETDATE() <= DATEADD(YEAR, @Alter, PRS.GeburtsDatum)
    AND NOT EXISTS (SELECT TOP 1 1
                    FROM dbo.XTaskAutoGenerated TAG WITH (READUNCOMMITTED)
                    WHERE TAG.XTaskAutoGeneratedTypeCode = @AutoGeneratedType
                      AND TAG.ReferenceTable = @ReferenceTable
                      AND TAG.ReferenceID = PRS.BaPersonID);

END
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Pendenzen\spPendenzCheck_Person1.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Pendenzen\spPendenzCheck_Person1.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXTask_Create.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXTask_Create.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO

EXECUTE spDropObject spXTask_Create;
GO
/*===============================================================================================
  $Revision: 14 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    EXEC dbo.spXTask_Create 'testing';
=================================================================================================*/

CREATE PROCEDURE dbo.spXTask_Create
(
  @CreatorModifier VARCHAR(50) = 'unknown'
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -- init start
  DECLARE @StartTimeOfCode DATETIME;
  SET @StartTimeOfCode = GETDATE();
  
  PRINT ('start call: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));

  -----------------------------------------------------------------------------
  -- Temp Tabelle initialisieren
  -----------------------------------------------------------------------------
  DECLARE @tmpXTask TABLE
  (
    TaskSenderCode INT NOT NULL,
    TaskReceiverCode INT NOT NULL,
    TaskTypeCode INT NULL,
    TaskStatusCode INT NOT NULL,
    CreateDate DATETIME NOT NULL,
    StartDate DATETIME NULL,
    ExpirationDate DATETIME NULL,
    Subject VARCHAR(100) NULL,
    TaskDescription VARCHAR(2500) NULL,
    FaLeistungID INT NULL,
    BaPersonID INT NULL,
    SenderID INT NULL,
    ReceiverID INT NULL,
    ReferenceTable VARCHAR(100) NULL,
    ReferenceID INT NULL,
    XTaskAutoGeneratedTypeCode INT NULL  -- store the type of the autogenerated task
  );
  
  DECLARE @Aktiv BIT;
  DECLARE @AnzahlTage INT;
  
  -- info
  PRINT ('done init: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));

  -----------------------------------------------------------------------------
  -- SOSTAT Pendenz (Anfangszustand)
  -----------------------------------------------------------------------------
  EXEC dbo.spBFSCheckAndCreateAnfangsdossiers 1	-- 1 = Nur Pendenzen erstellen, das Erstellen der Anfangsdossier wird dann vom Sozi ausgelöst
  
  -- info
  PRINT ('done "SOSTAT Pendenz (Anfangszustand)": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));

  
  -----------------------------------------------------------------------------
  -- getting other tasks
  -----------------------------------------------------------------------------
  -- Ende eines Finanzplans
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\WarnungVorEndeFinanzplan\Aktiv', GETDATE()))
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\WarnungVorEndeFinanzplan\AnzahlTage', GETDATE()));

    -- fill temporary table
    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID, 
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_WarnungVorEndeFinanzplan @AnzahlTage;
    
    -- info
    PRINT ('done "Ende eines Finanzplans": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

  -- Person wird 1
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\Person1\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\Person1\AnzahlTage', GETDATE()));

    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_Person1 @AnzahlTage;
    
    -- info
    PRINT ('done "Person wird 1": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

  -- Person wird 14
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\Person14\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\Person14\AnzahlTage', GETDATE()));

    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_Person14 @AnzahlTage;
    
    -- info
    PRINT ('done "Person wird 14": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;
  
  -- Person wird 18
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\Person18\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\Person18\AnzahlTage', GETDATE()));

    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_Person18 @AnzahlTage;
    
    -- info
    PRINT ('done "Person wird 18": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;
  
  -- Person wird 25
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\Person25\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\Person25\AnzahlTage', GETDATE()));

    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_Person25 @AnzahlTage;
    
    -- info
    PRINT ('done "Person wird 25": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

  -- Frau wird pensioniert
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\PensionsalterFrau\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\PensionsalterFrau\AnzahlTage', GETDATE()));
    
    DECLARE @PensionsalterFrau INT;
    SET @PensionsalterFrau = CONVERT(INT, dbo.fnXConfig('System\Basis\PensionsalterFrau', GETDATE()));
    
    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_PensionsalterFrau @AnzahlTage, @PensionsalterFrau;
    
    -- info
    PRINT ('done "Frau wird pensioniert": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END

  -- Frau erreicht AHV-Vorbezug-Alter
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\AHVVorbezugPensionFrau\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\AHVVorbezugPensionFrau\AnzahlTage', GETDATE()));
    
    DECLARE @VorbezugPensionFrau INT;
    SET @VorbezugPensionFrau = CONVERT(INT, dbo.fnXConfig('System\Basis\VorbezugPensionFrau', GETDATE()));
    
    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID, 
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_AHVVorbezugPensionFrau @AnzahlTage, @VorbezugPensionFrau;
    
    -- info
    PRINT ('done "Frau erreicht AHV-Vorbezug-Alter": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

  -- Mann wird pensioniert
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\PensionsalterMann\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\PensionsalterMann\AnzahlTage', GETDATE()));
    
    DECLARE @PensionsalterMann INT;
    SET @PensionsalterMann = CONVERT(INT, dbo.fnXConfig('System\Basis\PensionsalterMann', GETDATE()));
    
    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_PensionsalterMann @AnzahlTage, @PensionsalterMann;
    
    -- info
    PRINT ('done "Mann wird pensioniert": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

  -- Mann erreicht AHV-Vorbezug-Alter
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\AHVVorbezugPensionMann\Aktiv', GETDATE()));
 
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\AHVVorbezugPensionMann\AnzahlTage', GETDATE()));
    
    DECLARE @VorbezugPensionMann INT;
    SET @VorbezugPensionMann = CONVERT(INT, dbo.fnXConfig('System\Basis\VorbezugPensionMann', GETDATE()));
    
    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_AHVVorbezugPensionMann @AnzahlTage, @VorbezugPensionMann;
    
    -- info
    PRINT ('done "Mann erreicht AHV-Vorbezug-Alter": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;


  -- #7737 Fallsteuerung: Pendenz für Kontrolle der DLP-Erfassung bei Phasen
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\AblaufDienstleistungspaket\Aktiv', GETDATE()));
 
  IF (@Aktiv = 1)
  BEGIN
    INSERT INTO @tmpXTask (
    TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
    StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
    BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
    EXEC dbo.spPendenzCheck_FallsteuerungDLP;
  
    -- info
    PRINT ('done "Pendenz Fallsteuerung DLP-Kontrolle": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

    -- #7943 CAR: Pendenz Ausstattung Vertrag Auswertung Am geplant (DynaMask)
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\IntakeAusstattungVertragAuswertungAm\Aktiv', GETDATE()));
 
  IF (@Aktiv = 1)
  BEGIN
    INSERT INTO @tmpXTask (
    TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
    StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
    BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
    EXEC dbo.spPendenzCheck_IntakeAusstattungVertragAuswertungAm;
  
    -- info
    PRINT ('done "Pendenz Intake Ausstattung Vertrag Auswertung Am": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

    SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\BeratungAusstattungVertragAuswertungAm\Aktiv', GETDATE()));
 
  IF (@Aktiv = 1)
  BEGIN
    INSERT INTO @tmpXTask (
    TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
    StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
    BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
    EXEC dbo.spPendenzCheck_BeratungAusstattungVertragAuswertungAm;
  
    -- info
    PRINT ('done "Pendenz Beratung Ausstattung Vertrag Auswertung Am": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;
  
  -- Frist Kategorisierung läuft ab
  SET @Aktiv = CONVERT(BIT, dbo.fnXConfig('System\Pendenzen\Kategorisierung\Aktiv', GETDATE()));
  
  IF (@Aktiv = 1)
  BEGIN
    SET @AnzahlTage = CONVERT(INT, dbo.fnXConfig('System\Pendenzen\Kategorisierung\AnzahlTage', GETDATE()));

    INSERT INTO @tmpXTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, SenderID, ReceiverID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode)
      EXEC dbo.spPendenzCheck_FristKategorisierung @AnzahlTage;
    
    -- info
    PRINT ('done "Frist Kategorisierung": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;

  
  -- info
  PRINT ('done getting tasks: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));

  -----------------------------------------------------------------------------
  -- Insert entries into XTask and XTaskAutoGenerated tables
  -----------------------------------------------------------------------------
  -- setup vars
  DECLARE @TaskSenderCode INT;
  DECLARE @TaskReceiverCode INT;
  DECLARE @TaskTypeCode INT;
  DECLARE @TaskStatusCode INT;
  DECLARE @CreateDate DATETIME;
  DECLARE @StartDate DATETIME;
  DECLARE @ExpirationDate DATETIME;
  DECLARE @Subject VARCHAR(100);
  DECLARE @TaskDescription VARCHAR(2500);
  DECLARE @FaLeistungID INT;
  DECLARE @BaPersonID INT;
  DECLARE @SenderID INT;
  DECLARE @ReceiverID INT;
  DECLARE @ReferenceTable VARCHAR(100);
  DECLARE @ReferenceID INT;
  DECLARE @XTaskAutoGeneratedTypeCode INT;

  -- setup cursor
  DECLARE curXTask CURSOR FAST_FORWARD FOR
    SELECT TMP.TaskSenderCode, 
           TMP.TaskReceiverCode, 
           TMP.TaskTypeCode, 
           TMP.TaskStatusCode, 
           TMP.CreateDate,
           TMP.StartDate, 
           TMP.ExpirationDate, 
           TMP.Subject, 
           TMP.TaskDescription, 
           TMP.FaLeistungID, 
           TMP.BaPersonID, 
           TMP.SenderID, 
           TMP.ReceiverID,
           TMP.ReferenceTable,
           TMP.ReferenceID,
           TMP.XTaskAutoGeneratedTypeCode
    FROM @tmpXTask TMP;

  -- iterate through cursor
  OPEN curXTask;
  WHILE (1 = 1)
  BEGIN
    -- read next row and check if we have one
    FETCH NEXT 
    FROM curXTask 
    INTO @TaskSenderCode, @TaskReceiverCode, @TaskTypeCode, @TaskStatusCode, @CreateDate, @StartDate,
         @ExpirationDate, @Subject, @TaskDescription, @FaLeistungID, @BaPersonID, @SenderID,
         @ReceiverID, @ReferenceTable, @ReferenceID, @XTaskAutoGeneratedTypeCode;
    
    IF (@@FETCH_STATUS != 0)
    BEGIN
      BREAK;
    END;

    -- insert task into XTask table
    INSERT INTO dbo.XTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate,
                           StartDate, ExpirationDate, Subject, TaskDescription, FaLeistungID,
                           BaPersonID, FaFallID, SenderID, ReceiverID)
      SELECT TaskSenderCode   = @TaskSenderCode,
             TaskReceiverCode = @TaskReceiverCode,
             TaskTypeCode     = @TaskTypeCode,
             TaskStatusCode   = @TaskStatusCode,
             CreateDate       = @CreateDate,
             StartDate        = @StartDate,
             ExpirationDate   = @ExpirationDate,
             Subject          = @Subject,
             TaskDescription  = @TaskDescription,
             FaLeistungID     = @FaLeistungID,
             BaPersonID       = @BaPersonID,
             FaFallID         = @BaPersonID,
             SenderID         = @SenderID,
             ReceiverID       = @ReceiverID;
    
    -- insert entry into XTaskAutoGenerated table
    INSERT INTO dbo.XTaskAutoGenerated (XTaskID, ReferenceTable, ReferenceID, XTaskAutoGeneratedTypeCode,
                                        Creator, Modifier)
      SELECT XTaskID           = SCOPE_IDENTITY(),
             ReferenceTable    = @ReferenceTable,
             ReferenceID       = @ReferenceID,
             AutoGeneratedType = @XTaskAutoGeneratedTypeCode,
             Creator           = @CreatorModifier,
             Modifier          = @CreatorModifier;
  END; -- [WHILE cursor]

  -- clean up cursor
  CLOSE curXTask;
  DEALLOCATE curXTask;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  -- info
  PRINT ('done creating tasks: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  SET NOCOUNT OFF;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXTask_Create.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXTask_Create.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\1. Dispatcher\Standard\R4939_Dispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\1. Dispatcher\Standard\R4939_Dispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to add a new db version for given release.
=================================================================================================
  TEST: SELECT * FROM dbo.XDBVersion ORDER BY VersionDate, XDBVersionID;
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------------------------
DECLARE @Major INT;
DECLARE @Minor INT;
DECLARE @Build INT;
DECLARE @Revision INT;

DECLARE @BackwardCompatible VARCHAR(25);
DECLARE @VersionDescription VARCHAR(255);

-------------------------------------------------------------------------------------------------
-- define version
-------------------------------------------------------------------------------------------------
-- next release (e.g. 4.3.20)
SET @Major = 4;
SET @Minor = 9;
SET @Build = 39;
SET @Revision = 0;

-- backwards compatible (e.g. 4.3.8)
SET @BackwardCompatible = '4.9.30.0';

-- description (release info: season and year)
SET @VersionDescription = 'Autumn 2017'; -- Spring, Summer, Autumn, Winter

-------------------------------------------------------------------------------------------------
-- insert new db version entry (every time we call this script to have real history)
-- >> no more changes required below, setup version vars only above!
-------------------------------------------------------------------------------------------------
-- description for version
SET @VersionDescription = 'Release ' + CONVERT(VARCHAR(10), @Major) + '.' + 
                                       CONVERT(VARCHAR(10), @Minor) + '.' + 
                                       CONVERT(VARCHAR(10), @Build) + ISNULL(' - ' + @VersionDescription, '');

-- add new entry
EXEC dbo.spXDBVersionAddEntry @MajorVersion = @Major, 
                              @MinorVersion = @Minor, 
                              @Build = @Build, 
                              @Revision = @Revision, 
                              @BackwardCompatibleDownToClientVersion = @BackwardCompatible, 
                              @Description = @VersionDescription, 
                              @UserID = NULL;

-- fix some values
UPDATE DBV
SET DBV.Creator  = 'ReleaseScript',
    DBV.Modifier = 'ReleaseScript',
    DBV.Modified = GETDATE()
FROM dbo.XDBVersion DBV
WHERE DBV.XDBVersionID = dbo.fnXDBVersionGetCurrentDBVersionID();

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to create or update a config value with the name of the actual db.
  This config value is used to prevent Kiss from using a database that is not initialised
  whith a release skript. We want to prevent that the production document database is used
  from the integration environment.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- System Konfigurationswert  System\Allgemein\DbName
-------------------------------------------------------------------------------
DECLARE @CONFIGPATH VARCHAR(MAX);
SET @CONFIGPATH = 'System\Allgemein\DbName';
PRINT ('Checking system configuration value '  + @CONFIGPATH);

DECLARE @CURRENTDBNAME VARCHAR(400);
SET  @CURRENTDBNAME =  'KiSS4_I';  

PRINT ('Current db-name is: ' + @CURRENTDBNAME);

IF (NOT EXISTS (SELECT TOP 1 1 
                FROM dbo.XConfig 
                WHERE KeyPath = @CONFIGPATH))
BEGIN
  PRINT ('Configuration value '  + @CONFIGPATH + ' does not exist. Creating it now.');
  
  INSERT INTO dbo.XConfig 
  (
    KeyPath,
    [System],
    DatumVon,
    ValueCode,
    ValueVarchar,
    [Description],
    OriginalValueVarchar
  )
  VALUES 
  (
    @CONFIGPATH, --KeyPath
    1, -- System: ja
    '01.01.2011', --DatumVon
    1, --ValueCode (1: varchar, 2: int, 3: decimal ...) 
    @CURRENTDBNAME, --ValueVarchar
    ('Name der Datenbank. Beim Einloggen wird geprüft, ob der aktuelle Datenbank-Name mit ' +
     'diesem Wert übereinstimmt. Bei einer Nichtübereinstimmung kann der User nicht einloggen. ' +
     'Damit verhindern wir, dass versehentlich von einer Integrationsumgebung Dokumente auf ' +
     'der Produktionsumgebung mutiert, gelöscht oder eingefügt werden. ' +
     'Der erwartete Wert kann mit dem SQL "SELECT DB_NAME()" herausgefunden werden.'),
    @CURRENTDBNAME --Original Value
  );
END
ELSE
BEGIN
  PRINT ('Configuration value "'  + @CONFIGPATH + '" already exists. Updating it now.'); 
  
  UPDATE dbo.XConfig
  SET ValueVarchar = @CURRENTDBNAME 
  WHERE KeyPath = @CONFIGPATH;
END; 

-------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------
PRINT ('Done with checking "' + @CONFIGPATH + '"');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to cleanup empty extended properties (no content in value or '(null)')
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(255);
DECLARE @ColumnName VARCHAR(255);
DECLARE @PropertyName VARCHAR(255);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(255) NOT NULL,
  ColumnName VARCHAR(255),
  PropertyName VARCHAR(255) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ColumnName, PropertyName)
  SELECT TableName     = OBJECT_NAME(EXT.major_id), 
         ColumnName    = COL.name,
         PropertyName  = EXT.name
  FROM sys.extended_properties EXT
    LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id 
                                  AND COL.column_id = EXT.minor_id
  WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
    AND EXT.name <> 'microsoft_database_tools_support'
    AND ISNULL(EXT.value, '') IN ('', '(null)')
  ORDER BY TableName, 
           ColumnName, 
           CASE 
             WHEN EXT.name = 'MS_Description' THEN 0 
             ELSE 1 
           END, 
           PropertyName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName    = TMP.TableName,
         @ColumnName   = TMP.ColumnName,
         @PropertyName = TMP.PropertyName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- drop extended property
  -----------------------------------------------------------------------------
  EXEC dbo.spXExtendedProperty @TableName, @ColumnName, @PropertyName, '_delete_', 0, 1;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix constrainst created WITH NOCHECK to WITH CHECK.
           Reason:
           Constraints defined WITH NOCHECK are not considered by the query optimizer. These 
           constraints are ignored until all such constraints are re-enabled.
           
           See: http://msdn.microsoft.com/en-us/library/aa275462(v=sql.80).aspx
           
           Hint: Use "DBCC CHECKCONSTRAINTS (table_name)" to validate only
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(1000);
DECLARE @ConstraintName VARCHAR(1000);
DECLARE @SQLStatement NVARCHAR(4000);
DECLARE @ErrorMessage VARCHAR(8000);
DECLARE @ErrorCount INT;

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(1000) NOT NULL,
  ConstraintName VARCHAR(1000) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ConstraintName)
  SELECT TableName      = OBJECT_NAME(parent_object_id),
         ConstraintName = name
  FROM sys.foreign_keys
  WHERE is_not_trusted = 1
    AND is_disabled = 0
  ORDER BY TableName, ConstraintName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table
SET @ErrorCount = 0;

-- info
PRINT ('Info: Found "' + CONVERT(VARCHAR(50), @EntriesCount) + '" invalid constraints');

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName      = TMP.TableName,
         @ConstraintName = TMP.ConstraintName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- try to fix constraint
  -----------------------------------------------------------------------------
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to fix constraint here
    SET @SQLStatement = 'ALTER TABLE [dbo].[' + @TableName + '] WITH CHECK CHECK CONSTRAINT [' + @ConstraintName + '];';
    EXECUTE sp_executesql @SQLStatement;
    
    -- save
    COMMIT TRANSACTION;
    
    -- done
    PRINT ('Info: Successfully fixed table "' + @TableName + '" and constraint "' + @ConstraintName + '".');
  END TRY
  BEGIN CATCH
    -- undo
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = 'Warning: Could not fix table "' + @TableName + '" and constraint "' + @ConstraintName + '". Database error was: ' + ISNULL(ERROR_MESSAGE(), '<error?>');
    SET @ErrorCount = @ErrorCount + 1;

    -- show message and continue
    PRINT (@ErrorMessage);
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-- info
PRINT ('Info: Having now "' + CONVERT(VARCHAR(50), @ErrorCount) + '" invalid constraints after fixing');

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\CreateViews_Common.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\CreateViews_Common.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPersonSimple.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPersonSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwPersonSimple;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This is a simple view of the table BaPerson. The aim of this view is to be faster as
           the VwPerson.
           Joins are not allowed in this view, in order to keep it fast!
  -
  RETURNS: A few amount of information about a person. (BaPersonID, NameVorname)
=================================================================================================
  TEST:    SELECT TOP 10 BaPersonID, NameVorname FROM dbo.vwPersonSimple;
=================================================================================================*/

CREATE VIEW dbo.vwPersonSimple
AS
SELECT
  PRS.BaPersonID,
  NameVorname = PRS.Name + IsNull(', ' + PRS.Vorname, ''),
  PRS.Versichertennummer,
  PRS.GeschlechtCode,
  PRS.Geburtsdatum
FROM dbo.BaPerson PRS WITH (READUNCOMMITTED);
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPersonSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPersonSimple.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\Standard\vwUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\Standard\vwUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwUser
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get data for user
  -
  RETURNS: Userdata with some additional columns and information
  -
  TEST:    SELECT TOP 30 * FROM dbo.vwUser
=================================================================================================*/
CREATE VIEW dbo.vwUser
AS
SELECT 
  USR.UserID,
  USR.LogonName, 
  USR.FirstName, 
  USR.LastName, 
  USR.ShortName, 
  USR.IsUserAdmin, 
  USR.IsUserBIAGAdmin,
  USR.PasswordHash, 
  USR.IsLocked, 
  USR.GenderCode, 
  USR.LanguageCode, 
  USR.ModulID, 
  USR.isMandatsTraeger, 
  USR.Phone, 
  USR.EMail, 
  USR.ChiefID, 
  USR.PermissionGroupID, 
  USR.GrantPermGroupID, 
  USR.Text1, 
  USR.Text2, 
  USR.JobPercentage, 
  USR.HoursPerYearForCaseMgmt, 
  USR.XUserTS, 
  USR.XProfileID,
  NameVorname             = USR.LastName + ISNULL(', ' + USR.FirstName, ''),
  NameVornameOhneKomma    = USR.LastName + ISNULL(' ' + USR.FirstName, ''),
  VornameName             = ISNULL(USR.FirstName + ' ', '') + USR.LastName,
  LogonNameVornameOrgUnit = USR.LogonName + ' - ' + USR.LastName + ISNULL(', ' + USR.FirstName, '') + ISNULL(' (' + ORG.ItemName + ')', ''),
  OUU.OrgUnitID,
  ORG.ParentID,
  OrgEinheitName          = ORG.ItemName,
  OrgUnit                 = ORG.ItemName, -- von zh, wegen pendenzverwaltung
  OrgEinheitEmail         = ORG.EMail,
  OrgEinheitFax           = ORG.Fax,
  OrgEinheitWWW           = ISNULL(ORG.WWW, ORG.Internet),
  DisplayText             = USR.LogonName + ' - ' + USR.LastName + ISNULL(', ' + USR.FirstName, '') + ISNULL(' (' + ORG.ItemName + ')', '')
FROM dbo.XUser USR WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND 
                                                            OUU.OrgUnitMemberCode = 2
  LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\Standard\vwUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\Standard\vwUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmUser
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmUser
AS
SELECT
  UserID                  = USR.UserID,
  BenutzerNr              = USR.UserID,
  Login                   = USR.LogonName,
  Nachname                = USR.LastName,
  Vorname                 = USR.FirstName,
  Kuerzel                 = USR.ShortName,
  Telephon                = USR.Phone,
  EMail                   = USR.EMail,
  ErSieGross              = CASE USR.GenderCode
                              WHEN 1 THEN 'Er'
                              WHEN 2 THEN 'Sie'
                            END,
  FrauHerr                = CASE USR.GenderCode
                              WHEN 1 THEN 'Herr'
                              WHEN 2 THEN 'Frau'
                              ELSE 'Frau/Herr'
                            END,
  FrauHerrn               = CASE USR.GenderCode
                              WHEN 1 THEN 'Herrn'
                              WHEN 2 THEN 'Frau'
                              ELSE 'Frau/Herrn'
                            END,
  Briefanrede             = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, NULL),
  NameVorname             = USR.LastName + IsNull(', ' + USR.FirstName,''),
  NameVornameOhneKomma    = USR.LastName + IsNull(' ' + USR.FirstName,''),
  VornameName             = IsNull(USR.FirstName + ' ', '') + USR.LastName,
  Text1MitFmt             = USR.Text1,
  Text1OhneFmt            = USR.Text1, -- NORTF, 
  Text2MitFmt             = USR.Text2,
  Text2OhneFmt            = USR.Text2, -- NORTF, 
               
  AbteilungEMail          = ORG.EMail,
  AbteilungFax            = ORG.Fax,
               
  AbteilungName           = ORG.ItemName,
  AbteilungTelefon        = ORG.Phone,
  AbteilungTelFaxWWW      = ORG.WWW,
  AbteilungText1MitFmt    = ORG.Text1,
  AbteilungText1OhneFmt   = ORG.Text1,
  AbteilungText2MitFmt    = ORG.Text2,
  AbteilungText2OhneFmt   = ORG.Text2,
  AbteilungText3MitFmt    = ORG.Text3,
  AbteilungText3OhneFmt   = ORG.Text3,
  AbteilungText4MitFmt    = ORG.Text4,
  AbteilungText4OhneFmt   = ORG.Text4,
  AbteilungWWW            = ORG.WWW,

  CareOf                  = ADR.CareOf,
  AdressZusatz            = ADR.Zusatz,
  ZuhandenVon             = ADR.ZuhandenVon,
  Strasse                 = ADR.Strasse,
  HausNr                  = ADR.HausNr,
  Postfach                = ADR.Postfach,
  PostfachOhneNr          = ADR.PostfachOhneNr,
  PostfachTextD           = dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1),
  PLZ                     = ADR.PLZ,
  Ort                     = ADR.Ort,
  OrtschaftCode           = ADR.OrtschaftCode,
  Kanton                  = ADR.Kanton,
  Bezirk                  = ADR.Bezirk,
  --
  StrasseHausNr           = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
  OrtStrasse              = ISNULL(ADR.Ort,'') + ISNULL(', ' + ADR.Strasse + ISNULL(' ' + ADR.HausNr,''), ''),
  PLZOrt                  = ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
  --
  LandD                   = dbo.fnLandMLText(ADR.BaLandID, 1),
  LandF                   = dbo.fnLandMLText(ADR.BaLandID, 2),
  LandI                   = dbo.fnLandMLText(ADR.BaLandID, 3),
  LandE                   = dbo.fnLandMLText(ADR.BaLandID, 4),
  --
  AdresseEinzeilig        = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ', ' +
                            ISNULL(ADR.Zusatz + ', ', '') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr,'') + ', ', '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
                    
  AdresseEinzOhneName     = ISNULL(ADR.Zusatz + ', ','') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
                    
  AdresseMehrzeilig       = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + CHAR(13) + CHAR(10) +
                            ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
                    
  AdresseMehrzOhneName    = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
  AbteilungLeitungInitialen = ISNULL(SUBSTRING (LEIT.FirstName, 1, 1) + '.', '')  + ISNULL(SUBSTRING (LEIT.LastName, 1, 1) + '.', '') 
FROM dbo.XUser USR WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID 
                                                        AND OUU.OrgUnitMemberCode = 2
  LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
  LEFT JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.UserID = USR.UserID
  LEFT JOIN dbo.XUser        LEIT WITH (READUNCOMMITTED) on ORG.ChiefID = LEIT.UserID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwUserSimple.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwUserSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwUserSimple;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This is a simple view of the table XUser. The aim of this view is to be faster as
           the vwUser.
           Joins are not allowed in this view, in order to keep it fast!
  -
  RETURNS: A few amount of information about a user. 
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwUserSimple;
=================================================================================================*/

CREATE VIEW dbo.vwUserSimple
AS
SELECT
  USR.UserID,
  USR.LogonName,
  USR.LastName,
  USR.FirstName,
  NameVorname            = USR.LastName + IsNull(', ' + USR.FirstName, ''),
  DisplayText            = USR.LastName + IsNull(', ' + USR.FirstName, '') + ' - ' + USR.LogonName
FROM dbo.XUser USR WITH (READUNCOMMITTED);
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwUserSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwUserSimple.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewForeignKeys.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewForeignKeys.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject XViewForeignKeys;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/System/XViewForeignKeys.sql $
  $Author: Cjaeggi $
  $Modtime: 21.05.10 11:31 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get foreign keys on table and columns
  -
  RETURNS: All foreign keys of all tables
  -
  TEST:    SELECT TOP 30 * FROM dbo.XViewForeignKeys
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/System/XViewForeignKeys.sql $
 * 
 * 3     21.05.10 11:40 Cjaeggi
 * Merged and revised for coding rules
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.XViewForeignKeys
AS
SELECT DISTINCT 
       ForeignKeyName = SOB.[Name],
       PKTable        = OBJECT_NAME(SFK.rkeyid),
       PKColumns      = dbo.fnGetReferencedKeyColumnsOfForeignKey(SFK.constid),
       FKTable        = OBJECT_NAME(SFK.fkeyid),
       FKColumns      = dbo.fnGetForeignKeyColumnsOfForeignKey(SFK.constid)
FROM dbo.sysforeignkeys     SFK WITH (READUNCOMMITTED)
  INNER JOIN dbo.sysobjects SOB WITH (READUNCOMMITTED) ON SFK.constid = SOB.id;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewForeignKeys.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewForeignKeys.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewIndex.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewIndex.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject XViewIndex;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/System/XViewIndex.sql $
  $Author: Cjaeggi $
  $Modtime: 21.05.10 11:38 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get view indexes
  -
  RETURNS: Indexes of views
  -
  TEST:    SELECT TOP 30 * FROM dbo.XViewIndex
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/System/XViewIndex.sql $
 * 
 * 3     21.05.10 11:40 Cjaeggi
 * Merged and revised for coding rules
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.XViewIndex
AS
SELECT IndexName   = SIX.Name,
       TableName   = SOB.Name,
       PrimaryKey  = CAST((CASE(SIX.status & 2048) 
                             WHEN 2048 THEN 1 
                             ELSE 0 
                           END) AS BIT),
       [Unique]    = CAST(INDEXPROPERTY(SIX.id, SIX.Name, 'IsUnique') AS BIT),
       [Clustered] = CAST(INDEXPROPERTY(SIX.id, SIX.Name, 'IsClustered') AS BIT),
       Keys        = dbo.fnGetKeyColumnsOfIndex(SOB.Name, SIX.Name)
FROM dbo.sysindexes SIX WITH (READUNCOMMITTED)
  INNER JOIN dbo.sysobjects SOB WITH (READUNCOMMITTED) ON SOB.id = SIX.id
WHERE SIX.indid > 0 
  AND SIX.indid < 255 
  AND INDEXPROPERTY(SIX.id, SIX.Name, 'IsStatistics') = 0 
  AND INDEXPROPERTY(SIX.id, SIX.Name, 'IsHypothetical') = 0;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewIndex.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\XViewIndex.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFallPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFallPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject FaFallPerson
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: 
=================================================================================================*/

CREATE VIEW dbo.FaFallPerson
AS

SELECT
  FaFallPersonID = NULL,
  FaFallID = BaPersonID_1,
  BaPersonID = BaPersonID_2,
  DatumVon, DatumBis
FROM 
  dbo.BaPerson_Relation WITH (READUNCOMMITTED) 
UNION ALL
SELECT
  FaFallPersonID = NULL,
  FaFallID = BaPersonID_2,
  BaPersonID = BaPersonID_1,
  DatumVon, DatumBis
FROM 
  dbo.BaPerson_Relation WITH (READUNCOMMITTED) 
UNION ALL
SELECT
  FaFallPersonID = NULL,
  BaPersonID, 
  BaPersonID, 
  NULL, 
  NULL
FROM 
  dbo.BaPerson WITH (READUNCOMMITTED);

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFallPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFallPerson.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaKlientensystemPerson;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Eine übergreifende View, um FaFallPerson aus ZH und Standard zu abstrahieren
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwBaKlientensystemPerson;
=================================================================================================*/

CREATE VIEW dbo.vwBaKlientensystemPerson
AS
SELECT FaFallID,
       BaPersonID,
       DatumVon,
       DatumBis
FROM dbo.FaFallPerson FFP WITH (READUNCOMMITTED);
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmBDEZLEUebersicht;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:58 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for ZLE-Erfassung (only dummy for columns)
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmBDEZLEUebersicht
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
 * 
 * 4     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 3     23.10.08 9:31 Cjaeggi
 * Removed change again
 * 
 * 2     23.10.08 9:19 Cjaeggi
 * Changed fnBDEGetUebersicht
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
 * 
 * 1     3.09.08 9:49 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.vwTmBDEZLEUebersicht
AS
SELECT FCN.UserID, 
       FCN.MonatJahrText, 
       FCN.PensumProzent, 
       FCN.SollArbeitszeitProTag, 
       FCN.GZIstArbeitszeitProMonat, 
       FCN.GZSollArbeitszeitProMonat, 
       FCN.GZMonatsSaldo, 
       FCN.GZUebertragVorjahr, 
       FCN.GZUebertragVormonate, 
       FCN.GZKorrekturen, 
       FCN.GZAusbezahlteUeberstunden, 
       FCN.GZSaldo, 
       FCN.SLIstArbeitszeitProMonat, 
       FCN.FerienUebertragVorjahr, 
       FCN.FerienAnspruchProJahr, 
       FCN.FerienBisherBezogen, 
       FCN.FerienZugabenKuerzungen, 
       FCN.FerienKorrekturen, 
       FCN.FerienSaldo
FROM dbo.fnBDEGetUebersicht(- 1, dbo.fnLastDayOf(GETDATE()), 1, 0) AS FCN
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwIxBDELeistung_BDELeistungsart_AuswDLCode;
GO

-------------------------------------------------------------------------------
-- setup required properties
-------------------------------------------------------------------------------
SET ANSI_NULLS ON;
GO
SET ANSI_PADDING ON;
GO
SET ANSI_WARNINGS ON;
GO
SET CONCAT_NULL_YIELDS_NULL ON;
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER ON;
GO
SET ARITHABORT ON;
GO

/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Indexed view to improve performance of BDELeistung with INNER JOIN on BDELeistungsart.
           Usage for example in dbo.fnFaIsPersonClientByRule
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode;
=================================================================================================*/

CREATE VIEW dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode WITH SCHEMABINDING
AS
SELECT
  -- BDELeistung
  BaPersonID             = LEI.BaPersonID,
  Datum                  = LEI.Datum,
  DauerSUM               = SUM(ISNULL(LEI.Dauer, 0.0)),
  
  -- BDELeistungsart
  AuswDienstleistungCode = BLA.AuswDienstleistungCode,
  cBig                   = COUNT_BIG(*)
FROM dbo.BDELeistung             LEI
  INNER JOIN dbo.BDELeistungsart BLA ON BLA.BDELeistungsartID = LEI.BDELeistungsartID
GROUP BY LEI.BaPersonID, LEI.Datum, BLA.AuswDienstleistungCode;
GO

-------------------------------------------------------------------------------
-- create indexes
-------------------------------------------------------------------------------
CREATE UNIQUE CLUSTERED INDEX IX_vwIxBDELeistung_BDELeistungsart_AuswDLCode_BaPersonID_Datum_AuswDienstleistungCode 
ON [vwIxBDELeistung_BDELeistungsart_AuswDLCode]
(
  [BaPersonID] ASC,
  [Datum] ASC,
  [AuswDienstleistungCode] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
        SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, 
        ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATEN2];
GO

CREATE NONCLUSTERED INDEX IX_vwIxBDELeistung_BDELeistungsart_AuswDLCode_BaPersonID_Datum_DauerSUM_AuswDienstleistungCode 
ON [vwIxBDELeistung_BDELeistungsart_AuswDLCode]
(
  [BaPersonID] ASC,
  [Datum] ASC,
  [DauerSUM] ASC,
  [AuswDienstleistungCode] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
        SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, 
        ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATEN2];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmGvGesuch;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken-View für die Gesuchverwaltung
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmGvGesuch;
=================================================================================================*/

CREATE VIEW dbo.vwTmGvGesuch
AS
SELECT
  -----------------------------------------------------------------------------
  -- GvGesuch
  -----------------------------------------------------------------------------
  GvGesuchID              = GGE.GvGesuchID,
  BaPersonID              = GGE.BaPersonID,
  UserID                  = GGE.XUserID_Autor,
  GesuchsDatum            = GGE.GesuchsDatum,
  Gesuchsgrund            = GGE.Gesuchsgrund,
  BetragBewilligt         = GGE.BetragBewilligt,
  BewilligtAm             = GGE.BewilligtAm,
  BegruendungMitFmt       = GGE.Begruendung, -- RTF
  BegruendungOhneFmt      = GGE.Begruendung, -- NORTF
  Bemerkung               = GGE.Bemerkung,
  BewilligungBetragKS1    = GGE.BetragBewilligtKompetenzStufe1,
  BewilligungDatumKS1     = GGE.DatumBewilligtKompetenzStufe1,
  BewilligungBemerkungKS1 = GGE.BemerkungBewilligungKompetenzStufe1,
  BewilligungBetragKS2    = GGE.BetragBewilligtKompetenzStufe2,
  BewilligungDatumKS2     = GGE.DatumBewilligtKompetenzStufe2,
  BewilligungBemerkungKS2 = GGE.BemerkungBewilligungKompetenzStufe2,

  -----------------------------------------------------------------------------
  -- Bewilligung
  -----------------------------------------------------------------------------
  BewilligtVonName      = USRB.FirstName,
  BewilligtVonVorname   = USRB.LastName,
  BewilligtVonAbteilung = USRB.OrgEinheitName,

  -----------------------------------------------------------------------------
  -- Abschluss (externer Fonds)
  -----------------------------------------------------------------------------
  AbschlussDatum  = GGE.AbschlussDatum,
  AbschlussgrundD = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 1),
  AbschlussgrundF = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 2),
  AbschlussgrundI = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 3),

  -----------------------------------------------------------------------------
  -- Berechnet
  -----------------------------------------------------------------------------
  BetragBeantragt     = BBT.BetragBeantragt,
  BetragEigenleistung = ISNULL((SELECT SUM(CASE APO.GvAntragPositionTypCode
                                             WHEN 1 THEN APO.Betrag
                                             WHEN 2 THEN -APO.Betrag
                                             WHEN 3 THEN -APO.Betrag
                                           END)
                                FROM dbo.GvAntragPosition APO WITH (READUNCOMMITTED)
                                WHERE APO.GvGesuchID = GGE.GvGesuchID), $0),
  TotalAusFLBFond     = ISNULL((SELECT SUM(GGE1.BetragBewilligt)
                                FROM dbo.GvGesuch GGE1 WITH (READUNCOMMITTED)
                                WHERE GGE1.BaPersonID = GGE.BaPersonID
                                  AND YEAR(GGE1.GesuchsDatum) = YEAR(GETDATE())), $0),
  Kuerzung            = dbo.fnMax(BBT.BetragBeantragt - GGE.BetragBewilligt, $0),

  -----------------------------------------------------------------------------
  -- User
  -----------------------------------------------------------------------------
  Mitarbeiter  = USR.NameVorname,
  KGS          = KGS.ItemName,
  Kostenstelle = KST.ItemName,
  
  -----------------------------------------------------------------------------
  -- Person
  -----------------------------------------------------------------------------
  Klient = PRS.NameVorname,

  -----------------------------------------------------------------------------
  -- Fonds
  -----------------------------------------------------------------------------
  FondsNameKurz   = GFD.NameKurz,
  FondsNameLang   = GFD.NameLang,
  FondsBemerkungD = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 1, GFD.Bemerkung),
  FondsBemerkungF = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 2, GFD.Bemerkung),
  FondsBemerkungI = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 3, GFD.Bemerkung),
  FondsTypD       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 1),
  FondsTypF       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 2),
  FondsTypI       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 3),

  -----------------------------------------------------------------------------
  -- Verteiler
  -----------------------------------------------------------------------------
  Verteiler       = CASE 
                      WHEN AKS.Ort IS NULL THEN 'Pro Infirmis, '+  KST.ItemName + ', ' + USR.VornameName
                      ELSE AKS.BeantragendeStelle + ', ' + AKS.Kontaktperson + ', ' + AKS.Ort
                    END,
  VerteilerMehrzeilig = CASE 
                         WHEN AKS.Ort IS NULL THEN 'Pro Infirmis, '+  KST.ItemName + CHAR(13) + CHAR(10) + USR.VornameName
                         ELSE ISNULL(AKS.BeantragendeStelle + CHAR(13) + CHAR(10),'') +
                              ISNULL(AKS.Zusatz + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.Kontaktperson + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.Strasse + ISNULL(' ' + AKS.HausNr, '') + CHAR(13) + CHAR(10), '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, AKS.Postfach, AKS.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.PLZ + ' ', '') + ISNULL(AKS.Ort + CHAR(13) + CHAR(10), '')+
                              ISNULL(AKS.EMail, '')
                        END

FROM dbo.GvGesuch                    GGE  WITH (READUNCOMMITTED)
  INNER JOIN dbo.vwUser              USR  WITH (READUNCOMMITTED) ON USR.UserID = GGE.XUserID_Autor
  INNER JOIN dbo.vwPersonSimple      PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = GGE.BaPersonID
  INNER JOIN dbo.GvFonds             GFD  WITH (READUNCOMMITTED) ON GFD.GvFondsID = GGE.GvFondsID
  OUTER APPLY (SELECT BetragBeantragt     = ISNULL((SELECT SUM(APO.Betrag)
                                                    FROM dbo.GvAntragPosition APO WITH (READUNCOMMITTED)
                                                    WHERE APO.GvGesuchID = GGE.GvGesuchID
                                                      AND APO.GvAntragPositionTypCode = 2), $0)) BBT
  -- Benutzer der zuletzt das Gesuch bewilligt hat (letzer Eintrag mit Status "Prüfung abschliessen")
  LEFT JOIN dbo.GvBewilligung        GBE  WITH (READUNCOMMITTED) ON GBE.GvGesuchID = GGE.GvGesuchID
                                                                AND GBE.GvBewilligungCode = 5 -- Prüfung abschliessen
                                                                AND NOT EXISTS(SELECT TOP 1 1
                                                                               FROM dbo.GvBewilligung GBE2 WITH (READUNCOMMITTED)
                                                                               WHERE GBE2.GvGesuchID = GBE.GvGesuchID
                                                                                 AND GvBewilligungCode NOT IN (7, 8, 9) -- Zahlungen ausführen, Auflagen erledigen, Gesuch abschliessen
                                                                                 AND GBE2.Created > GBE.Created)
  LEFT JOIN dbo.vwUser               USRB WITH (READUNCOMMITTED) ON USRB.UserID = GBE.UserID
  LEFT JOIN dbo.XOrgUnit             KST  WITH (READUNCOMMITTED) ON KST.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(GGE.XUserID_Autor, 1))
  LEFT JOIN dbo.XOrgUnit             KGS  WITH (READUNCOMMITTED) ON KGS.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr(GGE.XUserID_Autor)
  LEFT JOIN dbo.GvAbklaerendeStelle  AKS  WITH (READUNCOMMITTED) ON AKS.GvGesuchID = GGE.GvGesuchID
;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwXConfig_public.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwXConfig_public.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwXConfig_public;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get details for SingleSignOn. 
  -
  RETURNS: Details of table XConfig.
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwXConfig_public;
=================================================================================================*/

CREATE VIEW dbo.vwXConfig_public
AS
SELECT
  CNF.XNamespaceExtensionID,
  CNF.KeyPath,
  CNF.System,
  CNF.DatumVon,
  CNF.ValueCode,
  CNF.LOVName,
  CNF.ValueBit,
  CNF.OriginalValueBit,
  CNF.ValueDateTime,
  CNF.OriginalValueDateTime,
  CNF.ValueDecimal,
  CNF.OriginalValueDecimal,
  CNF.ValueInt,
  CNF.OriginalValueInt,
  CNF.ValueMoney,
  CNF.OriginalValueMoney,
  CNF.ValueVarchar,
  CNF.OriginalValueVarchar
FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
  OUTER APPLY (SELECT TOP 1 DatumBis = DatumVon
               FROM dbo.XConfig CNFI WITH (READUNCOMMITTED)
               WHERE CNFI.KeyPath = CNF.KeyPath
                 AND CNFI.DatumVon > CNF.DatumVon
               ORDER BY CNFI.DatumVon ASC
               ) CNF2
WHERE CNF.KeyPath IN ('System\Allgemein\SingleSignOn',
                      'System\Allgemein\SingleSignOn\Domain',
                      'System\Allgemein\SingleSignOn\Gruppe',
                      'System\Allgemein\Benutzername_TechnischerBenutzer',
                      'System\Allgemein\Passwort_TechnischerBenutzer')
  AND GETDATE() BETWEEN CNF.DatumVon AND ISNULL(CNF2.DatumBis, '99991231');
  
GO

-- DO NOT REMOVE!
IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals WITH (READUNCOMMITTED)
           WHERE name = 'kiss_public'))
BEGIN
  GRANT SELECT ON [dbo].[vwXConfig_public] TO [kiss_public];
END
ELSE
BEGIN
  PRINT ('Warning: login [kiss_public] does not exists.');
END;

GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwXConfig_public.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\System\vwXConfig_public.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\CreateViews_Common.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\CreateViews_Common.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\Standard\CreateViews.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\Standard\CreateViews.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\vwKreditor_vwInstitution_vwPerson_DependingFNs.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\vwKreditor_vwInstitution_vwPerson_DependingFNs.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to (re)create construct of vwKreditor, vwInstitution, vwPerson and all
           depending functions as they are all created with flag "WITH SCHEMABINDING" and therefore
           depend on each other. 
=================================================================================================*/

-------------------------------------------------------------------------------
-- drop all items in order of dependence if existing (top down)
-------------------------------------------------------------------------------


/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\Drop_vwKreditor_vwInstitution_vwPerson_DependingFNs.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\Drop_vwKreditor_vwInstitution_vwPerson_DependingFNs.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop construct of vwKreditor, vwInstitution, vwPerson to later 
           re-createand them again. See vwKreditor_vwInstitution_vwPerson_DependingFNs.sql
           for further details. 
=================================================================================================*/

-------------------------------------------------------------------------------
-- drop all items in order of dependence if existing (top down)
-------------------------------------------------------------------------------
EXECUTE dbo.spDropObject vwKreditor;
GO
EXECUTE dbo.spDropObject vwInstitution;
GO
EXECUTE dbo.spDropObject vwPerson;
GO
--
EXECUTE dbo.spDropObject fnGetAdressText;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID;
GO
EXECUTE dbo.spDropObject fnTnToPc;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID_BaInstitution;
GO
EXECUTE dbo.spDropObject fnLandMLText;
GO
EXECUTE dbo.spDropObject fnBaGetPostfachText;
GO
EXECUTE dbo.spDropObject fnXGetPostfachTextML;
GO
EXECUTE dbo.spDropObject fnXDbObjectMLMsg;
GO
EXECUTE dbo.spDropObject fnGetMLText;
GO
EXECUTE dbo.spDropObject fnGetLastFirstName;
GO
--
EXECUTE dbo.spDropObject fnGetAge;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID_BaPerson;
GO
EXECUTE dbo.spDropObject fnDateOf;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\Drop_vwKreditor_vwInstitution_vwPerson_DependingFNs.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\Drop_vwKreditor_vwInstitution_vwPerson_DependingFNs.sql' -------- */

GO
-------------------------------------------------------------------------------
-- (re)create items (bottom up)
-------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnDateOf.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnDateOf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDateOf;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Convert datetime to date only
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @DateValue: The date to use for cutting time
  -
  RETURNS: Datetime value without any time (e.g. "<Date> 00:00:00.000")
=================================================================================================
  TEST:    SELECT dbo.fnDateOf(GETDATE());
=================================================================================================*/

CREATE FUNCTION dbo.fnDateOf
(
  @DateValue DATETIME
)
RETURNS DATETIME WITH SCHEMABINDING
AS 
BEGIN
  RETURN (CONVERT(DATETIME, CONVERT(VARCHAR, @DateValue, 112), 112));
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnDateOf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnDateOf.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID_BaPerson;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get specific unique BaAdresseID for BaInstitutionID
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @AdresseCode: The address type code within LOV BaAdressTyp
    @DateTime:    The datetime value to use for getting the address by DatumVon..DatumBis.
                  This value can be NULL and will be replaced by GETDATE()
  -
  RETURNS: Returns the BaPersonID with BaAdresseID matching for the given parameters or 
           NULL if no address was found
=================================================================================================
  TEST:    SELECT * FROM dbo.fnBaGetBaAdresseID_BaPerson(1, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetBaAdresseID_BaPerson
(
  @AdresseCode INT,
  @DateTime DATETIME
)
RETURNS TABLE WITH SCHEMABINDING
AS 
RETURN 
  SELECT BaPersonID  = ADR.BaPersonID,
         BaAdresseID = MAX(ADR.BaAdresseID)
  FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
  WHERE (ISNULL(ADR.AdresseCode, -1) = ISNULL(@AdresseCode, -1))
    AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
    AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
  GROUP BY ADR.BaPersonID;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaPerson.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAge.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAge.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetAge;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Calculate the approximate age using birthday and reference date
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Geburtsdatum:  The birthday date to use (has to be <= @Referenzdatum)
    @Referenzdatum: The reference date to use to calculate the age
  -
  RETURNS: Approximate age depending on given birthday-date and reference date or NULL if invalid
=================================================================================================
  TEST:    SELECT dbo.fnGetAge('2000-01-01', GETDATE());
           SELECT dbo.fnGetAge('2000-01-01', '1999-12-31');
           --
           SELECT dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())));
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAge
(
  @Geburtsdatum  DATETIME,
  @Referenzdatum DATETIME
)
RETURNS INT WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@Geburtsdatum = NULL OR @Referenzdatum = NULL)
  BEGIN
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- check if birthday is not yet over
  -----------------------------------------------------------------------------
  IF (@Referenzdatum < @Geburtsdatum)
  BEGIN
    -- no age yet
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- calculate and return approximate age
  -----------------------------------------------------------------------------
  RETURN (CONVERT(INT, ((DATEDIFF(dd, @Geburtsdatum, @Referenzdatum) + 0.5) / 365.25)));
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAge.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAge.sql' -------- */

GO
--

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetLastFirstName.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetLastFirstName.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetLastFirstName;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Combines LastName with FirstName as "LastName, FirstName". If UserID is given, the
           function will search LastName and FirstName from UserID, otherwise, it will try to
           combine from given parameters.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @UserID:    The user to get LastName and FirstName from
    @LastName:  The LastName to use if no UserID is given
    @FirstName: The FirstName to use if no UserID is given
  -
  RETURNS: "LastName, FirstName", or just "LastName" or "FirstName" depending on values
=================================================================================================
  TEST:    SELECT dbo.fnGetLastFirstName(2, NULL, NULL)
           SELECT dbo.fnGetLastFirstName(NULL, 'LastName', 'FirstName')
=================================================================================================*/

CREATE FUNCTION dbo.fnGetLastFirstName
(
  @UserID INT,
  @LastName VARCHAR(255),
  @FirstName VARCHAR(255)
)
RETURNS VARCHAR(500) WITH SCHEMABINDING
AS
BEGIN
  -----------------------------------------------------------------------------
  -- if we have a user id, we query values from table XUser
  -----------------------------------------------------------------------------
  IF (@UserID IS NOT NULL)
  BEGIN
    SELECT @LastName = USR.LastName,
           @FirstName = USR.FirstName
    FROM dbo.XUser USR WITH (READUNCOMMITTED)
    WHERE UserID = @UserID;
  END;
  
  -----------------------------------------------------------------------------
  -- trim
  -----------------------------------------------------------------------------
  SELECT @LastName  = LTRIM(RTRIM(@LastName)),
         @FirstName = LTRIM(RTRIM(@FirstName));
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@LastName = '')
  BEGIN
    SELECT @LastName = NULL;
  END;
  
  IF (@FirstName = '')
  BEGIN
    SELECT @FirstName = NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- combine data and return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@LastName + ISNULL(', ' + @FirstName, ''), ISNULL(@FirstName, ''));
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetLastFirstName.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetLastFirstName.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetMLText.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetMLText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetMLText;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -

=================================================================================================
   TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnGetMLText
(
  @TID INT,
  @LanguageCode INT
)
RETURNS VARCHAR(2000) WITH SCHEMABINDING
AS 
BEGIN
  RETURN (SELECT TOP 1 Text
          FROM dbo.XLangText WITH (READUNCOMMITTED)
          WHERE TID = @TID 
            AND LanguageCode IN (1, @LanguageCode)
          ORDER BY LanguageCode DESC);
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetMLText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnGetMLText.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXDbObjectMLMsg.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXDbObjectMLMsg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXDbObjectMLMsg;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get translateable text for database objects.
           This function expects a valid tid, otherwise it will return 'ERROR'.
           The function replaces any '\r\n' by CHAR(13) + CHAR(10), such that the newlines are
           displayed properly.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT dbo.fnXDbObjectMLMsg('aa', 'bb', 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnXDbObjectMLMsg
(
  @DBObjectName VARCHAR(100),
  @MessageName  VARCHAR(100),
  @LanguageCode INT
)
RETURNS VARCHAR(2000) WITH SCHEMABINDING
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@DbObjectName IS NULL OR @DbObjectName = '' OR @MessageName IS NULL OR @MessageName = '')
  BEGIN
   RETURN 'ERROR: Invalid parameters, cannot return a proper message (dbo.fnXDbObjectMLMsg).';
  END;
  
  -----------------------------------------------------------------------------
  -- declare vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnMessage VARCHAR(2000);
  
  -----------------------------------------------------------------------------
  -- get message from database
  -----------------------------------------------------------------------------
  SELECT @ReturnMessage = REPLACE(dbo.fnGetMLText(MessageTID, @LanguageCode), '\r\n', CHAR(13) + CHAR(10))
  FROM dbo.XMessage WITH (READUNCOMMITTED)
  WHERE MaskName = @DBObjectName 
    AND MessageName = @MessageName;
  
  -----------------------------------------------------------------------------
  -- validate message
  -----------------------------------------------------------------------------
  RETURN ISNULL(@ReturnMessage, 'ERROR: Text not found (dbo.fnXDbObjectMLMsg: ' + 
                                ISNULL(@DbObjectName, '') + '.' + ISNULL(@MessageName, '') + ').');
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXDbObjectMLMsg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXDbObjectMLMsg.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXGetPostfachTextML.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXGetPostfachTextML.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXGetPostfachTextML;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Determines the multilanguage text for Postfach address from parameters
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Postfach:       The text of the Postfach
    @PostfachOhneNr: The flag if the Postfach contains a valid content or is expected to be empty
    @LanguageCode:   The language code to use for ML texts
  -
  RETURNS: The multilanguage text for the Postfach as
           1) PostfachOhneNr = 1 >> '<PostfachMLText>'
           2) Postfach is not empty >> '<PostfachMLText> <PostfachContent>'
           3) Postfach is empty >> NULL
=================================================================================================
  TEST:    SELECT dbo.fnXGetPostfachTextML(NULL, NULL, 1);
           SELECT dbo.fnXGetPostfachTextML('123', 0, 1);
           SELECT dbo.fnXGetPostfachTextML('123', 1, 1);
           SELECT dbo.fnXGetPostfachTextML(NULL, 0, 1);
           SELECT dbo.fnXGetPostfachTextML(NULL, 1, 1);
           --
           SELECT dbo.fnXGetPostfachTextML('123', NULL, 1);
           SELECT dbo.fnXGetPostfachTextML('123', NULL, 2);
           SELECT dbo.fnXGetPostfachTextML('123', NULL, 3);
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetPostfachTextML
(
  @Postfach VARCHAR(100),
  @PostfachOhneNr BIT,
  @LanguageCode INT = 1
)
RETURNS VARCHAR(255) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- handle vars
  -----------------------------------------------------------------------------  
  DECLARE @PostfachMLText VARCHAR(100);
  
  -- due to performance, we set text here fixed for D/F/I (see: #6915)
  SELECT @PostfachMLText = CASE 
                             WHEN @LanguageCode = 1 THEN 'Postfach'        -- D
                             WHEN @LanguageCode = 2 THEN 'Case postale'    -- F
                             WHEN @LanguageCode = 3 THEN 'Casella postale' -- I
                             ELSE dbo.fnXDbObjectMLMsg('dbGeneral', 'Postfach', @LanguageCode)
                           END;
  
  -----------------------------------------------------------------------------
  -- return text depending on current data
  -----------------------------------------------------------------------------
  RETURN CASE
           WHEN ISNULL(@PostfachOhneNr, 0) = 1 THEN @PostfachMLText                   -- 1) the flag PostfachOhneNr is set, we show only Postfach (without evaluating text!)
           WHEN ISNULL(@Postfach, '') <> '' THEN @PostfachMLText + ' ' + @Postfach    -- 2) most common case: Postfach contains text
           ELSE NULL                                                                  -- 3) we do not have any postfach text
         END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXGetPostfachTextML.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnXGetPostfachTextML.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetPostfachText.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetPostfachText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetPostfachText;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Determines the multilanguage text for Postfach address with the option to give an ID
           of the address or directly the text to evaluate
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @BaAdresseID:    The id of the address to get Postfach from
    @Postfach:       If no BaAdresseID is given: The text of the Postfach
    @PostfachOhneNr: If no BaAdresseID is given: The flag if the Postfach contains a valid content
                     or is expected to be empty
    @LanguageCode:   The language code to use for ML texts
  -
  RETURNS: The multilanguage text for the Postfach as
           1) PostfachOhneNr = 1 >> '<PostfachMLText>'
           2) Postfach is not empty >> '<PostfachMLText> <PostfachContent>'
           3) Postfach is empty >> NULL
=================================================================================================
  TEST:    SELECT dbo.fnBaGetPostfachText(NULL, NULL, NULL, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, '123', 0, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, '123', 1, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, NULL, 0, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, NULL, 1, 1);
           --
           SELECT dbo.fnBaGetPostfachText(505, NULL, NULL, 1);
           SELECT dbo.fnBaGetPostfachText(505, NULL, NULL, 2);
           SELECT dbo.fnBaGetPostfachText(505, NULL, NULL, 3);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetPostfachText
(
  @BaAdresseID INT,
  @Postfach VARCHAR(100),
  @PostfachOhneNr BIT,
  @LanguageCode INT = 1
)
RETURNS VARCHAR(255) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- check if need to get Postfach content
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaAdresseID, -1) > 0)
  BEGIN
    SELECT @Postfach = ADR.Postfach,
           @PostfachOhneNr = ADR.PostfachOhneNr
    FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
    WHERE ADR.BaAdresseID = @BaAdresseID;
  END;
  
  -----------------------------------------------------------------------------
  -- get Postfach content
  -----------------------------------------------------------------------------  
  RETURN dbo.fnXGetPostfachTextML(@Postfach, @PostfachOhneNr, @LanguageCode);
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetPostfachText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetPostfachText.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnLandMLText.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnLandMLText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnLandMLText;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get the translated name of a country from table BaLand
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
   @BaLandID:     The id of the country as defined in table BaLand
   @LanguageCode: The id of language to use (default is german)
  -
  RETURNS: The multilanguage name of the desired country or '' if none found
=================================================================================================
  TEST:    SELECT dbo.fnLandMLText(147, 1)
           SELECT dbo.fnLandMLText(147, 2)
=================================================================================================*/

CREATE FUNCTION dbo.fnLandMLText
(
  @BaLandID INT,
  @LanguageCode	INT
)
RETURNS VARCHAR(200) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  SELECT @BaLandID     = ISNULL(@BaLandID, -1),      -- default is invalid number
         @LanguageCode = ISNULL(@LanguageCode, 1);   -- default is german
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @Text VARCHAR(200);
  
  -----------------------------------------------------------------------------
  -- get text from BaLand table
  -----------------------------------------------------------------------------
  SELECT @Text = ISNULL(CASE @LanguageCode 
                          WHEN 2 THEN LAN.TextFR    -- french
                          WHEN 3 THEN LAN.TextIT    -- italian
                          WHEN 4 THEN LAN.TextEN    -- english
                        END, LAN.Text)              -- german and any others
  FROM dbo.BaLand	LAN WITH (READUNCOMMITTED) 
  WHERE LAN.BaLandID = @BaLandID;
  
  -----------------------------------------------------------------------------
  -- done, return validated value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@Text, '');
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnLandMLText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\System\fnLandMLText.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaInstitution.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID_BaInstitution;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get specific unique BaAdresseID for BaInstitutionID
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @AdresseCode: The address type code within LOV BaAdressTyp (not evaluated by now -> future?)
    @DateTime:    The datetime value to use for getting the address by DatumVon..DatumBis.
                  This value can be NULL and will be replaced by GETDATE()
  -
  RETURNS: Returns the BaInstitutionID with BaAdresseID matching for the given parameters or 
           NULL if no address was found
=================================================================================================
  TEST:    SELECT * FROM dbo.fnBaGetBaAdresseID_BaInstitution(NULL, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetBaAdresseID_BaInstitution
(
  @AdresseCode INT,
  @DateTime DATETIME
)
RETURNS TABLE WITH SCHEMABINDING
AS 
RETURN 
  SELECT BaInstitutionID = ADR.BaInstitutionID,
         BaAdresseID     = MAX(ADR.BaAdresseID)
  FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
  WHERE ADR.BaPersonID IS NULL                                     -- additional: BaPersonID has to be NULL (an address of BaPerson can have BaInstitutionID as well)
    AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
    AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
  GROUP BY ADR.BaInstitutionID;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID_BaInstitution.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnTnToPc.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnTnToPc.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnTnToPc;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnTnToPc 
(
  @TN VARCHAR(9)
)
RETURNS VARCHAR(11) WITH SCHEMABINDING
AS 
BEGIN
  DECLARE @Result VARCHAR(11);
  SET @Result = @TN;

  IF (LEN(@TN) = 9)
  BEGIN
    DECLARE @MidPart VARCHAR(6);

    IF SUBSTRING(@TN, 3, 5) = '00000' 
      SET @MidPart = SUBSTRING(@TN, 8, 1)
    ELSE 
      IF SUBSTRING(@TN, 3, 4) = '0000' 
        SET @MidPart = SUBSTRING(@TN, 7, 2)
      ELSE 
        IF SUBSTRING(@TN, 3, 3) = '000' 
          SET @MidPart = SUBSTRING(@TN, 6, 3)
        ELSE 
          IF SUBSTRING(@TN, 3, 2) = '00' 
            SET @MidPart = SUBSTRING(@TN, 5, 4)
          ELSE 
            IF SUBSTRING(@TN, 3, 1) = '0' 
              SET @MidPart = SUBSTRING(@TN, 4, 5)
            ELSE 
              SET @MidPart = SUBSTRING(@TN, 3, 6)

    SET @Result = SUBSTRING(@TN, 1, 2) + '-' + @MidPart + '-' + SUBSTRING(@TN, 9, 1);
  END;
  
  RETURN @Result;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnTnToPc.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnTnToPc.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get specific unique BaAdresseID for given parameters in time.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @TableIDType: The type of the id within the table BaAdresse
                  - 'BaPersonID':         Use BaPersonID for matching @TableID
                  - 'BaInstitutionID':    Use BaInstitutionID for matching @TableID
                  - 'KaBetriebID':        Use KaBetriebID for matching @TableID
                  - 'KaBetriebKontaktID': Use KaBetriebKontaktID for matching @TableID
    @TableID:     The id within the table BaAdresse (e.g. BaPersonID, BaInstitutionID)
    @AdresseCode: The address type code within LOV BaAdressTyp, can be NULL (only important for BaPerson)
    @DateTime:    The datetime value to use for getting the address by DatumVon..DatumBis.
                  This value can be NULL and will be replaced by GETDATE()
  -
  RETURNS: Returns the BaAdresseID matching for the given parameters or NULL if no address was found
=================================================================================================
  TEST:    SELECT dbo.fnBaGetBaAdresseID('BaPersonID', 2, 1, NULL);
           SELECT dbo.fnBaGetBaAdresseID('BaInstitutionID', 2, NULL, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetBaAdresseID
(
  @TableIDType VARCHAR(50),
  @TableID INT,
  @AdresseCode INT,
  @DateTime DATETIME
)
RETURNS INT WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- get value depending on given parameters
  -----------------------------------------------------------------------------
  IF (@TableIDType = 'BaPersonID')
  BEGIN
    -- get matching address id for BaPerson
    RETURN (SELECT BaAdresseID = FCN.BaAdresseID
            FROM dbo.fnBaGetBaAdresseID_BaPerson(@AdresseCode, @DateTime) FCN
            WHERE FCN.BaPersonID = ISNULL(@TableID, -1));
  END
  ELSE IF (@TableIDType = 'BaInstitutionID')
  BEGIN
    -- get matching address id for BaInstitution
    RETURN (SELECT BaAdresseID = FCN.BaAdresseID
            FROM dbo.fnBaGetBaAdresseID_BaInstitution(@AdresseCode, @DateTime) FCN
            WHERE FCN.BaInstitutionID = ISNULL(@TableID, -1));
  END
  ELSE IF (@TableIDType = 'KaBetriebID')
  BEGIN
    -- get matching address id for KaBetrieb
    RETURN (SELECT BaAdresseID = MAX(ADR.BaAdresseID)
            FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
            WHERE ADR.KaBetriebID = ISNULL(@TableID, -1)                     -- KaBetriebID
              ---- AND (ISNULL(ADR.AdresseCode, -1) = ISNULL(@AdresseCode, -1))
              AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
              AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE()))));
  END
  ELSE IF (@TableIDType = 'KaBetriebKontaktID')
  BEGIN
    -- get matching address id for KaBetriebKontakt
    RETURN (SELECT BaAdresseID = MAX(ADR.BaAdresseID)
            FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
            WHERE ADR.KaBetriebKontaktID = ISNULL(@TableID, -1)              -- KaBetriebKontaktID
              ---- AND (ISNULL(ADR.AdresseCode, -1) = ISNULL(@AdresseCode, -1))
              AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
              AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE()))));
  END;
  
  -----------------------------------------------------------------------------
  -- this case should never occure
  -----------------------------------------------------------------------------
  RETURN NULL;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnBaGetBaAdresseID.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAdressText.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAdressText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetAdressText;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt die Adresse (PLZ Ort) oder mit Strasse (Strasse HausNr, PLZ Ort) des Klienten zurück
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @BaPersonID:  The ID of the person to get address from
    @ShowStrasse: flag if needed to show street
    @AddressType: 0=Wohnsitz, 1=Aufenthalt, 2=Post, 3=Heimatort
  -
  RETURNS: The desired address or NULL if nothing found or error
=================================================================================================
  TEST:    SELECT dbo.fnGetAdressText(3333, 1, 0)
           SELECT dbo.fnGetAdressText(3333, 0, 0)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 0)
           SELECT dbo.fnGetAdressText(87159, 0, 0)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 1)
           SELECT dbo.fnGetAdressText(87159, 0, 1)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 2)
           SELECT dbo.fnGetAdressText(87159, 0, 2)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 3)
           SELECT dbo.fnGetAdressText(87159, 0, 3)
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAdressText
(
  @BaPersonID INT,
  @ShowStrasse BIT = 0,
  @AddressType INT = 0
)
RETURNS VARCHAR(255) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate first
  -----------------------------------------------------------------------------
  -- validate
  IF (@BaPersonID IS NULL)
  BEGIN
   RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- get data
  -----------------------------------------------------------------------------
  -- init vars
  DECLARE @Output VARCHAR(255);
  DECLARE @AdresseCode INT;
  
  -- matching code to new address type
  SET @AdresseCode = CASE @AddressType
                       WHEN 1 THEN 2 -- Aufenthalt
                       WHEN 2 THEN 3 -- Post
                       WHEN 3 THEN NULL
                       ELSE 1        -- Wohnsitz
                     END;
  
  IF (@AddressType <> 3)
  BEGIN
    -- Aufenthalt, Post, Wohnsitz
    SELECT @Output = CASE @ShowStrasse
                       WHEN 1 THEN ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '')
                       ELSE ''
                     END + ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, '')
    FROM dbo.BaPerson         PRS WITH (READUNCOMMITTED)
      LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, @AdresseCode, NULL)
    WHERE PRS.BaPersonID = @BaPersonID;
  END
  ELSE
  BEGIN
    -- Heimatort (always without street information)
    SELECT @Output = ISNULL(CONVERT(VARCHAR, GDE.PLZ) + ' ', '') + ISNULL(GDE.Name, '')
    FROM dbo.BaPerson           PRS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
    WHERE PRS.BaPersonID = @BaPersonID;
  END;
  
  -- return value
  RETURN @Output;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAdressText.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Functions\Basis\fnGetAdressText.sql' -------- */

GO
--

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwPerson;
GO
/*===============================================================================================
  $Revision: 29 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View for person details
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
  -
  RETURNS: Various data and combined information about persons
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwPerson;
=================================================================================================*/

CREATE VIEW dbo.vwPerson WITH SCHEMABINDING
AS
SELECT -- default fields
       PRS.BaPersonID,
       PRS.Titel,
       PRS.Name,
       PRS.FruehererName,
       PRS.Vorname,
       PRS.Vorname2,
       PRS.Geburtsdatum,
       PRS.Sterbedatum,
       PRS.AHVNummer,
       PRS.Versichertennummer,
       PRS.HaushaltVersicherungsNummer,
       PRS.NNummer,
       PRS.ZEMISNummer,
       PRS.BFFNummer,
       PRS.ErteilungVA,
       PRS.GeschlechtCode,
       PRS.KonfessionCode,
       PRS.ZivilstandCode,
       PRS.ZivilstandDatum,
       PRS.HeimatgemeindeCode,
       PRS.HeimatgemeindeCodes,
       PRS.HeimatgemeindeBaGemeindeID,
       PRS.NationalitaetCode,
       PRS.AuslaenderStatusCode,
       PRS.AuslaenderStatusGueltigBis,
       PRS.InGemeindeSeit,
       PRS.InCHSeitGeburt,
       PRS.ImKantonSeit,
       PRS.ImKantonSeitGeburt,
       PRS.Telefon_P,
       PRS.Telefon_G,
       PRS.MobilTel,
       PRS.Fax,
       PRS.EMail,
       PRS.SprachCode,
       PRS.Unterstuetzt,
       PRS.Fiktiv,
       PRS.Testperson,
       PRS.NavigatorZusatz,
       PRS.Bemerkung,
       PRS.BaPersonTS,
       PRS.VerID,
       PRS.ZuzugKtPLZ,
       PRS.ZuzugKtOrt,
       PRS.ZuzugKtKanton,
       PRS.ZuzugKtOrtCode,
       PRS.ZuzugKtLandCode,
       PRS.ZuzugKtDatum,
       PRS.ZuzugKtSeitGeburt,
       PRS.ZuzugGdePLZ,
       PRS.ZuzugGdeOrt,
       PRS.ZuzugGdeKanton,
       PRS.ZuzugGdeOrtCode,
       PRS.ZuzugGdeLandCode,
       PRS.ZuzugGdeDatum,
       PRS.ZuzugGdeSeitGeburt,
       PRS.UntWohnsitzPLZ,
       PRS.UntWohnsitzOrt,
       PRS.UntWohnsitzKanton,
       PRS.UntWohnsitzOrtCode,
       PRS.UntWohnsitzLandCode,
       PRS.WegzugPLZ,
       PRS.WegzugOrt,
       PRS.WegzugKanton,
       PRS.WegzugOrtCode,
       PRS.WegzugLandCode,
       PRS.WegzugDatum,
       PRS.KeinSerienbrief,
       PRS.Creator,
       PRS.Created,
       PRS.Modifier,
       PRS.Modified,
       
       -- combined fields   
       NameVorname   = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
       VornameName   = ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
       [Alter]       = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
       [AlterMortal] = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
       
       Nationalitaet = NAT.Text,
       NationalitaetFR = NAT.TextFR,
       NationalitaetIT = NAT.TextIT,
       Heimatort     = HEI.Name + ISNULL(' ' + HEI.Kanton, ''),
       --
       WohnsitzBaAdresseID     = ADR1.BaAdresseID,
       Wohnsitz                = ISNULL(ADR1.Zusatz + ', ', '') +
                                 ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + ', ', '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR1.Postfach, ADR1.PostfachOhneNr, 1) + ', ', '') +
                                 ISNULL(ADR1.PLZ + ' ', '') + ISNULL(ADR1.Ort, ''),
       WohnsitzMehrzeilig      = ISNULL(ADR1.Zusatz + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR1.Postfach, ADR1.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR1.PLZ + ' ', '') + ISNULL(ADR1.Ort, ''),
       WohnsitzAdressZusatz    = ADR1.Zusatz,
       WohnsitzStrasse         = ADR1.Strasse,
       WohnsitzHausNr          = ADR1.HausNr,
       WohnsitzStrasseHausNr   = ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, ''),
       WohnsitzPostfach        = ADR1.Postfach,
       WohnsitzPostfachOhneNr  = ADR1.PostfachOhneNr,
       WohnsitzPostfachD       = dbo.fnBaGetPostfachText(NULL, ADR1.Postfach, ADR1.PostfachOhneNr, 1),
       WohnsitzPLZ             = ADR1.PLZ,
       WohnsitzOrt             = ADR1.Ort,
       WohnsitzPLZOrt          = ISNULL(ADR1.PLZ + ' ', '') + ISNULL(ADR1.Ort, ''),
       WohnsitzKanton          = ADR1.Kanton,
       WohnsitzLand            = dbo.fnLandMLText(ADR1.BaLandID, 1),
       WohnsitzOrtschaftCode   = ADR1.OrtschaftCode,
       WohnsitzBaLandID        = ADR1.BaLandID,
       WohnsitzBemerkung       = ADR1.Bemerkung,
       WohnsitzWohnStatusCode  = ADR1.WohnStatusCode,
       WohnsitzWohnungsgroesseCode = ADR1.WohnungsgroesseCode,
       --
       AufenthaltBaAdresseID     = ADR3.BaAdresseID,
       Aufenthalt                = ISNULL(ADR3.CareOf + ', ', '') +
                                   ISNULL(ADR3.Zusatz + ', ', '') +
                                   ISNULL(ADR3.Strasse + ISNULL(' ' + ADR3.HausNr, '') + ', ', '') +
                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADR3.Postfach, ADR3.PostfachOhneNr, 1) + ', ', '') +
                                   ISNULL(ADR3.PLZ + ' ', '') + ISNULL(ADR3.Ort, ''),
       AufenthaltMehrzeilig      = ISNULL(ADR3.CareOf + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ADR3.Zusatz + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ADR3.Strasse + ISNULL(' ' + ADR3.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADR3.Postfach, ADR3.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ADR3.PLZ + ' ', '') + ISNULL(ADR3.Ort, ''),
       AufenthaltAdressZusatz    = ADR3.Zusatz,
       AufenthaltStrasse         = ADR3.Strasse,
       AufenthaltHausNr          = ADR3.HausNr,
       AufenthaltStrasseHausNr   = ADR3.Strasse + ISNULL(' ' + ADR3.HausNr, ''),
       AufenthaltPostfach        = ADR3.Postfach,
       AufenthaltPostfachOhneNr  = ADR3.PostfachOhneNr,
       AufenthaltPostfachD       = dbo.fnBaGetPostfachText(NULL, ADR3.Postfach, ADR3.PostfachOhneNr, 1),
       AufenthaltPLZ             = ADR3.PLZ,
       AufenthaltOrt             = ADR3.Ort,
       AufenthaltPLZOrt          = ISNULL(ADR3.PLZ + ' ', '') + ISNULL(ADR3.Ort, ''),
       AufenthaltKanton          = ADR3.Kanton,
       AufenthaltLand            = dbo.fnLandMLText(ADR3.BaLandID, 1),
       AufenthaltOrtschaftCode   = ADR3.OrtschaftCode,
       AufenthaltBaLandID        = ADR3.BaLandID,
       AufenthaltBemerkung       = ADR3.Bemerkung,
       AufenthaltWohnStatusCode  = ADR3.WohnStatusCode,
       AufenthaltWohnungsgroesseCode = ADR3.WohnungsgroesseCode,
       
       AufenthaltBaInstitutionID = ADR3.BaInstitutionID,
       AufenthaltInstitutionName = ADR3.CareOf,
       
       -- BSS special fields
       PRS.SichtbarSDFlag,
       PRS.PersonSichtbarSDFlag,
       
       -- SRK/CAR special fields
       PRS.VerstaendigungSprachCode,
       PRS.InCHseit,
       PRS.CAusweisDatum,
       Anrede = CASE
                  WHEN PRS.VerstaendigungSprachCode = 2 THEN CASE
                                                               WHEN PRS.GeschlechtCode = 1 THEN 'Herr'
                                                               WHEN PRS.GeschlechtCode = 2 THEN 'Frau'
                                                               ELSE ''
                                                             END
                  ELSE CASE
                         WHEN PRS.GeschlechtCode = 1 THEN 'Monsieur'
                         WHEN PRS.GeschlechtCode = 2 THEN 'Madame'
                         ELSE ''
                       END
                END
FROM dbo.BaPerson          PRS  WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaLand     NAT  WITH (READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
  LEFT JOIN dbo.BaGemeinde HEI  WITH (READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  
  -- wohnsitz
  LEFT JOIN dbo.BaAdresse  ADR1 WITH (READUNCOMMITTED) ON ADR1.BaAdresseID = (SELECT FCN1.BaAdresseID
                                                                              FROM dbo.fnBaGetBaAdresseID_BaPerson(1, NULL) FCN1
                                                                              WHERE FCN1.BaPersonID = PRS.BaPersonID)
  
  -- aufenthalt
  LEFT JOIN dbo.BaAdresse  ADR3 WITH (READUNCOMMITTED) ON ADR3.BaAdresseID = (SELECT FCN3.BaAdresseID
                                                                              FROM dbo.fnBaGetBaAdresseID_BaPerson(3, NULL) FCN3
                                                                              WHERE FCN3.BaPersonID = PRS.BaPersonID);
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwPerson.sql' -------- */

GO

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwInstitution.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwInstitution;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Institutionen.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwInstitution;
=================================================================================================*/

CREATE VIEW dbo.vwInstitution WITH SCHEMABINDING
AS
SELECT INS.BaInstitutionID,
       INS.OrgUnitID,
       INS.InstitutionNr,
       INS.BaInstitutionArtCode,
       INS.Aktiv,
       INS.Debitor,
       INS.Kreditor,
       INS.KeinSerienbrief,
       INS.ManuelleAnrede,
       INS.Anrede,
       INS.Briefanrede,
       INS.Titel,
       INS.Name,
       INS.Vorname,
       INS.GeschlechtCode,
       INS.Telefon,
       INS.Telefon2,
       INS.Telefon3,
       INS.Fax,
       INS.EMail,
       INS.Homepage,
       INS.SprachCode,
       INS.Bemerkung,
       INS.Creator,
       INS.Created,
       INS.Modifier,
       INS.Modified,
       INS.BaInstitutionTS,
       --
       NameVorname = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname),
       --
       Adresse                 = ISNULL(ADR.Zusatz + ', ', '') +
                                 ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                                 ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       --
       AdresseMehrzeilig       = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       --
       OrtStrasse              = ISNULL(ADR.Ort, '') + ISNULL(', ' + ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''), ''),
       --
       Zusatz                  = ADR.Zusatz,
       AdressZusatz            = ADR.Zusatz,  -- [obsolete]
       Strasse                 = ADR.Strasse,
       HausNr                  = ADR.HausNr,
       StrasseHausNr           = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Postfach                = ADR.Postfach,
       PostfachOhneNr          = ADR.PostfachOhneNr,
       --
       PostfachTextD           = dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1),
       --
       PLZ                     = ADR.PLZ,
       Ort                     = ADR.Ort,
       PLZOrt                  = ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       Bezirk                  = ADR.Bezirk,
       Kanton                  = ADR.Kanton,
       Land                    = dbo.fnLandMLText(ADR.BaLandID, 1),
       OrtschaftCode           = ADR.OrtschaftCode,
       BaLandID                = ADR.BaLandID,
       --
       BaFreigabeStatusCode    = 2 -- hack um zh analog zu bleiben
FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = (SELECT FCN.BaAdresseID 
                                                                           FROM dbo.fnBaGetBaAdresseID_BaInstitution(NULL, NULL) FCN
                                                                           WHERE FCN.BaInstitutionID = INS.BaInstitutionID);
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwInstitution.sql' -------- */

GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwKreditor;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwKreditor;
=================================================================================================*/

CREATE VIEW dbo.vwKreditor WITH SCHEMABINDING
AS
WITH BaZahlungsweg_CTE
AS
(
    SELECT ZAH.BaZahlungswegID,
           ZAH.DatumVon,
           ZAH.DatumBis,
           ZAH.EinzahlungsscheinCode,
           ZAH.BankKontoNummer,
           ZAH.IBANNummer,
           ZAH.PostKontoNummer,
           ZAH.ReferenzNummer,
           ZAH.BaBankID,
           ZAH.BaInstitutionID,
           ZAH.BaPersonID,
           ZAH.AdresseName,
           ZAH.AdresseName2,
           ZAH.AdressePostfach,
           ZAH.AdresseStrasse,
           ZAH.AdresseHausNr,
           ZAH.AdressePLZ,
           ZAH.AdresseOrt
    FROM dbo.BaZahlungsweg ZAH
    WHERE (ZAH.BaInstitutionID IS NOT NULL OR ZAH.BaPersonID IS NOT NULL) -- cka: Kreditor muss Person oder Institution haben!
)
SELECT BaZahlungswegID           = ZAH.BaZahlungswegID,
       ZahlungswegDatumVon       = ZAH.DatumVon,
       ZahlungswegDatumBis       = ZAH.DatumBis,
       EinzahlungsscheinCode     = ZAH.EinzahlungsscheinCode,
       BankKontoNummer           = ZAH.BankKontoNummer,
       IBANNummer                = ZAH.IBANNummer,
       PostKontoNummer           = ZAH.PostKontoNummer,
       ReferenzNummer            = ZAH.ReferenzNummer,
       BaBankID                  = ZAH.BaBankID,
       BankName                  = BNK.Name,
       BankZusatz                = BNK.Zusatz,
       BankStrasse               = BNK.Strasse,
       BankPLZ                   = BNK.PLZ,
       BankOrt                   = BNK.Ort,
       BankClearingNr            = BNK.ClearingNr,
       BankPCKontoNr             = BNK.PCKontoNr,
       BankGueltigAb             = BNK.GueltigAb,
       BankLandCode              = BNK.LandCode,
       BaInstitutionID           = ZAH.BaInstitutionID,
       InstitutionName           = INS.[Name],
       BaFreigabeStatusCode      = INS.BaFreigabeStatusCode,
       InstitutionAdresse        = INS.Adresse,
       InstitutionOrtStrasse     = INS.OrtStrasse,
       InstitutionAdressZusatz   = INS.AdressZusatz,
       InstitutionStrasse        = INS.Strasse,
       InstitutionHausNr         = INS.HausNr,
       InstitutionStrasseHausNr  = INS.StrasseHausNr,
       InstitutionPostfach       = INS.Postfach,
       InstitutionPLZ            = INS.PLZ,
       InstitutionOrt            = INS.Ort,
       InstitutionPLZOrt         = INS.PLZOrt,
       InstitutionKanton         = INS.Kanton,
       InstitutionLand           = INS.Land,
       InstitutionBaLandID       = INS.BaLandID,
       BaPersonID                = ZAH.BaPersonID,
       PersonName                = PRS.Name,
       PersonVorname             = PRS.Vorname,
       PersonNameVorname         = PRS.NameVorname,
       PersonAdresse             = PRS.Wohnsitz,
       PersonAdressZusatz        = PRS.WohnsitzAdressZusatz,
       PersonStrasse             = PRS.WohnsitzStrasse,
       PersonHausNr              = PRS.WohnsitzHausNr,
       PersonStrasseHausNr       = PRS.WohnsitzStrasseHausNr,
       PersonPostfach            = PRS.WohnsitzPostfach,
       PersonPLZ                 = PRS.WohnsitzPLZ,
       PersonOrt                 = PRS.WohnsitzOrt,
       PersonPLZOrt              = PRS.WohnsitzPLZOrt,
       PersonKanton              = PRS.WohnsitzKanton,
       PersonLand                = PRS.WohnsitzLand,
       PersonBaLandID            = PRS.WohnsitzBaLandID,
       Kreditor                  = COALESCE(ZAH.AdresseName, INS.[Name], PRS.NameVorname),
       KreditorMehrZeilig        = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL 
                                      AND ZAH.AdressePLZ IS NOT NULL 
                                      AND ZAH.AdresseOrt IS NOT NULL 
                                      THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                           ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.NameVorname + CHAR(13) + CHAR(10) + PRS.WohnsitzMehrzeilig
                                     ELSE INS.[Name] + CHAR(13) + CHAR(10) + INS.AdresseMehrzeilig
                                   END,
       KreditorEinzeilig         = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL
                                      AND ZAH.AdressePLZ IS NOT NULL
                                      AND ZAH.AdresseOrt IS NOT NULL
                                      THEN ZAH.AdresseName + ', ' +
                                           ISNULL(ZAH.AdresseName2 + ', ', '') +
                                           ISNULL(ZAH.AdressePostfach + ', ', '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + ', ', '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.VornameName + ', ' + PRS.Wohnsitz
                                     ELSE INS.[Name] + ', ' + INS.Adresse
                                   END,
       Zahlungsweg               = EIZ.ShortText +
                                   ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)),'') +
                                   ISNULL(', ' + BNK.Name, '') +
                                   ISNULL(', ' + ZAH.BankKontoNummer, '') +
                                   ISNULL(', ' + ZAH.IBANNummer,''),
       ZahlungswegMehrZeilig     = EIZ.ShortText +
                                   ISNULL(CHAR(13) + CHAR(10) + 'IBAN:     ' + ZAH.IBANNummer,'') +
                                   ISNULL(CHAR(13) + CHAR(10) + 'Konto:    ' + ZAH.BankKontoNummer, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + BNK.Name, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + BNK.Strasse, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + ISNULL(BNK.PLZ + ' ', '') + BNK.Ort, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + 'PC-Konto: ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)), ''),
       PCKontoNr                 = dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)),
       ZusatzInfo                = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL 
                                      AND ZAH.AdressePLZ IS NOT NULL 
                                      AND ZAH.AdresseOrt IS NOT NULL
                                      THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                           ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.WohnsitzMehrzeilig
                                     ELSE INS.AdresseMehrzeilig
                                   END + CHAR(13) + CHAR(10) +
                                   '** ' + EIZ.ShortText + ' **' + CHAR(13) + CHAR(10) +
                                   ISNULL(dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)) + ISNULL(', ' + BNK.Name,'') + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ZAH.BankKontoNummer + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ZAH.IBANNummer, ''),
       IsActive                  = CONVERT(BIT, CASE 
                                                  WHEN GETDATE() BETWEEN ISNULL(ZAH.DatumVon, GETDATE()) AND ISNULL(ZAH.DatumBis, GETDATE()) THEN 1 
                                                  ELSE 0 
                                                END),
       BeguenstigtName           = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseName
                                          WHEN ZAH.BaPersonID IS NOT NULL THEN PRS.NameVorname
                                          ELSE INS.[Name]
                                        END, 35),
       BeguenstigtName2          = LEFT(CASE
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseName2 
                                        END, 35),
       BeguenstigtStrasse        = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseStrasse
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzStrasse
                                          ELSE INS.Strasse
                                        END, 35),
       BeguenstigtHausNr         = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseHausNr
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzHausNr
                                          ELSE INS.HausNr
                                        END, 35),
       BeguenstigtStrasseHausNr  = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '')
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzStrasseHausNr
                                          ELSE INS.StrasseHausNr
                                        END, 35),
       BeguenstigtPLZ            = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdressePLZ
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzPLZ
                                          ELSE INS.PLZ
                                        END, 10),
       BeguenstigtOrt            = LEFT(CASE
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseOrt
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzOrt
                                          ELSE INS.Ort
                                        END, 25)
FROM BaZahlungsweg_CTE        ZAH WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAH.BaInstitutionID
  LEFT JOIN dbo.vwPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ZAH.BaPersonID
  LEFT JOIN dbo.XLOVCode      EIZ WITH (READUNCOMMITTED) ON EIZ.LOVName = 'BgEinzahlungsschein' 
                                                        AND EIZ.Code = ZAH.EinzahlungsscheinCode
  LEFT JOIN dbo.BaBank        BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = ZAH.BaBankID;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\Standard\vwKreditor.sql' -------- */

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\vwKreditor_vwInstitution_vwPerson_DependingFNs.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\_SchemaBinding_\Standard\vwKreditor_vwInstitution_vwPerson_DependingFNs.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyKostenart.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyKostenart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject AyKostenart;
GO
/*===============================================================================================
  Revision: 3
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the BgKostenart entry for the modulID 6 (Asyl)
=================================================================================================*/

CREATE VIEW dbo.AyKostenart
AS

SELECT 
  BgKostenartID, 
  ModulID, 
  Name, 
  KontoNr, 
  Quoting, 
  BgSplittingArtCode, 
  BaWVZeileCode, 
  BgKostenartTS
FROM dbo.BgKostenart WITH (READUNCOMMITTED) 
WHERE ModulID = 6;

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyKostenart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyKostenart.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyPositionsart.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyPositionsart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject AyPositionsart;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Modul/AyPositionsart.sql $
  $Author: Tabegglen $
  $Modtime: 17.08.10 11:48 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/Modul/AyPositionsart.sql $
 * 
 * 4     17.08.10 11:50 Tabegglen
 * #3978 BgPositionsartNr muss BgPositionsartCode heissen, da es den
 * Charakter einer LOV hat.
 * 
 * 3     3.08.10 13:04 Cjaeggi
 * #3978: Fixed view after changes of table
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.AyPositionsart
AS
SELECT BgPositionsartID, 
       ModulID, 
       BgKategorieCode, 
       BgGruppeCode, 
       BgPositionsartCode, 
       BgPositionsartID_CopyOf, 
       Name, 
       HilfeText, 
       SortKey, 
       BgKostenartID, 
       NrmKontoCode, 
       VerwaltungSD_Default, 
       Spezkonto, 
       ProPerson, 
       ProUE, 
       Masterbudget_EditMask, 
       Monatsbudget_EditMask, 
       sqlRichtlinie, 
       VarName, 
       Verrechenbar, 
       Bemerkung, 
       NameTID, 
       DatumVon, 
       DatumBis, 
       System, 
       BgPositionsartTS
FROM dbo.BgPositionsart WITH (READUNCOMMITTED) 
WHERE ModulID = 6;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyPositionsart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\AyPositionsart.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFall.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject FaFall;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.FaFall
AS
SELECT
  FaFallID   = PRS.BaPersonID,
  UserID     = LEI.UserID,
  BaPersonID = PRS.BaPersonID,
  DatumVon   = CONVERT(DATETIME, NULL),
  DatumBis   = CONVERT(DATETIME, NULL)
FROM dbo.BaPerson            PRS WITH (READUNCOMMITTED) 
  CROSS APPLY (
    SELECT TOP 1 LEI1.FaLeistungID, UserID
    FROM FaLeistung LEI1
    WHERE LEI1.ModulID IN (2, 7)
      AND LEI1.BaPersonID = PRS.BaPersonID
    ORDER BY LEI1.ModulID, LEI1.DatumVon ASC, LEI1.FaLeistungID DESC
  ) LEI
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\FaFall.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDauerauftrag.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDauerauftrag.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewDauerauftrag
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/viewDauerauftrag.sql $
  $Author: Lloreggia $
  $Modtime: 16.11.09 14:19 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/viewDauerauftrag.sql $
 * 
 * 4     16.11.09 14:29 Lloreggia
 * Header Updated
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.viewDauerauftrag
AS

SELECT  
  FBA.FbDauerauftragID, 
  FBA.Text, 
  FBA.BaPersonID, 
  FBA.SollKtoNr, 
  FBA.HabenKtoNr, 
  FBA.Betrag, 
  FBA.FbZahlungswegID, 
  FBA.DatumVon, 
  FBA.PeriodizitaetCode,
  FBA.WochentagCode, 
  FBA.Monatstag1, 
  FBA.Monatstag2, 
  FBA.VorWochenende,
  FBA.DatumBis, 
  FBA.ReferenzNummer, 
  FBA.Zahlungsgrund, 
  FBA.Status, 
  FBA.FbDauerauftragTS, 
  FBA.DauerauftragDokID,
  AuftragStatus = LOV.Text,
  LetzteAusfuehrung = (SELECT MAX(ValutaDatum) FROM dbo.FbBuchung WITH (READUNCOMMITTED) 
                       WHERE FbDauerauftragID = FBA.FbDauerauftragID),
  AuftragPeriodizitaet = LOV2.Text,
  Mandant      = PRS.NameVorname,
  HabenKtoName = FBK1.KontoName,
  SollKtoName  = FBK2.KontoName,
  PlzOrt       = PRS.WohnsitzPLZOrt,
  FbTeamID = (SELECT MAX(FbTeamID) FROM dbo.FbPeriode WITH (READUNCOMMITTED) 
              WHERE  BaPersonID = FBA.BaPersonID AND
                     PeriodeVon = (SELECT MAX(PeriodeVon) FROM dbo.FbPeriode WITH (READUNCOMMITTED) 
                                   WHERE  BaPersonID = FBA.BaPersonID))
FROM 
  dbo.FbDauerauftrag FBA WITH (READUNCOMMITTED) 
        INNER JOIN dbo.vwPerson         PRS  ON FBA.BaPersonID = PRS.BaPersonID
        INNER JOIN dbo.XLOVCode         LOV  WITH (READUNCOMMITTED) ON LOV.Code = FBA.Status AND LOV.LOVName = 'FbDauerAuftragStatus'
        INNER JOIN dbo.XLOVCode         LOV2 WITH (READUNCOMMITTED) ON LOV2.Code = FBA.PeriodizitaetCode AND LOV2.LOVName = 'ZahlungsPeriode'
        LEFT OUTER JOIN dbo.FbKonto          FBK1 WITH (READUNCOMMITTED) ON FBK1.KontoNr = FBA.HabenKtoNr AND FBK1.FbPeriodeID IS NULL
        LEFT OUTER JOIN dbo.FbKonto          FBK2 WITH (READUNCOMMITTED) ON FBK2.KontoNr = FBA.SollKtoNr AND FBK2.FbPeriodeID IS NULL


GO



GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDauerauftrag.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDauerauftrag.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDTAFbBuchungen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDTAFbBuchungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewDTAFbBuchungen
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.viewDTAFbBuchungen
AS

SELECT
   FBB.FbBuchungID,
   FBB.Buchungsdatum,
   FBK.FbKontoId,
   FBDZ.FbDTAZugangID,
   FBDZ.KbFinanzInstitutCode,
   FBB.ValutaDatum,
   FBB.BelegNr,
   FBB.IBAN, 
   DTABankId       = FBDZ.BaBankID,
   FBDZ.VertragNr,
   FBB.ZahlungsArtCode,
   Mandant         = DMP.Name + IsNull(' ' + DMP.Vorname, ''),
   FBK.KontoNr,
   FBK.KontoName,
   DTAKontoNr      = FBDZ.KontoNr,
   DTAZugang       = FBDZ.Name,
   FBB.Betrag,
   Kreditor        = IsNull(FBB.Name + ', ', '') + IsNull(FBB.Zusatz + ', ', '') + IsNull(FBB.PLZ + ' ', '') + IsNull(FBB.Ort + ' ', '') + IsNull('PCKontoNr : ' + FBB.PCKontoNr + ' ', '') + IsNull('BankKontoNr : ' + FBB.BankKontoNr + ' ', ''),
   KreditorName    = FBB.Name,
   KreditorStrasse = FBB.Strasse,
   KreditorZusatz  = FBB.Zusatz,
   KreditorPLZ     = FBB.PLZ,
   KreditorOrt     = FBB.Ort,
   Zahlungsgrund   = IsNull(CONVERT(varchar(200), FBB.ReferenzNummer), FBB.Zahlungsgrund),
   FBB.PCKontoNr,
   FBB.BankKontoNr,
   BankName        = FBBA.Name,
   BankStrasse     = FBBA.Strasse,
   BankPLZ         = FBBA.PLZ,
   BankOrt         = FBBA.Ort,
   FBBA.ClearingNr,
   StatusText      = IsNull(XLOV.Text, 'Nicht Übermittelt'),
   DTAB.Status,
   DTAB.FbDTAJournalID,
   DTAStatusEdit   = CASE (SELECT MAX(FbDTAJournalID)
                           FROM dbo.FbDTABuchung WITH (READUNCOMMITTED) 
                           WHERE FbBuchungID = DTAB.FbBuchungID)
                       WHEN DTAB.FbDTAJournalID
                       THEN 1
                       ELSE 0
                     END
FROM dbo.FbBuchung             FBB
  INNER JOIN dbo.FbKonto       FBK  WITH (READUNCOMMITTED) ON FBB.HabenKtoNr = FBK.KontoNr AND FBB.FbPeriodeID = FBK.FbPeriodeID
  INNER JOIN dbo.FbDTAZugang   FBDZ WITH (READUNCOMMITTED) ON FBK.FbDTAZugangID = FBDZ.FbDTAZugangID
  INNER JOIN dbo.FbPeriode     FBP  WITH (READUNCOMMITTED) ON FBK.FbPeriodeID = FBP.FbPeriodeID
  INNER JOIN dbo.BaPerson      DMP  WITH (READUNCOMMITTED) ON FBP.BaPersonID = DMP.BaPersonID
  INNER JOIN dbo.FbZahlungsweg FBZ  WITH (READUNCOMMITTED) ON FBB.FbZahlungswegID = FBZ.FbZahlungswegID
  INNER JOIN dbo.FbKreditor    FBKR WITH (READUNCOMMITTED) ON FBZ.FbKreditorID = FBKR.FbKreditorID
  LEFT OUTER JOIN dbo.FbDTABuchung  DTAB WITH (READUNCOMMITTED) ON FBB.FbBuchungID = DTAB.FbBuchungID
  LEFT OUTER JOIN dbo.XLOVCode      XLOV WITH (READUNCOMMITTED) ON DTAB.Status = XLOV.Code AND XLOV.LOVName = 'FbBuchungDTAStatus'
  LEFT OUTER JOIN dbo.BaBank        FBBA WITH (READUNCOMMITTED) ON FBZ.BaBankID = FBBA.BaBankID
WHERE FBK.FbDTAZugangID IS NOT NULL AND FBB.FbZahlungswegID IS NOT NULL

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDTAFbBuchungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewDTAFbBuchungen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungCode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewFbBuchungCode
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungCode.sql $
  $Author: Lloreggia $
  $Modtime: 16.11.09 14:21 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungCode.sql $
 * 
 * 4     16.11.09 14:29 Lloreggia
 * Header Updated
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.viewFbBuchungCode
AS

SELECT 
  FBC.FbBuchungCodeID, 
  FBC.Code, 
  FBC.BaPersonID, 
  FBC.SollKtoNr, 
  FBC.HabenKtoNr, 
  FBC.Betrag, 
  FBC.Text, 
  FBC.UserID, 
  FBC.FbBuchungCodeTS,
  SollKtoName =
                 (SELECT TOP 1 KontoName
                  FROM   dbo.FbPeriode P WITH (READUNCOMMITTED) 
                         INNER JOIN dbo.FbKonto K WITH (READUNCOMMITTED) ON K.FbPeriodeID = P.FbPeriodeID
                  WHERE  KontoNr = FBC.SollKtoNr
                  ORDER BY PeriodeVon DESC) ,
  HabenKtoName =
                 (SELECT TOP 1 KontoName
                  FROM   dbo.FbPeriode P WITH (READUNCOMMITTED) 
                         INNER JOIN dbo.FbKonto K WITH (READUNCOMMITTED) ON K.FbPeriodeID = P.FbPeriodeID
                  WHERE  KontoNr = FBC.HabenKtoNr
                  ORDER BY PeriodeVon DESC),
  Mandant   = PRS.NameVorname,
  PlzOrt    = PRS.WohnsitzPLZOrt,
  MTLogon   = USR.LogonName,
  MTName    = USR.LastName + IsNull(', ' + USR.FirstName,'')
FROM   
  dbo.FbBuchungCode FBC      WITH (READUNCOMMITTED) 
  LEFT  JOIN dbo.vwPerson         PRS  ON PRS.BaPersonID  = FBC.BaPersonID
  LEFT  JOIN dbo.XUser            USR  WITH (READUNCOMMITTED) ON USR.UserID      = FBC.UserID


GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungCode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewFbBuchungen
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungen.sql $
  $Author: Lloreggia $
  $Modtime: 16.11.09 14:20 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungen.sql $
 * 
 * 4     16.11.09 14:29 Lloreggia
 * Header Updated
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.viewFbBuchungen
AS

-- set rowcount 1000
SELECT 
  FBU.FbBuchungID, 
  FBU.FbPeriodeID, 
  FBU.BuchungTypCode, 
  FBU.Code, 
  FBU.BelegNr, 
  FBU.BelegNrPos, 
  FBU.BuchungsDatum, 
  FBU.SollKtoNr, 
  FBU.HabenKtoNr, 
  FBU.Betrag, 
  FBU.Text, 
  FBU.ValutaDatum, 
  FBU.Zahlungsfrist, 
  FBU.BuchungStatusCode, 
  FBU.FbDauerauftragID, 
  FBU.ErfassungsDatum, 
  FBU.UserID, 
  FBU.FbZahlungswegID, 
  FBU.PCKontoNr, 
  FBU.BankKontoNr,
  FBU.IBAN,
  FBU.ZahlungsArtCode, 
  FBU.ReferenzNummer, 
  FBU.Zahlungsgrund, 
  FBU.Name, 
  FBU.Zusatz, 
  FBU.Strasse, 
  FBU.PLZ, 
  FBU.Ort, 
  FBU.Creator,
  FBU.Created,
  FBU.Modifier,
  FBU.Modified,
  FBU.FbBuchungTS,
  SollKtoName       = KTOS.KontoName,
  HabenKtoName      = KTOH.KontoName,
  SollKontoTypCode  = KTOS.KontoTypCode,
  HabenKontoTypCode = KTOH.KontoTypCode,
  Mandant = PRS.NameVorname,
  PRS.BaPersonID,
  PlzOrt     = PRS.WohnsitzPLZOrt,
  MTLogon    = USR1.LogonName,
  MTName     = IsNull(USR1.LastName,'') + IsNull(', ' + USR1.FirstName,''),
  ErfLogon   = USR2.LogonName,
  ErfName    = IsNull(USR2.LastName,'') + IsNull(', ' + USR2.FirstName,''),
  DTAB.Status,
  StatusText = XLOV.Text,
  PER.PeriodeStatusCode,
  PER.FbTeamID
FROM   
  dbo.FbBuchung FBU WITH (READUNCOMMITTED) 
  INNER JOIN dbo.FbKonto          KTOS WITH (READUNCOMMITTED) ON KTOS.FbPeriodeID = FBU.FbPeriodeID AND KTOS.KontoNr = FBU.SollKtoNr
  INNER JOIN dbo.FbKonto          KTOH WITH (READUNCOMMITTED) ON KTOH.FbPeriodeID = FBU.FbPeriodeID AND KTOH.KontoNr = FBU.HabenKtoNr
  INNER JOIN dbo.FbPeriode        PER  WITH (READUNCOMMITTED) ON PER.FbPeriodeID = FBU.FbPeriodeID
  INNER JOIN dbo.vwPerson         PRS  ON PRS.BaPersonID = PER.BaPersonID
  LEFT OUTER JOIN dbo.FaLeistung       LST  WITH (READUNCOMMITTED) ON LST.BaPersonID = PER.BaPersonID AND
                                     LST.ModulID IN (5, 29)
  LEFT OUTER JOIN dbo.XUser            USR1 WITH (READUNCOMMITTED) ON USR1.UserID = LST.UserID
  LEFT OUTER JOIN dbo.XUser            USR2 WITH (READUNCOMMITTED) ON USR2.UserID = FBU.UserID
  LEFT OUTER JOIN dbo.FbDTABuchung     DTAB WITH (READUNCOMMITTED) ON FBU.FbBuchungID = DTAB.FbBuchungID AND DTAB.FbDTAJournalID = (SELECT MAX(FbDTAJournalID) FROM dbo.FbDTABuchung WITH (READUNCOMMITTED) WHERE FbDTABuchung.FbBuchungID = FBU.FbBuchungID)
  LEFT OUTER JOIN dbo.XLOVCode         XLOV WITH (READUNCOMMITTED) ON DTAB.Status = XLOV.Code AND XLOV.LOVName = 'FbBuchungDTAStatus'
WHERE (LST.FaLeistungID IS NULL OR LST.FaLeistungID = dbo.fnVmGetLeistungID(PER.BaPersonID))


GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\viewFbBuchungen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaAdressate;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Auswahl Adressate in CtlFaDokumente
           Typ ist in LOV BaAdressatTyp übersetzt
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwBaAdressate;
=================================================================================================*/

CREATE VIEW dbo.vwBaAdressate
AS
-------------------------------------------------------------------------------
-- Personen
-------------------------------------------------------------------------------
SELECT ID      = PRS.BaPersonID,
       TypCode = 1,
       Typ     = 'Person',
       Name    = PRS.Name + ISNULL(' ' + PRS.Vorname, ''),
       Strasse = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Ort     = ADR.PLZ + ISNULL(' ' + ADR.Ort, '')
FROM dbo.BaPerson         PRS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL) -- wohnsitz

UNION ALL

-------------------------------------------------------------------------------
-- Institutionen
-------------------------------------------------------------------------------
SELECT ID      = INS.BaInstitutionID,
       TypCode = 2,
       Typ     = 'Institution',
       Name    = INS.[Name] + ISNULL(' ' + INS.Vorname, ''),
       Strasse = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Ort     = ADR.PLZ + ISNULL(' ' + ADR.Ort, '')
FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
WHERE INS.Aktiv = 1

--UNION ALL

---------------------------------------------------------------------------------
---- Private Mandatsträger
---------------------------------------------------------------------------------
--SELECT ID      =  VPM.VmPriMaID,
--       TypCode = 3,
--       Typ     = 'PriMa',
--       Name    = VPM.Name + IsNull(', ' + VPM.Vorname, ''),
--       Strasse = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
--       Ort     = IsNull(ADR.PLZ + ' ', '') + ADR.Ort
--    FROM VmPriMa           VPM
--      LEFT JOIN BaAdresse  ADR ON ADR.VmPriMaID = VPM.VmPriMaID
--    WHERE 
--    VPM.isActive = 1
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaAdressate.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBFSDossier.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBFSDossier.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBFSDossier
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwBFSDossier.sql $
  $Author: Ckaeser $
  $Modtime: 25.06.09 12:54 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwBFSDossier.sql $
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: vwBFSDossier
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.07.2008 15:09
*/
CREATE VIEW dbo.vwBFSDossier
AS

--SELECT 
--  FaLeistungID,    
--  FalltraegerID = LEI.BaPersonID 
--FROM FaLeistung	LEI
SELECT 
  FaLeistungID,    
  BaPersonID as 'FalltraegerID'
FROM dbo.FaLeistung	LEI WITH (READUNCOMMITTED) 

GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBFSDossier.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBFSDossier.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBgPosition.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBgPosition.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBgPosition
GO
/*===============================================================================================
  $Revision: 12 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwBgPosition
AS

--set rowcount 1000
SELECT
  BPO.BgPositionID,
  BPO.BgPositionID_Parent,
  BPO.BgPositionID_CopyOf,
  BPO.BgBudgetID,
  BPO.BaPersonID,
  BPO.BgKategorieCode,
  BPO.BgPositionsartID,
  BPO.ShBelegID,
  BPO.Betrag,
  BPO.Reduktion,
  BPO.Abzug,
  BPO.BetragEff,
  BPO.MaxBeitragSD,
  BPO.Buchungstext,
  BPO.BgSpezkontoID,
  BPO.VerwaltungSD,
  BPO.Bemerkung,
  BPO.DatumVon,
  BPO.DatumBis,
  BPO.BaInstitutionID,
  BPO.DebitorBaPersonID,
  BPO.VerwPeriodeVon,
  BPO.VerwPeriodeBis,
  BPO.FaelligAm,
  BPO.RechnungDatum,
  BPO.BgBewilligungStatusCode,
  BPO.Value1,
  BPO.Value2,
  BPO.Value3,
  BPO.ErstelltUserID,
  BPO.ErstelltDatum,
  BPO.MutiertUserID,
  BPO.MutiertDatum,
  BPO.BgPositionTS,
  BPO.BgPositionID_AutoForderung,
  BetragFinanzplan = CASE
                       WHEN SPT.BgPositionsartCode BETWEEN 39100 AND 39199 --EFB
                            AND SPT.BgPositionsartCode != SPT.BgGruppeCode 
                            AND BPO.BgKategorieCode = 2 --nur bei der Ausgabeposition soll mit Einkommen verglichen werden
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,   -- EFB <= Erwerbseinkommen
                                                (SELECT ISNULL(SUM(CONVERT(MONEY, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                 FROM dbo.BgPosition              SBPO WITH (READUNCOMMITTED)
                                                   INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                 WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                   AND SBPO.BaPersonID = BPO.BaPersonID 
                                                   AND SBPT.BgGruppeCode = 3101
                                                   AND GETDATE() BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231') )
                                               )) -- fnMIN, SELECT
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode = 60901
                         THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
                       ELSE CONVERT(MONEY, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
                     END,
  BetragBudget     = CASE
                       WHEN SPT.BgPositionsartCode IN (32011, 32015, 32016, 32017, 32018, 32019)
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug -
                                                ISNULL((SELECT SUM(SBPO.Betrag - SBPO.Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                        FROM dbo.BgPosition             SBPO WITH (READUNCOMMITTED)
                                                          INNER JOIN dbo.BgPositionsart SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                        WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                          AND SBPT.BgPositionsartCode IN (32021, 32022, 32023) 
                                                          AND SBPO.MaxBeitragSD = $0.00
                                                          AND CASE 
                                                                WHEN BBG.MasterBudget = 1 THEN GETDATE() 
                                                                ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) 
                                                              END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231')
                                                       ), $0.00) -- SELECT, ISNULL
                                               ) -- fnMIN, 
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode IN (32021, 32022, 32023)
                         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG / KVG über Limit
                       WHEN SPT.BgPositionsartCode = 60901
                         THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
                       WHEN SPT.BgPositionsartCode BETWEEN 39100 AND 39199 --EFB
                            AND SPT.BgPositionsartCode != SPT.BgGruppeCode 
                            AND BPO.BgKategorieCode = 2 --nur bei der Ausgabeposition soll mit Einkommen verglichen werden
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,  -- EFB <= Erwerbseinkommen
                                                (SELECT ISNULL(SUM(CONVERT(MONEY, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                 FROM dbo.BgPosition              SBPO WITH (READUNCOMMITTED)
                                                   INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                 WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                   AND SBPO.BaPersonID = BPO.BaPersonID 
                                                   AND SBPT.BgGruppeCode = 3101
                                                   AND CASE 
                                                         WHEN BBG.MasterBudget = 1 THEN GETDATE()
                                                         ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                                                       END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231') )
                                               )) -- fnMIN, SELECT
                                     ) -- CONVERT
                       ELSE CONVERT(MONEY, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
                     END,
  BetragRechnung   = CASE
                       WHEN SPT.BgPositionsartCode IN (32011, 32015, 32016, 32017, 32018, 32019)
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - 
                                                ISNULL((SELECT SUM(SBPO.Betrag - SBPO.Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                        FROM dbo.BgPosition             SBPO WITH (READUNCOMMITTED)
                                                          INNER JOIN dbo.BgPositionsart SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                        WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                         AND SBPT.BgPositionsartCode IN (32021, 32022, 32023) 
                                                         AND SBPO.MaxBeitragSD = $0.00
                                                         AND CASE 
                                                               WHEN BBG.MasterBudget = 1 THEN GETDATE() 
                                                               ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) 
                                                             END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231')
                                                       ), $0.00) -- IsNULL,, SELECT
                                               ) -- fnMIN
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode BETWEEN 39100 AND 39199 --EFB
                            AND SPT.BgPositionsartCode != SPT.BgGruppeCode 
                            AND BPO.BgKategorieCode = 2 --nur bei der Ausgabeposition soll mit Einkommen verglichen werden
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.Betrag - BPO.Reduktion,   -- EFB <= Erwerbseinkommen
                                                (SELECT ISNULL(SUM(Betrag - Reduktion), $0.00)
                                                 FROM dbo.BgPosition              SBPO WITH (READUNCOMMITTED)
                                                   INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                 WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                   AND SBPO.BaPersonID = BPO.BaPersonID 
                                                   AND SBPT.BgGruppeCode = 3101
                                                   AND CASE 
                                                         WHEN BBG.MasterBudget = 1 THEN GETDATE() 
                                                         ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) 
                                                       END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231')
                                               )) -- fnMIN, SELECT
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode IN (32021, 32022, 32023)
                         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG
                       WHEN SPT.BgPositionsartCode = 60901
                         THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
                       ELSE BPO.Betrag - BPO.Reduktion
                     END

FROM dbo.BgPosition              BPO WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgBudget        BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = BPO.BgBudgetID
  LEFT  JOIN dbo.BgPositionsart  SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID

GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBgPosition.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBgPosition.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwShMassendruckPapierverfuegung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwShMassendruckPapierverfuegung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwShMassendruckPapierverfuegung
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwShMassendruckPapierverfuegung.sql $
  $Author: Lgreulich $
  $Modtime: 30.07.09 15:24 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Template für neue Views
  -
  RETURNS: .
  -
  TEST:    SELECT * FROM vwTable
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwShMassendruckPapierverfuegung.sql $
 * 
 * 5     30.07.09 15:24 Lgreulich
 * 
 * 4     30.07.09 15:08 Lgreulich
 * 
 * 3     30.07.09 14:16 Lgreulich
 * 
 * 2     30.07.09 12:40 Lgreulich
 * 
 * 1     15.07.09 12:36 Lgreulich
 * Für neue Abfrage Massendruck Papierverfügung
 * 
 * 
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwShMassendruckPapierverfuegung
AS

SELECT USR.UserID,
         FAL.BaPersonID,
         BDG.BgBudgetID,
         BDG.Monat,
         BDG.Jahr,
         FBL.KbBuchungID, --FBL.FlBelegID,

         SAR         = IsNull(USR.FirstName + ' ', '') + USR.LastName,
         Klient      = PRS.NameVorname,
         BudgetMonat = dbo.fnXMonat(BDG.Monat) + ' ' + CONVERT(varchar, BDG.Jahr),
         Intern      = (SELECT TOP 1 FKA.Buchungstext
                        FROM  dbo.KbBuchungKostenart FKA WITH (READUNCOMMITTED)                              
                        WHERE FKA.KbBuchungID = FBL.KbBuchungID
                        ORDER BY CASE
                          WHEN FKA.Buchungstext LIKE 'Grundbedarf 2%'  THEN -9
                          WHEN FKA.Buchungstext LIKE 'Grundbedarf%'    THEN -10
                          WHEN FKA.Buchungstext LIKE 'Nebenkosten%'    THEN 900
                          WHEN FKA.Buchungstext LIKE 'VVG%'            THEN 999
                          ELSE FKA.BgKostenartID
                        END), -- dadurch: Grundbedarf zuerst
         FBL.Betrag,
         SelPrint   = CONVERT(bit,0),
         SFP.BgFinanzplanID
  FROM   dbo.FaLeistung FAL WITH (READUNCOMMITTED)
         INNER JOIN dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) on SFP.FaLeistungID = FAL.FaLeistungID
         INNER JOIN dbo.BgBudget     BDG WITH (READUNCOMMITTED) on BDG.BgFinanzplanID = SFP.BgFinanzplanID
         INNER JOIN dbo.KbBuchung    FBL WITH (READUNCOMMITTED) on FBL.BgBudgetID = BDG.BgBudgetID
                                        AND FBL.KbAuszahlungsArtCode = 102 -- via Papierverfügung
                                        AND FBL.KbBuchungTypCode = 1 -- Budget
                                        AND FBL.KbBuchungStatusCode = 2 -- freigegeben
         INNER JOIN dbo.XUser        USR WITH (READUNCOMMITTED) on USR.UserID = FAL.UserID
         INNER JOIN dbo.vwPerson     PRS on PRS.BaPersonID = FAL.BaPersonID
 WHERE   FAL.ModulID = 3

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwShMassendruckPapierverfuegung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwShMassendruckPapierverfuegung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAbklPhasen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAbklPhasen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAbklPhasen
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  TEST: SELECT TOP 10 * FROM vwTmAbklPhasen
=================================================================================================*/

CREATE VIEW dbo.vwTmAbklPhasen
AS

WITH AbklaerungCte
AS
(
  SELECT IsIntake                       = 1,
         KaAbklaerungIntakeID           = KAI.KaAbklaerungIntakeID,
         KaAbklaerungVertieftID         = NULL,
         AsdFragen                      = KAI.AsdFragen,
         Gespraechstermin               = KAI.Gespraechstermin,
         KaAbklaerungGrundDossCode      = KAI.KaAbklaerungGrundDossCode,
         KaAbklaerungIntegrBeurCode     = KAI.KaAbklaerungIntegrBeurCode,
         DatumIntegration               = KAI.DatumIntegration,
         ModulCode                      = KAI.KaAbklaerungPhaseIntakeCode,
         Datum                          = KAI.Datum,
         Bemerkung                      = KAI.Bemerkung,
         KaKurserfassungID              = NULL,
         KaAbklaerungProbeeinsatzInCode = NULL,
         EinsatzVon                     = NULL,
         EinsatzBis                     = NULL         
  FROM dbo.KaAbklaerungIntake KAI WITH (READUNCOMMITTED) 
  
  UNION ALL
  
  SELECT IsIntake                       = 0,
         KaAbklaerungIntakeID           = NULL,
         KaAbklaerungVertieftID         = KAV.KaAbklaerungVertieftID,
         AsdFragen                      = NULL,
         Gespraechstermin               = NULL,
         KaAbklaerungGrundDossCode      = KAV.KaAbklaerungGrundDossCode,
         KaAbklaerungIntegrBeurCode     = KAV.KaAbklaerungIntegrBeurCode,
         DatumIntegration               = KAV.DatumIntegration,
         ModulCode                      = KAV.KaAbklaerungPhaseVertiefteAbklaerungenCode,
         Datum                          = KAV.Datum,
         Bemerkung                      = KAV.Bemerkung,
         KaKurserfassungID              = KAV.KaKurserfassungID,
         KaAbklaerungProbeeinsatzInCode = KAV.KaAbklaerungProbeeinsatzInCode,
         EinsatzVon                     = KAV.EinsatzVon,
         EinsatzBis                     = KAV.EinsatzBis
  FROM dbo.KaAbklaerungVertieft KAV WITH (READUNCOMMITTED) 
)

SELECT
  KaAKPhasenID          = ISNULL(CTE.KaAbklaerungIntakeID, CTE.KaAbklaerungVertieftID),
  IstIntake             = IsIntake,
  Fragestellungen       = CTE.AsdFragen,
  GrundDossier          = dbo.fnLOVText('KaAbklärungGrundDoss', CTE.KaAbklaerungGrundDossCode),
  IntegBeurteilung      = dbo.fnLOVText('KaAbklaerungIntegrBeur', CTE.KaAbklaerungIntegrBeurCode),
  DatumIntegBeurteilung = CTE.DatumIntegration,
  KursDatumBis          = ISNULL(CONVERT(VARCHAR(15), KUE.DatumBis, 104), ''),
  KursDatumVon          = ISNULL(CONVERT(VARCHAR(15), KUE.DatumVon, 104), ''),
  Phase                 = CASE WHEN CTE.IsIntake = 1 THEN dbo.fnLOVText('KaAbklaerungPhaseIntake', CTE.ModulCode)
                                                     ELSE dbo.fnLOVText('KaAbklaerungPhaseVertiefteAbklaerungen', CTE.ModulCode) 
                          END,
  PhaseDatum            = ISNULL(CONVERT(VARCHAR, CTE.Datum, 104), ' '),
  Rueckfragen           = CTE.Bemerkung,
  Kursnummer            = KUE.KursNr,
  EinsatzIn             = dbo.fnLOVText('KaAbklPhasenEinsatzin', CTE.KaAbklaerungProbeeinsatzInCode),
  EinsatzVon            = CTE.EinsatzVon,
  EinsatzBis            = CTE.EinsatzBis,
  Gespraechtstermin     = CTE.Gespraechstermin
FROM AbklaerungCte              CTE
  LEFT JOIN dbo.KaKurserfassung KUE WITH (READUNCOMMITTED) ON KUE.KaKurserfassungID = CTE.KaKurserfassungID
  LEFT JOIN dbo.KaKurs          KUR WITH (READUNCOMMITTED) ON KUR.KaKursID = KUE.KursID

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAbklPhasen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAbklPhasen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAdressat.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAdressat.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmAdressat;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <Beschreibung der View, Zweck und Einsatz>
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmAdressat;
=================================================================================================*/

CREATE VIEW dbo.vwTmAdressat
AS
SELECT FaDokumenteID     = FDO.FaDokumenteID,
       GeehrteFrauHerr   = CASE
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN 'Sehr geehrte Damen und Herren'
                             WHEN PRS.GeschlechtCode = 1 THEN 'Sehr geehrter Herr ' + PRS.Name
                             WHEN PRS.GeschlechtCode = 2 THEN 'Sehr geehrte Frau ' + PRS.Name
                             ELSE 'Sehr geehrte/-r Frau/Herr ' + PRS.Name
                           END,
       
       ErsteZeile        = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.NameVorname
                             ELSE PRS.VornameName
                           END,
                           
       AdresseMehrzeilig = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL
                               THEN ISNULL(INS.Anrede + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.NameVorname + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.Zusatz + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.StrasseHausNr + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.PostfachTextD + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.PLZOrt, '')

                              WHEN CNF.AdressatAdresse = 3 AND PRS.AufenthaltBaAdresseID IS NOT NULL
                               THEN ISNULL(PRS.Titel + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.VornameName + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltAdressZusatz + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltStrasseHausNr + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltPostfachD + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltPLZOrt + CHAR(13) + CHAR(10), '')


                             ELSE   ISNULL(PRS.Titel + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.VornameName + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzAdressZusatz + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzStrasseHausNr + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzPostfachD + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzPLZOrt, '')
                           END,
       
       Ort               = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.Ort
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltOrt, PRS.WohnsitzOrt)
                             ELSE PRS.WohnsitzOrt
                           END,
       PLZ               = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.PLZ
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltPLZ, PRS.WohnsitzPLZ)
                             ELSE PRS.WohnsitzPLZ
                           END,
       PLZOrt            = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.PLZOrt
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(NULLIF(PRS.AufenthaltPLZOrt, ''), PRS.WohnsitzPLZOrt)
                             ELSE PRS.WohnsitzPLZOrt
                           END,
       Strasse           = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.StrasseHausNr
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltStrasseHausNr, PRS.WohnsitzStrasseHausNr)
                             ELSE PRS.WohnsitzStrasseHausNr
                           END,
       Zusatzzeile       = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.Zusatz
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltAdressZusatz, PRS.WohnsitzAdressZusatz)
                             ELSE PRS.WohnsitzAdressZusatz
                           END,
       Fax               = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL
                               THEN INS.Fax
                             ELSE PRS.Fax
                           END
FROM dbo.FaDokumente          FDO  WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwPerson      PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = FDO.BaPersonID_Adressat
  LEFT JOIN dbo.vwInstitution INS  WITH (READUNCOMMITTED) ON INS.BaInstitutionID = FDO.BaInstitutionID_Adressat
  OUTER APPLY (SELECT AdressatAdresse = dbo.fnXConfig('System\Textmarken\AdressatAdresse', GETDATE())) CNF
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAdressat.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAdressat.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAllgemein.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAllgemein.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAllgemein
GO
/*===============================================================================================
  $Author: lloreggia $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmAllgemein.sql $
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmAllgemein
AS

SELECT	
    KaIntegBildungID = IBI.KaIntegBildungID,
    Bemerkungen      = IBI.Bemerkung,
    Kursabschluss    = dbo.fnLOVText('KaInteBildKursAbschl', IBI.AbschlussCode),
    Kursaustritt     = IsNull(CONVERT(varchar, IBI.Austritt, 104), ''),
    Kurseintritt     = IsNull(CONVERT(varchar, IBI.Eintritt, 104), ''),
    Kursname         = KUR.Name
FROM dbo.KaIntegBildung IBI WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.KaKurserfassung KUE WITH (READUNCOMMITTED) on KUE.KaKurserfassungID = IBI.KaKurserfassungID
  LEFT JOIN dbo.KaKurs KUR WITH (READUNCOMMITTED) on KUR.KaKursID = KUE.KursID;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAllgemein.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmAllgemein.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmErblasser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmErblasser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmErblasser
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwTmErblasser.sql $
  $Author: Ckaeser $
  $Modtime: 25.06.09 12:53 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmErblasser.sql $
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmErblasser
AS

SELECT FaLeistungID = ERB.FaLeistungID,
       AHVNr        = ERB.AHVNummer,
       DerDes       = CASE
                        WHEN ERB.Anrede LIKE '%frau%' THEN 'r'
                        WHEN ERB.Anrede LIKE '%herr%' THEN 's'
                      END,
       DerDesBesch  = CASE
                        WHEN ERB.Anrede like '%frau%' THEN 'r'
                        WHEN ERB.Anrede like '%herr%' THEN 's'
                      END,

       DieDer       = CASE
                        WHEN ERB.Anrede LIKE '%frau%' THEN 'die'
                        WHEN ERB.Anrede LIKE '%herr%' THEN 'der'
                        ELSE 'die/der'
                      END,
       DieDerBesch  = CASE
                        WHEN ERB.Anrede like '%frau%' THEN 'die'
                        WHEN ERB.Anrede like '%herr%' THEN 'der'
                        ELSE 'die/der'
                      END,

       Todesdatum                   = CONVERT(VARCHAR, ERB.Todesdatum, 104),
       TodesdatumBesch              = CONVERT(VARCHAR, ERB.Todesdatum, 104),
       TodesdatumOderBereich        = ISNULL(ERB.TodesDatumText, CONVERT(VARCHAR, ERB.Todesdatum,104)),
       Todesort                     = ERB.TodesOrt,

       ErblasserAdresseEinzeln      = ERB.Strasse + ISNULL(', ' + ERB.Ort, ''),
       ErblasserAdresseEinzelnBesch = ERB.Strasse + ISNULL(', ' + ERB.Ort, ''),
       ErblasserAnrede              = ERB.Anrede,
       ErblasserAnredeBesch         = ERB.Anrede,
       ErblasserElternnamen         = ERB.Elternnamen,
       ErblasserElternnamenBesch    = ERB.Elternnamen,
       ErblasserFamilienNamen       = ERB.FamilienNamen,
       ErblasserFamilienNamenBesch  = ERB.FamilienNamen,
       ErblasserGeburtsdatum        = CONVERT(VARCHAR, Geburtsdatum, 104),
       ErblasserGeburtsdatumBesch   = CONVERT(VARCHAR, Geburtsdatum, 104),
       ErblasserHeimatorte          = ERB.Heimatorte,
       ErblasserHeimatorteBesch     = ERB.Heimatorte,
       ErblasserVornamen            = ERB.Vornamen,
       ErblasserVornamenBesch       = ERB.Vornamen,
       ErblasserZivilstand          = ZIV.Text,
       ErblasserZivilstandBesch     = ERB.Zivilstand,
       lasserLasserin               = CASE
                                        WHEN ERB.Anrede LIKE '%frau%' THEN 'Erblasserin'
                                        WHEN ERB.Anrede LIKE '%herr%' THEN 'Erblasser'
                                      END,

       ErblasserInfo1      = ISNULL(ERB.Anrede + ' ', '') +
                             ISNULL(ERB.FamilienNamen + ' ', '') +
                             ISNULL(ERB.Vornamen, '') +
                             ISNULL(', ' + ERB.Elternnamen, '') +
                             ISNULL(', ' + ERB.Zivilstand, ISNULL(', ' + ZIV.Text, '')) +
                             ISNULL(', geb. ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + Heimatorte, '') +
                             ISNULL(', wohnhaft gewesen in ' + ERB.Ort + ISNULL(', ' + ERB.Strasse, ''), '') +
                             ISNULL(', mit Aufenthalt in ' + ERB.Aufenthalt, ''),
       ErblasserInfo2      = ISNULL('am ' + CONVERT(VARCHAR, ERB.TodesDatum, 104), '') +
                             ISNULL(' in ' + ERB.TodesOrt, '') + ' verstorbenen' +
                             ISNULL(' ' + ERB.Vornamen, '') +
                             ISNULL(' ' + ERB.FamilienNamen, '') +
                             ISNULL(', geb. ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + ERB.Heimatorte, '') +
                             ISNULL(', ' + ERB.Zivilstand, ISNULL(', ' + ZIV.Text, '')) +
                             ISNULL(', wohnhaft gewesen in ' + ERB.Ort + ISNULL(', ' + ERB.Strasse, ''), ''),
       ErblasserInfo3      = (ERB.Elternnamen + '') +
                             ISNULL(', ' + ERB.Zivilstand, ISNULL(', ' + ZIV.Text, '')) +
                             ISNULL(', geboren am ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + ERB.Heimatorte, '') +
                             ISNULL(', ' + ERB.Strasse, '') +
                             ISNULL(', ' + ERB.Ort, '') +
                             ISNULL(', Aufenthalt: ' + ERB.Aufenthalt, ''),
       ErblasserInfo4      = ISNULL(ERB.Anrede + ' ', '') +
                             ISNULL(ERB.FamilienNamen + ' ', '') +
                             ISNULL(ERB.Vornamen, '') +
                             ISNULL(', geb. ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + ERB.Heimatorte, '') +
                             ISNULL(', wohnhaft gewesen ' + ISNULL(ERB.Strasse + ', ', ''), '') + ERB.Ort

FROM dbo.VmErblasser     ERB WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.XLOVCode ZIV WITH (READUNCOMMITTED) ON ZIV.LOVName = 'VmErbeZivilstand'
                                                   AND ZIV.Code = ERB.ZivilstandCode;

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmErblasser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmErblasser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmInstitution.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmInstitution;
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <Beschreibung der View, Zweck und Einsatz>
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwTmInstitution;
=================================================================================================*/

CREATE VIEW dbo.vwTmInstitution
AS
SELECT BaInstitutionID      = INS.BaInstitutionID,
       InstitutionNr        = INS.InstitutionNr,
       [Name]               = INS.[Name],
       Vorname              = INS.Vorname,
       NameVorname          = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname),
       Telefon              = INS.Telefon,
       Fax                  = INS.Fax,
       EMail                = INS.EMail,
       Homepage             = INS.Homepage,
       --
       CareOf               = ADR.CareOf,
       AdressZusatz         = ADR.Zusatz,
       ZuhandenVon          = ADR.ZuhandenVon,
       Strasse              = ADR.Strasse,
       HausNr               = ADR.HausNr,
       Postfach             = ADR.Postfach,
       PostfachOhneNr       = ADR.PostfachOhneNr,
       PostfachTextD        = dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1),
       PLZ                  = ADR.PLZ,
       Ort                  = ADR.Ort,
       OrtschaftCode        = ADR.OrtschaftCode,
       Kanton               = ADR.Kanton,
       Bezirk               = ADR.Bezirk,
       --
       StrasseHausNr        = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       OrtStrasse           = ISNULL(ADR.Ort,'') + ISNULL(', ' + ADR.Strasse + ISNULL(' ' + ADR.HausNr,''), ''),
       PLZOrt               = ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       --
       LandD                = dbo.fnLandMLText(ADR.BaLandID, 1),
       LandF                = dbo.fnLandMLText(ADR.BaLandID, 2),
       LandI                = dbo.fnLandMLText(ADR.BaLandID, 3),
       LandE                = dbo.fnLandMLText(ADR.BaLandID, 4),
       --
       AdresseEinzeilig     = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname) + ', ' +
                              ISNULL(ADR.Zusatz + ', ', '') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr,'') + ', ', '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       AdresseEinzOhneName  = ISNULL(ADR.Zusatz + ', ','') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       AdresseMehrzeilig    = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname) + CHAR(13) + CHAR(10) +
                              ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       AdresseMehrzOhneName = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, '')
FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL);
GO

 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmInstitution.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetrieb.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetrieb.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaBetrieb;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für die Maske KA - Betriebe
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 10 * FROM vwTmKaBetrieb;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaBetrieb
AS
SELECT -- Betrieb
       KaBetriebID             = BET.KaBetriebID,
       [Name]                  = BET.BetriebName,
       AdressZusatz            = ADR.Zusatz,
       AdresseMehrzeilig       = ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       Land                    = LAN.Text,
       [TeilbetriebVon]        = TBE.BetriebName,
       Telefon                 = BET.Telefon,
       Fax                     = BET.Fax,
       [EMail]                 = BET.EMail,
       Internet                = BET.Homepage,
       Akt                     = BET.Aktiv,
       [AuVe]                  = BET.InAusbildungsverbund,
       Charakter               = dbo.fnLOVText('KaBetriebCharakter', BET.CharakterCode),
       
       -- Dokument 
       KaBetriebDokumentID     = BED.KaBetriebDokumentID,    
       DokDatum                = BED.Datum,
       DokStichworte           = BED.Stichwort,
       DokAbsenderVornameName  = CASE 
                                   WHEN BED.AbsenderID > 0 THEN USR.FirstName + ISNULL(' ' + USR.LastName, '')
                                   ELSE KON.Vorname + ISNULL(' ' + KON.Name, '')
                                 END,
       
       -- Kontakt
       DokAdressatAnrede       = CASE 
                                   WHEN BED.AdressatID > 0 THEN CASE USR1.GenderCode
                                                                  WHEN 1 THEN 'Herr'
                                                                  WHEN 2 THEN 'Frau'
                                                                  ELSE 'Frau/Herr'
                                                                END
                                   ELSE CASE KON1.GeschlechtCode
                                          WHEN 1 THEN 'Herr'
                                          WHEN 2 THEN 'Frau'
                                          ELSE 'Frau/Herr'
                                        END
                                 END,
       DokAdressatSehrGeehrte  = CASE 
                                   WHEN BED.AdressatID > 0 THEN CASE USR1.GenderCode
                                                                  WHEN 1 THEN 'Sehr geehrter Herr ' + ISNULL(USR1.LastName, '')
                                                                  WHEN 2 THEN 'Sehr geehrte Frau ' + ISNULL(USR1.LastName, '')
                                                                  ELSE 'Sehr geehrte/r Frau/Herr ' + ISNULL(USR1.LastName, '')
                                                                END
                                   ELSE CASE KON1.GeschlechtCode
                                          WHEN 1 THEN 'Sehr geehrter Herr ' + ISNULL(KON1.Name, '')
                                          WHEN 2 THEN 'Sehr geehrte Frau ' + ISNULL(KON1.Name, '')
                                          ELSE 'Sehr geehrte/r Frau/Herr ' + ISNULL(KON1.Name, '')
                                        END
                                 END,
       DokAdressatLieberLiebe  = CASE 
                                   WHEN BED.AdressatID > 0 THEN CASE USR1.GenderCode
                                                                  WHEN 1 THEN 'Lieber'
                                                                  WHEN 2 THEN 'Liebe'
                                                                  ELSE 'Lieber / Liebe'
                                                                END
                                   ELSE CASE KON1.GeschlechtCode
                                          WHEN 1 THEN 'Lieber'
                                          WHEN 2 THEN 'Liebe'
                                          ELSE 'Lieber / Liebe'
                                        END
                                 END,  
       DokAdressatName         = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.LastName
                                   ELSE KON1.Name
                                 END,
       DokAdressatVorname      = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.FirstName
                                   ELSE KON1.Vorname
                                 END,   
       DokAdressatVornameName  = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.FirstName + ISNULL(' ' + USR1.LastName, '')
                                   ELSE KON1.Vorname + ISNULL(' ' + KON1.Name, '')
                                 END,
       DokAdressatTel          = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.Phone
                                   ELSE KON1.Telefon
                                 END,
       DokAdressatMobil        = CASE 
                                   WHEN BED.AdressatID > 0 THEN ''
                                   ELSE KON1.TelefonMobil
                                 END,
       DokAdressatAdresseMehrz = CASE
                                   WHEN KON1.UseZusatzadresse IS NULL OR KON1.UseZusatzadresse = 0 THEN 
                                     ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, '')
                                   ELSE
                                     ISNULL(KADR.Strasse + ISNULL(' ' + KADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                     ISNULL(dbo.fnBaGetPostfachText(NULL, KADR.Postfach, KADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                     ISNULL(KADR.PLZ + ' ', '') + ISNULL(KADR.Ort, '')
                                 END
FROM dbo.KaBetrieb                BET  WITH (READUNCOMMITTED)
  LEFT JOIN dbo.KaBetriebDokument BED  WITH (READUNCOMMITTED) ON BET.KaBetriebID = BED.KaBetriebID
  LEFT JOIN dbo.XUser             USR  WITH (READUNCOMMITTED) ON USR.UserID = BED.AbsenderID
  LEFT JOIN dbo.KaBetriebKontakt  KON  WITH (READUNCOMMITTED) ON KON.KaBetriebKontaktID = -BED.AbsenderID
  LEFT JOIN dbo.XUser             USR1 WITH (READUNCOMMITTED) ON USR1.UserID = BED.AdressatID
  LEFT JOIN dbo.KaBetriebKontakt  KON1 WITH (READUNCOMMITTED) ON KON1.KaBetriebKontaktID = -BED.AdressatID   
  LEFT JOIN dbo.BaAdresse         ADR  WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('KaBetriebID', BET.KaBetriebID, NULL, NULL)
  LEFT JOIN dbo.BaAdresse         KADR WITH (READUNCOMMITTED) ON KADR.BaAdresseID = dbo.fnBaGetBaAdresseID('KaBetriebKontaktID', KON1.KaBetriebKontaktID, NULL, NULL)
  LEFT JOIN dbo.BaLand            LAN  WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID
  LEFT JOIN dbo.KaBetrieb         TBE  WITH (READUNCOMMITTED) ON TBE.KaBetriebID = BET.TeilbetriebID;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetrieb.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetrieb.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetriebVerlauf.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetriebVerlauf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmKaBetriebVerlauf
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwTmKaBetriebVerlauf.sql $
  $Author: Lgreulich $
  $Modtime: 28.08.09 11:52 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für die Maske KA - Betriebe Verlauf
  -
  RETURNS: .
  -
  TEST:    SELECT * FROM vwTmKaBetriebVerlauf
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmKaBetriebVerlauf.sql $
 * 
 * 1     28.08.09 12:00 Lgreulich
 * #4884 Neue Textmarken
 * 
 * 
 * 
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmKaBetriebVerlauf
AS

SELECT 
  KaBetriebBesprechungID,
  Datum         = BES.Datum,
  Kontaktperson = BEK.Name + IsNull(', ' + BEK.Vorname, ''),
  Autor         = USR.LastName + IsNull(', ' + USR.FirstName, ''),
  Stichwort     = BES.Stichwort  
FROM dbo.KaBetriebBesprechung     BES WITH (READUNCOMMITTED)
   LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = BES.AutorID
   LEFT JOIN dbo.KaBetriebKontakt BEK WITH (READUNCOMMITTED) ON BEK.KaBetriebKontaktID = BES.KontaktPersonID

GO 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetriebVerlauf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaBetriebVerlauf.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaEinsatzplatz.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaEinsatzplatz.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmKaEinsatzplatz
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwTmKaEinsatzplatz.sql $
  $Author: Lgreulich $
  $Modtime: 31.08.09 13:09 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für die Maske KA - Einsatzplatz
  -
  RETURNS: .
  -
  TEST:    SELECT * FROM vwTmKaEinsatzplatz
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmKaEinsatzplatz.sql $
 * 
 * 2     31.08.09 13:09 Lgreulich
 * 
 * 1     31.08.09 12:47 Lgreulich
 * 
 * 
 * 
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmKaEinsatzplatz
AS

SELECT
	-- Grundinformationen
	KaEinsatzplatzID    = EIN.KaEinsatzplatzID,
	Aktiv               = CASE WHEN EIN.Aktiv = 1 THEN 'aktiv' ELSE 'inaktiv' END,
	Bezeichnung         = EIN.Bezeichnung,
	Branche             = dbo.fnLOVText('KaBranche', EIN.BrancheCode),
	Betrieb             = BET.BetriebName,
	BetriebAdresse      = IsNull(ADR.Strasse, '') + IsNull(' ' + ADR.HausNr, '') + IsNull(', ' + ADR.PLZ, '') + IsNull(' ' + ADR.Ort, ''),
	Stellenbeschreibung = EIN.Details,
	KAProgramm          = dbo.fnLOVText('KaVermittlungProgramm', EIN.KAProgrammCode),
	ZustaendigKA        = USR.LastName + IsNull(', ' + USR.FirstName, ''),
	Lehrberuf           = dbo.fnLOVText('KaLehrberuf', EIN.LehrberufCode),
	TypAusbildung       = dbo.fnLOVText('KaBerufsausbildungTyp', EIN.BerufsausbildungTyp),
	NeuGeschLehrstelle  = CASE WHEN EIN.NeuGeschaffeneLehrstelle = 1 THEN 'ja' ELSE 'nein' END,
  
	-- Dauer/Pensum
	ErfasstAm        = EIN.ErfassungsDatum,
	EinsatzAb        = EIN.EinsatzAb,
	unbefristet      = CASE WHEN EIN.DauerUnbefristet = 1 THEN 'ja' ELSE 'nein' END,
	Gesamtpensum     = EIN.GesamtPensum,
	aufteilbar       = CASE WHEN EIN.PensumAufteilbar = 1 THEN 'ja' ELSE 'nein' END,
	PensumUnbestimmt = CASE WHEN EIN.PensumUnbestimmt = 1 THEN 'ja' ELSE 'nein' END,
	EinzelpensumVon  = EIN.EinzelpensumMinimum,
	EinzelpensumBis  = EIN.EinzelpensumMaximum,     
  
	-- Anforderungen
	Fuehrerausweis       = CASE WHEN EIN.Fuehrerausweis = 1 THEN 'ja' ELSE 'nein' END,
	FuehrerausweisKat    = dbo.fnLOVText('KaFuehrerausweisKategorie', EIN.FuehrerausweisKategorieCode),
	PCKenntnisse         = CASE WHEN EIN.PCKenntnisse = 1 THEN 'ja' ELSE 'nein' END,
	Geschlecht           = dbo.fnLOVText('KaEinsatzplatzGeschlecht', EIN.GeschlechtCode),
	WeitereAnforderungen = EIN.WeitereAnforderungen,
	DeutschMuendlich     = dbo.fnLOVText('KaDeutschkenntnisse', EIN.DeutschMuendlichCode),
	DeutschSchriftlich   = dbo.fnLOVText('KaDeutschkenntnisse', EIN.DeutschSchriftlichCode),
	Ausbildung           = dbo.fnLOVText('KaAusbildung', EIN.AusbildungCode),
   
	-- Kontaktperson
	Kontaktperson       = IsNull(Name + ', ', '') + IsNull(Vorname, ''),
	KontaktFunktion     = dbo.fnLOVText('KaEinsatzplatzKontaktFunktion', EIN.FunktionCode),            
	KontaktBemerkung    = EIN.Bemerkung,
	KontaktTelefon      = KON.Telefon,
	KontaktTelefonMobil = KON.TelefonMobil,
	KontaktFax          = KON.Fax,
	KontaktEMail        = KON.Email
      
FROM dbo.KaEinsatzplatz            EIN WITH (READUNCOMMITTED)
	LEFT JOIN dbo.KaBetrieb        BET WITH (READUNCOMMITTED) ON BET.KaBetriebID = EIN.KaBetriebID
	LEFT JOIN dbo.BaAdresse        ADR WITH (READUNCOMMITTED) ON ADR.KaBetriebID = BET.KaBetriebID
                             AND GetDate() BETWEEN IsNull(ADR.DatumVon, GetDate()) AND IsNull(ADR.DatumBis, GetDate())
	LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = EIN.ZustaendigKA
	LEFT JOIN dbo.KaBetriebKontakt KON WITH (READUNCOMMITTED) ON KON.KaBetriebKontaktID = EIN.KaKontaktpersonID 

GO 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaEinsatzplatz.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaEinsatzplatz.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmPerson;
GO
/*===============================================================================================
  $Revision: 28 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Textmarke KLIENT
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwTmPerson WITH (READUNCOMMITTED);
=================================================================================================*/

CREATE VIEW dbo.vwTmPerson
AS
SELECT BaPersonID           = PRS.BaPersonID,
       PersonenNr           = PRS.BaPersonID,
       Anrede               = PRS.Titel,
       [Name]               = PRS.Name,
       [FrühererName]       = PRS.FruehererName,
       Vorname              = PRS.Vorname,
       VornameName          = ISNULL(PRS.Vorname + ' ','') + PRS.[Name],
       Vorname2             = PRS.Vorname2,
       NameVorname          = PRS.[Name] + ISNULL(', '+PRS.Vorname,''),
       NameVornameOhneKomma = PRS.[Name] + ISNULL(' '+PRS.Vorname,''),
	   [NameGB]               = UPPER(RTRIM(PRS.Name)),
       NameGBVorname          = UPPER(RTRIM(PRS.Name)) + ISNULL(', '+PRS.Vorname,''),
       NameGBVornameOhneKomma = UPPER(RTRIM(PRS.Name)) + ISNULL(' '+PRS.Vorname,''),
       Nationalitaet        = CASE 
                                WHEN dbo.fnLandMLText(PRS.NationalitaetCode, NULL) IS NULL 
                                 AND GDE.Name IS NOT NULL  THEN 'Schweiz' -- Nationalität leer + Heimatort erfasst => 'Schweiz'
                                ELSE dbo.fnLandMLText(PRS.NationalitaetCode, NULL)
                              END,
       GeschlechtCode       = PRS.GeschlechtCode,
       Geschlecht           = dbo.fnLOVText('Geschlecht', PRS.GeschlechtCode),

       Geburtsdatum                 = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
       GeburtsdatumAmerikanisch     = CONVERT(VARCHAR, PRS.Geburtsdatum, 111),
       GestorbenAm                  = CONVERT(VARCHAR, PRS.Sterbedatum, 104),
       AHVNummer                    = PRS.AHVNummer,
       Versichertennummer           = PRS.Versichertennummer,
       VersichertennummerSonstAHVNr = ISNULL(PRS.Versichertennummer, PRS.AHVNummer),

       BemerkungOhneFmt       = PRS.Bemerkung,  --ohne RTF-Formatierung
       BemerkungMitFmt        = PRS.Bemerkung,  --mit RTF-Formatierung

       NNummer                = PRS.NNummer,
       BFFNummer              = PRS.BFFNummer,
       HaushaltVersicherungsNummer = PRS.HaushaltVersicherungsNummer,
       
       Konfession             = dbo.fnLOVText('Konfession', PRS.KonfessionCode),
       Heimatort              = GDE.Name + ISNULL(' ' + GDE.Kanton, ''),
       HeimatortNationalitaet = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, NULL) END,
       HeimatortNationalitaetD = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, 1) END,
       HeimatortNationalitaetF = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, 2) END,
       HeimatortNationalitaetI = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, 3) END,
       PLZHeimatort           = ISNULL(CONVERT(VARCHAR, GDE.PLZ) + ' ','') + GDE.Name,
       
       Sprache                = dbo.fnLOVText('BaMuttersprache', PRS.SprachCode),
       SpracheVertsaendigung  = dbo.fnLOVText('BaVerstaendigungsSprache', PRS.VerstaendigungSprachCode),
       
       Permis                 = dbo.fnLOVText('Aufenthaltsstatus', PRS.AuslaenderStatusCode),
       PermisBis              = CONVERT(VARCHAR, PRS.AuslaenderStatusGueltigBis, 104),
       PermisSeit             = CONVERT(VARCHAR, PRS.ErteilungVA, 104) ,
       
       AufenthaltGueltigBis   = CONVERT(VARCHAR,PRS.AuslaenderStatusGueltigBis,104),
       -- TODO: (IBE)BaPerson.inCHseit vs. (BSS)BaPerson.AuslaenderStatusDatum
       InCHseit               = CONVERT(VARCHAR, PRS.inCHseit, 104),
       EndeZustaendigkeit     = CONVERT(VARCHAR, PRS.CAusweisDatum, 104),
       
       TelefonP               = PRS.Telefon_P,
       TelefonG               = PRS.Telefon_G,
       TelefonMobil           = PRS.MobilTel,
       EMail                  = PRS.EMail,
       Fax                    = PRS.Fax,
       Navigatorzusatz        = PRS.Navigatorzusatz,
       
       WegzugDatum            = PRS.WegzugDatum,
       WegzugOrt              = PRS.WegzugOrt,
       WegzugPLZ              = PRS.WegzugPLZ,
       
       Zivilstand             = dbo.fnLOVText('Zivilstand', PRS.ZivilstandCode),
       ZivilstandD =dbo.fnGetLOVMLText('Zivilstand',PRS.ZivilstandCode,1), 
       ZivilstandF =dbo.fnGetLOVMLText('Zivilstand',PRS.ZivilstandCode,2), 
       ZivilstandI =dbo.fnGetLOVMLText('Zivilstand',PRS.ZivilstandCode,3), 
       ZivilstandSeit         = CONVERT(VARCHAR,PRS.ZivilstandDatum ,104),
       ZuzugDatum             = PRS.ZuzugGdeDatum,
       ZuzugOrt               = PRS.ZuzugGdeOrt,
       ZuzugPLZ               = PRS.ZuzugGdePLZ,
       ZEMISNummer            = PRS.ZEMISNummer,
       
       ------------------------------------------------------------------------
       -- Texte
       ------------------------------------------------------------------------
       ErSie                = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'er'
                                WHEN 2 THEN 'sie'
                                ELSE 'er / sie'
                              END,
       ErSieGross           = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Er'
                                WHEN 2 THEN 'Sie'
                                ELSE 'Er / Sie'
                              END,
       HerrFrau             = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herr'
                                WHEN 2 THEN 'Frau'
                                ELSE ''
                              END,
       HerrFrauName         = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herr '
                                WHEN 2 THEN 'Frau '
                                ELSE ' '
                              END + PRS.Name,
       GeehrterHerrFrau     = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Sehr geehrter Herr'
                                WHEN 2 THEN 'Sehr geehrte Frau'
                                ELSE 'Sehr geehrte/-r Frau/Herr'
                              END,
       GeehrterHerrFrauName = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Sehr geehrter Herr '
                                WHEN 2 THEN 'Sehr geehrte Frau '
                                ELSE 'Sehr geehrte/-r Frau/Herr '
                              END + PRS.Name,
       HerrnFrau            = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herrn'
                                WHEN 2 THEN 'Frau'
                                ELSE ''
                              END,
       HerrnFrauName        = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herrn '
                                WHEN 2 THEN 'Frau '
                                ELSE ' '
                              END + PRS.Name,
       FrauHerrVornameName  = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herr '
                                WHEN 2 THEN 'Frau '
                                ELSE ''
                              END + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
       IhmIhr               = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'ihm'
                                WHEN 2 THEN 'ihr'
                                ELSE 'ihm / ihr'
                              END,
       LieberLiebe          = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Lieber'
                                WHEN 2 THEN 'Liebe'
                                ELSE 'Lieber / Liebe'
                              END,
       SeinIhr              = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'sein'
                                WHEN 2 THEN 'ihr'
                                ELSE 'sein / ihr'
                              END,
       SeineIhre            = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'seine'
                                WHEN 2 THEN 'ihre'
                                ELSE 'seine / ihre'
                              END,
       SeinerIhrer          = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'seiner'
                                WHEN 2 THEN 'ihrer'
                                ELSE 'seiner / ihrer'
                              END,
       -- TODO: Auf IBE war es 'Der Projektteilnehmer / Die Projektteilnehmerin'
       ProjektteilnehmerIn  = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Stellensuchender'
                                WHEN 2 THEN 'Stellensuchende'
                                ELSE 'Stellensuchender / Stellensuchende'
                              END,
       TeilnehmerIn         = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Der Teilnehmer'
                                WHEN 2 THEN 'Die Teilnehmerin'
                                ELSE 'Der Teilnehmer / Die Teilnehmerin'
                              END,
       
       ------------------------------------------------------------------------
       -- BaAdresse: Aufenthalt
       ------------------------------------------------------------------------
       AufenthaltsortAdresseEinzeilig     = PRS.Vorname + ' ' + PRS.Name + ', ' +
                                            ISNULL(ADRA.Zusatz + ', ','') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + ', ','') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortAdresseEinzOhneName  = ISNULL(ADRA.Zusatz + ', ','') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + ', ','') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortAdresseMehrzeilig    = PRS.Vorname + ' ' + PRS.Name + CHAR(13) + CHAR(10) +
                                            ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10),'') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + CHAR(13) + CHAR(10),'') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortAdresseMehrzOhneName = ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10),'') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + CHAR(13) + CHAR(10),'') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortStrasseNr            = ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,''),
       AufenthaltsortPLZOrt               = ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltWohnortAdrEinzeilig      = PRS.Vorname + ' ' + PRS.Name + ', ' +
                                            CASE
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + ', ', '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                                     ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + ', ', '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + ', ', '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnortAdrEinzOhneName   = CASE 
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + ', ', '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                                     ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + ', ', '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + ', ', '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnortAdrMehrzeilig     = PRS.Vorname + ' ' + PRS.Name + CHAR(13) + CHAR(10) +
                                            CASE
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnortAdrMehrzOhneName  = CASE
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnsitzStrasseNr        = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '')
                                              ELSE ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '')
                                            END,
       AufenthaltWohnsitzPLZOrt           = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnsitzPLZ              = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ADRW.PLZ
                                              ELSE ADRA.PLZ
                                            END,
       AufenthaltWohnsitzOrt              = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ADRW.Ort
                                              ELSE ADRA.Ort
                                            END,
       AufenthaltPostfachD                = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1),
       AufenthaltPostfachF                = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 2),
       AufenthaltPostfachI                = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 3),

       AufenthaltInstitutionName          = ADRA.CareOf,

       ------------------------------------------------------------------------
       -- BaAdresse: Wohnsitz
       ------------------------------------------------------------------------
       WohnsitzAdresseEinzeilig           = PRS.Vorname + ' ' + PRS.Name + ', ' +
                                            ISNULL(ADRW.Zusatz + ', ', '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, ''),
	   WohnsitzAdresseEinzeiligGB         = PRS.Vorname + ' ' + UPPER(RTRIM(PRS.Name)) + ', ' +
                                            ISNULL(ADRW.Zusatz + ', ', '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, ''),
       WohnsitzAdresseEinzOhneName        = ISNULL(ADRW.Zusatz + ', ','') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
       WohnsitzAdresseMehrzeilig          = PRS.Vorname + ' ' + PRS.Name + CHAR(13) + CHAR(10) +
                                            ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
       WohnsitzAdresseMehrzOhneName       = ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
       WohnsitzStrasseNr                  = ADRW.Strasse + ISNULL(' ' + ADRW.HausNr,''),
       WohnsitzPLZOrt                     = ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, ''),
       WohnsitzOrt                        = ADRW.Ort,
       WohnsitzPLZ                        = ADRW.PLZ,
       WohnsitzPostfachD                  = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1),
       WohnsitzPostfachF                  = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 2),
       WohnsitzPostfachI                  = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 3),
       
       ------------------------------------------------------------------------
       -- BaWohnsituation
       ------------------------------------------------------------------------
       Wohnsituation   = dbo.fnLOVText('Wohnstatus', ADRW.WohnStatusCode),
       Wohnungsgroesse = dbo.fnLOVText('Wohnungsgroesse', ADRW.WohnungsgroesseCode),
       
       ------------------------------------------------------------------------
       -- BaArbeitAusbildung
       ------------------------------------------------------------------------
       ArbeitslosSeit   = CONVERT(VARCHAR, ARB.StempelDatum, 104),
       AusgesteuertSeit = CONVERT(VARCHAR, ARB.AusgesteuertDatum, 104),
       Beruf            = CASE PRS.GeschlechtCode
                            WHEN 1 THEN BERB.BezeichnungM
                            WHEN 2 THEN BERB.BezeichnungW
                            ELSE BERB.Beruf
                          END,
       ErlernterBeruf   = CASE PRS.GeschlechtCode
                            WHEN 1 THEN BERE.BezeichnungM
                            WHEN 2 THEN BERE.BezeichnungW
                            ELSE BERE.Beruf
                          END,
       Schulbildung     = dbo.fnLOVText('Ausbildungstyp', ARB.HoechsteAusbildungCode),
       
       ------------------------------------------------------------------------
       -- Vermieter
       ------------------------------------------------------------------------
       VermieterName                 = INSM.[Name],
       VermieterAdresseEinzOhneName  = ISNULL(ADRM.Zusatz + ', ', '') +
                                       ISNULL(ADRM.Strasse + ISNULL(' ' + ADRM.HausNr, '') + ', ', '') +
                                       ISNULL(ADRM.PLZ + ' ', '') + ISNULL(ADRM.Ort, ''),
       VermieterAdresseMehrzOhneName = ISNULL(ADRM.Zusatz + CHAR(13) + CHAR(10), '') +
                                       ISNULL(ADRM.Strasse + ISNULL(' ' + ADRM.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                       ISNULL(ADRM.PLZ + ' ', '') + ISNULL(ADRM.Ort, ''),
       VermieterAdresseStrasseNr     = ADRM.Strasse + ISNULL(' ' + ADRM.HausNr,''),
       VermieterAdressePLZOrt        = ISNULL(ADRM.PLZ + ' ','') + ISNULL(ADRM.Ort, ''),
       VermieterAdressePLZ           = ADRM.PLZ,
       VermieterAdresseOrt           = ADRM.Ort,

       ------------------------------------------------------------------------
       -- KVG
       ------------------------------------------------------------------------
       KVGName                = INSK.[Name],
       KVGMitgliedNr          = GES.KVGMitgliedNr,
       KVGAdresseEinzOhneName = ISNULL(ADRK.Zusatz + ', ', '') +
                                ISNULL(ADRK.Strasse + ISNULL(' ' + ADRK.HausNr, '') + ', ', '') +
                                ISNULL(ADRK.PLZ + ' ', '') + ISNULL(ADRK.Ort, ''),
       
       ------------------------------------------------------------------------
       -- VVG
       ------------------------------------------------------------------------
       VVGName                = INSV.[Name],
       VVGMitgliedNr          = GES.VVGMitgliedNr,
       VVGAdresseEinzOhneName = ISNULL(ADRV.Zusatz + ', ', '') +
                                ISNULL(ADRV.Strasse + ISNULL(' ' + ADRV.HausNr, '') + ', ', '') +
                                ISNULL(ADRV.PLZ + ' ', '') + ISNULL(ADRV.Ort, ''),
       
       ------------------------------------------------------------------------
       -- Ehepartner
       ------------------------------------------------------------------------
       EhepartnerNachname           = PRSE.Name,
       EhepartnerVorname            = PRSE.Vorname,
       EhepartnerVorname2           = PRSE.Vorname2,
       EhepartnerNachnameVorname    = PRSE.NAME + ISNULL(' ' + PRSE.Vorname,''),
       EhepartnerNNummer            = PRSE.NNummer,
       EhepartnerBFFNummer          = PRSE.BFFNummer,
       --EhepartnerAufenthaltsstatusCode = PRSE.NNummer,
       -- TODO: (IBE)BaPerson.inCHseit vs. (BSS)BaPerson.AuslaenderStatusDatum
       EhepartnerInCHseit           = CONVERT(VARCHAR, PRSE.inCHseit, 104),
       EhepartnerNationalitaet        = CASE 
                                          WHEN dbo.fnLandMLText(PRSE.NationalitaetCode, NULL) IS NULL 
                                            AND PRSE.HeimatgemeindeBaGemeindeID IS NOT NULL  THEN 'Schweiz' -- Nationalität leer + Heimatort erfasst => 'Schweiz'
                                          ELSE dbo.fnLandMLText(PRSE.NationalitaetCode, NULL)
                                        END,
       EhepartnerZivilstand         = dbo.fnLOVText('Zivilstand', PRSE.ZivilstandCode),       
       EhepartnerBeruf              = CASE PRSE.GeschlechtCode
                                        WHEN 1 THEN BERBE.BezeichnungM
                                        WHEN 2 THEN BERBE.BezeichnungW
                                        ELSE BERBE.Beruf
                                      END,
       EhepartnerEndeZustaendigkeit = CONVERT(VARCHAR, PRSE.CAusweisDatum, 104),
       EhepartnerErteilungVA        = CONVERT(VARCHAR, PRSE.ErteilungVA, 104),
       EhepartnerGeschlecht         = dbo.fnLOVText('Geschlecht', PRSE.GeschlechtCode),
       EhepartnerPermis             = dbo.fnLOVText('Aufenthaltsstatus', PRSE.AuslaenderStatusCode),
       EhepartnerPersonenNummer     = PRSE.BaPersonID,
       EhepartnerGebDatum           = CONVERT(VARCHAR, PRSE.Geburtsdatum, 104),
       EhepartnerAHVNummer          = PRSE.AHVNummer,
       EhepartnerVersichertennummer = PRSE.Versichertennummer,
       EhepartnerAnrede             = PRSE.Titel,
       EhepartnerPLZOrt             = ISNULL(ADRE.PLZ + ' ', '') + ISNULL(ADRE.Ort, ''),
       EhepartnerStrasseNr          = ADRE.Strasse + ISNULL(' ' + ADRE.HausNr, ''),
       EhepartnerStrassePLZOrt      = ISNULL(ADRE.Strasse + ISNULL(' ' + ADRE.HausNr, '') + ', ', '') + ISNULL(ADRE.PLZ + ' ', '') + ISNULL(ADRE.Ort, ''),
       
       ------------------------------------------------------------------------
       -- Kostenstelle
       ------------------------------------------------------------------------
       Kostenstelle = dbo.fnKbGetKostenstelle(PRS.BaPersonID)
FROM dbo.BaPerson                  PRS  WITH (READUNCOMMITTED)
  -- Wohnsitz
  LEFT JOIN dbo.BaAdresse          ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)

  -- Aufenthalt
  LEFT JOIN dbo.BaAdresse          ADRA WITH (READUNCOMMITTED) ON ADRA.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 3, NULL)
  
  -- others
  LEFT JOIN dbo.BaArbeitAusbildung ARB  WITH (READUNCOMMITTED) ON ARB.BaPersonID = PRS.BaPersonID
  LEFT JOIN dbo.BaBeruf            BERB WITH (READUNCOMMITTED) ON BERB.BaBerufID = ARB.BerufCode
  LEFT JOIN dbo.BaBeruf            BERE WITH (READUNCOMMITTED) ON BERE.BaBerufID = ARB.ErlernterBerufCode
  LEFT JOIN dbo.BaGemeinde         GDE  WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  LEFT JOIN dbo.BaGesundheit       GES  WITH (READUNCOMMITTED) ON GES.BaPersonID = PRS.BaPersonID
                                                              AND GES.Jahr = (SELECT TOP 1 Jahr 
                                                                              FROM dbo.BaGesundheit WITH (READUNCOMMITTED) 
                                                                              WHERE BaPersonID = PRS.BaPersonID 
                                                                              ORDER BY Jahr DESC)
  LEFT JOIN dbo.BaInstitution      INSK WITH (READUNCOMMITTED) ON GES.KVGOrganisationID = INSK.BaInstitutionID
  LEFT JOIN dbo.BaAdresse          ADRK WITH (READUNCOMMITTED) ON ADRK.BaInstitutionID = INSK.BaInstitutionID
  LEFT JOIN dbo.BaInstitution      INSV WITH (READUNCOMMITTED) ON GES.VVGOrganisationID  = INSV.BaInstitutionID
  LEFT JOIN dbo.BaAdresse          ADRV WITH (READUNCOMMITTED) ON ADRV.BaInstitutionID = INSV.BaInstitutionID
  
  -- Miete
  LEFT JOIN dbo.BaMietvertrag      MIE  WITH (READUNCOMMITTED) ON MIE.BaPersonID = PRS.BaPersonID
  LEFT JOIN dbo.BaInstitution      INSM WITH (READUNCOMMITTED) ON INSM.BaInstitutionID = MIE.BaInstitutionID
  LEFT JOIN dbo.BaAdresse          ADRM WITH (READUNCOMMITTED) ON ADRM.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INSM.BaInstitutionID, NULL, NULL)
  
  -- Ehepartner
  LEFT JOIN dbo.BaPerson           PRSE WITH (READUNCOMMITTED) ON PRSE.BaPersonID = (SELECT TOP 1 
                                                                                            CASE
                                                                                              WHEN R.BaPersonID_2 = PRS.BaPersonID THEN R.BaPersonID_1
                                                                                              ELSE R.BaPersonID_2
                                                                                            END
                                                                                     FROM dbo.BaPerson_Relation R
                                                                                     WHERE (R.BaPersonID_1 = PRS.BaPersonID OR R.BaPersonID_2 = PRS.BaPersonID)
                                                                                       AND R.BaRelationID IN (13, 14, 15) -- Ehepaar, rechtliche Partnerschaft, Konkubinatspaar
                                                                                       AND dbo.fnDateOf(GETDATE()) BETWEEN ISNULL(R.DatumVon, dbo.fnDateOf(GETDATE())) AND ISNULL(R.DatumBis, dbo.fnDateOf(GETDATE()))
                                                                                    ORDER BY R.BaRelationID ASC, R.DatumVon DESC)
  LEFT JOIN dbo.BaAdresse          ADRE WITH (READUNCOMMITTED) ON ADRE.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRSE.BaPersonID, 1, NULL)  -- wohnsitz
  LEFT JOIN dbo.BaArbeitAusbildung ARBE WITH (READUNCOMMITTED) ON ARBE.BaPersonID = PRSE.BaPersonID
  LEFT JOIN dbo.BaBeruf            BERBE WITH (READUNCOMMITTED) ON BERBE.BaBerufID = ARBE.BerufCode;

GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmPerson.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaVermittlung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaVermittlung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaVermittlung;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken-View für Tabelle KaVermittlungSI / KaVermittlungBIBIP
  -
  RETURNS: 
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKaVermittlung;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaVermittlung
AS
SELECT
  -----------------------------------------------------------------------------
  -- Allgemein
  -----------------------------------------------------------------------------
  BaPersonID = PRS.BaPersonID,
  -----------------------------------------------------------------------------
  -- SI
  -----------------------------------------------------------------------------
  --SIID                  = VSI.KaVermittlungSIID,
  SIZuweiserVornameName = SUS.VornameName,
  SIZuweiserAnrede      = CASE
                          WHEN SUS.GenderCode = 1 THEN 'Herr'
                          WHEN SUS.GenderCode = 2 THEN 'Frau'
                          ELSE ''
                        END,
  SIZuweiserSektion     = SUS.OrgEinheitName,
  -----------------------------------------------------------------------------
  -- BI/BIP
  -----------------------------------------------------------------------------
  --BIBIPID                  = VBI.KaVermittlungBIBIPID,
  BIBIPZuweiserVornameName = BUS.VornameName,
  BIBIPZuweiserAnrede      = CASE
                               WHEN BUS.GenderCode = 1 THEN 'Herr'
                               WHEN BUS.GenderCode = 2 THEN 'Frau'
                               ELSE ''
                             END,
  BIBIPZuweiserSektion     = BUS.OrgEinheitName

FROM dbo.BaPerson                  PRS WITH(READUNCOMMITTED)
  LEFT JOIN dbo.FaLeistung         LBI WITH(READUNCOMMITTED) ON LBI.BaPersonID = PRS.BaPersonID
                                                            AND LBI.FaProzessCode = 705 -- Vermittlung BIBIP
                                                            AND ISNULL(LBI.DatumBis, '99990101') > GETDATE()
  LEFT JOIN dbo.KaVermittlungBIBIP VBI WITH(READUNCOMMITTED) ON VBI.FaLeistungID = LBI.FaLeistungID
  LEFT JOIN dbo.vwUser             BUS                       ON BUS.UserID = -VBI.ZuweiserID
  LEFT JOIN dbo.FaLeistung         LSI WITH(READUNCOMMITTED) ON LSI.BaPersonID = PRS.BaPersonID
                                                            AND LSI.FaProzessCode = 706 -- Vermittlung SI
                                                            AND ISNULL(LSI.DatumBis, '99990101') > GETDATE()
  LEFT JOIN dbo.KaVermittlungSI    VSI WITH(READUNCOMMITTED) ON VSI.FaLeistungID = LSI.FaLeistungID
  LEFT JOIN dbo.vwUser             SUS                       ON SUS.UserID = -VSI.ZuweiserID
WHERE VSI.KaVermittlungSIID IS NOT NULL
   OR VBI.KaVermittlungBIBIPID IS NOT NULL;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaVermittlung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKaVermittlung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungEinsatz.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungEinsatz.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVermittlungEinsatz;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Textmarken/vwTmVermittlungEinsatz.sql $
  $Author: Cjaeggi $
  $Modtime: 20.07.10 16:06 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 100 * FROM dbo.vwTmVermittlungEinsatz WITH (READUNCOMMITTED); 
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/Textmarken/vwTmVermittlungEinsatz.sql $
 * 
 * 5     20.07.10 16:07 Cjaeggi
 * #4167: Renamed column LandCode to BaLandID
 * 
 * 4     13.07.10 13:36 Cjaeggi
 * #4167: Fixed view after changes of BaAdresse, Refactoring
 * 
 * 3     6.08.09 10:24 Spsota
 * Views angepasst für neue Tabelle BaLand
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmVermittlungEinsatz
AS
SELECT KaVermittlungEinsatzID      = EIN.KaVermittlungEinsatzID,
       KaVermittlungVorschlagID    = EIN.KaVermittlungVorschlagID,
       KaEinsatzplatzID            = VOR.KaEinsatzplatzID,
       FaLeistungID                = VOR.FaLeistungID,
       EinsatzVon                  = EIN.EinsatzVon,
       EinsatzBis                  = EIN.EinsatzBis,
       Verlaengerung               = EIN.Verlaengerung,
       Arbeitspensum               = EIN.Arbeitspensum,
       BIEAZDatumVon               = EIN.BIEAZDatumVon,
       BIEAZDatumBis               = EIN.BIEAZDatumBis,
       BIEAZVerl                   = EIN.BIEAZVerlaengert,
       BIBruttolohn                = EIN.BIBruttolohn,
       BIEAZFinanzierungsgrad      = EIN.BIFinanzierungsgradEAZ,
       Abschluss                   = EIN.Abschluss,
       
       -- Zuständig KA
       ZustKANachname              = USR.LastName,
       ZustKAVorname               = USR.FirstName,
       ZustKAKuerzel               = USR.ShortName,
       ZustKATelephon              = USR.Phone,
       ZustKAEMail                 = USR.EMail,
       ZustKANameVorname           = USR.LastName + ISNULL(', ' + USR.FirstName, ''),
       ZustKANameVornameOhneKomma  = USR.LastName + ISNULL(' ' + USR.FirstName, ''),
       ZustKAVornameName           = ISNULL(USR.FirstName + ' ', '') + USR.LastName,
       
       -- Einsatzplatz
       Einsatzplatz                = EIP.Bezeichnung,
       EPBranche                   = dbo.fnLOVText('KaBranche', EIP.BrancheCode),
       EPKaProgramm                = dbo.fnLOVText('KaVermittlungProgramm', EIP.KaProgrammCode),
       EPLehrberuf                 = dbo.fnLOVText('KaLehrberuf', EIP.LehrberufCode),
       EPBerufsausbildung          = dbo.fnLOVText('KaBerufsausbildungTyp', EIP.BerufsAusbildungTyp),
       
       -- Betrieb
       Betrieb                     = BET.BetriebName,
       BetriebAdressZusatz         = ADR.Zusatz,
       BetriebStrasse              = ADR.Strasse,
       BetriebHausNr               = ADR.HausNr,
       BetriebPostfach             = ADR.Postfach,
       BetriebPLZ                  = ADR.PLZ,
       BetriebOrt                  = ADR.Ort,
       BetriebKanton               = ADR.Kanton,
       BetriebLand                 = LAN.Text,
       BetriebAdresseMehrzeilig    = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.Postfach + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       -- Betrieb-Kontakt
       KontaktTitel                = KON.Titel,
       KontaktName                 = KON.Name,
       KontaktVorname              = KON.Vorname,
       KontaktGeschlecht           = dbo.fnLOVText('Geschlecht', KON.GeschlechtCode),
       KontaktTelefon              = KON.Telefon,
       KontaktTelefonMobil         = KON.TelefonMobil,
       KontaktFax                  = KON.Fax,
       KontaktEmail                = KON.EMail,
       KontaktNameVorname          = ISNULL(KON.Name + ', ', '') + ISNULL(KON.Vorname, ''),
       KontaktVornameName          = ISNULL(KON.Vorname + ' ', '') + ISNULL(KON.Name, ''),
       KontaktLieberLiebe          = CASE KON.GeschlechtCode
                                       WHEN 1 THEN 'Lieber'
                                       WHEN 2 THEN 'Liebe'
                                       ELSE 'Lieber / Liebe'
                                     END
FROM dbo.KaVermittlungEinsatz          EIN WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.KaVermittlungVorschlag VOR WITH (READUNCOMMITTED) ON VOR.KaVermittlungVorschlagID = EIN.KaVermittlungVorschlagID
  LEFT JOIN dbo.KaEinsatzplatz         EIP WITH (READUNCOMMITTED) ON EIP.KaEinsatzplatzID = VOR.KaEinsatzplatzID
  LEFT JOIN dbo.KaBetrieb              BET WITH (READUNCOMMITTED) ON BET.KaBetriebID = EIP.KaBetriebID
  LEFT JOIN dbo.BaAdresse              ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('KaBetriebID', EIP.KaBetriebID, NULL, NULL)
  LEFT JOIN dbo.KaBetriebKontakt       KON WITH (READUNCOMMITTED) ON KON.KaBetriebKontaktID = EIP.KaKontaktpersonID
  LEFT JOIN dbo.vwUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = EIP.ZustaendigKA
  LEFT JOIN dbo.BaLand                 LAN WITH (READUNCOMMITTED) ON ADR.BaLandID = LAN.BaLandID;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungEinsatz.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungEinsatz.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungProfil.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungProfil.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmVermittlungProfil
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmVermittlungProfil
AS

SELECT	KaVermittlungProfilID		= PRO.KaVermittlungProfilID,
		LeistungID					= PRO.FaLeistungID,
		Branchen					= REPLACE(dbo.fnLOVTextListe('KaBranche', PRO.BrancheCodes), ',', char(13) + char(10)),
		Betriebe					= REPLACE(dbo.fnLOVTextListe('KaVermittlungKaBetriebe', PRO.KaBetriebCodes), ',', char(13) + char(10)),
		Einsatzbereiche				= REPLACE(dbo.fnLOVTextListe('KaVermittlungEinsatzbereich', PRO.EinsatzbereichCodes), ',', char(13) + char(10)),
		Lehrberuf					= dbo.fnLOVText('KaLehrberuf', PRO.LehrberufCode),
		[DeutschMuendlich]			= dbo.fnLOVText('KaDeutschkenntnisse', PRO.DeutschMuendlichCode),
		[DeutschSchriftlich]		= dbo.fnLOVText('KaDeutschkenntnisse', PRO.DeutschSchriftlichCode),
		[AmTelVerst]				= PRO.KannSichAmTelVerstaendigen,
		Sprachstandermittlung		= dbo.fnLOVText('KaVermittlungSprachstandermittlung', PRO.Sprachstandermittlung),
		[VermittelbarkeitBIBIP]		= dbo.fnLOVText('KaVermittlungBIBIPVermittelbarkeit', PRO.VermittelbarkeitBIBIPCode),
		[VermittelbarkeitSI]		= dbo.fnLOVText('KaVermittlungSiVermittelbarkeit', PRO.VermittelbarkeitSICode),
		[VermittelbarkeitBemerkung] = PRO.VermittelbarkeitBemerkung,
		Sucht						= dbo.fnLOVText('JaNeinUnklar', PRO.SuchtCode),
		Suchtart				 	= dbo.fnLOVText('KaVermittlungSuchtart', PRO.SuchtartCode),
		Gesundheit					= dbo.fnLOVText('KaVermittlungBIBIPGesundheit', PRO.GesundheitCode),
		[GesundheitEinschraenkungen] = PRO.GesundheitEinschraenkungen,
		[GesundheitKoerperlich]		 = dbo.fnLOVText('KaVermittlungSiGesundheit', PRO.GesundheitKoerperlichCode),
		[EinschraenkungenKoerperlich] = PRO.GesundheitBemerkung,
		[GesundheitBemerkung] = PRO.GesundheitBemerkung,
		[GesundheitPsychisch]		= dbo.fnLOVText('KaVermittlungSiGesundheit', PRO.GesundheitPsychischCode),
		Therapie					= dbo.fnLOVText('JaNein', PRO.TherpieCode),
		[Zuverlaessigkeit]			= dbo.fnLOVText('JaNeinBedingt', PRO.ZuverlaessigkeitCode),
		[MotivationInizio]			= dbo.fnLOVText('KaInizioMotivation', PRO.MotivationInizioCode),
		[MotivationBIBIPSI]			= dbo.fnLOVText('JaNeinBedingt', PRO.MotivationBIBIPSICode),
		[AeussereErscheinungBIBIP]	= dbo.fnLOVText('KaVermittlungBIBIPAeussereErscheinung', PRO.AeussereErscheinungCode),
		[AeussereErscheinungSI]		= dbo.fnLOVText('KaVermittlungSIAeussereErscheinung', PRO.AeussereErscheinungCode),
		InfoAnSDErfolgt				= PRO.InfoAnSDErfolgt,
		Kinderbetreuung				= dbo.fnLOVText('KaVermittlungSIKinderbetreuung', PRO.Kinderbetreuung),
		Einsatzpensum				= PRO.Einsatzpensum,
		EinsatzpensumVon			= PRO.EinsatzpensumVon,
		EinsatzpensumBis			= PRO.EinsatzpensumBis,
		BesondereWuensche			= PRO.BesondereWuensche,
		BesondereFaehigkeiten		= PRO.BesondereFaehigkeiten,
		Fuehrerausweis				= dbo.fnLOVText('JaNein', PRO.FuehrerausweisCode),
		FuehrerausweisKategorie		= dbo.fnLOVText('KaFuehrerausweisKategorie', PRO.FuehrerausweisKategorieCode),
		PCKenntnisse				= dbo.fnLOVText('JaNein', PRO.PCKenntnisseCode),
		Ausbildung					= dbo.fnLOVText('KaAusbildung', PRO.AusbildungCode),
		Arbeitszeiten				= REPLACE(dbo.fnLOVTextListe('KaVermittlungSIArbeitszeit', PRO.ArbeitszeitenCodes), ',', char(13) + char(10)),
		Unterstützung				= REPLACE(dbo.fnLOVTextListe('KaInizioUnterstuetzung', PRO.UnterstuetzungInizioCodes), ',', char(13) + char(10)),
		SIGespraech					= PRO.SIGespraech,
		SIGespraechfuehrerin		= USR.NameVorname,
		GespraechInizio				= PRO.GespraechDatum,
		Ausbildungswunsch			= dbo.fnLOVText('KaBerufsausbildungTyp', PRO.AusbildungstypWunschCode),
		Berufswunsch				= dbo.fnLOVText('KaLehrberuf', PRO.LehrberufWunschCode),
		Bemerkungen					= PRO.Bemerkungen,
		ArbeitsgebietBemerkung		= PRO.ArbeitsgebietBemerkungen,
		GesundheitKoerperlichBewertung = PRO.GesundheitKoerperlichBewertung,
		GesundheitPsychischBewertung = PRO.GesundheitPsychischBewertung,
		ZuverlaessigkeitBewertung   = PRO.ZuverlaessigkeitBewertung,
		MotivationBIBIPSIBewertung  = PRO.MotivationBIBIPSIBewertung,
    Schweizerdeutsch = dbo.fnLOVText('KaSchweizerdeutsch', PRO.KaSchweizerdeutschCode),
    LohnabtretungSD = dbo.fnLOVText('JaNein', PRO.KaLohnabtretungSDCode),
    LaufendeBetreibungen = dbo.fnLOVText('JaNein', PRO.KaLaufendeBetreibungenCode),
    AktuelleTaetigkeit = PRO.AktuelleTaetigkeit,
    Verfuegbarkeit = dbo.fnLOVText('KaVerfuegbarkeit', PRO.KaVerfuegbarkeitCode),
    EinschraenkungMontag = PRO.EinschraenkungMO,
    EinschraenkungDienstag = PRO.EinschraenkungDI,
    EinschraenkungMittwoch = PRO.EinschraenkungMI,
    EinschraenkungDonnerstag = PRO.EinschraenkungDO,
    EinschraenkungFreitag = PRO.EinschraenkungFR,
    EinschraenkungSamstag = PRO.EinschraenkungSA,
    EinschraenkungSonntag = PRO.EinschraenkungSO,
    Nachtarbeit = dbo.fnLOVText('JaNein', PRO.KaNachtarbeitCode)
FROM	dbo.KaVermittlungProfil PRO WITH (READUNCOMMITTED) 
	LEFT JOIN dbo.vwUser USR ON USR.UserID = PRO.SIGespraechfuehrerinID
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungProfil.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVermittlungProfil.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmVaterschaft.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmVaterschaft.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmVaterschaft;
GO
/*===============================================================================================
  $Revision: 1
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Enthält Felder für Vaterschafts-Textmarken.
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmVaterschaft;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmVaterschaft
AS
SELECT

  FaLeistungID  = LEI.FaLeistungID,
  BaPersonID    = LEI.BaPersonID,

  -----------------------------------------------------------------------------
  -- VmVaterschaft
  -----------------------------------------------------------------------------
  AnerkennungDat = CONVERT(VARCHAR, VMV.AnerkennungDatum, 104),
  AnerkennungOrt = VMV.AnerkennungOrt,
  UHVDat         = CONVERT(VARCHAR, VMV.UHVDatum, 104),
  SgeVDat        = CONVERT(VARCHAR, VMV.SorgerechtVereinbDatum, 104),
  GenehmDat      = CONVERT(VARCHAR, VMV.SchlussberichtGenehmigung, 104)

FROM dbo.FaLeistung           LEI WITH (READUNCOMMITTED)
  LEFT JOIN dbo.VmVaterschaft VMV WITH (READUNCOMMITTED) ON VMV.FaLeistungID = LEI.FaLeistungID
  LEFT JOIN dbo.vwTmPerson    PRS ON PRS.BaPersonID = LEI.BaPersonID
WHERE ModulID = 5 -- Vm
  AND LEI.FaProzessCode = 502; -- Vaterschaft
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmVaterschaft.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmVaterschaft.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmAntragEKSK.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmAntragEKSK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmAntragEKSK;
GO

/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmAntragEKSK.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmAntragEKSK;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmAntragEKSK
AS
SELECT VmAntragEKSKID = ANT.VmAntragEKSKID,
       FaLeistungID   = ANT.FaLeistungID,
       Titel          = ANT.Titel,
       Begruendung    = ANT.Begruendung,
       DatumAntrag    = CONVERT(VARCHAR(10), ANT.DatumAntrag, 104),
       Antrag         = ANT.Antrag,
       GenehmigtEKSK  = CONVERT(VARCHAR(10), ANT.DatumGenehmigtEKSK, 104),
       --
       Autor          = USR.VornameName
FROM dbo.VmAntragEKSK  ANT WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwUser USR WITH (READUNCOMMITTED) ON USR.UserID = ANT.UserID;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmAntragEKSK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmAntragEKSK.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmGefaehrdungsMeldung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmGefaehrdungsMeldung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmGefaehrdungsMeldung;
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmGefaehrdungsMeldung.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmGefaehrdungsMeldung;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW dbo.vwTmVmGefaehrdungsMeldung
AS
SELECT
  GMD.VmGefaehrdungsMeldungID,
  GMD.FaLeistungID,
  DatumEingang = CONVERT(VARCHAR(10), GMD.DatumEingang, 104), 
  Kontaktveranlasser = lovGF.Text, 
  GefaehrdungNSB = dbo.fnLOVTextListe('VmGefaehrdungNSB', GMD.VmGefaehrdungNSBCodes),
  Themen = dbo.fnLOVTextListe('FaThema', GMD.FaThemaCodes), 
  GMD.Ausgangslage, 
  GMD.Auflagen, 
  GMD.Ueberpruefung, 
  GMD.Konsequenzen, 
  AuflageDatum  = CONVERT(VARCHAR(10), GMD.AuflageDatum, 104)
FROM dbo.VmGefaehrdungsMeldung GMD WITH (READUNCOMMITTED)
LEFT JOIN dbo.XLovCode lovGF ON lovGF.LOVName = 'FaKontaktveranlasser' and lovGF.Code = GMD.FaKontaktveranlasserCode
;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmGefaehrdungsMeldung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmGefaehrdungsMeldung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMandBericht.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMandBericht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmMandBericht;
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmMandBericht, Maske CtlVmMandBericht.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmMandBericht;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmMandBericht
AS
SELECT VmMandBerichtID            = BER.VmMandBerichtID,
       FaLeistungID               = BER.FaLeistungID,
       VmBerichtID                = BER.VmBerichtID,
       GrundMassnahme             = LOVGM.Text,
       Berichtstitel              = LOVBT.Text,
       BerichtDatumVon            = CONVERT(VARCHAR(10), BER.BerichtDatumVon, 104),
       BerichtDatumBis            = CONVERT(VARCHAR(10), BER.BerichtDatumBis, 104),
       GrundMassnahmeText         = BER.GrundMassnahmeText,
       AuftragZielsetzungText     = BER.AuftragZielsetzungText,
       ZielErreicht               = LOVZE.Text,
       VIP                        = BER.VeraenderungInPeriode,            -- Beschränkung Word auf 20 Zeichen für Checkboxen
       VeraenderungInPeriodCBText = CASE 
                                      WHEN BER.VeraenderungInPeriode = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       Begruendung                = BER.Begruendung,
       NeueZieleText              = BER.NeueZieleText,
       Wohnen                     = LOVWO.Text,
       Gesundheit                 = LOVGE.Text,
       Verhalten                  = LOVVH.Text,
       Taetigkeit                 = LOVTA.Text,
       FS                         = BER.FamiliaereSituation,              -- Beschränkung Word auf 20 Zeichen für Checkboxen
       FamiliaereSituationCBText  = CASE 
                                      WHEN BER.FamiliaereSituation = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       SK                         = BER.SozialeKompetenzen,               -- Beschränkung Word auf 20 Zeichen für Checkboxen
       SozialeKompetenzenCBText   = CASE 
                                      WHEN BER.SozialeKompetenzen = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       FZ                         = BER.Freizeit,                         -- Beschränkung Word auf 20 Zeichen für Checkboxen
       FreizeitCBText             = CASE 
                                      WHEN BER.Freizeit = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       RES                        = BER.Resourcen,
       ResourcenCBText            = CASE
                                      WHEN BER.Resourcen = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       WohnenText                 = BER.WohnenText,
       GesundheitText             = BER.GesundheitText,
       VerhaltenText              = BER.VerhaltenText,
       TaetigkeitText             = BER.TaetigkeitText,
       FamSituationText           = BER.FamSituationText,
       SozialeKompetenzenText     = BER.SozialeKompetenzenText,
       FreizeitText               = BER.FreizeitText,
       BesondereRessourcenText    = BER.BesondereRessourcenText,
       HandlungenText             = BER.HandlungenText,
       BesSchwierigkeitenText     = BER.BesondereSchwierigkeitenText,
       KL                         = BER.Klient,                           -- Beschränkung Word auf 20 Zeichen für Checkboxen
       KlientCBText               = CASE 
                                      WHEN BER.Klient = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       DR                         = BER.Dritte,                           -- Beschränkung Word auf 20 Zeichen für Checkboxen
       DritteCBText               = CASE 
                                      WHEN BER.Dritte = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       I                          = BER.Institutionen,                    -- Beschränkung Word auf 20 Zeichen für Checkboxen
       InstitutionenCBText        = CASE 
                                      WHEN BER.Institutionen = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       KlientText                 = BER.KlientText,
       DritteText                 = BER.DritteText,
       InstitutionenText          = BER.InstitutionenText,
       MCSCMandat                 = LOVMCMD.Text,
       BerichtBelastAngMCSCAdmin  = LOVMCAD.Text,
       BelastungMandatText        = BER.BelastungMandatText,
       BelastungAdminText         = BER.BelastungAdminText,
       EinnahmenAngaben           = dbo.fnLOVTextListe('VmEinnahmenAngaben', BER.VmEinnahmenAngabenCodes),
       EA                         = BER.VmEinnahmenAngabenCodes,          -- Beschränkung Word auf 20 Zeichen für Checkboxen
       BerichtVersicherungen      = dbo.fnLOVTextListe('VmBerichtVersicherungen', BER.VmBerichtVersicherungenCodes),
       BV                         = BER.VmBerichtVersicherungenCodes,     -- Beschränkung Word auf 20 Zeichen für Checkboxen
       BerichtBesondereAngaben    = dbo.fnLOVTextListe('VmBerichtBesondereAngaben', BER.VmBerichtBesondereAngabenCodes),
       BBA                        = BER.VmBerichtBesondereAngabenCodes,   -- Beschränkung Word auf 20 Zeichen für Checkboxen
       EinnahmenBemerkungen       = BER.EinnahmenBemerkungen,
       VersicherungenBemerkungen  = BER.VersicherungenBemerkungen,
       BesondereAngabenBem        = BER.BesondereAngabenBemerkungen,
       AU                         = BER.AbrechnungUnterschrieben,         -- Beschränkung Word auf 20 Zeichen für Checkboxen
       AbrechnungUnterschrieben   = CASE 
                                      WHEN BER.AbrechnungUnterschrieben = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       PT                         = BER.PassationTeilnahme,               -- Beschränkung Word auf 20 Zeichen für Checkboxen
       PassationTeilnahmeCBText   = CASE 
                                      WHEN BER.PassationTeilnahme = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       PassationBemerkung         = BER.PassationBemerkung,
       AntragBericht              = LOVBA.Text,
       AntragBegruendung          = BER.AntragBegruendung,
       ErstellungDatum            = CONVERT(VARCHAR(10), BER.ErstellungDatum, 104),
       BerichtBeilagen            = LOVBB.Text,
       BsDatum                    = CONVERT(VARCHAR(10), BER.BsDatum, 104),
       BelegeZurueckRevision      = CONVERT(VARCHAR(10), BER.BelegeZurueckRevision, 104),
       ZurueckVomBS               = CONVERT(VARCHAR(10), BER.ZurueckVomBS, 104),
       Berichtsart                = LOVAR.Text,
       Autor                      = USR.VornameName
FROM dbo.VmMandBericht   BER     WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwUser   USR     WITH (READUNCOMMITTED) ON USR.UserID = BER.UserID
  LEFT JOIN dbo.XLovCode LOVGM   WITH (READUNCOMMITTED) ON LOVGM.LOVName = 'VmGrundMassnahme'
                                                       AND LOVGM.Code = BER.VmGrundMassnahmeCode
  LEFT JOIN dbo.XLovCode LOVBT   WITH (READUNCOMMITTED) ON LOVBT.LOVName = 'VmBerichtstitel'
                                                       AND LOVBT.Code = BER.VmBerichtstitelCode
  LEFT JOIN dbo.XLovCode LOVZE   WITH (READUNCOMMITTED) ON LOVZE.LOVName = 'VmZielErreicht'
                                                       AND LOVZE.Code = BER.VmZielErreichtCode
  LEFT JOIN dbo.XLovCode LOVWO   WITH (READUNCOMMITTED) ON LOVWO.LOVName = 'VmWohnen'
                                                       AND LOVWO.Code = BER.VmWohnenCode
  LEFT JOIN dbo.XLovCode LOVGE   WITH (READUNCOMMITTED) ON LOVGE.LOVName = 'VmGesundheit'
                                                       AND LOVGE.Code = BER.VmGesundheitCode
  LEFT JOIN dbo.XLovCode LOVVH   WITH (READUNCOMMITTED) ON LOVVH.LOVName = 'VmVerhalten'
                                                       AND LOVVH.Code = BER.VmVerhaltenCode
  LEFT JOIN dbo.XLovCode LOVTA   WITH (READUNCOMMITTED) ON LOVTA.LOVName = 'VmTätigkeit'
                                                       AND LOVTA.Code = BER.VmTaetigkeitCode
  LEFT JOIN dbo.XLovCode LOVMCMD WITH (READUNCOMMITTED) ON LOVMCMD.LOVName = 'VmBerichtBelastungsangabeMCSC'
                                                       AND LOVMCMD.Code = BER.VmBerichtBelastungsangabeMCSCCode_Mandat
  LEFT JOIN dbo.XLovCode LOVMCAD WITH (READUNCOMMITTED) ON LOVMCAD.LOVName = 'VmBerichtBelastungsangabeMCSC'
                                                       AND LOVMCAD.Code = BER.VmBerichtBelastungsangabeMCSCCode_Admin
  LEFT JOIN dbo.XLovCode LOVBA   WITH (READUNCOMMITTED) ON LOVBA.LOVName = 'VmAntragBericht'
                                                       AND LOVBA.Code = BER.VmAntragBerichtCode
  LEFT JOIN dbo.XLovCode LOVBB   WITH (READUNCOMMITTED) ON LOVBB.LOVName = 'VmMfBerichtBeilagen'
                                                       AND LOVBB.Code = BER.VmMfBerichtBeilagenCode
  LEFT JOIN dbo.XLovCode LOVAR   WITH (READUNCOMMITTED) ON LOVAR.LOVName = 'VmBerichtsart'
                                                       AND LOVAR.Code = BER.VmBerichtsartCode;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMandBericht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmMandBericht.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSachversicherung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSachversicherung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmSachversicherung;
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmSachversicherung.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmSachversicherung;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW dbo.vwTmVmSachversicherung
AS
SELECT
  SVG.VmSachversicherungID,
  SVG.FaLeistungID,
  VerArt = lovSV.Text, 
  SVG.Policenummer, 
  Selbstbehalt = CONVERT(VARCHAR(20), SVG.Selbstbehalt, 1), 
  SVG.Grundpraemie, 
  Zahlungsturnus = lovZT.Text, 
  LaufzeitVon = CONVERT(VARCHAR(10), SVG.LaufzeitVon, 104), 
  LaufzeitBis = CONVERT(VARCHAR(10), SVG.LaufzeitBis, 104), 
  VersichertSeit = CONVERT(VARCHAR(10), SVG.VersichertSeit, 104), 
  SVG.Person, 
  SVG.Bemerkungen,
  Adressat_NameVorname = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.NameVorname
    ELSE PRS.NameVorname
  END,
  Adressat_StrasseNr = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.StrasseHausNr
    ELSE PRS.WohnsitzStrasseNr
  END,
  Adressat_PLZOrt = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.PLZOrt
    ELSE PRS.WohnsitzPLZOrt
  END,
  Adressat_AdrMehrzeilig = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.AdresseMehrzeilig
    ELSE PRS.WohnsitzAdresseMehrzeilig
  END,
  Adressat_AdrEinzeilig = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.AdresseEinzeilig
    ELSE PRS.WohnsitzAdresseEinzeilig
  END
FROM dbo.VmSachversicherung SVG WITH (READUNCOMMITTED)
LEFT JOIN dbo.XLovCode lovSV WITH (READUNCOMMITTED) ON lovSV.LOVName = 'VmVersicherungsartSachversicherung' and lovSV.Code = SVG.VmVersicherungsartSachversicherungCode
LEFT JOIN dbo.XLovCode lovZT WITH (READUNCOMMITTED) ON lovZT.LOVName = 'VmZahlungsturnus' and lovZT.Code = SVG.VmZahlungsturnusCode
LEFT JOIN dbo.vwTmPerson PRS ON PRS.BaPersonID = SVG.BaPersonID
LEFT JOIN dbo.vwTmInstitution INS ON INS.BaInstitutionID = SVG.BaInstitutionID
;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSachversicherung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSachversicherung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSituationsBericht.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSituationsBericht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmSituationsBericht;
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmSituationsBericht.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmSituationsBericht;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW dbo.vwTmVmSituationsBericht
AS
SELECT
  BER.VmSituationsBerichtID, 
  BER.FaLeistungID, 
  AntragDatum = CONVERT(VARCHAR(10), BER.AntragDatum, 104), 
  TypSHAntrag = lovAN.Text, 
  Themen = dbo.fnLOVTextListe('FaThema', BER.FaThemaCodes), 
  BerichtFinanzen = dbo.fnXConvertRTF2Text(BER.BerichtFinanzen), 
  ZielPrognose = dbo.fnXConvertRTF2Text(BER.ZielPrognose), 
  AntragText = dbo.fnXConvertRTF2Text(BER.AntragText), 
  Autor = USR.VornameName
FROM dbo.VmSituationsBericht BER WITH (READUNCOMMITTED)
LEFT JOIN dbo.vwUser USR ON USR.UserID = BER.UserID
LEFT JOIN dbo.XLovCode lovAN ON lovAN.LOVName = 'VMTypSHAntrag' and lovAN.Code = BER.VMTypSHAntragCode
;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSituationsBericht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmVmSituationsBericht.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhKostenart.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhKostenart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject WhKostenart;
GO
/*===============================================================================================
  Revision: 3
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the BgKostenart entry for the modulID 3 (Sozialhilfe)
=================================================================================================*/
CREATE VIEW dbo.WhKostenart
AS

SELECT 
  BgKostenartID, 
  ModulID, 
  Name, 
  KontoNr, 
  Quoting, 
  BgSplittingArtCode, 
  BaWVZeileCode, 
  BgKostenartTS
FROM dbo.BgKostenart WITH (READUNCOMMITTED) 
WHERE ModulID = 3;

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhKostenart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhKostenart.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhPositionsart.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhPositionsart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject WhPositionsart
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Modul/WhPositionsart.sql $
  $Author: Tabegglen $
  $Modtime: 17.08.10 11:48 $
  $Revision: 8 $
=================================================================================================*/
CREATE  VIEW dbo.WhPositionsart
AS

SELECT
  POA.BgPositionsartID, POA.BgKategorieCode, POA.BgGruppeCode, POA.BgPositionsartCode, POA.BgPositionsartID_CopyOf, 
  POA.Name, POA.Hilfetext, POA.SortKey, POA.BgKostenartID, POA.NrmKontoCode, POA.VerwaltungSD_Default, POA.Spezkonto, 
  POA.ProPerson, POA.ProUE, POA.Masterbudget_EditMask, POA.Monatsbudget_EditMask, POA.ModulID, POA.sqlRichtlinie, 
  POA.BgPositionsartTS, POA.VarName, POA.Verrechenbar, POA.Bemerkung, POA.NameTID, POA.DatumVon, POA.DatumBis, 
  POA.System, POA.KreditorEingeschraenkt, 
  KontoNrName = ISNULL(KOA.KontoNr + ' ', '') + POA.Name
FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = POA.BgKostenartID
WHERE
  POA.ModulID = 3
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhPositionsart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\WhPositionsart.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaZahlungsweg.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaZahlungsweg;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Modul/vwBaZahlungsweg.sql $
  $Author: Cjaeggi $
  $Modtime: 15.07.10 19:28 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/Modul/vwBaZahlungsweg.sql $
 * 
 * 3     15.07.10 19:31 Cjaeggi
 * #4167: Fixed BaInstitution.InstitutionName after changes of table
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwBaZahlungsweg
AS
SELECT ZAL.BaZahlungswegID,
       ZAL.BaPersonID,
       ZAL.BaInstitutionID,
       ZAL.DatumVon,
       ZAL.DatumBis,
       ZAL.EinzahlungsscheinCode,
       ZAL.BaBankID,
       ZAL.BankKontoNummer,
       ZAL.IBANNummer,
       ZAL.PostKontoNummer,
       ZAL.ReferenzNummer,
       ZAL.AdresseName,
       ZAL.AdresseName2,
       ZAL.AdresseStrasse,
       ZAL.AdresseHausNr,
       ZAL.AdressePostfach,
       ZAL.AdressePLZ,
       ZAL.AdresseOrt,
       ZAL.AdresseLandCode,
       ZAL.BaZahlwegModulStdCodes,
       ZAL.BaZahlungswegTS,
       --
       [Name]     = CASE 
                      WHEN ZAL.BaPersonID IS NOT NULL THEN ISNULL(PRS.Vorname + ' ', '') + PRS.Name 
                      ELSE INS.[Name] 
                    END,
       Adresse    = CASE 
                      WHEN ZAL.BaPersonID IS NOT NULL THEN PRS.Wohnsitz 
                      ELSE INS.Adresse 
                    END,
       Empfaenger = CASE 
                      WHEN ZAL.BaPersonID IS NOT NULL THEN ISNULL(PRS.Vorname + ' ', '') + PRS.Name + ISNULL(', ' + PRS.Wohnsitz, '')
                      ELSE INS.[Name] + ISNULL(', ' + INS.Adresse, '')
                    END
FROM dbo.BaZahlungsweg        ZAL WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ZAL.BaPersonID
  LEFT JOIN dbo.vwInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAL.BaInstitutionID;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Modul\vwBaZahlungsweg.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmFaAktennotizen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmFaAktennotizen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmFaAktennotizen
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle FaAktennotizen.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmFaAktennotizen;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW [dbo].[vwTmFaAktennotizen]
AS
SELECT
  A.FaAktennotizID,
  A.FaLeistungID,
  ID = CONVERT(varchar(20), A.FaAktennotizID),
  Datum = CONVERT(varchar(10), A.Datum, 104),
  Dauer = LovDa.Text,
  A.Zeit,
  Kontaktart = LovKa.Text,
  GespraechsStatus = LovGS.Text,
  Gespraechstyp = LovGT.Text,
  Kontaktpartner = A.Kontaktpartner,
  AlimentenstelleTyp = LovAS.Text,
  Stichwort = A.Stichwort,
  InhaltMitFmt = A.InhaltRTF,
  InhaltOhneFmt = A.InhaltRTF,
  Themen = dbo.fnLOVTextListe('FaThema', A.FaThemaCodes),
  Vertraulich = CASE WHEN A.Vertraulich = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema1 = CASE WHEN A.BesprechungThema1 = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema2 = CASE WHEN A.BesprechungThema2 = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema3 = CASE WHEN A.BesprechungThema3 = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema4 = CASE WHEN A.BesprechungThema4 = 1 THEN 'Ja' ELSE 'Nein' END,
  A.BesprechungThemaText1,
  A.BesprechungThemaText2,
  A.BesprechungThemaText3,
  A.BesprechungThemaText4,
  A.BesprechungZiel1,
  A.BesprechungZiel2,
  A.BesprechungZiel3,
  A.BesprechungZiel4,
  BesprechungZielGrad1 = CONVERT(varchar(20), A.BesprechungZielGrad1),
  BesprechungZielGrad2 = CONVERT(varchar(20), A.BesprechungZielGrad2),
  BesprechungZielGrad3 = CONVERT(varchar(20), A.BesprechungZielGrad3),
  BesprechungZielGrad4 = CONVERT(varchar(20), A.BesprechungZielGrad4),
  A.Pendenz1,
  A.Pendenz2,
  A.Pendenz3,
  A.Pendenz4,
  PendenzErledigt1 = CASE WHEN A.PendenzErledigt1 = 1 THEN 'Ja' ELSE 'Nein' END,
  PendenzErledigt2 = CASE WHEN A.PendenzErledigt2 = 1 THEN 'Ja' ELSE 'Nein' END,
  PendenzErledigt3 = CASE WHEN A.PendenzErledigt3 = 1 THEN 'Ja' ELSE 'Nein' END,
  PendenzErledigt4 = CASE WHEN A.PendenzErledigt4 = 1 THEN 'Ja' ELSE 'Nein' END,
  -- User
  UserLogin = U.Login,
  UserNachname = U.Nachname,
  UserVorname = U.Vorname,
  UserKuerzel = U.Kuerzel,
  UserNameVorname = U.NameVorname,
  UserNameVornameOhneKomma = U.NameVornameOhneKomma,
  UserVornameName = U.VornameName
FROM dbo.FaAktennotizen A WITH (READUNCOMMITTED)
LEFT JOIN dbo.vwTmUser U ON U.BenutzerNr = A.UserID
LEFT JOIN dbo.XLOVCode LovDa WITH (READUNCOMMITTED) ON LovDa.LOVName = 'FaDauer' AND LovDa.Code = A.FaDauerCode
LEFT JOIN dbo.XLOVCode LovKa WITH (READUNCOMMITTED) ON LovKa.LOVName = 'FaKontaktart' AND LovKa.Code = A.FaKontaktartCode
LEFT JOIN dbo.XLOVCode LovGS WITH (READUNCOMMITTED) ON LovGS.LOVName = 'FaGespraechsStatus' AND LovGS.Code = A.FaGespraechsStatusCode
LEFT JOIN dbo.XLOVCode LovGT WITH (READUNCOMMITTED) ON LovGT.LOVName = 'FaThema' AND LovGT.Code = A.FaGespraechstypCode
LEFT JOIN dbo.XLOVCode LovAS WITH (READUNCOMMITTED) ON LovAS.LOVName = 'AlimentenstelleTyp' AND LovAS.Code = A.AlimentenstelleTypCode
;
GO

 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmFaAktennotizen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\Standard\vwTmFaAktennotizen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmBDEZLEUebersicht;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:58 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for ZLE-Erfassung (only dummy for columns)
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmBDEZLEUebersicht
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
 * 
 * 4     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 3     23.10.08 9:31 Cjaeggi
 * Removed change again
 * 
 * 2     23.10.08 9:19 Cjaeggi
 * Changed fnBDEGetUebersicht
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
 * 
 * 1     3.09.08 9:49 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.vwTmBDEZLEUebersicht
AS
SELECT FCN.UserID, 
       FCN.MonatJahrText, 
       FCN.PensumProzent, 
       FCN.SollArbeitszeitProTag, 
       FCN.GZIstArbeitszeitProMonat, 
       FCN.GZSollArbeitszeitProMonat, 
       FCN.GZMonatsSaldo, 
       FCN.GZUebertragVorjahr, 
       FCN.GZUebertragVormonate, 
       FCN.GZKorrekturen, 
       FCN.GZAusbezahlteUeberstunden, 
       FCN.GZSaldo, 
       FCN.SLIstArbeitszeitProMonat, 
       FCN.FerienUebertragVorjahr, 
       FCN.FerienAnspruchProJahr, 
       FCN.FerienBisherBezogen, 
       FCN.FerienZugabenKuerzungen, 
       FCN.FerienKorrekturen, 
       FCN.FerienSaldo
FROM dbo.fnBDEGetUebersicht(- 1, dbo.fnLastDayOf(GETDATE()), 1, 0) AS FCN
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesAuftrag.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesAuftrag.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesAuftrag;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen von Textmarken
  -
  RETURNS: Daten der Tabelle...
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesAuftrag;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesAuftrag
AS
  SELECT
    KesAuftragID                 = KAU.KesAuftragID,
    AuftragVom            = KAU.DatumAuftrag,
    AbklaerungDurch       = USRKA.NameVorname, -- Bearbeitung Durch
    MeldungDurchD         = dbo.fnGetLOVMLText(CASE WHEN KAU.IsKS=1 THEN 'KesGefaehrdungsmeldungDurchKS' ELSE 'KesGefaehrdungsmeldungDurchES' END, KAU.KesGefaehrdungsmeldungDurchCode, 1),
    MeldungDurchF         = dbo.fnGetLOVMLText(CASE WHEN KAU.IsKS=1 THEN 'KesGefaehrdungsmeldungDurchKS' ELSE 'KesGefaehrdungsmeldungDurchES' END, KAU.KesGefaehrdungsmeldungDurchCode, 2),
    MeldungDurchI         = dbo.fnGetLOVMLText(CASE WHEN KAU.IsKS=1 THEN 'KesGefaehrdungsmeldungDurchKS' ELSE 'KesGefaehrdungsmeldungDurchES' END, KAU.KesGefaehrdungsmeldungDurchCode, 3),
    AuftragDurchD         = dbo.fnGetLOVMLText('KesAuftragDurch', KAU.KesAuftragDurchCode, 1),
    AuftragDurchF         = dbo.fnGetLOVMLText('KesAuftragDurch', KAU.KesAuftragDurchCode, 2),
    AuftragDurchI         = dbo.fnGetLOVMLText('KesAuftragDurch', KAU.KesAuftragDurchCode, 3),          
    AbklaerungsartDE       = dbo.fnGetLOVMLText('KesAuftragAbklaerungsart', KAU.KesAuftragAbklaerungsartCode, 1),
    AbklaerungsartFR       = dbo.fnGetLOVMLText('KesAuftragAbklaerungsart', KAU.KesAuftragAbklaerungsartCode, 2),
    AbklaerungsartIT       = dbo.fnGetLOVMLText('KesAuftragAbklaerungsart', KAU.KesAuftragAbklaerungsartCode, 3),
    Anlass                = KAU.Anlass,
    Auftrag               = KAU.Auftrag,
    DokumentDatum         = dbo.fnDateOf(DOCDKAB.DateLastSave),
    FristBis              = KAU.DatumFrist,

    Abschluss             = KAU.AbschlussDatum,
    AbschlussgrundD       = dbo.fnGetLOVMLText('KesAuftragAbschlussgrund', KAU.KesAuftragAbschlussgrundCode, 1),
    AbschlussgrundF       = dbo.fnGetLOVMLText('KesAuftragAbschlussgrund', KAU.KesAuftragAbschlussgrundCode, 2),
    AbschlussgrundI       = dbo.fnGetLOVMLText('KesAuftragAbschlussgrund', KAU.KesAuftragAbschlussgrundCode, 3),          
    BeschlussRueckmeldung = dbo.fnDateOf(DOCDKAA.DateLastSave),
    BetroffenePersonen    = STUFF((SELECT DISTINCT
                                     ', ' + CONVERT(VARCHAR, PRS.Name + IsNull(' ' + PRS.Vorname, ''))
                                   FROM dbo.KesAuftrag_BaPerson KAP
                                     INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KAP.BaPersonID
                                   WHERE KAP.KesAuftragID = KAU.KesAuftragID 
                                   FOR XML PATH('')),
                                   1, 
                                   2, 
                                   ''),

    --Klient von der Leistung --> via Standard-Textmarke, Verwandt vom Klient hier spezifisch :
    KlientKindD        = dbo.ConcDistinct(NULLIF(ISNULL(PRSK.VornameName, '') + 
                                                 ISNULL(', ' + PRSK.ZivilstandD, '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSK.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSK.HeimatortNationalitaetD, '') +
                                                 ISNULL(', wohnhaft ' + PRSK.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientKindF        = dbo.ConcDistinct(NULLIF(ISNULL(PRSK.VornameName, '') + 
                                                 ISNULL(', ' + PRSK.ZivilstandF, '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSK.Geburtsdatum,104),'') +
                                                 ISNULL(', de ' + PRSK.HeimatortNationalitaetF, '') +
                                                 ISNULL(', domicile ' + PRSK.AufenthaltWohnortAdrEinzOhneName,''), '')),  
    KlientKindI        = dbo.ConcDistinct(NULLIF(ISNULL(PRSK.VornameName, '') + 
                                                 ISNULL(', ' + PRSK.ZivilstandI, '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSK.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSK.HeimatortNationalitaetI, '') +
                                                 ISNULL(', wohnhaft ' + PRSK.AufenthaltWohnortAdrEinzOhneName,''), '')),    
    KlientVaterD       = dbo.ConcDistinct(NULLIF(ISNULL(PRSV.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSV.ZivilstandD  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSV.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSV.HeimatortNationalitaetD, '') +
                                                 ISNULL(', wohnhaft ' + PRSV.AufenthaltWohnortAdrEinzOhneName,''), '')) ,        
    KlientVaterF       = dbo.ConcDistinct(NULLIF(ISNULL(PRSV.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSV.ZivilstandF  , '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSV.Geburtsdatum,104),'') +
                                                 ISNULL(', de ' + PRSV.HeimatortNationalitaetF, '') +
                                                 ISNULL(', domicile ' + PRSV.AufenthaltWohnortAdrEinzOhneName,''), '')),  
    KlientVaterI       = dbo.ConcDistinct(NULLIF(ISNULL(PRSV.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSV.ZivilstandI  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSV.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSV.HeimatortNationalitaetI, '') +
                                                 ISNULL(', wohnhaft ' + PRSV.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientMutterD      = dbo.ConcDistinct(NULLIF(ISNULL(PRSM.NameVornameOhneKomma, '') +
                                                 ISNULL(', ' + PRSM.ZivilstandD  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSM.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSM.HeimatortNationalitaetD, '') +
                                                 ISNULL(', wohnhaft ' + PRSM.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientMutterF      = dbo.ConcDistinct(NULLIF(ISNULL(PRSM.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSM.ZivilstandF  , '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSM.Geburtsdatum,104),'') +
                                                 ISNULL(', de ' + PRSM.HeimatortNationalitaetF, '') +
                                                 ISNULL(', domicile ' + PRSM.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientMutterI      = dbo.ConcDistinct(NULLIF(ISNULL(PRSM.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSM.ZivilstandI  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSM.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSM.HeimatortNationalitaetI, '') +
                                                 ISNULL(', wohnhaft ' + PRSM.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientGeschwisterD = dbo.ConcDistinct(NULLIF(ISNULL(PRSG.VornameName, '') +
                                                 ISNULL(', ' + PRSG.ZivilstandD  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSG.Geburtsdatum,104),''), '')),
    KlientGeschwisterF = dbo.ConcDistinct(NULLIF(ISNULL(PRSG.VornameName, '') +
                                                 ISNULL(', ' + PRSG.ZivilstandF  , '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSG.Geburtsdatum,104),''), '')),
    KlientGeschwisterI = dbo.ConcDistinct(NULLIF(ISNULL(PRSG.VornameName, '') +
                                                 ISNULL(', ' + PRSG.ZivilstandI  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSG.Geburtsdatum,104),''), '')),
    -- sonstiges
    DatumHeute = dbo.fnDateOf(GETDATE())
  FROM dbo.KesAuftrag               KAU     WITH (READUNCOMMITTED)
    LEFT JOIN dbo.FaLeistung        LEI     WITH (READUNCOMMITTED) ON LEI.FaLeistungID = KAU.FaLeistungID
    LEFT JOIN dbo.vwTmUser          USRKA   ON USRKA.UserID = KAU.UserID  
    LEFT JOIN dbo.XDocument         DOCDKAB WITH (READUNCOMMITTED) ON DOCDKAB.DocumentID = KAU.DocumentID_BeschlussRueckmeldung
    LEFT JOIN dbo.XDocument         DOCDKAA WITH (READUNCOMMITTED) ON DOCDKAA.DocumentID = KAU.DocumentID_Auftrag     
    -- Kind
    LEFT JOIN dbo.BaPerson_Relation PREK    WITH (READUNCOMMITTED) ON PREK.BaPersonID_1 = LEI.BaPersonID 
                                                                  AND PREK.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind , 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSK    WITH (READUNCOMMITTED) ON PRSK.BaPersonID = PREK.BaPersonID_2
    -- Vater
    LEFT JOIN dbo.BaPerson_Relation PREV    WITH (READUNCOMMITTED) ON PREV.BaPersonID_2 = LEI.BaPersonID 
                                                                  AND PREV.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind, 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSV    WITH (READUNCOMMITTED) ON PRSV.BaPersonID = PREV.BaPersonID_1 
                                                                  AND (PRSV.GeschlechtCode = 1 OR PRSV.GeschlechtCode IS NULL)  
    -- Mutter
    LEFT JOIN dbo.BaPerson_Relation PREM    WITH (READUNCOMMITTED) ON PREM.BaPersonID_2 = LEI.BaPersonID 
                                                                  AND PREM.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind, 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSM    WITH (READUNCOMMITTED) ON PRSM.BaPersonID = PREM.BaPersonID_1 
                                                                  AND PRSM.GeschlechtCode = 2 
    -- Geschwister
    LEFT JOIN dbo.BaPerson_Relation PREG    WITH (READUNCOMMITTED) ON (PREG.BaPersonID_1 = LEI.BaPersonID OR PREG.BaPersonID_2 = LEI.BaPersonID) 
                                                                  AND PREG.BaRelationID = 2 -- BaRelationID = 2 --> Geschwister
    LEFT JOIN dbo.vwTmPerson        PRSG    WITH (READUNCOMMITTED) ON (PRSG.BaPersonID = PREG.BaPersonID_1 AND PREG.BaPersonID_1 != LEI.BaPersonID)
                                                                   OR (PRSG.BaPersonID = PREG.BaPersonID_2 AND PREG.BaPersonID_2 != LEI.BaPersonID)

  GROUP BY  KAU.KesAuftragID, KAU.DatumAuftrag, KAU.DatumFrist, KAU.IsKS, KAU.KesGefaehrdungsmeldungDurchCode, KAU.KesAuftragAbklaerungsartCode, KAU.KesAuftragDurchCode, KAU.Anlass, KAU.Auftrag, KAU.AbschlussDatum, KAU.KesAuftragAbschlussgrundCode,
            DOCDKAB.DateLastSave, DOCDKAA.DateLastSave,
            USRKA.UserID, USRKA.NameVorname

GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesAuftrag.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesAuftrag.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesDokument.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesDokument.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesDokument;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen von Textmarken
  -
  RETURNS: Daten der Tabelle...
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesDokument;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesDokument
AS
  SELECT
    -- Dokument Teil --
    KesAuftragID                  = KED.KesAuftragID,
    KesDokumentID                 = KED.KesDokumentID,
    VerfasserInUserID             = KED.[UserID],
    VerfasserFrauHerr             = USR.FrauHerr,
    VerfasserFrauHerrn            = USR.FrauHerrn,
    VerfasserNameVorname          = USR.NameVorname,
    VerfasserNameVornameOhneKomma = USR.NameVornameOhneKomma,
    VerfasserVornameName          = USR.VornameName,
    VerfasserAbteilungEMail       = USR.AbteilungEMail,
    VerfasserAbteilungFax         = USR.AbteilungFax,
    VerfasserAbteilungName        = USR.AbteilungName,
    VerfasserAbteilungTelefon     = USR.AbteilungTelefon,
    VerfasserNachname             = USR.Nachname,
    VerfasserVorname              = USR.Vorname,
    VerfasserKuerzel              = USR.Kuerzel,
    VerfasserTelephon             = USR.Telephon,
    VerfasserEMail                = USR.EMail,
    --Verfasser via Standard-Textmarke: vwTmUser, existiert aber nur für "Aktuell eingeloggter Benutzer", deshalb integriert in diese View
    Stichwort                     = KED.[Stichwort],
    ResultatD                     = dbo.fnGetLOVMLText('KesDokumentResultat', KED.KesDokumentResultatCode, 1),
    ResultatF                     = dbo.fnGetLOVMLText('KesDokumentResultat', KED.KesDokumentResultatCode, 2),
    ResultatI                     = dbo.fnGetLOVMLText('KesDokumentResultat', KED.KesDokumentResultatCode, 3),
    ArtDE                          = dbo.fnGetLOVMLText('KesDokumentArt', KED.KesDokumentArtCode, 1),
    ArtFR                          = dbo.fnGetLOVMLText('KesDokumentArt', KED.KesDokumentArtCode, 2),
    ArtIT                          = dbo.fnGetLOVMLText('KesDokumentArt', KED.KesDokumentArtCode, 3), 
    VersandDatum                  = dbo.fnDateOf(DOCV.DateLastSave),
    -- sonstiges
    DatumHeute = dbo.fnDateOf(GETDATE())
  FROM dbo.KesDokument              KED     WITH (READUNCOMMITTED)
    LEFT JOIN dbo.XDocument         DOCD    WITH (READUNCOMMITTED) ON DOCD.DocumentID = KED.XDocumentID_Dokument
    LEFT JOIN dbo.XDocument         DOCV    WITH (READUNCOMMITTED) ON DOCV.DocumentID = KED.XDocumentID_Versand  
    LEFT JOIN dbo.vwTmUser          USR     ON KED.UserID = USR.UserID
    LEFT JOIN dbo.KesAuftrag        KAU     WITH (READUNCOMMITTED) ON KAU.KesAuftragID = KED.KesAuftragID
    LEFT JOIN dbo.FaLeistung        LEI     WITH (READUNCOMMITTED) ON LEI.FaLeistungID = KAU.FaLeistungID
    LEFT JOIN dbo.vwTmUser          USRKA   ON USRKA.UserID = KAU.UserID  
    LEFT JOIN dbo.XDocument         DOCDKAB WITH (READUNCOMMITTED) ON DOCDKAB.DocumentID = KAU.DocumentID_BeschlussRueckmeldung
    LEFT JOIN dbo.XDocument         DOCDKAA WITH (READUNCOMMITTED) ON DOCDKAA.DocumentID = KAU.DocumentID_Auftrag     
    -- Kind
    LEFT JOIN dbo.BaPerson_Relation PREK    WITH (READUNCOMMITTED) ON PREK.BaPersonID_1 = LEI.BaPersonID 
                                                                  AND PREK.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind , 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSK    WITH (READUNCOMMITTED) ON PRSK.BaPersonID = PREK.BaPersonID_2
    -- Vater
    LEFT JOIN dbo.BaPerson_Relation PREV    WITH (READUNCOMMITTED) ON PREV.BaPersonID_2 = LEI.BaPersonID 
                                                                  AND PREV.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind, 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSV    WITH (READUNCOMMITTED) ON PRSV.BaPersonID = PREV.BaPersonID_1 
                                                                  AND (PRSV.GeschlechtCode = 1 OR PRSV.GeschlechtCode IS NULL)  
    -- Mutter
    LEFT JOIN dbo.BaPerson_Relation PREM    WITH (READUNCOMMITTED) ON PREM.BaPersonID_2 = LEI.BaPersonID 
                                                                  AND PREM.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind, 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSM    WITH (READUNCOMMITTED) ON PRSM.BaPersonID = PREM.BaPersonID_1 
                                                                  AND PRSM.GeschlechtCode = 2 
    -- Geschwister
    LEFT JOIN dbo.BaPerson_Relation PREG    WITH (READUNCOMMITTED) ON (PREG.BaPersonID_1 = LEI.BaPersonID OR PREG.BaPersonID_2 = LEI.BaPersonID) 
                                                                  AND PREG.BaRelationID = 2 -- BaRelationID = 2 --> Geschwister
    LEFT JOIN dbo.vwTmPerson        PRSG    WITH (READUNCOMMITTED) ON (PRSG.BaPersonID = PREG.BaPersonID_1 AND PREG.BaPersonID_1 != LEI.BaPersonID)
                                                                   OR (PRSG.BaPersonID = PREG.BaPersonID_2 AND PREG.BaPersonID_2 != LEI.BaPersonID)

  GROUP BY  KED.KesAuftragID, KED.KesDokumentID, KED.UserID, KED.[Stichwort], KED.KesDokumentResultatCode, KED.KesDokumentArtCode, KED.[XDocumentID_Dokument], KED.[XDocumentID_Versand], KED.[KesDokumentTypCode],
            DOCD.DateLastSave, DOCV.DateLastSave,
            USR.FrauHerr, USR.FrauHerrn, USR.NameVorname, USR.NameVornameOhneKomma, USR.VornameName, USR.AbteilungEMail, USR.AbteilungFax, USR.AbteilungName, USR.AbteilungTelefon, USR.Nachname, USR.Vorname,  USR.Kuerzel, USR.Telephon,  USR.EMail,
            KAU.KesAuftragID, KAU.DatumAuftrag, KAU.DatumFrist, KAU.IsKS, KAU.KesGefaehrdungsmeldungDurchCode, KAU.KesAuftragAbklaerungsartCode, KAU.KesAuftragDurchCode, KAU.Anlass, KAU.Auftrag, KAU.AbschlussDatum, KAU.KesAuftragAbschlussgrundCode,
            DOCDKAB.DateLastSave, DOCDKAA.DateLastSave,            
            USRKA.UserID, USRKA.NameVorname

GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesDokument.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesDokument.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesMassnahmeBericht.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesMassnahmeBericht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesMassnahmeBericht;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Textmarken: KES > Massnahmenführung > Berichts-/R.ablage und > Auftrage/Anträge
  -
  RETURNS: Alle Textmarken: KES > Massnahmenfürhung > Berichts-/R.ablage und > Auftrage/Anträge
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesMassnahmeBericht;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesMassnahmeBericht
AS
SELECT
  -------------------------
  -- KesMassnahme
  -------------------------
  MAS.KesMassnahmeID,

  ArtikelNummer = dbo.ConcDistinct(ART.ArtikelNummer),
  ArtikelTextKurz = dbo.ConcDistinct(ART.BezeichnungKurz),
  ArtikelTextLang = dbo.ConcDistinct(ART.BezeichnungLang),
  ArtNmrTextKurz = dbo.ConcDistinct(ART.ArtikelNummer + ' ' + ART.BezeichnungKurz),
  ArtNmrTextLang = dbo.ConcDistinct(ART.ArtikelNummer + ' ' + ART.BezeichnungLang),

  DatErchtsbschlss = MAS.DatumVon,

  MFPNameVorname = MFP.NameVorname,
  MFPNmVrnmOhnKmma = MFP.NameVornameOhneKomma,
  MFPVornameName = MFP.VornameName,
  MFPAdrssEinzeilg = MFP.AdresseEinzeilig,
  MFPAdrssMhrzeilg = MFP.AdresseMehrzeilig,
  MFPErnanntSeit = MFP.DatumMandatVon,
  MFPPrmVrgchlSDAm = MFP.DatumVorgeschlagenAm,
  MFPPrmRchfrngVon= MFP.DatumRechnungsfuehrungVon,
  MFPPrmRchfrngBis= MFP.DatumRechnungsfuehrungBis,
    
  SARFrauHerr = USR.FrauHerr,
  SARFrauHerrn = USR.FrauHerrn,
  SARNameVorname = USR.NameVorname,
  SARNamVrnmOhnKma = USR.NameVornameOhneKomma,
  SARVornameName = USR.VornameName,
  SARAbteilungEMai = USR.AbteilungEMail,
  SARAbteilungFax = USR.AbteilungFax,
  SARAbteilungName = USR.AbteilungName,
  SARAbteilungTel = USR.AbteilungTelefon,
  SARNachname = USR.Nachname,
  SARVorname = USR.Vorname,
  SARKuerzel = USR.Kuerzel,
  SARTelephon = USR.Telephon,
  SAREMail = USR.EMail,
  
  ElterlicheSorgeD = dbo.fnLOVMLText('KesElterlicheSorgeObhut', MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, 1),
  ElterlicheSorgeF = dbo.fnLOVMLText('KesElterlicheSorgeObhut', MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, 2),
  ElterlicheSorgeI = dbo.fnLOVMLText('KesElterlicheSorgeObhut', MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, 3),  
  MassAuftragstext =  MAS.Auftragstext,

  -------------------------
  -- KesMassnahmeBericht
  -------------------------
  BER.KesMassnahmeBerichtID,

  PeriodeVon = BER.DatumVon,
  PeriodeBis = BER.DatumBis,
  Berichtsdatum = (SELECT DateLastSave FROM XDocument WHERE DocumentID = BER.DocumentID_Bericht),
  Rechnungsdatum = (SELECT DateLastSave FROM XDocument WHERE DocumentID = BER.DocumentID_Rechnung),
  BrchtArtDsBrchtD = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 1),
  BrchtArtDsBrchtF = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 2),
  BrchtArtDsBrchtI = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 3),

  -------------------------
  -- KesMassnahmeAuftrag
  -------------------------
  KesMassnahmeAuftragID = AUF.KesMassnahmeAuftragID,
  AuftragAuftrag = AUF.Auftrag,
  AuftrgrtGschftsD = dbo.fnLOVMLText('KesMassnahmeGeschaeftsart', AUF.KesMassnahmeGeschaeftsartCode, 1),
  AuftrgrtGschftsF = dbo.fnLOVMLText('KesMassnahmeGeschaeftsart', AUF.KesMassnahmeGeschaeftsartCode, 2),
  AuftrgrtGschftsI = dbo.fnLOVMLText('KesMassnahmeGeschaeftsart', AUF.KesMassnahmeGeschaeftsartCode, 3)
  


  --Klient... via Standard-Textmarken: Klient...

FROM dbo.KesMassnahme MAS WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = MAS.FaLeistungID
  INNER JOIN vwTmUser USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
  OUTER APPLY (SELECT TOP 1 
				NameVorname           = ISNULL(USRI.NameVorname, INSI.NameVorname),
				NameVornameOhneKomma  = ISNULL(USRI.NameVornameOhneKomma, INSI.Name + ISNULL(' ' + INSI.Vorname, '')),
				VornameName           = ISNULL(USRI.VornameName, ISNULL(INSI.Vorname + ' ', '') + INSI.Name),
				AdresseEinzeilig      = ISNULL(USRI.AdresseEinzeilig, INSI.AdresseEinzeilig),
				AdresseMehrzeilig	  = ISNULL(USRI.AdresseMehrzeilig, INSI.AdresseMehrzeilig),
				MFPI.DatumMandatVon,
				MFPI.DatumMandatBis,
				MFPI.DatumVorgeschlagenAm,	
				MFPI.DatumRechnungsfuehrungVon,
				MFPI.DatumRechnungsfuehrungBis
			   FROM dbo.KesMandatsfuehrendePerson MFPI
			     LEFT JOIN dbo.vwTmUser USRI ON USRI.UserID = MFPI.UserID
			     LEFT JOIN dbo.vwTmInstitution INSI ON INSI.BaInstitutionID = MFPI.BaInstitutionID
			   WHERE MFPI.KesMassnahmeID = MAS.KesMassnahmeID
			   ORDER BY ISNULL(MFPI.DatumMandatBis, '99991231') DESC) MFP 
  LEFT JOIN dbo.KesMassnahme_KesArtikel KMA ON KMA.KesMassnahmeID = MAS.KesMassnahmeID
  OUTER APPLY (SELECT 
				ArtikelNummer = Artikel + ISNULL('.' + Absatz, '') + ISNULL('.' + Ziffer, '') + ' ' + Gesetz,
				BezeichnungKurz,
				BezeichnungLang = Bezeichnung
			   FROM dbo.KesArtikel 
			   WHERE KesArtikelID = KMA.KesArtikelID) ART
  LEFT JOIN dbo.KesMassnahmeBericht BER WITH (READUNCOMMITTED) ON BER.KesMassnahmeID = MAS.KesMassnahmeID
  LEFT JOIN dbo.KesMassnahmeAuftrag AUF WITH (READUNCOMMITTED) ON AUF.KesMassnahmeID = MAS.KesMassnahmeID
GROUP BY MAS.KesMassnahmeID, MAS.DatumVon, 
         MFP.NameVorname, MFP.NameVornameOhneKomma, MFP.VornameName, MFP.AdresseEinzeilig, MFP.AdresseMehrzeilig, MFP.DatumMandatVon, MFP.DatumVorgeschlagenAm, MFP.DatumRechnungsfuehrungVon, MFP.DatumRechnungsfuehrungBis,
         USR.FrauHerr, USR.FrauHerrn, USR.NameVorname, USR.NameVornameOhneKomma, USR.VornameName, USR.AbteilungEMail, USR.AbteilungFax, USR.AbteilungName, USR.AbteilungTelefon, USR.Nachname, USR.Vorname, USR.Kuerzel, USR.Telephon, USR.EMail, 
         MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, MAS.Auftragstext, 
         BER.KesMassnahmeBerichtID, BER.DatumVon, BER.DatumBis, BER.DocumentID_Bericht, BER.DocumentID_Rechnung, BER.KesMassnahmeBerichtsartCode,
         AUF.KesMassnahmeAuftragID, AUF.Auftrag,  AUF.KesMassnahmeGeschaeftsartCode
         
         
         
;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesMassnahmeBericht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesMassnahmeBericht.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesVerlauf.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesVerlauf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesVerlauf;
GO
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Textmarken: KES > Fachstelle Prima > PRIMA-Begleitung
  -
  RETURNS: Alle Textmarken: KES > Fachstelle Prima > PRIMA-Begleitung
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesVerlauf;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesVerlauf
AS
SELECT
  VRL.KesVerlaufID,

  VRL.Datum,

  KontaktartDE = dbo.fnLOVMLText('KesKontaktart', VRL.KesKontaktartCode, 1),
  KontaktartFR = dbo.fnLOVMLText('KesKontaktart', VRL.KesKontaktartCode, 2),
  KontaktartIT = dbo.fnLOVMLText('KesKontaktart', VRL.KesKontaktartCode, 3),

  DienstleistungD = dbo.fnLOVMLText('KesDienstleistung', VRL.KesDienstleistungCode, 1),
  DienstleistungF = dbo.fnLOVMLText('KesDienstleistung', VRL.KesDienstleistungCode, 2),
  DienstleistungI = dbo.fnLOVMLText('KesDienstleistung', VRL.KesDienstleistungCode, 3),

  VRL.Stichwort,

  --Verfasser via Standard-Textmarke: vwTmUser, existiert aber nur für "Aktuell eingeloggter Benutzer", deshalb integriert in diese View
  VerfasserFrauHerr = USR.FrauHerr,
  VerfasserFrauHerrn = USR.FrauHerrn,
  VerfasserNameVorname = USR.NameVorname,
  VerfasserNameVornameOhneKomma = USR.NameVornameOhneKomma,
  VerfasserVornameName = USR.VornameName,
  VerfasserAbteilungEMail = USR.AbteilungEMail,
  VerfasserAbteilungFax = USR.AbteilungFax,
  VerfasserAbteilungName = USR.AbteilungName,
  VerfasserAbteilungTelefon = USR.AbteilungTelefon,
  VerfasserNachname = USR.Nachname,
  VerfasserVorname = USR.Vorname,
  VerfasserKuerzel = USR.Kuerzel,
  VerfasserTelephon = USR.Telephon,
  VerfasserEMail = USR.EMail,

  --Adressat via Standard-Textmarken: Adressat...

  DauerD = dbo.fnLOVMLText('FaDauer', VRL.FaDauerCode, 1),
  DauerF = dbo.fnLOVMLText('FaDauer', VRL.FaDauerCode, 2),
  DauerI = dbo.fnLOVMLText('FaDauer', VRL.FaDauerCode, 3),

  VRL.Inhalt
FROM dbo.KesVerlauf VRL WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwTmUser USR WITH (READUNCOMMITTED) ON USR.UserID = VRL.UserID
;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesVerlauf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Views\Textmarken\vwTmKesVerlauf.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\Standard\CreateViews.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\Testing\CreateTestDB\Standard\CreateViews.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXValidateDBO.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXValidateDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXValidateDBO;
GO
/*===============================================================================================
  $Revision: 17 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this stored procedure to validate database object such as table, view, function,
            store procedure.
    @DBOName:    The name of database object to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: (not used yet)
    @OnlyTypeOf: Specify a type to get only object definition of given type 
                 (e.g. 'U' for user-table, 'V' for view)
  -
  RETURNS: Print out messages of validated parts and result and returns 0 on success, 1 on failure
  -
  REMARKS: Get system types from SELECT * FROM sys.types;
=================================================================================================
  TEST:    EXEC dbo.spXValidateDBO BaPerson;
           EXEC dbo.spXValidateDBO BaAdresse;
           EXEC dbo.spXValidateDBO BaPerson_Relation;
           EXEC dbo.spXValidateDBO KbBuchung;
           EXEC dbo.spXValidateDBO XArchiv;
           EXEC dbo.spXValidateDBO XMenuItem;
           EXEC dbo.spXValidateDBO XTask;
           EXEC dbo.spXValidateDBO VmBewertung;
           EXEC dbo.spXValidateDBO XProfile;
=================================================================================================*/

CREATE PROCEDURE dbo.spXValidateDBO
(
  @DBOName VARCHAR(255),
  @OutputMode INT = NULL,
  @OnlyTypeOf VARCHAR(5) = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  PRINT ('---- Script version: $Revision: 16 $ ----');
  PRINT ('Info: Database "' + DB_NAME() + '"');
  
  -----------------------------------------------------------------------------
  -- setup vars
  -----------------------------------------------------------------------------
  DECLARE @CountFound INT;
  DECLARE @DBOType VARCHAR(10);
  DECLARE @DBOObjectID BIGINT;
  DECLARE @ErrorCounter INT;
  DECLARE @FinalOutput VARCHAR(1000);
  --
  DECLARE @TableColName VARCHAR(255);
  DECLARE @TableColID INT;
  DECLARE @TableColSystemTypeID INT;
  DECLARE @TableColCollationName VARCHAR(255);
  DECLARE @TableColIsNullable BIT; 
  DECLARE @TableColIsIdentity BIT;
  DECLARE @TableColDefaultObjectID INT;
  
  -- constants
  DECLARE @COLLATION VARCHAR(255);
  DECLARE @DEBUGLEVEL INT;
  
  SET @COLLATION = 'Latin1_General_CI_AS';
  SET @DEBUGLEVEL = 0;
  
  -- set other vars
  SET @ErrorCounter = 0;
  
  -- fix name if not trimmed
  SET @DBOName = ISNULL(LTRIM(RTRIM(@DBOName)), '');
  
  -- fix output mode if emtpy
  SET @OutputMode = ISNULL(@OutputMode, 0);
  
  -----------------------------------------------------------------------------
  -- validate unique
  -----------------------------------------------------------------------------
  -- count entries that possibly match
  SELECT @CountFound = COUNT(1)
  FROM sys.objects OBJ
  WHERE OBJ.[name] LIKE @DBOName + '%'
    AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  
  -- check any found
  IF (@CountFound < 1)
  BEGIN
    PRINT ('>>> Error: No database object starting with "' + @DBOName + '" found, please check spelling');
    
    -- failure
    RETURN 1;
  END;
  
  IF (@CountFound = 1)
  BEGIN
    -- get propper name and definition (could be only a part of the name > this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] LIKE @DBOName + '%'
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: LIKE searching: @CountFound = 1');
    END;
  END
  ELSE
  BEGIN
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: Multiple with LIKE found, searching exact now: @CountFound = ' + CONVERT(VARCHAR(50), @CountFound));
    END;
    
    -- check without like
    SELECT @CountFound = COUNT(1)
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@CountFound <> 1)
    BEGIN
      -- output candidates
      SELECT PossibleDBOs = OBJ.[name]
      FROM sys.objects OBJ
      WHERE OBJ.[name] LIKE @DBOName + '%'
        AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
      
      -- output message
      IF (@CountFound < 1)
      BEGIN
        PRINT ('>>> Error: No database object with exact name "' + @DBOName + '" found, please check spelling');
      END
      ELSE
      BEGIN
        PRINT ('>>> Error: Multiple database object with exact name "' + @DBOName + '" found, please check spelling');
      END;
      
      -- failure
      RETURN 1;
    END
    
    -- get propper name and definition (this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  END;

  -----------------------------------------------------------------------------
  -- type depending evaluation
  -----------------------------------------------------------------------------
  
  -- ==========================================================================
  -- TABLE:
  -- ==========================================================================
  IF (@DBOType = 'U')
  BEGIN
    PRINT ('Info: Table "' + @DBOName + '"');
    PRINT ('');

    ---------------------------------------------------------------------------
    -- validate table naming [a-z],[A-Z],[0-9],[_]
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate table prefix
    ---------------------------------------------------------------------------
    IF (@DBOName NOT LIKE 'Ka%' AND 
        @DBOName NOT LIKE 'Ay%' AND 
        @DBOName NOT LIKE 'Ba%' AND 
        @DBOName NOT LIKE 'Bde%' AND 
        @DBOName NOT LIKE 'Bw%' AND 
        @DBOName NOT LIKE 'Bg%' AND 
        @DBOName NOT LIKE 'Cm%' AND 
        @DBOName NOT LIKE 'Ed%' AND 
        @DBOName NOT LIKE 'Fa%' AND 
        @DBOName NOT LIKE 'Fb%' AND 
        @DBOName NOT LIKE 'Fs%' AND 
        @DBOName NOT LIKE 'Gv%' AND 
        @DBOName NOT LIKE 'Ik%' AND 
        @DBOName NOT LIKE 'In%' AND 
        @DBOName NOT LIKE 'Kb%' AND 
        @DBOName NOT LIKE 'Kbu%' AND 
        @DBOName NOT LIKE 'Kes%' AND 
        @DBOName NOT LIKE 'Kg%' AND 
        @DBOName NOT LIKE 'Qry%' AND 
        @DBOName NOT LIKE 'Sst%' AND 
        @DBOName NOT LIKE 'Bfs%' AND 
        @DBOName NOT LIKE 'Sb%' AND 
        @DBOName NOT LIKE 'Wh%' AND 
        @DBOName NOT LIKE 'Wsh%' AND 
        @DBOName NOT LIKE 'Vm%' AND 
        @DBOName NOT LIKE 'X%')
    BEGIN
      PRINT ('>>> Error: The table prefix for table "' + @DBOName + '" is not valid');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate PK
    ---------------------------------------------------------------------------
    SET @TableColName = @DBOName + 'ID';
    SET @TableColID = NULL;
    
    SELECT @TableColID              = column_id,
           @TableColSystemTypeID    = system_type_id,
           @TableColIsNullable      = is_nullable,
           @TableColIsIdentity      = is_identity,
           @TableColDefaultObjectID = default_object_id
    FROM sys.columns
    WHERE object_id = @DBOObjectID
      AND name = @TableColName;
    
    -- check found
    IF (@TableColID IS NULL)
    BEGIN
      PRINT ('>>> Error: The primary key column "' + @TableColName + '" was not found');
      SET @ErrorCounter = @ErrorCounter + 1;
    END
    ELSE
    BEGIN
      -- must be the first column
      IF (@TableColID > 1)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" should be the first column of the table');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be INT
      IF (@TableColSystemTypeID <> 56)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must be typeof INT');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be identity
      IF (@TableColIsIdentity = 0)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" is not an identity column');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be nullable
      IF (@TableColIsNullable = 1)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must not be nullable');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not have a default value
      IF (@TableColDefaultObjectID <> 0)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must not have a default value');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- validate TS
    ---------------------------------------------------------------------------
    SET @TableColName = @DBOName + 'TS';
    SET @TableColID = NULL;
    
    SELECT @TableColID              = column_id,
           @TableColSystemTypeID    = system_type_id,
           @TableColIsNullable      = is_nullable,
           @TableColIsIdentity      = is_identity,
           @TableColDefaultObjectID = default_object_id
    FROM sys.columns
    WHERE object_id = @DBOObjectID
      AND name = @TableColName;
    
    -- check found
    IF (@TableColID IS NULL)
    BEGIN
      PRINT ('>>> Error: The timestamp column "' + @TableColName + '" was not found');
      SET @ErrorCounter = @ErrorCounter + 1;
    END
    ELSE
    BEGIN
      -- must be the last column
      IF (@TableColID <> (SELECT MAX(column_id) 
                          FROM sys.columns
                          WHERE object_id = @DBOObjectID))
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" should be the last column of the table');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be TIMESTAMP
      IF (@TableColSystemTypeID <> 189)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must be typeof TIMESTAMP');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be identity
      IF (@TableColIsIdentity = 1)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not be an identity column');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be nullable
      IF (@TableColIsNullable = 1)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not be nullable');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not have a default value
      IF (@TableColDefaultObjectID <> 0)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not have a default value');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- validate columns existing: creator, created, modifier, modified
    ---------------------------------------------------------------------------
    -- creator
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Creator'
                      AND system_type_id = 167 -- VARCHAR
                      AND max_length = 50))
    BEGIN
      PRINT ('>>> Error: The column "Creator" as VARCHAR(50) is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- created
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Created'
                      AND system_type_id = 61 -- DATETIME
                      AND max_length = 8))
    BEGIN
      PRINT ('>>> Error: The column "Created" as DATETIME is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modifier
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Modifier'
                      AND system_type_id = 167 -- VARCHAR
                      AND max_length = 50))
    BEGIN
      PRINT ('>>> Error: The column "Modifier" as VARCHAR(50) is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modified
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Modified'
                      AND system_type_id = 61 -- DATETIME
                      AND max_length = 8))
    BEGIN
      PRINT ('>>> Error: The column "Modified" as DATETIME is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate columns defaults: creator, created, modifier, modified
    ---------------------------------------------------------------------------
    -- creator (no default)
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.default_constraints
                WHERE parent_object_id = @DBOObjectID
                  AND name = 'DF_' + @DBOName + '_Creator'))
    BEGIN
      PRINT ('>>> Error: The column "Creator" should not have default constraint assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT CreatorDFName = name,
             DFContent     = definition
      FROM sys.default_constraints
      WHERE parent_object_id = @DBOObjectID
        AND name = 'DF_' + @DBOName + '_Creator'
    END;
    
    -- created (must have default)
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.default_constraints
                    WHERE parent_object_id = @DBOObjectID
                      AND name = 'DF_' + @DBOName + '_Created'
                      AND definition LIKE '%GETDATE()%'))
    BEGIN
      PRINT ('>>> Error: The column "Created" should have default constraint for "GETDATE()" assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modifier (no default)
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.default_constraints
                WHERE parent_object_id = @DBOObjectID
                  AND name = 'DF_' + @DBOName + '_Modifier'))
    BEGIN
      PRINT ('>>> Error: The column "Modifier" should not have default constraint assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT CreatorDFName = name,
             DFContent     = definition
      FROM sys.default_constraints
      WHERE parent_object_id = @DBOObjectID
        AND name = 'DF_' + @DBOName + '_Modifier'
    END;
    
    -- modified (must have default)
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.default_constraints
                    WHERE parent_object_id = @DBOObjectID
                      AND name = 'DF_' + @DBOName + '_Modified'
                      AND definition LIKE '%GETDATE()%'))
    BEGIN
      PRINT ('>>> Error: The column "Modified" should have default constraint for "GETDATE()" assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate column naming [a-z],[A-Z],[0-9],[_]
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(
                            name, 'a', ''), 'b', ''), 'c', ''), 'd', ''), 'e', ''), 'f', ''), 'g', ''),
                                  'h', ''), 'i', ''), 'j', ''), 'k', ''), 'l', ''), 'm', ''), 'n', ''),
                                  'o', ''), 'p', ''), 'q', ''), 'r', ''), 's', ''), 't', ''), 'u', ''),
                                  'v', ''), 'w', ''), 'x', ''), 'y', ''), 'z', ''),
                                  '0', ''), '1', ''), '2', ''), '3', ''), '4', ''), '5', ''), '6', ''),
                                  '7', ''), '8', ''), '9', ''),
                                  '_', ''))
                            > 0))
    BEGIN
      PRINT ('>>> Error: There is at least one column name with wrong chars (not in [a-z],[A-Z],[0-9],[_])');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate column naming same as tablename
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE name = @DBOName))
    BEGIN
      PRINT ('>>> Error: There is a column with the same name as the table. This will be a problem with its C# class and property.');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate BIT columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND system_type_id = 104 -- BIT
                  AND default_object_id = 0))
    BEGIN
      PRINT ('>>> Error: There is at least one BIT column without a default value');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameWithoutBITDefault = name
      FROM sys.columns
      WHERE object_id = @DBOObjectID
        AND system_type_id = 104 -- BIT
        AND default_object_id = 0
      ORDER BY column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate BIT defaults (0)
    ---------------------------------------------------------------------------
    -- TODO

    ---------------------------------------------------------------------------
    -- validate defaulted not null columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND default_object_id > 0
                  AND is_nullable = 1))
    BEGIN
      PRINT ('>>> Error: There is at least one column with default value that is nullable');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameWithDefaultNullable = name
      FROM sys.columns
      WHERE object_id = @DBOObjectID
        AND default_object_id > 0
        AND is_nullable = 1
      ORDER BY column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate *Code
    ---------------------------------------------------------------------------
    -- INT
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Code'
                  AND COL.system_type_id <> 56))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Code column not typeof INT');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodeNotTypeOfINT = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Code'
        AND COL.system_type_id <> 56
      ORDER BY COL.column_id;
    END;
    
    -- LOVName
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Code'
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                                  WHERE LOV.LOVName = REPLACE(COL.name, 'Code', ''))))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Code column without a corresponding LOVName');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodeWithoutLOV = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Code'
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                        WHERE LOV.LOVName = REPLACE(COL.name, 'Code', ''))
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate *Codes
    ---------------------------------------------------------------------------
    -- VARCHAR
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Codes'
                  AND (COL.system_type_id <> 167 OR COL.max_length <> 255)))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Codes column not typeof VARCHAR(255)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodesNotTypeOfVARCHAR255 = COL.name,
             ColumnDataType                     = (SELECT TYP.NAME
                                                   FROM sys.types TYP
                                                   WHERE TYP.system_type_id = COL.system_type_id),
             ColumnDataLength                   = COL.max_length
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Codes'
        AND (COL.system_type_id <> 167 OR COL.max_length <> 255)
      ORDER BY COL.column_id;
    END;
    
    -- LOVName
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Codes'
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                                  WHERE LOV.LOVName = REPLACE(COL.name, 'Codes', ''))))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Codes column without a corresponding LOVName');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodesWithoutLOV = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Codes'
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                        WHERE LOV.LOVName = REPLACE(COL.name, 'Codes', ''))
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate clustered index for PK
    ---------------------------------------------------------------------------
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.indexes IDX
                    WHERE IDX.object_id = @DBOObjectID
                      AND IDX.name = 'PK_' + @DBOName
                      AND IDX.type = 1                -- CLUSTERED
                      AND IDX.is_primary_key = 1
                      AND IDX.is_disabled = 0))
    BEGIN
      PRINT ('>>> Error: The primary key does not have a corresponding CLUSTERED index "PK_' + @DBOName + '"');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate FK columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_key_columns FKC
                  INNER JOIN sys.columns     COL ON COL.object_id = @DBOObjectID
                                                AND COL.column_id = FKC.parent_column_id
                WHERE FKC.parent_object_id = @DBOObjectID
                  AND COL.name NOT LIKE '%\_%' ESCAPE '\' -- only those column without '_' > 99% of the others have a description (multi FKs to same table)
                  AND COL.name NOT IN (SELECT SCOL.name
                                       FROM sys.columns SCOL
                                       WHERE SCOL.object_id = FKC.referenced_object_id
                                         AND SCOL.column_id = FKC.referenced_column_id)))
    BEGIN
      PRINT ('>>> Error: There is at least one FK column with different naming compared to corresponding PK column');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidFKColumnName = COL.name
      FROM sys.foreign_key_columns FKC
        INNER JOIN sys.columns     COL ON COL.object_id = @DBOObjectID
                                      AND COL.column_id = FKC.parent_column_id
      WHERE FKC.parent_object_id = @DBOObjectID
        AND COL.name NOT LIKE '%\_%' ESCAPE '\' -- only those column without '_' > 99% of the others have a description (multi FKs to same table)
        AND COL.name NOT IN (SELECT SCOL.name
                             FROM sys.columns SCOL
                             WHERE SCOL.object_id = FKC.referenced_object_id
                               AND SCOL.column_id = FKC.referenced_column_id);
    END;
    
    ---------------------------------------------------------------------------
    -- validate foreignkeys naming
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_keys FKS
                WHERE FKS.parent_object_id = @DBOObjectID
                  AND (-- FK name
                       FKS.name NOT LIKE 'FK\_' + @DBOName + '\_%' ESCAPE '\'
                       -- PK table without description
                    OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                         CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') = ''
                    AND REPLACE(FKS.name, 'FK_' + @DBOName + '_', '') NOT IN (SELECT TBL.name
                                                                              FROM sys.tables TBL))
                       -- PK table with description
                    OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                         CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') <> ''
                    AND SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                  CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))) NOT IN (SELECT TBL.name
                                                                                                         FROM sys.tables TBL)))))
    BEGIN
      PRINT ('>>> Error: There is at least one FK which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidFKName = FKS.name
      FROM sys.foreign_keys FKS
      WHERE FKS.parent_object_id = @DBOObjectID
        AND (-- FK name
             FKS.name NOT LIKE 'FK\_' + @DBOName + '\_%' ESCAPE '\'
             -- PK table without description
          OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                               CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') = ''
          AND REPLACE(FKS.name, 'FK_' + @DBOName + '_', '') NOT IN (SELECT TBL.name
                                                                    FROM sys.tables TBL))
             -- PK table with description
          OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                               CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') <> ''
          AND SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                        CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))) NOT IN (SELECT TBL.name
                                                                                               FROM sys.tables TBL)));
    END;
    
    ---------------------------------------------------------------------------
    -- validate foreignkeys having at least one index that starts with column
    -- --> valid are IX or UK
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_keys FKS
                  INNER JOIN sys.foreign_key_columns FKC ON FKC.parent_object_id = FKS.parent_object_id
                                                        AND FKC.constraint_object_id = FKS.object_id
                  INNER JOIN sys.columns             COL ON COL.object_id = @DBOObjectID
                                                        AND COL.column_id = FKC.parent_column_id
                WHERE FKS.parent_object_id = @DBOObjectID
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM sys.indexes IDX
                                  WHERE IDX.object_id = @DBOObjectID
                                    AND IDX.type = 2            -- only NONCLUSTERED
                                    AND IDX.is_primary_key = 0  -- only FKs
                                    AND (IDX.name = 'IX_' + @DBOName + '_' + COL.name OR 
                                         IDX.name LIKE 'IX\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\' OR
                                         IDX.name = 'UK_' + @DBOName + '_' + COL.name OR 
                                         IDX.name LIKE 'UK\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\'))))
    BEGIN
      PRINT ('>>> Error: There is at least one FK which does not have an index assigned (each FK should have its IX or UK)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT MissingIXOrUKForFKCol = COL.name,
             MissingIXOrUKForFK    = FKS.name
      FROM sys.foreign_keys FKS
        INNER JOIN sys.foreign_key_columns FKC ON FKC.parent_object_id = FKS.parent_object_id
                                              AND FKC.constraint_object_id = FKS.object_id
        INNER JOIN sys.columns             COL ON COL.object_id = @DBOObjectID
                                              AND COL.column_id = FKC.parent_column_id
      WHERE FKS.parent_object_id = @DBOObjectID
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM sys.indexes IDX
                        WHERE IDX.object_id = @DBOObjectID
                          AND IDX.type = 2            -- only NONCLUSTERED
                          AND IDX.is_primary_key = 0  -- only FKs
                          AND (IDX.name = 'IX_' + @DBOName + '_' + COL.name OR 
                               IDX.name LIKE 'IX\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\' OR
                               IDX.name = 'UK_' + @DBOName + '_' + COL.name OR 
                               IDX.name LIKE 'UK\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\'));
    END;
    
    ---------------------------------------------------------------------------
    -- foreignkeys sorting just after PK in table
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate collation of columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE COL.object_id = @DBOObjectID
                  AND COL.collation_name IS NOT NULL
                  AND COL.collation_name <> @COLLATION))
    BEGIN
      PRINT ('>>> Error: There is at least one column with non-standard collation ("' + @COLLATION + '")');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidCollationColumnName = COL.name,
             CollationNameOfColumn      = COL.collation_name
      FROM sys.columns COL
      WHERE COL.object_id = @DBOObjectID
        AND COL.collation_name IS NOT NULL
        AND COL.collation_name <> @COLLATION
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- indexes naming IX_<TableName>
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.indexes
                WHERE object_id = @DBOObjectID
                  AND type = 2                  -- NONCLUSTERED
                  AND is_unique_constraint = 0  -- no UKs
                  AND name NOT LIKE 'IX\_' + @DBOName + '\_%' ESCAPE '\'))
    BEGIN
      PRINT ('>>> Error: There is at least one IX which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidIXName = name
      FROM sys.indexes
      WHERE object_id = @DBOObjectID
        AND type = 2                  -- NONCLUSTERED
        AND is_unique_constraint = 0  -- no UKs
        AND name NOT LIKE 'IX\_' + @DBOName + '\_%' ESCAPE '\';
    END;
    
    ---------------------------------------------------------------------------
    -- indexes naming (IX, UK) IX_<TableName>[<_ColumnName]+
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- unique-key naming (UK) UK_<TableName>...
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.indexes
                WHERE object_id = @DBOObjectID
                  AND type = 2                  -- NONCLUSTERED
                  AND is_unique_constraint = 1  -- UKs
                  AND name NOT LIKE 'UK\_' + @DBOName + '\_%' ESCAPE '\'))
    BEGIN
      PRINT ('>>> Error: There is at least one UK which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidUKName = name
      FROM sys.indexes
      WHERE object_id = @DBOObjectID
        AND type = 2                  -- NONCLUSTERED
        AND is_unique_constraint = 1  -- UKs
        AND name NOT LIKE 'UK\_' + @DBOName + '\_%' ESCAPE '\';
    END;
    
    ---------------------------------------------------------------------------
    -- unique-key type (UK) UK_<TableName>... >> no unique indexes
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate IX/UK having same filegroup as table
    ---------------------------------------------------------------------------
    IF ((SELECT COUNT(DISTINCT IDX.groupid)
         FROM sys.tables        TBL WITH (NOLOCK)
           LEFT JOIN sysindexes IDX WITH (NOLOCK) ON IDX.id = TBL.object_id
                                                 AND INDEXPROPERTY(IDX.id, IDX.name, 'IsAutoStatistics') = 0
         WHERE TBL.object_id = @DBOObjectID) > 1)
    BEGIN
      PRINT ('>>> Error: There is at least one IX/UK with different filegroup (each of them should have same as table)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT TableName    = TBL.name,
             IndexName    = ISNULL(IDX.[name], 'NA'),
             IndexType    = CASE 
                              WHEN IDX.indid = 0 THEN 'Table Row Data (table has no clustered index)'
                              WHEN IDX.indid = 1 THEN 'Clustered Index (and table row data)'
                              WHEN IDX.indid = 255 THEN 'TEXT/NTEXT/IMAGE/XML Column Data'
                              ELSE 'NonClustered Index'
                            END,
              IndexID     = ISNULL(IDX.indid, -1),
              FileGroup   = FILEGROUP_NAME(IDX.groupid),
              FileGroupID = IDX.groupid
      FROM sys.tables        TBL WITH (NOLOCK)
        LEFT JOIN sysindexes IDX WITH (NOLOCK) ON IDX.id = TBL.object_id
                                              AND INDEXPROPERTY(IDX.id, IDX.name, 'IsAutoStatistics') = 0
      WHERE TBL.object_id = @DBOObjectID
      ORDER BY IndexID;
    END;
    
    ---------------------------------------------------------------------------
    -- validating default constraints DF
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.objects OBJ
                WHERE OBJ.parent_object_id = @DBOObjectID
                  AND type = 'D'
                  AND (OBJ.name NOT LIKE 'DF\_' + @DBOName + '\_%' ESCAPE '\'
                    OR REPLACE(OBJ.name, 'DF_' + @DBOName + '_', '') NOT IN (SELECT COL.name
                                                                             FROM sys.columns COL
                                                                             WHERE COL.object_id = @DBOObjectID))))
    BEGIN
      PRINT ('>>> Error: There is at least one DF which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidDefaultConstraintName = OBJ.name
      FROM sys.objects OBJ
      WHERE OBJ.parent_object_id = @DBOObjectID
        AND type = 'D'
        AND (OBJ.name NOT LIKE 'DF\_' + @DBOName + '\_%' ESCAPE '\'
          OR REPLACE(OBJ.name, 'DF_' + @DBOName + '_', '') NOT IN (SELECT COL.name
                                                                   FROM sys.columns COL
                                                                   WHERE COL.object_id = @DBOObjectID))
    END;
    
    ---------------------------------------------------------------------------
    -- constraints CK
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- trigger
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- extended properties for table
    ---------------------------------------------------------------------------
    -- table description
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.extended_properties EXT
                    WHERE EXT.major_id = @DBOObjectID
                      AND EXT.name = 'MS_Description'
                      AND EXT.minor_id = 0
                      AND ISNULL(EXT.value, '') NOT IN ('', '(null)')))
    BEGIN
      PRINT ('>>> Error: The table "' + @DBOName + '" does not have a description assigned (extended property "MS_Description")');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- table author
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.extended_properties EXT
                    WHERE EXT.major_id = @DBOObjectID
                      AND name = 'Author'
                      AND EXT.minor_id = 0
                      AND ISNULL(EXT.value, '') NOT IN ('', '(null)')))
    BEGIN
      PRINT ('>>> Error: The table "' + @DBOName + '" does not have an author assigned (extended property "Author")');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- error?
    ---------------------------------------------------------------------------
    IF (@ErrorCounter = 0)
    BEGIN
      SET @FinalOutput = 'Info: The table "' + @DBOName + '" survived the basic checks without any remarks!';
    END
    ELSE
    BEGIN
      SET @FinalOutput = 'Info: The script detected <' + CONVERT(VARCHAR(50), @ErrorCounter) + '> problem(s) for table "' + @DBOName + '"!';
    END;
    
    -- done
    GOTO DONE;
  END;
  -- ==========================================================================
  
  -- ==========================================================================
  -- type not supported
  -- ==========================================================================
  PRINT ('>>> Error: The given database object "' + @DBOName + '" with type "' + @DBOType + '" is not supported for validation yet')
  RETURN 1;
  -- ==========================================================================

-- ****************************************************************************
-- FINAL STUFF
-- ****************************************************************************
DONE:
  IF (@ErrorCounter > 0)
  BEGIN
    PRINT ('');
  END;

  PRINT ('--------------------------------------------------------------------------------');
  PRINT @FinalOutput;
  PRINT ('--------------------------------------------------------------------------------');

  IF (@ErrorCounter = 0)
  BEGIN
    -- no problems
    PRINT ('                        boing         boing         boing');
    PRINT ('          e-e           . - .         . - .         . - .');
    PRINT ('         (\_/)\       ''       `.   ,''       `.   ,''       .');
    PRINT ('          `-''\ `--.___,         . .           . .          .');
    PRINT ('             ''\( ,_.-''''');
    PRINT ('                \\               "             "            a:f');
  END
  ELSE
  BEGIN
    -- found problems
    PRINT ('          \|||/');
    PRINT ('          (o o)');
    PRINT ('  ,~~~ooO~~(_)~~~~~~~~~~,');
    PRINT ('  |       Please        |');
    PRINT ('  |  fix the problems!  |');
    PRINT ('  |       Thanks!       |');
    PRINT ('  ''~~~~~~~~~~~~~~ooO~~~~''');
    PRINT ('         |__|__|');
    PRINT ('          || ||');
    PRINT ('         ooO Ooo');
  END;
  
  PRINT ('--------------------------------------------------------------------------------');
  
  -- return value
  RETURN CASE
           WHEN @ErrorCounter = 0 THEN 0    -- ok
           ELSE 1                           -- failure
         END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXValidateDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXValidateDBO.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXExtendedProperty;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  (Re)create or delete extended properties for database objects
    @DBOName:                 The name of the main database object (e.g. table "BaPerson")
    @ChildDBOName:            The name of the sub database object (e.g. column "BaPersonID")
    @ExtendedPropertyName:    The name of the extended property (e.g. "MS_Description")
    @ExtendedPropertyContent: The value of the extended property (e.g. description)
    @ErrorIfExisting:         Flag: 0=if extended property already exists, it will be dropped first
                                    1=if extended property already exists, an error will raise
    @DeleteOnly:              Flag: 0=a new extended property will be added
                                    1=no new extended property will be added - dropping only
  -
  RETURNS: No resultset will be returned - only printed messages
=================================================================================================
  TEST:    EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 0, 0;
           --
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 0, 0;
           -- expecting errors
           EXEC dbo.spXExtendedProperty 'XClass', 'abc', 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClasse', NULL, 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, NULL, 'TestMe', 0, 0;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'Abc', NULL, 0, 0;
           EXEC dbo.spXExtendedProperty NULL, NULL, 'Abc', 'TestMe', 0, 0;
           EXEC dbo.spXExtendedProperty '', NULL, 'Abc', 'TestMe', 0, 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spXExtendedProperty
(
  @DBOName VARCHAR(255),
  @ChildDBOName VARCHAR(255),
  @ExtendedPropertyName VARCHAR(255),
  @ExtendedPropertyContent VARCHAR(2000),
  @ErrorIfExisting BIT = 0,
  @DeleteOnly BIT = 0
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @DBOType VARCHAR(255);
  DECLARE @ChildDBOType VARCHAR(255);
  DECLARE @ExtendedPropertyExistsAlready BIT;
  DECLARE @ErrorMessage VARCHAR(2000);
  DECLARE @Schema VARCHAR(200);
  
  SET @DBOType = NULL;
  SET @ChildDBOType = NULL;
  SET @ExtendedPropertyExistsAlready = NULL;
  
  -----------------------------------------------------------------------------
  -- get types
  -----------------------------------------------------------------------------
  -- tables (with optional columns)
  IF (EXISTS (SELECT TOP 1 1
              FROM sys.tables
              WHERE name = @DBOName))
  BEGIN
    SET @DBOType = 'TABLE';
    SET @Schema = ( SELECT DISTINCT TABLE_SCHEMA
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = @DBOName );
    
    IF (@ChildDBOName IS NOT NULL)
    BEGIN
      SET @ChildDBOType = 'COLUMN';
    END;
  END;
  
  -- todo: if required, add further type handling...
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DBOName, '') = '' OR ISNULL(@ExtendedPropertyName, '') = '' OR ISNULL(@ExtendedPropertyContent, '') = '')
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: Invalid database object "' + ISNULL(@DBOName, '??') + '" or extended property name/content "' + ISNULL(@ExtendedPropertyName, '') + '".';
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  IF (@DBOType IS NULL OR (@ChildDBOName IS NOT NULL AND @ChildDBOType IS NULL))
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: Could not get known type of database object "' + ISNULL(@DBOName, '??') + '". Either name is not valid or type "' + ISNULL(@DBOType, '') + '" is not supported.';
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- check existing handling (type specific)
  -----------------------------------------------------------------------------
  IF (@DBOType = 'TABLE')
  BEGIN
    -- check if existing
    IF (EXISTS (SELECT TableName     = OBJECT_NAME(EXT.major_id), 
                       ColumnName    = COL.name, 
                       PropertyName  = EXT.name, 
                       PropertyValue = EXT.value
                FROM sys.extended_properties EXT
                  LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id
                                                AND COL.column_id = EXT.minor_id
                WHERE EXT.class_desc = 'OBJECT_OR_COLUMN'
                  AND OBJECT_NAME(EXT.major_id) = @DBOName
                  AND EXT.name = @ExtendedPropertyName
                  AND ((@ChildDBOName IS NULL AND EXT.minor_id = 0) 
                    OR (@ChildDBOName IS NOT NULL AND COL.name = @ChildDBOName))
               ))
    BEGIN
      SET @ExtendedPropertyExistsAlready = 1;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- general extended property handling
  -----------------------------------------------------------------------------  
  -- check if can delete if existing
  IF (@ErrorIfExisting = 1 AND @ExtendedPropertyExistsAlready = 1)
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: The extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" already exists for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', '');
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  -- check if need to delete
  IF (@ExtendedPropertyExistsAlready = 1)
  BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
      -- delete extended property
      EXEC sys.sp_dropextendedproperty @name = @ExtendedPropertyName, 
                                       @level0type = N'SCHEMA', @level0name = @Schema, 
                                       @level1type = @DBOType, @level1name = @DBOName, 
                                       @level2type = @ChildDBOType, @level2name = @ChildDBOName;
      
      COMMIT;
      
      -- show info
      PRINT ('Info: Dropped extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', ''));
    END TRY
    BEGIN CATCH
      -- rollback any action
      ROLLBACK TRANSACTION;
      
      -- set error part
      SET @ErrorMessage = ERROR_MESSAGE()
      
      -- do not continue
      RAISERROR ('Error: Could not drop extended property. Database error was: %s.', 18, 1, @ErrorMessage);
      RETURN;
    END CATCH;
  END;
  
  -- check if need to continue
  IF (@DeleteOnly = 1)
  BEGIN
    -- no more to do
    RETURN;
  END;
  
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to create extended property
    EXEC sys.sp_addextendedproperty @name = @ExtendedPropertyName, @value = @ExtendedPropertyContent, 
                                    @level0type = N'SCHEMA', @level0name = @Schema, 
                                    @level1type = @DBOType, @level1name = @DBOName, 
                                    @level2type = @ChildDBOType, @level2name = @ChildDBOName;
    
    COMMIT;
    
    -- show info
    PRINT ('Info: Added extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', ''));
  END TRY
  BEGIN CATCH
    -- rollback any action
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()
    
    -- do not continue
    RAISERROR ('Error: Could not add extended property. Database error was: %s.', 18, 1, @ErrorMessage);
    RETURN;
  END CATCH;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaInsertFaFall;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt INSERT in FaFall aus, falls FaFall eine Tabelle ist, sonst wird ein 
            erfolgreiches INSERT vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaInsertFaFall …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaInsertFaFall
(
  @UserID     int,
  @BaPersonID int,
  @DatumVon   datetime,
  @DatumBis   datetime
)
AS
BEGIN
  -- nur in Tabelle inserten
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFall' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'INSERT INTO dbo.FaFall(UserID, BaPersonID, DatumVon, DatumBis)
                       VALUES (@UserID_, @BaPersonID_, @DatumVon_, @DatumBis_)
                       
                       SELECT FaFallID = SCOPE_IDENTITY()';
    SET @ParmDefinition = N'@UserID_ int, @BaPersonID_ int, @DatumVon_ datetime, @DatumBis_ datetime';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @UserID_ = @UserID, @BaPersonID_ = @BaPersonID, @DatumVon_ = @DatumVon, @DatumBis_ = @DatumBis;
  END
  ELSE BEGIN
    SELECT FaFallID = @BaPersonID -- fake
  END
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDBO.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spDBO;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show the dbo definition (columns, additional data, code) for given dbo name
    @DBOName:    The name of database object to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: - Tables/Views: 
                   - 0 = default (both: table and columns)
                   - 1 = only table
                   - 2 = only columns
                   - 3 = print columns as DECLARE for vars instead of description content
                 - Others:
                   - 0 = default (print output)
                   - 1 = output of definition as select
    @OnlyTypeOf: Specify a type to get only object definition of given type 
                 (e.g. 'U' for user-table, 'V' for view)
  -
  RETURNS: Shows the definition of the object and returns 0 on success, 1 on failure
=================================================================================================
  TEST:    EXEC dbo.spDBO 'BaPerson';
           EXEC dbo.spDBO 'BaPerson', NULL, 'U';
           EXEC dbo.spDBO 'XUser', NULL;
           EXEC dbo.spDBO 'XProfileTag', NULL;
           --
           EXEC dbo.spDBO 'fnDateOf', 1;
           EXEC dbo.spDBO 'fnDateOf', 0;
           --
           EXEC dbo.spDBO 'spKbWVEinzelpostenGenerieren', 1;
           EXEC dbo.spDBO 'spKbWVEinzelpostenGenerieren', 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spDBO
(
  @DBOName VARCHAR(200),
  @OutputMode INT = NULL,
  @OnlyTypeOf VARCHAR(5) = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;

  -----------------------------------------------------------------------------
  -- setup vars
  -----------------------------------------------------------------------------
  DECLARE @CountFound INT;
  DECLARE @DBOType VARCHAR(10);
  DECLARE @DBOObjectID BIGINT;
  
  -- constants
  DECLARE @DEBUGLEVEL INT;
  SET @DEBUGLEVEL = 0;
  
  -- fix name if not trimmed
  SET @DBOName = ISNULL(LTRIM(RTRIM(@DBOName)), '');
  
  -- fix output mode if emtpy
  SET @OutputMode = ISNULL(@OutputMode, 0);
  
  -----------------------------------------------------------------------------
  -- validate unique
  -----------------------------------------------------------------------------
  -- count entries that possibly match
  SELECT @CountFound = COUNT(1)
  FROM sys.objects OBJ
  WHERE OBJ.[name] LIKE @DBOName + '%'
    AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  
  -- check any found
  IF (@CountFound < 1)
  BEGIN
    PRINT ('>>> Error: No database object starting with "' + @DBOName + '" found, please check spelling');
    
    -- failure
    RETURN 1;
  END;
  
  IF (@CountFound = 1)
  BEGIN
    -- get propper name and definition (could be only a part of the name > this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] LIKE @DBOName + '%'
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: LIKE searching: @CountFound = 1');
    END;
  END
  ELSE
  BEGIN
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: Multiple with LIKE found, searching exact now: @CountFound = ' + CONVERT(VARCHAR(50), @CountFound));
    END;
    
    -- check without like
    SELECT @CountFound = COUNT(1)
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@CountFound <> 1)
    BEGIN
      -- output candidates
      SELECT PossibleDBOs = OBJ.[name]
      FROM sys.objects OBJ
      WHERE OBJ.[name] LIKE @DBOName + '%'
        AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
      
      -- output message
      IF (@CountFound < 1)
      BEGIN
        PRINT ('>>> Error: No database object with exact name "' + @DBOName + '" found, please check spelling');
      END
      ELSE
      BEGIN
        PRINT ('>>> Error: Multiple database object with exact name "' + @DBOName + '" found, please check spelling');
      END;
      
      -- failure
      RETURN 1;
    END
    
    -- get propper name and definition (this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  END;

  -----------------------------------------------------------------------------
  -- type depending evaluation
  -----------------------------------------------------------------------------
  
  -- ==========================================================================
  -- TABLE/VIEW:
  -- ==========================================================================
  IF (@DBOType IN ('U', 'V'))
  BEGIN
    ---------------------------------------------------------------------------
    -- init temporary table for description
    ---------------------------------------------------------------------------
    DECLARE @TmpDescription TABLE
    (
      TableName VARCHAR(255) NOT NULL,
      ColumnName VARCHAR(255),
      PropertyName VARCHAR(255),
      PropertyValue VARCHAR(2000)
    );
    
    -----------------------------------------------------------------------------
    -- get description for given table
    -----------------------------------------------------------------------------
    -- fill data
    INSERT INTO @TmpDescription (TableName, ColumnName, PropertyName, PropertyValue)
      SELECT TableName     = OBJECT_NAME(EXT.major_id),
             ColumnName    = COL.Name,
             PropertyName  = EXT.Name,
             PropertyValue = CONVERT(VARCHAR(2000), EXT.value)
      FROM sys.extended_properties EXT
        LEFT JOIN sys.columns      COL ON COL.OBJECT_ID = EXT.major_id 
                                      AND COL.column_id = EXT.minor_id
      WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
        AND EXT.major_id = @DBOObjectID                                 -- only for current dbo
        AND EXT.Name IN ('MS_Description', 'Author', 'Used_In', 'NamespaceExtension');
    
    -----------------------------------------------------------------------------
    -- show table information
    -----------------------------------------------------------------------------
    IF (@OutputMode IN (0, 1) OR @OutputMode < 0 OR @OutputMode > 2)
    BEGIN
      SELECT [TableName]           = @DBOName,
             [Author]              = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'Author'),
             [UsedIn]              = (SELECT TMP.PropertyValue
                                     FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'Used_In'),
             [Description]         = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'MS_Description'),
             [ColumnsCount]        = (SELECT COUNT(1)
                                      FROM sys.columns
                                      WHERE object_id = @DBOObjectID),
             [NamespaceExtension]  = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'NamespaceExtension');
    END;
    
    -----------------------------------------------------------------------------
    -- show table-column information
    -----------------------------------------------------------------------------
    IF (@OutputMode IN (0, 2) OR @OutputMode < 0 OR @OutputMode > 2)
    BEGIN
      SELECT ColumnName           = COL.name,
             DataType             = UPPER(TYP.name),
             [Length]             = CASE
                                      WHEN TYP.name LIKE '%CHAR' AND COL.max_length = -1 THEN 'MAX'
                                      ELSE CONVERT(VARCHAR(20), COL.max_length)
                                    END,
             NotNull              = CASE COL.is_nullable 
                                      WHEN 1 THEN ''
                                      ELSE 'x'
                                    END,
             DefaultValue         = REPLACE(REPLACE(ISNULL((DEF.Text), ''), '((0))', '0'), '(0)', '0'),
             PrimaryKey           = ISNULL((SELECT CASE SKEY.name 
                                                     WHEN NULL THEN '' 
                                                     ELSE 'x' 
                                                   END
                                            FROM sys.key_constraints       SKEY
                                              INNER JOIN sys.index_columns SIXC ON SIXC.object_id = SKEY.parent_object_id
                                                                               AND SIXC.index_id = SKEY.unique_index_id
                                                                               AND SIXC.column_id = COL.column_id
                                            WHERE SKEY.type = 'PK'
                                              AND SKEY.parent_object_id = COL.object_id), ''), 
             [Identity]           = CASE COL.is_identity
                                      WHEN 1 THEN 'x'
                                      ELSE ''
                                    END,
             ForeignKey           = ISNULL((SELECT DISTINCT -- used for multiple FKs
                                                   CASE SCOL.name 
                                                     WHEN NULL THEN '' 
                                                     ELSE 'x' 
                                                   END
                                            FROM sys.foreign_key_columns SFKC
                                              INNER JOIN sys.columns     SCOL ON SCOL.object_id = COL.object_id
                                                                             AND SCOL.column_id = COL.column_id
                                                                             AND SCOL.column_id = SFKC.parent_column_id
                                            WHERE SFKC.parent_object_id = COL.object_id), ''),
             [Description]        = CASE @OutputMode
                                      WHEN 3 THEN -- output as var declaration
                                                  'DECLARE @' + COL.name + ' ' + 
                                                  CASE
                                                    WHEN TYP.name IN ('DECIMAL', 'NUMERIC')
                                                      THEN UPPER(TYP.name) + '(x, y);  -- TODO: set x, y'
                                                    WHEN TYP.name IN ('FLOAT', 'VARCHAR', 'CHAR', 'NVARCHAR', 'NCHAR', 'BINARY', 'VARBINARY')
                                                      THEN UPPER(TYP.name) + '(' + CASE
                                                                                     WHEN TYP.name LIKE '%CHAR' AND COL.max_length = -1 THEN 'MAX'
                                                                                     ELSE CONVERT(VARCHAR(20), COL.max_length)
                                                                                   END + ');'
                                                    WHEN TYP.name = 'TEXT'      THEN 'VARCHAR(MAX);'  + '  -- original as "TEXT"'
                                                    WHEN TYP.name = 'NTEXT'     THEN 'NVARCHAR(MAX);' + '  -- original as "NTEXT"'
                                                    WHEN TYP.name = 'TIMESTAMP' THEN 'BINARY(8);'     + '  -- original as "TIMESTAMP"'
                                                    ELSE UPPER(TYP.name) + ';'
                                                  END
                                      ELSE (SELECT TMP.PropertyValue
                                            FROM @TmpDescription TMP
                                            WHERE TMP.ColumnName = COL.[Name] 
                                              AND TMP.PropertyName = 'MS_Description')
                                    END,
             [NamespaceExtension] = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName = COL.[Name] 
                                        AND TMP.PropertyName = 'NamespaceExtension')
      FROM sys.columns         COL
        INNER JOIN sys.types   TYP ON TYP.system_type_id = COL.system_type_id
        LEFT  JOIN syscomments DEF ON DEF.id = COL.default_object_id
      WHERE COL.object_id = @DBOObjectID
      ORDER BY COL.column_id;
    END;

    -- return value
    RETURN CASE @@ROWCOUNT 
             WHEN 0 THEN 1 
             ELSE 0 
           END;
  END;
  -- ==========================================================================
  
  
  
  
  -- ==========================================================================
  -- FUNCTION/STOREDPROCEDURE/TRIGGER/CONSTRAINT:
  -- ==========================================================================
  IF (@DBOType IN ('FN', 'IF', 'TF', 'P', 'TR', 'C', 'D'))
  BEGIN
    -- init vars
    DECLARE @DBODefinition VARCHAR(MAX);
    
    -- get definition
    SET @DBODefinition = ISNULL(OBJECT_DEFINITION(OBJECT_ID(@DBOName)), '>>> Error: Could not get object definition of "' + @DBOName + '" with type "' + @DBOType + '"');
    
    IF (@OutputMode = 1)
    BEGIN
      -- output definiton within SELECT statement
      SELECT [DBOName]    = @DBOName,
             [Length]     = LEN(@DBODefinition),
             [Definition] = @DBODefinition;
    END
    ELSE
    BEGIN
      -- init vars
      DECLARE @DBODefLength BIGINT;
      DECLARE @DBODefCharAtNewLine BIGINT;
            
      -- print can handle only 8000 chars, so we need to check that
      IF (LEN(@DBODefinition) < 8000)
      BEGIN
        -- print out directly
        PRINT (@DBODefinition);
      END
      ELSE
      BEGIN
        -- print out in multiple steps
        WHILE (LEN(@DBODefinition) > 0)
        BEGIN
          -- get position of next newline to have proper text output
          SET @DBODefCharAtNewLine = CHARINDEX(CHAR(10), SUBSTRING(@DBODefinition, 1, 8000), 6000);
         
          IF (@DBODefCharAtNewLine < 1)
          BEGIN
            -- no newline, take max output
            SET @DBODefCharAtNewLine = 8000;
          END;
          
          -- print out first part of chars
          PRINT (SUBSTRING(@DBODefinition, 1, @DBODefCharAtNewLine));
          SET @DBODefLength = LEN(@DBODefinition);
          
          -- cut first part of chars
          IF (@DBODefLength > @DBODefCharAtNewLine)
          BEGIN
            SET @DBODefinition = SUBSTRING(@DBODefinition, @DBODefCharAtNewLine, @DBODefLength - @DBODefCharAtNewLine);
          END
          ELSE
          BEGIN
            SET @DBODefinition = '';
          END;
        END;
      END;
    END;
    
    -- success
    RETURN 0;
  END;
  -- ==========================================================================
  
  
  
  
  -- ==========================================================================
  -- type not supported
  -- ==========================================================================
  PRINT ('>>> Error: The given database object "' + @DBOName + '" with type "' + @DBOType + '" is not supported')
  
  -- failure
  RETURN 1;
  -- ==========================================================================
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\spDBO.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\TBL.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\TBL.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject TBL;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show the table-definition (columns, additional data) for given table
    @DBOName:    The name of table to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: - Tables: 
                   - 0 = default (both: table and columns)
                   - 1 = only table
                   - 2 = only columns
  -
  RETURNS: Shows the definition of the table
=================================================================================================
  TEST:    EXEC dbo.TBL 'BaPerson';
           EXEC dbo.TBL 'BaPerson', 0;
           EXEC dbo.TBL 'BaPerson', 1;
           EXEC dbo.TBL 'BaPerson', 2;
           --
           TBL BaPerson;
           TBL BaPerson, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.TBL
(
  @DBOName VARCHAR(200),
  @OutputMode INT = NULL
)
AS
BEGIN
  EXEC dbo.spDBO @DBOName, @OutputMode, 'U';
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\TBL.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\TBL.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\LOV.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\LOV.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject LOV;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show LOVCode entries for LIKE matching search value
    @LOVSerachValue: The search name for any LOVName containing the name
  -
  RETURNS: Table of matching entries within table LOVCode
=================================================================================================
  TEST:    LOV Modul
=================================================================================================*/

CREATE PROCEDURE dbo.LOV
(
  @SearchLOVName VARCHAR(50)
)
AS
BEGIN
  SELECT LOVName, 
         Code, 
         Text, 
         TextTID, 
         SortKey, 
         ShortText, 
         ShortTextTID, 
         BFSCode, 
         Value1, 
         Value1TID, 
         Value2, 
         Value2TID, 
         Value3, 
         Value3TID, 
         Description,
         LOVCodeName,
         IsActive,
         System, 
         XLOVCodeTS
  FROM dbo.XLOVCode WITH (READUNCOMMITTED) 
  WHERE LOVName LIKE '%' + @SearchLOVName + '%'
  ORDER BY LOVName, SortKey;
END;

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\LOV.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\LOV.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\USR.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\USR.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject USR
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Search for users using either name, login name or ID
    @UserSearchValue: .
  -
  RETURNS: .
=================================================================================================
  TEST: USR biag
=================================================================================================*/
CREATE PROCEDURE [dbo].[USR]
(
  @UserSearchValue VARCHAR(50)
)
AS
BEGIN
  SELECT *
  FROM dbo.XUser
  WHERE LastName LIKE '%' + @UserSearchValue + '%'
     OR FirstName LIKE '%' + @UserSearchValue + '%'
     OR LogonName LIKE  '%' + @UserSearchValue + '%'
     OR ShortName LIKE  '%' + @UserSearchValue + '%'
     OR CONVERT(VARCHAR, UserID) LIKE '%' + @UserSearchValue + '%'
  ORDER BY LastName, FirstName;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\USR.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\DBOs\Stored Procedures\System\USR.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to add server-version to table XDBServerVersion. With this, we can
           always proof which version was installed at a given time.
=================================================================================================
I wrote about versioning of old software recently and how I had to restore an old version of
SQL Server in response to a lawsuit. We had some challenges because the backup file that we
had was from years before and we weren't sure which version of SQL Server we needed. I forget
how we finally determined which service pack was needed, perhaps we read master somehow to
get a build.

In any case, when you apply patches or change how SQL Server functions, you can change the
way that code is executed or even the results that might be returned to an application.
You would hope that code would break and error out rather than return different results
than you expect.
Since many of us patch servers when Service Packs come out, or when we find a hot fix we
need, and we are constantly deploying and changing code, do we pay enough attention to
the server version as we make these deployments? I started thinking about this after the
last editorial and I think that we often take it for granted that we can easily recreate
our environments.

Consider what would happen in the event of a disaster. Suppose that one of your server
instances, any particular instance, died and you had to go back to a backup of the database,
would you know what version of SQL Server is needed? Do you know what version each of your
instances is using right now?

In some ways this makes me think that only installing RTM and Service Pack versions in
your production environment is a good idea. It's easier to track things if you keep all
your instances within a very narrow band of versions, and the worst case would be attempting
a restore on RTM, then SP1, then SP2, etc. until you hit the correct version. Imagine now
if you had to work through the various builds on my build list.

I used to think that I'd want to keep current on my patches. In one large environment, we
were actually pretty good about deploying patches to hundreds of instances inside a month,
so we always had a large percentage of our servers, and usually all the critical servers,
at the same patch level. However if a disaster had occurred within the month, we wouldn't
necessarily have been sure of what versions were installed.

I really don't have a great recommendation on how to handle this other than build some
automated system that tracks the current build number on a daily basis, perhaps even
putting it in each database. At least then you'll have it handy in the event of a disaster.

Steve Jones from SQLServerCentral.com

See: http://www.sqlservercentral.com/articles/Administration/2960/
=================================================================================================*/

-------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

------------------------------------------------------------------------------
-- init vars
------------------------------------------------------------------------------
DECLARE @LastServerVersion VARCHAR(255);

------------------------------------------------------------------------------
-- get last server version stored in table
------------------------------------------------------------------------------
SELECT TOP 1
       @LastServerVersion = DBS.ServerVersion
FROM dbo.XDBServerVersion DBS WITH (READUNCOMMITTED)
ORDER BY XDBServerVersionID DESC;

------------------------------------------------------------------------------
-- compare with current version
------------------------------------------------------------------------------
IF (ISNULL(@LastServerVersion, '') <> ISNULL(@@VERSION, '??'))
BEGIN
  -- automatically insert new version if last entry does not match first entry
  INSERT INTO dbo.XDBServerVersion (Creator)
  VALUES ('ReleaseScript')
  
  -- info
  PRINT ('Info: New database-server-version was detected and inserted in table XDBServerVersion: ' + ISNULL(@@VERSION, '??'));
END
ELSE
BEGIN
  -- still having the same version as in previous release
  -- info
  PRINT ('Info: Database-server-version did not change since last release: ' + ISNULL(@@VERSION, '??'));
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply KiSS database default settings on every release.
           
           Excluded settings:
           - recovery model
           - database owner
           - autogrowth >> depending on current database size and name, see comment in code
           - TODO: what else??
           
           See: /Database/Scripts/Automation/ApplySettingsToDatabases.sql
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 6 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- compatibility level (first)
-------------------------------------------------------------------------------------------------
-- set and validate server version
DECLARE @SQLSERVER2005 INT;
DECLARE @SQLSERVER2008 INT;
DECLARE @SQLSERVER2012 INT;
DECLARE @SQLSERVER2014 INT;

SET @SQLSERVER2005 = 2005;
SET @SQLSERVER2008 = 2008;
SET @SQLSERVER2012 = 2012;
SET @SQLSERVER2014 = 2014;

DECLARE @ServerVersion INT;
DECLARE @NewCompatibilityLevel INT;

SET @ServerVersion = CASE
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2005%' THEN @SQLSERVER2005
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2008%' THEN @SQLSERVER2008
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2012%' THEN @SQLSERVER2012
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2014%' THEN @SQLSERVER2014
                       ELSE NULL
                     END;

SET @NewCompatibilityLevel = CASE @ServerVersion
                               WHEN @SQLSERVER2005 THEN 90
                               WHEN @SQLSERVER2008 THEN 100
                               WHEN @SQLSERVER2012 THEN 110
                               WHEN @SQLSERVER2014 THEN 120
                               ELSE NULL
                             END;

IF (@ServerVersion IS NULL OR @NewCompatibilityLevel IS NULL)
BEGIN
  -- do not continue
  RAISERROR ('Error: Current SQL-Server version is not supported: Version=(''%s'')!', 18, 1, @@Version);
  RETURN;
END;

-- setup vars
DECLARE @DBName NVARCHAR(255);
DECLARE @CompatibilityLevel INT;

SELECT @DBName = DBS.name, 
       @CompatibilityLevel = DBS.compatibility_level
FROM sys.databases DBS
WHERE DBS.name = DB_NAME()
  AND DBS.is_read_only = 0;  -- prevent modifying readonly databases

-- check if need to switch compatibility level
IF (@CompatibilityLevel <> @NewCompatibilityLevel)
BEGIN
  -- info
  PRINT ('Info: Change compatibility level from "' + CONVERT(VARCHAR(5), @CompatibilityLevel) + '" to "' + CONVERT(VARCHAR(5), @NewCompatibilityLevel) + '" on database "' + @DBName + '"');
  
  -- set compatibility
  EXEC dbo.sp_dbcmptlevel @dbname = @DBName, @new_cmptlevel = @NewCompatibilityLevel;
END;
GO

PRINT ('Info: Handled compatibility level for current database');
GO


-------------------------------------------------------------------------------------------------
-- options
-------------------------------------------------------------------------------------------------
DECLARE @SqlStatement NVARCHAR(MAX);
DECLARE @DBName NVARCHAR(255);

SET @DBName = DB_NAME();

SET @SqlStatement = N'
-- automatic
ALTER DATABASE [' + @DBName + N'] SET AUTO_CLOSE OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_CREATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_SHRINK OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS_ASYNC ON;
  
-- cursor
ALTER DATABASE [' + @DBName + N'] SET CURSOR_CLOSE_ON_COMMIT OFF;
ALTER DATABASE [' + @DBName + N'] SET CURSOR_DEFAULT GLOBAL;

-- miscellaneous
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULL_DEFAULT OFF;
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULLS ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_PADDING ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_WARNINGS ON;
ALTER DATABASE [' + @DBName + N'] SET ARITHABORT ON;
ALTER DATABASE [' + @DBName + N'] SET CONCAT_NULL_YIELDS_NULL ON;
ALTER DATABASE [' + @DBName + N'] SET DB_CHAINING OFF;
ALTER DATABASE [' + @DBName + N'] SET NUMERIC_ROUNDABORT OFF;
ALTER DATABASE [' + @DBName + N'] SET PARAMETERIZATION SIMPLE;
ALTER DATABASE [' + @DBName + N'] SET QUOTED_IDENTIFIER OFF;
ALTER DATABASE [' + @DBName + N'] SET RECURSIVE_TRIGGERS OFF;
ALTER DATABASE [' + @DBName + N'] SET TRUSTWORTHY OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_date_correlation_on = 0))
BEGIN
  PRINT (''Info: DATE_CORRELATION_OPTIMIZATION is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;
  END;  
END;

-- recovery
ALTER DATABASE [' + @DBName + N'] SET PAGE_VERIFY CHECKSUM;

-------------------------------------------------------------------------------------------------
-- other advanced options
-------------------------------------------------------------------------------------------------
ALTER DATABASE [' + @DBName + N'] SET ALLOW_SNAPSHOT_ISOLATION OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_read_committed_snapshot_on = 0))
BEGIN
  PRINT (''Info: READ_COMMITTED_SNAPSHOT is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;
  END;  
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases DBS
           WHERE DBS.name = ''' + @DBName + N''' 
             AND DBS.is_broker_enabled = 1))
BEGIN
  -- info
  PRINT (''Info: Disable broker setting on database'');
  
  -- change broker settings
  ALTER DATABASE [' + @DBName + N'] SET DISABLE_BROKER;
END;

PRINT (''Info: Handled common settings for current database'');
';

-- execute it
EXEC (@SqlStatement)
GO

-------------------------------------------------------------------------------------------------
-- db files
-------------------------------------------------------------------------------------------------
-- setup vars
DECLARE @DBName NVARCHAR(255);
SET @DBName = DB_NAME();

DECLARE @SQLLogicalName NVARCHAR(1000);
DECLARE @SQLLogicalName_EXEC NVARCHAR(1000);

DECLARE @SQLDataSize NVARCHAR(1000);
DECLARE @SQLDataSize_EXEC NVARCHAR(1000);

DECLARE @SQLLogSize NVARCHAR(1000);
DECLARE @SQLLogSize_EXEC NVARCHAR(1000);

-- flag if size shall be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
DECLARE @ChangeSizes BIT;
SET @ChangeSizes = 0;

-- sql: change logical name
SET @SQLLogicalName = N'
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<CurrentLogicalName>'', NEWNAME = N''<NewLogicalName>'');
  
  PRINT (''Info: Rename executed'');';

-- sql: change autogrowth of data file (256MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLDataSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 262144KB);
  
  PRINT (''Info: Set data size executed'');
  
  USE [' + @DBName + N'];';

-- sql: change autogrowth of log file (32MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLLogSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 32768KB);
  
  PRINT (''Info: Set log size executed'');
  
  USE [' + @DBName + N'];';

-- get db-size
DECLARE @dbsize BIGINT;
DECLARE @logsize BIGINT;
DECLARE @DBWholeSize INT;

SELECT @dbsize  = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 = 0 THEN size
                                        ELSE 0
                                      END)),
       @logsize = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 <> 0 THEN size
                                        ELSE 0
                                      END))
FROM dbo.sysfiles;

-- get size in MB
SET @DBWholeSize = CONVERT(INT, CONVERT(MONEY, LTRIM(STR((CONVERT (DEC(15, 2), @dbsize) + CONVERT (DEC(15, 2), @logsize)) * 8192 / 1048576, 15, 2))));

-- log
PRINT ('Info: Current db-size is "' + CONVERT(VARCHAR(50), @DBWholeSize) + 'MB"');

-- set if size needs to be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
-- Info: we change size if database size is 200MB...20GB or database customer is PI. 
--       in any other case, the customer's IT is responsible for the autogrowth behaviour on its own.
IF ((@DBWholeSize > 200 AND @DBWholeSize < 20480) OR ((';' + 'BSS;SepDocDB;~ZH;$Standard' + ';') LIKE '%;PI;%'))
BEGIN
  -- do change size
  SET @ChangeSizes = 1;
  PRINT ('Info: Autogrowth behaviour sizes will be changed for current database');
END
ELSE
BEGIN
  PRINT ('Info: No changes to autogrowth behaviour - database does not match size definitions or explicit namespace extensions');
END;

-----------------------------------------------------------------------------
-- loop all database files and set proper logical name of files
-- 
-- apply optionally autogrowth behaviour
-----------------------------------------------------------------------------
-- setup vars
DECLARE @NewLogicalName VARCHAR(255);
DECLARE @CurrentLogicalName VARCHAR(255);
DECLARE @FileType INT;

-- setup cursor
DECLARE curDBFiles CURSOR FAST_FORWARD FOR
  SELECT LogicalName = CASE
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%.mdf' THEN @DBName + '_Primary'
                         WHEN DBF.type = 1 AND DBF.physical_name LIKE '%.ldf' THEN @DBName + '_Log'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten1.ndf'  THEN @DBName + '_Daten1'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten2.ndf'  THEN @DBName + '_Daten2'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten3.ndf'  THEN @DBName + '_Daten3'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%System.ndf'  THEN @DBName + '_System'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%History.ndf'  THEN @DBName + '_History'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Logging.ndf'  THEN @DBName + '_Logging'
                         ELSE CASE
                                WHEN DBF.name LIKE (@DBName + '%') THEN DBF.name                    -- we leave it the way it was (specially for ZH, where we have multiple filegroups: for each year on doc-database)
                                ELSE @DBName + '_Data_' + CONVERT(VARCHAR(10), DBF.data_space_id)   -- we rename it depending on its id
                              END
                       END,
         CurrentName = DBF.name,
         FileType    = DBF.type
  FROM sys.database_files DBF;

-- iterate through cursor
OPEN curDBFiles;
WHILE (1 = 1)
BEGIN
  -- read next row and check if we have one
  FETCH NEXT 
  FROM curDBFiles 
  INTO @NewLogicalName, @CurrentLogicalName, @FileType;
  
  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;
  
  -- check if localname should be changed
  IF (@NewLogicalName <> @CurrentLogicalName)
  BEGIN
    -- info
    PRINT ('Info: Rename logical name from "' + @CurrentLogicalName + '" to "' + @NewLogicalName + '"');
  
    -- setup sql-scripts
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName, '<CurrentLogicalName>', @CurrentLogicalName);
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName_EXEC, '<NewLogicalName>', @NewLogicalName);
    
    -- search in database
    EXEC sp_executesql @SQLLogicalName_EXEC;
  END
  ELSE
  BEGIN
    PRINT ('Info: Logical name is already correct "' + @CurrentLogicalName + '"');
  END;
  
  -- set autogrowth settings
  IF (@FileType = 0 AND @ChangeSizes = 1)
  BEGIN
    -- data file: 256MB unlimited, setup sql-scripts
    SET @SQLDataSize_EXEC = REPLACE(@SQLDataSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set data autogrowth behaviour for "' + @NewLogicalName + '" to "256MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLDataSize_EXEC;
  END
  ELSE IF (@FileType = 1 AND @ChangeSizes = 1)
  BEGIN
    -- log file: 32MB unlimited, setup sql-scripts
    SET @SQLLogSize_EXEC = REPLACE(@SQLLogSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set log autogrowth behaviour for "' + @NewLogicalName + '" to "32MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLLogSize_EXEC;
  END
END; -- [WHILE cursor]

-- clean up cursor
CLOSE curDBFiles;
DEALLOCATE curDBFiles;
GO

PRINT ('Info: Handled file corrections for current database');
GO

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
PRINT ('');
GO 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix default language of server-user "kiss3" and "kiss_bm"
           to "us_english" to prevent language specific errors such as datetime-convert.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- switch to master database
-------------------------------------------------------------------------------
USE [master];
GO

-------------------------------------------------------------------------------
-- try to fix kiss user
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.server_principals WHERE name = N'kiss3'))
BEGIN
  -- fix language
  ALTER LOGIN [kiss3] WITH DEFAULT_LANGUAGE=[us_english];
  
  -- info
  PRINT ('Info: Set default language of server-user "kiss3" to "us_english"');
END
ELSE
BEGIN
  -- info
  PRINT ('Warning: Could not fix default language of server-user "kiss3" to "us_english", user not found!');
END;
GO

-------------------------------------------------------------------------------
-- try to fix kiss_bm user
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.server_principals WHERE name = N'kiss_bm'))
BEGIN
  -- fix language
  ALTER LOGIN [kiss_bm] WITH DEFAULT_LANGUAGE=[us_english];
  
  -- info
  PRINT ('Info: Set default language of server-user "kiss_bm" to "us_english"');
END
ELSE
BEGIN
  -- info
  PRINT ('Warning: Could not fix default language of server-user "kiss_bm" to "us_english", user not found!');
END;
GO

-------------------------------------------------------------------------------
-- switch back to origin database
-------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KBE-1493_Update_XConfig_Int.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KBE-1493_Update_XConfig_Int.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===================================================================================================
  $Revision: 1 $
=====================================================================================================
  Description
-----------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1493 (BackColor of barMainMenu in FrmMain)
=====================================================================================================*/
SET NOCOUNT ON;
GO

IF(N'Int' = N'Int')
BEGIN
EXEC dbo.spAddXConfig @KeyPath = 'System\GUI\MenubalkenRotEinfaerben',
                      @DatumVon = '20180101',
                      @ValueVar = 1,
                      @ValueCode = 5, 
                      @Description = NULL,
                      @OriginalValue = 0,
                      @System = 0
PRINT ('Info: Konfiguration für Menubalken auf Integration rot einfärben wurde angepasst.');
END

GO

SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KBE-1493_Update_XConfig_Int.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_KBE-1493_Update_XConfig_Int.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select optional document database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_DOC_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_DOC_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
-- use document database (name must be given all the time, if no document database exists, use default database)
USE [KiSS4_DOC_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to cleanup empty extended properties (no content in value or '(null)')
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(255);
DECLARE @ColumnName VARCHAR(255);
DECLARE @PropertyName VARCHAR(255);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(255) NOT NULL,
  ColumnName VARCHAR(255),
  PropertyName VARCHAR(255) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ColumnName, PropertyName)
  SELECT TableName     = OBJECT_NAME(EXT.major_id), 
         ColumnName    = COL.name,
         PropertyName  = EXT.name
  FROM sys.extended_properties EXT
    LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id 
                                  AND COL.column_id = EXT.minor_id
  WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
    AND EXT.name <> 'microsoft_database_tools_support'
    AND ISNULL(EXT.value, '') IN ('', '(null)')
  ORDER BY TableName, 
           ColumnName, 
           CASE 
             WHEN EXT.name = 'MS_Description' THEN 0 
             ELSE 1 
           END, 
           PropertyName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName    = TMP.TableName,
         @ColumnName   = TMP.ColumnName,
         @PropertyName = TMP.PropertyName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- drop extended property
  -----------------------------------------------------------------------------
  EXEC dbo.spXExtendedProperty @TableName, @ColumnName, @PropertyName, '_delete_', 0, 1;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix constrainst created WITH NOCHECK to WITH CHECK.
           Reason:
           Constraints defined WITH NOCHECK are not considered by the query optimizer. These 
           constraints are ignored until all such constraints are re-enabled.
           
           See: http://msdn.microsoft.com/en-us/library/aa275462(v=sql.80).aspx
           
           Hint: Use "DBCC CHECKCONSTRAINTS (table_name)" to validate only
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(1000);
DECLARE @ConstraintName VARCHAR(1000);
DECLARE @SQLStatement NVARCHAR(4000);
DECLARE @ErrorMessage VARCHAR(8000);
DECLARE @ErrorCount INT;

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(1000) NOT NULL,
  ConstraintName VARCHAR(1000) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ConstraintName)
  SELECT TableName      = OBJECT_NAME(parent_object_id),
         ConstraintName = name
  FROM sys.foreign_keys
  WHERE is_not_trusted = 1
    AND is_disabled = 0
  ORDER BY TableName, ConstraintName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table
SET @ErrorCount = 0;

-- info
PRINT ('Info: Found "' + CONVERT(VARCHAR(50), @EntriesCount) + '" invalid constraints');

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName      = TMP.TableName,
         @ConstraintName = TMP.ConstraintName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- try to fix constraint
  -----------------------------------------------------------------------------
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to fix constraint here
    SET @SQLStatement = 'ALTER TABLE [dbo].[' + @TableName + '] WITH CHECK CHECK CONSTRAINT [' + @ConstraintName + '];';
    EXECUTE sp_executesql @SQLStatement;
    
    -- save
    COMMIT TRANSACTION;
    
    -- done
    PRINT ('Info: Successfully fixed table "' + @TableName + '" and constraint "' + @ConstraintName + '".');
  END TRY
  BEGIN CATCH
    -- undo
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = 'Warning: Could not fix table "' + @TableName + '" and constraint "' + @ConstraintName + '". Database error was: ' + ISNULL(ERROR_MESSAGE(), '<error?>');
    SET @ErrorCount = @ErrorCount + 1;

    -- show message and continue
    PRINT (@ErrorMessage);
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-- info
PRINT ('Info: Having now "' + CONVERT(VARCHAR(50), @ErrorCount) + '" invalid constraints after fixing');

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply KiSS database default settings on every release.
           
           Excluded settings:
           - recovery model
           - database owner
           - autogrowth >> depending on current database size and name, see comment in code
           - TODO: what else??
           
           See: /Database/Scripts/Automation/ApplySettingsToDatabases.sql
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 6 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- compatibility level (first)
-------------------------------------------------------------------------------------------------
-- set and validate server version
DECLARE @SQLSERVER2005 INT;
DECLARE @SQLSERVER2008 INT;
DECLARE @SQLSERVER2012 INT;
DECLARE @SQLSERVER2014 INT;

SET @SQLSERVER2005 = 2005;
SET @SQLSERVER2008 = 2008;
SET @SQLSERVER2012 = 2012;
SET @SQLSERVER2014 = 2014;

DECLARE @ServerVersion INT;
DECLARE @NewCompatibilityLevel INT;

SET @ServerVersion = CASE
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2005%' THEN @SQLSERVER2005
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2008%' THEN @SQLSERVER2008
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2012%' THEN @SQLSERVER2012
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2014%' THEN @SQLSERVER2014
                       ELSE NULL
                     END;

SET @NewCompatibilityLevel = CASE @ServerVersion
                               WHEN @SQLSERVER2005 THEN 90
                               WHEN @SQLSERVER2008 THEN 100
                               WHEN @SQLSERVER2012 THEN 110
                               WHEN @SQLSERVER2014 THEN 120
                               ELSE NULL
                             END;

IF (@ServerVersion IS NULL OR @NewCompatibilityLevel IS NULL)
BEGIN
  -- do not continue
  RAISERROR ('Error: Current SQL-Server version is not supported: Version=(''%s'')!', 18, 1, @@Version);
  RETURN;
END;

-- setup vars
DECLARE @DBName NVARCHAR(255);
DECLARE @CompatibilityLevel INT;

SELECT @DBName = DBS.name, 
       @CompatibilityLevel = DBS.compatibility_level
FROM sys.databases DBS
WHERE DBS.name = DB_NAME()
  AND DBS.is_read_only = 0;  -- prevent modifying readonly databases

-- check if need to switch compatibility level
IF (@CompatibilityLevel <> @NewCompatibilityLevel)
BEGIN
  -- info
  PRINT ('Info: Change compatibility level from "' + CONVERT(VARCHAR(5), @CompatibilityLevel) + '" to "' + CONVERT(VARCHAR(5), @NewCompatibilityLevel) + '" on database "' + @DBName + '"');
  
  -- set compatibility
  EXEC dbo.sp_dbcmptlevel @dbname = @DBName, @new_cmptlevel = @NewCompatibilityLevel;
END;
GO

PRINT ('Info: Handled compatibility level for current database');
GO


-------------------------------------------------------------------------------------------------
-- options
-------------------------------------------------------------------------------------------------
DECLARE @SqlStatement NVARCHAR(MAX);
DECLARE @DBName NVARCHAR(255);

SET @DBName = DB_NAME();

SET @SqlStatement = N'
-- automatic
ALTER DATABASE [' + @DBName + N'] SET AUTO_CLOSE OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_CREATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_SHRINK OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS_ASYNC ON;
  
-- cursor
ALTER DATABASE [' + @DBName + N'] SET CURSOR_CLOSE_ON_COMMIT OFF;
ALTER DATABASE [' + @DBName + N'] SET CURSOR_DEFAULT GLOBAL;

-- miscellaneous
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULL_DEFAULT OFF;
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULLS ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_PADDING ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_WARNINGS ON;
ALTER DATABASE [' + @DBName + N'] SET ARITHABORT ON;
ALTER DATABASE [' + @DBName + N'] SET CONCAT_NULL_YIELDS_NULL ON;
ALTER DATABASE [' + @DBName + N'] SET DB_CHAINING OFF;
ALTER DATABASE [' + @DBName + N'] SET NUMERIC_ROUNDABORT OFF;
ALTER DATABASE [' + @DBName + N'] SET PARAMETERIZATION SIMPLE;
ALTER DATABASE [' + @DBName + N'] SET QUOTED_IDENTIFIER OFF;
ALTER DATABASE [' + @DBName + N'] SET RECURSIVE_TRIGGERS OFF;
ALTER DATABASE [' + @DBName + N'] SET TRUSTWORTHY OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_date_correlation_on = 0))
BEGIN
  PRINT (''Info: DATE_CORRELATION_OPTIMIZATION is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;
  END;  
END;

-- recovery
ALTER DATABASE [' + @DBName + N'] SET PAGE_VERIFY CHECKSUM;

-------------------------------------------------------------------------------------------------
-- other advanced options
-------------------------------------------------------------------------------------------------
ALTER DATABASE [' + @DBName + N'] SET ALLOW_SNAPSHOT_ISOLATION OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_read_committed_snapshot_on = 0))
BEGIN
  PRINT (''Info: READ_COMMITTED_SNAPSHOT is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;
  END;  
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases DBS
           WHERE DBS.name = ''' + @DBName + N''' 
             AND DBS.is_broker_enabled = 1))
BEGIN
  -- info
  PRINT (''Info: Disable broker setting on database'');
  
  -- change broker settings
  ALTER DATABASE [' + @DBName + N'] SET DISABLE_BROKER;
END;

PRINT (''Info: Handled common settings for current database'');
';

-- execute it
EXEC (@SqlStatement)
GO

-------------------------------------------------------------------------------------------------
-- db files
-------------------------------------------------------------------------------------------------
-- setup vars
DECLARE @DBName NVARCHAR(255);
SET @DBName = DB_NAME();

DECLARE @SQLLogicalName NVARCHAR(1000);
DECLARE @SQLLogicalName_EXEC NVARCHAR(1000);

DECLARE @SQLDataSize NVARCHAR(1000);
DECLARE @SQLDataSize_EXEC NVARCHAR(1000);

DECLARE @SQLLogSize NVARCHAR(1000);
DECLARE @SQLLogSize_EXEC NVARCHAR(1000);

-- flag if size shall be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
DECLARE @ChangeSizes BIT;
SET @ChangeSizes = 0;

-- sql: change logical name
SET @SQLLogicalName = N'
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<CurrentLogicalName>'', NEWNAME = N''<NewLogicalName>'');
  
  PRINT (''Info: Rename executed'');';

-- sql: change autogrowth of data file (256MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLDataSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 262144KB);
  
  PRINT (''Info: Set data size executed'');
  
  USE [' + @DBName + N'];';

-- sql: change autogrowth of log file (32MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLLogSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 32768KB);
  
  PRINT (''Info: Set log size executed'');
  
  USE [' + @DBName + N'];';

-- get db-size
DECLARE @dbsize BIGINT;
DECLARE @logsize BIGINT;
DECLARE @DBWholeSize INT;

SELECT @dbsize  = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 = 0 THEN size
                                        ELSE 0
                                      END)),
       @logsize = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 <> 0 THEN size
                                        ELSE 0
                                      END))
FROM dbo.sysfiles;

-- get size in MB
SET @DBWholeSize = CONVERT(INT, CONVERT(MONEY, LTRIM(STR((CONVERT (DEC(15, 2), @dbsize) + CONVERT (DEC(15, 2), @logsize)) * 8192 / 1048576, 15, 2))));

-- log
PRINT ('Info: Current db-size is "' + CONVERT(VARCHAR(50), @DBWholeSize) + 'MB"');

-- set if size needs to be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
-- Info: we change size if database size is 200MB...20GB or database customer is PI. 
--       in any other case, the customer's IT is responsible for the autogrowth behaviour on its own.
IF ((@DBWholeSize > 200 AND @DBWholeSize < 20480) OR ((';' + 'BSS;SepDocDB;~ZH;$Standard' + ';') LIKE '%;PI;%'))
BEGIN
  -- do change size
  SET @ChangeSizes = 1;
  PRINT ('Info: Autogrowth behaviour sizes will be changed for current database');
END
ELSE
BEGIN
  PRINT ('Info: No changes to autogrowth behaviour - database does not match size definitions or explicit namespace extensions');
END;

-----------------------------------------------------------------------------
-- loop all database files and set proper logical name of files
-- 
-- apply optionally autogrowth behaviour
-----------------------------------------------------------------------------
-- setup vars
DECLARE @NewLogicalName VARCHAR(255);
DECLARE @CurrentLogicalName VARCHAR(255);
DECLARE @FileType INT;

-- setup cursor
DECLARE curDBFiles CURSOR FAST_FORWARD FOR
  SELECT LogicalName = CASE
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%.mdf' THEN @DBName + '_Primary'
                         WHEN DBF.type = 1 AND DBF.physical_name LIKE '%.ldf' THEN @DBName + '_Log'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten1.ndf'  THEN @DBName + '_Daten1'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten2.ndf'  THEN @DBName + '_Daten2'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten3.ndf'  THEN @DBName + '_Daten3'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%System.ndf'  THEN @DBName + '_System'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%History.ndf'  THEN @DBName + '_History'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Logging.ndf'  THEN @DBName + '_Logging'
                         ELSE CASE
                                WHEN DBF.name LIKE (@DBName + '%') THEN DBF.name                    -- we leave it the way it was (specially for ZH, where we have multiple filegroups: for each year on doc-database)
                                ELSE @DBName + '_Data_' + CONVERT(VARCHAR(10), DBF.data_space_id)   -- we rename it depending on its id
                              END
                       END,
         CurrentName = DBF.name,
         FileType    = DBF.type
  FROM sys.database_files DBF;

-- iterate through cursor
OPEN curDBFiles;
WHILE (1 = 1)
BEGIN
  -- read next row and check if we have one
  FETCH NEXT 
  FROM curDBFiles 
  INTO @NewLogicalName, @CurrentLogicalName, @FileType;
  
  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;
  
  -- check if localname should be changed
  IF (@NewLogicalName <> @CurrentLogicalName)
  BEGIN
    -- info
    PRINT ('Info: Rename logical name from "' + @CurrentLogicalName + '" to "' + @NewLogicalName + '"');
  
    -- setup sql-scripts
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName, '<CurrentLogicalName>', @CurrentLogicalName);
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName_EXEC, '<NewLogicalName>', @NewLogicalName);
    
    -- search in database
    EXEC sp_executesql @SQLLogicalName_EXEC;
  END
  ELSE
  BEGIN
    PRINT ('Info: Logical name is already correct "' + @CurrentLogicalName + '"');
  END;
  
  -- set autogrowth settings
  IF (@FileType = 0 AND @ChangeSizes = 1)
  BEGIN
    -- data file: 256MB unlimited, setup sql-scripts
    SET @SQLDataSize_EXEC = REPLACE(@SQLDataSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set data autogrowth behaviour for "' + @NewLogicalName + '" to "256MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLDataSize_EXEC;
  END
  ELSE IF (@FileType = 1 AND @ChangeSizes = 1)
  BEGIN
    -- log file: 32MB unlimited, setup sql-scripts
    SET @SQLLogSize_EXEC = REPLACE(@SQLLogSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set log autogrowth behaviour for "' + @NewLogicalName + '" to "32MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLLogSize_EXEC;
  END
END; -- [WHILE cursor]

-- clean up cursor
CLOSE curDBFiles;
DEALLOCATE curDBFiles;
GO

PRINT ('Info: Handled file corrections for current database');
GO

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
PRINT ('');
GO 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
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
  SET @DocDBName = 'KiSS4_DOC_I';
  
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

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS4_I') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS4_I'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS4_I];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\42\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql' -------- */


/*
************************************************************
  PROCESSED 158 FILES IN 00:00:12.5740571
************************************************************
*/
PRINT ('
************************************************************
');
PRINT ('  Info: End of script: [' + CONVERT(VARCHAR, GETDATE(), 113) + ']');
PRINT ('
************************************************************
');
