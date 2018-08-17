CREATE FUNCTION dbo.fnShGetBudget
 (@BgBudgetID int,
  @GetDate    datetime)
RETURNS
  @OUTPUT TABLE (
    Rec_ID            int,
    Parent_ID         int,
    SortKey           int IDENTITY(1, 1) PRIMARY KEY,

    Style             int,

    BgPositionID      int,
    BgPositionCode    int,
    ShPositionTypID   int,
    ShPositionTypCode int,

    ShEinzelzahlungID int,

    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,
    KOA               int,
    ShBelegID         int,
    ShSpezkontoID     int,
    ShZahlungsmodusID int,
    Dritte            bit,
    Zahlungsmodus     varchar(500),
    Bemerkung         varchar(4000)
  )
AS BEGIN
  DECLARE @Budget TABLE (
    PKey              int IDENTITY(1, 1) PRIMARY KEY,

    Rec_ID            int,
    Parent_ID         int,
    SortKey           int,

    Style             int,

    BgPositionID      int,
    BgPositionCode    int,
    ShPositionTypID   int,
    ShPositionTypCode int,

    ShEinzelzahlungID int,

    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,
    KOA               int,
    ShBelegID         int,
    ShSpezkontoID     int,
    ShZahlungsmodusID int,
    Dritte            bit,
    Bemerkung         varchar(4000)
  )

  DECLARE @Betrag          money,
          @ShFinanzPlanID  int,
          @RefDate         datetime

  SELECT
    @ShFinanzPlanID = BBG.ShFinanzPlanID,
    @RefDate = CASE WHEN BBG.BgBudgetCode < 10 THEN
                 CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(IsNull(SFP.DatumVon, SFP.GeplantVon), @GetDate), IsNull(SFP.DatumBis, SFP.GeplantBis)))
               ELSE
                 dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
               END
  FROM BgBudget              BBG
    INNER JOIN ShFinanzPlan  SFP ON SFP.ShFinanzPlanID = BBG.ShFinanzPlanID
  WHERE BBG.BgBudgetID = @BgBudgetID


  DECLARE @BgPosition TABLE (
    BgPositionID  int PRIMARY KEY,
    Dritte        bit NOT NULL DEFAULT (0)
  )

  INSERT INTO @BgPosition
    SELECT BPO.BgPositionID,
      Dritte = CASE WHEN NOT EXISTS (SELECT *
                                     FROM ShTeilzahlung            STZ
                                       LEFT  JOIN ShZahlungsmodus  SZM ON SZM.ShZahlungsmodusID = STZ.ShZahlungsmodusID
                                       LEFT  JOIN FlZahlungsweg    FLW ON FLW.FlZahlungswegID = IsNull(STZ.FlZahlungswegID, SZM.FlZahlungswegID)
                                     WHERE STZ.ShBelegID = BPO.ShBelegID AND (STZ.DmgPersonID IS NULL OR IsNull(BPO.DmgPersonID, STZ.DmgPersonID) = STZ.DmgPersonID)
                                       AND ( (FLW.FlKreditorID IS NULL AND STZ.ShZahlungsartCode BETWEEN 103 AND 104)
                                        OR FLW.FlKreditorID IN (SELECT FLZ2.FlKreditorID
                                                                FROM ShFinanzPlan_DmgPerson  SPP
                                                                  INNER JOIN FlZahlungsweg   FLZ2 ON FLZ2.FlZahlungswegID = SPP.FlZahlungswegID
                                                                WHERE SPP.ShFinanzPlanID = @ShFinanzPlanID AND SPP.DmgPersonID = IsNull(STZ.DmgPersonID, SPP.DmgPersonID)) ) )
                THEN 1 ELSE 0 END
    FROM vwBgPosition             BPO
      LEFT  JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID = BPO.ShPositionTypID
      LEFT  JOIN BgPosition       BPO2 ON BPO2.BgPositionID = BPO.BgPositionID_CopyOf
      LEFT  JOIN BgPosition       BPO3 ON BPO3.BgPositionID = BPO2.BgPositionID_CopyOf
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND CASE
            WHEN BPO.BgPositionCode = 5           THEN 0   -- Vermögen
            WHEN SPT.ShPositionTypCode IN (6, 7)  THEN     -- Miete, KVG, VVG
              CASE WHEN BPO.GueltigBis IS NULL THEN 1 ELSE 0 END
            ELSE
              CASE WHEN @RefDate BETWEEN IsNull(BPO.GueltigVon, '19000101') AND IsNull(BPO.GueltigBis, '20790606') THEN 1 ELSE 0 END
          END = 1
      AND (BPO.BetragBudget > $0.00 OR BPO2.Betrag > $0.00 OR BPO3.Betrag > $0.00
            OR BPO.ShPositionTypID IN (39900, 39910) /* Sanktionen immer anzeigen */
          )


