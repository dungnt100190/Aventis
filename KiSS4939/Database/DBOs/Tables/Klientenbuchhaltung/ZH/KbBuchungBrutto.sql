CREATE TABLE [dbo].[KbBuchungBrutto](
    [KbBuchungBruttoID] [int] IDENTITY(1,1) NOT NULL,
    [KbPeriodeID] [int] NOT NULL,
    [BgKostenartID] [int] NULL,
    [KbBuchungTypCode] [int] NOT NULL,
    [Code] [varchar](10) NULL,
    [BelegNr] [bigint] NULL,
    [BelegDatum] [datetime] NULL,
    [ValutaDatum] [datetime] NULL,
    [ErfassungsDatum] [datetime] NULL CONSTRAINT [DF_KbBuchungBrutto_ErfassungsDatum]  DEFAULT (getdate()),
    [TransferDatum] [datetime] NULL,
    [Zahlungsfrist] [int] NULL,
    [Betrag] [money] NOT NULL,
    [BetragEffektiv] [money] NOT NULL CONSTRAINT [DF_KbBuchungBrutto_BetragEffektiv]  DEFAULT (($0.0000)),
    [DatumEffektiv] [datetime] NULL,
    [Text] [varchar](200) NOT NULL,
    [KbBuchungStatusCode] [int] NULL,
    [UserID] [int] NULL,
    [KbBuchungBruttoTS] [timestamp] NOT NULL,
    [StorniertKbBuchungBruttoID] [int] NULL,
    [NeubuchungVonKbBuchungBruttoID] [int] NULL,
    [BgBudgetID] [int] NULL,
    [PscdFehlermeldung] [varchar](500) NULL,
    [ModulID] [int] NULL,
    [Kostenstelle] [varchar](20) NULL,
    [Hauptvorgang] [int] NULL,
    [Teilvorgang] [int] NULL,
    [Belegart] [varchar](4) NULL,
    [FaLeistungID] [int] NULL,
    [BgSplittingArtCode] [int] NULL,
    [Weiterverrechenbar] [bit] NULL CONSTRAINT [DF_KbBuchungBrutto_Weiterverrechenbar]  DEFAULT ((0)),
    [Quoting] [bit] NULL CONSTRAINT [DF_KbBuchungBrutto_Quoting]  DEFAULT ((0)),
    [Fakturiert] [bit] NOT NULL CONSTRAINT [DF_KbBuchungBrutto_Fakturiert]  DEFAULT ((0)),
    [MigDetailBuchungID] [int] NULL,
    [Mahnstufe] [int] NULL,
    [Abgetreten] [bit] NOT NULL CONSTRAINT [DF_KbBuchungBrutto_Abgetreten]  DEFAULT ((0)),
    [KbBuchungStatusCode_Netto] [int] NULL,
    [BetragEffektiv_Netto] [money] NOT NULL CONSTRAINT [DF_KbBuchungBrutto_BetragEffektiv_Netto]  DEFAULT ((0)),
    [GruppierungUmbuchung] [varchar](10) NULL,
    [Fakturasperre] [bit] NOT NULL CONSTRAINT [DF_KbBuchungBrutto_Fakturasperre]  DEFAULT ((0)),
    [Mahnsperre] [bit] NOT NULL CONSTRAINT [DF_KbBuchungBrutto_Mahnsperre]  DEFAULT ((0)),
    [PscdKennzeichen] [varchar](1) NULL,
 CONSTRAINT [PK_KbBuchungBrutto] PRIMARY KEY CLUSTERED 
(
    [KbBuchungBruttoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KbBuchungBrutto_BelegNr]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_BelegNr] ON [dbo].[KbBuchungBrutto] 
(
    [BelegNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_BgBudgetID]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_BgBudgetID] ON [dbo].[KbBuchungBrutto] 
(
    [BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_BgKostenartID]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_BgKostenartID] ON [dbo].[KbBuchungBrutto] 
(
    [BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_Div]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_Div] ON [dbo].[KbBuchungBrutto] 
(
    [StorniertKbBuchungBruttoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_FaLeistungID]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_FaLeistungID] ON [dbo].[KbBuchungBrutto] 
(
    [FaLeistungID] ASC
)
INCLUDE ( [BgKostenartID],
[KbBuchungTypCode],
[BelegNr],
[ValutaDatum],
[ErfassungsDatum],
[TransferDatum],
[Betrag],
[Text],
[KbBuchungStatusCode],
[StorniertKbBuchungBruttoID],
[NeubuchungVonKbBuchungBruttoID],
[BgBudgetID],
[Abgetreten],
[PscdKennzeichen]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_GruppierungUmbuchung]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_GruppierungUmbuchung] ON [dbo].[KbBuchungBrutto] 
(
    [GruppierungUmbuchung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_KbPeriodeID]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_KbPeriodeID] ON [dbo].[KbBuchungBrutto] 
