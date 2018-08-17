/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to update Kes-related XLOVCodes
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- Step 1: Update existing XLOVCodes
-------------------------------------------------------------------------------
UPDATE XLOVCode SET Text = 'Anderes', TextTID = NULL WHERE LOVName = 'KesAufhebungsgrundES' AND Code = 5;
UPDATE XLOVCode SET Text = 'Anderes', TextTID = NULL WHERE LOVName = 'KesAufhebungsgrundKS' AND Code = 6;
UPDATE XLOVCode SET Text = 'Andere', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 10;
UPDATE XLOVCode SET Text = 'Betroffene Person selber', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 1;
UPDATE XLOVCode SET Text = 'Keine (KESB von Amtes wegen)', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 11;
UPDATE XLOVCode SET Text = 'Weitere Amtsstellen (z.B. Betreibungsamt, Steueramt, Ausgleichskasse)', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchES' AND Code = 8;
UPDATE XLOVCode SET Text = 'Andere', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 10;
UPDATE XLOVCode SET Text = 'Betroffenes Kind selber', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 1;
UPDATE XLOVCode SET Text = 'Keine (KESB von Amtes wegen)', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 11;
UPDATE XLOVCode SET Text = 'Weitere Amtsstellen', TextTID = NULL WHERE LOVName = 'KesGefaehrdungsmeldungDurchKS' AND Code = 8;
UPDATE XLOVCode SET Text = 'Ordentlicher Bericht', TextTID = NULL WHERE LOVName = 'KesMassnahmeBerichtsart' AND Code = 1;

-------------------------------------------------------------------------------
-- Step 2: Insert missing XLOVCodes
-------------------------------------------------------------------------------
INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       11,   --Code
       'Korrespondenz', --Text
       10, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       '1,2', --Value3
       NULL, --Description
       NULL, --LOVCodeName
       1,    --IsActive
       0     --System
FROM XLOV
WHERE LOVName = 'KesDienstleistung'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleistung' AND Code = 11)

--XLOV Eintrag KesDienstleitungenStatFallentw machen
IF(NOT EXISTS (SELECT TOP 1 1 FROM XLOV WHERE LOVName = 'KesDienstleitungenStatFallentw'))
BEGIN
  INSERT INTO [XLOV] ([LOVName], [Description], [System], [Expandable], [ModulID], [LastUpdated], [Translatable], [NameValue1], [NameValue2], [NameValue3])
  VALUES ( N'KesDienstleitungenStatFallentw' ,  
           N'Maske CtlQueryStatFallentwicklungKes - Liste der Prozess' ,
           1 ,
           0 ,
           29,
           null ,
           1 ,
           null ,
           null ,
           null )
END;

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       1,   --Code
       'Präventionen', --Text
       1, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Präventionen', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 1)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       2,   --Code
       'Abklärungen/Auftrag', --Text
       2, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Abklärungen/Auftrag', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 2)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       3,   --Code
       'Massnahmeführung', --Text
       3, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Massnahmeführung', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 3)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       4,   --Code
       'Pflegekinderaufsicht', --Text
       4, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       'Pflegekinderaufsicht', --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesDienstleitungenStatFallentw'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesDienstleitungenStatFallentw' AND Code = 4)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       10,   --Code
       'Einstellung Verfahren', --Text
       10, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       NULL, --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesMassnahmeGeschaeftsart'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesMassnahmeGeschaeftsart' AND Code = 10)

INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System)
SELECT XLOVID,
       LOVName,
       11,   --Code
       'Inventar bei Todesfall', --Text
       11, --SortKey
       NULL, --ShortText
       NULL, --BFSCode
       NULL, --Value1,
       NULL, --Value2
       NULL, --Value3
       NULL, --Description
       NULL, --LOVCodeName
       1,    --IsActive
       1     --System
FROM XLOV
WHERE LOVName = 'KesMassnahmeGeschaeftsart'
  AND NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = 'KesMassnahmeGeschaeftsart' AND Code = 11)

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

