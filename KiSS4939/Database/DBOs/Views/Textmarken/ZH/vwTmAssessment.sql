SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAssessment
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAssessment.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:57 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAssessment.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
CREATE VIEW [dbo].[vwTmAssessment]
AS

SELECT
    FaAssessmentID,
	FaLeistungID,
	Sozialarbeiter = IsNull(USRero.Vorname, '') + IsNull(' ' + USRero.Name, ''),
	Eroeffnung = CONVERT(varchar, ASS.EroeffnungDatum, 104),
	EroeffnungUser = IsNull(USRero.Vorname, '') + IsNull(' ' + USRero.Name, ''),
	EroeffnungOrgUnit = IsNull(USRero.Vorname, '') + IsNull(' ' + USRero.Name, '') + IsNull(', ' + USRero.OrgEinheitName, ''),
	DatumBericht = CONVERT(varchar, ASS.DatumBericht, 104),
	Abschluss = CONVERT(varchar, ASS.AbschlussDatum, 104),
	AbschlussUser = IsNull(USRabs.Vorname, '') + IsNull(' ' + USRabs.Name, ''),
	Grund = dbo.fnLOVText('FaAssessmentAbschlussgrund', ASS.FaAssessmentAbschlussGrundCode),
	IsUeBv = CASE WHEN ASS.FaAssessmentAbschlussGrundCode IN (2,3) THEN 'Ja' ELSE 'Nein' END,
	GrundUeBv = dbo.fnLOVText('FaUeberbrueckungBevorschussungGrund', ASS.FaUeberbrueckungGrundCode),
	EmpfehlungRP = dbo.fnLOVText('FaRessourcenpaket', ASS.FaRessourcenPaketCode),
	Kriterium = dbo.fnLOVText('FaKriterium', ASS.FaKriteriumCode),
	QTUebergabeAm = CONVERT(varchar, ASS.QTUebergabeDatum, 104),
	QTUebergabeOrgUnit = OrgQtu.ItemName,
	Anlass,
	Situation,
	Thema1,
	Thema2,
	Thema1Zustaendig,
	Thema2Zustaendig,
	ThemaAnpacken,
	KeinInteresseGrund = ThemaAnpackenKeinInteresseGrund,
	KeinInteresse = CONVERT(bit, IsNull(ASS.ThemaAnpackenKeinInteresse, 0)),
	KeinSoD = CONVERT(bit, IsNull(ASS.KeinSoDThema, 0)),
	AndereStellen,
	BestehenAuflagen = dbo.fnLOVText('FaJaNein', ASS.FaAuflageCode),
	ZuweisungRP = dbo.fnLOVText('FaRessourcenPaket', ASS.RPBedarfCode),
	Muttersprache,
	DeutschGenuegend = CASE WHEN ASS.DeutschUngenuegend = 1 THEN 'Ja' ELSE 'Nein' END,
	Uebersetzer = CASE WHEN ASS.Uebersetzer = 1 THEN 'Ja' ELSE 'Nein' END,
	Bemerkung,
	Mitarbeiter = IsNull(USRmit.Vorname, '') + IsNull(' ' + USRmit.Name, ''),
	UnterschriebenDurchKlient = CONVERT(varchar, ASS.UnterschriebenDurchKlient, 104)
FROM dbo.FaAssessment ASS WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.vwUser USRero ON USRero.UserID = ASS.EroeffnungUserID
  LEFT OUTER JOIN dbo.vwUser USRabs ON USRabs.UserID = ASS.AbschlussUserID
  LEFT OUTER JOIN dbo.vwUser USRmit ON USRmit.UserID = ASS.BerichtUserID
  LEFT OUTER JOIN dbo.XOrgUnit OrgEro WITH (READUNCOMMITTED) ON OrgEro.OrgUnitID = ASS.EroeffnungOrgUnitID
  LEFT OUTER JOIN dbo.XOrgUnit OrgQtu WITH (READUNCOMMITTED) ON OrgQtu.OrgUnitID = ASS.QTUebergabeOrgUnitID

GO
GRANT SELECT ON [dbo].[vwTmAssessment] TO [tools_access]