-- Einnahmen, Ausgaben, Kürzungen (Beträge)
  INSERT INTO @Budget (Style, Parent_ID, SortKey, BgPositionID, BgPositionCode, ShPositionTypCode, ShPositionTypID,
                       Bezeichnung, Betrag, KOA, ShBelegID, ShSpezkontoID, ShZahlungsmodusID, Dritte, Bemerkung)
  SELECT Style             = MIN(
                               CASE BPO.BgPositionCode
                               WHEN 1 THEN CASE WHEN BPO.VerwaltungSD = 1          THEN 12 ELSE 11 END
                               WHEN 2 THEN CASE WHEN BPO.ShSpezkontoID IS NOT NULL THEN 23
                                                WHEN STZ.Dritte = 1                THEN 22 ELSE 21 END
                               WHEN 4 THEN 41
                               WHEN 6 THEN 61
                               ELSE NULL
                               END
                             ),
         Parent_ID         = MIN(IsNull((SPT.ShPositionTypCode * 4) + 1, BPO.BgPositionCode * 4)),
         SortKey           = MIN(SPT.SortKey),
         BgPositionID      = BPO.BgPositionID,
         BgPositionCode    = MIN(BPO.BgPositionCode),
         ShPositionTypCode = MIN(SPT.ShPositionTypCode),
         ShPositionTypID   = MIN(SPT.ShPositionTypID),
         Bezeichnung       = MIN(IsNull(IsNull(NullIf(RTrim(BPO.Buchungstext), ''), SPT.Name) +
                             IsNull(' (' + PRS.Name + ' ' + PRS.Vorname1 + ')', ''), SPK.NameSpezkonto)),
         Betrag            = SUM(IsNull(CASE WHEN BPO.DmgPersonID IS NULL THEN STZ.PersonFactor ELSE 1 END, 1) * BPO.BetragBudget),
         KOA               = MIN(SPT.FlKostenartID),
         ShBelegID         = MIN(BPO.ShBelegID),
         ShSpezkontoID     = MIN(BPO.ShSpezkontoID),
         ShZahlungsmodusID = MIN(STZ.ShZahlungsmodusID),
         Dritte            = MIN(CASE WHEN BPO.BgPositionCode = 1 THEN BPO.VerwaltungSD ELSE STZ.Dritte END),
         Bemerkung         = MIN(IsNull(CASE
                                 WHEN BPO.BgPositionCode = 1     THEN 'Wird vom ' + CASE WHEN BPO.VerwaltungSD = 1
                                                                                    THEN 'Sozialdienst'
                                                                                    ELSE 'Klient' END + ' verwaltet'
                                 WHEN BPO.GueltigVon IS NOT NULL AND BPO.ShPositionTypID in (20,21,60,62,63) THEN 'angepasst'
                                 END + IsNull(', Rechnungsbetrag: ' + LTrim(STR(NullIf(BPO.BetragRechnung, BPO.BetragBudget), 19, 2)), ''),
                                       IsNull(  'Rechnungsbetrag: ' + LTrim(STR(NullIf(BPO.BetragRechnung, BPO.BetragBudget), 19, 2)), '')))
  FROM   vwBgPosition BPO
         LEFT  JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID = BPO.ShPositionTypID
         LEFT  JOIN DmgPerson        PRS ON PRS.DmgPersonID = BPO.DmgPersonID
         LEFT  JOIN (SELECT SBL.ShBelegID,
                            STZ.ShZahlungsmodusID,
                            SPP.DmgPersonID,
                            PersonFactor = (SELECT CONVERT(real, 1) / COUNT(*)
                                            FROM   ShFinanzPlan_DmgPerson
                                            WHERE ShFinanzPlanID = BBG.ShFinanzPlanID AND IstUnterstuetzt = 1),
                            Dritte = CASE WHEN EXISTS (SELECT *
                                                       FROM   ShZahlungsmodus          SZM
                                                              LEFT  JOIN FlZahlungsweg    FLW ON FLW.FlZahlungswegID = IsNull(STZ.FlZahlungswegID, SZM.FlZahlungswegID)
                                                       WHERE SZM.ShZahlungsmodusID = STZ.ShZahlungsmodusID AND
                                                             ( (FLW.FlKreditorID IS NULL AND STZ.ShZahlungsartCode BETWEEN 103 AND 104) OR
                                                                FLW.FlKreditorID IN (SELECT FLZ2.FlKreditorID
                                                                                     FROM   ShFinanzPlan_DmgPerson  SPP
                                                                                            INNER JOIN FlZahlungsweg   FLZ2 ON FLZ2.FlZahlungswegID = SPP.FlZahlungswegID
                                                                                     WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID) ) )
                                     THEN 0 ELSE 1 END
                     FROM   BgBudget                        BBG
                            INNER JOIN ShBeleg                 SBL ON SBL.BgBudgetID     = BBG.BgBudgetID
                            INNER JOIN ShTeilzahlung           STZ ON STZ.ShBelegID      = SBL.ShBelegID
                            INNER JOIN ShFinanzPlan_DmgPerson  SPP ON SPP.ShFinanzPlanID = BBG.ShFinanzPlanID
                     WHERE  BBG.BgBudgetID = @BgBudgetID AND
                            SPP.IstUnterstuetzt = 1 AND
                            (STZ.DmgPersonID IS NULL OR STZ.DmgPersonID = SPP.DmgPersonID)
                ) STZ ON STZ.ShBelegID = BPO.ShBelegID AND (BPO.DmgPersonID IS NULL OR STZ.DmgPersonID = BPO.DmgPersonID)
          LEFT  JOIN ShZahlungsmodus  SZM ON SZM.ShZahlungsmodusID = STZ.ShZahlungsmodusID
          LEFT  JOIN ShSpezkonto      SPK ON SPK.ShSpezkontoID = BPO.ShSpezkontoID
  WHERE EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)
  GROUP BY BPO.BgPositionID, STZ.ShZahlungsmodusID

  -- SKOS2005
  DECLARE @Limit money, @SumZulage money

  SELECT @SumZulage = SUM(BPO.Betrag)
  FROM @Budget  BPO
  WHERE BPO.BgPositionCode = 2 AND BPO.ShPositionTypID BETWEEN 39000 AND 39999

  IF @SumZulage > $0.00 BEGIN
    SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
    FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
    WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnShKennzahlen(@ShFinanzPlanID) KNZ)
    ORDER BY CFG.Child DESC

    IF @SumZulage > @Limit
      UPDATE @Budget
        SET Betrag = Betrag * @Limit / @SumZulage
      WHERE BgPositionCode = 2 AND ShPositionTypID BETWEEN 39000 AND 39999
  END

