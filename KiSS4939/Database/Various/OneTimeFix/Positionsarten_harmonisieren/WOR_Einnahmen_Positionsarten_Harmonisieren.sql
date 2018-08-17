BEGIN TRANSACTION

DECLARE @BgKategorieCode INT,
        @RefDateVon      DATETIME,
        @RefDateBis      DATETIME,
        @OnlyCheck       BIT;

--------------------
-- Parameter setzen
--------------------
SET @BgKategorieCode = 1; --1: Einnahmen
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
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100104, BgPositionsartCode_Neu = 100104, VarName = '10.012', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '851', Name_Alt = 'Ausbildungslohn', Name_Neu = 'Ausbildungslohn', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 3, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 104, BgPositionsartCode_Neu = 104, VarName = '12.152', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '851', Name_Alt = 'Entschädigung für Haushaltsführung', Name_Neu = 'Entschädigung für Haushaltsführung', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 4, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 100103, BgPositionsartCode_Neu = 100103, VarName = '10.012', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '851', Name_Alt = 'Hauswartung', Name_Neu = 'Hauswartung', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = '20120930', ModulID = 3, [System] = 1, SortKey = 2, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 102, BgPositionsartCode_Neu = 102, VarName = '10.012', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '851', Name_Alt = 'Lohn', Name_Neu = 'Lohn', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 111, BgPositionsartCode_Neu = 111, VarName = '10.022', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '830', Name_Alt = 'ALV', Name_Neu = 'ALV', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 2, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100115, BgPositionsartCode_Neu = 90029, VarName = '10.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '903', Name_Alt = 'IV-Rente', Name_Neu = 'IV-Rente', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 6, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100289, BgPositionsartCode_Neu = 90030, VarName = '10.102', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '905', Name_Alt = 'IV-Taggeld', Name_Neu = 'IV-Taggeld', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 4, Masterbudget_EditMask = 2028031, Monatsbudget_EditMask = 495, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '10.052', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '740', Name_Alt = 'Lohn', Name_Neu = 'BVG-Rente', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '12.142', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '740', Name_Alt = 'Lohn', Name_Neu = 'Lebensversicherung / 3. Säule', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 110, BgPositionsartCode_Neu = 110, VarName = '10.032', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '900', Name_Alt = 'Altersrente', Name_Neu = 'AHV-Rente', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '10.122', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '900', Name_Alt = 'Lohn', Name_Neu = 'EO / Mutterschaftsversicherung', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '10.042', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '900', Name_Alt = 'Lohn', Name_Neu = 'Witwen-/Waisenrente', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 107, BgPositionsartCode_Neu = 107, VarName = '10.132', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '870', Name_Alt = 'Inkasso durch Inkassodienst; keine Bevorschussung', Name_Neu = 'Inkasso Frauenalimente, Kinderzulagen durch Inkassodienst', BgGruppeCodeName = 'Alimentenguthaben', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = 90032, VarName = '10.132', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '872', Name_Alt = 'Lohn', Name_Neu = 'Inkasso Kinderalimente durch Inkassodienst; keine Bevorschussung', BgGruppeCodeName = 'Alimentenguthaben', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60968, BgPositionsartCode_Neu = NULL, VarName = '10.011', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '854', Name_Alt = 'Kinderzulage', Name_Neu = 'Kinderzulage durch Arbeitgeber', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20121001', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 6, Masterbudget_EditMask = 2028031, Monatsbudget_EditMask = 495, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60969, BgPositionsartCode_Neu = NULL, VarName = '12.052', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '855', Name_Alt = 'Kinderzulage', Name_Neu = 'Kinderzulage Nichterwerbstätige', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 12, Masterbudget_EditMask = 2028031, Monatsbudget_EditMask = 495, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 31030, BgPositionsartCode_Neu = 31030, VarName = 'null', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '730', Name_Alt = 'Rückerstattung Krankenkasse', Name_Neu = 'Rückerstattung Krankenkasse', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 1311231, Monatsbudget_EditMask = 1896911, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '701', Name_Alt = 'Lohn', Name_Neu = 'Rückerstattung aus Hinterlassenschaft', BgGruppeCodeName = 'Rückerstattungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '12.162', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '871', Name_Alt = 'Lohn', Name_Neu = 'Elternbeiträge', BgGruppeCodeName = 'Rückerstattungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '12.162', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '880', Name_Alt = 'Lohn', Name_Neu = 'Verwandtenbeiträge', BgGruppeCodeName = 'Rückerstattungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '12.122', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '840', Name_Alt = 'Lohn', Name_Neu = 'Stipendien', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Lohn', Name_Neu = 'diverse Rückzahlungen', BgGruppeCodeName = 'Rückerstattungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Lohn', Name_Neu = 'Miete von Dritten', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 60958, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Übrige Einnahmen', Name_Neu = 'Übrige Einnahmen', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20120101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 850, Masterbudget_EditMask = 10416639, Monatsbudget_EditMask = 2543, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 31050, BgPositionsartCode_Neu = 31050, VarName = '12.02', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Vermögensverbrauch', Name_Neu = 'Vermögensverzehr', BgGruppeCodeName = 'Vermögen und Vermögensverbrauch', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20121001', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'I', BgPositionsartCode_Alt =  102, BgPositionsartCode_Neu = NULL, VarName = '', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Lohn', Name_Neu = 'Durchlauf Fremdgeld', BgGruppeCodeName = 'Rückerstattungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20110101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 112, BgPositionsartCode_Neu = NULL, VarName = '12.072', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '901', Name_Alt = 'EL-Betrag IV/AHV', Name_Neu = 'EL-Betrag IV/AHV', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 4, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 114, BgPositionsartCode_Neu = NULL, VarName = '10.082', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '740', Name_Alt = 'SUVA-Rente', Name_Neu = 'SUVA-Rente', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 9, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 115, BgPositionsartCode_Neu = NULL, VarName = '10.092', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '730', Name_Alt = 'Taggeld KK', Name_Neu = 'Taggeld KK', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 10, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 117, BgPositionsartCode_Neu = NULL, VarName = '10.052', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '740', Name_Alt = 'BVG', Name_Neu = 'BVG', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = '20120331', ModulID = 3, [System] = 1, SortKey = 3, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100114, BgPositionsartCode_Neu = NULL, VarName = '10.062', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '902', Name_Alt = 'Hilflosenentschädigung', Name_Neu = 'Hilflosenentschädigung', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 5, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100120, BgPositionsartCode_Neu = NULL, VarName = '10.082', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '730', Name_Alt = 'Unfall-Taggeld', Name_Neu = 'Unfall-Taggeld', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 11, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 100121, BgPositionsartCode_Neu = NULL, VarName = '10.042', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '900', Name_Alt = 'Witwen-/Waisenrente', Name_Neu = 'Witwen-/Waisenrente', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = '20120831', ModulID = 3, [System] = 1, SortKey = 12, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100122, BgPositionsartCode_Neu = NULL, VarName = '10.122', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '740', Name_Alt = 'Andere Sozialversicherungsleistungen', Name_Neu = 'Andere Sozialversicherungsleistungen', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 13, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 100290, BgPositionsartCode_Neu = NULL, VarName = '10.122', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '900', Name_Alt = 'EO/Mutterschaftsentschädigung', Name_Neu = 'EO/Mutterschaftsentschädigung', BgGruppeCodeName = 'Einkommen aus Versicherungsleistungen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = '20120101', DatumBis = '20121031', ModulID = 3, [System] = 1, SortKey = 12, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 100292, BgPositionsartCode_Neu = NULL, VarName = '12.122', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '840', Name_Alt = 'Stipendien', Name_Neu = 'Stipendien', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20120101', DatumBis = '20121031', ModulID = 3, [System] = 1, SortKey = 3, Masterbudget_EditMask = 2027520, Monatsbudget_EditMask = 495, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 100293, BgPositionsartCode_Neu = NULL, VarName = '12.0142', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '850', Name_Alt = 'Diverse Rückerstattung', Name_Neu = 'Diverse Rückerstattung', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = '20120101', DatumBis = '20120930', ModulID = 3, [System] = 1, SortKey = 850, Masterbudget_EditMask = 10416639, Monatsbudget_EditMask = 2543, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'U', BgPositionsartCode_Alt = 100294, BgPositionsartCode_Neu = NULL, VarName = '15.0412', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '700', Name_Alt = 'Persönliche Rückerstattung', Name_Neu = 'Persönliche Rückerstattung', BgGruppeCodeName = 'Rückerstattungen', ProPerson = 1, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = '20120101', DatumBis = NULL, ModulID = 3, [System] = 1, SortKey = 1, Masterbudget_EditMask = 1962495, Monatsbudget_EditMask = 495, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 100295, BgPositionsartCode_Neu = NULL, VarName = '12.162', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '880', Name_Alt = 'Verwandtenbeiträge', Name_Neu = 'Verwandtenbeiträge', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 0, Spezkonto = 0, DatumVon = NULL, DatumBis = '20120930', ModulID = 3, [System] = 1, SortKey = 850, Masterbudget_EditMask = 16773120, Monatsbudget_EditMask = 4095, sqlRichtlinie = NULL, Verrechenbar = 1;
INSERT INTO @poaSoll (Aktion, BgPositionsartCode_Alt, BgPositionsartCode_Neu, VarName, BgKategorieCode, KoAKontoNr, Name_Alt, Name_Neu, BgGruppeCodeName, ProPerson, ProUE, VerwaltungSD_Default, Spezkonto, DatumVon, DatumBis, ModulID, [System], SortKey, Masterbudget_EditMask, Monatsbudget_EditMask, sqlRichtlinie, Verrechenbar) SELECT  Aktion = 'D', BgPositionsartCode_Alt = 100106, BgPositionsartCode_Neu = NULL, VarName = '10.032', BgKategorieCode = @BgKategorieCode , KoAKontoNr = '851', Name_Alt = 'Pension', Name_Neu = 'Pension', BgGruppeCodeName = 'Erwerbseinkommen', ProPerson = 0, ProUE = 0, VerwaltungSD_Default = 1, Spezkonto = 0, DatumVon = NULL, DatumBis = '20120331', ModulID = 3, [System] = 1, SortKey = 6, Masterbudget_EditMask = 2093567, Monatsbudget_EditMask = 511, sqlRichtlinie = NULL, Verrechenbar = 1;

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
