CREATE TABLE [dbo].[KbPeriode_User] (
	[KbPeriodeID] [int] NOT NULL ,
	[UserID] [int] NOT NULL ,
	[KbPeriode_UserTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbPeriode_User] PRIMARY KEY  Clustered
	(
		[KbPeriodeID],
		[UserID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_KbPeriode_User_KbPeriode] FOREIGN KEY
	(
		[KbPeriodeID]
	) REFERENCES [dbo].[KbPeriode] (
		[KbPeriodeID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_KbPeriode_User_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbPeriode_User Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbPeriode_User', N'column', N'KbPeriodeID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbPeriode_User Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbPeriode_User', N'column', N'UserID'
GO

GO

GO

GO

GO
