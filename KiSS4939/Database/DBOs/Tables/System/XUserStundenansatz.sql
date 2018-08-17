CREATE TABLE [dbo].[XUserStundenansatz](
	[XUserStundenansatzID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Lohnart1] [money] NULL,
	[Lohnart2] [money] NULL,
	[Lohnart3] [money] NULL,
	[Lohnart4] [money] NULL,
	[Lohnart5] [money] NULL,
	[Lohnart6] [money] NULL,
	[Lohnart7] [money] NULL,
	[Lohnart8] [money] NULL,
	[Lohnart9] [money] NULL,
	[Lohnart10] [money] NULL,
	[Lohnart11] [money] NULL,
	[Lohnart12] [money] NULL,
	[Lohnart13] [money] NULL,
	[Lohnart14] [money] NULL,
	[Lohnart15] [money] NULL,
	[Lohnart16] [money] NULL,
	[Lohnart17] [money] NULL,
	[Lohnart18] [money] NULL,
	[Lohnart19] [money] NULL,
	[Lohnart20] [money] NULL,
	[VerID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XUserStundenansatzTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUserStundenansatz] PRIMARY KEY CLUSTERED 
(
	[XUserStundenansatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XUserStundenansatz_UserID]    Script Date: 07/12/2013 08:52:15 ******/
CREATE NONCLUSTERED INDEX [IX_XUserStundenansatz_UserID] ON [dbo].[XUserStundenansatz] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'XUserStundenansatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremschlüssel auf XUser Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 6' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart6'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 7' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart7'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 8' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart8'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 9' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart9'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 10' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart10'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 11' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart11'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 12' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart12'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 13' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart13'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 14' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart14'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 15' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart15'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 16' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart16'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 17' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart17'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 18' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart18'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 19' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart19'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stundenansatz der Lohnart 20' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Lohnart20'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verweis auf HistoryVersion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'VerID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz', @level2type=N'COLUMN',@level2name=N'XUserStundenansatzTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Stundenansätze für die Benutzer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserStundenansatz'
GO

/****** Object:  Trigger [dbo].[trHist_XUserStundenansatz]    Script Date: 07/12/2013 08:52:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[trHist_XUserStundenansatz]
  ON [dbo].[XUserStundenansatz]
  FOR INSERT, UPDATE, DELETE
AS 
BEGIN
  SET NOCOUNT ON;
  
  DECLARE @VerID INT;

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID 
    AND DATEDIFF(n, VersionDate, GETDATE()) < 60
  ORDER BY VerID DESC;

  IF (@VerID IS NULL)
  BEGIN
    RAISERROR ('Table [XUserStundenansatz] is under Version Control you must first create a new HistoryVersion entry', 16, 1);
    ROLLBACK TRANSACTION;
  END

  DECLARE @Changes TABLE 
  (
    XUserStundenansatzID INT NOT NULL,
    VerID                INT NULL,
    ActionCode           INT NOT NULL
    PRIMARY KEY (ActionCode, XUserStundenansatzID)
  );

  INSERT INTO @Changes
    SELECT 
      XUserStundenansatzID	= ISNULL(INS.XUserStundenansatzID, DEL.XUserStundenansatzID), 
	  VerID					= TBL.VerID,
      ActionCode			= CASE 
								 WHEN (INS.XUserStundenansatzID IS NULL) THEN 3 
								 WHEN (DEL.XUserStundenansatzID IS NULL) THEN 1 
								 ELSE 2 
							  END
    FROM INSERTED                             INS
      FULL OUTER JOIN DELETED                 DEL ON DEL.XUserStundenansatzID = INS.XUserStundenansatzID
      LEFT       JOIN Hist_XUserStundenansatz TBL ON TBL.XUserStundenansatzID = DEL.XUserStundenansatzID AND TBL.VerID_DELETED IS NULL
    WHERE INS.XUserStundenansatzID IS NULL
      OR  DEL.XUserStundenansatzID IS NULL
      OR  CHECKSUM(INS.XUserStundenansatzID, INS.UserID, INS.Lohnart1, INS.Lohnart2, INS.Lohnart3, INS.Lohnart4, INS.Lohnart5, INS.Lohnart6, INS.Lohnart7, INS.Lohnart8, INS.Lohnart9, INS.Lohnart10, INS.Lohnart11, INS.Lohnart12, INS.Lohnart13, INS.Lohnart14, INS.Lohnart15, INS.Lohnart16, INS.Lohnart17, INS.Lohnart18, INS.Lohnart19, INS.Lohnart20, INS.VerID, INS.Creator, INS.Created, INS.Modifier, INS.Modified)
       <> CHECKSUM(TBL.XUserStundenansatzID, TBL.UserID, TBL.Lohnart1, TBL.Lohnart2, TBL.Lohnart3, TBL.Lohnart4, TBL.Lohnart5, TBL.Lohnart6, TBL.Lohnart7, TBL.Lohnart8, TBL.Lohnart9, TBL.Lohnart10, TBL.Lohnart11, TBL.Lohnart12, TBL.Lohnart13, TBL.Lohnart14, TBL.Lohnart15, TBL.Lohnart16, TBL.Lohnart17, TBL.Lohnart18, TBL.Lohnart19, TBL.Lohnart20, TBL.VerID, TBL.Creator, TBL.Created, TBL.Modifier, TBL.Modified);    

  IF EXISTS (SELECT TOP 1 1 FROM @Changes UPD WHERE ActionCode = 2)
  BEGIN
    DELETE TBL
    FROM dbo.Hist_XUserStundenansatz TBL
      INNER JOIN @Changes            UPD ON UPD.ActionCode = 2 AND UPD.XUserStundenansatzID = TBL.XUserStundenansatzID
    WHERE TBL.VerID = @VerID;
  END;

  IF EXISTS (SELECT TOP 1 1 FROM @Changes UPD WHERE ActionCode > 1)
  BEGIN
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM dbo.Hist_XUserStundenansatz TBL
      INNER JOIN @Changes            UPD ON UPD.ActionCode > 1 AND UPD.XUserStundenansatzID = TBL.XUserStundenansatzID AND UPD.VerID = TBL.VerID;
  END

  IF EXISTS (SELECT TOP 1 1 FROM @Changes UPD WHERE ActionCode < 3) 
  BEGIN
    INSERT INTO dbo.Hist_XUserStundenansatz(XUserStundenansatzID, UserID, Lohnart1, Lohnart2, Lohnart3, Lohnart4, Lohnart5, Lohnart6, Lohnart7, Lohnart8, Lohnart9, Lohnart10, Lohnart11, Lohnart12, Lohnart13, Lohnart14, Lohnart15, Lohnart16, Lohnart17, Lohnart18, Lohnart19, Lohnart20, VerID, Creator, Created, Modifier, Modified)
      SELECT TBL.XUserStundenansatzID, TBL.UserID, TBL.Lohnart1, TBL.Lohnart2, TBL.Lohnart3, TBL.Lohnart4, TBL.Lohnart5, TBL.Lohnart6, TBL.Lohnart7, TBL.Lohnart8, TBL.Lohnart9, TBL.Lohnart10, TBL.Lohnart11, TBL.Lohnart12, TBL.Lohnart13, TBL.Lohnart14, TBL.Lohnart15, TBL.Lohnart16, TBL.Lohnart17, TBL.Lohnart18, TBL.Lohnart19, TBL.Lohnart20, @VerID, TBL.Creator, TBL.Created, TBL.Modifier, TBL.Modified
      FROM dbo.XUserStundenansatz TBL
        INNER JOIN @Changes       UPD ON UPD.ActionCode < 3 AND UPD.XUserStundenansatzID = TBL.XUserStundenansatzID;

    UPDATE TBL
      SET VerID = @VerID
    FROM dbo.XUserStundenansatz TBL
      INNER JOIN @Changes       UPD ON UPD.ActionCode < 3 AND UPD.XUserStundenansatzID = TBL.XUserStundenansatzID
    WHERE ISNULL(TBL.VerID, -1) != @VerID;
  END;
  
  SET NOCOUNT OFF;
END;


GO

ALTER TABLE [dbo].[XUserStundenansatz]  WITH CHECK ADD  CONSTRAINT [FK_XUserStundenansatz_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XUserStundenansatz] CHECK CONSTRAINT [FK_XUserStundenansatz_XUser]
GO

ALTER TABLE [dbo].[XUserStundenansatz] ADD  CONSTRAINT [DF_XUserStundenansatz_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XUserStundenansatz] ADD  CONSTRAINT [DF_XUserStundenansatz_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


