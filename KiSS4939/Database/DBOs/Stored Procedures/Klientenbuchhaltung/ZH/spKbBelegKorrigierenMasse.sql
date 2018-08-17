SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbBelegKorrigierenMasse;
GO
/*===============================================================================================
  $Revision: 17 $
=================================================================================================
  Description 
    Gib die Tabelle für das DataGrid im CtlKbBelegeKorrigierenMasse zurück.
    Query im SP und nicht direkt GUI weil Probleme mit der Liste von Leistungsarten von dem KissDoubleListSelection (Param @LAList)
    
    Berechnung der Einnahme und Ausgabe analag spWhKontoauszug für CtlWhKontoauszug
    Struktur der SP analog zum Query qryKbBuchungBruttoSuche im CtlKbBelegeKorrigieren 
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Fallnummer:         FaLeistung.FaFallID
    @LeistungstraegerID: BaPersonID des Leistungsträgers
    @KlientInID:         BaPersonID auf der Detail-Buchung
    @VerwDatumVon:       Datum von der Verwendungsperiode
    @VerwDatumBis:       Datum bis der Verwendungsperiode
    @LAList:             Liste der Leistungsarten (Komasepariert)
    @KbBuchungBruttoID:  KbBuchungBruttoID

  TEST:  EXEC spKbBelegKorrigierenMasse 11,173681,173681,'2014-01-01','2014-06-20',NULL,NULL
         EXEC spKbBelegKorrigierenMasse 11,173681,173681,NULL,NULL,NULL,NULL
         EXEC spKbBelegKorrigierenMasse 11,173681,NULL,NULL,NULL,NULL,NULL 
         EXEC spKbBelegKorrigierenMasse 11,NULL,NULL,NULL,NULL,NULL,NULL 
         EXEC spKbBelegKorrigierenMasse 11,NULL,NULL,NULL,NULL,NULL,24471
         EXEC spKbBelegKorrigierenMasse NULL,181624,NULL,NULL,NULL,NULL,NULL 
=================================================================================================*/


CREATE PROCEDURE dbo.spKbBelegKorrigierenMasse
(
  @Fallnummer INT = NULL,
  @LeistungstraegerID INT = NULL,
  @KlientInID INT = NULL,
  @VerwDatumVon DATETIME = NULL,
  @VerwDatumBis DATETIME = NULL,
  @LAList VARCHAR(200) = NULL,
  @KbBuchungBruttoID INT = NULL
)
AS
BEGIN

SET @VerwDatumVon = ISNULL(@VerwDatumVon, '17530101');
SET @VerwDatumBis = ISNULL(@VerwDatumBis, '99991231');

DECLARE @KopfBuchung TABLE
(
  KbBuchungBruttoID int
);

