CREATE TABLE [dbo].[XDocument](
  [DocumentID] [int] IDENTITY(1,1) NOT NULL,
  [DateCreation] [datetime] NOT NULL CONSTRAINT [DF_XDocument_DateCreation]  DEFAULT (getdate()),
  [UserID_Creator] [int] NULL,
  [DateLastSave] [datetime] NOT NULL CONSTRAINT [DF_XDocument_DateLastSave]  DEFAULT (getdate()),
  [UserID_LastSave] [int] NULL,
  [FileBinary] [image] NOT NULL,
  [DocFormatCode] [int] NULL,
  [FileExtension] [varchar](10) NULL,
  [DocReadonly] [bit] NULL,
  [DocTemplateID] [int] NULL,
  [XDocumentTS] [timestamp] NOT NULL,
  [FaDokKatalogID] [int] NULL,
  [FaDokSicherheitCode] [int] NULL,
  [FaLeistungID] [int] NULL,
  [UserID_Besitzer] [int] NULL,
  [DocDescription] [varchar](1000) NULL,
  [FaThemaCodes] [varchar](100) NULL,
  [DateLastRead] [datetime] NULL,
  [UserID_LastRead] [int] NULL,
  [MigrationSourcePath] [varchar](300) NULL,
  [PostMigrate] [datetime] NULL,
  [MigHerkunftCode] [int] NULL,
  [MigHerkunftText] [varchar](50) NULL,
  [DocTypeCode] [int] NULL,
  [DocTemplateName] [varchar](255) NULL,
  [CheckOut_UserID] [int] NULL,
  [CheckOut_Date] [datetime] NULL,
  [CheckOut_Filename] [varchar](max) NULL,
  [CheckOut_Machine] [varchar](max) NULL,
 CONSTRAINT [PK_XDocumentDateLastSave] PRIMARY KEY CLUSTERED 
(
  [DocumentID] ASC,
  [DateLastSave] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

-- if SQL Server is an Enterprise Edition, then use the partition scheme for XDocument
IF (SERVERPROPERTY('EditionID') = 1804890536 )
BEGIN
  -- Create partition function if it doesn't exists yet
  IF NOT EXISTS (SELECT TOP 1 1 FROM sys.partition_functions WHERE name = N'YearlyDateRangePFN')
  BEGIN
      {Include:YearlyDateRangePFN:NOGO}
  END
  ELSE
  BEGIN
    PRINT ('Warning: [YearlyDateRangePFN] does not exists');
  END;

  -- Create partition scheme if it doesn't exists yet
  IF NOT EXISTS (SELECT TOP 1 1 FROM sys.partition_schemes WHERE name = N'YearlyDateRangePScheme')
  BEGIN 
    {Include:YearlyDateRangePScheme:NOGO}
  END
  ELSE
  BEGIN
    PRINT ('Warning: [YearlyDateRangePScheme] does not exists');
  END;

  -- Move to partition scheme
  IF EXISTS (SELECT TOP 1 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[XDocument]') AND name = N'PK_XDocumentDateLastSave')
  BEGIN
    -- Drop primary key
    ALTER TABLE [dbo].[XDocument] DROP CONSTRAINT [PK_XDocumentDateLastSave]

    -- Add PK
    ALTER TABLE [dbo].[XDocument] ADD  CONSTRAINT [PK_XDocumentDateLastSave] PRIMARY KEY CLUSTERED 
    (
      [DocumentID] ASC,
      [DateLastSave] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) 
    ON [YearlyDateRangePScheme]([DateLastSave])
  END
  ELSE
  BEGIN
    PRINT ('Warning: [PK_XDocumentDateLastSave] does not exists on XDocument');
  END;
END
ELSE
BEGIN
  PRINT('Warning: Is not an Enterprise Edition');
END;
