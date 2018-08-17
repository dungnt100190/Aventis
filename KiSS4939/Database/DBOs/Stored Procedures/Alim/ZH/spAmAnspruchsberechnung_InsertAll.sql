SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAmAnspruchsberechnung_InsertAll
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/
-- =================================================================================================
-- Author:		R. Hesterberg
-- Create date: 08.08.2007
-- Description:	Alle Vorgaben in Tab. PositionsArt einfügen
-- !!!!!!!!!!!!!!!!!!!!!!!!!!!
-- ACHTUNG:
-- Die Einheit 2 darf nicht leer sein, wenn eine Berechnung x * y statt finden soll.
-- Wenn die Einheit 2 nicht sichtbar sein soll, soll sie auf ein Leerzeichen gesetzt werden: ' '
-- !!!!!!!!!!!!!!!!!!!!!!!!!!!
-- =================================================================================================
-- Testen: select * from AmAbPositionsArt
-- Daten einfügen:
-- ------------------------------------------
-- EXEC dbo.spAmAnspruchsberechnung_InsertAll
-- ------------------------------------------
-- Zuerst löschen: delete AmAbPositionsArt
-- Nur eine Pos löschen: 
--    !!!!!!!!!!!!!
--    Darf nur gemacht werden, wenn noch keine daten erfasst sind!!!
--    Vorhandene berechnungen müssen ev. neu berechnet werden, sonst sind sie falsch!!!
--    !!!!!!!!!!!!!
--    delete AmAbPosition where AmAbPositionsartID=3289
--    delete AmAbPositionsArt where Typ=3 and AmAbPositionsartID=3289
--    !!!!!!!!!!!!!
-- =================================================================================================
-- History:
-- 15.08.2007 : sozheo : Neue Spalten Format1 und Format2 
-- 16.08.2007 : sozheo : Sortierung bei 300 korrigiert
-- 31.08.2007 : sozheo : Neue Zeile 305, ALBV
-- 17.10.2007 : sozhew : Ein paar Fix Vorgabewerte eingegeben und Texte geändert
-- 22.10.2007 : sozhew : Texte Betrag in CHF geändert und Intervall in NULL
-- 29.10.2007 : sozheo : Erweiterungen für Typ 2 (üBH), löschen Von A41 und E141 (Kinderzulagen)
-- 31.10.2007 : sozheo : Berechnung korrigiert bei leerer Einheit
-- 04.11.2007 : sozheo : Anpassungen für KKBB
-- 13.11.2007 : sozhew : Definitionen für KKBB vorbereiten für Programmierung
-- 16.11.2007 : sozhew : Korrekturen KKBB
-- 20.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 25.11.2007 : sozheo : Anpassungen für KKBB
-- 28.11.2007 : sozheo : H303 weg
-- 10.01.2008 : sozheo : K511 ist jetzt fix, wird aus Monatszahlen genommen
-- 19.02.2008 : sozhew : Texte und Intervall angepasst Zeile 519 eingefügt und 519 in 521 verschoben
-- 07.03.2008 : sozheo : Korrekturen KKBB
-- 13.03.2008 : sozheo : Korrekturen KKBB: Position 3272 für immer weeg
-- 25.03.2008 : sozheo : Korrekturen ALBV: 144 -> 185, 183 -> 188, 184 -> 189
-- 09.04.2008 : sozheo : Korrekturen K511, manuell oder von Aliment
-- 15.04.2008 : sozheo : Korrekturen K512, Text UeBH
-- =================================================================================================

