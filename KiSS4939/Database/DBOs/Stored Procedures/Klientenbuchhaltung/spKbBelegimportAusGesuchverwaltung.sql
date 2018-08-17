SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbBelegimportAusGesuchverwaltung;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Belege aus der Gesuchverwaltung in der Klibu importieren.
    @GvAuszahlungPositionID ID der Auszahlungsposition
    @Belegdatum             Belegdatum
    @KbPeriodeID            ID aktive Geschäftsperiode
    @UserID                 UserID vom Ersteller
  -
  RETURNS:
  -
  TEST:
=================================================================================================*/

CREATE PROCEDURE dbo.spKbBelegimportAusGesuchverwaltung
(
  @GvAuszahlungPositionID INT,
  @Belegdatum             DATETIME,
  @Buchungstext           VARCHAR(200),
  @KbPeriodeID            INT,
  @UserID                 INT,
  @LanguageCode           INT = 1 -- default auf deutsch
)
AS 
BEGIN
  SET XACT_ABORT ON;

  DECLARE @Message VARCHAR(500);
  DECLARE @MaskeName VARCHAR(50);
  SET @MaskeName = 'BelegimportAusGesuchverwaltung';
  
  /************************************************************************************************/
  /* Check parameters                                                                             */
  /************************************************************************************************/
  IF (@GvAuszahlungPositionID IS NULL)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'GvAuszahlungPositionIdIsNull', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;

  IF (@Belegdatum IS NULL)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'BelegdatumIsNull', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;

  IF (@KbPeriodeID IS NULL)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'KbPeriodeIdIsNull', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;
  
  
  /************************************************************************************************/
  /* Init variables                                                                               */
  /************************************************************************************************/
  DECLARE @PeriodeVon DATETIME;
  DECLARE @PeriodeBis DATETIME;
  DECLARE @KontoNr_Kreditor VARCHAR(10);
  DECLARE @PeriodeStatusCode INT;
  DECLARE @KbBuchungID_New INT;
  DECLARE @Belegnummer INT;
  DECLARE @KbBelegkreisCode INT;
  DECLARE @KbBelegkreisID INT;
  DECLARE @ValutaDatum DATETIME;
  DECLARE @ReferenzNummer VARCHAR(50);
  DECLARE @BaZahlungswegID INT;
  DECLARE @Betrag MONEY;
  DECLARE @KontoNr VARCHAR(10);
  DECLARE @BgKostenartID INT;
  DECLARE @BaPersonID INT;
  DECLARE @KbZahlungskontoID INT;
  DECLARE @KbKostenstelleID INT;
  DECLARE @BgSplittingArtCode INT;
  DECLARE @Weiterverrechenbar BIT;
  DECLARE @Quoting BIT;
  DECLARE @MitteilungZeile1 VARCHAR(35);
  DECLARE @MitteilungZeile2 VARCHAR(35);
  DECLARE @MitteilungZeile3 VARCHAR(35);
  DECLARE @MitteilungZeile4 VARCHAR(35);
  DECLARE @BuchungstextKoa VARCHAR(200);
  DECLARE @GvAuszahlungArtCode INT;
  DECLARE @PositionStatusCode INT;
  
  DECLARE @ValutaDatumCount INT;
  DECLARE @ValutaDatumIterator INT;

  DECLARE @ValutaDatumTable TABLE
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    ValutaDatum DATETIME
  );

  DECLARE @BetragVerfuegbar MONEY;
  DECLARE @BetragValuta MONEY;

  DECLARE @KRE_BaBankID INT;
  DECLARE @KRE_BaPersonID INT;
  DECLARE @KRE_BankName VARCHAR(70);
  DECLARE @KRE_BankStrasse VARCHAR(50);
  DECLARE @KRE_BankPLZ VARCHAR(10);
  DECLARE @KRE_BankOrt VARCHAR(50);
  DECLARE @KRE_PCKontoNr VARCHAR(20);
  DECLARE @KRE_BankKontoNr VARCHAR(50);
  DECLARE @KRE_IBAN VARCHAR(50);
  DECLARE @KRE_BeguenstigtName VARCHAR(35);
  DECLARE @KRE_BeguenstigtName2 VARCHAR(35);
  DECLARE @KRE_BeguenstigtStrasse VARCHAR(35);
  DECLARE @KRE_BeguenstigtPLZ VARCHAR(10);
  DECLARE @KRE_BeguenstigtOrt VARCHAR(25);
  DECLARE @KRE_ClearingNr VARCHAR(15);
  DECLARE @KRE_ClearingNrNeu VARCHAR(15);
  DECLARE @KRE_KreditorMehrZeilig VARCHAR(2000);

  SET @KbBelegkreisCode = 11; -- Belegimport Gesuchverwaltung

  --Kreditor-Konto ermitteln
  SELECT @PeriodeVon        = PRD.PeriodeVon,
         @PeriodeBis        = PRD.PeriodeBis,
         @KontoNr_Kreditor  = KTO.KontoNr,
         @PeriodeStatusCode = PRD.PeriodeStatusCode
  FROM dbo.KbPeriode      PRD
    LEFT JOIN dbo.KbKonto KTO ON KTO.KbPeriodeID = PRD.KbPeriodeID
                             AND ',' + KTO.KbKontoartCodes + ',' LIKE '%,30,%' --30: Kreditor
  WHERE PRD.KbPeriodeID = @KbPeriodeID; 

  IF (@PeriodeStatusCode <> 1)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'PeriodeIstNichtAktiv', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;

  --Passt Belegdatum in Periode?
  IF((@BelegDatum NOT BETWEEN @PeriodeVon AND @PeriodeBis) AND @GvAuszahlungArtCode <> 102)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'BelegdatumNichtInPeriode', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;
  
  IF(@KontoNr_Kreditor IS NULL)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'KreditorKontoFehlt', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;
  
  IF EXISTS(SELECT TOP 1 1
            FROM dbo.KbBuchungKostenart WITH (READUNCOMMITTED)
            WHERE GvAuszahlungPositionID = @GvAuszahlungPositionID)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'AuszahlungBeteitsImportiert', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;
  
  -- BelegkreisID von 'Belegimport Gesuchverwaltung' holen
  SELECT @KbBelegkreisID = KbBelegkreisID
  FROM dbo.KbBelegKreis
  WHERE KbPeriodeID = @KbPeriodeID
    AND KbBelegKreisCode = @KbBelegkreisCode;
  
  --------------------------------------------------------------
  -- Details der Position holen
  --------------------------------------------------------------
  SELECT TOP 1
    @BaZahlungswegID     = GAP.BaZahlungswegID,
    @Betrag              = Betrag,
    @ValutaDatum         = ValutaDatum,
    @KontoNr             = KOA.KontoNr,
    @BgKostenartID       = KOA.BgKostenartID,
    @BgSplittingArtCode  = KOA.BgSplittingArtCode,
    @Weiterverrechenbar  = CASE WHEN KOA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
    @Quoting             = KOA.Quoting,
    @BaPersonID          = GES.BaPersonID,
    @KbZahlungskontoID   = FND.KbZahlungskontoID,
    @KbKostenstelleID    = KSP.KbKostenstelleID,
    @MitteilungZeile1    = GAP.MitteilungZeile1,
    @MitteilungZeile2    = GAP.MitteilungZeile2,
    @MitteilungZeile3    = GAP.MitteilungZeile3,
    @MitteilungZeile4    = GAP.MitteilungZeile4,
    @ReferenzNummer      = GAP.ReferenzNummer,
    @BuchungstextKoa     = GAP.BuchungsText,
    @GvAuszahlungArtCode = GAP.GvAuszahlungArtCode,
    @PositionStatusCode  = GAP.GvAuszahlungPositionStatusCode
  FROM dbo.GvAuszahlungPosition            GAP WITH (READUNCOMMITTED)
    INNER JOIN dbo.GvGesuch                GES WITH (READUNCOMMITTED) ON GES.GvGesuchID = GAP.GvGesuchID
    INNER JOIN dbo.GvFonds                 FND WITH (READUNCOMMITTED) ON FND.GvFondsID = GES.GvFondsID
    INNER JOIN dbo.GvPositionsart          GPA WITH (READUNCOMMITTED) ON GPA.GvPositionsartID = GAP.GvPositionsartID
    INNER JOIN dbo.BgKostenart             KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = GPA.BgKostenartID
    LEFT  JOIN dbo.KbKostenstelle_BaPerson KSP WITH (READUNCOMMITTED) ON KSP.BaPersonID = GES.BaPersonID
                                                                     AND @Belegdatum BETWEEN KSP.DatumVon AND ISNULL(KSP.DatumBis, '99990101')
  WHERE GAP.GvAuszahlungPositionID = @GvAuszahlungPositionID;
  
  -- Prüfen ob die Position importiert werden kann
  IF (@PositionStatusCode <> 5) -- Bewilligung erteilt
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'AuszahlungNichtFreigegeben', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;
  
  IF (@GvAuszahlungArtCode NOT IN (101, 102)) -- Elektronische oder papierige Auszahlung
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'AuszahlungNichtElektronischOderPapier', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;  

  IF (@KbKostenstelleID IS NULL)
  BEGIN
    SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'KeineKostenstelle', @LanguageCode);
    RAISERROR (@Message, 18, 1);
    RETURN -1;
  END;

  --------------------------------------------------------------
  -- Kreditor-Daten holen
  --------------------------------------------------------------
  SELECT TOP 1
    @KRE_BaBankID           = KRE.BaBankID,
    @KRE_BaPersonID         = KRE.BaPersonID,
    @KRE_BankName           = KRE.Bankname,
    @KRE_BankStrasse        = KRE.BankStrasse,
    @KRE_BankPLZ            = KRE.BankPLZ,
    @KRE_BankOrt            = KRE.BankOrt,
    @KRE_PCKontoNr          = KRE.PostKontoNummer,
    @KRE_BankKontoNr        = KRE.BankKontoNummer,
    @KRE_IBAN               = KRE.IBANNummer,
    @KRE_BeguenstigtName    = KRE.BeguenstigtName,
    @KRE_BeguenstigtName2   = KRE.BeguenstigtName2,
    @KRE_BeguenstigtStrasse = KRE.BeguenstigtStrasse,
    @KRE_BeguenstigtPLZ     = KRE.BeguenstigtPLZ,
    @KRE_BeguenstigtOrt     = KRE.BeguenstigtOrt,
    @KRE_KreditorMehrZeilig = KRE.KreditorMehrZeilig,
    @KRE_ClearingNr         = KRE.BankClearingNr,
    @KRE_ClearingNrNeu      = BNK.ClearingNrNeu
  FROM dbo.vwKreditor     KRE
    LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = KRE.BaBankID
  WHERE KRE.BaZahlungswegID = @BaZahlungswegID;

  -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
  IF @KRE_ClearingNrNeu IS NOT NULL 
  BEGIN
    DECLARE @ErrorText Varchar(MAX);
    SELECT @ErrorText = dbo.fnGetMLTextFromName(@MaskeName, 'ZahlungswegHatNeueClearungNr', @LanguageCode);
    SET @ErrorText = REPLACE(@ErrorText, '{0}', CONVERT(VARCHAR, @BaZahlungswegID));
    SET @ErrorText = REPLACE(@ErrorText, '{1}', @KRE_ClearingNr);
    SET @ErrorText = REPLACE(@ErrorText, '{2}', @KRE_KreditorMehrZeilig);
    RAISERROR (@ErrorText, 18, 1)
    RETURN -1;
  END;

  --------------------------------------------------------------
  -- Mehrere Valutadaten behandeln
  --------------------------------------------------------------
  INSERT INTO @ValutaDatumTable (ValutaDatum)
    SELECT ValutaDatum = ISNULL(GPV.Datum, GAP.ValutaDatum)
    FROM dbo.GvAuszahlungPosition          GAP WITH (READUNCOMMITTED)
      LEFT JOIN GvAuszahlungPositionValuta GPV WITH (READUNCOMMITTED) ON GPV.GvAuszahlungPositionID = GAP.GvAuszahlungPositionID
    WHERE GAP.GvAuszahlungPositionID = @GvAuszahlungPositionID;

  SET @ValutaDatumCount = @@ROWCOUNT;

  /************************************************************************************************/
  /* Beleg erstellen                                                                              */
  /************************************************************************************************/
  IF (@ValutaDatumCount > 0)
  BEGIN
    -- Loop über Valutadaten
    SET @ValutaDatumIterator = 1;

    -- Betrag aufteilen und auf 0.05 Runden
    SET @BetragValuta = ROUND((@Betrag / @ValutaDatumCount) * 2.0, 1) / 2.0;
    SET @BetragVerfuegbar = @Betrag;

    WHILE (@ValutaDatumIterator <= @ValutaDatumCount)
    BEGIN
      -- Valutadatum holen
      SELECT @ValutaDatum = TMP.ValutaDatum
      FROM @ValutaDatumTable TMP
      WHERE TMP.ID = @ValutaDatumIterator;

      -- Bei der letzten Buchung den Restbetrag verwenden
      IF (@ValutaDatumIterator = @ValutaDatumCount)
      BEGIN
        SET @BetragValuta = @BetragVerfuegbar;
      END;

      -- Betrag vom Total abziehen
      SET @BetragVerfuegbar = @BetragVerfuegbar - @BetragValuta;

      --  Belegnummer ermitteln bei elektronischen Auszahlungen
      IF (@GvAuszahlungArtCode <> 102)
      BEGIN
        EXEC @Belegnummer = dbo.spKbGetBelegNr @KbPeriodeID, @KbBelegkreisCode, NULL;
        IF(@Belegnummer < 0)
        BEGIN
          SELECT @Message = dbo.fnGetMLTextFromName(@MaskeName, 'HatKeineBelegnummer', @LanguageCode);
          RAISERROR (@Message, 18, 1);
          RETURN -1;
        END;
      END;
      
    -- Daten für Papierbelege setzen
    IF(@GvAuszahlungArtCode IN (102))
    BEGIN
      SET @Belegnummer = NULL;
      SET @BelegDatum = NULL;
    END;

      --  KbBuchung erstellen
      INSERT INTO KbBuchung(KbPeriodeID, KbBelegKreisID, BaZahlungswegID, KbZahlungskontoID, KbAuszahlungsArtCode, BelegNr, ErstelltDatum, ErstelltUserID, MutiertDatum, MutiertUserID, 
                            BelegDatum, ValutaDatum, [Text], ReferenzNummer, KbBuchungTypCode, KbBuchungStatusCode, Betrag, SollKtoNr, HabenKtoNr, PCKontoNr, 
                            BankKontoNr, IBAN, BaBankID, BankBCN, BankName, BankStrasse, BankPLZ, BankOrt, 
                            MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4, 
                            BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr, BeguenstigtPostfach, BeguenstigtPLZ, BeguenstigtOrt, BeguenstigtLandCode)
        SELECT
          KbPeriodeID          = @KbPeriodeID,
          KbBelegKreisID       = @KbBelegkreisID,
          BaZahlungswegID      = @BaZahlungswegID, 
          KbZahlungskontoID    = @KbZahlungskontoID,
          KbAuszahlungsArtCode = @GvAuszahlungArtCode, -- Code in GvAuszahlungArt = Code in KbAuszahlungsArt
          BelegNr              = @Belegnummer, 
          ErstelltDatum        = GETDATE(), 
          ErstelltUserID       = @UserID,
          MutiertDatum         = GETDATE(),
          MutiertUserID        = @UserID,
          BelegDatum           = @Belegdatum, 
          ValutaDatum          = @ValutaDatum, 
          [Text]               = @Buchungstext, 
          ReferenzNummer       = @ReferenzNummer, 
          KbBuchungTypCode     = 6,
          KbBuchungStatusCode  = 2, -- freigegeben
          Betrag               = @BetragValuta, 
          SollKtoNr            = NULL, 
          HabenKtoNr           = @KontoNr_Kreditor, 
          PCKontoNr            = @KRE_PCKontoNr, 
          BankKontoNr          = @KRE_BankKontoNr, 
          IBAN                 = @KRE_IBAN, 
          BaBankID             = @KRE_BaBankID, 
          BankBCN              = @KRE_ClearingNr, 
          BankName             = @KRE_BankName, 
          BankStrasse          = @KRE_BankStrasse, 
          BankPLZ              = @KRE_BankPLZ, 
          BankOrt              = @KRE_BankOrt, 
          MitteilungZeile1     = @MitteilungZeile1, 
          MitteilungZeile2     = @MitteilungZeile2, 
          MitteilungZeile3     = @MitteilungZeile3, 
          MitteilungZeile4     = @MitteilungZeile4, 
          BeguenstigtName      = @KRE_BeguenstigtName, 
          BeguenstigtName2     = @KRE_BeguenstigtName2, 
          BeguenstigtStrasse   = @KRE_BeguenstigtStrasse, 
          BeguenstigtHausNr    = NULL, 
          BeguenstigtPostfach  = NULL, 
          BeguenstigtPLZ       = @KRE_BeguenstigtPLZ, 
          BeguenstigtOrt       = @KRE_BeguenstigtOrt, 
          BeguenstigtLandCode  = NULL;
    
      SET @KbBuchungID_New = SCOPE_IDENTITY();    
    
      --  KbBuchungKostenart erstellen
      INSERT INTO dbo.KbBuchungKostenart (KbBuchungID, GvAuszahlungPositionID, BaPersonID, KbKostenstelleID, Betrag, KontoNr, BgKostenartID, 
                                          Buchungstext, VerwPeriodeVon, VerwPeriodeBis, BgSplittingArtCode, Weiterverrechenbar, Quoting)
        SELECT 
          KbBuchungID            = @KbBuchungID_New, 
          GvAuszahlungPositionID = @GvAuszahlungPositionID, 
          BaPersonID             = @BaPersonID, 
          KbKostenstelleID       = @KbKostenstelleID,
          Betrag                 = @BetragValuta, 
          KontoNr                = @KontoNr, 
          BgKostenartID          = @BgKostenartID, 
          Buchungstext           = @BuchungstextKoa,
          VerwPeriodeVon         = NULL, -- TODO
          VerwPeriodeBis         = NULL, 
          BgSplittingArtCode     = @BgSplittingArtCode,
          Weiterverrechenbar     = @Weiterverrechenbar, 
          Quoting                = @Quoting;

      UPDATE dbo.KbBuchung
        SET KbBuchungStatusCode = 13 -- verbucht
      WHERE KbBuchungID = @KbBuchungID_New AND KbAuszahlungsArtCode <> 102;

      SET @ValutaDatumIterator = @ValutaDatumIterator + 1;
    END;
    
    UPDATE dbo.GvAuszahlungPosition
      SET GvAuszahlungPositionStatusCode = 7 -- importiert
    WHERE GvAuszahlungPositionID = @GvAuszahlungPositionID
  END;
END;
GO
