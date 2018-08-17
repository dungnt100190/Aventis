SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbWVEinzelposten_WVEinheitenProBuchung_testwbm
GO
/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
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
  $Log: $
=================================================================================================*/


-------------------------------------------------------------------------------
-- CALL:    Use this function to get all WV-Einheiten that match for given entry
--          in KbBuchungBruottoPerson. Function does also all required calculations
--          for processing new entries depending on given rules and given KbWVEinzelposten entries!
--   
--   DatumBisWVLauf:           The date where the current WV-Lauf ends
--   KbBuchungBruttoPersonID:  The id of the corresponding entry within KbBuchungBruttoPerson
--   FaFallID:                 The id of the Fall that match WhWVEinheit.FaFallID
--   BaPersonID:               The id of the person that match WhWVEinheitMitglied.BaPersonID
--   BgSplittingArtCode:       The BgSplittingArtCode to use for given VerwendungsPeriode
--   Betrag:                   The money-value to use for calculation of the percentage depending 
--                             on existing WV-Einheiten (Warning: can also be negative!)
--   VerwPeriodeVon:           The Verwendungsperiode start date, used for finding matching WV-Einheiten
--   VerwPeriodeBis:           The Verwendungsperiode end date, used for finding matching WV-Einheiten
-- 
-- RETURNS: Table containing all required values for further processing of WV-Einzelposten, also containing
--          status with further informations
-- 
-- TEST:    SELECT * FROM dbo.fnKbWVEinzelposten_WVEinheitenProBuchung(NULL, 0, 0, 0, -1, 0.0, NULL, NULL)
-------------------------------------------------------------------------------
CREATE FUNCTION dbo.fnKbWVEinzelposten_WVEinheitenProBuchung_testwbm
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
  ResultID INT IDENTITY(1, 1) NOT NULL,         -- an identity to access every entry as unique
  KbBuchungBruttoPersonID INT NOT NULL,         -- the id of the item in KbBuchungBruttoPerson
  WhWVEinheitID INT NOT NULL,                   -- the id of the item in WhWVEinheit
  WhWVEinheitMitgliedID INT NOT NULL,           -- the id of the item in WhWVEinheitMitglied
  AnzahlTageVonBis INT,                         -- the calculated amount of days from DatumVon to DatumBis of current entry
  ProzentAnteil real,                           -- the calculated percentage depending on matching WhWVEinheiten
  WEPBeguenstigterBaPersonID INT NOT NULL,      -- the id of the person that has match entry in KbBuchungBruttoPerson and WhWVEinheitMitglied
  WEPDatumVon DATETIME NOT NULL,                -- the calculated start date for WVEinzelposten
  WEPDatumBis DATETIME NOT NULL,                -- the calculated end date for WVEinzelposten
  WEPSplittingDurchWVLaufDatumBis BIT,          -- flag if the entry is splitted because of @DatumBisWVLauf
  WEPBgSplittingArtCode INT NOT NULL,           -- the splittingart used for calculations
  WEPBetrag money,                              -- the calculated money-value corresponding to percentage    
  WEPStatus varchar(2000)                       -- the status for given entry (NULL = good, otherwise an error occured - showing error!)
)
AS BEGIN

insert @Result (KbBuchungBruttoPersonID,WhWVEinheitID,WhWVEinheitMitgliedID,
                WEPBeguenstigterBaPersonID,WEPDatumVon,WEPDatumBis,WEPBgSplittingArtCode)
values (-1,-1,-1,-1,'20990101','20990101',-1)

