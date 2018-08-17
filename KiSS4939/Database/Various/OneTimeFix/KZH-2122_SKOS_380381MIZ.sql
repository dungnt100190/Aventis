-- LA 380,381 (MIZ)
DECLARE @stichDatum AS DATETIME
SET @stichDatum = dbo.fnDateSerial(2016,5,1);

SELECT [Selektiert] = '',
       [Pers-Nr]    = PRS.BaPersonID,
       [Fall-Nr]    = LEI.FaFallID,
       [Finanzplan-Nr]   = FPL.BgFinanzplanID,
       [Geb-Datum]  = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
       [Name, Vorname Leistungsträger/in W] = PRS.NameVorname,
       [Name, Vorname Leistungsverantwortliche/r W] = USR.NameVorname,
       [Team W-Leistungsverantwortliche/r] = USR.OrgUnit,
       [BgPositionID] = dbo.ConcDistinct(POS.BgPositionID)    
FROM dbo.BgFinanzplan     FPL 
  INNER JOIN dbo.BgBudget   BBG ON BBG.BgFinanzplanID = FPL.BgFinanzplanID
                               AND BBG.MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BBG.BgBudgetID
                               AND POS.BgKategorieCode = 2 -- Ausgabe
                               AND ISNULL(POS.DatumVon, FPL.DatumVon) <= @stichDatum
                               AND COALESCE(POS.DatumBis, FPL.DatumBis, FPL.GeplantBis) > DATEADD(DAY,-1,@stichDatum)
  INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
  INNER JOIN dbo.BgKostenart KOA ON KOA.BgKostenartID = POA.BgKostenartID AND KOA.KontoNr IN (380,381)-- 380=MIZ ab 25 Jahre, 381=MIZ 16-25 Jahre
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FPL.FaLeistungID
  INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = LEI.BaPersonID
  INNER JOIN dbo.vwUser USR ON USR.UserID = LEI.UserID
WHERE COALESCE(FPL.DatumBis,FPL.GeplantBis,'99991231')  > DATEADD(DAY,-1,@stichDatum)
GROUP BY PRS.BaPersonID, LEI.FaFallID, FPL.BgFinanzplanID, PRS.Geburtsdatum, PRS.NameVorname, USR.NameVorname, USR.OrgUnit
