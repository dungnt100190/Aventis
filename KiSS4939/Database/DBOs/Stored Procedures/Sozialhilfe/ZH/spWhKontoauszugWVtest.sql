SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhKontoauszugWVtest
GO

CREATE PROCEDURE [dbo].[spWhKontoauszugWVtest]
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
  DECLARE @debug bit
  DECLARE @StartTime datetime
  SET @debug = 1
  SET @StartTime = GetDate()
  SET NOCOUNT ON

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
    StornoCode          int)  -- 0: Original, 1: Storno, 2: Neubuchung

IF @debug = 1 PRINT '1: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'

  DECLARE @KbBuchungBruttoPerson table (KbBuchungBruttoPersonID int, KbBuchungBruttoID int, FallBaPersonID int, KbBuchungID int)

  INSERT @KbBuchungBruttoPerson
  SELECT KBB.KbBuchungBruttoID,
         KBB.KbBuchungBruttoID,
         FAL.BaPersonID,
         NULL
  FROM   FaFall FAL
	     INNER JOIN FaLeistung                LEI ON LEI.FaFallID          = FAL.FaFallID
	     INNER JOIN KbBuchungBrutto           KBB ON KBB.FaLeistungID      = LEI.FaLeistungID
	     INNER JOIN KbBuchungBruttoPerson     KBK ON KBK.KbBuchungBruttoID = KBB.KbBuchungBruttoID
         LEFT  JOIN BgKostenart               BKA ON BKA.BgKostenartID     = KBB.BgKostenartID
         LEFT  JOIN BgPosition                BPO ON BPO.BgPositionID      = KBK.BgPositionID
  WHERE  FAL.BaPersonID = 142515 AND
         KBB.KbBuchungTypCode IN (1, 2, 5) AND -- manuell, budget, Umbuchung  
         KBK.BaPersonID = IsNull(@BaPersonID,KBK.BaPersonID) AND
        (@LAList = '' OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) AND
        CASE @KbKontoZeitraumCode
        WHEN 1 THEN CASE WHEN KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                               KBK.VerwPeriodeVon, IsNull(KBK.VerwPeriodeBis,KBK.VerwPeriodeVon))
        END = 1 AND
        IsNull(BPO.Buchungstext,KBB.Text) like '%' + IsNull(@Buchungstext,'') + '%'

IF @debug = 1 PRINT '1a: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'


  UPDATE @KbBuchungBruttoPerson
  SET    KbBuchungID = dbo.fnBruttoToNetto(KbBuchungBruttoID)


/*
        (@InklGruen = 1 OR ISNULL(BUC.KbBuchungStatusCode,KBB.KbBuchungStatusCode) not in (2,4)) AND
        (@InklRot = 1 OR ISNULL(BUC.KbBuchungStatusCode,KBB.KbBuchungStatusCode) <> 7)

         LEFT  JOIN KbBuchung                 BUC ON BUC.KbBuchungID       = dbo.fnBruttoToNetto(KBB.KbBuchungBruttoID)


*/


