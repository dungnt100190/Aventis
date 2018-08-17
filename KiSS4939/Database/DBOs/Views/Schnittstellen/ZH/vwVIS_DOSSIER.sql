SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_DOSSIER]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_DOSSIER;
END;
GO
/*===============================================================================================
  $Revision: 6 $
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

CREATE VIEW dbo.vwVIS_DOSSIER
AS
SELECT FALL_NR          = DOS.Number,
       DepartmentId     = DOS.ResponsibleDepartmentId,
       ABTEILUNG        = DEP.DepartmentShortCut,
       ZIP_NR           = REPLACE(DOS.MainPersonZipCode, '.', ''),
       NAME             = DOS.MainPersonSurname,
       ALLIANZNAME      = DOS.MainPersonAllianceName,
       VORNAME          = DOS.MainPersonGivenName,
       G_DAT            = DOS.MainPersonDateOfBirth,
       H_ORT            = DOS.MainPersonNativePlace,
       ZIV              = DOS.MainPersonMaritalState,
       AHV_NR           = REPLACE(DOS.MainPersonAhvNumber, '.', ''),
       SEX              = DOS.MainPersonGender,
       WMA_STR          = DOS.MainPersonStreet,
       WMA_POSTLAGERND  = DOS.MainPersonPosteRestante,
       WMA_PLZ          = DOS.MainPersonZip,
       WMA_ORT          = DOS.MainPersonCity,
       Id               = DOS.Id,
       RespDepId        = DOS.ResponsibleDepartmentId
FROM [{VisServerName}].[{VisDBName}].[kiss].[Dossier]            DOS
  INNER JOIN [{VisServerName}].[{VisDBName}].[kiss].[Department] DEP ON DEP.Id = DOS.ResponsibleDepartmentId

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


