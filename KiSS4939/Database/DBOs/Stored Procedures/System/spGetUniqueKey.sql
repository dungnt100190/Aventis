SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spGetUniqueKey
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spGetUniqueKey.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:09 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get the next unique key for given key-name
    @KeyName: The special key-name to use for getting the next unique key
  -
  RETURNS: The next unique key for given key-name
  -
  TEST:    EXEC dbo.spGetUniqueKey 'DebiID'
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spGetUniqueKey.sql $
 * 
 * 3     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 2     28.10.08 16:41 Cjaeggi
 * Removed WITH (READUNCOMMITTED) because of critical and unique access to
 * data
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE dbo.spGetUniqueKey
(
  @KeyName VARCHAR(10)
)
AS
BEGIN
  DECLARE @NextInt  INT
  DECLARE @TryNr    TINYINT
  DECLARE @KeyFound BIT
  
  SET @TryNr = 0
  SET @KeyFound = 0

  WHILE (@TryNr < 5)
  BEGIN
    SET @TryNr = @TryNr + 1

    SET @NextInt = NULL

    SELECT @NextInt = NextID
    FROM dbo.XKeySource -- not here! WITH (READUNCOMMITTED)
    WHERE KeyName = @KeyName AND 
          NextID < LastID

    UPDATE dbo.XKeySource
    SET NextID = @NextInt + 1
    WHERE KeyName = @KeyName AND 
          NextID = @NextInt

    IF (@@ROWCOUNT <> 1)
    BEGIN
      -- update ist fehlgeschlagen
      CONTINUE
    END
    ELSE 
    BEGIN
      -- update hat geklappt, BelegNr kann verwendet werden
      SET @KeyFound = 1
      
      SELECT @NextInt
      
      BREAK
    END
  END

  -- validate if key was found
  IF (@KeyFound = 0)
  BEGIN
    DECLARE @msg VARCHAR(200)
    
    SET @msg = 'Es konnte kein Schlüssel für die Schlüsselart '''+@KeyName+''' gelöst werden'
    
    RAISERROR (@msg, 18, 1)
  END
END
GO