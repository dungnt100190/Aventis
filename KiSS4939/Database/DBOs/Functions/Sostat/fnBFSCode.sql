SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSCode
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnBFSCode.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 9:51 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnBFSCode.sql $
 * 
 * 2     24.06.09 16:16 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnBFSCode
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnBFSCode
  (@LOVName varchar(100),
   @Code    int)
  RETURNS int
AS BEGIN
  DECLARE @BFSCode int

  SELECT @BFSCode = BFSCode
  FROM   dbo.XLOVCode WITH (READUNCOMMITTED) 
  WHERE  LOVName = @LOVName AND
           Code = @Code

  RETURN (@BFSCode)
END
GO