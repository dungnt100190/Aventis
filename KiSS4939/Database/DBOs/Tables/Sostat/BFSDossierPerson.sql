CREATE TABLE [dbo].[BFSDossierPerson] (
	[BFSDossierPersonID] [int] IDENTITY (1, 1) NOT NULL ,
	[BFSDossierID] [int] NOT NULL ,
	[BFSPersonCode] [int] NOT NULL ,
	[PersonIndex] [int] NOT NULL ,
	[PersonName] [varchar] (100) NULL ,
	[BaPersonID] [int] NULL ,
	[BFSDossierPersonTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BFSDossierPerson] PRIMARY KEY  Clustered
	(
		[BFSDossierPersonID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_BFSDossierPerson_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_BFSDossierPerson_BFSDossier] FOREIGN KEY
	(
		[BFSDossierID]
	) REFERENCES [dbo].[BFSDossier] (
		[BFSDossierID]
	) ON DELETE CASCADE
) ON [DATEN3]
GO
 CREATE  Unique  INDEX [IX_BFSDossierPerson_BFSDossierIDBFSPersonCOdePersonIndex_Unique] ON [dbo].[BFSDossierPerson]([BFSDossierID], [BFSPersonCode], [PersonIndex]) ON [DATEN3]
GO
 CREATE  INDEX [IX_BFSDossierPerson_1] ON [dbo].[BFSDossierPerson]([BFSDossierPersonID]) ON [DATEN3]
GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_BFSDossierPerson_BFSDossier) => BFSDossier.BFSDossierID', N'user', N'dbo', N'table', N'BFSDossierPerson', N'column', N'BFSDossierID'
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
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_BFSDossierPerson_BaPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'BFSDossierPerson', N'column', N'BaPersonID'
GO

GO

GO

GO

GO
