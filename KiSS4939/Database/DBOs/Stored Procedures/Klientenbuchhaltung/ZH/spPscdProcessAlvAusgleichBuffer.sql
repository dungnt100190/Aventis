SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spPscdProcessAlvAusgleichBuffer
GO
/*===============================================================================================
  $Revision: 10 $
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

CREATE PROCEDURE dbo.spPscdProcessAlvAusgleichBuffer
(
  @AlvBufferID INT,
  @UserID INT
)
AS BEGIN


  IF @AlvBufferID IS NULL
  BEGIN
    RAISERROR('@KbBuchngID darf nicht NULL sein.', 18, 1)
    RETURN -1
  END

  DECLARE
    @FaLeistungID INT,
    @KbBuchungID INT,
    @BaPersonID INT,
    @BaZahlungswegID INT,
    @IkForderungArtCode INT,
    @IkForderungEinmaligCode INT,
    @IkGlaeubigerWHID INT,
    @IstWH BIT,
    @ErrorZW VARCHAR(200),
    @StichDatum DATETIME,
    @AusgleichBetrag MONEY,
    @KreditorKtoNr VARCHAR(10)

  -- Angaben zur Buchung holen
  -- Angaben zu WH und BaZahlungsweg holen
  SELECT TOP 1
    @FaLeistungID = B.FaLeistungID,
    @KbBuchungID = B.KbBuchungID,
    @AusgleichBetrag = A.AusgleichBetrag,
    @KreditorKtoNr = A.KreditorKtoNr,
    @BaPersonID = P.BaPersonID,
    @StichDatum = K.VerwPeriodeVon,
    @IkForderungArtCode = B.IkForderungArtCode,
    @IkForderungEinmaligCode = P.IkForderungEinmaligCode
  FROM dbo.IkAlvAusgleichBuffer A WITH (READUNCOMMITTED)
  LEFT JOIN dbo.KbBuchung B WITH (READUNCOMMITTED) ON B.KbBuchungID = A.OpKbBuchungID
  LEFT JOIN dbo.KbBuchungKostenart K WITH (READUNCOMMITTED) ON K.KbBuchungID = B.KbBuchungID
  INNER JOIN dbo.IkPosition P WITH (READUNCOMMITTED) ON P.IkPositionID = B.IkPositionID
  WHERE A.IkAlvAusgleichBufferID = @AlvBufferID

  -- Daten aus IkInterneVerrechnung holen
  SELECT
    @IkGlaeubigerWHID = IkInterneVerrechnungID,
    @IstWH = InterneVerrechnung,
    @BaZahlungswegID = BaZahlungswegID
  FROM dbo.fnIkInterneVerrechnung_Get(@FaLeistungID, @BaPersonID, @StichDatum,
    @IkForderungArtCode, @IkForderungEinmaligCode)


  IF @IkGlaeubigerWHID IS NULL BEGIN
    RAISERROR('Die interne Verrechnung ist nicht definiert.', 18, 1)
    RETURN -2
  END

  -- Kontrolle, ob Zahlungsweg existiert
  IF @IstWH = 0 AND @BaZahlungswegID IS NULL
  BEGIN
    RAISERROR('Der Zahlungsweg ist noch nicht definiert.', 18, 1)
    RETURN -2
  END

  -- Kontrolle, ob Angaben im Zahlungsweg OK sind
  SET @ErrorZW = NULL
  IF @BaZahlungswegID IS NOT NULL BEGIN
    SET @ErrorZW = dbo.fnBaZahlungsweg_Check(@BaZahlungswegID, GETDATE())
    IF ISNULL(@ErrorZW, '') != '' BEGIN
      RAISERROR(@ErrorZW, 18, 1)
      RETURN -3
    END
  END


  -- Speichern weil alles OK
  DECLARE @ResultNumber INT
  SET @ResultNumber = 0
  BEGIN TRAN
  BEGIN TRY
    -- Neue Buchung erstellen (vermittelte Alimente)
    --  -1 : @KbBuchungID ist nicht definiert
    --  -2 : @AusgleichBetrag ist nicht definiert oder ist 0.--.
    --  -3 : @KreditorKtoNr ist nicht definiert
    --  -4 : Programmfehler: ForderungArtCode ist nicht im zulässigen Bereich.
    --  -5 : Programmfehler: Kontonummer ist nicht im zulässigen Bereich.
    --  -6 : Programmfehler: Neue Kontonummer existiert nicht.
    --  -7 : Die interne Verrechnung ist nicht definiert.
    --  -8 : Der Zahlungsweg ist nicht definiert (keine interne Verrechnung).
    --  -9 : Fehler in fnBaZahlungsweg_Check
    -- -10 : Der Buchungtext darf nicht leer sein (dbo.spKbBuchung_Create_AlimVermittelte).
    -- -11 : Die erste Mitteilungszeile darf nicht leer sein (dbo.spKbBuchung_Create_AlimVermittelte).
    -- -12 : Die zweite Mitteilungszeile darf nicht leer sein (dbo.spKbBuchung_Create_AlimVermittelte).
    EXEC @ResultNumber = dbo.spKbBuchung_Create_AlimVermittelte @KbBuchungID, @AusgleichBetrag, @KreditorKtoNr, @UserID

    IF @ResultNumber > 0 BEGIN
      -- Buchung um Buffer löschen, wenn alles OK
      DELETE dbo.IkAlvAusgleichBuffer WHERE IkAlvAusgleichBufferID = @AlvBufferID
      -- Speichern
      COMMIT
    END ELSE BEGIN
      -- Verwerfen
      ROLLBACK
      SET @ResultNumber = @ResultNumber - 100
    END
  END TRY
  BEGIN CATCH
    -- Unbekannter Fehler 
    ROLLBACK
    DECLARE @msg VARCHAR(2000)
    SET @msg = ERROR_MESSAGE()
    RAISERROR(@msg,18,1)
    RETURN -4
  END CATCH

  RETURN @ResultNumber
END

GO