SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spCreateDWHViews
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spCreateDWHViews.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:08 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spCreateDWHViews.sql $
 * 
 * 4     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 3     14.05.09 10:27 Mweber
 * auf Wunsch des DWH-Teams:
 * die beiden PRINT-Befehle sind auskommentiert
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spCreateDWHViews]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Loop over all tables:
	DECLARE	tableCur CURSOR local FOR
		SELECT		tbl.Name, tbl.OBJECT_ID, col.Name, col.column_id,
					(SELECT MAX(column_id) FROM sys.Columns maxcol WHERE maxcol.OBJECT_ID=tbl.OBJECT_ID) maxcol,
					col.system_type_id
		FROM		sys.tables tbl
		JOIN		sys.Columns col
		on			tbl.OBJECT_ID = col.OBJECT_ID
		WHERE		tbl.TYPE = 'U'
	--	and			tbl.name = 'AmAbKind'
		AND         tbl.Name NOT in ('sysdiagrams')
		ORDER BY	tbl.Name, col.column_id

	DECLARE			@TableName	varchar(255),
					@tableID	bigint,
					@ColumnName	varchar(255),
					@columnID	bigint,
					@maxColumnID	int,
					@systemTypeID	int,
					@SQL		varchar(2048),
					@lastTableName	varchar(255)

	SET				@lastTableName = ''

	OPEN			tableCur
	FETCH NEXT FROM tableCur INTO @TableName, @tableID, @ColumnName, @columnID, @maxColumnID, @systemTypeID
	WHILE @@fetch_status=0
	BEGIN
		-- New table in loop:
		IF @lastTableName <> @TableName
		BEGIN
			-- Drop view if existent:
			SET @SQL = 'IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N''[dbo].[v_' + @TableName + ']'')) DROP VIEW [dbo].[v_' + @TableName + ']'
			EXECUTE (@SQL)
			-- PRINT @SQL

			-- Create new view from field names:
			SET @SQL = 'create view [dbo].[v_' + @TableName + '] as select '
			SET @lastTableName = @TableName
		END
		SET @SQL = @SQL + '[' + @ColumnName + '], '
		-- Add timestamp-to-bigint column:
		IF @systemTypeID = 189
		BEGIN
			SET @SQL = @SQL + 'convert(bigint, [' + @ColumnName + ']) [' + @ColumnName + 'Bigint], '
		END
		-- Check if last column of this table:
		IF @columnID = @maxColumnID
		BEGIN
			SET @SQL = LEFT(@SQL, len(@SQL)-1) + ' from ' + @TableName + ';'
			EXECUTE (@SQL)
			-- PRINT @SQL
		END

		FETCH NEXT FROM tableCur INTO @TableName, @tableID, @ColumnName, @columnID, @maxColumnID, @systemTypeID
	END
	CLOSE			tableCur
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
