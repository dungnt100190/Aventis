SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstAerisBarbelegeSetVerbuchtDatum
GO
/*===============================================================================================
  $Revision: 12 $
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

CREATE PROCEDURE dbo.spSstAerisBarbelegeSetVerbuchtDatum
 (@BelegNr			bigint)		-- 11-stellige Belegnummer des Barbelegs, der ausbezahlt wurde
AS BEGIN

	-- Update W-Barbelege (falls es ein W-Barbeleg ist)
	UPDATE  BUC
	Set BarbelegAuszahlDatum = GetDate()
	FROM KbBuchung BUC
	INNER JOIN vwSstAerisWBarbelege AER ON AER.BelegNr = BUC.BelegNr
	WHERE BUC.BelegNr = @BelegNr

	-- Update K-Barbelege (falls es ein K-Barbeleg ist)
	UPDATE  BUC
	Set BarbelegAuszahlDatum = GetDate()
	FROM KgBuchung BUC
	INNER JOIN vwSstAerisKBarbelege AER ON AER.BelegNr = BUC.PscdBelegNr
	WHERE BUC.PscdBelegNr = @BelegNr

END



GO
IF EXISTS(SELECT TOP 1 1 FROM sysusers WHERE name = 'SstAeris')
BEGIN
  GRANT EXECUTE ON [dbo].[spSstAerisBarbelegeSetVerbuchtDatum] TO [SstAeris];
END;
