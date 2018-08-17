CREATE TABLE [dbo].[KbBuchungKostenart](
	[KbBuchungKostenartID] [int] IDENTITY(1,1) NOT NULL,
	[KbKostenstelleID] [int] NOT NULL,
	[NrmKontoCode] [int] NULL,
	[Betrag] [money] NOT NULL,
	[KbBuchungKostenartTS] [timestamp] NOT NULL,
	[KbBuchungID] [int] NOT NULL,
	[KontoNr] [varchar](10) NULL,
	[BgKostenartID] [int] NULL,
	[Buchungstext] [varchar](200) NULL,
	[BgPositionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[PositionImBeleg] [int] NULL,
	[KbForderungArtCode] [int] NULL,
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL,
	[BgSplittingArtCode] [int] NULL,
	[Weiterverrechenbar] [bit] NOT NULL,
	[Quoting] [bit] NOT NULL,
	[GvAuszahlungPositionID] [int] NULL,
 CONSTRAINT [PK_KbBuchungKostenart] PRIMARY KEY CLUSTERED 
(
	[KbBuchungKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbBuchungKostenart_BaPersonID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BaPersonID] ON [dbo].[KbBuchungKostenart] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_Betrag_KbBuchungID_KontoNr]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_Betrag_KbBuchungID_KontoNr] ON [dbo].[KbBuchungKostenart] 
(
	[Betrag] ASC,
	[KbBuchungID] ASC,
	[KontoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_KbBuchungKostenart_BgKostenartID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BgKostenartID] ON [dbo].[KbBuchungKostenart] 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_BgKostenartID_KbBuchungKostenartID_KbBuchungID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BgKostenartID_KbBuchungKostenartID_KbBuchungID] ON [dbo].[KbBuchungKostenart] 
(
	[BgKostenartID] ASC,
	[KbBuchungKostenartID] ASC,
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_BgPositionID_KbBuchungID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BgPositionID_KbBuchungID] ON [dbo].[KbBuchungKostenart] 
(
	[BgPositionID] ASC,
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_GvAuszahlungPositionID_KbBuchungID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_GvAuszahlungPositionID_KbBuchungID] ON [dbo].[KbBuchungKostenart] 
(
	[GvAuszahlungPositionID] ASC,
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_KbBuchungID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_KbBuchungID] ON [dbo].[KbBuchungKostenart] 
(
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_KbBuchungID_KbBuchungKostenartID_KbKostenstelleID_Betrag_BgKostenartID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_KbBuchungID_KbBuchungKostenartID_KbKostenstelleID_Betrag_BgKostenartID] ON [dbo].[KbBuchungKostenart] 
(
	[KbBuchungID] ASC,
	[KbBuchungKostenartID] ASC,
	[KbKostenstelleID] ASC,
	[Betrag] ASC,
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_KbBuchungID_KbKostenstelleID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_KbBuchungID_KbKostenstelleID] ON [dbo].[KbBuchungKostenart] 
(
	[KbBuchungID] ASC,
	[KbKostenstelleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungKostenart_KbKostenstelleID]    Script Date: 11/15/2013 10:53:57 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_KbKostenstelleID] ON [dbo].[KbBuchungKostenart] 
(
	[KbKostenstelleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbBuchungKostenart Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungKostenart', @level2type=N'COLUMN',@level2name=N'KbBuchungKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbKostenstelle_KbKostenstelle) => KbKostenstelle.KbKostenstelleID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungKostenart', @level2type=N'COLUMN',@level2name=N'KbKostenstelleID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchungKostenart_KbBuchung) => KbBuchung.KbBuchungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungKostenart', @level2type=N'COLUMN',@level2name=N'KbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchungKostenart_BgPosition) => BgPosition.BgPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungKostenart', @level2type=N'COLUMN',@level2name=N'BgPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchungKostenart_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungKostenart', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchungKostenart_GvAuszahlungPositionID) => GvAuszahlungPosition.GvAuszahlungPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungKostenart', @level2type=N'COLUMN',@level2name=N'GvAuszahlungPositionID'
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_BaPerson]
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_BgKostenart]
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_BgPosition]
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_GvAuszahlungPosition] FOREIGN KEY([GvAuszahlungPositionID])
REFERENCES [dbo].[GvAuszahlungPosition] ([GvAuszahlungPositionID])
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_GvAuszahlungPosition]
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_KbBuchung] FOREIGN KEY([KbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_KbBuchung]
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbKostenstelle_KbKostenstelle] FOREIGN KEY([KbKostenstelleID])
REFERENCES [dbo].[KbKostenstelle] ([KbKostenstelleID])
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbKostenstelle_KbKostenstelle]
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH NOCHECK ADD  CONSTRAINT [CK_KbBuchungKostenart_VerwPeriodeVon_VerwPeriodeBis] CHECK  (([VerwPeriodeVon]<=[VerwPeriodeBis]))
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [CK_KbBuchungKostenart_VerwPeriodeVon_VerwPeriodeBis]
GO

ALTER TABLE [dbo].[KbBuchungKostenart] ADD  CONSTRAINT [DF_KbBuchungKostenart_Weiterverrechenbar]  DEFAULT ((0)) FOR [Weiterverrechenbar]
GO

ALTER TABLE [dbo].[KbBuchungKostenart] ADD  CONSTRAINT [DF_KbBuchungKostenart_Quoting]  DEFAULT ((0)) FOR [Quoting]
GO


