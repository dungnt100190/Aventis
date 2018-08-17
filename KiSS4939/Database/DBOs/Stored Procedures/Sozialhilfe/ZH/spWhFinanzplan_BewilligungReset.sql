SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_BewilligungReset
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

CREATE PROCEDURE dbo.spWhFinanzplan_BewilligungReset
 (@BgFinanzplanID int,
  @UserID         int)
AS BEGIN

  DECLARE @BgBudgetID     INT
  DECLARE @COUNT INT
  DECLARE @msg   varchar(200)

  /************************************************************************************************/
  /* Check grüne/rote Monatsbudgets                                                                    */
  /************************************************************************************************/

  SELECT @COUNT = COUNT(*)
  FROM   dbo.BgBudget WITH (READUNCOMMITTED)
  WHERE  BgFinanzplanID = @BgFinanzplanID AND
         MasterBudget = 0 AND
         BgBewilligungStatusCode >= 5

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Für diesen Finanzplan gibt es bereits grüne/rote Monatsbudgets!'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  /************************************************************************************************/
  /* Alle grauen Monatsbudgets löschen                                                                             */
  /************************************************************************************************/
  DECLARE cBgBudget CURSOR FAST_FORWARD FOR
    SELECT BgBudgetID
    FROM   dbo.BgBudget WITH (READUNCOMMITTED)
    WHERE  BgFinanzplanID = @BgFinanzplanID AND
           MasterBudget = 0 AND
           BgBewilligungStatusCode = 1

  OPEN cBgBudget
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cBgBudget INTO @BgBudgetID
    IF @@FETCH_STATUS < 0 BREAK
    EXECUTE dbo.spWhBudget_Delete @BgBudgetID
    DELETE dbo.BgBudget WHERE BgBudgetID = @BgBudgetID
  END
  CLOSE cBgBudget
  DEALLOCATE cBgBudget

  /************************************************************************************************/
  /* BgPosition: Bewilligungs-Info und Spezialkonto zurücksetzen                                  */
  /************************************************************************************************/

  UPDATE BPO
  SET    BewilligtVon            = NULL,
         BewilligtBis            = NULL,
         BewilligtBetrag         = NULL,
         FPPosition              = NULL,
         BgSpezkontoID           = NULL,
         BgBewilligungStatusCode = 1
  FROM   dbo.BgPosition BPO WITH (READUNCOMMITTED)
         INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
  WHERE  BDG.BgFinanzplanID = @BgFinanzplanID AND
         BDG.MasterBudget = 1

  /************************************************************************************************/
  /* angelegte, unbebuchte Spezialkonti wieder löschen ?                                          */
  /************************************************************************************************/


  /************************************************************************************************/
  /* BgBudget: Bewilligungs-Status zurücksetzen                                                   */
  /************************************************************************************************/

  UPDATE dbo.BgBudget
  SET    BgBewilligungStatusCode = 1
  WHERE  BgFinanzplanID = @BgFinanzplanID AND
         MasterBudget = 1

  /************************************************************************************************/
  /* BgFinanzplan: Bewilligungsinfo und -Status zurücksetzen                                      */
  /************************************************************************************************/

  UPDATE dbo.BgFinanzplan
  SET    DatumVon = NULL,
         DatumBis = NULL,
         BgBewilligungStatusCode = 1
  WHERE  BgFinanzplanID = @BgFinanzplanID

  /************************************************************************************************/
  /* Eintrag Bewilligungsverlauf                                                                  */
  /************************************************************************************************/

  INSERT BgBewilligung (BgFinanzplanID, UserID, Datum, BgBewilligungCode, Bemerkung)
  VALUES (@BgFinanzplanID,@UserID,GetDate(),9,'mit Spezialrecht')

  /************************************************************************************************/
  /* Eintrag Fallverlaufsprotokoll muss von aufrufender Routine gemacht werden                    */
  /************************************************************************************************/

  /************************************************************************************************/
  /* WV-Einheiten anpassen                                                                        */
  /************************************************************************************************/
  DECLARE @FaFallID INT
  SELECT @FaFallID = FaFallID
  FROM dbo.BgFinanzplan   BFP
    INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = BFP.FaLeistungID
  WHERE BFP.BgFinanzplanID = @BgFinanzplanID
  
  EXECUTE spWhWVModifyUnits @FaFallID, 0

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
