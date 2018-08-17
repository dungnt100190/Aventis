SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSMonatsBelege
GO
/*===============================================================================================
  $Revision: 8 $
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
=================================================================================================
  LOG:
  15.02.2011 : RHesterberg   : Korrektur, damit Einnahmen auch in SOSTAT aufgenommen werden
  27.01.2011 : RHesterberg   : Korrektur für Kontrolle Verbuchung
  24.01.2011 : RHesterberg   : Korrektur für Kunden ohne Klientenbuchhaltung

 * 5     19.08.10 11:00 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode. Viele Einträge
 * in BFSFrage haben im Feld HerkunftSQL Vergleichsoperationen auf
 * BgPositionsartID,
 * welche eigentlich auf BgPositionsartCode erfolgen sollten. 
 * - Anpassung fnBFSBudget + fnBFSMonatsBelege, so dass sie
 * BgPositionsartCode ebenfalls zurückgeben.
 * - Anpassung HerkunftSQL, so dass BgPositionsartCode für die
 * Vergleichsoperationen verwendet wird.
 * 
 * 4     21.05.10 12:05 Nweber
 * DBOs aktualisieren
 * 
 * 3     24.02.10 11:42 Ckaeser
 * ab KiSS 4 wird der Status bei nicht abgetretenen Einnahmen nicht mehr
 * gesetzt!?
 * 
 * 2     27.10.09 15:31 Mweber
 * Generelle Ueberarbeitung
 * Berücksichtigung von nicht abgetretenen Einnahmen und Barbelegen
 * 
 * 1     19.10.09 4:40 Mweber
 * 
 * 1     19.10.09 4:29 Mweber
 * neu
 * (ersetzt fnBFSBBudget und fnBFSMonatlicheZahlung)
=================================================================================================*/

CREATE FUNCTION [dbo].[fnBFSMonatsBelege]
 (@AntragstellerID     int,
  @BFSLeistungsartCode int,
  @Jahr                int,
  @Monat			   int)

  RETURNS @BgPosition TABLE (
    BgPositionID        int,
    BgPositionsartID    int, 
    BgPositionsartCode  int,
    BgKategorieCode     int,
    BgGruppeCode        int, 
    BFSVariable         varchar(10),
    KontoNr             varchar(10), 
    BaPersonID          int,
    Betrag              money,
    NettoBetrag         money
  )
AS BEGIN

  DECLARE @FaProzessCode INT
  SET @FaProzessCode = dbo.fnBFSLeistungsartTOProzess(@BFSLeistungsartCode)

  INSERT INTO @BgPosition
  SELECT POS.BgPositionID,
         POS.BgPositionsartID,
         BPA.BgPositionsartCode,
         POS.BgKategorieCode,
         BPA.BgGruppeCode,
         BPA.VarName,
         KOA.KontoNr,
         BaPersonID  = ISNULL(POS.BaPersonID,@AntragstellerID),
         Betrag      = (SUM(POS.Betrag) - SUM(POS.Reduktion) - SUM(POS.Abzug)) / CASE WHEN COUNT(BUK.KbBuchungID) = 0 THEN 1 ELSE COUNT(BUK.KbBuchungID) END,
         NettoBetrag = ISNULL((SELECT SUM(Betrag) FROM KbBuchungKostenart WHERE BgPositionID = POS.BgPositionID),0)
  FROM   dbo.FaLeistung LEI
         INNER JOIN dbo.BgFinanzplan          FPL  ON FPL.FaLeistungID = LEI.FaLeistungID
         INNER JOIN dbo.BgBudget              BDG  ON BDG.BgFinanzplanID = FPL.BgFinanzplanID AND
                                                      BDG.MasterBudget = 0                        -- nur Monatsbudgets         
         INNER JOIN dbo.BgPosition            POS  ON POS.BgBudgetID = BDG.BgBudgetID                                                      
         INNER JOIN dbo.BgPositionsart        BPA  ON BPA.BgPositionsartID = POS.BgPositionsartID
		    -- med. Grundversorgung nicht relevant
            AND BPA.BgGruppeCode NOT IN (3202) 
         LEFT  JOIN dbo.BgKostenart           KOA  ON KOA.BgKostenartID = BPA.BgKostenartId 
         LEFT  JOIN dbo.KbBuchungKostenart    BUK  ON BUK.BgPositionID = POS.BgPositionID
         LEFT  JOIN dbo.KbBuchung             BUC  ON BUC.KbBuchungID = BUK.KbBuchungID
         LEFT  JOIN dbo.KbTransfer            TSF  ON TSF.KbBuchungID = BUC.KbBuchungID AND KbTransferStatusCode = 2 -- Übermittelt
         LEFT  JOIN dbo.KbZahlungslauf        ZLL  ON ZLL.KbZahlungslaufID = TSF.KbZahlungslaufID
		 LEFT  JOIN dbo.KbOpAusgleich         AUS  ON AUS.OpBuchungID = BUC.KbBuchungID AND
		     AUS.KbOpAusgleichID = (
			     SELECT MAX(KbOpAusgleichID)
				 FROM dbo.KbOpAusgleich
				 WHERE OpBuchungID = BUC.KbBuchungID
			 )
		 LEFT  JOIN dbo.KbBuchung             BUC2 ON BUC2.KbBuchungID = AUS.AusgleichBuchungID

  WHERE LEI.BaPersonID = @AntragstellerID 
   AND BDG.BgBewilligungStatusCode IN (5,9) -- nur bewilligte und gesperrte Budgets
   AND LEI.FaProzessCode = @FaProzessCode 
	 AND ISNULL(BUK.KbBuchungKostenartID,0) = ISNULL((
	  SELECT MIN(KbBuchungKostenartID) FROM  dbo.KbBuchungKostenart
	  WHERE  KbBuchungID = BUC.KbBuchungID),0)

	AND CASE 
      -- nicht abgetretene Einnahmen (wenn nicht in Veraltung Sozialdienst), Kürzungen
      WHEN ((POS.BgKategorieCode = 1 AND POS.VerwaltungSD = 0) OR POS.BgKategorieCode = 4)
        THEN CASE WHEN BDG.Jahr = @Jahr AND BDG.Monat = @Monat THEN 1 ELSE 0 END
	  -- ZahlauftragErstellt, ausgeglichen, teilweise ausgeglichen, verbucht
	  -- grüne und ausgedruckte Barbelege
      -- bei Kunden ohne Klibu werden alle verbuchten Buchungen berücksichtigt
      WHEN BUC.KbBuchungStatusCode IN (3,6,10,13) OR (BUC.KbBuchungStatusCode = 2 AND BUC.KbAuszahlungsArtCode = 103)
        THEN CASE WHEN YEAR(COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum)) = @Jahr AND
                      MONTH(COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum)) = @Monat
		          THEN 1 ELSE 0 END    
      ELSE 0
    END = 1

    GROUP BY POS.BgPositionsartID,
         BPA.BgPositionsartCode,
         POS.BgKategorieCode,
         BPA.BgGruppeCode,
         BPA.VarName,
         KOA.KontoNr,
         POS.BgPositionID,
         POS.BaPersonID
  RETURN
END
GO