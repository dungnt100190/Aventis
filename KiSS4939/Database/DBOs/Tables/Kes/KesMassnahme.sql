CREATE TABLE [dbo].[KesMassnahme](
  [KesMassnahmeID] [int] IDENTITY(1,1) NOT NULL,
  [FaLeistungID] [int] NOT NULL,
  [IsKS] [bit] NOT NULL,
  [DocumentID_Errichtungsbeschluss] [int] NULL,
  [DocumentID_Aufhebungsbeschluss] [int] NULL,
  [DatumVon] [datetime] NULL,
  [DatumBis] [datetime] NULL,
  [KesAufgabenbereichCodes] [varchar](255) NULL,
  [KesIndikationCodes] [varchar](255) NULL,
  [Auftragstext] [varchar](max) NULL,
  [KesElterlicheSorgeObhutCode_ElterlicheSorge] [int] NULL,
  [KesElterlicheSorgeObhutCode_Obhut] [int] NULL,
  [FuersorgerischeUnterbringung] [bit] NOT NULL,
  [Platzierung_BaInstitutionID] [int] NULL,
  [KesGrundlageCode] [int] NULL,
  [UebernahmeVon_Datum] [datetime] NULL,
  [UebernahmeVon_OrtschaftCode] [int] NULL,
  [UebernahmeVon_PLZ] [varchar](10) NULL,
  [UebernahmeVon_Ort] [varchar](50) NULL,
  [UebernahmeVon_Kanton] [varchar](max) NULL,
  [UebernahmeVon_KesBehoerdeID] [int] NULL,
  [AenderungVom_Datum] [datetime] NULL,
  [KesAenderungsgrundCode] [int] NULL,
  [UebertragungAn_Datum] [datetime] NULL,
  [UebertragungAn_OrtschaftCode] [int] NULL,
  [UebertragungAn_PLZ] [varchar](10) NULL,
  [UebertragungAn_Ort] [varchar](50) NULL,
  [UebertragungAn_Kanton] [varchar](max) NULL,
  [UebertragungAn_KesBehoerdeID] [int] NULL,
  [KesAufhebungsgrundCode] [int] NULL,
  [Bemerkung] [varchar](max) NULL,
  [Zustaendig_KesBehoerdeID] [int] NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KesMassnahmeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesMassnahme] PRIMARY KEY CLUSTERED 
(
  [KesMassnahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KesMassnahme_FaLeistungID]    Script Date: 10/09/2014 11:44:07 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_FaLeistungID] ON [dbo].[KesMassnahme] 
(
  [FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahme_UebernahmeVon_KesBehoerdeID]    Script Date: 10/09/2014 11:44:07 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_UebernahmeVon_KesBehoerdeID] ON [dbo].[KesMassnahme] 
(
  [UebernahmeVon_KesBehoerdeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_KesMassnahme_UebertragungAn_KesBehoerdeID]    Script Date: 10/09/2014 11:44:07 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_UebertragungAn_KesBehoerdeID] ON [dbo].[KesMassnahme] 
(
  [UebertragungAn_KesBehoerdeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_KesMassnahme_Platzierung_BaInstitutionID]    Script Date: 10/09/2014 11:44:07 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_Platzierung_BaInstitutionID] ON [dbo].[KesMassnahme] 
(
  [Platzierung_BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_KesMassnahme_Zustaendig_KesBehoerdeID]    Script Date: 10/09/2014 11:44:07 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_Zustaendig_KesBehoerdeID] ON [dbo].[KesMassnahme] 
