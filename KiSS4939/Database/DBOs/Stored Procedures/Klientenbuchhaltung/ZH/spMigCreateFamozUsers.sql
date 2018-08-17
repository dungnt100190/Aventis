SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spMigCreateFamozUsers
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
CREATE PROCEDURE dbo.spMigCreateFamozUsers
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
@EMail varchar(50)



DECLARE Users_Cursor CURSOR FOR
SELECT OldLogonName, NewLogonName, FirstName, LastName, Phone, EMail
FROM MigReplaceUsers
ORDER BY SortKey

OPEN Users_Cursor;
FETCH NEXT FROM Users_Cursor INTO @Old , @New , @FirstName , @LastName , @Phone, @EMail
WHILE @@FETCH_STATUS = 0
  BEGIN
    UPDATE XUser
    SET LogonName = @New, LastName = @LastName, FirstName = @FirstName,
      Phone = @Phone, EMail = @EMail
    WHERE LogonName = @Old
	IF @@ROWCOUNT = 1
		PRINT 'Successfully created user ' + @FirstName + ' '+ @LastName
    ELSE
		PRINT 'Error: could not create user ' + @FirstName + ' '+ @LastName

	FETCH NEXT FROM Users_Cursor INTO @Old , @New , @FirstName , @LastName , @Phone, @EMail
   END;
CLOSE Users_Cursor;
DEALLOCATE Users_Cursor;

END

