SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetGenderMLTitle;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetGenderMLTitle.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:06 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a multilanguage title
    @GenderCode:       The gender code to use (1=m, 2=f)
    @DBObjectName:     The dbobject-name to use for ml text
    @MessageNameMasc:  The message name to use for masculinum
    @MessageNameFem:   The message name to use for femininum
    @MessageNameUndef: The massage name to use if undefined
    @LanguageCode:     The languagecode to use
    @AppendString:     The string to append if value found
  -
  RETURNS: '' if not defined or invalid or ML text if found to gender
  -
  TEST:    SELECT [dbo].[fnGetGenderMLTitle](1, 'dbGeneral', 'Herr', 'Frau', NULL, 1, ' ')
           SELECT [dbo].[fnGetGenderMLTitle](2, 'dbGeneral', 'Herr', 'Frau', NULL, 1, ' ')
           SELECT [dbo].[fnGetGenderMLTitle](NULL, 'dbGeneral', 'Herr', 'Frau', NULL, 1, ' ')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetGenderMLTitle.sql $
 * 
 * 4     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 3     16.06.09 8:45 Cjaeggi
 * #4160: Changed test examples
 * 
 * 2     4.03.09 15:17 Cjaeggi
 * Fixed empty values behaviour and appendingstring for no gendercode.
 * Also trimming the return value.
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:40 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetGenderMLTitle
(
  @GenderCode INT,
  @DBObjectName VARCHAR(100),
  @MessageNameMasc VARCHAR(100),
  @MessageNameFem VARCHAR(100),
  @MessageNameUndef VARCHAR(100),
  @LanguageCode INT,
  @AppendString VARCHAR(255)
)
RETURNS VARCHAR(2000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnValue VARCHAR(2000)
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  SET @AppendString = ISNULL(@AppendString, '')
  
  -----------------------------------------------------------------------------
  -- get value depending on gender, message and language
  -----------------------------------------------------------------------------
  -- general if defined
  SET @ReturnValue = CASE @GenderCode WHEN 1 THEN ISNULL(dbo.fnXDbObjectMLMsg(@DBObjectName, @MessageNameMasc, @LanguageCode), '') + @AppendString
                                      WHEN 2 THEN ISNULL(dbo.fnXDbObjectMLMsg(@DBObjectName, @MessageNameFem, @LanguageCode), '') + @AppendString
                                      ELSE CASE WHEN ISNULL(@MessageNameUndef, '') <> '' THEN ISNULL(dbo.fnXDbObjectMLMsg(@DBObjectName, @MessageNameUndef, @LanguageCode), '') + @AppendString
                                                ELSE @AppendString
                                           END
                     END
  
  -----------------------------------------------------------------------------
  -- create date
  -----------------------------------------------------------------------------
  RETURN ISNULL(LTRIM(RTRIM(@ReturnValue)), '')
END
GO