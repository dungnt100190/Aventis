CREATE TABLE [dbo].[KgBuchung](
	[KgBuchungID] [int] IDENTITY(1,1) NOT NULL,
	[KgPeriodeID] [int] NOT NULL,
	[KgPositionID] [int] NULL,
	[KgBuchungTypCode] [int] NOT NULL,
	[KgAusgleichStatusCode] [int] NULL,
	[KgZahlungseingangID] [int] NULL,
	[CodeVorlage] [varchar](15) NULL,
	[BelegNr] [varchar](15) NULL,
	[BelegNrPos] [int] NULL,
	[BuchungsDatum] [datetime] NOT NULL,
	[SollKtoNr] [varchar](10) NULL,
	[HabenKtoNr] [varchar](10) NULL,
	[Betrag] [money] NOT NULL,
	[BetragFW] [money] NULL,
	[FbWaehrungID] [int] NULL,
	[Text] [varchar](200) NOT NULL,
	[ValutaDatum] [datetime] NULL,
	[BarbezugDatum] [datetime] NULL,
	[TransferDatum] [datetime] NULL,
	[KgBuchungStatusCode] [int] NULL,
	[UserIDKasse] [int] NULL,
	[BaZahlungswegID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[EinzahlungsscheinCode] [int] NULL,
	[KgAuszahlungsArtCode] [int] NULL,
	[BaBankID] [int] NULL,
	[BankKontoNummer] [varchar](50) NULL,
	[IBANNummer] [varchar](50) NULL,
	[PostKontoNummer] [varchar](20) NULL,
	[ESRTeilnehmer] [varchar](50) NULL,
	[ESRReferenznummer] [varchar](50) NULL,
	[BeguenstigtName] [varchar](100) NULL,
	[BeguenstigtName2] [varchar](200) NULL,
	[BeguenstigtStrasse] [varchar](100) NULL,
	[BeguenstigtHausNr] [varchar](10) NULL,
	[BeguenstigtPostfach] [varchar](40) NULL,
	[BeguenstigtOrt] [varchar](100) NULL,
	[BeguenstigtPLZ] [varchar](10) NULL,
	[BeguenstigtLandCode] [int] NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[KgBuchungTS] [timestamp] NOT NULL,
	[PscdFehlermeldung] [varchar](200) NULL,
	[PscdBelegNr] [bigint] NULL,
	[StorniertKgBuchungID] [int] NULL,
	[NeubuchungVonKgBuchungID] [int] NULL,
	[BarbelegUserID] [int] NULL,
	[BarbelegDatum] [datetime] NULL,
	[BarbelegAuszahlDatum] [datetime] NULL,
	[BarbelegGueltigVon] [datetime] NULL,
 CONSTRAINT [PK_KgBuchung] PRIMARY KEY CLUSTERED 
(
	[KgBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KgBuchung_BaBankID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_BaBankID] ON [dbo].[KgBuchung] 
(
	[BaBankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBuchung_BaZahlungswegID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_BaZahlungswegID] ON [dbo].[KgBuchung] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_BeguenstigtLandCode]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_BeguenstigtLandCode] ON [dbo].[KgBuchung] 
(
	[BeguenstigtLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBuchung_ErstelltUserID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_ErstelltUserID] ON [dbo].[KgBuchung] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_HabenKtoNr]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_HabenKtoNr] ON [dbo].[KgBuchung] 
(
	[HabenKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_KgBuchungStatusCode]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_KgBuchungStatusCode] ON [dbo].[KgBuchung] 
(
	[KgBuchungStatusCode] ASC
)
INCLUDE ( [ValutaDatum],
[KgPeriodeID],
[KgPositionID],
[BuchungsDatum],
[SollKtoNr],
[HabenKtoNr],
[Betrag],
[Text],
[KgAuszahlungsArtCode],
[PscdFehlermeldung],
[BaZahlungswegID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBuchung_KgPeriodeID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_KgPeriodeID] ON [dbo].[KgBuchung] 
(
	[KgPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_KgPeriodeID_HabenKtoNr]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_KgPeriodeID_HabenKtoNr] ON [dbo].[KgBuchung] 
(
	[KgPeriodeID] ASC,
	[HabenKtoNr] ASC
)
INCLUDE ( [BuchungsDatum],
[Betrag]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_KgPeriodeID_SollKtoNr]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_KgPeriodeID_SollKtoNr] ON [dbo].[KgBuchung] 
(
	[KgPeriodeID] ASC,
	[SollKtoNr] ASC
)
INCLUDE ( [KgPositionID],
[KgBuchungTypCode],
[KgAusgleichStatusCode],
[KgZahlungseingangID],
[CodeVorlage],
[BelegNr],
[BelegNrPos],
[BuchungsDatum],
[HabenKtoNr],
[Betrag],
[BetragFW],
[FbWaehrungID],
[Text],
[ValutaDatum],
[BarbezugDatum],
[TransferDatum],
[KgBuchungStatusCode],
[UserIDKasse],
[BaZahlungswegID],
[BaInstitutionID],
[EinzahlungsscheinCode],
[KgAuszahlungsArtCode],
[BaBankID],
[BankKontoNummer],
[IBANNummer],
[PostKontoNummer],
[ESRTeilnehmer],
[ESRReferenznummer],
[BeguenstigtName],
[BeguenstigtName2],
[BeguenstigtStrasse],
[BeguenstigtHausNr],
[BeguenstigtPostfach],
[BeguenstigtOrt],
[BeguenstigtPLZ],
[BeguenstigtLandCode],
[MitteilungZeile1],
[MitteilungZeile2],
[MitteilungZeile3],
[MitteilungZeile4],
[ErstelltUserID],
[ErstelltDatum],
[MutiertUserID],
[MutiertDatum],
[KgBuchungTS],
[PscdFehlermeldung],
[PscdBelegNr],
[StorniertKgBuchungID],
[NeubuchungVonKgBuchungID],
[BarbelegUserID],
[BarbelegDatum],
[BarbelegAuszahlDatum]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_KgPositionID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_KgPositionID] ON [dbo].[KgBuchung] 
(
	[KgPositionID] ASC
)
INCLUDE ( [KgBuchungStatusCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBuchung_KgZahlungseingangID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_KgZahlungseingangID] ON [dbo].[KgBuchung] 
(
	[KgZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_NeubuchungVonKgBuchungID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_NeubuchungVonKgBuchungID] ON [dbo].[KgBuchung] 
(
	[NeubuchungVonKgBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBuchung_PscdBelegNr]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_PscdBelegNr] ON [dbo].[KgBuchung] 
(
	[PscdBelegNr] ASC
)
INCLUDE ( [KgBuchungTS]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBuchung_SollKtoNr]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_SollKtoNr] ON [dbo].[KgBuchung] 
(
	[SollKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgBuchung_StorniertKgBuchungID]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_StorniertKgBuchungID] ON [dbo].[KgBuchung] 
(
	[StorniertKgBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBuchung_TransferDatum]    Script Date: 11/23/2011 16:00:29 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchung_TransferDatum] ON [dbo].[KgBuchung] 
(
	[TransferDatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Trigger [dbo].[trKgBuchung_AfterInsert]    Script Date: 11/23/2011 16:00:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[trKgBuchung_AfterInsert]
   ON  [dbo].[KgBuchung]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @KGBUCHUNGOFFSET bigint

	SELECT @KGBUCHUNGOFFSET = FirstID FROM PscdKeySource WHERE KeyName = 'AK'

    -- Update PSCDBelegNr
	UPDATE BUC
	SET PscdBelegNr = @KGBUCHUNGOFFSET + BUC.KgBuchungID
	FROM dbo.KgBuchung BUC
    INNER JOIN inserted INS ON INS.KgBuchungID = BUC.KgBuchungID
	WHERE BUC.PscdBelegNr IS NULL

END

GO

/****** Object:  Trigger [dbo].[trKgBuchung_AfterUpdate]    Script Date: 11/23/2011 16:00:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[trKgBuchung_AfterUpdate]
   ON  [dbo].[KgBuchung]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @KGBUCHUNGOFFSET bigint

	SELECT @KGBUCHUNGOFFSET = FirstID FROM PscdKeySource WHERE KeyName = 'AK'

    -- Update PSCDBelegNr
	UPDATE BUC
	SET PscdBelegNr = @KGBUCHUNGOFFSET + BUC.KgBuchungID
	FROM dbo.KgBuchung BUC
    INNER JOIN inserted INS ON INS.KgBuchungID = BUC.KgBuchungID
	WHERE BUC.PscdBelegNr IS NULL

END

GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Bei ausgedruckten Barbelegen entspricht dieses Datum dem Startdatum der Gültigkeit des Barbelegs. Dies ist in den meisten Fällen identisch mit dem Valutadatum. Das Valutadatum kann aber beim Transfer ins PSCD geändert werden, daher muss das GültigVon Datum separat gespeichert werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KgBuchung', @level2type=N'COLUMN',@level2name=N'BarbelegGueltigVon'
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_BaBank] FOREIGN KEY([BaBankID])
REFERENCES [dbo].[BaBank] ([BaBankID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_BaBank]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_BaLand] FOREIGN KEY([BeguenstigtLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_BaLand]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_BaZahlungsweg]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_KgKonto] FOREIGN KEY([KgPeriodeID], [SollKtoNr])
REFERENCES [dbo].[KgKonto] ([KgPeriodeID], [KontoNr])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_KgKonto]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_KgKonto1] FOREIGN KEY([KgPeriodeID], [HabenKtoNr])
REFERENCES [dbo].[KgKonto] ([KgPeriodeID], [KontoNr])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_KgKonto1]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_KgPeriode] FOREIGN KEY([KgPeriodeID])
REFERENCES [dbo].[KgPeriode] ([KgPeriodeID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_KgPeriode]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_KgPosition] FOREIGN KEY([KgPositionID])
REFERENCES [dbo].[KgPosition] ([KgPositionID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_KgPosition]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_KgZahlungseingang] FOREIGN KEY([KgZahlungseingangID])
REFERENCES [dbo].[KgZahlungseingang] ([KgZahlungseingangID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_KgZahlungseingang]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_NeubuchungVonKgBuchung] FOREIGN KEY([NeubuchungVonKgBuchungID])
REFERENCES [dbo].[KgBuchung] ([KgBuchungID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_NeubuchungVonKgBuchung]
GO
ALTER TABLE [dbo].[KgBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchung_StorniertKgBuchung] FOREIGN KEY([StorniertKgBuchungID])
REFERENCES [dbo].[KgBuchung] ([KgBuchungID])
GO
ALTER TABLE [dbo].[KgBuchung] CHECK CONSTRAINT [FK_KgBuchung_StorniertKgBuchung]