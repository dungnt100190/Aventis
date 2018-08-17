/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: XMenuItem übersetzen
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Step 1: XMenuItem
-------------------------------------------------------------------------------
DECLARE @TID INT;
DECLARE @Text VARCHAR(2000);
DECLARE @ClassName VARCHAR(255);

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TextDE VARCHAR(2000);
DECLARE @TextFR VARCHAR(2000);
DECLARE @MenuTID INT;

DECLARE @MenuItemText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  ClassName VARCHAR(200),
  TextDE VARCHAR(2000),
  TextFR VARCHAR(2000),
  MenuTID INT
);

-- needs to start just at the same value as IDENTITY column on table
SELECT @EntriesIterator = ISNULL(MAX(ID), 0) + 1 
FROM @MenuItemText;

DELETE FROM @MenuItemText

;WITH MenuItemCTE (TextDE, TextFR, ClassName)
AS
(
 SELECT 'KES-Dossiernachweis GEF Kt. BE','Preuve de dossier canton Berne','Kiss.UserInterface.View.Kes.KesDossiernachweisView,Kiss.UserInterface.View'

--SELECT 'TextDE', 'TextFR', 'ClassName' UNION ALL
)
-- insert entries into temp table
INSERT INTO @MenuItemText
 SELECT 
   CTE.ClassName, 
   CTE.TextDE, 
   CTE.TextFR,
   CTL.MenuTID
 FROM MenuItemCTE CTE
   LEFT JOIN dbo.XMenuItem CTL ON CTL.ClassName = CTE.ClassName

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @ClassName   = TMP.ClassName,
         @TextDE      = TMP.TextDE,
         @TextFR      = TMP.TextFR,
         @MenuTID     = TMP.MenuTID
  FROM @MenuItemText TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- translate
  IF (@TextFR = '' OR @TextFR IS NULL)
  BEGIN
    PRINT ('Info: TextFR ist leer, wurde nicht übersetzt bei ' + @ClassName );
  END
  ELSE
  BEGIN
    EXEC dbo.spXSetXLangText @MenuTID, 1, @TextDE, NULL, NULL, NULL, NULL, @MenuTID OUT
    EXEC dbo.spXSetXLangText @MenuTID, 2, @TextFR, NULL, NULL, NULL, NULL, @MenuTID OUT

    UPDATE dbo.XMenuItem
      SET MenuTID = @MenuTID
    WHERE ClassName = @ClassName
  END;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