CREATE PROCEDURE [dbo].[spAmAnspruchsberechnung_InsertAll]
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON
  DECLARE @Typ int
  DECLARE @Kind bit
  DECLARE @Parent int
  DECLARE @Sort1 char(1)


  -- =====================================================================================================================
  -- Alte Daten löschen
  -- =====================================================================================================================
  -- 29.10.2007 : A41 wird nicht mehr verwendet
  DELETE AmAbPosition WHERE AmAbPositionsartID=41
  DELETE AmAbPosition WHERE AmAbPositionsartID=2041
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=41
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=2041

  -- 29.10.2007 : E141 wird nicht mehr verwendet
  DELETE AmAbPosition WHERE AmAbPositionsartID=141
  DELETE AmAbPosition WHERE AmAbPositionsartID=2141
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=141
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=2141

  -- 20.11.2007 : UeBH wird nicht mehr verwendet
  DELETE AmAbPosition WHERE AmAbPositionsartID BETWEEN 2000 AND 2999
  DELETE AmAbPositionsart WHERE AmAbPositionsartID BETWEEN 2000 AND 2999
  DELETE AmAbKind WHERE AmAnspruchsberechnungID IN (
    SELECT A.AmAnspruchsberechnungID FROM AmAnspruchsberechnung A
    LEFT OUTER JOIN FaLeistung F on F.FaLeistungID = A.FaLeistungID
    WHERE F.FaProzessCode = 403
  )
  DELETE AmAnspruchsberechnung WHERE FaLeistungID IN (
    SELECT F.FaLeistungID FROM FaLeistung F
    WHERE F.FaProzessCode = 403
  )

  -- 22.11.2007 : 304 wird nicht mehr verwendet
  DELETE AmAbPosition WHERE AmAbPositionsartID=304
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=304

  -- 22.11.2007 : 500 wird nicht mehr verwendet
  DELETE AmAbPosition WHERE AmAbPositionsartID=501
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=501

  -- 22.11.2007 : 500 wird nicht mehr verwendet
  DELETE AmAbPosition WHERE AmAbPositionsartID=502
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=502

  -- 28.11.2007 : H303 wird nicht mehr verwendet, da diese jetzt 527 ist
  DELETE AmAbPosition WHERE AmAbPositionsartID=303
  DELETE AmAbPositionsart WHERE AmAbPositionsartID=303

  -- 07.03.2008 : KKBB Korrekturen
  DELETE AmAbPosition WHERE AmAbPositionsartID IN (3062, 3067, 3162, 3167, 3221, 3222, 3224, 3241, 3242, 3283, 3233)
  DELETE AmAbPositionsart WHERE AmAbPositionsartID IN (3062, 3067, 3162, 3167, 3221, 3222, 3224, 3241, 3242, 3283, 3233)

  -- 11.03.2008 : KKBB Korrekturen
  DELETE AmAbPosition WHERE AmAbPositionsartID IN (3275, 3276, 3272)
  DELETE AmAbPositionsart WHERE AmAbPositionsartID IN (3275, 3276, 3272)



  -- =====================================================================================================================
  -- ALBV 
  -- =====================================================================================================================
  -- Hier den richtigen Typ einstellen
  -- Typ ABLV Typ 1
  SET @Typ = 1
  -- Typ übH Typ 2
  --  SET @Typ = 2

  -- Berechnung Anspruchsgrenze Elterneinkommen
  SET @Kind = 0
  SET @Parent = 10
  SET @Sort1 = 'A';
  --  Text
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung Anspruchsgrenze Elterneinkommen',
      10,  NULL,    @Typ, @Kind, @Sort1, '010',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Elterngrenze ',  -- bei Anzeige zusätzlich "alleinstehend" oder "verheiratet" oder "Konkubinat"
      11,  @Parent, @Typ, @Kind, @Sort1, '011',  0, 0,   ' ',       NULL,          NULL,     NULL,     'Elterngrenze',      NULL,
      NULL,    NULL,     'bei Anzeige zusätzlich "alleinstehend" oder "verheiratet" oder "Konkubinat", ebenso bei ConfigName1'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'zzgl. für Kinder',  -- bei Anzeige zusätzlich ev. (3x3900)
      12,  @Parent, @Typ, @Kind, @Sort1, '012',  0, 0,   'CHF',      'Kinder', NULL,     NULL,     'PauschaleProKind',  NULL,
      NULL,    'N0',     'Der Betrag rechnet sich aus Wert1 * Wert2 (Wert2 = Anzahl Kinder)'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Anspruchsgrenze Elterneinkommen*',
      13,  @Parent, @Typ, @Kind, @Sort1, '013',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Summe aus oberen Zeilen'


  -- Verdienstabhängiges Einkommen
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 30
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verdienstabhängiges Einkommen',
      30,  NULL,    @Typ, @Kind, @Sort1, '030',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Brutto Lohn 1',
      31,  @Parent, @Typ, @Kind, @Sort1, '031',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Brutto Lohn 2',
      32,  @Parent, @Typ, @Kind, @Sort1, '032',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Brutto Lohn 3',
      33,  @Parent, @Typ, @Kind, @Sort1, '033',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Anderer Lohn',
      34,  @Parent, @Typ, @Kind, @Sort1, '034',  1, 1,  'CHF',       ' ',   NULL,     1,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Jahreslohn',
      35,  @Parent, @Typ, @Kind, @Sort1, '035',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abzüglich AHV etc.',
      40,  @Parent, @Typ, @Kind, @Sort1, '040',  0, 0,  'CHF',       '%',           NULL,     NULL,     NULL,               'AHVAbzug',
      NULL,    'N2',     '% vom Total Lohn'
  /* : 29.10.2007 : wird nicht mehr verwendet 
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Kinderzulagen',  
      41,  @Parent, @Typ, @Kind, @Sort1, '041',  1, 1,  'CHF',       '',   NULL,     12,     NULL,                NULL,       
      NULL,    'N0',     'Fr Betrag für z.B. 3 Kinder'
  */
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Reingewinn aus Selbständigkeit',
      42,  @Parent, @Typ, @Kind, @Sort1, '042',  1, 1,  'CHF',       ' ',   NULL,     1,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Jahresverdienst',
      43,  @Parent, @Typ, @Kind, @Sort1, '043',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Jahreslohn - AHV + Kinderzulagen'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total-Verdienst ohne Abzüge*',
      44,  @Parent, @Typ, @Kind, @Sort1, '044',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  -- Verdienstabhängige Abzüge
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 60
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verdienstabhängige Abzüge',
      60,  NULL,    @Typ, @Kind, @Sort1, '060',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufsauslagen',
      61,  @Parent, @Typ, @Kind, @Sort1, '061',  1, 1,  'CHF',       ' ',   1900.00,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufliche Vorsorge',
      62,  @Parent, @Typ, @Kind, @Sort1, '062',  1, 1,  'CHF',       ' ',   NULL,     12,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abonnement, Fahrspesen ZVV',
      63,  @Parent, @Typ, @Kind, @Sort1, '063',  1, 1,  'Tg/Woche',   'Zone',        NULL,     NULL,     NULL,                NULL,
      'N0',    'N0',     'Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV, oder Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV ???'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Fahrspesen',
      64,  @Parent, @Typ, @Kind, @Sort1, '064',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verpflegung',
      65,  @Parent, @Typ, @Kind, @Sort1, '065',  1, 1,  'V320/N640', 'Tg/Woche',  320.00,     5,     NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Weiterbildung',
      66,  @Parent, @Typ, @Kind, @Sort1, '066',  1, 1,  'CHF',       ' ',   400.00,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'NBU-Abzug',
      67,  @Parent, @Typ, @Kind, @Sort1, '067',  1, 1,  'CHF',       ' ',   NULL,     12,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Berufsauslagen*',
      69,  @Parent, @Typ, @Kind, @Sort1, '069',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resutat'

  -- Berechnung des Verdienstes
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 80
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung des Verdienstes',
      80,  NULL,    @Typ, @Kind, @Sort1, '080',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL

  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Verdienst ohne Abzüge',
      81,  @Parent, @Typ, @Kind, @Sort1, '081',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzüglich Berufsauslagen',
      82,  @Parent, @Typ, @Kind, @Sort1, '082',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'anrechenbarer Lohn',
      83,  @Parent, @Typ, @Kind, @Sort1, '083',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Totalverdienst*',
      84,  @Parent, @Typ, @Kind, @Sort1, '084',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  -- Verdienstabhängiges Einkommen <<2>>
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Sort1 = 'E';
  SET @Parent = 130
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Verdienstabhängiges Einkommen',
      130, NULL,    @Typ, @Kind, @Sort1, '130',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Brutto Lohn 1',
      131, @Parent, @Typ, @Kind, @Sort1, '131',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Brutto Lohn 2',
      132, @Parent, @Typ, @Kind, @Sort1, '132',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Brutto Lohn 3',
      133, @Parent, @Typ, @Kind, @Sort1, '133',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Anderer Lohn',
      134, @Parent, @Typ, @Kind, @Sort1, '134',  1, 1,  'CHF',       ' ',   NULL,     1,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Jahreslohn',
      135, @Parent, @Typ, @Kind, @Sort1, '135',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abzüglich AHV etc.',
      140, @Parent, @Typ, @Kind, @Sort1, '140',  0, 0,  'CHF',       '%',           NULL,     NULL,     NULL,                'AHVAbzug',
      NULL,    'N2',     '% vom Total Lohn'
  /* : 29.10.2007 : wird nicht mehr verwendet 
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Kinderzulagen',  
      141, @Parent, @Typ, @Kind, @Sort1, '141',  1, 1,  'CHF',       NULL,   NULL,     12,     NULL,                NULL,       
      NULL,    'N0',     'Fr Betrag für z.B. 3 Kinder'
  */
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Reingewinn aus Selbständigkeit',
      142, @Parent, @Typ, @Kind, @Sort1, '142',  1, 1,  'CHF',       ' ',           NULL,     1,      NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Jahresverdienst',
      143, @Parent, @Typ, @Kind, @Sort1, '143',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Jahreslohn - AHV'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total-Verdienst ohne Abzüge*',
      145, @Parent, @Typ, @Kind, @Sort1, '145',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  -- Verdienstabhängige Abzüge (Doppelverdiener)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 160
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Verdienstabhängige Abzüge',
      160, NULL,    @Typ, @Kind, @Sort1, '160',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufsauslagen',
      161, @Parent, @Typ, @Kind, @Sort1, '161',  1, 1,  'CHF',       ' ',   1900.00,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufliche Vorsorge',
      162, @Parent, @Typ, @Kind, @Sort1, '162',  1, 1,  'CHF',       ' ',   NULL,     12,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abonnement, Fahrspesen ZVV',
      163, @Parent, @Typ, @Kind, @Sort1, '163',  1, 1,  'Tg/Woche',   'Zone',        NULL,     NULL,     NULL,                NULL,
      'N0',    'N0',     'Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV, oder Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV ???'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Fahrspesen',
      164, @Parent, @Typ, @Kind, @Sort1, '164',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verpflegung',
      165, @Parent, @Typ, @Kind, @Sort1, '165',  1, 1,  'V320/N640', 'Tg/Woche',  320.00,     5,     NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Weiterbildung',
      166, @Parent, @Typ, @Kind, @Sort1, '166',  1, 1,  'CHF',       ' ',   400.00,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'NBU-Abzug',
      167, @Parent, @Typ, @Kind, @Sort1, '167',  1, 1,  'CHF',       ' ',   NULL,     12,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Berufsauslagen*',
      169, @Parent, @Typ, @Kind, @Sort1, '169',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resultat'


  -- Berechnung des Verdienstes (Doppelverdiener)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 180
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Berechnung des Verdienstes',
      180, NULL,    @Typ, @Kind, @Sort1, '180',  0, 0,  NULL,        NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Verdienst ohne Abzüge',
      181, @Parent, @Typ, @Kind, @Sort1, '181',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzüglich Berufsauslagen',
      182, @Parent, @Typ, @Kind, @Sort1, '182',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL

  -- 25.03.2008 : war vorher 144
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abzug für Doppelverdiener',
      185, @Parent, @Typ, @Kind, @Sort1, '185',  0, 0,   ' ',       NULL,          NULL,     NULL,     'AbzugDoppelverdiener', NULL,
      NULL,    NULL,     'AbzugDoppelverdiener'
  -- 25.03.2008 : war vorher 183
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'anrechenbarer Lohn',
      188, @Parent, @Typ, @Kind, @Sort1, '188',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  -- 25.03.2008 : war vorher 184
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Totalverdienst*',
      189, @Parent, @Typ, @Kind, @Sort1, '189',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  -- Berechnung Familien Einkünfte
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 200
  SET @Sort1 = 'H'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung der Familieneinkünfte',
      200, NULL,    @Typ, @Kind, @Sort1, '200',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Totalverdienst',
      201, @Parent, @Typ, @Kind, @Sort1, '201',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Ehegattenalimente',
      202, @Parent, @Typ, @Kind, @Sort1, '202',  1, 1,  'CHF',       ' ',   NULL,     12,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Renten',
      203, @Parent, @Typ, @Kind, @Sort1, '203',  1, 1,  'CHF',       ' ',   NULL,     12,      NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Vermögenszinsen',
      204, @Parent, @Typ, @Kind, @Sort1, '204',  1, 1,  'CHF',       ' ',   NULL,     1,      NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Weitere Einkommen',
      205, @Parent, @Typ, @Kind, @Sort1, '205',  1, 1,  'CHF',       ' ',   NULL,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Familien-Einkünfte*',
      206, @Parent, @Typ, @Kind, @Sort1, '206',  0, 0,   ' ',       NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resultat'


  -- Familien Abzüge - Verdienstunabhängige Abzüge
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 220
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung der Familienabzüge',
      220, NULL,    @Typ, @Kind, @Sort1, '220',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Versicherungsabzug Kinder',
      221, @Parent, @Typ, @Kind, @Sort1, '221',  1, 0,  'CHF',         'Kinder',       1200,     NULL,     NULL,                NULL,
      NULL,    'N0',     'Anzahl Kinder * Betrag'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Versicherungsabzug Eltern',
      222, @Parent, @Typ, @Kind, @Sort1, '222',  1, 0,  'CHF',         'Erwachsene',    2400,    NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Alimente für Dritte',
      223, @Parent, @Typ, @Kind, @Sort1, '223',  1, 1,  'CHF',         ' ',             NULL,     12,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Beiträge Säule 3a',
      224, @Parent, @Typ, @Kind, @Sort1, '224',  1, 1,  'CHF',         ' ',             NULL,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Andere Abzüge 1',
      231, @Parent, @Typ, @Kind, @Sort1, '231',  1, 1,  'CHF',         ' ',             NULL,     12,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Andere Abzüge 2',
      232, @Parent, @Typ, @Kind, @Sort1, '232',  1, 1,  'CHF',         ' ',             NULL,     12,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Schuldzinsen',
      241, @Parent, @Typ, @Kind, @Sort1, '241',  1, 1,  'CHF',         ' ',             NULL,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Spenden (aus Steuererklärung)',
      242, @Parent, @Typ, @Kind, @Sort1, '242',  1, 1,  'CHF',         ' ',             300.00,   1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Abzüge*',
      249, @Parent, @Typ, @Kind, @Sort1, '249',  0, 0,   ' ',          NULL,            NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resultat'

  -- 28.11.2007 : Neuer Titel
  -- Berechnung Monatsanspruchsgrenze (Elterneinkommen)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 250
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Familieneinkünfte',
      250, NULL,    @Typ, @Kind, @Sort1, '250',  0, 0,   NULL,          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Einkünfte',
      255, @Parent, @Typ, @Kind, @Sort1, '255',  0, 0,   ' ',          NULL,            NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Abzüge',
      256, @Parent, @Typ, @Kind, @Sort1, '256',  0, 0,   ' ',          NULL,            NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total anrechenbares Einkommen*',
      259, @Parent, @Typ, @Kind, @Sort1, '259',  0, 0,   ' ',          NULL,            NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL

  -- Berechnung Monatsanspruchsgrenze (Elterneinkommen)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 270
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung anrechenbaren Vermögens',
      270, NULL,    @Typ, @Kind, @Sort1, '270',  0, 0,   NULL,        NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL

  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Reinvermögen',
      271, @Parent, @Typ, @Kind, @Sort1, '271',  1, 1,  'CHF',       ' ',   NULL,     1,      NULL,                NULL,
      NULL,    'N0',     NULL

  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Differenz Vermögen',
      272, @Parent, @Typ, @Kind, @Sort1, '272',  0, 0,  'CHF',       'CHF',      NULL,     NULL,     NULL,                'VermoegenFamilie',
      NULL,    'N2',     'verschieden für verh., alleinsteh. und Konkubinat'

  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'anrechenbares Vermögen',
      275, @Parent, @Typ, @Kind, @Sort1, '275',  0, 0,  'CHF',       'Anteil 1/15', NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL

  -- hew 13.11.2007 Vermögensobergrenze Maximaler Betrag für "Allein" und "Verh" aus Xconfig
  -- heo 14.11.2007 :
  -- albv, uebh
  -- falls Reinvermögen (272) grösser als dieser Betrag -> Familienonbergrenze = 0.00 (284)  
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Vermögensobergrenze',
      276, @Parent, @Typ, @Kind, @Sort1, '276',  0, 0,    ' ',      NULL,           NULL,     NULL,     NULL,                'VermoegenEltern',
      NULL,    'N2',     NULL



  -- Monatsanspruchsgrenze
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 280
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Monatsanspruchsgrenze',
      280, NULL,    @Typ, @Kind, @Sort1, '280',  0, 0,  NULL,            NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Einkommensgrenze',
      281, @Parent, @Typ, @Kind, @Sort1, '281',  0, 0,  ' ',        NULL,         NULL,     NULL,     'Elterngrenze',       NULL,
      NULL,    NULL,     'verschieden für verh., alleinsteh. und Konkubinat'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzügl. anrechenbares Einkommen',
      282, @Parent, @Typ, @Kind, @Sort1, '282',  0, 0,  ' ',        NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzügl. anrechenbares Vermögen',
      283, @Parent, @Typ, @Kind, @Sort1, '283',  0, 0,  ' ',        NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Jahresanspruchsgrenze',
      284, @Parent, @Typ, @Kind, @Sort1, '284',  0, 0,  ' ',        NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  ': 12 = Monatsanspruchsgrenze*',
      288, @Parent, @Typ, @Kind, @Sort1, '288',  0, 0,  ' ',        NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     'Div durch 12 Monate'

  -- Gültiger Monatsanspruch	
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 300
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Gültiger Monatsanspruch',
      300, NULL,    @Typ, @Kind, @Sort1, '300', 0, 0,  NULL,             NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Monatsanspruchsgrenze',
      301, @Parent, @Typ, @Kind, @Sort1, '301', 0, 0,  ' ',         NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  /*
  15.08.2007 : sozheo :
  Wird nicht mehr verwendet!!!
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Monatsanspruchsgrenze (Verpflichtung Schuldner)',  
      302, @Parent, @Typ, @Kind, @Sort1, '302', 1, 1,  'CHF',         'Monate',     NULL,     12.0,      NULL,                 NULL,      
      NULL,    NULL,     NULL
  */

  -- 28.11.2007 : H303 wird nicht mehr verwendet, da diese jetzt 527 ist
  --EXEC dbo.spAmAnspruchsberechnung_InsertRow
  --'Monatsanspruchsgrenze (Kindereinkommen)',  
  --    303, @Parent, @Typ, @Kind, @Sort1, '303', 0, 0,  ' ',         NULL,         NULL,     NULL,     NULL,                 NULL,      
  --    NULL,    NULL,     NULL

  /*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Bevorschussungsbetrag',  
      304, @Parent, @Typ, @Kind, @Sort1, '304', 0, 0,  'CHF',         NULL,         NULL,     NULL,     'maxBetrag',          NULL,      
      NULL,    NULL,     NULL
  */
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Grenze Auszahlung',
      305, @Parent, @Typ, @Kind, @Sort1, '305', 0, 0,   ' ',         NULL,         NULL,     NULL,     'GrenzeAuszahlung',  NULL,
      'N2',    NULL,     NULL


  -- Berechnung Monatsanspruch pro Kind	
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Sort1 = 'K'
  SET @Kind = 1
  SET @Parent = 500
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung Monatsanspruch',
      500, NULL,    @Typ, @Kind, @Sort1, '000',  0, 0,  NULL,           NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
