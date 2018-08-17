SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKompetenzstufe;
GO
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Berechnet die Kompetenzstufe für die Abfrage Bewilligung in ZH.
    @UserID: Die Userid.
  -
  RETURNS: Die Kompetenzstufe          
           0: Sachbearbeiter (Keine Fremdkompetenz und keine Eigenkompetenz) oder User existiert nicht
           1: Sozialarbeiter (Fremdkompetenz und Eigenkompetenz vorhanden)
           2: Quartierteamleiter oder Quartierteamleiter Stv. (Leiter oder Stv. einer Organisationseinheit XOrgUnit)
           3: Zentrumsleiter oder Zentrumsleiter Stv. (Leiter oder Stv. einer Organisationseinheit XOrgUnit, 
              welche dem Quartierteam übergeordnet ist)
=================================================================================================
  TEST:    SELECT dbo.fnKompetenzstufe(…);
=================================================================================================*/

CREATE FUNCTION dbo.fnKompetenzstufe
(
  @UserID INT
)
RETURNS INT
AS 
BEGIN

  -- Wenn @UserID null ist, dann keine Kompetenz
  IF @UserID IS NULL
  BEGIN
    RETURN 0;
  END

  DECLARE @PermissionGroupID_SB INT;
  DECLARE @IsSozialarbeiter BIT;
  DECLARE @IsStellenleiter  BIT;
  DECLARE @IsZentrumsleiter BIT;

  SET @PermissionGroupID_SB = ISNULL(CONVERT(INT, dbo.fnXConfig('System\WH\Kompetenzgruppe_Sachbearbeiter', GETDATE())), -1);

  SELECT
    @IsSozialarbeiter = CASE
                          WHEN USR.PermissionGroupID IS NOT NULL AND USR.GrantPermGroupID IS NOT NULL
                               AND (USR.PermissionGroupID <> @PermissionGroupID_SB OR USR.GrantPermGroupID <> @PermissionGroupID_SB) THEN 1
                          ELSE 0
                        END,
    @IsStellenleiter  = CASE
                          WHEN ORG.ChiefID = @UserID OR ORG.StellvertreterID = @UserID THEN 1
                          ELSE 0
                        END,
    @IsZentrumsleiter = CASE
                          WHEN ORG_PARENT.OrgUnitID = dbo.fnXConfig('System\Basis\QuartiertteamsAbeilungsID', GETDATE())
                               AND (ORG.ChiefID = @UserID OR ORG.StellvertreterID = @UserID) THEN  1
                          ELSE  0
                        END
  FROM dbo.XUser                 USR        WITH(READUNCOMMITTED)
    INNER JOIN dbo.XOrgUnit_User OUU        WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
    INNER JOIN dbo.XOrgUnit      ORG        WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
    LEFT  JOIN dbo.XOrgUnit      ORG_PARENT WITH(READUNCOMMITTED) ON ORG_PARENT.OrgUnitID = ORG.ParentID
  WHERE USR.UserID = @UserID; 

  IF @IsZentrumsleiter = 1 RETURN 3;
  IF @IsStellenleiter  = 1 RETURN 2;
  IF @IsSozialarbeiter = 1 RETURN 1;

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO
