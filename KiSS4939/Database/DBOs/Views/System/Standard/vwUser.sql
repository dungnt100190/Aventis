SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwUser
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get data for user
  -
  RETURNS: Userdata with some additional columns and information
  -
  TEST:    SELECT TOP 30 * FROM dbo.vwUser
=================================================================================================*/
CREATE VIEW dbo.vwUser
AS
SELECT 
  USR.UserID,
  USR.LogonName, 
  USR.FirstName, 
  USR.LastName, 
  USR.ShortName, 
  USR.IsUserAdmin, 
  USR.IsUserBIAGAdmin,
  USR.PasswordHash, 
  USR.IsLocked, 
  USR.GenderCode, 
  USR.LanguageCode, 
  USR.ModulID, 
  USR.isMandatsTraeger, 
  USR.Phone, 
  USR.EMail, 
  USR.ChiefID, 
  USR.PermissionGroupID, 
  USR.GrantPermGroupID, 
  USR.Text1, 
  USR.Text2, 
  USR.JobPercentage, 
  USR.HoursPerYearForCaseMgmt, 
  USR.XUserTS, 
  USR.XProfileID,
  NameVorname             = USR.LastName + ISNULL(', ' + USR.FirstName, ''),
  NameVornameOhneKomma    = USR.LastName + ISNULL(' ' + USR.FirstName, ''),
  VornameName             = ISNULL(USR.FirstName + ' ', '') + USR.LastName,
  LogonNameVornameOrgUnit = USR.LogonName + ' - ' + USR.LastName + ISNULL(', ' + USR.FirstName, '') + ISNULL(' (' + ORG.ItemName + ')', ''),
  OUU.OrgUnitID,
  ORG.ParentID,
  OrgEinheitName          = ORG.ItemName,
  OrgUnit                 = ORG.ItemName, -- von zh, wegen pendenzverwaltung
  OrgEinheitEmail         = ORG.EMail,
  OrgEinheitFax           = ORG.Fax,
  OrgEinheitWWW           = ISNULL(ORG.WWW, ORG.Internet),
  DisplayText             = USR.LogonName + ' - ' + USR.LastName + ISNULL(', ' + USR.FirstName, '') + ISNULL(' (' + ORG.ItemName + ')', '')
FROM dbo.XUser USR WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND 
                                                            OUU.OrgUnitMemberCode = 2
  LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
GO