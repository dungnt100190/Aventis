SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XBookmark]
GO
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'AKT', N'Aktennotizen', 1, N'vwTmFaAktennotizen', N'Textmarken für die Aktennotizen', N'SELECT <TableColumn>
FROM dbo.vwTmFaAktennotizen WITH (READUNCOMMITTED)
WHERE FaAktennotizenID = {FaAktennotizenID}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'AKTAuszugIDsD', N'Aktennotizen', 1, NULL, N'Textmarken für alle angezeigten Aktennotizen', N'-- set current language
DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any AKTAuszugIDs*
-----------------------------------------------------------

-- setup vars
DECLARE @ShownIDsCsv VARCHAR(2000)
DECLARE @Idx INT
DECLARE @FaAktennotizenID VARCHAR(10)
DECLARE @CrLf VARCHAR(10)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- set other vars
SET @CrLf = CHAR(13) + CHAR(10)

-- init temp table
DECLARE @ShownIDs TABLE
(
  AutoID INT IDENTITY(1, 1),
  FaAktennotizenID INT
)

-- loop ids
SET @Idx = 1
WHILE @Idx <= LEN(@ShownIDsCsv)
BEGIN
  -- nicht numerische Zeichen überspringen
  WHILE @Idx <= LEN(@ShownIDsCsv) AND NOT SUBSTRING(@ShownIDsCsv, @Idx,1) BETWEEN ''0'' AND ''9''
  BEGIN
    SET @Idx = @Idx + 1
  END

  -- FaAktennotizenID aufbauen
  SET @FaAktennotizenID = ''''

  WHILE @Idx <= LEN(@ShownIDsCsv) AND SUBSTRING(@ShownIDsCsv, @Idx, 1) BETWEEN ''0'' AND ''9''
  BEGIN
    SET @FaAktennotizenID = @FaAktennotizenID + SUBSTRING(@ShownIDsCsv, @Idx, 1)
    SET @Idx = @Idx + 1
  END

  -- if id is valid, insert entry into temp table
  IF (@FaAktennotizenID <> '''')
  BEGIN
    INSERT @ShownIDs (FaAktennotizenID) VALUES (@FaAktennotizenID)
  END
END

