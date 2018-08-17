SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbAbrechnungASVS;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Stored Procedure für die Abfragen im Bereich Abrechung ASV.
            Das berücksichtige Konto ist im Konfigurationswert 
            "System\KliBu\AbfrageAbrechnungASVSKontoNr" enthalten.

    @KbPeriodeId:  Die ID der KbPeriode
    @DatumVon:     Datum von
    @DatumBis:     Datum Bis
    @Abfrage:      1. Abfrage Abrechung ASV
                   2. Abfrage Abrechung ASV Flüchtling
    @LanguageCode: Sprachcode (1 für DE).
    @OrgUnitID:    ID der Abteilung die gefiltert werden muss. Ist ein Suchfeld auf der Maske Abrechung ASV Flüchtling
  -
  RETURNS: Je nach Parameter @Abfrage werden andere Spalten zurückgegeben.
  Bei Wert 1 (Abfrage Abrechung ASV)
    Nachname:
    Vorname:
    AHV_Nummer:
    Versichertennummer:
    Krankenkasse: Feld Beguenstingt von der Buchung
    Periode Von:
    Periode Bis:
    Betrag KVG:
    BelegNr:
    BaPersonId$:

  Bei Wert 2 (Abfrage Abrechung ASV Flüchtling)
    [AHV-Nummer]: Die AHV Nummer  
    Geburtsdatum:      
    Nachname:         
    Vorname:       
    Strasse: Strasse voN der aktuellen Wohnistzadresse (siehe vwPerson)
    PLZ:  PLZ voN der aktuellen Wohnistzadresse (siehe vwPerson)	    
    Ort:   Strasse vom der aktuellen Wohnistzadresse (siehe vwPerson)      
    Aufenthaltsbewilligung: Aufenthaltsstatus
    Krankenkasse: Feld Beguenstingt von der Buchung    
    UnterstuetztVon:  DatumVon WhASVSeintrag von der Person in der Leistung der Position von der Buchung.
    UnterstuetztBis:   DatumVon WhASVSeintrag von der Person in der Leistung der Position von der Buchung.   
    Anzahlmonate: Maximum VerwendugnsperiodeVon der Kostenart minus Minimum VerwendungsperiodeBis der Kostenart + ein Monat.
                  Lücken werden nicht berücksichtigt.      
    BaPersonID$  Id der Person.  

=================================================================================================
  TEST:   
    DECLARE @DatumVon DATETIME, 
            @DatumBis DATETIME,
            @KbPeriodeId INT,
            @Abfrage INT;

    SET @DatumVon = '20100101';
    SET @DatumBis = '20111231';
    SET @KbPeriodeId = 5;
    SET @Abfrage = 2;

    EXEC spKbAbrechnungASVS @KbPeriodeId, @DatumVon, @DatumBis, @Abfrage, 1, NULL;
=================================================================================================*/

