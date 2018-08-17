SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkAlimenteRunden
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnIkAlimenteRunden.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 15:59 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnIkAlimenteRunden.sql $
 * 
 * 2     24.06.09 16:20 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnIkAlimenteRunden
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:57
*/
-- =====================================================================================
-- Author:      R. Hesterberg
-- Create date: 04.07.2007
-- Description: Runden für Alimente-Rechsttitel-Berechnung
-- =====================================================================================
CREATE FUNCTION dbo.fnIkAlimenteRunden
(
  -- RundungsCode gemäss LOV "IkIndexRunden"
  @Code INT,
  -- zu rundender Betrag
  @Betrag MONEY
)
RETURNS MONEY
AS BEGIN
  DECLARE @Result MONEY

  SET @Result = CASE @Code
    -- 1 = Kaufmännisch runden auf 1 Fr.
    WHEN 1 THEN ROUND(@Betrag, 0)
    -- 2 = Abrunden auf 1 Fr.
    WHEN 2 THEN FLOOR(@Betrag)
    -- 3 = Aufrunden auf 1 Fr.
    WHEN 3 THEN CEILING(@Betrag)
    -- 4 = Aufrunden auf 5 Fr.
    WHEN 4 THEN 5*CEILING(@Betrag/5)
    -- 5 = Kaufmännisch auf 5 Fr.
    WHEN 5 THEN 5*ROUND(@Betrag/5, 0)
    -- 6 = Kaufmännisch auf 10 Fr.
    WHEN 6 THEN 10*ROUND(@Betrag/10, 0)
    -- 7 = Kaufmännisch auf 0.05 Fr.
    WHEN 7 THEN ROUND(@Betrag*2, 1)/2
    -- sonst:
    ELSE ROUND(@Betrag, 0)
  END
  RETURN @Result
END
GO