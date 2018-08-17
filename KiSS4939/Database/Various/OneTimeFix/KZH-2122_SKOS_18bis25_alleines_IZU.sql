-- 18-25 eigenem HH
DECLARE @stichDatum AS DATETIME
SET @stichDatum = dbo.fnDateSerial(2016,5,1);

SELECT [Selektiert] = '',
       [Pers-Nr] = PRS.BaPersonID,
       [Fall-Nr] = LEI.FaFallID,
       [Finanzplan-Nr]   = FPL.BgFinanzplanID,
       [Geb-Datum]  = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
       [Name, Vorname Leistungsträger/in W] = PRS.NameVorname,
       [Name, Vorname Leistungsverantwortliche/r W] = USR.NameVorname,
       [Team W-Leistungsverantwortliche/r] = USR.OrgUnit,
       [BgPositionID]       = dbo.ConcDistinct(POS.BgPositionID),
       [GBL Betrag]         = SUM(POS_GBL.Betrag),
       Berechnungsgrundlage = dbo.fnLOVText('WhGrundbedarfTyp', FPL.WhGrundbedarfTypCode)
FROM dbo.BgFinanzplan     FPL 
  INNER JOIN dbo.BgBudget   BDG ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                               AND BDG.MasterBudget = 1
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FPL.FaLeistungID       
  CROSS APPLY (SELECT AnzTotal = COUNT(1),
                      [Alter] = MIN(dbo.fnGetAge(PRS_I.Geburtsdatum, @stichDatum))
               FROM dbo.BgFinanzplan_BaPerson FPP_I
                 INNER JOIN dbo.BaPerson PRS_I ON PRS_I.BaPersonID = FPP_I.BaPersonID
               WHERE FPP_I.BgFinanzplanID = FPL.BgFinanzplanID) FPP   
  INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = LEI.BaPersonID
  INNER JOIN dbo.vwUser USR ON USR.UserID = LEI.UserID
  
  OUTER APPLY (SELECT POS2.BgPositionID
               FROM dbo.BgPosition             POS2 WITH (READUNCOMMITTED)
                 INNER JOIN dbo.BgPositionsart POA2 WITH (READUNCOMMITTED) ON POA2.BgPositionsartID = POS2.BgPositionsartID
                 INNER JOIN dbo.BgKostenart    KOA2 WITH (READUNCOMMITTED) ON KOA2.BgKostenartID = POA2.BgKostenartID
               WHERE POS2.BgBudgetID = BDG.BgBudgetID
                 AND POS2.BgKategorieCode = 2
                 AND ISNULL(POS2.DatumVon, FPL.DatumVon) <= @stichDatum
                 AND COALESCE(POS2.DatumBis, FPL.DatumBis, FPL.GeplantBis) > DATEADD(DAY,-1,@stichDatum)
                 AND KOA2.KontoNr IN (370,371,385)) POS-- IZU ab 25 Jahre, IZU 16-25 Jahre, IZU/MIZ gemeinsam

  OUTER APPLY (SELECT Betrag = SUM(POS1.Betrag)
                FROM dbo.BgPosition POS1 WITH (READUNCOMMITTED)
                WHERE POS1.BgBudgetID = BDG.BgBudgetID
                  AND POS1.BgPositionsartID = FPL.WhGrundbedarfTypCode
                  AND POS1.BgKategorieCode = 2) POS_GBL
  
WHERE COALESCE(FPL.DatumBis, FPL.GeplantBis, '99991231') > DATEADD(DAY,-1,@stichDatum)
  AND FPP.AnzTotal = 1
  AND FPP.[Alter] >= 18
  AND FPP.[Alter] < 25
GROUP BY PRS.BaPersonID, LEI.FaFallID, FPL.BgFinanzplanID, PRS.Geburtsdatum, PRS.NameVorname, USR.NameVorname, USR.OrgUnit, FPL.WhGrundbedarfTypCode
ORDER BY FPL.BgFinanzplanID