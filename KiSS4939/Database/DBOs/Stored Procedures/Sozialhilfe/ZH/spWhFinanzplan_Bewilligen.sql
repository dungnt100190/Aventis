SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Bewilligen
GO

/*===============================================================================================
  $Revision: 7 $
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
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhFinanzplan_Bewilligen]
 (@BgFinanzplanID  int,
  @DatumVon        datetime,
  @BgPositionID    int      = NULL)
AS BEGIN
  DECLARE @FaLeistungID    int,
          @BgBudgetID      int,
          @BaZahlungswegID int,
          @BgAuszahlungID  int

  SELECT
    @FaLeistungID = SFP.FaLeistungID,
    @BgBudgetID   = BBG.BgBudgetID
  FROM dbo.BgFinanzplan      SFP WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                            AND BBG.MasterBudget = 1
  WHERE SFP.BgFinanzplanID = @BgFinanzplanID

  -- UPDATE BgBewilligungStatusCode
  UPDATE BPO
    SET DatumBis = IsNull(DateAdd(DAY, -1, BP2.DatumVon), BPO.DatumBis)
  FROM dbo.BgPosition          BPO WITH (READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BgPosition  BP2 WITH (READUNCOMMITTED) ON BP2.BgBudgetID = @BgBudgetID AND BP2.BgPositionID_CopyOf = BPO.BgPositionID
  WHERE BPO.BgBudgetID = @BgBudgetID AND (@BgPositionID IS NULL OR BP2.BgPositionID = @BgPositionID OR BP2.BgPositionID_Parent = @BgPositionID)

  UPDATE BgPosition
    SET BgBewilligungStatusCode = 5,
        BewilligtVon    = DatumVon,
        BewilligtBis    = DatumBis,
        BewilligtBetrag = Betrag - Reduktion - Abzug,
        FPPosition      = CASE WHEN @BgPositionID IS NULL THEN 1 ELSE 0 END
  WHERE BgBudgetID = @BgBudgetID AND (@BgPositionID IS NULL OR BgPositionID = @BgPositionID OR BgPositionID_Parent = @BgPositionID)


  -- Zahlungsweg
  SELECT TOP 1 @BaZahlungswegID = BZW.BaZahlungswegID
  FROM dbo.FaLeistung             LST WITH (READUNCOMMITTED)
    INNER JOIN dbo.BaZahlungsweg  BZW WITH (READUNCOMMITTED) ON BZW.BaPersonID = LST.BaPersonID
  WHERE LST.FaLeistungID = @FaLeistungID
    AND GetDate() BETWEEN IsNull(BZW.DatumVon, GetDate()) AND IsNull(BZW.DatumBis, GetDate())
  ORDER BY BaZahlungswegID DESC

  DECLARE @BgAuszahlungPerson_BgPositionID int,
          @KeinKreditor bit

  DECLARE cBgPosition CURSOR FAST_FORWARD FOR
    SELECT BgPositionID, BPT.KeinKreditor
    FROM dbo.BgPosition  BPO WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPositionsart BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID    
    WHERE BPO.BgBudgetID = @BgBudgetID AND (@BgPositionID IS NULL OR BPO.BgPositionID = @BgPositionID OR BPO.BgPositionID_Parent = @BgPositionID)
      AND BPO.BgKategorieCode = 2 AND BPO.BgSpezkontoID IS NULL AND BPO.BgPositionID NOT IN (SELECT BgPositionID FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) WHERE BgPositionID IS NOT NULL)

  OPEN cBgPosition
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cBgPosition INTO @BgAuszahlungPerson_BgPositionID, @KeinKreditor
    IF @@FETCH_STATUS < 0 BREAK

    INSERT INTO BgAuszahlungPerson (BgPositionID, KbAuszahlungsArtCode, BaZahlungswegID, BgAuszahlungsTerminCode)
      SELECT @BgAuszahlungPerson_BgPositionID, CASE WHEN @BaZahlungswegID IS NULL AND @KeinKreditor = 0 THEN 103 ELSE 101 END, CASE WHEN @KeinKreditor = 1 THEN NULL ELSE @BaZahlungswegID END, 1

  END

  DEALLOCATE cBgPosition

/* TODO
  -- graue/angefragte Monatsbudget Anpassen
  DECLARE @MonatsbudgetID          int,
          @DateMonatsbudget        datetime,
          @KbZahlungslaufValutaID  int

  DECLARE cBgBudget CURSOR FAST_FORWARD FOR
    SELECT BBG.BgBudgetID, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1), KbZahlungslaufValutaID
    FROM BgBudget                      BBG
      LEFT  JOIN KbZahlungslaufValuta  KZV ON KZV.Jahr = BBG.Jahr AND KZV.Monat = BBG.Monat
      INNER JOIN BgPosition            BP2 ON BP2.BgBudgetID = @BgBudgetID AND BP2.BgPositionID = @BgPositionID
    WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode < 5
      AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) BETWEEN BP2.DatumVon AND IsNull(BP2.DatumBis, '99991231')

  OPEN cBgBudget
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cBgBudget INTO @MonatsbudgetID, @DateMonatsbudget, @KbZahlungslaufValutaID
    IF @@FETCH_STATUS < 0 BREAK

    -- BgPosition read
    SELECT BP2.BgPositionID AS PK, BP2.BgPositionID_Parent AS Parent, BP2.BgAuszahlungID, CONVERT(int, NULL) AS KeyNew
    INTO #BgPosition
    FROM BgBudget            BBG
      INNER JOIN BgPosition  BP2 ON BP2.BgBudgetID = @BgBudgetID AND (BP2.BgPositionID = @BgPositionID OR BP2.BgPositionID_Parent = @BgPositionID)
      LEFT  JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgPositionID_CopyOf = BP2.BgPositionID_CopyOf
    WHERE BBG.BgBudgetID = @DateMonatsbudget AND BPO.BgPositionID IS NULL

    -- BgAuszahlungPerson
    SELECT DISTINCT STZ.BgAuszahlungPersonID AS PK, NULL AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgAuszahlungPerson
    FROM #BgAuszahlung               TMP
      INNER JOIN BgAuszahlungPerson  STZ ON STZ.BgAuszahlungID = TMP.PK

    EXECUTE spXParentChildCopy '#BgAuszahlungPerson',
                               'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                               'BgAuszahlungID', '(SELECT KeyNew FROM #BgAuszahlung WHERE Pk = BgAuszahlungID)'


    -- 1x / 2x monatliche Auszahlung
    UPDATE BAP
      SET Auszahlung1 = CASE BgAuszahlungsTerminCode
                          WHEN 1 THEN IsNull(KZV.DatMonatlich, DateAdd(m, -1, DateAdd(d, 23, @DateMonatsbudget)))
                          WHEN 2 THEN IsNull(KZV.DatTeil1, DateAdd(m, -1, DateAdd(d, 23, @DateMonatsbudget)))
                        END,
        Auszahlung2   = CASE BgAuszahlungsTerminCode
                          WHEN 1 THEN NULL
                          WHEN 2 THEN IsNull(KZV.DatTeil2, DateAdd(d, 15, @DateMonatsbudget))
                        END
    FROM KbZahlungslaufValuta          KZV
      INNER JOIN BgAuszahlung          BAZ ON BAZ.BgBudgetID = @MonatsbudgetID
      INNER JOIN BgAuszahlungPerson    BAP ON BAP.BgAuszahlungID = BAZ.BgAuszahlungID
    WHERE KZV.KbZahlungslaufValutaID = @KbZahlungslaufValutaID AND BAP.BgAuszahlungsTerminCode IN (1, 2)
      AND EXISTS (SELECT * FROM #BgAuszahlung WHERE KeyNew = BAZ.BgAuszahlungID)

    -- Wöchentliche Auszahlung
    INSERT INTO BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
      SELECT BAP.BgAuszahlungPersonID, TMP.Datum
      FROM BgAuszahlung                   BAZ
        INNER JOIN BgAuszahlungPerson     BAP ON BAP.BgAuszahlungID = BAZ.BgAuszahlungID
        INNER JOIN (SELECT Datum =   DatWoche1 FROM KbZahlungslaufValuta WHERE KbZahlungslaufValutaID = @KbZahlungslaufValutaID
                    UNION ALL SELECT DatWoche2 FROM KbZahlungslaufValuta WHERE KbZahlungslaufValutaID = @KbZahlungslaufValutaID
                    UNION ALL SELECT DatWoche3 FROM KbZahlungslaufValuta WHERE KbZahlungslaufValutaID = @KbZahlungslaufValutaID
                    UNION ALL SELECT DatWoche4 FROM KbZahlungslaufValuta WHERE KbZahlungslaufValutaID = @KbZahlungslaufValutaID
                    UNION ALL SELECT DatWoche5 FROM KbZahlungslaufValuta WHERE KbZahlungslaufValutaID = @KbZahlungslaufValutaID) TMP ON TMP.Datum IS NOT NULL
      WHERE BAZ.BgBudgetID = @MonatsbudgetID AND BAP.BgAuszahlungsTerminCode = 3
        AND EXISTS (SELECT * FROM #BgAuszahlung WHERE KeyNew = BAZ.BgAuszahlungID)
      ORDER BY BAP.BgAuszahlungPersonID


    DROP TABLE #BgAuszahlungPerson

    -- BgPosition insert
    DECLARE @FixFieldValue varchar(200)
    SET @FixFieldValue = 'BgPositionID, ' + CONVERT(varchar, @MonatsbudgetID) + ', (SELECT KeyNew FROM #BgAuszahlung WHERE Pk = BgAuszahlungID)'
                       + ', dbo.fnDateSerial(' + CONVERT(varchar, Year(@DateMonatsbudget)) + ', ' + CONVERT(varchar, MONTH(@DateMonatsbudget)) + ', 1)'
                       + ', dbo.fnLastDayOf(dbo.fnDateSerial(' + CONVERT(varchar, Year(@DateMonatsbudget)) + ', ' + CONVERT(varchar, MONTH(@DateMonatsbudget)) + ', 1))'

    EXECUTE spXParentChildCopy '#BgPosition',
                               'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                               'BgPositionID_CopyOf, BgBudgetID, BgAuszahlungID, VerwPeriodeVon, VerwPeriodeBis', @FixFieldValue, 'Bemerkung, DatumVon, DatumBis, OldID'

    DROP TABLE #BgPosition
    DROP TABLE #BgAuszahlung
  END
  DEALLOCATE cBgBudget
*/

  UPDATE BPO
    SET BgPositionID_CopyOf = BP2.BgPositionID,
      Betrag                = BP2.Betrag,
      Reduktion             = BP2.Reduktion,
      Abzug                 = BP2.Abzug,
      MaxBeitragSD          = BP2.MaxBeitragSD,
      VerwaltungSD          = BP2.VerwaltungSD,
      BgSpezkontoID         = CASE WHEN BPO.BgSpezkontoID IS NOT NULL THEN BP2.BgSpezkontoID END
  FROM dbo.BgBudget            BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgPosition  BP2 WITH (READUNCOMMITTED) ON BP2.BgBudgetID = @BgBudgetID AND (BP2.BgPositionID = @BgPositionID OR BP2.BgPositionID_Parent = @BgPositionID)
    INNER JOIN dbo.BgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgPositionID_CopyOf IN (BP2.BgPositionID, BP2.BgPositionID_CopyOf)
  WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode < 5
    AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) BETWEEN BP2.DatumVon AND IsNull(BP2.DatumBis, '99991231')

  DELETE BPO
  FROM dbo.BgBudget            BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgPosition  BP2 WITH (READUNCOMMITTED) ON BP2.BgBudgetID = @BgBudgetID AND (BP2.BgPositionID = @BgPositionID OR BP2.BgPositionID_Parent = @BgPositionID)
    INNER JOIN dbo.BgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgPositionID_CopyOf IN (BP2.BgPositionID, BP2.BgPositionID_CopyOf)
  WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode < 5
    AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) > IsNull(BP2.DatumBis, '99991231')


  -- Spezialkonto (Abzahlung, Vorabzug)
  DECLARE @BgSpezkontoID  int

  DECLARE cBgSpezkonto CURSOR FAST_FORWARD FOR
    SELECT BgSpezkontoID
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) ON SSK.FaLeistungID = SFP.FaLeistungID
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID

  OPEN cBgSpezkonto
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cBgSpezkonto INTO @BgSpezkontoID
    IF @@FETCH_STATUS != 0 BREAK

    EXECUTE spWhSpezkonto_UpdateBudget @BgSpezkontoID, @BgFinanzplanID
  END
  CLOSE cBgSpezkonto
  DEALLOCATE cBgSpezkonto
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
