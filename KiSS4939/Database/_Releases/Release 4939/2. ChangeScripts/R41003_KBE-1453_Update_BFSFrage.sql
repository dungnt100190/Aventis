/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update entries in BFSFrage table
=================================================================================================*/


UPDATE FRA 
  SET HerkunftSQL = 'SELECT @value = SUM(CASE WHEN BgKategorieCode in (1,4) THEN -Betrag ELSE Betrag END)
FROM dbo.fnBFSMonatsBelege(@AntragstellerID, @BFSLeistungsartCode, YEAR(@DatumBis), MONTH(@DatumBis), 0)
WHERE BgKategorieCode IN (1, 2, 4, 100, 101) -- Einnahmen, Ausgaben, Kürzungen, ZL, EZ

IF (@value < 0)
BEGIN
  SET @value = 0;
END;'
FROM dbo.BFSFrage FRA
WHERE Variable = '15.051'
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variable 15.051 wurde angepasst');

GO