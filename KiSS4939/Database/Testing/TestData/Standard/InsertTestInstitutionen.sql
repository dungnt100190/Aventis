/*
 * Erstellt Test-Institutionen (Krankenkasse, Vermieter).
 *
 * Die Variable @AppUser muss korrekt gesetzt sein!
 */

DECLARE @AppUser VARCHAR(255);
SET @AppUser = 'diag_admin';

DECLARE @UserID INT;

SELECT @UserID = UserID
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
DECLARE @BaInstitutionID_KK INT; -- Krankenkasse
DECLARE @BaInstitutionID_VM INT; -- Vermieter
DECLARE @BaZahlungswegID_VM INT; -- Zahlungsweg Vermieter
-------------------------------------------------------------------------------


------------------
-- Krankenkasse --
------------------
INSERT INTO [BaInstitution] ([Name], [BaInstitutionArtCode], [Aktiv], [Debitor], [Kreditor], [Creator], [Modifier]) 
VALUES ('Krank ''N Kasse', 1, 1, 0, 0, dbo.fnGetDBRowCreatorModifier(@UserID), dbo.fnGetDBRowCreatorModifier(@UserID));

SET @BaInstitutionID_KK = SCOPE_IDENTITY();

-- Typ
INSERT INTO [BaInstitution_BaInstitutionTyp] ([BaInstitutionID], [BaInstitutionTypID], [Creator], [Modifier])
VALUES (@BaInstitutionID_KK, 3, dbo.fnGetDBRowCreatorModifier(@UserID), dbo.fnGetDBRowCreatorModifier(@UserID));

-- Adresse
INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@AppUser);

INSERT INTO [BaAdresse] ([BaInstitutionID], [DatumVon], [Strasse], [HausNr], [PLZ], [Ort], [Kanton], [BaLandID], [OrtschaftCode], [Creator], [Modifier])
VALUES (@BaInstitutionID_KK, '2009-01-01 00:00:00', 'Milchstrasse', '1', '4232', 'Fehren', 'SO', 147, 2584, dbo.fnGetDBRowCreatorModifier(@UserID), dbo.fnGetDBRowCreatorModifier(@UserID));

-- Zahlungsweg
INSERT INTO [BaZahlungsweg] ([BaInstitutionID], [DatumVon], [EinzahlungsscheinCode], [IBANNummer], [PostKontoNummer])
VALUES (@BaInstitutionID_KK, '2009-01-01 00:00:00', 2, 'CH8509000000305545415', '305545415');


---------------
-- Vermieter --
---------------
INSERT INTO [BaInstitution] ([Name], [BaInstitutionArtCode], [Aktiv], [Debitor], [Kreditor], [Creator], [Modifier]) 
VALUES ('Test Immo', 1, 1, 0, 0, dbo.fnGetDBRowCreatorModifier(@UserID), dbo.fnGetDBRowCreatorModifier(@UserID));

SET @BaInstitutionID_VM = SCOPE_IDENTITY();

-- Typ
INSERT INTO [BaInstitution_BaInstitutionTyp] ([BaInstitutionID], [BaInstitutionTypID], [Creator], [Modifier])
VALUES (@BaInstitutionID_VM, 5, dbo.fnGetDBRowCreatorModifier(@UserID), dbo.fnGetDBRowCreatorModifier(@UserID));

-- Adresse
INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@AppUser);

INSERT INTO [BaAdresse] ([BaInstitutionID], [DatumVon], [Strasse], [HausNr], [PLZ], [Ort], [Kanton], [BaLandID], [OrtschaftCode], [Creator], [Modifier])
VALUES (@BaInstitutionID_VM, '2009-01-01 00:00:00', 'Wohnstrasse', '2', '3210', 'Kerzers', 'FR', 147, 1874, dbo.fnGetDBRowCreatorModifier(@UserID), dbo.fnGetDBRowCreatorModifier(@UserID));

-- Zahlungsweg
INSERT INTO [BaZahlungsweg] ([BaInstitutionID], [DatumVon], [EinzahlungsscheinCode], [IBANNummer], [PostKontoNummer])
VALUES (@BaInstitutionID_VM, '2009-01-01 00:00:00', 2, 'CH8509000000305545415', '305545415');

SET @BaZahlungswegID_VM = SCOPE_IDENTITY();
GO
