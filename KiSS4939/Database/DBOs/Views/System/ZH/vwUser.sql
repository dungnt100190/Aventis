SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwUser;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
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
  USR.PasswordHash,
  USR.IsLocked,
  USR.GenderCode,
  USR.LanguageCode,
  USR.ModulID,
  USR.UserProfileCode,
  USR.isMandatsTraeger,
  USR.Phone,
  USR.EMail,
  USR.ChiefID,
  USR.PermissionGroupID,
  USR.GrantPermGroupID,
  USR.JobPercentage,
  USR.HoursPerYearForCaseMgmt,
  USR.PrimaryUserID,
  USR.Funktion,
  USR.SachbearbeiterID,
  ORG.OrgUnitID,
  OrgUnit                = ORG.ItemName,
  OrgUnitShort           = IsNull(QUOE.ShortText, ORG.ItemName),
  BenutzerNr             = USR.UserID,
  Logon                  = USR.LogonName,
  Name                   = USR.LastName,
  Vorname                = USR.FirstName,
  Kurzzeichen            = USR.ShortName,
  Telefon                = USR.Phone,
  FrauHerr               = CASE USR.GenderCode
                             WHEN 1 THEN 'Herr'
                             WHEN 2 THEN 'Frau'
                           END ,
  NameVorname            = USR.LastName + IsNull(', ' + USR.FirstName, ''),
  NameVornameOhneKomma   = USR.LastName + IsNull(' ' + USR.FirstName, ''),
  Text1RTF               = USR.Text1,
  USR.Text1,
  Text2RTF               = USR.Text2,
  USR.Text2,
  VornameName            = IsNull(USR.FirstName + ' ','') + USR.LastName,
  OrgEinheitAdresseFeld  = ORG.Adresse,
  OrgEinheitEMail        = ORG.EMail,
  OrgEinheitFax          = ORG.Fax,
  OrgEinheitLogoRTF      = ORG.Logo,
  OrgEinheitName         = ORG.ItemName,
  OrgEinheitTelefon      = ORG.Phone,
  OrgEinheitTelFaxWWW    = ORG.WWW,
  OrgEinheitText1RTF     = ORG.Text1,
  OrgEinheitText1        = ORG.Text1,
  OrgEinheitText2RTF     = ORG.Text2,
  OrgEinheitText2        = ORG.Text2,
  OrgEinheitText3RTF     = ORG.Text3,
  OrgEinheitText3        = ORG.Text3,
  OrgEinheitText4RTF     = ORG.Text4,
  OrgEinheitText4        = ORG.Text4,
  OrgEinheitWWW          = ORG.WWW,
  Sozialzentrum          = SZ.Text,
  SozialzentrumKurz      = SZ.ShortText,
  SozialzentrumCode      = SZ.Code,
  StellenleiterID        = ORG.ChiefID,
  StellenleiterName      = STL.LastName + IsNull(', ' + STL.FirstName,''),
  StellenleiterLogon     = STL.LogonName,
  StellenleiterStvID     = ORG.StellvertreterID,
  StellenleiterStvName   = STV.LastName + IsNull(', ' + STV.FirstName,''),
  StellenleiterStvLogon  = STV.LogonName,
  LogonNameVornameOrgUnit = USR.LogonName + ' - ' + USR.LastName + IsNull(', ' + USR.FirstName, '')
                            + IsNull(' (' + ORG.ItemName + ')', ''),
  DisplayText             = USR.LogonName + ' - ' + USR.LastName + IsNull(', ' + USR.FirstName, '')
                            + IsNull(' (' + ORG.ItemName + ')', '')
FROM dbo.XUser USR WITH (READUNCOMMITTED)
     -- OrgUnit
     LEFT JOIN dbo.XOrgUnit_User OUU  WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                     OUU.OrgUnitMemberCode = 2
     LEFT JOIN dbo.XOrgUnit      ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
     LEFT JOIN dbo.XLOVCode      QUOE   WITH (READUNCOMMITTED) ON QUOE.LOVName = 'QuOrgUnitTeam' AND
                                     QUOE.Code = OUU.OrgUnitID

     -- Stellenleiter/Stv.
     LEFT JOIN dbo.XUser        STL  WITH (READUNCOMMITTED) ON STL.UserID = ORG.ChiefID
     LEFT JOIN dbo.XUser        STV  WITH (READUNCOMMITTED) ON STV.UserID = ORG.StellvertreterID

     -- Bestimmung Sozialzentrum
     LEFT JOIN dbo.XOrgUnit      PAR1 WITH (READUNCOMMITTED) ON PAR1.OrgUnitID = ORG.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR2 WITH (READUNCOMMITTED) ON PAR2.OrgUnitID = PAR1.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR3 WITH (READUNCOMMITTED) ON PAR3.OrgUnitID = PAR2.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR4 WITH (READUNCOMMITTED) ON PAR4.OrgUnitID = PAR3.ParentID
     LEFT JOIN dbo.XLOVCode      SZ   WITH (READUNCOMMITTED) ON SZ.LOVName = 'FaSozialzentrum' AND
                                     CONVERT(int,SZ.Value1) in (ORG.OrgUnitID,PAR1.OrgUnitID,PAR2.OrgUnitID,PAR3.OrgUnitID,PAR4.OrgUnitID)

GO
GRANT SELECT ON [dbo].[vwUser] TO [tools_access]