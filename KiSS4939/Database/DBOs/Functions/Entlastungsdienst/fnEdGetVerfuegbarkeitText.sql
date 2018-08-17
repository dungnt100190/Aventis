SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnEdGetVerfuegbarkeitText;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Generiert einen Text mit Angaben der Verfügbarkeit eines Benutzers (aus Mitarbeiterverwaltung BW/ED)
    @EdVerfuegbarkeitID:
    @LanguageCode:
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT dbo.fnEdGetVerfuegbarkeitText(7, 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnEdGetVerfuegbarkeitText
(
  @EdVerfuegbarkeitID INT,
  @LanguageCode INT
)
RETURNS VARCHAR(MAX)
AS 
BEGIN
  DECLARE @Result VARCHAR(MAX);
  SET @Result = '';

  WITH VerfuegbarkeitCTE AS
  (
    SELECT
      EVT.EdVerfuegbarkeit_ProTagID,
      Verfuegbarkeit = REPLACE(dbo.Conc(CASE X.Tageszeit
                         WHEN 1 THEN CASE WHEN EVT.VerfuegbarMorgen = 1 THEN dbo.fnGetLOVMLText('Tageszeit', 1, @LanguageCode) ELSE NULL END
                         WHEN 2 THEN CASE WHEN EVT.VerfuegbarNachmittag = 1 THEN dbo.fnGetLOVMLText('Tageszeit', 2, @LanguageCode) ELSE NULL END
                         WHEN 3 THEN CASE WHEN EVT.VerfuegbarAbend = 1 THEN dbo.fnGetLOVMLText('Tageszeit', 3, @LanguageCode) ELSE NULL END
                         WHEN 4 THEN CASE WHEN EVT.VerfuegbarNacht = 1 THEN dbo.fnGetLOVMLText('Tageszeit', 4, @LanguageCode) ELSE NULL END
                         ELSE NULL
                       END), ',', ', ')
    FROM dbo.EdVerfuegbarkeit_ProTag EVT WITH(READUNCOMMITTED)
      CROSS JOIN (SELECT Code
                  FROM dbo.XLOVCode LOC WITH(READUNCOMMITTED)
                  WHERE LOVName = 'Tageszeit') X (Tageszeit)
    GROUP BY EVT.EdVerfuegbarkeit_ProTagID
  )
  SELECT @Result = @Result + CHAR(13) + CHAR(10) + dbo.fnGetLOVMLText('Wochentag', EVT.WochentagID, @LanguageCode) + ISNULL(' ' + NULLIF(CTE.Verfuegbarkeit, ''), '') + ISNULL(' ' + EVT.Bemerkungen, '')
  FROM dbo.EdVerfuegbarkeit_ProTag EVT WITH (READUNCOMMITTED)
    LEFT JOIN VerfuegbarkeitCTE    CTE ON CTE.EdVerfuegbarkeit_ProTagID = EVT.EdVerfuegbarkeit_ProTagID
                                      AND CTE.Verfuegbarkeit IS NOT NULL
  WHERE EVT.EdVerfuegbarkeitID = @EdVerfuegbarkeitID
    AND (EVT.VerfuegbarMorgen = 1 OR
         EVT.VerfuegbarNachmittag = 1 OR
         EVT.VerfuegbarAbend = 1 OR
         EVT.VerfuegbarNacht = 1 OR
         EVT.Bemerkungen IS NOT NULL);

  RETURN STUFF(@Result, 1, 2, '');
END;
GO
