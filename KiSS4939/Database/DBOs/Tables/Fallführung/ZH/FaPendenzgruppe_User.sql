CREATE TABLE [dbo].[FaPendenzgruppe_User](
	[FaPendenzgruppe_UserID] [int] IDENTITY(1,1) NOT NULL,
	[FaPendenzgruppeID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[FaPendenzgruppe_UserTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaPendenzgruppe_User] PRIMARY KEY CLUSTERED 
(
	[FaPendenzgruppe_UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_FaPendenzgruppe_User_FaPendenzengruppeID]    Script Date: 11/23/2011 15:02:21 ******/
CREATE NONCLUSTERED INDEX [IX_FaPendenzgruppe_User_FaPendenzengruppeID] ON [dbo].[FaPendenzgruppe_User] 
(
	[FaPendenzgruppeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaPendenzgruppe_User_UserID]    Script Date: 11/23/2011 15:02:21 ******/
CREATE NONCLUSTERED INDEX [IX_FaPendenzgruppe_User_UserID] ON [dbo].[FaPendenzgruppe_User] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaPendenzgruppe_User]  WITH CHECK ADD  CONSTRAINT [FK_FaPendenzgruppe_XUser_FaPendenzgruppe] FOREIGN KEY([FaPendenzgruppeID])
REFERENCES [dbo].[FaPendenzgruppe] ([FaPendenzgruppeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaPendenzgruppe_User] CHECK CONSTRAINT [FK_FaPendenzgruppe_XUser_FaPendenzgruppe]
GO
ALTER TABLE [dbo].[FaPendenzgruppe_User]  WITH CHECK ADD  CONSTRAINT [FK_FaPendenzgruppe_XUser_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaPendenzgruppe_User] CHECK CONSTRAINT [FK_FaPendenzgruppe_XUser_XUser]