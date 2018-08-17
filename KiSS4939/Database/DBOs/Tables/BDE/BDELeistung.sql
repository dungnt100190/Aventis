CREATE TABLE [dbo].[BDELeistung](
	[BDELeistungID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[BDELeistungsartID] [int] NOT NULL,
	[KostenstelleOrgUnitID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[Datum] [datetime] NOT NULL,
	[Dauer] [money] NULL,
	[Anzahl] [int] NULL,
	[LohnartCode] [int] NULL,
	[Bemerkung] [varchar](500) NULL,
  [KeinExport] [bit] NOT NULL,
	[HistKostentraeger] [int] NOT NULL,
	[HistKostenstelle] [int] NOT NULL,
	[HistKostenart] [int] NOT NULL,
	[HistMandantNr] [int] NOT NULL,
	[Freigegeben] [bit] NOT NULL,
	[Visiert] [bit] NOT NULL,
	[Verbucht] [datetime] NULL,
	[VerbuchtLD] [datetime] NULL,
  [Fakturiert] [bit] NOT NULL,
	[VerID] [int] NULL,
	[BDELeistungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BDELeistung] PRIMARY KEY CLUSTERED 
(
	[BDELeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_BaPersonID] ON [dbo].[BDELeistung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_BaPersonID_Datum_Anzahl_BDELaID] ON [dbo].[BDELeistung] 
(
	[BaPersonID] ASC,
	[Datum] ASC,
	[Anzahl] ASC,
	[BDELeistungsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_BaPersonID_Datum_Dauer] ON [dbo].[BDELeistung] 
(
	[BaPersonID] ASC,
	[Datum] ASC,
	[Dauer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_BaPersonID_Datum_Dauer_BDELaID] ON [dbo].[BDELeistung] 
(
	[BaPersonID] ASC,
	[Datum] ASC,
	[Dauer] ASC,
	[BDELeistungsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_BDELeistungsartID] ON [dbo].[BDELeistung] 
(
	[BDELeistungsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_Datum] ON [dbo].[BDELeistung] 
(
	[Datum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_Datum_Dauer_UserID] ON [dbo].[BDELeistung] 
(
	[Datum] ASC,
	[Dauer] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_DatumDauerUserIDBDELaIDKSTOrgUnitIDLohnArtCode] ON [dbo].[BDELeistung] 
(
	[Datum] ASC,
	[Dauer] ASC,
	[UserID] ASC,
	[BDELeistungsartID] ASC,
	[KostenstelleOrgUnitID] ASC,
	[LohnartCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_DatumUserIDLohnartCode] ON [dbo].[BDELeistung] 
(
	[Datum] ASC,
	[UserID] ASC,
	[LohnartCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_HistKostenart] ON [dbo].[BDELeistung] 
(
	[HistKostenart] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_HistKostenstelle] ON [dbo].[BDELeistung] 
(
	[HistKostenstelle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_HistKostentraeger] ON [dbo].[BDELeistung] 
(
	[HistKostentraeger] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_HistMandantNr] ON [dbo].[BDELeistung] 
(
	[HistMandantNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_KostenstelleOrgUnitID] ON [dbo].[BDELeistung] 
(
	[KostenstelleOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_UserID] ON [dbo].[BDELeistung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_UserIDDatumFreigegeben] ON [dbo].[BDELeistung] 
(
	[UserID] ASC,
	[Datum] ASC,
	[Freigegeben] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_UserIDDatumVerbKSTOrgBDELaIDDauerLACode] ON [dbo].[BDELeistung] 
(
	[UserID] ASC,
	[Datum] ASC,
	[Verbucht] ASC,
	[KostenstelleOrgUnitID] ASC,
	[BDELeistungsartID] ASC,
	[Dauer] ASC,
	[LohnartCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_UserIDDatumVerbuchtKSTOrgUnitID] ON [dbo].[BDELeistung] 
(
	[UserID] ASC,
	[Datum] ASC,
	[Verbucht] ASC,
	[KostenstelleOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_UserIDDatumVerbuchtLDKSTOrgUnitID] ON [dbo].[BDELeistung] 
(
	[UserID] ASC,
	[Datum] ASC,
	[VerbuchtLD] ASC,
	[KostenstelleOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_UserIDDatumVisiert] ON [dbo].[BDELeistung] 
(
	[UserID] ASC,
	[Datum] ASC,
	[Visiert] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_UserIDLBDELaIDKSTOrgDatLA] ON [dbo].[BDELeistung] 
(
	[UserID] ASC,
	[BDELeistungsartID] ASC,
	[KostenstelleOrgUnitID] ASC,
	[Datum] ASC,
	[LohnartCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_Verbucht] ON [dbo].[BDELeistung] 
(
	[Verbucht] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_BDELeistung_Visiert] ON [dbo].[BDELeistung] 
(
	[Visiert] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

CREATE NONCLUSTERED INDEX [IX_BDELeistung_Datum_Verbucht_VerbuchtLD_HistMandantNr] ON [dbo].[BDELeistung] 
(
[Datum] desc,
[Verbucht] ASC,
[VerbuchtLD] ASC,
[HistMandantNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

CREATE NONCLUSTERED INDEX [IX_BDELeistung_Fakturierung] ON [dbo].[BDELeistung] 
(   
    [Visiert],
    [Fakturiert]
)
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDELeistung', @level2type=N'COLUMN',@level2name=N'BDELeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob diese Leistung über die Schnittstelle exportiert werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDELeistung', @level2type=N'COLUMN',@level2name=N'KeinExport'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Historisierter, berechneter Wert des Kostenträgers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDELeistung', @level2type=N'COLUMN',@level2name=N'HistKostentraeger'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Historisierter, berechneter Wert der Kostenstelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDELeistung', @level2type=N'COLUMN',@level2name=N'HistKostenstelle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Historisierter, berechneter Wert der Kostenart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDELeistung', @level2type=N'COLUMN',@level2name=N'HistKostenart'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Historisierter, berechneter Wert der MandantenNummer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDELeistung', @level2type=N'COLUMN',@level2name=N'HistMandantNr'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDELeistung'
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [trHist_BDELeistung]
  ON [BDELeistung]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON
  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [BDELeistung] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [BDELeistungID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [BDELeistungID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[BDELeistungID], DEL.[BDELeistungID]), TBL.VerID,
      CASE WHEN (INS.[BDELeistungID] IS NULL) THEN 3 WHEN (DEL.[BDELeistungID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[BDELeistungID] = INS.[BDELeistungID]
      LEFT       JOIN [Hist_BDELeistung]  TBL ON TBL.[BDELeistungID] = DEL.[BDELeistungID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[BDELeistungID] IS NULL) OR (DEL.[BDELeistungID] IS NULL)
      OR CHECKSUM(INS.[BDELeistungID], INS.[UserID], INS.[BDELeistungsartID], INS.[KostenstelleOrgUnitID], INS.[BaPersonID], INS.[Datum], INS.[Dauer], INS.[Anzahl], INS.[LohnartCode], INS.[Bemerkung], INS.[KeinExport], INS.[HistKostentraeger], INS.[HistKostenstelle], INS.[HistKostenart], INS.[HistMandantNr], INS.[Freigegeben], INS.[Visiert], INS.[Verbucht], INS.[VerbuchtLD], INS.[Fakturiert])
      <> CHECKSUM(TBL.[BDELeistungID], TBL.[UserID], TBL.[BDELeistungsartID], TBL.[KostenstelleOrgUnitID], TBL.[BaPersonID], TBL.[Datum], TBL.[Dauer], TBL.[Anzahl], TBL.[LohnartCode], TBL.[Bemerkung], TBL.[KeinExport], TBL.[HistKostentraeger], TBL.[HistKostenstelle], TBL.[HistKostenart], TBL.[HistMandantNr], TBL.[Freigegeben], TBL.[Visiert], TBL.[Verbucht], TBL.[VerbuchtLD], TBL.[Fakturiert])



  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_BDELeistung]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[BDELeistungID] = TBL.[BDELeistungID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_BDELeistung]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[BDELeistungID] = TBL.[BDELeistungID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_BDELeistung ([BDELeistungID], [UserID], [BDELeistungsartID], [KostenstelleOrgUnitID], [BaPersonID], [Datum], [Dauer], [Anzahl], [LohnartCode], [Bemerkung], [KeinExport], [HistKostentraeger], [HistKostenstelle], [HistKostenart], [HistMandantNr], [Freigegeben], [Visiert], [Verbucht], [VerbuchtLD], [Fakturiert], VerID)
      SELECT TBL.[BDELeistungID], TBL.[UserID], TBL.[BDELeistungsartID], TBL.[KostenstelleOrgUnitID], TBL.[BaPersonID], TBL.[Datum], TBL.[Dauer], TBL.[Anzahl], TBL.[LohnartCode], TBL.[Bemerkung], TBL.[KeinExport], TBL.[HistKostentraeger], TBL.[HistKostenstelle], TBL.[HistKostenart], TBL.[HistMandantNr], TBL.[Freigegeben], TBL.[Visiert], TBL.[Verbucht], TBL.[VerbuchtLD], TBL.[Fakturiert], @VerID
      FROM [BDELeistung]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BDELeistungID] = TBL.[BDELeistungID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [BDELeistung]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BDELeistungID] = TBL.[BDELeistungID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END
  SET NOCOUNT OFF
END

GO

ALTER TABLE [dbo].[BDELeistung]  WITH CHECK ADD  CONSTRAINT [FK_BDELeistung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BDELeistung] CHECK CONSTRAINT [FK_BDELeistung_BaPerson]
GO

ALTER TABLE [dbo].[BDELeistung]  WITH CHECK ADD  CONSTRAINT [FK_BDELeistung_BDELeistungsart] FOREIGN KEY([BDELeistungsartID])
REFERENCES [dbo].[BDELeistungsart] ([BDELeistungsartID])
GO

ALTER TABLE [dbo].[BDELeistung] CHECK CONSTRAINT [FK_BDELeistung_BDELeistungsart]
GO

ALTER TABLE [dbo].[BDELeistung]  WITH CHECK ADD  CONSTRAINT [FK_BDELeistung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BDELeistung] CHECK CONSTRAINT [FK_BDELeistung_XUser]
GO

ALTER TABLE [dbo].[BDELeistung] ADD  CONSTRAINT [DF_BDELeistung_Freigegeben]  DEFAULT ((0)) FOR [Freigegeben]
GO

ALTER TABLE [dbo].[BDELeistung] ADD  CONSTRAINT [DF_BDELeistung_KeinExport]  DEFAULT ((0)) FOR [KeinExport]
GO

ALTER TABLE [dbo].[BDELeistung] ADD  CONSTRAINT [DF_BDELeistung_Visiert]  DEFAULT ((0)) FOR [Visiert]
GO

ALTER TABLE [dbo].[BDELeistung] ADD  CONSTRAINT [DF_BDELeistung_Fakturiert]  DEFAULT ((0)) FOR [Fakturiert]
GO