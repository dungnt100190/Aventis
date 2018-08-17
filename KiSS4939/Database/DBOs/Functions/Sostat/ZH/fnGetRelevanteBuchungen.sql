SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetRelevanteBuchungen;
GO

/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description 
  Gibt eine Tabelle mit allen relevanten Auszahlungen (Nettobelege) zurück
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  @DatumVon:                   Start der Periode, falls null wird nach alle Buchungen vor <@DatumBis  gesucht
  @DatumBis:                   End der Periode     
  @UserID:                     Falls nicht NULL wird nur nach Buchungen in Leistungen dieses Benutzers gesucht
  @BaPersonID:                 Falls nicht NULL wird nur nach Buchungen in Leistungen dieser Person gesucht
  @LeistungsartCodes:          Kommagetrennte Liste von Leistungsart-Code : !!Nicht gebraucht als Kriterium für die Liste!!
  @OrgUnitID:                  Falls nicht NULL wird nur nach Buchungen in Leistungen von Benutzern in dieser OrgUnit gesucht
  
  TEST :
  SELECT * FROM dbo.fnGetRelevanteBuchungen('2011-07-01 00:00:00.000','2012-12-31 00:00:00.000',NULL,173681,NULL, NULL) -- <1s
  SELECT * FROM dbo.fnGetRelevanteBuchungen('2011-07-01 00:00:00.000','2012-12-31 00:00:00.000',NULL,NULL,NULL, 69)  -- 1:21
  SELECT * FROM dbo.fnGetRelevanteBuchungen('2011-07-01 00:00:00.000','2012-12-31 00:00:00.000',NULL,NULL,NULL, NULL) -- 1:24
  SELECT * FROM dbo.fnGetRelevanteBuchungen(NULL,'2012-12-31 00:00:00.000',NULL,173681,NULL, NULL)  -- <1s
  SELECT * FROM dbo.fnGetRelevanteBuchungen('2011-07-01 00:00:00.000','2012-12-31 00:00:00.000',7884,NULL,NULL, NULL)  -- <1s
  SELECT * FROM dbo.fnGetRelevanteBuchungen('2011-07-01 00:00:00.000','2012-12-31 00:00:00.000',7884, NULL, ',3,4,', NULL) -- 0s

