SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSGetKrankenkasseDaten;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Bestimmt für @FaLeistungID die per @DossierDatumBis (oder nächstfrühere) gültige
           Krankenkassendaten.
           Wird für Sostat-Fragen 9.01, 9.02, 9.04 und 9.05 verwendet

  RETURNS: 
=================================================================================================
  TEST: 
  SELECT * FROM dbo.fnBFSGetKrankenkasseDaten(123, GETDATE(), YEAR(GETDATE()));
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSGetKrankenkasseDaten
(
  @FaLeistungID    INT,
  @DossierDatumBis DATETIME,
  @Erhebungsjahr   INT
)
RETURNS @OutputResult TABLE 
(
  BaPersonID INT,
  KVGBetrag  MONEY, 
  KVGReduktion MONEY,
  KVGKasse   VARCHAR(200),
  VVGBetrag  MONEY
)
AS
BEGIN
  DECLARE @Tmp TABLE
  (
    ID          INT IDENTITY(1,1),
    BaPersonID  INT,
    Name        VARCHAR(100), -- für test
    KVGBetrag   MONEY,
    KVGReduktion MONEY,
    KVGKasse    VARCHAR(100),
    VVGBetrag   MONEY,
    DatumVon    DATETIME,
    DatumBis    DATETIME,
    MatchRank   INT
  );

  INSERT INTO @Tmp
  SELECT 
    PRS.BaPersonID,
    PRS.NameVorname,
    KVGBetrag       = (BPO.Betrag + IsNull(KVG.Betrag, $0.00)),
    KVGReduktion    = BPO.Reduktion,
    KVGKasse        = IKVG.Name,
    VVGBetrag       = IsNull(VVG.Betrag, $0.00),
    DatumVon        = ISNULL(BPO.DatumVon, FIP.DatumVon),
    DatumBis        = ISNULL(BPO.DatumBis, FIP.DatumBis),
    MatchRank       = NULL
  FROM dbo.BgFinanzplan                   FIP
    INNER JOIN dbo.vwBgPositionFinanzplan BPO ON BPO.BgFinanzplanID   = FIP.BgFinanzplanID
    INNER JOIN dbo.WhPositionsart         SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    LEFT  JOIN dbo.vwPerson               PRS ON PRS.BaPersonID       = BPO.BaPersonID
    LEFT JOIN (SELECT BPOI.Betrag, BPOI.BgBudgetID, BPOI.BgPositionID_Parent, POAI.BgPositionsartCode
               FROM dbo.BgPosition BPOI
                 INNER JOIN dbo.BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
               WHERE POAI.BgPositionsartCode IN (32021, 32022)) VVG ON VVG.BgBudgetID = BPO.BgBudgetID AND VVG.BgPositionID_Parent = BPO.BgPositionID
    LEFT JOIN (SELECT BPOI.Betrag, BPOI.BgBudgetID, BPOI.BgPositionID_Parent, POAI.BgPositionsartCode
               FROM dbo.BgPosition BPOI
                 INNER JOIN dbo.BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
               WHERE POAI.BgPositionsartCode IN (32023, 32024)) KVG ON KVG.BgBudgetID = BPO.BgBudgetID AND KVG.BgPositionID_Parent = BPO.BgPositionID
    LEFT  JOIN dbo.BaInstitution   IKVG ON IKVG.BaInstitutionID = BPO.BaInstitutionID
  WHERE FIP.BgFinanzplanID = dbo.fnBgGetCurrentOrPreviousFinanzplanID(@FaLeistungID, @DossierDatumBis)
    AND (SPT.BgPositionsartCode = 32020 OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130) -- KVG-Prämien
    AND YEAR(FIP.DatumVon) <= @Erhebungsjahr AND YEAR(FIP.DatumBis) >= @Erhebungsjahr - 1   -- Finanzplan muss zumindest teilweise im Erhebungsjahr sein. Wegen 6-Monatsregel wird auch DatumBis vom Vorjahr berücksichtigt 
  ORDER BY PRS.Name, PRS.Vorname, BPO.DatumVon

  UPDATE @Tmp
  SET MatchRank = CASE 
                    WHEN @DossierDatumBis BETWEEN DatumVon AND DatumBis THEN 1                        -- 1. Prio: FP umschliesst @DossierDatumBis
                    WHEN DatumBis < @DossierDatumBis THEN 2 + DATEDIFF(d, DatumBis, @DossierDatumBis) -- 2. Prio: FP vor @DossierDatumBis
                    ELSE 100000
                  END

  DELETE LOW
  FROM @Tmp HIGH
    INNER JOIN @Tmp LOW ON LOW.BaPersonID = HIGH.BaPersonID AND (LOW.MatchRank > HIGH.MatchRank
                                                                 OR LOW.MatchRank = HIGH.MatchRank AND LOW.ID > HIGH.ID) -- only 1 row per person
  INSERT INTO @OutputResult                         
  SELECT BaPersonID, KVGBetrag, KVGReduktion, KVGKasse, VVGBetrag
  FROM @Tmp;

  RETURN;

END;
GO