INSERT INTO @KopfBuchung
  SELECT DISTINCT
    KBB.KbBuchungBruttoID
  FROM dbo.KbBuchungBrutto               KBB WITH(READUNCOMMITTED)
    INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID 
    LEFT  JOIN dbo.vwPerson              PRS ON PRS.BaPersonID = KBP.BaPersonID
    LEFT  JOIN dbo.BgKostenart           BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID = KBB.BgKostenartID --OR KBB.BgKostenartID IS NULL AND KBP.SpezBgKostenartID = BKA.BgKostenartID
    LEFT  JOIN dbo.BgPosition            POS WITH(READUNCOMMITTED) ON POS.BgPositionID = KBP.BgPositionID
    LEFT  JOIN (SELECT KbBuchungBruttoID   = KBP2.KbBuchungBruttoID, 
                       KbBuchungStatusCode = MIN(BUC2.KbBuchungStatusCode) 
                FROM dbo.KbBuchungBruttoPerson      KBP2
                  INNER JOIN dbo.KbBuchungKostenart KOA  WITH(READUNCOMMITTED) ON KOA.BgPositionID = KBP2.BgPositionID
                  INNER JOIN dbo.KbBuchung          BUC2 WITH(READUNCOMMITTED) ON BUC2.KbBuchungID = KOA.KbBuchungID
                GROUP BY KBP2.KbBuchungBruttoID) BUC ON BUC.KbBuchungBruttoID = KBB.KbBuchungBruttoID 
    LEFT  JOIN dbo.BgBudget              BUD WITH(READUNCOMMITTED) ON BUD.BgBudgetID = KBB.BgBudgetID
    LEFT  JOIN dbo.FaLeistung            LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = KBB.FaLeistungID
  WHERE (KBB.KbBuchungStatusCode IN (3,8,6) AND KBB.Betrag < 0 
      OR KBB.Betrag > 0 AND (KBB.KbBuchungStatusCode IN (6,8,10) 
      OR KBB.KbBuchungStatusCode = 3 AND KBB.Abgetreten = 0 )) 
    AND (BUC.KbBuchungStatusCode IN (6) 
      OR KBP.BgPositionID IS NULL AND KBB.PscdKennzeichen IN ('S', 'U'))	-- Nur Belege mit Geldfluss, d.h. kleinster Nettobeleg-Status ist ausgeglichen / oder Umbuchungs- und SiLei-Belege, die haben keine Nettobelege
    AND KBB.StorniertKbBuchungBruttoID IS NULL -- Stornobelege können nicht storniert werden
    AND LEI.FaFallID = ISNULL(@Fallnummer, LEI.FaFallID)
    AND LEI.BaPersonID = ISNULL(@LeistungstraegerID, LEI.BaPersonID)
    AND KBP.BaPersonID = ISNULL(@KlientInID, KBP.BaPersonID)
    AND (dbo.fnDatumUeberschneidung(@VerwDatumVon, @VerwDatumBis, KBP.VerwPeriodeVon, ISNULL(KBP.VerwPeriodeBis, KBP.VerwPeriodeVon)) = 1)
    AND (@LAList IS NULL 
      OR ',' + @LAList + ',' LIKE '%,' + BKA.KontoNr + ',%')
    AND KBB.KbBuchungBruttoID = ISNULL(@KbBuchungBruttoID, KBB.KbBuchungBruttoID);

