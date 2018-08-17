CREATE TABLE [dbo].[FbTeam] (
	[FbTeamID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) NOT NULL ,
	[FbTeamTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbTeam] PRIMARY KEY  Clustered
	(
		[FbTeamID]
	)  ON [DATEN1]
) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbTeam Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbTeam', N'column', N'FbTeamID'
GO

GO

GO

GO

GO

GO

GO

GO
