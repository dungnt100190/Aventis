--------------------------------------------------------------------------
-- Korrekturskript bei Wechsel Verkehrskonto
--  8448_KgKorrekturVerkehrskonto
--------------------------------------------------------------------------

DECLARE @DatumVon DATETIME;
DECLARE @KontoNrAlt VARCHAR(10);
DECLARE @KontoNrNeu VARCHAR(10);
DECLARE @FaFallId INT;
DECLARE @CheckOnly BIT;

---------------------------------------------------------------------------
-- Initialisierung Parameter. Bitte vor ausführen ausfüllen.
-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
---------------------------------------------------------------------------

-- Ab wann die Buchungen auf das neue Verkehrskonto zeigen sollen
-- Es werden nur Buchungen der Periode angepasst, wo dieses Datum enthalten ist.
-- Schreibweise 'JJJJMMTT'
SET @DatumVon = '20100901';

-- Der Name des neuen Verkehrskonto
SET @KontoNrNeu = '1041';

-- Der Name des alten Verkehrskontos 
SET @KontoNrAlt = '1040';

-- Fallnummer
SET @FaFallId = 57733;

-- Wenn @CheckOnly 1 ist, werden die Daten nur validiert und nicht verändert.
-- Sonst werden die Daten effektiv umgehängt.
-- Im Validierungsmodus werden zwei Tabellen angezeigt. In der ersten Tabelle
-- sind die Buchungen vor der Änderung drin, in der zweiten Tabelle sind die 
-- Buchungen nach der Änderung drin.
SET @CheckOnly = 1

---------------------------------------------------------------------------
-- Ausdrucken der Parameter
---------------------------------------------------------------------------
PRINT 'Fallnr: ' + CONVERT(VARCHAR, ISNULL(@FaFallId,0));
PRINT 'Alte Konto-Nummer: ' + CONVERT(VARCHAR, ISNULL(@KontoNrAlt, 0));
PRINT 'Neue Konto-Nummer: ' + @KontoNrNeu;
PRINT 'Periode von: ' + CONVERT(VARCHAR, @DatumVon);

---------------------------------------------------------------------------
-- Validierungen
---------------------------------------------------------------------------
-- BaPerson ermitteln
DECLARE @BaPersonID INT;
DECLARE @Nachname VARCHAR(MAX);
DECLARE @Vorname VARCHAR(MAX);


SELECT 
	@BaPersonID = PRS.BaPersonID,
    @Nachname   = PRS.Name,
    @Vorname    = PRS.Vorname
FROM dbo.FaFall FAL
	INNER JOIN dbo.BaPerson PRS ON PRS.BaPersonID = FAL.BaPersonID
WHERE FAL.FaFallID = @FaFallId;

IF @BaPersonID IS NULL 
BEGIN
	RAISERROR 
	(
		'Person zur Fallnummer nicht gefunden', -- Message text.
		18, -- Severity.
		1 -- State.
	)
	GOTO SKIPPER
END

PRINT 'Fallträger Name: ' + ISNULL(@Nachname, '') + ' Fallträger Vorname: ' + ISNULL(@Vorname, '');

-- Periode ermitteln
DECLARE @KgPeriodeID INT;


SELECT 
  @KgPeriodeID = GPE.KgPeriodeID  	
FROM
  dbo.KgPeriode GPE
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = GPE.FaLeistungID
WHERE 
  LEI.FaFallID = @FaFallId
  AND GPE.PeriodeVon <= @DatumVon
  AND (GPE.PeriodeBis IS NULL OR GPE.PeriodeBis > @DatumVon)
  
IF @KgPeriodeID IS NULL 
BEGIN
	RAISERROR 
	(
		'Keine Periode gefunden', -- Message text.
		16, -- Severity.
		1 -- State.
	)
	GOTO SKIPPER;
END
  
PRINT 'PeriodeId: ' +  CONVERT(VARCHAR, @KgPeriodeID); 

-- Verkehrskonto eruieren
DECLARE @KgKontoIDAlt INT;
DECLARE @KgKontoIDNeu INT;
DECLARE @KontoArtAlt INT;
DECLARE @KontoArtNeu INT;

--  Daten altes Konto
SELECT 
	@KgKontoIDAlt = GKO.KgKontoID,
	@KontoArtAlt = GKO.KgKontoartCode
FROM dbo.KgKonto GKO
WHERE 
	GKO.KgPeriodeID = @KgPeriodeID
	AND GKO.KontoNr = @KontoNrAlt;
	
-- Daten neues Konto	
SELECT 
	@KgKontoIDNeu = GKO.KgKontoID,
	@KontoArtNeu = GKO.KgKontoartCode
FROM dbo.KgKonto GKO
WHERE 
	GKO.KgPeriodeID = @KgPeriodeID
	AND GKO.KontoNr = @KontoNrNeu;	
	
	
