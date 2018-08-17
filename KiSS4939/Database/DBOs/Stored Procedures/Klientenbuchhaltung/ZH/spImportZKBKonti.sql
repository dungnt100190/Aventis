SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spImportZKBKonti]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spImportZKBKonti]
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spImportZKBKonti]
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  DROP TABLE #BulkImport
  CREATE TABLE #BulkImport (
	[Name]         [varchar](50) NULL,
	[Vorname]      [varchar](50) NULL,
	[Geburtsdatum] [varchar](10) NULL,
	[ZkbKontoNr]   [varchar](50) NULL,
	[IBAN]         [varchar](50) NULL--,
--	[ZIPNr]        [varchar](50) NULL
  )

  BULK INSERT #BulkImport
    FROM 'D:\Lieferanten_Temp_Data\mathias\ZKBKonti\zkb3.csv'
    WITH (
      CODEPAGE        = 'ACP',
      FIELDTERMINATOR = ';',
      ROWTERMINATOR   = '\n'
    )


  TRUNCATE TABLE Import_ZkbKonto2

  INSERT INTO [Import_ZkbKonto2]
    SELECT [Name], [Vorname], CONVERT( datetime, SubString([Geburtsdatum],1,6) + '19' + SubString([Geburtsdatum],7,2), 104), [ZkbKontoNr], IBAN, ZIPNr, 0
    FROM #BulkImport
    WHERE IBAN LIKE 'CH%'



  SELECT *
  FROM   [Import_ZkbKonto2]

END
