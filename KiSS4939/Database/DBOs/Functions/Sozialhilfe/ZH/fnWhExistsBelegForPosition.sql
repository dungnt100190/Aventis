SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhExistsBelegForPosition
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Prüfen, ob für eine BudgetPosition bereits ein verbuchter Beleg besteht
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

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
      WHERE KBK.BgPositionID = @BgPositionID --AND KBU.KbBuchungTypCode IN (1,2/*Einnahmen, Ausgaben*/) --AND KBU.KbBuchungStatusCode IN ( 3,4,6,7,10 )
    )
    OR EXISTS
    (
      SELECT 1
      FROM dbo.KbBuchungBrutto               KBB WITH (READUNCOMMITTED) 
        INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
      WHERE KBP.BgPositionID = @BgPositionID --AND KBB.KbBuchungTypCode IN (1,2/*Einnahmen, Ausgaben*/) --AND KBB.KbBuchungStatusCode IN ( 3,4,6,7,10 )
    )
  )
  THEN 1 ELSE 0 END

END

--lov buchungsstatus
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
