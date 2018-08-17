SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject fnShGetSpezkontoEnddatum;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnShGetSpezkontoEnddatum.sql $
  $Author: Tabegglen $
  $Modtime: 10.06.10 11:07 $
  $Revision: 13 $
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
  $Log: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnShGetSpezkontoEnddatum.sql $
 * 
 * 11    10.06.10 11:10 Tabegglen
 * Removed the null-character VSS added to the comment of the previous
 * submission, making the file invalid.
 * 
 * 10    10.06.10 10:59 Tabegglen
 * #6271 + #5887: Wenn StartSaldo = 0.00, muss das DatumBis trotzdem
 * berechnet werden. Die dazu nötige Code-Stelle wurde irrtümlich in einer
 * vorherigen Revision entfernt.
 * 
 * 9     12.05.10 11:07 Tabegglen
 * #4374: Wenn der Abzahlungs-Betrag in einem Monatsbudget verändert wird,
 * muss das Bis-Datum des Spezialkontos neuberechnet werden
 * 
 * 8     10.05.10 17:47 Tabegglen
 * #4374: aktualisierte Functions und StoredProcedures müssen auch im
 * Dispatcher referenziert werden
 * 
 * 7     21.04.10 14:17 Tabegglen
 * #5887: Wenn Finanzplan keine weiteren Budgets hat, aber das
 * Abzahlungskonto noch einen Restsaldo aufweist, wird das EndDatum
 * trotzdem berechnet (notfalls in einen fiktiven Finanzplan).
 * 
 * 6     21.04.10 13:49 Tabegglen
 * #5887: Funktion berechnet Enddatum auch bei StartSaldo = 0.00 -->
 * Letzter Tag des StartMonats
 * 
 * 5     16.12.09 18:21 Mminder
 * #4915: Bei aufgehobener Kürzung wird als Enddatum der letzte verbuchte
 * Monat angegeben
 * 
 * 4     16.12.09 13:56 Mminder
 * #4915: Testfeedback 2. Runde: Es werden nicht mehr Kürzungspositionen
 * erstellt als Monate definiert sind
 * 
 * 3     14.12.09 10:29 Mminder
 * #4915: Das Enddatum darf nicht vor dem StartDatum liegen
 * 
 * 2     27.11.09 7:46 Nweber
 * VSS comment contained invalid char: NUL (null) with ASCII value 0
 * 
 * 1     18.11.09 13:32 Mminder
 * #4915: Kürzungen eingeführt
 * 
=================================================================================================*/

