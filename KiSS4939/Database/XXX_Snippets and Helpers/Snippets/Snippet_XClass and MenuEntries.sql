/*===============================================================================================
  Template um eine neue Maske in XClass einzutragen und den Menueintrag zu erstellen (bis zu 4 Menu-Stufen tief)
  TODO: XModulTree-Einträge können analog erstellt werden, das ist aber hier noch nicht generisch umgesetzt
=================================================================================================*/
DECLARE @ClassName VARCHAR(255);
DECLARE @Beschreibung VARCHAR(255);
DECLARE @ModulAbkuerzung VARCHAR(5);
DECLARE @BasisKlasse VARCHAR(100);
DECLARE @System BIT;
DECLARE @NamespaceExtension VARCHAR(5);
DECLARE @MainMenuCaption VARCHAR(100);
DECLARE @SubMenuCaption1 VARCHAR(100);
DECLARE @SubMenuCaption2 VARCHAR(100);
DECLARE @SubMenuCaption3 VARCHAR(100);
DECLARE @MenuItemCaption VARCHAR(100);
DECLARE @IconID INT;
DECLARE @ModulID INT;
DECLARE @Error VARCHAR(255);

-- Hier müssen die Masken-spezifischen Änderungen angebracht werden
SET @ClassName = 'CtlBfsPositionsartenMapping';
SET @Beschreibung = 'Mapping von Positionsarten zu BFS-Variablen';
SET @ModulAbkuerzung = 'BFS';
SET @BasisKlasse = 'KiSS4.Common.KissSearchUserControl';
SET @System = 0;
SET @NamespaceExtension = NULL;
SET @ModulID = 16;

-- Hier müssen die Menü-spezifischen Änderungen angebracht werden
SET @MainMenuCaption = 'Anwendung';    -- Oder Null, falls die Maske nicht unter einem Hauptmenu-Eintrag eingetragen werden soll. Der neue Menueintrag wird am Ende des Menus eingetragen
SET @SubMenuCaption1 = 'SoStat';       -- Oder Null, falls die Maske nicht unter diesem Submenu-Eintrag eingetragen werden soll (er wird dann am nächst höheren Eintrag, der definiert ist, eingetragen). Der neue Menueintrag wird am Ende des Menus eingetragen
SET @SubMenuCaption2 = 'Stammdaten';   -- Oder Null, falls die Maske nicht unter diesem Submenu-Eintrag eingetragen werden soll (er wird dann am nächst höheren Eintrag, der definiert ist, eingetragen). Der neue Menueintrag wird am Ende des Menus eingetragen
SET @SubMenuCaption3 = NULL;           -- Oder Null, falls die Maske nicht unter diesem Submenu-Eintrag eingetragen werden soll (er wird dann am nächst höheren Eintrag, der definiert ist, eingetragen). Der neue Menueintrag wird am Ende des Menus eingetragen
SET @MenuItemCaption = 'LA-Mapping';   -- Name (oder eben Caption) des neuen Menu-Eintrags
SET @IconID = 2112;                    -- Mask-Icon

-- Erstelle XClass-Eintrag
IF (NOT EXISTS (SELECT TOP 1 1
                FROM dbo.XClass
                WHERE ClassName = @ClassName))
BEGIN
  INSERT INTO dbo.XClass (ClassName, ModulID, MaskName, BaseType, ClassCode,
                          ClassTID, PropertiesXML, Designer, [Description],
                          CodeGenerated, [Resource], [Assembly], Branch, BuildNr,
                          [System], CheckOut_UserID, CheckOut_Date, NamespaceExtension)
  VALUES (@ClassName, @ModulID, @ModulAbkuerzung + ' - ' + @ClassName, @BasisKlasse, NULL,
          NULL, NULL, 0, @Beschreibung,
          NULL, NULL, NULL, NULL, 0,
          @System, NULL, NULL, @NamespaceExtension);
END;

-- Erstelle Menu-Eintrag (falls nötig)
IF (@MainMenuCaption IS NOT NULL)
BEGIN
  DECLARE @SortKey INT;
  DECLARE @MenuTID INT;
  DECLARE @ParentMenuItem VARCHAR(100);
  DECLARE @ParentMenuItemID INT;
  
  -- Suche Hauptmenu-Eintrag
  SELECT @ParentMenuItemID = MenuItemID
  FROM dbo.XMenuItem
  WHERE Caption = @MainMenuCaption;
  
  SET @ParentMenuItem = @MainMenuCaption;

  -- Prüfe, ob der Eintrag auf der nächsten Submenu-Stufe eingetragen werden soll
  IF (@SubMenuCaption1 IS NOT NULL)
  BEGIN
    SELECT @ParentMenuItemID = MenuItemID
    FROM dbo.XMenuItem
    WHERE Caption = @SubMenuCaption1
      AND ParentMenuItemID = @ParentMenuItemID;
    
    SET @ParentMenuItem = @SubMenuCaption1;
  END;

  -- Prüfe, ob der Eintrag auf der nächsten Submenu-Stufe eingetragen werden soll
  IF (@SubMenuCaption2 IS NOT NULL)
  BEGIN
    SELECT @ParentMenuItemID = MenuItemID
    FROM dbo.XMenuItem
    WHERE Caption = @SubMenuCaption2
      AND ParentMenuItemID = @ParentMenuItemID;
    
    SET @ParentMenuItem = @SubMenuCaption2;
  END;

  -- Prüfe, ob der Eintrag auf der nächsten Submenu-Stufe eingetragen werden soll
  IF (@SubMenuCaption3 IS NOT NULL)
  BEGIN
    SELECT @ParentMenuItemID = MenuItemID
    FROM dbo.XMenuItem
    WHERE Caption = @SubMenuCaption3
      AND ParentMenuItemID = @ParentMenuItemID;
    
    SET @ParentMenuItem = @SubMenuCaption3;
  END;
  
  IF (@ParentMenuItemID IS NULL)
  BEGIN
    SET @Error = 'Parent-Menu-Eintrag ' + @ParentMenuItem + ' konnte nicht gefunden werden';
    RAISERROR (@Error, 1, 1);
    RETURN;
  END;
  
  IF (NOT EXISTS (SELECT TOP 1 1
                  FROM dbo.XMenuItem
                  WHERE ParentMenuItemID = @ParentMenuItemID
                    AND ClassName = @ClassName))
  BEGIN
    INSERT INTO dbo.XLangText (LanguageCode, [Text])
    VALUES (1, @MenuItemCaption);
    
    SET @MenuTID = SCOPE_IDENTITY();
    
    SELECT @SortKey = MAX(SortKey) + 1
    FROM dbo.XMenuItem
    WHERE ParentMenuItemID = @ParentMenuItemID;

    INSERT INTO dbo.XMenuItem (ParentMenuItemID, BeginMenuGroup, Caption, MenuTID,
                               ImageIndex, SortKey, ClassName)
    VALUES (@ParentMenuItemID, 1, @MenuItemCaption, @MenuTID,
            @IconID, @SortKey, @ClassName);
  END;
END;