/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update XMOdulTree
  
=================================================================================================*/
-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-- CtlWhFinanzplan
UPDATE dbo.XModulTree 
  SET sqlInsertTreeItem = N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BgFinanzplanID, BaPersonID, BgBudgetID, Name, DatumVon, Abgeschlossen)
  SELECT @ModulTreeID, IsNull(@ClassName, '''') + CONVERT(varchar, SFP.BgFinanzPlanID), TRE.ID,
    CASE SFP.BgBewilligungStatusCode
      WHEN 1  THEN 1312  -- Vorbereitung
      WHEN 2  THEN 1312  -- Abgelehnt
      WHEN 3  THEN 1313  -- Angefragt
      WHEN 5  THEN 1314  -- Bewilligt
      WHEN 9  THEN 1315  -- Gesperrt
    END,
    TRE.FaFallID, TRE.FaLeistungID, SFP.BgFinanzplanID, TRE.BaPersonID, BBG.BgBudgetID,
    COALESCE(LAN.Text,TYP.Text) + '': '' + dbo.fnXKurzMonatJahrML(IsNull(SFP.DatumVon, SFP.GeplantVon), @LanguageCode) + IsNull('' - '' + dbo.fnXKurzMonatJahrML(IsNull(SFP.DatumBis, SFP.GeplantBis), @LanguageCode), ''''),
    IsNull(SFP.DatumVon, SFP.GeplantVon),
    Abgeschlossen = CASE WHEN LST.DatumBis IS NULL THEN 0 ELSE 1 END
  FROM #Tree                 TRE
    INNER JOIN BgFinanzPlan  SFP ON SFP.FaLeistungID = TRE.FaLeistungID
    INNER JOIN FaLeistung    LST ON LST.FaLeistungID = TRE.FaLeistungID
    LEFT  JOIN XLOVCode      TYP ON TYP.LOVName = ''WhHilfeTyp'' AND TYP.Code = SFP.WhHilfeTypCode
    LEFT  JOIN XLangText     LAN ON LAN.TID = TYP.TextTID AND LAN.LanguageCode = @LanguageCode     
    LEFT  JOIN BgBudget      BBG ON BBG.BgFinanzPlanID = SFP.BgFinanzPlanID AND BBG.Masterbudget = 1
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY IsNull(SFP.DatumVon, SFP.GeplantVon) DESC, SFP.BgFinanzplanID'
WHERE ModulTreeID = 30100


-- Monatsbudget
UPDATE dbo.XModulTree
  SET sqlInsertTreeItem = N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaLeistungID, BgFinanzplanID, BgBudgetID, MasterBudget, BgBewilligungStatusCode, Name, Abgeschlossen)
  SELECT @ModulTreeID, TRE.ID + ''\BBG'' + CONVERT(varchar, BBG.BgBudgetID), TRE.ID,
    CASE BBG.BgBewilligungStatusCode
      WHEN 1  THEN 1323  -- Vorbereitung
      WHEN 5  THEN 1324  -- Bewilligt
      WHEN 9  THEN 1325  -- Gesperrt
    END,
    TRE.FaLeistungID, BBG.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, BBG.BgBewilligungStatusCode,
    ''Budget mensuel '' + dbo.fnXKurzMonatML(BBG.Monat, @LanguageCode) + '' '' + CONVERT(varchar, BBG.Jahr),
    Abgeschlossen = CASE WHEN LST.DatumBis IS NULL THEN 0 ELSE 1 END
  FROM #Tree                 TRE
    INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = TRE.BgFinanzplanID AND SFP.BgBewilligungStatusCode >= 5
    INNER JOIN BgBudget      BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 0
    INNER JOIN FaLeistung    LST ON LST.FaLeistungID = TRE.FaLeistungID
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY BBG.Jahr, BBG.Monat'
WHERE ModulTreeID = 30119

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO