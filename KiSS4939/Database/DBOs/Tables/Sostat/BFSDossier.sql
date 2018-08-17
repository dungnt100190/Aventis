CREATE TABLE [dbo].[BFSDossier](
	[BFSDossierID] [int] IDENTITY(1,1) NOT NULL,
	[BFSKatalogVersionID] [int] NOT NULL,
	[FaLeistungID] [int] NULL,
	[UserID] [int] NULL,
	[LaufNr] [int] NOT NULL,
	[ZustaendigeGemeinde] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[Jahr] [int] NOT NULL,
	[Stichtag] [bit] NOT NULL,
	[BFSDossierStatusCode] [int] NULL,
	[BFSLeistungsartCode] [int] NOT NULL,
	[ImportDatum] [datetime] NULL,
	[PlausibilisierungDatum] [datetime] NULL,
	[ExportDatum] [datetime] NULL,
	[XML] [varchar](max) NULL,
	[BFSDossierTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BFSDossier] PRIMARY KEY CLUSTERED 
(
	[BFSDossierID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BFSDossier_BFSKatalogVersionID] ON [dbo].[BFSDossier] 
(
	[BFSKatalogVersionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BFSDossier_FaLeistungID] ON [dbo].[BFSDossier] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BFSDossier_UserID] ON [dbo].[BFSDossier] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BFSDossier Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'BFSDossierID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BFSDossier_BFSKatalogVersion) => BFSKatalogVersion.BFSKatalogVersionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'BFSKatalogVersionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BFSDossier_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BFSDossier_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die LaufNr wird für das Erstellen der BFS-Dossiernummer benötigt. Nach einen Unterbruch von mehr als 6 Monate wird die LaufNr incrementiert. (BFS-DossierNr = BaPersonID + ZustaendigeGemerinde + LaufNr)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'LaufNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BFS-Code der zuständige Gemeinde. Wird für die BFS-DossierNr benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'ZustaendigeGemeinde'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der erste Zahlung (Aufnahmedatum). Wird für die BFS-DossierNr benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zum definieren ob es ein Stichtag- oder ein Anfangszustand-Dossier ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'Stichtag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? obsolete??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'BFSDossierStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der BFS-Leistungsart aus BFSLOV-Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'BFSLeistungsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Imports' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'ImportDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Plausibilisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'PlausibilisierungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Exports' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier', @level2type=N'COLUMN',@level2name=N'ExportDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die einzelnen BFS-Dossiers (Anfangszustands- und Folgedossiers)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSDossier'
GO

ALTER TABLE [dbo].[BFSDossier]  WITH CHECK ADD  CONSTRAINT [FK_BFSDossier_BFSKatalogVersion] FOREIGN KEY([BFSKatalogVersionID])
REFERENCES [dbo].[BFSKatalogVersion] ([BFSKatalogVersionID])
GO

ALTER TABLE [dbo].[BFSDossier] CHECK CONSTRAINT [FK_BFSDossier_BFSKatalogVersion]
GO

ALTER TABLE [dbo].[BFSDossier]  WITH CHECK ADD  CONSTRAINT [FK_BFSDossier_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BFSDossier] CHECK CONSTRAINT [FK_BFSDossier_FaLeistung]
GO

ALTER TABLE [dbo].[BFSDossier]  WITH CHECK ADD  CONSTRAINT [FK_BFSDossier_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BFSDossier] CHECK CONSTRAINT [FK_BFSDossier_XUser]
GO

ALTER TABLE [dbo].[BFSDossier] ADD  CONSTRAINT [DF_BFSDossier_Stichtag]  DEFAULT ((0)) FOR [Stichtag]
GO