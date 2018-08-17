SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmWVCode
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmWVCode.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmWVCode.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmWVCode]
AS

SELECT	BaPersonID,
		Seit = CONVERT(varchar, DatumVon, 104),
		[Status] = dbo.fnLOVText('BaWVStatus', BaWVStatusCode),
		SKZNummer,
		DatumVon
FROM	dbo.BaWVCode WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmWVCode] TO [tools_access]