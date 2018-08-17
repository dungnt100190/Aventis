SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetReferencedKeyColumnsOfForeignKey;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetReferencedKeyColumnsOfForeignKey.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:25 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetReferencedKeyColumnsOfForeignKey.sql $
 * 
 * 3     17.03.10 13:25 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnGetReferencedKeyColumnsOfForeignKey
(
  @constid INT
)
RETURNS VARCHAR(500)
AS BEGIN
  DECLARE @ColumnList VARCHAR(500);
  
  SELECT @ColumnList = ISNULL(@ColumnList + ', ', '') +  SCO.[Name]
  FROM sysforeignkeys     SFK
    INNER JOIN sysobjects SOB ON SFK.constid = SOB.id
    INNER JOIN syscolumns SCO ON SCO.id = SFK.rkeyid
                             AND SCO.colid = SFK.rkey
  WHERE SFK.constid = @constid
  ORDER BY SFK.keyno;
  
  RETURN @ColumnList;
END;
GO