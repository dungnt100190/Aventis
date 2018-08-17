SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spQRYStundenProLeistungsart;
GO
/*===============================================================================================
  $Revision: 27 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to get details for query "Stunden pro Leistungsart" (PI-Edition)
    @LanguageCode:                The language code to use for ML values
    @OrgUnitID:                   The orgunit to use as filter for result
    @ZeitraumVon:                 The start of date to use
    @ZeitraumBis:                 The end of date to use 
    @BDELAAuswDLCode:             The code to use for filter
    @BDELAAuswProduktCode:        The code to use for filter
    @BDELAAuswPIAuftragCode:      The code to use for filter
    @BDELAAuswFakturaCode:        The code to use for filter
    @BDELeistungsartID:           The bdeleistungsartid to use as filter for result
    @UserID:                      The userid to use as filter for result
    @NurExport:                   Flag, if only Leistungen with KeinExport should be used 
    @ResultTable:                 The desired result table to generate
                                  - 'klient/innen'
                                  - 'zusammenfassung'
                                  - 'promonat'
                                  - 'kostenstelle'
    @CurrentUserID:               The userid of the user who is currently logged in and using KiSS
    @SpecialRightKostenstelleHS:  Set if the current user has a special right to see more orgunits and users 
    @SpecialRightKostenstelleKGS: Set if the current user has a special right to see more orgunits and users 
  -
  RETURNS: Result depending on given search parameters and ResultTable
=================================================================================================
  TEST:    EXEC dbo.spQRYStundenProLeistungsart 1, 91, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klient/innen', 2, 1, 1      -- BS Bern-Mittelland
           EXEC dbo.spQRYStundenProLeistungsart 1, 91, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'zusammenfassung', 2, 1, 1   -- BS Bern-Mittelland
           EXEC dbo.spQRYStundenProLeistungsart 1, 91, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'promonat', 2, 1, 1          -- BS Bern-Mittelland
           EXEC dbo.spQRYStundenProLeistungsart 1, 91, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'kostenstelle', 2, 1, 1      -- BS Bern-Mittelland
           --
           EXEC dbo.spQRYStundenProLeistungsart 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klient/innen', 2, 1, 1
           EXEC dbo.spQRYStundenProLeistungsart 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'zusammenfassung', 2, 1, 1
           EXEC dbo.spQRYStundenProLeistungsart 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'promonat', 2, 1, 1
           EXEC dbo.spQRYStundenProLeistungsart 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'kostenstelle', 2, 1, 1
=================================================================================================*/

