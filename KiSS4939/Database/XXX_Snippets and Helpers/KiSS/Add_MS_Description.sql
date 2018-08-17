/*------------------------------------------------------------------------------------------------------------
SELEKTIERT ALLE SPALTEN ALLER USER-TABELLEN (ausser _OLD_xyz Tabellen)
-------------------------------------------------------------------------------------------------------------*/
DROP TABLE #TabellenSpalten
DROP TABLE #PrimaryKeys
DROP TABLE #ForeignKeys

-- 'Config' Section
DECLARE @DeleteEmpty BIT
DECLARE @InsertDefault BIT
DECLARE @InsertEmpty BIT

-- Variablen
DECLARE @TabellenName   VARCHAR(100)
DECLARE @SpaltenName    VARCHAR(100)
DECLARE @MS_Description VARCHAR(5000)
DECLARE @Remarks VARCHAR(5000)
DECLARE @Example VARCHAR(5000)
DECLARE @IsPrimaryKey int
DECLARE @ForeignKeyName VARCHAR(5000)
DECLARE @ForeignKeyTableName VARCHAR(5000)
DECLARE @ForeignKeyFieldName VARCHAR(5000)

-- Presets
SET @DeleteEmpty = 1
SET @InsertDefault = 1
SET @InsertEmpty = 1

-- Fügt alle Tabellenspalten ausser (_OLD_ Tabellen) 
-- in temporär-Tabelle #TabellenSpalten

SELECT 
  TabellenName = TBL.name, 
  SpaltenName  = COL.name
INTO #TabellenSpalten
FROM sysobjects  TBL
  INNER JOIN syscolumns COL ON COL.id = TBL.id
WHERE TBL.xtype = 'U' AND TBL.name NOT IN ('dtproperties', 'sysdiagrams') 
  AND TBL.name NOT LIKE '_OLD_%'
ORDER BY TBL.name, COL.name

-- Fügt alle Primary Key Spalten 
-- in temporär-Tabelle #PrimaryKeys

SELECT
  TableName = TBL.name, 
  FieldName = COL.name,
  PKey         = CASE WHEN IDX.status & 2050 = 2050 THEN 1 ELSE 0 END
INTO #PrimaryKeys 
FROM sysobjects             TBL
  INNER JOIN syscolumns     COL ON TBL.id    = COL.id
  INNER JOIN systypes       TYP ON TYP.xtype = COL.xtype    AND TYP.usertype = COL.usertype
  LEFT  JOIN syscomments    COM ON COM.id    = COL.cdefault AND COM.colid = 1
  INNER JOIN sysindexes     IDX ON IDX.id = TBL.id
  INNER JOIN sysindexkeys   IDK ON IDK.id = TBL.id AND IDK.indid = IDX.indid AND IDK.colid = COL.colid
WHERE TBL.xtype = 'U' AND TBL.name != 'dtproperties' AND IDX.name NOT LIKE '_WA_Sys_%'

-- Fügt alle Foreign Key Spalten 
-- in temporär-Tabelle #ForeignKeys

SELECT DISTINCT
	FKSn.name AS ForeignKeyName,
	rTBL.name AS rTableName, 
	rCOL.name AS rFieldName,
	fTBL.name AS fTableName, 
	fCOL.name AS fFieldName
INTO #ForeignKeys
FROM sysforeignkeys       FKS
  INNER JOIN sysobjects   FKSn ON FKS.constid = FKSn.id
  INNER JOIN sysobjects   rTBL ON FKS.rkeyid = rTBL.id
  INNER JOIN syscolumns   rCOL ON rTBL.id    = rCOL.id AND FKS.rkey = rCOL.colid
  INNER JOIN sysobjects   fTBL ON FKS.fkeyid = fTBL.id
  INNER JOIN syscolumns   fCOL ON fTBL.id    = fCOL.id AND FKS.fkey = fCOL.colid

-- Loop über alle Tabellen-Spalten
DECLARE cTabellenSpalten CURSOR FAST_FORWARD FOR
  SELECT TabellenName, SpaltenName
  FROM #TabellenSpalten TSP