(
  [Zustaendig_KesBehoerdeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel Kes Massnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesMassnahmeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KesMassnahme_FaLeistung) => FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kindesschutz oder Erwachsenenschutz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'IsKS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Errichtungsbeschluss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'DocumentID_Errichtungsbeschluss'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Aufhebungsbeschluss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'DocumentID_Aufhebungsbeschluss'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahme Beginn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahme Ende' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Liste von Aufgabenbereichen (LOV KesAufgabenbereichES)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesAufgabenbereichCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Liste von Indikationen (LOV KesIndikationES oder KesIndikationKS)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesIndikationCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auftragstext' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Auftragstext'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Elterliche Sorge (LOV KesElterlicheSorgeObhut)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesElterlicheSorgeObhutCode_ElterlicheSorge'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Obhut (LOV KesElterlicheSorgeObhut)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesElterlicheSorgeObhutCode_Obhut'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grundlage (LOV KesGrundlage)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesGrundlageCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschriftung Fürsorgerische Unterbringung FU' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'FuersorgerischeUnterbringung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum ÜbernahmeVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebernahmeVon_Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ortschaft ÜbernahmeVon (zeigt auf BaPlz, ist aber kein Fremdschlüssel)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebernahmeVon_OrtschaftCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLZ ÜbernahmeVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebernahmeVon_PLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ort ÜbernahmeVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebernahmeVon_Ort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kanton ÜbernahmeVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebernahmeVon_Kanton'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KESB ÜbernahmeVon (Fremdschlüssel FK_KesMassnahme_UebernahmeVon_KesBehoerdeID) => KesBehoerdeID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebernahmeVon_KesBehoerdeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum AenderungVom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'AenderungVom_Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Änderungsgrund (LOV KesAenderungsgrund)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesAenderungsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum ÜbertragungAn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebertragungAn_Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ortschaft ÜbertragungAn (zeigt auf BaPlz, ist aber kein Fremdschlüssel)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebertragungAn_OrtschaftCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLZ ÜbertragungAn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebertragungAn_PLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ort ÜbertragungAn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebertragungAn_Ort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kanton ÜbertragungAn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebertragungAn_Kanton'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KESB ÜbertragungAn (Fremdschlüssel FK_KesMassnahme_UebertragungAn_KesBehoerdeID) => KesBehoerdeID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'UebertragungAn_KesBehoerdeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Platzierung in einer Institution (Fremdschlüssel FK_KesMassnahme_Platzierung_BaInstitutionID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Platzierung_BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aufhebungsgrund (LOV KesAufhebungsgrund)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesAufhebungsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KOKES Zuständige Behörde (Fremdschlüssel FK_KesMassnahme_Zustaendig_KesBehoerdeID) => KesBehoerdeID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Zustaendig_KesBehoerdeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesMassnahmeTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kes Massnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme'
GO

ALTER TABLE [dbo].[KesMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KesMassnahme] CHECK CONSTRAINT [FK_KesMassnahme_FaLeistung]
GO

ALTER TABLE [dbo].[KesMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_KesBehoerde_UebernahmeVon_KesBehoerdeID] FOREIGN KEY([UebernahmeVon_KesBehoerdeID])
REFERENCES [dbo].[KesBehoerde] ([KesBehoerdeID])
GO

ALTER TABLE [dbo].[KesMassnahme] CHECK CONSTRAINT [FK_KesMassnahme_KesBehoerde_UebernahmeVon_KesBehoerdeID]
GO

ALTER TABLE [dbo].[KesMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_KesBehoerde_UebertragungAn_KesBehoerdeID] FOREIGN KEY([UebertragungAn_KesBehoerdeID])
REFERENCES [dbo].[KesBehoerde] ([KesBehoerdeID])
GO

ALTER TABLE [dbo].[KesMassnahme] CHECK CONSTRAINT [FK_KesMassnahme_KesBehoerde_UebertragungAn_KesBehoerdeID]
GO

ALTER TABLE [dbo].[KesMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_Platzierung_BaInstitutionID] FOREIGN KEY([Platzierung_BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KesMassnahme] CHECK CONSTRAINT [FK_KesMassnahme_Platzierung_BaInstitutionID]
GO

ALTER TABLE [dbo].[KesMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_KesBehoerde_Zustaendig_KesBehoerdeID] FOREIGN KEY([Zustaendig_KesBehoerdeID])
REFERENCES [dbo].[KesBehoerde] ([KesBehoerdeID])
GO

ALTER TABLE [dbo].[KesMassnahme] CHECK CONSTRAINT [FK_KesMassnahme_KesBehoerde_Zustaendig_KesBehoerdeID]
GO

ALTER TABLE [dbo].[KesMassnahme] ADD  CONSTRAINT [DF_KesMassnahme_IsKS]  DEFAULT ((0)) FOR [IsKS]
GO

ALTER TABLE [dbo].[KesMassnahme] ADD  CONSTRAINT [DF_KesMassnahme_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesMassnahme] ADD  CONSTRAINT [DF_KesMassnahme_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

ALTER TABLE [dbo].[KesMassnahme] ADD  CONSTRAINT [DF_KesMassnahme_FuersorgerischeUnterbringung]  DEFAULT ((0)) FOR [FuersorgerischeUnterbringung]
GO

