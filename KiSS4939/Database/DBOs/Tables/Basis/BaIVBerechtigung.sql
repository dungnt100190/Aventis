CREATE TABLE [dbo].[BaIVBerechtigung](
	[BaIVBerechtigungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[BaIVBerechtigungCode] [int] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_BaIVBerechtigung_Created]  DEFAULT (getdate()),
	[VerID] [int] NULL,
	[BaIVBerechtigungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaIVBerechtigung] PRIMARY KEY CLUSTERED 
(
	[BaIVBerechtigungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BaIVBerechtigung_BaPersonID]    Script Date: 03/15/2010 15:41:04 ******/
CREATE NONCLUSTERED INDEX [IX_BaIVBerechtigung_BaPersonID] ON [dbo].[BaIVBerechtigung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaIVBerechtigung_BaPersonID_DatumVon]    Script Date: 03/15/2010 15:41:04 ******/
CREATE NONCLUSTERED INDEX [IX_BaIVBerechtigung_BaPersonID_DatumVon] ON [dbo].[BaIVBerechtigung] 
(
	[BaPersonID] ASC,
	[DatumVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaIVBerechtigung_BaPersonIDDatumVonBisBaIVBerechtigung]    Script Date: 03/15/2010 15:41:04 ******/
CREATE NONCLUSTERED INDEX [IX_BaIVBerechtigung_BaPersonIDDatumVonBisBaIVBerechtigung] ON [dbo].[BaIVBerechtigung] 
(
	[BaPersonID] ASC,
	[DatumVon] ASC,
	[DatumBis] ASC,
	[BaIVBerechtigungCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Trigger [dbo].[trHist_BaIVBerechtigung]    Script Date: 03/15/2010 15:41:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trHist_BaIVBerechtigung]
  ON [dbo].[BaIVBerechtigung]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON
  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [BaIVBerechtigung] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [BaIVBerechtigungID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [BaIVBerechtigungID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[BaIVBerechtigungID], DEL.[BaIVBerechtigungID]), TBL.VerID,
      CASE WHEN (INS.[BaIVBerechtigungID] IS NULL) THEN 3 WHEN (DEL.[BaIVBerechtigungID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[BaIVBerechtigungID] = INS.[BaIVBerechtigungID]
      LEFT       JOIN [Hist_BaIVBerechtigung]  TBL ON TBL.[BaIVBerechtigungID] = DEL.[BaIVBerechtigungID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[BaIVBerechtigungID] IS NULL) OR (DEL.[BaIVBerechtigungID] IS NULL)
      OR CHECKSUM(INS.[BaIVBerechtigungID], INS.[BaPersonID], INS.[DatumVon], INS.[DatumBis], INS.[BaIVBerechtigungCode], INS.[Bemerkungen], INS.[Creator], INS.[Created])
      <> CHECKSUM(TBL.[BaIVBerechtigungID], TBL.[BaPersonID], TBL.[DatumVon], TBL.[DatumBis], TBL.[BaIVBerechtigungCode], TBL.[Bemerkungen], TBL.[Creator], TBL.[Created])



  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_BaIVBerechtigung]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[BaIVBerechtigungID] = TBL.[BaIVBerechtigungID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_BaIVBerechtigung]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[BaIVBerechtigungID] = TBL.[BaIVBerechtigungID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_BaIVBerechtigung ([BaIVBerechtigungID], [BaPersonID], [DatumVon], [DatumBis], [BaIVBerechtigungCode], [Bemerkungen], [Creator], [Created], VerID)
      SELECT TBL.[BaIVBerechtigungID], TBL.[BaPersonID], TBL.[DatumVon], TBL.[DatumBis], TBL.[BaIVBerechtigungCode], TBL.[Bemerkungen], TBL.[Creator], TBL.[Created], @VerID
      FROM [BaIVBerechtigung]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BaIVBerechtigungID] = TBL.[BaIVBerechtigungID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [BaIVBerechtigung]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BaIVBerechtigungID] = TBL.[BaIVBerechtigungID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END
  SET NOCOUNT OFF
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'BaIVBerechtigungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaPerson, je Person gibt es 0..n Einträge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Startdatum eines Eintrages (ohne Zeit)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enddatum eines Eintrages (ohne Zeit)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code in der Werteliste BaIVBerechtigung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'BaIVBerechtigungCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zum erfassten Eintrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VersionID der Historisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'VerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaIVBerechtigung', @level2type=N'COLUMN',@level2name=N'BaIVBerechtigungTS'
GO
ALTER TABLE [dbo].[BaIVBerechtigung]  WITH CHECK ADD  CONSTRAINT [FK_BaIVBerechtigung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaIVBerechtigung] CHECK CONSTRAINT [FK_BaIVBerechtigung_BaPerson]