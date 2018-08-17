SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBaZahlungsweg
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBaZahlungsweg.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBaZahlungsweg.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwBaZahlungsweg]
AS

SELECT
		ZAL.BaZahlungswegID,
		ZAL.BaPersonID,
		ZAL.BaInstitutionID,
		ZAL.DatumVon,
		ZAL.DatumBis,
		ZAL.EinzahlungsscheinCode,
		ZAL.ZahlinformationAktiv,
		ZAL.BaBankID,
		ZAL.BankKontoNummer,
		ZAL.IBANNummer,
		ZAL.PostKontoNummer,
		ZAL.ESRTeilnehmer,
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
		ZAL.IsZkbVmKonto,
		ZAL.WMAVerwenden,
		[Name]     = CASE		WHEN ZAL.BaPersonID IS NOT NULL THEN IsNull(PRS.Vorname + ' ', '') + PRS.Name
												ELSE INS.Name END,
		Adresse		 = CASE		WHEN ZAL.BaPersonID IS NOT NULL THEN PRS.Wohnsitz
												ELSE INS.Adresse END,
		Empfaenger = CASE		WHEN ZAL.BaPersonID IS NOT NULL THEN IsNull( PRS.Vorname + ' ', '') + PRS.Name + IsNull( ', ' + PRS.Wohnsitz, '')
												ELSE INS.Name + IsNull( ', ' + INS.Adresse, '') END
FROM
		dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED)
		LEFT OUTER JOIN vwPerson      PRS ON PRS.BaPersonID      = ZAL.BaPersonID
		LEFT OUTER JOIN vwInstitution INS ON INS.BaInstitutionID = ZAL.BaInstitutionID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwBaZahlungsweg]  TO [tools_access]
GO
