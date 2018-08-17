SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhGetBudgetML;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetBudgetML.sql $
  $Author: Tabegglen $
  $Modtime: 18.08.10 13:44 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: fnWhGetBudget für Mehrsprachigkeit
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetBudgetML.sql $
 * 
 * 4     18.08.10 13:51 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode
 * 
 * 3     5.08.10 7:40 Cjaeggi
 * #4167: Fixed after renaming InstitutionName
 * 
 * 2     25.08.09 15:20 Nweber
 * 
 * 1     25.08.09 14:59 Nweber
 * #4932: Fehlende Funktionen
 * 
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetBudgetML
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
AS BEGIN
  DECLARE @SprachCode INT
  SELECT @SprachCode = P.VerstaendigungSprachCode
  FROM BgBudget B
    LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
    LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
    LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
    LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
  WHERE B.BgBudgetID = @BgBudgetID
  IF @SprachCode IS NULL SET @SprachCode = 1

  DECLARE @Text_Dritte varchar(200)
  SELECT @Text_Dritte = dbo.fnGetMLTextFromName('Report_Budget', 'Dritte', @SprachCode)


  DECLARE @Budget TABLE (
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
  FROM BgBudget              BBG
    INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID


  -- BgPositionen
  INSERT INTO @Budget (Style, Parent_ID, BgPositionID, BgAuszahlungPersonID, BgKategorieCode, BgGruppeCode, BgPositionsartID, BgPositionsartCode, BgKostenartID,
                       Bezeichnung, BetragBudget, BetragRechnung, BgSpezkontoID, Dritte, Faktor, Info)
    SELECT
      Style = CASE
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
                              FROM BgFinanzplan            FP
                                INNER JOIN dbo.BgPositionsart  PA WITH (READUNCOMMITTED) ON PA.BgPositionsartCode = FP.WhGrundbedarfTypCode AND
                                                                       ISNULL(PA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
                                                                       ISNULL(PA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))                                
                              WHERE FP.BgFinanzplanID = @BgFinanzplanID)
        ELSE BPA.BgKostenartID
      END,
      CAST(COALESCE(BPO.Buchungstext, BPA.Name, BSK.NameSpezkonto) AS varchar(100)) + IsNull(' (' + BPR.NameVorname + ')', ''),
      BPO.BetragBudget, BPO.BetragRechnung, BPO.BgSpezkontoID,
      Dritte    = CASE WHEN BAP.KbAuszahlungsArtCode <> 103
                        AND NOT EXISTS(SELECT *
                                       FROM BgFinanzplan_BaPerson
                                       WHERE BgFinanzplanID = @BgFinanzplanID
                                         AND IstUnterstuetzt = 1 AND BaPersonID = BZW.BaPersonID)
                       THEN 1 ELSE 0 END,
      Faktor = CASE
        WHEN BPO.BaPersonID IS NOT NULL THEN 1
        WHEN BAP.BaPersonID IS NULL     THEN 1
                    ELSE
                      (SELECT CONVERT(real, 1) / COUNT(*)
                       FROM BgFinanzplan_BaPerson
                       WHERE BgFinanzplanID = @BgFinanzplanID
                         AND IstUnterstuetzt = 1)
      END,
      Info = CASE WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode <> 5
               THEN IsNull(dbo.fnLOVMLText('BgBewilligungStatus', BPO.BgBewilligungStatusCode, @SprachCode) + '; ', '')
               ELSE ''
             END
           + CASE
               WHEN BPO.BgKategorieCode = 1 THEN COALESCE(PRS.NameVorname, INS.Name)
               WHEN BPO.BgKategorieCode IN (2, 100, 101) THEN COALESCE(
                 PRS.NameVorname,
                 INS.Name,
                 dbo.fnLOVMLText('KbAuszahlungsart', BAP.KbAuszahlungsArtCode, @SprachCode),
                 BSK.NameSpezkonto)
        ELSE NULL
      END
    FROM vwBgPosition            BPO
      LEFT  JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
      LEFT  JOIN vwPerson        BPR ON BPR.BaPersonID = BPO.BaPersonID
      LEFT  JOIN BgPosition      BP2 ON BP2.BgPositionID = BPO.BgPositionID_CopyOf
      LEFT  JOIN BgPosition      BP3 ON BP3.BgPositionID = BP2.BgPositionID_CopyOf

      LEFT  JOIN BgAuszahlungPerson BAP ON BAP.BgPositionID = BPO.BgPositionID
                                       AND (BPO.BaPersonID IS NULL OR BAP.BaPersonID IS NULL OR BAP.BaPersonID = BPO.BaPersonID)
      LEFT  JOIN BaZahlungsweg      BZW ON BZW.BaZahlungswegID = BAP.BaZahlungswegID
      LEFT  JOIN vwPerson           PRS ON PRS.BaPersonID      = BPO.BaPersonID
      LEFT  JOIN vwInstitution      INS ON INS.BaInstitutionID = CASE WHEN BPO.BgKategorieCode = 1 THEN BPO.BaInstitutionID   ELSE BZW.BaInstitutionID END
      LEFT  JOIN BgSpezkonto        BSK ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
      INNER JOIN dbo.BgBudget       BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND CASE
            WHEN BPO.BgKategorieCode = 5           THEN 0   -- Vermögen
            WHEN BPA.BgGruppeCode IN (3202, 3206)  THEN     -- KVG, VVG, Miete
              CASE WHEN BPO.DatumBis IS NULL THEN 1 ELSE 0 END
            ELSE
              CASE WHEN @RefDate BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, '20790606') THEN 1 ELSE 0 END
          END = 1
      AND (BPO.BetragBudget > $0.00 OR BP2.Betrag > $0.00 OR BP3.Betrag > $0.00
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
    SELECT XLC.Code, 1, XLC.Code,
      UPPER( dbo.fnLOVMLText('BgKategorie', XLC.Code, @SprachCode) ),
      (SELECT SUM(BetragBudget) FROM @Budget WHERE BgKategorieCode = XLC.Code)
    FROM XLOVCode XLC
    WHERE XLC.LOVName = 'BgKategorie'
      AND EXISTS (SELECT * FROM @Budget  TMP WHERE BgKategorieCode = XLC.Code)
    ORDER BY SortKey

  -- Gruppen
  INSERT INTO @Budget (Rec_ID, Parent_ID, Style, BgKategorieCode, BgGruppeCode, Bezeichnung, Total)
    SELECT
      MAX(BgKategorieCode + (BgGruppeCode * 1024)),
      TMP.BgKategorieCode, 2, TMP.BgKategorieCode, TMP.BgGruppeCode,
      MAX(dbo.fnLOVMLText('BgGruppe', TMP.BgGruppeCode, @SprachCode)),
      Total = (SELECT SUM(BetragBudget)
               FROM @Budget
               WHERE BgKategorieCode = TMP.BgKategorieCode
                 AND BgGruppeCode = TMP.BgGruppeCode)
    FROM @Budget TMP
      INNER JOIN XLOVCode  BBG ON BBG.LOVName = 'BgGruppe' AND BBG.Code = TMP.BgGruppeCode
    GROUP BY BgKategorieCode, BgGruppeCode, BBG.SortKey
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
    TMP.Info + CASE WHEN TMP.Dritte = 1 THEN ' '+@Text_Dritte ELSE '' END
  FROM @Budget                 TMP
    LEFT JOIN BgPositionsart   BPA ON BPA.BgPositionsartID  = TMP.BgPositionsartID
    LEFT JOIN BgSpezkonto      SSK ON SSK.BgSpezkontoID     = TMP.BgSpezkontoID
    LEFT JOIN BgKostenart      BKA ON BKA.BgKostenartID     = TMP.BgKostenartID
    LEFT JOIN @Budget          SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget          GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget          TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  RETURN
END
GO
 