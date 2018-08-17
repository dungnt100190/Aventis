CREATE TABLE [dbo].[FbBuchungCode] (
	[FbBuchungCodeID] [int] IDENTITY (1, 1) NOT NULL ,
	[Code] [varchar] (10) NOT NULL ,
	[BaPersonID] [int] NULL ,
	[SollKtoNr] [int] NULL ,
	[HabenKtoNr] [int] NULL ,
	[Betrag] [money] NULL ,
	[Text] [varchar] (200) NULL ,
	[UserID] [int] NULL ,
	[FbBuchungCodeTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbBuchungCode] PRIMARY KEY  Clustered
	(
		[FbBuchungCodeID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_FbBuchungCode_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_FbBuchungCode_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [DATEN3]
GO
 CREATE  INDEX [IX_FbBuchungCode_BaPersonID] ON [dbo].[FbBuchungCode]([BaPersonID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_FbBuchungCode_UserID] ON [dbo].[FbBuchungCode]([UserID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_FbBuchungCode_Code] ON [dbo].[FbBuchungCode]([Code]) ON [DATEN3]
GO
 CREATE  Unique  INDEX [IX_FbBuchungCode_CodeBaPersonID_Unique] ON [dbo].[FbBuchungCode]([Code], [BaPersonID]) WITH  FILLFACTOR = 90 ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbBuchungCode Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbBuchungCode', N'column', N'FbBuchungCodeID'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbBuchungCode_BaPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'FbBuchungCode', N'column', N'BaPersonID'
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
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbBuchungCode_XUser) => XUser.UserID', N'user', N'dbo', N'table', N'FbBuchungCode', N'column', N'UserID'
GO

GO

GO

GO

GO
