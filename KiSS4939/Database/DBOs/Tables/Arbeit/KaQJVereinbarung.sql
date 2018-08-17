CREATE TABLE [dbo].[KaQJVereinbarung](
	[KaQJVereinbarungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Vereinbarung] [bit] NULL,
	[ErstelltAm] [datetime] NULL,
	[DauerCode] [int] NULL,
	[Erfuellt] [bit] NULL,
	[GrundZiel] [varchar](max) NULL,
	[Abmachungen] [varchar](max) NULL,
	[VereinbarungDokID] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQJVereinbarungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJVereinbarung] PRIMARY KEY CLUSTERED 
(
	[KaQJVereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQJVereinbarung_FaLeistungID] ON [dbo].[KaQJVereinbarung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQJVereinbarung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJVereinbarung', @level2type=N'COLUMN',@level2name=N'KaQJVereinbarungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQJVereinbarung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJVereinbarung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQJVereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_KaQJVereinbarung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQJVereinbarung] CHECK CONSTRAINT [FK_KaQJVereinbarung_FaLeistung]
GO

ALTER TABLE [dbo].[KaQJVereinbarung] ADD  CONSTRAINT [DF_KaQJVereinbarung_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO