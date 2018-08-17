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
-- next release
SET @Major = 4;
SET @Minor = 5;
SET @Build = 44;
SET @Revision = 0;

-- backwards compatible
SET @BackwardCompatible = '4.5.32.0';

-- description (release info: season and year)
SET @VersionDescription = 'Winter 2013';

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