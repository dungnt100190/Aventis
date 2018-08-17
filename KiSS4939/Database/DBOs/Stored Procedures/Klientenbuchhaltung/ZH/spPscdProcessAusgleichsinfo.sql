SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spPscdProcessAusgleichsinfo
GO
/*===============================================================================================
  $Revision: 41 $
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

CREATE PROCEDURE dbo.spPscdProcessAusgleichsinfo
(
  @AusgleichBelegNr         BIGINT,
  @AusgleichBetrag          MONEY,
  @AusgleichDatum           DATETIME,
  @AusgleichGrund           INT,
  @EinzahlungDatum          DATETIME,
  @PscdVertragsgegenstandID INT,
  @PscdGeschaeftspartnerID  INT,
  @OPBelegNr                BIGINT,
  @PosInOPBeleg             INT,
  @Zahlstapel               VARCHAR(12),
  @PosInZahlstapel          INT,
  @OPUPW                    INT,
  @OPUPZ                    INT,
  @WVSTAT                   VARCHAR(1)
)
AS

BEGIN TRY

  DECLARE @ProcedureName VARCHAR(50), 
          @LogException  VARCHAR(2048), 
          @LogMessage    VARCHAR(500)
          
  SET     @ProcedureName = 'spPscdProcessAusgleichsinfo'
  
  DECLARE 
    @KbBuchungID                   INT,
    @KbBuchungBruttoID             INT,
    @KgBuchungID                   INT,
    @Count                         INT,
    @msg                           VARCHAR(200),
    @OPIstKreditorBuchung          BIT,
    @OPIstDebitorBuchung           BIT,
    @OPIstAusgleichsBuchung        BIT,
    @KbZahlungseingangID           INT,
    @GegenbuchungHabenKtoNr        VARCHAR(10),
    @GegenbuchungSollKtoNr         VARCHAR(10),
    @GegenbuchungText              VARCHAR(200),
    @KbPeriodeID                   INT,
    @DebitorKtoNr                  VARCHAR(10),
    @KreditorKtoNr                 VARCHAR(10),
    @AuszahlKtoNr                  INT,
    @OPText                        VARCHAR(200),
    @OPHabenKtoNr                  INT,
    @OPSollKtoNr                   INT,
    @GegenbuchungID                INT,
    @GegenbuchungBuchungStatusCode INT,
    @IstForderung                  BIT,
    @StorniertKbBuchungID          INT,
    @KbBuchungTypCode              INT,
    @ModulID                       INT,
    @PscdAusgleichID               INT,
    @OPBetrag                      MONEY,
    @OPValuta                      DATETIME,
    @OPBgBudgetID                  INT,
    @OpErstelltUserID              INT,
    @Today                         DATETIME,
    @AusglGrundDirektzahlung       INT

  SET @Today = GETDATE()

  -- Direktzahlungen haben immer AG = 90
  SET @AusglGrundDirektzahlung = 90
  
  -- mappen auf EZDAT anstatt AUGDT für Direktzahlung (#75)
  IF @AusgleichGrund = @AusglGrundDirektzahlung 
  BEGIN
    SET @AusgleichDatum = @EinzahlungDatum
  END
  
  --Ausgleichsmeldung speichern
  INSERT INTO dbo.PscdAusgleich(AUGBL, AUGBT, AUGDT, AUGRD, EZDAT, OPBEL, VTREF, GPART, KEYZ1, OPUPK, OPUPW, OPUPZ, POSZA, WVSTAT, Verarbeitet)
    VALUES (@AusgleichBelegNr, @AusgleichBetrag, CONVERT(VARCHAR,@AusgleichDatum,104), @AusgleichGrund, CONVERT(VARCHAR,@EinzahlungDatum,104), @OPBelegNr, @PscdVertragsgegenstandID, @PscdGeschaeftspartnerID, @Zahlstapel, @PosInOPBeleg, @OPUPW, @OPUPZ, @PosInZahlstapel, @WVSTAT, 0)
  SET @PscdAusgleichID = SCOPE_IDENTITY()

  BEGIN TRAN  -- Begin Tran schon hier, weil im Catch ein Rollback kommt und die Fehlermeldung in die Ausgleichszeile geschrieben wird

  -- #75: ALIM 04 - 99 Buchungen von Direktzahlungen
  -- neu wird Ausgleichsgrund 90 geliefert, welcher Direktzahlung bedeutet.
  -- TODO: Mathias, könnte das irgendwo stören?
  --IF @AusgleichGrund NOT IN (1,2,5,8,10,11,15,99) BEGIN
  IF @AusgleichGrund NOT IN (1, 2, 5, 8, 10, 11, 15, 26, @AusglGrundDirektzahlung, 99) 
  BEGIN
    SET @msg = 'AusgleichsgrundCode ' + CAST(@AusgleichGrund AS VARCHAR) + ' ist unbekannt.'
    RAISERROR(@msg,18,1)
    ROLLBACK
    RETURN
  END

  -- Überprüfung auf doppelte Ausgleiche: Sollte es eigentlich nicht geben
  IF EXISTS (SELECT TOP 1 1 
             FROM dbo.PscdAusgleich AUG 
             WHERE Verarbeitet = 1
               AND  AUG.Augbl = @AusgleichBelegNr
               AND  AUG.opbel = @OPBelegNr
               AND  AUG.opupk = @PosInOPBeleg
               AND  AUG.AUGBT = @AusgleichBetrag
               AND  AUG.augrd = @AusgleichGrund
               AND (AUG.vtref = @PscdVertragsgegenstandID OR AUG.vtref IS NULL AND @PscdVertragsgegenstandID IS NULL)
               AND  AUG.GPart = @PscdGeschaeftspartnerID
               AND  AUG.OPUPW = @OPUPW
               AND  AUG.opupz = @OPUPZ
    ) 
  BEGIN
    SET @msg = 'Der Ausgleich (AUGBL ' + CONVERT(VARCHAR, @AusgleichBelegNr) + ', OPBEL ' + CONVERT(VARCHAR, @OPBelegNr) + ') wurde bereits verarbeitet.'
    UPDATE PscdAusgleich SET Fehlermeldung = @msg WHERE PscdAusgleichID = @PscdAusgleichID
    COMMIT
    RETURN
  END
  
  SET @AusgleichBetrag = -@AusgleichBetrag

  SET @GegenbuchungBuchungStatusCode = CASE @AusgleichGrund WHEN  5 THEN  8 --storniert
--                                                              WHEN 10 THEN  6 --Rückläufer
                                                            WHEN 11 THEN  8 --storniert (Rücknahme Ausgleich)
--                                                              WHEN 99 THEN  3 --ZahlauftragErstellt (wieder offen)
                                                            ELSE 6  -- ausgeglichen
                                       END

  -- TODO :  Mathias, @OPText ist hier immer NULL, warum also IsNull bei 1 und 2?
  SET @GegenbuchungText = CASE @AusgleichGrund WHEN  1 THEN ISNULL(@OPText, 'Ausgleich durch Einzahlung')
                                               WHEN  2 THEN ISNULL(@OPText, 'Ausgleich durch Auszahlung')
                                               WHEN  5 THEN 'Storno'
                                               WHEN  8 THEN 'manuelle Kontenpflege'
                                               WHEN 10 THEN 'Rückläufer'
                                               WHEN 11 THEN 'Rücknahme Ausgleich'
                                               WHEN 15 THEN 'maschinelle Kontenpflege'
                                               WHEN 99 THEN 'OP wieder offen'
                          END

  -- Wir erhalten eine Belegnummer, wissen aber nicht in welcher Tabelle dieser abgelegt ist: KbBuchung, KbBuchungBrutto oder KgBuchung
  -- Probieren wir's mal in KbBuchungBrutto
  SET @Count = 0
  SELECT @Count             = COUNT(*),
         @KbBuchungBruttoID = SUM(KbBuchungBruttoID),
         @IstForderung      = CASE WHEN dbo.ConcDistinct(PscdKennzeichen) = 'E' THEN 1 ELSE 0 END,
         @KbPeriodeID       = MAX(KbPeriodeID)
  FROM dbo.KbBuchungBrutto
  WHERE BelegNr = @OPBelegNr
  GROUP BY BelegNr

  IF @Count > 1 
  BEGIN
    SET @msg = 'Es existieren ' + CAST(@Count AS VARCHAR) + ' Bruttobelege mit Belegnummer ' + CAST(@OPBelegNr AS VARCHAR) + '! Die Belegnummer müsste eindeutig sein.'
    RAISERROR(@msg,18,1)
  END

  IF @Count = 1 
  BEGIN
    -- Ausgleiche auf Bruttobelegen
    UPDATE dbo.KbBuchungBrutto
    SET BetragEffektiv = ISNULL(BetragEffektiv,$0.00) + @AusgleichBetrag,
        DatumEffektiv = @AusgleichDatum, 
        KbBuchungStatusCode = CASE WHEN KbBuchungStatusCode = 8 THEN 8  /*Bereits stornierter Beleg bleibt storniert, auch wenn der Betrag nun ausgeglichen ist*/
                                   WHEN Betrag = ISNULL(BetragEffektiv,$0.00) + @AusgleichBetrag THEN 6 /*ausgeglichen*/ 
                                   WHEN $0.00  = ISNULL(BetragEffektiv,$0.00) + @AusgleichBetrag THEN 3 /*Zahlauftrag erstellt*/ 
                                   ELSE 10 /*teilweise ausgeglichen*/ 
                              END
    WHERE KbBuchungBruttoID = @KbBuchungBruttoID 
      AND (KbBuchungStatusCode <> 8 /*Storno-Ausgleichsmeldungen ignorieren*/ OR StorniertKbBuchungBruttoID IS NOT NULL /*"Stornobuchung" einer Umbuchung hat Status 'storniert', soll aber trotzdem ausgeglichen werden*/)

    IF @WVSTAT = 'K' 
    BEGIN
      UPDATE dbo.KbBuchungBruttoPerson
      SET GesperrtFuerWV = 1
      WHERE KbBuchungBruttoID = @KbBuchungBruttoID 
        AND PositionImBeleg = @PosInOPBeleg
    END

    -- Für Brutto-/Netto-Verrechnung muss ein Eintrag in KbOpAusgleich erstellt werden
    IF @IstForderung = 0 AND @AusgleichGrund IN (8,15) /*manuelle/maschinelle Kontenpflege, wird für interne Verrechnung verwendet*/ 
    BEGIN
      DECLARE @DummyBruttoBuchungID INT
      SELECT TOP 1 @DummyBruttoBuchungID = KbBuchungID
      FROM dbo.KbBuchung WITH(READUNCOMMITTED)
      WHERE KbBuchungTypCode = 10

      SELECT @GegenbuchungID = KbBuchungID
      FROM dbo.KbBuchung
      WHERE BelegNr = @AusgleichBelegNr

      IF @GegenbuchungID IS NULL 
      BEGIN
        -- Gegenbuchung erstellen
        INSERT INTO dbo.KbBuchung (
          KbPeriodeID, KbBuchungTypCode, BelegNr, BelegDatum, ValutaDatum, 
          SollKtoNr, HabenKtoNr, Betrag, [Text], ModulID, ErstelltDatum, MutiertDatum, 
          KbBuchungStatusCode)
        VALUES (
          @KbPeriodeID, 4, @AusgleichBelegNr, @AusgleichDatum, @EinzahlungDatum, 
          NULL, NULL, @AusgleichBetrag, @GegenbuchungText, 3, 
          @Today, @Today, @GegenbuchungBuchungStatusCode)
        SELECT @GegenbuchungID = SCOPE_IDENTITY()
      END
      ELSE 
      BEGIN
        -- Bereits bestehende Gegenbuchung verwenden, Betrag updaten
        UPDATE dbo.KbBuchung
        SET Betrag = Betrag + @AusgleichBetrag,
            [Text] = LEFT(CASE WHEN [Text] LIKE '%' + @GegenbuchungText + '%' THEN [Text] ELSE ISNULL([Text] + ', ', '') + @GegenbuchungText END,200)
        WHERE KbBuchungID = @GegenbuchungID
      END

      INSERT INTO dbo.KbOpAusgleich(OpBuchungID, OpBuchungPosition, AusgleichBuchungID, KbAusgleichGrundCode, Betrag, KbBuchungBruttoID)
      VALUES (@DummyBruttoBuchungID, @PosInOPBeleg, @GegenbuchungID, @AusgleichGrund, @AusgleichBetrag, @KbBuchungBruttoID)
    END -- Ende Brutto-/Netto-Verrechnung

    -- zugehörige Nettobuchung bestimmen
    SELECT @KbBuchungID = KBU.KbBuchungID
    FROM dbo.KbBuchungBrutto               KBB
      INNER JOIN dbo.KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
      INNER JOIN dbo.KbBuchungKostenart    KBK ON KBK.BgPositionID      = KBP.BgPositionID
      INNER JOIN dbo.KbBuchung             KBU ON KBU.KbBuchungID       = KBK.KbBuchungID 
        AND ISNULL(KBP.Schuldner_BaPersonID,-1) = ISNULL(KBU.Schuldner_BaPersonID,-1) 
        AND ISNULL(KBP.Schuldner_BaInstitutionID,-1) = ISNULL(KBU.Schuldner_BaInstitutionID,-1) 
        AND KBU.ValutaDatum = KBB.ValutaDatum
    WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID
    
    IF @KbBuchungID IS NULL 
    BEGIN
      -- Bei Problemen auf der Schnittstelle kann das Valutadatum zwischen Brutto- und Nettobeleg unterschiedlich sein
      -- Falls es eine 1:1-Beziehung zwischen Brutto- und Nettobeleg gibt (z.B. bei Einnahmen), kann der Nettobeleg trotzdem ausgeglichen werden
      SELECT @KbBuchungID = MIN(KBU.KbBuchungID)
      FROM dbo.KbBuchungBrutto               KBB
        INNER JOIN dbo.KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
        INNER JOIN dbo.KbBuchungKostenart    KBK ON KBK.BgPositionID      = KBP.BgPositionID
        INNER JOIN dbo.KbBuchung             KBU ON KBU.KbBuchungID       = KBK.KbBuchungID 
         AND ISNULL(KBP.Schuldner_BaPersonID,-1) = ISNULL(KBU.Schuldner_BaPersonID,-1)
         AND ISNULL(KBP.Schuldner_BaInstitutionID,-1) = ISNULL(KBU.Schuldner_BaInstitutionID,-1) 
      WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID
      GROUP BY KBB.KbBuchungBruttoID
      HAVING COUNT(DISTINCT KBU.KbBuchungID) = 1
    END

    IF @IstForderung = 0 OR @KbBuchungID IS NULL OR @AusgleichGrund = 99 
    BEGIN
      -- Falls die Ausgleichsmeldung einen Auszahl-Bruttobeleg betraf, ist mit dem Update der Spalte BetragEffektiv und DatumEffektiv bereits alles getan
      -- oder: Für InvMDAS-Buchungen gibt es keine Netto-Belege
      -- oder: Ausgleichsgrund 99 wird nur für Brutto-Forderungen verarbeitet
      UPDATE dbo.PscdAusgleich
        SET Verarbeitet = 1
      WHERE PscdAusgleichID = @PscdAusgleichID

      COMMIT
      RETURN
    END
  END

  -- Ausgleichsgrund 99 wird nur für Brutto-Forderungen veraerbeitet
  IF @AusgleichGrund = 99 
  BEGIN
    COMMIT
    RETURN
  END

  -- Nächster Versuch: KbBuchung
  IF @KbBuchungID IS NULL 
  BEGIN
    SET @Count = 0

    SELECT @Count = Count(*), @KbBuchungID = MAX(KbBuchungID)
    FROM dbo.KbBuchung
    WHERE BelegNr = @OPBelegNr
    GROUP BY BelegNr

    IF @Count > 1 
    BEGIN
      SET @msg = 'Es existieren ' + CAST(@Count AS VARCHAR) + ' Nettobelege mit Belegnummer ' + CAST(@OPBelegNr AS VARCHAR) + '! Die Belegnummer müsste eindeutig sein.'
      RAISERROR(@msg,18,1)
    END
  END

  -- 1 Nettobeleg gefunden -> Ausgleichsmeldung dafür verarbeiten
  IF @Count = 1 
  BEGIN
    
    -- #75: ALIM 04 - 99 Buchungen von Direktzahlungen
    -- Spez: „Direktzahlung [Kinderalimente][Erwachsenenalimente][Kinderzulagen] MM.JJJJ“
    -- In den Text soll MM.JJJJ eingbaut werden:
    DECLARE @MonatJahrString VARCHAR(20)
    SET @MonatJahrString = ' ' + ISNULL(dbo.fnXMonatJahrString(@AusgleichDatum), 'MM.JJJJ')
    
    -- Infos aus OP holen
    SELECT @OPIstKreditorBuchung   = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN 1 ELSE 0 END,
           @OPIstDebitorBuchung    = CASE WHEN DEB.KontoNr = KBU.SollKtoNr THEN 1 ELSE 0 END,
           @OPIstAusgleichsBuchung = CASE KbBuchungTypCode WHEN 4 THEN 1 ELSE 0 END,
           @KreditorKtoNr          = KRE.KontoNr,
           @DebitorKtoNr           = DEB.KontoNr,
           @AuszahlKtoNr           = AUZ.KontoNr,
           @KbPeriodeID            = KBU.KbPeriodeID,
           @ModulID                = KBU.ModulID,
           @OPHabenKtoNr           = KBU.HabenKtoNr,
           @OPSollKtoNr            = KBU.SollKtoNr,

           -- #75: ALIM 04 - 99 Buchungen von Direktzahlungen
           -- neu wird Ausgleichsgrund 90 geliefert, welcher Direktzahlung bedeutet.
           -- Spez: „Direktzahlung [Kinderalimente][Erwachsenenalimente][Kinderzulagen] MM.JJJJ“
           @OPText = CASE  
                     WHEN @AusgleichGrund = @AusglGrundDirektzahlung AND P.Einmalig = 1 
                       -- Direktzahlungen bei einmaligen Forderungen:
                       THEN LEFT('Direktzahlung ' + ISNULL(
                         -- Text der Forderung aus LOV holen
                         dbo.fnLOVText('IkForderungEinmalig', P.IkForderungEinmaligCode) + @MonatJahrString, 
                         '[Text ist leer]'), 200)  
                     WHEN @AusgleichGrund = @AusglGrundDirektzahlung AND P.Einmalig = 0 
                       -- Direktzahlungen bei periodischen Forderungen:
                       THEN LEFT('Direktzahlung ' + ISNULL(
                         -- Text der Forderung aus LOV holen
                         dbo.fnLOVText('IkForderungArt', KBU.IkForderungArtCode) + @MonatJahrString, 
                         '[Text ist leer]'), 200)  
                     ELSE KBU.Text
                   END,

           @OPBetrag               = KBU.Betrag,
           @OPValuta               = KBU.ValutaDatum,
           @OPBgBudgetID           = KBU.BgBudgetID,
           @OpErstelltUserID       = KBU.ErstelltUserID
    FROM dbo.KbBuchung      KBU
      LEFT JOIN dbo.KbKonto KRE  ON KRE.KbPeriodeID = KBU.KbPeriodeID AND ',' + KRE.KbKontoartCodes + ',' LIKE '%,30,%'
      LEFT JOIN dbo.KbKonto DEB  ON DEB.KbPeriodeID = KBU.KbPeriodeID AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%'  
      LEFT JOIN dbo.KbKonto AUZ  ON AUZ.KbPeriodeID = KBU.KbPeriodeID AND ((KBU.ModulID = 3 AND ',' + AUZ.KbKontoartCodes + ',' LIKE '%,5,%') /*Auszahlkonto Wh*/ OR (KBU.ModulID = 4 AND ',' + AUZ.KbKontoartCodes + ',' LIKE '%,6,%') /*Auszahlkonto Alim*/)
      LEFT JOIN dbo.IkPosition P ON P.IkPositionID = KBU.IkPositionID
    WHERE KbBuchungID = @KbBuchungID

    /************************************* Debitorbuchungen ****************************************/
    IF @OPIstDebitorBuchung = 1 
    BEGIN
      SET @GegenbuchungHabenKtoNr = @DebitorKtoNr

      -- Den vom Ausgleich referenzierten Zahlungseingang suchen
      IF @AusgleichGrund = 1 
      BEGIN --Einzahlung
        IF @Zahlstapel IS NOT NULL AND @PosInZahlstapel IS NOT NULL 
        BEGIN
          SELECT TOP 1 @KbZahlungseingangID = KbZahlungseingangID, @GegenbuchungSollKtoNr = KTO.KontoNr
          FROM dbo.KbZahlungseingang ZAE
            LEFT JOIN dbo.KbPeriode  PER ON PER.PeriodeVon <= ZAE.Datum AND PER.PeriodeBis >= ZAE.Datum
            LEFT JOIN dbo.KbKonto    KTO ON KTO.KbPeriodeID = PER.KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,7,%' /*Zahlungseingangkonto*/ AND KTO.BankKontoNummer = ZAE.PscdBankverrechnKto
          WHERE PscdZahlungsstapel = @Zahlstapel AND PscdZahlungsstapelPos = @PosInZahlstapel
        END

        -- Fallback: Wir haben noch kein Eingangskonto gefunden, also wird das generische verwendet
        SELECT @GegenbuchungSollKtoNr = ISNULL(@GegenbuchungSollKtoNr,KontoNr)
        FROM dbo.KbKonto
        WHERE KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,8,%' /*Zahlungseingangkonto nicht bestimmbar*/

        SET @KbBuchungTypCode = 4 --Ausgleich
      END
      ELSE IF @AusgleichGrund IN (5,10,11,99) 
      BEGIN --Stornobuchungen
        SET @GegenbuchungSollKtoNr = @OPHabenKtoNr
        SET @StorniertKbBuchungID  = @KbBuchungID
        SET @KbBuchungTypCode      = 3 --Automatisch
      END
      ELSE IF @AusgleichGrund IN (8,15) 
      BEGIN --manuelle/maschinelle Kontenpflege
        SET @GegenbuchungSollKtoNr = NULL --ToDo
        SET @KbBuchungTypCode      = 4 --Ausgleich
      END
      ELSE IF @AusgleichGrund = @AusglGrundDirektzahlung 
      BEGIN 
        -- Direktzahlung (Schuldner hat das Geld der Gläubigerin direkt gegeben)
        -- #75: ALIM 04 - 99 Buchungen von Direktzahlungen
        -- neu wird Ausgleichsgrund 90 geliefert, welcher Direktzahlung bedeutet. 
        -- Gegenkonto holen: 
        SET @GegenbuchungHabenKtoNr = @OPSollKtoNr
        SET @GegenbuchungSollKtoNr = NULL
        -- In neuer Buchung TypeCode 4 = "Ausgleich" setzen:
        SET @KbBuchungTypCode = 4 
      END
      ELSE 
      BEGIN
        RAISERROR('Ungültige Ausgleichsdaten', 18, 1)
      END
    END
    
    /************************************* Kreditorbuchungen ****************************************/
    ELSE IF @OPIstKreditorBuchung = 1 
    BEGIN
      SET @GegenbuchungSollKtoNr = @KreditorKtoNr
      IF @AusgleichGrund = 2 
      BEGIN --Auszahlung
        SET @GegenbuchungHabenKtoNr = @AuszahlKtoNr
        SET @KbBuchungTypCode       = 4 --Ausgleich
        SET @AusgleichBetrag        = -@AusgleichBetrag --Bei den Nettobuchungen gibts kein negatives Vorzeichen - ausser vielleicht bei Stornos
      END 
      ELSE IF @AusgleichGrund IN (5,10,11,99) 
      BEGIN --Stornobuchungen
        SET @GegenbuchungHabenKtoNr = @OPSollKtoNr
        SET @StorniertKbBuchungID   = @KbBuchungID
        SET @KbBuchungTypCode       = 3 --Automatisch
        IF @AusgleichGrund = 99 SET @AusgleichBetrag = -@AusgleichBetrag
      END
      ELSE IF @AusgleichGrund IN (8,15) 
      BEGIN --manuelle/maschinelle Kontenpflege
        SET @GegenbuchungHabenKtoNr = NULL --ToDo
        SET @KbBuchungTypCode       = 4 --Ausgleich
      END
      ELSE 
      BEGIN
        RAISERROR('Ungültige Ausgleichsdaten',18,1)
      END
    END
    /************************************* Stornobuchungen ******************************************/
    ELSE 
    BEGIN
      -- Hier wird ein Ausgleichbeleg bearbeitet, der seinerseits einen OP referenziert
      SET @GegenbuchungHabenKtoNr = NULL--@OPSollKtoNr
      SET @GegenbuchungSollKtoNr  = NULL--@OPHabenKtoNr
      IF @AusgleichGrund IN (8,15) 
      BEGIN --manuelle/maschinelle Kontenpflege
        SET @StorniertKbBuchungID = NULL
        SET @KbBuchungTypCode     = 4 --Ausgleich
      END
      ELSE 
      BEGIN
        SET @StorniertKbBuchungID = @KbBuchungID
        SET @KbBuchungTypCode     = 3 --Automatisch
      END
    END
    
    -- #75: ALIM 04 - 99 Buchungen von Direktzahlungen
    -- neu wird Ausgleichsgrund 90 geliefert, welcher Direktzahlung bedeutet.
    --IF @OPText IS NOT NULL AND @AusgleichGrund IN (1,2) BEGIN
    IF @OPText IS NOT NULL AND @AusgleichGrund IN (1, 2, @AusglGrundDirektzahlung) 
    BEGIN
      SET @GegenbuchungText = @OPText    
    END

    -- Bereits vorhandene Gegenbuchung suchen
    SELECT @GegenbuchungID = KbBuchungID
    FROM dbo.KbBuchung
    WHERE BelegNr = @AusgleichBelegNr

    IF @GegenbuchungID IS NULL 
    BEGIN
      -- Gegenbuchung erstellen
      INSERT INTO dbo.KbBuchung (
        KbPeriodeID, KbBuchungTypCode, BelegNr, BelegDatum, ValutaDatum, 
        SollKtoNr, HabenKtoNr, Betrag, [Text], ModulID, ErstelltDatum, MutiertDatum, 
        KbBuchungStatusCode, KbZahlungseingangID, StorniertKbBuchungID)
      VALUES (
        @KbPeriodeID, @KbBuchungTypCode, @AusgleichBelegNr, @AusgleichDatum, @EinzahlungDatum, 
        @GegenbuchungSollKtoNr, @GegenbuchungHabenKtoNr, @AusgleichBetrag, @GegenbuchungText, @ModulID, 
        @Today, @Today, @GegenbuchungBuchungStatusCode, @KbZahlungseingangID, @StorniertKbBuchungID)
      SELECT @GegenbuchungID = SCOPE_IDENTITY()
     
    END
    ELSE 
    BEGIN
      -- Bereits bestehende Gegenbuchung verwenden, Betrag updaten
      UPDATE dbo.KbBuchung
      SET Betrag = Betrag + @AusgleichBetrag,
          [Text] = LEFT(CASE WHEN [Text] LIKE '%' + @GegenbuchungText + '%' THEN [Text] ELSE ISNULL([Text] + ', ', '') + @GegenbuchungText END,200)
      WHERE KbBuchungID = @GegenbuchungID
    END

    INSERT INTO dbo.KbOpAusgleich(OpBuchungID, OpBuchungPosition, AusgleichBuchungID, KbAusgleichGrundCode, Betrag)
    VALUES (@KbBuchungID, @PosInOPBeleg, @GegenbuchungID, @AusgleichGrund, @AusgleichBetrag)

    DECLARE @TotAusgleichBetrag MONEY
    SELECT @TotAusgleichBetrag = SUM(Betrag)
    FROM   dbo.KbOpAusgleich
    WHERE  OpBuchungID = @KbBuchungID

    IF @OPIstAusgleichsBuchung = 1 AND @AusgleichGrund IN (5,10,11) 
    BEGIN
      --Storno/Rückläufer/Rücknahme Ausgleich
      IF ABS(@TotAusgleichBetrag) = ABS(@OPBetrag) 
      BEGIN --todo: vorzeichen
        --Storno/Rückläufer/Rücknahme Ausgleich ist komplett (Meldungen kommen zerstückelt an)
        --den Ausgleichsbeleg auf storniert stellen
        UPDATE dbo.KbBuchung
        SET    KbBuchungStatusCode = 8 --storniert
        WHERE  KbBuchungID = @KbBuchungID

        --den Status des OPs updaten
        UPDATE dbo.KbBuchung
        SET KbBuchungStatusCode = CASE @AusgleichGrund WHEN 10 THEN 9 --Rückläufer
                                                       WHEN 11 THEN 3 --Einnahme ist wieder offen (Rücknahme Ausgleich)
                                                       WHEN  5 THEN 3 --Einnahme/Ausgabe ist wieder offen (wenn der Ausgleichsbeleg storniert wurde)
                                  END
        WHERE KbBuchungID IN
        (
          SELECT OpBuchungID
          FROM dbo.KbOpAusgleich
          WHERE AusgleichBuchungID = @KbBuchungID
        )

        -- Nun noch die Gegen-Ausgleiche zum OP erstellen
        INSERT INTO dbo.KbOpAusgleich(OpBuchungID, OpBuchungPosition, AusgleichBuchungID, KbAusgleichGrundCode, Betrag)
        SELECT OpBuchungID, OpBuchungPosition, AusgleichBuchungID, @AusgleichGrund, -Betrag
        FROM dbo.KbOpAusgleich
        WHERE AusgleichBuchungID = @KbBuchungID
      END
    END
    ELSE 
    BEGIN
      --normaler Ausgleich
      --Status des OPs updaten
      UPDATE dbo.KbBuchung
      SET    KbBuchungStatusCode = CASE WHEN @AusgleichGrund = 5 /*Storno*/ THEN 8 /*storniert*/
                                        WHEN (Betrag >= $0.00 AND @TotAusgleichBetrag >= Betrag) /*Einnahmen*/ OR (Betrag <= $0.00 AND @TotAusgleichBetrag <= Betrag) /*Ausgaben*/ THEN 6 /*ausgeglichen*/ 
                                        WHEN @TotAusgleichBetrag = $0.00 THEN CASE WHEN KbBuchungStatusCode IN (3,10,6) THEN 3 ELSE KbBuchungStatusCode END
                                        ELSE 10 /*teilweise ausgeglichen*/
                                   END
      WHERE  KbBuchungID = @KbBuchungID

      -- Arztrechnung ohne Rückforderung von KK ?
      IF EXISTS(
        SELECT KBU.KbBuchungID FROM dbo.KbBuchung KBU
          INNER JOIN dbo.KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
          INNER JOIN dbo.BgKostenart        BKA ON BKA.KontoNr = CASE 
                                                                   WHEN KBK.KontoNr = '150' THEN '751' 
                                                                   WHEN KBK.KontoNr = '151' THEN '752'
                                                                 END
          INNER JOIN dbo.BgPositionsart     BPA ON BPA.BgKostenartID = BKA.BgKostenartID AND BPA.BgKategorieCode = 1
          LEFT  JOIN dbo.BgPosition         BPO ON BPO.BgBudgetID = KBU.BgBudgetID 
            AND BPO.BaPersonID = KBK.BaPersonID 
            AND BPO.BgPositionsartID = BPA.BgPositionsartID 
            AND BPO.Betrag = KBK.Betrag 
            AND ISNULL(BPO.VerwPeriodeVon,-1) = ISNULL(KBK.VerwPeriodeVon,-1) 
            AND ISNULL(BPO.VerwPeriodeBis,-1) = ISNULL(KBK.VerwPeriodeBis,-1) 
            AND BPO.BgPositionID_AutoForderung = KBK.BgPositionID     --check: bereits Forderung an KK vorhanden? 
        WHERE KBU.KbBuchungID = @KbBuchungID 
          AND KBK.KontoNr IN ('150', '151') 
          AND KBU.KbAuszahlungsArtCode IS NOT NULL  -- nur Auszahlungen berücksichtigen, es könnten auch Rückzahlungen auf die Ausgaben-LAs 150 und 151 gebucht werden
          AND KBU.KbBuchungStatusCode = 6           -- ausgeglichen
          AND BPO.BgPositionID IS NULL              -- Selektiere nur die Buchungen, die noch KEINE Rückforderungs-Position haben
        )
    BEGIN 
    --Arztrechnung ohne Rückforderung von KK 
    -- => es wurde eine Arztrechnung ausbezahlt, das wollen wir sofort von der KK zurück!
        DECLARE @KKBaInstitutionID      INT,
                @KKName                 VARCHAR(200),
                @KKForderungKbBuchungID INT,
                @KKBgPositionID         INT

        DECLARE @EntriesCount INT;
        DECLARE @EntriesIterator INT;

        DECLARE @BgPositionID_KK TABLE
        (
          ID INT IDENTITY(1, 1) NOT NULL,
          BgPositionID INT
        );

        -- KK bestimmen, an welche die Rechnung geht
        -- Prio 1 KK die zum Zeitpunkt des OP-Valutas gültig war. Prio 2 die letzte KK vor dem OP-Valuta. Prio 3 die aktuellste KK
        SELECT TOP 1 @KKBaInstitutionID = INS.BaInstitutionID, @KKName = INS.Name
        FROM dbo.KbBuchung                  KBU
          INNER JOIN dbo.KbBuchungKostenart KBK ON KBK.KbBuchungID     = KBU.KbBuchungID
          INNER JOIN dbo.BgBudget           BUD ON BUD.BgBudgetID      = KBU.BgBudgetID
          INNER JOIN dbo.BgBudget           MAB ON MAB.BgFinanzplanID  = BUD.BgFinanzplanID 
                                               AND MAB.MasterBudget = 1
          INNER JOIN dbo.BgPosition         KVG ON KVG.BgBudgetID      = MAB.BgBudgetID /*KVG im Masterbudget*/ 
                                               AND KVG.BgPositionsartID = 32020 /*KVG*/ 
                                               AND KVG.BaPersonID = KBK.BaPersonID 
                                               AND KVG.Betrag <> $0.00 -- nur aktive Positionen
          LEFT  JOIN dbo.BgAuszahlungPerson AZP WITH (READUNCOMMITTED) ON AZP.BgPositionID = KVG.BgPositionID
          LEFT  JOIN dbo.BaZahlungsweg      ZLW WITH (READUNCOMMITTED) ON ZLW.BaZahlungswegID = AZP.BaZahlungswegID
          LEFT  JOIN dbo.BaInstitution      INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZLW.BaInstitutionID
        WHERE KBU.KbBuchungID = @KbBuchungID 
          AND KBK.KontoNr IN ('150', '151')
        ORDER BY CASE 
                   WHEN @OPValuta BETWEEN ISNULL(KVG.DatumVon, '17530101') AND ISNULL(KVG.DatumBis, '99991231') THEN 1 
                   WHEN ISNULL(KVG.DatumBis, '99991231') < @OPValuta THEN 2 
                   ELSE 3 
                 END, 
                 ISNULL(KVG.DatumVon, '17530101') DESC

        -- Keine KK im FP gefunden, in den Basisdaten (ver)suchen
        IF @KKBaInstitutionID IS NULL 
        BEGIN
          SELECT TOP 1 @KKBaInstitutionID = BKV.BaInstitutionID, @KKName = INS.Name
          FROM dbo.BaKrankenversicherung      BKV
            INNER JOIN dbo.BaInstitution      INS ON INS.BaInstitutionID  = BKV.BaInstitutionID
            INNER JOIN dbo.KbBuchungKostenart KBK ON KBK.KbBuchungID = @KbBuchungID 
                                                 AND BKV.BaPersonID = KBK.BaPersonID
          WHERE GesetzesGrundlageCode = 1 --KVG
          ORDER BY CASE 
                     WHEN @OPValuta BETWEEN ISNULL(BKV.DatumVon, '17530101') AND ISNULL(BKV.DatumBis, '99991231') THEN 1
                     WHEN ISNULL(BKV.DatumBis, '99991231') < @OPValuta THEN 2
                     ELSE 3
                   END,
                   ISNULL(BKV.DatumVon, '17530101') DESC
        END

        --Budgetposition erstellen
        INSERT INTO dbo.BgPosition(
            BgBudgetID, BgKategorieCode, BaPersonID, BaInstitutionID, BgPositionsartID, 
            Buchungstext, Betrag, 
            VerwPeriodeVon, VerwPeriodeBis, FaelligAm, VerwaltungSD, BgBewilligungStatusCode, ErstelltDatum, MutiertDatum, BgPositionID_AutoForderung)
          OUTPUT INSERTED.BgPositionID INTO @BgPositionID_KK
          SELECT DISTINCT
            @OPBgBudgetID, 1 /*Einnahmen*/, KBK.BaPersonID, @KKBaInstitutionID, BPA.BgPositionsartID, 
            SUBSTRING(ISNULL(@KKName +': ','') + ISNULL(KBK.Buchungstext,'Arztrechnung'), 1, 100), KBK.Betrag,
            KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, KBU.ValutaDatum, 1 /*abgetreten*/, 1, @Today, @Today, KBK.BgPositionID
          FROM dbo.KbBuchungKostenart     KBK
            INNER JOIN dbo.KbBuchung      KBU ON KBU.KbBuchungID   = KBK.KbBuchungID
            INNER JOIN dbo.BgKostenart    BKA ON BKA.KontoNr = CASE 
                                                                 WHEN KBK.KontoNr = '150' THEN '751' 
                                                                 WHEN KBK.KontoNr = '151' THEN '752'
                                                               END
            INNER JOIN dbo.BgPositionsart BPA ON BPA.BgKostenartID = BKA.BgKostenartID AND BPA.BgKategorieCode = 1
          WHERE KBK.KbBuchungID = @KbBuchungID

        -- prepare vars for loop
        SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
        SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

        -- alle erstellte Budgetpositionen auf grün stellen - auf gut Glück. Falls zB Debitor fehlt, muss Sozi ergänzen und manuell auf grün stellen
        WHILE (@EntriesIterator <= @EntriesCount)
        BEGIN
          -- get current entry
          SELECT @KKBgPositionID = TMP.BgPositionID
          FROM @BgPositionID_KK  TMP
          WHERE TMP.ID = @EntriesIterator;
          
          BEGIN TRY
            EXEC dbo.spWhBudget_CreateKbBuchung @OPBgBudgetID, @OPErstelltUserID, 0, 0, @KKBgPositionID
          END TRY
          BEGIN CATCH
            -- Fehler-Log
            SET @LogMessage = 'Fehler beim Grünstellen der automatischen KK-Sollstellung für Arztrechnung (Netto-ID ' + CONVERT(VARCHAR, @KbBuchungID) + ')'
            SET @LogException = ERROR_MESSAGE()
            EXEC spXLogAddEntry @ProcedureName, 0, 3, @LogMessage, @LogException, 'BgPosition', @KKBgPositionID
          END CATCH
          
          -- prepare for next entry
          SET @EntriesIterator = @EntriesIterator + 1;
        END;
      END -- Arztrechnung
      
      -- eingegangene vermittelte Alimente (ALV)?
      ELSE IF (@AusgleichGrund = 1 AND EXISTS( --Einzahlung
        SELECT KBU.KbBuchungID
        FROM dbo.KbBuchung KBU
          INNER JOIN dbo.KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
        WHERE KBU.KbBuchungID = @KbBuchungID 
          AND KBK.PositionImBeleg = @PosInOPBeleg 
          -- 30.04.2009 : sozheo : #4534: Bereinigung falscher LA
          AND (KBK.KontoNr IN ('920', '921', '922') /*ALV*/ OR KBU.AuszahlungErzeugen = 1) 
          AND KBU.KbBuchungStatusCode IN (6,10) /*(teil-)ausgeglichen*/ )) 
      BEGIN
        -- 26.03.2009 : sozheo : neu mit TRY / CATCH, damit fehlerhafte Daten nicht in PSCDLeiche verschoben werden
        BEGIN TRY
          EXEC dbo.spKbBuchung_Create_AlimVermittelte @KbBuchungID, @AusgleichBetrag, @KreditorKtoNr, NULL
        END TRY
        BEGIN CATCH
          DECLARE @MsgALV VARCHAR(200)
          SET @MsgALV = ERROR_MESSAGE()
          INSERT INTO dbo.IkAlvAusgleichBuffer(OpKbBuchungID, AusgleichBetrag, KreditorKtoNr, Fehlermeldung)
          VALUES (@KbBuchungID, @AusgleichBetrag, @KreditorKtoNr, @MsgALV)
        END CATCH

