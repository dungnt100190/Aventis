CREATE TABLE [dbo].[KbBuchung](
	[KbBuchungID] [int] IDENTITY(1,1) NOT NULL,
	[BaZahlungswegID] [int] NULL,
	[KbAuszahlungsArtCode] [int] NULL,
	[FlTypSourceCode] [int] NULL,
	[FlBelegStatusCode] [int] NULL,
	[IdSource] [int] NULL,
	[BelegNr] [int] NULL,
	[BarbelegUserID] [int] NULL,
	[ErstelltDatum] [datetime] NOT NULL,
	[TransferDatum] [datetime] NULL,
	[BelegDatum] [datetime] NULL,
	[ValutaDatum] [datetime] NULL,
	[BarbelegDatum] [datetime] NULL,
	[Text] [varchar](200) NOT NULL,
	[Extern] [varchar](50) NULL,
	[ReferenzNummer] [varchar](30) NULL,
	[AggregateInfo] [varchar](16) NULL,
	[FibuFehlermeldung] [varchar](500) NULL,
	[Remark] [varchar](50) NULL,
	[Old_SourceID] [int] NULL,
	[KbBuchungTS] [timestamp] NOT NULL,
	[KbPeriodeID] [int] NOT NULL,
	[KbBuchungTypCode] [int] NOT NULL,
	[KbBuchungStatusCode] [int] NULL,
	[Betrag] [money] NOT NULL,
	[SollKtoNr] [varchar](10) NULL,
	[HabenKtoNr] [varchar](10) NULL,
	[EinzahlungsscheinCode] [int] NULL,
	[PCKontoNr] [varchar](50) NULL,
	[BankKontoNr] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[BaBankID] [int] NULL,
	[BankBCN] [varchar](6) NULL,
	[BankName] [varchar](70) NULL,
	[BankStrasse] [varchar](50) NULL,
	[BankPLZ] [varchar](10) NULL,
	[BankOrt] [varchar](60) NULL,
	[Zahlungsgrund] [varchar](200) NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[BeguenstigtName] [varchar](100) NULL,
	[BeguenstigtName2] [varchar](200) NULL,
	[BeguenstigtStrasse] [varchar](100) NULL,
	[BeguenstigtHausNr] [varchar](10) NULL,
	[BeguenstigtPostfach] [varchar](40) NULL,
	[BeguenstigtPLZ] [varchar](10) NULL,
	[BeguenstigtOrt] [varchar](100) NULL,
	[BeguenstigtLandCode] [int] NULL,
	[KbZahlungseingangID] [int] NULL,
	[ErstelltUserID] [int] NOT NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[Schuldner_BaInstitutionID] [int] NULL,
	[Schuldner_BaPersonID] [int] NULL,
	[StorniertKbBuchungID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[BgBudgetID] [int] NULL,
	[IkPositionID] [int] NULL,
	[NeubuchungVonKbBuchungID] [int] NULL,
	[KbBelegKreisID] [int] NULL,
	[KbZahlungskontoID] [int] NULL,
	[IkForderungBgKostenartHistID] [int] NULL,
 CONSTRAINT [PK_KbBuchung] PRIMARY KEY CLUSTERED 
(
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbBuchung_BeguenstigtLandCode]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_BeguenstigtLandCode] ON [dbo].[KbBuchung] 
(
	[BeguenstigtLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_BgBudgetID]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_BgBudgetID] ON [dbo].[KbBuchung] 
(
	[BgBudgetID] ASC,
	[KbBuchungStatusCode] ASC,
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_FaLeistungID]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_FaLeistungID] ON [dbo].[KbBuchung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_HabenKtoNr]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_HabenKtoNr] ON [dbo].[KbBuchung] 
(
	[KbPeriodeID] ASC,
	[HabenKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_IkForderungBgKostenartHist]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_IkForderungBgKostenartHist] ON [dbo].[KbBuchung] 
(
	[IkForderungBgKostenartHistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_KbBuchung_IkPositionID]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_IkPositionID] ON [dbo].[KbBuchung] 
