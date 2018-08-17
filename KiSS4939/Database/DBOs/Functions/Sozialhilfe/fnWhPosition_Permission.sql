SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhPosition_Permission
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnWhPosition_Permission.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:07 $
  $Revision: 3 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnWhPosition_Permission.sql $
 * 
 * 3     25.06.09 8:17 Ckaeser
 * Alter2Create
 * 
 * 2     15.12.08 13:03 Ckaeser
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnWhPosition_Permission
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnWhPosition_Permission
 (@BgPositionID   int,
  @UserID         int)
  RETURNS bit

BEGIN
  DECLARE @PermissionGroupID  int,
          @BgKategorieCode    int,
          @BgPositionartID    int,
          @Betrag             money,
          @WhHilfeTypCode     int

  SELECT 
    @PermissionGroupID = CASE WHEN LST.UserID = @UserID THEN USR.PermissionGroupID ELSE USR.GrantPermGroupID END,
    @BgKategorieCode = BgKategorieCode, 
    @BgPositionartID = BgPositionsartID, 
    @Betrag          = Betrag,
    @WhHilfeTypCode  = BFP.WhHilfeTypCode
  FROM dbo.BgPosition            BPO WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID     = BPO.BgBudgetID
    INNER JOIN dbo.BgFinanzPlan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzPlanID = BBG.BgFinanzPlanID
    INNER JOIN dbo.FaLeistung    LST WITH (READUNCOMMITTED) ON LST.FaLeistungID   = BFP.FaLeistungID
    INNER JOIN dbo.XUser         USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID
  WHERE BgPositionID = @BgPositionID

  IF @BgKategorieCode = 100
    AND EXISTS (SELECT 1 FROM dbo.XPermissionValue WITH (READUNCOMMITTED) 
                WHERE PermissionGroupID = @PermissionGroupID
                  AND BgPositionsartID = @BgPositionartID
                  AND CONVERT(money, Value) >= @Betrag)
    RETURN 1

  IF @BgKategorieCode <> 100
    AND EXISTS (SELECT 1 FROM dbo.XPermissionValue WITH (READUNCOMMITTED) 
                WHERE PermissionGroupID = @PermissionGroupID
                  AND PermissionCode = CASE WHEN @WhHilfeTypCode = 1 THEN  6 -- Überbrückungshilfe	--> Sozialhilfe: FP Überbrückung - Wiederkehrende SIL's
                                            WHEN @WhHilfeTypCode = 2 THEN  2 -- reg. Sozialhilfe	--> Sozialhilfe: FP Normal - Wiederkehrende SIL's
                                            ELSE -9999
                                       END
                  AND CONVERT(money, Value) >= @Betrag)
    RETURN 1

  RETURN 0
END
GO