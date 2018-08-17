SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaIsPersonClientByRule;
GO

-------------------------------------------------------------------------------
-- setup properties because of indexed view usage
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function check if a person is a client defined by rule:
           - Active: a) In given year >= 1h in BDELeistung within given services (SB+CM)
                       from 1.1. of year to given date
                     b) In given year > 0.0h in BDELeistung within Dienstleistung BW, ED or AB
                     c) In given year > 0.0h in BDELeistung within PI-Auftrag "IEBI" (see #8010)
           - New: Active + Rules:
                  - Up to 5 years less, within each year less than 60min in BDELeistung within given services (SB+CM)
                    (year of given date - 5 --> 1.1. (e.g. 31.4.2008 --> 1.1.2003))
                  - If migrated person: No Fallverlauf.DatumBis within these 5 years (1.1. of current year - 5), etc.
    @BaPersonID:           The person to evaluate for active/new client
    @Date:                 The date to check if the person is client at this moment for current year
    @CheckIsNewClient:     1=Client has to be a new client (=active+not active in last 5y (1.1.))
    @CheckAdditionModules: 1=active is a) or b) or c), 0=active is only a)
  -
  RETURNS: 1 if person is client by rule; 0 if person is not client by rule; NULL if invalid or undefined
=================================================================================================
  TEST:    SELECT dbo.fnFaIsPersonClientByRule(4125, '2008-12-31', 0, 0)
           SELECT dbo.fnFaIsPersonClientByRule(4125, '2008-12-31', 0, 1)
           SELECT dbo.fnFaIsPersonClientByRule(4125, '2008-12-31', 1, 0)
           SELECT dbo.fnFaIsPersonClientByRule(4125, '2008-12-31', 1, 1)
           --
           SELECT dbo.fnFaIsPersonClientByRule(4294, '2011-12-31', 0, 1)
           --
           DECLARE @Date DATETIME;
           SET @Date = '2008-12-31';
           
           SELECT PRS.BaPersonID,
                  A = dbo.fnFaIsPersonClientByRule(PRS.BaPersonID, @Date, 0, 0),
                  B = dbo.fnFaIsPersonClientByRule(PRS.BaPersonID, @Date, 0, 1),
                  C = dbo.fnFaIsPersonClientByRule(PRS.BaPersonID, @Date, 1, 0),
                  D = dbo.fnFaIsPersonClientByRule(PRS.BaPersonID, @Date, 1, 1)
           FROM dbo.BaPerson PRS;
=================================================================================================*/

CREATE FUNCTION dbo.fnFaIsPersonClientByRule
(
  @BaPersonID INT,
  @Date DATETIME,
  @CheckIsNewClient BIT,
  @CheckAdditionModules BIT
)
RETURNS BIT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not all values are passed or invalid, we cannot do anything
  IF (@BaPersonID IS NULL OR @Date IS NULL OR YEAR(@Date) < 2008)
  BEGIN
    -- invalid values
    RETURN NULL;
  END;
  
  -- set flags
  SET @CheckIsNewClient = ISNULL(@CheckIsNewClient, 0);
  SET @CheckAdditionModules = ISNULL(@CheckAdditionModules, 0);
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  -- declare vars
  DECLARE @FirstOfYear DATETIME;
  DECLARE @SumHours MONEY;
  DECLARE @IsActiveOrNewClient BIT;

  -- setup vars
  SET @FirstOfYear = dbo.fnGetDateFromInts(1, 1, YEAR(@Date));
  SET @SumHours = 0.0;
  SET @IsActiveOrNewClient = 0;
  
  -----------------------------------------------------------------------------
  -- setup const vars
  --
  -- LOV: BDELeistungsartAuswDienstleistung
  --      Code Text
  --      0    Sozialberatung
  --      1    Case Management
  --      2    Begleitetes Wohnen
  --      3    Entlastungsdienst
  --      4    Assistenzdienst
  --      5    Dienstleistungen für Dritte
  --      6    Kurzberatung
  --      8    Transportdienst
  --      9    LUFEB
  --
  -- LOV: BDELeistungsartAuswPIAuftrag
  --      Code Text
  --      14   IEBI
  -----------------------------------------------------------------------------
  DECLARE @DienstleistungSB INT;
  DECLARE @DienstleistungCM INT;
  DECLARE @DienstleistungBW INT;
  DECLARE @DienstleistungED INT;
  DECLARE @DienstleistungAB INT;
  DECLARE @PIAuftrag_IEBI INT;
  
  SET @DienstleistungSB = 0;
  SET @DienstleistungCM = 1;
  SET @DienstleistungBW = 2;
  SET @DienstleistungED = 3;
  SET @DienstleistungAB = 4;
  SET @PIAuftrag_IEBI = 14;
  
  -----------------------------------------------------------------------------
  -- ACTIVE CLIENT
  -- a) check if person is active for given date for SB/CM/BW/ED
  -----------------------------------------------------------------------------
  SELECT @SumHours = SUM(VIW.DauerSUM)
  FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode VIW WITH (NOEXPAND)
  WHERE VIW.BaPersonID = @BaPersonID              -- filter by person
    AND VIW.Datum BETWEEN @FirstOfYear AND @Date  -- filter by date-range (only within start of year and given date within year)
    AND ISNULL(VIW.AuswDienstleistungCode, -1) IN (@DienstleistungSB, @DienstleistungCM, @DienstleistungBW, @DienstleistungED ); -- only LAs of SB/CM/BW/ED
  
  -- check if person is active client (at least >= 1.0h)
  IF (ISNULL(@SumHours, 0.0) >= 1.0)
  BEGIN
    -- person is active client for given date and year
    SET @IsActiveOrNewClient = 1; -- active
  END
  ELSE
  BEGIN
    -- person is not active client for given date and year
    SET @IsActiveOrNewClient = 0; -- not active
  END;
  
  -----------------------------------------------------------------------------
  -- ACTIVE CLIENT
  -- b) check if person also has to be checked for case b) (only if not yet active)
  -----------------------------------------------------------------------------
  IF (@CheckAdditionModules = 1 AND @IsActiveOrNewClient = 0)
  BEGIN
    -----------------------------------------------------------------------------
    -- b) check if person is active for given date for BW/ED/AB
    -----------------------------------------------------------------------------
    -- reset var
    SET @SumHours = NULL;
  
    -- check if person has any hours in BW/ED/AB
    SELECT @SumHours = SUM(VIW.DauerSUM)
    FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode VIW WITH (NOEXPAND)
    WHERE VIW.BaPersonID = @BaPersonID              -- filter by person
      AND VIW.Datum BETWEEN @FirstOfYear AND @Date  -- filter by date-range (only within start of year and given date within year)
      AND ISNULL(VIW.AuswDienstleistungCode, -1) IN (@DienstleistungBW, @DienstleistungED, @DienstleistungAB); -- only LAs of BW/ED/AB
    
    -- check if active (at least > 0.0h)
    IF (ISNULL(@SumHours, 0.0) > 0.0)
    BEGIN
      -- person is active client for given date and year
      SET @IsActiveOrNewClient = 1; -- active
    END
    ELSE
    BEGIN
      -- person is not active client for given date and year
      SET @IsActiveOrNewClient = 0; -- not active
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- ACTIVE CLIENT
  -- c) check if person also has to be checked for case c) (only if not yet active)
  -----------------------------------------------------------------------------
  IF (@CheckAdditionModules = 1 AND @IsActiveOrNewClient = 0)
  BEGIN
    -----------------------------------------------------------------------------
    -- c) check if person is active for given date for PI-Auftrag "IEBI"
    -----------------------------------------------------------------------------
    -- reset var
    SET @SumHours = NULL;
  
    -- check if person has any hours in "IEBI"
    SELECT @SumHours = SUM(ISNULL(LEI.Dauer, 0.0))
    FROM dbo.BDELeistung             LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.BDELeistungsart BLA WITH (READUNCOMMITTED) ON BLA.BDELeistungsartID = LEI.BDELeistungsartID
                                                               AND BLA.AuswPIAuftragCode = @PIAuftrag_IEBI     -- only PI-Auftrag "IEBI
    WHERE LEI.BaPersonID = @BaPersonID              -- filter by person
      AND LEI.Datum BETWEEN @FirstOfYear AND @Date  -- filter by date-range (only within start of year and given date within year)
    GROUP BY LEI.BaPersonID, LEI.Datum;
    
    -- check if active (at least > 0.0h)
    IF (ISNULL(@SumHours, 0.0) > 0.0)
    BEGIN
      -- person is active client for given date and year
      SET @IsActiveOrNewClient = 1; -- active
    END
    ELSE
    BEGIN
      -- person is not active client for given date and year
      SET @IsActiveOrNewClient = 0; -- not active
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- NEW CLIENT:
  -- check if need to evaluate for new client
  -----------------------------------------------------------------------------
  IF (@CheckIsNewClient = 1 AND @IsActiveOrNewClient = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- check if also new client
    -- 
    -- init vars
    ---------------------------------------------------------------------------
    DECLARE @WasActiveClientInLastFiveYears BIT;
    DECLARE @CountFVDatumBis INT;
    
    -- set vars
    SET @WasActiveClientInLastFiveYears = 0;
    SET @CountFVDatumBis = 0;
    
    ---------------------------------------------------------------------------
    -- check if person was active in any of last five years 
    -- (from first to last day within each last five years)
    -- >> one step recursive calls!
    ---------------------------------------------------------------------------
    -- year-1
    SET @WasActiveClientInLastFiveYears = dbo.fnFaIsPersonClientByRule(@BaPersonID, dbo.fnGetDateFromInts(31, 12, YEAR(@Date) - 1), 0, @CheckAdditionModules);
    
    -- year-2 and not yet active
    IF (ISNULL(@WasActiveClientInLastFiveYears, 0) = 0)
    BEGIN
       SET @WasActiveClientInLastFiveYears = dbo.fnFaIsPersonClientByRule(@BaPersonID, dbo.fnGetDateFromInts(31, 12, YEAR(@Date) - 2), 0, @CheckAdditionModules);
    END;
    
    -- year-3 and not yet active
    IF (ISNULL(@WasActiveClientInLastFiveYears, 0) = 0)
    BEGIN
       SET @WasActiveClientInLastFiveYears = dbo.fnFaIsPersonClientByRule(@BaPersonID, dbo.fnGetDateFromInts(31, 12, YEAR(@Date) - 3), 0, @CheckAdditionModules);
    END;
    
    -- year-4 and not yet active
    IF (ISNULL(@WasActiveClientInLastFiveYears, 0) = 0)
    BEGIN
       SET @WasActiveClientInLastFiveYears = dbo.fnFaIsPersonClientByRule(@BaPersonID, dbo.fnGetDateFromInts(31, 12, YEAR(@Date) - 4), 0, @CheckAdditionModules);
    END;
    
    -- year-5 and not yet active
    IF (ISNULL(@WasActiveClientInLastFiveYears, 0) = 0)
    BEGIN
       SET @WasActiveClientInLastFiveYears = dbo.fnFaIsPersonClientByRule(@BaPersonID, dbo.fnGetDateFromInts(31, 12, YEAR(@Date) - 5), 0, @CheckAdditionModules);
    END;
    
    ---------------------------------------------------------------------------
    -- check if person was active within those years
    ---------------------------------------------------------------------------
    IF (ISNULL(@WasActiveClientInLastFiveYears, 0) = 1)
    BEGIN
      -- person was active within last five years and therefore is not new
      SET @IsActiveOrNewClient = 0; -- not new
    END
    ELSE
    BEGIN
      -------------------------------------------------------------------------
      -- person was not active within last five years
      -- 
      -- check if date is out of migration scope or person was migrated from vis
      -------------------------------------------------------------------------
      IF (YEAR(@Date) > 2012 OR (SELECT ISNULL(visdat36ID, '') FROM BaPerson WHERE BaPersonID = @BaPersonID) = '')
      BEGIN
        -- date out of scope or not a migrated person, person is definitly a new client
        SET @IsActiveOrNewClient = 1; -- new
      END
      ELSE
      BEGIN
        -------------------------------------------------------------------------
        -- person was migrated from vis and year <= 2012
        -- 
        -- check if has any Fallverlauf within DatumBis between 1.1.(year-5) and 31.12.2007
        -- (range checked above)
        -------------------------------------------------------------------------
        DECLARE @MigrationDeadLine DATETIME;
        SET @MigrationDeadLine = dbo.fnGetDateFromInts(31, 12, 2007);
        
        -- get count of closed FV
        SELECT @CountFVDatumBis = COUNT(1)
        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
        WHERE LEI.BaPersonID = @BaPersonID AND -- filter BaPerson
              LEI.ModulID = 2 AND -- filter FV
              ISNULL(LEI.visdat36FALLID, '') <> '' AND -- migrated FV
              ((ISNULL(LEI.DatumBis, GETDATE()) BETWEEN dbo.fnGetDateFromInts(1, 1, YEAR(@Date) - 5) AND @MigrationDeadLine) OR -- between daterange (1.1.(year-5) and 31.12.2007), handle unclosed DatumBis as open till today
               (LEI.DatumVon <= @MigrationDeadLine AND (LEI.DatumBis IS NULL OR LEI.DatumBis > @MigrationDeadLine))); -- opened before migration and (not closed yet or closed after migration)
        
        -- check if any entry found
        IF (ISNULL(@CountFVDatumBis, 0) > 0)
        BEGIN
          -- person was migrated and has closed FV in this time and therefore is not new
          SET @IsActiveOrNewClient = 0; -- not new
        END
        ELSE
        BEGIN
          -- person was migrated and has no closed FV in this time and therefore is new
          SET @IsActiveOrNewClient = 1; -- new
        END; -- [check closed FV]
      END; -- [check out of scope or migrated]
    END; -- [active in last five years]
  END; -- [check if need to evaluate for new client]
  
  -----------------------------------------------------------------------------
  -- return value
  ----------------------------------------------------------------------------- 
  RETURN @IsActiveOrNewClient;
END;
GO