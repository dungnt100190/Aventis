SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetOriginalBgPositionID
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnGetOriginalBgPositionID.SQL $
  $Author: Lloreggia $
  $Modtime: 11.12.09 10:30 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Falls die übergebene @KbBuchungBruttoID eine NEU- oder STO-Buchung ist, 
           gibt diese Funktion die BgPositionID der Originalbuchung zurück, und zwar unabhängig, wie tief die Umbuchungs- resp. Storno-Hierarchie ist
           Falls die übergebene @KbBuchungBruttoID keine NEU- oder STO-Buchung ist, wird einfach die BgPositionID dieser @KbBuchungBruttoID zurückgegeben.
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    Select * from KbBuchungBrutto where StorniertKbBuchungBruttoID is not null
           Select dbo.fnGetOriginalBgPositionID(1036705)
=================================================================================================*/

CREATE FUNCTION dbo.fnGetOriginalBgPositionID
(
  @KbBuchungBruttoID int
)
RETURNS int
AS
BEGIN
  DECLARE @OriginalBgPositionID int
  DECLARE @OriginalKbBuchungBruttoID int
  SELECT @OriginalKbBuchungBruttoID = dbo.fnGetOriginalKbBuchungBruttoID(@KbBuchungBruttoID)
  
  SELECT @OriginalBgPositionID = POS.BgPositionID FROM BgPosition POS WITH (READUNCOMMITTED)
	INNER JOIN KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.BgPositionID = POS.BgPositionID
	WHERE KBP.KbBuchungBruttoID = @OriginalKbBuchungBruttoID
  
  RETURN @OriginalBgPositionID

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
