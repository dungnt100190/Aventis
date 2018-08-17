SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgGetBilanzErfolg
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

CREATE PROCEDURE dbo.spKgGetBilanzErfolg
 (@KgPeriodeID       int,
  @DatumVon          datetime,
  @DatumBis          datetime,
  @NurMitBuchungen   bit,
  @OhneKtoGruppen    bit)
AS
  DECLARE @count int

  DECLARE @BilanzSaldo     money
  DECLARE @ErfolgSaldo     money
  DECLARE @CurrKtoNr       varchar(10)
  DECLARE @CurrKibtoGruppe bit
  DECLARE @Vorsaldo        money
  DECLARE @Vorumsatz       money
  DECLARE @Umsatz          money
  DECLARE @BuchungCount    int

  DECLARE @tmp table (
--    ID                 int identity,
    KgKontoID          int,
    GruppeKontoID      int,
    KontoGruppe        bit,
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
             KTO.KgKontoID,
             KTO.GruppeKontoID,
             KTO.KontoGruppe,
             KTO.KgKontoklasseCode,
             KTO.KontoNr,
             KTO.KontoName,
             Vorsaldo = @Vorsaldo + @Vorumsatz,
             Umsatz   = @Umsatz,
             Saldo    = @Vorsaldo + @Vorumsatz + @Umsatz
      FROM   @Periode TMP
             INNER JOIN dbo.KgPeriode PER WITH (READUNCOMMITTED) ON PER.KgPeriodeID = TMP.KgPeriodeID
             INNER JOIN dbo.KgKonto   KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
      WHERE  KTO.KontoNr = @CurrKtoNr
      ORDER BY PER.PeriodeVon

    FETCH NEXT FROM cKontoNr INTO @CurrKtoNr
  END

  CLOSE cKontoNr
  DEALLOCATE cKontoNr

  -- alle Gruppen hinzufügen
  INSERT @tmp
  SELECT KTO.KgKontoID,
         KTO.GruppeKontoID,
         KTO.KontoGruppe,
         KTO.KgKontoklasseCode,
         KTO.KontoNr,
         KTO.KontoName,
         Vorsaldo = 0,
         Umsatz   = 0,
         Saldo    = 0
  FROM   @Periode TMP
         INNER JOIN dbo.KgKonto KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
  WHERE  KTO.KontoGruppe = 1 AND
         KTO.KgKontoklasseCode in (1,2,3,4)
  ORDER BY KontoNr

  -- Entfernen von leeren Gruppen
  WHILE @@rowcount > 0
    DELETE T
    FROM  @tmp T
    WHERE T.KontoGruppe = 1 AND
          NOT EXISTS (SELECT 1 FROM @tmp WHERE GruppeKontoID = T.KgKontoID)

  -- Totale bilden über 4 Stufen
  SET @count = 4
  WHILE @count > 0 BEGIN
    UPDATE T
    SET    Saldo = (SELECT SUM(IsNull(Saldo,0)) FROM @tmp WHERE GruppeKontoID = T.KgKontoID)
    FROM   @tmp T
    WHERE  T.KontoGruppe = 1
    SET @count = @count - 1
  END

  -- Ohne Konto-Gruppen
  IF @OhneKtoGruppen = 1 BEGIN
    UPDATE T
    SET GruppeKontoID = IsNull(T4.GruppeKontoID, IsNull(T3.GruppeKontoID, IsNull(T2.GruppeKontoID, T.GruppeKontoID)))
    FROM @tmp T
         LEFT JOIN @tmp T2 on T2.KgKontoID = T.GruppeKontoID
         LEFT JOIN @tmp T3 on T3.KgKontoID = T2.GruppeKontoID
         LEFT JOIN @tmp T4 on T4.KgKontoID = T3.GruppeKontoID
    WHERE T.KontoGruppe = 0

       DELETE @tmp WHERE KontoGruppe = 1 AND GruppeKontoID IS NOT NULL
  END

  -- BilanzSaldo, ErfolgSaldo, Vermöegenszunahme/-abnahme
  SELECT @BilanzSaldo  = SUM(IsNull(Saldo,0)) FROM @tmp WHERE KgKontoklasseCode in (1,2) AND KontoGruppe = 0
  SELECT @ErfolgSaldo  = SUM(IsNull(Saldo,0)) FROM @tmp WHERE KgKontoklasseCode in (3,4) AND KontoGruppe = 0

  IF @BilanzSaldo < 0
    INSERT @tmp VALUES (10000,NULL,1,1,NULL,'Vermögensabnahme',NULL,NULL,@BilanzSaldo)
  ELSE
    INSERT @tmp VALUES (10000,NULL,1,1,NULL,'Vermögenszunahme',NULL,NULL,@BilanzSaldo)

  SELECT KgKontoID,
         GruppeKontoID,
         KontoGruppe,
         Konto     = IsNull(KontoNr + ' ','') + KontoName,
         Vorsaldo  = CASE WHEN KontoGruppe = 0 THEN Vorsaldo END ,
         Umsatz    = CASE WHEN KontoGruppe = 0 THEN Umsatz END,
         Saldo     = CASE WHEN KontoGruppe = 0 THEN Saldo END,
         Total     = CASE WHEN KontoGruppe = 1 THEN Saldo END,
         IconIndex = CASE WHEN KontoGruppe = 1 THEN 1 ELSE 0 END
  FROM   @tmp
  ORDER BY IsNull(KontoNr,'zzz')
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
