SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbGetBelegNr
GO
/*===============================================================================================
  $Revision: 5$
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

CREATE PROCEDURE dbo.spKbGetBelegNr
	@Belegart varchar(10)
AS
BEGIN

  DECLARE @NextInt      bigint,
          @TryNr        tinyint,
          @BelegNrFound bit
  SET @TryNr = 0
  SET @BelegNrFound = 0

  WHILE @TryNr < 5 BEGIN
    SET @TryNr = @TryNr + 1

    --BEGIN TRANSACTION

    SET @NextInt = NULL

    -- Zuerst die verlorenen Belegnummern verwenden
    SELECT TOP 1 @NextInt = BelegNr
    FROM dbo.PscdVerloreneBelegNummern  VBN
      INNER JOIN dbo.PscdKeySource      SRC ON SRC.KeyName = @Belegart AND SRC.NumberCategory = 'Beleg'
    WHERE BelegNr BETWEEN SRC.FirstID AND SRC.LastID
    ORDER BY BelegNr ASC

    IF( @NextInt IS NOT NULL ) BEGIN
      -- Die Belegnummer darf erst verwendet werden, wenn sie auch gelöscht werden konnte (jemand anderes könnte etwas schneller gewesen sein)
      DELETE FROM PscdVerloreneBelegNummern WHERE BelegNr = @NextInt
      IF @@ROWCOUNT <> 1 BEGIN
        --ROLLBACK TRANSACTION
        CONTINUE
      END
      ELSE BEGIN
        --COMMIT TRANSACTION
        SET @BelegNrFound = 1
        SELECT @NextInt
        BREAK
      END
    END

    SELECT @NextInt = NextID
    FROM dbo.PscdKeySource
    WHERE KeyName = @Belegart

    UPDATE PscdKeySource
    SET NextID = @NextInt + 1
    WHERE KeyName = @Belegart AND NextID = @NextInt

    IF( @@ROWCOUNT <> 1 )
    BEGIN
      -- update ist fehlgeschlagen
      --ROLLBACK TRANSACTION
      CONTINUE
    END
    ELSE BEGIN 
      -- update hat geklappt, BelegNr kann verwendet werden
      --COMMIT TRANSACTION
      SET @BelegNrFound = 1
      SELECT @NextInt
      BREAK
    END
  END

  IF @BelegNrFound = 0 BEGIN
    DECLARE @msg varchar(200)
    SET @msg = 'Es konnte keine Belegnummer für die Belegart '''+@Belegart+'''gelöst werden'
    RAISERROR ( @msg, 18, 1 )    
  END
END

