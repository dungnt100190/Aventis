CREATE TABLE [dbo].[KaQJIntakeGespraech](
	[KaQJIntakeGespraechID] [int] IDENTITY(1,1) NOT NULL,
	[KaQJIntakeID] [int] NOT NULL,
	[Datum] [datetime] NULL,
	[KaQjIntakePraesenzCode] [int] NULL,
	[KaQjIntakeEntscheidCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaQJIntakeGespraechTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJIntakeGespraech] PRIMARY KEY CLUSTERED 
(
	[KaQJIntakeGespraechID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KaQJIntakeGespraech_KaQJIntakeID] ON [dbo].[KaQJIntakeGespraech] 
(
	[KaQJIntakeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle KaQJIntakeGespraech' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'KaQJIntakeGespraechID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Tabelle KaQJIntake' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'KaQJIntakeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Gesprächs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Präsenz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'KaQjIntakePraesenzCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Entscheid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'KaQjIntakeEntscheidCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech', @level2type=N'COLUMN',@level2name=N'KaQJIntakeGespraechTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KA - Qualifizierung Jugend - Intake' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntakeGespraech'
GO

ALTER TABLE [dbo].[KaQJIntakeGespraech]  WITH CHECK ADD  CONSTRAINT [FK_KaQJIntakeGespraech_KaQJIntake] FOREIGN KEY([KaQJIntakeID])
REFERENCES [dbo].[KaQJIntake] ([KaQJIntakeID])
GO

ALTER TABLE [dbo].[KaQJIntakeGespraech] CHECK CONSTRAINT [FK_KaQJIntakeGespraech_KaQJIntake]
GO

ALTER TABLE [dbo].[KaQJIntakeGespraech] ADD  CONSTRAINT [DF_KaQJIntakeGespraech_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaQJIntakeGespraech] ADD  CONSTRAINT [DF_KaQJIntakeGespraech_Modified]  DEFAULT (getdate()) FOR [Modified]
GO