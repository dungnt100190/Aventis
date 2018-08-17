SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetGenderMLTitleMF;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetGenderMLTitleMF.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:09 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a multilanguage gender title (m/f)
    @GenderCode:       The gender code to use (1=m, 2=f)
    @LanguageCode:     The languagecode to use
  -
  RETURNS: '' if not defined or invalid or ML text (as: m/w) if found to gender
  -
  TEST:    SELECT [dbo].[fnGetGenderMLTitleMF](1, 1)
           SELECT [dbo].[fnGetGenderMLTitleMF](2, 1)
           SELECT [dbo].[fnGetGenderMLTitleMF](NULL, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetGenderMLTitleMF.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:40 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetGenderMLTitleMF
(
  @GenderCode INT,
  @LanguageCode INT
)
RETURNS varchar(2000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate and return value
  -----------------------------------------------------------------------------
  RETURN IsNull(dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'Masculin', 'Feminin', NULL, @LanguageCode, NULL), '')
END
GO