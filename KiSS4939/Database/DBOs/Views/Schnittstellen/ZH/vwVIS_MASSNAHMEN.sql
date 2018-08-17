SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_MASSNAHMEN]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_MASSNAHMEN;
END;
GO
/*===============================================================================================
  $Revision: 8 $
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
CREATE VIEW dbo.vwVIS_MASSNAHMEN
AS
SELECT Vormsch_ID                 = ARR.ObsoleteIdentity,
       ArrangementId              = ARR.ID,
       FALL_NR                    = ARR.DossierNumber,
       BESCH_A_ED                 = ARR.DateOfOrder,
       BESCH_A_AD                 = ARR.DateOfRepeal,
       Massnahme                  = ARR.ArrangementArticleName,
       Mandatstyp                 = ARR.ArrangementTypeName,
       DossierId                  = ARR.DossierId,
       ArrangementId_Neurechtlich = ARR.ArrangementNewLawId,
       IstNeurechtlich            = ARR.IsNewLaw
FROM [{VisServerName}].[{VisDBName}].[kiss].[Arrangement] ARR

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

