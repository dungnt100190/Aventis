SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmUser
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

CREATE VIEW dbo.vwTmUser
AS
SELECT
  UserID                  = USR.UserID,
  BenutzerNr              = USR.UserID,
  Login                   = USR.LogonName,
  Nachname                = USR.LastName,
  Vorname                 = USR.FirstName,
  Kuerzel                 = USR.ShortName,
  Telephon                = USR.Phone,
  EMail                   = USR.EMail,
  ErSieGross              = CASE USR.GenderCode
                              WHEN 1 THEN 'Er'
                              WHEN 2 THEN 'Sie'
                            END,
  FrauHerr                = CASE USR.GenderCode
                              WHEN 1 THEN 'Herr'
                              WHEN 2 THEN 'Frau'
                              ELSE 'Frau/Herr'
                            END,
  FrauHerrn               = CASE USR.GenderCode
                              WHEN 1 THEN 'Herrn'
                              WHEN 2 THEN 'Frau'
                              ELSE 'Frau/Herrn'
                            END,
  Briefanrede             = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, NULL),
  NameVorname             = USR.LastName + IsNull(', ' + USR.FirstName,''),
  NameVornameOhneKomma    = USR.LastName + IsNull(' ' + USR.FirstName,''),
  VornameName             = IsNull(USR.FirstName + ' ', '') + USR.LastName,
  Text1MitFmt             = USR.Text1,
  Text1OhneFmt            = USR.Text1, -- NORTF, 
  Text2MitFmt             = USR.Text2,
  Text2OhneFmt            = USR.Text2, -- NORTF, 
               
  AbteilungEMail          = ORG.EMail,
  AbteilungFax            = ORG.Fax,
               
  AbteilungName           = ORG.ItemName,
  AbteilungTelefon        = ORG.Phone,
  AbteilungTelFaxWWW      = ORG.WWW,
  AbteilungText1MitFmt    = ORG.Text1,
  AbteilungText1OhneFmt   = ORG.Text1,
  AbteilungText2MitFmt    = ORG.Text2,
  AbteilungText2OhneFmt   = ORG.Text2,
  AbteilungText3MitFmt    = ORG.Text3,
  AbteilungText3OhneFmt   = ORG.Text3,
  AbteilungText4MitFmt    = ORG.Text4,
  AbteilungText4OhneFmt   = ORG.Text4,
  AbteilungWWW            = ORG.WWW,

  CareOf                  = ADR.CareOf,
  AdressZusatz            = ADR.Zusatz,
  ZuhandenVon             = ADR.ZuhandenVon,
  Strasse                 = ADR.Strasse,
  HausNr                  = ADR.HausNr,
  Postfach                = ADR.Postfach,
  PostfachOhneNr          = ADR.PostfachOhneNr,
  PostfachTextD           = dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1),
  PLZ                     = ADR.PLZ,
  Ort                     = ADR.Ort,
  OrtschaftCode           = ADR.OrtschaftCode,
  Kanton                  = ADR.Kanton,
  Bezirk                  = ADR.Bezirk,
  --
  StrasseHausNr           = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
  OrtStrasse              = ISNULL(ADR.Ort,'') + ISNULL(', ' + ADR.Strasse + ISNULL(' ' + ADR.HausNr,''), ''),
  PLZOrt                  = ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
  --
  LandD                   = dbo.fnLandMLText(ADR.BaLandID, 1),
  LandF                   = dbo.fnLandMLText(ADR.BaLandID, 2),
  LandI                   = dbo.fnLandMLText(ADR.BaLandID, 3),
  LandE                   = dbo.fnLandMLText(ADR.BaLandID, 4),
  --
  AdresseEinzeilig        = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ', ' +
                            ISNULL(ADR.Zusatz + ', ', '') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr,'') + ', ', '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
                    
  AdresseEinzOhneName     = ISNULL(ADR.Zusatz + ', ','') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + ', ', '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
                    
  AdresseMehrzeilig       = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + CHAR(13) + CHAR(10) +
                            ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
                    
  AdresseMehrzOhneName    = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                            ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
  AbteilungLeitungInitialen = ISNULL(SUBSTRING (LEIT.FirstName, 1, 1) + '.', '')  + ISNULL(SUBSTRING (LEIT.LastName, 1, 1) + '.', '') 
FROM dbo.XUser USR WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID 
                                                        AND OUU.OrgUnitMemberCode = 2
  LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
  LEFT JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.UserID = USR.UserID
  LEFT JOIN dbo.XUser        LEIT WITH (READUNCOMMITTED) on ORG.ChiefID = LEIT.UserID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
