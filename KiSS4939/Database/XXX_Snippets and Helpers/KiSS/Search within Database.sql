/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to find specific string within current database and common used fields
           on various tables (including all known columns which contain sql-code)
=================================================================================================*/

--------------------------------------------------------------------------------
-- define search value
--------------------------------------------------------------------------------
DECLARE @SearchString VARCHAR(255);
SET @SearchString = 'FindMe';

/*
--------------------------------------------------------------------------------
search within: 
--------------------------------------------------------------------------------
XClass
- CodeGenerated; ClassName;PropertiesXML

XRule
- CsCode

XClassControl
- ControlName

XClassComponent
- SelectStatement;ComponentName

XClassReference
- ClassName; ClassName_Ref

LOV
- LOVName; Description

LOVCode
- LOVName; Text

LOVCode for "ModulTree"
- Value1

XLangText for XMessage
- Text

XMenuItem
- Caption; ClassName

XModulTree
- ClassName; MaskName; sqlPreExecute; sqlInsertTreeItem

XBookmark
- Category; BookmarkName; TableName; Description; SQL

BgPositionsart
- sqlRichtlinie

BFSFrage
- HerkunftSQL

XQuery
- SQLquery

DynaMask
- MaskName

DynaField
- SQL; FieldName

SysObjects of SQLServer
- sysobjects.name; syscolumns.name; syscomments.text
--------------------------------------------------------------------------------
*/

---------------------------------------
-- header
---------------------------------------
SELECT Type = '.: Found for Search :.', 
       Titel = '"' + @SearchString + '" on "' + DB_NAME() + '" at "' + CONVERT(VARCHAR, GETDATE(), 120) + '"'

UNION

---------------------------------------
-- XClass
---------------------------------------
SELECT Type = 'XClass.CodeGenerated', 
       Titel = CLS.ClassName
FROM dbo.XClass CLS WITH (READUNCOMMITTED)
WHERE CLS.CodeGenerated LIKE '%' + @SearchString + '%'

UNION

SELECT Type = 'XClass.ClassName',
       Titel = CLS.ClassName
FROM dbo.XClass CLS WITH (READUNCOMMITTED)
WHERE CLS.ClassName LIKE '%' + @SearchString + '%'

UNION

SELECT Type = 'XClass.PropertiesXML',
       Titel = CLS.ClassName
FROM dbo.XClass CLS WITH (READUNCOMMITTED)
WHERE CLS.PropertiesXML LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XRule
---------------------------------------
SELECT Type = 'XRule.CsCode',
       Titel = ISNULL(CLS.ClassName, '') + ' - Rule: ' + ISNULL(RUL.RuleName, '<no rulename>')
FROM dbo.XRule RUL WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XClassRule CLS WITH (READUNCOMMITTED) ON CLS.XRuleID = RUL.XRuleID
WHERE RUL.CsCode LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XClassControl
---------------------------------------
SELECT Type = 'XClassControl.ControlName',
       Titel = CTL.ClassName + ' - ControlName: ' + CTL.ControlName
FROM dbo.XClassControl CTL WITH (READUNCOMMITTED)
WHERE CTL.ControlName LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XClassComponent
---------------------------------------
SELECT Type = 'XClassComponent.SelectStatement (SqlQuery)',
       Titel = CMP.ClassName + ' - SqlQuery: ' + CMP.ComponentName
FROM dbo.XClassComponent CMP WITH (READUNCOMMITTED)
WHERE TypeName = 'KiSS4.DB.SqlQuery' AND 
      CMP.SelectStatement LIKE '%' + @SearchString + '%'

UNION

SELECT Type = 'XClassComponent.ComponentName',
       Titel = CMP.ClassName + ' - ComponentName: ' + CMP.ComponentName
FROM dbo.XClassComponent CMP WITH (READUNCOMMITTED)
WHERE CMP.ComponentName LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XClassReference
---------------------------------------
SELECT Type = 'XClassReference.ClassName||ClassName_Ref',
       Titel = REF.ClassName + ' >> ' + REF.ClassName_Ref
FROM dbo.XClassReference REF WITH (READUNCOMMITTED)
WHERE REF.ClassName LIKE '%' + @SearchString + '%' OR 
      REF.ClassName_Ref LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XLOV
---------------------------------------
SELECT Type = 'XLOV.LOVName||Description', 
       Titel = LOV.LOVName
FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName LIKE '%' + @SearchString + '%' OR
      LOV.Description LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XLOVCode
---------------------------------------
SELECT Type = 'XLOVCode.LOVName||Text', 
       Titel = LOV.LOVName + ' - Text: ' + LOV.Text
FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName LIKE '%' + @SearchString + '%' OR
      LOV.Text LIKE '%' + @SearchString + '%'

UNION

SELECT Type = 'XLOVCode.Value1 ("ModulTree")', 
       Titel = LOC.LOVName
FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
WHERE LOC.LOVName = 'ModulTree'
  AND LOC.Value1 LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XLangText
---------------------------------------
SELECT Type = 'XLangText.Text (XMessage)', 
       Titel = MSG.Maskname + ' - ' + MSG.MessageName
FROM dbo.XMessage MSG WITH (READUNCOMMITTED)
  INNER JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = MSG.MessageTID AND 
                                                         TXT.LanguageCode = 1
WHERE TXT.Text LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XMenuItem
---------------------------------------
SELECT Type = 'XMenuItem.Caption', 
       Titel = MNU.Caption
FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
WHERE MNU.Caption LIKE '%' + @SearchString + '%'

UNION

SELECT Type = 'XMenuItem.ClassName', 
       Titel = MNU.ClassName
FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
WHERE MNU.ClassName LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XModulTree
---------------------------------------
SELECT Type = 'XModulTree.ClassName||MaskName',
       Titel = ISNULL('Class: ' + TRE.ClassName + '; ', '') + ISNULL('Mask: ' + TRE.MaskName, '')
FROM dbo.XModulTree TRE WITH (READUNCOMMITTED)
WHERE TRE.ClassName LIKE '%' + @SearchString + '%' OR 
      TRE.MaskName LIKE '%' + @SearchString + '%'

UNION

SELECT Type = 'XModulTree.sqlPreExecute||sqlInsertTreeItem',
       Titel = TRE.ClassName
FROM dbo.XModulTree TRE WITH (READUNCOMMITTED)
WHERE TRE.sqlPreExecute LIKE '%' + @SearchString + '%' OR 
      TRE.sqlInsertTreeItem LIKE '%' + @SearchString + '%'
      
UNION

---------------------------------------
-- XBookmark
---------------------------------------
SELECT Type = 'XBookmark.Category||BookmarkName||TableName||Description||SQL',
       Titel = ISNULL(BMK.BookmarkName, '<no name>') + ISNULL(' - Category: ' + BMK.Category, '')
FROM dbo.XBookmark BMK WITH (READUNCOMMITTED)
WHERE BMK.Category LIKE '%' + @SearchString + '%' OR 
      BMK.BookmarkName LIKE '%' + @SearchString + '%' OR 
      BMK.TableName LIKE '%' + @SearchString + '%' OR 
      BMK.Description LIKE '%' + @SearchString + '%' OR 
      BMK.SQL LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- BgPositionsart
---------------------------------------
SELECT Type = 'BgPositionsart.sqlRichtlinie',
       Titel = ISNULL(POA.Name, '<no name>')
FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED)
WHERE POA.sqlRichtlinie LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- BFSFrage
---------------------------------------
SELECT Type = 'BFSFrage.HerkunftSQL',
       Titel = ISNULL(FRG.Variable, '<no var>') + ISNULL(' - ' + FRG.Frage, '<no question>')
FROM dbo.BFSFrage FRG WITH (READUNCOMMITTED)
WHERE FRG.HerkunftSQL LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- XQuery
---------------------------------------
SELECT Type = 'XQuery.SQLquery',
       Titel = ISNULL(QRY.QueryName, '<no name>')
FROM dbo.XQuery QRY WITH (READUNCOMMITTED)
WHERE QRY.SQLquery LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- DynaMask
---------------------------------------
SELECT Type = 'DynaMask.MaskName',
       Titel = DYM.MaskName
FROM dbo.DynaMask DYM WITH (READUNCOMMITTED)
WHERE DYM.MaskName LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- DynaField
---------------------------------------
SELECT Type = 'DynaField.SQL',
       Titel = ISNULL(DYF.MaskName, '<no maskname>') + ISNULL('.' + DYF.FieldName, '<no fieldname>')
FROM dbo.DynaField DYF WITH (READUNCOMMITTED)
WHERE DYF.SQL LIKE '%' + @SearchString + '%'

UNION

SELECT Type = 'DynaField.FieldName',
       Titel = ISNULL(DYF.MaskName, '<no maskname>') + ISNULL('.' + DYF.FieldName, '<no fieldname>')
FROM dbo.DynaField DYF WITH (READUNCOMMITTED)
WHERE DYF.FieldName LIKE '%' + @SearchString + '%'

UNION

---------------------------------------
-- db-object within current database
---------------------------------------
SELECT DISTINCT
       Type = 'Database.DBOs',
       Titel = CASE 
                 WHEN OBJ.xtype IN ('V', 'FN', 'TF', 'P') THEN ISNULL(OBJ.xtype, '') + ISNULL(': ' + OBJ.[name], '')
                 ELSE ISNULL(OBJ.xtype, '') + ISNULL(': ' + OBJ.[name], '') + ISNULL(' - ' + COL.[name], '')
               END                    
FROM syscolumns         COL
  LEFT JOIN systypes    TYP ON TYP.xtype = COL.xtype
  LEFT JOIN sysobjects  OBJ ON OBJ.[id] = COL.[id]
  LEFT JOIN syscomments COM ON COM.[id] = COL.[id]
WHERE OBJ.[name] LIKE '%' + @SearchString + '%' OR    -- find table
      COL.[name] LIKE '%' + @SearchString + '%' OR    -- find column
      COM.[text] LIKE '%' + @SearchString + '%'       -- find code
      
---------------------------------------
-- do some general ordering
---------------------------------------
ORDER BY Type, Titel;