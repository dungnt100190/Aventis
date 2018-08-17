/*
  * Erstellt einen Testfall.
  * 
  * Wenn das Script mit einem bestimmten Benutzernamen ausgeführt werden soll,
  * kann die Variable @AppUser angepasst werden (z.B. auch in von 'ausserhalb' per Include)
  */

DECLARE @AppUser VARCHAR(255);
SET @AppUser = 'diag_admin';

DECLARE @UserID INT;
DECLARE @OrgUnitID INT;
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
DECLARE @FaFallID INT;            -- Fall
DECLARE @BaZahlungswegID_PRS INT; -- Zahlungsweg Fallträger
DECLARE @BgBudgetID INT;          -- Masterbudget
DECLARE @BgFinanzplanID INT;      -- Finanzplan
DECLARE @FaLeistungID INT;        -- Sozialhilfe
DECLARE @DatumVon DATETIME;       -- Beginn des Finanzplans
DECLARE @DatumBis DATETIME;       -- Ende des Finanzplans

SET @DatumVon = dbo.fnFirstDayOf(GETDATE());
SET @DatumBis = DATEADD(DAY, -1, DATEADD(MONTH, 6, @DatumVon));

DECLARE @tmpID INT;
-------------------------------------------------------------------------------

-- =========================
-- User muss in OrgUnit sein
-- =========================
SELECT @OrgUnitID = OrgUnitID
FROM dbo.XOrgUnit
WHERE ItemName = 'Administration';

IF (@OrgUnitID IS NULL)
BEGIN
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@AppUser);

  INSERT INTO dbo.XOrgUnit (ItemName, Kostenstelle, Mandantennummer, Creator, Modifier)
  VALUES ('Administration', 1, 1, @CreatorModifier, @CreatorModifier);

  SELECT @OrgUnitID = SCOPE_IDENTITY();

  INSERT INTO dbo.XOrgUnit_User (OrgUnitID, UserID, OrgUnitMemberCode)
  VALUES (@OrgUnitID, @UserID, 2); -- Mitglied
END;


-- ==============
-- Fall erstellen
-- ==============
INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@AppUser);

-- Fallträger
INSERT INTO dbo.BaPerson ([Name], [Vorname], [Geburtsdatum], [GeschlechtCode], [NationalitaetCode], [InCHSeitGeburt], [ImKantonSeitGeburt],
                          [Unterstuetzt], [Fiktiv], [Testperson], [SichtbarSDFlag], [PersonSichtbarSDFlag], Creator, Modifier)
VALUES ('Brandenburger', 'Regina', '1988-03-06 00:00:00', 2, 147, 0, 0, 1, 0, 0, 0, 1, @CreatorModifier, @CreatorModifier);

SET @BaPersonID_1 = SCOPE_IDENTITY();

-- Fall
INSERT INTO dbo.FaFall (BaPersonID, UserID, DatumVon)
VALUES (@BaPersonID_1, @UserID, @DatumVon);

SET @FaFallID = SCOPE_IDENTITY();

-- Klientensystem
INSERT INTO dbo.FaFallPerson (FaFallID, BaPersonID)
VALUES (@FaFallID, @BaPersonID_1);

-- Fallführung
INSERT INTO dbo.FaLeistung (BaPersonID, ModulID, FaProzessCode, UserID, GemeindeCode, DatumVon, IkHatUnterstuetzung, IkIstRentenbezueger, IkSchuldnerMahnen, FaFallID, Creator, Modifier)
VALUES (@BaPersonID_1, 2, 200, @UserID, 261, @DatumVon, 0, 0, 1, @FaFallID, @CreatorModifier, @CreatorModifier);

-- Zahlungsweg
INSERT INTO dbo.BaZahlungsweg (BaPersonID, DatumVon, EinzahlungsscheinCode)
VALUES (@BaPersonID_1, DATEADD(MONTH, -1, @DatumVon), 6);

SET @BaZahlungswegID_PRS = SCOPE_IDENTITY();

-- Adresse
INSERT INTO dbo.BaAdresse (BaPersonID, DatumVon, AdresseCode, Strasse, HausNr, PLZ, Ort, Kanton, BaLandID, OrtschaftCode, Creator, Modifier)
VALUES (@BaPersonID_1, '20000101', 1, 'Grosse Strasse', 42, '3000', 'Bern', 'BE', 147, 1670, @CreatorModifier, @CreatorModifier);

-- WV-Code
INSERT INTO dbo.BaWVCode (BaPersonID, DatumVon, BaWVStatusCode, WVCode, BaBedID)
VALUES (@BaPersonID_1, '20000101', 1, 5, 16006);
  

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

-- Klientensystem
INSERT INTO dbo.FaFallPerson (FaFallID, BaPersonID)
VALUES (@FaFallID, @BaPersonID_2);

-- Relation
INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
VALUES (@BaPersonID_1, @BaPersonID_2, 1); -- Kind

-- Adresse
INSERT INTO dbo.BaAdresse (BaPersonID, DatumVon, AdresseCode, Strasse, HausNr, PLZ, Ort, Kanton, BaLandID, OrtschaftCode, Creator, Modifier)
VALUES (@BaPersonID_2, '20000101', 1, 'Grosse Strasse', 42, '3000', 'Bern', 'BE', 147, 1670, @CreatorModifier, @CreatorModifier);

