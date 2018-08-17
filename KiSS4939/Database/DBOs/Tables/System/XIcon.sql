CREATE TABLE [dbo].[XIcon] (
	[XIconID] [int] NOT NULL ,
	[Name] [varchar] (100) NOT NULL ,
	[Icon] [image] NULL ,
	[XIconTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XICON] PRIMARY KEY  Clustered
	(
		[XIconID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XIcon Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XIcon', N'column', N'XIconID'
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
