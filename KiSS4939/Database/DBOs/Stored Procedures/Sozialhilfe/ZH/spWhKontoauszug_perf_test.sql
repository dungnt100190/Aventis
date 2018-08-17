SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhKontoauszug_perf_test
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhKontoauszug_perf_test.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:44 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .c
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhKontoauszug_perf_test.sql $
 * 
 * 3     11.12.09 12:51 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
 *
 * 
 * 6     3.03.09 01:10 mweber
 * Anzeige der Silei-Rückzahlungen LA 860/861/862/311
 * 
 * 5     2.03.09 21:10 Stahel-1
 * #43: Netto-Storno Implementiert für TA Rel 1
 * 
 * 3     16.02.2009 16:00 mweber
 * #44: Anzeige der Mahnstufe in neuer Spalte
 * 
 * 2     10.02.09 17:18 Stahel-1
 * Mantis 3875: STO und NEU-Buchungen werden nun auch korrekt im
 * Kontoauszug angezeigt
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhKontoauszug_perf_test]
 (@FallBaPersonID int,
  @BaPersonID int,
  @KbKontoZeitraumCode int,  -- 1 Buchungsdatum (= Valutadatum), 3 Verwendungsperiode
  @DatumVon datetime,
  @DatumBis datetime,
  @Buchungstext varchar(200),
  @LAList varchar(2000),
  @Verdichtet bit,
  @InklProLeist bit,
  @InklVermittlungsfall bit,
  @InklGruen bit,
  @InklRot bit)
