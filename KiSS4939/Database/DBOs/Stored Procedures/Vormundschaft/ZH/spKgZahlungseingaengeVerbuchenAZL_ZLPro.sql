 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject spKgZahlungseingaengeVerbuchenAZL_ZLPro
GO
/*===============================================================================================
  $Revision: 6$
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

CREATE PROCEDURE dbo.spKgZahlungseingaengeVerbuchenAZL_ZLPro
AS

BEGIN TRY
  BEGIN TRANSACTION
  --INIT
  DECLARE
  @msg varchar(200),
  @Herkunft varchar(3),
  @VerbuchteEingaenge int
  SET @Herkunft = 'AZL'

  --PROCESS
  DECLARE @MehrfachZuordenbar TABLE
  (
    KgZahlungseingangID int
  )

  INSERT INTO @MehrfachZuordenbar
    SELECT ZAL.KgZahlungseingangID
    FROM dbo.KgZahlungseingang  ZAL WITH (READUNCOMMITTED) 
      INNER JOIN dbo.KgBuchung  BUC WITH (READUNCOMMITTED) on BUC.Betrag       = ZAL.Betrag
      INNER JOIN dbo.KgPosition POS WITH (READUNCOMMITTED) on POS.KgPositionID = BUC.KgPositionID
      INNER JOIN dbo.KgBudget   BUD WITH (READUNCOMMITTED) ON BUD.KgBudgetID   = POS.KgBudgetID
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BUD.FaLeistungID
      INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID   = LEI.BaPersonID AND ZAL.BaPersonID = PRS.BaPersonID
      -- Konti bestimmen
      INNER JOIN dbo.KgKonto    KKK WITH (READUNCOMMITTED) ON KKK.KgKontoartCode = 1 AND KKK.KgPeriodeID = BUC.KgPeriodeID
      INNER JOIN dbo.KgKonto    DBK WITH (READUNCOMMITTED) ON DBK.KgKontoartCode = 2 AND DBK.KgPeriodeID = BUC.KgPeriodeID
    WHERE KgPositionsKategorieCode = 3
      AND Mitteilung LIKE '%ZL AHV/IV/_______/__________%____/__/_____/____'
      AND Ausgeglichen = 0
      AND BUC.KgBuchungStatusCode = 2
      AND CAST(SUBSTRING(ZAL.Mitteilung, PATINDEX('%ZL AHV/IV/_______/__________%', ZAL.Mitteilung) + 18, 10) AS int) = PRS.EinwohnerregisterID -- PID vergleichen
      AND CAST(SUBSTRING(ZAL.Mitteilung, PATINDEX('%____/__/_____/____', ZAL.Mitteilung) + 15, 2) AS int) = BUD.Monat
      AND CAST(SUBSTRING(ZAL.Mitteilung, PATINDEX('%____/__/_____/____', ZAL.Mitteilung) + 17, 2) AS int) + 2000 = BUD.Jahr
    GROUP BY ZAL.KgZahlungseingangID
    HAVING COUNT(*) > 1

  --  SELECT KgZahlungseingangID
  --  FROM @MehrfachZuordenbar


  DECLARE cZuordnungen CURSOR FAST_FORWARD FOR
  SELECT BUC.KgBuchungID, BUC.KgPeriodeID, ZAL.KgZahlungseingangID, ZAL.Datum, KKK.KontoNr, DBK.KontoNr, ZAL.Betrag, BUC.Text
  FROM dbo.KgZahlungseingang  ZAL WITH (READUNCOMMITTED) 
    INNER JOIN dbo.KgBuchung  BUC WITH (READUNCOMMITTED) on BUC.Betrag       = ZAL.Betrag
    INNER JOIN dbo.KgPosition POS WITH (READUNCOMMITTED) on POS.KgPositionID = BUC.KgPositionID
    INNER JOIN dbo.KgBudget   BUD WITH (READUNCOMMITTED) ON BUD.KgBudgetID   = POS.KgBudgetID
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BUD.FaLeistungID
    INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID   = LEI.BaPersonID AND ZAL.BaPersonID = PRS.BaPersonID
    -- Konti bestimmen
    INNER JOIN dbo.KgKonto    KKK WITH (READUNCOMMITTED) ON KKK.KgKontoartCode = 1 AND KKK.KgPeriodeID = BUC.KgPeriodeID
    INNER JOIN dbo.KgKonto    DBK WITH (READUNCOMMITTED) ON DBK.KgKontoartCode = 2 AND DBK.KgPeriodeID = BUC.KgPeriodeID
    LEFT  JOIN @MehrfachZuordenbar DPL ON DPL.KgZahlungseingangID = ZAL.KgZahlungseingangID
  WHERE KgPositionsKategorieCode = 3
    AND Mitteilung LIKE '%ZL AHV/IV/_______/__________%____/__/_____/____'
    AND Ausgeglichen = 0
    AND BUC.KgBuchungStatusCode = 2
    AND CAST(SUBSTRING(ZAL.Mitteilung, PATINDEX('%ZL AHV/IV/_______/__________%', ZAL.Mitteilung) + 18, 10) AS int) = PRS.EinwohnerregisterID -- PID vergleichen
    AND CAST(SUBSTRING(ZAL.Mitteilung, PATINDEX('%____/__/_____/____', ZAL.Mitteilung) + 15, 2) AS int) = BUD.Monat
    AND CAST(SUBSTRING(ZAL.Mitteilung, PATINDEX('%____/__/_____/____', ZAL.Mitteilung) + 17, 2) AS int) + 2000 = BUD.Jahr
    AND DPL.KgZahlungseingangID IS NULL

  DECLARE @KgBuchungID         int
  DECLARE @KgPeriodeID         int
  DECLARE @KgZahlungseingangID int
  DECLARE @ValutaDatum         datetime
  DECLARE @SollKtoNr           int
  DECLARE @HabenKtoNr          int
  DECLARE @Betrag              money
  DECLARE @Text                varchar(200)
  DECLARE @GegenbuchungID      int
  DECLARE @Count               int

  SET @Count = 0

  OPEN cZuordnungen
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cZuordnungen INTO @KgBuchungID, @KgPeriodeID, @KgZahlungseingangID, @ValutaDatum, @SollKtoNr, @HabenKtoNr, @Betrag, @Text
    IF @@FETCH_STATUS <> 0 BREAK

    -- Gegenbuchung erstellen
    INSERT INTO KgBuchung (KgPeriodeID, KgBuchungTypCode, KgZahlungseingangID, BuchungsDatum, ValutaDatum, SollKtoNr, HabenKtoNr, Betrag, Text, ErstelltDatum)
    VALUES (@KgPeriodeID, 3, @KgZahlungseingangID, GetDate(), @ValutaDatum, @SollKtoNr, @HabenKtoNr, @Betrag, @Text, GetDate())
    SELECT @GegenbuchungID = SCOPE_IDENTITY()

    -- Ausgleich eintragen
    INSERT INTO KgOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag)
    VALUES (@KgBuchungID, @GegenbuchungID, @Betrag)

    -- OP auf Status ausgeglichen setzen
    UPDATE KgBuchung
    SET    KgBuchungStatusCode = 6
    WHERE  KgBuchungID = @KgBuchungID
    
    -- Zahlungseingang auf Status ausgeglichen setzen
    UPDATE KgZahlungseingang
    SET    Ausgeglichen = 1
    WHERE  KgZahlungseingangID = @KgZahlungseingangID


    SET @Count = @Count + 1
  END

  CLOSE cZuordnungen
  DEALLOCATE cZuordnungen

  SET @VerbuchteEingaenge = @Count

  --Log-Eintrag
  INSERT INTO [KgZahlungsEingaengeLog](Source, VerbuchteEingaenge)
  VALUES (@Herkunft, @VerbuchteEingaenge)
  --SET @ID = SCOPE_IDENTITY()

  COMMIT
END TRY

BEGIN CATCH  
  IF @@TRANCOUNT > 0
    ROLLBACK

  SET @msg = 'Line ' + CAST(ERROR_LINE() AS varchar) + ': ' + ERROR_MESSAGE()
  --Log
  INSERT INTO [KgZahlungsEingaengeLog](Source, VerbuchteEingaenge, Fehlermeldung)
  VALUES (@Herkunft, @VerbuchteEingaenge, @msg)
  
  RAISERROR(@msg,18,1)
END CATCH
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
