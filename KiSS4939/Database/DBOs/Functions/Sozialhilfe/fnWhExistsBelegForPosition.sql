SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhExistsBelegForPosition
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnWhExistsBelegForPosition.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:06 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnWhExistsBelegForPosition.sql $
 * 
 * 2     25.06.09 8:15 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnWhExistsBelegForPosition
  Branch   : KiSS4_BSS_Master
  BuildNr  : 3
  Datum    : 07.07.2008 09:31
*/
-- =====================================================================================
-- Author:      M. Minder
-- Create date: 20.10.2007
-- Description: Prüfen, ob für eine BudgetPosition bereits ein verbuchter Beleg besteht
-- =====================================================================================
CREATE FUNCTION dbo.fnWhExistsBelegForPosition
(
  -- ID BudgetPosition
  @BgPositionID int
)
RETURNS bit
AS 

BEGIN

  RETURN CASE WHEN
  (
    EXISTS
    (
      SELECT 1
      FROM dbo.KbBuchung KBU WITH (READUNCOMMITTED) 
        INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID = KBU.KbBuchungID
      WHERE KBK.BgPositionID = @BgPositionID  AND KBU.KbBuchungStatusCode NOT IN (1, 2)--( 3,4,5,6,7,10,13)
    )
/*    OR EXISTS
    (
      SELECT *
      FROM KbBuchungBrutto               KBB
        INNER JOIN KbBuchungBruttoPerson KBP ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
      WHERE BgPositionID = @BgPositionID AND KbBuchungTypCode IN (1,2/*Einnahmen, Ausgaben*/) AND KbBuchungStatusCode IN ( 3,4,6,7,10 )
    )
*/
  )
  THEN 1 ELSE 0 END

END

--lov buchungsstatus
--lov KbBuchungTyp
GO