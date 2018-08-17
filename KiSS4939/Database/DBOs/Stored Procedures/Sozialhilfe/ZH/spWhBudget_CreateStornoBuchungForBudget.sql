SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject spWhBudget_CreateStornoBuchungForBudget
GO
/*===============================================================================================
  $Revision: 4$
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

CREATE PROCEDURE dbo.spWhBudget_CreateStornoBuchungForBudget 
 (@BgBudgetID        int,
  @UserID            int,
  @FailIfVerbucht    bit = 1,
  @CreateLockedDocs  bit = 0,
  @BgPositionID      int = NULL) -- 1: für die stornierten Belege neue gesperrte erzeugen (für Budget grün -> rot)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  DECLARE @BgBudgetIDSelect           int,
          @MasterBudget              bit,
          @KbPeriodeID int,
          @COUNT int,
          @BgJahr                    int,
          @BgMonat                   int,
          @msg                       varchar(200)

  IF @BgBudgetID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @BgBudgetID ist null!', 18, 1)
    RETURN -1
  END

  IF @UserID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
    RETURN -1
  END

  IF @UserID NOT IN (SELECT UserID FROM XUser) BEGIN
    RAISERROR ('Es existiert kein User mit ID %d!', 18, 1, @UserID)
    RETURN -1
  END

  SELECT @BgBudgetIDSelect = BgBudgetID, @MasterBudget = MasterBudget FROM BgBudget WHERE BgBudgetID = @BgBudgetID

  IF @BgBudgetIDSelect IS NULL BEGIN
    RAISERROR ('Das Monatsbudget mit der ID %d existiert nicht!', 18, 1, @BgBudgetID)
    RETURN -1
  END

  IF @MasterBudget = 1 BEGIN
    RAISERROR ('Dieses Budget ist ein Masterbudget und kann nicht storniert werden!', 18, 1)
    RETURN -1
  END

  IF( @BgPositionID IS NOT NULL ) BEGIN
    -- Nettobelege aus meheren BgPositionen
    SELECT @Count = Count(*)
    FROM   KbBuchungKostenart
    WHERE  BgPositionID <> @BgPositionID AND KbBuchungID IN
    (
      SELECT KbBuchungID
      FROM   KbBuchungKostenart
      WHERE  BgPositionID = @BgPositionID
    )	

    IF (@Count > 0) BEGIN
      RAISERROR ( 'Für diese Budgetposition gibt es Nettobelege, in die noch andere Budgetpositionen einfliessen! Deshalb kann diese Position nicht separat storniert werden', 18, 1)
      RETURN -1
    END
  END

  /************************************************************************************************/
  /* Check Konsistenz                                                                           */
  /************************************************************************************************/

  -- Bereits ausbezahlte Buchungen
  IF @FailIfVerbucht = 1 BEGIN
    IF @BgPositionID IS NULL BEGIN
      SELECT @COUNT = COUNT(*)
      FROM   KbBuchung
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (6,10)

      SELECT @COUNT = @COUNT + COUNT(*)
      FROM   KbBuchungBrutto
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (6,10)

      IF (@COUNT > 0) BEGIN
        RAISERROR ( 'Für dieses Budget gibt es Buchungen, die nicht mehr storniert werden können!', 18, 1)
        RETURN -1
      END
    END
    ELSE BEGIN
      SELECT @COUNT = COUNT(*)
      FROM   KbBuchung                KBU
        INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
      WHERE  KBK.BgPositionID = @BgPositionID AND KbBuchungStatusCode IN (6,10)

      SELECT @COUNT = @COUNT + COUNT(*)
      FROM   KbBuchungBrutto
      WHERE  BgPositionID = @BgPositionID AND KbBuchungStatusCode IN (6,10)

      IF (@COUNT > 0) BEGIN
        RAISERROR ( 'Für dieses Budget gibt es Buchungen, die nicht mehr storniert werden können!', 18, 1)
        RETURN -1
      END
    END
  END