/* 
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Reso-Nummer',   
      501, @Parent, @Typ, @Kind, @Sort1, '001',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                 NULL,      
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'ALBV berechtigt',   
      502, @Parent, @Typ, @Kind, @Sort1, '002',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                 NULL,      
      NULL,    NULL,     NULL
*/
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verpflichtung des Schuldners',
      --511, @Parent, @Typ, @Kind, @Sort1, '011',1, 0,  'CHF',      'pro Monat',    NULL,     1,      NULL,                 NULL,      
      511, @Parent, @Typ, @Kind, @Sort1, '011',  1, 1,  'CHF',      '0=man./1=Al.', NULL,     1,      NULL,                 NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Maximaler Bevorschussungsbetrag',
      512, @Parent, @Typ, @Kind, @Sort1, '012',  0, 0,  'CHF',       NULL,         NULL,     NULL,     'maxBetrag',          NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'berücksichtigte Verpflichtung',
      513, @Parent, @Typ, @Kind, @Sort1, '013',  0, 0,  'CHF',       NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Lohn',
      514, @Parent, @Typ, @Kind, @Sort1, '014',  1, 1,  'CHF',       ' ',          NULL,     12,       NULL,                 NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Renten',
      515, @Parent, @Typ, @Kind, @Sort1, '015',  1, 1,  'CHF',       ' ',          NULL,     12,       NULL,                 NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'andere Einkommen',
      516, @Parent, @Typ, @Kind, @Sort1, '016',  1, 1,  'CHF',       ' ',          NULL,     12,       NULL,                 NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufsauslagen pauschal',
      517, @Parent, @Typ, @Kind, @Sort1, '017',  1, 1,  'CHF',       ' ',          NULL,     1,        NULL,                 NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Fahrspesen',
      518, @Parent, @Typ, @Kind, @Sort1, '018',  1, 1,  'CHF',       ' ',          NULL,     12,       NULL,                 NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verpflegung',
      519, @Parent, @Typ, @Kind, @Sort1, '019',  1, 1,  'CHF',       ' ',          NULL,     1,       NULL,                 NULL,
      NULL,    'N0',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Anrechenbares Einkommen',
      521, @Parent, @Typ, @Kind, @Sort1, '021',  0, 0,  'CHF',       NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Kindereinkommensgrenze',
      525, @Parent, @Typ, @Kind, @Sort1, '025',  0, 0,  'CHF',       ':12 = Monat', NULL,     NULL,     'EinkommenKind',      ' ',
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abzüglich Kindereinkommen',
      526, @Parent, @Typ, @Kind, @Sort1, '026',  0, 0,  'CHF',       NULL,         NULL,     NULL,     'EinkommenKind',      ' ',
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Monatsanspruchsgrenze Kindereinkommen',
      527, @Parent, @Typ, @Kind, @Sort1, '027',  0, 0,   'CHF',    ':12 = Monat', NULL,     NULL,     NULL,                 NULL,
      NULL,    'N4',     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Anspruch (=max. Verpflichtung)',
      530, @Parent, @Typ, @Kind, @Sort1, '030',  0, 0,   ' ',       NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  -- 29.10.2007 : neu
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Effektiver Anspruch',
      531, @Parent, @Typ, @Kind, @Sort1, '031',  0, 0,   ' ',       NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL


  -- Gültiger Monatsanspruch pro Kind	
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Sort1 = 'X'
  SET @Parent = 720
  SET @Kind = 0
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Gültiger Monatsanspruch',
      720, NULL,    @Typ, @Kind, 'X',    '00',  0, 0,  ' ',             NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  -- für jedes Kind 1 mal:
  SET @Kind = 1
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'für Kind ',  -- Der Name wird hinten angefügt  
      730, @Parent, @Typ, @Kind, 'Y',    '01',  0, 0,   ' ',         NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  -- Total, immer nur einmal:
  SET @Kind = 0
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Gültiger Monatsanspruch Total',
      740, @Parent, @Typ, @Kind, 'Z',    '09',  0, 0,   ' ',         NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     'Darf Monatsanspruchsgrenze (Elterneinkommen) nicht übersteigen'




  -- =====================================================================================================================
  -- üBH (Typ = 2)
  -- =====================================================================================================================
  -- Ist genau gleich wie ALBV, ausser dass der ALBV-Betrag 650.-- aus Config jetzt nur noch 520.-- ist.
  -- Wir kopieren also alle Zeilen aus ALBV
  /*
  DECLARE @IDDiff INT
  SET @IDDiff = 2000 

  DECLARE 
    @PosArtID INT, 
    @ParentID INT

  -- Zuerst unnötige Zeilen löschen:
  DELETE AmAbPositionsArt 
  WHERE Typ = 2
  AND NOT AmAbPositionsartID IN (
    SELECT @IDDiff + A.AmAbPositionsArtID FROM AmAbPositionsArt A
    WHERE A.Typ = 1 )

  -- dann neu einfügen oder updaten:
  DECLARE CursorID CURSOR FOR
    SELECT AmAbPositionsartID, ParentID FROM AmAbPositionsart
    WHERE Typ = 1
  OPEN CursorID
  WHILE 1=1 BEGIN
    FETCH NEXT FROM CursorID INTO @PosArtID, @ParentID
    IF @@FETCH_STATUS <> 0 BREAK

    IF EXISTS(
      SELECT AmAbPositionsartID FROM AmAbPositionsart 
      WHERE AmAbPositionsartID = @PosArtID + @IDDiff
        AND Typ = 2 )
    BEGIN
      -- Vorhandene Zeile updaten:
      UPDATE AmAbPositionsart SET 
        ParentID = @ParentID + @IDDiff,
        Text = A.Text,
        Typ = 2,  -- üBH
        Kind = A.Kind,
        Sortierung1 = A.Sortierung1,
        Sortierung2 = A.Sortierung2,
        Mengeneinheit1 = A.Mengeneinheit1,
        Mengeneinheit2 = A.Mengeneinheit2,
        Editierbar1 = A.Editierbar1,
        Editierbar2 = A.Editierbar2,
        Default1 = A.Default1,
        Default2 = A.Default2,
        ConfigName1 = A.ConfigName1,
        ConfigName2 = A.ConfigName2,
        Format1 = A.Format1,
        Format2 = A.Format2,
        Kommentar = A.Kommentar
      FROM AmAbPositionsart A 
      WHERE AmAbPositionsartID = @PosArtID + @IDDiff 
        AND Typ = 2
        AND A.AmAbPositionsartID = @PosArtID
        AND A.Typ = 1

    END ELSE BEGIN
      -- Neue Zeile einfügen:
      INSERT INTO AmAbPositionsart (
        AmAbPositionsartID,
        ParentID,
        Text,
        Typ,
        Kind,
        Sortierung1,
        Sortierung2,
        Mengeneinheit1,
        Mengeneinheit2,
        Editierbar1,
        Editierbar2,
        Default1,
        Default2,
        ConfigName1,
        ConfigName2,
        Format1,
        Format2,
        Kommentar
      ) 
      SELECT
        @PosArtID + @IDDiff,
        @ParentID + @IDDiff,
        A.Text,
        2,  -- üBH
        A.Kind,
        A.Sortierung1,
        A.Sortierung2,
        A.Mengeneinheit1,
        A.Mengeneinheit2,
        A.Editierbar1,
        A.Editierbar2,
        A.Default1,
        A.Default2,
        A.ConfigName1,
        A.ConfigName2,
        A.Format1,
        A.Format2,
        A.Kommentar
      FROM AmAbPositionsart A 
      WHERE A.AmAbPositionsartID = @PosArtID
        AND A.Typ = 1

    END
  END
  CLOSE CursorID
  DEALLOCATE CursorID
  */

  -- =====================================================================================================================
  -- KKBB (Typ = 3)
  -- select * from AmAbPositionsart where AmAbPositionsartID > 3000 
  -- delete AmAbPositionsart where AmAbPositionsartID > 3000 and Typ = 3
  -- =====================================================================================================================
  SET @Typ = 3
  SET @Kind = 0
  SET @Parent = 3010
  SET @Sort1 = 'A';

  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung des Bedarfs',
      3010,  NULL,  @Typ, @Kind, @Sort1, '3010',  0, 0, NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Elterngrenze inklusive Kleinkind',  -- bei Anzeige zusätzlich "alleinstehend" oder "verheiratet" oder "Konkubinat"
      3011,@Parent, @Typ, @Kind, @Sort1, '3011',  0, 0, 'CHF',          NULL,          NULL,     NULL,     'Elterngrenze',      NULL,
      NULL,    NULL,     'bei Anzeige zusätzlich "alleinstehend" oder "verheiratet" oder "Konkubinat", ebenso bei ConfigName1'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'zzgl. für Kinder',  -- bei Anzeige zusätzlich ev. (3x3900)
      3012,@Parent, @Typ, @Kind, @Sort1, '3012',  0, 0, 'CHF',         'Kinder',       NULL,     NULL,     'PauschaleProKind',  NULL,
      NULL,    'N0',     'Der Betrag rechnet sich aus Wert1 * Wert2 (Wert2 = Anzahl Kinder)'

  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Monatsmiete',  -- bei Anzeige Monate x Monatsmiete eingeben
      3013,@Parent, @Typ, @Kind, @Sort1, '3013',  1, 1, 'CHF',         'Monate',      NULL,     12,     NULL,                NULL,
      NULL,    'N0',     '12 x Miete höchstens aber MaxJahresmiete'

  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Maximale Jahresmiete',  -- bei Anzeige Betrag aus MaxJahresmiete
      3014,@Parent, @Typ, @Kind, @Sort1, '3014',  0, 0,  'CHF',          NULL,          NULL,     NULL,     'MaxJahresmiete',    NULL,
      NULL,    NULL,     'Betrag aus MaxJahresmiete'

  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Bedarf*',
      3025,@Parent, @Typ, @Kind, @Sort1, '3025',  0, 0, ' ',            NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Summe aus oberen Zeilen'


  -- Verdienstabhängiges Einkommen
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3030
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verdienstabhängiges Einkommen',
      3030, NULL,   @Typ, @Kind, @Sort1, '3030',  0, 0, NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Netto Monatslohn',
      3031,@Parent, @Typ, @Kind, @Sort1, '3031',  1, 1, 'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Netto Reingewinn aus Selbständigkeit',
      3032,@Parent, @Typ, @Kind, @Sort1, '3032',  1, 0, 'CHF',          ' ',           NULL,      NULL,    NULL,                NULL,
      NULL,    'N0',     NULL