-- Einnahmen, Ausgaben, Kürzungen (Titel)
  INSERT INTO @Budget (Rec_ID, Style, SortKey, BgPositionCode, Bezeichnung)
  SELECT TMP.BgPositionCode * 4, 1, MAX(XLC.SortKey), TMP.BgPositionCode, UPPER(MIN(XLC.text))
  FROM @Budget           TMP
    INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'BgPosition' AND XLC.Code = TMP.BgPositionCode
  GROUP BY TMP.BgPositionCode

-- Einnahmen, Ausgaben, Kürzungen (Gruppe)
  INSERT INTO @Budget (Rec_ID, Parent_ID, Style, SortKey, BgPositionCode, ShPositionTypCode, Bezeichnung)
  SELECT TMP.ShPositionTypCode * 4 + 1, TMP.BgPositionCode * 4, 2, MIN(XLC.SortKey), TMP.BgPositionCode, TMP.ShPositionTypCode, MIN(XLC.text)
  FROM @Budget           TMP
    INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'ShPositionTyp' AND XLC.Code = TMP.ShPositionTypCode
  GROUP BY TMP.BgPositionCode, TMP.ShPositionTypCode

-- Einnahmen, Ausgaben, Kürzungen (Summen)
  INSERT INTO @Budget (Parent_ID, Style, SortKey, BgPositionCode, Bezeichnung, Total)
  SELECT TMP.BgPositionCode * 4, 2, 999998, TMP.BgPositionCode, 'Total ' + MIN(XLC.text), SUM(TMP.Betrag)
  FROM @Budget           TMP
    INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'BgPosition' AND XLC.Code = TMP.BgPositionCode
  GROUP BY TMP.BgPositionCode, XLC.text

  INSERT INTO @Budget (Parent_ID, Style, SortKey, BgPositionCode, Bezeichnung)
  SELECT TMP.BgPositionCode * 4, 2, 999999, TMP.BgPositionCode, ''
  FROM @Budget           TMP
  GROUP BY TMP.BgPositionCode


