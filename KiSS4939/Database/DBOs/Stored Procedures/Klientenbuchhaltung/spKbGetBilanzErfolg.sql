SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbGetBilanzErfolg;
GO
/*===============================================================================================
  $Revision: 18 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Erstellt die Bilanz und Erfolgsrechnung
    @KbPeriodeID:     ID der Periode
    @DatumVon:        DatumVon der Dauer, wenn NULL wird das PeriodeVon-Datum übernommen
    @DatumBis:        DatumBis der Dauer, wenn NULL wird das PeriodeBis-Datum übernommen
    @NurMitBuchungen: Zum definieren ob nur Konto mit Buchungen angezeigt werden müssen
                        - 0: alle Konto anzeigen
                        - 1/NULL: nur Konto mit Buchungen anzeigen
    @OhneKtoGruppen:  Zum definieren ob die Kontogruppen angezeigt werden müssen
                        - 0/NULL: Kontogruppen anzeigen
                        - 1: Kontogruppen nicht anzeigen
    @BilanzErCode:    Zum definieren ob die Bilanz oder Erfolgsrechnung erstellt werden muss
                        - 0/NULL: beides
                        - 1 Bilanz
                        - 2 ER

  -
  RETURNS: Eine Tabelle mit Bilanz und/oder Erfolgsrechnung.
           Spalte BilanzErCode definiert ob das Konto Bilanz oder ER relevant ist (1: Bilanz, 2: ER)
  -
  TEST:    EXEC dbo.spKbGetBilanzErfolg 28, NULL, NULL, 0, 1, 0;
           EXEC dbo.spKbGetBilanzErfolg 28;
=================================================================================================*/

