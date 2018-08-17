SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwUserSimple;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This is a simple view of the table XUser. The aim of this view is to be faster as
           the vwUser.
           Joins are not allowed in this view, in order to keep it fast!
  -
  RETURNS: A few amount of information about a user. 
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwUserSimple;
=================================================================================================*/

CREATE VIEW dbo.vwUserSimple
AS
SELECT
  USR.UserID,
  USR.LogonName,
  USR.LastName,
  USR.FirstName,
  NameVorname            = USR.LastName + IsNull(', ' + USR.FirstName, ''),
  DisplayText            = USR.LastName + IsNull(', ' + USR.FirstName, '') + ' - ' + USR.LogonName
FROM dbo.XUser USR WITH (READUNCOMMITTED);
GO
