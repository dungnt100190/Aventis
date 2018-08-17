SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhBudget_GetSpezkontoEnddatumTest;
GO
/*===============================================================================================
  $Revision: 1 $
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

CREATE PROCEDURE dbo.spWhBudget_GetSpezkontoEnddatumTest
(
  @BgSpezkontoID      int,
  @DatumVon_SpezKonto datetime,
  @StartSaldo         money,
  @BetragProMonat     money,
  @Inaktiv            bit
)
AS BEGIN

insert BgSpezkontoTest (Pos,Info) values ('*************************','')
insert BgSpezkontoTest (Pos,Info) values ('Input @BgSpezkontoID',convert(varchar,@BgSpezkontoID))
insert BgSpezkontoTest (Pos,Info) values ('Input @DatumVon_SpezKonto',convert(varchar,@DatumVon_SpezKonto,104))
insert BgSpezkontoTest (Pos,Info) values ('Input @StartSaldo',convert(varchar,@StartSaldo))
insert BgSpezkontoTest (Pos,Info) values ('Input @BetragProMonat',convert(varchar,@BetragProMonat))
insert BgSpezkontoTest (Pos,Info) values ('Input @Inaktiv',convert(varchar,@Inaktiv))


  DECLARE @Months TABLE
  (
    Monat    int,
    Jahr     int,
    Verbucht bit DEFAULT(0),
    Kandidat bit DEFAULT(0),
    Betrag   money DEFAULT ($0.00)
  )

  DECLARE @FaLeistungID int
  SELECT @FaLeistungID = FaLeistungID
  FROM dbo.BgSpezkonto
  WHERE BgSpezkontoID = @BgSpezkontoID

  -- zuerst bestimmen, welche Monate aufgrund der Finanzpläne überhaupt in Frage kommen
  INSERT INTO @Months (Monat, Jahr)
  SELECT MON.Code, JHR.Jahr
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
  SET Verbucht = CASE WHEN BPO.Betrag <> 0 AND BUD.BgBewilligungStatusCode >= 5 /*grün*/ AND BUC.Gesperrt <> 1 THEN 1 ELSE 0 END,
      Kandidat = CASE WHEN BUD.BgBudgetID IS NULL OR BUD.BgBewilligungStatusCode < 5 THEN 1 ELSE 0 END,
      Betrag   = CASE WHEN BUD.BgBewilligungStatusCode >= 5 /*grün*/ THEN BPO.Betrag ELSE $0.00 END
  FROM @Months MON
    INNER JOIN BgFinanzplan BFP ON BFP.FaLeistungID   = @FaLeistungID
    LEFT  JOIN BgBudget     BUD ON BUD.BgFinanzplanID = BFP.BgFinanzplanID AND
                                   BUD.MasterBudget   = 0 AND
                                   BUD.Jahr           = MON.Jahr AND
                                   BUD.Monat          = MON.Monat
    LEFT  JOIN BgPosition   BPO ON BPO.BgBudgetID = BUD.BgBudgetID AND BPO.BgSpezkontoID = @BgSpezkontoID AND BPO.BgKategorieCode = 3 AND BPO.Betrag <> 0
	OUTER APPlY ( SELECT Gesperrt = MAX(CASE WHEN BUC.KbBuchungStatusCode = 7 THEN 1 ELSE 0 END) -- gesperrte Buchungen finden
				FROM KbBuchungKostenart BKA
					INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = BKA.KbBuchungID
				WHERE BKA.BgPositionID = BPO.BgPositionID
				) BUC

  DECLARE @MonthCount int,
          @RestBetrag money,
          @EndDatum   datetime

  SELECT @RestBetrag = @StartSaldo - IsNull(SUM(Betrag),0)
  FROM @Months

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
      -- (2)...und dann den letzten davon nehmen
      SELECT TOP 1 @EndDatum = dbo.fnLastDayOf(dbo.fnDateSerial(TMP.Jahr, TMP.Monat, 1))
      FROM
      (
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
      ORDER BY TMP.Jahr DESC, TMP.Monat DESC
    END
    ELSE BEGIN
      -- rein theoretisch könnte es grüne Budgets nach dem letzten Kandidaten haben mit einer inaktiven Verrechnung
      -- diese verzögern das Enddatum
      SELECT @NichtKandidatenNachLetztemKandidat = Count(*)
      FROM   @Months
      WHERE  Kandidat = 0 AND dbo.fnDateSerial(Jahr, Monat, 1) > @LetzterKandidatMonat

      -- den letzten 
      SELECT @EndDatum = dbo.fnLastDayOf(DateAdd(m,@MonthCount-@KandidatenCount+@NichtKandidatenNachLetztemKandidat,@LetzterKandidatMonat))
    END
  END

insert BgSpezkontoTest (Pos,Info) values ('Result @EndDatum',convert(varchar,@EndDatum,104))

  select @EndDatum
END
