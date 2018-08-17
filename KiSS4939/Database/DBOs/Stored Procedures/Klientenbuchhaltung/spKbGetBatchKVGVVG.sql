SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject spKbGetBatchKVGVVG
GO
/*===============================================================================================
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to get health insurance table within control FrmBatchKVG
    @FaLeistungID: The id withing FaLeistung to process data from
    @BudgetMonth   The month of the budget to get data from
    @BudgetYear:   The year of the budget to get data from
  -
  RETURNS: Table containing data for month, budget, health insurance, person and data
  -
  TEST:    EXEC spKbGetBatchKVGVVG 60762, 11, 2007 -- from Abaci, Yilmaz (21316)
           EXEC spKbGetBatchKVGVVG 60762, NULL, NULL -- from Abaci, Yilmaz (21316)
           EXEC spKbGetBatchKVGVVG 75719, 7, 2008 -- from Sonnen, Aufgang (60732)
           EXEC spKbGetBatchKVGVVG 75719, NULL, NULL -- from Sonnen, Aufgang (60732)
           EXEC spKbGetBatchKVGVVG NULL  -- test
=================================================================================================*/

CREATE PROCEDURE dbo.spKbGetBatchKVGVVG
(
  @FaLeistungID INT,
  @BudgetMonth INT,
  @BudgetYear INT
)
AS BEGIN
--=============================================================================
  -----------------------------------------------------------------------------
  -- DEBUG
  -----------------------------------------------------------------------------
  /*
  DECLARE @FaLeistungID INT
  SET @FaLeistungID = 75719
  */
  
  -----------------------------------------------------------------------------
  -- DECLARE AND INIT VARS
  -----------------------------------------------------------------------------
  DECLARE @FaLeisungBaPersonID INT
  
  -- get person of this leistung
  SELECT TOP 1 @FaLeisungBaPersonID = FAL.BaPersonID
  FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED) 
  WHERE FAL.FaLeistungID = @FaLeistungID
  
  -----------------------------------------------------------------------------
  -- SETUP OUTPUT TABLE
  -----------------------------------------------------------------------------
  DECLARE @OUTPUT TABLE
  (
    BaPersonID             INT,
    Person                 VARCHAR(255),
    LeistungTraeger        BIT,
    BgBudgetID             INT,
    IsBudgetGray           BIT,
    IsBudgetGreen          BIT,
    Monatsbudget           DATETIME,
    Jahr                   INT,
    Monat                  INT,
    KbBuchungStatusCode    INT,
    Krankenkasse           VARCHAR(100),
    BaInstitutionID        INT,
    BetragKVG              MONEY,
    StatusKVG              INT,
    BetragKVGMax           MONEY,
    StatusKVGMax           INT,
    BetragVVG              MONEY,
    StatusVVG              INT,
    BelegID                INT,
    KbAuszahlungsArtCode   INT,
    ZahlungKVG             MONEY,
    StatusZahlungKVG       INT,
    ZahlungKVGMax          MONEY,
    StatusZahlungKVGMax    INT,
    ZahlungVVG             MONEY,
    StatusZahlungVVG       INT,
    Bemerkung              VARCHAR(5000),
    BgPositionIDKVG        INT,
    BgPositionIDKVGMax     INT,
    BgPositionIDVVG        INT,
    BgPositionsartIDKVG    INT,
    BgPositionsartIDKVGMax INT,
    BgPositionsartIDVVG    INT,
    BgSpezKontoIDKVG       INT,
    BgSpezKontoIDKVGMax    INT,
    BgSpezKontoIDVVG       INT
  )
  
  -----------------------------------------------------------------------------
  -- VALIDATE
  -----------------------------------------------------------------------------
  IF (ISNULL(@FaLeistungID, -1) < 1)
  BEGIN
    -- return just emtpy table
    SELECT *
    FROM @OUTPUT
    
    -- do not continue
    RETURN
  END
  
