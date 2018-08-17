SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyBudget_Update
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyBudget_Update.sql $
  $Author: Tabegglen $
  $Modtime: 19.08.10 8:45 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyBudget_Update.sql $
 * 
 * 3     19.08.10 8:46 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyBudget_Update
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyBudget_Update
 (@BgBudgetID        int,
  @UpdateGB_Minus    bit = 0,
  @UpdateGB_Normal   bit = 0,
  @UpdateGB_Plus     bit = 0,
  @BgPositionID      int = NULL)
AS BEGIN
  DECLARE @RefDate         datetime,
          @BgFinanzplanID  int,
          @BaPersonID      int,
          @SQL             nvarchar(4000)

  SELECT @RefDate        = IsNull(SFP.DatumVon, SFP.GeplantVon),
         @BgFinanzplanID = BBG.BgFinanzplanID
  FROM dbo.BgBudget    BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID
    AND (BBG.BgBewilligungStatusCode < 5 OR (BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode = 5))

  IF @BgFinanzplanID IS NULL RETURN

  DECLARE cRichtlinie CURSOR FAST_FORWARD FOR
    SELECT BPO.BgPositionID, BPO.BaPersonID, BPT.sqlRichtlinie
    FROM dbo.BgPosition             BPO WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgPositionID = IsNull(@BgPositionID, BPO.BgPositionID)
      AND BPT.sqlRichtlinie IS NOT NULL
      AND (BPT.BgPositionsartCode NOT IN (60001, 60002, 60002)
            OR (@UpdateGB_Minus = 1  AND BPT.BgPositionsartCode = 60001)
            OR (@UpdateGB_Normal = 1 AND BPT.BgPositionsartCode = 60002)
            OR (@UpdateGB_Plus = 1   AND BPT.BgPositionsartCode = 60003)
            OR BPO.BgPositionID = @BgPositionID)

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
FROM BgPosition   BPO,
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
FROM BgPosition   BPO,
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
  FROM dbo.BgPosition  BPO
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND (Betrag       != (Round(Betrag               * 2, 1) / 2)
      OR Reduktion    != (Round((Reduktion - 0.0001) * 2, 1) / 2)
      OR Abzug        != (Round((Abzug - 0.0001)     * 2, 1) / 2)
      OR MaxBeitragSD != (Round(MaxBeitragSD         * 2, 1) / 2))
END
GO