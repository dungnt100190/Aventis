CREATE TABLE [dbo].[BgFinanzplan](
	[BgFinanzplanID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BgBewilligungStatusCode] [int] NOT NULL,
	[BgGrundEroeffnenCode] [int] NULL,
	[BgGrundAbschlussCode] [int] NULL,
	[WhHilfeTypCode] [int] NULL,
	[GeplantVon] [datetime] NOT NULL,
	[GeplantBis] [datetime] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[BgFinanzplanTS] [timestamp] NOT NULL,
	[WhGrundbedarfTypCode] [int] NULL,
 CONSTRAINT [PK_BgFinanzplan] PRIMARY KEY CLUSTERED 
(
	[BgFinanzplanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_BgFinanzplanTS] ON [dbo].[BgFinanzplan] 
(
	[BgFinanzplanTS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_FaLeistungID] ON [dbo].[BgFinanzplan] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgFinanzplan Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan', @level2type=N'COLUMN',@level2name=N'BgFinanzplanID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgFinanzplan_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO

ALTER TABLE [dbo].[BgFinanzplan]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[BgFinanzplan] CHECK CONSTRAINT [FK_BgFinanzplan_FaLeistung]
GO

ALTER TABLE [dbo].[BgFinanzplan] ADD  CONSTRAINT [DF_BgFinanzplan_BgBewilligungStatusCode]  DEFAULT ((1)) FOR [BgBewilligungStatusCode]
GO

ALTER TABLE [dbo].[BgFinanzplan] ADD  CONSTRAINT [DF_BgFinanzplan_ShTypCode]  DEFAULT ((1)) FOR [WhHilfeTypCode]
GO