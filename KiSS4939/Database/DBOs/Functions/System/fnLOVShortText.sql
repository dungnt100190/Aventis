SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnLOVShortText
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnLOVShortText.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:01 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnLOVShortText.sql $
 * 
 * 2     24.06.09 16:23 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: fnLOVShortText
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:57
*/
CREATE FUNCTION dbo.fnLOVShortText
 (@LOVName varchar(100),
  @Code    int)
 RETURNS varchar(200)
AS 

BEGIN
  DECLARE @Text varchar(200)

  SELECT @Text = ShortText
  FROM   dbo.XLOVCODE WITH (READUNCOMMITTED) 
  WHERE  LOVNAME = @LOVName AND
         CODE = @Code

  IF @Text IS null SET @Text = ''

  RETURN (@Text)
END
GO