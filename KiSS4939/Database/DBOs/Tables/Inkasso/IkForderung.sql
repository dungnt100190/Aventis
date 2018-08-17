CREATE TABLE [dbo].[IkForderung](
	[IkForderungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[IkRechtstitelID] [int] NULL,
	[BaPersonID] [int] NULL,
	[IkForderungPeriodischCode] [int] NOT NULL,
	[DatumAnpassenAb] [datetime] NOT NULL,
	[DatumGueltigBis] [datetime] NULL,
	[Betrag] [money] NULL,
	[IkAnpassungsGrundCode] [int] NULL,
	[IkAnpassungsRegelCode] [int] NULL,
	[IndexStandBeiBerechnung] [money] NULL,
	[IndexStandDatum] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Sollgestellt] [bit] NOT NULL,
	[ALBVBerechtigt] [bit] NOT NULL,
	[Teuerungseinsprache] [bit] NOT NULL,
	[Unterstuetzungsfall] [bit] NOT NULL,
	[TeilALBV] [bit] NOT NULL,
	[TeilALBVBetrag] [money] NULL,
	[IkForderungTS] [timestamp] NOT NULL,
	[_tmp_AiForderungID_Periodisch] [int] NULL,
 CONSTRAINT [PK_IkForderung] PRIMARY KEY CLUSTERED 
(
	[IkForderungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_IkForderung_BaPersonID]    Script Date: 09/09/2015 16:00:28 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderung_BaPersonID] ON [dbo].[IkForderung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_IkForderung_FaLeistungID]    Script Date: 09/09/2015 16:00:28 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderung_FaLeistungID] ON [dbo].[IkForderung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkForderung_IkRechtstitelID]    Script Date: 09/09/2015 16:00:28 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderung_IkRechtstitelID] ON [dbo].[IkForderung] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für IkForderung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung', @level2type=N'COLUMN',@level2name=N'IkForderungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkForderung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkForderung_IkRechtstitel) => IkRechtstitel.IkRechtstitelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung', @level2type=N'COLUMN',@level2name=N'IkRechtstitelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkForderung_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

ALTER TABLE [dbo].[IkForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkForderung] CHECK CONSTRAINT [FK_IkForderung_BaPerson]
GO

ALTER TABLE [dbo].[IkForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[IkForderung] CHECK CONSTRAINT [FK_IkForderung_FaLeistung]
GO

ALTER TABLE [dbo].[IkForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO

ALTER TABLE [dbo].[IkForderung] CHECK CONSTRAINT [FK_IkForderung_IkRechtstitel]
GO

ALTER TABLE [dbo].[IkForderung] ADD  CONSTRAINT [DF_IkForderung_Sollgestellt]  DEFAULT ((0)) FOR [Sollgestellt]
GO

ALTER TABLE [dbo].[IkForderung] ADD  CONSTRAINT [DF_IkForderung_ALBVBerechtigt]  DEFAULT ((0)) FOR [ALBVBerechtigt]
GO

ALTER TABLE [dbo].[IkForderung] ADD  CONSTRAINT [DF_IkForderung_Teuerungseinsprache]  DEFAULT ((0)) FOR [Teuerungseinsprache]
GO

ALTER TABLE [dbo].[IkForderung] ADD  CONSTRAINT [DF_IkForderung_Unterstuetzungsfall]  DEFAULT ((0)) FOR [Unterstuetzungsfall]
GO

ALTER TABLE [dbo].[IkForderung] ADD  CONSTRAINT [DF_IkForderung_TeilALBV]  DEFAULT ((0)) FOR [TeilALBV]
GO

