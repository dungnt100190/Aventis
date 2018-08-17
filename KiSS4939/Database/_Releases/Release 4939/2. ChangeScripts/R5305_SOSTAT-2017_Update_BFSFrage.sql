/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Updates the BFSFrage 1.03 and 1.05 to check Avs Number with fnIsValidVersichertennummer
-------------------------------------------------------------------------------------------------
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- update BFSFrage 1.03 und 1.05
-------------------------------------------------------------------------------
UPDATE dbo.BFSFrage
  SET HerkunftSQL = 'SELECT @value = 
  CASE 
    WHEN dbo.fnBaIsValidVersichertennummer(BaPerson.AHVNummer, 1) = 1 THEN BaPerson.AHVNummer
    ELSE NULL 
  END 
FROM dbo.BaPerson WITH (READUNCOMMITTED)
  WHERE BaPerson.BaPersonID = @BaPersonID'
WHERE Variable = '1.03'
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variable 1.03 wurde angepasst');

UPDATE dbo.BFSFrage
  SET HerkunftSQL = 'SELECT @value = 
  CASE 
    WHEN dbo.fnBaIsValidVersichertennummer(vwPerson.VersichertenNummer, DEFAULT) = 1 THEN vwPerson.Versichertennummer
    ELSE NULL
  END 
FROM dbo.vwPerson
  WHERE vwPerson.BaPersonID = @BaPersonID'
WHERE Variable = '1.05'
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variable 1.05 wurde angepasst');
GO


-------------------------------------------------------------------------------
-- BFSFrage 7.07 und 7.08 aus Katalog entfernen
-------------------------------------------------------------------------------
UPDATE FRA 
  SET BFSLeistungsfilterCodes = NULL -- '1,2,3,8,9,10'
FROM dbo.BFSFrage FRA WITH (READUNCOMMITTED)
WHERE Variable IN  ('7.07', '7.08')
  AND BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                             FROM dbo.BFSKatalogVersion WITH (READUNCOMMITTED)
                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)

PRINT ('Info: Variablen 7.07 und 7.08 wurde entfernt');
GO



-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO