SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spIkGetKontoauszug;
GO
/*===============================================================================================
  $Revision: 26 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Inkasso-Kontoauszug erstellen. 
           Wird auch an folgenden Orte verwendet: - Schuldneransicht
                                                  - Gläubigeransicht
                                                  - Abfrage Inkasso Quote
                                                  - Abfrage Gläubiger Personalien
                                                  - Abfrage Rückerstattungsgründe
    @Forderungsart:        Code der Forderung aus LOV IkForderungEinmalig
    @GlaeubigerBaPersonID: BaPersonID des Gläubigers
    @SchuldnerBaPersonID:  BaPersonID des Schuldners
    @FaLeistungIDList:     kommaseparierte Liste von 1-n LeistungIDs (z.B.: '123456,123457' oder '123456')
    @BelegDatumVonX:       DatumVon des Belegdatums
    @BelegDatumBisX:       DatumBis des Belegdatums
    @ForderungDatumVonX:   DatumVon der Forderung (wird nur in CtlQueryIkRueckerstattungsgruende verwendet)
    @ForderungDatumBisX:   DatumBis der Forderung (wird nur in CtlQueryIkRueckerstattungsgruende verwendet)
    @InklusiveEinmalige:   ob einmalige Forderungen auch berücksichtigt werden müssen
    @MitSaldovortrag:      ob der Saldovortrag berechnet werden muss
    @Verdichtet:           ob der Kontoauszug verdichtet erstellt werden muss
    @ZahlungseingangEinmaligPeriodischUnterscheiden   ob angezeigt werden soll, dass ein Zahlungseingang auf eine einmalige oder periodische Forderung ausgeglichen wurde.
  -
  RETURNS: der Kontoauszug
  -
  TEST:    EXEC dbo.spIkGetKontoauszug NULL, NULL, 65001, 98851, NULL, NULL, NULL, NULL, 1, 1, 0, 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spIkGetKontoauszug
(
  @Forderungsart                                  INT,
  @GlaeubigerBaPersonID                           INT,
  @SchuldnerBaPersonID                            INT,
  @FaLeistungIDList                               VARCHAR(MAX),
  @BelegDatumVonX                                 DATETIME,
  @BelegDatumBisX                                 DATETIME,
  @ForderungDatumVonX                             DATETIME,
  @ForderungDatumBisX                             DATETIME,
  @InklusiveEinmalige                             BIT,
  @MitSaldovortrag                                BIT = 0,
  @Verdichtet                                     BIT = 0,
  @ZahlungseingangEinmaligPeriodischUnterscheiden BIT = 0
)
AS
  SET @BelegDatumVonX      = ISNULL(@BelegDatumVonX, '17530101');
  SET @BelegDatumBisX      = ISNULL(@BelegDatumBisX, '99990101');
  SET @MitSaldovortrag     = ISNULL(@MitSaldovortrag, 0);

  -- Define a temporary data-storage table
  -- VerdichtetTyp: Gruppierung:
  -- 1: Kinderalimente
  -- 2: Kinderzulagen  
  -- 3: Erwachsenenalimente
  -- 4: Zahlungseingang
  DECLARE @KontoAuszug TABLE(
    KbBuchungID         INT,
    Typ                 VARCHAR(50),
    BelegNr             INT,
    Datum               DATETIME,
    DatumForderung      DATETIME,
    Glaeubiger          VARCHAR(100), 
    Schuldner           VARCHAR(100), 
    [Text]              VARCHAR(200),
    BetragSoll          MONEY,
    BetragHaben         MONEY,
    SollKto             VARCHAR(10), 
    HabenKto            VARCHAR(10),
    Saldo               MONEY,
    KbOpAusgleichID     INT,
    BaPersonID          INT,
    FaLeistungID        INT,
    Einmalig            BIT,
    Einnahmen           BIT,
    KbZahlungseingangID INT,
    Bemerkung           VARCHAR(500),
    VerdichtetTyp       INT
  );

  DECLARE @FaLeistungIDs TABLE (
    FaLeistungID INT
  );

  INSERT INTO @FaLeistungIDs (FaLeistungID)
    SELECT FaLeistungID = CONVERT(INT, FCN.Value)
    FROM dbo.fnSplit(@FaLeistungIDList, ',') FCN;

  -- Define all BgKostenartID with the KontoNr
  DECLARE @KAID_Rueckerstattung                   INT,
          @KAID_Nachlass                          INT,
          @KAID_Verwandtenbeitraege               INT,
          @KAID_Elternbeitraege                   INT,
          @KAID_RueckerstattungPOM                INT,
          @KAID_Alimentenbevorschussung           INT,
          @KAID_KinderalimenteZulagen             INT,
          @KAID_KinderalimenteUnterstuetzung      INT,
          @KAID_UnterstuetzungVermittlung         INT,
          @KAID_KostenBevorschussung              INT,
          @KAID_KostenUnterstuetzungVermittlung   INT,
          @KAID_ZinsBevorschussung                INT,
          @KAID_ZinsUnterstuetzungVermittlung     INT,
          @KAID_InkassokostenVermittlung          INT,
          @KAID_Erwachsenenalimente               INT,
          @KAID_InkassokostenBevorschussung       INT,
          @KAID_InkassokostenUnterstuetzungsfall  INT,
          @KAID_ZinsUnterstuetzung                INT,
          @KAID_InkassokostenElternbeitraege      INT,
          @KAID_ZinsElternbeitraege               INT,
          @KAID_InkassokostenVerwandtenbeitraege  INT,
          @KAID_ZinsVerwandtenbeitraege           INT,
          @KAID_ZinsVermittlungsfall              INT;

  SET @KAID_Rueckerstattung = dbo.fnBgGetKostenartIDByKontoNr(700);
  SET @KAID_Nachlass = dbo.fnBgGetKostenartIDByKontoNr(701);
  SET @KAID_Verwandtenbeitraege = dbo.fnBgGetKostenartIDByKontoNr(880);
  SET @KAID_Elternbeitraege = dbo.fnBgGetKostenartIDByKontoNr(871);
  SET @KAID_RueckerstattungPOM = dbo.fnBgGetKostenartIDByKontoNr(904);

  SET @KAID_Alimentenbevorschussung = dbo.fnBgGetKostenartIDByKontoNr(780);
  SET @KAID_KinderalimenteZulagen = dbo.fnBgGetKostenartIDByKontoNr(781);
  SET @KAID_KinderalimenteUnterstuetzung = dbo.fnBgGetKostenartIDByKontoNr(872);
  SET @KAID_UnterstuetzungVermittlung = dbo.fnBgGetKostenartIDByKontoNr(870);

  SET @KAID_KostenBevorschussung = dbo.fnBgGetKostenartIDByKontoNr(782);
  SET @KAID_KostenUnterstuetzungVermittlung = dbo.fnBgGetKostenartIDByKontoNr(852);
  SET @KAID_ZinsBevorschussung = dbo.fnBgGetKostenartIDByKontoNr(783);
  SET @KAID_ZinsUnterstuetzungVermittlung = dbo.fnBgGetKostenartIDByKontoNr(853);

  SET @KAID_InkassokostenVermittlung = dbo.fnBgGetKostenartIDByKontoNr(685);
  SET @KAID_Erwachsenenalimente = dbo.fnBgGetKostenartIDByKontoNr(784);
  SET @KAID_InkassokostenBevorschussung = dbo.fnBgGetKostenartIDByKontoNr(682);
  SET @KAID_InkassokostenUnterstuetzungsfall = dbo.fnBgGetKostenartIDByKontoNr(873);
  SET @KAID_ZinsUnterstuetzung = dbo.fnBgGetKostenartIDByKontoNr(874);
  SET @KAID_InkassokostenElternbeitraege = dbo.fnBgGetKostenartIDByKontoNr(856);
  SET @KAID_ZinsElternbeitraege = dbo.fnBgGetKostenartIDByKontoNr(875);
  SET @KAID_InkassokostenVerwandtenbeitraege = dbo.fnBgGetKostenartIDByKontoNr(857);
  SET @KAID_ZinsVerwandtenbeitraege = dbo.fnBgGetKostenartIDByKontoNr(876);
  SET @KAID_ZinsVermittlungsfall = dbo.fnBgGetKostenartIDByKontoNr(785);


  -- Forderungen
  INSERT INTO @KontoAuszug(KbBuchungID, Typ, BelegNr, Datum, DatumForderung, Glaeubiger, Schuldner, [Text], BetragSoll, BetragHaben,
                           SollKto, HabenKto, Saldo, KbOpAusgleichID, BaPersonID, FaLeistungID, Einmalig, Einnahmen, Bemerkung, VerdichtetTyp)
  SELECT  
    KbBuchungID     = BUC.KbBuchungID,
    Typ             = 'Forderung',
    BelegNr         = BUC.BelegNr,
    Datum           = BUC.BelegDatum,
    DatumForderung  = POS.Datum,
    Glaeubiger      = GLB.NameVorname,
    Schuldner       = SCH.NameVorname,
    [Text]          = BUC.Text,
    Soll            = CASE WHEN POS.BetragIstNegativ = 0 THEN BUC.Betrag ELSE $0.00 END,
    Haben           = CASE WHEN POS.BetragIstNegativ = 0 THEN $0.00 ELSE ABS(BUC.Betrag) END,
    SollKto         = BUC.SollKtoNr,
    HabenKto        = BUC.HabenKtoNr,
    Saldo           = $0.00,
    KbOpAusgleichID =  -1,
    BaPersonID      = LST.BaPersonID,
    FaLeistungID    = BUC.FaLeistungID,
    Einmalig        = POS.Einmalig,
    Einnahmen       = CONVERT(BIT, 0),
    Bemerkung       = POS.Bemerkung,
    VerdichtetTyp   = CASE
                        WHEN @Verdichtet = 1 THEN
                          CASE
                            WHEN KOA.BgKostenartID IN (@KAID_Alimentenbevorschussung, @KAID_KinderalimenteUnterstuetzung) AND BUC.Text LIKE '%Kinderalimente%' THEN 1
                            WHEN KOA.BgKostenartID = @KAID_UnterstuetzungVermittlung AND BUC.Text LIKE '%Kinderalimente%' THEN 1 --OLD
                            WHEN KOA.BgKostenartID = @KAID_KinderalimenteZulagen AND BUC.Text LIKE '%Kinderalimente%' THEN 1
                            WHEN KOA.BgKostenartID IN (@KAID_KinderalimenteUnterstuetzung, @KAID_KinderalimenteZulagen) AND BUC.Text LIKE '%Kinderzulagen%' THEN 2
                            WHEN KOA.BgKostenartID = @KAID_UnterstuetzungVermittlung AND BUC.Text LIKE '%Kinderzulagen%' THEN 2 --OLD
                            /*Mantis 8629*/
                            WHEN KOA.BgKostenartID = @KAID_KinderalimenteZulagen THEN 2
                            WHEN KOA.BgKostenartID IN (@KAID_UnterstuetzungVermittlung, @KAID_Erwachsenenalimente) AND BUC.Text LIKE '%Erwachsenenalimente%' THEN 3
                            WHEN KOA.BgKostenartID = @KAID_UnterstuetzungVermittlung AND BUC.Text LIKE '%Erwachsenenalimente%' THEN 3 --OLD
                          END
                        ELSE NULL
                      END
  FROM dbo.KbBuchung                  BUC WITH (READUNCOMMITTED) 
    INNER JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungID = BUC.KbBuchungID
    INNER JOIN dbo.IkPosition         POS WITH (READUNCOMMITTED) ON POS.IkPositionID = BUC.IkPositionID
    LEFT  JOIN dbo.IkRechtstitel      RTL WITH (READUNCOMMITTED) ON RTL.IkRechtstitelID = POS.IkRechtstitelID AND POS.FaLeistungID IS NULL 
    LEFT  JOIN dbo.FaLeistung         LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = ISNULL(POS.FaLeistungID, RTL.FaLeistungID)
    LEFT  JOIN dbo.vwPerson           GLB ON GLB.BaPersonID = POS.BaPersonID
    LEFT  JOIN dbo.vwPerson           SCH ON SCH.BaPersonID = BUC.Schuldner_BaPersonID
    LEFT  JOIN dbo.XLOVCode           LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'IkForderungEinmalig' 
                                                                AND Code = POS.IkForderungCode
    LEFT  JOIN dbo.IkForderungBgKostenartHist FKH  WITH (READUNCOMMITTED) ON FKH.IkForderungBgKostenartHistID = BUC.IkForderungBgKostenartHistID
  WHERE (@FaLeistungIDList IS NULL OR BUC.FaLeistungID IN (SELECT FaLeistungID FROM @FaLeistungIDs))
    AND BUC.KbAuszahlungsArtCode IS NULL -- keine Auszahlungen
    AND ISNULL(@GlaeubigerBaPersonID, ISNULL(GLB.BaPersonID, LST.BaPersonID)) = ISNULL(GLB.BaPersonID, LST.BaPersonID)
    AND ISNULL(@SchuldnerBaPersonID, ISNULL(SCH.BaPersonID, LST.BaPersonID)) = ISNULL(SCH.BaPersonID, LST.BaPersonID)
    -- Wofür ist diese Bedingung nötig?
    AND (POS.Einmalig = 0 
      OR (@InklusiveEinmalige = 1 AND FKH.BgKostenartID = KOA.BgKostenartID)
      OR (LST.FaProzessCode = 405 AND POS.IkForderungCode = 99 AND KOA.BgKostenartID IS NULL)                     -- 99 Tagesheim/Krippe spezialfall 
    )
    -- Filter auf der Forderungsart
    AND ((@Forderungsart IS NULL)
      OR (@Forderungsart = FKH.IkForderungsartFilterCode));

  -- Zahlungen
  INSERT INTO @KontoAuszug(KbBuchungID, Typ, BelegNr, Datum, Glaeubiger, Schuldner, [Text], BetragSoll, BetragHaben, SollKto,
                           HabenKto, Saldo, KbOpAusgleichID, BaPersonID, FaLeistungID, Einmalig, Einnahmen, VerdichtetTyp, KbZahlungseingangID)
  SELECT DISTINCT
    KbBuchungID         = BUC.KbBuchungID,
    Typ                 = 'Zahlung',
    BelegNr             = BUC.BelegNr,
    Datum               = EIN.Datum,
    Glaeubiger          = AUS.Glaeubiger,
    Schuldner           = AUS.Schuldner,
    [Text]              = MAX(ISNULL(BUC.Text, 'Zahlung')),
    Soll                = $0.00,
    Haben               = SUM(OPA.Betrag),
    SollKto             = BUC.SollKtoNr,
    HabenKto            = BUC.HabenKtoNr,
    Saldo               = $0.00,
    KbOpAusgleichID     = MAX(OPA.KbOpAusgleichID),
    BaPersonID          = AUS.BaPersonID,
    FaLeistungID        = AUS.FaLeistungID,
    Einmalig            = CASE
                            WHEN @ZahlungseingangEinmaligPeriodischUnterscheiden = 1 THEN AUS.Einmalig 
                            ELSE NULL
                          END,
    Einnahmen           = CONVERT(BIT, 1),
    VerdichtetTyp       = CASE
                            WHEN @Verdichtet = 1 THEN 4
                            ELSE NULL
                          END,
    KbZahlungseingangID = EIN.KbZahlungseingangID
  FROM @KontoAuszug                  AUS
    INNER JOIN dbo.KbOpAusgleich     OPA WITH (READUNCOMMITTED) ON OPA.OpBuchungID = AUS.KbBuchungID
    INNER JOIN dbo.KbBuchung         BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = OPA.AusgleichBuchungID
    INNER JOIN dbo.KbZahlungseingang EIN WITH (READUNCOMMITTED) ON EIN.KbZahlungseingangID = BUC.KbZahlungseingangID
  GROUP BY BUC.BelegNr, BUC.KbBuchungID, EIN.Datum, AUS.Glaeubiger, AUS.Schuldner, BUC.SollKtoNr, BUC.HabenKtoNr, AUS.BaPersonID, AUS.FaLeistungID, 
      CASE
        WHEN @ZahlungseingangEinmaligPeriodischUnterscheiden = 1 THEN AUS.Einmalig 
        ELSE NULL
      END, EIN.KbZahlungseingangID;

  -- Saldovortrag-Row einfügen
  IF(@MitSaldovortrag = 1) 
  BEGIN
    IF(@FaLeistungIDList IS NULL)
    BEGIN
      INSERT INTO @KontoAuszug ([Text], [BetragSoll], [BetragHaben], [Saldo], [KbOpAusgleichID])
      SELECT
        [Text]          = 'Saldovortrag',
        BetragSoll      = ISNULL(SUM(BetragSoll), 0.0),
        BetragHaben     = ISNULL(SUM(BetragHaben), 0.0),
        Saldo           = ISNULL(SUM(BetragSoll)-SUM(BetragHaben), 0.0),
        KbOpAusgleichID = -1
      FROM @KontoAuszug
      WHERE Datum < @BelegDatumVonX 
    END
	ELSE
	BEGIN
      INSERT INTO @KontoAuszug (FaLeistungID, [Text], [BetragSoll], [BetragHaben], [Saldo], [KbOpAusgleichID])
      SELECT
        FaLeistungID    = IDS.FaLeistungID,
        [Text]          = 'Saldovortrag',
        BetragSoll      = ISNULL(SUM(AUS.BetragSoll), 0.0),
        BetragHaben     = ISNULL(SUM(AUS.BetragHaben), 0.0),
        Saldo           = ISNULL(SUM(AUS.BetragSoll) - SUM(AUS.BetragHaben), 0.0),
        KbOpAusgleichID = -1
      FROM @FaLeistungIDs IDS 
        LEFT JOIN @Kontoauszug AUS ON AUS.FaLeistungID = IDS.FaLeistungID
                                  AND AUS.Datum IS NULL OR AUS.Datum < @BelegDatumVonX 
      GROUP BY IDS.FaLeistungID
    END;
  END;

  -- Verdichtete (Gruppierte) Ausgabe
  IF (@Verdichtet = 1)
  BEGIN
    SELECT
      VerdichtetTyp       = VerdichtetTyp,
      KbBuchungID         = MAX(KbBuchungID),
      Typ                 = MAX(Typ),
      BelegNr             = MAX(BelegNr),
      Datum               = Datum,
      DatumForderung      = DatumForderung,
      Glaeubiger          = LTRIM(dbo.ConcDistinct(' ' + Glaeubiger)),
      Schuldner           = Schuldner,
      [Text]              = CASE
                              WHEN VerdichtetTyp = 1 THEN 'Kinderalimente ' + dbo.fnDateAsVarchar(DatumForderung, 'yyyy.mm')
                              WHEN VerdichtetTyp = 2 THEN 'Kinderzulagen ' + dbo.fnDateAsVarchar(DatumForderung, 'yyyy.mm')
                              WHEN VerdichtetTyp = 3 THEN 'Erwachsenenalimente ' + dbo.fnDateAsVarchar(DatumForderung, 'yyyy.mm')
                              ELSE MAX(Text)
                            END,
      BetragSoll          = SUM(BetragSoll),
      BetragHaben         = SUM(BetragHaben),
      SollKto             = MAX(SollKto),
      HabenKto            = MAX(HabenKto),
      Saldo               = SUM(Saldo),
      KbOpAusgleichID     = MAX(KbOpAusgleichID),
      BaPersonID          = MAX(BaPersonID),
      FaLeistungID        = FaLeistungID,
      Einmalig            = Einmalig,
      Einnahmen           = Einnahmen,
      Bemerkung           = ''
    FROM @KontoAuszug
    WHERE 
      --are we in Kontoauszug-Mode?
      ((@ForderungDatumVonX IS NULL OR @ForderungDatumBisX IS NULL)
        --we are in Kontoauszug-Mode
        AND (Datum BETWEEN @BelegDatumVonX AND @BelegDatumBisX
              OR Datum IS NULL
            )
      )
      OR 
      --are we in CtlQueryIkRueckerstattungsgruende-Mode? 
      ((@ForderungDatumVonX IS NOT NULL AND @ForderungDatumBisX IS NOT NULL)
        --we are in Query-Mode
        AND (DatumForderung IS NOT NULL AND (DatumForderung BETWEEN @ForderungDatumVonX AND @ForderungDatumBisX)
              OR (DatumForderung IS NULL AND (Datum BETWEEN @BelegDatumVonX AND @BelegDatumBisX))
            )
      )
    GROUP BY Datum, DatumForderung, VerdichtetTyp, Schuldner, FaLeistungID, Einmalig, Einnahmen, KbZahlungseingangID
    ORDER BY Datum;
  END
  ELSE
  BEGIN
    SELECT 
      KbBuchungID,
      Typ,
      BelegNr,
      Datum,
      DatumForderung,
      Glaeubiger, 
      Schuldner, 
      [Text],
      BetragSoll,
      BetragHaben,
      SollKto, 
      HabenKto,
      Saldo,
      KbOpAusgleichID,
      BaPersonID,
      FaLeistungID,
      Einmalig,
      Einnahmen,
      Bemerkung
    FROM @KontoAuszug
    WHERE 
      --are we in Kontoauszug-Mode?
      ((@ForderungDatumVonX IS NULL OR @ForderungDatumBisX IS NULL)
        --we are in Kontoauszug-Mode
        AND (Datum BETWEEN @BelegDatumVonX AND @BelegDatumBisX
              OR Datum IS NULL
            )
      )
      OR 
      --are we in CtlQueryIkRueckerstattungsgruende-Mode? 
      ((@ForderungDatumVonX IS NOT NULL AND @ForderungDatumBisX IS NOT NULL)
        --we are in Query-Mode
        AND (DatumForderung IS NOT NULL AND (DatumForderung BETWEEN @ForderungDatumVonX AND @ForderungDatumBisX)
              OR (DatumForderung IS NULL AND (Datum BETWEEN @BelegDatumVonX AND @BelegDatumBisX))
            )
      )
    ORDER BY Datum;
  END;
GO
