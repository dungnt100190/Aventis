CREATE TABLE [dbo].[BFSLOV] (
	[LOVName] [varchar] (100) NOT NULL ,
	[BFSLOVTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BFSLOV] PRIMARY KEY  Clustered
	(
		[LOVName]
	)  ON [DATEN3]
) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für BFSLOV Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'BFSLOV', N'column', N'LOVName'
GO

GO

GO

GO

GO