/*
  -- Gibt es überhaupt Buchungen, die storniert werden müssen?
  SELECT @COUNT = COUNT(*)
  FROM   KbBuchung
  WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (3,4)

  SELECT @COUNT = @COUNT + COUNT(*)
  FROM   KbBuchungBrutto
  WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (3,4)

  IF (@COUNT = 0) BEGIN
    RAISERROR ( 'Für dieses Budget gibt es keine Buchungen, die storniert werden müssen!', 18, 1)
    RETURN -1
  END
*/
  /************************************************************************************************/
  /* Get Monatsbudget properties, Check Stati, validate                                           */
  /************************************************************************************************/
  SELECT --@BgFinanzPlanID          = BBG.BgFinanzPlanID,
         --@MasterBudget            = BBG.MasterBudget,
         --@BgBewilligungStatusCode = BBG.BgBewilligungStatusCode,
         --@RefDate                 = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
         @BgJahr                  = BBG.Jahr,
         @BgMonat                 = BBG.Monat
         --@FAL_BaPersonID          = FAL.BaPersonID,
         --@Person                  = PRS.Name + IsNull(', ' + Vorname,''),
         --@FirstDayInMonth         = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
         --@LastDayInMonth          = dbo.fnLastDayOf(@FirstDayInMonth)

  FROM   BgBudget            BBG
--    INNER JOIN BgFinanzPlan  SFP ON SFP.BgFinanzPlanID = BBG.BgFinanzPlanID
--    INNER JOIN FaLeistung    FAL ON FAL.FaLeistungID   = SFP.FaLeistungID
--    INNER JOIN BaPerson      PRS ON PRS.BaPersonID     = FAL.BaPersonID
  WHERE BBG.BgBudgetID = @BgBudgetID

  /************************************************************************************************/
  /* Buchungsperiode bestimmen                                                                    */
  /************************************************************************************************/
  SELECT @KbPeriodeID = KbPeriodeID
  FROM KbPeriode
  WHERE PeriodeVon <= dbo.fnDateSerial(@BgJahr, @BgMonat, 1) AND PeriodeBis > dbo.fnDateSerial(@BgJahr, @BgMonat, 28)

  IF (@KbPeriodeID IS NULL) BEGIN
    SET @msg = 'Es existiert keine Buchungsperiode, die den ' + CONVERT(varchar, @BgMonat) + '. Monat im Jahr ' + CONVERT(varchar, @BgJahr) + ' beinhaltet!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  /************************************************************************************************/
  /* Bruttobelege stornieren                                                                      */
  /************************************************************************************************/
  -- Stornobelege erzeugen
  INSERT INTO KbBuchungBrutto(KbPeriodeID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, VerwPeriodeVon, VerwPeriodeBis, StorniertKbBuchungBruttoID, BgBudgetID)
    SELECT @KbPeriodeID, 3 /* Storno */, GETDATE(), GETDATE(), GETDATE(), -Betrag, 'storniert Beleg ' + CONVERT(varchar, BelegNr), 2/*freigegeben*/, @UserID, VerwPeriodeVon, VerwPeriodeBis, KbBuchungBruttoID, @BgBudgetID
    FROM   KbBuchungBrutto
    WHERE  BgBudgetID = @BgBudgetID AND IsNull(@BgPositionID, BgPositionID) = BgPositionID AND KbBuchungStatusCode IN (3,4) AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/

  -- Für stornierte Belege neue, gesperrte Belege erzeugen
  IF @CreateLockedDocs = 1 BEGIN
    DECLARE @KbBuchungBruttoIDAlt int,
            @KbBuchungBruttoIDNeu int

    DECLARE cNeueBelege CURSOR FAST_FORWARD FOR
      SELECT KbBuchungBruttoID--KbPeriodeID, BgPositionID, BuchungTypCode, GETDATE(), ValutaDatum, ErfassungsDatum, Betrag, [Text], 7/*gesperrt*/, @UserID, VerwPeriodeVon, VerwPeriodeBis, @BgBudgetID, Geschaeftsjahr
      FROM   KbBuchungBrutto
      WHERE  BgBudgetID = @BgBudgetID AND IsNull(@BgPositionID, BgPositionID) = BgPositionID AND KbBuchungStatusCode IN (3,4) /*verbucht, -mit Warnung*/ AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/


    OPEN cNeueBelege
    WHILE 1=1 BEGIN
      FETCH NEXT FROM cNeueBelege INTO @KbBuchungBruttoIDAlt
      IF @@FETCH_STATUS < 0 BREAK

      -- Buchungskopf einfügen
      INSERT INTO KbBuchungBrutto(KbPeriodeID, BgPositionID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, VerwPeriodeVon, VerwPeriodeBis, BgBudgetID, Geschaeftsjahr)
        SELECT KbPeriodeID, BgPositionID, BuchungTypCode, GETDATE(), ValutaDatum, ErfassungsDatum, Betrag, [Text], 7/*gesperrt*/, @UserID, VerwPeriodeVon, VerwPeriodeBis, @BgBudgetID, Geschaeftsjahr
        FROM   KbBuchungBrutto
        WHERE  KbBuchungBruttoID = @KbBuchungBruttoIDAlt

      SET @KbBuchungBruttoIDNeu = SCOPE_IDENTITY()

      -- Detailpositionen einfügen
      INSERT INTO KbBuchungKostenartBrutto(KbBuchungBruttoID, BgPositionID, KbKontoID, BgKostenartID, BaPersonID, Schuldner_BaInstitutionID, Schuldner_BaPersonID, Buchungstext, Betrag, BetragEffektiv, PositionImBeleg, BaZahlungswegID, PCKontoNr, BankKontoNr, IBAN, KbAuszahlungsartCode, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, Geschaeftsjahr, Valutadatum, Hauptvorgang, Teilvorgang, Belegart, BgKategorieCode, PscdZahlwegArt)
        SELECT @KbBuchungBruttoIDNeu, BgPositionID, KbKontoID, BgKostenartID, BaPersonID, Schuldner_BaInstitutionID, Schuldner_BaPersonID, Buchungstext, Betrag, BetragEffektiv, PositionImBeleg, BaZahlungswegID, PCKontoNr, BankKontoNr, IBAN, KbAuszahlungsartCode, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, Geschaeftsjahr, Valutadatum, Hauptvorgang, Teilvorgang, Belegart, BgKategorieCode, PscdZahlwegArt
        FROM   KbBuchungKostenartBrutto
        WHERE  KbBuchungBruttoID = @KbBuchungBruttoIDAlt

    END
    CLOSE cNeueBelege
    DEALLOCATE cNeueBelege

