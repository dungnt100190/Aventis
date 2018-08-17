SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXWriteLogFile
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXWriteLogFile.sql $
  $Author: Ckaeser $
  $Modtime: 6.08.09 9:26 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXWriteLogFile.sql $
 * 
 * 2     6.08.09 9:26 Ckaeser
 * 
 * VSS First
=================================================================================================*/
/*
This is a helper sp for the Migration KiSS3 --> KiSS4

Creates a log file

@msg:       Log-Message
@newLine:   0 = no empty line (default), 1 = create empty line
@overwrite: 0 = do not overwrite file,   1 = overwrite existing file
	
*/

CREATE PROCEDURE spXWriteLogFile
(
	@msg varchar(7999),
	@newLine   BIT = 0,
	@overwrite BIT = 0
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @execstr varchar(7999)
	DECLARE @file varchar(200)

	-- Get name of log file
	SET @file = (SELECT TOP 1 LogFile FROM XKiSSUpdate)

PRINT @file

	-- Add message to log file
	SET @execstr = RTrim('echo ' + COALESCE(LTrim(@msg),'-') +
		CASE WHEN (@overwrite = 1)
			THEN ' > '
			ELSE ' >> '
			END + RTrim(@file))

	EXEC master..xp_cmdshell @execstr--, NO_OUTPUT

	-- Add new line to log file
	IF @newLine = 1 BEGIN
		SET @execstr = RTrim('echo. ' +
			CASE WHEN (@overwrite = 1)
				THEN ' > '
				ELSE ' >> '
				END + RTrim(@file))

		EXEC master..xp_cmdshell @execstr, NO_OUTPUT
	END

	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
