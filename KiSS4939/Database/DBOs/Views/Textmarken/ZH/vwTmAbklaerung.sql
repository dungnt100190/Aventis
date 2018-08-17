SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmAbklaerung;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmAbklaerung
AS

SELECT
  FaAbklaerungID,
  NameVorname              = CASE WHEN PRS.Name IS NULL OR PRS.Name = '' THEN '' ELSE PRS.Name END
                             + CASE WHEN PRS.Vorname IS NULL OR PRS.Vorname = '' THEN '' ELSE ', ' + PRS.Vorname END
                             + CASE WHEN PRS.Vorname2 IS NULL OR PRS.Vorname2 = '' THEN '' ELSE ' ' + PRS.Vorname2 END,
  [BeginnAbklaerung]       = CONVERT(varchar, ABK.AuftragDatum, 104),
  [Ausloeser]              = dbo.fnLOVText('FaAbklaerungAusloeser', ABK.AusloeserCode),
  [Abklaerungsbericht]     = CONVERT(varchar, ABK.AbklaerungsberichtBeendetDatum, 104),
  [Fallverantwortlicher]   = CASE WHEN USR.FirstName IS NULL OR USR.FirstName = '' THEN '' ELSE USR.FirstName END 
                             + CASE WHEN USR.LastName IS NULL OR USR.LastName = '' THEN '' ELSE ' ' + USR.LastName END,
  [QTFallverantwortlicher] = CASE WHEN OUN.ItemName IS NULL OR OUN.ItemName = '' THEN '' ELSE OUN.ItemName END,
  [CoFallfuehrung]         = CASE WHEN USR2.FirstName IS NULL OR USR2.FirstName = '' THEN '' ELSE USR2.FirstName END
                             + CASE WHEN USR2.LastName IS NULL OR USR2.LastName = '' THEN '' ELSE ' ' + USR2.LastName END,
  [QTCOFallfuehrung]       = CASE WHEN OUN2.ItemName IS NULL OR OUN2.ItemName = '' THEN '' ELSE OUN2.ItemName END
FROM dbo.FaAbklaerung ABK WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.XUser USR  WITH (READUNCOMMITTED) ON USR.UserID = ABK.UserID
  LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
  LEFT OUTER JOIN dbo.XOrgUnit OUN WITH (READUNCOMMITTED) ON OUN.OrgUnitID = OUU.OrgUnitID
  LEFT OUTER JOIN dbo.XUser USR2 WITH (READUNCOMMITTED) ON USR2.UserID = ABK.CoUserID
  LEFT OUTER JOIN dbo.XOrgUnit_User OUU2 WITH (READUNCOMMITTED) ON OUU2.UserID = USR2.UserID AND OUU2.OrgUnitMemberCode = 2
  LEFT OUTER JOIN dbo.XOrgUnit OUN2 WITH (READUNCOMMITTED) ON OUN2.OrgUnitID = OUU2.OrgUnitID
  LEFT OUTER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ABK.BaPersonID
WHERE ABK.AusloeserCode <> -1 --Platzhalter für Tree soll nicht angezeigt werden.
GO
GRANT SELECT ON [dbo].[vwTmAbklaerung] TO [tools_access]