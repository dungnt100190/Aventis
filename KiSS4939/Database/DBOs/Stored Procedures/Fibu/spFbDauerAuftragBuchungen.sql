SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbDauerAuftragBuchungen
GO
/*===============================================================================================
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
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spFbDauerAuftragBuchungen
(
  @UserID INT
)
AS
  DECLARE @AnfangsDatum DATETIME;
  DECLARE @AnfangsDatumWithWeekend DATETIME;
  DECLARE @EndDatum DATETIME;
  DECLARE @LetzteBuchungDatum DATETIME;
  DECLARE @ValutaDatum DATETIME;
  DECLARE @FbDauerauftragID INT;
  DECLARE @MonatAbstand INT;
  DECLARE @Monatstag1 INT;
  DECLARE @Monatstag2 INT;
  DECLARE @VorWochenende BIT;
  DECLARE @FbPeriodeID INT;
  DECLARE @SollKtoNr INT;
  DECLARE @HabenKtoNr INT;
  DECLARE @BelegNummerierung INT;
  DECLARE @DayOfWeek INT;
  DECLARE @Frist INT;
  DECLARE @BuchungCount INT;
  DECLARE @ErfolgreicheBuchungenCount INT;
  DECLARE @Wochentag INT;
  DECLARE @CreatorModifier VARCHAR(50)

SELECT @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);

-- drop table #TempFbBuchung
CREATE TABLE #TempFbBuchung
(
  [FbDauerauftragID] [int] NULL ,
  [ValutaDatum] [datetime] NULL ,
  [FbPeriodeID] [int] NULL ,
  [SollKtoNr] [int] NULL ,
  [HabenKtoNr] [int] NULL
)

 -- first day of week is monday! before changing, store current value
  DECLARE @OrigDateFirst INT;
  SET @OrigDateFirst = @@DATEFIRST;  
  SET DATEFIRST 1;


SET @Frist    = IsNull(CONVERT(int, dbo.fnXConfig('System\Fibu\DauerAuftrage\BuchungsFrist', GetDate())), 1)
SET @EndDatum = DateAdd(d, @Frist, dbo.fnDateOf(GetDate()))
PRINT 'EndDatum : ' + CONVERT(varchar, @EndDatum)

SET @BelegNummerierung  = (SELECT TOP 1 FbBelegNrID FROM FbBelegNr WHERE BelegNrCode = 2)
SET @BuchungCount       = 0
SET @ErfolgreicheBuchungenCount = 0

PRINT 'Frist : ' + char(9) + char(9) + char(9) + char(9) + CONVERT (varchar, @Frist) + char(13) + char(13)

-- 1. Get all Dauerauftrag with their global elapsed time in which x buchungen could be created
  DECLARE cursorFDA CURSOR FOR
  SELECT  FDA.FbDauerauftragID, 
          AnfangsDatum = IsNull(MAX(FBU.ValutaDatumOriginal), FDA.DatumVon), 
          LetzteBuchungDatum = MAX(FBU.BuchungsDatum),
          --  if today's date is smaller than "Gueltig Bis" datum, use the today's date as right limit
          EndDatum = MIN(CASE WHEN (FDA.DatumBis IS NULL OR FDA.DatumBis > @EndDatum) THEN @EndDatum ELSE FDA.DatumBis END),
          MonatAbstand = LOV.Value1, 
          FDA.Monatstag1, 
          FDA.Monatstag2, 
          FDA.WochentagCode,
          FDA.VorWochenende
  FROM dbo.FbDauerauftrag     FDA WITH (READUNCOMMITTED) 
    LEFT  JOIN dbo.FbBuchung  FBU  WITH (READUNCOMMITTED) ON FBU.FbDauerauftragID  = FDA.FbDauerauftragID
    INNER JOIN dbo.XLOVCode   LOV  WITH (READUNCOMMITTED) ON FDA.PeriodizitaetCode = LOV.Code AND LOV.LOVName = 'ZahlungsPeriode'
  WHERE dbo.fnDateOf(FDA.DatumVon) <= @EndDatum
  GROUP BY FDA.FbDauerauftragID, FDA.Monatstag1, FDA.Monatstag2, FDA.WochentagCode, FDA.VorWochenende, LOV.Value1, FDA.DatumVon

-- 2. Foreach Dauerauftrag, insert the x buchungen into #Buchung table
OPEN cursorFDA
FETCH NEXT FROM cursorFDA INTO @FbDauerauftragID, @AnfangsDatum, @LetzteBuchungDatum, @EndDatum, @MonatAbstand, @Monatstag1, @Monatstag2, @Wochentag, @VorWochenende;
WHILE @@FETCH_STATUS = 0 
BEGIN
  PRINT 'AnfangsDatum : ' + CONVERT(varchar, @AnfangsDatum)
  --Berechnung aufgrund von Monatstag1 und Monatstag2
  IF (@Wochentag IS NULL)
    BEGIN  
    IF (Day(@AnfangsDatum) < @Monatstag1) BEGIN
    PRINT 'AnfangsDatum < @MonatsTag1'
    SET @AnfangsDatum = dbo.fnDateSerial(Year(@AnfangsDatum), Month(@AnfangsDatum), @Monatstag1)
    END

    ELSE IF (Day(@AnfangsDatum) > @Monatstag1 AND Day(@AnfangsDatum) <= @Monatstag2) BEGIN
    PRINT 'AnfangsDatum > @MonatsTag1  && AnfangsDatum < @MonatsTag2'
    SET @AnfangsDatum = dbo.fnDateSerial(Year(@AnfangsDatum), Month(@AnfangsDatum), @Monatstag2)
    END

    ELSE IF (Day(@AnfangsDatum) <> @Monatstag1) BEGIN
    PRINT 'AnfangsDatum > @MonatsTag1 && (AnfangsDatum < @MonatsTag2 OR @MonatsTag2 is null)'
    SET @AnfangsDatum = dbo.fnDateSerial(Year(DateAdd(month, 1, @AnfangsDatum)), Month(DateAdd(month, 1, @AnfangsDatum)), @Monatstag1)
    END

    SET @AnfangsDatum = dbo.fnDateOf(@AnfangsDatum)
    PRINT 'Start Daten'
    PRINT 'Monatstag1 : ' + char(9) + char(9) + char(9) + CONVERT(varchar, @Monatstag1)
    PRINT 'Monatstag2 : ' + char(9) + char(9) + char(9) + CONVERT(varchar, @Monatstag2)
    PRINT 'Periode End Datum : ' + char(9) + char(9) + char(9) + CONVERT(varchar, @EndDatum)
    PRINT 'Letzte Buchung Datum :' + char(9) + char(9) + char(9) + CONVERT(varchar, dbo.fnDateOf(@LetzteBuchungDatum))
    PRINT 'Periode Anfangs Datum : ' + char(9) + char(9) + CONVERT(varchar, @AnfangsDatum)
    END
  ELSE
  -- Berechnung aufgrund von Wochentag
  BEGIN
    IF (DatePart(weekday, @AnfangsDatum) < @Wochentag) BEGIN
      PRINT 'DatePart(weekday, @AnfangsDatum) < @Wochentag'
      SET @AnfangsDatum = DATEADD(day, @Wochentag - DatePart(weekday, @AnfangsDatum), @AnfangsDatum);
    END
    ELSE IF (DatePart(weekday, @AnfangsDatum) > @Wochentag) BEGIN
      PRINT 'DatePart(weekday, @AnfangsDatum) > @Wochentag)'
      SET @AnfangsDatum = DATEADD(day, 7 - DatePart(weekday, @AnfangsDatum) + @Wochentag, @AnfangsDatum);
    END
    ELSE BEGIN
      PRINT 'DatePart(weekday, @AnfangsDatum) = @Wochentag)'
    END
  END

  SET @DayOfWeek = DatePart(weekday, @AnfangsDatum)
  PRINT 'Day of week : ' + CONVERT(varchar, @DayOfWeek)
  -- We need to keep @TempDatum value to be able to compare with MonatsTag,
  -- which is different from tag calculated with Week Days. All "Buchung" falling
  -- on Friday, Saturday or Sunday should be inserted on Thursday, independantly from Frist, which is
  -- only used to calculate the elapsed time
  SET @AnfangsDatumWithWeekend = CASE @DayOfWeek
                                    WHEN 1 THEN DateAdd(day, -4, DateAdd(minute, 1, @AnfangsDatum)) -- montag
                                    WHEN 7 THEN DateAdd(day, -3, DateAdd(minute, 1, @AnfangsDatum)) -- sonntag
                                    WHEN 6 THEN DateAdd(day, -2, DateAdd(minute, 1, @AnfangsDatum)) -- samstag
                                    WHEN 5 THEN DateAdd(day, -1, DateAdd(minute, 1, @AnfangsDatum)) -- freitag
                                    ELSE @AnfangsDatum
                                  END
  SET @ValutaDatum = CASE WHEN @VorWochenende = 1 AND @DayOfWeek = 7 THEN DateAdd(day, -2, @AnfangsDatum) -- sonntag
                          WHEN @VorWochenende = 1 AND @DayOfWeek = 6 THEN DateAdd(day, -1, @AnfangsDatum) -- samstag
                          ELSE @AnfangsDatum
                     END

  PRINT 'Periode Anfangs Datum with weekend :' + char(9)  + CONVERT(varchar, @AnfangsDatumWithWeekend)  + char(13) + char(13)
  WHILE (@AnfangsDatumWithWeekend <= @EndDatum) 
  BEGIN
    -- Compare last buchungsdatum to see if buchung has already been created (used for weekend, so that buchung is not inserted once on thurday, once on friday etc..)
    IF (@LetzteBuchungDatum IS NULL OR (dbo.fnDateOf(@LetzteBuchungDatum) <> dbo.fnDateOf(@ValutaDatum) 
                                        AND dbo.fnDateOf(@LetzteBuchungDatum) <> dbo.fnDateOf(@AnfangsDatum)))
    BEGIN
      INSERT INTO #TempFbBuchung(FbDauerauftragID, ValutaDatum, FbPeriodeID, SollKtoNr, HabenKtoNr)
        SELECT FDA.FbDauerauftragID, @ValutaDatum, FPE.FbPeriodeID, FDA.SollKtoNr, FDA.HabenKtoNr
        FROM dbo.FbDauerauftrag FDA WITH (READUNCOMMITTED) 
          INNER JOIN dbo.BaPerson DMP WITH (READUNCOMMITTED) ON DMP.BaPersonID = FDA.BaPersonID
          LEFT  JOIN dbo.FbPeriode FPE WITH (READUNCOMMITTED) ON FPE.BaPersonID = DMP.BaPersonID AND @ValutaDatum BETWEEN FPE.PeriodeVon AND FPE.PeriodeBis AND FPE.PeriodeStatusCode = 1
        WHERE FDA.FbDauerauftragID = @FbDauerauftragID
    END
  
    -- @Anfangsdatum inkrementieren
    IF(@Wochentag IS NULL)
    BEGIN
      -- Berechnung anhand @Monatstag1 + @Monatstag2
      IF (@Monatstag2 IS NOT NULL) 
      BEGIN
        IF (@Monatstag2 IS NOT NULL AND Day(@AnfangsDatum) = @Monatstag2) 
        BEGIN
          SET @AnfangsDatum = dbo.fnDateSerial(Year(DateAdd(month, 1, @AnfangsDatum)), Month(DateAdd(month, 1, @AnfangsDatum)), @Monatstag1)
        END
        ELSE 
        BEGIN
         SET @AnfangsDatum = dbo.fnDateSerial(Year(@AnfangsDatum), Month(@AnfangsDatum), @Monatstag2)
        END
      END
      ELSE 
      BEGIN
        SET @AnfangsDatum = DateAdd(month, @MonatAbstand, @AnfangsDatum)
      END
    
    END
    ELSE
    BEGIN
      --Berechnung anhand @Wochentag
      SET @AnfangsDatum = DATEADD(day, 7, @AnfangsDatum);
    END

    SET @DayOfWeek = DatePart(weekday, @AnfangsDatum)
    SET @AnfangsDatumWithWeekend = CASE @DayOfWeek
                                     WHEN 1 THEN DateAdd(day, -4, DateAdd(minute, 1, @AnfangsDatum)) -- montag
                                     WHEN 7 THEN DateAdd(day, -3, DateAdd(minute, 1, @AnfangsDatum)) -- sonntag
                                     WHEN 6 THEN DateAdd(day, -2, DateAdd(minute, 1, @AnfangsDatum)) -- samstag
                                     WHEN 5 THEN DateAdd(day, -1, DateAdd(minute, 1, @AnfangsDatum)) -- freitag
                                     ELSE @AnfangsDatum
                                   END
    SET @ValutaDatum = CASE WHEN @VorWochenende = 1 AND @DayOfWeek = 7 THEN DateAdd(day, -2, @AnfangsDatum) -- sonntag
                            WHEN @VorWochenende = 1 AND @DayOfWeek = 6 THEN DateAdd(day, -1, @AnfangsDatum) -- samstag
                            ELSE @AnfangsDatum
                       END

    SET @BuchungCount = @BuchungCount + 1
    PRINT ' Buchung Nr : ' + CONVERT(varchar, @BuchungCount)
    PRINT 'Periode Anfangs Datum : ' + char(9) + char(9) + CONVERT(varchar, @AnfangsDatum)
    PRINT 'Periode Anfangs Datum with weekend :' + char(9) + CONVERT(varchar, @AnfangsDatumWithWeekend) + char(10)
    PRINT 'FbDauerAuftragID :' + char(9) + CONVERT(varchar, @FbDauerauftragID)
  END
  FETCH NEXT FROM cursorFDA INTO @FbDauerauftragID, @AnfangsDatum, @LetzteBuchungDatum, @EndDatum, @MonatAbstand, @Monatstag1, @Monatstag2, @Wochentag, @VorWochenende
END
CLOSE cursorFDA
DEALLOCATE cursorFDA
SET @BuchungCount = (SELECT COUNT(*) FROM #TempFbBuchung)

PRINT 'Number of Buchung ready to insert : ' + CONVERT(varchar, @BuchungCount)
-- 3. Foreach tempBuchung, insert in FbBuchung Table if SollktoNr, HabenKtoNr and FbPeriodeId is ok.
--    If not, update FbDauerAuftrag status and trash Buchung
-- Reset all current Dauerauftrag to 1 (Correct)
UPDATE FbDauerauftrag SET Status = 1 WHERE FbDauerauftragID in (SELECT DISTINCT FbDauerauftragID FROM #TempFbBuchung)
DECLARE cursorTempBuchung CURSOR FOR
  SELECT * FROM #TempFbBuchung
OPEN cursorTempBuchung
FETCH NEXT FROM cursorTempBuchung INTO @FbDauerauftragID, @ValutaDatum, @FbPeriodeID, @SollKtoNr, @HabenKtoNr

WHILE @@FETCH_STATUS = 0
BEGIN
  IF (@FbPeriodeID IS NULL) 
  BEGIN
    -- Ungultige Periode (Existiert nicht oder unaktiv)
    UPDATE FbDauerauftrag SET Status = 2 WHERE FbDauerauftragID = @FbDauerauftragID

    PRINT 'Ungultige oder unaktiv Periode'
  END
  -- HabenKtoNr + SollKtoNr existieren nicht in Periode
  ELSE IF (NOT EXISTS (SELECT KontoNr FROM FbKonto FBK WHERE FBK.FbPeriodeID = @FbPeriodeID AND KontoNr = @SollKtoNr) AND
           NOT EXISTS (SELECT KontoNr FROM FbKonto FBK WHERE FBK.FbPeriodeID = @FbPeriodeID AND KontoNr = @HabenKtoNr)) 
  BEGIN
    UPDATE FbDauerauftrag SET Status = 5 WHERE FbDauerauftragID = @FbDauerauftragID
    PRINT 'HabenKtoNr + SollKtoNr existieren nicht in Periode'
  END
  -- SollKtoNr existiert nicht in Periode
  ELSE IF (@SollKtoNr NOT in (SELECT KontoNr FROM FbKonto FBK WHERE FBK.FbPeriodeID = @FbPeriodeID)) 
  BEGIN
    UPDATE FbDauerauftrag SET Status = 3 WHERE FbDauerauftragID = @FbDauerauftragID
    PRINT 'SollKtoNr existiert nicht in Periode'
  END
  -- HabenKtoNr existiert nicht in Periode
  ELSE IF (@HabenKtoNr NOT in (SELECT KontoNr FROM FbKonto FBK WHERE FBK.FbPeriodeID = @FbPeriodeID)) 
  BEGIN
    UPDATE FbDauerauftrag SET Status = 4 WHERE FbDauerauftragID = @FbDauerauftragID
    PRINT 'HabenKtoNr existiert nicht in Periode'
  END
  -- Check that BelegNr Generation is set in FbBelegNr Table
  ELSE IF (@BelegNummerierung IS NULL) 
  BEGIN
    UPDATE FbDauerauftrag SET Status = 6 WHERE FbDauerauftragID = @FbDauerauftragID
    PRINT 'BelegNr Generation not set'
  END
  -- Buchung is richtig, mann muss nur noch sicher sein dass keinen Fehler in eine vorhige buchung passiert sind.
  -- Deshalb wird den Status kontrolliert
  ELSE IF ((SELECT Status FROM FbDauerauftrag FDA WHERE FDA.FbDauerauftragID = @FbDauerauftragID) = 1)
  BEGIN
    BEGIN TRANSACTION
      INSERT INTO dbo.FbBuchung
            (FbPeriodeID, BuchungTypCode, BelegNr, BelegNrPos, BuchungsDatum, SollKtoNr, HabenKtoNr, Betrag, Text,
             ValutaDatum, ValutaDatumOriginal, FbDauerauftragID, ErfassungsDatum, FbZahlungswegID, PCKontoNr, BankKontoNr, IBAN, ZahlungsArtCode,
             ReferenzNummer, Zahlungsgrund, Name, Zusatz, Strasse, PLZ, Ort, Creator, Modifier)
      SELECT @FbPeriodeID, 2, (SELECT TOP 1 Praefix + CAST(NaechsteBelegNr AS varchar) FROM FbBelegNr WHERE BelegNrCode = 2) , 0, @ValutaDatum, @SollKtoNr, @HabenKtoNr, FDA.Betrag, Text = dbo.fnFbGetBuchungstext(FDA.Text, @ValutaDatum),
             @ValutaDatum, @ValutaDatum, @FbDauerauftragID, GetDate(), FDA.FbZahlungswegID, FZW.PCKontoNr, FZW.BankKontoNr, FZW.IBAN, FZW.ZahlungsArtCode,
             FDA.ReferenzNummer, FDA.Zahlungsgrund, FKR.Name, FKR.Zusatz, FKR.Strasse, FKR.PLZ, FKR.Ort, @CreatorModifier, @CreatorModifier
      FROM dbo.FbDauerauftrag FDA WITH (READUNCOMMITTED) 
        INNER JOIN dbo.FbZahlungsweg FZW WITH (READUNCOMMITTED) ON FDA.FbZahlungswegID = FZW.FbZahlungswegID
        INNER JOIN dbo.FbKreditor    FKR WITH (READUNCOMMITTED) ON FZW.FbKreditorID    = FKR.FbKreditorID
      WHERE FDA.FbDauerauftragID = @FbDauerauftragID AND FDA.Status = 1
      
      UPDATE FbBelegNr
        SET NaechsteBelegNr = NaechsteBelegNr + 1
      WHERE BelegNrCode = 2
      PRINT 'Buchung Inseriert'
      SET @ErfolgreicheBuchungenCount = @ErfolgreicheBuchungenCount + 1
      UPDATE FbDauerauftrag SET Status = 1 WHERE FbDauerauftragID = @FbDauerauftragID
    COMMIT TRANSACTION
  END
  FETCH NEXT FROM cursorTempBuchung INTO @FbDauerauftragID, @ValutaDatum, @FbPeriodeID, @SollKtoNr, @HabenKtoNr
END
CLOSE cursorTempBuchung
DEALLOCATE cursorTempBuchung

  -------------------------------------------------------------------------------
  -- restore original setting as it is used per session!
  -------------------------------------------------------------------------------
  SET DATEFIRST @OrigDateFirst;

SELECT @ErfolgreicheBuchungenCount
GO
