SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetMyKiSSData
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaGetMyKiSSData.sql $
  $Author: rcxp $
  $Modtime: 7.01.10 9:00 $
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get all required data for My KiSS form
    @UserID:       The userid to use for filtering
    @LanguageCode: The language code to use for multilanguage values
    @Date:         The specific date to use for filtering (if NULL, current date will be uses)
    @ResultTable:  The desired result to display for data-output
                   - 'abmachungen'          = data from FaAbmachungen with specified filters
                   - 'zielvereinbarungen'   = data from FaLeistung for SB/CM
                   - 'vollmachten'          = data from BaPerson/FaLeistung
                   - 'gesuchverwaltung'     = data from GvGesuch
                   - 'unerledigteAuflagen'  = data from GvAuflage
  -
  RETURNS: The desired data for given parameters
  -
  TEST:    EXEC dbo.spFaGetMyKiSSData 2, 1, NULL, '--'
           -- valid entries
           EXEC dbo.spFaGetMyKiSSData 2, 1, NULL, 'abmachungen'
           EXEC dbo.spFaGetMyKiSSData 2, 1, NULL, 'zielvereinbarungen'
           EXEC dbo.spFaGetMyKiSSData 2, 1, NULL, 'vollmachten'
           EXEC dbo.spFaGetMyKiSSData 2, 1, NULL, 'gesuchverwaltung' 
           EXEC dbo.spFaGetMyKiSSData 2, 1, NULL, 'unerledigteAuflagen' 
           --
           EXEC dbo.spFaGetMyKiSSData 479, 1, NULL, 'abmachungen'
           EXEC dbo.spFaGetMyKiSSData 479, 1, NULL, 'zielvereinbarungen'
           EXEC dbo.spFaGetMyKiSSData 479, 1, NULL, 'vollmachten'
           EXEC dbo.spFaGetMyKiSSData 479, 1, NULL, 'gesuchverwaltung'
           EXEC dbo.spFaGetMyKiSSData 479, 1, NULL, 'unerledigteAuflagen'
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaGetMyKiSSData.sql $
 * 
 * 8     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 7     4.06.09 15:00 Cjaeggi
 * #4743: Filter only specified document types
 * 
 * 6     19.03.09 9:41 Cjaeggi
 * Fixed date-border <=
 * 
 * 5     19.03.09 9:28 Cjaeggi
 * ##4159: Changed date-border to future date
 * 
 * 4     17.03.09 11:13 Cjaeggi
 * Added more tests
 * 
 * 3     16.03.09 13:40 Cjaeggi
 * Added vollmachten, finanzgesuche, fixed bug with languagecode
 * 
 * 2     25.02.09 15:37 Cjaeggi
 * Added Zielvereinbarung entries
 * 
 * 1     17.02.09 15:18 Cjaeggi
 * New stored procedure for MyKiSS
=================================================================================================*/

