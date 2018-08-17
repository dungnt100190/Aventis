SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbSaldiVortragen
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbSaldiVortragen.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:26 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbSaldiVortragen.sql $
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
  DB-Object: spFbSaldiVortragen
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFbSaldiVortragen
 (@BaPersonID int)
AS
  DECLARE @CurrFbPeriodeID  int
  DECLARE @CurrPeriodeStatusCode int
  DECLARE @PreviousFbPeriodeID  int

  -- loop über alle Perioden des Mandanten

  SET @PreviousFbPeriodeID = NULL

  DECLARE cPeriode CURSOR STATIC FOR
      SELECT FbPeriodeID, PeriodeStatusCode
      FROM   dbo.FbPeriode WITH (READUNCOMMITTED) 
      WHERE  BaPersonID = @BaPersonID
      ORDER BY PeriodeVon

  OPEN cPeriode
  FETCH NEXT FROM cPeriode INTO @CurrFbPeriodeID,@CurrPeriodeStatusCode
  WHILE @@fetch_status = 0 BEGIN

    IF @CurrPeriodeStatusCode = 1 AND -- aktiv
       @PreviousFbPeriodeID IS NOT NULL

      -- Calculate AND set new EroeffnungsSaldo
      UPDATE FbKonto
      SET    EroeffnungsSaldo = IsNull(
              (SELECT IsNull(EroeffnungsSaldo,0)
               FROM   FbKonto
               WHERE  FbPeriodeID = @PreviousFbPeriodeID AND
                      KontoNr = KTO.KontoNr) +
              (SELECT IsNull(SUM(Betrag),0)
               FROM   FbBuchung
               WHERE  FbPeriodeID = @PreviousFbPeriodeID AND
                      SollKtoNr = KTO.KontoNr) -
              (SELECT IsNull(SUM(Betrag),0)
               FROM   FbBuchung
               WHERE  FbPeriodeID = @PreviousFbPeriodeID AND
                      HabenKtoNr = KTO.KontoNr) ,0)
      FROM   FbKonto KTO
      WHERE  FbPeriodeID = @CurrFbPeriodeID AND
             KontoKlasseCode in (1,2) -- Aktiven + Passiven

    SET @PreviousFbPeriodeID = @CurrFbPeriodeID

    FETCH NEXT FROM cPeriode INTO @CurrFbPeriodeID,@CurrPeriodeStatusCode
  END
  CLOSE cPeriode
  DEALLOCATE cPeriode
GO