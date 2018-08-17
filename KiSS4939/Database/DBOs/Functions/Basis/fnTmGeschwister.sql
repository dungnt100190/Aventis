SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnTmGeschwister;
GO
/*===============================================================================================
  $Revision: 1
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Liefert eine Liste der IDs von Geschwistern einer Person
    @BaPersonID: .
  -
  RETURNS: BaPersonID's aller Geschwister
  -
  TEST:    SELECT BaPersonID FROM dbo.fnGetGeschwister(65065);
=================================================================================================*/

CREATE FUNCTION dbo.fnTmGeschwister
(
  @BaPersonID INT
)
RETURNS @Result TABLE
(
  BaPersonID INT NOT NULL
)
AS
BEGIN
  INSERT INTO @Result (BaPersonID)
    SELECT PRS.BaPersonID
    FROM dbo.BaPerson_Relation PRE WITH (READUNCOMMITTED)
      INNER JOIN dbo.vwTmPerson  PRS ON ((PRS.BaPersonID = PRE.BaPersonID_1 AND PRE.BaPersonID_2 = @BaPersonID)
                                     OR  (PRS.BaPersonID = PRE.BaPersonID_2 AND PRE.BaPersonID_1 = @BaPersonID))
    WHERE PRE.BaRelationID = 2 -- Geschwister
    ORDER BY CONVERT(DATETIME, PRS.GeburtsDatum, 104) ASC;

  RETURN;
END;
GO
