/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to create or update a config value with the name of the actual db.
  This config value is used to prevent Kiss from using a database that is not initialised
  whith a release skript. We want to prevent that the production document database is used
  from the integration environment.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- System Konfigurationswert  System\Allgemein\DbName
-------------------------------------------------------------------------------
DECLARE @CONFIGPATH VARCHAR(MAX);
SET @CONFIGPATH = 'System\Allgemein\DbName';
PRINT ('Checking system configuration value '  + @CONFIGPATH);

DECLARE @CURRENTDBNAME VARCHAR(400);
SET  @CURRENTDBNAME =  '{DBName}';  

PRINT ('Current db-name is: ' + @CURRENTDBNAME);

IF (NOT EXISTS (SELECT TOP 1 1 
                FROM dbo.XConfig 
                WHERE KeyPath = @CONFIGPATH))
BEGIN
  PRINT ('Configuration value '  + @CONFIGPATH + ' does not exist. Creating it now.');
  
  INSERT INTO dbo.XConfig 
  (
    KeyPath,
    [System],
    DatumVon,
    ValueCode,
    ValueVarchar,
    [Description],
    OriginalValueVarchar
  )
  VALUES 
  (
    @CONFIGPATH, --KeyPath
    1, -- System: ja
    '01.01.2011', --DatumVon
    1, --ValueCode (1: varchar, 2: int, 3: decimal ...) 
    @CURRENTDBNAME, --ValueVarchar
    ('Name der Datenbank. Beim Einloggen wird geprüft, ob der aktuelle Datenbank-Name mit ' +
     'diesem Wert übereinstimmt. Bei einer Nichtübereinstimmung kann der User nicht einloggen. ' +
     'Damit verhindern wir, dass versehentlich von einer Integrationsumgebung Dokumente auf ' +
     'der Produktionsumgebung mutiert, gelöscht oder eingefügt werden. ' +
     'Der erwartete Wert kann mit dem SQL "SELECT DB_NAME()" herausgefunden werden.'),
    @CURRENTDBNAME --Original Value
  );
END
ELSE
BEGIN
  PRINT ('Configuration value "'  + @CONFIGPATH + '" already exists. Updating it now.'); 
  
  UPDATE dbo.XConfig
  SET ValueVarchar = @CURRENTDBNAME 
  WHERE KeyPath = @CONFIGPATH;
END; 

-------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------
PRINT ('Done with checking "' + @CONFIGPATH + '"');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO