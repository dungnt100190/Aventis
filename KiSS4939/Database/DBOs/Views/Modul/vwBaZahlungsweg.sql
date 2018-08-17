SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaZahlungsweg;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Modul/vwBaZahlungsweg.sql $
  $Author: Cjaeggi $
  $Modtime: 15.07.10 19:28 $
  $Revision: 3 $
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
  $Log: /KiSS4/Database/DBOs/Views/Modul/vwBaZahlungsweg.sql $
 * 
 * 3     15.07.10 19:31 Cjaeggi
 * #4167: Fixed BaInstitution.InstitutionName after changes of table
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwBaZahlungsweg
AS
SELECT ZAL.BaZahlungswegID,
       ZAL.BaPersonID,
       ZAL.BaInstitutionID,
       ZAL.DatumVon,
       ZAL.DatumBis,
       ZAL.EinzahlungsscheinCode,
       ZAL.BaBankID,
       ZAL.BankKontoNummer,
       ZAL.IBANNummer,
       ZAL.PostKontoNummer,
       ZAL.ReferenzNummer,
       ZAL.AdresseName,
       ZAL.AdresseName2,
       ZAL.AdresseStrasse,
       ZAL.AdresseHausNr,
       ZAL.AdressePostfach,
       ZAL.AdressePLZ,
       ZAL.AdresseOrt,
       ZAL.AdresseLandCode,
       ZAL.BaZahlwegModulStdCodes,
       ZAL.BaZahlungswegTS,
       --
       [Name]     = CASE 
                      WHEN ZAL.BaPersonID IS NOT NULL THEN ISNULL(PRS.Vorname + ' ', '') + PRS.Name 
                      ELSE INS.[Name] 
                    END,
       Adresse    = CASE 
                      WHEN ZAL.BaPersonID IS NOT NULL THEN PRS.Wohnsitz 
                      ELSE INS.Adresse 
                    END,
       Empfaenger = CASE 
                      WHEN ZAL.BaPersonID IS NOT NULL THEN ISNULL(PRS.Vorname + ' ', '') + PRS.Name + ISNULL(', ' + PRS.Wohnsitz, '')
                      ELSE INS.[Name] + ISNULL(', ' + INS.Adresse, '')
                    END
FROM dbo.BaZahlungsweg        ZAL WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ZAL.BaPersonID
  LEFT JOIN dbo.vwInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAL.BaInstitutionID;
GO