-- 07.03.2008 : Korrekturen KKBB
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abzug Erwerb Alleinstehende',
      3033,@Parent, @Typ, @Kind, @Sort1, '3033', 0, 0,  NULL,            NULL,           NULL,     NULL,       NULL,                NULL,
      NULL,    NULL,     'fix 5000.--, ev. noch in Config einbauen'


  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Verdienst ohne Abzüge*',
      3044,@Parent, @Typ, @Kind, @Sort1, '3044',  0, 0,  ' ',            NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL

  -- Verdienstabhängige Abzüge
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3060
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verdienstabhängige Abzüge',
      3060,NULL,   @Typ, @Kind, @Sort1, '3060',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufsauslagen',
      3061,@Parent, @Typ, @Kind, @Sort1, '3061',  1, 1, 'CHF',          ' ',           1900.00,  1,        NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung


-- 07.03.2008 : Korrekturen KKBB
-- immer weg
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufliche Vorsorge', 
      3062,@Parent, @Typ, @Kind, @Sort1, '3062',  1, 1, 'CHF',          ' ',           NULL,     12,        NULL,                NULL,       
      NULL,    'N0',     'Eingabe'
*/

  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abonnement, Fahrspesen ZVV',
      3063,@Parent, @Typ, @Kind, @Sort1, '3063',  1, 1, 'Tg/Woche',     'Zone',        NULL,     NULL,     NULL,                NULL,
      'N0',    'N0',     'Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV, oder Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV ???'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Fahrspesen',
      3064,@Parent, @Typ, @Kind, @Sort1, '3064',  1, 1, 'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     'Eingabe'

  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  -- Verpflegung nicht grösser als 600.--, Anzahl Tage <= 5
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verpflegung',
      3065,@Parent, @Typ, @Kind, @Sort1, '3065',  1, 1, 'V320/N640',    'Tg/Woche',    320.00,   5,        NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Weiterbildung',
      3066,@Parent, @Typ, @Kind, @Sort1, '3066',  1, 1, 'CHF',          ' ',           400.00,   1,        NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung


