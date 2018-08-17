SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_BERICHT]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_BERICHT;
END;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <Beschreibung der View, Zweck und Einsatz>
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwVIS_BERICHT;
=================================================================================================*/
CREATE VIEW dbo.vwVIS_BERICHT
AS
WITH CTE AS
(
  SELECT MAND_ID             = MRI.Number,
         VORMSCH_ID          = MAN.ArrangementObsoleteIdentity,
         ArrangementId       = MAN.ArrangementId,
         BERICHTSTERMIN      = MRI.ReportDate,
         T1                  = MRI.MandateReportCategory,
         BERICHT_VON         = MRI.ReportStart,
         BERICHT_PER         = MRI.ReportEnd,
         MAHNUNG1            = MRI.Dunning1,
         MAHNUNG2            = MRI.Dunning2,
         MAHNUNG3            = MRI.Dunning3,
         EINGANG_SDS         = MRI.ClearingOfficeEntry,
         AUSGANG_SDS         = MRI.ClearingOfficeExit,
         VB_BESCHLUSS        = MRI.Demandnote,
         RB_SB_BRZ           = MRI.Receipt,
         FRISTERSTRECKUNG    = MRI.TimelimitExtension,
         FALL_NR             = MAN.DossierNumber,
         BK_ID               = MRI.Id,
         MandateId           = MRI.MandateId,
         RankBericht         = RANK() OVER (PARTITION BY MRI.MandateID ORDER BY ISNULL(MRI.ReportStart, '17530101') DESC, ISNULL(MRI.ReportEnd, '99991231') DESC) -- pro Mandat die Berichte nummerieren
  FROM [{VisServerName}].[{VisDBName}].[kiss].[Mandate]                   MAN
    INNER JOIN [{VisServerName}].[{VisDBName}].[kiss].[MandateReportInfo] MRI ON MRI.MandateId = MAN.Id
)

SELECT  MAND_ID,
        VORMSCH_ID,
        ArrangementId,
        BERICHTSTERMIN,
        T1,
        BERICHT_VON,
        BERICHT_PER,
        MAHNUNG1,
        MAHNUNG2,
        MAHNUNG3,
        EINGANG_SDS,
        AUSGANG_SDS,
        VB_BESCHLUSS,
        RB_SB_BRZ,
        FRISTERSTRECKUNG,
        FALL_NR,
        BK_ID,
        MandateId,
        IstAktiv = CASE WHEN RankBericht = 1 
                     THEN CONVERT(BIT, 1) 
                     ELSE CONVERT(BIT, 0) 
                   END
FROM CTE

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

