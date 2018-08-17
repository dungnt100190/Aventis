SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXGetNumberFromText;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Extracts only the numbers from given text
    @Text: The text to parse for numbers
  -
  RETURNS: Numbers from given text or NULL if no numbers were found
=================================================================================================
  TEST:    SELECT dbo.fnXGetNumberFromText('40-902681-1');
           SELECT dbo.fnXGetNumberFromText('as4khd0939sdcc3345c3f78');
           SELECT dbo.fnXGetNumberFromText('hier.ist_eine@zah1\versteckt!Ääätsch!?');
           --
           SELECT dbo.fnXGetNumberFromText(NULL);
           SELECT dbo.fnXGetNumberFromText('');
           SELECT dbo.fnXGetNumberFromText('nurText');
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetNumberFromText
(
  @Text VARCHAR(255)
)
RETURNS BIGINT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@Text, '') = '')
  BEGIN
    -- no text to parse
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @OnlyNumbers VARCHAR(255); 
  SET @OnlyNumbers = '';

  SELECT @OnlyNumbers = @OnlyNumbers + CASE 
                                         WHEN OnlyNumbers LIKE '[0-9]' THEN OnlyNumbers 
                                         ELSE '' 
                                       END 
  FROM (SELECT OnlyNumbers = SUBSTRING(@Text, Tmp.number, 1)
        FROM (SELECT number
              FROM master..spt_values 
              WHERE type = 'p'
                 AND number BETWEEN 1 AND LEN(@Text)) AS Tmp) AS Tmp;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN CASE
           WHEN @OnlyNumbers = '' THEN NULL
           ELSE CONVERT(BIGINT, @OnlyNumbers)
         END;
END;
GO
