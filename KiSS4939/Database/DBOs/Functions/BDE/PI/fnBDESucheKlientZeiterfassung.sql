SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDESucheKlientZeiterfassung;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function in ZLE for searching client
    @UserID:       The id of the user who calls the function
    @LanguageCode: The language to use for multilanguage output
  -
  RETURNS: Data to show when searching client in ZLE
=================================================================================================
  TEST:    SELECT * FROM dbo.fnBDESucheKlientZeiterfassung(2, 1, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnBDESucheKlientZeiterfassung
(
  @UserID INT,
  @LanguageCode INT,
  @PersonNameVornameSearchString VARCHAR(255)
)
RETURNS TABLE
AS 
RETURN 
  SELECT [BaPersonID$]       = FCN.[BaPersonID$],
         [Nr.]               = FCN.[Nr.],
         [Name]              = FCN.[Name],
         [HE]                = dbo.fnGetLOVMLText('BaHilfslosenEntschaedigung', PRS.[HilfslosenEntschaedigungCode], @LanguageCode),
         [EL]                = PRS.[ErgaenzungsLeistungen],
         [Strasse]           = FCN.[Strasse],
         [Ort]               = FCN.[Ort],
         [Geburt]            = FCN.[Geburt]
  FROM dbo.fnDlgPersonSuchenKGSGastrecht(@UserID, 1, @PersonNameVornameSearchString) FCN
    INNER JOIN dbo.BaPerson                          PRS WITH (READUNCOMMITTED) ON PRS.[BaPersonID] = FCN.[BaPersonID$]
GO
