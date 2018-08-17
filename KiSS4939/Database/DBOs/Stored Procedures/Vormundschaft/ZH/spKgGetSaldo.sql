SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgGetSaldo
GO
/*===============================================================================================
  $Revision: 4$
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

CREATE PROCEDURE dbo.spKgGetSaldo
 (@KgPeriodeID int,
  @KontoNr     varchar(10))
AS

  IF IsNull(@KgPeriodeID,0) = 0 OR IsNull(@KontoNr,'') = '' BEGIN
    SELECT 0 Saldo
    RETURN
  END

  SELECT
    Saldo =      (SELECT IsNull(Vorsaldo,0)
                  FROM   dbo.KgKonto WITH (READUNCOMMITTED)
                  WHERE  KgPeriodeID = @KgPeriodeID AND
                         KontoNr = @KontoNr) +

                 (SELECT IsNull(SUM(Betrag),0)
                  FROM   dbo.KgBuchung WITH (READUNCOMMITTED)
                  WHERE  SollKtoNr = @KontoNr AND
                         KgPeriodeID = @KgPeriodeID) -

                 (SELECT IsNull(SUM(Betrag),0)
                  FROM   dbo.KgBuchung WITH (READUNCOMMITTED)
                  WHERE  HabenKtoNr = @KontoNr AND
                         KgPeriodeID = @KgPeriodeID)
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
