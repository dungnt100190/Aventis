SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject vwAsylFall
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylFall.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:52 $
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
  TEST: AND DatumVon < @PeriodeBis AND (DatumBis IS NULL OR DatumBis < @PeriodeVon) X-S, ToDo: Periode berücksichtigen
   .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylFall.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[vwAsylFall]
AS

SELECT
		FAL.FaFallID,
		WVC.DatumVon AS WVVon,
		WVC.DatumBis AS WVBis,
		LogonName = CAST( USR.LogonName AS varchar(10)),
		ORG.OrgUnitID,
		ORG.ItemName AS TeamName,
		Kostenstelle = CAST( ORG.Kostenstelle AS varchar(10)),
		FalltraegerBaPersonID = FAL.BaPersonID
FROM
		dbo.FaFall FAL WITH (READUNCOMMITTED)
		INNER JOIN dbo.FaFallPerson  FAP WITH (READUNCOMMITTED)
				ON FAP.FaFallID   = FAL.FaFallID
		INNER JOIN dbo.BaPerson      PRS WITH (READUNCOMMITTED)
				ON PRS.BaPersonID = FAL.BaPersonID
		INNER JOIN dbo.BaWVCode      WVC WITH (READUNCOMMITTED)
				ON WVC.BaPersonID = PRS.BaPersonID
				AND WVC.BaWVStatusCode = 1
				AND WVC.BaBedID IN (16026, 16029)

		LEFT OUTER JOIN  dbo.XUser          USR WITH (READUNCOMMITTED) ON USR.UserID     = FAL.UserID
		LEFT OUTER JOIN  dbo.XOrgUnit_User  U2O WITH (READUNCOMMITTED) ON U2O.UserID     = USR.UserID AND U2O.OrgUnitMemberCode = 2
		LEFT OUTER JOIN  dbo.XOrgUnit       ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID  = U2O.OrgUnitID
WHERE
		 (PRS.AuslaenderStatusCode = 29 OR WVC.WVCode = 17)
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylFall] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylFall]  TO [tools_sonar_ek_asyl_role]
GO
