CREATE TABLE [dbo].[XUser_UserGroup](
  [XUser_UserGroupID] [int] IDENTITY(1,1) NOT NULL,
  [UserID] [int] NOT NULL,
  [UserGroupID] [int] NOT NULL,
  [XUser_UserGroupTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUser_UserGroup] PRIMARY KEY CLUSTERED 
(
  [XUser_UserGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XUser_UserGroup_UserID_UserGroupID] UNIQUE NONCLUSTERED 
(
  [UserID] ASC,
  [UserGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Index [IX_XUser_UserGroup_UserGroupID]    Script Date: 10/29/2013 12:53:13 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_UserGroup_UserGroupID] ON [dbo].[XUser_UserGroup] 
(
  [UserGroupID] ASC,
  [UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XUser_UserGroup Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_UserGroup', @level2type=N'COLUMN',@level2name=N'XUser_UserGroupID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XUser_UserGroup_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_UserGroup', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XUser_UserGroup_XUserGroup) => XUserGroup.UserGroupID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_UserGroup', @level2type=N'COLUMN',@level2name=N'UserGroupID'
GO

ALTER TABLE [dbo].[XUser_UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_XUser_UserGroup_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XUser_UserGroup] CHECK CONSTRAINT [FK_XUser_UserGroup_XUser]
GO

ALTER TABLE [dbo].[XUser_UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_XUser_UserGroup_XUserGroup] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[XUserGroup] ([UserGroupID])
GO

ALTER TABLE [dbo].[XUser_UserGroup] CHECK CONSTRAINT [FK_XUser_UserGroup_XUserGroup]
GO


