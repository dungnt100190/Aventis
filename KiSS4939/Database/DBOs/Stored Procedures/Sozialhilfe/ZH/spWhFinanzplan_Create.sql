SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Create
GO
/*===============================================================================================
  $Revision: 11 $
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

CREATE PROCEDURE [dbo].[spWhFinanzplan_Create]
 (@FaLeistungID     int,
  @GeplantVon       datetime,
  @GeplantBis       datetime,
  @WhHilfeTypCode   int,
  @CopyOfLast       bit = 1,
  @WhGrundbedarfTyp int = NULL)
AS BEGIN
  DECLARE @BgFinanzplanID     int,
          @JahrMonatsbudget   int,
          @MonatMonatsbudget  int,
          @BgBudgetID         int

  -- BgFinanzplan
  INSERT INTO BgFinanzplan (FaLeistungID, BgBewilligungStatusCode, WhHilfeTypCode, GeplantVon, GeplantBis)
    VALUES (@FaLeistungID, 1, @WhHilfeTypCode, @GeplantVon, @GeplantBis)

  SELECT
    @BgFinanzplanID    = @@IDENTITY,
    @JahrMonatsbudget  = Year(@GeplantVon),
    @MonatMonatsbudget = MONTH(@GeplantVon)

  -- BgBudget (Masterbutget)
  INSERT INTO BgBudget (MasterBudget, BgBewilligungStatusCode, BgFinanzplanID, Jahr, Monat)
    VALUES (1, 1, @BgFinanzplanID, @JahrMonatsbudget, @MonatMonatsbudget)

  SET @BgBudgetID = @@IDENTITY


  DECLARE @BgFinanzplanID_Copy int,
          @BgBudget_Copy       int,
          @MonatsDifferenz     int

  SELECT TOP 1
    @BgBudget_Copy        = BBG.BgBudgetID,
    @BgFinanzplanID_Copy  = BBG.BgFinanzplanID,
    @MonatsDifferenz      = DateDiff(m, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1), @GeplantVon)
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE SFP.FaLeistungID = @FaLeistungID AND BBG.MasterBudget = 1
    AND SFP.BgFinanzplanID != @BgFinanzplanID
  ORDER BY Jahr DESC, Monat DESC


  IF @WhHilfeTypCode = 1 BEGIN -- nur Zürich (Notfallzahlung)
    UPDATE BgBudget SET MasterBudget = 0 WHERE BgBudgetID = @BgBudgetID

    -- Personen
    INSERT INTO BgFinanzplan_BaPerson(BgFinanzplanID, BaPersonID, IstUnterstuetzt)
      SELECT @BgFinanzplanID, BaPersonID, IstUnterstuetzt
      FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
      WHERE BgFinanzplanID = @BgFinanzplanID_Copy

    -- Nofallzahlung
    INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, VerwPeriodeVon, VerwPeriodeBis)
      SELECT @BgBudgetID, BgKategorieCode, BgPositionsartID, [Name], dbo.fnFirstDayOf(@GeplantVon), dbo.fnLastDayOf(@GeplantVon)
      FROM dbo.WhPositionsart
      WHERE BgPositionsartID = 40227

    RETURN
  END

  IF @CopyOfLast = 1 BEGIN
    -- Personen
    INSERT INTO BgFinanzplan_BaPerson(BgFinanzplanID, BaPersonID, IstUnterstuetzt)
      SELECT @BgFinanzplanID, BaPersonID, IstUnterstuetzt
      FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
      WHERE BgFinanzplanID = @BgFinanzplanID_Copy

    -- Copy BgPosition
    SELECT BgPositionID AS PK, BgPositionID_Parent AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgPosition
    FROM BgPosition  BPO
      LEFT  JOIN dbo.WhPositionsart  BPT ON BPT.BgPositionsartID = BPO.BgPositionsartID
      LEFT  JOIN dbo.BgBudget        BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
      LEFT  JOIN dbo.BgFinanzplan    FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    WHERE BPO.BgBudgetID = @BgBudget_Copy AND NOT (BPO.BgKategorieCode IN (1, 2) AND BPT.BgPositionsartID IS NULL)
      AND (BPO.DatumBis IS NULL OR BPO.DatumBis > @GeplantVon)	-- Kopiere die Positionen, deren Gültigkeit in die Gültigkeit des neuen FP hineinreichen
      AND IsNull(BPO.Hidden, 0) = 0

    DECLARE @FixFieldValue varchar(100)
    SET @FixFieldValue = CONVERT(varchar, @BgBudgetID) + ',0'
    EXECUTE dbo.spXParentChildCopy '#BgPosition',
                                   'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                                   'BgBudgetID,FPPosition', @FixFieldValue, 
                                   'BgPositionID_CopyOf, BgBewilligungStatusCode, BewilligtVon,BewilligtBis,BewilligtBetrag,OldID'

    -- Lösche das DatumVon der neuen Positionen, falls es vor dem Start des neuen FPs liegt
    UPDATE dbo.BgPosition 
    SET DatumVon = NULL
    WHERE BgBudgetID = @BgBudgetID 
      AND DatumVon <= @GeplantVon;

    -- Bei Einnahmen das Fälligkeitsdatum hochzählen
    UPDATE BgPosition
    SET FaelligAm = DateAdd(month, @MonatsDifferenz, FaelligAm)
    WHERE BgBudgetID = @BgBudgetID
      AND BgKategorieCode = 1
      AND FaelligAm IS NOT NULL

    -- Copy BgAuszahlungPerson
    SELECT BgAuszahlungPersonID AS PK, CONVERT(int, NULL) AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgAuszahlungPerson
    FROM dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) 
      INNER  JOIN #BgPosition  BPO ON BPO.PK = BAP.BgPositionID
      INNER  JOIN BgPosition   POS ON POS.BgPositionID = BAP.BgPositionID
      LEFT   JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
    WHERE POA.KeinKreditor IS NULL OR POA.KeinKreditor = 0;

    EXECUTE spXParentChildCopy '#BgAuszahlungPerson',
                               'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                               'BgPositionID', '(SELECT KeyNew FROM #BgPosition WHERE PK = BgPositionID)'

    -- Bei Positionen auf Positionsart mit KeinKreditor=1 muss der Kreditor gelöscht werden
    UPDATE BAP SET BaZahlungswegID = NULL
    FROM dbo.BgAuszahlungPerson BAP
      INNER JOIN BgPosition BPO ON BPO.BgPositionID = BAP.BgPositionID
      INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID 
      AND POA.KeinKreditor = 1;

    -- Sicherstellen, dass Positionen nicht auf ein Ausgabekonto umgeleitet werden
    UPDATE POS SET BgSpezkontoID = NULL 
    FROM dbo.BgPosition POS 
      INNER JOIN dbo.BgSpezkonto SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID = POS.BgSpezkontoID
    WHERE BgBudgetID = @BgBudgetID
      AND SPZ.BgSpezkontoTypCode = 1; -- Ausgabekonto

    -- Copy BgAuszahlungPersonTermin
    INSERT INTO BgAuszahlungPersonTermin(BgAuszahlungPersonID, Datum)
      SELECT TMP.KeyNew, DateAdd(m, @MonatsDifferenz, BAT.Datum) -- Valuta
      FROM #BgAuszahlungPerson                  TMP
        INNER JOIN dbo.BgAuszahlungPerson       BAP WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = TMP.PK
        INNER JOIN dbo.BgAuszahlungPersonTermin BAT WITH (READUNCOMMITTED) ON BAT.BgAuszahlungPersonID = TMP.PK AND BAP.BgAuszahlungsTerminCode = 4

    DROP TABLE #BgAuszahlungPerson
    DROP TABLE #BgPosition
  END

  IF NOT EXISTS (SELECT * FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) WHERE BgFinanzplanID = @BgFinanzplanID) BEGIN
    INSERT INTO BgFinanzplan_BaPerson(BgFinanzplanID, BaPersonID, IstUnterstuetzt)
      SELECT @BgFinanzplanID, BaPersonID, 1
      FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
      WHERE FaLeistungID = @FaLeistungID
  END

  IF @WhGrundbedarfTyp IS NULL
    SELECT @WhGrundbedarfTyp = BPO.BgPositionsartID
    FROM dbo.BgPosition        BPO WITH (READUNCOMMITTED) 
      INNER JOIN dbo.XLOVCode  XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID

  IF @WhGrundbedarfTyp IS NULL
    SELECT TOP 1 @WhGrundbedarfTyp = Code
    FROM dbo.XLOVCode WITH (READUNCOMMITTED) 
    WHERE LOVName = 'WhGrundbedarfTyp'
    ORDER BY SortKey

  UPDATE BgFinanzplan SET WhGrundbedarfTypCode = @WhGrundbedarfTyp WHERE BgFinanzplanID = @BgFinanzplanID

  -- Falscher Grundbedarf
  DELETE BPO
  FROM dbo.BgPosition             BPO
    INNER JOIN dbo.WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3201
  WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgPositionsartID != @WhGrundbedarfTyp AND NOT (@WhGrundbedarfTyp = 32011 AND BPO.BgPositionsartID IN (32012, 32013, 32014))

  -- Grundbedarf Neu
  IF NOT EXISTS (SELECT * FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = @WhGrundbedarfTyp)
    INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag, Buchungstext)
      SELECT TOP 1 @BgBudgetID, 2, @WhGrundbedarfTyp, $-1.00, [Name]
      FROM dbo.BgPositionsart WITH (READUNCOMMITTED) 
      WHERE BgPositionsartID = @WhGrundbedarfTyp

  IF @WhGrundbedarfTyp = 32011 BEGIN
    -- Zuschlag zu Grundbedarf I
    IF NOT EXISTS (SELECT * FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = 32012)
      INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
        VALUES (@BgBudgetID, 2, 32012)

    -- Grundbedarf 2
    IF NOT EXISTS (SELECT * FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = 32013)
      INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
        VALUES (@BgBudgetID, 2, 32013)
  END

  IF NOT EXISTS (
    SELECT *
    FROM dbo.BgPosition             BPO WITH (READUNCOMMITTED) 
      INNER JOIN dbo.WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3206
  )
  BEGIN
    DECLARE @Miete              money,
            @Nebenkosten        money,
            @MieteAnteil        money,
            @NebenkostenAnteil  money

    SELECT TOP 1
      @Miete       = IsNull(Miete, $0.00),       @Nebenkosten       = $0.00,
      @MieteAnteil = IsNull(MieteAnteil, $0.00), @NebenkostenAnteil = $0.00
    FROM dbo.FaLeistung                     LST WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BaWohnsituationPerson  WOP WITH (READUNCOMMITTED) ON WOP.BaPersonID = LST.BaPersonID
      INNER JOIN dbo.BaWohnsituation        WOH WITH (READUNCOMMITTED) ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
    WHERE LST.FaLeistungID = @FaLeistungID
      AND @GeplantVon BETWEEN IsNull(WOH.DatumVon, @GeplantVon) AND IsNull(WOH.DatumBis, @GeplantVon)
    ORDER BY WOH.DatumVon DESC

    -- Wohnkosten
    INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag, Reduktion, MaxBeitragSD, Buchungstext)
      SELECT TOP 1 @BgBudgetID, 2, SPT.BgPositionsartID, IsNull(@Miete, $0.00), IsNull(@Miete - @MieteAnteil, $0.00), IsNull(@MieteAnteil, $0.00), [Name]
      FROM dbo.WhPositionsart   SPT
      WHERE SPT.BgGruppeCode = 3206
      ORDER BY SPT.SortKey, BgPositionsartID

    -- Wohnnebenkosten
    INSERT INTO BgPosition (BgPositionID_Parent, BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag, Reduktion, MaxBeitragSD, Buchungstext)
      SELECT TOP 1 @@IDENTITY, @BgBudgetID, 2, 32060, IsNull(@Nebenkosten, $0.00), IsNull(@Nebenkosten - @NebenkostenAnteil, $0.00), IsNull(@NebenkostenAnteil, $0.00), [Name]
      FROM dbo.WhPositionsart   SPT
      WHERE SPT.BgPositionsartID = 32060

  END

  EXECUTE spWhFinanzplan_Update @BgFinanzplanID
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
