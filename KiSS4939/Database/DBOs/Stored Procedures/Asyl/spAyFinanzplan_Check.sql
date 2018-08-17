SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyFinanzplan_Check
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Check.sql $
  $Author: Ckaeser $
  $Modtime: 25.09.09 15:30 $
  $Revision: 4 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Check.sql $
 * 
 * 4     25.09.09 15:31 Ckaeser
 * Korrektur KST
 * 
 * 3     24.09.09 8:44 Lgreulich
 * Umbau KbKostenstelle -> KbKostenstelle_BaPerson
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyFinanzplan_Check
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyFinanzplan_Check
 (@BgFinanzplanID  int,
  @UserID          int)
AS 

BEGIN
  DECLARE @BgBudgetID  int
  SELECT @BgBudgetID = BgBudgetID FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 1

    SELECT 0 AS Typ, 'Es wird keine Person unterstützt'
    WHERE NOT EXISTS (SELECT 1 FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1)
  UNION ALL
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': bereits unterstützt im Masterbudget ' + CONVERT(varchar,SFP2.BgFinanzplanID)
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgFinanzplan_BaPerson SPP  WITH (READUNCOMMITTED) ON SPP.BgFinanzplanID = SFP.BgFinanzplanID AND
                                               SPP.IstUnterstuetzt = 1
      INNER JOIN dbo.BgFinanzplan_BaPerson SPP2 WITH (READUNCOMMITTED) ON SPP2.BaPersonID = SPP.BaPersonID AND
                                               SPP2.IstUnterstuetzt = 1 AND
                                               SPP2.BgFinanzplanID <> SPP.BgFinanzplanID
      INNER JOIN dbo.BgFinanzplan          SFP2 WITH (READUNCOMMITTED) ON SFP2.BgFinanzplanID = SPP2.BgFinanzplanID AND
                                               SFP2.BgBewilligungStatusCode >= 5 AND -- bewilligt, aktiv | bewilligt, abgelaufen
                                               (IsNull(SFP.DatumVon, SFP.GeplantVon) BETWEEN SFP2.DatumVon AND SFP2.DatumBis
                                                  OR COALESCE(SFP.DatumBis, SFP.GeplantBis, '99991231') BETWEEN SFP2.DatumVon AND SFP2.DatumBis)
      INNER JOIN dbo.BaPerson              PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID AND
          SFP.BgBewilligungStatusCode < 5

  UNION ALL
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': Kostenstelle'
    FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SPP.BgFinanzplanID = @BgFinanzplanID AND SPP.IstUnterstuetzt = 1
      AND NOT EXISTS(SELECT 1
                     FROM dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) 
                       INNER JOIN KbKostenstelle      KOS WITH (READUNCOMMITTED) ON KOS.KbKostenstelleID = KST.KbKostenstelleID
                     WHERE KST.BaPersonID = SPP.BaPersonID AND KOS.Aktiv = 1)

  UNION ALL
    SELECT 0, PRS.Name + ', ' + PRS.Vorname + ': Zahlungsweg'
    FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
    WHERE SPP.BgFinanzplanID = @BgFinanzplanID AND SPP.IstUnterstuetzt = 1
      AND SPP.BaZahlungswegID IS NULL

  ORDER BY 1, 2
END
GO