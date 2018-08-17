SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbBuchung_Update_Zahlungsweg
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbBuchung_Update_Zahlungsweg.sql $
  $Author: Rstahel $
  $Modtime: 30.05.10 22:01 $
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
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbBuchung_Update_Zahlungsweg.sql $
 * 
 * 6     30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 5     17.12.09 13:04 Nweber
 * #4644: Meldung für ungültige Banken angepasst
 * 
 * 4     1.12.09 14:03 Nweber
 * #4644: Fehlermeldung wenn eine Bank eine neue ClearingNr hat.
 * VSS FIRST
=================================================================================================*/

/*
=================================================================================================
Author:      sozheo
Create date: 11.02.2009
Description: Updaten der Tabelle KbBuchung nach Änderungen von Interne Verrechnung und Zahlungsweg
=================================================================================================
History:
11.02.2009 : sozheo : neu erstellt
23.10.2009 : sozheo : KbAuszahlungsArtCode und PSCDZahlwegArt hinzugefügt
=================================================================================================
*/

CREATE PROCEDURE dbo.spKbBuchung_Update_Zahlungsweg
(
  @LeistungID INT
)
AS
BEGIN
  DECLARE
    @KbBuchungID INT,
    @BaPersonID INT,
    @Valuta DATETIME,
    @ForderungCode INT,
    @Intern BIT,
    @BaZahlungswegID INT,
    @IstBarBeleg BIT,
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
    @IstZusatzZahlung BIT,
    @IkInterneVerrechnungID INT,
    @KbAuszahlungsArtCode INT,

    @KreditorMehrZeilig VARCHAR(MAX),
    @ClearingNr VARCHAR(15),
    @ClearingNrNeu VARCHAR(15)

  DECLARE crsBuchgIDs CURSOR FAST_FORWARD FOR
    SELECT 
      B.KbBuchungID, 
      K.BaPersonID, 
      B.ValutaDatum, 
      B.IkForderungArtCode, 
      CONVERT(BIT, CASE WHEN B.KbAuszahlungsArtCode = 103 THEN 1 ELSE 0 END), -- Barbeleg oder nicht
      CONVERT(BIT, CASE WHEN B.IkForderungArtCode IN (13, 14, 15, 32) THEN 1 ELSE 0 END) -- Zusatzzahlung?
    FROM dbo.KbBuchung B
    LEFT JOIN dbo.KbBuchungKostenart K ON K.KbBuchungID = B.KbBuchungID
    WHERE B.FaLeistungID = @LeistungID
      AND B.KbBuchungStatusCode IN (1, 2) -- nur vorbereitete und freigegebene
      AND B.IkForderungArtCode IN (10, 11, 12, 13, 14, 15)  -- alle Zahlungen
  OPEN crsBuchgIDs

  WHILE 1=1 BEGIN
    FETCH NEXT FROM crsBuchgIDs INTO 
      @KbBuchungID, 
      @BaPersonID, 
      @Valuta, 
      @ForderungCode, 
      @IstBarBeleg, 
      @IstZusatzZahlung
    IF @@FETCH_STATUS != 0 BREAK

    SELECT
      @IkInterneVerrechnungID = IkInterneVerrechnungID, 
      @Intern = InterneVerrechnung,
      @BaZahlungswegID = CASE 
        WHEN @ForderungCode IN (10, 11, 12, 31) THEN BaZahlungswegID
        WHEN @ForderungCode IN (13, 14, 15, 32) THEN BaZahlungswegIDZusatz
        ELSE NULL
      END
    FROM dbo.fnIkInterneVerrechnung_Get(@LeistungID, @BaPersonID, @Valuta, 1, 0)

    -- Angaben zum Zahlungsweg holen
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
      @KbAuszahlungsArtCode = Z.KbAuszahlungsArtCode
    FROM dbo.fnBaZahlungswegInfos(@BaZahlungswegID, @IstBarBeleg, @BaPersonID, @Intern) Z 

    SELECT
      @KreditorMehrZeilig        = KRE.KreditorMehrZeilig,
      @ClearingNr                = BNK.ClearingNr,
      @ClearingNrNeu             = BNK.ClearingNrNeu
    FROM dbo.vwKreditorInfo KRE
      LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = KRE.BaBankID
    WHERE KRE.BaZahlungswegID = @BaZahlungswegID

    -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
    IF @ClearingNrNeu IS NOT NULL BEGIN
      SELECT HasErrors = 1,
             ErrorText = 'Der Zahlungsweg mit der ID ' + CONVERT(VARCHAR, @BaZahlungswegID) + 
                         ' hat eine Bank (ClearingNr ' + @ClearingNr + ') mit einer neuen ClearingNr.'  + CHAR(13) + CHAR(10) +
                         'Kreditor:' + CHAR(13) + CHAR(10) +
                         @KreditorMehrZeilig
      RETURN
    END


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

      -- KbAuszahlungsArtCode
      /*
      CASE 
        WHEN @IstBarBeleg = 1 THEN 103
        WHEN @IstZusatzZahlung = 1 THEN 101 
        WHEN @Intern = 1 THEN 105
        ELSE 101
      END,
      */
      KbAuszahlungsArtCode = @KbAuszahlungsArtCode,

      -- PscdZahlwegArt
      PscdZahlwegArt = @PSCDZahlwegArt 
      /*
      CASE 
        WHEN @IstBarBeleg = 1 THEN 'C' 
        WHEN @IstZusatzZahlung = 1 THEN @Glauebiger_Auszahlungsart 
        WHEN @Intern = 0 THEN @Glauebiger_Auszahlungsart 
        ELSE ' ' 
      END
      */
    WHERE KbBuchungID = @KbBuchungID

  END
  CLOSE crsBuchgIDs
  DEALLOCATE crsBuchgIDs

  -- Alles ok
  SELECT 0 AS HasErrors
END

