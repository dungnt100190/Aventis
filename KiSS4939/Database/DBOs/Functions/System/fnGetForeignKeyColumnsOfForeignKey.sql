SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetForeignKeyColumnsOfForeignKey;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetForeignKeyColumnsOfForeignKey.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 9:58 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetForeignKeyColumnsOfForeignKey.sql $
 * 
 * 3     17.03.10 9:58 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     29.08.08 16:40 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetForeignKeyColumnsOfForeignKey
(
  @constid INT
)
RETURNS VARCHAR(500)
AS BEGIN
  DECLARE @ColumnList VARCHAR(500);
  
  SELECT @ColumnList = ISNULL(@ColumnList + ', ', '') + SCO.name
  FROM sysforeignkeys      SFK
    INNER JOIN sysobjects  SOB ON SFK.constid = SOB.id
    INNER JOIN syscolumns  SCO ON SCO.id = SFK.fkeyid 
                              AND SCO.colid = SFK.fkey
  WHERE SFK.constid = @constid
  ORDER BY SFK.keyno;
  
  RETURN @ColumnList;
END;
GO