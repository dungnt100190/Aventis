SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_Detail;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spIkMonatszahlen_Detail
  -- Leistung
  @LeistungID INT,
  -- Rechtstitel
  @RechtstitelID INT,
  -- Jahr:
  @ParamBisJahr INT = 0,
  -- Schlüssel Anspruchsberechnung:
  @ParamBisMonat INT = 0
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON


  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF (@RechtstitelID IS NULL OR @RechtstitelID = 0) AND (@LeistungID IS NULL OR @LeistungID = 0) BEGIN
    SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @RechtstitelID oder @LeistungID ist ungültig.' AS ErrorText
    RETURN -1
  END
  IF @ParamBisJahr IS NULL OR @ParamBisJahr < 1900 OR @ParamBisJahr > 9999 BEGIN
    SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @Jahr ist ungültig.' AS ErrorText
    RETURN -1
  END
  IF @ParamBisMonat IS NULL OR @ParamBisMonat < 1 OR @ParamBisMonat > 12 BEGIN
    SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @Monat ist ungültig.' AS ErrorText
    RETURN -1
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
  -- Vormonat holen:
  -- ---------------------------------------------------
  DECLARE @JahrPrevious INT
  DECLARE @MonatPrevious INT
  SET @JahrPrevious = @ParamBisJahr
  SET @MonatPrevious = @ParamBisMonat - 1
  IF @MonatPrevious<1 BEGIN
    SET @MonatPrevious = 12
    SET @JahrPrevious = @JahrPrevious - 1
  END

  -- ---------------------------------------------------
  -- Angaben von Rechsttitel holen
  -- ---------------------------------------------------
  --DECLARE @RechtstitelID INT
  DECLARE
    @Rundung INT,
    @ProzessCode INT,
    @IndexStandBeiBerechnungRT MONEY,
    @IndexStandVom DATETIME

  IF @LeistungID IS NULL BEGIN
    -- Daten aus Rechtstitel
    SELECT
      @ProzessCode = L.FaProzessCode,
      @Rundung = Q.IkIndexRundenCode,
      @IndexStandBeiBerechnungRT = Q.IndexStandPunkte,
      @IndexStandVom = Q.IndexStandVom
    FROM dbo.IkRechtstitel Q WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.FaLeistung L WITH (READUNCOMMITTED) ON L.FaLeistungID = Q.FaLeistungID
    WHERE Q.IkRechtstitelID = @RechtstitelID
  END ELSE BEGIN
    -- Daten aus Leistung
    SET @IndexStandBeiBerechnungRT = NULL
    SET @IndexStandVom = NULL
    SELECT
      @ProzessCode = L.FaProzessCode
    FROM dbo.FaLeistung L WITH (READUNCOMMITTED) 
    WHERE L.FaLeistungID = @RechtstitelID
  END 
  IF @Rundung IS NULL SET @Rundung = 7 --! BSS Standardmässig soll Kaufmännisch auf 5 Rp. gerundet werden!


  -- ---------------------------------------------------
  -- temp Tabelle erstellen:
  -- ---------------------------------------------------
  DECLARE @TmpValues TABLE (
    IkForderungID INT NULL,
    ActDate DATETIME NULL,
    BaPersonID INT NULL,
    TotalAliment MONEY NULL,
    BetragALBV MONEY NULL,
    BetragKiZulage MONEY NULL,
    BetragALBVRaten MONEY NULL,
    Punkte MONEY NULL,
    PunkteDatum DATETIME NULL,
    ALBVBerechtigt BIT NOT NULL DEFAULT(0),
    Unterstuetzungsfall BIT NOT NULL DEFAULT(0),
    IkForderungCode INT,
    Bemerkung varchar(500)
  )
  DECLARE 
    @PersonFill INT,
    @DateTmpFrom DATETIME,
    @DateTmpTo DATETIME,
    @DateTmpMax DATETIME,
    @Betrag MONEY,
    @IndexStand MONEY,
    @IndexStandDatum DATETIME, 
    @Bemerkung VARCHAR(500),
    @LoopCountDays INT,
    @ALBVMaxBetrag MONEY,
    @BetragALBV MONEY,
    @ALBVBerechtigt BIT,
    @Unterstuetzungsfall BIT,
    @IkForderungPeriodischCode INT,
    @IkForderungID INT

  SELECT @ALBVMaxBetrag = CONVERT(MONEY, dbo.fnXConfig('System\Inkasso\ALBVMaximalBetrag', @DateBeg))


  -- Daten aus Rechtstitel
  -- für alle Personen bei Gläubiger und alle Personen aus FaLeistung:
  -- --------------------------------
  DECLARE CursorPersonFill CURSOR FAST_FORWARD FOR
    SELECT DISTINCT BaPersonID
    FROM dbo.IkGlaeubiger WITH (READUNCOMMITTED) 
    WHERE (IkRechtstitelID = @RechtstitelID AND NOT @RechtstitelID IS NULL) 
       OR (FaLeistungID = @LeistungID AND NOT @LeistungID IS NULL)
  OPEN CursorPersonFill

  WHILE 1=1 BEGIN
    FETCH NEXT FROM CursorPersonFill INTO @PersonFill
    IF @@FETCH_STATUS != 0 BREAK

    IF @LeistungID IS NULL BEGIN
      -- nur bei Rechtstitel
      -- Alle Erwachsenenalimente (IkForderung) 
      -- --------------------------------------
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
          F.IkForderungID,
          CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
          F.DatumGueltigBis,
          CASE WHEN F.IkAnpassungsregelCode = 1
            THEN (F.Betrag*IsNull(F.IndexStandBeiBerechnung,100))/IsNull(R.IndexStandPunkte,100)
            ELSE F.Betrag
          END,
          ISNull(F.IndexStandBeiBerechnung,100),
          ISNull(F.IndexStandDatum, @DateEnd),
          CONVERT(VARCHAR(500), F.Bemerkung),
          F.Unterstuetzungsfall
        FROM dbo.IkForderung F WITH (READUNCOMMITTED) 
        LEFT OUTER JOIN dbo.IkRechtstitel R WITH (READUNCOMMITTED) ON R.IkRechtstitelID = F.IkRechtstitelID
        WHERE F.IkRechtstitelID = @RechtstitelID
          AND F.BaPersonID = @PersonFill
          AND F.IkForderungPeriodischCode = 2 -- 2 = Erwachsenenalimente
          AND F.DatumAnpassenAb < @DateEnd
        ORDER BY F.DatumAnpassenAb DESC, F.IkForderungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO 
          @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, @IndexStand, @IndexStandDatum, @Bemerkung, @Unterstuetzungsfall
        IF @@FETCH_STATUS != 0 BREAK
        SET @IkForderungPeriodischCode = 2
        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1

        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues 
            (IkForderungID, ActDate, BaPersonID, TotalAliment, Punkte, PunkteDatum, Bemerkung, 
             IkForderungCode, Unterstuetzungsfall)
            VALUES (@IkForderungID, @DateTmpFrom, @PersonFill, @Betrag*@LoopCountDays, @IndexStand, @IndexStandDatum, @Bemerkung, 
             @IkForderungPeriodischCode, @Unterstuetzungsfall)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom);
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen

      -- Alle Kinderzulagen (IkForderung) 
      -- --------------------------------------
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
          F.IkForderungID,
          CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
          F.DatumGueltigBis, 
          F.Betrag,
          F.Unterstuetzungsfall
        FROM dbo.IkForderung                F WITH (READUNCOMMITTED) 
          LEFT OUTER JOIN dbo.IkRechtstitel R WITH (READUNCOMMITTED) ON R.IkRechtstitelID = F.IkRechtstitelID
        WHERE F.IkRechtstitelID = @RechtstitelID
          AND F.BaPersonID = @PersonFill
          AND F.IkForderungPeriodischCode = 3 -- 3 = Kinderzulagen
          AND F.DatumAnpassenAb < @DateEnd
        ORDER BY F.DatumAnpassenAb DESC, F.IkForderungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO 
          @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, @Unterstuetzungsfall
        IF @@FETCH_STATUS != 0 BREAK
        SET @IkForderungPeriodischCode = 1 -- 1 Zeile für Kinderalimente und Kinderzulagen!
        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues 
            (IkForderungID, ActDate, BaPersonID, BetragKiZulage, IkForderungCode, Unterstuetzungsfall)
            VALUES (@IkForderungID, @DateTmpFrom, @PersonFill, @Betrag*@LoopCountDays, @IkForderungPeriodischCode, @Unterstuetzungsfall)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom);
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen


