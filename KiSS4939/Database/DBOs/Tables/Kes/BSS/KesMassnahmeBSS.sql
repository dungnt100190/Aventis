CREATE TABLE [dbo].[KesMassnahmeBSS](
	[KesMassnahmeBSSID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[VmPriMaID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[KesArtikelID_MassnahmegebundeneGeschaefte] [int] NULL,
	[KesArtikelID_NichtMassnahmegebundeneGeschaefte] [int] NULL,
	[Platzierung_BaInstitutionID] [int] NULL,
	[KesMassnahmeTypCode] [int] NOT NULL,
	[KesBeistandsartCode] [int] NULL,
	[KesGefaehrdungsmeldungDurchCode] [int] NULL,
	[KesAenderungsgrundCode] [int] NULL,
	[KesAufhebungsgrundCode] [int] NULL,
	[KESBDocumentID] [int] NULL,
	[DocumentID_Urkunde] [int] NULL,
	[ErrichtungVom] [datetime] NULL,
	[AenderungVom] [datetime] NULL,
	[UebernahmeVom] [datetime] NULL,
	[BerichtsgenehmigungVom] [datetime] NULL,
	[Beistandswechsel] [datetime] NULL,
	[UebertragungVom] [datetime] NULL,
	[AufhebungVom] [datetime] NULL,
	[KesAufgabenbereichCodes] [varchar](255) NULL,
	[KesGrundlageCode] [int] NULL,
	[KesIndikationCodes] [varchar](255) NULL,
	[KesElterlicheSorgeObhutCode_ElterlicheSorge] [int] NULL,
	[KesElterlicheSorgeObhutCode_Obhut] [int] NULL,
	[PLZ] [varchar](10) NULL,
	[Ort] [varchar](50) NULL,
	[OrtschaftCode] [int] NULL,
	[Kanton] [varchar](10) NULL,
	[FuersorgerischeUnterbringung] [bit] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[KesMassnahmeBSSTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesMassnahmeBSS] PRIMARY KEY CLUSTERED 
(
	[KesMassnahmeBSSID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KesMassnahmeBSS_BaInstitutionID]    Script Date: 02/04/2014 12:09:01 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBSS_BaInstitutionID] ON [dbo].[KesMassnahmeBSS] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahmeBSS_FaLeistungID]    Script Date: 02/04/2014 12:09:01 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBSS_FaLeistungID] ON [dbo].[KesMassnahmeBSS] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahmeBSS_KesArtikelID_MassnahmegebundeneGeschaefte]    Script Date: 02/04/2014 12:09:01 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBSS_KesArtikelID_MassnahmegebundeneGeschaefte] ON [dbo].[KesMassnahmeBSS] 
(
	[KesArtikelID_MassnahmegebundeneGeschaefte] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahmeBSS_KesArtikelID_NichtMassnahmegebundeneGeschaefte]    Script Date: 02/04/2014 12:09:01 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBSS_KesArtikelID_NichtMassnahmegebundeneGeschaefte] ON [dbo].[KesMassnahmeBSS] 
(
	[KesArtikelID_NichtMassnahmegebundeneGeschaefte] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_KesMassnahmeBSS_Platzierung_BaInstitutionID]    Script Date: 12/07/2015 18:18:38 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBSS_Platzierung_BaInstitutionID] ON [dbo].[KesMassnahmeBSS] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahmeBSS_UserID]    Script Date: 02/04/2014 12:09:01 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBSS_UserID] ON [dbo].[KesMassnahmeBSS] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahmeBSS_VmPriMaID]    Script Date: 02/04/2014 12:09:01 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBSS_VmPriMaID] ON [dbo].[KesMassnahmeBSS] 
