SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_CreateQuotedZahlinfo
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_CreateQuotedZahlinfo.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:13 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_CreateQuotedZahlinfo.sql $
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
  DB-Object: spWhBudget_CreateQuotedZahlinfo
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBudget_CreateQuotedZahlinfo
 (@BgPositionID   int)
AS BEGIN
  DECLARE @OldBgAuszahlungPersonID INT
  DECLARE @COUNT INT
  DECLARE @BaPersonID INT

  SELECT @OldBgAuszahlungPersonID = MAX(BgAuszahlungPersonID), @COUNT = COUNT(*)
  FROM   dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
  WHERE  BgPositionID = @BgPositionID AND
         BaPersonID IS NULL

  IF @COUNT > 1 OR @OldBgAuszahlungPersonID IS NULL
    RETURN

  DECLARE cPersonUE CURSOR STATIC FOR
  SELECT FPP.BaPersonID
  FROM   BgPosition                       BPO
         INNER JOIN BgBudget              BDG ON BDG.BgBudgetID = BPO.BgBudgetID
         INNER JOIN BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = BDG.BgFinanzplanID AND
                                                 FPP.IstUnterstuetzt = 1
  WHERE  BPO.BgPositionID = @BgPositionID

  OPEN cPersonUE
  FETCH NEXT FROM cPersonUE INTO @BaPersonID
  WHILE @@FETCH_STATUS = 0 BEGIN

    -- BgAuszahlungPerson
    SELECT BgAuszahlungPersonID AS PK, CONVERT(int, NULL) AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgAuszahlungPerson
    FROM BgAuszahlungPerson
    WHERE BgAuszahlungPersonID = @OldBgAuszahlungPersonID

    EXECUTE spXParentChildCopy '#BgAuszahlungPerson',
                               'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                               'BaPersonID', @BaPersonID

    -- BgAuszahlungPersonTermin
    INSERT INTO BgAuszahlungPersonTermin(BgAuszahlungPersonID, Datum)
      SELECT TMP.KeyNew, BAT.Datum
      FROM #BgAuszahlungPerson               TMP
        INNER JOIN BgAuszahlungPersonTermin  BAT ON BAT.BgAuszahlungPersonID = TMP.PK

    DROP TABLE #BgAuszahlungPerson

    FETCH NEXT FROM cPersonUE INTO @BaPersonID
  END
  CLOSE cPersonUE
  DEALLOCATE cPersonUE

  -- alte Daten löschen
  DELETE BgAuszahlungPersonTermin
  WHERE  BgAuszahlungPersonID = @OldBgAuszahlungPersonID

  DELETE BgAuszahlungPerson
  WHERE  BgAuszahlungPersonID = @OldBgAuszahlungPersonID
END
GO