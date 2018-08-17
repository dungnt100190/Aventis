SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaFall_GetActive
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
/*
===================================================================================================
Author:      sozheo
Create date: 15.07.2008
Description: Holen des aktiven oder des letzten inaktiven Falles

===================================================================================================
History:
15.07.2008 : sozheo : neu erstellt

===================================================================================================
*/
CREATE PROCEDURE [dbo].[spFaFall_GetActive]
  -- BaPersonID
  @BaPersonID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON


  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF @BaPersonID IS NULL OR @BaPersonID = 0 BEGIN
    RAISERROR ('Der Aufruf-Parameter @BaPersonID ist ungültig (spFaFall_GetActive).', 18, 1)
    RETURN -1
  END

  DECLARE
    @FaFallID INT,
    @DatumBis DATETIME


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

  -- Resultat zurückliefern
  -- ---------------------------------------------------------------------
  SELECT 
    FaFallID = @FaFallID,
    DatumBis = @DatumBis

  RETURN 1
END

