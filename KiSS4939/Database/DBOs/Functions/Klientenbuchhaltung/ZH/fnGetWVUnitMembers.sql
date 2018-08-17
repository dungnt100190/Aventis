SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetWVUnitMembers
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

CREATE FUNCTION dbo.fnGetWVUnitMembers
 (@WhWVEinheitID int,
  @BaPersonID_Exclude int)
 RETURNS varchar(1000)
AS
BEGIN

DECLARE @Name varchar(100)
DECLARE @Names varchar(1000)

DECLARE cNames CURSOR FAST_FORWARD FOR
  SELECT PRS.VornameName
  FROM dbo.WhWVEinheitMitglied WEM WITH (READUNCOMMITTED) 
    INNER JOIN dbo.vwPerson    PRS ON PRS.BaPersonID = WEM.BaPersonID
  WHERE WhWVEinheitID = @WhWVEinheitID AND WEM.BaPersonID <> IsNull(@BaPersonID_Exclude,-1)
OPEN cNames

WHILE 1=1
BEGIN
  FETCH NEXT FROM cNames INTO @Name
  IF @@FETCH_STATUS <> 0 BREAK

  SET @Names = IsNull(@Names + ', ', '') + @Name
END
CLOSE cNames
DEALLOCATE cNames

RETURN @Names

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
