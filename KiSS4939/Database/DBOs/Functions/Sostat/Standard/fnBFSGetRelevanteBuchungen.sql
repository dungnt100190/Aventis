SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSGetRelevanteBuchungen;
GO
/*===============================================================================================
  $Revision: 18 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt eine Tabelle mit allen für BFS relevanten Buchungen zurück
    @Erhebungsjahr: Erhebungsjahr
    @UserID: Suche nach bestimmten Mitarbeiter
    @BaPersonID: Suche nach bestimmter Person/Klient
    @LeistungsartCodes: Suche nach Leistungsarten
    @OrgUnitID: Suche nach ganzen Abteilungen

  RETURNS: relevanten Buchungen
=================================================================================================
  TEST: 
  SELECT * FROM dbo.fnBFSGetRelevanteBuchungen(2010, NULL, NULL, ',1,2,23,25,', NULL, 1) FCN;
=================================================================================================
  LOG:
  24.01.2011 : Korrektur für Kunden ohne Klientenbuchhaltung
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSGetRelevanteBuchungen
(
  @Erhebungsjahr INT = NULL,
  @UserID INT = NULL,
  @BaPersonID INT = NULL,
  @LeistungsartCodes VARCHAR(200) = NULL,  -- kommagetrennte Liste von Leistungsart-Codes
  @OrgUnitID INT = NULL,
  @InklBuchungenVorErhebungsjahr BIT = 1
)
RETURNS @OutputResult TABLE 
(
  FaProzessCode INT, 
  BaPersonID INT,       -- Antraggsteller
  Ausgleichsdatum DATETIME,
  FaLeistungID INT,     -- nicht eindeutig, daher max(FaLeistungID)
  BaPersonID_Glaeubiger INT,
  UNIQUE (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID, BaPersonID_Glaeubiger)
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- init
  -----------------------------------------------------------------------------
  SET @LeistungsartCodes = ',' + ISNULL(@LeistungsartCodes, '1,2,23,25,35,36,37,40,50') + ',';
  SET @InklBuchungenVorErhebungsjahr = ISNULL(@InklBuchungenVorErhebungsjahr, 1);
  
  IF (@Erhebungsjahr IS NULL)
  BEGIN
    SET @Erhebungsjahr = CONVERT(INT, dbo.fnXConfig('System\Sostat\Erhebungsjahr', GETDATE()));
  END;
  
  DECLARE @MonateBisAlsNachzahlungInterpretiert  INT;
  DECLARE @Date0107OfJahrMinus1 DATETIME;
  DECLARE @Date3112OfJahrMinus1 DATETIME;
  DECLARE @Date3112OfJahr       DATETIME;
  
  SET @MonateBisAlsNachzahlungInterpretiert = 4; -- für Test, später in XConfig auslagern
  SET @Date0107OfJahrMinus1 = CONVERT(DATETIME, '01.07.' + STR(@Erhebungsjahr - 1), 104);
  SET @Date3112OfJahr       = CONVERT(DATETIME, '31.12.' + STR(@Erhebungsjahr), 104);
  SET @Date3112OfJahrMinus1 = DATEADD(YEAR, -1, @Date3112OfJahr);
  
  DECLARE @KontoNrALBV VARCHAR(20);
  SET @KontoNrALBV = CONVERT(VARCHAR(20), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ALBVKontiBevorschussung', GETDATE())); --Anfangsdatum

  DECLARE @TmpData TABLE
  (
    FaProzessCode   INT, 
    BaPersonID      INT NOT NULL,
    Ausgleichsdatum DATETIME,
    FaLeistungID    INT NOT NULL,
    BaPersonID_Glaeubiger INT
  );
  
  -----------------------------------------------------------------------------
  -- Hole alle relevanten Buchungen für BFS
  -----------------------------------------------------------------------------
  -----------------------------------------------------------------------------
  -- WSH / Asyl
  -----------------------------------------------------------------------------
  IF (@LeistungsartCodes LIKE '%,1,%' OR 
      @LeistungsartCodes LIKE '%,2,%' OR
      @LeistungsartCodes LIKE '%,35,%' OR
      @LeistungsartCodes LIKE '%,36,%' OR
      @LeistungsartCodes LIKE '%,37,%' OR
      @LeistungsartCodes LIKE '%,40,%' OR
      @LeistungsartCodes LIKE '%,50,%') 
  BEGIN
    ---------------------------------------------------------------------------
    -- WSH / Asyl
    -- Pro Dossier und pro Tag mit Auszahlungen einen Eintrag in @OutputResult speichern. 
    ---------------------------------------------------------------------------
    INSERT INTO @TmpData (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID, BaPersonID_Glaeubiger)
      SELECT FaProzessCode   = CASE LEI.ModulID WHEN 6 THEN 600 ELSE LEI.FaProzessCode END,
             BaPersonID      = LEI.BaPersonID,
             Ausgleichsdatum = COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum),
             FaLeistungID    = MAX(LEI.FaLeistungID),
             BaPersonID_Glaeubiger = MIN(-1)
      FROM dbo.FaLeistung                 LEI  WITH (READUNCOMMITTED)
        INNER JOIN dbo.BgFinanzplan       FPL  WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID 
        INNER JOIN dbo.BgBudget           BDG  WITH (READUNCOMMITTED) ON BDG.BgFinanzplanID = FPL.BgFinanzplanID 
           -- nur Monatsbudgets
           AND BDG.MasterBudget = 0 
        INNER JOIN dbo.BgPosition         POS  WITH (READUNCOMMITTED) ON POS.BgBudgetID = BDG.BgBudgetID 
            -- 2: Ausgaben, 100: Zusätzliche Leistungen, 101: Einzelzahlung
            AND POS.BgKategorieCode IN (2, 100, 101) 
      
        -- Neue Anforderung vom BFS:
        -- Werden einem Klienten nur die Krankenkassenprämien bezahlt gilt dies gemäss BFS nicht als Sozialhilfe 
        -- und soll bei der Ablieferung der SOSTAT-Daten nicht berücksichtigt werden
        -- (siehe auch NewsletterD.pdf im Ticket 6208).
        LEFT  JOIN BgPositionsart        GBL  WITH (READUNCOMMITTED) ON GBL.BgPositionsartID = FPL.WhGrundbedarfTypCode
        LEFT JOIN dbo.BgSpezkonto        SPZ  WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = POS.BgSpezkontoID
        INNER JOIN dbo.BgPositionsart    POA  WITH (READUNCOMMITTED) ON POA.BgPositionsartID = COALESCE(POS.BgPositionsartID, SPZ.BgPositionsartID,GBL.BgPositionsartID)
                                                                    AND POA.ErzeugtBfsDossier = 1


        LEFT JOIN dbo.KbBuchungKostenart BUK  WITH (READUNCOMMITTED) ON BUK.BgPositionID = POS.BgPositionID 
        LEFT JOIN dbo.KbBuchung          BUC  WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
        LEFT JOIN dbo.KbTransfer         TSF  WITH (READUNCOMMITTED) ON TSF.KbBuchungID = BUC.KbBuchungID AND TSF.KbTransferStatusCode = 2 -- Übermittelt
        LEFT JOIN dbo.KbZahlungslauf     ZLL  WITH (READUNCOMMITTED) ON ZLL.KbZahlungslaufID = TSF.KbZahlungslaufID
        LEFT JOIN dbo.KbOpAusgleich      AUS  WITH (READUNCOMMITTED) ON AUS.OpBuchungID = BUC.KbBuchungID
            AND AUS.KbOpAusgleichID = (
                SELECT MAX(OP.KbOpAusgleichID)
                FROM dbo.KbOpAusgleich OP WITH (READUNCOMMITTED)
                WHERE OP.OpBuchungID = BUC.KbBuchungID
            )
        LEFT  JOIN dbo.KbBuchung          BUC2 WITH (READUNCOMMITTED) ON BUC2.KbBuchungID = AUS.AusgleichBuchungID

        LEFT  JOIN dbo.vwUser             USR  WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
      WHERE LEI.FaProzessCode IN (300, 600) -- 300: Wirtschaftliche Hilfe, 600: Asyl
        AND LEI.UserID = ISNULL(@UserID, LEI.UserID) 
        AND (USR.OrgUnitID = @OrgUnitID OR @OrgUnitID IS NULL)
        AND LEI.BaPersonID = ISNULL(@BaPersonID, LEI.BaPersonID)
        AND (
              -- nicht abgetretene Einnahmen (wenn nicht in Veraltung Sozialdienst), Kürzungen
              ((POS.BgKategorieCode = 1 AND POS.VerwaltungSD = 0 OR POS.BgKategorieCode = 4)
                AND (dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) BETWEEN @Date0107OfJahrMinus1 AND @Date3112OfJahr
                     OR (@InklBuchungenVorErhebungsjahr = 1 AND (dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) <= @Date3112OfJahrMinus1))))
              OR
              -- ZahlauftragErstellt, ausgeglichen, teilweise ausgeglichen, verbucht
              -- grüne und ausgedruckte Barbelege
              -- bei Kunden ohne Klibu werden alle verbuchten Buchungen berücksichtigt
              (BUC.KbBuchungStatusCode IN (3,6,10,13) OR BUC.KbBuchungStatusCode = 2 AND BUC.KbAuszahlungsArtCode = 103)
               AND (dbo.fnDateOf(COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum)) BETWEEN @Date0107OfJahrMinus1 AND @Date3112OfJahr
                    OR (@InklBuchungenVorErhebungsjahr = 1
                        AND COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum) IS NOT NULL
                        AND dbo.fnDateOf(COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum)) <= @Date3112OfJahrMinus1))
            )
        -- Versuch zum Herausfiltern von Nachzahlungen:
        -- Falls eine Buchung [n] Monate nach dem Budgetmonat ausbezahlt wird
        -- und der Budgetmonat im Vorjahr liegt, wird sie als Nachzahlung interpretiert und somit herausgefiltert
        -- Bsp: Budgetposition aus September 2011 wird erst im Januar 2012 ausbezahlt - für 2012 wird diese Buchung ignoriert
        AND (@MonateBisAlsNachzahlungInterpretiert IS NULL 
             OR DATEDIFF(m, 
                         dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1), 
                         dbo.fnDateOf(COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum))) < @MonateBisAlsNachzahlungInterpretiert)
      GROUP BY LEI.FaProzessCode, LEI.ModulID, LEI.BaPersonID, COALESCE(ZLL.TransferDatum, BUC2.BelegDatum, BUC.BelegDatum, BUC.ValutaDatum);
  END;
  
  -----------------------------------------------------------------------------
  -- Mutterschaftsleistungen, bzw. KKBB
  -----------------------------------------------------------------------------
  IF (@LeistungsartCodes LIKE '%,23,%')
  BEGIN
    -- ----------------------------------------------------------------------------
    -- Mutterschaftsleistungen, bzw. KKBB
    -- jeweils die letzten Ausgleichsbuchungen eines Tages für jede BaPerson WSH in @OutputResult speichern. 
    -- Es handelt sich um Reso und KiSS Dossiers 
    -- ck: ZH only!
    -- ----------------------------------------------------------------------------
    INSERT INTO @TmpData (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID, BaPersonID_Glaeubiger)
      SELECT FaProzessCode   = LST.FaProzessCode,
             BaPersonID      = LST.BaPersonID,
             Ausgleichsdatum = KB_2.BelegDatum,
             FaLeistungID    = MAX(LST.FaLeistungID),
             BaPersonID_Glaeubiger = MIN(-1)
      FROM dbo.FaLeistung                 LST  WITH (READUNCOMMITTED)
        LEFT  JOIN dbo.IkRechtstitel      IRT  WITH (READUNCOMMITTED) ON IRT.FaLeistungID = LST.FaLeistungID
        INNER JOIN dbo.IkPosition         IPO  WITH (READUNCOMMITTED) ON (IPO.FaLeistungID = LST.FaLeistungID OR IPO.IkRechtstitelID = IRT.IkRechtstitelID)
                                                                     AND (LST.FaProzessCode = 407) -- 407: KKBB  
        INNER JOIN dbo.KbBuchung          KB_1 WITH (READUNCOMMITTED) ON (IPO.IkPositionID = KB_1.IkPositionID)
        INNER JOIN dbo.KbBuchungKostenart KBK  WITH (READUNCOMMITTED) ON (KBK.KbBuchungID = KB_1.KbBuchungID)
                                                                     AND (KBK.BgKostenartID = 415) -- 415: KKBB Ausgabe 
        INNER JOIN dbo.BgKostenart        BK   WITH (READUNCOMMITTED) ON (KBK.BgKostenartID = BK.BgKostenartID)
                                                          --ZH only: AND (BK.FaFachbereichCode = 7) --   7: KKBB
        INNER JOIN dbo.KbOpAusgleich      KOA  WITH (READUNCOMMITTED) ON (KB_1.KbBuchungID = KOA.OpBuchungID)
        INNER JOIN dbo.KbBuchung          KB_2 WITH (READUNCOMMITTED) ON (KB_2.KbBuchungID = KOA.AusgleichBuchungID) 
                                                                     AND (dbo.fnDateOf(KB_2.BelegDatum) BETWEEN @Date0107OfJahrMinus1 AND @Date3112OfJahr
                                                                          OR (@InklBuchungenVorErhebungsjahr = 1 AND dbo.fnDateOf(KB_2.BelegDatum) <= @Date3112OfJahrMinus1))
        LEFT  JOIN dbo.vwUser             USR  WITH (READUNCOMMITTED) ON USR.UserID = LST.UserID
      WHERE LST.UserID = ISNULL(@UserID, LST.UserID)
        AND LST.BaPersonID = ISNULL(@BaPersonID, LST.BaPersonID)
        AND (USR.OrgUnitID = @OrgUnitID OR @OrgUnitID IS NULL)
      GROUP BY LST.FaProzessCode, LST.BaPersonID, KB_2.BelegDatum;
  END;
  
  -----------------------------------------------------------------------------
  -- ALBV
  -----------------------------------------------------------------------------
  IF (@LeistungsartCodes LIKE '%,25,%')
  BEGIN
    -- ----------------------------------------------------------------------------
    -- ALBV
    -- jeweils die letzen Ausgleichsbuchungen eines Tages für jede BaPerson WSH in @OutputResult speichern. 
    -- Es handelt sich um Reso und KiSS Dossiers 
    -- ck: ZH only (bis jetzt): da muss dann dieselbe Logik implementiert werden.
    -- ----------------------------------------------------------------------------
    INSERT INTO @TmpData (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID, BaPersonID_Glaeubiger)
      SELECT FaProzessCode   = LEI.FaProzessCode,
             BaPersonID      = GLB.BaPersonID_AntragStellendePerson,
             Ausgleichsdatum = KB_2.BelegDatum,
             FaLeistungID    = MAX(LEI.FaLeistungID),
             BaPersonID_Glaeubiger = ISNULL(KBK_1.BaPersonID, -1)
      FROM dbo.FaLeistung                 LEI  WITH (READUNCOMMITTED)
        LEFT  JOIN dbo.IkRechtstitel      IRT  WITH (READUNCOMMITTED) ON IRT.FaLeistungID = LEI.FaLeistungID
        INNER JOIN dbo.IkPosition         IPO  WITH (READUNCOMMITTED) ON (IPO.FaLeistungID = LEI.FaLeistungID OR IPO.IkRechtstitelID = IRT.IkRechtstitelID)
        INNER JOIN dbo.IkGlaeubiger       GLB  WITH (READUNCOMMITTED) ON (GLB.FaLeistungID = LEI.FaLeistungID OR GLB.IkRechtstitelID = IRT.IkRechtstitelID)
                                                                     AND GLB.BaPersonID = IPO.BaPersonID
        INNER JOIN dbo.KbBuchung          KB_1 WITH (READUNCOMMITTED) ON (IPO.IkPositionID = KB_1.IkPositionID)
        INNER JOIN dbo.KbBuchungKostenart KBK_1 WITH (READUNCOMMITTED) ON KBK_1.KbBuchungID = KB_1.KbBuchungID
                                                                      AND KBK_1.BgKostenartID IN (SELECT dbo.fnBgGetKostenartIDByKontoNr([Value])
                                                                                                  FROM dbo.fnSplit(@KontoNrALBV, ';'))
        INNER JOIN dbo.KbOpAusgleich      KOA  WITH (READUNCOMMITTED) ON (KOA.OpBuchungID = KB_1.KbBuchungID)
        INNER JOIN dbo.KbBuchung          KB_2 WITH (READUNCOMMITTED) ON (KB_2.KbBuchungID = KOA.AusgleichBuchungID) 
                                                                     AND (dbo.fnDateOf(KB_2.BelegDatum) BETWEEN @Date0107OfJahrMinus1 AND @Date3112OfJahr
                                                                          OR (@InklBuchungenVorErhebungsjahr = 1 AND dbo.fnDateOf(KB_2.BelegDatum) <= @Date3112OfJahrMinus1))
        LEFT  JOIN dbo.vwUser             USR  WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
      WHERE LEI.FaProzessCode = 401 -- Alimente
        AND LEI.UserID = ISNULL(@UserID, LEI.UserID)
        AND GLB.BaPersonID_AntragStellendePerson = ISNULL(@BaPersonID, GLB.BaPersonID_AntragStellendePerson)
        AND (USR.OrgUnitID = @OrgUnitID OR @OrgUnitID IS NULL)
      GROUP BY LEI.FaProzessCode, GLB.BaPersonID_AntragStellendePerson, KB_2.BelegDatum, KBK_1.BaPersonID;
  END;
  
  -----------------------------------------------------------------------------
  -- done, prepare output
  -----------------------------------------------------------------------------
  INSERT INTO @OutputResult (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID, BaPersonID_Glaeubiger)
    SELECT DISTINCT
           FaProzessCode   = TMP.FaProzessCode,
           BaPersonID      = TMP.BaPersonID,
           Ausgleichsdatum = TMP.Ausgleichsdatum,
           FaLeistungID    = TMP.FaLeistungID,
           BaPersonID_Glaeubiger = TMP.BaPersonID_Glaeubiger
      FROM @TmpData TMP
  
  RETURN;
END;
GO