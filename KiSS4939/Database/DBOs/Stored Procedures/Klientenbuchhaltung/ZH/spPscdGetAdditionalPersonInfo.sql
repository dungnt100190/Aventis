SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spPscdGetAdditionalPersonInfo
GO
/*===============================================================================================
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
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spPscdGetAdditionalPersonInfo
(
  @BaPersonID int
)
AS


DECLARE @BgFinanzplanID int
DECLARE @UntPersImHaushalt int
DECLARE @IstUnterstuetzungstraeger bit
DECLARE @WVEinheitID int

SELECT @BgFinanzplanID = FIP.BgFinanzplanID
FROM dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgFinanzplan  FIP WITH (READUNCOMMITTED) ON FIP.BgFinanzplanID = FPP.BgFinanzplanID
WHERE BaPersonID = @BaPersonID
  AND BgBewilligungStatusCode = 5 AND DatumVon IS NOT NULL AND DatumBis IS NOT NULL
ORDER BY CASE WHEN GetDate() BETWEEN DatumVon AND DatumBis THEN dbo.fnDateSerial(9999,1,1) ELSE DatumVon END DESC

SELECT @UntPersImHaushalt = COUNT(*)
FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
WHERE BgFinanzplanID = @BgFinanzplanID
  AND IstUnterstuetzt = 1


SELECT @WVEinheitID = WVM.WhWVEinheitID, @IstUnterstuetzungstraeger = CASE WHEN WVM.BaPersonID = WVE.BaPersonID THEN 1 ELSE 0 END
FROM dbo.WhWVEinheitMitglied WVM WITH (READUNCOMMITTED)
  INNER JOIN dbo.WhWVEinheit WVE WITH (READUNCOMMITTED) ON WVE.WhWVEinheitID = WVM.WhWVEinheitID
WHERE WVM.BaPersonID = @BaPersonID
  AND GetDate() BETWEEN DatumVon AND IsNull(DatumBis,dbo.fnDateSerial(9999,1,1))


SELECT     GMD.Name AS Heimatort, XLC.ShortText AS WVCode, WVC.DatumVon, WVC.DatumBis, @WVEinheitID AS WVEinheit, @UntPersImHaushalt AS WVPersonen, @IstUnterstuetzungstraeger AS WVTraeger
FROM         dbo.BaPerson AS PRS WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.BaGemeinde AS GMD WITH (READUNCOMMITTED) ON GMD.BaGemeindeID = PRS.HeimatgemeindeCode
  LEFT OUTER JOIN dbo.BaWVCode AS WVC WITH (READUNCOMMITTED) ON WVC.BaWVCodeID =
                          (SELECT     TOP (1) BaWVCodeID
                            FROM          dbo.BaWVCode WITH (READUNCOMMITTED)
                            WHERE      (BaPersonID = PRS.BaPersonID) AND (BaWVStatusCode = 1) AND GetDate() BETWEEN DatumVon AND IsNull(DatumBis, dbo.fnDateSerial(9999,12,31))
                            ORDER BY DatumVon DESC)
  LEFT OUTER JOIN dbo.XLOVCode AS XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BaWVCode' AND XLC.Code = WVC.WVCode
WHERE     (PRS.BaPersonID = @BaPersonID)

