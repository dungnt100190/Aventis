SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject spBFSDossier_Create;
GO
/*===============================================================================================
  $Revision: 24 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/
CREATE PROCEDURE dbo.spBFSDossier_Create
(
    @Jahr         INT,
    @FaLeistungID INT,
    @BaPersonID   INT,
    @ModulID      INT,
    @DatumVon     DATETIME,
    @DatumBis     DATETIME,
    @Stichtag     BIT = 1,
    @LaufNr       INT = NULL
)
AS 
BEGIN
  DECLARE @BFSDossierID INT;
  DECLARE @Debug INT;
  DECLARE @BaPersonID_Cursor INT;

  -- Debuginformationen
  SET @Debug = 0;

  IF (@Debug = 1)
  BEGIN
    PRINT 'spBFSDossier_Create, Jahr = ' + STR(@Jahr) + 
          ', FaLeistungID = ' + STR(@FaLeistungID) + 
          ', BaPersonID = ' + STR(@BaPersonID) + 
          ', ModulID = ' + STR(@ModulID) + 
          ', Stichtag = ' + STR(@Stichtag) +
          ', LaufNr = ' + STR(@LaufNr);
  END;
    
  -- Erhebungsjahr bestimmen
  DECLARE @Erhebungsjahr INT;
  SET @Erhebungsjahr = ISNULL(@Jahr, CONVERT(INT, dbo.fnXConfig('System\Sostat\Erhebungsjahr', GETDATE())));
  
  SET @LaufNr = ISNULL(@LaufNr, 0);

  -- Katalogversion bestimmen
  DECLARE @KatalogVersionID INT;
  SET @KatalogVersionID = dbo.fnBFSGetKatalogVersion(@Erhebungsjahr);

  IF @KatalogVersionID IS NULL
  BEGIN
    RAISERROR('@KatalogVersionID ist nicht definiert', 18, 1);
    RETURN -1;
  END;
  
  -- Prüfen, ob es nicht schon ein Dossier gibt für diese Leistung und diese LaufNr
  IF (EXISTS (
    SELECT TOP 1 1
    FROM dbo.BFSDossier               DOS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID
    WHERE DOS.Jahr        = @Erhebungsjahr
      AND DOS.Stichtag    = @Stichtag
      AND DOS.LaufNr      = @LaufNr
      AND DOP.BaPersonID  = @BaPersonID
      AND DOP.PersonIndex = 0
  ))
  BEGIN
    DECLARE @Error VARCHAR(500);
    SET @Error = CASE
                   WHEN @Stichtag = 0 THEN 'Anfangszustands-Dossier'
                   ELSE 'Stichtags-Dossier'
                 END +
                 ' für Antragssteller ' +
                 CONVERT(VARCHAR(15), @BaPersonID) + ' und LaufNr ' + 
                 CONVERT(VARCHAR(10), @LaufNr) + ' existiert bereits für das Jahr ' +
                 CONVERT(VARCHAR(10), @Erhebungsjahr);
    RAISERROR(@Error, 18, 1);
    RETURN -1;
  END;

  -- ProzessCode der Leistung holen
  DECLARE @ProzessCode INT;
  DECLARE @UserID INT;
  DECLARE @GemeindeCode INT;
  DECLARE @BFSLeistungsartCode INT;

  SELECT 
    @ProzessCode = LEI.FaProzessCode,
    @UserID = LEI.UserID,
    @GemeindeCode = LEI.GemeindeCode,
    @BFSLeistungsartCode = ISNULL(dbo.fnBFSCode('FaProzess', LEI.FaProzessCode),
                                  dbo.fnBFSGetLeistungsartCode(LEI.FaProzessCode, LEI.FaLeistungID))
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.FaLeistungID = @FaLeistungID;
  
    -- Fallback, falls GemeindeCode NULL ist - wenn es nur einen Kandidaten gibt, wird dieser verwendet
  IF (@GemeindeCode IS NULL)
  BEGIN
    SELECT @GemeindeCode = MIN(Code)
    FROM dbo.XLOVCode WITH(READUNCOMMITTED)
    WHERE LOVName = 'GemeindeSozialdienst'
    GROUP BY LOVName
    HAVING COUNT(*) = 1;
  END;

  -- BFS Dossier erzeugen
  INSERT INTO dbo.BFSDossier (
    Jahr, Stichtag, BFSKatalogVersionID, 
    BFSLeistungsartCode, FaLeistungID, UserID,
    DatumVon, DatumBis, ImportDatum,
    ZustaendigeGemeinde, LaufNr
  )
  VALUES ( 
    @Erhebungsjahr, @Stichtag, @KatalogVersionID,
    @BFSLeistungsartCode, @FaLeistungID, @UserID,
    @DatumVon, @DatumBis, GETDATE(),
    dbo.fnBFSCode('GemeindeSozialdienst', @GemeindeCode), @LaufNr
  );

  -- neue BFSDossierID holen
  SET @BFSDossierID = SCOPE_IDENTITY();

  -- Debuginformationen
  IF (@Debug = 1)
  BEGIN
    PRINT ('BFSLeistungsartCode = ' + STR(@BFSLeistungsartCode) + ', BFSDossierID = ' + STR(@BFSDossierID));
  END;

  IF (@BFSLeistungsartCode IN (1, 2))
  BEGIN  
    -- ******************************************************
    -- Sozialhilfe
    -- ******************************************************
    DECLARE @BFSPersonCode INT;

    -- Person in BFSDossierPerson abfüllen, 
    -- mindestens 1 Person muss vorhanden sein
    IF NOT EXISTS (SELECT TOP 1 1
                   FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                   WHERE BFSDossierID = @BFSDossierID
                     AND BFSPersonCode = 1)
    BEGIN
      INSERT INTO dbo.BFSDossierPerson(BFSDossierID, BFSPersonCode, PersonIndex, BaPersonID)
      VALUES (@BFSDossierID, 1, 0, @BaPersonID);
    END
    ELSE
    BEGIN
      UPDATE DOS
      SET BaPersonID = @BaPersonID
      FROM dbo.BFSDossierPerson DOS
      WHERE DOS.BFSDossierID = @BFSDossierID
        AND DOS.BFSPersonCode = 1;
    END;

    -- Personen des letzten Finanzplans des Antragsstellers einfügen
    DECLARE cBgFinanzplanBaPerson CURSOR FAST_FORWARD FOR
    SELECT
      FPP.BaPersonID,
      BFSPersonCode = CASE 
                        WHEN FPP.IstUnterstuetzt = 1 THEN 2 
                        ELSE 3 
                      END
    FROM dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) 
    WHERE FPP.BgFinanzplanID = (SELECT TOP 1 BgFinanzplanID -- Selektiere den neuesten Finanzplan des Antragsstellers, der am nächsten am Enddatum des Dossiers liegt
                                FROM dbo.BgFinanzplan       FIP WITH (READUNCOMMITTED)
                                  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FIP.FaLeistungID
                                WHERE LEI.BaPersonID = @BaPersonID
                                ORDER BY ABS(DATEDIFF(DAY, ISNULL(FIP.DatumVon, FIP.GeplantVon), @DatumBis))); -- Suche kleinste Differenz zwischen Enddatum Dossier und Finanzplan-Start

    OPEN cBgFinanzplanBaPerson;

    WHILE (1 = 1)  
    BEGIN
      FETCH NEXT
      FROM cBgFinanzplanBaPerson
      INTO @BaPersonID_Cursor, @BFSPersonCode;

      IF (@@FETCH_STATUS < 0)
      BEGIN
        BREAK;
      END;

      IF NOT EXISTS (SELECT TOP 1 1
                     FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                     WHERE BFSDossierID = @BFSDossierID
                       AND BaPersonID = @BaPersonID_Cursor)
      BEGIN
        INSERT INTO dbo.BFSDossierPerson (BFSDossierID, BaPersonID, BFSPersonCode, PersonIndex)
        SELECT 
          @BFSDossierID,
          @BaPersonID_Cursor,
          @BFSPersonCode,
          PersonIndex = ISNULL(MAX(PersonIndex), 0) + 1
        FROM dbo.BFSDossierPerson
        WHERE BFSDossierID = @BFSDossierID
          AND BFSPersonCode = @BFSPersonCode;
      END;
    END; -- OF WHILE

    CLOSE cBgFinanzplanBaPerson;
    DEALLOCATE cBgFinanzplanBaPerson;
  END -- [Sozialhilfe]
  ELSE 
  BEGIN
    -- ******************************************************
    -- Inkasso
    -- ******************************************************
    
    -- Gläubiger
    -- ------------------------------------------------------
    DECLARE cGlaeubigerBaPerson CURSOR FAST_FORWARD FOR
    SELECT
      GLB.BaPersonID,
      BFSPersonCode = CASE 
                        WHEN GLB.BaPersonID = @BaPersonID THEN 1 
                        ELSE 2 
                      END
    FROM dbo.FaLeistung LST WITH (READUNCOMMITTED)
      INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.FaLeistungID = LST.FaLeistungID
      INNER JOIN dbo.IkGlaeubiger GLB WITH (READUNCOMMITTED) ON GLB.IkRechtstitelID = RTT.IkRechtstitelID
      INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = GLB.BaPersonID
    WHERE LST.FaLeistungID = @FaLeistungID;

    OPEN cGlaeubigerBaPerson;
    
    WHILE (1 = 1)  
    BEGIN
      FETCH NEXT
      FROM cGlaeubigerBaPerson
      INTO @BaPersonID_Cursor, @BFSPersonCode;

      IF (@@FETCH_STATUS < 0)
      BEGIN
        BREAK;
      END;

      IF NOT EXISTS (SELECT TOP 1 1
                     FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                     WHERE BFSDossierID = @BFSDossierID
                       AND BaPersonID = @BaPersonID_Cursor)
      BEGIN
        INSERT INTO dbo.BFSDossierPerson (BFSDossierID, BaPersonID, BFSPersonCode, PersonIndex)
        SELECT
          @BFSDossierID,
          @BaPersonID_Cursor,
          @BFSPersonCode,
          PersonIndex = CASE
                          WHEN @BFSPersonCode = 1 THEN 0
                          ELSE ISNULL(MAX(PersonIndex), 0) + 1
                        END
        FROM dbo.BFSDossierPerson
        WHERE BFSDossierID = @BFSDossierID 
          AND BFSPersonCode = @BFSPersonCode;
      END; -- [IF NOT EXISTS]
    END; -- [OF WHILE]

    CLOSE cGlaeubigerBaPerson;
    DEALLOCATE cGlaeubigerBaPerson;

    -- ALBV
    -- ------------------------------------------------------
    IF (@BFSLeistungsartCode = 25) -- ALBV 
    BEGIN 
      -- Debuginformationen
      IF (@Debug = 1)
      BEGIN
        PRINT ('ALBV, Mutter einfügen ' + STR(@BFSDossierID) + ', Person ' + STR(@BaPersonID));
      END;
      
      -- Mutter in Haushalt aufnehmen (falls noch nicht vorhanden)
      IF NOT EXISTS (SELECT TOP 1 1
                     FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                     WHERE BFSDossierID = @BFSDossierID
                       AND BaPersonID = @BaPersonID) 
      BEGIN
        INSERT INTO dbo.BFSDossierPerson (BFSDossierID, BaPersonID, BFSPersonCode, PersonIndex)
        VALUES (@BFSDossierID, @BaPersonID, 1, 0);
      END; -- IF NOT EXISTS
    END; -- ALBV

    -- KKBB
    -- ------------------------------------------------------
    IF (@BFSLeistungsartCode = 23) -- KKBB
    BEGIN  
      -- Debuginformationen
      IF (@Debug = 1)
      BEGIN
        PRINT ('KKBB, BFSDossierID = ' + STR(@BFSDossierID));
      END;
      
      -- Bei KKBB ist die Mutter die Leistungsträgerin -> aufnehmen!
      IF NOT EXISTS (SELECT TOP 1 1
                     FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                     WHERE BFSDossierID = @BFSDossierID
                       AND BaPersonID = @BaPersonID)
      BEGIN
        IF (@Debug = 1)
        BEGIN
          PRINT ('KKBB, Mutter einfügen ' + STR(@BFSDossierID) + ', Person ' + STR(@BaPersonID));
        END;
          
        INSERT INTO dbo.BFSDossierPerson (BFSDossierID, BaPersonID, BFSPersonCode, PersonIndex)
        VALUES (@BFSDossierID, @BaPersonID, 1, 0);
      END;

      -- übrige Personen aus dem Klientensystem, 
      -- die in letzter Wohnsituation enthalten sind, in Haushalt aufnehmen 
      DECLARE cWohnsituationBaPerson CURSOR FAST_FORWARD FOR
        SELECT WSP2.BaPersonID
        FROM dbo.BFSDossierPerson              DP  WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaWohnsituationPerson WSP WITH (READUNCOMMITTED) ON WSP.BaPersonID = DP.BaPersonID
          INNER JOIN dbo.BaWohnsituation       WS  WITH (READUNCOMMITTED) ON WS.BaWohnsituationID = WSP.BaWohnsituationID
                                                                         AND DatumVon = (SELECT MAX(WS.DatumVon)
                                                                                         FROM dbo.BFSDossierPerson              DP  WITH (READUNCOMMITTED)
                                                                                           INNER JOIN dbo.BaWohnsituationPerson WSP WITH (READUNCOMMITTED) ON WSP.BaPersonID = DP.BaPersonID
                                                                                           INNER JOIN dbo.BaWohnsituation       WS  WITH (READUNCOMMITTED) ON WS.BaWohnsituationID = WSP.BaWohnsituationID
                                                                                         WHERE DP.BFSDossierID = @BFSDossierID)
          INNER JOIN dbo.BaWohnsituationPerson WSP2 WITH (READUNCOMMITTED) ON WSP.BaWohnsituationID = WSP2.BaWohnsituationID
                                                                          AND WSP.BaPersonID <> WSP2.BaPersonID 
        WHERE DP.BFSDossierID = @BFSDossierID;

      OPEN cWohnsituationBaPerson;
      
      WHILE (1 = 1)  
      BEGIN
        FETCH NEXT
        FROM cWohnsituationBaPerson
        INTO @BaPersonID;
        
        IF (@@FETCH_STATUS < 0)
        BEGIN
          BREAK;
        END;

        -- Debuginformationen
        IF (@Debug = 1)
        BEGIN
          PRINT ('Wohnsituation, BaPersonID = ' + STR(@BaPersonID));
        END;

        IF NOT EXISTS (SELECT TOP 1 1
                       FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                       WHERE BFSDossierID = @BFSDossierID 
                         AND BaPersonID = @BaPersonID)
        BEGIN
          -- Debuginformationen
          IF (@Debug = 1)
          BEGIN
            PRINT ('Insert BFSDossierPerson, BFSDossierID = ' + STR(@BFSDossierID) + ', BaPersonID = ' + STR(@BaPersonID));
          END;
            
          -- Einfügen
          INSERT INTO dbo.BFSDossierPerson (BFSDossierID, BaPersonID, BFSPersonCode, PersonIndex)
            SELECT
              @BFSDossierID,
              @BaPersonID,
              2,
              PersonIndex = ISNULL(MAX(PersonIndex), 0) + 1 
            FROM dbo.BFSDossierPerson
            WHERE BFSDossierID = @BFSDossierID
              AND BFSPersonCode = 2;
        END; -- [IF NOT EXISTS]
      END; -- [OF WHILE]

      CLOSE cWohnsituationBaPerson;
      DEALLOCATE cWohnsituationBaPerson;

      -- Personen im Fall mit gleicher WMA auch integrieren
      DECLARE cFallPersonMitGleicherWMA CURSOR FAST_FORWARD FOR
        SELECT PRS.BaPersonID
        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
          INNER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = LEI.FaFallID
          INNER JOIN dbo.vwPerson LTP WITH (READUNCOMMITTED) ON LTP.BaPersonID = LEI.BaPersonID 
          INNER JOIN dbo.vwPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAP.BaPersonID 
                                                            AND PRS.BaPersonID <> LTP.BaPersonID 
                                                            AND PRS.Wohnsitz = LTP.Wohnsitz
        WHERE FaLeistungID = @FaLeistungID;

      OPEN cFallPersonMitGleicherWMA;

      WHILE (1 = 1)
      BEGIN
        FETCH NEXT
        FROM cFallPersonMitGleicherWMA
        INTO @BaPersonID;

        IF (@@FETCH_STATUS < 0)
        BEGIN
          BREAK;
        END;

        -- Debuginformationen
        IF (@Debug = 1)
        BEGIN
          PRINT ('Gleiche WMA, BaPersonID = ' + STR(@BaPersonID));
        END;
        
        IF (NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                        WHERE BFSDossierID = @BFSDossierID
                          AND BaPersonID = @BaPersonID))
        BEGIN
          -- Debuginformationen
          IF (@Debug = 1)
          BEGIN
            PRINT ('Insert BFSDossierPerson, BFSDossierID = ' + STR(@BFSDossierID) + ', BaPersonID = ' + STR(@BaPersonID));
          END;
          
          -- Einfügen
          INSERT INTO dbo.BFSDossierPerson (BFSDossierID, BaPersonID, BFSPersonCode, PersonIndex)
            SELECT
              @BFSDossierID,
              @BaPersonID,
              2,
              ISNULL(MAX(PersonIndex), 0) + 1 
            FROM dbo.BFSDossierPerson
          WHERE BFSDossierID = @BFSDossierID
            AND BFSPersonCode = 2;
        END; -- [IF NOT EXISTS]
      END; -- [OF WHILE]

      CLOSE cFallPersonMitGleicherWMA;
      DEALLOCATE cFallPersonMitGleicherWMA;
    END; -- [KKBB]
  END; -- [Inkasso]

  -- Namen fürs ganze Dossier einfügen
  UPDATE DOS
  SET PersonName = PRS.NameVorname
  FROM dbo.BFSDossierPerson DOS
    INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = DOS.BaPersonID
  WHERE DOS.BFSDossierID = @BFSDossierID;

  -- jetzt noch Import starten
  EXECUTE dbo.spBFSPerformImport @BFSDossierID;
END;
GO