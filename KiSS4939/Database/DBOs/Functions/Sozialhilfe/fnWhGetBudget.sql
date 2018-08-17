SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhGetBudget;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetBudget.sql $
  $Author: Tabegglen $
  $Modtime: 18.08.10 13:03 $
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
  $Log: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetBudget.sql $
 * 
 * 4     18.08.10 13:51 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode
 * 
 * 3     5.08.10 7:40 Cjaeggi
 * #4167: Fixed after renaming InstitutionName
 * 
 * 2     25.06.09 8:17 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetBudget
(
  @BgBudgetID INT,
  @GetDate DATETIME
)
RETURNS @OUTPUT TABLE 
(
  Rec_ID INT,
  Parent_ID INT,
  SortKey INT IDENTITY(1, 1) PRIMARY KEY,
  Style INT,
  BgPositionID INT,
  BgKategorieCode INT,
  BgGruppeCode INT,
  BgPositionsartID INT,
  BgAuszahlungPersonID INT,
  Bezeichnung VARCHAR(500),
  Betrag MONEY,
  BetragRechnung MONEY,
  Total MONEY,
  KOA VARCHAR(10),
  BgSpezkontoID INT,
  Dritte BIT,
  Bemerkung VARCHAR(4000)
)
AS 
BEGIN
  DECLARE @Budget TABLE 
  (
    PKey                 int IDENTITY(1, 1) PRIMARY KEY,

    Rec_ID               int,
    Parent_ID            int,
    SortKey              int,

    Style                int,

    BgPositionID         int,
    BgKategorieCode      int,
    BgGruppeCode         int,
    BgPositionsartID     int,
    BgPositionsartCode   int,
    BgAuszahlungPersonID int,
    BgKostenartID        int,

    Bezeichnung          varchar(500),
    BetragBudget         money,
    BetragRechnung       money,
    Total                money,
    BgSpezkontoID        int,
    Dritte               bit,
    Faktor               real,
    Info                 varchar(4000)
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


  -- BgPositionen
  INSERT INTO @Budget (Style, Parent_ID, BgPositionID, BgAuszahlungPersonID, BgKategorieCode, BgGruppeCode, BgPositionsartID, BgPositionsartCode, BgKostenartID,
                       Bezeichnung, BetragBudget, BetragRechnung, BgSpezkontoID, Dritte, Faktor, Info)
    SELECT
      Style             = CASE
                            WHEN BPO.BgKategorieCode = 1   AND BPO.VerwaltungSD = 1             THEN 12
                            WHEN BPO.BgKategorieCode = 2   AND BPO.BgSpezkontoID IS NOT NULL    THEN 23
                            WHEN BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NULL        THEN 81
                            WHEN BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NOT NULL    THEN 82
                            WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 1  THEN 83
                            WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 3  THEN 84
                            WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 5  THEN 85
                            ELSE BPO.BgKategorieCode * 10 + 1
                          END,
      BPO.BgKategorieCode + IsNull(BPA.BgGruppeCode * 1024, 0),
      BPO.BgPositionID, BAP.BgAuszahlungPersonID,
      BPO.BgKategorieCode, BgGruppeCode, BPO.BgPositionsartID, BPA.BgPositionsartCode,
      BgKostenartID     = CASE
                            WHEN BSK.BgSpezkontoID IS NOT NULL  THEN BSK.BgKostenartID
                            WHEN BPO.BgKategorieCode = 101      THEN (
                              SELECT BgKostenartID
                              FROM dbo.BgFinanzplan            FP WITH (READUNCOMMITTED) 
                                INNER JOIN dbo.BgPositionsart  PA WITH (READUNCOMMITTED) ON PA.BgPositionsartCode = FP.WhGrundbedarfTypCode AND
                                                                       ISNULL(PA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
                                                                       ISNULL(PA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))                                
                              WHERE FP.BgFinanzplanID = @BgFinanzplanID)
                            ELSE BPA.BgKostenartID
                          END,
      CAST(COALESCE(BPO.Buchungstext, BPA.Name, BSK.NameSpezkonto) AS varchar(100)) + IsNull(' (' + BPR.NameVorname + ')', ''),
      BPO.BetragBudget, BPO.BetragRechnung, BPO.BgSpezkontoID,
      Dritte    = CASE
                    WHEN BPO.BgKategorieCode = 1 THEN BPO.VerwaltungSD
                    WHEN BZW.BaPersonID IS NULL AND BAP.KbAuszahlungsArtCode = 103 THEN 0 -- Cash / Barauszahlung
                    WHEN BZW.BaPersonID IS NULL AND BAP.KbAuszahlungsArtCode = 104 THEN 0 -- Check
                    WHEN NOT EXISTS(SELECT 1
                                    FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                                    WHERE BgFinanzplanID = @BgFinanzplanID
                                      AND IstUnterstuetzt = 1 AND BaPersonID = BZW.BaPersonID)
                      THEN 1
                    ELSE 0
                  END,
      Faktor    = CASE
                    WHEN BPO.BaPersonID IS NOT NULL THEN 1
                    WHEN BAP.BaPersonID IS NULL     THEN 1
                    ELSE
                      (SELECT CONVERT(real, 1) / COUNT(*)
                       FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                       WHERE BgFinanzplanID = @BgFinanzplanID
                         AND IstUnterstuetzt = 1)
                  END,
      Info      = CASE WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode <> 5
                    THEN IsNull(dbo.fnLOVText('BgBewilligungStatus', BPO.BgBewilligungStatusCode) + '; ', '')
                    ELSE ''
                  END
                + CASE
                    WHEN BPO.BgKategorieCode = 1              THEN COALESCE(PRS.NameVorname, INS.Name)
                    WHEN BPO.BgKategorieCode IN (2, 100, 101) THEN COALESCE(PRS.NameVorname, INS.Name, BZA.Text, BSK.NameSpezkonto)
                    ELSE NULL
                  END
    FROM dbo.vwBgPosition            BPO
      LEFT  JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
      LEFT  JOIN dbo.XLOVCode        BBG WITH (READUNCOMMITTED) ON BBG.LOVName = 'BgGruppe' AND BBG.Code = BPA.BgGruppeCode
      LEFT  JOIN dbo.vwPerson        BPR ON BPR.BaPersonID = BPO.BaPersonID
      LEFT  JOIN dbo.BgPosition      BP2 WITH (READUNCOMMITTED) ON BP2.BgPositionID = BPO.BgPositionID_CopyOf
      LEFT  JOIN dbo.BgPosition      BP3 WITH (READUNCOMMITTED) ON BP3.BgPositionID = BP2.BgPositionID_CopyOf

      LEFT  JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID
                                      AND (BPO.BaPersonID IS NULL OR BAP.BaPersonID IS NULL OR BAP.BaPersonID = BPO.BaPersonID)
      LEFT  JOIN dbo.XLOVCode           BZA WITH (READUNCOMMITTED) ON BZA.LOVName = 'KbAuszahlungsart' AND BZA.Code = BAP.KbAuszahlungsArtCode
      LEFT  JOIN dbo.BaZahlungsweg      BZW WITH (READUNCOMMITTED) ON BZW.BaZahlungswegID = BAP.BaZahlungswegID
      LEFT  JOIN dbo.vwPerson           PRS ON PRS.BaPersonID      = BPO.BaPersonID
      LEFT  JOIN dbo.vwInstitution      INS ON INS.BaInstitutionID = CASE WHEN BPO.BgKategorieCode = 1 THEN BPO.BaInstitutionID   ELSE BZW.BaInstitutionID END
      LEFT  JOIN dbo.BgSpezkonto        BSK WITH (READUNCOMMITTED) ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
      INNER JOIN dbo.BgBudget           BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND CASE
            WHEN BPO.BgKategorieCode = 5           THEN 0   -- Vermögen
            WHEN BPA.BgGruppeCode IN (3202, 3206)  THEN     -- KVG, VVG, Miete
              CASE WHEN BPO.DatumBis IS NULL THEN 1 ELSE 0 END
            ELSE
              CASE WHEN @RefDate BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, '20790606') THEN 1 ELSE 0 END
          END = 1
      AND (BPO.BetragBudget > $0.00 OR BP2.Betrag > $0.00 OR BP3.Betrag > $0.00 
            OR (BPO.BgKategorieCode = 1 AND (BPO.BetragBudget <> $0.00 OR BP2.Betrag <> $0.00 OR BP3.Betrag <> $0.00)) /* #8343 Negative Einnahmen auch berücksichtigen  */
            OR BPA.BgPositionsartCode IN (39900, 39910) /* Sanktionen immer anzeigen */
            OR BPO.BgKategorieCode IN (100, 101)
          )

  UPDATE @Budget
    SET BetragBudget   = BetragBudget   * Faktor,
        BetragRechnung = BetragRechnung * Faktor
  WHERE Faktor < 1


  -- SKOS2005
  DECLARE @Limit money, @SumZulage money

  SELECT @SumZulage = SUM(BPO.BetragBudget)
  FROM @Budget  BPO
  WHERE BPO.BgKategorieCode = 2 AND BPO.BgPositionsartCode BETWEEN 39000 AND 39999

  IF @SumZulage > $0.00 BEGIN
    SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
    FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
    WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KNZ)
    ORDER BY CFG.Child DESC

    IF @SumZulage > @Limit
      UPDATE @Budget
        SET BetragBudget   = BetragBudget * @Limit / @SumZulage,
            BetragRechnung = BetragRechnung * @Limit / @SumZulage
      WHERE BgKategorieCode = 2 AND BgPositionsartCode BETWEEN 39000 AND 39999
  END


  -- Kategorien
  INSERT INTO @Budget (Rec_ID, Style, BgKategorieCode, Bezeichnung, Total)
    SELECT Code, 1, Code, UPPER(Text), (SELECT SUM(BetragBudget) FROM @Budget WHERE BgKategorieCode = XLC.Code)
    FROM dbo.XLOVCode    XLC WITH (READUNCOMMITTED) 
    WHERE LOVName = 'BgKategorie'
      AND EXISTS (SELECT 1 FROM @Budget  TMP WHERE BgKategorieCode = XLC.Code)
    ORDER BY SortKey

  -- Gruppen
  INSERT INTO @Budget (Rec_ID, Parent_ID, Style, BgKategorieCode, BgGruppeCode, Bezeichnung, Total)
    SELECT MAX(BgKategorieCode + (BgGruppeCode * 1024)), BgKategorieCode, 2, BgKategorieCode, BgGruppeCode, BBG.Text,
      Total = (SELECT SUM(BetragBudget) FROM @Budget WHERE BgKategorieCode = TMP.BgKategorieCode AND BgGruppeCode = TMP.BgGruppeCode)
    FROM @Budget           TMP
      INNER JOIN dbo.XLOVCode  BBG WITH (READUNCOMMITTED) ON BBG.LOVName = 'BgGruppe' AND BBG.Code = TMP.BgGruppeCode
    GROUP BY BgKategorieCode, BgGruppeCode, BBG.Text, BBG.SortKey
    ORDER BY BBG.SortKey

