SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnIsNullOrEmpty;
GO

/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnIsNullOrEmpty.sql $
  $Author: Spsota $
  $Modtime: 13.09.10 13:35 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: A mix between the T-SQL Function ISNULL and the C# Function string.isNullOrEmpty
    @ToTest: The original string to use
    @Alternative: The altenative string if the original is null or empty
    @Prefix: Prefix to set before the original or alternative string
    @Postfix: Postfix to set after the original or alternative string
  -
  RETURNS: The original string or alternative string with pre- and postfix. If 
           the alternative string is null or empty returns the alternative string without
           pre- or postfix.
  -
  TEST:    SELECT dbo.fnIsNullOrEmpty('', 'Alternative', NULL, NULL);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnIsNullOrEmpty.sql $
 * 
 * 1     13.09.10 13:35 Spsota
 * Initial check-in. 
 
=================================================================================================*/

CREATE FUNCTION dbo.fnIsNullOrEmpty
(
  @ToTest VARCHAR(MAX),
  @Alternative VARCHAR(MAX),
  @Prefix VARCHAR(200),
  @Postfix VARCHAR(200)
)
RETURNS VARCHAR(MAX)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Init
  -----------------------------------------------------------------------------
  SET @Prefix = ISNULL(@Prefix, '');
  SET @Postfix = ISNULL(@Postfix, '');
  -----------------------------------------------------------------------------
  -- Return 
  -----------------------------------------------------------------------------
  RETURN 
  CASE 
    WHEN (@ToTest IS NOT NULL AND @ToTest <> '') THEN @Prefix + @ToTest + @Postfix
    WHEN (@Alternative IS NOT NULL AND @Alternative <> '') THEN @Prefix + @Alternative + @Postfix
    ELSE @Alternative
  END;
END;
GO 