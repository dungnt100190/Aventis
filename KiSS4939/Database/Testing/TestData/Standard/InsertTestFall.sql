/*
 * Erstellt einen Testfall.
 * 
 * Wenn das Script mit einem bestimmten Benutzernamen ausgeführt werden soll,
 * kann die Variable @AppUser angepasst werden (z.B. auch in von 'ausserhalb' per Include)
 */

DECLARE @AppUser VARCHAR(255);
SET @AppUser = 'diag_admin';

DECLARE @UserID INT;
DECLARE @CreatorModifier VARCHAR(50);

SELECT @UserID          = UserID,
       @CreatorModifier = dbo.fnGetDBRowCreatorModifier(UserID)
FROM   XUser
WHERE  LogonName = @AppUser;

-- Validate user
IF (@UserID IS NULL)
BEGIN
  PRINT @AppUser;
  PRINT 'Achtung! Kein User mit diesem Logon-Namen gefunden! Ausführung wird abgebrochen.';
  RETURN;
END;

-------------------------------------------------------------------------------
-- Nur setzen, wenn vorher nicht Institutionen eingefügt wurden oder ein neuer Batch angefangen hat
DECLARE @BaInstitutionID_KK INT; -- Krankenkasse
DECLARE @BaZahlungswegID_KK INT; -- Zahlungsweg Krankenkasse
DECLARE @BaInstitutionID_VM INT; -- Vermieter
DECLARE @BaZahlungswegID_VM INT; -- Zahlungsweg Vermieter

-- Mit richtigen Institutions-IDs ersetzen:
SET @BaInstitutionID_KK = 1;
SET @BaZahlungswegID_KK = 1;
SET @BaInstitutionID_VM = 2;
SET @BaZahlungswegID_VM = 2;

DECLARE @BaPersonID_1 INT;        -- Fallträger
DECLARE @BaPersonID_2 INT;        -- 2. Person (Kind)
DECLARE @BaPersonID_3 INT;        -- 3. Person (Partner)
DECLARE @BaZahlungswegID_PRS INT; -- Zahlungsweg Fallträger
DECLARE @BgBudgetID INT;          -- Masterbudget
DECLARE @BgFinanzplanID INT;      -- Finanzplan
DECLARE @BgPositionID_GB INT;     -- Grundbedarf
DECLARE @BgPositionID_MGK INT;    -- Med. Grundvers. KVG
DECLARE @BgPositionID_MGV INT;    -- Med. Grundvers. VVG
DECLARE @BgPositionID_SL INT;     -- Situationsbedingte Leistungen
DECLARE @BgPositionID_WK INT;     -- Wohnkosten
DECLARE @BgPositionID_ZU INT;     -- Zulagen
DECLARE @FaLeistungID INT;        -- Sozialhilfe
DECLARE @DatumVon DATETIME;       -- Beginn des Finanzplans
DECLARE @DatumBis DATETIME;       -- Ende des Finanzplans

SET @DatumVon = dbo.fnFirstDayOf(GETDATE());
SET @DatumBis = DATEADD(DAY, -1, DATEADD(MONTH, 6, @DatumVon));

DECLARE @tmpID INT;
-------------------------------------------------------------------------------

-- ==============
-- Fall erstellen
-- ==============
INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@AppUser);

-- Fallträger
INSERT INTO dbo.BaPerson ([Name], [Vorname], [Geburtsdatum], [GeschlechtCode], [NationalitaetCode], [InCHSeitGeburt], [ImKantonSeitGeburt],
                          [Unterstuetzt], [Fiktiv], [Testperson], [SichtbarSDFlag], [PersonSichtbarSDFlag], Creator, Modifier)
VALUES ('Brandenburger', 'Regina', '1988-03-06 00:00:00', 2, 147, 0, 0, 1, 0, 0, 0, 1, @CreatorModifier, @CreatorModifier);

SET @BaPersonID_1 = SCOPE_IDENTITY();

-- Kostenstelle
EXECUTE dbo.spKbKostenstelleAnlegen @BaPersonID_1, @UserID;

-- Fallführung
INSERT INTO dbo.FaLeistung (BaPersonID, ModulID, UserID, GemeindeCode, DatumVon, IkHatUnterstuetzung, IkIstRentenbezueger, IkSchuldnerMahnen, FaFallID, Creator, Modifier)
VALUES (@BaPersonID_1, 2, @UserID, 352, @DatumVon, 0, 0, 1, @BaPersonID_1, @CreatorModifier, @CreatorModifier);


