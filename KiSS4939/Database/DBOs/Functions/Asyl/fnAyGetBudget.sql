SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnAyGetBudget
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Asyl/fnAyGetBudget.sql $
  $Author: Tabegglen $
  $Modtime: 18.08.10 9:44 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Asyl/fnAyGetBudget.sql $
 * 
 * 6     18.08.10 13:51 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode
 * 
 * 5     11.01.10 12:58 Cjaeggi
 * #5705: Corrected wrong naming in AyBudget
 * 
 * 4     16.11.09 14:29 Lloreggia
 * Header Updated
 * 
 * 2     24.06.09 16:16 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnAyGetBudget
 (@BgBudgetID int,
  @GetDate    datetime)
RETURNS
  @OUTPUT TABLE (
    Rec_ID            int,
    Parent_ID         int,
    SortKey           int IDENTITY(1, 1) PRIMARY KEY,

    Style             int,

    BgPositionID      int,
    BgKategorieCode   int,
    BgPositionsartID  int,
    BgGruppeCode      int,

    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,
    KOA               int,
    BgSpezkontoID     int,
    BgZahlungsmodusID int,
    Dritte            bit,
    Abtretung         bit,
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
    BgKategorieCode   int,
    BgPositionsartID  int,
    BgGruppeCode      int,

    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,
    BgKostenartID     int,
    BgSpezkontoID     int,
    BgZahlungsmodusID int,
    Dritte            bit,
    Abtretung         bit DEFAULT (0),
    Bemerkung         varchar(4000)
  )

  DECLARE @Betrag          money,
          @BgFinanzplanID  int,
          @RefDate         datetime

  SELECT
    @BgFinanzplanID = BBG.BgFinanzplanID,
    @RefDate = CASE WHEN BBG.MasterBudget = 1 THEN
                 CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(IsNull(SFP.DatumVon, SFP.GeplantVon), @GetDate), IsNull(SFP.DatumBis, SFP.GeplantBis)))
               ELSE
                 dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
               END
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID


  DECLARE @BgPosition TABLE (
    BgPositionID       int NOT NULL,
    BaPersonID         int NULL,
    BgZahlungsmodusID  int,
    BaZahlungswegID    int,
    PersonFactor       real NOT NULL,
    Dritte             bit NOT NULL DEFAULT (1),
    Unique (BgPositionID, BaPersonID)
  )


  INSERT INTO @BgPosition
    SELECT
      BPO.BgPositionID,
      BaPersonID = IsNull(BPO.BaPersonID, STZ.BaPersonID),
      SZM.BgZahlungsmodusID,
      FLW.BaZahlungswegID,
      PersonFactor = (SELECT CONVERT(real, 1) / COUNT(*)
                      FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                      WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1),
      Dritte = CASE
        WHEN BPO.BgKategorieCode NOT IN (2, 100, 101)                                            THEN 0
        WHEN FLW.BaZahlungswegID IS NULL AND STZ.KbAuszahlungsArtCode BETWEEN 103 AND 104        THEN 0
        WHEN FLW.BaPersonID IS NULL                                                              THEN 1
        WHEN FLW.BaPersonID IN (SELECT BaPersonID 
                                FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                                WHERE IstUnterstuetzt = 1 AND BgFinanzplanID = @BgFinanzplanID)  THEN 0
        WHEN FLW.BaPersonID IN (SELECT FLZ2.BaPersonID
                                FROM dbo.BgFinanzplan_BaPerson   SPP WITH (READUNCOMMITTED) 
                                  INNER JOIN dbo.BaZahlungsweg   FLZ2 WITH (READUNCOMMITTED) ON FLZ2.BaZahlungswegID = SPP.BaZahlungswegID
                                WHERE IstUnterstuetzt = 1 AND BgFinanzplanID = @BgFinanzplanID)  THEN 0
        ELSE 1
      END
    FROM vwBgPosition                BPO
      LEFT  JOIN dbo.BgAuszahlungPerson  STZ WITH (READUNCOMMITTED) ON STZ.BgPositionID = BPO.BgPositionID
                                        AND (BPO.BaPersonID IS NULL OR BPO.BaPersonID = STZ.BaPersonID OR STZ.BaPersonID IS NULL)
      LEFT  JOIN dbo.BgZahlungsmodus     SZM WITH (READUNCOMMITTED) ON SZM.BgZahlungsmodusID = STZ.BgZahlungsmodusID
      LEFT  JOIN dbo.BaZahlungsweg       FLW WITH (READUNCOMMITTED) ON FLW.BaZahlungswegID = IsNull(STZ.BaZahlungswegID, SZM.BaZahlungswegID)

      LEFT  JOIN dbo.AyPositionsart      SPT  ON SPT.BgPositionsartID = BPO.BgPositionsartID
      LEFT  JOIN dbo.BgPosition          BPO2 WITH (READUNCOMMITTED) ON BPO2.BgPositionID = BPO.BgPositionID_CopyOf
      LEFT  JOIN dbo.BgPosition          BPO3 WITH (READUNCOMMITTED) ON BPO3.BgPositionID = BPO2.BgPositionID_CopyOf
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgKategorieCode != 5  -- Vermögen
      AND @RefDate BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, '20790606')
      AND (BPO.BetragBudget > $0.00 OR BPO2.Betrag > $0.00 OR BPO3.Betrag > $0.00)



