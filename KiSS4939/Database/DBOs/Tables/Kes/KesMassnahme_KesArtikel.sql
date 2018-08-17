CREATE TABLE [dbo].[KesMassnahme_KesArtikel](
	[KesMassnahme_KesArtikelID] [int] IDENTITY(1,1) NOT NULL,
	[KesMassnahmeID] [int] NOT NULL,
	[KesArtikelID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesMassnahme_KesArtikelTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesMassnahme_KesArtikel] PRIMARY KEY CLUSTERED 
(
	[KesMassnahme_KesArtikelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KesMassnahme_KesArtikel_KesArtikelID]    Script Date: 02/04/2014 12:16:27 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_KesArtikel_KesArtikelID] ON [dbo].[KesMassnahme_KesArtikel] 
(
	[KesArtikelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahme_KesArtikel_KesMassnahmeID]    Script Date: 02/04/2014 12:16:27 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_KesArtikel_KesMassnahmeID] ON [dbo].[KesMassnahme_KesArtikel] 
(
	[KesMassnahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesMassnahme_KesArtikel_KesMassnahmeID_KesArtikelID]    Script Date: 02/04/2014 12:16:27 ******/
CREATE NONCLUSTERED INDEX [IX_KesMassnahme_KesArtikel_KesMassnahmeID_KesArtikelID] ON [dbo].[KesMassnahme_KesArtikel] 
(
	[KesMassnahmeID] ASC,
	[KesArtikelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'KesMassnahme_KesArtikelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Tabelle KesMassnahme, Spalte KesMassnahmeID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'KesMassnahmeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Tabelle KesArtikel, Spalte KesArtikelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'KesArtikelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripiton', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optmistic Locking.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel', @level2type=N'COLUMN',@level2name=N'KesMassnahme_KesArtikelTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle von KesMassnahme und KesArtikel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme_KesArtikel'
GO

ALTER TABLE [dbo].[KesMassnahme_KesArtikel]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_KesArtikel_KesArtikel] FOREIGN KEY([KesArtikelID])
REFERENCES [dbo].[KesArtikel] ([KesArtikelID])
GO

ALTER TABLE [dbo].[KesMassnahme_KesArtikel] CHECK CONSTRAINT [FK_KesMassnahme_KesArtikel_KesArtikel]
GO

ALTER TABLE [dbo].[KesMassnahme_KesArtikel]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_KesArtikel_KesMassnahme] FOREIGN KEY([KesMassnahmeID])
REFERENCES [dbo].[KesMassnahme] ([KesMassnahmeID])
GO

ALTER TABLE [dbo].[KesMassnahme_KesArtikel] CHECK CONSTRAINT [FK_KesMassnahme_KesArtikel_KesMassnahme]
GO

ALTER TABLE [dbo].[KesMassnahme_KesArtikel] ADD  CONSTRAINT [DF_KesMassnahme_KesArtikel_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesMassnahme_KesArtikel] ADD  CONSTRAINT [DF_KesMassnahme_KesArtikel_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


