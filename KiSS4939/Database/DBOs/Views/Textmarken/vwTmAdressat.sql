SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmAdressat;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <Beschreibung der View, Zweck und Einsatz>
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmAdressat;
=================================================================================================*/

CREATE VIEW dbo.vwTmAdressat
AS
SELECT FaDokumenteID     = FDO.FaDokumenteID,
       GeehrteFrauHerr   = CASE
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN 'Sehr geehrte Damen und Herren'
                             WHEN PRS.GeschlechtCode = 1 THEN 'Sehr geehrter Herr ' + PRS.Name
                             WHEN PRS.GeschlechtCode = 2 THEN 'Sehr geehrte Frau ' + PRS.Name
                             ELSE 'Sehr geehrte/-r Frau/Herr ' + PRS.Name
                           END,
       
       ErsteZeile        = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.NameVorname
                             ELSE PRS.VornameName
                           END,
                           
       AdresseMehrzeilig = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL
                               THEN ISNULL(INS.Anrede + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.NameVorname + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.Zusatz + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.StrasseHausNr + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.PostfachTextD + CHAR(13) + CHAR(10), '') +
                                    ISNULL(INS.PLZOrt, '')

                              WHEN CNF.AdressatAdresse = 3 AND PRS.AufenthaltBaAdresseID IS NOT NULL
                               THEN ISNULL(PRS.Titel + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.VornameName + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltAdressZusatz + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltStrasseHausNr + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltPostfachD + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.AufenthaltPLZOrt + CHAR(13) + CHAR(10), '')


                             ELSE   ISNULL(PRS.Titel + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.VornameName + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzAdressZusatz + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzStrasseHausNr + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzPostfachD + CHAR(13) + CHAR(10), '') +
                                    ISNULL(PRS.WohnsitzPLZOrt, '')
                           END,
       
       Ort               = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.Ort
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltOrt, PRS.WohnsitzOrt)
                             ELSE PRS.WohnsitzOrt
                           END,
       PLZ               = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.PLZ
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltPLZ, PRS.WohnsitzPLZ)
                             ELSE PRS.WohnsitzPLZ
                           END,
       PLZOrt            = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.PLZOrt
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(NULLIF(PRS.AufenthaltPLZOrt, ''), PRS.WohnsitzPLZOrt)
                             ELSE PRS.WohnsitzPLZOrt
                           END,
       Strasse           = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.StrasseHausNr
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltStrasseHausNr, PRS.WohnsitzStrasseHausNr)
                             ELSE PRS.WohnsitzStrasseHausNr
                           END,
       Zusatzzeile       = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL THEN INS.Zusatz
                             WHEN CNF.AdressatAdresse = 3 THEN ISNULL(PRS.AufenthaltAdressZusatz, PRS.WohnsitzAdressZusatz)
                             ELSE PRS.WohnsitzAdressZusatz
                           END,
       Fax               = CASE 
                             WHEN FDO.BaPersonID_Adressat IS NULL
                               THEN INS.Fax
                             ELSE PRS.Fax
                           END
FROM dbo.FaDokumente          FDO  WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwPerson      PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = FDO.BaPersonID_Adressat
  LEFT JOIN dbo.vwInstitution INS  WITH (READUNCOMMITTED) ON INS.BaInstitutionID = FDO.BaInstitutionID_Adressat
  OUTER APPLY (SELECT AdressatAdresse = dbo.fnXConfig('System\Textmarken\AdressatAdresse', GETDATE())) CNF
GO