SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Bewilligen
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhFinanzplan_Bewilligen.sql $
  $Author: Rstahel $
  $Modtime: 19.08.10 11:47 $
  $Revision: 10 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhFinanzplan_Bewilligen.sql $
 * 
 * 7     19.08.10 17:16 Rstahel
 * #3978: Beim Bewilligen des Finanzplans (was z.B. auch bei Änderungen an
 * Finanzplan-Masken passiert), werden neu auch die Masterpositionen
 * terminiert und Folgepositionen erstellt, falls Positionsarten in der
 * Periode des Finanzplans terminiert wurden in der Zwischenzeit.
 * 
 * 6     17.08.10 15:13 Rstahel
 * #3978: Kommentar ergängt, so dass die Daten-Anomalie "DatumVon >
 * DatumBis" etwas klarer wird.
 * 
 * 5     23.02.10 9:34 Lgreulich
 * 
 * 4     23.02.10 7:51 Lgreulich
 * #5837 KVG konnte nicht erfasst werden, Korrektur bei Spezkonto!
 * 
 * 3     15.02.10 15:15 Ckaeser
 * #5038 
 * 
 * 2     25.06.09 8:47 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhFinanzplan_Bewilligen
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhFinanzplan_Bewilligen
 (@BgFinanzplanID  INT,
  @DatumVon        DATETIME,
  @BgPositionID    INT      = NULL)
