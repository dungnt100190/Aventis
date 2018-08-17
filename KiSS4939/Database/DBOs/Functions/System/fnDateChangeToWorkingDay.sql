SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDateChangeToWorkingDay;
GO

/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnDateChangeToWorkingDay.sql $
  $Author: Rhesterberg $
  $Modtime: 14.09.10 16:17 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Wndalteschreibung der Function, Zweck und Einsatz>
    @OldDate: Das Datum, welches geprüft und u.U. korrigiert werden soll
    @ShiftForward: 1 -> das Datum wird nach hinten geschoben, wenn es ein Samstag oder Sonntag ist
                   0 -> das Datum wird nach vorne geschoben, wenn es ein Samstag oder Sonntag ist
                   2 -> das Datum wird nicht geschoben
  -
  RETURNS: Liefert das korrigierte Datum zurück
  -
  TEST:    SELECT NeuesDatum = dbo.fnDateChangeToWorkingDay(GetDate(), 1);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnDateChangeToWorkingDay.sql $
 * 
 * 3     14.09.10 16:18 Rhesterberg
 * #5469 Auszahlungs-Valuta kopieren
 * 
 * 2     14.09.10 15:19 Rhesterberg
 * #5469 Auszahlungs-Valuta kopieren
 * 
 * 1     14.09.10 13:15 Rhesterberg
 * #5469 Auszahlungs-Valuta zu kopieren
=================================================================================================*/

CREATE FUNCTION dbo.fnDateChangeToWorkingDay
(
  @OldDate DATETIME,
  @ShiftForward INT
)
RETURNS DATETIME
AS 
BEGIN

	-----------------------------------------------------------------------------
	-- Deklarationen
	-----------------------------------------------------------------------------
	DECLARE @NewDate DATETIME
	SET @NewDate = @OldDate
	
	-----------------------------------------------------------------------------
	-- Kontrolle der Parameter
	-----------------------------------------------------------------------------
	IF @OldDate IS NULL
	BEGIN
	    -- Wenn das Datum nicht definiert ist, kann nicht zurückgeliefert werden
		RETURN @NewDate
	END

	IF @ShiftForward = 2 
	BEGIN
	    -- Wenn @ShiftForward = 2, dann wird nicht geschoben
		RETURN @NewDate
	END

	DECLARE 
		@Saturday INT,
		@Sunday INT,
		@CountDays INT,
		@NumberFirstDayOfWeek INT


	-----------------------------------------------------------------------------
	-- Anpassungen für @@DATEFIRST vorbereiten
	-----------------------------------------------------------------------------
	-- Die Nummer des ersten Wochentags holen: 1 = Montag, 2 = Dienstag, usw.
	-- u.U. kann dies auch 2 = Montag, 3 = Dienstag, usw. sein
	SET @NumberFirstDayOfWeek = @@DATEFIRST

	-- Die Nummer des Samstags gemäss Einstellung der DB holen
	SET @Saturday = CASE @NumberFirstDayOfWeek
		WHEN 1 THEN 6
		WHEN 2 THEN 5
		WHEN 3 THEN 4
		WHEN 4 THEN 3
		WHEN 5 THEN 2
		WHEN 6 THEN 1
		ELSE 7
	END	

	-- Die Nummer des Sonntags gemäss Einstellung der DB holen
	SET @Sunday = CASE @NumberFirstDayOfWeek
		WHEN 1 THEN 7
		WHEN 2 THEN 6
		WHEN 3 THEN 5
		WHEN 4 THEN 4
		WHEN 5 THEN 3
		WHEN 6 THEN 2
		ELSE 1
	END	

	-----------------------------------------------------------------------------
	-- Datum kontrollieren/korrigieren
	-----------------------------------------------------------------------------
	IF DATEPART(DW, @NewDate) IN (@Saturday, @Sunday)
	BEGIN
		-- Das neue Datum ist ein Samstag oder ein Sonntag
		-- deshalb wird das neue Datum noch abgepasst, damit es auf einen Werktag fällt
		IF @ShiftForward = 1 
		BEGIN
			-- es ist erwünscht, dass das neue Datum nach hinten (=später) geschoben wird
			SET @CountDays = CASE 
				WHEN DATEPART(DW, @NewDate) = @Saturday THEN 2
				ELSE 1
			END
			SET @NewDate = DATEADD(DAY, @CountDays, @NewDate)
        
			-- Wenn nun die Monatsgrenze überschritten wurde, 
			-- muss in die andere Richtung korrigiert werden
			IF MONTH(@NewDate) != MONTH(@OldDate) 
			BEGIN
			
				SET @CountDays = CASE 
					WHEN DATEPART(DW, @OldDate) = @Saturday THEN 1
					ELSE 2
				END
				SET @NewDate = DATEADD(DAY, -@CountDays, @OldDate) 
			
				-- Sicherheitskontrolle
				IF MONTH(@NewDate) != MONTH(@OldDate)
				BEGIN
					SET @NewDate = NULL
				END 
			END
      
		END ELSE BEGIN
			-- es ist erwünscht, dass das neue Datum nach vorne (=früher) geschoben wird
			SET @CountDays = CASE 
				WHEN DATEPART(DW, @NewDate) = @Saturday THEN 1
				ELSE 2
			END
			SET @NewDate = DATEADD(DAY, -@CountDays, @OldDate)
        
			-- Wenn nun die Monatsgrenze ünterschritten wurde, 
			-- muss in die andere Richtung korrigiert werden
			IF MONTH(@NewDate) != MONTH(@OldDate) 
			BEGIN
			
				SET @CountDays = CASE 
					WHEN DATEPART(DW, @OldDate) = @Saturday THEN 2
					ELSE 3
				END
				SET @NewDate = DATEADD(DAY, @CountDays, @OldDate) 
			
				-- Sicherheitskontrolle
				IF MONTH(@NewDate) != MONTH(@OldDate)
				BEGIN
					SET @NewDate = NULL
				END 
			END
		END
	END
  
	-----------------------------------------------------------------------------
	-- Datum zurückgeben
	-----------------------------------------------------------------------------
	RETURN @NewDate
END;
GO
