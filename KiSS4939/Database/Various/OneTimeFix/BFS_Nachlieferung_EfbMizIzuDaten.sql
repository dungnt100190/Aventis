/*
Test mit Andi, BSS 4.2.46
Pantaleo, Lucio Battista (19.12.1969) - [Id: 630]
Budget ID = 370422

select varname, * from BgPositionsart
where varname like '10.%'

select K.*, P.varname, P.* from BgPositionsart P
left join bgKostenart K on K.bgKostenartID = P.bgKostenartID
where varname like '10.2%'

-- Kostenart.KontoNR: IZU = 101, MIZ = 103, EFB = 105


select top 100 buchungstext, * from bgPosition
where buchungstext like 'EFB%[0-9]%-%[0-9]%'


select top 100 * from bfsdossierPerson



*/


DECLARE 
  @BFSDossierID INT,
  @Stichtag INT,
  @BFSDossierPersonID INT,
  @BaPersonLaufnummer INT,
  @FaLeistungID INT,
  @BaPersonID INT, 
  @BgBudgetID INT, 
  @BFSKatalogVersionID INT,
  @BFSFrage_MIZ_Betrag INT,
  @BFSFrage_MIZ_JaNein INT,
  @BFSFrage_IZU_Betrag INT,
  @BFSFrage_IZU_JaNein INT,
  @BFSFrage_EFB_Betrag INT,
  @BFSFrage_EFB_JaNein INT,
  @BetragMIZ MONEY,
  @BetragIZU MONEY,
  @BetragEFB MONEY,
  @BetragMIZ_alt MONEY,
  @BetragIZU_alt MONEY,
  @BetragEFB_alt MONEY,
  @Budget VARCHAR(100),
  @PersonName VARCHAR(100),
  @Anfang VARCHAR(100),
  @InstNr VARCHAR(200),

  @anzPersHH INT,
  @anzPersUE INT,
  @betragZugesprochen MONEY,
  @datum1Zahlung DATETIME,
  @datumZZahlung DATETIME,
  @betragGesamt MONEY,
  @AHV VARCHAR(200),
  @VersNr VARCHAR(200),
  @Geburt VARCHAR(200),
  @Geschlecht VARCHAR(200),
  @Zivilstand VARCHAR(200),
  @Nationalitaet VARCHAR(200),
  @Aufenthalt VARCHAR(200),

  @bfsFrage_anzPersHH INT,
  @bfsFrage_anzPersUE INT,
  @bfsFrage_betragZugesprochen INT,
  @bfsFrage_datum1Zahlung INT,
  @bfsFrage_datumZZahlung INT,
  @bfsFrage_betragGesamt INT,
  @bfsFrage_AHV INT,
  @bfsFrage_VersNr INT,
  @bfsFrage_Geburt INT,
  @bfsFrage_Geschlecht INT,
  @bfsFrage_Zivilstand INT,
  @bfsFrage_Nationalitaet INT,
  @bfsFrage_Aufenthalt INT
  
  -- -------------------------------------------------------------------------------
  
  
DECLARE @tmp TABLE (
  DossierID INT, 
  Stichtag INT,
  BaPersonLaufnummer INT, 
  
  anzPersHH INT,
  anzPersUE INT,
  betragZugesprochen MONEY,
  datum1Zahlung DATETIME,
  datumZZahlung DATETIME,
  betragGesamt MONEY,
  AHV VARCHAR(200),
  VersNr VARCHAR(200),
  Geburt VARCHAR(200),
  Geschlecht VARCHAR(200),
  Zivilstand VARCHAR(200),
  Nationalitaet VARCHAR(200),
  Aufenthalt VARCHAR(200),

  
  MIZBetrag MONEY, 
  IZUBetrag MONEY, 
  EFBBetrag MONEY,
  MIZBetrag_alt MONEY, 
  IZUBetrag_alt MONEY, 
  EFBBetrag_alt MONEY,

  BaPersonID INT, 
  BgBudgetID INT, 
  Budget VARCHAR(100),
  PersonName VARCHAR(100),
  Anfang VARCHAR(100))
  
SET @BFSKatalogVersionID = dbo.fnBFSGetKatalogVersion(2010)

SELECT @InstNr = CONVERT(VARCHAR(200), dbo.fnXConfig('System\Sostat\Institution', GETDATE()));


-- MIZ
-- IZU = 10.222, MIZ = 10.212, EFB = 10.232
SELECT @BFSFrage_MIZ_JaNein = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '10.211'
SELECT @BFSFrage_MIZ_Betrag = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '10.212'

