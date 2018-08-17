SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXKurzMonatJahrML;
GO
/*===============================================================================================
  $Revision: 1 $
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
=================================================================================================*/

CREATE FUNCTION dbo.fnXKurzMonatJahrML
(
  @Date datetime,
  @LanguageCode INT
)
RETURNS varchar(16)
AS BEGIN
  DECLARE @FormatDate varchar(16)

  SET @FormatDate = dbo.fnXKurzMonatML(DatePart(mm, @Date), @LanguageCode) + ' ' +
                    CONVERT(varchar, DatePart(YYYY, @Date))

  RETURN(@FormatDate)
END
GO