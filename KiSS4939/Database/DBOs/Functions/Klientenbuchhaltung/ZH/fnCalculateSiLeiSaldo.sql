SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnCalculateSiLeiSaldo
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnCalculateSiLeiSaldo.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 10:24 $
  $Revision: 6 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnCalculateSiLeiSaldo.sql $
 * 
 * 6     11.12.09 11:00 Lloreggia
 * Header aktualisiert
 * 
 * 5     30.07.09 11:25 Mminder
 * #5057: Rückläufer werden nicht mehr in den Saldo miteinbezogen
 * 
 * 4     25.07.09 12:16 Mminder
 * #4725: Performanceoptimierung
 * 
 * 3     17.07.09 23:51 Mminder
 * #4725: Korrektes Miteinbeziehen von Stornobuchungen
 * Performanceverbesserung
 * 
 * 2     7.07.09 0:09 Mminder
 * #4790: Umbuchung von Altdaten wird nun auch berücksichtigt
 * 
 * 1     26.06.09 16:34 Mminder
 * #4725: Zentraler Ort zum Berechnen des Saldo einer SiLei
=================================================================================================*/

CREATE FUNCTION [dbo].[fnCalculateSiLeiSaldo]
(
  @BaSicherheitsleistungID  int,
  @SaldoPer                 datetime 
)
 RETURNS money
AS 

BEGIN
  --SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
  DECLARE @Saldo         money,
          @LetzteBuchung datetime

  IF @SaldoPer IS NULL
    SET @SaldoPer = GETDATE()

  --Migrierte Buchungen
  SELECT @Saldo         = IsNull(SUM(MIG.Betrag),0)
         --,@LetzteBuchung = IsNull(MAX(MIG.Buchungsdatum),'1850-01-01')
  FROM dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED)
    INNER JOIN dbo.MigDetailBuchung      MIG WITH (READUNCOMMITTED) ON MIG.MigDetailBuchungID = SIP.MigDetailBuchungID
  WHERE SIP.BaSicherheitsleistungID = @BaSicherheitsleistungID AND
        MIG.KissLeistungsart IN ('320','321','860','861','862') AND
        MIG.Buchungsdatum <= @SaldoPer

  --Nettobuchungen
  SELECT @Saldo         = @Saldo + IsNull(SUM(KBK.Betrag),0)
         --,@LetzteBuchung = CASE WHEN @LetzteBuchung < MAX(KBU.ValutaDatum) AND MAX(KBU.ValutaDatum) IS NOT NULL THEN MAX(KBU.ValutaDatum) ELSE @LetzteBuchung END
  FROM dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED)
    INNER JOIN dbo.KbBuchung             KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID   = SIP.KbBuchungID
    INNER JOIN dbo.KbBuchungKostenart    KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID   = KBU.KbBuchungID
    INNER JOIN dbo.BgKostenart           BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = KBK.BgKostenartID
  WHERE SIP.BaSicherheitsleistungID = @BaSicherheitsleistungID AND
        KBU.KbBuchungStatusCode NOT IN (9) AND  --Rückläufer ausschliessen
        BKA.KontoNr IN ('320','321','860','861','862') AND
        KBU.ValutaDatum <= @SaldoPer

  --Bruttobuchungen inkl. Neubuchungen
  SELECT @Saldo         = @Saldo - IsNull(SUM(KBP.Betrag),0)
         --,@LetzteBuchung = CASE WHEN @LetzteBuchung < MAX(KBB.ValutaDatum) AND MAX(KBB.ValutaDatum) IS NOT NULL THEN MAX(KBB.ValutaDatum) ELSE @LetzteBuchung END
  FROM dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED)
    INNER JOIN dbo.KbBuchungBrutto       KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = SIP.KbBuchungBruttoID AND /*KBB.Betrag >= 0 AND*/ SIP.KbBuchungID IS NULL
    INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
    INNER JOIN dbo.BgKostenart           BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID     = IsNull(KBP.SpezBgKostenartID,KBB.BgKostenartID)
  WHERE SIP.BaSicherheitsleistungID = @BaSicherheitsleistungID AND
        BKA.KontoNr IN ('320','321','860','861','862') AND
        KBB.ValutaDatum <= @SaldoPer

  --Stornobuchungen
  SELECT @Saldo = @Saldo - IsNull(SUM(KBP.Betrag),0)
         --,@LetzteBuchung = CASE WHEN @LetzteBuchung < MAX(KBB.ValutaDatum) AND MAX(KBB.ValutaDatum) IS NOT NULL THEN MAX(KBB.ValutaDatum) ELSE @LetzteBuchung END
  FROM dbo.BaSicherheitsleistungPosition         BSP WITH(READUNCOMMITTED)
    LEFT  JOIN (SELECT DISTINCT ORP.KbBuchungBruttoID, KBK.KbBuchungID
                FROM KbBuchungBruttoPerson      ORP WITH(READUNCOMMITTED)
                  INNER JOIN KbBuchungKostenart KBK WITH(READUNCOMMITTED) ON KBK.BgPositionID = ORP.BgPositionID) KBK ON BSP.KbBuchungID = KBK.KbBuchungID
    INNER JOIN dbo.KbBuchungBrutto               ORB WITH(READUNCOMMITTED) ON BSP.KbBuchungBruttoID = ORB.KbBuchungBruttoID OR KBK.KbBuchungBruttoID = ORB.KbBuchungBruttoID
    INNER JOIN dbo.KbBuchungBrutto               KBB WITH(READUNCOMMITTED) ON ORB.KbBuchungBruttoID = KBB.StorniertKbBuchungBruttoID
    INNER JOIN dbo.KbBuchungBruttoPerson         KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
    INNER JOIN dbo.BgKostenart                   BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID     = IsNull(KBB.BgKostenartID,KBP.SpezBgKostenartID)
      WHERE BSP.BaSicherheitsleistungID = @BaSicherheitsleistungID AND
            KBB.StorniertKbBuchungBruttoID IS NOT NULL AND -- OR KBB.NeubuchungVonKbBuchungBruttoID IS NOT NULL)
            BKA.KontoNr IN ('320','321','860','861','862') AND
            KBB.ValutaDatum <= @SaldoPer

  --Umbuchungen Altdaten
  SELECT @Saldo = @Saldo - IsNull(SUM(KBP.Betrag),0)
         --,@LetzteBuchung = CASE WHEN @LetzteBuchung < MAX(KBB.ValutaDatum) AND MAX(KBB.ValutaDatum) IS NOT NULL THEN MAX(KBB.ValutaDatum) ELSE @LetzteBuchung END
  FROM BaSicherheitsleistungPosition BSP WITH(READUNCOMMITTED)
    INNER JOIN KbBuchungBrutto       KBB WITH(READUNCOMMITTED) ON BSP.MigDetailbuchungID = KBB.MigDetailbuchungID
    INNER JOIN KbBuchungBruttoPerson KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID  = KBB.KbBuchungBruttoID
    INNER JOIN BgKostenart           BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID      = KBB.BgKostenartID
  WHERE BSP.BaSicherheitsleistungID = @BaSicherheitsleistungID
    AND BKA.KontoNr in ('320','321','860','861','862')
    AND KBB.Belegart = 'UB' -- Nur die Stornobuchung, nicht die Neubuchung
    AND KBB.ValutaDatum < @SaldoPer

  RETURN @Saldo
END

