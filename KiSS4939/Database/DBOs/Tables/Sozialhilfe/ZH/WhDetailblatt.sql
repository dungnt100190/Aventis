CREATE TABLE [dbo].[WhDetailblatt](
	[WhDetailblattID] [int] IDENTITY(1,1) NOT NULL,
	[WhAbrechnungID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[DocumentID] [int] NULL,
	[ErgaenzungsblattDokumentID] [int] NULL,
	[TotalEinnahmen] [money] NULL,
	[TotalAusgaben] [money] NULL,
	[Bemerkung] [varchar](2000) NULL,
	[Grund] [varchar](2000) NULL,
	[TotalAusgabenKlient] [money] NULL,
	[TotalAusgabenDritte] [money] NULL,
	[TotalEinnahmenKlient] [money] NULL,
	[TotalEinnahmenSD] [money] NULL,
	[TotalVerrechnungRueckerstattung] [money] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WhDetailblattTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WhDetailblatt] PRIMARY KEY CLUSTERED 
(
	[WhDetailblattID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WhDetailblatt_DocumentID]    Script Date: 07/26/2012 16:19:27 ******/
CREATE NONCLUSTERED INDEX [IX_WhDetailblatt_DocumentID] ON [dbo].[WhDetailblatt] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO


/****** Object:  Index [IX_WhDetailblatt_ErgaenzungsblattDokumentID]    Script Date: 07/26/2012 16:19:27 ******/
CREATE NONCLUSTERED INDEX [IX_WhDetailblatt_ErgaenzungsblattDokumentID] ON [dbo].[WhDetailblatt] 
(
	[ErgaenzungsblattDokumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO


/****** Object:  Index [IX_WhDetailblatt_WhAbrechnungID]    Script Date: 07/26/2012 16:19:27 ******/
CREATE NONCLUSTERED INDEX [IX_WhDetailblatt_WhAbrechnungID] ON [dbo].[WhDetailblatt] 
(
	[WhAbrechnungID] ASC
)
INCLUDE ( [DatumVon],
[DatumBis],
[ErgaenzungsblattDokumentID],
[WhDetailblattTS]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total Ausgaben Klient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'TotalAusgabenKlient'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total Ausgaben an Dritte' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'TotalAusgabenDritte'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total Einnahmen Klient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'TotalEinnahmenKlient'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total Einnahmen Sozialdienste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'TotalEinnahmenSD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total Verrechnung und Rückerstattungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'TotalVerrechnungRueckerstattung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt', @level2type=N'COLUMN',@level2name=N'WhDetailblattTS'
GO

ALTER TABLE [dbo].[WhDetailblatt]  WITH CHECK ADD  CONSTRAINT [FK_WhDetailblatt_WhAbrechnung] FOREIGN KEY([WhAbrechnungID])
REFERENCES [dbo].[WhAbrechnung] ([WhAbrechnungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WhDetailblatt] CHECK CONSTRAINT [FK_WhDetailblatt_WhAbrechnung]
GO

ALTER TABLE [dbo].[WhDetailblatt] ADD  CONSTRAINT [DF__WhDetailb__Bemer__26D61AED]  DEFAULT ('') FOR [Bemerkung]
GO

ALTER TABLE [dbo].[WhDetailblatt] ADD  CONSTRAINT [DF_WhDetailblatt_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WhDetailblatt] ADD  CONSTRAINT [DF_WhDetailblatt_Modified]  DEFAULT (getdate()) FOR [Modified]
GO