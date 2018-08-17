CREATE TABLE [dbo].[XOrgUnit_XDocTemplate](
	[XOrgUnit_XDocTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[OrgUnitID] [int] NOT NULL,
	[DocTemplateID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XOrgUnit_XDocTemplateTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XOrgUnit_XDocTemplate] PRIMARY KEY CLUSTERED 
(
	[XOrgUnit_XDocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XOrgUnit_XDocTemplate_DocTemplateID]    Script Date: 12/23/2010 10:16:36 ******/
CREATE NONCLUSTERED INDEX [IX_XOrgUnit_XDocTemplate_DocTemplateID] ON [dbo].[XOrgUnit_XDocTemplate] 
(
	[DocTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XOrgUnit_XDocTemplate_OrgUnitID]    Script Date: 12/23/2010 10:16:36 ******/
CREATE NONCLUSTERED INDEX [IX_XOrgUnit_XDocTemplate_OrgUnitID] ON [dbo].[XOrgUnit_XDocTemplate] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'XOrgUnit_XDocTemplateID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XOrgUnit (Abteilung).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XDocTemplate (Vorlage).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'DocTemplateID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zulest geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate', @level2type=N'COLUMN',@level2name=N'XOrgUnit_XDocTemplateTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle von XOrgUnit und XDocTemplate (Abteilung und Vorlage)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Vorlagenverwalgung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_XDocTemplate'
GO

ALTER TABLE [dbo].[XOrgUnit_XDocTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XDocTemplate_XDocTemplate] FOREIGN KEY([DocTemplateID])
REFERENCES [dbo].[XDocTemplate] ([DocTemplateID])
GO

ALTER TABLE [dbo].[XOrgUnit_XDocTemplate] CHECK CONSTRAINT [FK_XOrgUnit_XDocTemplate_XDocTemplate]
GO

ALTER TABLE [dbo].[XOrgUnit_XDocTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XDocTemplate_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[XOrgUnit_XDocTemplate] CHECK CONSTRAINT [FK_XOrgUnit_XDocTemplate_XOrgUnit]
GO

ALTER TABLE [dbo].[XOrgUnit_XDocTemplate] ADD  CONSTRAINT [DF_XOrgUnit_XDocTemplate_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XOrgUnit_XDocTemplate] ADD  CONSTRAINT [DF_XOrgUnit_XDocTemplate_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


