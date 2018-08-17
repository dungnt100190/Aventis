CREATE TABLE [dbo].[XUserGroup_Right](
  [UserGroup_RightID] [int] IDENTITY(1,1) NOT NULL,
  [UserGroupID] [int] NOT NULL,
  [RightID] [int] NULL,
  [XClassID] [int] NULL,
  [ClassName] [varchar](255) NULL,
  [QueryName] [varchar](100) NULL,
  [MaskName] [varchar](100) NULL,
  [MayInsert] [bit] NOT NULL,
  [MayUpdate] [bit] NOT NULL,
  [MayDelete] [bit] NOT NULL,
  [XUserGroup_RightTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUserGroup_Right] PRIMARY KEY NONCLUSTERED 
(
  [UserGroup_RightID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE CLUSTERED INDEX [IX_XUserGroup_Right] ON [dbo].[XUserGroup_Right] 
(
  [UserGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_XUserGroup_Right_XClassID] ON [dbo].[XUserGroup_Right] 
(
  [XClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_XUserGroup_Right_ClassName] ON [dbo].[XUserGroup_Right] 
(
  [ClassName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_XUserGroup_Right_QueryName] ON [dbo].[XUserGroup_Right] 
(
  [QueryName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_XUserGroup_Right_MaskName] ON [dbo].[XUserGroup_Right] 
(
  [MaskName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XUserGroup_Right Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup_Right', @level2type=N'COLUMN',@level2name=N'UserGroup_RightID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XUserGroup_Right_XUserGroup) => XUserGroup.UserGroupID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup_Right', @level2type=N'COLUMN',@level2name=N'UserGroupID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XUserGroup_Right_XClass) => XClass.XClassID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup_Right', @level2type=N'COLUMN',@level2name=N'XClassID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XUserGroup_Right_XRight) => XRight.RightID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup_Right', @level2type=N'COLUMN',@level2name=N'RightID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XUserGroup_Right_DynaMask) => DynaMask.MaskName' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup_Right', @level2type=N'COLUMN',@level2name=N'MaskName'
GO

ALTER TABLE [dbo].[XUserGroup_Right]  WITH CHECK ADD  CONSTRAINT [FK_XUserGroup_Right_DynaMask] FOREIGN KEY([MaskName])
REFERENCES [dbo].[DynaMask] ([MaskName])
GO

ALTER TABLE [dbo].[XUserGroup_Right] CHECK CONSTRAINT [FK_XUserGroup_Right_DynaMask]
GO

ALTER TABLE [dbo].[XUserGroup_Right]  WITH CHECK ADD  CONSTRAINT [FK_XUserGroup_Right_XClass] FOREIGN KEY([XClassID])
REFERENCES [dbo].[XClass] ([XClassID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XUserGroup_Right] CHECK CONSTRAINT [FK_XUserGroup_Right_XClass]
GO

ALTER TABLE [dbo].[XUserGroup_Right]  WITH CHECK ADD  CONSTRAINT [FK_XUserGroup_Right_ClassName] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[XUserGroup_Right] CHECK CONSTRAINT [FK_XUserGroup_Right_ClassName]
GO

ALTER TABLE [dbo].[XUserGroup_Right]  WITH CHECK ADD  CONSTRAINT [FK_XUserGroup_Right_XQuery] FOREIGN KEY([QueryName])
REFERENCES [dbo].[XQuery] ([QueryName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XUserGroup_Right] CHECK CONSTRAINT [FK_XUserGroup_Right_XQuery]
GO

ALTER TABLE [dbo].[XUserGroup_Right]  WITH CHECK ADD  CONSTRAINT [FK_XUserGroup_Right_XRight] FOREIGN KEY([RightID])
REFERENCES [dbo].[XRight] ([RightID])
GO

ALTER TABLE [dbo].[XUserGroup_Right] CHECK CONSTRAINT [FK_XUserGroup_Right_XRight]
GO

ALTER TABLE [dbo].[XUserGroup_Right]  WITH CHECK ADD  CONSTRAINT [FK_XUserGroup_Right_XUserGroup] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[XUserGroup] ([UserGroupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XUserGroup_Right] CHECK CONSTRAINT [FK_XUserGroup_Right_XUserGroup]
GO

ALTER TABLE [dbo].[XUserGroup_Right] ADD  CONSTRAINT [DF_XUserGroup_Right_MayInsert]  DEFAULT ((0)) FOR [MayInsert]
GO

ALTER TABLE [dbo].[XUserGroup_Right] ADD  CONSTRAINT [DF_XUserGroup_Right_MayUpdate]  DEFAULT ((0)) FOR [MayUpdate]
GO

ALTER TABLE [dbo].[XUserGroup_Right] ADD  CONSTRAINT [DF_XUserGroup_Right_MayDelete]  DEFAULT ((0)) FOR [MayDelete]
GO