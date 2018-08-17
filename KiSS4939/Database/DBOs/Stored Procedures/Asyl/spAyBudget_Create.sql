SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyBudget_Create
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyBudget_Create.sql $
  $Author: Tabegglen $
  $Modtime: 19.08.10 8:41 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyBudget_Create.sql $
 * 
 * 3     19.08.10 8:59 Tabegglen
 * #3978: Beim Erstellen des Monatsbudges wird neu zusätzlich auch noch
 * die Gültigkeit der Positionsart geprüft (nicht nur die Gültigkeit der
 * Position selber)
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyBudget_Create
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyBudget_Create
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
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BBG.MasterBudget = 1

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
	    RAISERROR ('Der Finanzplan enthält bereits sämtliche Monatsbudgets', 18, 1)
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
    @MonatsDifferenz = DateDiff(m,@DatumVon_SFP, @DateMonatsbudget)

  IF EXISTS (SELECT 1 FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode < 5) BEGIN
    -- BgPosition read
    SELECT BgPositionID AS PK, BgPositionID_Parent AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgPosition
    FROM dbo.BgPosition             BPO WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BgBudgetID = @BgBudget_Copy
      AND IsNull(BPO.DatumVon, '19000101') < IsNull(BPO.DatumBis, '99991231')
      AND (BPO.Betrag > $0.00 OR (BPT.Monatsbudget_EditMask & 0x6 != 0))
      AND (IsNull(BPO.DatumVon, '19000101') < dbo.fnLastDayOf(@DateMonatsbudget)      -- Only Masterbudget-Positions which are valid in this month
            AND IsNull(BPO.DatumBis, '99991231') > dbo.fnFirstDayOf(@DateMonatsbudget))
      AND (IsNull(BPT.DatumVon, '19000101') < dbo.fnLastDayOf(@DateMonatsbudget)			-- Only PositionArt which are valid in this month
            AND IsNull(BPT.DatumBis, '99991231') > dbo.fnFirstDayOf(@DateMonatsbudget))

    -- BgPosition insert
    DECLARE @FixFieldValue varchar(200)
    SET @FixFieldValue = 'BgPositionID, ' + CONVERT(varchar, @BgBudgetID) +
                       + ', dbo.fnDateSerial(' + CONVERT(varchar, Year(@DateMonatsbudget)) + ', ' + CONVERT(varchar, MONTH(@DateMonatsbudget)) + ', 1)'
                       + ', dbo.fnLastDayOf(dbo.fnDateSerial(' + CONVERT(varchar, Year(@DateMonatsbudget)) + ', ' + CONVERT(varchar, MONTH(@DateMonatsbudget)) + ', 1))'

    EXECUTE spXParentChildCopy '#BgPosition',
                               'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                               'BgPositionID_CopyOf, BgBudgetID, VerwPeriodeVon, VerwPeriodeBis', @FixFieldValue, 'BgBewilligungStatusCode, DatumVon, DatumBis, OldID, ShBelegID'
-- Wunsch Asylkoordination: Bemerkungen mitkopieren
-- alte Version:               'BgPositionID_CopyOf, BgBudgetID, VerwPeriodeVon, VerwPeriodeBis', @FixFieldValue, 'BgBewilligungStatusCode, Bemerkung, DatumVon, DatumBis, OldID'

    -- BgAuszahlungPerson
    SELECT BgAuszahlungPersonID AS PK, CONVERT(int, NULL) AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgAuszahlungPerson
    FROM dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) 
      INNER  JOIN #BgPosition  BPO ON BPO.PK = BAP.BgPositionID

    EXECUTE spXParentChildCopy '#BgAuszahlungPerson',
                               'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                               'BgPositionID', '(SELECT KeyNew FROM #BgPosition WHERE PK = BgPositionID)'

    DROP TABLE #BgAuszahlungPerson
    DROP TABLE #BgPosition

    -- Update Budget
    EXECUTE spAyBudget_Update @BgBudgetID, 1, 1, 1

    -- Spezialkonto
    EXECUTE spAyBudget_Abzahlungskonto @BgBudgetID
  END

  -- Output
  SELECT BgBudgetID = @BgBudgetID
END
GO