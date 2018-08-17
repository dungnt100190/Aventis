SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnXKurzMonatJahr
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnXKurzMonatJahr.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnXKurzMonatJahr.sql $
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
  DB-Object: fnXKurzMonatJahr
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnXKurzMonatJahr
 (@DATE datetime)
 RETURNS varchar(16)
AS 

BEGIN
  DECLARE @FormatDate varchar(16)

  SET @FormatDate = dbo.fnXKurzMonat(DatePart(mm, @DATE)) + ' ' +
                    CONVERT(varchar, DatePart(YYYY, @DATE))

  RETURN(@FormatDate)
END

GO