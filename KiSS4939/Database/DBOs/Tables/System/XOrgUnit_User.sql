CREATE TABLE [dbo].[XOrgUnit_User](
  [XOrgUnit_UserID] [int] IDENTITY(1,1) NOT NULL,
	[OrgUnitID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[OrgUnitMemberCode] [int] NOT NULL,
	[MayInsert] [bit] NOT NULL,
	[MayUpdate] [bit] NOT NULL,
	[MayDelete] [bit] NOT NULL,
	[VerID] [int] NULL,
  [XOrgUnit_UserTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XOrgUnit_User] PRIMARY KEY CLUSTERED 
(
	[XOrgUnit_UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XOrgUnit_User_OrgUnitID_UserID] UNIQUE NONCLUSTERED 
(
  [OrgUnitID] ASC,
  [UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_User_OrgUnitID_OrgUnitMemberCode] ON [dbo].[XOrgUnit_User] 
(
	[OrgUnitID] ASC,
	[OrgUnitMemberCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [SYSTEM]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_User_OrgUnitID_UserID_OrgUnitMemberCode] ON [dbo].[XOrgUnit_User] 
(
	[OrgUnitID] ASC,
	[UserID] ASC,
	[OrgUnitMemberCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [SYSTEM]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_User_OrgUnitMemberCode] ON [dbo].[XOrgUnit_User] 
(
	[OrgUnitMemberCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [SYSTEM]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_User_UserID_OrgUnitMemberCode] ON [dbo].[XOrgUnit_User] 
(
	[UserID] ASC,
	[OrgUnitMemberCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [SYSTEM]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XOrgUnit_User Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_User', @level2type=N'COLUMN',@level2name=N'XOrgUnit_UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XOrgUnit_User_XOrgUnit) => XOrgUnit.OrgUnitID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_User', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XOrgUnit_User_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit_User', @level2type=N'COLUMN',@level2name=N'UserID'
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trHist_XOrgUnit_User]
  ON [dbo].[XOrgUnit_User]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON

  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [XOrgUnit_User] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [XOrgUnit_UserID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [XOrgUnit_UserID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[XOrgUnit_UserID], DEL.[XOrgUnit_UserID]), TBL.VerID,
      CASE WHEN (INS.[XOrgUnit_UserID] IS NULL) THEN 3 WHEN (DEL.[XOrgUnit_UserID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[XOrgUnit_UserID] = INS.[XOrgUnit_UserID]
      LEFT       JOIN [Hist_XOrgUnit_User]  TBL ON TBL.[XOrgUnit_UserID] = DEL.[XOrgUnit_UserID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[XOrgUnit_UserID] IS NULL) OR (DEL.[XOrgUnit_UserID] IS NULL)
      OR CHECKSUM(INS.[XOrgUnit_UserID], INS.[OrgUnitID], INS.[UserID], INS.[OrgUnitMemberCode], INS.[MayInsert], INS.[MayUpdate], INS.[MayDelete])
      <> CHECKSUM(TBL.[XOrgUnit_UserID], TBL.[OrgUnitID], TBL.[UserID], TBL.[OrgUnitMemberCode], TBL.[MayInsert], TBL.[MayUpdate], TBL.[MayDelete])



  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_XOrgUnit_User]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[XOrgUnit_UserID] = TBL.[XOrgUnit_UserID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_XOrgUnit_User]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[XOrgUnit_UserID] = TBL.[XOrgUnit_UserID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_XOrgUnit_User ([XOrgUnit_UserID], [OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete], VerID)
      SELECT TBL.[XOrgUnit_UserID], TBL.[OrgUnitID], TBL.[UserID], TBL.[OrgUnitMemberCode], TBL.[MayInsert], TBL.[MayUpdate], TBL.[MayDelete], @VerID
      FROM [XOrgUnit_User]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[XOrgUnit_UserID] = TBL.[XOrgUnit_UserID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [XOrgUnit_User]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[XOrgUnit_UserID] = TBL.[XOrgUnit_UserID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END

  SET NOCOUNT OFF
END

GO

ALTER TABLE [dbo].[XOrgUnit_User]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_User_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[XOrgUnit_User] CHECK CONSTRAINT [FK_XOrgUnit_User_XOrgUnit]
GO

ALTER TABLE [dbo].[XOrgUnit_User]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_User_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XOrgUnit_User] CHECK CONSTRAINT [FK_XOrgUnit_User_XUser]
GO

ALTER TABLE [dbo].[XOrgUnit_User] ADD  CONSTRAINT [DF_XOrgUnit_User_MayInsert]  DEFAULT ((0)) FOR [MayInsert]
GO

ALTER TABLE [dbo].[XOrgUnit_User] ADD  CONSTRAINT [DF_XOrgUnit_User_MayUpdate]  DEFAULT ((0)) FOR [MayUpdate]
GO

ALTER TABLE [dbo].[XOrgUnit_User] ADD  CONSTRAINT [DF_XOrgUnit_User_MayDelete]  DEFAULT ((0)) FOR [MayDelete]
GO