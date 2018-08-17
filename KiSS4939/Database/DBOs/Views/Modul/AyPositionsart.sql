SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject AyPositionsart;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Modul/AyPositionsart.sql $
  $Author: Tabegglen $
  $Modtime: 17.08.10 11:48 $
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
  $Log: /KiSS4/Database/DBOs/Views/Modul/AyPositionsart.sql $
 * 
 * 4     17.08.10 11:50 Tabegglen
 * #3978 BgPositionsartNr muss BgPositionsartCode heissen, da es den
 * Charakter einer LOV hat.
 * 
 * 3     3.08.10 13:04 Cjaeggi
 * #3978: Fixed view after changes of table
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.AyPositionsart
AS
SELECT BgPositionsartID, 
       ModulID, 
       BgKategorieCode, 
       BgGruppeCode, 
       BgPositionsartCode, 
       BgPositionsartID_CopyOf, 
       Name, 
       HilfeText, 
       SortKey, 
       BgKostenartID, 
       NrmKontoCode, 
       VerwaltungSD_Default, 
       Spezkonto, 
       ProPerson, 
       ProUE, 
       Masterbudget_EditMask, 
       Monatsbudget_EditMask, 
       sqlRichtlinie, 
       VarName, 
       Verrechenbar, 
       Bemerkung, 
       NameTID, 
       DatumVon, 
       DatumBis, 
       System, 
       BgPositionsartTS
FROM dbo.BgPositionsart WITH (READUNCOMMITTED) 
WHERE ModulID = 6;
GO