/*
    INSERT INTO KbBuchungBrutto(KbPeriodeID, BgPositionID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, VerwPeriodeVon, VerwPeriodeBis, BgBudgetID, Geschaeftsjahr)
      SELECT KbPeriodeID, BgPositionID, BuchungTypCode, GETDATE(), ValutaDatum, ErfassungsDatum, Betrag, [Text], 7/*gesperrt*/, @UserID, VerwPeriodeVon, VerwPeriodeBis, @BgBudgetID, Geschaeftsjahr
      FROM   KbBuchungBrutto
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (3,4) AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/
*/    
  END

  -- noch nicht verbuchte Belege sperren
  -- stornierte Belege mit Status 'storniert' versehen
  UPDATE   KBU
  SET      KbBuchungStatusCode = CASE WHEN( STO.KbBuchungBruttoID IS NULL ) THEN CASE @CreateLockedDocs WHEN 1 THEN 7 /*gesperrt*/ ELSE 1 /*vorbereitet*/ END ELSE 8 /*storniert*/ END
  FROM     KbBuchungBrutto     KBU
    LEFT JOIN KbBuchungBrutto  STO ON STO.StorniertKbBuchungBruttoID = KBU.KbBuchungBruttoID
  WHERE    KBU.BgBudgetID = @BgBudgetID AND IsNull(@BgPositionID, KBU.BgPositionID) = KBU.BgPositionID AND KBU.KbBuchungStatusCode IN (1,2,3,4,5) AND KBU.BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/

  /************************************************************************************************/
  /* Nettobelege stornieren                                                                       */
  /************************************************************************************************/
  -- Stornobelege erzeugen
  IF( @BgPositionID IS NULL ) BEGIN
    INSERT INTO KbBuchung(KbPeriodeID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, StorniertKbBuchungID, BgBudgetID)
      SELECT @KbPeriodeID, 3 /* Storno */, GETDATE(), GETDATE(), GETDATE(), -Betrag, 'storniert Beleg ' + CONVERT(varchar, BelegNr), 2, @UserID, KbBuchungID, @BgBudgetID
      FROM   KbBuchung
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (3,4) AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/
--  END
--  ELSE BEGIN
--    INSERT INTO KbBuchung(KbPeriodeID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, StorniertKbBuchungID, BgBudgetID)
--      SELECT @KbPeriodeID, 3 /* Storno */, GETDATE(), GETDATE(), GETDATE(), -Betrag, 'storniert Beleg ' + CONVERT(varchar, BelegNr), 2, @UserID, KbBuchungID, @BgBudgetID
--      FROM   KbBuchung
--      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungID IN (SELECT KbBuchungID FROM KbBuchungKostenart WHERE BgPositionID = @BgPositionID) AND KbBuchungStatusCode IN (3,4) AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/
--  END

  -- Für stornierte Belege neue, gesperrte Belege erzeugen
  IF @CreateLockedDocs = 1 BEGIN
    DECLARE @KbBuchungIDAlt int,
            @KbBuchungIDNeu int

    DECLARE cNeueBelege CURSOR FAST_FORWARD FOR
      SELECT KbBuchungID--KbPeriodeID, BgPositionID, BuchungTypCode, GETDATE(), ValutaDatum, ErfassungsDatum, Betrag, [Text], 7/*gesperrt*/, @UserID, VerwPeriodeVon, VerwPeriodeBis, @BgBudgetID, Geschaeftsjahr
      FROM   KbBuchung
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (3,4) /*verbucht, -mit Warnung*/ AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/


    OPEN cNeueBelege
    WHILE 1=1 BEGIN
      FETCH NEXT FROM cNeueBelege INTO @KbBuchungIDAlt
      IF @@FETCH_STATUS < 0 BREAK

      -- Buchungskopf einfügen
      INSERT INTO KbBuchung(KbPeriodeID, IkForderungBetragID, BuchungTypCode, Code, BelegDatum, ValutaDatum, ErfassungsDatum, Zahlungsfrist, Betrag, BetragEffektiv, DatumEffektiv, [Text], KbBuchungStatusCode, UserID, BaZahlungswegID, PCKontoNr, BankKontoNr, IBAN, KbAuszahlungsartCode, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, Geschaeftsjahr, BgKategorieCode, BgBudgetID, UserIDKasse, PscdZahlwegArt, CashOrCheckAm, Schuldner_BaInstitutionID, Schuldner_BaPersonID, ModulID)
        SELECT KbPeriodeID, IkForderungBetragID, BuchungTypCode, Code, GETDATE(), ValutaDatum, ErfassungsDatum, Zahlungsfrist, Betrag, BetragEffektiv, DatumEffektiv, [Text], 7/*gesperrt*/, UserID, BaZahlungswegID, PCKontoNr, BankKontoNr, IBAN, KbAuszahlungsartCode, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, Geschaeftsjahr, BgKategorieCode, BgBudgetID, UserIDKasse, PscdZahlwegArt, CashOrCheckAm, Schuldner_BaInstitutionID, Schuldner_BaPersonID, ModulID
        FROM   KbBuchung
        WHERE  KbBuchungID = @KbBuchungIDAlt

      SET @KbBuchungIDNeu = SCOPE_IDENTITY()

      -- Detailpositionen einfügen
      INSERT INTO KbBuchungKostenart(KbBuchungID, BgPositionID, KbKontoID, BgKostenartID, BaPersonID, Buchungstext, Betrag, BetragEffektiv, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, VerwPeriodeVon, VerwPeriodeBis, KbForderungArtCode)
        SELECT @KbBuchungIDNeu, BgPositionID, KbKontoID, BgKostenartID, BaPersonID, Buchungstext, Betrag, BetragEffektiv, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, VerwPeriodeVon, VerwPeriodeBis, KbForderungArtCode
        FROM   KbBuchungKostenart
        WHERE  KbBuchungID = @KbBuchungIDAlt

    END
    CLOSE cNeueBelege
    DEALLOCATE cNeueBelege