-- Einnahmen, Ausgaben, Kürzungen (Beträge)
  INSERT INTO @Budget (Style, Parent_ID, SortKey, BgPositionID, BgKategorieCode, BgGruppeCode, BgPositionsartID,
          Bezeichnung, Betrag, BgKostenartID, BgSpezkontoID, BgZahlungsmodusID, Dritte, Bemerkung, Abtretung)
    SELECT Style           = MIN(CASE
                                   WHEN BPO.BgKategorieCode = 1   AND BPO.VerwaltungSD = 1             THEN 12
                                   WHEN BPO.BgKategorieCode = 2   AND BPO.BgSpezkontoID IS NOT NULL    THEN 23
                                   WHEN BPO.BgKategorieCode = 2   AND STZ.Dritte = 1                   THEN 22
                                   WHEN BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NULL        THEN 81
                                   WHEN BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NOT NULL    THEN 82
                                   WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 1  THEN 83
                                   WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 3  THEN 84
                                   WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 5  THEN 85
                                   ELSE BPO.BgKategorieCode * 10 + 1
                                 END),
         Parent_ID         = MIN(CASE
                                   WHEN BPO.BgKategorieCode IN (100, 101) THEN COALESCE(BPO.BgSpezkontoID * 2, SPT.BgGruppeCode * 2 + 1, 0)
                                   ELSE IsNull((SPT.BgGruppeCode * 4) + 1, BPO.BgKategorieCode * 4)
                                 END),
         SortKey           = MIN(SPT.SortKey),
         BgPositionID      = BPO.BgPositionID,
         BgKategorieCode   = MIN(BPO.BgKategorieCode),
         BgGruppeCode      = MIN(SPT.BgGruppeCode),
         BgPositionsartID  = MIN(SPT.BgPositionsartID),
         Bezeichnung       = MIN(IsNull(IsNull(NullIf(RTrim(BPO.Buchungstext), ''), SPT.Name) +
                             IsNull(' (' + PRS.Name + ' ' + PRS.Vorname + ')', ''), SPK.NameSpezkonto)),
         Betrag            = SUM(IsNull(CASE WHEN BPO.BaPersonID IS NULL AND STZ.BaPersonID IS NOT NULL THEN STZ.PersonFactor ELSE 1 END, 1) * BPO.BetragBudget),
         BgKostenartID     = MIN(SPT.BgKostenartID),
         BgSpezkontoID     = MIN(BPO.BgSpezkontoID),
         BgZahlungsmodusID = MIN(STZ.BgZahlungsmodusID),
         Dritte            = MIN(CASE WHEN BPO.BgKategorieCode = 1 THEN BPO.VerwaltungSD ELSE CONVERT(int, STZ.Dritte) END),
         Bemerkung         = MIN(CASE
                                   WHEN SPT.BgPositionsartCode = 60901 AND BPO.Reduktion != $0.00       THEN 'Quellensteuer: ' + LTrim(STR(BPO.Reduktion, 19, 2)) + ', Einkommen: ' + LTrim(STR(BPO.Betrag, 19, 2)) + ', '
                                   WHEN BPO.BgKategorieCode = 2                                         THEN IsNull('Rechnungsbetrag: ' + LTrim(STR(NullIf(BPO.BetragRechnung, BPO.BetragBudget), 19, 2)) + ', ', '')
                                   WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode <> 5  THEN IsNull(dbo.fnLOVText('BgBewilligungStatus', BPO.BgBewilligungStatusCode), '')
                                   ELSE IsNull(CONVERT(varchar(200), BPO.Value1) + ' ','')
                                 END
                                  + IsNull(CONVERT(varchar(8000), BPO.Bemerkung), '')),
         Abtretung   = MIN(CASE WHEN BPO.BgKategorieCode = 1 THEN BPO.VerwaltungSD ELSE 0 END )
  FROM dbo.vwBgPosition              BPO
    LEFT  JOIN dbo.AyPositionsart    SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    LEFT  JOIN dbo.BaPerson          PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BPO.BaPersonID
    INNER JOIN @BgPosition       STZ ON STZ.BgPositionID = BPO.BgPositionID
    LEFT  JOIN dbo.BgZahlungsmodus   SZM WITH (READUNCOMMITTED) ON SZM.BgZahlungsmodusID = STZ.BgZahlungsmodusID
    LEFT  JOIN dbo.BgSpezkonto       SPK WITH (READUNCOMMITTED) ON SPK.BgSpezkontoID = BPO.BgSpezkontoID
  WHERE BPO.BgBudgetID = @BgBudgetID
  GROUP BY BPO.BgPositionID, STZ.BgZahlungsmodusID

