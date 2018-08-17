SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDeleteFall
GO
/*===============================================================================================
  $Revision: 1 $
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

CREATE PROCEDURE dbo.spDeleteFall (@FaFallID int)
AS
BEGIN

BEGIN TRY
BEGIN TRAN

  DELETE FaFallPerson WHERE FaFallID = @FaFallID
  DELETE FaJournal WHERE FaFallID = @FaFallID
  DELETE FaInvolviertePerson WHERE FaFallID = @FaFallID
  DELETE FaInvolvierteInstitution WHERE FaFallID = @FaFallID

  DELETE FaAktennotizen            WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaRessourcenkarte         WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaAbmachung               WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaDokumente               WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaTeilLeistungserbringer  WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaVoranmeldung            WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaCheckin                 WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaAssessment              WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaZielvereinbarung        WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaAbklaerung              WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
  DELETE FaDokumente               WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)

  DELETE FaUnterlagenliste WHERE FaUnterlagenID in (SELECT FaUnterlagenID
                                                  FROM   FaUnterlagen UNT
                                                         INNER JOIN FaLeistung LEI on LEI.FaLeistungID = UNT.FaLeistungID
                                                  WHERE LEI.FaFallID = @FaFallID)
  DELETE FaUnterlagen WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)

  DELETE FaLeistung WHERE FaFallID = @FaFallID
  DELETE FaFall WHERE FaFallID = @FaFallID

  COMMIT
END TRY
BEGIN CATCH
  ROLLBACK
  DECLARE @msg varchar(4000)
  SET @msg = ERROR_MESSAGE()
  RAISERROR(@msg, 18,1)
END CATCH
END