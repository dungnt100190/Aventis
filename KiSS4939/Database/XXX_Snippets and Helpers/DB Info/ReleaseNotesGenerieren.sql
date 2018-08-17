/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Skript um die Releasnotes zu generieren
  -

  Wichtig: Die Variabeln @VersionAlt und @VersionNeu müssen definiert werden.
=================================================================================================*/


DECLARE @VersionAlt VARCHAR(255);
DECLARE @VersionNeu VARCHAR(255);

-- -----------------------------------------------------------------------------
-- #0000-679 Releasenotes generieren per Script
-- -----------------------------------------------------------------------------
-- notwendige Definitionen
-- -----------------------------------------------------------------------------
SET @VersionAlt = 'R4544';
SET @VersionNeu = 'R4606';
-- -----------------------------------------------------------------------------
-- -----------------------------------------------------------------------------

DECLARE @temp TABLE (
  Kunde VARCHAR(20),
  ID VARCHAR(200),
  Typ VARCHAR(200),
  Name VARCHAR(200),
  Beschreibung VARCHAR(1000),
  Korrektur VARCHAR(MAX)
)

DECLARE @Sql NVARCHAR(4000);
DECLARE @Kunde VARCHAR(20);
DECLARE @DbAlt VARCHAR(255);
DECLARE @DbNeu VARCHAR(255);

IF @@SERVERNAME LIKE 'bisrv1029%'
BEGIN
  DECLARE curKunde CURSOR FAST_FORWARD FOR 
    SELECT Kunde = 'BSS_TestRelease_' UNION
    SELECT Kunde = 'CAR_Prod_' UNION
    SELECT Kunde = 'Standard_' UNION
    SELECT Kunde = 'WOH_Prod_';
END
ELSE IF @@SERVERNAME LIKE 'bisrv1028'
BEGIN
  DECLARE curKunde CURSOR FAST_FORWARD FOR 
    SELECT Kunde = 'Standard_' UNION
    SELECT Kunde = 'PI_PROD_';
END
ELSE IF @@SERVERNAME LIKE 'SZHM9301%'
BEGIN
DECLARE curKunde CURSOR FAST_FORWARD FOR 
  SELECT Kunde = 'ZH_Dev_'
END;

