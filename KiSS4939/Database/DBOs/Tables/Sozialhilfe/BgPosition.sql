CREATE TABLE [dbo].[BgPosition](
	[BgPositionID] [int] IDENTITY(1,1) NOT NULL,
	[BgPositionID_Parent] [int] NULL,
	[BgPositionID_CopyOf] [int] NULL,
	[BgBudgetID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[BgPositionsartID] [int] NULL,
	[BgSpezkontoID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[DebitorBaPersonID] [int] NULL,
	[ErstelltUserID] [int] NULL,
	[MutiertUserID] [int] NULL,
	[BgPositionID_AutoForderung] [int] NULL,
	[BgKategorieCode] [int] NOT NULL,
	[ShBelegID] [int] NULL,
	[Betrag] [money] NOT NULL,
	[Reduktion] [money] NOT NULL,
	[Abzug] [money] NOT NULL,
	[BetragEff] [money] NULL,
	[MaxBeitragSD] [money] NOT NULL,
	[Buchungstext] [varchar](100) NULL,
	[VerwaltungSD] [bit] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[OldID] [int] NULL,
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL,
	[FaelligAm] [datetime] NULL,
	[RechnungDatum] [datetime] NULL,
	[BgBewilligungStatusCode] [int] NOT NULL,
	[Value1] [sql_variant] NULL,
	[Value2] [sql_variant] NULL,
	[Value3] [sql_variant] NULL,
	[BetragAnfrage] [money] NULL,
	[BgAuszahlungID] [int] NULL,
	[DatumEff] [datetime] NULL,
	[BemerkungSaldierung] [varchar](max) NULL,
	[Saldiert] [bit] NOT NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertDatum] [datetime] NULL,
	[BgPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgPosition] PRIMARY KEY NONCLUSTERED 
(
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [IX_BgPosition] UNIQUE CLUSTERED 
(
	[BgBudgetID] ASC,
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BgPosition_BaInstitutionID]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BaInstitutionID] ON [dbo].[BgPosition] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO


/****** Object:  Index [IX_BgPosition_BaPersonID]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BaPersonID] ON [dbo].[BgPosition] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO


/****** Object:  Index [IX_BgPosition_BgBudgetID]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BgBudgetID] ON [dbo].[BgPosition] 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO


/****** Object:  Index [IX_BgPosition_BgPositionID_AutoForderung]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_AutoForderung] ON [dbo].[BgPosition] 
(
	[BgPositionID_AutoForderung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_BgPosition_BgPositionID_BgPositionID_Parent_BgBewilligungStatusCode]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_BgPositionID_Parent_BgBewilligungStatusCode] ON [dbo].[BgPosition] 
(
	[BgPositionID] ASC,
	[BgPositionID_Parent] ASC,
	[BgBewilligungStatusCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BgPosition_BgPositionID_CopyOf]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_CopyOf] ON [dbo].[BgPosition] 
(
	[BgPositionID_CopyOf] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO


/****** Object:  Index [IX_BgPosition_BgPositionID_Parent]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionID_Parent] ON [dbo].[BgPosition] 
(
	[BgPositionID_Parent] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BgPosition_BgPositionTS]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BgPositionTS] ON [dbo].[BgPosition] 
(
	[BgPositionTS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BgPosition_BgSpezkontoID]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_BgSpezkontoID] ON [dbo].[BgPosition] 
(
	[BgSpezkontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO


/****** Object:  Index [IX_BgPosition_ErstelltUserID]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_ErstelltUserID] ON [dbo].[BgPosition] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO


/****** Object:  Index [IX_BgPosition_MutiertUserID]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_MutiertUserID] ON [dbo].[BgPosition] 
(
	[MutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO


/****** Object:  Index [IX_BgPosition_ShBelegID]    Script Date: 02/09/2011 08:33:29 ******/
CREATE NONCLUSTERED INDEX [IX_BgPosition_ShBelegID] ON [dbo].[BgPosition] 
(
	[ShBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgPosition Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BgPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPosition_BgPosition) => BgPosition.BgPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BgPositionID_Parent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPosition_BgBudget) => BgBudget.BgBudgetID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BgBudgetID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPosition_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPosition_BgSpezkonto) => BgSpezkonto.BgSpezkontoID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BgSpezkontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPosition_BaInstitution) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPosition_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'ErstelltUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPosition_XUser1) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'MutiertUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Benutzer kann über die Saldierung eine Bemerkung hinzufügen. Siehe CtlQueryWhZahlungseingaenge.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'BemerkungSaldierung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Benutzer kann manuell eine BgPosition eines Monatsbudgets als saldiert markieren.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition', @level2type=N'COLUMN',@level2name=N'Saldiert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Daten über eine Position in einem Budget' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPosition'
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_AutoForderung] FOREIGN KEY([BgPositionID_AutoForderung])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_AutoForderung]
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

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BaPerson_DebitorBaPersonID] FOREIGN KEY([DebitorBaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BaPerson_DebitorBaPersonID]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgBudget]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgPosition] FOREIGN KEY([BgPositionID_Parent])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgPosition]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_BgPosition_CopyOf] FOREIGN KEY([BgPositionID_CopyOf])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_BgPosition_CopyOf]
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

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_XUser] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_XUser]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [FK_BgPosition_XUser1] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [FK_BgPosition_XUser1]
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

ALTER TABLE [dbo].[BgPosition] ADD  CONSTRAINT [DF_BgPosition_Saldiert]  DEFAULT ((0)) FOR [Saldiert]
GO

ALTER TABLE [dbo].[BgPosition]  WITH CHECK ADD  CONSTRAINT [CK_BgPosition_VerwPeriodeVon_VerwPeriodeBis] CHECK  (([VerwPeriodeVon] <= [VerwPeriodeBis]))
GO

ALTER TABLE [dbo].[BgPosition] CHECK CONSTRAINT [CK_BgPosition_VerwPeriodeVon_VerwPeriodeBis]
GO