--=============================================================================
  
  -----------------------------------------------------------------------------
  -- KVG: INSERT VALUES INTO TEMPORARY TABLE
  -----------------------------------------------------------------------------
  INSERT INTO @OUTPUT
    SELECT BaPersonID               = BPP.BaPersonID,
           Person                   = (SELECT SUB.Name + ISNULL(', ' + SUB.Vorname, '')
                                       FROM dbo.BaPerson SUB WITH (READUNCOMMITTED)
                                       WHERE SUB.BaPersonID = BPP.BaPersonID),
           LeistungTraeger          = CASE WHEN BPP.BaPersonID = @FaLeisungBaPersonID THEN 1 
                                           ELSE 0 
                                      END,
           BgBudgetID               = BBG.BgBudgetID,
           IsBudgetGray             = CASE WHEN BBG.BgBewilligungStatusCode = 1 THEN 1 
                                           ELSE 0 
                                      END,
           IsBudgetGreen            = CASE WHEN BBG.BgBewilligungStatusCode = 5 THEN 1 
                                           ELSE 0 
                                      END,
           Monatsbudget             = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
           Jahr                     = BBG.Jahr,
           Monat                    = BBG.Monat,
           KbBuchungStatusCode      = NULL, -- update later
           Krankenkasse             = INS.[Name],
           BaInstitutionID          = BPO.BaInstitutionID,
           
           BetragKVG                = CASE WHEN (SPT.BgPositionsartCode IN (32020) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130) THEN ISNULL(BPO.BetragRechnung, $0) 
                                           ELSE $0 
                                      END, -- KVG (32020)
           StatusKVG                = CASE WHEN BBG.MasterBudget = 0 AND (SPT.BgPositionsartCode IN (32020) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130) -- KVG (32020)
                                             THEN CASE WHEN STA.Status IS NULL
                                                         THEN CASE WHEN BPO.BgKategorieCode IN (2, 100) AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Auszahlung/Zusätzliche Leistung an Spezialkonto
                                                                     THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                               ELSE 1 
                                                                          END
                                                                   WHEN BPO.BgKategorieCode = 1 AND BPO.VerwaltungSD = 0 -- nicht abgetretene Einnahmen
                                                                     THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                               ELSE 1 
                                                                          END
                                                                   ELSE CASE WHEN BPO.BgKategorieCode = 2 AND KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL -- Ausgaben an Klient (ohne tatsähliche Auszahlung)
                                                                               THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                                         ELSE 1 
                                                                                    END
                                                                             ELSE CASE BPO.BgBewilligungStatusCode WHEN 1 THEN 1   -- grau
                                                                                                                   WHEN 2 THEN 15  -- abgelehnt
                                                                                                                   WHEN 3 THEN 12  -- angefragt
                                                                                                                   WHEN 5 THEN 14  -- bewilligt
                                                                                                                   WHEN 9 THEN 7   -- gesperrt
                                                                                  END
                                                                        END
                                                              END
                                                       ELSE STA.Status
                                                  END
                                      END,
           
           BetragKVGMax             = NULL,
           StatusKVGMax             = NULL,
           
           BetragVVG                = NULL,
           StatusVVG                = NULL,
           
           -- request used BelegID of inserted entries from FrmBatchKVG, entries are connected by BgPositionID_Parent where
           -- first entry gets NULL and the following entries get the id of the first one - independent of the person then.
           BelegID                  = (SELECT TOP 1 -- expect only one id
                                              CASE WHEN SUB.BgPositionID_Parent IS NULL THEN SUB.BgPositionID
                                                   ELSE SUB.BgPositionID_Parent
                                              END
                                       FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                       INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                       WHERE SUB.BgBudgetID = BPO.BgBudgetID 
                                         AND SUB.BaPersonID = BPP.BaPersonID 
                                         AND (SPT.BgPositionsartCode IN (32020) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130) -- KVG (32020)
                                         AND SUB.BgKategorieCode = 101 -- 101=Einzelzahlung
                                         AND SUB.BgSpezkontoID IS NOT NULL),
           KbAuszahlungsArtCode    = NULL, -- update later
           
           ZahlungKVG              = NULL, -- update later
           StatusZahlungKVG        = NULL, -- update later
           ZahlungKVGMax           = NULL, -- update later
           StatusZahlungKVGMax     = NULL, -- update later
           ZahlungVVG              = NULL, -- update later
           StatusZahlungVVG        = NULL, -- update later
           
           Bemerkung               = NULL, -- update later
           
           BgPositionIDKVG         = (SELECT SUB.BgPositionID
                                      FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID
                                        AND SUB.BaPersonID = BPP.BaPersonID
                                        AND (SPT.BgPositionsartCode IN (32020) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130) -- KVG
                                        AND SUB.BgKategorieCode = 101 -- 101=Einzelzahlung
                                        AND SUB.BgSpezkontoID IS NOT NULL),
           BgPositionIDKVGMax      = NULL,
           BgPositionIDVVG         = NULL,
           
           BgPositionsartIDKVG     = (SELECT TOP 1 SUB.BgPositionsartID -- expect only one id
                                      FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID
                                        AND SUB.BaPersonID = BPP.BaPersonID
                                        AND (SPT.BgPositionsartCode IN (32020) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130) -- KVG (32020)
                                        AND SUB.BgSpezkontoID IS NOT NULL),
           BgPositionsartIDKVGMax  = NULL,
           BgPositionsartIDVVG     = NULL,
           
           BgSpezKontoIDKVG        = (SELECT TOP 1 SUB.BgSpezkontoID -- expect only one id
                                      FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID
                                        AND SUB.BaPersonID = BPP.BaPersonID
                                        AND SUB.BgKategorieCode = 2
                                        AND (SPT.BgPositionsartCode IN (32020) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130)-- KVG (32020)
                                        AND SUB.BgSpezkontoID IS NOT NULL),
           BgSpezKontoIDKVGMax     = NULL,
           BgSpezKontoIDVVG        = NULL
    
    FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID = FAL.FaLeistungID
      INNER JOIN dbo.BgBudget              BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID 
                                                                     AND (@BudgetMonth IS NULL OR BBG.Monat = @BudgetMonth) 
                                                                     AND (@BudgetYear IS NULL OR BBG.Jahr = @BudgetYear)
      INNER JOIN dbo.BgFinanzplan_BaPerson BPP WITH (READUNCOMMITTED) ON BPP.BgFinanzplanID =  BBG.BgFinanzplanID
      LEFT  JOIN dbo.vwBgPosition          BPO                        ON BPO.BgBudgetID = BBG.BgBudgetID 
                                                                     AND BPO.BaPersonID = BPP.BaPersonID 
                                                                     AND BPO.BgSpezkontoID IS NOT NULL
      LEFT  JOIN dbo.BgPositionsart        SPT                        ON SPT.BgPositionsartID = BPO.BgPositionsartID 
                                                                     AND (SPT.BgPositionsartCode IN (32020) OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130) -- KVG (32020)
      LEFT  JOIN dbo.BaInstitution         INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPO.BaInstitutionID

      LEFT  JOIN dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID 
                                                                     AND BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                                                     FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                                                                                                     WHERE  BgPositionID = BPO.BgPositionID
                                                                                                     ORDER BY CASE WHEN BaPersonID IS NULL THEN 1
                                                                                                                   WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                                                   ELSE 3
                                                                                                              END)
      LEFT  JOIN dbo.vwKreditor            KRE                        ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
      LEFT  JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FAL.FaLeistungID AND ARC.CheckOut IS NULL
      LEFT  JOIN (SELECT BUC.BgBudgetID,
                         BUK.BgPositionID,
                         Status = MAX(BUC.KbBuchungStatusCode)
                  FROM dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                  GROUP BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BBG.BgBudgetID 
                                                                AND STA.BgPositionID = BPO.BgPositionID
    
    WHERE FAL.FaLeistungID = @FaLeistungID 
      AND ARC.FaLeistungID IS NULL -- Fall darf abgeschlossen sein, aber nicht archiviert!
      AND BFP.BgBewilligungStatusCode >= 5 
      AND BPP.IstUnterstuetzt = 1 
      AND BBG.MasterBudget = 0 
      AND BPO.BgKategorieCode = 2 -- 2=Ausgaben
          
  -----------------------------------------------------------------------------
  -- KVG-MAX: INSERT VALUES INTO TEMPORARY TABLE
  -----------------------------------------------------------------------------
  INSERT INTO @OUTPUT
    SELECT BaPersonID               = BPP.BaPersonID,
           Person                   = (SELECT SUB.Name + ISNULL(', ' + SUB.Vorname, '')
                                       FROM dbo.BaPerson SUB WITH (READUNCOMMITTED)
                                       WHERE SUB.BaPersonID = BPP.BaPersonID),
           LeistungTraeger          = CASE WHEN BPP.BaPersonID = @FaLeisungBaPersonID THEN 1 
                                           ELSE 0 
                                      END,
           BgBudgetID               = BBG.BgBudgetID,
           IsBudgetGray             = CASE WHEN BBG.BgBewilligungStatusCode = 1 THEN 1 
                                           ELSE 0 
                                      END,
           IsBudgetGreen            = CASE WHEN BBG.BgBewilligungStatusCode = 5 THEN 1 
                                           ELSE 0 
                                      END,
           Monatsbudget             = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
           Jahr                     = BBG.Jahr,
           Monat                    = BBG.Monat,
           KbBuchungStatusCode      = NULL, -- update later
           Krankenkasse             = INS.[Name],
           BaInstitutionID          = BPO.BaInstitutionID,
           
           BetragKVG                = NULL,
           StatusKVG                = NULL,
           
           BetragKVGMax             = CASE WHEN SPT.BgPositionsartCode IN (32023, 32024) THEN ISNULL(BPO.BetragRechnung, $0) 
                                           ELSE $0 
                                      END, -- KVG-Max (32023="KVG - GBL"; 32024="KVG - SIL")
           StatusKVGMax             = CASE WHEN BBG.MasterBudget = 0 AND SPT.BgPositionsartCode IN (32023, 32024) -- KVG-Max (32023="KVG - GBL"; 32024="KVG - SIL")
                                             THEN CASE WHEN STA.Status IS NULL
                                                         THEN CASE WHEN BPO.BgKategorieCode IN (2, 100) AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Auszahlung/Zusätzliche Leistung an Spezialkonto
                                                                     THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                               ELSE 1 
                                                                          END
                                                                   WHEN BPO.BgKategorieCode = 1 AND BPO.VerwaltungSD = 0 -- nicht abgetretene Einnahmen
                                                                     THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                               ELSE 1 
                                                                          END
                                                                   ELSE CASE WHEN BPO.BgKategorieCode = 2 AND KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL -- Ausgaben an Klient (ohne tatsähliche Auszahlung)
                                                                               THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                                         ELSE 1 
                                                                                    END
                                                                             ELSE CASE BPO.BgBewilligungStatusCode WHEN 1 THEN 1   -- grau
                                                                                                                   WHEN 2 THEN 15  -- abgelehnt
                                                                                                                   WHEN 3 THEN 12  -- angefragt
                                                                                                                   WHEN 5 THEN 14  -- bewilligt
                                                                                                                   WHEN 9 THEN 7   -- gesperrt
                                                                                  END
                                                                        END
                                                              END
                                                       ELSE STA.Status
                                                  END
                                      END,
           
           BetragVVG                = NULL,
           StatusVVG                = NULL,
           
           -- request used BelegID of inserted entries from FrmBatchKVG, entries are connected by BgPositionID_Parent where
           -- first entry gets NULL and the following entries get the id of the first one - independent of the person then.
           BelegID                  = (SELECT TOP 1 -- expect only one id
                                              CASE WHEN SUB.BgPositionID_Parent IS NULL THEN SUB.BgPositionID
                                                   ELSE SUB.BgPositionID_Parent
                                              END
                                       FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                       INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                       WHERE SUB.BgBudgetID = BPO.BgBudgetID
                                         AND SUB.BaPersonID = BPP.BaPersonID
                                         AND SPT.BgPositionsartCode IN (32023, 32024)-- KVG-Max (32023="KVG - GBL"; 32024="KVG - SIL")
                                         AND SUB.BgKategorieCode = 101 -- 101=Einzelzahlung
                                         AND SUB.BgSpezkontoID IS NOT NULL), 
           KbAuszahlungsArtCode    = NULL, -- update later
           
           ZahlungKVG              = NULL, -- update later
           StatusZahlungKVG        = NULL, -- update later
           ZahlungKVGMax           = NULL, -- update later
           StatusZahlungKVGMax     = NULL, -- update later
           ZahlungVVG              = NULL, -- update later
           StatusZahlungVVG        = NULL, -- update later
           
           Bemerkung               = NULL, -- update later
           
           BgPositionIDKVG         = NULL,
           BgPositionIDKVGMax      = (SELECT TOP 1 SUB.BgPositionID -- expect only one id
                                      FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID
                                        AND SUB.BaPersonID = BPP.BaPersonID
                                        AND SPT.BgPositionsartCode IN (32023, 32024) -- KVG-Max (32023="KVG - GBL"; 32024="KVG - SIL")
                                        AND SUB.BgKategorieCode = 101-- 101=Einzelzahlung
                                        AND SUB.BgSpezkontoID IS NOT NULL), 
           BgPositionIDVVG         = NULL,
           
           BgPositionsartIDKVG     = NULL,
           BgPositionsartIDKVGMax  = (SELECT TOP 1 SUB.BgPositionsartID -- expect only one id
                                      FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID
                                       AND  SUB.BaPersonID = BPP.BaPersonID
                                       AND  SPT.BgPositionsartCode IN (32023, 32024) -- KVG-Max (32023="KVG - GBL"; 32024="KVG - SIL")
                                       AND  SUB.BgSpezkontoID IS NOT NULL),
           BgPositionsartIDVVG     = NULL,
           
           BgSpezKontoIDKVG        = NULL,
           BgSpezKontoIDKVGMax     = (SELECT TOP 1 SUB.BgSpezkontoID -- expect only one id
                                      FROM dbo.BgPosition       SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID
                                        AND SUB.BaPersonID = BPP.BaPersonID
                                        AND SUB.BgKategorieCode = 2
                                        AND SPT.BgPositionsartCode IN (32023, 32024) -- KVG-Max (32023="KVG - GBL"; 32024="KVG - SIL")
                                        AND SUB.BgSpezkontoID IS NOT NULL), 
           BgSpezKontoIDVVG        = NULL
    
    FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID = FAL.FaLeistungID
      INNER JOIN dbo.BgBudget              BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID 
                                                                     AND (@BudgetMonth IS NULL OR BBG.Monat = @BudgetMonth) 
                                                                     AND (@BudgetYear IS NULL OR BBG.Jahr = @BudgetYear)
      INNER JOIN dbo.BgFinanzplan_BaPerson BPP WITH (READUNCOMMITTED) ON BPP.BgFinanzplanID =  BBG.BgFinanzplanID
      LEFT  JOIN dbo.vwBgPosition          BPO                        ON BPO.BgBudgetID = BBG.BgBudgetID
                                                                     AND BPO.BaPersonID = BPP.BaPersonID
                                                                     AND BPO.BgSpezkontoID IS NOT NULL
      LEFT  JOIN dbo.BgPositionsart        SPT                        ON SPT.BgPositionsartID = BPO.BgPositionsartID 
                                                                     AND SPT.BgPositionsartCode IN (32023, 32024) -- KVG-Max (32023="KVG - GBL"; 32024="KVG - SIL")
      LEFT  JOIN dbo.BaInstitution         INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPO.BaInstitutionID

      LEFT  JOIN dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID
                                                                     AND BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                                                     FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                                                                                                     WHERE  BgPositionID = BPO.BgPositionID
                                                                                                     ORDER BY CASE WHEN BaPersonID IS NULL THEN 1
                                                                                                                   WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                                                   ELSE 3
                                                                                                              END)
      LEFT  JOIN dbo.vwKreditor            KRE                        ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
      LEFT  JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FAL.FaLeistungID AND ARC.CheckOut IS NULL
      LEFT  JOIN (SELECT BUC.BgBudgetID,
                         BUK.BgPositionID,
                         Status = MAX(BUC.KbBuchungStatusCode)
                  FROM dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                  GROUP BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BBG.BgBudgetID 
                                                                AND STA.BgPositionID = BPO.BgPositionID
    
    WHERE FAL.FaLeistungID = @FaLeistungID 
      AND ARC.FaLeistungID IS NULL -- Fall darf abgeschlossen sein, aber nicht archiviert!
      AND BFP.BgBewilligungStatusCode >= 5 
      AND BPP.IstUnterstuetzt = 1 
      AND BBG.MasterBudget = 0 
      AND BPO.BgKategorieCode = 2 -- 2=Ausgaben
  
  -----------------------------------------------------------------------------
  -- VVG: INSERT VALUES INTO TEMPORARY TABLE
  -----------------------------------------------------------------------------
  INSERT INTO @OUTPUT
    SELECT BaPersonID               = BPP.BaPersonID,
           Person                   = (SELECT SUB.Name + ISNULL(', ' + SUB.Vorname, '')
                                       FROM dbo.BaPerson SUB WITH (READUNCOMMITTED)
                                       WHERE SUB.BaPersonID = BPP.BaPersonID),
           LeistungTraeger          = CASE WHEN BPP.BaPersonID = @FaLeisungBaPersonID THEN 1 
                                           ELSE 0 
                                      END,
           BgBudgetID               = BBG.BgBudgetID,
           IsBudgetGray             = CASE WHEN BBG.BgBewilligungStatusCode = 1 THEN 1 
                                           ELSE 0 
                                      END,
           IsBudgetGreen            = CASE WHEN BBG.BgBewilligungStatusCode = 5 THEN 1 
                                           ELSE 0 
                                      END,
           Monatsbudget             = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
           Jahr                     = BBG.Jahr,
           Monat                    = BBG.Monat,
           KbBuchungStatusCode      = NULL, -- update later
           Krankenkasse             = INS.[Name],
           BaInstitutionID          = BPO.BaInstitutionID,
           
           BetragKVG                = NULL,
           StatusKVG                = NULL,
           
           BetragKVGMax             = NULL,
           StatusKVGMax             = NULL,
           
           BetragVVG                = CASE WHEN SPT.BgPositionsartCode IN (32021, 32022) THEN ISNULL(BPO.BetragRechnung, $0) 
                                           ELSE $0 
                                      END, -- VVG (32021, 32022)
           StatusVVG                = CASE WHEN BBG.MasterBudget = 0 AND SPT.BgPositionsartCode IN (32021, 32022) -- VVG (32021, 32022)
                                             THEN CASE WHEN STA.Status IS NULL
                                                         THEN CASE WHEN BPO.BgKategorieCode IN (2, 100) AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Auszahlung/Zusätzliche Leistung an Spezialkonto
                                                                     THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                               ELSE 1 
                                                                          END
                                                                   WHEN BPO.BgKategorieCode = 1 AND BPO.VerwaltungSD = 0 -- nicht abgetretene Einnahmen
                                                                     THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                               ELSE 1 
                                                                          END
                                                                   ELSE CASE WHEN BPO.BgKategorieCode = 2 AND KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL -- Ausgaben an Klient (ohne tatsächliche Auszahlung)
                                                                               THEN CASE WHEN BBG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                                         ELSE 1 
                                                                                    END
                                                                             ELSE CASE BPO.BgBewilligungStatusCode WHEN 1 THEN 1   -- grau
                                                                                                                   WHEN 2 THEN 15  -- abgelehnt
                                                                                                                   WHEN 3 THEN 12  -- angefragt
                                                                                                                   WHEN 5 THEN 14  -- bewilligt
                                                                                                                   WHEN 9 THEN 7   -- gesperrt
                                                                                  END
                                                                        END
                                                              END
                                                       ELSE STA.Status
                                                  END
                                      END,
           
           -- request used BelegID of inserted entries from FrmBatchKVG, entries are connected by BgPositionID_Parent where
           -- first entry gets NULL and the following entries get the id of the first one - independent of the person then.
           BelegID                 = (SELECT TOP 1 -- expect only one id
                                             CASE WHEN SUB.BgPositionID_Parent IS NULL THEN SUB.BgPositionID
                                                  ELSE SUB.BgPositionID_Parent
                                             END
                                      FROM dbo.BgPosition SUB WITH (READUNCOMMITTED) 
                                        INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID 
                                        AND SUB.BaPersonID = BPP.BaPersonID 
                                        AND SPT.BgPositionsartCode IN (32021, 32022) -- VVG (32021, 32022)
                                        AND SUB.BgKategorieCode = 101 -- 101=Einzelzahlung
                                        AND SUB.BgSpezkontoID IS NOT NULL ), 
           KbAuszahlungsArtCode    = NULL, -- update later
           
           ZahlungKVG              = NULL, -- update later
           StatusZahlungKVG        = NULL, -- update later
           ZahlungKVGMax           = NULL, -- update later
           StatusZahlungKVGMax     = NULL, -- update later
           ZahlungVVG              = NULL, -- update later
           StatusZahlungVVG        = NULL, -- update later
           
           Bemerkung               = NULL, -- update later
           
           BgPositionIDKVG         = NULL,
           BgPositionIDKVGMax      = NULL,
           BgPositionIDVVG         = (SELECT TOP 1 SUB.BgPositionID
                                      FROM dbo.BgPosition SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID 
                                        AND SUB.BaPersonID = BPP.BaPersonID 
                                        AND SPT.BgPositionsartCode IN (32021, 32022) -- VVG (32021, 32022)
                                        AND SUB.BgKategorieCode = 101 -- 101=Einzelzahlung
                                        AND SUB.BgSpezkontoID IS NOT NULL), 
           
           BgPositionsartIDKVG     = NULL,
           BgPositionsartIDKVGMax  = NULL,
           BgPositionsartIDVVG     = (SELECT TOP 1 SUB.BgPositionsartID -- expect only one id
                                      FROM dbo.BgPosition SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID 
                                        AND SUB.BaPersonID = BPP.BaPersonID 
                                        AND SPT.BgPositionsartCode IN (32021, 32022) -- VVG (32021, 32022)
                                        AND SUB.BgSpezkontoID IS NOT NULL), 
           
           BgSpezKontoIDKVG        = NULL,
           BgSpezKontoIDKVGMax     = NULL,
           BgSpezKontoIDVVG        = (SELECT TOP 1 SUB.BgSpezkontoID -- expect only one id
                                      FROM dbo.BgPosition SUB WITH (READUNCOMMITTED) 
                                      INNER JOIN BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = SUB.BgPositionsartID
                                      WHERE SUB.BgBudgetID = BPO.BgBudgetID 
                                        AND SUB.BaPersonID = BPP.BaPersonID 
                                        AND SUB.BgKategorieCode = 2 
                                        AND SPT.BgPositionsartCode IN (32021, 32022) -- VVG (32021, 32022)
                                        AND SUB.BgSpezkontoID IS NOT NULL)
    
    FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgFinanzplan          BFP WITH (READUNCOMMITTED) ON BFP.FaLeistungID = FAL.FaLeistungID
      INNER JOIN dbo.BgBudget              BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID 
                                                                     AND (@BudgetMonth IS NULL OR BBG.Monat = @BudgetMonth) 
                                                                     AND (@BudgetYear IS NULL OR BBG.Jahr = @BudgetYear)
      INNER JOIN dbo.BgFinanzplan_BaPerson BPP WITH (READUNCOMMITTED) ON BPP.BgFinanzplanID =  BBG.BgFinanzplanID
      LEFT  JOIN dbo.vwBgPosition          BPO                        ON BPO.BgBudgetID = BBG.BgBudgetID 
                                                                     AND BPO.BaPersonID = BPP.BaPersonID 
                                                                     AND BPO.BgSpezkontoID IS NOT NULL
      LEFT  JOIN dbo.BgPositionsart        SPT                        ON SPT.BgPositionsartID = BPO.BgPositionsartID 
                                                                     AND SPT.BgPositionsartCode IN (32021, 32022) -- VVG (32021, 32022)
      LEFT  JOIN dbo.BaInstitution         INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPO.BaInstitutionID

      LEFT  JOIN dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID 
                                                                     AND BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                                                     FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
                                                                                                     WHERE BgPositionID = BPO.BgPositionID
                                                                                                     ORDER BY CASE WHEN BaPersonID IS NULL THEN 1
                                                                                                                   WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                                                   ELSE 3
                                                                                                              END)
      LEFT  JOIN dbo.vwKreditor            KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
      LEFT  JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FAL.FaLeistungID AND ARC.CheckOut IS NULL
      LEFT  JOIN (SELECT BUC.BgBudgetID,
                         BUK.BgPositionID,
                         Status = MAX(BUC.KbBuchungStatusCode)
                  FROM dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                  GROUP BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BBG.BgBudgetID 
                                                                AND STA.BgPositionID = BPO.BgPositionID

    WHERE FAL.FaLeistungID = @FaLeistungID 
      AND ARC.FaLeistungID IS NULL -- Fall darf abgeschlossen sein, aber nicht archiviert!
      AND BFP.BgBewilligungStatusCode >= 5 
      AND BPP.IstUnterstuetzt = 1 
      AND BBG.MasterBudget = 0 
      AND BPO.BgKategorieCode = 2 -- 2=Ausgaben
  
--=============================================================================
  
  -----------------------------------------------------------------------------
  -- GENERAL: UPDATE PENDING FIELDS
  -----------------------------------------------------------------------------
  UPDATE OPT
  SET KbBuchungStatusCode  = (SELECT TOP 1 KBB.KbBuchungStatusCode
                              FROM dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) 
                                INNER JOIN dbo.KbBuchung KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungID = KBK.KbBuchungID 
                                                                                   AND KBB.BgBudgetID = OPT.BgBudgetID
                              WHERE KBK.BgPositionID = BelegID),
      KbAuszahlungsArtCode = (SELECT KbAuszahlungsArtCode
                              FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
                              WHERE BgPositionID = BelegID)
  FROM @OUTPUT  OPT
  WHERE BelegID IS NOT NULL
  
  -----------------------------------------------------------------------------
  -- KVG: UPDATE PENDING FIELDS
  -----------------------------------------------------------------------------
  UPDATE OPT
  SET ZahlungKVG          = (SELECT POS.Betrag
                             FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
                             WHERE POS.BgPositionID = OPT.BgPositionIDKVG),
      StatusZahlungKVG    = (SELECT ISNULL(STA.Status, CASE 
                                                         WHEN BPO.BgKategorieCode IN (2, 100) AND 
                                                              KRE.BaZahlungswegID IS NULL AND 
                                                              BPO.BgSpezkontoID IS NOT NULL -- Auszahlung/Zusätzliche Leistung an Spezialkonto
                                                              THEN CASE 
                                                                     WHEN BDG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                     ELSE 1 
                                                                   END
                                                         WHEN BPO.BgKategorieCode IN (101)   -- Einzelzahlungen
                                                              THEN CASE 
                                                                     WHEN BDG.BgBewilligungStatusCode IN (5, 9) THEN 14 
                                                                     ELSE 1 
                                                                   END
                                                         ELSE CASE BPO.BgBewilligungStatusCode
                                                                WHEN 1 THEN 1   -- grau
                                                                WHEN 2 THEN 15  -- abgelehnt
                                                                WHEN 3 THEN 12  -- angefragt
                                                                WHEN 5 THEN 14  -- bewilligt
                                                                WHEN 9 THEN 7   -- gesperrt
                                                             END
                                                       END)
                             FROM dbo.BgPosition        BPO WITH (READUNCOMMITTED) 
                               LEFT JOIN dbo.BgBudget   BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = OPT.BgBudgetID
                               LEFT JOIN dbo.vwKreditor KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = (SELECT TOP 1 BaZahlungswegID 
                                                                                                             FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
                                                                                                             WHERE BgPositionID = BPO.BgPositionID)
                               LEFT JOIN (SELECT BUC.BgBudgetID,
                                                 BUK.BgPositionID,
                                                 Status = MAX(BUC.KbBuchungStatusCode)
                                          FROM dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) 
                                            LEFT JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                                          GROUP BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = OPT.BgBudgetID 
                                                                                        AND STA.BgPositionID = BPO.BgPositionID
                             WHERE BPO.BgPositionID = OPT.BgPositionIDKVG),
      Bemerkung           = (SELECT CONVERT(VARCHAR(5000), POS.Bemerkung) 
                             FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                             WHERE POS.BgPositionID = OPT.BgPositionIDKVG)
  FROM @OUTPUT  OPT
  WHERE OPT.BelegID IS NOT NULL AND 
        ISNULL(OPT.BetragKVG, 0) > 0
  
  -----------------------------------------------------------------------------
  -- KVG-MAX: UPDATE PENDING FIELDS
  -----------------------------------------------------------------------------
  UPDATE OPT
  SET ZahlungKVGMax       = (SELECT POS.Betrag
                             FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
                             WHERE POS.BgPositionID = OPT.BgPositionIDKVGMax),
      StatusZahlungKVGMax = (SELECT ISNULL(STA.Status, CASE 
                                                         WHEN BPO.BgKategorieCode IN (2, 100) AND 
                                                              KRE.BaZahlungswegID IS NULL AND 
                                                              BPO.BgSpezkontoID IS NOT NULL -- Auszahlung/Zusätzliche Leistung an Spezialkonto
                                                              THEN CASE 
                                                                     WHEN BDG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                     ELSE 1 
                                                                   END
                                                         WHEN BPO.BgKategorieCode IN (101)   -- Einzelzahlungen
                                                              THEN CASE 
                                                                     WHEN BDG.BgBewilligungStatusCode IN (5, 9) THEN 14 
                                                                     ELSE 1 
                                                                   END
                                                         ELSE CASE BPO.BgBewilligungStatusCode
                                                                WHEN 1 THEN 1   -- grau
                                                                WHEN 2 THEN 15  -- abgelehnt
                                                                WHEN 3 THEN 12  -- angefragt
                                                                WHEN 5 THEN 14  -- bewilligt
                                                                WHEN 9 THEN 7   -- gesperrt
                                                             END
                                                       END)
                             FROM dbo.BgPosition        BPO WITH (READUNCOMMITTED) 
                               LEFT JOIN dbo.BgBudget   BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = OPT.BgBudgetID
                               LEFT JOIN dbo.vwKreditor KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = (SELECT TOP 1 BaZahlungswegID 
                                                                                                             FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
                                                                                                             WHERE BgPositionID = BPO.BgPositionID)
                               LEFT JOIN (SELECT BUC.BgBudgetID,
                                                 BUK.BgPositionID,
                                                 Status = MAX(BUC.KbBuchungStatusCode)
                                          FROM dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) 
                                            LEFT JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                                          GROUP BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = OPT.BgBudgetID 
                                                                                        AND STA.BgPositionID = BPO.BgPositionID
                             WHERE BPO.BgPositionID = OPT.BgPositionIDKVGMax),
      Bemerkung           = (SELECT CONVERT(VARCHAR(5000), POS.Bemerkung) 
                             FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                             WHERE POS.BgPositionID = OPT.BgPositionIDKVGMax)
  FROM @OUTPUT  OPT
  WHERE OPT.BelegID IS NOT NULL AND 
        ISNULL(OPT.BetragKVGMax, 0) > 0
  
  -----------------------------------------------------------------------------
  -- VVG: UPDATE PENDING FIELDS
  -----------------------------------------------------------------------------
  UPDATE OPT
  SET ZahlungVVG          = (SELECT POS.Betrag
                             FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                             WHERE POS.BgPositionID = OPT.BgPositionIDVVG),
      StatusZahlungVVG    = (SELECT ISNULL(STA.Status, CASE 
                                                         WHEN BPO.BgKategorieCode IN (2, 100) AND 
                                                              KRE.BaZahlungswegID IS NULL AND 
                                                              BPO.BgSpezkontoID IS NOT NULL -- Auszahlung/Zusätzliche Leistung an Spezialkonto
                                                              THEN CASE 
                                                                     WHEN BDG.BgBewilligungStatusCode IN (5, 9) THEN 2 
                                                                     ELSE 1 
                                                                   END
                                                         WHEN BPO.BgKategorieCode IN (101)   -- Einzelzahlungen
                                                              THEN CASE 
                                                                     WHEN BDG.BgBewilligungStatusCode IN (5, 9) THEN 14 
                                                                     ELSE 1 
                                                                   END
                                                         ELSE CASE BPO.BgBewilligungStatusCode
                                                                WHEN 1 THEN 1   -- grau
                                                                WHEN 2 THEN 15  -- abgelehnt
                                                                WHEN 3 THEN 12  -- angefragt
                                                                WHEN 5 THEN 14  -- bewilligt
                                                                WHEN 9 THEN 7   -- gesperrt
                                                             END
                                                       END)
                             FROM dbo.BgPosition        BPO WITH (READUNCOMMITTED) 
                               LEFT JOIN dbo.BgBudget   BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = OPT.BgBudgetID
                               LEFT JOIN dbo.vwKreditor KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = (SELECT TOP 1 BaZahlungswegID 
                                                                                                             FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
                                                                                                             WHERE BgPositionID = BPO.BgPositionID)
                               LEFT JOIN (SELECT BUC.BgBudgetID,
                                                 BUK.BgPositionID,
                                                 Status = MAX(BUC.KbBuchungStatusCode)
                                          FROM dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) 
                                            LEFT JOIN dbo.KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                                          GROUP BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = OPT.BgBudgetID 
                                                                                        AND STA.BgPositionID = BPO.BgPositionID
                             WHERE BPO.BgPositionID = OPT.BgPositionIDVVG),
      Bemerkung           = (SELECT CONVERT(VARCHAR(5000), POS.Bemerkung) 
                             FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                             WHERE POS.BgPositionID = OPT.BgPositionIDVVG)
  FROM @OUTPUT  OPT
  WHERE OPT.BelegID IS NOT NULL AND 
        ISNULL(OPT.BetragVVG, 0) > 0
  
