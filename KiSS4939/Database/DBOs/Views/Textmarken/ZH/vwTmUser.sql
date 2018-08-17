SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmUser
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmUser.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
  $Revision: 3 $
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
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmUser.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmUser]
AS

SELECT
  BenutzerNr					= USR.UserID,
  Logon							= USR.LogonName,
  Name							= USR.LastName,
  Vorname						= USR.FirstName,
  Kurzzeichen					= USR.ShortName,
  Telefon						= USR.Phone,
  EMail							= USR.EMail,
  Funktion						= USR.Funktion,
  FrauHerr						= CASE USR.GenderCode
								   WHEN 1 THEN 'Herr'
								   WHEN 2 THEN 'Frau'
								   END ,
  NameVorname					= USR.LastName + IsNull(', ' + USR.FirstName,''),
  NameVornameOhneKomma			= USR.LastName + IsNull(' ' + USR.FirstName,''),
  Text1MitFMT					= USR.Text1 ,
  Text1OhneFMT					= USR.Text1 ,
  Text2MitFMT					= USR.Text2 ,
  Text2OhneFMT					= USR.Text2 ,
  VornameName					= IsNull(USR.FirstName + ' ','') + USR.LastName,
  FrauHerrVornameName			= CASE USR.GenderCode WHEN 1 THEN 'Herr ' WHEN 2 THEN 'Frau ' ELSE '' END +
									IsNull(USR.FirstName + ' ','') + USR.LastName,
  OrgEinheitAdresseFeld			= ORG.Adresse,
  OrgEinheitAdresseFeldOhneStdZH = replace(convert(varchar(2000),Org.Adresse), 'Stadt Zürich' + char(13) + char(10),''),
  OrgEinheitAdresseEinzeilig	= replace(convert(varchar(2000),ORG.Adresse), char(13) + char(10), ', '),
  OrgEinheitAdresseEinzOhneStdZH = replace( 
									replace(convert(varchar(2000),ORG.Adresse), char(13) + char(10), ', '),
									'Stadt Zürich, ', ''),
  OrgEinheitEMail				= ORG.EMail,
  OrgEinheitFax					= ORG.Fax,
  OrgEinheitLogoMitFMT			= ORG.Logo,
  OrgEinheitName				= ORG.ItemName,
  OrgEinheitTelefon				= ORG.Phone,
  OrgEinheitTelFaxWWW			= IsNull('Tel. ' + ORG.Phone, '') + 
								  IsNull(char(13) + char(10) + 'Fax ' + ORG.Fax, '') + 
								  IsNull(char(13) + char(10) + ORG.WWW, '') /* +
								   char(13) + char(10) +
								   char(13) + char(10) +
								   'Ihre Kontaktperson' + char(13) + char(10) +
								   USR.LastName + IsNull(' ' + USR.FirstName,'') +
								   IsNull( char(13) + char(10) + 'Direktwahl ' + USR.Phone,'') +
								   IsNull( char(13) + char(10) + USR.EMail,'') */ ,
  OrgEinheitText1MitFMT			= ORG.Text1,
  OrgEinheitText1ohneFMT		= ORG.Text1,
  OrgEinheitText2MitFMT			= ORG.Text2,
  OrgEinheitText2ohneFMT		= ORG.Text2,
  OrgEinheitText3MitFMT			= ORG.Text3,
  OrgEinheitText3ohneFMT		= ORG.Text3,
  OrgEinheitText4MitFMT			= ORG.Text4,
  OrgEinheitText4ohneFMT		= ORG.Text4,
  OrgEinheitWWW					= ORG.WWW,

  StellenleiterVornameName		= IsNull(STL.FirstName + ' ','') + STL.LastName,
  StellenleiterStvVornameName	= IsNull(STV.FirstName + ' ','') + STV.LastName,

  Sozialzentrum					= SZ.Text,
  SozialzentrumKurz				= SZ.ShortText,
  SozialzentrumCode				= SZ.Code,
  SozialzentrumLtgAnrede		= CASE ZL.GenderCode
									WHEN 1 THEN 'Herr'
									WHEN 2 THEN 'Frau'
								  END,
  SozialzentrumLtg				=ZL.FirstName +IsNull(' ' + ZL.LastName,''),
  SozialzentrumAdresseOhneStdZH = replace(convert(varchar(2000),SZ1.Adresse), 'Stadt Zürich' + char(13) + char(10),''),
  SozialzentrumAdresseEinzeilig = replace(replace(convert(varchar(2000),SZ1.Adresse), char(13) + char(10), ', '), 
									'Stadt Zürich, ','')


FROM dbo.XUser USR WITH (READUNCOMMITTED)
     LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                    OUU.OrgUnitMemberCode = 2
     LEFT OUTER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
     LEFT OUTER JOIN dbo.XUser         STL WITH (READUNCOMMITTED) ON STL.UserID = ORG.ChiefID
     LEFT OUTER JOIN dbo.XUser         STV WITH (READUNCOMMITTED) ON STV.UserID = ORG.StellvertreterID

     -- Bestimmung Sozialzentrum (analog vwUser)
     LEFT JOIN dbo.XOrgUnit      PAR1 WITH (READUNCOMMITTED) ON PAR1.OrgUnitID = ORG.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR2 WITH (READUNCOMMITTED) ON PAR2.OrgUnitID = PAR1.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR3 WITH (READUNCOMMITTED) ON PAR3.OrgUnitID = PAR2.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR4 WITH (READUNCOMMITTED) ON PAR4.OrgUnitID = PAR3.ParentID
     LEFT JOIN dbo.XLOVCode      SZ   WITH (READUNCOMMITTED) ON SZ.LOVName = 'FaSozialzentrum' AND
                                     CONVERT(int,SZ.Value1) in (ORG.OrgUnitID,PAR1.OrgUnitID,PAR2.OrgUnitID,PAR3.OrgUnitID,PAR4.OrgUnitID)
	 -- Leitung Sozialzentrum
	 LEFT JOIN dbo.XOrgUnit		 SZ1  WITH (READUNCOMMITTED) ON SZ1.OrgUnitID = CONVERT(int,SZ.Value1)
	 LEFT JOIN dbo.Xuser		 ZL   WITH (READUNCOMMITTED) ON ZL.Userid = SZ1.ChiefID
