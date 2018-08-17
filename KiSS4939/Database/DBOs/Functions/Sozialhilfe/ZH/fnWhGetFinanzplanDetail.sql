SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhGetFinanzplanDetail
GO
/*===============================================================================================
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
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetFinanzplanDetail
(
  @BgBudgetID      int,
  @GetDate         datetime
)
RETURNS
  @OUTPUT TABLE (
    Rec_ID            int,
    Parent_ID         int,
    SortKey           int IDENTITY(1, 1) PRIMARY KEY,

    Style             int,

    BgKategorieCode   int,
    BgGruppeCode      int,

    KontoNr			  varchar(10),
    Buchungstext       varchar(500),
    Betrag            money,
    Total             money,

    Info              varchar(4000)
  )
AS
BEGIN
  DECLARE @Budget TABLE (
    PKey              int IDENTITY(1, 1) PRIMARY KEY,

    Rec_ID            int,
    Parent_ID         int,
    SortKey           int,

    Style             int,

    BgKategorieCode   int,
    BgGruppeCode      int,
    KontoNr			  varchar(10),
    Buchungstext      varchar(500),
    Betrag            money,
    Total             money,

    Info              varchar(4000)
  )

  SELECT @GetDate = CASE WHEN BBG.MasterBudget = 1
                      THEN dbo.fnDateOf(CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(@GetDate, IsNull(BFP.DatumVon, BFP.GeplantVon)), IsNull(BFP.DatumBis, BFP.GeplantBis))))
                      ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                    END
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID

  DECLARE @WhPositionsart TABLE (
    BgPositionsartID  int PRIMARY KEY,
	BgKostenartID     int,
    BgKategorieCode   int,
    BgGruppeCode      int,
    BgGruppeCode2     int
  )

  INSERT INTO @WhPositionsart
  SELECT BgPositionsartID, BgKostenartID, BgKategorieCode, BgGruppeCode, CASE WHEN BgGruppeCode BETWEEN 39000 AND 39999 THEN 39000 ELSE BgGruppeCode END
  FROM dbo.WhPositionsart WITH (READUNCOMMITTED)
  WHERE BgKategorieCode IN (1, 2, 4) AND
		SpezHauptvorgang IS NULL AND SpezTeilvorgang IS NULL -- Filtere die Spezial-Positionsarten (Multifunktionales Vorzeichen)

  -- BgPositionen
  INSERT INTO @Budget (Style, Parent_ID, BgKategorieCode, BgGruppeCode, KontoNr, Buchungstext, Betrag, SortKey, Info)
  SELECT 10,
         BPA.BgKategorieCode,
         BPA.BgKategorieCode,
         BPA.BgGruppeCode2,
         BKA.KontoNr,
         BPO.Buchungstext,
         IsNull(SUM(BPO.BetragFinanzplan), $0.00),
         BGG.SortKey,
         Info = '' -- TODO
  FROM @WhPositionsart         BPA
       INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = @BgBudgetID
       INNER JOIN dbo.XLOVCode      BGG WITH (READUNCOMMITTED) ON BGG.LOVName = 'BgGruppe' AND BGG.Code = BPA.BgGruppeCode2
       LEFT  JOIN dbo.vwBgPosition  BPO ON BPO.BgPositionsartID = BPA.BgPositionsartID AND BPO.BgBudgetID = @BgBudgetID
	                            AND (BBG.BgBewilligungStatusCode = 1 OR IsNull(BPO.FPPosition,0) = 1)
       INNER JOIN dbo.BgKostenart   BKA WITH (READUNCOMMITTED) on BKA.BgKostenartID = BPA.BgKostenartID
  WHERE (BPA.BgKategorieCode IN (1, 2) OR (BPA.BgKategorieCode = 4 AND BPO.BetragFinanzplan > 0))
  AND BKA.KontoNr NOT in (830, 831) -- ohne VU Fall und VU Person
  AND (BPO.BgPositionID IS NULL OR
			(BPO.BgBewilligungStatusCode IN (1,3,5) AND -- Vorbereitet, Bewilligung angefragt, Bewilligung erteilt
			CASE
				WHEN BPO.BgKategorieCode = 5           THEN 0   -- Vermögen
			ELSE
				CASE WHEN @GetDate BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, '20790606') THEN 1 ELSE 0 END
			END = 1))
  GROUP BY BKA.KontoNr, BBG.BgBewilligungStatusCode, BPA.BgKategorieCode, BPA.BgGruppeCode2, BPO.Buchungstext, BGG.SortKey

  -- Kategorien
  INSERT INTO @Budget (Rec_ID, Style, BgKategorieCode, Buchungstext, Total, SortKey)
    SELECT Code, 1, Code, UPPER(Text), (SELECT SUM(Betrag) FROM @Budget WHERE BgKategorieCode = Code), SortKey
    FROM dbo.XLOVCode WITH (READUNCOMMITTED)
    WHERE LOVName = 'BgKategorie'
      AND EXISTS (SELECT * FROM @Budget WHERE BgKategorieCode = Code)
    ORDER BY SortKey

  -- Output
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style,
    BgKategorieCode, BgGruppeCode,
    KontoNr, Buchungstext, Betrag, Total, Info)
  SELECT TMP.Rec_ID, TMP.Parent_ID, TMP.Style,
    TMP.BgKategorieCode, TMP.BgGruppeCode,
    TMP.KontoNr,
	Buchungstext = CASE TMP.Style
                    WHEN 1 THEN ''
                    WHEN 2 THEN '  '
                    ELSE        '    '
                  END + TMP.Buchungstext,
    TMP.Betrag, TMP.Total,
    SubString(TMP.Info, 3, 8000)
  FROM @Budget                 TMP
    LEFT JOIN @Budget          SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget          GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget          TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
  WHERE TMP.BgGruppeCode IS NULL OR TMP.BgGruppeCode NOT IN (3901, 3902)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  INSERT INTO @OUTPUT (Style, Buchungstext) VALUES (1, '')
  INSERT INTO @OUTPUT (Style, Buchungstext) VALUES (1, 'Fehlbeträge')
  INSERT INTO @OUTPUT (Style, Buchungstext, Betrag)
    SELECT 10, '   Fehlbetrag exkl. Zulagen',
      Betrag = (SELECT SUM(CASE
                             WHEN BgKategorieCode = 1 THEN -Betrag
                             WHEN BgKategorieCode = 2 THEN Betrag
                             WHEN BgKategorieCode = 4 THEN -Betrag
                             ELSE $0.00
                           END)
                FROM @Budget
                WHERE Style = 10 AND BgGruppeCode NOT BETWEEN 39000 AND 39999)
  INSERT INTO @OUTPUT (Style, Buchungstext, Betrag)
    SELECT 1, ' Fehlbetrag inkl. Zulagen',
      Betrag = (SELECT SUM(CASE
                             WHEN BgKategorieCode = 1 THEN -Betrag
                             WHEN BgKategorieCode = 2 THEN Betrag
                             WHEN BgKategorieCode = 4 THEN -Betrag
                             ELSE $0.00
                           END)
                FROM @Budget
                WHERE Style = 10)
  RETURN
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
