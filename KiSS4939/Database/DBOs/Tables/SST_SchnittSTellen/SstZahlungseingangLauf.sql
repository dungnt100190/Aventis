CREATE TABLE [dbo].[SstZahlungseingangLauf](
	[SstZahlungseingangLaufID] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NULL,
	[Ende] [datetime] NULL,
	[TimestampGesendet] [varchar](14) NULL,
	[TimestampErhalten] [varchar](14) NULL,
	[Meldung] [varchar](max) NULL,
	[MeldungEinfuegen] [varchar](max) NULL,
	[AbholungErfolgreich] [bit] NOT NULL,
	[EinfuegenErfolgreich] [bit] NOT NULL,
	[Fremdsystem] [varchar](50) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[SstZahlungseingangLaufTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstZahlungseingangLauf] PRIMARY KEY CLUSTERED 
(
	[SstZahlungseingangLaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'SstZahlungseingangLaufID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Startzeitpunkt des Requests' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Start'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Endzeitpunkt des Requests' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Ende'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der ans Fremdsystem gesendete Timestamp. Das Fremdsystem liefern alle Zahlungseingänge nach diesem Timestamp zurück, unabhängig davon, ob diese bereits einmal gesendet wurden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'TimestampGesendet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der vom Fremdsystem zurückgegebene Timestamp (sollte dem gesendeten entsprechen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'TimestampErhalten'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Meldung des Fremdsystems (sowohl Erfolgs- als auch Fehlermeldung) oder technische Fehlermeldung, z.B. Server nicht erreichbar oder Timeout' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Meldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enthält Fehlermeldungen von Datensätzen, welche nicht in SstZahlungseingang eingefügt werden konnten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'MeldungEinfuegen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 falls fehlgeschagen, 1 falls Abholung erfolgreich' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'AbholungErfolgreich'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dieser Wert ist true wenn alle vom PSCD erhaltenen Einträge in die Tabelle SstZahlungseingang übernommen werden konnten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'EinfuegenErfolgreich'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Genaue Bezeichnung des Fremdsystems, könnte Konfigurationsprobleme aufdecken' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Fremdsystem'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf', @level2type=N'COLUMN',@level2name=N'SstZahlungseingangLaufTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Mathias Minder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Repräsentiert eine Abholung von Zahlungseingängen im Fremdsystem (in ELUSA: PSCD)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'SST' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingangLauf'
GO

ALTER TABLE [dbo].[SstZahlungseingangLauf] ADD  CONSTRAINT [DF_SstZahlungseingangLauf_AbholungErfolgreich]  DEFAULT ((0)) FOR [AbholungErfolgreich]
GO

ALTER TABLE [dbo].[SstZahlungseingangLauf] ADD  CONSTRAINT [DF_SstZahlungseingangLauf_EinfuegenErfolgreich]  DEFAULT ((1)) FOR [EinfuegenErfolgreich]
GO

ALTER TABLE [dbo].[SstZahlungseingangLauf] ADD  CONSTRAINT [DF_SstZahlungseingangLauf_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[SstZahlungseingangLauf] ADD  CONSTRAINT [DF_SstZahlungseingangLauf_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

