SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXKurzMonatML;
GO
/*===============================================================================================
  $Revision: 1 $
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
=================================================================================================*/

-- get month as varchar in short format
CREATE FUNCTION dbo.fnXKurzMonatML
(
  @Monat INT,
  @LanguageCode INT
)
RETURNS varchar(10)
AS BEGIN
  -- vars
  DECLARE @FormatDate varchar(10)

  SET @FormatDate = CASE @Monat
                      WHEN  1 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Januar', @LanguageCode)
                      WHEN  2 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Februar', @LanguageCode)
                      WHEN  3 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Maerz', @LanguageCode)
                      WHEN  4 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'April', @LanguageCode)
                      WHEN  5 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Mai', @LanguageCode)
                      WHEN  6 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Juni', @LanguageCode)
                      WHEN  7 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Juli', @LanguageCode)
                      WHEN  8 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'August', @LanguageCode)
                      WHEN  9 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'September', @LanguageCode)
                      WHEN 10 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Oktober',  @LanguageCode)
                      WHEN 11 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'November', @LanguageCode)
                      WHEN 12 THEN dbo.fnXDbObjectMLMsg('fnXKurzMonat', 'Dezember', @LanguageCode)
                      ELSE ''
                    END

   RETURN(@FormatDate)
END
GO