=================================================================================================*/
CREATE FUNCTION dbo.fnGetRelevanteBuchungen
(
  @DatumVon                             DATETIME = NULL,
  @DatumBis                             DATETIME,
  @UserID                               INT = NULL,
  @BaPersonID                           INT = NULL,
  @LeistungsartCodes                    VARCHAR(200) = NULL,
  @OrgUnitID                            INT = NULL
)
RETURNS @OUTPUT TABLE 
(
  FaProzessCode   INT,
  BaPersonID      INT, -- Antraggsteller
  Ausgleichsdatum DATETIME,
  FaLeistungID    INT   -- nicht eindeutig, daher max(FaLeistungID)
  PRIMARY KEY (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID)
)
AS
BEGIN

  SET @LeistungsartCodes = ',' + ISNULL(@LeistungsartCodes, '1,2,23,25') + ',';

  IF @LeistungsartCodes like '%,1,%' OR @LeistungsartCodes like '%,2,%'
  BEGIN
    -- Datumsbereich vorbereiten
    SET @DatumVon = dbo.fnDateOf(@DatumVon);
    SET @DatumBis = DATEADD(ms, -3, DATEADD(DAY, 1, dbo.fnDateOf(@DatumBis)));

    -- Hilfstabelle mit allen durch das LA-Mapping Tool zugeordneten LA's (KontoNr)
    DECLARE @BFS_LA TABLE 
    (
      KontoNr VARCHAR(10)
      PRIMARY KEY (KontoNr)
    );

    INSERT @BFS_LA
      SELECT DISTINCT (KontoNr)
      FROM dbo.BgPositionsart      BPA WITH(READUNCOMMITTED)
        INNER JOIN dbo.BgKostenart KOA WITH(READUNCOMMITTED) ON KOA.BgKostenartID = BPA.BgKostenartID
      WHERE BPA.ErzeugtBfsDossier = 1;
    
    
    --temp FaLeistung  
    DECLARE @FaLeistung TABLE 
    (
      FaLeistungID INT
      PRIMARY KEY (FaLeistungID)
    );      
    
    INSERT INTO @FaLeistung     
      SELECT DISTINCT FaLeistungID
      FROM FaLeistung                LEI WITH(READUNCOMMITTED)
        LEFT  JOIN dbo.XOrgUnit_User O2U WITH(READUNCOMMITTED) ON O2U.UserID = LEI.UserID
      WHERE 1=1
      AND BaPersonID = ISNULL(@BaPersonID, BaPersonID)
      AND LEI.UserID = ISNULL(@UserID, LEI.UserID) 
      AND (O2U.OrgUnitID IS NULL OR O2U.OrgUnitID = ISNULL(@OrgUnitID, O2U.OrgUnitID))

    ;WITH myCte AS
    (  

      SELECT
        FaProzessCode = LEI.FaProzessCode,
        BaPersonID = LEI.BaPersonID,
        Ausgleichsdatum = ISNULL(KB2.Belegdatum, KB1.Barbelegdatum) ,  
        FaLeistungID = LEI.FaLeistungID,
        UserID = LEI.UserID,
        OrgUnitID = OE.OrgUnitID
      FROM @FaLeistung                    LEIt 
        INNER JOIN dbo.FaLeistung         LEI WITH(READUNCOMMITTED) ON (LEI.FaLeistungID = LEIt.FaLeistungID)
        INNER JOIN dbo.BgFinanzPlan       BFP WITH(READUNCOMMITTED) ON (LEI.FaLeistungID = BFP.FaLeistungID)
                                                                   AND (LEI.FaProzessCode = 300) -- 300: Wirtschaftliche Hilfe
        INNER JOIN dbo.BgBudget           BUD WITH(READUNCOMMITTED) ON (BFP.BgFinanzplanID = BUD.BgFinanzplanID)
                                                                   AND (BUD.MasterBudget = 0) -- nur Monatsbudgets
        INNER JOIN dbo.BgPosition         POS WITH(READUNCOMMITTED) ON (BUD.BgBudgetID = POS.BgBudgetID)
                                                                   AND (POS.BgKategorieCode IN (2, 100, 101)) -- 2: Ausgaben, 100: Zusätzliche Leistungen, 101: Einzelzahlung)
        INNER JOIN dbo.KbBuchungKostenart KBK WITH(READUNCOMMITTED) ON (POS.BgPositionID = KBK.BgPositionID  AND KBK.Betrag > 0)
        INNER JOIN dbo.BgKostenart        KOA WITH(READUNCOMMITTED) ON (KBK.BgKostenartID = KOA.BgKostenartID)
        INNER JOIN @BFS_LA                LA                        ON LA.KontoNr = KOA.KontoNr
        INNER JOIN dbo.KbBuchung          KB1 WITH(READUNCOMMITTED) ON (KBK.KbBuchungID = KB1.KbBuchungID)
        LEFT  JOIN dbo.KbOpAusgleich      OPA WITH(READUNCOMMITTED) ON (KB1.KbBuchungID = OPA.OpBuchungID)
        LEFT  JOIN dbo.KbBuchung          KB2 WITH(READUNCOMMITTED) ON (KB2.KbBuchungID = OPA.AusgleichBuchungID)    
        LEFT  JOIN dbo.XOrgUnit_User      OE WITH(READUNCOMMITTED)  ON (OE.UserID = LEI.UserID)   
      WHERE 1=1
        AND KBK.Betrag > 0 
      UNION       
        SELECT
          LEI.FaProzessCode,
          LEI.BaPersonID,
          MDB.BuchungsDatum,
          MDB.FaLeistungID,
          UserID =  LEI.UserID,
          OrgUnitID = OE.OrgUnitID         
          FROM MigDetailbuchung    MDB
          INNER JOIN dbo.FaLeistung  LEI ON LEI.FaLeistungID = MDB.FaLeistungID
          INNER JOIN dbo.BgKostenart KOA ON KOA.KontoNr      = MDB.KissLeistungsart
          INNER JOIN @BFS_LA         LA  ON LA.KontoNr       = KOA.KontoNr
          LEFT  JOIN dbo.XOrgUnit_User      OE WITH(READUNCOMMITTED)  ON (OE.UserID = LEI.UserID)  
        
    )
  
   INSERT @OUTPUT
    SELECT
      FaProzessCode,
      BaPersonID,
      Ausgleichsdatum,
      MAX(FaLeistungID)
    FROM myCte
    WHERE 1=1    
      AND (@DatumVon IS NULL OR Ausgleichsdatum >= @DatumVon)
      AND Ausgleichsdatum <= @DatumBis 
      AND BaPersonID = ISNULL(@BaPersonID, BaPersonID) 
      AND UserID = ISNULL(@UserID, UserID)      
      AND (@OrgUnitID IS NULL OR OrgUnitID = @OrgUnitID)                    
    GROUP BY
      FaProzessCode,
      BaPersonID,
      Ausgleichsdatum;   
          

  END;

  RETURN;
END;
