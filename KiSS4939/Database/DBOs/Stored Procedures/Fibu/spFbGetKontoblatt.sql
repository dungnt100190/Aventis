SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbGetKontoblatt
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetKontoblatt.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:27 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetKontoblatt.sql $
 * 
 * 2     25.06.09 11:38 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spFbGetKontoblatt
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFbGetKontoblatt
 (@FbPeriodeID int,
  @KontoNr     int)
AS
  DECLARE @FbBuchungID int
  DECLARE @Betrag      money
  DECLARE @SollKtoNr   int
  DECLARE @HabenKtoNr  money
  DECLARE @Saldo       money

  CREATE TABLE #tmp (
    FbBuchungID   int,
    GegenKtoNr    int,
    BetragSoll    money,
    BetragHaben   money,
    Saldo         money)

  DECLARE c CURSOR STATIC FOR
    SELECT FbBuchungID, Betrag, SollKtoNr, HabenKtoNr
    FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
    WHERE  FbPeriodeID = @FbPeriodeID AND
           (SollKtoNr = @KontoNr OR HabenKtoNr = @KontoNr)
    ORDER BY BuchungsDatum

  SET @Saldo = 0

  SELECT @Saldo = EroeffnungsSaldo
  FROM   dbo.FbKonto WITH (READUNCOMMITTED) 
  WHERE  FbPeriodeID = @FbPeriodeID AND
         KontoNr = @KontoNr

  OPEN c
  FETCH NEXT FROM c INTO @FbBuchungID,@Betrag, @SollKtoNr, @HabenKtoNr
  WHILE @@fetch_status = 0 BEGIN

    IF @SollKtoNr = @KontoNr BEGIN
      SET @Saldo = @Saldo + @Betrag
      INSERT #tmp VALUES (@FbBuchungID,@HabenKtoNr,@Betrag,NULL,@Saldo)
    END ELSE BEGIN
      SET @Saldo = @Saldo - @Betrag
      INSERT #tmp VALUES (@FbBuchungID,@SollKtoNr,NULL,@Betrag,@Saldo)
    END
    FETCH NEXT FROM c INTO @FbBuchungID,@Betrag, @SollKtoNr, @HabenKtoNr
  END

  CLOSE c
  DEALLOCATE c

SELECT FBU.*,
       T.*
FROM   #tmp T
       INNER JOIN dbo.FbBuchung FBU WITH (READUNCOMMITTED) ON FBU.FbBuchungID = T.FbBuchungID
ORDER BY FBU.BuchungsDatum
GO