update @Result set KbBuchungBruttoPersonID = -2

  -- ============================================================================
  -- INIT
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @SuccessfullyDone BIT
  DECLARE @AmountOfDaysVerwPeriode INT

  -- set vars
  SET @SuccessfullyDone = 0                                                             -- by default nothing is ok!
  SET @AmountOfDaysVerwPeriode = (DateDiff(DAY, @VerwPeriodeVon, @VerwPeriodeBis) + 1)  -- amount of days for VerwPeriode (including border >> +1)

  -------------------------------------------------------------------------------
  -- validate parameters and vars
  -------------------------------------------------------------------------------
  IF (@DatumBisWVLauf IS NULL OR IsNull(@KbBuchungBruttoPersonID, -1) < 1 OR IsNull(@FaFallID, -1) < 1 OR
      IsNull(@BaPersonID, -1) < 1 OR IsNull(@BgSplittingArtCode, -1) < 0 OR @VerwPeriodeVon IS NULL OR
      @VerwPeriodeBis IS NULL OR @VerwPeriodeVon > @VerwPeriodeBis OR @BgSplittingArtCode NOT IN (1, 2, 3, 4) OR
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

update @Result set KbBuchungBruttoPersonID = -3

  -------------------------------------------------------------------------------
  -- validate if @VerwPeriodeVon > @DatumBisWVLauf, in this case we just do nothing
  -------------------------------------------------------------------------------
  IF (@VerwPeriodeVon > @DatumBisWVLauf)
  BEGIN
    -- in this case, we don't do anything but return
    RETURN
  END
  -- ============================================================================


update @Result set KbBuchungBruttoPersonID = -4


  -- ============================================================================
  -- COLLECT MATCHING ENTRIES IN WVEinheit AND WVEinheitMitglied
  --
  -- hint: for all SplittingArtCodes the same!
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- collect data
  -------------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT KbBuchungBruttoPersonID           = @KbBuchungBruttoPersonID,         -- static value for current call
           WhWVEinheitID                     = WEH.WhWVEinheitID,
           WhWVEinheitMitgliedID             = WEM.WhWVEinheitMitgliedID,
           AnzahlTageVonBis                  = NULL,                             -- progressed later on
           ProzentAnteil                     = NULL,                             -- progressed later on
           WEPBeguenstigterBaPersonID        = @BaPersonID,                      -- static value for current call
           WEPDatumVon                       = WEH.DatumVon,
           WEPDatumBis                       = IsNull(WEH.DatumBis, '9999-12-31'),  -- use really big date!!
           WEPSplittingDurchWVLaufDatumBis   = 0,                                -- by default, not splitted by WV-Lauf!
           WEPBgSplittingArtCode             = @BgSplittingArtCode,              -- static value for current call
           WEPBetrag                         = NULL,                             -- progressed later on
           WEPStatus                         = NULL                              -- by default, no value = 'OK'
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
                                    )
    WHERE WEM.BaPersonID = @BaPersonID                                           -- only for current BaPersonID

