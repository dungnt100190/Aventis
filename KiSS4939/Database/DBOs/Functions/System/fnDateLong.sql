SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDateLong;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Datum als Text konvertieren. "Wochentag, Tag Monat Jahr"
    @Date:         Das Datum welches ausgeschrieben werden soll.
    @LanguageCode: LanguageCode.
  -
  RETURNS: Ein String welcher gegebenenfalls so aussieht: Donnerstag, 09. September 1999
                                             Französisch: jeudi, 09 septembre 1999
=================================================================================================
  TEST:    SELECT dbo.fnDateLong(PRS.Geburtsdatum, 1), PRS.Geburtsdatum FROM dbo.BaPerson PRS;
=================================================================================================*/

CREATE FUNCTION dbo.fnDateLong
(
  @DateValue DATETIME,
  @LanguageCode INT
)
RETURNS VARCHAR(255)
AS BEGIN

  IF (@DateValue IS NULL)
  BEGIN
    RETURN NULL;
  END;

  -- define vars
  DECLARE @DateLong   VARCHAR(100);
  DECLARE @Weekday    VARCHAR(20);
  DECLARE @Month      VARCHAR(20);
  DECLARE @Separation VARCHAR(5);

  -- get weekday
  SET @Weekday = (DATEPART(weekday, @DateValue) + @@DATEFIRST - 2) % 7 + 1;

  -- set point due to LanguageCode
  SET @Separation =  CASE @LanguageCode
                       WHEN 1 THEN '. '
                       ELSE ' '
                     END;
  
  -- define month
  SET @Month = dbo.fnGetLOVMLText('Monat', DATEPART(MONTH, @DateValue), @LanguageCode);

  -- assemble
  SET @DateLong = dbo.fnGetLOVMLText('Wochentag', @Weekday, @LanguageCode) -- Weekday
                  + ', '
                  + CONVERT(VARCHAR(2), DATEPART(dd, @DateValue))    -- Day
                  + @Separation                                      -- Seperation
                  + @Month                                           -- Month
                  + ' '
                  + CONVERT(VARCHAR(4), DATEPART(YEAR, @DateValue)); -- Year
  
  RETURN @DateLong;
END;
GO