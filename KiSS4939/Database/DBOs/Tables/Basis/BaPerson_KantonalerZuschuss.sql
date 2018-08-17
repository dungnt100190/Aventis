CREATE TABLE [dbo].[BaPerson_KantonalerZuschuss](
	[BaPerson_KantonalerZuschussID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaKantonalerZuschussID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[BaPerson_KantonalerZuschussTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPerson_KantonalerZuschuss] PRIMARY KEY CLUSTERED 
(
	[BaPerson_KantonalerZuschussID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_BaPerson_KantonalerZuschuss_BaPersonID_BaKantonalerZuschussID_Unique] ON [dbo].[BaPerson_KantonalerZuschuss] 
(
	[BaPersonID] ASC,
	[BaKantonalerZuschussID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_KantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'BaPerson_KantonalerZuschussID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_KantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaKantonalerZuschuss.BaKantonalerZuschussID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_KantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'BaKantonalerZuschussID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_KantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_KantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_KantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'BaPerson_KantonalerZuschussTS'
GO

ALTER TABLE [dbo].[BaPerson_KantonalerZuschuss]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_KantonalerZuschuss_BaKantonalerZuschuss] FOREIGN KEY([BaKantonalerZuschussID])
REFERENCES [dbo].[BaKantonalerZuschuss] ([BaKantonalerZuschussID])
GO

ALTER TABLE [dbo].[BaPerson_KantonalerZuschuss] CHECK CONSTRAINT [FK_BaPerson_KantonalerZuschuss_BaKantonalerZuschuss]
GO

ALTER TABLE [dbo].[BaPerson_KantonalerZuschuss]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_KantonalerZuschuss_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaPerson_KantonalerZuschuss] CHECK CONSTRAINT [FK_BaPerson_KantonalerZuschuss_BaPerson]
GO

ALTER TABLE [dbo].[BaPerson_KantonalerZuschuss] ADD  CONSTRAINT [DF_BaPerson_KantonalerZuschuss_Created]  DEFAULT (getdate()) FOR [Created]
GO