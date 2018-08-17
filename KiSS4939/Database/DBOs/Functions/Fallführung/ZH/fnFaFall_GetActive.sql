SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnFaFall_GetActive
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Holen des aktiven oder des letzten inaktiven Falles
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnFaFall_GetActive
(
  -- BaPersonID
  @BaPersonID INT
)
RETURNS @OUTPUT TABLE (
  FaFallID INT,
  DatumBis DATETIME
)
AS BEGIN

  DECLARE 
    @FaFallID INT,
    @DatumBis DATETIME

  SET @FaFallID = NULL
  SET @DatumBis = NULL

  -- Den letzetn aktiven Fall holen, sollte nur eine Zeile geben
  -- ---------------------------------------------------------------------
  SELECT TOP 1 
    @FaFallID = FaFallID, 
    @DatumBis = DatumBis
  FROM dbo.FaFall WITH (READUNCOMMITTED)
  WHERE BaPersonID = @BaPersonID
    AND DatumBis IS NULL
  ORDER BY DatumVon DESC, DatumBis DESC


  IF @FaFallID IS NULL BEGIN
    -- Es existiert kein aktiver Fall, also den letzten inaktiven holen
    -- ---------------------------------------------------------------------
    SELECT TOP 1 
      @FaFallID = FaFallID, 
      @DatumBis = DatumBis
    FROM dbo.FaFall WITH (READUNCOMMITTED) 
    WHERE BaPersonID = @BaPersonID
    ORDER BY DatumVon DESC, DatumBis DESC
  END 

  INSERT @OUTPUT
  SELECT FaFallID = @FaFallID, DatumBis = @DatumBis

  RETURN
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
