SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_MANDATSTRAEGER_SIMPLE]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_MANDATSTRAEGER_SIMPLE;
END;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: einfache View um den Name eines Mandatsträger zu haben
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwVIS_MANDATSTRAEGER_SIMPLE
AS
SELECT PERS_NR          = MAN.PersonNumber,
       NAME             = MAN.MandateOfficerSurname,
       VORNAME          = MAN.MandateOfficerGivenName,
       NameVorname      = MAN.MandateOfficerSurname + ', ' + MAN.MandateOfficerGivenName,
       CATEGORY         = MAN.MandateOfficerCategory,
       M_ERNENN_DT      = MAN.DateOfNomination,
       M_AUFHEB_DT      = MAN.DateOfDismissal,
       MandateId        = MAN.Id
FROM [{VisServerName}].[{VisDBName}].[kiss].[Mandate] MAN

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

