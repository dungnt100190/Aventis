SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhKontoauszugNeu
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhKontoauszugNeu.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:45 $
  $Revision: 2 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhKontoauszugNeu.sql $
 * 
 * 2     11.12.09 12:46 Lloreggia
 * Header aktualisiert, ALTER -> CREATE
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhKontoauszugNeu]
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

  SET @KbKontoZeitraumCode = ISNULL(@KbKontoZeitraumCode,1)
  SET @DatumVon            = ISNULL(@DatumVon,'19000101')
  SET @DatumBis            = ISNULL(@DatumBis,'29000101')
  SET @LAList              = ISNULL(@LAList,'')

  DECLARE @Saldo       money

  DECLARE @tmp TABLE (
    BuchungID           int,
    Buchungsdatum       datetime,
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
    
  INSERT @tmp
  SELECT 
	BuchungID           = KBB.KbBuchungBruttoID,
	Buchungsdatum       = KBB.ValutaDatum, --KBB.BelegDatum,
	BaPersonID          = PRS.BaPersonID,
	Klient              = PRS.DisplayText,
	BelegNr             = convert(varchar(20),isnull(KBB.BelegNr,KBB.KbBuchungBruttoID)),
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
    S                   = case when BPO.VerwaltungSD = 1 then 'S' end,
    D                   = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END,
    Bar                 = CASE WHEN BAP.KbAuszahlungsArtCode = 103 THEN 'b' END,
	Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                          THEN IsNull(dbo.fnWhGetBetragKontoauszug(BKA.BgSplittingArtCode, KBK.Betrag, KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                          ELSE KBK.Betrag
                          END,
	Betrag100           = KBK.Betrag,
	EA                  = CASE WHEN KBK.Betrag <= $0.00 THEN 'A' ELSE 'E' END,
	KbBuchungStatusCode = CASE WHEN BUC.KbBuchungStatusCode IS NOT NULL
                          THEN BUC.KbBuchungStatusCode
                          ELSE CASE WHEN KBB.KbBuchungStatusCode = 3
                               THEN 6  -- transferietre BruttoBelege ohne Nettobeleg auf "ausgeglichen" setzen
                               ELSE KBB.KbBuchungStatusCode
                               END
                          END,
    Doc                 = (SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END FROM BgDokument WHERE BgPositionID = BPO.BgPositionID),
	Auszahlart          = ART.Text,
	KreditorDebitor     = COALESCE(KRE.Kreditor + CHAR(13) + CHAR(10) + KRE.ZusatzInfo,
								   DEBI.Name + CHAR(13) + CHAR(10) + DEBI.AdresseMehrzeilig,
								   DEBP.NameVorname + CHAR(13) + CHAR(10) + DEBP.WohnsitzMehrzeilig),
	PK                  = 'K',
	PLFall              = NULL,
	PLPerson            = NULL,
    BgPositionID        = BPO.BgPositionID,
    BgBudgetID          = BBG.BgBudgetID,
    BgFinanzplanID      = BFP.BgFinanzplanID,
    FallBaPersonID      = FAL.BaPersonID,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = COALESCE(NEU.ValutaDatum,STO.ValutaDatum,KBB.ValutaDatum),
    OriginalBuchungID   = COALESCE(NEU.KbBuchungBruttoID,STO.KbBuchungBruttoID,KBB.KbBuchungBruttoID),
    KbBuchungID         = BUC.KbBuchungID,
    StornoCode          = CASE 
                          WHEN NEU.KbBuchungBruttoID IS NOT NULL THEN 2
                          WHEN STO.KbBuchungBruttoID IS NOT NULL THEN 1
                          ELSE 0
                          END
  FROM dbo.FaFall                            FAL WITH (READUNCOMMITTED) 
	INNER JOIN dbo.FaLeistung                FLE WITH (READUNCOMMITTED) ON FLE.FaFallID          = FAL.FaFallID
	INNER JOIN dbo.BgFinanzplan              BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID      = FLE.FaLeistungID
	INNER JOIN dbo.BgBudget                  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID    = BFP.BgFinanzplanID
	INNER JOIN dbo.KbBuchungBrutto           KBB WITH (READUNCOMMITTED) ON KBB.BgBudgetID        = BBG.BgBudgetID
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
    LEFT  JOIN dbo.XLOVCode                 ART  WITH (READUNCOMMITTED) ON ART.LOVName = 'KbAuszahlungsArt' and ART.Code = BAP.KbAuszahlungsArtCode
    LEFT  JOIN dbo.XLOVCode                 SPL  WITH (READUNCOMMITTED) ON SPL.LOVName = 'BgSplittingArt' and SPL.Code = BKA.BgSplittingArtCode
    LEFT  JOIN dbo.KbBuchung                BUC  WITH (READUNCOMMITTED) ON BUC.KbBuchungID = dbo.fnBruttoToNetto(KBB.KbBuchungBruttoID)
    LEFT  JOIN dbo.KbBuchungBrutto          STO  WITH (READUNCOMMITTED) ON STO.KbBuchungBruttoID = KBB.StorniertKbBuchungBruttoID
    LEFT  JOIN dbo.KbBuchungBrutto          NEU  WITH (READUNCOMMITTED) ON NEU.KbBuchungBruttoID = KBB.NeubuchungVonKbBuchungBruttoID
  WHERE FAL.BaPersonID = @FallBaPersonID AND
        KBB.KbBuchungTypCode IN (1, 2, 5) AND  -- manuell, budget, Umbuchung
        KBK.BaPersonID = ISNULL(@BaPersonID,KBK.BaPersonID) AND
        (@LAList = '' OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) AND
        CASE @KbKontoZeitraumCode
        WHEN 1 THEN CASE WHEN KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                               KBK.VerwPeriodeVon, ISNULL(KBK.VerwPeriodeBis,KBK.VerwPeriodeVon))
        END = 1 AND
        isNull(BPO.Buchungstext,KBB.Text) like '%' + isNull(@Buchungstext,'') + '%' AND
        (@InklGruen = 1 OR ISNULL(BUC.KbBuchungStatusCode,
                                  CASE WHEN KBB.KbBuchungStatusCode = 3 THEN 6 ELSE KBB.KbBuchungStatusCode END) not in (2,3,4,5)) AND
        (@InklRot = 1 OR ISNULL(BUC.KbBuchungStatusCode,KBB.KbBuchungStatusCode) <> 7)

  --Nachbearbeitung für teilausgeglichene Einnahmen
  update T
  set    Betrag = T.Betrag * 
                  (select sum(Betrag) from KbOpAusgleich where OpBuchungID = T.KbBuchungID)
                   /
                  (select sum(Betrag) from KbBuchungBruttoPerson where KbBuchungBruttoID = T.BuchungID)
  from   @tmp T
  where  T.EA = 'E' and
         T.KbBuchungStatusCode = 10
         

  IF @Verdichtet = 1 BEGIN
    INSERT @tmp
    SELECT BuchungID,
           MAX(Buchungsdatum),
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
           null,null, -- PLFall,PLPerson,
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
      Buchungsdatum       = BUC.BuchungsDatum,
      BaPersonID          = PRS.BaPersonID,
      Klient              = PRS.DisplayText,
      BelegNr             = BUC.NummernKreis + '-' + convert(varchar(20),BUC.BelegNummer),
      LA                  = CASE WHEN BUC.LeistungsArtNrProLeist BETWEEN 9000 AND 9999 THEN 'V' ELSE '' END + BUC.KissLeistungsart,
      LAText              = 'K: ' + BUC.KissLeistungsart + ' PL: ' + CONVERT(varchar,BUC.LeistungsArtNrProLeist) + ' ' + BUC.LeistungsArtText,
      Quoting             = ISNULL(BKA.Quoting,0),
      Buchungstext        = BUC.Buchungstext,
      VerwPeriodeVon      = BUC.VerwendungVon,
      VerwPeriodeBis      = BUC.VerwendungBis,
      BgSplittingArtCode  = null,
      Splitting           = null,
      TransferDatum       = null,
      ValutaDatum         = BUC.FaelligkeitsDatum,
      ErfassungsDatum     = BUC.ErfassungsDatum,
      S                   = null,
      D                   = null,
      Bar                 = CASE WHEN BUC.NummernKreis like 'B%' THEN 'b' END,
      Betrag              = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
                            THEN IsNull(dbo.fnWhGetBetragKontoauszug(2/*Monat*/, -BUC.Betrag, BUC.VerwendungVon, BUC.VerwendungBis, @DatumVon, @DatumBis), $0.00)
                            ELSE -BUC.Betrag
                            END,
      Betrag100           = -BUC.Betrag,
      EA                  = CASE WHEN SUBSTRING(BUC.NummernKreis, 1, 1) IN ('B','D','E','F') THEN 'A' ELSE 'E' END,
      KbBuchungStatusCode = null,
      Doc                 = null,
      Auszahlart          = null,
      KreditorDebitor     = IsNull(BUC.DEBKREVorname + CHAR(13) + CHAR(10), '') + 
                            IsNull(BUC.DEBKREName + CHAR(13) + CHAR(10), '' ) + 
                            IsNull(BUC.DEBKREZusatzzeile, '' ),
      PK                  = 'P',
      PLFall              = BUC.FallProleist,
      PLPerson            = BUC.PersonProleist,
      BgPositionID        = null,
      BgBudgetID          = null,
      BgFinanzplanID      = null,
      FallBaPersonID      = null,
      Verdichtet          = 0,
      GroupBaPersonID     = CASE WHEN ISNULL(BKA.Quoting,0) = 1 THEN -1 ELSE PRS.BaPersonID END,
      OriginalValuta      = BUC.FaelligkeitsDatum,
      OriginalBuchungID   = BUC.MigDetailBuchungID,
      KbBuchungID         = null,
      StornoCode          = 0
    FROM dbo.FaFall                    FAL WITH (READUNCOMMITTED) 
      INNER JOIN dbo.FaLeistung        FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
      INNER JOIN dbo.MigDetailBuchung  BUC WITH (READUNCOMMITTED) ON BUC.FaLeistungID = FLE.FaLeistungID
      INNER JOIN dbo.vwPerson          PRS ON PRS.BaPersonID = BUC.BaPersonID
      LEFT  JOIN dbo.BgKostenart       BKA WITH (READUNCOMMITTED) ON BKA.KontoNr = BUC.KissLeistungsart
    WHERE FAL.BaPersonID = @FallBaPersonID AND 
      BUC.BuchungsStatusCode = 1 AND /*Korrekt*/
      BUC.LeistungsArtNrProLeist IS NOT NULL AND
      BUC.BaPersonID = ISNULL(@BaPersonID,BUC.BaPersonID) AND
      (@LAList = '' OR (',' + @LAList + ',' like '%,' + BUC.KissLeistungsart + ',%')) AND
      ((@InklVermittlungsfall = 1 AND BUC.LeistungsArtNrProLeist >= 9000) OR
       (@InklProLeist = 1 AND BUC.LeistungsArtNrProLeist < 9000)) AND 
      CASE @KbKontoZeitraumCode
      WHEN 1 THEN CASE WHEN BUC.BuchungsDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
      WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                             BUC.VerwendungVon, ISNULL(BUC.VerwendungBis,BUC.VerwendungVon))
      END = 1 AND
      BUC.Buchungstext like '%' + isNull(@Buchungstext,'') + '%'

    IF @Verdichtet = 1 BEGIN
      INSERT @tmp
      SELECT MAX(BuchungID),
             MIN(Buchungsdatum),
             BaPersonID = CASE WHEN MIN(BaPersonID) = MAX(BaPersonID) THEN MAX(BaPersonID) END,
             Klient     = CASE WHEN T.Quoting = 1 AND COUNT(distinct BaPersonID) > 1
                          THEN 'ganze UE (' + CONVERT(varchar,COUNT(distinct BaPersonID)) + ')' 
                          ELSE MAX(Klient) 
                          END,
             BelegNr,
             LA,
             MAX(LAText),
             Quoting,
             MAX(Buchungstext),
             MIN(VerwPeriodeVon),
             MAX(VerwPeriodeBis),
             null,null,null, --BgSplittingArtCode,Splitting,TransferDatum
             MIN(ValutaDatum),
             MIN(ErfassungsDatum),
             null,null, --S,D
             MAX(bar),
             SUM(Betrag),
             SUM(Betrag100),
             MAX(EA),
             null,null,null, -- EA,KbBuchungStatusCode,Doc,Auszahlart
             MAX(KreditorDebitor),
             'P',
             MAX(PLFall),
             CASE WHEN COUNT(*) > 1 THEN MAX(PLPerson) END,
             null,null,null,null, -- BgPositionID,BgBudgetID,BgFinanzplanID,FallBaPersonID,
             Verdichtet = 1,
             GroupBaPersonID,
             MIN(OriginalValuta),
             MIN(OriginalBuchungID),
             null,
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
           ProLeistText    = 'Fall ' + CONVERT(varchar,PLFall) + 
                             ISNULL(', Person ' + CONVERT(varchar,PLPerson),''),
           Einnahme        = CASE WHEN EA = 'E' THEN T.Betrag END,
           Ausgabe         = CASE WHEN EA = 'A' THEN -T.Betrag END,
           Saldo           = CONVERT(money,null),
           SaldoRelevant   = CONVERT(bit,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE 1 END),
           BetragSaldo     = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE T.Betrag END),
           BetragEinnahme  = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'E' THEN T.Betrag ELSE 0 END),
           BetragAusgabe   = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'A' THEN -T.Betrag ELSE 0 END),
           GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
    FROM   @tmp T
    WHERE  T.Verdichtet = 1
    ORDER BY CASE WHEN @KbKontoZeitraumCode = 3 THEN T.VerwPeriodeBis ELSE T.OriginalValuta END,
             CASE WHEN @KbKontoZeitraumCode = 3 THEN 0 ELSE T.OriginalBuchungID END,
             CASE WHEN @KbKontoZeitraumCode = 3 THEN 0 ELSE T.StornoCode END
  END

  SELECT T.*,
         ProLeistText    = 'Fall ' + CONVERT(varchar,PLFall) + 
                           ISNULL(', Person ' + CONVERT(varchar,PLPerson),''),
         Einnahme        = CASE WHEN EA = 'E' THEN T.Betrag END,
         Ausgabe         = CASE WHEN EA = 'A' THEN -T.Betrag END,
         Saldo           = CONVERT(money,null),
         SaldoRelevant   = CONVERT(bit,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE 1 END),
         BetragSaldo     = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) IN (2,3,4,5,7) THEN 0 ELSE T.Betrag END),
         BetragEinnahme  = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'E' THEN T.Betrag ELSE 0 END),
         BetragAusgabe   = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7) AND EA = 'A' THEN -T.Betrag ELSE 0 END),
         GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
  FROM   @tmp T
  WHERE  T.Verdichtet = 0 AND
         Betrag <> 0
  ORDER BY CASE WHEN @KbKontoZeitraumCode = 3 THEN T.VerwPeriodeBis ELSE T.OriginalValuta END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.OriginalBuchungID END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.StornoCode END,
           Klient

GO