update @Result set KbBuchungBruttoPersonID = -5

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

  IF (@BgSplittingArtCode IN (1, 3, 4))
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

    DECLARE @DayEndDateOfLastMatchingEntry DATETIME
    DECLARE @ErrorDaySplit varchar(255)

    -- set vars
    SET @DayEndDateOfLastMatchingEntry = NULL

    SET @ErrorDaySplit = NULL

    -- loop through entries and scan if already an entry exists
    DECLARE curDaySplitWVLauf CURSOR FAST_FORWARD FOR
      SELECT ResultID, KbBuchungBruttoPersonID, WhWVEinheitMitgliedID
      FROM @Result

    -----------------------------------
    OPEN curDaySplitWVLauf
    WHILE 1=1
    BEGIN
      FETCH NEXT FROM curDaySplitWVLauf INTO @DayResultID, @DayKbBuchungBruttoPersonID, @DayWhWVEinheitMitgliedID
      IF @@FETCH_STATUS <> 0 BREAK

      -- check if any valid entry with SplittingDurchWVLaufDatumBis = 0 exists --> remove this one from result, already finished within WV
      IF (EXISTS(SELECT TOP 1 1
                 FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED) 
                   INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                              WVL.Testlauf = 0                         -- only non-testing entries
                 WHERE WEP.KbBuchungBruttoPersonID = @DayKbBuchungBruttoPersonID AND   -- matching KbBuchungBruttoPersonID entry
                       WEP.WhWVEinheitMitgliedID = @DayWhWVEinheitMitgliedID AND       -- matching WhWVEinheitMitgliedID entry
                       WEP.SplittingDurchWVLaufDatumBis = 0 AND                        -- non-splitted entries!
                       WEP.StorniertKbWVEinzelpostenID IS NULL AND                     -- only those who are non-reversed-entries
                       WEP.Ungueltig = 0 AND                                           -- only those who are not marked as invalid (already processed as reversed)
                       WEP.KbWVEinzelpostenStatusCode <> 100))                         -- only non-testing entries (includes only status L,V,F,B,A,N --> S will receive invalid-flag and will not be found here!)
      BEGIN
        -- remove this entry and continue
        DELETE FROM @Result
        WHERE ResultID = @DayResultID
      END

      -- otherwise if: check if any entry with SplittingDurchWVLaufDatumBis = 1 exists --> candidate for further special handling
      --   hint: more than one entry is possible!
      ELSE IF (EXISTS(SELECT TOP 1 1
                      FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED) 
                        INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                   WVL.Testlauf = 0                            -- only non-testing entries
                      WHERE WEP.KbBuchungBruttoPersonID = @DayKbBuchungBruttoPersonID AND      -- matching KbBuchungBruttoPersonID entry
                            WEP.WhWVEinheitMitgliedID = @DayWhWVEinheitMitgliedID AND          -- matching WhWVEinheitMitgliedID entry
                            WEP.SplittingDurchWVLaufDatumBis = 1 AND                           -- only splitted entries!
                            WEP.StorniertKbWVEinzelpostenID IS NULL AND                        -- only those who are non-reversed-entries
                            WEP.Ungueltig = 0 AND                                              -- only those who are not marked as invalid (already processed as reversed)
                            WEP.KbWVEinzelpostenStatusCode <> 100))                            -- only non-testing entries (includes only status L,V,F,B,A,N --> S will receive invalid-flag and will not be found here!)
      BEGIN
        -- reset vars
        SET @DayEndDateOfLastMatchingEntry = NULL

        -- process existing values (we need last used end-date of existing matching entries)
        SELECT @DayEndDateOfLastMatchingEntry = MAX(WEP.DatumBis)
        FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED) 
          INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                     WVL.Testlauf = 0                            -- only non-testing entries
        WHERE WEP.KbBuchungBruttoPersonID = @DayKbBuchungBruttoPersonID AND      -- matching KbBuchungBruttoPersonID entry
              WEP.WhWVEinheitMitgliedID = @DayWhWVEinheitMitgliedID AND          -- matching WhWVEinheitMitgliedID entry
              WEP.SplittingDurchWVLaufDatumBis = 1 AND                           -- only splitted entries!
              WEP.StorniertKbWVEinzelpostenID IS NULL AND                        -- only those who are non-reversed-entries
              WEP.Ungueltig = 0 AND                                              -- only those who are not marked as invalid (already processed as reversed)
              WEP.KbWVEinzelpostenStatusCode <> 100                              -- only non-testing entries

        -- validate if date is ok
        IF (@DayEndDateOfLastMatchingEntry IS NULL)
        BEGIN
          -- this case should not occure, cancel!
          SET @ErrorDaySplit = 'Invalid end date of last matching entry while processing splitted entries!'
          BREAK
        END

        -- we set new start date as the one we want + 1 --> only if current date is earlier than new date
        --   any further handling is not required, this will be done later on
        UPDATE @Result
        SET WEPDatumVon = DateAdd(DAY, 1, @DayEndDateOfLastMatchingEntry) -- add one day to prevent overlapping entries!
        WHERE ResultID = @DayResultID
      END
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

    -----------------------------------------------------------------------------
    -- successfully done with 'Taggenau' splitting, set success flag
    -----------------------------------------------------------------------------
    SET @SuccessfullyDone = 1
  END -- ['Taggenau' splitting modes]
  -- ============================================================================

