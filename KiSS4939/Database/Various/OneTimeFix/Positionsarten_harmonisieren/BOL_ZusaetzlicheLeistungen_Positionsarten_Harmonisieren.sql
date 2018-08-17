BEGIN TRANSACTION

DECLARE @BgKategorieCode INT,
        @RefDateVon      DATETIME,
        @RefDateBis      DATETIME,
        @OnlyCheck       BIT;

--------------------
-- Parameter setzen
--------------------
SET @BgKategorieCode = 100; --100: Zusätzliche Leistungen
SET @RefDateVon = '20120101';
SET @RefDateBis = '20120131';
SET @OnlyCheck = 1;  --Um die Mutation durchzuführen, muss dieser Parameter auf 0 gesetzt werden


DECLARE @poaSoll TABLE(
  ID                      INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  Aktion                  VARCHAR(1),
  BgPositionsartCode_Alt  INT NOT NULL,
  BgPositionsartCode_Neu  INT,
  VarName	                VARCHAR(50),
  BgKategorieCode	        INT,
  KoAKontoNr              VARCHAR(10),
  Name_Alt   	            VARCHAR(100),
  Name_Neu	              VARCHAR(100),
  BgGruppeCodeName        VARCHAR(100),
  BgGruppeCode            INT,
  ProPerson	              BIT,
  ProUE	                  BIT,
  VerwaltungSD_Default	  BIT,
  Spezkonto	              BIT,
  DatumVon	              DATETIME,
  DatumBis	              DATETIME,
  ModulID                 INT,  
  [System]	              BIT,

  SortKey	                INT,
  Masterbudget_EditMask	  INT,
  Monatsbudget_EditMask  	INT,
  sqlRichtlinie	          VARCHAR(3000),
  Verrechenbar	          BIT,
  
  RequiresTermination     BIT DEFAULT(0),
  BgPositionsartID        INT,              --Verweis auf die IST-Positionsart, die updated wird
  TerminationResult       VARCHAR(MAX)
);

----------------------------------------------------------------------------------------------------------
-- Soll-Positionsarten definieren
-- Potentiell zu mutierende Positionsarten werden in @poaSoll erstellt, neu zu erstellende in @poaInsert
----------------------------------------------------------------------------------------------------------
-- <<start of Soll-POAs>> --
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 158, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Krankenkasse Selbstbehalt', Name_Neu = 'Krankenkasse Selbstbehalt', BgGruppeCodeName = 'Med. Grundversorgung', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 4, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 39020, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Arztrechnung', Name_Neu = 'Arztrechnung', BgGruppeCodeName = 'Krankheits- und behinderunsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 2, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 157, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Krankenkasse Franchise', Name_Neu = 'Krankenkasse Franchise', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 3, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 159, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '201', Name_Alt = 'Zahnarztrechnung', Name_Neu = 'Zahnarztrechnung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 6, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 185, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '321', Name_Alt = 'Therapeutisch/Pädagogische Integrationsmassnahmen', Name_Neu = 'Therapeutisch/Pädagogische Integrationsmassnahmen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20120101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 360, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 169, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '400', Name_Alt = 'Spitalaufenthalte', Name_Neu = 'Spitalaufenthalte', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20120101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 200, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160974, BgPositionsartCode_Neu = NULL, VarName = '15.041', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '411', Name_Alt = 'Platzk. Erw. Vollzug/Haft ES', Name_Neu = 'Platzk. Erw. Vollzug/Haft ES', BgGruppeCodeName = 'Leistungen für Therapie- und Entzugsmassnahmen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 1, DatumVon = '20120101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 7, Masterbudget_EditMask = 10224127, Monatsbudget_EditMask = 35327, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 170, BgPositionsartCode_Neu = NULL, VarName = '15.041', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '430', Name_Alt = 'Therapieaufenthalte, Alters- und Pflegeheime', Name_Neu = 'Therapieaufenthalte, Alters- und Pflegeheime', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20120101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 210, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 143, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '600', Name_Alt = 'Diverses', Name_Neu = 'Diverses', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 1, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  185, BgPositionsartCode_Neu = NULL, VarName = '10.022', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '830', Name_Alt = 'Therapeutisch/Pädagogische Integrationsmassnahmen', Name_Neu = 'Ablieferung Arbeitslosenversicherung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20111201', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 360, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  185, BgPositionsartCode_Neu = NULL, VarName = '10.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '903', Name_Alt = 'Therapeutisch/Pädagogische Integrationsmassnahmen', Name_Neu = ' Ablieferung IV-Leistungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20111201', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 360, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  185, BgPositionsartCode_Neu = NULL, VarName = '10.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '901', Name_Alt = 'Therapeutisch/Pädagogische Integrationsmassnahmen', Name_Neu = 'Ablieferung Sozialversicherungsleistungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20111201', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 360, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  185, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Therapeutisch/Pädagogische Integrationsmassnahmen', Name_Neu = 'Durchlauf Fremdgeld', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 360, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;

-- <<end of Soll-POAs>> --
-------------------------------------------------------------------
--Tasks ermitteln, was mit den Positionsarten gemacht werden muss
-------------------------------------------------------------------
UPDATE POAS
  SET BgGruppeCode = GRC.Code,
      BgPositionsartID = POAI.BgPositionsartID
FROM @poaSoll POAS
  INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartCode = POAS.BgPositionsartCode_Alt
                               AND IsNull(POAI.DatumVon, @RefDateVon) <= @RefDateVon 
                               AND IsNull(POAI.DatumBis, @RefDateBis) >= @RefDateBis
  CROSS APPLY (SELECT TOP 1 Code 
               FROM XLOVCode COD
               WHERE COD.LOVName = 'BgGruppe'                               
                 AND ((COD.Code = POAI.BgGruppeCode 
                        AND COD.Text = POAS.BgGruppeCodeName)
                      OR (COD.Text = POAS.BgGruppeCodeName))
               ORDER BY CASE WHEN COD.Code = POAI.BgGruppeCode AND COD.Text = POAS.BgGruppeCodeName THEN 1
                             ELSE 2
                        END) GRC;

--Benötigt die Mutation eine Terminierung der Positionsart?
UPDATE POAS
  SET RequiresTermination = CASE WHEN KOA.KontoNr <> POAS.KoAKontoNr THEN 1    --wenn die Kostenart ändert
                                  WHEN POAS.BgGruppeCode <> POAI.BgGruppeCode THEN 1  --wenn die Gruppe ändert
                                  ELSE 0
                             END
FROM @poaSoll POAS
  INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartCode = POAS.BgPositionsartCode_Alt
                               AND IsNull(POAI.DatumVon, @RefDateVon) <= @RefDateVon 
                               AND IsNull(POAI.DatumBis, @RefDateBis) >= @RefDateBis
  INNER JOIN BgKostenart KOA ON KOA.BgKostenartID = POAI.BgKostenartID
WHERE POAS.Aktion = 'U';                             

-------------------------------------------------------------------
--Perform Checks
-------------------------------------------------------------------
--1. Welche Positionsarten gibt es in der DB, die nicht in @poaSoll existieren
SELECT 'PoAs in DB, die nicht im Excel existieren', [Code]=POAI.BgPositionsartCode, [Name]=POAI.Name, * 
FROM BgPositionsart POAI
  INNER JOIN BgKostenart_WhGefKategorie KGK ON KGK.BgKostenartID = POAI.BgKostenartID  --nur PoAs auf KoAs mit GEF-Mapping
WHERE POAI.BgKategorieCode = @BgKategorieCode
  AND ModulID = 3  --SH-Modul
  AND IsNull(POAI.DatumVon, @RefDateVon) <= @RefDateVon --nur Positionsarten, die am RefDate gültig sind
  AND IsNull(POAI.DatumBis, @RefDateBis) >= @RefDateBis
  AND NOT EXISTS (SELECT TOP 1 1 FROM @poaSoll POAS WHERE POAS.BgPositionsartCode_Alt = POAI.BgPositionsartCode)

--2. Welche Positionsarten gibt es in @poaSoll, die nicht in der DB existieren
SELECT 'PoAs im Excel, die nicht in der DB existieren', [Code]=POAS.BgPositionsartCode_Alt, POAS.Aktion
FROM @poaSoll POAS
WHERE NOT EXISTS (SELECT TOP 1 1 FROM BgPositionsart POAI WHERE POAS.BgPositionsartCode_Alt = POAI.BgPositionsartCode)

