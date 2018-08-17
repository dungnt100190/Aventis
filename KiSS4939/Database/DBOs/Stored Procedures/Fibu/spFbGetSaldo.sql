SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbGetSaldo
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetSaldo.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetSaldo.sql $
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
  DB-Object: spFbGetSaldo
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFbGetSaldo
 (@FbPeriodeID int,
  @KontoNr     int)
AS

  DECLARE @SaldoGruppeName varchar(20)

  IF IsNull(@FbPeriodeID,0) = 0 OR IsNull(@KontoNr,0) = 0 BEGIN
    SELECT 0 Saldo, 0 GrpSaldo
    RETURN
  END

  SELECT @SaldoGruppeName = SaldoGruppeName
  FROM   dbo.FbKonto WITH (READUNCOMMITTED) 
  WHERE  FbPeriodeID = @FbPeriodeID AND
         KontoNr = @KontoNr

  IF @@error <> 0 BEGIN
    SELECT 0 Saldo, 0 GrpSaldo
    RETURN
  END

  SELECT
    SaldoGruppeName = @SaldoGruppeName,

    Saldo =      (SELECT IsNull(EroeffnungsSaldo,0)
                  FROM   dbo.FbKonto WITH (READUNCOMMITTED) 
                  WHERE  FbPeriodeID = @FbPeriodeID AND
                         KontoNr = @KontoNr) +

                 (SELECT IsNull(SUM(Betrag),0)
                  FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
                  WHERE  SollKtoNr = @KontoNr AND
                         FbPeriodeID = @FbPeriodeID) -

                 (SELECT IsNull(SUM(Betrag),0)
                  FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
                  WHERE  HabenKtoNr = @KontoNr AND
                         FbPeriodeID = @FbPeriodeID),

    GrpSaldo =   (SELECT IsNull(SUM(EroeffnungsSaldo),0)
                  FROM   dbo.FbKonto WITH (READUNCOMMITTED) 
                  WHERE  FbPeriodeID = @FbPeriodeID AND
                         KontoNr in (SELECT KontoNr FROM dbo.FbKonto WITH (READUNCOMMITTED) 
                                    WHERE  SaldoGruppeName = @SaldoGruppeName AND
                                           FbPeriodeID = @FbPeriodeID)) +

                  (SELECT IsNull(SUM(Betrag),0)
                  FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
                  WHERE  SollKtoNr in (SELECT KontoNr FROM dbo.FbKonto WITH (READUNCOMMITTED) 
                                       WHERE  SaldoGruppeName = @SaldoGruppeName AND
                                              FbPeriodeID = @FbPeriodeID) AND
                         FbPeriodeID = @FbPeriodeID) -

                 (SELECT IsNull(SUM(Betrag),0)
                  FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
                  WHERE  HabenKtoNr in (SELECT KontoNr FROM dbo.FbKonto WITH (READUNCOMMITTED) 
                                        WHERE  SaldoGruppeName = @SaldoGruppeName AND
                                               FbPeriodeID = @FbPeriodeID) AND
                         FbPeriodeID = @FbPeriodeID)
GO