SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_ABTEILUNG]'))
BEGIN 
  EXECUTE dbo.spDropObject vwVIS_ABTEILUNG;
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
CREATE VIEW dbo.vwVIS_ABTEILUNG
AS
SELECT Waisenrat     = OrphanConcilGivenname + ' ' + OrphanConcilSurname + ', KESB Mitglied',
       Telefon       = OrphanConcilPhoneExternal,
       Abteilung     = DepartmentShortCut,
       AbteilungLang = DepartmentName,
       Id            = Id
FROM [{VisServerName}].[{VisDBName}].[kiss].[Department]

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

