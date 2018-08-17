SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spABAInsertBulkVisum;
GO

-------------------------------------------------------------------------------
-- setup required properties
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to insert 0h data into BDELeistung for users with Stundenlohn
           and no data, to prevent inserting more data into an exported month
    @UserLogonName:  The id of the user who calls the sp
    @Kostenstelle:   The Mandantennummer where the user is member
    @DatumVon:       Starting date to check if entries exists for user
    @DatumBis:       Ending date to check if entries exists for user
  -
  RETURNS: One column-resultset with columnname = [Done] where > -1 = ok, < 0 = nok
=================================================================================================
  TEST:    EXEC spABAInsertBulkVisum 'cjaeggi', 100, '2008-01-01', '2008-01-31'
=================================================================================================*/

CREATE PROCEDURE dbo.spABAInsertBulkVisum
(
  @UserLogonName varchar(200),
  @MandantenNr INT,
  @DatumVon datetime,
  @DatumBis datetime
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- Validate
  -------------------------------------------------------------------------------
  IF (@UserLogonName IS NULL OR @MandantenNr IS NULL OR @DatumVon IS NULL OR @DatumBis IS NULL)
  BEGIN
    -- invalid values
    SELECT [Done] = -1;
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- Vars
  -------------------------------------------------------------------------------
  DECLARE @AffectedRows INT;
  
  -------------------------------------------------------------------------------
  -- A temporary table for collecting users
  -------------------------------------------------------------------------------
  DECLARE @Users TABLE
  (
    UserID INT NOT NULL,
    LastName VARCHAR(200),
    FirstName VARCHAR(200),
    OrgUnitID INT NOT NULL,
    KeinBDEExport BIT NOT NULL
  );
  
  -------------------------------------------------------------------------------
  -- Insert users who are allowed to insert data into temp table
  --   all users within the given MandantenNr for the startdate/enddate
  --   INFO: we only use start- and enddate, for real history, 
  --         we should insert for each day within given range
  -------------------------------------------------------------------------------
  -- start date
  INSERT INTO @Users
    SELECT DISTINCT
           USR.UserID,
           USR.LastName,
           USR.FirstName,
           OrgUnitID = dbo.fnOrgUnitOfUserHistoryPerDate(USR.UserID, @DatumVon),
           KeinBDEExport = CONVERT(BIT, ISNULL(dbo.fnXGetHistUserValue('KeinBDEExport', USR.UserID, GetDate()), 0))
    FROM dbo.XUser USR WITH (READUNCOMMITTED)
    WHERE dbo.fnBDEGetHistMandantenNrPerDate(USR.UserID, @DatumVon, NULL) = @MandantenNr AND -- filter MandatenNr
          USR.UserID NOT IN (SELECT LEI.UserID
                             FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                             WHERE LEI.Datum BETWEEN @DatumVon AND @DatumBis); -- only those with no data in BDELeistung for period
  
  -- end date (in most cases, this would do nothing as the mandantennr will not change)
  INSERT INTO @Users
    SELECT DISTINCT
           USR.UserID,
           USR.LastName,
           USR.FirstName,
           OrgUnitID = dbo.fnOrgUnitOfUserHistoryPerDate(USR.UserID, @DatumBis),
           KeinBDEExport = CONVERT(BIT, ISNULL(dbo.fnXGetHistUserValue('KeinBDEExport', USR.UserID, GetDate()), 0))
    FROM dbo.XUser USR WITH (READUNCOMMITTED)
    WHERE dbo.fnBDEGetHistMandantenNrPerDate(USR.UserID, @DatumBis, NULL) = @MandantenNr AND -- filter MandatenNr
          USR.UserID NOT IN (SELECT UserID 
                             FROM @Users) AND                                 -- those who are not yet in table
          USR.UserID NOT IN (SELECT LEI.UserID
                             FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                             WHERE LEI.Datum BETWEEN @DatumVon AND @DatumBis); -- only those with no data in BDELeistung for period
  
  -------------------------------------------------------------------------------
  -- New history version (!)
  -------------------------------------------------------------------------------
  INSERT INTO HistoryVersion (AppUser) VALUES (@UserLogonName);
  
  -------------------------------------------------------------------------------
  -- Insert bulk visum for defined person at the end of the period
  -------------------------------------------------------------------------------
  INSERT INTO dbo.BDELeistung (UserID, BDELeistungsartID, KostenstelleOrgUnitID, Datum, Dauer, KeinExport,
                               Freigegeben, Visiert, Verbucht, HistKostenart, HistKostenstelle, HistKostentraeger, HistMandantNr)
    SELECT DISTINCT 
           UserID                = USR.UserID,
           BDELeistungsartID     = 1,   -- static entry from BDELeistungsart ("System: Automatisches Visum")
           KostenstelleOrgUnitID = USR.OrgUnitID,
           Datum                 = @DatumBis,
           Dauer                 = 0.0,  -- entry with no time
           KeinExport            = USR.KeinBDEExport,
           Freigegeben           = 1,
           Visiert               = 1,
           Verbucht              = NULL, -- not yet Verbucht, due to check function: fnBDEGetNextExportMonth()
           HistKostenart         = dbo.fnBDEGetHistKostenartPerDate(USR.UserID, 1, @DatumBis),
           HistKostenstelle      = ISNULL(dbo.fnBDEGetHistKostenstellePerDate(NULL, @DatumBis, USR.OrgUnitID), dbo.fnBDEGetHistKostenstellePerDate(USR.UserID, @DatumBis, NULL)),
           HistKostentraeger     = (SELECT TOP 1 Kostentraeger
                                    FROM dbo.fnBDEGetHistKostentraegerPerDate(USR.UserID, 1, @DatumBis)),
           HistMandantNr         = dbo.fnBDEGetHistMandantenNrPerDate(USR.UserID, @DatumBis, USR.OrgUnitID)
    FROM @Users USR;
  
  -- count rows we inserted
  SET @AffectedRows = @@ROWCOUNT;
  
  -------------------------------------------------------------------------------
  -- Done, return inserted rows (ok: >= 0)
  -------------------------------------------------------------------------------
  SELECT [Done] = ISNULL(@AffectedRows, -1);
END;
GO