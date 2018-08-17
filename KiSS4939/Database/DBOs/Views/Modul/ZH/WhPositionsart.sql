SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject WhPositionsart
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/WhPositionsart.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:59 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/WhPositionsart.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[WhPositionsart]
AS

SELECT
		BgPositionsartID, ModulID, BgKategorieCode, BgGruppeCode, Name, SortKey, BgKostenartID,
		VerwaltungSD_Default, Spezkonto, ProPerson, ProUE, Verrechenbar, Bemerkung, Masterbudget_EditMask,
		Monatsbudget_EditMask, sqlRichtlinie, VarName, BgPositionsartTS, SpezHauptvorgang, SpezTeilvorgang
FROM
		dbo.BgPositionsart WITH (READUNCOMMITTED)
WHERE
		ModulID = 3

GO
GRANT SELECT ON [dbo].[WhPositionsart] TO [tools_access]