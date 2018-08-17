SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbZahlungslaufValuta_InsertNewYear;
GO

/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/System/spKbZahlungslaufValuta_InsertNewYear.sql $
  $Author: Rhesterberg $
  $Modtime: 14.09.10 15:15 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Erstellt die Zahlungsvaluti für ein ganzes Jahr anahnd der Daten des Vorjahres
    @NewYear: Das Jahr, welches neu gefüllt werden soll
    @ShiftForward: 1 -> das Datum wird nach hinten geschoben, wenn es ein Samstag oder Sonntag ist
                   0 -> das Datum wird nach vorne geschoben, wenn es ein Samstag oder Sonntag ist
                   2 -> das Datum wird nicht geschoben
  -
  RETURNS: kein Funktionswert
  -
  TEST: EXEC dbo.spKbZahlungslaufValuta_InsertNewYear 2010, 1;
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/System/spKbZahlungslaufValuta_InsertNewYear.sql $
 * 
 * 2     14.09.10 15:20 Rhesterberg
 * #5469 Auszahlungs-Valuta kopieren
 * 
 * 1     14.09.10 10:53 Rhesterberg
 * #5469 Auszahlungs-Valuta zu kopieren
=================================================================================================*/

CREATE PROCEDURE dbo.spKbZahlungslaufValuta_InsertNewYear
(
	@NewYear INT,
	@ShiftForward INT
)
AS 
BEGIN
	-----------------------------------------------------------------------------
	-- start call
	-----------------------------------------------------------------------------
	SET NOCOUNT ON;
  
	-----------------------------------------------------------------------------
	-- Parameter kontrollieren
	-----------------------------------------------------------------------------
	IF @NewYear IS NULL 
	BEGIN
		-- wenn kein Jahr angegeben ist, kann nichts gemacht werden
		RAISERROR('InvalidParameters' , 18, 1)
		RETURN
	END
  
	-----------------------------------------------------------------------------
	-- Deklarationen
	-----------------------------------------------------------------------------
	DECLARE
		@Monat INT, 
		@DatMonatlich DATETIME, 
		@DatTeil1 DATETIME, 
		@DatTeil2 DATETIME,  
		@DatWoche1 DATETIME, 
		@DatWoche2 DATETIME, 
		@DatWoche3 DATETIME, 
		@DatWoche4 DATETIME, 
		@DatWoche5 DATETIME,
	
		@NewDatMonatlich DATETIME, 
		@NewDatTeil1 DATETIME, 
		@NewDatTeil2 DATETIME,  
		@NewDatWoche1 DATETIME, 
		@NewDatWoche2 DATETIME, 
		@NewDatWoche3 DATETIME, 
		@NewDatWoche4 DATETIME, 
		@NewDatWoche5 DATETIME


	-----------------------------------------------------------------------------
	-- Cursor für das ganze Jahr 
	-----------------------------------------------------------------------------
	DECLARE curDates CURSOR FAST_FORWARD FOR
		SELECT 
			ZLV.Monat, ZLV.DatMonatlich, ZLV.DatTeil1, ZLV.DatTeil2,  
			ZLV.DatWoche1, ZLV.DatWoche2, ZLV.DatWoche3, ZLV.DatWoche4, ZLV.DatWoche5
		FROM dbo.KbZahlungslaufValuta ZLV
		WHERE ZLV.Jahr = @NewYear - 1
	OPEN curDates

	-----------------------------------------------------------------------------
	-- Ganzes Jahr erstellen
	-----------------------------------------------------------------------------
	WHILE 1 = 1
	BEGIN
		-- alle Daten für einen Monat holen
		FETCH NEXT FROM curDates INTO
			@Monat, @DatMonatlich, @DatTeil1, @DatTeil2, 
			@DatWoche1, @DatWoche2, @DatWoche3, @DatWoche4, @DatWoche5
		IF @@FETCH_STATUS != 0 BREAK
    
	    -- alle Daten um 1 Jahr erhöhen
		SET @NewDatMonatlich = DATEADD(YEAR, 1, @DatMonatlich) 
		SET @NewDatTeil1 = DATEADD(YEAR, 1, @DatTeil1) 
		SET @NewDatTeil2 = DATEADD(YEAR, 1, @DatTeil2)  
		SET @NewDatWoche1 = DATEADD(YEAR, 1, @DatWoche1) 
		SET @NewDatWoche2 = DATEADD(YEAR, 1, @DatWoche2) 
		SET @NewDatWoche3 = DATEADD(YEAR, 1, @DatWoche3) 
		SET @NewDatWoche4 = DATEADD(YEAR, 1, @DatWoche4) 
		SET @NewDatWoche5 = DATEADD(YEAR, 1, @DatWoche5)
	
	    -- alle Daten kontrollieren/korrigieren, 
		-- dass kein Datum auf Samstag oder Sonntag fällt
	    SET @NewDatMonatlich = dbo.fnDateChangeToWorkingDay(@NewDatMonatlich, @ShiftForward) 
		SET @NewDatTeil1 = dbo.fnDateChangeToWorkingDay(@NewDatTeil1, @ShiftForward) 
	    SET @NewDatTeil2 = dbo.fnDateChangeToWorkingDay(@NewDatTeil2, @ShiftForward) 
		SET @NewDatWoche1 = dbo.fnDateChangeToWorkingDay(@NewDatWoche1, @ShiftForward) 
	    SET @NewDatWoche2 = dbo.fnDateChangeToWorkingDay(@NewDatWoche2, @ShiftForward) 
		SET @NewDatWoche3 = dbo.fnDateChangeToWorkingDay(@NewDatWoche3, @ShiftForward) 
	    SET @NewDatWoche4 = dbo.fnDateChangeToWorkingDay(@NewDatWoche4, @ShiftForward) 
		SET @NewDatWoche5 = dbo.fnDateChangeToWorkingDay(@NewDatWoche5, @ShiftForward) 
    
		IF EXISTS(
			SELECT TOP 1 1 FROM dbo.KbZahlungslaufValuta
			WHERE Jahr = @NewYear AND Monat = @Monat) 
		BEGIN
			-- es existieren bereits Daten in diesem Monat
			-- wenn Daten bereits existieren, werden sie nicht überschrieben
			UPDATE ZLV SET
				ZLV.DatMonatlich = ISNULL(ZLV.DatMonatlich, @NewDatMonatlich),
				ZLV.DatTeil1 = ISNULL(ZLV.DatTeil1, @NewDatTeil1),
				ZLV.DatTeil2 = ISNULL(ZLV.DatTeil2, @NewDatTeil2),
				ZLV.DatWoche1 = ISNULL(ZLV.DatWoche1, @NewDatWoche1),
				ZLV.DatWoche2 = ISNULL(ZLV.DatWoche2, @NewDatWoche2),
				ZLV.DatWoche3 = ISNULL(ZLV.DatWoche3, @NewDatWoche3),
				ZLV.DatWoche4 = ISNULL(ZLV.DatWoche4, @NewDatWoche4),
				ZLV.DatWoche5 = ISNULL(ZLV.DatWoche5, @NewDatWoche5)
			FROM dbo.KbZahlungslaufValuta ZLV
			WHERE ZLV.Jahr = @NewYear AND ZLV.Monat = @Monat
		END 
		ELSE BEGIN
			-- es existieren keine Daten in diesem Monat
			-- alle Daten neu einfügen
			INSERT INTO dbo.KbZahlungslaufValuta(
				Jahr, Monat, DatMonatlich, DatTeil1, DatTeil2,
				DatWoche1, DatWoche2, DatWoche3, DatWoche4, DatWoche5)
			VALUES (
				@NewYear, @Monat, @NewDatMonatlich, @NewDatTeil1, @NewDatTeil2,
				@NewDatWoche1, @NewDatWoche2, @NewDatWoche3, @NewDatWoche4, @NewDatWoche5)
		END
	END

	-----------------------------------------------------------------------------
	-- Cursor freigeben
	-----------------------------------------------------------------------------
	CLOSE curDates
	DEALLOCATE curDates
  
END;
GO
