CREATE TABLE [dbo].[XMessage] (
	[MaskName] [varchar] (100) NOT NULL ,
	[MessageName] [varchar] (100) NOT NULL ,
	[MessageTID] [int] NULL ,
	[MessageCode] [int] NULL ,
	[Context] [varchar] (100) NULL ,
	[XMessageTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XMessage] PRIMARY KEY  Clustered
	(
		[MaskName],
		[MessageName]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XMessage Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XMessage', N'column', N'MaskName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XMessage Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XMessage', N'column', N'MessageName'
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
