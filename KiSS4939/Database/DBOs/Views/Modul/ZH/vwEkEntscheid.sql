SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwEkEntscheid
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwEkEntscheid.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwEkEntscheid.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwEkEntscheid]
AS
SELECT     WKE.WhEkEntscheidID, WKE.Datum, WKE.BaPersonID, PRS.Name, PRS.Vorname, PRS.NNummer, FAL.FaFallID,
                      WKE.Bemerkung, WKE.EntscheidJahr, WKE.EntscheidKW, WKE.EntscheidLaufNr,
                      LEI.UserID, WKE.WhVerfuegungGrundCode, XLC.Text, XLC.ShortText, TeamID = ORG.OrgUnitID, Team = ORG.ItemName
FROM         dbo.WhEkEntscheid WKE WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung   LEI WITH (READUNCOMMITTED) ON WKE.FaLeistungID = LEI.FaLeistungID
  INNER JOIN dbo.FaFall       FAL WITH (READUNCOMMITTED) ON FAL.FaFallID     = LEI.FaFallID
  INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName      = 'WhVerfuegungGrund' AND XLC.Code = WKE.WhVerfuegungGrundCode
  INNER JOIN dbo.BaPerson     PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID   = WKE.BaPersonID
--  INNER JOIN dbo.XUser        USR ON USR.UserID       = LEI.UserID
  INNER JOIN dbo.XOrgUnit_User O2U WITH (READUNCOMMITTED) ON O2U.UserID       = LEI.UserID AND OrgUnitMemberCode = 2 /*Mitglied*/
  INNER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID    = O2U.OrgUnitID
WHERE     (WKE.EntscheidJahr IS NOT NULL) AND (WKE.EntscheidKW IS NOT NULL) --AND (WKE.EntscheidLaufNr IS NULL)

--lov WhVerfuegungGrund

--lov whekstatus
/*
select Top 10 *
from BaPerson

select *
from XOrgUnit


*/
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwEkEntscheid] TO [tools_access]
GO
GRANT SELECT ON [dbo].[vwEkEntscheid] TO [tools_sonar_ek_asyl_role]
GO
GRANT  UPDATE  ON [dbo].[vwEkEntscheid] (
	[EntscheidLaufNr]
	) TO [tools_access]
GO
