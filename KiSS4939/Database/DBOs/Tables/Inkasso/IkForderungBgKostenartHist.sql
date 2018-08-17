CREATE TABLE [dbo].[IkForderungBgKostenartHist](
	[IkForderungBgKostenartHistID] [int] IDENTITY(1,1) NOT NULL,
	[BgKostenartID] [int] NOT NULL,
	[IkForderungPeriodischCode] [int] NULL,
	[IstAlbvBerechtigt] [bit] NOT NULL,
	[IstAlbvUeberMax] [bit] NOT NULL,
	[IstUnterstuetzungsfall] [bit] NOT NULL,
	[IkForderungEinmaligCode] [int] NULL,
	[IkForderungsartFilterCode] [int] NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[IkForderungBgKostenartHistTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkForderungBgKostenartHist] PRIMARY KEY CLUSTERED 
(
	[IkForderungBgKostenartHistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkForderungBgKostenartHist_BgKostenartID] ON [dbo].[IkForderungBgKostenartHist] 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IkForderungBgKostenartHistID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Forderungskostenart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'BgKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code in der LOV IkForedungPeriodisch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IkForderungPeriodischCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum wissen ob die periodische Forderung ALBV-Berechtigt ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IstAlbvBerechtigt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum wissen ob die periodische Forderung den ALBV max. Beitrag übersteigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IstAlbvUeberMax'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum wissen ob die periodische Forderung ein Unterstützungsfall ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IstUnterstuetzungsfall'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code in der LOV IkForedungEinmalig' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IkForderungEinmaligCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der im Kontoauszug als Filter verwendet wird. Entspricht jetzt an der LOV IkForderungEinmalig' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IkForderungsartFilterCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gültig ab' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gültig bis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist', @level2type=N'COLUMN',@level2name=N'IkForderungBgKostenartHistTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um die BgKostenartID der Forderung fachlich historisiert zu haben' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderungBgKostenartHist'
GO

ALTER TABLE [dbo].[IkForderungBgKostenartHist]  WITH CHECK ADD  CONSTRAINT [FK_IkForderungBgKostenartHist_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[IkForderungBgKostenartHist] CHECK CONSTRAINT [FK_IkForderungBgKostenartHist_BgKostenart]
GO

ALTER TABLE [dbo].[IkForderungBgKostenartHist] ADD  CONSTRAINT [DF_IkForderungBgKostenartHist_IstAlbvBerechtigt]  DEFAULT ((0)) FOR [IstAlbvBerechtigt]
GO

ALTER TABLE [dbo].[IkForderungBgKostenartHist] ADD  CONSTRAINT [DF_IkForderungBgKostenartHist_IstAlbvUeberMax]  DEFAULT ((0)) FOR [IstAlbvUeberMax]
GO

ALTER TABLE [dbo].[IkForderungBgKostenartHist] ADD  CONSTRAINT [DF_IkForderungBgKostenartHist_IstUnterstuetzungsfall]  DEFAULT ((0)) FOR [IstUnterstuetzungsfall]
GO

ALTER TABLE [dbo].[IkForderungBgKostenartHist] ADD  CONSTRAINT [DF_IkForderungBgKostenartHist_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[IkForderungBgKostenartHist] ADD  CONSTRAINT [DF_IkForderungBgKostenartHist_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