;WITH KbBuchungBruttoCte AS
(
  SELECT
    KbBuchungBruttoID         = KBB.KbBuchungBruttoID,
    FaFallID                  = LEI.FaFallID,
    FaLeistungID              = LEI.FaLeistungID,
    BaPersonID_LT             = LEI.BaPersonID,
    BgFinanzplanID            = BUD.BgFinanzplanID,
    BgBudgetID                = BUD.BgBudgetID,
    BgPositionID              = POS.BgPositionID,
    BgKostenartID             = ISNULL(BKA.BgKostenartID, KBP.SpezBgKostenartID),  -- SiLei haben die Kostenart auf den Detailpositionen
    BelegNr                   = KBB.BelegNr,
    ValutaDatum               = KBB.ValutaDatum,
    BelegDatum                = KBB.BelegDatum,
    BetrifftBaPersonID        = PRS.BaPersonID,
    LA                        = BKA.KontoNr,
    Quoting                   = BKA.Quoting,
    Buchungstext              = KBB.[Text], -- TODO oder KBP.Buchungstext?
    VerwPeriodeVon            = KBP.VerwPeriodeVon, 
    VerwPeriodeBis            = KBP.VerwPeriodeBis, 
    BgSplittingArtCode        = BKA.BgSplittingArtCode,
    SplittingArt              = dbo.fnLOVMLShortText('BgSplittingArt', BKA.BgSplittingArtCode, 1),
    DatumEffektiv             = NET.DatumEffektiv,
    S                         = CASE WHEN POS.VerwaltungSD = 1 THEN 'S' ELSE NULL END,
    D                         = CASE WHEN ISNULL(ZLW.BaZahlungswegID, 0) > 0 AND ISNULL(ZLW.BaPersonID, 0) = 0 THEN 'D' END,
    Bar                       = CASE WHEN BAP.KbAuszahlungsArtCode = 103 THEN 'b' ELSE NULL END,
    Betrag                    = ISNULL(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, KBP.Betrag, KBP.VerwPeriodeVon, KBP.VerwPeriodeBis, @VerwDatumVon, @VerwDatumBis), $0.00),
    BetragEffektiv            = ISNULL(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, KBP.Betrag *
                                     CASE
                                       WHEN NET.Anteil IS NOT NULL THEN NET.Anteil
                                       WHEN NET.Betrag IS NOT NULL AND NET.BetragEffektiv IS NOT NULL AND NET.BetragEffektiv = 0.0 THEN 0.0
                                       WHEN NET.Betrag IS NOT NULL AND NET.BetragEffektiv IS NOT NULL THEN (NET.BetragEffektiv / NET.Betrag)
                                       ELSE 1.0
                                     END, KBP.VerwPeriodeVon, KBP.VerwPeriodeBis, @VerwDatumVon, @VerwDatumBis), $0.00),
    EA                        = CASE WHEN KBP.Betrag <= $0.00 THEN 'A' ELSE 'E' END,
    PscdKennzeichen           = KBB.PscdKennzeichen,
    KbBuchungBruttoStatusCode = KBB.KbBuchungStatusCode,
    KbBuchungStatusCode       = CASE
                                  WHEN KBB.KbBuchungStatusCode = 8 -- Stornierter Bruttobeleg
                                    THEN KBB.KbBuchungStatusCode	-- Wir haben eine Stornobuchung gefunden (Stornierter Original-Beleg oder den STO-Beleg), d.h. wir wollen den Brutto-Status anzeigen, unabhängig vom Netto-Status
                                  ELSE
                                    CASE
                                      WHEN NET.MaxStatusCode IS NOT NULL THEN NET.MaxStatusCode
                                      ELSE KBB.KbBuchungStatusCode
                                    END
                                END,
    Doc                       = (SELECT CASE WHEN COUNT(T.BgDokumentID) > 0 THEN COUNT(BgDokumentID) END
                                 FROM (SELECT DISTINCT BDO.BgDokumentID
                                       FROM dbo.KbBuchungBruttoPerson BUP WITH(READUNCOMMITTED)
                                         INNER JOIN dbo.BgDokument    BDO WITH(READUNCOMMITTED) ON BDO.BgPositionID = BUP.BgPositionID
                                       WHERE BUP.KbBuchungBruttoID = dbo.fnGetOriginalKbBuchungBruttoID(KBB.KbBuchungBruttoID)
                                       UNION
                                       SELECT DISTINCT BDO.BgDokumentID
                                       FROM dbo.KbBuchungBruttoPerson BUP WITH(READUNCOMMITTED)
                                         INNER JOIN dbo.BgPosition    POS WITH(READUNCOMMITTED) ON POS.BgPositionID = BUP.BgPositionID
                                         INNER JOIN dbo.BgDokument    BDO WITH(READUNCOMMITTED) ON BDO.BgBudgetID = POS.BgBudgetID
                                       WHERE  BUP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
                                       UNION
                                       SELECT DISTINCT BDO.BgDokumentID
                                       FROM dbo.KbBuchungBruttoPerson BUP WITH(READUNCOMMITTED)
                                         INNER JOIN dbo.BgPosition    POS WITH(READUNCOMMITTED) ON POS.BgPositionID = BUP.BgPositionID
                                         INNER JOIN dbo.BgBudget      BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
                                         INNER JOIN dbo.BgDokument    BDO WITH(READUNCOMMITTED) ON BDO.BgFinanzplanID = BDG.BgFinanzplanID
                                       WHERE  BUP.KbBuchungBruttoID = KBB.KbBuchungBruttoID) T
                                       ),
    Budget                    = CASE
                                  WHEN BUD.Monat > 9 THEN ''
                                  ELSE '0'            
                                END + CONVERT(VARCHAR(2), BUD.Monat) + '.' + SUBSTRING(CONVERT(VARCHAR(4), BUD.Jahr), 3, 2),
    GroupBaPersonID           = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    StornoCode                = CASE
                                  WHEN KBB.NeubuchungVonKbBuchungBruttoID IS NOT NULL THEN 2
                                  WHEN KBB.StorniertKbBuchungBruttoID IS NOT NULL  THEN 1
                                  ELSE 0
                                END,
    isSiLei                   = CASE WHEN SIP.BaSicherheitsleistungPositionID IS NOT NULL THEN 1 ELSE 0 END,
    PersonDisplayText         = PRS.DisplayText,
    Kostenstelle              = KBB.Kostenstelle,
    Hauptvorgang              = KBB.Hauptvorgang,
    Teilvorgang               = KBB.Teilvorgang,
    SpezHauptvorgang          = KBP.SpezHauptvorgang,
    SpezTeilvorgang           = KBP.SpezTeilvorgang,
    BgKostenartHauptvorgang   = BKA.Hauptvorgang,
    BgKostenartTeilvorgang    = BKA.Teilvorgang,
    BgKostenartHauptvorgangAbtretung = BKA.HauptvorgangAbtretung,
    BgKostenartTeilvorgangAbtretung = BKA.TeilvorgangAbtretung,  
    Belegart                  = KBB.Belegart,
    Weiterverrechenbar        = KBB.Weiterverrechenbar,
    Abgetreten                = KBB.Abgetreten, 
    BetragKopf                = KBB.Betrag,
    KbBuchungBruttoPersonID   = CASE WHEN BKA.Quoting = 1 THEN NULL ELSE KBP.KbBuchungBruttoPersonID END
  FROM @KopfBuchung                      TEMP
    INNER JOIN dbo.KbBuchungBrutto       KBB WITH(READUNCOMMITTED) ON KBB.KbBuchungBruttoID = TEMP.KbBuchungBruttoID
    INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID 
    LEFT  JOIN dbo.vwPerson2             PRS ON PRS.BaPersonID = KBP.BaPersonID
    LEFT  JOIN dbo.BgKostenart           BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID     = KBB.BgKostenartID
    LEFT  JOIN dbo.BgPosition            POS WITH(READUNCOMMITTED) ON POS.BgPositionID      = KBP.BgPositionID
    LEFT  JOIN dbo.BgBudget              BUD WITH(READUNCOMMITTED) ON BUD.BgBudgetID        = KBB.BgBudgetID
    LEFT  JOIN dbo.FaLeistung            LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID      = KBB.FaLeistungID
    OUTER APPLY dbo.fnBruttoToNettos(KBP.KbBuchungBruttoPersonID, KBP.BgPositionID, KBB.Betrag, KBB.ValutaDatum) NET
    OUTER APPLY (SELECT TOP 1 KbAuszahlungsArtCode, BaZahlungswegID
                 FROM dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED)
                 WHERE BAP.BgPositionID = POS.BgPositionID
                 ORDER BY
                   CASE
                     WHEN BAP.BaPersonID = KBP.BaPersonID THEN 1
                     WHEN BAP.BaPersonID IS NULL THEN 2
                     ELSE 3
                   END
               ) BAP
    LEFT  JOIN dbo.BaZahlungsweg                 ZLW WITH(READUNCOMMITTED) ON ZLW.BaZahlungswegID = BAP.BaZahlungswegID
    LEFT  JOIN dbo.BaSicherheitsleistungPosition SIP WITH(READUNCOMMITTED) ON SIP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
)

