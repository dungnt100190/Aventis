CREATE TABLE [dbo].[BaBeruf] (
	[BaBerufID] [int] NOT NULL ,
	[Beruf] [varchar] (200) NOT NULL ,
	[BezeichnungM] [varchar] (200) NULL ,
	[BezeichnungW] [varchar] (200) NULL ,
	[SortKey] [int] NOT NULL ,
	[BFSCode] [int] NOT NULL ,
	[BaBerufTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BaBeruf] PRIMARY KEY  Clustered
	(
		[BaBerufID]
	)  ON [DATEN2]
) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für BaBeruf Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'BaBeruf', N'column', N'BaBerufID'
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

GO

GO

GO

GO

GO

GO

GO

GO

GO
