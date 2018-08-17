SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetLastFirstName;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Combines LastName with FirstName as "LastName, FirstName". If UserID is given, the
           function will search LastName and FirstName from UserID, otherwise, it will try to
           combine from given parameters.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @UserID:    The user to get LastName and FirstName from
    @LastName:  The LastName to use if no UserID is given
    @FirstName: The FirstName to use if no UserID is given
  -
  RETURNS: "LastName, FirstName", or just "LastName" or "FirstName" depending on values
=================================================================================================
  TEST:    SELECT dbo.fnGetLastFirstName(2, NULL, NULL)
           SELECT dbo.fnGetLastFirstName(NULL, 'LastName', 'FirstName')
=================================================================================================*/

CREATE FUNCTION dbo.fnGetLastFirstName
(
  @UserID INT,
  @LastName VARCHAR(255),
  @FirstName VARCHAR(255)
)
RETURNS VARCHAR(500) WITH SCHEMABINDING
AS
BEGIN
  -----------------------------------------------------------------------------
  -- if we have a user id, we query values from table XUser
  -----------------------------------------------------------------------------
  IF (@UserID IS NOT NULL)
  BEGIN
    SELECT @LastName = USR.LastName,
           @FirstName = USR.FirstName
    FROM dbo.XUser USR WITH (READUNCOMMITTED)
    WHERE UserID = @UserID;
  END;
  
  -----------------------------------------------------------------------------
  -- trim
  -----------------------------------------------------------------------------
  SELECT @LastName  = LTRIM(RTRIM(@LastName)),
         @FirstName = LTRIM(RTRIM(@FirstName));
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@LastName = '')
  BEGIN
    SELECT @LastName = NULL;
  END;
  
  IF (@FirstName = '')
  BEGIN
    SELECT @FirstName = NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- combine data and return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@LastName + ISNULL(', ' + @FirstName, ''), ISNULL(@FirstName, ''));
END;
GO