SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBgGetCurrentOrPreviousFinanzplanID;
GO
/*===============================================================================================
  Revision: 2
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Bestimmt per @DatumMax den aktuellen Finanzplan oder den nächstfrüheren
           Wird z.B. bei SoStat verwendet, um den letzten gültigen FP vor Dossierende zu bestimmen
  -
  RETURNS: BgFinanzplanID
  -
  TEST: SELECT dbo.fnBgGetCurrentOrPreviousFinanzplanID(123, GETDATE())
=================================================================================================*/
CREATE FUNCTION dbo.fnBgGetCurrentOrPreviousFinanzplanID
(
  @FaLeistungID INT,
  @DatumMax     DATETIME
)
RETURNS INT WITH SCHEMABINDING
AS
BEGIN
  RETURN(SELECT TOP 1 BgFinanzplanID
         FROM dbo.BgFinanzplan FIP
         WHERE FIP.FaLeistungID = @FaLeistungID
           AND FIP.DatumVon IS NOT NULL AND FIP.DatumBis IS NOT NULL            -- Nur bewilligte FP
         ORDER BY CASE
                    WHEN @DatumMax BETWEEN FIP.DatumVon AND FIP.DatumBis THEN 1 -- 1. Prio: FP umschliesst @DatumMax
                    WHEN FIP.DatumBis < @DatumMax THEN 2                        -- 2. Prio: FP vor @DatumMax
                    ELSE 3
                  END,
                  ISNULL(FIP.DatumVon, '19000101') DESC);                       -- den aktuellsten Datensatz nehmen
END
GO