SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Create
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhBudget_Create.sql $
  $Author: Rstahel $
  $Modtime: 8.08.10 21:18 $
  $Revision: 3 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhBudget_Create.sql $
 * 
 * 3     8.08.10 21:47 Rstahel
 * #3978: Beim Erstellen des Monatsbudges wird neu zusätzlich auch noch
 * die Gültigkeit der Positionsart geprüft (nicht nur die Gültigkeit der
 * Position selber)
 * 
 * 2     25.06.09 8:51 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhBudget_Create
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBudget_Create
 (@BgFinanzplanID   int,
  @BgBudgetID       int = NULL)
AS BEGIN
  DECLARE @BgBudget_Copy       int,
          @DatumVon_SFP        datetime,
          @DatumBis_SFP        datetime,
          @DateMonatsbudget    datetime,
          @JahrMonatsbudget    int,
          @MonatMonatsbudget   int,
          @MonatsDifferenz     int

  -- Get Masterbudget
  SELECT TOP 1
    @BgBudget_Copy        = BBG.BgBudgetID,
    @DatumVon_SFP         = SFP.DatumVon,
    @DatumBis_SFP         = SFP.DatumBis,
    @DateMonatsbudget     = dbo.fnFirstDayOf(SFP.DatumVon)
  FROM dbo.BgFinanzplan      SFP WITH (READUNCOMMITTED) 
    LEFT  JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
  WHERE SFP.BgFinanzplanID = @BgFinanzplanID

  IF EXISTS (SELECT 1 FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgFinanzplanID = @BgFinanzplanID AND BgBudgetID = @BgBudgetID) BEGIN
    SELECT @DateMonatsbudget = dbo.fnDateSerial(Jahr, Monat, 1) FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID
  END ELSE BEGIN
    -- Find Next Monatsbudget
    WHILE EXISTS (SELECT 1 FROM dbo.BgBudget WITH (READUNCOMMITTED) 
                  WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 0
                    AND Jahr = Year(@DateMonatsbudget) AND Monat = month(@DateMonatsbudget)
    ) BEGIN
      SET @DateMonatsbudget = DateAdd(m, 1, @DateMonatsbudget)
    END

    -- Check Datum Next Monatsbudget
    IF @DateMonatsbudget > @DatumBis_SFP BEGIN
      RETURN
    END ELSE BEGIN
      -- BgBudget (Masterbutget)
      INSERT INTO BgBudget (MasterBudget, BgBewilligungStatusCode, BgFinanzplanID, Jahr, Monat)
        VALUES (0, 1, @BgFinanzplanID, Year(@DateMonatsbudget), MONTH(@DateMonatsbudget))

      SET @BgBudgetID = @@IDENTITY
    END
  END

  SELECT
    @JahrMonatsbudget  = Year(@DateMonatsbudget),
    @MonatMonatsbudget = MONTH(@DateMonatsbudget),
    @MonatsDifferenz = DateDiff(m, @DatumVon_SFP, @DateMonatsbudget)

  IF EXISTS (SELECT 1 FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode < 5) BEGIN
    -- BgPosition read
    SELECT BgPositionID AS PK, BgPositionID_Parent AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgPosition
    FROM dbo.BgPosition              BPO WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BgBudgetID = @BgBudget_Copy
      AND IsNull(BPO.DatumVon, '19000101') < IsNull(BPO.DatumBis, '99991231')
      AND (BPO.Betrag > $0.00 OR (BPT.Monatsbudget_EditMask & 0x6 != 0))
      AND (BPO.BgKategorieCode NOT IN (1, 2) OR BPO.BgBewilligungStatusCode = 5)
      AND (IsNull(BPO.DatumVon, '19000101') < dbo.fnLastDayOf(@DateMonatsbudget)			-- Only Masterbudget-Positions which are valid in this month 
            AND IsNull(BPO.DatumBis, '99991231') > dbo.fnFirstDayOf(@DateMonatsbudget))
      AND (IsNull(BPT.DatumVon, '19000101') < dbo.fnLastDayOf(@DateMonatsbudget)			-- Only PositionArt which are valid in this month
            AND IsNull(BPT.DatumBis, '99991231') > dbo.fnFirstDayOf(@DateMonatsbudget))

    -- BgPosition insert
    DECLARE @FixFieldValue varchar(200)
    SET @FixFieldValue = 'BgPositionID, ' + CONVERT(varchar, @BgBudgetID)
                       + ', DateAdd(m, ' + CONVERT(varchar, @MonatsDifferenz) + ', FaelligAm)'
                       + ', dbo.fnDateSerial(' + CONVERT(varchar, @JahrMonatsbudget) + ', ' + CONVERT(varchar, @MonatMonatsbudget) + ', 1)'
                       + ', dbo.fnLastDayOf(dbo.fnDateSerial(' + CONVERT(varchar, @JahrMonatsbudget) + ', ' + CONVERT(varchar, @MonatMonatsbudget) + ', 1))'

    EXECUTE spXParentChildCopy '#BgPosition',
                               'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                               'BgPositionID_CopyOf, BgBudgetID, FaelligAm, VerwPeriodeVon, VerwPeriodeBis', @FixFieldValue, 'BgBewilligungStatusCode, Bemerkung, DatumVon, DatumBis, OldID, ShBelegID'

    -- BgAuszahlungPerson
    SELECT BgAuszahlungPersonID AS PK, CONVERT(int, NULL) AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgAuszahlungPerson
    FROM dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) 
      INNER  JOIN #BgPosition  BPO ON BPO.PK = BAP.BgPositionID

    EXECUTE spXParentChildCopy '#BgAuszahlungPerson',
                               'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                               'BgPositionID', '(SELECT KeyNew FROM #BgPosition WHERE PK = BgPositionID)'

    -- BgAuszahlungPersonTermin
    INSERT INTO BgAuszahlungPersonTermin(BgAuszahlungPersonID, Datum)
      SELECT TMP.KeyNew,
        CASE
          WHEN BAP.BgAuszahlungsTerminCode = 4 THEN DateAdd(m, @MonatsDifferenz, BAT.Datum) -- Valuta
          ELSE TRM.Datum
        END
      FROM #BgAuszahlungPerson               TMP
        INNER JOIN dbo.BgAuszahlungPerson        BAP WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = TMP.PK
        LEFT  JOIN dbo.BgAuszahlungPersonTermin  BAT WITH (READUNCOMMITTED) ON BAT.BgAuszahlungPersonID = TMP.PK AND BAP.BgAuszahlungsTerminCode = 4
        LEFT  JOIN dbo.fnKbAuszahlTermine(@JahrMonatsbudget, @MonatMonatsbudget)
                                             TRM ON TRM.BgAuszahlungsTerminCode = BAP.BgAuszahlungsTerminCode
                                                AND (BAP.BgAuszahlungsTerminCode <> 6 OR BAP.BgWochentagCodes LIKE '%' + CONVERT(varchar, TRM.BgWochentagCode) + '%')
      WHERE BAT.BgAuszahlungPersonID IS NOT NULL OR TRM.Datum IS NOT NULL

    DROP TABLE #BgAuszahlungPerson
    DROP TABLE #BgPosition

    -- Update Budget
    EXECUTE spWhBudget_Update @BgBudgetID

    -- Spezialkonto
    EXECUTE spWhBudget_Abzahlungskonto @BgBudgetID
  END

  -- Output
  SELECT BgBudgetID = @BgBudgetID
END
GO