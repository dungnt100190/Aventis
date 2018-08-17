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