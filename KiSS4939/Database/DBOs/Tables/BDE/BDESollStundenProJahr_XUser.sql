CREATE TABLE [dbo].[BDESollStundenProJahr_XUser](
  [BDESollStundenProJahr_XUserID] [int] IDENTITY(1,1) NOT NULL,
  [UserID] [int] NOT NULL,
  [Jahr] [int] NOT NULL,
  [JanuarStd] [money] NOT NULL,
  [FebruarStd] [money] NOT NULL,
  [MaerzStd] [money] NOT NULL,
  [AprilStd] [money] NOT NULL,
  [MaiStd] [money] NOT NULL,
  [JuniStd] [money] NOT NULL,
  [JuliStd] [money] NOT NULL,
  [AugustStd] [money] NOT NULL,
  [SeptemberStd] [money] NOT NULL,
  [OktoberStd] [money] NOT NULL,
  [NovemberStd] [money] NOT NULL,
  [DezemberStd] [money] NOT NULL,
  [TotalStd] [money] NOT NULL,
  [ManualEdit] [bit] NOT NULL CONSTRAINT [DF_BDESollStundenProJahr_XUser_ManualEdit]  DEFAULT ((0)),
  [BDESollStundenProJahr_XUserTS] [timestamp] NOT NULL,
  [VerID] [int] NULL,
 CONSTRAINT [PK_BDESollStundenProJahr_XUser] PRIMARY KEY CLUSTERED 
(
  [BDESollStundenProJahr_XUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_BDESollStundenProJahr_UserID_Jahr] UNIQUE NONCLUSTERED 
(
  [UserID] ASC,
  [Jahr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IX_BDESollStundenProJahr_XUser_UserID_Jahr] ON [dbo].[BDESollStundenProJahr_XUser] 
(
  [UserID] ASC,
  [Jahr] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Trigger [dbo].[trHist_BDESollStundenProJahr_XUser]    Script Date: 03/16/2010 08:46:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trHist_BDESollStundenProJahr_XUser]
  ON [dbo].[BDESollStundenProJahr_XUser]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON

  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [BDESollStundenProJahr_XUser] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [BDESollStundenProJahr_XUserID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [BDESollStundenProJahr_XUserID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[BDESollStundenProJahr_XUserID], DEL.[BDESollStundenProJahr_XUserID]), TBL.VerID,
      CASE WHEN (INS.[BDESollStundenProJahr_XUserID] IS NULL) THEN 3 WHEN (DEL.[BDESollStundenProJahr_XUserID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[BDESollStundenProJahr_XUserID] = INS.[BDESollStundenProJahr_XUserID]
      LEFT       JOIN [Hist_BDESollStundenProJahr_XUser]  TBL ON TBL.[BDESollStundenProJahr_XUserID] = DEL.[BDESollStundenProJahr_XUserID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[BDESollStundenProJahr_XUserID] IS NULL) OR (DEL.[BDESollStundenProJahr_XUserID] IS NULL)
      OR CHECKSUM(INS.[BDESollStundenProJahr_XUserID], INS.[UserID], INS.[Jahr], INS.[JanuarStd], INS.[FebruarStd], INS.[MaerzStd], INS.[AprilStd], INS.[MaiStd], INS.[JuniStd], INS.[JuliStd], INS.[AugustStd], INS.[SeptemberStd], INS.[OktoberStd], INS.[NovemberStd], INS.[DezemberStd], INS.[TotalStd], INS.[ManualEdit])
      <> CHECKSUM(TBL.[BDESollStundenProJahr_XUserID], TBL.[UserID], TBL.[Jahr], TBL.[JanuarStd], TBL.[FebruarStd], TBL.[MaerzStd], TBL.[AprilStd], TBL.[MaiStd], TBL.[JuniStd], TBL.[JuliStd], TBL.[AugustStd], TBL.[SeptemberStd], TBL.[OktoberStd], TBL.[NovemberStd], TBL.[DezemberStd], TBL.[TotalStd], TBL.[ManualEdit])



  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_BDESollStundenProJahr_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[BDESollStundenProJahr_XUserID] = TBL.[BDESollStundenProJahr_XUserID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_BDESollStundenProJahr_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[BDESollStundenProJahr_XUserID] = TBL.[BDESollStundenProJahr_XUserID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_BDESollStundenProJahr_XUser ([BDESollStundenProJahr_XUserID], [UserID], [Jahr], [JanuarStd], [FebruarStd], [MaerzStd], [AprilStd], [MaiStd], [JuniStd], [JuliStd], [AugustStd], [SeptemberStd], [OktoberStd], [NovemberStd], [DezemberStd], [TotalStd], [ManualEdit], VerID)
      SELECT TBL.[BDESollStundenProJahr_XUserID], TBL.[UserID], TBL.[Jahr], TBL.[JanuarStd], TBL.[FebruarStd], TBL.[MaerzStd], TBL.[AprilStd], TBL.[MaiStd], TBL.[JuniStd], TBL.[JuliStd], TBL.[AugustStd], TBL.[SeptemberStd], TBL.[OktoberStd], TBL.[NovemberStd], TBL.[DezemberStd], TBL.[TotalStd], TBL.[ManualEdit], @VerID
      FROM [BDESollStundenProJahr_XUser]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BDESollStundenProJahr_XUserID] = TBL.[BDESollStundenProJahr_XUserID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [BDESollStundenProJahr_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BDESollStundenProJahr_XUserID] = TBL.[BDESollStundenProJahr_XUserID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END

  SET NOCOUNT OFF
END

GO
ALTER TABLE [dbo].[BDESollStundenProJahr_XUser]  WITH CHECK ADD  CONSTRAINT [FK_BDESollStundenProJahr_XUser_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[BDESollStundenProJahr_XUser] CHECK CONSTRAINT [FK_BDESollStundenProJahr_XUser_XUser]
