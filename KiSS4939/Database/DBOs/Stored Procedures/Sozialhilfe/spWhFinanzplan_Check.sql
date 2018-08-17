SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Check
GO
/*===============================================================================================
  $Revision: 25 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: Tabelle mit den Fehlern und Warnungen
           Spalte0 (Typ):
             - 0: Fehler, der behoben werden muss. Sonst kann FP nicht freigegeben werden.
             - 1: Kompetenz: Fehlende Konpetenz um den FP zu bewilligen
             - 2: Warnungen. Der Finanpzlan kann trotz diesen Warnungen freigegeben werden.
           Spalte1: Fehlermeldung oder Warnung
  -
  TEST:    .
=================================================================================================*/
CREATE PROCEDURE dbo.spWhFinanzplan_Check
(
  @BgFinanzplanID  INT,
  @UserID          INT
)
AS 
BEGIN
  DECLARE @RefDate           DATETIME,
          @RefDateTo         DATETIME,
          @BgBudgetID        INT,
          @PermissionGroupID INT,
          @WhHilfeTypCode    INT,
          @FaLeistungID      INT;

  SELECT
    @BgBudgetID        = BgBudgetID,
    @RefDate           = ISNULL(SFP.DatumVon, SFP.GeplantVon),
    @RefDateTo         = ISNULL(SFP.DatumBis, SFP.GeplantBis),
    -- Eigenkompetenz (eigener FP) oder Fremdkompetenz
    @PermissionGroupID = CASE WHEN FAL.UserID = @UserID
                           THEN USR.PermissionGroupID
                           ELSE USR.GrantPermGroupID
                         END,
    @WhHilfeTypCode    = SFP.WhHilfeTypCode,
    @FaLeistungID      = SFP.FaLeistungID
  FROM dbo.BgFinanzplan       SFP WITH (READUNCOMMITTED)
    LEFT  JOIN dbo.BgBudget   BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
    INNER JOIN dbo.FaLeistung FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = SFP.FaLeistungID
    INNER JOIN dbo.XUser      USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID
  WHERE SFP.BgFinanzplanID = @BgFinanzplanID;

  DECLARE @Permission TABLE (
    PermissionCode INT PRIMARY KEY,
    Value          SQL_VARIANT);

  INSERT INTO @Permission
    SELECT PermissionCode, Value
    FROM dbo.XPermissionValue WITH (READUNCOMMITTED)
    WHERE PermissionGroupID = @PermissionGroupID 
      AND PermissionCode IS NOT NULL;

  DECLARE @WhGrundbedarfTyp INT;
  SELECT @WhGrundbedarfTyp = BPO.BgPositionsartID
  FROM dbo.BgPosition             BPO WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN dbo.XLOVCode       XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = SPT.BgPositionsartCode
  WHERE BPO.BgBudgetID = @BgBudgetID


  DECLARE @SumAusgabenStd MONEY,
          @SumAusgabenSil MONEY;

  SELECT @SumAusgabenStd = SUM(BPO.BetragFinanzplan)
  FROM dbo.vwBgPosition BPO 
  INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  WHERE BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 AND SPT.BgGruppeCode != 99
    AND ( (BPO.DatumVon IS NULL  AND SPT.BgPositionsartCode NOT IN (32020, 32021) AND SPT.BgPositionsartCode NOT BETWEEN 32121 AND 32130 AND SPT.BgPositionsartCode NOT BETWEEN 60 AND 99) OR
          ((SPT.BgPositionsartCode IN (32020, 32021) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130 OR SPT.BgPositionsartCode BETWEEN 60 AND 99)
             AND GETDATE() BETWEEN ISNULL(BPO.DatumVon, '19000101') AND ISNULL(BPO.DatumBis, GETDATE()))
        );

  -- SKOS 2005 Limite Zulagen
  IF @WhGrundbedarfTyp = 32015 
  BEGIN
    DECLARE @Limit MONEY, 
            @SumZulage MONEY;

    SELECT TOP 1 @Limit = CONVERT(MONEY, CFG.ValueVar)
    FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
    WHERE CONVERT(INT, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KNZ)
    ORDER BY CFG.Child DESC

    SELECT @SumZulage = SUM(BPO.BetragFinanzplan)
    FROM vwBgPosition BPO 
    INNER JOIN WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 AND SPT.BgPositionsartCode BETWEEN 39000 AND 39999 AND SPT.BgGruppeCode != 99
      AND ( (BPO.DatumVon IS NULL  AND SPT.BgPositionsartCode NOT IN (32020, 32021) AND SPT.BgPositionsartCode NOT BETWEEN 32121 AND 32130 AND SPT.BgPositionsartCode NOT BETWEEN 60 AND 99) OR
            ((SPT.BgPositionsartCode IN (32020, 32021) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130 OR SPT.BgPositionsartCode BETWEEN 60 AND 99)
               AND GETDATE() BETWEEN ISNULL(BPO.DatumVon, '19000101') AND ISNULL(BPO.DatumBis, GETDATE()))
          );

    IF @SumZulage > @Limit
    BEGIN
      SET @SumAusgabenStd = @SumAusgabenStd - @SumZulage + @Limit;
    END;
  END;

  SELECT @SumAusgabenSil = SUM(BPO.BetragFinanzplan)
  FROM dbo.vwBgPosition           BPO
    INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  WHERE BPO.BgBudgetID = @BgBudgetID
   AND BPO.BgKategorieCode = 2
   AND SPT.BgGruppeCode BETWEEN 3901 AND 3905
   AND ISNULL(BPO.DatumVon, @RefDate) BETWEEN @RefDate AND @RefDateTo;

    SELECT Typ = 0 , 'Es wird keine Person unterstützt'
    WHERE NOT EXISTS (SELECT TOP 1 1 
                      FROM BgFinanzplan_BaPerson 
                      WHERE BgFinanzplanID = @BgFinanzplanID 
                        AND IstUnterstuetzt = 1)
                        
  UNION ALL
    SELECT Typ = 0, PRS.NameVorname + ': Geburtsdatum'
    FROM BgFinanzplan_BaPerson SPP INNER JOIN vwPerson PRS ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SPP.BgFinanzplanID = @BgFinanzplanID 
      AND PRS.Geburtsdatum IS NULL
      
  UNION ALL
    SELECT Typ = CASE WHEN ISNULL(dbo.fnXConfig('System\Sozialhilfe\FinanzPlan\Check_PersonIn2FpUnterstuetzt', @RefDate), 1) = 1 
                   THEN 0 
                   ELSE 2 
                 END,
           PRS.NameVorname + ': bereits unterstützt im Finanzplan ' + CONVERT(VARCHAR, SFP2.BgFinanzplanID)
    FROM dbo.BgFinanzplan                  SFP  WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgFinanzplan_BaPerson SPP  WITH (READUNCOMMITTED) ON SPP.IstUnterstuetzt = 1 
                                                                      AND SPP.BgFinanzplanID = SFP.BgFinanzplanID
      INNER JOIN dbo.BgFinanzplan_BaPerson SPP2 WITH (READUNCOMMITTED) ON SPP2.IstUnterstuetzt = 1 
                                                                      AND SPP2.BaPersonID = SPP.BaPersonID
                                                                      AND SPP2.BgFinanzplanID <> SPP.BgFinanzplanID
      INNER JOIN dbo.BgFinanzplan          SFP2 WITH (READUNCOMMITTED) ON SFP2.BgFinanzplanID = SPP2.BgFinanzplanID 
                                                                      AND SFP2.BgBewilligungStatusCode = 5 -- bewilligt, aktiv
                                                                      AND SFP2.DatumBis > ISNULL(SFP.DatumVon, SFP.GeplantVon)
                                                                      AND SFP2.DatumVon < ISNULL(SFP.DatumBis, SFP.GeplantBis)
      INNER JOIN dbo.vwPerson              PRS  ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID
      AND SFP.BgBewilligungStatusCode < 5
      AND SFP.FaLeistungID <> SFP2.FaLeistungID -- nicht im selben SH-Fall

  UNION ALL -- SKOS 2005
    SELECT Typ = 2, PRS.Name + ', ' + PRS.Vorname + ': Zulagen / EFB / Sanktion fehlen'
    FROM dbo.BgFinanzplan                   SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgFinanzplan_BaPerson  SPP WITH (READUNCOMMITTED) ON SPP.BgFinanzplanID = SFP.BgFinanzplanID
      INNER JOIN dbo.BaPerson               PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 
      AND SFP.BgFinanzplanID = @BgFinanzplanID 
      AND SPP.IstUnterstuetzt = 1
      AND dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= 16
      AND @WhHilfeTypCode != 1 -- Überbrückungshilfe
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.BgPosition             SPOS WITH (READUNCOMMITTED)
                        INNER JOIN dbo.BgPositionsart SPOA WITH (READUNCOMMITTED) ON SPOA.BgPositionsartID = SPOS.BgPositionsartID
                      WHERE SPOS.DatumVon IS NULL 
                        AND SPOS.BgBudgetID = @BgBudgetID 
                        AND SPOS.BaPersonID = PRS.BaPersonID
                        AND SPOA.BgPositionsartCode BETWEEN 39000 AND 39999)

  UNION ALL -- SKOS 2005
    SELECT Typ = 0, PRS.Name + ', ' + PRS.Vorname + ': Zulagen / EFB / Sanktion - Alleinerziehend ohne Kind'
    FROM dbo.BgBudget               BBG WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPosition     BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID       = BBG.BgBudgetID
      INNER JOIN dbo.BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID
      INNER JOIN dbo.BaPerson       PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID       = BPO.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 
      AND BBG.BgBudgetID = @BgBudgetID 
      AND BBG.MasterBudget = 1 
      AND BBG.BgBewilligungStatusCode < 5 
      AND BPO.DatumVon IS NULL
      AND (SPT.BgPositionsartCode BETWEEN 39110 AND 39119 
        OR SPT.BgPositionsartCode BETWEEN 39130 AND 39139
        OR SPT.BgPositionsartCode IN (39210, 39910))
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED)
                        INNER JOIN dbo.BaPerson      PR2 WITH (READUNCOMMITTED) ON PR2.BaPersonID = SPP.BaPersonID
                      WHERE SPP.BgFinanzplanID = @BgFinanzplanID 
                        AND SPP.IstUnterstuetzt = 1
                        AND dbo.fnGetAge(PR2.Geburtsdatum, @RefDate) < 16)

  UNION ALL -- #7219 Der Finanzplan kann nur freigegeben werden, wenn bei allen Positionen mit Positionsarten "Kreditor eingeschränkt = true" eine Institution vorhanden ist. 
    SELECT Typ = 0, 'Bei Positionen mit Positionsart ''' +  SPT.Name + ''' muss eine Institution ausgewählt werden.'
    FROM dbo.BgBudget               BBG WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPosition     BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID       = BBG.BgBudgetID
      INNER JOIN dbo.BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID   
    WHERE BBG.BgFinanzplanId = @BgFinanzplanID 
      AND BBG.MasterBudget = 1
      AND SPT.KreditorEingeschraenkt = 1
      AND BPO.BaInstitutionID IS NULL

  UNION ALL -- SKOS 2005
    SELECT Typ = 0, PRS.Name + ', ' + PRS.Vorname + ': Zulagen / EFB / Sanktion - Alleinerziehend mit Ehepartner im gleichen Haushalt'
    FROM dbo.BgBudget               BBG WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPosition     BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID       = BBG.BgBudgetID
      INNER JOIN dbo.BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID
      INNER JOIN dbo.BaPerson       PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID       = BPO.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 
      AND BBG.BgBudgetID = @BgBudgetID 
      AND BBG.MasterBudget = 1 
      AND BBG.BgBewilligungStatusCode < 5 
      AND BPO.DatumVon IS NULL
      AND (SPT.BgPositionsartCode BETWEEN 39110 AND 39119 
        OR SPT.BgPositionsartCode BETWEEN 39130 AND 39139 
        OR SPT.BgPositionsartCode IN (39210, 39910))
      AND (SELECT COUNT(*)
           FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED)
             INNER JOIN (SELECT BaPersonID_1, BaPersonID_2, BaRelationID FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         UNION
                         SELECT BaPersonID_1, BaPersonID_2, BaRelationID FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                         )               TMP ON TMP.BaRelationID IN (13, 14) AND TMP.BaPersonID_1 = SPP.BaPersonID
           WHERE SPP.BgFinanzplanID = @BgFinanzplanID) > 2

  UNION ALL -- SKOS 2005
    SELECT Typ = 0, PRS.Name + ', ' + PRS.Vorname + ': EFB ohne Einkommen'
    FROM dbo.BgBudget               BBG WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPosition     BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID       = BBG.BgBudgetID
      INNER JOIN dbo.BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID
      INNER JOIN dbo.BaPerson       PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID       = BPO.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 
      AND BBG.BgBudgetID = @BgBudgetID 
      AND BBG.MasterBudget = 1 
      AND BBG.BgBewilligungStatusCode < 5 
      AND BPO.DatumVon IS NULL
      AND (SPT.BgPositionsartCode BETWEEN 39100 AND 39199)
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM BgPosition              BP2
                        INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BP2.BgPositionsartID
                      WHERE BP2.DatumVon IS NULL 
                        AND BP2.BgKategorieCode = 1 
                        AND SPT.BgGruppeCode IN (3101)
                        AND BP2.BgBudgetID = BPO.BgBudgetID 
                        AND BP2.BaPersonID = PRS.BaPersonID)
  UNION ALL
    SELECT Typ = 1, 'Die Dauer des Finanzplanes (' + CONVERT(VARCHAR, DATEDIFF(m, SFP.GeplantVon, SFP.GeplantBis) + 1)
      + ' Monate) übersteigt Ihre Kompetenz (' + CONVERT(VARCHAR, ISNULL(TMP.Value, 0)) + ' Monate  für ' + XLC.Text + ')'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = SFP.WhHilfeTypCode
      LEFT  JOIN @Permission      TMP ON TMP.PermissionCode = CASE SFP.WhHilfeTypCode WHEN 1 THEN 7 ELSE 3 END
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID 
      AND SFP.BgBewilligungStatusCode < 5
      AND (DATEDIFF(m, SFP.GeplantVon, SFP.GeplantBis) + 1) > CONVERT(INT, ISNULL(TMP.Value, 0))

  UNION ALL
    SELECT Typ = 1, 'Die Gesamt-Dauer der Überbrückungshilfe(n) (' + CONVERT(VARCHAR, DATEDIFF(m, MIN(SFP.GeplantVon), MAX(SFP.GeplantBis)) + 1)
      + ' Monate) übersteigt Ihre Kompetenz (' + CONVERT(VARCHAR, ISNULL(MIN(TMP.Value), 0)) + ' Monate)'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = SFP.WhHilfeTypCode
      LEFT  JOIN @Permission      TMP ON TMP.PermissionCode = 7
    WHERE @WhHilfeTypCode = 1
      AND SFP.WhHilfeTypCode = 1
      AND SFP.FaLeistungID = @FaLeistungID
    HAVING (DATEDIFF(m, MIN(SFP.GeplantVon), MAX(SFP.GeplantBis)) + 1) > CONVERT(INT, ISNULL(MIN(TMP.Value), 0))

  UNION ALL
    SELECT Typ = 1, 'Die Summe der Lebenshaltungskosten (Fr. ' + LTRIM(STR(ISNULL( @SumAusgabenStd, $0.00), 10, 2))
      + ') übersteigt Ihre Kompetenz (Fr. ' + LTRIM(STR(ISNULL(CONVERT(MONEY, TMP.Value), $0.00), 10, 2)) + ' für ' + XLC.Text + ')'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = SFP.WhHilfeTypCode
      LEFT  JOIN @Permission      TMP ON TMP.PermissionCode = CASE SFP.WhHilfeTypCode WHEN 1 THEN 5 ELSE 1 END
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID 
      AND SFP.BgBewilligungStatusCode < 5
      AND @SumAusgabenStd > ISNULL(CONVERT(MONEY, TMP.Value), $0.00)

  UNION ALL
    SELECT Typ = 1, 'Die Summe der weiteren Kosten (SIL etc.) (Fr. ' + LTRIM(STR(ISNULL(@SumAusgabenSil, $0.00), 10, 2))
      + ') übersteigt Ihre Kompetenz (Fr. ' + LTRIM(STR(ISNULL(CONVERT(MONEY, TMP.Value), $0.00), 10, 2)) + ' für ' + XLC.Text + ')'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = SFP.WhHilfeTypCode
      LEFT  JOIN @Permission      TMP ON TMP.PermissionCode = CASE SFP.WhHilfeTypCode WHEN 1 THEN 6 ELSE 2 END
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID 
      AND SFP.BgBewilligungStatusCode < 5
      AND @SumAusgabenSil > ISNULL(CONVERT(MONEY, TMP.Value), $0.00)

  UNION ALL
    SELECT Typ = 1, 'Sie können ihre eigenen Finanzpläne nicht selber bewilligen (4-Augen Prinzip)'
    FROM dbo.BgFinanzplan       SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung FAL ON FAL.FaLeistungID = SFP.FaLeistungID
      LEFT  JOIN @Permission    TMP ON TMP.PermissionCode = 9
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID 
      AND SFP.BgBewilligungStatusCode < 5
      AND FAL.UserID = @UserID
      AND ISNULL(CONVERT(BIT, TMP.Value), 1) = 1

  UNION ALL
    SELECT Typ = 2, PRS.NameVorname + ': Zahlungsverbindung'
    FROM dbo.BgFinanzplan        BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung  LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = BFP.FaLeistungID
      INNER JOIN dbo.vwPerson    PRS ON PRS.BaPersonID = LST.BaPersonID
    WHERE BFP.BgFinanzplanID = @BgFinanzplanID
      AND NOT EXISTS(SELECT TOP 1 1 
                     FROM dbo.BaZahlungsweg WITH (READUNCOMMITTED)
                     WHERE BaPersonID = PRS.BaPersonID
                       AND GETDATE() BETWEEN ISNULL(DatumVon, GETDATE()) AND ISNULL(DatumBis, GETDATE())
                     )
  
  UNION ALL
    SELECT Typ = 0, PRS.Name + ', ' + PRS.Vorname + ': Kostenstelle'
    FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SPP.BgFinanzplanID = @BgFinanzplanID
      AND SPP.IstUnterstuetzt = 1
      AND NOT EXISTS(SELECT TOP 1 1
                     FROM dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED)
                       INNER JOIN KbKostenstelle      KOS WITH (READUNCOMMITTED) ON KOS.KbKostenstelleID = KST.KbKostenstelleID
                     WHERE KST.BaPersonID = SPP.BaPersonID AND KOS.Aktiv = 1)
  
  UNION ALL
    SELECT Typ = 2, PRS.NameVorname + ' erhält vom Inkassodienst Alimentenbevorschussung!'
    FROM BgFinanzplan FPL
      INNER JOIN BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
      INNER JOIN IkGlaeubiger GLB ON GLB.BaPersonID = FPP.BaPersonID
      INNER JOIN IkRechtstitel RTL ON RTL.IkRechtstitelID = GLB.IkRechtstitelID
      INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = RTL.FaLeistungID
      LEFT JOIN  vwPerson PRS ON PRS.BaPersonID = FPP.BaPersonID
    WHERE FPL.BgFinanzplanID = @BgFinanzplanID
      AND GLB.Aktiv = 1 -- Gläubiger Aktiv
      AND FPP.IstUnterstuetzt = 1 -- Unterstützt im Finanzplan
      AND LEI.FaProzessCode = 401 -- Aliment
      AND LEI.DatumVon < FPL.GeplantBis 
      AND (LEI.DatumBis IS NULL 
        OR LEI.DatumBis > FPL.GeplantVon)
      AND LEI.DatumVon <= GETDATE() 
      AND (LEI.DatumBis IS NULL 
        OR LEI.DatumBis >= GETDATE())
        
  UNION ALL
    SELECT Typ = 0, 'zuständige Gemeinde fehlt'
    FROM dbo.FaLeistung WITH (READUNCOMMITTED)
    WHERE FaLeistungID = @FaLeistungID
      AND GemeindeCode IS NULL

  UNION ALL -- #7227: Grundbedarf junge Erwachsene
    SELECT Typ = 2, PRS.NameVorname + ' ist jünger als 25 Jahre!'	
    FROM dbo.BgFinanzplan           FPL        WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung     LEI        WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
      INNER JOIN dbo.BgBudget       BDG        WITH (READUNCOMMITTED) ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                                                                     AND BDG.MasterBudget = 1
      INNER JOIN dbo.BgPositionsart POA        WITH (READUNCOMMITTED) ON POA.BgPositionsartCode = FPL.WhGrundbedarfTypCode
      INNER JOIN dbo.BgPosition     POS        WITH (READUNCOMMITTED) ON POS.BgBudgetID = BDG.BgBudgetID
                                                                     AND POS.BgPositionsartID = POA.BgPositionsartID
                                                                     AND POS.DatumVon IS NULL
                                                                     AND POS.Reduktion <= 0
      INNER JOIN dbo.vwPerson       PRS        WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
      INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
                                                                     AND FPP.BaPersonID = LEI.BaPersonID
                                                                     AND FPP.IstUnterstuetzt = 1
    WHERE FPL.BgFinanzplanID = @BgFinanzplanID
      AND PRS.[Alter] >= 18 
      AND PRS.[Alter] < 25
      AND NOT EXISTS(SELECT TOP 1 1
                     FROM dbo.BgFinanzplan_BaPerson FPP1 WITH (READUNCOMMITTED)
                     WHERE FPP1.BgFinanzplanID = FPP.BgFinanzplanID
                       AND FPP1.BaPersonID <> LEI.BaPersonID
                       AND FPP1.IstUnterstuetzt = 1)

UNION ALL -- Datum GeplantVon ist grösser als AVS-Daten (DatumVon + 2 Monate)
  SELECT 
    Typ = CASE WHEN tempFin.GeplantVon < (SELECT CONVERT(DATETIME, dbo.fnXConfig('System\Sozialhilfe\ASV\StartValidierung', GETDATE()))) 
            THEN 2 
            ELSE 0 
          END, 
    'Das ASV-Datum darf, bezogen auf den 1. des Monats, maximal 2 Monate früher als die Sozialhilfe sein.'
  FROM dbo.WhASVSEintrag ASV 
    INNER JOIN (SELECT TOP 1 FPL.FaLeistungID, FPL.GeplantVon
                FROM dbo.BgFinanzplan FPL WITH (READUNCOMMITTED)
                WHERE FPL.FaLeistungID = @FaLeistungID
                ORDER BY FPL.GeplantVon) tempFin ON ASV.FaLeistungID = tempFin.FaLeistungID
  WHERE tempFin.GeplantVon > DATEADD(mm, + 2, dbo.fnFirstDayOf(ASV.DatumVon))
    AND ASV.ASVSEintragStatusCode < 4 -- Widerrufene filtern
  ORDER BY 1, 2;
END;

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
