CREATE TABLE [dbo].[XUser_XDocTemplate](
	[XUser_XDocTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[DocTemplateID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XUser_XDocTemplateTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUser_XDocTemplate] PRIMARY KEY CLUSTERED 
(
	[XUser_XDocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XUser_XDocTemplate_DocTemplateID]    Script Date: 12/23/2010 09:58:50 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_XDocTemplate_DocTemplateID] ON [dbo].[XUser_XDocTemplate] 
(
	[DocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_XDocTemplate_UserID]    Script Date: 12/23/2010 09:58:50 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_XDocTemplate_UserID] ON [dbo].[XUser_XDocTemplate] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'XUser_XDocTemplateID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XDocTemplate (Dokument).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'DocTemplateID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate', @level2type=N'COLUMN',@level2name=N'XUser_XDocTemplateTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle (Many2Many), XUser und XDocTemplate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'System' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_XDocTemplate'
GO

ALTER TABLE [dbo].[XUser_XDocTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XDocTemplate_XDocTemplate] FOREIGN KEY([DocTemplateID])
REFERENCES [dbo].[XDocTemplate] ([DocTemplateID])
GO

ALTER TABLE [dbo].[XUser_XDocTemplate] CHECK CONSTRAINT [FK_XUser_XDocTemplate_XDocTemplate]
GO

ALTER TABLE [dbo].[XUser_XDocTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XDocTemplate_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XUser_XDocTemplate] CHECK CONSTRAINT [FK_XUser_XDocTemplate_XUser]
GO

ALTER TABLE [dbo].[XUser_XDocTemplate] ADD  CONSTRAINT [DF_XUser_XDocTemplate_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XUser_XDocTemplate] ADD  CONSTRAINT [DF_XUser_XDocTemplate_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


