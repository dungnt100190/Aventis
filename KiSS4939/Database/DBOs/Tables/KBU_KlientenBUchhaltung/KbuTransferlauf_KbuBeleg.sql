CREATE TABLE [dbo].[KbuTransferlauf_KbuBeleg](
	[KbuTransferlauf_KbuBelegID] [int] IDENTITY(1,1) NOT NULL,
	[KbuTransferlaufID] [int] NOT NULL,
	[KbuBelegID] [int] NOT NULL,
	[TransferZeitpunkt] [datetime] NULL,
	[Fehlermeldung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuTransferlauf_KbuBelegTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuTransferlauf_KbuBeleg] PRIMARY KEY CLUSTERED 
(
	[KbuTransferlauf_KbuBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbuTransferlauf_KbuBeleg_KbuBelegID]    Script Date: 06/21/2011 08:36:54 ******/
CREATE NONCLUSTERED INDEX [IX_KbuTransferlauf_KbuBeleg_KbuBelegID] ON [dbo].[KbuTransferlauf_KbuBeleg] 
(
	[KbuBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuTransferlauf_KbuBeleg_KbuTransferlaufID]    Script Date: 06/21/2011 08:36:54 ******/
CREATE NONCLUSTERED INDEX [IX_KbuTransferlauf_KbuBeleg_KbuTransferlaufID] ON [dbo].[KbuTransferlauf_KbuBeleg] 
(
	[KbuTransferlaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuTransferlauf_KbuBelegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zum Transferlauf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuTransferlaufID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zum Beleg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuBelegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt des Transfers bzw. des Transferversuches' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'TransferZeitpunkt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Allfälliger beim Transfer aufgetretener Fehler. NULL, wenn Transfer noch nicht oder erfolgreich durchgeführt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'Fehlermeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuTransferlauf_KbuBelegTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Mathias Minder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zuordnung von Belegen zu Transferläufen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Klientenbuchhaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf_KbuBeleg'
GO

ALTER TABLE [dbo].[KbuTransferlauf_KbuBeleg]  WITH CHECK ADD  CONSTRAINT [FK_KbuTransferlauf_KbuBeleg_KbuBeleg] FOREIGN KEY([KbuBelegID])
REFERENCES [dbo].[KbuBeleg] ([KbuBelegID])
GO

ALTER TABLE [dbo].[KbuTransferlauf_KbuBeleg] CHECK CONSTRAINT [FK_KbuTransferlauf_KbuBeleg_KbuBeleg]
GO

ALTER TABLE [dbo].[KbuTransferlauf_KbuBeleg]  WITH CHECK ADD  CONSTRAINT [FK_KbuTransferlauf_KbuBeleg_KbuTransferlauf_KbuBeleg] FOREIGN KEY([KbuTransferlaufID])
REFERENCES [dbo].[KbuTransferlauf] ([KbuTransferlaufID])
GO

ALTER TABLE [dbo].[KbuTransferlauf_KbuBeleg] CHECK CONSTRAINT [FK_KbuTransferlauf_KbuBeleg_KbuTransferlauf_KbuBeleg]
GO

ALTER TABLE [dbo].[KbuTransferlauf_KbuBeleg] ADD  CONSTRAINT [DF_KbuTransferlauf_KbuBeleg_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuTransferlauf_KbuBeleg] ADD  CONSTRAINT [DF_KbuTransferlauf_KbuBeleg_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