(
	[IkPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbAuszahlungsArtCode]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbAuszahlungsArtCode] ON [dbo].[KbBuchung] 
(
	[KbAuszahlungsArtCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbBelegKreisID_BelegNr]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBelegKreisID_BelegNr] ON [dbo].[KbBuchung] 
(
	[KbBelegKreisID] ASC,
	[BelegNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungID_KbAuszahlungsArtCode_KbBuchungStatusCode_BelegDatum_ValutaDatum]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungID_KbAuszahlungsArtCode_KbBuchungStatusCode_BelegDatum_ValutaDatum] ON [dbo].[KbBuchung] 
(
	[KbBuchungID] ASC,
	[KbAuszahlungsArtCode] ASC,
	[KbBuchungStatusCode] ASC,
	[BelegDatum] ASC,
	[ValutaDatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungStatusCode]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungStatusCode] ON [dbo].[KbBuchung] 
(
	[KbBuchungStatusCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungTS]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungTS] ON [dbo].[KbBuchung] 
(
	[KbBuchungTS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungTypCode_KbAuszahlungsArtCode]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungTypCode_KbAuszahlungsArtCode] ON [dbo].[KbBuchung] 
(
	[KbBuchungTypCode] ASC,
	[KbAuszahlungsArtCode] ASC
)
INCLUDE ( [BgBudgetID],
[KbBuchungID],
[KbBuchungStatusCode],
[KbPeriodeID],
[ValutaDatum]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungTypCode_KbBuchungStatusCode_KbAuszahlungsArtCode]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungTypCode_KbBuchungStatusCode_KbAuszahlungsArtCode] ON [dbo].[KbBuchung] 
(
	[KbBuchungTypCode] ASC,
	[KbAuszahlungsArtCode] ASC
)
INCLUDE ( [BgBudgetID],
[KbBuchungID],
[KbBuchungStatusCode],
[KbPeriodeID],
[ValutaDatum]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungTypCode_KbZahlungseingangID]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungTypCode_KbZahlungseingangID] ON [dbo].[KbBuchung] 
(
	[KbBuchungTypCode] ASC,
	[KbZahlungseingangID] ASC
)
INCLUDE ( [KbBuchungID],
[BelegNr],
[KbPeriodeID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbPeriodeID_BelegNr_BelegDatum_Betrag]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbPeriodeID_BelegNr_BelegDatum_Betrag] ON [dbo].[KbBuchung] 
(
	[KbPeriodeID] ASC,
	[BelegNr] ASC,
	[BelegDatum] ASC,
	[Betrag] ASC
)
INCLUDE ( [KbBuchungID],
[SollKtoNr],
[HabenKtoNr],
[KbZahlungseingangID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_KbBuchung_KbPeriodeID_HabenKtoNr_KbBuchungID_BelegNr_BelegDatum_SollKtoNr_Betrag]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbPeriodeID_HabenKtoNr_KbBuchungID_BelegNr_BelegDatum_SollKtoNr_Betrag] ON [dbo].[KbBuchung] 
(
	[KbPeriodeID] ASC,
	[HabenKtoNr] ASC,
	[KbBuchungID] ASC,
	[BelegNr] ASC,
	[BelegDatum] ASC,
	[SollKtoNr] ASC,
	[Betrag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbZahlungseingangID]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbZahlungseingangID] ON [dbo].[KbBuchung] 
(
	[KbZahlungseingangID] ASC,
	[Betrag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_KbZahlungskontoID]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbZahlungskontoID] ON [dbo].[KbBuchung] 
(
	[KbZahlungskontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_NeuBuchung]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_NeuBuchung] ON [dbo].[KbBuchung] 
(
	[NeubuchungVonKbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_Sicherung]    Script Date: 11/15/2013 10:32:20 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_KbBuchung_Sicherung] ON [dbo].[KbBuchung] 