CREATE PROCEDURE dbo.spFaGetMyKiSSData
(
  @UserID INT,
  @LanguageCode INT,
  @Date DATETIME,
  @ResultTable VARCHAR(20)
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @DatePlus30Days DATETIME
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  -- validate parameters
  IF (ISNULL(@UserID, -1) < 1 OR @ResultTable NOT IN ('abmachungen', 'zielvereinbarungen', 'vollmachten', 'gesuchverwaltung', 'unerledigteAuflagen'))
  BEGIN
    -- do not continue
    RAISERROR ('Error: Invalid UserID (''%d'') and/or ResultTable (''%s''), cannot continue!', 18, 1, @UserID, @ResultTable)
    RETURN
  END
  
  -- set default values to var
  SET @LanguageCode   = ISNULL(@LanguageCode, 1)
  SET @Date           = dbo.fnDateOf(ISNULL(@Date, GETDATE())) -- only date without time!
  SET @DatePlus30Days = DATEADD(day, 30, @Date)
  
  -- info
  PRINT ('start output for <' + @ResultTable + '> with parameters @Date=' + CONVERT(VARCHAR, @Date, 113) + ', @LanguageCode=' + CONVERT(VARCHAR, @LanguageCode) + ', @DatePlus30Days=' + CONVERT(VARCHAR, @DatePlus30Days, 113) + ': ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  
  -------------------------------------------------------------------------------
  -- output 'abmachungen'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'abmachungen')
  BEGIN
    -- get data
    SELECT FaAbmachungenID = FAA.FaAbmachungenID,
           BaPersonID      = PRS.BaPersonID,
           Klient          = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', ''),
           Termin          = FAA.PerDatum,
           Stichworte      = FAA.Stichworte
    FROM dbo.FaAbmachungen FAA WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAA.BaPersonID
    WHERE FAA.UserID = @UserID AND              -- only where current user is author
          FAA.PerDatum <= @DatePlus30Days AND   -- only those where PerDatum is before date border date (those who are expired+30d)
          FAA.Erledigt = 0                      -- only those who are not already done
    ORDER BY Termin, Klient, Stichworte
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113))
    
    -- done
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- output 'zielvereinbarungen'
  -------------------------------------------------------------------------------
  ELSE IF (@ResultTable = 'zielvereinbarungen')
  BEGIN
    -- init temporary table for all clients
    DECLARE @TmpBaPersonIDs TABLE
    (
      BaPersonID INT NOT NULL PRIMARY KEY,
      AnzRZSB INT,
      AnzRZSBFaellig INT,
      AnzRZCM INT,
      AnzRZCMFaellig INT,
      AnzHZSB INT,
      AnzHZSBFaellig INT,
      AnzHZCM INT,
      AnzHZCMFaellig INT,
      AnzMNSB INT,
      AnzMNSBFaellig INT,
      AnzMNCM INT,
      AnzMNCMFaellig INT
    )
    
    -- fill temporary table
    INSERT INTO @TmpBaPersonIDs (BaPersonID)
      SELECT DISTINCT
             LEI.BaPersonID
      FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
      WHERE LEI.UserID = @UserID AND    -- only where current user is responsible
            LEI.ModulID IN (3, 4) AND   -- only for SB=3 and/or CM=4
            LEI.DatumBis IS NULL        -- only open items
            
    -- get temporary table
    UPDATE TMP
    SET -- RZ
        TMP.AnzRZSB        = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 3, TMP.BaPersonID, 1, 0),
        TMP.AnzRZSBFaellig = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 3, TMP.BaPersonID, 1, 1),
        TMP.AnzRZCM        = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 4, TMP.BaPersonID, 1, 0),
        TMP.AnzRZCMFaellig = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 4, TMP.BaPersonID, 1, 1),
        -- HZ
        TMP.AnzHZSB        = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 3, TMP.BaPersonID, 2, 0),
        TMP.AnzHZSBFaellig = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 3, TMP.BaPersonID, 2, 1),
        TMP.AnzHZCM        = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 4, TMP.BaPersonID, 2, 0),
        TMP.AnzHZCMFaellig = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 4, TMP.BaPersonID, 2, 1),
        -- MN
        TMP.AnzMNSB        = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 3, TMP.BaPersonID, 3, 0),
        TMP.AnzMNSBFaellig = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 3, TMP.BaPersonID, 3, 1),
        TMP.AnzMNCM        = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 4, TMP.BaPersonID, 3, 0),
        TMP.AnzMNCMFaellig = dbo.fnFaGetMyKiSSZielvereinbarungDataCount(@UserID, @Date, 4, TMP.BaPersonID, 3, 1)
    FROM @TmpBaPersonIDs TMP
    
    -- validate
    IF (EXISTS(SELECT TOP 1 1
               FROM @TmpBaPersonIDs TMP
               WHERE TMP.AnzRZSB < 0 OR TMP.AnzRZSBFaellig < 0 OR TMP.AnzRZCM < 0 OR TMP.AnzRZCMFaellig < 0 OR
                     TMP.AnzHZSB < 0 OR TMP.AnzHZSBFaellig < 0 OR TMP.AnzHZCM < 0 OR TMP.AnzHZCMFaellig < 0 OR
                     TMP.AnzMNSB < 0 OR TMP.AnzMNSBFaellig < 0 OR TMP.AnzMNCM < 0 OR TMP.AnzMNCMFaellig < 0))
    BEGIN
      -- throw exception due to invalid data!
      RAISERROR ('Error: Invalid data for at least one entry in temporary table @TmpBaPersonIDs of ResultTable (''%s''), cannot continue!', 18, 1, @ResultTable)
      RETURN
    END
  
    -- get data
    SELECT BaPersonID   = PRS.BaPersonID,
           Klient       = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', ''),
           AnzRZ        = ISNULL(TMP.AnzRZSB, 0)        + ISNULL(TMP.AnzRZCM, 0),
           AnzRZFaellig = ISNULL(TMP.AnzRZSBFaellig, 0) + ISNULL(TMP.AnzRZCMFaellig, 0),
           AnzHZ        = ISNULL(TMP.AnzHZSB, 0)        + ISNULL(TMP.AnzHZCM, 0),
           AnzHZFaellig = ISNULL(TMP.AnzHZSBFaellig, 0) + ISNULL(TMP.AnzHZCMFaellig, 0),
           AnzMN        = ISNULL(TMP.AnzMNSB, 0)        + ISNULL(TMP.AnzMNCM, 0),
           AnzMNFaellig = ISNULL(TMP.AnzMNSBFaellig, 0) + ISNULL(TMP.AnzMNCMFaellig, 0)
    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      INNER JOIN @TmpBaPersonIDs TMP ON TMP.BaPersonID = PRS.BaPersonID
    ORDER BY Klient
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113))
    
    -- done
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- output 'vollmachten'
  -------------------------------------------------------------------------------
  ELSE IF (@ResultTable = 'vollmachten')
  BEGIN
    -- get data
    SELECT BaPersonID      = PRS.BaPersonID,
           Klient          = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', ''),
           Fallverlauf     = CONVERT(BIT, CASE WHEN LEI.DatumBis IS NULL THEN 1   -- open
                                               ELSE 0                             -- closed
                                          END)
    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2) AND   -- FV
                                                              LEI.UserID = @UserID                                                    -- only where current user is responsible for last open/closed FV
    WHERE PRS.LaufendeVollmachtErlaubnis = 1     -- only where laufende vollmacht is true
    ORDER BY Fallverlauf, Klient
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113))
    
    -- done
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- output 'gesuchverwaltung'
  -------------------------------------------------------------------------------
  ELSE IF (@ResultTable = 'gesuchverwaltung')
  BEGIN
    -- get data
    SELECT GvGesuchID         = GES.GvGesuchID,
           BaPersonID         = GES.BaPersonID,
           Klient             = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', ''),
           GesuchsDatum       = GES.GesuchsDatum,
           Fonds              = FND.NameKurz,
		   GvStatusCode		  = GES.GvStatusCode,
           BetragBewilligt    = GES.BetragBewilligt,
           BetragBeantragt    = ISNULL((SELECT SUM(APO.Betrag)
                                        FROM dbo.GvAntragPosition APO WITH (READUNCOMMITTED)
                                        WHERE APO.GvGesuchID = GES.GvGesuchID
                                          AND APO.GvAntragPositionTypCode = 2), 0.0), --2: beantragter Betrag
           DatumEntscheid     = GES.BewilligtAm,
           DatumAuszahlung    = (SELECT MAX(BUC_AUS.BelegDatum)
                                 FROM GvAuszahlungPosition GAP
                                   INNER JOIN KbBuchungKostenart BKO ON BKO.GvAuszahlungPositionID = GAP.GvAuszahlungPositionID
                                   INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = BKO.KbBuchungID
                                   INNER JOIN KbOpAusgleich AUS ON AUS.OpBuchungID = BUC.KbBuchungID
                                   INNER JOIN KbBuchung BUC_AUS ON BUC_AUS.KbBuchungID = AUS.AusgleichBuchungID
                                 WHERE GAP.GvGesuchID = GES.GvGesuchID),
           Autor              = USR.NameVorname
    FROM dbo.GvGesuch           GES WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = GES.BaPersonID
      INNER JOIN dbo.GvFonds    FND WITH (READUNCOMMITTED) ON FND.GvFondsID = GES.GvFondsID
      INNER JOIN dbo.vwUser     USR WITH (READUNCOMMITTED) ON USR.UserID = GES.XUserID_Autor
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2) -- FV
                                                          AND LEI.UserID = @UserID                                              -- only where current user is responsible for last open/closed FV
    WHERE GES.GvStatusCode <> 7 --7: Abgeschlossen
    ORDER BY GES.GvStatusCode ASC, Klient ASC, GES.GesuchsDatum DESC;
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113))
    
    -- done
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- output 'unerledigteAuflagen'
  -------------------------------------------------------------------------------
  ELSE IF (@ResultTable = 'unerledigteAuflagen')
  BEGIN
    -- get data
    ;WITH AuflageCTE AS (
        SELECT GvGesuchID           = GES.GvGesuchID,
               BaPersonID           = GES.BaPersonID,
               Klient               = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', ''),
               Fonds                = FND.NameKurz,
               Gegenstand           = AUF.Gegenstand,
               Verpflichtung        = AUF.SchriftlicheVerpflichtung,
               Betrag               = AUF.Betrag,
               Frist                = AUF.Faellig,
               IstAbgelaufen        = CASE WHEN AUF.Faellig < GETDATE() THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END,
               AnzahlTageBisFaellig = DATEDIFF(day, GETDATE(), AUF.Faellig)
        FROM dbo.GvAuflage          AUF WITH (READUNCOMMITTED)
          INNER JOIN dbo.GvGesuch   GES WITH (READUNCOMMITTED) ON GES.GvGesuchID = AUF.GvGesuchID
          INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = GES.BaPersonID
          INNER JOIN dbo.GvFonds    FND WITH (READUNCOMMITTED) ON FND.GvFondsID = GES.GvFondsID
          INNER JOIN dbo.vwUser     USR WITH (READUNCOMMITTED) ON USR.UserID = GES.XUserID_Autor
          INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2) -- FV
                                                              AND LEI.UserID = @UserID                                              -- only where current user is responsible for last open/closed FV
        WHERE AUF.Erledigt = 0 AND AUF.Erlassen = 0
    )
    SELECT 
      GvGesuchID,
      BaPersonID,
      Klient,
      Fonds,
      Gegenstand,
      Verpflichtung,
      Betrag,
      Frist
    FROM AuflageCTE
    ORDER BY IstAbgelaufen DESC, --Zuerst die abgelaufenen, dann die nicht abgelaufenen
             CASE
               WHEN IstAbgelaufen = 1 THEN AnzahlTageBisFaellig   --bei den abgelaufenen: die am längsten abgelaufenen zuerst
               ELSE -AnzahlTageBisFaellig  --bei den nicht abgelaufenen: diejenigen mit der längsten Laufzeit zuerst
             END; 

    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113))
    
    -- done
    RETURN
  END  
END
GO



