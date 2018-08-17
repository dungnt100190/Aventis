SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBaRelation
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

CREATE FUNCTION dbo.fnBaRelation
 (@BaPersonID_A int,
  @BaPersonID_B int)
 RETURNS varchar(75)
AS
BEGIN
  DECLARE @Relation varchar(75)

  SELECT @Relation = CASE PRS.GeschlechtCode
                       WHEN 1 THEN RLE.NameMaennlich
                       WHEN 2 THEN RLE.NameWeiblich
                       ELSE        RLE.NameGenerisch
                     END
  FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
    INNER JOIN (SELECT BaPersonID_2 AS BaPersonID_A, BaPersonID_1 AS BaPersonID_B,
                  NameGenerisch1 AS NameGenerisch, NameMaennlich1 AS NameMaennlich, NameWeiblich1 AS NameWeiblich
                FROM dbo.BaPerson_Relation DRE WITH (READUNCOMMITTED) 
                  INNER JOIN dbo.BaRelation DRL WITH (READUNCOMMITTED) ON DRL.BaRelationID = DRE.BaRelationID
                UNION ALL
                SELECT BaPersonID_1 AS BaPersonID_A, BaPersonID_2 AS BaPersonID_B,
                  NameGenerisch2 AS NameGenerisch, NameMaennlich2 AS NameMaennlich, NameWeiblich2 AS NameWeiblich
                FROM dbo.BaPerson_Relation DRE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaRelation DRL WITH (READUNCOMMITTED) ON DRL.BaRelationID = DRE.BaRelationID
               ) RLE ON BaPersonID_A = @BaPersonID_A AND BaPersonID_B = PRS.BaPersonID
  WHERE PRS.BaPersonID = @BaPersonID_B

  RETURN(@Relation)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