(
	[KbPeriodeID] ASC,
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_SollKto]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_SollKto] ON [dbo].[KbBuchung] 
(
	[KbPeriodeID] ASC,
	[SollKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_StornierKbBuchung]    Script Date: 11/15/2013 10:32:20 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_StornierKbBuchung] ON [dbo].[KbBuchung] 
(
	[StorniertKbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchung_BaZahlungsweg) => BaZahlungsweg.BaZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchung_UserID_Kasse) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'BarbelegUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchung_KbPeriode) => KbPeriode.KbPeriodeID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'KbPeriodeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchung_KbZahlungseingang) => KbZahlungseingang.KbZahlungseingangID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'KbZahlungseingangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchung_KbBuchungStorniert) => KbBuchung.KbBuchungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'StorniertKbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchung_IkPosition) => IkPosition.IkPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'IkPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbBuchung_KbBuchungNeuBuchung) => KbBuchung.KbBuchungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'NeubuchungVonKbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf KbZahlungskonto. Ist für die Gesuchverwaltung verwendet um einen Zahlungskonto auf der Buchung zu definieren' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'KbZahlungskontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf IkForderungBgKostenartHist. Ist fürs Inkasso verwendet im Belegimport und Kontoauszug' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'IkForderungBgKostenartHistID'
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BaBank] FOREIGN KEY([BaBankID])
REFERENCES [dbo].[BaBank] ([BaBankID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BaBank]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BaInstitution] FOREIGN KEY([Schuldner_BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BaInstitution]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BaLand] FOREIGN KEY([BeguenstigtLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BaLand]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BaPerson] FOREIGN KEY([Schuldner_BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BaPerson]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BaZahlungsweg]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BgBudget]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_FaLeistung]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_IkForderungBgKostenartHist] FOREIGN KEY([IkForderungBgKostenartHistID])
REFERENCES [dbo].[IkForderungBgKostenartHist] ([IkForderungBgKostenartHistID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_IkForderungBgKostenartHist]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_IkPosition] FOREIGN KEY([IkPositionID])
REFERENCES [dbo].[IkPosition] ([IkPositionID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_IkPosition]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_KbBelegKreis] FOREIGN KEY([KbBelegKreisID])
REFERENCES [dbo].[KbBelegKreis] ([KbBelegKreisID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_KbBelegKreis]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_KbBuchungNeuBuchung] FOREIGN KEY([NeubuchungVonKbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_KbBuchungNeuBuchung]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_KbBuchungStorniert] FOREIGN KEY([StorniertKbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_KbBuchungStorniert]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_KbPeriode] FOREIGN KEY([KbPeriodeID])
REFERENCES [dbo].[KbPeriode] ([KbPeriodeID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_KbPeriode]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_KbZahlungseingang] FOREIGN KEY([KbZahlungseingangID])
REFERENCES [dbo].[KbZahlungseingang] ([KbZahlungseingangID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_KbZahlungseingang]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_KbZahlungskonto] FOREIGN KEY([KbZahlungskontoID])
REFERENCES [dbo].[KbZahlungskonto] ([KbZahlungskontoID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_KbZahlungskonto]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_UserID_Kasse] FOREIGN KEY([BarbelegUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_UserID_Kasse]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_XUser_ErstelltUserID] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_XUser_ErstelltUserID]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_XUser_MutiertUserID] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_XUser_MutiertUserID]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [CK_KbBuchung_DataIntegrity] CHECK  (([dbo].[fnKbCKKbBuchungIntegrity]([KbBuchungID],[KbBuchungStatusCode],[Betrag],[SollKtoNr],[HabenKtoNr])=(0)))
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [CK_KbBuchung_DataIntegrity]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid KbBuchung records with verbuchen state' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'CONSTRAINT',@level2name=N'CK_KbBuchung_DataIntegrity'
GO

ALTER TABLE [dbo].[KbBuchung] ADD  CONSTRAINT [DF_KbBuchung_ErstelltDatum]  DEFAULT (getdate()) FOR [ErstelltDatum]
GO

