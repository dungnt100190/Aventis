SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSMonatsBelege
GO
/*===============================================================================================
  $Revision: 16 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt eine Tabelle mit allen für BFS relevanten Buchungen zurück
    @AntragstellerID: ID der Person/Klient
    @LeistungsartCodes: Suche nach Leistungsarten
    @Jahr: Jahr des Erhebungsjahrs
    @Monat: Monat des Erhebungsjahrs

  RETURNS: relevanten Buchungen für einen Klienten und einen Monat
=================================================================================================
  TEST:
  SELECT * FROM dbo.fnBFSMonatsBelege(1, 1, 2010, 12);
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSMonatsBelege
(
  @AntragstellerID     INT,
  @BFSLeistungsartCode INT,
  @Jahr                INT,
  @Monat               INT,
  @GenauerMonat        INT = NULL
)
RETURNS @BgPosition TABLE
(
  BgPositionID        INT,
  BgPositionsartID    INT, 
  BgPositionsartCode  INT,
  BgKategorieCode     INT,
  BgGruppeCode        INT, 
  BFSVariable         VARCHAR(10),
  KontoNr             VARCHAR(10), 
  BaPersonID          INT,
  Betrag              MONEY,
  NettoBetrag         MONEY
)
AS BEGIN

  -- Steuert ob der Stichmonat zu berücksichtigen ist oder der übergebene Monat
  -- 0 = Stichmonat zu berücksichtigen, 1 = übergebene Monat berücksichtigen
  SET @GenauerMonat = ISNULL(@GenauerMonat, 0);
  DECLARE @FaProzessCode INT,
          @BuchungenVon DATETIME,
          @BuchungenBis DATETIME;
  
  -- BFSLeistungsartCode in Prozesscode umwandeln.
  SET @FaProzessCode = dbo.fnBFSLeistungsartTOProzess(@BFSLeistungsartCode);

  -- Letztes Monatsbudget im Jahr berechnen, welches als Stichmonat zählt (ausgeweitet auf 20.[Vormonat] - 10.[Nachmonat])
  IF (@GenauerMonat = 0)
  BEGIN
    SELECT TOP 1 @Monat = BDG.Monat
    FROM dbo.BgBudget             BDG
      INNER JOIN dbo.BgFinanzplan FPL ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
      INNER JOIN dbo.FaLeistung   LEI ON LEI.FaLeistungID = FPL.FaLeistungID
    WHERE LEI.BaPersonID = @AntragstellerID
      AND BDG.MasterBudget = 0
      AND BDG.Jahr = @Jahr
      AND LEI.FaProzessCode = @FaProzessCode
    ORDER BY BDG.Monat DESC;

    SET @BuchungenVon = DATEADD(MONTH, -1, dbo.fnDateSerial(@Jahr, @Monat, 20));
    SET @BuchungenBis = DATEADD(DAY, 10, dbo.fnLastDayOf(dbo.fnDateSerial(@Jahr, @Monat, 1)));
  END
  ELSE
  BEGIN
    SET @BuchungenVon = dbo.fnDateSerial(@Jahr, @Monat, 1);
    SET @BuchungenBis = dbo.fnLastDayOf(@BuchungenVon);
  END;

  -- Anstatt unten dbo.fnDateOf() zu gebrauchen, bringt die folgende Zeile ca. 20% mehr Performance
  SET @BuchungenBis = DATEADD(SECOND, -1, DATEADD(DAY, 1, @BuchungenBis));

  -- 
  INSERT INTO @BgPosition
  SELECT POS.BgPositionID,
         BPA.BgPositionsartID,
         BPA.BgPositionsartCode,
         POS.BgKategorieCode,
         BPA.BgGruppeCode,
         BPA.VarName,
         KOA.KontoNr,
         BaPersonID  = ISNULL(POS.BaPersonID, @AntragstellerID),
         Betrag      = CASE WHEN SPZ.BgSpezkontoTypCode IN (2, 3) 
                         THEN 0
                         ELSE SUM(POS.BetragBudget) / CASE WHEN COUNT(BUK.KbBuchungID) = 0 THEN 1 ELSE COUNT(BUK.KbBuchungID) END
                       END,
         NettoBetrag = ISNULL(SUM(BUK.Betrag), 0)
  FROM   dbo.FaLeistung LEI
    INNER JOIN dbo.BgFinanzplan       FPL  ON FPL.FaLeistungID = LEI.FaLeistungID
    INNER JOIN dbo.BgBudget           BDG  ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                                          AND BDG.MasterBudget = 0 -- nur Monatsbudgets
    INNER JOIN dbo.vwBgPosition       POS  ON POS.BgBudgetID = BDG.BgBudgetID
    LEFT  JOIN dbo.KbBuchungKostenart BUK  ON BUK.BgPositionID = POS.BgPositionID
    LEFT  JOIN dbo.KbBuchung          BUC  ON BUC.KbBuchungID = BUK.KbBuchungID
    LEFT  JOIN dbo.KbTransfer         TSF  ON TSF.KbBuchungID = BUC.KbBuchungID
                                          AND KbTransferStatusCode = 2 -- Übermittelt
    LEFT  JOIN dbo.KbZahlungslauf     ZLL  ON ZLL.KbZahlungslaufID = TSF.KbZahlungslaufID
    LEFT  JOIN dbo.KbOpAusgleich      AUS  ON AUS.OpBuchungID = BUC.KbBuchungID
                                          AND AUS.KbOpAusgleichID = (SELECT MAX(KbOpAusgleichID)
                                                                     FROM dbo.KbOpAusgleich
                                                                     WHERE OpBuchungID = BUC.KbBuchungID)
    LEFT  JOIN dbo.KbBuchung          BUC2 ON BUC2.KbBuchungID = AUS.AusgleichBuchungID
    LEFT  JOIN dbo.BgSpezkonto        SPZ  ON SPZ.BgSpezkontoID = POS.BgSpezkontoID
    LEFT  JOIN dbo.BgPositionsart     BPA  ON BPA.BgPositionsartID = COALESCE(POS.BgPositionsartID,     -- 1: direkt Positionsart aus Budgetposition
                                                                              SPZ.BgPositionsartID,     -- 2: Positionsart ist im Spezkonto hinterlegt
                                                                              (SELECT BgPositionsartID  -- 3: GBL? Positionsart von GBL-Art des FPs ableiten
                                                                               FROM BgPositionsart 
                                                                               WHERE BgPositionsartCode = FPL.WhGrundbedarfTypCode
                                                                                 AND BgKostenartID = ISNULL(SPZ.BgKostenartID, BgKostenartID)
                                                                                 AND dbo.fnDateSerial(@Jahr, @Monat, 1) BETWEEN ISNULL(DatumVon, '19000101') and Isnull(Datumbis,'99991231')), -- Bei EZ ab GBL ist SPZ.BgKostenartID NULL. BgPositionsartCode = FPL.WhGrundbedarfTypCode ist eigentlich genau genug
                                                                              (SELECT MIN(BgPositionsartID)  -- 4: last resort; einfach die erste Positionsart der Kostenart verwenden
                                                                               FROM BgPositionsart 
                                                                               WHERE BgKostenartID = SPZ.BgKostenartID))
    LEFT  JOIN dbo.BgKostenart        KOA  ON KOA.BgKostenartID = BPA.BgKostenartId
  WHERE LEI.BaPersonID = @AntragstellerID
    AND LEI.FaProzessCode = @FaProzessCode
    AND BDG.BgBewilligungStatusCode IN (5, 9) -- nur bewilligte und gesperrte Budgets
    AND (@GenauerMonat = 1 OR @Monat <> 12 OR BDG.Monat = @Monat AND BDG.Jahr = @Jahr) -- nur Zahlungen vom Dezemberbudget nehemen falls der Stichmonat Dezember ist.
    AND CASE
          -- nicht abgetretene Einnahmen (wenn nicht in Veraltung Sozialdienst), Kürzungen
          WHEN ((POS.BgKategorieCode = 1 AND POS.VerwaltungSD = 0) OR POS.BgKategorieCode = 4)
            THEN CASE WHEN BDG.Jahr = @Jahr AND BDG.Monat = @Monat THEN 1 ELSE 0 END
          -- ZahlauftragErstellt, ausgeglichen, teilweise ausgeglichen, verbucht
          -- grüne und ausgedruckte Barbelege
          -- bei Kunden ohne Klibu werden alle verbuchten Buchungen berücksichtigt
          WHEN BUC.KbBuchungStatusCode IN (3, 6, 10, 13) OR (BUC.KbBuchungStatusCode = 2 AND BUC.KbAuszahlungsArtCode = 103)
            THEN CASE WHEN COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum) BETWEEN @BuchungenVon AND @BuchungenBis
                        THEN 1 ELSE 0 END
          ELSE 0
        END = 1
  GROUP BY BPA.BgPositionsartID,
           BPA.BgPositionsartCode,
           POS.BgKategorieCode,
           BPA.BgGruppeCode,
           BPA.VarName,
           KOA.KontoNr,
           POS.BgPositionID,
           POS.BaPersonID,
           SPZ.BgSpezkontoTypCode;
  RETURN;
END;
GO