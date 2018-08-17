SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject sp_dropdiagram;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/DB_DiagramDesigner/sp_dropdiagram.sql $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/DB_DiagramDesigner/sp_dropdiagram.sql $
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

CREATE PROCEDURE dbo.sp_dropdiagram
(
		@diagramname 	sysname,
		@owner_id	int	= null
)
WITH EXECUTE AS 'dbo'
AS
BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
GO
GRANT  EXECUTE  ON [dbo].[sp_dropdiagram]  TO [public]
GO
DENY  EXECUTE  ON [dbo].[sp_dropdiagram]  TO [guest] CASCADE
GO
EXEC sp_addextendedproperty N'microsoft_database_tools_support', 1, N'user', N'dbo', N'procedure', N'sp_dropdiagram'
GO