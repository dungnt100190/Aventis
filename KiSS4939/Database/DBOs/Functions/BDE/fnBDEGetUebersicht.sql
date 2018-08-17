SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetUebersicht;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get BDE overview of specific user and date
    @UserID:              The user to get data from
    @Date:                The date the values has to be calculated to.
    @LanguageCode:        The languagecode to use for displaying data
    @OnlyUserAdminFields: Show only data that are corresponding to system/user-admin/user control
  -
  RETURNS: Table containing all data used to display overview for user and date
=================================================================================================
  TEST:    SELECT * FROM [dbo].[fnBDEGetUebersicht](689, '2008-01-01', 1, 0)
           SELECT * FROM [dbo].[fnBDEGetUebersicht](515, GETDATE(), 1, 0)
           SELECT * FROM [dbo].[fnBDEGetUebersicht](69, GETDATE(), 1, 0)
           SELECT * FROM [dbo].[fnBDEGetUebersicht](567, GETDATE(), 1, 0)
           SELECT * FROM [dbo].[fnBDEGetUebersicht](2222221, GETDATE(), 1, 0)
           SELECT * FROM [dbo].[fnBDEGetUebersicht](515, GETDATE(), 1, 1)
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetUebersicht
(
  @UserID  INT,
  @Date DATETIME,
  @LanguageCode INT,
  @OnlyUserAdminFields BIT
)
RETURNS @Result TABLE
(
  UserID INT,
  MonatJahrText VARCHAR(255),
  PensumProzent INT,
  SollArbeitszeitProTag MONEY,
  GZIstArbeitszeitProMonat MONEY,
  GZSollArbeitszeitProMonat MONEY,
  GZMonatsSaldo MONEY,
  GZUebertragVorjahr MONEY,
  GZUebertragVormonate MONEY,
  GZKorrekturen MONEY,
  GZAusbezahlteUeberstunden MONEY,
  GZSaldo MONEY,
  SLIstArbeitszeitProMonat MONEY,
  FerienUebertragVorjahr MONEY,
  FerienAnspruchProJahr MONEY,
  FerienBisherBezogen MONEY,
  FerienZugabenKuerzungen MONEY,
  FerienKorrekturen MONEY,
  FerienSaldo MONEY
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (ISNULL(@UserID, -1) < 1 OR @Date IS NULL OR YEAR(@Date) < 2000 OR @LanguageCode IS NULL)
  BEGIN
    -- invalid parameters, do not continue
    RETURN;
  END;
  
  -- set bits
  SET @OnlyUserAdminFields = ISNULL(@OnlyUserAdminFields, 0);
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @EndOfLastYear DATETIME;
  DECLARE @EndOfLastMonth DATETIME;
  
  SET @EndOfLastYear = dbo.fnGetDateFromInts(31, 12, YEAR(@Date) - 1);
  SET @EndOfLastMonth = DATEADD(d, -1, dbo.fnFirstDayOf(@Date));
  
  -- validate vars
  IF (@EndOfLastYear IS NULL OR @EndOfLastMonth IS NULL)
  BEGIN
    -- invalid values
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- get non-calculateable values
  -- INFO: some fields are same as in dbo.fnBDEGetLeistungMonatView
  -----------------------------------------------------------------------------
  IF (@OnlyUserAdminFields = 0)
  BEGIN
    -- default behaviour, get all values
    INSERT INTO @Result
      SELECT UserID                     = @UserID,
             MonatJahrText              = dbo.fnXMonatJahrML(@Date, @LanguageCode),
             PensumProzent              = ISNULL(dbo.fnBDEGetPensumPercent(@UserID, @Date), 0),
             SollArbeitszeitProTag      = ISNULL(dbo.fnBDEGetSollProTag(@UserID, @Date), 0.0), 
             GZIstArbeitszeitProMonat   = 0.0, -- update later
             GZSollArbeitszeitProMonat  = 0.0, -- update later
             GZMonatsSaldo              = 0.0, -- update later
             GZUebertragVorjahr         = ISNULL(dbo.fnBDEGetGleitzeitSaldo(@UserID, @EndOfLastYear), 0.0), -- till end of last year
             GZUebertragVormonate       = ISNULL(dbo.fnBDEGetGleitzeitSaldo(@UserID, @EndOfLastMonth), 0.0), -- till end of last month (later: = (GZ-Saldo end of last month)-(GZ-Saldo end of last year))
             GZKorrekturen              = ISNULL(dbo.fnBDEGetGleitzeitKorrekturen(@UserID, @Date, 1), 0.0), -- only current year
             GZAusbezahlteUeberstunden  = ISNULL(dbo.fnBDEGetAusbezahlteUeberstunden(@UserID, @Date, 1), 0.0), -- only current year
             GZSaldo                    = ISNULL(dbo.fnBDEGetGleitzeitSaldo(@UserID, @Date), 0.0),
             SLIstArbeitszeitProMonat   = 0.0, -- update later
             FerienUebertragVorjahr     = ISNULL(dbo.fnBDEGetFerienSaldo(@UserID, @EndOfLastYear), 0.0), -- till end of last year
             FerienAnspruchProJahr      = ISNULL(dbo.fnBDEGetFerienAnspruch(@UserID, @Date, 1), 0.0), -- only current year
             FerienBisherBezogen        = ISNULL(dbo.fnBDEGetErfassteFerien(@UserID, @Date, 1), 0.0), -- only current year
             FerienZugabenKuerzungen    = ISNULL(dbo.fnBDEGetFerienZugabenKuerzungen(@UserID, @Date, 1), 0.0), -- only current year
             FerienKorrekturen          = ISNULL(dbo.fnBDEGetFerienKorrekturen(@UserID, @Date, 1), 0.0), -- only current year
             FerienSaldo                = ISNULL(dbo.fnBDEGetFerienSaldo(@UserID, @Date), 0.0);
    
    -----------------------------------------------------------------------------
    -- update calculateable values
    -----------------------------------------------------------------------------
    -- calculate GZ-Vormonate (only within current year)
    UPDATE @Result
    SET GZUebertragVormonate = GZUebertragVormonate - GZUebertragVorjahr;
  
    -- update GZ-values
    UPDATE @Result
    SET GZIstArbeitszeitProMonat   = ISNULL(GLM.GZIstArbeitszeitProMonat, 0.0),
        GZSollArbeitszeitProMonat  = ISNULL(GLM.GZSollArbeitszeitProMonat, 0.0),
        GZMonatsSaldo              = ISNULL(GLM.GZMonatsSaldo, 0.0),
        SLIstArbeitszeitProMonat   = ISNULL(GLM.SLIstArbeitszeitProMonat, 0.0)
    FROM dbo.fnBDEGetLeistungMonat(@UserID, @LanguageCode, MONTH(@Date), YEAR(@Date)) GLM;
  END
  ELSE
  BEGIN
    -- get only specific values used in system-control
    INSERT INTO @Result (UserID, MonatJahrText, PensumProzent, SollArbeitszeitProTag, GZSollArbeitszeitProMonat, 
                         GZAusbezahlteUeberstunden, FerienAnspruchProJahr, FerienZugabenKuerzungen)
      SELECT UserID                     = @UserID,
             MonatJahrText              = dbo.fnXMonatJahrML(@Date, @LanguageCode),
             PensumProzent              = ISNULL(dbo.fnBDEGetPensumPercent(@UserID, @Date), 0),
             SollArbeitszeitProTag      = ISNULL(dbo.fnBDEGetSollProTag(@UserID, @Date), 0.0), 
             GZSollArbeitszeitProMonat  = dbo.fnBDEGetSollProMonat(@UserID, @Date),                             -- validate later on
             GZAusbezahlteUeberstunden  = ISNULL(dbo.fnBDEGetAusbezahlteUeberstunden(@UserID, @Date, 1), 0.0),  -- only current year
             FerienAnspruchProJahr      = ISNULL(dbo.fnBDEGetFerienAnspruch(@UserID, @Date, 1), 0.0),           -- only current year
             FerienZugabenKuerzungen    = ISNULL(dbo.fnBDEGetFerienZugabenKuerzungen(@UserID, @Date, 1), 0.0);  -- only current year

    -- validate soll for 'Monatslohn' (same rule as in dbo.fnBDEGetLeistungMonat)
    UPDATE @Result
    SET GZSollArbeitszeitProMonat = CASE 
                                      WHEN ISNULL(GZSollArbeitszeitProMonat, -1) < 0.0 THEN 0.0  --(negative soll is not allowed)
                                      ELSE GZSollArbeitszeitProMonat
                                    END;
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO