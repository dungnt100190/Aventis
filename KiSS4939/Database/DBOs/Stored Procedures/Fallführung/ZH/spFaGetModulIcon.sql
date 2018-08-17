SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetModulIcon
GO
/*===============================================================================================
  $Revision: 4$
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

CREATE PROCEDURE dbo.spFaGetModulIcon
 (@BaPersonID   int,
  @FaFallID     int = NULL,
  @TreeExists   bit = 0)
AS BEGIN
  SELECT MOD.ModulID, MOD.ShortName,
    IconID = 1000 + 100 * MOD.ModulID + IsNull(MIN(
      CASE
        WHEN MOD.ModulID = 1 AND PRS.BaPersonID IS NOT NULL  THEN 1 -- Basis
--        WHEN MOD.ModulID = 2 AND FAL.FaFallID IS NOT NULL    THEN 1 -- Fallfuehrung
        WHEN FLE.FaLeistungID IS NULL                        THEN NULL
        WHEN ARC.FaLeistungID IS NOT NULL                    THEN 3
        WHEN FLE.DatumBis IS NOT NULL                        THEN 2
        ELSE 1
      END), 0)
  FROM dbo.XModul                    MOD WITH (READUNCOMMITTED)
    LEFT OUTER JOIN dbo.XClass            CLS WITH (READUNCOMMITTED) ON CLS.BaseType = 'KiSS4.Common.KissModulTree' AND CLS.ModulID = MOD.ModulID
    LEFT OUTER JOIN dbo.BaPerson          PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = @BaPersonID
    LEFT OUTER JOIN dbo.FaFall            FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = PRS.BaPersonID AND FAL.FaFallID = IsNull(@FaFallID, FAL.FaFallID)
    LEFT OUTER JOIN dbo.FaLeistung        FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID AND FLE.ModulID = MOD.ModulID
    LEFT OUTER JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE MOD.ModulTree = 1 AND MOD.ShortName IS NOT NULL
    AND (@TreeExists = 0 OR CLS.ClassName IS NOT NULL)
  GROUP BY MOD.ModulID, MOD.ShortName, MOD.SortKey
  ORDER BY MOD.SortKey, MOD.ModulID, MOD.ShortName
END

