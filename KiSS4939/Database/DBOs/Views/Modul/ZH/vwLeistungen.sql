SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwLeistungen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwLeistungen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:55 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwLeistungen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwLeistungen]
AS

SELECT
	LEI.FaFallID AS FaFallID,
	LEI.FaLeistungID AS FaLeistungID,
    LEI.ModulID AS ModulID,
    LEI.FaProzessCode AS FaProzessCode,
    CONVERT(varchar, LEI.DatumVon,104)  AS DatumVon,
    CONVERT(varchar, LEI.DatumBis,104)  AS DatumBis,
    CONVERT(varchar, LEI.DatumVon,104) + IsNull('-' + CONVERT(varchar, LEI.DatumBis,104), '')  AS DatumVonBis,
	LEI.BaPersonID AS BaPersonID,
    LEI.SachbearbeiterID AS SachbearbeiterID,
    LEI.UserID AS UserID,
	MOD.Name AS FaLeistungName,
	LOV.ShortText AS FaProzessCodeName,
	PRS.NameVorname AS [LT Name],                            -- Leistungsträger
    SA.NameVorname AS [SA Name],                             -- Sozialarbeite
    SA.ShortName AS [SA ShortName],
	SA.SozialzentrumCode AS [SA SozialzentrumCode],
	SA.OrgUnitID AS [SA OrgUnitID],
    SA.SozialzentrumKurz AS [SA Sozialzentrum],
    SA.OrgEinheitName AS [SA OrgEinheit],
    SA.LogonName + ' ' + SA.OrgEinheitName AS [SA NameOrg],
    SB.NameVorname AS [SB Name],
	SB.SozialzentrumCode AS [SB SozialzentrumCode],
	SB.OrgUnitID AS [SB OrgUnitID],                           -- Sachbearbeiter
    SB.SozialzentrumKurz AS [SB Sozialzentrum],
    SB.OrgEinheitName AS [SB OrgEinheit],
    SB.LogonName + ' ' + SB.OrgEinheitName AS [SB NameOrg]
FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
		INNER JOIN dbo.XModul MOD WITH (READUNCOMMITTED) on MOD.ModulID = LEI.ModulID
        LEFT OUTER JOIN dbo.XLOVCode LOV WITH (READUNCOMMITTED) ON LOV.Code = LEI.FaProzessCode AND LOV.LOVName = 'FaProzess'
        INNER JOIN vwPerson  PRS on PRS.BaPersonID = LEI.BaPersonID
        INNER JOIN vwUser  SA on SA.UserID = LEI.UserID
        LEFT JOIN vwUser  SB on SB.UserID = LEI.SachbearbeiterID

GO
GRANT SELECT ON [dbo].[vwLeistungen] TO [tools_access]