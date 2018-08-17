SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spPscdProcessAusgleichsinfo_test
GO

CREATE PROCEDURE [dbo].[spPscdProcessAusgleichsinfo_test]
(
  @AusgleichBelegNr bigint,
  @AusgleichBetrag money,
  @AusgleichDatum datetime,
  @AusgleichGrund int,
  @EinzahlungDatum datetime,
  @PscdVertragsgegenstandID int,
  @PscdGeschaeftspartnerID int,
  @OPBelegNr bigint,
  @PosInOPBeleg int,
  @Zahlstapel varchar(12),
  @PosInZahlstapel int,
  @OPUPW int,
  @OPUPZ int
)
AS

BEGIN TRY

  DECLARE @KbBuchungID int,
          @KbBuchungBruttoID int,
          @KgBuchungID int,
          @Count int,
          @msg varchar(200),
          @OPIstKreditorBuchung bit,
          @OPIstDebitorBuchung bit,
          @OPIstAusgleichsBuchung bit,
          @KbZahlungseingangID int,
          @GegenbuchungHabenKtoNr varchar(10),
          @GegenbuchungSollKtoNr varchar(10),
          @GegenbuchungText varchar(200),
          @KbPeriodeID int,
          @DebitorKtoNr varchar(10),
          @KreditorKtoNr varchar(10),
          @AuszahlKtoNr int,
          @OPText varchar(200),
          @OPHabenKtoNr int,
          @OPSollKtoNr int,
          @GegenbuchungID int,
          @IstForderung bit,
          @StorniertKbBuchungID int,
          @KbBuchungTypCode int,
          @AusgleichGrundText varchar(50),
          @NeuerOPKbBuchungStatusCode int,
          @ModulID int,
          @PscdAusgleichID int,
          @OPBetrag money,
          @OPValuta datetime,
          @OPBgBudgetID int,
          @OpErstelltUserID int

  --Ausgleichsmeldung speichern
  INSERT INTO PscdAusgleich(AUGBL, AUGBT, AUGDT, AUGRD, EZDAT, OPBEL, VTREF, GPART, KEYZ1, OPUPK, OPUPW, OPUPZ, POSZA, Verarbeitet)
  VALUES (@AusgleichBelegNr, @AusgleichBetrag, CONVERT(varchar,@AusgleichDatum,104), @AusgleichGrund, CONVERT(varchar,@EinzahlungDatum,104), @OPBelegNr, @PscdVertragsgegenstandID, @PscdGeschaeftspartnerID, @Zahlstapel, @PosInOPBeleg, @OPUPW, @OPUPZ, @PosInZahlstapel, 0)
  SET @PscdAusgleichID = SCOPE_IDENTITY()

  -- ToDo: wirklich ignorieren?
  IF @AusgleichGrund = 99 RETURN

  BEGIN TRAN

  IF @AusgleichGrund NOT IN (1,2,5,8,10,11,15,99) BEGIN
    SET @msg = 'AusgleichsgrundCode ' + CAST(@AusgleichGrund AS varchar) + ' ist unbekannt'
    RAISERROR(@msg,18,1)
    RETURN
  END

  SELECT @AusgleichGrundText = dbo.fnLOVText('KbAusgleichGrund',@AusgleichGrund)
  SET @AusgleichBetrag = -@AusgleichBetrag

  -- Wir erhalten eine Belegnummer, wissen aber nicht in welcher Tabelle dieser abgelegt ist: KbBuchung, KbBuchungBrutto oder KgBuchung
  -- Probieren wir's mal in KbBuchungBrutto
  SET @Count = 0
  SELECT @Count = Count(*), @KbBuchungBruttoID = SUM(KbBuchungBruttoID), @IstForderung = CASE WHEN SUM(Betrag) > $0.00 THEN 1 ELSE 0 END
  FROM KbBuchungBrutto
  WHERE BelegNr = @OPBelegNr
  GROUP BY BelegNr

  IF @Count > 1 BEGIN
    SET @msg = 'Es existieren '+CAST(@Count AS varchar)+' Bruttobelege mit Belegnummer '+CAST(@OPBelegNr AS varchar)+'! Die Belegnummer müsste eindeutig sein.'
    RAISERROR(@msg,18,1)
  END

  IF @Count = 1 BEGIN
      -- Ausgleiche auf Bruttobelegen
      UPDATE KbBuchungBrutto
      SET BetragEffektiv = IsNull(BetragEffektiv,$0.00) + @AusgleichBetrag,
          DatumEffektiv = @AusgleichDatum, 
          KbBuchungStatusCode = CASE WHEN Betrag = IsNull(BetragEffektiv,$0.00) + @AusgleichBetrag THEN 6 /*ausgeglichen*/ ELSE 10 /*teilweise ausgeglichen*/ END
      WHERE KbBuchungBruttoID = @KbBuchungBruttoID
    IF @IstForderung = 0 BEGIN
      -- Falls die Ausgleichsmeldung einen Auszahl-Bruttobeleg betraf, ist mit dem Update der Spalte BetragEffektiv und DatumEffektiv beretis alles getan
      COMMIT
      RETURN
    END

    SELECT @KbBuchungID = KBU.KbBuchungID
    FROM KbBuchungBrutto               KBB
      INNER JOIN KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
      INNER JOIN KbBuchungKostenart    KBK ON KBK.BgPositionID      = KBP.BgPositionID
      INNER JOIN KbBuchung             KBU ON KBU.KbBuchungID       = KBK.KbBuchungID AND IsNull(KBP.Schuldner_BaPersonID,-1) = IsNull(KBU.Schuldner_BaPersonID,-1) AND IsNull(KBP.Schuldner_BaInstitutionID,-1) = IsNull(KBU.Schuldner_BaInstitutionID,-1) AND KBU.ValutaDatum = KBB.ValutaDatum
    WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID
  END

  -- Nächster Versuch: KbBuchung
  IF @KbBuchungID IS NULL BEGIN
    SET @Count = 0
    SELECT @Count = Count(*), @KbBuchungID = SUM(KbBuchungID)
    FROM KbBuchung
    WHERE BelegNr = @OPBelegNr
    GROUP BY BelegNr

    IF @Count > 1 BEGIN
      SET @msg = 'Es existieren '+ CAST(@Count AS varchar) +' Nettobelege mit Belegnummer '+ CAST(@OPBelegNr AS varchar) +'! Die Belegnummer müsste eindeutig sein.'
      RAISERROR(@msg,18,1)
    END
  END

  -- 1 Nettobeleg gefunden -> Ausgleichsmeldung dafür verarbeiten
  IF @Count = 1 BEGIN
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
           @OPText                 = KBU.Text,
           @OPBetrag               = KBU.Betrag,
           @OPValuta               = KBU.ValutaDatum,
           @OPBgBudgetID           = KBU.BgBudgetID,
           @OpErstelltUserID       = KBU.ErstelltUserID
    FROM KbBuchung      KBU
      LEFT JOIN KbKonto KRE ON KRE.KbPeriodeID = KBU.KbPeriodeID AND ',' + KRE.KbKontoartCodes + ',' LIKE '%,30,%'
      LEFT JOIN KbKonto DEB ON DEB.KbPeriodeID = KBU.KbPeriodeID AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%'  
      LEFT JOIN KbKonto AUZ ON AUZ.KbPeriodeID = KBU.KbPeriodeID AND ((KBU.ModulID = 3 AND ',' + AUZ.KbKontoartCodes + ',' LIKE '%,5,%') /*Auszahlkonto Wh*/ OR (KBU.ModulID = 4 AND ',' + AUZ.KbKontoartCodes + ',' LIKE '%,6,%') /*Auszahlkonto Alim*/)
    WHERE KbBuchungID = @KbBuchungID

    /************************************* Debitorbuchungen ****************************************/
    IF @OPIstDebitorBuchung = 1 BEGIN
      SET @GegenbuchungHabenKtoNr = @DebitorKtoNr

      -- Den vom Ausgleich referenzierten Zahlungseingang suchen
      IF @AusgleichGrund = 1 BEGIN --Einzahlung
        IF @Zahlstapel IS NOT NULL AND @PosInZahlstapel IS NOT NULL BEGIN
          SELECT TOP 1 @KbZahlungseingangID = KbZahlungseingangID, @GegenbuchungSollKtoNr = KTO.KontoNr
          FROM KbZahlungseingang ZAE
            LEFT JOIN KbPeriode  PER ON PER.PeriodeVon <= ZAE.Datum AND PER.PeriodeBis >= ZAE.Datum
            LEFT JOIN KbKonto    KTO ON KTO.KbPeriodeID = PER.KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,7,%' /*Zahlungseingangkonto*/ AND KTO.BankKontoNummer = ZAE.PscdBankverrechnKto
          WHERE PscdZahlungsstapel = @Zahlstapel AND PscdZahlungsstapelPos = @PosInZahlstapel
        END

        -- Fallback: Wir haben noch kein Eingangskonto gefunden, also wird das generische verwendet
        SELECT @GegenbuchungSollKtoNr = IsNull(@GegenbuchungSollKtoNr,KontoNr)
        FROM KbKonto
        WHERE KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,8,%' /*Zahlungseingangkonto nicht bestimmbar*/

        SET @KbBuchungTypCode = 4 --Ausgleich
      END
      ELSE IF @AusgleichGrund IN (5,10,11,99) BEGIN --Stornobuchungen
        SET @GegenbuchungSollKtoNr = @OPHabenKtoNr
        SET @StorniertKbBuchungID  = @KbBuchungID
        SET @KbBuchungTypCode      = 3 --Automatisch
      END
      ELSE IF @AusgleichGrund IN (8,15) BEGIN --manuelle/maschinelle Kontenpflege
        SET @GegenbuchungSollKtoNr = NULL --ToDo
        SET @KbBuchungTypCode      = 3 --Automatisch
      END
      ELSE BEGIN
        RAISERROR('Ungültige Ausgleichsdaten',18,1)
      END

    END
    /************************************* Kreditorbuchungen ****************************************/
    ELSE IF @OPIstKreditorBuchung = 1 BEGIN
      SET @GegenbuchungSollKtoNr = @KreditorKtoNr
      IF @AusgleichGrund = 2 BEGIN --Auszahlung
        SET @GegenbuchungHabenKtoNr = @AuszahlKtoNr
        SET @KbBuchungTypCode       = 4 --Ausgleich
        SET @AusgleichBetrag        = -@AusgleichBetrag --Bei den Nettobuchungen gibts kein negatives Vorzeichen - ausser vielleicht bei Stornos
      END 
      ELSE IF @AusgleichGrund IN (5,10,11,99) BEGIN --Stornobuchungen
        SET @GegenbuchungHabenKtoNr = @OPSollKtoNr
        SET @StorniertKbBuchungID   = @KbBuchungID
        SET @KbBuchungTypCode       = 3 --Automatisch
        IF @AusgleichGrund = 99 SET @AusgleichBetrag = -@AusgleichBetrag
      END
      ELSE IF @AusgleichGrund IN (8,15) BEGIN --manuelle/maschinelle Kontenpflege
        SET @GegenbuchungHabenKtoNr = NULL --ToDo
        SET @KbBuchungTypCode       = 3 --Automatisch
      END
      ELSE BEGIN
        RAISERROR('Ungültige Ausgleichsdaten',18,1)
      END
    END
    /************************************* Stornobuchungen ******************************************/
    ELSE BEGIN
      -- Hier wird ein Ausgleichbeleg bearbeitet, der seinerseits einen OP referenziert
      SET @GegenbuchungHabenKtoNr = NULL--@OPSollKtoNr
      SET @GegenbuchungSollKtoNr  = NULL--@OPHabenKtoNr
      SET @StorniertKbBuchungID   = @KbBuchungID
      SET @KbBuchungTypCode       = 3 --Automatisch
      
      --
