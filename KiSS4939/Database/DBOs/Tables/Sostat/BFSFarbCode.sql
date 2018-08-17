CREATE TABLE [dbo].[BFSFarbCode] (
	[BFSFarbCodeID] [int] IDENTITY (1, 1) NOT NULL ,
	[Leistungsfilter] [int] NOT NULL ,
	[ExcelFarbCode] [int] NOT NULL ,
	[BFSFrageID] [int] NOT NULL ,
	CONSTRAINT [PK_BFSFarbCode] PRIMARY KEY  Clustered
	(
		[BFSFarbCodeID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_BFSFarbCode_BFSFrage] FOREIGN KEY
	(
		[BFSFrageID]
	) REFERENCES [dbo].[BFSFrage] (
		[BFSFrageID]
	) ON DELETE CASCADE
) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Prim�rschl�ssel f�r BFSFarbCode Records (nach Prim�rschl�ssel-Standards)', N'user', N'dbo', N'table', N'BFSFarbCode', N'column', N'BFSFarbCodeID'
GO

GO

GO

GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschl�ssel (FK_BFSFarbCode_BFSFrage) => BFSFrage.BFSFrageID', N'user', N'dbo', N'table', N'BFSFarbCode', N'column', N'BFSFrageID'
GO

GO
