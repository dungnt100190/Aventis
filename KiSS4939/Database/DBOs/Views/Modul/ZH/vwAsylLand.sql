SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwAsylLand
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylLand.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylLand.sql $
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW dbo.vwAsylLand
AS

SELECT
		BaLandID, Text AS Land
FROM
		dbo.BaLand WITH (READUNCOMMITTED)

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylLand] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylLand]  TO [tools_sonar_ek_asyl_role]
GO
