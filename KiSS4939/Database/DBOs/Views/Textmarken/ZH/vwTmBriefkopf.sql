﻿SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmBriefkopf
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmBriefkopf.sql $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmBriefkopf.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmBriefkopf]
AS

SELECT
  BenutzerNr			= USR.UserID,
  BriefkopfAdresse		= ORG.Adresse,
  BriefkopfLogoMitFMT	= ORG.Logo,
  BriefkopfTelFaxWWW    = IsNull(ORG.Phone, '') + IsNull(', ' + ORG.Fax, '') + IsNull(', ' + ORG.WWW, '')
FROM dbo.XUser USR WITH (READUNCOMMITTED)
     LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                    OUU.OrgUnitMemberCode = 2
     LEFT OUTER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID

GO
GRANT SELECT ON [dbo].[vwTmBriefkopf] TO [tools_access]