AS

  SET @KbKontoZeitraumCode = IsNull(@KbKontoZeitraumCode,1)
  SET @DatumVon            = IsNull(@DatumVon,'19000101')
  SET @DatumBis            = IsNull(@DatumBis,'29000101')
  SET @LAList              = IsNull(@LAList,'')

  DECLARE @Saldo       money

  DECLARE @tmp TABLE (
    BuchungID           int,
    BuchungsDatum       datetime,
    BaPersonID          int,
	Klient              varchar(200),
	BelegNr             varchar(20),
	LA                  varchar(10),
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
    S                   varchar(1),
    D                   varchar(1),
    Bar                 varchar(1),
	Betrag              money,
    Betrag100           money,
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
    BgFinanzplanID      int,
    FallBaPersonID      int,
    Verdichtet          bit,
    GroupBaPersonID     int,
    OriginalValuta      datetime,
    OriginalBuchungID   int,
    KbBuchungID         int, --Nettobeleg
    StornoCode          int)  -- 0: Original, 1: Storno, 2: Neubuchung

  -- Bruttobelege aus W-Budgets
  INSERT @tmp
  SELECT DISTINCT
	BuchungID           = KBB.KbBuchungBruttoID,
	BuchungsDatum       = KBB.ValutaDatum, --KBB.BelegDatum,
	BaPersonID          = PRS.BaPersonID,
	Klient              = PRS.DisplayText,
	BelegNr             = CONVERT(varchar(20),IsNull(KBB.BelegNr,KBB.KbBuchungBruttoID)),
	LA                  = BKA.KontoNr,
	LAText              = BKA.KontoNr + ' ' + BKA.Name,
    Quoting             = BKA.Quoting,
	Buchungstext        = KBK.Buchungstext,
	VerwPeriodeVon      = KBK.VerwPeriodeVon,
	VerwPeriodeBis      = KBK.VerwPeriodeBis,
	BgSplittingArtCode  = BKA.BgSplittingArtCode,
	Splitting           = SPL.ShortText,
	TransferDatum       = KBB.TransferDatum,
	ValutaDatum         = KBB.ValutaDatum,
    ErfassungsDatum     = KBB.ErfassungsDatum,
    S                   = CASE WHEN BPO.VerwaltungSD = 1 THEN 'S' END,
    D                   = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END,
    Bar                 = CASE WHEN BAP.KbAuszahlungsArtCode = 103 THEN 'b' END,
	Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                          THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, KBK.Betrag, KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                          ELSE KBK.Betrag
                          END,
	Betrag100           = KBK.Betrag,
	EA                  = CASE WHEN KBK.Betrag <= $0.00 THEN 'A' ELSE 'E' END,
	KbBuchungStatusCode = CASE WHEN KBB.KbBuchungStatusCode = 8 -- Stornierter Bruttobeleg
						  THEN KBB.KbBuchungStatusCode	-- Wir haben eine Stornobuchung gefunden (Stornierter Original-Beleg oder den STO-Beleg), d.h. wir wollen den Brutto-Status anzeigen, unabhängig vom Netto-Status
						  ELSE
								CASE WHEN BUC.KbBuchungStatusCode IS NOT NULL
								THEN BUC.KbBuchungStatusCode
								ELSE KBB.KbBuchungStatusCode
								END
						  END,
    Doc                 = (SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END FROM BgDokument WHERE BgPositionID = BPO.BgPositionID),
	Auszahlart          = ART.Text,
	KreditorDebitor     = COALESCE(KRE.Kreditor + char(13) + char(10) + KRE.ZusatzInfo,
								   DEBI.Name + char(13) + char(10) + DEBI.AdresseMehrzeilig,
								   DEBP.NameVorname + char(13) + char(10) + DEBP.WohnsitzMehrzeilig),
	PK                  = 'K',
	PLFall              = NULL,
	PLPerson            = NULL,
    BgPositionID        = BPO.BgPositionID,
    BgBudgetID          = BBG.BgBudgetID,
    BgFinanzplanID      = BFP.BgFinanzplanID,
    FallBaPersonID      = FAL.BaPersonID,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = KBB.ValutaDatum,
    OriginalBuchungID   = KBB.KbBuchungBruttoID,
    KbBuchungID         = BUC.KbBuchungID,
    StornoCode          = CASE
                          WHEN KBB.NeubuchungVonKbBuchungBruttoID IS NOT NULL THEN 2
                          WHEN KBB.StorniertKbBuchungBruttoID IS NOT NULL  THEN 1
                          ELSE 0
                          END
  FROM dbo.FaFall                            FAL WITH (READUNCOMMITTED)
	INNER JOIN dbo.FaLeistung                FLE WITH (READUNCOMMITTED) ON FLE.FaFallID          = FAL.FaFallID
	INNER JOIN dbo.KbBuchungBrutto           KBB WITH (READUNCOMMITTED) ON KBB.FaLeistungID        = FLE.FaLeistungID
	LEFT JOIN dbo.BgBudget					 BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID		= KBB.BgBudgetID
	LEFT JOIN dbo.BgFinanzplan               BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID      = BBG.BgFinanzplanID
	INNER JOIN dbo.KbBuchungBruttoPerson     KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungBruttoID = KBB.KbBuchungBruttoID
    LEFT  JOIN dbo.BgPosition                BPO WITH (READUNCOMMITTED) ON BPO.BgPositionID      = KBK.BgPositionID
    LEFT  JOIN dbo.BgAuszahlungPerson        BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID AND
                                                BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                            FROM   dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                                                                            WHERE  BgPositionID = BPO.BgPositionID
                                                                            ORDER BY
                                                                              CASE WHEN BaPersonID = KBK.BaPersonID THEN 1
                                                                                   WHEN BaPersonID IS NULL THEN 2
                                                                              ELSE 3
                                                                            END)
    LEFT  JOIN dbo.vwKreditor               KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
    LEFT  JOIN dbo.vwInstitution            DEBI ON DEBI.BaInstitutionID = BPO.BaInstitutionID AND
                                                BPO.BgKategorieCode = 1
    LEFT  JOIN dbo.vwPerson                 DEBP ON DEBP.BaPersonID = BPO.DebitorBaPersonID
	LEFT  JOIN dbo.BgKostenart              BKA  WITH (READUNCOMMITTED) ON BKA.BgKostenartID = KBB.BgKostenartID
	LEFT  JOIN dbo.vwPerson                 PRS  ON PRS.BaPersonID = KBK.BaPersonID
    LEFT  JOIN dbo.XLOVCode                 ART  WITH (READUNCOMMITTED) ON ART.LOVName = 'KbAuszahlungsArt' AND ART.Code = BAP.KbAuszahlungsArtCode
    LEFT  JOIN dbo.XLOVCode                 SPL  WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
    LEFT  JOIN dbo.KbBuchung                BUC  WITH (READUNCOMMITTED) ON BUC.KbBuchungID = dbo.fnBruttoToNetto(KBB.KbBuchungBruttoID)
  WHERE FAL.BaPersonID = @FallBaPersonID AND
        KBB.KbBuchungTypCode IN (1, 2, 5) AND  -- manuell, budget, Umbuchung
        KBK.BaPersonID = IsNull(@BaPersonID,KBK.BaPersonID) AND
        (@LAList = '' OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) AND
        CASE @KbKontoZeitraumCode
        WHEN 1 THEN CASE WHEN KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                               KBK.VerwPeriodeVon, IsNull(KBK.VerwPeriodeBis,KBK.VerwPeriodeVon))
        END = 1 AND
        IsNull(BPO.Buchungstext,KBB.Text) like '%' + IsNull(@Buchungstext,'') + '%' AND
        (@InklGruen = 1 OR IsNull(BUC.KbBuchungStatusCode,
                                  CASE WHEN KBB.KbBuchungStatusCode = 3 THEN 6 ELSE KBB.KbBuchungStatusCode END) NOT in (2,3,4,5)) AND
        (@InklRot = 1 OR IsNull(BUC.KbBuchungStatusCode,KBB.KbBuchungStatusCode) <> 7)


  --Nachbearbeitung für teilausgeglichene Einnahmen
  UPDATE T
  SET    Betrag = T.Betrag *
                  (SELECT SUM(Betrag) FROM KbOpAusgleich WHERE OpBuchungID = T.KbBuchungID)
                   /
                  (SELECT SUM(Betrag) FROM KbBuchungBruttoPerson WHERE KbBuchungBruttoID = T.BuchungID)
  FROM   @tmp T
  WHERE  T.EA = 'E' AND
         T.KbBuchungStatusCode = 10

  --Nachbearbeitung für STO-Belege
  UPDATE T
  SET	 EA = CASE WHEN T.EA = 'E' THEN 'A' ELSE 'E' END
  FROM   @tmp T
  WHERE  StornoCode = 1

  -- Nettobelege aus Betreibungskosten
  INSERT @tmp
  SELECT
	BuchungID           = BUC.KbBuchungID,
	BuchungsDatum       = BUC.ValutaDatum, --KBB.BelegDatum,
	BaPersonID          = PRS.BaPersonID,
	Klient              = PRS.DisplayText,
	BelegNr             = CONVERT(varchar(20),IsNull(BUC.BelegNr,BUC.KbBuchungID)),
	LA                  = BKA.KontoNr,
	LAText              = BKA.KontoNr + ' ' + BKA.Name,
    Quoting             = BKA.Quoting,
	Buchungstext        = BUK.Buchungstext,
	VerwPeriodeVon      = BUK.VerwPeriodeVon,
	VerwPeriodeBis      = BUK.VerwPeriodeBis,
	BgSplittingArtCode  = BKA.BgSplittingArtCode,
	Splitting           = SPL.ShortText,
	TransferDatum       = BUC.TransferDatum,
	ValutaDatum         = BUC.ValutaDatum,
    ErfassungsDatum     = BUC.ErstelltDatum,
    S                   = NULL,
    D                   = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END,
    Bar                 = NULL,
	Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                          THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, -BUK.Betrag, BUK.VerwPeriodeVon, BUK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                          ELSE -BUK.Betrag
                          END,
	Betrag100           = -BUK.Betrag,
	EA                  = 'A',
	KbBuchungStatusCode = BUC.KbBuchungStatusCode,
    Doc                 = (SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END FROM KbDokument WHERE KbBuchungID = BUC.KbBuchungID),
	Auszahlart          = ART.Text,
	KreditorDebitor     = KRE.Kreditor + char(13) + char(10) + KRE.ZusatzInfo,
	PK                  = 'K',
	PLFall              = NULL,
	PLPerson            = NULL,
    BgPositionID        = NULL,
    BgBudgetID          = NULL,
    BgFinanzplanID      = NULL,
    FallBaPersonID      = FAL.BaPersonID,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = BUC.ValutaDatum,
    OriginalBuchungID   = BUC.KbBuchungID,
    KbBuchungID         = BUC.KbBuchungID,
    StornoCode          = 0
  FROM dbo.KbBuchung BUC
    INNER JOIN dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) ON BUK.KbBuchungID = BUC.KbBuchungID
    INNER JOIN dbo.FaLeistung         LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BUC.FaLeistungID
    INNER JOIN dbo.FaFall             FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
    LEFT  JOIN dbo.vwPerson           PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
    INNER JOIN dbo.BgKostenart        BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BUK.BgKostenartID AND
                                                                    BKA.KontoNr = '365'
    LEFT  JOIN dbo.vwKreditor         KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
    LEFT  JOIN dbo.XLOVCode           AZA WITH (READUNCOMMITTED) ON AZA.LOVName = 'KbAuszahlungsart' AND AZA.Code = BUC.KbAuszahlungsArtCode
    LEFT  JOIN dbo.XLOVCode           PRO WITH (READUNCOMMITTED) ON PRO.LOVName = 'FaProzess' AND PRO.Code = LEI.FaProzessCode
    LEFT  JOIN dbo.XLOVCode           SPL WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
    LEFT  JOIN dbo.XLOVCode           ART WITH (READUNCOMMITTED) ON ART.LOVName = 'KbAuszahlungsArt' AND ART.Code = BUC.KbAuszahlungsArtCode
  WHERE FAL.BaPersonID = @FallBaPersonID AND
        BUC.KbBuchungTypCode = 2 AND  -- manuel
        BUK.BaPersonID = IsNull(@BaPersonID,BUK.BaPersonID) AND
        (@LAList = '' OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) AND
        CASE @KbKontoZeitraumCode
        WHEN 1 THEN CASE WHEN BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                               BUK.VerwPeriodeVon, IsNull(BUK.VerwPeriodeBis,BUK.VerwPeriodeVon))
        END = 1 AND
        BUK.Buchungstext like '%' + IsNull(@Buchungstext,'') + '%' AND
        (@InklGruen = 1 OR BUC.KbBuchungStatusCode NOT in (2,3,4,5)) AND
        (@InklRot = 1 OR BUC.KbBuchungStatusCode <> 7)

  -- Bruttobelege aus Sicherheitsleistungen
  INSERT @tmp
  SELECT DISTINCT
    BuchungID           = BUC.KbBuchungBruttoID,
	BuchungsDatum       = BUC.ValutaDatum,
	BaPersonID          = PRS.BaPersonID,
	Klient              = PRS.DisplayText,
	BelegNr             = CONVERT(varchar(20),IsNull(BUC.BelegNr,BUC.KbBuchungBruttoID)),
	LA                  = BKA.KontoNr,
	LAText              = BKA.KontoNr + ' ' + BKA.Name,
    Quoting             = BKA.Quoting,
	Buchungstext        = BUP.Buchungstext,
	VerwPeriodeVon      = BUP.VerwPeriodeVon,
	VerwPeriodeBis      = BUP.VerwPeriodeBis,
	BgSplittingArtCode  = BKA.BgSplittingArtCode,
	Splitting           = SPL.ShortText,
	TransferDatum       = BUC.TransferDatum,
	ValutaDatum         = BUC.ValutaDatum,
    ErfassungsDatum     = BUC.ErfassungsDatum,
    S                   = NULL,
    D                   = NULL,
    Bar                 = NULL,
	Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                          THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, BUP.Betrag, BUP.VerwPeriodeVon, BUP.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                          ELSE BUP.Betrag
                          END,
	Betrag100           = BUP.Betrag,
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
    BgFinanzplanID      = NULL,
    FallBaPersonID      = FAL.BaPersonID,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = BUC.ValutaDatum,
    OriginalBuchungID   = BUC.KbBuchungBruttoID,
    KbBuchungID         = NULL,
    StornoCode          = 0
  FROM dbo.BaSicherheitsleistungPosition SIP
    INNER JOIN dbo.BaSicherheitsleistung SIC  WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
    INNER JOIN dbo.KbBuchungBrutto       BUC  WITH (READUNCOMMITTED) ON BUC.KbBuchungBruttoID = SIP.KbBuchungBruttoID
    INNER JOIN dbo.KbBuchungBruttoPerson BUP  WITH (READUNCOMMITTED) ON BUP.KbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.FaLeistung            LEI  WITH(READUNCOMMITTED)  ON LEI.BaPersonID = SIC.BaPersonID AND
                                                                        LEI.FaProzessCode = 300 AND
                                                                        LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                                                            FROM   dbo.FaLeistung WITH(READUNCOMMITTED)
                                                                                            WHERE  BaPersonID = SIC.BaPersonID AND
                                                                                                   FaProzessCode = 300
                                                                                            ORDER BY DatumVon DESC)
    LEFT  JOIN dbo.FaFall                FAL  WITH (READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
    LEFT  JOIN dbo.vwPerson              PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = SIC.BaPersonID
    INNER JOIN dbo.BgKostenart           BKA  WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BUP.SpezBgKostenartID AND
                                                                        BKA.KontoNr in ('860','861','862','311')
    LEFT  JOIN dbo.XLOVCode              SPL  WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
	LEFT  JOIN dbo.KbBuchungBrutto       STO  WITH (READUNCOMMITTED) ON STO.StorniertKbBuchungBruttoID = BUC.KbBuchungBruttoID
	LEFT  JOIN dbo.KbBuchungBrutto       NEU  WITH (READUNCOMMITTED) ON NEU.NeubuchungVonKbBuchungBruttoID = BUC.KbBuchungBruttoID
    LEFT  JOIN dbo.vwInstitution         DEBI WITH (READUNCOMMITTED) ON DEBI.BaInstitutionID = SIC.BaInstitutionID

  WHERE FAL.BaPersonID = @FallBaPersonID AND
        (@LAList = '' OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) AND
        CASE @KbKontoZeitraumCode
        WHEN 1 THEN CASE WHEN BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                               BUP.VerwPeriodeVon, IsNull(BUP.VerwPeriodeBis,BUP.VerwPeriodeVon))
        END = 1 AND
        BUP.Buchungstext like '%' + IsNull(@Buchungstext,'') + '%' AND
        (@InklGruen = 1 OR BUC.KbBuchungStatusCode NOT in (2,3,4,5)) AND
        (@InklRot = 1 OR BUC.KbBuchungStatusCode <> 7)


  -- Verdichtung
  IF @Verdichtet = 1 BEGIN
    INSERT @tmp
    SELECT BuchungID,
           MAX(BuchungsDatum),
           BaPersonID = CASE WHEN MIN(BaPersonID) = MAX(BaPersonID) THEN MAX(BaPersonID) END,
           Klient     = CASE WHEN T.Quoting = 1 AND  COUNT(*) > 1
                        THEN 'ganze UE (' + CONVERT(varchar,COUNT(*)) + ')'
                        ELSE MAX(Klient)
                        END,
           MAX(BelegNr),
           LA,
           MAX(LAText),
           Quoting,
           MAX(Buchungstext),
           MAX(VerwPeriodeVon),
           MAX(VerwPeriodeBis),
           MAX(BgSplittingArtCode),
           MAX(Splitting),
           MAX(TransferDatum),
           MAX(ValutaDatum),
           MIN(ErfassungsDatum),
           MAX(S),
           MAX(D),
           MAX(Bar),
           SUM(Betrag),
           SUM(Betrag100),
           MAX(EA),
           MAX(KbBuchungStatusCode),
           MAX(Doc),
           MAX(Auszahlart),
           MAX(KreditorDebitor),
           MAX(PK),
           NULL,NULL, -- PLFall,PLPerson,
           MAX(BgPositionID),
           MAX(BgBudgetID),
           MAX(BgFinanzplanID),
           MAX(FallBaPersonID),
           Verdichtet = 1,
           GroupBaPersonID,
           MIN(OriginalValuta),
           MIN(OriginalBuchungID),
           MIN(KbBuchungID),
           MIN(StornoCode)
    FROM   @tmp T
    GROUP BY BuchungID,LA,GroupBaPersonID,Quoting
  END

  IF @InklProLeist = 1 OR @InklVermittlungsfall = 1 BEGIN
    INSERT @tmp
    SELECT
      BuchungID           = BUC.BelegNummer,
      BuchungsDatum       = BUC.BuchungsDatum,
      BaPersonID          = PRS.BaPersonID,
      Klient              = PRS.DisplayText,
      BelegNr             = BUC.NummernKreis + '-' + CONVERT(varchar(20),BUC.BelegNummer),
      LA                  = CASE WHEN BUC.LeistungsArtNrProLeist BETWEEN 9000 AND 9999 THEN 'V' ELSE '' END + BUC.KissLeistungsart,
      LAText              = 'K: ' + BUC.KissLeistungsart + ' PL: ' + CONVERT(varchar,BUC.LeistungsArtNrProLeist) + ' ' + BUC.LeistungsArtText,
      Quoting             = IsNull(BKA.Quoting,0),
      Buchungstext        = BUC.Buchungstext,
      VerwPeriodeVon      = BUC.VerwendungVon,
      VerwPeriodeBis      = BUC.VerwendungBis,
      BgSplittingArtCode  = NULL,
      Splitting           = NULL,
      TransferDatum       = NULL,
      ValutaDatum         = BUC.FaelligkeitsDatum,
      ErfassungsDatum     = BUC.ErfassungsDatum,
      S                   = NULL,
      D                   = NULL,
      Bar                 = CASE WHEN BUC.NummernKreis like 'B%' THEN 'b' END,
      Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                            THEN IsNull(dbo.fnWhGetBetragKontoauszug(2/*Monat*/, -BUC.Betrag, BUC.VerwendungVon, BUC.VerwendungBis, @DatumVon, @DatumBis), $0.00)
                            ELSE -BUC.Betrag
                            END,
      Betrag100           = -BUC.Betrag,
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
      BgFinanzplanID      = NULL,
      FallBaPersonID      = NULL,
      Verdichtet          = 0,
      GroupBaPersonID     = CASE WHEN IsNull(BKA.Quoting,0) = 1 THEN -1 ELSE PRS.BaPersonID END,
      OriginalValuta      = BUC.FaelligkeitsDatum,
      OriginalBuchungID   = BUC.MigDetailBuchungID,
      KbBuchungID         = NULL,
      StornoCode          = 0
    FROM dbo.FaFall                    FAL WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung        FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
      INNER JOIN dbo.MigDetailBuchung  BUC WITH (READUNCOMMITTED) ON BUC.FaLeistungID = FLE.FaLeistungID
      INNER JOIN dbo.vwPerson          PRS ON PRS.BaPersonID = BUC.BaPersonID
      LEFT  JOIN dbo.BgKostenart       BKA WITH (READUNCOMMITTED) ON BKA.KontoNr = BUC.KissLeistungsart
    WHERE FAL.BaPersonID = @FallBaPersonID AND
      BUC.BuchungsStatusCode = 1 AND /*Korrekt*/
      BUC.LeistungsArtNrProLeist IS NOT NULL AND
      BUC.BaPersonID = IsNull(@BaPersonID,BUC.BaPersonID) AND
      (@LAList = '' OR (',' + @LAList + ',' like '%,' + BUC.KissLeistungsart + ',%')) AND
      ((@InklVermittlungsfall = 1 AND BUC.LeistungsArtNrProLeist >= 9000) OR
       (@InklProLeist = 1 AND BUC.LeistungsArtNrProLeist < 9000)) AND
      CASE @KbKontoZeitraumCode
      WHEN 1 THEN CASE WHEN BUC.BuchungsDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
      WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                             BUC.VerwendungVon, IsNull(BUC.VerwendungBis,BUC.VerwendungVon))
      END = 1 AND
      BUC.Buchungstext like '%' + IsNull(@Buchungstext,'') + '%'

    IF @Verdichtet = 1 BEGIN
      INSERT @tmp
      SELECT MAX(BuchungID),
             MIN(BuchungsDatum),
             BaPersonID = CASE WHEN MIN(BaPersonID) = MAX(BaPersonID) THEN MAX(BaPersonID) END,
             Klient     = CASE WHEN T.Quoting = 1 AND COUNT(DISTINCT BaPersonID) > 1
                          THEN 'ganze UE (' + CONVERT(varchar,COUNT(DISTINCT BaPersonID)) + ')'
                          ELSE MAX(Klient)
                          END,
             BelegNr,
             LA,
             MAX(LAText),
             Quoting,
             MAX(Buchungstext),
             MIN(VerwPeriodeVon),
             MAX(VerwPeriodeBis),
             NULL,NULL,NULL, --BgSplittingArtCode,Splitting,TransferDatum
             MIN(ValutaDatum),
             MIN(ErfassungsDatum),
             NULL,NULL, --S,D
             MAX(bar),
             SUM(Betrag),
             SUM(Betrag100),
             MAX(EA),
             NULL,NULL,NULL, -- EA,KbBuchungStatusCode,Doc,Auszahlart
             MAX(KreditorDebitor),
             'P',
             MAX(PLFall),
             CASE WHEN COUNT(*) > 1 THEN MAX(PLPerson) END,
             NULL,NULL,NULL,NULL, -- BgPositionID,BgBudgetID,BgFinanzplanID,FallBaPersonID,
             Verdichtet = 1,
             GroupBaPersonID,
             MIN(OriginalValuta),
             MIN(OriginalBuchungID),
             NULL,
             MIN(StornoCode)
      FROM   @tmp T
      WHERE  PK = 'P' AND
             Verdichtet = 0
      GROUP BY BelegNr,LA,GroupBaPersonID,Quoting
    END
  END

  --Output
  IF @Verdichtet = 1 BEGIN
    SELECT T.*,
           Mahnstufe       = CASE WHEN T.PK = 'K' AND T.EA = 'E' THEN
                              (SELECT MAX(M.ShortText)
                               FROM KbBuchungBrutto B
                                    INNER JOIN XLOVCode M on M.LOVName = 'WhMahnstufe' AND
                                                             M.Code = CASE
                                                                      WHEN Mahnsperre = 1 THEN 6
                                                                      WHEN Fakturasperre = 1 THEN 5
                                                                      WHEN B.Mahnstufe in (1,2,3,4) THEN B.Mahnstufe
                                                                      WHEN Fakturiert = 1 THEN 0
                                                                      END
                               WHERE B.KbBuchungBruttoID = T.BuchungID)
                             END,
           ProLeistText    = 'Fall ' + CONVERT(varchar,PLFall) +
                             IsNull(', Person ' + CONVERT(varchar,PLPerson),''),
           Einnahme        = CASE WHEN EA = 'E' THEN T.Betrag END,
           Ausgabe         = CASE WHEN EA = 'A' THEN -T.Betrag END,
           Saldo           = CONVERT(money,NULL),
           SaldoRelevant   = CONVERT(bit,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE 1 END),
           BetragSaldo     = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE T.Betrag END),
           BetragEinnahme  = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'E' THEN T.Betrag ELSE 0 END),
           BetragAusgabe   = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'A' THEN -T.Betrag ELSE 0 END),
           GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
    FROM   @tmp T
    WHERE  T.Verdichtet = 1
    ORDER BY CASE WHEN @KbKontoZeitraumCode = 3 THEN T.VerwPeriodeBis ELSE T.OriginalValuta END,
             CASE WHEN @KbKontoZeitraumCode = 3 THEN 0 ELSE T.OriginalBuchungID END,
             CASE WHEN @KbKontoZeitraumCode = 3 THEN 0 ELSE T.StornoCode END
  END

  SELECT T.*,
         Mahnstufe       = CASE WHEN T.PK = 'K' AND T.EA = 'E' THEN
                             (SELECT MAX(M.ShortText)
                              FROM KbBuchungBrutto B
                                   INNER JOIN XLOVCode M on M.LOVName = 'WhMahnstufe' AND
                                                       M.Code = CASE
                                                                WHEN Mahnsperre = 1 THEN 6
                                                                WHEN Fakturasperre = 1 THEN 5
                                                                WHEN B.Mahnstufe in (1,2,3,4) THEN B.Mahnstufe
                                                                WHEN Fakturiert = 1 THEN 0
                                                                END
                              WHERE B.KbBuchungBruttoID = T.BuchungID)
                           END,
         ProLeistText    = 'Fall ' + CONVERT(varchar,PLFall) +
                           IsNull(', Person ' + CONVERT(varchar,PLPerson),''),
         Einnahme        = CASE WHEN EA = 'E' THEN T.Betrag END,
         Ausgabe         = CASE WHEN EA = 'A' THEN -T.Betrag END,
         Saldo           = CONVERT(money,NULL),
         SaldoRelevant   = CONVERT(bit,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE 1 END),
         BetragSaldo     = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE T.Betrag END),
         BetragEinnahme  = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'E' THEN T.Betrag ELSE 0 END),
         BetragAusgabe   = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'A' THEN -T.Betrag ELSE 0 END),
         GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
  FROM   @tmp T
  WHERE  T.Verdichtet = 0 AND
         Betrag <> 0
  ORDER BY CASE WHEN @KbKontoZeitraumCode = 3 THEN T.VerwPeriodeBis ELSE T.OriginalValuta END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.OriginalBuchungID END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.StornoCode END,
           Klient
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
