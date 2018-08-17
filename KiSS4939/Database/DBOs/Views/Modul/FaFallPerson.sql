SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject FaFallPerson
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: 
=================================================================================================*/

CREATE VIEW dbo.FaFallPerson
AS

SELECT
  FaFallPersonID = NULL,
  FaFallID = BaPersonID_1,
  BaPersonID = BaPersonID_2,
  DatumVon, DatumBis
FROM 
  dbo.BaPerson_Relation WITH (READUNCOMMITTED) 
UNION ALL
SELECT
  FaFallPersonID = NULL,
  FaFallID = BaPersonID_2,
  BaPersonID = BaPersonID_1,
  DatumVon, DatumBis
FROM 
  dbo.BaPerson_Relation WITH (READUNCOMMITTED) 
UNION ALL
SELECT
  FaFallPersonID = NULL,
  BaPersonID, 
  BaPersonID, 
  NULL, 
  NULL
FROM 
  dbo.BaPerson WITH (READUNCOMMITTED);

GO