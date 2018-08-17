SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Update
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhFinanzplan_Update.sql $
  $Author: Mmarghitola $
  $Modtime: 11.02.10 15:40 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhFinanzplan_Update.sql $
 * 
 * 6     11.02.10 15:41 Mmarghitola
 * Spezialzeichen entfernt
 * 
 * 5     11.02.10 14:49 Mmarghitola
 * #5809: Änderungen nur an unbewilligten Finanzplänen vornehmen
 * 
 * 4     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 3     10.04.09 22:41 Rstahel
 * #99: Weitere Verbesserungen
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhFinanzplan_Update]
 (@BgFinanzplanID int)
AS BEGIN
  DECLARE @BgBudgetID               int,
          @WhGrundbedarfTyp         int,
          @BgBewilligungStatusCode  int,
          @RefDate                  datetime

  SELECT
    @BgBudgetID               = BBG.BgBudgetID,
    @BgBewilligungStatusCode  = BFP.BgBewilligungStatusCode,
    @RefDate                  = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
  FROM dbo.BgFinanzplan      BFP WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID AND BBG.MasterBudget = 1
  WHERE BFP.BgFinanzplanID = @BgFinanzplanID

  IF @BgBudgetID IS NULL RETURN
  IF @BgBewilligungStatusCode IN (5, 9) RETURN

  SELECT @WhGrundbedarfTyp = BPO.BgPositionsartID
  FROM dbo.BgPosition        BPO WITH (READUNCOMMITTED)
    INNER JOIN dbo.XLOVCode  XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = BPO.BgPositionsartID
  WHERE BPO.BgBudgetID = @BgBudgetID

  IF @WhGrundbedarfTyp = 32015 AND @BgBewilligungStatusCode < 5 BEGIN
    UPDATE BgPosition
      SET Betrag = -$1.00
    WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = 32015
  END


  -- Add Remove Person
  DECLARE @BaPersonID      int,
          @IstUnterstuetzt  bit

  DECLARE cPerson CURSOR FAST_FORWARD FOR
    SELECT BaPersonID, IstUnterstuetzt
    FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
    WHERE BgFinanzplanID = @BgFinanzplanID
   UNION ALL
    SELECT DISTINCT BPO.BaPersonID, 0
    FROM dbo.BgBudget            BBG WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
    WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BPO.BaPersonID IS NOT NULL
      AND NOT EXISTS (SELECT * FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
                      WHERE BaPersonID = BPO.BaPersonID AND BgFinanzplanID = @BgFinanzplanID)

  OPEN cPerson
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cPerson INTO @BaPersonID, @IstUnterstuetzt
    IF @@FETCH_STATUS != 0 BREAK

    IF @IstUnterstuetzt = 1 BEGIN
      DECLARE @KVG                  money,
              @BaInstitutionID      int,
              @VVG                  money,
              @VVG_BaInstitutionID  int

      SELECT TOP 1
        @KVG = IsNull(KVG.Praemie, $0.00), @BaInstitutionID     = KVG.BaInstitutionID,
        @VVG = IsNull(VVG.Praemie, $0.00), @VVG_BaInstitutionID = VVG.BaInstitutionID
      FROM dbo.BaPerson                       PRS WITH (READUNCOMMITTED)
        LEFT JOIN dbo.BaKrankenversicherung   KVG WITH (READUNCOMMITTED) ON KVG.BaPersonID = PRS.BaPersonID AND KVG.GesetzesGrundlageCode = 1
                                             AND @RefDate BETWEEN IsNull(KVG.DatumVon, @RefDate) AND IsNull(KVG.DatumBis, @RefDate)
        LEFT JOIN dbo.BaKrankenversicherung   VVG WITH (READUNCOMMITTED) ON VVG.BaPersonID = PRS.BaPersonID AND VVG.GesetzesGrundlageCode = 2
                                             AND @RefDate BETWEEN IsNull(VVG.DatumVon, @RefDate) AND IsNull(VVG.DatumBis, @RefDate)
      WHERE PRS.BaPersonID = @BaPersonID
      ORDER BY KVG.DatumVon DESC, VVG.DatumVon DESC

      IF @RefDate < '20080701' -- ZH: Vor 1.7.2008 keine Prämien aus Basisdaten übernehmen
        SELECT @KVG = $0.00, @VVG = $0.00

      -- KVG
      IF NOT EXISTS (SELECT * FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND BaPersonID = @BaPersonID AND BgPositionsartID = 32020)
        INSERT INTO BgPosition (BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, BaInstitutionID, Buchungstext)
          SELECT @BgBudgetID, @BaPersonID, BgKategorieCode, BgPositionsartID, @KVG, @BaInstitutionID, [Name]
          FROM dbo.BgPositionsart WITH (READUNCOMMITTED)
          WHERE BgPositionsartID = 32020

-- VVG aus GBL: Wird nicht mehr ausgewiesen als separate Position (siehe auch Mantis #99)
/*      -- VVG
      IF NOT EXISTS (SELECT * FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND BaPersonID = @BaPersonID AND BgPositionsartID IN (32021, 32022))
        INSERT INTO BgPosition (BgPositionID_Parent, BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, MaxBeitragSD, BaInstitutionID, Buchungstext)
          SELECT SCOPE_IDENTITY(), @BgBudgetID, @BaPersonID, BgKategorieCode, BgPositionsartID, @VVG, $0.00, @VVG_BaInstitutionID, [Name]
          FROM dbo.BgPositionsart WITH (READUNCOMMITTED)
          WHERE BgPositionsartID = 32021
*/

      -- Alg. Erwerbsunkosten
      IF @WhGrundbedarfTyp = 32011 BEGIN
        IF NOT EXISTS (SELECT * FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND BaPersonID = @BaPersonID AND BgPositionsartID = 32031) BEGIN
          INSERT INTO BgPosition (BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, MaxBeitragSD, Buchungstext)
            SELECT @BgBudgetID, @BaPersonID, BgKategorieCode, BgPositionsartID, CONVERT(money, dbo.fnXConfig('System\Sozialhilfe\SKOS\C3_GeAmount', @RefDate)), [Name]
            FROM dbo.BgPositionsart WITH (READUNCOMMITTED)
            WHERE BgPositionsartID = 32031
        END
      END ELSE IF @WhGrundbedarfTyp = 32015 BEGIN
        DELETE FROM dbo.BgPosition WHERE BgBudgetID = @BgBudgetID AND BaPersonID = @BaPersonID AND BgPositionsartID = 32031
      END

    END ELSE BEGIN
      -- Persönliche Eintrage für nichtunterstützte Persone löschen
      WHILE 1 = 1 BEGIN
        DELETE BPO
        FROM dbo.BgBudget            BBG
          INNER JOIN dbo.BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID
        WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BPO.BaPersonID = @BaPersonID
          AND NOT EXISTS (SELECT * FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgPositionID_Parent = BPO.BgPositionID)

        IF @@rowcount = 0 BREAK
      END
    END
  END
  CLOSE cPerson
  DEALLOCATE cPerson

  EXECUTE spWhBudget_Update @BgBudgetID
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
