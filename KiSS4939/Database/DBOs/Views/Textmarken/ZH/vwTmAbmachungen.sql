SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAbmachungen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAbmachungen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAbmachungen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmAbmachungen]
AS

SELECT
	ABM.FaAbmachungID,
	Klient1 = IsNull(PRS1.Vorname, '') + IsNull(' ' + PRS1.Name, ''),
	Klient2 = IsNull(PRS2.Vorname, '') + IsNull(' ' + PRS2.Name, ''),
	KlientBeide = IsNull(PRS1.Vorname, '') + IsNull(' ' + PRS1.Name, '') + IsNull(' und ' + PRS2.Vorname + IsNull(' ' + PRS2.Name, ''), ''),
	Betreff,
	ErfasstAm = CONVERT(varchar, ABM.ErstelltDatum , 104),
	Sozialarbeiter = IsNull(USR.FirstName, '') + IsNull(' ' + USR.LastName, ''),
	SozialarbeiterInFunktion = IsNull(USR.Funktion, ''),
	Ausgangslage,
	AuflageVon = CONVERT(varchar, ABM.AuflageVon, 104),
    Auflagentext,
	AngedrohteSanktion = dbo.fnLOVText('FaAbmachungSanktionen', ABM.AngedrohtFaAbmachungSanktionenCode),
	Sanktion = dbo.fnLOVText('FaAbmachungSanktionen', ABM.FaAbmachungSanktionenCode),
	Frist = CONVERT(varchar, ABM.ErfuellenBis, 104),
	StellenleiterVornameName = IsNull(STL.FirstName + ' ','') + STL.LastName,
	FrauHerr1 =
		CASE PRS1.GeschlechtCode
			WHEN 1 THEN 'Herr'
			WHEN 2 THEN 'Frau'
		ELSE ''
		END,
	GeehrteFrauHerrVornameName1 =
		CASE PRS1.GeschlechtCode
			WHEN 1 THEN 'Sehr geehrter Herr '
			WHEN 2 THEN 'Sehr geehrte Frau '
			ELSE ''
		END + PRS1.Name,
	WohnsitzAdresseMehrzOhneName = (
		IsNull(ADR1.Zusatz + char(13) + char(10),'') +
		IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
		IsNull(ADR1.PLZ + ' ','') + ADR1.Ort )
FROM   dbo.FaAbmachung ABM WITH (READUNCOMMITTED)
	LEFT OUTER JOIN dbo.BaPerson PRS1 WITH (READUNCOMMITTED) ON PRS1.BaPersonID = ABM.Klient1ID
	LEFT OUTER JOIN dbo.BaPerson PRS2 WITH (READUNCOMMITTED) ON PRS2.BaPersonID = ABM.Klient2ID
    LEFT OUTER JOIN dbo.XUser USR WITH (READUNCOMMITTED) on USR.UserID = ABM.ErstelltUserID
	LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                    OUU.OrgUnitMemberCode = 2
    LEFT OUTER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
	LEFT OUTER JOIN dbo.XUser STL WITH (READUNCOMMITTED) ON STL.UserID = ORG.ChiefID
	LEFT OUTER JOIN dbo.BaAdresse ADR1 WITH (READUNCOMMITTED) ON ADR1.BaPersonID = PRS1.BaPersonID AND ADR1.AdresseCode = 1 -- Wohnsitz
                                  AND GetDate() BETWEEN IsNull(ADR1.DatumVon, GetDate()) AND IsNull(ADR1.DatumBis, GetDate())

GO
GRANT SELECT ON [dbo].[vwTmAbmachungen] TO [tools_access]