IF @debug = 1 PRINT '1b: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'
RETURN

  INSERT @tmp
  SELECT
	BuchungID           = KBB.KbBuchungBruttoID,
	BuchungsDatum       = KBB.ValutaDatum, --KBB.BelegDatum,
	BaPersonID          = PRS.BaPersonID,
	Klient              = PRS.DisplayText,
	BelegNr             = CONVERT(varchar(20),KBB.BelegNr),
	LA                  = BKA.KontoNr,
	LAText              = BKA.KontoNr + ' ' + BKA.Name,
    Quoting             = BKA.Quoting,
	Buchungstext        = KBK.Buchungstext,
	VerwPeriodeVon      = KBK.VerwPeriodeVon,
	VerwPeriodeBis      = KBK.VerwPeriodeBis,
	BgSplittingArtCode  = BKA.BgSplittingArtCode,
	Splitting           = NULL, -- SPL.ShortText,
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
	KbBuchungStatusCode = NULL, --ISNULL(BUC.KbBuchungStatusCode,KBB.KbBuchungStatusCode),
    Doc                 = NULL, -- (SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END FROM BgDokument WHERE BgPositionID = BPO.BgPositionID),
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
    FallBaPersonID      = P.FallBaPersonID,
    Verdichtet          = 0,
    GroupBaPersonID     = CASE WHEN BKA.Quoting = 1 THEN -1 ELSE PRS.BaPersonID END,
    OriginalValuta      = COALESCE(NEU.ValutaDatum,STO.ValutaDatum,KBB.ValutaDatum),
    OriginalBuchungID   = COALESCE(NEU.KbBuchungBruttoID,STO.KbBuchungBruttoID,KBB.KbBuchungBruttoID),
    StornoCode          = CASE
                          WHEN NEU.KbBuchungBruttoID IS NOT NULL THEN 2
                          WHEN STO.KbBuchungBruttoID IS NOT NULL THEN 1
                          ELSE 0
                          END
  FROM @KbBuchungBruttoPerson P
	LEFT  JOIN KbBuchungBruttoPerson     KBK ON KBK.KbBuchungBruttoPersonID = P.KbBuchungBruttoPersonID
	LEFT  JOIN KbBuchungBrutto           KBB ON KBB.KbBuchungBruttoID       = KBK.KbBuchungBruttoID
    LEFT  JOIN BgPosition                BPO ON BPO.BgPositionID            = KBK.BgPositionID
	LEFT  JOIN BgBudget                  BBG ON BBG.BgBudgetID              = BPO.BgBudgetID
	LEFT  JOIN BgFinanzplan              BFP ON BFP.BgFinanzplanID          = BBG.BgFinanzplanID
    LEFT  JOIN BgAuszahlungPerson        BAP ON BAP.BgPositionID            = BPO.BgPositionID AND
                                                BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                            FROM   BgAuszahlungPerson
                                                                            WHERE  BgPositionID = BPO.BgPositionID
                                                                            ORDER BY
                                                                              CASE WHEN BaPersonID = KBK.BaPersonID THEN 1
                                                                                   WHEN BaPersonID IS NULL THEN 2
                                                                              ELSE 3
                                                                            END)
    LEFT  JOIN vwKreditor               KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
    LEFT  JOIN vwInstitution            DEBI ON DEBI.BaInstitutionID = BPO.BaInstitutionID AND
                                                BPO.BgKategorieCode = 1
    LEFT  JOIN vwPerson                 DEBP ON DEBP.BaPersonID = BPO.DebitorBaPersonID
	LEFT  JOIN BgKostenart              BKA  ON BKA.BgKostenartID = KBB.BgKostenartID
	LEFT  JOIN vwPerson                 PRS  ON PRS.BaPersonID = KBK.BaPersonID
    LEFT  JOIN XLOVCode                 ART  ON ART.LOVName = 'KbAuszahlungsArt' AND ART.Code = BAP.KbAuszahlungsArtCode
    LEFT  JOIN XLOVCode                 SPL  ON SPL.LOVName = 'BgSplittingArt' AND SPL.Code = BKA.BgSplittingArtCode
    LEFT  JOIN KbBuchungBrutto          STO  ON STO.KbBuchungBruttoID = KBB.StorniertKbBuchungBruttoID
    LEFT  JOIN KbBuchungBrutto          NEU  ON NEU.KbBuchungBruttoID = KBB.NeubuchungVonKbBuchungBruttoID

  WHERE 1=1
/*
KBK.BaPersonID = ISNULL(@BaPersonID,KBK.BaPersonID) AND
        (@LAList = '' OR (',' + @LAList + ',' like '%,' + BKA.KontoNr + ',%')) AND
        CASE @KbKontoZeitraumCode
        WHEN 1 THEN CASE WHEN KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
        WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                               KBK.VerwPeriodeVon, ISNULL(KBK.VerwPeriodeBis,KBK.VerwPeriodeVon))
        END = 1 AND
        isNull(BPO.Buchungstext,KBB.Text) like '%' + isNull(@Buchungstext,'') + '%' AND
        (@InklGruen = 1 OR ISNULL(BUC.KbBuchungStatusCode,KBB.KbBuchungStatusCode) not in (2,4)) AND
        (@InklRot = 1 OR ISNULL(BUC.KbBuchungStatusCode,KBB.KbBuchungStatusCode) <> 7)
*/
IF @debug = 1 PRINT '2: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'

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
           MIN(StornoCode)
    FROM   @tmp T
    GROUP BY BuchungID,LA,GroupBaPersonID,Quoting
  END

IF @debug = 1 PRINT '3: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'

  IF @InklProLeist = 1 BEGIN
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
      BetragSaldo         = CASE WHEN @KbKontoZeitraumCode = 3 -- VerwPeriode
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
      StornoCode          = 0
    FROM FaFall                    FAL
      INNER JOIN FaLeistung        FLE ON FLE.FaFallID = FAL.FaFallID
      INNER JOIN MigDetailBuchung  BUC ON BUC.FaLeistungID = FLE.FaLeistungID
      INNER JOIN vwPerson          PRS ON PRS.BaPersonID = BUC.BaPersonID
      LEFT  JOIN BgKostenart       BKA ON BKA.KontoNr = BUC.KissLeistungsart
    WHERE FAL.BaPersonID = @FallBaPersonID AND
      BUC.BuchungsStatusCode = 1 AND /*Korrekt*/
      BUC.LeistungsArtNrProLeist IS NOT NULL AND
      BUC.BaPersonID = IsNull(@BaPersonID,BUC.BaPersonID) AND
      (@LAList = '' OR (',' + @LAList + ',' like '%,' + BUC.KissLeistungsart + ',%')) AND
      (@InklVermittlungsfall = 1 OR BUC.LeistungsArtNrProLeist < 9000) AND
      CASE @KbKontoZeitraumCode
      WHEN 1 THEN CASE WHEN BUC.BuchungsDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
      WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon,@DatumBis,
                                             BUC.VerwendungVon, IsNull(BUC.VerwendungBis,BUC.VerwendungVon))
      END = 1 AND
      BUC.Buchungstext like '%' + IsNull(@Buchungstext,'') + '%'

