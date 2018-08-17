/*===============================================================================================
  $Archive: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/NewDBServerScripts/DBVersionInformationOutput.sql $
  $Author: Cjaeggi $
  $Modtime: 26.08.10 10:35 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to print database version information
=================================================================================================
  $Log: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/NewDBServerScripts/DBVersionInformationOutput.sql $
 * 
 * 1     26.08.10 10:36 Cjaeggi
 * Added further database information
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- get version info
-------------------------------------------------------------------------------
-- init vars
DECLARE @Version VARCHAR(20);
DECLARE @VersionDate DATETIME;
DECLARE @BackwardTo VARCHAR(20);

-- get data
SELECT @Version     = CONVERT(VARCHAR(10), MajorVersion) + '.' + 
                      CONVERT(VARCHAR(10), MinorVersion) + '.' + 
                      CONVERT(VARCHAR(10), Build) + '.' + 
                      CONVERT(VARCHAR(10), Revision),
       @VersionDate = VersionDate,
       @BackwardTo  = BackwardCompatibleDownToClientVersion
FROM dbo.XDBVersion
WHERE XDBVersionID = dbo.fnXDBVersionGetCurrentDBVersionID()

PRINT ('');
PRINT ('---- DATABASE VERSION ----');
PRINT ('Info: Database-Version = "' + ISNULL(@Version, '??') + '", Date = "' + ISNULL(CONVERT(VARCHAR, @VersionDate, 104), '??') + '", BackwardCompatibleTo = "' + ISNULL(@BackwardTo, '??') + '"');
PRINT ('');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
