SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgSparhafenAbschlussBuchung
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
CREATE PROCEDURE dbo.spKgSparhafenAbschlussBuchung
(
 @KgSparhafenAbschlussID int,
 @SparhafenKtoNr         varchar(10)
)
AS
  DECLARE @KtoCount    int
  DECLARE @BankKtoNr   varchar(100)
  DECLARE @KgPeriodeID int
  
  SET @KtoCount = 0

  IF @SparhafenKtoNr IS NOT NULL BEGIN
    -- Bestimmung BankKto: Suche mit @SparhafenKtoNr
    SELECT @KtoCount = count(*), @BankKtoNr = MAX(KTO.KontoNr), @KgPeriodeID = MAX(PER.KgPeriodeID)
    FROM   KgSparhafenAbschluss SPA
           INNER JOIN FaLeistung LEI on LEI.BaPersonID = SPA.BaPersonID
           INNER JOIN KgPeriode  PER on PER.FaLeistungID = LEI.FaLeistungID AND
                                        SPA.BDatum BETWEEN PER.PeriodeVon AND PER.PeriodeBis
           INNER JOIN KgKonto    KTO on KTO.KgPeriodeID = PER.KgPeriodeID AND
                                        KTO.KontoNr = @SparhafenKtoNr
    WHERE  SPA.KgSparhafenAbschlussID = @KgSparhafenAbschlussID
  END

  IF @KtoCount = 0 BEGIN
    -- Bestimmung BankKto: Suche mit TeilKtoNr
    SELECT @KtoCount = count(*), @BankKtoNr = MAX(KTO.KontoNr), @KgPeriodeID = MAX(PER.KgPeriodeID)
    FROM   KgSparhafenAbschluss SPA
           INNER JOIN FaLeistung LEI on LEI.BaPersonID = SPA.BaPersonID
           INNER JOIN KgPeriode  PER on PER.FaLeistungID = LEI.FaLeistungID AND
                                        SPA.BDatum BETWEEN PER.PeriodeVon AND PER.PeriodeBis
           INNER JOIN KgKonto    KTO on KTO.KgPeriodeID = PER.KgPeriodeID AND
                                        KTO.KontoName like '%' + SPA.TeilKtoNr + '%'
    WHERE  SPA.KgSparhafenAbschlussID = @KgSparhafenAbschlussID
  END

  IF @KtoCount = 0 BEGIN
    -- Bestimmung BankKto: Suche mit 'Sparhafen'
    SELECT @KtoCount = count(*), @BankKtoNr = MAX(KTO.KontoNr), @KgPeriodeID = MAX(PER.KgPeriodeID)
    FROM    KgSparhafenAbschluss SPA
           INNER JOIN FaLeistung LEI on LEI.BaPersonID = SPA.BaPersonID
           INNER JOIN KgPeriode  PER on PER.FaLeistungID = LEI.FaLeistungID AND
                                        SPA.BDatum BETWEEN PER.PeriodeVon AND PER.PeriodeBis
           INNER JOIN KgKonto    KTO on KTO.KgPeriodeID = PER.KgPeriodeID AND
                                        KTO.KontoName like '%Sparhafen%'
    WHERE  SPA.KgSparhafenAbschlussID = @KgSparhafenAbschlussID
  END

  IF @KtoCount = 0 BEGIN
    UPDATE KgSparhafenAbschluss
    SET    Fehlermeldung = 'Kein passendes Sparhafen-Konto gefunden'
    WHERE  KgSparhafenAbschlussID = @KgSparhafenAbschlussID
  END

  IF @KtoCount > 1 BEGIN
      UPDATE KgSparhafenAbschluss
      SET    Fehlermeldung = 'Mehrere passende Sparhafen-Konti gefunden'
      WHERE  KgSparhafenAbschlussID = @KgSparhafenAbschlussID
  END

  IF @KtoCount = 1 BEGIN
    -- Periode aktiv?
    IF (SELECT KgPeriodeStatusCode FROM KgPeriode WHERE KgPeriodeID = @KgPeriodeID) <> 1 BEGIN -- aktiv

        UPDATE KgSparhafenAbschluss
        SET    Fehlermeldung = 'Die passende Periode ist nicht aktiv'
        WHERE  KgSparhafenAbschlussID = @KgSparhafenAbschlussID

    END ELSE BEGIN

      -- Buchung erzeugen
      INSERT KgBuchung (KgPeriodeID,KgBuchungTypCode,BuchungsDatum,SollKtoNr,HabenKtoNr,Betrag,Text,ValutaDatum,ErstelltDatum)
      SELECT KgPeriodeID      = @KgPeriodeID,
             KgBuchungTypCode = 3,
             BuchungsDatum    = SPA.BDatum,
             SollKtoNr        = CASE SPA.Code
                                WHEN 1 THEN @BankKtoNr
                                WHEN 2 THEN '1320'  -- Debitor Verrechnungssteuer
                                END,
             HabenKtoNr       = CASE SPA.Code
                                WHEN 1 THEN '4610' -- Finanz-/Zinserträge
                                WHEN 2 THEN @BankKtoNr
                                END,
             Betrag           = SPA.Betrag,
             Text             = CASE SPA.Code
                                WHEN 1 THEN 'Bruttozins'
                                WHEN 2 THEN 'Verrechnungssteuer'
                                END -- + ' (Testlauf wbm)'
                                ,
             ValutaDatum      = SPA.BDatum,
             ErstelltDatum    = GetDate()
      FROM   KgSparhafenAbschluss SPA
      WHERE  SPA.KgSparhafenAbschlussID = @KgSparhafenAbschlussID

      IF @@error = 0 BEGIN
        -- KgBuchungID eintragen
        UPDATE KgSparhafenAbschluss
        SET    KgBuchungID = @@identity,
               Fehlermeldung = NULL
        WHERE  KgSparhafenAbschlussID = @KgSparhafenAbschlussID
      END ELSE BEGIN
        UPDATE KgSparhafenAbschluss
        SET    Fehlermeldung = 'Fehler beim Erzeugen der Buchung'
        WHERE  KgSparhafenAbschlussID = @KgSparhafenAbschlussID
      END
    END
  END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
