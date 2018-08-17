SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetMLTextByDefault;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetMLTextByDefault.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:40 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get translated text by TID and languagecode. If no translation
           exists, return given default text.
    @TID:          The Text-ID withing XLangText to use as identification for translation
    @LanguageCode: The language code to use for translation
    @DefaultText:  The default text to return if no translation was found
  -
  RETURNS: Return default text if tid and language does not return a value
  -
  TEST:    SELECT dbo.fnGetMLTextByDefault(100, 1, 'default')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetMLTextByDefault.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     9.02.09 15:25 Cjaeggi
 * Overworked and commented
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:41 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetMLTextByDefault
(
  @TID INT, 
  @LanguageCode INT, 
  @DefaultText VARCHAR(2000)
)
RETURNS VARCHAR(2000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- try to get ML-text defined in database and return default-text
  --   if no translation was found
  -----------------------------------------------------------------------------
  RETURN ISNULL(dbo.fnGetMLText(@TID, @LanguageCode), @DefaultText)
END
GO