SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgBudget_Delete
GO

CREATE PROCEDURE [dbo].[spKgBudget_Delete]
 (@KgBudgetID   int) -- BudgetID oder MasterbudgetID
AS BEGIN
  IF NOT( @@TRANCOUNT > 0) BEGIN
    -- Das Transaktionshandling wird vom Client durchgeführt (weniger fehleranfällig)
    RAISERROR('Keine Transaktion offen. spKgBudget_Delete darf nur innerhalb einer Transaktion durchgeführt werden', 15, 1)
    RETURN -2
  END
  BEGIN TRY

    -- Beleg vorhanden?
    IF EXISTS
    (
      SELECT BUC.KgBuchungID
        --,Position = 'Monatsbudget ' + dbo.fnLOVShortText('Monat', BUD.Monat) + ' ' + CONVERT(varchar, BUD.Jahr) + ', ' + dbo.fnLOVText('KgPositionsKategorie', POS.KgPositionsKategorieCode) + ': ' + POS.Buchungstext + ' à '  + CONVERT(varchar, POS.Betrag)
      FROM dbo.KgBudget         BUD
        INNER JOIN dbo.KgPosition POS ON POS.KgBudgetID = BUD.KgBudgetID
        INNER JOIN dbo.KgBuchung  BUC ON BUC.KgPositionID = POS.KgPositionID
      WHERE BUC.KgBuchungStatusCode > 2
        AND BUC.KgBuchungStatusCode != 7
        AND (BUD.KgMasterBudgetID = @KgBudgetID OR BUD.KgBudgetID = @KgBudgetID) -- Budgets zur MonatsbudgetID/MasterbudgetID
    )
    BEGIN
      RAISERROR('Das Budget kann nicht gelöscht werden, da bereits Buchungen mit Geldfluss existieren bzw. an PSCD übermittelt wurden.', 15, 2)
      RETURN -1
    END

    IF EXISTS
    (
      SELECT POS.KgPositionID
      FROM dbo.KgBudget           BUD
        INNER JOIN dbo.KgPosition POS ON POS.KgBudgetID = BUD.KgBudgetID
        LEFT JOIN dbo.KgDokument  DOC ON DOC.KgPositionID = POS.KgPositionID
      WHERE (BUD.KgMasterBudgetID = @KgBudgetID OR BUD.KgBudgetID = @KgBudgetID) -- Budgets zur MonatsbudgetID/MasterbudgetID
        AND BUD.KgMasterBudgetID IS NOT NULL -- Monatsbudget
        AND (POS.MasterbudgetPositionID IS NULL -- Manuell angelegt
          OR DOC.KgDokumentID IS NOT NULL) -- Dokumente hinterlegt
    )

    BEGIN
      DECLARE @errorString varchar(2000)
      SELECT @errorString = N'Das Budget kann nicht gelöscht werden, da noch Dokumente oder Einzelrechnungen hinterlegt sind.'
        + char(13) + char(10) + N'Bitte den Status des Dokumentes klären resp. die Auszahlung der Einzelrechnung prüfen '
        + N'oder Rücksprache mit der Klientenbuchhaltung K nehmen.'
      RAISERROR(@errorSTring, 15, 3)
      RETURN -1
    END


    ------------
    -- Delete --
    ------------

    DECLARE @KgBudgetFiltered TABLE
    (
        KgBudgetID int
    )
     
    INSERT INTO @KgBudgetFiltered
    SELECT KgBudgetID
    FROM dbo.KgBudget BDG
    WHERE  BDG.KgMasterBudgetID = @KgBudgetID OR BDG.KgBudgetID = @KgBudgetID

    -- KgPositionValuta
    DELETE VAL
    FROM dbo.KgPositionValuta       VAL
      INNER JOIN dbo.KgPosition     POS ON POS.KgPositionID = VAL.KgPositionID
      INNER JOIN @KgBudgetFiltered  BDF ON BDF.KgBudgetID = POS.KgBudgetID

    -- KgPosition
    DELETE POS
    FROM dbo.KgPosition POS
      INNER JOIN @KgBudgetFiltered BDF ON BDF.KgBudgetID = POS.KgBudgetID

    -- KgBudget
    DELETE BUD
    FROM dbo.KgBudget BUD 
      INNER JOIN @KgBudgetFiltered BDF ON BDF.KgBudgetID = BUD.KgBudgetID
    
  END TRY
  BEGIN CATCH
    IF ERROR_NUMBER() IS NOT NULL BEGIN
  	  DECLARE @error_message varchar(2000), @error_number int, @error_severity int, @error_state int,
		    @error_procedure varchar(200), @error_line int
	    SELECT @error_message = ERROR_MESSAGE(), @error_number = ERROR_NUMBER(), @error_severity = ERROR_SEVERITY(),
  		  @error_state = ERROR_STATE(), @error_procedure = ERROR_PROCEDURE(), @error_line = ERROR_LINE()
  	  RAISERROR (@error_message, @error_severity, 1, @error_number, @error_severity, @error_state, @error_procedure, @error_line);
    END
  END CATCH

END

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
