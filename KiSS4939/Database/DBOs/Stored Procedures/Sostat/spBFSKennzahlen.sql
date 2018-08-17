SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBFSKennzahlen;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Fasst summarisch die wichtigsten Fall- und Finanzkennzahlen eines bestimmten Datumsberichs der aktuell
           importierten Dossiers zusammen: 
           Fallzahl, Anzahl UE/HH, Bruttobedarf, Einnahmen, Zulagen,Nettobetdarf, zugesprochene Leistung
    @Erhebungsjahr:
    @LetzteAuszahlungVon: untere Begrenzung der letzten Auszahlung (BFS-Variable 16.02)
    @LetzteAuszahlungBis: obere Begrenzung der letzten Auszahlung
    @@NettobedarfGroesserOderGleich0: nur Dossiers mit Nettobedarf >= 0 werden berücksichtigt
    @ResultatProDossier: 1: Kennzahlen pro Dossier, 0: Kennzahlen über alle Dossiers hinweg
    @FaLeistungID: Einschränkung auf eine W-Leistung, zu Testzwecken
    @BFSDossierID: Einschränkung auf ein Dossier, zu Testzwecken
    @Stichtag: 1: Stichtag, 0: Anfangszustände
  -
=================================================================================================
  TEST:    EXEC dbo.spBFSKennzahlen;
=================================================================================================*/

