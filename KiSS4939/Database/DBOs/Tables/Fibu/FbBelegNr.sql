CREATE TABLE [dbo].[FbBelegNr] (
	[FbBelegNrID] [int] IDENTITY (1, 1) NOT NULL ,
	[BelegNrCode] [int] NOT NULL CONSTRAINT [DF_FbBelegNr_BelegNrCode] DEFAULT (0),
	[UserID] [int] NULL ,
	[BaPersonID] [int] NULL ,
	[NaechsteBelegNr] [int] NOT NULL ,
	[BelegNrVon] [int] NOT NULL ,
	[BelegNrBis] [int] NOT NULL ,
	[Praefix] [varchar] (10) NULL ,
	[FbBelegNrTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbBelegNr] PRIMARY KEY  Clustered
	(
		[FbBelegNrID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_FbBelegNr_DmgPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_FbBelegNr_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [DATEN2]
GO
 CREATE  INDEX [IX_FbBelegNr_UserID] ON [dbo].[FbBelegNr]([UserID]) ON [DATEN2]
GO
 CREATE  INDEX [IX_FbBelegNr_BaPersonID] ON [dbo].[FbBelegNr]([BaPersonID]) ON [DATEN2]
GO
 CREATE  Unique  INDEX [IX_FbBelegNr_BelegNrCodeUserIDBaPersonID_Unique] ON [dbo].[FbBelegNr]([BelegNrCode], [UserID], [BaPersonID]) WITH  FILLFACTOR = 90 ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbBelegNr Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbBelegNr', N'column', N'FbBelegNrID'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbBelegNr_XUser) => XUser.UserID', N'user', N'dbo', N'table', N'FbBelegNr', N'column', N'UserID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbBelegNr_DmgPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'FbBelegNr', N'column', N'BaPersonID'
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

GO

GO

GO
