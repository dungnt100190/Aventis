SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject WhPositionsart
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Modul/WhPositionsart.sql $
  $Author: Tabegglen $
  $Modtime: 17.08.10 11:48 $
  $Revision: 8 $
=================================================================================================*/
CREATE  VIEW dbo.WhPositionsart
AS

SELECT
  POA.BgPositionsartID, POA.BgKategorieCode, POA.BgGruppeCode, POA.BgPositionsartCode, POA.BgPositionsartID_CopyOf, 
  POA.Name, POA.Hilfetext, POA.SortKey, POA.BgKostenartID, POA.NrmKontoCode, POA.VerwaltungSD_Default, POA.Spezkonto, 
  POA.ProPerson, POA.ProUE, POA.Masterbudget_EditMask, POA.Monatsbudget_EditMask, POA.ModulID, POA.sqlRichtlinie, 
  POA.BgPositionsartTS, POA.VarName, POA.Verrechenbar, POA.Bemerkung, POA.NameTID, POA.DatumVon, POA.DatumBis, 
  POA.System, POA.KreditorEingeschraenkt, 
  KontoNrName = ISNULL(KOA.KontoNr + ' ', '') + POA.Name
FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = POA.BgKostenartID
WHERE
  POA.ModulID = 3
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
