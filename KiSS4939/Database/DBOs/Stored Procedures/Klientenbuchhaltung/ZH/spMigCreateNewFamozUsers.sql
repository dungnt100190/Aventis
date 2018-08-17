SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spMigCreateNewFamozUsers
GO
/*===============================================================================================
  $Revision: 1$
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
CREATE PROCEDURE dbo.spMigCreateNewFamozUsers
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  DECLARE @Old varchar(10),
  @New varchar(10),
  @FirstName varchar(50),
  @LastName varchar(50),
  @Phone varchar(20),
  @EMail varchar(50),
  @UserID int



  DECLARE Users_Cursor CURSOR FOR
    SELECT OldLogonName, NewLogonName, FirstName, LastName, Phone, Email 
    FROM dbo.MigReplaceUsers WITH (READUNCOMMITTED)
    WHERE LEN(NewLogonName) = 6 AND NewLogonName NOT IN (SELECT LogonName FROM dbo.XUser WITH (READUNCOMMITTED))
    ORDER BY SortKey

  OPEN Users_Cursor;
  FETCH NEXT FROM Users_Cursor INTO @Old , @New , @FirstName , @LastName , @Phone, @EMail
  WHILE @@FETCH_STATUS = 0
    BEGIN

      INSERT INTO XUser (LogonName,LastName,FirstName,Phone,EMail,IsUserAdmin,PermissionGroupID)
      VALUES( @New, @LastName, @FirstName, @Phone, @EMail,1,11 )

      SET @UserID = SCOPE_IDENTITY()
    IF @@ROWCOUNT = 1 BEGIN
      PRINT 'Successfully created user ' + @FirstName + ' '+ @LastName
          INSERT INTO dbo.XOrgUnit_User (OrgUnitID, UserID, OrgUnitMemberCode,MayInsert, MayUpdate, MayDelete)
          VALUES (68,@UserID,2/*Member*/,1,1,1)
      END
      ELSE
      PRINT 'Error: could not create user ' + @FirstName + ' '+ @LastName


    FETCH NEXT FROM Users_Cursor INTO @Old , @New , @FirstName , @LastName , @Phone, @EMail
     END;
  CLOSE Users_Cursor;
  DEALLOCATE Users_Cursor;

END

