CREATE TABLE [dbo].[XClassReference] (
	[ClassName] [varchar] (255) NOT NULL ,
	[ClassName_Ref] [varchar] (255) NOT NULL ,
	[XClassReferenceTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XClassReference] PRIMARY KEY  Clustered
	(
		[ClassName],
		[ClassName_Ref]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_XClassReference_XClass] FOREIGN KEY
	(
		[ClassName]
	) REFERENCES [dbo].[XClass] (
		[ClassName]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_XClassReference_XClassRef] FOREIGN KEY
	(
		[ClassName_Ref]
	) REFERENCES [dbo].[XClass] (
		[ClassName]
	)
) ON [PRIMARY]
GO
 CREATE  INDEX [IX_XClassReference] ON [dbo].[XClassReference]([ClassName_Ref]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Beinhaltet s�mtliche Referenzen einer Klasse zu anderen Klassen, wobei je Klasse der Name der Referenz-Klasse eindeutig sein muss', N'user', N'dbo', N'table', N'XClassReference'
GO
EXEC sp_addextendedproperty N'Used_in', N'KiSS Core, Business Designer', N'user', N'dbo', N'table', N'XClassReference'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Prim�rschl�ssel f�r XClassReference Records (nach Prim�rschl�ssel-Standards), Prim�rschl�ssel zusammen mit ClassName_Ref (Unique), Fremdschl�ssel auf XClass.ClassName.', N'user', N'dbo', N'table', N'XClassReference', N'column', N'ClassName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Prim�rschl�ssel f�r XClassReference Records (nach Prim�rschl�ssel-Standards), Prim�rschl�ssel zusammen mit ClassName (Unique), Name der jeweiligen Klasse, welche Referenziert wird. Fremdschl�ssel (FK_XClassReference_XClassRef) => XClass.ClassName', N'user', N'dbo', N'table', N'XClassReference', N'column', N'ClassName_Ref'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird f�r die �nderungsverfolgung verwendet', N'user', N'dbo', N'table', N'XClassReference', N'column', N'XClassReferenceTS'
GO

GO
