SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXGetPostfachTextML;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Determines the multilanguage text for Postfach address from parameters
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Postfach:       The text of the Postfach
    @PostfachOhneNr: The flag if the Postfach contains a valid content or is expected to be empty
    @LanguageCode:   The language code to use for ML texts
  -
  RETURNS: The multilanguage text for the Postfach as
           1) PostfachOhneNr = 1 >> '<PostfachMLText>'
           2) Postfach is not empty >> '<PostfachMLText> <PostfachContent>'
           3) Postfach is empty >> NULL
=================================================================================================
  TEST:    SELECT dbo.fnXGetPostfachTextML(NULL, NULL, 1);
           SELECT dbo.fnXGetPostfachTextML('123', 0, 1);
           SELECT dbo.fnXGetPostfachTextML('123', 1, 1);
           SELECT dbo.fnXGetPostfachTextML(NULL, 0, 1);
           SELECT dbo.fnXGetPostfachTextML(NULL, 1, 1);
           --
           SELECT dbo.fnXGetPostfachTextML('123', NULL, 1);
           SELECT dbo.fnXGetPostfachTextML('123', NULL, 2);
           SELECT dbo.fnXGetPostfachTextML('123', NULL, 3);
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetPostfachTextML
(
  @Postfach VARCHAR(100),
  @PostfachOhneNr BIT,
  @LanguageCode INT = 1
)
RETURNS VARCHAR(255) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- handle vars
  -----------------------------------------------------------------------------  
  DECLARE @PostfachMLText VARCHAR(100);
  
  -- due to performance, we set text here fixed for D/F/I (see: #6915)
  SELECT @PostfachMLText = CASE 
                             WHEN @LanguageCode = 1 THEN 'Postfach'        -- D
                             WHEN @LanguageCode = 2 THEN 'Case postale'    -- F
                             WHEN @LanguageCode = 3 THEN 'Casella postale' -- I
                             ELSE dbo.fnXDbObjectMLMsg('dbGeneral', 'Postfach', @LanguageCode)
                           END;
  
  -----------------------------------------------------------------------------
  -- return text depending on current data
  -----------------------------------------------------------------------------
  RETURN CASE
           WHEN ISNULL(@PostfachOhneNr, 0) = 1 THEN @PostfachMLText                   -- 1) the flag PostfachOhneNr is set, we show only Postfach (without evaluating text!)
           WHEN ISNULL(@Postfach, '') <> '' THEN @PostfachMLText + ' ' + @Postfach    -- 2) most common case: Postfach contains text
           ELSE NULL                                                                  -- 3) we do not have any postfach text
         END;
END;
GO