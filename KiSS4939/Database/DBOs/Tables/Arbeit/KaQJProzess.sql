CREATE TABLE [dbo].[KaQJProzess](
	[KaQJProzessID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[KompetenzDokID] [int] NULL,
	[ZwischenzeugnisDokID] [int] NULL,
	[LebenslaufDokID] [int] NULL,
	[StandortbestDokID] [int] NULL,
	[ProgrammBildungDokID] [int] NULL,
	[BeilageSEMODokID] [int] NULL,
	[ProgEnde] [datetime] NULL,
	[BeraterID] [int] NULL,
	[FallfuehrungID] [int] NULL,
	[AndereStellen] [varchar](max) NULL,
	[ProgEndeGrund] [int] NULL,
	[ProgEndeCode] [int] NULL,
	[AbbruchCode] [int] NULL,
	[TermineStaoDokID] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQJProzessTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJProzess] PRIMARY KEY CLUSTERED 
(
	[KaQJProzessID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQJProzess_FaLeistungID] ON [dbo].[KaQJProzess] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQJProzess Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJProzess', @level2type=N'COLUMN',@level2name=N'KaQJProzessID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQJProzess_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJProzess', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQJProzess]  WITH CHECK ADD  CONSTRAINT [FK_KaQJProzess_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQJProzess] CHECK CONSTRAINT [FK_KaQJProzess_FaLeistung]
GO

ALTER TABLE [dbo].[KaQJProzess] ADD  CONSTRAINT [DF_KaQJProzess_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO