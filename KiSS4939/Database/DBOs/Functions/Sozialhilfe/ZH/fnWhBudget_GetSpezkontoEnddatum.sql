SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhBudget_GetSpezkontoEnddatum
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnWhBudget_GetSpezkontoEnddatum.sql $
  $Author: Mminder $
  $Modtime: 2.09.10 14:02 $
  $Revision: 8 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnWhBudget_GetSpezkontoEnddatum.sql $
 * 
 * 8     24.09.10 17:35 Mminder
 * #???? Enddatumsberechnung Abzahlungskonto verbessert
 * 
 * 7     30.03.10 10:27 Mminder
 * #5783: Korrekte Berechnung des Enddatums auch wenn keine Kandidaten
 * vorhanden sind (alle Budgets grün, kein neuer Finanzplan erstellt)
 * 
 * 6     24.03.10 18:00 Mminder
 * #5783: Monate, in denen der Beleg, in den die Verrechnung integriert
 * wird, gesperrt oder storniert ist, werden als nicht verbucht
 * betrachtet. Dies ist eine Angleichung an die Saldoberechnung der
 * Spezkonto-Maske
 * 
 * 5     11.12.09 11:01 Lloreggia
 * Header aktualisiert
 * 
 * 4     10.08.09 11:06 Mmarghitola
 * #4870: Veränderung teilweise rückgängig machen (da Nebenwirkungen bei
 * Verrechnungskonto entstehen können. Die problematische Veränderung kam
 * nie auf Produktion).
 * 
 * 2     18.06.09 10:15 Mmarghitola
 * #97: Berechnung in Spezialfällen korrigieren (verbuchte Einträge nach
 * letztem Kandidat, keine Monatsbudgets vorhanden)
 * 
 * 1     19.05.09 18:40 Mminder
 * #97: Nachkorrektur, DatumBis von Verrechnungen wird nun auch über den
 * letzten FP hinaus korrekt berechnet
=================================================================================================*/

