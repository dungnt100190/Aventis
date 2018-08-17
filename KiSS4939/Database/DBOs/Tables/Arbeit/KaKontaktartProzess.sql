CREATE TABLE [dbo].[KaKontaktartProzess](
	[KaKontaktartProzessID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[KaKontaktartProzessCode] [int] NOT NULL,
	[KaKontaktartProzessStatusCode] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaKontaktartProzessTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaKontaktartProzess] PRIMARY KEY CLUSTERED 
(
	[KaKontaktartProzessID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaKontaktartProzess_FaLeistungID]    Script Date: 03/15/2016 13:04:39 ******/
CREATE NONCLUSTERED INDEX [IX_KaKontaktartProzess_FaLeistungID] ON [dbo].[KaKontaktartProzess] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaKontaktartProzess Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaKontaktartProzess', @level2type=N'COLUMN',@level2name=N'KaKontaktartProzessID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaKontaktartProzess_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaKontaktartProzess', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Eintrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaKontaktartProzess', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaKontaktartProzess' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaKontaktartProzess', @level2type=N'COLUMN',@level2name=N'KaKontaktartProzessCode'
GO

ALTER TABLE [dbo].[KaKontaktartProzess]  WITH CHECK ADD  CONSTRAINT [FK_KaKontaktartProzess_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaKontaktartProzess] CHECK CONSTRAINT [FK_KaKontaktartProzess_FaLeistung]
GO

ALTER TABLE [dbo].[KaKontaktartProzess] ADD  CONSTRAINT [DF_KaKontaktartProzess_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaKontaktartProzess] ADD  CONSTRAINT [DF_KaKontaktartProzess_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaKontaktartProzess] ADD  CONSTRAINT [DF_KaKontaktartProzess_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


