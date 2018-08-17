SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbWVEinzelposten_WVEinheitenProBuchung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnKbWVEinzelposten_WVEinheitenProBuchung.sql $
  $Author: Mminder $
  $Modtime: 13.01.10 15:37 $
  $Revision: 16 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all WV-Einheiten that match for given entry
           in KbBuchungBruottoPerson. Function does also all required calculations
           for processing new entries depending on given rules and given KbWVEinzelposten entries!
    @DatumBisWVLauf:          The date where the current WV-Lauf ends
    @KbBuchungBruttoPersonID: The id of the corresponding entry within KbBuchungBruttoPerson
    @FaFallID:                The id of the Fall that match WhWVEinheit.FaFallID
    @BaPersonID:              The id of the person that match WhWVEinheitMitglied.BaPersonID
    @BgSplittingArtCode:      The BgSplittingArtCode to use for given VerwendungsPeriode
    @Betrag:                  The MONEY-value to use for calculation of the percentage depending 
                              on existing WV-Einheiten (Warning: can also be negative!)
    @VerwPeriodeVon:          The Verwendungsperiode start date, used for finding matching WV-Einheiten
    @VerwPeriodeBis:          The Verwendungsperiode end date, used for finding matching WV-Einheiten
  -
  RETURNS: Table containing all required values for further processing of WV-Einzelposten, also containing
           status with further informations
  -
  TEST:    SELECT * FROM dbo.fnKbWVEinzelposten_WVEinheitenProBuchung(NULL, 0, 0, 0, -1, 0.0, NULL, NULL)
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnKbWVEinzelposten_WVEinheitenProBuchung.sql $
 * 
 * 16    13.01.10 15:45 Mminder
 * #5467: Rekursverfahren für WV-Einheiten
 * 
 * 15    11.12.09 10:39 Lloreggia
 * Header aktualisiert, ALTER -> CREATE
 * 
 * 14    15.05.09 4:45 Mminder
 * #4179: Nachkorrektur
 * 
 * 11    10.03.09 18:08 Rstahel
 * Abgleich der Functions aus KISS4_MASTER_ZH
 * 
 * 7     19.09.08 17:06 Cjaeggi
 * BugFixes 'Teilausgleich'
 * 
 * 6     19.09.08 16:35 Cjaeggi
 * BugFix 'Teilausgleich'
 * 
 * 5     19.09.08 16:02 Cjaeggi
 * BugFixing 'Teilausgleich'
 * 
 * 4     19.09.08 15:06 Cjaeggi
 * 
 * 3     19.09.08 13:57 Cjaeggi
 * Corrected statement for 'Teilausgleich'
 * 
 * 2     19.09.08 13:51 Cjaeggi
 * Partially implemented 'Teilausgleich'
 * 
 * 1     17.09.08 13:18 Cjaeggi
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION [dbo].[fnKbWVEinzelposten_WVEinheitenProBuchung]
(
 @DatumBisWVLauf DATETIME,
 @KbBuchungBruttoPersonID INT,
 @FaFallID INT,
 @BaPersonID INT,
 @BgSplittingArtCode INT,
 @Betrag money,
 @VerwPeriodeVon DATETIME,
 @VerwPeriodeBis DATETIME
)
RETURNS @Result TABLE
(
  ResultID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,        -- an identity to access every entry as unique
  KbBuchungBruttoPersonID INT NOT NULL,                    -- the id of the item in KbBuchungBruttoPerson
  WhWVEinheitID INT NOT NULL,                              -- the id of the item in WhWVEinheit
  WhWVEinheitMitgliedID INT NOT NULL,                      -- the id of the item in WhWVEinheitMitglied
  AnzahlTageVonBis INT,                                    -- the calculated amount of days from DatumVon to DatumBis of current entry
  ProzentAnteil real,                                      -- the calculated percentage depending on matching WhWVEinheiten
  WEPBeguenstigterBaPersonID INT NOT NULL,                 -- the id of the person that has match entry in KbBuchungBruttoPerson and WhWVEinheitMitglied
  WEPDatumVon DATETIME NOT NULL,                           -- the calculated start date for WVEinzelposten
  WEPDatumBis DATETIME NOT NULL,                           -- the calculated end date for WVEinzelposten
  WEPSplittingDurchWVLaufDatumBis BIT NOT NULL DEFAULT(0), -- flag if the entry is splitted because of @DatumBisWVLauf
  WEPBgSplittingArtCode INT NOT NULL,                      -- the splittingart used for calculations
  WEPBetrag money,                                         -- the calculated MONEY-value corresponding to percentage    
  WEPAlreadyFinishedAndRemoveable BIT DEFAULT(0),          -- store if an entry is already finished with wv but because of 'Teilausgleich' has to be handled later anyway
  WEPAlreadyFinishedAndRemoveableHandled BIT DEFAULT(0),   -- every entry with WEPAlreadyFinishedAndRemoveable=1 has to be handled (removed from result or updated WEPBetrag value) and get the flag WEPAlreadyFinishedAndRemoveable=1, otherwise it will be throw an error due to unexpected state
  WEPStatus varchar(2000)                                  -- the status for given entry (NULL = good, otherwise an error occured - showing error!)
)
AS BEGIN
  -- ============================================================================
  -- INIT
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- create a copy of the @Result-table above (without id-column!) to store new 
  --   entries that are inserted within cursor. otherwise this would cause a 
  --   endless loop...
  -------------------------------------------------------------------------------
  DECLARE @Result_Copy TABLE
  (
    KbBuchungBruttoPersonID INT NOT NULL,                    -- the id of the item in KbBuchungBruttoPerson
    WhWVEinheitID INT NOT NULL,                              -- the id of the item in WhWVEinheit
    WhWVEinheitMitgliedID INT NOT NULL,                      -- the id of the item in WhWVEinheitMitglied
    AnzahlTageVonBis INT,                                    -- the calculated amount of days from DatumVon to DatumBis of current entry
    ProzentAnteil real,                                      -- the calculated percentage depending on matching WhWVEinheiten
    WEPBeguenstigterBaPersonID INT NOT NULL,                 -- the id of the person that has match entry in KbBuchungBruttoPerson and WhWVEinheitMitglied
    WEPDatumVon DATETIME NOT NULL,                           -- the calculated start date for WVEinzelposten
    WEPDatumBis DATETIME NOT NULL,                           -- the calculated end date for WVEinzelposten
    WEPSplittingDurchWVLaufDatumBis BIT NOT NULL DEFAULT(0), -- flag if the entry is splitted because of @DatumBisWVLauf
    WEPBgSplittingArtCode INT NOT NULL,                      -- the splittingart used for calculations
    WEPBetrag money,                                         -- the calculated MONEY-value corresponding to percentage    
    WEPAlreadyFinishedAndRemoveable BIT DEFAULT(0),          -- store if an entry is already finished with wv but because of 'Teilausgleich' has to be handled later anyway
    WEPAlreadyFinishedAndRemoveableHandled BIT DEFAULT(0),   -- every entry with WEPAlreadyFinishedAndRemoveable=1 has to be handled (removed from result or updated WEPBetrag value) and get the flag WEPAlreadyFinishedAndRemoveable=1, otherwise it will be throw an error due to unexpected state
    WEPStatus varchar(2000)                                  -- the status for given entry (NULL = good, otherwise an error occured - showing error!)
  )

  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @SuccessfullyDone BIT           -- ensure process has finished with success
  DECLARE @AmountOfDaysVerwPeriode INT    -- count amount of days within VerwPeriode

  -- set vars
  SET @SuccessfullyDone          = 0                                                      -- by default nothing is ok!
  SET @AmountOfDaysVerwPeriode   = (DateDiff(DAY, @VerwPeriodeVon, @VerwPeriodeBis) + 1)  -- amount of days for VerwPeriode (including border >> +1)

  -------------------------------------------------------------------------------
  -- validate parameters and vars
  -------------------------------------------------------------------------------
  IF (@DatumBisWVLauf IS NULL OR
      IsNull(@KbBuchungBruttoPersonID, -1) < 1 OR
      IsNull(@FaFallID, -1) < 1 OR
      IsNull(@BaPersonID, -1) < 1 OR
      IsNull(@BgSplittingArtCode, -1) < 0 OR
      @VerwPeriodeVon IS NULL OR
      @VerwPeriodeBis IS NULL OR
      @VerwPeriodeVon > @VerwPeriodeBis OR
      @BgSplittingArtCode NOT IN (1, 2, 3, 4) OR
      IsNull(@AmountOfDaysVerwPeriode, -1) < 1)
  BEGIN
    -- invalid values
    INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
    VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Invalid or emtpy parameters given, cannot continue!')

    -- stop here
    RETURN
  END

  -- setup given values as expecting
  SET @Betrag = IsNull(@Betrag, 0.0)

  -------------------------------------------------------------------------------
  -- validate if @VerwPeriodeVon > @DatumBisWVLauf, in this case we just do nothing
  -------------------------------------------------------------------------------
  IF (@VerwPeriodeVon > @DatumBisWVLauf)
  BEGIN
    -- in this case, we don't do anything but return
    RETURN
  END
  -- ============================================================================




  -- ============================================================================
  -- COLLECT MATCHING ENTRIES IN WVEinheit AND WVEinheitMitglied
  --
  -- hint: for all SplittingArtCodes the same!
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- collect data
  -------------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT KbBuchungBruttoPersonID                = @KbBuchungBruttoPersonID,            -- static value for current call
           WhWVEinheitID                          = WEH.WhWVEinheitID,
           WhWVEinheitMitgliedID                  = WEM.WhWVEinheitMitgliedID,
           AnzahlTageVonBis                       = NULL,                                -- progressed later on
           ProzentAnteil                          = NULL,                                -- progressed later on
           WEPBeguenstigterBaPersonID             = @BaPersonID,                         -- static value for current call
           WEPDatumVon                            = WEH.DatumVon,
           WEPDatumBis                            = IsNull(WEH.DatumBis, '9999-12-31'),  -- use really big date!!
           WEPSplittingDurchWVLaufDatumBis        = 0,                                   -- by default, not splitted by WV-Lauf!
           WEPBgSplittingArtCode                  = @BgSplittingArtCode,                 -- static value for current call
           WEPBetrag                              = NULL,                                -- progressed later on
           WEPAlreadyFinishedAndRemoveable        = 0,                                   -- by default, entry is not yet finished
           WEPAlreadyFinishedAndRemoveableHandled = 0,                                   -- by default, entry is not yet finished and handled!
           WEPStatus                              = NULL                                 -- by default, no value = 'OK'
    FROM dbo.WhWVEinheitMitglied WEM WITH (READUNCOMMITTED)
      INNER JOIN dbo.WhWVEinheit WEH WITH (READUNCOMMITTED) ON WEH.WhWVEinheitID = WEM.WhWVEinheitID AND
                                                               WEH.FaFallID = @FaFallID AND                 -- only for current FallID
                                                               WEH.Ungueltig = 0 AND                        -- only valid entries
                                                               WEH.WVCode <> 16 AND                         -- 'noch keine Definition möglich' won't be handled
                                                               WEH.BEDCode NOT IN (16031, 16032) AND        -- 'Keine Weiterverrechnung' or 'derzeit keine Definition' won't be handled
                                                               (
                                                                (WEH.DatumVon <= @VerwPeriodeVon AND IsNull(WEH.DatumBis, '9999-12-31') >= @VerwPeriodeVon) OR    -- get entries starting before start of Verwendungsperiode (>= means at least one day at start of Verwendungsperiode)
                                                                (WEH.DatumVon >= @VerwPeriodeVon AND IsNull(WEH.DatumBis, '9999-12-31') <= @VerwPeriodeBis) OR    -- get entries starging with or later than start of Verwendungsperiode and end before or at end of Verwendungsperiode
                                                                (WEH.DatumVon <= @VerwPeriodeBis AND IsNull(WEH.DatumBis, '9999-12-31') >= @VerwPeriodeBis)       -- get entries starting before or within Verwendungsperiode and end later or with Verwendungsperiode (<= means at least one day at end of Verwendungsperiode)
                                                               ) AND
                                                               (WEH.Rekurs IS NULL OR WEH.RekursAbgeschlossen IS NOT NULL) -- dont generate EPs for WVEs with a running Rekurs
    WHERE WEM.BaPersonID = @BaPersonID       -- only for current BaPersonID

  -------------------------------------------------------------------------------
  -- validate data found
  -------------------------------------------------------------------------------
  -- check if any data found
  IF (NOT EXISTS(SELECT TOP 1 1 FROM @Result))
  BEGIN
    -- no data found, do not continue with any processing
    RETURN
  END

  -- validate DatumVon, DatumBis
  IF (EXISTS(SELECT TOP 1 1 FROM @Result WHERE WEPDatumVon IS NULL OR WEPDatumBis IS NULL OR WEPDatumVon > WEPDatumBis))
  BEGIN
    -- >> remove all entries from result in order to prevent returning unknown data
    DELETE FROM @Result

    -- insert error message
    INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
    VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Invalid DatumVon and/or DatumBis in WhWVEinheit, cannot continue!')

    -- stop here
    RETURN
  END
  -- ============================================================================




  -- ============================================================================
  -- 'TAGGENAU' SPLITTING MODES
  --
  -- @BgSplittingArtCode LOV 'BgSplittingart' IN (1='Taggenau', 3='Valuta', 4='Entscheid')
  -- ============================================================================
--  IF (@BgSplittingArtCode IN (1, 2, 3, 4))
  BEGIN
    -----------------------------------------------------------------------------
    -- modify given data and set borders for [VerwPeriodeVon..VerwPeriodeBis]
    -----------------------------------------------------------------------------
    -- update DatumVon
    UPDATE @Result
    SET WEPDatumVon = @VerwPeriodeVon
    WHERE WEPDatumVon < @VerwPeriodeVon

    -- update DatumBis
    UPDATE @Result
    SET WEPDatumBis = @VerwPeriodeBis
    WHERE WEPDatumBis > @VerwPeriodeBis

    -----------------------------------------------------------------------------
    -- !! handle splitted entries by earlier WV-Lauf progressing
    -----------------------------------------------------------------------------
    -- init vars
    DECLARE @DayResultID INT
    DECLARE @DayKbBuchungBruttoPersonID INT
    DECLARE @DayWhWVEinheitMitgliedID INT
    DECLARE @DayWEPDatumVon DATETIME           -- used for 'Teilausgleich' to insert a new entry on already finished items

    DECLARE @DayEndDateOfLastMatchingEntry DATETIME
    DECLARE @ErrorDaySplit varchar(255)

    -- set vars
    SET @DayEndDateOfLastMatchingEntry = NULL

    SET @ErrorDaySplit = NULL

    -- loop through entries and scan if already an entry exists
    DECLARE curDaySplitWVLauf CURSOR FAST_FORWARD FOR
      SELECT RES.ResultID,
             RES.KbBuchungBruttoPersonID,
             RES.WhWVEinheitMitgliedID,
             RES.WEPDatumVon
      FROM @Result RES

    -----------------------------------
    OPEN curDaySplitWVLauf
    WHILE 1=1
    BEGIN
      FETCH NEXT FROM curDaySplitWVLauf INTO @DayResultID, @DayKbBuchungBruttoPersonID, @DayWhWVEinheitMitgliedID, @DayWEPDatumVon
      IF @@FETCH_STATUS <> 0 BREAK

      -----------------------------------
      -- check if any valid entry with SplittingDurchWVLaufDatumBis = 0 exists --> mark this entry as already finished within WV
      -----------------------------------
      IF (EXISTS(SELECT TOP 1 1
                 FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
                   INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                                         WVL.Testlauf = 0    -- only non-testing entries
                 WHERE WEP.KbBuchungBruttoPersonID = @DayKbBuchungBruttoPersonID AND         -- matching KbBuchungBruttoPersonID entry
                       WEP.WhWVEinheitMitgliedID = @DayWhWVEinheitMitgliedID AND             -- matching WhWVEinheitMitgliedID entry
                       WEP.SplittingDurchWVLaufDatumBis = 0 AND
                       WEP.StorniertKbWVEinzelpostenID IS NULL AND                           -- only those who are non-reversed-entries
                       WEP.Ungueltig = 0 AND                                                 -- only those who are not marked as invalid (already processed as reversed)
                       WEP.KbWVEinzelpostenStatusCode NOT IN (7, 100)))                      -- only non-reversal and non-testing entries (includes only status L,V,F,B,A,N --> some of S will receive invalid-flag and will not be found here!)
      BEGIN
        -- set entry as already finished and continue
        UPDATE RES
        SET RES.WEPAlreadyFinishedAndRemoveable = 1  -- mark as already finished but because of 'Teilausgleich', we leave entry in result and remove it later on
        FROM @Result RES
        WHERE RES.ResultID = @DayResultID
      END

      -----------------------------------
      -- otherwise if: check if any entry with SplittingDurchWVLaufDatumBis = 1 exists --> candidate for further special handling
      --   hint: more than one entry is possible!
      -----------------------------------
      ELSE IF (EXISTS(SELECT TOP 1 1
                      FROM KbWVEinzelposten WEP
                        INNER JOIN KbWVLauf WVL ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                   WVL.Testlauf = 0                            -- only non-testing entries
                      WHERE WEP.KbBuchungBruttoPersonID = @DayKbBuchungBruttoPersonID AND      -- matching KbBuchungBruttoPersonID entry
                            WEP.WhWVEinheitMitgliedID = @DayWhWVEinheitMitgliedID AND          -- matching WhWVEinheitMitgliedID entry
                            WEP.SplittingDurchWVLaufDatumBis = 1 AND
                            WEP.StorniertKbWVEinzelpostenID IS NULL AND                        -- only those who are non-reversed-entries
                            WEP.Ungueltig = 0 AND                                              -- only those who are not marked as invalid (already processed as reversed)
                            WEP.KbWVEinzelpostenStatusCode NOT IN (7, 100)))                   -- only non-reversal and non-testing entries (includes only status L,V,F,B,A,N --> some of S will receive invalid-flag and will not be found here!)
      BEGIN
        -- reset vars
        SET @DayEndDateOfLastMatchingEntry = NULL

        -- process existing values (we need last used end-date of existing matching entries)
        SELECT @DayEndDateOfLastMatchingEntry = MAX(WEP.DatumBis)
        FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
          INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                                WVL.Testlauf = 0     -- only non-testing entries
        WHERE WEP.KbBuchungBruttoPersonID = @DayKbBuchungBruttoPersonID AND          -- matching KbBuchungBruttoPersonID entry
              WEP.WhWVEinheitMitgliedID = @DayWhWVEinheitMitgliedID AND              -- matching WhWVEinheitMitgliedID entry
              WEP.SplittingDurchWVLaufDatumBis = 1 AND                               -- only splitted entries!
              WEP.StorniertKbWVEinzelpostenID IS NULL AND                            -- only those who are non-reversed-entries
              WEP.Ungueltig = 0 AND                                                  -- only those who are not marked as invalid (already processed as reversed)
              WEP.KbWVEinzelpostenStatusCode NOT IN (7, 100)                         -- only non-reversal and non-testing entries (includes only status L,V,F,B,A,N --> some of S will receive invalid-flag and will not be found here!)

        -- validate if date is ok
        IF (@DayEndDateOfLastMatchingEntry IS NULL)
        BEGIN
          -- this case should not occure, cancel!
          SET @ErrorDaySplit = 'Invalid end date of last matching entry while processing splitted entries!'
          BREAK
        END

        IF @DayWEPDatumVon < @DayEndDateOfLastMatchingEntry BEGIN
          -- we set new start date as the one we want + 1 --> only if current date is earlier than new date
          --   any further handling is not required, this will be done later on
          UPDATE @Result
          SET WEPDatumVon = DateAdd(DAY, 1, @DayEndDateOfLastMatchingEntry) -- add one day to prevent overlapping entries!
          WHERE ResultID = @DayResultID

          -- used for 'Teilausgleich' to cover already handled date-range:
          --  >> insert a new entry into @Result_Copy (due to endless-loop of @Result) in order to cover date-range that 
          --     actually would already be done
          --  >> any further processing with percentage and amount should work similar to other 'normal' entries
          INSERT INTO @Result_Copy
            SELECT KbBuchungBruttoPersonID                = RES.KbBuchungBruttoPersonID,         -- take from original entry
                   WhWVEinheitID                          = RES.WhWVEinheitID,                   -- take from original entry
                   WhWVEinheitMitgliedID                  = RES.WhWVEinheitMitgliedID,           -- take from original entry
                   AnzahlTageVonBis                       = NULL,                                -- progressed later on
                   ProzentAnteil                          = NULL,                                -- progressed later on
                   WEPBeguenstigterBaPersonID             = RES.WEPBeguenstigterBaPersonID,      -- take from original entry
                   WEPDatumVon                            = @DayWEPDatumVon,                     -- start at original start date
                   WEPDatumBis                            = @DayEndDateOfLastMatchingEntry,      -- end at end of last splitted entry date
                   WEPSplittingDurchWVLaufDatumBis        = 0,                                   -- entry is not splitted by WV-Lauf!
                   WEPBgSplittingArtCode                  = RES.WEPBgSplittingArtCode,           -- take from original entry
                   WEPBetrag                              = NULL,                                -- progressed later on
                   WEPAlreadyFinishedAndRemoveable        = 1,                                   -- by default, entry is finished because it is covered by existing entries!
                   WEPAlreadyFinishedAndRemoveableHandled = 0,                                   -- by default, entry is finished but not yet handled!
                   WEPStatus                              = NULL                                 -- by default, no value = 'OK'
             FROM @Result RES
             WHERE RES.ResultID = @DayResultID                                                   -- of course, only for current entry
        END
      END -- [if any valid entry with SplittingDurchWVLaufDatumBis = 0 exists]
    END
    -----------------------------------

    -- close cursor
    CLOSE curDaySplitWVLauf
    DEALLOCATE curDaySplitWVLauf

    -- check if any error occured while looping through cursor
    IF (@ErrorDaySplit IS NOT NULL)
    BEGIN
      -- an error occured, we cannot continue
      -- >> remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Evaluate existing entries in KbWVEinzelposten, cannot continue! Error was: ' + IsNull(@ErrorDaySplit, ''))

      -- stop here
      RETURN
    END

    -- add entries from @Result_Copy to @Result
    INSERT INTO @Result
      SELECT CPY.*
      FROM @Result_Copy CPY

    -- clear @Result_Copy table due to security
    DELETE FROM @Result_Copy

    -----------------------------------------------------------------------------
    -- !! handle splitting by DatumBisWVLauf
    -----------------------------------------------------------------------------
    -- remove all entries with: out of date DatumVon (should not happen, but does not matter when deleted)
    DELETE FROM @Result
    WHERE WEPDatumVon > @DatumBisWVLauf

    -- update every entry that ends later than DatumBisWVLauf with new limit and flag
    UPDATE @Result
    SET WEPDatumBis = @DatumBisWVLauf,         -- move DatumBis to earlier date (shorten entries)
        WEPSplittingDurchWVLaufDatumBis = 1    -- set flag in order to recalculate other part of this entry later on with next run
    WHERE WEPDatumBis > @DatumBisWVLauf

    -----------------------------------------------------------------------------
    -- validate first given and calculated dates, before we go on with processing
    -----------------------------------------------------------------------------
    IF (EXISTS(SELECT TOP 1 1 FROM @Result WHERE WEPDatumVon IS NULL OR WEPDatumBis IS NULL OR WEPDatumVon > WEPDatumBis))
    BEGIN
      -- this case should never occure, throw error
      -- >> remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Invalid WEPDatumVon and/or WEPDatumBis in result-table, cannot continue!')

      -- stop here
      RETURN
    END

    -----------------------------------------------------------------------------
    -- calculate amount of days of each entry in result
    -----------------------------------------------------------------------------
    -- calulate amount of days
    UPDATE @Result
    SET AnzahlTageVonBis = (DateDiff(DAY, WEPDatumVon, WEPDatumBis) + 1)  -- amount of days for DatumVon..DatumBis (including border >> +1)

    -- validate if all amount of days are valid
    IF (EXISTS(SELECT TOP 1 1 FROM @Result WHERE AnzahlTageVonBis IS NULL OR AnzahlTageVonBis > @AmountOfDaysVerwPeriode))
    BEGIN
      -- this case should never occure, throw error
      -- >> remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Invalid amount of days in result table, cannot continue!')

      -- stop here
      RETURN
    END

    -----------------------------------------------------------------------------
    -- calculate percentage depending on amount of days within VerwPeriode
    -----------------------------------------------------------------------------
    -- setup percentage depending on amount of day WEP and VerwPeriode
    UPDATE @Result
    SET ProzentAnteil = CONVERT(real, AnzahlTageVonBis) / CONVERT(real, @AmountOfDaysVerwPeriode)  -- no rounding at this position!

    -----------------------------------------------------------------------------
    -- calculate 'WEPBetrag' depending on percentage of each entry
    -----------------------------------------------------------------------------
    -- calculate amount value
    UPDATE @Result
    SET WEPBetrag = CONVERT(money,ProzentAnteil * @Betrag)           -- no rounding at this position!

   -- validate if each value has a valid amount
    IF (EXISTS(SELECT TOP 1 1 FROM @Result WHERE WEPBetrag IS NULL))
    BEGIN
      -- this case should never occure, throw error
      -- >> remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Invalid amount value in result table, cannot continue!')

      -- stop here
      RETURN
    END

    -- validate if SUM('Betrag') is not more than given amount and corresponding sign is valid
    DECLARE @SumWEPBetrag money

    SELECT @SumWEPBetrag = SUM(WEPBetrag)
    FROM @Result

    IF ((@Betrag >= 0   AND @SumWEPBetrag > @Betrag + 0.05) OR
        (@Betrag <  0   AND @SumWEPBetrag < @Betrag - 0.05) OR
        (@Betrag >= 0.0 AND @SumWEPBetrag < 0.0) OR
        (@Betrag <  0.0 AND @SumWEPBetrag > 0.0))
    BEGIN
      -- this case should never occure, throw error
      -- >> remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Invalid, SUM(amount) is more than given parameter-amount or sign-error (@Betrag=' + IsNull(CONVERT(varchar, @Betrag), 'NULL') + ', @SumWEPBetrag=' + IsNull(CONVERT(varchar, @SumWEPBetrag), 'NULL') + '), cannot continue!')

      -- stop here
      RETURN
    END

    -- ==========================================================================
    -- handle 'Teilausgleich' for those entries that are marked as already 
    --   finished (shorthand expression TA means 'TeilAusgleich')
    -- ==========================================================================
    -- if an entry is marked as already finished, we have to check if existing
    --   entries have the same MONEY-amount as we calculated for a non-existing entry.
    -- 
    -- if the calculated new WV-EP-entry already exists in as one or many parts within
    --   KbWVEinzelposten with different amount (SUM(KbWVEinzelposten.Betrag) <> @Result.WEPBetrag),
    --   we do not remove the entry from @Result, we modify the amount WEPBetrag to the
    --   delta: @Result.WEPBetrag = @Result.WEPBetrag - SUM(KbWVEinzelposten.Betrag)
    -- 
    -- with every WV-Lauf the new created date-ranges should never be smaller than
    --   already existing entries. if this would be the case, the smaller ones
    --   would not find its corresponding existing bigger entry and therefore would not
    --   be marked as handled -> throws an exception, which is good here!
    -- ==========================================================================
    -- init vars
    DECLARE @TAResultID INT
    DECLARE @TAKbBuchungBruttoPersonID INT
    DECLARE @TAWhWVEinheitMitgliedID INT
    DECLARE @TABeguenstigterBaPersonID INT
    DECLARE @TAWEPDatumVon DATETIME
    DECLARE @TAWEPDatumBis DATETIME
    DECLARE @TAWEPBetragRounded money

    DECLARE @TABetragExistingWVEPs money       -- used to store amount that was already handled by 0..n existing WV-Einzelposten for given entry
    DECLARE @TABetragDifference money          -- used to store once calulated value as difference between existing and new amount

    -- loop through entries and scan if already money has been handled for this entry
    DECLARE curTANewEntries CURSOR FAST_FORWARD FOR
      SELECT RES.ResultID,
             RES.KbBuchungBruttoPersonID,
             RES.WhWVEinheitMitgliedID,
             RES.WEPBeguenstigterBaPersonID,
             RES.WEPDatumVon,
             RES.WEPDatumBis,
             (FLOOR(RES.WEPBetrag * 20.0 + 0.5) / 20.0) AS TAWEPBetragRounded    -- round up/down to 0.05 CHF (has to be the same as in dbo.spKbWVEinzelpostenGenerieren!!)
      FROM @Result RES
      WHERE RES.WEPAlreadyFinishedAndRemoveable = 1

    -----------------------------------
    OPEN curTANewEntries
    WHILE 1=1
    BEGIN
      FETCH NEXT FROM curTANewEntries INTO @TAResultID, @TAKbBuchungBruttoPersonID, @TAWhWVEinheitMitgliedID, @TABeguenstigterBaPersonID, @TAWEPDatumVon, @TAWEPDatumBis, @TAWEPBetragRounded
      IF @@FETCH_STATUS <> 0 BREAK

      -- reset non-cursor-vars due to security
      SET @TABetragExistingWVEPs = NULL
      SET @TABetragDifference = NULL

      -- check if any valid entry with SplittingDurchWVLaufDatumBis = 0 exists --> get amount and compare with current new entry
      IF (EXISTS(SELECT TOP 1 1
                 FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
                   INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                                         WVL.Testlauf = 0         -- only non-testing entries
                 WHERE WEP.KbBuchungBruttoPersonID = @TAKbBuchungBruttoPersonID AND               -- matching KbBuchungBruttoPersonID entry
                       WEP.WhWVEinheitMitgliedID = @TAWhWVEinheitMitgliedID AND                   -- matching WhWVEinheitMitgliedID entry
                       WEP.BeguenstigterBaPersonID = @TABeguenstigterBaPersonID AND               -- matching BeguenstigterBaPersonID entry (!! difference to other same selects above, even more security !!)
                       --WEP.SplittingDurchWVLaufDatumBis = 0 AND                                 -- include splitted entries!
                       WEP.StorniertKbWVEinzelpostenID IS NULL AND                                -- only those who are non-reversed-entries
                       WEP.Ungueltig = 0 AND                                                      -- only those who are not marked as invalid (already processed as reversed)
                       WEP.KbWVEinzelpostenStatusCode NOT IN (7, 100) AND                         -- only non-reversal and non-testing entries (includes only status L,V,F,B,A,N --> some of S will receive invalid-flag and will not be found here!)
                       WEP.DatumVon >= @TAWEPDatumVon AND                                         -- only those who are within given date range (DatumVon)
                       WEP.DatumBis <= @TAWEPDatumBis))                                           -- only those who are within given date range (DatumBis)
      BEGIN
        -- entry does already exist and therefore would not be handled anymore -> if there only wasn't the 'Teilausgleich'...
        --   now: get existing money amount and compare with new calculated amount
        SELECT @TABetragExistingWVEPs = SUM(WEP.Betrag)                             -- take sum in order to capture all possible splitted parts of EinzelPosten
        FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
          INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                                WVL.Testlauf = 0         -- only non-testing entries
        WHERE WEP.KbBuchungBruttoPersonID = @TAKbBuchungBruttoPersonID AND               -- matching KbBuchungBruttoPersonID entry
              WEP.WhWVEinheitMitgliedID = @TAWhWVEinheitMitgliedID AND                   -- matching WhWVEinheitMitgliedID entry
              WEP.BeguenstigterBaPersonID = @TABeguenstigterBaPersonID AND               -- matching BeguenstigterBaPersonID entry (!! difference to other same selects above, even more security !!)
              --WEP.SplittingDurchWVLaufDatumBis = 0 AND                                 -- include splitted entries!!
              WEP.StorniertKbWVEinzelpostenID IS NULL AND                                -- only those who are non-reversed-entries
              WEP.Ungueltig = 0 AND                                                      -- only those who are not marked as invalid (already processed as reversed)
              WEP.KbWVEinzelpostenStatusCode NOT IN (7, 100) AND                         -- only non-reversal and non-testing entries (includes only status L,V,F,B,A,N --> some of S will receive invalid-flag and will not be found here!)
              WEP.DatumVon >= @TAWEPDatumVon AND                                         -- only those who are within given date range (DatumVon)
              WEP.DatumBis <= @TAWEPDatumBis                                             -- only those who are within given date range (DatumBis)

        -- check amounts, cannot be NULL due to comparison
        SET @TAWEPBetragRounded = IsNull(@TAWEPBetragRounded, 0.0)
        SET @TABetragExistingWVEPs = IsNull(@TABetragExistingWVEPs, 0.0)

        -- validate if same sign (must be the case due to security of wrong entries!!)
        IF ((@TAWEPBetragRounded >= 0 AND @TABetragExistingWVEPs < 0) OR
            (@TAWEPBetragRounded < 0 AND @TABetragExistingWVEPs >= 0))
        BEGIN
          -- signs do not match, cannot continue due to security issue! this case should never occure, throw error
          -- >> remove all entries from result in order to prevent returning unknown data
          DELETE FROM @Result

          -- insert error message
          INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
          VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Sign does not match while comparing calculated with existing amount for <Teilausgleich>!')

          -- stop here
          RETURN
        END

        -- calculate difference (always: NEWAmount - OLDAmount; e.g.: 600-400 = 200; -600-(-400) = -200) 
        --   >> rounding is already done above
        SET @TABetragDifference = @TAWEPBetragRounded - @TABetragExistingWVEPs

        -- compare with current values (+/- <> 0.0 means we have a delta in comparison with existing values)
        IF (@TABetragDifference <> 0.0)
        BEGIN
          -- we have a difference, update current entry with new amount and mark it as valid
          UPDATE RES
          SET RES.WEPBetrag = @TABetragDifference,               -- calculated difference (automatically rounded up/down to 0.05 CHF)
              RES.WEPAlreadyFinishedAndRemoveable = 0,            -- item is not yet finished and therefore we have to keep it
              RES.WEPAlreadyFinishedAndRemoveableHandled = 0      -- item is not yet finished and therefore we have to keep it
          FROM @Result RES
          WHERE RES.ResultID = @TAResultID                        -- of course, only current item within result
        END
        ELSE
        BEGIN
          -- no difference, mark entry as really removable (entry will be removed later on)
          UPDATE RES
          SET RES.WEPAlreadyFinishedAndRemoveable = 1,            -- item is really finished
              RES.WEPAlreadyFinishedAndRemoveableHandled = 1      -- item is was handled above within current cursor-loop
          FROM @Result RES
          WHERE RES.ResultID = @TAResultID                        -- of course, only current item within result
        END

        -- here, we are done for this entry, go on with next in cursor-loop
      END -- [if at least one existing entry exists]
    END
    -----------------------------------

    -- close cursor
    CLOSE curTANewEntries
    DEALLOCATE curTANewEntries

    -----------------------------------------------------------------------------
    -- remove those who are really really finished from result table 
    --   (WEPAlreadyFinishedAndRemoveable = 1 AND WEPAlreadyFinishedAndRemoveableHandled = 1, 
    --   both have to be true)
    -----------------------------------------------------------------------------
    DELETE FROM @Result
    WHERE WEPAlreadyFinishedAndRemoveable = 1 AND         -- marked as finished
          WEPAlreadyFinishedAndRemoveableHandled = 1      -- marked as finished and handled above

    -----------------------------------------------------------------------------
    -- check if any unhandled entry exists for WEPAlreadyFinishedAndRemoveable=1
    --   this would mean, we could not find matching existing item in KbWVEinzelposten
    --   as expected and therefore did no neccessary corrections on amount
    -----------------------------------------------------------------------------
    IF (EXISTS(SELECT TOP 1 1 FROM @Result WHERE WEPAlreadyFinishedAndRemoveable = 1 AND WEPAlreadyFinishedAndRemoveableHandled = 0))
    BEGIN
      -- this case should never occure, throw error

      -- init vars for detailed output
      DECLARE @RemoveErrCounter INT
      DECLARE @RemoveWEPDatumVon DATETIME
      DECLARE @RemoveWEPDatumBis DATETIME

      -- fill vars for error-details
      SELECT @RemoveErrCounter = COUNT(1)
      FROM @Result RES
      WHERE RES.WEPAlreadyFinishedAndRemoveable = 1 AND
            RES.WEPAlreadyFinishedAndRemoveableHandled = 0

      SELECT TOP 1
             @RemoveWEPDatumVon = RES.WEPDatumVon,
             @RemoveWEPDatumBis = RES.WEPDatumBis
      FROM @Result RES
      WHERE RES.WEPAlreadyFinishedAndRemoveable = 1 AND
            RES.WEPAlreadyFinishedAndRemoveableHandled = 0

      -- remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: There is at least one finished entry that is not yet handled for <Teilausgleich> (Count=''' + CONVERT(varchar, IsNull(@RemoveErrCounter, -1)) + ''', WEPDatumVon=''' + IsNull(CONVERT(varchar, @RemoveWEPDatumVon, 104), '<unknown>') + ''', WEPDatumBis=''' + IsNull(CONVERT(varchar, @RemoveWEPDatumBis, 104), '<unknown>.') +' Values: @DatumBisWVLauf ' +IsNull(CONVERT(varchar, @DatumBisWVLauf),'')+', @KbBuchungBruttoPersonID ' +IsNull(CONVERT(varchar, @KbBuchungBruttoPersonID),'')+', @FaFallID ' +IsNull(CONVERT(varchar, @FaFallID),'')+', @BaPersonID ' +IsNull(CONVERT(varchar, @BaPersonID),'')+', @BgSplittingArtCode ' +IsNull(CONVERT(varchar, @BgSplittingArtCode),'')+', @Betrag ' +IsNull(CONVERT(varchar, @Betrag),'')+', @VerwPeriodeVon ' +IsNull(CONVERT(varchar, @VerwPeriodeVon, 104),'')+', @VerwPeriodeBis ' +IsNull(CONVERT(varchar, @VerwPeriodeBis,104),'') + ''')!')
/*
print @DatumBisWVLauf
print @KbBuchungBruttoPersonID
print @FaFallID
print @BaPersonID
print @BgSplittingArtCode
print @Betrag
print @VerwPeriodeVon
print @VerwPeriodeBis 
*/
      -- stop here
      RETURN
    END
    -- ==========================================================================

    -----------------------------------------------------------------------------
    -- successfully done with 'Taggenau' splitting, set success flag
    -----------------------------------------------------------------------------
    SET @SuccessfullyDone = 1
  END -- ['Taggenau' splitting modes]
  -- ============================================================================

  -- ============================================================================
  -- CHECK: EVERYTHING OK?
  -- ============================================================================
  IF (IsNull(@SuccessfullyDone, 0) = 0)
  BEGIN
    -- an error or unknown process occured, do not continue!
    -- >> remove all entries from result in order to prevent returning unknown data
    DELETE FROM @Result

    -- insert error message
    INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
    VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Something went wrong, due to security no data can be returned!')

    -- stop here
    RETURN
  END
  -- ============================================================================




  -- ============================================================================
  -- DONE: IF WE ARE HERE, EVERYTHING WORKED AS EXPECTED
  -- ============================================================================
  -- return entries found
  RETURN
  -- ============================================================================
END