SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject fnCombineRTFTexts;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnCombineRTFTexts.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:32 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to combine rtf-texts to one including spacer
    @FirstRtfText:  The text first text containing rtf-flags
    @SecondRtfText: The text first text containing rtf-flags
    @Spacer:        The spacer text between both
  -
  RETURNS: Combined texts
  -
  TEST:    SELECT [dbo].[fnCombineRTFTexts]('{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}  \viewkind4\uc1\pard\fs20 Entlastung der Familie, Betreuung beider Kinder Enzo und Sarah\par  }', '{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}  \viewkind4\uc1\pard\fs20 Entlastung der Familie, Betreuung beider Kinder Enzo und Sarah\par  }', ' :: ')
==========================================================================================s=======
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnCombineRTFTexts.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     15.12.08 14:05 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnCombineRTFTexts
(
  @FirstRtfText VARCHAR(MAX),
  @SecondRtfText VARCHAR(MAX),
  @Spacer VARCHAR(50)
)
RETURNS VARCHAR(MAX)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- check first
  IF (ISNULL(@FirstRtfText, '') = '')
  BEGIN
    -- validate second
    IF (ISNULL(@SecondRtfText, '') = '')
    BEGIN
      -- empty second, too, do nothing
      RETURN NULL
    END
    
    -- check if valid rtf
    IF (@SecondRtfText NOT LIKE '{\rtf1\ansi\ansicpg1252\deff0\deflang____{\fonttbl{\f0\fnil\fcharset0 Arial;}}%')
    BEGIN
      -- do nothing, pattern does not match
      RETURN 'Error: invalid second text (1)'
    END
    
    -- take only second but append spacer anyway
    SET @SecondRtfText = SUBSTRING(@SecondRtfText, 79, LEN(@SecondRtfText))      -- {\rtf1\ansi\ansicpg1252\deff0\deflang____{\fonttbl{\f0\fnil\fcharset0 Arial;}}
    SET @SecondRtfText = SUBSTRING(@SecondRtfText, 1, LEN(@SecondRtfText) - 1)   -- }
    
    -- add spacer and reformat as rtf
    SET @SecondRtfText = ISNULL(@Spacer, '') + @SecondRtfText
    SET @SecondRtfText = '{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}' + @SecondRtfText + '}' -- 2055 = german switzerland
    
    -- return value
    RETURN @SecondRtfText
  END
  
  -- check second
  IF (ISNULL(@SecondRtfText, '') = '')
  BEGIN
    -- take only first
    RETURN @FirstRtfText
  END
  
  -----------------------------------------------------------------------------
  -- check if valid rtf-text
  -----------------------------------------------------------------------------
  IF (@FirstRtfText NOT LIKE '{\rtf1\ansi\ansicpg1252\deff0\deflang____{\fonttbl{\f0\fnil\fcharset0 Arial;}}%')
  BEGIN
    -- do nothing, pattern does not match
    RETURN 'Error: invalid first text (2)'
  END
  
  IF (@SecondRtfText NOT LIKE '{\rtf1\ansi\ansicpg1252\deff0\deflang____{\fonttbl{\f0\fnil\fcharset0 Arial;}}%')
  BEGIN
    -- do nothing, pattern does not match
    RETURN 'Error: invalid second text (2)'
  END
  
  -----------------------------------------------------------------------------
  -- text is rtf, remove headers and final brakets
  -----------------------------------------------------------------------------
  SET @FirstRtfText = SUBSTRING(@FirstRtfText, 79, LEN(@FirstRtfText))         -- {\rtf1\ansi\ansicpg1252\deff0\deflang____{\fonttbl{\f0\fnil\fcharset0 Arial;}}
  SET @FirstRtfText = SUBSTRING(@FirstRtfText, 1, LEN(@FirstRtfText) - 1)      -- }
  
  SET @SecondRtfText = SUBSTRING(@SecondRtfText, 79, LEN(@SecondRtfText))      -- {\rtf1\ansi\ansicpg1252\deff0\deflang____{\fonttbl{\f0\fnil\fcharset0 Arial;}}
  SET @SecondRtfText = SUBSTRING(@SecondRtfText, 1, LEN(@SecondRtfText) - 1)   -- }
  
  -----------------------------------------------------------------------------
  -- combine texts
  -----------------------------------------------------------------------------
  SET @FirstRtfText = @FirstRtfText + ISNULL(@Spacer, '') + @SecondRtfText
  SET @FirstRtfText = '{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}' + @FirstRtfText + '}' -- 2055 = german switzerland
  
  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN @FirstRtfText
END
