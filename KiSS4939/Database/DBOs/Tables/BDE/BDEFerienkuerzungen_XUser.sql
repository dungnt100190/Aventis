CREATE TABLE [dbo].[BDEFerienkuerzungen_XUser](
	[UserID] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[FerienkuerzungStd] [money] NOT NULL,
	[ManualEdit] [bit] NOT NULL CONSTRAINT [DF_BDEFerienkuerzungen_XUser_ManualEdit]  DEFAULT ((0)),
	[BDEFerienkuerzungen_XUserTS] [timestamp] NOT NULL,
	[VerID] [int] NULL,
 CONSTRAINT [PK_BDEFerienkuerzungen_XUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[Jahr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Trigger [dbo].[trHist_BDEFerienkuerzungen_XUser]    Script Date: 03/16/2010 08:44:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trHist_BDEFerienkuerzungen_XUser]
  ON [dbo].[BDEFerienkuerzungen_XUser]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON

  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [BDEFerienkuerzungen_XUser] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [UserID] int NOT NULL,
  [Jahr] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [UserID], [Jahr])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[UserID], DEL.[UserID]), IsNull(INS.[Jahr], DEL.[Jahr]), TBL.VerID,
      CASE WHEN (INS.[UserID] IS NULL AND INS.[Jahr] IS NULL) THEN 3 WHEN (DEL.[UserID] IS NULL AND DEL.[Jahr] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[UserID] = INS.[UserID] AND DEL.[Jahr] = INS.[Jahr]
      LEFT       JOIN [Hist_BDEFerienkuerzungen_XUser]  TBL ON TBL.[UserID] = DEL.[UserID] AND TBL.[Jahr] = DEL.[Jahr] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[UserID] IS NULL AND INS.[Jahr] IS NULL) OR (DEL.[UserID] IS NULL AND DEL.[Jahr] IS NULL)
      OR CHECKSUM(INS.[UserID], INS.[Jahr], INS.[FerienkuerzungStd], INS.[ManualEdit])
      <> CHECKSUM(TBL.[UserID], TBL.[Jahr], TBL.[FerienkuerzungStd], TBL.[ManualEdit])



  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_BDEFerienkuerzungen_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[UserID] = TBL.[UserID] AND UPD.[Jahr] = TBL.[Jahr]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_BDEFerienkuerzungen_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[UserID] = TBL.[UserID] AND UPD.[Jahr] = TBL.[Jahr] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_BDEFerienkuerzungen_XUser ([UserID], [Jahr], [FerienkuerzungStd], [ManualEdit], VerID)
      SELECT TBL.[UserID], TBL.[Jahr], TBL.[FerienkuerzungStd], TBL.[ManualEdit], @VerID
      FROM [BDEFerienkuerzungen_XUser]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[UserID] = TBL.[UserID] AND UPD.[Jahr] = TBL.[Jahr]

    UPDATE TBL
      SET VerID = @VerID
    FROM [BDEFerienkuerzungen_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[UserID] = TBL.[UserID] AND UPD.[Jahr] = TBL.[Jahr]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END

  SET NOCOUNT OFF
END

GO
ALTER TABLE [dbo].[BDEFerienkuerzungen_XUser]  WITH CHECK ADD  CONSTRAINT [FK_BDEFerienkuerzungen_XUser_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[BDEFerienkuerzungen_XUser] CHECK CONSTRAINT [FK_BDEFerienkuerzungen_XUser_XUser]