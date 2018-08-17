SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgBudget_KgBuchung_Create
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH_Branches/KiSS4233_MASTER_ZH/Stored Procedures/spKgBudget_KgBuchung_Create.sql $
  $Author: Rstahel $
  $Modtime: 13.09.10 10:00 $
  $Revision: 9 $
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
  $Log: /Database/KiSS4_MASTER_ZH_Branches/KiSS4233_MASTER_ZH/Stored Procedures/spKgBudget_KgBuchung_Create.sql $
 * 
 * 9     13.09.10 10:43 Rstahel
 * #6459: Beim Erstellen der K-Buchung wird nun die Kreditoren-Information
 * (aus der View vwKreditor) ausgelesen und nicht mehr selber via Zahlweg
 * aus Institution resp. Person rekonstruiert. Damit kommt nun der
 * Begünstigen-Text in jedem Fall korrekt heraus.
 * 
 * 7     12.08.10 15:25 Mmarghitola
 * #6331: Concurrency Violations verhindern
 * 
 * 6     23.03.10 8:47 Mmarghitola
 * #5612: Korrektur Anzeigetext
 * 
 * 5     17.02.10 16:14 Mmarghitola
 * #5612: Limite für Barbezüge
 * 
 * 4     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 3     29.06.09 1:27 Rstahel
 * #4712: Weitere Bugfixes
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKgBudget_KgBuchung_Create]
 (@KgBudgetID   int, -- not null
  @KgPositionID int, -- optional
  @UserID int,
  @AuchInGesperrteBudgets bit)       -- Falls 1, wird die Buchung auch in einem roten (gesperrten) Budget erstellt, die Buchung wird aber ebenfalls gesperrt (Status 7)
AS BEGIN

  DECLARE @KgPeriodeID       int,
          @KreditorKtoNr     varchar(10),
          @DebitorKtoNr      varchar(10),
          @KgMasterBudgetID  int,
          @BudgetMonat       int,
          @BudgetJahr        int,
          @FaLeistungID      int,
          @BaPersonID        int,
          @KgBewilligungCode int,
          @BuchungDatum      datetime,
          @BuchungDatumMin   datetime,
          @BuchungDatumMax   datetime,
          @PositionCount     int,
          @msg               varchar(200),
          @KgBuchungStatusCode int

  IF NOT( @@TRANCOUNT > 0) BEGIN
    -- Das Transaktionshandling wird vom Client durchgeführt (weniger fehleranfällig)
    RAISERROR('Keine Transaktion offen. spKgBudget_KgBuchung_Create darf nur innerhalb einer Transaktion durchgeführt werden', 15, 1)
    RETURN -2
  END

  IF @KgBudgetID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @KgBudgetID ist null!', 18, 1)
    RETURN -1
  END

  IF NOT EXISTS (SELECT 1 FROM dbo.KgBudget WHERE KgBudgetID = @KgBudgetID) BEGIN
    RAISERROR ('Das Monatsbudget mit der ID %d existiert nicht!', 18, 1, @KgBudgetID)
    RETURN -1
  END

  -- Get properties of Monatsbudget
  SELECT @KgBewilligungCode = BDG.KgBewilligungCode,
         @KgMasterBudgetID  = BDG.KgMasterBudgetID,
         @BudgetMonat       = BDG.Monat,
         @BudgetJahr        = BDG.Jahr,
         @FaLeistungID      = LEI.FaLeistungID,
         @BaPersonID        = LEI.BaPersonID
  FROM   dbo.KgBudget BDG
         INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = BDG.FaLeistungID
  WHERE  KgBudgetID = @KgBudgetID

  IF (@KgMasterBudgetID IS NULL) BEGIN
    RAISERROR ('Dieses Budget ist ein Masterbudget !', 18, 1)
    RETURN -1
  END

  IF @KgPositionID IS NOT NULL BEGIN
	IF EXISTS (SELECT 1 FROM dbo.KgBuchung WHERE KgPositionID = @KgPositionID) BEGIN
      RAISERROR ('Diese Position ist bereits übermittelt an die Buchhaltung)!', 18, 1)
      RETURN -1
    END
    IF (@KgBewilligungCode = 1) BEGIN
      RAISERROR ('Dieses Monatsbudget ist noch nicht freigegeben (grau)!', 18, 1)
      RETURN -1
    END
  END ELSE IF (@KgBewilligungCode = 5) BEGIN
    RAISERROR ('Dieses Monatsbudget ist bereits zur Zahlung freigegeben (grün)!', 18, 1)
    RETURN -1
  END

  SET @KgBuchungStatusCode = 2  -- Im Normalfall bekommt die neue Buchung den Status Freigegeben = 2
  
  IF (@KgBewilligungCode = 9) BEGIN -- Gesperrtes Budget
    IF @AuchInGesperrteBudgets = 1 BEGIN
      SET @KgBuchungStatusCode = 7  -- Buchung wird trotz gesperrtem Budget erstellt. Wir müssen aber den Status der neuen Buchung auf Gesperrt = 7 setzen
    END ELSE BEGIN
      RAISERROR ('Dieses Monatsbudget ist gesperrt!', 18, 1)
      RETURN -1
    END
  END

  /************************************************************************************************/
  /* Check Konsistenz                                                                           */
  /************************************************************************************************/
  DECLARE @COUNT int

  IF @KgPositionID IS NULL BEGIN
    -- Bereits verbuchte Buchungen
    SELECT @COUNT = COUNT(*)
    FROM dbo.KgBuchung BUC
      INNER JOIN dbo.KgPosition POS ON POS.KgPositionID = BUC.KgPositionID
    WHERE  POS.KgBudgetID = @KgBudgetID

    IF (@COUNT > 0) BEGIN
      RAISERROR ( 'Für dieses Budget gibt es bereits verbuchte Buchungen!', 18, 1)
      RETURN -1
    END

    -- maximale Anzahl grüner Budgets in der Zukunft: 6
    SELECT @COUNT = COUNT(*)
    FROM dbo.KgBudget BDG
      INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = BDG.FaLeistungID
    WHERE  LEI.BaPersonID = @BaPersonID AND
           BDG.KgMasterBudgetID IS NOT NULL AND
           BDG.KgBewilligungCode IN (5,9) AND
           dbo.fnDateSerial(BDG.Jahr,BDG.Monat,1) >= GetDate()

    IF (@COUNT >= 6) BEGIN
      RAISERROR ( 'Es dürfen nur 6 Monatsbudget im Voraus auf grün gestellt werden!', 18, 1)
      RETURN -1
    END

