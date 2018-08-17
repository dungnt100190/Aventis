SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject USR
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Search for users using either name, login name or ID
    @UserSearchValue: .
  -
  RETURNS: .
=================================================================================================
  TEST: USR biag
=================================================================================================*/
CREATE PROCEDURE [dbo].[USR]
(
  @UserSearchValue VARCHAR(50)
)
AS
BEGIN
  SELECT *
  FROM dbo.XUser
  WHERE LastName LIKE '%' + @UserSearchValue + '%'
     OR FirstName LIKE '%' + @UserSearchValue + '%'
     OR LogonName LIKE  '%' + @UserSearchValue + '%'
     OR ShortName LIKE  '%' + @UserSearchValue + '%'
     OR CONVERT(VARCHAR, UserID) LIKE '%' + @UserSearchValue + '%'
  ORDER BY LastName, FirstName;
END;
GO
