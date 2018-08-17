SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Create;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhFinanzplan_Create.sql $
  $Author: Tabegglen $
  $Modtime: 19.08.10 13:45 $
  $Revision: 9 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhFinanzplan_Create.sql $
 * 
 * 7     19.08.10 14:03 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode
 * 
 * 6     17.08.10 0:44 Rstahel
 * #3978: Terminieren von Positionsarten im Masterbudget ist nun
 * implementiert, und zwar werden Vorgänger und Nachfolgerpositionen
 * erstellt, falls nötig, und die abhängigen Daten (BgAuszahlungPerson und
 * PersonTermin) werden ebenfalls kopiert. Diese Funktion wird bei jedem
 * Finanzplan-Update ausgeführt.
 * 
 * 5     13.08.10 7:32 Cjaeggi
 * #3978: BugFixing, Formatting
 * 
 * 4     12.08.10 18:16 Rstahel
 * #3978: Terminieren von Positionen im Masterbudget in separate SP
 * ausgegliedert, so dass diese SP auch beim Erstellen eines FP verwendet
 * werden kann
 * 
 * 3     15.02.10 13:50 Ckaeser
 * Clean Code
 * 
 * 2     25.06.09 8:47 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE PROCEDURE dbo.spWhFinanzplan_Create
(
  @FaLeistungID     INT,
  @GeplantVon       DATETIME,
  @GeplantBis       DATETIME,
  @WhHilfeTypCode   INT,
  @CopyOfLast       BIT = 1,
  @WhGrundbedarfTyp INT = NULL
)
AS 
BEGIN
  DECLARE @BgFinanzplanID INT;
  DECLARE @JahrMonatsbudget INT;
  DECLARE @MonatMonatsbudget INT;
  DECLARE @BgBudgetID INT;
  DECLARE @BgFinanzplanID_Copy INT;
  DECLARE @BgBudget_Copy INT;
  DECLARE @MonatsDifferenz INT;
  
  -- BgFinanzplan
  INSERT INTO dbo.BgFinanzplan (FaLeistungID, BgBewilligungStatusCode, WhHilfeTypCode, GeplantVon, GeplantBis)
  VALUES (@FaLeistungID, 1, @WhHilfeTypCode, @GeplantVon, @GeplantBis);
  
  SELECT @BgFinanzplanID    = SCOPE_IDENTITY(),
         @JahrMonatsbudget  = YEAR(@GeplantVon),
         @MonatMonatsbudget = MONTH(@GeplantVon);
  
  -- BgBudget (Masterbutget)
  INSERT INTO dbo.BgBudget (MasterBudget, BgBewilligungStatusCode, BgFinanzplanID, Jahr, Monat)
  VALUES (1, 1, @BgFinanzplanID, @JahrMonatsbudget, @MonatMonatsbudget);
  
  SET @BgBudgetID = SCOPE_IDENTITY();
  
  SELECT TOP 1
         @BgBudget_Copy       = BBG.BgBudgetID,
         @BgFinanzplanID_Copy = BBG.BgFinanzplanID,
         @MonatsDifferenz     = DATEDIFF(m, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1), @GeplantVon)
  FROM dbo.BgBudget             BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE SFP.FaLeistungID = @FaLeistungID 
    AND BBG.MasterBudget = 1
    AND SFP.BgFinanzplanID != @BgFinanzplanID
  ORDER BY Jahr DESC, Monat DESC;

  IF (@CopyOfLast = 1)
  BEGIN
    -- Personen
    INSERT INTO BgFinanzplan_BaPerson(BgFinanzplanID, BaPersonID, IstUnterstuetzt)
      SELECT @BgFinanzplanID, 
             BaPersonID, 
             IstUnterstuetzt
      FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
      WHERE BgFinanzplanID = @BgFinanzplanID_Copy;
    
    -- Copy BgPosition
    SELECT PK       = BgPositionID,
           Parent   = BgPositionID_Parent,
           KeyNew   = CONVERT(INT, NULL),
           BPO.BgPositionID_CopyOf,
           BPO.BgPositionsartID
    INTO #BgPosition
    FROM dbo.BgPosition              BPO WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.WhPositionsart  BPT ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudget_Copy 
      AND (BPO.BgKategorieCode NOT IN (1, 2) OR BPT.BgPositionsartID IS NOT NULL)
      AND (@GeplantVon BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, @GeplantVon) 
        OR @GeplantVon < BPO.DatumVon)
    
    DECLARE @FixFieldValue VARCHAR(100);
    SET @FixFieldValue = CONVERT(VARCHAR, @BgBudgetID);
    EXECUTE dbo.spXParentChildCopy '#BgPosition',
                                   'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                                   'BgBudgetID', @FixFieldValue,
                                   'BgPositionID_CopyOf, BgBewilligungStatusCode, OldID, ShBelegID'
    
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

    UPDATE BPO
    SET BgPositionID_CopyOf = NXT.KeyNew
    FROM dbo.BgPosition      BPO
      INNER JOIN #BgPosition ORI ON ORI.KeyNew = BPO.BgPositionID
      INNER JOIN #BgPosition NXT ON NXT.PK = ORI.BgPositionID_CopyOf
    WHERE BPO.BgBudgetID = @BgBudgetID 
      AND BPO.DatumVon IS NOT NULL;
    
    -- Copy BgAuszahlungPerson
    SELECT PK     = BgAuszahlungPersonID, 
           Parent = CONVERT(INT, NULL), 
           KeyNew = CONVERT(INT, NULL)
    INTO #BgAuszahlungPerson
    FROM BgAuszahlungPerson   BAP
      INNER  JOIN #BgPosition BPO ON BPO.PK = BAP.BgPositionID
      INNER  JOIN dbo.BgPositionsart POA_Old ON POA_Old.BgPositionsartID = BPO.BgPositionsartID
      LEFT   JOIN dbo.BgPositionsart POA_Nachfolge ON POA_Nachfolge.BgPositionsartID_CopyOf = POA_Old.BgPositionsartID
    WHERE POA_Old.Spezkonto = 1                   -- Wenn trotz POA_Old.Spezkonto = 1 ein BgAuszahlungPerson existiert -> kopieren  
      OR  ISNULL(POA_Nachfolge.Spezkonto, 0) = 0; -- Wenn POA_Nachfolge.Spezkonto = 0 oder leer dann sowieso
    
    EXECUTE dbo.spXParentChildCopy '#BgAuszahlungPerson',
                                   'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                                   'BgPositionID', '(SELECT KeyNew FROM #BgPosition WHERE PK = BgPositionID)';
    
    -- Copy BgAuszahlungPersonTermin
    INSERT INTO BgAuszahlungPersonTermin(BgAuszahlungPersonID, Datum)
      SELECT TMP.KeyNew, DateAdd(m, @MonatsDifferenz, BAT.Datum) -- Valuta
      FROM #BgAuszahlungPerson              TMP
        INNER JOIN BgAuszahlungPerson       BAP ON BAP.BgAuszahlungPersonID = TMP.PK
        INNER JOIN BgAuszahlungPersonTermin BAT ON BAT.BgAuszahlungPersonID = TMP.PK 
                                               AND BAP.BgAuszahlungsTerminCode = 4;
        
    DROP TABLE #BgAuszahlungPerson;
    DROP TABLE #BgPosition;
  END;
  
  IF (NOT EXISTS (SELECT TOP 1 1 
                  FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                  WHERE BgFinanzplanID = @BgFinanzplanID))
  BEGIN
    INSERT INTO BgFinanzplan_BaPerson(BgFinanzplanID, BaPersonID, IstUnterstuetzt)
      SELECT @BgFinanzplanID, 
             BaPersonID, 
             1
      FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
      WHERE FaLeistungID = @FaLeistungID;
  END;
  
  IF (@WhGrundbedarfTyp IS NULL)
  BEGIN
    SELECT @WhGrundbedarfTyp = POA.BgPositionsartCode
    FROM dbo.BgPosition             BPO WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID
      INNER JOIN dbo.XLOVCode       XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhGrundbedarfTyp' 
                                                        AND XLC.Code = POA.BgPositionsartCode
    WHERE BPO.BgBudgetID = @BgBudgetID;
  END;
  
  IF (@WhGrundbedarfTyp IS NULL)
  BEGIN
    SELECT TOP 1 @WhGrundbedarfTyp = Code
    FROM dbo.XLOVCode WITH (READUNCOMMITTED) 
    WHERE LOVName = 'WhGrundbedarfTyp'
    ORDER BY SortKey;
  END;
  
  UPDATE dbo.BgFinanzplan 
  SET WhGrundbedarfTypCode = @WhGrundbedarfTyp 
  WHERE BgFinanzplanID = @BgFinanzplanID;
  
  -- Falscher Grundbedarf
  DELETE BPO
  FROM BgPosition             BPO
    INNER JOIN WhPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID 
                                 AND BPA.BgGruppeCode = 3201
  WHERE BPO.BgBudgetID = @BgBudgetID 
    AND BPA.BgPositionsartCode != @WhGrundbedarfTyp 
    AND NOT (@WhGrundbedarfTyp = 32011 AND BPA.BgPositionsartCode IN (32012, 32013, 32014));
  
  -- Grundbedarf Neu
  IF (NOT EXISTS (SELECT TOP 1 1 
                  FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                  INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = POS.BgPositionsartID
                  WHERE POS.BgBudgetID = @BgBudgetID 
                    AND POA.BgPositionsartCode = @WhGrundbedarfTyp))
  BEGIN
    INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag, Buchungstext)
      SELECT TOP 1 
             @BgBudgetID, BPA.BgKategorieCode, BPA.BgPositionsartID, $-1.00, [Name]
      FROM dbo.BgPositionsart BPA WITH (READUNCOMMITTED)
        INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
      WHERE BgPositionsartCode = @WhGrundbedarfTyp AND
           ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
           ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1));
  END;
  
  IF (@WhGrundbedarfTyp = 32011)
  BEGIN
    -- Zuschlag zu Grundbedarf I
    IF (NOT EXISTS (SELECT TOP 1 1 
                    FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = POS.BgPositionsartID
                    WHERE POS.BgBudgetID = @BgBudgetID 
                      AND POA.BgPositionsartCode = 32012))
    BEGIN
      INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
        SELECT TOP 1 
               @BgBudgetID, BPA.BgKategorieCode, BPA.BgPositionsartID
        FROM dbo.BgPositionsart BPA WITH (READUNCOMMITTED)
          INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
        WHERE BgPositionsartCode = 32012 AND
             ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
             ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1));
    END;
    
    -- Grundbedarf 2
    IF (NOT EXISTS (SELECT TOP 1 1 
                    FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = POS.BgPositionsartID
                    WHERE POS.BgBudgetID = @BgBudgetID 
                      AND POA.BgPositionsartCode = 32013))
    BEGIN
      INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
        SELECT TOP 1 
               @BgBudgetID, BPA.BgKategorieCode, BPA.BgPositionsartID
        FROM dbo.BgPositionsart BPA WITH (READUNCOMMITTED)
          INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
        WHERE BgPositionsartCode = 32013 AND
             ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
             ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1));
    END;
  END;
  
  IF (NOT EXISTS (SELECT TOP 1 1
                  FROM dbo.BgPosition             BPO WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.WhPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
                  WHERE BPO.BgBudgetID = @BgBudgetID 
                    AND BPA.BgGruppeCode = 3206))
  BEGIN
    DECLARE @Miete MONEY;
    DECLARE @Nebenkosten MONEY;
    DECLARE @MieteAnteil MONEY;
    DECLARE @NebenkostenAnteil MONEY;
    
    SELECT @Miete             = NULL, 
           @Nebenkosten       = $0.00,
           @MieteAnteil       = NULL, 
           @NebenkostenAnteil = $0.00;
    
    -- Wohnkosten
    INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag, Reduktion, MaxBeitragSD, Buchungstext)
      SELECT TOP 1 
             @BgBudgetID, 
             2, 
             BPA.BgPositionsartID, 
             ISNULL(@Miete, $0.00), 
             ISNULL(@Miete - @MieteAnteil, $0.00), 
             ISNULL(@MieteAnteil, $0.00), 
             [Name]
      FROM dbo.WhPositionsart BPA
      INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
      WHERE BPA.BgGruppeCode = 3206 AND
         ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
         ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
      ORDER BY BPA.SortKey, BPA.BgPositionsartID;
    
    -- Wohnnebenkosten
    INSERT INTO dbo.BgPosition (BgPositionID_Parent, BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag, 
                                Reduktion, MaxBeitragSD, Buchungstext)
      SELECT TOP 1 
             SCOPE_IDENTITY(), 
             @BgBudgetID, 
             2, 
             BPA.BgPositionsartID, 
             ISNULL(@Nebenkosten, $0.00), 
             ISNULL(@Nebenkosten - @NebenkostenAnteil, $0.00), 
             ISNULL(@NebenkostenAnteil, $0.00), 
             [Name]
      FROM dbo.WhPositionsart BPA
      INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
      WHERE BPA.BgPositionsartCode = 32060 AND
         ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
         ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1));
  END;
  
  EXECUTE dbo.spWhFinanzplan_Update @BgFinanzplanID;
END;
GO