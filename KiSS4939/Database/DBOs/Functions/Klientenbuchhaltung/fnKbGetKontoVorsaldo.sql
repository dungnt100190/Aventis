SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKbGetKontoVorsaldo;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Berechnet das Vorsaldo einen Konto an einen gebenenes Datum
    @KbPeriodeID:       ID der Periode zu berücksichtigen
    @KontoNr:           Kontonummer vom Konto für welches das Vorsaldo berechnet sein muss
    @Datum:             Datum für welches das Vorsaldo berechnet sein muss
    @AuchUnverbuchteZE: Ob unverbuchte Zahlungseingänge auch berücksichtigt werden müssen
  -
  RETURNS: Das Vorsaldo einen Konto oder NULL wenn die Parameter ungültig sind
=================================================================================================
  TEST:    SELECT dbo.fnKbGetKontoVorsaldo(32, '2000.302', '20100101', 0);
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetKontoVorsaldo
(
  @KbPeriodeID       INT,
  @KontoNr           VARCHAR(10),
  @Datum             DATETIME,
  @AuchUnverbuchteZE BIT = 0
)
RETURNS MONEY
AS BEGIN
  DECLARE @Vorsaldo MONEY;
  DECLARE @Soll     MONEY;
  DECLARE @Haben    MONEY;
  DECLARE @BetragZE MONEY;
          
  -----------------------------------------------------------------------------
  -- Validierung den Parametern
  -----------------------------------------------------------------------------
  IF (@KbPeriodeID IS NULL OR @KontoNr IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  -- Periode vorhanden
  IF (NOT EXISTS(SELECT TOP 1 1 
                 FROM dbo.KbPeriode WITH (READUNCOMMITTED)
                 WHERE KbPeriodeID = @KbPeriodeID))
  BEGIN
    RETURN NULL;
  END;
  
  -- Konto vorhanden
  IF (NOT EXISTS(SELECT TOP 1 1 
                 FROM dbo.KbKonto WITH (READUNCOMMITTED)
                 WHERE KbPeriodeID = @KbPeriodeID 
                   AND KontoNr = @KontoNr))
  BEGIN
    RETURN NULL;
  END;
  
  SET @AuchUnverbuchteZE = ISNULL(@AuchUnverbuchteZE, 0);

  -----------------------------------------------------------------------------
  -- Vorsaldo berechnen
  -----------------------------------------------------------------------------
  SELECT @Vorsaldo   = ISNULL(Vorsaldo, 0)
  FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
  WHERE KTO.KbPeriodeID = @KbPeriodeID
    AND KTO.KontoNr = @KontoNr;

  -- Buchungen die vor dem Datum erfolgten abzählen
  IF (@Datum IS NOT NULL)
  BEGIN
    -- Soll- und Habenbetrag summieren
    ;WITH CTE
     AS
     (
         SELECT Soll = CASE WHEN (BUC.SollKtoNr = @KontoNr OR (BUC.SollKtoNr IS NULL AND BKO.KontoNr = @KontoNr)) THEN ISNULL(BKO.Betrag, BUC.Betrag) ELSE 0 END,
                Haben = CASE WHEN (BUC.HabenKtoNr = @KontoNr OR (BUC.HabenKtoNr IS NULL AND BKO.KontoNr = @KontoNr)) THEN ISNULL(BKO.Betrag, BUC.Betrag) ELSE 0 END
         FROM dbo.KbBuchung                 BUC WITH (READUNCOMMITTED)
           LEFT JOIN dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED) ON BKO.KbBuchungID = BUC.KbBuchungID
           LEFT JOIN dbo.KbZahlungseingang  ZEG WITH (READUNCOMMITTED) ON ZEG.KbZahlungseingangID = BUC.KbZahlungseingangID 
         WHERE BUC.KbPeriodeID = @KbPeriodeID
           AND BUC.BelegNr IS NOT NULL
           AND BUC.BelegDatum IS NOT NULL
           AND BUC.Betrag <> 0       
           AND ((BUC.SollKtoNr = @KontoNr OR (BUC.SollKtoNr IS NULL AND BKO.KontoNr = @KontoNr))
             OR (BUC.HabenKtoNr = @KontoNr OR (BUC.HabenKtoNr IS NULL AND BKO.KontoNr = @KontoNr)))
           AND BUC.BelegDatum < @Datum
           AND ISNULL(ZEG.Ausgeglichen, 1) = 1 -- nur verbuchte Zahlungseingänge     
     ) 

    SELECT @Soll = SUM(Soll), @Haben = SUM(Haben)
    FROM Cte

    -- Vorsaldo berechnen
    SET @Vorsaldo = @Vorsaldo + @Soll - @Haben;
    
    IF (@AuchUnverbuchteZE = 1)
    BEGIN
      SELECT @BetragZE = ISNULL(SUM(ZEG.Betrag), 0)
      FROM dbo.KbZahlungseingang ZEG WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbPeriode PRD WITH (READUNCOMMITTED) ON PRD.KbPeriodeID = @KbPeriodeID
      WHERE ZEG.KontoNr = @KontoNr
        AND dbo.fnDateOf(ZEG.Datum) < @Datum
        AND dbo.fnDateOf(ZEG.Datum) >= PRD.PeriodeVon
        AND dbo.fnDateOf(ZEG.Datum) <= PRD.PeriodeBis
        AND ZEG.Ausgeglichen = 0; -- noch nicht verbucht
        
      SET @Vorsaldo = @Vorsaldo + ISNULL(@BetragZE, 0);
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @Vorsaldo;
END;
GO
