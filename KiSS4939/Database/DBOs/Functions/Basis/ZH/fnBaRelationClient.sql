SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBaRelationClient
GO
/*===============================================================================================
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
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnBaRelationClient
 (@BaFallPersonID int,
  @BaPersonID int,
  @ActualDate datetime)
 RETURNS varchar(75)
AS
BEGIN
  DECLARE @Relation varchar(75)

  SELECT @Relation = 
  CASE WHEN R.BaPersonID_2 = @BaFallPersonID
    THEN CASE
      WHEN P1.GeschlechtCode=1 THEN Rel.NameMaennlich1
      WHEN P1.GeschlechtCode=2 THEN Rel.NameWeiblich1
      ELSE Rel.NameGenerisch1
    END
    ELSE CASE
      WHEN P2.GeschlechtCode=1 THEN Rel.NameMaennlich2
      WHEN P2.GeschlechtCode=2 THEN Rel.NameWeiblich2
      ELSE Rel.NameGenerisch2
    END
  END
  FROM dbo.BaPerson_Relation R WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.BaPerson P1 WITH (READUNCOMMITTED) on P1.BaPersonID=R.BaPersonID_1 AND R.BaPersonID_1<>@BaFallPersonID
  LEFT OUTER JOIN dbo.BaPerson P2 WITH (READUNCOMMITTED) on P2.BaPersonID=R.BaPersonID_2 AND R.BaPersonID_2<>@BaFallPersonID
  LEFT OUTER JOIN dbo.BaRelation Rel WITH (READUNCOMMITTED) on Rel.BaRelationID=R.BaRelationID
  WHERE (
      ((R.BaPersonID_1 = @BaFallPersonID) AND (R.BaPersonID_2 = @BaPersonID)) OR
      ((R.BaPersonID_2 = @BaFallPersonID) AND (R.BaPersonID_1 = @BaPersonID))
    )
    AND @ActualDate BETWEEN IsNull(R.DatumBis, @ActualDate) AND IsNull(R.DatumBis, @ActualDate)
    ORDER BY IsNull(R.DatumBis, GetDate()) DESC

  RETURN(@Relation)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