CREATE PROCEDURE dbo.spBFSKennzahlen
(
  @Erhebungsjahr                  INT = NULL,
  @LetzteAuszahlungVon            DATETIME = NULL,
  @LetzteAuszahlungBis            DATETIME = NULL,
  @NettobedarfGroesserOderGleich0 BIT = 1,
  @ResultatProDossier             BIT = 0,
  @FaLeistungID                   INT = NULL,
  @BFSDossierID                   INT = NULL,
  @Stichtag                       BIT = 1
)
AS 
BEGIN
  DECLARE @BFSKatalogVersionID INT

  -- Setzen von Default Parametern, falls noch nicht spezifiziert
  SET @Erhebungsjahr                  = COALESCE(@Erhebungsjahr, CONVERT(int, dbo.fnXConfig('System\Sostat\Erhebungsjahr', GETDATE())), YEAR(GETDATE()));
  SET @LetzteAuszahlungVon            = ISNULL(@LetzteAuszahlungVon, dbo.fnDateSerial(@Erhebungsjahr, 1, 1));
  SET @LetzteAuszahlungBis            = ISNULL(@LetzteAuszahlungBis, dbo.fnDateSerial(@Erhebungsjahr, 12, 31));
  SET @NettobedarfGroesserOderGleich0 = ISNULL(@NettobedarfGroesserOderGleich0, 1);
  SET @BFSKatalogVersionID            = dbo.fnBFSGetKatalogVersion(@Erhebungsjahr);

  -- Zwischentotal-Variablen
  DECLARE @ZulagenTotal               MONEY;
  DECLARE @NettobedarfInklZulagen     MONEY;
  DECLARE @DifferenzNettoZugesprochen MONEY;

  -- Zwischentabelle für die effiziente Berechnung von Kennzahlen 
  DECLARE @tmpKennzahlen TABLE
  (
    [BFSDossierID]               INT,
    [V15.06 Erste Auszahlung]    VARCHAR(10),
    [V16.02 Letzte Auszahlung]   VARCHAR(10),
    [V15.04 Bruttobedarf]        MONEY,
    [V10.00 Total Einnahmen]     MONEY,
    [V15.0415 Total MIZ]         MONEY,
    [V15.0416 Total IZU]         MONEY,
    [V15.0417 Total EFB]         MONEY,
    [V15.051 Nettobedarf]        MONEY,
    [V15.052 ZugesprLeistung]    MONEY,
    [V15.08 Jahresauszahlbetrag] MONEY,
    [V15.11 Januar]              MONEY,
    [V15.12 Februar]             MONEY,
    [V15.13 März]                MONEY,
    [V15.14 April]               MONEY,
    [V15.15 Mai]                 MONEY,
    [V15.16 Juni]                MONEY,
    [V15.17 Juli]                MONEY,
    [V15.18 August]              MONEY,
    [V15.19 September]           MONEY,
    [V15.20 Oktober]             MONEY,
    [V15.21 November]            MONEY,
    [V15.22 Dezember]            MONEY
    PRIMARY KEY (BFSDossierID)
  );

  -- Tabelle für die 2-spaltige Struktur der Ausgabe
  DECLARE @Resultat TABLE
  (
    Bezeichnung VARCHAR(200),
    WertBetrag  SQL_VARIANT
  );

  -- Hilfsvariablen für die ID's der relevanten BFS-Variablen
  DECLARE 
    @BFSFrageID_V15_06   INT,
    @BFSFrageID_V16_02   INT,
    @BFSFrageID_V15_04   INT,
    @BFSFrageID_V10_00   INT,
    @BFSFrageID_V15_0415 INT,
    @BFSFrageID_V15_0416 INT,
    @BFSFrageID_V15_0417 INT,
    @BFSFrageID_V15_051  INT,
    @BFSFrageID_V15_052  INT,
    @BFSFrageID_V15_08   INT,  
    @BFSFrageID_V15_11   INT,
    @BFSFrageID_V15_12   INT,
    @BFSFrageID_V15_13   INT,
    @BFSFrageID_V15_14   INT,
    @BFSFrageID_V15_15   INT,
    @BFSFrageID_V15_16   INT,
    @BFSFrageID_V15_17   INT,
    @BFSFrageID_V15_18   INT,
    @BFSFrageID_V15_19   INT,
    @BFSFrageID_V15_20   INT,
    @BFSFrageID_V15_21   INT,
    @BFSFrageID_V15_22   INT;


  SELECT @BFSFrageID_V15_06 = BFSFrageID   FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.06';
  SELECT @BFSFrageID_V16_02 = BFSFrageID   FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '16.02';
  SELECT @BFSFrageID_V15_04 = BFSFrageID   FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.04';
  SELECT @BFSFrageID_V10_00 = BFSFrageID   FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '10.00';
  SELECT @BFSFrageID_V15_0415 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.0415';
  SELECT @BFSFrageID_V15_0416 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.0416';
  SELECT @BFSFrageID_V15_0417 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.0417';
  SELECT @BFSFrageID_V15_051 = BFSFrageID  FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.051';
  SELECT @BFSFrageID_V15_052 = BFSFrageID  FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.052';

  SELECT @BFSFrageID_V15_08 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.08';
  SELECT @BFSFrageID_V15_11 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.11';
  SELECT @BFSFrageID_V15_12 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.12';
  SELECT @BFSFrageID_V15_13 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.13';
  SELECT @BFSFrageID_V15_14 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.14';
  SELECT @BFSFrageID_V15_15 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.15';
  SELECT @BFSFrageID_V15_16 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.16';
  SELECT @BFSFrageID_V15_17 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.17';
  SELECT @BFSFrageID_V15_18 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.18';
  SELECT @BFSFrageID_V15_19 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.19';
  SELECT @BFSFrageID_V15_20 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.20';
  SELECT @BFSFrageID_V15_21 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.21';
  SELECT @BFSFrageID_V15_22 = BFSFrageID FROM dbo.BFSFrage WITH(READUNCOMMITTED) WHERE BFSKatalogVersionID = @BFSKatalogVersionID AND Variable = '15.22';

  -- Befüllung der Detailtabelle mit den relevanten Variablen, pro Dossier ein Datensatz
  INSERT @tmpKennzahlen
  SELECT DOS.BFSDossierID, 
       [V15.06 Erste Auszahlung]  =  CONVERT(VARCHAR(10),V15_06.Wert,104),
       [V16.02 Letzte Auszahlung] =  CONVERT(VARCHAR(10),V16_02.Wert,104),
       [V15.04 Bruttobedarf]      =  CONVERT(MONEY, ISNULL(V15_04.Wert, 0)),
       [V10.00 Total Einnahmen]   =  CONVERT(MONEY, ISNULL(V10_00.Wert, 0)),
       [V15.0415 Total MIZ]       =  CONVERT(MONEY, ISNULL(V15_0415.Wert, 0)),
       [V15.0416 Total IZU]       =  CONVERT(MONEY, ISNULL(V15_0416.Wert, 0)),
       [V5.0417 Total EFB]        =  CONVERT(MONEY, ISNULL(V15_0417.Wert, 0)),
       [V15.051 Nettobedarf]      =  CONVERT(MONEY, ISNULL(V15_051.Wert, 0)),
       [V15.052 ZugesprLeistung]  =  CONVERT(MONEY, ISNULL(V15_052.Wert, 0)),

       [V15.08 Jahresauszahlbetrag] = CONVERT(MONEY, ISNULL(V15_08.Wert, 0)),
       [V15.11 Januar]              = CONVERT(MONEY, ISNULL(V15_11.Wert, 0)),
       [V15.12 Februar]             = CONVERT(MONEY, ISNULL(V15_12.Wert, 0)),
       [V15.13 März]                = CONVERT(MONEY, ISNULL(V15_13.Wert, 0)),
       [V15.14 April]               = CONVERT(MONEY, ISNULL(V15_14.Wert, 0)),
       [V15.15 Mai]                 = CONVERT(MONEY, ISNULL(V15_15.Wert, 0)),
       [V15.16 Juni]                = CONVERT(MONEY, ISNULL(V15_16.Wert, 0)),
       [V15.17 Juli]                = CONVERT(MONEY, ISNULL(V15_17.Wert, 0)),
       [V15.18 August]              = CONVERT(MONEY, ISNULL(V15_18.Wert, 0)),
       [V15.19 September]           = CONVERT(MONEY, ISNULL(V15_19.Wert, 0)),
       [V15.20 Oktober]             = CONVERT(MONEY, ISNULL(V15_20.Wert, 0)),
       [V15.11 November]            = CONVERT(MONEY, ISNULL(V15_21.Wert, 0)),
       [V15.12 Dezember]            = CONVERT(MONEY, ISNULL(V15_22.Wert, 0))
  FROM dbo.BFSDossier     DOS WITH(READUNCOMMITTED)
    LEFT JOIN dbo.BFSWert V15_06   WITH(READUNCOMMITTED) ON V15_06.BFSDossierID   = DOS.BFSDossierID AND V15_06.BFSFrageID = @BFSFrageID_V15_06
    LEFT JOIN dbo.BFSWert V16_02   WITH(READUNCOMMITTED) ON V16_02.BFSDossierID   = DOS.BFSDossierID AND V16_02.BFSFrageID = @BFSFrageID_V16_02
    LEFT JOIN dbo.BFSWert V15_04   WITH(READUNCOMMITTED) ON V15_04.BFSDossierID   = DOS.BFSDossierID AND V15_04.BFSFrageID = @BFSFrageID_V15_04
    LEFT JOIN dbo.BFSWert V10_00   WITH(READUNCOMMITTED) ON V10_00.BFSDossierID   = DOS.BFSDossierID AND V10_00.BFSFrageID = @BFSFrageID_V10_00
    LEFT JOIN dbo.BFSWert V15_0415 WITH(READUNCOMMITTED) ON V15_0415.BFSDossierID = DOS.BFSDossierID AND V15_0415.BFSFrageID = @BFSFrageID_V15_0415
    LEFT JOIN dbo.BFSWert V15_0416 WITH(READUNCOMMITTED) ON V15_0416.BFSDossierID = DOS.BFSDossierID AND V15_0416.BFSFrageID = @BFSFrageID_V15_0416
    LEFT JOIN dbo.BFSWert V15_0417 WITH(READUNCOMMITTED) ON V15_0417.BFSDossierID = DOS.BFSDossierID AND V15_0417.BFSFrageID = @BFSFrageID_V15_0417
    LEFT JOIN dbo.BFSWert V15_051  WITH(READUNCOMMITTED) ON V15_051.BFSDossierID  = DOS.BFSDossierID AND V15_051.BFSFrageID = @BFSFrageID_V15_051
    LEFT JOIN dbo.BFSWert V15_052  WITH(READUNCOMMITTED) ON V15_052.BFSDossierID  = DOS.BFSDossierID AND V15_052.BFSFrageID = @BFSFrageID_V15_052
    LEFT JOIN dbo.BFSWert V15_08   WITH(READUNCOMMITTED) ON V15_08.BFSDossierID  = DOS.BFSDossierID AND V15_08.BFSFrageID = @BFSFrageID_V15_08
    LEFT JOIN dbo.BFSWert V15_11   WITH(READUNCOMMITTED) ON V15_11.BFSDossierID  = DOS.BFSDossierID AND V15_11.BFSFrageID = @BFSFrageID_V15_11
    LEFT JOIN dbo.BFSWert V15_12   WITH(READUNCOMMITTED) ON V15_12.BFSDossierID  = DOS.BFSDossierID AND V15_12.BFSFrageID = @BFSFrageID_V15_12
    LEFT JOIN dbo.BFSWert V15_13   WITH(READUNCOMMITTED) ON V15_13.BFSDossierID  = DOS.BFSDossierID AND V15_13.BFSFrageID = @BFSFrageID_V15_13
    LEFT JOIN dbo.BFSWert V15_14   WITH(READUNCOMMITTED) ON V15_14.BFSDossierID  = DOS.BFSDossierID AND V15_14.BFSFrageID = @BFSFrageID_V15_14
    LEFT JOIN dbo.BFSWert V15_15   WITH(READUNCOMMITTED) ON V15_15.BFSDossierID  = DOS.BFSDossierID AND V15_15.BFSFrageID = @BFSFrageID_V15_15
    LEFT JOIN dbo.BFSWert V15_16   WITH(READUNCOMMITTED) ON V15_16.BFSDossierID  = DOS.BFSDossierID AND V15_16.BFSFrageID = @BFSFrageID_V15_16
    LEFT JOIN dbo.BFSWert V15_17   WITH(READUNCOMMITTED) ON V15_17.BFSDossierID  = DOS.BFSDossierID AND V15_17.BFSFrageID = @BFSFrageID_V15_17
    LEFT JOIN dbo.BFSWert V15_18   WITH(READUNCOMMITTED) ON V15_18.BFSDossierID  = DOS.BFSDossierID AND V15_18.BFSFrageID = @BFSFrageID_V15_18
    LEFT JOIN dbo.BFSWert V15_19   WITH(READUNCOMMITTED) ON V15_19.BFSDossierID  = DOS.BFSDossierID AND V15_19.BFSFrageID = @BFSFrageID_V15_19
    LEFT JOIN dbo.BFSWert V15_20   WITH(READUNCOMMITTED) ON V15_20.BFSDossierID  = DOS.BFSDossierID AND V15_20.BFSFrageID = @BFSFrageID_V15_20
    LEFT JOIN dbo.BFSWert V15_21   WITH(READUNCOMMITTED) ON V15_21.BFSDossierID  = DOS.BFSDossierID AND V15_21.BFSFrageID = @BFSFrageID_V15_21
    LEFT JOIN dbo.BFSWert V15_22   WITH(READUNCOMMITTED) ON V15_22.BFSDossierID  = DOS.BFSDossierID AND V15_22.BFSFrageID = @BFSFrageID_V15_22 
  WHERE DOS.Jahr = @Erhebungsjahr
    AND DOS.Stichtag = @Stichtag
    AND DOS.DatumBis BETWEEN @LetzteAuszahlungVon AND @LetzteAuszahlungBis
    AND DOS.FaLeistungID = ISNULL(@FaLeistungID,DOS.FaLeistungID)
    AND DOS.BFSDossierID = ISNULL(@BFSDossierID,DOS.BFSDossierID);

  -- Löschen der Dossiers mit Nettobedarf <= 0, falls Parameter gesetzt
  IF @NettobedarfGroesserOderGleich0 = 1
  BEGIN
    DELETE @tmpKennzahlen
    WHERE [V15.051 Nettobedarf] < 0.00;
  END;


  IF @ResultatProDossier = 1
  BEGIN
    -- Aufbereiten der detaillierten Ausgabe
    SELECT Jahr            = @Erhebungsjahr,
           Stichtag        = CASE WHEN @Stichtag = 1 THEN 'ja' ELSE 'nein' END,
           DossierID       = DOS.BFSDossierID, 
           FallNr          = LEI.FaFallID, 
           LeistungsNr     = DOS.FaLeistungID, 
           AntragstellerID = DOP.BaPersonID, 
           Antragsteller   = DOP.PersonName, 
           KZL.[V15.06 Erste Auszahlung],
           KZL.[V16.02 Letzte Auszahlung],
           KZL.[V15.04 Bruttobedarf],
           KZL.[V10.00 Total Einnahmen],
           KZL.[V15.0415 Total MIZ],
           KZL.[V15.0416 Total IZU],
           KZL.[V15.0417 Total EFB],
           KZL.[V15.051 Nettobedarf],
           KZL.[V15.052 ZugesprLeistung],
           KZL.[V15.08 Jahresauszahlbetrag],
           KZL.[V15.11 Januar],
           KZL.[V15.12 Februar],
           KZL.[V15.13 März],
           KZL.[V15.14 April],
           KZL.[V15.15 Mai],
           KZL.[V15.16 Juni],
           KZL.[V15.17 Juli],
           KZL.[V15.18 August],
           KZL.[V15.19 September],
           KZL.[V15.20 Oktober],
           KZL.[V15.21 November],
           KZL.[V15.22 Dezember],
           Bruttobedarf               = [V15.04 Bruttobedarf],
           TotalEinnahmen             = [V10.00 Total Einnahmen],
           TotalZulagen               = [V15.0415 Total MIZ] +  [V15.0416 Total IZU] + [V15.0417 Total EFB],
           NettobedarfInklZulagen     = [V15.0415 Total MIZ] +  [V15.0416 Total IZU] + [V15.0417 Total EFB] + [V15.051 Nettobedarf],
           Zugesprochen               = [V15.052 ZugesprLeistung],
           DifferenzNettoZugesprochen = [V15.0415 Total MIZ] +  [V15.0416 Total IZU] + [V15.0417 Total EFB] + [V15.051 Nettobedarf] - [V15.052 ZugesprLeistung],                           
           DifferenzInProzent         = CASE WHEN ([V15.0415 Total MIZ] +  [V15.0416 Total IZU] + [V15.0417 Total EFB] + [V15.051 Nettobedarf]) > 0
                                        THEN ([V15.0415 Total MIZ] +  [V15.0416 Total IZU] + [V15.0417 Total EFB] + [V15.051 Nettobedarf] - [V15.052 ZugesprLeistung]) / 
                                             ([V15.0415 Total MIZ] +  [V15.0416 Total IZU] + [V15.0417 Total EFB] + [V15.051 Nettobedarf]) * 100
                                        ELSE 9999
                                        END
    FROM @tmpKennzahlen               KZL
      INNER JOIN dbo.BFSDossier       DOS WITH(READUNCOMMITTED) ON DOS.BFSDossierID = KZL.BFSDossierID
      INNER JOIN dbo.BFSDossierPerson DOP WITH(READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID
                                                               AND DOP.BFSPersonCode = 1
      LEFT  JOIN dbo.FaLeistung       LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = DOS.FaLeistungID    
    RETURN
  END

  -- Aufbereiten der einzelnen Kennzahlen, mit Zwischensummen
  SET @ZulagenTotal = (SELECT SUM([V15.0415 Total MIZ]) +  
                       SUM([V15.0416 Total IZU]) + 
                       SUM([V15.0417 Total EFB])
     FROM @tmpKennzahlen KZL);

  SET @NettobedarfInklZulagen = @ZulagenTotal + (SELECT SUM([V15.051 Nettobedarf])
                                                 FROM @tmpKennzahlen KZL);

  SET @DifferenzNettoZugesprochen = @NettobedarfInklZulagen - (SELECT SUM([V15.052 ZugesprLeistung])
                                                               FROM @tmpKennzahlen KZL);

  INSERT @Resultat
    SELECT 'Erhebungsjahr',
           CONVERT(VARCHAR, @Erhebungsjahr);

  INSERT @Resultat 
    SELECT 'Stichtag', 
           CASE @Stichtag
             WHEN 1 THEN 'ja'
             ELSE 'nein'
           END;

  INSERT @Resultat 
    SELECT 'Datumsbereich letzte Auszahlung',
           CONVERT(VARCHAR,@LetzteAuszahlungVon,104) + ' - ' + CONVERT(VARCHAR,@LetzteAuszahlungBis,104);
         
  INSERT @Resultat 
    SELECT 'Filter Nettobedarf >= 0', 
           CASE @NettobedarfGroesserOderGleich0
             WHEN 1 THEN 'aktiv'
             ELSE 'inaktiv'
           END;

  INSERT @Resultat 
    SELECT 'Anzahl Fälle',
           (SELECT CONVERT(VARCHAR, COUNT(*))
            FROM @tmpKennzahlen)
           'Fälle';

  INSERT @Resultat
    SELECT 'Anzahl Personen UE',
           (SELECT CONVERT(VARCHAR, COUNT(*))
            FROM @tmpKennzahlen           KZL
              INNER JOIN dbo.BFSDossierPerson DOP WITH(READUNCOMMITTED) ON DOP.BFSDossierID = KZL.BFSDossierID
                                                                       AND DOP.BFSPersonCode in (1,2)
                                                                       AND DOP.PersonIndex <= 9);

  INSERT @Resultat
    SELECT 'Anzahl Personen HH',
           (SELECT CONVERT(VARCHAR, COUNT(*))
            FROM @tmpKennzahlen           KZL
              INNER JOIN dbo.BFSDossierPerson DOP WITH(READUNCOMMITTED) ON DOP.BFSDossierID = KZL.BFSDossierID
                                                                       AND DOP.BFSPersonCode = 3
                                                                       AND DOP.PersonIndex <= 9);
  INSERT @Resultat
    SELECT '', '';

  INSERT @Resultat 
  SELECT 'V10.00 Gesamtes Einkommen UE Betrag',
         (SELECT SUM([V10.00 Total Einnahmen])
          FROM @tmpKennzahlen KZL);

  INSERT @Resultat
  SELECT 'V15.04 Bruttobedarf der UE im Stichmonat (inkl. MIZ, IZU)',
         (SELECT SUM([V15.04 Bruttobedarf])
          FROM @tmpKennzahlen KZL);

  INSERT @Resultat
  SELECT 'V15.0417 Total der Einkommensfreibeträge EFB',
         (SELECT SUM([V15.0417 Total EFB])
          FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.051 Berechneter Nettobedarf gemäss SKOS (inkl. MIZ, IZU)',
           (SELECT SUM([V15.051 Nettobedarf])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'Nettobedarf plus EFB',
           @NettobedarfInklZulagen;

  INSERT @Resultat
    SELECT 'V15.052 Zugesprochene Leistung',
           (SELECT SUM([V15.052 ZugesprLeistung])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'Nettobedarf (inkl. EFB) - Zugesprochene Leistung',
           @DifferenzNettoZugesprochen;

  INSERT @Resultat 
    SELECT 'Differenz in %',
           CASE 
             WHEN @NettobedarfInklZulagen = 0 THEN NULL -- division by zero verhindern
             ELSE @DifferenzNettoZugesprochen / @NettobedarfInklZulagen * 100
           END;

  INSERT @Resultat
    SELECT 'Kontrolle: Bruttobedarf - Einnahmen = Nettobedarf',
           (SELECT SUM([V15.04 Bruttobedarf]) - SUM([V10.00 Total Einnahmen])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT '',''

  INSERT @Resultat
    SELECT 'V15.08 Gesamter Auszahlungsbetrag seit Jahresbeginn',
           (SELECT SUM([V15.08 Jahresauszahlbetrag])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.11 Januar',
           (SELECT SUM([V15.11 Januar])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.12 Februar',
           (SELECT SUM([V15.12 Februar])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.13 März',
           (SELECT SUM([V15.13 März])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.14 April',
           (SELECT SUM([V15.14 April])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.15 Mai',
           (SELECT SUM([V15.15 Mai])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.16 Juni',
           (SELECT SUM([V15.16 Juni])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.17 Juli',
           (SELECT SUM([V15.17 Juli])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.18 August',
           (SELECT SUM([V15.18 August])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.19 September',
           (SELECT SUM([V15.19 September])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.20 Oktober',
           (SELECT SUM([V15.20 Oktober])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.21 November',
           (SELECT SUM([V15.21 November])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'V15.22 Dezember',
           (SELECT SUM([V15.22 Dezember])
            FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT 'Kontrollsumme der Kalendermonate',
           (SELECT 
            SUM([V15.11 Januar]) +
            SUM([V15.12 Februar]) +
            SUM([V15.13 März]) +
            SUM([V15.14 April]) +
            SUM([V15.15 Mai]) +
            SUM([V15.16 Juni]) +
            SUM([V15.17 Juli]) +
            SUM([V15.18 August]) +
            SUM([V15.19 September]) +
            SUM([V15.20 Oktober]) +
            SUM([V15.21 November]) +
            SUM([V15.22 Dezember]) 
        FROM @tmpKennzahlen KZL);

  INSERT @Resultat 
    SELECT '',''

  INSERT @Resultat 
    SELECT 'Datenbank', DB_NAME();
           
  INSERT @Resultat 
    SELECT 'Ausführungszeitpunkt', CONVERT(VARCHAR(30), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(30), GETDATE(), 114);


  -- Ausgabe der Kennzahlen
  SELECT *
  FROM @Resultat;
END;
GO