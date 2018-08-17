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
SET @RefDateBis = '20111231';
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
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 146, BgPositionsartCode_Neu = NULL, VarName = '15.0413', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'ordentlicher Grundbedarf bei Wochenaufenthalt Kind', Name_Neu = 'ordentlicher Grundbedarf bei Wochenaufenthalt Kind', BgGruppeCodeName = 'Grundbedarf', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 10, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 147, BgPositionsartCode_Neu = NULL, VarName = '15.0413', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'zusätzlicher Grundbedarf', Name_Neu = 'zusätzlicher Grundbedarf', BgGruppeCodeName = 'Grundbedarf', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 20, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 148, BgPositionsartCode_Neu = NULL, VarName = '15.0413', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'Teuerungsausgleich', Name_Neu = 'Teuerungsausgleich', BgGruppeCodeName = 'Grundbedarf', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 25, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 150, BgPositionsartCode_Neu = NULL, VarName = '15.0404', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '110', Name_Alt = 'Nachzahlung Miete', Name_Neu = 'Nachzahlung Miete', BgGruppeCodeName = 'Wohnkosten', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 40, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 152, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '530', Name_Alt = 'KVG-Prämien rückwirkende', Name_Neu = 'KVG-Prämien rückwirkende', BgGruppeCodeName = 'Med. Grundversorgung', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 60, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 0;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 153, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '530', Name_Alt = 'KVG-Prämien zusätzlich', Name_Neu = 'KVG-Prämien zusätzlich', BgGruppeCodeName = 'Med. Grundversorgung', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 70, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 0;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 157, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Krankenkasse Franchise', Name_Neu = 'Krankenkasse Franchise', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 90, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 158, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Krankenkasse Selbstbehalt', Name_Neu = 'Krankenkasse Selbstbehalt', BgGruppeCodeName = 'Med. Grundversorgung', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 100, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 159, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '201', Name_Alt = 'Zahnarztrechnung', Name_Neu = 'Zahnarzt', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 110, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Spitex/hauswirtschaftliche Leistungen', Name_Neu = 'Spitex/hauswirtschaftliche Leistungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 112, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 161, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '521', Name_Alt = 'Hausrat/Haftpflichtversicherung', Name_Neu = 'Hausrat- und Haftpflichtversicherung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 120, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 0;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 162, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Umzugskosten', Name_Neu = 'Umzugskosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 130, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 163, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Reinigungskosten', Name_Neu = 'Reinigungs- und Entsorgungskosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 140, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 164, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Mobiliaranschaffung', Name_Neu = 'Mobiliaranschaffung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 150, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 165, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Reparaturen', Name_Neu = 'Reparaturen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 160, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 166, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Brille, Brillengestell', Name_Neu = 'Brille, Brillengestell', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 170, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 167, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Feste', Name_Neu = 'Feste', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = '20131231', ModulID = 3, [System] = 0, SortKey = 180, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 168, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Weihnachtspauschale', Name_Neu = 'Weihnachtspauschale', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 190, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 169, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '400', Name_Alt = 'Spitalaufenthalte', Name_Neu = 'Spitalaufenthalte', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 200, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 170, BgPositionsartCode_Neu = NULL, VarName = '15.041', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '430', Name_Alt = 'Therapieaufenthalte, Alters- und Pflegeheime', Name_Neu = 'Therapieaufenthalte, Alters- und Pflegeheime', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 210, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 172, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Mitgliederbeiträge', Name_Neu = 'Mitgliederbeiträge', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 230, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 174, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Verhütung', Name_Neu = 'Verhütung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 260, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 175, BgPositionsartCode_Neu = NULL, VarName = '15.0418', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Zusätzliche Verkehrskosten', Name_Neu = 'Zusätzliche Verkehrskosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 270, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 176, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Kurse (ohne Deutschkurse)', Name_Neu = 'Kurse (ohne Deutschkurse)', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 280, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 177, BgPositionsartCode_Neu = NULL, VarName = '15.0409', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Lager', Name_Neu = 'Lager', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 290, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 178, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Ausweisverlängerung/Pässe', Name_Neu = 'Persönliche Dokumente z.B. Pässe, Ausweise usw.', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 300, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 179, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '522', Name_Alt = 'AHV-Mindestbeiträge (rückwirkende)', Name_Neu = 'AHV-Mindestbeiträge (rückwirkende)', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 310, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 0;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 180, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '522', Name_Alt = 'AHV-Mindestbeiträge (laufende)', Name_Neu = 'AHV-Mindestbeiträge (laufende)', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 320, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 0;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 181, BgPositionsartCode_Neu = NULL, VarName = '15.0408', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Familienerg. Kinderbetreuung: Einmalig', Name_Neu = 'Familienergänzende Kinderbetreuung ', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 330, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 183, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '600', Name_Alt = 'Ablieferungen', Name_Neu = 'Ablieferungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = '20140131', ModulID = 3, [System] = 0, SortKey = 340, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 184, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '320', Name_Alt = 'Abklärungsmodule KA für berufliche Integ', Name_Neu = 'Abklärungsmodule KA für berufliche Integ', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = '20140131', ModulID = 3, [System] = 0, SortKey = 350, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 186, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Übersetzungskosten', Name_Neu = 'Übersetzungskosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 1000, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 39020, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Arztrechnung', Name_Neu = 'Arzt / Medikamente', BgGruppeCodeName = 'Krankheits- und behinderunsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 80, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60923, BgPositionsartCode_Neu = NULL, VarName = '10.232', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '101', Name_Alt = 'Zulagen / EFB', Name_Neu = 'IZU', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60959, BgPositionsartCode_Neu = NULL, VarName = '12.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Spesen', Name_Neu = 'Spesen Mandatsträger', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 380, Masterbudget_EditMask = 10448896, Monatsbudget_EditMask = 35327, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60960, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Durchreisende Reisespesen', Name_Neu = 'Reisespesen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 390, Masterbudget_EditMask = 10448896, Monatsbudget_EditMask = 35327, sqlRichtlinie = NULL, Verrechenbar = 0;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60967, BgPositionsartCode_Neu = NULL, VarName = 'NULL', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Deutsch-Kurse', Name_Neu = 'Deutsch-Kurse', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 281, Masterbudget_EditMask = 10448896, Monatsbudget_EditMask = 35327, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 149, BgPositionsartCode_Neu = NULL, VarName = '15.0404', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '111', Name_Alt = 'Jahres-Mietnebenkosten (inkl. Cablecom)', Name_Neu = 'Mietnebenkosten', BgGruppeCodeName = 'Wohnkosten', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 30, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 185, BgPositionsartCode_Neu = NULL, VarName = '15.041', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '321', Name_Alt = 'Therapeutisch/Pädagogische Integrationsmassnahmen', Name_Neu = 'Therapeutisch/Pädagogische Integrationsmassnahmen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = '20140228', ModulID = 3, [System] = 0, SortKey = 360, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 61028, BgPositionsartCode_Neu = NULL, VarName = '15.041', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '411', Name_Alt = 'Platzk. Erw. Vollzug/Haft ES', Name_Neu = 'Platzk. Erw. Vollzug/Haft ES', BgGruppeCodeName = 'Leistungen für Therapie- und Entzugsmassnahmen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 1, DatumVon = '20110101', DatumBis = '20131231', ModulID = 3, [System] = 1, SortKey = 7, Masterbudget_EditMask = 10224127, Monatsbudget_EditMask = 35327, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 187, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Nicht-pflichtige Medizinalkosten', Name_Neu = 'Nicht-pflichtige Medizinalkosten', BgGruppeCodeName = 'Krankheits- und behinderunsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 80, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 188, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'Abzahlungsvereinbarung', Name_Neu = 'Abzahlungsvereinbarung', BgGruppeCodeName = 'Rückerstattungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 100, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '102', Name_Alt = 'Zulagen / EFB', Name_Neu = 'VVG ', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '103', Name_Alt = 'Zulagen / EFB', Name_Neu = 'MIZ', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '10.232', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '105', Name_Alt = 'Zulagen / EFB', Name_Neu = 'EFB', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '15.0418', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '107', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Auswärtige Verpflegung ', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  176, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Kurse (ohne Deutschkurse)', Name_Neu = 'Schule, Aus- und Weiterbildung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 280, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  176, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Kurse (ohne Deutschkurse)', Name_Neu = 'Aufgabenhilfe', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 280, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  162, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Umzugskosten', Name_Neu = 'Einlagerung Mobiliar', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 130, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  164, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Mobiliaranschaffung', Name_Neu = 'Elektronische Medien', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 150, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  164, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Mobiliaranschaffung', Name_Neu = 'Kosten für Fahrzeuge', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 150, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  164, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Mobiliaranschaffung', Name_Neu = 'Arbeitsuntensilien', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 150, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '700', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Persönliche Rückerstattungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '701', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Rückerstattungen aus Erbschaften', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '730', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Krankenkassen- und UVG-Leistungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '731', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Taggelder KVG / VVG / UVG', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '740', Name_Alt = 'Zulagen / EFB', Name_Neu = 'BVG, Lebensversicherung, 3. Säule', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '750', Name_Alt = 'Zulagen / EFB', Name_Neu = 'SUVA-Rente', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = 90035, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '830', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Arbeitslosenversicherung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '840', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Stipendien', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Übrige Einnahmen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '851', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Lohneinnahmen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '854', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Kinderzulagen Arbeitgeber', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '855', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Kinderzulagen Nichterwerbstätige ', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '900', Name_Alt = 'Zulagen / EFB', Name_Neu = 'AHV-Renten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = 90037, VarName = '12.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '901', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Ergänzungsleistungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '10.062', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '902', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Hilflosenentschädigung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = 90036, VarName = '10.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '903', Name_Alt = 'Zulagen / EFB', Name_Neu = 'IV-Renten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '-', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '904', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Sozialversicherungsleistungen POM u. and. kant. Behörden', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '10.102', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '905', Name_Alt = 'Zulagen / EFB', Name_Neu = 'IV-Taggeld', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '12.142', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '906', Name_Alt = 'Zulagen / EFB', Name_Neu = 'Fonds', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  60923, BgPositionsartCode_Neu = NULL, VarName = '10.062', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '907', Name_Alt = 'Zulagen / EFB', Name_Neu = 'EL-Krankheitskosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20140101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 370, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;





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