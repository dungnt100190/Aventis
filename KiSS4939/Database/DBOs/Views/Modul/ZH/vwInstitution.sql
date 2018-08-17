SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwInstitution
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwInstitution.sql $
  $Author: Mmarghitola $
  $Modtime: 18.08.10 14:47 $
  $Revision: 5 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwInstitution.sql $
 * 
 * 5     18.08.10 14:55 Mmarghitola
 * Sternchen in View aufgrund von Risiken (Schemaänderungen in zu Grunde
 * liegender Tabelle führen zu inkonsistenter Ansicht) entfernt
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwInstitution]
AS
  SELECT
    INS.[BaInstitutionID],
    INS.[Name],
    [InstitutionName] = INS.[Name],
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
  FROM dbo.BaInstitution           INS WITH (READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BaAdresse  ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID AND ADR.BaPersonID IS NULL
    LEFT OUTER JOIN dbo.BaLand     LAN WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID
    LEFT OUTER JOIN dbo.XLOVCode   TYP WITH (READUNCOMMITTED) ON TYP.LOVName = 'BaInstitutionTyp' AND TYP.Code = INS.InstitutionTypCode
  WHERE NOT EXISTS (SELECT * FROM dbo.BaAdresse WITH (READUNCOMMITTED)
                    WHERE BaInstitutionID = INS.BaInstitutionID AND BaPersonID IS NULL
                      AND BaAdresseID > ADR.BaAdresseID)

GO
GRANT SELECT ON [dbo].[vwInstitution] TO [tools_access]