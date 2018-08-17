CREATE TABLE [dbo].[KbuBelegDebitor](
	[KbuBelegDebitorID] [int] IDENTITY(1,1) NOT NULL,
	[KbuBelegID] [int] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuBelegDebitorTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuBelegDebitor] PRIMARY KEY CLUSTERED 
(
	[KbuBelegDebitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbuBelegDebitor_BaInstitutionID]    Script Date: 08/19/2011 14:31:45 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegDebitor_BaInstitutionID] ON [dbo].[KbuBelegDebitor] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegDebitor_BaPersonID]    Script Date: 08/19/2011 14:31:45 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegDebitor_BaPersonID] ON [dbo].[KbuBelegDebitor] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegDebitor_KbuBelegID]    Script Date: 08/19/2011 14:31:45 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegDebitor_KbuBelegID] ON [dbo].[KbuBelegDebitor] 
(
	[KbuBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'KbuBelegDebitorID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Beleg.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'KbuBelegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Person.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor', @level2type=N'COLUMN',@level2name=N'KbuBelegDebitorTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Debitorinformationen über den Kombibeleg.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KBU, WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegDebitor'
GO

ALTER TABLE [dbo].[KbuBelegDebitor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegDebitor_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KbuBelegDebitor] CHECK CONSTRAINT [FK_KbuBelegDebitor_BaInstitution]
GO

ALTER TABLE [dbo].[KbuBelegDebitor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegDebitor_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KbuBelegDebitor] CHECK CONSTRAINT [FK_KbuBelegDebitor_BaPerson]
GO

ALTER TABLE [dbo].[KbuBelegDebitor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegDebitor_KbuBeleg] FOREIGN KEY([KbuBelegID])
REFERENCES [dbo].[KbuBeleg] ([KbuBelegID])
GO

ALTER TABLE [dbo].[KbuBelegDebitor] CHECK CONSTRAINT [FK_KbuBelegDebitor_KbuBeleg]
GO

ALTER TABLE [dbo].[KbuBelegDebitor] ADD  CONSTRAINT [DF_KbuBelegDebitor_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuBelegDebitor] ADD  CONSTRAINT [DF_KbuBelegDebitor_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


