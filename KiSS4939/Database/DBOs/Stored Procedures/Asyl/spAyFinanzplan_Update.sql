SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyFinanzplan_Update
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Update.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:33 $
  $Revision: 3 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Update.sql $
 * 
 * 3     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 2     4.11.08 18:50 dmast
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyFinanzplan_Update
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyFinanzplan_Update
 (@BgFinanzplanID int)
AS 

BEGIN
  DECLARE @BgBudgetID int,
          @RefDate    datetime

  SELECT @BgBudgetID = BgBudgetID, @RefDate = dbo.fnDateSerial(Jahr, Monat, 1)
  FROM dbo.BgBudget WITH (READUNCOMMITTED) 
  WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 1

  DECLARE @cntUnterstuetzt  int
  SELECT @cntUnterstuetzt = COUNT(*) FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
  WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1

  -- Grundbedarf
  IF NOT EXISTS (SELECT 1 FROM dbo.BgPosition WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID IN (60001, 60002, 60003))
    INSERT BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
    VALUES (@BgBudgetID, 2, 60002)  -- Grundbedarf normal

  -- Betrag Stufe minus
  UPDATE BgPosition
  SET    Betrag =  round(CONVERT(money, TMP.ValueVar)/0.05,0)* 0.05  -- Runden auf 5 Rp.
  FROM   dbo.BgPosition   BPO,
         dbo.fnXConfigChild('System\Asyl\Grundbedarf\minus', @RefDate)  TMP
  WHERE  BgBudgetID = @BgBudgetID AND
         BgPositionsartID = 60001 AND
         TMP.Child = @cntUnterstuetzt

  -- Betrag Stufe normal
  UPDATE BgPosition
  SET    Betrag =  round(CONVERT(money, TMP.ValueVar)/0.05,0)* 0.05  -- Runden auf 5 Rp.
  FROM   BgPosition   BPO,
         dbo.fnXConfigChild('System\Asyl\Grundbedarf\normal', @RefDate)  TMP
  WHERE  BgBudgetID = @BgBudgetID AND
         BgPositionsartID = 60002 AND
         TMP.Child = @cntUnterstuetzt

  -- Betrag Stufe plus
  UPDATE BgPosition
  SET    Betrag =  round(CONVERT(money, TMP.ValueVar)/0.05,0)* 0.05  -- Runden auf 5 Rp.
  FROM   BgPosition   BPO,
         dbo.fnXConfigChild('System\Asyl\Grundbedarf\plus', @RefDate)  TMP
  WHERE  BgBudgetID = @BgBudgetID AND
         BgPositionsartID = 60003 AND
         TMP.Child = @cntUnterstuetzt

  -- Kleidung
  IF NOT EXISTS (SELECT * FROM BgPosition WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = 60004)
    INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID)
      VALUES (@BgBudgetID, 2, 60004)  -- Kleidung / Schuhe

  UPDATE BgPosition
    SET Betrag = CONVERT(money, IsNull(dbo.fnXConfig('System\Asyl\Kleidung', @RefDate), $0.00) )
                    * (SELECT COUNT(*) FROM BgFinanzplan_BaPerson WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1)
  WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = 60004


  EXECUTE spAyBudget_Update @BgBudgetID, 1,1,1

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
      AND NOT EXISTS (SELECT 1 FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                      WHERE BaPersonID = BPO.BaPersonID AND BgFinanzplanID = @BgFinanzplanID)

  OPEN cPerson
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cPerson INTO @BaPersonID, @IstUnterstuetzt
    IF @@FETCH_STATUS != 0 BREAK

    IF @IstUnterstuetzt = 1 BEGIN
      PRINT 'Unterstuetzt'
    END ELSE BEGIN
      -- Persönliche Eintrage für nichtunterstützte Persone löschen
      -- zuerst Positionen mit Verweis auf Parent löschen
      DELETE BPO
      FROM BgBudget            BBG
        INNER JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID
      WHERE BBG.BgFinanzplanID = @BgFinanzplanID
        AND BPO.BaPersonID = @BaPersonID
        AND BPO.BgPositionID IN (SELECT BgPositionID_Parent FROM BgPosition WHERE BgBudgetID = BBG.BgBudgetID)

      -- dann restliche Positionen löschen
      DELETE BPO
      FROM BgBudget            BBG
        INNER JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID
      WHERE BBG.BgFinanzplanID = @BgFinanzplanID
        AND BPO.BaPersonID = @BaPersonID

    END
  END
  CLOSE cPerson
  DEALLOCATE cPerson

  -- Betrag auf 0.05 Runden
  UPDATE BPO
    SET
      Betrag       = Round(Betrag               * 2, 1) / 2,
      Reduktion    = Round((Reduktion - 0.0001) * 2, 1) / 2,
      Abzug        = Round((Abzug - 0.0001)     * 2, 1) / 2,
      MaxBeitragSD = Round(MaxBeitragSD         * 2, 1) / 2
  FROM dbo.BgPosition  BPO
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND (Betrag       != (Round(Betrag               * 2, 1) / 2)
      OR Reduktion    != (Round((Reduktion - 0.0001) * 2, 1) / 2)
      OR Abzug        != (Round((Abzug - 0.0001)     * 2, 1) / 2)
      OR MaxBeitragSD != (Round(MaxBeitragSD         * 2, 1) / 2))
END
GO