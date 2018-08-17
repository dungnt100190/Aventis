/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Skript für MaSoKra Import

  Formel für das Excel:
    - Spalte K : =TEXT(E2;"JJJJ-MM-TT;@")
    - Spalte L : =TEXT(F2;"JJJJ-MM-TT;@")
    - Spalte M : =TEXT(G2;"JJJJ-MM-TT;@")
    - Spalte O : =CONCATENATE("UNION ALL SELECT '";A2;"','";B2;"','";C2;"',";D2;",'";K2;"','";L2;"','";M2;"','";H2;"',";I2)
      oder wenn Office-Sprache Deutsch:
      Spalte O : =VERKETTEN("UNION ALL SELECT '";A2;"','";B2;"','";C2;"',";D2;",'";K2;"','";L2;"','";M2;"','";H2;"',";I2)

=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-- Loop
DECLARE @EntriesCount INT,
        @EntriesIterator INT;

--  tmp Table ImportSource
DECLARE @Versichertennummer VARCHAR(18),
        @KontoNr VARCHAR(10),
        @Buchungstext VARCHAR(100),
        @Betrag MONEY,
        @VerwPeriodeVon DATETIME,
        @VerwPeriodeBis DATETIME,
        @FaelligAm DATETIME,
        @Debitor VARCHAR(500),
        @BaInstitutionID INT;
        
DECLARE @tmpImportSource TABLE
(
  ID INT IDENTITY(1,1) NOT NULL,
  Versichertennummer VARCHAR(18) NOT NULL,
  KontoNr VARCHAR(10) NOT NULL,
  Buchungstext VARCHAR(100),
  Betrag MONEY NOT NULL,
  VerwPeriodeVon DATETIME NOT NULL,
  VerwPeriodeBis DATETIME NOT NULL,
  FaelligAm DATETIME NOT NULL,
  Debitor VARCHAR(500),
  BaInstitutionID INT NOT NULL
)               

-- Tabelle BgPosition und Hiflvariablen
DECLARE @BgPositionID INT,
        @BgBudgetID INT,
        @BudgetJahr INT,
        @BudgetMonat INT,
        @BaPersonID INT,
        @BgKategorieCode INT,
        @VerwaltungSD BIT,
        @AnzahlBgPositionsart INT,
        @BgPositionsartID INT,
        @CreatorModifier VARCHAR(50),
        @UserID INT,
        @MigKZH2130ID INT,
        @AusfuehrungNo INT,
        @Msg VARCHAR(200);
                
        
SET @BudgetJahr = 2016;
SET @BudgetMonat = 6; 
SET @BgKategorieCode = 1;  -- Einnahme
SET @UserID = dbo.fnXGetSystemUserID();
SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);

-----
INSERT INTO @tmpImportSource
        (Versichertennummer,
         KontoNr,
         Buchungstext,
         Betrag,
         VerwPeriodeVon,
         VerwPeriodeBis,
         FaelligAm,
         Debitor,
         BaInstitutionID)
