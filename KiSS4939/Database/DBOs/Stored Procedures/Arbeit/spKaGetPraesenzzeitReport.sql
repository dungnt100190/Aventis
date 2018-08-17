SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKaGetPraesenzzeitReport;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: . 
=================================================================================================
  TEST: EXEC dbo.spKaGetPraesenzzeitReport NULL, 11, 2010, NULL, NULL, NULL, NULL, NULL, NULL, NULL
=================================================================================================*/

CREATE PROCEDURE dbo.spKaGetPraesenzzeitReport
(
  @IsUserKA      INT,
  @Monat         INT,
  @Jahr          INT,
  @KlientID      INT,
  @APVNr         INT,
  @Zusatz        INT,
  @CoachID       INT,
  @FachbereichID INT,
  @FachleitungID INT,
  @KursID        INT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- init
  -----------------------------------------------------------------------------
  SET NOCOUNT ON

  DECLARE @tmp TABLE 
  (
    ID           INT IDENTITY,
    BaPersonID   INT,
    Tag          INT,
    AM_AnwCode   INT,
    PM_AnwCode   INT,
    AM_Bemerkung VARCHAR(MAX),
    PM_Bemerkung VARCHAR(MAX),
    SamstagAktiv BIT,
    SonntagAktiv BIT,
    PRIMARY KEY (BaPersonID,Tag,ID)
  );

  DECLARE @SichtbarSD INT;
  
  IF (@IsUserKA = 0)
  BEGIN
    SET @SichtbarSD = 0;
  END 
  ELSE 
  BEGIN
    SET @SichtbarSD = 1;
  END;
  
  -----------------------------------------------------------------------------
  -- Anpassungen für @@DATEFIRST vorbereiten
  -- Die Nummer des ersten Wochentags holen: 1 = Montag, 2 = Dienstag, usw.
  -- u.U. kann dies auch 2 = Montag, 3 = Dienstag, usw. sein
  -----------------------------------------------------------------------------
  DECLARE @Saturday             INT;
  DECLARE @Sunday               INT;
  DECLARE @NumberFirstDayOfWeek INT;
  
  SET @NumberFirstDayOfWeek = @@DATEFIRST;
  
  -- Die Nummer des Samstags gemäss Einstellung der DB holen
  SET @Saturday = CASE @NumberFirstDayOfWeek
                    WHEN 1 THEN 6
                    WHEN 2 THEN 5
                    WHEN 3 THEN 4
                    WHEN 4 THEN 3
                    WHEN 5 THEN 2
                    WHEN 6 THEN 1
                    ELSE 7
                  END;

  -- Die Nummer des Sonntags gemäss Einstellung der DB holen
  SET @Sunday = CASE @NumberFirstDayOfWeek
                  WHEN 1 THEN 7
                  WHEN 2 THEN 6
                  WHEN 3 THEN 5
                  WHEN 4 THEN 4
                  WHEN 5 THEN 3
                  WHEN 6 THEN 2
                  ELSE 1
                END;

  -- Bestimmung der Anzahl Tage in diesem Monat
  DECLARE @DaysInMonth      INT;
  DECLARE @FirstOfMonth     DATETIME;
  DECLARE @FirstOfNextMonth DATETIME;
  
  SET @DaysInMonth      = dbo.fnDaysInMonthOf(dbo.fnDateSerial(@Jahr, @Monat, 1));
  SET @FirstOfMonth     = CONVERT(DATETIME, '1.' + CONVERT(VARCHAR, @Monat) + '.' + CONVERT(VARCHAR, @Jahr), 104);
  SET @FirstOfNextMonth = DATEADD(MONTH, 1, @FirstOfMonth);
  
  -----------------------------------------------------------------------------
  -- get data and fill temp table
  -----------------------------------------------------------------------------
  INSERT @tmp
    SELECT KAR.BaPersonID,
           DAY(Datum),
           AM_AnwCode,
           PM_AnwCode,
           AM_Bemerkung,
           PM_Bemerkung,
           SamstagAktiv=ISNULL(KAE.SamstagAktiv,0),
           SonntagAktiv=ISNULL(KAE.SonntagAktiv,0)
    FROM dbo.KaArbeitsrapport KAR WITH (READUNCOMMITTED) 
      INNER JOIN dbo.KAEinsatz KAE on KAE.KaEinsatzID=KAR.KaEinsatzID
    WHERE YEAR(Datum) = @Jahr 
      AND MONTH(Datum) = @Monat
      AND (KAR.SichtbarSDFlag = @SichtbarSD OR (KAR.SichtbarSDFlag = (SELECT PER.SichtbarSDFlag 
                                                                      FROM dbo.BaPerson PER WITH (READUNCOMMITTED) 
                                                                      WHERE PER.BaPersonID = KAR.BaPersonID) OR KAR.SichtbarSDFlag = 1))
      AND KAR.BaPersonID = ISNULL(@KlientID, KAR.BaPersonID)
  
      AND KAR.KaEinsatzID IN (SELECT KAE.KaEinsatzID
                          FROM dbo.KaEinsatz KAE WITH (READUNCOMMITTED) 
                          WHERE KAE.KaEinsatzplatzID = ISNULL(@APVNr, KAE.KaEinsatzplatzID))
  
      AND KAR.KaEinsatzID IN (SELECT KAE1.KaEinsatzID
                          FROM dbo.KaEinsatz KAE1 WITH (READUNCOMMITTED) 
                          WHERE @Zusatz IS NULL OR @Zusatz = KAE1.APVZusatzCode)
  
      AND (@CoachID IS NULL OR EXISTS (SELECT TOP 1 1 
                                       FROM dbo.KaZuteilFachbereich ZUT1 WITH (READUNCOMMITTED) 
                                       WHERE ZUT1.ZustaendigKaID = @CoachID 
                                         AND BaPersonID = KAR.BaPersonID
                                         AND (CONVERT(DATETIME, ZUT1.ZuteilungVon, 104) < @FirstOfNextMonth
                                         AND (CONVERT(DATETIME, ZUT1.ZuteilungBis, 104) >= @FirstOfMonth OR ZUT1.ZuteilungBis IS NULL))))
      
      AND (@FachbereichID IS NULL OR KAR.BaPersonID IN (SELECT DISTINCT ZUT.BaPersonID
                                                    FROM dbo.KaZuteilFachbereich ZUT WITH (READUNCOMMITTED) 
                                                    WHERE @FachbereichID = ZUT.FachbereichID
                                                      AND (CONVERT(DATETIME, ZUT.ZuteilungVon, 104) < @FirstOfNextMonth
                                                      AND (CONVERT(DATETIME, ZUT.ZuteilungBis, 104) >= @FirstOfMonth OR ZUT.ZuteilungBis IS NULL))))
      
      AND (@FachleitungID IS NULL OR KAR.BaPersonID IN (SELECT DISTINCT ZUT2.BaPersonID
                                                    FROM dbo.KaZuteilFachbereich ZUT2 WITH (READUNCOMMITTED) 
                                                    WHERE ZUT2.FachleitungID = @FachleitungID
                                                      AND (CONVERT(DATETIME, ZUT2.ZuteilungVon, 104) < @FirstOfNextMonth
                                                      AND (CONVERT(DATETIME, ZUT2.ZuteilungBis, 104) >= @FirstOfMonth OR ZUT2.ZuteilungBis IS NULL))))
      
      AND (@KursID IS NULL OR KAR.BaPersonID IN (SELECT DISTINCT IBI.BaPersonID
                                             FROM dbo.KaIntegBildung IBI WITH (READUNCOMMITTED) 
                                             WHERE (IBI.KaKurserfassungID = @KursID 
                                                    AND CONVERT(DATETIME, IBI.Eintritt, 104) < @FirstOfNextMonth
                                                    AND CONVERT(DATETIME, IBI.Austritt, 104) >= @FirstOfMonth))
                                                OR KAR.BaPersonID IN (SELECT DISTINCT LEI.BaPersonID 
                                                                  FROM FaLeistung LEI WITH (READUNCOMMITTED)
                                                                  WHERE LEI.FaLeistungID IN (SELECT KAV.FaLeistungID 
                                                                                             FROM dbo.KaAbklaerungVertieft KAV WITH (READUNCOMMITTED) 
                                                                                             WHERE KAV.KaKurserfassungID = @KursID)))
  

  -----------------------------------------------------------------------------
  -- output
  -----------------------------------------------------------------------------
  DECLARE @MonatJahr VARCHAR(2000);
  DECLARE @LastDayOfMonth INT;
  
  SET @MonatJahr = CONVERT(VARCHAR, dbo.fnXMonat(@Monat)) + ' ' + CONVERT(VARCHAR, @Jahr);
  SET @LastDayOfMonth = DAY(dbo.fnLastDayOf(CONVERT(DATETIME, '01.' + CONVERT(VARCHAR, @Monat) + '.' + CONVERT(VARCHAR, @Jahr) , 104)));
  
  SELECT BaPersonID = T.BaPersonID,
         Monat      = dbo.fnXMonat(@Monat),
         Jahr       = @Jahr,
         MonatJahr  = @MonatJahr,
         Name       = PRS.Name,
         Vorname    = PRS.Vorname,
         Klient     = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
         --
         [V01] = T01.KaPraesenzcode_ShortText_V,
         [V02] = T02.KaPraesenzcode_ShortText_V,
         [V03] = T03.KaPraesenzcode_ShortText_V,
         [V04] = T04.KaPraesenzcode_ShortText_V,
         [V05] = T05.KaPraesenzcode_ShortText_V,
         [V06] = T06.KaPraesenzcode_ShortText_V,
         [V07] = T07.KaPraesenzcode_ShortText_V,
         [V08] = T08.KaPraesenzcode_ShortText_V,
         [V09] = T09.KaPraesenzcode_ShortText_V,
         [V10] = T10.KaPraesenzcode_ShortText_V,
         [V11] = T11.KaPraesenzcode_ShortText_V,
         [V12] = T12.KaPraesenzcode_ShortText_V,
         [V13] = T13.KaPraesenzcode_ShortText_V,
         [V14] = T14.KaPraesenzcode_ShortText_V,
         [V15] = T15.KaPraesenzcode_ShortText_V,
         [V16] = T16.KaPraesenzcode_ShortText_V,
         [V17] = T17.KaPraesenzcode_ShortText_V,
         [V18] = T18.KaPraesenzcode_ShortText_V,
         [V19] = T19.KaPraesenzcode_ShortText_V,
         [V20] = T20.KaPraesenzcode_ShortText_V,
         [V21] = T21.KaPraesenzcode_ShortText_V,
         [V22] = T22.KaPraesenzcode_ShortText_V,
         [V23] = T23.KaPraesenzcode_ShortText_V,
         [V24] = T24.KaPraesenzcode_ShortText_V,
         [V25] = T25.KaPraesenzcode_ShortText_V,
         [V26] = T26.KaPraesenzcode_ShortText_V,
         [V27] = T27.KaPraesenzcode_ShortText_V,
         [V28] = T28.KaPraesenzcode_ShortText_V,
         [V29] = T29.KaPraesenzcode_ShortText_V,
         [V30] = T30.KaPraesenzcode_ShortText_V,
         [V31] = T31.KaPraesenzcode_ShortText_V,

         [N01] = T01.KaPraesenzcode_ShortText_N,
         [N02] = T02.KaPraesenzcode_ShortText_N,
         [N03] = T03.KaPraesenzcode_ShortText_N,
         [N04] = T04.KaPraesenzcode_ShortText_N,
         [N05] = T05.KaPraesenzcode_ShortText_N,
         [N06] = T06.KaPraesenzcode_ShortText_N,
         [N07] = T07.KaPraesenzcode_ShortText_N,
         [N08] = T08.KaPraesenzcode_ShortText_N,
         [N09] = T09.KaPraesenzcode_ShortText_N,
         [N10] = T10.KaPraesenzcode_ShortText_N,
         [N11] = T11.KaPraesenzcode_ShortText_N,
         [N12] = T12.KaPraesenzcode_ShortText_N,
         [N13] = T13.KaPraesenzcode_ShortText_N,
         [N14] = T14.KaPraesenzcode_ShortText_N,
         [N15] = T15.KaPraesenzcode_ShortText_N,
         [N16] = T16.KaPraesenzcode_ShortText_N,
         [N17] = T17.KaPraesenzcode_ShortText_N,
         [N18] = T18.KaPraesenzcode_ShortText_N,
         [N19] = T19.KaPraesenzcode_ShortText_N,
         [N20] = T20.KaPraesenzcode_ShortText_N,
         [N21] = T21.KaPraesenzcode_ShortText_N,
         [N22] = T22.KaPraesenzcode_ShortText_N,
         [N23] = T23.KaPraesenzcode_ShortText_N,
         [N24] = T24.KaPraesenzcode_ShortText_N,
         [N25] = T25.KaPraesenzcode_ShortText_N,
         [N26] = T26.KaPraesenzcode_ShortText_N,
         [N27] = T27.KaPraesenzcode_ShortText_N,
         [N28] = T28.KaPraesenzcode_ShortText_N,
         [N29] = T29.KaPraesenzcode_ShortText_N,
         [N30] = T30.KaPraesenzcode_ShortText_N,
         [N31] = T31.KaPraesenzcode_ShortText_N,
         --
         Day28 = CASE WHEN @LastDayOfMonth > 27 THEN '28' ELSE '' END,
         Day29 = CASE WHEN @LastDayOfMonth > 28 THEN '29' ELSE '' END,
         Day30 = CASE WHEN @LastDayOfMonth > 29 THEN '30' ELSE '' END,
         Day31 = CASE WHEN @LastDayOfMonth > 30 THEN '31' ELSE '' END,
         --
         [Stat01]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 1) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 1))) / 2,
         
         [Stat02]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 2) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 2))) / 2,
                                                                 
         [Stat03]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 3) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 3))) / 2,
         
         [Stat04]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 4) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 4))) / 2,
         
         [Stat05]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 5) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 5))) / 2,                                                                          
         
         [Stat06]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 7) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 7))) / 2,
         
         [Stat07]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 6) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 6))) / 2,
         
         [Stat08]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 9) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 9))) / 2,
         
         [Stat09]  = (SELECT TageAnwesend * 100 / CASE WorkingDays WHEN 0 THEN 1 ELSE WorkingDays END
                      FROM(
                           SELECT TageAnwesend = SUM(CASE WHEN AM_AnwCode IN (1,2,3,4,5,7,8,9) 
                                                           AND PM_AnwCode IN (1,2,3,4,5,7,8,9) THEN 2
                                                          WHEN AM_AnwCode IN (1,2,3,4,5,7,8,9) THEN 1
                                                          WHEN PM_AnwCode IN (1,2,3,4,5,7,8,9) THEN 1
                                                          ELSE 0
                                                     END),
                                  WorkingDays  = SUM(CASE WHEN AM_AnwCode = 11 
                                                           AND PM_AnwCode = 11 THEN 0
                                                          WHEN AM_AnwCode = 11 THEN 1
                                                          WHEN PM_AnwCode = 11 THEN 1
                                                          ELSE 2
                                                     END)
                           FROM @tmp TI
                           WHERE TI.BaPersonID = T.BaPersonID
                      ) TMP),
         
         [Stat10]  = CONVERT(FLOAT, ((SELECT COUNT(1) 
                                      FROM @tmp 
                                      WHERE BaPersonID = T.BaPersonID 
                                        AND AM_AnwCode = 8) + (SELECT COUNT(1) 
                                                               FROM @tmp 
                                                               WHERE BaPersonID = T.BaPersonID 
                                                                 AND PM_AnwCode = 8))) / 2,
         
         -- Bestimmung der Farben (Inaktiv -> 0: mittel, Code erfasst -> 1:weiss, Wochenende -> 3: dunkel)
         Color01 = CASE WHEN T01.Color IS NOT NULL THEN T01.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color02 = CASE WHEN T02.Color IS NOT NULL THEN T02.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 02)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color03 = CASE WHEN T03.Color IS NOT NULL THEN T03.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 03)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color04 = CASE WHEN T04.Color IS NOT NULL THEN T04.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 04)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color05 = CASE WHEN T05.Color IS NOT NULL THEN T05.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 05)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color06 = CASE WHEN T06.Color IS NOT NULL THEN T06.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 06)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color07 = CASE WHEN T07.Color IS NOT NULL THEN T07.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 07)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color08 = CASE WHEN T08.Color IS NOT NULL THEN T08.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 08)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color09 = CASE WHEN T09.Color IS NOT NULL THEN T09.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 09)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color10 = CASE WHEN T10.Color IS NOT NULL THEN T10.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 10)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color11 = CASE WHEN T11.Color IS NOT NULL THEN T11.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 11)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color12 = CASE WHEN T12.Color IS NOT NULL THEN T12.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 12)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color13 = CASE WHEN T13.Color IS NOT NULL THEN T13.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 13)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color14 = CASE WHEN T14.Color IS NOT NULL THEN T14.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 14)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color15 = CASE WHEN T15.Color IS NOT NULL THEN T15.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 15)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color16 = CASE WHEN T16.Color IS NOT NULL THEN T16.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 16)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color17 = CASE WHEN T17.Color IS NOT NULL THEN T17.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 17)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color18 = CASE WHEN T18.Color IS NOT NULL THEN T18.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 18)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color19 = CASE WHEN T19.Color IS NOT NULL THEN T19.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 19)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color20 = CASE WHEN T20.Color IS NOT NULL THEN T20.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 20)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color21 = CASE WHEN T21.Color IS NOT NULL THEN T21.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 21)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color22 = CASE WHEN T22.Color IS NOT NULL THEN T22.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 22)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color23 = CASE WHEN T23.Color IS NOT NULL THEN T23.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 23)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color24 = CASE WHEN T24.Color IS NOT NULL THEN T24.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 24)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color25 = CASE WHEN T25.Color IS NOT NULL THEN T25.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 25)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color26 = CASE WHEN T26.Color IS NOT NULL THEN T26.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 26)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color27 = CASE WHEN T27.Color IS NOT NULL THEN T27.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 27)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color28 = CASE WHEN T28.Color IS NOT NULL THEN T28.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 28)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color29 = CASE WHEN T29.Color IS NOT NULL THEN T29.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 29)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color30 = CASE WHEN T30.Color IS NOT NULL THEN T30.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 30)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END,
         Color31 = CASE WHEN T31.Color IS NOT NULL THEN T31.Color
                        WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 31)) IN (@Saturday, @Sunday) THEN 3
                        ELSE 0
                   END
  FROM (SELECT DISTINCT BaPersonID FROM @tmp)          T
    INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID

    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 01) T01
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 02) T02
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 03) T03
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 04) T04
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 05) T05
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 06) T06
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 07) T07
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 08) T08
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 09) T09
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 10) T10

    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 11) T11
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 12) T12
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 13) T13
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 14) T14
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 15) T15
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 16) T16
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 17) T17
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 18) T18
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 19) T19
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 20) T20
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 21) T21
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 22) T22
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 23) T23
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 24) T24
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 25) T25
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 26) T26
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 27) T27
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 28) T28
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 29) T29
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 30) T30
    OUTER APPLY (SELECT AM_AnwCode,
                        KaPraesenzcode_ShortText_V = dbo.fnLOVShortText('KaPraesenzCode', AM_AnwCode),
                        PM_AnwCode,
                        KaPraesenzcode_ShortText_N = dbo.fnLOVShortText('KaPraesenzCode', PM_AnwCode),

                        Color = CASE  WHEN AM_AnwCode IS NOT NULL AND AM_AnwCode IS NOT NULL                THEN 1  --Code erfasst  -> 1:weiss
                                      WHEN DATEPART(dw, dbo.fnDateSerial(@Jahr, @Monat, 01)) IN (@Saturday, @Sunday)  THEN 3  --Wochenende    -> 3: dunkel
                                      ELSE 0                                                                        --Inaktiv       -> 0: mittel
                                END
                 FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 31) T31
  ORDER BY PRS.Name, PRS.Vorname;
END;
GO