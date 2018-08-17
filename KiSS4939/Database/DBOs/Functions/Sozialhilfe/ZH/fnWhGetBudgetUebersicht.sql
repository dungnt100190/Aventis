SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhGetBudgetUebersicht;
GO
/*===============================================================================================
  Revision: 6
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
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetBudgetUebersicht
(
  @BgBudgetID INT,
  @GetDate    DATETIME
)
RETURNS
  @OUTPUT TABLE (
    Rec_ID            INT,
    Parent_ID         INT,
    SortKey           INT IDENTITY(1, 1) PRIMARY KEY,

    Style             INT,

    Bezeichnung       VARCHAR(500),
    Betrag            MONEY,
    Total             MONEY,
    Bemerkung         VARCHAR(4000)
  )
AS BEGIN
  DECLARE @BgBudget TABLE (
    Rec_ID            INT,
    Parent_ID         INT,
    SortKey           INT,

    Style             INT,

    BgPositionID      INT,
    BgKategorieCode   INT,
    BgGruppeCode      INT,
    BgPositionsartID  INT,
    BgAuszahlungID    INT,
    Bezeichnung       VARCHAR(500),
    Betrag            MONEY,
    BetragRechnung    MONEY,
    Total             MONEY,
    KOA               VARCHAR(10),
    BgSpezkontoID     INT,
    Dritte            BIT,
    Bemerkung         VARCHAR(4000)
  );

  INSERT INTO @BgBudget
    SELECT *
    FROM dbo.fnWhGetBudget(@BgBudgetID, @GetDate);


  DECLARE @Betrag      MONEY,
          @BetragSumme MONEY;

  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style, Bezeichnung) VALUES (-10, -1, 2, 'Leistungen des SoD');
  SET @BetragSumme = 0;

  SELECT @Betrag = SUM(Betrag) FROM @BgBudget WHERE BgKategorieCode = 2 AND BgAuszahlungID IS NOT NULL AND Dritte = 0;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-10, 3, 'Ausgaben, an Klient/in', IsNull(@Betrag, 0));
  SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0);

  SELECT @Betrag = SUM(Betrag) FROM @BgBudget WHERE BgKategorieCode = 2 AND BgAuszahlungID IS NOT NULL AND Dritte = 1;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-10, 3, 'Ausgaben, an Dritte', IsNull(@Betrag, 0));
  SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0);

  SELECT @Betrag = SUM(Betrag) FROM @BgBudget WHERE BgKategorieCode = 2 AND BgSpezkontoID IS NOT NULL;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-10, 3, 'Ausgaben, Gutschrift auf Ausgabenkonto', IsNull(@Betrag, 0));
  SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0);

  SELECT @Betrag = SUM(Betrag) FROM @BgBudget WHERE BgKategorieCode = 4;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-10, 3, 'Abzüglich Reduktionen', IsNull(0 - @Betrag, 0));
  SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0);

  SELECT @Betrag = SUM(Betrag) FROM @BgBudget WHERE BgKategorieCode = 1;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-10, 3, 'Abzüglich Einkommen', IsNull(0 - @Betrag, 0));
  SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0);

  SELECT @Betrag = SUM(Betrag) FROM @BgBudget WHERE BgKategorieCode = 100 AND Style = 85;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-10, 3, 'Zusätzliche Leistungen (nur bewilligte)', IsNull(@Betrag, 0));
  SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0);

  UPDATE @OUTPUT  SET Total = @BetragSumme WHERE Rec_ID = -10;

  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung) VALUES (-1, 2, '');
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style, Bezeichnung) VALUES (-20, -1, 2, 'Zahlungen des SoD');
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-20, 3, 'Total Leistungen', @BetragSumme);

  -- Spezkonti
  SELECT @Betrag = SUM(BetragRechnung) FROM @BgBudget WHERE BgKategorieCode IN (2, 3, 6) AND BgSpezkontoID IS NOT NULL
														 OR BgKategorieCode = 3 AND BgSpezkontoID IS NULL; --Auto-Verrechnung benötigt kein Spezialkonto

  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag)
    SELECT -20, 3, 'Abzüge für ' + LEFT(XLC.text, LEN(XLC.text) - 1) + 'i', IsNull(SUM(-BPO.BetragRechnung), 0)
    FROM dbo.XLOVCode        XLC WITH (READUNCOMMITTED)
      LEFT  JOIN (SELECT BetragRechnung = SUM(BetragRechnung), SSK.BgSpezkontoTypCode
                  FROM @BgBudget            TMP
                    INNER JOIN dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = TMP.BgSpezkontoID
                  WHERE TMP.BgKategorieCode IN (2, 3, 6)
                  GROUP BY SSK.BgSpezkontoTypCode
                  UNION ALL
                  SELECT BetragRechnung = SUM(BetragRechnung), BgSpezkontoTypCode = 3
                  FROM @BgBudget            TMP
                  WHERE TMP.BgKategorieCode = 3
                    AND TMP.BgSpezkontoID IS NULL
                  ) BPO ON BPO.BgSpezkontoTypCode = XLC.Code
    WHERE XLC.LOVName = 'BgSpezkontoTyp'
    GROUP BY XLC.text, XLC.SortKey
    ORDER BY XLC.SortKey;

  SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0);

  -- Von SD verwaltete Einnahmen
  SELECT @Betrag = SUM(BetragRechnung)
  FROM @BgBudget               TMP
    INNER JOIN dbo.BgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgPositionID = TMP.BgPositionID
  WHERE TMP.BgKategorieCode = 1 AND VerwaltungSD = 1;

  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style, Bezeichnung, Betrag) VALUES (-21, -20, 3, 'Von SoD verwaltete Einnahmen', IsNull(@Betrag, 0));
  SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0);

  -- Zahlungen aus Vorabzugs-, Abzahlungs- und Ausgabekonti
  SELECT @Betrag = SUM(BetragRechnung) FROM @BgBudget WHERE BgKategorieCode = 101 AND BgSpezkontoID IS NOT NULL;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-20, 3, 'Zahlungen aus Vorabzugs-, Verrechnungs- und Ausgabekonti', IsNull(@Betrag, 0));
  SET @BetragSumme = @BetragSumme + IsNull(@Betrag, 0);

  UPDATE @OUTPUT  SET Total = @BetragSumme WHERE Rec_ID = -20;


  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung) VALUES (-1, 2, '');
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style, Bezeichnung) VALUES (-30, -1, 2, 'Zahlungen des SoD an Klient/in');
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-30, 3, 'Total Zahlungen', @BetragSumme);

  -- Zahlungen an Dritte (Ausgaben, Einzelzahlung)
  SELECT @Betrag = SUM(BetragRechnung) FROM @BgBudget WHERE BgKategorieCode IN (2, 100, 101) AND Dritte = 1;
  INSERT INTO @OUTPUT (Parent_ID, Style, Bezeichnung, Betrag) VALUES (-30, 3, 'Zahlungen an Dritte', IsNull(-@Betrag, 0));
  SET @BetragSumme = @BetragSumme - IsNull(@Betrag, 0);

  UPDATE @OUTPUT  SET Total = @BetragSumme WHERE Rec_ID = -30;

  RETURN;
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
