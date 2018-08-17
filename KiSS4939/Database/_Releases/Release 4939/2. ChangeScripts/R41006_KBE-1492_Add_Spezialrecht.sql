/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1475
=================================================================================================*/
SET NOCOUNT ON;
GO

DECLARE @CreatorModifier VARCHAR(50);
SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()); 

DECLARE @RightName VARCHAR(100);
SET @RightName = 'CtlBaPerson_FiktivePersonBearbeiten';

IF NOT EXISTS (SELECT TOP 1 1 FROM XRight WHERE RightName = @RightName)
BEGIN
  INSERT INTO dbo.XRight
  (
      XClassID,
      ClassName,
      RightName,
      UserText,
      Description,
      Creator,
      Created,
      Modifier,
      Modified
  )
  SELECT XClassID,
       ClassName,
       RightName = @RightName,
       UserText = 'BA - Fiktive Person bearbeiten',
       Description = 'Spezialrecht um fiktive Personen zu bearbeiten',
       Creator = @CreatorModifier,
       Created = GETDATE(),
       Modifier = @CreatorModifier,
       Modified = GETDATE()
  FROM XClass
  WHERE ClassName = 'CtlBaPerson'

  PRINT ('Info: Spezialrecht: ' + @RightName + ' erstellt.');
END
ELSE
BEGIN
  PRINT ('Info: Spezialrecht: ' + @RightName + ' existiert bereits.');
END;

SET NOCOUNT OFF;
GO
