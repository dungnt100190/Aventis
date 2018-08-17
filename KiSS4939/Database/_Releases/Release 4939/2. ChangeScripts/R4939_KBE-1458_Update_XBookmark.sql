/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Script um die Textmarken anzupassen
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- Step 1: VmLetzteMassnahme...
-------------------------------------------------------------------------------
-- Old-Tabelle erstellen
SELECT TOP 1 *
INTO dbo._Old_XBookmark
FROM dbo.XBookmark WITH (READUNCOMMITTED)
WHERE 1 = 0


-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmLetzteMassnahmeMTEmail',
'VmLetzteMassnahmeMTErnennung',
'VmLetzteMassnahmeMTNachname',
'VmLetzteMassnahmeMTName',
'VmLetzteMassnahmeMTPLZOrt',
'VmLetzteMassnahmeMTStrasseNr',
'VmLetzteMassnahmeMTTelefonG',
'VmLetzteMassnahmeMTTelefonMobil',
'VmLetzteMassnahmeMTTelefonP',
'VmLetzteMassnahmeMTVorname',
'VmLetzteMassnahmeAufhebung',
'VmLetzteMassnahmeBeschlussVom',
'VmLetzteMassnahmeZGBArtikel',
'VmLetzteMassnahmeZGBBez'
)


-- neue Textmarken-View erstellen
IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XBookmark WITH (READUNCOMMITTED)
           WHERE BookmarkName = 'VmLetzteMassnahme'))
BEGIN
  PRINT ('Warning: XBookmark VmLetzteMassnahme ist bereits vorhanden');
END
ELSE
BEGIN
  INSERT INTO dbo.XBookmark (BookmarkName, Category, BookmarkCode, [SQL], [Description], TableName, ModulID, AlwaysVisible, [System]) 
    SELECT 'VmLetzteMassnahme', 'Vormundschaft', 1, 'SELECT <TableColumn> 
FROM dbo.vwTmVmLetzteMassnahme 
WHERE BaPersonID = {BaPersonID}', NULL, 'vwTmVmLetzteMassnahme', 5, 0, 1
  PRINT ('Info: XBookmark VmLetzteMassnahme wurde erstellt');
END;



GO

-------------------------------------------------------------------------------
-- Step 2: VmMassnahme...
-------------------------------------------------------------------------------
-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmMassnahmeAufhebung',
'VmMassnahmeBeschlussVom',
'VmMassnahmeZGBArtikel',
'VmMassnahmeZGBBez'
)


-- neue Textmarken-View erstellen
IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XBookmark WITH (READUNCOMMITTED)
           WHERE BookmarkName = 'VmMassnahme'))
BEGIN
  PRINT ('Warning: XBookmark VmMassnahme ist bereits vorhanden');
END
ELSE
BEGIN
  INSERT INTO dbo.XBookmark (BookmarkName, Category, BookmarkCode, [SQL], [Description], TableName, ModulID, AlwaysVisible, [System]) 
    SELECT 'VmMassnahme', 'Vormundschaft', 1, 'SELECT <TableColumn> 
FROM dbo.vwTmVmMassnahme 
WHERE KesMassnahmeID = {KesMassnahmeID}', NULL, 'vwTmVmMassnahme', 5, 0, 1
  PRINT ('Info: XBookmark VmMassnahme wurde erstellt');
END;
GO


-------------------------------------------------------------------------------
-- Step 3: VmMandatstraeger... löschen
-------------------------------------------------------------------------------
-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmMandatstraegerAnrede',
'VmMandatsträgerSehrGeehrteFrauHerr',
'VmMandatstraegerName',
'VmMandatstraegerVorname',
'VmMandatstraegerVornameName'
)

GO


-------------------------------------------------------------------------------
-- Step 4: VmLetzteBerPeriode...
-------------------------------------------------------------------------------
-- alte Werte in Old-Tabelle speichern und löschen
DELETE 
FROM dbo.XBookmark 
  OUTPUT Deleted.BookmarkName, Deleted.BookmarkNameTID, Deleted.Category, Deleted.CategoryTID, Deleted.BookmarkCode, Deleted.SQL, Deleted.Description, Deleted.DescriptionTID, Deleted.TableName, Deleted.ModulID, Deleted.AlwaysVisible, Deleted.System
    INTO dbo._Old_XBookmark (BookmarkName, BookmarkNameTID, Category, CategoryTID, BookmarkCode, SQL, Description, DescriptionTID, TableName, ModulID, AlwaysVisible, System)
WHERE BookmarkName IN (
'VmLetzteBerPeriodeBis',
'VmLetzteBerPeriodeEntsch',
'VmLetzteBerPeriodeVon'
)


-- neue Textmarken-View erstellen
IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XBookmark WITH (READUNCOMMITTED)
           WHERE BookmarkName = 'VmLetzteBerPeriode'))
BEGIN
  PRINT ('Warning: XBookmark VmLetzteBerPeriode ist bereits vorhanden');
END
ELSE
BEGIN
  INSERT INTO dbo.XBookmark (BookmarkName, Category, BookmarkCode, [SQL], [Description], TableName, ModulID, AlwaysVisible, [System]) 
    SELECT 'VmLetzteBerPeriode', 'Vormundschaft', 1, 'SELECT <TableColumn> 
FROM dbo.vwTmVmLetzteBerPeriode 
WHERE BaPersonID = {BaPersonID}', NULL, 'vwTmVmLetzteBerPeriode', 5, 0, 1
  PRINT ('Info: XBookmark VmLetzteBerPeriode wurde erstellt');
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

