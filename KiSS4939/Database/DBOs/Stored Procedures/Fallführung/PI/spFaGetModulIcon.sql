SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetModulIcon
GO
/*===============================================================================================
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
=================================================================================================*/

CREATE PROCEDURE dbo.spFaGetModulIcon
(
  @BaPersonID   int,
  @FaFallID     int = NULL, -- wird noch nicht verwendet
  @TreeExists   bit = 0
)
AS BEGIN
  -- Iconoffsets für Modulstati:
  DECLARE @OffActive   INT
  DECLARE @OffDisable  INT
  DECLARE @OffClosed   INT
  SET @OffActive   = 1
  SET @OffClosed   = 2
  SET @OffDisable  = 0

  -- use temporary table
  DECLARE @TmpModulIcons TABLE 
  (
    ModulID int not null,
    ShortName varchar(255),
    IconID int,
    OrderID int
  )

  -- add default icons
  INSERT INTO @TmpModulIcons (ModulID, ShortName, IconID, OrderID)
    SELECT MOD.ModulID, 
           MOD.ShortName,
           IconID = 1000 + 100 * MOD.ModulID + IsNull(CASE WHEN MOD.ModulID = 1 AND PRS.BaPersonID IS NOT NULL  THEN 1 -- Basis
                                                           ELSE IsNull((SELECT TOP 1 CASE WHEN LEI.DatumBis IS NULL THEN @OffActive
                                                                                          ELSE @OffClosed
                                                                                     END
                                                                         FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                                         WHERE  BaPersonID = PRS.BaPersonID AND LEI.ModulID = MOD.ModulID
                                                                         ORDER BY CASE  WHEN LEI.DatumBis IS NULL THEN 0
                                                                                        ELSE 1
                                                                                  END, LEI.DatumVon DESC
                                                                      ), @OffDisable)
                                                      END, 0),
          OrderID = CASE WHEN MOD.ModulID IN (1, 2) THEN MOD.ModulID
                         ELSE MOD.ModulID + 1
                    END
  FROM dbo.XModul                    MOD WITH (READUNCOMMITTED)
    LEFT  JOIN dbo.XClass            CLS WITH (READUNCOMMITTED) ON CLS.BaseType = 'KiSS4.Common.KissModulTree' AND CLS.ModulID = MOD.ModulID
    LEFT  JOIN dbo.BaPerson          PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = @BaPersonID
  WHERE MOD.ModulTree = 1 AND MOD.ShortName IS NOT NULL AND (@TreeExists = 0 OR CLS.ClassName IS NOT NULL)
  ORDER BY MOD.ModulID, MOD.ShortName

  -- check if need to add icons (only if tree does not have to exist)
  IF(@TreeExists = 0)
  BEGIN
    -- add empty icons between module and dienstleistungen
    INSERT INTO @TmpModulIcons (ModulID, ShortName, IconID, OrderID)
    VALUES(0, '', 0, 3)
  END

  -- show content
  SELECT *
  FROM @TmpModulIcons
  ORDER BY OrderID
END
GO