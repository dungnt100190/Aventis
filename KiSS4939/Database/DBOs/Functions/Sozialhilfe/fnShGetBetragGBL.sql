SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject fnShGetBetragGBL;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnShGetBetragGBL
(
  @BgFinanzplanID int,
  @Quoting        bit = 0,
  @Runden         bit = 1
)
RETURNS MONEY
AS BEGIN
  DECLARE @BetragGBL MONEY,
          @UE INT,
          @KuerzungAbAngepasstemGrundbedarf BIT;
  
  SELECT @KuerzungAbAngepasstemGrundbedarf = CONVERT(BIT, dbo.fnXConfig('System\Sozialhilfe\KuerzungAbAngepasstemGrundbedarf', GETDATE()));

  SELECT @BetragGBL = CASE 
                        WHEN @KuerzungAbAngepasstemGrundbedarf = 1  THEN BPO.BetragFinanzplan                              
                        ELSE BPO.Betrag 
                      END,
         @UE        = FPP.UE
  FROM dbo.BgFinanzplan           BFP
    INNER JOIN dbo.BgBudget       BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID 
                                                            AND BBG.Masterbudget = 1
    INNER JOIN dbo.vwBgPosition   BPO WITH (READUNCOMMITTED) ON BBG.BgBudgetID = BPO.BgBudgetID 
    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID 
                                                            AND POA.BgPositionsartCode IN (SELECT Code 
                                                                                           FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                                                                                           WHERE LOVName = 'WhGrundbedarfTyp')
    INNER JOIN (SELECT BgFinanzplanID, 
                       UE = COUNT(*)
                FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
                WHERE BgFinanzplanID = @BgFinanzplanID 
                  AND IstUnterstuetzt = 1
                GROUP BY BgFinanzplanID) FPP ON FPP.BgFinanzplanID = BFP.BgFinanzplanID
  WHERE BFP.BgFinanzplanID = @BgFinanzplanID
    AND BPO.DatumVon IS NULL;

  IF @Quoting = 1 
  BEGIN
    IF @Runden = 1 
    BEGIN
      SET @BetragGBL = FLOOR((@BetragGBL / @UE) * 20.0 + 0.5) / 20.0;
    END
    ELSE 
    BEGIN
      SET @BetragGBL = @BetragGBL / @UE;
    END;
  END;

  RETURN @BetragGBL;
END;
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
 