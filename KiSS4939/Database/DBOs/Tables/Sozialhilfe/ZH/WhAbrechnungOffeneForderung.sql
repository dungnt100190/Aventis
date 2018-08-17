CREATE TABLE [dbo].[WhAbrechnungOffeneForderung](
	[WhAbrechnungOffeneForderungID] [int] IDENTITY(1,1) NOT NULL,
	[WhAbrechnungID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[Grund] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WhAbrechnungOffeneForderungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WhAbrechnungOffeneForderung] PRIMARY KEY CLUSTERED 
(
	[WhAbrechnungOffeneForderungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WhAbrechnungOffeneForderung_WhAbrechnungID]    Script Date: 07/25/2012 11:34:37 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnungOffeneForderung_WhAbrechnungID] ON [dbo].[WhAbrechnungOffeneForderung] 
(
	[WhAbrechnungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für WhAbrechnungOffeneForderung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'WhAbrechnungOffeneForderungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_WhAbrechnungOffeneForderung_WhAbrechnung) => WhAbrechnungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'WhAbrechnungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der offenen Forderung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund der offenen Forderung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'Grund'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung', @level2type=N'COLUMN',@level2name=N'WhAbrechnungOffeneForderungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen für offene Forderungen einer Klientenkontoabrechnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhAbrechnungOffeneForderung'
GO

ALTER TABLE [dbo].[WhAbrechnungOffeneForderung]  WITH CHECK ADD  CONSTRAINT [FK_WhAbrechnungOffeneForderung_WhAbrechnung] FOREIGN KEY([WhAbrechnungID])
REFERENCES [dbo].[WhAbrechnung] ([WhAbrechnungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WhAbrechnungOffeneForderung] CHECK CONSTRAINT [FK_WhAbrechnungOffeneForderung_WhAbrechnung]
GO

ALTER TABLE [dbo].[WhAbrechnungOffeneForderung] ADD  CONSTRAINT [DF_WhAbrechnungOffeneForderung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WhAbrechnungOffeneForderung] ADD  CONSTRAINT [DF_WhAbrechnungOffeneForderung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

