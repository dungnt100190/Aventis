SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgBuchung_Storno
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
  Storniert eine K-Buchung
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

CREATE PROCEDURE dbo.spKgBuchung_Storno
(
  @KgBuchungID int,
  @UserID int
)
AS BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

  DECLARE @stornoBuchungID int

  IF @@TRANCOUNT = 0 BEGIN
    RAISERROR('spKgBuchungStorno: Keine Transaktion offen.', 18, 1)
    RETURN
  END

  IF NOT EXISTS
  (
    SELECT KgBuchungID
    FROM KgBuchung
    WHERE KgBuchungID = @KgBuchungID
  )
  BEGIN
    RAISERROR ('Die zu stornierende Buchung wurde nicht gefunden.', 18, 1)
    RETURN -1
  END

  IF NOT EXISTS
  (
    -- Automatisch erstellte Buchungen (KgBuchungTypCode 3[automatisch] und 4[Ausgleich] (und 5??) haben keinen KgBuchungStatusCode
    SELECT KgBuchungID
    FROM KgBuchung
    WHERE KgBuchungID = @KgBuchungID AND KgBuchungStatusCode IS NOT NULL AND KgBuchungStatusCode NOT IN (2, 8)
  )
  BEGIN
    RAISERROR ('Es können keine automatisch erstellten Buchungen und Buchungen in den Zuständen "freigegeben" und "storniert" storniert werden.', 18, 1)
    RETURN -1
  END

  IF NOT EXISTS
  (
      SELECT BUC.KgPeriodeID
      FROM KgBuchung BUC
        INNER JOIN KgPeriode PER ON PER.KgPeriodeID = BUC.KgPeriodeID
      WHERE BUC.KgBuchungID = @KgBuchungID AND PER.KgPeriodeStatusCode IN (1, 2) -- 1:aktiv, 2:inaktiv. Ausschluss von 3: abgeschlossen
  )
  BEGIN
    RAISERROR ('Die Buchungs-Periode ist abgeschlossen.', 18, 1)
    RETURN -1
  END

  INSERT INTO KgBuchung(
    KgPeriodeID,
    KgPositionID,
    KgBuchungTypCode,
    KgAusgleichStatusCode,
    KgZahlungseingangID,
    CodeVorlage,
    BelegNr,
    BelegNrPos,
    BuchungsDatum,
    SollKtoNr,
    HabenKtoNr,
    Betrag,
    BetragFW,
    FbWaehrungID,
    [Text],
    ValutaDatum,
    BarbezugDatum,
    TransferDatum,
    KgBuchungStatusCode,
    UserIDKasse,
    BaZahlungswegID,
    BaInstitutionID,
    EinzahlungsscheinCode,
    KgAuszahlungsArtCode,
    BaBankID,
    BankKontoNummer,
    IBANNummer,
    PostKontoNummer,
    ESRTeilnehmer,
    ESRReferenznummer,
    BeguenstigtName,
    BeguenstigtName2,
    BeguenstigtStrasse,
    BeguenstigtHausNr,
    BeguenstigtPostfach,
    BeguenstigtOrt,
    BeguenstigtPLZ,
    BeguenstigtLandCode,
    MitteilungZeile1,
    MitteilungZeile2,
    MitteilungZeile3,
    MitteilungZeile4,
    ErstelltUserID,
    ErstelltDatum,
    MutiertUserID,
    MutiertDatum,
    PscdFehlermeldung,
    PscdBelegNr,
    StorniertKgBuchungID,
    NeubuchungVonKgBuchungID)
  SELECT
    KgPeriodeID,
    KgPositionID              = null,
    KgBuchungTypCode          = 2, -- manuell
    KgAusgleichStatusCode,
    KgZahlungseingangID,
    CodeVorlage,
    BelegNr,
    BelegNrPos,
    BuchungsDatum,
    SollKtoNr                 = HabenKtoNr,
    HabenKtoNr                = SollKtoNr,
    Betrag,
    BetragFW,
    FbWaehrungID,
    [Text]                    = 'STO ' + CONVERT(VARCHAR(20), KgBuchungID) + ', ' + [Text],
    ValutaDatum,
    BarbezugDatum,
    TransferDatum             = NULL,
    KgBuchungStatusCode       = 8, -- storno
    UserIDKasse,
    BaZahlungswegID,
    BaInstitutionID,
    EinzahlungsscheinCode,
    KgAuszahlungsArtCode,
    BaBankID,
    BankKontoNummer,
    IBANNummer,
    PostKontoNummer,
    ESRTeilnehmer,
    ESRReferenznummer,
    BeguenstigtName,
    BeguenstigtName2,
    BeguenstigtStrasse,
    BeguenstigtHausNr,
    BeguenstigtPostfach,
    BeguenstigtOrt,
    BeguenstigtPLZ,
    BeguenstigtLandCode,
    MitteilungZeile1,
    MitteilungZeile2,
    MitteilungZeile3,
    MitteilungZeile4,
    ErstelltUserID            = @UserID,
    ErstelltDatum             = GetDate(),
    MutiertUserID             = @UserID,
    MutiertDatum              = GetDate(),
    PscdFehlermeldung         = NULL,
    PscdBelegNr               = NULL,
    StorniertKgBuchungID      = @KgBuchungID,
    NeubuchungVonKgBuchungID  = NULL
  FROM KgBuchung
  WHERE KgBuchungID = @KgBuchungID
  SET @stornoBuchungID = SCOPE_IDENTITY()

  -- Alte Buchung stornieren
  UPDATE KgBuchung
  SET    KgBuchungStatusCode = 8
  WHERE  KgBuchungID = @KgBuchungID


END

