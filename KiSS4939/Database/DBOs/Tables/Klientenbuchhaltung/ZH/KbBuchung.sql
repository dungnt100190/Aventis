CREATE TABLE [dbo].[KbBuchung](
    [KbBuchungID] [int] IDENTITY(1,1) NOT NULL,
    [KbPeriodeID] [int] NOT NULL,
    [FaLeistungID] [int] NULL,
    [IkPositionID] [int] NULL,
    [KbBuchungTypCode] [int] NOT NULL,
    [Code] [varchar](10) NULL,
    [BelegNr] [bigint] NULL,
    [BelegDatum] [datetime] NULL,
    [ValutaDatum] [datetime] NULL,
    [TransferDatum] [datetime] NULL,
    [Betrag] [money] NOT NULL,
    [Text] [varchar](200) NOT NULL,
    [KbBuchungStatusCode] [int] NULL,
    [SollKtoNr] [varchar](10) NULL,
    [HabenKtoNr] [varchar](10) NULL,
    [KbZahlungseingangID] [int] NULL,
    [BaZahlungswegID] [int] NULL,
    [KbAuszahlungsArtCode] [int] NULL,
    [PCKontoNr] [varchar](50) NULL,
    [BaBankID] [int] NULL,
    [BankKontoNr] [varchar](50) NULL,
    [IBAN] [varchar](50) NULL,
    [ReferenzNummer] [varchar](50) NULL,
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
    [BeguenstigtOrt] [varchar](100) NULL,
    [BeguenstigtPLZ] [varchar](10) NULL,
    [BeguenstigtLandCode] [int] NULL,
    [KbBuchungTS] [timestamp] NOT NULL,
    [BgBudgetID] [int] NULL,
    [BarbelegUserID] [int] NULL,
    [BarbelegDatum] [datetime] NULL,
    [CashOrCheckAm] [datetime] NULL,
    [PscdZahlwegArt] [char](1) NULL,
    [PscdFehlermeldung] [varchar](500) NULL,
    [StorniertKbBuchungID] [int] NULL,
    [Schuldner_BaInstitutionID] [int] NULL,
    [Schuldner_BaPersonID] [int] NULL,
    [ModulID] [int] NULL,
    [KbForderungIstSH] [bit] NULL,
    [Kostenstelle] [varchar](20) NULL,
    [BankName] [varchar](70) NULL,
    [BankStrasse] [varchar](50) NULL,
    [BankPLZ] [varchar](10) NULL,
    [BankOrt] [varchar](60) NULL,
    [BankBCN] [varchar](10) NULL,
    [ErstelltUserID] [int] NULL,
    [ErstelltDatum] [datetime] NULL,
    [MutiertUserID] [int] NULL,
    [MutiertDatum] [datetime] NULL,
    [IkForderungArtCode] [int] NULL,
    [Dossiernummer] [varchar](10) NULL,
    [Fakturiert] [bit] NOT NULL,
    [Mahnstufe] [int] NULL,
    [Fakturasperre] [bit] NOT NULL,
    [Mahnsperre] [bit] NOT NULL,
    [AuszahlungErzeugen] [bit] NULL,
    [RuecklaeuferErledigt] [bit] NOT NULL,
    [RuecklaeuferBemerkung] [varchar](100) NULL,
    [BarbelegAuszahlDatum] [datetime] NULL,
    [BarbelegGueltigVon] [datetime] NULL,
    [KbZahlungskontoID] [int] NULL,
 CONSTRAINT [PK_KbBuchung] PRIMARY KEY CLUSTERED 
(
    [KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbBuchung_BaZahlungswegID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_BaZahlungswegID] ON [dbo].[KbBuchung] 
(
    [BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_BeguenstigtLandCode]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_BeguenstigtLandCode] ON [dbo].[KbBuchung] 
(
    [BeguenstigtLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_BelegNr]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_BelegNr] ON [dbo].[KbBuchung] 
(
    [BelegNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_BgBudgetID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_BgBudgetID] ON [dbo].[KbBuchung] 
(
    [BgBudgetID] ASC
)
INCLUDE ( [BelegNr],
[BelegDatum],
[KbBuchungStatusCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_FaLeistungID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_FaLeistungID] ON [dbo].[KbBuchung] 
(
    [FaLeistungID] ASC
)
INCLUDE ( [KbBuchungTypCode],
[BelegNr],
[ValutaDatum],
[TransferDatum],
[KbBuchungStatusCode],
[BaZahlungswegID],
[KbAuszahlungsArtCode],
[ErstelltDatum],
[IkPositionID],
[Betrag],
[ErstelltUserID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_HabenKtoNr]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_HabenKtoNr] ON [dbo].[KbBuchung] 
(
    [HabenKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_IkForderungArtCode]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_IkForderungArtCode] ON [dbo].[KbBuchung] 
(
    [IkForderungArtCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchung_IkPositionID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_IkPositionID] ON [dbo].[KbBuchung] 
(
    [IkPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungID_KbAuszahlungsArtCode_KbBuchungStatusCode_BelegDatum_ValutaDatum]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungID_KbAuszahlungsArtCode_KbBuchungStatusCode_BelegDatum_ValutaDatum] ON [dbo].[KbBuchung] 
(
    [KbBuchungID] ASC,
    [KbAuszahlungsArtCode] ASC,
    [KbBuchungStatusCode] ASC,
    [BelegDatum] ASC,
    [ValutaDatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungStatusCode]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungStatusCode] ON [dbo].[KbBuchung] 
(
    [KbBuchungStatusCode] ASC
)
INCLUDE ( [PscdFehlermeldung],
[BelegDatum],
[Text],
[Betrag],
[ValutaDatum],
[KbBuchungTS],
[KbPeriodeID],
[SollKtoNr],
[HabenKtoNr],
[BaZahlungswegID],
[KbAuszahlungsArtCode],
[PCKontoNr],
[BankKontoNr],
[ReferenzNummer],
[BeguenstigtName],
[BeguenstigtName2],
[BeguenstigtStrasse],
[BeguenstigtHausNr],
[BeguenstigtPostfach],
[BeguenstigtOrt],
[BeguenstigtPLZ],
[BgBudgetID],
[Schuldner_BaInstitutionID],
[Schuldner_BaPersonID],
[BankName],
[BelegNr],
[IkPositionID],
[ModulID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_KbBuchungTypCode_KbZahlungseingangID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbBuchungTypCode_KbZahlungseingangID] ON [dbo].[KbBuchung] 
(
    [KbBuchungTypCode] ASC,
    [KbZahlungseingangID] ASC
)
INCLUDE ( [KbBuchungID],
[BelegNr],
[KbPeriodeID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_KbPeriodeID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbPeriodeID] ON [dbo].[KbBuchung] 
(
    [KbPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_KbZahlungseingangID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbZahlungseingangID] ON [dbo].[KbBuchung] 
(
    [KbZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_KbZahlungskontoID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_KbZahlungskontoID] ON [dbo].[KbBuchung] 
(
    [KbZahlungskontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_KbBuchung_SollKtoNr]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_SollKtoNr] ON [dbo].[KbBuchung] 
(
    [SollKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchung_StorniertKbBuchungID]    Script Date: 11/06/2013 08:42:39 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchung_StorniertKbBuchungID] ON [dbo].[KbBuchung] 
(
    [StorniertKbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Bei ausgedruckten Barbelegen entspricht dieses Datum dem Startdatum der Gültigkeit des Barbelegs. Dies ist in den meisten Fällen identisch mit dem Valutadatum. Das Valutadatum kann aber beim Transfer ins PSCD geändert werden, daher muss das GültigVon Datum separat gespeichert werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'BarbelegGueltigVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf KbZahlungskonto. Ist für die Gesuchverwaltung verwendet um einen Zahlungskonto auf der Buchung zu definieren' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'COLUMN',@level2name=N'KbZahlungskontoID'
GO

/****** Object:  Trigger [dbo].[trKbBuchung_Delete]    Script Date: 11/06/2013 08:42:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[trKbBuchung_Delete]
  ON [dbo].[KbBuchung]
  FOR DELETE NOT FOR REPLICATION
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON


  -- Kontrolle, ob gelöscht werden darf
  IF EXISTS(
    SELECT KbBuchungID FROM DELETED
    WHERE KbBuchungStatusCode = 8
  )
  BEGIN
    ROLLBACK TRANSACTION
    RAISERROR ('Stornierte Buchungen können nicht gelöscht werden.', 18, 1)
    RETURN
  END

  IF EXISTS(
    SELECT KbBuchungID FROM DELETED
    WHERE TransferDatum IS NOT NULL
  )
  BEGIN
    ROLLBACK TRANSACTION
    RAISERROR ('An PSCD gesendete Buchungen können nicht gelöscht werden.', 18, 1)
    RETURN
  END

  IF EXISTS(
    SELECT KbBuchungID FROM DELETED
    WHERE BarbelegDatum IS NOT NULL
  )
  BEGIN
    ROLLBACK TRANSACTION
    RAISERROR ('Ausgedruckte Barbelege können nicht gelöscht werden.', 18, 1)
    RETURN
  END

  -- Füllen von PscdVerloreneBelegNummern beim Löschen von Buchungen
  -- aber nur, wenn Buchung noch nicht ans PSCD gesendet worden ist
  -- und die Belegnummer in PscdVerloreneBelegNummern noch nicht existiert
  INSERT INTO PscdVerloreneBelegNummern (BelegNr)
  SELECT BelegNr FROM DELETED D
  WHERE D.BelegNr IS NOT NULL
    AND NOT EXISTS(
      SELECT V.BelegNr FROM PscdVerloreneBelegNummern V
      WHERE V.BelegNr = D.BelegNr
    )

END



GO

--KbBuchung
CREATE TRIGGER [dbo].[TR_KbBuchung_RowDeleted]
       ON [dbo].[KbBuchung]
AFTER DELETE
AS
BEGIN
  DECLARE @Creator VARCHAR(50);
  SET @Creator = HOST_NAME() + '(' + ORIGINAL_LOGIN() + ')';

  INSERT INTO dbo.XLog
   (Source,
    SourceKey,
    XLogLevelCode,
    Message,
    Comment,
    ReferenceTable,
    ReferenceID,
    NonPurgeable,
    Creator,
    Created,
    Modifier,
    Modified)
  SELECT
    'TR_KbBuchung_RowDeleted', -- Source - varchar(255)
    0, -- SourceKey - int
    0, -- XLogLevelCode - int
    'In Tabelle KbBuchung wurde folgender Datensatz gelöscht: KbBuchungID = ' + CONVERT(VARCHAR(50), KbBuchungID) + ', BelegNr = '  + ISNULL(CONVERT(VARCHAR(50), BelegNr), 'NULL')  + ', BgBudgetID = ' + ISNULL(CONVERT(VARCHAR(50), BgBudgetID), 'NULL') + '.', -- Message - varchar(max)
    'Datensatz durch Trigger TR_KbBuchung_RowDeleted erstellt', -- Comment - varchar(max)
    'KbBuchung', -- ReferenceTable - varchar(100)
    KbBuchungID, -- ReferenceID - int
    0, -- NonPurgeable - bit
    @Creator, -- Creator - varchar(50)
    GETDATE(), -- Created - datetime
    @Creator, -- Modifier - varchar(50)
    GETDATE() -- Modified - datetime
  FROM DELETED 
END

GO

ALTER TABLE [dbo].[KbBuchung] ENABLE TRIGGER [TR_KbBuchung_RowDeleted]
GO


ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BaLand] FOREIGN KEY([BeguenstigtLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BaLand]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_BaZahlungsweg]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_FaLeistung]
GO

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_IkPosition] FOREIGN KEY([IkPositionID])
REFERENCES [dbo].[IkPosition] ([IkPositionID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_IkPosition]
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

ALTER TABLE [dbo].[KbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchung_StorniertKbBuchungID] FOREIGN KEY([StorniertKbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [FK_KbBuchung_StorniertKbBuchungID]
GO

ALTER TABLE [dbo].[KbBuchung] ADD  CONSTRAINT [DF_KbBuchung_Fakturiert]  DEFAULT ((0)) FOR [Fakturiert]
GO

ALTER TABLE [dbo].[KbBuchung] ADD  CONSTRAINT [DF_KbBuchung_Fakturasperre]  DEFAULT ((0)) FOR [Fakturasperre]
GO

ALTER TABLE [dbo].[KbBuchung] ADD  CONSTRAINT [DF_KbBuchung_Mahnsperre]  DEFAULT ((0)) FOR [Mahnsperre]
GO

ALTER TABLE [dbo].[KbBuchung] ADD  CONSTRAINT [DF_KbBuchung_RuecklaeuferErledigt]  DEFAULT ((0)) FOR [RuecklaeuferErledigt]
GO


