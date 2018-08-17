SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbProcessAusgleichsinfo
GO
/*===============================================================================================
  $Revision: 3 $
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

CREATE PROCEDURE dbo.spKbProcessAusgleichsinfo
(
  @AusgleichBelegNr bigint,
  @AusgleichBetrag money,
  @AusgleichDatum datetime,
  @AusgleichGrund int,
  @EinzahlungDatum datetime,
  @PscdVertragsgegenstandID int,
  @PscdGeschaeftspartnerID int,
  @OPBelegNr bigint,
  @PosInOPBeleg int,
  @ZahlstapelID varchar(12),
  @PosInZahlstapel int,
  @OPUPW int,
  @OPUPZ int
)
AS

BEGIN TRAN
BEGIN TRY

  DECLARE @KbBuchungID int,
          @KbBuchungBruttoID int,
          @COUNT int,
          @msg varchar(200),
          @IstKreditorBuchung int,
          @IstDebitorBuchung int,
          @KbZahlungseingangID int,
          @GegenbuchungHabenKtoNr varchar(10),
          @GegenbuchungSollKtoNr varchar(10),
          @GegenbuchungText varchar(200),
          @KbPeriodeID int,
          @DebitorKtoNr varchar(10),
          @KreditorKtoNr varchar(10),
          @AuszahlKtoNr int,
          @OPText varchar(200),
          @OPHabenKtoNr int,
          @OPSollKtoNr int,
          @GegenbuchungID int,
          @IstForderung bit,
          @StorniertKbBuchungID bit,
          @KbBuchungTypCode bit,
          @AusgleichGrundText varchar(50),
          @ModulID int

  IF @AusgleichGrund NOT IN (1,2,5,8,10,11,15,99) BEGIN
    SET @msg = 'AusgleichsgrundCode ' + @AusgleichGrund + ' ist unbekannt'
    RAISERROR(@msg,18,1)
    RETURN
  END

  SELECT @AusgleichGrundText = dbo.fnLOVText('KbAusgleichGrund',@AusgleichGrund)

  -- Wir erhalten eine Belegnummer, wissen aber nicht in welcher Tabelle dieser abgelegt ist: KbBuchung, KbBuchungBrutto oder KgBuchung
  -- Probieren wir's mal in KbBuchungBrutto
  SELECT @COUNT = COUNT(*), @KbBuchungBruttoID = SUM(KbBuchungBruttoID), @IstForderung = CASE WHEN SUM(Betrag) > $0.00 THEN 1 ELSE 0 END
  FROM dbo.KbBuchungBrutto WITH (READUNCOMMITTED)
  WHERE BelegNr = @OPBelegNr
  GROUP BY BelegNr

  IF @COUNT > 1 BEGIN
    SET @msg = 'Es existieren '+@COUNT+' Bruttobelege mit Belegnummer '+@OPBelegNr+'! Die Belegnummer müsste eindeutig sein.'
    RAISERROR(@msg,18,1)
    RETURN
  END

  IF @COUNT = 1 BEGIN
    IF @IstForderung = 0 BEGIN
      -- Ausgleiche auf Bruttobelegen
      UPDATE KbBuchungBrutto
      SET BetragEffektiv = IsNull(BetragEffektiv,$0.00) - @AusgleichBetrag,
          DatumEffektiv = @AusgleichDatum,
          KbBuchungStatusCode = CASE WHEN Betrag = IsNull(BetragEffektiv,$0.00) - @AusgleichBetrag THEN 6 /*ausgeglichen*/ ELSE 10 /*teilweise ausgeglichen*/ END
      WHERE KbBuchungBruttoID = @KbBuchungBruttoID
      -- ToDo COMMIT
      ROLLBACK
      RETURN
    END

    SELECT @KbBuchungID = KBU.KbBuchungID
    FROM dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
      INNER JOIN dbo.KbBuchungKostenart    KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID      = KBP.BgPositionID
      INNER JOIN dbo.KbBuchung             KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID       = KBK.KbBuchungID AND IsNull(KBP.Schuldner_BaPersonID,-1) = IsNull(KBU.Schuldner_BaPersonID,-1) AND IsNull(KBP.Schuldner_BaInstitutionID,-1) = IsNull(KBU.Schuldner_BaInstitutionID,-1) AND KBU.ValutaDatum = KBB.ValutaDatum
    WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID
  END

  -- Probieren wir's mal in KbBuchung
  SELECT @COUNT = COUNT(*), @KbBuchungID = SUM(KbBuchungID)
  FROM dbo.KbBuchung WITH (READUNCOMMITTED)
  WHERE BelegNr = @OPBelegNr
  GROUP BY BelegNr

  IF @COUNT > 1 BEGIN
    SET @msg = 'Es existieren '+ CAST(@COUNT AS varchar) +' Nettobelege mit Belegnummer '+ CAST(@OPBelegNr AS varchar) +'! Die Belegnummer müsste eindeutig sein.'
    RAISERROR(@msg,18,1)
    RETURN
  END

  -- 1 Nettobeleg gefunden -> Ausgleichsmeldung dafür verarbeiten
  IF @COUNT = 1 BEGIN
    -- Infos aus OP holen
    SELECT @IstKreditorBuchung = CASE WHEN KRE.KbKontoID IS NOT NULL THEN 1 ELSE 0 END,
           @IstDebitorBuchung  = CASE WHEN DEB.KbKontoID IS NOT NULL THEN 1 ELSE 0 END,
           @KreditorKtoNr      = KRE.KontoNr,
           @DebitorKtoNr       = DEB.KontoNr,
           @AuszahlKtoNr       = AUZ.KontoNr,
           @KbPeriodeID        = KBU.KbPeriodeID,
           @ModulID            = KBU.ModulID,
           @OPHabenKtoNr       = KBU.HabenKtoNr,
           @OPSollKtoNr        = KBU.SollKtoNr,
           @OPText             = KBU.Text
    FROM dbo.KbBuchung      KBU WITH (READUNCOMMITTED)
      LEFT OUTER JOIN dbo.KbKonto KRE WITH (READUNCOMMITTED) ON KRE.KbPeriodeID = KBU.KbPeriodeID AND KBU.HabenKtoNr = KRE.KontoNr AND ',' + KRE.KbKontoartCodes + ',' LIKE '%,30,%'
      LEFT OUTER JOIN dbo.KbKonto DEB WITH (READUNCOMMITTED) ON DEB.KbPeriodeID = KBU.KbPeriodeID AND KBU.SollKtoNr  = DEB.KontoNr AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%'
      LEFT OUTER JOIN dbo.KbKonto AUZ WITH (READUNCOMMITTED) ON AUZ.KbPeriodeID = KBU.KbPeriodeID AND ((KBU.ModulID = 3 AND ',' + AUZ.KbKontoartCodes + ',' LIKE '%,5,%') /*Auszahlkonto Wh*/ OR (KBU.ModulID = 4 AND ',' + AUZ.KbKontoartCodes + ',' LIKE '%,6,%') /*Auszahlkonto Alim*/)
    WHERE KbBuchungID = @KbBuchungID

    IF @IstDebitorBuchung = 1 BEGIN
      -- Den vom Ausgleich referenzierten Zahlungseingang suchen
      IF @AusgleichGrund = 1 BEGIN --Einzahlung
        IF @ZahlstapelID IS NOT NULL AND @PosInZahlstapel IS NOT NULL BEGIN
          SELECT TOP 1 @KbZahlungseingangID = KbZahlungseingangID, @GegenbuchungSollKtoNr = KTO.KontoNr
          FROM KbZahlungseingang ZAE WITH (READUNCOMMITTED)
            LEFT OUTER JOIN dbo.KbPeriode  PER WITH (READUNCOMMITTED) ON PER.PeriodeVon <= ZAE.Datum AND PER.PeriodeBis >= ZAE.Datum
            LEFT OUTER JOIN dbo.KbKonto    KTO WITH (READUNCOMMITTED) ON KTO.KbPeriodeID = PER.KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,7,%' /*Zahlungseingangkonto*/ AND KTO.BankKontoNummer = ZAE.PscdBankverrechnKto
          WHERE PscdZahlungsstapel = @ZahlstapelID AND PscdZahlungsstapelPos = @PosInZahlstapel
        END

        -- Fallback: Wir haben noch kein Eingangskonto gefunden, also wird das generische verwendet
        SELECT @GegenbuchungSollKtoNr = IsNull(@GegenbuchungSollKtoNr,KontoNr)
        FROM dbo.KbKonto WITH (READUNCOMMITTED)
        WHERE KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,8,%' /*Zahlungseingangkonto nicht bestimmbar*/

        SET @KbBuchungTypCode = 4 --Ausgleich
      END
      ELSE IF @AusgleichGrund IN (5,10,11,99) BEGIN --Stornobuchungen
        SET @GegenbuchungSollKtoNr = @OPHabenKtoNr
        SET @StorniertKbBuchungID  = @KbBuchungID
        SET @KbBuchungTypCode      = 3 --Automatisch
      END
      ELSE BEGIN
        RAISERROR('Ungültige Ausgleichsdaten',18,1)
        RETURN
      END

      SET @GegenbuchungHabenKtoNr = @KreditorKtoNr
    END
    ELSE IF @IstKreditorBuchung = 1 BEGIN
      SET @GegenbuchungSollKtoNr = @KreditorKtoNr
      IF @AusgleichGrund = 2 BEGIN --Auszahlung
        SET @GegenbuchungHabenKtoNr = @AuszahlKtoNr
        SET @KbBuchungTypCode       = 4 --Ausgleich
      END
      ELSE IF @AusgleichGrund IN (5,10,11,99) BEGIN --Stornobuchungen
        SET @GegenbuchungHabenKtoNr = @OPSollKtoNr
        SET @StorniertKbBuchungID   = @KbBuchungID
        SET @KbBuchungTypCode       = 3 --Automatisch
      END
      ELSE BEGIN
        RAISERROR('Ungültige Ausgleichsdaten',18,1)
        RETURN
      END
    END
    ELSE BEGIN
      -- Stornobuchung
      SET @GegenbuchungHabenKtoNr = @OPSollKtoNr
      SET @GegenbuchungSollKtoNr  = @OPHabenKtoNr
      SET @StorniertKbBuchungID   = @KbBuchungID
      SET @KbBuchungTypCode       = 3 --Automatisch