/*
      SET @msg = 'Der Nettobeleg mit Belegnummer ' + CAST(@OPBelegNr as varchar) + ' ist weder eine Kreditor- noch eine Debitorbuchung! Deshalb kann kein Ausgleich mit Grund ' + @AusgleichGrundText + ' dazu verarbeitet werden'
      RAISERROR(@msg,18,1)
      RETURN
*/
    END

/*
    SET @NeuerOPKbBuchungStatusCode = CASE @AusgleichGrund WHEN  5 THEN  8 --storniert
                                                           WHEN 10 THEN  9 --Rückläufer
                                                           WHEN 11 THEN  8 --storniert (Rücknahme Ausgleich)
                                                           WHEN 99 THEN  3 --ZahlauftragErstellt (wieder offen)
                                      END
*/
    SET @GegenbuchungText = CASE @AusgleichGrund WHEN  1 THEN IsNull(@OPText, 'Ausgleich durch Einzahlung')
                                                 WHEN  2 THEN IsNull(@OPText, 'Ausgleich durch Auszahlung')
                                                 WHEN  5 THEN 'Storno'
                                                 WHEN  8 THEN 'manuelle Kontenpflege'
                                                 WHEN 10 THEN 'Rückläufer'
                                                 WHEN 11 THEN 'Rücknahme Ausgleich'
                                                 WHEN 15 THEN 'maschinelle Kontenpflege'
                                                 WHEN 99 THEN 'OP wieder offen'
                            END

    -- Bereits vorhandene Gegenbuchung suchen
    SELECT @GegenbuchungID = KbBuchungID
    FROM KbBuchung
    WHERE BelegNr = @AusgleichBelegNr

    IF @GegenbuchungID IS NULL BEGIN
      -- Gegenbuchung erstellen
      INSERT INTO KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegNr, BelegDatum, ValutaDatum, SollKtoNr, HabenKtoNr, Betrag, [Text], ModulID, ErstelltDatum, MutiertDatum, KbBuchungStatusCode, KbZahlungseingangID, StorniertKbBuchungID)
      VALUES (@KbPeriodeID, @KbBuchungTypCode, @AusgleichBelegNr, @AusgleichDatum, @EinzahlungDatum, @GegenbuchungSollKtoNr, @GegenbuchungHabenKtoNr, @AusgleichBetrag, @GegenbuchungText, @ModulID, GetDate(), GetDate(), 13 /*verbucht*/, @KbZahlungseingangID, @StorniertKbBuchungID)
      SELECT @GegenbuchungID = SCOPE_IDENTITY()
    END
    ELSE BEGIN
      -- Bereits bestehende Gegenbuchung verwenden, Betrag updaten
      UPDATE KbBuchung
      SET Betrag = Betrag + @AusgleichBetrag,
          [Text] = CASE WHEN [Text] LIKE '%' + @GegenbuchungText + '%' THEN [Text] ELSE IsNull([Text] + ', ', '') + @GegenbuchungText END
      WHERE KbBuchungID = @GegenbuchungID
    END

    INSERT INTO KbOpAusgleich(OpBuchungID, OpBuchungPosition, AusgleichBuchungID, KbAusgleichGrundCode, Betrag)
    VALUES (@KbBuchungID, @PosInOPBeleg, @GegenbuchungID, @AusgleichGrund, @AusgleichBetrag)

    

    DECLARE @TotAusgleichBetrag money
    SELECT @TotAusgleichBetrag = SUM(Betrag)
	FROM   KbOpAusgleich
	WHERE  OpBuchungID = @KbBuchungID

    IF @OPIstAusgleichsBuchung = 1 AND @AusgleichGrund IN (5,10,11) BEGIN
      --Storno/Rückläufer/Rücknahme Ausgleich
      IF ABS(@TotAusgleichBetrag) = ABS(@OPBetrag) BEGIN --todo: vorzeichen
        --Storno/Rückläufer/Rücknahme Ausgleich ist komplett (Meldungen kommen zerstückelt an)
        --den Ausgleichsbeleg auf storniert stellen
        UPDATE KbBuchung
        SET    KbBuchungStatusCode = 8 --storniert
        WHERE  KbBuchungID = @KbBuchungID

        --den Status des OPs updaten
        UPDATE KbBuchung
        SET KbBuchungStatusCode = CASE @AusgleichGrund WHEN 10 THEN 9 --Rückläufer
                                                       WHEN 11 THEN 3 --Einnahme ist wieder offen (Rücknahme Ausgleich)
                                                       WHEN  5 THEN 3 --Einnahme/Ausgabe ist wieder offen (wenn der Ausgleichsbeleg storniert wurde)
                                  END
        WHERE KbBuchungID IN
        (
          SELECT OpBuchungID
          FROM KbOpAusgleich
          WHERE AusgleichBuchungID = @KbBuchungID
        )

        -- Nun noch die Gegen-Ausgleiche zum OP erstellen
        INSERT INTO KbOpAusgleich(OpBuchungID, OpBuchungPosition, AusgleichBuchungID, KbAusgleichGrundCode, Betrag)
        SELECT OpBuchungID, OpBuchungPosition, AusgleichBuchungID, @AusgleichGrund, -Betrag
        FROM KbOpAusgleich
        WHERE AusgleichBuchungID = @KbBuchungID

      END
    END
    ELSE BEGIN
      --normaler Ausgleich
      --Status des OPs updaten
      UPDATE KbBuchung
      SET    KbBuchungStatusCode = CASE WHEN (Betrag >= $0.00 AND @TotAusgleichBetrag >= Betrag) /*Einnahmen*/ OR (Betrag <= $0.00 AND @TotAusgleichBetrag <= Betrag) /*Ausgaben*/ THEN 6 /*ausgeglichen*/ 
                                        WHEN @TotAusgleichBetrag = $0.00   THEN CASE WHEN KbBuchungStatusCode IN (3,10,6) THEN 3 ELSE KbBuchungStatusCode END
                                        ELSE 10 /*teilweise ausgeglichen*/
                                   END
	  WHERE  KbBuchungID = @KbBuchungID

      -- Arztrechnung?
      IF EXISTS(SELECT KBU.KbBuchungID
                FROM KbBuchung                  KBU
                  INNER JOIN KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
                  INNER JOIN BgKostenart        BKA ON BKA.KontoNr = CASE WHEN KBK.KontoNr = '150' THEN '751' 
                                                                          WHEN KBK.KontoNr = '151' THEN '752'
                                                                     END
                  INNER JOIN BgPositionsart     BPA ON BPA.BgKostenartID             = BKA.BgKostenartID
                  LEFT  JOIN BgPosition         BPO ON BPO.BgBudgetID                = KBU.BgBudgetID AND 
                                                       BPO.BaPersonID                = KBK.BaPersonID AND
                                                       BPO.BgPositionsartID          = BPA.BgPositionsartID AND
                                                       BPO.Betrag                    = KBK.Betrag AND 
                                                       IsNull(BPO.VerwPeriodeVon,-1) = IsNull(KBK.VerwPeriodeVon,-1) AND 
                                                       IsNull(BPO.VerwPeriodeBis,-1) = IsNull(KBK.VerwPeriodeBis,-1)       --check: bereits Forderung an KK vorhanden? 
                WHERE KBU.KbBuchungID = @KbBuchungID AND KBK.KontoNr IN ('150', '151') AND KBU.KbBuchungStatusCode = 6 /*ausgeglichen*/ AND BPO.BgPositionID IS NULL ) BEGIN --Arztrechnung
        -- es wurde eine Arztrechnung ausbezahlt, das wollen wir sofort von der KK zurück!
        DECLARE @KKBaInstitutionID int,
                @KKName varchar(200),
                @KKForderungKbBuchungID int,
                @KKBgPositionID int

        -- KK bestimmen, an welche die Rechnung geht
        SELECT @KKBaInstitutionID = KVG.BaInstitutionID, @KKName = INS.Name
        FROM KbBuchung                  KBU
          INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID     = KBU.KbBuchungID
          INNER JOIN BgBudget           BUD ON BUD.BgBudgetID      = KBU.BgBudgetID
          INNER JOIN BgBudget           MAB ON MAB.BgFinanzplanID  = BUD.BgFinanzplanID AND MAB.MasterBudget = 1
          INNER JOIN BgPosition         KVG ON KVG.BgBudgetID      = MAB.BgBudgetID AND KVG.BgPositionsartID = 32020 /*KVG*/ AND KVG.BaPersonID = KBK.BaPersonID --KVG im Masterbudget
          LEFT  JOIN BaInstitution      INS ON INS.BaInstitutionID = KVG.BaInstitutionID
        WHERE KBU.KbBuchungID = @KbBuchungID AND KBK.KontoNr IN ('150', '151')

        --Keine KK im FP gefunden, in den Basisdaten (ver)suchen
        IF @KKBaInstitutionID IS NULL BEGIN
          SELECT TOP 1 @KKBaInstitutionID = BKV.BaInstitutionID, @KKName = INS.Name
          FROM BaKrankenversicherung BKV
            LEFT  JOIN BaInstitution INS ON INS.BaInstitutionID = BKV.BaInstitutionID
          WHERE @OPValuta BETWEEN IsNull(BKV.DatumVon,dbo.fnDateSerial(1800,1,1)) AND IsNull(BKV.DatumBis,dbo.fnDateSerial(9999,12,31))
            AND GesetzesGrundlageCode = 1 --KVG
        END

        --Budgetposition erstellen
        INSERT INTO BgPosition(BgBudgetID, BgKategorieCode, BaPersonID, BaInstitutionID, BgPositionsartID, Buchungstext, Betrag, 
                               VerwPeriodeVon, VerwPeriodeBis, FaelligAm, VerwaltungSD, BgBewilligungStatusCode, ErstelltDatum, MutiertDatum)
        SELECT @OPBgBudgetID, 1 /*Einnahmen*/, KBK.BaPersonID, @KKBaInstitutionID, BPA.BgPositionsartID, IsNull(@KKName +': ','') + IsNull(KBK.Buchungstext,'Arztrechnung'), KBK.Betrag,
               KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, KBU.ValutaDatum, 1 /*abgetreten*/, 1, GETDATE(), GETDATE()
        FROM KbBuchungKostenart     KBK
          INNER JOIN KbBuchung      KBU ON KBU.KbBuchungID   = KBK.KbBuchungID
          INNER JOIN BgKostenart    BKA ON BKA.KontoNr = CASE WHEN KBK.KontoNr = '150' THEN '751' 
                                                              WHEN KBK.KontoNr = '151' THEN '752'
                                                         END
          INNER JOIN BgPositionsart BPA ON BPA.BgKostenartID = BKA.BgKostenartID
        WHERE KBK.KbBuchungID = @KbBuchungID
        SET @KKBgPositionID = SCOPE_IDENTITY()

        --Budgetposition auf grün stellen - auf gut Glück. Falls zB Debitor fehlt, muss Sozi ergänzen und manuell auf grün stellen
        BEGIN TRY
          EXEC spWhBudget_CreateKbBuchung @OPBgBudgetID, @OPErstelltUserID, 0, 0, @KKBgPositionID
        END TRY
        BEGIN CATCH
        END CATCH
