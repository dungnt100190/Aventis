SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXExtendedProperty;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  (Re)create or delete extended properties for database objects
    @DBOName:                 The name of the main database object (e.g. table "BaPerson")
    @ChildDBOName:            The name of the sub database object (e.g. column "BaPersonID")
    @ExtendedPropertyName:    The name of the extended property (e.g. "MS_Description")
    @ExtendedPropertyContent: The value of the extended property (e.g. description)
    @ErrorIfExisting:         Flag: 0=if extended property already exists, it will be dropped first
                                    1=if extended property already exists, an error will raise
    @DeleteOnly:              Flag: 0=a new extended property will be added
                                    1=no new extended property will be added - dropping only
  -
  RETURNS: No resultset will be returned - only printed messages
=================================================================================================
  TEST:    EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 0, 0;
           --
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 0, 0;
           -- expecting errors
           EXEC dbo.spXExtendedProperty 'XClass', 'abc', 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClasse', NULL, 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, NULL, 'TestMe', 0, 0;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'Abc', NULL, 0, 0;
           EXEC dbo.spXExtendedProperty NULL, NULL, 'Abc', 'TestMe', 0, 0;
           EXEC dbo.spXExtendedProperty '', NULL, 'Abc', 'TestMe', 0, 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spXExtendedProperty
(
  @DBOName VARCHAR(255),
  @ChildDBOName VARCHAR(255),
  @ExtendedPropertyName VARCHAR(255),
  @ExtendedPropertyContent VARCHAR(2000),
  @ErrorIfExisting BIT = 0,
  @DeleteOnly BIT = 0
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @DBOType VARCHAR(255);
  DECLARE @ChildDBOType VARCHAR(255);
  DECLARE @ExtendedPropertyExistsAlready BIT;
  DECLARE @ErrorMessage VARCHAR(2000);
  DECLARE @Schema VARCHAR(200);
  
  SET @DBOType = NULL;
  SET @ChildDBOType = NULL;
  SET @ExtendedPropertyExistsAlready = NULL;
  
  -----------------------------------------------------------------------------
  -- get types
  -----------------------------------------------------------------------------
  -- tables (with optional columns)
  IF (EXISTS (SELECT TOP 1 1
              FROM sys.tables
              WHERE name = @DBOName))
  BEGIN
    SET @DBOType = 'TABLE';
    SET @Schema = ( SELECT DISTINCT TABLE_SCHEMA
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = @DBOName );
    
    IF (@ChildDBOName IS NOT NULL)
    BEGIN
      SET @ChildDBOType = 'COLUMN';
    END;
  END;
  
  -- todo: if required, add further type handling...
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DBOName, '') = '' OR ISNULL(@ExtendedPropertyName, '') = '' OR ISNULL(@ExtendedPropertyContent, '') = '')
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: Invalid database object "' + ISNULL(@DBOName, '??') + '" or extended property name/content "' + ISNULL(@ExtendedPropertyName, '') + '".';
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  IF (@DBOType IS NULL OR (@ChildDBOName IS NOT NULL AND @ChildDBOType IS NULL))
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: Could not get known type of database object "' + ISNULL(@DBOName, '??') + '". Either name is not valid or type "' + ISNULL(@DBOType, '') + '" is not supported.';
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- check existing handling (type specific)
  -----------------------------------------------------------------------------
  IF (@DBOType = 'TABLE')
  BEGIN
    -- check if existing
    IF (EXISTS (SELECT TableName     = OBJECT_NAME(EXT.major_id), 
                       ColumnName    = COL.name, 
                       PropertyName  = EXT.name, 
                       PropertyValue = EXT.value
                FROM sys.extended_properties EXT
                  LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id
                                                AND COL.column_id = EXT.minor_id
                WHERE EXT.class_desc = 'OBJECT_OR_COLUMN'
                  AND OBJECT_NAME(EXT.major_id) = @DBOName
                  AND EXT.name = @ExtendedPropertyName
                  AND ((@ChildDBOName IS NULL AND EXT.minor_id = 0) 
                    OR (@ChildDBOName IS NOT NULL AND COL.name = @ChildDBOName))
               ))
    BEGIN
      SET @ExtendedPropertyExistsAlready = 1;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- general extended property handling
  -----------------------------------------------------------------------------  
  -- check if can delete if existing
  IF (@ErrorIfExisting = 1 AND @ExtendedPropertyExistsAlready = 1)
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: The extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" already exists for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', '');
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  -- check if need to delete
  IF (@ExtendedPropertyExistsAlready = 1)
  BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
      -- delete extended property
      EXEC sys.sp_dropextendedproperty @name = @ExtendedPropertyName, 
                                       @level0type = N'SCHEMA', @level0name = @Schema, 
                                       @level1type = @DBOType, @level1name = @DBOName, 
                                       @level2type = @ChildDBOType, @level2name = @ChildDBOName;
      
      COMMIT;
      
      -- show info
      PRINT ('Info: Dropped extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', ''));
    END TRY
    BEGIN CATCH
      -- rollback any action
      ROLLBACK TRANSACTION;
      
      -- set error part
      SET @ErrorMessage = ERROR_MESSAGE()
      
      -- do not continue
      RAISERROR ('Error: Could not drop extended property. Database error was: %s.', 18, 1, @ErrorMessage);
      RETURN;
    END CATCH;
  END;
  
  -- check if need to continue
  IF (@DeleteOnly = 1)
  BEGIN
    -- no more to do
    RETURN;
  END;
  
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to create extended property
    EXEC sys.sp_addextendedproperty @name = @ExtendedPropertyName, @value = @ExtendedPropertyContent, 
                                    @level0type = N'SCHEMA', @level0name = @Schema, 
                                    @level1type = @DBOType, @level1name = @DBOName, 
                                    @level2type = @ChildDBOType, @level2name = @ChildDBOName;
    
    COMMIT;
    
    -- show info
    PRINT ('Info: Added extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', ''));
  END TRY
  BEGIN CATCH
    -- rollback any action
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()
    
    -- do not continue
    RAISERROR ('Error: Could not add extended property. Database error was: %s.', 18, 1, @ErrorMessage);
    RETURN;
  END CATCH;
END;
GO