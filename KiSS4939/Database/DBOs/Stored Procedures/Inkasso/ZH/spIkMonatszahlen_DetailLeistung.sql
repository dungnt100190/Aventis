SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_DetailLeistung
GO
/*===============================================================================================
  $Revision: 6 $
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
CREATE PROCEDURE dbo.spIkMonatszahlen_DetailLeistung
  -- ID Rechtstitel :
  @LeistungID INT = 0,
  -- Jahr:
  @ParamBisJahr INT = 0,
  -- Monat:
  @ParamBisMonat INT = 0
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON


  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF @LeistungID IS NULL OR @LeistungID = 0 BEGIN
    RETURN -1
  END
  IF @ParamBisJahr IS NULL OR @ParamBisJahr < 1900 OR @ParamBisJahr > 9999 BEGIN
    RETURN -2
  END
  IF @ParamBisMonat IS NULL OR @ParamBisMonat < 1 OR @ParamBisMonat > 12 BEGIN
    RETURN -3
  END


  -- ---------------------------------------------------
  -- Start-Datum und EndDatum holen:
  -- ---------------------------------------------------
  DECLARE @DateBeg DATETIME
  SET @DateBeg = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1)
  -- Ende-Datum
  DECLARE @DateEnd DATETIME
  DECLARE @DaysInMonth INT
  SET @DaysInMonth = dbo.fnDaysInMonthOf(@DateBeg)
  SET @DateEnd = dbo.fnDateSerial(@ParamBisJahr,  @ParamBisMonat, @DaysInMonth)


  -- ---------------------------------------------------
  -- Angaben von Leistung holen
  -- ---------------------------------------------------
  DECLARE
    @Rundung INT
  SET @Rundung = 1  -- Kaufmännisch runden auf  CHF 1.00


  -- ---------------------------------------------------
  -- temp Tabelle erstellen:
  -- ---------------------------------------------------
  DECLARE @TmpValues TABLE  (
    IkForderungID INT NULL,
	ActDate DATETIME NULL,
    BaPersonID INT NULL,
    Days INT NULL,
	TotalAliment MONEY NULL,
	VerwPeriodeVon DATETIME NULL,
	VerwPeriodeBis DATETIME NULL
  )


  -- ---------------------------------------------------
  -- Berechnung erstellen, 
  -- ---------------------------------------------------
  -- Daten in Variabeln setzen
  DECLARE
    @DateTmpFrom DATETIME,
    @DateTmpTo DATETIME,
    @DateTmpMax DATETIME,
    @Betrag MONEY,
    @Total MONEY,
    @LoopCountDays INT,
    @IkForderungID INT,
    @IkPositionID INT,
    @MonatIstErledigt BIT,
    @IkForderungPeriodischCode INT,
    @LineCounts INT,
    @FaProzessCode INT,
    @SplittingCode INT,
    @VerwPeriodeVon DATETIME,
    @VerwPeriodeBis DATETIME,
    @VerwPerVon DATETIME,
    @VerwPerBis DATETIME,
    @VerwPerVon_Max DATETIME,
    @VerwPerBis_Max DATETIME,
    @Day INT,
    @HatStornierteBuchungen BIT
  SET @LineCounts = 0


  -- --------------------------------------------------
  -- Alle Positionen von gelöschten Forderungen löschen
  -- --------------------------------------------------
  DELETE P FROM dbo.IkPosition P
  WHERE P.FaLeistungID = @LeistungID
    AND P.IkRechtstitelID IS NULL
    AND P.Einmalig = 0
    AND NOT EXISTS (
      SELECT Q.IkPositionID FROM dbo.IkForderungPosition Q WITH(READUNCOMMITTED)
      WHERE Q.IkPositionID = P.IkPositionID
    )
    AND NOT EXISTS (
      SELECT B.KbBuchungID FROM dbo.KbBuchung B WITH(READUNCOMMITTED)
      WHERE B.IkPositionID = P.IkPositionID
    )

  -- Stornierte Buchungen suchen
  -- ---------------------------
  SET @HatStornierteBuchungen = CASE WHEN EXISTS(
    SELECT TOP 1 P.IkPositionID FROM dbo.IkPosition P WITH(READUNCOMMITTED)
    LEFT JOIN dbo.KbBuchung B WITH(READUNCOMMITTED) ON P.IkPositionID = B.IkPositionID
    WHERE P.FaLeistungID = @LeistungID
      AND P.IkRechtstitelID IS NULL
      AND P.Jahr = @ParamBisJahr
      AND P.Monat = @ParamBisMonat
      AND B.KbBuchungStatusCode = 8 -- storniert
  ) THEN 1 ELSE 0 END

  -- -----------------------------
  -- Alle Positionen neu berechnen
  -- -----------------------------
  DECLARE crsForderungTyp CURSOR FAST_FORWARD FOR
    SELECT DISTINCT F.IkForderungPeriodischCode, L.FaProzessCode, ISNULL(KA.BgSplittingArtCode, 1)
    FROM dbo.IkForderung F WITH(READUNCOMMITTED)
    LEFT JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = F.FaLeistungID
    LEFT JOIN dbo.XLOVCode X WITH(READUNCOMMITTED) ON X.LOVName = 'IkForderungPeriodisch' AND X.Code = F.IkForderungPeriodischCode
    LEFT JOIN dbo.BgKostenArt KA WITH(READUNCOMMITTED) ON CONVERT(VARCHAR, KA.BgKostenArtID) = X.Value2
    WHERE F.FaLeistungID = @LeistungID
  OPEN crsForderungTyp

  WHILE 1=1 BEGIN
    FETCH NEXT FROM crsForderungTyp INTO @IkForderungPeriodischCode, @FaProzessCode, @SplittingCode
    IF @@FETCH_STATUS != 0 BREAK

    -- Alle 
    -- ----
    DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
      SELECT
        F.IkForderungID,
        CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
        F.DatumGueltigBis,
        F.Betrag,
        F.VerwPeriodeVon, F.VerwPeriodeBis
      FROM dbo.IkForderung F WITH(READUNCOMMITTED)
      WHERE F.FaLeistungID = @LeistungID
        --AND F.Aktiv = 1
        AND F.IkForderungPeriodischCode = @IkForderungPeriodischCode
        AND F.DatumAnpassenAb < @DateEnd
      ORDER BY F.DatumAnpassenAb DESC, F.IkForderungID DESC
    OPEN CursorForderungen

    SET @DateTmpTo = @DateEnd
    WHILE 1=1 BEGIN
      FETCH NEXT FROM CursorForderungen INTO
        @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, @VerwPeriodeVon, @VerwPeriodeBis
      IF @@FETCH_STATUS != 0 BREAK
      IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
      IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
      SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
      IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
        INSERT INTO @TmpValues
          (IkForderungID, ActDate, Days, TotalAliment, VerwPeriodeVon, VerwPeriodeBis)
          VALUES (@IkForderungID, @DateTmpFrom, @LoopCountDays, @Betrag, @VerwPeriodeVon, @VerwPeriodeBis)
      END
      SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom)
      IF (@DateTmpTo < @DateBeg) BREAK
    END
    CLOSE CursorForderungen
    DEALLOCATE CursorForderungen

    -- Jetzt summieren und alles speichern
    -- -----------------------------------
    -- Summen holen:
    SELECT TOP 1
      @Total = dbo.fnIkAlimenteRunden(@Rundung, ISNULL(SUM(tmp.TotalAliment*Days)/@DaysInMonth, 0)),
      @VerwPerVon_Max = MAX(tmp.VerwPeriodeVon),
      @VerwPerBis_Max = MAX(tmp.VerwPeriodeBis)
    FROM @TmpValues tmp

    SET @VerwPerVon = NULL
    SET @VerwPerBis = NULL
    IF @FaProzessCode BETWEEN 300 AND 399 BEGIN
      IF @SplittingCode = 1 BEGIN
        -- Taggenau :
        -- ----------
        SET @Day = ISNULL(DAY(@VerwPerVon_Max), 1)
        IF @Day > @DaysInMonth SET @Day = @DaysInMonth
        SET @VerwPerVon = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, @Day)

        SET @Day = ISNULL(DAY(@VerwPerBis_Max), @DaysInMonth)
        IF @Day > @DaysInMonth SET @Day = @DaysInMonth
        SET @VerwPerBis = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, @Day)

        IF @VerwPerVon > @VerwPerBis SET @VerwPerBis = @VerwPerVon
      END ELSE
      IF @SplittingCode = 2 BEGIN
        -- Monat :
        -- -------
        SET @VerwPerVon = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1)
        SET @VerwPerBis = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, @DaysInMonth)
      END ELSE
      IF @SplittingCode = 3 BEGIN
        -- Valuta :
        -- -------
        SET @VerwPerVon = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1)
      END ELSE
      IF @SplittingCode = 4 BEGIN
        -- Entscheid :
        -- ----------
        SET @Day = ISNULL(DAY(@VerwPerVon_Max), 1)
        IF @Day > @DaysInMonth SET @Day = @DaysInMonth
        SET @VerwPerVon = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, @Day)
      END
    END

    -- kontrollieren, ob der Monat nicht bereits erledigt ist
    SET @IkPositionID = NULL
    SET @MonatIstErledigt = 0
    SELECT TOP 1
      @IkPositionID = P.IkPositionID,
      @MonatIstErledigt = CONVERT(BIT, CASE WHEN EXISTS(
        SELECT TOP 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)
        WHERE BUC.IkPositionID = P.IkPositionID
          AND BUC.KbBuchungStatusCode != 8
      ) THEN 1 ELSE 0 END)
    FROM dbo.IkPosition P WITH(READUNCOMMITTED)
    WHERE P.FaLeistungID = @LeistungID
      AND P.Monat = @ParamBisMonat
      AND P.Jahr = @ParamBisJahr
      AND P.Einmalig = 0
      AND P.IkForderungEinmaligCode = @IkForderungPeriodischCode

    IF (@MonatIstErledigt = 0)
    BEGIN
      -- -----------------------------
      -- Monat ist noch nicht erledigt  
      -- -----------------------------
      IF (@Total = 0 OR @Total IS NULL) AND @HatStornierteBuchungen = 0
      BEGIN
        -- IkPosition löschen, wenn Betrag 0
        DELETE dbo.IkPosition
        WHERE IkPositionID = @IkPositionID
      END ELSE
      BEGIN
        -- Updaten oder neu einfügen

        -- ---------------------------------------------------
        -- Summen speichern:
        -- ---------------------------------------------------
        IF NOT @IkPositionID IS NULL
        BEGIN
          -- Zeile updaten
          SET @LineCounts = @LineCounts + 1
          UPDATE dbo.IkPosition SET
            IkForderungEinmaligCode = @IkForderungPeriodischCode,
            TotalAliment = @Total,
            TotalAlimentSoll = @Total,
            VerwPeriodeVon = @VerwPerVon,
            VerwPeriodeBis = @VerwPerBis
          WHERE IkPositionID = @IkPositionID
        END ELSE
        BEGIN
          -- Neue Zeile einfügen
          SET @LineCounts = @LineCounts + 1
          INSERT INTO dbo.IkPosition (
            FaLeistungID, Einmalig, IkForderungEinmaligCode,
            Datum, Monat, Jahr,
            TotalAliment, TotalAlimentSoll,
            VerwPeriodeVon, VerwPeriodeBis
          ) VALUES (
            @LeistungID, 0, @IkForderungPeriodischCode,
            dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1),
            @ParamBisMonat, @ParamBisJahr,
            @Total, @Total,
            @VerwPerVon, @VerwPerBis
          )
          SET @IkPositionID = SCOPE_IDENTITY()
        END
      END
    END ELSE BEGIN
      -- ------------------
      -- Wenn der Monat bereits erledigt ist, dann sollen nur die Soll-Werte korrigiert werden
      -- Monat ist erledigt  
      -- Zeile updaten
      -- -------------------------------------------------------------------------------------
      SET @LineCounts = @LineCounts + 1
      UPDATE dbo.IkPosition SET
        TotalAlimentSoll = @Total
      WHERE IkPositionID = @IkPositionID
    END

    -- Alte n:m-Beziehung löschen:
    DELETE dbo.IkForderungPosition
    WHERE IkPositionID = @IkPositionID
      AND NOT IkForderungID IN (
        SELECT DISTINCT IkForderungID FROM @TmpValues
        WHERE IkForderungID IS NOT NULL
      )

    -- Jetzt noch n:m-Beziehung füllen:
    DECLARE crsFordPos CURSOR FAST_FORWARD FOR
      SELECT DISTINCT IkForderungID FROM @TmpValues
      WHERE IkForderungID IS NOT NULL --AND BaPersonID = @PersonID
    OPEN crsFordPos
    WHILE 1=1 BEGIN
      FETCH NEXT FROM crsFordPos INTO @IkForderungID
      IF @@FETCH_STATUS <> 0 BREAK
      -- neue einfügen
      IF NOT EXISTS(
        SELECT IkForderungID FROM dbo.IkForderungPosition WITH(READUNCOMMITTED)
        WHERE IkForderungID = @IkForderungID AND IkPositionID = @IkPositionID)
      BEGIN
        INSERT INTO dbo.IkForderungPosition (IkForderungID, IkPositionID)
          VALUES (@IkForderungID, @IkPositionID)
      END
    END
    CLOSE crsFordPos
    DEALLOCATE crsFordPos


    -- Vorbereiten für nächsten Typ
    -- -----------------------------------
    DELETE @TmpValues
  END
  CLOSE crsForderungTyp
  DEALLOCATE crsForderungTyp

  -- ---------------------------------------------------
  -- Alles löschen, falls alte Typen vorhanden
  -- ---------------------------------------------------
/*
  DELETE P FROM IkPosition P
  WHERE P.FaLeistungID = @LeistungID
    AND P.Jahr = @ParamBisJahr
    AND P.Monat = @ParamBisMonat
    AND P.Einmalig = 0
    AND P.ErledigterMonat = 0
    AND NOT EXISTS(
      SELECT Q.IkForderungID FROM IkForderungPosition Q
      LEFT JOIN IkForderung F ON F.IkForderungID = Q.IkForderungID
      WHERE Q.IkPositionID = P.IkPositionID
        AND F.IkForderungPeriodischCode = P.IkForderungEinmaligCode
    )
*/


-- NUR FUER TESTS:
--SELECT V.* FROM @TmpValues V where BaPersonID =  205496


  -- ---------------------------------------------------
  -- temporäre Tabellen löschen:
  -- ---------------------------------------------------
  --DROP TABLE #TmpDates
  --DROP TABLE @TmpValues

  -- NUR FUER TESTS:
  --SELECT V.* FROM IkPosition V
  --WHERE IkRechtstitelID = @RechtstitelID AND Jahr = @Jahr AND Monat = @Monat

  -- Resultate zurückliefern
  --SELECT 0 AS HasErrors, @HasErrorMaxBetrag AS HasErrorMaxBetrag, @LineCounts AS LineCounts
  RETURN @LineCounts

END


GO