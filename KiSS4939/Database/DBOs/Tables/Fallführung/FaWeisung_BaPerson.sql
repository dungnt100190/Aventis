CREATE TABLE [dbo].[FaWeisung_BaPerson] (
	[FaWeisung_BaPersonID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaWeisungID] [int] NOT NULL ,
	[BaPersonID] [int] NOT NULL ,
	[FaWeisung_BaPersonTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaWeisung_BaPerson] PRIMARY KEY  Clustered
	(
		[FaWeisung_BaPersonID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_FaWeisung_BaPerson_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	),
	CONSTRAINT [FK_FaWeisung_BaPerson_FaWeisung] FOREIGN KEY
	(
		[FaWeisungID]
	) REFERENCES [dbo].[FaWeisung] (
		[FaWeisungID]
	) ON DELETE CASCADE
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Beinhaltet betroffene Personen von einer Weisung', N'user', N'dbo', N'table', N'FaWeisung_BaPerson'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für FaWeisung_BaPerson Records', N'user', N'dbo', N'table', N'FaWeisung_BaPerson', N'column', N'FaWeisung_BaPersonID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel auf FaWeisung', N'user', N'dbo', N'table', N'FaWeisung_BaPerson', N'column', N'FaWeisungID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fredmschlüssel auf BaPerson', N'user', N'dbo', N'table', N'FaWeisung_BaPerson', N'column', N'BaPersonID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird für die Änderungsverfolgung verwendet', N'user', N'dbo', N'table', N'FaWeisung_BaPerson', N'column', N'FaWeisung_BaPersonTS'
GO
