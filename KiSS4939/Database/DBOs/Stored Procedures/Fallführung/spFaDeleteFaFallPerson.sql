SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaDeleteFaFallPerson;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt DELETE in FaFallPerson aus, falls FaFallPerson eine Tabelle ist, sonst wird ein 
            erfolgreiches DELETE vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaDeleteFaFallPerson …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaDeleteFaFallPerson
(
  @FaFallPersonID int
)
AS
BEGIN
  -- nur in Tabelle löschen
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFallPerson' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'DELETE FROM dbo.FaFallPerson
                       WHERE FaFallPersonID = @FaFallPersonID_';
    SET @ParmDefinition = N'@FaFallPersonID_ int';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @FaFallPersonID_ = @FaFallPersonID;
  END
  ELSE BEGIN
    SELECT NULL -- fake
  END
END;
GO
