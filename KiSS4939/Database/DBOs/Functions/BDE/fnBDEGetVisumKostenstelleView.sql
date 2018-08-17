SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
EXECUTE dbo.spDropObject fnBDEGetVisumKostenstelleView;
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Creates the table data for the 'Visum Kostenstelle' window.
   @KostenstelleOrgUnitID: The id of the OrgUnit pertaining to a Kostenstelle
   @Date:                  The date of the month concerned
   @UserID:                The user who want's to get data
   @LanguageCode:          The language code used for multilanguage content
   @UserHasHSRights:       Flag if user has rights of Hauptsitz and therefore can see all users
                           with all data like administrator (1=has rights, 0=only default rights)
   @UserHasKGSRights:      Flag if user has rights of KGS and therefore can see all users depending
                           on ZLE-rights (1=has rights, 0=only default rights)
  -
  RETURNS: The data for the tabular view of the 'Visum Kostenstelle' window.
=================================================================================================
  TEST:    SELECT * FROM dbo.fnBDEGetVisumKostenstelleView(10, '2008-08-04', 2, 1, 0, 0)
           SELECT * FROM dbo.fnBDEGetVisumKostenstelleView(19, '2008-05-01', 2, 1, 0, 0)
           SELECT * FROM dbo.fnBDEGetVisumKostenstelleView(19, '2008-05-01', 1513, 1, 0, 0)
           --
           SELECT * FROM dbo.fnBDEGetVisumKostenstelleView(NULL, '2008-05-01', 1513, 1, 1, 1)
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetVisumKostenstelleView
(
  @KostenstelleOrgUnitID INT, 
  @Date DATETIME,
  @UserID INT,
  @LanguageCode INT,
  @UserHasHSRights BIT,
  @UserHasKGSRights BIT
)
RETURNS @Result TABLE
(
  UserID INT PRIMARY KEY NOT NULL,
  --
  Auswahl BIT,
  --
  Kostenstelle VARCHAR(200),
  Mitarbeiter VARCHAR(200),
  MitarbeiterNr VARCHAR(50),
  Freigegeben BIT,
  Visiert BIT,
  Verbucht DATETIME,
  VerbuchtLD DATETIME,
  --
  PensumProzent INT,
  GZIstArbeitszeitProMonat MONEY,
  GZSollArbeitszeitProMonat MONEY,
  GZMonatsSaldo MONEY,
  GZSaldo MONEY,
  GZUebertragVorjahr MONEY,
  GZKorrekturen MONEY,
  GZAusbezahlteUeberstunden MONEY,
  --
  SLIstArbeitszeitProMonat MONEY,
  --
  FerienBezogenMonat MONEY,
  FerienSaldo MONEY,
  FerienUebertragVorjahr MONEY, 
  FerienAnspruchProJahr MONEY,
  FerienBisherBezogen MONEY,
  FerienZugabenKuerzungen MONEY,
  FerienKorrekturen MONEY,
  --
  Zeitraum VARCHAR(50)
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  SET @KostenstelleOrgUnitID = ISNULL(@KostenstelleOrgUnitID, -1);
  SET @Date                  = ISNULL(@Date, '1754-01-01');
  SET @UserID                = ISNULL(@UserID, -1);
  SET @LanguageCode          = ISNULL(@LanguageCode, -1);
  SET @UserHasHSRights       = ISNULL(@UserHasHSRights, 0);
  SET @UserHasKGSRights      = ISNULL(@UserHasKGSRights, 0);
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @EndOfLastYear DATETIME;
  DECLARE @EndOfLastMonth DATETIME;
  
  SET @EndOfLastYear  = dbo.fnGetDateFromInts(31, 12, YEAR(@Date) - 1);
  SET @EndOfLastMonth = DATEADD(d, -1, dbo.fnFirstDayOf(@Date));
  
  -- validate vars
  IF (@EndOfLastYear IS NULL OR @EndOfLastMonth IS NULL)
  BEGIN
    -- invalid values
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- fill the table variable with the rows for your result set
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT 
      UserID                    = LEI.UserID,
      --
      Auswahl                   = CONVERT(BIT, 0),
      --
      Kostenstelle              = (SELECT dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName)
                                   FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                                   WHERE ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(LEI.UserID, 1))),
      Mitarbeiter               = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
      MitarbeiterNr             = (SELECT SUSR.MitarbeiterNr
                                   FROM dbo.XUser SUSR WITH (READUNCOMMITTED)
                                   WHERE SUSR.UserID = LEI.UserID),
      Freigegeben               = 0,   -- update later
      Visiert                   = 0,   -- update later
      Verbucht                  = 0,   -- update later
      VerbuchtLD                = 0,   -- update later
      --
      PensumProzent             = dbo.fnBDEGetPensumPercent(LEI.UserID, @Date),
      GZIstArbeitszeitProMonat  = 0.0, -- update later
      GZSollArbeitszeitProMonat = 0.0, -- update later
      GZMonatsSaldo             = 0.0, -- updated later
      GZSaldo                   = dbo.fnBDEGetGleitzeitSaldo(LEI.UserID, @Date),
      GZUebertragVorjahr        = ISNULL(dbo.fnBDEGetGleitzeitSaldo(LEI.UserID, @EndOfLastYear), 0.0),      -- till end of last year
      GZKorrekturen             = ISNULL(dbo.fnBDEGetGleitzeitKorrekturen(LEI.UserID, @Date, 1), 0.0),      -- only current year
      GZAusbezahlteUeberstunden = ISNULL(dbo.fnBDEGetAusbezahlteUeberstunden(LEI.UserID, @Date, 1), 0.0),   -- only current year
      --      
      SLIstArbeitszeitProMonat  = 0.0, -- update later
      --
      FerienBezogenMonat        = 0.0, -- updated later
      FerienSaldo               = ISNULL(dbo.fnBDEGetFerienSaldo(LEI.UserID, @Date), 0.0),
      FerienUebertragVorjahr    = ISNULL(dbo.fnBDEGetFerienSaldo(LEI.UserID, @EndOfLastYear), 0.0),         -- till end of last year
      FerienAnspruchProJahr     = ISNULL(dbo.fnBDEGetFerienAnspruch(LEI.UserID, @Date, 1), 0.0),            -- only current year
      FerienBisherBezogen       = ISNULL(dbo.fnBDEGetErfassteFerien(LEI.UserID, @Date, 1), 0.0),            -- only current year
      FerienZugabenKuerzungen   = ISNULL(dbo.fnBDEGetFerienZugabenKuerzungen(LEI.UserID, @Date, 1), 0.0),   -- only current year
      FerienKorrekturen         = ISNULL(dbo.fnBDEGetFerienKorrekturen(LEI.UserID, @Date, 1), 0.0),         -- only current year,
      --
      Zeitraum                  = NULL -- update later
    FROM dbo.BDELeistung LEI
      INNER JOIN dbo.fnBDEGetOEUserListExtended(@UserID, 0, @UserHasHSRights) USR ON USR.Code = LEI.UserID  -- select only allowed users (SECURITY)
    WHERE (@KostenstelleOrgUnitID < 0 OR LEI.KostenstelleOrgUnitID = @KostenstelleOrgUnitID) AND            -- filter by given orgunit
          YEAR(LEI.Datum) = YEAR(@Date) AND                                                                 -- filter by given year
          MONTH(LEI.Datum) = MONTH(@Date)                                                                   -- filter by given month
    GROUP BY LEI.UserID;
  
  -----------------------------------------------------------------------------
  -- update pending data
  -----------------------------------------------------------------------------
  -- declare cursor vars
  DECLARE @CurUserID INT;
  
  -- setup cursor
  DECLARE curUsers CURSOR FAST_FORWARD FOR
    SELECT RES.UserID
    FROM @Result RES;
  
  -- iterate through cursor
  OPEN curUsers;
  WHILE 1 = 1
  BEGIN
    -- read next row and check if we have one
    FETCH NEXT 
    FROM curUsers 
    INTO @CurUserID;
    
    IF (@@FETCH_STATUS != 0)
    BEGIN
      BREAK;
    END;
    
    -- update pending data
    UPDATE RES
    SET RES.Freigegeben               = ISNULL(GLM.Freigegeben, 0),
        RES.Visiert                   = ISNULL(GLM.Visiert, 0),
        RES.Verbucht                  = GLM.Verbucht,
        RES.VerbuchtLD                = GLM.VerbuchtLD,
        --
        RES.GZIstArbeitszeitProMonat  = ISNULL(GLM.GZIstArbeitszeitProMonat, 0.0),
        RES.GZSollArbeitszeitProMonat = ISNULL(GLM.GZSollArbeitszeitProMonat, 0.0),
        RES.GZMonatsSaldo             = ISNULL(GLM.GZMonatsSaldo, 0.0),
        --
        RES.SLIstArbeitszeitProMonat  = ISNULL(GLM.SLIstArbeitszeitProMonat, 0.0),
        --
        RES.FerienBezogenMonat        = ISNULL(CASE WHEN MONTH(@Date) = 1 THEN RES.FerienBisherBezogen -- only current year (first month)
                                                    ELSE RES.FerienBisherBezogen - ISNULL(dbo.fnBDEGetErfassteFerien(RES.UserID, (DATEADD(d, -1, dbo.fnFirstDayOf(@Date))), 1), 0) -- only current month within same year (end of current month - end of last month)!
                                               END, 0.0),
        --
        RES.Zeitraum                  = dbo.fnGetZeitraumString(GLM.MonatStartDatum, GLM.MonatEndDatum)
    FROM @Result RES
      INNER JOIN dbo.fnBDEGetLeistungMonat(@CurUserID, @LanguageCode, MONTH(@Date), YEAR(@Date)) GLM ON GLM.UserID = RES.UserID  -- get data for given user
    WHERE RES.UserID = @CurUserID;
  END; -- [WHILE cursor]
  
  -- clean up cursor
  CLOSE curUsers;
  DEALLOCATE curUsers;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