-- Zahlungsweg
INSERT INTO dbo.BaZahlungsweg (BaPersonID, DatumVon, EinzahlungsscheinCode)
VALUES (@BaPersonID_1, DATEADD(YEAR, -1, @DatumVon), 6);

SET @BaZahlungswegID_PRS = SCOPE_IDENTITY();


-- WV
INSERT INTO dbo.BaWVCode ([BaPersonID], [BaWVCode], [DatumVon], [DatumBis], [StatusCode], [KantonKuerzel])
VALUES (@BaPersonID_1, 21, @DatumVon, @DatumBis, 1, 'SG');


-- =============
-- Zweite Person
-- =============
INSERT INTO dbo.HistoryVersion
       (AppUser)
VALUES (@AppUser);

-- Person
INSERT INTO dbo.BaPerson ([Name], [Vorname], [Geburtsdatum], [GeschlechtCode], [NationalitaetCode], [InCHSeitGeburt], [ImKantonSeitGeburt],
                          [Unterstuetzt], [Fiktiv], [Testperson], [SichtbarSDFlag], [PersonSichtbarSDFlag], Creator, Modifier)
VALUES ('Brandenburger', 'Gabriella', '2008-06-01 00:00:00', 2, 147, 0, 0, 1, 0, 0, 0, 1, @CreatorModifier, @CreatorModifier);

SET @BaPersonID_2 = SCOPE_IDENTITY();


-- Relation
INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
VALUES (@BaPersonID_1, @BaPersonID_2, 1); -- Kind

-- Kostenstelle
EXECUTE dbo.spKbKostenstelleAnlegen @BaPersonID_2, @UserID;


-- WV
INSERT INTO dbo.BaWVCode (BaPersonID, BaWVCode, DatumVon, DatumBis, StatusCode)
VALUES (@BaPersonID_2, 21, @DatumVon, @DatumBis, 1);


-- =============
-- Dritte Person
-- =============
INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@AppUser);

-- Person
INSERT INTO dbo.BaPerson ([Name], [Vorname], [Geburtsdatum], [GeschlechtCode], [NationalitaetCode], [InCHSeitGeburt], [ImKantonSeitGeburt],
                          [Unterstuetzt], [Fiktiv], [Testperson], [SichtbarSDFlag], [PersonSichtbarSDFlag], Creator, Modifier)
VALUES ('Löffler', 'Ueli', '1977-06-16 00:00:00', 1, 147, 0, 0, 0, 0, 0, 0, 1, @CreatorModifier, @CreatorModifier);

SET @BaPersonID_3 = SCOPE_IDENTITY();


-- Relation
INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
VALUES (@BaPersonID_1, @BaPersonID_3, 14); -- rechtliche Partnerschaft

-- Kostenstelle
EXECUTE dbo.spKbKostenstelleAnlegen @BaPersonID_3, @UserID;


-- ===========
-- Sozialhilfe
-- ===========
INSERT INTO FaLeistung (FaFallID, BaPersonID, ModulID, FaProzessCode, DatumVon, UserID, Creator, Modifier)
  SELECT TOP 1 FaFallID, BaPersonID, 3, 300, @DatumVon, @UserID, @CreatorModifier, @CreatorModifier
  FROM dbo.FaFall
  WHERE BaPersonID = @BaPersonID_1
  ORDER BY DatumBis, DatumVon DESC;

SET @FaLeistungID = SCOPE_IDENTITY();

-- Finanzplan
EXECUTE dbo.spWhFinanzplan_Create @FaLeistungID, @DatumVon, @DatumBis, 2; -- Regulärer FP

SELECT TOP 1 @BgFinanzplanID = BgFinanzplanID
FROM dbo.BgFinanzplan
WHERE FaLeistungID = @FaLeistungID;

-- Update Leistung
UPDATE dbo.FaLeistung
SET BaPersonID = @BaPersonID_1, ModulID = 3, UserID = @UserID, GemeindeCode = 352, LeistungsartCode = 2, EroeffnungsGrundCode = 5,
    DatumVon = @DatumVon, IkHatUnterstuetzung = 0, IkIstRentenbezueger = 0, IkSchuldnerMahnen = 1, FaFallID = @BaPersonID_1, FaProzessCode = 300
WHERE FaLeistungID = @FaLeistungID;


-- Unterstützungsplan
INSERT INTO dbo.BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt)
VALUES (@BgFinanzplanID, @BaPersonID_2, 1)

