SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject SEL
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/SEL.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:47 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/SEL.sql $
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: SEL
  Branch   : KiSS4_BSS_Master
  BuildNr  : 2
  Datum    : 06.08.2008 11:06
*/

CREATE PROCEDURE dbo.SEL
 (@TableName       varchar(200),
  @Value           varchar(100),
  @WhereColumnName varchar(200) = NULL,
  @SelectColumnName varchar(200) = NULL
  )
AS


SET @WhereColumnName = isNull(@WhereColumnName, @TableName + 'ID')
SET @SelectColumnName = isNull(@SelectColumnName, '*')

DECLARE @SQL nvarchar(1000)

SET @SQL = '
SELECT ' + @SelectColumnName + ' 
FROM ' + @TableName + '
WHERE ' + @WhereColumnName  + ' = ' +@Value
PRINT @SQL

EXECUTE sp_executesql @SQL
GO