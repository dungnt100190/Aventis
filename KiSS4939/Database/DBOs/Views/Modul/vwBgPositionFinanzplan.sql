SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBgPositionFinanzplan;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Listet die gültigen Positionen von Finanzplänen aus. 
           Kapselt ein paar Hacks
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwBgPositionFinanzplan;
=================================================================================================*/

CREATE VIEW dbo.vwBgPositionFinanzplan
WITH SCHEMABINDING
AS
SELECT FIP.BgFinanzplanID, 
       BUD.BgBudgetID, 
       POS.BgPositionID, 
       POS.BgPositionsartID, 
       POS.DatumVon, 
       POS.DatumBis, 
       POS.Betrag, 
       POS.Reduktion, 
       POS.Abzug, 
       POS.BaPersonID, 
       POS.BaInstitutionID
FROM dbo.BgFinanzplan            FIP
  INNER JOIN dbo.BgBudget        BUD ON BUD.BgFinanzplanID = FIP.BgFinanzplanID AND BUD.Masterbudget = 1
  INNER JOIN dbo.BgPosition      POS ON BUD.BgBudgetID     = POS.BgBudgetID
WHERE IsNull(POS.DatumVon, '19000101') <> '19000102'                                -- Im Masterbudget erstellte/veränderte Position
  AND NOT (POS.DatumVon IS NOT NULL AND POS.BgPositionID_CopyOf IS NULL)            -- Im Monatsbudget erstellte Position
  AND (POS.DatumVon IS NULL OR POS.DatumBis IS NULL OR POS.DatumVon < POS.DatumBis) -- Diese Daten-Anomalie (DatumVon > DatumBis) filtert die nicht mehr gültigen Vorgänger-Positionen heraus

GO