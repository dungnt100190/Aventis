SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaInsertFaFall;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt INSERT in FaFall aus, falls FaFall eine Tabelle ist, sonst wird ein 
            erfolgreiches INSERT vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaInsertFaFall …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaInsertFaFall
(
  @UserID     int,
  @BaPersonID int,
  @DatumVon   datetime,
  @DatumBis   datetime
)
AS
BEGIN
  -- nur in Tabelle inserten
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFall' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'INSERT INTO dbo.FaFall(UserID, BaPersonID, DatumVon, DatumBis)
                       VALUES (@UserID_, @BaPersonID_, @DatumVon_, @DatumBis_)
                       
                       SELECT FaFallID = SCOPE_IDENTITY()';
    SET @ParmDefinition = N'@UserID_ int, @BaPersonID_ int, @DatumVon_ datetime, @DatumBis_ datetime';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @UserID_ = @UserID, @BaPersonID_ = @BaPersonID, @DatumVon_ = @DatumVon, @DatumBis_ = @DatumBis;
  END
  ELSE BEGIN
    SELECT FaFallID = @BaPersonID -- fake
  END
END;
GO