--=============================================================================
  
  -----------------------------------------------------------------------------
  -- OUTPUT
  -----------------------------------------------------------------------------
  SELECT DISTINCT
         OPT.BaPersonID,
         OPT.Person,
         OPT.LeistungTraeger,
         OPT.BgBudgetID,
         OPT.IsBudgetGray,
         OPT.IsBudgetGreen,
         OPT.Monatsbudget,
         OPT.Jahr,
         OPT.Monat,
         OPT.KbBuchungStatusCode,
         OPT.Krankenkasse,
         OPT.BaInstitutionID,
         
         BetragKVG    = MAX(OPT.BetragKVG),
         BetragKVGMax = MAX(OPT.BetragKVGMax),
         
         StatusKVG    = MAX(OPT.StatusKVG),
         StatusKVGMax = MAX(OPT.StatusKVGMax),
         
         BetragVVG    = MAX(OPT.BetragVVG),
         StatusVVG    = MAX(OPT.StatusVVG),
         
         OPT.BelegID,
         OPT.KbAuszahlungsArtCode,
         
         OPT.ZahlungKVG,
         OPT.StatusZahlungKVG,
         
         OPT.ZahlungKVGMax,
         OPT.StatusZahlungKVGMax,
         
         OPT.ZahlungVVG,
         OPT.StatusZahlungVVG,
         
         OPT.Bemerkung,
         
         OPT.BgPositionIDKVG,
         OPT.BgPositionIDKVGMax,
         OPT.BgPositionIDVVG,
         
         OPT.BgPositionsartIDKVG,
         OPT.BgPositionsartIDKVGMax,
         OPT.BgPositionsartIDVVG,
         
         OPT.BgSpezKontoIDKVG,
         OPT.BgSpezKontoIDKVGMax,
         OPT.BgSpezKontoIDVVG
  FROM @OUTPUT OPT
  GROUP BY OPT.BaPersonID, 
           OPT.Person, 
           OPT.LeistungTraeger,
           OPT.BgBudgetID, 
           OPT.IsBudgetGray, 
           OPT.IsBudgetGreen, 
           OPT.Monatsbudget, 
           OPT.Jahr, 
           OPT.Monat,
           OPT.KbBuchungStatusCode, 
           OPT.Krankenkasse, 
           OPT.BaInstitutionID,
           OPT.BelegID,
           OPT.KbAuszahlungsArtCode, 
           
           OPT.ZahlungKVG, 
           OPT.StatusZahlungKVG, 
           
           OPT.ZahlungKVGMax, 
           OPT.StatusZahlungKVGMax, 
           
           OPT.ZahlungVVG, 
           OPT.StatusZahlungVVG,
           
           OPT.Bemerkung, 
           
           OPT.BgPositionIDKVG, 
           OPT.BgPositionIDKVGMax, 
           OPT.BgPositionIDVVG, 
           
           OPT.BgPositionsartIDKVG, 
           OPT.BgPositionsartIDKVGMax, 
           OPT.BgPositionsartIDVVG,
           
           OPT.BgSpezKontoIDKVG, 
           OPT.BgSpezKontoIDKVGMax, 
           OPT.BgSpezKontoIDVVG
  HAVING (MAX(ISNULL(OPT.BetragKVG, 0)) + MAX(ISNULL(OPT.BetragKVGMax, 0)) + MAX(ISNULL(OPT.BetragVVG, 0))) > 0
  ORDER BY OPT.Jahr DESC, 
           OPT.Monat DESC, 
           OPT.LeistungTraeger DESC, 
           OPT.Person, 
           BetragKVG DESC, 
           BetragKVGMax DESC, 
           BetragVVG DESC
--=============================================================================
END