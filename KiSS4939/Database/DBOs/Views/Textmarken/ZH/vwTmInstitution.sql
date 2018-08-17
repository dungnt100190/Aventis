SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmInstitution
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmInstitution.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:57 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmInstitution.sql $
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmInstitution]
AS

  SELECT
    InstitutionNr   = INS.BaInstitutionID,
    InstitutionName = INS.Name,
    Typ             = TYP.Text,
    Telefon         = INS.Telefon,
    Fax             = INS.Fax,
    EMail           = INS.EMail,
    Homepage        = INS.Homepage,
    OrtStrasse      = IsNull(ADR.Ort,'') + IsNull(', ' + ADR.Strasse + IsNull(' ' + ADR.HausNr,''), ''),
    AdressZusatz    = ADR.Zusatz,
    Strasse         = ADR.Strasse,
    HausNr          = ADR.HausNr,
    StrasseHausNr   = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
    Postfach        = ADR.Postfach,
    PLZ             = ADR.PLZ,
    Ort             = ADR.Ort,
    PLZOrt          = IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    Kanton          = ADR.Kanton,
    Land            = LAN.Text,
    OrtschaftCode   = ADR.OrtschaftCode,
    LandCode        = LAN.BaLandID,
    AdresseEinzeilig = (
      INS.Name + ', ' +
      IsNull(ADR.Zusatz + ', ','') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + ', ','') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort ),
    AdresseEinzOhneName = (
      IsNull(ADR.Zusatz + ', ','') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + ', ','') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort ),
    AdresseMehrzeilig = (
      INS.Name + char(13) + char(10) +
      IsNull(ADR.Zusatz + char(13) + char(10),'') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + char(13) + char(10),'') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort ),
    AdresseMehrzOhneName = (
      IsNull(ADR.Zusatz + char(13) + char(10),'') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + char(13) + char(10),'') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort )

  FROM   dbo.BaInstitution INS WITH (READUNCOMMITTED)
         LEFT OUTER JOIN dbo.BaAdresse      ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID AND
                                          ADR.BaPersonID IS NULL
         LEFT OUTER JOIN dbo.BaLand					LAN WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID
         LEFT OUTER JOIN dbo.XLOVCode       TYP WITH (READUNCOMMITTED) ON TYP.LOVName = 'BaInstitutionTyp' AND TYP.Code = INS.InstitutionTypCode

GO
GRANT SELECT ON [dbo].[vwTmInstitution] TO [tools_access]