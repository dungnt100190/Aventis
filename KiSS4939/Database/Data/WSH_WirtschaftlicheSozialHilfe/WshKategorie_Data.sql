-- =============================================
-- Tabelle WshKategorie füllen
-- =============================================

DECLARE @SysDate DATETIME;
SET @SysDate = '20110801';

DECLARE @SysUser VARCHAR(50);
SELECT TOP 1 @SysUser = LogonName FROM dbo.XUser 
WHERE UserID = dbo.fnXGetSystemUserID();


SET IDENTITY_INSERT dbo.WshKategorie  ON

IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Ausgabe')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 1,
  Name = 'Ausgabe', 
  IstAktiv = 1, 
  IstAbzug = 0, 
  SortKey = 1, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;


IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Einnahme')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 2,
  Name = 'Einnahme', 
  IstAktiv = 1, 
  IstAbzug = 0, 
  SortKey = 2, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;
  
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Sanktion')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 3,
  Name = 'Sanktion', 
  IstAktiv = 1, 
  IstAbzug = 1, 
  SortKey = 5, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;  

  
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Verrechnung')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 4,
  Name = 'Verrechnung', 
  IstAktiv = 1, 
  IstAbzug = 1, 
  SortKey = 3, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;  
  
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Rückerstattung')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 5,
  Name = 'Rückerstattung', 
  IstAktiv = 1, 
  IstAbzug = 1, 
  SortKey = 4, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;  

  
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Abzahlung')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 6,
  Name = 'Abzahlung', 
  IstAktiv = 0, 
  IstAbzug = 0, 
  SortKey = 6, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;  
 
  
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Kürzung')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 7,
  Name = 'Kürzung', 
  IstAktiv = 0, 
  IstAbzug = 0, 
  SortKey =7, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;     
  
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Vermögen')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 8,
  Name = 'Vermögen', 
  IstAktiv = 0, 
  IstAbzug = 0, 
  SortKey = 8, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;  
  
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Vorabzug')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 9,
  Name = 'Vorabzug', 
  IstAktiv = 0, 
  IstAbzug = 0, 
  SortKey = 9, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;    



IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.WshKategorie WHERE Name = 'Unbekannt')
INSERT INTO dbo.WshKategorie (
  WshKategorieID, Name, IstAktiv, IstAbzug, SortKey, Creator, Created, Modifier, Modified)
SELECT 
  WshKategorieID = 100,
  Name = 'Unbekannt', 
  IstAktiv = 0, 
  IstAbzug = 0, 
  SortKey = 100, 
  Creator = @SysUser, 
  Created = @SysDate, 
  Modifier = @SysUser, 
  Modified = @SysDate;

SET IDENTITY_INSERT dbo.WshKategorie OFF