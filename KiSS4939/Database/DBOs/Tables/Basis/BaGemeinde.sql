CREATE TABLE [dbo].[BaGemeinde](
	[BaGemeindeID] [int] IDENTITY(1,1) NOT NULL,
	[BFSCode] [int] NULL,
	[PLZ] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[NameLang] [varchar](150) NULL,
	[NameTID] [int] NULL,
	[GemeindeEintragArt] [int] NULL,
	[GemeindeStatus] [int] NULL,
	[GemeindeAufnahmeNummer] [int] NULL,
	[GemeindeAufnahmeModus] [int] NULL,
	[GemeindeAufnahmeDatum] [datetime] NULL,
	[GemeindeAufhebungNummer] [int] NULL,
	[GemeindeAufhebungModus] [int] NULL,
	[GemeindeAufhebungDatum] [datetime] NULL,
	[GemeindeAenderungDatum] [datetime] NULL,
	[GemeindeHistorisierungID] [int] NULL,
	[BezirkCode] [int] NULL,
	[BezirkName] [varchar](100) NULL,
	[BezirkNameLang] [varchar](150) NULL,
	[BezirkNameTID] [int] NULL,
	[BezirkEintragArt] [int] NULL,
	[BezirkAufnahmeNummer] [int] NULL,
	[BezirkAufnahmeModus] [int] NULL,
	[BezirkAufnahmeDatum] [datetime] NULL,
	[BezirkAufhebungNummer] [int] NULL,
	[BezirkAufhebungModus] [int] NULL,
	[BezirkAufhebungDatum] [datetime] NULL,
	[BezirkAenderungDatum] [datetime] NULL,
	[KantonID] [int] NULL,
	[Kanton] [varchar](2) NULL,
	[KantonNameLang] [varchar](100) NULL,
	[BFSDelivered] [bit] NULL,
	[BaGemeindeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaGemeinde] PRIMARY KEY CLUSTERED 
(
	[BaGemeindeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_BaGemeinde_Name] ON [dbo].[BaGemeinde] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BaGemeinde_NamePLZ] ON [dbo].[BaGemeinde] 
(
	[Name] ASC,
	[PLZ] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BaGemeinde_NamePLZNameTIDBezirkNameBezirkNameTIDKanton] ON [dbo].[BaGemeinde] 
(
	[Name] ASC,
	[PLZ] ASC,
	[NameTID] ASC,
	[BezirkName] ASC,
	[BezirkNameTID] ASC,
	[Kanton] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BaGemeinde_PLZ] ON [dbo].[BaGemeinde] 
(
	[PLZ] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaGemeinde Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BaGemeindeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BFSCode der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BFSCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postleitzahl der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'PLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Amtlicher Name der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'NameLang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gemeindename TID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'NameTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art des Gemeindeeintrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeEintragArt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mutationssnummer Aufnahme der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeAufnahmeNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art der Gemeindeaufnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeAufnahmeModus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Gemeindeaufnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeAufnahmeDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mutationsnummer Aufhebung der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeAufhebungNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art der Gemeindeaufhebung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeAufhebungModus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Gemeindeaufhebung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeAufhebungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aenderungsdatum der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeAenderungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Historisierungsnummer der Gemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'GemeindeHistorisierungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BezirkCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name des Bezirks' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Amtlicher Name des Bezirks' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkNameLang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezirksname TID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkNameTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art des Bezirkseinrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkEintragArt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mutationsnummer Aufnahme des Bezirks' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkAufnahmeNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art der Bezirksaufnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkAufnahmeModus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Bezirksaufnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkAufnahmeDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mutationsnummer Aufhebung des Bezirks' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkAufhebungNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art der Bezirksaufhebung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkAufhebungModus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Bezirksaufhebung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkAufhebungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aenderungsdatum des Bezirks' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BezirkAenderungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True wenn das BFS die Daten bei einer aktualisierung neu geliefert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGemeinde', @level2type=N'COLUMN',@level2name=N'BFSDelivered'
GO

ALTER TABLE [dbo].[BaGemeinde] ADD  CONSTRAINT [DF_BaGemeinde_BFSDelivered]  DEFAULT ((0)) FOR [BFSDelivered]
GO