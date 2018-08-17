CREATE TABLE [dbo].[WshGrundbudgetPositionKreditor](
	[WshGrundbudgetPositionKreditorID] [int] IDENTITY(1,1) NOT NULL,
	[WshGrundbudgetPositionID] [int] NOT NULL,
	[BaZahlungswegID] [int] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshGrundbudgetPositionKreditorTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshGrundbudgetPositionKreditor] PRIMARY KEY CLUSTERED 
(
	[WshGrundbudgetPositionKreditorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [UK_WshGrundbudgetPositionKreditor_WshGrundbudgetPositionID] UNIQUE NONCLUSTERED 
(
	[WshGrundbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPositionKreditor_BaZahlungswegID] ON [dbo].[WshGrundbudgetPositionKreditor] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPositionKreditor_WshGrundbudgetPositionID] ON [dbo].[WshGrundbudgetPositionKreditor] 
(
	[WshGrundbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionKreditorID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der GrundbudgetPosition, zu welcher die Kreditor-Informationen gehören' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel des für die Auszahlung verwendeten Zahlungswegs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Referenznummer für die Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'ReferenzNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die erste Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die zweite Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die dritte Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die vierte Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionKreditorTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Kreditor-Informationen der zugehörigen WshGrundbudgetPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor'
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPositionKreditor_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor] CHECK CONSTRAINT [FK_WshGrundbudgetPositionKreditor_BaZahlungsweg]
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPositionKreditor_WshGrundbudgetPosition] FOREIGN KEY([WshGrundbudgetPositionID])
REFERENCES [dbo].[WshGrundbudgetPosition] ([WshGrundbudgetPositionID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor] CHECK CONSTRAINT [FK_WshGrundbudgetPositionKreditor_WshGrundbudgetPosition]
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor]  WITH CHECK ADD  CONSTRAINT [CK_WshGrundbudgetPositionKreditor_AtLeastOneInformation] CHECK  (([BaZahlungswegID] IS NOT NULL OR [ReferenzNummer] IS NOT NULL OR [MitteilungZeile1] IS NOT NULL OR [MitteilungZeile2] IS NOT NULL OR [MitteilungZeile3] IS NOT NULL OR [MitteilungZeile4] IS NOT NULL))
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor] CHECK CONSTRAINT [CK_WshGrundbudgetPositionKreditor_AtLeastOneInformation]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sicherstellen, dass mindestens eine nützliche Information vorhanden ist (Zahlungsweg, RefNr oder Mitteilungszeile)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionKreditor', @level2type=N'CONSTRAINT',@level2name=N'CK_WshGrundbudgetPositionKreditor_AtLeastOneInformation'
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor] ADD  CONSTRAINT [DF_WshGrundbudgetPositionKreditor_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor] ADD  CONSTRAINT [DF_WshGrundbudgetPositionKreditor_Modified]  DEFAULT (getdate()) FOR [Modified]
GO