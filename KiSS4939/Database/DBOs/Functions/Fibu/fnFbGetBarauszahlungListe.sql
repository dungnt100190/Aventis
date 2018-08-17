SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFbGetBarauszahlungListe;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Kreiert die Liste der Barauszahlungen für die Maske VM-Kasse.
    @SucheDatumVon: Begin Suchzeitraum
    @SucheDatumBis: Ende Suchzeitraum
    @SucheVerbucht: Suche nach verbuchten Auszahlungen
    @SucheNichtVerbucht: Suche nach nicht verbuchten Auszahlungen
    @SucheBaPersonID: Suche nach Auszahlungen dieser Person
  -
  RETURNS: Tabelle mit allen nötigen Informationen um eine Barauszahlung durchführen zu können.
  -
  TEST:    SELECT * FROM dbo.fnFbGetBarauszahlungListe(GETDATE(), GETDATE(), 0, 1, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnFbGetBarauszahlungListe
(
  @SucheDatumVon datetime,
  @SucheDatumBis datetime,
  @SucheVerbucht bit = 0,
  @SucheNichtVerbucht bit = 1,
  @SucheBaPersonID int
)
RETURNS @Result TABLE
(
  FbBarauszahlungAuftragID int,
  FbBarauszahlungZyklusID int,
  FbPeriodeID int,
  FbBuchungID int,
  FaLeistungID int,
  BaPersonID int,
  Mandant varchar(255),
  MandantVornameName varchar(255),
  PersStrasse varchar(50),
  PersPLZ varchar(8),
  PersOrt varchar(50),
  PersGeburtsdatum datetime,
  PersAHVNummer varchar(25),
  PersVersNummer varchar(25),
  BelegNr varchar(25),
  Stichtag datetime,
  AuszahlungAb datetime,
  AuszahlungBis datetime,
  BewilligtDurch varchar(500),
  Betrag money,
  Auszahldatum datetime,
  StatusCode int,
  SollKtoNr varchar(25),
  SollKtoName varchar(50),
  HabenKtoNr varchar(25),
  HabenKtoName varchar(50),
  Buchungstext varchar(255),
  Mandatstraeger varchar(500),
  AuszahlungDurch varchar(50),
  FbBarauszahlungAuftragTS binary(8),
  FbBarauszahlungZyklusTS binary(8)
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- Checks
  -------------------------------------------------------------------------------
  IF @SucheDatumVon IS NULL SET @SucheDatumVon = CONVERT(datetime, CONVERT(varchar, GETDATE(), 104), 104);
  IF @SucheDatumBis IS NULL SET @SucheDatumBis = CONVERT(datetime, CONVERT(varchar, GETDATE(), 104), 104);
  IF @SucheVerbucht IS NULL SET @SucheVerbucht = 0;
  IF @SucheNichtVerbucht IS NULL SET @SucheNichtVerbucht = 1;

  -------------------------------------------------------------------------------
  -- Declarations
  -------------------------------------------------------------------------------
  DECLARE @AuftragID int, @ZyklusID int, @BaPersonID int, @FaLeistungID int,
    @Mandant varchar(255), @MandantVornameName varchar(255), @StrasseHausNr varchar(50),  @PLZ varchar(8),  @Ort varchar(50),
    @Geburtsdatum datetime,  @AHVNummer varchar(50),  @VersNummer varchar(50),  
    @SollKtoNr int, @HabenKtoNr int, @Betrag money, 
    @Buchungstext varchar(255), @Vorbezug int, @Nachbezug int, @AuftragDatumVon datetime, @AuftragDatumBis datetime, 
    @Mandatstraeger varchar(500), @BewilligtDurch varchar(500), @DatumStart datetime, @DauerNaechsteZahlung int, @DauerTyp int,
    @AuftragTS binary(8), @ZyklusTS binary(8);

  DECLARE @CurrentDatum datetime, @AuszahlungAb datetime, @AuszahlungBis datetime, @BelegNr varchar(25), 
    @Auszahldatum datetime, @AuszahlungDurch varchar(50), @StatusCode int, @Today datetime, @PeriodeID int,
    @FbBuchungID int, @SollKtoName varchar(50), @HabenKtoName varchar(50);

  SET @Today = dbo.fnDateOf(GETDATE());

  DECLARE @EntriesCount INT;
  DECLARE @EntriesIterator INT;

  DECLARE @TempTable TABLE
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    FbBarauszahlungAuftragID INT,
    FbBarauszahlungZyklusID INT,
    BaPersonID INT,
    FaLeistungID INT,
    Mandant VARCHAR(255),
    MandantVornameName VARCHAR(255),
    WohnsitzStrasseHausNr VARCHAR(50),
    WohnsitzPLZ VARCHAR(8),
    WohnsitzOrt VARCHAR(50),
    Geburtsdatum DATETIME,
    AHVNummer VARCHAR(25),
    Versichertennummer VARCHAR(25),
    SollKtoNr VARCHAR(25),
    HabenKtoNr VARCHAR(25),
    Betrag MONEY,
    Buchungstext VARCHAR(255),
    Vorbezug INT,
    Nachbezug INT,
    DatumVon DATETIME,
    DatumBis DATETIME,
    Mandatstraeger VARCHAR(500),
    BewilligtDurch VARCHAR(500),
    DatumStart DATETIME,
    DauerNaechsteZahlung INT,
    DauerTypCode INT,
    FbBarauszahlungAuftragTS BINARY(8),
    FbBarauszahlungZyklusTS BINARY(8)
  );

  
  -------------------------------------------------------------------------------
  -- insert entries into temp table
  -------------------------------------------------------------------------------
  INSERT INTO @TempTable
    SELECT 
      BAA.FbBarauszahlungAuftragID,
      BAZ.FbBarauszahlungZyklusID,
      LEI.BaPersonID,
      BAA.FaLeistungID,
      Mandant = PRS.NameVorname,
      MandantVornameName = PRS.VornameName,
      PRS.WohnsitzStrasseHausNr,
      PRS.WohnsitzPLZ,
      PRS.WohnsitzOrt,
      PRS.Geburtsdatum,
      PRS.AHVNummer,
      PRS.Versichertennummer,
      BAA.SollKtoNr,
      BAA.HabenKtoNr,
      BAA.Betrag,
      BAA.Buchungstext,
      BAA.Vorbezug,
      BAA.Nachbezug,
      BAA.DatumVon,
      BAA.DatumBis,
      Mandatstraeger = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
      BewilligtDurch = dbo.fnGetLastFirstName(BAA.UserID_Modifier, NULL, NULL),
      BAZ.DatumStart,
      BAZ.DauerNaechsteZahlung,
      BAZ.DauerTypCode,
      BAA.FbBarauszahlungAuftragTS,
      BAZ.FbBarauszahlungZyklusTS
    FROM dbo.FbBarauszahlungAuftrag         BAA WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung             LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BAA.FaLeistungID
      INNER JOIN dbo.FbBarauszahlungZyklus  BAZ WITH (READUNCOMMITTED) ON BAZ.FbBarauszahlungAuftragID = BAA.FbBarauszahlungAuftragID
      INNER JOIN dbo.vwPerson               PRS                        ON PRS.BaPersonID = LEI.BaPersonID
    WHERE (dbo.fnDateOf(BAA.DatumVon) <= @SucheDatumBis OR dbo.fnDateOf(BAA.DatumBis) >= @SucheDatumVon)
      AND (@SucheBaPersonID IS NULL OR LEI.BaPersonID = @SucheBaPersonID);

  -- prepare vars for loop
  SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
  SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

  -------------------------------------------------------------------------------
  -- loop all entries
  -------------------------------------------------------------------------------
  WHILE (@EntriesIterator <= @EntriesCount)
  BEGIN
    -- get current entry
    SELECT  @AuftragID = FbBarauszahlungAuftragID,
            @ZyklusID = FbBarauszahlungZyklusID,
            @BaPersonID = BaPersonID,
            @FaLeistungID = FaLeistungID,
            @Mandant = Mandant,
            @MandantVornameName = MandantVornameName,
            @StrasseHausNr = WohnsitzStrasseHausNr,
            @PLZ = WohnsitzPLZ,
            @Ort = WohnsitzOrt,
            @Geburtsdatum = Geburtsdatum,
            @AHVNummer = AHVNummer,
            @VersNummer = Versichertennummer,
            @SollKtoNr = SollKtoNr,
            @HabenKtoNr = HabenKtoNr,
            @Betrag = Betrag,
            @Buchungstext = Buchungstext,
            @Vorbezug = Vorbezug,
            @Nachbezug = Nachbezug,
            @AuftragDatumVon = DatumVon,
            @AuftragDatumBis = DatumBis,
            @Mandatstraeger = Mandatstraeger,
            @BewilligtDurch = BewilligtDurch,
            @DatumStart = DatumStart,
            @DauerNaechsteZahlung = DauerNaechsteZahlung,
            @DauerTyp = DauerTypCode,
            @AuftragTS = FbBarauszahlungAuftragTS,
            @ZyklusTS = FbBarauszahlungZyklusTS
    FROM @TempTable TMP
    WHERE TMP.ID = @EntriesIterator;
    
    -----------------------------------------------------------------------------
    -- do something
    -----------------------------------------------------------------------------
    SET @CurrentDatum = NULL;

    WHILE 1=1
    BEGIN
    
      SET @PeriodeID = NULL;
      SET @FbBuchungID = NULL;
      SET @BelegNr = NULL;
      SET @Auszahldatum = NULL;
      SET @AuszahlungDurch = NULL;
      SET @SollKtoName = NULL;
      SET @HabenKtoName = NULL;
      
      IF @CurrentDatum IS NULL
      BEGIN
        SET @CurrentDatum = dbo.fnDateOf(@DatumStart);
      END
      ELSE
      BEGIN
        IF @DauerNaechsteZahlung = 0
        BEGIN
          BREAK;
        END;
        SET @CurrentDatum = CASE @DauerTyp
                              WHEN 1 THEN DATEADD(day, @DauerNaechsteZahlung, @CurrentDatum)
                              WHEN 2 THEN DATEADD(month, @DauerNaechsteZahlung, @CurrentDatum)
                              ELSE NULL
                            END;
      END;

      -- When new occurance not within date range then break 
      SET @AuszahlungBis = DATEADD(day, @Nachbezug, @CurrentDatum);
      SET @AuszahlungAb = DATEADD(day, -@Vorbezug, @CurrentDatum);
            
      IF @AuszahlungAb < @AuftragDatumVon
      BEGIN
        SET @AuszahlungAb = @AuftragDatumVon;
      END;
      
      IF @AuftragDatumBis IS NOT NULL AND @AuszahlungBis > @AuftragDatumBis
      BEGIN
        SET @AuszahlungBis = @AuftragDatumBis;
      END;
                  
      IF (@AuszahlungBis <  @SucheDatumVon AND @AuszahlungAb <= @AuszahlungBis) OR @CurrentDatum < @AuftragDatumVon
      BEGIN
        CONTINUE;
      END;

      IF @AuszahlungAb >  @SucheDatumBis OR @AuszahlungAb > @AuftragDatumBis OR @CurrentDatum > @AuftragDatumBis
      BEGIN
        BREAK;
      END;
      
      
      -- Check if occurance not already paid
      SELECT 
        @FbBuchungID = FBB.FbBuchungID,
        @BelegNr = FBB.BelegNr,
        @Auszahldatum = BAB.Datum,
        @AuszahlungDurch = dbo.fnGetLastFirstName(FBB.UserID, NULL, NULL),
        @Betrag = ISNULL(FBB.Betrag, @Betrag),
        @Buchungstext = ISNULL(FBB.Text, @Buchungstext),
        @SollKtoNr = ISNULL(FBB.SollKtoNr, @SollKtoNr)
      FROM dbo.FbBarauszahlungAusbezahlt  BAB WITH (READUNCOMMITTED)
        INNER JOIN dbo.FbBuchung          FBB WITH (READUNCOMMITTED) ON FBB.FbBuchungID = BAB.FbBuchungID
      WHERE BAB.FbBarauszahlungZyklusID = @ZyklusID
        AND BAB.Stichtag = @CurrentDatum;
      
      -- Set Status
      SET @StatusCode = 3; -- Freigegeben
      
      IF @Auszahldatum IS NOT NULL AND @BelegNr IS NOT NULL
      BEGIN
        IF @SucheVerbucht = 0
        BEGIN
          CONTINUE;
        END;
        SET @StatusCode = 4; -- Ausbezahlt
      END
      ELSE
      BEGIN
        IF @SucheNichtVerbucht = 0 
        BEGIN
          CONTINUE;
        END;
        IF @AuszahlungBis < @Today
        BEGIN
          SET @StatusCode = 5 -- Verfallen
        END
        ELSE IF @AuszahlungAb > @Today
        BEGIN
          SET @StatusCode = 2 -- Noch nicht fällig
        END;
      END;
        
      SELECT 
        @PeriodeID = FPR.FbPeriodeID,
        @SollKtoName = FKTS.KontoName,
        @HabenKtoName = FKTH.KontoName
      FROM dbo.FbPeriode      FPR  WITH (READUNCOMMITTED)
        LEFT JOIN dbo.FbKonto FKTS WITH (READUNCOMMITTED) ON FKTS.FbPeriodeID = FPR.FbPeriodeID AND FKTS.KontoNr = @SollKtoNr
        LEFT JOIN dbo.FbKonto FKTH WITH (READUNCOMMITTED) ON FKTH.FbPeriodeID = FPR.FbPeriodeID AND FKTH.KontoNr = @HabenKtoNr
      WHERE FPR.PeriodeStatusCode = 1 -- aktiv
        AND FPR.BaPersonID = @BaPersonID
        AND (@AuszahlungBis BETWEEN FPR.PeriodeVon AND FPR.PeriodeBis OR @AuszahlungAb BETWEEN FPR.PeriodeVon AND FPR.PeriodeBis)
        AND (@Today BETWEEN FPR.PeriodeVon AND FPR.PeriodeBis OR @StatusCode <> 3); -- sicherstellen, dass wenn mehrere Perioden existieren, diejenige von heute verwendet wird.
        
      IF @StatusCode = 3
      BEGIN
        IF @PeriodeID IS NULL 
        BEGIN
          SET @StatusCode = 1; -- Keine Periode Vorhanden
        END
        ELSE IF @HabenKtoName IS NULL
        BEGIN
          SET @StatusCode = 6; -- Konto nicht vorhanden
        END;
      END;
      
      -- Make entry in temp table
      INSERT INTO @Result(FbBarauszahlungAuftragID, FbBarauszahlungZyklusID, FbPeriodeID, FbBuchungID, FaLeistungID, BaPersonID,
                          BelegNr, Mandant, MandantVornameName, SollKtoNr, HabenKtoNr, Betrag, Buchungstext, Mandatstraeger, BewilligtDurch, 
                          Stichtag, AuszahlungAb, AuszahlungBis, Auszahldatum,  StatusCode, AuszahlungDurch, SollKtoName, HabenKtoName, 
                          PersStrasse, PersPLZ, PersOrt, PersGeburtsdatum, PersAHVNummer, PersVersNummer, 
                          FbBarauszahlungAuftragTS, FbBarauszahlungZyklusTS)
        VALUES (@AuftragID, @ZyklusID, @PeriodeID, @FbBuchungID, @FaLeistungID, @BaPersonID,
                @BelegNr, @Mandant, @MandantVornameName, @SollKtoNr, @HabenKtoNr, @Betrag, @Buchungstext, @Mandatstraeger, @BewilligtDurch, 
                @CurrentDatum, @AuszahlungAb, @AuszahlungBis, @Auszahldatum, @StatusCode, @AuszahlungDurch, @SollKtoName, @HabenKtoName,
                @StrasseHausNr, @PLZ, @Ort, @Geburtsdatum, @AHVNummer, @VersNummer,
                @AuftragTS, @ZyklusTS);
    END;
    -----------------------------------------------------------------------------
  
    -- prepare for next entry
    SET @EntriesIterator = @EntriesIterator + 1;
  END;
  
  RETURN;
END;
GO