CREATE FUNCTION [dbo].[fnWhBudget_GetSpezkontoEnddatum]
(
  @BgSpezkontoID      int,
  @DatumVon_SpezKonto datetime,
  @StartSaldo         money,
  @BetragProMonat     money,
  @Inaktiv            bit
)
RETURNS datetime
AS BEGIN

  DECLARE @Months TABLE
  (
    Monat          INT,
    Jahr           INT,
    BgFinanzplanID INT,
    Verbucht       BIT   DEFAULT(0),
    Kandidat       BIT   DEFAULT(0),
    Betrag         MONEY DEFAULT ($0.00)
  )

  DECLARE @FaLeistungID int
  SELECT @FaLeistungID = FaLeistungID
  FROM dbo.BgSpezkonto
  WHERE BgSpezkontoID = @BgSpezkontoID

  -- zuerst bestimmen, welche Monate aufgrund der Finanzpläne überhaupt in Frage kommen
  INSERT INTO @Months (Monat, Jahr, BgFinanzplanID)
  SELECT MON.Code, JHR.Jahr, BFP.BgFinanzplanID
  FROM BgFinanzplan BFP
    INNER JOIN (SELECT BgFinanzplanID, Jahr = DatePart(yyyy,DatumVon)
                FROM BgFinanzplan
                UNION
                SELECT BgFinanzplanID, Jahr = DatePart(yyyy,DatumBis)
                FROM BgFinanzplan) JHR ON JHR.BgFinanzplanID = BFP.BgFinanzplanID
    INNER JOIN XLOVCode     MON ON MON.LOVName = 'Monat' AND BFP.DatumVon <= dbo.fnDateSerial(JHR.Jahr,MON.Code,1) AND
                                                             BFP.DatumBis >= dbo.fnDateSerial(JHR.Jahr,MON.Code,1)
  WHERE BFP.FaLeistungID = @FaLeistungID AND dbo.fnDateSerial(JHR.Jahr,MON.Code,1) >= @DatumVon_SpezKonto


  UPDATE MON
  SET Verbucht = CASE WHEN BPO.BgPositionID IS NOT NULL AND (BPO.Betrag - BPO.Reduktion) <> 0 AND BUD.BgBewilligungStatusCode IN (1, 5) /*grau,grün*/ AND (STA.KbBuchungStatusCode IS NULL OR STA.KbBuchungStatusCode NOT IN (7,8)) THEN 1 ELSE 0 END,
      Kandidat = CASE WHEN BUD.BgBudgetID IS NULL OR BUD.BgBewilligungStatusCode = 1 AND BPO.BgPositionID IS NULL THEN 1 ELSE 0 END,
      Betrag   = CASE WHEN BPO.BgPositionID IS NOT NULL AND BUD.BgBewilligungStatusCode IN (1, 5) /*grau,grün*/ AND (STA.KbBuchungStatusCode IS NULL OR STA.KbBuchungStatusCode NOT IN (7,8)) THEN (BPO.Betrag - BPO.Reduktion) ELSE $0.00 END
  FROM @Months MON
    LEFT  JOIN dbo.BgBudget     BUD ON BUD.BgFinanzplanID = MON.BgFinanzplanID AND
                                       BUD.MasterBudget   = 0 AND
                                       BUD.Jahr           = MON.Jahr AND
                                       BUD.Monat          = MON.Monat
    LEFT  JOIN dbo.BgPosition BPO ON BPO.BgBudgetID = BUD.BgBudgetID AND BPO.BgSpezkontoID = @BgSpezkontoID AND BPO.BgKategorieCode = 3 AND (BPO.Betrag - BPO.Reduktion) <> 0
    LEFT  JOIN (SELECT KBK.BgPositionID, KbBuchungStatusCode = MAX(KBU.KbBuchungStatusCode)
                FROM dbo.KbBuchungKostenart KBK
                  INNER JOIN dbo.KbBuchung  KBU ON KBU.KbBuchungID  = KBK.KbBuchungID
                WHERE KBU.StorniertKbBuchungID IS NULL
                GROUP BY KBK.BgPositionID) STA ON STA.BgPositionID = BPO.BgPositionID

  DECLARE @MonthCount int,
          @RestBetrag money,
          @EndDatum   datetime

  SELECT @RestBetrag = @StartSaldo - IsNull(SUM(Betrag),0)
  FROM @Months
  WHERE IsNull(Betrag,0) <> 0

  IF @RestBetrag <= $0.00 BEGIN

    -- Falls Verrechnung beendet, ist das letzte Budget mit verbuchter Verrechnung das Ende der Verrechnung
    SELECT TOP 1 @EndDatum = dbo.fnLastDayOf(dbo.fnDateSerial(Jahr, Monat, 1))
    FROM @Months
    WHERE Verbucht = 1
    ORDER BY Jahr DESC, Monat DESC

  END
  ELSE IF @Inaktiv = 1 BEGIN
    SET @EndDatum = NULL
  END
  ELSE IF (SELECT COUNT(*) FROM @Months) = 0 BEGIN -- Keine Monatsbudgets bisher vorhanden
    SET @MonthCount = CEILING(@RestBetrag / @BetragProMonat)
	SET @EndDatum = dbo.fnLastDayOf(DateAdd(m, @MonthCount - 1,@DatumVon_SpezKonto))
  END
  ELSE BEGIN
    SET @MonthCount = CEILING(@RestBetrag / @BetragProMonat)

    DECLARE @KandidatenCount int,
            @LetzterKandidatMonat datetime,
            @NichtKandidatenNachLetztemKandidat int
    SELECT @KandidatenCount = Count(*), @LetzterKandidatMonat = MAX(dbo.fnDateSerial(Jahr, Monat, 1))
    FROM @Months
    WHERE Kandidat = 1

    IF @KandidatenCount >= @MonthCount BEGIN

      -- #6860: Versuch, die fehlerhafte Optimierung durch einen Zwischenschritt zu verhindern
      ;WITH TopNKandidaten AS
        (
          SELECT TOP (@MonthCount) * FROM @Months WHERE Kandidat = 1 ORDER BY Jahr ASC, Monat ASC
        ),
        LetzerVerbuchterMonat AS
        (
          SELECT TOP 1 Monat, Jahr FROM @Months WHERE Verbucht = 1 ORDER BY Jahr DESC, Monat DESC
        )
      -- (2)...und dann den letzten davon nehmen
      SELECT TOP 1 @EndDatum = dbo.fnLastDayOf(dbo.fnDateSerial(TMP.Jahr, TMP.Monat, 1))
      FROM
      (
        -- (1)zuerst die nächsten n Kandidaten selektieren...
        SELECT Monat, Jahr
        FROM TopNKandidaten
		UNION -- bereits verbuchte Einträge können nach den letzten Kandidaten liegen
		SELECT Monat, Jahr
        FROM LetzerVerbuchterMonat
      ) TMP
      ORDER BY TMP.Jahr DESC, TMP.Monat DESC;
    END
    ELSE BEGIN
      -- Fallback, wenn keine Kandidaten vorhanden sind (alle Budgets grün, noch kein neuer FP erstellt)
      -- Daten für den folgenden 'fiktiven' Kandidaten bereitstellen
      IF @LetzterKandidatMonat IS NULL BEGIN
        SELECT @LetzterKandidatMonat = DATEADD(m,1,MAX(dbo.fnDateSerial(Jahr, Monat, 1)))
        FROM @Months
        SET @KandidatenCount = 1
      END

      -- rein theoretisch könnte es grüne Budgets nach dem letzten Kandidaten haben mit einer inaktiven Verrechnung
      -- diese verzögern das Enddatum
      SELECT @NichtKandidatenNachLetztemKandidat = Count(*)
      FROM   @Months
      WHERE  Kandidat = 0 AND dbo.fnDateSerial(Jahr, Monat, 1) > @LetzterKandidatMonat

      -- den letzten 
      SELECT @EndDatum = dbo.fnLastDayOf(DateAdd(m,@MonthCount-@KandidatenCount+@NichtKandidatenNachLetztemKandidat,@LetzterKandidatMonat))
    END
  END
  RETURN @EndDatum
END

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