-- Einzelzahlungen
  IF EXISTS (SELECT * FROM ShEinzelzahlung WHERE BgBudgetID = @BgBudgetID) BEGIN
    -- Einzelzahlung (Titel)
    INSERT INTO @Budget (Rec_ID, SortKey, Style, Bezeichnung) VALUES (-99, 3, 1, 'EINZELZAHLUNG')

    -- Einzelzahlung (Gruppe)
    INSERT INTO @Budget (Rec_ID, Parent_ID, Style, SortKey, BgPositionCode, Bezeichnung)
    SELECT DISTINCT
           Rec_ID         = COALESCE(SEZ.ShSpezkontoID * 2, SEZ.ShPositionTypID * 2 + 1, 0),
           Parent_ID      = -99,
           Style          = 2,
           SortKey        = COALESCE(XLC.SortKey, SPT.SortKey, 0) * 1000 + SEZ.ShSpezkontoID,
           BgPositionCode = 100,
           Bezeichnung    = COALESCE(XLC.text + ': ' + SSK.NameSpezkonto, 'Zusätzliche Leistung: ' + SPT.Name
                            , 'Finanzierung durch Reduktion Grundbedarf')
    FROM   ShEinzelzahlung        SEZ
           LEFT  JOIN ShPositionTyp  SPT ON SPT.ShPositionTypID = SEZ.ShPositionTypID
           LEFT  JOIN ShSpezkonto    SSK ON SSK.ShSpezkontoID   = SEZ.ShSpezkontoID
           LEFT  JOIN XLOVCode       XLC ON XLC.LOVName = 'ShSpezkontoTyp' AND XLC.Code = SSK.ShSpezkontoTypCode
    WHERE  SEZ.BgBudgetID = @BgBudgetID

    -- Einzelzahlung (Positionen)
    INSERT INTO @Budget (Style, BgPositionCode, ShPositionTypID, Parent_ID, SortKey, Bezeichnung, Betrag, ShBelegID, KOA, ShZahlungsmodusID, Dritte, ShEinzelzahlungID, Bemerkung)
    SELECT Style             = CASE WHEN SEZ.ShPositionTypID IS NULL
                               THEN CASE WHEN SEZ.ShSpezkontoID IS NULL THEN 81 ELSE 82 END
                               ELSE SEZ.ShStatusEinzelzahlungCode - 18
                               END,
           BgPositionCode    = 100,
           SEZ.ShPositionTypID,
           Parent_ID         = COALESCE(SEZ.ShSpezkontoID * 2, SEZ.ShPositionTypID * 2 + 1, 0),
           SortKey           = SEZ.ShSpezkontoID,
           Bezeichnung       = SEZ.NameEinzelzahlung + IsNull(' (' + PRS.Name + ' ' + PRS.Vorname1 + ')',''),
           Betrag            = SEZ.Betrag,
           ShBelegID         = SEZ.ShBelegID,
           KOA               = SEZ.FlKostenartID,
           ShZahlungsmodusID = STZ.ShZahlungsmodusID,
           Dritte            = CASE WHEN EXISTS (SELECT *
                                                 FROM ShZahlungsmodus          SZM
                                                   LEFT  JOIN FlZahlungsweg    FLW ON FLW.FlZahlungswegID = IsNull(STZ.FlZahlungswegID, SZM.FlZahlungswegID)
                                                 WHERE SZM.ShZahlungsmodusID = STZ.ShZahlungsmodusID
                                                   AND ( (FLW.FlKreditorID IS NULL AND STZ.ShZahlungsartCode BETWEEN 103 AND 104) OR
                                                          FLW.FlKreditorID IN (SELECT FLZ2.FlKreditorID
                                                                               FROM ShFinanzPlan_DmgPerson  SPP
                                                                                 INNER JOIN FlZahlungsweg   FLZ2 ON FLZ2.FlZahlungswegID = SPP.FlZahlungswegID
                                                                               WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID) ) )
                                     THEN 0 ELSE 1 END,

           ShEinzelzahlungID = SEZ.ShEinzelzahlungID,
           Bemerkung         = CASE WHEN SPT.ShPositionTypCode = 100 THEN XLC.text ELSE '' END
      FROM ShEinzelzahlung          SEZ
        LEFT  JOIN XLOVCode         XLC ON XLC.LOVName = 'ShStatusEinzelzahlung' AND XLC.Code = SEZ.ShStatusEinzelzahlungCode
        LEFT  JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID   = SEZ.ShPositionTypID
        LEFT  JOIN ShSpezkonto      SSK ON SSK.ShSpezkontoID     = SEZ.ShSpezkontoID
        LEFT  JOIN ShTeilzahlung    STZ ON STZ.ShBelegID         = SEZ.ShBelegID
        LEFT  JOIN ShZahlungsmodus  SZM ON SZM.ShZahlungsmodusID = STZ.ShZahlungsmodusID
        LEFT  JOIN DmgPerson        PRS ON PRS.DmgPersonID       = SEZ.DmgPersonID
      WHERE SEZ.BgBudgetID = @BgBudgetID


    -- Einzelzahlung (Summe)
    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Total)
    SELECT -99, 999998, 2, 'Total Einzelzahlungen', SUM(SEZ.Betrag)
    FROM   ShEinzelzahlung      SEZ
    WHERE  SEZ.BgBudgetID = @BgBudgetID

    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung) VALUES (-99, 999999, 2, '')
  END


