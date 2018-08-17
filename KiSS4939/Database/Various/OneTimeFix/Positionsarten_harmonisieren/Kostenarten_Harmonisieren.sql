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