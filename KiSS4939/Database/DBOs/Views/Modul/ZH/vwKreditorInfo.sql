SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKreditorInfo
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwKreditorInfo.sql $
  $Author: Mmarghitola $
  $Modtime: 21.09.10 15:19 $
  $Revision: 10 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwKreditorInfo.sql $
 * 
 * 9     23.09.10 21:55 Mmarghitola
 * #6587: Kleine Verbesserungen
 * 
 * 8     20.09.10 18:56 Mmarghitola
 * #6147: Änderungen Klientenkontoabrechnung, Optimierungen (#6015)
 * 
 * 7     30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 6     18.01.10 13:01 Mminder
 * #4644: Bereinigung nach Diskussion mit Nicolas
 * 
 * 5     18.01.10 12:48 Mminder
 * #4644: Änderung an BaBank in Release integriert
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     1.12.09 14:03 Nweber
 * #4644: Fehlermeldung wenn eine Bank eine neue ClearingNr hat.
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwKreditorInfo]
AS
SELECT
      BaZahlungswegID       = ZAL.BaZahlungswegID,
      EinzahlungsscheinCode = ZAL.EinzahlungsscheinCode,
      BaPersonID            = ZAL.BaPersonID,
      BaInstitutionID       = ZAL.BaInstitutionID,
      BaBankID              = ZAL.BaBankID,
      PCKontoNr             = ZAL.PostKontoNummer,
      BankKontoNr           = ZAL.BankKontoNummer,
      IBAN                  = ZAL.IBANNummer,
      ESRTeilnehmer         = ZAL.ESRTeilnehmer,
      BankName              = ISNULL(BNK.Name, BNK2.Name),
      BankStrasse           = ISNULL(BNK.Strasse, BNK2.Strasse),
      BankPLZ               = ISNULL(BNK.PLZ, BNK2.PLZ),
      BankOrt               = ISNULL(BNK.Ort, BNK2.Ort),
      Bank_BCN              = ISNULL(BNK.ClearingNr, BNK2.ClearingNr),
      Name = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseName 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseName
        WHEN ZAL.BaPersonID IS NULL THEN INS.Name
        ELSE PRS.NameVorname
      END,
      Name2 = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseName2 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseName2
        WHEN ZAL.BaPersonID IS NULL THEN INS.AdressZusatz
        ELSE PRS.WohnsitzAdressZusatz
      END,
      StrasseHausNr = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseStrasse 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseStrasse + IsNull(' ' + ZAL.AdresseHausNr, '')
        WHEN ZAL.BaPersonID IS NULL THEN INS.StrasseHausNr
        ELSE PRS.WohnsitzStrasseHausNr
      END,
      Strasse = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseStrasse 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseStrasse
        WHEN ZAL.BaPersonID IS NULL THEN INS.Strasse
        ELSE PRS.WohnsitzStrasse
      END,
      HausNr = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseHausNr 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseHausNr
        WHEN ZAL.BaPersonID IS NULL THEN INS.HausNr
        ELSE PRS.WohnsitzHausNr
      END,
      PLZ = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdressePLZ 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdressePLZ
        WHEN ZAL.BaPersonID IS NULL THEN INS.PLZ
        ELSE PRS.WohnsitzPLZ
      END,
      Ort = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseOrt 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseOrt
        WHEN ZAL.BaPersonID IS NULL THEN INS.Ort
        ELSE PRS.WohnsitzOrt
      END,
      Postfach = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdressePostfach
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdressePostfach
        WHEN ZAL.BaPersonID IS NULL THEN INS.Postfach
        ELSE PRS.WohnsitzPostfach
      END,
      LandCode = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseLandCode 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseLandCode
        WHEN ZAL.BaPersonID IS NULL THEN INS.LandCode
        ELSE PRS.WohnsitzLandCode
      END,
      Auszahlungsart = XLE.Value1,
      AuszahlungsartText = XLE.ShortText,
      KreditorMehrZeilig         = CASE
                                   WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL
                                        THEN ZAL.AdresseName + char(13) + char(10) +
                                             IsNull(ZAL.AdresseName2 + char(13) + char(10), '') +
                                             IsNull(ZAL.AdressePostfach + char(13) + char(10), '') +
                                             IsNull(ZAL.AdresseStrasse + IsNull(' ' + ZAL.AdresseHausNr, '') + char(13) + char(10), '') +
                                             ZAL.AdressePLZ + ' ' + ZAL.AdresseOrt
                                   WHEN PRS.BaPersonID IS NOT NULL
                                        THEN PRS.NameVorname + char(13) + char(10) + PRS.WohnsitzMehrzeilig
                                   ELSE INS.Name + char(13) + char(10) + INS.AdresseMehrzeilig
                                   END
    FROM dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED)
      LEFT OUTER JOIN dbo.BaBank BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = Zal.BaBankID AND ZAL.PostKontoNummer IS NULL
      LEFT JOIN dbo.BaBank BNK2 WITH (READUNCOMMITTED) ON BNK2.ClearingNr = '9000' /*Postfinance*/ AND ZAL.PostKontoNummer IS NOT NULL
      LEFT OUTER JOIN dbo.vwPerson2      PRS ON PRS.BaPersonID      = ZAL.BaPersonID
      LEFT OUTER JOIN dbo.vwInstitution2 INS ON INS.BaInstitutionID = ZAL.BaInstitutionID
      LEFT OUTER JOIN dbo.XLOVCode      XLE WITH (READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = ZAL.EinzahlungsscheinCode
