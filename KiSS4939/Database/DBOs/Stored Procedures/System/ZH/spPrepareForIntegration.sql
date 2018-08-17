SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE spDropObject spPrepareForIntegration
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:       
  -
  RETURNS:       
  -
=================================================================================================
  TEST:          
=================================================================================================*/

CREATE  PROCEDURE dbo.spPrepareForIntegration
AS


DECLARE @UserID  int
SELECT @UserID = UserID FROM XUser WHERE LogonName = 'sozkwa'


UPDATE XPermissionGroup
  SET PermissionGroupName = 'Sozialarbeiter/in'
WHERE PermissionGroupID = 11

-- eigenkompetenz
UPDATE XUser
  SET PermissionGroupID = 11  -- Sozialarbeiter/in

-- fremdkompetenz
UPDATE XUser
  SET GrantPermGroupID = 4    -- Stellenleiter/in
WHERE UserID = @UserID        -- Karin Wälti

-- sozkwa als Leiter aller Stellen einsetzen
UPDATE XOrgUnit
  SET ChiefID = @UserID       -- Karin Wälti
WHERE ParentID IS NOT NULL AND ChiefID IS NULL


-- xconfig setzen
UPDATE XConfig
  SET ValueVarchar = 'http://10.1.100.114/AlphaSvc/Integration/AlphaSvc.asmx'
WHERE KeyPath  = 'System\Schnittstellen\Alpha\AlphaWebServiceURL'

UPDATE XConfig
  SET ValueVarchar = 'http://10.1.100.114/PSCDSvc/Integration/PSCDSvc.asmx'
WHERE KeyPath  = 'System\Schnittstellen\PSCD\PSCDWebServiceURL'

UPDATE XConfig
  SET ValueVarchar = ''
WHERE KeyPath  = 'System\Schnittstellen\Alpha\Proxy'

UPDATE XConfig
  SET ValueVarchar = ''
WHERE KeyPath  = 'System\Schnittstellen\PSCD\Proxy'

TRUNCATE TABLE PscdVerloreneBelegnummern


