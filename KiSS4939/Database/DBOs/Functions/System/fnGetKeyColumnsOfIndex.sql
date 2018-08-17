SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetKeyColumnsOfIndex;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetKeyColumnsOfIndex.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:19 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetKeyColumnsOfIndex.sql $
 * 
 * 3     17.03.10 13:19 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnGetKeyColumnsOfIndex
(
  @TableName VARCHAR(100),
  @IndexName VARCHAR(100)
)
RETURNS VARCHAR(500)
AS BEGIN
  DECLARE @ColumnList VARCHAR(500);
  
  SELECT @ColumnList = ISNULL(@ColumnList + ', ', '') + SC.name
  FROM sysindexes           SI
    INNER JOIN sysindexkeys SK ON SK.id = SI.id 
                              AND SK.indid = SI.indid
    INNER JOIN syscolumns   SC ON SK.id = SC.id 
                              AND SK.colid = SC.colid
  WHERE SI.id = OBJECT_ID(@TableName) 
    AND SI.name = @IndexName
  ORDER BY SK.keyno;
  
  RETURN @ColumnList;
END;
GO