CREATE TABLE [dbo].[XDocContext_Template](
	[XDocContext_TemplateID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[ParentPosition] [int] NULL,
	[FolderName] [varchar](100) NULL,
	[DocContextID] [int] NULL,
	[DocTemplateID] [int] NULL,
	[UserProfileCode] [int] NULL,
	[XDocContext_TemplateTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDocContext_Template] PRIMARY KEY NONCLUSTERED 
(
	[XDocContext_TemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [SYSTEM]
) ON [SYSTEM]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XDocContext_Template]    Script Date: 03/22/2012 10:39:43 ******/
CREATE CLUSTERED INDEX [IX_XDocContext_Template] ON [dbo].[XDocContext_Template] 
(
	[ParentID] ASC,
	[ParentPosition] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [SYSTEM]
GO


/****** Object:  Index [IX_XDocContext_Template_DocTemplateID]    Script Date: 03/22/2012 10:39:43 ******/
CREATE NONCLUSTERED INDEX [IX_XDocContext_Template_DocTemplateID] ON [dbo].[XDocContext_Template] 
(
	[DocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [SYSTEM]
GO


/****** Object:  Index [IX_XDocContext_Template_DocContextID]    Script Date: 03/22/2012 10:39:43 ******/
CREATE NONCLUSTERED INDEX [IX_XDocContext_Template_DocContextID] ON [dbo].[XDocContext_Template] 
(
	[DocContextID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [SYSTEM]
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

