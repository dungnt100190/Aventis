SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Update
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhBudget_Update.sql $
  $Author: Tabegglen $
  $Modtime: 7.09.10 12:57 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhBudget_Update.sql $
 * 
 * 5     7.09.10 12:58 Tabegglen
 * #6411 neue SP, die das Budget rundet.
 * 
 * 4     6.09.10 10:58 Tabegglen
 * #6411 neue SP, die das Budget rundet.
 * 
 * 3     19.08.10 8:32 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode
 * 
 * 2     25.06.09 8:47 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhBudget_Update
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
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
  FROM BgBudget    BBG
    INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID
    AND (BBG.BgBewilligungStatusCode < 5 OR (BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode = 5))

  IF @BgFinanzplanID IS NULL RETURN

  DECLARE cRichtlinie CURSOR FAST_FORWARD FOR
    SELECT BPO.BgPositionID, BPO.BaPersonID, BPT.sqlRichtlinie
    FROM BgPosition              BPO
      INNER JOIN BgPositionsart  BPT ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgPositionID = IsNull(@BgPositionID, BPO.BgPositionID)
      AND BPT.sqlRichtlinie IS NOT NULL
      AND BPT.BgPositionsartCode != 32030  -- Ausnahme Eff. Erwerbsunkosten

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
  EXECUTE dbo.spWhBudget_Runden @BgBudgetID;

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