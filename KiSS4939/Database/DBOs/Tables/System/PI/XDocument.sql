CREATE TABLE [dbo].[XDocument](
	[DocumentID] [int] IDENTITY(1,1) NOT NULL,
	[DateCreation] [datetime] NOT NULL,
	[UserID_Creator] [int] NULL,
	[DateLastRead] [datetime] NULL,
	[DateLastSave] [datetime] NOT NULL,
	[UserID_LastRead] [int] NULL,
	[UserID_LastSave] [int] NULL,
	[FileBinary] [image] NOT NULL,
	[DocFormatCode] [int] NULL,
	[FileExtension] [varchar](10) NULL,
	[DocReadOnly] [bit] NOT NULL,
	[DocTemplateID] [int] NULL,
	[DocTypeCode] [int] NULL,
	[DocTemplateName] [varchar](255) NULL,
	[CheckOut_UserID] [int] NULL,
	[CheckOut_Date] [datetime] NULL,
	[CheckOut_Filename] [varchar](max) NULL,
	[CheckOut_Machine] [varchar](max) NULL,
	[visdat36Area] [varchar](255) NULL,
	[visdat36ID] [varchar](255) NULL,
	[XDocumentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDocument] PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1] TEXTIMAGE_ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_XDocument_DocFormatCode] ON [dbo].[XDocument] 
(
	[DocFormatCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_XDocument_DocTemplateID] ON [dbo].[XDocument] 
(
	[DocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_XDocument_DocTypeCode] ON [dbo].[XDocument] 
(
	[DocTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_XDocument_FileExtension] ON [dbo].[XDocument] 
(
	[FileExtension] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

ALTER TABLE [dbo].[XDocument]  WITH CHECK ADD  CONSTRAINT [FK_XDocument_XDocTemplate] FOREIGN KEY([DocTemplateID])
REFERENCES [dbo].[XDocTemplate] ([DocTemplateID])
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[XDocument] CHECK CONSTRAINT [FK_XDocument_XDocTemplate]
GO

ALTER TABLE [dbo].[XDocument] ADD  CONSTRAINT [DF_XDocument_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO

ALTER TABLE [dbo].[XDocument] ADD  CONSTRAINT [DF_XDocument_DateLastSave]  DEFAULT (getdate()) FOR [DateLastSave]
GO

ALTER TABLE [dbo].[XDocument] ADD  CONSTRAINT [DF_XDocument_DocReadOnly]  DEFAULT ((0)) FOR [DocReadOnly]
GO