-- 07.03.2008 : Korrekturen KKBB
-- immer weg
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'NBU-Abzug',  
      3067,@Parent, @Typ, @Kind, @Sort1, '3067',  1, 1, 'CHF',          ' ',           NULL,     12,        NULL,                NULL,       
      NULL,    'N0',     'Eingabe'
*/
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Berufsauslagen*',
      3075,@Parent, @Typ, @Kind, @Sort1, '3075',  0, 0,  ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resultat'

  -- Berechnung des Verdienstes
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3080
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung des Verdienstes',
      3080, NULL,   @Typ, @Kind, @Sort1, '3080',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Verdienst ohne Abzüge',
      3081,@Parent, @Typ, @Kind, @Sort1, '3081', 0, 0,   ' ',           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzüglich Berufsauslagen',
      3082,@Parent, @Typ, @Kind, @Sort1, '3082', 0, 0,   ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Anrechenbarer Verdienst*',
      3084,@Parent, @Typ, @Kind, @Sort1, '3084', 0, 0,   ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  -- Verdienstabhängiges Einkommen <<2>>
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Sort1 = 'E';
  SET @Parent = 3130
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Verdienstabhängiges Einkommen',
      3130,NULL,    @Typ, @Kind, @Sort1, '3130', 0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Netto Monatslohn',
      3131,@Parent, @Typ, @Kind, @Sort1, '3131',  1, 1,  'CHF',         ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Reingewinn aus Selbständigkeit',
      3142,@Parent, @Typ, @Kind, @Sort1, '3142', 1, 1,  'CHF',          ' ',           NULL,     1,         NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Verdienst ohne Abzüge*',
      3145,@Parent, @Typ, @Kind, @Sort1, '3145', 0, 0,   ' ',            NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  -- Verdienstabhängige Abzüge (Doppelverdiener)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3160
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Verdienstabhängige Abzüge',
      3160, NULL,   @Typ, @Kind, @Sort1, '3160', 0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufsauslagen',
      3161,@Parent, @Typ, @Kind, @Sort1, '3161', 1, 1,  'CHF',          ' ',           1900.00,  1,        NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung


-- 07.03.2008 : Korrekturen KKBB
-- immer weg
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berufliche Vorsorge',  
      3162,@Parent, @Typ, @Kind, @Sort1, '3162', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,       
      NULL,    'N0',     'Eingabe'
*/
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Abonnement, Fahrspesen ZVV',
      3163,@Parent, @Typ, @Kind, @Sort1, '3163', 1, 1,  'Tg/Woche',     'Zone',        NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     'Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV, oder Eingabe 3.00 = Tage / Zahl 2 = Zone ZVV ???'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Fahrspesen',
      3164,@Parent, @Typ, @Kind, @Sort1, '3164', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verpflegung',
      3165,@Parent, @Typ, @Kind, @Sort1, '3165', 1, 1,  'V320/N640',    'Tg/Woche',    320.00,    5,       NULL,                NULL,
      'N0',    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Weiterbildung',
      3166,@Parent, @Typ, @Kind, @Sort1, '3166', 1, 1,  'CHF',          ' ',           400.00,     1,      NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung


-- 07.03.2008 : Korrekturen KKBB
-- immer weg
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'NBU-Abzug',  
      3167,@Parent, @Typ, @Kind, @Sort1, '3167', 1, 1,  'CHF',          ' ',           NULL,     12,        NULL,                NULL,       
      NULL,    'N0',     'Eingabe'
