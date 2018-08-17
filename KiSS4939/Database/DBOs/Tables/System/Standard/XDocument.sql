CREATE TABLE [dbo].[XDocument](
	[DocumentID] [int] IDENTITY(1,1) NOT NULL,
	[DateCreation] [datetime] NOT NULL,
	[UserID_Creator] [int] NULL,
	[DateLastSave] [datetime] NOT NULL,
	[UserID_LastSave] [int] NULL,
	[FileBinary] [image] NOT NULL,
	[DocFormatCode] [int] NULL,
	[FileExtension] [varchar](10) NULL,
	[DocReadOnly] [bit] NOT NULL,
	[DocTemplateID] [int] NULL,
	[XDocumentTS] [timestamp] NOT NULL,
	[DocTypeCode] [int] NULL,
	[DocTemplateName] [varchar](255) NULL,
	[CheckOut_UserID] [int] NULL,
	[CheckOut_Date] [datetime] NULL,
	[CheckOut_Filename] [varchar](max) NULL,
	[CheckOut_Machine] [varchar](max) NULL,
	[UserID_LastRead] [int] NULL,
	[DateLastRead] [datetime] NULL,
 CONSTRAINT [PK_XDocument] PRIMARY KEY NONCLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Index [IX_XDocument_DocTypeCode]    Script Date: 11/13/2009 15:17:18 ******/
CREATE CLUSTERED INDEX [IX_XDocument_DocTypeCode] ON [dbo].[XDocument] 
(
	[DocTypeCode] ASC,
	[DocFormatCode] ASC,
	[FileExtension] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[XDocument] ADD  CONSTRAINT [DF_XDocument_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO

ALTER TABLE [dbo].[XDocument] ADD  CONSTRAINT [DF_XDocument_DateLastSave]  DEFAULT (getdate()) FOR [DateLastSave]
GO

ALTER TABLE [dbo].[XDocument] ADD  CONSTRAINT [DF_XDocument_IsReadOnly]  DEFAULT ((0)) FOR [DocReadOnly]
GO