OPEN cTabellenSpalten
WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cTabellenSpalten INTO @TabellenName, @SpaltenName
  IF @@FETCH_STATUS < 0 BREAK

  SET @IsPrimaryKey = 0
  SET @MS_Description = NULL
  SET @Remarks = NULL
  SET @Example = NULL
  SET @ForeignKeyName = ''
  SET @ForeignKeyTableName = ''
  SET @ForeignKeyFieldName = ''

  -- Löscht leere Properties
  IF @DeleteEmpty = 1
  BEGIN
	-- MS_DESCRIPTION
	SELECT @MS_Description = CONVERT(varchar, value)
	FROM ::fn_listextendedproperty ('MS_Description', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName)

	IF IsNull(@MS_Description, '') = '' AND @MS_Description is not null
	BEGIN
		EXEC sp_dropextendedproperty 'MS_Description', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName
	END

	-- Remarks
	
	SELECT @Remarks = CONVERT(varchar, value)
	FROM ::fn_listextendedproperty ('Remarks', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName)

	IF IsNull(@Remarks, '') = '' AND @Remarks IS NOT NULL
	BEGIN
		EXEC sp_dropextendedproperty 'Remarks', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName
	END

	-- Example
	SELECT @Example = CONVERT(varchar, value)
	FROM ::fn_listextendedproperty ('Example', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName)

	IF IsNull(@Example, '') = '' AND @Example IS NOT NULL
	BEGIN
		EXEC sp_dropextendedproperty 'Example', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName
	END
  END

  -- Fügt Standard MS_Description ein (PK,FK)
  IF @InsertDefault = 1
  BEGIN
	IF NOT EXISTS(
		SELECT CONVERT(varchar, value)
		FROM ::fn_listextendedproperty ('MS_Description', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName)
	) 
	BEGIN	
	  -- überprüft ob Kolonne Primary Key ist	
	  SELECT @IsPrimaryKey = PKey FROM #PrimaryKeys WHERE TableName = @TabellenName AND FieldName = @SpaltenName

	  IF @IsPrimaryKey = 1
	  BEGIN
		SET @MS_Description = 'Primärschlüssel für ' + @TabellenName + ' Records (nach Primärschlüssel-Standards)'
	  END
	  ELSE BEGIN
		-- vieleicht ist es ein foreign key?
		SELECT @ForeignKeyName = ForeignKeyName, @ForeignKeyTableName = rTableName, @ForeignKeyFieldName = rFieldName from #ForeignKeys where fTableName = @TabellenName AND fFieldName = @SpaltenName

		IF NOT IsNull(@ForeignKeyName, '') = '' BEGIN
			SET @MS_Description = 'Fremdschlüssel (' + @ForeignKeyName + ') => ' +  @ForeignKeyTableName + '.' + @ForeignKeyFieldName
		END
	  END  

	  IF NOT IsNull(@MS_Description, '') = '' BEGIN
		 EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=@MS_Description , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=@TabellenName, @level2type=N'COLUMN',@level2name=@SpaltenName
	  END	
	END
  END

  -- Fügt leere Properties hinzu
  IF (@InsertEmpty = 1)
  BEGIN
	-- MS_DESCRIPTION
    IF NOT EXISTS(SELECT 1
                  FROM ::fn_listextendedproperty ('MS_Description', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName))
    BEGIN
	  print @TabellenName + '.' + @SpaltenName + ' - Add Empty Description'
      EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=@TabellenName, @level2type=N'COLUMN',@level2name=@SpaltenName
    END
	-- Remarks
    IF NOT EXISTS(SELECT 1
                  FROM ::fn_listextendedproperty ('Remarks', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName))
    BEGIN
	  print @TabellenName + '.' + @SpaltenName + ' - Add Empty Remarks'
      EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=@TabellenName, @level2type=N'COLUMN',@level2name=@SpaltenName
    END
	-- Example
    IF NOT EXISTS(SELECT 1
                  FROM ::fn_listextendedproperty ('Example', 'user', 'dbo', 'table', @TabellenName, 'column', @SpaltenName))
    BEGIN
      print @TabellenName + '.' + @SpaltenName + ' - Add Empty Example'
      EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=@TabellenName, @level2type=N'COLUMN',@level2name=@SpaltenName
    END

  END
 END
DEALLOCATE cTabellenSpalten
GO
