SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject AyKostenart;
GO
/*===============================================================================================
  Revision: 3
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the BgKostenart entry for the modulID 6 (Asyl)
=================================================================================================*/

CREATE VIEW dbo.AyKostenart
AS

SELECT 
  BgKostenartID, 
  ModulID, 
  Name, 
  KontoNr, 
  Quoting, 
  BgSplittingArtCode, 
  BaWVZeileCode, 
  BgKostenartTS
FROM dbo.BgKostenart WITH (READUNCOMMITTED) 
WHERE ModulID = 6;

GO