/*
select 'KKPosition',*
from BgPosition--KbBuchungKostenart
where bgpositionid = @KKBgPositionID

select 'KK-KbBuchungKostenart',*
from KbBuchungKostenart
where bgpositionid = @KKBgPositionID
*/
      END -- Arztrechnung
      -- eingegangene vermittelte Alimente (ALV)?
      ELSE IF (EXISTS(SELECT KBU.KbBuchungID
                      FROM KbBuchung                  KBU
                        INNER JOIN KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
                      WHERE KBU.KbBuchungID = @KbBuchungID AND KBK.PositionImBeleg = @PosInOPBeleg AND KBK.KontoNr IN ('920', '921', '922') /*ALV*/ AND KBU.KbBuchungStatusCode IN (6,10) /*(teil-)ausgeglichen*/ )) BEGIN

        DECLARE @AlvAuszahlungKbBuchungID int

        SELECT KbPeriodeID, KBU.FaLeistungID, KBU.IkPositionID, 3 /*automatisch*/, GETDATE(), KBU.ValutaDatum, @AusgleichBetrag, 'Vermittlung: Automatische Auszahlung aus Zahlungseingang', 2 /*freigegeben*/, @KreditorKtoNr, IGL.BaZahlungswegID,
               CASE WHEN IGL.InterneVerrechnung = 1 THEN 105 /*Interne Verrechnung*/ ELSE 101 /*Elektronische Auszahlung*/ END, KRE.PostKontoNummer, KRE.BaBankID, KRE.BankKontoNummer, KRE.IBANNummer,
               LEFT(KRE.PersonNameVorname,100),
               LEFT(KRE.PersonAdressZusatz,200),
               LEFT(KRE.PersonStrasse,100),
               LEFT(KRE.PersonHausNr,10),
               LEFT(KRE.PersonPostfach,40),
               LEFT(KRE.PersonPLZ,10),
               LEFT(KRE.PersonOrt,100),
               KRE.PersonLandCode,
               BgBudgetID, CASE WHEN IGL.InterneVerrechnung = 1 THEN NULL ELSE XLE.Value1 END, KBU.ModulID, Kostenstelle,
               LEFT(KRE.BankName,70), 
               LEFT(KRE.BankStrasse,50), 
               LEFT(KRE.BankPLZ,10), 
               LEFT(KRE.BankOrt,60), 
               LEFT(KRE.BankClearingNr,10), GETDATE(), GETDATE()
        FROM KbBuchung             KBU
          INNER JOIN IkPosition    IKP ON IKP.IkPositionID = KBU.IkPositionID
          INNER JOIN IkGlaeubiger  IGL ON IGL.IkRechtstitelID = IKP.IkRechtstitelID AND IGL.BaPersonID = IKP.BaPersonID
          LEFT  JOIN vwKreditor    KRE ON KRE.BaZahlungswegID = IGL.BaZahlungswegID
          LEFT  JOIN XLOVCode      XLE ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = KRE.EinzahlungsscheinCode
        WHERE KbBuchungID = @KbBuchungID 

        -- Auszahlbuchung erstellen
        INSERT INTO KbBuchung (KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, HabenKtoNr, BaZahlungswegID, 
                               KbAuszahlungsArtCode, PcKontoNr, BaBankID, BankKontoNr, IBAN, BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr, BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, BeguenstigtLandCode,
                               BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, ErstelltDatum, MutiertDatum )
        SELECT KbPeriodeID, KBU.FaLeistungID, KBU.IkPositionID, 3 /*automatisch*/, GETDATE(), KBU.ValutaDatum, @AusgleichBetrag, 'Vermittlung: Automatische Auszahlung aus Zahlungseingang', 2 /*freigegeben*/, @KreditorKtoNr, IGL.BaZahlungswegID,
               CASE WHEN IGL.InterneVerrechnung = 1 THEN 105 /*Interne Verrechnung*/ ELSE 101 /*Elektronische Auszahlung*/ END, KRE.PostKontoNummer, KRE.BaBankID, KRE.BankKontoNummer, KRE.IBANNummer,
               LEFT(KRE.PersonNameVorname,100),
               LEFT(KRE.PersonAdressZusatz,200),
               LEFT(KRE.PersonStrasse,100),
               LEFT(KRE.PersonHausNr,10),
               LEFT(KRE.PersonPostfach,40),
               LEFT(KRE.PersonPLZ,10),
               LEFT(KRE.PersonOrt,100),
               KRE.PersonLandCode,
               BgBudgetID, CASE WHEN IGL.InterneVerrechnung = 1 THEN NULL ELSE XLE.Value1 END, KBU.ModulID, Kostenstelle,
               LEFT(KRE.BankName,70), 
               LEFT(KRE.BankStrasse,50), 
               LEFT(KRE.BankPLZ,10), 
               LEFT(KRE.BankOrt,60), 
               LEFT(KRE.BankClearingNr,10), GETDATE(), GETDATE()
        FROM KbBuchung             KBU
          INNER JOIN IkPosition    IKP ON IKP.IkPositionID = KBU.IkPositionID
          INNER JOIN IkGlaeubiger  IGL ON IGL.IkRechtstitelID = IKP.IkRechtstitelID AND IGL.BaPersonID = IKP.BaPersonID
          LEFT  JOIN vwKreditor    KRE ON KRE.BaZahlungswegID = IGL.BaZahlungswegID
          LEFT  JOIN XLOVCode      XLE ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = KRE.EinzahlungsscheinCode
        WHERE KbBuchungID = @KbBuchungID 

        SELECT @AlvAuszahlungKbBuchungID = SCOPE_IDENTITY()

        INSERT INTO KbBuchungKostenart (KbBuchungID, BgKostenartID, BaPersonID, Buchungstext, Betrag, KontoNr, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, VerwPeriodeVon, VerwPeriodeBis)
        SELECT @AlvAuszahlungKbBuchungID, BKA.BgKostenartID, BaPersonID, KBK.Buchungstext, @AusgleichBetrag, BKA.KontoNr, 1, BKA.Hauptvorgang, BKA.Teilvorgang, BKA.Belegart, VerwPeriodeVon, VerwPeriodeBis
        FROM KbBuchungKostenart  KBK
          INNER JOIN BgKostenart BKA ON BKA.KontoNr = CASE KBK.KontoNr WHEN 920 THEN 620
                                                                       WHEN 921 THEN 621
                                                                       WHEN 922 THEN 622
                                                      END
        WHERE KbBuchungID = @KbBuchungID