OPEN curKunde;
WHILE 1=1
BEGIN
  FETCH NEXT FROM curKunde INTO @Kunde;
  IF @@FETCH_STATUS != 0 BREAK;

  SET @DbAlt = 'KISS_' + @Kunde + @VersionAlt;
  SET @DbNeu = 'KISS_' + @Kunde + @VersionNeu;
  
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  VALUES (@Kunde, NULL, NULL, NULL, NULL, NULL);

  IF NOT EXISTS (
    SELECT TOP 1 1 Name FROM sys.sysdatabases
    WHERE Name = @DbAlt) 
  BEGIN
    INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
    VALUES (@Kunde, NULL, NULL, NULL, 'Die Datenbank "' + @DbAlt + '" existiert nicht.', NULL);
  END 
  ELSE
  IF NOT EXISTS (
    SELECT TOP 1 1 Name FROM sys.sysdatabases
    WHERE Name = @DbNeu) 
  BEGIN
    INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
    VALUES (@Kunde, NULL, NULL, NULL, 'Die Datenbank "' + @DbNeu + '" existiert nicht.', NULL);
  END ELSE
  BEGIN

    -- -----------------------------------------------------------------------------
    -- Kontrollieren, ob das Feld XRight.Description schon existiert
    -- -----------------------------------------------------------------------------
    DECLARE @XRight_Description_Existiert BIT;
    DECLARE @ParamDefinition NVARCHAR(500);
    SET @ParamDefinition = N'@XRight_Description_ExistiertOUT BIT OUTPUT';
    SET @XRight_Description_Existiert = 0;
    SET @Sql = N'
    IF EXISTS(
      SELECT TOP 1 1 FROM ' + @DbAlt + '.sys.columns
      WHERE object_id = (
        SELECT object_id FROM ' + @DbAlt + '.sys.objects
        WHERE name = ''XRight'' AND type = ''U''
      )
      AND name = ''Description''
    ) 
    BEGIN
      SELECT @XRight_Description_ExistiertOUT = 1;
    END ELSE BEGIN
      SELECT @XRight_Description_ExistiertOUT = 0;
    END;'
    EXEC sys.sp_executesql @Sql, @ParamDefinition, @XRight_Description_ExistiertOUT=@XRight_Description_Existiert OUTPUT;


    -- -----------------------------------------------------------------------------
    -- Gelöschte Rechte 
    -- -----------------------------------------------------------------------------
    SET @Sql = N'
    SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(200), R.RightID), ''Rechte gelöscht'', R.RightName, ' + 
      CASE WHEN @XRight_Description_Existiert = 1 
        THEN 'Description = R.UserText + '' '' + R.Description'
        ELSE 'Description = ''[XRight.Description nicht vorhanden]''' 
      END + ', NULL FROM ' + @DbAlt + '.dbo.XRight R
    WHERE NOT EXISTS (
      SELECT top 1 A.RightID FROM ' + @DbNeu + '.dbo.XRight A
      WHERE A.RightID = R.RightID )
    ORDER BY R.RightName';
    PRINT @Sql;
    INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
    EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Neue Rechte 
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(200), R.RightID), ''Recht neu'', R.RightName, R.UserText + '' '' + R.Description, NULL FROM ' + @DbNeu + '.dbo.XRight R
  WHERE NOT EXISTS (
    SELECT top 1 A.RightID FROM ' + @DbAlt + '.dbo.XRight A
    WHERE A.RightID = R.RightID )
  ORDER BY R.RightName';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Geänderte Rechte 
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(200), R.RightID), ''Recht geändert'', R.RightName, R.UserText + '' '' + R.Description, 
  CASE WHEN A.ClassName != R.ClassName 
    THEN ''ClassName alt: '' + ISNULL(A.ClassName, ''[leer]'') + '', neu: '' + ISNULL(R.ClassName, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.RightName != R.RightName 
    THEN ''RightName alt: '' + ISNULL(A.RightName, ''[leer]'') + '', neu: '' + ISNULL(R.RightName, ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.UserText != R.UserText 
    THEN ''UserText alt: '' + ISNULL(A.UserText, ''[leer]'') + '', neu: '' + ISNULL(R.UserText, ''[leer]'')
    ELSE ''''
  END  
  FROM ' + @DbNeu + '.dbo.XRight R
  INNER JOIN ' + @DbAlt + '.dbo.XRight A ON A.RightID = R.RightID
  WHERE A.ClassName != R.ClassName
     OR A.RightName != R.RightName
     OR A.UserText != R.UserText
  ORDER BY R.RightName';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Gelöschte Konfiguration
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT
    ''' + @Kunde + ''',
    CONVERT(VARCHAR(200), ALT.XConfigID),
    ''Konfiguration gelöscht'',
    ALT.KeyPath,
    CONVERT(VARCHAR(200), ISNULL(ALT.Description, '''')) + '': '' + CONVERT(VARCHAR(200), ISNULL(' + @DbAlt + '.dbo.fnXConfig(ALT.KeyPath, ALT.DatumVon), '','')),
    NULL
  FROM ' + @DbAlt + '.dbo.XConfig ALT
  WHERE NOT EXISTS (SELECT TOP 1 NEU.XConfigID
                    FROM ' + @DbNeu + '.dbo.XConfig NEU
                    WHERE NEU.XConfigID = ALT.XConfigID)
  ORDER BY ALT.KeyPath;';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
    EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Neue Konfiguration
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT
    ''' + @Kunde + ''',
    CONVERT(VARCHAR(200), NEU.XConfigID),
    ''Konfiguration neu'',
    NEU.KeyPath,
    CONVERT(VARCHAR(200), ISNULL(NEU.Description, '''')) + '': '' + CONVERT(VARCHAR(200), ISNULL(' + @DbNeu + '.dbo.fnXConfig(NEU.KeyPath, NEU.DatumVon), '''')),
    NULL
  FROM ' + @DbNeu + '.dbo.XConfig NEU
  WHERE NOT EXISTS (SELECT TOP 1 ALT.XConfigID
                    FROM ' + @DbAlt + '.dbo.XConfig ALT
                    WHERE ALT.XConfigID = NEU.XConfigID)
  ORDER BY NEU.KeyPath;';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Geänderte Konfiguration 
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT
    ''' + @Kunde + ''',
    CONVERT(VARCHAR(200), R.XConfigID),
    ''Konfiguration geändert'',
    R.KeyPath,
    CONVERT(VARCHAR(200), ISNULL(R.Description, '''')) + '': '' + COALESCE(CONVERT(VARCHAR(200), R.ValueBit), CONVERT(VARCHAR(200), R.ValueDateTime), CONVERT(VARCHAR(200), R.ValueDecimal), CONVERT(VARCHAR(200), R.ValueInt), CONVERT(VARCHAR(200), R.ValueMoney), CONVERT(VARCHAR(200), R.ValueVarchar), ''''),
    CASE
      WHEN A.XNamespaceExtensionID != R.XNamespaceExtensionID 
        THEN ''XNamespaceExtensionID alt: '' + ISNULL(CONVERT(VARCHAR(200), A.XNamespaceExtensionID), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(200), R.XNamespaceExtensionID), ''[leer]'') + '' / '' 
      ELSE ''''
    END +
    CASE
      WHEN A.KeyPath != R.KeyPath 
        THEN ''KeyPath alt: '' + ISNULL(CONVERT(VARCHAR(200), A.KeyPath), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(200), R.KeyPath), ''[leer]'') + '' / '' 
      ELSE ''''
    END +  
    CASE
      WHEN A.System != R.System 
        THEN ''System alt: '' + ISNULL(CONVERT(VARCHAR(200), A.System), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(200), R.System), ''[leer]'') + '' / '' 
      ELSE ''''
    END +  
    CASE
      WHEN A.DatumVon != R.DatumVon 
        THEN ''DatumVon alt: '' + ISNULL(CONVERT(VARCHAR(200), A.DatumVon, 104), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(200), R.DatumVon, 104), ''[leer]'') + '' / '' 
      ELSE ''''
    END +  
    CASE
      WHEN A.ValueCode != R.ValueCode 
        THEN ''ValueCode alt: '' + ISNULL(CONVERT(VARCHAR(200), A.ValueCode), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(200), R.ValueCode), ''[leer]'') + '' / '' 
      ELSE ''''
    END +
    CASE
      WHEN ' + @DbAlt + '.dbo.fnXConfig(A.KeyPath, A.DatumVon) != ' + @DbNeu + '.dbo.fnXConfig(R.KeyPath, R.DatumVon)
        THEN ''Wert alt: '' + ISNULL(CONVERT(VARCHAR(MAX), ' + @DbAlt + '.dbo.fnXConfig(A.KeyPath, A.DatumVon)), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(MAX), ' + @DbNeu + '.dbo.fnXConfig(R.KeyPath, R.DatumVon)), ''[leer]'') + '' / '' 
      ELSE ''''
    END +
    CASE
      WHEN A.Description != R.Description 
        THEN ''Description alt: '' + ISNULL(A.Description, ''[leer]'') + '', neu: '' + ISNULL(R.Description, ''[leer]'') + '' / '' 
      ELSE ''''
    END
  FROM ' + @DbNeu + '.dbo.XConfig R
    INNER JOIN ' + @DbAlt + '.dbo.XConfig A ON A.XConfigID = R.XConfigID
  WHERE R.KeyPath != ''System\Allgemein\DbName''
    AND (A.XNamespaceExtensionID != R.XNamespaceExtensionID OR
         A.KeyPath != R.KeyPath OR
         A.System != R.System OR
         A.DatumVon != R.DatumVon OR
         A.ValueCode != R.ValueCode OR
         CONVERT(VARCHAR, ' + @DbAlt + '.dbo.fnXConfig(A.KeyPath, A.DatumVon)) != CONVERT(VARCHAR, ' + @DbNeu + '.dbo.fnXConfig(R.KeyPath, R.DatumVon)) OR
         A.Description != R.Description)
  ORDER BY R.KeyPath;';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Gelöschte XLovCode
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', R.LOVName + ''.'' + CONVERT(VARCHAR(200), R.Code), ''LOV gelöscht'', R.Text, R.Description, NULL 
  FROM ' + @DbAlt + '.dbo.XLovCode R
  WHERE NOT EXISTS (
    SELECT top 1 A.Code FROM ' + @DbNeu + '.dbo.XLovCode A
    WHERE A.LOVName = R.LOVName AND A.Code = R.Code )
  ORDER BY R.LOVName, R.Code';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Neue XLovCode
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', R.LOVName + ''.'' + CONVERT(VARCHAR(200), R.Code), ''LOV neu'', R.Text, R.Description, NULL 
  FROM ' + @DbNeu + '.dbo.XLovCode R
  WHERE NOT EXISTS (
    SELECT top 1 A.Code FROM ' + @DbAlt + '.dbo.XLovCode A
    WHERE A.LOVName = R.LOVName AND A.Code = R.Code )
    ORDER BY R.LOVName, R.Code';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;

  
  -- -----------------------------------------------------------------------------
  -- Geänderte LovCode 
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', R.LOVName + ''.'' + CONVERT(VARCHAR(200), R.Code), ''LOV geändert'', R.Text, R.Description, 
  CASE WHEN A.Text != R.Text 
    THEN ''Text alt: '' + ISNULL(A.Text, ''[leer]'') + '', neu: '' + ISNULL(R.Text, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.SortKey != R.SortKey 
    THEN ''SortKey alt: '' + ISNULL(CONVERT(VARCHAR(20), A.SortKey), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.SortKey), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.ShortText != R.ShortText 
    THEN ''ShortText alt: '' + ISNULL(A.ShortText, ''[leer]'') + '', neu: '' + ISNULL(R.ShortText, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.BFSCode != R.BFSCode 
    THEN ''BFSCode alt: '' + ISNULL(CONVERT(VARCHAR(20), A.BFSCode), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.BFSCode), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.Value1 != R.Value1 
    THEN ''Value1 alt: '' + ISNULL(A.Value1, ''[leer]'') + '', neu: '' + ISNULL(R.Value1, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.Value2 != R.Value2 
    THEN ''Value2 alt: '' + ISNULL(A.Value2, ''[leer]'') + '', neu: '' + ISNULL(R.Value2, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.Value3 != R.Value3 
    THEN ''Value3 alt: '' + ISNULL(A.Value3, ''[leer]'') + '', neu: '' + ISNULL(R.Value3, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.System != R.System 
    THEN ''System alt: '' + ISNULL(CONVERT(VARCHAR(20), A.System), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.System), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.LOVCodeName != R.LOVCodeName 
    THEN ''LOVCodeName alt: '' + ISNULL(A.LOVCodeName, ''[leer]'') + '', neu: '' + ISNULL(R.LOVCodeName, ''[leer]'')
    ELSE ''''
  END  
  FROM ' + @DbNeu + '.dbo.XLovCode R
  INNER JOIN ' + @DbAlt + '.dbo.XLovCode A ON A.LOVName = R.LOVName AND  A.Code = R.Code
  WHERE A.Text != R.Text
     OR A.SortKey != R.SortKey
     OR A.ShortText != R.ShortText
     OR A.BFSCode != R.BFSCode
     OR A.Value1 != R.Value1
     OR A.Value2 != R.Value2
     OR A.Value3 != R.Value3
     OR A.System != R.SYSTEM
     OR A.LOVCodeName != R.LOVCodeName
  ORDER BY R.LOVName, R.Code';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;
  
  
  -- -----------------------------------------------------------------------------
  -- Gelöschte XClass
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', R.ClassName, ''Class gelöscht'', ISNULL(MDL.ShortName + '' - '', '''') + ISNULL(R.MaskName, ''''), NULL, NULL 
  FROM ' + @DbAlt + '.dbo.XClass R
    LEFT JOIN ' + @DbAlt + '.dbo.XModul MDL WITH (READUNCOMMITTED) ON MDL.ModulID = R.ModulID
  WHERE NOT EXISTS (
    SELECT top 1 A.ClassName FROM ' + @DbNeu + '.dbo.XClass A
    WHERE A.ClassName = R.ClassName)
  ORDER BY R.ClassName, R.Maskname';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Neue XClass
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', R.ClassName, ''Class neu'', ISNULL(MDL.ShortName + '' - '', '''') + ISNULL(R.MaskName, ''''), NULL, NULL 
  FROM ' + @DbNeu + '.dbo.XClass R
    LEFT JOIN ' + @DbNeu + '.dbo.XModul MDL WITH (READUNCOMMITTED) ON MDL.ModulID = R.ModulID
  WHERE NOT EXISTS (
    SELECT top 1 A.ClassName FROM ' + @DbAlt + '.dbo.XClass A
    WHERE A.ClassName = R.ClassName)
  ORDER BY R.ClassName, R.Maskname';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;
  
  
  -- -----------------------------------------------------------------------------
  -- Geänderte XClass 
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  SELECT ''' + @Kunde + ''', R.ClassName, ''Class geändert'', ISNULL(MDL.ShortName + '' - '', '''') + ISNULL(R.MaskName, ''''), NULL, 
  CASE WHEN A.MaskName != R.MaskName 
    THEN ''MaskName alt: '' + ISNULL(A.MaskName, ''[leer]'') + '', neu: '' + ISNULL(R.MaskName, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.BaseType != R.BaseType 
    THEN ''BaseType alt: '' + ISNULL(A.BaseType, ''[leer]'') + '', neu: '' + ISNULL(R.BaseType, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.ClassCode != R.ClassCode 
    THEN ''ClassCode alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ClassCode), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ClassCode), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.ClassTID != R.ClassTID 
    THEN ''ClassTID alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ClassTID), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ClassTID), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN CONVERT(VARCHAR(MAX), A.PropertiesXML) != CONVERT(VARCHAR(MAX), R.PropertiesXML) 
    THEN ''PropertiesXML alt: '' + ISNULL(CONVERT(VARCHAR(MAX), A.PropertiesXML), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(MAX), R.PropertiesXML), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.Designer != R.Designer 
    THEN ''Designer alt: '' + ISNULL(CONVERT(VARCHAR(20), A.Designer), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.Designer), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN CONVERT(VARCHAR(MAX), A.CodeGenerated) != CONVERT(VARCHAR(MAX), R.CodeGenerated) 
    THEN ''CodeGenerated alt: '' + ISNULL(CONVERT(VARCHAR(MAX), A.CodeGenerated), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(MAX), R.CodeGenerated), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.Branch != R.Branch 
    THEN ''Branch alt: '' + ISNULL(CONVERT(VARCHAR(MAX), A.Branch), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(MAX), R.Branch), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.BuildNr != R.BuildNr 
    THEN ''BuildNr alt: '' + ISNULL(CONVERT(VARCHAR(20), A.BuildNr), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.BuildNr), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.System != R.System 
    THEN ''System alt: '' + ISNULL(CONVERT(VARCHAR(20), A.System), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.System), ''[leer]'') + '' / '' 
    ELSE ''''
  END
  FROM ' + @DbNeu + '.dbo.XClass R
    LEFT  JOIN ' + @DbNeu + '.dbo.XModul MDL WITH (READUNCOMMITTED) ON MDL.ModulID = R.ModulID
    INNER JOIN ' + @DbAlt + '.dbo.XClass A ON A.ClassName = R.ClassName
  WHERE A.ModulID != R.ModulID
     OR A.MaskName != R.MaskName
     OR A.BaseType != R.BaseType
     OR A.ClassCode != R.ClassCode
     OR A.ClassTID != R.ClassTID
     OR CONVERT(VARCHAR(MAX), A.PropertiesXML) != CONVERT(VARCHAR(MAX), R.PropertiesXML)
     OR A.Designer != R.Designer
     OR CONVERT(VARCHAR(MAX), A.CodeGenerated) != CONVERT(VARCHAR(MAX), R.CodeGenerated)
     --OR A.Resource != R.Resource
     --OR A.Assembly != R.Assembly
     OR A.Branch != R.Branch
     OR A.BuildNr != R.BuildNr
     OR A.System != R.System
     --OR A.Checkout_UserID != R.Checkout_UserID
     --OR A.Checkout_Date != R.Checkout_Date
     OR A.NameSpaceExtension != R.NameSpaceExtension
  ORDER BY R.ClassName, R.Maskname';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;
    
  
  -- -----------------------------------------------------------------------------
  -- Gelöschte XMenuItem
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  WITH MenuItem_CTE (MenuItemID, ItemPath) AS (
    SELECT X.MenuItemID, ItemPath = CAST(X.Caption AS VARCHAR(MAX))
    FROM ' + @DbNeu + '.dbo.XMenuItem X WHERE X.ParentMenuItemID IS NULL
    UNION ALL
    SELECT X.MenuItemID, ItemPath = CTE.ItemPath + ''\'' + X.Caption
    FROM ' + @DbNeu + '.dbo.XMenuItem X
    INNER JOIN MenuItem_CTE CTE ON CTE.MenuItemID = X.ParentMenuItemID)
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(20), R.MenuItemID), ''MenuItem gelöscht'', R.Caption, CTE.ItemPath, NULL 
  FROM ' + @DbAlt + '.dbo.XMenuItem R
  LEFT JOIN MenuItem_CTE CTE ON R.MenuItemID = CTE.MenuItemID
  WHERE NOT EXISTS (
    SELECT top 1 A.ClassName FROM ' + @DbNeu + '.dbo.XMenuItem A
    WHERE A.MenuItemID = R.MenuItemID)
  ORDER BY R.ControlName';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Neue XMenuItem
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  WITH MenuItem_CTE (MenuItemID, ItemPath) AS (
    SELECT X.MenuItemID, ItemPath = CAST(X.Caption AS VARCHAR(MAX))
    FROM ' + @DbNeu + '.dbo.XMenuItem X WHERE X.ParentMenuItemID IS NULL
    UNION ALL
    SELECT X.MenuItemID, CTE.ItemPath + ''\'' + X.Caption
    FROM ' + @DbNeu + '.dbo.XMenuItem X
    INNER JOIN MenuItem_CTE CTE ON CTE.MenuItemID = X.ParentMenuItemID)
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(20), R.MenuItemID), ''MenuItem neu'', R.Caption, CTE.ItemPath, NULL 
  FROM ' + @DbNeu + '.dbo.XMenuItem R
  LEFT JOIN MenuItem_CTE CTE ON R.MenuItemID = CTE.MenuItemID
  WHERE NOT EXISTS (
    SELECT top 1 A.MenuItemID FROM ' + @DbAlt + '.dbo.XMenuItem A
    WHERE A.MenuItemID = R.MenuItemID)
  ORDER BY R.ControlName';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;
  
  
  -- -----------------------------------------------------------------------------
  -- Geänderte XMenuItem 
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  WITH MenuItem_CTE (MenuItemID, ItemPath) AS (
  SELECT X.MenuItemID, CAST(X.Caption AS VARCHAR(MAX))
  FROM ' + @DbNeu + '.dbo.XMenuItem X WHERE X.ParentMenuItemID IS NULL
  UNION ALL
  SELECT X.MenuItemID, CTE.ItemPath + ''\'' + X.Caption
  FROM ' + @DbNeu + '.dbo.XMenuItem X
  INNER JOIN MenuItem_CTE CTE ON CTE.MenuItemID = X.ParentMenuItemID)
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(20), R.MenuItemID), ''MenuItem geändert'', R.Caption, CTE.ItemPath, NULL
  FROM ' + @DbNeu + '.dbo.XMenuItem R
  INNER JOIN ' + @DbAlt + '.dbo.XMenuItem A ON A.MenuItemID = R.MenuItemID
  LEFT JOIN MenuItem_CTE CTE ON R.MenuItemID = CTE.MenuItemID
  WHERE A.ParentMenuItemID != R.ParentMenuItemID
  OR A.ControlName != R.ControlName
  OR A.BeginMenuGroup != R.BeginMenuGroup
  OR A.Enabled != R.Enabled
  OR A.Visible != R.Visible
  OR A.Caption != R.Caption
  OR A.ItemShortCutCtrl != R.ItemShortCutCtrl
  OR A.ItemShortCutShift != R.ItemShortCutShift
  OR A.ItemShortCutAlt != R.ItemShortCutAlt
  OR A.ItemShortCutKey != R.ItemShortCutKey
  OR A.ImageIndex != R.ImageIndex
  OR A.SortKey != R.SortKey
  OR A.ClassName != R.ClassName
  OR A.ShowInToolbar != R.ShowInToolbar
  OR A.BeginToolbarGroup != R.BeginToolbarGroup
  OR A.ToolbarSortKey != R.ToolbarSortKey
  OR A.System != R.System
  OR A.HideLockedItems != R.HideLockedItems
  OR CONVERT(VARCHAR(MAX), A.DESCRIPTION) != CONVERT(VARCHAR(MAX), R.DESCRIPTION)
  OR A.OnlyBIAGAdminVisible != R.OnlyBIAGAdminVisible';
  PRINT @Sql;
  PRINT CONVERT(VARCHAR(20), LEN(@Sql));
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;

    DECLARE @KorrText VARCHAR(MAX);
    DECLARE @ParamKorr NVARCHAR(500);
    DECLARE @Id VARCHAR(20);
    SET @ParamKorr = N'@KorrTextOUT VARCHAR(MAX) OUTPUT';
    DECLARE curKorr CURSOR FAST_FORWARD FOR 
      SELECT ID FROM @temp
      WHERE Typ = 'MenuItem geändert' AND Kunde = @Kunde;
    OPEN curKorr;
    WHILE 1=1
    BEGIN
      FETCH NEXT FROM curKorr INTO @Id;
      IF @@FETCH_STATUS != 0 BREAK;
  
    SET @KorrText = '';
      SET @Sql = N'
      SELECT @KorrTextOUT = 
      CASE WHEN A.BeginMenuGroup != R.BeginMenuGroup THEN ''BeginMenuGroup alt: '' + ISNULL(CONVERT(VARCHAR(20), A.BeginMenuGroup), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.BeginMenuGroup), ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ItemShortCutCtrl != R.ItemShortCutCtrl THEN ''ItemShortCutCtrl alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ItemShortCutCtrl), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ItemShortCutCtrl), ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ItemShortCutShift != R.ItemShortCutShift THEN ''ItemShortCutShift alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ItemShortCutShift), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ItemShortCutShift), ''[leer]'') + '' / '' ELSE '''' END + 
      CASE WHEN A.ItemShortCutAlt != R.ItemShortCutAlt THEN ''ItemShortCutAlt alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ItemShortCutAlt), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ItemShortCutAlt), ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ItemShortCutKey != R.ItemShortCutKey THEN ''ItemShortCutKey alt: '' + ISNULL(A.ItemShortCutKey, ''[leer]'') + '', neu: '' + ISNULL(R.ItemShortCutKey, ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ToolbarSortKey != R.ToolbarSortKey THEN ''ToolbarSortKey alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ToolbarSortKey), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ToolbarSortKey), ''[leer]'') + '' / '' ELSE '''' END +  
      CASE WHEN A.System != R.System THEN ''System alt: '' + ISNULL(CONVERT(VARCHAR(20), A.System), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.System), ''[leer]'') + '' / '' ELSE '''' END +  
      CASE WHEN A.HideLockedItems != R.HideLockedItems THEN ''HideLockedItems alt: '' + ISNULL(CONVERT(VARCHAR(20), A.HideLockedItems), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.HideLockedItems), ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ParentMenuItemID != R.ParentMenuItemID THEN ''ParentMenuItemID alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ParentMenuItemID), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ParentMenuItemID), ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ControlName != R.ControlName THEN ''ControlName alt: '' + ISNULL(A.ControlName, ''[leer]'') + '', neu: '' + ISNULL(R.ControlName, ''[leer]'') + '' / '' ELSE '''' END 
      FROM ' + @DbNeu + '.dbo.XMenuItem A 
      INNER JOIN ' + @DbAlt + '.dbo.XMenuItem R ON R.MenuItemID = A.MenuItemID
      WHERE A.MenuItemID = ' + @Id;
      PRINT @Sql;
    PRINT CONVERT(VARCHAR(20), LEN(@Sql));
      EXEC sys.sp_executesql @Sql, @ParamKorr, @KorrTextOUT=@KorrText OUTPUT;
      UPDATE @temp SET Korrektur = @KorrText
      WHERE ID = @Id AND Typ = 'MenuItem geändert' AND Kunde = @Kunde
      
    SET @KorrText = '';
      SET @Sql = N'
      SELECT @KorrTextOUT = 
      CASE WHEN A.Enabled != R.Enabled THEN ''Enabled alt: '' + ISNULL(CONVERT(VARCHAR(20), A.Enabled), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.Enabled), ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.Visible != R.Visible THEN ''Visible alt: '' + ISNULL(CONVERT(VARCHAR(20), A.Visible), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.Visible), ''[leer]'') + '' / '' ELSE '''' END +  
      CASE WHEN A.Caption != R.Caption THEN ''Caption alt: '' + ISNULL(A.Caption, ''[leer]'') + '', neu: '' + ISNULL(R.Caption, ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ImageIndex != R.ImageIndex THEN ''ImageIndex alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ImageIndex), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ImageIndex), ''[leer]'') + '' / '' ELSE '''' END +  
      CASE WHEN A.SortKey != R.SortKey THEN ''SortKey alt: '' + ISNULL(CONVERT(VARCHAR(20), A.SortKey), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.SortKey), ''[leer]'') + '' / '' ELSE '''' END +  
      CASE WHEN A.ClassName != R.ClassName THEN ''ClassName alt: '' + ISNULL(A.ClassName, ''[leer]'') + '', neu: '' + ISNULL(R.ClassName, ''[leer]'') + '' / '' ELSE '''' END +
      CASE WHEN A.ShowInToolbar != R.ShowInToolbar THEN ''ShowInToolbar alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ShowInToolbar), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ShowInToolbar), ''[leer]'') + '' / '' ELSE '''' END +  
      CASE WHEN A.BeginToolbarGroup != R.BeginToolbarGroup THEN ''BeginToolbarGroup alt: '' + ISNULL(CONVERT(VARCHAR(20), A.BeginToolbarGroup), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.BeginToolbarGroup), ''[leer]'') + '' / '' ELSE '''' END +  
      CASE WHEN CONVERT(VARCHAR(MAX), A.Description) != CONVERT(VARCHAR(MAX), R.Description) THEN ''Description alt: '' + CONVERT(VARCHAR(MAX), ISNULL(A.Description, ''[leer]'')) + '', neu: '' + CONVERT(VARCHAR(MAX), ISNULL(R.Description, ''[leer]'')) + '' / '' ELSE '''' END +
      CASE WHEN A.OnlyBIAGAdminVisible != R.OnlyBIAGAdminVisible THEN ''OnlyBIAGAdminVisible alt: '' + ISNULL(CONVERT(VARCHAR(20), A.OnlyBIAGAdminVisible), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.OnlyBIAGAdminVisible), ''[leer]'') + '' / '' ELSE '''' END
      FROM ' + @DbNeu + '.dbo.XMenuItem A 
      INNER JOIN ' + @DbAlt + '.dbo.XMenuItem R ON R.MenuItemID = A.MenuItemID
      WHERE A.MenuItemID = ' + @Id;
      PRINT @Sql;
    PRINT CONVERT(VARCHAR(20), LEN(@Sql));
      EXEC sys.sp_executesql @Sql, @ParamKorr, @KorrTextOUT=@KorrText OUTPUT;
      UPDATE X SET X.Korrektur = ISNULL(X.Korrektur, '') + ISNULL(@KorrText, '')
      FROM @temp X
      WHERE X.ID = @Id AND X.Typ = 'MenuItem geändert' AND X.Kunde = @Kunde
      
    END	
    CLOSE curKorr
    DEALLOCATE curKorr


  -- -----------------------------------------------------------------------------
  -- Gelöschte XModulTree
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  WITH ModulTree_CTE (ModulTreeID, ItemPath) AS (
    SELECT X.ModulTreeID, CAST(X.Name AS VARCHAR(MAX))
    FROM ' + @DbNeu + '.dbo.XModulTree X WHERE X.ModulTreeID_Parent IS NULL
    UNION ALL
    SELECT X.ModulTreeID, CTE.ItemPath + ''\'' + X.NAME
    FROM ' + @DbNeu + '.dbo.XModulTree X
    INNER JOIN ModulTree_CTE CTE ON CTE.ModulTreeID = X.ModulTreeID_Parent)
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(20), R.ModulTreeID), ''ModulTree gelöscht'', R.Name, CTE.ItemPath, NULL 
  FROM ' + @DbAlt + '.dbo.XModulTree R
  LEFT JOIN ModulTree_CTE CTE ON CTE.ModulTreeID = R.ModulTreeID
  WHERE NOT EXISTS (
    SELECT top 1 A.ModulTreeID FROM ' + @DbNeu + '.dbo.XModulTree A
    WHERE A.ModulTreeID = R.ModulTreeID)
  ORDER BY CTE.ItemPath';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;


  -- -----------------------------------------------------------------------------
  -- Neue XModulTree
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  WITH ModulTree_CTE (ModulTreeID, ItemPath) AS (
    SELECT X.ModulTreeID, ItemPath = CAST(X.Name AS VARCHAR(MAX))
    FROM ' + @DbNeu + '.dbo.XModulTree X WHERE X.ModulTreeID_Parent IS NULL
    UNION ALL
    SELECT X.ModulTreeID, CTE.ItemPath + ''\'' + X.NAME
    FROM ' + @DbNeu + '.dbo.XModulTree X
    INNER JOIN ModulTree_CTE CTE ON CTE.ModulTreeID = X.ModulTreeID_Parent)
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(20), R.ModulTreeID), ''ModulTree neu'', R.Name, CTE.ItemPath, NULL 
  FROM ' + @DbNeu + '.dbo.XModulTree R
  LEFT JOIN ModulTree_CTE CTE ON CTE.ModulTreeID = R.ModulTreeID
  WHERE NOT EXISTS (
    SELECT top 1 A.ModulTreeID FROM ' + @DbAlt + '.dbo.XModulTree A
    WHERE A.ModulTreeID = R.ModulTreeID)
  ORDER BY CTE.ItemPath';
  PRINT @Sql;
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;
  
  
  -- -----------------------------------------------------------------------------
  -- Geänderte XModulTree 
  -- -----------------------------------------------------------------------------
  SET @Sql = N'
  WITH ModulTree_CTE (ModulTreeID, ItemPath) AS (
    SELECT X.ModulTreeID, CAST(X.Name AS VARCHAR(MAX))
    FROM ' + @DbNeu + '.dbo.XModulTree X WHERE X.ModulTreeID_Parent IS NULL
    UNION ALL
    SELECT X.ModulTreeID, CTE.ItemPath + ''\'' + X.NAME
    FROM ' + @DbNeu + '.dbo.XModulTree X
    INNER JOIN ModulTree_CTE CTE ON CTE.ModulTreeID = X.ModulTreeID_Parent)
  SELECT ''' + @Kunde + ''', CONVERT(VARCHAR(20), R.ModulTreeID), ''ModulTree geändert'', CTE.ItemPath, R.ClassName, 
  CASE WHEN A.ModulTreeID_Parent != R.ModulTreeID_Parent 
    THEN ''ModulTreeID_Parent alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ModulTreeID_Parent), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ModulTreeID_Parent), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.ModulID != R.ModulID 
    THEN ''ModulID alt: '' + ISNULL(CONVERT(VARCHAR(20), A.ModulID), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.ModulID), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.SortKey != R.SortKey 
    THEN ''SortKey alt: '' + ISNULL(CONVERT(VARCHAR(20), A.SortKey), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.SortKey), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.XIconID != R.XIconID 
    THEN ''XIconID alt: '' + ISNULL(CONVERT(VARCHAR(20), A.XIconID), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.XIconID), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.Name != R.Name 
    THEN ''Name alt: '' + ISNULL(A.Name, ''[leer]'') + '', neu: '' + ISNULL(R.Name, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.NameTID != R.NameTID 
    THEN ''NameTID alt: '' + ISNULL(CONVERT(VARCHAR(20), A.NameTID), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.NameTID), ''[leer]'') + '' / '' 
    ELSE ''''
  END +  
  CASE WHEN A.ClassName != R.ClassName 
    THEN ''ClassName alt: '' + ISNULL(A.ClassName, ''[leer]'') + '', neu: '' + ISNULL(R.ClassName, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.MaskName != R.MaskName 
    THEN ''MaskName alt: '' + ISNULL(A.MaskName, ''[leer]'') + '', neu: '' + ISNULL(R.MaskName, ''[leer]'') + '' / ''
    ELSE ''''
  END +
  CASE WHEN A.Active != R.Active 
    THEN ''Active alt: '' + ISNULL(CONVERT(VARCHAR(20), A.Active), ''[leer]'') + '', neu: '' + ISNULL(CONVERT(VARCHAR(20), R.Active), ''[leer]'') + '' / '' 
    ELSE ''''
  END
  FROM ' + @DbNeu + '.dbo.XModulTree R
  INNER JOIN ' + @DbAlt + '.dbo.XModulTree A ON A.ModulTreeID = R.ModulTreeID
  LEFT JOIN ModulTree_CTE CTE ON CTE.ModulTreeID = R.ModulTreeID
  WHERE A.ModulTreeID_Parent != R.ModulTreeID_Parent
     OR A.ModulID != R.ModulID
     OR A.SortKey != R.SortKey
     OR A.XIconID != R.XIconID
     OR A.Name != R.Name
     OR A.NameTID != R.NameTID
     OR A.ClassName != R.ClassName
     OR A.MaskName != R.MaskName
     OR A.Active != R.Active
  ORDER BY CTE.ItemPath';
  PRINT @Sql;
  PRINT CONVERT(VARCHAR(20), LEN(@Sql));
  INSERT INTO @temp (Kunde, ID, Typ, Name, Beschreibung, Korrektur)
  EXEC sys.sp_executesql @Sql;
  
  
  END
END
CLOSE curKunde
DEALLOCATE curKunde


-- -----------------------------------------------------------------------------
-- Resultat zurückliefern
-- -----------------------------------------------------------------------------
SELECT * FROM @temp;