-- bss spez. 

      -- Alle Kinderalimente (IkForderung) 
      -- --------------------------------------
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
          IkForderungID       = F.IkForderungID,
          DateTmpFrom         = CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
          DateTmpMax          = F.DatumGueltigBis, 
          Betrag              = CASE WHEN F.IkAnpassungsregelCode = 1
                                  THEN (F.Betrag * ISNULL(F.IndexStandBeiBerechnung, 100)) / ISNULL(R.IndexStandPunkte, 100)
                                  ELSE F.Betrag
                                END,
          BetragALBV          = CASE
                                  WHEN F.ALBVBerechtigt = 1 AND F.IkAnpassungsregelCode = 1
                                    THEN CONVERT(MONEY, dbo.fnMIN(CONVERT(MONEY, ((CASE TeilALBV WHEN 0 THEN F.Betrag ELSE F.TeilALBVBetrag END) * ISNULL(F.IndexStandBeiBerechnung, $100.0)) / ISNULL(R.IndexStandPunkte, 100)),
                                                                  @ALBVMaxBetrag))
                                  WHEN F.ALBVBerechtigt = 1 AND F.IkAnpassungsregelCode != 1
                                    THEN CONVERT(MONEY, dbo.fnMIN(CASE TeilALBV WHEN 0 THEN F.Betrag ELSE F.TeilALBVBetrag END,
                                                                  @ALBVMaxBetrag))
                                  ELSE 0
                                END,
          ALBVBerechtigt      = F.ALBVBerechtigt,
          IndexStand          = ISNull(F.IndexStandBeiBerechnung,100),
          IndexStandDatum     = ISNull(F.IndexStandDatum, @DateEnd),
          Bemerkung           = CONVERT(VARCHAR(500), F.Bemerkung),
          Unterstuetzungsfall = F.Unterstuetzungsfall
        FROM dbo.IkForderung                F WITH (READUNCOMMITTED) 
          LEFT OUTER JOIN dbo.IkRechtstitel R WITH (READUNCOMMITTED) ON R.IkRechtstitelID = F.IkRechtstitelID
        WHERE F.IkRechtstitelID = @RechtstitelID
          AND F.BaPersonID = @PersonFill
          AND F.IkForderungPeriodischCode = 1 -- 1 = Kinderalimente
          AND F.DatumAnpassenAb < @DateEnd
        ORDER BY F.DatumAnpassenAb DESC, F.IkForderungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO 
          @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, @BetragALBV, @ALBVBerechtigt, @IndexStand, @IndexStandDatum, @Bemerkung, @Unterstuetzungsfall
        IF @@FETCH_STATUS != 0 BREAK
        SET @IkForderungPeriodischCode = 1
        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues 
            (IkForderungID, ActDate, BaPersonID, TotalAliment, BetragALBV, ALBVBerechtigt, Punkte, PunkteDatum, Bemerkung, 
             IkForderungCode, Unterstuetzungsfall)
            VALUES (@IkForderungID, @DateTmpFrom, @PersonFill, @Betrag*@LoopCountDays, @BetragALBV*@LoopCountDays, @ALBVBerechtigt, @IndexStand, @IndexStandDatum, @Bemerkung, 
            @IkForderungPeriodischCode, @Unterstuetzungsfall)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom);
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen
    
    END ELSE BEGIN
      -- Alle, welche kein rechtstitel haben
      -- --------------------------------------
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
          F.IkForderungID,
          CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
          F.DatumGueltigBis, 
          F.Betrag, 
          F.IkForderungPeriodischCode,
          F.Unterstuetzungsfall
        FROM dbo.IkForderung F WITH (READUNCOMMITTED) 
        WHERE F.FaLeistungID = @LeistungID
          AND F.BaPersonID = @PersonFill
          AND F.DatumAnpassenAb < @DateEnd
        ORDER BY F.DatumAnpassenAb DESC, F.IkForderungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO 
          @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, @IkForderungPeriodischCode, @Unterstuetzungsfall
        IF @@FETCH_STATUS != 0 BREAK
        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues 
            (IkForderungID, ActDate, BaPersonID, TotalAliment, IkForderungCode, Unterstuetzungsfall)
            VALUES (@IkForderungID, @DateTmpFrom, @PersonFill, @Betrag*@LoopCountDays, @IkForderungPeriodischCode, @Unterstuetzungsfall)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom);
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen

    END
  END
  CLOSE CursorPersonFill
  DEALLOCATE CursorPersonFill


  IF @LeistungID IS NULL BEGIN
    -- nur bei Rechtstitel
    -- ---------------------------------------------------
    -- Verrechnungen
    -- Daten einfügen: Verrechnungen, aber nur einmal!!!
    -- select R.*, CASE WHEN R.DatumBis = convert(DateTime,'20071101') THEN R.LetzterMonat ELSE R.BetragProMonat END from IkRatenplan R where convert(DateTime,'20071101') BETWEEN R.DatumVon AND R.DatumBis
    -- select * from IkPosition where IkRechtstitelID = 6009 and Jahr = 2007 and Monat = 11
    -- ---------------------------------------------------
    INSERT INTO @TmpValues
      (ActDate, BaPersonID, BetragALBVRaten)
    SELECT
      @DateBeg,
      R.BaPersonID,
      CASE
        WHEN R.DatumBis = @DateBeg THEN CASE
          WHEN X.Value1 = '1' THEN R.LetzterMonat -- Nachzahlung an Gläubiger, also Betrag positiv
          ELSE -R.LetzterMonat                    --Rückforderung von Gläubiger, also Betrag negativ
        END
        ELSE CASE
          WHEN X.Value1 = '1' THEN R.BetragProMonat -- Nachzahlung an Gläubiger, also Betrag positiv
          ELSE -R.BetragProMonat                    --Rückforderung von Gläubiger, also Betrag negativ
        END
      END
    FROM dbo.IkVerrechnungskonto   R WITH (READUNCOMMITTED) 
      LEFT OUTER JOIN dbo.XLOVCode X WITH (READUNCOMMITTED) ON X.LOVName = 'IkVerrechnungsart' AND X.Code = R.IkVerrechnungsartCode
    WHERE R.IkRechtstitelID = @RechtstitelID
      AND @DateBeg BETWEEN R.DatumVon AND R.DatumBis
      AND (R.AnnulliertAm IS NULL OR @DateEnd <= R.AnnulliertAm)
  END

