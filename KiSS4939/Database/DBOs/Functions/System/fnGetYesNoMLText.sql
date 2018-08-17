SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetYesNoMLText;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetYesNoMLText.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:10 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a multilanguage gender title (m/f)
    @FlagValue:          The flag to get text for (1=true, 0=false)
    @LanguageCode:       The languagecode to use
    @ShowUnknownAsText:  Set if NULL-flag has to be handled as text or empty (1='Unknown', 0='')
  -
  RETURNS: '' if not defined or invalid or ML text (as: yes/no) if possible
  -
  TEST:    SELECT [dbo].[fnGetYesNoMLText](1, 1, 0)
           SELECT [dbo].[fnGetYesNoMLText](2, 1, 0)
           SELECT [dbo].[fnGetYesNoMLText](NULL, 1, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetYesNoMLText.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:41 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetYesNoMLText
(
  @FlagValue BIT,
  @LanguageCode INT,
  @ShowUnknownAsText BIT
)
RETURNS varchar(2000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate and return value
  -----------------------------------------------------------------------------
  RETURN CASE WHEN @FlagValue = 0 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'No', @LanguageCode)
              WHEN @FlagValue = 1 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'Yes', @LanguageCode)
              ELSE CASE WHEN ISNULL(@ShowUnknownAsText, 0) = 1 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'Unknown', @LanguageCode)
                        ELSE ''
                   END
              END
END

GO