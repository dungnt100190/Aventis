CREATE TABLE [dbo].[FaLeistungBewertung] (
	[FaBewertungID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaLeistungID] [int] NOT NULL ,
	[Termin] [datetime] NULL ,
	[Datum] [datetime] NULL ,
	[FaBewertungCode] [int] NULL ,
	[FaKriterienCodes] [varchar] (100) NULL ,
	[UserID] [int] NULL ,
	[FaLeistungBewertungTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaLeistungBewertung] PRIMARY KEY  Clustered
	(
		[FaBewertungID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_FaLeistungBewertung_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	),
	CONSTRAINT [FK_FaLeistungBewertung_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_FaLeistungBewertung_FaLeistungID] ON [dbo].[FaLeistungBewertung]([FaLeistungID]) ON [DATEN2]
GO
 CREATE  INDEX [IX_FaLeistungBewertung_UserID] ON [dbo].[FaLeistungBewertung]([UserID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FaLeistungBewertung Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FaLeistungBewertung', N'column', N'FaBewertungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaLeistungBewertung_FaLeistung) => FaLeistung.FaLeistungID', N'user', N'dbo', N'table', N'FaLeistungBewertung', N'column', N'FaLeistungID'
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
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FaLeistungBewertung_XUser) => XUser.UserID', N'user', N'dbo', N'table', N'FaLeistungBewertung', N'column', N'UserID'
GO

GO

GO

GO

GO
