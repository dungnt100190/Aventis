SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetBetragEffektiv
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: 
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnGetBetragEffektiv
(
  @BuchungID INT,
  @erwarteterBetrag FLOAT
)
RETURNS FLOAT
AS
BEGIN
  DECLARE @effektiverBetrag FLOAT;

  SELECT @effektiverBetrag = CASE
                               WHEN BUC.KbBuchungStatusCode = 6 OR BUC.KbBuchungStatusCode = 10 THEN -- ausgeglichen / teilweise ausgeglichen
                                 CONVERT(FLOAT, @erwarteterBetrag) *
                                 (SELECT SUM(AUG.Betrag)
                                  FROM dbo.KbOpAusgleich AUG WITH(READUNCOMMITTED)
                                  WHERE OpBuchungID = @BuchungID) /
                                 CONVERT(FLOAT, BUC.Betrag) -- vorher: betrag von bruttoperson (falsch!)
                               ELSE 0.0
                             END
  FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)
  WHERE BUC.KbBuchungID = @BuchungID;

  RETURN @effektiverBetrag;
END;
GO