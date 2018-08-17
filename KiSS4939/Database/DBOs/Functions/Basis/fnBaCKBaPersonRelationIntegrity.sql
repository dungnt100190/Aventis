SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaCKBaPersonRelationIntegrity;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnBaCKBaPersonRelationIntegrity.sql $
  $Author: Cjaeggi $
  $Modtime: 6.05.10 9:44 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check data integrity for table BaPerson_Relation.
    @BaPerson_RelationID: The primary key id of the datarow to insert/update
    @BaPersonID_1:        The id of the first person
    @BaPersonID_2:        The id of the second person
  -
  RETURNS: "1" if something is wrong, on valid data "0"
  -
  TEST:    SELECT dbo.fnBaCKBaPersonRelationIntegrity(NULL, 1, 2);
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(NULL, 1, 1);
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(NULL, NULL, 1);
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(NULL, -1, 1);
           --
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(NULL, 3347, 3348);
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(NULL, 3348, 3347);
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(14128, 3348, 3347);
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(14128, 3348, 3348);
           SELECT dbo.fnBaCKBaPersonRelationIntegrity(NULL, 3348, 3348);
=================================================================================================
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnBaCKBaPersonRelationIntegrity.sql $
 * 
 * 1     7.05.10 9:10 Cjaeggi
 * #6127: Doppelte Beziehungen zwischen Personen (add check constraint)
=================================================================================================*/

CREATE FUNCTION dbo.fnBaCKBaPersonRelationIntegrity
(
  @BaPerson_RelationID INT,
  @BaPersonID_1 INT,
  @BaPersonID_2 INT
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate parameter
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID_1, -1) < 1 OR 
      ISNULL(@BaPersonID_2, -1) < 1 OR
      @BaPersonID_1 = @BaPersonID_2)
  BEGIN
    -- invalid parameter
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- validate against existing data
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM dbo.BaPerson_Relation PRE WITH (READUNCOMMITTED)
              WHERE PRE.BaPerson_RelationID <> ISNULL(@BaPerson_RelationID, -1)
                AND ((PRE.BaPersonID_1 = @BaPersonID_2 AND PRE.BaPersonID_2 = @BaPersonID_1) 
                  OR (PRE.BaPersonID_1 = @BaPersonID_1 AND PRE.BaPersonID_2 = @BaPersonID_2)
                  OR (PRE.BaPersonID_1 = @BaPersonID_1 AND PRE.BaPersonID_2 = @BaPersonID_1) 
                  OR (PRE.BaPersonID_1 = @BaPersonID_2 AND PRE.BaPersonID_2 = @BaPersonID_2))))
  BEGIN
    -- invalid data
    RETURN 1;
  END
  ELSE
  BEGIN
    -- valid data
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- if we are here, something is wrong
  -----------------------------------------------------------------------------
  RETURN 1;
END;
GO