/*
--debug
select * from KbBuchung
where kbbuchungid = @AlvAuszahlungKbBuchungID

select * from KbBuchungkostenart
where kbbuchungid = @AlvAuszahlungKbBuchungID
*/

--RAISERROR('ALV gefunden!',18,1)
        
      END -- Ende ALV
      
      -- Direktzahlung (Schuldner hat das Geld der Gläubigerin direkt gegeben)
      --ELSE IF @AusgleichGrund = @AusglGrundDirektzahlung BEGIN 
        -- #75: ALIM 04 - 99 Buchungen von Direktzahlungen
        -- es darf keine Vermittlung stattfinden.
        -- nothing to do here
      --END -- Ende Direktzahlung
      
      -- InvMDAS-Auszahlung erfolgt?
      ELSE IF (@AusgleichGrund = 2 
               AND /*Auszahlung*/ EXISTS(SELECT KBU.KbBuchungID--, @KontoNr = KBK.KontoNr
                                         FROM dbo.KbBuchung                  KBU
                                           INNER JOIN dbo.KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
                                         WHERE KBU.KbBuchungTypCode <> 4 
                                           AND KBU.KbBuchungID = @KbBuchungID 
                                           AND KBK.KontoNr IN ('320', '321') /*Mietzinsdepot, Anteilschein*/ 
                                           AND KBU.KbBuchungStatusCode = 6 /*(teil-)ausgeglichen*/ )) 
      BEGIN
        DECLARE @KontoNr      VARCHAR(20),
                @BgPositionID INT

        SELECT  @KontoNr = KBK.KontoNr, 
                @BgPositionID = KBK.BgPositionID
        FROM dbo.KbBuchung                  KBU
          INNER JOIN dbo.KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
        WHERE KBU.KbBuchungID = @KbBuchungID 
          AND KBK.KontoNr IN ('320', '321')

        -- BaSicherheitsleistung anlegen
        INSERT INTO dbo.BaSicherheitsleistung(BaPersonID, AuszahlungAm, BaMieteSicherheitsleistungArtCode, BaInstitutionID, BaBankID, KontoNummer, IBAN )
        SELECT TOP 1 LEI.BaPersonID, 
                     KBU.ValutaDatum, 
                     CASE @KontoNr WHEN '320' THEN 3 /*AS*/ WHEN '321' THEN 2 /*MD*/ END, 
                     BaInstitutionID, 
                     CASE WHEN ZAL.EinzahlungsscheinCode IN (1,2) THEN NULL ELSE ZAL.BaBankID END, 
                     CASE WHEN ZAL.EinzahlungsscheinCode IN (1,2) THEN NULL ELSE ZAL.BankKontoNummer END, 
                     CASE WHEN ZAL.EinzahlungsscheinCode IN (1,2) THEN NULL ELSE ZAL.IBANNummer END
        FROM dbo.KbBuchung                  KBU
          INNER JOIN dbo.FaLeistung         LEI ON LEI.FaLeistungID = KBU.FaLeistungID
          LEFT  JOIN dbo.BaZahlungsweg      ZAL ON ZAL.BaZahlungswegID = KBU.BaZahlungswegID
        WHERE KBU.KbBuchungID = @KbBuchungID

        -- Position anlegen
        INSERT INTO dbo.BaSicherheitsleistungPosition(BaSicherheitsleistungID, BaSicherheitsleistungPositionCode, BgPositionID, KbBuchungID)
        SELECT SCOPE_IDENTITY(), 1/*Auszahlung*/, @BgPositionID, @KbBuchungID

      END --Ende InvMDAS
