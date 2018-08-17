SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetAllDependendNettoBelegIDs
GO
/*===============================================================================================
  $Revision: 5 $
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

CREATE FUNCTION dbo.fnGetAllDependendNettoBelegIDs
 (@OrigNettoBelegID int)
  RETURNS @OUTPUT TABLE (NettoBelegID int)
AS

BEGIN

    INSERT @OUTPUT (NettoBelegID)
		SELECT DISTINCT KBU2.KbBuchungID
		  FROM dbo.KbBuchung KBU1 WITH (READUNCOMMITTED)
			inner JOIN dbo.KbBuchungKostenart    KBK1 WITH (READUNCOMMITTED) ON KBK1.KbBuchungID      = KBU1.KbBuchungID
			inner JOIN dbo.KbBuchungKostenart    KBK2 WITH (READUNCOMMITTED) ON KBK2.BgPositionID      = KBK1.BgPositionID
			inner JOIN dbo.KbBuchung             KBU2 WITH (READUNCOMMITTED) ON KBU2.KbBuchungID       = KBK2.KbBuchungID
		WHERE KBU1.KbBuchungID = @OrigNettoBelegID AND KBU2.StorniertKbBuchungID IS NULL
		UNION
		SELECT DISTINCT			KBU1.KbBuchungID
		  FROM dbo.KbBuchung KBU1 WITH (READUNCOMMITTED)
		WHERE KBU1.KbBuchungID = @OrigNettoBelegID
				
	RETURN			
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
