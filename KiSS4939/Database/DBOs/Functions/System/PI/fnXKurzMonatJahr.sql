SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXKurzMonatJahr;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnXKurzMonatJahr.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:52 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: get month and year as 'mmm yyyy' from datetime
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnXKurzMonatJahr.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnXKurzMonatJahr
(
  @Date datetime,
  @LanguageCode INT
)
RETURNS varchar(16)
AS BEGIN
  DECLARE @FormatDate varchar(16)

  SET @FormatDate = dbo.fnXKurzMonat(DatePart(mm, @Date), @LanguageCode) + ' ' +
                    CONVERT(varchar, DatePart(YYYY, @Date))

  RETURN(@FormatDate)
END
GO