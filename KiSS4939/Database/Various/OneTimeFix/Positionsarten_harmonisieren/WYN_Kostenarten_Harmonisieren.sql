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
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 43, Name = 'Zulagen IZU', KontoNr = '101', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'IZU/MIZ (Zulagen)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6081, Name = 'VVG (aus GB)', KontoNr = '102', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'Grundbedarf', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10056, Name = 'Zulagen MIZ', KontoNr = '103', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'IZU/MIZ (Zulagen)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10057, Name = 'Zulagen EFB', KontoNr = '105', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'EFB (Einkommensfreibetrag)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10058, Name = 'Auswärtige Verpflegung', KontoNr = '107', Splittingart = 'Monat', Quoting = 0, WCZeile = '1. Lebensunterhalt', GefKategorieTyp = 'Aufwand', GefKategorie = 'IZU/MIZ (Zulagen)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 2, Name = 'Wohnkosten (ohne NK)', KontoNr = '110', Splittingart = 'Monat', Quoting = 1, WCZeile = '2. Wohnung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Wohnkosten inkl. Wohnnebenkosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10059, Name = 'Mietnebenkosten', KontoNr = '111', Splittingart = 'Monat', Quoting = 1, WCZeile = '2. Wohnung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Wohnkosten inkl. Wohnnebenkosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 3, Name = 'Arzt, Medikamente', KontoNr = '200', Splittingart = 'Monat', Quoting = 0, WCZeile = '3. Äerztliche Behandlung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Gesundheitskosten ohne KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 4, Name = 'Zahnarzt', KontoNr = '201', Splittingart = 'Monat', Quoting = 0, WCZeile = '3. Äerztliche Behandlung', GefKategorieTyp = 'Aufwand', GefKategorie = 'Gesundheitskosten ohne KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 5, Name = 'Integrationsmassnahmen KA', KontoNr = '320', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10008, Name = 'Therapeutisch/Pädagogische Integrationsmassnahmen', KontoNr = '321', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6082, Name = 'Integrationsmassnahmen Übrige', KontoNr = '322', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6, Name = 'Pflegetaxen in Krankenhäusern und Kuranstalten', KontoNr = '400', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Gesundheitskosten ohne KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 7, Name = 'Unterbringung in Vollzugsinstitutionen (Haftanstalten)', KontoNr = '410', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6084, Name = 'Pflegegelder in Vollzugsinstitutionen (Haftanstalten) mit ES ZGB', KontoNr = '411', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6085, Name = 'Unterbringung in stationären Einrichtungen', KontoNr = '420', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6086, Name = 'Unterbringung in stationären Einrichtungen mit ES ZGB', KontoNr = '421', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10060, Name = 'Unterbringung in stationären Einrichtungen mit KS ZGB', KontoNr = '422', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6087, Name = 'Unterbringung in Alters- und Pflegeheimen', KontoNr = '430', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6088, Name = 'Unterbringung in Alters- und Pflegeheimen mit ES ZGB', KontoNr = '431', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10061, Name = 'Unterbringung in stationären Einrichtungen für Minderjährige', KontoNr = '432', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10062, Name = 'Ambulante Massnahmen Minderjährige', KontoNr = '433', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10063, Name = 'Ambulante Massnahmen Erwachsene', KontoNr = '434', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10064, Name = 'Ambulante Massnahmen Minderjährige mit KS ZGB', KontoNr = '435', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10065, Name = 'Ambulante Massnahmen Erwachsene mit ES ZGB', KontoNr = '436', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Kosten für vorsorgliche ambulante Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6089, Name = 'Übernachtungen in Obdachloseninstitutionen', KontoNr = '440', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 8, Name = 'Pensionsgelder (Hotellerie, Pensionen, Private)', KontoNr = '450', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6090, Name = 'Unterbringung Minderjährige bei Privaten', KontoNr = '460', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige Platzierungskosten', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10072, Name = 'Unterbringung Minderjährige bei Privaten mit KS ZGB', KontoNr = '461', Splittingart = 'Monat', Quoting = 0, WCZeile = '5. a) Kostgelder', GefKategorieTyp = 'Aufwand', GefKategorie = 'Platzierungskosten aufgrund vormundschaftlicher Massnahmen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 9, Name = 'Situationsbedingte Leistungen', KontoNr = '520', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6091, Name = 'Hausrat- und Haftpflichtversicherungen', KontoNr = '521', Splittingart = 'Valuta', Quoting = 1, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 11, Name = 'AHV-Mindestbeiträge', KontoNr = '522', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'Übrige SIL', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6092, Name = 'Inkassokosten im Unterstützungs- und Vermittlungsfall', KontoNr = '523', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6106, Name = 'Zins im Unterstützungs-/Vermittlungsfall', KontoNr = '524', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10, Name = 'Krankenkassenprämien KVG', KontoNr = '530', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Aufwand', GefKategorie = 'KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6093, Name = 'KVG EL-Bezüger', KontoNr = '531', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = 'Aufwand', GefKategorie = 'Gesundheitskosten ohne KK-Prämien Grundversicherung', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10027, Name = 'Zuschuss nach Dekret', KontoNr = '550', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 12, Name = 'Ablieferungen', KontoNr = '600', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 13, Name = 'Ablieferungen an Behörde (ZUG)', KontoNr = '601', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 14, Name = 'Ablieferungen übrige Behörden', KontoNr = '602', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 15, Name = 'Ablieferungen Behörden (Bund)', KontoNr = '603', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6094, Name = 'Ablieferungen Sozialversicherungsleistungen POM', KontoNr = '604', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10067, Name = 'Ablieferung Mehreinnahmen', KontoNr = '605', Splittingart = 'Monat', Quoting = 0, WCZeile = '6. Andere Aufwendungen', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 16, Name = 'Alimentebevorschussung', KontoNr = '680', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 17, Name = 'Alimentenbevorschussung (Ablieferung)', KontoNr = '681', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6095, Name = 'Inkassokosten Alimentenbevorschussung', KontoNr = '682', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6105, Name = 'Zins Alimentenbevorschussung', KontoNr = '683', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 18, Name = 'Persönliche Rückerstattungen', KontoNr = '700', Splittingart = 'Monat', Quoting = 0, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Persönliche Rückerstattungen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 19, Name = 'Rückerstattungen aus Hinterlassenschaften', KontoNr = '701', Splittingart = 'Monat', Quoting = 0, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Persönliche Rückerstattungen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 20, Name = 'Leistungen von Krankenkassen/UVG', KontoNr = '730', Splittingart = 'Monat', Quoting = 0, WCZeile = '8. a) Versicherungsleistungen Krankenkasse', GefKategorieTyp = 'Ertrag', GefKategorie = 'Erträge Gesundheitskosten (KK-Rückerstattungen)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 21, Name = 'SUVA-Renten/Militärvers./Alterspensionen', KontoNr = '740', Splittingart = 'Monat', Quoting = 1, WCZeile = '11. Bundesbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 22, Name = 'Alimentenbevorschussung', KontoNr = '780', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 23, Name = 'Kinderalimente und - Zulagen Vermittlung Bevorschussung', KontoNr = '781', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6096, Name = 'Inkassokosten Alimentenbevorschussung', KontoNr = '782', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6103, Name = 'Zins Alimentenbevorschussung', KontoNr = '783', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 24, Name = 'Heimatliche Vergütung ZUG', KontoNr = '800', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Ertrag', GefKategorie = 'Heimatliche Vergütungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 25, Name = 'Heimatliche Vergütung Ausländer', KontoNr = '801', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = 'Ertrag', GefKategorie = 'Heimatliche Vergütungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 30, Name = 'Übrige behördliche Vergütungen', KontoNr = '802', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 27, Name = 'Arbeitslosenversicherung', KontoNr = '830', Splittingart = 'Monat', Quoting = 1, WCZeile = '11. Bundesbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'ALV', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 28, Name = 'Stipendien', KontoNr = '840', Splittingart = 'Monat', Quoting = 1, WCZeile = '11. Bundesbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 29, Name = 'Übrige Einnahmen', KontoNr = '850', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Übrige Einkommen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6097, Name = 'Lohneinnahmen', KontoNr = '851', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Erwerbseinkommen (netto)', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6098, Name = 'Inkassokosten im Unterstützungs-/Vermittlungsfall', KontoNr = '852', Splittingart = 'Monat', Quoting = 1, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6104, Name = 'Zins im Unterstützungs-/Vermittlungsfall', KontoNr = '853', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10054, Name = 'Kinderzulage Lohn', KontoNr = '854', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Familienzulagen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10055, Name = 'Kinderzulage Versicherung', KontoNr = '855', Splittingart = 'Monat', Quoting = 1, WCZeile = '10. Rückerstattungen', GefKategorieTyp = 'Ertrag', GefKategorie = 'Familienzulagen', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 31, Name = 'Frauenrenten,Kinderzulagen im Unterstützungs- u. Vermittlungsfall, KA Verm.', KontoNr = '870', Splittingart = 'Monat', Quoting = 0, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 33, Name = 'Elternbeiträge', KontoNr = '871', Splittingart = 'Monat', Quoting = 1, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6099, Name = 'Kinderalimente im Unterstützungsfall', KontoNr = '872', Splittingart = 'Monat', Quoting = 0, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Kinderalimente und Ehegattenalimente', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 32, Name = 'Verwandtenbeiträge', KontoNr = '880', Splittingart = 'Monat', Quoting = 0, WCZeile = '9. Verwandtenbeiträge', GefKategorieTyp = 'Ertrag', GefKategorie = 'Elternbeiträge/Verwandtenunterstützung', Inkassoprovision = 1;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 34, Name = 'AHV-Renten', KontoNr = '900', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 35, Name = 'EL f. AHV-/IV-Bezüger', KontoNr = '901', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 36, Name = 'HE f. AHV-/IV-Bezüger', KontoNr = '902', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'Einkommen aus übrigen Sozialversicherungen', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 37, Name = 'IV-Renten', KontoNr = '903', Splittingart = 'Monat', Quoting = 1, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'IV-Taggelder und IV-Rente', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 6100, Name = 'Sozialversicherungsleistungen POM u. and. kant. Behörden', KontoNr = '904', Splittingart = 'Monat', Quoting = 0, WCZeile = '', GefKategorieTyp = '', GefKategorie = '', Inkassoprovision = 0;
INSERT INTO @koaSoll (BgKostenartID, Name, KontoNr, Splittingart, Quoting, WVZeile, GefKategorieTyp, GefKategorie, Inkassoprovision) SELECT  BgKostenartID = 10068, Name = 'IV-Taggeld', KontoNr = '905', Splittingart = 'Monat', Quoting = 0, WCZeile = '8. Versicherungsleistungen AHV', GefKategorieTyp = 'Ertrag', GefKategorie = 'IV-Taggelder und IV-Rente', Inkassoprovision = 0;

