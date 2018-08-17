BEGIN TRANSACTION

DECLARE @OnlyCheck       BIT;

--------------------
-- Parameter setzen
--------------------
SELECT @OnlyCheck = 1;

DECLARE @koaSoll TABLE(
  ID INT IDENTITY (1,1) ,
  BgKostenartID INT,
  Name VARCHAR(500), 
  KontoNr VARCHAR(10), 
  Splittingart VARCHAR(500), 
  Quoting BIT, 
  WVZeile VARCHAR(500),
  GefKategorieTyp VARCHAR(500),
  GefKategorie VARCHAR(500),
  Inkassoprovision BIT
);

----------------------------------------------------------------------------
-- KOA begin
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 1, Name = 'Grundbedarf', KontoNr = '100', Splittingart = 'Monat', Quoting = 1, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'Grundbedarf', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 43, Name = 'IZU', KontoNr = '101', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'IZU/MIZ (Zulagen)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6081, Name = 'VVG', KontoNr = '102', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'Grundbedarf', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10056, Name = 'MIZ', KontoNr = '103', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'IZU/MIZ (Zulagen)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10057, Name = 'EFB', KontoNr = '105', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'EFB (Einkommensfreibetrag)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10058, Name = 'Auswärtige Verpflegung', KontoNr = '107', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 2, Name = 'Mietzinse (ohne Nebenkosten)', KontoNr = '110', Splittingart = 'Monat', Quoting = 1, WCZeile = '2. Wohnung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Wohnkosten inkl. Wohnnebenkosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10059, Name = 'Mietnebenkosten', KontoNr = '111', Splittingart = 'Monat', Quoting = 1, WCZeile = '2. Wohnung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Wohnkosten inkl. Wohnnebenkosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 3, Name = 'Arzt / Medikamente', KontoNr = '200', Splittingart = 'Monat', Quoting = 0, WCZeile = '3. Äerztliche Behandlung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Gesundheitskosten ohne KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 4, Name = 'Zahnarzt', KontoNr = '201', Splittingart = 'Monat', Quoting = 0, WCZeile = '3. Äerztliche Behandlung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Gesundheitskosten ohne KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10007, Name = 'Integrationsmassnahmen KA', KontoNr = '320', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10008, Name = 'Therapeutisch/Pädagogische Integrationsmassnahmen', KontoNr = '321', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6082, Name = 'Integrationsmassnahmen Übrige', KontoNr = '322', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6, Name = 'Pflegetaxen in Krankenhäusern und Kuranstalten', KontoNr = '400', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Gesundheitskosten ohne KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 7, Name = 'Vollzugsinstitutionen (Haftanstalten)', KontoNr = '410', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6084, Name = 'Pflegegelder in Vollzugsinstitutionen (Haftanstalten) mit ES ZGB', KontoNr = '411', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6085, Name = 'Allgemeine stationären Einrichtungen', KontoNr = '420', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6086, Name = 'Pflegegelder in stationären Einrichtungen mit ES ZGB', KontoNr = '421', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10060, Name = 'Pflegegelder in stationären Einrichtungen mit KS ZGB', KontoNr = '422', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6087, Name = 'Therapieaufenthalte, Alters- und Pflegeheime', KontoNr = '430', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6088, Name = 'Pflegegelder in Alters- und Pflegeheimen mit ES ZGB', KontoNr = '431', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10061, Name = 'Unterbringung Minderjährige stationär', KontoNr = '432', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10062, Name = 'Ambulante Massnahmen Minderjährige', KontoNr = '433', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10063, Name = 'Ambulante Massnahmen Erwachsene', KontoNr = '434', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10064, Name = 'Ambulante Massnahmen Minderjährige mit KS ZGB', KontoNr = '435', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10065, Name = 'Ambulante Massnahmen Erwachsene mit ES ZGB', KontoNr = '436', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6089, Name = 'Obdachloseninstitution', KontoNr = '440', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 8, Name = 'Pensionsgelder (Hotellerie, Pensionen, Private)', KontoNr = '450', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6090, Name = 'Unterbringung Minderjährige bei Privaten', KontoNr = '460', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10066, Name = 'Pflegegelder Minderjährige bei Privaten mit KS ZGB', KontoNr = '461', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 9, Name = 'Situationsbedingte Leistungen', KontoNr = '520', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6091, Name = 'Hausrat- und Haftpflichtversicherungen', KontoNr = '521', Splittingart = 'Valuta', Quoting = 1, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 11, Name = 'AHV-Mindesbeiträge', KontoNr = '522', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'Familienzulagen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6092, Name = 'Inkassokosten im Unterstützungs- und Vermittlungsfall', KontoNr = '523', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6106, Name = 'Zins im Unterstützungs-/Vermittlungsfall', KontoNr = '524', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10, Name = 'KVG Krankenkassenprämien', KontoNr = '530', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6093, Name = 'KVG Rückerstattung ASV (z.B. EL)', KontoNr = '531', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'KK-Prämien Grundversicherung', Inkassoprovision = 0;

INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 12, Name = 'Ablieferungen', KontoNr = '600', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = '', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 13, Name = 'Ablieferungen an Behörde (ZUG)', KontoNr = '601', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Heimatliche Vergütungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 14, Name = 'Ablieferungen übrige Behörden', KontoNr = '602', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 15, Name = 'Ablieferungen Behörden (Bund)', KontoNr = '603', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6094, Name = 'Ablieferungen Sozialversicherungsleistungen POM', KontoNr = '604', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10067, Name = 'Ablieferung Mehreinnahmen', KontoNr = '605', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 16, Name = 'Bevorschussung Kinderalimente', KontoNr = '680', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10034, Name = 'Vermittlung Kinderalimente u. KiZu', KontoNr = '681', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6095, Name = 'Inkassokosten Bevorschussung', KontoNr = '682', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6105, Name = 'Zins Alimentenbevorschussung', KontoNr = '683', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6125, Name = 'Erwachsenenalimente Ausgabe', KontoNr = '684', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6127, Name = 'Inkassokosten Alimentenvermittlung', KontoNr = '685', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 18, Name = 'Persönliche Rückerstattungen', KontoNr = '700', Splittingart = 'Monat', Quoting = 0, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Persönliche Rückerstattungen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 19, Name = 'Rückerstattungen aus Erbschaft', KontoNr = '701', Splittingart = 'Monat', Quoting = 0, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Persönliche Rückerstattungen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6124, Name = 'Prämienverbilligung ASV', KontoNr = '720', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 20, Name = 'Krankenkassen- und UVG-Leistungen', KontoNr = '730', Splittingart = 'Monat', Quoting = 0, WCZeile = '8. a) Versicherungsleistungen Krankenkasse', GefKategorieTyp = 'Ertrag', GefKategorie = 'Erträge Gesundheitskosten (KK-Rückerstattungen)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 21, Name = 'BVG, Lebensversicherung, 3. Säule', KontoNr = '740', Splittingart = 'Monat', Quoting = 1, WCZeile = '11. Bundesbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 22, Name = 'Rückerst. Bevorschussung Kinderalimente', KontoNr = '780', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 23, Name = 'Rückerst. Vermittlung Kinderalimente u. KiZu', KontoNr = '781', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6096, Name = 'Inkassokosten Alimentenbevorschussung', KontoNr = '782', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6103, Name = 'Zins Bevorschussung', KontoNr = '783', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6126, Name = 'Erwachsenenalimente Einnahme', KontoNr = '784', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6128, Name = 'Zins Alimentenvermittlung', KontoNr = '785', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = '-', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 24, Name = 'Heimatliche Vergütung ZUG', KontoNr = '800', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Ertrag', GefKategorie = 'Heimatliche Vergütungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 25, Name = 'Heimatliche Vergütung Ausländer', KontoNr = '801', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Ertrag', GefKategorie = 'Heimatliche Vergütungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 30, Name = 'Übrige behördliche Vergütungen (z.B. SRK, Caritas usw.)', KontoNr = '802', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 27, Name = 'Arbeitslosenversicherung', KontoNr = '830', Splittingart = 'Monat', Quoting = 1, WCZeile = '11. Bundesbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'ALV', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 28, Name = 'Stipendien', KontoNr = '840', Splittingart = 'Monat', Quoting = 1, WCZeile = '11. Bundesbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 29, Name = 'Übrige Einnahmen', KontoNr = '850', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6097, Name = 'Lohneinnahmen', KontoNr = '851', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Erwerbseinkommen (netto)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6098, Name = 'Inkassokosten Rückerstattungen (inkl. POM)', KontoNr = '852', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6104, Name = 'Zins Rückerstattung (inkl. POM)', KontoNr = '853', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Ertrag', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10054, Name = 'Kinderzulage Arbeitgeber', KontoNr = '854', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Familienzulagen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10055, Name = 'Kinderzulage Nichterwerbstätige', KontoNr = '855', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Familienzulagen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6131, Name = 'Inkassokosten Elternbeiträge (EB)', KontoNr = '856', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6133, Name = 'Inkassokosten Verwandtenbeiträge (VB)', KontoNr = '857', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 31, Name = 'Erwachsenenalimente im Unterstützungsfall', KontoNr = '870', Splittingart = 'Monat', Quoting = 0, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 33, Name = 'Elternbeiträge', KontoNr = '871', Splittingart = 'Monat', Quoting = 1, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6099, Name = 'Kinderalimente u. KiZu im Unterstützungsfall', KontoNr = '872', Splittingart = 'Monat', Quoting = 0, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6129, Name = 'Inkassokosten Alimente im Unterstützungsfall', KontoNr = '873', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6130, Name = 'Zins Alimente im Unterstützungsfall', KontoNr = '874', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6132, Name = 'Zins Elternbeiträge (EB)', KontoNr = '875', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6134, Name = 'Zins Verwandtenbeiträge (VB)', KontoNr = '876', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 32, Name = 'Verwandtenbeiträge', KontoNr = '880', Splittingart = 'Monat', Quoting = 0, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 34, Name = 'AHV-Renten', KontoNr = '900', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 35, Name = 'Ergänzungsleistungen', KontoNr = '901', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 36, Name = 'Hilflosenentschädigung', KontoNr = '902', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 37, Name = 'IV-Renten', KontoNr = '903', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'IV-Taggelder und IV-Rente', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6100, Name = 'Sozialversicherungsleistungen POM u. and. kant. Behörden', KontoNr = '904', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10068, Name = 'IV-Taggeld', KontoNr = '905', Splittingart = 'Monat', Quoting = 0, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'IV-Taggelder und IV-Rente', Inkassoprovision = 0;

INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = -1, Name = 'Nebenkosten KESB-Massnahmen Erwachsene', KontoNr = '423', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = -1, Name = 'Nebenkosten KESB-Massnahmen Minderjährige', KontoNr = '424', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = -1, Name = 'Nebenkosten übrige Unterbringungen', KontoNr = '425', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = -1, Name = 'Taggelder KVG / VVG / UVG', KontoNr = '731', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = -1, Name = 'SUVA-Rente', KontoNr = '750', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = -1, Name = 'Fonds', KontoNr = '906', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = -1, Name = 'EL-Krankheitskosten', KontoNr = '907', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;



-- KOA end
----------------------------------------------------------------------------
-------------------------------------------------------------------
-- Perform Checks
-------------------------------------------------------------------
-- 1. Gegenüberstellung Soll / Ist aufgrund BgPositionsartCode
SELECT 
  -- Soll
  [S:ID]               = KOAS.BgKostenartID, 
  [S:Name]             = KOAS.Name, 
  [S:KontoNr]          = KOAS.KontoNr, 
  [S:Splittingart]     = KOAS.Splittingart, 
  [S:Quoting]          = KOAS.Quoting, 
  [S:WVZeile]          = KOAS.WVZeile, 
  [S:GefKategorieTyp]  = KOAS.GefKategorieTyp, 
  [S:GefKategorie]     = KOAS.GefKategorie, 
  [S:Inkassoprovision] = KOAS.Inkassoprovision, 

  [ ]                  = ' ',

  -- Ist
  [I:ID]               = KOAI.BgKostenartID, 
  [I:Name]             = KOAI.Name, 
  [I:KontoNr]          = KOAI.KontoNr, 
  [I:Splittingart]     = dbo.fnLOVText('BgSplittingArt', KOAI.BgSplittingArtCode), 
  [I:Quoting]          = KOAI.Quoting, 
  [I:WVZeile]          = dbo.fnLOVText('BaWVZeile', KOAI.BaWVZeileCode),
  [I:GefKategorieTyp]  = dbo.fnLOVText('WhGefKategorieTyp', WGK.WhGefKategorieTypCode), 
  [I:GefKategorie]     = dbo.fnLOVText('WhGefKategorie', WGK.WhGefKategorieCode), 
  [I:Inkassoprovision] = ISNULL(KGK.IsInkassoprovision, 0)
FROM @koaSoll KOAS
  LEFT JOIN dbo.BgKostenart KOAI ON KOAI.KontoNr = KOAS.KontoNr
                                AND KOAI.ModulID = 3 -- Sozialhilfe
  LEFT JOIN dbo.BgKostenart_WhGefKategorie KGK ON KGK.BgKostenartID = KOAI.BgKostenartID
  LEFT JOIN dbo.WhGefKategorie WGK ON WGK.WhGefKategorieID = KGK.WhGefKategorieID
ORDER BY KOAS.KontoNr;


-------------------------------------------------------------------
--Perform Changes
-------------------------------------------------------------------
IF (@OnlyCheck = 1)
BEGIN
  RETURN;
END;

-- Kostenart anpassen
UPDATE KOA
  SET Name = KOAS.Name,
      Quoting = KOAS.Quoting,
      BgSplittingArtCode = ISNULL(LOV1.Code, -1),
      BaWVZeileCode = ISNULL(LOV2.Code, -1)
FROM dbo.BgKostenart KOA
  INNER JOIN @koaSoll KOAS ON KOAS.KontoNr = KOA.KontoNr
  LEFT JOIN dbo.XLOVCode LOV1 WITH (READUNCOMMITTED) ON LOV1.LOVName = 'BgSplittingArt'
                                                    AND LOV1.Text = KOAS.Splittingart
  LEFT JOIN dbo.XLOVCode LOV2 WITH (READUNCOMMITTED) ON LOV2.LOVName = 'BaWVZeile'
                                                    AND LOV2.Text = KOAS.WVZeile
WHERE KOA.ModulID = 3; -- Sozialhilfe

-- neue Kostenarten hinzufügen
INSERT INTO dbo.BgKostenart (ModulID, KontoNr, Name, Quoting, BgSplittingArtCode, BaWVZeileCode)
  SELECT 
    ModulID = 3, 
    KontoNr, 
    Name, 
    Quoting, 
    BgSplittingArtCode = ISNULL(LOV1.Code, -1),
    BaWVZeileCode = ISNULL(LOV2.Code, -1)
  FROM @koaSoll KOAS
    LEFT JOIN dbo.XLOVCode LOV1 WITH (READUNCOMMITTED) ON LOV1.LOVName = 'BgSplittingArt'
                                                      AND LOV1.Text = KOAS.Splittingart
    LEFT JOIN dbo.XLOVCode LOV2 WITH (READUNCOMMITTED) ON LOV2.LOVName = 'BaWVZeile'
                                                      AND LOV2.Text = KOAS.WVZeile
  WHERE NOT EXISTS(SELECT TOP 1 1
                   FROM dbo.BgKostenart KOA WITH (READUNCOMMITTED)
                   WHERE KOA.KontoNr = KOAS.KontoNr)
-- GEF-Kategorie anpassen
-- TODO


-- neue Konto erstellen
DECLARE @KbPeriodeID INT;
SELECT @KbPeriodeID = KbPeriodeID
FROM dbo.KbPeriode PRD
WHERE KbMandantID = 1
  AND PeriodeVon = '20140101';

DECLARE @KontoTmp TABLE 
(
  ID INT IDENTITY(1, 1),
  KontoNr VARCHAR(10), 
  KontoNr_Parent VARCHAR(19),
  KbKontoKlasseCode INT
);

INSERT INTO @KontoTmp (KontoNr, KontoNr_Parent, KbKontoKlasseCode) -- 3: Aufwand, 4: Ertrag
  SELECT '423', '3660.309', 3 UNION ALL
  SELECT '424', '3660.309', 3 UNION ALL
  SELECT '425', '3660.309', 3 UNION ALL
  SELECT '731', '4360.304', 4 UNION ALL
  SELECT '750', '4360.304', 4 UNION ALL
  SELECT '906', '4360.304', 4 UNION ALL
  SELECT '907', '4360.304', 4 UNION ALL
  
  SELECT '107', '3660.310', 3 UNION ALL
  SELECT '522', '3660.309', 3 UNION ALL
  SELECT '802', '4360.304', 4