*/
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Berufsauslagen*',
      3175,@Parent, @Typ, @Kind, @Sort1, '3175', 0, 0,  ' ',            NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resultat'


  -- Berechnung des Verdienstes (Doppelverdiener)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3180
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Berechnung des Verdienstes',
      3180, NULL,   @Typ, @Kind, @Sort1, '3180',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Verdienst ohne Abzüge',
      3181,@Parent, @Typ, @Kind, @Sort1, '3181', 0, 0,  ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzüglich Berufsauslagen',
      3182,@Parent, @Typ, @Kind, @Sort1, '3182', 0, 0,  ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Anrechenbarer Verdienst*',
      3184,@Parent, @Typ, @Kind, @Sort1, '3184', 0, 0,  ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL


  -- Berechnung Familien Einkünfte
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3200
  SET @Sort1 = 'H'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Verdienstunabhängige Einkünfte',
      3200, NULL,   @Typ, @Kind, @Sort1, '3200', 0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Totalverdienst',
      3201,@Parent, @Typ, @Kind, @Sort1, '3201', 0, 0,   ' ',           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Zweitverdiener Totalverdienst',
      3202,@Parent, @Typ, @Kind, @Sort1, '3202', 0, 0,   ' ',           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Ehegattenalimente',
      3203,@Parent, @Typ, @Kind, @Sort1, '3203', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Kinderalimente',
      3204,@Parent, @Typ, @Kind, @Sort1, '3204', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Fremde Kinderzulagen',
      3205,@Parent, @Typ, @Kind, @Sort1, '3205', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Renten',
      3206,@Parent, @Typ, @Kind, @Sort1, '3206', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Vermögenszinsen',
      3207,@Parent, @Typ, @Kind, @Sort1, '3207', 1, 1,  'CHF',          ' ',            NULL,     1,       NULL,                NULL,
      NULL,    'N0',     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Weitere Einkommen',
      3208,@Parent, @Typ, @Kind, @Sort1, '3208', 1, 1,  'CHF',          ' ',            NULL,     1,       NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Einkünfte*',
      3215,@Parent, @Typ, @Kind, @Sort1, '3215', 0, 0,  ' ',           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resultat'


  -- Familien Abzüge - Verdienstunabhängige Abzüge
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3220
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  --'Berechnung der verdienstunabhängigen Abzüge',
  'Verdienstunabhängige Abzüge',
      3220, NULL,   @Typ, @Kind, @Sort1, '3220', 0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung

-- 07.03.2008 : Korrekturen KKBB
-- immer weg
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Versicherungsabzug Kinder',  
      3221,@Parent, @Typ, @Kind, @Sort1, '3221', 0, 0,  'CHF',          'Kinder',      NULL,     NULL,     'VersicherungsabzugKind',  NULL, 
      NULL,    'N0',     'Anzahl Kinder * Betrag'
*/
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung


-- 07.03.2008 : Korrekturen KKBB
-- immer weg
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Versicherungsabzug Eltern',  
      3222,@Parent, @Typ, @Kind, @Sort1, '3222', 0, 0,  'CHF',         'Erwachsene',   NULL,     NULL,     'VersicherungsabzugEltern', NULL, 
      NULL,    'N0',     NULL
*/
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Alimente für Dritte',
      3223,@Parent, @Typ, @Kind, @Sort1, '3223', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung

-- 07.03.2008 : Korrekturen KKBB
-- immer weg
  /*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Beiträge Säule 3a',  
      3224,@Parent, @Typ, @Kind, @Sort1, '3224', 1, 1,  'CHF',          ' ',           NULL,     1,       NULL,                NULL,       
      NULL,    'N0',     'Eingabe'
  */
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Andere Abzüge 1',
      3231,@Parent, @Typ, @Kind, @Sort1, '3231', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Andere Abzüge 2',
      3232,@Parent, @Typ, @Kind, @Sort1, '3232', 1, 1,  'CHF',          ' ',           NULL,     12,       NULL,                NULL,
      NULL,    'N0',     'Eingabe'
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung



-- 07.03.2008 : Korrekturen KKBB
-- immer weg
  /*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Schuldzinsen',  
      3241,@Parent, @Typ, @Kind, @Sort1, '3241', 1, 1,  'CHF',          ' ',           NULL,     1,        NULL,                NULL,       
      NULL,    'N0',     'Eingabe'
  */
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung

-- 07.03.2008 : Korrekturen KKBB
-- immer weg
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Spenden (aus Steuererklärung)',  
      3242,@Parent, @Typ, @Kind, @Sort1, '3242', 1, 1,  'CHF',          ' ',           300.00,   1,        NULL,                NULL,       
      NULL,    'N0',     'Eingabe'
*/
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Abzüge*',
      3249,@Parent, @Typ, @Kind, @Sort1, '3249', 0, 0,  ' ',            NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     'Resultat'


  -- Berechnung des Verdienstes (Doppelverdiener)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3250
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Familieneinkünfte',
      3250, NULL,   @Typ, @Kind, @Sort1, '3250', 0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Einkünfte',
      3255,@Parent, @Typ, @Kind, @Sort1, '3255', 0, 0,  ' ',           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Abzüge',
      3256,@Parent, @Typ, @Kind, @Sort1, '3256', 0, 0,  ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Anrechenbares Einkommen*',
      3259,@Parent, @Typ, @Kind, @Sort1, '3259', 0, 0,  ' ',          NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL

  -- Berechnung Monatsanspruchsgrenze (Elterneinkommen)
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3270
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Reinvermögen',
      3270, NULL,  @Typ, @Kind, @Sort1, '3270',  0, 0,  NULL,           NULL,          NULL,     NULL,     NULL,                NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Reinvermögen',
      3271,@Parent, @Typ, @Kind, @Sort1, '3271', 1, 0,  'CHF',          'CHF',           NULL,     1,        NULL,                NULL,
      NULL,    'N2',     NULL
/*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Vermögensobergrenze',  
      3272,@Parent, @Typ, @Kind, @Sort1, '3272', 0, 0,  'CHF',          'CHF',         NULL,     NULL,     NULL,                'VermoegenFamilie',       
      NULL,    'N2',     'verschieden für verheiratet, alleinstehend und Konkubinat'
*/


/*
für allr KKBB immer weg:
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'anrechenbares Vermögen',  
      3275,@Parent, @Typ, @Kind, @Sort1, '3275', 0, 0,  'CHF',          'Anteil 1/15', NULL,     NULL,     NULL,                'AnteilEinkommenVermoegen',       
      NULL,    'N4',     NULL
  -- hew 13.11.2007 Vermögensobergrenze Maximaler Betrag für "Allein" und "Verh" aus Xconfig
  -- falls reinvermögen (3272) gtösser als dieser Berttag -> alles 0.00 (3284)  
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Vermögensobergrenze',  
      3276, @Parent, @Typ, @Kind, @Sort1, '3276',  0, 0,  'CHF',        NULL,          NULL,     NULL,     NULL,                'VermoegenEltern',       
      NULL,    'N2',     NULL
*/


  -- Monatsanspruch berechnen
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2      Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  SET @Parent = 3280
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Berechnung des Monatsanspruchs',
      3280,NULL,  @Typ, @Kind, @Sort1,  '3280',  0, 0,  NULL,            NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Bedarf',
      3281,@Parent, @Typ, @Kind, @Sort1, '3281', 0, 0,  ' ',          NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     'Total Bedarf'
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzügl. anrechenbares Einkommen',
      3282,@Parent, @Typ, @Kind, @Sort1, '3282', 0, 0,  ' ',          NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL

-- 07.03.2008 : Korrekturen KKBB
-- immer weg 3283
  /*
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'abzügl. anrechenbares Vermögen',  
      3283,@Parent, @Typ, @Kind, @Sort1, '3283', 0, 0,  ' ',          NULL,         NULL,     NULL,     NULL,                 NULL,      
      NULL,    NULL,     NULL
   */
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Jahresanspruch',
      3284,@Parent, @Typ, @Kind, @Sort1, '3284', 0, 0,  ' ',          NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     NULL
  --  ID   Parent   Typ   Kind   Sort1   Sort2   Edit.  Einheit 1       Einheit 2     Default1, Default2, Config 1             Config 2    
  --  Format1  Format2   Bemerkung
  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Monatsanspruch (1/12 Jahresanspruch)',
      3288,@Parent, @Typ, @Kind, @Sort1, '3288', 0, 0,  ' ',          NULL,        NULL,     NULL,     NULL,                 NULL,
      NULL,    'N2',     'pro Monat'

  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Maximaler Monatsanspruch',
      3289,@Parent, @Typ, @Kind, @Sort1, '3289', 0, 0,  'CHF',            NULL,         NULL,     NULL,     'maxBetrag',          NULL,
      NULL,    NULL,     'maximaler Monatsanspruch'

  EXEC dbo.spAmAnspruchsberechnung_InsertRow
  'Total Anspruch',
      3290,@Parent, @Typ, @Kind, @Sort1, '3290', 0, 0,   ' ',            NULL,         NULL,     NULL,     NULL,                 NULL,
      NULL,    NULL,     'Total'


  -- 25.03.2008 : Korrektur bestehender Daten
  -- select * from AmAbPosition where ParentID = 180
  IF EXISTS(SELECT TOP 1 * FROM AmAbPositionsart WHERE AmAbPositionsartID IN (144, 183, 184))
  BEGIN

    UPDATE AmAbPosition SET
      AmAbPositionsartID = 185,
      ParentID = 180,
      Sortierung2 = '185'
    WHERE AmAbPositionsartID = 144

    UPDATE AmAbPosition SET
      AmAbPositionsartID = 188,
      Sortierung2 = '188'
    WHERE AmAbPositionsartID = 183

    UPDATE AmAbPosition SET
      AmAbPositionsartID = 189,
      Sortierung2 = '189'
    WHERE AmAbPositionsartID = 184

    DELETE AmAbPositionsart WHERE AmAbPositionsartID IN (144, 183, 184)
  END

END