-- KOA end
----------------------------------------------------------------------------

-------------------------------------------------------------------
-- Perform Checks
-------------------------------------------------------------------
-- 1. Gegenüberstellung Soll / Ist aufgrund BgPositionsartCode
SELECT 
  -- Soll
  [S:ID]           = KOAS.BgKostenartID, 
  [S:Name]         = KOAS.Name, 
  [S:KontoNr]      = KOAS.KontoNr, 
  [S:Splittingart] = KOAS.Splittingart, 
  [S:Quoting]      = KOAS.Quoting, 
  [S:WVZeile]      = KOAS.WVZeile, 
  [S:GefKategorieTyp]  = KOAS.GefKategorieTyp, 
  [S:GefKategorie]     = KOAS.GefKategorie, 
  [S:Inkassoprovision] = KOAS.Inkassoprovision, 

  [ ]               = ' ',

  -- Ist
  [I:ID]           = KOAI.BgKostenartID, 
  [I:Name]         = KOAI.Name, 
  [I:KontoNr]      = KOAI.KontoNr, 
  [I:Splittingart] = dbo.fnLOVText('BgSplittingArt', KOAI.BgSplittingArtCode), 
  [I:Quoting]      = KOAI.Quoting, 
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

-- 2. Konto Gegenüberstellung Soll / Ist
SELECT 
  -- Soll
  [S:BgKostenartID]    = KOAS.BgKostenartID, 
  [S:Name]             = KOAS.Name, 
  [S:KontoNr]          = KOAS.KontoNr, 

  [ ]                  = ' ',

  -- Ist
  [I:KbKontoID]        = KTO.KbKontoID, 
  [I:Name]             = KTO.KontoName, 
  [I:KontoNr]          = KTO.KontoNr