--RAISERROR('Ich will nur testen',18,1)
    END
/*
--debug
SELECT 'Ausgleiche',*
FROM   KbOpAusgleich
WHERE  OpBuchungID > 1100 OR OpBuchungID IN( @KbBuchungID,1025)

SELECT 'Buchungen',*
FROM KbBuchung
WHERE KbBuchungID > 1100 OR KbBuchungID IN (@KbBuchungID,@GegenbuchungID,1025)

IF @KbBuchungBruttoID IS NOT NULL 
SELECT 'Bruttobuchungen', *
FROM KbBuchungBrutto
WHERE KbBuchungBruttoID = @KbBuchungBruttoID
  */
  END
  ELSE 
  BEGIN
    SET @Count = 0
    -- Kein Netto- und kein Bruttobeleg, bleiben noch die K-Belege
    DECLARE @OPHabenKonto            VARCHAR(10),
            @OPSollKonto             VARCHAR(10),
            @OPKgBuchungID           INT,
            @KgBuchungIDOut          INT,
            @KgPeriodeID             INT,
            @KgAuszahlungsartCode    INT,
            @KontokorrentKontoNr     VARCHAR(10),
            @GegenbuchungKgPeriodeID INT

  -- Suche zuerst nach PSCD-Belegnummer
    SELECT  @Count                = COUNT(*), 
            @KgPeriodeID          = SUM(KBU.KgPeriodeID), 
            @OPKgBuchungID        = SUM(KgBuchungID), 
            @OPBetrag             = SUM(Betrag), 
            @KgAuszahlungsartCode = SUM(KgAuszahlungsartCode), 
            @KontokorrentKontoNr  = dbo.ConcDistinct(KontoNr), 
            @OPHabenKonto         = dbo.ConcDistinct(HabenKtoNr), 
            @OPSollKonto          = dbo.ConcDistinct(SollKtoNr), 
            @OPText               = dbo.ConcDistinct(Text)
    FROM dbo.KgBuchung       KBU
      INNER JOIN dbo.KgKonto KTO ON KTO.KgPeriodeID = KBU.KgPeriodeID 
        AND KgKontoartCode = 1
    WHERE PscdBelegNr = @OPBelegNr
    GROUP BY PscdBelegNr

    IF @Count > 1 
    BEGIN
      SET @msg = 'Es existieren ' + CAST(@Count AS VARCHAR) + ' K-Belege mit Belegnummer ' + CAST(@OPBelegNr AS VARCHAR) + '! Die Belegnummer müsste eindeutig sein.'
      RAISERROR(@msg,18,1)
    END
    ELSE IF @Count = 0 
    BEGIN
      IF @OPBelegNr NOT BETWEEN 60000000000 AND 60999999999    -- WV-Einzelposten werden über die WV-Statusmeldungen abgehandelt, die Ausgleichsmeldungen dürfen nicht in PscdAusgleichLeiche landen, da sie diese Tabelle sonst unnötig aufblähen
        AND @OPBelegNr NOT BETWEEN 32000000000 AND 32999999999 -- Die Auszahlungsmeldungen von PSCD für die K-Belege interessieren nicht, wir kennen die Belegnummer der Auszahlanforderung gar nicht. Auch sie würden PscdAusgleichLeiche unnötig aufblähen
        AND @PscdGeschaeftspartnerID NOT BETWEEN 16000 AND 16099 
      BEGIN  -- WV läuft über Statusmeldungen
        -- Bevor wir aufgeben, suche nochmals in den K-Belegen nach einer Buchung, die keine PSCD-Belegnummer hat und deren KgBuchungID aber der OPBEL entspricht
        -- Dies wäre dann ein K-Beleg, der wegen Locking-Problemen auf der KiSS-DB zwar ans PSCD übermittelt wurde, aber die PSCD-Belegnummer konnte nicht zurückgeschrieben werden
        SELECT @Count = Count(*), 
               @KgPeriodeID = SUM(KBU.KgPeriodeID), 
               @OPKgBuchungID = SUM(KgBuchungID),
               @OPBetrag = SUM(Betrag), 
               @KgAuszahlungsartCode = SUM(KgAuszahlungsartCode), 
               @KontokorrentKontoNr = dbo.ConcDistinct(KontoNr), 
               @OPHabenKonto = dbo.ConcDistinct(HabenKtoNr), 
               @OPSollKonto = dbo.ConcDistinct(SollKtoNr), 
               @OPText = dbo.ConcDistinct(Text)
        FROM dbo.KgBuchung       KBU
          INNER JOIN dbo.KgKonto KTO ON KTO.KgPeriodeID = KBU.KgPeriodeID AND KgKontoartCode = 1
        WHERE  @OPBelegNr LIKE '30%' + CONVERT(VARCHAR, KBU.KgBuchungID) 
          AND PscdBelegNr IS NULL
        GROUP BY KgBuchungID
    
        IF @Count <> 1 
        BEGIN
          -- #5449: Storno eines SiLei-Ausgleiches kann nicht verarbeitet werden, da der Ausgleichsbeleg im KiSS nicht abgebildet wird
          IF @PscdGeschaeftspartnerID = 499998 AND @AusgleichGrund = 5 
          BEGIN
            UPDATE dbo.PscdAusgleich
            SET Verarbeitet = 1, Fehlermeldung = 'Storno eines Ausgleichs einer SiLei-Forderung ignoriert'
            WHERE PscdAusgleichID = @PscdAusgleichID
          END
        ELSE 
        BEGIN
          -- Kein eindeutiger Beleg gefunden => Fehlermeldung
          SET @msg = 'Es existiert kein Beleg mit Belegnummer ' + CAST(@OPBelegNr AS VARCHAR) + '!'
          RAISERROR(@msg,18,1)
        END
      END
      ELSE 
      BEGIN
        -- Ok, Beleg gefunden, nun speichere noch die OPBEL (PSCD-Belegnummer) ab
        UPDATE KgBuchung
        SET PscdBelegNr = @OPBelegNr
        WHERE KgBuchungID = @OPKgBuchungID
      END
    END 
    ELSE 
    BEGIN
      SET @OPKgBuchungID = NULL
    END
  END
    
    IF @OPKgBuchungID IS NOT NULL 
    BEGIN
      SET @AusgleichBetrag = -@AusgleichBetrag
      IF ABS(@OPBetrag) <> ABS(@AusgleichBetrag) 
      BEGIN
        SET @msg = 'Der Ausgleichsbetrag ' + CAST(@AusgleichBetrag as varchar) + ' entspricht nicht dem erwarteten Betrag von ' + CAST(@OPBetrag AS VARCHAR)
        RAISERROR(@msg,18,1)
      END

      --ok, Checks erfolgreich bestanden, Ausgleich buchen

      -- Klient hat den Barbeleg eingelöst, das Geld ist aber noch nicht von seinem Konto zur Stadtkasse überwiesen worden.
      -- Überweisung wird mit Ausgleichsgrund 2 gemeldet.
      IF(@AusgleichGrund = 26 AND @KgAuszahlungsartCode = 103)
      BEGIN
        UPDATE dbo.KgBuchung
          SET BarbezugDatum = @AusgleichDatum
        WHERE KgBuchungID = @OPKgBuchungID
      END
      ELSE
      BEGIN
        UPDATE dbo.KgBuchung
          SET KgBuchungStatusCode = CASE @AusgleichGrund WHEN 5 THEN 8 ELSE 6 END --storniert/ausgeglichen
        WHERE KgBuchungID = @OPKgBuchungID

        SELECT @GegenbuchungKgPeriodeID = CASE WHEN GGB.KgPeriodeID IS NOT NULL THEN GGB.KgPeriodeID 
                                               WHEN ORI.KgPeriodeStatusCode = 1 THEN ORI.KgPeriodeID 
                                          END
        FROM dbo.KgPeriode         ORI
          LEFT JOIN dbo.KgPeriode  GGB ON GGB.FaLeistungID = ORI.FaLeistungID 
            AND @AusgleichDatum BETWEEN GGB.PeriodeVon 
            AND GGB.PeriodeBis 
            AND GGB.KgPeriodeStatusCode = 1 /*aktiv*/
        WHERE ORI.KgPeriodeID = @KgPeriodeID

        IF @GegenbuchungKgPeriodeID IS NULL 
        BEGIN
          SET @msg = 'Es existiert keine aktive Buchungsperiode für das Zahlungseingangsdatum ' + CONVERT(VARCHAR, @AusgleichDatum, 104)
          RAISERROR(@msg,18,1)
        END


        -- Gegenbuchung erzeugen
        INSERT INTO dbo.KgBuchung(
          KgPeriodeID, KgBuchungTypCode, KgAusgleichStatusCode, BuchungsDatum, 
          SollKtoNr, 
          HabenKtoNr, 
          Betrag, Text, 
          ErstelltDatum, MutiertDatum, KgBuchungStatusCode, TransferDatum, ValutaDatum)
        VALUES(
          @GegenbuchungKgPeriodeID, 3, 3, ISNULL(ISNULL(@EinzahlungDatum,@AusgleichDatum),GETDATE()), 
          @OPHabenKonto, 
          CASE @AusgleichGrund 
            WHEN 5 THEN @OPSollKonto /*Storno: zurück aufs LA-Konto*/ 
            ELSE @KontokorrentKontoNr /*Auszahlung: Ab aufs Kontokorrent*/ 
          END, 
          @AusgleichBetrag, @OPText, 
          @Today, @Today, 6, NULL, ISNULL(ISNULL(@EinzahlungDatum,@AusgleichDatum),GETDATE()))

        SET @KgBuchungIDOut = SCOPE_IDENTITY()

        INSERT INTO dbo.KgOpAusgleich(OpBuchungID, AusgleichBuchungID, Betrag, KbAusgleichGrundCode)
          VALUES(@OPKgBuchungID, @KgBuchungIDOut, @AusgleichBetrag, @AusgleichGrund)
      END
    END
  END

  --ROLLBACK
  UPDATE dbo.PscdAusgleich
    SET Verarbeitet = 1
  WHERE PscdAusgleichID = @PscdAusgleichID

  COMMIT
END TRY
BEGIN CATCH  
  ROLLBACK

  SET @msg = 'Line ' + CAST(ERROR_LINE() AS VARCHAR) + ': ' + ERROR_MESSAGE()
  UPDATE dbo.PscdAusgleich
  SET Fehlermeldung = @msg
  WHERE PscdAusgleichID = @PscdAusgleichID

  RAISERROR(@msg,18,1)
END CATCH