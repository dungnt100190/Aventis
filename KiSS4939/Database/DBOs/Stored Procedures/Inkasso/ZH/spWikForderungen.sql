SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWikForderungen;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Liefert Daten an die Maske CtlQueryWikMahnstati
    @UserID: Nur von diesem Benutzer erfasste Forderungen anzeigen
    @SchuldnerBaPersonID: Nur Forderungen für diesen Schuldner anzeigen.
  -
  RETURNS: 
  -
=================================================================================================
  TEST:    EXEC dbo.sp<Name> …
=================================================================================================*/



CREATE PROCEDURE dbo.spWikForderungen
  @UserID int,
  @SchuldnerBaPersonID int,
  @Datumsart char, -- z: Zahlungseingang, s: Sollstellung
  @DatumVon datetime,
  @DatumBis datetime,
  @forderungsStatus char, -- o: offen, b: bezahlt, null: alle
  @FaProzessCode int,
  @ForderungsArt char, -- p: Periodische, e: einmalige, null: alle
  @LeistungAktiv bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  DECLARE @result TABLE 
  (
    FaFallID int,
    FaLeistungID int,
    FallBaPersonID int,
    KbBuchungID int,
    BuchungsText varchar(1000),
    [Status] int,
    Forderungsart varchar(30),
    SchuldnerNameVorname varchar(300),
    Verpflichtung money,
    BetragTotal money,
    BetragZE money,
    ValutaDatum datetime
  );

  SELECT
    @DatumVon = ISNULL(@DatumVon, CONVERT(datetime, '17530101')),
    @DatumBis = ISNULL(@DatumBis, CONVERT(datetime, '99991231'));

    INSERT INTO @result
	  SELECT
      LEI.FaFallID,
      LEI.FaLeistungID,
      FAL.BaPersonID,
      BUC.KbBuchungID,
      KOS.BuchungsText,
      [Status] = BUC.KbBuchungStatusCode,
      Forderungsart = CASE WHEN POS.Einmalig = 1 THEN 'Einmalig' ELSE 'Periodisch' END,
      SchuldnerNameVorname = PER.NameVorname,
      Verpflichtung = BUC.Betrag,
      BetragTotal = ISNULL((SELECT SUM(ISNULL(AUG.Betrag, $0.00)) FROM KbOpAusgleich AUG WHERE OpBuchungID = BUC.KbBuchungID), $0.00),
      BetragZE = ISNULL(BEZ.Betrag, $0.00), -- Bezahlt zw. DatumVon und DatumBis
      ValutaDatum = BUC.ValutaDatum
    FROM dbo.KbBuchung                  BUC
      INNER JOIN dbo.FaLeistung         LEI ON BUC.FaLeistungID = LEI.FaLeistungID
      INNER JOIN dbo.IkPosition         POS ON BUC.IkPositionID = POS.IkPositionID
      OUTER APPLY (SELECT Betrag = SUM(ISNULL(AUG.Betrag, $0.00))
                   FROM dbo.KbOpAusgleich AUG
                     INNER JOIN dbo.KbBuchung BUC2 ON BUC2.KbBuchungID = AUG.AusgleichBuchungID 
                   WHERE AUG.OpBuchungID = BUC.KbBuchungID AND BUC2.BelegDatum BETWEEN @DatumVon AND @DatumBis
                  ) BEZ -- bezahlt zwischen @DatumVon und @DatumBis
      LEFT JOIN dbo.KbBuchungKostenart KOS ON KOS.KbBuchungID = BUC.KbBuchungID
      LEFT JOIN dbo.vwPerson           PER ON PER.BaPersonID = LEI.BaPersonID
      LEFT JOIN dbo.FaFall             FAL ON FAL.FaFallID = LEI.FaFallID
    WHERE
      (@UserID IS NULL OR BUC.ErstelltUserID = @UserID)
      AND LEI.FaProzessCode IN (301, 302, 304) -- Einschränkung auf WIK-Leistungen
      AND (@SchuldnerBaPersonID IS NULL OR LEI.BaPersonID = @SchuldnerBaPersonID)
      AND (@FaProzessCode IS NULL OR LEI.FaProzessCode = @FaProzessCode)
      AND (@LeistungAktiv IS NULL OR @LeistungAktiv = 1 AND (LEI.DatumBis IS NULL OR LEI.DatumBis >= GetDate())
          OR @LeistungAktiv = 0 AND LEI.DatumBis < GetDate())
      -- Einschränkung auf periodische/einmalige Sollstellungen
      AND (@ForderungsArt IS NULL OR @ForderungsArt = 'p' AND POS.Einmalig = 0 OR @ForderungsArt = 'e' AND POS.Einmalig = 1)
      -- Suche nach Sollstellungsdatum
      AND (@Datumsart <> 's' OR
        (
          -- Valutadatum im Suchbereich
          BUC.ValutaDatum BETWEEN @DatumVon AND @DatumBis AND
          -- zusätliche Suchkriterium offen/bezahlt
            (@forderungsStatus IS NULL OR
             @forderungsStatus = 'o' AND BUC.KbBuchungStatusCode NOT IN (6, 8) OR
             @forderungsStatus = 'b' AND BUC.KbBuchungStatusCode = 6)
        ))
      -- Suche nach Zahlungseingang
      AND (@Datumsart <> 'z' OR
        -- nur Einträge ohne ZE
        @forderungsStatus = 'o' AND (BEZ.Betrag IS NULL OR BEZ.Betrag = 0) AND BUC.KbBuchungStatusCode NOT IN (6, 8)  OR
        -- nur Einträge mit ZE
        @forderungsStatus = 'b' AND BEZ.Betrag <> 0 AND BUC.KbBuchungStatusCode <> 8
      );

  -- Haupteinträge
  SELECT
    FaFallID,
    FaLeistungID,
    FallBaPersonID,
    KbBuchungID,
    BuchungsText,
    [Status],
    Forderungsart,
    SchuldnerNameVorname,
    Verpflichtung,
    BetragTotal,
    BetragZE,
    Differenz = Verpflichtung - BetragTotal,
    ValutaDatum
  FROM @result
  ORDER BY FaFallID, SchuldnerNameVorname;

  -- Einzelne Ausgleichsbuchungen
  IF @Datumsart = 'z' AND @forderungsStatus = 'b' BEGIN
    SELECT
      RES.KbBuchungID,
      AusgleichBuchungID = BUC.KbBuchungID,
      AusgleichDatum = BUC.BelegDatum,
      RES.SchuldnerNameVorname,
      BuchungsText,
      Betrag = AUG.Betrag
    FROM @result RES
      INNER JOIN dbo.KbOpAusgleich AUG ON AUG.OpBuchungID = RES.KbBuchungID
      INNER JOIN dbo.KbBuchung BUC ON BUC.KbBuchungID = AUG.AusgleichBuchungID
    WHERE BUC.BelegDatum BETWEEN @DatumVon AND @DatumBis
    ORDER BY FaFallID, SchuldnerNameVorname;
  END

END
GO
