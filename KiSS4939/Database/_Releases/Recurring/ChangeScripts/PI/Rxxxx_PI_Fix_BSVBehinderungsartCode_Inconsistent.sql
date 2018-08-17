/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Korrigiert alle BaPerson-Einträge, bei welchen den BSVBehinderungsartCode nicht mit 
           Hauptbehinderungsart übereinstimmt (via Value1 von Werteliste 'BaBehinderungsart')
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- set update flag
-------------------------------------------------------------------------------
DECLARE @DoUpdateWrongData BIT;
SET @DoUpdateWrongData = 1;

-------------------------------------------------------------------------------
-- setup temporary table
-------------------------------------------------------------------------------
DECLARE @TmpWrongBSVBehinderungsart TABLE
(
  BaPersonID INT NOT NULL PRIMARY KEY,
  Name VARCHAR(255) NOT NULL,
  Vorname VARCHAR(255),
  HauptbehinderungsArtCode INT NOT NULL,
  BSVBehinderungsartCode INT,
  SollValue INT NOT NULL
);

-------------------------------------------------------------------------------
-- fill temporary table
-------------------------------------------------------------------------------
INSERT INTO @TmpWrongBSVBehinderungsart
  SELECT PRS.BaPersonID,
         PRS.Name,
         PRS.Vorname,
         PRS.HauptbehinderungsArtCode,
         PRS.BSVBehinderungsartCode,
         LOV.Value1
  FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
    INNER JOIN dbo.XLOVCode LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'BaBehinderungsart' 
                                                      AND LOV.Code = PRS.HauptbehinderungsArtCode
  WHERE PRS.HauptbehinderungsArtCode IS NOT NULL 
    AND (PRS.BSVBehinderungsartCode IS NULL OR PRS.BSVBehinderungsartCode <> LOV.Value1);

-------------------------------------------------------------------------------
-- show output of wrong data
-------------------------------------------------------------------------------
/*
SELECT TMP.*
FROM @TmpWrongBSVBehinderungsart TMP
ORDER BY TMP.BaPersonID;
--*/

-------------------------------------------------------------------------------
-- fix wrong data
-------------------------------------------------------------------------------
-- check if need to update data
IF (ISNULL(@DoUpdateWrongData, 0) = 1 AND EXISTS (SELECT TOP 1 1
                                                  FROM @TmpWrongBSVBehinderungsart))
BEGIN
  -- create new history version
  INSERT INTO HistoryVersion (AppUser) 
  VALUES ('ReleaseScript');

  -- update data
  UPDATE PRS
  SET PRS.BSVBehinderungsartCode = TMP.SollValue
  FROM dbo.BaPerson PRS
    INNER JOIN @TmpWrongBSVBehinderungsart TMP ON TMP.BaPersonID = PRS.BaPersonID;
  
  PRINT ('Warning: Corrected "' + CONVERT(VARCHAR(50), @@ROWCOUNT) + '" invalid values in dbo.BaPerson.BSVBehinderungsartCode');
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
