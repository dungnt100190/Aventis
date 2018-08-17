CREATE TABLE [dbo].[XDocTemplate](
	[DocTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[DocTemplateName] [varchar](255) NULL,
	[FileExtension] [varchar](10) NULL,
	[DateCreation] [datetime] NOT NULL,
	[DateLastSave] [datetime] NOT NULL,
	[FileBinary] [image] NULL,
	[DocFormatCode] [int] NULL,
	[DocTemplateTS] [timestamp] NOT NULL,
	[FaDokKatalogID] [int] NULL,
	[FaDokSpracheCode] [int] NULL,
	[CheckOut_UserID] [int] NULL,
	[CheckOut_Date] [datetime] NULL,
	[CheckOut_Filename] [varchar](max) NULL,
	[CheckOut_Machine] [varchar](max) NULL,
 CONSTRAINT [PK_XDocTemplate] PRIMARY KEY CLUSTERED 
(
	[DocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[XDocTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XDocTemplate_FaDokKatalog] FOREIGN KEY([FaDokKatalogID])
REFERENCES [dbo].[FaDokKatalog] ([FaDokKatalogID])
GO
ALTER TABLE [dbo].[XDocTemplate] CHECK CONSTRAINT [FK_XDocTemplate_FaDokKatalog]