(
    [KbPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_MigDetailBuchungID]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_MigDetailBuchungID] ON [dbo].[KbBuchungBrutto] 
(
    [MigDetailBuchungID] ASC
)
INCLUDE ( [KbBuchungStatusCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_NeubuchungVonKbBuchungBruttoID]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_NeubuchungVonKbBuchungBruttoID] ON [dbo].[KbBuchungBrutto] 
(
    [NeubuchungVonKbBuchungBruttoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbBuchungBrutto_UserID]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_UserID] ON [dbo].[KbBuchungBrutto] 
(
    [UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungBrutto_ValutaDatum]    Script Date: 11/23/2011 15:54:17 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungBrutto_ValutaDatum] ON [dbo].[KbBuchungBrutto] 
(
    [ValutaDatum] ASC
)
INCLUDE ( [KbBuchungBruttoID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Trigger [dbo].[trKbBuchungBrutto_Delete]    Script Date: 11/23/2011 15:54:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		mminder
-- Create date: 29.08.2009
-- Description:	Verhindern, dass Buchungen gelöscht werden, die an PSCD gesendet wurden
-- =============================================
CREATE TRIGGER [dbo].[trKbBuchungBrutto_Delete]
  ON [dbo].[KbBuchungBrutto]
  FOR DELETE NOT FOR REPLICATION
AS
BEGIN

  IF EXISTS(
    SELECT KbBuchungBruttoID FROM DELETED
    WHERE TransferDatum IS NOT NULL
  )
  BEGIN
    ROLLBACK TRANSACTION
    RAISERROR ('An PSCD gesendete Buchungen können nicht gelöscht werden.', 18, 1)
    RETURN
  END

END

GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_BgBudget]
GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_BgKostenart]
GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_FaLeistungID] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_FaLeistungID]
GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_KbBuchungBrutto] FOREIGN KEY([StorniertKbBuchungBruttoID])
REFERENCES [dbo].[KbBuchungBrutto] ([KbBuchungBruttoID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_KbBuchungBrutto]
GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_KbPeriode] FOREIGN KEY([KbPeriodeID])
REFERENCES [dbo].[KbPeriode] ([KbPeriodeID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_KbPeriode]
GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_MigDetailBuchung] FOREIGN KEY([MigDetailBuchungID])
REFERENCES [dbo].[MigDetailBuchung] ([MigDetailBuchungID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_MigDetailBuchung]
GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_Neubuchung] FOREIGN KEY([NeubuchungVonKbBuchungBruttoID])
REFERENCES [dbo].[KbBuchungBrutto] ([KbBuchungBruttoID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_Neubuchung]
GO
ALTER TABLE [dbo].[KbBuchungBrutto]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBrutto_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[KbBuchungBrutto] CHECK CONSTRAINT [FK_KbBuchungBrutto_XUser]
GO

/****** Object:  Trigger [dbo].[TR_KbBuchungBrutto_RowDeleted]    Script Date: 24.06.2016 13:39:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--KbBuchungBrutto
CREATE TRIGGER [dbo].[TR_KbBuchungBrutto_RowDeleted]
       ON [dbo].[KbBuchungBrutto]
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
    'TR_KbBuchungBrutto_RowDeleted', -- Source - varchar(255)
    0, -- SourceKey - int
    0, -- XLogLevelCode - int
    'In Tabelle KbBuchungBrutto wurde folgender Datensatz gelöscht: KbBuchungBruttoID = ' + CONVERT(VARCHAR(50), KbBuchungBruttoID) + ', BelegNr = '  + ISNULL(CONVERT(VARCHAR(50),BelegNr), 'NULL')  + ', BgBudgetID = ' + ISNULL(CONVERT(VARCHAR(50), BgBudgetID), 'NULL')  + '.', -- Message - varchar(max)
    'Datensatz durch Trigger TR_KbBuchungBrutto_RowDeleted erstellt', -- Comment - varchar(max)
    'KbBuchungBrutto', -- ReferenceTable - varchar(100)
    KbBuchungBruttoID, -- ReferenceID - int
    0, -- NonPurgeable - bit
    @Creator, -- Creator - varchar(50)
    GETDATE(), -- Created - datetime
    @Creator, -- Modifier - varchar(50)
    GETDATE() -- Modified - datetime
  FROM DELETED 
END

GO

ALTER TABLE [dbo].[KbBuchungBrutto] ENABLE TRIGGER [TR_KbBuchungBrutto_RowDeleted]
GO