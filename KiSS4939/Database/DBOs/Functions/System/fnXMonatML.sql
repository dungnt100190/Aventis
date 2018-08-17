SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXMonatML;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the name of the desired month as varchar in long format
    @MonthNr:      The number of the month (e.g. 1=jan)
    @LanguageCode: The language code to use for multilanguage output (1=german)
  -
  RETURNS: The name of the desired month as varchar in long format
=================================================================================================
TEST:    SELECT dbo.fnXMonatML(1, 1);
         SELECT dbo.fnXMonatML(1, 2);
         SELECT dbo.fnXMonatML(1, 3);
=================================================================================================*/

CREATE FUNCTION dbo.fnXMonatML
(
  @MonthNr INT,
  @LanguageCode INT
)
RETURNS VARCHAR(50)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- french  
  -----------------------------------------------------------------------------  
  IF (@LanguageCode = 2)
  BEGIN
    RETURN CASE @MonthNr
             WHEN  1 THEN 'Janvier'
             WHEN  2 THEN 'Février'
             WHEN  3 THEN 'Mars'
             WHEN  4 THEN 'Avril'
             WHEN  5 THEN 'Mai'
             WHEN  6 THEN 'Juin'
             WHEN  7 THEN 'Juillet'
             WHEN  8 THEN 'Août'
             WHEN  9 THEN 'Septembre'
             WHEN 10 THEN 'Octobre'
             WHEN 11 THEN 'Novembre'
             WHEN 12 THEN 'Décembre'
             ELSE ''
           END;
  END;
  
  -----------------------------------------------------------------------------
  -- italian  
  -----------------------------------------------------------------------------  
  IF (@LanguageCode = 3)
  BEGIN
    RETURN CASE @MonthNr
             WHEN  1 THEN 'Gennaio'
             WHEN  2 THEN 'Febbraio'
             WHEN  3 THEN 'Marzo'
             WHEN  4 THEN 'Aprile'
             WHEN  5 THEN 'Maggio'
             WHEN  6 THEN 'Giugno'
             WHEN  7 THEN 'Luglio'
             WHEN  8 THEN 'Agosto'
             WHEN  9 THEN 'Settembre'
             WHEN 10 THEN 'Ottobre'
             WHEN 11 THEN 'Novembre'
             WHEN 12 THEN 'Dicembre'
             ELSE ''
           END;
  END;
  
  -----------------------------------------------------------------------------
  -- default = german  
  -----------------------------------------------------------------------------  
  RETURN CASE @MonthNr
           WHEN  1 THEN 'Januar'
           WHEN  2 THEN 'Februar'
           WHEN  3 THEN 'März'
           WHEN  4 THEN 'April'
           WHEN  5 THEN 'Mai'
           WHEN  6 THEN 'Juni'
           WHEN  7 THEN 'Juli'
           WHEN  8 THEN 'August'
           WHEN  9 THEN 'September'
           WHEN 10 THEN 'Oktober'
           WHEN 11 THEN 'November'
           WHEN 12 THEN 'Dezember'
           ELSE ''
         END;
END;
GO