-- create entries
SELECT Datum_Autor    = ISNULL(CONVERT(VARCHAR, FAN.Datum, 104), '''') + @CrLf + @CrLf +
                        ISNULL(dbo.fnGetLastFirstName(FAN.UserID, NULL, NULL), ''''),
       NextCell       = NULL,
       DL_Kontaktart  = ISNULL(dbo.fnLOVMLText(''FaModulDienstleistungen'', FAN.DienstleistungCode, @LanguageCode), '''') + @CrLf + @CrLf +
                        ISNULL(dbo.fnLOVMLText(''FaKontaktart'', FAN.KontaktArtCode, @LanguageCode), ''''),
       NextCell       = NULL,
       Stichworte     = FAN.Stichworte,
       NextCell       = NULL,
       InhaltRTF      = FAN.Inhalt,
       NextCell       = NULL,
       Beteil_Themen  = ISNULL(dbo.fnFaSplitBeteiligtePersonen(FAN.BeteiligtePersonen, 1, @LanguageCode), '''') + @CrLf + @CrLf +
                        ISNULL(REPLACE(dbo.fnLOVMLColumnListe(''FaLebensbereich'', FAN.ThemenCodes, NULL, @LanguageCode), '';'', @CrLf), ''''),
       NextCell       = NULL
FROM FaAktennotizen FAN
  INNER JOIN @ShownIDs IDS ON IDS.FaAktennotizenID = FAN.FaAktennotizenID
ORDER BY IDS.AutoID', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'AKTAuszugIDsF', N'Aktennotizen', 1, NULL, N'Textmarken für alle angezeigten Aktennotizen', N'-- set current language
DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any AKTAuszugIDs*
-----------------------------------------------------------

-- setup vars
DECLARE @ShownIDsCsv VARCHAR(2000)
DECLARE @Idx INT
DECLARE @FaAktennotizenID VARCHAR(10)
DECLARE @CrLf VARCHAR(10)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- set other vars
SET @CrLf = CHAR(13) + CHAR(10)

-- init temp table
DECLARE @ShownIDs TABLE
(
  AutoID INT IDENTITY(1, 1),
  FaAktennotizenID INT
)

-- loop ids
SET @Idx = 1
WHILE @Idx <= LEN(@ShownIDsCsv)
BEGIN
  -- nicht numerische Zeichen überspringen
  WHILE @Idx <= LEN(@ShownIDsCsv) AND NOT SUBSTRING(@ShownIDsCsv, @Idx,1) BETWEEN ''0'' AND ''9''
  BEGIN
    SET @Idx = @Idx + 1
  END

  -- FaAktennotizenID aufbauen
  SET @FaAktennotizenID = ''''

  WHILE @Idx <= LEN(@ShownIDsCsv) AND SUBSTRING(@ShownIDsCsv, @Idx, 1) BETWEEN ''0'' AND ''9''
  BEGIN
    SET @FaAktennotizenID = @FaAktennotizenID + SUBSTRING(@ShownIDsCsv, @Idx, 1)
    SET @Idx = @Idx + 1
  END

  -- if id is valid, insert entry into temp table
  IF (@FaAktennotizenID <> '''')
  BEGIN
    INSERT @ShownIDs (FaAktennotizenID) VALUES (@FaAktennotizenID)
  END
END

-- create entries
SELECT Datum_Autor    = ISNULL(CONVERT(VARCHAR, FAN.Datum, 104), '''') + @CrLf + @CrLf +
                        ISNULL(dbo.fnGetLastFirstName(FAN.UserID, NULL, NULL), ''''),
       NextCell       = NULL,
       DL_Kontaktart  = ISNULL(dbo.fnLOVMLText(''FaModulDienstleistungen'', FAN.DienstleistungCode, @LanguageCode), '''') + @CrLf + @CrLf +
                        ISNULL(dbo.fnLOVMLText(''FaKontaktart'', FAN.KontaktArtCode, @LanguageCode), ''''),
       NextCell       = NULL,
       Stichworte     = FAN.Stichworte,
       NextCell       = NULL,
       InhaltRTF      = FAN.Inhalt,
       NextCell       = NULL,
       Beteil_Themen  = ISNULL(dbo.fnFaSplitBeteiligtePersonen(FAN.BeteiligtePersonen, 1, @LanguageCode), '''') + @CrLf + @CrLf +
                        ISNULL(REPLACE(dbo.fnLOVMLColumnListe(''FaLebensbereich'', FAN.ThemenCodes, NULL, @LanguageCode), '';'', @CrLf), ''''),
       NextCell       = NULL
FROM FaAktennotizen FAN
  INNER JOIN @ShownIDs IDS ON IDS.FaAktennotizenID = FAN.FaAktennotizenID
ORDER BY IDS.AutoID', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'AKTAuszugIDsI', N'Aktennotizen', 1, NULL, N'Textmarken für alle angezeigten Aktennotizen', N'-- set current language
DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any AKTAuszugIDs*
-----------------------------------------------------------

-- setup vars
DECLARE @ShownIDsCsv VARCHAR(2000)
DECLARE @Idx INT
DECLARE @FaAktennotizenID VARCHAR(10)
DECLARE @CrLf VARCHAR(10)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- set other vars
SET @CrLf = CHAR(13) + CHAR(10)

-- init temp table
DECLARE @ShownIDs TABLE
(
  AutoID INT IDENTITY(1, 1),
  FaAktennotizenID INT
)

-- loop ids
SET @Idx = 1
WHILE @Idx <= LEN(@ShownIDsCsv)
BEGIN
  -- nicht numerische Zeichen überspringen
  WHILE @Idx <= LEN(@ShownIDsCsv) AND NOT SUBSTRING(@ShownIDsCsv, @Idx,1) BETWEEN ''0'' AND ''9''
  BEGIN
    SET @Idx = @Idx + 1
  END

  -- FaAktennotizenID aufbauen
  SET @FaAktennotizenID = ''''

  WHILE @Idx <= LEN(@ShownIDsCsv) AND SUBSTRING(@ShownIDsCsv, @Idx, 1) BETWEEN ''0'' AND ''9''
  BEGIN
    SET @FaAktennotizenID = @FaAktennotizenID + SUBSTRING(@ShownIDsCsv, @Idx, 1)
    SET @Idx = @Idx + 1
  END

  -- if id is valid, insert entry into temp table
  IF (@FaAktennotizenID <> '''')
  BEGIN
    INSERT @ShownIDs (FaAktennotizenID) VALUES (@FaAktennotizenID)
  END
END

-- create entries
SELECT Datum_Autor    = ISNULL(CONVERT(VARCHAR, FAN.Datum, 104), '''') + @CrLf + @CrLf +
                        ISNULL(dbo.fnGetLastFirstName(FAN.UserID, NULL, NULL), ''''),
       NextCell       = NULL,
       DL_Kontaktart  = ISNULL(dbo.fnLOVMLText(''FaModulDienstleistungen'', FAN.DienstleistungCode, @LanguageCode), '''') + @CrLf + @CrLf +
                        ISNULL(dbo.fnLOVMLText(''FaKontaktart'', FAN.KontaktArtCode, @LanguageCode), ''''),
       NextCell       = NULL,
       Stichworte     = FAN.Stichworte,
       NextCell       = NULL,
       InhaltRTF      = FAN.Inhalt,
       NextCell       = NULL,
       Beteil_Themen  = ISNULL(dbo.fnFaSplitBeteiligtePersonen(FAN.BeteiligtePersonen, 1, @LanguageCode), '''') + @CrLf + @CrLf +
                        ISNULL(REPLACE(dbo.fnLOVMLColumnListe(''FaLebensbereich'', FAN.ThemenCodes, NULL, @LanguageCode), '';'', @CrLf), ''''),
       NextCell       = NULL
FROM FaAktennotizen FAN
  INNER JOIN @ShownIDs IDS ON IDS.FaAktennotizenID = FAN.FaAktennotizenID
ORDER BY IDS.AutoID', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'AKTAuszugSuche', N'Aktennotizen', 1, NULL, N'Textmarke der Suchkriterien für alle angezeigten Aktennotizen', N'SELECT {SearchValues}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'AKTAutorMA', N'Aktennotizen', 1, N'vwTmUser', N'Textmarken für die Aktennotizen - Daten aus vwTmUser für Autor', N'-- setup vars
DECLARE @UserID INT

-- get userid from current FaAktennotizen.UserID
SELECT @UserID = UserID
FROM dbo.FaAktennotizen WITH (READUNCOMMITTED)
WHERE FaAktennotizenID = {FaAktennotizenID}

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BTI', N'Betreuungsinfo', 1, N'vwTmFaBetreuungsinfo', N'Textmarken für die Betreuungsinfo', N'SELECT <TableColumn>
FROM dbo.vwTmFaBetreuungsinfo WITH (READUNCOMMITTED)
WHERE FaBetreuungsinfoID = {FaBetreuungsinfoID}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWAuswertung', N'BegleitetesWohnen', 1, N'vwTmBwAuswertungOrganisation', N'Textmarken für Auswertung und Organisation des BegleitetenWohnens', N'SELECT <TableColumn>
FROM dbo.vwTmBwAuswertungOrganisation WITH (READUNCOMMITTED)
WHERE BwAuswertungOrganisationID = {BwAuswertungOrganisationID}', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BwEdMa', N'Fallführung', 1, N'vwTmEdMitarbeiter', N'Textmarken für die allgemeinen Bw/Ed-Mitarbeiterdaten', N'SELECT <TableColumn>
FROM dbo.vwTmEdMitarbeiter WITH (READUNCOMMITTED)
WHERE EDMitarbeiterID = {EdMitarbeiterID}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzKlient', N'BegleitetesWohnen', 1, N'vwTmBaPerson', N'Textmarken für den BegleitetesWohnen-Einsatz - Daten aus vwTmBaPerson für betroffenen Klienten', N'SELECT <TableColumn>
FROM dbo.vwTmBaPerson WITH (READUNCOMMITTED)
WHERE BaPersonID = {BaPersonID}', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeKlKurzD', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeKlKurzF', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeKlKurzI', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeKlLangeD', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeKlLangeF', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeKlLangeI', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeMAKurzD', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeMAKurzF', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeMAKurzI', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeMALangeD', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeMALangeF', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzListeMALangeI', N'BegleitetesWohnen', 1, NULL, N'Textmarken für den BegleitetesWohnen-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spBwEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzMADL', N'BegleitetesWohnen', 1, N'vwTmUser', N'Textmarken für den BegleitetesWohnen-Einsatz - Daten aus vwTmUser für den MA der zugehörigen Leistung', N'-- setup vars
DECLARE @UserID INT

-- get userid from leistung
SELECT TOP 1 @UserID = UserID
FROM dbo.FaLeistung WITH (READUNCOMMITTED)
WHERE FaLeistungID = {FaLeistungID}

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsatzMAEd', N'BegleitetesWohnen', 1, N'vwTmEdEinsatzEDMitarbeiter', N'Textmarken für den BegleitetesWohnen-Einsatz - Mitarbeiter, welcher aktuell als BW-Mitarbeiter ausgewählt, oder im Abfrage-Modus für die Suche verwendet wird', N'SELECT <TableColumn>
FROM dbo.vwTmEdEinsatzEDMitarbeiter WITH (READUNCOMMITTED)
WHERE UserID = {UserIDOfBW} 
  AND XModulID = {ModulID}', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWEinsVereinb', N'BegleitetesWohnen', 1, N'vwTmBwEinsatzvereinbarung', N'Textmarken für die Einsatzvereinbarung des BegleitetenWohnens', N'SELECT <TableColumn>
FROM dbo.vwTmBwEinsatzvereinbarung WITH (READUNCOMMITTED)
WHERE BwEinsatzvereinbarungID = {BwEinsatzvereinbarungID}', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'BWMa', N'BegleitetesWohnen', 1, N'vwTmEdMitarbeiterBw', N'Textmarken für die spezifischen BegleitetesWohen-Mitarbeiterdaten', N'SELECT <TableColumn>
FROM dbo.vwTmEdMitarbeiterBw WITH (READUNCOMMITTED)
WHERE EDMitarbeiterID = {EdMitarbeiterID}', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CM', N'CaseManagement', 1, N'vwTmCmCaseManagement', N'Textmarken für das CaseManagement', N'SELECT <TableColumn>
FROM dbo.vwTmCmCaseManagement WITH (READUNCOMMITTED)
WHERE FaCaseManagementID = {FaCaseManagementID}', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMEvalListeD', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Evaluation - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMEvalListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 1, 0, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMEvalListeF', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Evaluation - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMEvalListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 1, 0, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMEvalListeI', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Evaluation - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMEvalListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 1, 0, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMZustaendigMA', N'CaseManagement', 1, N'vwTmUser', N'Textmarken für das CaseManagement - Daten aus vwTmUser für Zuständig SAR', N'-- setup vars
DECLARE @UserID INT

-- get userid from current FaSozialberatung.UserID
SELECT @UserID = LEI.UserID
FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
WHERE LEI.FaLeistungID = {FaLeistungID}

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMZvListeD', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Zielvereinbarung - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMZvListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 0, 0, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMZvListeF', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Zielvereinbarung - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMZvListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 0, 0, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMZvListeI', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Zielvereinbarung - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMZvListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 0, 0, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMZvListeOhneEvalD', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Zielvereinbarung - Liste der Ziele und Massnahmen, ohne evaluierte Einträge', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMZvListeOhneEval*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 0, 1, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMZvListeOhneEvalF', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Zielvereinbarung - Liste der Ziele und Massnahmen, ohne evaluierte Einträge', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMZvListeOhneEval*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 0, 1, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'CMZvListeOhneEvalI', N'CaseManagement', 1, NULL, N'Textmarken für die CaseManagement-Zielvereinbarung - Liste der Ziele und Massnahmen, ohne evaluierte Einträge', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any CMZvListeOhneEval*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 4, 0, 1, @LanguageCode', 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeuteKurz', N'Andere', 1, NULL, N'Format dd.mm.yyyy', N'SELECT CONVERT(VARCHAR, GETDATE(), 104)', 0, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeuteLangeD', N'Andere', 1, NULL, N'Format dd. mmmm yyyy', N'SELECT CONVERT(VARCHAR, DAY(GETDATE())) + ''. '' +
       dbo.fnXMonatML(MONTH(GETDATE()), 1) + '' '' +
       CONVERT(VARCHAR, YEAR(GETDATE()))', 0, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeuteLangeF', N'Andere', 1, NULL, N'Format dd. mmmm yyyy', N'SELECT CONVERT(VARCHAR, DAY(GETDATE())) + ''. '' +
       dbo.fnXMonatML(MONTH(GETDATE()), 2) + '' '' +
       CONVERT(VARCHAR, YEAR(GETDATE()))', 0, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeuteLangeI', N'Andere', 1, NULL, N'Format dd. mmmm yyyy', N'SELECT CONVERT(VARCHAR, DAY(GETDATE())) + ''. '' +
       dbo.fnXMonatML(MONTH(GETDATE()), 3) + '' '' +
       CONVERT(VARCHAR, YEAR(GETDATE()))', 0, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'DOC', N'Dokumente', 1, N'vwTmFaDokumente', N'Textmarken für die Dokumente', N'DECLARE @FaDokumenteID INT;
DECLARE @BaInstitutionKontaktID INT;

SET @FaDokumenteID = ISNULL({FaDokumenteID}, -1);
SET @BaInstitutionKontaktID = ISNULL({BaInstitutionKontaktID}, -1);

SELECT <TableColumn>
FROM dbo.vwTmFaDokumente DOC WITH (READUNCOMMITTED)
WHERE DOC.FaDokumenteID = @FaDokumenteID
  AND (DOC.AdressatKPInkID IS NULL OR DOC.AdressatKPInkID = @BaInstitutionKontaktID);', 13, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'DOCAutorMA', N'Dokumente', 1, N'vwTmUser', N'Textmarken für die Dokumente - Daten aus vwTmUser, wenn Autor ein Mitarbeiter ist', N'-- setup vars
DECLARE @UserID INT

-- get userid from current document.autor
SELECT @UserID = AutorID
FROM dbo.FaDokumente WITH (READUNCOMMITTED)
WHERE AutorAdressTypCode = 1 AND -- user only
      FaDokumenteID = {FaDokumenteID}

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 13, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDAuswDaten', N'Entlastungsdienst', 1, N'vwTmEdAuswertungsdaten', N'Textmarken für die Entlastungsdienst-Auswertungsdaten', N'SELECT <TableColumn>
FROM dbo.vwTmEdAuswertungsdaten WITH (READUNCOMMITTED)
WHERE EdAuswertungsdatenID = {EdAuswertungsdatenID}', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzKlient', N'Entlastungsdienst', 1, N'vwTmBaPerson', N'Textmarken für den Entlastungsdienst-Einsatz - Daten aus vwTmBaPerson für betroffenen Klienten', N'SELECT <TableColumn>
FROM dbo.vwTmBaPerson WITH (READUNCOMMITTED)
WHERE BaPersonID = {BaPersonID}', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlKurzD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlKurzF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlKurzI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlKurzOhneTelTypD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlKurzOhneTelTypF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlKurzOhneTelTypI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''client_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlLangeD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlLangeF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlLangeI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlLangeOhneTelTypD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlLangeOhneTelTypF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeKlLangeOhneTelTypI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Klienten', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''client_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMAKurzD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMAKurzF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMAKurzI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMAKurzOhneTelTypD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter (Telefon ohne Typangabe)', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMAKurzOhneTelTypF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter (Telefon ohne Typangabe)', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMAKurzOhneTelTypI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter (Telefon ohne Typangabe)', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''ma_withfromto_shortday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMALangeD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMALangeF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMALangeI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMALangeOhneTelTypD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter (Telefon ohne Typangabe)', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 1
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMALangeOhneTelTypF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter (Telefon ohne Typangabe)', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 2
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzListeMALangeOhneTelTypI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Liste Einsätze von Mitarbeiter (Telefon ohne Typangabe)', N'DECLARE @LanguageCode INT
DECLARE @ReturnTable VARCHAR(50)

SET @LanguageCode = 3
SET @ReturnTable  = ''ma_withfromto_longday''

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzListe*
-----------------------------------------------------------
-- setup vars
DECLARE @ShownIDsCsv VARCHAR(1000)

-- get shown ids
SET @ShownIDsCsv = {SelectedIdList}

-- get data as defined
EXEC dbo.spEdEinsatzTextmarkeListen @ShownIDsCsv, @LanguageCode, @ReturnTable, 1;', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzMADL', N'Entlastungsdienst', 1, N'vwTmUser', N'Textmarken für den Entlastungsdienst-Einsatz - Daten aus vwTmUser für den MA der zugehörigen Leistung', N'-- setup vars
DECLARE @UserID INT

-- get userid from leistung
SELECT TOP 1 @UserID = UserID
FROM dbo.FaLeistung WITH (READUNCOMMITTED)
WHERE FaLeistungID = {FaLeistungID}

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzMAEd', N'Entlastungsdienst', 1, N'vwTmEdEinsatzEDMitarbeiter', N'Textmarken für den Entlastungsdienst-Einsatz - Mitarbeiter, welcher aktuell als ED-Mitarbeiter ausgewählt, oder im Abfrage-Modus für die Suche verwendet wird', N'SELECT <TableColumn>
FROM dbo.vwTmEdEinsatzEDMitarbeiter WITH (READUNCOMMITTED)
WHERE UserID = {UserIDOfED} 
  AND XModulID = {ModulID}', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzSucheDatumBis', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Bis-Datum aus Suche (AccessMode.Leistung), sonst via Parameter in Init()', N'-- init var
DECLARE @DatumBis VARCHAR(50)

-- get value from context
SET @DatumBis = {SearchDatumBis}

-- select value depending on given context value (kind of hack, because if context will return "", an error will occure)
SELECT CASE WHEN ISNULL(@DatumBis, ''-'') = ''-'' THEN ''''
            ELSE @DatumBis
       END', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzSucheDatumVon', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - Von-Datum aus Suche (AccessMode.Leistung), sonst via Parameter in Init()', N'-- init var
DECLARE @DatumVon VARCHAR(50)

-- get value from context
SET @DatumVon = {SearchDatumVon}

-- select value depending on given context value (kind of hack, because if context will return "", an error will occure)
SELECT CASE WHEN ISNULL(@DatumVon, ''-'') = ''-'' THEN ''''
            ELSE @DatumVon
       END', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzSucheTypEdD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - TypED aus Suche (AccessMode.Leistung), sonst via Parameter in Init()', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzSucheTypEd*
-----------------------------------------------------------
SELECT dbo.fnGetLOVMLText(''EdTyp'', ISNULL({SearchTypED}, -1), @LanguageCode)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzSucheTypEdF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - TypED aus Suche (AccessMode.Leistung), sonst via Parameter in Init()', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzSucheTypEd*
-----------------------------------------------------------
SELECT dbo.fnGetLOVMLText(''EdTyp'', ISNULL({SearchTypED}, -1), @LanguageCode)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsatzSucheTypEdI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst-Einsatz - TypED aus Suche (AccessMode.Leistung), sonst via Parameter in Init()', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDEinsatzSucheTypEd*
-----------------------------------------------------------
SELECT dbo.fnGetLOVMLText(''EdTyp'', ISNULL({SearchTypED}, -1), @LanguageCode)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDEinsVereinb', N'Entlastungsdienst', 1, N'vwTmEdEinsatzvereinbarung', N'Textmarken für die Entlastungsdienst-Einsatzvereinbarung', N'SELECT <TableColumn>
FROM dbo.vwTmEdEinsatzvereinbarung WITH (READUNCOMMITTED)
WHERE EdEinsatzvereinbarungID = {EdEinsatzvereinbarungID}', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDMa', N'Entlastungsdienst', 1, N'vwTmEdMitarbeiterEd', N'Textmarken für die spezifischen Entlastungsdienst-Mitarbeiterdaten', N'SELECT <TableColumn>
FROM dbo.vwTmEdMitarbeiterEd WITH (READUNCOMMITTED)
WHERE EDMitarbeiterID = {EdMitarbeiterID}', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDMaKurseListeD', N'Entlastungsdienst', 1, NULL, N'Textmarken für die Entlastungsdienst-Mitarbeiter - Kurse der Mitarbeiter als Liste', N'DECLARE @LanguageCode INT

SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
-----------------------------------------------------------
-- setup vars
DECLARE @EdMaKursIDsCsv VARCHAR(1000)

-- get shown ids
SET @EdMaKursIDsCsv = {EdMitarbeiterKursIDList}

-- get data as defined
EXEC dbo.spEdMaKursTextmarkeListe @EdMaKursIDsCsv, @LanguageCode', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDMaKurseListeF', N'Entlastungsdienst', 1, NULL, N'Textmarken für die Entlastungsdienst-Mitarbeiter - Kurse der Mitarbeiter als Liste', N'DECLARE @LanguageCode INT

SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
-----------------------------------------------------------
-- setup vars
DECLARE @EdMaKursIDsCsv VARCHAR(1000)

-- get shown ids
SET @EdMaKursIDsCsv = {EdMitarbeiterKursIDList}

-- get data as defined
EXEC dbo.spEdMaKursTextmarkeListe @EdMaKursIDsCsv, @LanguageCode', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDMaKurseListeI', N'Entlastungsdienst', 1, NULL, N'Textmarken für die Entlastungsdienst-Mitarbeiter - Kurse der Mitarbeiter als Liste', N'DECLARE @LanguageCode INT

SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
-----------------------------------------------------------
-- setup vars
DECLARE @EdMaKursIDsCsv VARCHAR(1000)

-- get shown ids
SET @EdMaKursIDsCsv = {EdMitarbeiterKursIDList}

-- get data as defined
EXEC dbo.spEdMaKursTextmarkeListe @EdMaKursIDsCsv, @LanguageCode', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDRechnAdresseED1EinzD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst - RechnungsadresseED1 des Klienten (einzeilig)', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDRechnAdresseED1Einz*
-----------------------------------------------------------
-- setup vars
DECLARE @BaPersonID INT

-- get shown ids
SET @BaPersonID = {BaPersonID}

-- get data as defined
SELECT RaED1 = dbo.fnGetFlexibleAdress(@BaPersonID, NULL, @LanguageCode, 0, ''raed1'', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDRechnAdresseED1EinzF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst - RechnungsadresseED1 des Klienten (einzeilig)', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDRechnAdresseED1Einz*
-----------------------------------------------------------
-- setup vars
DECLARE @BaPersonID INT

-- get shown ids
SET @BaPersonID = {BaPersonID}

-- get data as defined
SELECT RaED1 = dbo.fnGetFlexibleAdress(@BaPersonID, NULL, @LanguageCode, 0, ''raed1'', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDRechnAdresseED1EinzI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst - RechnungsadresseED1 des Klienten (einzeilig)', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDRechnAdresseED1Einz*
-----------------------------------------------------------
-- setup vars
DECLARE @BaPersonID INT

-- get shown ids
SET @BaPersonID = {BaPersonID}

-- get data as defined
SELECT RaED1 = dbo.fnGetFlexibleAdress(@BaPersonID, NULL, @LanguageCode, 0, ''raed1'', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDRechnAdresseED1MehrzD', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst - RechnungsadresseED1 des Klienten (mehrzeilig)', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDRechnAdresseED1Mehrz*
-----------------------------------------------------------
-- setup vars
DECLARE @BaPersonID INT

-- get shown ids
SET @BaPersonID = {BaPersonID}

-- get data as defined
SELECT RaED1 = dbo.fnGetFlexibleAdress(@BaPersonID, NULL, @LanguageCode, 1, ''raed1'', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDRechnAdresseED1MehrzF', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst - RechnungsadresseED1 des Klienten (mehrzeilig)', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDRechnAdresseED1Mehrz*
-----------------------------------------------------------
-- setup vars
DECLARE @BaPersonID INT

-- get shown ids
SET @BaPersonID = {BaPersonID}

-- get data as defined
SELECT RaED1 = dbo.fnGetFlexibleAdress(@BaPersonID, NULL, @LanguageCode, 1, ''raed1'', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'EDRechnAdresseED1MehrzI', N'Entlastungsdienst', 1, NULL, N'Textmarken für den Entlastungsdienst - RechnungsadresseED1 des Klienten (mehrzeilig)', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any EDRechnAdresseED1Mehrz*
-----------------------------------------------------------
-- setup vars
DECLARE @BaPersonID INT

-- get shown ids
SET @BaPersonID = {BaPersonID}

-- get data as defined
SELECT RaED1 = dbo.fnGetFlexibleAdress(@BaPersonID, NULL, @LanguageCode, 1, ''raed1'', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)', 6, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaLeistungDatumBis', N'Fallführung', 1, NULL, N'Textmarke für die Fallführung - DatumBis', N'SELECT CONVERT(VARCHAR, DatumBis, 104)
FROM dbo.FaLeistung WITH (READUNCOMMITTED)
WHERE FaLeistungID = {FaLeistungID}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaLeistungDatumVon', N'Fallführung', 1, NULL, N'Textmarke für die Fallführung - DatumVon', N'SELECT CONVERT(VARCHAR, DatumVon, 104)
FROM dbo.FaLeistung WITH (READUNCOMMITTED)
WHERE FaLeistungID = {FaLeistungID}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'FG', N'Finanzgesuche', 1, N'vwTmFaFinanzgesuche', N'Textmarken für die Finanzgesuche', N'SELECT <TableColumn> FROM vwTmFaFinanzgesuche WHERE FaFinanzgesucheID = {FaFinanzgesucheId}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'IN', N'Intake', 1, N'vwTmFaIntake', N'Textmarken für das Intake', N'SELECT <TableColumn>
FROM dbo.vwTmFaIntake WITH (READUNCOMMITTED)
WHERE FaIntakeID = {FaIntakeID}', 7, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KL', N'Klientensystem', 1, N'vwTmBaPerson', N'Textmarken für das Klientensystem', N'SELECT <TableColumn>
FROM dbo.vwTmBaPerson WITH (READUNCOMMITTED)
WHERE BaPersonID = {BaPersonID}', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenBwEdD', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Begleiter/innen und Entlaster/innen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 1;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenBwEd*
-----------------------------------------------------------

-----------------------------------------------------------
-- collect module short-texts
-----------------------------------------------------------
-- init vars
DECLARE @ShortTextBW VARCHAR(20);
DECLARE @ShortTextED VARCHAR(20);

-- get translated texts
SELECT @ShortTextBW = ISNULL(dbo.fnGetMLText(LOV.ShortTextTID, @LanguageCode), LOV.ShortText)
FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName = ''Modul'' 
  AND LOV.Code = 5;  -- BW

SELECT @ShortTextED = ISNULL(dbo.fnGetMLText(LOV.ShortTextTID, @LanguageCode), LOV.ShortText)
FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName = ''Modul''
  AND LOV.Code = 6;  -- ED

-- validate
SET @ShortTextBW = ISNULL(@ShortTextBW, ''BW'');
SET @ShortTextED = ISNULL(@ShortTextED, ''ED'');

-----------------------------------------------------------
-- collect data from BW/ED users
-----------------------------------------------------------
SELECT Module     = @ShortTextBW, -- static for BW
       NextCell   = NULL,
       UserName   = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
       NextCell   = NULL,
       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 1, ''edmitarbeiter'', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
       NextCell   = NULL,
       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
       NextCell   = NULL,
       TelNrMobil = USR.PhoneMobile,
       NextCell   = NULL,
       EMail      = USR.EMail,
       NextCell   = NULL
FROM dbo.XUser_BwEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
  INNER JOIN dbo.BwEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.BwEinsatzvereinbarungID = UEV.BwEinsatzvereinbarungID
                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 5) -- 5=BW
  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

UNION ALL

SELECT Module     = @ShortTextED, -- static for ED
       NextCell   = NULL,
       UserName   = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
       NextCell   = NULL,
       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 1, ''edmitarbeiter'', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
       NextCell   = NULL,
       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
       NextCell   = NULL,
       TelNrMobil = USR.PhoneMobile,
       NextCell   = NULL,
       EMail      = USR.EMail,
       NextCell   = NULL
FROM dbo.XUser_EdEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
  INNER JOIN dbo.EdEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.EdEinsatzvereinbarungID = UEV.EdEinsatzvereinbarungID
                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 6) -- 6=ED
  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

ORDER BY Module, UserName, Adresse;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenBwEdF', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Begleiter/innen und Entlaster/innen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 2;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenBwEd*
-----------------------------------------------------------

-----------------------------------------------------------
-- collect module short-texts
-----------------------------------------------------------
-- init vars
DECLARE @ShortTextBW VARCHAR(20);
DECLARE @ShortTextED VARCHAR(20);

-- get translated texts
SELECT @ShortTextBW = ISNULL(dbo.fnGetMLText(LOV.ShortTextTID, @LanguageCode), LOV.ShortText)
FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName = ''Modul'' 
  AND LOV.Code = 5;  -- BW

SELECT @ShortTextED = ISNULL(dbo.fnGetMLText(LOV.ShortTextTID, @LanguageCode), LOV.ShortText)
FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName = ''Modul''
  AND LOV.Code = 6;  -- ED

-- validate
SET @ShortTextBW = ISNULL(@ShortTextBW, ''BW'');
SET @ShortTextED = ISNULL(@ShortTextED, ''ED'');

-----------------------------------------------------------
-- collect data from BW/ED users
-----------------------------------------------------------
SELECT Module     = @ShortTextBW, -- static for BW
       NextCell   = NULL,
       UserName   = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
       NextCell   = NULL,
       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 1, ''edmitarbeiter'', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
       NextCell   = NULL,
       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
       NextCell   = NULL,
       TelNrMobil = USR.PhoneMobile,
       NextCell   = NULL,
       EMail      = USR.EMail,
       NextCell   = NULL
FROM dbo.XUser_BwEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
  INNER JOIN dbo.BwEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.BwEinsatzvereinbarungID = UEV.BwEinsatzvereinbarungID
                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 5) -- 5=BW
  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

UNION ALL

SELECT Module     = @ShortTextED, -- static for ED
       NextCell   = NULL,
       UserName   = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
       NextCell   = NULL,
       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 1, ''edmitarbeiter'', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
       NextCell   = NULL,
       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
       NextCell   = NULL,
       TelNrMobil = USR.PhoneMobile,
       NextCell   = NULL,
       EMail      = USR.EMail,
       NextCell   = NULL
FROM dbo.XUser_EdEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
  INNER JOIN dbo.EdEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.EdEinsatzvereinbarungID = UEV.EdEinsatzvereinbarungID
                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 6) -- 6=ED
  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

ORDER BY Module, UserName, Adresse;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenBwEdI', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Begleiter/innen und Entlaster/innen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 3;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenBwEd*
-----------------------------------------------------------

-----------------------------------------------------------
-- collect module short-texts
-----------------------------------------------------------
-- init vars
DECLARE @ShortTextBW VARCHAR(20);
DECLARE @ShortTextED VARCHAR(20);

-- get translated texts
SELECT @ShortTextBW = ISNULL(dbo.fnGetMLText(LOV.ShortTextTID, @LanguageCode), LOV.ShortText)
FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName = ''Modul'' 
  AND LOV.Code = 5;  -- BW

SELECT @ShortTextED = ISNULL(dbo.fnGetMLText(LOV.ShortTextTID, @LanguageCode), LOV.ShortText)
FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
WHERE LOV.LOVName = ''Modul''
  AND LOV.Code = 6;  -- ED

-- validate
SET @ShortTextBW = ISNULL(@ShortTextBW, ''BW'');
SET @ShortTextED = ISNULL(@ShortTextED, ''ED'');

-----------------------------------------------------------
-- collect data from BW/ED users
-----------------------------------------------------------
SELECT Module     = @ShortTextBW, -- static for BW
       NextCell   = NULL,
       UserName   = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
       NextCell   = NULL,
       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 1, ''edmitarbeiter'', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
       NextCell   = NULL,
       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
       NextCell   = NULL,
       TelNrMobil = USR.PhoneMobile,
       NextCell   = NULL,
       EMail      = USR.EMail,
       NextCell   = NULL
FROM dbo.XUser_BwEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
  INNER JOIN dbo.BwEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.BwEinsatzvereinbarungID = UEV.BwEinsatzvereinbarungID
                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 5) -- 5=BW
  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

UNION ALL

SELECT Module     = @ShortTextED, -- static for ED
       NextCell   = NULL,
       UserName   = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
       NextCell   = NULL,
       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 1, ''edmitarbeiter'', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
       NextCell   = NULL,
       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
       NextCell   = NULL,
       TelNrMobil = USR.PhoneMobile,
       NextCell   = NULL,
       EMail      = USR.EMail,
       NextCell   = NULL
FROM dbo.XUser_EdEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
  INNER JOIN dbo.EdEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.EdEinsatzvereinbarungID = UEV.EdEinsatzvereinbarungID
                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 6) -- 6=ED
  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

ORDER BY Module, UserName, Adresse;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenInstFachpersD', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Institutionen/Fachpersonen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 1;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenInstFachpers*
-----------------------------------------------------------

-----------------------------------------------------------
-- get relation codes and texts
-----------------------------------------------------------
SELECT DISTINCT 
       [Name]            = ISNULL(INS.NameVorname, ''''),
       NextCell          = NULL,
       Adresse           = dbo.fnGetLastFirstName(NULL, INS.StrasseHausNr, INS.PLZOrt),
       NextCell          = NULL,
       Kontaktperson     = dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname),
       NextCell          = NULL,
       TelNr             = COALESCE(INK.Telefon, INS.Telefon, INS.Telefon2, INS.Telefon3),
       NextCell          = NULL,
       BetrifftBaPerson	 = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
       NextCell          = NULL,
       BeziehungZuPerson = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name),
       NextCell          = NULL
FROM dbo.BaPerson_BaInstitution       BPI WITH (READUNCOMMITTED)
  INNER JOIN dbo.vwInstitution        INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPI.BaInstitutionID
  LEFT  JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BPI.BaPersonID
  LEFT  JOIN dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED) ON INK.BaInstitutionKontaktID = BPI.BaInstitutionKontaktID
  LEFT  JOIN dbo.BaInstitutionTyp     ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BPI.BaInstitutionTypID
WHERE BPI.BaPersonID IN (SELECT BaPersonID_1 
                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         WHERE BaPersonID_2 = @BaPersonID
                         
                         UNION ALL
                         
                         SELECT BaPersonID_2
                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         WHERE BaPersonID_1 = @BaPersonID
                         
                         UNION ALL
                         
                         SELECT @BaPersonID)
ORDER BY [Name] ASC;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenInstFachpersF', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Institutionen/Fachpersonen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 2;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenInstFachpers*
-----------------------------------------------------------

-----------------------------------------------------------
-- get relation codes and texts
-----------------------------------------------------------
SELECT DISTINCT 
       [Name]            = ISNULL(INS.NameVorname, ''''),
       NextCell          = NULL,
       Adresse           = dbo.fnGetLastFirstName(NULL, INS.StrasseHausNr, INS.PLZOrt),
       NextCell          = NULL,
       Kontaktperson     = dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname),
       NextCell          = NULL,
       TelNr             = COALESCE(INK.Telefon, INS.Telefon, INS.Telefon2, INS.Telefon3),
       NextCell          = NULL,
       BetrifftBaPerson	 = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
       NextCell          = NULL,
       BeziehungZuPerson = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name),
       NextCell          = NULL
FROM dbo.BaPerson_BaInstitution       BPI WITH (READUNCOMMITTED)
  INNER JOIN dbo.vwInstitution        INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPI.BaInstitutionID
  LEFT  JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BPI.BaPersonID
  LEFT  JOIN dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED) ON INK.BaInstitutionKontaktID = BPI.BaInstitutionKontaktID
  LEFT  JOIN dbo.BaInstitutionTyp     ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BPI.BaInstitutionTypID
WHERE BPI.BaPersonID IN (SELECT BaPersonID_1 
                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         WHERE BaPersonID_2 = @BaPersonID
                         
                         UNION ALL
                         
                         SELECT BaPersonID_2
                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         WHERE BaPersonID_1 = @BaPersonID
                         
                         UNION ALL
                         
                         SELECT @BaPersonID)
ORDER BY [Name] ASC;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenInstFachpersI', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Institutionen/Fachpersonen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 3;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenInstFachpers*
-----------------------------------------------------------

-----------------------------------------------------------
-- get relation codes and texts
-----------------------------------------------------------
SELECT DISTINCT 
       [Name]            = ISNULL(INS.NameVorname, ''''),
       NextCell          = NULL,
       Adresse           = dbo.fnGetLastFirstName(NULL, INS.StrasseHausNr, INS.PLZOrt),
       NextCell          = NULL,
       Kontaktperson     = dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname),
       NextCell          = NULL,
       TelNr             = COALESCE(INK.Telefon, INS.Telefon, INS.Telefon2, INS.Telefon3),
       NextCell          = NULL,
       BetrifftBaPerson	 = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
       NextCell          = NULL,
       BeziehungZuPerson = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name),
       NextCell          = NULL
FROM dbo.BaPerson_BaInstitution       BPI WITH (READUNCOMMITTED)
  INNER JOIN dbo.vwInstitution        INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPI.BaInstitutionID
  LEFT  JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BPI.BaPersonID
  LEFT  JOIN dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED) ON INK.BaInstitutionKontaktID = BPI.BaInstitutionKontaktID
  LEFT  JOIN dbo.BaInstitutionTyp     ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BPI.BaInstitutionTypID
WHERE BPI.BaPersonID IN (SELECT BaPersonID_1 
                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         WHERE BaPersonID_2 = @BaPersonID
                         
                         UNION ALL
                         
                         SELECT BaPersonID_2
                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         WHERE BaPersonID_1 = @BaPersonID
                         
                         UNION ALL
                         
                         SELECT @BaPersonID)
ORDER BY [Name] ASC;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenPersonenD', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Personen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;
DECLARE @ShowBirthdayInsteadOfAge BIT;

DECLARE @Relations TABLE
(
  Code INT NOT NULL,
  Text VARCHAR(255)
);

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 1;
SET @ShowBirthdayInsteadOfAge = 1;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenPersonen*
-----------------------------------------------------------

-----------------------------------------------------------
-- get relation codes and texts
-----------------------------------------------------------
-- fill temporary table
INSERT INTO @Relations
 -- generic
  SELECT Code = BaRelationID, 
         Text = dbo.fnGetMLTextByDefault(NameGenerisch1TID, @LanguageCode, NameGenerisch1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000, 
         Text = dbo.fnGetMLTextByDefault(NameGenerisch2TID, @LanguageCode, NameGenerisch2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameGenerisch1 <> NameGenerisch2
  
  UNION ALL
  
  -- male
  SELECT Code = BaRelationID + 100, 
         Text = dbo.fnGetMLTextByDefault(NameMaennlich1TID, @LanguageCode, NameMaennlich1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000 + 100, 
         Text = dbo.fnGetMLTextByDefault(NameMaennlich2TID, @LanguageCode, NameMaennlich2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameMaennlich1 <> NameMaennlich2
  
  UNION ALL
  
  -- female
  SELECT Code = BaRelationID + 200, 
         Text = dbo.fnGetMLTextByDefault(NameWeiblich1TID, @LanguageCode, NameWeiblich1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000 + 200, 
         Text = dbo.fnGetMLTextByDefault(NameWeiblich2TID, @LanguageCode, NameWeiblich2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameWeiblich1 <> NameWeiblich2

  ORDER BY Code;

-----------------------------------------------------------
-- get relations
-----------------------------------------------------------
SELECT PersonNameVorname  = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
       NextCell           = NULL,
       Beziehung          = (SELECT TOP 1 REL.Text
                             FROM @Relations REL
                             WHERE REL.Code = (BRL.BaRelationID +  
                                               CASE 
                                                 WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
                                                   THEN 1000 
                                                 ELSE 0 
                                               END +
                                               CASE PRS.GeschlechtCode 
                                                 WHEN 1 THEN 100
                                                 WHEN 2 THEN 200
                                                 ELSE 0 
                                               END)),
       NextCell           = NULL,
       ImGleichenHaushalt = dbo.fnGetYesNoMLText(dbo.fnBaGleicheAdresse(@BaPersonID, PRS.BaPersonID, 1, NULL), @LanguageCode, 1),
       NextCell           = NULL,
       AgeBDay            = CASE @ShowBirthdayInsteadOfAge
                              WHEN 1 THEN CONVERT(VARCHAR, PRS.Geburtsdatum, 104)
                              ELSE CONVERT(VARCHAR, dbo.fnGetAge(PRS.Geburtsdatum, GETDATE()))
                            END,
       NextCell           = NULL,
       Klient             = CASE 
                              WHEN EXISTS(SELECT TOP 1 1 
                                          FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                                          WHERE BaPersonID = PRS.BaPersonID) THEN dbo.fnGetYesNoMLText(1, @LanguageCode, 1)
                              ELSE dbo.fnGetYesNoMLText(0, @LanguageCode, 1)
                            END,
       NextCell           = NULL
FROM dbo.BaPerson_Relation  BRE WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID IN (BRE.BaPersonID_1, BRE.BaPersonID_2)
  LEFT  JOIN dbo.BaRelation BRL WITH (READUNCOMMITTED) ON BRL.BaRelationID = BRE.BaRelationID
WHERE (BRE.BaPersonID_1 = @BaPersonID OR BRE.BaPersonID_2 = @BaPersonID) 
  AND PRS.BaPersonID != @BaPersonID
ORDER BY (BRL.BaRelationID +  
          CASE 
            WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
              THEN 1000 
            ELSE 0 
          END +
          CASE PRS.GeschlechtCode 
            WHEN 1 THEN 100
            WHEN 2 THEN 200
            ELSE 0 
          END) ASC, AgeBDay DESC;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenPersonenF', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Personen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;
DECLARE @ShowBirthdayInsteadOfAge BIT;

DECLARE @Relations TABLE
(
  Code INT NOT NULL,
  Text VARCHAR(255)
);

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 2;
SET @ShowBirthdayInsteadOfAge = 0;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenPersonen*
-----------------------------------------------------------

-----------------------------------------------------------
-- get relation codes and texts
-----------------------------------------------------------
-- fill temporary table
INSERT INTO @Relations
 -- generic
  SELECT Code = BaRelationID, 
         Text = dbo.fnGetMLTextByDefault(NameGenerisch1TID, @LanguageCode, NameGenerisch1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000, 
         Text = dbo.fnGetMLTextByDefault(NameGenerisch2TID, @LanguageCode, NameGenerisch2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameGenerisch1 <> NameGenerisch2
  
  UNION ALL
  
  -- male
  SELECT Code = BaRelationID + 100, 
         Text = dbo.fnGetMLTextByDefault(NameMaennlich1TID, @LanguageCode, NameMaennlich1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000 + 100, 
         Text = dbo.fnGetMLTextByDefault(NameMaennlich2TID, @LanguageCode, NameMaennlich2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameMaennlich1 <> NameMaennlich2
  
  UNION ALL
  
  -- female
  SELECT Code = BaRelationID + 200, 
         Text = dbo.fnGetMLTextByDefault(NameWeiblich1TID, @LanguageCode, NameWeiblich1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000 + 200, 
         Text = dbo.fnGetMLTextByDefault(NameWeiblich2TID, @LanguageCode, NameWeiblich2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameWeiblich1 <> NameWeiblich2

  ORDER BY Code;

-----------------------------------------------------------
-- get relations
-----------------------------------------------------------
SELECT PersonNameVorname  = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
       NextCell           = NULL,
       Beziehung          = (SELECT TOP 1 REL.Text
                             FROM @Relations REL
                             WHERE REL.Code = (BRL.BaRelationID +  
                                               CASE 
                                                 WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
                                                   THEN 1000 
                                                 ELSE 0 
                                               END +
                                               CASE PRS.GeschlechtCode 
                                                 WHEN 1 THEN 100
                                                 WHEN 2 THEN 200
                                                 ELSE 0 
                                               END)),
       NextCell           = NULL,
       ImGleichenHaushalt = dbo.fnGetYesNoMLText(dbo.fnBaGleicheAdresse(@BaPersonID, PRS.BaPersonID, 1, NULL), @LanguageCode, 1),
       NextCell           = NULL,
       AgeBDay            = CASE @ShowBirthdayInsteadOfAge
                              WHEN 1 THEN CONVERT(VARCHAR, PRS.Geburtsdatum, 104)
                              ELSE CONVERT(VARCHAR, dbo.fnGetAge(PRS.Geburtsdatum, GETDATE()))
                            END,
       NextCell           = NULL,
       Klient             = CASE 
                              WHEN EXISTS(SELECT TOP 1 1 
                                          FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                                          WHERE BaPersonID = PRS.BaPersonID) THEN dbo.fnGetYesNoMLText(1, @LanguageCode, 1)
                              ELSE dbo.fnGetYesNoMLText(0, @LanguageCode, 1)
                            END,
       NextCell           = NULL
FROM dbo.BaPerson_Relation  BRE WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID IN (BRE.BaPersonID_1, BRE.BaPersonID_2)
  LEFT  JOIN dbo.BaRelation BRL WITH (READUNCOMMITTED) ON BRL.BaRelationID = BRE.BaRelationID
WHERE (BRE.BaPersonID_1 = @BaPersonID OR BRE.BaPersonID_2 = @BaPersonID) 
  AND PRS.BaPersonID != @BaPersonID
ORDER BY (BRL.BaRelationID +  
          CASE 
            WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
              THEN 1000 
            ELSE 0 
          END +
          CASE PRS.GeschlechtCode 
            WHEN 1 THEN 100
            WHEN 2 THEN 200
            ELSE 0 
          END) ASC, AgeBDay DESC;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'KLBeziehungenPersonenI', N'Klientensystem', 1, NULL, N'Textmarken für das Klientensystem - Beziehungen zu Personen', N'DECLARE @BaPersonID INT;
DECLARE @LanguageCode INT;
DECLARE @ShowBirthdayInsteadOfAge BIT;

DECLARE @Relations TABLE
(
  Code INT NOT NULL,
  Text VARCHAR(255)
);

SET @BaPersonID = {BaPersonID};
SET @LanguageCode = 3;
SET @ShowBirthdayInsteadOfAge = 0;

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any KLBeziehungenPersonen*
-----------------------------------------------------------

-----------------------------------------------------------
-- get relation codes and texts
-----------------------------------------------------------
-- fill temporary table
INSERT INTO @Relations
 -- generic
  SELECT Code = BaRelationID, 
         Text = dbo.fnGetMLTextByDefault(NameGenerisch1TID, @LanguageCode, NameGenerisch1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000, 
         Text = dbo.fnGetMLTextByDefault(NameGenerisch2TID, @LanguageCode, NameGenerisch2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameGenerisch1 <> NameGenerisch2
  
  UNION ALL
  
  -- male
  SELECT Code = BaRelationID + 100, 
         Text = dbo.fnGetMLTextByDefault(NameMaennlich1TID, @LanguageCode, NameMaennlich1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000 + 100, 
         Text = dbo.fnGetMLTextByDefault(NameMaennlich2TID, @LanguageCode, NameMaennlich2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameMaennlich1 <> NameMaennlich2
  
  UNION ALL
  
  -- female
  SELECT Code = BaRelationID + 200, 
         Text = dbo.fnGetMLTextByDefault(NameWeiblich1TID, @LanguageCode, NameWeiblich1) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)

  UNION ALL

  SELECT Code = BaRelationID + 1000 + 200, 
         Text = dbo.fnGetMLTextByDefault(NameWeiblich2TID, @LanguageCode, NameWeiblich2) 
  FROM dbo.BaRelation WITH (READUNCOMMITTED)
  WHERE NameWeiblich1 <> NameWeiblich2

  ORDER BY Code;

-----------------------------------------------------------
-- get relations
-----------------------------------------------------------
SELECT PersonNameVorname  = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
       NextCell           = NULL,
       Beziehung          = (SELECT TOP 1 REL.Text
                             FROM @Relations REL
                             WHERE REL.Code = (BRL.BaRelationID +  
                                               CASE 
                                                 WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
                                                   THEN 1000 
                                                 ELSE 0 
                                               END +
                                               CASE PRS.GeschlechtCode 
                                                 WHEN 1 THEN 100
                                                 WHEN 2 THEN 200
                                                 ELSE 0 
                                               END)),
       NextCell           = NULL,
       ImGleichenHaushalt = dbo.fnGetYesNoMLText(dbo.fnBaGleicheAdresse(@BaPersonID, PRS.BaPersonID, 1, NULL), @LanguageCode, 1),
       NextCell           = NULL,
       AgeBDay            = CASE @ShowBirthdayInsteadOfAge
                              WHEN 1 THEN CONVERT(VARCHAR, PRS.Geburtsdatum, 104)
                              ELSE CONVERT(VARCHAR, dbo.fnGetAge(PRS.Geburtsdatum, GETDATE()))
                            END,
       NextCell           = NULL,
       Klient             = CASE 
                              WHEN EXISTS(SELECT TOP 1 1 
                                          FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                                          WHERE BaPersonID = PRS.BaPersonID) THEN dbo.fnGetYesNoMLText(1, @LanguageCode, 1)
                              ELSE dbo.fnGetYesNoMLText(0, @LanguageCode, 1)
                            END,
       NextCell           = NULL
FROM dbo.BaPerson_Relation  BRE WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID IN (BRE.BaPersonID_1, BRE.BaPersonID_2)
  LEFT  JOIN dbo.BaRelation BRL WITH (READUNCOMMITTED) ON BRL.BaRelationID = BRE.BaRelationID
WHERE (BRE.BaPersonID_1 = @BaPersonID OR BRE.BaPersonID_2 = @BaPersonID) 
  AND PRS.BaPersonID != @BaPersonID
ORDER BY (BRL.BaRelationID +  
          CASE 
            WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
              THEN 1000 
            ELSE 0 
          END +
          CASE PRS.GeschlechtCode 
            WHEN 1 THEN 100
            WHEN 2 THEN 200
            ELSE 0 
          END) ASC, AgeBDay DESC;', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'MA', N'Mitarbeiter', 1, N'vwTmUser', N'Textmarken für den angemeldeten Benutzer', N'SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = {UserID}', 10, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'MADL', N'MitarbeiterDienstleistung', 1, N'vwTmUser', N'Textmarken für den Prozess-Verantwortlichen', N'-- setup vars
DECLARE @UserID INT

-- get userid from leistung
SELECT TOP 1 @UserID = UserID
FROM dbo.FaLeistung WITH (READUNCOMMITTED)
WHERE FaLeistungID = {FaLeistungID}

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 10, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'MAFV', N'MitarbeiterFallverlauf', 1, N'vwTmUser', N'Textmarken für den Fallverlauf-Verantwortlichen', N'-- setup vars
DECLARE @UserID INT

-- get userid from current fallverlauf
SELECT TOP 1 @UserID = UserID
FROM dbo.FaLeistung WITH (READUNCOMMITTED)
WHERE BaPersonID = {BaPersonID} AND ModulID = 2
ORDER BY CASE WHEN DatumBis IS NULL THEN 1 ELSE 0 END DESC, DatumVon DESC, FaLeistungID DESC

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 10, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SB', N'Sozialberatung', 1, N'vwTmSbSozialberatung', N'Textmarken für die Sozialberatung', N'SELECT <TableColumn>
FROM dbo.vwTmSbSozialberatung WITH (READUNCOMMITTED)
WHERE SbSozialberatungID = {SbSozialberatungID}', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBEvalListeD', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Evaluation - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBEvalListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 1, 0, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBEvalListeF', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Evaluation - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBEvalListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 1, 0, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBEvalListeI', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Evaluation - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBEvalListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 1, 0, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBZustaendigMA', N'Sozialberatung', 1, N'vwTmUser', N'Textmarken für die Sozialberatung - Daten aus vwTmUser für Zuständig SAR', N'-- setup vars
DECLARE @UserID INT

-- get userid from current FaSozialberatung.UserID
SELECT @UserID = LEI.UserID
FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
WHERE LEI.FaLeistungID = {FaLeistungID}

-- get values for user
SELECT <TableColumn>
FROM dbo.vwTmUser WITH (READUNCOMMITTED)
WHERE UserID = ISNULL(@UserID, -1)', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBZvListeD', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Zielvereinbarung - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBZvListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 0, 0, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBZvListeF', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Zielvereinbarung - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBZvListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 0, 0, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBZvListeI', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Zielvereinbarung - Liste der Ziele und Massnahmen', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBZvListe*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 0, 0, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBZvListeOhneEvalD', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Zielvereinbarung - Liste der Ziele und Massnahmen, ohne evaluierte Einträge', N'DECLARE @LanguageCode INT
SET @LanguageCode = 1

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBZvListeOhneEval*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 0, 1, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBZvListeOhneEvalF', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Zielvereinbarung - Liste der Ziele und Massnahmen, ohne evaluierte Einträge', N'DECLARE @LanguageCode INT
SET @LanguageCode = 2

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBZvListeOhneEval*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 0, 1, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SBZvListeOhneEvalI', N'Sozialberatung', 1, NULL, N'Textmarken für die Sozialberatung-Zielvereinbarung - Liste der Ziele und Massnahmen, ohne evaluierte Einträge', N'DECLARE @LanguageCode INT
SET @LanguageCode = 3

-----------------------------------------------------------
-- no language specific changes from here on
--   similar to any SBZvListeOhneEval*
-----------------------------------------------------------
-- setup vars
DECLARE @FaLeistungID INT

-- get shown ids
SET @FaLeistungID = ISNULL({FaLeistungID}, -1)

-- get data as defined
EXEC dbo.spFaTextmarkenSBCM @FaLeistungID, 3, 0, 1, @LanguageCode', 3, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'SIT', N'Situationsbeschreibung', 1, N'vwTmFaSituationsbeschreibung', N'Textmarken für die Situationsbeschreibung', N'SELECT <TableColumn>
FROM dbo.vwTmFaSituationsbeschreibung WITH (READUNCOMMITTED)
WHERE FaSituationsbeschreibungID = {FaSituationsbeschreibungID}', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZLEUebersicht', N'BDE', 1, N'vwTmBDEZLEUebersicht', N'Textmarken für die Übersicht der ZLE-Erfassung (ZLE-Data)
--> Benutzt Dummy-View für Spalten (vwTmBDEZLEUebersicht)', N'-- init vars
DECLARE @UserID INT
DECLARE @LanguageCode INT
DECLARE @ShownDate DATETIME
DECLARE @ColumnName VARCHAR(255)
DECLARE @ColumnDataType VARCHAR(50)

-- set vars from context
SET @UserID         = ISNULL({SelectedUserID}, -1)
SET @LanguageCode   = ISNULL({LanguageCode}, 1)
SET @ShownDate      = ISNULL({OverviewMonth}, GETDATE())
SET @ColumnName     = ISNULL(N''<TableColumn>'', '''')

-- get datatype of view-column
SELECT @ColumnDataType = TYP.name
FROM sys.views AS VEW
  INNER JOIN sys.all_columns CLM ON CLM.object_id = VEW.object_id
  LEFT OUTER JOIN sys.types  TYP  ON TYP.user_type_id = CLM.user_type_id
WHERE SCHEMA_NAME(VEW.schema_id) = N''dbo'' AND
      VEW.name = N''vwTmBDEZLEUebersicht'' AND
      CLM.name = @ColumnName

-- datatype depending handling
IF (@ColumnDataType = N''money'')
BEGIN
  -- get data rounded!
  SELECT <TableColumn> = CONVERT(DECIMAL(10, 2), <TableColumn>) -- if column is money, do round on two digits and keep them
  FROM dbo.fnBDEGetUebersicht(@UserID, dbo.fnLastDayOf(@ShownDate), @LanguageCode, 0) FCN
END
ELSE
BEGIN
  -- get data
  SELECT <TableColumn>
  FROM dbo.fnBDEGetUebersicht(@UserID, dbo.fnLastDayOf(@ShownDate), @LanguageCode, 0) FCN
END', 20, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [TableName], [Description], [SQL], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZLEUebersichtUser', N'BDE', 1, N'vwTmUser', N'Textmarken für die Übersicht der ZLE-Erfassung (SelectedUser)', N'-- init vars
DECLARE @UserID INT

-- set vars from context
SET @UserID = ISNULL({SelectedUserID}, -1)

-- get data
SELECT <TableColumn>
FROM dbo.vwTmUser USR WITH (READUNCOMMITTED)
WHERE USR.UserID = @UserID', 20, 0, 1)
GO
COMMIT
GO