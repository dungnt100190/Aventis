SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_OPERATION]'))
BEGIN 
  EXECUTE dbo.spDropObject vwVIS_OPERATION;
END;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwVIS_OPERATION
AS
SELECT 
  MandateReportInfoId = MandateReportInfoId,
  GenemigungVB        = VbDecision
FROM [{VisServerName}].[{VisDBName}].[kiss].[Operation]

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

