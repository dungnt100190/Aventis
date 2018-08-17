SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbGetKontoblaetter
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetKontoblaetter.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:27 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetKontoblaetter.sql $
 * 
 * 2     25.06.09 11:38 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spFbGetKontoblaetter
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFbGetKontoblaetter
 (@FbPeriodeID   int,
  @KontoNrVon    int,
  @KontoNrBis    int,
  @DatumVon      datetime,
  @DatumBis      datetime)
AS
  SET NOCOUNT ON

  DECLARE @CurrKtoNr     int,
          @CurrKtoName   varchar(50),
          @FbBuchungID   int,
          @BuchungsDatum datetime,
          @Text          varchar(200),
          @Betrag        money,
          @SollKtoNr     int,
          @HabenKtoNr    money,
          @Saldo         money,
          @SaldoS        money,
          @SaldoH        money,
          @SaldoDone     bit

  DECLARE @tmp TABLE (
    ID            int identity,
    FbBuchungID   int,
    BuchungsDatum datetime,
    Text          varchar(200),
    KtoName       varchar(60),
    GKtoNr        int,
    BetragSoll    money,
    BetragHaben   money,
    Saldo         money
  )

  DECLARE @Periode TABLE (
    FbPeriodeID   int PRIMARY KEY,
    PeriodeVon    datetime,
    PeriodeBis    datetime
  )

  INSERT INTO @Periode
    SELECT FbPeriodeID, PeriodeVon, PeriodeBis
    FROM dbo.FbPeriode  PER WITH (READUNCOMMITTED) 
    WHERE @FbPeriodeID IS NULL
      OR (BaPersonID = (SELECT BaPersonID FROM dbo.FbPeriode WITH (READUNCOMMITTED) WHERE FbPeriodeID = @FbPeriodeID)
          AND @DatumVon <= PER.PeriodeBis AND @DatumBis >= PER.PeriodeVon)

  -- loop über alle Kontonummern
  DECLARE cKontoNr CURSOR STATIC FOR
    SELECT DISTINCT KontoNr
    FROM dbo.FbKonto           KTO WITH (READUNCOMMITTED) 
    WHERE KontoNr BETWEEN @KontoNrVon AND @KontoNrBis
      AND ((@FbPeriodeID IS NULL AND KTO.FbPeriodeID IS NULL) OR
           (@FbPeriodeID IS NOT NULL AND EXISTS (SELECT * FROM @Periode TMP WHERE FbPeriodeID = KTO.FbPeriodeID)))
    ORDER BY KontoNr

  OPEN cKontoNr
  FETCH NEXT FROM cKontoNr INTO @CurrKtoNr
  WHILE @@fetch_status = 0 BEGIN

    -- KontoName zusammensetzen
    IF @FbPeriodeID IS NULL BEGIN
      SELECT @CurrKtoName = CONVERT(varchar,@CurrKtoNr) + '  ' + KontoName
      FROM   dbo.FbKonto WITH (READUNCOMMITTED) 
      WHERE  FbPeriodeID IS NULL AND
             KontoNr = @CurrKtoNr

      SET @Saldo = 0

      -- Summe der Eröffnungssaldi: Nur jeweils erste Periode eines Mandanten berücksichtigen !
      SELECT @Saldo = IsNull(SUM(EroeffnungsSaldo), 0)
      FROM dbo.FbKonto            KTO WITH (READUNCOMMITTED) 
        INNER JOIN dbo.FbPeriode  PER WITH (READUNCOMMITTED) ON PER.FbPeriodeID = KTO.FbPeriodeID
      WHERE KTO.KontoNr = @CurrKtoNr AND PER.PeriodeVon <= @DatumBis
        AND PER.PeriodeVon = (SELECT MIN(PeriodeVon)
                               FROM   dbo.FbPeriode WITH (READUNCOMMITTED) 
                               WHERE  BaPersonID = PER.BaPersonID)

      -- Saldovortrag berechnen für @CurrKtoNr
      SELECT @SaldoS = IsNull(SUM(CASE WHEN SollKtoNr = @CurrKtoNr THEN Betrag ELSE 0 END),0),
             @SaldoH = IsNull(SUM(CASE WHEN HabenKtoNr = @CurrKtoNr THEN Betrag ELSE 0 END),0)
      FROM dbo.FbBuchung         BUC WITH (READUNCOMMITTED) 
      WHERE BUC.BuchungsDatum < @DatumVon
        AND (SollKtoNr = @CurrKtoNr OR HabenKtoNr = @CurrKtoNr)

    END ELSE BEGIN
      SELECT TOP 1 @FbPeriodeID = PER.FbPeriodeID, @CurrKtoName = CONVERT(varchar, KTO.KontoNr) + '  ' + KTO.KontoName
      FROM dbo.FbKonto           KTO WITH (READUNCOMMITTED) 
        INNER JOIN @Periode  PER ON PER.FbPeriodeID = KTO.FbPeriodeID
      WHERE KontoNr = @CurrKtoNr
      ORDER BY PeriodeVon

      SET @Saldo = 0

      SELECT @Saldo = EroeffnungsSaldo
      FROM   dbo.FbKonto WITH (READUNCOMMITTED) 
      WHERE  FbPeriodeID = @FbPeriodeID AND
             KontoNr = @CurrKtoNr

      -- Saldovortrag berechnen für @CurrKtoNr
      SELECT @SaldoS = IsNull(SUM(CASE WHEN SollKtoNr = @CurrKtoNr THEN Betrag ELSE 0 END),0),
             @SaldoH = IsNull(SUM(CASE WHEN HabenKtoNr = @CurrKtoNr THEN Betrag ELSE 0 END),0)
      FROM dbo.FbBuchung         BUC WITH (READUNCOMMITTED) 
        INNER JOIN @Periode  PER ON PER.FbPeriodeID = BUC.FbPeriodeID
      WHERE BUC.BuchungsDatum < @DatumVon AND PER.PeriodeBis > @DatumVon
        AND (SollKtoNr = @CurrKtoNr OR HabenKtoNr = @CurrKtoNr)
    END

    IF @Saldo > 0
      SET @SaldoS = @SaldoS + @Saldo
    ELSE
      SET @SaldoH = @SaldoH - @Saldo

    SET @Saldo = @SaldoS - @SaldoH

    SET @SaldoDone = 0

    -- Saldovortrag eintragen, falls Saldo,SaldoS oder SaldoH <> 0 (falls keine weiteren Buchungen mehr vorhanden)
    IF @Saldo <> 0 OR @SaldoS <> 0 OR @SaldoH <> 0 BEGIN
      INSERT @tmp VALUES (NULL,@DatumVon, 'Saldovortrag', @CurrKtoName,NULL,@SaldoS,@SaldoH,@Saldo)
      SET @SaldoDone = 1
    END

    -- loop über alle Buchungen einer KontoNr innerhalb des DatumBereichs
    DECLARE cBuchung CURSOR STATIC FOR
      SELECT FbBuchungID, BuchungsDatum, Text, Betrag, SollKtoNr, HabenKtoNr
      FROM dbo.FbBuchung          BUC WITH (READUNCOMMITTED) 
        INNER JOIN @Periode  PER ON PER.FbPeriodeID = BUC.FbPeriodeID
      WHERE BUC.BuchungsDatum BETWEEN @DatumVon AND @DatumBis
        AND (SollKtoNr = @CurrKtoNr OR HabenKtoNr = @CurrKtoNr)
      ORDER BY BuchungsDatum, BelegNr

    OPEN cBuchung
    FETCH NEXT FROM cBuchung INTO @FbBuchungID, @BuchungsDatum, @Text, @Betrag, @SollKtoNr, @HabenKtoNr
    WHILE @@fetch_status = 0 BEGIN

      -- Saldovortrag eintragen, falls nicht schon weiter oben erfolgt
      IF @SaldoDone = 0 BEGIN
        INSERT @tmp VALUES (NULL,@DatumVon, 'Saldovortrag', @CurrKtoName,NULL,@SaldoS,@SaldoH,@Saldo)
        SET @SaldoDone = 1
      END

      IF @SollKtoNr = @CurrKtoNr BEGIN
        SET @Saldo = @Saldo + @Betrag
        INSERT @tmp VALUES (@FbBuchungID,@BuchungsDatum, @Text, @CurrKtoName ,@HabenKtoNr,@Betrag,NULL,@Saldo)
      END ELSE BEGIN
        SET @Saldo = @Saldo - @Betrag
        INSERT @tmp VALUES (@FbBuchungID,@BuchungsDatum, @Text, @CurrKtoName,@SollKtoNr,NULL,@Betrag,@Saldo)
      END

      FETCH NEXT FROM cBuchung INTO @FbBuchungID, @BuchungsDatum, @Text, @Betrag, @SollKtoNr, @HabenKtoNr
    END

    CLOSE cBuchung
    DEALLOCATE cBuchung

    FETCH NEXT FROM cKontoNr INTO @CurrKtoNr
  END

  CLOSE cKontoNr
  DEALLOCATE cKontoNr

  SELECT T.*,
         FBU.BelegNr,
         KontoNrBereich = CONVERT(varchar,@KontoNrVon) + ' - ' + CONVERT(varchar,@KontoNrBis),
         DatumBereich   = CONVERT(varchar,@DatumVon,104) + ' - ' + CONVERT(varchar,@DatumBis,104),
         PRS.Geburtsdatum,
         Mandant        = PRS.Name + IsNull(', ' + PRS.Vorname,'')
  FROM   @tmp T
         LEFT JOIN dbo.FbBuchung FBU WITH (READUNCOMMITTED) on FBU.FbBuchungID = T.FbBuchungID
         LEFT JOIN dbo.FbPeriode PER WITH (READUNCOMMITTED) on PER.FbPeriodeID = FBU.FbPeriodeID
         LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) on PRS.BaPersonID = PER.BaPersonID
  ORDER BY T.ID
GO