IF @KgKontoIDAlt IS NULL 
BEGIN
	RAISERROR 
	(
		'Altes Konto existiert nicht in der Periode', -- Message text.
		18, -- Severity, und die ist gross :), so dass es abbricht.
		1 -- State.
	)
	GOTO SKIPPER
END

PRINT 'KgKontoId alt: ' + CONVERT(VARCHAR, @KgKontoIDAlt);
  
IF @KontoArtAlt = 1
BEGIN
	RAISERROR 
	(
		'Altes Konto ist immer noch Verkehrskonto. Bitte zuerst Kontoart ändern.', -- Message text.
		18, 
		1 -- State.		
	)
	GOTO SKIPPER
END

IF @KgKontoIDNeu IS NULL 
BEGIN
	RAISERROR 
	(
		'neus Konto existiert nicht in der Periode', -- Message text.
		18, -- Severity.
		1 -- State.
	)
	GOTO SKIPPER 
END
  
PRINT 'KgKontoId neu: ' + CONVERT(VARCHAR, @KgKontoIDNeu);  
  
IF @KontoArtNeu <> 1
BEGIN
	RAISERROR 
	(
		'Neues Konto ist nicht Verkehrskonto. Bitte zuerst Kontoart ändern', -- Message text.
		18, -- Severity.
		1 -- State.
	)
	GOTO SKIPPER
END

-- Debugging Ausgabe 
IF @CheckOnly = 1
BEGIN
	SELECT 
		GBU.KgBuchungID,
		GPE.PeriodeVon,
		GPE.PeriodeBis,
		GBU.ErstelltDatum,
		GBU.HabenKtoNr,
		GBU.SollKtoNr,
		GBU.Betrag
	FROM dbo.KgBuchung GBU
		LEFT JOIN dbo.KgPeriode GPE ON GPE.KgPeriodeID = GBU.KgPeriodeID
	WHERE 
		(GBU.SollKtoNr = @KontoNrAlt OR GBU.HabenKtoNr =  @KontoNrAlt OR GBU.SollKtoNr = @KontoNrNeu OR GBU.HabenKtoNr = @KontoNrNeu)
	  AND GBU.KgPeriodeID = @KgPeriodeID
END  

 
-- declare and init vars
DECLARE @ErrorMessage VARCHAR(MAX);
SET @ErrorMessage = NULL;



-------------------------------------------------------------------------------
-- Effektives Umhängen der Konti in den Buchungen
-------------------------------------------------------------------------------
BEGIN TRANSACTION;

BEGIN TRY  



  -- Sollkonto
  UPDATE dbo.KgBuchung
	SET SollKtoNr = @KontoNrNeu
  WHERE
	KgPeriodeID = @KgPeriodeID
	AND SollKtoNr = @KontoNrAlt
	AND ErstelltDatum >= @DatumVon
	
  PRINT 'Anzahl Buchungen für Sollkonto angepasst: ' +  CONVERT(VARCHAR, @@ROWCOUNT);
	
  -- Habenkonto
  UPDATE dbo.KgBuchung
	SET HabenKtoNr = @KontoNrNeu
  WHERE
	KgPeriodeID = @KgPeriodeID
	AND HabenKtoNr = @KontoNrAlt
    AND ErstelltDatum >= @DatumVon
    
   PRINT 'Anzahl Buchungen für Habenkonto angepasst: ' +  CONVERT(VARCHAR, @@ROWCOUNT);    
  	
  
  -- done
  IF @CheckOnly <> 1
  BEGIN
	COMMIT TRANSACTION;
  END
  
  -- checkonly
  ELSE BEGIN
  
	SELECT 
		GBU.KgBuchungID,
		GPE.PeriodeVon,
		GPE.PeriodeBis,
		GBU.ErstelltDatum,
		GBU.HabenKtoNr,
		GBU.SollKtoNr,
		GBU.Betrag
	FROM dbo.KgBuchung GBU
		LEFT JOIN dbo.KgPeriode GPE ON GPE.KgPeriodeID = GBU.KgPeriodeID
	WHERE 
		(GBU.SollKtoNr = @KontoNrAlt OR GBU.HabenKtoNr =  @KontoNrAlt OR GBU.SollKtoNr = @KontoNrNeu OR GBU.HabenKtoNr = @KontoNrNeu)
	  AND GBU.KgPeriodeID = @KgPeriodeID

	ROLLBACK TRANSACTION;

  END
  PRINT ('Info: Successfully completed data handling and committed transaction.');
END TRY
BEGIN CATCH
  -- set error part
  SET @ErrorMessage = ERROR_MESSAGE();
  
  -- do rollback!
  ROLLBACK TRANSACTION;
  
  -- do not continue
  RAISERROR ('Error: Could not process data handling. Database error was: %s', 18, 1, @ErrorMessage);
  RETURN;
END CATCH;	  
	
	
SKIPPER: 
	PRINT 'Script stopped processing';	

	

  


