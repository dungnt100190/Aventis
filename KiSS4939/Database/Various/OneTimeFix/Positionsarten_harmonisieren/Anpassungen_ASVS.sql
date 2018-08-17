BEGIN TRANSACTION

SET NOCOUNT ON;
GO

DECLARE @BgKostenartID_720 INT;
DECLARE @BgKostenartID_531 INT;
DECLARE @UserID INT;
DECLARE @Creator VARCHAR(50);
DECLARE @WhGefKategorieID_KK INT;
DECLARE @KbPeriodeID INT;
DECLARE @GruppeKontoID INT;
DECLARE @SortKey INT;

--------------------
-- Parameter setzen
--------------------
SELECT @UserID = dbo.fnXGetSystemUserID();
SELECT @Creator = dbo.fnGetDBRowCreatorModifier(@UserID);

SELECT @WhGefKategorieID_KK = WhGefKategorieID
FROM dbo.WhGefKategorie WITH (READUNCOMMITTED)
WHERE WhGefKategorieCode = 9; -- KK-Pr�mien Grundversicherung

SELECT @KbPeriodeID = KbPeriodeID
FROM dbo.KbPeriode PRD WITH (READUNCOMMITTED)
WHERE PRD.KbMandantID = 1
  AND PRD.PeriodeVon = '20120101';
  
SELECT @BgKostenartID_531 = BgKostenartID
FROM dbo.BgKostenart KOA WITH (READUNCOMMITTED)
WHERE KontoNr = '531';

-------------------------------------------------------------------
--Perform Changes
-------------------------------------------------------------------
-- 1. Kostenart 720 "Pr�mienverbilligung ASV" einrichten
IF NOT EXISTS(SELECT TOP 1 1
              FROM dbo.BgKostenart KOA WITH (READUNCOMMITTED)
              WHERE KontoNr = '720')
BEGIN
  -- Kostenart 720 "Pr�mienverbilligung ASV" einrichten
  INSERT INTO dbo.BgKostenart
          (ModulID,
           Name,
           KontoNr,
           Quoting,
           BgSplittingArtCode,
           BaWVZeileCode)
  VALUES  (3, -- ModulID - int
           'Pr�mienverbilligung ASV', -- Name - varchar(100)
           '720', -- KontoNr - varchar(10)
           0, -- Quoting - bit
           2, -- BgSplittingArtCode - int
           NULL  -- BaWVZeileCode - int
           );
           
  SELECT @BgKostenartID_720 = SCOPE_IDENTITY();
  
  PRINT ('Info: KOA 720 erstellt. (' + CONVERT(VARCHAR(50), @BgKostenartID_720) + ')');

  -- Mapping KOA 720 zur GEF-Kategorie "KK-Pr�mien Grundversicherung"
  INSERT INTO dbo.BgKostenart_WhGefKategorie
          (BgKostenartID,
           WhGefKategorieID,
           IsInkassoprovision,
           Creator,
           Created,
           Modifier,
           Modified)
  VALUES  (@BgKostenartID_720, -- BgKostenartID - int
           @WhGefKategorieID_KK, -- WhGefKategorieID - int
           0, -- IsInkassoprovision - bit
           @Creator, -- Creator - varchar(50)
           GETDATE(), -- Created - datetime
           @Creator, -- Modifier - varchar(50)
           GETDATE() -- Modified - datetime
           );
           
  PRINT ('Info: Mapping KOA 720 zur GEF-Kategorie "KK-Pr�mien Grundversicherung" erstellt.');
END;

-- 2. Konto 720 in 2012 einrichten unter Konto 4360.304 "�brige Einnahmen"
IF NOT EXISTS(SELECT *
              FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
              WHERE KbPeriodeID = @KbPeriodeID
                AND KontoNr = '720')
BEGIN
  SELECT @GruppeKontoID = KbKontoID
  FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
  WHERE KbPeriodeID = @KbPeriodeID
    AND KontoNr = '4360.304'; -- �brige Einnahmen
    
  SELECT @SortKey = MAX(SortKey) + 1
  FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
  WHERE GruppeKontoID = @GruppeKontoID;

  INSERT INTO dbo.KbKonto
          (KbPeriodeID,
           GruppeKontoID,
           Kontogruppe,
           KbKontoklasseCode,
           KbKontoartCodes,
           KontoNr,
           KontoName,
           Vorsaldo,
           SaldoGruppeName,
           Saldovortrag,
           SortKey,
           KbZahlungskontoID)
  VALUES  (@KbPeriodeID, -- KbPeriodeID - int
           @GruppeKontoID, -- GruppeKontoID - int
           0, -- Kontogruppe - bit
           4, -- KbKontoklasseCode - int
           NULL, -- KbKontoartCodes - varchar(20)
           '720', -- KontoNr - varchar(10)
           'Pr�mienverbilligung ASV', -- KontoName - varchar(100)
           0.0, -- Vorsaldo - money
           NULL, -- SaldoGruppeName - varchar(100)
           NULL, -- Saldovortrag - bit
           @SortKey, -- SortKey - int
           NULL  -- KbZahlungskontoID - int
           );
           
  PRINT ('Info: Konto 720 in Periode 2012 erstellt.');
END;

-- 3. Konto 530 "KVG" in 2012 / Erfolgsrechnung dem Konto 3660.308 "Medizinalauslagen" zuordnen
SELECT @GruppeKontoID = KbKontoID
FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
WHERE KbPeriodeID = @KbPeriodeID
  AND KontoNr = '3660.308'; -- Medizinalauslagen
  
SELECT @SortKey = MAX(SortKey) + 1
FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
WHERE GruppeKontoID = @GruppeKontoID;

UPDATE KTO
SET GruppeKontoID     = @GruppeKontoID,
    SortKey           = @SortKey,
    KbKontoklasseCode = 3 -- Aufwand
FROM dbo.KbKonto KTO
WHERE KbPeriodeID = @KbPeriodeID
  AND KontoNr = '530'
  AND (GruppeKontoID <> @GruppeKontoID
    OR KbKontoklasseCode <> 3);
    
IF(@@ROWCOUNT > 0)
BEGIN
	PRINT ('Info: Konto 530 an 3660.308 zugeordnet.');
END;
  
-- 4. Konto 531 "KVG-EL Bez�ger" in 2012 / Erfolgsrechnung dem Konto 3660.308 "Medizinalauslagen" zuordnen
SELECT @GruppeKontoID = KbKontoID
FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
WHERE KbPeriodeID = @KbPeriodeID
  AND KontoNr = '3660.308'; -- Medizinalauslagen
  
SELECT @SortKey = MAX(SortKey) + 1
FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
WHERE GruppeKontoID = @GruppeKontoID;

UPDATE KTO
SET GruppeKontoID     = @GruppeKontoID,
    SortKey           = @SortKey,
    KbKontoklasseCode = 3 -- Aufwand
FROM dbo.KbKonto KTO
WHERE KbPeriodeID = @KbPeriodeID
  AND KontoNr = '531'
  AND (GruppeKontoID <> @GruppeKontoID
    OR KbKontoklasseCode <> 3);
    
IF(@@ROWCOUNT <> 0)
BEGIN
	PRINT ('Info: Konto 531 an 3660.308 zugeordnet.');
END;

-- 5. Mapping KOA 531 zur GEF-Kategorie "KK-Pr�mien Grundversicherung"
IF NOT EXISTS(SELECT TOP 1 1 
              FROM dbo.BgKostenart_WhGefKategorie WITH (READUNCOMMITTED)
              WHERE BgKostenartID = @BgKostenartID_531 
                AND WhGefKategorieID = @WhGefKategorieID_KK)
BEGIN
  -- Bestehendes Mapping l�schen
  DELETE FROM dbo.BgKostenart_WhGefKategorie WHERE BgKostenartID = @BgKostenartID_531;
  IF (@@ROWCOUNT > 0)
  BEGIN
    PRINT ('Info: Mapping f�r KOA 531 gel�scht.');
  END;
  
  -- Mapping KOA 531 zur GEF-Kategorie "KK-Pr�mien Grundversicherung"
  INSERT INTO dbo.BgKostenart_WhGefKategorie
          (BgKostenartID,
           WhGefKategorieID,
           IsInkassoprovision,
           Creator,
           Created,
           Modifier,
           Modified)
  VALUES  (@BgKostenartID_531, -- BgKostenartID - int
           @WhGefKategorieID_KK, -- WhGefKategorieID - int
           0, -- IsInkassoprovision - bit
           @Creator, -- Creator - varchar(50)
           GETDATE(), -- Created - datetime
           @Creator, -- Modifier - varchar(50)
           GETDATE() -- Modified - datetime
           );
           
  PRINT ('Info: Mapping KOA 531 zur GEF-Kategorie "KK-Pr�mien Grundversicherung" erstellt.');
END;

-- 6. Dummy-Dossier "Pr�mienverbilligung ASV"
IF NOT EXISTS(SELECT TOP 1 1
              FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
              WHERE Name = 'Pr�mienverbilligung ASV'
                AND Fiktiv = 1)
BEGIN
  INSERT INTO dbo.HistoryVersion(AppUser)
  VALUES  (@Creator);

  INSERT INTO dbo.BaPerson
          (Name,
           Geburtsdatum,
           Fiktiv,
           Creator,
           Created,
           Modifier,
           Modified)
  VALUES  ('Pr�mienverbilligung ASV', -- Name - varchar(100)
           '20120101', -- Geburtsdatum - datetime
           1, -- Fiktiv - bit
           @Creator, -- Creator - varchar(50)
           GETDATE(), -- Created - datetime
           @Creator, -- Modifier - varchar(50)
           GETDATE() -- Modified - datetime
           );
           
  DECLARE @BaPersonID INT;
  SELECT @BaPersonID = SCOPE_IDENTITY();
  
  PRINT ('Info: Dummy-Dossier "Pr�mienverbilligung ASV" mit BaPersonID ' + CONVERT(VARCHAR(50), @BaPersonID) + ' erstellt.');
  
  EXEC dbo.spKbKostenstelleAnlegen @BaPersonID, @UserID;
  
  PRINT ('Info: Kostenstelle f�r Dummy-Dossier "Pr�mienverbilligung ASV" erstellt.');
END;
GO

SET NOCOUNT OFF;
GO

-- COMMIT
-- ROLLBACK

