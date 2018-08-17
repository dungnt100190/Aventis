SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetShortedVarchar;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetShortedVarchar.sql $
  $Author: Cjaeggi $
  $Modtime: 9.12.09 15:03 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to shorten a specific varchar to maximum defined length including
           attachment string
   @OriginalVarchar:   The original varchar to shorten
   @MaxLength:         The maximum length including any additional attachment
   @TooLongAttachment: The attachment to append to result if original varchar is too long
  -
  RETURNS: Varchar with maximum length as given or shorter if original varchar is not too long, NULL if invalid
  -
  TEST:    SELECT dbo.fnGetShortedVarchar('original text', 5, '...')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetShortedVarchar.sql $
 * 
 * 2     9.12.09 15:06 Cjaeggi
 * Achitecture
 * 
 * 1     6.03.09 14:40 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnGetShortedVarchar
(
  @OriginalVarchar VARCHAR(MAX),
  @MaxLength INT,
  @TooLongAttachment VARCHAR(10)
)
RETURNS VARCHAR(MAX)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- check parameters
  IF (@OriginalVarchar IS NULL OR ISNULL(@MaxLength, -1) < 1)
  BEGIN
    -- invalid parameters, do not continue
    RETURN NULL;
  END;
  
  -- set attachment var
  SET @TooLongAttachment = ISNULL(@TooLongAttachment, '');
  
  -- check if maxlength is longer than attachment
  IF (@MaxLength <= LEN(@TooLongAttachment))
  BEGIN
    -- this would only return attachement and therefore not make any sense
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- check length
  -----------------------------------------------------------------------------
  IF (LEN(@OriginalVarchar) <= @MaxLength)
  BEGIN
    -- value is not too long
    RETURN @OriginalVarchar;
  END;
  
  -----------------------------------------------------------------------------
  -- do shorten varchar and return value
  -----------------------------------------------------------------------------
  RETURN SUBSTRING(@OriginalVarchar, 1, @MaxLength - LEN(@TooLongAttachment)) + @TooLongAttachment;
END;
GO