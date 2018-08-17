SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetAnredeAnschriftBaInstitutionKontakt;
GO
/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get 'Anrede' and 'Briefanrede' for contact persons of institutions
   @BaInstitutionKontaktID:  The id of the contact person to get data title from (can be NULL if @GenderCode is given)
   @GenderCode:       The gender code of the contact person (if NULL, @BaInstitutionKontaktID is required) where 1=m, 2=f
   @LanguageCode:     The language code to use for multilanguage texts
   @ReturnMode:       - 'herrfrau': return "Herr" or "Frau"
                      - 'geehrte': return "Sehr geehrter Herr" or "Sehr geehrte Frau"
   @AppendString:     The string value to append if value found
  -
  RETURNS: The desired value or '' if invalid or empty value found.
           BaInstitutionKontaktID is given: Automatic generated text if Flag ManuelleAnrede=0, otherwise manual entered
                                            text of Anrede or Briefanrede ('' if empty)
           BaInstitutionKontaktID is empty: Only automatic generated text
  -
  TEST:    SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(NULL, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(NULL, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(NULL, 1, 1, 'geehrte', '');
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(1906, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(1906, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(1906, 1, 1, 'geehrte', '');
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(1922, 1, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(1922, 2, 1, 'herrfrau', '');
           SELECT dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(1922, 1, 1, 'geehrte', '');
=================================================================================================
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt
(
  @BaInstitutionKontaktID INT,
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
  
  -- default values
  SET @LanguageCode = ISNULL(@LanguageCode, 1);   -- default is german
  SET @AppendString = ISNULL(@AppendString, '');  -- no append string if NULL given
  
  SET @ManuelleAnrede = 0;
  SET @Anrede = '';
  SET @Briefanrede = '';
  
  -----------------------------------------------------------------------------
  -- get values if only BaPersonID is given
  -----------------------------------------------------------------------------
  IF (@BaInstitutionKontaktID IS NOT NULL)
  BEGIN
    SELECT @GenderCode     = INK.GeschlechtCode,
           @ManuelleAnrede = INK.ManuelleAnrede,
           @Anrede         = INK.Anrede,
           @Briefanrede    = INK.Briefanrede
    FROM dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED)
    WHERE INK.BaInstitutionKontaktID = @BaInstitutionKontaktID; 
  END;
  
  -----------------------------------------------------------------------------
  -- mode and age depending result
  -----------------------------------------------------------------------------
  -- return value depending on mode
  IF (@ReturnMode = 'herrfrau')
  BEGIN
    -- Anrede: "Herr/Frau" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 0 THEN dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, @LanguageCode, NULL)
                         ELSE @Anrede
                       END;
  END
  ELSE IF (@ReturnMode = 'geehrte')
  BEGIN
    -- Briefanrede: "Sehr geehrte(r) Herr/Frau" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 0 THEN dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, @LanguageCode, NULL) -- sehr geehrte(r) herr/frau
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