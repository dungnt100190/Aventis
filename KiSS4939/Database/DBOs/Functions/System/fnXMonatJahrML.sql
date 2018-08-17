SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXMonatJahrML;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the month and year as 'mmmm yyyy' from given datetime and language
    @Date:         The date to use for getting month and year
    @LanguageCode: The language code to use for multilanguage output (1=german)
  -
  RETURNS: The month and year as 'mmmm yyyy' from given datetime
=================================================================================================
  TEST:    SELECT dbo.fnXMonatJahrML(GETDATE(), 1);
           SELECT dbo.fnXMonatJahrML(GETDATE(), 2);
           SELECT dbo.fnXMonatJahrML(GETDATE(), 3);
=================================================================================================*/

CREATE FUNCTION dbo.fnXMonatJahrML
(
  @Date DATETIME,
  @LanguageCode INT
)
RETURNS VARCHAR(50)
AS
BEGIN
  RETURN dbo.fnXMonatML(DATEPART(mm, @Date), @LanguageCode) + ' ' + CONVERT(VARCHAR, DATEPART(YYYY, @Date));
END;
GO