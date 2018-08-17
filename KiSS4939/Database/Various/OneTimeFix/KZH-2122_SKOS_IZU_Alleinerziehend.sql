-- IZU alleinerz. + Pflege
DECLARE @stichDatum AS DATETIME
SET @stichDatum = dbo.fnDateSerial(2016,5,1);

SELECT 
       [Selektiert] = '',
       [Pers-Nr]    = PRS.BaPersonID,
       [Fall-Nr]    = LEI.FaFallID,
       [Finanzplan-Nr]   = FPL.BgFinanzplanID,
       [Geb-Datum]  = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
       [Name, Vorname Leistungsträger/in W] = PRS.NameVorname,
       [Name, Vorname Leistungsverantwortliche/r W] = USR.NameVorname,
       [Team W-Leistungsverantwortliche/r] = USR.OrgUnit,
       [Leistung] = dbo.fnLOVText('BgZulagenLeistung', CONVERT(INT, POS.Value1)),
       Betrag = POS.Betrag,
       [Anzahl Erwachsene im Haushalt] = FEK.AnzE,
       [Anzahl Kinder im Haushalt] = FEK.AnzK,
       [Total Personen im Haushalt] = FEK.AnzTotal,
       [BgPositionID]   = POS.BgPositionID
FROM dbo.BgFinanzplan     FPL 
  INNER JOIN dbo.BgBudget   BBG ON BBG.BgFinanzplanID = FPL.BgFinanzplanID
                               AND BBG.MasterBudget = 1
  INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BBG.BgBudgetID
                                AND POS.BgKategorieCode = 2 -- Ausgabe
                                AND ISNULL(POS.DatumVon, FPL.DatumVon) <= @stichDatum
                                AND COALESCE(POS.DatumBis, FPL.DatumBis, FPL.GeplantBis) > DATEADD(DAY,-1,@stichDatum)
  INNER JOIN dbo.BgPositionsart BPA ON BPA.BgPositionsartID = POS.BgPositionsartID
  INNER JOIN dbo.BgKostenart KOA ON KOA.BgKostenartID = BPA.BgKostenartID 
                                AND KOA.KontoNr IN (370,371) -- 370=IZU ab 25 Jahre 371=IZU-16-25 Jahre
  INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FPL.FaLeistungID
  INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = LEI.BaPersonID
  INNER JOIN dbo.vwUser USR ON USR.UserID = LEI.UserID

  CROSS APPLY (SELECT AnzTotal = COUNT(1),
                      AnzE = SUM(CASE WHEN dbo.fnGetAge(PRS_I.Geburtsdatum, @stichDatum) >= 18 THEN 1 ELSE 0 END), 
                      AnzK = SUM(CASE WHEN dbo.fnGetAge(PRS_I.Geburtsdatum, @stichDatum) < 18 THEN 1 ELSE 0 END)
              FROM dbo.BgFinanzplan_BaPerson FPP_I
                INNER JOIN dbo.BaPerson PRS_I ON PRS_I.BaPersonID = FPP_I.BaPersonID
              WHERE FPP_I.BgFinanzplanID = FPL.BgFinanzplanID) FEK 
WHERE COALESCE(FPL.DatumBis,FPL.GeplantBis,'99991231')  > DATEADD(DAY,-1,@stichDatum)
  AND (pos.value1 IS NULL OR POS.Value1 IN (11, 13)) --11:regelmässige Pflege von Angehörigen im oder ausserhalb des eigenen Haushalts, 13:alleinziehend mit Kindern unter 3 Jahren

