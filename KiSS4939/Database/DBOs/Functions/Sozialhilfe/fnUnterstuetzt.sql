SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUnterstuetzt
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnUnterstuetzt.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:05 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnUnterstuetzt.sql $
 * 
 * 2     25.06.09 8:15 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnUnterstuetzt
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnUnterstuetzt
  (@FalltraegerID   int,
   @BaPersonID     int,
   @RefDate         datetime)
  RETURNS bit
AS BEGIN
  IF EXISTS (SELECT 1
             FROM dbo.BgFinanzplan_BaPerson          SDP WITH (READUNCOMMITTED) 
               INNER JOIN dbo.BgFinanzplan            SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SDP.BgFinanzplanID
               INNER JOIN dbo.BgFinanzplan_BaPerson  FAL WITH (READUNCOMMITTED) ON FAL.BgFinanzplanID = SFP.BgFinanzplanID
             WHERE SDP.BaPersonID = @BaPersonID AND SDP.IstUnterstuetzt = 1
               AND @RefDate BETWEEN SFP.DatumVon AND IsNull(SFP.DatumBis, @RefDate)
               AND FAL.BaPersonID = @FalltraegerID AND FAL.IstUnterstuetzt = 1)
  RETURN 1

  IF EXISTS (SELECT 1 FROM dbo.BaPerson WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID AND Unterstuetzt = 1) OR
     EXISTS (SELECT 1
             FROM dbo.BgFinanzplan_BaPerson          SDP WITH (READUNCOMMITTED) 
               INNER JOIN dbo.BgFinanzplan            SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SDP.BgFinanzplanID
             WHERE SDP.BaPersonID = @BaPersonID AND SDP.IstUnterstuetzt = 1
               AND @RefDate BETWEEN SFP.DatumVon AND IsNull(SFP.DatumBis, @RefDate))
  BEGIN
    IF EXISTS (SELECT 1
               FROM dbo.BgFinanzplan_BaPerson          SDP WITH (READUNCOMMITTED) 
                 INNER JOIN dbo.BgFinanzplan            SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SDP.BgFinanzplanID
               WHERE SDP.BaPersonID = @FalltraegerID AND SDP.IstUnterstuetzt = 1
                 AND @RefDate BETWEEN SFP.DatumVon AND IsNull(SFP.DatumBis, @RefDate)) OR
       EXISTS (SELECT 1
               FROM dbo.BgFinanzplan_BaPerson          SDP WITH (READUNCOMMITTED) 
                 INNER JOIN dbo.BgFinanzplan            SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SDP.BgFinanzplanID
               WHERE SDP.BaPersonID = @BaPersonID AND SDP.IstUnterstuetzt = 1
                 AND @RefDate BETWEEN SFP.DatumVon AND IsNull(SFP.DatumBis, @RefDate))
      RETURN NULL
    ELSE
      RETURN 1
  END

  RETURN 0
END
GO