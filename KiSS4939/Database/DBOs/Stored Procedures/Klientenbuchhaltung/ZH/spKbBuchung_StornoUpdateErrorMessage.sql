SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbBuchung_StornoUpdateErrorMessage
GO
/*===============================================================================================
  $Revision: 9 $
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
CREATE PROCEDURE dbo.spKbBuchung_StornoUpdateErrorMessage
(
	@KbBuchungID		int,
	@ErrorMsg			varchar(300)
)
AS BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Update der PSCD-Fehlermeldung auf dem Beleg selber
	UPDATE KbBuchung
	SET PscdFehlermeldung = @ErrorMsg
	WHERE KbBuchungID = @KbBuchungID

	-- Prüfe, ob es schon einen Eintrag in KbBuchungStorno gibt, und erstelle ihn wenn nötig
	EXEC dbo.spKbBuchung_StornoCheckAndCreateKbBuchungStornoEntry @KbBuchungID

	DECLARE @Count int

	SELECT @Count = count(KbBuchungID)
	FROM KbBuchungStorno
	WHERE KbBuchungID = @KbBuchungID

	IF @Count > 0 BEGIN
		-- Update des existierenden Eintrags
		UPDATE KbBuchungStorno
		SET StornoFehlermeldung = @ErrorMsg
		WHERE KbBuchungID = @KbBuchungID
	END
	ELSE BEGIN
		-- Es gibt keinen Eintrag für diese Buchung in der Storno-Tabelle => Fehler
		DECLARE @msg varchar(200)
		SET @msg = 'Der Netto-Beleg ' + CONVERT(varchar, @KbBuchungID) + ' existiert nicht in der KbBuchungStorno Tabelle, das ist aber Voraussetzung für das Abfüllen einer Storno-Fehlermeldung.'

		RAISERROR (@msg, 18, 1)
		RETURN -1
	END
END