-- COPY DATA FROM EXCEL HERE
SELECT '7563229456704','140','Prämienkorrektur 2016',37,'2016-06-01','2016-06-03','2016-06-01','Helsana Versicherungen AG',557987
UNION ALL SELECT '7561949660685','140','Prämienkorrektur 2016',37,'2016-06-01','2016-06-03','2016-06-01','Helsana Versicherungen AG',557987
UNION ALL SELECT '7560347511209','140','Prämienkorrektur 2016',37,'2016-06-01','2016-06-03','2016-06-01','Helsana Versicherungen AG',557987
UNION ALL SELECT '7568228062024','140','Prämienkorrektur 2016',37,'2016-06-01','2016-06-03','2016-06-01','Helsana Versicherungen AG',557987
UNION ALL SELECT '7569445502416','140','Prämienkorrektur 2016',37,'2016-06-01','2016-06-03','2016-06-01','Helsana Versicherungen AG',557987
UNION ALL SELECT '7564878439162','140','Prämienkorrektur 2016',37,'2016-06-01','2016-06-03','2016-06-01','Helsana Versicherungen AG',557987
-- END OF COPY AREA

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-- _Mig_KZH2130 MigTabelle erstellen
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MigKZH2130]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].MigKZH2130
  ( MigKZH2130ID INT IDENTITY(1,1) NOT NULL,
    Versichertennummer VARCHAR(18) NOT NULL, 
    BgBudgetID INT,
    BgPositionID INT,
    BaPersonID INT,
    Betrag MONEY,
    BgPositionsartID INT,
    Buchungstext VARCHAR(100),
    VerwPeriodeVon DATETIME,
    VerwPeriodeBis DATETIME,
    FaelligAm DATETIME,
    BaInstitutionID INT,
    ErrorMessage VARCHAR(3000),
    AusfuehrungNo INT,
    Creator VARCHAR(50),
    Created DATETIME NOT NULL  
   CONSTRAINT [PK_MigKZH2130] PRIMARY KEY CLUSTERED 
  (
    [MigKZH2130ID] ASC
  )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  ) ON [PRIMARY] 
  PRINT 'Tabelle MigKZH2130 erstellt';
END 

SELECT @AusfuehrungNo = ISNULL(MAX(AusfuehrungNo), 0) + 1 
FROM dbo.MigKZH2130;

