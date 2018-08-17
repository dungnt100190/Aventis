SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDeletePerson
GO

CREATE PROCEDURE [dbo].[spDeletePerson] (@BaPersonID int)
AS
BEGIN

BEGIN TRY
BEGIN TRAN

  DELETE FaFallPerson WHERE BaPersonID = @BaPersonID
  DELETE FaInvolviertePerson WHERE BaPersonID = @BaPersonID
  DELETE BaAdresse WHERE BaPersonID = @BaPersonID
  DELETE BaAlteFallNr WHERE BaPersonID = @BaPersonID
  DELETE BaPraemienverbilligung WHERE BaPersonID = @BaPersonID
  DELETE BaErsatzeinkommen WHERE BaPersonID = @BaPersonID
  DELETE BaVermoegen WHERE BaPersonID = @BaPersonID
  DELETE BaKrankenversicherung WHERE BaPersonID = @BaPersonID
  DELETE BaPraemienuebernahme WHERE BaPersonID = @BaPersonID
  DELETE BaArbeit WHERE BaPersonID = @BaPersonID
  DELETE BaZahlungsweg WHERE BaPersonID = @BaPersonID
  DELETE BaPerson WHERE BaPersonID = @BaPersonID

/*
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
  delete FaInvolviertePerson where BaPersonID = @BaPersonID
*/
  COMMIT
END TRY
BEGIN CATCH
  ROLLBACK
  DECLARE @msg varchar(4000)
  SET @msg = ERROR_MESSAGE()
  RAISERROR(@msg, 18,1)
END CATCH
END
