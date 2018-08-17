SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbBuchung_Create_AlimVermittelte
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbBuchung_Create_AlimVermittelte.sql $
  $Author: Nweber $
  $Modtime: 14.07.10 10:40 $
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: vermittelte Alimente aus ALVBuffer neu anstossen
    @Param0:   KbBuchungID
    @Param1:   AusgleichBetrag
    @Param2:   KreditorKtoNr
    @Param3:   UserID
  -
  TEST:    EXEC spKbBuchung_Create_AlimVermittelte -1, 0, '2000', -1
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbBuchung_Create_AlimVermittelte.sql $
 * 
 * 15    14.07.10 11:35 Nweber
 * #6064: Spalte KbPeriodeID von der Tabelle KbBuchungKostenart löschen
 * 
 * 14    30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 13    12.03.10 7:50 Nweber
 * #4534: Bereinigung falscher LA-Nr 912. Analog an LA-Nr 913.
 * 
 * 12    17.12.09 13:04 Nweber
 * #4644: Meldung für ungültige Banken angepasst
 * 
 * 11    11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 10    1.12.09 14:03 Nweber
 * #4644: Fehlermeldung wenn eine Bank eine neue ClearingNr hat.
 * 
 * 9     28.07.09 21:58 Rhesterberg
 * #5077: Daten-Explorer / Alimentenwesen / Buffer leeren / Fehlermeldung
=================================================================================================*/

/*
=================================================================================================
Author:      sozheo
Create date: 06.01.2009
Description: Erstellen von Buchungen für Vermittlung von erhaltenen Alimenten
=================================================================================================
History:
06.01.2009 : sozheo : neu erstellt
14.01.2009 : sozheo : UserID eingebaut
12.02.2009 : sozheo : Zahlungsweg und interne Verrechnung neu aus Tabelle IkInterneVerrechnung
23.02.2009 : sozheo : AuszahlungsartCode und PSCDZahlwegArt neu aus Funktion
27.02.2009 : sozheo : Buchungstext angepasst
04.03.2009 : sozheo : Buchungstext angepasst
11.03.2009 : sozheo : interne Verrehcnung wird auch gespeichert
02.04.2009 : sozheo : Text korrigiert
18.05.2009 : sozheo : #4734: Neues Feld KbBuchungKostenart.PscdKennzeichen befüllen
19.05.2009 : sozheo : #4534: Falsche LAs bei "Verzugszinsen Gläubiger" bereinigen 
27.07.2009 : sozheo : #32: Monatszahlen übergeordnet (ALIM5)
=================================================================================================
*/


