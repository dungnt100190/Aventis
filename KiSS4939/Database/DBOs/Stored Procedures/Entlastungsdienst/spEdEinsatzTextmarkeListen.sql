SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spEdEinsatzTextmarkeListen;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this stored procedure to get data for almost same but different formated
           bookmarks on EdEinsatz
    @ShownIDsCsv:  The EdEinsatzIDs as csv-values to show
    @LanguageCode: The language code to use for multilanguage output
    @ResultTable:  The result table to show for given parameters
                   - 'ma_withfromto_longday'
                   - 'ma_withfromto_shortday'
                   - 'client_withfromto_longday'
                   - 'client_withfromto_shortday'
  -
  RETURNS: The desired table output for EdEinsatz as shown on gui (@ShownIDsCsv) for resulttable
=================================================================================================
  TEST:    EXEC [dbo].[spEdEinsatzTextmarkeListen] '2,3,4', 1, 'ma_withfromto_longday'
           EXEC [dbo].[spEdEinsatzTextmarkeListen] '2,3,4', 1, 'ma_withfromto_shortday'
           --
           EXEC [dbo].[spEdEinsatzTextmarkeListen] '2,3,4', 1, 'ma_withfromto_shortday', 1
           --
           EXEC [dbo].[spEdEinsatzTextmarkeListen] '2,3,4', 1, 'client_withfromto_longday'
           EXEC [dbo].[spEdEinsatzTextmarkeListen] '2,3,4', 1, 'client_withfromto_shortday'
=================================================================================================*/

