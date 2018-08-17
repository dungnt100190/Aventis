SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBFSCheckAndCreateAnfangsdossiers;
GO
/*===============================================================================================
  $Revision: 20 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  <Beschreibung der Stored Procedure, Zweck und Einsatz>
    @Param1: <Beschreibung von Parameter 1>
    @Param2: <Beschreibung von Parameter 2>
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    EXEC dbo.spBFSCheckAndCreateAnfangsdossiers 1; -- call from spXTask_Create
           --
           EXEC dbo.spBFSCheckAndCreateAnfangsdossiers 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spBFSCheckAndCreateAnfangsdossiers
(
  @OnlyCreatePendenz BIT = 0,
  @Erhebungsjahr INT = NULL
)
AS
BEGIN
  -- ----------------------------------------------------------------------------
  -- Für das Erstellen der Anfangszustands-Dossiers interessiert das Enddatum 
  -- des aktuellsten Unterbruchs der Unterstützung einer Person von mind. 6 Monaten  
  --
  -- Beispiel (Horizontal ist die Zeitachse):
  --
  --
  --   1. Anfang des Betrachtungsraums
  --   |            2. Buchung X für Person A
  --   |            |                       3. Buchung Y für Person A
  --   |            |                       |        4. Jetzt, d.h. Zeitpunkt, an dem das Script läuft
  --   |            |<--------------------->|<------>|
  --   v            v    5.Unterbruch >6M   v   6.   v
  -- --+------------+-----------------------+--------+-------> Zeitachse
  --   ^            ^                       ^        ^ 
  --   |            |                       |        |
  -- 1.7.08   1.2.09          1.9.09  15.10.09
  --  ------------->|                       |<-------------
  --  7. vorheriges Dossier                   8. neues Dossier
  --                               
  --
  -- Entscheidend für das Anfangszustands-Dossiers ist der 3. Zeitpunkt (1.9.09), 
  --       da die letzte Auszahlung mehr als 6 Monate her ist (5.Unterbruch).
  -- Weiter muss die Zeitspanne (6.) zwischen der ersten Buchung des neuen Dossiers (8.) mehr als 6 Wochen sein, 
  --       was hier stimmt: 1.9.09 bis 15.10.09 entspricht 6 Wochen.
  
  -- --------------------------------------------------------------------------
  -- init
  -- --------------------------------------------------------------------------
  SET NOCOUNT ON;
  SET @Erhebungsjahr = ISNULL(@Erhebungsjahr, YEAR(GETDATE()))

  -- init start
  DECLARE @StartTimeOfCode DATETIME;
  SET @StartTimeOfCode = GETDATE();
  
  PRINT ('start call: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  DECLARE @LeistungsartCodes VARCHAR(200);
  DECLARE @WochenNachErsterBuchung INT;
  DECLARE @ReceiverIDPendenzengruppe INT;
  
  SET @WochenNachErsterBuchung = CONVERT(INT, dbo.fnXConfig('System\Sostat\AnfangsZustandMinimumDauerSeitErsterBuchung', 6));
  SET @LeistungsartCodes = ',' + ISNULL(@LeistungsartCodes, '1,2,23,40,50') + ',';
  SET @ReceiverIDPendenzengruppe = CONVERT(INT, ISNULL(dbo.fnXConfig('System\Pendenzen\EmpfaengerPendenzAnfangszustandBFS\PendenzengruppeID', GETDATE()), -1));
  
  -- Definition von temporaeren Tabellen
  DECLARE @tmpBuchungen TABLE 
  (
    FaProzessCode INT,
    BaPersonID INT NOT NULL,           -- Antraggsteller
    Ausgleichsdatum DATETIME,
    FaLeistungID INT NOT NULL,         -- nicht eindeutig, daher max(FaLeistungID)
    UNIQUE (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID)
  );
  
  DECLARE @tmpUnterbrueche TABLE 
  (
    FaLeistungID INT,
    FaProzessCode INT,
    BaPersonID INT,           -- Antraggsteller
    Anfang DATETIME,
    Ende DATETIME
    PRIMARY KEY (FaLeistungID, FaProzessCode, BaPersonID, Anfang, Ende)
  );
  
  -- info
  PRINT ('done init: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -- --------------------------------------------------------------------------
  -- Hole alle relevanten Buchungen für BFS
  -- --------------------------------------------------------------------------
  INSERT INTO @tmpBuchungen
    SELECT DISTINCT
           FCN.FaProzessCode,
           FCN.BaPersonID,
           FCN.Ausgleichsdatum,
           FCN.FaLeistungID
    FROM dbo.fnBFSGetRelevanteBuchungen(@Erhebungsjahr, NULL, NULL, @LeistungsartCodes, NULL, 1) FCN; -- 1: Inkl. Buchungen ausserhalb Erhebungsjahr
  
  -- info
  PRINT ('done "BFS-Buchungen": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -- ----------------------------------------------------------------------------
  -- Füge eine Dummy-Buchung ein vor dem Anfang des Betrachtungsraums, konkret am 30.6 vom Vorjahr
  -- ----------------------------------------------------------------------------
  INSERT @tmpBuchungen
    SELECT DISTINCT
      TMP.FaProzessCode,
      TMP.BaPersonID,
      CONVERT(DATETIME, '30.06.' + STR(@Erhebungsjahr - 1), 104),
      TMP.FaLeistungID
    FROM @tmpBuchungen TMP
    WHERE YEAR(TMP.Ausgleichsdatum) = @Erhebungsjahr -- Für ältere Buchungen keine Dummy-Buchungen erstellen
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM @tmpBuchungen
                      WHERE Ausgleichsdatum = CONVERT(DATETIME, '30.06.' + STR(@Erhebungsjahr - 1), 104)
                        AND FaProzessCode = TMP.FaProzessCode
                        AND BaPersonID = TMP.BaPersonID
                        AND FaLeistungID = TMP.FaLeistungID) -- Da auch ältere Buchungen geholt werden, könnte bereits eine Buchung zu diesem Zeitpunkt existieren
    GROUP BY TMP.FaLeistungID, TMP.FaProzessCode, TMP.BaPersonID, TMP.FaLeistungID;
  
  -- info
  PRINT ('done "Dummy-Buchung": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -- ----------------------------------------------------------------------------
  -- Determiniere alle Unterbrüche von mind. 6 Monaten. 
  -- Mit der Dummy-Buchung von oben werden auch neue Leistungen erfasst, 
  -- und solche, deren letzte Buchungen vor dem 1.7. des Vorjahres lag
  -- ----------------------------------------------------------------------------
  INSERT @tmpUnterbrueche
    SELECT DISTINCT
      MAX(BUC1.FaLeistungID),
      BUC1.FaProzessCode,
      BUC1.BaPersonID,
      Anfang = BUC1.Ausgleichsdatum,
      Ende   = MIN(BUC2.Ausgleichsdatum)
    FROM @tmpBuchungen        BUC1
      LEFT JOIN @tmpBuchungen BUC2 ON BUC2.BaPersonID = BUC1.BaPersonID 
                                  AND BUC2.FaProzessCode = BUC1.FaProzessCode 
                                  AND BUC2.Ausgleichsdatum > BUC1.Ausgleichsdatum
    GROUP BY BUC1.BaPersonID, BUC1.Ausgleichsdatum, BUC1.FaProzessCode
    HAVING dbo.fnBFSIsNewDossierGap(BUC1.Ausgleichsdatum, MIN(BUC2.Ausgleichsdatum)) = 1;
  
  -- info
  PRINT ('done "Determinieren": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -- ----------------------------------------------------------------------------
  -- Für das Erstellen der Anfangszustands-Dossiers interessiert das Enddatum 
  -- des aktuellsten Unterbruchs der Unterstützung einer Person,  
  -- wobei nur diejenigen Unterbrüche relevant sind, bei denen das Enddatum 
  -- mind. 6 Wochen her ist vom heutigen Datum
  -- ----------------------------------------------------------------------------
  -- init vars and table
  DECLARE @EntriesCount_Unterbruch INT;
  DECLARE @EntriesIterator_Unterbruch INT;
  --
  DECLARE @EntriesCount_ImportDossier INT;
  DECLARE @EntriesIterator_ImportDossier INT;
  --
  DECLARE @FaLeistungID INT;
  DECLARE @BaPersonID INT;
  --
  DECLARE @DossierDatumVon DATETIME;
  DECLARE @Jahr INT;
  DECLARE @LaufNr INT;
  
  -- create table #Tmp_ImportDossiers
  DECLARE @Tmp_Unterbruch TABLE
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    FaLeistungID INT,
    BaPersonID INT
  );
  
  -- (re)create table #Tmp_ImportDossiers
  DECLARE @Tmp_ImportDossiers_All TABLE
  (
    Jahr INT,
    BaPersonID INT,
    FaLeistungID INT,
    ModulID INT,  
    DatumVon DATETIME,
    DatumBis DATETIME,
    Person VARCHAR(100),
    FaProzessCode INT,
    Leistungsart INT,
    LaufNr INT,
    BaPersonID$ INT
  );
  
  -- (re)create table #Tmp_ImportDossiers
  IF (OBJECT_ID('TempDB.dbo.#Tmp_ImportDossiers') IS NOT NULL)
  BEGIN 
    DROP TABLE #Tmp_ImportDossiers;
  END;
  
  CREATE TABLE #Tmp_ImportDossiers
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    FaLeistungID INT, 
    BaPersonID INT, 
    DossierDatumVon DATETIME, 
    Jahr INT,
    LaufNr INT
  );

  -- mim: ev könnte @Tmp_Unterbruch durch spBFSGetImportDossiers abgelöst werden

  -- insert entries into temp table
  INSERT INTO @Tmp_Unterbruch (FaLeistungID, BaPersonID)
    -- Selektiere nur diejenigen neuesten Unterbrüche, zu denen nicht schon ein Anfangsdossier existiert
    SELECT DISTINCT
      FaLeistungID       = FaLeistungID, 
      BaPersonID         = BaPersonID
      --UnterbruchDatumVon = Anfang,
      --UnterbruchDatumBis = Ende
    FROM
    (
      -- Hole alle neuesten Unterbrüche für den Antragssteller
      SELECT DISTINCT
        FaLeistungID = MAX(U.FaLeistungID), -- Die Leistung ist nicht unbedingt eindeutig, da ein Antragssteller mehrere sequentielle Leistungen haben kann
        BaPersonID   = U.BaPersonID,
        --Anfang       = MAX(U.Anfang),
        Ende         = MAX(U.Ende)
      FROM @tmpUnterbrueche U
      GROUP BY U.BaPersonID
    ) A
    WHERE NOT EXISTS (SELECT TOP 1 1 
                      FROM dbo.BFSDossier               DOS WITH (READUNCOMMITTED) -- Prüfe, dass es nicht schon ein Anfangszustands-Dossier für diese Antragssteller gibt, dessen Anfangsdatum dem Enddatum des aktuellsten Unterbruchs entspricht
                        INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID
                      WHERE DOS.Jahr = @Erhebungsjahr 
                        AND DOP.BaPersonID = A.BaPersonID 
                        AND DOP.PersonIndex = 0 
                        AND DOS.DatumVon = A.Ende 
                        AND DOS.Stichtag = 0);

  -- prepare vars for loop
  SET @EntriesCount_Unterbruch = @@ROWCOUNT;  -- needs to be done just after filling!
  SET @EntriesIterator_Unterbruch = 1;        -- needs to start just at the same value as IDENTITY column on table
  
  -- info
  PRINT ('starting "loops" with "' + CONVERT(VARCHAR(20), @EntriesCount_Unterbruch) + '" entries: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -----------------------------------------------------------------------------
  -- loop all entries for "Unterbruch"
  -----------------------------------------------------------------------------
  WHILE (@EntriesIterator_Unterbruch <= @EntriesCount_Unterbruch)
  BEGIN
    -- get current entry
    SELECT @FaLeistungID = TMP.FaLeistungID, 
           @BaPersonID   = TMP.BaPersonID
    FROM @Tmp_Unterbruch TMP
    WHERE TMP.ID = @EntriesIterator_Unterbruch;
    
    ---------------------------------------------------------------------------
    -- handle current "Unterbruch" entry, import dossiers
    ---------------------------------------------------------------------------
    -- empty tables
    DELETE FROM @Tmp_ImportDossiers_All;
    TRUNCATE TABLE #Tmp_ImportDossiers;
    
    -- fill tables
    INSERT INTO @Tmp_ImportDossiers_All
      EXEC dbo.spBFSGetImportDossiers @Erhebungsjahr, NULL, @BaPersonID, @LeistungsartCodes, NULL;
    
    -- get releavant data
    INSERT INTO #Tmp_ImportDossiers (FaLeistungID, BaPersonID, DossierDatumVon, Jahr, LaufNr)
      SELECT DISTINCT
             FaLeistungID    = FaLeistungID, 
             BaPersonID      = BaPersonID, 
             DossierDatumVon = DatumVon, 
             Jahr            = Jahr,
             LaufNr          = LaufNr
      FROM @Tmp_ImportDossiers_All
      WHERE YEAR(DatumVon) = @Erhebungsjahr;
    
    -- prepare vars for loop
    SET @EntriesCount_ImportDossier = @@ROWCOUNT;  -- needs to be done just after filling!
    SET @EntriesIterator_ImportDossier = 1;        -- needs to start just at the same value as IDENTITY column on table
    
    -- info
    --PRINT ('starting "importdossier" with "' + CONVERT(VARCHAR(20), @EntriesCount_ImportDossier) + '" entries: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    ---------------------------------------------------------------------------
    -- loop all entries for "ImportDossier"
    ---------------------------------------------------------------------------
    WHILE (@EntriesIterator_ImportDossier <= @EntriesCount_ImportDossier)
    BEGIN
      PRINT ('Dossier ' + CONVERT(VARCHAR, @EntriesIterator_ImportDossier) + '/' + CONVERT(VARCHAR, @EntriesCount_ImportDossier));
      -- iteriere über alle importierten Anfangszustands-Dossiers. Normalerweise ist dies nur eines, 
      -- potentiell könnte es aber schon mehrere Monate her sein seit dem letzten Aufruf, so dass in der zwischenzeit schon ein 6-Monate-Unterbruch möglich wäre
      
      -- get current entry
      SELECT @FaLeistungID    = TMP.FaLeistungID, 
             @BaPersonID      = TMP.BaPersonID,
             @DossierDatumVon = TMP.DossierDatumVon,
             @Jahr            = TMP.Jahr,
             @LaufNr          = TMP.LaufNr
      FROM #Tmp_ImportDossiers TMP
      WHERE TMP.ID = @EntriesIterator_ImportDossier;
      
      -------------------------------------------------------------------------
      -- handle current import dossier entry
      -------------------------------------------------------------------------
      -- Erstelle neues Anfangszustandsdossier
      IF (@OnlyCreatePendenz = 1)
      BEGIN
        -- Wenn nur eine Pendenz erstellt werden soll (alle ausser ZH)
        -- Erstelle eine Pendenz für den Sozi oder die Gruppe welche im Konfig-Wert definiert ist
        INSERT INTO dbo.XTask (TaskSenderCode, TaskReceiverCode, TaskTypeCode, TaskStatusCode, CreateDate, StartDate, 
                               ExpirationDate, Subject, TaskDescription, FaLeistungID, FaFallID,BaPersonID, SenderID, ReceiverID)
          SELECT DISTINCT
            TaskSenderCode   = 5,      -- DbScript
            TaskReceiverCode = CASE WHEN @ReceiverIDPendenzengruppe <> -1 THEN 2 ELSE 1 END,      -- Person oder Gruppe wenn Konfig-Wert gesetzt
            TaskTypeCode     = 14,     -- Kontrolle
            TaskStatusCode   = 1,      -- Pendent
            CreateDate       = @DossierDatumVon,
            StartDate        = NULL,
            ExpirationDate   = DATEADD(WEEK, 6, @DossierDatumVon),
            Subject          = 'Anfangszustand Sostat erfassen',
            TaskDescription  = 'Anfangszustand im Fall erfassen  - Sostat Felder',
            FaLeistungID     = LEI.FaLeistungID,
            FaFallID         = LEI.FaFallID,
            BaPersonID       = @BaPersonID,
            SenderID         = LEI.UserID,
            ReceiverID       = CASE WHEN @ReceiverIDPendenzengruppe <> -1 THEN @ReceiverIDPendenzengruppe ELSE LEI.UserID END
          FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
          WHERE FaLeistungID = @FaLeistungID
            AND NOT EXISTS (-- Prüfe nochmals, das sicher noch kein Anfangszustanddossier für diesen Antragsteller 
                            -- und dieses DatumVon und dieses Jahr existiert
                            SELECT TOP 1 1 
                            FROM dbo.XTask TSK WITH (READUNCOMMITTED)
                            WHERE (TSK.FaFallID     = LEI.FaFallID OR TSK.FaLeistungID = LEI.FaLeistungID)
                              AND TSK.BaPersonID   = @BaPersonID
                              AND TSK.TaskTypeCode = 14
                              AND ABS(DATEDIFF(MONTH, TSK.CreateDate, @DossierDatumVon)) < 6); --wurde bereits innerhalb der letzten 6 Monate eine Pendenz erstellt?
      END
      ELSE IF (NOT EXISTS (-- Wenn direkt ein Dossier erstellt werden soll (ZH)
                           -- Prüfe, dass es nicht schon ein Anfangszustands-Dossier für diese Antragssteller gibt, 
                           -- dessen Anfangsdatum dem Enddatum des aktuellsten Unterbruchs entspricht
                           SELECT TOP 1 1 
                           FROM dbo.BFSDossier               DOS
                             INNER JOIN dbo.BFSDossierPerson DOP ON DOP.BFSDossierID = DOS.BFSDossierID
                           WHERE DOS.Jahr        = @Erhebungsjahr 
                             AND DOP.BaPersonID  = @BaPersonID 
                             AND DOP.PersonIndex = 0 
                             AND DOS.LaufNr      = @LaufNr
                             AND DOS.Stichtag    = 0))
      BEGIN
        -- Erste Buchung des neuen Dossiers muss mind. 6 Wochen her sein
        IF (DATEDIFF(WEEK, @DossierDatumVon, GetDate()) >= @WochenNachErsterBuchung)
        BEGIN
          -- Erstelle das Anfangsdossier
          BEGIN TRY
            EXEC dbo.spBFSDossier_Create @Jahr, @FaLeistungID, @BaPersonID, 3, @DossierDatumVon, @DossierDatumVon, 0, @LaufNr;       -- DatumBis = DatumVon, 0 = Anfangszustand
          END TRY
          BEGIN CATCH
            DECLARE @errormsg varchar(500)
            SET @errormsg = ERROR_MESSAGE()
            EXEC spXLogAddEntry 'spBFSCheckAndCreateAnfangsdossiers', 0, 3, 'Fehler in spBFSDossier_Create (Anlegen eines Anfangszustandsdossiers)', @errormsg, '', 0
          END CATCH
        END;
      END;
      -------------------------------------------------------------------------
      
      -- prepare for next entry
      SET @EntriesIterator_ImportDossier = @EntriesIterator_ImportDossier + 1;
    END;  -- loop import dossier
    ---------------------------------------------------------------------------
    
    -- prepare for next entry
    SET @EntriesIterator_Unterbruch = @EntriesIterator_Unterbruch + 1;
  END;
  
  -- delete tables
  IF (OBJECT_ID('TempDB.dbo.#Tmp_ImportDossiers') IS NOT NULL)
  BEGIN 
    DROP TABLE #Tmp_ImportDossiers;
  END;
  
  -- info
  PRINT ('done "loops": ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
END;
GO