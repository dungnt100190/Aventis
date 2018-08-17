SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgGetKontoblaetter
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgGetKontoblaetter.sql $
  $Author: Mmarghitola $
  $Modtime: 19.08.10 16:29 $
  $Revision: 15 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgGetKontoblaetter.sql $
 * 
 * 13    19.08.10 16:52 Mmarghitola
 * #6513: Vermögensabrechnungs-Änderungen
 * 
 * 12    21.04.10 16:11 Mmarghitola
 * #5908: jump-Paths mitliefern
 * 
 * 11    15.12.09 18:43 Mminder
 * #5572: Dokumente auf Kontoebene werden wieder angezeigt (Korrektur
 * Seiteneffekt Performanceoptimierung)
 * 
 * 10    11.12.09 11:36 Lloreggia
 * Header aktualisiert, ALTER -> CREATE
 * 
 * 9     10.12.09 14:48 Mmarghitola
 * #5572: Korrektur zu doppelten Einträgen / #5564 Performance
 * 
 * 8     3.11.09 8:08 Mmarghitola
 * #4892: Änderungen gemäss Spezifikation (Umgang mit Dokumenten)
 * 
 * 7     14.08.09 12:05 Mweber
 * #4713 neuer Input Parameter @Report für unterschiedliche Report
 * Sortierung
 * 
 * 6     12.08.09 11:29 Rstahel
 * #5052: Stornierte Kreditoren/Debitoren-Belege (d.h. Original- und
 * Stornobeleg) sind nun auch ausgeblendet, wenn das Flag "Ausgeglichene
 * Kreditoren/Debitoren ausblenden" angewählt ist.
 * 
 * 5     29.07.09 22:29 Mweber
 * #4713 Anpassung Sortierreihenfolge
 * 
 * 4     11.03.09 17:47 Mminder
 * #49, Korrektur: Belege bei Aufwand-/Ertrag-Konti nicht ausblenden
 * 
 * 3     11.02.09 12:12 Mminder
 * Neues Feature: Ausgeglichene Kreditoren-/Debitorenbuchungen können
 * ausgeblended werden
 * 
 * 2     9.02.09 14:20 Mminder
 * Aktuelle Version von Produktion
 * + Neue Spalten, um Dokumente im Kontoblatt-Grid anzuzeigen
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKgGetKontoblaetter]
 (@KgPeriodeID             int,
  @KontoNrVon              varchar(10),
  @KontoNrBis              varchar(10),
  @DatumVon                datetime,
  @DatumBis                datetime,
  @ValutaVon               datetime,
  @ValutaBis               datetime,
  @AusgeglicheneAusblenden bit = 0,
  @Report                  bit = 0)
