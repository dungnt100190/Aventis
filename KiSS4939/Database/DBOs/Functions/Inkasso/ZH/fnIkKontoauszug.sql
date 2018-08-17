SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkKontoauszug
GO
/*===============================================================================================
  $Revision: 8 $
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

CREATE FUNCTION dbo.fnIkKontoauszug
(
	@FaFallID int,
	@DatumVon datetime,
	@DatumBis datetime,
	@forderungsart int,
	@SchuldnerBaPersonID int,
	@glaeubigerBaPersonID int,
	@FaLeistungID int,
	@wik bit
)
RETURNS
@result TABLE
(
	  KbBuchungID			int,
	  SortID				int,
	  IstDebitor			bit,
	  SchuldnerID			int,
	  Schuldner				varchar(200),
	  GlaeubigerID			int,
	  Glaeubiger			varchar(200),
	  BelegNr				varchar(20),
	  Datum					datetime,
	  [Text]				varchar(500),
	  BetragSoll			money,
	  BetragHaben			money,
	  DetailPos				int,
	  DetailText			varchar(500),
	  Saldo					money,
	  Bezahlt				money,
	  Differenz				money,
	  KbBuchungStatusCode	int,
	  IkForderungArtCode	int,
	  FordgArt				varchar(300),
	  PscdFehlermeldung		varchar(500),
	  IstZahlung			bit
)
AS
BEGIN
	INSERT INTO @result
	SELECT
	  BUC.KbBuchungID,
	  SortID = BUC.KbBuchungID,
	  IstDebitor = CONVERT(INT, 1),
	  SchuldnerID   = BUC.Schuldner_BaPersonID,
	  Schuldner     = SCH.NameVorname,
	  GlaeubigerID  = KST.BaPersonID,
	  Glaeubiger    = GLA.NameVorname,
	  BelegNr       = BUC.BelegNr,
	  Datum         = CASE
		  WHEN BUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN BUC.ValutaDatum
		  ELSE KST.VerwPeriodeVon
	  END,
	  [Text]        = KST.Buchungstext,
	  BetragSoll    = CASE WHEN BUC.HabenKtoNr IS NULL THEN KST.Betrag ELSE NULL END,
	  BetragHaben   = CASE WHEN BUC.HabenKtoNr IS NULL THEN NULL ELSE KST.Betrag END,
	  DetailPos     = BUC.IkForderungArtCode,
	  DetailText    = KST.Buchungstext,
	  Saldo = CONVERT(money, NULL),
	  Bezahlt = (
		  SELECT SUM(OP.Betrag)
      FROM dbo.KbOpAusgleich    OP WITH (READUNCOMMITTED)
		    LEFT JOIN dbo.KbBuchung OPB WITH (READUNCOMMITTED) ON OPB.KbBuchungID = OP.AusgleichBuchungID
		  WHERE OP.OpBuchungID = BUC.KbBuchungID
		    AND OPB.KbBuchungStatusCode != 8
	  ),
	  Differenz = CONVERT(money, 0),
	  BUC.KbBuchungStatusCode,
	  BUC.IkForderungArtCode,
	  FordgArt = LOV.Text,
	  BUC.PscdFehlermeldung,
	  IstZahlung = CONVERT(bit,
		CASE WHEN BUC.IkForderungArtCode in (10,11,12,13,14,15,31,32)
		  THEN 1 ELSE 0
		END)
	FROM dbo.FaLeistung                 L WITH (READUNCOMMITTED)
	  INNER JOIN dbo.KbBuchung          BUC WITH (READUNCOMMITTED) ON L.FaLeistungID = BUC.FaLeistungID
    LEFT JOIN dbo.KbBuchungKostenart KST WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KST.KbBuchungID
	  LEFT JOIN dbo.FaFall              F WITH (READUNCOMMITTED) ON F.FaFallID = L.FaFallID
	  LEFT JOIN dbo.vwPerson            GLA WITH (READUNCOMMITTED) ON GLA.BaPersonID = KST.BaPersonID
	  LEFT JOIN dbo.vwPerson            SCH WITH (READUNCOMMITTED) ON SCH.BaPersonID = BUC.Schuldner_BaPersonID
	  LEFT JOIN dbo.XLOVCode            LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'IkForderungArt' AND LOV.Code = BUC.IkForderungArtCode
	WHERE (L.FaFallID = @FaFallID
      OR L.FaFallID IN (
		    SELECT Q.FaFallID
        FROM dbo.FaLeistung Q WITH (READUNCOMMITTED)
		    WHERE Q.FaProzessCode = 301 AND Q.VUFaFallID = @FaFallID ))
	  AND (@FaLeistungID = 0 OR L.FaLeistungID = @FaLeistungID)
	  AND BUC.IkPositionID IS NOT NULL
	  AND (@DatumVon IS NULL OR CASE
		  WHEN BUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN BUC.ValutaDatum
		  ELSE KST.VerwPeriodeVon
	  END >= @DatumVon)  -- Datum Von
	  AND (@DatumBis IS NULL OR CASE
		  WHEN BUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN BUC.BelegDatum
		  WHEN BUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN BUC.ValutaDatum
		  ELSE KST.VerwPeriodeVon
	  END <= @DatumBis)  -- Datum bis
	  AND (@forderungsart IS NULL OR BUC.IkForderungArtCode = @forderungsart)  -- Forderungsart
	  AND (@SchuldnerBaPersonID IS NULL OR BUC.Schuldner_BaPersonID = @SchuldnerBaPersonID)  -- Schuldner
	  AND (@glaeubigerBaPersonID IS NULL OR KST.BaPersonID = @glaeubigerBaPersonID)  -- Gläubiger

	UNION ALL
	SELECT
	  ZBUC.KbBuchungID,
	  SortID = O.OpBuchungID,
	  IstDebitor = CONVERT(INT, 0),
	  SchuldnerID   = ZBUC.Schuldner_BaPersonID,
	  Schuldner     = SCH.NameVorname,
	  GlaeubigerID  = NULL,
	  Glaeubiger    = NULL,
	  BelegNr       = ZBUC.BelegNr,
	  Datum         = CASE
		  WHEN ZBUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN ZBUC.BelegDatum
		  WHEN ZBUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN ZBUC.BelegDatum
		  WHEN ZBUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN ZBUC.BelegDatum
		  WHEN ZBUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN ZBUC.BelegDatum
		  WHEN ZBUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN ZBUC.ValutaDatum
		  ELSE ZKST.VerwPeriodeVon
	  END,
	  [Text]        = CASE WHEN @WIK = 1 THEN BUC.Text ELSE ZBUC.Text END,
	  BetragSoll    = NULL,
	  BetragHaben   = O.Betrag,
	  DetailPos     = ZBUC.IkForderungArtCode,
	  DetailText    = ZBUC.Text,
	  Saldo = CONVERT(money, NULL),
	  Bezahlt = NULL,
	  Differenz = NULL,
	  ZBUC.KbBuchungStatusCode,
	  ZBUC.IkForderungArtCode,
	  FordgArt = LOV.Text,
	  ZBUC.PscdFehlermeldung,
	  IstZahlung = CONVERT(bit, 0)
	FROM dbo.KbOpAusgleich              O
	  LEFT JOIN dbo.KbBuchung           ZBUC ON O.AusgleichBuchungID = ZBUC.KbBuchungID
	  LEFT JOIN dbo.KbBuchungKostenart  ZKST ON ZKST.KbBuchungID = ZBUC.KbBuchungID
	  LEFT JOIN dbo.vwPerson            SCH ON SCH.BaPersonID = ZBUC.Schuldner_BaPersonID
	  LEFT JOIN dbo.XLOVCode            LOV ON LOV.LOVName = 'IkForderungArt' AND LOV.Code = ZBUC.IkForderungArtCode
    LEFT JOIN dbo.KbBuchung           BUC ON BUC.KbBuchungID = O.opBuchungID
	WHERE O.OpBuchungID IN (
	  SELECT DISTINCT BUC.KbBuchungID
	  FROM dbo.FaLeistung                 L
      INNER JOIN dbo.KbBuchung          BUC ON L.FaLeistungID = BUC.FaLeistungID
	    LEFT JOIN dbo.KbBuchungKostenart  KST ON KST.KbBuchungID = BUC.KbBuchungID
	    LEFT JOIN dbo.FaFall              F ON F.FaFallID = L.FaFallID
	  WHERE (L.FaFallID = @FaFallID
      OR L.FaFallID IN (
		    SELECT Q.FaFallID
        FROM dbo.FaLeistung Q
		    WHERE Q.FaProzessCode = 301 AND Q.VUFaFallID = @FaFallID ))
		  AND L.FaProzessCode NOT IN (406,407)
		  AND (@FaLeistungID = 0 OR L.FaLeistungID = @FaLeistungID)
		  AND BUC.IkPositionID IS NOT NULL
	    -- A
		  AND ( @wik = 1 OR @DatumVon IS NULL OR CASE
  		  WHEN BUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN BUC.ValutaDatum
		    ELSE KST.VerwPeriodeVon
		  END >= @DatumVon)  -- Datum Von
		  AND ( @wik = 1 OR @DatumBis IS NULL OR CASE
  		  WHEN BUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN BUC.BelegDatum
		    WHEN BUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN BUC.ValutaDatum
		    ELSE KST.VerwPeriodeVon
		  END  <= @DatumBis)  -- Datum bis
      -- A spezifisch Ende
		  AND (@forderungsart IS NULL OR BUC.IkForderungArtCode = @forderungsart)  -- Forderungsart
		  AND (@SchuldnerBaPersonID IS NULL OR BUC.Schuldner_BaPersonID = @SchuldnerBaPersonID)  -- Schuldner
		  AND (@glaeubigerBaPersonID IS NULL OR KST.BaPersonID = @glaeubigerBaPersonID)  -- Gläubiger
	  )
    -- WIK
	  AND ( @wik = 0 OR @DatumVon IS NULL OR CASE
	    WHEN ZBUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN ZBUC.BelegDatum
	    WHEN ZBUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN ZBUC.BelegDatum
	    WHEN ZBUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN ZBUC.BelegDatum
		  WHEN ZBUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN ZBUC.BelegDatum
	    WHEN ZBUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN ZBUC.ValutaDatum
	    ELSE ZKST.VerwPeriodeVon
	  END >= @DatumVon)  -- Datum Von
	  AND ( @wik = 0 OR @DatumBis IS NULL OR CASE
		  WHEN ZBUC.BelegNr BETWEEN 10000000000 AND 11999999999 THEN ZBUC.BelegDatum
	    WHEN ZBUC.BelegNr BETWEEN 20000000000 AND 21999999999 THEN ZBUC.BelegDatum
	    WHEN ZBUC.BelegNr BETWEEN 56000000000 AND 56999999999 THEN ZBUC.BelegDatum
		  WHEN ZBUC.BelegNr BETWEEN 59000000000 AND 59999999999 THEN ZBUC.BelegDatum
	    WHEN ZBUC.BelegNr BETWEEN 15000000000 AND 15999999999 THEN ZBUC.ValutaDatum
	    ELSE ZKST.VerwPeriodeVon
	  END  <= @DatumBis)  -- Datum bis
    -- WIK-spezifisch Ende
	ORDER BY Datum, Glaeubiger, SortID

	DECLARE @Saldo money
	SET @Saldo = $0.00
	UPDATE @result SET @Saldo = Saldo = @Saldo + IsNull(BetragSoll, $0.00) - IsNull(BetragHaben, $0.00)
	RETURN
END
GO