--3. Welche Positionsarten heissen zwar gleich, haben aber unterschiedliche BgPositionsartCodes --> mapping falsch?
SELECT 'PoAs mit gleichem Namen, unerschiedliche BgPositionsartCodes', [S:Code]=POAS.BgPositionsartCode_Alt, [I:Code]=POAI.BgPositionsartCode, [Name_Alt]=POAS.Name_Alt, *
FROM BgPositionsart POAI
  INNER JOIN @poaSoll POAS ON POAS.Name_Alt = POAI.Name
                          AND POAS.BgGruppeCode = POAI.BgGruppeCode
WHERE POAI.BgPositionsartCode <> POAS.BgPositionsartCode_Alt
  AND IsNull(POAS.Name_Alt, '') <> ''
  AND IsNull(POAI.Name, '') <> ''
  
--4. Können alle zu terminierenden Positionsarten auf das gewünschte Datum terminiert werden? (für Aktion:D und Aktion:U mit @RequiresTermination)
-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @poaSollID INT,
        @BgPositionsartID INT,
        @DatumBis DATETIME,
        @NachfolgePoAID INT;

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  PoaSollID INT,
  BgPositionsartID INT,
  DatumBis DATETIME,
  NachfolgePoAID INT
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (PoaSollID, BgPositionsartID, DatumBis, NachfolgePoAID)
  SELECT POAS.ID, POAS.BgPositionsartID, POAS.DatumBis, NULL
  FROM @poaSoll POAS 
  WHERE POAS.Aktion = 'D'
  
  UNION ALL
  SELECT POAS.ID, POAS.BgPositionsartID, CONVERT(DATETIME, dbo.fnMAX(DATEADD(day, -1, IsNull(POAS.DatumVon, @RefDateVon)), @RefDateBis)), -1
  FROM @poaSoll POAS 
  WHERE POAS.Aktion = 'U'
    AND POAs.RequiresTermination = 1;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @PoaSollID = TMP.PoaSollID,
         @BgPositionsartID = TMP.BgPositionsartID,
         @DatumBis         = TMP.DatumBis,
         @NachfolgePoAID   = TMP.NachfolgePoAID
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  BEGIN TRY
    EXEC dbo.spWhPositionsart_Terminieren @BgPositionsartID, @DatumBis, @NachfolgePoAID, 1  --1: PreviewMode  
  END TRY
  BEGIN CATCH
    UPDATE @poaSoll
      SET TerminationResult = ERROR_MESSAGE()
    WHERE ID = @PoaSollID
  END CATCH
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

SELECT 'DatumBis ungültig', TerminationResult, * FROM @poaSoll WHERE TerminationResult IS NOT NULL;
  
--5. Gegenüberstellung Einzufügende Positionsart und ihr "copy of" (woher die weiteren Daten wie EditMask... kommen)
SELECT 'neue PoAs / copy_of', [S:Code]=POAS.BgPositionsartCode_Alt, [S:Name_Neu]=POAS.Name_Neu, *
FROM @poaSoll POAS 
  INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartCode = POAS.BgPositionsartCode_Alt
                                AND IsNull(POAI.DatumVon, @RefDateVon) <= @RefDateVon
                                AND IsNull(POAI.DatumBis, @RefDateBis) >= @RefDateBis
WHERE POAS.Aktion = 'I'

--5. Gegenüberstellung Soll / Ist aufgrund BgPositionsartCode
SELECT 
       -- Soll
       [Aktion]          = POAS.Aktion,
       [S:BFS-Variable]  = POAS.VarName, 
       [S:Bedag-Code]    = ISNULL(POAS.BgPositionsartCode_Neu, POAS.BgPositionsartCode_Alt), 
       [S:KoA]           = POAS.KoAKontoNr, 
       [S:Name]          = POAS.Name_Neu, 
       [S:Gruppe]        = POAS.BgGruppeCodeName, 
       [S:Pro Pers.]     = POAS.ProPerson, 
       [S:Pro UE]        = POAS.ProUE, 
       [S:Verw. SD]      = POAS.VerwaltungSD_Default, 
       [S:Spezialk.]     = POAS.Spezkonto, 
       [S:Datum Von]     = POAS.DatumVon, 
       [S:Datum Bis]     = POAS.DatumBis,

       [ ]               = ' ',

       -- Ist
       [I:BFS-Variable]  = POAI.VarName, 
       [I:Code]          = POAI.BgPositionsartCode, 
       [I:KoA]           = KOA.KontoNr, 
       [I:Name]          = POAI.Name, 
       [I:Gruppe]        = GRC.Text, 
       [I:Pro Pers.]     = POAI.ProPerson, 
       [I:Pro UE]        = POAI.ProUE, 
       [I:Verw. SD]      = POAI.VerwaltungSD_Default, 
       [I:Spezialk.]     = POAI.Spezkonto, 
       [I:Datum Von]     = POAI.DatumVon, 
       [I:Datum Bis]     = POAI.DatumBis
       