-- Übersicht
  DECLARE @BetragSumme money


  INSERT INTO @Budget (Rec_ID, SortKey, Style, Bezeichnung) VALUES (-1, 99, 1, 'ÜBERSICHT')
    INSERT INTO @Budget (Rec_ID, Parent_ID, SortKey, Style, Bezeichnung) VALUES (-10, -1, 1, 2, 'Leistungen des Sozialdienstes')
      SET @BetragSumme = 0

      SELECT @Betrag = SUM(BPO.BetragBudget) - CASE WHEN @SumZulage > @Limit THEN @SumZulage - @Limit ELSE $0.00 END
      FROM vwBgPosition            BPO
      WHERE BPO.BgPositionCode = 2 AND BPO.ShBelegID IS NOT NULL
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID AND Dritte = 0)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 2, 3, 'Ausgaben, an Klient', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM vwBgPosition            BPO
      WHERE BPO.BgPositionCode = 2 AND BPO.ShBelegID IS NOT NULL
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID AND Dritte = 1)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 3, 3, 'Ausgaben, an Dritte', IsNull(@Betrag, 0))

      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM vwBgPosition            BPO
      WHERE BPO.BgPositionCode = 2 AND BPO.ShSpezkontoID IS NOT NULL
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 4, 3, 'Ausgaben, Gutschrift auf Ausgabenkonto', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM vwBgPosition            BPO
      WHERE BPO.BgPositionCode = 4
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 5, 3, 'Abzüglich Kürzungen', IsNull(0 - @Betrag, 0))
      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)

      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM vwBgPosition            BPO
      WHERE BPO.BgPositionCode = 1
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 6, 3, 'Abzüglich Einkommen', IsNull(0 - @Betrag, 0))
      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)

      SELECT @Betrag = SUM(SEZ.Betrag)
      FROM ShEinzelzahlung     SEZ
      WHERE SEZ.BgBudgetID = @BgBudgetID AND SEZ.ShPositionTypID IS NOT NULL AND SEZ.ShStatusEinzelzahlungCode = 103
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 6, 3, 'Situationsbedingte Leistungen (nur bewilligte)', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Total) VALUES (-1, 8, 2, 'Total Leistungen', @BetragSumme)


    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung) VALUES (-1, 9, 2, '')
    INSERT INTO @Budget (Rec_ID, Parent_ID, SortKey, Style, Bezeichnung) VALUES (-20, -1, 10, 2, 'Zahlungen des Sozialdienstes')
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-20, 1, 3, 'Total Leistungen', @BetragSumme)

      -- Spezkonti
      SELECT @Betrag = SUM(BPO.BetragRechnung)
      FROM vwBgPosition            BPO
      WHERE BPO.ShSpezkontoID IS NOT NULL
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag)
        SELECT -20, MIN(XLC.Code) + 1, 3, 'Abzüge für ' + LEFT(XLC.text, LEN(XLC.text) - 1) + 'i', IsNull(SUM(-BPO.Betrag), 0)
        FROM XLOVCode        XLC
          LEFT  JOIN (SELECT SUM(BPO.BetragRechnung) AS Betrag, SSK.ShSpezkontoTypCode
                      FROM vwBgPosition         BPO
                        INNER JOIN ShSpezkonto  SSK ON SSK.ShSpezkontoID = BPO.ShSpezkontoID
                      WHERE EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)
                      GROUP BY SSK.ShSpezkontoTypCode
                     ) BPO ON BPO.ShSpezkontoTypCode = XLC.Code
        WHERE XLC.LOVName = 'ShSpezkontoTyp'
        GROUP BY XLC.text

      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)

      -- Von SD verwaltete Einnahmen
      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM vwBgPosition            BPO
      WHERE BPO.BgPositionCode = 1 AND VerwaltungSD = 1
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-20, 16, 3, 'Von SD verwaltete Einnahmen', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

      -- Zahlungen aus Vorabzugs-, Abzahlungs- und Ausgabekonti
      SELECT @Betrag = SUM(SEZ.Betrag)
      FROM ShEinzelzahlung         SEZ
      WHERE SEZ.BgBudgetID = @BgBudgetID AND SEZ.ShSpezkontoID IS NOT NULL
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-20, 17, 3, 'Zahlungen aus Vorabzugs-, Abzahlungs- und Ausgabekonti', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Total) VALUES (-1, 18, 2, 'Total Zahlungen', @BetragSumme)


    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung) VALUES (-1, 19, 2, '')
    INSERT INTO @Budget (Rec_ID, Parent_ID, SortKey, Style, Bezeichnung) VALUES (-30, -1, 20, 2, 'Zahlungen des Sozialdienstes')
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-30, 1, 3, 'Total Zahlungen', @BetragSumme)

      -- Zahlungen an Dritte (Budget)
      SELECT @Betrag = SUM(BPO.BetragRechnung)
      FROM vwBgPosition            BPO
      WHERE BPO.BgPositionCode = 2 AND BPO.ShBelegID IS NOT NULL
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID AND Dritte = 1)

      -- Zahlungen an Dritte (Einzelzahlung)
      SELECT @Betrag = IsNull(@Betrag, $0.00) + IsNull(SUM(TMP.Betrag), $0.00)
      FROM @Budget                  TMP
        INNER JOIN ShEinzelzahlung  SEZ ON SEZ.ShEinzelzahlungID = TMP.ShEinzelzahlungID
        LEFT  JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID   = SEZ.ShPositionTypID
      WHERE TMP.Dritte = 1 AND TMP.BgPositionCode = 100
        AND (SPT.ShPositionTypCode IS NULL OR SPT.ShPositionTypCode <> 100 OR SEZ.ShStatusEinzelzahlungCode = 103)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-30, 2, 3, 'Zahlungen an Dritte', IsNull(-@Betrag, 0))
      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)

    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Total) VALUES (-1, 20, 2, 'Total Zahlungen an Klient', @BetragSumme)


