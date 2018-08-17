CREATE TABLE [dbo].[GvAuszahlungPosition](
	[GvAuszahlungPositionID] [int] IDENTITY(1,1) NOT NULL,
	[GvGesuchID] [int] NOT NULL,
	[GvPositionsartID] [int] NOT NULL,
	[BaZahlungswegID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[ValutaDatum] [datetime] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[Zahlungsinstruktion] [varchar](max) NULL,
	[GvAuszahlungTerminArtCode] [int] NOT NULL,
	[GvAuszahlungArtCode] [int] NOT NULL,
	[GvAuszahlungPositionStatusCode] [int] NOT NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[BuchungsText] [varchar](200) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvAuszahlungPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvAuszahlungPosition] PRIMARY KEY CLUSTERED 
(
	[GvAuszahlungPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvAuszahlungPosition_BaZahlungswegID]    Script Date: 11/12/2012 14:42:00 ******/
CREATE NONCLUSTERED INDEX [IX_GvAuszahlungPosition_BaZahlungswegID] ON [dbo].[GvAuszahlungPosition] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvAuszahlungPosition_GvGesuchID]    Script Date: 11/12/2012 14:42:00 ******/
CREATE NONCLUSTERED INDEX [IX_GvAuszahlungPosition_GvGesuchID] ON [dbo].[GvAuszahlungPosition] 
(
	[GvGesuchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvAuszahlungPosition_GvPositionsartID]    Script Date: 11/12/2012 14:42:00 ******/
CREATE NONCLUSTERED INDEX [IX_GvAuszahlungPosition_GvPositionsartID] ON [dbo].[GvAuszahlungPosition] 
(
	[GvPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvAuszahlungPosition Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'GvAuszahlungPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAuszahlungPosition_GvGesuch) => GvGesuchID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'GvGesuchID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAuszahlungPosition_GvPositionsart) => GvPositionsartID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'GvPositionsartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAuszahlungPosition_BaZahlungsweg) => BgZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der GvAuszahlungPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valutadatum (wenn nur eines vorhanden, ansonsten in GvAuszahlungPositionValuta)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'ValutaDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ReferenzNummer (Zahlinfo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'ReferenzNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextfeld für Zahlungsinstruktionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'Zahlungsinstruktion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV GvAuszahlungTerminArt ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'GvAuszahlungTerminArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV GvAuszahlungArt ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'GvAuszahlungArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Statuscode der GvAuszahlungPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'GvAuszahlungPositionStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mitteilungszeile 1, Feld für Mitteilungen zur Buchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'MitteilungZeile1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mitteilungszeile 2, Feld für Mitteilungen zur Buchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'MitteilungZeile2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mitteilungszeile 3, Feld für Mitteilungen zur Buchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'MitteilungZeile3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mitteilungszeile 4, Feld für Mitteilungen zur Buchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'MitteilungZeile4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buchungstext, Feld für zusätzliche Kommentare zur Buchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'BuchungsText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition', @level2type=N'COLUMN',@level2name=N'GvAuszahlungPositionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen zu den einzelnen Auszahlungspositionen in der Gesuchverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPosition'
GO

ALTER TABLE [dbo].[GvAuszahlungPosition]  WITH CHECK ADD  CONSTRAINT [FK_GvAuszahlungPosition_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[GvAuszahlungPosition] CHECK CONSTRAINT [FK_GvAuszahlungPosition_BaZahlungsweg]
GO

ALTER TABLE [dbo].[GvAuszahlungPosition]  WITH CHECK ADD  CONSTRAINT [FK_GvAuszahlungPosition_GvGesuch] FOREIGN KEY([GvGesuchID])
REFERENCES [dbo].[GvGesuch] ([GvGesuchID])
GO

ALTER TABLE [dbo].[GvAuszahlungPosition] CHECK CONSTRAINT [FK_GvAuszahlungPosition_GvGesuch]
GO

ALTER TABLE [dbo].[GvAuszahlungPosition]  WITH CHECK ADD  CONSTRAINT [FK_GvAuszahlungPosition_GvPositionsart] FOREIGN KEY([GvPositionsartID])
REFERENCES [dbo].[GvPositionsart] ([GvPositionsartID])
GO

ALTER TABLE [dbo].[GvAuszahlungPosition] CHECK CONSTRAINT [FK_GvAuszahlungPosition_GvPositionsart]
GO

ALTER TABLE [dbo].[GvAuszahlungPosition] ADD  CONSTRAINT [DF_GvAuszahlungPosition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvAuszahlungPosition] ADD  CONSTRAINT [DF_GvAuszahlungPosition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