FROM @poaSoll POAS
  LEFT  JOIN BgPositionsart POAI ON POAI.BgPositionsartCode = POAS.BgPositionsartCode_Alt
                                AND IsNull(POAI.DatumVon, @RefDateVon) <= @RefDateVon
                                AND IsNull(POAI.DatumBis, @RefDateBis) >= @RefDateBis
                                AND POAS.Aktion <> 'I'  --für 'I' kein IST-Zustand anzeigen
  LEFT  JOIN BgKostenart KOA ON KOA.BgKostenartID = POAI.BgKostenartID
  LEFT  JOIN XLOVCode GRC ON GRC.Code = POAI.BgGruppeCode
                         AND GRC.LOVName = 'BgGruppe'
ORDER BY POAS.KoAKontoNr, POAS.BgGruppeCodeName

------------------------------------------------------------------------------------------------------------
--Prerequisite: Es darf keine Probleme in TerminationResult haben
------------------------------------------------------------------------------------------------------------
IF EXISTS (SELECT TOP 1 1 FROM @poaSoll WHERE TerminationResult IS NOT NULL)
BEGIN
  SELECT 'Prerequisite: Es darf keine Probleme in TerminationResult haben';
  RETURN;
END

-------------------------------------------------------------------
--Perform Changes
-------------------------------------------------------------------
IF (@OnlyCheck = 1)
BEGIN
  RETURN;
END;


-- 1. Backup-Kopie erstellen _Old_BgPositionsart
IF NOT EXISTS(SELECT TOP 1 1
              FROM sys.tables T
              WHERE name = '_Old_BgPositionsart')
BEGIN
  SELECT * INTO _Old_BgPositionsart FROM BgPositionsart;
END;
 
-- 2. Positionsarten erstellen
INSERT INTO BgPositionsart (BgKategorieCode, BgGruppeCode, Name, SortKey, BgKostenartID, 
  VerwaltungSD_Default, Spezkonto, ProPerson, ProUE, Masterbudget_EditMask, Monatsbudget_EditMask, ModulID, sqlRichtlinie,
  VarName, Verrechenbar, DatumVon, DatumBis, BgPositionsartCode, System, 
  KreditorEingeschraenkt)
SELECT POAS.BgKategorieCode, POAS.BgGruppeCode, POAS.Name_Neu, POAS.SortKey, KOA.BgKostenartID, 
  POAS.VerwaltungSD_Default, POAS.Spezkonto, POAS.ProPerson, POAS.ProUE, POAS.Masterbudget_EditMask, POAS.Monatsbudget_EditMask, POAS.ModulID, POAS.sqlRichtlinie,
  POAS.VarName, POAS.Verrechenbar, POAS.DatumVon, POAS.DatumBis, POAS.BgPositionsartCode_Neu, POAS.System, 
  KreditorEingeschraenkt = CASE WHEN GEF.WhGefKategorieCode IS NOT NULL AND GEF.WhGefKategorieCode IN (10, 11) THEN 1 ELSE 0 END
FROM @poaSoll POAS
  INNER JOIN BgKostenart KOA ON KOA.KontoNr = POAS.KoAKontoNr
  LEFT  JOIN BgKostenart_WhGefKategorie KGK ON KGK.BgKostenartID = KOA.BgKostenartID
  LEFT  JOIN WhGefKategorie GEF ON GEF.WhGefKategorieID = KGK.WhGefKategorieID
WHERE POAS.Aktion = 'I';

PRINT (CONVERT(VARCHAR(20), @@ROWCOUNT) + ' Positionsarten neu erstellt.');

-- 3. Positionsarten anpassen (wo keine Terminierung nötig ist)
UPDATE POAI
  SET POAI.VarName = POAS.VarName,
      POAI.Name = POAS.Name_Neu,
      POAI.ProPerson = POAS.ProPerson,
      POAI.ProUE = POAS.ProUE,
      POAI.VerwaltungSD_Default = POAS.VerwaltungSD_Default,
      POAI.Spezkonto = POAS.Spezkonto
