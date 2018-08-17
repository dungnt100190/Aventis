SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgSaldiVortragen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgSaldiVortragen.sql $
  $Author: Mmarghitola $
  $Modtime: 21.06.10 1:04 $
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
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgSaldiVortragen.sql $
 * 
 * 5     21.06.10 1:12 Mmarghitola
 * #5908: Saldi vortragen korrigieren
 * 
 * 4     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 3     12.05.09 12:05 Mweber
 *
 * 1     12.5.09 MWeber
 *       Bilanzkonti mit Saldo automatisch anlegen in Folgeperiode

=================================================================================================*/

CREATE PROCEDURE [dbo].[spKgSaldiVortragen]
 (@BaPersonID int)
AS
  DECLARE @CurrKgPeriodeID  int
  DECLARE @CurrKgPeriodeStatusCode int
  DECLARE @PreviousKgPeriodeID  int

  -- loop über alle Perioden des Mandanten

  SET @PreviousKgPeriodeID = NULL

  DECLARE cPeriode CURSOR STATIC FOR
      SELECT KgPeriodeID, KgPeriodeStatusCode
      FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
             INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = PER.FaLeistungID
      WHERE  LEI.BaPersonID = @BaPersonID
      ORDER BY PER.PeriodeVon

  OPEN cPeriode
  FETCH NEXT FROM cPeriode INTO @CurrKgPeriodeID,@CurrKgPeriodeStatusCode
  WHILE @@fetch_status = 0 BEGIN

    IF @CurrKgPeriodeStatusCode = 1 AND -- aktiv
       @PreviousKgPeriodeID IS NOT NULL
    BEGIN

	  -- Konti mit Vorsaldouebertrag = 1 aus der Vorperiode anlegen, falls sie in der
      -- aktuellen Periode noch nicht existieren 

      INSERT KgKonto (KgPeriodeID,GruppeKontoID,GruppePosition,KontoGruppe,
                      KgKontoklasseCode,KgKontoartCode,KontoNr,KontoName,
                      Vorsaldo,VorsaldoUebertrag)
      SELECT @CurrKgPeriodeID,KTO4.KgKontoID,KTO.GruppePosition,KTO.KontoGruppe,
             KTO.KgKontoklasseCode,KTO.KgKontoartCode,KTO.KontoNr,KTO.KontoName,
             0,1
      FROM dbo.KgKonto KTO WITH (READUNCOMMITTED)
           LEFT JOIN dbo.KgKonto KTO2 WITH (READUNCOMMITTED) on KTO2.KontoNr = KTO.KontoNr AND
                                                                KTO2.KgPeriodeID = @CurrKgPeriodeID
           -- joins für neue GruppeKontoID
           LEFT JOIN dbo.KgKonto KTO3 WITH (READUNCOMMITTED) on KTO3.KgKontoID = KTO.GruppeKontoID AND
                                                                KTO3.KgPeriodeID = @PreviousKgPeriodeID
           LEFT JOIN dbo.KgKonto KTO4 WITH (READUNCOMMITTED) on KTO4.KontoNr = KTO3.KontoNr AND
                                                                KTO4.KgPeriodeID = @CurrKgPeriodeID
      WHERE KTO.KgPeriodeID = @PreviousKgPeriodeID AND
            KTO.VorsaldoUebertrag = 1 AND
            KTO2.KgPeriodeID IS NULL

      -- Calculate AND set new EroeffnungsSaldo
      UPDATE KgKonto
      SET    Vorsaldo = IsNull(
              (SELECT IsNull(Vorsaldo,0)
               FROM   dbo.KgKonto WITH (READUNCOMMITTED)
               WHERE  KgPeriodeID = @PreviousKgPeriodeID AND
                      KontoNr = KTO.KontoNr) +
              (SELECT IsNull(SUM(Betrag),0)
               FROM   dbo.KgBuchung WITH (READUNCOMMITTED)
               WHERE  KgPeriodeID = @PreviousKgPeriodeID AND
                      SollKtoNr = KTO.KontoNr) -
              (SELECT IsNull(SUM(Betrag),0)
               FROM   dbo.KgBuchung WITH (READUNCOMMITTED)
               WHERE  KgPeriodeID = @PreviousKgPeriodeID AND
                      HabenKtoNr = KTO.KontoNr) ,0),
            KontoName = ISNULL((SELECT KTO2.KontoName FROM KgKonto KTO2 WHERE KTO2.KgPeriodeID = @PreviousKgPeriodeID AND KTO2.KontoNr = KTO.KontoNr), KTO.KontoName)
      FROM   dbo.KgKonto KTO WITH (READUNCOMMITTED)
      WHERE  KgPeriodeID = @CurrKgPeriodeID AND
             EXISTS (SELECT TOP 1 1 FROM KgKonto KTO2 WHERE KTO2.KontoNr = KTO.KontoNr AND KTO2.KgPeriodeID = @PreviousKgPeriodeID AND KTO2.VorsaldoUebertrag = 1)
    END

    SET @PreviousKgPeriodeID = @CurrKgPeriodeID

    FETCH NEXT FROM cPeriode INTO @CurrKgPeriodeID,@CurrKgPeriodeStatusCode
  END
  CLOSE cPeriode
  DEALLOCATE cPeriode
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
