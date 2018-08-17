SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhUnterstuetztePersonen;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnWhUnterstuetztePersonen
(
	@FaFallID int
)
RETURNS TABLE
AS
RETURN
(
	SELECT DISTINCT BFP.BaPersonID
	FROM dbo.FaFall								FAL	 WITH (READUNCOMMITTED)
		INNER JOIN dbo.FaFall					FAL2 WITH (READUNCOMMITTED) ON FAL2.BaPersonID = FAL.BaPersonID
		INNER JOIN dbo.FaLeistung				LEI	 WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL2.FaFallID
		INNER JOIN dbo.BgFinanzplan				BFI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BFI.FaLeistungID AND BFI.DatumVon IS NOT NULL
		INNER JOIN dbo.BgFinanzplan_BaPerson	BFP  WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BFI.BgFinanzplanID AND BFP.IstUnterstuetzt = 1
	WHERE LEI.FaFallID = @FaFallID AND LEI.ModulID = 3
	UNION
	SELECT DISTINCT MIG.BaPersonID
	FROM dbo.FaFall								FAL	 WITH (READUNCOMMITTED)
		INNER JOIN dbo.FaFall					FAL2 WITH (READUNCOMMITTED) ON FAL2.BaPersonID = FAL.BaPersonID
		INNER JOIN dbo.FaLeistung				LEI	 WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL2.FaFallID
		INNER JOIN dbo.MigDetailbuchung MIG WITH (READUNCOMMITTED) ON MIG.FaLeistungID = LEI.FaLeistungID
	WHERE LEI.FaFallID = @FaFallID AND LEI.ModulID = 3
)
	

