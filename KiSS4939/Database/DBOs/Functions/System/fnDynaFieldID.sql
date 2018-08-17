SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnDynaFieldID
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnDynaFieldID.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 15:55 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnDynaFieldID.sql $
 * 
 * 2     24.06.09 16:17 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnDynaFieldID
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnDynaFieldID(
  @FieldName        varchar(100))
RETURNS int
AS 

BEGIN
  RETURN (SELECT TOP 1 DynaFieldID
          FROM dbo.DynaField         FLD WITH (READUNCOMMITTED) 
            INNER JOIN dbo.DynaMask  MSK WITH (READUNCOMMITTED) ON MSK.MaskName = FLD.MaskName
          WHERE FLD.FieldName = @FieldName AND FLD.FieldCode NOT IN (1)
          ORDER BY CONVERT(int, MSK.Active) DESC)
END

GO