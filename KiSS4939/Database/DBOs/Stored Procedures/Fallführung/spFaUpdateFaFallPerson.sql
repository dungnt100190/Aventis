SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaUpdateFaFallPerson;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt UPDATE auf FaFallPerson aus, falls FaFallPerson eine Tabelle ist, sonst wird ein 
            erfolgreiches UPDATE vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaUpdateFaFallPerson …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaUpdateFaFallPerson
(
  @FaFallPersonID int,
  @FaFallID       int,
  @BaPersonID     int,
  @DatumVon       datetime,
  @DatumBis       datetime
)
AS
BEGIN
  -- nur in Tabelle updaten
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFallPerson' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'UPDATE dbo.FaFallPerson
                     SET FaFallID = @FaFallID_,
                 BaPersonID = @BaPersonID_,
                 DatumVon = @DatumVon_,
                 DatumBis = @DatumBis_
             WHERE FaFallPersonID = @FaFallPersonID_';
    SET @ParmDefinition = N'@FaFallPersonID_ int, @FaFallID_ int, @BaPersonID_ int, @DatumVon_ datetime, @DatumBis_ datetime';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @FaFallPersonID_ = @FaFallPersonID, @FaFallID_ = @FaFallID, @BaPersonID_ = @BaPersonID, @DatumVon_ = @DatumVon, @DatumBis_ = @DatumBis ;
  END
  ELSE BEGIN
    SELECT NULL -- fake
  END
END;
GO
