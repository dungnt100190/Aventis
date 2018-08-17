SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGleicherHaushalt
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnGleicherHaushalt
(
  @FalltraegerID int,
  @BaPersonID int,
  @RefDate datetime
)
RETURNS bit AS

BEGIN
  
  -- ist BaPersonID zum Zeitpunkt @RefDate in einem Finanzplan von @FalltraegerID Mitglied? 
  IF EXISTS (SELECT 1
             FROM   dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID = LEI.FaLeistungID
                    INNER JOIN dbo.BgFinanzplan_BaPerson FPR WITH (READUNCOMMITTED) ON FPR.BgFinanzplanID = BFP.BgFinanzplanID
             WHERE  LEI.BaPersonID = @FalltraegerID AND 
                    @RefDate BETWEEN BFP.DatumVon AND IsNull(BFP.DatumBis, @RefDate) AND
                    FPR.BaPersonID = @BaPersonID)
    RETURN 1

  -- ist BaPersonID zum Zeitpunkt @RefDate in derselben Wohnsituation wie @FalltraegerID? 
  IF EXISTS (SELECT 1
             FROM   dbo.BaWohnsituationPerson WOP WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.BaWohnsituation       WOH  WITH (READUNCOMMITTED) ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
                    INNER JOIN dbo.BaWohnsituationPerson WOP2 WITH (READUNCOMMITTED) ON WOP2.BaWohnsituationID = WOH.BaWohnsituationID
             WHERE  WOP.BaPersonID = @FalltraegerID AND 
                    @RefDate BETWEEN IsNull(WOH.DatumVon,@RefDate) AND IsNull(WOH.DatumBis, @RefDate) AND
                    WOP2.BaPersonID = @BaPersonID)
    RETURN 1

  RETURN 0

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
