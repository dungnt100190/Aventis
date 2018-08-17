SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject sp_helpdiagrams;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/DB_DiagramDesigner/sp_helpdiagrams.sql $
  $Author: Cjaeggi $
  $Modtime: 3.08.10 11:10 $
  $Revision: 3 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/DB_DiagramDesigner/sp_helpdiagrams.sql $
 * 
 * 3     3.08.10 11:11 Cjaeggi
 * Fixed granting and exprop
 * 
 * 2     3.08.10 10:13 Cjaeggi
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE PROCEDURE dbo.sp_helpdiagrams
(
		@diagramname sysname = NULL,
		@owner_id int = NULL
)
WITH EXECUTE AS N'dbo'
AS
BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
GO
GRANT  EXECUTE  ON [dbo].[sp_helpdiagrams]  TO [public]
GO
DENY  EXECUTE  ON [dbo].[sp_helpdiagrams]  TO [guest] CASCADE
GO
EXEC sp_addextendedproperty N'microsoft_database_tools_support', 1, N'user', N'dbo', N'procedure', N'sp_helpdiagrams'
GO