/*
      SET @msg = 'Der Nettobeleg mit Belegnummer ' + CAST(@OPBelegNr as varchar) + ' ist weder eine Kreditor- noch eine Debitorbuchung! Deshalb kann kein Ausgleich mit Grund ' + @AusgleichGrundText + ' dazu verarbeitet werden'
      RAISERROR(@msg,18,1)
      RETURN
*/
    END

    SET @GegenbuchungText = CASE @AusgleichGrund WHEN  1 THEN IsNull(@OPText, 'Ausgleich durch Einzahlung')
                                                 WHEN  2 THEN IsNull(@OPText, 'Ausgleich durch Auszahlung')
                                                 WHEN  5 THEN 'Storno'
                                                 WHEN  8 THEN 'manuelle Kontenpflege'
                                                 WHEN 10 THEN 'Rückläufer'
                                                 WHEN 11 THEN 'Rücknahme Ausgleich'
                                                 WHEN 15 THEN 'maschinelle Kontenpflege'
                                                 WHEN 99 THEN 'OP wieder offen'
                            END

    -- Bereits vorhandene Gegenbuchung suchen
    SELECT @GegenbuchungID = KbBuchungID
    FROM dbo.KbBuchung WITH (READUNCOMMITTED)
    WHERE BelegNr = @AusgleichBelegNr

    IF @GegenbuchungID IS NULL BEGIN
      -- Gegenbuchung erstellen
      INSERT INTO KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegNr, BelegDatum, ValutaDatum, SollKtoNr, HabenKtoNr, Betrag, [Text], ModulID, ErstelltDatum, MutiertDatum, KbBuchungStatusCode, KbZahlungseingangID, StorniertKbBuchungID)
      VALUES (@KbPeriodeID, @KbBuchungTypCode, @AusgleichBelegNr, @AusgleichDatum, @EinzahlungDatum, @GegenbuchungSollKtoNr, @GegenbuchungHabenKtoNr, @AusgleichBetrag, @GegenbuchungText, @ModulID, GetDate(), GetDate(), 13 /*verbucht*/, @KbZahlungseingangID, @StorniertKbBuchungID)
      SELECT @GegenbuchungID = SCOPE_IDENTITY()
    END
    ELSE BEGIN
      -- Bereits bestehende Gegenbuchung verwenden, Betrag updaten
      UPDATE KbBuchung
      SET Betrag = Betrag + @AusgleichBetrag,
          [Text] = CASE WHEN [Text] LIKE '%' + @GegenbuchungText + '%' THEN [Text] ELSE IsNull([Text] + ', ', '') + @GegenbuchungText END
      WHERE KbBuchungID = @GegenbuchungID
    END

    INSERT INTO KbOpAusgleich(OpBuchungID, OpBuchungPosition, AusgleichBuchungID, KbAusgleichGrundCode, Betrag)
    VALUES (@KbBuchungID, @PosInOPBeleg, @GegenbuchungID, @AusgleichGrund, @AusgleichBetrag)


    DECLARE @TotAusgleichBetrag money
    SELECT @TotAusgleichBetrag = SUM(-Betrag)
	FROM   dbo.KbOpAusgleich WITH (READUNCOMMITTED)
	WHERE  OpBuchungID = @KbBuchungID

    UPDATE KbBuchung
	SET    KbBuchungStatusCode = CASE WHEN (Betrag >= $0.00 AND @TotAusgleichBetrag >= Betrag) /*Einnahmen*/ OR (Betrag <= $0.00 AND @TotAusgleichBetrag <= Betrag) /*Ausgaben*/ THEN 6 /*ausgeglichen*/
                                      WHEN @TotAusgleichBetrag = $0.00   THEN CASE WHEN KbBuchungStatusCode IN (3,10,6) THEN 3 ELSE KbBuchungStatusCode END
                                      ELSE 10 /*teilweise ausgeglichen*/
                                 END
	WHERE  KbBuchungID = @KbBuchungID

SELECT *
FROM   dbo.KbOpAusgleich WITH (READUNCOMMITTED)
WHERE  OpBuchungID = @KbBuchungID

SELECT *
FROM dbo.KbBuchung WITH (READUNCOMMITTED)
WHERE KbBuchungID IN (@KbBuchungID,@GegenbuchungID)

  END
  ROLLBACK
  --ToDo COMMIT
END TRY
BEGIN CATCH
  ROLLBACK
  SET @msg = 'Line ' + CAST(ERROR_LINE() AS varchar) + ': ' + ERROR_MESSAGE()
  RAISERROR(@msg,18,1)
END CATCH