AS BEGIN
  DECLARE @FaLeistungID           INT,
          @BgBudgetID             INT,
          @BaPersonID             INT,
          @BaZahlungswegID        INT,
          @BgAuszahlungID         INT,
          @StandardAuszahlungsart INT
          
  -- Falls nötig, werden zuerst noch Positionen terminiert im neuen Masterbudget
  EXEC spWhPositionsart_Masterbudget_Terminieren @BgFinanzplanID
  
  -- Diverse Werte eruieren        
  SELECT
    @FaLeistungID           = SFP.FaLeistungID,
    @BaPersonID             = FLE.BaPersonID,
    @BgBudgetID             = BBG.BgBudgetID,
    @StandardAuszahlungsart = CONVERT(INT, (SELECT ISNULL(dbo.fnXConfig('System\Sozialhilfe\KlientStandardZahlungart', GETDATE()), 101)))  -- 101 ist elektronische Auszahlung
  FROM dbo.BgFinanzplan        SFP WITH (READUNCOMMITTED) 
    INNER JOIN dbo.FaLeistung  FLE WITH (READUNCOMMITTED) ON FLE.FaLeistungId = SFP.FaLeistungID
    INNER JOIN dbo.BgBudget    BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                              AND BBG.MasterBudget = 1
  WHERE SFP.BgFinanzplanID = @BgFinanzplanID

  -- Terminiere die Vorgängerposition so, dass sie vor der Nachfolgerposition aufhört. 
  -- Falls beide Positionen zum gleichen Zeitpunkt beginnen, wird mit diesem Statement das DatumVon einen Tag nach dem DatumBis gesetzt (d.h. es ergibt sich eine negative Gültigkeitsdauer)
  -- Diese Daten-Anomalie (DatumVon > DatumBis) wird in den Finanzplan-Masken geprüft und ausgenutzt, um die nicht mehr gültigen Positionen herauszufiltern.
  UPDATE BPO
    SET DatumBis = IsNull(DateAdd(DAY, -1, BP2.DatumVon), BPO.DatumBis)
  FROM BgPosition          BPO
    LEFT  JOIN dbo.BgPosition  BP2 WITH (READUNCOMMITTED) ON BP2.BgBudgetID = @BgBudgetID AND BP2.BgPositionID_CopyOf = BPO.BgPositionID
  WHERE BPO.BgBudgetID = @BgBudgetID AND 
	(@BgPositionID IS NULL OR BP2.BgPositionID = @BgPositionID OR BP2.BgPositionID_Parent = @BgPositionID)

  -- UPDATE BgBewilligungStatusCode
  -- Entweder für das gesamte Budget oder für die Hauptposition mit allen Nebenpositionen.
  UPDATE BgPosition
    SET BgBewilligungStatusCode = 5 -- 5: Bewilligung erteilt
  WHERE 
    BgBudgetID = @BgBudgetID 
    AND (@BgPositionID IS NULL OR BgPositionID = @BgPositionID OR BgPositionID_Parent = @BgPositionID)


  -- Ausgabekonto erstellen, wenn das die Positionsart verlangt
  -- Wenn bereits ein Ausgabekonto für diese Positionsart und Person existiert, wird keines angelegt. 
  INSERT INTO BgSpezkonto 
  (
	  FaLeistungID, 
	  BgSpezkontoTypCode, 
	  NameSpezkonto, 
	  DatumVon, 
	  BgPositionsartID, 
	  BgKostenartID, 
	  BaPersonID, 
	  BaInstitutionID
  )
  SELECT DISTINCT 
	@FaLeistungID, -- FaLeistungID
	1,             -- BgSpezkontoTypCode (1: Ausgabekonto) 
	SUBSTRING(BPT.Name + IsNull(' (' + PRS.NameVorname + ')', ''),1,100), -- NameSpezkonto
	@DatumVon,     -- DatumVon
	BPT.BgPositionsartID, 
	BPT.BgKostenartID, 
	BPO.BaPersonID,
    CASE WHEN BPT.BgGruppeCode IN (3901, 3902, 3903)  -- 3901: SIL, 3902: Krankheits- und behinderunsbedingte Leistungen, 3903: Leistungen für Therapie- und Entzugsmassnahmen
           THEN BPO.BaInstitutionID 
           ELSE NULL 
    END -- Institutionid
  FROM dbo.vwBgPosition              BPO
      INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
      LEFT  JOIN dbo.vwPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
  WHERE 
     BPO.BgBudgetID = @BgBudgetID 
     AND (@BgPositionID IS NULL OR BPO.BgPositionID = @BgPositionID OR BPO.BgPositionID_Parent = @BgPositionID)
     AND BPT.Spezkonto = 1 
     AND (BPO.BetragRechnung > $0.00 OR (BPT.Masterbudget_EditMask & 0x4000 != 0) OR (BPT.Monatsbudget_EditMask & 0x4 != 0))
     AND NOT EXISTS (SELECT 1 
                     FROM dbo.BgSpezkonto WITH (READUNCOMMITTED) 
                     WHERE 
                       FaLeistungID = @FaLeistungID 
                       AND BgPositionsartID = BPT.BgPositionsartID 
                       AND @DatumVon BETWEEN DatumVon AND IsNull(DatumBis, @DatumVon)
                       AND IsNull(BaPersonID, 0) = IsNull(BPO.BaPersonID, 0)
                       AND (BPT.BgGruppeCode NOT IN (3901, 3902, 3903) OR IsNull(BaInstitutionID, 0) = IsNull(BPO.BaInstitutionID, 0))) 

  -- Spezialkonto auf der Position NULL setzen, wenn 
  -- kein passendes Spezialkonto existiert.
  UPDATE BPO
    SET BgSpezkontoID = NULL
  FROM BgPosition              BPO
    INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID AND BPT.BgKategorieCode = 2 -- BgKategorie2: Ausgaben
    INNER JOIN dbo.BgSpezkonto     SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
  WHERE 
    BPO.BgBudgetID = @BgBudgetID 
    AND (@BgPositionID IS NULL OR BPO.BgPositionID = @BgPositionID OR BPO.BgPositionID_Parent = @BgPositionID)
    AND (SSK.BgKostenartID <> BPT.BgKostenartID
         OR @DatumVon NOT BETWEEN SSK.DatumVon AND IsNull(SSK.DatumBis, @DatumVon)
         OR COALESCE(SSK.BgPositionsartID, BPO.BgPositionsartID)  <> BPO.BgPositionsartID
         OR COALESCE(SSK.BaPersonID, BPO.BaPersonID, 0)           <> IsNull(BPO.BaPersonID, 0)
         OR (BPT.BgGruppeCode IN (3901, 3902, 3903) AND IsNull(SSK.BaInstitutionID, 0) <> IsNull(BPO.BaInstitutionID, 0)))

  -- Spezialkono setzen
  UPDATE BPO
    SET BgSpezkontoID = SSK.BgSpezkontoID
  FROM BgPosition              BPO
    INNER JOIN dbo.vwBgPosition    vBP ON vBP.BgPositionID = BPO.BgPositionID
    INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN dbo.BgSpezkonto     SSK WITH (READUNCOMMITTED) ON SSK.FaLeistungID = @FaLeistungID AND SSK.BgPositionsartID = BPT.BgPositionsartID
                                  AND @DatumVon BETWEEN SSK.DatumVon AND IsNull(SSK.DatumBis, @DatumVon)
                                  AND IsNull(SSK.BaPersonID, 0) = IsNull(BPO.BaPersonID, 0)
                                  AND (BPT.BgGruppeCode NOT IN (3901, 3902, 3903) OR IsNull(SSK.BaInstitutionID, 0) = IsNull(BPO.BaInstitutionID, 0))
  WHERE 
    BPO.BgBudgetID = @BgBudgetID 
    AND (@BgPositionID IS NULL OR BPO.BgPositionID = @BgPositionID OR BPO.BgPositionID_Parent = @BgPositionID)
    AND BPT.Spezkonto = 1 
    AND (vBP.BetragRechnung > $0.00 OR (BPT.Masterbudget_EditMask & 0x4000 != 0) OR (BPT.Monatsbudget_EditMask & 0x4 != 0))
    AND BPO.BgSpezkontoID IS NULL 
    AND BPO.BgPositionID NOT IN (SELECT BgPositionID FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) WHERE BgPositionID IS NOT NULL)


  -- Aktuellen Zahlungsweg eruieren.
  -- Wir nehmen den ersten Treffer.
  SELECT TOP 1 @BaZahlungswegID = BaZahlungswegID
  FROM dbo.BaZahlungsweg WITH (READUNCOMMITTED) 
  WHERE BaPersonID = @BaPersonID
    AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
  ORDER BY BaZahlungswegID DESC

  DECLARE @BgAuszahlungPerson_BgPositionID INT,
          @BgPositionID_CopyOf             INT

  -- Cursor definieren für alle Positionen im Masterbudget,
  -- welche kein Spezialkonto haben und noch keinen
  -- Eintrag in BgAuszahlungPerson (nur für Ausgaben) haben,
  -- einen Eintrag in BgAuszahlungPerson anzulegen.
  -- Das machen wir nur, wenn die Positionsart kein Spezialkonto verlangt.
  DECLARE cBgPosition CURSOR FAST_FORWARD FOR
    SELECT 
      BPO.BgPositionID, 
      BPO.BgPositionID_CopyOf
    FROM dbo.BgPosition  BPO WITH (READUNCOMMITTED) 
	  INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID 
    WHERE 
      BgBudgetID = @BgBudgetID 
      AND (@BgPositionID IS NULL OR BPO.BgPositionID = @BgPositionID OR BPO.BgPositionID_Parent = @BgPositionID)
      AND BPO.BgKategorieCode = 2  -- 2: Ausgaben
      AND BPT.Spezkonto = 0        -- So ein ding braucht es nicht, wenn Auszahlung auf Spezialkonto gehen soll.
      AND BPO.BgSpezkontoID IS NULL 
      AND BPO.BgPositionID NOT IN (SELECT BgPositionID FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) WHERE BgPositionID IS NOT NULL)

  -- Iteration über Positionen im Masterbudget, um BgAuszalungPerson und BgAuszahlungPersonTermin anzulegen.
  OPEN cBgPosition
  WHILE (1 = 1) BEGIN
    
    FETCH NEXT FROM cBgPosition 
    INTO @BgAuszahlungPerson_BgPositionID, 
         @BgPositionID_CopyOf
    
    IF @@FETCH_STATUS < 0 BREAK

    -- Original (Vorgänger/CopyOf) hat ein  BgAuszahlungPerson, in desem Falle kopieren wir die Werte vom Original.
    IF EXISTS (SELECT * FROM BgAuszahlungPerson WHERE BgPositionID = @BgPositionID_CopyOf) BEGIN
    
      -- BgAuszahlungPerson
      SELECT BgAuszahlungPersonID AS PK, 
             CONVERT(INT, NULL)   AS Parent, 
             CONVERT(INT, NULL)   AS KeyNew
      INTO #BgAuszahlungPersonA
      FROM BgAuszahlungPerson BAP
      WHERE BgPositionID = @BgPositionID_CopyOf

      -- BgAuszahlungPerson Eintrag aus CopyOf (Original) kopieren.
      EXECUTE spXParentChildCopy '#BgAuszahlungPersonA', -- TempTablename
                                 'BgAuszahlungPerson',   -- Tablename
                                 'BgAuszahlungPersonID', -- Primary-KeyName
                                 NULL,                   -- Parent-KeyName
                                 'BgPositionID',         -- FixColumnNames
                                 @BgAuszahlungPerson_BgPositionID -- FixColumnValues

      -- BgAuszahlungPersonTermin
      INSERT INTO BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
        SELECT TMP.KeyNew, -- BgAuszahlungPersonID
               TRM.Datum
        FROM #BgAuszahlungPersonA              TMP
          INNER JOIN BgAuszahlungPersonTermin  TRM ON TRM.BgAuszahlungPersonID = TMP.PK

      DROP TABLE #BgAuszahlungPersonA
      
    -- Original (Vorgänger/CopyOf) hat kein BgAuszahlungPerson  
    END ELSE BEGIN
      INSERT INTO BgAuszahlungPerson 
      (
	    BgPositionID, 
		KbAuszahlungsArtCode, 
		BaZahlungswegID, 
		BgAuszahlungsTerminCode, 
		MitteilungZeile1, 
		MitteilungZeile2, 
		MitteilungZeile3
       )
       SELECT 
          @BgAuszahlungPerson_BgPositionID, -- BgPositionID
          KbAuszahlungsArtCode    = CASE WHEN BZW.BaZahlungswegID IS NULL THEN 103 -- 103: Cash
                                         ELSE @StandardAuszahlungsart END, --KbAuszahlungsArtCode
          BZW.BaZahlungswegID, -- Zahlungswegid
          BgAuszahlungsTerminCode = 1,  -- 1x pro Monat
          MitteilungZeile1        = CASE WHEN BZW.BaZahlungswegID IS NULL OR BZW.EinzahlungsscheinCode = 2 THEN LEFT(PRS.VornameName, 35) END,
          MitteilungZeile2        = CASE WHEN BZW.BaZahlungswegID IS NULL THEN LEFT(PRS.WohnsitzStrasseHausNr, 35) END,
          MitteilungZeile3        = CASE WHEN BZW.BaZahlungswegID IS NULL THEN LEFT(PRS.WohnsitzPLZOrt, 35) END
       FROM vwPerson               PRS
          LEFT  JOIN BaZahlungsweg  BZW ON BZW.BaZahlungswegID = @BaZahlungswegID
       WHERE PRS.BaPersonID = @BaPersonID
    END
  END

  DEALLOCATE cBgPosition

  -- Graue Monatsbudget aktualisieren  
  UPDATE BPO
  SET 
      BgPositionID_CopyOf   = BP2.BgPositionID,
      Betrag                = BP2.Betrag,
      Reduktion             = BP2.Reduktion,
      Abzug                 = BP2.Abzug,
      MaxBeitragSD          = BP2.MaxBeitragSD,
      VerwaltungSD          = BP2.VerwaltungSD,
      BgPositionsartId      = BP2.BgPositionsartId,
      Buchungstext          = BP2.Buchungstext,      
      BgSpezkontoID         = CASE WHEN (BPO.BgSpezkontoID IS NOT NULL OR BPO.Betrag = 0) THEN BP2.BgSpezkontoID END, -- Warum wird das nur 
      BaInstitutionID       = BP2.BaInstitutionID
  FROM dbo.BgBudget            BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgPosition  BP2 WITH (READUNCOMMITTED) ON BP2.BgBudgetID = @BgBudgetID 
                                                             AND (BP2.BgPositionID = @BgPositionID 
                                                                  OR BP2.BgPositionID_Parent = @BgPositionID)
    INNER JOIN dbo.BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgPositionID_CopyOf IN (BP2.BgPositionID, BP2.BgPositionID_CopyOf)
  WHERE 
    BBG.BgFinanzplanID = @BgFinanzplanID 
    AND BBG.MasterBudget = 0 
    AND BBG.BgBewilligungStatusCode < 5
    AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) BETWEEN BP2.DatumVon AND IsNull(BP2.DatumBis, '99991231')


  -- Positionen aus grauen Monatsbudgets löschen
  -- Wenn diese Positionen über den Zeitraum der Masterposition hinausragen.  
  DELETE BPO
  FROM BgBudget            BBG
    INNER JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID
  WHERE 
    BBG.BgFinanzplanID = @BgFinanzplanID 
    AND BBG.MasterBudget = 0 
    AND BBG.BgBewilligungStatusCode < 5
    AND EXISTS (SELECT *
                FROM BgPosition
                WHERE 
                  BgBudgetID = @BgBudgetID 
                  AND @BgPositionID IN (BgPositionID, BgPositionID_Parent)
                  AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) > IsNull(DatumBis, '99991231')
                  AND BPO.BgPositionID_CopyOf IN (BgPositionID, BgPositionID_CopyOf)
                )


  -- graue/angefragte Monatsbudget Anpassen
  DECLARE @MonatsbudgetID          INT,
          @DateMonatsbudget        DATETIME,
          @JahrMonatsbudget        INT,
          @MonatMonatsbudget       INT,
          @MonatsDifferenz         INT,
          @KbZahlungslaufValutaID  INT

  -- Cursor, um in Monatsbudget noch nicht existierende Positionen (und BgAuszahlungPerson und BgAuszahlungPersonTermin anzulegen).
  DECLARE cBgBudget CURSOR FAST_FORWARD FOR
    SELECT 
      BBG.BgBudgetID,
      dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1), 
      BBG.Jahr, 
      BBG.Monat,
      DateDiff(m, SFP.DatumVon, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)), --Monatsdifferenz (INT)
      KbZahlungslaufValutaID
    FROM dbo.BgBudget                      BBG WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.KbZahlungslaufValuta  KZV WITH (READUNCOMMITTED) ON KZV.Jahr = BBG.Jahr AND KZV.Monat = BBG.Monat
      INNER JOIN dbo.BgPosition            BP2 WITH (READUNCOMMITTED) ON BP2.BgBudgetID = @BgBudgetID AND BP2.BgPositionID = @BgPositionID
      LEFT  JOIN dbo.BgFinanzplan          SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
    WHERE 
      BBG.BgFinanzplanID = @BgFinanzplanID 
      AND BBG.MasterBudget = 0 
      AND BBG.BgBewilligungStatusCode < 5
      AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) BETWEEN BP2.DatumVon AND IsNull(BP2.DatumBis, '99991231')

  -- Über anzupassende graue Monatsbudget iterieren
  OPEN cBgBudget
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cBgBudget INTO @MonatsbudgetID, @DateMonatsbudget, @JahrMonatsbudget, @MonatMonatsbudget, @MonatsDifferenz, @KbZahlungslaufValutaID
    IF @@FETCH_STATUS < 0 BREAK

    -- BgPositionId eruieren, wenn diese noch nicht im Monatsbudget existiert.
    SELECT 
      BP2.BgPositionID AS PK, 
      BP2.BgPositionID_Parent AS Parent, 
      CONVERT(INT, NULL) AS KeyNew
    INTO #BgPosition
    FROM BgBudget            BBG
      INNER JOIN BgPosition  BP2 ON BP2.BgBudgetID = @BgBudgetID AND (BP2.BgPositionID = @BgPositionID OR BP2.BgPositionID_Parent = @BgPositionID)
      LEFT  JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgPositionID_CopyOf = BP2.BgPositionID
    WHERE 
      BBG.BgBudgetID = @MonatsbudgetID 
      AND BPO.BgPositionID IS NULL

    -- BgPosition anlegen (da sie ja noch nicht im Monatsbudget existiert).
    DECLARE @FixFieldValue varchar(200)
    SET @FixFieldValue = 'BgPositionID, '  -- BgPositionID_CopyOf
                         + CONVERT(VARCHAR, @MonatsbudgetID) -- BgBudgetID
                         + ', DateAdd(m, '  + CONVERT(VARCHAR, @MonatsDifferenz) + ', FaelligAm)' -- FaelligAm
                         + ', dbo.fnDateSerial(' + CONVERT(varchar, @JahrMonatsbudget) + ', ' + CONVERT(varchar, @MonatMonatsbudget) + ', 1)' --VerwPeriodeVon
                         + ', dbo.fnLastDayOf(dbo.fnDateSerial(' + CONVERT(varchar, @JahrMonatsbudget) + ', ' + CONVERT(varchar, @MonatMonatsbudget) + ', 1))' -- VerwPeriodeBis

    EXECUTE spXParentChildCopy '#BgPosition', -- TempTableName
                               'BgPosition',  -- TableName
                               'BgPositionID',        -- PrimaryKeyName
                               'BgPositionID_Parent', -- ParentKeyName
                               'BgPositionID_CopyOf, BgBudgetID, FaelligAm, VerwPeriodeVon, VerwPeriodeBis',  --FixColumnNames
                               @FixFieldValue, -- FixColumnValues
                               'BgBewilligungStatusCode, Bemerkung, DatumVon, DatumBis, OldID, ShBelegID' --DBDefaultNames

    -- BgAuszahlungPerson kopieren
    SELECT 
      BgAuszahlungPersonID AS PK, 
      CONVERT(int, NULL) AS Parent, 
      CONVERT(int, NULL) AS KeyNew
    INTO #BgAuszahlungPerson
    FROM BgAuszahlungPerson    BAP
      INNER  JOIN #BgPosition  BPO ON BPO.PK = BAP.BgPositionID

    EXECUTE spXParentChildCopy '#BgAuszahlungPerson',  -- TempTableName
                               'BgAuszahlungPerson',   -- TableName
                               'BgAuszahlungPersonID', -- PrimaryKeyName
                               NULL,  -- ParentKeyName
                               'BgPositionID',   --FixColumnNames
                               '(SELECT KeyNew FROM #BgPosition WHERE PK = BgPositionID)' --DBDefaultNames

    -- BgAuszahlungPersonTermin kopieren
    INSERT INTO BgAuszahlungPersonTermin(BgAuszahlungPersonID, Datum)
      SELECT TMP.KeyNew,
        CASE
          WHEN BAP.BgAuszahlungsTerminCode = 4 THEN DateAdd(m, @MonatsDifferenz, BAT.Datum) -- Valuta
          ELSE TRM.Datum
        END
      FROM #BgAuszahlungPerson               TMP
        INNER JOIN BgAuszahlungPerson        BAP ON BAP.BgAuszahlungPersonID = TMP.PK
        LEFT  JOIN BgAuszahlungPersonTermin  BAT ON BAT.BgAuszahlungPersonID = TMP.PK AND BAP.BgAuszahlungsTerminCode = 4
        LEFT  JOIN dbo.fnKbAuszahlTermine(@JahrMonatsbudget, @MonatMonatsbudget)
                                             TRM ON TRM.BgAuszahlungsTerminCode = BAP.BgAuszahlungsTerminCode
                                                AND (BAP.BgAuszahlungsTerminCode <> 6 OR BAP.BgWochentagCodes LIKE '%' + CONVERT(varchar, TRM.BgWochentagCode) + '%')
      WHERE BAT.BgAuszahlungPersonID IS NOT NULL OR TRM.Datum IS NOT NULL

    DROP TABLE #BgAuszahlungPerson
    DROP TABLE #BgPosition
  END
  DEALLOCATE cBgBudget


  -- Spezialkonto (Abzahlung, Vorabzug)
  DECLARE @BgSpezkontoID  int

  DECLARE cBgSpezkonto CURSOR FAST_FORWARD FOR
    SELECT BgSpezkontoID
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) ON SSK.FaLeistungID = SFP.FaLeistungID
    WHERE 
      SFP.BgFinanzplanID = @BgFinanzplanID
      AND (SSK.DatumBis IS NULL OR SSK.DatumBis >= DATEADD(MONTH, -6, SFP.DatumVon)) -- #5837 Ältere Spezkonti nicht berücksichtigen!!!
    
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