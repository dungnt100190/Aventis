SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmInstitution;
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <Beschreibung der View, Zweck und Einsatz>
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwTmInstitution;
=================================================================================================*/

CREATE VIEW dbo.vwTmInstitution
AS
SELECT BaInstitutionID      = INS.BaInstitutionID,
       InstitutionNr        = INS.InstitutionNr,
       [Name]               = INS.[Name],
       Vorname              = INS.Vorname,
       NameVorname          = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname),
       Telefon              = INS.Telefon,
       Fax                  = INS.Fax,
       EMail                = INS.EMail,
       Homepage             = INS.Homepage,
       --
       CareOf               = ADR.CareOf,
       AdressZusatz         = ADR.Zusatz,
       ZuhandenVon          = ADR.ZuhandenVon,
       Strasse              = ADR.Strasse,
       HausNr               = ADR.HausNr,
       Postfach             = ADR.Postfach,
       PostfachOhneNr       = ADR.PostfachOhneNr,
       PostfachTextD        = dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1),
       PLZ                  = ADR.PLZ,
       Ort                  = ADR.Ort,
       OrtschaftCode        = ADR.OrtschaftCode,
       Kanton               = ADR.Kanton,
       Bezirk               = ADR.Bezirk,
       --
       StrasseHausNr        = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       OrtStrasse           = ISNULL(ADR.Ort,'') + ISNULL(', ' + ADR.Strasse + ISNULL(' ' + ADR.HausNr,''), ''),
       PLZOrt               = ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       --
       LandD                = dbo.fnLandMLText(ADR.BaLandID, 1),
       LandF                = dbo.fnLandMLText(ADR.BaLandID, 2),
       LandI                = dbo.fnLandMLText(ADR.BaLandID, 3),
       LandE                = dbo.fnLandMLText(ADR.BaLandID, 4),
       --
       AdresseEinzeilig     = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname) + ', ' +
                              ISNULL(ADR.Zusatz + ', ', '') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr,'') + ', ', '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       AdresseEinzOhneName  = ISNULL(ADR.Zusatz + ', ','') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       AdresseMehrzeilig    = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname) + CHAR(13) + CHAR(10) +
                              ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       AdresseMehrzOhneName = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                              ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, '')
FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL);
GO

 