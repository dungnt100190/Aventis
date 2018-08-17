/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to add new LOVs
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1: lov BaZahlungswegDokumentTyp
-------------------------------------------------------------------------------
DECLARE @LovName VARCHAR(50);
SET @LovName = 'BaZahlungswegDokumentTyp';

IF (EXISTS(SELECT TOP 1 1
           FROM dbo.XLOV
           WHERE LOVName = @LovName))
BEGIN
  PRINT ('Warning: Die LOV "' + @LovName + '" existiert bereits');
END
ELSE
BEGIN 
  DECLARE @XLOVCodeID INT;
  INSERT INTO dbo.XLOV (LOVName, [Description], [System], Expandable, ModulID, LastUpdated, Translatable)
    VALUES (@LovName, 'Typ für die Dokumente eines Zahlungswegs', 0, 1, 1, GETDATE(), 1)
  SELECT @XLOVCodeID = SCOPE_IDENTITY();

  ;WITH CodeCTE AS 
  (
    SELECT Code = 1, [Text] = 'neuer Kreditor', SortKey = 1 UNION ALL
    SELECT Code = 2, [Text] = 'zusätzliche Zahlverbindung', SortKey = 2 UNION ALL
    SELECT Code = 3, [Text] = 'Adressänderung', SortKey = 3 UNION ALL
    SELECT Code = 4, [Text] = 'Namensänderung', SortKey = 4
  )

  INSERT INTO dbo.XLOVCode (XLOVID, LOVName, Code, [Text], SortKey, ShortText, IsActive, [System])
    SELECT @XLOVCodeID, @LovName, Code, [Text], SortKey, NULL, 1, 0
    FROM CodeCTE
  PRINT ('Info: Die LOV "' + @LovName + '" wurde erstellt');
END;

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

