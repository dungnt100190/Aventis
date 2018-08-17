SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spIkSollstellung_KbBuchung_Create;
GO
/*===============================================================================================
  $Revision: 25 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Belegimport aus Inkasso. 
           Buchungen (Forderungen und/oder Auszahlungen) anhand IkPosition erstellen.
    @IkPositionID:                         ID der IkPosition zu importieren
    @BuchungsDatum:                        Belegdatum
    @ValutaDatum:                          Valutadatum
    @ErfassungsdatumAlt:                   Erfassungsdatum
    @TextMaske:                            Buchungstext
    @UserID:                               ErstelltUserID
    @KbPeriodeID:                          ID der Geschäftsperiode
    @IsMigration:                          in Migrationsmodul (@IsMigration = 1) wird die Prüfung ob die Periode gesperrt ist nicht gemacht
    @GetResultOf_fnKbCKKbBuchungIntegrity: falls 1 wird den Integritätscheck vor dem Update ausgegeben.
  -
  RETURNS: Tabelle mit HasErrors und AnzahlErstellt
  -
  TEST:    EXEC dbo.spIkSollstellung_KbBuchung_Create 2007, 11, '20071107', '20071107', '20071107', '11.2007', 1692 
           
           EXEC dbo.spIkSollstellung_KbBuchung_Create 2008, 2, '20080219', '20080227', '20080226', 7142 
           Error: The INSERT statement conflicted with the FOREIGN KEY constraint "FK_KbBuchung_KbKonto_Soll". The conflict occurred in database "KiSS4_MASTER_ZH", table "dbo.KbKonto".
           
           -- validate
           SELECT * FROM KbBuchung WHERE UserID = 2654
           SELECT * FROM KbBuchung WHERE KbBuchungID IN (988, 989, 990)
           SELECT * FROM KbBuchungKostenart WHEREwhere KbBuchungID IN (988, 989, 990)
=================================================================================================*/

