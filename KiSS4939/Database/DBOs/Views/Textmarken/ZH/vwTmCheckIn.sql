SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmCheckIn
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmCheckIn.sql $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmCheckIn.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: 23.01.2008
Description: Textmarke für FaCheckin
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmCheckIn
===================================================================================================
History:
--------
23.01.2008 : sozheo : neu erstellt
===================================================================================================
*/


CREATE VIEW [dbo].[vwTmCheckIn]
AS

SELECT
  CHK.FaCheckinID,
  CHK.FaLeistungID,
  ErstkontaktDatum = CONVERT(varchar, CHK.ErstkontaktDatum, 104),
  ErstKontaktUser = USRek.VornameName,
  ErstKontaktOrganisation = ORGek.ItemName,
  Kontaktart = dbo.fnLOVText('FaCheckinKontaktart', CHK.KontaktartCode),
  CHK.KontaktPerson,
  KontaktGrund = dbo.fnLOVText('FaCheckinEroeffnungsgrund', CHK.KontaktgrundCode),
  -- TODO: welche LOV-Liste?
  -- FallartZAV = dbo.fnLOVText('???', CHK.FallartZAVCode),
  ZustaendigkeitGeprueftDatum = CONVERT(varchar, CHK.ZustaendigkeitGeprueftDatum, 104),
  ZustaendigkeitUser = USRzs.VornameName,
  ZustaendigkeitOrganisation = ORGzs.ItemName,
  Situationsbeschrieb,

  AntragAbgegebenDatum = CONVERT(varchar, CHK.AntragAbgegebenDatum, 104),
  AntragAbgegebenUser = USRaa.VornameName,

  AntragEingegangenDatum = CONVERT(varchar, CHK.AntragEingegangenDatum, 104),
  AntragEingegangenUser = USRae.VornameName,

  AntragVollstaendigDatum = CONVERT(varchar, CHK.AntragVollstaendigDatum, 104),
  AntragVollstaendigUser = USRav.VornameName,

  AbschlussDatum = CONVERT(varchar, CHK.AbschlussDatum, 104),
  AbschlussUser = USRab.VornameName,

  FallabschlussGrund = dbo.fnLOVText('FaCheckinAbschlussgrund', CHK.FallabschlussGrundCode),
  GespraecheGemacht = CASE WHEN CHK.GespraecheGemacht = 1 THEN 'Ja' ELSE 'Nein' END,
  RessourcenPaket = dbo.fnLOVText('FaRessourcenpaket', CHK.FaRessourcenPaketCode),
  Kriterium = dbo.fnLOVText('FaKriterium', CHK.FaKriteriumCode),

  QuartierTeam = ORGqt.ItemName,
  UebergabeDatum = CONVERT(varchar, CHK.QTUebergabeDatum, 104)
FROM dbo.FaCheckin CHK WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwUser USRek ON USRek.UserID = CHK.ErstkontaktUserID
  LEFT JOIN dbo.vwUser USRzs ON USRzs.UserID = CHK.ZustaendigUserID
  LEFT JOIN dbo.vwUser USRaa ON USRaa.UserID = CHK.AntragAbgegebenUserID
  LEFT JOIN dbo.vwUser USRae ON USRae.UserID = CHK.AntragEingegangenUserID
  LEFT JOIN dbo.vwUser USRav ON USRav.UserID = CHK.AntragVollstaendigUserID
  LEFT JOIN dbo.vwUser USRab ON USRab.UserID = CHK.AbschlussUserID
  LEFT JOIN dbo.XOrgUnit ORGek WITH (READUNCOMMITTED) ON ORGek.OrgUnitID = CHK.ErstKontaktOrgUnitID
  LEFT JOIN dbo.XOrgUnit ORGzs WITH (READUNCOMMITTED) ON ORGzs.OrgUnitID = CHK.ZustaendigOrgUnitID
  LEFT JOIN dbo.XOrgUnit ORGqt WITH (READUNCOMMITTED) ON ORGqt.OrgUnitID = CHK.QuartierTeamID

GO
GRANT SELECT ON [dbo].[vwTmCheckIn] TO [tools_access]