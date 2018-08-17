CREATE TABLE [dbo].[KaAbklaerungVertieft](
	[KaAbklaerungVertieftID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[KaKurserfassungID] [int] NULL,
	[Datum] [datetime] NULL,
	[KaAbklaerungPhaseVertiefteAbklaerungenCode] [int] NULL,
	[KaAbklaerungStatusDossierCode] [int] NULL,
	[DatumKursAbbruch] [datetime] NULL,
	[KaAbklaerungPraesenzCode] [int] NULL,
	[KaAbklaerungProbeeinsatzInCode] [int] NULL,
	[EinsatzVon] [datetime] NULL,
	[EinsatzBis] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[DatumIntegration] [datetime] NULL,
	[KaAbklaerungIntegrBeurCode] [int] NULL,
	[DocumentID_Integration] [int] NULL,
	[KaAbklaerungGrundDossCode] [int] NULL,
	[DatumAustritt] [datetime] NULL,
	[DocumentID_Schlussbericht] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaAbklaerungVertieftTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaAbklaerungVertieft] PRIMARY KEY CLUSTERED 
(
	[KaAbklaerungVertieftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaAbklaerungVertieft_FaLeistungID]    Script Date: 01/13/2014 11:15:45 ******/
CREATE NONCLUSTERED INDEX [IX_KaAbklaerungVertieft_FaLeistungID] ON [dbo].[KaAbklaerungVertieft] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KaAbklaerungVertieft_KaKurserfassungID]    Script Date: 01/13/2014 11:15:45 ******/
CREATE NONCLUSTERED INDEX [IX_KaAbklaerungVertieft_KaKurserfassungID] ON [dbo].[KaAbklaerungVertieft] 
(
	[KaKurserfassungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaAbklaerungVertieft Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungVertieftID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaAbklaerungVertieft_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaAbklaerungVertieft_KaKurserfassung) => KaKurserfassung.KaKurserfassungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaKurserfassungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Abklärung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld Modul' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungPhaseVertiefteAbklaerungenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld Status Dossier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungStatusDossierCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Kursabbruchs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'DatumKursAbbruch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Präsenz Kurs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungPraesenzCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Probeeinsatz in' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungProbeeinsatzInCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum von des Einsatzes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'EinsatzVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum bis des Einsatzes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'EinsatzBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Integration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'DatumIntegration'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der Integrationsbeurteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungIntegrBeurCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XDocument für die Integrationsbeurteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'DocumentID_Integration'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund Dossierrückgabe (LOV KaAbklärungGrundDoss)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungGrundDossCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Austritts bei einer Dossierrückgabe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'DatumAustritt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XDocument für das Schlussbericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'DocumentID_Schlussbericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob den Datensatz auch für Benutzern aus SD sichtbar ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'SichtbarSDFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft', @level2type=N'COLUMN',@level2name=N'KaAbklaerungVertieftTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um vertiefte Abklärungen zu erfassen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieft'
GO

ALTER TABLE [dbo].[KaAbklaerungVertieft]  WITH CHECK ADD  CONSTRAINT [FK_KaAbklaerungVertieft_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaAbklaerungVertieft] CHECK CONSTRAINT [FK_KaAbklaerungVertieft_FaLeistung]
GO

ALTER TABLE [dbo].[KaAbklaerungVertieft]  WITH CHECK ADD  CONSTRAINT [FK_KaAbklaerungVertieft_KaKurserfassung] FOREIGN KEY([KaKurserfassungID])
REFERENCES [dbo].[KaKurserfassung] ([KaKurserfassungID])
GO

ALTER TABLE [dbo].[KaAbklaerungVertieft] CHECK CONSTRAINT [FK_KaAbklaerungVertieft_KaKurserfassung]
GO

ALTER TABLE [dbo].[KaAbklaerungVertieft] ADD  CONSTRAINT [DF_KaAbklaerungVertieft_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaAbklaerungVertieft] ADD  CONSTRAINT [DF_KaAbklaerungVertieft_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaAbklaerungVertieft] ADD  CONSTRAINT [DF_KaAbklaerungVertieft_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


