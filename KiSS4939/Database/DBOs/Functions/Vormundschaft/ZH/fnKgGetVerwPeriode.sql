SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKgGetVerwPeriode
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnKgGetVerwPeriode
  (
    @KgPeriodeID  int,
    @KontoNr      int
  )
 RETURNS varchar(130)
AS BEGIN
  -- Die Funktion gibt für ein Konto einer K-Periode einen String aus, der die Verwendungsperiode beschreibt.
  -- Dabei ist die Beschreibung eine Annäherung, die eigentliche Verwendungsperiode wird im K nicht erfasst.
  -- Des Weiteren kann es mehrere Unterbrüche in der Verwendung geben, nur bei bis zu einer Unterbrechung kann gibt die Funktion einen schönen wert zurück
  -- Finde alle Monate
  DECLARE @AllMonths Table
  (
    FirstDayOfMonth DateTime
  )
  INSERT INTO @AllMonths (FirstDayOfMonth)
  (
    SELECT STM.FirstDayOfMonth
    FROM dbo.KgPeriode KPE
      CROSS APPLY dbo.[fnSplitToMonths](KPE.PeriodeVon, KPE.PeriodeBis) STM
    WHERE KPE.KgPeriodeID = @KgPeriodeID
  )
  -- Finde Monate mit Buchungen
  DECLARE @MonthsMitBuchungen TABLE
  (
    FirstDayOfMonth DateTime
  )
  DECLARE @MonthsOhneBuchungen TABLE
  (
    FirstDayOfMonth DateTime
  )
  INSERT INTO @MonthsMitBuchungen (FirstDayOfMonth)
  (
    SELECT STM.FirstDayOfMonth
    FROM @AllMonths STM
    WHERE EXISTS
    (
      SELECT KgBuchungID
      FROM KgBuchung BUC
      WHERE BUC.KgPeriodeID = @KgPeriodeID AND (BUC.HabenKtoNr = @KontoNr OR BUC.SollKtoNr = @KontoNr)
        AND BUC.Buchungsdatum BETWEEN STM.FirstDayOfMonth AND dbo.fnLastDayOf(STM.FirstDayOfMonth)
    )
  )
  INSERT INTO @MonthsOhneBuchungen (FirstDayOfMonth)
  (
    SELECT FirstDayOfMonth
    FROM @AllMonths
    EXCEPT
    SELECT FirstDayOfMonth
    FROM @MonthsMitBuchungen
  )
  
  DECLARE @firstMonthOfFirstPeriod datetime, @firstMonthAfterFirstPeriod datetime, @firstMonthOfSecondPeriod datetime, @firstMonthAfterSecondPeriod datetime
  -- Finde die Monate, in denen es Belege mit dieser KontoNr gibt
  -- a) Finde den ersten Monat mit Beleg
  SELECT TOP 1 @firstMonthOfFirstPeriod = FirstDayOfMonth
  FROM @MonthsMitBuchungen
  ORDER BY FirstDayOfMonth ASC
  -- b) Finde den ersten Monat nach a) ohne Beleg, letzter Monat+1 falls nichts
  SELECT TOP 1 @firstMonthAfterFirstPeriod = FirstDayOfMonth
  FROM @MonthsOhneBuchungen
  WHERE FirstDayOfMonth >= @firstMonthOfFirstPeriod
  ORDER BY FirstDayOfMonth ASC
  
  IF @firstMonthAfterFirstPeriod IS NULL BEGIN
    SELECT TOP 1 @firstMonthAfterFirstPeriod = DateAdd(month, 1, FirstDayOfMonth)
    FROM @MonthsMitBuchungen
    ORDER BY FirstDayOfMonth DESC
  END
  ELSE BEGIN
    -- c) Finde den ersten Monat nach b) mit Beleg (oder nichts)
    SELECT TOP 1 @firstMonthOfSecondPeriod = FirstDayOfMonth
    FROM @MonthsMitBuchungen
    WHERE FirstDayOfMonth > @firstMonthAfterFirstPeriod
    ORDER BY FirstDayOfMonth ASC
    -- d) Finde den letzten Monat nach c) ohne Beleg (oder nichts)
    SELECT TOP 1 @firstMonthAfterSecondPeriod = FirstDayOfMonth
    FROM @MonthsOhneBuchungen
    WHERE @firstMonthOfSecondPeriod IS NOT NULL AND FirstDayOfMonth > @firstMonthOfSecondPeriod
    ORDER BY FirstDayOfMonth DESC
    -- Finde den letzten Monat + 1, falls noch kein Monat nach der zweiten Periode gefunden wurde
    IF @firstMonthOfSecondPeriod IS NOT NULL AND @firstMonthAfterSecondPeriod IS NULL BEGIN
      SELECT TOP 1 @firstMonthAfterSecondPeriod = DateAdd(month, 1, FirstDayOfMonth)
      FROM @MonthsMitBuchungen
      WHERE FirstDayOfMonth >= @firstMonthAfterFirstPeriod
      ORDER BY FirstDayOfMonth DESC
    END
    IF EXISTS -- Existieren mehr als zwei Perioden?
      (
        SELECT TOP 1 FirstDayOfMonth
        FROM @MonthsMitBuchungen
        WHERE FirstDayOfMonth >= @firstMonthAfterSecondPeriod
        ORDER BY FirstDayOfMonth ASC
      ) BEGIN
      -- Zu viele Unterbrechungen, wir können die Periode nicht schön darstellen
      SELECT @firstMonthOfFirstPeriod = NULL, @firstMonthAfterFirstPeriod = NULL, @firstMonthOfSecondPeriod = NULL, @firstMonthAfterSecondPeriod = NULL
    END
  END
  DECLARE @Result varchar(200)
  SET @Result = ''
  IF @firstMonthOfFirstPeriod IS NOT NULL AND @firstMonthAfterFirstPeriod IS NOT NULL  BEGIN
    SET @Result = SUBSTRING(CONVERT(varchar(10), @firstMonthOfFirstPeriod, 4), 4, 8) + '-' +
                  SUBSTRING(CONVERT(varchar(10), DateAdd(day, -1, @firstMonthAfterFirstPeriod), 4), 4, 8) + 
         CASE WHEN @firstMonthOfSecondPeriod IS NULL THEN ''
          ELSE ' und ' +
                  SUBSTRING(CONVERT(varchar(10), @firstMonthOfSecondPeriod, 4), 4, 8) + '-' +
                  SUBSTRING(CONVERT(varchar(10), DateAdd(day, -1, @firstMonthAfterSecondPeriod), 4), 4, 8) END
  END
  RETURN @Result
END

GO