INSERT INTO dbo.KbKonto (KbPeriodeID, GruppeKontoID, KbKontoklasseCode, KontoNr, KontoName, Kontogruppe)
  SELECT 
    KbPeriodeID       = @KbPeriodeID, 
    GruppeKontoID     = KTOP.KbKontoID, 
    KbKontoklasseCode = TMP.KbKontoKlasseCode, 
    KontoNr           = TMP.KontoNr, 
    KontoName         = KOAS.Name, 
    Kontogruppe       = 0
  FROM @KontoTmp TMP
    LEFT JOIN dbo.KbKonto KTO ON KTO.KbPeriodeID = @KbPeriodeID
                             AND KTO.KontoNr = TMP.KontoNr
    INNER JOIN dbo.KbKonto KTOP ON KTOP.KbPeriodeID = @KbPeriodeID
                               AND KTOP.KontoNr = TMP.KontoNr_Parent
    INNER JOIN @koaSoll KOAS ON KOAS.KontoNr = TMP.KontoNr
  WHERE KTO.KbKontoID IS NULL;

  UPDATE KTO
    SET GruppeKontoID     = ISNULL(KTOP.KbKontoID, KTO.GruppeKontoID), 
        KbKontoklasseCode = ISNULL(TMP.KbKontoKlasseCode, KTO.KbKontoklasseCode), 
        KontoName         = ISNULL(KOAS.Name, KTO.KontoName)
  FROM @KontoTmp TMP
    LEFT  JOIN dbo.KbKonto KTO  ON KTO.KbPeriodeID = @KbPeriodeID
                               AND KTO.KontoNr = TMP.KontoNr
    LEFT  JOIN dbo.KbKonto KTOP ON KTOP.KbPeriodeID = @KbPeriodeID
                               AND KTOP.KontoNr = TMP.KontoNr_Parent
    INNER JOIN @koaSoll    KOAS ON KOAS.KontoNr = TMP.KontoNr
  WHERE KTO.KbKontoID IS NULL;



-- Kontoplan sortieren
PRINT('Sorts each account groups by KontoNr');

DECLARE @KbKontoCTE TABLE(
  KbKontoID INT NOT NULL,
  KontoNr   VARCHAR(10),
  [Level]   INT
);

-- get account with level
WITH KontoCTE (KbKontoID, KontoNr, [Level]) AS -- common table expression 
(
  SELECT 
    KbKontoID,
    KontoNr,
    [Level] = 0
  FROM KbKonto
  WHERE KbPeriodeID = @KbPeriodeID
    AND GruppeKontoID IS NULL

  UNION ALL

  SELECT 
    KTO.KbKontoID,
    KTO.KontoNr,
    [Level] = [Level] + 1
  FROM KbKonto KTO
    INNER JOIN KontoCTE CTE ON CTE.KbKontoID = KTO.GruppeKontoID
  WHERE KbPeriodeID = @KbPeriodeID
)

INSERT INTO @KbKontoCTE
SELECT *
FROM KontoCTE CTE
ORDER BY CTE.Level, CTE.KontoNr

DECLARE @MaxLevel      INT,
        @LevelIterator INT,
        @KontoCount    INT,
        @KontoIterator INT;

DECLARE @GruppeKontoID INT;

DECLARE @Konto TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  KbKontoID INT
);

DECLARE @SortKonto TABLE
(
  KbKontoID INT,
  SortKey   INT
);


SELECT @MaxLevel = MAX([Level])
FROM @KbKontoCTE;

SET @LevelIterator = 0;
SET @KontoIterator = 0;

-- foreach level but last
WHILE(@LevelIterator < @MaxLevel)
BEGIN
  -- get account at this level
  INSERT INTO @Konto(KbKontoID)
  SELECT KbKontoID
  FROM @KbKontoCTE
  WHERE [Level] = @LevelIterator;

  SELECT @KontoCount = COUNT(1) FROM @Konto
  
  -- foreach account at this level
  WHILE (@KontoIterator <= @KontoCount)
  BEGIN
    -- get current entry
    SELECT @GruppeKontoID = TMP.KbKontoID
    FROM @Konto TMP
    WHERE TMP.ID = @KontoIterator;
    
    -- order by KontoNr
    INSERT INTO @SortKonto(KbKontoID, SortKey)
    SELECT 
      KbKontoID,
      SortKey = ROW_NUMBER() OVER (ORDER BY KontoNr)
    FROM KbKonto
    WHERE GruppeKontoID = @GruppeKontoID
    ORDER BY KontoNr;
    
    -- Set the new SortKey
    UPDATE KTO
    SET SortKey = KTOS.SortKey
    FROM KbKonto KTO
      INNER JOIN @SortKonto KTOS ON KTOS.KbKontoID = KTO.KbKontoID;
    
    
    -- prepare for next account entry
    SET @KontoIterator = @KontoIterator + 1;
  END;  

  -- prepare for next level entry
  SET @LevelIterator = @LevelIterator + 1;
END;




--COMMIT
--ROLLBACK