-- NUR FUER TESTS:
--SELECT V.*, V.TotalAliment/@DaysInMonth AS ProMonat, @DaysInMonth as DaysInMonth, BeginDate = @DateBeg, EndDate = @DateEnd FROM @TmpValues V
-- NUR FUER TESTS:
/*
SELECT V.BaPersonID,
  TotalAliment = dbo.fnIkAlimenteRunden(@Rundung, ISNULL(SUM(V.TotalAliment)/@DaysInMonth, 0)),
  BetragALBV = ROUND(ISNULL(SUM(V.BetragALBV)/@DaysInMonth, 0), 0),
  BetragKinderzulage = ROUND(ISNULL(SUM(V.BetragKiZulage)/@DaysInMonth, 0), 0),
  BetragVerrechg = ISNULL(SUM(V.BetragALBVRaten), 0)
FROM @TmpValues V
--where V.BaPersonID = 209063
GROUP BY BaPersonID
*/



  -- ---------------------------------------------------
  -- Nicht notwendige Daten löschen:
  -- ---------------------------------------------------
  -- IkForderungPosition
  /*
  DELETE IkForderungPosition
  WHERE IkPositionID IN (
    SELECT IkPositionID FROM IkPosition
    WHERE IkRechtstitelID = @RechtstitelID 
      AND Jahr = @ParamBisJahr 
      AND Monat = @ParamBisMonat 
      AND Einmalig = 0
      AND ErledigterMonat = 0 
      AND NOT BaPersonID IN (SELECT BaPersonID FROM @TmpValues)
  )
  */
  DELETE IkPosition
  WHERE (
      (IkRechtstitelID = @RechtstitelID AND @RechtstitelID IS NOT NULL) OR
      (FaLeistungID = @LeistungID AND @LeistungID IS NOT NULL)
    )
    AND Jahr = @ParamBisJahr
    AND Monat = @ParamBisMonat
    AND Einmalig = 0
    AND ErledigterMonat = 0
    AND NOT BaPersonID IN (SELECT BaPersonID FROM @TmpValues)


  -- Variabeln 
  --DECLARE @TextBemerkung varchar(100)
  DECLARE 
    @PersonID INT,
    @TotalAliment MONEY,
    @BetragALBVverrechnung MONEY,
    @BetragKiZulage MONEY,
    @IndexStandBeiBerechnungPos MONEY,
    @IkPositionID INT,
    @MonatIstErledigt BIT,
    @HasErrorMaxBetrag BIT,
    @LineCounts INT
  SET @HasErrorMaxBetrag = 0
  SET @LineCounts = 0

  DECLARE CursorPersons CURSOR FAST_FORWARD FOR
    -- Schlaufe über alle Personen
    SELECT DISTINCT BaPersonID FROM @TmpValues
  OPEN CursorPersons
  WHILE 1=1 BEGIN
    FETCH NEXT FROM CursorPersons INTO @PersonID
    IF @@FETCH_STATUS <> 0 BREAK

    -- ---------------------------------------------------
    -- jede Person einzeln updaten:
    -- ---------------------------------------------------
    -- IndexStand holen
    SELECT TOP 1
      @IndexStandBeiBerechnungPos = IsNull(Q.Punkte,100),
      @IndexStandVom              = IsNull(Q.PunkteDatum, @DateEnd - 1)
    FROM @TmpValues Q
    WHERE Q.BaPersonID = @PersonID
    ORDER BY Q.ActDate DESC

    -- Summen holen:
    SELECT
      @TotalAliment              = dbo.fnIkAlimenteRunden(@Rundung, IsNull(SUM(tmp.TotalAliment)/@DaysInMonth, 0)),
      @BetragALBV                = dbo.fnIkAlimenteRunden(@Rundung, IsNull(SUM(tmp.BetragALBV)/@DaysInMonth, 0)),
      @BetragALBVverrechnung     = IsNull(SUM(tmp.BetragALBVRaten), 0),
      @BetragKiZulage            = dbo.fnIkAlimenteRunden(7, IsNull(SUM(tmp.BetragKiZulage)/@DaysInMonth, 0)), -- Kaufmännisches Runden auf 0.05 Ticket 4123
      @ALBVBerechtigt            = MAX(CONVERT(INT, ALBVBerechtigt)),
      @IkForderungPeriodischCode = MIN(tmp.IkForderungCode),
      @Unterstuetzungsfall       = MAX(CONVERT(INT, tmp.Unterstuetzungsfall))
    FROM @TmpValues tmp
    WHERE tmp.BaPersonID = @PersonID

    DECLARE @BetragAuszahlung money
    SET @BetragAuszahlung = @BetragALBV + @BetragALBVverrechnung 
    IF @BetragAuszahlung < 0
      SET @BetragAuszahlung = 0

