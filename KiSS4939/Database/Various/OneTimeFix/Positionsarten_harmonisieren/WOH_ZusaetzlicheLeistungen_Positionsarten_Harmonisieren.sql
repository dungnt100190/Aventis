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
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160921, BgPositionsartCode_Neu = NULL, VarName = '15.0413', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'Entschädigung Besuchsrecht Unterhalt', Name_Neu = 'Entschädigung Besuchsrecht Unterhalt', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 6, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 156, BgPositionsartCode_Neu = 156, VarName = '15.0413', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'Freie Verfügung 13.Monatslohn, Gratifika', Name_Neu = 'Freie Verfügung 13.Monatslohn, Gratifika', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 34, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 147, BgPositionsartCode_Neu = 147, VarName = '15.0413', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'Grundbedarf für Lebensunterhalt', Name_Neu = 'Grundbedarf für Lebensunterhalt', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 17, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160949, BgPositionsartCode_Neu = NULL, VarName = '15.0413', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '100', Name_Alt = 'Lebensunterhalt aus GB stat. Aufenthalt', Name_Neu = 'Lebensunterhalt aus GB stat. Aufenthalt', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 101, Masterbudget_EditMask = 10481664, Monatsbudget_EditMask = 2559, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160932, BgPositionsartCode_Neu = NULL, VarName = '15.0404', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '110', Name_Alt = 'Erstmalige Zahlung Mietkautionsversicher', Name_Neu = 'Erstmalige Zahlung Mietkautionsversicher', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 27, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 149, BgPositionsartCode_Neu = 149, VarName = '15.0404', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '111', Name_Alt = 'Heiz- und Nebenkosten', Name_Neu = 'Heiz- und Nebenkosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20120201', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 19, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100150, BgPositionsartCode_Neu = 100150, VarName = '15.0404', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '110', Name_Alt = 'Wohnkosten (ohne NK)', Name_Neu = 'Wohnkosten (ohne NK)', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 41, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 39020, BgPositionsartCode_Neu = 39020, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Arztrechnung', Name_Neu = 'Arztrechnung', BgGruppeCodeName = 'Krankheits- und behinderunsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 80, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100152, BgPositionsartCode_Neu = 100152, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '200', Name_Alt = 'Selbstbehalte/Franchisen', Name_Neu = 'Selbstbehalte/Franchisen', BgGruppeCodeName = 'Einmalige Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 46, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100130, BgPositionsartCode_Neu = 100130, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '201', Name_Alt = 'Zahnarzt - Dentalhygiene', Name_Neu = 'Zahnarzt - Dentalhygiene', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110201', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 47, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160934, BgPositionsartCode_Neu = NULL, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '201', Name_Alt = 'Zahnarzt - KV Kieferorthopädie', Name_Neu = 'Zahnarzt - KV Kieferorthopädie', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 45, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100146, BgPositionsartCode_Neu = 100146, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '201', Name_Alt = 'Zahnarzt - Vertrauenszahnarzt negativ', Name_Neu = 'Zahnarzt - Vertrauenszahnarzt negativ', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 44, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100145, BgPositionsartCode_Neu = 100145, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '201', Name_Alt = 'Zahnarzt - Vertrauenszahnarzt positiv', Name_Neu = 'Zahnarzt - Vertrauenszahnarzt positiv', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 43, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 159, BgPositionsartCode_Neu = 159, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '201', Name_Alt = 'Zahnarzt Kosten', Name_Neu = 'Zahnarzt Kosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 42, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 169, BgPositionsartCode_Neu = 169, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '400', Name_Alt = 'Spitalaufenthalte', Name_Neu = 'Spitalaufenthalte', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 200, Masterbudget_EditMask = 2060288, Monatsbudget_EditMask = 33279, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160930, BgPositionsartCode_Neu = NULL, VarName = '10.222', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '101', Name_Alt = 'IZU %', Name_Neu = 'IZU %', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 22, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160929, BgPositionsartCode_Neu = NULL, VarName = '10.222', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '101', Name_Alt = 'IZU Alleinerziehende', Name_Neu = 'IZU Alleinerziehende', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 21, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160931, BgPositionsartCode_Neu = NULL, VarName = '10.222', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '101', Name_Alt = 'IZU Auszubildende', Name_Neu = 'IZU Auszubildende', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 23, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160928, BgPositionsartCode_Neu = NULL, VarName = '10.222', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '101', Name_Alt = 'IZU Betrag', Name_Neu = 'IZU Betrag', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 20, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160933, BgPositionsartCode_Neu = NULL, VarName = '10.212', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '101', Name_Alt = 'MIZ Minimale Integrationszulage', Name_Neu = 'MIZ Minimale Integrationszulage', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 28, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60927, BgPositionsartCode_Neu = 60927, VarName = '10.232', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '105', Name_Alt = 'EFB', Name_Neu = 'EFB', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110601', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 13, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160926, BgPositionsartCode_Neu = NULL, VarName = '10.232', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '105', Name_Alt = 'EFB - Erwerbsaufnahme', Name_Neu = 'EFB - Erwerbsaufnahme', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110601', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 12, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160935, BgPositionsartCode_Neu = NULL, VarName = '10.232', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '105', Name_Alt = 'Freibetrag einmalige Arbeitseinsätze', Name_Neu = 'Freibetrag einmalige Arbeitseinsätze', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110601', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 14, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160914, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Autosteuern', Name_Neu = 'Autosteuern', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 4, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160913, BgPositionsartCode_Neu = NULL, VarName = '13.012', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Autoversicherung', Name_Neu = 'Autoversicherung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 3, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100158, BgPositionsartCode_Neu = 100158, VarName = '15.0418', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Effektive Erwerbsunkosten', Name_Neu = 'Effektive Erwerbsunkosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 15, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160922, BgPositionsartCode_Neu = NULL, VarName = '15.0409', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Einschreibe-/Semestergebühren', Name_Neu = 'Einschreibe-/Semestergebühren', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 7, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100139, BgPositionsartCode_Neu = 100139, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Ersatzanschaffung Mobiliar', Name_Neu = 'Ersatzanschaffung Mobiliar', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 33, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100135, BgPositionsartCode_Neu = 100135, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Erstausstattung Mobiliar 1 Person', Name_Neu = 'Erstausstattung Mobiliar 1 Person', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 29, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100136, BgPositionsartCode_Neu = 100136, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Erstausstattung Mobiliar 2 Personen', Name_Neu = 'Erstausstattung Mobiliar 2 Personen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 30, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100137, BgPositionsartCode_Neu = 100137, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Erstausstattung Mobiliar 3 Personen', Name_Neu = 'Erstausstattung Mobiliar 3 Personen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 31, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100138, BgPositionsartCode_Neu = 100138, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Erstausstattung Mobiliar 4+mehr Personen', Name_Neu = 'Erstausstattung Mobiliar 4+mehr Personen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 32, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160917, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Gebühren für Ausweispapiere', Name_Neu = 'Gebühren für Ausweispapiere', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 16, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100133, BgPositionsartCode_Neu = 100133, VarName = '15.0408', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Kindertagesbetreuung', Name_Neu = 'Kindertagesbetreuung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 24, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 166, BgPositionsartCode_Neu = 166, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Kosten für Sehhilfen', Name_Neu = 'Kosten für Sehhilfen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110601', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 11, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160925, BgPositionsartCode_Neu = NULL, VarName = '15.0409', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Nachhilfe- und Spezialunterricht', Name_Neu = 'Nachhilfe- und Spezialunterricht', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 10, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160923, BgPositionsartCode_Neu = NULL, VarName = '15.0409', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Prüfungskosten', Name_Neu = 'Prüfungskosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 8, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100155, BgPositionsartCode_Neu = NULL, VarName = '15.0409', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Schullagerkosten', Name_Neu = 'Schullagerkosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 35, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160924, BgPositionsartCode_Neu = NULL, VarName = '15.0409', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Schulmaterialkosten', Name_Neu = 'Schulmaterialkosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 9, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 165, BgPositionsartCode_Neu = 165, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Service- und Reperaturkosten (Auto)', Name_Neu = 'Service- und Reperaturkosten (Auto)', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 5, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160950, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Übersetzungskosten', Name_Neu = 'Übersetzungskosten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110501', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 102, Masterbudget_EditMask = 10481664, Monatsbudget_EditMask = 2559, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100140, BgPositionsartCode_Neu = 100140, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Umzugkosten für 1 Person', Name_Neu = 'Umzugkosten für 1 Person', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 36, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100141, BgPositionsartCode_Neu = 100141, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Umzugkosten für 2 Personen', Name_Neu = 'Umzugkosten für 2 Personen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 37, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100142, BgPositionsartCode_Neu = 100142, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Umzugkosten für 3 Personen', Name_Neu = 'Umzugkosten für 3 Personen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 38, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100143, BgPositionsartCode_Neu = 100143, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Umzugkosten für 4+mehr Personen', Name_Neu = 'Umzugkosten für 4+mehr Personen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 39, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 160912, BgPositionsartCode_Neu = NULL, VarName = '15.0407', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Unkosten für Arbeitsbemühungen', Name_Neu = 'Unkosten für Arbeitsbemühungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 2, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100149, BgPositionsartCode_Neu = 100149, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Zusatzversicherung VVG', Name_Neu = 'Zusatzversicherung VVG', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 26, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100154, BgPositionsartCode_Neu = 100154, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Nicht geregelte ESIL', Name_Neu = 'Nicht geregelte ESIL', BgGruppeCodeName = 'Einmalige Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 48, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 161047, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '520', Name_Alt = 'Freizeitaktivitäten', Name_Neu = 'Freizeitaktivitäten', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110401', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 36, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 161, BgPositionsartCode_Neu = 161, VarName = '13.012', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '521', Name_Alt = 'Hausrat- und Haftpflichtversicherung', Name_Neu = 'Hausrat- und Haftpflichtversicherung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 0, ProUE = 1, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 18, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 180, BgPositionsartCode_Neu = 180, VarName = 'null', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '522', Name_Alt = 'AHV-Mindestbeitrag', Name_Neu = 'AHV-Mindestbeitrag', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 1, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100148, BgPositionsartCode_Neu = 100148, VarName = '15.0405', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '530', Name_Alt = 'Grundversicherung KVG', Name_Neu = 'Grundversicherung KVG', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 25, Masterbudget_EditMask = 2093056, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 161055, BgPositionsartCode_Neu = 90035, VarName = '10.022', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '830', Name_Alt = 'Ablieferung Arbeitslosenversicherung', Name_Neu = 'Ablieferung Arbeitslosenversicherung', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20111201', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 1, Masterbudget_EditMask = 16773120, Monatsbudget_EditMask = 4095, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 161056, BgPositionsartCode_Neu = 90036, VarName = '10.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '903', Name_Alt = 'Ablieferung IV-Leistungen', Name_Neu = ' Ablieferung IV-Leistungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20111201', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 1, Masterbudget_EditMask = 16773120, Monatsbudget_EditMask = 4095, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 161057, BgPositionsartCode_Neu = 90037, VarName = '10.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '901', Name_Alt = 'Ablieferung Sozialversicherungsleistungen', Name_Neu = 'Ablieferung Sozialversicherungsleistungen', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20111201', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 1, Masterbudget_EditMask = 16773120, Monatsbudget_EditMask = 4095, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt = 161055, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Ablieferung Arbeitslosenversicherung', Name_Neu = 'Durchlauf Fremdgeld', BgGruppeCodeName = 'Situationsbedingte Leistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 0, SortKey = 1, Masterbudget_EditMask = 16773120, Monatsbudget_EditMask = 4095, sqlRichtlinie = NULL, Verrechenbar = 1;

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