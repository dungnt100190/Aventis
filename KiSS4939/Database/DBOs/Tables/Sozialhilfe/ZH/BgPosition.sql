CREATE TABLE [dbo].[BgPosition](
	[BgPositionID] [int] IDENTITY(1,1) NOT NULL,
	[BgBudgetID] [int] NOT NULL,
	[BgPositionID_CopyOf] [int] NULL,
	[BgPositionID_Parent] [int] NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[DebitorBaPersonID] [int] NULL,
	[BgPositionsartID] [int] NULL,
	[BgSpezkontoID] [int] NULL,
	[BgPositionID_AutoForderung] [int] NULL,
	[ErstelltUserID] [int] NULL,
	[MutiertUserID] [int] NULL,
	[BgKategorieCode] [int] NOT NULL,
	[DatumBis] [datetime] NULL,
	[DatumVon] [datetime] NULL,
	[Buchungstext] [varchar](100) NULL,
	[Betrag] [money] NOT NULL,
	[Reduktion] [money] NOT NULL,
	[Abzug] [money] NOT NULL,
	[MaxBeitragSD] [money] NOT NULL,
	[Bemerkung] [text] NULL,
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL,
	[FaelligAm] [datetime] NULL,
	[RechnungDatum] [datetime] NULL,
	[BetragAnfrage] [money] NULL,
	[VerwaltungSD] [bit] NOT NULL,
	[BgBewilligungStatusCode] [int] NULL,
	[BewilligtVon] [datetime] NULL,
	[BewilligtBis] [datetime] NULL,
	[BewilligtBetrag] [money] NULL,
	[FPPosition] [bit] NULL,
	[Value1] [sql_variant] NULL,
	[Value2] [sql_variant] NULL,
	[Value3] [sql_variant] NULL,
	[BetragGBLAufAusgabekonto] [money] NULL,
	[BgPositionTS] [timestamp] NOT NULL,
	[Hidden] [bit] NULL,
	[Rechnungsnummer] [varchar](100) NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertDatum] [datetime] NULL,
 CONSTRAINT [PK_BgPosition] PRIMARY KEY NONCLUSTERED 
(
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1],
 CONSTRAINT [IX_BgPosition] UNIQUE CLUSTERED 
(
	[BgBudgetID] ASC,
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [DATEN1]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BaInstitutionID] ON [dbo].[BgPosition] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN3]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BaPersonID] ON [dbo].[BgPosition] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN3]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgBudgetID] ON [dbo].[BgPosition] 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN3]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgKategorieCode] ON [dbo].[BgPosition] 
(
	[BgKategorieCode] ASC,
	[ErstelltDatum] DESC
)
INCLUDE ( [Betrag],
[VerwaltungSD],
[BgBudgetID],
[BgPositionsartID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_AutoForderung] ON [dbo].[BgPosition] 
(
	[BgPositionID_AutoForderung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_BgPositionID_Parent_BgBewilligungStatusCode] ON [dbo].[BgPosition] 
(
	[BgPositionID] ASC,
	[BgPositionID_Parent] ASC,
	[BgBewilligungStatusCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_CopyOf] ON [dbo].[BgPosition] 
(
	[BgPositionID_CopyOf] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_Parent] ON [dbo].[BgPosition] 
(
	[BgPositionID_Parent] ASC
)
INCLUDE ( [Betrag]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionsartID] ON [dbo].[BgPosition] 
(
	[BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionTS] ON [dbo].[BgPosition] 
(
	[BgPositionTS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_BgSpezkontoID] ON [dbo].[BgPosition] 
(
	[BgSpezkontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN3]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_ErstelltUser_Datum] ON [dbo].[BgPosition] 
(
	[ErstelltUserID] ASC,
	[ErstelltDatum] ASC
)
INCLUDE ( [BgBudgetID],
[BgPositionID_Parent],
[BgBewilligungStatusCode],
[BgKategorieCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_MutiertUserId_und_Datum] ON [dbo].[BgPosition] 
(
	[MutiertUserID] ASC,
	[MutiertDatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_BgPosition_Rechnungsnummer] ON [dbo].[BgPosition] 
(
	[Rechnungsnummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Automatisch generierte Krankenkassen-Forderung (LA 751/752): FK zur auslösenden Arztrechnung (LA 150/151)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BgPositionID_AutoForderung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wenn True, dann wird diese Position nicht dargestellt. Dies wird verwendet, um Positionen aus Datenmigrationsgründen zu verstecken, die nicht löschbar sind, da sie zu viele bestehende Abhängigkeiten haben.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'Hidden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rechnungsnummer, relevant für ZL und EZ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'Rechnungsnummer'
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BaInstitution]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BaPerson]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BaPerson_Debitor] FOREIGN KEY([DebitorBaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BaPerson_Debitor]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgBudget]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgPosition_AutoForderung] FOREIGN KEY([BgPositionID_AutoForderung])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgPosition_AutoForderung]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgPosition_CopyOf] FOREIGN KEY([BgPositionID_CopyOf])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgPosition_CopyOf]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgPosition_Parent] FOREIGN KEY([BgPositionID_Parent])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgPosition_Parent]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgPositionsart] FOREIGN KEY([BgPositionsartID])
REFERENCES [dbo].[BgPositionsart] ([BgPositionsartID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgPositionsart]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgSpezkonto] FOREIGN KEY([BgSpezkontoID])
REFERENCES [dbo].[BgSpezkonto] ([BgSpezkontoID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgSpezkonto]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_XUser_Erstellt] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_XUser_Erstellt]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_XUser_Mutiert] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_XUser_Mutiert]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [CK_BgPosition_VerwPeriodeVon_VerwPeriodeBis] CHECK  (([VerwPeriodeVon] <= [VerwPeriodeBis]))
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [CK_BgPosition_VerwPeriodeVon_VerwPeriodeBis]
GO

ALTER TABLE [dbo].[BgPosition] ADD  CONSTRAINT [DF_BgPosition_Betrag]  DEFAULT ((0)) FOR [Betrag]
GO

ALTER TABLE [dbo].[BgPosition] ADD  CONSTRAINT [DF_BgPosition_Reduktion]  DEFAULT ((0)) FOR [Reduktion]
GO

ALTER TABLE [dbo].[BgPosition] ADD  CONSTRAINT [DF_BgPosition_Abzug]  DEFAULT ((0)) FOR [Abzug]
GO

ALTER TABLE [dbo].[BgPosition] ADD  CONSTRAINT [DF_BgPosition_MaxBeitragSD]  DEFAULT ((999999999)) FOR [MaxBeitragSD]
GO

ALTER TABLE [dbo].[BgPosition] ADD  CONSTRAINT [DF_BgPosition_VerwaltungSD]  DEFAULT ((0)) FOR [VerwaltungSD]
GO

ALTER TABLE [dbo].[BgPosition] ADD  CONSTRAINT [DF_BgPosition_BgBewilligungStatusCode]  DEFAULT ((1)) FOR [BgBewilligungStatusCode]
GO