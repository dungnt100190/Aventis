CREATE TABLE [dbo].[XDocContext_Template](
	[XDocContext_TemplateID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[ParentPosition] [int] NULL,
	[FolderName] [varchar](100) NULL,
	[DocContextID] [int] NULL,
	[DocTemplateID] [int] NULL,
	[XDocContext_TemplateTS] [timestamp] NOT NULL,
	[ModulID] [int] NULL,
 CONSTRAINT [PK_XDocContext_Template] PRIMARY KEY NONCLUSTERED 
(
	[XDocContext_TemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE CLUSTERED INDEX [IX_XDocContext_Template] ON [dbo].[XDocContext_Template] 
(
	[ParentID] ASC,
	[ParentPosition] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XDocContext_Template_DocContextID] ON [dbo].[XDocContext_Template] 
(
	[DocContextID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XDocContext_Template Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocContext_Template', @level2type=N'COLUMN',@level2name=N'XDocContext_TemplateID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XDocContext_Template_XDocContext_Template) => XDocContext_Template.XDocContext_TemplateID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocContext_Template', @level2type=N'COLUMN',@level2name=N'ParentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XDocContext_Template_XDocContext) => XDocContext.DocContextID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocContext_Template', @level2type=N'COLUMN',@level2name=N'DocContextID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XDocContext_Template_XDocTemplate) => XDocTemplate.DocTemplateID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDocContext_Template', @level2type=N'COLUMN',@level2name=N'DocTemplateID'
GO

ALTER TABLE [dbo].[XDocContext_Template]  WITH CHECK ADD  CONSTRAINT [FK_XDocContext_Template_XDocContext] FOREIGN KEY([DocContextID])
REFERENCES [dbo].[XDocContext] ([DocContextID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XDocContext_Template] CHECK CONSTRAINT [FK_XDocContext_Template_XDocContext]
GO

ALTER TABLE [dbo].[XDocContext_Template]  WITH CHECK ADD  CONSTRAINT [FK_XDocContext_Template_XDocContext_Template] FOREIGN KEY([ParentID])
REFERENCES [dbo].[XDocContext_Template] ([XDocContext_TemplateID])
GO

ALTER TABLE [dbo].[XDocContext_Template] CHECK CONSTRAINT [FK_XDocContext_Template_XDocContext_Template]
GO

ALTER TABLE [dbo].[XDocContext_Template]  WITH CHECK ADD  CONSTRAINT [FK_XDocContext_Template_XDocTemplate] FOREIGN KEY([DocTemplateID])
REFERENCES [dbo].[XDocTemplate] ([DocTemplateID])
GO

ALTER TABLE [dbo].[XDocContext_Template] CHECK CONSTRAINT [FK_XDocContext_Template_XDocTemplate]
GO

ALTER TABLE [dbo].[XDocContext_Template]  WITH CHECK ADD  CONSTRAINT [FK_XDocContext_Template_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[XDocContext_Template] CHECK CONSTRAINT [FK_XDocContext_Template_XModul]
GO