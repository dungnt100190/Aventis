SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spReportWhAuszahlungsbeleg;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Listet alle ausbezahlten und noch auszuzahlenden Positionen eines Monatsbudgets auf.
    @BgBudgetID: Das darzustellende Monatsbudget
    @LanguageCode: Sprache für die Titelzellen. z.B. 1 für DE.
  -
  RETURNS: Eine Tabelle mit allen ausbezahlten und noch auszuzahlenden Positionen eines Monatsbudgets.
=================================================================================================
  TEST:    EXEC dbo.spReportWhAuszahlungsbeleg 2137, 2; --Budget mit KVG,VVG,KVG-GBL
=================================================================================================*/

CREATE PROCEDURE dbo.spReportWhAuszahlungsbeleg
(
  @BgBudgetID INT,
  @LanguageCode INT
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;

  --------------------------------------------
  --Haushalt/Unterstützungseinheit ermitteln
  --------------------------------------------
  DECLARE @UnterstuetztePersonen TABLE (
    BaPersonID INT
  );

  INSERT INTO @UnterstuetztePersonen (BaPersonID)
  SELECT BFB.BaPersonID
  FROM dbo.BgBudget                       BDG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    INNER JOIN dbo.BgFinanzplan_BaPerson  BFB WITH (READUNCOMMITTED) ON BFB.BgFinanzplanID = FPL.BgFinanzplanID
  WHERE BDG.BgBudgetID = @BgBudgetID
    AND BFB.IstUnterstuetzt = 1;

  DECLARE @UE INT, @HG INT, @BgFinanzplanID INT,
          @NameVornameKlient VARCHAR(MAX);    

  SELECT  @UE                = SUM(CONVERT(INT, BFB.IstUnterstuetzt)), 
          @HG                = SUM(1), 
          @BgFinanzplanID    = MIN(FPL.BgFinanzplanID),
          @NameVornameKlient = MIN(PRS.NameVorname)
  FROM dbo.BgBudget                       BDG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    INNER JOIN dbo.BgFinanzplan_BaPerson  BFB WITH (READUNCOMMITTED) ON BFB.BgFinanzplanID = FPL.BgFinanzplanID
    INNER JOIN dbo.FaLeistung             LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
    INNER JOIN dbo.vwPerson               PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
  WHERE BDG.BgBudgetID = @BgBudgetID;
  
  --------------------------------------------
  --ReportKategorieFooter
  --------------------------------------------
  DECLARE @ReportGruppeHeader1    VARCHAR(MAX),
          @ReportGruppeHeader2    VARCHAR(MAX),
          @ReportGruppeHeader3    VARCHAR(MAX),
          @ReportGruppeHeader4    VARCHAR(MAX),
          @ReportGruppeHeader5    VARCHAR(MAX),
          @ReportGruppeHeader6    VARCHAR(MAX),
          @ZahlungswegHeader      VARCHAR(MAX),
          @ReportGruppeFooter1    VARCHAR(MAX),
          @ReportGruppeFooter2    VARCHAR(MAX),
          @ReportGruppeFooter3    VARCHAR(MAX),
          @ReportGruppeFooter4    VARCHAR(MAX),
          @ReportGruppeFooter5    VARCHAR(MAX),
          @ReportGruppeFooter6    VARCHAR(MAX),
          @TextMieteEff           VARCHAR(MAX),
          @TextNebenkosten        VARCHAR(MAX),
          @TextEFB                VARCHAR(MAX),
          @TextIZU                VARCHAR(MAX),
          @TextSIL                VARCHAR(MAX),
          @TextUEHG               VARCHAR(MAX),
          @TextVon                VARCHAR(MAX),
          @TextUeberteuerteMiete  VARCHAR(MAX),
          @TextBarauszahlung      VARCHAR(MAX),
          @TextCheck              VARCHAR(MAX),
          @TextBetrag             VARCHAR(MAX);
          
          
  SELECT  @ReportGruppeHeader1    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeHeader1', @LanguageCode),
          @ReportGruppeHeader2    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeHeader2', @LanguageCode),
          @ReportGruppeHeader3    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeHeader3', @LanguageCode),
          @ReportGruppeHeader4    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeHeader4', @LanguageCode),
          @ReportGruppeHeader5    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeHeader5', @LanguageCode),
          @ReportGruppeHeader6    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeHeader6', @LanguageCode),
          @ZahlungswegHeader      =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ZahlungswegHeader',   @LanguageCode),
          @ReportGruppeFooter1    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeFooter1', @LanguageCode),
          @ReportGruppeFooter2    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeFooter2', @LanguageCode),
          @ReportGruppeFooter3    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeFooter3', @LanguageCode),
          @ReportGruppeFooter4    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeFooter4', @LanguageCode),
          @ReportGruppeFooter5    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeFooter5', @LanguageCode),
          @ReportGruppeFooter6    =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'ReportGruppeFooter6', @LanguageCode),
          
          @TextMieteEff           =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextMieteEff',          @LanguageCode),
          @TextNebenkosten        =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextNebenkosten',       @LanguageCode),
          @TextEFB                =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextEFB',               @LanguageCode),
          @TextIZU                =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextIZU',               @LanguageCode),
          @TextSIL                =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextSIL',               @LanguageCode),
          @TextUEHG               =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextUEHG',              @LanguageCode),
          @TextVon                =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextVon',               @LanguageCode),
          @TextUeberteuerteMiete  =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextUeberteuerteMiete', @LanguageCode),
          @TextBarauszahlung      =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextBarauszahlung',     @LanguageCode),
          @TextCheck              =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextCheck',             @LanguageCode),
          @TextBetrag             =  dbo.fnGetMLTextFromName('SH-Monatsbudget Auszahlbeleg', 'TextBetrag',            @LanguageCode);

  -- Temporäre Tabelle für die Positionen
  DECLARE @Positionen TABLE (
    BgPositionID        INT,
    BaPersonID          INT,
    BgPositionsartCode  INT,
    BgPositionsartID    INT,
    BgGruppeCode        INT,
    BgSpezkontoID       INT,
    BgKategorieCode     INT,
    Buchungstext        VARCHAR(MAX),
    VerwaltungSD        BIT,
    BetragPosition      MONEY,
    BetragBudget        MONEY,
    BetragFinanzplan    MONEY,
    BetragRechnung      MONEY,
    BetragReduktion     MONEY,
    BetragAbzug         MONEY,

    
    ReportGruppeCode    INT,
    ReportGruppeHeader  VARCHAR(MAX),
    ZahlungswegHeader   VARCHAR(MAX),
    ReportGruppeFooter  VARCHAR(MAX),
    Betrag              MONEY,  
    SortKey             INT,
    AnKlient            BIT,
    AnDritte            BIT,
    ZahlungswegDetails  VARCHAR(MAX)
  );

  ------------------------------------------
  --Positionen aus Monatsbudget übernehmen
  ------------------------------------------
  INSERT INTO @Positionen (BgPositionID, BaPersonID, BgPositionsartCode, BgPositionsartID, BgGruppeCode, BgSpezkontoID,
    BgKategorieCode, Buchungstext, VerwaltungSD, BetragPosition, BetragBudget, BetragFinanzplan,
    BetragRechnung, BetragReduktion, BetragAbzug)
  SELECT
    POS.BgPositionID, POS.BaPersonID, POA.BgPositionsartCode, POA.BgPositionsartID, POA.BgGruppeCode, POS.BgSpezkontoID,
    POS.BgKategorieCode, POS.Buchungstext, POS.VerwaltungSD, POS.Betrag, POS.BetragBudget, POS.BetragFinanzplan,
    POS.BetragRechnung, POS.Reduktion, POS.Abzug
  FROM dbo.vwBgPosition POS
    INNER JOIN dbo.BgBudget BDG ON BDG.BgBudgetID = POS.BgBudgetID
    LEFT JOIN dbo.BgSpezkonto SPK ON SPK.BgSpezkontoID = POS.BgSpezkontoID
    LEFT JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = IsNull(POS.BgPositionsartID, SPK.BgPositionsartID)
  WHERE BDG.BgBudgetID = @BgBudgetID
    AND BDG.BgBewilligungStatusCode = 5 --5:Bewilligung erteilt

  -----------------------------------
  --Positionen mit Daten anreichern
  -----------------------------------
  
  -- AnDritte/AnKlient/Zahlungsdetails
  ------------------------------------
  UPDATE POS
    SET POS.AnDritte          = CASE
                                  WHEN KRE.BaZahlungswegID IS NULL  THEN 0
                                  WHEN EXISTS (SELECT TOP 1 1
                                               FROM @UnterstuetztePersonen
                                               WHERE BaPersonID = KRE.BaPersonID)  THEN 0
                                  ELSE 1
                                END,

      POS.AnKlient            = CASE
                                  WHEN EXISTS (SELECT TOP 1 1
                                               FROM @UnterstuetztePersonen
                                               WHERE BaPersonID = KRE.BaPersonID)  THEN 1
                                  WHEN EXISTS (SELECT TOP 1 1
                                               FROM BgAuszahlungPerson
                                               WHERE BgPositionID = POS.BgPositionID
                                                 AND KbAuszahlungsartCode IN (103, 104)) THEN 1  --103: Cash/Barauszahlung oder 104: Check = AnKlient
                                  WHEN KRE.BaZahlungswegID IS NULL  THEN 0
                                  ELSE 0
                                END
  FROM @Positionen POS
    LEFT  JOIN dbo.BgAuszahlungPerson BAP  ON BAP.BgPositionID = POS.BgPositionID 
                                          AND BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                           FROM   BgAuszahlungPerson
                                                                           WHERE  BgPositionID = POS.BgPositionID
                                                                           ORDER BY 
                                                                             CASE WHEN BaPersonID IS NULL THEN 1
                                                                                  WHEN BaPersonID = POS.BaPersonID THEN 2
                                                                                  ELSE 3
                                                                             END)
    LEFT  JOIN dbo.vwKreditor         KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID;

  -- Buchungstext
  ---------------
  UPDATE POS
    SET Buchungstext = CASE WHEN POS.BgGruppeCode = 3201 /*Grundbedarf*/ THEN ISNULL(POS.Buchungstext, POA.Name) + @TextUEHG + CONVERT(VARCHAR, @UE) + @TextVon + CONVERT(VARCHAR, @HG)
                            WHEN POA.BgGruppeCode = 3206 /*Wohnkosten*/ AND POA.BgPositionsartCode <> 32060 THEN @TextMieteEff 
                            WHEN POA.BgGruppeCode = 3206 /*Wohnkosten*/ AND POA.BgPositionsartCode = 32060 THEN @TextNebenkosten 
                            WHEN POA.BgGruppeCode BETWEEN 39100 AND 39130 /*EFB*/ THEN @TextEFB + POS.Buchungstext 
                            WHEN POA.BgGruppeCode = 39200 /*IZU %*/ THEN @TextIZU + POS.Buchungstext 
                            WHEN POA.BgGruppeCode BETWEEN 3901 AND 3905 /*SIL*/ THEN @TextSIL + POS.Buchungstext 
                            WHEN POS.Buchungstext IS NULL THEN COALESCE(POS.Buchungstext, POA.Name, SPK.NameSpezkonto) 
                            ELSE POS.Buchungstext 
                        END + IsNull(' (' + PRS.NameVorname + ')', '')
  FROM @Positionen POS
    LEFT JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
    LEFT JOIN BgSpezkonto    SPK ON SPK.BgSpezkontoID = POS.BgSpezkontoID
    LEFT JOIN vwPerson       PRS ON PRS.BaPersonID = POS.BaPersonID;
      
  -- Beträge ermitteln
  
  -- Betrag (KVG-Beitrag)
  -----------------------
  UPDATE POS
    SET Betrag = BetragPosition + IsNull(KVG_GBL.Betrag, 0.00)
  FROM @Positionen POS
      LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode IN (32023, 32024)) KVG_GBL ON KVG_GBL.BgBudgetID =  @BgBudgetID AND KVG_GBL.BgPositionID_Parent = POS.BgPositionID
  WHERE POS.BgPositionsartCode BETWEEN 32121 AND 32129; --KVG (Regionen 1-3, Erwachsene + Jugendliche)

  -- Übrige Beträge
  -----------------
  UPDATE POS
    SET Betrag =  CASE WHEN BgGruppeCode = 3201 /*Grundbedarf*/ THEN BetragFinanzplan
                       WHEN BgGruppeCode = 3206 /*Wohnkosten*/  THEN BetragRechnung
                       WHEN BgPositionsartCode BETWEEN 39100 AND 39300 /* Zulagen */ THEN BetragPosition
                       WHEN BgGruppeCode BETWEEN 3901 AND 3905 /* SIL */ THEN BetragPosition
                       WHEN BgPositionsartCode IN (32021, 32022, 32023) /* VVG, VVG-SIL, KVG-GBL */ THEN BetragPosition
                       WHEN BgKategorieCode = 1 /*1: Einnahme */ AND POS.VerwaltungSD = 0 THEN BetragPosition
                       WHEN BgKategorieCode IN (3, 4, 6) /*3:Abzahlung, 4: Kürzung, 6: Vorabzug */ THEN BetragBudget
                       WHEN BgPositionsartCode = 32030 THEN BetragFinanzplan
                       WHEN BgKategorieCode IN (100, 101) THEN BetragPosition
                       ELSE Betrag --do nothing
                  END 
  FROM @Positionen POS;
  
  -- ReportGruppe und -Kategorie zuweisen
  --------------------------
  UPDATE POS
    SET ReportGruppeCode    = CASE WHEN POS.Betrag = 0 THEN NULL
                                   WHEN POS.BgKategorieCode = 2 /*2: Ausgabe */ AND POS.AnKlient = 1                                      THEN 1 /* Ausgaben gemäss Finanzplan an Klienten*/
                                   WHEN POS.BgKategorieCode IN (100, 101) /*100:Zus.Leistung, 101: Einzelzahlung */ AND POS.AnKlient = 1  THEN 2 /* Weitere Zahlungen an Klientin */
                                   WHEN POS.BgKategorieCode = 2 AND POS.BgPositionsartCode IN (32023, 32021) /* KVG-GBL/VVG-SIL */        THEN 3 /* Verrechnungen/Abzüge */
                                   WHEN POS.BgKategorieCode = 1 /*1: Einnahme */ AND POS.VerwaltungSD = 0                                 THEN 3 /* Verrechnungen/Abzüge */
                                   WHEN POS.BgKategorieCode IN (3, 4, 6) /*3:Abzahlung, 4: Kürzung, 6: Vorabzug */                        THEN 3 /* Verrechnungen/Abzüge */
                                   ELSE ReportGruppeCode --do nothing
                              END
  FROM @Positionen POS

  -- Positionen erstellen (Überteuerte Miete, bereits erfolgte Zahlungen an Klienten...)

  -- Überteuerte Miete
  ----------------------------------------------------
  DECLARE @ReduktionAufMiete MONEY;
  SELECT @ReduktionAufMiete = POS.BetragRechnung-POS.BetragBudget
  FROM @Positionen POS
  WHERE POS.BgGruppeCode = 3206 /*Wohnkosten*/ AND POS.BgPositionsartCode <> 32060

  IF(@ReduktionAufMiete > 0)
  BEGIN
    INSERT INTO @Positionen(ReportGruppeCode, ReportGruppeHeader, ReportGruppeFooter, Buchungstext, Betrag)
    VALUES (3, @ReportGruppeHeader3, @ReportGruppeFooter3, @TextUeberteuerteMiete, @ReduktionAufMiete);
  END

  -- Bereits erfolgte Zahlungen an Klienten
  -----------------------------------------
  INSERT INTO @Positionen(ReportGruppeCode, ReportGruppeHeader, ReportGruppeFooter, Buchungstext, Betrag, AnKlient, ZahlungswegDetails)
  SELECT  ReportGruppeCode = 4,
          ReportGruppeHeader = @ReportGruppeHeader4,
          ReportGruppeFooter = @ReportGruppeFooter4,
          Buchungstext = MIN(POS.Buchungstext),
          Betrag = SUM(BKO.Betrag),
          AnKlient = 1,
          ZahlungswegDetails = MIN(BUC.BeguenstigtName + ', ' + CASE WHEN BUC.KbAuszahlungsartCode = 103 THEN @TextBarauszahlung
                                                                     WHEN BUC.KbAuszahlungsartCode = 104 THEN @TextCheck
                                                                     ELSE COALESCE(KRE.IBANNummer, KRE.BankKontoNummer, KRE.PostKontoNummer)
                                                                END
                                                                + CHAR(13) + CHAR(10) + CONVERT(VARCHAR, BUC.ValutaDatum, 104))
  FROM KbBuchungKostenart BKO
    INNER JOIN @Positionen POS ON POS.BgPositionID = BKO.BgPositionID
    INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = BKO.KbBuchungID
    LEFT  JOIN vwKreditor KRE ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
  WHERE POS.AnKlient = 1
    AND BUC.KbBuchungStatusCode IN (4, 6) --4: Barbeleg ausgedruckt, 6: ausgeglichen
  GROUP BY POS.BgPositionID, BUC.KbBuchungID
  
  -- Zahlungen an Dritte
  ----------------------
  INSERT INTO @Positionen(ReportGruppeCode, ReportGruppeHeader, ReportGruppeFooter, Buchungstext, Betrag, AnKlient, ZahlungswegDetails)
  SELECT  ReportGruppeCode = 6,
          ReportGruppeHeader = @ReportGruppeHeader6,
          ReportGruppeFooter = @ReportGruppeFooter6,
          Buchungstext = MIN(KRE.Kreditor),
          Betrag = SUM(BKO.Betrag),
          AnDritte = 1,
          ZahlungswegDetails = MIN(COALESCE(KRE.IBANNummer, KRE.BankKontoNummer, KRE.PostKontoNummer)) + CHAR(13) + CHAR(10) + CONVERT(VARCHAR, MIN(BUC.ValutaDatum), 104)
  FROM KbBuchungKostenart BKO
    INNER JOIN @Positionen POS ON POS.BgPositionID = BKO.BgPositionID
    INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = BKO.KbBuchungID
    INNER JOIN vwKreditor KRE ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
  WHERE BUC.KbBuchungStatusCode IN (2, 4, 6) --2: Freigegeben, 4: Barbeleg ausgedruckt, 6: ausgeglichen
    AND POS.AnDritte = 1
    AND BUC.HabenKtoNr IS NOT NULL  --Forderungen ausschliessen
  GROUP BY BUC.KbBuchungID
  
  -- Auszahlungsbetrag an Klienten
  --------------------------------
  INSERT INTO @Positionen(ReportGruppeCode, ReportGruppeHeader, ReportGruppeFooter, Buchungstext, Betrag, AnKlient, ZahlungswegDetails)
  SELECT  ReportGruppeCode = 5,
          ReportGruppeHeader = @ReportGruppeHeader5,
          ReportGruppeFooter = @ReportGruppeFooter5,
          Buchungstext = CASE WHEN BUC.KbAuszahlungsartCode IN (103, 104) THEN BUC.BeguenstigtName 
                              ELSE KRE.Kreditor
                         END,
          Betrag = BUC.Betrag,
          AnKlient = 1,
          ZahlungswegDetails = CASE WHEN BUC.KbAuszahlungsartCode = 103 THEN @TextBarauszahlung 
                                    WHEN BUC.KbAuszahlungsartCode = 104 THEN @TextCheck 
                                    ELSE COALESCE(KRE.IBANNummer, KRE.BankKontoNummer, KRE.PostKontoNummer) 
                               END + CHAR(13) + CHAR(10) + CONVERT(VARCHAR, BUC.ValutaDatum, 104)
  FROM KbBuchung BUC
    LEFT JOIN vwKreditor KRE ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
    LEFT JOIN @UnterstuetztePersonen PRS ON PRS.BaPersonID = KRE.BaPersonID
  WHERE BUC.KbBuchungStatusCode = 2 --2: Freigegeben
    AND BUC.BgBudgetID = @BgBudgetID
    AND (PRS.BaPersonID IS NOT NULL --Belege an KlientIn
          OR BUC.KbAuszahlungsartCode IN (103, 104))  --Barauszahlungen + Check haben keinen Kreditor/Zahlungsweg, gelten aber als 'an KlientIn'
  ORDER BY BUC.ValutaDatum, KRE.Kreditor;

  UPDATE POS
  SET
        ReportGruppeHeader    = CASE POS.ReportGruppeCode WHEN 1 THEN @ReportGruppeHeader1
                                                          WHEN 2 THEN @ReportGruppeHeader2
                                                          WHEN 3 THEN @ReportGruppeHeader3
                                                          WHEN 4 THEN @ReportGruppeHeader4
                                                          WHEN 5 THEN @ReportGruppeHeader5
                                                          WHEN 6 THEN @ReportGruppeHeader6
                                                          ELSE NULL
                                END,
        ReportGruppeFooter    = CASE POS.ReportGruppeCode WHEN 1 THEN @ReportGruppeFooter1
                                                          WHEN 2 THEN @ReportGruppeFooter2
                                                          WHEN 3 THEN @ReportGruppeFooter3
                                                          WHEN 4 THEN @ReportGruppeFooter4
                                                          WHEN 5 THEN @ReportGruppeFooter5
                                                          WHEN 6 THEN @ReportGruppeFooter6
                                                          ELSE NULL
                                END,
        ZahlungswegHeader     = CASE WHEN EXISTS (SELECT TOP 1 1 FROM @Positionen WHERE ReportGruppeCode = POS.ReportGruppeCode AND ZahlungswegDetails IS NOT NULL) THEN @ZahlungswegHeader
                                     ELSE NULL
                                END
  FROM @Positionen POS;

  --Sicherstellen, dass auch wenn kein zur Auszahlung offener Betrag existiert, zumindest 0.00 steht
  IF(NOT EXISTS(SELECT TOP 1 1 FROM @Positionen WHERE ReportGruppeCode = 5))
  BEGIN
      INSERT INTO @Positionen(ReportGruppeCode, ReportGruppeHeader, ReportGruppeFooter, Buchungstext, Betrag, AnKlient, ZahlungswegDetails)
      VALUES (5, NULL, @ReportGruppeFooter5, '', 0, 1, '');
  END;

  -- Output
  ---------
  SELECT 
    ReportGruppeCode, 
    ReportGruppeHeader, 
    ZahlungswegHeader, 
    ReportGruppeFooter, 
    Buchungstext, 
    Betrag, 
    ZahlungswegDetails,
    TextBetrag = @TextBetrag
  FROM @Positionen
  WHERE ReportGruppeCode IS NOT NULL
  ORDER BY ReportGruppeCode
  
END;