/*
--debug
select * from KbBuchung
where kbbuchungid = @AlvAuszahlungKbBuchungID

select * from KbBuchungkostenart
where kbbuchungid = @AlvAuszahlungKbBuchungID
*/

--RAISERROR('ALV gefunden!',18,1)
        
      END
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
  ELSE BEGIN
    SET @Count = 0
    -- Kein Netto- und kein Bruttobeleg, bleiben noch die K-Belege
    DECLARE @OPHabenKonto varchar(10),
            @OPKgBuchungID int,
            @KgBuchungIDOut int,
            @KgPeriodeID int,
            @KgAuszahlungsArtCode int,
            @KontokorrentKontoNr varchar(10),
            @GegenbuchungKgPeriodeID int

    SELECT @Count = Count(*), @KgPeriodeID = SUM(KBU.KgPeriodeID), @OPKgBuchungID = SUM(KgBuchungID), @OPBetrag = SUM(Betrag), @KgAuszahlungsArtCode = SUM(KgAuszahlungsArtCode), @KontokorrentKontoNr = dbo.ConcDistinct(KontoNr), @OPHabenKonto = dbo.ConcDistinct(HabenKtoNr), @OPText = dbo.ConcDistinct(Text)
    FROM KgBuchung       KBU
      INNER JOIN KgKonto KTO ON KTO.KgPeriodeID = KBU.KgPeriodeID AND KgKontoartCode = 1
    WHERE BelegNr = @OPBelegNr
    GROUP BY BelegNr

    IF @Count > 1 BEGIN
      SET @msg = 'Es existieren '+CAST(@Count AS varchar)+' K-Belege mit Belegnummer '+CAST(@OPBelegNr AS varchar)+'! Die Belegnummer müsste eindeutig sein.'
      RAISERROR(@msg,18,1)
    END
    ELSE IF @Count = 0 BEGIN
      SET @msg = 'Es existiert kein Beleg mit Belegnummer '+CAST(@OPBelegNr AS varchar)+'!'
      RAISERROR(@msg,18,1)
    END
    ELSE BEGIN
      IF ABS(@OPBetrag) <> ABS(@AusgleichBetrag) BEGIN
        SET @msg = 'Der Ausgleichsbetrag '+CAST(@AusgleichBetrag AS varchar)+' entspricht nicht dem erwarteten Betrag von '+CAST(@OPBetrag AS varchar)
        RAISERROR(@msg,18,1)
      END
      --ok, Checks erfolgreich bestanden, Ausgleich buchen
      --IF @KgAuszahlungsartCode = 103 BEGIN --Cash
        -- provisorisch, wenn Rückmeldung über MT940 klappt, wird der Ausgleich erst erfolgen, wenn die Zahlung vom Klientenkonto auf das Konto der Stadtkasse erfolgt ist
        --kgOpBeleg.KgBuchungStatusCode = 11; // Barbezug erfolgt (Klient hat Geld abgeholt, es muss aber noch vom Klientenkonto auf das Stadtkassekonto transferiert werden)
        UPDATE KgBuchung
        SET KgBuchungStatusCode = 6, --ausgeglichen
            BarbezugDatum = CASE @KgAuszahlungsArtCode WHEN 103 THEN @AusgleichDatum ELSE BarbezugDatum END
        WHERE KgBuchungID = @KgBuchungID

        SELECT @GegenbuchungKgPeriodeID = GGB.KgPeriodeID
        FROM KgPeriode         ORI
          INNER JOIN KgPeriode GGB ON GGB.FaLeistungID = ORI.FaLeistungID
        WHERE ORI.KgPeriodeID = @KgPeriodeID AND @AusgleichDatum BETWEEN GGB.PeriodeVon AND GGB.PeriodeBis
          AND GGB.KgPeriodeStatusCode = 1 /*aktiv*/

        IF @GegenbuchungKgPeriodeID IS NULL BEGIN
          SET @msg = 'Es existiert keine aktive Buchungsperiode für das Zahlungseingangsdatum ' + CONVERT(varchar, @AusgleichDatum, 104)
          RAISERROR(@msg,18,1)
        END


        -- Gegenbuchung erzeugen
        INSERT INTO KgBuchung(KgPeriodeID, KgBuchungTypCode, KgAusgleichStatusCode, BuchungsDatum, SollKtoNr, HabenKtoNr, Betrag, Text, 
                              ErstelltDatum, MutiertDatum, KgBuchungStatusCode, TransferDatum, ValutaDatum)
        VALUES     (@GegenbuchungKgPeriodeID, 3, 3, @AusgleichDatum, @OPHabenKonto, @KontokorrentKontoNr, @AusgleichBetrag, @OPText, GETDATE(), GETDATE(), 6, NULL, @AusgleichBetrag)
        SET         @KgBuchungIDOut = SCOPE_IDENTITY()

        INSERT INTO KgOpAusgleich( OpBuchungID, AusgleichBuchungID, Betrag )
        VALUES                   (@OPKgBuchungID, @KgBuchungIDOut, @AusgleichBetrag)

      --END
    END
  END

  --ROLLBACK
  UPDATE PscdAusgleich
  SET Verarbeitet = 1
  WHERE PscdAusgleichID = @PscdAusgleichID

  COMMIT
END TRY
BEGIN CATCH  
  ROLLBACK

  SET @msg = 'Line ' + CAST(ERROR_LINE() AS varchar) + ': ' + ERROR_MESSAGE()
  UPDATE PscdAusgleich
  SET Fehlermeldung = @msg
  WHERE PscdAusgleichID = @PscdAusgleichID

  RAISERROR(@msg,18,1)
END CATCH

