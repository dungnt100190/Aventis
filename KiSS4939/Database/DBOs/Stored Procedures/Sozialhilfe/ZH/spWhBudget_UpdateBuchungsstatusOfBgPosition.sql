SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spWhBudget_UpdateBuchungsstatusOfBgPosition]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spWhBudget_UpdateBuchungsstatusOfBgPosition]
GO
CREATE PROCEDURE [dbo].[spWhBudget_UpdateBuchungsstatusOfBgPosition]
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

  DECLARE @Count int

  -- Nettobelege aus meheren BgPositionen
  SELECT @Count = Count(*)
  FROM   KbBuchungKostenart
  WHERE  BgPositionID <> @BgPositionID AND KbBuchungID IN
  (
    SELECT KbBuchungID
    FROM   KbBuchungKostenart
    WHERE  BgPositionID = @BgPositionID
  )	

  IF (@Count > 0) BEGIN
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
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