SELECT
  KbBuchungBruttoID         = CTE.KbBuchungBruttoID,
  FaFallID                  = MAX(CTE.FaFallID),
  FaLeistungID              = MAX(CTE.FaLeistungID),
  BaPersonID                = MAX(CTE.BaPersonID_LT),
  BgFinanzplanID            = MAX(CTE.BgFinanzplanID),
  BgBudgetID                = MAX(CTE.BgBudgetID),
  BgPositionID              = MAX(CTE.BgPositionID),
  BgKostenartID             = MAX(CTE.BgKostenartID),
  BelegNr                   = MAX(CTE.BelegNr),
  ValutaDatum               = MAX(CTE.ValutaDatum),
  BelegDatum                = MAX(CTE.BelegDatum),
  BetrifftBaPersonID        = CASE WHEN MIN(CTE.BetrifftBaPersonID) = MAX(CTE.BetrifftBaPersonID) THEN MAX(CTE.BetrifftBaPersonID) ELSE NULL END,
  BetrifftPerson            = CASE WHEN MIN(CTE.BetrifftBaPersonID) = MAX(CTE.BetrifftBaPersonID) THEN MAX(CTE.PersonDisplayText) ELSE NULL END,
  Quoting                   = CONVERT(BIT, MAX(CONVERT(INT, CTE.Quoting))),
  [Text]                    = MAX(CTE.Buchungstext),
  VerwPeriodeVon            = MIN(CTE.VerwPeriodeVon),
  VerwPeriodeBis            = MAX(CTE.VerwPeriodeBis),
  BgSplittingArtCode        = MAX(CTE.BgSplittingArtCode),
  Splittingart              = MAX(CTE.SplittingArt),
  DatumEffektiv             = MAX(CTE.DatumEffektiv),
  S                         = MAX(CTE.S),
  D                         = MAX(CTE.D),
  Bar                       = MAX(CTE.Bar),
  Betrag                    = SUM(CTE.Betrag),
  BetragEffektiv            = SUM(CTE.BetragEffektiv),
  EA                        = MAX(CASE WHEN CTE.StornoCode = 1 
                                    THEN CASE WHEN CTE.EA = 'E' THEN 'A' ELSE 'E' END
                                    ELSE CTE.EA
                                  END),
  Einnahme                  = CASE WHEN CTE.EA = 'E' 
                                THEN CASE WHEN (CTE.KbBuchungStatusCode = 6 OR CTE.KbBuchungStatusCode = 10) AND CTE.IsSiLei = 0 THEN SUM(CTE.BetragEffektiv)
                                ELSE SUM(CTE.Betrag) END
                              END,
  Ausgabe                   = CASE WHEN CTE.EA = 'A' 
                                THEN CASE WHEN (CTE.KbBuchungStatusCode = 6 OR CTE.KbBuchungStatusCode = 10) AND CTE.IsSiLei = 0 THEN SUM(-CTE.BetragEffektiv)
                                ELSE SUM(-CTE.Betrag) END
                              END,
  PscdKennzeichen           = CTE.PscdKennzeichen,
  KbBuchungBruttoStatusCode = MAX(CTE.KbBuchungBruttoStatusCode),
  KbBuchungStatusCode       = MAX(CTE.KbBuchungStatusCode),
  Doc                       = MAX(CTE.Doc),
  Budget                    = MAX(CTE.Budget),
  GroupBaPersonID           = MAX(CTE.GroupBaPersonID),
  StornoCode                = MAX(CTE.StornoCode),
  IsSiLei                   = CONVERT(BIT, MAX(CTE.IsSiLei)),
  Klient                    = CASE 
                                WHEN CTE.Quoting = 1 AND COUNT(DISTINCT CTE.BetrifftBaPersonID) > 1
                                  THEN 'ganze UE (' + CONVERT(VARCHAR, COUNT(DISTINCT CTE.BetrifftBaPersonID)) + ')'
                                ELSE dbo.ConcDistinct(CTE.PersonDisplayText)
                              END,
  BetrifftBaPersonIDs       = CASE WHEN MIN(CTE.BetrifftBaPersonID) = MAX(CTE.BetrifftBaPersonID) THEN NULL ELSE dbo.ConcDistinct(CTE.BetrifftBaPersonID) END,
  KlientBaPersonCount       = COUNT(DISTINCT CTE.BetrifftBaPersonID),
  Auswahl                   = CONVERT(BIT, 0), -- Wegen Checkbox
  Fehlermeldung             = CONVERT(VARCHAR(MAX), ''), -- Wegen Fehlermeldung  
  SelectedHaushaltProleistPersonenIDs = '', -- Validierung : wird gebraucht falls Dummy-Finanzplan nötig ist
  SelectedHaushaltdatumvon  = CONVERT(DATETIME, NULL), -- Validierung : wird gebraucht falls Dummy-Finanzplan nötig ist
  SelectedHaushaltdatumbis  = CONVERT(DATETIME, NULL), -- Validierung : wird gebraucht falls Dummy-Finanzplan nötig ist
  KontoNr                   = MAX(CTE.LA),
  BgKostenart               = MAX(CTE.LA), -- + Name
  Kostenstelle              = MAX(CTE.Kostenstelle),
  Hauptvorgang              = ISNULL(CTE.Hauptvorgang, MIN(CTE.SpezHauptvorgang)),  -- SiLei haben den Hauptvorgang auf den Detailpositionen
  Teilvorgang               = ISNULL(CTE.Teilvorgang, MIN(CTE.SpezTeilvorgang)),  -- SiLei haben den Teilvorgang auf den Detailpositionen
  BgKostenartHauptvorgang   = CTE.BgKostenartHauptvorgang,
  BgKostenartTeilvorgang    = CTE.BgKostenartTeilvorgang,
  BgKostenartHauptvorgangAbtretung = CTE.BgKostenartHauptvorgangAbtretung,
  BgKostenartTeilvorgangAbtretung = CTE.BgKostenartTeilvorgangAbtretung,    
  Belegart                  = CTE.Belegart,
  Weiterverrechenbar        = CTE.Weiterverrechenbar,
  Abgetreten                = CTE.Abgetreten,
  BetrifftPersonen          = dbo.ConcDistinct(PersonDisplayText), 
  BetragKopf                = CTE.BetragKopf,
  KbBuchungBruttoPersonID   = MAX(CTE.KbBuchungBruttoPersonID)
