SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhAZLvsKVG
GO
-- =============================================
-- Author:		Marghitola Marcel
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spWhAZLvsKVG]
  -- Add the parameters for the stored procedure here
  @DatumVon datetime,
  @DatumBis datetime,
  @OrgGruppeID int,
  @TeamID int,
  @UserID int,
  @BaPersonID int,
  @FaFallID int
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

SELECT @DatumVon = ISNULL(@DatumVon, '17530101'), @DatumBis = ISNULL(@DatumBis, '30000101')

;WITH FAL
(
  FaFallID,
  BaPersonID,
  FaLeistungID,
  SozialzentrumKurz,
  OrgUnitShort,
  NameVorname
) AS
(
  SELECT
    FAL.FaFallID,
    FAL.BaPersonID,
    LEI.FaLeistungID,
    MAX(USR.SozialzentrumKurz),
    MAX(USR.OrgUnitShort),
    MAX(USR.NameVorname)
  FROM dbo.FaFall FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.vwUser					USR WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserID
    INNER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = FAL.FaFallID-- AND FAP.IstUnterstuetzt = 1
    INNER JOIN dbo.FaLeistung     LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
        AND (LEI.DatumVon BETWEEN @DatumVon AND @DatumBis
          OR LEI.DatumVon < @DatumVon AND LEI.DatumBis IS NULL
          OR LEI.DatumBis BETWEEN @DatumVon AND @DatumBis)
  WHERE
    (@FaFallID IS NULL OR FAL.FaFallID = @FaFallID)
    AND (FAL.DatumVon BETWEEN @DatumVon AND @DatumBis
      OR FAL.DatumVon < @DatumVon AND FAL.DatumBis IS NULL
      OR FAL.DatumBis BETWEEN @DatumVon AND @DatumBis)
    AND (@UserID IS NULL OR @UserID = FAL.UserID)
    AND (@BaPersonID IS NULL OR @BaPersonID = FAP.BaPersonID)
    AND ((@OrgGruppeID IS NULL AND @TeamID IS NULL) OR USR.OrgUnitID IN (SELECT OrgUnitID FROM dbo.fnOrgUnitsOfTeam(@OrgGruppeID,@TeamID)))
  GROUP BY FAL.FaFallID, FAL.BaPersonID, LEI.FaLeistungID
)
SELECT
  LA74x.FaFallID,
  LA74x.FallBaPersonID,
  PER.DisplayText,
  Betrag74x = Replace(Convert(varchar(20), convert(money, LA74x.Betrag), 1), ',', ''''),
  Betrag140 = Replace(Convert(varchar(20), convert(money, ISNULL(LA140P.Betrag, $0.00) + ISNULL(LA140K.Betrag, $0.00)), 1), ',', ''''),
  Betrag170 = Replace(Convert(varchar(20), convert(money, ISNULL(LA170P.Betrag, $0.00) + ISNULL(LA170K.Betrag, $0.00)), 1), ',', ''''),
  BetragEffektiv74x = Replace(Convert(varchar(20), convert(money, LA74x.BetragEffektiv), 1), ',', ''''),
  BetragEffektiv140 = Replace(Convert(varchar(20), convert(money, ISNULL(LA140P.BetragEffektiv, $0.00) + ISNULL(LA140K.BetragEffektiv, $0.00)), 1), ',', ''''),
  BetragEffektiv170 = Replace(Convert(varchar(20), convert(money, ISNULL(LA170P.BetragEffektiv, $0.00) + ISNULL(LA170K.BetragEffektiv, $0.00)), 1), ',', ''''),
  Diff74x = ISNULL(LA74x.Betrag, $0.00)  - ISNULL(LA74x.BetragEffektiv, $0.00),
  Diff140 = ISNULL(LA140P.Betrag, $0.00) + ISNULL(LA140K.Betrag, $0.00) - (ISNULL(LA140P.BetragEffektiv, $0.00) + ISNULL(LA140K.BetragEffektiv, $0.00)),
  Diff170 = ISNULL(LA170P.Betrag, $0.00) + ISNULL(LA170K.Betrag, $0.00) - (ISNULL(LA170P.BetragEffektiv, $0.00) + ISNULL(LA170K.BetragEffektiv, $0.00)),
  LA74x.SZ,
  LA74x.QT, -- Quartierteam
  LA74x.MA
FROM (
  SELECT
    FaFallID,
    FallBaPersonID = MAX(FallBaPersonID),
    Betrag = SUM(Betrag),
    BetragEffektiv = SUM(BetragEffektiv),
    SZ = MAX(SZ),
    QT = MAX(QT),
    MA = MAX(MA)
  FROM (
    SELECT -- ProLeist 74x
      FAL.FaFallID,
      FallBaPersonID = MAX(FAL.BaPersonID), -- Fallträger
      Betrag = -SUM(dbo.[fnWhGetBetragKontoauszug](2, MIG74x.Betrag, MIG74x.VerwendungVon, MIG74x.VerwendungBis, @DatumVon, @DatumBis)),
      BetragEffektiv = -SUM(dbo.[fnWhGetBetragKontoauszug](2, MIG74x.Betrag, MIG74x.VerwendungVon, MIG74x.VerwendungBis, @DatumVon, @DatumBis)),
      SZ = MAX(FAL.SozialzentrumKurz),
      QT = MAX(FAL.OrgUnitShort), -- Quartierteam
      MA = MAX(FAL.NameVorname)
    FROM FAL
      INNER JOIN dbo.MigDetailBuchung           MIG74x WITH (READUNCOMMITTED) ON FAL.FaLeistungID = MIG74x.FaLeistungID AND MIG74x.KissLeistungsArt in (740, 741, 742, 743)
    WHERE
      (@DatumVon IS NULL AND @DatumBis IS NULL
        OR dbo.fnDatumUeberschneidung(MIG74x.VerwendungVon, MIG74x.VerwendungBis, ISNULL(@DatumVon, CONVERT(datetime,'17530101')), ISNULL(@DatumBis, CONVERT(datetime, '30000101'))) = 1)
      AND MIG74x.LeistungsArtNrProLeist < 9000 AND MIG74x.BuchungsStatusCode = 1 /*Korrekt*/
    GROUP BY FAL.FaFallID
    HAVING SUM(Betrag) <> $0.00
    UNION ALL
    SELECT -- KISS 74x
      FAL.FaFallID,
      FallBaPersonID = MAX(FAL.BaPersonID),
      Betrag = SUM(dbo.[fnWhGetBetragKontoauszug](2,  KBP74x.Betrag, KBP74x.VerwPeriodeVon, KBP74x.VerwPeriodeBis, @DatumVon, @DatumBis)), -- Gesamtbetrag (nicht effektiv)
      BetragEffektiv = SUM(dbo.[fnWhGetBetragKontoauszug](2,
          CASE WHEN NET74x.anteil IS NOT NULL THEN KBP74x.Betrag * NET74x.anteil
            WHEN NET74x.Betrag IS NOT NULL AND NET74x.BetragEffektiv IS NOT NULL THEN KBP74x.Betrag * (NET74x.BetragEffektiv / NET74x.Betrag)
            ELSE KBP74x.Betrag END,
        KBP74x.VerwPeriodeVon, KBP74x.VerwPeriodeBis, @DatumVon, @DatumBis)),
      SZ = MAX(FAL.SozialzentrumKurz),
      QT = MAX(FAL.OrgUnitShort), -- Quartierteam
      MA = MAX(FAL.NameVorname)
    FROM FAL
      INNER JOIN dbo.KbBuchungBrutto	      KBB74x  WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KBB74x.FaLeistungID
      INNER JOIN dbo.BgKostenart			      KOS74x  WITH (READUNCOMMITTED) ON KOS74x.BgKostenartID = KBB74x.BgKostenartID AND KOS74x.KontoNr IN ('740', '741', '742', '743')
      INNER JOIN dbo.KbBuchungBruttoPerson  KBP74x  WITH (READUNCOMMITTED) ON KBB74x.KbBuchungBruttoID = KBP74x.KbBuchungBruttoID
      OUTER APPLY dbo.fnBruttoToNettos(KBP74x.KbBuchungBruttoID, KBP74x.BgPositionID, KBB74x.Betrag, KBB74x.ValutaDatum) AS NET74x
    WHERE
      (@DatumVon IS NULL AND @DatumBis IS NULL 
        OR dbo.fnDatumUeberschneidung(KBP74x.VerwPeriodeVon, KBP74x.VerwPeriodeBis, ISNULL(@DatumVon, CONVERT(datetime,'17530101')), ISNULL(@DatumBis, CONVERT(datetime, '30000101'))) = 1)
      AND KBP74x.Betrag <> $0.00
      AND (KBB74x.KbBuchungStatusCode <> 8 OR IsNull(KBB74x.GruppierungUmbuchung, '') NOT LIKE 'S0%')
      AND (NET74x.Anteil IS NOT NULL OR NET74x.BetragEffektiv <> 0.00 OR NET74x.Betrag IS NULL OR NET74x.BetragEffektiv IS NULL)
      AND (NET74x.Anteil IS NULL OR NET74x.Anteil <> 0.00)
    GROUP BY FAL.FaFallID
    ) LA74xI
  GROUP BY FaFallID
  ) LA74x
  INNER JOIN dbo.vwPerson				  PER WITH (READUNCOMMITTED) ON PER.BaPersonID = LA74x.FallBaPersonID
  OUTER APPLY (
    SELECT -- ProLeist 140
      Betrag = -SUM(dbo.[fnWhGetBetragKontoauszug](2, MIG140.Betrag, MIG140.VerwendungVon, MIG140.VerwendungBis, @DatumVon, @DatumBis)),
      BetragEffektiv = -SUM(dbo.[fnWhGetBetragKontoauszug](2, MIG140.Betrag, MIG140.VerwendungVon, MIG140.VerwendungBis, @DatumVon, @DatumBis))
    FROM dbo.FaLeistung            LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.MigDetailBuchung    MIG140 WITH (READUNCOMMITTED) ON MIG140.FaLeistungID = LEI.FaLeistungID
    WHERE LEI.FaFallID = LA74x.FaFallID -- evt fallbaperson statt fafallid
      AND MIG140.KissLeistungsArt = '140'
      AND (@DatumVon IS NULL AND @DatumBis IS NULL
        OR dbo.fnDatumUeberschneidung(MIG140.VerwendungVon, MIG140.VerwendungBis, ISNULL(@DatumVon, CONVERT(datetime,'17530101')), ISNULL(@DatumBis, CONVERT(datetime, '30000101'))) = 1)
      AND MIG140.LeistungsArtNrProLeist < 9000 AND MIG140.BuchungsStatusCode = 1 /*Korrekt*/
  ) LA140P
  OUTER APPLY (
    SELECT -- KISS 140
      Betrag = SUM(dbo.[fnWhGetBetragKontoauszug](2,  KBP140.Betrag, KBP140.VerwPeriodeVon, KBP140.VerwPeriodeBis, @DatumVon, @DatumBis)), -- Gesamtbetrag (nicht effektiv)
      BetragEffektiv = SUM(dbo.[fnWhGetBetragKontoauszug](2,
          CASE WHEN NET140.anteil IS NOT NULL THEN KBP140.Betrag * NET140.anteil
            WHEN NET140.Betrag IS NOT NULL AND NET140.BetragEffektiv IS NOT NULL THEN KBP140.Betrag * (NET140.BetragEffektiv / NET140.Betrag)
            ELSE KBP140.Betrag END,
        KBP140.VerwPeriodeVon, KBP140.VerwPeriodeBis, @DatumVon, @DatumBis))
    FROM dbo.FaLeistung            LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungBrutto	KBB140 WITH (READUNCOMMITTED) ON KBB140.FaLeistungID = LEI.FaLeistungID
      INNER JOIN dbo.KbBuchungBruttoPerson	  KBP140 WITH (READUNCOMMITTED) ON KBB140.KbBuchungBruttoID = KBP140.KbBuchungBruttoID
      INNER JOIN dbo.BgKostenart			KOS140 WITH (READUNCOMMITTED) ON KOS140.BgKostenartID = KBB140.BgKostenartID AND KOS140.KontoNr = '140'
      OUTER APPLY dbo.fnBruttoToNettos(KBP140.KbBuchungBruttoID, KBP140.BgPositionID, KBB140.Betrag, KBB140.ValutaDatum) AS NET140
    WHERE LEI.FaFallID = LA74x.FaFallID -- evt fallbaperson statt fafallid
      AND (@DatumVon IS NULL AND @DatumBis IS NULL 
        OR dbo.fnDatumUeberschneidung(KBP140.VerwPeriodeVon, KBP140.VerwPeriodeBis, ISNULL(@DatumVon, CONVERT(datetime,'17530101')), ISNULL(@DatumBis, CONVERT(datetime, '30000101'))) = 1)
      AND KBP140.Betrag <> $0.00
      AND (KBB140.KbBuchungStatusCode <> 8 OR IsNull(KBB140.GruppierungUmbuchung, '') NOT LIKE 'S0%')
      AND (NET140.Anteil IS NOT NULL OR NET140.BetragEffektiv <> 0.00 OR NET140.Betrag IS NULL OR NET140.BetragEffektiv IS NULL)
      AND (NET140.Anteil IS NULL OR NET140.Anteil <> 0.00)
  ) LA140K
  OUTER APPLY (
    SELECT -- ProLeist 170
      Betrag = -SUM(dbo.[fnWhGetBetragKontoauszug](2, MIG170.Betrag, MIG170.VerwendungVon, MIG170.VerwendungBis, @DatumVon, @DatumBis)),
      BetragEffektiv = -SUM(dbo.[fnWhGetBetragKontoauszug](2, MIG170.Betrag, MIG170.VerwendungVon, MIG170.VerwendungBis, @DatumVon, @DatumBis))
    FROM dbo.FaLeistung            LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.MigDetailBuchung    MIG170 WITH (READUNCOMMITTED) ON MIG170.FaLeistungID = LEI.FaLeistungID
    WHERE LEI.FaFallID = LA74x.FaFallID -- evt fallbaperson statt fafallid
      AND MIG170.KissLeistungsArt = '170'
      AND (@DatumVon IS NULL AND @DatumBis IS NULL
        OR dbo.fnDatumUeberschneidung(MIG170.VerwendungVon, MIG170.VerwendungBis, ISNULL(@DatumVon, CONVERT(datetime,'17530101')), ISNULL(@DatumBis, CONVERT(datetime, '30000101'))) = 1)
      AND MIG170.LeistungsArtNrProLeist < 9000 AND MIG170.BuchungsStatusCode = 1 /*Korrekt*/
  ) LA170P
  OUTER APPLY (
    SELECT -- KISS 170
      Betrag = SUM(dbo.[fnWhGetBetragKontoauszug](2,  KBP170.Betrag, KBP170.VerwPeriodeVon, KBP170.VerwPeriodeBis, @DatumVon, @DatumBis)), -- Gesamtbetrag (nicht effektiv)
      BetragEffektiv = SUM(dbo.[fnWhGetBetragKontoauszug](2,
          CASE WHEN NET170.anteil IS NOT NULL THEN KBP170.Betrag * NET170.anteil
            WHEN NET170.Betrag IS NOT NULL AND NET170.BetragEffektiv IS NOT NULL THEN KBP170.Betrag * (NET170.BetragEffektiv / NET170.Betrag)
            ELSE KBP170.Betrag END,
        KBP170.VerwPeriodeVon, KBP170.VerwPeriodeBis, @DatumVon, @DatumBis))
    FROM dbo.FaLeistung            LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungBrutto	KBB170 WITH (READUNCOMMITTED) ON KBB170.FaLeistungID = LEI.FaLeistungID
      INNER JOIN dbo.KbBuchungBruttoPerson	  KBP170 WITH (READUNCOMMITTED) ON KBB170.KbBuchungBruttoID = KBP170.KbBuchungBruttoID
      INNER JOIN dbo.BgKostenart			KOS170 WITH (READUNCOMMITTED) ON KOS170.BgKostenartID = KBB170.BgKostenartID AND KOS170.KontoNr = '170'
      OUTER APPLY dbo.fnBruttoToNettos(KBP170.KbBuchungBruttoID, KBP170.BgPositionID, KBB170.Betrag, KBB170.ValutaDatum) AS NET170
    WHERE LEI.FaFallID = LA74x.FaFallID -- evt fallbaperson statt fafallid
      AND (@DatumVon IS NULL AND @DatumBis IS NULL 
        OR dbo.fnDatumUeberschneidung(KBP170.VerwPeriodeVon, KBP170.VerwPeriodeBis, ISNULL(@DatumVon, CONVERT(datetime,'17530101')), ISNULL(@DatumBis, CONVERT(datetime, '30000101'))) = 1)
      AND KBP170.Betrag <> $0.00
      AND (KBB170.KbBuchungStatusCode <> 8 OR IsNull(KBB170.GruppierungUmbuchung, '') NOT LIKE 'S0%')
      AND (NET170.Anteil IS NOT NULL OR NET170.BetragEffektiv <> 0.00 OR NET170.Betrag IS NULL OR NET170.BetragEffektiv IS NULL)
      AND (NET170.Anteil IS NULL OR NET170.Anteil <> 0.00)
  ) LA170K
  ORDER BY LA74x.MA, PER.DisplayText
END
GO
