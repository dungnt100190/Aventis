SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetDefaultGemeindeCode;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Returns the default value for GemeindeCode based on the items of LOV GemeindeSozialdienst.
  -
  RETURNS: - NULL if there is more than one item in the LOV
           - the Code of the item of the LOV if there is exactly one item
=================================================================================================
  TEST:    SELECT dbo.fnGetDefaultGemeindeCode();
=================================================================================================*/

CREATE FUNCTION dbo.fnGetDefaultGemeindeCode()
RETURNS INT
AS 
BEGIN

  DECLARE @Count INT, @Code INT;

  SELECT @Count = COUNT(1),
         @Code = MIN(Code)
  FROM XLOVCode
  WHERE LOVName = 'GemeindeSozialdienst'

  IF(@Count = 1)
  BEGIN
    RETURN @Code;  
  END

  RETURN NULL;
END;
GO
