SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_CreateQuotedZahlinfo
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spWhBudget_CreateQuotedZahlinfo
 (@BgPositionID   int)
AS BEGIN
  DECLARE @OldBgAuszahlungPersonID INT
  DECLARE @NewBgAuszahlungPersonID INT
  DECLARE @Count INT
  DECLARE @BaPersonID INT
  DECLARE @WhereClause VARCHAR(200)

  SELECT @OldBgAuszahlungPersonID = MAX(BgAuszahlungPersonID), @Count = COUNT(*) 
  FROM   dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
  WHERE  BgPositionID = @BgPositionID AND
         BaPersonID IS NULL

  IF @COUNT > 1 OR @OldBgAuszahlungPersonID IS NULL
    RETURN
  
  DECLARE cPersonUE CURSOR STATIC FOR 
  SELECT FPP.BaPersonID
  FROM   dbo.BgPosition BPO  WITH (READUNCOMMITTED) 
         INNER JOIN dbo.BgBudget              BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
         INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = BDG.BgFinanzplanID AND
                                                 FPP.IstUnterstuetzt = 1
  WHERE  BPO.BgPositionID = @BgPositionID

  OPEN cPersonUE
  FETCH NEXT FROM cPersonUE INTO @BaPersonID
  WHILE @@FETCH_STATUS = 0 BEGIN

    -- BgAuszahlungPerson
    SET @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(varchar,@OldBgAuszahlungPersonID)
    EXEC spDuplicateRows 'BgAuszahlungPerson',@WhereClause,'BaPersonID',@BaPersonID
        
    SET @NewBgAuszahlungPersonID = @@IDENTITY

    -- BgAuszahlungPersonTermin
    SET @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(varchar,@OldBgAuszahlungPersonID)
    EXEC spDuplicateRows 'BgAuszahlungPersonTermin',@WhereClause,'BgAuszahlungPersonID',@NewBgAuszahlungPersonID 

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
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