INSERT INTO dbo.BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt)
VALUES (@BgFinanzplanID, @BaPersonID_3, 0)

-- Update Finanzplan
EXECUTE dbo.spWhFinanzplan_Update @BgFinanzplanID;

-- Get Budget
SELECT @BgBudgetID = BgBudgetID
FROM dbo.BgBudget
WHERE BgFinanzplanID = @BgFinanzplanID
  AND MasterBudget = 1;


-- ==============
-- Vorabzugskonti
-- ==============
INSERT INTO dbo.BgSpezkonto
       (FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, DatumVon, Inaktiv)
VALUES (@FaLeistungID, 2, 'Stromrechnung', $0.0000, 0, $30.0000, DATEADD(MONTH, 1, @DatumVon), 0);

SET @tmpID = SCOPE_IDENTITY();

EXECUTE spWhSpezkonto_UpdateBudget @tmpID;


-- =========
-- Kürzungen
-- =========
INSERT INTO dbo.BgSpezkonto
       (FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, DatumVon, BaPersonID,
       Inaktiv, KuerzungAnteilGBL, KuerzungLaufzeitMonate)
VALUES (@FaLeistungID, 4, 'Nicht eingehaltene Pendenz...', $0.0000, 0, DATEADD(MONTH, 3, @DatumVon), @BaPersonID_1, 0, $10.0000, 6);

SET @tmpID = SCOPE_IDENTITY();

EXECUTE dbo.spWhSpezkonto_UpdateBudget @tmpID;


-- ==========
-- Wohnkosten
-- ==========
SELECT @BgPositionID_WK = BgPositionID
FROM dbo.BgPosition
WHERE BgPositionsartID = 62;

UPDATE dbo.BgPosition
SET BgBudgetID = @BgBudgetID, BgKategorieCode = 2, BgPositionsartID = 62, Betrag = $1300.0000, Reduktion = $400.0500,
    Abzug = $33.3000, MaxBeitragSD = $833.3500, Buchungstext = 'Miete - gem. Richtlinie', VerwaltungSD = 0, BgBewilligungStatusCode = 5
WHERE BgPositionID = @BgPositionID_WK;

-- Auszahlung
DELETE TRM
FROM dbo.BgAuszahlungPersonTermin TRM
  INNER JOIN dbo.BgAuszahlungPerson AUS ON AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
WHERE AUS.BgPositionID = @BgPositionID_WK;

DELETE FROM dbo.BgAuszahlungPerson
WHERE BgPositionID = @BgPositionID_WK;

INSERT INTO BgAuszahlungPerson
       (BgPositionID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BaZahlungswegID, MitteilungZeile1)
VALUES (@BgPositionID_WK, 101, 1, @BaZahlungswegID_VM, 'Regina Brandenburger');


-- ====================
-- Med. Grundversorgung
-- ====================
-- Erste Person
SELECT @BgPositionID_MGK = BgPositionID
FROM dbo.BgPosition
WHERE BgPositionsartID = 32020
  AND BaPersonID = @BaPersonID_1;

UPDATE dbo.BgPosition
SET BgBudgetID = @BgBudgetID, BaPersonID = @BaPersonID_1, BgKategorieCode = 2, BgPositionsartID = 32121,
    Betrag = $300.0000, Reduktion = $0.0000, Abzug = $0.0000, MaxBeitragSD = $300.0000, Buchungstext = 'KVG Krankenkassenprämien',
    VerwaltungSD = 0, BaInstitutionID = @BaInstitutionID_KK, BgBewilligungStatusCode = 1
WHERE BgPositionID = @BgPositionID_MGK;


INSERT INTO dbo.BgPosition
       (BgPositionID_Parent, BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, Reduktion,
       Abzug, MaxBeitragSD, Buchungstext, VerwaltungSD, BaInstitutionID, BgBewilligungStatusCode)
VALUES (@BgPositionID_MGK, @BgBudgetID, @BaPersonID_1, 2, 32023, $0.0000, $0.0000, $0.0000, $0.0000, 'KVG - GBL', 0, @BaInstitutionID_KK, 1);


SELECT @BgPositionID_MGV = BgPositionID
FROM dbo.BgPosition
WHERE BgPositionsartID = 32021
  AND BaPersonID = @BaPersonID_1;