/*
    INSERT INTO KbBuchung(KbPeriodeID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, 
                BaZahlungswegID, KbAuszahlungsArtCode, PCKontoNr, BankKontoNr, IBAN, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, BgKategorieCode, PscdZahlwegArt ,BgBudgetID, Geschaeftsjahr)
      SELECT KbPeriodeID, BuchungTypCode, GETDATE(), ValutaDatum, ErfassungsDatum, Betrag, [Text], 7, @UserID, 
             BaZahlungswegID, KbAuszahlungsArtCode, PCKontoNr, BankKontoNr, IBAN, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, BgKategorieCode, PscdZahlwegArt ,@BgBudgetID, Geschaeftsjahr
      FROM   KbBuchung
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (3,4) AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/
*/
  END

  -- noch nicht verbuchte Belege sperren
  -- stornierte Belege mit Status 'storniert' versehen
  UPDATE   KBU
  SET      KbBuchungStatusCode = CASE WHEN( STO.KbBuchungID IS NULL ) THEN CASE @CreateLockedDocs WHEN 1 THEN 7 /*gesperrt*/ ELSE 1 /*vorbereitet*/ END ELSE 8 /*storniert*/ END
  FROM     KbBuchung     KBU
    LEFT JOIN KbBuchung  STO ON STO.StorniertKbBuchungID = KBU.KbBuchungID
  WHERE    KBU.BgBudgetID = @BgBudgetID AND KBU.KbBuchungStatusCode IN (1,2,3,4,5) AND KBU.BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/

  END
  ELSE BEGIN
    DECLARE @IDs TABLE(ID int)

    INSERT INTO @IDs
      SELECT KbBuchungID 
      FROM KbBuchungKostenart 
      WHERE BgPositionID = @BgPositionID

    INSERT INTO KbBuchung(KbPeriodeID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, StorniertKbBuchungID, BgBudgetID)
      SELECT @KbPeriodeID, 3 /* Storno */, GETDATE(), GETDATE(), GETDATE(), -Betrag, 'storniert Beleg ' + CONVERT(varchar, BelegNr), 2, @UserID, KbBuchungID, @BgBudgetID
      FROM   KbBuchung
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungID IN (SELECT ID FROM @IDs) AND KbBuchungStatusCode IN (3,4) AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/

  -- Für stornierte Belege neue, gesperrte Belege erzeugen
  IF @CreateLockedDocs = 1 BEGIN
