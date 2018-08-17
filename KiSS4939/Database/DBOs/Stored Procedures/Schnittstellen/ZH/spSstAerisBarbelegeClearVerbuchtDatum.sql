SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstAerisBarbelegeClearVerbuchtDatum
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spSstIKAuszugExportXML.sql $
  $Author: Rstahel $
  $Modtime: 25.08.10 14:39 $
  $Revision: 11 $
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
  $Log:
 * 
=================================================================================================*/
CREATE PROCEDURE [dbo].[spSstAerisBarbelegeClearVerbuchtDatum]
 (@BelegNr			bigint)		-- 11-stellige Belegnummer des Barbelegs, der storniert wurde
AS BEGIN

	-- Update W-Barbelege (falls es ein W-Barbeleg ist)
	UPDATE  BUC
	Set BarbelegAuszahlDatum = NULL
	FROM KbBuchung BUC
	INNER JOIN vwSstAerisWBarbelege AER ON AER.BelegNr = BUC.BelegNr
	WHERE BUC.BelegNr = @BelegNr

	-- Update K-Barbelege (falls es ein K-Barbeleg ist)
	UPDATE  BUC
	Set BarbelegAuszahlDatum = NULL
	FROM KgBuchung BUC
	INNER JOIN vwSstAerisKBarbelege AER ON AER.BelegNr = BUC.PscdBelegNr
	WHERE BUC.PscdBelegNr = @BelegNr

END



GO
IF EXISTS(SELECT TOP 1 1 FROM sysusers WHERE name = 'SstAeris')
BEGIN
  GRANT EXECUTE ON [dbo].[spSstAerisBarbelegeClearVerbuchtDatum] TO [SstAeris];
END;
