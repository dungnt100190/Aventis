CREATE TABLE [dbo].[KbKostenstelle_BaPerson] (
	[KbKostenstelleBaPersonID] [int] IDENTITY (1, 1) NOT NULL ,
	[BaPersonID] [int] NOT NULL ,
	[KbKostenstelleID] [int] NOT NULL ,
	[DatumVon] [datetime] NULL ,
	[DatumBis] [datetime] NULL ,
	[Creator] [varchar] (50) NOT NULL ,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_KbKostenstelle_BaPerson_Created] DEFAULT (GetDate()),
	[Modifier] [varchar] (50) NOT NULL ,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_KbKostenstelle_BaPerson_Modified] DEFAULT (GetDate()),
	[KbKostenstelle_BaPersonTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbKostenstelle_BaPerson] PRIMARY KEY  Clustered
	(
		[KbKostenstelleBaPersonID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_KbKostenstelle_BaPerson_BaPersonID] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_KbKostenstelle_BaPerson_KbKostenstelleID] FOREIGN KEY
	(
		[KbKostenstelleID]
	) REFERENCES [dbo].[KbKostenstelle] (
		[KbKostenstelleID]
	) ON DELETE CASCADE
) ON [PRIMARY]
GO
 CREATE  INDEX [IX_KbKostenstelle_BaPerson_BaPersonID] ON [dbo].[KbKostenstelle_BaPerson]([BaPersonID]) ON [DATEN2]
GO
 CREATE  INDEX [IX_KbKostenstelle_BaPerson_KbKostenstelleID] ON [dbo].[KbKostenstelle_BaPerson]([KbKostenstelleID]) ON [DATEN2]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Um in KiSS4 die alten KiSS3 Kostenstellen anzuzeigen wurde in diese Hilfstabelle migriert.    Muss mit Implementation der Schnittstellen überarbeitet werden!', N'user', N'dbo', N'table', N'KbKostenstelle_BaPerson'
GO
EXEC sp_addextendedproperty N'Used_in', N'Inkasso', N'user', N'dbo', N'table', N'KbKostenstelle_BaPerson'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_BaPersonKbKostenstelle_BaPersonID) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'KbKostenstelle_BaPerson', N'column', N'BaPersonID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_BaPersonKbKostenstelle_KbKostenstelleID) => KbKostenstelle.KbKostenstelleID', N'user', N'dbo', N'table', N'KbKostenstelle_BaPerson', N'column', N'KbKostenstelleID'
GO

GO

GO

GO

GO
