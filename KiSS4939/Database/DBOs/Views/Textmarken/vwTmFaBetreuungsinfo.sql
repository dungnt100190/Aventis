SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFaBetreuungsinfo;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmFaBetreuungsinfo.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 10:00 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for FaBertreuungsinfo
  -
  RETURNS: Bookmarks for FaBetreuungsinfo
  -
  TEST:    SELECT TOP 30 * FROM vwTmFaBetreuungsinfo
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmFaBetreuungsinfo.sql $
 * 
 * 3     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 2     15.12.08 14:28 Cjaeggi
 * Added NotfallInfo
 * 
 * 1     11.12.08 16:22 Cjaeggi
 * First version
=================================================================================================*/

CREATE VIEW dbo.vwTmFaBetreuungsinfo
AS
SELECT
  -- from BaPerson
  VPR.*,

  -- from FaBetreuungsinfo
  FAB.FaBetreuungsinfoID,
  
  FAB.IndividualBehinderung,
  FAB.IndividualPersoenlichkeit,
  FAB.IndividualKommunikation,
  FAB.IndividualIntellektuell,
  FAB.IndividualMotorik,
  FAB.IndividualFreizeit,
  FAB.IndividualNotfallInfo,
  
  FAB.BetreuungVerhalten,
  FAB.BetreuungAngst,
  FAB.BetreuungSicherheit,
  FAB.BetreuungVerhindern,
  FAB.BetreuungMedizin,
  FAB.BetreuungMedikation,
  FAB.BetreuungErnaehrung,
  FAB.BetreuungTagesablauf,
  
  FAB.SelbstaendigMobilitaet,
  FAB.SelbstaendigKleiden,
  FAB.SelbstaendigNahrung,
  FAB.SelbstaendigGrundpflege,
  FAB.SelbstaendigToilette,
  FAB.SelbstaendigSchlaf,
  FAB.SelbstaendigVerschiedenes

FROM dbo.FaBetreuungsinfo FAB WITH(READUNCOMMITTED)
  INNER JOIN dbo.vwTmBaPerson VPR WITH(READUNCOMMITTED) ON VPR.BaPersonID = FAB.BaPersonID
GO 