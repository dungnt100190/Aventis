SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXProfileTagsTextListe;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <Beschreibung der Function, Zweck und Einsatz>
    @ProfileID: Die Id des Profils.
    @LanguageCode: Die Sprache des Users.    
  -
  RETURNS: Holt die Merkmale (XProfileTags) und macht daraus ein ganzer String.
=================================================================================================
  TEST: SELECT dbo.fnXProfileTagsTextListe(1, 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnXProfileTagsTextListe
(
  @ProfileID INT,
  @LanguageCode INT 
)
RETURNS VARCHAR(MAX)
AS 
BEGIN
  RETURN STUFF((SELECT CONVERT(VARCHAR(MAX), SUB.Text)
                FROM (SELECT [Text] = '; ' + dbo.fnGetMLTextByDefault(PRT.NameTID, @LanguageCode, PRT.Name)
                      FROM dbo.XProfile_XProfileTag PPT WITH (READUNCOMMITTED)
                        INNER JOIN dbo.XProfileTag  PRT WITH (READUNCOMMITTED) ON PRT.XProfileTagID = PPT.XProfileTagID
                      WHERE PPT.XProfileID = @ProfileID) AS SUB 
                ORDER BY SUB.[Text]
                FOR XML PATH('')), 1, 2, '');
END;
GO
