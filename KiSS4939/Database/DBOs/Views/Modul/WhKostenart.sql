SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject WhKostenart;
GO
/*===============================================================================================
  Revision: 3
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the BgKostenart entry for the modulID 3 (Sozialhilfe)
=================================================================================================*/
CREATE VIEW dbo.WhKostenart
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
WHERE ModulID = 3;

GO