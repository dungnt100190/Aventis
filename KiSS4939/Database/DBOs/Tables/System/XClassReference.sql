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
EXEC sp_addextendedproperty N'MS_Description', N'Beinhaltet sämtliche Referenzen einer Klasse zu anderen Klassen, wobei je Klasse der Name der Referenz-Klasse eindeutig sein muss', N'user', N'dbo', N'table', N'XClassReference'
GO
EXEC sp_addextendedproperty N'Used_in', N'KiSS Core, Business Designer', N'user', N'dbo', N'table', N'XClassReference'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XClassReference Records (nach Primärschlüssel-Standards), Primärschlüssel zusammen mit ClassName_Ref (Unique), Fremdschlüssel auf XClass.ClassName.', N'user', N'dbo', N'table', N'XClassReference', N'column', N'ClassName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XClassReference Records (nach Primärschlüssel-Standards), Primärschlüssel zusammen mit ClassName (Unique), Name der jeweiligen Klasse, welche Referenziert wird. Fremdschlüssel (FK_XClassReference_XClassRef) => XClass.ClassName', N'user', N'dbo', N'table', N'XClassReference', N'column', N'ClassName_Ref'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird für die Änderungsverfolgung verwendet', N'user', N'dbo', N'table', N'XClassReference', N'column', N'XClassReferenceTS'
GO

GO
