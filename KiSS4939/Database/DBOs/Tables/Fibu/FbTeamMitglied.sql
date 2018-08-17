CREATE TABLE [dbo].[FbTeamMitglied] (
	[FbTeamID] [int] NOT NULL ,
	[UserID] [int] NOT NULL ,
	[StandardBereich] [bit] NOT NULL CONSTRAINT [DF_FbTeamMitglied_StandardBereich] DEFAULT (1),
	[DepotBereich] [bit] NOT NULL CONSTRAINT [DF_FbTeamMitglied_DepotBereich] DEFAULT (0),
	[FbTeamMitgliedTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbTeamMitglied] PRIMARY KEY  Clustered
	(
		[FbTeamID],
		[UserID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_FbTeamMitglied_FbTeam] FOREIGN KEY
	(
		[FbTeamID]
	) REFERENCES [dbo].[FbTeam] (
		[FbTeamID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_FbTeamMitglied_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbTeamMitglied Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbTeamMitglied', N'column', N'FbTeamID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbTeamMitglied Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbTeamMitglied', N'column', N'UserID'
GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO
