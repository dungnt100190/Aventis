SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXExecuteSQLFile
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXExecuteSQLFile.sql $
  $Author: Ckaeser $
  $Modtime: 1.07.09 12:58 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  This helper sp is used for Migrating KiSS3 --> KiSS4, Create KiSS DB and Release Scripts!

			Because we already got all the DB Objects in SS, we don't want to store them in 
			the migration script as well.
			--> USE THIS SP TO EXECUTE THE SCRIPTS INSTEAD!

  TODO's:	- output? 
			- Exception handling?
			- 
			
  @Param01:	ObjectName to creat (== sollte FileName ohne .sql sein)
  
  @Param02:	@DBObjectType:
				1: Table
				2: Function
				3: Stored Procedure
				4: View
				5: Change Script

  -
  RETURNS: .
  -
  TEST:    EXEC dbo.spXX
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXExecuteSQLFile.sql $
 * 
 * 4     1.07.09 12:59 Ckaeser
 * 
 * 3     1.07.09 12:57 Ckaeser
 * 
 * 2     1.07.09 12:57 Ckaeser
 * 
 * 1     1.07.09 12:56 Ckaeser
 * 
 * 
 * 1     18.06.09 10:59 Ckaeser
=================================================================================================*/

CREATE Procedure spXExecuteSQLFile
	(
		@DBObjectName VARCHAR(100),
		@DBObjectType INT
	)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON

  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------

  DECLARE @sql       varchar(MAX)
  DECLARE @DBName    varchar(100)
  DECLARE @DBServer  varchar(100)
  DECLARE @Path      varchar(500)
  DECLARE @Directory varchar(30)
  DECLARE @DebugMode bit 

  SELECT 
    @DBName    = MIG.DBName,
    @DBServer  = MIG.DBServer,
    @Path      = MIG.Path,
    @DebugMode = 0  -- SET THIS TO 1 if you want some additional info-output
  FROM dbo.XKiSSUpdate MIG WITH (READUNCOMMITTED)

BEGIN TRY

/*******************************************************************
* Create Table from SS Definition
*******************************************************************/
  IF @DBObjectType = 1
    SET @Directory = '\Tables\'
  ELSE IF @DBObjectType = 2
    SET @Directory = '\Functions\'
  ELSE IF @DBObjectType = 3
    SET @Directory = '\Stored Procedures\'
  ELSE IF @DBObjectType = 4
    SET @Directory = '\Views\'
 --@@TODO ChangeScripts(?)
 --@@TODO DocDB Flag/Name?
  
      SET @sql = '
    EXEC master..xp_cmdshell ''sqlcmd -S ' + @DBServer + ' -E -d ' + @DBName + ' -i "' + @Path + @Directory + @DBObjectName + '.sql"'''
-- DEBUG and THINK ABOUT integration output to file?
-- EXEC master..xp_cmdshell ''sqlcmd -S ' + @DBServer + ' -E -d ' + @DBName + ' -i "' + @Path + @Directory + @DBObjectName + '.sql" -o c:\outfile.txt'''
    
    IF @DebugMode = 1
    BEGIN
      PRINT @sql
      EXECUTE (@sql)
    END
    ELSE 
      EXECUTE (@sql + ', NO_OUTPUT')
END TRY
BEGIN CATCH
     DECLARE @error VARCHAR(2000)
     SET @error = (SELECT ERROR_MESSAGE() AS Fehler)
     EXEC dbo.spXWriteLogFile @error, 1
END CATCH

END
