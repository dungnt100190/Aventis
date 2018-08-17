SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaLeistung_Insert
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spFaLeistung_Insert.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:17 $
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
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spFaLeistung_Insert.sql $
 * 
 * 4     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 3     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 28.05.2008
Description: Leistungen einfügen

===================================================================================================
History:
28.05.2008 : sozheo : neu erstellt
13.06.2008 : sozheo : Rechtstitel Bezeichnung korrigiert
20.06.2008 : sozheo : TRY CATCH Block hinzugefügt

===================================================================================================
*/

CREATE PROCEDURE [dbo].[spFaLeistung_Insert]
  -- FallPersonID
  @FallPersonID INT,
  -- ProzessCode
  @ProzessCode INT,
  -- UserID
  @UserID INT,
  -- OrgUnitID
  @OrgUnitID INT,
  -- SchuldnerBaPersonID
  @BaPersonID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- Kontrolle der Parameter
  -- -----------------------
  IF @FallPersonID IS NULL RETURN -1
  IF @ProzessCode IS NULL RETURN -1
  IF NOT @ProzessCode BETWEEN 300 AND 499 RETURN -1
  IF @UserID IS NULL RETURN -1
  IF @BaPersonID IS NULL RETURN -1


  DECLARE
    @PscdVertragsgegenstandID INT,
    @SchuldnerID INT,
    @DatumBis DATETIME,
    @EroeffnungsGrundCode INT,
    @FallId INT,
    @NewID INT,
    @BelegParameter varchar(10),
    @CreatorModifier VARCHAR(50);

  SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);

  -- Kontrolle, ob Fall nicht abgeschlossen und ob Fallführung existiert
  -- -------------------------------------------------------------------
  SELECT TOP 1
    @FallId = F.FaFallID
  FROM dbo.FaFall F WITH (READUNCOMMITTED)
  WHERE F.BaPersonID = @FallPersonID
    AND F.DatumBis IS NULL
  ORDER BY F.DatumVon DESC, F.DatumBis DESC
  IF @FallId IS NULL RETURN -2

  IF NOT EXISTS(
    SELECT TOP 1 FaLeistungID FROM dbo.FaLeistung WITH (READUNCOMMITTED)
    WHERE FaFallID = @FallId
      AND FaProzessCode = CASE WHEN @ProzessCode BETWEEN 400 AND 499 THEN 201 ELSE 200 END
      AND DatumBis IS NULL )
  BEGIN
    RETURN -2
  END

  -- FaLeistung.SchuldnerBaPersonID setzen
  -- -------------------------------------
  SET @SchuldnerID = CASE
    WHEN @ProzessCode IN (402,404) THEN NULL
    ELSE @BaPersonID
  END

  -- FaLeistung.EroeffnungsGrundCode setzen
  -- --------------------------------------
  SET @EroeffnungsGrundCode = CASE @ProzessCode
    WHEN 407 THEN 40503 -- Inkasso KKBB
    ELSE NULL
  END

  -- Transaktion starten
  -- -------------------
  BEGIN TRANSACTION
  BEGIN TRY

    -- Neue PSCD Vetragsgegenstand-Nummer holen
    -- ----------------------------------------
    SET @PscdVertragsgegenstandID = NULL
    SET @BelegParameter = CASE
      WHEN @ProzessCode BETWEEN 405 AND 410 THEN 'ALBV'
      WHEN @ProzessCode IN (301,302,304) THEN 'INKW'
      WHEN @ProzessCode BETWEEN 300 AND 399 THEN 'WSH1'
      ELSE NULL
    END

    IF @BelegParameter IS NOT NULL
    BEGIN
      EXEC dbo.spKbGetBelegNr_out @BelegParameter, @PscdVertragsgegenstandID OUT
      IF @PscdVertragsgegenstandID IS NULL OR @PscdVertragsgegenstandID = 0 BEGIN

        ROLLBACK TRANSACTION
        RETURN -3
      END
    END

    -- Leistung einfgügen
    -- ------------------
    INSERT INTO FaLeistung (
      FaFallID,
      ModulID,
      FaProzessCode,
      BaPersonID,
      UserID,
      DatumVon,
      EroeffnungsGrundCode,
      SchuldnerBaPersonID,
      PscdVertragsgegenstandID,
      Creator,
      Created,
      Modifier,
      Modified)
    VALUES (
      @FallId,
      CASE WHEN @ProzessCode BETWEEN 300 AND 399 THEN 3 ELSE 4 END,
      @ProzessCode,
      @BaPersonID,
      @UserID,
      GetDate(),
      @EroeffnungsGrundCode,
      @SchuldnerID,
      @PscdVertragsgegenstandID,
      @CreatorModifier,
      GetDate(),
      @CreatorModifier,
      GetDate())

    -- neue ID holen
    SET @NewID = SCOPE_IDENTITY()

    -- FallProtokoll füllen
    -- --------------------
    INSERT FaJournal (
      FaFallID, FaLeistungID, BaPersonID, UserID, Text, OrgUnitID)
    VALUES (
      @FallId, @NewID, @BaPersonID, @UserID,
      CASE @ProzessCode
        WHEN 301 THEN 'Inkasso Verwantenunterstützung eingefügt'
        WHEN 302 THEN 'Inkasso Rückerstattung eingefügt'
        WHEN 304 THEN 'Inkasso Unterhaltsbeiträge eingefügt'
        WHEN 405 THEN 'Inkasso ALBV eingefügt'
        WHEN 406 THEN 'Inkasso UeBH eingefügt'
        WHEN 407 THEN 'Inkasso KKBB eingefügt'
        WHEN 408 THEN 'Rückforderung ALBV eingefügt'
        WHEN 409 THEN 'Rückforderung UeBH eingefügt'
        WHEN 410 THEN 'Rückforderung KKBB eingefügt'
        ELSE 'Unbekannt'
      END,
      @OrgUnitID
    )


    IF @NewID > 0 AND @NewID IS NOT NULL AND @ProzessCode IN (405,406,407)
    BEGIN
      -- Inkassi ALBV, UeBH, KKBB
      -- Hier soll automatisch ein neuer Rechtstitel erstellt werden
      INSERT INTO IkRechtstitel(
        FaLeistungID,
        Bezeichnung,
        Mahnlauf,
        IkRechtstitelGueltigVon)
      VALUES (
        @NewID,
        CASE @ProzessCode
          WHEN 405 THEN 'Rechtstitel ALBV, '
          WHEN 406 THEN 'Rechtstitel UeBH, '
          WHEN 407 THEN 'Bedingung KKBB, '
        END + CONVERT(varchar, GetDate(), 104),
        0,
        GetDate()
      )
    END

    -- Transaktion beenden
    -- -------------------
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH

    -- Transaktion beenden
    -- -------------------
    ROLLBACK TRANSACTION
    RETURN -4
  END CATCH

  -- Neue ID FaLeistung zurückgeben
  -- ------------------------------
  RETURN @NewID
END
