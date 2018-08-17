SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject vwAsylFallMitglieder
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylFallMitglieder.sql $
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
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylFallMitglieder.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwAsylFallMitglieder]
AS

SELECT     FAL.FaFallID, PRS.BaPersonID, FAP.DatumVon AS ImFallVon, FAP.DatumBis AS ImFallBis, AufenthaltCode = CAST( XLA.Value1 AS varchar(30)), XLC.ShortText AS WVCode,
           WVC.DatumVon AS WVVon, WVC.DatumBis AS WVBis, WVC.SKZNummer AS SKZNr
FROM         dbo.FaFall        AS FAL WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaFallPerson  AS FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = FAL.FaFallID
  INNER JOIN dbo.BaPerson      AS PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAP.BaPersonID
  LEFT OUTER JOIN dbo.BaWVCode AS WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID = PRS.BaPersonID AND WVC.BaWVStatusCode = 1
  INNER JOIN dbo.XLOVCode      AS XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BaWVCode' AND XLC.Code = WVC.WVCode
  INNER JOIN dbo.XLOVCode      AS XLA WITH (READUNCOMMITTED) ON XLA.LOVName = 'BaAufenthaltsstatus' AND XLA.Code = PRS.AuslaenderStatusCode
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylFallMitglieder] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylFallMitglieder]  TO [tools_sonar_ek_asyl_role]
GO
