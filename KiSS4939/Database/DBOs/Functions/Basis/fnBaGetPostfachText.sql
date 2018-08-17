SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetPostfachText;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Determines the multilanguage text for Postfach address with the option to give an ID
           of the address or directly the text to evaluate
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @BaAdresseID:    The id of the address to get Postfach from
    @Postfach:       If no BaAdresseID is given: The text of the Postfach
    @PostfachOhneNr: If no BaAdresseID is given: The flag if the Postfach contains a valid content
                     or is expected to be empty
    @LanguageCode:   The language code to use for ML texts
  -
  RETURNS: The multilanguage text for the Postfach as
           1) PostfachOhneNr = 1 >> '<PostfachMLText>'
           2) Postfach is not empty >> '<PostfachMLText> <PostfachContent>'
           3) Postfach is empty >> NULL
=================================================================================================
  TEST:    SELECT dbo.fnBaGetPostfachText(NULL, NULL, NULL, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, '123', 0, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, '123', 1, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, NULL, 0, 1);
           SELECT dbo.fnBaGetPostfachText(NULL, NULL, 1, 1);
           --
           SELECT dbo.fnBaGetPostfachText(505, NULL, NULL, 1);
           SELECT dbo.fnBaGetPostfachText(505, NULL, NULL, 2);
           SELECT dbo.fnBaGetPostfachText(505, NULL, NULL, 3);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetPostfachText
(
  @BaAdresseID INT,
  @Postfach VARCHAR(100),
  @PostfachOhneNr BIT,
  @LanguageCode INT = 1
)
RETURNS VARCHAR(255) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- check if need to get Postfach content
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaAdresseID, -1) > 0)
  BEGIN
    SELECT @Postfach = ADR.Postfach,
           @PostfachOhneNr = ADR.PostfachOhneNr
    FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
    WHERE ADR.BaAdresseID = @BaAdresseID;
  END;
  
  -----------------------------------------------------------------------------
  -- get Postfach content
  -----------------------------------------------------------------------------  
  RETURN dbo.fnXGetPostfachTextML(@Postfach, @PostfachOhneNr, @LanguageCode);
END;
GO