-- Output
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style,
    BgPositionID, BgPositionCode, ShPositionTypID, ShPositionTypCode, ShEinzelzahlungID,
    Bezeichnung, Betrag, Total, KOA, ShBelegID, ShSpezkontoID, ShZahlungsmodusID, Dritte, Zahlungsmodus, Bemerkung)
  SELECT TMP.Rec_ID, TMP.Parent_ID, TMP.Style,
    TMP.BgPositionID, TMP.BgPositionCode, TMP.ShPositionTypID, SPT.ShPositionTypCode, TMP.ShEinzelzahlungID,
    Bezeichnung = CASE TMP.Style
                    WHEN 1 THEN ''
                    WHEN 2 THEN '  '
                    ELSE        '    '
                  END + TMP.Bezeichnung,
    TMP.Betrag, TMP.Total, KOA.IdFibuKostenart, TMP.ShBelegID, TMP.ShSpezkontoID, TMP.ShZahlungsmodusID, TMP.Dritte,
    IsNull(SZM.NameZahlungsmodus + CASE WHEN TMP.Dritte = 1 THEN ' (Dritte)' ELSE ' (Klient)' END, 'Gutschrift für ' + SSK.NameSpezkonto), TMP.Bemerkung
  FROM @Budget                 TMP
    LEFT JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID   = TMP.ShPositionTypID
    LEFT JOIN ShZahlungsmodus  SZM ON SZM.ShZahlungsmodusID = TMP.ShZahlungsmodusID
    LEFT JOIN ShSpezkonto      SSK ON SSK.ShSpezkontoID     = TMP.ShSpezkontoID
    LEFT JOIN FlKostenart      KOA ON KOA.FlKostenartID     = TMP.KOA
    LEFT JOIN @Budget          SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget          GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget          TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  RETURN
END

GO