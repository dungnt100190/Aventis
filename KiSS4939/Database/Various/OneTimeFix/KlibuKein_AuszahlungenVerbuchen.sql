/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: SOSTAT für Kunde ohne KliBu. 
           Alle freigegebene (KbBuchungStatusCode = 2) Auszahlungen verbuchen.
           Buchungen mit Auszahlungsart (KbAuszahlungsArtCode IN (102,104,103)):
             - Kreditor, über Papierverfügung zur Buchhaltung
             - Postcheck
             - Barauszahlung via Kasse
           
           Ausgleichsbuchung erstellen und Valutadatum als Belegdatum und Buchungsdatum verwenden.
           
           KbPeriodeID kann manuell gesetzt werden. 
           Wenn es NULL ist wird die aktuelle aktive Periode genommen.
=================================================================================================
  TEST: 
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @KbBuchungID INT;
DECLARE @KbPeriodeID INT;

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  KbBuchungID INT
);

-------------------------------------------------------------------------------
-- init KbPeriodeID
-------------------------------------------------------------------------------
SET @KbPeriodeID = 2; -- auf NULL setzen falls die aktuelle aktive Periode verwendet werden muss

IF (@KbPeriodeID IS NULL)
BEGIN
  SELECT @KbPeriodeID = KbPeriodeID
  FROM KbPeriode
  WHERE PeriodeStatusCode = 1
    AND GETDATE() BETWEEN PeriodeVon AND PeriodeBis;
END;

IF (@KbPeriodeID IS NULL)
BEGIN
  SELECT 'KbPeriode ist NULL!';
  RETURN;
END;

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
-- Grüne buchungen
INSERT INTO @TempTable (KbBuchungID)
  SELECT BUC.KbBuchungID
  FROM dbo.KbBuchung        BUC
    INNER JOIN dbo.BgBudget BDG ON BDG.BgBudgetID = BUC.BgBudgetID
  WHERE BUC.KbAuszahlungsArtCode IN (102,104,103) -- Papierverfügung, Postcheck, Barauszahlung
    AND BUC.KbBuchungStatusCode = 2 -- freigegeben
    AND BDG.Jahr < 2012;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

PRINT('Anzahl Auszahlungen zu verbuchen: ' + CONVERT(VARCHAR, @EntriesCount));

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @KbBuchungID = TMP.KbBuchungID
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------

  -- Zahlungskonto
  DECLARE @KbZahlungskontoID INT;
  SELECT 
    @KbZahlungskontoID = KZK.KbZahlungskontoID
  FROM dbo.KbZahlungskonto KZK
    LEFT JOIN dbo.KbKonto KBK ON KBK.KbZahlungskontoID = KZK.KbZahlungskontoID
  WHERE KBK.KbPeriodeID = @KbPeriodeID;

  -- AktivKonto
  DECLARE @AktivKontoID INT,
          @AktivKontoNr VARCHAR(10);
  SELECT
    @AktivKontoID = KbKontoId,
    @AktivKontoNr = KontoNr
  FROM KBKonto
  WHERE KbPeriodeID = @KbPeriodeID
    AND KbZahlungskontoID = @KbZahlungskontoID;

  IF @AktivKontoID > 0
  BEGIN
    ------------------------------------------------
    -- Ausgleichsbuchung erstellen
    ------------------------------------------------
    DECLARE @UserID INT;
    SELECT @UserID = dbo.fnXGetSystemUserID();

    -- BelegNr
    DECLARE @BelegNr INT;
    DECLARE @tmpBelegNr TABLE (BelegNr INT);

    INSERT INTO @tmpBelegNr
    EXEC dbo.spKbGetBelegNr @KbPeriodeID, 7, NULL;

    SELECT @BelegNr = BelegNr
    FROM @tmpBelegNr;

    -- Eintrag in KbBuchung
    INSERT INTO dbo.KbBuchung(BelegDatum,ErstelltDatum,KbBuchungTypCode,KbPeriodeID,KbBuchungStatusCode,Betrag,SollKtoNr,HabenKtoNr,[Text],BelegNr,ErstelltUserID)
    SELECT
     ValutaDatum,
     GETDATE(),
     4,
     @KbPeriodeID,
     6,
     Betrag,
     HabenKtoNr,
     @AktivKontoNr,
     'Ausgleichsbuchung',
     @BelegNr,
     @UserID
    FROM dbo.KbBuchung
    WHERE KbBuchungID = @KbBuchungID;

    DECLARE @KbBuchungID_Ausgleich INT;

    SELECT @KbBuchungID_Ausgleich = SCOPE_IDENTITY();

    -- Eintrag in KbOpAusgleich
    INSERT INTO dbo.KbOpAusgleich(OpBuchungID, AusgleichBuchungID, Betrag)
    SELECT
      KbBuchungID,
      @KbBuchungID_Ausgleich,
      Betrag
    FROM dbo.KbBuchung
    WHERE KbBuchungID = @KbBuchungID;

    -- OP-Buchung als ausgeglichen markieren und BelegDatum mit Valutadatum setzen
    UPDATE dbo.KbBuchung
      SET KbBuchungStatusCode = 6,
          BelegDatum = ValutaDatum
    WHERE KbBuchungID = @KbBuchungID;
    
    PRINT('Auszahlung verbucht. KbBuchungID = ' + CONVERT(VARCHAR, @KbBuchungID) + ', AusgleichBuchungID = ' + CONVERT(VARCHAR, @KbBuchungID_Ausgleich));
  END
  ELSE
  BEGIN
    PRINT('Keinen Aktivkonto bei KbBuchungID: ' + CONVERT(VARCHAR, @KbBuchungID));
  END;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

PRINT('Anzahl Auszahlungen verbucht: ' + CONVERT(VARCHAR, @EntriesIterator - 1));

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
