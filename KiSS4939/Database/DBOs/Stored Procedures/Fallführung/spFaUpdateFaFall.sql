SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaUpdateFaFall;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt UPDATE auf FaFall aus, falls FaFall eine Tabelle ist, sonst wird ein 
            erfolgreiches UPDATE vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaUpdateFaFall …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaUpdateFaFall
(
  @FaFallID   int,
  @UserID     int,
  @BaPersonID int,
  @DatumVon   datetime,
  @DatumBis   datetime
)
AS
BEGIN
  -- nur in Tabelle updaten
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFall' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'UPDATE dbo.FaFall
	                   SET UserID = @UserID_,
					       BaPersonID = @BaPersonID_,
					       DatumVon = @DatumVon_,
					       DatumBis = @DatumBis_
					   WHERE FaFallID = @FaFallID_';
    SET @ParmDefinition = N'@FaFallID_ int, @UserID_ int, @BaPersonID_ int, @DatumVon_ datetime, @DatumBis_ datetime';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @FaFallID_ = @FaFallID, @UserID_ = @UserID, @BaPersonID_ = @BaPersonID, @DatumVon_ = @DatumVon, @DatumBis_ = @DatumBis ;
  END
  ELSE BEGIN
    SELECT NULL -- fake
  END
END;
GO