UPDATE dbo.BgPosition
SET BgBudgetID = @BgBudgetID, BaPersonID = @BaPersonID_1, BgKategorieCode = 2, BgPositionsartID = 32021,
    Betrag = $0.0000, Reduktion = $0.0000, Abzug = $0.0000, MaxBeitragSD = $0.0000, Buchungstext = 'VVG',
    VerwaltungSD = 0, BgBewilligungStatusCode = 1
WHERE BgPositionID = @BgPositionID_MGV;


-- Zweite Person
SELECT @BgPositionID_MGK = BgPositionID
FROM dbo.BgPosition
WHERE BgPositionsartID = 32020
  AND BaPersonID = @BaPersonID_2;

UPDATE dbo.BgPosition
SET BgBudgetID = @BgBudgetID, BaPersonID = @BaPersonID_2, BgKategorieCode = 2, BgPositionsartID = 32121,
    Betrag = $70.0000, Reduktion = $0.0000, Abzug = $0.0000, MaxBeitragSD = $300.0000, Buchungstext = 'KVG Krankenkassenprämien',
    VerwaltungSD = 0, BaInstitutionID = @BaInstitutionID_KK, BgBewilligungStatusCode = 1
WHERE BgPositionID = @BgPositionID_MGK;


INSERT INTO dbo.BgPosition
       (BgPositionID_Parent, BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, Reduktion,
       Abzug, MaxBeitragSD, Buchungstext, VerwaltungSD, BaInstitutionID, BgBewilligungStatusCode)
VALUES (@BgPositionID_MGK, @BgBudgetID, @BaPersonID_2, 2, 32023, $0.0000, $0.0000, $0.0000, $0.0000, 'KVG - GBL', 0, @BaInstitutionID_KK, 1);


SELECT @BgPositionID_MGV = BgPositionID
FROM dbo.BgPosition
WHERE BgPositionsartID = 32021
  AND BaPersonID = @BaPersonID_2;

UPDATE dbo.BgPosition
SET BgBudgetID = @BgBudgetID, BaPersonID = @BaPersonID_2, BgKategorieCode = 2, BgPositionsartID = 32021,
    Betrag = $0.0000, Reduktion = $0.0000, Abzug = $0.0000, MaxBeitragSD = $0.0000, Buchungstext = 'VVG',
    VerwaltungSD = 0, BgBewilligungStatusCode = 1
WHERE BgPositionID = @BgPositionID_MGV;


-- =======
-- Zulagen
-- =======
INSERT INTO dbo.BgPosition
       (BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, Reduktion, Abzug, MaxBeitragSD,
       Buchungstext, VerwaltungSD, BgBewilligungStatusCode)
VALUES (@BgBudgetID, @BaPersonID_1, 2, 39230, $100.0000, $0.0000, $0.0000, $999999999.0000, 'IZU', 0, 5);

SET @BgPositionID_ZU = SCOPE_IDENTITY();


-- =============================
-- Situationsbedingte Leistungen
-- =============================
INSERT INTO dbo.BgPosition
       (BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, Reduktion, Abzug, MaxBeitragSD,
       Buchungstext, VerwaltungSD, DatumVon, BgBewilligungStatusCode)
VALUES (@BgBudgetID, @BaPersonID_2, 2, 135, $250.0000, $0.0000, $0.0000, $999999999.0000,
       'Fremdbetreuung von Kindern', 0, @DatumVon, 5);

SET @BgPositionID_SL = SCOPE_IDENTITY();


-- =====================
-- Finanzplan bewilligen
-- =====================
INSERT INTO dbo.BgBewilligung
       (BgFinanzplanID, UserID, Datum, BgBewilligungCode, PerDatum) 
VALUES (@BgFinanzplanID, @UserID, @DatumVon, 2, @DatumVon);

EXECUTE dbo.spWhFinanzplan_Bewilligen @BgFinanzplanID, @DatumVon;

UPDATE dbo.BgBudget
SET BgBewilligungStatusCode = 5
WHERE BgFinanzplanID = @BgFinanzplanID
  AND MasterBudget = 1;


UPDATE dbo.BgFinanzplan
SET FaLeistungID = @FaLeistungID, BgBewilligungStatusCode = 5, WhHilfeTypCode = 2, GeplantVon = @DatumVon,
    GeplantBis = @DatumBis, DatumVon = @DatumVon, DatumBis = @DatumBis,
    WhGrundbedarfTypCode = 32015
WHERE BgFinanzplanID = @BgFinanzplanID;

