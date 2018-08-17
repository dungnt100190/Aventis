SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetLohnartText;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Lohnart-Text for given code, user, date and language
    @UserID:  The user who owns the item
    @Date:    The date where the item was booked
    @LohnartCode:  The code for the Lohnart
    @LanguageCode: The language to use for the text
  -
  RETURNS: The text for given value if defined or '' if not found
  -
=================================================================================================
  TEST:    SELECT [dbo].[fnBDEGetLohnartText](2, '2007-06-30', 1100, 2)
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetLohnartText
(
  @UserID INT,
  @Date DATETIME,
  @LohnartCode INT,
  @LanguageCode INT
)
RETURNS VARCHAR(255)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@UserID IS NULL OR @Date IS NULL)
  BEGIN
    RETURN '';
  END;

  -- handle LohnartCode = NULL as Monatslohn (like everywhere else, too)
  SET @LohnartCode = ISNULL(@LohnartCode, -1);

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @LohnartText VARCHAR(255);

  -----------------------------------------------------------------------------
  -- LohnartCode depending handling
  -----------------------------------------------------------------------------
  IF (@LohnartCode = -1)
  BEGIN
    ---------------------------------------------------------------------------
    -- Monatslohn
    ---------------------------------------------------------------------------
    SET @LohnartText = dbo.fnXDbObjectMLMsg('fnBDEGetLohnartDropDown', 'MonatslohnEntry', @LanguageCode);
  END
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- Stundenlohn
    ---------------------------------------------------------------------------
    -- create vars
    DECLARE @StundenlohnAmount MONEY
    DECLARE @LAItemID VARCHAR(50)

    ---------------------------------------------------------------------------
    -- Lohnart text as ML
    ---------------------------------------------------------------------------
    SELECT @LohnartText = dbo.fnGetLOVMLText(LOV.LOVName, LOV.Code, @LanguageCode),
           @LAItemID = LOV.Value1
    FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
    WHERE LOVName = 'BDELohnart'
      AND Code = @LohnartCode;

    -- get amount from history
    SELECT TOP 1
      @StundenlohnAmount = CASE @LAItemID
                             WHEN 'LA1' THEN ISNULL(HSA.Lohnart1, 0)
                             WHEN 'LA2' THEN ISNULL(HSA.Lohnart2, 0)
                             WHEN 'LA3' THEN ISNULL(HSA.Lohnart3, 0)
                             WHEN 'LA4' THEN ISNULL(HSA.Lohnart4, 0)
                             WHEN 'LA5' THEN ISNULL(HSA.Lohnart5, 0)
                             WHEN 'LA6' THEN ISNULL(HSA.Lohnart6, 0)
                             WHEN 'LA7' THEN ISNULL(HSA.Lohnart7, 0)
                             WHEN 'LA8' THEN ISNULL(HSA.Lohnart8, 0)
                             WHEN 'LA9' THEN ISNULL(HSA.Lohnart9, 0)
                             WHEN 'LA10' THEN ISNULL(HSA.Lohnart10, 0)
                             WHEN 'LA11' THEN ISNULL(HSA.Lohnart11, 0)
                             WHEN 'LA12' THEN ISNULL(HSA.Lohnart12, 0)
                             WHEN 'LA13' THEN ISNULL(HSA.Lohnart13, 0)
                             WHEN 'LA14' THEN ISNULL(HSA.Lohnart14, 0)
                             WHEN 'LA15' THEN ISNULL(HSA.Lohnart15, 0)
                             WHEN 'LA16' THEN ISNULL(HSA.Lohnart16, 0)
                             WHEN 'LA17' THEN ISNULL(HSA.Lohnart17, 0)
                             WHEN 'LA18' THEN ISNULL(HSA.Lohnart18, 0)
                             WHEN 'LA19' THEN ISNULL(HSA.Lohnart19, 0)
                             WHEN 'LA20' THEN ISNULL(HSA.Lohnart20, 0)
                             ELSE -1.0 -- not defined, should not occur
                           END
    FROM dbo.Hist_XUserStundenansatz HSA WITH (READUNCOMMITTED)
      INNER JOIN dbo.HistoryVersion  HIS WITH (READUNCOMMITTED) ON HIS.VerID = HSA.VerID
    WHERE HSA.UserID = @UserID
      AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date  -- only those entries earlier or like given date
    ORDER BY HIS.VersionDate DESC, HIS.VerID DESC;

    -- validate
    SET @LohnartText = ISNULL(@LohnartText, '<?>');

    -- append to text
    SET @LohnartText = @LohnartText + ISNULL(' (' + CONVERT(VARCHAR(50), @StundenlohnAmount) + ' SFr.)', '');
  END;

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@LohnartText, '');
END;
GO
