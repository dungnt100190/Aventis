SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spAddXConfig;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Fügt eine neue Row in XConfig ein.
           OriginalValue, ValueCode und System werden von einem älteren Datensatz
           (falls vorhanden) übernommen.
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE [dbo].[spAddXConfig]
(
  @KeyPath VARCHAR(500),
  @DatumVon DATETIME,
  @ValueVar SQL_VARIANT = NULL,
  @ValueCode INT = NULL,
  @Description VARCHAR(1000) = NULL,
  @OriginalValue SQL_VARIANT = NULL,
  @System BIT = 0
)
AS
BEGIN
  DECLARE @Old_XConfigID INT;
  DECLARE @Old_KeyPathTID INT;
  DECLARE @Old_ValueVar SQL_VARIANT;
  DECLARE @Old_ValueCode INT;
  DECLARE @Old_Description VARCHAR(1000);
  DECLARE @Old_DescriptionTID INT;
  DECLARE @Old_System BIT;
  DECLARE @PerformUpdate BIT;
  SET @PerformUpdate = 0;

  SELECT TOP 1
    @Old_XConfigID			= XConfigID,
    @Old_ValueVar			= dbo.fnXConfig(KeyPath, DatumVon),
    @Old_ValueCode			= ValueCode,
    @Old_Description		= Description,
    @Old_DescriptionTID		= DescriptionTID,
    @Old_System				= System,
    @Old_KeyPathTID			= KeyPathTID,
    @PerformUpdate			= CASE WHEN DatumVon = @DatumVon THEN 1 ELSE 0 END
  FROM dbo.XConfig
  WHERE KeyPath = @KeyPath
    AND DatumVon <= @DatumVon
  ORDER BY DatumVon DESC;

  -- Überprüfen, ob ein Eintrag mit DatumVon = NULL existiert
  IF (@Old_XConfigID IS NULL)
  BEGIN
    SELECT TOP 1
      @Old_XConfigID   = XConfigID,
      @Old_ValueVar    = dbo.fnXConfig(KeyPath, DatumVon),
      @Old_ValueCode   = ValueCode,
      @Old_Description = Description,
      @Old_DescriptionTID  = DescriptionTID,
      @Old_System      = System,
      @Old_KeyPathTID  = KeyPathTID,
      @PerformUpdate   = CASE WHEN @DatumVon IS NULL THEN 1 ELSE 0 END
    FROM dbo.XConfig
    WHERE KeyPath = @KeyPath
      AND DatumVon IS NULL;
  END;

  -- Teils alte Daten bevorzugen
  SET @OriginalValue = COALESCE(@Old_ValueVar, @OriginalValue, @ValueVar);
  SET @ValueCode = ISNULL(ISNULL(@Old_ValueCode, @ValueCode), 1);
  SET @System = ISNULL(ISNULL(@Old_System, @System), 0);
  -- Teils neue Daten bevorzugen
  SET @Description = ISNULL(ISNULL(@Description, @Old_Description), '');

  DECLARE @CM VARCHAR(50);
  SET @CM = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

  IF (@PerformUpdate = 0)
  BEGIN
    INSERT INTO dbo.XConfig (
        KeyPath,
        KeyPathTID,
        DatumVon,
        ValueCode,
        Description,
        DescriptionTID,
        ValueBit,
        OriginalValueBit,
        ValueDateTime,
        OriginalValueDateTime,
        ValueDecimal,
        OriginalValueDecimal,
        ValueInt,
        OriginalValueInt,
        ValueMoney,
        OriginalValueMoney,
        ValueVarchar,
        OriginalValueVarchar,
        System,
        Creator,
        Modifier)
      SELECT
        Keypath               = @Keypath,
        KeyPathTID            = @Old_KeyPathTID,
        DatumVon              = @DatumVon,
        ValueCode             = @ValueCode,
        [Description]         = @Description,
        DescriptionTID		  = CASE WHEN @Old_Description = @Description THEN @Old_DescriptionTID ELSE NULL END,
        ValueBit              = CASE WHEN @ValueCode = 5 THEN CONVERT(BIT, @ValueVar) ELSE NULL END,
        OriginalValueBit      = CASE WHEN @ValueCode = 5 THEN CONVERT(BIT, @OriginalValue) ELSE NULL END,
        ValueDateTime         = CASE WHEN @ValueCode = 6 THEN CONVERT(DATETIME, @ValueVar) ELSE NULL END,
        OriginalValueDateTime = CASE WHEN @ValueCode = 6 THEN CONVERT(DATETIME, @OriginalValue) ELSE NULL END,
        ValueDecimal          = CASE WHEN @ValueCode = 3 THEN CONVERT(DECIMAL, @ValueVar) ELSE NULL END,
        OriginalValueDecimal  = CASE WHEN @ValueCode = 3 THEN CONVERT(DECIMAL, @OriginalValue) ELSE NULL END,
        ValueInt              = CASE WHEN @ValueCode = 2 THEN CONVERT(INT, @ValueVar) ELSE NULL END,
        OriginalValueInt      = CASE WHEN @ValueCode = 2 THEN CONVERT(INT, @OriginalValue) ELSE NULL END,
        ValueMoney            = CASE WHEN @ValueCode = 4 THEN CONVERT(INT, @ValueVar) ELSE NULL END,
        OriginalValueMoney    = CASE WHEN @ValueCode = 4 THEN CONVERT(INT, @OriginalValue) ELSE NULL END,
        ValueVarchar          = CASE WHEN @ValueCode IN (1, 7, 8, 9, 10, 11) THEN CONVERT(VARCHAR(MAX), @ValueVar) ELSE NULL END,
        OriginalValueVarchar  = CASE WHEN @ValueCode IN (1, 7, 8, 9, 10, 11) THEN CONVERT(VARCHAR(MAX), @OriginalValue) ELSE NULL END,
        System                = @System,
        Creator               = @CM,
        Modifier              = @CM;
  END
  ELSE BEGIN
    UPDATE CNF
    SET
      ValueCode             = @ValueCode,
      [Description]         = @Description,
      DescriptionTID		= CASE WHEN @Old_Description = @Description THEN @Old_DescriptionTID ELSE NULL END,
      ValueBit              = CASE WHEN @ValueCode = 5 THEN CONVERT(BIT, @ValueVar) ELSE NULL END,
      OriginalValueBit      = CASE WHEN @ValueCode = 5 THEN CONVERT(BIT, @OriginalValue) ELSE NULL END,
      ValueDateTime         = CASE WHEN @ValueCode = 6 THEN CONVERT(DATETIME, @ValueVar) ELSE NULL END,
      OriginalValueDateTime = CASE WHEN @ValueCode = 6 THEN CONVERT(DATETIME, @OriginalValue) ELSE NULL END,
      ValueDecimal          = CASE WHEN @ValueCode = 3 THEN CONVERT(DECIMAL, @ValueVar) ELSE NULL END,
      OriginalValueDecimal  = CASE WHEN @ValueCode = 3 THEN CONVERT(DECIMAL, @OriginalValue) ELSE NULL END,
      ValueInt              = CASE WHEN @ValueCode = 2 THEN CONVERT(INT, @ValueVar) ELSE NULL END,
      OriginalValueInt      = CASE WHEN @ValueCode = 2 THEN CONVERT(INT, @OriginalValue) ELSE NULL END,
      ValueMoney            = CASE WHEN @ValueCode = 4 THEN CONVERT(MONEY, @ValueVar) ELSE NULL END,
      OriginalValueMoney    = CASE WHEN @ValueCode = 4 THEN CONVERT(MONEY, @OriginalValue) ELSE NULL END,
      ValueVarchar          = CASE WHEN @ValueCode IN (1, 7, 8, 9, 10, 11) THEN CONVERT(VARCHAR(MAX), @ValueVar) ELSE NULL END,
      OriginalValueVarchar  = CASE WHEN @ValueCode IN (1, 7, 8, 9, 10, 11) THEN CONVERT(VARCHAR(MAX), @OriginalValue) ELSE NULL END,
      System                = @System,
      Modifier              = @CM,
      Modified              = GETDATE()
    FROM dbo.XConfig CNF
    WHERE XConfigID = @Old_XConfigID;
  END;
END;
GO
