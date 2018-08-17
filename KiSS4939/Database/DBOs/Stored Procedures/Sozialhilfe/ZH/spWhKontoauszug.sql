SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhKontoauszug
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhKontoauszug.sql $
  $Author: Mmarghitola $
  $Modtime: 10.08.10 12:31 $
  $Revision: 11 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhKontoauszug.sql $
 * 
 * 11    10.08.10 12:31 Mmarghitola
 * #6147: Änderungen Klientenkontoabrechnung  (Ausschluss LAs)
 * 
 * 10    11.12.09 12:51 Lloreggia
 * Header aktualisiert
 * 
 * 9     12.05.09 9:34 Mmarghitola
 * 
 * 7     10.03.09 17:59 Rstahel
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

CREATE PROCEDURE [dbo].[spWhKontoauszug]
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
  @InklRot bit,
  @InklStorno bit)
AS
BEGIN
  SET @KbKontoZeitraumCode = IsNull(@KbKontoZeitraumCode,1)
  SET @DatumVon            = IsNull(@DatumVon,'17530101')
  SET @DatumBis            = IsNull(@DatumBis,'29000101')
  SET @LAList              = IsNull(@LAList,'')

  DECLARE @Saldo money

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
    DatumEffektiv       datetime,
    S                   varchar(1),
    D                   varchar(1),
    Bar                 varchar(1),
    Betrag              money, -- Betrag bezogen auf den gesuchten Zeitraum, für teilausgeglichene Beträge bezahlter Anteil
    Betrag100           money, -- ganzer Betrag
    BetragEffektiv      money, -- tatsächlich bezahlter Betrag, bezogen auf gesuchten Zeitraum
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
    StornoCode          int,  -- 0: Original, 1: Storno, 2: Neubuchung
    IstGBL              bit,
    IstEinzelzahlungGBL	bit,
    AnzahlBelege        int
  )
  
  INSERT INTO @tmp
  SELECT
    BuchungID,
    BuchungsDatum,
    BaPersonID,
    Klient,
    BelegNr,
    LA = CASE WHEN PK = 'P' THEN CASE WHEN LAProLeist BETWEEN 9000 AND 9999 THEN 'V' ELSE '' END + LA ELSE LA END,
    LAText = CASE WHEN PK = 'P' THEN 'K: ' + LA + ' PL: ' + CONVERT(varchar,LAProLeist) + ' ' + LAText ELSE LA + ' ' + LAText END,
    Quoting,
    Buchungstext,
    VerwPeriodeVon,
    VerwPeriodeBis,
    BgSplittingArtCode,
    Splitting,
    TransferDatum,
    ValutaDatum,
    ErfassungsDatum,
    DatumEffektiv,
    S,
    D,
    Bar,
    Betrag,
    Betrag100,
    BetragEffektiv,
    EA,
    KbBuchungStatusCode,
    Doc,
    Auszahlart,
    KreditorDebitor,
    PK,
    PLFall,
    PLPerson,
    BgPositionID,
    BgBudgetID,
    BgBudgetName,
    BgFinanzplanID,
    FallBaPersonID,
    Rechnungsnummer,
    Verdichtet,
    GroupBaPersonID,
    OriginalValuta,
    OriginalBuchungID,
    KbBuchungID,
    StornoCode,
    IstGBL,
    IstEinzelzahlungGBL,
    AnzahlBelege
 FROM dbo.fnWhKontoauszug(@FallBaPersonID,
  CONVERT(varchar(10),@BaPersonID),
  @KbKontoZeitraumCode,
  @DatumVon,
  @DatumBis,
  @Buchungstext,
  @LAList,
  @Verdichtet,
  @InklProLeist,
  @InklVermittlungsfall,
  @InklGruen,
  @InklRot,
  @InklStorno,
  NULL, -- zeige immer Einnahmen und Ausgaben an
  0) -- Kein Klientenkontoabrechnungsmodus


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
           Einnahme        = CASE WHEN EA = 'E' THEN
                CASE WHEN KbBuchungStatusCode = 6 or KbBuchungStatusCode = 10 THEN T.BetragEffektiv
                ELSE T.Betrag END
               END,
           Ausgabe         = CASE WHEN EA = 'A' THEN
                CASE WHEN KbBuchungStatusCode = 6 or KbBuchungStatusCode = 10 THEN -T.BetragEffektiv
                ELSE -T.Betrag END
               END,
           Saldo           = CONVERT(money,NULL),
           SaldoRelevant   = CONVERT(bit,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7,9) THEN 0 ELSE 1 END),
           BetragSaldo     = CONVERT(money, T.BetragEffektiv),
           BetragEinnahme  = CONVERT(money,CASE WHEN EA = 'E' THEN T.BetragEffektiv ELSE 0 END),
           BetragAusgabe   = CONVERT(money,CASE WHEN EA = 'A' THEN -T.BetragEffektiv ELSE 0 END),
--           BetragSaldo     = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7,9) THEN 0 ELSE T.BetragEffektiv END),
--           BetragEinnahme  = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7,9) AND EA = 'E' THEN T.BetragEffektiv ELSE 0 END),
--           BetragAusgabe   = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7,9) AND EA = 'A' THEN -T.BetragEffektiv ELSE 0 END),
           GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
    FROM   @tmp T
    WHERE  T.Verdichtet = 1 AND
         (Betrag100 <> 0 OR AnzahlBelege > 1 OR IstGBL = 1) -- für den Moment: GBL immer anzeigen
    ORDER BY VerwPeriodeVon DESC, VerwPeriodeBis DESC, LA ASC
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
         Einnahme        = CASE WHEN EA = 'E' THEN
                CASE WHEN KbBuchungStatusCode = 6 or KbBuchungStatusCode = 10 THEN T.BetragEffektiv
                ELSE T.Betrag END
               END,
         Ausgabe         = CASE WHEN EA = 'A' THEN
                CASE WHEN KbBuchungStatusCode = 6 or KbBuchungStatusCode = 10 THEN -T.BetragEffektiv
                ELSE -T.Betrag END
               END,
         Saldo           = CONVERT(money,NULL),
         SaldoRelevant   = CONVERT(bit,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7,9) THEN 0 ELSE 1 END),
         BetragSaldo     = CONVERT(money,T.BetragEffektiv),
         BetragEinnahme  = CONVERT(money,CASE WHEN EA = 'E' THEN T.BetragEffektiv ELSE 0 END),
         BetragAusgabe   = CONVERT(money,CASE WHEN EA = 'A' THEN -T.BetragEffektiv ELSE 0 END),
--         BetragSaldo     = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) IN (2,3,4,5,7,9) THEN 0 ELSE T.BetragEffektiv END),
--         BetragEinnahme  = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7,9) AND EA = 'E' THEN T.BetragEffektiv ELSE 0 END),
--         BetragAusgabe   = CONVERT(money,CASE WHEN IsNull(T.KbBuchungStatusCode,0) NOT IN (2,3,4,5,7,9) AND EA = 'A' THEN -T.BetragEffektiv ELSE 0 END),
         GroupBaPersonID = CASE WHEN T.Quoting = 1 THEN -1 ELSE T.BaPersonID END
  FROM   @tmp T
  WHERE  T.Verdichtet = 0 AND
         (Betrag100 <> 0 OR IstGBL = 1) -- für den Moment: GBL immer anzeigen
  ORDER BY VerwPeriodeVon DESC, VerwPeriodeBis DESC, LA ASC
END;
