SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaAdressate;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Auswahl Adressate in CtlFaDokumente
           Typ ist in LOV BaAdressatTyp übersetzt
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwBaAdressate;
=================================================================================================*/

CREATE VIEW dbo.vwBaAdressate
AS
-------------------------------------------------------------------------------
-- Personen
-------------------------------------------------------------------------------
SELECT ID      = PRS.BaPersonID,
       TypCode = 1,
       Typ     = 'Person',
       Name    = PRS.Name + ISNULL(' ' + PRS.Vorname, ''),
       Strasse = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Ort     = ADR.PLZ + ISNULL(' ' + ADR.Ort, '')
FROM dbo.BaPerson         PRS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL) -- wohnsitz

UNION ALL

-------------------------------------------------------------------------------
-- Institutionen
-------------------------------------------------------------------------------
SELECT ID      = INS.BaInstitutionID,
       TypCode = 2,
       Typ     = 'Institution',
       Name    = INS.[Name] + ISNULL(' ' + INS.Vorname, ''),
       Strasse = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
       Ort     = ADR.PLZ + ISNULL(' ' + ADR.Ort, '')
FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
WHERE INS.Aktiv = 1

--UNION ALL

---------------------------------------------------------------------------------
---- Private Mandatsträger
---------------------------------------------------------------------------------
--SELECT ID      =  VPM.VmPriMaID,
--       TypCode = 3,
--       Typ     = 'PriMa',
--       Name    = VPM.Name + IsNull(', ' + VPM.Vorname, ''),
--       Strasse = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
--       Ort     = IsNull(ADR.PLZ + ' ', '') + ADR.Ort
--    FROM VmPriMa           VPM
--      LEFT JOIN BaAdresse  ADR ON ADR.VmPriMaID = VPM.VmPriMaID
--    WHERE 
--    VPM.isActive = 1
GO