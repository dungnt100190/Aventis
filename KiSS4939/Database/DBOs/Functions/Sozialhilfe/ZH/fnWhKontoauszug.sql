SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhKontoauszug;
GO
/*===============================================================================================
  $Revision: 15 $
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
=================================================================================================*/
CREATE FUNCTION dbo.fnWhKontoauszug
(
  @FallBaPersonID int,
  @PersonenListe varchar(150),
  @KbKontoZeitraumCode int,  -- 1 Buchungsdatum (= Valutadatum), 3 Verwendungsperiode
  @DatumVon datetime,
  @DatumBis datetime,
  @Buchungstext varchar(200),
  @LAList varchar(2000),
  @Verdichtet bit,
  @InklProLeist bit,
  @InklVermittlungsfall bit,
  @InklGruen bit,
  @InklRot bit,
  @InklStorno bit,
  @EA char, -- E für Einnahmen, A für Ausgaben, NULL für alles
  @KlientenKontoabrechnungsModus bit = 0 -- Steuert die LA-Auswahl
)
RETURNS
@tmp TABLE (
  BuchungID           int,
  BuchungsDatum       datetime,
  BaPersonID          int,
  Klient              varchar(200),
  BelegNr             varchar(20),
  LA                  varchar(5),
  LAProLeist          varchar(5),
  LAText              varchar(150),
  Quoting             bit,
  Buchungstext        varchar(200),
  VerwPeriodeVon      datetime,
  VerwPeriodeBis      datetime,
  BgSplittingArtCode  int,
  Splitting           char,
  TransferDatum       datetime,
  ValutaDatum         datetime,
  ErfassungsDatum     datetime,
  DatumEffektiv       datetime,
  S                   varchar(1),
  D                   varchar(1),
  Bar                 varchar(1),
  Betrag              money,
  Betrag100           money,
  BetragEffektiv      money,
  EA                  varchar(1), -- E = Einnahme, A = Ausgabe
  KbBuchungStatusCode int,
  Doc                 varchar(1),
  Auszahlart          varchar(100),
  KreditorDebitor     varchar(2000),
  PK                  varchar(1), -- P = ProLeist, K = KiSS
  PLFall              int,
  PLPerson            int,
  BgPositionID        int,
  BgBudgetID          int,
  BgBudgetName        varchar(60),
  BgFinanzplanID      int,
  FallBaPersonID      int,
  Rechnungsnummer     varchar(100),
  Verdichtet          bit,
  GroupBaPersonID     int,
  OriginalValuta      datetime,
  OriginalBuchungID   int,
  KbBuchungID         int, --Nettobeleg
  KbBuchungBruttoID   int,
  StornoCode          int,  -- 0: Original, 1: Storno, 2: Neubuchung
  IstGBL              bit,
  IstEinzelzahlungGBL bit,
  IstSiLei            bit,
  AnzahlBelege        int,
  PosImBeleg          int -- Hilfsangabe: dient dazu, im ersten grossen Select durch das Distinct keine Werte zu verlieren.
)
AS
BEGIN
  SET @KbKontoZeitraumCode = IsNull(@KbKontoZeitraumCode, 1);
  SET @DatumVon            = IsNull(@DatumVon, '17530101');
  SET @DatumBis            = IsNull(@DatumBis, '29000101');
  SET @LAList              = IsNull(@LAList, '');

  DECLARE @Saldo       money;

  IF (@Buchungstext = '')
  BEGIN
    SET @Buchungstext = NULL;
  END;

  IF (@LAList = '')
  BEGIN
    SET @LAList = NULL;
  END;

  DECLARE @Personen TABLE (
    BaPersonID INT
  );

  INSERT INTO @personen
    SELECT CONVERT(INT, SplitValue)
    FROM dbo.fnSplitStringToValues(@PersonenListe, ',', 0);

  -- LA-Such-Varianten:
  -- alle ausser WV_VU_UB (Standard Kontoauszug)
  -- speziell ausgewählte LAs (Benutzer-Auswahl im Kontoauszug)
  -- alle ausser WV_VU_UB und Klientenkontoabrechnungs-Zusatz_LAs (Standard Klientenkontoabrechnung)
  -- alle ausser WV_VU_UB und Benutzer-Auswahl an Zusatz-LAs ( Klientenkontoabrechnung)
  DECLARE @LA_WV_VU_UB TABLE (
    KontoNr INT
  );

  INSERT INTO @LA_WV_VU_UB
    SELECT CONVERT(INT, SplitValue)
    FROM dbo.fnSplitStringToValues((SELECT CONVERT(VARCHAR(500), dbo.fnXConfig('System\WH\WV_VU_UB', GETDATE())) ), ',', 0);

  DECLARE @StornierteProleistBuchungen TABLE (
    MigDetailBuchungID INT,
    NummernKreis VARCHAR(2),
    BelegNummer INT,
    KissLeistungsart INT,
    BaPersonID INT
  );

  -- Bruttobelege aus W-Budgets
  INSERT @tmp
  SELECT DISTINCT
    BuchungID           = KBB.KbBuchungBruttoID,
    BuchungsDatum       = KBB.ValutaDatum, --KBB.BelegDatum,
    BaPersonID          = PRS.BaPersonID,
    Klient              = PRS.DisplayText,
    BelegNr             = CONVERT(varchar(20),IsNull(KBB.BelegNr,KBB.KbBuchungBruttoID)),
    LA                  = BKA.KontoNr,
    LAProLeist          = NULL,
    LAText              = BKA.Name,
    Quoting             = BKA.Quoting,
    Buchungstext        = KBK.Buchungstext,
    VerwPeriodeVon      = KBK.VerwPeriodeVon,
    VerwPeriodeBis      = KBK.VerwPeriodeBis,
    BgSplittingArtCode  = BKA.BgSplittingArtCode,
    Splitting           = SPL.ShortText,
    TransferDatum       = KBB.TransferDatum,
    ValutaDatum         = KBB.ValutaDatum,
    ErfassungsDatum     = KBB.ErfassungsDatum,
    DatumEffektiv       = NET.DatumEffektiv,
    S                   = CASE WHEN KBB.Abgetreten = 1 THEN 'S' END,
    D                   = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END,
    Bar                 = CASE WHEN BAP.KbAuszahlungsArtCode = 103 THEN 'b' END,
    Betrag              = CASE
                            WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                              THEN ISNULL(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, KBK.Betrag, KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE KBK.Betrag
                          END,
    Betrag100           = KBK.Betrag,
    BetragEffektiv      = CASE
                            WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                              THEN ISNULL(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, KBK.Betrag *
                                CASE
                                  WHEN NET.anteil IS NOT NULL THEN NET.anteil
                                  WHEN NET.Betrag IS NOT NULL AND NET.BetragEffektiv IS NOT NULL AND NET.BetragEffektiv = 0.0 THEN 0.0
                                  WHEN NET.Betrag IS NOT NULL AND NET.BetragEffektiv IS NOT NULL THEN (NET.BetragEffektiv / NET.Betrag)
                                  ELSE 1.0
                                END, KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE
                              CASE
                                WHEN NET.anteil IS NOT NULL THEN KBK.Betrag * NET.anteil
                                WHEN NET.Betrag IS NOT NULL AND NET.BetragEffektiv IS NOT NULL AND NET.BetragEffektiv = 0.0 THEN 0.0
                                WHEN NET.Betrag IS NOT NULL AND NET.BetragEffektiv IS NOT NULL THEN KBK.Betrag * (NET.BetragEffektiv / NET.Betrag)
                                ELSE KBK.Betrag
                              END
                          END,
    EA                  = CASE WHEN KBK.Betrag <= $0.00 THEN 'A' ELSE 'E' END,
    KbBuchungStatusCode = CASE
                            WHEN KBB.KbBuchungStatusCode = 8 -- Stornierter Bruttobeleg
                              THEN KBB.KbBuchungStatusCode	-- Wir haben eine Stornobuchung gefunden (Stornierter Original-Beleg oder den STO-Beleg), d.h. wir wollen den Brutto-Status anzeigen, unabhängig vom Netto-Status
                            ELSE
                              CASE
                                WHEN NET.maxStatusCode IS NOT NULL THEN NET.maxStatusCode
                                ELSE KBB.KbBuchungStatusCode
                              END
                          END,						  
    Doc                 = (SELECT CASE WHEN COUNT(T.BgDokumentID) > 0 THEN COUNT(BgDokumentID) END
                           FROM (SELECT DISTINCT BDO.BgDokumentID
                                 FROM dbo.KbBuchungBruttoPerson BUP WITH(READUNCOMMITTED)
                                   INNER JOIN BgPosition    POS ON POS.BgPositionID = BUP.BgPositionID
                                   INNER JOIN dbo.BgDokument    BDO WITH(READUNCOMMITTED) ON BDO.BgPositionID = BUP.BgPositionID
                                 WHERE BUP.KbBuchungBruttoID = dbo.fnGetOriginalKbBuchungBruttoID(KBB.KbBuchungBruttoID)
                                   AND (POS.BaPersonID = BPO.BaPersonID OR BPO.BaPersonID IS NULL)
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
                                 WHERE  BUP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
                                 UNION
                                 SELECT DISTINCT BgDokumentID
                                 FROM dbo.KbBuchungBruttoPerson BUP WITH(READUNCOMMITTED)
                                   INNER JOIN dbo.BgPosition    POS WITH(READUNCOMMITTED) ON POS.BgPositionID = BUP.BgPositionID
                                   INNER JOIN dbo.BgPosition    POM WITH(READUNCOMMITTED) ON POM.BgPositionID = POS.BgPositionID_CopyOf
                                   INNER JOIN dbo.BgDokument    BDO WITH(READUNCOMMITTED) ON BDO.BgPositionID = POM.BgPositionID
                                 WHERE BUP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
                                   AND BDO.BgDokumentTypCode = 4
                                   AND (POM.BaPersonID = BPO.BaPersonID OR BPO.BaPersonID IS NULL)) T),
    Auszahlart          = ART.Text,
    KreditorDebitor     = COALESCE(KRE.Kreditor + CHAR(13) + CHAR(10) + KRE.ZusatzInfo,
                            DEI.Name + CHAR(13) + CHAR(10) + DEI.AdresseMehrzeilig,
                            DEP.NameVorname + CHAR(13) + CHAR(10) + DEP.WohnsitzMehrzeilig),
    PK                  = 'K',
    PLFall              = NULL,
    PLPerson            = NULL,
    BgPositionID        = BPO.BgPositionID,
    BgBudgetID          = BBG.BgBudgetID,
    BgBudgetName        = CASE
                            WHEN BBG.Monat > 9 THEN ''
                            ELSE '0'
                          END + CONVERT(VARCHAR(2), BBG.Monat) + '.' + SUBSTRING(CONVERT(VARCHAR(4), BBG.Jahr), 3, 2),
    BgFinanzplanID      = BFP.BgFinanzplanID,
    FallBaPersonID      = FAL.BaPersonID,
    Rechnungsnummer     = BPO.Rechnungsnummer,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = KBB.ValutaDatum,
    OriginalBuchungID   = KBB.KbBuchungBruttoID,
    KbBuchungID         = NULL,--BUC.KbBuchungID,
    KbBuchungBruttoID   = KBB.KbBuchungBruttoID,
    StornoCode          = CASE
                          WHEN KBB.NeubuchungVonKbBuchungBruttoID IS NOT NULL THEN 2
                          WHEN KBB.StorniertKbBuchungBruttoID IS NOT NULL  THEN 1
                          ELSE 0
                          END,
    IstGBL              = CASE
                            WHEN BPO.BgPositionsartID = BFP.WhGrundbedarfTypCode AND
                                 BPO.BgPositionID_Parent IS NULL AND -- der GBL hat nie einen Parent
                                 BPO.BgKategorieCode = 2 AND KBB.Betrag < 0 AND  -- Ausgaben-Kategorie und Betrag<0
                                 KBB.KbBuchungStatusCode <> 8 THEN 1 -- nicht storniert
                            ELSE 0
                          END,
    IstEinzelzahlungGBL = 0,
    IstSiLei            = 0,
    AnzahlBelege        = NET.AnzahlBelege,
    PositionImBeleg     = KBK.PositionImBeleg
  FROM dbo.FaFall                            FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung                FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
    INNER JOIN dbo.KbBuchungBrutto           KBB WITH (READUNCOMMITTED) ON KBB.FaLeistungID = FLE.FaLeistungID
                                                                       AND KBB.KbBuchungTypCode IN (1, 2, 5) -- manuell, budget, Umbuchung; wobei: andere gibts (noch?) nicht
    INNER JOIN dbo.KbBuchungBruttoPerson     KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungBruttoID = KBB.KbBuchungBruttoID
    LEFT  JOIN dbo.BgBudget                  BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = KBB.BgBudgetID
    LEFT  JOIN dbo.BgFinanzplan              BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
    LEFT  JOIN dbo.BgPosition                BPO WITH (READUNCOMMITTED) ON BPO.BgPositionID = KBK.BgPositionID
    LEFT  JOIN dbo.vwInstitution2            DEI WITH (READUNCOMMITTED) ON DEI.BaInstitutionID = BPO.BaInstitutionID
                                                                       AND BPO.BgKategorieCode = 1 -- Einnahmen
    LEFT  JOIN dbo.vwPerson2                 DEP WITH (READUNCOMMITTED) ON DEP.BaPersonID = BPO.DebitorBaPersonID
    LEFT  JOIN dbo.BgKostenart               BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = KBB.BgKostenartID
    LEFT  JOIN dbo.vwPerson2                 PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KBK.BaPersonID
    OUTER APPLY (SELECT TOP 1 KbAuszahlungsArtCode, BaZahlungswegID
                 FROM dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED)
                 WHERE BAP.BgPositionID = BPO.BgPositionID
                 ORDER BY
                   CASE
                     WHEN BAP.BaPersonID = KBK.BaPersonID THEN 1
                     WHEN BAP.BaPersonID IS NULL THEN 2
                     ELSE 3
                   END
               ) BAP
    LEFT  JOIN dbo.vwKreditor KRE  WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
    LEFT  JOIN dbo.XLOVCode   ART  WITH (READUNCOMMITTED) ON ART.LOVName = 'KbAuszahlungsArt'
                                                         AND ART.Code = BAP.KbAuszahlungsArtCode
    LEFT  JOIN dbo.XLOVCode   SPL  WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt'
                                                         AND SPL.Code = BKA.BgSplittingArtCode
    OUTER APPLY dbo.fnBruttoToNettos(KBK.KbBuchungBruttoPersonID, KBK.BgPositionID, KBB.Betrag, KBB.ValutaDatum) AS NET
  WHERE FAL.BaPersonID = @FallBaPersonID
    AND (@PersonenListe IS NULL OR KBK.BaPersonID IN (SELECT BaPersonID FROM @personen))
    AND (@LAList IS NULL AND BKA.KontoNr NOT IN (SELECT KontoNr FROM @LA_WV_VU_UB)
      -- Falls LaList = '': Standardabfrage. Die Liste umfasst Leistungsarten die standardmässig nicht dabei sind (siehe Spezifikation)
         OR (',' + @LAList + ',' LIKE '%,' + BKA.KontoNr + ',%'))
    AND (@EA IS NULL OR @EA = CASE
                                WHEN KBK.Betrag <= $0.00 AND KBB.StorniertKbBuchungBruttoID IS NULL
                                  OR KBK.Betrag > $0.00 AND KBB.StorniertKbBuchungBruttoID IS NOT NULL
                                  THEN 'A'
                                ELSE 'E'
                              END)
    AND CASE @KbKontoZeitraumCode
          WHEN 1 THEN CASE WHEN KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
          WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, KBK.VerwPeriodeVon, ISNULL(KBK.VerwPeriodeBis, KBK.VerwPeriodeVon))
          WHEN 4 THEN CASE
                        WHEN NET.DatumEffektiv BETWEEN @DatumVon AND @DatumBis THEN 1
                        ELSE 0
                      END
        END = 1
    AND (@Buchungstext IS NULL OR ISNULL(BPO.Buchungstext, KBB.Text) LIKE '%' + @Buchungstext + '%')
    AND (NET.Gelb IS NULL -- Es hat keinen Netto-Beleg, kommt bei Umbuchungen vor
         AND ((@inklGruen = 1
              OR KBB.KbBuchungStatusCode NOT IN (2, 3, 4, 5, 9)
              OR KBB.KbBuchungStatusCode = 3 AND KBB.NeubuchungVonKbBuchungBruttoID IS NOT NULL)
              AND (@inklRot = 1 OR KBB.KbBuchungStatusCode <> 7) -- Neubuchungen auch ohne Ausgleich anzeigen #6231
              AND (@inklStorno = 1 OR KBB.KbBuchungStatusCode <> 8)) -- Filtere alle Buchungen im Storno-Status
         -- Es hat mind. einen Netto-Beleg, überprüfe anhand von diesem ob wir den Beleg anzeigen oder nicht.
         OR  (NET.Gelb = 1 AND KBB.KbBuchungStatusCode <> 8) -- Buchungen mit Geldfluss, die nicht storniert wurden
         OR  (NET.Gruen = 1 AND @InklGruen = 1)
         OR  (NET.Rot = 1 AND @InklRot = 1)
         OR  ((KBB.KbBuchungStatusCode = 8 OR NET.Storno = 1)
              AND @InklStorno = 1));


  --Nachbearbeitung für STO-Belege
  UPDATE T
    SET EA = CASE WHEN T.EA = 'E' THEN 'A' ELSE 'E' END
  FROM @tmp T
  WHERE StornoCode = 1;

  -- Einzelzahlungen ab GBL, welche keinen Bruttobeleg haben (Altlasten, bis ca. Mai 2009)
  -- Damals wurden für die Einzelzahlungen keine separaten Bruttobelege abgelegt, weshalb
  -- diese Buchungen in einer Bruttoansicht nicht separat auftauchen würden. Auf ausdrücklichen Wunsch
  -- seitens Fachspezialisten (z.B. sozbev) werden diese Zahlungen separat im Kontoauszug aufgeführt.
  -- Falls der ursprüngliche Beleg nicht ausgeführt wurde, der Einzelzahlung jedoch nicht, so muss
  -- der Netto-Beleg aufgeführt werden.
  INSERT @tmp
    SELECT
      BuchungID           = BUC.KbBuchungID,
      BuchungsDatum       = BUC.ValutaDatum,
      BaPersonID          = PRS.BaPersonID,
      Klient              = PRS.DisplayText,
      BelegNr             = CONVERT(VARCHAR(20), ISNULL(BUC.BelegNr,BUC.KbBuchungID)),
      LA                  = BKA.KontoNr,
      LAProLeist          = NULL,
      LAText              = BKA.Name,
      Quoting             = BKA.Quoting,
      Buchungstext        = KBK.Buchungstext,
      VerwPeriodeVon      = KBK.VerwPeriodeVon,
      VerwPeriodeBis      = KBK.VerwPeriodeBis,
      BgSplittingArtCode  = BKA.BgSplittingArtCode,
      Splitting           = SPL.ShortText,
      TransferDatum       = BUC.TransferDatum,
      ValutaDatum         = BUC.ValutaDatum,
      ErfassungsDatum     = BUC.ErstelltDatum,
      DatumEffektiv       = HAB.BelegDatum,
      S                   = CASE WHEN POS.VerwaltungSD = 1 THEN 'S' END,
      D                   = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END,
      Bar                 = CASE WHEN BAP.KbAuszahlungsArtCode = 103 THEN 'b' END,
      Betrag              = CASE
                              WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                                THEN IsNull(dbo.fnWhGetBetragKontoauszug(
                                              BKA.BgSplittingArtCode, -KBK.Betrag, KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                              ELSE -KBK.Betrag
                            END,
      Betrag100           = KBK.Betrag,
      BetragEffektiv      = CASE
                              WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                                THEN ISNULL(dbo.fnWhGetBetragKontoauszug(
                                              BKA.BgSplittingArtCode, dbo.fnGetBetragEffektiv(
                                                                        BUC.KbBuchungID, -KBK.Betrag), KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                              ELSE -KBK.Betrag
                              END,
      EA                  = 'A',
      KbBuchungStatusCode = BUC.KbBuchungStatusCode,
      Doc                 = (SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END
                             FROM dbo.BgDokument WITH(READUNCOMMITTED)
                             WHERE BgPositionID = POS.BgPositionID),
      Auszahlart          = ART.Text,
      KreditorDebitor     = KRE.Kreditor + CHAR(13) + CHAR(10) + KRE.ZusatzInfo,
      PK                  = 'K',
      PLFall              = NULL,
      PLPerson            = NULL,
      BgPositionID        = POS.BgPositionID,
      BgBudgetID          = POS.BgBudgetID,
      BgBudgetName        = CASE WHEN BUD.Monat > 9 THEN '' ELSE '0' END + CONVERT(varchar(2), BUD.Monat) + '.' + SubString(CONVERT(varchar(4), BUD.Jahr), 3, 2),
      BgFinanzplanID      = BFP.BgFinanzplanID,
      FallBaPersonID      = FAL.BaPersonID,
      Rechnungsnummer     = POS.Rechnungsnummer,
      Verdichtet          = 0,
      GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
      OriginalValuta      = BUC.ValutaDatum,
      OriginalBuchungID   = BUC.KbBuchungID,
      KbBuchungID         = BUC.KbBuchungID,
      KbBuchungBruttoID   = NULL,
      StornoCode          = 0,
      IstGBL              = 0,
      IstEinzelzahlungGBL = 1,
      IstSiLei            = 0,
      AnzahlBelege        = 1,
      PositionImBeleg     = KBP.PositionImBeleg
    FROM dbo.FaFall                        FAL WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung            FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
      INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID = FLE.FaLeistungID
      INNER JOIN dbo.BgBudget              BUD WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
      INNER JOIN dbo.BgPosition            POS WITH (READUNCOMMITTED) ON BUD.BgBudgetID = POS.BgBudgetID
                                                                     AND (POS.BgKategorieCode = 101 AND POS.BgSpezkontoID IS NULL) -- Einzelzahlung vom GBL
      INNER JOIN dbo.KbBuchungKostenart    KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = POS.BgPositionID
      LEFT  JOIN dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = POS.BgPositionID
                                                                     AND BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                                                     FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                                                                                                     WHERE BgPositionID = POS.BgPositionID
                                                                                                     ORDER BY CASE
                                                                                                                WHEN BaPersonID = KBK.BaPersonID THEN 1
                                                                                                                WHEN BaPersonID IS NULL THEN 2
                                                                                                                ELSE 3
                                                                                                              END)
      LEFT  JOIN dbo.vwKreditor            KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
      INNER JOIN dbo.KbBuchung             BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KBK.KbBuchungID
      LEFT  JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.BgPositionID = POS.BgPositionID
      LEFT  JOIN dbo.vwPerson2             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KBK.BaPersonID
      LEFT  JOIN dbo.BgKostenart           BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID	= KBK.BgKostenartID
      LEFT  JOIN dbo.XLOVCode              SPL WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
      LEFT  JOIN dbo.XLOVCode              ART WITH (READUNCOMMITTED) ON ART.LOVName = 'KbAuszahlungsArt' AND ART.Code = BAP.KbAuszahlungsArtCode
      LEFT  JOIN dbo.KbBuchung             HAB WITH (READUNCOMMITTED) ON HAB.KbBuchungID = (SELECT TOP 1 BUCI.KbBuchungID
                                                                                            FROM dbo.KbOpAusgleich     KOA WITH(READUNCOMMITTED)
                                                                                              INNER JOIN dbo.KbBuchung BUCI WITH(READUNCOMMITTED) ON BUCI.KbBuchungID = KOA.AusgleichBuchungID
                                                                                            WHERE KOA.OpBuchungID = BUC.KbBuchungID
                                                                                              AND BUCI.BelegDatum IS NOT NULL)
    WHERE FAL.BaPersonID = @FallBaPersonID
      AND (@PersonenListe IS NULL OR KBK.BaPersonID IN (SELECT BaPersonID FROM @personen))
      AND (@LAList IS NULL AND BKA.KontoNr NOT IN (SELECT KontoNr FROM @LA_WV_VU_UB) OR
          -- Falls LaList = '': Standardabfrage. Die Liste umfasst Leistungsarten die standardmässig nicht dabei sind (siehe Spezifikation)
           (',' + @LAList + ',' LIKE '%,' + BKA.KontoNr + ',%'))
      AND (@EA IS NULL OR @EA = 'A')
      AND CASE @KbKontoZeitraumCode
            WHEN 1 THEN CASE WHEN BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
            WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, KBK.VerwPeriodeVon, ISNULL(KBK.VerwPeriodeBis, KBK.VerwPeriodeVon))
            WHEN 4 THEN CASE WHEN HAB.BelegDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
          END = 1
      AND KBP.KbBuchungBruttoPersonID IS NULL -- nur Einzelzahlungen ohne Bruttobeleg
      AND (@Buchungstext IS NULL OR POS.Buchungstext LIKE '%' + @Buchungstext + '%')
      AND (@InklGruen = 1 OR BUC.KbBuchungStatusCode NOT in (2,3,4,5,9))
      AND (@InklRot = 1 OR BUC.KbBuchungStatusCode <> 7)
      AND (@InklStorno = 1 OR BUC.KbBuchungStatusCode <> 8)
      AND BKA.KontoNr IN ('110', '120', '121'); -- Nur für GBL-Leistungsarten, da ansonsten die Berechnung pro Leistungsart nicht mehr stimmt
      -- TODO: gibt es auch in diesem Spezialfall den Spezialfall, dass der GBL nicht ausbezahlt wurde?

  -- Finde Monate, in denen EZ nicht separat ausgewiesen werden kann. z.B. weil der Abzug aufgrund falschem falschem Quoting nicht möglich ist.
  DELETE FROM @tmp
  WHERE IstEinzelzahlungGBL = 1
    AND BgBudgetID IN (SELECT DISTINCT TMP.BgBudgetID
                       FROM @tmp TMP
                         -- Essenz der EZ
                         INNER JOIN (SELECT BgBudgetID, BaPersonID, Betrag = SUM(Betrag)
                                     FROM @tmp
                                     WHERE IstEinzelzahlungGBL = 1
                                     GROUP BY BgBudgetID, BaPersonID) EIZ ON EIZ.BgBudgetID = TMP.BgBudgetID
                                                                         AND EIZ.BaPersonID = TMP.BaPersonID
                         -- Essenz der GBLs
                         -- Es kann mehrere GBL-Belege geben, z.B. durch Splitting auf Netto-Seite oder Quoting auf Brutto-Seite.
                         -- Der abzuziehende Betrag muss auf die einzelnen Buchungen aufgeteilt werden
                         -- Evt. ein Problem(?): falls nicht alle Netto-Buchungen zu einer Brutto-GBL-Buchung ausgeglichen sind (z.B. Barauszahlungen),
                         -- so wird der Anteil der Einzelzahlung nur auf Anzahl ausgeglichenen Buchungen gespalten und abgezogen.
                         LEFT  JOIN (SELECT BgBudgetID, BaPersonID, AnzahlGBL = COUNT(ALL BuchungID), AnteilBezahlt = CASE WHEN SUM(BetragEffektiv) = $0.00 THEN $0.00 ELSE SUM(Betrag) / SUM(BetragEffektiv) END
                                     FROM @tmp
                                     WHERE IstGBL = 1
                                     GROUP BY BgBudgetID, BaPersonID) GBL ON GBL.BgBudgetID = TMP.BgBudgetID AND GBL.BaPersonID = TMP.BaPersonID
                       WHERE IstGBL = 1
                         AND GBL.BgBudgetID IS NOT NULL -- Falls der Ursprungs-GBL nicht ausbezahlt wurde, so muss der Beleg erscheinen.
                         AND (TMP.BetragEffektiv > EIZ.Betrag / GBL.AnzahlGBL * GBL.AnteilBezahlt OR TMP.Betrag > EIZ.Betrag / GBL.AnzahlGBL * GBL.AnteilBezahlt));

  -- Ziehe die Einzelzahlungen beim GBL ab, damit die Gesamtsumme wieder stimmt
  UPDATE @tmp
    SET Betrag         = CASE
                           WHEN TMP.Betrag > EIZ.Betrag / GBL.AnzahlGBL * GBL.AnteilBezahlt THEN $0.00
                           ELSE TMP.Betrag - EIZ.Betrag / GBL.AnzahlGBL * GBL.AnteilBezahlt
                         END, -- Beide Beträge sind negativ
        BetragEffektiv = CASE
                           WHEN TMP.BetragEffektiv > EIZ.Betrag / GBL.AnzahlGBL * GBL.AnteilBezahlt THEN $0.00
                           ELSE TMP.BetragEffektiv - EIZ.Betrag / GBL.AnzahlGBL * GBL.AnteilBezahlt
                         END -- BetragEffektiv wird um den damals erwarteten Betrag gekürzt, nicht um den tatsächlich bezahlten Betrag.
  FROM @tmp TMP
    INNER JOIN -- Essenz der EZ
      (SELECT BgBudgetID , BaPersonID, Betrag = SUM(Betrag)
       FROM @tmp
       WHERE IstEinzelzahlungGBL = 1
       GROUP BY BgBudgetID, BaPersonID) EIZ ON EIZ.BgBudgetID = TMP.BgBudgetID AND EIZ.BaPersonID = TMP.BaPersonID
    INNER JOIN -- Essenz der GBLs
      -- Es kann mehrere GBL-Belege geben, z.B. durch Splitting auf Netto-Seite oder Quoting auf Brutto-Seite.
      -- Der abzuziehende Betrag muss auf die einzelnen Buchungen aufgeteilt werden
      -- Evt. ein Problem(?): falls nicht alle Netto-Buchungen zu einer Brutto-GBL-Buchung ausgeglichen sind (z.B. Barauszahlungen),
      -- so wird der Anteil der Einzelzahlung nur auf Anzahl ausgeglichenen Buchungen gespalten und abgezogen.
      (SELECT BgBudgetID AS BgBudgetID, BaPersonID, AnzahlGBL = COUNT(ALL BuchungID), AnteilBezahlt = CASE WHEN SUM(BetragEffektiv) = $0.00 THEN $0.00 ELSE SUM(Betrag) / SUM(BetragEffektiv) END
       FROM @tmp
       WHERE IstGBL = 1
       GROUP BY BgBudgetID, BaPersonID) GBL ON GBL.BgBudgetID = TMP.BgBudgetID AND GBL.BaPersonID = TMP.BaPersonID
  WHERE IstGBL = 1;
  -- Ende der Berechnung Einzelzahlungen ab GBL


  -- Nettobelege aus Betreibungskosten
  INSERT @tmp
  SELECT
    BuchungID           = BUC.KbBuchungID,
    BuchungsDatum       = BUC.ValutaDatum, --KBB.BelegDatum,
    BaPersonID          = PRS.BaPersonID,
    Klient              = PRS.DisplayText,
    BelegNr             = CONVERT(varchar(20),IsNull(BUC.BelegNr,BUC.KbBuchungID)),
    LA                  = BKA.KontoNr,
    LAProLeist          = NULL,
    LAText              = BKA.Name,
    Quoting             = BKA.Quoting,
    Buchungstext        = BUK.Buchungstext,
    VerwPeriodeVon      = BUK.VerwPeriodeVon,
    VerwPeriodeBis      = BUK.VerwPeriodeBis,
    BgSplittingArtCode  = BKA.BgSplittingArtCode,
    Splitting           = SPL.ShortText,
    TransferDatum       = BUC.TransferDatum,
    ValutaDatum         = BUC.ValutaDatum,
    ErfassungsDatum     = BUC.ErstelltDatum,
    DatumEffektiv       = NULL,
    S                   = NULL,
    D                   = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END,
    Bar                 = NULL,
    Betrag              = CASE
                            WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                              THEN ISNULL(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, -BUK.Betrag, BUK.VerwPeriodeVon, BUK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE -BUK.Betrag
                          END,
    Betrag100           = -BUK.Betrag,
    BetragEffektiv      = CASE
                            WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                              THEN ISNULL(dbo.fnWhGetBetragKontoauszug(
                                            BKA.BgSplittingArtCode, dbo.fnGetBetragEffektiv(
                                                                      BUC.KbBuchungID, -BUK.Betrag), BUK.VerwPeriodeVon, BUK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE -BUK.Betrag
                          END,
    EA                  = 'A',
    KbBuchungStatusCode = BUC.KbBuchungStatusCode,
    Doc                 = (SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END
                           FROM dbo.KbDokument WITH(READUNCOMMITTED)
                           WHERE KbBuchungID = BUC.KbBuchungID),
    Auszahlart          = ART.Text,
    KreditorDebitor     = KRE.Kreditor + CHAR(13) + CHAR  (10) + KRE.ZusatzInfo,
    PK                  = 'K',
    PLFall              = NULL,
    PLPerson            = NULL,
    BgPositionID        = NULL,
    BgBudgetID          = NULL,
    BgBudgetName        = NULL,
    BgFinanzplanID      = NULL,
    FallBaPersonID      = FAL.BaPersonID,
    Rechnungsnummer     = NULL,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = BUC.ValutaDatum,
    OriginalBuchungID   = BUC.KbBuchungID,
    KbBuchungID         = BUC.KbBuchungID,
    KbBuchungBruttoID   = NULL,
    StornoCode          = 0,
    IstGBL              = 0,
    IstEinzelzahlungGBL = 0,
    IstSiLei            = 0,
    AnzahlBelege        = 1,
    PositionImBeleg     = BUK.PositionImBeleg
  FROM dbo.FaFall                     FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung         LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
    INNER JOIN dbo.KbBuchung          BUC WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BUC.FaLeistungID
    INNER JOIN dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) ON BUK.KbBuchungID = BUC.KbBuchungID
    LEFT  JOIN dbo.vwPerson2          PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
    INNER JOIN dbo.BgKostenart        BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BUK.BgKostenartID 
                                                                AND BKA.KontoNr IN ('365', '366') -- Inkasso-Kosten WH, o.KK-Pr.
    LEFT  JOIN dbo.vwKreditor         KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
    LEFT  JOIN dbo.XLOVCode           AZA WITH (READUNCOMMITTED) ON AZA.LOVName = 'KbAuszahlungsart' AND AZA.Code = BUC.KbAuszahlungsArtCode
    LEFT  JOIN dbo.XLOVCode           PRO WITH (READUNCOMMITTED) ON PRO.LOVName = 'FaProzess' AND PRO.Code = LEI.FaProzessCode
    LEFT  JOIN dbo.XLOVCode           SPL WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
    LEFT  JOIN dbo.XLOVCode           ART WITH (READUNCOMMITTED) ON ART.LOVName = 'KbAuszahlungsArt' AND ART.Code = BUC.KbAuszahlungsArtCode
  WHERE FAL.BaPersonID = @FallBaPersonID 
    AND BUC.KbBuchungTypCode = 2 
    AND  -- manuel
        (@PersonenListe IS NULL OR BUK.BaPersonID in (SELECT BaPersonID FROM @personen)) 
    AND (@LAList IS NULL AND BKA.KontoNr NOT IN (SELECT KontoNr FROM @LA_WV_VU_UB) 
      -- Falls LaList = '': Standardabfrage. Die Liste umfasst Leistungsarten die standardmässig nicht dabei sind (siehe Spezifikation)
      OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) 
    AND (@EA IS NULL OR @EA = 'A') 
    AND CASE @KbKontoZeitraumCode
          WHEN 1 THEN CASE WHEN BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
          WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, BUK.VerwPeriodeVon, IsNull(BUK.VerwPeriodeBis, BUK.VerwPeriodeVon))
          WHEN 4 THEN CASE WHEN BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        END = 1 
    AND (@Buchungstext IS NULL OR BUK.Buchungstext like '%' + @Buchungstext + '%') 
    AND (@InklGruen = 1 OR BUC.KbBuchungStatusCode NOT in (2,3,4,5,9)) 
    AND (@InklRot = 1 OR BUC.KbBuchungStatusCode <> 7)
  OPTION (FORCE ORDER)

  -- Bruttobelege aus Sicherheitsleistungen (SiLei)
  INSERT @tmp
  SELECT DISTINCT
    BuchungID           = BUC.KbBuchungBruttoID,
    BuchungsDatum       = BUC.ValutaDatum,
    BaPersonID          = PRS.BaPersonID,
    Klient              = PRS.DisplayText,
    BelegNr             = CONVERT(varchar(20),IsNull(BUC.BelegNr,BUC.KbBuchungBruttoID)),
    LA                  = BKA.KontoNr,
    LAProLeist          = NULL,
    LAText              = BKA.Name,
    Quoting             = BKA.Quoting,
    Buchungstext        = BUP.Buchungstext,
    VerwPeriodeVon      = BUP.VerwPeriodeVon,
    VerwPeriodeBis      = BUP.VerwPeriodeBis,
    BgSplittingArtCode  = BKA.BgSplittingArtCode,
    Splitting           = SPL.ShortText,
    TransferDatum       = BUC.TransferDatum,
    ValutaDatum         = BUC.ValutaDatum,
    ErfassungsDatum     = BUC.ErfassungsDatum,
    DatumEffektiv       = BUC.DatumEffektiv,
    S                   = NULL,
    D                   = NULL,
    Bar                 = NULL,
    Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                            THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, BUP.Betrag, BUP.VerwPeriodeVon, BUP.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE BUP.Betrag
                          END,
    Betrag100           = BUP.Betrag,
    BetragEffektiv      = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                            THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, BUP.Betrag, BUP.VerwPeriodeVon, BUP.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE BUP.Betrag
                          END,
    EA                  = CASE WHEN BUP.Betrag <= $0.00 THEN 'A' ELSE 'E' END,
    KbBuchungStatusCode = BUC.KbBuchungStatusCode,
    Doc                 = NULL,
    Auszahlart          = NULL,
    KreditorDebitor     = DEBI.Name + char(13) + char(10) + DEBI.AdresseMehrzeilig,
    PK                  = 'K',
    PLFall              = NULL,
    PLPerson            = NULL,
    BgPositionID        = NULL,
    BgBudgetID          = NULL,
    BgBudgetName        = NULL,
    BgFinanzplanID      = NULL,
    FallBaPersonID      = FAL.BaPersonID,
    Rechnungsnummer     = NULL,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = BUC.ValutaDatum,
    OriginalBuchungID   = BUC.KbBuchungBruttoID,
    KbBuchungID         = NULL,
    KbBuchungBruttoID   = BUC.KbBuchungBruttoID,
    StornoCode          = 0,
    IstGBL              = 0,
    IstEinzelzahlungGBL = 0,
    IstSiLei            = 1,
    AnzahlBelege        = 1,
    BUP.PositionImBeleg
  FROM dbo.BaSicherheitsleistungPosition SIP  WITH (READUNCOMMITTED)
    INNER JOIN dbo.BaSicherheitsleistung SIC  WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
    INNER JOIN dbo.KbBuchungBrutto       BUC  WITH (READUNCOMMITTED) ON BUC.KbBuchungBruttoID = SIP.KbBuchungBruttoID
    INNER JOIN dbo.KbBuchungBruttoPerson BUP  WITH (READUNCOMMITTED) ON BUP.KbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.FaLeistung            LEI  WITH (READUNCOMMITTED) ON LEI.BaPersonID = SIC.BaPersonID 
                                                                    AND LEI.FaProzessCode = 300 
                                                                    AND LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                                                            FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                                                                                            WHERE BaPersonID = SIC.BaPersonID 
                                                                                              AND FaProzessCode = 300
                                                                                            ORDER BY DatumVon DESC)
    LEFT  JOIN dbo.FaFall                FAL  WITH (READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
    LEFT  JOIN dbo.vwPerson2             PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = SIC.BaPersonID
    INNER JOIN dbo.BgKostenart           BKA  WITH (READUNCOMMITTED) ON BKA.BgKostenartID = IsNull(BUP.SpezBgKostenartID,BUC.BgKostenartID) 
                                                                    AND BKA.KontoNr IN ('860','861','862','311')
    LEFT  JOIN dbo.XLOVCode              SPL  WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
    LEFT  JOIN dbo.KbBuchungBrutto       STO  WITH (READUNCOMMITTED) ON STO.StorniertKbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.KbBuchungBrutto       NEU  WITH (READUNCOMMITTED) ON NEU.NeubuchungVonKbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.vwInstitution2        DEBI WITH (READUNCOMMITTED) ON DEBI.BaInstitutionID = SIC.BaInstitutionID

  WHERE FAL.BaPersonID = @FallBaPersonID 
    AND (@PersonenListe IS NULL OR BUP.BaPersonID in (SELECT BaPersonID FROM @personen)) 
    AND (@LAList IS NULL AND BKA.KontoNr NOT IN (SELECT KontoNr FROM @LA_WV_VU_UB) 
      -- Falls LaList = '': Standardabfrage. Die Liste umfasst Leistungsarten die standardmässig nicht dabei sind (siehe Spezifikation)
      OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) 
    AND (@EA IS NULL OR @EA = CASE WHEN BUP.Betrag <= $0.00 THEN 'A' ELSE 'E' END) 
    AND CASE @KbKontoZeitraumCode
          WHEN 1 THEN CASE WHEN BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
          WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, BUP.VerwPeriodeVon, IsNull(BUP.VerwPeriodeBis,BUP.VerwPeriodeVon))
          WHEN 4 THEN CASE WHEN BUC.DatumEffektiv BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        END = 1 
    AND (@Buchungstext IS NULL OR BUP.Buchungstext like '%' + @Buchungstext + '%') 
    AND (@InklGruen = 1 OR BUC.KbBuchungStatusCode NOT in (2,3,4,5,9)) 
    AND (@InklRot = 1 OR BUC.KbBuchungStatusCode <> 7)
    AND (@InklStorno = 1 OR BUC.KbBuchungStatusCode <> 8)

    -- Bruttobelege aus Sicherheitsleistungen (SiLei) (Teil 2: BUC.StorniertKbBuchungBruttoID = SIP.KbBuchungBruttoID)
  INSERT @tmp
    SELECT DISTINCT
    BuchungID           = BUC.KbBuchungBruttoID,
    BuchungsDatum       = BUC.ValutaDatum,
    BaPersonID          = PRS.BaPersonID,
    Klient              = PRS.DisplayText,
    BelegNr             = CONVERT(varchar(20),IsNull(BUC.BelegNr,BUC.KbBuchungBruttoID)),
    LA                  = BKA.KontoNr,
    LAProLeist          = NULL,
    LAText              = BKA.Name,
    Quoting             = BKA.Quoting,
    Buchungstext        = BUP.Buchungstext,
    VerwPeriodeVon      = BUP.VerwPeriodeVon,
    VerwPeriodeBis      = BUP.VerwPeriodeBis,
    BgSplittingArtCode  = BKA.BgSplittingArtCode,
    Splitting           = SPL.ShortText,
    TransferDatum       = BUC.TransferDatum,
    ValutaDatum         = BUC.ValutaDatum,
    ErfassungsDatum     = BUC.ErfassungsDatum,
    DatumEffektiv       = BUC.DatumEffektiv,
    S                   = NULL,
    D                   = NULL,
    Bar                 = NULL,
    Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                            THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, BUP.Betrag, BUP.VerwPeriodeVon, BUP.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE BUP.Betrag
                          END,
    Betrag100           = BUP.Betrag,
    BetragEffektiv      = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                            THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, BUP.Betrag, BUP.VerwPeriodeVon, BUP.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                            ELSE BUP.Betrag
                          END,
    EA                  = CASE WHEN BUP.Betrag <= $0.00 THEN 'A' ELSE 'E' END,
    KbBuchungStatusCode = BUC.KbBuchungStatusCode,
    Doc                 = NULL,
    Auszahlart          = NULL,
    KreditorDebitor     = DEBI.Name + char(13) + char(10) + DEBI.AdresseMehrzeilig,
    PK                  = 'K',
    PLFall              = NULL,
    PLPerson            = NULL,
    BgPositionID        = NULL,
    BgBudgetID          = NULL,
    BgBudgetName        = NULL,
    BgFinanzplanID      = NULL,
    FallBaPersonID      = FAL.BaPersonID,
    Rechnungsnummer     = NULL,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = BUC.ValutaDatum,
    OriginalBuchungID   = BUC.KbBuchungBruttoID,
    KbBuchungID         = NULL,
    KbBuchungBruttoID   = BUC.KbBuchungBruttoID,
    StornoCode          = 0,
    IstGBL              = 0,
    IstEinzelzahlungGBL = 0,
    IstSiLei            = 1,
    AnzahlBelege        = 1,
    BUP.PositionImBeleg
    FROM dbo.BaSicherheitsleistungPosition SIP  WITH (READUNCOMMITTED)
    INNER JOIN dbo.BaSicherheitsleistung SIC  WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
    INNER JOIN dbo.KbBuchungBrutto       BUC  WITH (READUNCOMMITTED) ON BUC.StorniertKbBuchungBruttoID = SIP.KbBuchungBruttoID
    INNER JOIN dbo.KbBuchungBruttoPerson BUP  WITH (READUNCOMMITTED) ON BUP.KbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.FaLeistung            LEI  WITH (READUNCOMMITTED) ON LEI.BaPersonID = SIC.BaPersonID 
                                                                    AND LEI.FaProzessCode = 300 
                                                                    AND LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                                                            FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                                                                                            WHERE BaPersonID = SIC.BaPersonID 
                                                                                              AND FaProzessCode = 300
                                                                                            ORDER BY DatumVon DESC)
    LEFT  JOIN dbo.FaFall                FAL  WITH (READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
    LEFT  JOIN dbo.vwPerson2             PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = SIC.BaPersonID
    INNER JOIN dbo.BgKostenart           BKA  WITH (READUNCOMMITTED) ON BKA.BgKostenartID = IsNull(BUP.SpezBgKostenartID,BUC.BgKostenartID) 
                                                                    AND BKA.KontoNr IN ('860','861','862','311')
    LEFT  JOIN dbo.XLOVCode              SPL  WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
    LEFT  JOIN dbo.KbBuchungBrutto       STO  WITH (READUNCOMMITTED) ON STO.StorniertKbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.KbBuchungBrutto       NEU  WITH (READUNCOMMITTED) ON NEU.NeubuchungVonKbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.vwInstitution2        DEBI WITH (READUNCOMMITTED) ON DEBI.BaInstitutionID = SIC.BaInstitutionID
    WHERE FAL.BaPersonID = @FallBaPersonID 
    AND (@PersonenListe IS NULL OR BUP.BaPersonID in (SELECT BaPersonID FROM @personen)) 
    AND (@LAList IS NULL AND BKA.KontoNr NOT IN (SELECT KontoNr FROM @LA_WV_VU_UB) 
      -- Falls LaList = '': Standardabfrage. Die Liste umfasst Leistungsarten die standardmässig nicht dabei sind (siehe Spezifikation)
      OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) 
    AND (@EA IS NULL OR @EA = CASE WHEN BUP.Betrag <= $0.00 THEN 'A' ELSE 'E' END) 
    AND CASE @KbKontoZeitraumCode
          WHEN 1 THEN CASE WHEN BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
          WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, BUP.VerwPeriodeVon, IsNull(BUP.VerwPeriodeBis,BUP.VerwPeriodeVon))
          WHEN 4 THEN CASE WHEN BUC.DatumEffektiv BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        END = 1 
    AND (@Buchungstext IS NULL OR BUP.Buchungstext like '%' + @Buchungstext + '%') 
    AND (@InklGruen = 1 OR BUC.KbBuchungStatusCode NOT in (2,3,4,5,9)) 
    AND (@InklRot = 1 OR BUC.KbBuchungStatusCode <> 7)
    AND (@InklStorno = 1 OR BUC.KbBuchungStatusCode <> 8)
    
  IF @InklProLeist = 1 OR @InklVermittlungsfall = 1 
  BEGIN
    IF @InklStorno <> 1 
    BEGIN
      -- Finde alle Proleist-Buchungen, zu denen ein KiSS-Storno existiert. Diese Belege müssen
      -- nachher aus der Resultatmenge herausgefiltert werden
      INSERT INTO @StornierteProleistBuchungen
        SELECT DISTINCT MIG.MigDetailBuchungID, MIG.NummernKreis, MIG.BelegNummer, MIG.KissLeistungsart, MIG.BaPersonID--, M1.BetragSTO, SUM(MIG.Betrag)
        FROM FaFall                   FAL (READUNCOMMITTED)
          INNER JOIN FaLeistung       LEI (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
          INNER JOIN MigDetailBuchung MIG (READUNCOMMITTED) ON MIG.FaLeistungID = LEI.FaLeistungID
          INNER JOIN KbBuchungBrutto  KBB (READUNCOMMITTED) ON KBB.MigDetailBuchungID = MIG.MigDetailBuchungID
        WHERE FAL.BaPersonID = @FallBaPersonID
          AND KBB.KbBuchungStatusCode = 8
      -- Proleist-Buchungen mit gleichem Nummernkreis, Belegnummer, Kissleistungsart und (falls gequoted) gleicher Person.
      -- Diese wurden mitumgebucht und sind somit auch 'storniert'.
      INSERT INTO @StornierteProleistBuchungen
      SELECT DISTINCT MIG.MigDetailBuchungID, MIG.NummernKreis, MIG.BelegNummer, MIG.KissLeistungsart, MIG.BaPersonID--, M1.BetragSTO, SUM(MIG.Betrag)
      FROM @StornierteProleistBuchungen STO
        INNER JOIN dbo.BgKostenart      BKA (READUNCOMMITTED) ON BKA.KontoNr = STO.KissLeistungsart
        INNER JOIN MigDetailBuchung     MIG (READUNCOMMITTED) ON STO.NummernKreis = MIG.NummernKreis 
                                                             AND STO.BelegNummer = MIG.BelegNummer
                                                             AND STO.KissLeistungsart = MIG.KissLeistungsart
                                                             AND (BKA.Quoting = 1 OR STO.BaPersonID = MIG.BaPersonID)
                                                             AND STO.MigDetailBuchungID <> MIG.MigDetailBuchungID -- Keine ID doppelt einfügen

    END

    INSERT @tmp
    SELECT
      BuchungID           = BUC.BelegNummer,
      BuchungsDatum       = BUC.BuchungsDatum,
      BaPersonID          = PRS.BaPersonID,
      Klient              = PRS.DisplayText,
      BelegNr             = BUC.NummernKreis + '-' + CONVERT(varchar(20),BUC.BelegNummer),
      LA                  = BUC.KissLeistungsart,
      LAProLeist          = BUC.LeistungsArtNrProLeist,
      LAText              = BUC.LeistungsArtText,
      Quoting             = IsNull(BKA.Quoting,0),
      Buchungstext        = BUC.Buchungstext,
      VerwPeriodeVon      = BUC.VerwendungVon,
      VerwPeriodeBis      = BUC.VerwendungBis,
      BgSplittingArtCode  = NULL,
      Splitting           = NULL,
      TransferDatum       = NULL,
      ValutaDatum         = BUC.FaelligkeitsDatum,
      ErfassungsDatum     = BUC.ErfassungsDatum,
      DatumEffektiv       = NULL,
      S                   = NULL,
      D                   = NULL,
      Bar                 = CASE WHEN BUC.NummernKreis like 'B%' THEN 'b' END,
      Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                              THEN IsNull(dbo.fnWhGetBetragKontoauszug(IsNull(BKA.BgSplittingArtCode, 2/*Monat*/), -BUC.Betrag, BUC.VerwendungVon, BUC.VerwendungBis, @DatumVon, @DatumBis), $0.00)
                              ELSE -BUC.Betrag
                            END,
      Betrag100           = -BUC.Betrag,
      BetragEffektiv      = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                              THEN IsNull(dbo.fnWhGetBetragKontoauszug(IsNull(BKA.BgSplittingArtCode, 2/*Monat*/), -BUC.Betrag, BUC.VerwendungVon, BUC.VerwendungBis, @DatumVon, @DatumBis), $0.00)
                              ELSE -BUC.Betrag
                            END,
      EA                  = CASE WHEN SubString(BUC.NummernKreis, 1, 1) IN ('B','D','E','F') THEN 'A' ELSE 'E' END,
      KbBuchungStatusCode = NULL,
      Doc                 = NULL,
      Auszahlart          = NULL,
      KreditorDebitor     = IsNull(BUC.DEBKREVorname + char(13) + char(10), '') +
                            IsNull(BUC.DEBKREName + char(13) + char(10), '' ) +
                            IsNull(BUC.DEBKREZusatzzeile, '' ),
      PK                  = 'P',
      PLFall              = BUC.FallProleist,
      PLPerson            = BUC.PersonProleist,
      BgPositionID        = NULL,
      BgBudgetID          = NULL,
      BgBudgetName        = NULL,
      BgFinanzplanID      = NULL,
      FallBaPersonID      = NULL,
      Rechnungsnummer     = NULL,
      Verdichtet          = 0,
      GroupBaPersonID     = CASE WHEN IsNull(BKA.Quoting,0) = 1 THEN -1 ELSE PRS.BaPersonID END,
      OriginalValuta      = BUC.FaelligkeitsDatum,
      OriginalBuchungID   = BUC.MigDetailBuchungID,
      KbBuchungID         = NULL,
      KbBuchungBruttoID   = NULL,
      StornoCode          = 0,
      IstGBL              = 0,
      IstEinzelzahlungGBL = 0,
      IstSiLei            = 0,
      AnzahlBelege        = 1,
      PosImBeleg          = BUC.BelegPos
    FROM dbo.FaFall                           FAL WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung               FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
      INNER JOIN dbo.MigDetailBuchung         BUC WITH (READUNCOMMITTED) ON BUC.FaLeistungID = FLE.FaLeistungID
      LEFT  JOIN dbo.vwPerson2                PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BUC.BaPersonID
      LEFT  JOIN dbo.BgKostenart              BKA WITH (READUNCOMMITTED) ON BKA.KontoNr = BUC.KissLeistungsart
      LEFT  JOIN @StornierteProleistBuchungen STO ON STO.MigDetailBuchungID = BUC.MigDetailBuchungID
    WHERE FAL.BaPersonID = @FallBaPersonID 
      AND BUC.BuchungsStatusCode = 1 /*Korrekt*/
      AND BUC.LeistungsArtNrProLeist IS NOT NULL 
      AND (@PersonenListe IS NULL OR BUC.BaPersonID in (SELECT BaPersonID FROM @personen)) 
      AND (@LAList IS NULL AND BUC.KissLeistungsart NOT IN (SELECT KontoNr FROM @LA_WV_VU_UB) 
        -- Falls LaList = '': Standardabfrage. Die Liste umfasst Leistungsarten die standardmässig nicht dabei sind (siehe Spezifikation)
        OR (',' + @LAList + ',' like '%,' + BUC.KissLeistungsart + ',%')) 
      AND (@EA IS NULL OR @EA = CASE WHEN SubString(BUC.NummernKreis, 1, 1) IN ('B','D','E','F') THEN 'A' ELSE 'E' END) 
      AND ((@InklVermittlungsfall = 1 AND BUC.LeistungsArtNrProLeist >= 9000) 
        OR (@InklProLeist = 1 AND BUC.LeistungsArtNrProLeist < 9000)) 
      AND CASE @KbKontoZeitraumCode
            WHEN 1 THEN CASE WHEN BUC.FaelligkeitsDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
            WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, BUC.VerwendungVon, IsNull(BUC.VerwendungBis, BUC.VerwendungVon))
            WHEN 4 THEN 0 -- Proleist-Buchungen können nicht durch Effektiv-Datum gefunden werden, da das Effektiv-Datum von Proleistbuchungen unbekannt ist.
          END = 1 
      AND (@Buchungstext IS NULL OR BUC.Buchungstext like '%' + @Buchungstext + '%') 
      AND STO.MigDetailBuchungID IS NULL -- Die Buchung darf nicht umgebucht worden sein. Falls @inklStorno = 1,
      -- dann ist @StornierteProleistBuchungen nicht befüllt.
  END

  -- Verdichtung
  IF @Verdichtet = 1 
  BEGIN
    INSERT @tmp
    SELECT BuchungID,
       MAX(BuchungsDatum),
       BaPersonID = CASE WHEN MIN(BaPersonID) = MAX(BaPersonID) THEN MAX(BaPersonID) END,
       Klient     = CASE WHEN T.Quoting = 1 AND COUNT(DISTINCT BaPersonID) > 1
                      THEN 'ganze UE (' + CONVERT(varchar,COUNT(DISTINCT BaPersonID)) + ')'
                      ELSE MAX(Klient)
                    END,
       MAX(BelegNr),
       LA,
       MAX(LAProLeist),
       MAX(LAText),
       Quoting,
       IsNull(Buchungstext, ''),
       VerwPeriodeVon,
       VerwPeriodeBis,
       MAX(BgSplittingArtCode),
       MAX(Splitting),
       MAX(TransferDatum),
       MAX(ValutaDatum),
       MIN(ErfassungsDatum),
       MAX(DatumEffektiv),
       MAX(S),
       MAX(D),
       MAX(Bar),
       SUM(Betrag),
       SUM(Betrag100),
       SUM(BetragEffektiv),
       MAX(EA),
       MAX(KbBuchungStatusCode),
       MAX(Doc),
       MAX(Auszahlart),
       MAX(KreditorDebitor),
       MAX(PK),
       NULL,NULL, -- PLFall,PLPerson,
       MAX(BgPositionID),
       MAX(BgBudgetID),
       MAX(BgBudgetName),
       MAX(BgFinanzplanID),
       MAX(FallBaPersonID),
       MAX(Rechnungsnummer),
       Verdichtet = 1,
       GroupBaPersonID,
       MIN(OriginalValuta),
       MIN(OriginalBuchungID),
       MIN(KbBuchungID),
       MIN(KbBuchungBruttoID),
       MIN(StornoCode),
       MAX(CONVERT(INT,IstGBL)),
       0, -- IstEinzelzahlungGBL (wird nur in der Zwischenrechnung verwendet)
       MAX(CONVERT(INT, IstSiLei)),
       MAX(AnzahlBelege), -- Anzahl Belege,
       PosImBeleg = NULL -- Macht keinen Sinn in der verdichteten Ansicht
    FROM @tmp T
    WHERE PK IS NULL OR PK <> 'P' AND Verdichtet = 0
    GROUP BY BuchungID,LA,GroupBaPersonID,Quoting,Buchungstext,VerwPeriodeVon,VerwPeriodeBis;

    IF (@InklProLeist = 1 OR @InklVermittlungsfall = 1)
    BEGIN
      INSERT @tmp
      SELECT
        MAX(BuchungID),
        MIN(BuchungsDatum),
        BaPersonID = CASE WHEN MIN(BaPersonID) = MAX(BaPersonID) THEN MAX(BaPersonID) END,
        Klient     = CASE WHEN T.Quoting = 1 AND COUNT(DISTINCT BaPersonID) > 1
                       THEN 'ganze UE (' + CONVERT(varchar,COUNT(DISTINCT BaPersonID)) + ')'
                       ELSE MAX(Klient)
                     END,
        BelegNr,
        LA,
        MAX(LAProLeist),
        MAX(LAText),
        Quoting,
        Buchungstext,
        VerwPeriodeVon,
        VerwPeriodeBis,
        NULL,NULL,NULL, --BgSplittingArtCode,Splitting,TransferDatum
        MIN(ValutaDatum),
        MIN(ErfassungsDatum),
        NULL, -- effektives zahldatum
        NULL,NULL, --S,D
        MAX(Bar),
        SUM(Betrag),
        SUM(Betrag100),
        SUM(BetragEffektiv),
        MAX(EA),
        NULL,NULL,NULL, -- EA,KbBuchungStatusCode,Doc,Auszahlart
        MAX(KreditorDebitor),
        'P',
        MAX(PLFall),
        CASE WHEN COUNT(*) > 1 THEN MAX(PLPerson) END,
        NULL,NULL,NULL,NULL,NULL,NULL, -- BgPositionID,BgBudgetID,BgBudgetName,BgFinanzplanID,FallBaPersonID,Rechnungsnummer
        Verdichtet = 1,
        GroupBaPersonID,
        MIN(OriginalValuta),
        MIN(OriginalBuchungID),
        NULL,
        NULL,
        MIN(StornoCode),
        0, -- IstGBL (wird nur in der Zwischenrechnung verwendet)
        0, -- IstEinzelzahlungGBL (wird nur in der Zwischenrechnung verwendet)
        MAX(CONVERT(INT, IstSiLei)),
        MAX(AnzahlBelege), -- Anzahl belege
        PosImBeleg = NULL -- Macht keinen Sinn in der verdichteten Ansicht
      FROM   @tmp T
      WHERE  PK = 'P' 
        AND Verdichtet = 0
      GROUP BY BelegNr, LA, GroupBaPersonID, Quoting, Buchungstext, VerwPeriodeVon, VerwPeriodeBis;
    END;
  END;

  RETURN;
END;