CREATE FUNCTION dbo.fnShGetSpezkontoEnddatum
(
  @BgSpezkontoID          INT,
  @DatumVon_SpezKonto     DATETIME,
  @StartSaldo             MONEY,
  @BetragProMonat         MONEY,
  @Inaktiv                BIT,
  @KuerzungLaufzeitMonate INT
)
RETURNS datetime
AS BEGIN

  DECLARE @Months TABLE
  (
    Monat          INT,
    Jahr           INT,
    BgFinanzplanID INT,
    Verbucht       BIT DEFAULT(0),
    Kandidat       BIT DEFAULT(0),
    Betrag         MONEY DEFAULT ($0.00)
  );

  DECLARE @FaLeistungID       INT,
          @BgSpezkontoTypCode INT,
          @BgKategorieCode    INT;

  SELECT 
    @FaLeistungID       = FaLeistungID, 
    @BgSpezkontoTypCode = BgSpezkontoTypCode,
    @BgKategorieCode    = CASE BgSpezkontoTypCode 
                            WHEN 3 THEN 3 
                            WHEN 4 THEN 4 
                          END 
  FROM dbo.BgSpezkonto WITH (READUNCOMMITTED)
  WHERE BgSpezkontoID = @BgSpezkontoID;

  IF (@StartSaldo = 0 AND @BgSpezkontoTypCode = 3)
  BEGIN
    RETURN dbo.fnLastDayOf(@DatumVon_SpezKonto);
  END;

  IF (@BetragProMonat = 0)
  BEGIN
    RETURN dbo.fnLastDayOf(@DatumVon_SpezKonto);
  END;

  -- zuerst bestimmen, welche Monate aufgrund der Finanzpläne überhaupt in Frage kommen
  INSERT INTO @Months (Monat, Jahr, BgFinanzplanID)
  SELECT MON.Code, 
         JHR.Jahr, 
         BFP.BgFinanzplanID
  FROM dbo.BgFinanzplan BFP WITH (READUNCOMMITTED)
    INNER JOIN (SELECT BgFinanzplanID, 
                       Jahr = DATEPART(yyyy, DatumVon)
                FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
                UNION
                SELECT BgFinanzplanID, Jahr = DATEPART(yyyy, DatumBis)
                FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)) JHR ON JHR.BgFinanzplanID = BFP.BgFinanzplanID
    INNER JOIN dbo.XLOVCode MON WITH (READUNCOMMITTED) 
                                ON MON.LOVName = 'Monat' 
                               AND dbo.fnFirstDayOf(BFP.DatumVon) <= dbo.fnDateSerial(JHR.Jahr, MON.Code, 1) 
                               AND dbo.fnLastDayOf(BFP.DatumBis) >= dbo.fnDateSerial(JHR.Jahr, MON.Code, 1)
  WHERE BFP.FaLeistungID = @FaLeistungID 
    AND dbo.fnDateSerial(JHR.Jahr, MON.Code, 1) >= @DatumVon_SpezKonto;

  UPDATE MON
  SET Verbucht = CASE WHEN BPO.BetragBudget <> 0 AND BUD.BgBewilligungStatusCode IN (1, 5) /*grau,grün*/ THEN 1 ELSE 0 END,
      Kandidat = CASE WHEN BUD.BgBudgetID IS NULL THEN 1 ELSE 0 END,
      Betrag   = CASE WHEN BUD.BgBewilligungStatusCode IN (1, 5) /*grau,grün*/  THEN BPO.BetragBudget ELSE $0.00 END
  FROM @Months MON
    LEFT  JOIN dbo.BgBudget     BUD WITH (READUNCOMMITTED)
                                    ON BUD.BgFinanzplanID = MON.BgFinanzplanID 
                                   AND BUD.MasterBudget   = 0 
                                   AND BUD.Jahr           = MON.Jahr 
                                   AND BUD.Monat          = MON.Monat
    LEFT  JOIN dbo.vwBgPosition BPO WITH (READUNCOMMITTED)
                                    ON BPO.BgBudgetID = BUD.BgBudgetID 
                                   AND BPO.BgSpezkontoID = @BgSpezkontoID 
                                   AND BPO.BgKategorieCode = @BgKategorieCode 
                                   AND BPO.BetragBudget <> 0;

  -- Abschlussposition des Spezkontos auch berücksichtigen
  INSERT INTO @Months (Monat, Jahr, Verbucht, Betrag)
  SELECT Monat    = MONTH(Created),
         Jahr     = YEAR(Created),
         Verbucht = 1,
         Betrag   = Betrag
  FROM dbo.BgSpezkontoAbschluss WITH (READUNCOMMITTED)
  WHERE BgSpezkontoID = @BgSpezkontoID;

  DECLARE @MonthCount         INT,
          @RestBetrag         MONEY,
          @EndDatum           DATETIME,
          @KuerzungRestMonate INT;

  SELECT @RestBetrag = @StartSaldo - ISNULL(SUM(Betrag),0)
  FROM @Months
  WHERE ISNULL(Betrag,0) <> 0;

  SELECT @KuerzungRestMonate = @KuerzungLaufzeitMonate - ISNULL(COUNT(*),0)
  FROM @Months
  WHERE Verbucht = 1;

  IF (@BgSpezkontoTypCode = 3 AND @RestBetrag <= $0.00)
  BEGIN
    -- Falls Verrechnung beendet, ist das letzte Budget mit verbuchter Verrechnung das Ende der Verrechnung
    SELECT TOP 1 @EndDatum = dbo.fnLastDayOf(dbo.fnDateSerial(Jahr, Monat, 1))
    FROM @Months
    WHERE Betrag <> $0.00
    ORDER BY Jahr DESC, Monat DESC;
  END
  ELSE IF (@Inaktiv = 1)
  BEGIN
    IF (@BgSpezkontoTypCode = 4)
    BEGIN -- Eine aufgehobene Kürzung ist in dem Monat fertig, in dem zum letzten Mal darauf gebucht wurde
      SELECT TOP 1 @EndDatum = dbo.fnLastDayOf(dbo.fnDateSerial(Jahr, Monat, 1))
      FROM @Months
      WHERE Verbucht = 1
      ORDER BY Jahr DESC, Monat DESC;
    END
    ELSE 
    BEGIN
      SET @EndDatum = NULL;
    END;
  END
  ELSE IF (SELECT COUNT(*) FROM @Months) = 0 
  BEGIN -- Keine Monatsbudgets bisher vorhanden
    IF (@BgSpezkontoTypCode = 4)
    BEGIN
      SET @EndDatum = dbo.fnLastDayOf(DATEADD(m, @KuerzungRestMonate - 1, @DatumVon_SpezKonto));
    END
    ELSE 
    BEGIN
      SET @MonthCount = CEILING(@RestBetrag / @BetragProMonat);
      SET @EndDatum = dbo.fnLastDayOf(DATEADD(m, @MonthCount - 1, @DatumVon_SpezKonto));
    END
  END
  ELSE 
  BEGIN
    IF (@BgSpezkontoTypCode = 4)
    BEGIN
      SET @MonthCount = @KuerzungRestMonate;
    END
    ELSE 
    BEGIN
      SET @MonthCount = CEILING(@RestBetrag / @BetragProMonat);
    END;

    IF (@MonthCount < 0)
    BEGIN
      SET @MonthCount = 0;
    END;

    DECLARE @KandidatenCount                    INT,
            @LetzterKandidatMonat               DATETIME,
            @NichtKandidatenNachLetztemKandidat INT;

    SELECT @KandidatenCount = COUNT(*), 
           @LetzterKandidatMonat = MAX(dbo.fnDateSerial(Jahr, Monat, 1))
    FROM @Months
    WHERE Kandidat = 1;

    IF (@KandidatenCount >= @MonthCount)
    BEGIN
      -- (2)...und dann den letzten davon nehmen
      SELECT TOP 1 @EndDatum = dbo.fnLastDayOf(dbo.fnDateSerial(TMP.Jahr, TMP.Monat, 1))
      FROM (
        -- (1)zuerst die nächsten n Kandidaten selektieren...
        SELECT TOP (@MonthCount) *
        FROM @Months
        WHERE Kandidat = 1
        ORDER BY Jahr, Monat

        UNION -- bereits verbuchte Einträge können nach den letzten Kandidaten liegen

        SELECT TOP 1 *
        FROM @Months
        WHERE Verbucht = 1
        ORDER BY Jahr DESC, Monat DESC
      ) TMP
      ORDER BY TMP.Jahr DESC, TMP.Monat DESC;
    END
    ELSE 
    BEGIN
      -- Fallback, wenn keine Kandidaten vorhanden sind (alle Budgets grün, noch kein neuer FP erstellt)
      -- Daten für den folgenden 'fiktiven' Kandidaten bereitstellen
      IF (@LetzterKandidatMonat IS NULL)
      BEGIN
        SELECT @LetzterKandidatMonat = DATEADD(m, 1, MAX(dbo.fnDateSerial(Jahr, Monat, 1)))
        FROM @Months
        SET @KandidatenCount = 1;
      END;

      -- rein theoretisch könnte es grüne Budgets nach dem letzten Kandidaten haben mit einer inaktiven Verrechnung
      -- diese verzögern das Enddatum
      SELECT @NichtKandidatenNachLetztemKandidat = COUNT(*)
      FROM   @Months
      WHERE  Kandidat = 0 
        AND dbo.fnDateSerial(Jahr, Monat, 1) > @LetzterKandidatMonat;

      -- den letzten 
      SELECT @EndDatum = dbo.fnLastDayOf(DateAdd(m, @MonthCount - @KandidatenCount + @NichtKandidatenNachLetztemKandidat, @LetzterKandidatMonat));
    END;
  END;
  
  -- Das Enddatum darf nicht vor dem StartDatum liegen
  IF (@DatumVon_SpezKonto > @EndDatum)
  BEGIN
    SET @EndDatum = dbo.fnLastDayOf(@DatumVon_SpezKonto);
  END;

  RETURN @EndDatum;
END;
GO

SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
  
