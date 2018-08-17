SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwZahlungsweg
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwZahlungsweg.sql $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwZahlungsweg.sql $
 * 
 * 4     30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 19.05.2008
Description: Zahlungsweg suchen nur Krediotren-Buchungen
===================================================================================================
Tests:
select * from vwZahlungsweg
===================================================================================================
History:
--------
19.05.2008 : sozheo : neu erstellt
===================================================================================================
*/

CREATE VIEW [dbo].[vwZahlungsweg]
AS

--set rowcount 1000
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
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseName
    WHEN Z.BaPersonID IS NULL THEN I.Name
    ELSE P.NameVorname
  END,
  Glaeubiger_Name2 = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseName2
    WHEN Z.BaPersonID IS NULL THEN I.AdressZusatz
    ELSE P.WohnsitzAdressZusatz
  END,
  Glaeubiger_Strasse = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseStrasse
    WHEN Z.BaPersonID IS NULL THEN I.Strasse
    ELSE P.WohnsitzStrasse
  END,
  Glaeubiger_HausNr = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN NULL
    WHEN Z.BaPersonID IS NULL THEN I.HausNr
    ELSE P.WohnsitzHausNr
  END,
  Glaeubiger_PLZ = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdressePLZ
    WHEN Z.BaPersonID IS NULL THEN I.PLZ
    ELSE P.WohnsitzPLZ
  END,
  Glaeubiger_Ort = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseOrt
    WHEN Z.BaPersonID IS NULL THEN I.Ort
    ELSE P.WohnsitzOrt
  END,
  Glaeubiger_Postfach = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdressePostfach
    WHEN Z.BaPersonID IS NULL THEN I.Postfach
    ELSE P.WohnsitzPostfach
  END,
  Glaeubiger_LandCode = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseLandCode
    WHEN Z.BaPersonID IS NULL THEN I.LandCode
    ELSE P.WohnsitzLandCode
  END,
  Glauebiger_Auszahlungsart = XLE.Value1
FROM dbo.BaZahlungsweg Z WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.BaBank B WITH (READUNCOMMITTED) ON B.BaBankID = CASE
    WHEN Z.BaBankID IS NULL AND Z.PostKontoNummer IS NOT NULL THEN (
      SELECT PB.BaBankID FROM dbo.BaBank PB WITH (READUNCOMMITTED)
      WHERE PB.ClearingNr = '9000' )
    ELSE Z.BaBankID
  END
  LEFT OUTER JOIN dbo.vwPerson P ON P.BaPersonID = Z.BaPersonID
  LEFT OUTER JOIN dbo.vwInstitution I ON I.BaInstitutionID = Z.BaInstitutionID
  LEFT JOIN dbo.XLOVCode XLE WITH (READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = Z.EinzahlungsscheinCode