CREATE PROCEDURE [dbo].[spKbBuchung_Create_AlimVermittelte]
(
  @KbBuchungID INT,
  @AusgleichBetrag MONEY,
  @KreditorKtoNr VARCHAR(10),
  @UserID INT
)
AS BEGIN

  IF @KbBuchungID IS NULL 
  BEGIN
    RAISERROR('@KbBuchungID ist nicht definiert.', 18, 1)
    RETURN -1
  END

  IF ISNULL(@AusgleichBetrag, 0) = 0
  BEGIN
    RAISERROR('@AusgleichBetrag ist nicht definiert oder ist 0.--.', 18, 1)
    RETURN -2
  END

  IF @KreditorKtoNr IS NULL
  BEGIN
    RAISERROR('@KreditorKtoNr ist nicht definiert', 18, 1)
    RETURN -3
  END


  DECLARE 
    @FaLeistungID INT,
    @BaPersonID INT,
    --@VerwPeriodeDatum DATETIME,
    @BaZahlungswegID INT,
    @IkForderungArtCode INT, 
    @IkForderungArtCodeNeu INT,
    @Today DATETIME,
    @InterneVerrechnung BIT,
    @ErrorZW VARCHAR(200),
    @KbBuchungIDNeu INT,
    @Glaeubiger_BaBankID INT,
    @Glaeubiger_BankName VARCHAR(70),
    @Glaeubiger_BankStrasse VARCHAR(50),
    @Glaeubiger_BankPLZ VARCHAR(10),
    @Glaeubiger_BankOrt VARCHAR(60),
    @Glaeubiger_PCKontoNr VARCHAR(50),
    @Glaeubiger_BankKontoNr VARCHAR(50),
    @Glaeubiger_IBAN VARCHAR(50),
    @Glaeubiger_Bank_BCN VARCHAR(10),
    @Glaeubiger_Name VARCHAR(100),
    @Glaeubiger_Name2 VARCHAR(200),
    @Glaeubiger_Strasse VARCHAR(100),
    @Glaeubiger_HausNr VARCHAR(10),
    @Glaeubiger_PLZ VARCHAR(10),
    @Glaeubiger_Ort VARCHAR(100),
    @Glaeubiger_Postfach VARCHAR(40),
    @Glaeubiger_LandCode INT,
    @PSCDZahlwegArt CHAR(1),
    @KbAuszahlungsArtCode INT,
    @KontoKANeu VARCHAR(10),
    @KontoKA VARCHAR(10), 
    @BgKostenartIDNeu INT,
    @Glauebiger_EinzahlungsscheinCode INT,
    @IstBarBeleg BIT, 
    @IkForderungEinmaligCode INT,
    @Buchungstext VARCHAR(200),
    @IstEinmalig BIT, 
    @IstElternteil BIT, 
    @Verfahrensnummer VARCHAR(20), 
    @VerwPeriodeVon DATETIME,
    @VerwPeriodeBis DATETIME,
    @IkInterneVerrechnungID INT,
    @Mitteilungszeile1 VARCHAR(35),
    @Mitteilungszeile2 VARCHAR(35),
    @FaFallID INT,
    @NameVorname VARCHAR(200),
    @ProzessCode INT,
    @AuszahlungErzeugen BIT,

    @KreditorMehrZeilig VARCHAR(MAX),
    @ClearingNr VARCHAR(15),
    @ClearingNrNeu VARCHAR(15),
    @Message VARCHAR(MAX)



  -- Es ist nie ein Barbeleg
  -- Eingegangene Zahlungen des Schuldners werden immer elektronisch weitergeleitet
  SET @IstBarBeleg = 0

  -- heutiges Datum holen
  SET @Today = GETDATE()

  -- 12.02.2009 : sozheo : neu aus Tabelle IkInterneVerrechnung
  -- FaLeistungID, BaPersonID und ValutaDatum holen
  SELECT 
    @FaLeistungID = B.FaLeistungID,
    @BaPersonID = K.BaPersonID,
    @IkForderungArtCode = B.IkForderungArtCode,
    @IkForderungEinmaligCode = P.IkForderungEinmaligCode,
    @KontoKA = K.KontoNr,
    @IstEinmalig = P.Einmalig, 
    @IstElternteil = G.IstElternteil, 
    @Verfahrensnummer = P.Verfahrensnummer, 
    @VerwPeriodeVon = K.VerwPeriodeVon,
    @VerwPeriodeBis = K.VerwPeriodeBis,
    @FaFallID = L.FaFallID,
    @NameVorname = PRS.NameVorname,
    @ProzessCode = L.FaProzessCode,
    @AuszahlungErzeugen = B.AuszahlungErzeugen
  FROM dbo.KbBuchung B WITH(READUNCOMMITTED)
  LEFT JOIN dbo.KbBuchungKostenart K WITH(READUNCOMMITTED) ON K.KbBuchungID = B.KbBuchungID
  LEFT JOIN dbo.IkPosition P WITH(READUNCOMMITTED) ON P.IkPositionID = B.IkPositionID
  LEFT OUTER JOIN dbo.IkGlaeubiger G WITH(READUNCOMMITTED) ON G.IkGlaeubigerID = (
    -- 07.07.2009 : sozheo : #32: Monatszahlen übergeordnet
    SELECT TOP 1 GX.IkGlaeubigerID FROM dbo.IkGlaeubiger GX WITH(READUNCOMMITTED) 
    LEFT OUTER JOIN dbo.IkRechtstitel RX WITH(READUNCOMMITTED) on RX.IkRechtstitelID = GX.IkRechtstitelID
    WHERE RX.FaLeistungID = P.FaLeistungID
      AND GX.BaPersonID = P.BaPersonID
    -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    ORDER BY case GX.IkGlaeubigerStatusCode WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 ELSE 4 END ASC
  )
  LEFT JOIN dbo.vwPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = G.BaPersonID
  LEFT JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = B.FaLeistungID
  WHERE B.KbBuchungID = @KbBuchungID

  IF NOT @IkForderungArtCode IN (2, 3, 4, 30) 
  BEGIN
    -- Fehler: Vermittelte Zahlungen sind nur zulässig bei Alimente, Kinderzulagen und einmaligen Forderungen
    RAISERROR('Programmfehler: ForderungArtCode ist nicht im zulässigen Bereich.', 18, 1)
    RETURN -4
  END

  SET @KontoKANeu = CASE @KontoKA 
    WHEN '920' THEN '620'
    WHEN '921' THEN '621'
    WHEN '922' THEN '622'
    ELSE NULL
  END

  IF @IstEinmalig = 1 AND @IkForderungEinmaligCode = 13 -- Verzugszinsen Gläubiger
    AND @AuszahlungErzeugen = 1 AND @KontoKA = '913'
    AND @KontoKANeu IS NULL
  BEGIN
    -- 19.05.2009 : sozheo : 
    -- Im Herbst 2008 wurde auf Verzugszinsen Gläubiger (Code 13) irrtümlich LA 913 eingestellt.
    -- Es hat somit viele Beträge, welche nicht vermittelt wurden (weil nur LA 920, 921, 922 vermittelt werden)
    -- Diese Daten werden nun hier abgehandelt:
    -- Zuerst die korrekten Angaben erstellen
    SET @KontoKANeu = '622'
  END

  -- #4534: Das selbe als hier oben aber für KontoNr = 912 und IkFerderungEinmaligCode = 14
  IF @IstEinmalig = 1 AND @IkForderungEinmaligCode = 14 -- Prozessentschädigung Gläubiger
    AND @AuszahlungErzeugen = 1 AND @KontoKA = '912'
    AND @KontoKANeu IS NULL
  BEGIN
    SET @KontoKANeu = '622'
  END


  IF @KontoKANeu IS NULL
  BEGIN
    RAISERROR('Programmfehler: Kontonummer ist nicht im zulässigen Bereich.', 18, 1)
    RETURN -5
  END

  -- ID von BgKostenart holen, damit KbBuchungKostenart korrekt gefüllt werden kann
  SELECT TOP 1 @BgKostenartIDNeu = BgKostenartID 
  FROM dbo.BgKostenart 
  WHERE KontoNr = @KontoKANeu 
    AND ModulID = 4

  -- Kontrolle ID von BgKostenart
  IF @BgKostenartIDNeu IS NULL
  BEGIN
    RAISERROR('Programmfehler: Neue Kontonummer existiert nicht.', 18, 1)
    RETURN -6
  END


  -- 12.02.2009 : sozheo : neu aus Tabelle IkInterneVerrechnung
  -- Zahlungsweg und interne Verrechnung holen
  SELECT
    @IkInterneVerrechnungID = IkInterneVerrechnungID,
    @BaZahlungswegID = BaZahlungswegID,
    @InterneVerrechnung = InterneVerrechnung
  FROM dbo.fnIkInterneVerrechnung_Get(
    @FaLeistungID, 
    @BaPersonID, 
    @VerwPeriodeVon, 
    @IkForderungArtCode, 
    @IkForderungEinmaligCode)


  IF @IkInterneVerrechnungID IS NULL OR @InterneVerrechnung IS NULL
  BEGIN
    -- Fehler: @InterneVerrechnung nicht definiert 
    RAISERROR('Die interne Verrechnung ist nicht definiert.', 18, 1)
    RETURN -7
  END

  IF (@InterneVerrechnung = 0 AND @BaZahlungswegID IS NULL)
  BEGIN
    -- Fehler: kein Zahlungsweg vorhanden, wenn nicht InterneVerrechnung
    RAISERROR('Der Zahlungsweg ist nicht definiert (keine interne Verrechnung).', 18, 1)
    RETURN -8
  END

  SET @ErrorZW = NULL
  IF (@InterneVerrechnung = 0) 
  BEGIN
    -- Kontrolle des Zahlungswegs
    SET @ErrorZW = dbo.fnBaZahlungsweg_Check(@BaZahlungswegID, @Today)
    IF ISNULL(@ErrorZW, '') != '' 
    BEGIN
      RAISERROR(@ErrorZW, 18, 1)
      RETURN -9
    END
  END

 SET @IkForderungArtCodeNeu = @IkForderungArtCode + 100

  -- Buchungstexct holen
  SET @Buchungstext =  dbo.fnKbBuchung_GetBuchungstext_Alim(1, 
    @ProzessCode, @IstEinmalig, @InterneVerrechnung, @IkForderungArtCodeNeu, @IkForderungEinmaligCode,
    @IstElternteil, @Verfahrensnummer, @VerwPeriodeVon, @VerwPeriodeBis)
  IF @Buchungstext IS NULL OR @Buchungstext = '' 
  BEGIN
    RAISERROR('Der Buchungtext darf nicht leer sein (dbo.spKbBuchung_Create_AlimVermittelte).', 18, 1)
    RETURN -10
  END

  -- Mitteilungszeile 1
  SET @Mitteilungszeile1 = dbo.fnKbBuchung_GetMitteilungstext1(@FaFallID, @NameVorname)
  IF @Mitteilungszeile1 IS NULL 
  BEGIN
    RAISERROR('Die erste Mitteilungszeile darf nicht leer sein (dbo.spKbBuchung_Create_AlimVermittelte).', 18, 1)
    RETURN -11
  END

  -- Mitteilungszeile 2
  SET @Mitteilungszeile2 = dbo.fnKbBuchung_GetMitteilungstext2(1, 
    @IstEinmalig, @InterneVerrechnung, @IkForderungArtCodeNeu, @IkForderungEinmaligCode,
    @IstElternteil, @Verfahrensnummer, @VerwPeriodeVon, @VerwPeriodeBis)
  IF @Mitteilungszeile2 IS NULL 
  BEGIN
    RAISERROR('Die zweite Mitteilungszeile darf nicht leer sein (dbo.spKbBuchung_Create_AlimVermittelte).', 18, 1)
    RETURN -12
  END


 

  -- Angaben zum Zahlungsweg holen
  SELECT TOP 1 
    @Glauebiger_EinzahlungsscheinCode = Z.EinzahlungsscheinCode,
    @Glaeubiger_BaBankID = Z.Glaeubiger_BaBankID,
    @Glaeubiger_BankName = Z.Glaeubiger_BankName,
    @Glaeubiger_BankStrasse = Z.Glaeubiger_BankStrasse,
    @Glaeubiger_BankPLZ = Z.Glaeubiger_BankPLZ,
    @Glaeubiger_BankOrt = Z.Glaeubiger_BankOrt,
    @Glaeubiger_PCKontoNr = Z.Glaeubiger_PCKontoNr,
    @Glaeubiger_BankKontoNr = Z.Glaeubiger_BankKontoNr,
    @Glaeubiger_IBAN = Z.Glaeubiger_IBAN,
    @Glaeubiger_Bank_BCN = Z.Glaeubiger_Bank_BCN,
    @Glaeubiger_Name = Z.Glaeubiger_Name,
    @Glaeubiger_Name2 = Z.Glaeubiger_Name2,
    @Glaeubiger_Strasse = Z.Glaeubiger_Strasse,
    @Glaeubiger_HausNr = Z.Glaeubiger_HausNr,
    @Glaeubiger_PLZ = Z.Glaeubiger_PLZ,
    @Glaeubiger_Ort = Z.Glaeubiger_Ort,
    @Glaeubiger_Postfach = Z.Glaeubiger_Postfach,
    @Glaeubiger_LandCode = Z.Glaeubiger_LandCode,
    @PSCDZahlwegArt = Z.PSCDZahlwegArt,
    @KbAuszahlungsArtCode = Z.KbAuszahlungsArtCode
  FROM dbo.fnBaZahlungswegInfos(@BaZahlungswegID, @IstBarBeleg, @BaPersonID, @InterneVerrechnung) Z 

  SELECT
    @KreditorMehrZeilig        = KRE.KreditorMehrZeilig,
    @ClearingNr                = BNK.ClearingNr,
    @ClearingNrNeu             = BNK.ClearingNrNeu
  FROM dbo.vwKreditorInfo KRE
    LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = KRE.BaBankID
  WHERE KRE.BaZahlungswegID = @BaZahlungswegID

  -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
  IF @ClearingNrNeu IS NOT NULL BEGIN
    SET @Message = 'Der Zahlungsweg mit der ID %d hat eine Bank (ClearingNr %s) mit einer neuen ClearingNr.' + CHAR(13) + CHAR(10) +
                   'Kreditor:'+ CHAR(13) + CHAR(10) +
                   '%s'
    RAISERROR (@Message, 18, 1, @BaZahlungswegID, @ClearingNr, @KreditorMehrZeilig)
    RETURN -1
  END

  -- Buchung erstellen
  INSERT INTO dbo.KbBuchung(
    KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, 
    BelegDatum, ValutaDatum, Betrag, 
    [Text], 
    KbBuchungStatusCode, 
    HabenKtoNr, BaZahlungswegID, 
    KbAuszahlungsArtCode, 
    BeguenstigtName, BeguenstigtName2, 
    BeguenstigtStrasse, BeguenstigtHausNr, 
    BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, BeguenstigtLandCode,
    BgBudgetID, 
    PscdZahlwegArt, 
    ModulID, Kostenstelle, 
    BaBankID, BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, 
    PcKontoNr, BankKontoNr, IBAN, 
    ErstelltDatum, MutiertDatum, ErstelltUserID, MutiertUserID,
    MitteilungZeile1, MitteilungZeile2, IkForderungArtCode, KbForderungIstSH
  )
  SELECT 
    KBU.KbPeriodeID, KBU.FaLeistungID, KBU.IkPositionID, 3 /* KbBuchungTypCode = automatisch*/, 
    @Today, @Today, @AusgleichBetrag, 
    -- vorher : 'Vermittlung: Automatische Auszahlung aus Zahlungseingang', 
    @Buchungstext,
    -- KbBuchungStatusCode:
    2, /* freigegeben */ 
    @KreditorKtoNr, 
    @BaZahlungswegID,
    -- KbAuszahlungsArtCode:
    /*CASE WHEN @InterneVerrechnung = 1 
      THEN 105 /* Interne Verrechnung */ 
      ELSE 101 /* Elektronische Auszahlung */ 
    END,*/ 
    @KbAuszahlungsArtCode, 
    -- Gläubiger
    @Glaeubiger_Name,
    @Glaeubiger_Name2,
    @Glaeubiger_Strasse,
    @Glaeubiger_HausNr,
    @Glaeubiger_Postfach,
    @Glaeubiger_Ort,
    @Glaeubiger_PLZ,
    @Glaeubiger_LandCode,
    -- Ist im A eigentlich immer NULL, macht aber nichts:
    KBU.BgBudgetID, 
    -- PscdZahlwegArt:
    @PSCDZahlwegArt, 
    KBU.ModulID, KBU.Kostenstelle,
    -- Bank des Gläubigers
    @Glaeubiger_BaBankID,
    @Glaeubiger_BankName,
    @Glaeubiger_BankStrasse,
    @Glaeubiger_BankPLZ,
    @Glaeubiger_BankOrt,
    @Glaeubiger_Bank_BCN,
    @Glaeubiger_PCKontoNr,
    @Glaeubiger_BankKontoNr,
    @Glaeubiger_IBAN,
    @Today, @Today, @UserID, @UserID, 
    -- Mitteilungszeile 1
    --LEFT('F' + CAST(LEI.FaFallID AS VARCHAR) + ' ' + PRS.NameVorname, 35),
    @Mitteilungszeile1,
    @Mitteilungszeile2,
    @IkForderungArtCodeNeu,
    @InterneVerrechnung
  FROM dbo.KbBuchung KBU WITH(READUNCOMMITTED)
  --LEFT JOIN dbo.IkPosition P WITH(READUNCOMMITTED) ON P.IkPositionID = KBU.IkPositionID
  --INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = @BaPersonID
  --INNER JOIN dbo.FaLeistung LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = KBU.FaLeistungID
  --LEFT JOIN dbo.vwKreditor KRE ON KRE.BaZahlungswegID = @BaZahlungswegID
  --LEFT JOIN dbo.XLOVCode XLE WITH(READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = @Glauebiger_EinzahlungsscheinCode
  WHERE KbBuchungID = @KbBuchungID 

  SELECT @KbBuchungIDNeu = SCOPE_IDENTITY()

  -- Kostenartbuchung erstellen
  INSERT INTO dbo.KbBuchungKostenart(
    KbBuchungID, BgKostenartID, BaPersonID, 
    Buchungstext, Betrag, KontoNr, PositionImBeleg, 
    Hauptvorgang, Teilvorgang, Belegart, VerwPeriodeVon, VerwPeriodeBis,
    PscdKennzeichen)
  SELECT TOP 1 
    @KbBuchungIDNeu, BKA.BgKostenartID, @BaPersonID, 
    KBK.Buchungstext, @AusgleichBetrag, BKA.KontoNr, 1, 
    BKA.Hauptvorgang, BKA.Teilvorgang, BKA.Belegart, KBK.VerwPeriodeVon, KBK.VerwPeriodeBis,
    'C' -- ist immer Kreditor, da diese Beträge immer ausbezahlt werden 
  FROM dbo.KbBuchungKostenart KBK WITH(READUNCOMMITTED)
  LEFT JOIN dbo.BgKostenart BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID = @BgKostenartIDNeu
  WHERE KBK.KbBuchungID = @KbBuchungID

  RETURN @KbBuchungIDNeu

END