--    DECLARE @KbBuchungIDAlt int,
--            @KbBuchungIDNeu int

    DECLARE cNeueBelege CURSOR FAST_FORWARD FOR
      SELECT KbBuchungID--KbPeriodeID, BgPositionID, BuchungTypCode, GETDATE(), ValutaDatum, ErfassungsDatum, Betrag, [Text], 7/*gesperrt*/, @UserID, VerwPeriodeVon, VerwPeriodeBis, @BgBudgetID, Geschaeftsjahr
      FROM   KbBuchung
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungID IN (SELECT ID FROM @IDs) AND KbBuchungStatusCode IN (3,4) /*verbucht, -mit Warnung*/ AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/


    OPEN cNeueBelege
    WHILE 1=1 BEGIN
      FETCH NEXT FROM cNeueBelege INTO @KbBuchungIDAlt
      IF @@FETCH_STATUS < 0 BREAK

      -- Buchungskopf einfügen
      INSERT INTO KbBuchung(KbPeriodeID, IkForderungBetragID, BuchungTypCode, Code, BelegDatum, ValutaDatum, ErfassungsDatum, Zahlungsfrist, Betrag, BetragEffektiv, DatumEffektiv, [Text], KbBuchungStatusCode, UserID, BaZahlungswegID, PCKontoNr, BankKontoNr, IBAN, KbAuszahlungsartCode, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, Geschaeftsjahr, BgKategorieCode, BgBudgetID, UserIDKasse, PscdZahlwegArt, CashOrCheckAm, Schuldner_BaInstitutionID, Schuldner_BaPersonID, ModulID)
        SELECT KbPeriodeID, IkForderungBetragID, BuchungTypCode, Code, GETDATE(), ValutaDatum, ErfassungsDatum, Zahlungsfrist, Betrag, BetragEffektiv, DatumEffektiv, [Text], 7/*gesperrt*/, UserID, BaZahlungswegID, PCKontoNr, BankKontoNr, IBAN, KbAuszahlungsartCode, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, Geschaeftsjahr, BgKategorieCode, BgBudgetID, UserIDKasse, PscdZahlwegArt, CashOrCheckAm, Schuldner_BaInstitutionID, Schuldner_BaPersonID, ModulID
        FROM   KbBuchung
        WHERE  KbBuchungID = @KbBuchungIDAlt

      SET @KbBuchungIDNeu = SCOPE_IDENTITY()

      -- Detailpositionen einfügen
      INSERT INTO KbBuchungKostenart(KbBuchungID, BgPositionID, KbKontoID, BgKostenartID, BaPersonID, Buchungstext, Betrag, BetragEffektiv, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, VerwPeriodeVon, VerwPeriodeBis, KbForderungArtCode)
        SELECT @KbBuchungIDNeu, BgPositionID, KbKontoID, BgKostenartID, BaPersonID, Buchungstext, Betrag, BetragEffektiv, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, VerwPeriodeVon, VerwPeriodeBis, KbForderungArtCode
        FROM   KbBuchungKostenart
        WHERE  KbBuchungID = @KbBuchungIDAlt

    END
    CLOSE cNeueBelege
    DEALLOCATE cNeueBelege


