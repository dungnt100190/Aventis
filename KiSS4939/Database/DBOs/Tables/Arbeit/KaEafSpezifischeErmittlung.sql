CREATE TABLE [dbo].[KaEafSpezifischeErmittlung](
	[KaEafSpezifischeErmittlungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[AnwesendTeilzeit] [varchar](200) NULL,
	[Zielsetzungen] [varchar](max) NULL,
	[ProzessEinladungErfolgt] [bit] NOT NULL,
	[ProzessVereinbarung] [bit] NOT NULL,
	[ProzessDatumVereinbarung] [datetime] NULL,
	[ProzessAustauschgespraech1] [bit] NOT NULL,
	[ProzessDatumAustauschgespraech1] [datetime] NULL,
	[ProzessAustauschgespraech2] [bit] NOT NULL,
	[ProzessDatumAustauschgespraech2] [datetime] NULL,
	[ProzessAustauschgespraech3] [bit] NOT NULL,
	[ProzessDatumAustauschgespraech3] [datetime] NULL,
	[ProzessAbschlussgespraechErfolgt] [bit] NOT NULL,
	[ProzessSchlussbericht] [bit] NOT NULL,
	[ProzessAustrittsbefragungErfolgt] [bit] NOT NULL,
	[ProzessBemerkungenAbschluss] [varchar](max) NULL,
	[InterventionenDatumAufforderung1] [datetime] NULL,
	[InterventionenAufforderung1] [varchar](max) NULL,
	[InterventionenDatumAufforderung2] [datetime] NULL,
	[InterventionenAufforderung2] [varchar](max) NULL,
	[AustrittDatum] [datetime] NULL,
	[KaEafAustrittsgrundCode] [int] NULL,
	[KaEafAustrittsgrundMassnahmeBeendetCode] [int] NULL,
	[KaEafAustrittsgrundAbbruchAnbieterCode] [int] NULL,
	[DocumentID_ProzessVereinbarung] [int] NULL,
	[DocumentID_ProzessSchlussbericht] [int] NULL,
	[DocumentID_InterventionenAufforderung1] [int] NULL,
	[DocumentID_InterventionenAufforderung2] [int] NULL,
	[DocumentID_InterventionenAufforderung3] [int] NULL,
	[DocumentID_InterventionenVereinbarung1] [int] NULL,
	[DocumentID_InterventionenVereinbarung2] [int] NULL,
	[DocumentID_InterventionenVerwarnung1] [int] NULL,
	[DocumentID_InterventionenVerwarnung2] [int] NULL,
	[DocumentID_InterventionenProgrammabbruch] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaEafSpezifischeErmittlungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaEafSpezifischeErmittlung] PRIMARY KEY CLUSTERED 
(
	[KaEafSpezifischeErmittlungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaEafSpezifischeErmittlung_FaLeistungID]    Script Date: 01/20/2014 09:48:58 ******/
CREATE NONCLUSTERED INDEX [IX_KaEafSpezifischeErmittlung_FaLeistungID] ON [dbo].[KaEafSpezifischeErmittlung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'KaEafSpezifischeErmittlungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaEafSpezifischeErmittlung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaEafAustrittsGrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'KaEafAustrittsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaEafAustrittsgrundMassnahmeBeendet wird mit Austrittgrund Massnahme beendet gesetzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'KaEafAustrittsgrundMassnahmeBeendetCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaEafAustrittsgrundAbbruchAnbieter wird mit Austrittgrund Abbruch Anbieter gesetzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'KaEafAustrittsgrundAbbruchAnbieterCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung', @level2type=N'COLUMN',@level2name=N'KaEafSpezifischeErmittlungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KA - EAF - Spezifische Ermittlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Arbeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSpezifischeErmittlung'
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung]  WITH CHECK ADD  CONSTRAINT [FK_KaEafSpezifischeErmittlung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] CHECK CONSTRAINT [FK_KaEafSpezifischeErmittlung_FaLeistung]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessEinladungErfolgt]  DEFAULT ((0)) FOR [ProzessEinladungErfolgt]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessVereinbarung]  DEFAULT ((0)) FOR [ProzessVereinbarung]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessAustauschgespraech1]  DEFAULT ((0)) FOR [ProzessAustauschgespraech1]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessAustauschgespraech2]  DEFAULT ((0)) FOR [ProzessAustauschgespraech2]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessAustauschgespraech3]  DEFAULT ((0)) FOR [ProzessAustauschgespraech3]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessAbschlussgespraechErfolgt]  DEFAULT ((0)) FOR [ProzessAbschlussgespraechErfolgt]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessSchlussbericht]  DEFAULT ((0)) FOR [ProzessSchlussbericht]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_ProzessAustrittsbefragungErfolgt]  DEFAULT ((0)) FOR [ProzessAustrittsbefragungErfolgt]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaEafSpezifischeErmittlung] ADD  CONSTRAINT [DF_KaEafSpezifischeErmittlung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


