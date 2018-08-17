SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetAnredeAnschriftBaPerson;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get 'Anrede' and 'Anschrift' for persons with age (depending on mode):
           - < 16:  "Sehr geehrte Familie" instead of "Sehr geehrter Herr" or "Sehr geehrte Frau";
                    "Familie" instead of "Herr" or "Frau"
           - >= 16: "Sehr geehrter Herr" or "Sehr geehrte Frau" instead of "Sehr geehrte Familie";
                    "Herr" or "Frau" instead of "Familie"
   @BaPersonID:   The id of the person to get data title from (can be NULL if @Age and @GenderCode is given)
   @Age:          The age of the person (if NULL, either @BaPersonID or @DateOfBirth is required)
   @DateOfBirth:  The date of birth (if NULL, either @BaPersonID or @Age is required)
   @DateOfDeath:  The date of death used to calculate age with @DateOfBirth
   @GenderCode:   The gender code of the person (if NULL, @BaPersonID is required) where 1=m, 2=f
   @LanguageCode: The language code to use for multilanguage texts
   @ReturnMode:   - 'famherrfrau': return "Familie" or "Herr" or "Frau"
                  - 'geehrte': return "Sehr geehrte Familie" or "Sehr geehrter Herr" or "Sehr geehrte Frau"
   @AppendString: The string value to append if value found
  -
  RETURNS: The desired value or '' if invalid or empty value found
=================================================================================================
  TEST:    SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 1, NULL, NULL, 1, 1, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 1, 1, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 1, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 1, NULL, NULL, 1, 1, 'geehrte', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 1, 1, 'geehrte', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 1, 'geehrte', '', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 12, NULL, NULL, 1, 2, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 3, 'geehrte', ', NULL, NULL, NULL')
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 3, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(9, NULL, NULL, NULL, NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(-1, NULL, NULL, GETDATE(), NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, GETDATE(), NULL, NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, GETDATE(), NULL, NULL, 1, 'famherrfrau', '__', 1, 'anrede', 'briefanrede')
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, GETDATE(), NULL, NULL, 1, 'geehrte', '__', 1, 'anrede', 'briefanrede')
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'famherrfrau', '__', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'famherrfrau', '__', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'geehrte', '__', 1, 'anrede', 'briefanrede')
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetAnredeAnschriftBaPerson
(
  @BaPersonID INT,
  @Age INT,
  @DateOfBirth DATETIME,
  @DateOfDeath DATETIME,
  @GenderCode INT,
  @LanguageCode INT,
  @ReturnMode VARCHAR(20),
  @AppendString VARCHAR(255),
  @ManuelleAnrede BIT,
  @Anrede VARCHAR(100),
  @Briefanrede VARCHAR(100)
)
RETURNS VARCHAR(255)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnValue VARCHAR(255);
  DECLARE @IsUnderAge BIT;
  DECLARE @ReadDataFromBaPerson BIT;
  
  -- default values
  SET @LanguageCode = ISNULL(@LanguageCode, 1);   -- default is german
  SET @AppendString = ISNULL(@AppendString, '');  -- no append string if NULL given
  SET @ReadDataFromBaPerson = 0;
  
  -----------------------------------------------------------------------------
  -- if manual, we do not need any further calculations
  -----------------------------------------------------------------------------
  IF (ISNULL(@ManuelleAnrede, 0) = 0)
  BEGIN
    ---------------------------------------------------------------------------
    -- get values if only BaPersonID is given
    ---------------------------------------------------------------------------
    IF (@Age IS NULL)
    BEGIN
      IF (@DateOfBirth IS NULL)
      BEGIN
        -- get values from BaPerson
        SELECT @Age                  = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
               @GenderCode           = PRS.GeschlechtCode,
               @ManuelleAnrede       = PRS.ManuelleAnrede,
               @Anrede               = PRS.Anrede,
               @Briefanrede          = PRS.Briefanrede,
               @ReadDataFromBaPerson = 1
        FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
        WHERE PRS.BaPersonID = ISNULL(@BaPersonID, -1);  -- no BaPersonID given, set -1 for no data
      END
      ELSE
      BEGIN
        -- calculate @Age from @DateOfBirth and @DateOfDeath
        SET @Age = dbo.fnGetAge(@DateOfBirth, ISNULL(@DateOfDeath, GETDATE()));
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- get values if only BaPersonID is given and we did not read the Anrede above
    ---------------------------------------------------------------------------
    IF (@BaPersonID IS NOT NULL AND @ReadDataFromBaPerson = 0)
    BEGIN
      SELECT @ManuelleAnrede       = PRS.ManuelleAnrede,
             @Anrede               = PRS.Anrede,
             @Briefanrede          = PRS.Briefanrede
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID; 
    END;
    
    ---------------------------------------------------------------------------
    -- mode and age depending result
    ---------------------------------------------------------------------------
    -- set underage flag
    SET @IsUnderAge = CASE 
                        WHEN ISNULL(@Age, 99) < 16 THEN 1    -- if no age is defined, use non-underage, limit is 16 years old
                        ELSE 0
                      END;
  END;
  
  -- return value depending on mode
  IF (@ReturnMode = 'famherrfrau')
  BEGIN
    -- Anrede: "Familie/Herr/Frau" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 1 THEN @Anrede
                         WHEN @IsUnderAge = 1 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'Familie', @LanguageCode)            -- familie
                         ELSE dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, @LanguageCode, NULL) -- herr/frau
                       END;
  END
  ELSE IF (@ReturnMode = 'geehrte')
  BEGIN
    -- Briefanrede: "Sehr geehrte(r) Familie/Herr/Frau" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 1 THEN @Briefanrede
                         WHEN @IsUnderAge = 1 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'SehrGeehrteFamilie', @LanguageCode)                        -- sehr geehrte familie
                         ELSE dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, @LanguageCode, NULL) -- sehr geehrte(r) herr/frau
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