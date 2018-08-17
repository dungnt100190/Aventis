SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject #spTEMPFinanzplanBeendenUndWiedereroeffnen
GO
CREATE PROCEDURE #spTEMPFinanzplanBeendenUndWiedereroeffnen
(
	@BgFinanzplanID int,
	@Stichtag DateTime  -- Abschlussdatum des Finanzplans (muss Monatsende sein)
)
AS
BEGIN 
  DECLARE @NewBgFinanzplanID  int
  DECLARE @BgBudgetID  int
  DECLARE @FaLeistungID int
  DECLARE @GeplantVon DateTime
  DECLARE @GeplantBis DateTime
  DECLARE @WhHilfeTyp int
  
  -- Hole Zusatzinformationen
  SELECT @FaLeistungID = FaLeistungID, 
         @GeplantBis = GeplantBis,
         @WhHilfeTyp = CASE WHEN WhHilfeTypCode = 2 THEN 4 ELSE WhHilfeTypCode END
  FROM BgFinanzplan WHERE BgFinanzplanID = @BgFinanzplanID
  
  -- Lösche alle grauen Budgets nach Stichtag
  DECLARE cBudget CURSOR FOR
  SELECT BgBudgetID
  FROM BgBudget   BBG
  WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode < 5
  AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) > @Stichtag

  OPEN cBudget
  WHILE 1 = 1 BEGIN
  FETCH NEXT FROM cBudget INTO @BgBudgetID
    IF @@FETCH_STATUS != 0 BREAK

    EXECUTE spWhBudget_Delete @BgBudgetID
    DELETE FROM BgBudget WHERE BgBudgetID = @BgBudgetID
  END
  CLOSE cBudget
  DEALLOCATE cBudget
 
  -- Erstelle neuen Finanzplan 
  SET @GeplantVon = DATEADD(d, 1, @Stichtag)
  EXECUTE spWhFinanzPlan_Create @FaLeistungID, @GeplantVon, @GeplantBis, @WhHilfeTyp
  
  SELECT @NewBgFinanzplanID = (SELECT TOP 1 BgFinanzplanID FROM BgFinanzplan WHERE FaLeistungID = @FaLeistungID AND GeplantBis = @GeplantBis ORDER BY BgFinanzplanID desc)
  
  -- Update des beendeten Finanzplans
  UPDATE BgFinanzplan SET 
      Bemerkung = 'Automatisch terminierter Finanzplan per ' + CONVERT(varchar, @Stichtag, 104) + ' wegen GBL-Teuerungsanpassung gemäss SKOS' + ISNULL(', ' + CONVERT(varchar, Bemerkung), ''),
      DatumBis = @Stichtag,
      BgGrundAbschlussCode = 4 -- Signifikante Änderung der finanziellen Situation
    WHERE BgFinanzplanID = @BgFinanzplanID

  -- Update des neuen Finanzplans
  UPDATE BgFinanzplan SET 
      Bemerkung = 'Automatisch wieder eröffneter Finanzplan per ' + CONVERT(varchar, DateAdd(d, 1, @Stichtag), 104) + ' wegen GBL-Teuerungsanpassung gemäss SKOS' + ISNULL(', ' + CONVERT(varchar, Bemerkung), ''),
      UnterschriftAntrag = (SELECT TOP 1 UnterschriftAntrag FROM BgFinanzplan WHERE BgFinanzplanID = @BgFinanzplanID) -- Kopiere UnterschriftAnftrag vom alten Finanzplan
    WHERE BgFinanzplanID = @NewBgFinanzplanID  
                
  -- Finanzplan-Bewilligungs-Eintrag
  DECLARE @Biag_User INT;
  SELECT @Biag_User = UserID FROM XUser WHERE LogonName = 'diag_admin'

  INSERT INTO BgBewilligung 
  (BgFinanzPlanID, PerDatum, BgBewilligungCode, UserID, Datum)
  VALUES
  (@BgFinanzplanID, @Stichtag, 5 /* = 'Finanzplan vorzeitig beendet' */, @Biag_User /* = kiss_sys */, GetDate())

  -- Fallverlaufsprotokoll
  DECLARE @Text varchar(500)
  SET @Text = 'Automatisch terminierter und wieder eröffneter Finanzplan per ' + CONVERT(varchar, @Stichtag, 104) + ' wegen GBL-Teuerungsanpassung gemäss SKOS'
  
  -- (Neuer Journaleintrag)
  EXECUTE dbo.spFaInsertFVProtokoll NULL /*FaFallID*/, 
                                @FaLeistungID, 
                                NULL /*BaPersonID*/, 
                                8601 /* = kiss_sys*/, 
                                1 /* = FaJournalCode*/,
                                @Text

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
