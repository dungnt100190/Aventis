CREATE TABLE [dbo].[KaEafSozioberuflicheBilanz](
	[KaEafSozioberuflicheBilanzID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[AnwesendTeilzeit] [varchar](200) NULL,
	[Schwerpunkte] [varchar](max) NULL,
	[ProzessEinladungErfolgt] [bit] NOT NULL,
	[ProzessAufnahmeverfahrenErfolgt] [bit] NOT NULL,
	[ProzessErmittlungsprogrammErstellt] [bit] NOT NULL,
	[ProzessFaehigkeitsprofilMelba] [bit] NOT NULL,
	[ProzessZwischengespraech] [bit] NOT NULL,
	[ProzessDatumZwischengespraech] [datetime] NULL,
	[ProzessVerzahnungsgespraech1] [bit] NOT NULL,
	[ProzessDatumVerzahnungsgespraech1] [datetime] NULL,
	[ProzessVerzahnungsgespraech2] [bit] NOT NULL,
	[ProzessDatumVerzahnungsgespraech2] [datetime] NULL,
	[ProzessVerzahnungsgespraech3] [bit] NOT NULL,
	[ProzessDatumVerzahnungsgespraech3] [datetime] NULL,
	[ProzessAbschlussgespraechErfolgt] [bit] NOT NULL,
	[ProzessSchlussbericht] [bit] NOT NULL,
	[ProzessFaehigkeitsAnalyse] [bit] NOT NULL,
	[ProzessBewerbungskompetenz] [bit] NOT NULL,
	[ProzessAustrittsbefragungErfolgt] [bit] NOT NULL,
	[ProzessBemerkungenAbschluss] [varchar](max) NULL,
	[AufnahmeZielsetzungenRAV] [varchar](max) NULL,
	[AufnahmeErgebnisseInterview] [varchar](max) NULL,
	[AufnahmeErgebnisseBewerbung] [varchar](max) NULL,
	[AufnahmeErgebnisseAssessment] [varchar](max) NULL,
	[AufnahmeErgebnisseWerkstatt] [varchar](max) NULL,
	[InterventionenDatumAufforderung] [datetime] NULL,
	[InterventionenAufforderung] [varchar](max) NULL,
	[AustrittDatum] [datetime] NULL,
	[KaEafAustrittsgrundCode] [int] NULL,
	[KaEafAustrittsgrundMassnahmeBeendetCode] [int] NULL,
	[KaEafAustrittsgrundAbbruchAnbieterCode] [int] NULL,
	[DocumentID_ProzessErmittlungsprogramm] [int] NULL,
	[DocumentID_ProzessFaehigkeitsprofilMelba] [int] NULL,
	[DocumentID_ProzessSchlussbericht] [int] NULL,
	[DocumentID_ProzessFaehigkeitsAnalyse] [int] NULL,
	[DocumentID_ProzessBewerbungskompetenz] [int] NULL,
	[DocumentID_InterventionenVereinbarung] [int] NULL,
	[DocumentID_InterventionenVerwarnung1] [int] NULL,
	[DocumentID_InterventionenVerwarnung2] [int] NULL,
	[DocumentID_InterventionenProgrammabbruch] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaEafSozioberuflicheBilanzTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaEafSozioberuflicheBilanz] PRIMARY KEY CLUSTERED 
(
	[KaEafSozioberuflicheBilanzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaEafSozioberuflicheBilanz_FaLeistungID]    Script Date: 06/29/2015 11:56:06 ******/
CREATE NONCLUSTERED INDEX [IX_KaEafSozioberuflicheBilanz_FaLeistungID] ON [dbo].[KaEafSozioberuflicheBilanz] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'KaEafSozioberuflicheBilanzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaEafSozioberuflicheBilanz_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaEafAustrittsGrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'KaEafAustrittsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaEafAustrittsgrundMassnahmeBeendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'KaEafAustrittsgrundMassnahmeBeendetCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaEafAustrittsgrundAbbruchAnbieter' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'KaEafAustrittsgrundAbbruchAnbieterCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz', @level2type=N'COLUMN',@level2name=N'KaEafSozioberuflicheBilanzTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KA - EAF - Sozioberufliche Bilanz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Arbeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEafSozioberuflicheBilanz'
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz]  WITH CHECK ADD  CONSTRAINT [FK_KaEafSozioberuflicheBilanz_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] CHECK CONSTRAINT [FK_KaEafSozioberuflicheBilanz_FaLeistung]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessEinladungErfolgt]  DEFAULT ((0)) FOR [ProzessEinladungErfolgt]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessAufnahmeverfahrenErfolgt]  DEFAULT ((0)) FOR [ProzessAufnahmeverfahrenErfolgt]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessErmittlungsprogrammErstellt]  DEFAULT ((0)) FOR [ProzessErmittlungsprogrammErstellt]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessFaehigkeitsprofilMelba]  DEFAULT ((0)) FOR [ProzessFaehigkeitsprofilMelba]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessZwischengespraech]  DEFAULT ((0)) FOR [ProzessZwischengespraech]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessVerzahnungsgespraech1]  DEFAULT ((0)) FOR [ProzessVerzahnungsgespraech1]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessVerzahnungsgespraech2]  DEFAULT ((0)) FOR [ProzessVerzahnungsgespraech2]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessVerzahnungsgespraech3]  DEFAULT ((0)) FOR [ProzessVerzahnungsgespraech3]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessAbschlussgespraechErfolgt]  DEFAULT ((0)) FOR [ProzessAbschlussgespraechErfolgt]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessSchlussbericht]  DEFAULT ((0)) FOR [ProzessSchlussbericht]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessFaehigkeitsAnalyse]  DEFAULT ((0)) FOR [ProzessFaehigkeitsAnalyse]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessBewerbungskompetenz]  DEFAULT ((0)) FOR [ProzessBewerbungskompetenz]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_ProzessAustrittsbefragungErfolgt]  DEFAULT ((0)) FOR [ProzessAustrittsbefragungErfolgt]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaEafSozioberuflicheBilanz] ADD  CONSTRAINT [DF_KaEafSozioberuflicheBilanz_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