IF @debug = 1 PRINT '4: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'

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
             MIN(StornoCode)
      FROM   @tmp T
      WHERE  PK = 'P' AND
             Verdichtet = 0
      GROUP BY BelegNr,LA,GroupBaPersonID,Quoting
    END
  END

IF @debug = 1 PRINT '5: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'

  --Output
  IF @Verdichtet = 1 BEGIN
    SELECT T.*,
           ProLeistText    = 'Fall ' + CONVERT(varchar,PLFall) +
                             IsNull(', Person ' + CONVERT(varchar,PLPerson),''),
           Einnahme        = CASE WHEN EA = 'E' THEN T.Betrag END,
           Ausgabe         = CASE WHEN EA = 'A' THEN -T.Betrag END,
           Saldo           = CONVERT(money,NULL),
           SaldoRelevant   = CONVERT(bit,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,4,7) THEN 0 ELSE 1 END),
           BetragSaldo     = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,4,7) THEN 0 ELSE T.Betrag END),
           BetragEinnahme  = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,4,7) AND EA = 'E' THEN T.Betrag END),
           BetragAusgabe   = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,4,7) AND EA = 'A' THEN -T.Betrag END),
           GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
    FROM   @tmp T
    WHERE  T.Verdichtet = 1
    ORDER BY CASE WHEN @KbKontoZeitraumCode = 3 THEN T.VerwPeriodeBis ELSE T.ValutaDatum END
  END

IF @debug = 1 PRINT '6: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'

  SELECT T.*,
         ProLeistText    = 'Fall ' + CONVERT(varchar,PLFall) +
                           IsNull(', Person ' + CONVERT(varchar,PLPerson),''),
         Einnahme        = CASE WHEN EA = 'E' THEN T.Betrag END,
         Ausgabe         = CASE WHEN EA = 'A' THEN -T.Betrag END,
         Saldo           = CONVERT(money,NULL),
         SaldoRelevant   = CONVERT(bit,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,4,7) THEN 0 ELSE 1 END),
         BetragSaldo     = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,4,7) THEN 0 ELSE T.Betrag END),
         BetragEinnahme  = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,4,7) AND EA = 'E' THEN T.Betrag END),
         BetragAusgabe   = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,4,7) AND EA = 'A' THEN -T.Betrag END),
         GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
  FROM   @tmp T
  WHERE  T.Verdichtet = 0 AND
         Betrag <> 0
  ORDER BY CASE WHEN @KbKontoZeitraumCode = 3 THEN T.VerwPeriodeBis ELSE T.OriginalValuta END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.OriginalBuchungID END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.StornoCode END


IF @debug = 1 PRINT '7: ' + CONVERT(varchar,DateDiff(ms, GetDate(), @StartTime)) + ' ms'

/*
  SELECT T.*,
         ProLeistText    = 'Fall ' + CONVERT(varchar,PLFall) + 
                           ISNULL(', Person ' + CONVERT(varchar,PLPerson),''),
         Einnahme        = CASE WHEN EA = 'E' THEN T.Betrag END,
         Ausgabe         = CASE WHEN EA = 'A' THEN -T.Betrag END,
         Saldo           = CONVERT(money,null),
         SaldoRelevant   = CONVERT(bit,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) IN (2,4,7) THEN 0 ELSE 1 END),
         BetragSaldo     = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) IN (2,4,7) THEN 0 ELSE T.Betrag END),
         BetragEinnahme  = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) NOT IN (2,4,7) AND EA = 'E' THEN T.Betrag END),
         BetragAusgabe   = CONVERT(money,CASE WHEN ISNULL(T.KbBuchungStatusCode,0) NOT IN (2,4,7) AND EA = 'A' THEN -T.Betrag END),
         GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
  FROM   @tmp T
  WHERE  T.Verdichtet = 0 AND
         abs(Betrag) = 300
  ORDER BY CASE WHEN @KbKontoZeitraumCode = 3 THEN T.VerwPeriodeBis ELSE T.OriginalValuta END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.OriginalBuchungID END,
           CASE WHEN @KbKontoZeitraumCode <> 3 THEN T.StornoCode END
*/
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
