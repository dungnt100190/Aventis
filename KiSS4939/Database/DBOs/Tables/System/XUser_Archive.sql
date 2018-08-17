CREATE TABLE [dbo].[XUser_Archive] (
	[UserID] [int] NOT NULL ,
	[ArchiveID] [int] NOT NULL ,
	[XUser_ArchiveTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XUser_Archive] PRIMARY KEY  Clustered
	(
		[UserID],
		[ArchiveID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_XUser_Archive_XArchive] FOREIGN KEY
	(
		[ArchiveID]
	) REFERENCES [dbo].[XArchive] (
		[ArchiveID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_XUser_Archive_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für XUser_Archive Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XUser_Archive', N'column', N'UserID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für XUser_Archive Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XUser_Archive', N'column', N'ArchiveID'
GO

GO

GO

GO

GO
