SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhAbrechnung;
GO

/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  Parameterbeschrieb für die einzelnen TotalErgebnisse
  [TotalAusgabenKlient] 
    @EA: A
    @ZahlungDritte: ''
    @SozEinnahmenAbgetreten = NULL
    @BgKategorie: 2,100,101

  [TotalAusgabenDritte] 
    @EA: A
    @ZahlungDritte: 'D'
    @SozEinnahmenAbgetreten = NULL
    @BgKategorie: 2,100,101

  [TotalVerrechnungRuecherstattung] 
    @EA: E
    @ZahlungDritte: ''
    @SozEinnahmenAbgetreten = NULL
    @BgKategorie: 3

  [TotalEinnahmenKlient] 
    @EA: E
    @ZahlungDritte: ''
    @SozEinnahmenAbgetreten = ''
    @BgKategorie: 1

  [TotalEinnahmenSD] 
    @EA: E
    @ZahlungDritte: ''
    @SozEinnahmenAbgetreten = 'S'
    @BgKategorie: 1

  RETURNS: .
  -
*/

CREATE FUNCTION dbo.fnWhAbrechnung
(
  @WhDetailblattID int,
  -- E für Einzahlung oder A für Auszahlung
  @EA char,
  -- Zahlungen an Dritte -> Spalte D is not null
  @ZahlungDritte char,
  -- Abgetretene Einnahmen -> Spalte S is not null
  @SozEinnahmenAbgetreten char,
  -- Komma separierte Liste mit BG-Kategorie
  @BgKategorie varchar(max)
)
RETURNS 
@tmp TABLE 
(
  LA varchar(10), 
  LAText varchar(150),
  Betrag money
)
AS
BEGIN
  DECLARE @FaFallID INT;
  DECLARE @FT INT;
  DECLARE @DatumVon DATETIME;
  DECLARE @DatumBis DATETIME;
  SELECT 
    @FaFallID = ABR.FaFallID, 
    @FT       = FAL.BaPersonID, 
    @DatumVon = DET.DatumVon, 
    @DatumBis = DET.DatumBis
  FROM dbo.WhDetailblatt			  DET WITH (READUNCOMMITTED)
    INNER JOIN dbo.WhAbrechnung ABR WITH (READUNCOMMITTED) ON ABR.WhAbrechnungID = DET.WhAbrechnungID
    INNER JOIN dbo.FaFall		    FAL WITH (READUNCOMMITTED) ON ABR.FaFallID = FAL.FaFallID
  WHERE WhDetailblattID = @WhDetailblattID;

  DECLARE @KontoauszugParameter TABLE
  (
    FT INT, -- Fallträger
    BaPersonID INT,
    EffektivAbgerechneteLAs VARCHAR(MAX) -- effektiv ausgewaehlte LAs für diese Person
  );

  -- Die Abrechnung ist Fallübergreifend: Finde alle Fälle
  -- Verbesserungsmöglichkeit: Daten für Mig-Buchungen erstellen (Fallzugehörigkeit). Abklären, ob es dies nicht schon gibt.
  -- Tabelle: baPerson, faleistung
  INSERT INTO @KontoauszugParameter (FT, BaPersonID, EffektivAbgerechneteLAs)
    SELECT DISTINCT AAF.FT, WDB.BaPersonID, WDB.EffektivAbgerechneteLAs
    FROM dbo.WhDetailblatt_BaPerson WDB WITH (READUNCOMMITTED)
      OUTER APPLY dbo.fnWhAbrechnungAlleFaelle(CONVERT(VARCHAR(10),WDB.BaPersonID)) AAF
    WHERE WhDetailblattID = @WhDetailblattID 
      AND Inkl = 1;

  INSERT INTO @tmp
    SELECT
      LA,
      MAX(LAText),
      SUM(BetragEffektiv) 
    FROM (SELECT 
            LAText = CASE WHEN BgKategorieCode = 3 
                       THEN LAText + ISNULL(' aus ' +  SPZ.NameSpezkonto,'') 
                       ELSE LAText 
                     END,
            LAProLeist, 
            LA, 
            BetragEffektiv
          FROM @KontoauszugParameter FAL
            CROSS APPLY fnWhKontoauszug(FAL.FT,
                                        CONVERT(Varchar(10), FAL.BaPersonID),
                                        3, -- KbKontoZeitraumCode, 3 = Verwendungsperiode
                                        @DatumVon,
                                        @DatumBis,
                                        NULL, -- Buchungstext
                                        FAL.EffektivAbgerechneteLAs, -- @LAList: Neu wird eine Liste der EffektivAbgerechneten LAs übergeben
                                        0, -- Verdichtet
                                        1, -- InklProLeist
                                        0, -- InklVermittlungsfall
                                        0, -- InklGruen
                                        0, -- InklRot
                                        0, -- InklStorno
                                        @EA, -- EA
                                        1 -- Klientenkontoabrechnungsmodus
                                       ) KON
            LEFT JOIN dbo.BgPosition  BPO ON BPO.BgPositionID = ISNULL(KON.BgPositionID, dbo.fnGetOriginalBgPositionID(KON.KbBuchungBruttoID))
            LEFT JOIN dbo.BgSpezkonto SPZ ON SPZ.BgSpezkontoID = BPO.BgSpezkontoID
            OUTER APPLY (SELECT 
                           S = CASE 
                                 WHEN KON.PK <> 'P' THEN NULL
                                 WHEN KON.EA = 'E' THEN 'S' -- ProLeist Zahlungseingänge sind immer abgetreten. TODO S in fnWhKontoauszug setzen? 
                                 ELSE NULL
                               END
                         ) PROL
            OUTER APPLY (SELECT 
                           D = (SELECT TOP 1 
                                  D = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END
                                FROM dbo.BgPosition                    POS1 WITH (READUNCOMMITTED)
                                  INNER JOIN dbo.KbBuchungBruttoPerson KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = BPO.BgPositionID
                                  OUTER APPLY (SELECT TOP 1 KbAuszahlungsArtCode, BaZahlungswegID
                                               FROM dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED)
                                               WHERE BAP.BgPositionID = POS1.BgPositionID
                                               ORDER BY
                                                 CASE
                                                   WHEN BAP.BaPersonID = KBK.BaPersonID THEN 1
                                                   WHEN BAP.BaPersonID IS NULL THEN 2
                                                   ELSE 3
                                                 END
                                             ) BAP
                                  LEFT  JOIN dbo.vwKreditor KRE  WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
                                WHERE POS1.BgPositionID = BPO.BgPositionID),
                           S = (SELECT TOP 1 NULLIF(KBU.Abgetreten, 0)
                                FROM dbo.KbBuchungBrutto KBU WITH (READUNCOMMITTED)
                                WHERE KBU.KbBuchungBruttoID = KON.KbBuchungBruttoID)
                         WHERE KON.BgPositionID IS NULL -- nur für Umbuchungen berechnen
                           AND KON.PK = 'K'
                         ) UMB -- TODO in fnWhKontoauszug setzen? 
          WHERE (BPO.BgKategorieCode IN (SELECT SplitValue
                                         FROM dbo.fnSplitStringToValues(@BgKategorie, ',', 1))
              OR KON.PK = 'P' AND ',' + @BgKategorie + ',' NOT LIKE '%,3,%' -- ProLeist haben keine Position aber müssen berücksichtigt werden. ProLeist können keine Verrechnung sein
              OR BPO.BgKategorieCode IS NULL AND KON.IstSiLei = 1 AND ',' + @BgKategorie + ',' NOT LIKE '%,3,%' -- SiLei haben nicht zwingend eine Position aber müssen immer berücksichtigt werden
              OR EXISTS(SELECT TOP 1 1 -- ist eine ProLeist Umbuchung
                        FROM dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED)
                        WHERE KBB.KbBuchungBruttoID = KON.KbBuchungBruttoID
                          AND KBB.MigDetailBuchungID IS NOT NULL
                          AND ',' + @BgKategorie + ',' NOT LIKE '%,3,%') -- ProLeist können keine Verrechnung sein
              )
            -- Zahlung an Dritte
            AND (@ZahlungDritte = 'D' AND (KON.D IS NOT NULL OR  UMB.D IS NOT NULL)
              OR @ZahlungDritte = ''  AND (KON.D IS NULL     AND UMB.D IS NULL)
              OR @ZahlungDritte IS NULL)
            -- Einnahme abgetreten
            AND (@SozEinnahmenAbgetreten = 'S' AND (KON.S IS NOT NULL OR  UMB.S IS NOT NULL OR  PROL.S IS NOT NULL)
              OR @SozEinnahmenAbgetreten = ''  AND (KON.S IS NULL     AND UMB.S IS NULL     AND PROL.S IS NULL)
              OR @SozEinnahmenAbgetreten IS NULL)
    ) AS Kontoauszug
    GROUP BY LA, LAProLeist
    ORDER BY LA;

  RETURN;
END;