CREATE PROCEDURE dbo.spIkSollstellung_KbBuchung_Create
(
  @IkPositionID INT,
  @BuchungsDatum DATETIME,
  @ValutaDatum DATETIME,
  @ErfassungsdatumAlt DATETIME,
  @TextMaske VARCHAR(200),
  @UserID INT,
  @KbPeriodeID INT,
  @IsMigration BIT = 0,
  @GetResultOf_fnKbCKKbBuchungIntegrity BIT = 0
)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  -- ==========================
  -- Kontrolle der Parameter:
  -- ==========================
  IF @IkPositionID IS NULL OR @IkPositionID = 0 
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Fehler in Parameter: Der Parameter @IkPositionID ist ungültig.';
    RETURN;
  END;

  IF @BuchungsDatum IS NULL 
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Fehler in Parameter: Der Parameter @Buchungsdatum ist ungültig.';
    RETURN;
  END;

  IF @ValutaDatum IS NULL 
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Fehler in Parameter: Der Parameter @Valutadatum ist ungültig.';
    RETURN;
  END;

  IF @KbPeriodeID IS NULL
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Es konnte keine gültige Periode gefunden werden.';
    RETURN;
  END;
  
  -- =======================================================
  -- Deklaration der Variablen:
  -- =======================================================
  DECLARE
    @Anzahl INT,
    @tmpDate DATETIME,
    @tmpDateLast DATETIME,
    @tmpMon varchar(2),
    @Buchungstext1 varchar(200),
    @TextMaskeNeu VARCHAR(500),
    @EinzelBuchungstextDebi1 VARCHAR(500),
    @EinzelBuchungstextDebi2 VARCHAR(500),
    @EinzelBuchungstextDebi3 VARCHAR(500),
    @EinzelBuchungstextKredi VARCHAR(500),
    @BgKostenartIDDebi1 INT,
    @BgKostenartIDDebi2 INT,
    @BgKostenartIDDebi3 INT,
    @BgKostenartIDKredi INT,
    @IkForderungBgKostenartHistIDDebi1 INT,
    @IkForderungBgKostenartHistIDDebi2 INT,
    @IkForderungBgKostenartHistIDDebi3 INT,
    @IkForderungBgKostenartHistIDKredi1 INT,
    @Result INT,
    @ErrorText VARCHAR(5000),
    @BgKostenartID VARCHAR(10), 
    @IkForderungBgKostenartHistID INT,
    @KbBuchungNewID INT,
    @KbBuchungID_AuszahlungALBV INT,
    @IkRechtstitelID INT,
    @Unterstuetzungsfall BIT,
    @HasALBVBetrag BIT,
    @BaPersonID INT,
    @tmpBetragKredi money,
    @tmpBetragDebi1 money,
    @tmpBetragDebi2 money,
    @tmpBetragDebi3 money,
    @BetragAlim money,
    @BetragALBV money,
    @BetragKiZu money,
    @BetragVerr money,
    @BetragALBVminusVerr money,
    @BetragEinmalig money,
    @ForderungCode INT,  -- ehemals @EinmaligBetragTyp (kann aus lov IkForderungEinmalig sein (falls istEinmalig = 1) sonst lov IkForderungPeriodisch
    @IstEinmaligerBetrag BIT,
    @PeriodeDatum DATETIME,
    @PosImBeleg INT,
    @Glaeubiger_ZahlungswegID INT,
    @Glaeubiger_Aktiv BIT, -- BSS!
    @Glaeubiger_BaBankID INT,
    @Glaeubiger_BaPersonID INT,
    @Glaeubiger_PCKontoNr varchar(200),
    @Glaeubiger_BankKontoNr varchar(200),
    @Glaeubiger_BankName varchar(200),
    @Glaeubiger_BankStrasse varchar(200),
    @Glaeubiger_BankPLZ varchar(20),
    @Glaeubiger_BankOrt varchar(200),
    @Glaeubiger_IBAN varchar(50),
    @Glaeubiger_Referenznummer varchar(50),
    @Glaeubiger_Name varchar(200),
    @Glaeubiger_Name2 varchar(200),
    @Glaeubiger_Strasse varchar(200),
    @Glaeubiger_HausNr varchar(20),
    @Glaeubiger_PLZ varchar(200),
    @Glaeubiger_Ort varchar(200),
    @Glaeubiger_Postfach varchar(100),
    @Glaeubiger_LandCode INT,
    @Glaeubiger_Bank_BCN INT,
    @ForderungsTitelName varchar(200),
    @EinzelBuchungstext varchar(200),
    @Glaeubiger_ESTyp INT,
    @Schuldner_BaPersonID INT,
    @UserName varchar(200),
    @FallPersonName varchar(200),
    @PersonName varchar(200),
    @Glauebiger_Auszahlungsart char(1),
    @Glaeubiger_AuszahlungsArtCode INT,
    @Glaeubiger_PscdZahlwegArt varchar(1),
    @DebiKtoNr varchar(20),
    @KrediKtoNr varchar(20),
    @ErledigterMonat BIT,
    @ProzessCode INT,
    @FaLeistungID INT,
    @ALBVBerechtigt BIT,
    @EinmaligerBetragIstNegativ BIT,
    @MitteilungZeile1 VARCHAR(35),
    @Monat INT,
    @Jahr INT;
    

  -- =======================================================
  -- Periode, Debitoren-Konto und Kreditoren-Konto finden
  -- =======================================================
  -- Periode finden
  IF @IsMigration = 0 AND NOT EXISTS(SELECT TOP 1 1
                                     FROM dbo.KbPeriode WITH (READUNCOMMITTED) 
                                     WHERE KbPeriodeID = @KbPeriodeID
                                       AND PeriodeStatusCode = 1)
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Die Periode ist gesperrt.';
    RETURN;
  END;

  -- KREDI Kontierung finden
  SET @KrediKtoNr = NULL;
  
  SELECT TOP 1 @KrediKtoNr = KontoNr 
  FROM dbo.KbKonto WITH (READUNCOMMITTED) 
  WHERE KbPeriodeID = @KbPeriodeID
    AND '%,'+KbKontoArtCodes+',%' LIKE '%,30,%'; -- BSS! = 3 -- 3 = Kreditorenkonto, 2 = Debitorenkonto

  -- DEBI Kontierung finden
  SET @DebiKtoNr = NULL
  
  SELECT TOP 1 @DebiKtoNr = KontoNr 
  FROM dbo.KbKonto WITH (READUNCOMMITTED) 
  WHERE KbPeriodeID = @KbPeriodeID
    AND '%,'+KbKontoArtCodes +',%' LIKE '%,20,%'; --BSS! = 2 -- 3 = Kreditorenkonto, 2 = Debitorenkonto

  IF @KrediKtoNr IS NULL OR @DebiKtoNr IS NULL 
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Es konnten keine gültigen Kreditoren- und Debitorenkonti gefunden werden.';
    RETURN;
  END;

  -- =======================================================
  -- SQL zum Suchen einer Position
  -- =======================================================
  SET @ErrorText = '';
  SET @Anzahl = 0 ;


  -- Es wird eine Zeile IkPosition verarbeitet
  SELECT
    @IkRechtstitelID            = POS.IkRechtstitelID,
    @Unterstuetzungsfall        = POS.Unterstuetzungsfall,
    @BaPersonID                 = POS.BaPersonID,
    @BetragAlim                 = ISNULL(POS.TotalAliment, 0),
    @BetragALBV                 = ISNULL(POS.BetragALBV, 0),
    @BetragKiZu                 = ISNULL(POS.BetragKiZulage, 0),
    @BetragVerr                 = ISNULL(POS.BetragALBVverrechnung, 0),
    @BetragEinmalig             = ISNULL(POS.BetragEinmalig, 0),
    @ForderungCode              = POS.IkForderungCode,
    @PersonName                 = PRS.NameVorname,
    @Schuldner_BaPersonID       = LEI.SchuldnerBaPersonID,
    @ForderungsTitelName        = CASE 
                                    WHEN POS.Einmalig = 1 THEN XEM.Text
                                    ELSE XPD.Text
                                  END,
    @BgKostenartID              = CASE 
                                    WHEN POS.Einmalig = 1 THEN FKH.BgKostenartID
                                    ELSE NULL
                                  END,
    @IkForderungBgKostenartHistID = CASE 
                                    WHEN POS.Einmalig = 1 THEN FKH.IkForderungBgKostenartHistID
                                    ELSE NULL
                                  END,
    @IstEinmaligerBetrag        = POS.Einmalig,
    @ErledigterMonat            = POS.ErledigterMonat,
    @ProzessCode                = LEI.FaProzessCode,
    @PeriodeDatum               = POS.Datum,
    @FaLeistungID               = LEI.FaLeistungID,
    @ALBVBerechtigt             = POS.ALBVBerechtigt,
    @EinmaligerBetragIstNegativ = POS.BetragIstNegativ,
    @Monat                      = POS.Monat,
    @Jahr                       = POS.Jahr
  FROM dbo.IkPosition                         POS WITH (READUNCOMMITTED) 
    LEFT  JOIN dbo.IkRechtstitel              RTT WITH (READUNCOMMITTED) ON RTT.IkRechtstitelID = POS.IkRechtstitelID
    INNER JOIN dbo.FaLeistung                 LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = POS.FaLeistungID
                                                                         OR LEI.FaLeistungID = RTT.FaLeistungID 
    LEFT  JOIN dbo.vwPerson                   PRS                        ON PRS.BaPersonID = POS.BaPersonID
    LEFT  JOIN dbo.XLOVCode                   XPD WITH (READUNCOMMITTED) ON XPD.LOVName = 'IkForderungPeriodisch' 
                                                                        AND XPD.Code = POS.IkForderungCode
    LEFT  JOIN dbo.XLOVCode                   XEM WITH (READUNCOMMITTED) ON XEM.LOVName = 'IkForderungEinmalig' 
                                                                        AND XEM.Code = POS.IkForderungCode
    LEFT  JOIN dbo.IkForderungBgKostenartHist FKH WITH (READUNCOMMITTED) ON FKH.IkForderungEinmaligCode = POS.IkForderungCode
                                                                        AND @BuchungsDatum BETWEEN ISNULL(FKH.DatumVon, '17530101') AND ISNULL(FKH.DatumBis, '99991231')
  WHERE IkPositionID = @IkPositionID;

  IF @ErledigterMonat = 1 
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Dieser Monat ist bereits verbucht.';
    RETURN;
  END;


  -- =======================================================
  -- Alle Buchungen erstellen:
  -- =======================================================

  -- Buchungstext erstellen
  SET @TextMaskeNeu = '';
  IF (@TextMaske IS NOT NULL AND @TextMaske != '') SET @TextMaskeNeu = ' ' + @TextMaske;

  SET @tmpMon = CONVERT(VARCHAR, @Monat);
  IF LEN(@tmpMon) = 1 SET @tmpMon = '0' + @tmpMon;
  SET @Buchungstext1 = CONVERT(VARCHAR(4), @Jahr) + '.' + @tmpMon;

  SET @PosImBeleg = 1;  -- In Bern glaub nicht gebraucht
  SET @tmpBetragDebi1 = 0;
  SET @tmpBetragDebi2 = 0;
  SET @tmpBetragDebi3 = 0;
  SET @tmpBetragKredi = 0;

  SET @BgKostenartIDDebi1 = NULL;
  SET @BgKostenartIDDebi2 = NULL;
  SET @BgKostenartIDDebi3 = NULL;
  SET @BgKostenartIDKredi = NULL;

  SET @IkForderungBgKostenartHistIDDebi1 = NULL;
  SET @IkForderungBgKostenartHistIDDebi2 = NULL;
  SET @IkForderungBgKostenartHistIDDebi3 = NULL;
  SET @IkForderungBgKostenartHistIDKredi1 = NULL;

  IF @IstEinmaligerBetrag = 0 
  BEGIN
    -- Periodische Forderungen (nicht Einmalige Beträge, Monatszahlen)
    -- -------------------------------------
    IF @ProzessCode = 401 AND @ForderungCode = 1 -- Kinderalimente
    BEGIN
      -- DEBITOREN ALBV Kinder
      ------------------------
      -- 1. Kostenartbuchung
      SET @EinzelBuchungstextDebi1 = CASE
                                       WHEN @Unterstuetzungsfall = 1 THEN 'Kinderaliment (Unterstützungsfall) ' 
                                       WHEN @ALBVBerechtigt = 1 THEN 'Kinderalimente (Bevorschussung) '
                                       ELSE 'Kinderaliment (Vermittlungsfall) ' 
                                     END + @Buchungstext1 + @TextMaskeNeu;
      SELECT 
        @IkForderungBgKostenartHistIDDebi1 = IkForderungBgKostenartHistID,
        @BgKostenartIDDebi1 = BgKostenartID
      FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 1, @ALBVBerechtigt, 0, @Unterstuetzungsfall);
      SET @tmpBetragDebi1 = @BetragALBV;
      IF (@tmpBetragDebi1 < 0)
      BEGIN
        SET @tmpBetragDebi1 = 0;
      END;
      PRINT ('Info: 1. Kostenartbuchung @BgKostenartIDDebi1=' + ISNULL(CONVERT(VARCHAR, @BgKostenartIDDebi1), 'NULL') + 
             ', @tmpBetragDebi1=' + ISNULL(CONVERT(VARCHAR, @tmpBetragDebi1), 'NULL'));

      -- 2. Kostenartbuchung
      SET @EinzelBuchungstextDebi2 = CASE 
                                       WHEN @Unterstuetzungsfall = 1 THEN 'Kinderaliment (Unterstützungsfall) ' 
                                       WHEN @ALBVBerechtigt = 1 THEN 'Kinderalimente (über max. Bevorschussung) '
                                       ELSE 'Kinderalimente (Vermittlungsfall) '
                                     END + @Buchungstext1 + @TextMaskeNeu;
      
      SELECT 
        @IkForderungBgKostenartHistIDDebi2 = IkForderungBgKostenartHistID,
        @BgKostenartIDDebi2 = BgKostenartID
      FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 1, @ALBVBerechtigt, @ALBVBerechtigt, @Unterstuetzungsfall)
      SET @tmpBetragDebi2 = @BetragAlim - @tmpBetragDebi1;
      IF (@tmpBetragDebi2 < 0)
      BEGIN
        SET @tmpBetragDebi2 = 0;
      END;
      PRINT ('Info: 2. Kostenartbuchung @BgKostenartIDDebi2=' + ISNULL(CONVERT(VARCHAR, @BgKostenartIDDebi2), 'NULL') + 
             ', @tmpBetragDebi2=' + ISNULL(CONVERT(VARCHAR, @tmpBetragDebi2), 'NULL'));

      -- 3. Kostenartbuchung
      SET @EinzelBuchungstextDebi3 = CASE 
                                       WHEN @Unterstuetzungsfall = 1 THEN 'Kinderzulagen (Unterstützungsfall) '
                                       WHEN @ALBVBerechtigt = 1 THEN 'Kinderzulagen (Vermittlung bei Bevorschussungsfall) '
                                       ELSE 'Kinderzulagen (Vermittlungsfall) '
                                     END + @Buchungstext1 + @TextMaskeNeu;
      
      SELECT 
        @IkForderungBgKostenartHistIDDebi3 = IkForderungBgKostenartHistID,
        @BgKostenartIDDebi3 = BgKostenartID
      FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 3, @ALBVBerechtigt, 0, @Unterstuetzungsfall)
      SET @tmpBetragDebi3 = @BetragKiZu;
      IF (@tmpBetragDebi3 < 0)
      BEGIN
        SET @tmpBetragDebi3 = 0;
      END;
      PRINT ('Info: 3. Kostenartbuchung @BgKostenartIDDebi3=' + ISNULL(CONVERT(VARCHAR, @BgKostenartIDDebi3), 'NULL') + 
             ', @tmpBetragDebi3=' + ISNULL(CONVERT(VARCHAR, @tmpBetragDebi3), 'NULL'));

      -- KREDITOREN ALBV Kinder
      -------------------------
      SET @EinzelBuchungstextKredi = 'Zahlung ALBV ' + @Buchungstext1 + @TextMaskeNeu;
      SELECT @BgKostenartIDKredi = BgKostenartID_Auszahlung -- ALBV
      FROM dbo.IkForderung_BgKostenart IFK WITH (READUNCOMMITTED)
      WHERE BgKostenartID_Forderung = (SELECT TOP 1 BgKostenartID
                                       FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 1, 1, 0, 0)) -- ALBV-Forderung
        AND IkForderungPeriodischCode = 1;
      SET @tmpBetragKredi = @tmpBetragDebi1 + @BetragVerr; -- @BetragVerr ist negativ und wird abgezogen
      PRINT ('Info: Kreditoren ALBV @BgKostenartIDKredi=' + ISNULL(CONVERT(VARCHAR, @BgKostenartIDKredi), 'NULL') + 
             ', @tmpBetragKredi=' + ISNULL(CONVERT(VARCHAR, @tmpBetragKredi), 'NULL'));

    END -- END Kinderalimente
    ELSE IF @ProzessCode = 401 AND @ForderungCode = 2 -- Erwachsenenalimente
    BEGIN
      -- DEBITOREN ALBV Erwachsene
      ----------------------------
      -- 2. Kostenartbuchung
      SET @EinzelBuchungstextDebi1 = CASE 
                                       WHEN @Unterstuetzungsfall = 1 THEN 'Erwachsenenalimente (Unterstützungsfall) '
                                       ELSE 'Erwachsenenalimente '
                                     END + @Buchungstext1 + @TextMaskeNeu;
      SELECT 
        @IkForderungBgKostenartHistIDDebi1 = IkForderungBgKostenartHistID,
        @BgKostenartIDDebi1 = BgKostenartID
      FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 2, 0, 0, @Unterstuetzungsfall);
      SET @tmpBetragDebi1 = @BetragAlim;
      IF @tmpBetragDebi1 < 0 SET @tmpBetragDebi1 =  0;  -- kann nicht < 0 sein 
    END 
    ELSE IF @ProzessCode = 402 -- Elternbeitrag
    BEGIN
      -- DEBITOREN Elternbeitrag
      -- ----------------------------------------
      SET @EinzelBuchungstextDebi1 = 'Elternbeitrag ' + @Buchungstext1 + @TextMaskeNeu;
      SELECT 
        @IkForderungBgKostenartHistIDDebi1 = IkForderungBgKostenartHistID,
        @BgKostenartIDDebi1 = BgKostenartID
      FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 5, 0, 0, 0);
      SET @tmpBetragDebi1 = @BetragAlim;
    END
    ELSE IF @ProzessCode = 404 -- Verwandtenbeitrag / Erstbrief
    BEGIN
      -- DEBITOREN Verwandtenbeitrag
      -- ----------------------------------------
      SET @EinzelBuchungstextDebi1 = 'Verwandtenbeitrag ' + @Buchungstext1 + @TextMaskeNeu;
      SELECT 
        @IkForderungBgKostenartHistIDDebi1 = IkForderungBgKostenartHistID,
        @BgKostenartIDDebi1 = BgKostenartID
        FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 4, 0, 0, 0);
      SET @tmpBetragDebi1 = @BetragAlim;
    END;
    
    -- Periodische Rückerstattung gibt es nicht
    --ELSE IF @ProzessCode = 403 -- Rückerstattung
    --BEGIN
    --  -- DEBITOREN Rückerstattung
    --  -- ----------------------------------------
    --  SET @EinzelBuchungstextDebi1 = 'Rückerstattung ' + @Buchungstext1 + @TextMaskeNeu;
    --  SET @BgKostenartIDDebi1 = dbo.fnBgGetKostenartIDByKontoNr(700);
    --  SET @tmpBetragDebi1 = @BetragAlim;
    --END
    
    -- Tagesheim/Krippe gibt es nicht mehr
    --ELSE IF @ProzessCode = 405 -- Tagesheim/Krippe
    --BEGIN
    --  -- DEBITOREN Tagesheim/Krippe
    --  -- ----------------------------------------
    --  SET @EinzelBuchungstextDebi1 = 'Tagesheim/Krippe ' + @Buchungstext1 + @TextMaskeNeu;
    --  SET @BgKostenartIDDebi1 = dbo.fnBgGetKostenartIDByKontoNr(871); -- HACK: (gibts neu nicht mehr gleich wie Elternbeitrag)
    --  SET @tmpBetragDebi1 = @BetragAlim;
    --END
    
    -- Periodische Nachlass gibt es nicht
    --ELSE IF @ProzessCode = 406 -- Nachlass
    --BEGIN
    --  -- DEBITOREN Nachlass
    --  -- ----------------------------------------
    --  SET @EinzelBuchungstextDebi1 = 'Nachlass ' + @Buchungstext1 + @TextMaskeNeu;
    --  SET @BgKostenartIDDebi1 = dbo.fnBgGetKostenartIDByKontoNr(701);
    --  SET @tmpBetragDebi1 = @BetragAlim;
    --END
    
    -- Periodische Rückerstattung POM gibt es nicht
    --ELSE IF @ProzessCode = 407 -- Rückerstattung POM
    --BEGIN
    --  -- DEBITOREN Rückerstattung POM
    --  -- ----------------------------------------
    --  SET @EinzelBuchungstextDebi1 = 'Rückerstattung POM ' + @Buchungstext1 + @TextMaskeNeu;
    --  SET @BgKostenartIDDebi1 = dbo.fnBgGetKostenartIDByKontoNr(904);
    --  SET @tmpBetragDebi1 = @BetragAlim;
    --END;
  END -- END periodische Forderung
  ELSE 
  BEGIN
    -- Einmalige Beträge (Debitoren)
    -- -----------------------------
    SET @IkForderungBgKostenartHistIDDebi1 = @IkForderungBgKostenartHistID; -- aus IkForderungBgKostenartHist
    SET @BgKostenartIDDebi1 = CONVERT(INT, @BgKostenartID); -- aus IkForderungBgKostenartHist
    SET @PosImBeleg = 1;  -- ist immer 1
    SET @tmpBetragDebi1 = CASE WHEN @EinmaligerBetragIstNegativ = 1
                            THEN -@BetragEinmalig
                            ELSE @BetragEinmalig
                          END;
    SET @EinzelBuchungstextDebi1 = @ForderungsTitelName + ' ' + @Buchungstext1 + @TextMaskeNeu;

    -- Kinderalimente (Bevorschussung)
    IF @ProzessCode = 401 AND @ForderungCode = 2
    BEGIN
      -- KREDITOREN ALBV Kinder
      -------------------------
      SET @EinzelBuchungstextKredi = 'Zahlung ALBV ' + @Buchungstext1 + @TextMaskeNeu;
      SELECT @BgKostenartIDKredi = BgKostenartID_Auszahlung -- ALBV
      FROM dbo.IkForderung_BgKostenart IFK WITH (READUNCOMMITTED)
      WHERE BgKostenartID_Forderung = (SELECT TOP 1 BgKostenartID
                                       FROM dbo.fnIkGetIkForderungBgKostenart(@IstEinmaligerBetrag, @BuchungsDatum, 2, 1, 0, 0)) -- ALBV-Forderung
        AND IkForderungEinmaligCode = 2;
      SET @tmpBetragKredi = @tmpBetragDebi1;
    END;
  END; -- END einmalige Forderung

  SET @EinzelBuchungstextKredi = SUBSTRING(@EinzelBuchungstextKredi, 1, 200);
  SET @EinzelBuchungstextDebi1 = SUBSTRING(@EinzelBuchungstextDebi1, 1, 200);
  SET @EinzelBuchungstextDebi2 = SUBSTRING(@EinzelBuchungstextDebi2, 1, 200);
  SET @EinzelBuchungstextDebi3 = SUBSTRING(@EinzelBuchungstextDebi3, 1, 200);

  -- =================
  -- Kreditorenbuchung
  -- =================
  IF @tmpBetragKredi > 0 AND @Unterstuetzungsfall = 0 
  BEGIN
    -- Zahlungsweg suchen nur bei speziellen ALBV Buchungen
    -- ----------------------------------------------------
    -- ##4507: Mitteilungszeile soll Gläubiger NameVorname sein, nicht Schuldner!
    SELECT
      @Glaeubiger_ZahlungswegID = GLB.BaZahlungswegID,
      @Glaeubiger_Aktiv         = GLB.Aktiv,
      @MitteilungZeile1         = LEFT(PRS.NameVorname, 35)
    FROM dbo.IkGlaeubiger     GLB WITH (READUNCOMMITTED)
      INNER JOIN dbo.vwPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = GLB.BaPersonID
    WHERE GLB.IkRechtstitelID = @IkRechtstitelID
      AND GLB.BaPersonID = @BaPersonID;

    IF @Glaeubiger_Aktiv = 1
    BEGIN
      DECLARE @KreditorMehrZeilig VARCHAR(MAX),
              @ClearingNr         VARCHAR(15),
              @ClearingNrNeu      VARCHAR(15);
      
      -- Gläubiger Angaben holen
      -- -----------------------
      SELECT TOP 1
        @Glaeubiger_BaBankID       = KRE.BaBankID,
        @Glaeubiger_BaPersonID     = KRE.BaPersonID,
        @Glaeubiger_BankName       = KRE.Bankname,
        @Glaeubiger_BankStrasse    = KRE.BankStrasse,
        @Glaeubiger_BankPLZ        = KRE.BankPLZ,
        @Glaeubiger_BankOrt        = KRE.BankOrt,
        @Glaeubiger_PCKontoNr      = KRE.PostKontoNummer,
        @Glaeubiger_BankKontoNr    = KRE.BankKontoNummer,
        @Glaeubiger_IBAN           = KRE.IBANNummer,
        @Glaeubiger_Referenznummer = KRE.ReferenzNummer,
        @Glaeubiger_Name           = KRE.BeguenstigtName,
        @Glaeubiger_Name2          = KRE.BeguenstigtName2,
        @Glaeubiger_Strasse        = KRE.BeguenstigtStrasse,
        @Glaeubiger_HausNr         = NULL, --TODO?
        @Glaeubiger_PLZ            = KRE.BeguenstigtPLZ,
        @Glaeubiger_Ort            = KRE.BeguenstigtOrt,
        @Glaeubiger_Postfach       = NULL,--TODO?
        @Glaeubiger_LandCode       = NULL,--TODO?
        @Glaeubiger_Bank_BCN       = KRE.BankClearingNr,
        @Glauebiger_Auszahlungsart = NULL, --TODO löschen?
        @KreditorMehrZeilig        = KRE.KreditorMehrZeilig,
        @ClearingNr                = BNK.ClearingNr,
        @ClearingNrNeu             = BNK.ClearingNrNeu
      FROM dbo.vwKreditor KRE
        LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = KRE.BaBankID
      WHERE KRE.BaZahlungswegID = @Glaeubiger_ZahlungswegID;

      -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
      IF @ClearingNrNeu IS NOT NULL 
      BEGIN
        SELECT  HasErrors = 1,
                ErrorText = 'Der Zahlungsweg mit der ID ' + CONVERT(VARCHAR, @Glaeubiger_ZahlungswegID) + 
                            ' hat eine Bank (ClearingNr ' + @ClearingNr + ') mit einer neuen ClearingNr.'  + CHAR(13) + CHAR(10) +
                            'Kreditor:' + CHAR(13) + CHAR(10) +
                            @KreditorMehrZeilig;
        RETURN;
      END;


      DECLARE @naechsteBelegNr INT;
      EXECUTE @naechsteBelegNr = spKbGetBelegNr @KbPeriodeID, 3, null, 1; -- 1: select of spkbGetBelegNr interfers with qry["xyz"], so we don't want the select here!
                                          -- KbBelegkreis	3	Belegimport Inkasso

      DECLARE @KbBelegKreisID INT;
      SELECT @KbBelegKreisID = KbBelegKreisID
      FROM dbo.KbBelegKreis BLK WITH (READUNCOMMITTED)
      WHERE KbPeriodeID = @KbPeriodeID
        AND KbBelegKreisCode = 3; -- Belegimport Ikasso

      -- Buchung erstellen:
      -- --------------------
      INSERT INTO dbo.KbBuchung (
        KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode,
        BelegNr, KbBelegKreisID, 
        BelegDatum, ValutaDatum,
        Betrag, [Text], KbBuchungStatusCode,
        SollKtoNr, HabenKtoNr, 
        BaZahlungswegID, KbAuszahlungsArtCode,
        PCKontoNr, BaBankID, BankKontoNr, IBAN, ReferenzNummer,
        BankName, BankStrasse, BankPLZ, BankOrt, BankBCN,
        MitteilungZeile1,
        BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr,
        BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, BeguenstigtLandCode,
        Schuldner_BaPersonID,
        ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      ) VALUES (
        -- KbPeriodeID, 
        @KbPeriodeID,
        -- FaLeistungID
        @FaLeistungID,
        -- IkPositionID, 
        @IkPositionID,
        -- KbBuchungTypCode, 
        3,
        -- BelegNr
        @naechsteBelegNr,
        -- KbBelegKreisID
        @KbBelegKreisID,
        -- BelegDatum,
        @BuchungsDatum,
        -- ValutaDatum,
        @ValutaDatum,
        -- Betrag,
        @tmpBetragKredi,
        -- Text,
        @EinzelBuchungstextKredi,
        -- KbBuchungStatusCode,
        2,
        -- SollKtoNr
        NULL,
        -- HabenKontoNr
        @KrediKtoNr, -- @HabenKtoNr,
        -- BaZahlungswegID,
        @Glaeubiger_ZahlungswegID,
        -- KbAuszahlungsArtCode,
        -- hier ev. Auswahl bei Alimente LOV KbAuszahlungsart
        CASE WHEN @Unterstuetzungsfall = 0 THEN 101 ELSE 105 END,
        -- PCKontoNr,
        @Glaeubiger_PCKontoNr,
        -- BaBankID,
        @Glaeubiger_BaBankID,
        -- BankKontoNr,
        @Glaeubiger_BankKontoNr,
        -- IBAN
        @Glaeubiger_IBAN,
        -- Referenznr (Mantis 3786)
        @Glaeubiger_Referenznummer,
        -- Bank
        @Glaeubiger_BankName,
        @Glaeubiger_BankStrasse,
        @Glaeubiger_BankPLZ,
        @Glaeubiger_BankOrt,
        @Glaeubiger_Bank_BCN,
        -- MitteilungZeile1: NameVorname von Fallträger (Mantis 3138)
        @MitteilungZeile1,
        -- Name,
        LEFT(@Glaeubiger_Name, 35),
        -- Name2,
        LEFT(@Glaeubiger_Name2, 35),
        -- Strasse,
        LEFT(@Glaeubiger_Strasse, 35),
        -- Hausnummer,
        LEFT(@Glaeubiger_HausNr, 10),
        -- Postfach,
        LEFT(@Glaeubiger_Postfach, 40),
        -- Ort,
        LEFT(@Glaeubiger_Ort, 25),
        -- PLZ,
        LEFT(@Glaeubiger_PLZ, 20),
        -- LandCode,
        @Glaeubiger_LandCode,
        -- Schuldner_BaPersonID
        @Schuldner_BaPersonID,
        -- ErstelltUserID, ErstelltDatum,
        @UserID, @ErfassungsdatumAlt,
        -- MutiertUserID, MutiertDatum
        @UserID, @ErfassungsdatumAlt
      );

      SET @KbBuchungNewID = SCOPE_IDENTITY();
      SET @KbBuchungID_AuszahlungALBV = SCOPE_IDENTITY();

      -- KST-Buchung erstellen
      -- ---------------------
      SET @PosImBeleg = 10
      EXEC dbo.spIkSollstellung_KbBuchungKstArt_Create @KbBuchungNewID, 10, 
           @EinzelBuchungstextKredi, @BaPersonID, @tmpBetragKredi, 1,  
           @BgKostenartIDKredi, @PeriodeDatum;

      -- fnKbCKKbBuchungIntegrity vor dem Update ausführen damit ein Entwickler einfacher das Problem finden kann
      IF (@GetResultOf_fnKbCKKbBuchungIntegrity = 1)
      BEGIN
        SELECT KbBuchungID, KbBuchungStatusCode, Betrag, SollKtoNr, HabenKtoNr, * 
        FROM dbo.KbBuchung 
        WHERE KbBuchungID = @KbBuchungNewID
        
        SELECT *
        FROM dbo.KbBuchungKostenart
        WHERE KbBuchungID = @KbBuchungNewID;

        SELECT dbo.fnKbCKKbBuchungIntegrity(KbBuchungID, 13, Betrag, SollKtoNr, HabenKtoNr)
        FROM KbBuchung
        WHERE KbBuchungID = @KbBuchungNewID;
      END;

      -- Buchungsstatus auf verbucht setzen
      UPDATE dbo.KbBuchung
        SET KbBuchungStatusCode = 13
      WHERE KbBuchungID = @KbBuchungNewID;

      SET @Anzahl = @Anzahl + 1;
    END;
  END; -- END Kreditorenbuchung


  -- ================================================
  -- Normale Buchung erstellen (Debitorenbuchung)
  -- Es dürfen auch negative Totalbeträge gebucht werden
  -- Zahlungsweg Infos werden nicht verwendet
  -- ================================================
  IF (@tmpBetragDebi1 <> 0) 
  BEGIN
    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum, 
      Betrag, [Text], KbBuchungStatusCode, SollKtoNr, HabenKtoNr, Schuldner_BaPersonID, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum, IkForderungBgKostenartHistID
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID
      @FaLeistungID,
      -- IkPositionID, 
      @IkPositionID,
      -- KbBuchungTypCode, 
      3,  -- Automatisch
      -- BelegDatum,
      @BuchungsDatum,
      -- ValutaDatum,
      @ValutaDatum,
      -- Betrag,
      @tmpBetragDebi1,
      -- Text,
      @EinzelBuchungstextDebi1,
      -- KbBuchungStatusCode,
      2,
      -- SollKtoNr,
      CASE WHEN @tmpBetragDebi1 > 0 THEN @DebiKtoNr ELSE NULL END,
      -- HabenKtoNr,
      CASE WHEN @tmpBetragDebi1 > 0 THEN NULL ELSE @DebiKtoNr END,
      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      @UserID, @ErfassungsdatumAlt, @UserID, @ErfassungsdatumAlt,
      --  IkForderungBgKostenartHistID
      @IkForderungBgKostenartHistIDDebi1
    );
    SET @KbBuchungNewID = SCOPE_IDENTITY();

    -- Kostenart-Buchung
    EXEC dbo.spIkSollstellung_KbBuchungKstArt_Create @KbBuchungNewID, 1, 
         @EinzelBuchungstextDebi1, @BaPersonID, @tmpBetragDebi1, 1,  
         @BgKostenartIDDebi1, @PeriodeDatum;

    -- Buchungsstatus auf verbucht setzen
    UPDATE dbo.KbBuchung
      SET KbBuchungStatusCode = 13
    WHERE KbBuchungID = @KbBuchungNewID;

    -- Verbindung zwischen Forderung ALBV und Auszahlung ALBV erstellen
    IF (@ALBVBerechtigt = 1 AND @tmpBetragKredi <> 0)
    BEGIN
      DECLARE @Creator VARCHAR(100);
      SELECT @Creator = dbo.fnGetDBRowCreatorModifier(@UserID);

      INSERT INTO dbo.KbForderungAuszahlung(KbBuchungID_Auszahlung, KbBuchungID_Forderung, Creator, Modifier)
        VALUES(@KbBuchungID_AuszahlungALBV, @KbBuchungNewID, @Creator, @Creator);
    END;

    SET @Anzahl = @Anzahl + 1;
  END; -- END Buchung Debi1

  IF (@tmpBetragDebi2 <> 0) 
  BEGIN
    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum, 
      Betrag, [Text], KbBuchungStatusCode, SollKtoNr, HabenKtoNr, Schuldner_BaPersonID, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum, IkForderungBgKostenartHistID
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID
      @FaLeistungID,
      -- IkPositionID, 
      @IkPositionID,
      -- KbBuchungTypCode, 
      3,  -- Automatisch
      -- BelegDatum,
      @BuchungsDatum,
      -- ValutaDatum,
      @ValutaDatum,
      -- Betrag,
      CASE WHEN @tmpBetragDebi2 > 0 THEN @tmpBetragDebi2 ELSE -@tmpBetragDebi2 END,
      -- Text,
      @EinzelBuchungstextDebi2,
      -- KbBuchungStatusCode,
      2,
      -- SollKtoNr,
      CASE WHEN @tmpBetragDebi2 > 0 THEN @DebiKtoNr ELSE NULL END,
      -- HabenKtoNr,
      CASE WHEN @tmpBetragDebi2 > 0 THEN NULL ELSE @DebiKtoNr END,
      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      @UserID, @ErfassungsdatumAlt, @UserID, @ErfassungsdatumAlt,
      -- IkForderungBgKostenartHistID
      @IkForderungBgKostenartHistIDDebi2
    );
    SET @KbBuchungNewID = SCOPE_IDENTITY();

    -- Kostenart-Buchung
    EXEC dbo.spIkSollstellung_KbBuchungKstArt_Create @KbBuchungNewID, 2, 
         @EinzelBuchungstextDebi2, @BaPersonID, @tmpBetragDebi2, 1,  
         @BgKostenartIDDebi2, @PeriodeDatum;

    -- Buchungsstatus auf verbucht setzen
    UPDATE dbo.KbBuchung
      SET KbBuchungStatusCode = 13
    WHERE KbBuchungID = @KbBuchungNewID;

    SET @Anzahl = @Anzahl + 1;
  END; -- END Buchung Debi2

  IF (@tmpBetragDebi3 <> 0) 
  BEGIN
    -- Kinderzulagen
    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum, 
      Betrag, [Text], KbBuchungStatusCode, SollKtoNr, HabenKtoNr, Schuldner_BaPersonID, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum, IkForderungBgKostenartHistID
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID
      @FaLeistungID,
      -- IkPositionID, 
      @IkPositionID,
      -- KbBuchungTypCode, 
      3,  -- Automatisch
      -- BelegDatum,
      @BuchungsDatum,
      -- ValutaDatum,
      @ValutaDatum,
      -- Betrag,
      CASE WHEN @tmpBetragDebi3 > 0 THEN @tmpBetragDebi3 ELSE -@tmpBetragDebi3 END,
      -- Text,
      @EinzelBuchungstextDebi3,
      -- KbBuchungStatusCode,
      2,
      -- SollKtoNr,
      CASE WHEN @tmpBetragDebi3 > 0 THEN @DebiKtoNr ELSE NULL END,
      -- HabenKtoNr,
      CASE WHEN @tmpBetragDebi3 > 0 THEN NULL ELSE @DebiKtoNr END,
      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      @UserID, @ErfassungsdatumAlt, @UserID, @ErfassungsdatumAlt,
      -- IkForderungBgKostenartHistID
      @IkForderungBgKostenartHistIDDebi3
    );
    SET @KbBuchungNewID = SCOPE_IDENTITY();

    -- Kostenart-Buchung
    EXEC dbo.spIkSollstellung_KbBuchungKstArt_Create @KbBuchungNewID, 3, 
         @EinzelBuchungstextDebi3, @BaPersonID, @tmpBetragDebi3, 1,  
         @BgKostenartIDDebi3, @PeriodeDatum;
       
    -- Buchungsstatus auf verbucht setzen
    UPDATE dbo.KbBuchung
      SET KbBuchungStatusCode = 13
    WHERE KbBuchungID = @KbBuchungNewID;

    SET @Anzahl = @Anzahl + 1;
  END; -- END Buchung Debi3


  -- Monat sperren:
  UPDATE dbo.IkPosition 
    SET ErledigterMonat = 1
  WHERE IkPositionID = @IkPositionID;


  -- Monat sperren bei IkVerrechnungskonto:
  IF @IstEinmaligerBetrag = 0 
  BEGIN
    -- bei periodischen Beträgen (Monatszahlen), Monat sperren bei IkVerrechnungskonto:
    UPDATE VRK
      SET IstErledigt = 1
    FROM dbo.IkVerrechnungskonto VRK WITH (READUNCOMMITTED)
    WHERE VRK.BaPersonID = @BaPersonID
      AND VRK.IstErledigt = 0
      AND dbo.fnDateOf(@PeriodeDatum) BETWEEN dbo.fnFirstDayOf(VRK.DatumVon) AND dbo.fnLastDayOf(ISNULL(VRK.AnnulliertAm, VRK.DatumBis))
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.IkPosition IPO
                  WHERE IPO.IkRechtstitelID = VRK.IkRechtstitelID
                    AND IPO.BaPersonID = VRK.BaPersonID
                    AND IPO.Einmalig = 0
                    AND IPO.ErledigterMonat = 1
                    AND dbo.fnLastDayOf(dbo.fnDateSerial(IPO.Jahr, IPO.Monat, 1)) >= dbo.fnLastDayOf(ISNULL(VRK.AnnulliertAm, VRK.DatumBis)));
  END;

  IF NOT @ErrorText = '' AND @IsMigration = 0 
  BEGIN
    -- Fehler zurückgeben
    SELECT HasErrors = 1, ErrorText = @ErrorText;
    RETURN;
  END;

  -- Alles ok, Anzahl Buchung zurückgeben
  IF @IsMigration = 0
  BEGIN
    SELECT HasErrors = 0, AnzahlErstellt = @Anzahl;
  END;
END;
GO