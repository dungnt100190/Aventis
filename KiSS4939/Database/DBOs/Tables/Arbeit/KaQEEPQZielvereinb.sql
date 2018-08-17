CREATE TABLE [dbo].[KaQEEPQZielvereinb](
	[KaQEEPQZielvereinbID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[FeinzielDat] [datetime] NULL,
	[Feinziel] [varchar](max) NULL,
	[ErreichenBis] [varchar](100) NULL,
	[MessungZielerreichung] [varchar](max) NULL,
	[Ergebnis] [varchar](max) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQEEPQZielvereinbTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQEEPQZielvereinb] PRIMARY KEY CLUSTERED 
(
	[KaQEEPQZielvereinbID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQEEPQZielvereinb_FaLeistungID] ON [dbo].[KaQEEPQZielvereinb] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQEEPQZielvereinb Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQZielvereinb', @level2type=N'COLUMN',@level2name=N'KaQEEPQZielvereinbID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQEEPQZielvereinb_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQZielvereinb', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQEEPQZielvereinb]  WITH CHECK ADD  CONSTRAINT [FK_KaQEEPQZielvereinb_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQEEPQZielvereinb] CHECK CONSTRAINT [FK_KaQEEPQZielvereinb_FaLeistung]
GO

ALTER TABLE [dbo].[KaQEEPQZielvereinb] ADD  CONSTRAINT [DF_KaQEEPQZielvereinb_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO