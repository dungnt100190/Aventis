SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgZahlungseingaengeVerbuchenSVA
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgZahlungseingaengeVerbuchenSVA.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:39 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgZahlungseingaengeVerbuchenSVA.sql $
 * 
 * 4     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 3     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKgZahlungseingaengeVerbuchenSVA]
AS

BEGIN TRY
	BEGIN TRANSACTION    
	--INIT
	DECLARE 	
	@msg varchar(200),
	@herkunft varchar(3),
	@verbuchteEingaenge int
	set @herkunft = 'SVA'

	--PROCESS
	DECLARE @MehrfachZuordenbar TABLE
	(
	  KgZahlungseingangID int
	)


	INSERT INTO @MehrfachZuordenbar
      SELECT ZAL.KgZahlungseingangID
      FROM KgZahlungseingang  ZAL WITH (READUNCOMMITTED)
        INNER JOIN KgBuchung  BUC WITH (READUNCOMMITTED) ON BUC.Betrag       = ZAL.Betrag
        INNER JOIN KgPosition POS WITH (READUNCOMMITTED) ON POS.KgPositionID = BUC.KgPositionID
        INNER JOIN KgBudget   BUD WITH (READUNCOMMITTED) ON BUD.KgBudgetID   = POS.KgBudgetID
        INNER JOIN FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BUD.FaLeistungID
        INNER JOIN BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID   = LEI.BaPersonID AND ZAL.BaPersonID = PRS.BaPersonID
        -- Konti bestimmen
        INNER JOIN KgKonto    KKK WITH (READUNCOMMITTED) ON KKK.KgKontoartCode = 1 AND KKK.KgPeriodeID = BUC.KgPeriodeID
        INNER JOIN KgKonto    DBK WITH (READUNCOMMITTED) ON DBK.KgKontoartCode = 2 AND DBK.KgPeriodeID = BUC.KgPeriodeID
        INNER JOIN XLOVCode   MON WITH (READUNCOMMITTED) ON MON.LOVName = 'Monat' AND MON.Code = BUD.Monat
      WHERE KgPositionsKategorieCode = 3
        AND (Mitteilung LIKE '% SVA %' OR Mitteilung LIKE '%SOZIALVERSICHERUNGSANSTA%' OR Mitteilung LIKE '%AUSGLEICH%' OR Mitteilung LIKE '%AHV-KASSE%' OR Mitteilung LIKE '%AHV%')
        AND (Mitteilung LIKE '%___.__.___.___%' /*AHV*/ OR Mitteilung LIKE '%___.____.____.__%' /*VersichertenNr*/)
        AND Ausgeglichen = 0
        AND BUC.KgBuchungStatusCode = 2
        AND (SUBSTRING(ZAL.Mitteilung, PATINDEX('%___.__.___.___%', ZAL.Mitteilung), 14)         = PRS.AHVNummer
          OR SUBSTRING(ZAL.Mitteilung, PATINDEX('%___.__.___.___%', ZAL.Mitteilung), 11) + '000' = PRS.AHVNummer          -- AHV vergleichen
          OR SUBSTRING(ZAL.Mitteilung, PATINDEX('%___.____.____.__%', ZAL.Mitteilung), 16)       = PRS.Versichertennummer)-- VersichertenNr vergleichen
        AND (Mitteilung LIKE '%' + MON.Text + '%' OR Mitteilung LIKE '%' + MON.ShortText + ' ' + CAST(BUD.Jahr as varchar) + '%' OR
             Mitteilung LIKE '%' + CAST(BUD.Monat as varchar) + '.' + RIGHT(CAST(BUD.Jahr as varchar),2) + '%' OR
             Mitteilung LIKE '%' + REPLACE(MON.Text,'ä','ae') + '%' OR Mitteilung LIKE '%' + REPLACE(MON.ShortText,'ä','ae') + ' ' + CAST(BUD.Jahr as varchar) + '%') --die März-Zeile...
      GROUP BY ZAL.KgZahlungseingangID
      HAVING COUNT(*) > 1

	  SELECT KgZahlungseingangID
	  FROM @MehrfachZuordenbar


	DECLARE cZuordnungen CURSOR FAST_FORWARD FOR
	  SELECT BUC.KgBuchungID, BUC.KgPeriodeID, ZAL.KgZahlungseingangID, ZAL.Datum, KKK.KontoNr, DBK.KontoNr, ZAL.Betrag, BUC.Text
	  FROM dbo.KgZahlungseingang  ZAL WITH (READUNCOMMITTED) 
		INNER JOIN dbo.KgBuchung  BUC WITH (READUNCOMMITTED) ON BUC.Betrag       = ZAL.Betrag
		INNER JOIN dbo.KgPosition POS WITH (READUNCOMMITTED) ON POS.KgPositionID = BUC.KgPositionID
		INNER JOIN dbo.KgBudget   BUD WITH (READUNCOMMITTED) ON BUD.KgBudgetID   = POS.KgBudgetID
		INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BUD.FaLeistungID
		INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID   = LEI.BaPersonID AND ZAL.BaPersonID = PRS.BaPersonID
		-- Konti bestimmen
		INNER JOIN dbo.KgKonto    KKK WITH (READUNCOMMITTED) ON KKK.KgKontoartCode = 1 AND KKK.KgPeriodeID = BUC.KgPeriodeID
		INNER JOIN dbo.KgKonto    DBK WITH (READUNCOMMITTED) ON DBK.KgKontoartCode = 2 AND DBK.KgPeriodeID = BUC.KgPeriodeID
		INNER JOIN dbo.XLOVCode   MON WITH (READUNCOMMITTED) ON MON.LOVName = 'Monat' AND MON.Code = BUD.Monat
		LEFT OUTER JOIN @MehrfachZuordenbar DPL              ON DPL.KgZahlungseingangID = ZAL.KgZahlungseingangID
      WHERE KgPositionsKategorieCode = 3
        AND (Mitteilung LIKE '% SVA %' OR Mitteilung LIKE '%SOZIALVERSICHERUNGSANSTA%' OR Mitteilung LIKE '%AUSGLEICH%' OR Mitteilung LIKE '%AHV-KASSE%' OR Mitteilung LIKE '%AHV%')
        AND (Mitteilung LIKE '%___.__.___.___%' OR Mitteilung LIKE '%___.____.____.__%')
        AND Ausgeglichen = 0
        AND BUC.KgBuchungStatusCode = 2
        AND (SUBSTRING(ZAL.Mitteilung, PATINDEX('%___.__.___.___%', ZAL.Mitteilung), 14)         = PRS.AHVNummer
          OR SUBSTRING(ZAL.Mitteilung, PATINDEX('%___.__.___.___%', ZAL.Mitteilung), 11) + '000' = PRS.AHVNummer          -- AHV vergleichen
          OR SUBSTRING(ZAL.Mitteilung, PATINDEX('%___.____.____.__%', ZAL.Mitteilung), 16)       = PRS.Versichertennummer)-- VersichertenNr vergleichen

        AND (Mitteilung LIKE '%' + MON.Text + '%' OR
             Mitteilung LIKE '%' + MON.ShortText + ' ' + CAST(BUD.Jahr as varchar) + '%' OR
             Mitteilung LIKE '%' + CAST(BUD.Monat as varchar) + '.' + RIGHT(CAST(BUD.Jahr as varchar),2) + '%' OR
             Mitteilung LIKE '%' + CAST(BUD.Monat as varchar) + '.' +       CAST(BUD.Jahr as varchar)    + '%' OR
             Mitteilung LIKE '%' + REPLACE(MON.Text,'ä','ae') + '%' OR Mitteilung LIKE '%' + REPLACE(MON.ShortText,'ä','ae') + ' ' + CAST(BUD.Jahr as varchar) + '%') --die März-Zeile...
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
--select @KgBuchungID, @KgPeriodeID, @KgZahlungseingangID, @ValutaDatum, @SollKtoNr, @HabenKtoNr, @Betrag, @Text
	  -- Gegenbuchung erstellen
	  INSERT INTO KgBuchung (KgPeriodeID, KgBuchungTypCode, KgZahlungseingangID, BuchungsDatum, ValutaDatum, SollKtoNr, HabenKtoNr, Betrag, Text, ErstelltDatum)
	  VALUES (@KgPeriodeID, 3, @KgZahlungseingangID, GETDATE(), @ValutaDatum, @SollKtoNr, @HabenKtoNr, @Betrag, @Text, GETDATE())
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

	SET @verbuchteEingaenge = @Count

	--Log-Eintrag
	INSERT INTO [KgZahlungsEingaengeLog](Source, VerbuchteEingaenge)
	VALUES (@herkunft, @verbuchteEingaenge)
	--SET @ID = SCOPE_IDENTITY()

	COMMIT
END TRY

BEGIN CATCH  
	IF @@TRANCOUNT > 0
		ROLLBACK

	SET @msg = 'Line ' + CAST(ERROR_LINE() as varchar) + ': ' + ERROR_MESSAGE()
	--Log
	INSERT INTO [KgZahlungsEingaengeLog](Source, VerbuchteEingaenge, Fehlermeldung)
	VALUES (@herkunft, @verbuchteEingaenge, @msg)
	
	RAISERROR(@msg,18,1)
END CATCH

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
