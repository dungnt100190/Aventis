SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbAuszahlungAlimentenvermittlungErstellen;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Auszahlbelege für Alimentenvermittlung eines Zahlungseingangs automatisch erstellen
    @KbZahlungseingangID: ID des Zahlungseingangs zu analysieren um Auszahlungen zu erstellen
    @KbPeriodeID:         ID der Periode
    @UserID:              ID des Users
  -
  RETURNS: .
  -
  TEST:    EXEC dbo.spKbAuszahlungAlimentenvermittlungErstellen 1, 28, 75
=================================================================================================*/

CREATE PROCEDURE dbo.spKbAuszahlungAlimentenvermittlungErstellen
(
  @KbZahlungseingangID INT,
  @KbPeriodeID         INT,
  @UserID              INT
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- declare and init vars
  -------------------------------------------------------------------------------
  DECLARE @KbBuchungID_Zahlungseingang INT,
          @KrediKtoNr                  VARCHAR(10),
          @UserName                    VARCHAR(50),
          @PraefixBuchungstext         VARCHAR(200);

  SET @UserName = dbo.fnGetDBRowCreatorModifier(@UserID);
  SELECT @PraefixBuchungstext = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\PraefixBuchungstextAuszahlung', GETDATE())), '');

  DECLARE @KbBuchung_Forderung TABLE(
    KbBuchungID        INT NOT NULL,
    KbOpAusgleichID    INT NOT NULL,
    Betrag             MONEY,
    BetragAusgeglichen MONEY,
    BetragAusbezahlt   MONEY,
    Buchungstext       VARCHAR(200)
  );

  -- Kreditorkontonummer suchen
  SELECT TOP 1 @KrediKtoNr = KontoNr
  FROM dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE KbPeriodeID = @KbPeriodeID
    AND '%,'+KbKontoArtCodes+',%' LIKE '%,30,%';

  -- Buchung des Zahlungseinganges
  SELECT @KbBuchungID_Zahlungseingang = KbBuchungID
  FROM dbo.KbBuchung WITH (READUNCOMMITTED)
  WHERE KbZahlungseingangID = @KbZahlungseingangID;
  PRINT('Zahlungseingang KbBuchungID = ' + ISNULL(CONVERT(VARCHAR, @KbBuchungID_Zahlungseingang), 'NULL'));

  -------------------------------------------------------------------------------
  -- Forderungsbuchungen die mit dem Zahlungseingang ausgeglichen worden sind
  -------------------------------------------------------------------------------
  ;WITH BetragCte
  AS
  (
    -- Betrag der Forderung und ausgeglichenen Betrag berechnen
    SELECT
      OPA.OpBuchungID,
      OPA.KbOpAusgleichID,
      BetragForderung = SUM(BUC.Betrag),
      BetragAusgleich = SUM(OPA.Betrag),
      Text = MIN(BUC.Text)
    FROM dbo.KbOpAusgleich                 OPA  WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchung             BUC  WITH (READUNCOMMITTED)
                                                ON BUC.KbBuchungID = OPA.OpBuchungID -- Originalbuchung (Forderung)
    WHERE OPA.AusgleichBuchungID = @KbBuchungID_Zahlungseingang -- Ausgleichsbuchung (Zahlungseingang)
      AND BUC.IkPositionID IS NOT NULL -- Buchung kommt aus dem Inkasso
    GROUP BY OPA.OpBuchungID, OPA.KbOpAusgleichID
  )

  -- Ausbezahlten Betrag auch noch berechnen
  INSERT INTO @KbBuchung_Forderung(KbBuchungID, KbOpAusgleichID, Betrag, BetragAusgeglichen, BetragAusbezahlt, Buchungstext)
  SELECT
    CTE.OpBuchungID,
    CTE.KbOpAusgleichID,
    BetragForderung = MIN(CTE.BetragForderung),
    BetragAusgleich = MIN(CTE.BetragAusgleich),
    BetragAusbezahlt = SUM(ISNULL(BUCA.Betrag, 0)),
    Text = MIN(CTE.Text)
  FROM BetragCte CTE
    LEFT  JOIN dbo.KbForderungAuszahlung AUS  WITH (READUNCOMMITTED)
                                              ON AUS.KbBuchungID_Forderung = CTE.OpBuchungID
    LEFT  JOIN dbo.KbBuchung             BUCA WITH (READUNCOMMITTED)
                                              ON BUCA.KbBuchungID = AUS.KbBuchungID_Auszahlung
    LEFT  JOIN dbo.KbBuchungKostenart    BKOA WITH (READUNCOMMITTED)
                                              ON BKOA.KbBuchungID = BUCA.KbBuchungID
  WHERE (BKOA.KbForderungArtCode IS NULL OR BKOA.KbForderungArtCode <> 10) -- ALBV-Forderung nich berücksichtigen (Betrag zwischen Forderung und Auszahlung kann wegen einer Verrechnung unterschiedlich sein)
  GROUP BY CTE.OpBuchungID, CTE.KbOpAusgleichID;
  PRINT('Forderungsbuchungen die mit dem Zahlungseingang ausgeglichen worden sind. COUNT = ' + CONVERT(VARCHAR, @@ROWCOUNT));

  -------------------------------------------------------------------------------
  -- init vars and table for loop
  -------------------------------------------------------------------------------
  DECLARE @Loop TABLE(
    ID              INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    KbBuchungID     INT NOT NULL,
    KbOpAusgleichID INT NOT NULL
  );

  DECLARE @EntriesCount    INT,
          @EntriesIterator INT;

  DECLARE @KbBuchungID_Forderung INT,
          @KbOpAusgleichID       INT,
          @Betrag                MONEY,
          @BetragAusgeglichen    MONEY,
          @BetragAusbezahlt      MONEY,
          @Buchungstext          VARCHAR(200);

  DECLARE @KbBuchungID_New INT;

  -------------------------------------------------------------------------------
  -- insert entries into temp table
  -------------------------------------------------------------------------------
  INSERT INTO @Loop(KbBuchungID, KbOpAusgleichID)
    SELECT
      BUC.KbBuchungID,
      BUC.KbOpAusgleichID
    FROM @KbBuchung_Forderung BUC
    WHERE BUC.BetragAusbezahlt < BUC.Betrag;

  -- prepare vars for loop
  SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
  SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

  -------------------------------------------------------------------------------
  -- loop all entries
  -------------------------------------------------------------------------------
  WHILE (@EntriesIterator <= @EntriesCount)
  BEGIN
    -- get current entry
    SELECT
      @KbBuchungID_Forderung = BUC.KbBuchungID,
      @KbOpAusgleichID       = BUC.KbOpAusgleichID,
      @Betrag                = BUC.Betrag,
      @BetragAusgeglichen    = BUC.BetragAusgeglichen,
      @BetragAusbezahlt      = BUC.BetragAusbezahlt,
      @Buchungstext          = LEFT(@PraefixBuchungstext + ' ' + BUC.Buchungstext, 200)
    FROM @loop TMP
      INNER JOIN @KbBuchung_Forderung BUC ON BUC.KbBuchungID = TMP.KbBuchungID
                                          AND BUC.KbOpAusgleichID = TMP.KbOpAusgleichID
    WHERE TMP.ID = @EntriesIterator;

    -----------------------------------------------------------------------------
    -- Auszahlung für die Buchung erstellen
    -----------------------------------------------------------------------------
    PRINT('Auszahlung für die Buchung erstellen. @KbBuchungID_Forderung = ' + ISNULL(CONVERT(VARCHAR, @KbBuchungID_Forderung), 'NULL'));
    -- Insert into KbBuchung
    INSERT INTO dbo.KbBuchung(KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegNr, BelegDatum, ValutaDatum, Betrag, [Text], 
                              KbBuchungStatusCode, SollKtoNr, HabenKtoNr, BaZahlungswegID, KbAuszahlungsArtCode, PCKontoNr, BaBankID, 
                              BankKontoNr, IBAN, ReferenzNummer, BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, MitteilungZeile1, 
                              BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr, BeguenstigtPostfach, BeguenstigtOrt, 
                              BeguenstigtPLZ, BeguenstigtLandCode, Schuldner_BaPersonID, ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum)
    SELECT
      KbPeriodeID          = @KbPeriodeID,
      FaLeistungID         = BUC.FaLeistungID,
      IkPositionID         = BUC.IkPositionID,
      KbBuchungTypCode     = 3, -- Automatisch
      BelegNr              = NULL,
      BelegDatum           = NULL,
      ValutaDatum          = NULL,
      Betrag               = @BetragAusgeglichen,
      [Text]               = @Buchungstext,
      KbBuchungStatusCode  = 2, -- freigegeben
      SollKtoNr            = NULL,
      HabenKtoNr           = @KrediKtoNr,
      BaZahlungswegID      = GLB.BaZahlungswegID,
      KbAuszahlungsArtCode = 101, -- Elektronische Auszahlung
      PCKontoNr            = KRE.PostKontoNummer,
      BaBankID             = KRE.BaBankID,
      BankKontoNr          = KRE.BankKontoNummer,
      IBAN                 = KRE.IBANNummer,
      ReferenzNummer       = KRE.ReferenzNummer,
      BankName             = KRE.BankName,
      BankStrasse          = KRE.BankStrasse,
      BankPLZ              = KRE.BankPLZ,
      BankOrt              = KRE.BankOrt,
      BankBCN              = KRE.BankClearingNr,
      MitteilungZeile1     = LEFT(PRS.NameVorname, 35),
      BeguenstigtName      = LEFT(KRE.BeguenstigtName, 35),
      BeguenstigtName2     = LEFT(KRE.BeguenstigtName2, 35),
      BeguenstigtStrasse   = LEFT(KRE.BeguenstigtStrasse, 35),
      BeguenstigtHausNr    = NULL, --TODO?
      BeguenstigtPostfach  = NULL, --TODO?
      BeguenstigtOrt       = LEFT(KRE.BeguenstigtOrt, 25),
      BeguenstigtPLZ       = LEFT(KRe.BeguenstigtPLZ, 20),
      BeguenstigtLandCode  = NULL, --TODO?
      Schuldner_BaPersonID = ISNULL(LEIP.SchuldnerBaPersonID, LEIR.SchuldnerBaPersonID),
      ErstelltUserID       = @UserID,
      ErstelltDatum        = GETDATE(),
      MutiertUserID        = @UserID,
      MutiertDatum         = GETDATE()
    FROM dbo.KbBuchung                       BUC  WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungKostenart      BKO  WITH (READUNCOMMITTED)
                                                  ON BKO.KbBuchungID = BUC.KbBuchungID
      INNER JOIN dbo.IkPosition              IPO  WITH (READUNCOMMITTED)
                                                  ON IPO.IkPositionID = BUC.IkPositionID
                                                  AND IPO.Unterstuetzungsfall = 0
                                                  AND IPO.BetragIstNegativ = 0

      OUTER APPLY (SELECT IkForderungPeriodischCode
                    FROM dbo.fnIkForderung(IPO.IkPositionID, BKO.KbForderungArtCode)
                    WHERE Unterstuetzungsfall = 0) FRD

      INNER JOIN dbo.IkForderung_BgKostenart FKA  WITH (READUNCOMMITTED)
                                                  ON FKA.BgKostenartID_Forderung = BKO.BgKostenartID
                                                  AND ((IPO.Einmalig = 0 AND FKA.IkForderungPeriodischCode = FRD.IkForderungPeriodischCode)
                                                  OR (IPO.Einmalig = 1 AND FKA.IkForderungEinmaligCode = IPO.IkForderungCode AND FKA.IkForderungEinmaligCode != 2)) -- einmalige Kinderalimente (Bevorschussung) nicht berücksichtigen
      LEFT  JOIN dbo.IkRechtstitel           RTT  WITH (READUNCOMMITTED)
                                                  ON RTT.IkRechtstitelID = IPO.IkRechtstitelID
      LEFT  JOIN dbo.FaLeistung              LEIP WITH (READUNCOMMITTED) -- Leistung auf Position
                                                  ON LEIP.FaLeistungID = IPO.FaLeistungID
      INNER JOIN dbo.IkGlaeubiger            GLB  WITH (READUNCOMMITTED)
                                                  ON GLB.BaPersonID = IPO.BaPersonID
                                                  AND (GLB.IkRechtstitelID = RTT.IkRechtstitelID OR GLB.FaLeistungID = LEIP.FaLeistungID)
                                                  AND GLB.AuszahlungVermittlungStoppen = 0 -- keine Buchung erstellen wenn der Gläubiger die Auszahlung von Vermittlung gestopt hat
      LEFT  JOIN dbo.vwKreditor              KRE  WITH (READUNCOMMITTED)
                                                  ON KRE.BaZahlungswegID = GLB.BaZahlungswegID
      INNER JOIN dbo.vwPersonSimple          PRS  WITH (READUNCOMMITTED)
                                                  ON PRS.BaPersonID = GLB.BaPersonID
      LEFT JOIN dbo.FaLeistung               LEIR WITH (READUNCOMMITTED) -- Leistung auf Rechtstitel
                                                  ON LEIR.FaLeistungID = RTT.FaLeistungID
    WHERE BUC.KbBuchungID = @KbBuchungID_Forderung;

    IF (@@ROWCOUNT > 0)
    BEGIN
      SELECT @KbBuchungID_New = NULLIF(SCOPE_IDENTITY(), @KbBuchungID_New);
      PRINT('@@ROWCOUNT > 0, @KbBuchungID_New = ' + ISNULL(CONVERT(VARCHAR, @KbBuchungID_New), 'NULL'));

      -- Insert into KbBuchungKostenart
      INSERT INTO dbo.KbBuchungKostenart (KbBuchungID, KbKostenstelleID, BgKostenartID, BaPersonID, Buchungstext, Betrag, KontoNr, PositionImBeleg, 
                                          KbForderungArtCode, VerwPeriodeVon, VerwPeriodeBis, BgSplittingArtCode, Weiterverrechenbar, Quoting)
      SELECT
        KbBuchungID        = @KbBuchungID_New,
        KbKostenstelleID   = BKO.KbKostenstelleID,
        BgKostenartID      = FKA.BgKostenartID_Auszahlung,
        BaPersonID         = BKO.BaPersonID,
        Buchungstext       = @Buchungstext,
        Betrag             = @BetragAusgeglichen,
        KontoNr            = KOA.KontoNr,
        PositionImBeleg    = BKO.PositionImBeleg,
        KbForderungArtCode = NULL, -- TODO LOV IkKbForderungArt erweitern?
        VerwPeriodeVon     = BKO.VerwPeriodeVon,
        VerwPeriodeBis     = BKO.VerwPeriodeBis,
        BgSplittingArtCode = BKO.BgSplittingArtCode,
        Weiterverrechenbar = BKO.Weiterverrechenbar,
        Quoting            = BKO.Quoting
      FROM dbo.KbBuchungKostenart              BKO WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbBuchung               BUC WITH (READUNCOMMITTED)
                                                    ON BUC.KbBuchungID = BKO.KbBuchungID
        INNER JOIN dbo.IkPosition              IPO WITH (READUNCOMMITTED)
                                                    ON IPO.IkPositionID = BUC.IkPositionID

        OUTER APPLY (SELECT IkForderungPeriodischCode
                      FROM dbo.fnIkForderung(IPO.IkPositionID, BKO.KbForderungArtCode)
                      WHERE Unterstuetzungsfall = 0) FRD

        INNER JOIN dbo.IkForderung_BgKostenart FKA WITH (READUNCOMMITTED)
                                                    ON FKA.BgKostenartID_Forderung = BKO.BgKostenartID
                                                    AND ((IPO.Einmalig = 0 AND FKA.IkForderungPeriodischCode = FRD.IkForderungPeriodischCode)
                                                    OR (IPO.Einmalig = 1 AND FKA.IkForderungEinmaligCode = IPO.IkForderungCode))
        INNER JOIN dbo.BgKostenart             KOA WITH (READUNCOMMITTED)
                                                    ON KOA.BgKostenartID = FKA.BgKostenartID_Auszahlung
      WHERE BKO.KbBuchungID = @KbBuchungID_Forderung
      PRINT('Insert into KbBuchungKostenart. COUNT = ' + CONVERT(VARCHAR, @@ROWCOUNT));

      -- Insert into KbForderungAuszahlung
      INSERT INTO dbo.KbForderungAuszahlung(KbBuchungID_Forderung, KbBuchungID_Auszahlung, KbOpAusgleichID, Creator, Modifier)
      SELECT
        KbBuchungID_Forderung  = @KbBuchungID_Forderung,
        KbBuchungID_Auszahlung = @KbBuchungID_New,
        KbOpAusgleichID        = @KbOpAusgleichID,
        Creator                = @UserName,
        Modifier               = @UserName
      PRINT('Insert into KbForderungAuszahlung. COUNT = ' + CONVERT(VARCHAR, @@ROWCOUNT));
    END
    ELSE
    BEGIN
      PRINT('@@ROWCOUNT <= 0');
    END;
    -----------------------------------------------------------------------------

    -- prepare for next entry
    SET @EntriesIterator = @EntriesIterator + 1;
  END;  
END;
GO