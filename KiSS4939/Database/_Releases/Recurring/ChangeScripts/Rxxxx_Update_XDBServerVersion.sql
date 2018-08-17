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
