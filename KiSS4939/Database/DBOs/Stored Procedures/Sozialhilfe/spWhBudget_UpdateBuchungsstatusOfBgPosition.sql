SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_UpdateBuchungsstatusOfBgPosition
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_UpdateBuchungsstatusOfBgPosition.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:12 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_UpdateBuchungsstatusOfBgPosition.sql $
 * 
 * 2     25.06.09 8:47 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhBudget_UpdateBuchungsstatusOfBgPosition
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBudget_UpdateBuchungsstatusOfBgPosition
 (
  @BgPositionID           int,
  @BuchungsStatusCode     int,
  @BuchungsStatusCode_alt int
 )
AS BEGIN
  /*
  */
  SET NOCOUNT ON

  IF( @BuchungsStatusCode NOT IN (1,2,7) )
  BEGIN
    RAISERROR ( 'Der Parameter @BuchungsStatusCode enthält einen ungültigen Wert!', 18, 1)
    RETURN -1
  END

  DECLARE @COUNT int

  -- Nettobelege aus meheren BgPositionen
  SELECT @COUNT = COUNT(*)
  FROM   dbo.KbBuchungKostenart WITH (READUNCOMMITTED) 
  WHERE  BgPositionID <> @BgPositionID AND KbBuchungID IN
  (
    SELECT KbBuchungID
    FROM   dbo.KbBuchungKostenart WITH (READUNCOMMITTED) 
    WHERE  BgPositionID = @BgPositionID
  )

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Für diese Budgetposition gibt es Nettobelege, in die noch andere Budgetpositionen einfliessen!', 18, 1)
    RETURN -1
  END

  UPDATE KbBuchung
    SET  KbBuchungStatusCode = @BuchungsStatusCode
  FROM   KbBuchung KBU
    INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
  WHERE  BgPositionID = @BgPositionID AND KBU.KbBuchungStatusCode = @BuchungsStatusCode_alt --IN (1,2,7)

  UPDATE KbBuchungBrutto
    SET  KbBuchungStatusCode = @BuchungsStatusCode
  WHERE  BgPositionID = @BgPositionID AND KbBuchungStatusCode = @BuchungsStatusCode_alt --IN (1,2,7)

END
GO