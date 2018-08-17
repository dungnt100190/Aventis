CREATE TABLE [dbo].[BaEinwohnerregisterPersonStatus](
	[BaEinwohnerregisterPersonStatusID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaEinwohnerregisterPersonStatusTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaEinwohnerregisterPersonStatus] PRIMARY KEY CLUSTERED 
(
	[BaEinwohnerregisterPersonStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaEinwohnerregisterPersonStatus_BaPersonID]    Script Date: 05/21/2014 14:19:11 ******/
CREATE NONCLUSTERED INDEX [IX_BaEinwohnerregisterPersonStatus_BaPersonID] ON [dbo].[BaEinwohnerregisterPersonStatus] 
(
	[BaEinwohnerregisterPersonStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus', @level2type=N'COLUMN',@level2name=N'BaEinwohnerregisterPersonStatusID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK BaPersonID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus', @level2type=N'COLUMN',@level2name=N'BaEinwohnerregisterPersonStatusTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nathanaël Rossel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Liste der BaPersonID in Omega (oder anderes Fremdsystem) registriert sind (Nachbarische Tabelle ist log.BaWinwohnerRegisterPersonAnAbMeldung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaEinwohnerregisterPersonStatus'
GO

ALTER TABLE [dbo].[BaEinwohnerregisterPersonStatus]  WITH CHECK ADD  CONSTRAINT [FK_BaEinwohnerregisterPersonStatus_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaEinwohnerregisterPersonStatus] CHECK CONSTRAINT [FK_BaEinwohnerregisterPersonStatus_BaPerson]
GO

ALTER TABLE [dbo].[BaEinwohnerregisterPersonStatus] ADD  CONSTRAINT [DF_BaEinwohnerregisterPersonStatus_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaEinwohnerregisterPersonStatus] ADD  CONSTRAINT [DF_BaEinwohnerregisterPersonStatus_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


