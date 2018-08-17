SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBDEGetLeistungWoche;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to get values (zeitrechner, ist) per week
    @UserID:       The user to get data from
    @LanguageCode: The language code to use for multilanguage content
  -
  RETURNS: Table containing all BDE data per day usable for weekgrouping
  -
  TEST:    EXEC dbo.spBDEGetLeistungWoche 2, 1
=================================================================================================*/

CREATE PROCEDURE dbo.spBDEGetLeistungWoche
(
  @UserID INT,
  @LanguageCode INT
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -- #5784: first day of week is monday! before changing, store current value
  DECLARE @OrigDateFirst INT;
  SET @OrigDateFirst = @@DATEFIRST;
  
  SET DATEFIRST 1;
  
  -------------------------------------------------------------------------------
  -- multilanguage
  -------------------------------------------------------------------------------
  DECLARE @MLTextCalendarWeek VARCHAR(10);
  SET @MLTextCalendarWeek = dbo.fnXDbObjectMLMsg('spBDEGetLeistungWoche', 'CalendarWeek', @LanguageCode);
  
  -------------------------------------------------------------------------------
  -- a temporary table for processing and collecting values
  -------------------------------------------------------------------------------
  DECLARE @TimePerWeek TABLE
  (
    ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Datum DATETIME NOT NULL,
    Woche INT NOT NULL,
    Zeitrechnertotal MONEY,
    Leistungtotal MONEY
  );
  
  -------------------------------------------------------------------------------
  -- get values from BDELeistung
  -- (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur, 5=Stunden-Import)
  -------------------------------------------------------------------------------
  INSERT @TimePerWeek (Datum, Woche, Leistungtotal)
    SELECT Datum         = LEI.Datum,
           Woche         = dbo.fnXGetISOWeekNumber(LEI.Datum),
           Leistungtotal = SUM(LEI.Dauer)
    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.BDELeistungsart ART WITH (READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID 
                                                               AND ART.LeistungsartTypCode IN (1, 3, 5)
    WHERE LEI.UserID = @UserID
    GROUP BY LEI.Datum;
  
  -------------------------------------------------------------------------------
  -- update values with times from Zeitrechner
  -------------------------------------------------------------------------------
  UPDATE TBL
  SET Zeitrechnertotal = (SELECT SUM(((CONVERT(MONEY, ZRE.ZeitBis) - FLOOR(CONVERT(MONEY, ZRE.ZeitBis))) -
                                 (CONVERT(MONEY, ZRE.ZeitVon) - FLOOR(CONVERT(MONEY, ZRE.ZeitVon)))) * 24)
                          FROM dbo.BDEZeitrechner ZRE WITH (READUNCOMMITTED)
                          WHERE Datum = TBL.Datum 
                            AND ZRE.UserID = @UserID 
                            AND ZRE.ZeitBis IS NOT NULL)
  FROM @TimePerWeek TBL;
  
  -------------------------------------------------------------------------------
  -- ouput table
  -------------------------------------------------------------------------------
  SELECT Jahr             = YEAR(TBL.Datum),
         Woche            = CONVERT(VARCHAR, YEAR(TBL.Datum)) + ': ' + @MLTextCalendarWeek + ' ' +
                            CASE 
                              WHEN TBL.Woche < 10 THEN '0' + CONVERT(VARCHAR, TBL.Woche)
                              ELSE CONVERT(VARCHAR, TBL.Woche)
                            END,
         WT               = dbo.fnBDEGetWeekDayFromDate(TBL.Datum, @LanguageCode),
         Datum            = TBL.Datum,
         Zeitrechnertotal = CONVERT(VARCHAR, TBL.Zeitrechnertotal, 1),
         TagesIst         = CONVERT(VARCHAR, TBL.Leistungtotal, 1),
         Differenz        = CONVERT(VARCHAR, TBL.Zeitrechnertotal - TBL.Leistungtotal, 1)
  FROM @TimePerWeek TBL
  ORDER BY TBL.Datum DESC;
  
  -------------------------------------------------------------------------------
  -- restore original setting as it is used per session!
  -------------------------------------------------------------------------------
  SET DATEFIRST @OrigDateFirst;
END;
GO