FROM @poaSoll POAS
  INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartCode = POAS.BgPositionsartCode_Alt
                                AND IsNull(POAI.DatumVon, @RefDateVon) <= @RefDateVon 
                                AND IsNull(POAI.DatumBis, @RefDateBis) >= @RefDateBis
WHERE POAS.Aktion = 'U'
  AND POAS.RequiresTermination = 0
  
PRINT (CONVERT(VARCHAR(20), @@ROWCOUNT) + ' Positionsarten mutiert (ohne Terminierung).');
  
-- 4. Positionsarten anpassen (wo Terminierung nötig ist) und Positionsarten terminieren
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @PoaSollID = TMP.PoaSollID,
         @BgPositionsartID = TMP.BgPositionsartID,
         @DatumBis         = TMP.DatumBis,
         @NachfolgePoAID   = TMP.NachfolgePoAID
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  IF (@NachfolgePoAID IS NOT NULL)
  BEGIN
    --Nachfolge Positionsart erstellen
    INSERT INTO BgPositionsart (BgKategorieCode, BgGruppeCode, Name, HilfeText, SortKey, BgKostenartID, NrmKontoCode, VerwaltungSD_Default, Spezkonto, ProPerson,
      ProUE, Masterbudget_EditMask, Monatsbudget_EditMask, ModulID, sqlRichtlinie, VarName, Verrechenbar, Bemerkung, NameTID, DatumVon, BgPositionsartCode, 
      BgPositionsartID_CopyOf, System, 
      KreditorEingeschraenkt)
    SELECT POAS.BgKategorieCode, POAS.BgGruppeCode, POAS.Name_Neu, POAI.HilfeText, POAS.SortKey, KOA.BgKostenartID, POAI.NrmKontoCode, POAS.VerwaltungSD_Default, POAS.Spezkonto, POAS.ProPerson,
      POAS.ProUE, POAS.Masterbudget_EditMask, POAS.Monatsbudget_EditMask, POAS.ModulID, POAS.sqlRichtlinie, POAS.VarName, POAS.Verrechenbar, POAI.Bemerkung, POAI.NameTID, @RefDateVon, ISNULL(POAS.BgPositionsartCode_Neu, POAS.BgPositionsartCode_Alt), 
      POAI.BgPositionsartID, POAS.System, 
      KreditorEingeschraenkt = CASE WHEN GEF.WhGefKategorieCode IS NOT NULL AND GEF.WhGefKategorieCode IN (10, 11) THEN 1 ELSE 0 END
    FROM @poaSoll POAS
      INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = @BgPositionsartID
      INNER JOIN BgKostenart KOA ON KOA.KontoNr = POAS.KoAKontoNr
      LEFT  JOIN BgKostenart_WhGefKategorie KGK ON KGK.BgKostenartID = KOA.BgKostenartID
      LEFT  JOIN WhGefKategorie GEF ON GEF.WhGefKategorieID = KGK.WhGefKategorieID
    WHERE POAS.ID = @PoaSollID

    SET @NachfolgePoAID = SCOPE_IDENTITY();
  END
  
  BEGIN TRY
    EXEC dbo.spWhPositionsart_Terminieren @BgPositionsartID, @DatumBis, @NachfolgePoAID, 0  --0: No Preview
  END TRY
  BEGIN CATCH
    UPDATE @poaSoll
      SET TerminationResult = ERROR_MESSAGE()
    WHERE ID = @PoaSollID
  END CATCH
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-- 5. Bedag-PositionsartCode setzen
UPDATE POA
  SET BgPositionsartCode = BgPositionsartID
FROM dbo.BgPositionsart POA
WHERE POA.BgPositionsartCode IS NULL;

UPDATE POA
  SET BgPositionsartCode = POAS.BgPositionsartCode_Neu
FROM dbo.BgPositionsart POA
  INNER JOIN @poaSoll POAS ON POAS.BgPositionsartCode_Neu IS NOT NULL
                          AND POAS.BgPositionsartCode_Neu <> POAS.BgPositionsartCode_Alt
                          AND POAS.BgPositionsartCode_Alt = POA.BgPositionsartCode
                          AND POAS.Aktion <> 'I'
WHERE NOT EXISTS(SELECT TOP 1 1
                 FROM dbo.BgPositionsart POA2 WITH (READUNCOMMITTED)
                 WHERE POA2.BgPositionsartID = POAS.BgPositionsartCode_Neu)

--COMMIT
--rollback