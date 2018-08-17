SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE dbo.spDropObject fnKbGetWVReportData
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbGetWVReportData.sql $
  $Author: Tabegglen $
  $Modtime: 15.09.10 14:51 $
  $Revision: 14 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get data used for WV-report
    @CsvKbWVEinzelpostenIDs: The KbWVEinzelpostenIDs as CSV that have to be used to collect data
    @LanguageCode:           The language code used for display data
  -
  RETURNS: Table containing all neccessary data used for WV-report
  -
  TEST:    SELECT * FROM dbo.fnKbGetWVReportData('10,11,12,13', 1)
           SELECT * FROM dbo.fnKbGetWVReportData(NULL, NULL)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbGetWVReportData.sql $
 * 
 * 14    15.09.10 14:52 Tabegglen
 * #6429 Korrektur gemäss Feedback C. Stucki: KoA 523 ist nicht
 * weiterverrechenbar.
 * 
 * 13    15.09.10 12:51 Tabegglen
 * #6429 neue Kostenarten/Konti mit 'Weiterverrechnung' auf 1 gesetzt
 * müssen auch im Report fest-verdrahtet reingenommen werden, sonst
 * erscheinen die entsprechenden Buchungen nicht.
 * 
 * 12    24.09.09 8:44 Lgreulich
 * Umbau KbKostenstelle -> KbKostenstelle_BaPerson
 * 
 * 11    24.06.09 16:22 Ckaeser
 * Alter2Create
 * 
 * 10    24.10.08 13:08 Cjaeggi
 * Changes due to no FaFinanzplanID when VerwPeriodeVon/Bis is out of
 * DatumVon/Bis of Finanzplan
 * 
 * 9     23.10.08 11:15 dmast
 * 
 * 8     22.10.08 21:00 dmast
 * 
 * 7     14.10.08 15:03 dmast
 * WV: Gruppierung nach BgFinanzplanID
 * 
 * 6     2.10.08 11:10 Cjaeggi
 * 
 * 5     1.10.08 14:36 Cjaeggi
 * 
 * 4     1.10.08 12:23 Cjaeggi
 * Some more code
 * 
 * 3     30.09.08 15:44 Cjaeggi
 * Some more code
 * 
 * 2     29.09.08 12:51 Cjaeggi
 * Testentries
 * 
 * 1     29.09.08 10:38 Cjaeggi
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetWVReportData
(
 @CsvKbWVEinzelpostenIDs VARCHAR(MAX),
 @LanguageCode INT = 1 -- use default language if none defined
)
RETURNS @Result TABLE
(
  Id$ INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
  FaLeistungID INT NULL,
  BaPersonID INT NOT NULL,
  KostenstelleNr VARCHAR(200),
  Header_DatumVon DATETIME,
  Header_DatumBis DATETIME,
  Header_PersonName VARCHAR(255),
  Header_PersonGeburtsdatum DATETIME,
  Header_Heimatgemeinden VARCHAR(255),
  Header_Kantone VARCHAR(255),
  Header_Wohnort VARCHAR(100),
  Header_WohnkantonNr VARCHAR(50),
  Header_HeimatkantonNr VARCHAR(50),
  Header_Bemerkung VARCHAR(MAX),
  Sub_Betrag1 MONEY,
  Sub_Betrag2 MONEY,
  Sub_Betrag3 MONEY,
  Sub_Betrag4 MONEY,
  Sub_Betrag5 MONEY,
  Sub_Betrag5a MONEY,
  Sub_Betrag5b MONEY,
  Sub_Betrag5c MONEY,
  Sub_Betrag6 MONEY,
  Sub_TotalAusgaben MONEY,
  Sub_Betrag8 MONEY,
  Sub_Betrag8a MONEY,
  Sub_Betrag9 MONEY,
  Sub_Betrag10 MONEY,
  Sub_Betrag11 MONEY,
  Sub_TotalEinnahmen MONEY,
  Sub_Betrag14 MONEY,
  Sub_Betrag15Total MONEY
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@CsvKbWVEinzelpostenIDs IS NULL)
  BEGIN
    -- invalid values
    RETURN
  END
  
  -- use default language if none defined
  SET @LanguageCode = ISNULL(@LanguageCode, 1)
  
  -----------------------------------------------------------------------------
  -- create and fill temporary table for CSV-values
  -----------------------------------------------------------------------------
  -- init table
  DECLARE @KbWVEinzelpostenIDs TABLE
  (
    KbWVEinzelpostenID INT NOT NULL PRIMARY KEY,
    FaLeistungID       INT,
    BgFinanzplanID     INT,
    BaPersonID         INT NOT NULL,
    KantonKuerzel      VARCHAR(50) NOT NULL
  )

  -- get data using function  
  INSERT INTO @KbWVEinzelpostenIDs (KbWVEinzelpostenID, FaLeistungID, BgFinanzplanID, BaPersonID, KantonKuerzel)
    SELECT WEP.KbWVEinzelpostenID, FaLeistungID = MAX(BFP.FaLeistungID), BgFinanzplanID = MAX(BFP.BgFinanzplanID), WEP.BaPersonID, IsNull(WEP.KantonKuerzel, '')
    FROM dbo.fnSplit(@CsvKbWVEinzelpostenIDs, ',') FCN
      INNER JOIN dbo.KbWVEinzelposten              WEP WITH (READUNCOMMITTED) ON WEP.KbWVEinzelpostenID = CONVERT(int, FCN.Value)
      INNER JOIN dbo.BgFinanzplan_BaPerson         FPP WITH (READUNCOMMITTED) ON FPP.BaPersonID = WEP.BaPersonID AND FPP.IstUnterstuetzt = 1
      LEFT  JOIN dbo.BgFinanzplan                  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = FPP.BgFinanzplanID
                                                                             AND WEP.DatumVon BETWEEN BFP.DatumVon AND BFP.DatumBis
    GROUP BY WEP.KbWVEinzelpostenID, WEP.BaPersonID, IsNull(WEP.KantonKuerzel, '')


  -- Finanzpläne ohne Personenveränderung zusammenfassen
  DECLARE @FaLeistungID        int,
          @BgFinanzplanID      int,
          @Old_FaLeistungID    int,
          @Old_BgFinanzplanID  int

  DECLARE cBgFinanzplan CURSOR FAST_FORWARD FOR
    SELECT WEP.FaLeistungID, WEP.BgFinanzplanID
    FROM @KbWVEinzelpostenIDs  WEP
      INNER JOIN BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = WEP.BgFinanzplanID
    GROUP BY WEP.FaLeistungID, WEP.BgFinanzplanID, BFP.DatumVon
    ORDER BY WEP.FaLeistungID, WEP.BgFinanzplanID, BFP.DatumVon

  OPEN cBgFinanzplan
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cBgFinanzplan INTO @FaLeistungID, @BgFinanzplanID
    IF @@FETCH_STATUS < 0 BREAK

    IF @Old_FaLeistungID = @FaLeistungID BEGIN
      IF NOT EXISTS (SELECT *
                     FROM (SELECT BaPersonID FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
                          WHERE BgFinanzplanID = @Old_BgFinanzplanID AND IstUnterstuetzt = 1) OLD
                       FULL JOIN (SELECT BaPersonID FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
                                  WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1) NEW ON NEW.BaPersonID = OLD.BaPersonID
                     WHERE OLD.BaPersonID IS NULL OR NEW.BaPersonID IS NULL)
      BEGIN
        UPDATE @KbWVEinzelpostenIDs
          SET BgFinanzplanID = @Old_BgFinanzplanID
        WHERE BgFinanzplanID = @BgFinanzplanID

        CONTINUE
      END
    END
    SELECT @Old_FaLeistungID = @FaLeistungID, @Old_BgFinanzplanID = @BgFinanzplanID
  END
  DEALLOCATE cBgFinanzplan


  -- Leistungsträger
  UPDATE WEP
    SET BaPersonID = FLE.BaPersonID
  FROM @KbWVEinzelpostenIDs  WEP
    INNER JOIN FaLeistung    FLE WITH (READUNCOMMITTED) ON FLE.FaLeistungID = WEP.FaLeistungID
  WHERE EXISTS (SELECT * FROM @KbWVEinzelpostenIDs
                WHERE BgFinanzplanID = WEP.BgFinanzplanID AND BaPersonID = FLE.BaPersonID
                  AND KantonKuerzel = WEP.KantonKuerzel)
  
  -- Älteste Person
  UPDATE WEP
    SET BaPersonID = (SELECT TOP 1 TMP.BaPersonID
                      FROM @KbWVEinzelpostenIDs  TMP
                        INNER JOIN BaPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
                      WHERE BgFinanzplanID = WEP.BgFinanzplanID
                        AND KantonKuerzel = WEP.KantonKuerzel
                      ORDER BY PRS.Geburtsdatum)
  FROM @KbWVEinzelpostenIDs  WEP
    INNER JOIN FaLeistung    FLE WITH (READUNCOMMITTED) ON FLE.FaLeistungID = WEP.FaLeistungID
  WHERE WEP.BaPersonID <> FLE.BaPersonID
  

  -----------------------------------------------------------------------------
  -- get data for given KbWVEinzelpostenIDs
  -----------------------------------------------------------------------------
  INSERT INTO @Result (FaLeistungID, BaPersonID, KostenstelleNr,
                       Header_DatumVon, Header_DatumBis, Header_PersonName, Header_PersonGeburtsdatum,
                       Header_Heimatgemeinden, Header_Kantone, Header_Wohnort, Header_WohnkantonNr, 
                       Header_HeimatkantonNr, Header_Bemerkung,
                       Sub_Betrag1, Sub_Betrag2, Sub_Betrag3, Sub_Betrag4, Sub_Betrag5, Sub_Betrag5a, Sub_Betrag5b, Sub_Betrag5c, Sub_Betrag6,
                       Sub_Betrag8, Sub_Betrag8a, Sub_Betrag9, Sub_Betrag10, Sub_Betrag11,
                       Sub_Betrag14)
    SELECT -- specific data
           FaLeistungID              = TMP.FaLeistungID,
           BaPersonID                = TMP.BaPersonID,
           KostenstelleNr            = MAX(dbo.fnKbGetKostenstelle(TMP.BaPersonID)),
      
           -- header data
           Header_DatumVon           = MIN(WEP.DatumVon),
           Header_DatumBis           = MAX(WEP.DatumBis),
           Header_PersonName         = MAX(ISNULL(PRS.Name + ISNULL(', ' + PRS.Vorname, ''), ISNULL(PRS.Vorname, ''))),
           Header_PersonGeburtsdatum = MAX(PRS.Geburtsdatum),
           Header_Heimatgemeinden    = MAX(ISNULL(dbo.fnGetMLText(GDE.NameTID, @LanguageCode), GDE.Name)),
           Header_Kantone            = MAX(WEP.KantonKuerzel),
           Header_Wohnort            = MAX(ADR.Ort),
           Header_WohnkantonNr       = MAX(CASE WHEN WEP.BaPersonID = TMP.BaPersonID THEN WEP.WohnKantonNr END),
           Header_HeimatkantonNr     = MAX(CASE WHEN WEP.BaPersonID = TMP.BaPersonID THEN WEP.HeimatkantonNr END),
           Header_Bemerkung          = MAX(CASE WHEN WEP.BaPersonID = TMP.BaPersonID THEN CONVERT(VARCHAR(MAX), BVC.Bemerkung) END), -- required to convert because of GROUP BY
           
           -- expenses
           Sub_Betrag1  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 1 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag2  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 2 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag3  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 3 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag4  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 4 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag5  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 5 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag5a = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 6 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag5b = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 7 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag5c = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 8 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag6  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 9 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           
           -- income
           Sub_Betrag8  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 10 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag8a = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 11 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag9  = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 12 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag10 = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 13 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           Sub_Betrag11 = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 14 THEN WEP.Betrag ELSE $0.00 END), $0.00),
           
           -- deductions
           Sub_Betrag14 = NullIf(SUM(CASE WHEN KOA.BaWVZeileCode = 15 THEN WEP.Betrag ELSE $0.00 END), $0.00)
    
    FROM @KbWVEinzelpostenIDs               TMP       
      INNER JOIN dbo.KbWVEinzelposten       WEP WITH (READUNCOMMITTED) ON WEP.KbWVEinzelpostenID = TMP.KbWVEinzelpostenID
      
      -- person
      INNER JOIN dbo.BaPerson               PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
      LEFT  JOIN dbo.BaAdresse              ADR WITH (READUNCOMMITTED) ON ADR.BaPersonID = PRS.BaPersonID AND 
                                                                          ADR.AdresseCode = 1 AND     -- 1='Wohnsitz'
                                                                          GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())
      LEFT  JOIN dbo.BaGemeinde             GDE WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
      
      -- wv
      INNER JOIN dbo.BaWVCode               BVC WITH (READUNCOMMITTED) ON BVC.BaWVCodeID = WEP.BaWVCodeID
      
      -- klibu
      INNER JOIN dbo.KbBuchungKostenart     BKA WITH (READUNCOMMITTED) ON BKA.KbBuchungKostenartID = WEP.KbBuchungKostenartID
      INNER JOIN dbo.BgKostenart            KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = BKA.BgKostenartID
      INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.KbKostenstelleID = BKA.KbKostenstelleID
    
    GROUP BY TMP.FaLeistungID, TMP.BgFinanzplanID, TMP.BaPersonID
    ORDER BY TMP.FaLeistungID, TMP.BgFinanzplanID, TMP.BaPersonID
  
  -----------------------------------------------------------------------------
  -- update calculated columns
  -----------------------------------------------------------------------------
  -- calculate Sub_TotalAusgaben, SubTotalEinnahmen
  UPDATE RES
      -- total expenses
  SET RES.Sub_TotalAusgaben  = ISNULL(RES.Sub_Betrag1, 0.0) + 
                               ISNULL(RES.Sub_Betrag2, 0.0) + 
                               ISNULL(RES.Sub_Betrag3, 0.0) + 
                               ISNULL(RES.Sub_Betrag4, 0.0) + 
                               ISNULL(RES.Sub_Betrag5, 0.0) + 
                               ISNULL(RES.Sub_Betrag5a, 0.0) + 
                               ISNULL(RES.Sub_Betrag5b, 0.0) + 
                               ISNULL(RES.Sub_Betrag5c, 0.0) + 
                               ISNULL(RES.Sub_Betrag6, 0.0),

      -- total incomes                              
      RES.Sub_TotalEinnahmen = ISNULL(RES.Sub_Betrag8, 0.0) +
                               ISNULL(RES.Sub_Betrag8a, 0.0) +
                               ISNULL(RES.Sub_Betrag9, 0.0) +
                               ISNULL(RES.Sub_Betrag10, 0.0) +
                               ISNULL(RES.Sub_Betrag11, 0.0)
  FROM @Result RES
  
  -- calculate Sub_Betrag15Total
  -- TODO: what about: '14. Pflichtleistungen'? (Sub_Betrag14)
  UPDATE RES
  SET RES.Sub_Betrag15Total = ISNULL(RES.Sub_TotalAusgaben, 0.0) - ISNULL(RES.Sub_TotalEinnahmen, 0.0) - ISNULL(RES.Sub_Betrag14, 0.0)
  FROM @Result RES

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
