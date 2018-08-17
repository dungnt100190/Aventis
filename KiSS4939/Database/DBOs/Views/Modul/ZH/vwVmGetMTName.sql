SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwVmGetMTName
GO

CREATE VIEW [dbo].[vwVmGetMTName]
AS

SELECT     LEI.BaPersonID, LEI.DatumVon, LEI.DatumBis, [User] = USR.NameVorname + ' (' + USR.OrgUnit + ')'
FROM         dbo.FaLeistung AS LEI
  INNER JOIN dbo.vwUser AS USR ON LEI.UserID = USR.UserID
WHERE     (LEI.FaProzessCode = 210)
