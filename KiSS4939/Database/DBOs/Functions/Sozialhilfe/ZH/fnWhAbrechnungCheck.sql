SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhAbrechnungCheck
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[fnWhAbrechnungCheck]
(
	@WhAbrechnungID int
)
RETURNS 
@Fehler TABLE 
(
	Fehlermeldung varchar(300)
)
AS
BEGIN
	INSERT INTO @Fehler
	SELECT TOP 1 Fehlermeldung = 'Alle Daten der Perioden müssen ausgefüllt sein.'
	FROM
	(
		SELECT TOP 1 WhDetailblattID
		FROM WhDetailblatt
		WHERE WhAbrechnungID = @WhAbrechnungID AND
			(DatumVon IS NULL OR DatumBis IS NULL)
		UNION
		SELECT WhAbrechnungID
		FROM WhAbrechnung
		WHERE WhAbrechnungID = @WhAbrechnungID AND
			(DatumBis IS NULL OR DatumVon IS NULL)
	) AS tmp

	UNION
	SELECT TOP 1 Fehlermeldung = 'Das Startdatum einer Periode muss vor dem Enddatum einer Periode liegen.'
	FROM
	(
		SELECT TOP 1 WhDetailblattID
		FROM WhDetailblatt
		WHERE WhAbrechnungID = @WhAbrechnungID AND DatumVon >= DatumBis
		UNION
		SELECT WhAbrechnungID
		FROM WhAbrechnung
		WHERE WhAbrechnungID = @WhAbrechnungID AND DatumVon >= DatumBis
	) AS tmp

	UNION

	SELECT TOP 1 Fehlermeldung = 'Die Abrechnungsperiode stimmt nicht mit den Detailperioden überein.'
	FROM WhDetailblatt DET
		INNER JOIN WhAbrechnung ABR ON ABR.WhAbrechnungID = DET.WhAbrechnungID
	WHERE DET.WhAbrechnungID = @WhAbrechnungID
--	GROUP BY ABR.WhAbrechnungID
	HAVING MIN(DET.DatumVon) <> MIN(ABR.DatumVon) OR MAX(DET.DatumBis) <> MAX(ABR.DatumBis)

	UNION

	SELECT TOP 1 Fehlermeldung = 'Eine Periode muss am ersten Tag eines Monats starten und am letzten Tag eines Monats enden.'
	FROM
	(
		SELECT TOP 1 WhDetailblattID
		FROM WhDetailblatt
		WHERE WhAbrechnungID = @WhAbrechnungID AND
			(DatePart(day, DatumVon) <> 1 OR DatePart(month, DatumBis) = DatePart(month, DateAdd(Day, 1, DatumBis)))
		UNION
		SELECT WhAbrechnungID
		FROM WhAbrechnung
		WHERE WhAbrechnungID = @WhAbrechnungID AND
			(DatePart(day, DatumVon) <> 1 OR DatePart(month, DatumBis) = DatePart(month, DateAdd(Day, 1, DatumBis)))
	) AS tmp

  UNION
  SELECT TOP 1 Fehlermeldungt = 'Gewisse Detailperioden überschneiden sich, bitte erstellte Detailblätter kontrollieren und richtige Perioden setzen.'
  FROM WhDetailblatt DET1
    INNER JOIN WhDetailblatt DET2 ON DET2.WhAbrechnungID = @WhAbrechnungID AND DET1.WhDetailblattID <> DET2.WhDetailblattID
      AND (DET1.DatumVon BETWEEN DET2.DatumVon AND DET2.DatumBis OR DET2.DatumVon BETWEEN DET1.DatumVon AND DET1.DatumBis)
	WHERE DET1.WhAbrechnungID = @WhAbrechnungID

	UNION

	SELECT TOP 1 Fehlermeldung = 'Nicht alle Detailblätter wurden erstellt'
	FROM WhDetailblatt
	WHERE WhAbrechnungID = @WhAbrechnungID
		AND DocumentID IS NULL

	DECLARE @datumVon datetime, @datumBis datetime, @altesDatumBis datetime
	SET @altesDatumBis = NULL
	DECLARE detailCursor CURSOR FOR
		SELECT DatumVon, DatumBis
		FROM WhDetailblatt
		WHERE WhAbrechnungID = @WhAbrechnungID
		ORDER BY DatumVon ASC
	OPEN detailCursor
	FETCH NEXT FROM detailCursor
	INTO @datumVon, @DatumBis
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @datumVon <> DateAdd(day, 1, @altesDatumBis) AND @altesDatumBis IS NOT NULL
		BEGIN
			INSERT INTO @Fehler
			(Fehlermeldung) Values ('Für eine Detailperiode konnte die anschliessende Detailperiode nicht gefunden werden.')
			BREAK
		END
		SET @altesDatumBis = @DatumBis
		FETCH NEXT FROM detailCursor
		INTO @datumVon, @DatumBis
	END

	CLOSE detailCursor
	DEALLOCATE detailCursor
	
	RETURN 
END

