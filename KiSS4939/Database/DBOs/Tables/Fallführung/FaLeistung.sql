CREATE TABLE [dbo].[FaLeistung](
  [FaLeistungID] [int] IDENTITY(1,1) NOT NULL,
  [BaPersonID] [int] NOT NULL,
  [FaFallID] [int] NOT NULL,
  [ModulID] [int] NOT NULL,
  [UserID] [int] NOT NULL,
  [SachbearbeiterID] [int] NULL,
  [SchuldnerBaPersonID] [int] NULL,
  [FaProzessCode] [int] NULL,
  [GemeindeCode] [int] NULL,
  [LeistungsartCode] [int] NULL,
  [EroeffnungsGrundCode] [int] NULL,
  [AbschlussGrundCode] [int] NULL,
  [DatumVon] [datetime] NOT NULL,
  [DatumBis] [datetime] NULL,
  [Bemerkung] [varchar](max) NULL,
  [Dossiernummer] [varchar](20) NULL,
  [FaAufnahmeartCode] [int] NULL,
  [FaKontaktveranlasserCode] [int] NULL,
  [FaTeilleistungserbringerCodes] [varchar](255) NULL,
  [FaModulDienstleistungenCode] [int] NULL,
  [IkSchuldnerStatusCode] [int] NULL,
  [IkAufenthaltsartCode] [int] NULL,
  [IkHatUnterstuetzung] [bit] NOT NULL,
  [IkIstRentenbezueger] [bit] NOT NULL,
  [IkSchuldnerMahnen] [bit] NOT NULL,
  [IkEinnahmenQuoteCode] [int] NULL,
  [IkDatumRechtskraft] [datetime] NULL,
  [IkInkassoBemuehungCode] [int] NULL,
  [IkVerjaehrungAm] [datetime] NULL,
  [IkLeistungStatusCode] [int] NULL,
  [IkDatumForderungstitel] [datetime] NULL,
  [IkRueckerstattungTypCode] [int] NULL,
  [IkForderungTitelCode] [int] NULL,
  [IkErreichungsGradCode] [int] NULL,
  [OldUnitID] [int] NULL,
  [VmAuftragCode] [int] NULL,
  [KaProzessCode] [int] NULL,
  [KaEpqJob] [bit] NULL,
  [Bezeichnung] [varchar](50) NULL,
  [MigrationKA] [int] NULL,
  [PscdVertragsgegenstandID] [bigint] NULL,
  [MigBemerkung] [varchar](200) NULL,
  [MigHerkunftCode] [int] NULL,
  [MigAlteFallNr] [int] NULL,
  [VUFaFallID] [int] NULL,
  [visdat36Area] [varchar](255) NULL,
  [visdat36FALLID] [varchar](6) NULL,
  [visdat36LEISTUNGID] [varchar](6) NULL,
  [WiederholteSpezifischeErmittlungEAF] [bit] NOT NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [FaLeistungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaLeistung] PRIMARY KEY CLUSTERED 
(
  [FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaLeistung_BaPersonID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_BaPersonID] ON [dbo].[FaLeistung] 
(
  [BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_BaPersonID_DatumVon_FaFallID_FaProzessCode]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_BaPersonID_DatumVon_FaFallID_FaProzessCode] ON [dbo].[FaLeistung] 
(
  [BaPersonID] ASC,
  [DatumVon] DESC
)
INCLUDE ( [FaFallID],
[FaProzessCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_BaPersonID_FaLeistungID_ModulID_DatumVon]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_BaPersonID_FaLeistungID_ModulID_DatumVon] ON [dbo].[FaLeistung] 
(
  [BaPersonID] ASC,
  [FaLeistungID] ASC,
  [ModulID] ASC,
  [DatumVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_BaPersonID_ModulID_FaLeistungID_DatumVon_DatumBis_VisDatFallID_visdat36Area]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_BaPersonID_ModulID_FaLeistungID_DatumVon_DatumBis_VisDatFallID_visdat36Area] ON [dbo].[FaLeistung] 
(
  [BaPersonID] ASC,
  [ModulID] ASC,
  [FaLeistungID] ASC,
  [DatumVon] ASC,
  [DatumBis] ASC,
  [visdat36FALLID] ASC,
  [visdat36Area] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_DatumBis]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_DatumBis] ON [dbo].[FaLeistung] 
(
  [DatumBis] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_FaFallID_BaPersonID_ModulID_DatumVon_DatumBis_UserID_SachbearbeiterID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_FaFallID_BaPersonID_ModulID_DatumVon_DatumBis_UserID_SachbearbeiterID] ON [dbo].[FaLeistung] 
(
  [FaFallID] ASC
)
INCLUDE ( [FaProzessCode],
[BaPersonID],
[ModulID],
[DatumVon],
[DatumBis],
[UserID],
[SachbearbeiterID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_FaFallID_ModulID_GemeindeCode_DatumVon]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_FaFallID_ModulID_GemeindeCode_DatumVon] ON [dbo].[FaLeistung] 
(
  [FaFallID] ASC,
  [ModulID] ASC,
  [GemeindeCode] ASC,
  [DatumVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_FaLeistungID_BaPersonID_ModulID_DatumVon_DatumBis]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_FaLeistungID_BaPersonID_ModulID_DatumVon_DatumBis] ON [dbo].[FaLeistung] 
(
  [FaLeistungID] ASC,
  [BaPersonID] ASC,
  [ModulID] ASC,
  [DatumVon] ASC,
  [DatumBis] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_FaLeistungID_UserID_BaPersonID_ModulID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_FaLeistungID_UserID_BaPersonID_ModulID] ON [dbo].[FaLeistung] 
(
  [FaLeistungID] ASC,
  [UserID] ASC,
  [BaPersonID] ASC,
  [ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_FaLeistungTS]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_FaLeistungTS] ON [dbo].[FaLeistung] 
(
  [FaLeistungTS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_FaProzessCode_FaLeistungID_UserID_BaPersonID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_FaProzessCode_FaLeistungID_UserID_BaPersonID] ON [dbo].[FaLeistung] 
(
  [FaProzessCode] ASC,
  [FaLeistungID] ASC,
  [UserID] ASC,
  [BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_GemeindeCode_DatumVon_FaLeistungID_BaPersonID_ModulID_SchuldnerBaPersonID_DatumBis]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_GemeindeCode_DatumVon_FaLeistungID_BaPersonID_ModulID_SchuldnerBaPersonID_DatumBis] ON [dbo].[FaLeistung] 
(
  [GemeindeCode] ASC,
  [DatumVon] ASC
)
INCLUDE ( [FaLeistungID],
[BaPersonID],
[ModulID],
[SchuldnerBaPersonID],
[DatumBis]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_ModulID_FaLeistungID_BaPersonID_UserID_DatumVon]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_ModulID_FaLeistungID_BaPersonID_UserID_DatumVon] ON [dbo].[FaLeistung] 
(
  [ModulID] ASC,
  [FaLeistungID] ASC,
  [BaPersonID] ASC,
  [UserID] ASC,
  [DatumVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_ModulID_FaLeistungID_FaFallID_DatumBis]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_ModulID_FaLeistungID_FaFallID_DatumBis] ON [dbo].[FaLeistung] 
(
  [ModulID] ASC
)
INCLUDE ( [FaLeistungID],
[FaFallID],
[DatumBis]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaLeistung_SachbearbeiterID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_SachbearbeiterID] ON [dbo].[FaLeistung] 
(
  [SachbearbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_SchuldnerBaPersonID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_SchuldnerBaPersonID] ON [dbo].[FaLeistung] 
(
  [SchuldnerBaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_UserID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_UserID] ON [dbo].[FaLeistung] 
(
  [UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_UserID_FaLeistungID_BaPersonID_DatumBis]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_UserID_FaLeistungID_BaPersonID_DatumBis] ON [dbo].[FaLeistung] 
(
  [UserID] ASC,
  [FaLeistungID] ASC,
  [BaPersonID] ASC,
  [DatumBis] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_FaLeistung_VUFaFallID]    Script Date: 05/17/2013 14:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistung_VUFaFallID] ON [dbo].[FaLeistung] 
(
  [VUFaFallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaLeistung_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaLeistung_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'SachbearbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaLeistung_SchuldnerBaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'SchuldnerBaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nummer des KES Dossiers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'Dossiernummer'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'SchuldnerBaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'LeistungsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'MBU' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'FaAufnahmeartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'MBU' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'FaKontaktveranlasserCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV-Codes für FaTeilleistungserbringer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'FaTeilleistungserbringerCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV-Codes für FaModulDienstleistungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'FaModulDienstleistungenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'FaModulDienstleistungenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkSchuldnerStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkAufenthaltsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkHatUnterstuetzung'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkIstRentenbezueger'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkSchuldnerMahnen'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkEinnahmenQuoteCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkDatumRechtskraft'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkInkassoBemuehungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkVerjaehrungAm'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkDatumForderungstitel'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkRueckerstattungTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkForderungTitelCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'IkErreichungsGradCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'OldUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'VmAuftragCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'KaProzessCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'KaEpqJob'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'MigrationKA'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'WiederholteSpezifischeErmittlungEAF'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'PscdVertragsgegenstandID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'MigBemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'MigHerkunftCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'MigAlteFallNr'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'VUFaFallID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'visdat36Area'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'visdat36FALLID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'visdat36LEISTUNGID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung', @level2type=N'COLUMN',@level2name=N'FaLeistungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet alle fachlich historisierten Modul-Leistungen der Klientendossiers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'F, WSH, I, A, VM, etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistung'
GO

ALTER TABLE [dbo].[FaLeistung]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaLeistung] CHECK CONSTRAINT [FK_FaLeistung_BaPerson]
GO

ALTER TABLE [dbo].[FaLeistung]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistung_SachbearbeiterID] FOREIGN KEY([SachbearbeiterID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaLeistung] CHECK CONSTRAINT [FK_FaLeistung_SachbearbeiterID]
GO

ALTER TABLE [dbo].[FaLeistung]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistung_SchuldnerBaPerson] FOREIGN KEY([SchuldnerBaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaLeistung] CHECK CONSTRAINT [FK_FaLeistung_SchuldnerBaPerson]
GO

ALTER TABLE [dbo].[FaLeistung]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistung_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[FaLeistung] CHECK CONSTRAINT [FK_FaLeistung_XModul]
GO

ALTER TABLE [dbo].[FaLeistung]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaLeistung] CHECK CONSTRAINT [FK_FaLeistung_XUser]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_GemeindeCode]  DEFAULT ([dbo].[fnGetDefaultGemeindeCode]()) FOR [GemeindeCode]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_DatumVon]  DEFAULT (getdate()) FOR [DatumVon]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_IkHatUnterstuetzung]  DEFAULT ((0)) FOR [IkHatUnterstuetzung]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_IkIstRentenbezueger]  DEFAULT ((0)) FOR [IkIstRentenbezueger]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_IkSchuldnerMahnen]  DEFAULT ((1)) FOR [IkSchuldnerMahnen]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_WiederholteSpezifischeErmittlungEAF]  DEFAULT ((0)) FOR [WiederholteSpezifischeErmittlungEAF]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaLeistung] ADD  CONSTRAINT [DF_FaLeistung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

-------------------------------------------------------------------------------
-- only ZH: Adding FK to column FaFallID (FaFall.FaFallID)
-------------------------------------------------------------------------------
IF (N';' + N'{NSExt}' + N';' LIKE N'%;ZH;%' OR
    N';' + N'{NSExt}' + N';' LIKE N'%;$ZH;%')
BEGIN
  ALTER TABLE [dbo].[FaLeistung]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistung_FaFall] FOREIGN KEY([FaFallID])
  REFERENCES [dbo].[FaFall] ([FaFallID])

  ALTER TABLE [dbo].[FaLeistung] CHECK CONSTRAINT [FK_FaLeistung_FaFall]

  ALTER TABLE [dbo].[FaLeistung]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistung_VUFaFallID] FOREIGN KEY([VUFaFallID])
  REFERENCES [dbo].[FaFall] ([FaFallID])

  ALTER TABLE [dbo].[FaLeistung] CHECK CONSTRAINT [FK_FaLeistung_VUFaFallID]
END
GO