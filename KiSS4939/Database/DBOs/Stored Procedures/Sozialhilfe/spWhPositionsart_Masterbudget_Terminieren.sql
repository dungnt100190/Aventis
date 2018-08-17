SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhPositionsart_Masterbudget_Terminieren;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhPositionsart_Masterbudget_Terminieren.sql $
  $Author: Tabegglen $
  $Modtime: 15.09.10 12:59 $
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to check if there are Positions in a Masterbudget which need to be terminated. 
           Secondary, it also creates Follow-up Positions with the new PositionArt if needed.
           
    @BgFinanzplanID             The Finanzplan where the Masterbudget-Positions need to be checked and terminated
    @BgPositionsartID           (optional) Filter to only check Positions with this PositionArtID

  -
  RETURNS: VOID
  -
  -
  TEST:    wrong entries (expect error):
           
    SELECT *
    FROM BgPosition BPO 
        LEFT JOIN BgPosition BPO_Nachfolge ON BPO_Nachfolge.BgPositionID_CopyOf = BPO.BgPositionID
        INNER JOIN BgPositionsArt POA ON POA.BgPositionsArtID = BPO.BgPositionsArtID
        LEFT JOIN BgPositionsArt POA_Nachfolge ON POA_Nachfolge.BgPositionsartID_CopyOf = POA.BgPositionsArtID
        INNER JOIN BgBudget BUD ON BUD.BgBudgetID = BPO.BgBudgetID
        INNER JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = BUD.BgFinanzplanID
    WHERE BUD.Masterbudget = 1  -- Masterbudget des Finanzplans
        AND ISNULL(POA.DatumBis, '19000101') >= ISNULL(FIP.DatumVon, FIP.GeplantVon) AND ISNULL(POA.DatumBis, '99991231') < ISNULL(FIP.DatumBis, FIP.GeplantBis)    -- Die Positionsart wurde innerhalb des Finanzplans terminiert
        AND BPO_Nachfolge.BgPositionID IS NULL  -- Es wurde noch keine Nachfolge-Position erstellt


           good entries:
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhPositionsart_Masterbudget_Terminieren.sql $
 * 
 * 13    15.09.10 13:00 Tabegglen
 * Die Einschränkung (nur mit Nachfolge-Positionsart) wurde schon im JOIN
 * gemacht, dann muss es in der copy-SP nicht auch noch gemacht werden
 * 
 * 12    15.09.10 9:56 Tabegglen
 * #3987 Masterbudgets wurden nicht aktualisiert, wenn bereits
 * monatsbudgets existierten
 * 
 * 11    15.09.10 9:21 Tabegglen
 * Wird eine Positionsart terminiert ohne Nachfolge-Positionsart, dann
 * darf der BgAuszahlungPerson Datensatz nicht dupliziert werden (es gibt
 * ja keine Nachfolge-Position im Masterbudget)
 * 
 * 10    10.09.10 16:13 Tabegglen
 * #3978 Wird eine Positionsart terminiert ohne Nachfolge-Positionsart,
 * dann darf der BgAuszahlungPerson Datensatz nicht dupliziert werden (es
 * gibt ja keine Nachfolge-Position im Masterbudget)
 * 
 * 9     26.08.10 15:05 Tabegglen
 * #3978 Monatsbudgets müssen inkl. dem Monatsbudget des Monats von
 * DatumVon oder DatumBis aktualisiert werden (<= statt <, >= statt >)
 * 
 * 8     25.08.10 14:30 Rstahel
 * #3978: Bugfix beim Verbinden der neuen Children mit dem neuen Parent
 * 
 * 7     25.08.10 9:56 Rstahel
 * #3978: Problem mit spXParentChildCopy behoben: Die Kolonne BgPositionID
 * darf in der temporären Tabelle #NeuePositionen nicht gleich heissen wie
 * in der Kopier-Ziel-Tabelle BgAuszahlungPerson
 * 
 * 6     24.08.10 17:49 Rstahel
 * #3978: SP neu aufgebaut, so dass nun auch Parent-Child-Konstellationen
 * korrekt geklont werden. Aktuell existiert noch ein Problem mit dem
 * spXParentChildCopy der BgAuszahlungPerson, da bin ich noch daran
 * 
 * 5     20.08.10 11:40 Rstahel
 * #3978: Bedingung für die Terminierung korrigiert
 * 
 * 4     17.08.10 7:52 Cjaeggi
 * Fixed invalid 00char, tabs2spaces
 * 
 * 3     17.08.10 0:44 Rstahel
 * #3978: Terminieren von Positionsarten im Masterbudget ist nun
 * implementiert, und zwar werden Vorgänger und Nachfolgerpositionen
 * erstellt, falls nötig, und die abhängigen Daten (BgAuszahlungPerson und
 * PersonTermin) werden ebenfalls kopiert. Diese Funktion wird bei jedem
 * Finanzplan-Update ausgeführt.
 * 
 * 2     12.08.10 22:31 Rstahel
 * #3978: SP ist nun so gebaut, dass sie mehrfach ausgeführt werden kann,
 * ohne dass dies Seiteneffekte wie mehrfache Positionen etc. hat
 * 
 * 1     12.08.10 18:16 Rstahel
 * #3978: Terminieren von Positionen im Masterbudget in separate SP
 * ausgegliedert, so dass diese SP auch beim Erstellen eines FP verwendet
 * werden kann
 =================================================================================================*/

