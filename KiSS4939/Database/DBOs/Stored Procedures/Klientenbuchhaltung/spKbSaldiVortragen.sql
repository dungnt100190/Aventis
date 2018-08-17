SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbSaldiVortragen
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Klientenbuchhaltung/spKbSaldiVortragen.sql $
  $Author: Rstahel $
  $Modtime: 24.09.10 16:57 $
  $Revision: 12 $
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
 */
CREATE PROCEDURE dbo.spKbSaldiVortragen
 (@CurrKbPeriodeID int)
AS

  DECLARE @CurrPeriodeStatusCode int
  --DECLARE @PreviousKbPeriodeID   int
  DECLARE @SuccessorKbPeriodeID   int
  DECLARE @KbMandantID           int -- MandantID of @CurrKbPeriodeID
  
  SELECT @KbMandantID = KbMandantID
  FROM dbo.KbPeriode PRD WITH (READUNCOMMITTED)
  WHERE PRD.KbPeriodeID = @CurrKbPeriodeID
							  
  -- Nachfolge-Periode des Mandanten Suchen
  SET @SuccessorKbPeriodeID = (SELECT TOP 1 SUC.KbPeriodeID
         					   FROM dbo.KbPeriode         SUC WITH (READUNCOMMITTED)
							     INNER JOIN dbo.KbPeriode CURR WITH (READUNCOMMITTED) ON CURR.KbPeriodeID = @CurrKbPeriodeID
							   WHERE SUC.PeriodeVon > CURR.PeriodeVon
							     AND SUC.KbMandantID = CURR.KbMandantID
							   ORDER BY SUC.PeriodeVon)

  /************************************************************************************************/
  /* Beträge plausibilisieren                                                                     */
  /************************************************************************************************/
--  IF @PreviousKbPeriodeID IS NULL BEGIN
--    SET @msg = 'Es gibt keine VorgängerPeriode'
--    RAISERROR(@msg, 18, 1)
--    RETURN -1
--  END
  
    IF @SuccessorKbPeriodeID IS NOT NULL BEGIN
      -- Calculate and set new EroeffnungsSaldo
      UPDATE KbKonto
      SET Vorsaldo = IsNull(
              (-- VorSaldo der vorangehenden Periode
               SELECT IsNull(Vorsaldo, 0)
               FROM dbo.KbKonto WITH (READUNCOMMITTED)
               WHERE KbPeriodeID = @CurrKbPeriodeID
                 AND KontoNr = KTO.KontoNr)
              +(-- addiere alle SOLL-Buchungen
               IsNull((SELECT SUM(Betrag)
                       FROM dbo.fnKbGetRelevanteBuchungen(@CurrKbPeriodeID, NULL, NULL, 0, 0) REB1
                         WHERE REB1.SollKtoNr = KTO.KontoNr), 0))
              -(-- subtrahiere alle HABEN-Buchungen
               IsNull((SELECT SUM(Betrag)
                         FROM dbo.fnKbGetRelevanteBuchungen(@CurrKbPeriodeID, NULL, NULL, 0, 0) REB2
                         WHERE REB2.HabenKtoNr = KTO.KontoNr), 0)), 0)
      FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
      WHERE KbPeriodeID = @SuccessorKbPeriodeID
        --AND KbKontoKlasseCode in (5,6)-- Aktiven + Passiven
        -- Es wird nicht mehr nach Kontos unterschieden. Es wird nur noch geschaut, ob 
        -- das SaldoVortrag-Flag der aktuellen gesetzt ist.
        AND EXISTS (SELECT 1 FROM dbo.KbKonto oldKonto WITH (READUNCOMMITTED) 
                    WHERE oldKonto.KbPeriodeId = @CurrKbPeriodeID 
                      AND oldKonto.KontoNr = KTO.KontoNr 
                      AND oldKonto.SaldoVortrag = 1) 

END

GO