FROM KbBuchungBruttoCte CTE
GROUP BY KbBuchungBruttoID, LA, GroupBaPersonID, Quoting, Buchungstext, VerwPeriodeVon, VerwPeriodeBis, EA, KbBuchungStatusCode, 
       CTE.IsSiLei, CTE.PscdKennzeichen, CTE.Hauptvorgang, CTE.Teilvorgang, 
       CTE.BgKostenartHauptvorgang, CTE.BgKostenartTeilvorgang, CTE.BgKostenartHauptvorgangAbtretung, CTE.BgKostenartTeilvorgangAbtretung,
       CTE.Belegart, CTE.Weiterverrechenbar, CTE.Abgetreten, CTE.BetragKopf
ORDER BY VerwPeriodeVon DESC, VerwPeriodeBis DESC, LA


-- Detailbuchung auflisten
SELECT DISTINCT 
KBP.KbBuchungBruttoID, 
PRS.BaPersonID,
Person = PRS.NameVorname + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
KBP.Schuldner_BaInstitutionID,
KBP.Schuldner_BaPersonID,
KBP.Buchungstext, 
KBP.Betrag,
KBP.VerwPeriodeVon, 
KBP.VerwPeriodeBis, 
KBP.PositionImBeleg,
KBP.SpezBgKostenartID,
KBP.SpezHauptvorgang,
KBP.SpezTeilvorgang,
KBP.GesperrtFuerWV,
KBP.Zinsperiode 
FROM @KopfBuchung TEMP
  INNER JOIN KbBuchungBrutto       KBB WITH(READUNCOMMITTED) ON KBB.KbBuchungBruttoID = TEMP.KbBuchungBruttoID
  INNER JOIN KbBuchungBruttoPerson KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
  INNER JOIN vwPerson              PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID        = KBP.BaPersonID
  LEFT  JOIN FaLeistung            LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID      = KBB.FaLeistungID
  LEFT  JOIN BgPosition            POS WITH(READUNCOMMITTED) ON POS.BgPositionID      = KBP.BgPositionID
  LEFT  JOIN KbBuchungKostenart    KOA WITH(READUNCOMMITTED) ON KOA.BgPositionID      = POS.BgPositionID
  LEFT  JOIN KbBuchung             BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID       = KOA.KbBuchungID

END;
