SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmCmCaseManagement;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmCmCaseManagement.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:59 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for CmCaseManagement
  -
  RETURNS: Bookmarks for casemanagement and client
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmCmCaseManagement
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmCmCaseManagement.sql $
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     19.03.09 15:21 Cjaeggi
 * New view for new bookmarks of CaseManagement
=================================================================================================*/

CREATE VIEW dbo.vwTmCmCaseManagement
AS
SELECT
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  FAC.FaCaseManagementID,
  FAC.FaLeistungID,
  
  -----------------------------------------------------------------------------
  -- all from person
  -----------------------------------------------------------------------------
  PRS.*,
  
  -----------------------------------------------------------------------------
  -- Others
  -----------------------------------------------------------------------------
  ErstellungZV = CONVERT(VARCHAR, FAC.ErstellungZV, 104),
  FAC.Grundsatzziel

FROM dbo.FaCaseManagement FAC WITH(READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung   LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FAC.FaLeistungID
  INNER JOIN dbo.vwTmBaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
WHERE FAC.IstHaupteintrag = 1
GO