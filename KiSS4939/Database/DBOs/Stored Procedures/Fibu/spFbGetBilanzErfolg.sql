SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbGetBilanzErfolg
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetBilanzErfolg.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:28 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetBilanzErfolg.sql $
 * 
 * 2     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spFbGetBilanzErfolg
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFbGetBilanzErfolg
 (@FbPeriodeID       int,
  @PerDatum          datetime,
  @NurMitBuchungen   bit)
AS
  DECLARE @VorSaldoAktiven  money
  DECLARE @VorSaldoPassiven money
  DECLARE @VorSaldoAufwand  money
  DECLARE @VorSaldoErtrag   money

  DECLARE @SaldoAktiven  money
  DECLARE @SaldoPassiven money
  DECLARE @SaldoAufwand  money
  DECLARE @SaldoErtrag   money

  DECLARE @Team          varchar(50)
  DECLARE @DatumBereich  varchar(50)
  DECLARE @Geburtsdatum  varchar(20)
  DECLARE @Mandant       varchar(200)

  CREATE TABLE #tmp (
    ID               int identity,
    KlasseCode       int,
    Klasse           varchar(20),
    KontoNr          int,
    KontoName        varchar(150),
    Vorsaldo         money,
    Saldo            money,
    SaldoGruppeName  varchar(20))

  IF @PerDatum IS NULL
    SET @PerDatum = (SELECT PeriodeBis FROM dbo.FbPeriode WITH (READUNCOMMITTED) WHERE FbPeriodeID = @FbPeriodeID)

  INSERT #tmp
    SELECT
      KTO.KontoKlasseCode,
      KLA.Text,
      KTO.KontoNr,
      KTO.KontoName,
      CASE WHEN KTO.KontoKlasseCode in (1,2)
      THEN KTO.EroeffnungsSaldo
      ELSE NULL
      END,
      IsNull(KTO.EroeffnungsSaldo,0) +
      (SELECT IsNull(SUM(Betrag),0)
       FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
       WHERE  FbPeriodeID = @FbPeriodeID AND
              SollKtoNr = KTO.KontoNr AND
              BuchungsDatum <= @PerDatum) -
      (SELECT IsNull(SUM(Betrag),0)
       FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
       WHERE  FbPeriodeID = @FbPeriodeID AND
              HabenKtoNr = KTO.KontoNr AND
              BuchungsDatum <= @PerDatum),
      KTO.SaldoGruppeName
    FROM dbo.FbKonto KTO WITH (READUNCOMMITTED) 
         INNER JOIN dbo.XLOVCode KLA WITH (READUNCOMMITTED) on KLA.LOVName = 'FbKontoKlasse' AND
                                    KLA.Code = KTO.KontoKlasseCode
    WHERE FbPeriodeID = @FbPeriodeID AND
          KTO.KontoKlasseCode <= 4 AND
          (IsNull(@NurMitBuchungen,1) = 0 OR EXISTS
            (SELECT 1 FROM   dbo.FbBuchung WITH (READUNCOMMITTED) 
             WHERE  FbPeriodeID = @FbPeriodeID AND
                    (SollKtoNr = KTO.KontoNr OR HabenKtoNr = KTO.KontoNr) AND
                    BuchungsDatum <= IsNull(@PerDatum,BuchungsDatum)) OR
            IsNull(KTO.EroeffnungsSaldo,0) <> 0
          )
    ORDER BY KTO.KontoKlasseCode, KTO.KontoNr

  SELECT @SaldoAktiven  = SUM(Saldo), @VorSaldoAktiven  = SUM(Vorsaldo) FROM #tmp WHERE KlasseCode = 1
  SELECT @SaldoPassiven = SUM(Saldo), @VorSaldoPassiven = SUM(Vorsaldo) FROM #tmp WHERE KlasseCode = 2
  SELECT @SaldoAufwand  = SUM(Saldo), @VorSaldoAufwand  = SUM(Vorsaldo) FROM #tmp WHERE KlasseCode = 3
  SELECT @SaldoErtrag   = SUM(Saldo), @VorSaldoErtrag   = SUM(Vorsaldo) FROM #tmp WHERE KlasseCode = 4

  IF @SaldoAktiven + @SaldoPassiven > 0 BEGIN
    INSERT #tmp VALUES (1,'Aktiven' ,NULL,'Total Aktiven',@VorSaldoAktiven,@SaldoAktiven,NULL)
    INSERT #tmp VALUES (2,'Passiven',NULL,'Total Passiven',@VorSaldoPassiven,@SaldoPassiven,NULL)
    INSERT #tmp VALUES (2,'Passiven',NULL,'Vermögenszunahme',NULL,- @SaldoAktiven - @SaldoPassiven,NULL)
    INSERT #tmp VALUES (2,'Passiven',NULL,'Total',NULL,- @SaldoAktiven,NULL)
  END ELSE IF @SaldoAktiven + @SaldoPassiven < 0 BEGIN
    INSERT #tmp VALUES (1,'Aktiven' ,NULL,'Total Aktiven',@VorSaldoAktiven,@SaldoAktiven,NULL)
    INSERT #tmp VALUES (1,'Aktiven' ,NULL,'Vermögensabnahme',NULL,- @SaldoAktiven - @SaldoPassiven,NULL)
    INSERT #tmp VALUES (1,'Aktiven' ,NULL,'Total',NULL,- @SaldoPassiven,NULL)
    INSERT #tmp VALUES (2,'Passiven',NULL,'Total Passiven',@VorSaldoPassiven,@SaldoPassiven,NULL)
  END ELSE BEGIN
    INSERT #tmp VALUES (1,'Aktiven' ,NULL,'Total Aktiven',@VorSaldoAktiven,@SaldoAktiven,NULL)
    INSERT #tmp VALUES (2,'Passiven',NULL,'Total Passiven',@VorSaldoPassiven,@SaldoPassiven,NULL)
  END

  IF @SaldoAufwand + @SaldoErtrag > 0 BEGIN
    INSERT #tmp VALUES (3,'Aufwand',NULL,'Total Aufwand',@VorSaldoAufwand,@SaldoAufwand,NULL)
    INSERT #tmp VALUES (4,'Ertrag' ,NULL,'Total Ertrag',@VorSaldoAufwand,@SaldoErtrag,NULL)
    INSERT #tmp VALUES (4,'Ertrag' ,NULL,'Vermögensabnahme',NULL,- @SaldoAufwand - @SaldoErtrag,NULL)
    INSERT #tmp VALUES (4,'Ertrag' ,NULL,'Total',NULL,- @SaldoAufwand,NULL)
  END ELSE IF @SaldoAufwand + @SaldoErtrag < 0 BEGIN
    INSERT #tmp VALUES (3,'Aufwand',NULL,'Total Aufwand',@VorSaldoAufwand,@SaldoAufwand,NULL)
    INSERT #tmp VALUES (3,'Aufwand',NULL,'Vermögenszunahme',NULL,- @SaldoAufwand - @SaldoErtrag,NULL)
    INSERT #tmp VALUES (3,'Aufwand',NULL,'Total',NULL,- @SaldoErtrag,NULL)
    INSERT #tmp VALUES (4,'Ertrag' ,NULL,'Total Ertrag',@VorSaldoErtrag,@SaldoErtrag,NULL)
  END ELSE BEGIN
    INSERT #tmp VALUES (3,'Aufwand',NULL,'Total Aufwand',@VorSaldoAufwand,@SaldoAufwand,NULL)
    INSERT #tmp VALUES (4,'Ertrag' ,NULL,'Total Ertrag',@VorSaldoErtrag,@SaldoErtrag,NULL)
  END

  -- Saldogruppen
  INSERT #tmp
  SELECT
    99,
    'Saldogruppen',
    NULL,
    SaldoGruppeName,
    SUM(Vorsaldo),
    SUM(Saldo),
    NULL
  FROM #tmp
  WHERE SaldoGruppeName IS NOT NULL
  GROUP BY SaldoGruppeName
  ORDER BY SaldoGruppeName

  -- Total der Saldogruppen
  INSERT #tmp
  SELECT
    99,
    'Saldogruppen',
    NULL,
    'Total SaldoGruppen',
    SUM(Vorsaldo),
    SUM(Saldo),
    NULL
  FROM #tmp
  WHERE KlasseCode = 99

  SELECT @Mandant = PRS.Name + IsNull(', ' + PRS.Vorname,''),
         @Geburtsdatum = CONVERT(varchar,PRS.Geburtsdatum,104),
         @DatumBereich = CONVERT(varchar,PER.PeriodeVon,104) + ' - ' +
                         CONVERT(varchar,PER.PeriodeBis,104),
         @Team = TEA.Name
  FROM   dbo.FbPeriode PER WITH (READUNCOMMITTED) 
         INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) on PRS.BaPersonID = PER.BaPersonID
         LEFT  JOIN dbo.FbTeam    TEA WITH (READUNCOMMITTED) on TEA.FbTeamID = PER.FbTeamID
  WHERE  PER.FbPeriodeID = @FbPeriodeID

  --vorzeichen bei passiv- und ertragskonti invertieren
  UPDATE #tmp SET vorsaldo = -vorsaldo, saldo = -saldo WHERE klassecode in (2, 4)

  SELECT Mandant = @Mandant,
         Geburtsdatum = @Geburtsdatum,
         DatumBereich = @DatumBereich,
         Team = @Team,
         Klasse = CONVERT(varchar,KlasseCode) + '. ' + Klasse,
         KontoNr,
         KontoName,
         EroeffnungsSaldo = Vorsaldo ,
         Umsatz = CASE WHEN KlasseCode in (1,2,99)
                  THEN Saldo - Vorsaldo
                  ELSE NULL
                  END,
         Saldo,
         PerDatum = @PerDatum
  FROM   #tmp
  ORDER BY KlasseCode,ID
GO