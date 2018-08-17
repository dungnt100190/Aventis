SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBFSGetImportDossiers;
GO
/*===============================================================================================
  $Revision: 12 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    EXECUTE dbo.spBFSGetImportDossiers NULL, NULL, NULL, NULL, NULL, NULL;
=================================================================================================*/

CREATE PROCEDURE dbo.spBFSGetImportDossiers
(
  @Erhebungsjahr INT = NULL,
  @UserID INT = NULL,
  @BaPersonID INT = NULL,
  @LeistungsartCodes VARCHAR(200) = NULL,  -- kommagetrennte Liste von Leistungsart-Codes
  @OrgUnitID INT = NULL,
  @InklBuchungenVorErhebungsjahr BIT = 1
)
AS
BEGIN
  SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
  
  SET @LeistungsartCodes = ISNULL(@LeistungsartCodes, '1,2,23,25,35,36,37,40,50');
  SET @LeistungsartCodes = ',' + @LeistungsartCodes + ',';
  SET @InklBuchungenVorErhebungsjahr = ISNULL(@InklBuchungenVorErhebungsjahr, 1);
  
  DECLARE @Date0107OfJahrMinus1 DATETIME;
  SET @Date0107OfJahrMinus1 = dbo.fnDateSerial(@Erhebungsjahr - 1, 7, 1);

  IF (@Erhebungsjahr IS NULL)
  BEGIN
    SET @Erhebungsjahr = CONVERT(int, dbo.fnXConfig('System\Sostat\Erhebungsjahr', GETDATE()));
  END;
  
  EXECUTE dbo.spDropObject 'tempdb..#tmpBuchungen';
  EXECUTE dbo.spDropObject 'tempdb..#tmpUnterbrueche';
  EXECUTE dbo.spDropObject 'tempdb..#tmpDossiers';
  
  -- ----------------------------------------------------------------------------
  -- Definition von temporaeren Tabellen
  -- ----------------------------------------------------------------------------
  -- tmpBuchungen enthaelt fuer jede BaPerson alle Tage mit Ausgleichsbuchungen
  CREATE TABLE #tmpBuchungen
  (
    FaProzessCode   INT,
    BaPersonID      INT,      -- Antraggsteller
    Ausgleichsdatum DATETIME,
    FaLeistungID    INT,       -- nicht eindeutig, daher max(FaLeistungID)
    BaPersonID_Glaeubiger INT,
    PRIMARY KEY (FaProzessCode, BaPersonID, Ausgleichsdatum, BaPersonID_Glaeubiger)
  );
  
  -- tmpUnterbrueche enthaelt für jede Person die Pausen zwischen Ausgleichsbuchungen, die laenger als 6 Monate sind
  CREATE TABLE #tmpUnterbrueche
  (
    FaProzessCode INT,
    BaPersonID    INT,      -- Antraggsteller
    Anfang        DATETIME,
    Ende          DATETIME,
    PRIMARY KEY (FaProzessCode, BaPersonID, Anfang)
  );
  
  -- tmpDossiers enthaelt die Dossiers unter Beruecksichtigung der 6 Monate Regel
  CREATE TABLE #tmpDossiers
  (
    tmpDossiersID INT IDENTITY(1,1),
    Jahr INT,
    BaPersonID INT,
    FaLeistungID INT,           -- max(FaLeistungID)
    ModulID INT,       
    DatumVon DATETIME,
    DatumBis DATETIME,
    Person VARCHAR(100),
    FaProzessCode INT,
    Leistungsart INT,
    MaxDatumBis DATETIME,
    LaufNr      INT,
    PRIMARY KEY (tmpDossiersID, Jahr, BaPersonID)
  );
  
  -- Hole alle relevanten Buchungen für BFS
  INSERT INTO #tmpBuchungen
    SELECT DISTINCT
           FCN.* 
    FROM fnBFSGetRelevanteBuchungen(@Erhebungsjahr, @UserID, @BaPersonID, @LeistungsartCodes, @OrgUnitID, @InklBuchungenVorErhebungsjahr) FCN;
  
  -- ----------------------------------------------------------------------------
  -- Unterbrueche von mehr als 6 Monaten bestimmen
  -- ----------------------------------------------------------------------------
  INSERT #tmpUnterbrueche
    SELECT DISTINCT
      BUC1.FaProzessCode,
      BUC1.BaPersonID,
      Anfang = BUC1.Ausgleichsdatum,
      Ende = MIN(BUC2.Ausgleichsdatum)
    FROM #tmpBuchungen        BUC1
      LEFT JOIN #tmpBuchungen BUC2 ON BUC2.BaPersonID = BUC1.BaPersonID 
                                  AND BUC2.FaProzessCode = BUC1.FaProzessCode 
                                  AND BUC2.Ausgleichsdatum > BUC1.Ausgleichsdatum
    GROUP BY BUC1.BaPersonID, BUC1.Ausgleichsdatum, BUC1.FaProzessCode
    HAVING dbo.fnBFSIsNewDossierGap(BUC1.Ausgleichsdatum, MIN(BUC2.Ausgleichsdatum)) = 1;
  
  -- ----------------------------------------------------------------------------
  -- Output 1: fuer alle Personen in #tmpBuchungen 1 Dossier erstellen
  -- ----------------------------------------------------------------------------
  INSERT #tmpDossiers
    SELECT Jahr          = @Erhebungsjahr,
           BaPersonID    = CASE 
                             WHEN TMP.FaProzessCode = 405 THEN NULL -- TODO? IsNull(dbo.[fnFindInkassoMutter](MAX(TMP.FaLeistungID), NULL),TMP.BaPersonID)
                             ELSE TMP.BaPersonID 
                           END,
           FaLeistungID  = MAX(TMP.FaLeistungID),
           ModulID       = CASE 
                             WHEN TMP.FaProzessCode = 300 THEN 3
                             WHEN TMP.FaProzessCode = 600 THEN 6
                             ELSE 4 
                           END,
           DatumVon      = MIN(Ausgleichsdatum),
           DatumBis      = ISNULL((SELECT MIN(Anfang)   -- Anfang des ersten Unterbruchs
                                   FROM #tmpUnterbrueche 
                                   WHERE FaProzessCode = TMP.FaProzessCode 
                                     AND BaPersonID = TMP.BaPersonID), MAX(Ausgleichsdatum)),  
           Person        = NULL,
           FaProzessCode = TMP.FaProzessCode,
           Leistungsart  = dbo.fnBFSGetLeistungsartCode(TMP.FaProzessCode, MAX(TMP.FaLeistungID)),
           MaxDatumBis   = MAX(Ausgleichsdatum),
           LaufNr        = NULL
    FROM #tmpBuchungen TMP
    GROUP BY TMP.BaPersonID, TMP.FaProzessCode

  -- Dossiers mit unbekannter Leistungsart entfernen
  DELETE FROM #tmpDossiers
  WHERE Leistungsart IS NULL;

  UPDATE DOS
  SET DOS.Person = PRS.Name + ISNULL(', ' + PRS.Vorname, '')
  FROM #tmpDossiers         DOS
    INNER JOIN dbo.BaPerson PRS ON PRS.BaPersonID = DOS.BaPersonID;
  
  -- ----------------------------------------------------------------------------
  -- fuer jeden Unterbruch ein neues Dossier erzeugen
  -- ----------------------------------------------------------------------------
  INSERT #tmpDossiers
    SELECT Jahr          = @Erhebungsjahr,
           BaPersonID    = DOS.BaPersonID,
           FaLeistungID  = DOS.FaLeistungID,
           ModulID       = DOS.ModulID,
           DatumVon      = TMP.Ende,
           DatumBis      = ISNULL((SELECT MIN(Anfang)   -- Anfang des nächsten Unterbruchs
                                   FROM #tmpUnterbrueche 
                                   WHERE FaProzessCode = TMP.FaProzessCode 
                                     AND BaPersonID = TMP.BaPersonID 
                                     AND Anfang > TMP.Anfang), DOS.MaxDatumBis), 
           Person        = DOS.Person,
           FaProzessCode = DOS.FaProzessCode,
           Leistungsart  = DOS.Leistungsart,
           MaxDatumBis   = DOS.MaxDatumBis,
           LaufNr        = NULL
    FROM #tmpUnterbrueche     TMP
      INNER JOIN #tmpDossiers DOS ON DOS.BaPersonID = TMP.BaPersonID 
                                 AND DOS.FaProzessCode = TMP.FaProzessCode;
  
  -- ----------------------------------------------------------------------------
  -- Testpersonen löschen 
  -- ----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1 
              FROM syscolumns 
              WHERE id = object_id('BaPerson') 
                AND name = 'Testperson'))
  BEGIN
    DELETE 
    FROM #tmpDossiers 
    WHERE BaPersonID IN (SELECT PRS.BaPersonID 
                         FROM dbo.BaPerson PRS
                         WHERE PRS.Testperson = 1);
  END;

  -- ----------------------------------------------------------------------------
  -- LaufNr bestimmen
  -- ----------------------------------------------------------------------------
  UPDATE TMP
  SET LaufNr = RNK.LaufNr
  FROM #tmpDossiers TMP
    INNER JOIN (SELECT tmpDossiersID,
                       LaufNr = RANK() OVER (PARTITION BY BaPersonID ORDER BY DatumVon)
                FROM #tmpDossiers) RNK ON RNK.tmpDossiersID = TMP.tmpDossiersID;

  -- ----------------------------------------------------------------------------
  -- Dossiers ausserhalb des Erhebungsjahrs entfernen
  -- ----------------------------------------------------------------------------
  DELETE FROM #tmpDossiers
  WHERE DatumBis < @Date0107OfJahrMinus1
     OR YEAR(DatumVon) > @Erhebungsjahr;

  -- ----------------------------------------------------------------------------
  -- DatumBis muss im Erhebungsjahr liegen
  -- ----------------------------------------------------------------------------
  UPDATE #tmpDossiers
  SET DatumBis = dbo.fnDateSerial(@Erhebungsjahr, 12, 31)
  WHERE YEAR(DatumBis) > @Erhebungsjahr

  -- ----------------------------------------------------------------------------
  -- FaLeistungID korrigieren
  -- ----------------------------------------------------------------------------
  UPDATE DOS
  SET FaLeistungID = ISNULL((SELECT TOP 1 BUC.FaLeistungID
                             FROM #tmpBuchungen BUC
                             WHERE BUC.Ausgleichsdatum BETWEEN DOS.DatumVon AND DOS.DatumBis
                               AND BUC.BaPersonID = DOS.BaPersonID
                             ORDER BY CASE 
                                        WHEN BUC.Ausgleichsdatum BETWEEN @Date0107OfJahrMinus1 AND dbo.fnDateSerial(@Erhebungsjahr, 12, 31) THEN 1
                                        ELSE 2
                                      END,
                                      BUC.Ausgleichsdatum DESC), FaLeistungID)
  FROM #tmpDossiers DOS

  -- ----------------------------------------------------------------------------
  -- Output: #tmpDossiers zurueckgeben
  -- ----------------------------------------------------------------------------
  SELECT DISTINCT 
         Jahr,
         BaPersonID,
         FaLeistungID,
         ModulID,
         DatumVon,
         DatumBis,
         Person,
         FaProzessCode,
         Leistungsart,
         LaufNr,
         BaPersonID$ = TMP.BaPersonID
  FROM #tmpDossiers TMP
  WHERE @LeistungsartCodes LIKE '%,' + CONVERT(VARCHAR, TMP.Leistungsart) + ',%'
  ORDER BY BaPersonID DESC, DatumVon ASC;
END;


GO