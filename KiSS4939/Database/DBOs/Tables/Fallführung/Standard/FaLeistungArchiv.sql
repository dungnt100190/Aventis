CREATE TABLE [dbo].[FaLeistungArchiv] (
	[FaLeistungArchivID] [int] IDENTITY (1, 1) NOT NULL ,
	[ArchiveID] [int] NOT NULL ,
	[FaLeistungID] [int] NOT NULL ,
	[ArchivNr] [varchar] (100) NULL ,
	[CheckIn] [datetime] NOT NULL CONSTRAINT [DF_FaLeistungArchiv_CheckIn] DEFAULT (GetDate()),
	[CheckOut] [datetime] NULL ,
	[CheckInUserID] [int] NOT NULL ,
	[CheckOutUserID] [int] NULL ,
	[FaLeistungArchivTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaLeistungArchiv] PRIMARY KEY  Clustered
	(
		[FaLeistungArchivID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_FaLeistungArchiv_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_FaLeistungArchiv_XArchive] FOREIGN KEY
	(
		[ArchiveID]
	) REFERENCES [dbo].[XArchive] (
		[ArchiveID]
	),
	CONSTRAINT [FK_FaLeistungArchiv_XUser] FOREIGN KEY
	(
		[CheckInUserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	),
	CONSTRAINT [FK_FaLeistungArchiv_XUser1] FOREIGN KEY
	(
		[CheckOutUserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	)
) ON [DATEN1]
GO
 CREATE  INDEX [IX_FaLeistungArchiv_ArchiveID] ON [dbo].[FaLeistungArchiv]([ArchiveID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_FaLeistungArchiv_FaLeistungID] ON [dbo].[FaLeistungArchiv]([FaLeistungID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_FaLeistungArchiv_CheckInUserID] ON [dbo].[FaLeistungArchiv]([CheckInUserID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_FaLeistungArchiv_CheckOutUserID] ON [dbo].[FaLeistungArchiv]([CheckOutUserID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_FaLeistungArchiv_CheckOut] ON [dbo].[FaLeistungArchiv]([CheckOut]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FaLeistungArchiv Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FaLeistungArchiv', N'column', N'FaLeistungArchivID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaLeistungArchiv_XArchive) => XArchive.ArchiveID', N'user', N'dbo', N'table', N'FaLeistungArchiv', N'column', N'ArchiveID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaLeistungArchiv_FaLeistung) => FaLeistung.FaLeistungID', N'user', N'dbo', N'table', N'FaLeistungArchiv', N'column', N'FaLeistungID'
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
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaLeistungArchiv_XUser) => XUser.UserID', N'user', N'dbo', N'table', N'FaLeistungArchiv', N'column', N'CheckInUserID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaLeistungArchiv_XUser1) => XUser.UserID', N'user', N'dbo', N'table', N'FaLeistungArchiv', N'column', N'CheckOutUserID'
GO

GO

GO

GO

GO