CREATE PROCEDURE dbo.spKbAbrechnungASVS
(
  @KbPeriodeId INT,
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @Abfrage INT,
  @LanguageCode INT,
  @OrgUnitID INT
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  DECLARE @KontoNr VARCHAR(100);

  -- Konfigurationswert lesen
  SELECT @KontoNr = CONVERT(VARCHAR(100), dbo.fnXConfig('System\KliBu\AbfrageAbrechnungASVSKontoNr', GETDATE()));

  DECLARE @Result TABLE 
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    Nachname VARCHAR(100),
    Vorname  VARCHAR(100),
    Geburtsdatum DATETIME,
    AHVNummer VARCHAR(16),
    Versichertennummer VARCHAR(18),
    WohnsitzStrasseHausNr VARCHAR(111),
    WohnsitzPLZ VARCHAR(10),      
    WohnsitzOrt VARCHAR(50),  
    Aufenthaltsbewilligung VARCHAR(MAX), 
    Krankenkasse VARCHAR(35), 
    PeriodeVon DATETIME,
    PeriodeBis DATETIME,
    AnzahlMonate INT,
    BetragKVG MONEY,
    BelegNr INT,
    UnterstuetztVon DATETIME,
    UnterstuetztBis DATETIME,
    BaPersonID INT
  );
  
  INSERT INTO @Result 
    SELECT 
      Nachname               = PRS.Name,
      Vorname                = PRS.Vorname,
      Geburtsdatum           = Geburtsdatum,
      AHVNummer              = PRS.AHVNummer,
      Versichertennummer     = PRS.Versichertennummer,
      WohnsitzStrasseHausNr  = PRS.WohnsitzStrasseHausNr,
      WohnsitzPLZ            = PRS.WohnsitzPLZ, 
      WohnsitzOrt            = PRS.WohnsitzOrt,
      Aufenthaltsbewilligung = dbo.fnGetLOVMLText('Aufenthaltsstatus', PRS.AuslaenderStatusCode, @LanguageCode),
      Krankenkasse           = BUC.BeguenstigtName, 
      PeriodeVon             = KOA.VerwPeriodeVon,
      PeriodeBis             = KOA.VerwPeriodeBis,
      AnzahlMonate           = 0,
      BetragKVG              = CASE 
                                 WHEN BUC.SollKtoNr IS NULL 
                                 THEN KOA.Betrag 
                                 ELSE -KOA.Betrag 
                               END,
      BelegNr                = BUC.BelegNr,
      UnterstuetztVon        = ASE.DatumVon,
      UnterstuetztBis        = ASE.DatumBis,
      BaPersonID             = PRS.BaPersonID
    FROM dbo.fnKbGetRelevanteBuchungen(@KbPeriodeId, @DatumVon, @DatumBis, 0, 0) REB
      INNER JOIN dbo.KbBuchung               BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = REB.KbBuchungID
      INNER JOIN dbo.KbBuchungKostenart      KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungKostenartID = REB.KbBuchungKostenartID 
      LEFT  JOIN dbo.BgPosition              POS WITH (READUNCOMMITTED) ON POS.BgPositionID = KOA.BgPositionID
      INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.KbKostenstelleID = KOA.KbKostenstelleID
                                                                       AND (KST.DatumBis IS NULL 
                                                                         OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)
      INNER JOIN dbo.vwPerson                PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KST.BaPersonID
      INNER JOIN dbo.BgKostenart             BGK WITH (READUNCOMMITTED) ON BGK.BgKostenartID = KOA.BgKostenartID
      LEFT  JOIN dbo.BgBudget                BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
      LEFT  JOIN dbo.BgFinanzplan            FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
      LEFT  JOIN dbo.WhASVSEintrag           ASE WITH (READUNCOMMITTED) ON ASE.WhASVSEintragID = (SELECT TOP 1 ASE1.WhASVSEintragID 
                                                                                                  FROM dbo.WhASVSEintrag ASE1 WITH (READUNCOMMITTED)
                                                                                                  WHERE ASE1.BaPersonID = PRS.BaPersonID
                                                                                                    AND ASE1.FaLeistungID = FPL.FaLeistungID
                                                                                                  ORDER BY ASE1.DatumVon DESC)                                                              
      LEFT  JOIN dbo.FaLeistung              LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
      LEFT  JOIN dbo.XOrgUnit_User           OUU WITH (READUNCOMMITTED) ON OUU.UserID = LEI.UserID
                                                                       AND OUU.OrgUnitMemberCode = 2
    WHERE BGK.KontoNr = @KontoNr
      AND (@OrgUnitID IS NULL OR OUU.OrgUnitID = @OrgUnitID)
      AND BUC.KbBuchungStatusCode IN (3,5,6,10,13); /* 3 ZahlauftragErstellt
              
			                                           5 ZahlauftragFehlerhaft
                                                       6 ausgeglichen
                                                       10 teilweise ausgeglichen
                                                       13 verbucht */

  IF (@Abfrage = 1)
  BEGIN
    SELECT
      Nachname           = Nachname,
      Vorname            = Vorname,
      [AHV-Nummer]       = AHVNummer,
      Versichertennummer = Versichertennummer,
      Krankenkasse       = Krankenkasse, 
      [Periode von]      = PeriodeVon,
      [Periode bis]      = PeriodeBis,
      [Betrag KVG]       = BetragKVG,
      BelegNr            = BelegNr,
      BaPersonID$        = BaPersonID   
    FROM @Result
    ORDER BY Nachname, Vorname, AHVNummer, Versichertennummer, PeriodeVon;--NameVorname, PRS.AHVNummer, PRS.Versichertennummer, KOA.VerwPeriodeVon;
    
    RETURN;
  END;

  IF (@Abfrage = 2)
  BEGIN
    DECLARE @AnzahlMonate TABLE(
      ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
      BaPersonID INT,
      Krankenkasse VARCHAR(35),
      JahrMonat DATETIME,
      UnterstuetztVon DATETIME,
      UnterstuetztBis DATETIME
    );

    -------------------------------------------------------------------------------
    -- init vars and table
    -------------------------------------------------------------------------------
    DECLARE @EntriesCount INT;
    DECLARE @EntriesIterator INT;
    DECLARE @BaPersonID INT;
    DECLARE @Krankenkasse VARCHAR(35);
    DECLARE @PeriodeVon DATETIME;
    DECLARE @PeriodeBis DATETIME;
    DECLARE @UnterstuetztVon DATETIME;
    DECLARE @UnterstuetztBis DATETIME;
    DECLARE @JahrMonat DATETIME;

    -- prepare vars for loop
    SELECT @EntriesCount = COUNT(1) FROM @Result;
    SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

    -------------------------------------------------------------------------------
    -- loop all entries
    -------------------------------------------------------------------------------
    WHILE (@EntriesIterator <= @EntriesCount)
    BEGIN
      -- get current entry
      SELECT @BaPersonID      = TMP.BaPersonID,
             @Krankenkasse    = TMP.Krankenkasse,
             @PeriodeVon      = TMP.PeriodeVon,
             @PeriodeBis      = TMP.PeriodeBis,
             @UnterstuetztVon = TMP.UnterstuetztVon,
             @UnterstuetztBis = TMP.UnterstuetztBis
      FROM @Result TMP
      WHERE TMP.ID = @EntriesIterator;
      
      -----------------------------------------------------------------------------
      -- do something
      -----------------------------------------------------------------------------
      WHILE (@PeriodeVon < @PeriodeBis)
      BEGIN
        SELECT @JahrMonat = dbo.fnFirstDayOf(@PeriodeVon);
        IF NOT EXISTS(SELECT TOP 1 1
                      FROM @AnzahlMonate
                      WHERE BaPersonID = @BaPersonID
                        AND ISNULL(Krankenkasse, '') = ISNULL(@Krankenkasse, '')
                        AND JahrMonat = @JahrMonat
                        AND ISNULL(UnterstuetztVon, '17530101') = ISNULL(@UnterstuetztVon, '17530101')
                        AND ISNULL(UnterstuetztBis, '99991231') = ISNULL(@UnterstuetztBis, '99991231'))
        BEGIN
          INSERT INTO @AnzahlMonate(BaPersonID, Krankenkasse, JahrMonat, UnterstuetztVon, UnterstuetztBis)
          VALUES(@BaPersonID, @Krankenkasse, @JahrMonat, @UnterstuetztVon, @UnterstuetztBis);
          
          UPDATE @Result
          SET AnzahlMonate = Anzahlmonate + 1
          WHERE ID = @EntriesIterator;
        END;
        
        SET @PeriodeVon = DATEADD(MONTH, 1, @PeriodeVon);
      END;
      
      -- prepare for next entry
      SET @EntriesIterator = @EntriesIterator + 1;
    END;
    
    -----------------------------------------------------------------------------
    -- OUTPUT
    -----------------------------------------------------------------------------
    SELECT
      Versichertennummer     = Versichertennummer,
      Geburtsdatum           = Geburtsdatum,
      Nachname               = Nachname,
      Vorname                = Vorname,
      Strasse                = WohnsitzStrasseHausNr,
      PLZ	                   = WohnsitzPLZ,
      Ort                    = WohnsitzOrt,
      Aufenthaltsbewilligung = Aufenthaltsbewilligung,
      Krankenkasse           = Krankenkasse, 
      UnterstuetztVon        = UnterstuetztVon,
      UnterstuetztBis        = UnterstuetztBis,
      Anzahlmonate           = (SELECT COUNT(DISTINCT JahrMonat)
                                FROM @AnzahlMonate
                                WHERE BaPersonID = RES.BaPersonID
                                  AND ISNULL(Krankenkasse, '') = ISNULL(RES.Krankenkasse, '')
                                  AND ISNULL(UnterstuetztVon, '17530101') = ISNULL(RES.UnterstuetztVon, '17530101')
                                  AND ISNULL(UnterstuetztBis, '99991231') = ISNULL(RES.UnterstuetztBis, '99991231')),
      [Betrag KVG]           = SUM(BetragKVG),
      BaPersonID$            = BaPersonID   
    FROM @Result RES
    GROUP BY Versichertennummer,
             Geburtsdatum, 
             Krankenkasse, 
             Nachname, 
             Vorname, 
             WohnsitzStrasseHausNr,
             WohnsitzPLZ, 
             WohnsitzOrt, 
             Aufenthaltsbewilligung, 
             Krankenkasse, 
             UnterstuetztVon, 
             UnterstuetztBis, 
             BaPersonID
    ORDER BY Nachname, Vorname, Versichertennummer, UnterstuetztVon;
  END;
END;
GO