WITH RECOMPILE -- Workaround für zeitweilige Performance-Probleme
AS
  SET NOCOUNT ON

  DECLARE @CurrKtoNr          varchar(10),
          @CurrKtoName        varchar(200),
          @CurrKgKontoartCode int,
          @KgBuchungID        int,
          @KgPositionID       int,
          @BuchungsDatum      datetime,
          @ValutaDatum        datetime,
          @Text               varchar(1000),
          @Betrag             money,
          @SollKtoNr          varchar(100),
          @HabenKtoNr         varchar(100),
          @Saldo              money,
          @SaldoS             money,
          @SaldoH             money,
          @SaldoDone          bit

  DECLARE @tmp TABLE (
    ID            int identity,
    KgBuchungID   int,
    KgPositionID  int,
    BuchungsDatum datetime,
    ValutaDatum   datetime,
    [Text]        varchar(1000),
    KtoName       varchar(120),
    GKtoNr        int,
    BetragSoll    money,
    BetragHaben   money,
    Saldo         money,
    KtoNr         INT,
    KgKontoartCode INT
  )

  --alle betroffenen Perioden (@DatumVon-@DatumBis kann periodenübergreifend sein)
  DECLARE @Periode TABLE (KgPeriodeID int PRIMARY KEY)

  INSERT INTO @Periode
    SELECT KgPeriodeID
    FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
    WHERE  FaLeistungID = (SELECT FaLeistungID FROM KgPeriode WHERE KgPeriodeID = @KgPeriodeID) AND
           dbo.fnDatumUeberschneidung(PeriodeVon,PeriodeBis,@DatumVon,@DatumBis) = 1

  -- loop über alle Kontonummern
  DECLARE cKontoNr CURSOR STATIC FOR
    SELECT DISTINCT KTO.KontoNr
    FROM   @Periode TMP
           INNER JOIN dbo.KgKonto KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
    WHERE  KTO.KontoGruppe = 0 AND
           KTO.KontoNr BETWEEN @KontoNrVon AND @KontoNrBis
    ORDER BY KontoNr

  OPEN cKontoNr
  FETCH NEXT FROM cKontoNr INTO @CurrKtoNr
  WHILE @@fetch_status = 0 BEGIN

	  SELECT @CurrKtoName = @CurrKtoNr + '  ' + max(KTO.KontoName), @CurrKgKontoartCode = MAX(KTO.KgKontoartCode)
	  FROM   @Periode TMP
             INNER JOIN dbo.KgKonto KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
	  WHERE  KTO.KontoNr = @CurrKtoNr

	  SET @Saldo = 0

    -- Vorsaldo der ersten Periode	
    SELECT TOP 1 @Saldo = Vorsaldo
	  FROM   @Periode TMP
             INNER JOIN dbo.KgPeriode PER WITH (READUNCOMMITTED) ON PER.KgPeriodeID = TMP.KgPeriodeID
             INNER JOIN dbo.KgKonto   KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = TMP.KgPeriodeID
	  WHERE  KTO.KontoNr = @CurrKtoNr
    ORDER BY PER.PeriodeVon

	  -- Saldovortrag berechnen für @CurrKtoNr
	  SELECT @SaldoS = IsNull(SUM(CASE WHEN SollKtoNr = @CurrKtoNr THEN Betrag ELSE 0 END),0),
	         @SaldoH = IsNull(SUM(CASE WHEN HabenKtoNr = @CurrKtoNr THEN Betrag ELSE 0 END),0)
	  FROM   @Periode TMP
             INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgPeriodeID = TMP.KgPeriodeID
	  WHERE  BUC.BuchungsDatum < @DatumVon AND
		     (SollKtoNr = @CurrKtoNr OR HabenKtoNr = @CurrKtoNr)

    IF @Saldo > 0
      SET @SaldoS = @SaldoS + @Saldo
    ELSE
      SET @SaldoH = @SaldoH - @Saldo

    SET @Saldo = @SaldoS - @SaldoH

    SET @SaldoDone = 0

    -- Saldovortrag eintragen, falls Saldo,SaldoS oder SaldoH <> 0 (falls keine weiteren Buchungen mehr vorhanden)
    IF @Saldo <> 0 OR (@SaldoS <> 0 OR @SaldoH <> 0) AND @SaldoH <> @SaldoS BEGIN
      INSERT @tmp VALUES (NULL, NULL, @DatumVon, NULL, 'Saldovortrag', @CurrKtoName, NULL, @SaldoS, @SaldoH, @Saldo, @CurrKtoNr, @CurrKgKontoartCode)
      SET @SaldoDone = 1
    END

    -- loop über alle Buchungen einer KontoNr innerhalb des DatumBereichs
    DECLARE cBuchung CURSOR STATIC FOR
      SELECT
        KgBuchungID,
        KgPositionID,
        BuchungsDatum,
        ValutaDatum,
        [Text],
        Betrag,
        SollKtoNr,
        HabenKtoNr
      FROM   @Periode             TMP
        INNER JOIN dbo.KgBuchung  BUC WITH (READUNCOMMITTED) ON BUC.KgPeriodeID = TMP.KgPeriodeID
        LEFT  JOIN
        (
          SELECT
            OpBuchungID,
            BetragAusgeglichen = SUM(Betrag)
          FROM dbo.KgOpAusgleich WITH (READUNCOMMITTED)
          GROUP BY OpBuchungID
        ) AUG1 ON AUG1.OpBuchungID = BUC.KgBuchungID AND AUG1.BetragAusgeglichen = BUC.Betrag
        LEFT  JOIN
        (
          SELECT
            AusgleichBuchungID,
            BetragAusgeglichen = SUM(Betrag)
          FROM dbo.KgOpAusgleich WITH (READUNCOMMITTED)
          GROUP BY AusgleichBuchungID
        ) AUG2 ON AUG2.AusgleichBuchungID = BUC.KgBuchungID AND AUG2.BetragAusgeglichen = BUC.Betrag
      WHERE  dbo.fnDateOf(BuchungsDatum) BETWEEN @DatumVon AND @DatumBis AND
             (SollKtoNr = @CurrKtoNr OR HabenKtoNr = @CurrKtoNr) AND
             (@AusgeglicheneAusblenden = 0 OR                                                 -- Nicht ausblenden
               NOT (																		             -- Ausblenden:
                              @CurrKgKontoartCode IS NOT NULL AND @CurrKgKontoartCode IN (2,3) AND 	     -- Ausblenden falls Kreditor oder Debitorkonto und
                                (AUG1.OpBuchungID IS NOT NULL OR AUG2.AusgleichBuchungID IS NOT NULL) OR -- ausgeglichene Buchung oder
                                 BUC.KgBuchungStatusCode IS NOT NULL AND BUC.KgBuchungStatusCode = 8     -- stornierte Buchung (Original- und Storno-Buchung)
                   )
             )
      ORDER BY ISNULL(BUC.ValutaDatum,dbo.fnDateOf(BuchungsDatum)) ASC, 
               CASE WHEN BUC.SollKtoNr = @CurrKtoNr THEN BUC.HabenKtoNr ELSE BUC.SollKtoNr END DESC,
               dbo.fnDateOf(BuchungsDatum) ASC 

    OPEN cBuchung
    FETCH NEXT FROM cBuchung INTO @KgBuchungID, @KgPositionID, @BuchungsDatum, @ValutaDatum, @Text, @Betrag, @SollKtoNr, @HabenKtoNr
    WHILE @@fetch_status = 0 BEGIN

      -- Saldovortrag eintragen, falls nicht schon weiter oben erfolgt
      IF @SaldoDone = 0 BEGIN
        INSERT @tmp VALUES (NULL, NULL, @DatumVon, NULL, 'Saldovortrag', @CurrKtoName, NULL, @SaldoS, @SaldoH, @Saldo, @CurrKtoNr, @CurrKgKontoartCode)
        SET @SaldoDone = 1
      END

      IF @SollKtoNr = @CurrKtoNr BEGIN
        SET @Saldo = @Saldo + @Betrag
        INSERT @tmp VALUES (@KgBuchungID, @KgPositionID, @BuchungsDatum, @ValutaDatum, @Text, @CurrKtoName, @HabenKtoNr ,@Betrag ,NULL ,@Saldo, @CurrKtoNr, @CurrKgKontoartCode)
      END ELSE BEGIN
        SET @Saldo = @Saldo - @Betrag
        INSERT @tmp VALUES (@KgBuchungID, @KgPositionID, @BuchungsDatum, @ValutaDatum, @Text, @CurrKtoName, @SollKtoNr, NULL, @Betrag, @Saldo, @CurrKtoNr, @CurrKgKontoartCode)
      END

      FETCH NEXT FROM cBuchung INTO @KgBuchungID, @KgPositionID, @BuchungsDatum, @ValutaDatum, @Text, @Betrag, @SollKtoNr, @HabenKtoNr
    END

    CLOSE cBuchung
    DEALLOCATE cBuchung

    FETCH NEXT FROM cKontoNr INTO @CurrKtoNr
  END

  CLOSE cKontoNr
  DEALLOCATE cKontoNr

  IF @ValutaVon IS NOT NULL
    DELETE @tmp WHERE IsNull(ValutaDatum,@ValutaVon) < @ValutaVon

  IF @ValutaBis IS NOT NULL
    DELETE @tmp WHERE IsNull(ValutaDatum,@ValutaBis) > @ValutaBis

  SELECT T.*,
         KontoNrBereich = CONVERT(varchar,@KontoNrVon) + ' - ' + CONVERT(varchar,@KontoNrBis),
         DatumBereich   = CONVERT(varchar,@DatumVon,104) + ' - ' + CONVERT(varchar,@DatumBis,104),
         Mandant        = PRS.NameVorname,
         PN             = PRS.BaPersonID,
         Geburtsdatum   = convert(varchar,PRS.Geburtsdatum,104),
         AnzahlDoc      = COALESCE(DOCB.Anzahl + DOC.Anzahl, DOCB.Anzahl, DOC.Anzahl),
         AnzahlKontoDoc = DOCK.Anzahl,
         DocIDsPosition = DOC.IDs,
         DocIDsBuchung  = DOCB.IDs,
         DocIDsKonto    = DOCK.IDs,
         JumpToMBPfad   = 'CtlKgLeistung' + convert(varchar, ISNULL(BDG.FaLeistungID, BDG2.FaLeistungID)) +
                          '\Masterbudget' + convert(varchar, ISNULL(BDG.KgMasterBudgetID, BDG2.KgMasterBudgetID)) + 
                          '\Monatsbudget' + convert(varchar, ISNULL(BDG.KgBudgetID, BDG2.KgBudgetID)),
         JumpToKgPositionID = ISNULL(POS.KgPositionID, BDG2.KgPositionID)
  FROM   @tmp T
         LEFT JOIN dbo.KgPeriode  PER WITH (READUNCOMMITTED) ON PER.KgPeriodeID = @KgPeriodeID
         LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = PER.FaLeistungID
         LEFT JOIN dbo.vwPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
         OUTER APPLY (SELECT KgPositionID, Anzahl = Count(*), IDs = dbo.ConcDistinct(KgDokumentID)
                    FROM   dbo.KgDokument WITH (READUNCOMMITTED)
                    WHERE KgPositionID = T.KgPositionID
                    GROUP BY KgPositionID) DOC
         OUTER APPLY (SELECT KgBuchungID, Anzahl = Count(*), IDs = dbo.ConcDistinct(KgDokumentID)
                    FROM   dbo.KgDokument WITH (READUNCOMMITTED)
                    WHERE KgBuchungID = T.KgBuchungID
                    GROUP BY KgBuchungID) DOCB
         OUTER APPLY (SELECT KgKontoID, Anzahl = Count(*), IDs = dbo.ConcDistinct(KgDokumentID)
                    FROM   dbo.KgDokument WITH (READUNCOMMITTED)
                    WHERE KgKontoID IN (SELECT KgKontoID FROM KgKonto WHERE KontoNr = convert(varchar(10), T.KtoNr) AND KgPeriodeID = @KgPeriodeID)
                    GROUP BY KgKontoID) DOCK
         LEFT  JOIN KgPosition    POS on POS.KgPositionID = T.KgPositionID
         LEFT  JOIN KgBudget      BDG on BDG.KgBudgetID = POS.KgBudgetID
         OUTER APPLY -- finde das Budget für Ausgleiche (es könnte mehrere geben, im Normalfall gibt es jedoch nur eins)
         (
           SELECT TOP 1 BDG3.KgBudgetID, FaLeistungID, KgMasterBudgetID, POS2.KgPositionID
           FROM KgOpAusgleich AUG
             INNER JOIN KgBuchung BUC2 ON BUC2.KgBuchungID = AUG.OpBuchungID
             INNER JOIN KgPosition POS2 ON POS2.KgPositionID = BUC2.KgPositionID
             INNER JOIN KgBudget BDG3 ON BDG3.KgBudgetID = POS2.KgBudgetID
           WHERE BDG.KgBudgetID IS NULL -- Suche das Budget nur, falls es noch nicht gefunden wurde
             AND AUG.AusgleichbuchungID = T.KgBuchungID
         ) BDG2
  ORDER BY T.KtoName, CASE WHEN @Report = 1 THEN T.ID ELSE -T.ID END

GO