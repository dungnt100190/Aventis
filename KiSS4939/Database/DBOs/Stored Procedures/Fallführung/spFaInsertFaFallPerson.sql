SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaInsertFaFallPerson;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt INSERT in FaFallPerson aus, falls FaFallPerson eine Tabelle ist, sonst wird ein 
            erfolgreiches INSERT vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaInsertFaFallPerson …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaInsertFaFallPerson
(
  @FaFallID   int,
  @BaPersonID int,
  @DatumVon   datetime,
  @DatumBis   datetime
)
AS
BEGIN
  -- nur in Tabelle inserten
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFallPerson' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'INSERT INTO dbo.FaFallPerson(FaFallID, BaPersonID, DatumVon, DatumBis)
                       VALUES (@FaFallID_, @BaPersonID_, @DatumVon_, @DatumBis_)
                       
                       SELECT FaFallPersonID = SCOPE_IDENTITY()';
    SET @ParmDefinition = N'@FaFallID_ int, @BaPersonID_ int, @DatumVon_ datetime, @DatumBis_ datetime';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @FaFallID_ = @FaFallID, @BaPersonID_ = @BaPersonID, @DatumVon_ = @DatumVon, @DatumBis_ = @DatumBis;
  END
  ELSE BEGIN
    SELECT FaFallPersonID = NULL -- fake
  END
END;
GO
