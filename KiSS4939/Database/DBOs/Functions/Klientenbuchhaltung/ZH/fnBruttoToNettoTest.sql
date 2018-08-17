SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBruttoToNettoTest
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnBruttoToNettoTest.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 10:23 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnBruttoToNettoTest.sql $
 * 
 * 3     11.12.09 11:00 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:08 Rstahel
 * Abgleich der Functions aus KISS4_MASTER_ZH
=================================================================================================*/

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fnBruttoToNettoTest]
(
  @KbBuchungBruttoID int
)
RETURNS int
AS
BEGIN
  DECLARE @KbBuchungID int

  SELECT @KbBuchungID = KBP.BgPositionID
  FROM dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED)  
    INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
    LEFT OUTER JOIN dbo.KbBuchungKostenart    KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID      = KBP.BgPositionID
  WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID


/*
  SELECT @KbBuchungID = KBU.KbBuchungID
  FROM KbBuchungBrutto KBB
    INNER JOIN KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
    INNER JOIN KbBuchungKostenart    KBK ON KBK.BgPositionID      = KBP.BgPositionID
    INNER JOIN KbBuchung             KBU ON KBU.KbBuchungID       = KBK.KbBuchungID AND IsNull(KBP.Schuldner_BaPersonID,-1) = IsNull(KBU.Schuldner_BaPersonID,-1) AND IsNull(KBP.Schuldner_BaInstitutionID,-1) = IsNull(KBU.Schuldner_BaInstitutionID,-1) AND KBU.ValutaDatum = KBB.ValutaDatum
  WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID
*/
  RETURN @KbBuchungID

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
