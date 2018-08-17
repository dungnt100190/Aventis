-------------------------------------------------------------------------------
-- Role [tools_access]
-------------------------------------------------------------------------------
DECLARE @RoleName sysname
set @RoleName = N'tools_access'
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = @RoleName AND type = 'R')
Begin
	DECLARE @RoleMemberName sysname
	DECLARE Member_Cursor CURSOR FOR
	select [name]
	from sys.database_principals 
	where principal_id in ( 
		select member_principal_id 
		from sys.database_role_members 
		where role_principal_id in (
			select principal_id
			FROM sys.database_principals where [name] = @RoleName  AND type = 'R' ))

	OPEN Member_Cursor;

	FETCH NEXT FROM Member_Cursor
	into @RoleMemberName

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec sp_droprolemember @rolename=@RoleName, @membername= @RoleMemberName

		FETCH NEXT FROM Member_Cursor
		into @RoleMemberName
	END;

	CLOSE Member_Cursor;
	DEALLOCATE Member_Cursor;
End

GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'tools_access' AND type = 'R')
  DROP ROLE [tools_access]
GO

CREATE ROLE [tools_access] AUTHORIZATION [dbo]
GO

-------------------------------------------------------------------------------
-- Role [tools_sonar_ek_asyl_role]
-------------------------------------------------------------------------------
DECLARE @RoleName sysname
set @RoleName = N'tools_sonar_ek_asyl_role'
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = @RoleName AND type = 'R')
Begin
	DECLARE @RoleMemberName sysname
	DECLARE Member_Cursor CURSOR FOR
	select [name]
	from sys.database_principals 
	where principal_id in ( 
		select member_principal_id 
		from sys.database_role_members 
		where role_principal_id in (
			select principal_id
			FROM sys.database_principals where [name] = @RoleName  AND type = 'R' ))

	OPEN Member_Cursor;

	FETCH NEXT FROM Member_Cursor
	into @RoleMemberName

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec sp_droprolemember @rolename=@RoleName, @membername= @RoleMemberName

		FETCH NEXT FROM Member_Cursor
		into @RoleMemberName
	END;

	CLOSE Member_Cursor;
	DEALLOCATE Member_Cursor;
End

GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'tools_sonar_ek_asyl_role' AND type = 'R')
  DROP ROLE [tools_sonar_ek_asyl_role]
GO

CREATE ROLE [tools_sonar_ek_asyl_role] AUTHORIZATION [dbo]
GO