(
	[VmPriMaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel Kes Massnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesMassnahmeBSSID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KesMassnahmeBSS_FaLeistung) => FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahmeführender (Berufsbeistand), Fremdschlüssel (FK_KesMassnahmeBSS_XUser) => UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahmeführender (Privatperson), Fremdschlüssel (FK_KesMassnahmeBSS_VmPriMa) => VmPriMaID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'VmPriMaID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahmeführender (Fachbeistand), Fremdschlüssel (FK_KesMassnahmeBSS_BaInstitution) => BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahmegebundene Geschäfte, Fremdschlüssel (FK_KesMassnahmeBSS_KesArtikel) => KesArtikelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesArtikelID_MassnahmegebundeneGeschaefte'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nicht Massnahmegebundene Geschäfte, Fremdschlüssel (FK_KesMassnahmeBSS_KesArtikel) => KesArtikelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesArtikelID_NichtMassnahmegebundeneGeschaefte'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahmen Typ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesMassnahmeTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beistandsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesBeistandsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gefährdungsmeldung durch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesGefaehrdungsmeldungDurchCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Änderungsgrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesAenderungsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aufhebungsgrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesAufhebungsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verfügung/Auftrag KESB DokumentID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KESBDocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Für die eingescannte Ernennungsurkunde in KES-Massnahmen-ES' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'DocumentID_Urkunde'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Errichtung vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'ErrichtungVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Änderung vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'AenderungVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Übernahme vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'UebernahmeVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Beistandswechsel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Beistandswechsel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Übertragung vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'UebertragungVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aufhebung vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'AufhebungVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aufgabenbereich (LOV KesAufgabenbereichES)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesAufgabenbereichCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indikation (LOV KesIndikationES oder KesIndikationKS jenach Wert in KesMassnahmeTypCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesIndikationCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wert der Werteliste KesElterlicheSorgeObhut im Feld ''Elterliche Sorge''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesElterlicheSorgeObhutCode_ElterlicheSorge'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wert der Werteliste KesElterlicheSorgeObhut im Feld ''Obhut''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesElterlicheSorgeObhutCode_Obhut'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLZ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'PLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ort' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Ort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ortschaftscode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'OrtschaftCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kanton' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Kanton'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Massnahme Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hat den Wert 1, wenn der Datensatz logisch gelöscht ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Platzierung in einer Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'Platzierung_BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschriftung Berichtsgenehmigung vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'BerichtsgenehmigungVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschriftung Fürsorgerische Unterbringung FU' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'FuersorgerischeUnterbringung'
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS', @level2type=N'COLUMN',@level2name=N'KesMassnahmeBSSTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'André Wittwer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kes Massnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBSS'
GO

ALTER TABLE [dbo].[KesMassnahmeBSS]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBSS_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] CHECK CONSTRAINT [FK_KesMassnahmeBSS_BaInstitution]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBSS_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] CHECK CONSTRAINT [FK_KesMassnahmeBSS_FaLeistung]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBSS_KesArtikel_Massnahmegebunden] FOREIGN KEY([KesArtikelID_MassnahmegebundeneGeschaefte])
REFERENCES [dbo].[KesArtikel] ([KesArtikelID])
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] CHECK CONSTRAINT [FK_KesMassnahmeBSS_KesArtikel_Massnahmegebunden]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBSS_KesArtikel_NichtMassnahmegebunden] FOREIGN KEY([KesArtikelID_NichtMassnahmegebundeneGeschaefte])
REFERENCES [dbo].[KesArtikel] ([KesArtikelID])
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] CHECK CONSTRAINT [FK_KesMassnahmeBSS_KesArtikel_NichtMassnahmegebunden]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBSS_VmPriMa] FOREIGN KEY([VmPriMaID])
REFERENCES [dbo].[VmPriMa] ([VmPriMaID])
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] CHECK CONSTRAINT [FK_KesMassnahmeBSS_VmPriMa]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBSS_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] CHECK CONSTRAINT [FK_KesMassnahmeBSS_XUser]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBSS_Platzierung_BaInstitution] FOREIGN KEY([Platzierung_BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] CHECK CONSTRAINT [FK_KesMassnahmeBSS_Platzierung_BaInstitution]
GO


ALTER TABLE [dbo].[KesMassnahmeBSS] ADD  CONSTRAINT [DF_KesMassnahmeBSS_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] ADD  CONSTRAINT [DF_KesMassnahmeBSS_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] ADD  CONSTRAINT [DF_KesMassnahmeBSS_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[KesMassnahmeBSS] ADD  CONSTRAINT [DF_KesMassnahmeBSS_FuersorgerischeUnterbringung]  DEFAULT ((0)) FOR [FuersorgerischeUnterbringung]
GO