-- IZU
-- IZU = 10.222, MIZ = 10.212, EFB = 10.232
SELECT @BFSFrage_IZU_JaNein = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '10.221'
SELECT @BFSFrage_IZU_Betrag = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '10.222'

-- EFB
-- IZU = 10.222, MIZ = 10.212, EFB = 10.232
SELECT @BFSFrage_EFB_JaNein = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '10.231'
SELECT @BFSFrage_EFB_Betrag = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '10.232'
  
-- ----------------------------------------------------------
SELECT @bfsFrage_anzPersHH = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '4.08'

SELECT @bfsFrage_anzPersUE = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '4.09'

SELECT @bfsFrage_betragZugesprochen = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '15.052'

SELECT @bfsFrage_datum1Zahlung = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '15.06'

SELECT @bfsFrage_datumZZahlung = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '16.02'

SELECT @bfsFrage_betragGesamt = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '15.08'

SELECT @bfsFrage_AHV = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '1.03'

SELECT @bfsFrage_VersNr = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '1.05'

SELECT @bfsFrage_Geburt = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '4.01'

SELECT @bfsFrage_Geschlecht = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '4.02'

SELECT @bfsFrage_Zivilstand = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '4.03'

SELECT @bfsFrage_Nationalitaet = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '4.04'

SELECT @bfsFrage_Aufenthalt = BFSFrageID FROM BFSFrage
WHERE BFSKatalogVersionID = @BFSKatalogVersionID 
  AND Variable = '4.05'

-- ----------------------------------------------------------



DECLARE curDossiers CURSOR FAST_FORWARD FOR
  SELECT P.BFSDossierID, D.Stichtag, P.PersonIndex, P.bfsdossierPersonID, D.FaLeistungID, P.BaPersonID, B.Name + ISNULL(' ' + B.Vorname, ''), 
  CASE WHEN D.Stichtag = 1 THEN 'Stichtag' ELSE 'Anfang' END
  FROM bfsdossier D
  INNER JOIN bfsdossierPerson P on P.BFSDossierID = D.BFSDossierID
  LEFT JOIN baPerson B on B.BaPersonID = P.BaPersonID
  WHERE D.Jahr = 2010
  --and P.BaPersonID = 630 
  --ORDER BY B.Name + ISNULL(' ' + B.Vorname, ''), D.Stichtag, D.FaLeistungID 
  --ORDER BY P.BFSDossierID, D.Stichtag, P.PersonIndex 
  ORDER BY D.FaLeistungID, D.Stichtag, P.PersonIndex 
  
  
OPEN curDossiers
WHILE (1 = 1)
BEGIN

  FETCH NEXT FROM curDossiers INTO 
    @BFSDossierID, @Stichtag, @BaPersonLaufnummer, @BFSDossierPersonID, @FaLeistungID, @BaPersonID, @PersonName, @Anfang;
  IF (@@FETCH_STATUS != 0) BREAK;

  /*  
  PRINT '------------------------------------------------------'
  PRINT 'BFSDossierID = ' + CONVERT(VARCHAR(MAX), @FaLeistungID)
  PRINT 'BaPersonID = ' + CONVERT(VARCHAR(MAX), @BaPersonID)
  PRINT 'Name = ' + ISNULL(CONVERT(VARCHAR(MAX), @BaPersonID)
  */
  
  -- letztes Budget suchen
  SELECT TOP 1 
    @BgBudgetID = BgBudgetID,
    @Budget = 'Monat ' + CONVERT(VARCHAR, Monat)
  FROM BgBudget B
  INNER JOIN BgFinanzplan FP on FP.BgFinanzplanID = B.BgFinanzplanID
  WHERE FP.FaLeistungID = @FaLeistungID AND B.Jahr = 2010 AND B.MasterBudget = 0
  ORDER BY B.Monat DESC


  -- -------------------------------------------------------------------------------
  SET @anzPersHH = NULL
  SELECT TOP 1 @anzPersHH = CONVERT(INT, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_anzPersHH
    
  SET @anzPersUE = NULL
  SELECT TOP 1 @anzPersUE = CONVERT(INT, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_anzPersUE

  SET @betragZugesprochen = NULL
  SELECT TOP 1 @betragZugesprochen = CONVERT(MONEY, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_betragZugesprochen

  SET @datum1Zahlung = NULL
  SELECT TOP 1 @datum1Zahlung = CONVERT(DATETIME, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_datum1Zahlung

  SET @datumZZahlung = NULL
  SELECT TOP 1 @datumZZahlung = CONVERT(DATETIME, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_datumZZahlung

  SET @betragGesamt = NULL
  SELECT TOP 1 @betragGesamt = CONVERT(MONEY, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_betragGesamt

  SET @AHV = NULL
  SELECT TOP 1 @AHV = CONVERT(VARCHAR(200), Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_AHV
    
  SET @VersNr = NULL
  SELECT TOP 1 @VersNr = CONVERT(VARCHAR(200), Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_VersNr
    
  SET @Geburt = NULL
  SELECT TOP 1 @Geburt = CONVERT(VARCHAR(200), Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_Geburt

  SET @Geschlecht = NULL
  SELECT TOP 1 @Geschlecht = CONVERT(VARCHAR(200), Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_Geschlecht

  SET @Zivilstand = NULL
  SELECT TOP 1 @Zivilstand = CONVERT(VARCHAR(200), Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_Zivilstand
    
  SET @Nationalitaet = NULL
  SELECT TOP 1 @Nationalitaet = CONVERT(VARCHAR(200), Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_Nationalitaet

  SET @Aufenthalt = NULL
  SELECT TOP 1 @Aufenthalt = CONVERT(VARCHAR(200), Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_Aufenthalt

  -- -------------------------------------------------------------------------------
  
  -- -------------------------------------------------------------------------------
  -- IZU = 10.222, MIZ = 10.212, EFB = 10.232
  -- ALTE BETRAEGE
  -- MIZ Betrag
  SET @BetragMIZ_alt = NULL
  SELECT TOP 1 @BetragMIZ_alt = CONVERT(MONEY, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_MIZ_Betrag
  -- IZU Betrag
  SET @BetragIZU_alt = NULL
  SELECT TOP 1 @BetragIZU_alt = CONVERT(MONEY, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_IZU_Betrag
  -- EFB Betrag
  SET @BetragEFB_alt = NULL
  SELECT TOP 1 @BetragEFB_alt = CONVERT(MONEY, Wert) FROM BFSWert 
  WHERE BFSDossierID = @BFSDossierID AND BFSDossierPersonID = @BFSDossierPersonID
    AND BFSFrageID = @BFSFrage_EFB_Betrag
  -- -------------------------------------------------------------------------------

  
  -- -------------------------------------------------------------------------------
  -- NEUE BETRAEGE
  -- MIZ Betrag suchen
  -- IZU = 10.222, MIZ = 10.212, EFB = 10.232
  SET @BetragMIZ = NULL
  SELECT @BetragMIZ = COALESCE(
  (
  SELECT TOP 1 P.Betrag
  FROM BgPosition P
  LEFT JOIN BgPositionsart A on A.BgPositionsartID = P.BgPositionsartID
  LEFT JOIN BgKostenart K on K.BgKostenartID = A.BgKostenartID
  WHERE P.BgBudgetID = @BgBudgetID
  AND P.BgSpezKontoID IS NULL
  AND P.BaPersonID = @BaPersonID
  AND A.VarName = '10.212' 
  AND EXISTS ( 
    SELECT TOP 1 1 FROM KbBuchungKostenart B
    INNER JOIN KbBuchung C ON C.KbBuchungID = B.KbBuchungID
    WHERE B.BgPositionID = P.BgPositionID
    --  2 = freigegeben
    --  3 = ZahlauftragErstellt, 
    --  6 = ausgeglichen, 
    -- 10 = teilweise ausgeglichen, 
    -- 13 = verbucht
    AND (C.KbBuchungStatusCode IN (3,6,10,13) OR (C.KbBuchungStatusCode = 2 AND C.KbAuszahlungsArtCode = 103))
    )
  ),
  (
  SELECT TOP 1 P.Betrag
  FROM BgPosition P
  LEFT JOIN BgSpezKonto S ON S.BgSpezKontoID = P.BgSpezKontoID
  LEFT JOIN BgKostenart KA on KA.BgKostenartID = S.BgKostenartID
  WHERE P.BgBudgetID = @BgBudgetID
  AND P.BaPersonID = @BaPersonID
  AND (P.Buchungstext like  '[0-9]%-%[0-9]%' OR P.Buchungstext like  'MIZ%' OR P.Buchungstext like  '%MIZ%') 
  AND (S.NameSpezKonto like 'MIZ%' OR S.NameSpezKonto like '%MIZ%')
  --AND P.BgKategorieCode = 2 -- Ausgabe, ohne Einzelzahlungen 101
  AND P.BgBewilligungStatusCode = 5 -- Bewilligung erteilt

  AND EXISTS ( 
    SELECT TOP 1 1 FROM KbBuchungKostenart B
    INNER JOIN KbBuchung C ON C.KbBuchungID = B.KbBuchungID
    WHERE B.BgPositionID = P.BgPositionID
    --  2 = freigegeben
    --  3 = ZahlauftragErstellt, 
    --  6 = ausgeglichen, 
    -- 10 = teilweise ausgeglichen, 
    -- 13 = verbucht
    AND (C.KbBuchungStatusCode IN (3,6,10,13) OR (C.KbBuchungStatusCode = 2 AND C.KbAuszahlungsArtCode = 103))
    )
  ))  

  -- IZU Betrag suchen
  -- IZU = 10.222, MIZ = 10.212, EFB = 10.232
  SET @BetragIZU = NULL
  SELECT @BetragIZU = COALESCE(
  (
  SELECT TOP 1 P.Betrag
  FROM BgPosition P
  LEFT JOIN BgPositionsart A on A.BgPositionsartID = P.BgPositionsartID
  LEFT JOIN BgKostenart K on K.BgKostenartID = A.BgKostenartID
  WHERE P.BgBudgetID = @BgBudgetID
  AND P.BgSpezKontoID IS NULL
  AND P.BaPersonID = @BaPersonID
  AND A.VarName = '10.222' 
  AND EXISTS ( 
    SELECT TOP 1 1 FROM KbBuchungKostenart B
    INNER JOIN KbBuchung C ON C.KbBuchungID = B.KbBuchungID
    WHERE B.BgPositionID = P.BgPositionID
    --  2 = freigegeben
    --  3 = ZahlauftragErstellt, 
    --  6 = ausgeglichen, 
    -- 10 = teilweise ausgeglichen, 
    -- 13 = verbucht
    AND (C.KbBuchungStatusCode IN (3,6,10,13) OR (C.KbBuchungStatusCode = 2 AND C.KbAuszahlungsArtCode = 103))
    )
  ),
  (
  SELECT TOP 1 P.Betrag
  FROM BgPosition P
  LEFT JOIN BgSpezKonto S ON S.BgSpezKontoID = P.BgSpezKontoID
  LEFT JOIN BgKostenart KA on KA.BgKostenartID = S.BgKostenartID
  WHERE P.BgBudgetID = @BgBudgetID
  AND P.BaPersonID = @BaPersonID
  AND (P.Buchungstext like  '[0-9]%-%[0-9]%' OR P.Buchungstext like  'IZU%' OR P.Buchungstext like  '%IZU%') 
  AND (S.NameSpezKonto like 'IZU%' OR S.NameSpezKonto like '%IZU%')
  --AND P.BgKategorieCode = 2 -- Ausgabe, ohne Einzelzahlungen 101
  AND P.BgBewilligungStatusCode = 5 -- Bewilligung erteilt
  AND EXISTS ( 
    SELECT TOP 1 1 FROM KbBuchungKostenart B
    INNER JOIN KbBuchung C ON C.KbBuchungID = B.KbBuchungID
    WHERE B.BgPositionID = P.BgPositionID
    --  2 = freigegeben
    --  3 = ZahlauftragErstellt, 
    --  6 = ausgeglichen, 
    -- 10 = teilweise ausgeglichen, 
    -- 13 = verbucht
    AND (C.KbBuchungStatusCode IN (3,6,10,13) OR (C.KbBuchungStatusCode = 2 AND C.KbAuszahlungsArtCode = 103))
    )
  ))  


  -- EFB Betrag suchen
  -- IZU = 10.222, MIZ = 10.212, EFB = 10.232
  SET @BetragEFB = NULL
  SELECT @BetragEFB = COALESCE(
  (
  SELECT TOP 1 P.Betrag
  FROM BgPosition P
  LEFT JOIN BgPositionsart A on A.BgPositionsartID = P.BgPositionsartID
  LEFT JOIN BgKostenart K on K.BgKostenartID = A.BgKostenartID
  WHERE P.BgBudgetID = @BgBudgetID
  AND P.BgSpezKontoID IS NULL
  AND P.BaPersonID = @BaPersonID
  AND A.VarName = '10.232' 
  AND EXISTS ( 
    SELECT TOP 1 1 FROM KbBuchungKostenart B
    INNER JOIN KbBuchung C ON C.KbBuchungID = B.KbBuchungID
    WHERE B.BgPositionID = P.BgPositionID
    --  2 = freigegeben
    --  3 = ZahlauftragErstellt, 
    --  6 = ausgeglichen, 
    -- 10 = teilweise ausgeglichen, 
    -- 13 = verbucht
    AND (C.KbBuchungStatusCode IN (3,6,10,13) OR (C.KbBuchungStatusCode = 2 AND C.KbAuszahlungsArtCode = 103))
    )
  ),
  (
  SELECT TOP 1 P.Betrag
  FROM BgPosition P
  LEFT JOIN BgSpezKonto S ON S.BgSpezKontoID = P.BgSpezKontoID
  LEFT JOIN BgKostenart KA on KA.BgKostenartID = S.BgKostenartID
  WHERE P.BgBudgetID = @BgBudgetID
  AND P.BaPersonID = @BaPersonID
  AND (P.Buchungstext like  '[0-9]%-%[0-9]%' OR P.Buchungstext like  'EFB%' OR P.Buchungstext like  '%EFB%') 
  AND (S.NameSpezKonto like 'EFB%' OR S.NameSpezKonto like '%EFB%')
  --AND P.BgKategorieCode = 2 -- Ausgabe, ohne Einzelzahlungen 101
  AND P.BgBewilligungStatusCode = 5 -- Bewilligung erteilt
  AND EXISTS ( 
    SELECT TOP 1 1 FROM KbBuchungKostenart B
    INNER JOIN KbBuchung C ON C.KbBuchungID = B.KbBuchungID
    WHERE B.BgPositionID = P.BgPositionID
    --  2 = freigegeben
    --  3 = ZahlauftragErstellt, 
    --  6 = ausgeglichen, 
    -- 10 = teilweise ausgeglichen, 
    -- 13 = verbucht
    AND (C.KbBuchungStatusCode IN (3,6,10,13) OR (C.KbBuchungStatusCode = 2 AND C.KbAuszahlungsArtCode = 103))
    )
  ))  
  -- -------------------------------------------------------------------------------



  -- -------------------------------------------------------------------------------
  -- Daten einfügen
  INSERT INTO @tmp (
    DossierID, Stichtag, BaPersonID, BaPersonLaufnummer,
    MIZBetrag, IZUBetrag, EFBBetrag, MIZBetrag_alt, IZUBetrag_alt, EFBBetrag_alt, 
    BgBudgetID, Budget, PersonName, Anfang,
    anzPersHH, anzPersUE, betragZugesprochen, datum1Zahlung, datumZZahlung, betragGesamt,
    AHV, VersNr, Geburt, Geschlecht, Zivilstand, Nationalitaet, Aufenthalt
 )
  VALUES (@BFSDossierID, @Stichtag, @BaPersonID, @BaPersonLaufnummer,
    @BetragMIZ, @BetragIZU, @BetragEFB, @BetragMIZ_alt, @BetragIZU_alt, @BetragEFB_alt,
    @BgBudgetID, @Budget, @PersonName, @Anfang,
    @anzPersHH, @anzPersUE, @betragZugesprochen, @datum1Zahlung, @datumZZahlung, @betragGesamt,
    @AHV, @VersNr, @Geburt, @Geschlecht, @Zivilstand, @Nationalitaet, @Aufenthalt)
  -- -------------------------------------------------------------------------------

/*  
lov BuchungsStatus
select top 3 * from FaLeistung
select top 3 * from BgFinanzplan
select top 3 * from BgBudget

select * from BgPosition where BgBudgetID = 370207
select * from BgSpezkonto where BgSpezkontoID = 52152
select top 100 * from BgAuszahlungPerson where BgPositionID = 5183072
select top 100 * from BgAuszahlungPerson where BaPersonID = 630
select top 100 * from KbBuchungKostenart where BgPositionID = 5183072

select top 3 * from KbBuchung
select * from BgPositionsart
select * from BgKostenart order by KontoNR
*/

END  
-- clean up cursor
CLOSE curDossiers;
DEALLOCATE curDossiers;

SELECT Institution = @InstNr, GemeindeID = BFS.ZustaendigeGemeinde, T.* 
FROM @tmp T
LEFT JOIN BFSDossier BFS ON BFS.BfsDossierID = T.DossierID

GO
  
  
