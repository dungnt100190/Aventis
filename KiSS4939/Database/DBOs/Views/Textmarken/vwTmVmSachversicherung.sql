SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmSachversicherung;
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmSachversicherung.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmSachversicherung;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW dbo.vwTmVmSachversicherung
AS
SELECT
  SVG.VmSachversicherungID,
  SVG.FaLeistungID,
  VerArt = lovSV.Text, 
  SVG.Policenummer, 
  Selbstbehalt = CONVERT(VARCHAR(20), SVG.Selbstbehalt, 1), 
  SVG.Grundpraemie, 
  Zahlungsturnus = lovZT.Text, 
  LaufzeitVon = CONVERT(VARCHAR(10), SVG.LaufzeitVon, 104), 
  LaufzeitBis = CONVERT(VARCHAR(10), SVG.LaufzeitBis, 104), 
  VersichertSeit = CONVERT(VARCHAR(10), SVG.VersichertSeit, 104), 
  SVG.Person, 
  SVG.Bemerkungen,
  Adressat_NameVorname = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.NameVorname
    ELSE PRS.NameVorname
  END,
  Adressat_StrasseNr = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.StrasseHausNr
    ELSE PRS.WohnsitzStrasseNr
  END,
  Adressat_PLZOrt = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.PLZOrt
    ELSE PRS.WohnsitzPLZOrt
  END,
  Adressat_AdrMehrzeilig = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.AdresseMehrzeilig
    ELSE PRS.WohnsitzAdresseMehrzeilig
  END,
  Adressat_AdrEinzeilig = CASE
    WHEN SVG.BaPersonID IS NULL 
    THEN INS.AdresseEinzeilig
    ELSE PRS.WohnsitzAdresseEinzeilig
  END
FROM dbo.VmSachversicherung SVG WITH (READUNCOMMITTED)
LEFT JOIN dbo.XLovCode lovSV WITH (READUNCOMMITTED) ON lovSV.LOVName = 'VmVersicherungsartSachversicherung' and lovSV.Code = SVG.VmVersicherungsartSachversicherungCode
LEFT JOIN dbo.XLovCode lovZT WITH (READUNCOMMITTED) ON lovZT.LOVName = 'VmZahlungsturnus' and lovZT.Code = SVG.VmZahlungsturnusCode
LEFT JOIN dbo.vwTmPerson PRS ON PRS.BaPersonID = SVG.BaPersonID
LEFT JOIN dbo.vwTmInstitution INS ON INS.BaInstitutionID = SVG.BaInstitutionID
;
GO
