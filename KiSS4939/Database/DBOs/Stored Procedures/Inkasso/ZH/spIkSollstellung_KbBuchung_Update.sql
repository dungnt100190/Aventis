SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkSollstellung_KbBuchung_Update
GO
/*===============================================================================================
  $Revision: 6 $
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

CREATE PROCEDURE dbo.spIkSollstellung_KbBuchung_Update 
  -- KbBuchungID:
  @KbBuchungID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON
  
  -- Kontrolle der Parameter:
  IF @KbBuchungID IS NULL RETURN -1

  DECLARE 
    @PscdFehlermeldung VARCHAR(500),
    @IkPositionID INT,
    @IkRechtstitelID INT,
    @BaZahlungswegID INT,
    @KbBuchungStatusCode INT,
    @Glaeubiger_BaPersonID INT,
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
    @Glauebiger_Auszahlungsart VARCHAR(10),

    @OldBaZahlungswegID INT,
    @OldGlaeubiger_BaBankID INT,
    @OldGlaeubiger_BankName VARCHAR(70),
    @OldGlaeubiger_BankStrasse VARCHAR(50),
    @OldGlaeubiger_BankPLZ VARCHAR(10),
    @OldGlaeubiger_BankOrt VARCHAR(60),
    @OldGlaeubiger_PCKontoNr VARCHAR(50),
    @OldGlaeubiger_BankKontoNr VARCHAR(50),
    @OldGlaeubiger_IBAN VARCHAR(50),
    @OldGlaeubiger_Bank_BCN VARCHAR(10),
    @OldGlaeubiger_Name VARCHAR(100),
    @OldGlaeubiger_Name2 VARCHAR(200),
    @OldGlaeubiger_Strasse VARCHAR(100),
    @OldGlaeubiger_HausNr VARCHAR(10),
    @OldGlaeubiger_PLZ VARCHAR(10),
    @OldGlaeubiger_Ort VARCHAR(100),
    @OldGlaeubiger_Postfach VARCHAR(40),
    @OldGlaeubiger_LandCode INT,
    @OldGlauebiger_Auszahlungsart VARCHAR(10),
    @IstZusstzZahlung BIT,
    @Unterstuetzungsfall BIT,
    @ZwBarzahlung1 BIT,
    @PSCDZahlwegArt CHAR(1)


  -- Fehler-Daten holen
  SELECT TOP 1 
    @KbBuchungStatusCode = B.KbBuchungStatusCode,
    @PscdFehlermeldung = B.PscdFehlermeldung,
    @IkPositionID = P.IkPositionID,
    @Glaeubiger_BaPersonID = P.BaPersonID,
    @IkRechtstitelID = P.IkRechtstitelID,
    @OldBaZahlungswegID = B.BaZahlungswegID,
    @OldGlaeubiger_BaBankID = B.BaBankID,
    @OldGlaeubiger_BankName = B.BankName,
    @OldGlaeubiger_BankStrasse = B.BankStrasse,
    @OldGlaeubiger_BankPLZ = B.BankPLZ,
    @OldGlaeubiger_BankOrt = B.BankOrt,
    @OldGlaeubiger_PCKontoNr = B.PCKontoNr,
    @OldGlaeubiger_BankKontoNr = B.BankKontoNr,
    @OldGlaeubiger_IBAN = B.IBAN,
    @OldGlaeubiger_Bank_BCN = B.BankBCN,
    @OldGlaeubiger_Name = B.BeguenstigtName,
    @OldGlaeubiger_Name2 = B.BeguenstigtName2,
    @OldGlaeubiger_Strasse = B.BeguenstigtStrasse,
    @OldGlaeubiger_HausNr = B.BeguenstigtHausNr,
    @OldGlaeubiger_PLZ = B.BeguenstigtPLZ,
    @OldGlaeubiger_Ort = B.BeguenstigtOrt,
    @OldGlaeubiger_Postfach = B.BeguenstigtPostfach,
    @OldGlaeubiger_LandCode = B.BeguenstigtLandCode,
    @OldGlauebiger_Auszahlungsart = B.PscdZahlwegArt,
    @IstZusstzZahlung = CONVERT(BIT, CASE WHEN B.IkForderungArtCode IN (13,14,15,32) THEN 1 ELSE 0 END),
    @Unterstuetzungsfall = CONVERT(BIT, CASE WHEN B.KbAuszahlungsArtCode = 105 THEN 1 ELSE 0 END),
    @BaZahlungswegID = CASE WHEN B.IkForderungArtCode IN (13,14,15,32) 
      THEN IV.BaZahlungswegID_ALBVZusatz
      ELSE IV.BaZahlungswegID_ALBV 
    END,
    @ZwBarzahlung1 = CONVERT(BIT, CASE WHEN B.KbAuszahlungsArtCode = 103 THEN 1 ELSE 0 END) 
  -- Hier kein WITH(READUNCOMMITTED), wir wollen nur committete Buchungen sehen
  FROM dbo.KbBuchung B 
  LEFT JOIN dbo.IkPosition P WITH(READUNCOMMITTED) ON P.IkPositionID = B.IkPositionID
  /*
  LEFT JOIN dbo.IkGlaeubiger G WITH(READUNCOMMITTED) ON G.IkGlaeubigerID = (
    -- 07.07.2009 : sozheo : #32: Monatszahlen übergeordnet
    SELECT TOP 1 GX.IkGlaeubigerID FROM dbo.IkGlaeubiger GX WITH(READUNCOMMITTED) 
    LEFT OUTER JOIN dbo.IkRechtstitel RX WITH(READUNCOMMITTED) on RX.IkRechtstitelID = GX.IkRechtstitelID
    WHERE RX.FaLeistungID = L.FaLeistungID
      AND GX.BaPersonID = F.BaPersonID
    -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    ORDER BY case GX.IkGlaeubigerStatusCode WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 ELSE 4 END ASC
  )
  */
  LEFT JOIN dbo.IkInterneVerrechnung IV ON IV.IkInterneVerrechnungID = (
    SELECT TOP 1 IVX.IkInterneVerrechnungID FROM dbo.IkInterneVerrechnung IVX
    WHERE IVX.FaLeistungID = B.FaLeistungID
      AND IVX.BaPersonID = P.BaPersonID
      AND IVX.DatumVon <= P.Datum
    ORDER BY IVX.DatumVon DESC
  )
  WHERE B.KbBuchungID = @KbBuchungID


  -- Wenn Status nicht 'fehlerhaft'
  IF @KbBuchungStatusCode != 5 RETURN -2
  -- Kontrolle PscdFehlermeldung:
  IF NOT (
    @PscdFehlermeldung LIKE 'Keine ESR-Referenznummer angegeben für%'
  ) RETURN -3


  -- IkPosition nicht gefunden:
  IF @IkPositionID IS NULL RETURN -4
  -- IkRechtstitelID nicht gefunden:
  IF @IkRechtstitelID IS NULL RETURN -5
  -- BaZahlungswegID nicht gefunden:
  IF @BaZahlungswegID IS NULL RETURN -6


  IF @PscdFehlermeldung LIKE 'Keine ESR-Referenznummer angegeben für%' 
  BEGIN
    -- Falscher Zahlungsweg vwerwendet:
    SELECT TOP 1 
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
      @Glauebiger_Auszahlungsart = Z.KbAuszahlungsArtCode
    FROM dbo.fnBaZahlungswegInfos(@BaZahlungswegID, @ZwBarzahlung1, @Glaeubiger_BaPersonID, @Unterstuetzungsfall) Z 


    -- Wenn nichts verändert wird, dann Meldung und zurück
    IF @OldBaZahlungswegID = @BaZahlungswegID
      AND @OldGlaeubiger_BaBankID = @Glaeubiger_BaBankID
      AND @OldGlaeubiger_BankName = @Glaeubiger_BankName
      AND @OldGlaeubiger_BankStrasse = @Glaeubiger_BankStrasse
      AND @OldGlaeubiger_BankPLZ = @Glaeubiger_BankPLZ
      AND @OldGlaeubiger_BankOrt = @Glaeubiger_BankOrt
      AND @OldGlaeubiger_PCKontoNr = @Glaeubiger_PCKontoNr
      AND @OldGlaeubiger_BankKontoNr = @Glaeubiger_BankKontoNr
      AND @OldGlaeubiger_IBAN = @Glaeubiger_IBAN
      AND @OldGlaeubiger_Bank_BCN = @Glaeubiger_Bank_BCN
      AND @OldGlaeubiger_Name = @Glaeubiger_Name
      AND @OldGlaeubiger_Name2 = @Glaeubiger_Name2
      AND @OldGlaeubiger_Strasse = @Glaeubiger_Strasse
      AND @OldGlaeubiger_HausNr = @Glaeubiger_HausNr
      AND @OldGlaeubiger_PLZ = @Glaeubiger_PLZ
      AND @OldGlaeubiger_Ort = @Glaeubiger_Ort
      AND @OldGlaeubiger_Postfach = @Glaeubiger_Postfach
      AND @OldGlaeubiger_LandCode = @Glaeubiger_LandCode
      RETURN -7

    -- Korrekturen speichern
    UPDATE dbo.KbBuchung SET
      BaZahlungswegID = @BaZahlungswegID,
      BaBankID = @Glaeubiger_BaBankID,
      BankName = @Glaeubiger_BankName,
      BankStrasse = @Glaeubiger_BankStrasse,
      BankPLZ = @Glaeubiger_BankPLZ,
      BankOrt = @Glaeubiger_BankOrt,
      PCKontoNr = @Glaeubiger_PCKontoNr,
      BankKontoNr = @Glaeubiger_BankKontoNr,
      IBAN = @Glaeubiger_IBAN,
      BankBCN = @Glaeubiger_Bank_BCN,
      BeguenstigtName = @Glaeubiger_Name,
      BeguenstigtName2 = @Glaeubiger_Name2,
      BeguenstigtStrasse = @Glaeubiger_Strasse,
      BeguenstigtHausNr = @Glaeubiger_HausNr,
      BeguenstigtPLZ = @Glaeubiger_PLZ,
      BeguenstigtOrt = @Glaeubiger_Ort,
      BeguenstigtPostfach = @Glaeubiger_Postfach,
      BeguenstigtLandCode = @Glaeubiger_LandCode,

      -- StatusCode
      KbBuchungStatusCode = 2,
      -- KbAuszahlungsArtCode
      KbAuszahlungsArtCode = @Glauebiger_Auszahlungsart,
      /*
        WHEN @ZwBarzahlung1 = 1 THEN 103
        WHEN @IstZusstzZahlung = 1 THEN 101 
        WHEN @Unterstuetzungsfall = 1 THEN 105
        ELSE 101
      END,*/
      -- PscdZahlwegArt
      PscdZahlwegArt = @PSCDZahlwegArt,
      /* CASE 
        WHEN @ZwBarzahlung1 = 1 THEN 'C' 
        WHEN @IstZusstzZahlung = 1 THEN @Glauebiger_Auszahlungsart 
        WHEN @Unterstuetzungsfall = 0 THEN @Glauebiger_Auszahlungsart 
        ELSE ' ' 
      END,*/
      -- PscdFehlermeldung löschen
      PscdFehlermeldung = NULL
    WHERE KbBuchungID = @KbBuchungID
  END
  RETURN 0
END

GO