-- Einnahmen, Ausgaben, Kürzungen (Titel)
  INSERT INTO @Budget (Rec_ID, Style, SortKey, BgKategorieCode, Bezeichnung)
    SELECT TMP.BgKategorieCode * 4, 1, MAX(XLC.SortKey), TMP.BgKategorieCode, UPPER(MIN(XLC.text))
    FROM @Budget           TMP
      INNER JOIN dbo.XLOVCode  XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgKategorie' AND XLC.Code = TMP.BgKategorieCode
    GROUP BY TMP.BgKategorieCode


-- Einnahmen, Ausgaben, Kürzungen (Gruppe)
  INSERT INTO @Budget (Rec_ID, Parent_ID, Style, SortKey, BgKategorieCode, BgGruppeCode, Bezeichnung)
    SELECT
      Rec_ID      = MIN(CASE
                          WHEN TMP.BgKategorieCode IN (100, 101) THEN IsNull(IsNull(TMP.BgSpezkontoID * 2, TMP.BgGruppeCode * 2 + 1), 0)
                          ELSE TMP.BgGruppeCode * 4 + 1
                        END),
      Parent_ID   = TMP.BgKategorieCode * 4, 2,
      SortKey     = MIN(XLC.SortKey),
      TMP.BgKategorieCode,
      TMP.BgGruppeCode,
      Bezeichnung = MIN(CASE
                          WHEN TMP.BgKategorieCode IN (100, 101) THEN
                            IsNull(IsNull(
                              SKT.text + ': ' + SSK.NameSpezkonto,
                              'Zusätzliche Leistung: ' + XLC.text),
                              'Finanzierung durch Reduktion Grundbedarf')
                          ELSE XLC.text
                        END)
    FROM @Budget              TMP
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = TMP.BgGruppeCode
      LEFT  JOIN dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = TMP.BgSpezkontoID
      LEFT  JOIN dbo.XLOVCode     SKT WITH (READUNCOMMITTED) ON SKT.LOVName = 'BgSpezkontoTyp' AND SKT.Code = SSK.BgSpezkontoTypCode
    GROUP BY TMP.BgKategorieCode, TMP.BgGruppeCode

-- Einnahmen, Ausgaben, Kürzungen (Summen)
  INSERT INTO @Budget (Parent_ID, Style, SortKey, BgKategorieCode, Bezeichnung, Total)
    SELECT TMP.BgKategorieCode * 4, 2, 999998, TMP.BgKategorieCode, 'Total ' + MIN(XLC.text), SUM(TMP.Betrag)
    FROM @Budget           TMP
      INNER JOIN dbo.XLOVCode  XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgKategorie' AND XLC.Code = TMP.BgKategorieCode
    GROUP BY TMP.BgKategorieCode, XLC.text

  INSERT INTO @Budget (Parent_ID, Style, SortKey, BgKategorieCode, Bezeichnung)
    SELECT TMP.BgKategorieCode * 4, 2, 999999, TMP.BgKategorieCode, ''
    FROM @Budget           TMP
    GROUP BY TMP.BgKategorieCode


-- Übersicht
  DECLARE @BetragSumme money

  INSERT INTO @Budget (Rec_ID, SortKey, Style, Bezeichnung) VALUES (-1, 99, 1, 'ÜBERSICHT')
    INSERT INTO @Budget (Rec_ID, Parent_ID, SortKey, Style, Bezeichnung) VALUES (-10, -1, 1, 2, 'Leistungen der Asylkordinationsstelle')
      SET @BetragSumme = 0


      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 2
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID AND Dritte = 0)
        AND NOT EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID AND Dritte = 1)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 2, 3, 'Ausgaben, an Klient/in', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)


      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 2 AND BPO.BgSpezkontoID IS NULL
        AND EXISTS (SELECT * FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID AND Dritte = 1)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 3, 3, 'Ausgaben, an Dritte', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)


      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 2 AND BPO.BgSpezkontoID IS NOT NULL
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 4, 3, 'Ausgaben, Gutschrift auf Ausgabenkonto', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)


      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 4
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 5, 3, 'Abzüglich Kürzungen', IsNull(0 - @Betrag, 0))
      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)


      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 1
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 6, 3, 'Abzüglich Einkommen', IsNull(0 - @Betrag, 0))
      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)

      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 5
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-10, 6, 3, 'Einzelzahlungen', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Total) VALUES (-1, 8, 2, 'Total Leistungen', @BetragSumme)


    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung) VALUES (-1, 9, 2, '')
    INSERT INTO @Budget (Rec_ID, Parent_ID, SortKey, Style, Bezeichnung) VALUES (-20, -1, 10, 2, 'Zahlungen der Asylkordinationsstelle')
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-20, 1, 3, 'Total Leistungen', @BetragSumme)

      -- Spezkonti
      SELECT @Betrag = SUM(BPO.BetragRechnung)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgSpezkontoID IS NOT NULL
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag)
        SELECT Parent_ID   = -20, 
               SortKey     = MIN(XLC.Code) + 1, 
               Style       = 3, 
               Bezeichnung = 'Abzüge für ' + CASE 
                                               WHEN RIGHT(XLC.text, 2) = 'en' THEN XLC.text   -- handle z.B. 'Kürzungen' (see #5705)
                                               ELSE LEFT(XLC.text, LEN(XLC.text) - 1) + 'i'   -- handle 'Konto' as 'Konti'
                                             END, 
               Betrag      = ISNULL(SUM(-BPO.Betrag), 0)
        FROM dbo.XLOVCode        XLC WITH (READUNCOMMITTED) 
          LEFT  JOIN (SELECT SUM(BPO.BetragRechnung) AS Betrag, SSK.BgSpezkontoTypCode
                      FROM dbo.vwBgPosition         BPO
                        INNER JOIN dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
                      WHERE EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)
                      GROUP BY SSK.BgSpezkontoTypCode
                     ) BPO ON BPO.BgSpezkontoTypCode = XLC.Code
        WHERE XLC.LOVName = 'BgSpezkontoTyp'
        GROUP BY XLC.text

      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)


      -- Von SD verwaltete Einnahmen
      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 1 AND VerwaltungSD = 1
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-20, 16, 3, 'Von AK verwaltete Einnahmen', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)


      -- Zahlungen aus Vorabzugs-, Abzahlungs- und Ausgabekonti
      SELECT @Betrag = SUM(BPO.BetragBudget)
      FROM dbo.vwBgPosition            BPO
      WHERE BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NOT NULL
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-20, 17, 3, 'Zahlungen aus Vorabzugs-, Abzahlungs- und Ausgabekonti', IsNull(@Betrag, 0))
      SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0)

    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Total) VALUES (-1, 18, 2, 'Total Zahlungen', @BetragSumme)


    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung) VALUES (-1, 19, 2, '')
    INSERT INTO @Budget (Rec_ID, Parent_ID, SortKey, Style, Bezeichnung) VALUES (-30, -1, 20, 2, 'Zahlungen der Asylkordinationsstelle')
      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-30, 1, 3, 'Total Zahlungen', @BetragSumme)


      -- Zahlungen an Dritte 
      SELECT @Betrag = SUM(BPO.BetragRechnung)
      FROM dbo.vwBgPosition            BPO
      WHERE ((BPO.BgKategorieCode = 2 AND BPO.BgSpezkontoID IS NULL) OR (BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 5) OR BPO.BgKategorieCode = 101)
        AND EXISTS (SELECT 1 FROM @BgPosition WHERE BgPositionID = BPO.BgPositionID AND Dritte = 1)

      INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Betrag) VALUES (-30, 2, 3, 'Zahlungen an Dritte', IsNull(-@Betrag, 0))
      SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0)


    INSERT INTO @Budget (Parent_ID, SortKey, Style, Bezeichnung, Total) VALUES (-1, 20, 2, 'Total Zahlungen an Klient/in', @BetragSumme)


