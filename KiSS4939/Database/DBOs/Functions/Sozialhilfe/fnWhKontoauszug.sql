SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhKontoauszug;
GO
/*===============================================================================================
  $Revision: 8$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt die Tabelle für den Kontauszug zurück
  PARAMS:
    @FallBaPersonID
    @BaPersonIDsString
    @KbKontoZeitraumCode
    @DatumVon
    @DatumBis
    @LAList
    @Verdichtet
    @BetraegeAnpassen
    @FaLeistungIDsString
    @AlleKlienten
    @NeueSeite
  -
  RETURNS: Tabelle Kontauszug (@Output)
=================================================================================================
  TEST:    SELECT * FROM dbo.fnWhKontoauszug(…);
=================================================================================================*/

CREATE FUNCTION dbo.fnWhKontoauszug
(
  @FallBaPersonID INT,
  @BaPersonIDsString VARCHAR(200),
  @KbKontoZeitraumCode INT,  /* 1 Buchungsdatum (= BelegDatum), 3 Verwendungsperiode */
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @LAList VARCHAR(2000),
  @Verdichtet BIT,
  @BetraegeAnpassen BIT,
  @FaLeistungIDsString VARCHAR(200),
  @AlleKlienten BIT = 0,
  @NeueSeite BIT = 0,
  @SaldoVortragKiss BIT = 0,
  @SaldoVortragFremdsystem BIT = 0
)
/* Die auszugebende Tabelle */
RETURNS @Output TABLE
(
  ID                  INT NOT NULL IDENTITY(1, 1),
  OrgName             VARCHAR(1000),	
  OrgAdresse          VARCHAR(1000),         
  OrgPLZOrt           VARCHAR(1000),
  NeueSeite           BIT,
  DruckDatum          VARCHAR(200),
  Auswertungszeitraum VARCHAR(100),
  KbBuchungID         INT,
  BelegDatum          datetime,
  ValutaDatum         datetime,
  BaPersonID          INT,
  Klient              VARCHAR(200),
  BelegNr             VARCHAR(20),
  LA                  VARCHAR(10),
  LAText              VARCHAR(110),
  Buchungstext        VARCHAR(400),
  VerwPeriodeVon      DATETIME,
  VerwPeriodeBis      DATETIME,
  BgSplittingArtCode  INT,
  Betrag              MONEY,
  BetragSaldo         MONEY,
  Betrag100           MONEY,
  EA                  VARCHAR(1), /* E = Einnahme, A = Ausgabe */
  KbBuchungStatusCode INT,
  Doc                 VARCHAR(1),
  Auszahlart          VARCHAR(100),
  KreditorDebitor     VARCHAR(2000),
  Einnahme	          MONEY,
  Ausgabe             MONEY,
  Saldo               MONEY,
  SortKey             INT -- 1: Saldovortrag KiSS, 2: Saldovortrag Fremdsystem, 3: Total Saldovortrag, 4: Buchung
)
AS
BEGIN
  DECLARE
    @CountSonderZeilen INT,
    @PeriodeKlibu INT,
    @OrgName VARCHAR(1000), 
    @OrgAdresse VARCHAR(1000), 
    @OrgPLZOrt VARCHAR(1000),
    @DatumString VARCHAR(200);

  SET @KbKontoZeitraumCode = ISNULL(@KbKontoZeitraumCode, 1);
  SET @DatumVon = ISNULL(@DatumVon, '17530101');
  SET @DatumBis = ISNULL(@DatumBis, '99991231');
  SET @LAList = ISNULL(@LAList, '');
  SET @AlleKlienten = ISNULL(@AlleKlienten, 0);
  SET @NeueSeite = ISNULL(@NeueSeite, 0);
  SET @SaldoVortragFremdsystem = ISNULL(@SaldoVortragFremdsystem, 0);
  SET @SaldoVortragKiss = ISNULL(@SaldoVortragKiss, 0);
  SET @CountSonderZeilen = 0;

  SET @PeriodeKlibu = CONVERT(INT, dbo.fnXConfig('System\KliBu\KliBuIntegriertSeitPeriode', GETDATE())); -- keine alten Buchungen (Simultan)
  SET @OrgName      = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig('System\Adresse\Sozialhilfe\Organisation', GETDATE())), '');
  SET @OrgAdresse   = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig('System\Adresse\Sozialhilfe\Adresse', GETDATE())), '');
  SET @OrgPLZOrt    = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig('System\Adresse\Sozialhilfe\PLZ', GETDATE())) + ' ', '')
                    + ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig('System\Adresse\Sozialhilfe\Ort', GETDATE())), '');
  SET @DatumString = 'Ausdruckdatum ' + CONVERT(VARCHAR(20), GETDATE(), 104);
  
  DECLARE @BaPersonIDs TABLE 
  (
    BaPersonID INT
  );

  DECLARE @FaLeistungIDs TABLE 
  (
    FaLeistungID INT,
    DatumVon DATETIME,
    DatumBis DATETIME
  );

  DECLARE @Buchungen TABLE
  (
    KbBuchungID         INT,
    BelegDatum          DATETIME,
    ValutaDatum         DATETIME,
    BaPersonID          INT,
    Klient              VARCHAR(200),
    BelegNr             VARCHAR(20),
    LA                  VARCHAR(10),
    LAText              VARCHAR(110),
    Buchungstext        VARCHAR(400),
    VerwPeriodeVon      DATETIME,
    VerwPeriodeBis      DATETIME,
    BgSplittingArtCode  INT,
    Betrag              MONEY,
    Betrag100           MONEY,
    EA                  VARCHAR(1), -- E = Einnahme, A = Ausgabe
    KbBuchungStatusCode INT,
    Doc                 VARCHAR(1),
    Auszahlart          VARCHAR(100),
    KreditorDebitor     VARCHAR(2000),
    BgFinanzplanID      INT,
    Saldo               MONEY,
    SortKey             INT -- 1: Saldovortrag KiSS, 2: Saldovortrag Fremdsystem, 3: Total Saldovortrag, 4: Buchung
  );

  DECLARE @AnzahlPersonenImHaushalt TABLE(
    BgFinanzplanID      INT,
    AnzahlPersonen      INT
  );

  INSERT INTO @FaLeistungIDs (FaLeistungID, DatumVon, DatumBis)
    SELECT LEI.FaLeistungID, LEI.DatumVon, ISNULL(LEI.DatumBis, '99991231')
    FROM dbo.fnSplit(@FaLeistungIDsString, ',')
    INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = CONVERT(INT, Value)
  
  INSERT INTO @AnzahlPersonenImHaushalt
    SELECT BFP.BgFinanzplanID, AnzahlPersonen = COUNT(PRS.BaPersonID)
    FROM BgFinanzplan_BaPerson    BFB
      INNER JOIN vwPerson         PRS ON PRS.BaPersonID = BFB.BaPersonID
      INNER JOIN BgFinanzplan     BFP ON BFP.BgFinanzplanID = BFB.BgFinanzplanID
      INNER JOIN FaLeistung       FLE ON FLE.FaLeistungID = BFP.FaLeistungID
      INNER JOIN FaFall           FAL ON FAL.FaFallID = FLE.FaFallID
    WHERE FAL.BaPersonID = IsNUll(@FallBaPersonID, FAL.BaPersonID)
      AND (@FaLeistungIDsString IS NULL OR FLE.FaLeistungID IN (SELECT FaLeistungID FROM @FaLeistungIDs))
      AND BFB.IstUnterstuetzt = 1
    GROUP BY BFP.BgFinanzplanID;

  -- anzuzeigende Personen lesen (übergebene BaPersonIDs splitten oder ganze UE lesen)
  IF (@AlleKlienten = 1)
  BEGIN
    -- Alle Klienten brücksichtigen:
   INSERT INTO @BaPersonIDs (BaPersonID)
      SELECT DISTINCT 
        ISNULL(FPP.BaPersonID, KBP.BaPersonID)
      FROM dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KBK.KbBuchungID
        INNER JOIN dbo.KbKostenstelle KST WITH (READUNCOMMITTED) ON KST.KbKostenstelleID = KBK.KbKostenstelleID
        INNER JOIN dbo.KbKostenstelle_BaPerson KBP WITH (READUNCOMMITTED) ON KBP.KbKostenstelleID = KST.KbKostenstelleID
                                                                         AND BUC.BelegDatum BETWEEN IsNull(KBP.DatumVon, '19000101') AND ISNULL(KBP.DatumBis, '99991231')
        LEFT JOIN dbo.BgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = KBK.BgPositionID
        LEFT JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
        LEFT JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BDG.BgFinanzplanID AND FPP.IstUnterstuetzt = 1
        LEFT JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
      WHERE BUC.BelegDatum IS NOT NULL
        AND BUC.BelegDatum BETWEEN ISNULL(@DatumVon, BUC.BelegDatum) AND ISNULL(@DatumBis, BUC.BelegDatum)
        AND (@FallBaPersonID = 0 OR @FallBaPersonID = FPP.BaPersonID)
        AND (@FaLeistungIDsString IS NULL OR FPL.FaLeistungID IN (SELECT FaLeistungID FROM @FaLeistungIDs))
  END
  ELSE IF(@BaPersonIDsString IS NOT NULL)
  BEGIN
    INSERT INTO @BaPersonIDs (BaPersonID)
    SELECT CONVERT(INT, Value)
    FROM dbo.fnSplit(@BaPersonIDsString, ',');
  END
  ELSE IF(@FaLeistungIDsString IS NOT NULL)
  BEGIN
    INSERT INTO @BaPersonIDs (BaPersonID)
      SELECT DISTINCT PRS.BaPersonID
    FROM @FaLeistungIDs LEI
      CROSS APPLY (SELECT BaPersonID
                   FROM dbo.fnWhGetUePersonen(@FallBaPersonID, NULL, LEI.FaLeistungID)) PRS
  END
  ELSE
  BEGIN
    INSERT INTO @BaPersonIDs (BaPersonID)
      SELECT BaPersonID
      FROM dbo.fnWhGetUePersonen(@FallBaPersonID, NULL, NULL);
  END;

  -- KostenartBuchungen dieser Personen
  INSERT INTO @Buchungen (KbBuchungID, BelegDatum, ValutaDatum, BaPersonID, Klient, BelegNr, LA, LAText, BgSplittingArtCode, Buchungstext,
                          VerwPeriodeVon, VerwPeriodeBis, Betrag, Betrag100, EA, KbBuchungStatusCode, BgFinanzplanID, Saldo, SortKey)
    SELECT
      KbBuchungID         = BUC.KbBuchungID,
      BelegDatum          = BUC.BelegDatum,
      ValutaDatum         = BUC.ValutaDatum,
      BaPersonID          = PRS.BaPersonID,
      Klient              = PRS.Name + ISNULL(' ' + PRS.Vorname, ''),
      BelegNr             = CONVERT(varchar(20), BUC.BelegNr),
      LA                  = KOA.KontoNr,
      LAText              = KOA.KontoNr + ' ' + KOA.Name,
      BgSplittingArtCode  = KOA.BgSplittingArtCode,
      Buchungstext        = ISNULL(BKA.Buchungstext, '') + ' ' + ISNULL(BUC.Text, ''),
      VerwPeriodeVon      = BKA.VerwPeriodeVon,
      VerwPeriodeBis      = BKA.VerwPeriodeBis,
      Betrag              = CASE
                              WHEN @BetraegeAnpassen = 1
                                THEN ISNULL(dbo.fnWhGetBetragKontoauszug(KOA.BgSplittingArtCode, BKA.Betrag, BKA.VerwPeriodeVon, BKA.VerwPeriodeBis, @DatumVon, @DatumBis), $0.00)
                              ELSE BKA.Betrag
                            END,
      Betrag100           = BKA.Betrag,
      EA                  = CASE
                              WHEN BUC.SollKtoNr IS NOT NULL THEN 'E'
                              WHEN BUC.HabenKtoNr IS NOT NULL THEN 'A'
                            END,
      KbBuchungStatusCode = BUC.KbBuchungStatusCode,
      BgFinanzplanID      = BDG.BgFinanzplanID,
      Saldo               = $0,
      SortKey             = 4 -- Bei Änderung auch im Output ändern
    FROM dbo.KbBuchungKostenart              BKA WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchung               BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BKA.KbBuchungID
      INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.KbKostenstelleID = BKA.KbKostenstelleID
      INNER JOIN @BaPersonIDs                TMP ON TMP.BaPersonID = KST.BaPersonID
      INNER JOIN dbo.vwPerson                PRS ON PRS.BaPersonID = KST.BaPersonID
      LEFT  JOIN dbo.BgKostenart             KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = BKA.BgKostenartID
      LEFT  JOIN dbo.BgBudget                BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = BUC.BgBudgetID
                                                                       AND BUC.NeubuchungVonKbBuchungID IS NULL -- Bei Neubuchungen die BudgetID nicht berücksichtigen damit sie in andere Fälle mittel Verwendungsperiode aufgelistet wird
      LEFT  JOIN dbo.BgFinanzplan            FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    WHERE (BUC.BelegDatum IS NOT NULL)
      AND (BKA.BaPersonID IS NULL OR BKA.BaPersonID IN (SELECT BaPersonID FROM @BaPersonIDs)) -- #4838 Abfrage Kontoauszug angepasst, BaPersonID kann NULL sein (nicht Personenbezogenen Inkasso-Buchungen)
      AND BUC.KbPeriodeID >= @PeriodeKlibu
      AND BUC.BelegNr IS NOT NULL
      AND (@LAList = '' OR (',' + @LAList + ',' like '%,' + KOA.KontoNr + ',%'))       -- Filter Koa
      AND (@FaLeistungIDsString IS NULL 
           OR FPL.BgFinanzplanID IS NULL -- Falls der Finanzplan nicht ermittelt wurde soll die Buchung in beiden Fällen aufgelistet werden. Buchungen die mittels Verwendungsperiode an einem FP eines anderen Falls werden weiter unten gelöscht
           OR EXISTS (SELECT TOP 1 1 
                      FROM @FaLeistungIDs 
                      WHERE FaLeistungID = FPL.FaLeistungID))
    ORDER BY KbBuchungID, BelegDatum, LA, LAText, VerwPeriodeVon, VerwPeriodeBis, ValutaDatum, EA, KbBuchungStatusCode, Klient;


  IF (@FaLeistungIDsString IS NOT NULL)
  BEGIN
    -- Einnahmen die nicht in diesen Fall gehören löschen
    DELETE BUC
      --OUTPUT 'Einnahmen', DELETED.*
    FROM @Buchungen BUC
      INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = (SELECT TOP 1 BgBudgetID
                                                                              FROM dbo.KbOpAusgleich     OPA  WITH (READCOMMITTED)
                                                                                INNER JOIN dbo.KbBuchung BUC2 WITH (READCOMMITTED) ON BUC2.KbBuchungID = OPA.OpBuchungID
                                                                              WHERE OPA.AusgleichBuchungID = BUC.KbBuchungID
                                                                                AND BUC2.BgBudgetID IS NOT NULL) 
      INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    WHERE BUC.BgFinanzplanID IS NULL
      AND BUC.EA = 'E'-- IS NOT NULL -- nur für Einnahmen
      AND NOT EXISTS (SELECT TOP 1 1 
                      FROM @FaLeistungIDs 
                      WHERE FaLeistungID = FPL.FaLeistungID)

  
    -- manuelle Buchungen und Umbuchungen die nicht in diesen Fall gehören löschen
    DELETE BUC
      --OUTPUT 'manuelle Buchungen und Neubuchungen', DELETED.*
    FROM @Buchungen BUC
      INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = (SELECT TOP 1 BDG2.BgBudgetID
                                                                              FROM dbo.BgBudget BDG2 WITH (READUNCOMMITTED)
                                                                                INNER JOIN dbo.BgFinanzplan FPL2 WITH (READUNCOMMITTED) ON FPL2.BgFinanzplanID = BDG2.BgFinanzplanID
                                                                                INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL2.BgFinanzplanID
                                                                              WHERE FPP.BaPersonID = BUC.BaPersonID
                                                                                AND FPP.IstUnterstuetzt = 1
                                                                                AND ISNULL(FPL2.DatumVon, FPL2.GeplantVon) <= BUC.VerwPeriodeBis
                                                                                AND ISNULL(FPL2.DatumBis, FPL2.GeplantBis) >= BUC.VerwPeriodeVon)
      INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    WHERE BUC.BgFinanzplanID IS NULL
      AND NOT EXISTS (SELECT TOP 1 1 
                      FROM @FaLeistungIDs 
                      WHERE FaLeistungID = FPL.FaLeistungID)
      -- Einnahmen nicht löschen
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.BgBudget BDG2 WITH (READUNCOMMITTED) 
                        INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG2.BgFinanzplanID
                      WHERE BDG2.BgBudgetID = (SELECT TOP 1 BgBudgetID
                                               FROM dbo.KbOpAusgleich     OPA  WITH (READUNCOMMITTED)
                                                 INNER JOIN dbo.KbBuchung BUC2 WITH (READUNCOMMITTED) ON BUC2.KbBuchungID = OPA.OpBuchungID
                                               WHERE OPA.AusgleichBuchungID = BUC.KbBuchungID
                                                 AND BUC2.BgBudgetID IS NOT NULL) 
                        AND BUC.BgFinanzplanID IS NULL
                        AND BUC.EA = 'E'-- IS NOT NULL -- nur für Einnahmen
                        )
  END;



  -- Saldovortrag Fremdsystem
  IF (@SaldoVortragFremdsystem = 1)
  BEGIN
    DECLARE @SaldoFS MONEY;

    SELECT TOP 1 @SaldoFS = KST.Vorsaldo
    FROM dbo.KbKostenstelle KST WITH(READUNCOMMITTED)
      INNER JOIN dbo.KbKostenstelle_BaPerson KSP WITH(READUNCOMMITTED) ON KSP.KbKostenstelleID = KST.KbKostenstelleID
    WHERE KST.Aktiv = 1
      AND KSP.BaPersonID = @FallBaPersonID
    ORDER BY DatumVon DESC;

    IF (@SaldoFS IS NOT NULL AND @SaldoFS <> $0)
    BEGIN
    SET @CountSonderZeilen = @CountSonderZeilen+1;
      INSERT INTO @Buchungen (Buchungstext, Saldo, SortKey)
      VALUES ('Saldovortrag aus Fremdsystem', @SaldoFS, 1);
    END;
  END;

  -- Saldovortrag KiSS
  IF (@SaldoVortragKiss = 1)
  BEGIN
    DECLARE @SaldoK MONEY;

    --Wenn @BetraegeAnpassen = 1: Originalbetrag - "aufgrund Verwendungsperiode auf Abfrage-Periode umgerechneter Betrag", sprich: Der Betrag ausserhalb der Abfrage-Periode
    SELECT @SaldoK = SUM(ISNULL(CASE TMP.EA WHEN 'A' THEN CASE WHEN @BetraegeAnpassen = 1 THEN TMP.Betrag100 - TMP.Betrag 
                                                               ELSE TMP.Betrag 
                                                          END
                                            ELSE -1 * CASE WHEN @BetraegeAnpassen = 1 THEN TMP.Betrag100 - TMP.Betrag 
                                                        ELSE TMP.Betrag 
                                                      END
                                END, $0))
    FROM @Buchungen TMP
    WHERE CASE @KbKontoZeitraumCode -- Filter Zeitraum
            WHEN 1 THEN CASE WHEN TMP.BelegDatum < @DatumVon THEN 1 ELSE 0 END
            WHEN 3 THEN CASE WHEN TMP.VerwPeriodeVon < @DatumVon THEN 1 ELSE 0 END
          END = 1;

    IF (@SaldoK IS NOT NULL AND @SaldoK <> $0)
    BEGIN
      SET @CountSonderZeilen = @CountSonderZeilen+1;
    INSERT INTO @Buchungen (Buchungstext, Saldo, SortKey)
      VALUES ('Saldovortrag aus KiSS', @SaldoK, 2);
    END;
  END;

  /* Total-Zeile einfuegen, falls Saldovortrag aus Kiss und Fremdsystem vorhanden */
  IF (@CountSonderZeilen = 2)
  BEGIN
  INSERT INTO @Buchungen (Buchungstext, Saldo, SortKey)
    VALUES ('Total Saldovorträge', 0, 3);
  END

  -- OUTPUT
  IF (@Verdichtet = 0)
  BEGIN
    INSERT INTO @Output (OrgName, OrgAdresse, OrgPLZOrt, NeueSeite, DruckDatum,
                         Auswertungszeitraum, KbBuchungID, BelegDatum, ValutaDatum, BaPersonID,
                         Klient, BelegNr, LA, LAText, Buchungstext,
                         VerwPeriodeVon, VerwPeriodeBis, BgSplittingArtCode, Betrag, BetragSaldo,
                         Betrag100, EA, KbBuchungStatusCode, Doc, Auszahlart,
                         KreditorDebitor, Einnahme, Ausgabe, Saldo, SortKey)
      SELECT
        OrgName = @OrgName,
        OrgAdresse = @OrgAdresse,
        OrgPLZOrt = @OrgPLZOrt,
        NeueSeite = @NeueSeite,
        DruckDatum = @DatumString,
        Auswertungszeitraum = 'Zeitraum von ' + CONVERT(VARCHAR(20), @DatumVon, 104) + ' bis ' + CONVERT(VARCHAR(20), @DatumBis, 104),
        T.KbBuchungID,
        T.BelegDatum,
        T.ValutaDatum,
        T.BaPersonID,
        T.Klient,
        T.BelegNr,
        T.LA,
        T.LAText,
        T.Buchungstext,
        T.VerwPeriodeVon,
        T.VerwPeriodeBis,
        T.BgSplittingArtCode,
        T.Betrag, 
        BetragSaldo = CONVERT(money,0),
        T.Betrag100,
        T.EA,
        T.KbBuchungStatusCode,
        T.Doc,
        T.Auszahlart,
        T.KreditorDebitor,
        Einnahme = CASE WHEN EA = 'E' THEN T.Betrag ELSE NULL END,
        Ausgabe  = CASE WHEN EA = 'A' THEN T.Betrag ELSE NULL END,
        Saldo    = ISNULL(T.Saldo, $0),
        T.SortKey
      FROM @Buchungen T
      WHERE (CASE @KbKontoZeitraumCode -- Filter Zeitraum
               WHEN 1 THEN CASE WHEN T.BelegDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
               WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, T.VerwPeriodeVon, ISNULL(T.VerwPeriodeBis, T.VerwPeriodeVon))
             END = 1)
         OR (T.KbBuchungID IS NULL AND T.Saldo IS NOT NULL) -- Vortrag
      ORDER BY T.SortKey, T.Klient, T.BelegDatum;
  END
  ELSE BEGIN
    INSERT INTO @Output (OrgName, OrgAdresse, OrgPLZOrt, NeueSeite, DruckDatum,
                         Auswertungszeitraum, KbBuchungID, BelegDatum, ValutaDatum, BaPersonID,
                         Klient, BelegNr, LA, LAText, Buchungstext,
                         VerwPeriodeVon, VerwPeriodeBis, BgSplittingArtCode, Betrag, BetragSaldo,
                         Betrag100, EA, KbBuchungStatusCode, Doc, Auszahlart,
                         KreditorDebitor, Einnahme, Ausgabe, Saldo, SortKey)
      SELECT
        OrgName = @OrgName,
        OrgAdresse = @OrgAdresse,
        OrgPLZOrt = @OrgPLZOrt,
        NeueSeite = @NeueSeite,
        DruckDatum = @DatumString,
        Auswertungszeitraum = 'Zeitraum von ' + CONVERT(VARCHAR(20), @DatumVon, 104) + ' bis ' + CONVERT(VARCHAR(20), @DatumBis, 104),
        T.KbBuchungID,
        T.BelegDatum,
        T.ValutaDatum,
        BaPersonID   = CASE WHEN MIN(BaPersonID) = MAX(BaPersonID) THEN MAX(BaPersonID) END,
        Klient       = CASE 
                         WHEN MIN(Klient) = MAX(Klient) THEN MAX(Klient) 
                         WHEN COUNT(DISTINCT BaPersonID) < ANZ.AnzahlPersonen THEN dbo.ConcDistinct(Klient)
                         WHEN T.SortKey = 4 THEN 'ganze UE'
                         ELSE NULL -- Vortrag
                       END,
        BelegNr      = MAX(BelegNr),
        T.LA,
        T.LAText,
        Buchungstext = MAX(Buchungstext),
        T.VerwPeriodeVon,
        T.VerwPeriodeBis,
        T.BgSplittingArtCode,
        Betrag       = SUM(Betrag),
        BetragSaldo  = SUM(Betrag),
        Betrag100    = SUM(Betrag100),
        T.EA,
        T.KbBuchungStatusCode,
        T.Doc,
        T.Auszahlart,
        T.KreditorDebitor,
        Einnahme     = CASE WHEN EA = 'E' THEN SUM(Betrag) ELSE NULL END,
        Ausgabe      = CASE WHEN EA = 'A' THEN SUM(Betrag) ELSE NULL END,
        Saldo        = ISNULL(T.Saldo, $0),
        T.SortKey
      FROM @Buchungen T
        LEFT JOIN @AnzahlPersonenImHaushalt ANZ ON ANZ.BgFinanzplanID = T.BgFinanzplanID
      WHERE (CASE @KbKontoZeitraumCode -- Filter Zeitraum
               WHEN 1 THEN CASE WHEN T.BelegDatum BETWEEN @DatumVon AND @DatumBis THEN 1 ELSE 0 END
               WHEN 3 THEN dbo.fnDatumUeberschneidung(@DatumVon, @DatumBis, T.VerwPeriodeVon, ISNULL(T.VerwPeriodeBis, T.VerwPeriodeVon))
             END = 1)
         OR (T.KbBuchungID IS NULL AND T.Saldo IS NOT NULL) -- Vortrag
      GROUP BY KbBuchungID, BelegDatum, /*BelegNr,*/ LA,LAText, /*Buchungstext,*/
               VerwPeriodeVon, VerwPeriodeBis, BgSplittingArtCode, ValutaDatum,
               EA, KbBuchungStatusCode, Doc, Auszahlart, KreditorDebitor, ANZ.AnzahlPersonen,
               SortKey, Saldo
      ORDER BY T.SortKey, T.BelegDatum;
  END;

  RETURN;
END;
GO
