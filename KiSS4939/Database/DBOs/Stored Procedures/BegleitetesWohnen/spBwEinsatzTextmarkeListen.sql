SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spBwEinsatzTextmarkeListen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/BegleitetesWohnen/spBwEinsatzTextmarkeListen.sql $
  $Author: Cjaeggi $
  $Modtime: 13.01.10 11:25 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this stored procedure to get data for almost same but different formated
           bookmarks on BwEinsatz
    @ShownIDsCsv:  The BwEinsatzIDs as csv-values to show
    @LanguageCode: The language code to use for multilanguage output
    @ResultTable:  The result table to show for given parameters
                   - 'ma_withfromto_longday'
                   - 'ma_withfromto_shortday'
                   - 'client_withfromto_longday'
                   - 'client_withfromto_shortday'
  -
  RETURNS: The desired table output for BwEinsatz as shown on gui (@ShownIDsCsv) for resulttable
  -
  TEST:    EXEC [dbo].[spBwEinsatzTextmarkeListen] '2,3,4', 1, 'ma_withfromto_longday'
           EXEC [dbo].[spBwEinsatzTextmarkeListen] '2,3,4', 1, 'ma_withfromto_shortday'
           --
           EXEC [dbo].[spBwEinsatzTextmarkeListen] '2,3,4', 1, 'client_withfromto_longday'
           EXEC [dbo].[spBwEinsatzTextmarkeListen] '2,3,4', 1, 'client_withfromto_shortday'
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/BegleitetesWohnen/spBwEinsatzTextmarkeListen.sql $
 * 
 * 5     13.01.10 11:28 Cjaeggi
 * #672: Replaced fn GetPersonTitle
 * 
 * 4     10.11.09 8:07 Cjaeggi
 * 
 * 3     10.11.09 8:07 Cjaeggi
 * #5185: Minor refactoring, removed join on XModul
 * 
 * 2     9.11.09 16:22 Spsota
 * 
 * 1     9.11.09 16:19 Spsota
 * #5185 Änderungen an SP und View für Textmarken (BW und ED
=================================================================================================*/

CREATE PROCEDURE dbo.spBwEinsatzTextmarkeListen
(
  @ShownIDsCsv VARCHAR(1000),
  @LanguageCode INT,
  @ResultTable VARCHAR(50)
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@ShownIDsCsv, '') = '' OR @ResultTable IS NULL)
  BEGIN
    -- do nothing
    RETURN
  END
  
  -- set default values
  SET @LanguageCode = ISNULL(@LanguageCode, -1)
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  -- init vars
  DECLARE @CrLf VARCHAR(10)
  DECLARE @From VARCHAR(20)
  DECLARE @To VARCHAR(20)
  DECLARE @TelP VARCHAR(10)
  DECLARE @TelM VARCHAR(10)
  --
  DECLARE @WeekdayFormat VARCHAR(10)
  
  -- set vars
  SET @CrLf = CHAR(13) + CHAR(10)
  SET @From = ISNULL(dbo.fnXDbObjectMLMsg('spEdEinsatzTextmarkeListen', 'ValueFrom', @LanguageCode), '')
  SET @To   = ISNULL(dbo.fnXDbObjectMLMsg('spEdEinsatzTextmarkeListen', 'ValueTo', @LanguageCode), '')
  SET @TelP = '(' + ISNULL(dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonPrivat', @LanguageCode), '') + ')'
  SET @TelM = '(' + ISNULL(dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonMobil', @LanguageCode), '') + ')'
  
  -- set weekday format
  SET @WeekdayFormat = CASE WHEN @ResultTable IN ('ma_withfromto_longday', 'client_withfromto_longday') THEN 'long'
                            ELSE 'short'
                       END
  
  -------------------------------------------------------------------------------
  -- fill temporary table with csv-values separated as rows
  -------------------------------------------------------------------------------
   -- init temp table to store csv values
  DECLARE @ShownIDs TABLE
  (
    ID INT IDENTITY(1, 1),
    OccurenceID INT NOT NULL,
    BwEinsatzID INT NOT NULL
  )
  
  -- fill table
  INSERT INTO @ShownIDs (OccurenceID, BwEinsatzID)
    SELECT OccurenceID = FCN.OccurenceID,
           BwEinsatzID = CONVERT(INT, FCN.SplitValue)
    FROM dbo.fnSplitStringToValues(@ShownIDsCsv, ',', 1) FCN
  
  -- info
  PRINT ('done with init, getting data now: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  SELECT Date       = LTRIM(RTRIM(@From + ' ' + dbo.fnGetWeekDayFromDate(dbo.fnDateOf(BWE.Beginn), @LanguageCode, @WeekdayFormat) + ', ' + ISNULL(CONVERT(VARCHAR, BWE.Beginn, 104), '') + @CrLf +
                                  @To + ' ' + dbo.fnGetWeekDayFromDate(dbo.fnDateOf(BWE.Ende), @LanguageCode, @WeekdayFormat) + ', ' + ISNULL(CONVERT(VARCHAR, BWE.Ende, 104), ''))),
         --
         NextCell   = NULL,
         --
         Hours      =  dbo.fnGetTimeOfDate(BWE.Beginn, 1) + @CrLf +
                       dbo.fnGetTimeOfDate(BWE.Ende, 1),
         --
         NextCell   = NULL,
         --
         DetailInfo = CASE WHEN @ResultTable IN ('ma_withfromto_longday', 'ma_withfromto_shortday') THEN
                             -- ma_withfromto_*, get client information
                             dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + @CrLf +
                             CASE WHEN PRS.Telefon_P IS NULL THEN ''
                                  ELSE PRS.Telefon_P + ' ' + @TelP
                             END +
                             CASE WHEN PRS.Telefon_P IS NOT NULL AND PRS.MobilTel IS NOT NULL THEN ', ' -- append separator if we also have a mobile number
                                  ELSE ''                            
                             END +
                             CASE WHEN PRS.MobilTel IS NULL THEN ''
                                  ELSE PRS.MobilTel + ' ' + @TelM
                             END
                           ELSE
                             -- client_withfromto_*, get Begleiter information
                             dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL) + @CrLf +
                             dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode) + 
                             CASE WHEN USR.PhoneMobile IS NOT NULL THEN ', ' + USR.PhoneMobile + ' ' + @TelM
                                  ELSE ''                            
                             END
                      END,
         --
         NextCell   = NULL,
         --
         Comments   = BWE.Bemerkungen,
         --
         NextCell   = NULL
  FROM dbo.BwEinsatz                           BWE WITH (READUNCOMMITTED)
    INNER JOIN @ShownIDs                       IDS ON IDS.BwEinsatzID = BWE.BwEinsatzID
    --
    INNER JOIN dbo.FaLeistung                  LEI ON LEI.FaLeistungID = BWE.FaLeistungID
    INNER JOIN dbo.BaPerson                    PRS ON PRS.BaPersonID = LEI.BaPersonID
    --
    LEFT  JOIN dbo.XUser_BwEinsatzvereinbarung UEV ON UEV.XUser_BwEinsatzvereinbarungID = BWE.XUser_BwEinsatzvereinbarungID
    LEFT  JOIN dbo.XUser                       USR ON USR.UserID = UEV.UserID
    LEFT  JOIN dbo.EdMitarbeiter               EDM ON EDM.UserID = USR.UserID
    INNER JOIN dbo.EdMitarbeiter_XModul        EXM ON EXM.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                  AND EXM.XModulID = 5 -- BW
  ORDER BY BWE.Beginn, BWE.Ende, dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname), dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL)
  
  -- info
  PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113))
END
GO
