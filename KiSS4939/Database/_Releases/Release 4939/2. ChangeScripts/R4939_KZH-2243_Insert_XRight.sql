/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to add new rights
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1: CtlBaZahlungsweg_DefinitivSetzen
-------------------------------------------------------------------------------
DECLARE @ClassName VARCHAR(50);
DECLARE @RightName VARCHAR(50);
SET @ClassName = 'CtlBaZahlungsweg';
SET @RightName = 'CtlBaZahlungsweg_DefinitivSetzen';

IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XRight
           WHERE ClassName = @ClassName
             AND RightName = @RightName))
BEGIN
  PRINT ('Warning: Das Spezialrecht "' + @RightName + '" existiert bereits');
END
ELSE
BEGIN 
  DECLARE @Creator VARCHAR(50);
  SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());
  
  INSERT INTO dbo.XRight (XClassID, ClassName, RightName, UserText, [Description], Creator, Created, Modifier, Modified)
    SELECT XClassID, ClassName, @RightName, 'InstitutionenStamm: Status des Zahlungswegs auf definitiv setzen', '', @Creator, GETDATE(), @Creator, GETDATE()
    FROM dbo.XClass
    WHERE ClassName = @ClassName

  PRINT ('Info: Das Spezialrecht "' + @RightName + '" wurde erstellt');
END;

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