CREATE PROCEDURE dbo.spKbGetBilanzErfolg
(
  @KbPeriodeID       INT,
  @DatumVon          DATETIME = NULL,
  @DatumBis          DATETIME = NULL,
  @NurMitBuchungen   BIT = 1,
  @OhneKtoGruppen    BIT = 0,
  @BilanzErCode      INT = NULL -- 0/NULL beides; 1 Bilanz; 2 ER
)
AS
BEGIN

  -- Init temp table
  DECLARE @tmpSummen  TABLE (
    SollKtoNr            VARCHAR(10) NOT NULL,
    HabenKtoNr           VARCHAR(10) NOT NULL,
    Betrag               MONEY,
    Ausgabe              BIT
  );

  DECLARE @tmp TABLE (
    KbKontoID          INT,
    GruppeKontoID      INT,
    Kontogruppe        BIT,
    KbKontoklasseCode  INT,
    KontoNr            VARCHAR(50),
    KontoName          VARCHAR(150),
    Vorsaldo           MONEY,
    Saldo              MONEY,
    UmsatzSoll         MONEY,
    UmsatzHaben        MONEY,
    UmsatzAufwand      MONEY,
    UmsatzErtrag       MONEY,
    Umsatz             MONEY,
    Zuwachs            MONEY,
    Abgang             MONEY,
    SortKey            INT
  );
  
  DECLARE @tmpOutput TABLE (
    -- allgemein
    KbKontoID            INT,
    GruppeKontoID        INT,
    Kontogruppe          BIT,
    KbKontoklasseCode    INT,
    KbKontoklasseCodeSub INT,
    BilanzErCode         INT,
    KontoNr              VARCHAR(50),
    KontoName            VARCHAR(150),
    -- ER
    Aufwand              MONEY,
    Ertrag               MONEY,
    -- Bilanz
    Anfangsbestand       MONEY,
    Endbestand           MONEY,
    Zuwachs              MONEY,
    Abgang               MONEY,
    -- Liste
    Umsatz               MONEY,
    Saldo                MONEY,
    Vorsaldo             MONEY,
    Total                MONEY,
    -- Sortierung
    SortKey1             INT,
    SortKey2             INT,
    SortKey3             BIT,
    SortKey4             INT,
    SortKey5             VARCHAR(50)
  );

  -- Set variable
  IF @NurMitBuchungen IS NULL
  BEGIN
    SET @NurMitBuchungen = 1;
  END;

  IF @BilanzErCode IS NULL
  BEGIN
    SET @BilanzErCode = 0;
  END;

  IF @DatumVon IS NULL
  BEGIN
    SELECT @DatumVon = PeriodeVon 
    FROM dbo.KbPeriode WITH (READUNCOMMITTED) 
    WHERE KbPeriodeID = @KbPeriodeID;
  END;

  IF @DatumBis IS NULL
  BEGIN
    SELECT @DatumBis = PeriodeBis 
    FROM dbo.KbPeriode WITH (READUNCOMMITTED) 
    WHERE KbPeriodeID = @KbPeriodeID;
  END;
 
  -- Hole die technische KontoNr
  DECLARE @TechnischeKonti VARCHAR(255);

  SELECT @TechnischeKonti = CONVERT(VARCHAR(255), dbo.fnXConfig('System\KliBu\TechnischeKonti', @DatumVon));

  DECLARE @technischeKonto TABLE
  (
    ID                INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KontoNr           VARCHAR(10)
  );

  INSERT INTO @technischeKonto(KontoNr)
  SELECT [Value]
  FROM dbo.fnSplit(@TechnischeKonti, ';');

  -- Relevante Buchungen holen
  INSERT INTO @tmpSummen (SollKtoNr, HabenKtoNr, Betrag, Ausgabe)
    SELECT 
      SollKtoNr,
      HabenKtoNr,
      SUM(Betrag),
      Ausgabe
    FROM dbo.fnKbGetRelevanteBuchungen(@KbPeriodeID, @DatumVon, @DatumBis, 0, 0)
    GROUP BY HabenKtoNr, SollKtoNr, Ausgabe;

  ;WITH tmpCte AS
  (
    SELECT KTO.KbKontoID,
           KTO.GruppeKontoID,
           KTO.Kontogruppe,
           KTO.KbKontoklasseCode,
           KTO.KontoNr,
           KTO.KontoName,
           Vorsaldo = dbo.fnKbGetKontoVorsaldo(@KbPeriodeID, KTO.KontoNr, @DatumVon, 0),
           Vorsaldo_Konto = ISNULL(KTO.Vorsaldo, 0),
           Saldo = 0,
           UmsatzSoll = ISNULL((SELECT SUM(Betrag)
                                FROM @tmpSummen
                                WHERE SollKtoNr = KTO.KontoNr), 0),
           UmsatzHaben = ISNULL((SELECT SUM(Betrag)
                                 FROM @tmpSummen
                                 WHERE HabenKtoNr = KTO.KontoNr), 0),
           SortKey = CASE WHEN KTO.GruppeKontoID IS NULL 
                          THEN SortKey 
                          ELSE (SELECT SortKey 
                                FROM dbo.KbKonto WITH (READUNCOMMITTED)
                                WHERE KbKontoID = KTO.GruppeKontoID) 
                     END
    FROM dbo.KbKonto KTO WITH (READUNCOMMITTED) 
    WHERE KTO.KbPeriodeID = @KbPeriodeID
      AND (@NurMitBuchungen = 0
        OR Kontogruppe = 1
        OR ISNULL(KTO.Vorsaldo,0) <> 0
        OR EXISTS (SELECT TOP 1 1 
                   FROM @tmpSummen 
                   WHERE SollKtoNr = KTO.KontoNr 
                     OR HabenKtoNr = KTO.KontoNr))
  )

  INSERT @tmp
    SELECT KbKontoID,
           GruppeKontoID,
           Kontogruppe,
           KbKontoklasseCode,
           KontoNr,
           KontoName,
           Vorsaldo,
           Saldo,
           UmsatzSoll,
           UmsatzHaben,
           UmsatzAufwand  = CASE WHEN KbKontoklasseCode = 3 THEN UmsatzSoll - UmsatzHaben ELSE 0.0 END,
           UmsatzErtrag   = CASE WHEN KbKontoklasseCode = 4 THEN UmsatzHaben - UmsatzSoll ELSE 0.0 END,
           Umsatz = Vorsaldo_Konto + UmsatzSoll - UmsatzHaben,
           Zuwachs = CASE 
                       WHEN KbKontoklasseCode = 5 THEN UmsatzSoll  -- Aktiven
                       WHEN KbKontoklasseCode = 6 THEN UmsatzHaben -- Passiven
                       ELSE 0.0
                     END,
           Abgang  = CASE 
                       WHEN KbKontoklasseCode = 5 THEN UmsatzHaben -- Aktiven
                       WHEN KbKontoklasseCode = 6 THEN UmsatzSoll  -- Passiven
                       ELSE 0.0
                     END,
           SortKey
    FROM tmpCte;

  -- Entfernen von leeren Gruppen
  WHILE @@rowcount > 0
  BEGIN
    DELETE T
    FROM  @tmp T
    WHERE T.Kontogruppe = 1
      AND NOT EXISTS (SELECT TOP 1 1 
                      FROM @tmp 
                      WHERE GruppeKontoID = T.KbKontoID)
  END;
    
  -- Totale für Kontogruppen bilden
  DECLARE @COUNT INT;
  ;WITH UmsatzCte AS
  (
    SELECT 
      TMP.KbKontoID,
      TMP.GruppeKontoID,
      [Level]= 0
    FROM @tmp TMP
    WHERE TMP.Kontogruppe = 1
      AND TMP.GruppeKontoID IS NULL
    
    UNION ALL
    SELECT 
      TMP.KbKontoID,
      TMP.GruppeKontoID,
      [Level] = CTE.[Level] + 1
    FROM @tmp TMP
      INNER JOIN UmsatzCte CTE ON CTE.KbKontoID = TMP.GruppeKontoID
  )

  SELECT @COUNT = MAX([Level])
  FROM UmsatzCte;
  
  WHILE @COUNT > 0 
  BEGIN
    UPDATE T
      SET Umsatz        = (SELECT SUM(ISNULL(Umsatz,0)) 
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID),
          UmsatzSoll    = (SELECT SUM(ISNULL(UmsatzSoll,0)) 
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID),
          UmsatzHaben   = (SELECT SUM(ISNULL(UmsatzHaben,0)) 
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID),
          UmsatzAufwand = (SELECT SUM(IsNull(UmsatzAufwand,0))
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID),
          UmsatzErtrag  = (SELECT SUM(IsNull(UmsatzErtrag,0))
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID),
          Zuwachs       = (SELECT SUM(IsNull(Zuwachs,0))
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID),
          Abgang        = (SELECT SUM(IsNull(Abgang,0))
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID),
          Vorsaldo      = (SELECT SUM(IsNull(Vorsaldo,0))
                           FROM @tmp 
                           WHERE GruppeKontoID = T.KbKontoID)
    FROM @tmp T
    WHERE T.Kontogruppe = 1;
    SET @COUNT = @COUNT - 1;
  END;
  
  -- Ohne Konto-Gruppen (alle Child-Kontogruppen löschen)
  IF @OhneKtoGruppen = 1 
  BEGIN
    ;WITH GruppenCte AS(
      SELECT 
         TMP.KbKontoID,
         TMP.GruppeKontoID,
         GruppeKontoID_Neu = TMP.KbKontoID
      FROM @tmp TMP
      WHERE TMP.Kontogruppe = 1
        AND TMP.GruppeKontoID IS NULL
        
      UNION ALL 
      SELECT 
         TMP.KbKontoID,
         TMP.GruppeKontoID,
         GruppeKontoID_Neu = CTE.GruppeKontoID_Neu
      FROM @tmp TMP
        INNER JOIN GruppenCte CTE ON CTE.KbKontoID = TMP.GruppeKontoID
    )
    
    UPDATE TMP
      SET GruppeKontoID = CTE.GruppeKontoID_Neu
    FROM @tmp TMP
      INNER JOIN GruppenCte CTE ON CTE.KbKontoID = TMP.GruppeKontoID
    WHERE TMP.Kontogruppe = 0;

    DELETE @tmp WHERE Kontogruppe = 1 AND GruppeKontoID IS NOT NULL;
  END;
    
  -- Filter: Bilanz oder Erfolgsrechung oder beides (siehe parameter @BilanzErCode)
  -- Die Rekursion erfolgt von der Wurzel zu den Blättern.
  ;WITH TmpCte AS
  (
    -- Anchor 
    SELECT 
      T.KbKontoID,
      T.GruppeKontoID,
      T.Kontogruppe,
      T.KbKontoklasseCode,
      BilanzErCode = T.KbKontoklasseCode,
      T.KontoNr,
      T.KontoName,
      T.Vorsaldo,
      T.Saldo,
      T.Umsatz,
      T.UmsatzSoll,
      T.UmsatzHaben,
      T.UmsatzAufwand,
      T.UmsatzErtrag,
      T.Zuwachs,
      T.Abgang,
      T.SortKey      
    FROM @tmp T
    WHERE T.GruppeKontoID IS NULL
      AND (KbKontoklasseCode = @BilanzErCode 
        OR KbKontoklasseCode IS NULL 
        OR @BilanzErCode = 0)

    -- Recursion    
    UNION ALL 
    SELECT 
      T.KbKontoID,
      T.GruppeKontoID,
      T.Kontogruppe,
      T.KbKontoklasseCode,
      BilanzErCode = TCTE.BilanzErCode,
      T.KontoNr,
      T.KontoName,
      T.Vorsaldo,
      T.Saldo,
      T.Umsatz,
      T.UmsatzSoll,
      T.UmsatzHaben,
      T.UmsatzAufwand,
      T.UmsatzErtrag,
      T.Zuwachs,
      T.Abgang,
      T.SortKey    
    FROM @tmp T
      INNER JOIN TmpCte TCTE ON TCTE.KbKontoID = T.GruppeKontoID                
  )

  INSERT INTO @tmpOutput
    SELECT
      -- allgemein
      TMP.KbKontoID,
      TMP.GruppeKontoID,
      TMP.Kontogruppe,
      TMP.KbKontoklasseCode,
      KbKontoklasseCodeSub = NULL,
      TMP.BilanzErCode,
      TMP.KontoNr,
      TMP.KontoName,
      
      -- ER
      Aufwand   = CASE WHEN TMP.KbKontoklasseCode = 3 OR TMP.Kontogruppe = 1 
                       THEN TMP.UmsatzAufwand
                       ELSE 0.0 END,
      Ertrag    = CASE WHEN TMP.KbKontoklasseCode = 4 OR TMP.Kontogruppe = 1 
                       THEN TMP.UmsatzErtrag
                       ELSE 0.0 END,
      -- Bilanz
      Anfangsbestand  = CASE WHEN TMP.BilanzErCode = 1 THEN TMP.Vorsaldo ELSE 0.0 END,
      Endbestand      = CASE WHEN TMP.BilanzErCode = 1 THEN TMP.Vorsaldo + TMP.UmsatzSoll - TMP.UmsatzHaben ELSE 0.0 END, 
      Zuwachs         = CASE WHEN TMP.BilanzErCode = 1 THEN TMP.Zuwachs ELSE 0.0 END,
      Abgang          = CASE WHEN TMP.BilanzErCode = 1 THEN TMP.Abgang ELSE 0.0 END,
      
      -- Liste
      Umsatz    = CASE WHEN TMP.Kontogruppe = 0 THEN TMP.Umsatz END,
      Saldo     = CASE WHEN TMP.Kontogruppe = 0 THEN TMP.Saldo END,
      Vorsaldo  = 0,
      Total     = CASE WHEN TMP.Kontogruppe = 1 THEN TMP.Umsatz END,

      -- Sortierung
      SortKey1  = CASE WHEN TMP.GruppeKontoID IS NULL 
                    THEN TMP.SortKey 
                    ELSE (SELECT SortKey 
                          FROM @tmp 
                          WHERE KbKontoID = TMP.GruppeKontoID) 
                  END,
      SortKey2  = CASE WHEN TMP.Kontogruppe = 1 AND TMP.GruppeKontoID IS NOT NULL 
                    THEN (SELECT MIN(GruppeKontoID) 
                          FROM @TMP 
                          WHERE GruppeKontoID = TMP.KbKontoID) 
                    ELSE TMP.GruppeKontoID 
                  END,
      SortKey3  = TMP.Kontogruppe,
      SortKey4  = KTO.Sortkey,
      SortKey5  = ISNULL(TMP.KontoNr,'zzz')
    FROM TmpCte TMP
      INNER JOIN dbo.KbKonto KTO WITH (READUNCOMMITTED) ON KTO.KbKontoID = TMP.KbKontoID
    ORDER BY SortKey1, SortKey2, SortKey3 DESC, SortKey4, SortKey5;

  -- update KbKontoklasseCodeSub 
  ;WITH KontoklasseSubCte AS
  (
    -- Anchor 
    SELECT 
      TMP.KbKontoID,
      TMP.GruppeKontoID,
      KbKontoklasseCodeSub = TMP.KbKontoklasseCode
    FROM @tmpOutput TMP
    WHERE TMP.GruppeKontoID IS NOT NULL
      AND (NOT EXISTS (SELECT TOP 1 1
                       FROM @tmpOutput STMP
                       WHERE STMP.GruppeKontoID = TMP.KbKontoID))

    -- Recursion    
    UNION ALL 
    SELECT 
      TMP.KbKontoID,
      TMP.GruppeKontoID,
      KbKontoklasseCodeSub = TCTE.KbKontoklasseCodeSub 
    FROM @tmp TMP
      INNER JOIN KontoklasseSubCte TCTE ON TCTE.GruppeKontoID = TMP.KbKontoID
  )
  
  UPDATE TMP
  SET TMP.KbKontoklasseCodeSub = CTE.KbKontoklasseCodeSub
  FROM @tmpOutput TMP
    INNER JOIN KontoklasseSubCte CTE ON CTE.KbKontoID = TMP.KbKontoID;
  
  -- technische KontoNr mit Betrag 0.00 und leere Gruppen nicht anzeigen
  ;WITH TechnischeKontoCte AS
  (
    SELECT 
      HasOnlyTechnicalAccount = 1, 
      KbKontoID,
      GruppeKontoID
    FROM @tmpOutput TMP
    WHERE TMP.KontoNr IN (SELECT KontoNr
                          FROM @technischeKonto
                          WHERE TMP.Umsatz = 0.0)
    UNION ALL
    
    SELECT 
      HasOnlyTechnicalAccount = CASE WHEN NOT EXISTS(SELECT 1
                                                     FROM KbKonto KTO1 
                                                     WHERE KTO1.KbPeriodeID = KTO.KbPeriodeID 
                                                       AND KTO1.GruppeKontoID = KTO.KbKontoID
                                                       AND KTO1.KbKontoID <> CTE.KbKontoID) 
                                  THEN 1 
                                  ELSE 0 
                                END,
      KTO.KbKontoID,
      KTO.GruppeKontoID
    FROM KbKonto KTO
      INNER JOIN TechnischeKontoCte CTE ON CTE.GruppeKontoID = KTO.KbKontoID
  )

  DELETE TMP FROM @tmpOutput TMP
  WHERE TMP.KbKontoID IN (SELECT KbKontoID
                          FROM TechnischeKontoCte
                          WHERE HasOnlyTechnicalAccount = 1);

  -- Select output
  SELECT
    -- für Report
    InstName    = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig('SozialDienst\Allgemein\Name', GETDATE())), '[kein Institutionsname]'),
    InstStrasse = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig('SozialDienst\Allgemein\Adresse', GETDATE())), ''),
    InstPLZOrt  = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig('SozialDienst\Allgemein\PLZ', GETDATE())) + ' ', '') +
                  ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig('SozialDienst\Allgemein\Ort', GETDATE())) + ' ', ''),
    Parameter   = CONVERT(VARCHAR(20), @DatumVon, 104)  + ' - ' + CONVERT(VARCHAR(20), @DatumBis, 104),
    DruckDatum  = 'Druckdatum ' + CONVERT(VARCHAR(20), GETDATE(), 104),
    DatumVon  = @DatumVon,
    DatumBis  = @DatumBis,

    -- für Abfrage und Report    
    TMP.KbKontoID,
    TMP.GruppeKontoID,
    TMP.Kontogruppe,
    TMP.KbKontoklasseCode,
    TMP.KbKontoklasseCodeSub,
    TMP.BilanzErCode,
    Konto = ISNULL(TMP.KontoNr + ' ','') + TMP.KontoName,
    TMP.KontoNr,
    TMP.KontoName,
    TMP.Aufwand,
    TMP.Ertrag,

    Anfangsbestand = CASE
                       WHEN TMP.KbKontoklasseCodeSub = 6 AND ISNULL(TMP.Anfangsbestand, 0.0) <> 0.0 THEN -TMP.Anfangsbestand      -- Passivkonto sollte nicht als minus ausgegeben werden
                       ELSE TMP.Anfangsbestand
                     END,
    Endbestand     = CASE
                       WHEN TMP.KbKontoklasseCodeSub = 6 AND ISNULL(TMP.Endbestand, 0.0) <> 0.0 THEN -TMP.Endbestand              -- Passivkonto sollte nicht als minus ausgegeben werden
                       ELSE TMP.Endbestand
                     END,
    TMP.Zuwachs,
    TMP.Abgang,

    TMP.Umsatz,
    TMP.Saldo,
    TMP.Vorsaldo,
    TMP.Total,
    IconIndex = CASE WHEN TMP.Kontogruppe = 1 THEN 1 ELSE 0 END,
    BilanzER  = CASE @BilanzErCode 
                  WHEN 1 THEN 'Bilanz'
                  WHEN 2 THEN 'Erfolgsrechnung'
                  ELSE 'Bilanz/Erfolgsrechnung'
                END
  FROM @tmpOutput TMP
  ORDER BY SortKey1, SortKey2, SortKey3 DESC, SortKey4, SortKey5;
END;
GO