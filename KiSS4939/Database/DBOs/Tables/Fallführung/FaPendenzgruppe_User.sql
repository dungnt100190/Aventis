CREATE TABLE [dbo].[FaPendenzgruppe_User] (
	[FaPendenzgruppe_UserID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaPendenzgruppeID] [int] NOT NULL ,
	[UserID] [int] NOT NULL ,
	[FaPendenzgruppe_UserTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaTaskGroup_XUser] PRIMARY KEY  Clustered
	(
		[FaPendenzgruppe_UserID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_FaPendenzgruppe_XUser_FaPendenzgruppe] FOREIGN KEY
	(
		[FaPendenzgruppeID]
	) REFERENCES [dbo].[FaPendenzgruppe] (
		[FaPendenzgruppeID]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_FaPendenzgruppe_XUser_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	) ON DELETE CASCADE
) ON [PRIMARY]
GO
 CREATE  INDEX [IX_FaTaskGroup_User_FaPendenzgruppeID] ON [dbo].[FaPendenzgruppe_User]([FaPendenzgruppeID], [UserID]) ON [PRIMARY]
GO
 CREATE  INDEX [IX_FaTaskGroup_User] ON [dbo].[FaPendenzgruppe_User]([UserID], [FaPendenzgruppeID]) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FaPendenzgruppe_User Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FaPendenzgruppe_User', N'column', N'FaPendenzgruppe_UserID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaPendenzgruppe_XUser_FaPendenzgruppe) => FaPendenzgruppe.FaPendenzgruppeID', N'user', N'dbo', N'table', N'FaPendenzgruppe_User', N'column', N'FaPendenzgruppeID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaPendenzgruppe_XUser_XUser) => XUser.UserID', N'user', N'dbo', N'table', N'FaPendenzgruppe_User', N'column', N'UserID'
GO

GO

GO

GO

GO
