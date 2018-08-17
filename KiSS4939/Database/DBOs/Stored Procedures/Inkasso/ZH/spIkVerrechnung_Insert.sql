SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkVerrechnung_Insert
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1: .
    @Param2: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spIkVerrechnung_Insert
  -- Rechtstitel
  @IkRechtstitelID INT,
  -- BaPersonID
  @BaPersonID INT,
  -- GrundForderung
  @Grundforderung money,
  -- Betrag pro Monat
  @BetragMonat money,
  -- BetragLetzterMonat
  @BetragLetzterMonat money,
  -- DatumVon
  @DatumVon DATETIME,
  -- DatumBis
  @DatumBis DATETIME,
  -- IkVerrechnungsart
  @IkVerrechnungsart INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  RAISERROR ('Diese Funktion ist in 4.1.27 nicht aktiviert.', 18, 1)
  RETURN -1


  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF (@IkRechtstitelID IS NULL OR @IkRechtstitelID = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @RechtstitelID ist null.', 18, 1)
    RETURN -1
  END
  IF (@BaPersonID IS NULL OR @BaPersonID = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @BaPersonID ist null.', 18, 1)
    RETURN -1
  END
  IF (@Grundforderung IS NULL OR @Grundforderung = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @GrundForderung ist null.', 18, 1)
    RETURN -1
  END
  IF (@BetragMonat IS NULL OR @BetragMonat = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @BetragMonat ist null.', 18, 1)
    RETURN -1
  END
  IF (@BetragLetzterMonat IS NULL OR @BetragLetzterMonat = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @BetragLetzterMonat ist null.', 18, 1)
    RETURN -1
  END
  IF (@DatumVon IS NULL) BEGIN
    RAISERROR ('Der Aufruf-Parameter @DatumVon ist null.', 18, 1)
    RETURN -1
  END
  IF (@DatumBis IS NULL) BEGIN
    RAISERROR ('Der Aufruf-Parameter @DatumBis ist null.', 18, 1)
    RETURN -1
  END
  IF (@IkVerrechnungsart IS NULL OR @IkVerrechnungsart = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @IkVerrechnungsart ist null.', 18, 1)
    RETURN -1
  END


  DECLARE
    @NewID INT,
    @ErrorMsg varchar(200),
    @Datum DATETIME,
    @FaLeistungID INT

  -- LeitsungsID zum Rechtstitel holen
  SELECT TOP 1 @FaLeistungID = FaLeistungID FROM dbo.IkRechtstitel
  WHERE IkRechtstitelID = @IkRechtstitelID
  IF (@FaLeistungID IS NULL OR @FaLeistungID = 0) BEGIN
    RAISERROR ('Die Leistung konnnte nicht gefunden werden (@FaLeistungID ist null).', 18, 1)
    RETURN -1
  END


  BEGIN TRANSACTION
  BEGIN TRY
    -- Neue einmalige Verrechnung erstellen
    -- --------------------------------
    INSERT INTO dbo.IkVerrechnungskonto (
      IkRechtstitelID, BaPersonID, Grundforderung, VereinbarungVom, BetragProMonat,
      DatumVon, DatumBis, LetzterMonat,
      IstAnnulliert, AnnulliertAm, IstAnPscdGesendet,
      IkVerrechnungsartCode
    )
    VALUES (
      @IkRechtstitelID, @BaPersonID, @Grundforderung, @DatumVon, @BetragMonat,
      dbo.fnFirstDayOf(@DatumVon), dbo.fnFirstDayOf(@DatumBis), @BetragLetzterMonat,
      0, NULL, 0, @IkVerrechnungsart
    )
    SET @NewID = SCOPE_IDENTITY()

    -- Speichern
    -- ---------
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH

    -- Bei Fehler
    -- ----------
    ROLLBACK TRANSACTION
    SET @ErrorMsg = ERROR_MESSAGE()
    RAISERROR (@ErrorMsg, 18, 1)
    RETURN -1
  END CATCH

  EXEC dbo.spIkMonatszahlen_DetailAll @FaLeistungID, 1

  RETURN 1
END

GO
