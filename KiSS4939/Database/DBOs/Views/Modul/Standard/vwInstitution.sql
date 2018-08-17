SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwInstitution;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Institutionen.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwInstitution;
=================================================================================================*/

CREATE VIEW dbo.vwInstitution WITH SCHEMABINDING
AS
SELECT INS.BaInstitutionID,
       INS.OrgUnitID,
       INS.InstitutionNr,
       INS.BaInstitutionArtCode,
       INS.Aktiv,
       INS.Debitor,
       INS.Kreditor,
       INS.KeinSerienbrief,
       INS.ManuelleAnrede,
       INS.Anrede,
       INS.Briefanrede,
       INS.Titel,
       INS.Name,
       INS.Vorname,
       INS.GeschlechtCode,
       INS.Telefon,
       INS.Telefon2,
       INS.Telefon3,
       INS.Fax,
       INS.EMail,
       INS.Homepage,
       INS.SprachCode,
       INS.Bemerkung,
       INS.Creator,
       INS.Created,
       INS.Modifier,
       INS.Modified,
       INS.BaInstitutionTS,
       --
       NameVorname = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname),
       --
       Adresse                 = ISNULL(ADR.Zusatz + ', ', '') +
                                 ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                                 ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       --
       AdresseMehrzeilig       = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       --
       OrtStrasse              = ISNULL(ADR.Ort, '') + ISNULL(', ' + ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''), ''),
       --
       Zusatz                  = ADR.Zusatz,
       AdressZusatz            = ADR.Zusatz,  -- [obsolete]
       Strasse                 = ADR.Strasse,
       HausNr                  = ADR.HausNr,
       StrasseHausNr           = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Postfach                = ADR.Postfach,
       PostfachOhneNr          = ADR.PostfachOhneNr,
       --
       PostfachTextD           = dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1),
       --
       PLZ                     = ADR.PLZ,
       Ort                     = ADR.Ort,
       PLZOrt                  = ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       Bezirk                  = ADR.Bezirk,
       Kanton                  = ADR.Kanton,
       Land                    = dbo.fnLandMLText(ADR.BaLandID, 1),
       OrtschaftCode           = ADR.OrtschaftCode,
       BaLandID                = ADR.BaLandID,
       --
       BaFreigabeStatusCode    = 2 -- hack um zh analog zu bleiben
FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = (SELECT FCN.BaAdresseID 
                                                                           FROM dbo.fnBaGetBaAdresseID_BaInstitution(NULL, NULL) FCN
                                                                           WHERE FCN.BaInstitutionID = INS.BaInstitutionID);
GO