--select forderungcode = @IkForderungPeriodischCode, bapersonid = @PersonID
    -- kontrollieren, ob der Monat nicht bereits erledigt ist
    SET @IkPositionID = NULL
    SET @MonatIstErledigt = 0
    SELECT TOP 1
      @IkPositionID = IkPositionID,
      @MonatIstErledigt = IsNull(ErledigterMonat, 0)
    FROM dbo.IkPosition 
    WHERE (
        (IkRechtstitelID = @RechtstitelID AND @RechtstitelID IS NOT NULL) OR
        (FaLeistungID = @LeistungID AND @LeistungID IS NOT NULL)
      )
      AND BaPersonID = @PersonID
      AND Monat = @ParamBisMonat
      AND Jahr = @ParamBisJahr
      AND Einmalig = 0

    IF (@MonatIstErledigt = 0)
    BEGIN
      IF (
        --(@ProzessCode = 401) AND -- ALBV
        (@TotalAliment = 0 OR @TotalAliment IS NULL) AND
        (@BetragALBVverrechnung = 0 OR @BetragALBVverrechnung IS NULL) AND
        (@BetragKiZulage = 0 OR @BetragKiZulage IS NULL)
      )
      BEGIN
        -- Alles null, also löschen
        DELETE IkPosition
        WHERE IkPositionID = @IkPositionID

      END ELSE
      BEGIN
        -- Updaten oder neu einfügen

        -- ---------------------------------------------------
        -- Die Bemerkung soll nur übernommen werden, 
        -- wenn es eine Veränderung im Monat gegeben hat
        -- ---------------------------------------------------
        /*
        SET @Bemerkung = NULL
        IF NOT EXISTS (
          SELECT 1 FROM IkPosition 
          WHERE IkRechtstitelID = @RechtstitelID
            AND BaPersonID = @PersonID
            AND Monat = @MonatPrevious
            AND Jahr = @JahrPrevious
            AND Einmalig = 0
            AND TotalAliment = @TotalAliment
            AND BetragALBV = @BetragALBV
            AND BetragALBVVerrechnung = @BetragALBVVerrechnung
            AND BetragKiZulage = @BetragKiZulage )
        BEGIN
          -- Letzte Bemerkung holen
          SELECT TOP 1
            @Bemerkung = CONVERT(VARCHAR(500), Q.Bemerkung)
          FROM IkForderung Q
          WHERE Q.BaPersonID = @PersonID
            AND Q.IkRechtstitelID = @RechtstitelID
            AND NOT Q.Bemerkung IS NULL
            AND Q.DatumAnpassenAb BETWEEN @DateBeg AND @DateEnd
            -- TODO
            -- AND Q.ForderungAktiv = 1
          ORDER BY Q.DatumAnpassenAb DESC
        END
        */


        -- ---------------------------------------------------
        -- Kontrolle Betrag
        -- ---------------------------------------------------
/*
        IF @TotalAliment<@BetragALBV AND @ProzessCode = 405 BEGIN -- nur bei ALBV
          SET @BetragALBV = @TotalAliment
          SET @HasErrorMaxBetrag = @HasErrorMaxBetrag + 1
        END
*/

        -- ---------------------------------------------------
        -- Summen speichern:
        -- ---------------------------------------------------
        IF @IkPositionID IS NOT NULL
        BEGIN
          -- Zeile updaten
          SET @LineCounts = @LineCounts + 1
          UPDATE IkPosition SET
            -- Bei Update soll dies nicht überschrieben werden 
            -- 18.03.2008: jetzt aber doch wieder :-)
            Unterstuetzungsfall = @Unterstuetzungsfall,
            TotalAliment = @TotalAliment,
            TotalAlimentSoll = @TotalAliment,
            BetragALBV = @BetragALBV,
            BetragALBVSoll = @BetragALBV,
            BetragALBVverrechnung = @BetragALBVverrechnung,
            BetragKiZulage = @BetragKiZulage,
            BetragKiZulageSoll = @BetragKiZulage,
            IndexStandBeiBerechnung = @IndexStandBeiBerechnungPos,
            IndexStandDatum = @IndexStandVom,
            IkForderungCode = @IkForderungPeriodischCode,
            ALBVBerechtigt  = @ALBVBerechtigt,
            BetragAuszahlung = @BetragAuszahlung
          WHERE IkPositionID = @IkPositionID
        END ELSE BEGIN

          -- Neue Zeile einfügen
          SET @LineCounts = @LineCounts + 1
          INSERT INTO IkPosition (
            IkRechtstitelID, FaLeistungID, Einmalig, ErledigterMonat,
            Datum, Monat, Jahr, BaPersonID,
            TotalAliment, BetragALBV, BetragALBVverrechnung, BetragKiZulage,
            TotalAlimentSoll, BetragALBVSoll, BetragKiZulageSoll,
            IndexStandBeiBerechnung, IndexStandDatum,
            IkForderungCode, ALBVBerechtigt, Unterstuetzungsfall, BetragAuszahlung
          ) VALUES (
            @RechtstitelID, @LeistungID, 0, 0,
            dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1),
            @ParamBisMonat, @ParamBisJahr, @PersonID,
            @TotalAliment, @BetragALBV, @BetragALBVverrechnung, @BetragKiZulage,
            @TotalAliment, @BetragALBV, @BetragKiZulage,
            @IndexStandBeiBerechnungPos, @IndexStandVom,
            @IkForderungPeriodischCode, @ALBVBerechtigt, @Unterstuetzungsfall, @BetragAuszahlung
          )
          SET @IkPositionID = SCOPE_IDENTITY()
        END
      END
    END ELSE BEGIN
      -- ---------------------------------------------------
      -- Zeile updaten
      -- ---------------------------------------------------
      -- Wenn der Monat bereits erledigt ist, dann sollen nur die Soll-Werte korrigiert werden
      SET @LineCounts = @LineCounts + 1
      UPDATE IkPosition SET
        -- Bei Update soll dies nicht überschrieben werden
        -- Unterstuetzungsfall = @Unterstuetzungsfall,
        TotalAlimentSoll = @TotalAliment,
        BetragALBVSoll = @BetragALBV,
        BetragKiZulageSoll = @BetragKiZulage
      WHERE IkPositionID = @IkPositionID
    END

    -- Alte n:m-Beziehung löschen:
    DELETE IkForderungPosition 
    WHERE IkPositionID = @IkPositionID
      AND NOT IkForderungID IN (
        SELECT DISTINCT IkForderungID FROM @TmpValues 
        WHERE IkForderungID IS NOT NULL AND BaPersonID = @PersonID
      )

    IF @IkPositionID IS NOT NULL BEGIN 
      -- Jetzt noch n:m-Beziehung füllen:
      DECLARE crsFordPos CURSOR FAST_FORWARD FOR
        SELECT DISTINCT IkForderungID FROM @TmpValues 
        WHERE IkForderungID IS NOT NULL AND BaPersonID = @PersonID
      OPEN crsFordPos
      WHILE 1=1 BEGIN
        FETCH NEXT FROM crsFordPos INTO @IkForderungID
        IF @@FETCH_STATUS <> 0 OR @IkPositionID IS NULL BREAK
        -- neue einfügen
        IF NOT EXISTS(
          SELECT * FROM IkForderungPosition 
          WHERE IkForderungID = @IkForderungID AND IkPositionID = @IkPositionID)
        BEGIN
          INSERT INTO IkForderungPosition (IkForderungID, IkPositionID)
            VALUES (@IkForderungID, @IkPositionID)
        END
      END
      CLOSE crsFordPos
      DEALLOCATE crsFordPos
    END

  END
  CLOSE CursorPersons
  DEALLOCATE CursorPersons


  -- NUR FUER TESTS:
  --SELECT V.* FROM IkPosition V
  --WHERE IkRechtstitelID = @RechtstitelID AND Jahr = @ParamBisJahr AND Monat = @ParamBisMonat

  -- Resultate zurückliefern
  --SELECT 0 AS HasErrors, @HasErrorMaxBetrag AS HasErrorMaxBetrag, @LineCounts AS LineCounts
  --print convert(varchar, @LineCounts)
END
GO
