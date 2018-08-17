SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetAnredeAnschriftBaInstitution;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get 'Anrede' and 'Briefanrede' for institutions-
   @BaInstitutionID:  The id of the institution to get data title from (can be NULL if @GenderCode is given)
   @GenderCode:       The gender code of the person (if NULL, @BaInstitutionID is required) where 1=m, 2=f
   @LanguageCode:     The language code to use for multilanguage texts
   @ReturnMode:       - 'herrfrau': return "Herr" or "Frau"
                      - 'geehrte': return "Sehr geehrter Herr" or "Sehr geehrte Frau"
   @AppendString:     The string value to append if value found
  -
  RETURNS: The desired value or '' if invalid or empty value found.
           BaInstitutionID is given: Automatic generated text if Flag ManuelleAnrede=0, otherwise manual entered
                                     text of Anrede or Briefanrede ('' if empty)
           BaInstitutionID is empty: Only automatic generated text
=================================================================================================
  TEST:    SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(NULL, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(NULL, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(NULL, 1, 1, 'geehrte', '');
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(4, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(4, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(4, 1, 1, 'geehrte', '');
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(520, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(520, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(520, 1, 1, 'geehrte', '');
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(4178, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(4178, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(4178, 1, 1, 'geehrte', '');
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(232, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(232, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(232, 1, 1, 'geehrte', '');
 =================================================================================================*/

CREATE FUNCTION dbo.fnBaGetAnredeAnschriftBaInstitution
(
  @BaInstitutionID INT,
  @GenderCode INT,
  @LanguageCode INT,
  @ReturnMode VARCHAR(20),
  @AppendString VARCHAR(255) 
)
RETURNS VARCHAR(255)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@ReturnMode NOT IN ('herrfrau', 'geehrte'))
  BEGIN
    -- invalid values, cannot return a valid text
    RETURN '';
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnValue VARCHAR(255);
  --
  DECLARE @ManuelleAnrede BIT;
  DECLARE @Anrede VARCHAR(100);
  DECLARE @Briefanrede VARCHAR(100);
  DECLARE @BaInstitutionArtCode INT;
  
  -- default values
  SET @LanguageCode = ISNULL(@LanguageCode, 1);   -- default is german
  SET @AppendString = ISNULL(@AppendString, '');  -- no append string if NULL given
  
  SET @ManuelleAnrede = 0;
  SET @Anrede = '';
  SET @Briefanrede = '';
  SET @BaInstitutionArtCode = -1;
  
  -----------------------------------------------------------------------------
  -- get values if only BaInstitutionID is given
  -----------------------------------------------------------------------------
  IF (@BaInstitutionID IS NOT NULL)
  BEGIN
    SELECT @GenderCode           = INS.GeschlechtCode,
           @ManuelleAnrede       = INS.ManuelleAnrede,
           @Anrede               = INS.Anrede,
           @Briefanrede          = INS.Briefanrede,
           @BaInstitutionArtCode = ISNULL(INS.BaInstitutionArtCode, -1)
    FROM dbo.BaInstitution INS WITH (READUNCOMMITTED)
    WHERE INS.BaInstitutionID = @BaInstitutionID; 
  END;
  
  -----------------------------------------------------------------------------
  -- mode and age depending result
  -----------------------------------------------------------------------------
  -- return value depending on mode
  IF (@ReturnMode = 'herrfrau')
  BEGIN
    -- Anrede: "Herr/Frau" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 0 THEN CASE
                                                         WHEN @BaInstitutionArtCode = 1 THEN NULL   -- no Anrede for institution
                                                         ELSE dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, @LanguageCode, NULL)
                                                       END
                         ELSE @Anrede
                       END;
  END
  ELSE IF (@ReturnMode = 'geehrte')
  BEGIN
    -- Briefanrede: "Sehr geehrte(r) Herr/Frau" OR "Sehr geehrte Damen und Herren" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 0 THEN CASE
                                                         WHEN @BaInstitutionArtCode = 1 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'SehrGeehrteDamenHerren', @LanguageCode)
                                                         ELSE dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, @LanguageCode, NULL) -- sehr geehrte(r) herr/frau
                                                       END
                         ELSE @Briefanrede
                       END;
  END;
  
  -----------------------------------------------------------------------------
  -- done, prepare and return value
  -----------------------------------------------------------------------------
  RETURN CASE 
           WHEN ISNULL(@ReturnValue, '') = '' THEN ''
           ELSE @ReturnValue + @AppendString
         END;
END;
GO 