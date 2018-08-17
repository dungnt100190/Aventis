SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Create KiSS4_TestDB/02_spDropObject.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:48 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Create KiSS4_TestDB/02_spDropObject.sql $
 * 
 * 2     25.06.09 11:44 Ckaeser
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spDropObject
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:28
*/
CREATE PROCEDURE dbo.spDropObject
 (@MainObjectName  varchar(776),
  @ObjectName      varchar(776) = NULL)
AS BEGIN
  SET NOCOUNT ON

  DECLARE  @SQL       varchar(512)
  DECLARE  @xtype     varchar(2)

  IF CHARINDEX('.#', @MainObjectName) > 0 OR CHARINDEX('#', @MainObjectName) = 1 BEGIN
    SELECT @xtype = CASE
                      WHEN @ObjectName IS NULL   THEN OBJ.xtype
                      WHEN SUB.xtype IS NOT NULL THEN SUB.xtype
                      WHEN IDX.id IS NOT NULL    THEN 'IX'
                    END
    FROM tempdb..sysobjects         OBJ
      LEFT JOIN tempdb..sysobjects  SUB ON SUB.parent_obj = OBJ.id AND SUB.id = OBJECT_ID(@ObjectName)
      LEFT JOIN tempdb..sysindexes  IDX ON IDX.id         = OBJ.id AND IDX.name = @ObjectName
    WHERE OBJ.id = OBJECT_ID(@MainObjectName)

    SET @MainObjectName = SubString(@MainObjectName, CHARINDEX('#', @MainObjectName), 1000)
  END ELSE BEGIN
    SELECT @xtype = CASE
                      WHEN @ObjectName IS NULL   THEN OBJ.xtype
                      WHEN SUB.xtype IS NOT NULL THEN SUB.xtype
                      WHEN IDX.id IS NOT NULL    THEN 'IX'
                    END
    FROM sysobjects                 OBJ
      LEFT JOIN sysobjects          SUB ON SUB.parent_obj = OBJ.id AND SUB.id = OBJECT_ID(@ObjectName)
      LEFT JOIN sysindexes          IDX ON IDX.id         = OBJ.id AND IDX.name = @ObjectName
    WHERE OBJ.id = OBJECT_ID(@MainObjectName)

    IF @xtype IN ('U') BEGIN
      SET @SQL = 'EXECUTE spDropTableRef ''' + @MainObjectName + ''''
      EXECUTE (@SQL)
    END
  END

  SET @SQL = CASE @xtype
               WHEN 'U'  THEN 'DROP TABLE '     + @MainObjectName  -- User table
               WHEN 'TR' THEN 'DROP TRIGGER '   + @MainObjectName  -- Trigger

               WHEN 'V'  THEN 'DROP VIEW '      + @MainObjectName  -- View

               WHEN 'P'  THEN 'DROP PROCEDURE ' + @MainObjectName  -- Stored procedure

               WHEN 'FN' THEN 'DROP FUNCTION '  + @MainObjectName  -- Scalar function
               WHEN 'TF' THEN 'DROP FUNCTION '  + @MainObjectName  -- Table function
               WHEN 'IF' THEN 'DROP FUNCTION '  + @MainObjectName  -- Inlined table-function

               WHEN 'PK' THEN 'ALTER TABLE '    + @MainObjectName + ' DROP CONSTRAINT ' + @ObjectName  -- PrimaryKey
               WHEN 'D'  THEN 'ALTER TABLE '    + @MainObjectName + ' DROP CONSTRAINT ' + @ObjectName  -- Default or DEFAULT constraint
               WHEN 'UQ' THEN 'ALTER TABLE '    + @MainObjectName + ' DROP CONSTRAINT ' + @ObjectName
               WHEN 'C'  THEN 'ALTER TABLE '    + @MainObjectName + ' DROP CONSTRAINT ' + @ObjectName  -- CHECK constraint

               WHEN 'F'  THEN 'ALTER TABLE '    + @MainObjectName + ' DROP CONSTRAINT ' + @ObjectName  -- FOREIGN KEY constraint

               WHEN 'IX' THEN 'DROP INDEX '     + @MainObjectName + '.' + @ObjectName


               WHEN 'K'  THEN NULL  -- PRIMARY KEY or UNIQUE constraint

               WHEN 'L'  THEN NULL  -- Log
               WHEN 'R'  THEN NULL  -- Rule
               WHEN 'RF' THEN NULL  -- replication filter stored procedure

               WHEN 'S'  THEN NULL  -- System table
               WHEN 'X'  THEN NULL  -- Extended stored procedure

               ELSE           NULL
             END

  IF NOT @SQL IS NULL BEGIN
    PRINT '  - ' + @SQL
    EXECUTE (@SQL)
  END
END

GO