SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbSozialhilferechnungDifferenziert;
GO
/*===============================================================================================
  $Revision: 34 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Differenzierung Sozialhilferechnung erstellen. SP ist notwendig weil es Indexes auf
            temporäre Tabellen braucht.
    @KbPeriodeID:     ID der KbPeriode
    @LanguageCode:    LanguageCode. 1 = Deutsch, 2 = Französisch
    @DatumVon:        Date from to analyse
    @DatumBis:        Date to to analyse
    @nurOhneGemeinde: Only entries without munitipality
    @GemeindeCode:    Search only entries for the given municipality
  -
  RETURNS: Tabelle für die Differenzierung Sozialhilferechnung
           Table 0: Liste
           Table 1: Gemeinde Gruppiert
  -
  TEST:    EXEC dbo.spKbSozialhilferechnungDifferenziert 36;
=================================================================================================*/

CREATE PROCEDURE dbo.spKbSozialhilferechnungDifferenziert
(
  @KbPeriodeID                 INT,
  @LanguageCode                INT = 1,
  @DatumVon                    DATETIME = NULL,
  @DatumBis                    DATETIME = NULL,
  @nurOhneGemeinde             BIT = 0,
  @GemeindeCode                INT = NULL,
  @UserID_SAR                  INT = NULL,
  @SektionID                   INT = NULL,
  @mitEinnahmenNichtAbgetreten BIT = 0
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- Declare and set variables
  -----------------------------------------------------------------------------
  DECLARE @DebugMode BIT;
  SET @DebugMode = 0;

  DECLARE @Jahr INT,
          @HauptgemeindeBFSNr INT;

  SELECT @HauptgemeindeBFSNr = CONVERT(INT, dbo.fnXConfig('System\Allgemein\HauptgemeindeBFSNr', GETDATE()));

  SELECT @Jahr = YEAR(PER.PeriodeVon)
  FROM dbo.KbPeriode PER WITH(READUNCOMMITTED) 
  WHERE PER.KbPeriodeID = @KbPeriodeID;

  IF (@DatumVon IS NULL AND @DatumBis IS NULL)
  BEGIN
    SELECT @DatumVon = PER.PeriodeVon, 
           @DatumBis = PER.PeriodeBis 
    FROM dbo.KbPeriode PER WITH(READUNCOMMITTED) 
    WHERE PER.KbPeriodeID = @KbPeriodeID;
  END
  ELSE
  BEGIN
    IF (@DatumVon IS NULL)
    BEGIN
      SELECT @DatumVon = PER.PeriodeVon 
      FROM dbo.KbPeriode PER WITH(READUNCOMMITTED) 
      WHERE PER.KbPeriodeID = @KbPeriodeID;
    END;

    IF (@DatumBis IS NULL)
    BEGIN
      SELECT @DatumBis = PER.PeriodeBis 
      FROM dbo.KbPeriode PER WITH(READUNCOMMITTED) 
      WHERE PER.KbPeriodeID = @KbPeriodeID;
    END;
  END;

  IF (@nurOhneGemeinde IS NULL)
  BEGIN
    SET @nurOhneGemeinde = 0;
  END;

  DECLARE @ZeitraumString VARCHAR(100);
  SET @ZeitraumString = dbo.fnGetZeitraumString(@DatumVon, @DatumBis);

  -----------------------------------------------------------------------------
  -- Search ZuDe, ALBV, Inkassoprivileg and Heimatliche Vergütung Konti
  -----------------------------------------------------------------------------
  DECLARE @ZuDeKonti                  VARCHAR(200);
  DECLARE @ALBVKonti                  VARCHAR(200);
  DECLARE @ALBVKontiBevorschussung    VARCHAR(200);
  DECLARE @ALBVKontiInkassikosten     VARCHAR(200);
  DECLARE @ALBVKontiRueckerstattung   VARCHAR(200);
  DECLARE @InkassoprivilegKonti       VARCHAR(200);
  DECLARE @HeimatlicheVergeutungKonti VARCHAR(200);
  DECLARE @SozialhilfeInkasssoKonti   VARCHAR(200);

  -- Get the KontoNr that are relevant for both "Zuschüsse..." tabs
  SELECT @ZuDeKonti = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ZuDeKonti', @DatumVon));

  -- Get the KontoNr that are relevant for the ALBV tab
  SELECT @ALBVKonti = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ALBVKonti', @DatumVon));

  -- Get the KontoNr that are relevant for the ALBV (Bevorschussung)
  SELECT @ALBVKontiBevorschussung = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ALBVKontiBevorschussung', @DatumVon));

  -- Get the KontoNr that are relevant for the ALBV (Inkassikosten)
  SELECT @ALBVKontiInkassikosten = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ALBVKontiInkassikosten', @DatumVon));

  -- Get the KontoNr that are relevant for the ALBV (Rueckerstattung)
  SELECT @ALBVKontiRueckerstattung = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ALBVKontiRueckerstattung', @DatumVon));

  -- Get the KontoNr that are relevant for the colums "Ertrag Inkassoprivileg"
  SELECT @InkassoprivilegKonti = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\InkassoprivilegKonti', @DatumVon));

  -- Get the KontoNr that are relevant for the colums "Ertrag Heimatlich"
  SELECT @HeimatlicheVergeutungKonti = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\HeimatlicheVerguetungKonti', @DatumVon));

  -- Get the KontoNr that are relevant to detect "Sozialhilfeinkasso"-Dossiers
  SELECT @SozialhilfeInkasssoKonti = CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\SozialhilfeInkasssoKonti', @DatumVon));

  -- Create temp tables for Konto
  CREATE TABLE #tmpZuDeKonto
  (
    ID                INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KontoNr           VARCHAR(10)
  );

  CREATE TABLE #tmpALBVKonto
  (
    ID                INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KontoNr           VARCHAR(10),
    IsBevorschussung  BIT DEFAULT (0),
    IsInkassikosten   BIT DEFAULT (0),
    IsRueckerstattung BIT DEFAULT (0)
  );
  
  CREATE TABLE #tmpInkassoprivilegKonto
  (
    ID                INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KontoNr           VARCHAR(10)
  );

  CREATE TABLE #tmpHeimatlicheVergeutungKonto
  (
    ID                INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KontoNr           VARCHAR(10)
  );

  CREATE TABLE #tmpSozialhilfeInkasssoKonto
  (
    ID                INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KontoNr           VARCHAR(10)
  );

  -- Insert all ZuDe-Konto
  INSERT INTO #tmpZuDeKonto(KontoNr)
  SELECT [Value]
  FROM dbo.fnSplit(@ZuDeKonti, ';');

  -- Insert all ALBV-Konto
  INSERT INTO #tmpALBVKonto(KontoNr)
  SELECT [Value]
  FROM dbo.fnSplit(@ALBVKonti, ';');

  -- SET Bevorschussungskonto
  UPDATE KTO
    SET IsBevorschussung = 1
  FROM #tmpALBVKonto KTO
  WHERE KTO.KontoNr IN (SELECT [Value]
                        FROM dbo.fnSplit(@ALBVKontiBevorschussung, ';'));

  -- SET Inkassikostenkonto
  UPDATE KTO
    SET IsInkassikosten = 1
  FROM #tmpALBVKonto KTO
  WHERE KTO.KontoNr IN (SELECT [Value]
                        FROM dbo.fnSplit(@ALBVKontiInkassikosten, ';'));

  -- SET Rueckerstattungskonto
  UPDATE KTO
    SET IsRueckerstattung = 1
  FROM #tmpALBVKonto KTO
  WHERE KTO.KontoNr IN (SELECT [Value]
                        FROM dbo.fnSplit(@ALBVKontiRueckerstattung, ';'));

  -- Insert all Inkassoprivileg-Konto
  INSERT INTO #tmpInkassoprivilegKonto(KontoNr)
  SELECT [Value]
  FROM dbo.fnSplit(@InkassoprivilegKonti, ';');

  -- Insert all Heimatliche Vergütung-Konto
  INSERT INTO #tmpHeimatlicheVergeutungKonto(KontoNr)
  SELECT [Value]
  FROM dbo.fnSplit(@HeimatlicheVergeutungKonti, ';');

    -- Insert all SozialhilfeInkasso-Konto
  INSERT INTO #tmpSozialhilfeInkasssoKonto(KontoNr)
  SELECT [Value]
  FROM dbo.fnSplit(@SozialhilfeInkasssoKonti, ';');

  -- index on KontoNr
  CREATE NONCLUSTERED INDEX IX_#tmpALBVKonto_KontoNr ON #tmpALBVKonto
    (
    KontoNr
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  CREATE NONCLUSTERED INDEX IX_#tmpZuDeKonto_KontoNr ON #tmpZuDeKonto
    (
    KontoNr
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  CREATE NONCLUSTERED INDEX IX_#tmpInkassoprivilegKonto_KontoNr ON #tmpInkassoprivilegKonto
    (
    KontoNr
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  CREATE NONCLUSTERED INDEX IX_#tmpHeimatlicheVergeutungKonto_KontoNr ON #tmpHeimatlicheVergeutungKonto
    (
    KontoNr
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  -------------------------------------------------------------
  -- Create temp tables
  -------------------------------------------------------------
  -- #tmpRelevanteBuchungen
  CREATE TABLE #tmpRelevanteBuchungen
  (
    ID                   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    KbKostenstelleID     INT         NULL,
    KbBuchungKostenartID INT         NULL,
    KbBuchungID          INT         NOT NULL,
    BgKostenartID        INT         NULL,
    BgBudgetID           INT,
    BgPositionID         INT,
    SollKtoNr            VARCHAR(10) NOT NULL,
    HabenKtoNr           VARCHAR(10) NOT NULL,
    Betrag               MONEY       NOT NULL,
    Ausgabe              BIT         NOT NULL,
    BelegDatum           DATETIME    NOT NULL,
    GemeindeCode         INT         NULL,
    IsManual             BIT         NOT NULL
  );

  -- #tmpBuchung
  CREATE TABLE #tmpBuchung
  (
    ID                   INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KbKostenstelleID     INT, 
    BgKostenartID        INT,
    KbBuchungID          INT         NOT NULL,
    KbBuchungKostenartID INT         NOT NULL,
    BgBudgetID           INT,
    BgPositionID         INT,
    BaWVCode             INT,
    SollKtoNr            VARCHAR(10) NOT NULL,
    HabenKtoNr           VARCHAR(10) NOT NULL,
    Betrag               MONEY,
    GemeindeCode         INT,
    BelegDatum           DATETIME    NOT NULL,
    IsManual             BIT         NOT NULL,
    Under18              BIT         NOT NULL,
    IsNichtAbtrEinnahme  BIT         NOT NULL,
    IsAusgabeNichtAbtrEinnahme  BIT  NOT NULL
  );
  
  /*
    BuchungTypCode
      1: relevante Buchungen für die normale diff. SHR
      2: nicht abgetretene Einnahmen
      3: Ausgaben von nicht abgetretene Einnahmen aus gekürzten Positionen aufgeteilt
      4: Ausgaben von nicht abgetretene Einnahmen auf GBL-Ausgabeposition (falls Restbetrag nachdem die gekürzten Positionen gebraucht wurden)
      5: Ausgaben von nicht abgetretene Einnahmen auf die erste Ausgabeposition, bei Budgets die keine GBL-Position haben (falls Restbetrag nachdem die gekürzten Positionen gebraucht wurden)
  */

  -- #tmpDiffSH
  CREATE TABLE #tmpDiffSH
  (
    ID                      INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KbKostenstelleID        INT,
    BgKostenartID           INT,
    KbKontoID               INT,
    GruppeKontoID           INT,
    BaWVCode                INT,
    Kontogruppe             BIT,
    KbKontoklasseCode       INT,
    KontoNr                 VARCHAR(10),
    KontoName               VARCHAR(150),
    Aufwand                 MONEY,
    Ertrag                  MONEY,
    Betrag                  MONEY,
    GemeindeCode            INT,
    IsZuDeKonto             BIT,
    IsALBVKonto             BIT,
    IsSozialhilfeInkasso    BIT,
    AnzahlKostenart         INT,
    ErtraegeInkassoprivileg MONEY,
    UebrigeErtraege         MONEY,
    ErtraegeHeimatliche     MONEY,
    ErtragInkassoUebrig     MONEY,
    IsManual                BIT,
    Under18                 BIT NOT NULL
  );


  CREATE TABLE #tmpAusgabenGekuerzt
  (
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    BgBudgetID INT, 
    BgPositionID INT, 
    Betrag MONEY, 
    BetragBudget MONEY,
    RestBetrag MONEY
  );


  CREATE TABLE #tmpErrorBuchung
  (
    ID                   INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    ErrorMessage         VARCHAR(200) NOT NULL,
    KbKostenstelleID     INT, 
    BgKostenartID        INT,
    KbBuchungID          INT,
    KbBuchungKostenartID INT,
    BgBudgetID           INT,
    BgPositionID         INT,
    BaWVCode             INT,
    SollKtoNr            VARCHAR(10),
    HabenKtoNr           VARCHAR(10),
    Betrag               MONEY,
    GemeindeCode         INT,
    BelegDatum           DATETIME,
    IsManual             BIT,
    IsNichtAbtrEinnahme  BIT,
    IsAusgabeNichtAbtrEinnahme  BIT
  );


  -----------------------------------------------------------------------------
  -- Suche von relevante Buchungen im gewünschte Zeitraum
  -----------------------------------------------------------------------------
  -- Code copied from fnKbGetRelevanteBuchungen and made the join on KbBuchungKostenart as inner join to be faster.

  -- Es gibt einen fachlichen Grund, dass die Debitor KiSS intern immer auf 0.00 sein soll. 
  -- Die Debitoren werden in der Klibu nicht bewirtschaftet, sie werden nur KiSS-intern geführt (als offene Posten-Liste). 
  -- Daher werden unten die Debitoren separat nochmals selektiert 

  -- HACK: (Siehe auch #6717)
  -- Der folgende UNION ist nötig, da die internen Debitoren-Buchungen auf die Kostenarten aufgeteilt werden müssen. 
  -- Dies daher, weil es keine explizite Buchung gibt für die Debitoren zu KOA Zuordnung
  -- Daher werden im ersten SQL-Statement alle Buchungen selektiert, und im zweiten SQL-Statements werden nochmals die Debitoren selektiert, 
  --    wobei das SollKonto dem Habenkonto vom ersten SQL entspricht und beim Habenkonto neu das Konto der KOA genommen wird. 
  --    Somit werden die internen Debitoren auf die Kostenarten verteilt
  INSERT INTO #tmpRelevanteBuchungen(KbKostenstelleID, KbBuchungKostenartID, KbBuchungID, BgKostenartID, SollKtoNr, HabenKtoNr, Betrag, Ausgabe, BelegDatum, IsManual, BgBudgetID, BgPositionID)
    -- expenses
    SELECT 
      KbKostenstelleID     = BKO.KbKostenstelleID,
      KbBuchungKostenartID = BKO.KbBuchungKostenartID,
      KbBuchungID          = BUC.KbBuchungID,
      BgKostenartID        = BKO.BgKostenartID,
      SollKtoNr            = COALESCE(BUC.SollKtoNr, KOA.KontoNr, ''),
      HabenKtoNr           = COALESCE(BUC.HabenKtoNr, KOA.KontoNr, ''),
      Betrag               = ISNULL(BKO.Betrag, BUC.Betrag),
      Ausgabe              = 1,
      BelegDatum           = BUC.BelegDatum,
      IsManual             = CASE WHEN BUC.KbBuchungTypCode IN (2, 5) THEN 1 ELSE 0 END,
      BgBudgetID           = BUC.BgBudgetID,
      BgPositionID         = BKO.BgPositionID
    FROM dbo.KbBuchung                  BUC WITH(READUNCOMMITTED) 
      INNER JOIN dbo.KbBuchungKostenart BKO WITH(READUNCOMMITTED) ON BKO.KbBuchungID = BUC.KbBuchungID
      INNER JOIN dbo.BgKostenart        KOA WITH(READUNCOMMITTED) ON KOA.BgKostenartID = BKO.BgKostenartID -- only those with valid entry
    WHERE BUC.KbPeriodeID = @KbPeriodeID                               -- only those of same periode
      AND BUC.BelegNr IS NOT NULL                                      -- only those with valid belegnr
      AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN @DatumVon AND @DatumBis -- only those where KbBuchung.BelegDatum Between @DatumVon AND @DatumBis
      -- debug
      --AND BgBudgetID = 36878 
      -- end debug       

    -- combine entries
    UNION ALL

    -- income
    SELECT 
      KbKostenstelleID     = BKO.KbKostenstelleID,
      KbBuchungKostenartID = BKO.KbBuchungKostenartID,
      KbBuchungID          = BUC.KbBuchungID,
      BgKostenartID        = BKO.BgKostenartID,
      SollKtoNr            = BUC.HabenKtoNr,
      HabenKtoNr           = COALESCE(KOA.KontoNr, BUC.SollKtoNr),
      Betrag               = ISNULL(BKO.Betrag, BUC.Betrag),
      Ausgabe              = 0,
      BelegDatum           = BUC.BelegDatum,
      IsManual             = CASE BUC.KbBuchungTypCode WHEN 2 THEN 1 ELSE 0 END,
      BgBudgetID           = BUC.BgBudgetID,
      BgPositionID         = BKO.BgPositionID
    FROM dbo.KbBuchung                  BUC WITH(READUNCOMMITTED) 
      INNER JOIN dbo.KbKonto            DEB WITH(READUNCOMMITTED) ON DEB.KbPeriodeID = BUC.KbPeriodeID             -- only those of same periode
                                                                 AND DEB.KontoNr = BUC.HabenKtoNr                  -- only those with matching kontoNr
                                                                 AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%' -- only those with code=20 'Debitor' in kontoart
      INNER JOIN dbo.KbBuchungKostenart BKO WITH(READUNCOMMITTED) ON BKO.KbBuchungID = BUC.KbBuchungID
      INNER JOIN dbo.BgKostenart        KOA WITH(READUNCOMMITTED) ON KOA.BgKostenartID = BKO.BgKostenartID
    WHERE BUC.KbPeriodeID = @KbPeriodeID                               -- only those of same periode
      AND BUC.BelegNr IS NOT NULL                                      -- only those with valid belegnr
      AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN @DatumVon AND @DatumBis -- only those where KbBuchung.BelegDatum Between @DatumVon AND @DatumBis
      -- debug
      --AND BgBudgetID = 36878 
      -- end debug       


  CREATE NONCLUSTERED INDEX IX_#tmpRelevanteBuchungen_KbBuchungID ON #tmpRelevanteBuchungen
    (
    KbBuchungID
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  -- Zuständige Gemeinde suchen
  UPDATE BUC
    SET GemeindeCode = dbo.fnKbGetZustaendigeGemeinde(BUC.KbBuchungKostenartID)
  FROM #tmpRelevanteBuchungen BUC

  -----------------------------------------------------------------------------
  -- Suche von relevante Buchungen für die Sozialhilferechnung
  -----------------------------------------------------------------------------
  INSERT INTO #tmpBuchung (KbKostenstelleID, BaWVCode, SollKtoNr, HabenKtoNr, Betrag, GemeindeCode, BgKostenartID, KbBuchungID, KbBuchungKostenartID, BelegDatum, IsManual, Under18, BgBudgetID, BgPositionID, IsNichtAbtrEinnahme, IsAusgabeNichtAbtrEinnahme)
    SELECT TMP.KbKostenstelleID,
           BaWVCode = CASE WHEN WVC.BaWVCode IN (50, 51) THEN WVC.BaWVCode ELSE NULL END, --uns interessieren nur 50, 51 (ZuDe Heim/NichtHeim)
           TMP.SollKtoNr,
           TMP.HabenKtoNr,
           TMP.Betrag,
           TMP.GemeindeCode, 
           TMP.BgKostenartID,
           TMP.KbBuchungID,
           TMP.KbBuchungKostenartID,
           TMP.BelegDatum,
           TMP.IsManual,
           Under18  = CASE 
                        WHEN dbo.fnGetAge(PRS.Geburtsdatum, TMP.BelegDatum) < 18
                        THEN 1
                        ELSE 0
                      END,
           TMP.BgBudgetID,
           TMP.BgPositionID,
           IsNichtAbtrEinnahme = 0,
           IsAusgabeNichtAbtrEinnahme = 0
    FROM #tmpRelevanteBuchungen              TMP WITH(READUNCOMMITTED)
      INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH(READUNCOMMITTED) ON KST.KbKostenstelleID = TMP.KbKostenstelleID
                                                                      AND (KST.DatumBis IS NULL 
                                                                        OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)
      INNER JOIN dbo.BaPerson                PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = KST.BaPersonID            
      LEFT  JOIN dbo.BaWVCode                WVC WITH(READUNCOMMITTED) ON WVC.BaPersonID = KST.BaPersonID 
                                                                      AND dbo.fnDateOf(TMP.BelegDatum) BETWEEN WVC.DatumVon AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999, 12, 31))
    WHERE (@nurOhneGemeinde = 1 OR @GemeindeCode IS NULL OR TMP.GemeindeCode = @GemeindeCode)
      AND (@nurOhneGemeinde = 0 OR TMP.GemeindeCode IS NULL);



  IF (@mitEinnahmenNichtAbgetreten = 1)
  BEGIN
    DECLARE @EntriesCountEinnahme INT;
    DECLARE @EntriesIteratorEinnahme INT;

    DECLARE @EntriesCountAusgaben INT;
    DECLARE @EntriesIteratorAusgaben INT;
    
    SELECT @EntriesIteratorEinnahme = MAX(ID) + 1
    FROM #tmpBuchung
  
    CREATE NONCLUSTERED INDEX IX_#tmpBuchung_BgBudgetID_BgPositionID ON #tmpBuchung
    (
    BgBudgetID, BgPositionID
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  
    -- Nicht abgetretene Einnahmen hinzufügen
    INSERT INTO #tmpBuchung (KbKostenstelleID, BaWVCode, SollKtoNr, HabenKtoNr, Betrag, GemeindeCode, BgKostenartID, KbBuchungID, KbBuchungKostenartID, BelegDatum, IsManual, Under18, BgBudgetID, BgPositionID, IsNichtAbtrEinnahme, IsAusgabeNichtAbtrEinnahme)
      SELECT KbKostenstelleID      = KST.KbKostenstelleID,
             BaWVCode              = CASE WHEN WVC.BaWVCode IN (50, 51) THEN WVC.BaWVCode ELSE NULL END, --uns interessieren nur 50, 51 (ZuDe Heim/NichtHeim)
             SollKtoNr             = DEB.KontoNr, 
             HabenKtoNr            = KOA.KontoNr,
             Betrag                = POS.Betrag / AnzahlPersonen, -- TODO Runden? Nein, noch nicht da es für GEF pro Dossier gruppiert wird
             GemeindeCode          = LEI.GemeindeCode, 
             BgKostenartID         = KOA.BgKostenartID,
             KbBuchungID           = -POS.BgPositionID,
             KbBuchungKostenartID  = -POS.BgPositionID,
             BelegDatum            = TMP.BelegDatum,
             IsManual              = 0,
             Under18  = CASE 
                          WHEN dbo.fnGetAge(PRS.Geburtsdatum, TMP.BelegDatum) < 18
                          THEN 1
                          ELSE 0
                        END,
             BgBudgetID            = POS.BgBudgetID, 
             BgPositionID          = POS.BgPositionID,
             IsNichtAbtrEinnahme   = 1,
             IsAusgabeNichtAbtrEinnahme = 0
      FROM dbo.BgPosition POS 
        CROSS APPLY (SELECT TMP.BgBudgetID, BelegDatum = MIN(TMP.BelegDatum) -- nur Budgets die eine Buchung in der Geschäftsperiode haben
                     FROM #tmpBuchung TMP
                       INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungKostenartID = TMP.KbBuchungKostenartID
                       INNER JOIN BgPosition POS ON POS.BgPositionID = KBK.BgPositionID
                     WHERE TMP.BgBudgetID IS NOT NULL
                       AND POS.BgKategorieCode = 2 --uns interessieren nur ausbezahlte Ausgabe-Positionen (die gekürzt werden)
                     GROUP BY TMP.BgBudgetID) TMP
        INNER JOIN dbo.BgBudget                BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
        INNER JOIN dbo.BgFinanzplan            FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
        INNER JOIN dbo.FaLeistung              LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
        INNER JOIN dbo.BgPositionsart          POA WITH(READUNCOMMITTED) ON POA.BgPositionsartID = POS.BgPositionsartID
        INNER JOIN dbo.BgKostenart             KOA WITH(READUNCOMMITTED) ON KOA.BgKostenartID = POA.BgKostenartID
        CROSS APPLY (SELECT PRS.BaPersonID, PRS.Geburtsdatum, AnzahlPersonen = COUNT(1) OVER(PARTITION BY FPP.BgFinanzplanID)
                     FROM dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED)
                       INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FPP.BaPersonID
                     WHERE FPP.BgFinanzplanID = FPL.BgFinanzplanID
                       AND FPP.IstUnterstuetzt = 1
                       AND (KOA.Quoting = 1 
                         OR FPP.BaPersonID = POS.BaPersonID
                         OR POS.BaPersonID IS NULL)) PRS
        INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH(READUNCOMMITTED) ON KST.BaPersonID = PRS.BaPersonID
                                                                        AND (KST.DatumBis IS NULL 
                                                                          OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)
        LEFT  JOIN dbo.BaWVCode                WVC WITH(READUNCOMMITTED) ON WVC.BaPersonID = KST.BaPersonID 
                                                                        AND dbo.fnDateOf(TMP.BelegDatum) BETWEEN WVC.DatumVon AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999, 12, 31))
        OUTER APPLY (SELECT KontoNr
                     FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
                     WHERE KbPeriodeID = @KbPeriodeID
                       AND ',' + KbKontoartCodes + ',' LIKE '%,20,%') DEB  -- Debitor-Konto
      WHERE POS.BgKategorieCode = 1
        AND POS.VerwaltungSD = 0
        AND POS.BgBudgetID = TMP.BgBudgetID
        AND POS.Betrag > 0
        -- nur Budgets in aktueller Geschäftsperiode
        AND dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) <= @DatumBis
        AND dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 31) >= @DatumVon
      --debug
      --and BDG.bgbudgetid = 
      --36878
      --end debug
      ORDER BY POS.BgBudgetID
    
    SET @EntriesCountEinnahme = @EntriesIteratorEinnahme - 1 + @@ROWCOUNT;
    PRINT ('Info: @EntriesCountEinnahme = ' + CONVERT(VARCHAR(MAX), @EntriesCountEinnahme));
    
    IF (@DebugMode = 1)
    BEGIN
      SELECT 'IsNichtAbtrEinnahme = 1', TMP.*, POS.BetragBudget
      FROM #tmpBuchung TMP
        LEFT JOIN dbo.vwBgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = TMP.BgPositionID
      WHERE IsNichtAbtrEinnahme = 1

      SELECT 'IsNichtAbtrEinnahme = 1', TMP.BgBudgetID, SUM(TMP.Betrag)
      FROM #tmpBuchung TMP
        LEFT JOIN dbo.vwBgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = TMP.BgPositionID
      WHERE IsNichtAbtrEinnahme = 1
      GROUP BY TMP.BgBudgetID
      HAVING SUM(TMP.Betrag) <> 0.0
      ORDER BY TMP.BgBudgetID

      SELECT 'IsNichtAbtrEinnahme = 1', SUM(TMP.Betrag)
      FROM #tmpBuchung TMP
        LEFT JOIN dbo.vwBgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = TMP.BgPositionID
      WHERE IsNichtAbtrEinnahme = 1
    END;
    
    
    -- die aufgrund von nicht abgetretenen Einnahmen gekürzten Ausgabe-Positionen müssen ungekürzt ausgewiesen werden
    ;WITH PosGroupCTE AS
    (
      SELECT TMP.BgBudgetID, TMP.BgPositionID, Betrag = SUM(TMP.Betrag)
      FROM #tmpBuchung TMP
      WHERE IsNichtAbtrEinnahme = 0
        AND TMP.BgPositionID IS NOT NULL
      GROUP BY TMP.BgBudgetID, TMP.BgPositionID
    )
    INSERT INTO #tmpAusgabenGekuerzt (BgBudgetID, BgPositionID, Betrag, BetragBudget, RestBetrag)
      --SELECT TMP.BgBudgetID, TMP.BgPositionID, TMP.Betrag, POS.BetragRechnung, POS.BetragRechnung - TMP.Betrag
      SELECT TMP.BgBudgetID, TMP.BgPositionID, TMP.Betrag, POS.BetragBudget, POS.BetragBudget - TMP.Betrag
      FROM PosGroupCTE TMP
        LEFT JOIN dbo.vwBgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = TMP.BgPositionID
      --WHERE TMP.Betrag < POS.BetragBudget
      WHERE TMP.Betrag < POS.BetragRechnung
      ORDER BY TMP.BgBudgetID, TMP.Betrag
    
    
    DECLARE @BgBudgetID INT;
    DECLARE @BgPositionID_Einnahme INT;
    DECLARE @BetragEinnahme MONEY;
    DECLARE @MaxID INT;
    DECLARE @BgKostenartID INT;
    
    DECLARE @BgPositionID_Ausgabe INT;
    DECLARE @RestBetrag MONEY;
    
    IF (@DebugMode = 1)
    BEGIN
      SELECT '#tmpAusgabenGekuerzt', * 
      FROM #tmpAusgabenGekuerzt AG 
      --WHERE BgBudgetID = 
      --  36882
        --38105
    END;
    
    -------------------------------------------------------------------------------
    -- loop all entries
    -------------------------------------------------------------------------------
    WHILE (@EntriesIteratorEinnahme <= @EntriesCountEinnahme)
    BEGIN
      -- get current entry
      SELECT @BgBudgetID            = TMP.BgBudgetID,
             @BgPositionID_Einnahme = TMP.BgPositionID,
             @BetragEinnahme        = TMP.Betrag,
             @BgKostenartID         = TMP.BgKostenartID,
             @MaxID                 = (SELECT MAX(ID) FROM #tmpBuchung WHERE BgBudgetID = TMP.BgBudgetID AND IsNichtAbtrEinnahme = 1)
      FROM #tmpBuchung TMP
      WHERE TMP.ID = @EntriesIteratorEinnahme;

      -----------------------------------------------------------------------------
      -- do something
      -----------------------------------------------------------------------------
      PRINT ('Info: @EntriesIteratorEinnahme = ' + CONVERT(VARCHAR(MAX), @EntriesIteratorEinnahme));
      PRINT ('      @BgBudgetID = ' + CONVERT(VARCHAR(MAX), @BgBudgetID));
      PRINT ('      @BgPositionID_Einnahme = ' + CONVERT(VARCHAR(MAX), @BgPositionID_Einnahme));
      PRINT ('      @BetragEinnahme = ' + CONVERT(VARCHAR(MAX), @BetragEinnahme));
      PRINT ('      @MaxID = ' + CONVERT(VARCHAR(MAX), @MaxID));

      --Prüfen, ob Einnahme-KoA gemappt ist auf eine GEF-Kategorie
      IF(NOT EXISTS(SELECT TOP 1 1 
                FROM dbo.BgKostenart_WhGefKategorie KGK
                WHERE KGK.BgKostenartID = @BgKostenartID))
      BEGIN
        SET @EntriesIteratorEinnahme = @EntriesIteratorEinnahme + 1;
        CONTINUE;
      END

      SELECT @EntriesIteratorAusgaben = MIN(ID), @EntriesCountAusgaben = MIN(ID) - 1 + COUNT(1)
      FROM #tmpAusgabenGekuerzt AG
      WHERE BgBudgetID = @BgBudgetID
        AND RestBetrag > 0
        
      WHILE (@EntriesIteratorAusgaben <= @EntriesCountAusgaben AND @BetragEinnahme > 0)
      BEGIN
        -- get current entry
        SELECT @BgPositionID_Ausgabe = TMP.BgPositionID,
               @RestBetrag           = TMP.RestBetrag
        FROM #tmpAusgabenGekuerzt TMP
        WHERE TMP.ID = @EntriesIteratorAusgaben;
        
        PRINT ('      Info: @EntriesIteratorAusgaben = ' + CONVERT(VARCHAR(MAX), @EntriesIteratorAusgaben));
        PRINT ('            @RestBetrag = ' + CONVERT(VARCHAR(MAX), @RestBetrag));
        PRINT ('            @BetragEinnahme = ' + CONVERT(VARCHAR(MAX), @BetragEinnahme));
        PRINT ('            add @BgPositionID_Ausgabe = ' + CONVERT(VARCHAR(MAX), @BgPositionID_Ausgabe) + ' RestBetrag = ' + CONVERT(VARCHAR(MAX), @RestBetrag - @BetragEinnahme) );
 

        UPDATE #tmpAusgabenGekuerzt
          SET RestBetrag = CASE WHEN @BetragEinnahme < RestBetrag THEN RestBetrag - @BetragEinnahme ELSE 0.0 END
        WHERE ID = @EntriesIteratorAusgaben

        INSERT INTO #tmpBuchung (KbKostenstelleID, BaWVCode, SollKtoNr, HabenKtoNr, Betrag, GemeindeCode, BgKostenartID, KbBuchungID, KbBuchungKostenartID, BelegDatum, IsManual, Under18, BgBudgetID, BgPositionID, IsNichtAbtrEinnahme, IsAusgabeNichtAbtrEinnahme)
          SELECT KbKostenstelleID           = TMP.KbKostenstelleID,
                 BaWVCode                   = TMP.BaWVCode,
                 SollKtoNr                  = KOA.KontoNr, 
                 HabenKtoNr                 = KRE.KontoNr,
                 Betrag                     = CASE WHEN @BetragEinnahme < @RestBetrag THEN @BetragEinnahme ELSE @RestBetrag END, -- TODO Runden? Nein, noch nicht da es für GEF pro Dossier gruppiert wird
                 GemeindeCode               = TMP.GemeindeCode, 
                 BgKostenartID              = KOA.BgKostenartID,
                 KbBuchungID                = -POS.BgPositionID,
                 KbBuchungKostenartID       = -POS.BgPositionID,
                 BelegDatum                 = TMP.BelegDatum,
                 IsManual                   = 0,
                 Under18                    = TMP.Under18,
                 BgBudgetID                 = POS.BgBudgetID, 
                 BgPositionID               = POS.BgPositionID,
                 IsNichtAbtrEinnahme        = 0,
                 IsAusgabeNichtAbtrEinnahme = 1
          FROM #tmpBuchung TMP
            CROSS APPLY (SELECT * FROM dbo.BgPosition POS1 WHERE POS1.BgPositionID = @BgPositionID_Ausgabe) POS
            INNER JOIN dbo.BgBudget                BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
            INNER JOIN dbo.BgFinanzplan            FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
            LEFT  JOIN dbo.BgSpezkonto             SPZ WITH(READUNCOMMITTED) ON SPZ.BgSpezkontoID = POS.BgSpezkontoID
            LEFT  JOIN dbo.BgPositionsart          POA WITH(READUNCOMMITTED) ON POA.BgPositionsartID = ISNULL(POS.BgPositionsartID, SPZ.BgPositionsartID)
            LEFT  JOIN dbo.BgPositionsart          GBL WITH(READUNCOMMITTED) ON GBL.BgPositionsartID = FPL.WhGrundbedarfTypCode
            INNER JOIN dbo.BgKostenart             KOA WITH(READUNCOMMITTED) ON KOA.BgKostenartID = COALESCE(POA.BgKostenartID, SPZ.BgKostenartID, GBL.BgKostenartID)
            OUTER APPLY (SELECT KontoNr
                         FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
                         WHERE KbPeriodeID = @KbPeriodeID
                           AND ',' + KbKontoartCodes + ',' LIKE '%,30,%') KRE  -- Kreditor-Konto
          WHERE TMP.ID = @EntriesIteratorEinnahme

        -- TODO
        IF(@@ROWCOUNT = 0)
        BEGIN
          PRINT ('ERROR Insert ist leer');
        END;
        
        SET @BetragEinnahme = @BetragEinnahme - @RestBetrag;
        SET @EntriesIteratorAusgaben = @EntriesIteratorAusgaben + 1;
      END;
      
      IF(@BetragEinnahme > 0.0)
      BEGIN
        PRINT ('            @BetragEinnahme = ' + CONVERT(VARCHAR(MAX), @BetragEinnahme) + ' Betrag auf KOA von GBL-Position oder erste Ausgabe-Position dazuzählen');
                
        INSERT INTO #tmpBuchung (KbKostenstelleID, BaWVCode, SollKtoNr, HabenKtoNr, Betrag, GemeindeCode, BgKostenartID, KbBuchungID, KbBuchungKostenartID, BelegDatum, IsManual, Under18, BgBudgetID, BgPositionID, IsNichtAbtrEinnahme, IsAusgabeNichtAbtrEinnahme)
          SELECT KbKostenstelleID           = TMP.KbKostenstelleID,
                 BaWVCode                   = TMP.BaWVCode,
                 SollKtoNr                  = KOA.KontoNr, 
                 HabenKtoNr                 = KRE.KontoNr,
                 Betrag                     = @BetragEinnahme, -- TODO Runden? Nein, noch nicht da es für GEF pro Dossier gruppiert wird
                 GemeindeCode               = TMP.GemeindeCode, 
                 BgKostenartID              = KOA.BgKostenartID,
                 KbBuchungID                = -ISNULL(POS_GBL.BgPositionID, POS_AUS.BgPositionID),
                 KbBuchungKostenartID       = -ISNULL(POS_GBL.BgPositionID, POS_AUS.BgPositionID),
                 BelegDatum                 = TMP.BelegDatum,
                 IsManual                   = 0,
                 Under18                    = TMP.Under18,
                 BgBudgetID                 = @BgBudgetID, 
                 BgPositionID               = ISNULL(POS_GBL.BgPositionID, POS_AUS.BgPositionID),
                 IsNichtAbtrEinnahme        = 0,
                 IsAusgabeNichtAbtrEinnahme = 1
          FROM #tmpBuchung TMP
            OUTER APPLY (SELECT TOP 1 POS1.*, POA1.BgKostenartID -- GBL-Position
                         FROM dbo.BgBudget BDG
                           INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
                           INNER JOIN dbo.BgPosition POS1 WITH(READUNCOMMITTED) ON POS1.BgBudgetID = BDG.BgBudgetID
                           INNER JOIN dbo.BgPositionsart POA1 WITH (READUNCOMMITTED) ON POA1.BgPositionsartID = POS1.BgPositionsartID
                         WHERE BDG.BgBudgetID = @BgBudgetID
                           AND POA1.BgPositionsartCode = FPL.WhGrundbedarfTypCode
                           AND POS1.BgKategorieCode = 2) POS_GBL
            OUTER APPLY (SELECT TOP 1 POS1.*, POA1.BgKostenartID -- erste Ausgabe-Position
                         FROM dbo.BgBudget BDG
                           INNER JOIN dbo.BgPosition POS1 WITH(READUNCOMMITTED) ON POS1.BgBudgetID = BDG.BgBudgetID
                           INNER JOIN dbo.BgPositionsart POA1 WITH (READUNCOMMITTED) ON POA1.BgPositionsartID = POS1.BgPositionsartID
                         WHERE BDG.BgBudgetID = @BgBudgetID
                           AND POS1.Betrag > 0
                           AND POS1.BgKategorieCode = 2) POS_AUS
            INNER JOIN dbo.BgKostenart    KOA WITH(READUNCOMMITTED) ON KOA.BgKostenartID = ISNULL(POS_GBL.BgKostenartID, POS_AUS.BgKostenartID)
            OUTER APPLY (SELECT KontoNr
                         FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
                         WHERE KbPeriodeID = @KbPeriodeID
                           AND ',' + KbKontoartCodes + ',' LIKE '%,30,%') KRE  -- Kreditor-Konto
          WHERE TMP.ID = @EntriesIteratorEinnahme
        
        IF(@@ROWCOUNT = 0)
        BEGIN
          PRINT ('ERROR max id Insert ist leer');
        END;
      END;
      -----------------------------------------------------------------------------
      
      -- prepare for next entry
      SET @EntriesIteratorEinnahme = @EntriesIteratorEinnahme + 1;
    END;


    IF (@DebugMode = 1)
    BEGIN
      SELECT 'IsAusgabeNichtAbtrEinnahme = 1', SUM(TMP.Betrag)
      FROM #tmpBuchung TMP
        LEFT JOIN dbo.vwBgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = TMP.BgPositionID
      WHERE IsAusgabeNichtAbtrEinnahme = 1

      SELECT 'IsAusgabeNichtAbtrEinnahme = 1', TMP.*, POS.BetragBudget
      FROM #tmpBuchung TMP
        LEFT JOIN dbo.vwBgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = TMP.BgPositionID
      WHERE IsAusgabeNichtAbtrEinnahme = 1


      SELECT 'IsAusgabeNichtAbtrEinnahme = 1', TMP.BgBudgetID, SUM(TMP.Betrag)
      FROM #tmpBuchung TMP
        LEFT JOIN dbo.vwBgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = TMP.BgPositionID
      WHERE IsAusgabeNichtAbtrEinnahme = 1
      GROUP BY TMP.BgBudgetID
      ORDER BY TMP.BgBudgetID

      SELECT * FROM #tmpErrorBuchung
    END;
  END; --IF (@mitEinnahmenNichtAbgetreten = 1)

  IF (@DebugMode = 1)
  BEGIN
    SELECT '#tmpBuchung', * FROM #tmpBuchung 
  END;

  CREATE NONCLUSTERED INDEX IX_#tmpBuchung_KbBuchungKostenartID_KbKostenstelleID ON #tmpBuchung
    (
    KbBuchungKostenartID, KbKostenstelleID
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  CREATE NONCLUSTERED INDEX IX_#tmpBuchung_SollKtoNr_HabenKtoNr ON #tmpBuchung
    (
    SollKtoNr, HabenKtoNr
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]



  -----------------------------------------------------------------------------
  -- Betrag summieren und Anzahl Kostenart pro Kostenstelle und Kostenarten berechnen
  -----------------------------------------------------------------------------
  ;WITH TmpDiffShCte
  AS(
    SELECT TMP.KbKostenstelleID,
           TMP.BgKostenartID,
           KTO.KbKontoID,
           KTO.GruppeKontoID,
           BaWVCode = CASE 
                        WHEN KTO.KontoNr IN (SELECT KontoNr FROM #tmpALBVKonto) THEN 9999 
                        ELSE TMP.BaWVCode 
                      END,
           KTO.Kontogruppe,
           KTO.KbKontoklasseCode,
           KTO.KontoNr,
           KTO.KontoName,
           Aufwand = SUM(CASE 
                       WHEN KTO.KbKontoKlasseCode <> 3   THEN $0
                       WHEN TMP.SollKtoNr  = KTO.KontoNr THEN Betrag
                       WHEN TMP.HabenKtoNr = KTO.KontoNr THEN -Betrag
                       ELSE $0
                     END),
           Ertrag  = SUM(CASE 
                       WHEN KTO.KbKontoKlasseCode <> 4   THEN $0
                       WHEN TMP.HabenKtoNr = KTO.KontoNr THEN Betrag
                       WHEN TMP.SollKtoNr  = KTO.KontoNr THEN -Betrag
                       ELSE $0
                     END),
           Betrag = SUM(CASE 
                       WHEN TMP.SollKtoNr  = KTO.KontoNr THEN Betrag
                       WHEN TMP.HabenKtoNr = KTO.KontoNr THEN -Betrag
                     END),
           TMP.GemeindeCode,
           IsZuDeKonto = CASE WHEN KTOZ.KontoNr IS NOT NULL OR TMP.BaWVCode IN (50, 51) THEN 1 ELSE 0 END,
           IsALBVKonto = CASE WHEN KTOA.KontoNr IS NOT NULL THEN 1 ELSE 0 END,
           IsNotSozialhilfeInkasso = CASE WHEN ISNULL(',' + KTO.KbKontoartCodes + ',','') NOT LIKE '%,30,%' AND KTOS.KontoNr IS NULL THEN 1 ELSE 0 END,
           AnzahlKostenart = COUNT(1),
           IsManual = MIN(CONVERT(INT, TMP.IsManual)),
           Under18 = MAX(CONVERT(INT, TMP.Under18)) --wenn in Auswertungs-Zeitraum minderjährig, dann wird Fall als minderjährig ausgewiesen, auch wenn er während des Auswertungs-Zeitraums volljährig wird
    FROM dbo.KbKonto           KTO WITH(READUNCOMMITTED)
      INNER JOIN #tmpBuchung   TMP  ON TMP.SollKtoNr = KTO.KontoNr OR TMP.HabenKtoNr = KTO.KontoNr
      LEFT  JOIN #tmpZuDeKonto KTOZ ON KTOZ.KontoNr = KTO.KontoNr
      LEFT  JOIN #tmpALBVKonto KTOA ON KTOA.KontoNr = KTO.KontoNr
      LEFT  JOIN #tmpSozialhilfeInkasssoKonto KTOS ON KTOS.KontoNr = KTO.KontoNr

    WHERE KTO.KbPeriodeID = @KbPeriodeID
    GROUP BY TMP.KbKostenstelleID, TMP.BaWVCode, TMP.SollKtoNr, TMP.HabenKtoNr, TMP.GemeindeCode, TMP.BgKostenartID, KTO.KbKontoID, KTO.GruppeKontoID, KTO.Kontogruppe, 
      KTO.KbKontoklasseCode, KTO.KontoNr, KTO.KontoName, 
      CASE WHEN KTOZ.KontoNr IS NOT NULL OR TMP.BaWVCode IN (50, 51) THEN 1 ELSE 0 END, 
      CASE WHEN KTOA.KontoNr IS NOT NULL THEN 1 ELSE 0 END,
      CASE WHEN ISNULL(',' + KTO.KbKontoartCodes + ',','') NOT LIKE '%,30,%' AND KTOS.KontoNr IS NULL THEN 1 ELSE 0 END
  )

  INSERT #tmpDiffSH(KbKostenstelleID, BgKostenartID, KbKontoID, GruppeKontoID, BaWVCode, Kontogruppe, KbKontoklasseCode, KontoNr, KontoName, Aufwand, Ertrag, Betrag, GemeindeCode, IsZuDeKonto, IsALBVKonto, IsSozialhilfeInkasso, AnzahlKostenart, ErtraegeInkassoprivileg, UebrigeErtraege, ErtraegeHeimatliche, ErtragInkassoUebrig, IsManual, Under18)
    SELECT 
      CTE.KbKostenstelleID,
      CTE.BgKostenartID,
      CTE.KbKontoID,
      CTE.GruppeKontoID,
      CTE.BaWVCode,
      CTE.Kontogruppe,
      CTE.KbKontoklasseCode,
      CTE.KontoNr,
      CTE.KontoName,
      Aufwand                 = SUM(CTE.Aufwand),
      Ertrag                  = SUM(CTE.Ertrag),
      Betrag                  = SUM(CTE.Betrag),
      CTE.GemeindeCode,
      CTE.IsZuDeKonto,
      CTE.IsALBVKonto,
      IsSozialhilfeInkasso    = CASE WHEN SUM(CTE.IsNotSozialhilfeInkasso) = 0 THEN 1 ELSE 0 END, --wenn mind. eine Zeile den Wert 1 hat, ist es kein Sozialhilfeinkasso
      AnzahlKostenart         = SUM(CTE.AnzahlKostenart),
      ErtraegeInkassoprivileg = SUM(CASE WHEN KTOI.KontoNr IS NOT NULL THEN ISNULL(Ertrag,0) ELSE 0 END),
      UebrigeErtraege         = SUM(CASE WHEN KTOI.KontoNr IS NULL AND KTOH.KontoNr IS NULL THEN ISNULL(Ertrag,0) ELSE 0 END),
      ErtraegeHeimatliche     = SUM(CASE WHEN KTOH.KontoNr IS NOT NULL THEN ISNULL(Ertrag,0) ELSE 0 END),
      ErtragInkassoUebrig     = SUM(CASE WHEN KTOH.KontoNr IS NULL THEN ISNULL(Ertrag,0) ELSE 0 END), -- ErtraegeInkassoprivileg + UebrigeErtraege
      IsManual                = MIN(CONVERT(INT, CTE.IsManual)),
      Under18                 = MAX(CONVERT(int, CTE.Under18)) --wenn in Auswertungs-Zeitraum minderjährig, dann wird Fall als minderjährig ausgewiesen, auch wenn er während des Auswertungs-Zeitraums volljährig wird
    FROM TmpDiffShCte                           CTE
      LEFT  JOIN #tmpInkassoprivilegKonto       KTOI ON KTOI.KontoNr = CTE.KontoNr
      LEFT  JOIN #tmpHeimatlicheVergeutungKonto KTOH ON KTOH.KontoNr = CTE.KontoNr
    GROUP BY CTE.KbKostenstelleID, CTE.BgKostenartID, CTE.KbKontoID, CTE.GruppeKontoID, CTE.BaWVCode, CTE.Kontogruppe, CTE.KbKontoklasseCode,
      CTE.KontoNr, CTE.KontoName, CTE.GemeindeCode, CTE.IsZuDeKonto, CTE.IsALBVKonto;

  CREATE NONCLUSTERED INDEX IX_#tmpDiffSH_KbKostenstelleID ON #tmpDiffSH
    (
    KbKostenstelleID
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  CREATE NONCLUSTERED INDEX IX_#tmpDiffSH_BgKostenartID ON #tmpDiffSH
    (
    BgKostenartID
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

  CREATE NONCLUSTERED INDEX IX_#tmpDiffSH_KbKontoID ON #tmpDiffSH
    (
    KbKontoID
    ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


-- debug
--SELECT * FROM #tmpDiffSH 
-- end debug

  -----------------------------------------------------------------------------
  -- Insert into Output table
  -----------------------------------------------------------------------------
  SELECT
    NameVorname                = PRS.NameVorname,
    WeiterePersonalien         = ISNULL(', ' + CONVERT(VARCHAR, DATEPART(YEAR, PRS.Geburtsdatum)), '')
                                 + CASE 
                                     WHEN PRS.NationalitaetCode = 147 
                                     THEN ISNULL(', ' + PRS.Heimatort, '')  -- bei CH Heimatort
                                     ELSE ISNULL(', ' + PRS.Nationalitaet, '') -- bei Ausländern Nationalität
                                   END,
    Under18                    = MAX(CONVERT(int, Under18)), --wenn in Auswertungs-Zeitraum minderjährig, dann wird Fall als minderjährig ausgewiesen, auch wenn er während des Auswertungs-Zeitraums volljährig wird
    ZuzugKtDatum               = PRS.ZuzugKtDatum,
    Fax                        = PRS.Fax,
    UserID_S                   = COALESCE(FAL.UserID, FAL1.UserID, FAL2.UserID),
    SAR_S                      = COALESCE(FAL.NameVorname, FAL1.NameVorname, FAL2.NameVorname),
    SektionID_S                = COALESCE(FAL.OrgUnitID, FAL1.OrgUnitID, FAL2.OrgUnitID),
    Sektion_S                  = COALESCE(FAL.ItemName, FAL1.ItemName, FAL2.ItemName),

    UserID_I                   = COALESCE(FAL3.UserID, FAL2.UserID),
    SAR_I                      = COALESCE(FAL3.NameVorname, FAL2.NameVorname),
    SektionID_I                = COALESCE(FAL3.OrgUnitID, FAL2.OrgUnitID),
    Sektion_I                  = COALESCE(FAL3.ItemName, FAL2.ItemName),

    Bezugsgroesse              = dbo.fnLOVText('BaWVCode', TMP.BaWVCode),
    AnzahlDossiers             = 0, --wird später, wenn SummeAufwand berechnet ist, ggf noch auf 1 gesetzt
    AnzahlPersonen             = 1,
    
    Aufwand                    = SUM(ISNULL(Aufwand, 0)),
    Ertrag                     = SUM(ISNULL(Ertrag, 0)),
    ErtraegeInkassoprivileg    = SUM(ISNULL(ErtraegeInkassoprivileg, 0)),
    UebrigeErtraege            = SUM(ISNULL(UebrigeErtraege, 0)),
    ErtraegeHeimatliche        = SUM(ISNULL(ErtraegeHeimatliche, 0)),
    ErtragInkassoUebrig        = SUM(ISNULL(ErtragInkassoUebrig, 0)),
    
    MonatlichAlimente       = ISNULL((SELECT TOP 1 POS.TotalAliment
                                   FROM dbo.IkPosition POS WITH(READUNCOMMITTED)
                                   WHERE POS.ALBVBerechtigt = 1
                                     AND POS.Datum BETWEEN @DatumVon AND @DatumBis
                                     AND POS.BaPersonID = PRS.BaPersonID
                                   ORDER BY POS.Datum DESC), $0),
    Bevorschussung          = SUM(CASE WHEN TMP.IsALBVKonto = 1 AND ALBV.IsBevorschussung = 1 THEN ISNULL(Aufwand,0)  ELSE 0 END),
    Inkassikosten           = SUM(CASE WHEN TMP.IsALBVKonto = 1 AND ALBV.IsInkassikosten = 1 THEN ISNULL(Betrag,0) ELSE 0 END),
    Rueckerstattung         = SUM(CASE WHEN TMP.IsALBVKonto = 1 AND ALBV.IsRueckerstattung = 1 THEN ISNULL(Ertrag,0) ELSE 0 END),
    Netto                   = $0, -- wird im code berechnet (Bevorschussung + Inkassikosten - Rueckerstattung)
    BaWVCode$               = CASE WHEN TMP.IsZuDeKonto = 1 OR TMP.IsALBVKonto = 1 THEN TMP.BaWVCode ELSE NULL END, -- wird nur für ZuDe Heim/nicht Heim und ALBV gegeben
    BaPersonID$             = PRS.BaPersonID,
    DatumVonBis             = @ZeitraumString,
    Gemeinde                = dbo.fnLOVMLText('GemeindeSozialdienst', TMP.GemeindeCode, @LanguageCode),
    IsZuDeKonto$            = TMP.IsZuDeKonto,
    IsALBVKonto$            = TMP.IsALBVKonto,
    IsManual$               = MIN(CONVERT(INT, TMP.IsManual)),
    IsWiHiRelevant$		    = 0, --wird benötigt, um die in den "Wirtschaftliche Hilfe"-relevanten Registern nötigen Filter-Regeln anzuwenden

    -- Spalten für die differnenzierung Sozialhilferechnung
    HasGefMapping$        = CASE WHEN SUM(GEF.WhGefKategorieID) > 0 THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END,
    Jahr                  = @Jahr,
    AbrechnendeEinheit    = @HauptgemeindeBFSNr,
    AngeschlosseneEinheit = TMP.GemeindeCode,
    DossierNr             = COALESCE(FAL.BaPersonID_Fall, FAL1.BaPersonID_Fall, FAL2.BaPersonID_Fall, PRS.BaPersonID),
    DatensatzID           = CONVERT(VARCHAR, PRS.BaPersonID) + '-' + ISNULL(CONVERT(VARCHAR, COALESCE(FAL.BaPersonID_Fall, FAL1.BaPersonID_Fall, FAL2.BaPersonID_Fall, PRS.BaPersonID)), '') + '-' + ISNULL(CONVERT(VARCHAR, TMP.GemeindeCode), '') + '-' + CONVERT(VARCHAR, @HauptgemeindeBFSNr),
    DatensatzID_Int       = PRS.BaPersonID,

    -- Aufwand
    Grundbedarf                             = SUM(CASE WHEN GEF.WhGefKategorieCode = 6  THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    Wohnkosten                              = SUM(CASE WHEN GEF.WhGefKategorieCode = 7  THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    Gesundheitskosten                       = SUM(CASE WHEN GEF.WhGefKategorieCode = 8  THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    KKPraemienGrundversicherung             = SUM(CASE WHEN GEF.WhGefKategorieCode = 9  THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    NKMassnahmenMitKesbBeschluss            = SUM(CASE WHEN GEF.WhGefKategorieCode = 10 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    UeberschusszahlungAnKesb                = SUM(CASE WHEN GEF.WhGefkategorieCode = 35 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    MassnahmekostenOhneKesbBeschluss        = SUM(CASE WHEN GEF.WhGefkategorieCode = 36 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    SchulkostenMassnahmenOhneKesbBeschluss  = SUM(CASE WHEN GEF.WhGefkategorieCode = 37 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    NKMassnahmenOhneKesbBeschluss           = SUM(CASE WHEN GEF.WhGefKategorieCode = 11 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    VorsorglicheAmbulanteMassnahmen         = SUM(CASE WHEN GEF.WhGefKategorieCode = 12 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    AHVMindestbeitraege                     = SUM(CASE WHEN GEF.WhGefkategorieCode = 38 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    UebrigeSIL                              = SUM(CASE WHEN GEF.WhGefKategorieCode = 13 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    IZU                                     = SUM(CASE WHEN GEF.WhGefKategorieCode = 14 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    EFB                                     = SUM(CASE WHEN GEF.WhGefKategorieCode = 15 THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),

    -- Ertrag
    ErwerbseinkommenNetto                   = SUM(CASE WHEN GEF.WhGefKategorieCode = 16 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    ALV                                     = SUM(CASE WHEN GEF.WhGefKategorieCode = 17 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    IVTaggelderRenten                       = SUM(CASE WHEN GEF.WhGefKategorieCode = 18 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    EinkommenAusSozialversicherungen        = SUM(CASE WHEN GEF.WhGefKategorieCode = 19 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    KinderalimenteUndEhegattenalimente      = SUM(CASE WHEN GEF.WhGefKategorieCode = 20 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    Familienzulagen                         = SUM(CASE WHEN GEF.WhGefKategorieCode = 21 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    ErtraegeGesundheitskosten               = SUM(CASE WHEN GEF.WhGefKategorieCode = 22 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    PersoenlicheRueckerstattung             = SUM(CASE WHEN GEF.WhGefKategorieCode = 23 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    ElternbeitraegeVerwandtenunterstuetzung = SUM(CASE WHEN GEF.WhGefKategorieCode = 24 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    HeimatlicheVerguetungen                 = SUM(CASE WHEN GEF.WhGefKategorieCode = 25 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    UebrigeErtraegeDWH                      = SUM(CASE WHEN GEF.WhGefKategorieCode = 26 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),

    -- Mengeninformationen
    AnzUnterstuetzteMonate                  = (SELECT COUNT(Monat)
                                               FROM (SELECT DISTINCT Monat = BDG.Jahr * 100 + BDG.Monat
                                                     FROM dbo.BgFinanzplan_BaPerson      FPP WITH (READUNCOMMITTED)
                                                       INNER JOIN dbo.BgBudget           BDG WITH (READUNCOMMITTED) ON BDG.BgFinanzplanID = FPP.BgFinanzplanID
                                                                                                                   AND BDG.BgBewilligungStatusCode = 5
                                                       INNER JOIN dbo.BgPosition         POS WITH (READUNCOMMITTED) ON POS.BgBudgetID = BDG.BgBudgetID
                                                       INNER JOIN dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED) ON BKO.BgPositionID = POS.BgPositionID
                                                       INNER JOIN dbo.KbBuchung          BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BKO.KbBuchungID
                                                                                                                   AND BUC.BelegNr IS NOT NULL
                                                     WHERE FPP.BaPersonID = PRS.BaPersonID
                                                       AND dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) <= @DatumBis
                                                       AND dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 31) >= @DatumVon
                                                       AND (POS.BaPersonID IS NULL
                                                         OR POS.BaPersonID = PRS.BaPersonID)
        
                                                     UNION
                                                     
                                                     -- Suche nach Manuelle Buchungen 
                                                     SELECT DISTINCT Monat = YEAR(BUC.BelegDatum) * 100 + MONTH(BUC.BelegDatum)
                                                     FROM #tmpBuchung BUC
                                                       INNER JOIN dbo.KbBuchung BUC1 WITH (READUNCOMMITTED) ON BUC1.KbBuchungID = BUC.KbBuchungID
                                                     WHERE BUC.KbKostenstelleID = TMP.KbKostenstelleID
                                                       AND BUC1.KbBuchungTypCode = 2
                                                    )TMP),
    SummeAufwand                            = SUM(CASE WHEN (GEF.WhGefKategorieCode BETWEEN 6 AND 15) OR (GEF.WhGefKategorieCode BETWEEN 35 AND 38) THEN ISNULL(TMP.Aufwand, 0) - ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    SummeErtrag                             = SUM(CASE WHEN (GEF.WhGefKategorieCode BETWEEN 16 AND 26) THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    ErtragOhneInkassoprovision              = SUM(CASE WHEN (GEF.WhGefKategorieCode BETWEEN 16 AND 26) THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END) - SUM(CASE WHEN KGK.IsInkassoprovision = 1 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    ErtragMitInkassoprovision               = SUM(CASE WHEN KGK.IsInkassoprovision = 1 THEN ISNULL(TMP.Ertrag, 0) - ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    
    -- Aufwand und Ertag von Kostenarten ohne Mapping
    AufwandOhneMapping                      = SUM(CASE WHEN KGK.WhGefKategorieID IS NULL AND TMP.IsZuDeKonto = 0 AND TMP.IsALBVKonto = 0 THEN ISNULL(TMP.Aufwand, 0) ELSE 0 END),
    ErtragOhneMapping                       = SUM(CASE WHEN KGK.WhGefKategorieID IS NULL AND TMP.IsZuDeKonto = 0 AND TMP.IsALBVKonto = 0 THEN ISNULL(TMP.Ertrag, 0) ELSE 0 END),
    ErtraegeInkassoprivilegOhneMapping      = SUM(CASE WHEN KGK.WhGefKategorieID IS NULL AND TMP.IsZuDeKonto = 0 AND TMP.IsALBVKonto = 0 THEN ISNULL(TMP.ErtraegeInkassoprivileg, 0) ELSE 0 END),
    UebrigeErtraegeOhneMapping              = SUM(CASE WHEN KGK.WhGefKategorieID IS NULL AND TMP.IsZuDeKonto = 0 AND TMP.IsALBVKonto = 0 THEN ISNULL(TMP.UebrigeErtraege, 0) ELSE 0 END),
    ErtraegeHeimatlicheOhneMapping          = SUM(CASE WHEN KGK.WhGefKategorieID IS NULL AND TMP.IsZuDeKonto = 0 AND TMP.IsALBVKonto = 0 THEN ISNULL(TMP.ErtraegeHeimatliche, 0) ELSE 0 END),
    ErtragInkassoUebrigOhneMapping          = SUM(CASE WHEN KGK.WhGefKategorieID IS NULL AND TMP.IsZuDeKonto = 0 AND TMP.IsALBVKonto = 0 THEN ISNULL(TMP.ErtragInkassoUebrig, 0) ELSE 0 END),
    KOAsOhneMapping							= dbo.ConcDistinct(CASE WHEN KGK.WhGefKategorieID IS NULL AND TMP.IsZuDeKonto = 0 AND TMP.IsALBVKonto = 0 THEN TMP.KontoNr ELSE NULL END)
  INTO #output
  FROM #tmpDiffSH                             TMP 
    INNER JOIN dbo.KbKostenstelle_BaPerson    KST  WITH(READUNCOMMITTED) ON KST.KbKostenstelleID = TMP.KbKostenstelleID
                                                                        AND (KST.DatumBis IS NULL OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)
    INNER JOIN dbo.vwPerson                   PRS  WITH(READUNCOMMITTED) ON PRS.BaPersonID = KST.BaPersonID
    LEFT  JOIN dbo.BgKostenart_WhGefKategorie KGK  WITH(READUNCOMMITTED) ON KGK.BgKostenartID = TMP.BgKostenartID
    LEFT  JOIN dbo.WhGefKategorie             GEF  WITH(READUNCOMMITTED) ON GEF.WhGefKategorieID = KGK.WhGefKategorieID
    LEFT  JOIN #tmpALBVKonto                  ALBV WITH(READUNCOMMITTED) ON ALBV.KontoNr = TMP.KontoNr
    OUTER APPLY (SELECT TOP 1 
                   FT = CASE WHEN BPP.BaPersonID = LEI.BaPersonID THEN 1 ELSE 0 END,
                   BaPersonID_Fall = LEI.BaPersonID,
                   USR.UserID,
                   USR.NameVorname,
                   ORG.OrgUnitID,
                   ORG.ItemName
                 FROM dbo.BgFinanzplan_BaPerson           BPP WITH(READUNCOMMITTED) 
                   INNER JOIN dbo.BgFinanzplan            BFP WITH(READUNCOMMITTED) ON BFP.BgFinanzplanID = BPP.BgFinanzplanID
                   INNER JOIN dbo.FaLeistung              LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = BFP.FaLeistungID
                   LEFT  JOIN dbo.vwUser                  USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
                   LEFT  JOIN dbo.XOrgUnit_User           OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                                   AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
                   LEFT  JOIN dbo.XOrgUnit                ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                   INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH(READUNCOMMITTED) ON KST.BaPersonID = BPP.BaPersonID
                                                                                   AND (KST.DatumBis IS NULL 
                                                                                     OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)
                 WHERE BPP.IstUnterstuetzt = 1
                   AND KST.KbKostenstelleID = TMP.KbKostenstelleID
                   AND (BFP.DatumVon BETWEEN @DatumVon AND @DatumBis 
                    OR  BFP.DatumBis BETWEEN @DatumVon AND @DatumBis
                    OR  (BFP.DatumVon <= @DatumVon AND BFP.DatumBis >= @DatumBis))
                 ORDER BY FT DESC, BFP.DatumVon DESC) FAL
    OUTER APPLY (SELECT TOP 1 
                   FT = CASE WHEN BPP.BaPersonID = LEI.BaPersonID THEN 1 ELSE 0 END,
                   BaPersonID_Fall = LEI.BaPersonID,
                   USR.UserID,
                   USR.NameVorname,
                   ORG.OrgUnitID,
                   ORG.ItemName
                 FROM dbo.BgFinanzplan_BaPerson           BPP WITH(READUNCOMMITTED) 
                   INNER JOIN dbo.BgFinanzplan            BFP WITH(READUNCOMMITTED) ON BFP.BgFinanzplanID = BPP.BgFinanzplanID
                   INNER JOIN dbo.FaLeistung              LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = BFP.FaLeistungID
                   LEFT  JOIN dbo.vwUser                  USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
                   LEFT  JOIN dbo.XOrgUnit_User           OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                                   AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
                   LEFT  JOIN dbo.XOrgUnit                ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                   INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH(READUNCOMMITTED) ON KST.BaPersonID = BPP.BaPersonID
                                                                                   AND (KST.DatumBis IS NULL 
                                                                                     OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)
                 WHERE BPP.IstUnterstuetzt = 1
                   AND KST.KbKostenstelleID = TMP.KbKostenstelleID
                 ORDER BY FT DESC, BFP.DatumVon DESC) FAL1
    OUTER APPLY (SELECT TOP 1 *
                 FROM(SELECT TOP 1
                       FT = 1,
                       BaPersonID_Fall = LEI.BAPersonID,
                       USR.UserID,
                       USR.NameVorname,
                       ORG.OrgUnitID,
                       ORG.ItemName,
                       SortKey = 1
                     FROM FaLeistung LEI
                       INNER JOIN dbo.vwUser        USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
                       LEFT  JOIN dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                             AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
                       LEFT  JOIN dbo.XOrgUnit      ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                     WHERE LEI.BaPersonID = PRS.BaPersonID
                       AND LEI.ModulID = 2 --nur F-Modul (wenn Person die Fallträgerin selbst ist)
                     ORDER BY LEI.DatumVon DESC
                    
                     UNION
        
                     SELECT TOP 1 
                       FT = CASE WHEN PRS.BaPersonID = LEI.BaPersonID THEN 1 ELSE 0 END,
                       BaPersonID_Fall = LEI.BAPersonID,
                       USR.UserID,
                       USR.NameVorname,
                       ORG.OrgUnitID,
                       ORG.ItemName,
                       SortKey = 2
                     FROM dbo.BaPerson_Relation REL WITH (READUNCOMMITTED) 
                       LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
                                                    ON LEI.BaPersonID = CASE WHEN REL.BaPersonID_1 = PRS.BaPersonID
                                                                          THEN REL.BaPersonID_2
                                                                          ELSE REL.BaPersonID_1
                                                                        END
                       INNER JOIN dbo.vwUser        USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
                       LEFT  JOIN dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                             AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
                       LEFT  JOIN dbo.XOrgUnit      ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                     WHERE (REL.BaPersonID_1 = PRS.BaPersonID OR  REL.BaPersonID_2 = PRS.BaPersonID) 
                       AND LEI.BaPersonID IS NOT NULL
                     ORDER BY FT DESC, LEI.ModulID, LEI.DatumVon DESC --F-Modul wenn Person eine Relation zum FT hat
                   ) FAL2_TMP
                   ORDER BY FAL2_TMP.SortKey ASC) FAL2
    OUTER APPLY (SELECT TOP 1 
                   USR.UserID,
                   USR.NameVorname,
                   ORG.OrgUnitID,
                   ORG.ItemName
                 FROM IkGlaeubiger GLB
                   LEFT  JOIN dbo.IkRechtstitel RTT WITH(READUNCOMMITTED) ON RTT.IkRechtstitelID = GLB.IkRechtstitelID
                   INNER JOIN dbo.FaLeistung    LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = GLB.FaLeistungID
                                                                          OR LEI.FaLeistungID = RTT.FaLeistungID
                   INNER JOIN dbo.vwUser        USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
                   LEFT  JOIN dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                         AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
                   LEFT  JOIN dbo.XOrgUnit      ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                 WHERE GLB.BaPersonID = PRS.BaPersonID
                 ORDER BY LEI.DatumVon DESC) FAL3
  WHERE  1 = 1
    AND TMP.KbKontoklasseCode IN (3, 4) -- Aufwand, Ertrag
  GROUP BY 
    PRS.BaPersonID, FAL.FT, FAL.BaPersonID_Fall, FAL1.BaPersonID_Fall, FAL2.BaPersonID_Fall, TMP.KbKostenstelleID, TMP.BaWVCode, TMP.GemeindeCode, TMP.IsZuDeKonto, TMP.IsALBVKonto,
    PRS.NameVorname,
    -- WeiterePersonalien
    ISNULL(', ' + CONVERT(VARCHAR, DATEPART(YEAR, PRS.Geburtsdatum)), '')
                                 + CASE 
                                     WHEN PRS.NationalitaetCode = 147 
                                     THEN ISNULL(', ' + PRS.Heimatort, '')  -- bei CH Heimatort
                                     ELSE ISNULL(', ' + PRS.Nationalitaet, '') -- bei Ausländern Nationalität
                                   END,
    PRS.ZuzugKtDatum,
    PRS.Fax,
    COALESCE(FAL.UserID, FAL1.UserID, FAL2.UserID),
    COALESCE(FAL.NameVorname, FAL1.NameVorname, FAL2.NameVorname),
    COALESCE(FAL.OrgUnitID, FAL1.OrgUnitID, FAL2.OrgUnitID),
    COALESCE(FAL.ItemName, FAL1.ItemName, FAL2.ItemName),
    COALESCE(FAL3.UserID, FAL2.UserID),
    COALESCE(FAL3.NameVorname, FAL2.NameVorname),
    COALESCE(FAL3.OrgUnitID, FAL2.OrgUnitID),
    COALESCE(FAL3.ItemName, FAL2.ItemName)
    

  -----------------------------------------------------------------------------
  -- Handle Manuelle Buchung, Filter SAR/Sektion
  -----------------------------------------------------------------------------
  UPDATE #output SET SAR_S = 'Manuelle Buchung', 
                     SAR_I = 'Manuelle Buchung', 
                     Sektion_S = 'Manuelle Buchung', 
                     Sektion_I = 'Manuelle Buchung', 
                     UserID_S = NULL, 
                     UserID_I = NULL, 
                     SektionID_S = NULL, 
                     SektionID_I = NULL 
  WHERE IsManual$ = 1;

  IF(@UserID_SAR IS NOT NULL)
  BEGIN
    DELETE FROM #output WHERE ISNULL(UserID_S, -1) <> @UserID_SAR AND ISNULL(UserID_I, -1) <> @UserID_SAR;
  END

  IF(@SektionID IS NOT NULL)
  BEGIN
    DELETE FROM #output WHERE ISNULL(SektionID_S, -1) <> @SektionID AND ISNULL(SektionID_I, NULL) <> @SektionID;
  END

  ------------------------------------------
  -- Spalte AnzahlDossiers korrekt setzen
  ------------------------------------------
  
  --3 - Zuschüsse Heim (BaWvCode=50)
  ------------------------------------------
  UPDATE OTP SET AnzahlDossiers = 0
  FROM #output OTP
  WHERE OTP.BaWVCode$ = 50

  UPDATE OTP SET AnzahlDossiers = 1
  FROM #output OTP
  WHERE OTP.BaWVCode$ = 50
    AND OTP.BaPersonID$ = OTP.DossierNr
    AND EXISTS (SELECT TOP 1 1 FROM #output
                WHERE BaWVCode$ = 50
                  AND DossierNr = OTP.DossierNr
                  AND Aufwand > 0)

  --4 - Zuschüsse Nicht Heim (BaWvCode=51)
  ------------------------------------------
  UPDATE OTP SET AnzahlDossiers = 0
  FROM #output OTP
  WHERE OTP.BaWVCode$ = 51

  UPDATE OTP SET AnzahlDossiers = 1
  FROM #output OTP
  WHERE OTP.BaWVCode$ = 51
    AND OTP.BaPersonID$ = OTP.DossierNr
    AND EXISTS (SELECT TOP 1 1 FROM #output
                WHERE BaWVCode$ = 51
                  AND DossierNr = OTP.DossierNr
                  AND Aufwand > 0)

  --5 - ALBV (IsALBVKonto=1)
  ------------------------------------------
  UPDATE OTP SET AnzahlDossiers = 0
  FROM #output OTP
  WHERE OTP.IsALBVKonto$ = 1

  UPDATE OTP SET AnzahlDossiers = 1
  FROM #output OTP
  WHERE OTP.IsALBVKonto$ = 1
    AND OTP.BaPersonID$ = OTP.DossierNr
    AND EXISTS (SELECT TOP 1 1 FROM #output
                WHERE IsALBVKonto$ = 1
                  AND DossierNr = OTP.DossierNr
                  AND SummeAufwand > 0)
  
  --DWH/2a Wi.Hilfe (Filter: HasGefMapping = 1)
  ------------------------------------------
  UPDATE OTP SET AnzahlDossiers = 0
  FROM #output OTP
  WHERE OTP.HasGefMapping$ = 1

  UPDATE OTP SET AnzahlDossiers = 1
  FROM #output OTP
  WHERE OTP.HasGefMapping$ = 1
    AND OTP.BaPersonID$ = OTP.DossierNr
    AND EXISTS (SELECT TOP 1 1 FROM #output
                WHERE HasGefMapping$ = 1
                  AND DossierNr = OTP.DossierNr
                  AND SummeAufwand > 0)

  ------------------------------------------
  --WV-Code ermitteln 
  ------------------------------------------
  UPDATE OTP SET Bezugsgroesse = dbo.fnLOVText('BaWVCode', WVC.BaWVCode)
  FROM #output OTP
    LEFT JOIN dbo.BaWVCode WVC WITH(READUNCOMMITTED) ON WVC.BaPersonID = OTP.DatensatzID_Int 
                                                    AND dbo.fnDateOf(@DatumBis) BETWEEN WVC.DatumVon AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999, 12, 31))
  WHERE OTP.Bezugsgroesse = ''


  ----------------------------------------------------
  -- Filter-Regeln für Wirtschaftliche Hilfe anwenden:
  -- Damit ein Datensatz in "2a", "Filag 2012" und in der Gesamtübersicht unter "580 Wirtschaftliche Hilfe" zählt, müssen folgende Regeln erfüllt sein:
  -- - IsALBVKonto$ = 0
  -- - IsZuDeKonto$ = 0
  -- - HasGefMapping$ = 1
  -- - in den "Filag 2012" Betrag-Spalten muss mind. ein Betrag <> 0.00 sein
  ----------------------------------------------------
  UPDATE OTP SET IsWiHiRelevant$ = 1
  FROM #output OTP
  WHERE IsALBVKonto$ = 0
    AND IsZuDeKonto$ = 0
    AND HasGefMapping$ = 1
    AND (Grundbedarf <> 0
            OR Wohnkosten <> 0
            OR Gesundheitskosten <> 0
            OR KKPraemienGrundversicherung <> 0
            OR NKMassnahmenMitKesbBeschluss <> 0
            OR UeberschusszahlungAnKesb <> 0
            OR MassnahmekostenOhneKesbBeschluss <> 0
            OR SchulkostenMassnahmenOhneKesbBeschluss <> 0
            OR NKMassnahmenOhneKesbBeschluss <> 0
            OR VorsorglicheAmbulanteMassnahmen <> 0
            OR AHVMindestbeitraege <> 0
            OR UebrigeSIL <> 0
            OR IZU <> 0
            OR EFB <> 0
            OR ErwerbseinkommenNetto <> 0
            OR ALV <> 0
            OR IVTaggelderRenten <> 0
            OR EinkommenAusSozialversicherungen <> 0
            OR KinderalimenteUndEhegattenalimente <> 0
            OR Familienzulagen <> 0
            OR ErtraegeGesundheitskosten <> 0
            OR PersoenlicheRueckerstattung <> 0
            OR ElternbeitraegeVerwandtenunterstuetzung <> 0
            OR HeimatlicheVerguetungen <> 0
            OR UebrigeErtraegeDWH  <> 0
        )

  -----------------------------------------------------------------------------
  -- Output Liste
  -----------------------------------------------------------------------------
  SELECT
    Personalien       = NameVorname + WeiterePersonalien + ISNULL(', ' + CONVERT(VARCHAR, ZuzugKtDatum, 104), ''),
    PersonalienAnonym = ISNULL(CONVERT(VARCHAR, DossierNr), '-') + WeiterePersonalien,
    Fax,
    Bezugsgroesse,
    AnzahlDossiers,
    AnzahlPersonen,
    
    SAR     = CASE WHEN AnzUnterstuetzteMonate > 0 THEN SAR_S ELSE SAR_I END,
    Sektion = CASE WHEN AnzUnterstuetzteMonate > 0 THEN Sektion_S ELSE Sektion_I END,
    SAR_S,
    Sektion_S,
    SAR_I,
    Sektion_I,
    
    Aufwand_Liste                 = Aufwand,
    Ertrag_Liste                  = Ertrag,
    ErtraegeInkassoprivileg_Liste = ErtraegeInkassoprivileg,
    UebrigeErtraege_Liste         = UebrigeErtraege,
    ErtraegeHeimatliche_Liste     = ErtraegeHeimatliche,
    ErtragInkassoUebrig_Liste     = ErtragInkassoUebrig,
    
    Aufwand                 = Aufwand - AufwandOhneMapping,
    Ertrag                  = Ertrag - ErtragOhneMapping,
    ErtraegeInkassoprivileg = ErtraegeInkassoprivileg - ErtraegeInkassoprivilegOhneMapping,
    UebrigeErtraege         = UebrigeErtraege - UebrigeErtraegeOhneMapping,
    ErtraegeHeimatliche     = ErtraegeHeimatliche - ErtraegeHeimatlicheOhneMapping,
    ErtragInkassoUebrig     = ErtragInkassoUebrig - ErtragInkassoUebrigOhneMapping,
    
    AufwandOhneMapping,
    ErtragOhneMapping,
    ErtraegeInkassoprivilegOhneMapping,
    UebrigeErtraegeOhneMapping,
    ErtraegeHeimatlicheOhneMapping,
    ErtragInkassoUebrigOhneMapping,
    KOAsOhneMapping,

    MonatlichAlimente,
    Bevorschussung,
    Inkassikosten,
    Rueckerstattung,
    Netto                   = Bevorschussung + Inkassikosten - Rueckerstattung,
    BaWVCode$,
    BaPersonID$,
    DatumVonBis,
    Gemeinde,
    IsZuDeKonto$,
    IsALBVKonto$,
    IsWiHiRelevant$,
    HasUnmappedKOA$         = CASE WHEN AufwandOhneMapping <> 0 OR ErtragOhneMapping <> 0 OR ErtraegeInkassoprivilegOhneMapping <> 0 
                                     OR UebrigeErtraegeOhneMapping <> 0 OR ErtraegeHeimatlicheOhneMapping <> 0 OR ErtragInkassoUebrigOhneMapping <> 0
                                THEN CONVERT(BIT, 1) 
                                ELSE CONVERT(BIT, 0) 
                              END,

    -- Spalten für die differnenzierung Sozialhilferechnung
    HasGefMapping$,
    Jahr,
    AbrechnendeEinheit,
    AngeschlosseneEinheit,
    DossierNr,
    DatensatzID,
    DatensatzID_Int,

    -- Aufwand
    Grundbedarf,
    Wohnkosten,
    Gesundheitskosten,
    KKPraemienGrundversicherung,
    NKMassnahmenMitKesbBeschluss,
    UeberschusszahlungAnKesb,
    MassnahmekostenOhneKesbBeschluss,
    SchulkostenMassnahmenOhneKesbBeschluss,
    NKMassnahmenOhneKesbBeschluss,
    VorsorglicheAmbulanteMassnahmen,
    AHVMindestbeitraege,
    UebrigeSIL,
    IZU,
    EFB,

    -- Ertrag
    ErwerbseinkommenNetto,
    ALV,
    IVTaggelderRenten,
    EinkommenAusSozialversicherungen,
    KinderalimenteUndEhegattenalimente,
    Familienzulagen,
    ErtraegeGesundheitskosten,
    PersoenlicheRueckerstattung,
    ElternbeitraegeVerwandtenunterstuetzung,
    HeimatlicheVerguetungen,
    UebrigeErtraegeDWH,

    -- Mengeninformationen
    AnzPlatzierungenErwachseneOhneKesb = CASE WHEN MassnahmekostenOhneKesbBeschluss + NKMassnahmenOhneKesbBeschluss > 0 AND Under18 = 0 THEN 1 ELSE 0 END,
    AnzPlatzierungenErwachseneMitKesb  = CASE WHEN NKMassnahmenMitKesbBeschluss > 0 AND Under18 = 0 THEN 1 ELSE 0 END,
    AnzPlatzierungenU18OhneKesb        = CASE WHEN MassnahmekostenOhneKesbBeschluss + NKMassnahmenOhneKesbBeschluss > 0 AND Under18 = 1 THEN 1 ELSE 0 END,
    AnzPlatzierungenU18MitKesb         = CASE WHEN NKMassnahmenMitKesbBeschluss > 0 AND Under18 = 1 THEN 1 ELSE 0 END,
    AnzAmbulanteMassnahmen             = CASE WHEN VorsorglicheAmbulanteMassnahmen > 0 THEN 1 ELSE 0 END,
    --AnzDossiers = --> AnzahlDossiers 
    --AnzPersonen = --> AnzahlPersonen
    AnzUnterstuetzteMonate,
    
    SummeAufwand,
    SummeErtrag,
    ErtragOhneInkassoprovision,
    ErtragMitInkassoprovision,
    AnzahlKinderBevorschusst    = CASE WHEN Bevorschussung <> 0 THEN 1 ELSE 0 END,
    AnzahlKinderRueckerstattung = CASE WHEN Rueckerstattung <> 0 THEN 1 ELSE 0 END
  FROM #output
  ORDER BY NameVorname, WeiterePersonalien;

  -----------------------------------------------------------------------------
  -- Output Gemeinde Gruppiert
  -----------------------------------------------------------------------------
  SELECT
    Gemeinde,
    IsZuDeKonto$,
    IsALBVKonto$,
    IsWiHiRelevant$,
    BaWVCode$,
    AnzahlDossiers = SUM(AnzahlDossiers),
    AnzahlPersonen = SUM(AnzahlPersonen),

    Aufwand                 = SUM(Aufwand - AufwandOhneMapping),
    Ertrag                  = SUM(Ertrag - ErtragOhneMapping),
    ErtraegeInkassoprivileg = SUM(ErtraegeInkassoprivileg - ErtraegeInkassoprivilegOhneMapping),
    UebrigeErtraege         = SUM(UebrigeErtraege - UebrigeErtraegeOhneMapping),
    ErtraegeHeimatliche     = SUM(ErtraegeHeimatliche - ErtraegeHeimatlicheOhneMapping),
    ErtragInkassoUebrig     = SUM(ErtragInkassoUebrig - ErtragInkassoUebrigOhneMapping),

    MonatlichAlimente           = SUM(MonatlichAlimente),
    Bevorschussung              = SUM(Bevorschussung),
    Inkassikosten               = SUM(Inkassikosten),
    Rueckerstattung             = SUM(Rueckerstattung),
    AnzahlKinderBevorschusst    = SUM(CASE WHEN Bevorschussung <> 0 THEN 1 ELSE 0 END),
    AnzahlKinderRueckerstattung = SUM(CASE WHEN Rueckerstattung <> 0 THEN 1 ELSE 0 END)
  FROM #output TMP
  GROUP BY Gemeinde, IsZuDeKonto$, IsALBVKonto$, IsWiHiRelevant$, BaWVCode$;

  -----------------------------------------------------------------------------
  -- Output Anhang 1 - Gesamtübersicht
  -----------------------------------------------------------------------------
  DECLARE @OutputAnhang1 TABLE (
    SchemaHrm               VARCHAR(10),
    Rubrik                  VARCHAR(100),
    AnzahlDossiers          INT,
    AnzahlPersonen          INT,
    Aufwand                 MONEY,
    Ertrag                  MONEY,
    ErtraegeInkassoprivileg MONEY,
    ErtraegeHeimatliche     MONEY,
    UebrigeErtraege         MONEY,
    RubrikID                INT
  );

  -- Provide default records to provide at least a row with 0.00 entries
  INSERT INTO @OutputAnhang1 (
    RubrikID,
    SchemaHrm,
    Rubrik,
    AnzahlDossiers,
    AnzahlPersonen,
    Aufwand,
    Ertrag,
    ErtraegeInkassoprivileg,
    ErtraegeHeimatliche,
    UebrigeErtraege
  )
  SELECT 1, '580', 'Total wirtschaftliche Hilfe', 0, 0, 0, 0, 0, 0, 0
  UNION ALL
  SELECT 2, '581', 'Zuschüsse Heim', 0, 0, 0, 0, 0, 0, 0
  UNION ALL
  SELECT 3, '581', 'Zuschüsse nicht Heim', 0, 0, 0, 0, 0 ,0, 0
  UNION ALL
  SELECT 4, '585', 'Bevorschussung und Rückerstattung', NULL, 0, 0, 0, NULL, NULL, NULL
  UNION ALL
  SELECT 5, '585', 'Inkassokosten', NULL, NULL, 0, NULL, NULL, NULL, NULL
  
  ;WITH UebersichtCte AS(
    SELECT
      IsZuDeKonto$,
      IsALBVKonto$,
      IsWiHiRelevant$,
      BaWVCode$,
      DossierNr$ = CASE WHEN AnzahlDossiers <> 0 THEN DossierNr ELSE NULL END,
      DatensatzID_Int$ = DatensatzId_Int,

      Aufwand                 = Aufwand - AufwandOhneMapping,
      Ertrag                  = Ertrag - ErtragOhneMapping,
      ErtraegeInkassoprivileg = ErtraegeInkassoprivileg - ErtraegeInkassoprivilegOhneMapping,
      UebrigeErtraege         = UebrigeErtraege - UebrigeErtraegeOhneMapping,
      ErtraegeHeimatliche     = ErtraegeHeimatliche - ErtraegeHeimatlicheOhneMapping,
      ErtragInkassoUebrig     = ErtragInkassoUebrig - ErtragInkassoUebrigOhneMapping,

      MonatlichAlimente = MonatlichAlimente,
      Bevorschussung    = Bevorschussung,
      Inkassikosten     = Inkassikosten,
      Rueckerstattung   = Rueckerstattung,
      AnzahlKinderBevorschussungRueckerstattung = CASE WHEN Bevorschussung <> 0 OR Rueckerstattung <> 0 THEN DatensatzId_Int ELSE NULL END
    FROM #output
    --GROUP BY IsZuDeKonto$, IsALBVKonto$, BaWVCode$
  )
  
  INSERT INTO @OutputAnhang1 (
    SchemaHrm,
    Rubrik,
    AnzahlDossiers,
    AnzahlPersonen,
    Aufwand,
    Ertrag,
    ErtraegeInkassoprivileg,
    ErtraegeHeimatliche,
    UebrigeErtraege,
    RubrikID
  )  
  -- Rubrik "Total wirtschaftliche Hilfe"
  SELECT
    SchemaHrm               = '580',
    Rubrik                  = 'Total wirtschaftliche Hilfe',
    AnzahlDossiers          = COUNT(DISTINCT DossierNr$),
    AnzahlPersonen          = COUNT(DISTINCT DatensatzID_Int$),
    Aufwand                 = SUM(Aufwand),
    Ertrag                  = SUM(Ertrag),
    ErtraegeInkassoprivileg = SUM(ErtraegeInkassoprivileg),
    ErtraegeHeimatliche     = SUM(ErtraegeHeimatliche),
    UebrigeErtraege         = SUM(UebrigeErtraege),
    1
  FROM UebersichtCte
  WHERE IsWiHiRelevant$ = 1
    
  
  UNION ALL

  -- Rubrik "Zuschüsse Heim"
  SELECT
    SchemaHrm               = '581',
    Rubrik                  = 'Zuschüsse Heim',
    AnzahlDossiers          = COUNT(DISTINCT DossierNr$),
    AnzahlPersonen          = COUNT(DISTINCT DatensatzID_Int$),
    Aufwand                 = SUM(Aufwand),
    Ertrag                  = SUM(Ertrag),
    ErtraegeInkassoprivileg = SUM(ErtraegeInkassoprivileg),
    ErtraegeHeimatliche     = SUM(ErtraegeHeimatliche),
    UebrigeErtraege         = SUM(UebrigeErtraege),
    2
  FROM UebersichtCte
  WHERE IsZuDeKonto$ = 1
    AND BaWVCode$ = 50

  UNION ALL 
  
  -- Rubrik "Zuschüsse nicht Heim"
  SELECT
    SchemaHrm               = '581',
    Rubrik                  = 'Zuschüsse nicht Heim',
    AnzahlDossiers          = COUNT(DISTINCT DossierNr$),
    AnzahlPersonen          = COUNT(DISTINCT DatensatzID_Int$),
    Aufwand                 = SUM(Aufwand),
    Ertrag                  = SUM(Ertrag),
    ErtraegeInkassoprivileg = SUM(ErtraegeInkassoprivileg),
    ErtraegeHeimatliche     = SUM(ErtraegeHeimatliche),
    UebrigeErtraege         = SUM(UebrigeErtraege),
    3
  FROM UebersichtCte
  WHERE IsZuDeKonto$ = 1
    AND BaWVCode$ = 51

  UNION ALL 
  
  -- Rubrik "Bevorschussung und Rückerstattung"
  SELECT
    SchemaHrm               = '585',
    Rubrik                  = 'Bevorschussung und Rückerstattung',
    AnzahlDossiers          = NULL,
    AnzahlPersonen          = COUNT(DISTINCT AnzahlKinderBevorschussungRueckerstattung),
    Aufwand                 = SUM(Bevorschussung),
    Ertrag                  = SUM(Rueckerstattung),
    ErtraegeInkassoprivileg = NULL,
    ErtraegeHeimatliche     = NULL,
    UebrigeErtraege         = NULL,
    4
  FROM UebersichtCte
  WHERE IsALBVKonto$ = 1
    
  UNION ALL 
  
  -- Rubrik "Inkassokosten"
  SELECT
    SchemaHrm               = '585',
    Rubrik                  = 'Inkassokosten',
    AnzahlDossiers          = NULL,
    AnzahlPersonen          = NULL,
    Aufwand                 = Inkassikosten,
    Ertrag                  = NULL,
    ErtraegeInkassoprivileg = NULL,
    ErtraegeHeimatliche     = NULL,
    UebrigeErtraege         = NULL,
    5
  FROM UebersichtCte
  WHERE IsALBVKonto$ = 1
    
  SELECT 
    SchemaHrm               = MIN(SchemaHrm),
    Rubrik                  = MIN(Rubrik),
    AnzahlDossiers          = SUM(AnzahlDossiers),
    AnzahlPersonen          = SUM(AnzahlPersonen),
    Aufwand                 = SUM(Aufwand),
    Ertrag                  = SUM(Ertrag),
    ErtraegeInkassoprivileg = SUM(ErtraegeInkassoprivileg),
    ErtraegeHeimatliche     = SUM(ErtraegeHeimatliche),
    UebrigeErtraege         = SUM(UebrigeErtraege),
    RubrikID
  FROM @OutputAnhang1
  GROUP BY RubrikID
  ORDER BY RubrikID   
    
  -----------------------------------------------------------------------------
  -- Drop temp tables
  -----------------------------------------------------------------------------
  DROP TABLE #tmpZuDeKonto;
  DROP TABLE #tmpALBVKonto;
  DROP TABLE #tmpInkassoprivilegKonto;
  DROP TABLE #tmpHeimatlicheVergeutungKonto;
  DROP TABLE #tmpSozialhilfeInkasssoKonto;
  DROP TABLE #tmpRelevanteBuchungen;
  DROP TABLE #tmpBuchung;
  DROP TABLE #tmpDiffSH;
  DROP TABLE #tmpAusgabenGekuerzt;
  DROP TABLE #tmpErrorBuchung;
  DROP TABLE #output;
END;
GO