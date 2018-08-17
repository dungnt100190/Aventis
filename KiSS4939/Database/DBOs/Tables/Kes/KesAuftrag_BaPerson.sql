CREATE TABLE [dbo].[KesAuftrag_BaPerson](
	[KesAuftrag_BaPersonID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[KesAuftragID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesAuftrag_BaPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesAuftrag_BaPerson] PRIMARY KEY CLUSTERED 
(
	[KesAuftrag_BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_KesAuftrag_BaPerson_BaPersonID_FaDokumentID] UNIQUE NONCLUSTERED 
(
	[BaPersonID] ASC,
	[KesAuftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KesAuftrag_BaPerson_BaPersonID] ON [dbo].[KesAuftrag_BaPerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_KesAuftrag_BaPerson_KesAuftragID] ON [dbo].[KesAuftrag_BaPerson] 
(
	[KesAuftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_KesAuftrag_BaPerson_KesAuftragID_BaPersonID] ON [dbo].[KesAuftrag_BaPerson] 
(
	[KesAuftragID] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'KesAuftrag_BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Tabelle BaPerson, Spalte BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Tabelle FaDokumentAblage, Spalte KesAuftragID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'KesAuftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripiton', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optmistic Locking.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson', @level2type=N'COLUMN',@level2name=N'KesAuftrag_BaPersonTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle von BaPerson und KesAuftrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag_BaPerson'
GO

ALTER TABLE [dbo].[KesAuftrag_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_KesAuftrag_BaPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KesAuftrag_BaPerson] CHECK CONSTRAINT [FK_KesAuftrag_BaPerson_BaPerson]
GO

ALTER TABLE [dbo].[KesAuftrag_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_KesAuftrag_BaPerson_KesAuftrag] FOREIGN KEY([KesAuftragID])
REFERENCES [dbo].[KesAuftrag] ([KesAuftragID])
GO

ALTER TABLE [dbo].[KesAuftrag_BaPerson] CHECK CONSTRAINT [FK_KesAuftrag_BaPerson_KesAuftrag]
GO

ALTER TABLE [dbo].[KesAuftrag_BaPerson] ADD  CONSTRAINT [DF_KesAuftrag_BaPerson_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesAuftrag_BaPerson] ADD  CONSTRAINT [DF_KesAuftrag_BaPerson_Modified]  DEFAULT (getdate()) FOR [Modified]
GO