PRINT 'Import der Daten beginnt - AusfuehrungNo ' + CONVERT(VARCHAR(MAX), @AusfuehrungNo);

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @Versichertennummer  = TMP.Versichertennummer,
         @KontoNr             = TMP.KontoNr,
         @Buchungstext        = TMP.Buchungstext,
         @Betrag              = TMP.Betrag,
         @VerwPeriodeVon      = TMP.VerwPeriodeVon,
         @VerwPeriodeBis      = TMP.VerwPeriodeBis,
         @FaelligAm           = TMP.FaelligAm,
         @Debitor             = TMP.Debitor,
         @BaInstitutionID     = TMP.BaInstitutionID
  FROM @tmpImportSource TMP
  WHERE TMP.ID = @EntriesIterator;
  
  SET @BgBudgetID = NULL;
  SET @BaPersonID = NULL;
  SET @AnzahlBgPositionsart = NULL;
  SET @BgPositionsartID = NULL;
  SET @BgPositionID = NULL;
  SET @MigKZH2130ID = NULL;
  
  BEGIN TRY
    BEGIN TRAN
    
      PRINT (CONVERT(VARCHAR(MAX), @EntriesIterator) + ' Vers.Nr: ' + @Versichertennummer);
      --BaPerson
      IF ((SELECT COUNT(BaPersonID)
           FROM dbo.BaPerson PRS
           WHERE REPLACE(PRS.Versichertennummer, '.', '') = REPLACE(@Versichertennummer, '.', '')) > 1)
      BEGIN
        RAISERROR('Es gibt mehrere Personen mit dieser Versichertennummer.',18,1);
      END;
    
      SELECT TOP 1 @BaPersonID = PRS.BaPersonID
      FROM dbo.BaPerson PRS
      WHERE REPLACE(PRS.Versichertennummer, '.', '') = REPLACE(@Versichertennummer, '.', '');   
    
      IF (@BaPersonID IS NULL)
      BEGIN
        RAISERROR('Mit dieser Versichertennummer kann keine Person gefunden werden.',18,1);
      END     
    
      -- Budget selektieren
      SELECT TOP 1 @BgBudgetID = BDG.BgBudgetID
      FROM dbo.BgBudget                      BDG
        INNER JOIN dbo.BgFinanzplan          FPL ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
        INNER JOIN dbo.BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
        INNER JOIN dbo.FaLeistung            LEI ON LEI.FaLeistungID = FPL.FaLeistungID
      WHERE BDG.BgBewilligungStatusCode = 5 -- = nur Grün Budget
        AND BDG.MasterBudget = 0 -- einmalig dann nicht im Masterbudget=1
        AND FPP.BaPersonID = @BaPersonID
        AND FPP.IstUnterstuetzt = 1
        AND (LEI.DatumBis IS NULL OR LEI.DatumBis >= dbo.fnDateSerial(@BudgetJahr, @BudgetMonat, 1))
        AND BDG.Jahr >= @BudgetJahr
      ORDER BY (CASE WHEN Jahr = @BudgetJahr AND Monat = @BudgetMonat THEN 1 ELSE 0 END) DESC, -- 1) Juni-Budet 
        CASE WHEN (Jahr = @BudgetJahr AND Monat < @BudgetMonat) OR (Jahr < @BudgetJahr) THEN -Jahr ELSE Jahr END, -- 2) früher als Juni
        CASE WHEN (Jahr = @BudgetJahr AND Monat < @BudgetMonat) OR (Jahr < @BudgetJahr) THEN -Monat ELSE Monat END -- 3) später als Juni

      IF (@BgBudgetID IS NULL)
      BEGIN
        RAISERROR('Für diese Person konnte kein passendes Budget gefunden werden.',18,1);
      END       
     
      IF NOT EXISTS (SELECT TOP 1 1
                     FROM dbo.BaInstitution INS 
                     WHERE Name = @Debitor 
                       AND BaInstitutionID = @BaInstitutionID)
      BEGIN
        SET @Msg = 'Die Institution "' + @Debitor + '" mit ID ' + CONVERT(VARCHAR(MAX), @BaInstitutionID) + ' konnte nicht gefunden werden. Bitte BaInstitutionName und BaInstitutionID prüfen.'
        RAISERROR(@Msg, 18, 1)
      END 
    
      -- BgPositionsart
      SELECT @AnzahlBgPositionsart = COUNT(1) 
      FROM dbo.BgPositionsart POA
        INNER JOIN dbo.BgKostenart KOA ON KOA.BgKostenartID = POA.BgKostenartID
      WHERE KontoNr = @KontoNr
        AND BgKategorieCode = @BgKategorieCode;
       
      IF (@AnzahlBgPositionsart > 1)
      BEGIN
        RAISERROR('Es wurden mehrere Positionsarten wurden für diese LA gefunden.',18,1);
      END    
      IF (@AnzahlBgPositionsart = 0)
      BEGIN
        RAISERROR('Es wurde keine Positionsart für diese LA gefunden.',18,1);
      END       
            
      SELECT TOP 1 @BgPositionsartID = POA.BgPositionsartID
      FROM dbo.BgPositionsart POA
        INNER JOIN dbo.BgKostenart KOA ON KOA.BgKostenartID = POA.BgKostenartID
      WHERE KontoNr = @KontoNr
        AND BgKategorieCode = @BgKategorieCode;  
            
       
      SELECT TOP 1 @BgPositionID = POS.BgPositionID
      FROM dbo.BgPosition POS
      WHERE BgBudgetID = @BgBudgetID
        AND BaPersonID = @BaPersonID
        AND BaInstitutionID = @BaInstitutionID
        AND BgPositionsartID = @BgPositionsartID
        AND BgKategorieCode = @BgKategorieCode   
      
      IF @BgPositionID IS NOT NULL
      BEGIN
       RAISERROR('Es existiert bereits eine identische Position. Es wurde keine weitere Position in diesem Budget erstellt.',18,1)
      END

      INSERT INTO BgPosition ( [BgBudgetID], [BaPersonID] ,[BaInstitutionID] ,[BgPositionsartID],[BgKategorieCode],
                               [Buchungstext], [Betrag], [Reduktion], [Abzug], [MaxBeitragSD],
                               [Bemerkung], [VerwPeriodeVon], [VerwPeriodeBis], [FaelligAm],       
                               [VerwaltungSD], [ErstelltDatum] ,[MutiertDatum] )
        OUTPUT      @Versichertennummer,
                    INSERTED.BgBudgetID,
                    INSERTED.BgPositionID,
                    INSERTED.BaPersonID,
                    INSERTED.Betrag,
                    INSERTED.BgPositionsartID,
                    INSERTED.Buchungstext,
                    INSERTED.VerwPeriodeVon,
                    INSERTED.VerwPeriodeBis,
                    INSERTED.FaelligAm,
                    INSERTED.BaInstitutionID,
                    NULL,
                    @AusfuehrungNo,
                    @CreatorModifier,
                    GETDATE()
          INTO dbo.MigKZH2130 (Versichertennummer, BgBudgetID, BgPositionID, BaPersonID, Betrag, BgPositionsartID, Buchungstext, VerwPeriodeVon, VerwPeriodeBis, FaelligAm, 
                               BaInstitutionID, ErrorMessage, AusfuehrungNo, Creator, Created)
        SELECT   @BgBudgetID, 
                 @BaPersonID, 
                 @BaInstitutionID, 
                 @BgPositionsartID, 
                 @BgKategorieCode,
                 @Buchungstext,
                 @Betrag,
                 0, -- Reduktion
                 0, -- Abzug
                 999999999.00, -- MaxBeitragSD
                 'Position automatisch erstellt (Import gemäss KZH-2130)', -- Bemerkung
                 @VerwPeriodeVon,
                 @VerwPeriodeBis,
                 @FaelligAm,
                 1, -- VerwaltungSD
                 GETDATE(), -- ErstelltDatum
                 GETDATE(); -- Mutierdatum

       SET @MigKZH2130ID = SCOPE_IDENTITY();
      
       SELECT @BgPositionID = BgPositionID
       FROM dbo.MigKZH2130
       WHERE MigKZH2130ID = @MigKZH2130ID;              
          
       IF @UserID IS NULL
       BEGIN
         RAISERROR('Der Benutzer konnte nicht gefunden werden, die Position kann dann nicht grün gestellt werden.',18,1);
       END      
       ELSE
       BEGIN
         -- grün stellen         
         EXEC spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0, null, @BgPositionID
       END
        
      COMMIT      

  END TRY
  BEGIN CATCH  
  
    ROLLBACK   
   
    
    DECLARE @errormsg varchar(500)
    SET @errormsg = ERROR_MESSAGE();   
    PRINT ('  Fehler: ' + @errormsg);  
    
    INSERT INTO dbo.MigKZH2130
            (Versichertennummer,
             BgBudgetID,
             BgPositionID,
             BaPersonID,
             Betrag,
             BgPositionsartID,
             Buchungstext,
             VerwPeriodeVon,
             VerwPeriodeBis,
             FaelligAm,
             BaInstitutionID,
             ErrorMessage,
             AusfuehrungNo,
             Creator,
             Created)
    VALUES  (@Versichertennummer, --Versichertennummer - varchar(18)
             @BgBudgetID, -- BgBudgetID - int
             @BgPositionID, -- BgPositionID - int
             @BaPersonID, -- BaPersonID - int
             @Betrag, -- Betrag - money
             @BgPositionsartID, -- BgPositionsartID - int
             @Buchungstext, -- Buchungstext - varchar(100)
             @VerwPeriodeVon, -- VerwPeriodeVon - datetime
             @VerwPeriodeBis, -- VerwPeriodeBis - datetime
             @FaelligAm, -- FaelligAm - datetime
             @BaInstitutionID, -- BaInstitutionID - int
             @errormsg, -- ErrorMessage - varchar(3000)
             @AusfuehrungNo,
             @CreatorModifier, -- Creator - varchar(50)
             GETDATE())  -- Created - datetime

  
  END CATCH  

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

PRINT '*****************************************************************************************'
PRINT '   Import komplett. Das Protokoll des Imports befindet sich in der Tabelle: MigKZH2130'
PRINT '*****************************************************************************************'

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO


