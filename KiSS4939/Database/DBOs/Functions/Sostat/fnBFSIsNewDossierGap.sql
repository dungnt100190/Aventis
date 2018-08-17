
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSIsNewDossierGap;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: true, falls die 6-Monats-Grenze zwischen zwei Datum �berschritten ist
           h�ufige Logik in fn ausgelagert, da die Definition unklar ist. Laut Verena Schorn (ZH)
           ist die 6-Monatsregel erf�llt, wenn zwischen zwei Datum sechs Kalendermonate liegen:
           Hat ein Fall am 10.02.12 und am 20.08.12 eine Auszahlung, ist das noch der gleiche Fall,
           da nur 5 ganze Kalendermonate dazwischenliegen (M�rz, April, Mai, Juni, Juli)
           Im ersten Schritt soll die Logik an diese fn delegiert werden, damit in einem sp�teren
           Schritt die Logik ge�ndert werden kann (falls das BFS und die weiteren Gemeinden 
           einverstanden sind)
    @@Datum1:    .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/
CREATE FUNCTION dbo.fnBFSIsNewDossierGap
(
  @Datum1 DATETIME,
  @Datum2 DATETIME
)
RETURNS BIT
AS 
BEGIN
  RETURN CASE 
           WHEN @Datum1 IS NULL OR @Datum2 IS NULL
                OR DATEDIFF(MONTH, @Datum1, @Datum2) < 6 
                OR (DATEDIFF(MONTH, @Datum1, @Datum2) = 6 
                    AND DAY(@Datum1) > DAY(@Datum2)) THEN 0 
           ELSE 1 
         END;

/*
-- voschlag f�r neu (ungetestet):
  RETURN CASE WHEN MONTH(@Datum2) - MONTH(@Datum1) < 6 THEN 0 ELSE 1 END
*/
END;
GO