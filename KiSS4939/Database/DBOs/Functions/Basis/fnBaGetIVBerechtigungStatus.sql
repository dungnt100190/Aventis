SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetIVBerechtigungStatus;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get the current state for IV-Berechtigung. 
           >> If state for given @Date is NULL/'Keine'/'InBearbeitung', then we see if within the last 
              10 years we at least once had the state 'Vorhanden'. If true, the state will be 'Vorhanden'!
           >> Only one state per day is valid, so if more than one state is defined, the function
              will throw an exception!
           >> The state 'In Bearbeitung' will be treated as 'Keine' (see flag @Detailed)
    @BaPersonID: The person to get value from
    @Date:       The date to use for calculating state (if NULL, GetDate() will be used)
    @Detailed:   1      = Returns real current detailed state (excluding handling for 10years-rule)
                 0/NULL = Returns only 'Keine' or 'Vorhanden'
  -
  RETURNS: Current value for given person or -1 if nothing defined
=================================================================================================
  TEST:    SELECT dbo.fnBaGetIVBerechtigungStatus(72708, GETDATE(), 0);
           SELECT dbo.fnBaGetIVBerechtigungStatus(72708, GETDATE(), 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetIVBerechtigungStatus
(
  @BaPersonID INT,
  @Date DATETIME,
  @Detailed BIT
)
RETURNS INT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if no value given, invalid id
  IF (@BaPersonID IS NULL)
  BEGIN
    RETURN -1;
  END;
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  -- if NULL use 0 for BIT
  SET @Detailed = ISNULL(@Detailed, 0);
  
  -- if date is emtpy, use current date (but without hours, minutes and seconds)
  SET @Date = dbo.fnDateOf(ISNULL(@Date, GETDATE()));
  
  -- if we need to have detailed value but date is in future, we need to get current date for @Date (see #8023)
  IF (@Detailed = 1 AND @Date > GETDATE())
  BEGIN
    SET @Date = dbo.fnDateOf(GETDATE());
  END;
  
  -----------------------------------------------------------------------------
  -- LOV definition
  -----------------------------------------------------------------------------
  /*
  LOV-INFO:
  ---------
  BaIVBerechtigung    1    Vorhanden
  BaIVBerechtigung    2    In Bearbeitung
  BaIVBerechtigung    3    Keine
  BaIVBerechtigung    4    Sonderpädagogische Massnahme (see: #8023)
  */
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  -- const
  DECLARE @IVBerechtigungVORHANDEN INT;
  DECLARE @IVBerechtigungINBEARBEITUNG INT;
  DECLARE @IVBerechtigungKEINE INT;
  DECLARE @IVBerechtigungSONDPMSN INT;
  
  SET @IVBerechtigungVORHANDEN = 1;
  SET @IVBerechtigungINBEARBEITUNG = 2;
  SET @IVBerechtigungKEINE = 3;
  SET @IVBerechtigungSONDPMSN = 4;
  
  -- others
  DECLARE @IVBerechtiungCodeForDate INT;
  SET @IVBerechtiungCodeForDate = NULL;
  
  -----------------------------------------------------------------------------
  -- get defined value for given date
  ----------------------------------------------------------------------------- 
  SELECT @IVBerechtiungCodeForDate = BIV.BaIVBerechtigungCode
  FROM dbo.BaIVBerechtigung BIV WITH (READUNCOMMITTED)
  WHERE BIV.BaPersonID = @BaPersonID 
    AND BIV.DatumVon <= @Date 
    AND (BIV.DatumBis IS NULL OR BIV.DatumBis >= @Date)
  
  -----------------------------------------------------------------------------
  -- check if value found is NULL or 'Keine' or 'InBearbeitung' 
  -- and therefore we have to check the last 10 years
  --
  -- in detailed, we do not check the last 10 years
  ----------------------------------------------------------------------------- 
  IF (@Detailed = 0 AND ISNULL(@IVBerechtiungCodeForDate, @IVBerechtigungKEINE) IN (@IVBerechtigungKEINE, @IVBerechtigungINBEARBEITUNG))
  BEGIN
    -- init vars
    DECLARE @DateTenYearsAgo DATETIME;
    DECLARE @StateVorhandenOrSondpMsnInLastYears INT;
    
    SET @DateTenYearsAgo = DATEADD(yy, -10, @Date);
    SET @StateVorhandenOrSondpMsnInLastYears = -1;
  
    -- value for given date is 'Keine'/'InBearbeitung'/NULL, so we have to see if within the last 10 years 
    -- the person had the state 'Vorhanden'/'Sonderpädagogische Massnahme' and therefore would get 'Vorhanden' anyway
    SELECT TOP 1 
           @StateVorhandenOrSondpMsnInLastYears = BIV.BaIVBerechtigungCode
    FROM dbo.BaIVBerechtigung BIV WITH (READUNCOMMITTED)
    WHERE BIV.BaPersonID = @BaPersonID 
      AND BIV.BaIVBerechtigungCode IN (@IVBerechtigungVORHANDEN, @IVBerechtigungSONDPMSN)
      AND BIV.DatumVon <= @Date                                                                                 -- only until given date (no future defined entries!)
      AND (BIV.DatumVon >= @DateTenYearsAgo OR (BIV.DatumVon < @DateTenYearsAgo AND 
                                                (BIV.DatumBis IS NULL OR BIV.DatumBis >= @DateTenYearsAgo)))    -- check the last 10 years from given date
    ORDER BY BIV.DatumVon DESC;                                                                                 -- we need only newest of the last 10 years
    
    -- check if we had at least one time 'Vorhanden'/'Sonderpädagogische Massnahme' within last 10 years
    IF (ISNULL(@StateVorhandenOrSondpMsnInLastYears, @IVBerechtigungKEINE) IN (@IVBerechtigungVORHANDEN, @IVBerechtigungSONDPMSN))
    BEGIN
      IF (@Detailed = 0)
      BEGIN
        -- although the person has now NULL/'Keine'/'InBearbeitung', it will get 'Vorhanden' because of 
        -- 'Vorhanden'/'Sonderpädagogische Massnahme' occurence in last 10 years
        SET @IVBerechtiungCodeForDate = @IVBerechtigungVORHANDEN;
      END
      ELSE
      BEGIN
        -- get latest active state as we need to have detailed value
        SET @IVBerechtiungCodeForDate = @StateVorhandenOrSondpMsnInLastYears;
      END;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- if we do not need detailed value:
  -- - convert value from 'In Bearbeitung' to 'Keine'
  -- - convert value from 'Sonderpädagogische Massnahme' to 'Vorhanden'
  -----------------------------------------------------------------------------
  IF (@Detailed = 0)
  BEGIN
    IF (@IVBerechtiungCodeForDate = @IVBerechtigungINBEARBEITUNG)
    BEGIN
      -- convert because of sense
      SET @IVBerechtiungCodeForDate = @IVBerechtigungKEINE;
    END
    ELSE IF (@IVBerechtiungCodeForDate = @IVBerechtigungSONDPMSN)
    BEGIN
      -- convert because of sense
      SET @IVBerechtiungCodeForDate = @IVBerechtigungVORHANDEN;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- return value
  -----------------------------------------------------------------------------
  RETURN CASE @Detailed
           WHEN 0 THEN ISNULL(@IVBerechtiungCodeForDate, @IVBerechtigungKEINE)
           ELSE @IVBerechtiungCodeForDate
         END;
END;
GO