CREATE PROCEDURE dbo.spQRYStundenProLeistungsart
(
  @LanguageCode INT,
  @OrgUnitID INT,
  @ZeitraumVon DATETIME,
  @ZeitraumBis DATETIME,
  @BDELAAuswDLCode INT,
  @BDELAAuswProduktCode INT,
  @BDELAAuswPIAuftragCode INT,
  @BDELAAuswFakturaCode INT,
  @BDELeistungsartID INT,
  @UserID INT,
  @NurExport BIT,
  @ResultTable VARCHAR(50),
  @CurrentUserID INT,
  @SpecialRightKostenstelleHS BIT,
  @SpecialRightKostenstelleKGS BIT
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' start call');
  
  -------------------------------------------------------------------------------
  -- set default values
  -------------------------------------------------------------------------------
  SET @LanguageCode                = ISNULL(@LanguageCode, 1);
  SET @SpecialRightKostenstelleHS  = ISNULL(@SpecialRightKostenstelleHS, 0);
  SET @SpecialRightKostenstelleKGS = ISNULL(@SpecialRightKostenstelleKGS, 0);
  SET @NurExport = ISNULL(@NurExport, 0);
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------	
  DECLARE @ZeitraumString VARCHAR(100);
  DECLARE @DatumBisOrGetDate DATETIME;
  
  -- set vars
  SET @DatumBisOrGetDate = ISNULL(@ZeitraumBis, GETDATE());
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@ResultTable IS NULL OR @CurrentUserID IS NULL)
  BEGIN
    -- invalid data
    SELECT [Error] = 'Error: Invalid parametes, cannot search data!',
           [BaPersonID$] = NULL;
    
    -- do not continue
    RETURN;
  END;
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@ZeitraumVon, @ZeitraumBis);
  
  -------------------------------------------------------------------------------
  -- init temp table
  -------------------------------------------------------------------------------
  DECLARE @Temp TABLE
  (
    BDELeistungID INT NOT NULL PRIMARY KEY,
    UserID INT,
    BaPersonID INT,    
    KostenstelleOrgUnitID INT,
    HistKGSOfUserOrOrgUnit VARCHAR(100),
    KeinExport BIT,
    HistKostenstelle INT,
    BDELeistungsartID INT
  );
  
  DECLARE @TempHistKSTOrgUnitItemName TABLE
  (
    Datum DATETIME,
    HistKostenstelle INT,
    KST VARCHAR(150)
  );

  DECLARE @TempHistKGSOfUserOrOrgUnit TABLE
  (
    Datum DATETIME,
    KostenstelleOrgUnitID INT,
    KGS VARCHAR(100)
  );

  DECLARE @TempHistLAValue TABLE
  (
    Datum DATETIME,
    BDELeistungsartID INT,
    KTRStandard VARCHAR(20)
  );


  -------------------------------------------------------------------------------
  -- fill temp table with persons
  -------------------------------------------------------------------------------
  -- get all person who fit to defined search criterias
  INSERT INTO @Temp (BDELeistungID, UserID, BaPersonID, KostenstelleOrgUnitID, KeinExport, HistKostenstelle, BDELeistungsartID)
    SELECT BDELeistungID         = LEI.BDELeistungID, 
           UserID                = LEI.UserID,
           BaPersonID            = LEI.BaPersonID,
           KostenstelleOrgUnitID = LEI.KostenstelleOrgUnitID,
           KeinExport            = LEI.KeinExport,
           HistKostenstelle      = LEI.HistKostenstelle,
           BDELeistungsartID     = LEI.BDELeistungsartID
    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
    WHERE (@OrgUnitID IS NULL OR LEI.KostenstelleOrgUnitID = @OrgUnitID) 
      AND (@UserID IS NULL OR LEI.UserID = @UserID)
      AND (@BDELeistungsartID IS NULL OR LEI.BDELeistungsartID = @BDELeistungsartID)
      AND (@NurExport = 0 OR LEI.KeinExport <> @NurExport )
      AND LEI.Datum BETWEEN ISNULL(@ZeitraumVon, LEI.Datum) AND ISNULL(@ZeitraumBis, LEI.Datum);
  
  -- info
  PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' filled temporary table');
  
  -- Temp-Tabellen für History Informationen laden damit es nicht für jede BDELeistung neu berechnet werden muss
  IF (@ResultTable = 'klient/innen' OR @ResultTable = 'kostenstelle' OR @ResultTable = 'promonat')
  BEGIN
    -- HistKostenstelle
    ;WITH HistKSTOrgUnitItemNameCTE 
    AS
    (
      SELECT DISTINCT HistKostenstelle
      FROM @Temp
    )

    INSERT INTO @TempHistKSTOrgUnitItemName
      SELECT 
        @DatumBisOrGetDate,
        HistKostenstelle,
        dbo.fnBDEGetHistKSTOrgUnitItemName(HistKostenstelle, @DatumBisOrGetDate)
      FROM HistKSTOrgUnitItemNameCTE

    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' filled temporary @TempHistKSTOrgUnitItemName table');
  END;

  IF (@ResultTable = 'klient/innen' OR @ResultTable = 'kostenstelle' OR @ResultTable = 'promonat')
  BEGIN
    -- KostenstelleOrgUnitID
    ;WITH HistKGSOfUserOrOrgUnitCTE 
    AS
    (
      SELECT DISTINCT KostenstelleOrgUnitID
      FROM @Temp
    )

    INSERT INTO @TempHistKGSOfUserOrOrgUnit
      SELECT 
        @DatumBisOrGetDate,
        KostenstelleOrgUnitID,
        dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @DatumBisOrGetDate, KostenstelleOrgUnitID, 0, 1)
      FROM HistKGSOfUserOrOrgUnitCTE
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' filled temporary @TempHistKGSOfUserOrOrgUnit table');
  END;

  IF (@ResultTable = 'klient/innen' OR @ResultTable = 'zusammenfassung' OR @ResultTable = 'kostenstelle' OR @ResultTable = 'promonat')
  BEGIN
    -- BDELeistungsartID
    ;WITH HistLAValueCTE 
    AS
    (
      SELECT DISTINCT BDELeistungsartID
      FROM @Temp
    )

    INSERT INTO @TempHistLAValue (Datum, BDELeistungsartID, KTRStandard)
      SELECT 
        @DatumBisOrGetDate,
        BDELeistungsartID,
        KTRStandard = CONVERT(VARCHAR(20),dbo.fnBDEGetHistLAValue('KTRStandard', BDELeistungsartID, @DatumBisOrGetDate))
      FROM HistLAValueCTE
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' filled temporary @TempHistLAValue table');  
  END;

  -------------------------------------------------------------------------------
  -- filter rights-depending users/orgunits
  -------------------------------------------------------------------------------
  -- if user has no HS-special-right, some restrictions are neccessary
  -- same filter as in CtlQueryBaAktiveKlienten_Load
  IF (@SpecialRightKostenstelleHS = 0)
  BEGIN
    IF (@SpecialRightKostenstelleKGS = 0)
    BEGIN
      -- user has NO-special-rights, filter by users
      
      -- init temporary table because of performance
      DECLARE @TmpAllowedUserIDs TABLE
      (
        UserID INT NOT NULL PRIMARY KEY
      );
      
      -- fill temporary table
      INSERT INTO @TmpAllowedUserIDs (UserID)
        SELECT USR.Code
        FROM dbo.fnQryGetMitarbeiterDropDown(@CurrentUserID, @SpecialRightKostenstelleHS, @SpecialRightKostenstelleKGS, 0) USR
        WHERE USR.Code IS NOT NULL;  -- no empty entry
    
      -- user has NO special rights
      -- delete entries from users the current user cannot see (this includes more than orgunit), same procedure as in query-gui
      DELETE FROM @Temp
      WHERE ISNULL(UserID, -1) NOT IN (SELECT USR.UserID
                                       FROM @TmpAllowedUserIDs USR);
    END
    ELSE
    BEGIN
      -- user has KGS-special-right, filter by orgunit
    
      -- init temporary table because of performance
      DECLARE @TmpAllowedOrgUnitIDs TABLE
      (
        AllowedKSTOrgUnitID INT NOT NULL PRIMARY KEY
      );
      
      -- fill temporary table
      INSERT INTO @TmpAllowedOrgUnitIDs (AllowedKSTOrgUnitID)
        SELECT ORG.Code
        FROM dbo.fnQryGetKostenstelleDropDown(@CurrentUserID, @SpecialRightKostenstelleHS, @SpecialRightKostenstelleKGS) ORG
        WHERE ORG.Code IS NOT NULL;  -- no empty entry
    
      -- user has special rights and can see more orgunits and users
      -- delete entries from orgunits the user cannot see (this includes non KGS-users), same procedure as in query-gui
      DELETE FROM @Temp
      WHERE ISNULL(KostenstelleOrgUnitID, -1) NOT IN (SELECT ORG.AllowedKSTOrgUnitID
                                                      FROM @TmpAllowedOrgUnitIDs ORG);
    END;
  END;
  
  -- info
  PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' done with preparation, processing now output for <' + @ResultTable + '>');
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  
  -------------------------------------------------------------------------------
  -- output 'klient/innen'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'klient/innen')
  BEGIN
    SELECT BaPersonID$            = PRS.BaPersonID,
           [Leistungsart]         = ISNULL(TXT.Text, LEA.Bezeichnung),
           [KTR St.]              = (SELECT TOP 1 KTRStandard FROM @TempHistLAValue WHERE BDELeistungsartID = LEI.BDELeistungsartID),
           [Klienten/innen]       = dbo.fnGetLastFirstName(NULL, PRS.[Name], PRS.Vorname),
           [Hauptbehinderungsart] = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
           [BSV-Behinderungsart]  = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, @LanguageCode),
           [MitarbeiterIn]        = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           [Personal-Nr.]         = CONVERT(VARCHAR(50), dbo.fnXGetHistUserValue('MitarbeiterNr', LEI.UserID, @DatumBisOrGetDate)),
           [Lohntyp]              = dbo.fnLOVMLText('BenutzerLohnTyp', 
                                                    CONVERT(INT, dbo.fnXGetHistUserValue('LohntypCode', LEI.UserID, @DatumBisOrGetDate)),
                                                    @LanguageCode),
           [Stunden]              = ISNULL(SUM(LEI.Dauer), 0.0),
           [Anzahl]               = ISNULL(SUM(LEI.Anzahl), 0),
           [BG]                   = dbo.fnBDEGetPensumPercent(LEI.UserID, @DatumBisOrGetDate),
           [KST]                  = (SELECT TOP 1 KST FROM @TempHistKSTOrgUnitItemName WHERE HistKostenstelle = LEI.HistKostenstelle),
           [KGS]                  = (SELECT TOP 1 KGS FROM @TempHistKGSOfUserOrOrgUnit WHERE KostenstelleOrgUnitID = LEI.KostenstelleOrgUnitID),
           [ZLE]                  = dbo.fnGetLOVMLText('BDELeistungsartAuswDienstleistung', LEA.AuswDienstleistungCode, @LanguageCode),
           [Produkt]              = dbo.fnGetLOVMLText('BDELeistungsartAuswProdukt', LEA.AuswProduktCode, @LanguageCode),
           [PI-Auftrag]           = dbo.fnGetLOVMLText('BDELeistungsartAuswPIAuftrag', LEA.AuswPIAuftragCode, @LanguageCode),
           [Faktura]              = dbo.fnGetLOVMLText('BDELeistungsartAuswFaktura', LEA.AuswFakturaCode, @LanguageCode),
           [Zeitraum]             = @ZeitraumString,
           [Kein Export]          = TMP.KeinExport

    FROM @Temp                       TMP
      INNER JOIN dbo.BDELeistung     LEI WITH (READUNCOMMITTED) ON LEI.BDELeistungID = TMP.BDELeistungID
      INNER JOIN dbo.BDELeistungsart LEA WITH (READUNCOMMITTED) ON LEA.BDELeistungsartID = LEI.BDELeistungsartID
      LEFT  JOIN dbo.XLangText       TXT WITH (READUNCOMMITTED) ON TXT.TID = LEA.BezeichnungTID 
                                                               AND TXT.LanguageCode = @LanguageCode
      LEFT  JOIN dbo.BaPerson        PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
    
    WHERE (@BDELAAuswDLCode IS NULL OR LEA.AuswDienstleistungCode = @BDELAAuswDLCode) 
      AND (@BDELAAuswProduktCode IS NULL OR LEA.AuswProduktCode = @BDELAAuswProduktCode) 
      AND (@BDELAAuswPIAuftragCode IS NULL OR LEA.AuswPIAuftragCode = @BDELAAuswPIAuftragCode) 
      AND (@BDELAAuswFakturaCode IS NULL OR LEA.AuswFakturaCode = @BDELAAuswFakturaCode)
    
    GROUP BY PRS.BaPersonID, ISNULL(TXT.Text, LEA.Bezeichnung), LEI.BDELeistungsartID, LEI.UserID, PRS.[Name], PRS.Vorname, 
             PRS.HauptBehinderungsartCode, PRS.BSVBehinderungsartCode, LEI.KostenstelleOrgUnitID, LEA.AuswDienstleistungCode, 
             LEA.AuswProduktCode, LEA.AuswPIAuftragCode, LEA.AuswFakturaCode, LEI.HistKostenstelle, TMP.KeinExport
    
    ORDER BY [Leistungsart], [Klienten/innen], [Stunden];
    
    -- info
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' done output for <' + @ResultTable + '>');
    
    -- done
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- output 'zusammenfassung'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'zusammenfassung')
  BEGIN
    SELECT [Leistungsart]     = ISNULL(TXT.Text, LEA.Bezeichnung),
           [KTR St.]          = (SELECT TOP 1 KTRStandard FROM @TempHistLAValue WHERE BDELeistungsartID = LEI.BDELeistungsartID),
           [Klienten/innen]   = COUNT(DISTINCT LEI.BaPersonID),
           [Stunden]          = ISNULL(SUM(LEI.Dauer), 0.0),
           [Anzahl]           = ISNULL(SUM(LEI.Anzahl), 0),
           [ZLE]              = dbo.fnGetLOVMLText('BDELeistungsartAuswDienstleistung', LEA.AuswDienstleistungCode, @LanguageCode),
           [Produkt]          = dbo.fnGetLOVMLText('BDELeistungsartAuswProdukt', LEA.AuswProduktCode, @LanguageCode),
           [PI-Auftrag]       = dbo.fnGetLOVMLText('BDELeistungsartAuswPIAuftrag', LEA.AuswPIAuftragCode, @LanguageCode),
           [Faktura]          = dbo.fnGetLOVMLText('BDELeistungsartAuswFaktura', LEA.AuswFakturaCode, @LanguageCode),
           [Zeitraum]         = @ZeitraumString,
           [Kein Export]      = TMP.KeinExport
    
    FROM @Temp                       TMP
      INNER JOIN dbo.BDELeistung     LEI WITH (READUNCOMMITTED) ON LEI.BDELeistungID = TMP.BDELeistungID
      INNER JOIN dbo.BDELeistungsart LEA WITH (READUNCOMMITTED) ON LEA.BDELeistungsartID = LEI.BDELeistungsartID
      LEFT  JOIN dbo.XLangText       TXT WITH (READUNCOMMITTED) ON TXT.TID = LEA.BezeichnungTID 
                                                               AND TXT.LanguageCode = @LanguageCode

    WHERE (@BDELAAuswDLCode IS NULL OR LEA.AuswDienstleistungCode = @BDELAAuswDLCode) 
      AND (@BDELAAuswProduktCode IS NULL OR LEA.AuswProduktCode = @BDELAAuswProduktCode) 
      AND (@BDELAAuswPIAuftragCode IS NULL OR LEA.AuswPIAuftragCode = @BDELAAuswPIAuftragCode) 
      AND (@BDELAAuswFakturaCode IS NULL OR LEA.AuswFakturaCode = @BDELAAuswFakturaCode)
    
    GROUP BY ISNULL(TXT.Text, LEA.Bezeichnung), LEA.AuswDienstleistungCode, LEI.BDELeistungsartID,
             LEA.AuswProduktCode, LEA.AuswPIAuftragCode, LEA.AuswFakturaCode, TMP.KeinExport
    
    ORDER BY [Leistungsart], [Klienten/innen], [Stunden];
    
    -- info
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' done output for <' + @ResultTable + '>');
    
    -- done
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- output 'kostenstelle'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'kostenstelle')
  BEGIN
    -- info
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' done updating temporary table used for ouptut of <' + @ResultTable + '>');
    
    -- generate real output
    SELECT [KGS]              = (SELECT TOP 1 KGS FROM @TempHistKGSOfUserOrOrgUnit WHERE KostenstelleOrgUnitID = LEI.KostenstelleOrgUnitID),
           [KST]              = (SELECT TOP 1 KST FROM @TempHistKSTOrgUnitItemName WHERE HistKostenstelle = LEI.HistKostenstelle),
           [Leistungsart]     = ISNULL(TXT.Text, LEA.Bezeichnung),
           [KTR St.]          = (SELECT TOP 1 KTRStandard FROM @TempHistLAValue WHERE BDELeistungsartID = LEI.BDELeistungsartID),
           [Klienten/innen]   = COUNT(DISTINCT LEI.BaPersonID),
           [Stunden]          = ISNULL(SUM(LEI.Dauer), 0.0),
           [Anzahl]           = ISNULL(SUM(LEI.Anzahl), 0),
           [ZLE]              = dbo.fnGetLOVMLText('BDELeistungsartAuswDienstleistung', LEA.AuswDienstleistungCode, @LanguageCode),
           [Produkt]          = dbo.fnGetLOVMLText('BDELeistungsartAuswProdukt', LEA.AuswProduktCode, @LanguageCode),
           [PI-Auftrag]       = dbo.fnGetLOVMLText('BDELeistungsartAuswPIAuftrag', LEA.AuswPIAuftragCode, @LanguageCode),
           [Faktura]          = dbo.fnGetLOVMLText('BDELeistungsartAuswFaktura', LEA.AuswFakturaCode, @LanguageCode),
           [Zeitraum]         = @ZeitraumString,
           [Kein Export]      = TMP.KeinExport
    
    FROM @Temp                       TMP
      INNER JOIN dbo.BDELeistung     LEI WITH (READUNCOMMITTED) ON LEI.BDELeistungID = TMP.BDELeistungID
      INNER JOIN dbo.BDELeistungsart LEA WITH (READUNCOMMITTED) ON LEA.BDELeistungsartID = LEI.BDELeistungsartID
      LEFT  JOIN dbo.XLangText       TXT WITH (READUNCOMMITTED) ON TXT.TID = LEA.BezeichnungTID 
                                                               AND TXT.LanguageCode = @LanguageCode
    
    WHERE (@BDELAAuswDLCode IS NULL OR LEA.AuswDienstleistungCode = @BDELAAuswDLCode)
      AND (@BDELAAuswProduktCode IS NULL OR LEA.AuswProduktCode = @BDELAAuswProduktCode) 
      AND (@BDELAAuswPIAuftragCode IS NULL OR LEA.AuswPIAuftragCode = @BDELAAuswPIAuftragCode) 
      AND (@BDELAAuswFakturaCode IS NULL OR LEA.AuswFakturaCode = @BDELAAuswFakturaCode)
    
    GROUP BY TMP.HistKGSOfUserOrOrgUnit, LEI.KostenstelleOrgUnitID, LEI.HistKostenstelle, ISNULL(TXT.Text, LEA.Bezeichnung), 
             LEI.BDELeistungsartID, LEA.AuswDienstleistungCode, LEA.AuswProduktCode, 
             LEA.AuswPIAuftragCode, LEA.AuswFakturaCode, TMP.KeinExport
    
    ORDER BY [KGS], [KST], [Leistungsart], [Klienten/innen], [Stunden];
    
    -- info
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' done output for <' + @ResultTable + '>');
    
    -- done
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- output 'promonat'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'promonat')
  BEGIN
    -- init temp table (due to performance, we take temporary table instead of table-var)
    CREATE TABLE #Result
    (
      ID                     INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
      UserID                 INT NOT NULL,
      BDELeistungsartID      INT NOT NULL,
      Dauer                  MONEY,
      Monat                  INT,
      Jahr                   INT,
      BG                     INT,
      KST                    VARCHAR(150) NOT NULL,
      KGS                    VARCHAR(150) NOT NULL, 
      AuswDienstleistungCode INT,
      AuswProduktCode        INT,
      AuswPIAuftragCode      INT,
      AuswFakturaCode        INT,
      KeinExport             BIT
    );
    
    -- setup indexes
    CREATE INDEX IX_TmpResult_Dauer_Monat_Jahr_BDELeistungsartID_UserID_KGS_KST ON #Result (Dauer, Monat, Jahr, BDELeistungsartID, UserID, KGS, KST);
    CREATE INDEX IX_TmpResult_UserID_BDELeistungsartID_BG_KGS_Ausw ON #Result (UserID, BDELeistungsartID, BG, KGS, AuswDienstleistungCode, AuswProduktCode, AuswPIAuftragCode, AuswFakturaCode);
    
    -- fill temporary result table
    -- INFO: do not use DISTINCT as this would remove some important entries
    INSERT INTO #Result (UserID, BDELeistungsartID, Dauer, Monat, Jahr, BG, KST, KGS, 
                         AuswDienstleistungCode, AuswProduktCode, AuswPIAuftragCode, AuswFakturaCode, KeinExport)
      SELECT UserID                 = LEI.UserID,
             BDELeistungsartID      = LEI.BDELeistungsartID,
             Dauer                  = ISNULL(SUM(LEI.Dauer), 0.0),
             Monat                  = MONTH(LEI.Datum), 
             Jahr                   = YEAR(LEI.Datum),
             BG                     = dbo.fnBDEGetPensumPercent(LEI.UserID, @DatumBisOrGetDate),
             KST                    = ISNULL((SELECT TOP 1 KST FROM @TempHistKSTOrgUnitItemName WHERE HistKostenstelle = LEI.HistKostenstelle), ''),
             KGS                    = ISNULL((SELECT TOP 1 KGS FROM @TempHistKGSOfUserOrOrgUnit WHERE KostenstelleOrgUnitID = LEI.KostenstelleOrgUnitID), ''),
             AuswDienstleistungCode = LEA.AuswDienstleistungCode,
             AuswProduktCode        = LEA.AuswProduktCode,
             AuswPIAuftragCode      = LEA.AuswPIAuftragCode,
             AuswFakturaCode        = LEA.AuswFakturaCode,
             KeinExport             = TMP.KeinExport
      FROM @Temp                       TMP
        INNER JOIN dbo.BDELeistung     LEI WITH (READUNCOMMITTED) ON LEI.BDELeistungID = TMP.BDELeistungID
        INNER JOIN dbo.BDELeistungsart LEA WITH (READUNCOMMITTED) ON LEA.BDELeistungsartID = LEI.BDELeistungsartID
      
      WHERE (@BDELAAuswDLCode        IS NULL OR LEA.AuswDienstleistungCode = @BDELAAuswDLCode) 
        AND (@BDELAAuswProduktCode   IS NULL OR LEA.AuswProduktCode        = @BDELAAuswProduktCode) 
        AND (@BDELAAuswPIAuftragCode IS NULL OR LEA.AuswPIAuftragCode      = @BDELAAuswPIAuftragCode) 
        AND (@BDELAAuswFakturaCode   IS NULL OR LEA.AuswFakturaCode        = @BDELAAuswFakturaCode)
      
      GROUP BY LEI.UserID, LEI.HistKostenstelle, LEI.BDELeistungsartID, LEI.KostenstelleOrgUnitID, MONTH(LEI.Datum),
               YEAR(LEI.Datum), LEA.AuswDienstleistungCode, LEA.AuswProduktCode, LEA.AuswPIAuftragCode, LEA.AuswFakturaCode, TMP.KeinExport;
    
    -- info
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' done fill temporary table used for result for <' + @ResultTable + '>');
    
    -- show output data using temporary result table
    SELECT [MitarbeiterIn] = dbo.fnGetLastFirstName(RES.UserID, NULL, NULL),
           [Personal-Nr.]  = CONVERT(VARCHAR(50), dbo.fnXGetHistUserValue('MitarbeiterNr', RES.UserID, @DatumBisOrGetDate)),
           [Lohntyp]       = dbo.fnLOVMLText('BenutzerLohnTyp', 
                                             CONVERT(INT, dbo.fnXGetHistUserValue('LohntypCode', RES.UserID, @DatumBisOrGetDate)),
                                             @LanguageCode),
           [Leistungsart]  = ISNULL(TXT.Text, LEA.Bezeichnung),
           [KTR St.]       = (SELECT TOP 1 KTRStandard FROM @TempHistLAValue WHERE BDELeistungsartID = RES.BDELeistungsartID),
           --
           [Jan]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 1
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Feb]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 2
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Mrz]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 3
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Apr]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 4
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Mai]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 5
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Jun]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 6
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Jul]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 7
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Aug]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 8
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Sep]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 9
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Okt]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 10
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Nov]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 11
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           [Dez]   = (SELECT SUM(SUB.Dauer) 
                      FROM #Result SUB 
                      WHERE SUB.Monat = 12
                        AND SUB.Jahr = RES.Jahr 
                        AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                        AND SUB.UserID = RES.UserID
                        AND SUB.KGS = RES.KGS
                        AND SUB.KST = RES.KST),
           --
           [Total] = ISNULL((SELECT SUM(SUB.Dauer) 
                             FROM #Result SUB
                             WHERE SUB.Jahr = RES.Jahr 
                               AND SUB.BDELeistungsartID = RES.BDELeistungsartID 
                               AND SUB.UserID = RES.UserID
                               AND SUB.KGS = RES.KGS
                               AND SUB.KST = RES.KST), 0.0),
           [Jahr]  = RES.Jahr,
           --
           [BG]          = RES.[BG],
           [KST]         = RES.[KST],
           [KGS]         = RES.[KGS],
           [ZLE]         = dbo.fnGetLOVMLText('BDELeistungsartAuswDienstleistung', RES.AuswDienstleistungCode, @LanguageCode),
           [Produkt]     = dbo.fnGetLOVMLText('BDELeistungsartAuswProdukt', RES.AuswProduktCode, @LanguageCode),
           [PI-Auftrag]  = dbo.fnGetLOVMLText('BDELeistungsartAuswPIAuftrag', RES.AuswPIAuftragCode, @LanguageCode),
           [Faktura]     = dbo.fnGetLOVMLText('BDELeistungsartAuswFaktura', RES.AuswFakturaCode, @LanguageCode),
           [Zeitraum]    = @ZeitraumString,
           [Kein Export] = RES.KeinExport
    FROM #Result                     RES
      INNER JOIN dbo.BDELeistungsart LEA WITH (READUNCOMMITTED) ON LEA.BDELeistungsartID = RES.BDELeistungsartID
      LEFT  JOIN dbo.XLangText       TXT WITH (READUNCOMMITTED) ON TXT.TID = LEA.BezeichnungTID 
                                                               AND TXT.LanguageCode = @LanguageCode
    
    GROUP BY RES.UserID, ISNULL(TXT.Text, LEA.Bezeichnung), RES.BDELeistungsartID, RES.BG, RES.KST, RES.KGS, 
             RES.AuswDienstleistungCode, RES.AuswProduktCode, RES.AuswPIAuftragCode, RES.AuswFakturaCode, RES.Jahr, RES.KeinExport
    
    ORDER BY MitarbeiterIn, Leistungsart, Jahr, KGS;
    
    -- cleanup
    DROP TABLE #Result;
    
    -- info
    PRINT (CONVERT(VARCHAR, GETDATE(), 113) + ' done output for <' + @ResultTable + '>');
    
    -- done
    RETURN;
  END;
END;
GO


