SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhAbrechnungAlleFaelle
GO
/*===============================================================================================
  $Revision: 1 $
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

CREATE FUNCTION dbo.fnWhAbrechnungAlleFaelle
(
	@baPersonenIDs varchar(500)
)
RETURNS
@Faelle TABLE
(
	FaFallID int,
	FT int -- Fallträger
)
AS
BEGIN
	DECLARE @Personen table
	(
		BaPersonID int
	)
	INSERT INTO @Personen (BaPersonID) SELECT SplitValue FROM dbo.fnSplitStringToValues(@baPersonenIDs, ',', 1)

	INSERT INTO @Faelle (FaFallID, FT)
	SELECT DISTINCT LEI.FaFallID, FAL.BaPersonID
	FROM dbo.BgFinanzplan_BaPerson	BFP WITH (READUNCOMMITTED)
 		INNER JOIN BgFinanzplan		BFI WITH (READUNCOMMITTED) ON BFI.BgFinanzplanID = BFP.BgFinanzplanID AND BFI.DatumVon IS NOT NULL
		INNER JOIN FaLeistung		LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BFI.FaLeistungID AND LEI.ModulID = 3
		INNER JOIN FaFall			FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
	WHERE BFP.BaPersonID IN (SELECT BaPersonID FROM @Personen)
	UNION
	SELECT DISTINCT FAL.FaFallID, FAL.BaPersonID
	FROM dbo.MigDetailBuchung		BUC WITH (READUNCOMMITTED)
		INNER JOIN dbo.FaLeistung	LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BUC.FaLeistungID
		INNER JOIN dbo.FaFall		FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
	WHERE BUC.BaPersonID IN (SELECT BaPersonID FROM @Personen)

	RETURN
END
