CREATE TABLE [dbo].[BaPersonKbKostenstelle] (
	[BaPersonID] [int] NOT NULL ,
	[KbKostenstelleID] [int] NOT NULL ,
	[BaPersonKbKostenstelleTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BaPersonKbKostenstelle] PRIMARY KEY  Clustered
	(
		[BaPersonID],
		[KbKostenstelleID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_BaPersonKbKostenstelle_BaPersonID] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_BaPersonKbKostenstelle_KbKostenstelleID] FOREIGN KEY
	(
		[KbKostenstelleID]
	) REFERENCES [dbo].[KbKostenstelle] (
		[KbKostenstelleID]
	) ON DELETE CASCADE
) ON [PRIMARY]
GO
 CREATE  INDEX [IX_BaPersonKbKostenstelle] ON [dbo].[BaPersonKbKostenstelle]([BaPersonID], [KbKostenstelleID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_BaPersonKbKostenstelle_BaPersonID) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'BaPersonKbKostenstelle', N'column', N'BaPersonID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_BaPersonKbKostenstelle_KbKostenstelleID) => KbKostenstelle.KbKostenstelleID', N'user', N'dbo', N'table', N'BaPersonKbKostenstelle', N'column', N'KbKostenstelleID'
GO

GO

GO

GO

GO
