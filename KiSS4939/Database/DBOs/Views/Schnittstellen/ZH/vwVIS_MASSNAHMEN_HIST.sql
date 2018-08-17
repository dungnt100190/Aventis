SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_MASSNAHMEN_HIST]'))
BEGIN 
  EXECUTE dbo.spDropObject vwVIS_MASSNAHMEN_HIST;
END;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwVIS_MASSNAHMEN_HIST
AS
SELECT Vormsch_ID    = ARR.ObsoleteIdentity,
       ArrangementId = ARR.ID,
       FALL_NR       = ARR.DossierNumber,
       BESCH_A_ED    = ARH.DateOfOrder,
       BESCH_A_AD    = ARH.DateOfRepeal,
       Massnahme     = ARH.ArticleDescription,
       Mandatstyp    = ARH.ArrangementDescription
FROM [{VisServerName}].[{VisDBName}].[kiss].[ArrangementHistory]  ARH
  INNER JOIN [{VisServerName}].[{VisDBName}].[kiss].[Arrangement] ARR ON ARR.Id = ARH.ArrangementId
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


