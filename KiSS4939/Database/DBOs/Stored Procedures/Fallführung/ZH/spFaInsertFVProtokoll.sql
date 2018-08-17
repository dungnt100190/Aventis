SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaInsertFVProtokoll
GO
/*===============================================================================================
  $Revision: 4$
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

-------------------------------------------------------------------------------
-- CALL:    Use this sp create a new entry into FaJournal (Fallverlaufsprotokoll)
--   FaFallID:       The FallID to use 
--                   (if NULL, 1. trying to get it with FaLeistungID, 2. trying to get it with BaPersonID)
--   FaLeistungID:   The LeistungID to use
--   BaPersonID:     The ID of the person of the fall 
--                   (if NULL, 1. trying to get it with FaLeistungID, 2. trying to get it with FaFallID)
--                   !! if a BaPersonID does not have any entries in FaFall, the entry will not be written, without showing any error
--   UserID:         The ID of the user (required)
--   FaJournalCode:  The code for the journal entry (default is 1)
--   Text:           The text to use for the journal entry
-- RETURNS: The id of the inserted entry (FaJournalID) or -1 if invalid/error

-- TEST:    EXEC [spFaInsertFVProtokoll] 51152, NULL, NULL, 7140, 1, '--- test only ---'
-- TEST:    EXEC [spFaInsertFVProtokoll] NULL, NULL, 100315, 7140, 1, '--- test only ---'
-- TEST:    EXEC [spFaInsertFVProtokoll] NULL, NULL, 181254, 7140, 1, '--- test only ---'
/*
   SELECT TOP 10 *
   FROM FaJournal
   ORDER BY FaJournalID DESC
*/
-------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[spFaInsertFVProtokoll]
(
 @FaFallID INT,
 @FaLeistungID INT,
 @BaPersonID INT,
 @UserID INT,
 @FaJournalCode INT = 1,
 @Text TEXT
)
AS
  -------------------------------------------------------------------------------
  -- validate FaFallID
  -------------------------------------------------------------------------------
  -- if NULL, 1. trying to get it with FaLeistungID
  IF (@FaFallID IS NULL AND @FaLeistungID IS NOT NULL)
  BEGIN
    -- request FaFallID from FaLeistung
    SELECT @FaFallID = LEI.FaFallID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.FaLeistungID = @FaLeistungID
  END

  -- if NULL, 2. trying to get it with BaPersonID
  IF (@FaFallID IS NULL AND @BaPersonID IS NOT NULL)
  BEGIN
    -- request FaFallID from FaFall
    SELECT TOP 1 @FaFallID = FAL.FaFallID
    FROM dbo.FaFall FAL WITH (READUNCOMMITTED)
    WHERE FAL.BaPersonID = @BaPersonID
    ORDER BY FAL.DatumBis, FAL.DatumVon DESC
  END

  -------------------------------------------------------------------------------
  -- validate BaPersonID
  -------------------------------------------------------------------------------
  -- if NULL, 1. trying to get it with FaLeistungID
  IF (@BaPersonID IS NULL AND @FaLeistungID IS NOT NULL)
  BEGIN
    -- request BaPersonID from FaLeistung
    SELECT @BaPersonID = LEI.BaPersonID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.FaLeistungID = @FaLeistungID
  END

  -- if NULL, 2. trying to get it with FaFallID
  IF (@BaPersonID IS NULL AND @FaFallID IS NOT NULL)
  BEGIN
    -- request BaPersonID from FaFall
    SELECT @BaPersonID = FAL.BaPersonID
    FROM dbo.FaFall FAL WITH (READUNCOMMITTED)
    WHERE FAL.FaFallID = @FaFallID
  END

  -------------------------------------------------------------------------------
  -- check if BaPersonID has any entry in FaFall, if not, do not continue - silently
  -------------------------------------------------------------------------------
  IF (@BaPersonID IS NOT NULL AND @FaFallID IS NULL AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.FaFall WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID))
  BEGIN
    -- this is an entry for a BaPersonID without any entry in FaFall, so do not continue
    SELECT FaJournalID = -1
    RETURN -1
  END

  -------------------------------------------------------------------------------
  -- check required fields
  -------------------------------------------------------------------------------
  IF (@FaFallID IS NULL OR @UserID IS NULL OR @FaJournalCode IS NULL OR @Text IS NULL)
  BEGIN
    -- exception
    RAISERROR ('Error: Not all required values are given, cannot insert data into FaJournal!', 16, 1)
    SELECT FaJournalID = -1
    RETURN -1
  END

  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @BaPersonName VARCHAR(100)
  DECLARE @BaPersonVorname VARCHAR(100)
  DECLARE @UserLastName VARCHAR(200)
  DECLARE @UserFirstName VARCHAR(200)
  DECLARE @UserLogonName VARCHAR(200)
  DECLARE @OrgUnitID INT
  DECLARE @OrgUnitItemName VARCHAR(100)
  
  -------------------------------------------------------------------------------
  -- get values from ids
  -------------------------------------------------------------------------------
  -- person
  SELECT @BaPersonName = PRS.Name,
         @BaPersonVorname = PRS.Vorname
  FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
  WHERE PRS.BaPersonID = @BaPersonID

  -- user
  SELECT @UserLastName = USR.LastName,
         @UserFirstName = USR.FirstName,
         @UserLogonName = USR.LogonName
  FROM dbo.XUser USR WITH (READUNCOMMITTED)
  WHERE USR.UserID = @UserID

  -- orgunit
  SELECT @OrgUnitID = ORG.OrgUnitID,
         @OrgUnitItemName = ORG.ItemName
  FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
    INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
  WHERE OUU.UserID = @UserID AND OUU.OrgUnitMemberCode = 2 -- member only

  -------------------------------------------------------------------------------
  -- insert data
  -------------------------------------------------------------------------------
  INSERT INTO FaJournal (FaFallID, FaLeistungID, BaPersonID, BaPersonName, BaPersonVorname, UserID,
                         UserLastName, UserFirstName, UserLogonName, OrgUnitID, OrgUnitItemName,
                         Datum, FaJournalCode, Text, ManuellerEintrag)
  VALUES (@FaFallID, @FaLeistungID, @BaPersonID, @BaPersonName, @BaPersonVorname, @UserID,
          @UserLastName, @UserFirstName, @UserLogonName, @OrgUnitID, @OrgUnitItemName,
          GETDATE(), @FaJournalCode, @Text, 0)
  
  -------------------------------------------------------------------------------
  -- get id of inserted entry
  -------------------------------------------------------------------------------
  SELECT [FaJournalID] = ISNULL(SCOPE_IDENTITY(), -1)


