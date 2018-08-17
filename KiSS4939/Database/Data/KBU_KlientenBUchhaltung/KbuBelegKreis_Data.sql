/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the data in "KbuBelegKreis" 
-------------------------------------------------------------------------------------------------
  TEST:    SELECT * FROM dbo.KbuBelegKreis;
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- drop the data
-------------------------------------------------------------------------------
DELETE FROM dbo.KbuBelegKreis;
PRINT ('Info: Deleted data KbuBelegKreis');

-------------------------------------------------------------------------------
-- add the data
-------------------------------------------------------------------------------
DECLARE @KbuBelegKreisCode INT;
DECLARE @InsertDate DATETIME;
SET @InsertDate = CONVERT(DATETIME, '20100101');
DECLARE @userid INT;
DECLARE @usertext VARCHAR(200);
SELECT @userid = dbo.fnXGetSystemUserID();
SELECT @usertext = LogonName FROM dbo.XUser WHERE UserID = @userid;
SET @usertext = ISNULL(@usertext, 'System');

INSERT INTO dbo.KbuBelegKreis (KbuBelegKreisCode, NaechsteBelegNr, BelegNrVon, BelegNrBis, Creator, Created, Modifier, Modified)
  SELECT KbuBelegKreisCode = 1,
         NaechsteBelegNr   = 200000000,
         BelegNrVon        = 200000000,
         BelegNrBis        = 299999999,
         Creator           = @usertext,
         Created           = @InsertDate,
         Modifier          = @usertext,
         Modified          = @InsertDate

  UNION ALL
  SELECT KbuBelegKreisCode = 2,
         NaechsteBelegNr   = 300000000,
         BelegNrVon        = 300000000,
         BelegNrBis        = 399999999,
         Creator           = @usertext,
         Created           = @InsertDate,
         Modifier          = @usertext,
         Modified          = @InsertDate

  UNION ALL
  SELECT KbuBelegKreisCode = 3,
         NaechsteBelegNr   = 400000000,
         BelegNrVon        = 400000000,
         BelegNrBis        = 499999999,
         Creator           = @usertext,
         Created           = @InsertDate,
         Modifier          = @usertext,
         Modified          = @InsertDate

  UNION ALL
  SELECT KbuBelegKreisCode = 4,
         NaechsteBelegNr   = 500000000,
         BelegNrVon        = 500000000,
         BelegNrBis        = 599999999,
         Creator           = @usertext,
         Created           = @InsertDate,
         Modifier          = @usertext,
         Modified          = @InsertDate

  UNION ALL
  SELECT KbuBelegKreisCode = 5,
         NaechsteBelegNr   = 600000000,
         BelegNrVon        = 600000000,
         BelegNrBis        = 699999999,
         Creator           = @usertext,
         Created           = @InsertDate,
         Modifier          = @usertext,
         Modified          = @InsertDate;

-- info
PRINT ('Info: Created data KbuBelegKreis');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO