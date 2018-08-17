SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwAsylGemeinde
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylGemeinde.sql $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylGemeinde.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW dbo.vwAsylGemeinde
AS

SELECT BaGemeindeID, PLZ, Name, Kanton, BFSCode
FROM dbo.BaGemeinde WITH (READUNCOMMITTED)
WHERE GemeindeAufhebungDatum IS NULL

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylGemeinde] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylGemeinde]  TO [tools_sonar_ek_asyl_role]
GO
