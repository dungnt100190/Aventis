SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetWorkingDays;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Berechnet Anzahl Arbeitstage in übergebenem Monat, Jahr in Abhängigkeit, 
           ob Samstage und Sonntage gezählt werden sollen
    @Monat: Monat
    @Jahr : Jahr
    @SamstagAktiv: Flag, ob Samstage mitgezählt werden sollen
    @SonntagAktiv: Flag, ob Sonntage mitgezählt werden sollen
  -
  RETURNS: INT, der die Anzahl Tage angibt
=================================================================================================
  TEST:    select  dbo.fnGetWorkingDays (9 , 2012, 0, 1) 
=================================================================================================*/

CREATE FUNCTION dbo.fnGetWorkingDays
(
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @SamstagAktiv BIT,
  @SonntagAktiv BIT
)
RETURNS INT
AS BEGIN
  
  DECLARE @WorkDays int 

  DECLARE @Saturday INT;
  DECLARE @Sunday INT;
  DECLARE @NumberFirstDayOfWeek INT;
  
  SET @NumberFirstDayOfWeek = @@DATEFIRST;
  
  -- Die Nummer des Samstags gemäss Einstellung der DB holen
  SET @Saturday = CASE @NumberFirstDayOfWeek
                    WHEN 1 THEN 6
                    WHEN 2 THEN 5
                    WHEN 3 THEN 4
                    WHEN 4 THEN 3
                    WHEN 5 THEN 2
                    WHEN 6 THEN 1
                    ELSE 7
                  END;

  -- Die Nummer des Sonntags gemäss Einstellung der DB holen
  SET @Sunday = CASE @NumberFirstDayOfWeek
                  WHEN 1 THEN 7
                  WHEN 2 THEN 6
                  WHEN 3 THEN 5
                  WHEN 4 THEN 4
                  WHEN 5 THEN 3
                  WHEN 6 THEN 2
                  ELSE 1
                END;

  -- Bestimmung der Anzahl Tage in diesem Monat
  DECLARE @ActualDay DATETIME;

--loop
  SET @WorkDays=0;
  SET @ActualDay = @DatumVon;
  WHILE ( @ActualDay <= @DatumBis)
  BEGIN
        IF(DATEPART(dw, @ActualDay) = @Saturday AND  @SamstagAktiv=1 )
        BEGIN
			SET @WorkDays=@WorkDays+1;
        END        
        IF(DATEPART(dw, @ActualDay) = @Sunday AND @SonntagAktiv=1)
		BEGIN
		    SET @WorkDays=@WorkDays+1;
		END
		IF (DATEPART(dw,@ActualDay ) NOT IN (@Saturday, @Sunday))
		BEGIN
			SET @WorkDays=@WorkDays+1;
		END	
        SET @ActualDay = DATEADD(d,1,@ActualDay); 
  END

  RETURN @WorkDays;
END;
GO