CREATE PROCEDURE dbo.spWhPositionsart_Masterbudget_Terminieren
(
  @BgFinanzplanID INT,
  @BgPositionsartID INT = NULL
)
AS
    -- ============================================================================
    -- INIT
    -- ============================================================================
    -------------------------------------------------------------------------------
    -- don't count events, it's not required!
    -------------------------------------------------------------------------------
    SET NOCOUNT ON;

    DECLARE @NeuePositionen_Count INT;
    DECLARE @NeuePositionen_Iterator INT;

    DECLARE @BgPositionID int
    DECLARE @BgPositionsArtID_Nachfolge int
    DECLARE @BgPositionsArtID_Vorgaenger int
    DECLARE @DatumVon datetime
    DECLARE @DatumBis datetime
    DECLARE @BgSpezkontoID_Old  int
    DECLARE @BgSpezkontoID_Neu  int
    DECLARE @MasterBgPositionID_Nachfolge int
    DECLARE @MasterBgPositionID_Vorgaenger int
    
    CREATE TABLE  #NeuePositionen 
    (
        BgPositionID_Neu int,				-- Neue BgPositonID (wird weiter unten nach den Inserts abgefüllt)
        BgPositionID_Old int,				-- BgPosition der zu kopierenden Position
        BgPositionID_OldParent int,			-- FK zur "alten" Parent-BgPosition
        BgPositionsArtID_Nachfolge int,		-- Nachfolge-PositionsArtID der neu zu erstellenden Position
        BgSpezkontoID_Old int,      -- Falls die alte Position auf ein Ausgabekonto ausgezahlt wurde
        TerminiereDatumVon datetime,		-- Falls die neue Position vor die "alte" gesetzt wird, muss das DatumVon der alten Position auf dieses Datum terminiert werden. Sonst ist dieser Feld NULL
        TerminiereDatumBis datetime			-- Falls die neue Position nach der "alten" gesetzt wird, muss das DatumBis der alten Position auf dieses Datum terminiert werden. Sonst ist dieser Feld NULL
    )

    DECLARE @NeuePositionen TABLE
    (
        ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
        BgPositionID int, 
        BgPositionsArtID_Nachfolge int, 
        DatumVon datetime, 
        DatumBis datetime, 
        BgSpezkontoID_Old int, 
        BgSpezkontoID_Neu int
    )
        
    -- Prüfe, ob neue Nachfolge-Positionen erstellt werden müssen, die nach der "alten" Position gesetzt werden
    INSERT INTO #NeuePositionen
    SELECT 
      NULL,
      BPO.BgPositionID,
      BPO.BgPositionID_Parent,
      POA_Nachfolge.BgPositionsArtID,
      SPZ.BgSpezkontoID,
      NULL,
      POA.DatumBis
    FROM BgPosition BPO 
      LEFT JOIN BgSpezkonto SPZ ON SPZ.BgSpezkontoID = BPO.BgSpezkontoID AND SPZ.BgSpezkontoTypCode = 1 --1: Ausgabe
      INNER JOIN BgPositionsArt POA ON POA.BgPositionsArtID = BPO.BgPositionsArtID
      LEFT JOIN BgPositionsArt POA_Nachfolge ON POA_Nachfolge.BgPositionsartID_CopyOf = POA.BgPositionsArtID
      INNER JOIN BgBudget BUD ON BUD.BgBudgetID = BPO.BgBudgetID
      INNER JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = BUD.BgFinanzplanID
      LEFT JOIN BgPosition BPO_Nachfolge ON BPO_Nachfolge.BgPositionID_CopyOf = BPO.BgPositionID AND BPO_Nachfolge.BgBudgetID = BUD.BgBudgetID
    WHERE FIP.BgFinanzplanID = @BgFinanzplanID AND BUD.Masterbudget = 1 -- Masterbudget des Finanzplans
		AND ISNULL(POA.DatumBis, '99991231') < ISNULL(FIP.DatumBis, FIP.GeplantBis)    -- Die Positionsart wurde vor dem Ende des Finanzplans terminiert
      AND (@BgPositionsartID IS NULL OR POA.BgPositionsArtID = @BgPositionsartID) -- Entweder alle Positionsarten (falls keine übergeben wurde), oder nur die übergebene Positionsart
      AND BPO_Nachfolge.BgPositionID IS NULL  -- Es wurde noch keine Nachfolge-Position erstellt
        
    -- Prüfe, ob neue Vorgänger-Positionen erstellt werden müssen, die vor die "alte" Position gesetzt werden
    INSERT INTO #NeuePositionen
    SELECT 
      NULL,
      BPO.BgPositionID,
      BPO.BgPositionID_Parent,
      POA_Vorgaenger.BgPositionsArtID,
      NULL,
      POA.DatumVon,
      NULL
    FROM BgPosition BPO 
      INNER JOIN BgPositionsArt POA ON POA.BgPositionsArtID = BPO.BgPositionsArtID
      LEFT JOIN BgPositionsArt POA_Vorgaenger ON POA_Vorgaenger.BgPositionsArtID = POA.BgPositionsartID_CopyOf
      INNER JOIN BgBudget BUD ON BUD.BgBudgetID = BPO.BgBudgetID
      INNER JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = BUD.BgFinanzplanID
      LEFT JOIN BgPosition BPO_Vorgaenger ON BPO_Vorgaenger.BgPositionID = BPO.BgPositionID_CopyOf AND BPO_Vorgaenger.BgBudgetID = BUD.BgBudgetID
    WHERE FIP.BgFinanzplanID = @BgFinanzplanID AND BUD.Masterbudget = 1 -- Masterbudget des Finanzplans
      AND ISNULL(POA.DatumVon, '19000101') > ISNULL(FIP.DatumVon, FIP.GeplantVon)    -- Die Gültigkeit der Positionsart beginnt nach dem Begin des Finanzplans
      AND (@BgPositionsartID IS NULL OR POA.BgPositionsArtID = @BgPositionsartID) -- Entweder alle Positionsarten (falls keine übergeben wurde), oder nur die übergebene Positionsart
      AND BPO_Vorgaenger.BgPositionID IS NULL -- Es wurde noch keine Vorgaenger-Position erstellt

	-- Prüfe, ob die zu kopierenden Positionen noch Parent-Positionen haben
    INSERT INTO #NeuePositionen
    SELECT 
      NULL,
      BPO_Parent.BgPositionID,
      BPO_Parent.BgPositionID_Parent,
      POA_Parent.BgPositionsArtID,
      NULL,
      NPO_Child.TerminiereDatumVon,	-- Kopiere DatumVon von der zu terminierenden Child-Position
      NPO_Child.TerminiereDatumBis	-- Kopiere DatumBis von der zu terminierenden Child-Position
    FROM #NeuePositionen NPO_Child
		INNER JOIN BgPosition BPO_Parent ON BPO_Parent.BgPositionID = NPO_Child.BgPositionID_OldParent
      INNER JOIN BgPositionsArt POA_Parent ON POA_Parent.BgPositionsArtID = BPO_Parent.BgPositionsArtID
    
	-- Prüfe, ob die zu kopierenden Positionen noch Child-Positionen haben
    INSERT INTO #NeuePositionen
    SELECT 
      NULL,
      BPO_Child.BgPositionID,
      BPO_Child.BgPositionID_Parent,
      POA_Child.BgPositionsArtID,
      NULL,
      NPO_Parent.TerminiereDatumVon,	-- Kopiere DatumVon von der zu terminierenden Parent-Position
  		NPO_Parent.TerminiereDatumBis	-- Kopiere DatumBis von der zu terminierenden Parent-Position
    FROM #NeuePositionen NPO_Parent 
      INNER JOIN BgPosition BPO_Child ON BPO_Child.BgPositionID_Parent = NPO_Parent.BgPositionID_Old
      INNER JOIN BgPositionsArt POA_Child ON POA_Child.BgPositionsArtID = BPO_Child.BgPositionsArtID
      LEFT JOIN #NeuePositionen NPO_AlreadySelected ON NPO_AlreadySelected.BgPositionID_Old = BPO_Child.BgPositionID			
    WHERE NPO_AlreadySelected.BgPositionID_Old IS NULL	-- Stelle sicher, dass wir die Child-Position nur zufügen, wenn sich nicht schon in der temporären Tabelle existiert

    -- prepare internal table
    INSERT INTO @NeuePositionen (
      BgPositionID, 
      BgPositionsArtID_Nachfolge, 
      DatumVon, 
      DatumBis, 
      BgSpezkontoID_Old
    )
    SELECT 
      NPO.BgPositionID_Old,
      NPO.BgPositionsArtID_Nachfolge,
      DatumVon = DATEADD(d, 1, NPO.TerminiereDatumBis),  -- Nachfolgepositionen beginnen einen Tag nach der Originalposition
      DatumBis = DATEADD(d, -1, NPO.TerminiereDatumVon),  -- Vorgaengerpositionen enden einen Tag vor der Nachfolgeposition
      NPO.BgSpezkontoID_Old
    FROM #NeuePositionen NPO
    ORDER BY BgPositionID_OldParent	-- Kopiere zuerst die Parents (d.h. diejenigen Positionen, bei denen BgPositionID_OldParent NULL ist). Damit stellen wir sicher, dass wenn die Children kopiert werden, die Parents bereits kopiert sind, und somit angehängt werden können)
    
    -- prepare vars for loop
    SET @NeuePositionen_Count = @@ROWCOUNT;
    SET @NeuePositionen_Iterator = 1;
            
    WHILE (@NeuePositionen_Iterator <= @NeuePositionen_Count)
    BEGIN
      -- fetch current entry
      SELECT 
        @BgPositionID = TMP.BgPositionID, 
        @BgPositionsArtID_Nachfolge = TMP.BgPositionsArtID_Nachfolge, 
        @DatumVon = TMP.DatumVon, 
        @DatumBis = TMP.DatumBis, 
        @BgSpezkontoID_Old = TMP.BgSpezkontoID_Old, 
        @BgSpezkontoID_Neu = TMP.BgSpezkontoID_Neu
      FROM @NeuePositionen TMP
      WHERE TMP.ID = @NeuePositionen_Iterator;

      -- wenn wir eine Nachfolge-Positionsart haben, können wir ein Duplikat mit dieser Nachfolge-Positionsart erstellen
      IF (@BgPositionsArtID_Nachfolge IS NOT NULL)
      BEGIN
        --wurde bereits ein neues Spezialkonto erstellen?
        IF(@BgSpezkontoID_Neu IS NULL)
        BEGIN
          --müssen wir ein neues spezialkonto erstellen?
          IF(@BgSpezkontoID_Old IS NOT NULL)
          BEGIN
            INSERT INTO BgSpezkonto (FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, DatumVon, BgPositionsartID, BgKostenartID, BaPersonID, BaInstitutionID)
              SELECT SPZ.FaLeistungID, SPZ.BgSpezkontoTypCode, SUBSTRING(BPT.Name + IsNull(' (' + PRS.NameVorname + ')', ''),1,100), @DatumVon, BPT.BgPositionsartID, BPT.BgKostenartID, SPZ.BaPersonID,
                SPZ.BaInstitutionID
              FROM dbo.BgSpezkonto SPZ
                INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = @BgPositionsartID_Nachfolge
                LEFT  JOIN dbo.vwPerson        PRS ON PRS.BaPersonID = SPZ.BaPersonID
              WHERE SPZ.BgSpezkontoID = @BgSpezkontoID_Old

              SET @BgSpezkontoID_Neu = SCOPE_IDENTITY();
               
              UPDATE @NeuePositionen SET BgSpezkontoID_Neu = @BgSpezkontoID_Neu
              WHERE BgSpezkontoID_Old = @BgSpezkontoID_Old;

              UPDATE SPZ SET SPZ.DatumBis = NPO.TerminiereDatumBis
              FROM BgSpezkonto SPZ
                INNER JOIN #NeuePositionen NPO ON NPO.BgSpezkontoID_Old = SPZ.BgSpezkontoID
              WHERE SPZ.BgSpezkontoID = @BgSpezkontoID_Old;
          END
        END

        INSERT INTO BgPosition (BgPositionID_CopyOf, BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, ShBelegID, 
                                                        Betrag, Reduktion, Abzug, BetragEff, MaxBeitragSD, Buchungstext, BgSpezkontoID, VerwaltungSD, Bemerkung, 
                                                        DatumVon, DatumBis, OldID, BaInstitutionID, DebitorBaPersonID, VerwPeriodeVon, VerwPeriodeBis, FaelligAm, RechnungDatum,
                                                        BgBewilligungStatusCode)
            SELECT BgPositionID, BgBudgetID, BaPersonID, BgKategorieCode, @BgPositionsartID_Nachfolge, ShBelegID,
                        Betrag, Reduktion, Abzug, BetragEff, MaxBeitragSD, Buchungstext, IsNull(@BgSpezkontoID_Neu, BPO.BgSpezkontoID), VerwalTungSD, Bemerkung,
                        ISNULL(@DatumVon, DatumVon), ISNULL(@DatumBis, DatumBis), OldID, BaInstitutionID, DebitorBaPersonID, VerwPeriodeVon, VerwPeriodeBis, FaelligAm, RechnungDatum,
                        BgBewilligungStatusCode
            FROM BgPosition BPO
            WHERE BgPositionID = @BgPositionID;

        SET @MasterBgPositionID_Nachfolge = SCOPE_IDENTITY();
            
        -- Speichere die neue PositionsID
        UPDATE #NeuePositionen SET BgPositionID_Neu = @MasterBgPositionID_Nachfolge
      	WHERE BgPositionID_Old = @BgPositionID				
                
        -- Wenn bereits Monatsbudgets existieren, welche aufgrund der terminierten Masterbudget-Position erstellt wurden, müssen wir diese Positionen anhand der Nachfolge-Masterbudget-Positionsart aktualisieren (aber nur diejenigen Budget, deren Monat nach dem Terminierungsdatum liegen)
        UPDATE POS
        SET BgPositionID_CopyOf = @MasterBgPositionID_Nachfolge, 
            BgPositionsartID = @BgPositionsartID_Nachfolge,
            BgSpezkontoID = IsNull(@BgSpezkontoID_Neu, POS.BgSpezkontoID)
        FROM BgPosition POS
            INNER JOIN BgBudget BDG ON BDG.BgBudgetID = POS.BgBudgetID
        WHERE BDG.MasterBudget = 0  -- Nur Monatsbudgets
            AND BDG.BgFinanzplanID = @BgFinanzplanID        -- Nur Budgets dieses Finanzplans
            AND POS.BgPositionID_CopyOf = @BgPositionID
            AND (@DatumVon IS NULL OR (BDG.Jahr = YEAR(@DatumVon) AND BDG.Monat >= MONTH(@DatumVon)) OR (BDG.Jahr > YEAR(@DatumVon)))	-- Falls @DatumVon gesetzt, müssen alle Monatsbudget nach diesem Datum gesucht werden
            AND (@DatumBis IS NULL OR (BDG.Jahr = YEAR(@DatumBis) AND BDG.Monat <= MONTH(@DatumBis)) OR (BDG.Jahr < YEAR(@DatumBis)))	-- Falls @DatumBis gesetzt, müssen alle Monatsbudget vor diesem Datum gesucht werden
      END;
        
      -- prepare for next entry
      SET @NeuePositionen_Iterator = @NeuePositionen_Iterator + 1;
    END; -- [while loop cursor]

	-- Falls die Original-Position einen Parent hatte, muss nun auch die kopierte Child-Position an ihren neuen Parent gehängt werden
	UPDATE BPO_ChildNeu SET 
		BgPositionID_Parent = NPO_NewParent.BgPositionID_Neu
	FROM BgPosition BPO_ChildNeu 
		INNER JOIN #NeuePositionen NPO_ChildNeu ON NPO_ChildNeu.BgPositionID_Neu = BPO_ChildNeu.BgPositionID
		INNER JOIN BgPosition BPO_ChildOld ON BPO_ChildOld.BgPositionID = NPO_ChildNeu.BgPositionID_Old		-- Vorgänger-Child-Position 
		INNER JOIN #NeuePositionen NPO_NewParent ON NPO_NewParent.BgPositionID_Old = BPO_ChildOld.BgPositionID_Parent	-- Neuer Parent

    -- Terminiere noch die Original-Positionen
    UPDATE BPO SET
		DatumVon = ISNULL(NPO.TerminiereDatumVon, BPO.DatumVon),
		DatumBis = ISNULL(NPO.TerminiereDatumBis, BPO.DatumBis)
    FROM #NeuePositionen NPO
        INNER JOIN BgPosition BPO ON BPO.BgPositionID = NPO.BgPositionID_Old

	-- Kopiere den neuen Positionsart-Text, falls der Original-Positionstext auch dem Original-Positionsart-Text entsprochen hat
	UPDATE BPO_New SET
		Buchungstext = POA_New.Name	-- Setze neuen Positions-Text
    FROM #NeuePositionen NPO
		INNER JOIN BgPosition BPO_New ON BPO_New.BgPositionID = NPO.BgPositionID_Neu
		INNER JOIN BgPositionsArt POA_New ON POA_New.BgPositionsArtID = BPO_New.BgPositionsArtID
		INNER JOIN BgPosition BPO_Old ON BPO_Old.BgPositionID = NPO.BgPositionID_Old
		INNER JOIN BgPositionsArt POA_Old ON POA_Old.BgPositionsArtID = BPO_Old.BgPositionsArtID
	WHERE BPO_Old.Buchungstext = POA_Old.Name	-- Nur wenn der Original-Positionstext auch dem Original-Positionsart-Text entspricht 

	
    -- Copy BgAuszahlungPerson for all terminated Positions (having a Nachfolge-Position)
    SELECT PK     = BgAuszahlungPersonID, 
           Parent = CONVERT(INT, NULL), 
           KeyNew = CONVERT(INT, NULL)
    INTO #BgAuszahlungPerson
    FROM BgAuszahlungPerson   BAP
      INNER  JOIN #NeuePositionen NPO ON NPO.BgPositionID_Old = BAP.BgPositionID AND NPO.BgPositionID_Neu IS NOT NULL;    
    
    EXECUTE dbo.spXParentChildCopy '#BgAuszahlungPerson',
                                   'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                                   'BgPositionID', '(SELECT T.BgPositionID_Neu FROM #NeuePositionen T WHERE T.BgPositionID_Old = BgPositionID)';
    
    -- Copy BgAuszahlungPersonTermin for all terminated Positions
    INSERT INTO BgAuszahlungPersonTermin(BgAuszahlungPersonID, Datum)
      SELECT TMP.KeyNew, BAT.Datum
      FROM #BgAuszahlungPerson              TMP
        INNER JOIN BgAuszahlungPerson       BAP ON BAP.BgAuszahlungPersonID = TMP.PK
        INNER JOIN BgAuszahlungPersonTermin BAT ON BAT.BgAuszahlungPersonID = TMP.PK 
                                               AND BAP.BgAuszahlungsTerminCode = 4;     -- 4 = Valuta
                                               
             
    DROP TABLE #BgAuszahlungPerson   
    DROP TABLE #NeuePositionen                    
    
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
