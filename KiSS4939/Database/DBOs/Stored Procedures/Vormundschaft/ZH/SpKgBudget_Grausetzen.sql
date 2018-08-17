SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgBudget_Grausetzen
GO

CREATE PROCEDURE [dbo].[spKgBudget_Grausetzen]
 (@KgBudgetID   int) -- BudgetID
AS BEGIN
    
    IF NOT( @@TRANCOUNT > 0) BEGIN
        -- Das Transaktionshandling wird vom Client durchgeführt (weniger fehleranfällig)
        RAISERROR('Keine Transaktion offen. spKgBudget_Grausetzen darf nur innerhalb einer Transaktion durchgeführt werden', 15, 1)
        RETURN -2
    END

    -- Beleg vorhanden?
    IF EXISTS
    (
      SELECT BUC.KgBuchungID
      FROM dbo.KgPosition POS
        INNER JOIN dbo.KgBuchung  BUC ON BUC.KgPositionID = POS.KgPositionID
      WHERE POS.KgBudgetID = @KgBudgetID
        AND BUC.KgBuchungStatusCode > 2
        AND BUC.KgBuchungStatusCode != 7
    )
    BEGIN
      RAISERROR('Das Budget kann nicht gelöscht werden, da bereits Buchungen mit Geldfluss existieren bzw. an PSCD übermittelt wurden.', 15, 2)
      RETURN -1
    END

    ------------
    -- Delete --
    ------------

    IF EXISTS (SELECT KgBudgetID FROM KgBudget WHERE KgBudgetID = @KgBudgetID AND KgBewilligungCode IN (5, 9)) BEGIN

        DELETE BUC
        FROM   dbo.KgBuchung BUC
            inner join dbo.KgPosition POS on POS.KgPositionID = BUC.KgPositionID
        WHERE  POS.KgBudgetID = @KgBudgetID and
            BUC.KgBuchungStatusCode in (2,7)  --grün,rot

        UPDATE dbo.KgBudget
        SET    KgBewilligungCode = 1
        WHERE  KgBudgetID = @KgBudgetID

    END

END

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