update @Result set KbBuchungBruttoPersonID = -6

  -- ============================================================================
  -- 'MONAT' SPLITTING MODE
  --
  -- @BgSplittingArtCode LOV 'BgSplittingart' IN (2='Monat')
  --   but only if not yet done
  -- ============================================================================
  IF (@BgSplittingArtCode = 2 AND IsNull(@SuccessfullyDone, 0) = 0)
  BEGIN
    -----------------------------------------------------------------------------
    -- remove all existing entries, we do not need them anymore. get new entries
    --   from recursion... :)
    -----------------------------------------------------------------------------
    --DELETE FROM @Result

    -----------------------------------------------------------------------------
    -- validate VerwPeriodeVon/Bis 
    --   >> VerwPeriodeVon has to be first day of month
    --   (not validated yet: >> VerwPeriodeBis has to be last day of month >= VerwPeriodeVon)
    -----------------------------------------------------------------------------
    IF (DAY(@VerwPeriodeVon) <> 1)
    BEGIN
      -- VerwPeriodeVon has invalid day, cannot start at different day than '1.'
      -- >> remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: Invalid VerwPeriodeVon for BgSplittingArtCode=''Monat'', cannot have different day than first of month!')

      -- stop here
      RETURN
    END

update @Result set KbBuchungBruttoPersonID = -7


    -----------------------------------------------------------------------------
    -- create temporary tables for collecting data and later processing
    -----------------------------------------------------------------------------
    DECLARE @SplitVerwPeriodeByMonth TABLE
    (
      ID INT IDENTITY (1, 1) NOT NULL,    -- used to identify any entry
      FirstDayOfMonth DATETIME NOT NULL,  -- used to store each first day of given months
      Betrag money                        -- used to store amount for each month (totalamount / #months)
    )

    -----------------------------------------------------------------------------
    -- split months of VerwPeriodeVon/Bis to each month
    -----------------------------------------------------------------------------
    -- init start conditions
    DECLARE @NextFirstDayOfMonth DATETIME
    SET @NextFirstDayOfMonth = @VerwPeriodeVon        -- start with start of VerwPeriode

    -- loop while there are any months to split
    WHILE (@NextFirstDayOfMonth < @VerwPeriodeBis)    -- loop as long as start of next-first-day-of-month is < VerwPeriodeBis
    BEGIN
      -- insert current first date of month to temporary table
      INSERT INTO @SplitVerwPeriodeByMonth (FirstDayOfMonth)
      VALUES (@NextFirstDayOfMonth)

      -- add one month to first day of month
      SET @NextFirstDayOfMonth = DateAdd(MONTH, 1, @NextFirstDayOfMonth)
    END

    -- validate if any entry inserted (expect at least one)
    IF (NOT EXISTS(SELECT TOP 1 1 FROM @SplitVerwPeriodeByMonth))
    BEGIN
      -- No entry generated, this is not valid for given VerwPeriode. at least one month is required!
      -- >> remove all entries from result in order to prevent returning unknown data
      DELETE FROM @Result

      -- insert error message
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPBgSplittingArtCode, WEPStatus)
      VALUES (@KbBuchungBruttoPersonID, -1, -1, -1, '9999-01-01', '9999-01-01', -1, 'Error: No month generated for BgSplittingArtCode=''Monat'', at least one month is required!')

      -- stop here
      RETURN
    END

update @Result set KbBuchungBruttoPersonID = -8  --(select count(*) from @SplitVerwPeriodeByMonth)

    -----------------------------------------------------------------------------
    -- calculate amount for each month from total-amount 
    -- 
    -- hint: each month is equal, its #days does not matter for calculating amount
    -----------------------------------------------------------------------------
    -- init vars
    DECLARE @CountSplitMonths INT
    DECLARE @AmountForEachMonth money

    -- count entries
    SELECT @CountSplitMonths = COUNT(1)
    FROM @SplitVerwPeriodeByMonth

    SET @CountSplitMonths = IsNull(@CountSplitMonths, 0)        -- set as '0' to provoke a 'divided by zero'-error if no entry

    -- calculate amount and update each entry
    UPDATE @SplitVerwPeriodeByMonth
    SET Betrag = @Betrag / CONVERT(money, @CountSplitMonths)    -- no rounding at this position!

update @Result set WEPBetrag = (select Betrag from @SplitVerwPeriodeByMonth)

    -----------------------------------------------------------------------------
    -- get for each single month the 'Taggenau'-WV-Einheiten using this function
    --   required to use a cursor, otherwise it would not work!
    --
    -- hint: RECURSION CALL, USING 'Taggenau' FOR EACH SPLITTED MONTH!!
    -----------------------------------------------------------------------------
    -- init cursor vars
    DECLARE @SVMFirstDayOfMonth DATETIME
    DECLARE @SVMBetrag money

    -- setup cursor
    DECLARE curMonthsSplit CURSOR FAST_FORWARD FOR
      SELECT SVM.FirstDayOfMonth,
             SVM.Betrag
      FROM @SplitVerwPeriodeByMonth SVM

    -- loop for each entry
    OPEN curMonthsSplit
    WHILE 1=1
    BEGIN
      FETCH NEXT FROM curMonthsSplit INTO @SVMFirstDayOfMonth, @SVMBetrag
      IF @@FETCH_STATUS <> 0 BREAK

      -- RECURSION: insert entries for current row    
      INSERT INTO @Result (KbBuchungBruttoPersonID, WhWVEinheitID, WhWVEinheitMitgliedID, AnzahlTageVonBis, ProzentAnteil,
                           WEPBeguenstigterBaPersonID, WEPDatumVon, WEPDatumBis, WEPSplittingDurchWVLaufDatumBis,
                           WEPBgSplittingArtCode, WEPBetrag, WEPStatus)
        SELECT KbBuchungBruttoPersonID         = FCN.KbBuchungBruttoPersonID,
               WhWVEinheitID                   = FCN.WhWVEinheitID,
               WhWVEinheitMitgliedID           = FCN.WhWVEinheitMitgliedID,
               AnzahlTageVonBis                = FCN.AnzahlTageVonBis,
               ProzentAnteil                   = FCN.ProzentAnteil,
               WEPBeguenstigterBaPersonID      = FCN.WEPBeguenstigterBaPersonID,
               WEPDatumVon                     = FCN.WEPDatumVon,
               WEPDatumBis                     = FCN.WEPDatumBis,
               WEPSplittingDurchWVLaufDatumBis = FCN.WEPSplittingDurchWVLaufDatumBis,
               WEPBgSplittingArtCode           = FCN.WEPBgSplittingArtCode,
               WEPBetrag                       = FCN.WEPBetrag,
               WEPStatus                       = FCN.WEPStatus
        FROM dbo.fnKbWVEinzelposten_WVEinheitenProBuchung(@DatumBisWVLauf,
                                                          @KbBuchungBruttoPersonID,
                                                          @FaFallID,
                                                          @BaPersonID,
                                                          3,                         -- fake as 'Valuta' because we only have one day (update later back)
                                                          @SVMBetrag,                -- Betrag         = splitted amount from total-amount
                                                          @SVMFirstDayOfMonth,       -- VerwPeriodeVon = first day of month
                                                          @SVMFirstDayOfMonth) FCN   -- VerwPeriodeBis = use just one day (VerwPeriodeVon = VerwPeriodeBis = first day of current month)
    END

    -- close cursor
    CLOSE curMonthsSplit
    DEALLOCATE curMonthsSplit

    -----------------------------------------------------------------------------
    -- reset SplittingArt to 'Monat' because we faked it above as 'Valuta'
    -----------------------------------------------------------------------------
    UPDATE @Result
    SET WEPBgSplittingArtCode = 2 -- 'Monat'

    -----------------------------------------------------------------------------
    -- calculate DatumBis depending on DatumVon (last day of month)
    -----------------------------------------------------------------------------
    UPDATE @Result
    SET WEPDatumBis = dbo.fnLastDayOf(WEPDatumVon)

    -----------------------------------------------------------------------------
    -- successfully done with 'Monat' splitting, set success flag
    -----------------------------------------------------------------------------
    SET @SuccessfullyDone = 1
  END -- ['Monat' splitting modes]
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