/*
  END ELSE BEGIN
	Regel deaktiviert 18.12.2007 - sozbus, sozsmm
    IF EXISTS (SELECT 1 FROM KgPosition 
               WHERE KgPositionID = @KgPositionID AND
                     (@BudgetMonat <> MONTH(BuchungDatum) OR
                     @BudgetJahr <> YEAR(BuchungDatum)))
    BEGIN
      RAISERROR ( 'Das Buchungsdatum dieser Position liegt ausserhalb des Budgetmonats!', 18, 1)
      RETURN -1
    END
*/
  END

  /************************************************************************************************/
  /* Buchungsperiode bestimmen                                                                    */
  /************************************************************************************************/

  IF @KgPositionID IS NULL BEGIN
    SELECT @BuchungDatumMin = MIN(BuchungDatum),
           @BuchungDatumMax = MAX(BuchungDatum),
           @PositionCount   = COUNT(*)
    FROM dbo.KgPosition
	  WHERE KgBudgetID = @KgBudgetID

    IF @PositionCount > 0 BEGIN
      SELECT TOP 1 @KgPeriodeID = KgPeriodeID
      FROM dbo.KgPeriode
      WHERE  FaLeistungID = @FaLeistungID AND
             KgPeriodeStatusCode = 1 AND
             @BuchungDatumMin >= PeriodeVon AND
             @BuchungDatumMax <= PeriodeBis

      IF @KgPeriodeID IS NULL BEGIN
        SET @msg = 'Bitte bei Perioden (K) eine neue Buchungsperiode erfassen (F5)!'
        RAISERROR (@msg, 18, 1)
        RETURN -1
      END
    END ELSE BEGIN
      SELECT TOP 1 @KgPeriodeID = KgPeriodeID
      FROM dbo.KgPeriode
      WHERE FaLeistungID = @FaLeistungID AND
            KgPeriodeStatusCode = 1 AND
            dbo.fnDateSerial(@BudgetJahr,@BudgetMonat,1) BETWEEN PeriodeVon AND PeriodeBis

      IF @KgPeriodeID IS NULL BEGIN
        SET @msg = 'Bitte bei Perioden (K) eine neue Buchungsperiode erfassen (F5)!'
        RAISERROR (@msg, 18, 1)
        RETURN -1
      END
    END
  END ELSE BEGIN
    SELECT @BuchungDatum = BuchungDatum
    FROM dbo.KgPosition
	WHERE  KgPositionID = @KgPositionID

    SELECT @KgPeriodeID = KgPeriodeID
    FROM dbo.KgPeriode
    WHERE  FaLeistungID = @FaLeistungID AND
           KgPeriodeStatusCode = 1 AND
           @BuchungDatum BETWEEN PeriodeVon AND DateAdd(s,-1,DateAdd(d,1,PeriodeBis))

    IF (@KgPeriodeID IS NULL) BEGIN
      SET @msg = 'Bitte bei Perioden (K) eine neue Buchungsperiode erfassen (F5)!'
      RAISERROR (@msg, 18, 1)
      RETURN -1
    END
  END

  /************************************************************************************************/
  /* Spezialkonti bestimmen                                                                       */
  /************************************************************************************************/

  SELECT TOP 1 @KreditorKtoNr = KontoNr
  FROM dbo.KgKonto
  WHERE KgPeriodeID = @KgPeriodeID AND
        KgKontoartCode = 3 -- kreditor

  IF (@KreditorKtoNr IS NULL) BEGIN
    SET @msg = 'Es ist kein Kreditor-Konto definiert!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  SELECT TOP 1 @DebitorKtoNr = KontoNr
  FROM dbo.KgKonto
  WHERE KgPeriodeID = @KgPeriodeID AND
        KgKontoartCode = 2 -- debitor

  IF (@DebitorKtoNr IS NULL) BEGIN
    SET @msg = 'Es ist kein Debitor-Konto definiert!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  /************************************************************************************************/
  /* Maximaler Barbeleg-Betrag überprüfen                                                                       */
  /************************************************************************************************/
  DECLARE @maxBarBetrag money
  SET @maxBarBetrag = CONVERT(money, dbo.fnXConfig('System\Vormundschaft\MaxBarBezugBetrag', GetDate()))
  IF EXISTS
  (
    SELECT POS.KgPositionID
    FROM   dbo.KgPosition POS
      INNER JOIN dbo.KgPositionValuta VAL ON VAL.KgPositionID = POS.KgPositionID
    WHERE
      POS.KgBudgetID = @KgBudgetID AND
      POS.KgPositionID = IsNull(@KgPositionID,POS.KgPositionID) AND
      POS.KgAuszahlungsArtCode = 103 AND -- Barzahlungen
      @maxBarBetrag < CASE WHEN POS.KgPositionsKategorieCode = 1
                            THEN  FLOOR((POS.Betrag /
                                    (SELECT COUNT(*) FROM dbo.KgPositionValuta WHERE KgPositionID = POS.KgPositionID))* 20.0 + 0.5) / 20.0
                           ELSE
                             POS.Betrag
                           END
  )
  BEGIN
    SET @msg = 'Die Erstellung eines Barbeleges ist nicht möglich. Der Maximalbetrag pro Barbeleg beträgt CHF ' + REPLACE(CONVERT(VARCHAR(40),@maxBarBetrag , 1), ',', '''') + '.'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END


  /************************************************************************************************/
  /* Monatsbudget verbuchen                                                                       */
  /************************************************************************************************/

  INSERT dbo.KgBuchung
         (KgPeriodeID,KgPositionID,KgBuchungTypCode,KgAusgleichStatusCode,BelegNr,BelegNrPos,
          BuchungsDatum,SollKtoNr,HabenKtoNr,Betrag,ValutaDatum,Text,
          KgBuchungStatusCode,BaInstitutionID,BaZahlungswegID,ErstelltUserID,ErstelltDatum,MutiertUserID,MutiertDatum, KgAuszahlungsArtCode,
          MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4,
          BeguenstigtName,BeguenstigtName2,BeguenstigtStrasse,BeguenstigtHausNr,
          BeguenstigtPostfach,BeguenstigtOrt,BeguenstigtPLZ,BeguenstigtLandCode,
          EinzahlungsscheinCode,BaBankID,BankKontoNummer,PostKontoNummer,IBANNummer,ESRTeilnehmer, ESRReferenznummer)
  SELECT KgPeriodeID           = @KgPeriodeID,
         KgPositionID          = POS.KgPositionID,
         KgBuchungTypCode      = 1,
         KgAusgleichStatusCode = 1,
         BelegNr               = CONVERT(varchar,POS.KgPositionID),
         BelegNrPos            = 0,
         BuchungsDatum         = IsNull(CASE KgPositionsKategorieCode  -- TODO: Abklären ob ok so
                                 WHEN 1 THEN POS.BuchungDatum   --Ausgabe Klient
                                 WHEN 2 THEN POS.BuchungDatum   --Ausgabe Dritte
                                 WHEN 3 THEN POS.BuchungDatum   --Einnahme
                                 END, dbo.fnDateSerial(@BudgetJahr,@BudgetMonat,1)),
         SollKtoNr             = CASE KgPositionsKategorieCode
                                 WHEN 1 THEN POS.KontoNr        --Ausgabe Klient
                                 WHEN 2 THEN POS.KontoNr        --Ausgabe Dritte
                                 WHEN 3 THEN @DebitorKtoNr      --Einnahme
                                 END,
         HabenKtoNr            = CASE KgPositionsKategorieCode
                                 WHEN 1 THEN @KreditorKtoNr     --Ausgabe Klient
                                 WHEN 2 THEN @KreditorKtoNr     --Ausgabe Dritte
                                 WHEN 3 THEN POS.KontoNr        --Einnahme
                                 END,
         Betrag                = CASE WHEN POS.KgPositionsKategorieCode = 1
                                 THEN  FLOOR((POS.Betrag /
                                       (SELECT COUNT(*) FROM dbo.KgPositionValuta WHERE KgPositionID = POS.KgPositionID))
                                        * 20.0 + 0.5) / 20.0
                                 ELSE
                                   POS.Betrag
                                 END,
         ValutaDatum           = VAL.Datum,
         Text                  = POS.Buchungstext,
         KgBuchungStatusCode   = @KgBuchungStatusCode,
         BaInstitutionID       = POS.BaInstitutionID,
         BaZahlungswegID       = POS.BaZahlungswegID,
         ErstelltUserID        = @UserID,
         ErstelltDatum         = GetDate(),
         MutiertUserID         = @UserID,
         MutiertDatum          = GetDate(),
         KgAuszahlungsArtCode  = POS.KgAuszahlungsArtCode,
         MitteilungZeile1      = POS.MitteilungZeile1,
         MitteilungZeile2      = POS.MitteilungZeile2,
         MitteilungZeile3      = POS.MitteilungZeile3,
         MitteilungZeile4      = POS.MitteilungZeile4,
         BeguenstigtName       = KRE.Name,
         BeguenstigtName2      = KRE.Name2,
         BeguenstigtStrasse    = KRE.Strasse,
         BeguenstigtHausNr     = KRE.HausNr,
         BeguenstigtPostfach   = KRE.Postfach,
         BeguenstigtOrt        = KRE.Ort,
         BeguenstigtPLZ        = KRE.PLZ,
         BeguenstigtLandCode   = KRE.LandCode,
         EinzahlungsscheinCode = KRE.EinzahlungsscheinCode,
         BaBankID              = KRE.BaBankID,
         BankKontoNummer       = KRE.BankKontoNr,
         PostKontoNummer       = KRE.PCKontoNr,
         IBANNummer            = KRE.IBAN,
         ESRTeilnehmer         = KRE.ESRTeilnehmer,
         ESRReferenznummer     = POS.ReferenzNummer
  FROM              dbo.KgPosition       POS
    INNER JOIN      dbo.KgPositionValuta VAL ON VAL.KgPositionID    = POS.KgPositionID
    LEFT OUTER JOIN dbo.vwKreditorInfo   KRE ON KRE.BaZahlungswegID = POS.BaZahlungswegID
   WHERE POS.KgBudgetID = @KgBudgetID AND
        POS.KgPositionID = IsNull(@KgPositionID,POS.KgPositionID)

  IF @KgPositionID IS NULL
    UPDATE dbo.KgBudget
    SET    KgBewilligungCode = 5  -- 'grün', Bewilligung erteilt
    WHERE  KgBudgetID = @KgBudgetID

  -- Update Timestamps to prevent concurrency conflicts
  UPDATE KgPosition
  SET KgBudgetID = KgBudgetID
  WHERE KgBudgetID = @KgBudgetID AND
        KgPositionID = IsNull(@KgPositionID,KgPositionID)

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
