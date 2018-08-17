CREATE TABLE [dbo].[KbBuchungKostenart](
    [KbBuchungKostenartID] [int] IDENTITY(1,1) NOT NULL,
    [KbBuchungID] [int] NOT NULL,
    [BgPositionID] [int] NULL,
    [BgKostenartID] [int] NULL,
    [BaPersonID] [int] NULL,
    [Buchungstext] [varchar](200) NULL,
    [Betrag] [money] NOT NULL,
    [KontoNr] [varchar](10) NULL,
    [PositionImBeleg] [int] NULL,
    [Hauptvorgang] [int] NULL,
    [Teilvorgang] [int] NULL,
    [Belegart] [varchar](4) NULL,
    [KbBuchungKostenartTS] [timestamp] NOT NULL,
    [OLD_KbForderungArtCode] [int] NULL,
    [VerwPeriodeVon] [datetime] NULL,
    [VerwPeriodeBis] [datetime] NULL,
    [PscdKennzeichen] [varchar](1) NULL,
 CONSTRAINT [PK_KbBuchungKostenart] PRIMARY KEY CLUSTERED 
(
    [KbBuchungKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KbBuchungKostenart_BaPersonID]    Script Date: 11/23/2011 15:55:13 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BaPersonID] ON [dbo].[KbBuchungKostenart] 
(
    [BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungKostenart_BgKostenartID]    Script Date: 11/23/2011 15:55:13 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BgKostenartID] ON [dbo].[KbBuchungKostenart] 
(
    [BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungKostenart_BgKostenartID_KbBuchungKostenartID_KbBuchungID]    Script Date: 11/23/2011 15:55:13 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BgKostenartID_KbBuchungKostenartID_KbBuchungID] ON [dbo].[KbBuchungKostenart] 
(
    [BgKostenartID] ASC,
    [KbBuchungKostenartID] ASC,
    [KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbBuchungKostenart_BgPositionID]    Script Date: 11/23/2011 15:55:13 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_BgPositionID] ON [dbo].[KbBuchungKostenart] 
(
    [BgPositionID] ASC
)
INCLUDE ( [KbBuchungID],
[BgKostenartID],
[BaPersonID],
[Buchungstext],
[Betrag],
[VerwPeriodeVon],
[VerwPeriodeBis]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungKostenart_KbBuchungID]    Script Date: 11/23/2011 15:55:13 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_KbBuchungID] ON [dbo].[KbBuchungKostenart] 
(
    [KbBuchungID] ASC
)
INCLUDE ( [BgPositionID],
[BgKostenartID],
[BaPersonID],
[Buchungstext],
[Betrag],
[PositionImBeleg],
[VerwPeriodeVon],
[VerwPeriodeBis],
[KontoNr]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KbBuchungKostenart_KontoNr]    Script Date: 11/23/2011 15:55:13 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungKostenart_KontoNr] ON [dbo].[KbBuchungKostenart] 
(
    [KontoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_BaPerson]
GO
ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO
ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_BgPosition]
GO
ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_KbBuchung] FOREIGN KEY([KbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_KbBuchung]
GO
ALTER TABLE [dbo].[KbBuchungKostenart]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenart_KbKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO
ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [FK_KbBuchungKostenart_KbKostenart]
GO

ALTER TABLE [dbo].[KbBuchungKostenart]  WITH NOCHECK ADD  CONSTRAINT [CK_KbBuchungKostenart_VerwPeriodeVon_VerwPeriodeBis] CHECK  (([VerwPeriodeVon]<=[VerwPeriodeBis]))
GO

ALTER TABLE [dbo].[KbBuchungKostenart] CHECK CONSTRAINT [CK_KbBuchungKostenart_VerwPeriodeVon_VerwPeriodeBis]
GO

/****** Object:  Trigger [dbo].[TR_KbBuchungKostenart_RowDeleted]    Script Date: 24.06.2016 13:37:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--KbBuchungKostenart
CREATE TRIGGER [dbo].[TR_KbBuchungKostenart_RowDeleted]
       ON [dbo].[KbBuchungKostenart]
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
    'TR_KbBuchungKostenart_RowDeleted', -- Source - varchar(255)
    0, -- SourceKey - int
    0, -- XLogLevelCode - int
    'In Tabelle KbBuchungKostenart wurde folgender Datensatz gelöscht: KbBuchungID = ' + CONVERT(VARCHAR(50), KbBuchungID) + ', KbBuchungKostenartID = '  + CONVERT(VARCHAR(50), KbBuchungKostenartID)  + ', BgPositionID = ' + ISNULL(CONVERT(VARCHAR(50), BgPositionID), 'NULL')  + '.', -- Message - varchar(max)
    'Datensatz durch Trigger TR_KbBuchungKostenart_RowDeleted erstellt', -- Comment - varchar(max)
    'KbBuchungKostenart', -- ReferenceTable - varchar(100)
    KbBuchungKostenartID, -- ReferenceID - int
    0, -- NonPurgeable - bit
    @Creator, -- Creator - varchar(50)
    GETDATE(), -- Created - datetime
    @Creator, -- Modifier - varchar(50)
    GETDATE() -- Modified - datetime
  FROM DELETED
END

GO

ALTER TABLE [dbo].[KbBuchungKostenart] ENABLE TRIGGER [TR_KbBuchungKostenart_RowDeleted]
GO

