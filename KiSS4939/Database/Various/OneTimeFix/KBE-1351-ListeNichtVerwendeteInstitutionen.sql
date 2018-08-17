/*===============================================================================================
  $Revision: 5$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt eine Liste der nicht verwendeten Zahlungswege -
           gemäss Kommentar von Adreas Fuchs - 22.08.2016 09:27 im Ticket KBE-1351 
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

DECLARE @dateRef AS DATETIME
SET @dateRef = dbo.fnDateSerial(YEAR(GETDATE() ) - 2,1,1);

WITH KbBuchung_CTE (KbBuchungID, KbBuchungDatum, BaZahlungswegID)
AS
(
  SELECT BUC.KbBuchungID,
         KbBuchungDatum = CASE WHEN ZEI.KbZahlungseingangID IS NOT NULL
                               THEN BUC.BelegDatum
                               ELSE CASE WHEN(BUC.BelegDatum >BUC.ValutaDatum) 
                                         THEN BUC.BelegDatum 
                                         ELSE BUC.ValutaDatum 
                                    END
                               END,
        BaZahlungswegID = ZLW.BaZahlungswegID
  FROM dbo.KbBuchung BUC
    LEFT JOIN dbo.BaZahlungsweg ZLW ON ZLW.BaZahlungswegID = BUC.BaZahlungswegID
    LEFT JOIN dbo.KbZahlungseingang ZEI ON ZEI.KbZahlungseingangID = BUC.KbZahlungseingangID
  WHERE ISNULL(ZLW.BaInstitutionID, ZEI.BaInstitutionID) IS NOT NULL
)  

SELECT [Deaktivieren] = '',
       [Institutions-ID] = VI.BaInstitutionID,
       [Institutions-Name] = VI.Name,
       [Institutions-Adresse] = VI.Adresse,
       [Institutions-AnzahlZahlungswege] = (SELECT COUNT(BaZahlungswegID) FROM dbo.BaZahlungsweg WHERE BaInstitutionID = VI.BaInstitutionID ),
       LetzteBuchungID = BUC.KbBuchungID,
       LetzteBuchungDatum = BUC.KbBuchungDatum,
       [Zahlungsweg-DatumVon] = ZLW.DatumVon,
       [Zahlungsweg-DatumBis] = ZLW.DatumBis,        
       [Zahlungsweg-Zahlwegtyp] = dbo.fnLOVText('BgEinzahlungsschein',ZLW.EinzahlungsscheinCode),
       [Zahlungsweg-BankName] = BNK.Name,        
       [Zahlungsweg-BankKontoNummer] = ZLW.BankKontoNummer,
       [Zahlungsweg-IBANNummer] = ZLW.IBANNummer,
       [Zahlungsweg-PostKontoNummer] = ZLW.PostKontoNummer,        
       [Zahlungsweg-ReferenzNummer] = ZLW.ReferenzNummer,
       [Zahlungsweg-Empfaenger] = ZLW.Empfaenger,
       [KoppelungmitKAexterneBerater] = CASE WHEN EXISTS (SELECT TOP 1 1
                                                          FROM  dbo.BaInstitutionKontakt OKO
                                                          WHERE OKO.BaInstitutionID = VI.BaInstitutionID) THEN 'Ja' ELSE 'Nein' END
FROM dbo.vwBaZahlungsweg ZLW
LEFT JOIN dbo.BaBank BNK ON BNK.BaBankID = ZLW.BaBankID
INNER JOIN dbo.vwInstitution VI ON VI.BaInstitutionID = ZLW.BaInstitutionID
OUTER APPLY
(
  SELECT TOP 1 BUC3.KbBuchungID,
               BUC3.KbBuchungDatum,
               BUC3.BaZahlungswegID
  FROM KbBuchung_CTE BUC3 
  WHERE 1=1
    AND BUC3.BaZahlungswegID = ZLW.BaZahlungswegID
    AND BUC3.KbBuchungDatum < @dateRef
  ORDER BY BUC3.KbBuchungDatum DESC
) BUC
WHERE NOT EXISTS (SELECT TOP 1 1 -- Hat Buchungen innerhalb der 2 letzten Jahren
                  FROM KbBuchung_CTE BUC2 
                  WHERE 1=1
                    AND BUC2.BaZahlungswegID = ZLW.BaZahlungswegID
                    AND BUC2.KbBuchungDatum >= @dateRef)
  AND NOT EXISTS(SELECT TOP 1 1 -- Aktive Fall
                 FROM  dbo.BaPerson_BaInstitution PIN
                   INNER JOIN dbo.FaFallPerson FAP ON FAP.BaPersonID = PIN.BaPersonID
                   INNER JOIN dbo.FaLeistung LEI ON LEI.FaFallID = FAP.FaFallID
                 WHERE PIN.BaInstitutionID =  VI.BaInstitutionID
                   AND LEI.ModulID = 2 
                   AND (LEI.DatumBis IS NULL 
                    OR LEI.DatumBis > GETDATE()))    
ORDER BY VI.Name
                
-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
