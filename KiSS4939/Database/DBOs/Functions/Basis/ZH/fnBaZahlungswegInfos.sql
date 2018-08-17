SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBaZahlungswegInfos
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnBaZahlungswegInfos.sql $
  $Author: Rstahel $
  $Modtime: 30.05.10 22:01 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnBaZahlungswegInfos.sql $
 * 
 * 4     30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 3     11.12.09 10:19 Lloreggia
 * Header aktualisiert, ALTER -> CREATE
 * 
 * 2     28.02.09 4:00 Rhesterberg
 * 
 * 1     10.09.08 12:24 Aklopfenstein
 * VSS FIRST
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: 19.05.2008
Description: Zahlungsweg suchen nur Krediotren-Buchungen
===================================================================================================
Tests:
select top 10 * from BaZahlungsweg
select top 10 * from BaPerson
select * from dbo.fnBaZahlungswegInfos(67996,0,100315)
select * from dbo.fnBaZahlungswegInfos(67996,1,100315)
===================================================================================================
History:
--------
03.06.2008 : sozheo : neu erstellt
23.02.2009 : sozheo : neu mit @IstInterneVerrechnung
23.10.2009 : sozheo : KbAuszahlungsArtCode und PSCDZahlwegArt hinzugefügt
===================================================================================================
*/