/*
    INSERT INTO KbBuchung(KbPeriodeID, BuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, 
                BaZahlungswegID, KbAuszahlungsArtCode, PCKontoNr, BankKontoNr, IBAN, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, BgKategorieCode, PscdZahlwegArt ,BgBudgetID, Geschaeftsjahr)
      SELECT KbPeriodeID, BuchungTypCode, GETDATE(), ValutaDatum, ErfassungsDatum, Betrag, [Text], 7, @UserID, 
             BaZahlungswegID, KbAuszahlungsArtCode, PCKontoNr, BankKontoNr, IBAN, ReferenzNummer, ClearingNr, Zahlungsgrund, [Name], Zusatz, Strasse, PLZ, Ort, Dritte, BgKategorieCode, PscdZahlwegArt ,@BgBudgetID, Geschaeftsjahr
      FROM   KbBuchung
      WHERE  BgBudgetID = @BgBudgetID AND KbBuchungStatusCode IN (3,4) AND BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/
*/
  END

  -- noch nicht verbuchte Belege sperren
  -- stornierte Belege mit Status 'storniert' versehen
  UPDATE   KBU
  SET      KbBuchungStatusCode = CASE WHEN( STO.KbBuchungID IS NULL ) THEN CASE @CreateLockedDocs WHEN 1 THEN 7 /*gesperrt*/ ELSE 1 /*vorbereitet*/ END ELSE 8 /*storniert*/ END
  FROM     KbBuchung     KBU
    LEFT JOIN KbBuchung  STO ON STO.StorniertKbBuchungID = KBU.KbBuchungID
  WHERE    KBU.BgBudgetID = @BgBudgetID AND KBU.KbBuchungID IN (SELECT ID FROM @IDs) AND KBU.KbBuchungStatusCode IN (1,2,3,4,5) AND KBU.BuchungTypCode IN (1,2) /*Verbindlichkeit,Forderung*/


  END
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
