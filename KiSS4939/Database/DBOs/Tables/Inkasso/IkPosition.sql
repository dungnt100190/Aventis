CREATE TABLE [dbo].[IkPosition](
	[IkPositionID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[IkRechtstitelID] [int] NULL,
	[Einmalig] [bit] NOT NULL,
	[Datum] [datetime] NULL,
	[Monat] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[TotalAliment] [money] NULL,
	[TotalAlimentSoll] [money] NULL,
	[BetragALBV] [money] NULL,
	[BetragALBVSoll] [money] NULL,
	[BetragKiZulage] [money] NULL,
	[BetragKiZulageSoll] [money] NULL,
	[BetragALBVverrechnung] [money] NULL,
	[BetragEinmalig] [money] NULL,
	[BetragAuszahlung] [money] NULL,
	[IkForderungCode] [int] NULL,
	[IndexStandBeiBerechnung] [money] NULL,
	[IndexStandDatum] [datetime] NULL,
	[ErledigterMonat] [bit] NOT NULL,
	[Unterstuetzungsfall] [bit] NOT NULL,
	[ALBVBerechtigt] [bit] NOT NULL,
	[BetragIstNegativ] [bit] NOT NULL,
	[Bemerkung] [varchar](500) NULL,
	[IkPositionTS] [timestamp] NOT NULL,
	[_tmp_AiForderungID_Einmalig] [int] NULL,
	[_tmp_AiForderungID] [int] NULL,
 CONSTRAINT [PK_IkPosition] PRIMARY KEY CLUSTERED 
(
	[IkPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkPosition_BaPersonID] ON [dbo].[IkPosition] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_IkPosition_BaPersonID_IkPositionID_Datum_TotalAliment_ALBVBerechtigt] ON [dbo].[IkPosition] 
(
	[BaPersonID] ASC,
	[IkPositionID] ASC,
	[Datum] ASC,
	[TotalAliment] ASC,
	[ALBVBerechtigt] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_IkPosition_FaLeistungID] ON [dbo].[IkPosition] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_IkPosition_IkRechtstitelID] ON [dbo].[IkPosition] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für IkPosition Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkPosition', @level2type=N'COLUMN',@level2name=N'IkPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkPosition_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkPosition', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkPosition_IkRechtstitel) => IkRechtstitel.IkRechtstitelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkPosition', @level2type=N'COLUMN',@level2name=N'IkRechtstitelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkPosition_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkPosition', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

ALTER TABLE [dbo].[IkPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkPosition_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkPosition] CHECK CONSTRAINT [FK_IkPosition_BaPerson]
GO

ALTER TABLE [dbo].[IkPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkPosition_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[IkPosition] CHECK CONSTRAINT [FK_IkPosition_FaLeistung]
GO

ALTER TABLE [dbo].[IkPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkPosition_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO

ALTER TABLE [dbo].[IkPosition] CHECK CONSTRAINT [FK_IkPosition_IkRechtstitel]
GO

ALTER TABLE [dbo].[IkPosition] ADD  CONSTRAINT [DF_IkPosition_Einmalig]  DEFAULT (0) FOR [Einmalig]
GO

ALTER TABLE [dbo].[IkPosition] ADD  CONSTRAINT [DF_IkPosition_ErledigterMonat]  DEFAULT (0) FOR [ErledigterMonat]
GO

ALTER TABLE [dbo].[IkPosition] ADD  CONSTRAINT [DF_IkPosition_Unterstuetzungsfall]  DEFAULT (0) FOR [Unterstuetzungsfall]
GO

ALTER TABLE [dbo].[IkPosition] ADD  CONSTRAINT [DF_IkPosition_ALBVBerechtigt]  DEFAULT (0) FOR [ALBVBerechtigt]
GO

ALTER TABLE [dbo].[IkPosition] ADD  CONSTRAINT [DF_IkPosition_BetragIstNegativ]  DEFAULT (0) FOR [BetragIstNegativ]
GO