CREATE FUNCTION [dbo].[fnBaZahlungswegInfos] (
  @BaZahlungswegID INT,
  @IstBarzahlung BIT,
  @BarzahlungAnBaPersonID INT,
  @IstInterneVerrechnung BIT
)
RETURNS @OUTPUT TABLE (
  BaZahlungswegID INT,
  EinzahlungsscheinCode INT,
  Glaeubiger_BaPersonID INT,
  Glaeubiger_BaInstitutionID INT,
  Glaeubiger_BaBankID INT,
  Glaeubiger_PCKontoNr VARCHAR(50),
  Glaeubiger_BankKontoNr VARCHAR(50),
  Glaeubiger_IBAN VARCHAR(50),
  Glaeubiger_BankName VARCHAR(70),
  Glaeubiger_BankStrasse VARCHAR(50),
  Glaeubiger_BankPLZ VARCHAR(10),
  Glaeubiger_BankOrt VARCHAR(60),
  Glaeubiger_Bank_BCN VARCHAR(10),
  Glaeubiger_Name VARCHAR(100),
  Glaeubiger_Name2 VARCHAR(200),
  Glaeubiger_Strasse VARCHAR(100),
  Glaeubiger_HausNr VARCHAR(10),
  Glaeubiger_PLZ VARCHAR(10),
  Glaeubiger_Ort VARCHAR(100),
  Glaeubiger_Postfach VARCHAR(40),
  Glaeubiger_LandCode INT,
  PSCDZahlwegArt VARCHAR(1),
  KbAuszahlungsArtCode INT  
)
AS BEGIN

  IF @IstInterneVerrechnung = 1
  BEGIN
    -- =========================================
    -- Bei interner Verrechnung
    -- =========================================
    INSERT @OUTPUT
    SELECT
      BaZahlungswegID = NULL,
      EinzahlungsscheinCode = NULL,
      Glaeubiger_BaPersonID = NULL,
      Glaeubiger_BaInstitutionID = NULL,
      Glaeubiger_BaBankID = NULL,
      Glaeubiger_PCKontoNr = NULL,
      Glaeubiger_BankKontoNr = NULL,
      Glaeubiger_IBAN = NULL,
      Glaeubiger_BankName = NULL,
      Glaeubiger_BankStrasse = NULL,
      Glaeubiger_BankPLZ = NULL,
      Glaeubiger_BankOrt = NULL,
      Glaeubiger_Bank_BCN = NULL,
      Glaeubiger_Name = NULL,
      Glaeubiger_Name2 = NULL,
      Glaeubiger_Strasse = NULL,
      Glaeubiger_HausNr = NULL,
      Glaeubiger_PLZ = NULL,
      Glaeubiger_Ort = NULL,
      Glaeubiger_Postfach = NULL,
      Glaeubiger_LandCode = NULL,
      PSCDZahlwegArt = ' ', -- Interne Verrechnung
      KbAuszahlungsArtCode = 105 -- Interne Verrechnung
  END ELSE
  IF @IstBarzahlung = 0
  BEGIN
    -- =========================================
    -- Nicht Barzahlung, normale Auszahlung
    -- =========================================
    INSERT @OUTPUT
    SELECT
      BaZahlungswegID = Z.BaZahlungswegID,
      EinzahlungsscheinCode = Z.EinzahlungsscheinCode,
      Glaeubiger_BaPersonID = Z.BaPersonID,
      Glaeubiger_BaInstitutionID = Z.BaInstitutionID,
      Glaeubiger_BaBankID = Z.BaBankID,
      Glaeubiger_PCKontoNr = Z.PostKontoNummer,
      Glaeubiger_BankKontoNr = Z.BankKontoNummer,
      Glaeubiger_IBAN = Z.IBANNummer,
      Glaeubiger_BankName = B.Name,
      Glaeubiger_BankStrasse = B.Strasse,
      Glaeubiger_BankPLZ = B.PLZ,
      Glaeubiger_BankOrt = B.Ort,
      Glaeubiger_Bank_BCN = B.ClearingNr,
      Glaeubiger_Name = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseName 
        WHEN Z.WMAVerwenden = 0 THEN Z.AdresseName
        WHEN Z.BaPersonID IS NULL THEN I.Name
        ELSE P.NameVorname
      END,
      Glaeubiger_Name2 = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseName2 
        WHEN Z.WMAVerwenden = 0 THEN Z.AdresseName2
        WHEN Z.BaPersonID IS NULL THEN I.AdressZusatz
        ELSE P.WohnsitzAdressZusatz
      END,
      Glaeubiger_Strasse = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseStrasse 
        WHEN Z.WMAVerwenden = 0 THEN Z.AdresseStrasse
        WHEN Z.BaPersonID IS NULL THEN I.Strasse
        ELSE P.WohnsitzStrasse
      END,
      Glaeubiger_HausNr = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseHausNr 
        WHEN Z.WMAVerwenden = 0 THEN Z.AdresseHausNr
        WHEN Z.BaPersonID IS NULL THEN I.HausNr
        ELSE P.WohnsitzHausNr
      END,
      Glaeubiger_PLZ = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdressePLZ 
        WHEN Z.WMAVerwenden = 0 THEN Z.AdressePLZ
        WHEN Z.BaPersonID IS NULL THEN I.PLZ
        ELSE P.WohnsitzPLZ
      END,
      Glaeubiger_Ort = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseOrt 
        WHEN Z.WMAVerwenden = 0 THEN Z.AdresseOrt
        WHEN Z.BaPersonID IS NULL THEN I.Ort
        ELSE P.WohnsitzOrt
      END,
      Glaeubiger_Postfach = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdressePostfach
        WHEN Z.WMAVerwenden = 0 THEN Z.AdressePostfach
        WHEN Z.BaPersonID IS NULL THEN I.Postfach
        ELSE P.WohnsitzPostfach
      END,
      Glaeubiger_LandCode = CASE
        --WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseLandCode 
        WHEN Z.WMAVerwenden = 0 THEN Z.AdresseLandCode
        WHEN Z.BaPersonID IS NULL THEN I.LandCode
        ELSE P.WohnsitzLandCode
      END,
      PSCDZahlwegArt = XLE.Value1,  -- Elektronische Auszahlung
      KbAuszahlungsArtCode = 101 -- Elektronische Auszahlung
    FROM dbo.BaZahlungsweg Z WITH (READUNCOMMITTED)
      LEFT OUTER JOIN dbo.BaBank B WITH (READUNCOMMITTED) ON B.BaBankID = CASE
        WHEN Z.BaBankID IS NULL AND Z.PostKontoNummer IS NOT NULL THEN (
          SELECT PB.BaBankID FROM dbo.BaBank PB WITH (READUNCOMMITTED)
          WHERE PB.ClearingNr = '9000' )
        ELSE Z.BaBankID
      END
      LEFT OUTER JOIN dbo.vwPerson P ON P.BaPersonID = Z.BaPersonID
      LEFT OUTER JOIN dbo.vwInstitution I ON I.BaInstitutionID = Z.BaInstitutionID 
      -- lov BgEinzahlungsschein
      LEFT JOIN dbo.XLOVCode XLE WITH (READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = Z.EinzahlungsscheinCode
    WHERE Z.BaZahlungswegID = @BaZahlungswegID
  END ELSE BEGIN
    -- =========================================
    -- Bei Barzahlung
    -- =========================================
    INSERT @OUTPUT
    SELECT
      BaZahlungswegID = NULL,
      EinzahlungsscheinCode = NULL,
      Glaeubiger_BaPersonID = @BarzahlungAnBaPersonID,
      Glaeubiger_BaInstitutionID = NULL,
      Glaeubiger_BaBankID = NULL,
      Glaeubiger_PCKontoNr = NULL,
      Glaeubiger_BankKontoNr = NULL,
      Glaeubiger_IBAN = NULL,
      Glaeubiger_BankName = NULL,
      Glaeubiger_BankStrasse = NULL,
      Glaeubiger_BankPLZ = NULL,
      Glaeubiger_BankOrt = NULL,
      Glaeubiger_Bank_BCN = NULL,
      Glaeubiger_Name = P.NameVorname,
      Glaeubiger_Name2 = P.WohnsitzAdressZusatz,
      Glaeubiger_Strasse = P.WohnsitzStrasse,
      Glaeubiger_HausNr = P.WohnsitzHausNr,
      Glaeubiger_PLZ = P.WohnsitzPLZ,
      Glaeubiger_Ort = P.WohnsitzOrt,
      Glaeubiger_Postfach = P.WohnsitzPostfach,
      Glaeubiger_LandCode = P.WohnsitzLandCode,
      PSCDZahlwegArt = 'C', -- Cash / Barauszahlung
      KbAuszahlungsArtCode = 103 -- Cash / Barauszahlung
    FROM dbo.vwPerson P
    WHERE P.BaPersonID = @BarzahlungAnBaPersonID
  END

  RETURN
END

GO