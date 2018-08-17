CREATE TABLE [dbo].[KaQEEPQZielvereinbVerl](
	[KaQEEPQZielvereinbVerlID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[FeinzielDat] [datetime] NULL,
	[Feinziel] [varchar](max) NULL,
	[ErreichenBis] [varchar](100) NULL,
	[MessungZielerreichung] [varchar](max) NULL,
	[Ergebnis] [varchar](max) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQEEPQZielvereinbVerlTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQEEPQZielvereinbVerl] PRIMARY KEY CLUSTERED 
(
	[KaQEEPQZielvereinbVerlID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQEEPQZielvereinbVerl_FaLeistungID] ON [dbo].[KaQEEPQZielvereinbVerl] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQEEPQZielvereinbVerl Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQZielvereinbVerl', @level2type=N'COLUMN',@level2name=N'KaQEEPQZielvereinbVerlID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQEEPQZielvereinbVerl_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQZielvereinbVerl', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQEEPQZielvereinbVerl]  WITH CHECK ADD  CONSTRAINT [FK_KaQEEPQZielvereinbVerl_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQEEPQZielvereinbVerl] CHECK CONSTRAINT [FK_KaQEEPQZielvereinbVerl_FaLeistung]
GO

ALTER TABLE [dbo].[KaQEEPQZielvereinbVerl] ADD  CONSTRAINT [DF_KaQEEPQZielvereinbVerl_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO