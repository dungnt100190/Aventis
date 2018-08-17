SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaDeleteFaFall;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt DELETE in FaFall aus, falls FaFall eine Tabelle ist, sonst wird ein 
            erfolgreiches DELETE vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaDeleteFaFall …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaDeleteFaFall
(
  @FaFallID int
)
AS
BEGIN
  -- nur in Tabelle löschen
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFall' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'DELETE FROM dbo.FaFall
                       WHERE FaFallID = @FaFallID_';
    SET @ParmDefinition = N'@FaFallID_ int';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @FaFallID_ = @FaFallID;
  END
  ELSE BEGIN
    SELECT NULL -- fake
  END
END;
GO
