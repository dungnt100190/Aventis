CREATE TABLE [dbo].[BaLand](
	[BaLandID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[TextFR] [varchar](200) NOT NULL,
	[TextIT] [varchar](200) NOT NULL,
	[TextEN] [varchar](200) NOT NULL,
	[Iso2Code] [varchar](2) NULL,
	[Iso3Code] [varchar](3) NULL,
	[BFSCode] [int] NULL,
	[SortKey] [int] NULL,
	[SAPCode] [varchar](20) NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[BFSDelivered] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaLandTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaLand] PRIMARY KEY CLUSTERED 
(
	[BaLandID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_BaLand_BaLandID_Text_TextFR_TextIT_TextEN] ON [dbo].[BaLand] 
(
	[BaLandID] ASC,
	[Text] ASC,
	[TextFR] ASC,
	[TextIT] ASC,
	[TextEN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name des Landes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zweistelliger ISO Code; 3166 Alpha-2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'Iso2Code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dreistelliger ISO Code; 3166 Alpha-3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'Iso3Code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ländercodes für die Schnittstelle zu SAP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'SAPCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Wert von BFS geliefert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'BFSDelivered'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt der Erstellung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz als letzter verändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt der letzten Änderung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaLand', @level2type=N'COLUMN',@level2name=N'Modified'
GO

ALTER TABLE [dbo].[BaLand] ADD  CONSTRAINT [DF_BaLand_BFSDelivered]  DEFAULT ((0)) FOR [BFSDelivered]
GO

ALTER TABLE [dbo].[BaLand] ADD  CONSTRAINT [DF_BaLand_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaLand] ADD  CONSTRAINT [DF_BaLand_Modified]  DEFAULT (getdate()) FOR [Modified]
GO