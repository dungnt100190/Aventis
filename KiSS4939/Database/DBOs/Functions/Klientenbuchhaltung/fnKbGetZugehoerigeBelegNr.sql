SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbGetZugehoerigeBelegNr
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnKbGetZugehoerigeBelegNr.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:00 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnKbGetZugehoerigeBelegNr.sql $
 * 
 * 2     24.06.09 16:22 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnKbGetZugehoerigeBelegNr
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.07.2008 15:08
*/
-------------------------------------------------------------------------------
-- CALL:              Use this function to get a corresponding BelegNr of given BelegNr.

--   @KbBuchungID:       The given KbBuchungID
--   @InputTypCode:      The Type of Buchung of the given KbBuchungID 1: Original 2: Storno 3: Neubuchung
--   @OutputTypCode:     The Type of Buchung of the desired Result    1: Original 2: Storno 3: Neubuchung

-- RETURNS:              BelegNr
-- 
-- TEST: SELECT * FROM dbo.fnKbGetZugehoerigeBelegNr](1517797)  -- Originalbuchung
--       SELECT * FROM dbo.fnKbGetZugehoerigeBelegNr](1517937)  -- Stornobuchung
--       SELECT * FROM dbo.fnKbGetZugehoerigeBelegNr](1517938)  -- Neubuchung

-------------------------------------------------------------------------------
CREATE FUNCTION dbo.fnKbGetZugehoerigeBelegNr
 (@KbBuchungID   int)
RETURNS
  @OUTPUT TABLE (
    OriginalBelegNr   int,
    StornoBelegNr     int,
    NeubuchungBelegNr int
  )
AS 

BEGIN
  DECLARE @InputTypCode INT 

  SELECT 
    @InputTypCode = CASE
                      WHEN StorniertKbBuchungID IS NULL AND NeubuchungVonKbBuchungID IS NULL THEN 1
                      WHEN StorniertKbBuchungID IS NOT NULL AND NeubuchungVonKbBuchungID IS NULL THEN 2
                      WHEN StorniertKbBuchungID IS NULL AND NeubuchungVonKbBuchungID IS NOT NULL THEN 3
                    END
  FROM dbo.KbBuchung WITH (READUNCOMMITTED) 
  WHERE KbBuchungID = @KbBuchungID

 
  IF @InputTypCode = 1  --Original:
  BEGIN
     INSERT INTO @OUTPUT(OriginalBelegNr, StornoBelegNr, NeubuchungBelegNr)
     SELECT 
       OriginalBelegNr   = BUC1.BelegNr,
       StornoBelegNr     = BUC2.BelegNr,
       NeubuchungBelegNr = BUC3.BelegNr
     FROM dbo.KbBuchung        BUC1 WITH (READUNCOMMITTED) 
       LEFT JOIN dbo.KbBuchung BUC2 WITH (READUNCOMMITTED) ON BUC2.StorniertKbBuchungID = BUC1.KbBuchungID
       LEFT JOIN dbo.KbBuchung BUC3 WITH (READUNCOMMITTED) ON BUC3.NeubuchungVonKbBuchungID = BUC1.KbBuchungID
     WHERE BUC1.KbBuchungID = @KbBuchungID
  END
  ELSE IF @InputTypCode = 2 --Storno:
  BEGIN
     INSERT INTO @OUTPUT(OriginalBelegNr, StornoBelegNr, NeubuchungBelegNr)
     SELECT 
       OriginalBelegNr   = BUC2.BelegNr,
       StornoBelegNr     = BUC1.BelegNr,
       NeubuchungBelegNr = BUC3.BelegNr
     FROM dbo.KbBuchung        BUC1 WITH (READUNCOMMITTED) 
       LEFT JOIN dbo.KbBuchung BUC2 WITH (READUNCOMMITTED) ON BUC2.KbBuchungID = BUC1.StorniertKbBuchungID 
       LEFT JOIN dbo.KbBuchung BUC3 WITH (READUNCOMMITTED) ON BUC3.NeubuchungVonKbBuchungID = BUC2.KbBuchungID
    WHERE BUC1.KbBuchungID = @KbBuchungID
   END
   ELSE IF @InputTypCode = 3 --Neubuchung
   BEGIN
     INSERT INTO @OUTPUT(OriginalBelegNr, StornoBelegNr, NeubuchungBelegNr)
     SELECT 
       OriginalBelegNr   = BUC2.BelegNr,
       NeubuchungBelegNr = BUC1.BelegNr,
       StornoBelegNr     = BUC3.BelegNr
     FROM dbo.KbBuchung        BUC1 WITH (READUNCOMMITTED) 
       LEFT JOIN dbo.KbBuchung BUC2 WITH (READUNCOMMITTED) ON BUC2.KbBuchungID = BUC1.NeubuchungVonKbBuchungID 
       LEFT JOIN dbo.KbBuchung BUC3 WITH (READUNCOMMITTED) ON BUC3.StorniertKbBuchungID = BUC2.KbBuchungID
     WHERE BUC1.KbBuchungID = @KbBuchungID
   END
   
   RETURN
END
GO