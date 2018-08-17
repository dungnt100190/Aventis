SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgGetBilanzErfolgReport
GO
/*===============================================================================================
  $Revision: 4$
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

CREATE PROCEDURE dbo.spKgGetBilanzErfolgReport
 (@KgPeriodeID         int,
  @DatumVon            datetime,
  @DatumBis            datetime,
  @NurMitBuchungen     bit,
  @OhneKtoGruppen      bit,
  @Bemerkung           text,
  @PM                  text,
  @MA                  varchar(150),
  @UserID              int,
  @KeinAbrechnungsText bit)
AS
  DECLARE @count int

  DECLARE @BilanzSaldo     money
  DECLARE @ErfolgSaldo     money
  DECLARE @CurrKtoNr       varchar(10)
  DECLARE @Vorsaldo        money
  DECLARE @Vorumsatz       money
  DECLARE @Umsatz          money
  DECLARE @BuchungCount    int

  DECLARE @tmp table (
    Klasse             varchar(100),
    Gruppe1            varchar(100),
    Gruppe2            varchar(100),
    Gruppe3            varchar(100),
    KgKontoID          int,
    KgKontoklasseCode  int,
    KontoNr            varchar(50),
    KontoName          varchar(150),
    Vorsaldo           money,
    Umsatz             money,
    Saldo              money)

  IF @DatumVon IS NULL
     SELECT @DatumVon = PeriodeVon FROM dbo.KgPeriode WITH (READUNCOMMITTED) WHERE KgPeriodeID = @KgPeriodeID

  IF @DatumBis IS NULL
     SELECT @DatumBis = PeriodeBis FROM dbo.KgPeriode WITH (READUNCOMMITTED) WHERE KgPeriodeID = @KgPeriodeID

  --alle betroffenen Perioden (@DatumVon-@DatumBis kann periodenübergreifend sein)
  DECLARE @Periode TABLE (KgPeriodeID int PRIMARY KEY)

  INSERT INTO @Periode
    SELECT KgPeriodeID
    FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
    WHERE  FaLeistungID = (SELECT FaLeistungID FROM KgPeriode WHERE KgPeriodeID = @KgPeriodeID) AND
           dbo.fnDatumUeberschneidung(PeriodeVon,PeriodeBis,@DatumVon,@DatumBis) = 1

  -- loop über alle Kontonummern (ohne Gruppen)
  DECLARE cKontoNr CURSOR STATIC FOR
    SELECT DISTINCT KTO.KontoNr
    FROM   @Periode TMP
           INNER JOIN dbo.KgKonto KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
    WHERE  KTO.KontoGruppe = 0 AND
           KTO.KgKontoklasseCode in (1,2,3,4)
    ORDER BY KontoNr

  OPEN cKontoNr
  FETCH NEXT FROM cKontoNr INTO @CurrKtoNr
  WHILE @@fetch_status = 0 BEGIN

	SET @Vorsaldo = 0

    -- Eröffnungssaldo aus der ersten Periode
    SELECT TOP 1 @Vorsaldo = Vorsaldo
	FROM   @Periode TMP
           INNER JOIN dbo.KgPeriode PER WITH (READUNCOMMITTED) ON PER.KgPeriodeID = TMP.KgPeriodeID
           INNER JOIN dbo.KgKonto   KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
	WHERE  KTO.KontoNr = @CurrKtoNr
    ORDER BY PER.PeriodeVon

	-- Vorumsatz aus Buchungen
	SELECT @Vorumsatz = IsNull(SUM(CASE WHEN SollKtoNr = @CurrKtoNr THEN Betrag ELSE -Betrag END),0)
	FROM   @Periode TMP
           INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgPeriodeID = TMP.KgPeriodeID
	WHERE  BUC.BuchungsDatum < @DatumVon AND
		   (SollKtoNr = @CurrKtoNr OR HabenKtoNr = @CurrKtoNr)

    -- Umsatz aus Buchungen
    SELECT @Umsatz = IsNull(SUM(CASE WHEN SollKtoNr = @CurrKtoNr THEN Betrag ELSE -Betrag END),0),
           @BuchungCount = COUNT(*)
    FROM   @Periode TMP
           INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgPeriodeID = TMP.KgPeriodeID
    WHERE  dbo.fnDateOf(BuchungsDatum) BETWEEN @DatumVon AND @DatumBis AND
           (SollKtoNr = @CurrKtoNr OR HabenKtoNr = @CurrKtoNr)

    IF IsNull(@NurMitBuchungen,1) = 0 OR
       @BuchungCount > 0 OR
       @Vorsaldo <> 0 OR
       @VorUmsatz <> 0

      INSERT @tmp
      SELECT TOP 1
             Klasse  = CONVERT(varchar, KLA.Code) + ' ' + KLA.Text,
             Gruppe1 = Coalesce(GR1.KontoNr + ' ' + GR1.KontoName,
                                GR2.KontoNr + ' ' + GR2.KontoName,
                                GR3.KontoNr + ' ' + GR3.KontoName,'-'),
             Gruppe2 = CASE WHEN GR1.KgKontoID IS NOT NULL THEN GR2.KontoNr + ' ' + GR2.KontoName
                            WHEN GR2.KgKontoID IS NOT NULL THEN GR3.KontoNr + ' ' + GR3.KontoName
                       ELSE '-'
                       END,
             Gruppe3 = CASE WHEN GR1.KgKontoID IS NOT NULL THEN GR3.KontoNr + ' ' + GR3.KontoName ELSE '-' END,
             KTO.KgKontoID,
             KTO.KgKontoklasseCode,
             KTO.KontoNr,
             KTO.KontoName,
             Vorsaldo = @Vorsaldo + @Vorumsatz,
             Umsatz   = @Umsatz,
             Saldo    = @Vorsaldo + @Vorumsatz + @Umsatz
      FROM   @Periode TMP
             INNER JOIN dbo.KgPeriode PER WITH (READUNCOMMITTED) ON PER.KgPeriodeID = TMP.KgPeriodeID
             INNER JOIN dbo.KgKonto   KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
             LEFT  JOIN dbo.XLOVCode  KLA WITH (READUNCOMMITTED) on KLA.LOVName = 'KgKontoKlasse' AND KLA.Code = KTO.KgKontoklasseCode
             LEFT  JOIN dbo.KgKonto   GR3 WITH (READUNCOMMITTED) on GR3.KgKontoID = KTO.GruppeKontoID AND GR3.GruppeKontoID IS NOT NULL AND @OhneKtoGruppen = 0
             LEFT  JOIN dbo.KgKonto   GR2 WITH (READUNCOMMITTED) on GR2.KgKontoID = GR3.GruppeKontoID AND GR2.GruppeKontoID IS NOT NULL AND @OhneKtoGruppen = 0
             LEFT  JOIN dbo.KgKonto   GR1 WITH (READUNCOMMITTED) on GR1.KgKontoID = GR2.GruppeKontoID AND GR1.GruppeKontoID IS NOT NULL AND @OhneKtoGruppen = 0
      WHERE  KTO.KontoNr = @CurrKtoNr
      ORDER BY PER.PeriodeVon

    FETCH NEXT FROM cKontoNr INTO @CurrKtoNr
  END

  CLOSE cKontoNr
  DEALLOCATE cKontoNr

  -- BilanzSaldo, ErfolgSaldo, Vermöegenszunahme/-abnahme
  SELECT @BilanzSaldo  = SUM(IsNull(Saldo,0)) FROM @tmp WHERE KgKontoklasseCode in (1,2)
  SELECT @ErfolgSaldo  = SUM(IsNull(Saldo,0)) FROM @tmp WHERE KgKontoklasseCode in (3,4)

  SELECT T.*,
         Konto               = IsNull(KontoNr + ' ','') + KontoName,
         Bemerkung           = @Bemerkung,
         PM                  = @PM,
         MA                  = @MA,
         DatumBereich        = CONVERT(varchar,@DatumVon,104) + ' - ' + CONVERT(varchar,@DatumBis,104),
         Mandant             = PRS.NameVorname,
         PN                  = PRS.BaPersonID,
         Geburtsdatum        = CONVERT(varchar,PRS.Geburtsdatum,104),
         OrtDatum            = 'Zürich, ' + CONVERT(varchar, GetDate(), 104) + ' / ' + USR.LogonName,
         ResultatText        = CASE WHEN @BilanzSaldo < 0 THEN 'Vermögensabnahme' ELSE 'Vermögenszunahme' END,
         ResultatBetrag      = @BilanzSaldo,
         OhneKtoGruppen      = @OhneKtoGruppen,
         KeinAbrechnungsText = @KeinAbrechnungsText
  FROM   @tmp T
         LEFT OUTER JOIN dbo.KgPeriode  PER WITH (READUNCOMMITTED) on PER.KgPeriodeID = @KgPeriodeID
         LEFT OUTER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.FaLeistungID = PER.FaLeistungID 
         LEFT OUTER JOIN dbo.vwPerson   PRS on PRS.BaPersonID = LEI.BaPersonID
         LEFT OUTER JOIN dbo.XUser      USR WITH (READUNCOMMITTED) on USR.UserID = @UserID

  ORDER BY IsNull(KontoNr,'zzz')
