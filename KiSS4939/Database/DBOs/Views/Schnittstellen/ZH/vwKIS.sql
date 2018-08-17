SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKIS
GO
/*===============================================================================================
  $Revision: 10 $
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
=================================================================================================*/

CREATE VIEW dbo.vwKIS
AS

SELECT KENNUNG            = 'KIS2014',
       DAT_EXPORT         = CONVERT(CHAR(8), GETDATE(), 112) + RIGHT('0' + CONVERT(VARCHAR(6), DATEPART(hh, GETDATE()) * 10000 + DATEPART(mi, GETDATE()) * 100 + DATEPART(ss, GETDATE())), 6),
       EXPORT_USR         = 'KiSS  ',
       zip_nr             = ISNULL(CONVERT(char(9), PRS.ZIPNr), '051' + CONVERT(CHAR(6), PRS.BaPersonID)),
       ahv_nr             = CONVERT(CHAR(14), ISNULL(PRS.AHVNummer, '')),
       sozvers_nr         = REPLACE(PRS.Versichertennummer, '.', ''),
       nachname           = CONVERT(CHAR(32), ISNULL(PRS.Name, '')),
       vorname            = CONVERT(CHAR(32), ISNULL(PRS.Vorname, '')),
       strasse            = CONVERT(CHAR(32), CASE WHEN ADR.Gesperrt = 1 THEN 'gesperrt' ELSE ISNULL(PRS.WohnsitzStrasse, '') END),
       plz                = CONVERT(CHAR(8), CASE WHEN ADR.Gesperrt = 1 THEN '' ELSE ISNULL(PRS.WohnsitzPLZ, '') END),
       ort                = CONVERT(CHAR(32), CASE WHEN ADR.Gesperrt = 1 THEN 'gesperrt' ELSE ISNULL(PRS.WohnsitzOrt, '') END),
       dat_geburt         = ISNULL(CONVERT(CHAR(8), PRS.Geburtsdatum, 112), ''),
       dat_tod            = ISNULL(CONVERT(CHAR(8),  PRS.Sterbedatum, 112), ''),
       geschlecht_code    = CONVERT(CHAR(1),  CASE GeschlechtCode WHEN 1 THEN 'm' WHEN 2 THEN 'w' ELSE '' END),
       heimatort          = CONVERT(CHAR(32), ISNULL(GMD.Name, '')),
       nationalitaet      = CONVERT(CHAR(32), ISNULL(LAN.[Text], '')),
       leistungsart_code  = CONVERT(CHAR(5), ISNULL(LEI.FaProzessCode + 1000, '')),
       dat_bezug_von      = ISNULL(CONVERT(CHAR(8), LEI.DatumVon, 112), ''),
       dat_bezug_bis      = ISNULL(CONVERT(CHAR(8), LEI.DatumBis, 112), ''),
       fall_nr            = CONVERT(CHAR(10), ISNULL(LEI.FaLeistungID, '')),
       person_nr          = CONVERT(CHAR(10), ISNULL(PRS.BaPersonID, '')),
       sb_nachname        = CONVERT(CHAR(32), ISNULL(USR.LastName, '')),
       sb_vorname         = CONVERT(CHAR(32), ISNULL(USR.FirstName, '')),
       bereich            = CONVERT(CHAR(32), ISNULL(ORG.ItemName, '')),
       sb_telefon         = CONVERT(CHAR(24), ISNULL(USR.Phone, '')),
       sb_email           = CONVERT(CHAR(64), ISNULL(USR.EMail, ''))
FROM dbo.vwPerson                PRS
  LEFT OUTER JOIN dbo.BaAdresse  ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID  = PRS.WohnsitzBaAdresseID
  INNER JOIN dbo.FaLeistung      LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID   = PRS.BaPersonID
  INNER JOIN dbo.XUser           USR WITH (READUNCOMMITTED) ON USR.UserID       = LEI.UserID
  INNER JOIN dbo.XOrgUnit_User   U2O WITH (READUNCOMMITTED) ON U2O.UserID       = USR.UserID AND OrgUnitMemberCode = 2 /*Mitglied*/
  INNER JOIN dbo.XOrgUnit        ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID    = U2O.OrgUnitID
  LEFT OUTER JOIN dbo.BaGemeinde GMD WITH (READUNCOMMITTED) ON GMD.BaGemeindeID = PRS.HeimatgemeindeCode
  LEFT OUTER JOIN dbo.BaLand     LAN WITH (READUNCOMMITTED) ON LAN.BaLandID     = PRS.NationalitaetCode
WHERE LEI.ModulID <> 4 AND LEI.FaProzessCode <> 201


GO
GRANT SELECT ON [dbo].[vwKIS] TO [tools_access]