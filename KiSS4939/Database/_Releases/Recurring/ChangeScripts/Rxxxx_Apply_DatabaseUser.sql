/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply only required rights to KiSS database user 
           (kiss3, kiss, kiss4_pi, ...)
           
  HINTS:   - To fix on changes, too: /Database/Scripts/Automation/ApplySecurityToDatabases.sql
           - Prevent adding any GOs for easy copy into script above
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 8 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------------------------
DECLARE @RoleNameBookmarksOnly SYSNAME;
DECLARE @RoleNameExecutor SYSNAME;
DECLARE @RoleNameDefinitionViewer SYSNAME;
--
DECLARE @RoleName SYSNAME;
DECLARE @RoleMemberName SYSNAME;
--
DECLARE @SqlStatement NVARCHAR(1000);
DECLARE @UserSchemaName NVARCHAR(255);

SET @RoleNameBookmarksOnly = N'KiSS_BookmarksOnly';
SET @RoleNameExecutor = N'KiSS_db_executor';
SET @RoleNameDefinitionViewer = N'KiSS_db_definition_viewer';

-------------------------------------------------------------------------------------------------
-- validate bookmarks role, set owner to dbo if current user is assigned
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleNameBookmarksOnly
              AND type = 'R'
              AND owning_principal_id = USER_ID('{SqlUserName}')))
BEGIN
  -- change owner of role to dbo
  SET @SqlStatement = 'ALTER AUTHORIZATION ON ROLE::[' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '] TO [dbo];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Changed owner of role "' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '" to "dbo"');
END;

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_executor
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameExecutor;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT EXECUTE TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_definition_viewer
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameDefinitionViewer;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT VIEW DEFINITION TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- setup rights
-------------------------------------------------------------------------------------------------
---------------------------------------
-- remove user from role <db_owner>
---------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_role_members       RM
              INNER JOIN sys.database_principals U  ON U.principal_id = RM.member_principal_id
                                                   AND U.name = '{SqlUserName}'
              INNER JOIN sys.database_principals R  ON R.principal_id = RM.role_principal_id
                                                   AND R.name = 'db_owner'))
BEGIN
  -- drop it
  EXEC sp_droprolemember 'db_owner', '{SqlUserName}';

  -- info
  PRINT ('Info: Removed user "{SqlUserName}" from db_owner rights members');
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "{SqlUserName}" is not member of role "db_owner"');
END;

---------------------------------------
-- drop and recreate user for login
---------------------------------------
-- check if need to drop first
IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals 
           WHERE name = N'{SqlUserName}'
             AND type = N'S'))
BEGIN
  -- check if user owns a schema
  SELECT @UserSchemaName = SCH.name
  FROM sys.database_principals DBP
    INNER JOIN sys.schemas     SCH ON SCH.principal_id = DBP.principal_id
  WHERE DBP.name = N'{SqlUserName}'
    AND DBP.type = N'S';
  
  IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, changing owner of schema "' + @UserSchemaName + '" to [dbo].');
      
    -- change owner of schema
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [dbo];';
    EXEC sp_executesql @SqlStatement;
  END;
  
  -- info
  PRINT ('Info: Drop assignment of user "{SqlUserName}"');

  -- drop assignment of kiss3 user
  DROP USER [{SqlUserName}];
END;

-- create KiSS user for login
CREATE USER [{SqlUserName}] FOR LOGIN [{SqlUserName}] WITH DEFAULT_SCHEMA = [dbo];

-- info
PRINT ('Info: Created user "{SqlUserName}" for login on database');

IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, rechanging owner of schema "' + @UserSchemaName + '" with owner [dbo] back to "{SqlUserName}".');
     
    -- rechange owner of schema to SqlUserName
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [{SqlUserName}];';
    EXEC sp_executesql @SqlStatement;
  END;


---------------------------------------
-- add KiSS user to specific members
---------------------------------------
-- public roles
EXEC sp_addrolemember 'db_datareader', '{SqlUserName}';
EXEC sp_addrolemember 'db_datawriter', '{SqlUserName}';

-- KiSS roles
EXEC sp_addrolemember @RoleNameExecutor, '{SqlUserName}';
EXEC sp_addrolemember @RoleNameDefinitionViewer, '{SqlUserName}';

-- add required/restrict rights (e.g. for INDENTITY_INSERTs)
GRANT ALTER ANY SCHEMA TO [{SqlUserName}];
DENY CREATE SCHEMA TO [{SqlUserName}];

USE [master];
GO
BEGIN TRY
  GRANT EXECUTE ON sys.xp_msver TO [{SqlUserName}];
END TRY
BEGIN CATCH
  PRINT ('Warning: Could not grant rights on sys.xp_msver to {SqlUserName}!')
END CATCH;
GO
USE [{DBName}];
GO

-- info
PRINT ('Info: Added user "{SqlUserName}" as member to specific roles');
PRINT ('');