FROM @koaSoll KOAS
  LEFT JOIN dbo.KbKonto KTO ON KTO.KontoNr = KOAS.KontoNr
                           AND KTO.KbPeriodeID = (SELECT TOP 1 KbPeriodeID
                                                  FROM dbo.KbPeriode PRD WITH (READUNCOMMITTED)
                                                  WHERE PRD.KbMandantID = 1
                                                    AND GETDATE() BETWEEN PRD.PeriodeVon AND PRD.PeriodeBis)
ORDER BY KOAS.KontoNr;


-------------------------------------------------------------------
--Perform Changes
-------------------------------------------------------------------
IF (@OnlyCheck = 1)
BEGIN
  RETURN;
END;

-- 1. Kostenart anpassen
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

-- 2. Name des Kontos in aktuelle Periode anpassen
UPDATE KTO
  SET KontoName = KOAS.Name
FROM dbo.KbKonto KTO
  INNER JOIN @koaSoll KOAS ON KOAS.KontoNr = KTO.KontoNr
WHERE KTO.KbPeriodeID = (SELECT TOP 1 KbPeriodeID
                         FROM dbo.KbPeriode PRD WITH (READUNCOMMITTED)
                         WHERE PRD.KbMandantID = 1
                           AND GETDATE() BETWEEN PRD.PeriodeVon AND PRD.PeriodeBis);

-- GEF-Kategorie anpassen
-- TODO


-- COMMIT
-- ROLLBACK