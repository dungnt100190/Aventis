SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE dbo.spDropObject fnBruttoToNettos
GO
/*===============================================================================================
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
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION [dbo].[fnBruttoToNettos]
(
  @KbBuchungBruttoPersonID INT,
  @BgPositionID INT,
  @Betrag MONEY,
  @ValutaDatum DATETIME
)
RETURNS @result TABLE
(
  Betrag FLOAT, -- voller Netto-Betrag (-> Umrechnung auf brutto nötig)
  BetragEffektiv FLOAT, -- effektiv bezahlter Betrag
  Anteil FLOAT,	-- bezahlter Anteil, wird ausgefüllt, falls alle Buchungen den gleichen Status haben (ausser teilausgeglichen und mehreren Netto-Belegen).
  AnzahlBelege INT,
  MinStatusCode INT,
  MaxStatusCode INT,
  Gelb BIT,
  Gruen BIT,
  Rot BIT,
  Storno BIT,
  DatumEffektiv DATETIME
)
AS
BEGIN
  DECLARE @kandidaten TABLE
  (
    KbBuchungID_Netto INT PRIMARY KEY,
    Betrag MONEY,
    Zustand INT
  );

  DECLARE @anzahl INT;

  -- Nachfolgendes INSERT deckt alle Idealfälle ab
  INSERT INTO @kandidaten
    SELECT KBU.KbBuchungID,
           SUM(KBK.Betrag),
           MAX(KBU.KbBuchungStatusCode)
    FROM dbo.KbBuchungBruttoPerson      KBP WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = KBP.BgPositionID
      INNER JOIN dbo.KbBuchung          KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
                                                                  AND KBU.ValutaDatum = @ValutaDatum
                                                                  AND (@Betrag < 0 OR ISNULL(KBP.Schuldner_BaPersonID, -1) =
                                                                                      ISNULL(KBU.Schuldner_BaPersonID, -1))
                                                                  AND (@Betrag < 0 OR ISNULL(KBP.Schuldner_BaInstitutionID, -1) =
                                                                                      ISNULL(KBU.Schuldner_BaInstitutionID, -1))
    WHERE KBP.KbBuchungBruttoPersonID = @KbBuchungBruttoPersonID
      AND KBP.BgPositionID = @BgPositionID
    GROUP BY KBU.KbBuchungID;

  SELECT @anzahl = COUNT(*)
  FROM @kandidaten;

  IF (@anzahl = 0)
  BEGIN
    -- Leider doch kein Idealfall.
    -- Durch eine verspätete Übertragung ans PSCD kann die Netto- und die Bruttobuchung ein unterschiedliches Datum aufweisen.
    INSERT INTO @kandidaten
      SELECT KBU.KbBuchungID,
             SUM(KBK.Betrag),
             MAX(KBU.KbBuchungStatusCode)
      FROM dbo.KbBuchungBruttoPerson      KBP WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = KBP.BgPositionID
        INNER JOIN dbo.KbBuchung          KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
                                                                       AND (@Betrag < 0 OR ISNULL(KBP.Schuldner_BaPersonID, -1) =
                                                                                           ISNULL(KBU.Schuldner_BaPersonID, -1))
                                                                       AND (@Betrag < 0 OR ISNULL(KBP.Schuldner_BaInstitutionID, -1) =
                                                                                           ISNULL(KBU.Schuldner_BaInstitutionID, -1))
      WHERE KBP.KbBuchungBruttoPersonID = @KbBuchungBruttoPersonID
        AND KBP.BgPositionID = @BgPositionID
      GROUP BY KBU.KbBuchungID;

    SELECT @anzahl = COUNT(*)
    FROM @kandidaten;
    
    IF (@anzahl = 0)
    BEGIN
      -- Eine Netto-Buchung mehrere Bruttobelege kann Schuldner_BaPersonID/Schuldner_BaInstitutionID mit Wert null haben
      INSERT INTO @kandidaten
        SELECT KBU.KbBuchungID,
               SUM(KBK.Betrag),
               MAX(KBU.KbBuchungStatusCode)
        FROM dbo.KbBuchungBruttoPerson      KBP WITH (READUNCOMMITTED)
          INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = KBP.BgPositionID
          INNER JOIN dbo.KbBuchung          KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
        WHERE KBP.KbBuchungBruttoPersonID = @KbBuchungBruttoPersonID
          AND KBP.BgPositionID = @BgPositionID
          AND (KBU.Schuldner_BaPersonID IS NULL AND KBU.Schuldner_BaInstitutionID IS NULL)
          AND KBU.ValutaDatum = @ValutaDatum
        GROUP BY KBU.KbBuchungID;

      SELECT @anzahl = COUNT(*)
      FROM @kandidaten;

      IF (@anzahl = 0)
      BEGIN
        -- letzter Versuch: wähle alle möglichen Kandidaten
        INSERT INTO @kandidaten
          SELECT KBU.KbBuchungID,
                 SUM(KBK.Betrag),
                 MAX(KBU.KbBuchungStatusCode)
          FROM dbo.KbBuchungBruttoPerson      KBP
            INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = KBP.BgPositionID
            INNER JOIN dbo.KbBuchung          KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
          WHERE KBP.KbBuchungBruttoPersonID = @KbBuchungBruttoPersonID
            AND KBP.BgPositionID = @BgPositionID
          GROUP BY KBU.KbBuchungID;
      END;
    END;
  END;

  SELECT @anzahl = COUNT(*)
  FROM @kandidaten;

  IF (@anzahl > 0)
  BEGIN
    INSERT INTO @result
      SELECT Betrag         = SUM(dbo.fnGetBetragEffektiv(KbBuchungID_Netto, Betrag)),
             BetragEffektiv = SUM(Betrag),
             Anteil         = CASE
                                WHEN COUNT(KDT.KbBuchungID_Netto) = 1 THEN MAX(dbo.fnGetBetragEffektiv(KbBuchungID_Netto, 1.0))
                                WHEN NOT(MAX(Zustand) <> MIN(Zustand) OR MAX(Zustand) = 10) THEN
                                  CASE
                                    WHEN MAX(Zustand) = 6 THEN 1.0
                                    ELSE 0.0
                                  END
                              END,
             AnzahlBelege   = COUNT(*),
             MinStatusCode  = MIN(Zustand),
             MaxStatusCode  = CASE
                                WHEN MAX(Zustand) = MIN(Zustand) THEN MAX(Zustand) -- Alle haben den gleichen Zustand
                                WHEN MAX(CASE
                                           WHEN Zustand = 6 OR Zustand = 10 THEN 1
                                           ELSE 0
                                         END) > 0 THEN 10 --Ein Teil wurde bezahlt
                                ELSE MAX(Zustand)
                              END,
             Gelb           = CASE -- Gelb: Zahlauftrag ausgeglichen, teilausgeglichen
                                WHEN MAX(CASE
                                           WHEN Zustand = 6 OR Zustand = 10 THEN 1
                                           ELSE 0
                                         END) > 0 THEN 1
                                ELSE 0
                              END,
             Gruen          = CASE
                                WHEN MAX(CASE
                                           WHEN Zustand = 2 OR Zustand = 3 OR Zustand = 4 OR Zustand = 9 THEN 1
                                           ELSE 0
                                         END) > 0 THEN 1
                                ELSE 0
                              END, -- Gruen: freigegeben, erstellt, ausgedruckt, Rückläufer
             Rot            = CASE
                                WHEN MAX(CASE
                                           WHEN Zustand = 7 THEN 1
                                           ELSE 0
                                         END) > 0 THEN 1
                                ELSE 0
                              END, -- Rot: gesperrt
             Storno         = CASE
                                WHEN MAX(CASE
                                           WHEN Zustand = 8 THEN 1
                                           ELSE 0
                                         END) > 0 THEN 1
                                ELSE 0
                              END, -- Storno: storniert
             DatumEffektiv  = (SELECT MAX(BUC.BelegDatum)
                               FROM dbo.KbOpAusgleich     KOA WITH (READUNCOMMITTED)
                                 INNER JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KOA.AusgleichBuchungID
                               WHERE KOA.OpBuchungID = MAX(KDT.KbBuchungID_Netto)
                                 AND BUC.BelegDatum IS NOT NULL)
      FROM @kandidaten KDT;
  END;
  RETURN;
END;
