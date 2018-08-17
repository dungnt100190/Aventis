SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmSbSozialberatung;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmSbSozialberatung.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 10:01 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for SbSozialberatung
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmSbSozialberatung
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmSbSozialberatung.sql $
 * 
 * 5     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 4     23.03.09 7:24 Cjaeggi
 * ##4018: Changed column Bemerkungen to Grundsatzziel
 * 
 * 3     19.03.09 15:15 Cjaeggi
 * ##4019: Renamed and changed for new bookmarks
 * 
 * 2     2.12.08 15:26 Cjaeggi
 * Changed LOV name
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
 * 
 * 1     3.09.08 9:49 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.vwTmSbSozialberatung
AS
SELECT
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  SBS.SbSozialberatungID,
  SBS.FaLeistungID,
  
  -----------------------------------------------------------------------------
  -- all from person
  -----------------------------------------------------------------------------
  PRS.*,
  
  -----------------------------------------------------------------------------
  -- Others
  -----------------------------------------------------------------------------
  ErstellungZV = CONVERT(VARCHAR, SBS.ErstellungZV, 104),
  SBS.Grundsatzziel

FROM dbo.SbSozialberatung SBS WITH(READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung   LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = SBS.FaLeistungID
  INNER JOIN dbo.vwTmBaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
WHERE SBS.IstHaupteintrag = 1
GO