SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnXModul10
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnXModul10.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:08 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnXModul10.sql $
 * 
 * 2     24.06.09 16:14 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnXModul10
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnXModul10
 (@input varchar(50))
  RETURNS char(1)
AS 

BEGIN
  DECLARE @pos int,
          @val int

  SELECT @pos = 0, @val = 0

  WHILE @pos < LEN(@input) BEGIN
    SET @pos = @pos + 1
    SET @val = CONVERT(int, SubString('09468271350', (CONVERT(int, SubString(@input, @pos, 1)) + @val) % 10 + 1, 1))
  END

  RETURN CONVERT(char(1), (10 - @val) % 10)
END

GO