CREATE PROCEDURE dbo.spEdEinsatzTextmarkeListen
(
  @ShownIDsCsv VARCHAR(1000),
  @LanguageCode INT,
  @ResultTable VARCHAR(50),
  @WithoutPhoneType BIT = 0
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@ShownIDsCsv, '') = '' OR @ResultTable IS NULL)
  BEGIN
    -- do nothing
    RETURN;
  END;
  
  -- set default values
  SET @LanguageCode = ISNULL(@LanguageCode, -1);
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  -- init vars
  DECLARE @CrLf VARCHAR(10);
  DECLARE @From VARCHAR(20);
  DECLARE @To VARCHAR(20);
  DECLARE @TelP VARCHAR(10);
  DECLARE @TelM VARCHAR(10);
  --
  DECLARE @WeekdayFormat VARCHAR(10);
  
  -- set vars
  SET @CrLf = CHAR(13) + CHAR(10);
  SET @From = ISNULL(dbo.fnXDbObjectMLMsg('spEdEinsatzTextmarkeListen', 'ValueFrom', @LanguageCode), '');
  SET @To   = ISNULL(dbo.fnXDbObjectMLMsg('spEdEinsatzTextmarkeListen', 'ValueTo', @LanguageCode), '');
  
  IF (@WithoutPhoneType = 0)
  BEGIN
    SET @TelP = '(' + ISNULL(dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonPrivat', @LanguageCode), '') + ')';
    SET @TelM = '(' + ISNULL(dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonMobil', @LanguageCode), '') + ')';
  END
  ELSE
  BEGIN
    SET @TelP = '';
    SET @TelM = '';
  END;
  
  -- set weekday format
  SET @WeekdayFormat = CASE 
                         WHEN @ResultTable IN ('ma_withfromto_longday', 'client_withfromto_longday') THEN 'long'
                         ELSE 'short'
                       END;
  
  -------------------------------------------------------------------------------
  -- fill temporary table with csv-values separated as rows
  -------------------------------------------------------------------------------
   -- init temp table to store csv values
  DECLARE @ShownIDs TABLE
  (
    ID INT IDENTITY(1, 1),
    OccurenceID INT NOT NULL,
    EdEinsatzID INT NOT NULL
  );
  
  -- fill table
  INSERT INTO @ShownIDs (OccurenceID, EdEinsatzID)
    SELECT OccurenceID = FCN.OccurenceID,
           EdEinsatzID = CONVERT(INT, FCN.SplitValue)
    FROM dbo.fnSplitStringToValues(@ShownIDsCsv, ',', 1) FCN;
  
  -- info
  PRINT ('done with init, getting data now: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  SELECT Date       = LTRIM(RTRIM(@From + ' ' + dbo.fnGetWeekDayFromDate(dbo.fnDateOf(EDE.Beginn), @LanguageCode, @WeekdayFormat) + ', ' + ISNULL(CONVERT(VARCHAR, EDE.Beginn, 104), '') + @CrLf +
                                  @To + ' ' + dbo.fnGetWeekDayFromDate(dbo.fnDateOf(EDE.Ende), @LanguageCode, @WeekdayFormat) + ', ' + ISNULL(CONVERT(VARCHAR, EDE.Ende, 104), ''))),
         --
         NextCell   = NULL,
         --
         Hours      =  dbo.fnGetTimeOfDate(EDE.Beginn, 1) + @CrLf +
                       dbo.fnGetTimeOfDate(EDE.Ende, 1),
         --
         NextCell   = NULL,
         --
         DetailInfo = CASE WHEN @ResultTable IN ('ma_withfromto_longday', 'ma_withfromto_shortday') THEN
                             -- ma_withfromto_*, get client information
                             dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + @CrLf +
                             CASE 
                               WHEN PRS.Telefon_P IS NULL THEN ''
                               ELSE RTRIM(PRS.Telefon_P + ' ' + @TelP)
                             END +
                             CASE 
                               WHEN PRS.Telefon_P IS NOT NULL AND PRS.MobilTel IS NOT NULL THEN ', ' -- append separator if we also have a mobile number
                               ELSE ''                            
                             END +
                             CASE 
                               WHEN PRS.MobilTel IS NULL THEN ''
                               ELSE RTRIM(PRS.MobilTel + ' ' + @TelM)
                             END
                           ELSE
                             -- client_withfromto_*, get Entlaster information
                             dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL) + @CrLf +
                             CASE 
                               WHEN @WithoutPhoneType = 0 THEN dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode)
                               ELSE ISNULL((SELECT COALESCE(SUSR.PhoneOffice, SUSR.PhoneIntern, SUSR.PhonePrivat, SUSR.PhoneMobile)
                                            FROM dbo.XUser SUSR WITH (READUNCOMMITTED)
                                            WHERE SUSR.UserID = UEV.UserID), '')
                             END + 
                             CASE 
                               WHEN USR.PhoneMobile IS NOT NULL THEN ', ' + RTRIM(USR.PhoneMobile + ' ' + @TelM)
                               ELSE ''                            
                             END
                      END,
         --
         NextCell   = NULL,
         --
         Comments   = EDE.Bemerkungen,
         --
         NextCell   = NULL
  FROM dbo.EdEinsatz                           EDE WITH (READUNCOMMITTED)
    INNER JOIN @ShownIDs                       IDS ON IDS.EdEinsatzID = EDE.EdEinsatzID
    --
    INNER JOIN dbo.FaLeistung                  LEI ON LEI.FaLeistungID = EDE.FaLeistungID
    INNER JOIN dbo.BaPerson                    PRS ON PRS.BaPersonID = LEI.BaPersonID
    --
    LEFT  JOIN dbo.XUser_EdEinsatzvereinbarung UEV ON UEV.XUser_EdEinsatzvereinbarungID = EDE.XUser_EdEinsatzvereinbarungID
    LEFT  JOIN dbo.XUser                       USR ON USR.UserID = UEV.UserID
    LEFT  JOIN dbo.EdMitarbeiter               EDM ON EDM.UserID = USR.UserID
    INNER JOIN dbo.EdMitarbeiter_XModul        EXM ON EXM.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                  AND EXM.XModulID = 6 -- ED
  ORDER BY EDE.Beginn, 
           EDE.Ende, 
           dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname), 
           dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL);
  
  -- info
  PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113));
END;
GO
