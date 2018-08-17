CREATE TABLE [dbo].[XDocTemplate](
	[DocTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[CheckOut_UserID] [int] NULL,
	[XProfileID] [int] NULL,
	[DocTemplateName] [varchar](255) NULL,
	[FileExtension] [varchar](10) NULL,
	[DateCreation] [datetime] NOT NULL,
	[DateLastSave] [datetime] NOT NULL,
	[FileBinary] [image] NULL,
	[DocFormatCode] [int] NULL,
	[CheckOut_Date] [datetime] NULL,
	[CheckOut_Filename] [varchar](max) NULL,
	[CheckOut_Machine] [varchar](max) NULL,
	[DocTemplateTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDocTemplate] PRIMARY KEY CLUSTERED 
(
	[DocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XDocTemplate_XProfileID]    Script Date: 01/12/2011 08:37:33 ******/
CREATE NONCLUSTERED INDEX [IX_XDocTemplate_XProfileID] ON [dbo].[XDocTemplate] 
(
	[XProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XDocTemplate Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate', @level2type=N'COLUMN',@level2name=N'DocTemplateID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der User, welcher das Dokument bearbeitet. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate', @level2type=N'COLUMN',@level2name=N'CheckOut_UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'Fremdschlüssel zum Vorlagenprofil.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate', @level2type=N'COLUMN',@level2name=N'XProfileID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Vorlage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate', @level2type=N'COLUMN',@level2name=N'DocTemplateName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dateierweiterung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate', @level2type=N'COLUMN',@level2name=N'FileExtension'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Unbekannt. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für Vorlagen inklusive Binärdaten der Vorlage (Officeintegration).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'System' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocTemplate'
GO

ALTER TABLE [dbo].[XDocTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XDocTemplate_XProfile] FOREIGN KEY([XProfileID])
REFERENCES [dbo].[XProfile] ([XProfileID])
GO

ALTER TABLE [dbo].[XDocTemplate] CHECK CONSTRAINT [FK_XDocTemplate_XProfile]
GO

ALTER TABLE [dbo].[XDocTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XDocTemplate_XUser] FOREIGN KEY([CheckOut_UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XDocTemplate] CHECK CONSTRAINT [FK_XDocTemplate_XUser]
GO


