SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaRelation;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/PI/fnBaRelation.sql $
  $Author: Cjaeggi $
  $Modtime: 16.03.10 11:20 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @BaPersonID_A: 
    @BaPersonID_B: 
  -
  RETURNS: 
  -
  TEST:    
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/PI/fnBaRelation.sql $
 * 
 * 3     16.03.10 11:20 Cjaeggi
 * Updated function to fit standard layout
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:52 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBaRelation
(
  @BaPersonID_A INT,
  @BaPersonID_B INT
)
RETURNS VARCHAR(75)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @Relation VARCHAR(75)
  
  -----------------------------------------------------------------------------
  -- collect data
  -----------------------------------------------------------------------------
  SELECT @Relation = CASE PRS.GeschlechtCode
                       WHEN 1 THEN RLE.NameMaennlich
                       WHEN 2 THEN RLE.NameWeiblich
                       ELSE RLE.NameGenerisch
                     END
  FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
    INNER JOIN (SELECT BaPersonID_A  = BaPersonID_2, 
                       BaPersonID_B  = BaPersonID_1,
                       NameGenerisch = NameGenerisch1, 
                       NameMaennlich = NameMaennlich1, 
                       NameWeiblich  = NameWeiblich1
                FROM dbo.BaPerson_Relation PRE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaRelation REL WITH (READUNCOMMITTED) ON REL.BaRelationID = PRE.BaRelationID
                
                UNION ALL
                
                SELECT BaPersonID_A  = BaPersonID_1, 
                       BaPersonID_B  = BaPersonID_2,
                       NameGenerisch = NameGenerisch2, 
                       NameMaennlich = NameMaennlich2, 
                       NameWeiblich  = NameWeiblich2
                FROM dbo.BaPerson_Relation PRE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaRelation REL WITH (READUNCOMMITTED) ON REL.BaRelationID = PRE.BaRelationID) RLE ON BaPersonID_A = @BaPersonID_A
                                                                                                                  AND BaPersonID_B = PRS.BaPersonID
  WHERE PRS.BaPersonID = @BaPersonID_B
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN (@Relation)
END
GO