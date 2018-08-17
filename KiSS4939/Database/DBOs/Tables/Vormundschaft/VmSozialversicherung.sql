CREATE TABLE [dbo].[VmSozialversicherung](
	[VmSozialversicherungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[BaPersonID_Adressat] [int] NULL,
	[BaInstitutionID_Adressat] [int] NULL,
	[VmPriMaID_Adressat] [int] NULL,
	[DocumentID_Korrespondenz] [int] NULL,
	[VmSozialversicherungenBezeichnungenCode] [int] NULL,
	[Grund] [varchar](max) NULL,
	[Eingereicht] [datetime] NULL,
	[VerfuegungVom] [datetime] NULL,
	[Berechnungsgrundlage] [varchar](300) NULL,
	[Verfuegungsbetrag] [money] NULL,
	[Bemerkungen] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmSozialversicherungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmSozialversicherung] PRIMARY KEY CLUSTERED 
(
	[VmSozialversicherungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmSozialversicherung_BaInstitutionID_Adressat]    Script Date: 01/25/2011 09:09:39 ******/
CREATE NONCLUSTERED INDEX [IX_VmSozialversicherung_BaInstitutionID_Adressat] ON [dbo].[VmSozialversicherung] 
(
	[BaInstitutionID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSozialversicherung_BaPersonID_Adressat]    Script Date: 01/25/2011 09:09:39 ******/
CREATE NONCLUSTERED INDEX [IX_VmSozialversicherung_BaPersonID_Adressat] ON [dbo].[VmSozialversicherung] 
(
	[BaPersonID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSozialversicherung_Korrespondenz]    Script Date: 01/25/2011 09:09:39 ******/
CREATE NONCLUSTERED INDEX [IX_VmSozialversicherung_Korrespondenz] ON [dbo].[VmSozialversicherung] 
(
	[DocumentID_Korrespondenz] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'VmSozialversicherungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur LeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu BaPerson (Adressat)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'BaPersonID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur BaInstitution, Adressat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'BaInstitutionID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum VmPriMa (Private Mandatsträger) für das Adressat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'VmPriMaID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüsssel zum Dokument, Rolle Korrespondenz.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'DocumentID_Korrespondenz'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'VmSozialversicherungenBezeichnungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'VmSozialversicherungenBezeichnungenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'VmSozialversicherungenBezeichnungenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Grund'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'eingereicht am' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Eingereicht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verfügung vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'VerfuegungVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Berechnungsgrundlage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Berechnungsgrundlage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verfügungsbetrag monatlich.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Verfuegungsbetrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt modifiziert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz modifiziert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung', @level2type=N'COLUMN',@level2name=N'VmSozialversicherungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sozialversicherung im Modul Vormundschaftliche Massnahmen, Administration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSozialversicherung'
GO

ALTER TABLE [dbo].[VmSozialversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSozialversicherung_BaInstitution] FOREIGN KEY([BaInstitutionID_Adressat])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[VmSozialversicherung] CHECK CONSTRAINT [FK_VmSozialversicherung_BaInstitution]
GO

ALTER TABLE [dbo].[VmSozialversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSozialversicherung_BaPerson] FOREIGN KEY([BaPersonID_Adressat])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[VmSozialversicherung] CHECK CONSTRAINT [FK_VmSozialversicherung_BaPerson]
GO

ALTER TABLE [dbo].[VmSozialversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSozialversicherung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmSozialversicherung] CHECK CONSTRAINT [FK_VmSozialversicherung_FaLeistung]
GO

ALTER TABLE [dbo].[VmSozialversicherung]  WITH CHECK ADD  CONSTRAINT [FK_VmSozialversicherung_VmPriMa] FOREIGN KEY([VmPriMaID_Adressat])
REFERENCES [dbo].[VmPriMa] ([VmPriMaID])
GO

ALTER TABLE [dbo].[VmSozialversicherung] CHECK CONSTRAINT [FK_VmSozialversicherung_VmPriMa]
GO

ALTER TABLE [dbo].[VmSozialversicherung] ADD  CONSTRAINT [DF_VmSozialversicherung_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmSozialversicherung] ADD  CONSTRAINT [DF_VmSozialversicherung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmSozialversicherung] ADD  CONSTRAINT [DF_VmSozialversicherung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

