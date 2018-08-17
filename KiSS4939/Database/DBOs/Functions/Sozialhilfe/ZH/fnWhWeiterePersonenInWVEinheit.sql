SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhWeiterePersonenInWVEinheit
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

CREATE FUNCTION dbo.fnWhWeiterePersonenInWVEinheit
  (@WhWVEinheitID int,
   @UTBaPersonID  int)
  RETURNS varchar(500)
AS 

BEGIN
  DECLARE @Names varchar(500),
          @Name varchar(100),
          @First bit,
          @BaPersonID int
  SET @First = 1

  DECLARE name_cursor CURSOR FAST_FORWARD FOR
    SELECT PRS.Name + ',  ' + PRS.Vorname, WVM.BaPersonID
    FROM dbo.WhWVEinheitMitglied WVM WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BaPerson    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = WVM.BaPersonID
    WHERE WhWVEinheitID = @WhWVEinheitID

  OPEN name_cursor
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM name_cursor INTO @Name, @BaPersonID
    IF @@FETCH_STATUS != 0 BREAK
    IF @BaPersonID = @UTBaPersonID CONTINUE

    IF( @First <> 1 )
      SET @Names = @Names + ' / ' + @Name
    ELSE
    BEGIN
      SET @First = 0
      SET @Names = @Name
    END
  END
  CLOSE name_cursor
  DEALLOCATE name_cursor
--print @Names

  RETURN @Names

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
