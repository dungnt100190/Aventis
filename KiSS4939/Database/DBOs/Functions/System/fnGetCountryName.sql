SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetCountryName
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetCountryName.sql $
  $Author: Cjaeggi $
  $Modtime: 7.08.09 11:54 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get country name depending on country id and language
    @CountryCode:        The id of the country in table BaLand
    @LanguageCode:       The language code (1=D, 2=F, 3=I)
    @NullIfSwitzerland:  1 = If country code is null or 147, no text will be returned
                         0 = The country name will be returned in any way (null = 147)
  -
  RETURNS: Converted value as varchar
  -
  TEST:    SELECT dbo.fnGetCountryName(NULL, 1, 0)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetCountryName.sql $
 * 
 * 3     7.08.09 11:54 Cjaeggi
 * Changed comments
 * 
 * 2     7.08.09 11:04 Cjaeggi
 * Changed to fit new table BaLand
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:40 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetCountryName
(
  @CountryCode INT,
  @LanguageCode INT,
  @NullIfSwitzerland BIT
)
RETURNS VARCHAR(255)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not value is passed, switzerland is taken
  SET @CountryCode = ISNULL(@CountryCode, 147) -- switzerland
  
  -----------------------------------------------------------------------------
  -- check if switzerland
  -----------------------------------------------------------------------------
  -- if @NullIfSwitzerland = 1 and switzerland, nothing will be returned
  IF (@NullIfSwitzerland = 1 AND @CountryCode = 147)
  BEGIN
    -- switzerland
    RETURN NULL
  END
  
  -----------------------------------------------------------------------------
  -- get multilanguage value
  ----------------------------------------------------------------------------- 
  RETURN dbo.fnLandMLText(@CountryCode, @LanguageCode)
END
GO