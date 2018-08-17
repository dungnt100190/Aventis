SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAlteFallNr
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAlteFallNr.sql $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAlteFallNr.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[vwTmAlteFallNr]
AS

SELECT	BaPersonID,
		AlteFallNr = FallNrAlt,
		AltePersNr = PersonNrAlt,
		DatumVon
FROM	dbo.BaAlteFallNr  WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmAlteFallNr] TO [tools_access]