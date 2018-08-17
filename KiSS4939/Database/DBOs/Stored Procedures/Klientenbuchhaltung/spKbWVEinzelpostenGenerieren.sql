SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbWVEinzelpostenGenerieren
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKbWVEinzelpostenGenerieren.sql $
  $Author: Ckaeser $
  $Modtime: 12.08.09 14:25 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to create and handle and fill WV-Einzelposten
    @UserID:                       User who runs the stored procecure
    @KbPeriodeID:                  The current active PeriodeID to use
    @Testlauf:                     1 (default) = the data will be used only for testing,
                                   0 = the data is used for real processing
    @DatumBisWVLauf:               Date for the limit of Verwendungsperiode to handle
    
    @Out_KbWVLaufID:               Return the new KbWVLaufID to caller of stored procedure
    @Out_CountNewKbWVEinzelposten: Return the amount of new created items in KbWVEinzelposten
  -
  RETURNS: Entry within KbWVLauf, where any output means: everything is ok.
           Otherwise, an error has occured!
  -
  EXCEPTIONS: Stored procedure raises an error in case of bad error!
  -
  TEST:    wrong entries (expect error):
           EXEC spKbWVEinzelpostenGenerieren NULL, 1, 1, '2008-06-30'
           EXEC spKbWVEinzelpostenGenerieren -1, NULL, NULL, NULL
           
           good entries:
           EXEC spKbWVEinzelpostenGenerieren 2009, 30, 1, '2008-08-22'
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKbWVEinzelpostenGenerieren.sql $
 * 
 * 6     12.08.09 14:27 Ckaeser
 * #4932 Alter2Create Bereinigung DBO's
 * 
 * 5     3.08.09 10:45 Nweber
 * #4932: Functions and Stored Procedures merged
 * 
 * 3     6.04.09 14:56 Cjaeggi
 * Changed transactionhandling, order of try and begin transaction
 * 
 * 2     1.10.08 12:44 Cjaeggi
 * Revised, commenting, case fix
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKbWVEinzelpostenGenerieren]
(
  @UserID INT,
  @KbPeriodeID INT,
  @Testlauf BIT = 1,
  @DatumBisWVLauf datetime,
  @Out_KbWVLaufID INT OUTPUT,
  @Out_CountNewKbWVEinzelposten INT OUTPUT
)
AS
  -- ============================================================================
  -- INIT
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- don't count events, it's not required!
  -------------------------------------------------------------------------------
  SET NOCOUNT ON

  -------------------------------------------------------------------------------
  -- Vars
  -------------------------------------------------------------------------------
  -- declare vars
  DECLARE @KbWVEinzelpostenStatus_TestLauf INT
  DECLARE @KbWVEinzelpostenStatus_Vorbereitet INT
  DECLARE @KbWVEinzelpostenStatus_Storniert INT
  DECLARE @KbBuchungStatusCode_storniert INT
  DECLARE @BaWVCodeStatusCode_verfallen INT

  DECLARE @ErrorMessage varchar(MAX)
  DECLARE @KbWVLaufID INT
  DECLARE @KbWVEinzelpostenStatusCode INT

  DECLARE @NewStorno_KbWVEinzelpostenID INT
  DECLARE @NewKbWVEinzelpostenID INT

  -- set output vars to invalid (later on to valid again, if everything is ok)
  SET @Out_KbWVLaufID = -1
  SET @Out_CountNewKbWVEinzelposten = -1

  -- set static vars
  SET @KbWVEinzelpostenStatus_Vorbereitet = 2     -- from LOV 'KbWVEinzelpostenStatus', where Code=2 and Text='Vorbereitet' (default for real run)
  SET @KbWVEinzelpostenStatus_Storniert = 7       -- from LOV 'KbWVEinzelpostenStatus', where Code=7 and Text='Storniert'
  SET @KbWVEinzelpostenStatus_TestLauf = 100      -- from LOV 'KbWVEinzelpostenStatus', where Code=100 and Text='Testlauf' (default for test run)
  SET @KbBuchungStatusCode_storniert = 8          -- from LOV 'KbBuchungStatus', where Code=8 and Text='storniert'
  SET @BaWVCodeStatusCode_verfallen = 2           -- from LOV 'BaWVStatus', where Code=2 and Text='verfallen'

  -------------------------------------------------------------------------------
  -- Validate parameters
  -------------------------------------------------------------------------------
  IF (IsNull(@UserID, -1) < 1 OR IsNull(@KbPeriodeID, -1) < 1 OR @DatumBisWVLauf IS NULL)
  BEGIN
    -- invalid value, set error part
    SET @ErrorMessage = CONVERT(varchar, @DatumBisWVLauf, 104)

    -- do not continue
    RAISERROR ('Error: Invalid UserID (''%d'') and/or KbPeriodeID (''%d'') and/or DatumBis (''%s'') parameter, cannot continue!', 18, 1, @UserID, @KbPeriodeID, @ErrorMessage)
    RETURN
  END

  -- setup flags
  SET @Testlauf = IsNull(@Testlauf, 1) -- by default, only testing

  -- default value for statuscode
  IF (@Testlauf = 1)
  BEGIN
    -- running in test mode
    SET @KbWVEinzelpostenStatusCode = @KbWVEinzelpostenStatus_TestLauf   -- 'Testlauf'
  END
  ELSE
  BEGIN
    -- running in real mode
    SET @KbWVEinzelpostenStatusCode = @KbWVEinzelpostenStatus_Vorbereitet  -- 'Vorbereitet'
  END

  -------------------------------------------------------------------------------
  -- Create new entry within KbWVLauf
  -------------------------------------------------------------------------------
  -- create entry
  INSERT INTO dbo.KbWVLauf (UserID, KbPeriodeID, DatumBisWVLauf, Testlauf)
  VALUES (@UserID, @KbPeriodeID, @DatumBisWVLauf, @Testlauf)

  -- get new inserted id
  SET @KbWVLaufID = IsNull(SCOPE_IDENTITY(), -1)

  -- validate identity
  IF (IsNull(@KbWVLaufID, -1) < 1)
  BEGIN
    -- invalid @KbWVLaufID, do not continue
    RAISERROR ('Error: Invalid identity value for new entry in dbo.KbWVLauf (''%d''), cannot continue!', 18, 1, @KbWVLaufID)
    RETURN
  END
  -- ============================================================================




  -- ============================================================================
  -- DATA CORRECTIONS (REVERSAL)
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- We do reversal on entries within KbWVEinzelposten depending on status of
  --   corresponding data for each current entry. As one entry can only be
  --   reversed once, we can combine the result and do reversal only once.
  -------------------------------------------------------------------------------
  -- Reversal: BaWVCode
  -------------------------------------------------------------------------------
  -- do reversal on KbWVEinzelposten where corresponding entry within BaWVCode
  --   has gone invalid (BaWVCode.StatusCode = 2 'Verfallen')
  -- 
  -- info: any further changes in BaWVCode are not allowed and therefore
  --       not handled
  -------------------------------------------------------------------------------
  -- Reversal: KbBuchung
  -------------------------------------------------------------------------------
  -- do reversal on KbWVEinzelposten where corresponding entry within KbBuchung
  --   has reversal-flag (KbBuchungStatusCode = 8 ('storniert'))
  -- 
  -- info: any further changes in KbBuchung are not allowed and therefore
  --       not handled
  -------------------------------------------------------------------------------
    -- init new transaction
    BEGIN TRANSACTION

  -- start try catch block
  BEGIN TRY
    -----------------------------------------------------------------------------
    -- create temporary tables for collecting data and later processing
    -----------------------------------------------------------------------------
    -- init temporary table for entries that have to reversed
    DECLARE @Storno_KbWVEinzelposten TABLE
    (
      ID$ INT identity(1, 1) NOT NULL PRIMARY KEY,
      KbWVEinzelpostenID INT NOT NULL
    )

    -----------------------------------------------------------------------------
    -- get all ids to do reversal
    --
    -- hint: only those who are non-testing entries!
    -----------------------------------------------------------------------------
    INSERT INTO @Storno_KbWVEinzelposten
      -- get all as 'invalid' marked entries within WhWVEinheit 
      SELECT WEP.KbWVEinzelpostenID
      FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                              WVL.Testlauf = 0                                                  -- only non-testing entries

        INNER JOIN dbo.BaWVCode BWC WITH (READUNCOMMITTED) ON BWC.BaWVCodeID = WEP.BaWVCodeID AND
                                                              IsNull(BWC.StatusCode, -1) = @BaWVCodeStatusCode_verfallen        -- only those who are marked as invalid by now

      WHERE WEP.StorniertKbWVEinzelpostenID IS NULL AND                            -- only those who are non-reversed-entries
            WEP.Ungueltig = 0 AND                                                  -- only those who are not marked as invalid (already processed as reversed)
            WEP.KbWVEinzelpostenStatusCode <> @KbWVEinzelpostenStatus_TestLauf     -- only non-testing entries

      -- add more entries
      UNION ALL

      -- get all reversal entries within KbBuchung
      SELECT WEP.KbWVEinzelpostenID
      FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                             WVL.Testlauf = 0                                                             -- only non-testing entries

        INNER JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungKostenartID = WEP.KbBuchungKostenartID
        INNER JOIN dbo.KbBuchung BUC          WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KOA.KbBuchungID AND
                                                                        BUC.KbBuchungStatusCode = @KbBuchungStatusCode_storniert AND      -- only those who are marked as reversed
                                                                        BUC.StorniertKbBuchungID IS NULL                                  -- only those who are non-reversed entries (that means, the original, non-reversal ones)

      WHERE WEP.StorniertKbWVEinzelpostenID IS NULL AND                                                   -- only those who are non-reversed-entries
            WEP.Ungueltig = 0 AND                                                                         -- only those who are not marked as invalid (already processed as reversed)
            WEP.KbWVEinzelpostenStatusCode <> @KbWVEinzelpostenStatus_TestLauf                            -- only non-testing entries

    -----------------------------------------------------------------------------
    -- update current entries and mark them as invalid
    --
    -- hint: if current run is 'Testlauf', we do not update these entries!
    -----------------------------------------------------------------------------
    IF (@Testlauf = 0)
    BEGIN
      UPDATE WEP
      SET WEP.Ungueltig = 1
      FROM dbo.KbWVEinzelposten WEP
      WHERE WEP.KbWVEinzelpostenID IN (SELECT DISTINCT TMP.KbWVEinzelpostenID
                                       FROM @Storno_KbWVEinzelposten TMP)
    END

    -----------------------------------------------------------------------------
    -- insert reversal entries into KbWVEinzelposten
    -----------------------------------------------------------------------------
    INSERT INTO dbo.KbWVEinzelposten (StorniertKbWVEinzelpostenID, KbWVLaufID, BaPersonID, BaWVCodeID, BaWVCode,
                                      KbBuchungKostenartID, KbKostenstelleID, BgKostenartID, BgSplittingArtCode, Betrag,
                                      DatumVon, DatumBis, SplittingDurchWVLaufDatumBis, KbWVEinzelpostenStatusCode, Fakturiert,
                                      Buchungstext, HeimatkantonNr, WohnKantonNr, KantonKuerzel, Auslandschweizer)
      SELECT StorniertKbWVEinzelpostenID      = WEP.KbWVEinzelpostenID,
             KbWVLaufID                       = @KbWVLaufID,                       -- current WV-Lauf number
             BaPersonID                       = WEP.BaPersonID,
             BaWVCodeID                       = WEP.BaWVCodeID,
             BaWVCode                         = WEP.BaWVCode,
             KbBuchungKostenartID             = WEP.KbBuchungKostenartID,
             KbKostenstelleID                 = WEP.KbKostenstelleID,
             BgKostenartID                    = WEP.BgKostenartID,
             BgSplittingArtCode               = WEP.BgSplittingArtCode,
             Betrag                           = -WEP.Betrag,                       -- flip sign because it's a reversal entry based on KbWVEinzelposten-entry!
             DatumVon                         = WEP.DatumVon,
             DatumBis                         = WEP.DatumBis,
             SplittingDurchWVLaufDatumBis     = WEP.SplittingDurchWVLaufDatumBis,
             KbWVEinzelpostenStatusCode       = @KbWVEinzelpostenStatusCode,       -- current status
             Fakturiert                       = 0,                                 -- item is not yet printed, set flag=0!
             Buchungstext                     = WEP.Buchungstext,
             HeimatkantonNr                   = WEP.HeimatkantonNr,
             WohnKantonNr                     = WEP.WohnKantonNr,
             KantonKuerzel                    = WEP.KantonKuerzel,
             Auslandschweizer                 = WEP.Auslandschweizer

      FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
      WHERE WEP.KbWVEinzelpostenID IN (SELECT DISTINCT TMP.KbWVEinzelpostenID
                                       FROM @Storno_KbWVEinzelposten TMP)

    -----------------------------------------------------------------------------
    -- everything ok, commit changes now
    -----------------------------------------------------------------------------
    COMMIT TRANSACTION
  END TRY

  BEGIN CATCH
    -- error occured, do undo reversal
    ROLLBACK TRANSACTION

    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()

    -- do not continue
    RAISERROR ('Error: Could not process reversal on table dbo.KbWVEinzelposten. Database error was: %s.', 18, 1, @ErrorMessage)
    RETURN
  END CATCH
  -- ============================================================================




  -- ============================================================================
  -- CREATE NEW DATA (INSERTS ON KbWVEinzelposten)
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- INIT:
  -- create temporary tables for collecting data and later processing
  -------------------------------------------------------------------------------
  -- collect possible WV-entries within KbBuchungKostenart
  DECLARE @KbBuchungKostenartIDs TABLE
  (
    ID$ INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  -- performance!
    KbBuchungKostenartID INT NOT NULL,            -- from KbBuchungKostenart.KbBuchungKostenartID
    KbBuchungKostenartIDForDelete INT NOT NULL,   -- from KbBuchungKostenart.KbBuchungKostenartID (used to have unique name for DELETE statment)
    BaPersonID INT NOT NULL,                      -- from KbBuchungKostenart.BaPersonID = BaWVCode.BaPersonID
    BgSplittingArtCode INT NOT NULL,              -- from KbBuchungKostenart.BgSplittingArtCode
    Betrag money NOT NULL,                        -- from KbBuchungKostenart.Betrag
    VerwPeriodeVon datetime,                      -- from KbBuchungKostenart.VerwPeriodeVon
    VerwPeriodeBis datetime,                      -- from KbBuchungKostenart.VerwPeriodeBis
    AmountOfDaysVerwPeriode INT NOT NULL          -- calculated using KbBuchungKostenart.VerwPeriodeVon/Bis
  )

  -- store entries for KbWVEinzelposten
  DECLARE @NewKbWVEinzelposten TABLE
  (
    NewKbWVEinzelpostenID INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,  -- used to identify any entry
    BaPersonID INT,                                                  -- from KbBuchungKostenart.BaPersonID
    BaWVCodeID INT,                                                  -- from BaWVCode.BaWVCodeID
    BaWVCode INT,                                                    -- from BaWVCode.BaWVCode
    KbBuchungKostenartID INT NOT NULL,                               -- from KbBuchungKostenart.KbBuchungKostenartID
    KbKostenstelleID INT,                                            -- from KbBuchungKostenart.KbKostenstelleID
    BgKostenartID INT,                                               -- from KbBuchungKostenart.BgKostenartID
    BgSplittingArtCode INT NOT NULL,                                 -- from KbBuchungKostenart.BgSplittingArtCode
    Betrag money,                                                    -- calculated depending on KbBuchungKostenart.Betrag, BaWVCode.DatumVon/Bis, KbBuchungKostenart.VerwPeriodeVon/Bis and KbBuchungKostenart.BgSplittingArtCode
    DatumVon datetime,                                               -- calculated (same as Betrag)
    DatumBis datetime,                                               -- calculated (same as Betrag)
    SplittingDurchWVLaufDatumBis BIT,                                -- calculated depending on @DatumBisWVLauf and given entries
    Buchungstext varchar(200),                                       -- from KbBuchungKostenart.Buchungstext
    HeimatkantonNr varchar(50),                                      -- from BaWVCode.HeimatkantonNr
    WohnKantonNr varchar(50),                                        -- from BaWVCode.WohnKantonNr
    KantonKuerzel varchar(50),                                       -- from BaWVCode.KantonKuerzel
    Auslandschweizer BIT,                                            -- from BaWVCode.Auslandschweizer
    EintragStatus varchar(2000)                                      -- status from function-call: NULL = good, otherwise an error occured - showing error!
  )

  -------------------------------------------------------------------------------
  -- COLLECT ALL CANDIDATES:
  -- collect all possible entries within KbBuchungKostenart and store ids in
  --   temporary table
  -------------------------------------------------------------------------------
  --   > only those where KbBuchungKostenart.KbPeriodeID = @KbPeriodeID
  --   > only those where KbBuchung.BelegNr IS NOT NULL
  --   > only those where KbBuchung.BelegDatum <= @DatumBisWVLauf
  --   > only those where KbBuchungKostenart.VerwPeriodeVon <= @DatumBisWVLauf
  --   > corresponding entry for BaWVCode.BaPerson (to KbBuchungKostenart.BaPersonID)
  --   > valid for WV (KbBuchungKostenart.Weiterverrechenbar = true)
  --   > valid for WV (BaWVCode.BaWVCode = 21 'ZUG mit Weiterverrechnung > als 2 J. im Kanton' AND 
  --                   BaWVCode.StatusCode = 1 'Gültig')
  --   > only those with KbBuchung.KbBuchungStatusCode IN (6, 10, 13) >> see function
  -------------------------------------------------------------------------------
  INSERT INTO @KbBuchungKostenartIDs
    SELECT DISTINCT                         -- unique only!
           KbBuchungKostenartID             = FCN.KbBuchungKostenartID,                           -- from KbBuchungKostenart.KbBuchungKostenartID
           KbBuchungKostenartIDForDelete    = FCN.KbBuchungKostenartID,                           -- from KbBuchungKostenart.KbBuchungKostenartID (used to delete entries)
           BaPersonID                       = KOA.BaPersonID,                                     -- from KbBuchungKostenart.BaPersonID = BaWVCode.BaPersonID
           BgSplittingArtCode               = KOA.BgSplittingArtCode,                             -- from KbBuchungKostenart.BgSplittingArtCode
           Betrag                           = KOA.Betrag,                                         -- from KbBuchungKostenart.Betrag
           VerwPeriodeVon                   = KOA.VerwPeriodeVon,                                 -- from KbBuchungKostenart.VerwPeriodeVon
           VerwPeriodeBis                   = IsNull(KOA.VerwPeriodeBis, KOA.VerwPeriodeVon),     -- from KbBuchungKostenart.VerwPeriodeBis
           AmountOfDaysVerwPeriode          = (DateDiff(DAY, KOA.VerwPeriodeVon, IsNull(KOA.VerwPeriodeBis, KOA.VerwPeriodeVon)) + 1)    -- amount of days (including border >> +1)

    FROM dbo.fnKbWVGetBuchungKandidaten(@KbPeriodeID, @DatumBisWVLauf) FCN
      INNER JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungKostenartID = FCN.KbBuchungKostenartID

  -------------------------------------------------------------------------------
  -- REMOVE FINISHED ONES:
  -- remove entries from temporary table that are already fully handled within
  --   KbWVEinzelposten and any further processing is not required.
  -- 
  -- to find out if an entry is already done, we have to sum up all days of all
  --   valid existing entries within KbWVEinzelposten. 
  -- if an entry does not have a matching id KbWVEinzelposten.KbBuchungKostenartID, 
  --   this one is not handled yet and therefore cannot be removed from temporary table.
  -------------------------------------------------------------------------------
  DELETE FROM @KbBuchungKostenartIDs
  WHERE 1 = (SELECT CASE WHEN SUM((DateDiff(DAY, WEP.DatumVon, WEP.DatumBis) + 1)) >= AmountOfDaysVerwPeriode   -- compare if sum(valid inserted entries - DatumVon/Bis) is >= amount of given days of VerwPeriodeVon/Bis: 
                                                                                                                --   if sum is ">", this would be invalid (not handled here as error, but handled as equal!)
                                                                                                                --   if sum is "=", then this entry is fully handled and completed, no further processing required
                                                                                                                --   otherwise entry is not complete and needs further processing
                         THEN 1     -- this entry can be removed from temp-table, its completely done
                         ELSE 0     -- this entry cannot be removed, total days of existing valid entries do not match!
                    END
             FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
               INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                                     WVL.Testlauf = 0                                               -- only non-testing entries
             WHERE WEP.KbBuchungKostenartID = KbBuchungKostenartIDForDelete AND                                                     -- sum only entries for current KbBuchungBruttoPersonID
                   WEP.StorniertKbWVEinzelpostenID IS NULL AND                                                                      -- only those who are non-reversed-entries
                   WEP.Ungueltig = 0 AND                                                                                            -- only those who are not marked as invalid (already processed as reversed)
                   WEP.KbWVEinzelpostenStatusCode NOT IN (@KbWVEinzelpostenStatus_Storniert, @KbWVEinzelpostenStatus_TestLauf))     -- we handle statuscode 7='Storniert' and 100='Testlauf' as not existing

  -------------------------------------------------------------------------------
  -- CREATE TEMP WVEinzelposten-ENTRIES:
  -- combine possible new entries with calculated new KbWVEinzelposten entries
  --   use a cursor because direct call won't work
  -- 
  -- the function will do all required calculation and validation for given values
  -------------------------------------------------------------------------------
  -- setup vars asigned from cursor
  DECLARE @InsKbBuchungKostenartID INT
  DECLARE @InsBaPersonID INT
  DECLARE @InsBgSplittingArtCode INT
  DECLARE @InsBetrag money
  DECLARE @InsVerwPeriodeVon datetime
  DECLARE @InsVerwPeriodeBis datetime

  -- setup cursor
  DECLARE curInsertsNewKbWhEinzelposten CURSOR FAST_FORWARD FOR
    SELECT TKA.KbBuchungKostenartID,
           TKA.BaPersonID,
           TKA.BgSplittingArtCode,
           TKA.Betrag,                                     -- don't flip sign
           TKA.VerwPeriodeVon,
           IsNull(TKA.VerwPeriodeBis, TKA.VerwPeriodeVon)  -- if VerwPeriodeBis is empty take VerwPeriodeVon
    FROM @KbBuchungKostenartIDs TKA

  -- loop for each entry
  OPEN curInsertsNewKbWhEinzelposten
  WHILE 1=1
  BEGIN
    FETCH NEXT FROM curInsertsNewKbWhEinzelposten INTO @InsKbBuchungKostenartID, @InsBaPersonID, @InsBgSplittingArtCode,
                                                       @InsBetrag, @InsVerwPeriodeVon, @InsVerwPeriodeBis
    IF @@FETCH_STATUS <> 0 BREAK

    -- try..catch to capture sql-errors from function!
    BEGIN TRY
      -- insert entries for current row
      INSERT INTO @NewKbWVEinzelposten (BaPersonID, BaWVCodeID, BaWVCode, KbBuchungKostenartID, KbKostenstelleID, BgKostenartID,
                                        BgSplittingArtCode, Betrag, DatumVon, DatumBis, SplittingDurchWVLaufDatumBis, Buchungstext,
                                        HeimatkantonNr, WohnKantonNr, KantonKuerzel, Auslandschweizer, EintragStatus)
        SELECT BaPersonID                        = @InsBaPersonID,                                  -- from KbBuchungKostenart.BaPersonID = BaWVCode.BaPersonID
               BaWVCodeID                        = FCN.BaWVCodeID,                                  -- from BaWVCode.BaWVCodeID
               BaWVCode                          = BWC.BaWVCode,                                    -- from BaWVCode.BaWVCode
               KbBuchungKostenartID              = @InsKbBuchungKostenartID,                        -- from KbBuchungKostenart.KbBuchungKostenartID
               KbKostenstelleID                  = KOA.KbKostenstelleID,                            -- from KbBuchungKostenart.KbKostenstelleID
               BgKostenartID                     = KOA.BgKostenartID,                               -- from KbBuchungKostenart.BgKostenartID
               BgSplittingArtCode                = FCN.WEPBgSplittingArtCode,                       -- from KbBuchungKostenart.BgSplittingArtCode
               Betrag                            = FCN.WEPBetrag,                                   -- calculated depending on KbBuchungKostenart.Betrag, BaWVCode.DatumVon/Bis, KbBuchungKostenart.VerwPeriodeVon/Bis and KbBuchungKostenart.BgSplittingArtCode
               DatumVon                          = FCN.WEPDatumVon,                                 -- calculated (same as Betrag)
               DatumBis                          = FCN.WEPDatumBis,                                 -- calculated (same as Betrag)
               SplittingDurchWVLaufDatumBis      = IsNull(FCN.WEPSplittingDurchWVLaufDatumBis, 0),  -- calculated depending on @DatumBisWVLauf and given entries
               Buchungstext                      = KOA.Buchungstext,                                -- from KbBuchungKostenart.Buchungstext
               HeimatkantonNr                    = BWC.HeimatkantonNr,                              -- from BaWVCode.HeimatkantonNr
               WohnKantonNr                      = BWC.WohnKantonNr,                                -- from BaWVCode.WohnKantonNr
               KantonKuerzel                     = BWC.KantonKuerzel,                               -- from BaWVCode.KantonKuerzel
               Auslandschweizer                  = BWC.Auslandschweizer,                            -- from BaWVCode.Auslandschweizer
               EintragStatus                     = FCN.WEPStatus                                    -- status from function-call: NULL = good, otherwise an error occured - showing error!
       FROM dbo.fnKbWVEinzelposten_WVEinheitenProBuchung(@DatumBisWVLauf,
                                                         @InsKbBuchungKostenartID,
                                                         @InsBaPersonID,
                                                         @InsBgSplittingArtCode,
                                                         @InsBetrag,
                                                         @InsVerwPeriodeVon,
                                                         @InsVerwPeriodeBis) FCN

         LEFT JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungKostenartID = FCN.KbBuchungKostenartID  -- left join to capture wrong entries, error will follow later on
         LEFT JOIN dbo.BaWVCode           BWC WITH (READUNCOMMITTED) ON BWC.BaWVCodeID = FCN.BaWVCodeID                      -- left join to capture wrong entries, error will follow later on
    END TRY

    BEGIN CATCH
      -- error occured (high possibly in dbo.fnKbWVEinzelposten_WVEinheitenProBuchung() call), get error message
      SET @ErrorMessage = ERROR_MESSAGE()

      -- append error
      SET @ErrorMessage = 'Error in function-call, entry is invalid! Database error was: ' + IsNull(@ErrorMessage, '<none>')

      -- insert entry with current @InsKbBuchungKostenartID and error message into result
      INSERT INTO @NewKbWVEinzelposten (KbBuchungKostenartID, BgSplittingArtCode, EintragStatus)
        SELECT KbBuchungKostenartID    = @InsKbBuchungKostenartID,         -- from KbBuchungKostenart.KbBuchungKostenartID
               BgSplittingArtCode      = -1,                               -- cannot be NULL
               EintragStatus           = @ErrorMessage                     -- error-status: NULL = good, otherwise an error occured - showing error!

      -- do continue with next entry!
    END CATCH
  END -- [while loop cursor]

  -- close cursor
  CLOSE curInsertsNewKbWhEinzelposten
  DEALLOCATE curInsertsNewKbWhEinzelposten

  -------------------------------------------------------------------------------
  -- HANDLE ERRORS:
  -- validate new entries using the given state returned from function
  --
  -- insert wrong entries into KbWVEinzelpostenFehler and delete them afterwards
  --   from temporary table to prevent wrong data in KbWVEinzelposten
  -------------------------------------------------------------------------------
  -- insert wrong entries int KbWVEinzelpostenFehler
  INSERT INTO dbo.KbWVEinzelpostenFehler (KbWVLaufID, KbBuchungKostenartID, BaPersonID, WVFehlermeldung)
    SELECT DISTINCT
           KbWVLaufID               = @KbWVLaufID,                                  -- static var, created above
           KbBuchungKostenartID     = NEP.KbBuchungKostenartID,                     -- from KbBuchungKostenart.KbBuchungKostenartID
           BaPersonID               = NEP.BaPersonID,                               -- from KbBuchungKostenart.BaPersonID
           WVFehlermeldung          = IsNull(NEP.EintragStatus, '<Unknown error>')  -- error message from function
    FROM @NewKbWVEinzelposten NEP
    WHERE NEP.EintragStatus IS NOT NULL OR            -- error message
          IsNull(BaWVCodeID, -1) < 0 OR               -- invalid BaWVCodeID value
          IsNull(NEP.BgSplittingArtCode, -1) < 0      -- invalid BgSplittingArtCode value


  -- remove wrong entries and continue with valid ones
  DELETE FROM @NewKbWVEinzelposten
  WHERE EintragStatus IS NOT NULL

  -------------------------------------------------------------------------------
  -- INSERT INTO KbWVEinzelposten:
  -- handle inserts within transaction
  -------------------------------------------------------------------------------
    -- init new transaction
    BEGIN TRANSACTION

  -- start try catch block
  BEGIN TRY
    -----------------------------------------------------------------------------
    -- insert all calculated and prepared entries from temp-table 
    --   into KbWVEinzelposten
    -----------------------------------------------------------------------------
    INSERT INTO dbo.KbWVEinzelposten (KbWVLaufID, BaPersonID, BaWVCodeID, BaWVCode, KbBuchungKostenartID, KbKostenstelleID,
                                      BgKostenartID, BgSplittingArtCode, Betrag, DatumVon, DatumBis, SplittingDurchWVLaufDatumBis,
                                      KbWVEinzelpostenStatusCode, Buchungstext, HeimatkantonNr, WohnKantonNr, KantonKuerzel,
                                      Auslandschweizer)
      SELECT KbWVLaufID                       = @KbWVLaufID,                                -- static var, created above
             BaPersonID                       = NEP.BaPersonID,
             BaWVCodeID                       = NEP.BaWVCodeID,
             BaWVCode                         = NEP.BaWVCode,
             KbBuchungKostenartID             = NEP.KbBuchungKostenartID,
             KbKostenstelleID                 = NEP.KbKostenstelleID,
             BgKostenartID                    = NEP.BgKostenartID,
             BgSplittingArtCode               = NEP.BgSplittingArtCode,
             Betrag                           = (FLOOR(NEP.Betrag * 20.0 + 0.5) / 20.0),    -- round up/down to 0.05 CHF
             DatumVon                         = NEP.DatumVon,
             DatumBis                         = NEP.DatumBis,
             SplittingDurchWVLaufDatumBis     = NEP.SplittingDurchWVLaufDatumBis,
             KbWVEinzelpostenStatusCode       = @KbWVEinzelpostenStatusCode,                -- static var, created above
             Buchungstext                     = NEP.Buchungstext,
             HeimatkantonNr                   = NEP.HeimatkantonNr,
             WohnKantonNr                     = NEP.WohnKantonNr,
             KantonKuerzel                    = NEP.KantonKuerzel,
             Auslandschweizer                 = NEP.Auslandschweizer
      FROM @NewKbWVEinzelposten NEP

    -----------------------------------------------------------------------------
    -- everything ok, commit changes now
    -----------------------------------------------------------------------------
    COMMIT TRANSACTION
  END TRY

  BEGIN CATCH
    -- error occured, do undo PscdBelegNr and inserts
    ROLLBACK TRANSACTION

    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()

    -- do not continue
    RAISERROR ('Error: Could not process inserts into dbo.KbWVEinzelposten. Database error was: %s.', 18, 1, @ErrorMessage)
    RETURN
  END CATCH
  -- ============================================================================




  -- ============================================================================
  -- DONE: IF WE ARE HERE, EVERYTHING WORKED AS EXPECTED
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- update entry within KbWVLauf to determine duration
  -------------------------------------------------------------------------------
  UPDATE dbo.KbWVLauf
  SET EndDatum = GetDate()
  WHERE KbWVLaufID = @KbWVLaufID

  -------------------------------------------------------------------------------
  -- fill output variables with valid data
  -------------------------------------------------------------------------------
  SET @Out_KbWVLaufID = IsNull(@KbWVLaufID, -1)

  SELECT @Out_CountNewKbWVEinzelposten = COUNT(1)
  FROM dbo.KbWVEinzelposten WVE WITH(READUNCOMMITTED)
  WHERE WVE.KbWVLaufID = @KbWVLaufID

  -------------------------------------------------------------------------------
  -- return current entry from KbWVLauf 
  --   (used to find corresponding entries within KbWVEinzelposten)
  -------------------------------------------------------------------------------
  /* 
  -- not required anymore --
  SELECT *
  FROM dbo.KbWVLauf WVL WITH(READUNCOMMITTED)
  WHERE WVL.KbWVLaufID = @KbWVLaufID
  */
  -- ============================================================================
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
