SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgGetKontoblatt
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

CREATE PROCEDURE dbo.spKgGetKontoblatt
 (@KgPeriodeID int,
  @KontoNr     int)
AS
  DECLARE @KgBuchungID int
  DECLARE @Betrag      money
  DECLARE @SollKtoNr   int
  DECLARE @HabenKtoNr  money
  DECLARE @Saldo       money

  CREATE TABLE #tmp (
    KgBuchungID   int,
    GegenKtoNr    int,
    BetragSoll    money,
    BetragHaben   money,
    Saldo         money)

  DECLARE c CURSOR STATIC FOR
    SELECT KgBuchungID, Betrag, SollKtoNr, HabenKtoNr
    FROM   dbo.KgBuchung WITH (READUNCOMMITTED)
    WHERE  KgPeriodeID = @KgPeriodeID AND
           (SollKtoNr = @KontoNr OR HabenKtoNr = @KontoNr)
    ORDER BY BuchungsDatum

  SET @Saldo = 0

  SELECT @Saldo = Vorsaldo
  FROM   dbo.KgKonto WITH (READUNCOMMITTED)
  WHERE  KgPeriodeID = @KgPeriodeID AND
         KontoNr = @KontoNr

  OPEN c
  FETCH NEXT FROM c INTO @KgBuchungID,@Betrag, @SollKtoNr, @HabenKtoNr
  WHILE @@fetch_status = 0 BEGIN

    IF @SollKtoNr = @KontoNr BEGIN
      SET @Saldo = @Saldo + @Betrag
      INSERT #tmp VALUES (@KgBuchungID,@HabenKtoNr,@Betrag,NULL,@Saldo)
    END ELSE BEGIN
      SET @Saldo = @Saldo - @Betrag
      INSERT #tmp VALUES (@KgBuchungID,@SollKtoNr,NULL,@Betrag,@Saldo)
    END
    FETCH NEXT FROM c INTO @KgBuchungID,@Betrag, @SollKtoNr, @HabenKtoNr
  END

  CLOSE c
  DEALLOCATE c

SELECT BUC.*,
       T.*
FROM   #tmp T
       INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgBuchungID = T.KgBuchungID
ORDER BY BUC.BuchungsDatum