-- WV-Code
INSERT INTO dbo.BaWVCode (BaPersonID, DatumVon, BaWVStatusCode, WVCode, BaBedID)
VALUES (@BaPersonID_2, '20000101', 1, 5, 16006);


-- =============
-- Dritte Person
-- =============
INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@AppUser);

-- Person
INSERT INTO dbo.BaPerson ([Name], [Vorname], [Geburtsdatum], [GeschlechtCode], [NationalitaetCode], [InCHSeitGeburt], [ImKantonSeitGeburt],
                          [Unterstuetzt], [Fiktiv], [Testperson], [SichtbarSDFlag], [PersonSichtbarSDFlag], Creator, Modifier)
VALUES ('Löffler', 'Ueli', '1977-06-16 00:00:00', 1, 147, 0, 0, 0, 0, 0, 0, 1, @CreatorModifier, @CreatorModifier);

SET @BaPersonID_3 = SCOPE_IDENTITY();

-- Klientensystem
INSERT INTO dbo.FaFallPerson (FaFallID, BaPersonID)
VALUES (@FaFallID, @BaPersonID_3);

-- Relation
INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
VALUES (@BaPersonID_1, @BaPersonID_3, 14); -- rechtliche Partnerschaft


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

-- Update Finanzplan
UPDATE dbo.BgFinanzplan
SET UnterschriftAntrag = GETDATE(),
    XDocumentID_Leistungsentscheid = 0 -- Dummy-ID, damit Finanzplan "vollständig" erfasst ist
WHERE BgFinanzplanID = @BgFinanzplanID;

-- Update Leistung
UPDATE dbo.FaLeistung
SET BaPersonID = @BaPersonID_1,
    ModulID = 3,
    UserID = @UserID,
    GemeindeCode = 261,
    LeistungsartCode = 2,
    EroeffnungsGrundCode = 5,
    DatumVon = @DatumVon,
    IkHatUnterstuetzung = 0,
    IkIstRentenbezueger = 0,
    IkSchuldnerMahnen = 1,
    FaProzessCode = 300
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


-- ====================
-- Med. Grundversorgung
-- ====================
-- 1. Person
INSERT INTO [BgPosition] ([BgBudgetID], [BaPersonID], [BgPositionsartID], [BgKategorieCode], [DatumBis],
                          [DatumVon], [Buchungstext], [Betrag], [Reduktion], [Abzug],
                          [MaxBeitragSD], [VerwaltungSD], [BgBewilligungStatusCode])
VALUES (@BgBudgetID, @BaPersonID_1, 32020, 2, '20130731',
        '20120801', N'KVG Prämie inkl. Spesen', 300.0000, 0.0000, 0.0000,
        999999999.0000, 0, 5)

-- 2. Person
INSERT INTO [BgPosition] ([BgBudgetID], [BaPersonID], [BgPositionsartID], [BgKategorieCode], [DatumBis],
                          [DatumVon], [Buchungstext], [Betrag], [Reduktion], [Abzug],
                          [MaxBeitragSD], [VerwaltungSD], [BgBewilligungStatusCode])
VALUES (@BgBudgetID, @BaPersonID_2, 32020, 2, '20130731',
        '20120801', N'KVG Prämie inkl. Spesen', 70.0000, 0.0000, 0.0000,
        999999999.0000, 0, 5)


-- ==========
-- Wohnkosten
-- ==========
INSERT INTO [BgPosition] ([BgBudgetID], [BgPositionsartID], [BgKategorieCode], [DatumBis], [DatumVon],
                          [Buchungstext], [Betrag], [Reduktion], [Abzug], [MaxBeitragSD],
                          [VerwaltungSD], [BgBewilligungStatusCode])
VALUES (@BgBudgetID, 3104, 2, '20130731', '20120801',
        N'Miete inkl. Nebenkosten', 1300.0000, 500.0000, 0.0000, 800.0000,
        0, 5)


-- =======
-- Zulagen
-- =======
INSERT INTO [BgPosition] ([BgBudgetID], [BaPersonID], [BgPositionsartID], [BgKategorieCode], [DatumBis],
                          [DatumVon], [Buchungstext], [Betrag], [Reduktion], [Abzug],
                          [MaxBeitragSD], [VerwaltungSD], [BgBewilligungStatusCode], [Value1])
VALUES (@BgBudgetID, @BaPersonID_1, 40160, 2, '20130731',
        '20120801', N'IZU 16-25 Jahre', 100.0000, 0.0000, 0.0000,
        999999999.0000, 0, 5, 1)


-- ============
-- Zusätzliches
-- ============
INSERT INTO [BgPosition] ([BgBudgetID], [BaPersonID], [BgPositionsartID], [BgKategorieCode], [DatumBis],
                          [DatumVon], [Buchungstext], [Betrag], [Reduktion], [Abzug],
                          [MaxBeitragSD], [VerwaltungSD], [BgBewilligungStatusCode])
VALUES (@BgBudgetID, @BaPersonID_2, 40066, 2, '20130731',
        '20120801', N'Heim ohne interne Schule', 250.0000, 0.0000, 0.0000,
        999999999.0000, 0, 1)


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


-- =================
-- Budgets erstellen
-- =================

-- # Budgets:
DECLARE @BudgetCount INT;
SET @BudgetCount = 3;

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
    SET @msgRaise = 'Budget mit ID ' + CONVERT(VARCHAR, @tmpID) + ' konnte nicht grüngestellt werden: ' + ISNULL(@msgErr, '');
    RAISERROR(@msgRaise, 16, 1);
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
GO
