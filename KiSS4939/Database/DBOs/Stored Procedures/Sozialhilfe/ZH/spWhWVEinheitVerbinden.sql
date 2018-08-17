SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhWVEinheitVerbinden
GO
/*===============================================================================================
  $Revision: 4 $
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

CREATE PROCEDURE dbo.spWhWVEinheitVerbinden
(
  @Einheiten varchar(100)
)
AS

DECLARE
@Query	varchar(1000)

SET @Query = '
DECLARE cEinheiten CURSOR FAST_FORWARD FOR
SELECT WVE.WhWVEinheitID, WVE.BaPersonID, WVM.WhWVEinheitID, WVM.BaPersonID,WVM.BaWVCodeID,BP.Name, BP.Vorname, BP.Geburtsdatum,BP.GeschlechtCode 
FROM WhWVEinheit WVE
INNER JOIN WhWVEinheitMitglied WVM ON WVE.WhWVEinheitID = WVM.WhWVEinheitID
INNER JOIN BaPerson BP ON WVE.BaPersonID = BP.BaPersonID
WHERE WVE.WhWVEinheitID IN (' + @Einheiten + ')
ORDER BY BP.Geburtsdatum ASC'

SET NOCOUNT ON
EXECUTE (@Query)
SET NOCOUNT OFF

DECLARE 
@counter			int,
@EinheitWhWVEinheitID int, 
@EinheitBaPersonID	int, 
@MitgliedWhWVEinheitID int, 
@MitgliedBaPersonID int, 
@BaWVCodeID			int, 
@Name				varchar(100), 
@Vorname			varchar(100), 
@Geburtsdatum		datetime, 
@GeschlechtCode		int,
@TraegerWhWVEinheitID int

SET @counter = 0

OPEN cEinheiten
WHILE (1 = 1) BEGIN

	SET @TraegerWhWVEinheitID = @EinheitWhWVEinheitID --WhWVEinheitID des Traegers zwischenspeichern

	FETCH NEXT FROM cEinheiten 
	INTO @EinheitWhWVEinheitID, @EinheitBaPersonID, @MitgliedWhWVEinheitID, @MitgliedBaPersonID, @BaWVCodeID, @Name, @Vorname, @Geburtsdatum, @GeschlechtCode 


	SET @counter = @counter + 1
	IF @counter = 1 CONTINUE --der erste Datensatz, ist Träger (hier nicht bearbeiten)

	IF @@FETCH_STATUS < 0 BREAK

	BEGIN TRY
		--select @EinheitWhWVEinheitID, @TraegerWhWVEinheitID, @MitgliedWhWVEinheitID, @MitgliedBaPersonID, @BaWVCodeID, @Name, @Vorname, @Geburtsdatum, @GeschlechtCode 
		
		--Miglied von alter Einheit auf neue Einheit verweisen
		UPDATE WhWVEinheitMitglied 
		SET WhWVEinheitID = @TraegerWhWVEinheitID 
		WHERE WhWVEinheitID = @MitgliedWhWVEinheitID 
		AND BaPersonID = @MitgliedBaPersonID 
		AND BaWVCodeID = @BaWVCodeID
		
		--Alte Einheit löschen
		DELETE FROM WhWVEinheit 
		WHERE WhWVEinheitID = @EinheitWhWVEinheitID

	END TRY
	BEGIN CATCH
	  PRINT ERROR_MESSAGE()
	END CATCH
END


CLOSE cEinheiten
DEALLOCATE cEinheiten
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