-- Output
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style,
    BgPositionID, BgKategorieCode, BgPositionsartID, BgGruppeCode,
    Bezeichnung, Betrag, Total, KOA, BgSpezkontoID, BgZahlungsmodusID, Dritte, Abtretung, Zahlungsmodus, Bemerkung)
  SELECT TMP.Rec_ID, TMP.Parent_ID, TMP.Style,
    TMP.BgPositionID, TMP.BgKategorieCode, TMP.BgPositionsartID, SPT.BgGruppeCode,
    Bezeichnung = CASE TMP.Style
                    WHEN 1 THEN ''
                    WHEN 2 THEN '  '
                    ELSE        '    '
                  END + TMP.Bezeichnung,
    TMP.Betrag, TMP.Total, KOA.KontoNr, TMP.BgSpezkontoID, TMP.BgZahlungsmodusID, TMP.Dritte, TMP.Abtretung,
    IsNull(SZM.NameZahlungsmodus + CASE WHEN TMP.Dritte = 1 THEN ' (Dritte)' ELSE ' (Klient/in)' END, 'Gutschrift für ' + SSK.NameSpezkonto), TMP.Bemerkung
  FROM @Budget                 TMP
    LEFT JOIN dbo.AyPositionsart   SPT ON SPT.BgPositionsartID  = TMP.BgPositionsartID
    LEFT JOIN dbo.BgZahlungsmodus  SZM WITH (READUNCOMMITTED) ON SZM.BgZahlungsmodusID = TMP.BgZahlungsmodusID
    LEFT JOIN dbo.BgSpezkonto      SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID     = TMP.BgSpezkontoID
    LEFT JOIN dbo.BgKostenart      KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID     = TMP.BgKostenartID
    LEFT JOIN @Budget          SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget          GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget          TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  RETURN
END

GO