-- ==================
-- Update Grundbedarf
-- ==================
UPDATE dbo.BgPosition
SET BgBudgetID = @BgBudgetID, BgKategorieCode = 2, BgPositionsartID = 32015, Betrag = $1190.6500,
    Reduktion = $0.0000, Abzug = $0.0000, Buchungstext = 'Grundbedarf SKOS 2005', VerwaltungSD = 0,
    BgBewilligungStatusCode = 5, MutiertUserID = @UserID, MutiertDatum = GETDATE()
WHERE BgPositionID = @BgPositionID_GB;


-- ==============
-- Update Zulagen
-- ==============
UPDATE dbo.BgPosition
SET BgBudgetID = @BgBudgetID, BaPersonID = @BaPersonID_1, BgKategorieCode = 2, BgPositionsartID = 39230,
    Betrag = $100.0000, Reduktion = $0.0000, Abzug = $0.0000, Buchungstext = 'IZU', VerwaltungSD = 0,
    BgBewilligungStatusCode = 5, MutiertUserID = @UserID, MutiertDatum = GETDATE()
WHERE BgPositionID = @BgPositionID_ZU;


-- =================
-- Budgets erstellen
-- =================

-- # Budgets:
DECLARE @BudgetCount INT;
SET @BudgetCount = 6;

DECLARE @BgBudgetIDs TABLE (BgBudgetID INT);

DECLARE @i INT;
SET @i = 0;

WHILE (@i < @BudgetCount)
BEGIN
  -- Budget erstellen
  INSERT INTO @BgBudgetIDs
    EXECUTE dbo.spWhBudget_Create @BgFinanzplanID;
  SELECT @tmpID = BgBudgetID
  FROM   @BgBudgetIDs;
  DELETE FROM @BgBudgetIDs;

  -- Grünstellen
  BEGIN TRY
    EXECUTE dbo.spWhBudget_CreateKbBuchung @tmpID, @UserID;
  END TRY
  BEGIN CATCH
    DECLARE @msgErr VARCHAR(4000);
    SET @msgErr = ERROR_MESSAGE();
    DECLARE @msgRaise VARCHAR(4000);
    SET @msgRaise = 'Budget:' + CONVERT(VARCHAR, @tmpID) + ' konnte nicht grüngestellt werden.';
    RAISERROR(@msgRaise, 16, 1);
    PRINT @msgErr;
    RETURN;
  END CATCH;

  -- Bewilligen
  UPDATE dbo.BgBudget
  SET BgBewilligungStatusCode = 5
  WHERE BgBudgetID = @tmpID;

  INSERT INTO dbo.BgBewilligung
         (BgBudgetID, UserID, Datum, BgBewilligungCode, Bemerkung) 
  VALUES (@tmpID, @UserID, GETDATE(), 103, 'Es wurden 1 Belege zur Zahlung freigegeben');

  SET @i = @i + 1;
END;


-- =====================
-- Budgetimport in KliBu
-- =====================
DECLARE @KbBuchungID INT;
DECLARE @KbPeriodeID INT;
DECLARE @BelegNr INT;

DECLARE curBuchung CURSOR FAST_FORWARD FOR
  SELECT KbBuchungID, KbPeriodeID
  FROM dbo.KbBuchung
  ORDER BY KbBuchungID ASC;

OPEN curBuchung;

WHILE (1 = 1)
BEGIN
  FETCH NEXT
  FROM curBuchung
  INTO @KbBuchungID, @KbPeriodeID;

  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;

  EXEC @BelegNr = dbo.spKbGetBelegNr @KbPeriodeID, 2, NULL; -- (2: Belegimport Sozialhilfe)
  
  UPDATE dbo.KbBuchung
  SET BelegNr = @BelegNr, BelegDatum = dbo.fnDateOf(GETDATE()), KbBuchungStatusCode = 13
  WHERE KbBuchungID = @KbBuchungID
END;

-- =============
-- SOSTAT Export
-- =============

-- Pendenzen-Job ausführen
EXEC dbo.spXTask_Create;

-- Anfangszustand erstellen
DECLARE @DatumVonBFS DATETIME;
DECLARE @Jahr INT;

SELECT @DatumVonBFS = DatumVon,
       @Jahr        = YEAR(DatumVon)
FROM dbo.FaLeistung
WHERE FaLeistungID = @FaLeistungID;

EXEC dbo.spBFSDossier_Create @Jahr, @FaLeistungID, @BaPersonID_1, 3, @DatumVonBFS, NULL, 0, 0;
GO