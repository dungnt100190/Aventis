SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwInstitution2
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwInstitution2.sql $
  $Author: Mmarghitola $
  $Modtime: 7.09.10 10:49 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Liefert die gleiche Daten wie vwInstitution. vwInstitution2 ist schneller, falls
    für eine Institution eine Adresse gefunden werden muss. vwInstitution ist schneller, falls
    zu einer Adresse eine Institution gefunden werden muss
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwInstitution2.sql $
 * 
 * 1     7.09.10 15:12 Mmarghitola
 * #6587: vwBaPerson2 und vwInstitution2 hinzugefügt
 * 
=================================================================================================*/

CREATE VIEW [dbo].[vwInstitution2]
AS
  SELECT
    INS.[BaInstitutionID],
    INS.[Name],
    InstitutionName = INS.[Name],
    INS.[InstitutionTypCode],
    INS.[Debitor],
    INS.[Kreditor],
    INS.[Telefon],
    INS.[Fax],
    INS.[EMail],
    INS.[SprachCode],
    INS.[Bemerkung],
    INS.[Aktiv],
    INS.[Anrede],
    INS.[Homepage],
    INS.[BaFreigabeStatusCode],
    INS.[DefinitivUserID],
    INS.[DefinitivDatum],
    INS.[Creator],
    INS.[Created],
    INS.[ErstelltUserID],
    [ErstelltDatum] = INS.[Created],
    INS.[Modifier],
    INS.[Modified],
    INS.[MutiertUserID],
    [MutiertDatum] = INS.[Modified],
    INS.[BaInstitutionTS],
    Typ               = TYP.Text,
    Adresse           = IsNull(ADR.Zusatz + ', ', '') +
                        IsNull(ADR.Postfach + ', ', '') +
                        IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr, '') + ', ', '') +
                        IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    AdresseMehrzeilig = IsNull(ADR.Zusatz + char(13) + char(10), '') +
                        IsNull(ADR.Postfach + char(13) + char(10), '') +
                        IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr, '') + char(13) + char(10), '') +
                        IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    OrtStrasse        = IsNull(ADR.Ort, '') + IsNull(', ' + ADR.Strasse + IsNull(' ' + ADR.HausNr, ''), ''),
    AdressZusatz      = ADR.Zusatz,
    ADR.Strasse,
    ADR.HausNr,
    StrasseHausNr     = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
    ADR.Postfach,
    ADR.PLZ,
    ADR.Ort,
    PLZOrt            = IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    ADR.Kanton,
    Land              = LAN.Text,
    OrtschaftCode     = ADR.OrtschaftCode,
    LandCode          = LAN.BaLandID
  FROM dbo.BaInstitution      INS WITH (READUNCOMMITTED)
    LEFT OUTER JOIN dbo.XLOVCode   TYP WITH (READUNCOMMITTED) ON TYP.LOVName = 'BaInstitutionTyp' AND TYP.Code = INS.InstitutionTypCode
    OUTER APPLY
    (
      SELECT TOP 1 ADR2.Zusatz, ADR2.Strasse, ADR2.HausNr, ADR2.Ort, ADR2.Kanton, ADR2.OrtschaftCode,
        ADR2.Postfach, ADR2.PLZ, ADR2.BaLandID
      FROM dbo.BaAdresse ADR2
      WHERE ADR2.BaInstitutionID = INS.BaInstitutionID
      ORDER BY ADR2.BaAdresseID DESC
    ) ADR
    LEFT OUTER JOIN dbo.BaLand		 LAN WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID
