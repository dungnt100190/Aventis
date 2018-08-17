CREATE TABLE [dbo].[KaQJPZZielvereinbarung](
	[KaQJPZZielvereinbarungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[ZielDatum] [datetime] NULL,
	[VereinbartesZiel] [varchar](max) NULL,
	[ErreichenBis] [varchar](max) NULL,
	[KriterienPruefen] [varchar](max) NULL,
	[BeurteilungID] [int] NULL,
	[DatumBeurteilung] [datetime] NULL,
	[ZielvereinbarungDokID] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQJPZZielvereinbarungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJPZZielvereinbarung] PRIMARY KEY CLUSTERED 
(
	[KaQJPZZielvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQJPZZielvereinbarung_FaLeistungID] ON [dbo].[KaQJPZZielvereinbarung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQJPZZielvereinbarung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZZielvereinbarung', @level2type=N'COLUMN',@level2name=N'KaQJPZZielvereinbarungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQJPZZielvereinbarung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZZielvereinbarung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQJPZZielvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_KaQJPZZielvereinbarung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQJPZZielvereinbarung] CHECK CONSTRAINT [FK_KaQJPZZielvereinbarung_FaLeistung]
GO

ALTER TABLE [dbo].[KaQJPZZielvereinbarung] ADD  CONSTRAINT [DF_KaQJPZZielvereinbarung_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO