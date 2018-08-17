SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Update
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_Update.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:55 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_Update.sql $
 * 
 * 3     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE dbo.spWhBudget_Update
 (@BgBudgetID        int,
  @BgPositionID      int = NULL)
AS BEGIN
  DECLARE @RefDate         datetime,
          @BgFinanzplanID  int,
          @BaPersonID      int,
          @SQL             nvarchar(4000)

  SELECT @RefDate        = IsNull(SFP.DatumVon, SFP.GeplantVon),
         @BgFinanzplanID = BBG.BgFinanzplanID
  FROM dbo.BgBudget    BBG
    INNER JOIN dbo.BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID
    AND (BBG.BgBewilligungStatusCode < 5 OR (BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode = 5))

  IF @BgFinanzplanID IS NULL RETURN

  DECLARE cRichtlinie CURSOR FAST_FORWARD FOR
    SELECT BPO.BgPositionID, BPO.BaPersonID, BPT.sqlRichtlinie
    FROM dbo.BgPosition              BPO WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED)
        ON BPT.BgPositionsartID = BPO.BgPositionsartID
        AND BPT.sqlRichtlinie IS NOT NULL
        AND BPT.BgPositionsartID != 32030  -- Ausnahme Eff. Erwerbsunkosten
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgPositionID = IsNull(@BgPositionID, BPO.BgPositionID)

  OPEN cRichtlinie
  WHILE (1=1) BEGIN
    FETCH NEXT FROM cRichtlinie INTO @BgPositionID, @BaPersonID, @SQL
    IF @@FETCH_STATUS != 0 BREAK

    DECLARE @Last_DEF  int

    SET @Last_DEF = LEN(@SQL) - CHARINDEX(REVERSE('_DEF'), REVERSE(@SQL))
    IF CHARINDEX('FROM', @SQL, @Last_DEF) = 0
      SET @SQL = @SQL + char(13) + 'INTO #Richtlinie'
    ELSE
      SET @SQL = STUFF(@SQL, @Last_DEF, 0, char(13) + 'INTO #Richtlinie')

    IF @BaPersonID IS NULL BEGIN
      SET @SQL = @SQL + '

UPDATE BPO
  SET Betrag = IsNull(
                 CASE WHEN BPO.Betrag = $-1.00 THEN CONVERT(money, IsNull(TMP.UE_DEF, TMP.UE_MIN))
                 ELSE CONVERT(money, dbo.fnMAX(dbo.fnMIN(BPO.Betrag, TMP.UE_MAX), TMP.UE_MIN))
               END, BPO.Betrag)
FROM dbo.BgPosition   BPO,
  #Richtlinie     TMP
WHERE BgPositionID = @BgPositionID
  AND (Betrag NOT BETWEEN TMP.UE_MIN AND TMP.UE_MAX OR Betrag = $-1.00)'
    END ELSE BEGIN
      SET @SQL = @SQL + '

UPDATE BPO
  SET Betrag = IsNull(
                 CASE WHEN BPO.Betrag = $-1.00 THEN CONVERT(money, IsNull(TMP.PR_DEF, TMP.PR_MIN))
                 ELSE CONVERT(money, dbo.fnMAX(dbo.fnMIN(BPO.Betrag, TMP.PR_MAX), TMP.PR_MIN))
               END, BPO.Betrag)
FROM dbo.BgPosition   BPO,
  #Richtlinie     TMP
WHERE BgPositionID = @BgPositionID
  AND (Betrag NOT BETWEEN TMP.PR_MIN AND TMP.PR_MAX OR Betrag = $-1.00)'
    END


    EXECUTE sp_executesql @SQL,
      N'@RefDate         DATETIME,
        @BgFinanzplanID  INT,
        @BgBudgetID      INT,
        @BgPositionID    INT',
      @RefDate, @BgFinanzplanID, @BgBudgetID, @BgPositionID
  END
  CLOSE cRichtlinie
  DEALLOCATE cRichtlinie

  -- Betrag auf 0.05 Runden
  UPDATE BPO
    SET
      Betrag       = Round(Betrag               * 2, 1) / 2,
      Reduktion    = Round((Reduktion - 0.0001) * 2, 1) / 2,
      Abzug        = Round((Abzug - 0.0001)     * 2, 1) / 2,
      MaxBeitragSD = Round(MaxBeitragSD         * 2, 1) / 2
  FROM dbo.BgPosition  BPO WITH (READUNCOMMITTED)
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND (Betrag       != (Round(Betrag               * 2, 1) / 2)
      OR Reduktion    != (Round((Reduktion - 0.0001) * 2, 1) / 2)
      OR Abzug        != (Round((Abzug - 0.0001)     * 2, 1) / 2)
      OR MaxBeitragSD != (Round(MaxBeitragSD         * 2, 1) / 2))

  -- Monat und Jahr anpassen, falls es sich um ein Masterbudget handelt
  UPDATE BDG
  SET BDG.Monat = MONTH(FPL.GeplantVon), BDG.Jahr = YEAR(FPL.GeplantVon)
  FROM dbo.BgFinanzplan FPL WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
  WHERE BDG.MasterBudget = 1
    AND BDG.BgBudgetID = @BgBudgetID 
    AND (YEAR(GeplantVon) <> BDG.Jahr
    OR MONTH(GeplantVon) <> BDG.Monat)

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
