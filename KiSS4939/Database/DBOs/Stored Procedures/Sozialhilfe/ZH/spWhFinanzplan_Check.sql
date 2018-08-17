SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Check
GO
/*===============================================================================================
  $Revision: 8 $
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
  @BgFinanzplanID  int,
  @UserID          int
)
AS BEGIN
  DECLARE @RefDate           datetime,
          @BgBudgetID        int,
          @PermissionGroupID int,
          @WhHilfeTypCode    int

  SELECT
    @BgBudgetID        = BgBudgetID,
    @RefDate           = IsNull(SFP.DatumVon, SFP.GeplantVon),
    -- Eigenkompetenz (eigener FP) oder Fremdkompetenz
    @PermissionGroupID = CASE WHEN FAL.UserID = @UserID
                           THEN USR.PermissionGroupID
                           ELSE USR.GrantPermGroupID
                         END,
    @WhHilfeTypCode    = SFP.WhHilfeTypCode
  FROM dbo.BgFinanzplan        SFP WITH (READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BgBudget    BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
    INNER JOIN dbo.FaLeistung  FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = SFP.FaLeistungID
    INNER JOIN dbo.XUser       USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID
  WHERE SFP.BgFinanzplanID = @BgFinanzplanID


  DECLARE @Permission TABLE (
    PermissionCode int PRIMARY KEY,
    Value          sql_variant)

  INSERT INTO @Permission
    SELECT PermissionCode, Value
    FROM   dbo.XPermissionValue WITH (READUNCOMMITTED)
    WHERE  PermissionGroupID = @PermissionGroupID AND
           PermissionCode IS NOT NULL


  DECLARE @WhGrundbedarfTyp  int
  SELECT @WhGrundbedarfTyp = BgPositionsartID
  FROM dbo.BgPosition        BPO WITH (READUNCOMMITTED)
    INNER JOIN dbo.XLOVCode  XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = BPO.BgPositionsartID
  WHERE BPO.BgBudgetID = @BgBudgetID


  DECLARE @SumAusgabenStd    money,
          @SumAusgabenSil    money

  SELECT @SumAusgabenStd = SUM(BPO.BetragFinanzplan)
  FROM dbo.vwBgPosition BPO INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  WHERE BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 AND SPT.BgGruppeCode != 99
    AND ( (BPO.DatumVon IS NULL  AND BPO.BgPositionsartID NOT IN (32020, 32021) AND BPO.BgPositionsartID NOT BETWEEN 60 AND 99) OR
          ((BPO.BgPositionsartID IN (32020, 32021) OR BPO.BgPositionsartID BETWEEN 60 AND 99)
             AND GetDate() BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, GetDate()))
        )

-- SKOS 2005 Limite Zulagen
  IF @WhGrundbedarfTyp = 32015 BEGIN
    DECLARE @Limit money, @SumZulage money

    SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
    FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
    WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KNZ)
    ORDER BY CFG.Child DESC

    SELECT @SumZulage = SUM(BPO.BetragFinanzplan)
    FROM dbo.vwBgPosition BPO INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 AND BPO.BgPositionsartID BETWEEN 39000 AND 39999 AND SPT.BgGruppeCode != 99
      AND ( (BPO.DatumVon IS NULL  AND BPO.BgPositionsartID NOT IN (32020, 32021) AND BPO.BgPositionsartID NOT BETWEEN 60 AND 99) OR
            ((BPO.BgPositionsartID IN (32020, 32021) OR BPO.BgPositionsartID BETWEEN 60 AND 99)
               AND GetDate() BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, GetDate()))
          )

    IF @SumZulage > @Limit
      SET @SumAusgabenStd = @SumAusgabenStd - @SumZulage + @Limit
  END


  SELECT @SumAusgabenSil = SUM(BPO.BetragFinanzplan)
  FROM dbo.vwBgPosition BPO INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  WHERE BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 AND SPT.BgGruppeCode = 99
    AND ( (BPO.DatumVon IS NULL  AND BPO.BgPositionsartID NOT IN (32020, 32021) AND BPO.BgPositionsartID NOT BETWEEN 60 AND 99) OR
          ((BPO.BgPositionsartID IN (32020, 32021) OR BPO.BgPositionsartID BETWEEN 60 AND 99)
             AND GetDate() BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, GetDate()))
        )


    SELECT 0 AS Typ, 'Es wird keine Person unterstützt'
    WHERE NOT EXISTS (SELECT BgFinanzplanID FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1)
  UNION ALL
    SELECT 0 AS Typ, PRS.NameVorname + ': Geburtsdatum'
    FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED) INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SPP.BgFinanzplanID = @BgFinanzplanID AND PRS.Geburtsdatum IS NULL

  UNION ALL
    SELECT 0 AS Typ, PRS.NameVorname + ': Person im Klientensystem ist inaktiv'
    FROM dbo.BgFinanzplan                   BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung             LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = BFP.FaLeistungID
      INNER JOIN dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID
      INNER JOIN dbo.vwPerson               PRS ON PRS.BaPersonID = FPP.BaPersonID
    WHERE BFP.BgFinanzplanID = @BgFinanzplanID
      AND NOT EXISTS (SELECT FaFallPersonID FROM dbo.FaFallPerson WITH (READUNCOMMITTED)
                      WHERE FaFallID = LST.FaFallID AND BaPersonID = FPP.BaPersonID
                        AND IsNull(BFP.DatumVon, BFP.GeplantVon) BETWEEN IsNull(DatumVon, '17530101') AND IsNull(DatumBis, '99991231'))
  UNION ALL
    SELECT 0 AS Typ, PRS.NameVorname + ': Person ohne finanzelle Leistung darf nicht unterstützt werden'
    FROM dbo.BgFinanzplan                   BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID
      INNER JOIN dbo.vwPerson               PRS ON PRS.BaPersonID = FPP.BaPersonID
    WHERE BFP.BgFinanzplanID = @BgFinanzplanID AND FPP.IstUnterstuetzt = 1
      AND PRS.PersonOhneLeistung = 1

  UNION ALL
    SELECT 0 AS Typ, PRS.NameVorname + ': Person ohne Wohn-/Meldeadresse'
    FROM dbo.BgFinanzplan                   BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID
      INNER JOIN dbo.vwPerson               PRS ON PRS.BaPersonID = FPP.BaPersonID
    WHERE BFP.BgFinanzplanID = @BgFinanzplanID AND FPP.IstUnterstuetzt = 1
      AND (WohnsitzBaAdresseID IS NULL OR
           VornameName IS NULL OR
           WohnsitzPLZ IS NULL OR
           WohnsitzOrt IS NULL)

  UNION ALL
    SELECT 0 AS Typ, PRS.NameVorname + ': WV-Code'
    FROM dbo.BgFinanzplan                   BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BFP.BgFinanzplanID
      INNER JOIN dbo.vwPerson               PRS ON PRS.BaPersonID = FPP.BaPersonID
    WHERE BFP.BgFinanzplanID = @BgFinanzplanID AND FPP.IstUnterstuetzt = 1
      AND (NOT EXISTS (SELECT * FROM BaWVCode WHERE BaPersonID = PRS.BaPersonID AND BFP.GeplantVon BETWEEN DatumVon AND IsNull(DatumBis, BFP.GeplantVon) AND BaWVStatusCode = 1)
       OR  NOT EXISTS (SELECT * FROM BaWVCode WHERE BaPersonID = PRS.BaPersonID AND BFP.GeplantBis BETWEEN DatumVon AND IsNull(DatumBis, BFP.GeplantBis) AND BaWVStatusCode = 1))

  UNION ALL
    SELECT CASE WHEN IsNull(dbo.fnXConfig('System\Sozialhilfe\FinanzPlan\Check_PersonIn2FpUnterstuetzt', @RefDate), 1) = 1 THEN 0 ELSE 2 END,
      PRS.NameVorname + ': bereits unterstützt im Finanzplan ' + CONVERT(varchar, SFP2.BgFinanzplanID)
    FROM dbo.BgFinanzplan                  SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgFinanzplan_BaPerson SPP  WITH (READUNCOMMITTED) ON SPP.IstUnterstuetzt = 1  AND SPP.BgFinanzplanID = SFP.BgFinanzplanID
      INNER JOIN dbo.BgFinanzplan_BaPerson SPP2 WITH (READUNCOMMITTED) ON SPP2.IstUnterstuetzt = 1 AND SPP2.BaPersonID = SPP.BaPersonID
                                            AND SPP2.BgFinanzplanID <> SPP.BgFinanzplanID
      INNER JOIN dbo.BgFinanzplan          SFP2 WITH (READUNCOMMITTED) ON SFP2.BgFinanzplanID = SPP2.BgFinanzplanID AND SFP2.BgBewilligungStatusCode = 5 -- bewilligt, aktiv
                                            AND SFP2.DatumBis > IsNull(SFP.DatumVon, SFP.GeplantVon)
                                            AND SFP2.DatumVon < IsNull(SFP.DatumBis, SFP.GeplantBis)
      INNER JOIN dbo.vwPerson              PRS  ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID
      AND SFP.BgBewilligungStatusCode < 5
      AND SFP.FaLeistungID <> SFP2.FaLeistungID -- nicht im selben SH-Fall

  UNION ALL
    SELECT 0, 'Unterschrift Antrag darf nicht leer bleiben'
    FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
    WHERE BgFinanzplanID = @BgFinanzplanID AND UnterschriftAntrag IS NULL

  UNION ALL
    SELECT 0, 'Der Leistungsentscheid (Ki/Ju amb./stationär, Klärungsphase oder Leistungsentscheid) fehlt und muss erstellt werden'
    FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
    WHERE BgFinanzplanID = @BgFinanzplanID 
      AND XDocumentID_KiJuAmbulant IS NULL 
      AND XDocumentID_Klaerungsphase IS NULL 
      AND XDocumentID_Leistungsentscheid IS NULL

  UNION ALL
    SELECT 0, 'Nur ein Dokument (Klärungsphase oder Leistungsentscheid) darf existieren'
    FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
    WHERE BgFinanzplanID = @BgFinanzplanID 
      AND XDocumentID_Klaerungsphase IS NOT NULL 
      AND XDocumentID_Leistungsentscheid IS NOT NULL

  UNION ALL    
    SELECT 0 AS Typ, 'Die LA: ' + CONVERT(VARCHAR, KOA.KontoNr) + ' "' + POA.Name + '" ist inaktiv und muss vom Finanzplan entfernt werden.'
    FROM dbo.BgFinanzplan FPL WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                                                        AND BDG.Masterbudget = 1
      INNER JOIN dbo.BgPosition BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BDG.BgBudgetID
      INNER JOIN BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartid = BPO.BgPositionsartid
      INNER JOIN BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = POA.BgKostenartID
      INNER JOIN dbo.XLOVCode LOC WITH (READUNCOMMITTED) ON LOC.Code = POA.BgKategorieCode
                                                        AND LOC.LOVName = 'BgKategorie'
    WHERE FPL.BgFinanzplanID = @BgFinanzplanID
      AND FPL.BgBewilligungStatusCode < 5 --nur unbewilligte Finanzpläne
      AND POA.BgKategorieCode > 10000 --inaktiv 

/*
  UNION ALL -- SKOS 2005
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': Zulagen / EFB / Sanktion fehlen'
    FROM BgFinanzPlan                    SFP
      INNER JOIN BgFinanzPlan_BaPerson  SPP ON SPP.BgFinanzPlanID = SFP.BgFinanzPlanID
      INNER JOIN BaPerson               PRS ON PRS.BaPersonID    = SPP.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 AND SFP.BgFinanzPlanID = @BgFinanzPlanID AND SPP.IstUnterstuetzt = 1
      AND dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= 16
      AND @WhHilfeTypCode != 1 -- Überbrückungshilfe
      AND NOT EXISTS (SELECT * FROM BgPosition
                      WHERE DatumVon IS NULL AND BgBudgetID = @BgBudgetID AND BaPersonID = PRS.BaPersonID
                        AND BgPositionsartID BETWEEN 39000 AND 39999)

  UNION ALL -- SKOS 2005
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': Zulagen / EFB / Sanktion - Alleinerziehend ohne Kind'
    FROM BgBudget            BBG
      INNER JOIN BgPosition  BPO ON BPO.BgBudgetID     = BBG.BgBudgetID
      INNER JOIN BaPerson   PRS ON PRS.BaPersonID    = BPO.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 AND BBG.BgBudgetID = @BgBudgetID AND BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode < 5 AND BPO.DatumVon IS NULL
      AND (BPO.BgPositionsartID BETWEEN 39010 AND 39019 OR BPO.BgPositionsartID BETWEEN 39030 AND 39039 OR BPO.BgPositionsartID IN (39050, 39910))
      AND NOT EXISTS (SELECT *
                      FROM BgFinanzPlan_BaPerson  SPP
                        INNER JOIN BaPerson       PR2 ON PR2.BaPersonID = SPP.BaPersonID
                      WHERE SPP.BgFinanzPlanID = @BgFinanzPlanID AND SPP.IstUnterstuetzt = 1
                        AND dbo.fnGetAge(PR2.Geburtsdatum, @RefDate) < 16)

  UNION ALL -- SKOS 2005
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': Zulagen / EFB / Sanktion - Alleinerziehend mit Ehepartner im gleichen Haushalt'
    FROM BgBudget            BBG
      INNER JOIN BgPosition  BPO ON BPO.BgBudgetID     = BBG.BgBudgetID
      INNER JOIN BaPerson   PRS ON PRS.BaPersonID    = BPO.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 AND BBG.BgBudgetID = @BgBudgetID AND BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode < 5 AND BPO.DatumVon IS NULL
      AND (BPO.BgPositionsartID BETWEEN 39010 AND 39019 OR BPO.BgPositionsartID BETWEEN 39030 AND 39039 OR BPO.BgPositionsartID IN (39050, 39910))
      AND (SELECT COUNT(*)
           FROM BgFinanzPlan_BaPerson  SPP
             INNER JOIN (SELECT BaPersonID_1, BaPersonID_2, BaRelationID FROM BaPerson_Relation
                         UNION
                         SELECT BaPersonID_1, BaPersonID_2, BaRelationID FROM BaPerson_Relation
                         )               TMP ON TMP.BaRelationID IN (13, 14) AND TMP.BaPersonID_1 = SPP.BaPersonID
           WHERE SPP.BgFinanzPlanID = @BgFinanzPlanID) > 2

  UNION ALL -- SKOS 2005
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': EFB ohne Einkommen'
    FROM BgBudget            BBG
      INNER JOIN BgPosition  BPO ON BPO.BgBudgetID     = BBG.BgBudgetID
      INNER JOIN BaPerson   PRS ON PRS.BaPersonID    = BPO.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 AND BBG.BgBudgetID = @BgBudgetID AND BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode < 5 AND BPO.DatumVon IS NULL
      AND (BPO.BgPositionsartID BETWEEN 39000 AND 39039)
      AND NOT EXISTS (SELECT *
                      FROM BgPosition             BP2
                        INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BP2.BgPositionsartID
                      WHERE BP2.DatumVon IS NULL AND BP2.BgKategorieCode = 1 AND SPT.BgGruppeCode IN (3101)
                        AND BP2.BgBudgetID = BPO.BgBudgetID AND BP2.BaPersonID = PRS.BaPersonID)
*/
/*  Regel muss noch detailierter spezifiziert werden
  UNION ALL -- SKOS 2005
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': Zulage mit Einkommen'
    FROM BgBudget            BBG
      INNER JOIN BgPosition  BPO ON BPO.BgBudgetID     = BBG.BgBudgetID
      INNER JOIN BaPerson   PRS ON PRS.BaPersonID    = BPO.BaPersonID
    WHERE @WhGrundbedarfTyp = 32015 AND BBG.BgBudgetID = @BgBudgetID AND BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode < 5 AND BPO.DatumVon IS NULL
      AND BPO.BgPositionsartID BETWEEN 39000 AND 39999
      AND NOT (BPO.BgPositionsartID BETWEEN 39000 AND 39039 OR BPO.BgPositionsartID IN (39090))
      AND EXISTS (SELECT *
                  FROM BgPosition             BP2
                    INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BP2.BgPositionsartID
                  WHERE BP2.DatumVon IS NULL AND BP2.BgKategorieCode = 1 AND SPT.BgGruppeCode IN (3101)
                    AND BP2.BgBudgetID = BPO.BgBudgetID AND BP2.BaPersonID = PRS.BaPersonID)
*/
  UNION ALL
    SELECT 1, 'Die Dauer des Finanzplanes (' + CONVERT(varchar, DateDiff(m, SFP.GeplantVon, SFP.GeplantBis) + 1)
      + ' Monate) übersteigt Ihre Kompetenz (' + CONVERT(varchar, IsNull(TMP.Value, 0)) + ' Monate  für ' + XLC.Text + ')'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = SFP.WhHilfeTypCode
      LEFT  JOIN @Permission  TMP ON TMP.PermissionCode = CASE SFP.WhHilfeTypCode WHEN 1 THEN 17 ELSE 3 END
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID AND SFP.BgBewilligungStatusCode < 5
      AND (DateDiff(m, SFP.GeplantVon, SFP.GeplantBis) + 1) > CONVERT(int, IsNull(TMP.Value, 0))

  UNION ALL
    SELECT 1, 'Die Summe der Lebenshaltungskosten (Fr. ' + LTrim(STR(IsNull( @SumAusgabenStd, $0.00), 10, 2))
      + ') übersteigt Ihre Kompetenz (Fr. ' + LTrim(STR(IsNull(CONVERT(money, TMP.Value), $0.00), 10, 2)) + ' für ' + XLC.Text + ')'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = SFP.WhHilfeTypCode
      LEFT  JOIN @Permission  TMP ON TMP.PermissionCode = CASE SFP.WhHilfeTypCode WHEN 1 THEN 15 ELSE 1 END
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID AND SFP.BgBewilligungStatusCode < 5
      AND @SumAusgabenStd > IsNull(CONVERT(money, TMP.Value), $0.00)

  UNION ALL
    SELECT 1, 'Die Summe der weiteren Kosten (SIL etc.) (Fr. ' + LTrim(STR(IsNull(@SumAusgabenSil, $0.00), 10, 2))
      + ') übersteigt Ihre Kompetenz (Fr. ' + LTrim(STR(IsNull(CONVERT(money, TMP.Value), $0.00), 10, 2)) + ' für ' + XLC.Text + ')'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = SFP.WhHilfeTypCode
      LEFT  JOIN @Permission  TMP ON TMP.PermissionCode = CASE SFP.WhHilfeTypCode WHEN 1 THEN 16 ELSE 2 END
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID AND SFP.BgBewilligungStatusCode < 5
      AND @SumAusgabenSil > IsNull(CONVERT(money, TMP.Value), $0.00)

  UNION ALL
    SELECT 1, 'Sie können ihre eigenen Finanzpläne nicht selber bewilligen (4-Augen Prinzip)'
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung       FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = SFP.FaLeistungID
      LEFT  JOIN @Permission  TMP ON TMP.PermissionCode = 9
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID AND SFP.BgBewilligungStatusCode < 5
      AND FAL.UserID = @UserID
      AND IsNull(CONVERT(bit, TMP.Value), 1) = 1

  UNION ALL
    SELECT 2 AS TYP, PRS.NameVorname + ': Zahlungsverbindung'
    FROM dbo.BgFinanzplan        BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung  LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = BFP.FaLeistungID
      INNER JOIN dbo.vwPerson    PRS ON PRS.BaPersonID = LST.BaPersonID
    WHERE BFP.BgFinanzplanID = @BgFinanzplanID
      AND NOT EXISTS(SELECT * FROM dbo.BaZahlungsweg WITH (READUNCOMMITTED)
                     WHERE BaPersonID = PRS.BaPersonID
                       AND GetDate() BETWEEN DatumVon AND IsNull(DatumBis, GetDate())
                     )

  ORDER BY 1, 2
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