-- Output
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style,
    BgPositionID, BgAuszahlungPersonID, BgKategorieCode, BgPositionsartID, BgGruppeCode,
    Bezeichnung, Betrag, BetragRechnung, Total, KOA, BgSpezkontoID, Dritte, Bemerkung)
  SELECT TMP.Rec_ID, TMP.Parent_ID,
    Style = CASE WHEN TMP.Style = 21 AND TMP.Dritte = 1 THEN 22 ELSE TMP.Style END,
    TMP.BgPositionID, TMP.BgAuszahlungPersonID, TMP.BgKategorieCode, TMP.BgPositionsartID, BPA.BgGruppeCode,
    Bezeichnung = CASE TMP.Style WHEN 1 THEN '' WHEN 2 THEN '  ' ELSE '    ' END + TMP.Bezeichnung,
    TMP.BetragBudget, TMP.BetragRechnung, TMP.Total,
    BKA.KontoNr,
    TMP.BgSpezkontoID, TMP.Dritte,
    TMP.Info + CASE WHEN TMP.Dritte = 1 THEN ' (Dritte)' ELSE '' END
  FROM @Budget                 TMP
    LEFT JOIN dbo.BgPositionsart   BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID  = TMP.BgPositionsartID
    LEFT JOIN dbo.BgSpezkonto      SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID     = TMP.BgSpezkontoID
    LEFT JOIN dbo.BgKostenart      BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID     = TMP.BgKostenartID
    LEFT JOIN @Budget          SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget          GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget          TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  RETURN
END
GO