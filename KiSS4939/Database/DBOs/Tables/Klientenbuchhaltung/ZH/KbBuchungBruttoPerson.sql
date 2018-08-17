CREATE TABLE [dbo].[KbBuchungBruttoPerson](
    [KbBuchungBruttoPersonID] [int] IDENTITY(1,1) NOT NULL,
    [KbBuchungBruttoID] [int] NOT NULL,
    [BgPositionID] [int] NULL,
    [BaPersonID] [int] NOT NULL,
    [Schuldner_BaInstitutionID] [int] NULL,
    [Schuldner_BaPersonID] [int] NULL,
    [Buchungstext] [varchar](200) NULL,
    [Betrag] [money] NOT NULL,
    [VerwPeriodeVon] [datetime] NULL,
    [VerwPeriodeBis] [datetime] NULL,
    [PositionImBeleg] [int] NULL,
    [SpezBgKostenartID] [int] NULL,
    [SpezHauptvorgang] [int] NULL,
    [SpezTeilvorgang] [int] NULL,
    [GesperrtFuerWV] [bit] NOT NULL,
    [KbBuchungBruttoPersonTS] [timestamp] NOT NULL,
    [Zinsperiode] [int] NULL,
 CONSTRAINT [PK_KbBuchungBruttoPerson] PRIMARY KEY CLUSTERED 
(
    [KbBuchungBruttoPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KbBuchungBruttoPerson_BaPersonID] ON [dbo].[KbBuchungBruttoPerson] 
(
    [BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_KbBuchungBruttoPerson_BgPositionID] ON [dbo].[KbBuchungBruttoPerson] 
(
    [BgPositionID] ASC
)
INCLUDE ( [KbBuchungBruttoID],
[PositionImBeleg]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_KbBuchungBruttoPerson_KbBuchungBruttoID] ON [dbo].[KbBuchungBruttoPerson] 
(
    [KbBuchungBruttoID] ASC
)
INCLUDE ( [BgPositionID],
[BaPersonID],
[Buchungstext],
[Betrag],
[VerwPeriodeVon],
[VerwPeriodeBis],
[PositionImBeleg],
[SpezBgKostenartID],
[Zinsperiode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_KbBuchungBruttoPerson_Schuldner_BaInstitutionID] ON [dbo].[KbBuchungBruttoPerson] 
(
    [Schuldner_BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_KbBuchungBruttoPerson_Schuldner_BaPersonID] ON [dbo].[KbBuchungBruttoPerson] 
(
    [Schuldner_BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_KbBuchungBruttoPerson_SpezBgKostenartID] ON [dbo].[KbBuchungBruttoPerson] 
(
    [SpezBgKostenartID] ASC
)
INCLUDE ( [KbBuchungBruttoPersonID],
[KbBuchungBruttoID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBruttoPerson_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] CHECK CONSTRAINT [FK_KbBuchungBruttoPerson_BgPosition]
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungBruttoPerson_KbBuchungBrutto] FOREIGN KEY([KbBuchungBruttoID])
REFERENCES [dbo].[KbBuchungBrutto] ([KbBuchungBruttoID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] CHECK CONSTRAINT [FK_KbBuchungBruttoPerson_KbBuchungBrutto]
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenartBrutto_BaInstitution] FOREIGN KEY([Schuldner_BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] CHECK CONSTRAINT [FK_KbBuchungKostenartBrutto_BaInstitution]
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenartBrutto_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] CHECK CONSTRAINT [FK_KbBuchungKostenartBrutto_BaPerson]
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungKostenartBrutto_BaPerson1] FOREIGN KEY([Schuldner_BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] CHECK CONSTRAINT [FK_KbBuchungKostenartBrutto_BaPerson1]
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson]  WITH CHECK ADD  CONSTRAINT [CK_KbBuchungBruttoPerson_VerwPeriodeVon_VerwPeriodeBis] CHECK (([VerwPeriodeVon]<=[VerwPeriodeBis]))
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] CHECK CONSTRAINT [CK_KbBuchungBruttoPerson_VerwPeriodeVon_VerwPeriodeBis]
GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] ADD  CONSTRAINT [DF_KbBuchungBruttoPerson_GesperrtFuerWV]  DEFAULT ((0)) FOR [GesperrtFuerWV]
GO

/****** Object:  Trigger [dbo].[TR_KbBuchungBruttoPerson_RowDeleted]    Script Date: 24.06.2016 13:40:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--KbBuchungBruttoPerson
CREATE TRIGGER [dbo].[TR_KbBuchungBruttoPerson_RowDeleted]
       ON [dbo].[KbBuchungBruttoPerson]
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
    'TR_KbBuchungBruttoPerson_RowDeleted', -- Source - varchar(255)
    0, -- SourceKey - int
    0, -- XLogLevelCode - int
    'In Tabelle KbBuchungBruttoPerson wurde folgender Datensatz gelöscht: KbBuchungBruttoPersonID = ' + CONVERT(VARCHAR(50), KbBuchungBruttoPersonID) + ', KbBuchungBruttoID = ' + CONVERT(VARCHAR(50), KbBuchungBruttoID)  + ', BgPositionID = '  + ISNULL(CONVERT(VARCHAR(50),BgPositionID), 'NULL')  +  '.', -- Message - varchar(max)
    'Datensatz durch Trigger TR_KbBuchungBruttoPerson_RowDeleted erstellt', -- Comment - varchar(max)
    'KbBuchungBruttoPerson', -- ReferenceTable - varchar(100)
    KbBuchungBruttoPersonID, -- ReferenceID - int
    0, -- NonPurgeable - bit
    @Creator, -- Creator - varchar(50)
    GETDATE(), -- Created - datetime
    @Creator, -- Modifier - varchar(50)
    GETDATE() -- Modified - datetime
  FROM DELETED 
END

GO

ALTER TABLE [dbo].[KbBuchungBruttoPerson] ENABLE TRIGGER [TR_KbBuchungBruttoPerson_RowDeleted]
GO
