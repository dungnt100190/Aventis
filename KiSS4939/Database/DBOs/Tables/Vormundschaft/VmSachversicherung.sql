CREATE TABLE [dbo].[VmSachversicherung](
	[VmSachversicherungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[VmPriMaID] [int] NULL,
	[DocumentID_Mutation] [int] NULL,
	[DocumentID_MittAnm] [int] NULL,
	[DocumentID_AufhKuend] [int] NULL,
	[VmVersicherungsartSachversicherungCode] [int] NULL,
	[Policenummer] [varchar](100) NULL,
	[Selbstbehalt] [decimal](18, 0) NULL,
	[Grundpraemie] [varchar](100) NULL,
	[VmZahlungsturnusCode] [int] NULL,
	[LaufzeitVon] [datetime] NULL,
	[LaufzeitBis] [datetime] NULL,
	[VersichertSeit] [datetime] NULL,
	[Person] [varchar](200) NULL,
	[Bemerkungen] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmSachversicherungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmSachversicherung] PRIMARY KEY CLUSTERED 
(
	[VmSachversicherungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmSachversicherung_BaInstitutionID]    Script Date: 01/25/2011 09:10:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmSachversicherung_BaInstitutionID] ON [dbo].[VmSachversicherung] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSachversicherung_BaPersonId]    Script Date: 01/25/2011 09:10:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmSachversicherung_BaPersonId] ON [dbo].[VmSachversicherung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSachversicherung_DocumentID_AufhKuend]    Script Date: 01/25/2011 09:10:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmSachversicherung_DocumentID_AufhKuend] ON [dbo].[VmSachversicherung] 
(
	[DocumentID_AufhKuend] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSachversicherung_DocumentID_MittAnm]    Script Date: 01/25/2011 09:10:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmSachversicherung_DocumentID_MittAnm] ON [dbo].[VmSachversicherung] 
(
	[DocumentID_MittAnm] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSachversicherung_DocumentID_Mutation]    Script Date: 01/25/2011 09:10:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmSachversicherung_DocumentID_Mutation] ON [dbo].[VmSachversicherung] 
(
	[DocumentID_Mutation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSachversicherung_FaLeistungsID]    Script Date: 01/25/2011 09:10:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmSachversicherung_FaLeistungsID] ON [dbo].[VmSachversicherung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSachversicherung_VmPriMaID]    Script Date: 01/25/2011 09:10:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmSachversicherung_VmPriMaID] ON [dbo].[VmSachversicherung] 
(
	[VmPriMaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VmSachversicherung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'VmSachversicherungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Adressat, falls es eine Person ist und nicht eine Institution. Siehe auch BaInstitutionId.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Adressat, falls es eine Institution ist und nicht eine BaPerson ist. Siehe auch InstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu VmPriMa (Privater Mandatsträger).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'VmPriMaID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument "Mutation"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'DocumentID_Mutation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument "Mitteilung / Anmeldung".' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'DocumentID_MittAnm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument "Aufhebung / Kündigung"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'DocumentID_AufhKuend'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art der Versicherung. Beispiele: Haftpflicht, Hausrat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'VmVersicherungsartSachversicherungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Policennummer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Policenummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstbehalt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Selbstbehalt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grundprämie als Textfeld.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Grundpraemie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zahlungsturnus. Beispiele: monatlich, zweimonatlich ...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'VmZahlungsturnusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Laufzeit von.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'LaufzeitVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Laufzeit bis Datum.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'LaufzeitBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Versichert seit Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'VersichertSeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zusätzliche und andere versicherte Person/en' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Person'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz gelöscht ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz  erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSachversicherung', @level2type=N'COLUMN',@level2name=N'VmSachversicherungTS'
GO

ALTER TABLE [dbo].[VmSachversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSachversicherung_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[VmSachversicherung] CHECK CONSTRAINT [FK_VmSachversicherung_BaInstitution]
GO

ALTER TABLE [dbo].[VmSachversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSachversicherung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[VmSachversicherung] CHECK CONSTRAINT [FK_VmSachversicherung_BaPerson]
GO

ALTER TABLE [dbo].[VmSachversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSachversicherung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmSachversicherung] CHECK CONSTRAINT [FK_VmSachversicherung_FaLeistung]
GO

ALTER TABLE [dbo].[VmSachversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSachversicherung_VmPriMa] FOREIGN KEY([VmPriMaID])
REFERENCES [dbo].[VmPriMa] ([VmPriMaID])
GO

ALTER TABLE [dbo].[VmSachversicherung] CHECK CONSTRAINT [FK_VmSachversicherung_VmPriMa]
GO

ALTER TABLE [dbo].[VmSachversicherung] ADD  CONSTRAINT [VmSachversicherung_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmSachversicherung] ADD  CONSTRAINT [DF_VmSachversicherung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmSachversicherung] ADD  CONSTRAINT [DF_VmSachversicherung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


