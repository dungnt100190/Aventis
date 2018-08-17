CREATE TABLE [dbo].[FbDTABuchung] (
	[FbBuchungID] [int] NOT NULL ,
	[FbDTAJournalID] [int] NOT NULL ,
	[Status] [int] NOT NULL CONSTRAINT [DF__FbDTABuch__Statu__4007E458] DEFAULT (0),
	[FbDTABuchungTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbDTABuchung] PRIMARY KEY  Clustered
	(
		[FbBuchungID],
		[FbDTAJournalID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_FbBuchungDTA_FbBuchung] FOREIGN KEY
	(
		[FbBuchungID]
	) REFERENCES [dbo].[FbBuchung] (
		[FbBuchungID]
	),
	CONSTRAINT [FK_FbBuchungDTA_FbDTAJournal] FOREIGN KEY
	(
		[FbDTAJournalID]
	) REFERENCES [dbo].[FbDTAJournal] (
		[FbDTAJournalID]
	)
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbDTABuchung Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbDTABuchung', N'column', N'FbBuchungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbDTABuchung Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbDTABuchung', N'column', N'FbDTAJournalID'
GO

GO

GO

GO

GO

GO

GO

GO
