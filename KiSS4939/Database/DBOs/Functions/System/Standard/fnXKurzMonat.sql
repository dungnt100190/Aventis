SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnXKurzMonat
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnXKurzMonat.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnXKurzMonat.sql $
 * 
 * 2     24.06.09 16:15 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnXKurzMonat
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnXKurzMonat
 (@Monat int)
 RETURNS varchar(10)
AS 

BEGIN
  DECLARE @FormatDate varchar(10)

  SET @FormatDate = CASE @Monat
                      WHEN  1 THEN 'Jan'
                      WHEN  2 THEN 'Feb'
                      WHEN  3 THEN 'März'
                      WHEN  4 THEN 'Apr'
                      WHEN  5 THEN 'Mai'
                      WHEN  6 THEN 'Juni'
                      WHEN  7 THEN 'Juli'
                      WHEN  8 THEN 'Aug'
                      WHEN  9 THEN 'Sep'
                      WHEN 10 THEN 'Okt'
                      WHEN 11 THEN 'Nov'
                      WHEN 12 THEN 'Dez'
                      ELSE ''
                    END

   RETURN(@FormatDate)
END

GO